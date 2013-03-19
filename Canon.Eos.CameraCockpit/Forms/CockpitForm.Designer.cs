namespace Canon.Eos.CameraCockpit.Forms
{
    partial class CockpitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.TearDown();
                if(components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._controlPanel = new System.Windows.Forms.Panel();
            this.btnLoadPic = new System.Windows.Forms.Button();
            this._liveViewPictureButton = new System.Windows.Forms.Button();
            this._liveViewButton = new System.Windows.Forms.Button();
            this._selectCameraLabel = new System.Windows.Forms.Label();
            this._cameraCollectionComboBox = new System.Windows.Forms.ComboBox();
            this._takePictureButton = new System.Windows.Forms.Button();
            this._storePicturesOnCameraRadioButton = new System.Windows.Forms.RadioButton();
            this._storePicturesOnHostRadioButton = new System.Windows.Forms.RadioButton();
            this._picturesOnHostLocationTextBox = new System.Windows.Forms.TextBox();
            this._browsePicturesOnHostLocationButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btn_Prev = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this._pictureBox02 = new System.Windows.Forms.PictureBox();
            this.btnNext02 = new System.Windows.Forms.Button();
            this.btnPrev02 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this._controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox02)).BeginInit();
            this.SuspendLayout();
            // 
            // _pictureBox
            // 
            this._pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._pictureBox.Location = new System.Drawing.Point(12, 86);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Size = new System.Drawing.Size(280, 279);
            this._pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pictureBox.TabIndex = 0;
            this._pictureBox.TabStop = false;
            // 
            // _controlPanel
            // 
            this._controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._controlPanel.Controls.Add(this.btnLoadPic);
            this._controlPanel.Controls.Add(this._liveViewPictureButton);
            this._controlPanel.Controls.Add(this._liveViewButton);
            this._controlPanel.Controls.Add(this._selectCameraLabel);
            this._controlPanel.Controls.Add(this._cameraCollectionComboBox);
            this._controlPanel.Controls.Add(this._takePictureButton);
            this._controlPanel.Location = new System.Drawing.Point(614, 12);
            this._controlPanel.Name = "_controlPanel";
            this._controlPanel.Size = new System.Drawing.Size(200, 654);
            this._controlPanel.TabIndex = 1;
            // 
            // btnLoadPic
            // 
            this.btnLoadPic.Location = new System.Drawing.Point(3, 273);
            this.btnLoadPic.Name = "btnLoadPic";
            this.btnLoadPic.Size = new System.Drawing.Size(197, 69);
            this.btnLoadPic.TabIndex = 5;
            this.btnLoadPic.Text = "Load Pic";
            this.btnLoadPic.UseVisualStyleBackColor = true;
            this.btnLoadPic.Click += new System.EventHandler(this.btnLoadPic_Click);
            // 
            // _liveViewPictureButton
            // 
            this._liveViewPictureButton.Enabled = false;
            this._liveViewPictureButton.Location = new System.Drawing.Point(-1, 198);
            this._liveViewPictureButton.Name = "_liveViewPictureButton";
            this._liveViewPictureButton.Size = new System.Drawing.Size(197, 69);
            this._liveViewPictureButton.TabIndex = 4;
            this._liveViewPictureButton.Text = "Take Liveview Picture ";
            this._liveViewPictureButton.UseVisualStyleBackColor = true;
            this._liveViewPictureButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // _liveViewButton
            // 
            this._liveViewButton.Location = new System.Drawing.Point(-1, 123);
            this._liveViewButton.Name = "_liveViewButton";
            this._liveViewButton.Size = new System.Drawing.Size(197, 69);
            this._liveViewButton.TabIndex = 3;
            this._liveViewButton.Text = "LiveView";
            this._liveViewButton.UseVisualStyleBackColor = true;
            this._liveViewButton.Click += new System.EventHandler(this.HandleLiveViewButtonClick);
            // 
            // _selectCameraLabel
            // 
            this._selectCameraLabel.AutoSize = true;
            this._selectCameraLabel.Location = new System.Drawing.Point(3, 5);
            this._selectCameraLabel.Name = "_selectCameraLabel";
            this._selectCameraLabel.Size = new System.Drawing.Size(76, 13);
            this._selectCameraLabel.TabIndex = 2;
            this._selectCameraLabel.Text = "Select Camera";
            // 
            // _cameraCollectionComboBox
            // 
            this._cameraCollectionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cameraCollectionComboBox.FormattingEnabled = true;
            this._cameraCollectionComboBox.Location = new System.Drawing.Point(2, 21);
            this._cameraCollectionComboBox.Name = "_cameraCollectionComboBox";
            this._cameraCollectionComboBox.Size = new System.Drawing.Size(194, 21);
            this._cameraCollectionComboBox.TabIndex = 1;
            // 
            // _takePictureButton
            // 
            this._takePictureButton.Location = new System.Drawing.Point(-1, 48);
            this._takePictureButton.Name = "_takePictureButton";
            this._takePictureButton.Size = new System.Drawing.Size(197, 69);
            this._takePictureButton.TabIndex = 0;
            this._takePictureButton.Text = "Take Picture";
            this._takePictureButton.UseVisualStyleBackColor = true;
            this._takePictureButton.Click += new System.EventHandler(this.HandleTakePictureButtonClick);
            // 
            // _storePicturesOnCameraRadioButton
            // 
            this._storePicturesOnCameraRadioButton.AutoSize = true;
            this._storePicturesOnCameraRadioButton.Checked = true;
            this._storePicturesOnCameraRadioButton.Location = new System.Drawing.Point(12, 15);
            this._storePicturesOnCameraRadioButton.Name = "_storePicturesOnCameraRadioButton";
            this._storePicturesOnCameraRadioButton.Size = new System.Drawing.Size(145, 17);
            this._storePicturesOnCameraRadioButton.TabIndex = 2;
            this._storePicturesOnCameraRadioButton.TabStop = true;
            this._storePicturesOnCameraRadioButton.Text = "Store Pictures on Camera";
            this._storePicturesOnCameraRadioButton.UseVisualStyleBackColor = true;
            this._storePicturesOnCameraRadioButton.CheckedChanged += new System.EventHandler(this._storePicturesOnCameraRadioButton_CheckedChanged);
            // 
            // _storePicturesOnHostRadioButton
            // 
            this._storePicturesOnHostRadioButton.AutoSize = true;
            this._storePicturesOnHostRadioButton.Location = new System.Drawing.Point(12, 38);
            this._storePicturesOnHostRadioButton.Name = "_storePicturesOnHostRadioButton";
            this._storePicturesOnHostRadioButton.Size = new System.Drawing.Size(131, 17);
            this._storePicturesOnHostRadioButton.TabIndex = 3;
            this._storePicturesOnHostRadioButton.Text = "Store Pictures on Host";
            this._storePicturesOnHostRadioButton.UseVisualStyleBackColor = true;
            // 
            // _picturesOnHostLocationTextBox
            // 
            this._picturesOnHostLocationTextBox.Location = new System.Drawing.Point(30, 60);
            this._picturesOnHostLocationTextBox.Name = "_picturesOnHostLocationTextBox";
            this._picturesOnHostLocationTextBox.Size = new System.Drawing.Size(525, 20);
            this._picturesOnHostLocationTextBox.TabIndex = 4;
            this._picturesOnHostLocationTextBox.Text = "c:\\canonimages";
            // 
            // _browsePicturesOnHostLocationButton
            // 
            this._browsePicturesOnHostLocationButton.Location = new System.Drawing.Point(561, 60);
            this._browsePicturesOnHostLocationButton.Name = "_browsePicturesOnHostLocationButton";
            this._browsePicturesOnHostLocationButton.Size = new System.Drawing.Size(46, 20);
            this._browsePicturesOnHostLocationButton.TabIndex = 5;
            this._browsePicturesOnHostLocationButton.Text = "...";
            this._browsePicturesOnHostLocationButton.UseVisualStyleBackColor = true;
            this._browsePicturesOnHostLocationButton.Click += new System.EventHandler(this._browsePicturesOnHostLocationButton_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(12, 415);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(595, 251);
            this.txtMsg.TabIndex = 6;
            // 
            // btn_Prev
            // 
            this.btn_Prev.Location = new System.Drawing.Point(136, 371);
            this.btn_Prev.Name = "btn_Prev";
            this.btn_Prev.Size = new System.Drawing.Size(75, 23);
            this.btn_Prev.TabIndex = 7;
            this.btn_Prev.Text = "上一张";
            this.btn_Prev.UseVisualStyleBackColor = true;
            this.btn_Prev.Click += new System.EventHandler(this.btn_Prev_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Location = new System.Drawing.Point(217, 371);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(75, 23);
            this.btn_Next.TabIndex = 8;
            this.btn_Next.Text = "下一张";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // _pictureBox02
            // 
            this._pictureBox02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._pictureBox02.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._pictureBox02.Location = new System.Drawing.Point(328, 86);
            this._pictureBox02.Name = "_pictureBox02";
            this._pictureBox02.Size = new System.Drawing.Size(279, 279);
            this._pictureBox02.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pictureBox02.TabIndex = 9;
            this._pictureBox02.TabStop = false;
            // 
            // btnNext02
            // 
            this.btnNext02.Location = new System.Drawing.Point(531, 371);
            this.btnNext02.Name = "btnNext02";
            this.btnNext02.Size = new System.Drawing.Size(75, 23);
            this.btnNext02.TabIndex = 11;
            this.btnNext02.Text = "下一张";
            this.btnNext02.UseVisualStyleBackColor = true;
            this.btnNext02.Click += new System.EventHandler(this.btnNext02_Click);
            // 
            // btnPrev02
            // 
            this.btnPrev02.Location = new System.Drawing.Point(450, 371);
            this.btnPrev02.Name = "btnPrev02";
            this.btnPrev02.Size = new System.Drawing.Size(75, 23);
            this.btnPrev02.TabIndex = 10;
            this.btnPrev02.Text = "上一张";
            this.btnPrev02.UseVisualStyleBackColor = true;
            this.btnPrev02.Click += new System.EventHandler(this.btnPrev02_Click);
            // 
            // CockpitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 678);
            this.Controls.Add(this.btnNext02);
            this.Controls.Add(this.btnPrev02);
            this.Controls.Add(this._pictureBox02);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.btn_Prev);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this._browsePicturesOnHostLocationButton);
            this.Controls.Add(this._picturesOnHostLocationTextBox);
            this.Controls.Add(this._storePicturesOnHostRadioButton);
            this.Controls.Add(this._storePicturesOnCameraRadioButton);
            this.Controls.Add(this._controlPanel);
            this.Controls.Add(this._pictureBox);
            this.Name = "CockpitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camera Cockpit";
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this._controlPanel.ResumeLayout(false);
            this._controlPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox02)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _pictureBox;
        private System.Windows.Forms.Panel _controlPanel;
        private System.Windows.Forms.Button _takePictureButton;
        private System.Windows.Forms.RadioButton _storePicturesOnCameraRadioButton;
        private System.Windows.Forms.RadioButton _storePicturesOnHostRadioButton;
        private System.Windows.Forms.TextBox _picturesOnHostLocationTextBox;
        private System.Windows.Forms.Button _browsePicturesOnHostLocationButton;
        private System.Windows.Forms.Label _selectCameraLabel;
        private System.Windows.Forms.ComboBox _cameraCollectionComboBox;
        private System.Windows.Forms.Button _liveViewButton;
        private System.Windows.Forms.Button _liveViewPictureButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnLoadPic;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btn_Prev;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.PictureBox _pictureBox02;
        private System.Windows.Forms.Button btnNext02;
        private System.Windows.Forms.Button btnPrev02;
    }
}

