namespace youtube_dl_gui
{
    partial class frmSettings
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
            if (disposing && (components != null))
            {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.btnRedownload = new System.Windows.Forms.Button();
            this.btnBrws = new System.Windows.Forms.Button();
            this.txtDownloadLocation = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.numUpdateDays = new System.Windows.Forms.NumericUpDown();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.chkDeleteExecutable = new System.Windows.Forms.CheckBox();
            this.chkAutoClearURL = new System.Windows.Forms.CheckBox();
            this.chkHoverURL = new System.Windows.Forms.CheckBox();
            this.chkSaveArgs = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ttHelp = new System.Windows.Forms.ToolTip(this.components);
            this.chkSaveToMaster = new System.Windows.Forms.CheckBox();
            this.chkSeperateDownloads = new System.Windows.Forms.CheckBox();
            this.btnYtDl = new System.Windows.Forms.Button();
            this.txtYtDl = new System.Windows.Forms.TextBox();
            this.chkUpdateCheck = new System.Windows.Forms.CheckBox();
            this.chkSaveDLParams = new System.Windows.Forms.CheckBox();
            this.chkSaveConvParams = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.chkStaticYTDL = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabDownloads = new System.Windows.Forms.TabPage();
            this.lbDlSeperator = new System.Windows.Forms.Label();
            this.tabConverter = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateDays)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.tabDownloads.SuspendLayout();
            this.tabConverter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRedownload
            // 
            this.btnRedownload.Location = new System.Drawing.Point(60, 175);
            this.btnRedownload.Name = "btnRedownload";
            this.btnRedownload.Size = new System.Drawing.Size(186, 24);
            this.btnRedownload.TabIndex = 32;
            this.btnRedownload.Text = "Redownload youtube-dl application";
            this.ttHelp.SetToolTip(this.btnRedownload, "Redownload youtube-dl.exe if it seems to not work.");
            this.btnRedownload.UseVisualStyleBackColor = true;
            this.btnRedownload.Click += new System.EventHandler(this.btnRedownload_Click);
            // 
            // btnBrws
            // 
            this.btnBrws.Location = new System.Drawing.Point(270, 30);
            this.btnBrws.Name = "btnBrws";
            this.btnBrws.Size = new System.Drawing.Size(25, 20);
            this.btnBrws.TabIndex = 31;
            this.btnBrws.Text = "...";
            this.ttHelp.SetToolTip(this.btnBrws, "Browse for a new download path");
            this.btnBrws.UseVisualStyleBackColor = true;
            this.btnBrws.Click += new System.EventHandler(this.btnBrws_Click);
            // 
            // txtDownloadLocation
            // 
            this.txtDownloadLocation.Location = new System.Drawing.Point(23, 30);
            this.txtDownloadLocation.Name = "txtDownloadLocation";
            this.txtDownloadLocation.ReadOnly = true;
            this.txtDownloadLocation.Size = new System.Drawing.Size(241, 20);
            this.txtDownloadLocation.TabIndex = 30;
            this.ttHelp.SetToolTip(this.txtDownloadLocation, "The location where videos will get downloaded");
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(11, 12);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(79, 13);
            this.Label1.TabIndex = 29;
            this.Label1.Text = "Download path";
            // 
            // numUpdateDays
            // 
            this.numUpdateDays.Enabled = false;
            this.numUpdateDays.Location = new System.Drawing.Point(184, 142);
            this.numUpdateDays.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numUpdateDays.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpdateDays.Name = "numUpdateDays";
            this.numUpdateDays.Size = new System.Drawing.Size(49, 20);
            this.numUpdateDays.TabIndex = 28;
            this.numUpdateDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ttHelp.SetToolTip(this.numUpdateDays, "Amount of days to wait.");
            this.numUpdateDays.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkUpdate
            // 
            this.chkUpdate.AutoSize = true;
            this.chkUpdate.Enabled = false;
            this.chkUpdate.Location = new System.Drawing.Point(25, 143);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.Size = new System.Drawing.Size(248, 17);
            this.chkUpdate.TabIndex = 27;
            this.chkUpdate.Text = "Update youtube-dl.exe every   xxxxxxx     day(s)";
            this.ttHelp.SetToolTip(this.chkUpdate, "After X amount of days, download a fresh version of youtube-dl.");
            this.chkUpdate.UseVisualStyleBackColor = true;
            // 
            // chkDeleteExecutable
            // 
            this.chkDeleteExecutable.AutoSize = true;
            this.chkDeleteExecutable.Location = new System.Drawing.Point(25, 120);
            this.chkDeleteExecutable.Name = "chkDeleteExecutable";
            this.chkDeleteExecutable.Size = new System.Drawing.Size(256, 17);
            this.chkDeleteExecutable.TabIndex = 26;
            this.chkDeleteExecutable.Text = "Automatically delete youtube-dl.exe when closing";
            this.ttHelp.SetToolTip(this.chkDeleteExecutable, "Deletes youtube-dl.exe when exiting.");
            this.chkDeleteExecutable.UseVisualStyleBackColor = true;
            // 
            // chkAutoClearURL
            // 
            this.chkAutoClearURL.AutoSize = true;
            this.chkAutoClearURL.Checked = true;
            this.chkAutoClearURL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoClearURL.Location = new System.Drawing.Point(18, 141);
            this.chkAutoClearURL.Name = "chkAutoClearURL";
            this.chkAutoClearURL.Size = new System.Drawing.Size(214, 17);
            this.chkAutoClearURL.TabIndex = 25;
            this.chkAutoClearURL.Text = "Auto-Clear URL when starting download";
            this.ttHelp.SetToolTip(this.chkAutoClearURL, "Automatically clear the Download URL text box and clipboard when starting the dow" +
        "nload.");
            this.chkAutoClearURL.UseVisualStyleBackColor = true;
            // 
            // chkHoverURL
            // 
            this.chkHoverURL.AutoSize = true;
            this.chkHoverURL.Checked = true;
            this.chkHoverURL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHoverURL.Location = new System.Drawing.Point(18, 118);
            this.chkHoverURL.Name = "chkHoverURL";
            this.chkHoverURL.Size = new System.Drawing.Size(247, 17);
            this.chkHoverURL.TabIndex = 24;
            this.chkHoverURL.Text = "Hover over URL textbox to paste clipboard text";
            this.chkHoverURL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttHelp.SetToolTip(this.chkHoverURL, "When hovering over the Download URL, automatically paste the text  in the clipboa" +
        "rd.");
            this.chkHoverURL.UseVisualStyleBackColor = true;
            // 
            // chkSaveArgs
            // 
            this.chkSaveArgs.AutoSize = true;
            this.chkSaveArgs.Checked = true;
            this.chkSaveArgs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveArgs.Location = new System.Drawing.Point(18, 164);
            this.chkSaveArgs.Name = "chkSaveArgs";
            this.chkSaveArgs.Size = new System.Drawing.Size(269, 17);
            this.chkSaveArgs.TabIndex = 33;
            this.chkSaveArgs.Text = "Remember custom arguments and save to ./args.txt";
            this.ttHelp.SetToolTip(this.chkSaveArgs, "Save the arguments the user creates when downloading with a custom preset.\r\n\r\n./a" +
        "rgs.txt = the args.txt file within youtube-dl-gui\'s directory.");
            this.chkSaveArgs.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(146, 248);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(227, 248);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ttHelp
            // 
            this.ttHelp.AutoPopDelay = 30000;
            this.ttHelp.InitialDelay = 150;
            this.ttHelp.ReshowDelay = 100;
            // 
            // chkSaveToMaster
            // 
            this.chkSaveToMaster.AutoSize = true;
            this.chkSaveToMaster.Checked = true;
            this.chkSaveToMaster.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveToMaster.Location = new System.Drawing.Point(29, 50);
            this.chkSaveToMaster.Name = "chkSaveToMaster";
            this.chkSaveToMaster.Size = new System.Drawing.Size(247, 17);
            this.chkSaveToMaster.TabIndex = 36;
            this.chkSaveToMaster.Text = "Save converted file to same location as original";
            this.ttHelp.SetToolTip(this.chkSaveToMaster, "Saves the output of the file you wanted to convert to the same file location as t" +
        "he file you inputted.");
            this.chkSaveToMaster.UseVisualStyleBackColor = true;
            // 
            // chkSeperateDownloads
            // 
            this.chkSeperateDownloads.AutoSize = true;
            this.chkSeperateDownloads.Location = new System.Drawing.Point(25, 97);
            this.chkSeperateDownloads.Name = "chkSeperateDownloads";
            this.chkSeperateDownloads.Size = new System.Drawing.Size(209, 17);
            this.chkSeperateDownloads.TabIndex = 33;
            this.chkSeperateDownloads.Text = "Seperate downloads to different folders";
            this.ttHelp.SetToolTip(this.chkSeperateDownloads, "Downloads will be downloaded to the download path.\r\n\r\nVideo downloads will be sto" +
        "red in the \"Video\" folder\r\nAudio downloads will be stored in the \"Audio\" folder." +
        "");
            this.chkSeperateDownloads.UseVisualStyleBackColor = true;
            // 
            // btnYtDl
            // 
            this.btnYtDl.Location = new System.Drawing.Point(270, 30);
            this.btnYtDl.Name = "btnYtDl";
            this.btnYtDl.Size = new System.Drawing.Size(25, 20);
            this.btnYtDl.TabIndex = 40;
            this.btnYtDl.Text = "...";
            this.ttHelp.SetToolTip(this.btnYtDl, "Browse for a new download path");
            this.btnYtDl.UseVisualStyleBackColor = true;
            this.btnYtDl.Click += new System.EventHandler(this.btnYtDl_Click);
            // 
            // txtYtDl
            // 
            this.txtYtDl.Location = new System.Drawing.Point(23, 30);
            this.txtYtDl.Name = "txtYtDl";
            this.txtYtDl.ReadOnly = true;
            this.txtYtDl.Size = new System.Drawing.Size(241, 20);
            this.txtYtDl.TabIndex = 39;
            this.ttHelp.SetToolTip(this.txtYtDl, "The location where videos will get downloaded");
            // 
            // chkUpdateCheck
            // 
            this.chkUpdateCheck.AutoSize = true;
            this.chkUpdateCheck.Checked = true;
            this.chkUpdateCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdateCheck.Location = new System.Drawing.Point(18, 95);
            this.chkUpdateCheck.Name = "chkUpdateCheck";
            this.chkUpdateCheck.Size = new System.Drawing.Size(162, 17);
            this.chkUpdateCheck.TabIndex = 37;
            this.chkUpdateCheck.Text = "Check for updates on launch";
            this.chkUpdateCheck.UseVisualStyleBackColor = true;
            // 
            // chkSaveDLParams
            // 
            this.chkSaveDLParams.AutoSize = true;
            this.chkSaveDLParams.Checked = true;
            this.chkSaveDLParams.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveDLParams.Location = new System.Drawing.Point(25, 74);
            this.chkSaveDLParams.Name = "chkSaveDLParams";
            this.chkSaveDLParams.Size = new System.Drawing.Size(173, 17);
            this.chkSaveDLParams.TabIndex = 38;
            this.chkSaveDLParams.Text = "Save download format && quality";
            this.chkSaveDLParams.UseVisualStyleBackColor = true;
            // 
            // chkSaveConvParams
            // 
            this.chkSaveConvParams.AutoSize = true;
            this.chkSaveConvParams.Checked = true;
            this.chkSaveConvParams.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSaveConvParams.Location = new System.Drawing.Point(29, 27);
            this.chkSaveConvParams.Name = "chkSaveConvParams";
            this.chkSaveConvParams.Size = new System.Drawing.Size(179, 17);
            this.chkSaveConvParams.TabIndex = 39;
            this.chkSaveConvParams.Text = "Save conversion format && quality";
            this.chkSaveConvParams.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabGeneral);
            this.tabControl1.Controls.Add(this.tabDownloads);
            this.tabControl1.Controls.Add(this.tabConverter);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(314, 243);
            this.tabControl1.TabIndex = 40;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.chkStaticYTDL);
            this.tabGeneral.Controls.Add(this.label2);
            this.tabGeneral.Controls.Add(this.btnYtDl);
            this.tabGeneral.Controls.Add(this.label3);
            this.tabGeneral.Controls.Add(this.txtYtDl);
            this.tabGeneral.Controls.Add(this.chkHoverURL);
            this.tabGeneral.Controls.Add(this.chkAutoClearURL);
            this.tabGeneral.Controls.Add(this.chkUpdateCheck);
            this.tabGeneral.Controls.Add(this.chkSaveArgs);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(306, 217);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // chkStaticYTDL
            // 
            this.chkStaticYTDL.AutoSize = true;
            this.chkStaticYTDL.Enabled = false;
            this.chkStaticYTDL.Location = new System.Drawing.Point(23, 58);
            this.chkStaticYTDL.Name = "chkStaticYTDL";
            this.chkStaticYTDL.Size = new System.Drawing.Size(153, 17);
            this.chkStaticYTDL.TabIndex = 42;
            this.chkStaticYTDL.Text = "Use a static youtube-dl.exe";
            this.chkStaticYTDL.UseVisualStyleBackColor = true;
            this.chkStaticYTDL.CheckedChanged += new System.EventHandler(this.chkStaticYTDL_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(25, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 2);
            this.label2.TabIndex = 41;
            this.label2.Text = "Stop looking for easter eggs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "youtube-dl path";
            // 
            // tabDownloads
            // 
            this.tabDownloads.Controls.Add(this.lbDlSeperator);
            this.tabDownloads.Controls.Add(this.chkSeperateDownloads);
            this.tabDownloads.Controls.Add(this.btnBrws);
            this.tabDownloads.Controls.Add(this.chkSaveDLParams);
            this.tabDownloads.Controls.Add(this.Label1);
            this.tabDownloads.Controls.Add(this.txtDownloadLocation);
            this.tabDownloads.Controls.Add(this.btnRedownload);
            this.tabDownloads.Controls.Add(this.numUpdateDays);
            this.tabDownloads.Controls.Add(this.chkDeleteExecutable);
            this.tabDownloads.Controls.Add(this.chkUpdate);
            this.tabDownloads.Location = new System.Drawing.Point(4, 22);
            this.tabDownloads.Name = "tabDownloads";
            this.tabDownloads.Size = new System.Drawing.Size(306, 217);
            this.tabDownloads.TabIndex = 2;
            this.tabDownloads.Text = "Downloads";
            this.tabDownloads.UseVisualStyleBackColor = true;
            // 
            // lbDlSeperator
            // 
            this.lbDlSeperator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbDlSeperator.Location = new System.Drawing.Point(25, 61);
            this.lbDlSeperator.Name = "lbDlSeperator";
            this.lbDlSeperator.Size = new System.Drawing.Size(256, 2);
            this.lbDlSeperator.TabIndex = 34;
            this.lbDlSeperator.Text = "Stop looking for easter eggs";
            // 
            // tabConverter
            // 
            this.tabConverter.Controls.Add(this.chkSaveConvParams);
            this.tabConverter.Controls.Add(this.chkSaveToMaster);
            this.tabConverter.Location = new System.Drawing.Point(4, 22);
            this.tabConverter.Name = "tabConverter";
            this.tabConverter.Padding = new System.Windows.Forms.Padding(3);
            this.tabConverter.Size = new System.Drawing.Size(306, 217);
            this.tabConverter.TabIndex = 3;
            this.tabConverter.Text = "Converter";
            this.tabConverter.UseVisualStyleBackColor = true;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(322, 275);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(330, 290);
            this.Name = "frmSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Shown += new System.EventHandler(this.frmSettings_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numUpdateDays)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.tabDownloads.ResumeLayout(false);
            this.tabDownloads.PerformLayout();
            this.tabConverter.ResumeLayout(false);
            this.tabConverter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRedownload;
        internal System.Windows.Forms.Button btnBrws;
        internal System.Windows.Forms.TextBox txtDownloadLocation;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.NumericUpDown numUpdateDays;
        internal System.Windows.Forms.CheckBox chkUpdate;
        internal System.Windows.Forms.CheckBox chkDeleteExecutable;
        internal System.Windows.Forms.CheckBox chkAutoClearURL;
        internal System.Windows.Forms.CheckBox chkHoverURL;
        private System.Windows.Forms.CheckBox chkSaveArgs;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ToolTip ttHelp;
        internal System.Windows.Forms.CheckBox chkSaveToMaster;
        private System.Windows.Forms.CheckBox chkUpdateCheck;
        private System.Windows.Forms.CheckBox chkSaveDLParams;
        private System.Windows.Forms.CheckBox chkSaveConvParams;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.TabPage tabDownloads;
        private System.Windows.Forms.CheckBox chkSeperateDownloads;
        private System.Windows.Forms.Label lbDlSeperator;
        private System.Windows.Forms.TabPage tabConverter;
        private System.Windows.Forms.CheckBox chkStaticYTDL;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Button btnYtDl;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtYtDl;
    }
}