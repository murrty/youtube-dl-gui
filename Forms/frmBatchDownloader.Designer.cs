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
            this.btnBatchDownloadStart = new System.Windows.Forms.Button();
            this.mBatchDownloaderArgs = new System.Windows.Forms.ContextMenu();
            this.mBatchDownloaderLoadArgsFromSettings = new System.Windows.Forms.MenuItem();
            this.mBatchDownloaderLoadArgsFromArgsTxt = new System.Windows.Forms.MenuItem();
            this.mBatchDownloaderLoadArgsFromFile = new System.Windows.Forms.MenuItem();
            this.sbBatchDownloader = new System.Windows.Forms.StatusBar();
            this.sbLoadArgs = new youtube_dl_gui.SplitButton();
            this.txtBatchDownloadVideoSpecificArgument = new youtube_dl_gui.HintTextBox();
            this.txtBatchDownloadLink = new youtube_dl_gui.HintTextBox();
            this.vistaListView1 = new youtube_dl_gui.VistaListView();
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
            this.cbBatchDownloadType.TabIndex = 1;
            // 
            // lbBatchDownloadLink
            // 
            this.lbBatchDownloadLink.AutoSize = true;
            this.lbBatchDownloadLink.Location = new System.Drawing.Point(9, 9);
            this.lbBatchDownloadLink.Name = "lbBatchDownloadLink";
            this.lbBatchDownloadLink.Size = new System.Drawing.Size(111, 13);
            this.lbBatchDownloadLink.TabIndex = 2;
            this.lbBatchDownloadLink.Text = "lbBatchDownloadLink";
            // 
            // lbBatchDownloadType
            // 
            this.lbBatchDownloadType.AutoSize = true;
            this.lbBatchDownloadType.Location = new System.Drawing.Point(275, 9);
            this.lbBatchDownloadType.Name = "lbBatchDownloadType";
            this.lbBatchDownloadType.Size = new System.Drawing.Size(115, 13);
            this.lbBatchDownloadType.TabIndex = 3;
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
            this.lbBatchVideoSpecificArgument.TabIndex = 5;
            this.lbBatchVideoSpecificArgument.Text = "lbBatchVideoSpecificArgument";
            // 
            // btnBatchDownloadAdd
            // 
            this.btnBatchDownloadAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDownloadAdd.Location = new System.Drawing.Point(575, 24);
            this.btnBatchDownloadAdd.Name = "btnBatchDownloadAdd";
            this.btnBatchDownloadAdd.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDownloadAdd.TabIndex = 9;
            this.btnBatchDownloadAdd.Text = "btnBatchDownloadAdd";
            this.btnBatchDownloadAdd.UseVisualStyleBackColor = true;
            this.btnBatchDownloadAdd.Click += new System.EventHandler(this.btnBatchDownloadAdd_Click);
            // 
            // btnBatchDownloadRemoveSelected
            // 
            this.btnBatchDownloadRemoveSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDownloadRemoveSelected.Location = new System.Drawing.Point(575, 80);
            this.btnBatchDownloadRemoveSelected.Name = "btnBatchDownloadRemoveSelected";
            this.btnBatchDownloadRemoveSelected.Size = new System.Drawing.Size(75, 37);
            this.btnBatchDownloadRemoveSelected.TabIndex = 10;
            this.btnBatchDownloadRemoveSelected.Text = "btnBatchDownloadRemoveSelected";
            this.btnBatchDownloadRemoveSelected.UseVisualStyleBackColor = true;
            this.btnBatchDownloadRemoveSelected.Click += new System.EventHandler(this.btnBatchDownloadRemoveSelected_Click);
            // 
            // btnBatchDownloadStart
            // 
            this.btnBatchDownloadStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDownloadStart.Location = new System.Drawing.Point(575, 259);
            this.btnBatchDownloadStart.Name = "btnBatchDownloadStart";
            this.btnBatchDownloadStart.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDownloadStart.TabIndex = 11;
            this.btnBatchDownloadStart.Text = "btnBatchDownloadStart";
            this.btnBatchDownloadStart.UseVisualStyleBackColor = true;
            this.btnBatchDownloadStart.Click += new System.EventHandler(this.btnBatchDownloadStart_Click);
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
            // 
            // mBatchDownloaderLoadArgsFromArgsTxt
            // 
            this.mBatchDownloaderLoadArgsFromArgsTxt.Index = 1;
            this.mBatchDownloaderLoadArgsFromArgsTxt.Text = "mBatchDownloaderLoadArgsFromArgsTxt";
            // 
            // mBatchDownloaderLoadArgsFromFile
            // 
            this.mBatchDownloaderLoadArgsFromFile.Index = 2;
            this.mBatchDownloaderLoadArgsFromFile.Text = "mBatchDownloaderLoadArgsFromFile";
            // 
            // sbBatchDownloader
            // 
            this.sbBatchDownloader.Location = new System.Drawing.Point(0, 288);
            this.sbBatchDownloader.Name = "sbBatchDownloader";
            this.sbBatchDownloader.Size = new System.Drawing.Size(662, 22);
            this.sbBatchDownloader.SizingGrip = false;
            this.sbBatchDownloader.TabIndex = 16;
            this.sbBatchDownloader.Text = "Waiting for start";
            // 
            // sbLoadArgs
            // 
            this.sbLoadArgs.DropDownContextMenu = this.mBatchDownloaderArgs;
            this.sbLoadArgs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sbLoadArgs.Location = new System.Drawing.Point(575, 53);
            this.sbLoadArgs.Name = "sbLoadArgs";
            this.sbLoadArgs.Size = new System.Drawing.Size(75, 23);
            this.sbLoadArgs.TabIndex = 15;
            this.sbLoadArgs.Text = "sbLoadArgs";
            this.sbLoadArgs.UseVisualStyleBackColor = true;
            // 
            // txtBatchDownloadVideoSpecificArgument
            // 
            this.txtBatchDownloadVideoSpecificArgument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchDownloadVideoSpecificArgument.Location = new System.Drawing.Point(409, 26);
            this.txtBatchDownloadVideoSpecificArgument.Name = "txtBatchDownloadVideoSpecificArgument";
            this.txtBatchDownloadVideoSpecificArgument.Size = new System.Drawing.Size(160, 20);
            this.txtBatchDownloadVideoSpecificArgument.TabIndex = 14;
            this.txtBatchDownloadVideoSpecificArgument.TextHint = "--argument";
            // 
            // txtBatchDownloadLink
            // 
            this.txtBatchDownloadLink.Location = new System.Drawing.Point(12, 26);
            this.txtBatchDownloadLink.Name = "txtBatchDownloadLink";
            this.txtBatchDownloadLink.Size = new System.Drawing.Size(256, 20);
            this.txtBatchDownloadLink.TabIndex = 13;
            this.txtBatchDownloadLink.TextHint = "https://....";
            // 
            // vistaListView1
            // 
            this.vistaListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vistaListView1.CheckBoxes = true;
            this.vistaListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clUrl,
            this.clType,
            this.clArgs});
            this.vistaListView1.EnableVistaView = true;
            this.vistaListView1.FullRowSelect = true;
            this.vistaListView1.Location = new System.Drawing.Point(12, 51);
            this.vistaListView1.Name = "vistaListView1";
            this.vistaListView1.Size = new System.Drawing.Size(557, 231);
            this.vistaListView1.TabIndex = 12;
            this.vistaListView1.UseCompatibleStateImageBehavior = false;
            this.vistaListView1.View = System.Windows.Forms.View.Details;
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
            this.Controls.Add(this.sbBatchDownloader);
            this.Controls.Add(this.sbLoadArgs);
            this.Controls.Add(this.txtBatchDownloadVideoSpecificArgument);
            this.Controls.Add(this.txtBatchDownloadLink);
            this.Controls.Add(this.vistaListView1);
            this.Controls.Add(this.btnBatchDownloadStart);
            this.Controls.Add(this.btnBatchDownloadRemoveSelected);
            this.Controls.Add(this.btnBatchDownloadAdd);
            this.Controls.Add(this.lbBatchVideoSpecificArgument);
            this.Controls.Add(this.lbBatchDownloadType);
            this.Controls.Add(this.lbBatchDownloadLink);
            this.Controls.Add(this.cbBatchDownloadType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(670, 340);
            this.Name = "frmBatchDownloader";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBatchDownloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBatchDownloader_FormClosing);
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
        private System.Windows.Forms.Button btnBatchDownloadStart;
        private VistaListView vistaListView1;
        private System.Windows.Forms.ColumnHeader clUrl;
        private System.Windows.Forms.ColumnHeader clType;
        private System.Windows.Forms.ColumnHeader clArgs;
        private HintTextBox txtBatchDownloadLink;
        private HintTextBox txtBatchDownloadVideoSpecificArgument;
        private SplitButton sbLoadArgs;
        private System.Windows.Forms.ContextMenu mBatchDownloaderArgs;
        private System.Windows.Forms.MenuItem mBatchDownloaderLoadArgsFromSettings;
        private System.Windows.Forms.MenuItem mBatchDownloaderLoadArgsFromArgsTxt;
        private System.Windows.Forms.MenuItem mBatchDownloaderLoadArgsFromFile;
        private System.Windows.Forms.StatusBar sbBatchDownloader;
    }
}