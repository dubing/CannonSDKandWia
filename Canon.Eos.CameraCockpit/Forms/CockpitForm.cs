using System;
using System.Drawing;
using System.Windows.Forms;
using Canon.Eos.CameraCockpit.Properties;
using Canon.Eos.Framework;
using Canon.Eos.Framework.Eventing;
using WIA;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Canon.Eos.CameraCockpit.Forms
{
    public partial class CockpitForm : Form
    {
        private readonly FrameworkManager _manager;
        // make these global or they will go out of scope
        DeviceManager wiaDevManager = null;
        Device wiaDevice = null;
        List<string> downloadPicList;

        public CockpitForm()
        {
            _manager = new FrameworkManager();
            _manager.CameraAdded += this.HandleCameraAdded;
            this.InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.StartUp();
            this.LoadCameras();
        }

        private EosCamera GetSelectedCamera()
        {
            return _cameraCollectionComboBox.Items.Count > 0 && _cameraCollectionComboBox.SelectedIndex >= 0
                ? _cameraCollectionComboBox.SelectedItem as EosCamera : null;
        }

        private void HandleCameraAdded(object sender, EventArgs e)
        {
            this.LoadCameras();
        }

        private void HandleCameraSelectionChanged(object sender, EventArgs e)
        {
            this.UpdateCameraControls();
        }

        private void UpdateCameraControls()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(this.UpdateCameraControls));
                return;
            }

            var camera = this.GetSelectedCamera();
            if (camera == null)
            {
                _liveViewButton.Enabled = false;
                _takePictureButton.Enabled = false;
            }
            else
            {
                try
                {
                    if (camera.IsInHostLiveViewMode)
                    {
                        _liveViewButton.Text = Resources.StopLiveViewButtonLabel;
                        _takePictureButton.Enabled = false;
                        _liveViewPictureButton.Enabled = true;
                    }
                    else
                    {
                        _liveViewButton.Text = Resources.StartLiveViewButtonLabel;
                        _takePictureButton.Enabled = true;
                        _liveViewPictureButton.Enabled = false;
                    }
                    _liveViewButton.Enabled = true;
                }
                catch (EosException)
                {
                    _liveViewButton.Text = Resources.LiveViewNotSupportedButtonLabel;
                    _takePictureButton.Enabled = false;
                }
            }
        }

        private void HandleCameraShutdown(object sender, EventArgs e)
        {
            this.LoadCameras();
            this.UpdateCameraControls();
        }

        private void HandlePictureUpdate(object sender, EosImageEventArgs e)
        {
            this.UpdatePicture(e.GetImage());
        }

        private void HandleTakePictureButtonClick(object sender, EventArgs e)
        {
            this.SafeCall(() =>
            {
                var camera = this.GetSelectedCamera();
                if (camera != null)
                    camera.TakePicture();
            }, ex => MessageBox.Show(ex.ToString(), Resources.TakePictureError, MessageBoxButtons.OK, MessageBoxIcon.Error));
        }

        private void LoadCameras()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(this.LoadCameras));
            }
            else
            {
                _cameraCollectionComboBox.Items.Clear();
                foreach (var camera in _manager.GetCameras())
                {
                    camera.Shutdown += this.HandleCameraShutdown;
                    camera.PictureTaken += this.HandlePictureUpdate;
                    camera.LiveViewUpdate += this.HandlePictureUpdate;
                    camera.LiveViewStopped += new EventHandler(camera_LiveViewStopped);
                    camera.LiveViewPaused += new EventHandler(camera_LiveViewPaused);

                    _cameraCollectionComboBox.Items.Add(camera);
                }
                if (_cameraCollectionComboBox.Items.Count > 0)
                    _cameraCollectionComboBox.SelectedIndex = 0;
            }
        }

        private void StartUp()
        {
            this.SafeCall(() =>
            {
                _cameraCollectionComboBox.SelectedIndexChanged += this.HandleCameraSelectionChanged;
                _liveViewButton.Enabled = false;
                _takePictureButton.Enabled = false;
                _manager.LoadFramework();
            }, ex =>
            {
                MessageBox.Show(ex.ToString(), Resources.FrameworkLoadError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            });
        }

        private void TearDown()
        {
            _manager.ReleaseFramework();
        }

        private void UpdatePicture(Image image)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => this.UpdatePicture(image)));
            else
                _pictureBox.Image = image;
        }

        private void SafeCall(Action action, Action<Exception> exceptionHandler)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired) this.Invoke(exceptionHandler, ex);
                else exceptionHandler(ex);
            }
        }

        private void HandleLiveViewButtonClick(object sender, EventArgs e)
        {
            this.SafeCall(() =>
            {
                var camera = this.GetSelectedCamera();
                if (camera == null)
                    return;

                if (camera.IsInHostLiveViewMode) camera.StopLiveView();
                else camera.StartLiveView(EosLiveViewAutoFocus.QuickMode);

                this.UpdateCameraControls();
            }, ex => { });
        }

        private void camera_LiveViewStopped(object sender, EventArgs e)
        {
            UpdateCameraControls();
        }

        private void camera_LiveViewResume()
        {
            this.SafeCall(() =>
            {
                var camera = this.GetSelectedCamera();
                if (camera != null)
                    camera.ResumeLiveview();
            }, ex =>
            {
                MessageBox.Show(ex.ToString(), Resources.TakePictureError, MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        public void camera_LiveViewPaused(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
                this.Invoke(new Action(() => this.camera_LiveViewPaused(sender, e)));
            else
                this.SafeCall(() =>
                {
                    var camera = this.GetSelectedCamera();
                    if (camera != null)
                        camera.TakePicture();
                }, ex =>
                {
                    MessageBox.Show(ex.ToString(), Resources.TakePictureError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    camera_LiveViewResume();
                });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.SafeCall(() =>
            {
                var camera = this.GetSelectedCamera();
                if (camera != null)
                    camera.TakePictureInLiveview();
            }, ex => MessageBox.Show(ex.ToString(), Resources.TakePictureError, MessageBoxButtons.OK, MessageBoxIcon.Error));
        }

        private void _storePicturesOnCameraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.SafeCall(() =>
            {
                var camera = this.GetSelectedCamera();
                if (camera != null)
                {
                    if (_storePicturesOnCameraRadioButton.Checked)
                    {
                        camera.SavePicturesToCamera();
                    }
                    else
                    {
                        camera.SavePicturesToHost(_picturesOnHostLocationTextBox.Text);
                    }
                }
            }, ex => MessageBox.Show(ex.ToString(), "Problem setting Savelocation", MessageBoxButtons.OK, MessageBoxIcon.Error));

        }

        private void _browsePicturesOnHostLocationButton_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr.Equals(DialogResult.OK))
            {
                _picturesOnHostLocationTextBox.Text = folderBrowserDialog1.SelectedPath;
                _storePicturesOnCameraRadioButton_CheckedChanged(null, null);
            }
        }

        private void btnLoadPic_Click(object sender, EventArgs e)
        {
            this.SafeCall(() =>
            {
                //if (ConnectToCamera())
                //{
                //    DownJpg();
                //}
                DownJpgFromAllCamera();
            }, ex => MessageBox.Show(ex.ToString(), "Problem setting Savelocation", MessageBoxButtons.OK, MessageBoxIcon.Error));
                              
        }

        public void DownJpg(string DeviceID)
        {
            //this.txtMsg.Text = "";
            WIA.ImageFile wiaImageFile = null;
            //bool Success = false;
            string fullName = "";

            List<string> OriginalNames = new List<string>();
            List<string> NewNames = new List<string>();

            for (int i = 1; i < wiaDevice.Items.Count; i++)
            {
                string oldName = wiaDevice.Items[i].ItemID;

                // Get the picture file from the camera
                // the FormatID doesn't seem to matter, 
                // you can even transfer a JPEG file using wiaFormatTIFF
                wiaImageFile = (WIA.ImageFile)wiaDevice.Items[i].Transfer(FormatID.wiaFormatJPEG);

                string extension = wiaImageFile.FileExtension.ToLower().Trim();

                fullName = oldName;
                if (extension.Length > 0)
                {
                    fullName += "." + extension;
                }

                string newName = _picturesOnHostLocationTextBox.Text + "\\" + Guid.NewGuid() + "." + extension;
                wiaImageFile.SaveFile(newName);

                this.txtMsg.Text += "Saving " + oldName + "." + extension + " as " + newName + "\r\n";

                if (wiaImageFile != null)
                {
                    Marshal.ReleaseComObject(wiaImageFile);
                }
            }


        }

        public void DownJpgFromAllCamera()
        {

            foreach (IDeviceInfo DevInfo in new DeviceManagerClass().DeviceInfos)
            {
                if (DevInfo.Type == WiaDeviceType.CameraDeviceType)
                {
                    string DeviceID = DevInfo.DeviceID;
                    wiaDevice = DevInfo.Connect();
                    DownJpg(DeviceID);                  
                }
            }



        }

        //// True for connected, False for not
        //public bool ConnectToCamera()
        //{
        //    // Device is already connected
        //    if (wiaDevice != null)
        //        return true;

        //    foreach (IDeviceInfo DevInfo in new DeviceManagerClass().DeviceInfos)
        //    {
        //        if (DevInfo.Type == WiaDeviceType.CameraDeviceType)
        //        {
        //            string tilte = DevInfo.DeviceID;
        //            wiaDevice = DevInfo.Connect();

        //            return true;
        //        }
        //    }
        //    // Not a still camera
        //    return false;


        //}
    }
}
