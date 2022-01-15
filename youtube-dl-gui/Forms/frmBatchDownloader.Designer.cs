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
            this.sbBatchDownloadLoadArgs = new youtube_dl_gui.Controls.SplitButton();
            this.txtBatchDownloadLink = new youtube_dl_gui.Controls.ExtendedTextBox();
            this.lvBatchDownloadQueue = new youtube_dl_gui.Controls.VistaListView();
            this.clUrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clArgs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbArguments = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbBatchDownloadType
            // 
            this.cbBatchDownloadType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatchDownloadType.FormattingEnabled = true;
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
            this.lbBatchVideoSpecificArgument.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.btnBatchDownloadAdd.Location = new System.Drawing.Point(565, 24);
            this.btnBatchDownloadAdd.Name = "btnBatchDownloadAdd";
            this.btnBatchDownloadAdd.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDownloadAdd.TabIndex = 8;
            this.btnBatchDownloadAdd.Text = "btnBatchDownloadAdd";
            this.btnBatchDownloadAdd.UseVisualStyleBackColor = true;
            this.btnBatchDownloadAdd.Click += new System.EventHandler(this.btnBatchDownloadAdd_Click);
            // 
            // btnBatchDownloadRemoveSelected
            // 
            this.btnBatchDownloadRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDownloadRemoveSelected.Enabled = false;
            this.btnBatchDownloadRemoveSelected.Location = new System.Drawing.Point(565, 53);
            this.btnBatchDownloadRemoveSelected.Name = "btnBatchDownloadRemoveSelected";
            this.btnBatchDownloadRemoveSelected.Size = new System.Drawing.Size(75, 37);
            this.btnBatchDownloadRemoveSelected.TabIndex = 10;
            this.btnBatchDownloadRemoveSelected.Text = "btnBatchDownloadRemoveSelected";
            this.btnBatchDownloadRemoveSelected.UseVisualStyleBackColor = true;
            this.btnBatchDownloadRemoveSelected.Click += new System.EventHandler(this.btnBatchDownloadRemoveSelected_Click);
            // 
            // btnBatchDownloadStartStopExit
            // 
            this.btnBatchDownloadStartStopExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDownloadStartStopExit.Enabled = false;
            this.btnBatchDownloadStartStopExit.Location = new System.Drawing.Point(565, 252);
            this.btnBatchDownloadStartStopExit.Name = "btnBatchDownloadStartStopExit";
            this.btnBatchDownloadStartStopExit.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDownloadStartStopExit.TabIndex = 13;
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
            this.sbBatchDownloader.Location = new System.Drawing.Point(0, 281);
            this.sbBatchDownloader.Name = "sbBatchDownloader";
            this.sbBatchDownloader.Size = new System.Drawing.Size(652, 22);
            this.sbBatchDownloader.SizingGrip = false;
            this.sbBatchDownloader.TabIndex = 14;
            this.sbBatchDownloader.Text = "sbBatchDownloader";
            // 
            // ilBatchDownloadProgress
            // 
            this.ilBatchDownloadProgress.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilBatchDownloadProgress.ImageSize = new System.Drawing.Size(16, 16);
            this.ilBatchDownloadProgress.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // chkBatchDownloaderSoundVBR
            // 
            this.chkBatchDownloaderSoundVBR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBatchDownloaderSoundVBR.AutoSize = true;
            this.chkBatchDownloaderSoundVBR.Location = new System.Drawing.Point(575, 100);
            this.chkBatchDownloaderSoundVBR.Name = "chkBatchDownloaderSoundVBR";
            this.chkBatchDownloaderSoundVBR.Size = new System.Drawing.Size(181, 17);
            this.chkBatchDownloaderSoundVBR.TabIndex = 11;
            this.chkBatchDownloaderSoundVBR.Text = "chkBatchDownloaderSoundVBR";
            this.chkBatchDownloaderSoundVBR.UseVisualStyleBackColor = true;
            this.chkBatchDownloaderSoundVBR.Visible = false;
            this.chkBatchDownloaderSoundVBR.CheckedChanged += new System.EventHandler(this.chkBatchDownloaderSoundVBR_CheckedChanged);
            // 
            // cbBatchQuality
            // 
            this.cbBatchQuality.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBatchQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatchQuality.FormattingEnabled = true;
            this.cbBatchQuality.Location = new System.Drawing.Point(404, 25);
            this.cbBatchQuality.Name = "cbBatchQuality";
            this.cbBatchQuality.Size = new System.Drawing.Size(77, 21);
            this.cbBatchQuality.TabIndex = 5;
            this.cbBatchQuality.Visible = false;
            // 
            // cbBatchFormat
            // 
            this.cbBatchFormat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbBatchFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBatchFormat.FormattingEnabled = true;
            this.cbBatchFormat.Location = new System.Drawing.Point(487, 25);
            this.cbBatchFormat.Name = "cbBatchFormat";
            this.cbBatchFormat.Size = new System.Drawing.Size(77, 21);
            this.cbBatchFormat.TabIndex = 6;
            this.cbBatchFormat.Visible = false;
            // 
            // sbBatchDownloadLoadArgs
            // 
            this.sbBatchDownloadLoadArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sbBatchDownloadLoadArgs.DropDownContextMenu = this.mBatchDownloaderArgs;
            this.sbBatchDownloadLoadArgs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sbBatchDownloadLoadArgs.Location = new System.Drawing.Point(575, 96);
            this.sbBatchDownloadLoadArgs.Name = "sbBatchDownloadLoadArgs";
            this.sbBatchDownloadLoadArgs.Size = new System.Drawing.Size(75, 23);
            this.sbBatchDownloadLoadArgs.TabIndex = 12;
            this.sbBatchDownloadLoadArgs.Text = "sbBatchDownloadLoadArgs";
            this.sbBatchDownloadLoadArgs.UseVisualStyleBackColor = true;
            this.sbBatchDownloadLoadArgs.Visible = false;
            this.sbBatchDownloadLoadArgs.Click += new System.EventHandler(this.sbBatchDownloadLoadArgs_Click);
            // 
            // txtBatchDownloadLink
            // 
            this.txtBatchDownloadLink.AllowDrop = true;
            this.txtBatchDownloadLink.ButtonAlignment = youtube_dl_gui.Controls.ButtonAlignments.Left;
            this.txtBatchDownloadLink.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtBatchDownloadLink.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBatchDownloadLink.ButtonImageIndex = -1;
            this.txtBatchDownloadLink.ButtonImageKey = "";
            this.txtBatchDownloadLink.ButtonSize = new System.Drawing.Size(22, 19);
            this.txtBatchDownloadLink.ButtonText = "";
            this.txtBatchDownloadLink.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtBatchDownloadLink.Location = new System.Drawing.Point(12, 26);
            this.txtBatchDownloadLink.Name = "txtBatchDownloadLink";
            this.txtBatchDownloadLink.Size = new System.Drawing.Size(256, 20);
            this.txtBatchDownloadLink.TabIndex = 3;
            this.txtBatchDownloadLink.TextHint = "https://...";
            this.txtBatchDownloadLink.TextChanged += new System.EventHandler(this.txtBatchDownloadLink_TextChanged);
            this.txtBatchDownloadLink.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBatchDownloadLink_KeyPress);
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
            this.lvBatchDownloadQueue.HideSelection = false;
            this.lvBatchDownloadQueue.Location = new System.Drawing.Point(12, 51);
            this.lvBatchDownloadQueue.Name = "lvBatchDownloadQueue";
            this.lvBatchDownloadQueue.Size = new System.Drawing.Size(547, 224);
            this.lvBatchDownloadQueue.SmallImageList = this.ilBatchDownloadProgress;
            this.lvBatchDownloadQueue.TabIndex = 9;
            this.lvBatchDownloadQueue.UseCompatibleStateImageBehavior = false;
            this.lvBatchDownloadQueue.View = System.Windows.Forms.View.Details;
            this.lvBatchDownloadQueue.SelectedIndexChanged += new System.EventHandler(this.lvBatchDownloadQueue_SelectedIndexChanged);
            this.lvBatchDownloadQueue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvBatchDownloadQueue_KeyDown);
            this.lvBatchDownloadQueue.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvBatchDownloadQueue_KeyUp);
            // 
            // clUrl
            // 
            this.clUrl.Text = "URL";
            this.clUrl.Width = 255;
            // 
            // clType
            // 
            this.clType.Text = "Type";
            this.clType.Width = 88;
            // 
            // clArgs
            // 
            this.clArgs.Text = "Args";
            this.clArgs.Width = 210;
            // 
            // cbArguments
            // 
            this.cbArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbArguments.FormattingEnabled = true;
            this.cbArguments.Location = new System.Drawing.Point(409, 26);
            this.cbArguments.Name = "cbArguments";
            this.cbArguments.Size = new System.Drawing.Size(150, 21);
            this.cbArguments.TabIndex = 15;
            // 
            // frmBatchDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 303);
            this.Controls.Add(this.chkBatchDownloaderSoundVBR);
            this.Controls.Add(this.sbBatchDownloader);
            this.Controls.Add(this.sbBatchDownloadLoadArgs);
            this.Controls.Add(this.txtBatchDownloadLink);
            this.Controls.Add(this.lvBatchDownloadQueue);
            this.Controls.Add(this.btnBatchDownloadStartStopExit);
            this.Controls.Add(this.btnBatchDownloadRemoveSelected);
            this.Controls.Add(this.btnBatchDownloadAdd);
            this.Controls.Add(this.lbBatchVideoSpecificArgument);
            this.Controls.Add(this.lbBatchDownloadType);
            this.Controls.Add(this.lbBatchDownloadLink);
            this.Controls.Add(this.cbBatchDownloadType);
            this.Controls.Add(this.cbBatchQuality);
            this.Controls.Add(this.cbBatchFormat);
            this.Controls.Add(this.cbArguments);
            this.Icon = global::youtube_dl_gui.Properties.Resources.youtube_dl_gui;
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
        private youtube_dl_gui.Controls.VistaListView lvBatchDownloadQueue;
        private System.Windows.Forms.ColumnHeader clUrl;
        private System.Windows.Forms.ColumnHeader clArgs;
        private youtube_dl_gui.Controls.ExtendedTextBox txtBatchDownloadLink;
        private youtube_dl_gui.Controls.SplitButton sbBatchDownloadLoadArgs;
        private System.Windows.Forms.ContextMenu mBatchDownloaderArgs;
        private System.Windows.Forms.MenuItem mBatchDownloaderLoadArgsFromSettings;
        private System.Windows.Forms.MenuItem mBatchDownloaderLoadArgsFromArgsTxt;
        private System.Windows.Forms.MenuItem mBatchDownloaderLoadArgsFromFile;
        private System.Windows.Forms.StatusBar sbBatchDownloader;
        private System.Windows.Forms.ImageList ilBatchDownloadProgress;
        private System.Windows.Forms.CheckBox chkBatchDownloaderSoundVBR;
        private System.Windows.Forms.ComboBox cbBatchQuality;
        private System.Windows.Forms.ComboBox cbBatchFormat;
        private System.Windows.Forms.ColumnHeader clType;
        private System.Windows.Forms.ComboBox cbArguments;
    }
}