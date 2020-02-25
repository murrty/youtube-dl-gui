namespace youtube_dl_gui {
    partial class frmBatchDownloader {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBatchDownloader));
            this.cbBatchDownloadType = new System.Windows.Forms.ComboBox();
            this.lbBatchDownloadLink = new System.Windows.Forms.Label();
            this.lbBatchDownloadType = new System.Windows.Forms.Label();
            this.lbBatchVideoSpecificArgument = new System.Windows.Forms.Label();
            this.btnBatchDownloadAdd = new System.Windows.Forms.Button();
            this.btnBatchDownloadRemoveSelected = new System.Windows.Forms.Button();
            this.btnBatchDownloadStartStopExit = new System.Windows.Forms.Button();
            this.mBatchDownloaderArgs = new System.Windows.Forms.ContextMenu();
            this.mBatchDownloaderLoadArgsFromSettings = new System.Windows.Forms.MenuItem();
            this.mBatchDownloaderLoadArgsFromArgsTxt = new System.Windows.Forms.MenuItem();
            this.mBatchDownloaderLoadArgsFromFile = new System.Windows.Forms.MenuItem();
            this.sbBatchDownloader = new System.Windows.Forms.StatusBar();
            this.ilBatchDownloadProgress = new System.Windows.Forms.ImageList(this.components);
            this.chkBatchDownloaderSoundVBR = new System.Windows.Forms.CheckBox();
            this.cbBatchQuality = new System.Windows.Forms.ComboBox();
            this.cbBatchFormat = new System.Windows.Forms.ComboBox();
            this.sbBatchDownloadLoadArgs = new youtube_dl_gui.SplitButton();
            this.txtBatchDownloadVideoSpecificArgument = new youtube_dl_gui.HintTextBox();
            this.txtBatchDownloadLink = new youtube_dl_gui.HintTextBox();
            this.lvBatchDownloadQueue = new youtube_dl_gui.VistaListView();
            this.clUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clArgs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // cbBatchDownloadType
            // 
            this.cbBatchDownloadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatchDownloadType.FormattingEnabled = true;
            this.cbBatchDownloadType.Items.AddRange(new object[] {
            "Video",
            "Audio",
            "Custom"});
            this.cbBatchDownloadType.Location = new System.Drawing.Point(278, 25);
            this.cbBatchDownloadType.Name = "cbBatchDownloadType";
            this.cbBatchDownloadType.Size = new System.Drawing.Size(121, 21);
            this.cbBatchDownloadType.TabIndex = 4;
            this.cbBatchDownloadType.SelectedIndexChanged += new System.EventHandler(this.cbBatchDownloadType_SelectedIndexChanged);
            // 
            // lbBatchDownloadLink
            // 
            this.lbBatchDownloadLink.AutoSize = true;
            this.lbBatchDownloadLink.Location = new System.Drawing.Point(9, 9);
            this.lbBatchDownloadLink.Name = "lbBatchDownloadLink";
            this.lbBatchDownloadLink.Size = new System.Drawing.Size(111, 13);
            this.lbBatchDownloadLink.TabIndex = 0;
            this.lbBatchDownloadLink.Text = "lbBatchDownloadLink";
            // 
            // lbBatchDownloadType
            // 
            this.lbBatchDownloadType.AutoSize = true;
            this.lbBatchDownloadType.Location = new System.Drawing.Point(275, 9);
            this.lbBatchDownloadType.Name = "lbBatchDownloadType";
            this.lbBatchDownloadType.Size = new System.Drawing.Size(115, 13);
            this.lbBatchDownloadType.TabIndex = 1;
            this.lbBatchDownloadType.Text = "lbBatchDownloadType";
            // 
            // lbBatchVideoSpecificArgument
            // 
            this.lbBatchVideoSpecificArgument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbBatchVideoSpecificArgument.AutoSize = true;
            this.lbBatchVideoSpecificArgument.Location = new System.Drawing.Point(406, 9);
            this.lbBatchVideoSpecificArgument.Name = "lbBatchVideoSpecificArgument";
            this.lbBatchVideoSpecificArgument.Size = new System.Drawing.Size(153, 13);
            this.lbBatchVideoSpecificArgument.TabIndex = 2;
            this.lbBatchVideoSpecificArgument.Text = "lbBatchVideoSpecificArgument";
            // 
            // btnBatchDownloadAdd
            // 
            this.btnBatchDownloadAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDownloadAdd.Enabled = false;
            this.btnBatchDownloadAdd.Location = new System.Drawing.Point(575, 24);
            this.btnBatchDownloadAdd.Name = "btnBatchDownloadAdd";
            this.btnBatchDownloadAdd.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDownloadAdd.TabIndex = 6;
            this.btnBatchDownloadAdd.Text = "btnBatchDownloadAdd";
            this.btnBatchDownloadAdd.UseVisualStyleBackColor = true;
            this.btnBatchDownloadAdd.Click += new System.EventHandler(this.btnBatchDownloadAdd_Click);
            // 
            // btnBatchDownloadRemoveSelected
            // 
            this.btnBatchDownloadRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDownloadRemoveSelected.Enabled = false;
            this.btnBatchDownloadRemoveSelected.Location = new System.Drawing.Point(575, 53);
            this.btnBatchDownloadRemoveSelected.Name = "btnBatchDownloadRemoveSelected";
            this.btnBatchDownloadRemoveSelected.Size = new System.Drawing.Size(75, 37);
            this.btnBatchDownloadRemoveSelected.TabIndex = 9;
            this.btnBatchDownloadRemoveSelected.Text = "btnBatchDownloadRemoveSelected";
            this.btnBatchDownloadRemoveSelected.UseVisualStyleBackColor = true;
            this.btnBatchDownloadRemoveSelected.Click += new System.EventHandler(this.btnBatchDownloadRemoveSelected_Click);
            // 
            // btnBatchDownloadStartStopExit
            // 
            this.btnBatchDownloadStartStopExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDownloadStartStopExit.Enabled = false;
            this.btnBatchDownloadStartStopExit.Location = new System.Drawing.Point(575, 259);
            this.btnBatchDownloadStartStopExit.Name = "btnBatchDownloadStartStopExit";
            this.btnBatchDownloadStartStopExit.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDownloadStartStopExit.TabIndex = 10;
            this.btnBatchDownloadStartStopExit.Text = "btnBatchDownloadStart";
            this.btnBatchDownloadStartStopExit.UseVisualStyleBackColor = true;
            this.btnBatchDownloadStartStopExit.Click += new System.EventHandler(this.btnBatchDownloadStartStopExit_Click);
            // 
            // mBatchDownloaderArgs
            // 
            this.mBatchDownloaderArgs.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mBatchDownloaderLoadArgsFromSettings,
            this.mBatchDownloaderLoadArgsFromArgsTxt,
            this.mBatchDownloaderLoadArgsFromFile});
            // 
            // mBatchDownloaderLoadArgsFromSettings
            // 
            this.mBatchDownloaderLoadArgsFromSettings.Index = 0;
            this.mBatchDownloaderLoadArgsFromSettings.Text = "mBatchDownloaderLoadArgsFromSettings";
            this.mBatchDownloaderLoadArgsFromSettings.Click += new System.EventHandler(this.mBatchDownloaderLoadArgsFromSettings_Click);
            // 
            // mBatchDownloaderLoadArgsFromArgsTxt
            // 
            this.mBatchDownloaderLoadArgsFromArgsTxt.Index = 1;
            this.mBatchDownloaderLoadArgsFromArgsTxt.Text = "mBatchDownloaderLoadArgsFromArgsTxt";
            this.mBatchDownloaderLoadArgsFromArgsTxt.Click += new System.EventHandler(this.mBatchDownloaderLoadArgsFromArgsTxt_Click);
            // 
            // mBatchDownloaderLoadArgsFromFile
            // 
            this.mBatchDownloaderLoadArgsFromFile.Index = 2;
            this.mBatchDownloaderLoadArgsFromFile.Text = "mBatchDownloaderLoadArgsFromFile";
            this.mBatchDownloaderLoadArgsFromFile.Click += new System.EventHandler(this.mBatchDownloaderLoadArgsFromFile_Click);
            // 
            // sbBatchDownloader
            // 
            this.sbBatchDownloader.Location = new System.Drawing.Point(0, 288);
            this.sbBatchDownloader.Name = "sbBatchDownloader";
            this.sbBatchDownloader.Size = new System.Drawing.Size(662, 22);
            this.sbBatchDownloader.SizingGrip = false;
            this.sbBatchDownloader.TabIndex = 11;
            this.sbBatchDownloader.Text = "Waiting for start";
            // 
            // ilBatchDownloadProgress
            // 
            this.ilBatchDownloadProgress.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilBatchDownloadProgress.ImageStream")));
            this.ilBatchDownloadProgress.TransparentColor = System.Drawing.Color.Fuchsia;
            this.ilBatchDownloadProgress.Images.SetKeyName(0, "waiting.bmp");
            this.ilBatchDownloadProgress.Images.SetKeyName(1, "downloading.bmp");
            this.ilBatchDownloadProgress.Images.SetKeyName(2, "finished.bmp");
            this.ilBatchDownloadProgress.Images.SetKeyName(3, "errored.bmp");
            // 
            // chkBatchDownloaderSoundVBR
            // 
            this.chkBatchDownloaderSoundVBR.AutoSize = true;
            this.chkBatchDownloaderSoundVBR.Location = new System.Drawing.Point(575, 100);
            this.chkBatchDownloaderSoundVBR.Name = "chkBatchDownloaderSoundVBR";
            this.chkBatchDownloaderSoundVBR.Size = new System.Drawing.Size(181, 17);
            this.chkBatchDownloaderSoundVBR.TabIndex = 12;
            this.chkBatchDownloaderSoundVBR.Text = "chkBatchDownloaderSoundVBR";
            this.chkBatchDownloaderSoundVBR.UseVisualStyleBackColor = true;
            this.chkBatchDownloaderSoundVBR.Visible = false;
            this.chkBatchDownloaderSoundVBR.CheckedChanged += new System.EventHandler(this.chkBatchDownloaderSoundVBR_CheckedChanged);
            // 
            // cbBatchQuality
            // 
            this.cbBatchQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatchQuality.FormattingEnabled = true;
            this.cbBatchQuality.Location = new System.Drawing.Point(409, 25);
            this.cbBatchQuality.Name = "cbBatchQuality";
            this.cbBatchQuality.Size = new System.Drawing.Size(77, 21);
            this.cbBatchQuality.TabIndex = 13;
            this.cbBatchQuality.Visible = false;
            // 
            // cbBatchFormat
            // 
            this.cbBatchFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatchFormat.FormattingEnabled = true;
            this.cbBatchFormat.Location = new System.Drawing.Point(492, 25);
            this.cbBatchFormat.Name = "cbBatchFormat";
            this.cbBatchFormat.Size = new System.Drawing.Size(77, 21);
            this.cbBatchFormat.TabIndex = 14;
            this.cbBatchFormat.Visible = false;
            // 
            // sbBatchDownloadLoadArgs
            // 
            this.sbBatchDownloadLoadArgs.DropDownContextMenu = this.mBatchDownloaderArgs;
            this.sbBatchDownloadLoadArgs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sbBatchDownloadLoadArgs.Location = new System.Drawing.Point(575, 96);
            this.sbBatchDownloadLoadArgs.Name = "sbBatchDownloadLoadArgs";
            this.sbBatchDownloadLoadArgs.Size = new System.Drawing.Size(75, 23);
            this.sbBatchDownloadLoadArgs.TabIndex = 8;
            this.sbBatchDownloadLoadArgs.Text = "sbBatchDownloadLoadArgs";
            this.sbBatchDownloadLoadArgs.UseVisualStyleBackColor = true;
            this.sbBatchDownloadLoadArgs.Visible = false;
            this.sbBatchDownloadLoadArgs.Click += new System.EventHandler(this.sbBatchDownloadLoadArgs_Click);
            // 
            // txtBatchDownloadVideoSpecificArgument
            // 
            this.txtBatchDownloadVideoSpecificArgument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchDownloadVideoSpecificArgument.Location = new System.Drawing.Point(409, 26);
            this.txtBatchDownloadVideoSpecificArgument.Name = "txtBatchDownloadVideoSpecificArgument";
            this.txtBatchDownloadVideoSpecificArgument.Size = new System.Drawing.Size(160, 20);
            this.txtBatchDownloadVideoSpecificArgument.TabIndex = 5;
            this.txtBatchDownloadVideoSpecificArgument.TextHint = "--argument";
            this.txtBatchDownloadVideoSpecificArgument.Visible = false;
            // 
            // txtBatchDownloadLink
            // 
            this.txtBatchDownloadLink.Location = new System.Drawing.Point(12, 26);
            this.txtBatchDownloadLink.Name = "txtBatchDownloadLink";
            this.txtBatchDownloadLink.Size = new System.Drawing.Size(256, 20);
            this.txtBatchDownloadLink.TabIndex = 3;
            this.txtBatchDownloadLink.TextHint = "https://...";
            this.txtBatchDownloadLink.TextChanged += new System.EventHandler(this.txtBatchDownloadLink_TextChanged);
            // 
            // lvBatchDownloadQueue
            // 
            this.lvBatchDownloadQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBatchDownloadQueue.BackColor = System.Drawing.SystemColors.Window;
            this.lvBatchDownloadQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clUrl,
            this.clType,
            this.clArgs});
            this.lvBatchDownloadQueue.EnableVistaView = true;
            this.lvBatchDownloadQueue.FullRowSelect = true;
            this.lvBatchDownloadQueue.Location = new System.Drawing.Point(12, 51);
            this.lvBatchDownloadQueue.Name = "lvBatchDownloadQueue";
            this.lvBatchDownloadQueue.Size = new System.Drawing.Size(557, 231);
            this.lvBatchDownloadQueue.SmallImageList = this.ilBatchDownloadProgress;
            this.lvBatchDownloadQueue.TabIndex = 7;
            this.lvBatchDownloadQueue.UseCompatibleStateImageBehavior = false;
            this.lvBatchDownloadQueue.View = System.Windows.Forms.View.Details;
            this.lvBatchDownloadQueue.SelectedIndexChanged += new System.EventHandler(this.lvBatchDownloadQueue_SelectedIndexChanged);
            // 
            // clUrl
            // 
            this.clUrl.Text = "clUrl";
            this.clUrl.Width = 255;
            // 
            // clType
            // 
            this.clType.Text = "clType";
            this.clType.Width = 88;
            // 
            // clArgs
            // 
            this.clArgs.Text = "clArgs";
            this.clArgs.Width = 210;
            // 
            // frmBatchDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 310);
            this.Controls.Add(this.cbBatchFormat);
            this.Controls.Add(this.cbBatchQuality);
            this.Controls.Add(this.chkBatchDownloaderSoundVBR);
            this.Controls.Add(this.sbBatchDownloader);
            this.Controls.Add(this.sbBatchDownloadLoadArgs);
            this.Controls.Add(this.txtBatchDownloadVideoSpecificArgument);
            this.Controls.Add(this.txtBatchDownloadLink);
            this.Controls.Add(this.lvBatchDownloadQueue);
            this.Controls.Add(this.btnBatchDownloadStartStopExit);
            this.Controls.Add(this.btnBatchDownloadRemoveSelected);
            this.Controls.Add(this.btnBatchDownloadAdd);
            this.Controls.Add(this.lbBatchVideoSpecificArgument);
            this.Controls.Add(this.lbBatchDownloadType);
            this.Controls.Add(this.lbBatchDownloadLink);
            this.Controls.Add(this.cbBatchDownloadType);
            this.MinimumSize = new System.Drawing.Size(670, 340);
            this.Name = "frmBatchDownloader";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBatchDownloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBatchDownloader_FormClosing);
            this.Load += new System.EventHandler(this.frmBatchDownloader_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBatchDownloadType;
        private System.Windows.Forms.Label lbBatchDownloadLink;
        private System.Windows.Forms.Label lbBatchDownloadType;
        private System.Windows.Forms.Label lbBatchVideoSpecificArgument;
        private System.Windows.Forms.Button btnBatchDownloadAdd;
        private System.Windows.Forms.Button btnBatchDownloadRemoveSelected;
        private System.Windows.Forms.Button btnBatchDownloadStartStopExit;
        private VistaListView lvBatchDownloadQueue;
        private System.Windows.Forms.ColumnHeader clUrl;
        private System.Windows.Forms.ColumnHeader clType;
        private System.Windows.Forms.ColumnHeader clArgs;
        private HintTextBox txtBatchDownloadLink;
        private HintTextBox txtBatchDownloadVideoSpecificArgument;
        private SplitButton sbBatchDownloadLoadArgs;
        private System.Windows.Forms.ContextMenu mBatchDownloaderArgs;
        private System.Windows.Forms.MenuItem mBatchDownloaderLoadArgsFromSettings;
        private System.Windows.Forms.MenuItem mBatchDownloaderLoadArgsFromArgsTxt;
        private System.Windows.Forms.MenuItem mBatchDownloaderLoadArgsFromFile;
        private System.Windows.Forms.StatusBar sbBatchDownloader;
        private System.Windows.Forms.ImageList ilBatchDownloadProgress;
        private System.Windows.Forms.CheckBox chkBatchDownloaderSoundVBR;
        private System.Windows.Forms.ComboBox cbBatchQuality;
        private System.Windows.Forms.ComboBox cbBatchFormat;
    }
}