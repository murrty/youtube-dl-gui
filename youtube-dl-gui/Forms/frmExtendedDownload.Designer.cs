﻿namespace youtube_dl_gui {
    partial class frmExtendedDownload {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.pbThumbnail = new System.Windows.Forms.PictureBox();
            this.txtMediaTitle = new System.Windows.Forms.TextBox();
            this.lbExtendedDownloaderUploader = new System.Windows.Forms.Label();
            this.txtUploader = new System.Windows.Forms.TextBox();
            this.lbExtendedDownloaderDownloadingThumbnail = new System.Windows.Forms.Label();
            this.btnExtendedDownloaderDownloadThumbnail = new System.Windows.Forms.Button();
            this.lbTimestamp = new System.Windows.Forms.Label();
            this.txtViews = new System.Windows.Forms.TextBox();
            this.lbExtendedDownloaderViews = new System.Windows.Forms.Label();
            this.tcVideoData = new System.Windows.Forms.TabControl();
            this.tpFormats = new System.Windows.Forms.TabPage();
            this.tcFormats = new System.Windows.Forms.TabControl();
            this.tabVideoFormats = new System.Windows.Forms.TabPage();
            this.lvVideoFormats = new System.Windows.Forms.ListView();
            this.chVideoQuality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoFPS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoContainer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoBitrate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoDimension = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoCodec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoFormatId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabAudioFormats = new System.Windows.Forms.TabPage();
            this.lvAudioFormats = new System.Windows.Forms.ListView();
            this.chAudioBitrate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudioContainer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudioSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudioSampleRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudioCodec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudioFormatId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabCustom = new System.Windows.Forms.TabPage();
            this.txtCustomArguments = new System.Windows.Forms.TextBox();
            this.tpFormatOptions = new System.Windows.Forms.TabPage();
            this.chkVideoSeparateAudio = new System.Windows.Forms.CheckBox();
            this.cbVbrQualities = new System.Windows.Forms.ComboBox();
            this.chkAudioVBR = new System.Windows.Forms.CheckBox();
            this.chkVideoDownloadAudio = new System.Windows.Forms.CheckBox();
            this.lbSchema = new System.Windows.Forms.Label();
            this.cbSchema = new System.Windows.Forms.ComboBox();
            this.lbAudioEncoder = new System.Windows.Forms.Label();
            this.lbVideoEncoder = new System.Windows.Forms.Label();
            this.cbAudioEncoders = new System.Windows.Forms.ComboBox();
            this.cbVideoEncoders = new System.Windows.Forms.ComboBox();
            this.tpDescription = new System.Windows.Forms.TabPage();
            this.rtbMediaDescription = new murrty.controls.ExtendedRichTextBox();
            this.tpVerbose = new System.Windows.Forms.TabPage();
            this.txtGeneratedArguments = new System.Windows.Forms.TextBox();
            this.rtbVerbose = new murrty.controls.ExtendedRichTextBox();
            this.tpDebug = new System.Windows.Forms.TabPage();
            this.btnKill = new System.Windows.Forms.Button();
            this.chkPbTaskbar = new System.Windows.Forms.CheckBox();
            this.btnPbRemove = new System.Windows.Forms.Button();
            this.btnPbAdd = new System.Windows.Forms.Button();
            this.btnCreateArgs = new System.Windows.Forms.Button();
            this.rbVideo = new System.Windows.Forms.RadioButton();
            this.rbAudio = new System.Windows.Forms.RadioButton();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.btnDownloadAbortClose = new System.Windows.Forms.Button();
            this.btnDownloadWithAuthentication = new System.Windows.Forms.Button();
            this.chkDownloaderCloseAfterDownload = new System.Windows.Forms.CheckBox();
            this.pbStatus = new murrty.controls.ExtendedProgressBar();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.lbExtendedDownloaderLink = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).BeginInit();
            this.tcVideoData.SuspendLayout();
            this.tpFormats.SuspendLayout();
            this.tcFormats.SuspendLayout();
            this.tabVideoFormats.SuspendLayout();
            this.tabAudioFormats.SuspendLayout();
            this.tabCustom.SuspendLayout();
            this.tpFormatOptions.SuspendLayout();
            this.tpDescription.SuspendLayout();
            this.tpVerbose.SuspendLayout();
            this.tpDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbThumbnail
            // 
            this.pbThumbnail.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbThumbnail.Location = new System.Drawing.Point(12, 12);
            this.pbThumbnail.Name = "pbThumbnail";
            this.pbThumbnail.Size = new System.Drawing.Size(318, 178);
            this.pbThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThumbnail.TabIndex = 0;
            this.pbThumbnail.TabStop = false;
            // 
            // txtMediaTitle
            // 
            this.txtMediaTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMediaTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMediaTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMediaTitle.Location = new System.Drawing.Point(12, 196);
            this.txtMediaTitle.Name = "txtMediaTitle";
            this.txtMediaTitle.ReadOnly = true;
            this.txtMediaTitle.Size = new System.Drawing.Size(450, 22);
            this.txtMediaTitle.TabIndex = 6;
            // 
            // lbExtendedDownloaderUploader
            // 
            this.lbExtendedDownloaderUploader.AutoSize = true;
            this.lbExtendedDownloaderUploader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExtendedDownloaderUploader.Location = new System.Drawing.Point(333, 107);
            this.lbExtendedDownloaderUploader.Name = "lbExtendedDownloaderUploader";
            this.lbExtendedDownloaderUploader.Size = new System.Drawing.Size(51, 13);
            this.lbExtendedDownloaderUploader.TabIndex = 10;
            this.lbExtendedDownloaderUploader.Text = "Uploader";
            // 
            // txtUploader
            // 
            this.txtUploader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUploader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUploader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUploader.Location = new System.Drawing.Point(336, 119);
            this.txtUploader.Name = "txtUploader";
            this.txtUploader.ReadOnly = true;
            this.txtUploader.Size = new System.Drawing.Size(128, 22);
            this.txtUploader.TabIndex = 11;
            // 
            // lbExtendedDownloaderDownloadingThumbnail
            // 
            this.lbExtendedDownloaderDownloadingThumbnail.AutoSize = true;
            this.lbExtendedDownloaderDownloadingThumbnail.BackColor = System.Drawing.Color.Transparent;
            this.lbExtendedDownloaderDownloadingThumbnail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExtendedDownloaderDownloadingThumbnail.Location = new System.Drawing.Point(20, 20);
            this.lbExtendedDownloaderDownloadingThumbnail.Name = "lbExtendedDownloaderDownloadingThumbnail";
            this.lbExtendedDownloaderDownloadingThumbnail.Size = new System.Drawing.Size(155, 17);
            this.lbExtendedDownloaderDownloadingThumbnail.TabIndex = 12;
            this.lbExtendedDownloaderDownloadingThumbnail.Text = "Downloading thumbnail...";
            this.lbExtendedDownloaderDownloadingThumbnail.Visible = false;
            // 
            // btnExtendedDownloaderDownloadThumbnail
            // 
            this.btnExtendedDownloaderDownloadThumbnail.BackColor = System.Drawing.Color.Transparent;
            this.btnExtendedDownloaderDownloadThumbnail.Location = new System.Drawing.Point(20, 159);
            this.btnExtendedDownloaderDownloadThumbnail.Name = "btnExtendedDownloaderDownloadThumbnail";
            this.btnExtendedDownloaderDownloadThumbnail.Size = new System.Drawing.Size(122, 23);
            this.btnExtendedDownloaderDownloadThumbnail.TabIndex = 13;
            this.btnExtendedDownloaderDownloadThumbnail.Text = "Get thumbnail";
            this.btnExtendedDownloaderDownloadThumbnail.UseVisualStyleBackColor = false;
            this.btnExtendedDownloaderDownloadThumbnail.Visible = false;
            this.btnExtendedDownloaderDownloadThumbnail.Click += new System.EventHandler(this.btnDownloadThumbnail_Click);
            // 
            // lbTimestamp
            // 
            this.lbTimestamp.AutoSize = true;
            this.lbTimestamp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.lbTimestamp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbTimestamp.Location = new System.Drawing.Point(294, 169);
            this.lbTimestamp.Name = "lbTimestamp";
            this.lbTimestamp.Size = new System.Drawing.Size(28, 13);
            this.lbTimestamp.TabIndex = 14;
            this.lbTimestamp.Text = "0:00";
            this.lbTimestamp.Visible = false;
            // 
            // txtViews
            // 
            this.txtViews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtViews.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtViews.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtViews.Location = new System.Drawing.Point(336, 168);
            this.txtViews.Name = "txtViews";
            this.txtViews.ReadOnly = true;
            this.txtViews.Size = new System.Drawing.Size(128, 22);
            this.txtViews.TabIndex = 16;
            // 
            // lbExtendedDownloaderViews
            // 
            this.lbExtendedDownloaderViews.AutoSize = true;
            this.lbExtendedDownloaderViews.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExtendedDownloaderViews.Location = new System.Drawing.Point(333, 156);
            this.lbExtendedDownloaderViews.Name = "lbExtendedDownloaderViews";
            this.lbExtendedDownloaderViews.Size = new System.Drawing.Size(34, 13);
            this.lbExtendedDownloaderViews.TabIndex = 15;
            this.lbExtendedDownloaderViews.Text = "Views";
            // 
            // tcVideoData
            // 
            this.tcVideoData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcVideoData.Controls.Add(this.tpFormats);
            this.tcVideoData.Controls.Add(this.tpDescription);
            this.tcVideoData.Controls.Add(this.tpVerbose);
            this.tcVideoData.Controls.Add(this.tpDebug);
            this.tcVideoData.Location = new System.Drawing.Point(12, 253);
            this.tcVideoData.Name = "tcVideoData";
            this.tcVideoData.SelectedIndex = 0;
            this.tcVideoData.Size = new System.Drawing.Size(450, 201);
            this.tcVideoData.TabIndex = 17;
            // 
            // tpFormats
            // 
            this.tpFormats.Controls.Add(this.tcFormats);
            this.tpFormats.Location = new System.Drawing.Point(4, 22);
            this.tpFormats.Name = "tpFormats";
            this.tpFormats.Padding = new System.Windows.Forms.Padding(3);
            this.tpFormats.Size = new System.Drawing.Size(442, 175);
            this.tpFormats.TabIndex = 0;
            this.tpFormats.Text = "Format";
            this.tpFormats.UseVisualStyleBackColor = true;
            // 
            // tcFormats
            // 
            this.tcFormats.Controls.Add(this.tabVideoFormats);
            this.tcFormats.Controls.Add(this.tabAudioFormats);
            this.tcFormats.Controls.Add(this.tabCustom);
            this.tcFormats.Controls.Add(this.tpFormatOptions);
            this.tcFormats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcFormats.Location = new System.Drawing.Point(3, 3);
            this.tcFormats.Name = "tcFormats";
            this.tcFormats.SelectedIndex = 0;
            this.tcFormats.Size = new System.Drawing.Size(436, 169);
            this.tcFormats.TabIndex = 0;
            // 
            // tabVideoFormats
            // 
            this.tabVideoFormats.Controls.Add(this.lvVideoFormats);
            this.tabVideoFormats.Location = new System.Drawing.Point(4, 22);
            this.tabVideoFormats.Name = "tabVideoFormats";
            this.tabVideoFormats.Padding = new System.Windows.Forms.Padding(3);
            this.tabVideoFormats.Size = new System.Drawing.Size(428, 143);
            this.tabVideoFormats.TabIndex = 0;
            this.tabVideoFormats.Text = "GenericVideo";
            this.tabVideoFormats.UseVisualStyleBackColor = true;
            // 
            // lvVideoFormats
            // 
            this.lvVideoFormats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chVideoQuality,
            this.chVideoFPS,
            this.chVideoContainer,
            this.chVideoFileSize,
            this.chVideoBitrate,
            this.chVideoDimension,
            this.chVideoCodec,
            this.chVideoFormatId});
            this.lvVideoFormats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvVideoFormats.FullRowSelect = true;
            this.lvVideoFormats.HideSelection = false;
            this.lvVideoFormats.Location = new System.Drawing.Point(3, 3);
            this.lvVideoFormats.MultiSelect = false;
            this.lvVideoFormats.Name = "lvVideoFormats";
            this.lvVideoFormats.Size = new System.Drawing.Size(422, 137);
            this.lvVideoFormats.TabIndex = 13;
            this.lvVideoFormats.UseCompatibleStateImageBehavior = false;
            this.lvVideoFormats.View = System.Windows.Forms.View.Details;
            // 
            // chVideoQuality
            // 
            this.chVideoQuality.Text = "Quality";
            this.chVideoQuality.Width = 69;
            // 
            // chVideoFPS
            // 
            this.chVideoFPS.Text = "FPS";
            this.chVideoFPS.Width = 31;
            // 
            // chVideoContainer
            // 
            this.chVideoContainer.Text = "Container";
            this.chVideoContainer.Width = 65;
            // 
            // chVideoFileSize
            // 
            this.chVideoFileSize.Text = "File size";
            // 
            // chVideoBitrate
            // 
            this.chVideoBitrate.Text = "Bitrate";
            this.chVideoBitrate.Width = 67;
            // 
            // chVideoDimension
            // 
            this.chVideoDimension.Text = "Dimensions";
            this.chVideoDimension.Width = 85;
            // 
            // chVideoCodec
            // 
            this.chVideoCodec.Text = "Codec";
            this.chVideoCodec.Width = 94;
            // 
            // chVideoFormatId
            // 
            this.chVideoFormatId.Text = "ID";
            this.chVideoFormatId.Width = 38;
            // 
            // tabAudioFormats
            // 
            this.tabAudioFormats.Controls.Add(this.lvAudioFormats);
            this.tabAudioFormats.Location = new System.Drawing.Point(4, 22);
            this.tabAudioFormats.Name = "tabAudioFormats";
            this.tabAudioFormats.Padding = new System.Windows.Forms.Padding(3);
            this.tabAudioFormats.Size = new System.Drawing.Size(428, 143);
            this.tabAudioFormats.TabIndex = 1;
            this.tabAudioFormats.Text = "GenericAudio";
            this.tabAudioFormats.UseVisualStyleBackColor = true;
            // 
            // lvAudioFormats
            // 
            this.lvAudioFormats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAudioBitrate,
            this.chAudioContainer,
            this.chAudioSize,
            this.chAudioSampleRate,
            this.chAudioCodec,
            this.chAudioFormatId});
            this.lvAudioFormats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAudioFormats.FullRowSelect = true;
            this.lvAudioFormats.HideSelection = false;
            this.lvAudioFormats.Location = new System.Drawing.Point(3, 3);
            this.lvAudioFormats.MultiSelect = false;
            this.lvAudioFormats.Name = "lvAudioFormats";
            this.lvAudioFormats.Size = new System.Drawing.Size(422, 137);
            this.lvAudioFormats.TabIndex = 14;
            this.lvAudioFormats.UseCompatibleStateImageBehavior = false;
            this.lvAudioFormats.View = System.Windows.Forms.View.Details;
            // 
            // chAudioBitrate
            // 
            this.chAudioBitrate.Text = "Bitrate";
            this.chAudioBitrate.Width = 74;
            // 
            // chAudioContainer
            // 
            this.chAudioContainer.Text = "Container";
            this.chAudioContainer.Width = 70;
            // 
            // chAudioSize
            // 
            this.chAudioSize.Text = "File size";
            this.chAudioSize.Width = 76;
            // 
            // chAudioSampleRate
            // 
            this.chAudioSampleRate.Text = "Sample rate";
            this.chAudioSampleRate.Width = 86;
            // 
            // chAudioCodec
            // 
            this.chAudioCodec.Text = "Codec";
            this.chAudioCodec.Width = 109;
            // 
            // chAudioFormatId
            // 
            this.chAudioFormatId.Text = "ID";
            this.chAudioFormatId.Width = 35;
            // 
            // tabCustom
            // 
            this.tabCustom.Controls.Add(this.txtCustomArguments);
            this.tabCustom.Location = new System.Drawing.Point(4, 22);
            this.tabCustom.Name = "tabCustom";
            this.tabCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustom.Size = new System.Drawing.Size(428, 143);
            this.tabCustom.TabIndex = 3;
            this.tabCustom.Text = "GenericCustom";
            this.tabCustom.UseVisualStyleBackColor = true;
            // 
            // txtCustomArguments
            // 
            this.txtCustomArguments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustomArguments.Enabled = false;
            this.txtCustomArguments.Location = new System.Drawing.Point(3, 3);
            this.txtCustomArguments.Multiline = true;
            this.txtCustomArguments.Name = "txtCustomArguments";
            this.txtCustomArguments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCustomArguments.Size = new System.Drawing.Size(422, 137);
            this.txtCustomArguments.TabIndex = 15;
            // 
            // tpFormatOptions
            // 
            this.tpFormatOptions.Controls.Add(this.chkVideoSeparateAudio);
            this.tpFormatOptions.Controls.Add(this.cbVbrQualities);
            this.tpFormatOptions.Controls.Add(this.chkAudioVBR);
            this.tpFormatOptions.Controls.Add(this.chkVideoDownloadAudio);
            this.tpFormatOptions.Controls.Add(this.lbSchema);
            this.tpFormatOptions.Controls.Add(this.cbSchema);
            this.tpFormatOptions.Controls.Add(this.lbAudioEncoder);
            this.tpFormatOptions.Controls.Add(this.lbVideoEncoder);
            this.tpFormatOptions.Controls.Add(this.cbAudioEncoders);
            this.tpFormatOptions.Controls.Add(this.cbVideoEncoders);
            this.tpFormatOptions.Location = new System.Drawing.Point(4, 22);
            this.tpFormatOptions.Name = "tpFormatOptions";
            this.tpFormatOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tpFormatOptions.Size = new System.Drawing.Size(428, 143);
            this.tpFormatOptions.TabIndex = 2;
            this.tpFormatOptions.Text = "tpFormatOptions";
            this.tpFormatOptions.UseVisualStyleBackColor = true;
            // 
            // chkVideoSeparateAudio
            // 
            this.chkVideoSeparateAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkVideoSeparateAudio.AutoSize = true;
            this.chkVideoSeparateAudio.Location = new System.Drawing.Point(6, 120);
            this.chkVideoSeparateAudio.Name = "chkVideoSeparateAudio";
            this.chkVideoSeparateAudio.Size = new System.Drawing.Size(149, 17);
            this.chkVideoSeparateAudio.TabIndex = 28;
            this.chkVideoSeparateAudio.Text = "chkVideoSeparateAudio";
            this.chkVideoSeparateAudio.UseVisualStyleBackColor = true;
            // 
            // cbVbrQualities
            // 
            this.cbVbrQualities.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVbrQualities.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVbrQualities.Enabled = false;
            this.cbVbrQualities.FormattingEnabled = true;
            this.cbVbrQualities.Location = new System.Drawing.Point(348, 62);
            this.cbVbrQualities.Name = "cbVbrQualities";
            this.cbVbrQualities.Size = new System.Drawing.Size(74, 21);
            this.cbVbrQualities.TabIndex = 27;
            // 
            // chkAudioVBR
            // 
            this.chkAudioVBR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAudioVBR.AutoSize = true;
            this.chkAudioVBR.Location = new System.Drawing.Point(297, 64);
            this.chkAudioVBR.Name = "chkAudioVBR";
            this.chkAudioVBR.Size = new System.Drawing.Size(45, 17);
            this.chkAudioVBR.TabIndex = 26;
            this.chkAudioVBR.Text = "VBR";
            this.chkAudioVBR.UseVisualStyleBackColor = true;
            this.chkAudioVBR.CheckedChanged += new System.EventHandler(this.chkAudioVBR_CheckedChanged);
            // 
            // chkVideoDownloadAudio
            // 
            this.chkVideoDownloadAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkVideoDownloadAudio.AutoSize = true;
            this.chkVideoDownloadAudio.Checked = true;
            this.chkVideoDownloadAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVideoDownloadAudio.Location = new System.Drawing.Point(6, 97);
            this.chkVideoDownloadAudio.Name = "chkVideoDownloadAudio";
            this.chkVideoDownloadAudio.Size = new System.Drawing.Size(158, 17);
            this.chkVideoDownloadAudio.TabIndex = 17;
            this.chkVideoDownloadAudio.Text = "chkVideoDownloadAudio";
            this.chkVideoDownloadAudio.UseVisualStyleBackColor = true;
            this.chkVideoDownloadAudio.CheckedChanged += new System.EventHandler(this.chkVideoDownloadAudio_CheckedChanged);
            // 
            // lbSchema
            // 
            this.lbSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSchema.Location = new System.Drawing.Point(140, 37);
            this.lbSchema.Name = "lbSchema";
            this.lbSchema.Size = new System.Drawing.Size(113, 15);
            this.lbSchema.TabIndex = 25;
            this.lbSchema.Text = "lbSchema";
            this.lbSchema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSchema
            // 
            this.cbSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSchema.FormattingEnabled = true;
            this.cbSchema.Location = new System.Drawing.Point(255, 35);
            this.cbSchema.Name = "cbSchema";
            this.cbSchema.Size = new System.Drawing.Size(167, 21);
            this.cbSchema.TabIndex = 24;
            this.cbSchema.Text = "%(title)s-%(id)s.%(ext)s";
            // 
            // lbAudioEncoder
            // 
            this.lbAudioEncoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAudioEncoder.Location = new System.Drawing.Point(236, 116);
            this.lbAudioEncoder.Name = "lbAudioEncoder";
            this.lbAudioEncoder.Size = new System.Drawing.Size(61, 21);
            this.lbAudioEncoder.TabIndex = 20;
            this.lbAudioEncoder.Text = "lbAudioEncoder";
            this.lbAudioEncoder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbVideoEncoder
            // 
            this.lbVideoEncoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVideoEncoder.Location = new System.Drawing.Point(236, 89);
            this.lbVideoEncoder.Name = "lbVideoEncoder";
            this.lbVideoEncoder.Size = new System.Drawing.Size(61, 21);
            this.lbVideoEncoder.TabIndex = 19;
            this.lbVideoEncoder.Text = "lbVideoEncoder";
            this.lbVideoEncoder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbAudioEncoders
            // 
            this.cbAudioEncoders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioEncoders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioEncoders.FormattingEnabled = true;
            this.cbAudioEncoders.Items.AddRange(new object[] {
            "(do not re-encode)"});
            this.cbAudioEncoders.Location = new System.Drawing.Point(303, 116);
            this.cbAudioEncoders.Name = "cbAudioEncoders";
            this.cbAudioEncoders.Size = new System.Drawing.Size(119, 21);
            this.cbAudioEncoders.TabIndex = 18;
            // 
            // cbVideoEncoders
            // 
            this.cbVideoEncoders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVideoEncoders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoEncoders.FormattingEnabled = true;
            this.cbVideoEncoders.Items.AddRange(new object[] {
            "(do not re-encode)"});
            this.cbVideoEncoders.Location = new System.Drawing.Point(303, 89);
            this.cbVideoEncoders.Name = "cbVideoEncoders";
            this.cbVideoEncoders.Size = new System.Drawing.Size(119, 21);
            this.cbVideoEncoders.TabIndex = 16;
            // 
            // tpDescription
            // 
            this.tpDescription.Controls.Add(this.rtbMediaDescription);
            this.tpDescription.Location = new System.Drawing.Point(4, 22);
            this.tpDescription.Name = "tpDescription";
            this.tpDescription.Padding = new System.Windows.Forms.Padding(3);
            this.tpDescription.Size = new System.Drawing.Size(442, 175);
            this.tpDescription.TabIndex = 1;
            this.tpDescription.Text = "Description";
            this.tpDescription.UseVisualStyleBackColor = true;
            // 
            // rtbMediaDescription
            // 
            this.rtbMediaDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMediaDescription.Location = new System.Drawing.Point(3, 3);
            this.rtbMediaDescription.Name = "rtbMediaDescription";
            this.rtbMediaDescription.ReadOnly = true;
            this.rtbMediaDescription.Size = new System.Drawing.Size(436, 169);
            this.rtbMediaDescription.TabIndex = 2;
            this.rtbMediaDescription.Text = "";
            // 
            // tpVerbose
            // 
            this.tpVerbose.Controls.Add(this.txtGeneratedArguments);
            this.tpVerbose.Controls.Add(this.rtbVerbose);
            this.tpVerbose.Location = new System.Drawing.Point(4, 22);
            this.tpVerbose.Name = "tpVerbose";
            this.tpVerbose.Padding = new System.Windows.Forms.Padding(3);
            this.tpVerbose.Size = new System.Drawing.Size(442, 175);
            this.tpVerbose.TabIndex = 3;
            this.tpVerbose.Text = "Verbose";
            this.tpVerbose.UseVisualStyleBackColor = true;
            // 
            // txtGeneratedArguments
            // 
            this.txtGeneratedArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeneratedArguments.Location = new System.Drawing.Point(6, 147);
            this.txtGeneratedArguments.Name = "txtGeneratedArguments";
            this.txtGeneratedArguments.ReadOnly = true;
            this.txtGeneratedArguments.Size = new System.Drawing.Size(430, 22);
            this.txtGeneratedArguments.TabIndex = 1;
            // 
            // rtbVerbose
            // 
            this.rtbVerbose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbVerbose.Location = new System.Drawing.Point(3, 3);
            this.rtbVerbose.Name = "rtbVerbose";
            this.rtbVerbose.ReadOnly = true;
            this.rtbVerbose.Size = new System.Drawing.Size(436, 140);
            this.rtbVerbose.TabIndex = 0;
            this.rtbVerbose.Text = "";
            // 
            // tpDebug
            // 
            this.tpDebug.Controls.Add(this.btnKill);
            this.tpDebug.Controls.Add(this.chkPbTaskbar);
            this.tpDebug.Controls.Add(this.btnPbRemove);
            this.tpDebug.Controls.Add(this.btnPbAdd);
            this.tpDebug.Controls.Add(this.btnCreateArgs);
            this.tpDebug.Location = new System.Drawing.Point(4, 22);
            this.tpDebug.Name = "tpDebug";
            this.tpDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tpDebug.Size = new System.Drawing.Size(442, 175);
            this.tpDebug.TabIndex = 2;
            this.tpDebug.Text = "Debug";
            this.tpDebug.UseVisualStyleBackColor = true;
            // 
            // btnKill
            // 
            this.btnKill.Location = new System.Drawing.Point(17, 44);
            this.btnKill.Name = "btnKill";
            this.btnKill.Size = new System.Drawing.Size(86, 23);
            this.btnKill.TabIndex = 4;
            this.btnKill.Text = "Kill";
            this.btnKill.UseVisualStyleBackColor = true;
            this.btnKill.Click += new System.EventHandler(this.btnKill_Click);
            // 
            // chkPbTaskbar
            // 
            this.chkPbTaskbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPbTaskbar.AutoSize = true;
            this.chkPbTaskbar.Location = new System.Drawing.Point(79, 150);
            this.chkPbTaskbar.Name = "chkPbTaskbar";
            this.chkPbTaskbar.Size = new System.Drawing.Size(64, 17);
            this.chkPbTaskbar.TabIndex = 3;
            this.chkPbTaskbar.Text = "Taskbar";
            this.chkPbTaskbar.UseVisualStyleBackColor = true;
            this.chkPbTaskbar.CheckedChanged += new System.EventHandler(this.chkPbTaskbar_CheckedChanged);
            // 
            // btnPbRemove
            // 
            this.btnPbRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPbRemove.Location = new System.Drawing.Point(43, 146);
            this.btnPbRemove.Name = "btnPbRemove";
            this.btnPbRemove.Size = new System.Drawing.Size(30, 23);
            this.btnPbRemove.TabIndex = 2;
            this.btnPbRemove.Text = "-";
            this.btnPbRemove.UseVisualStyleBackColor = true;
            this.btnPbRemove.Click += new System.EventHandler(this.btnPbRemove_Click);
            // 
            // btnPbAdd
            // 
            this.btnPbAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPbAdd.Location = new System.Drawing.Point(7, 146);
            this.btnPbAdd.Name = "btnPbAdd";
            this.btnPbAdd.Size = new System.Drawing.Size(30, 23);
            this.btnPbAdd.TabIndex = 1;
            this.btnPbAdd.Text = "+";
            this.btnPbAdd.UseVisualStyleBackColor = true;
            this.btnPbAdd.Click += new System.EventHandler(this.btnPbAdd_Click);
            // 
            // btnCreateArgs
            // 
            this.btnCreateArgs.Location = new System.Drawing.Point(17, 15);
            this.btnCreateArgs.Name = "btnCreateArgs";
            this.btnCreateArgs.Size = new System.Drawing.Size(86, 23);
            this.btnCreateArgs.TabIndex = 0;
            this.btnCreateArgs.Text = "Create args";
            this.btnCreateArgs.UseVisualStyleBackColor = true;
            this.btnCreateArgs.Click += new System.EventHandler(this.btnCreateArgs_Click);
            // 
            // rbVideo
            // 
            this.rbVideo.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbVideo.Checked = true;
            this.rbVideo.Location = new System.Drawing.Point(12, 224);
            this.rbVideo.Name = "rbVideo";
            this.rbVideo.Size = new System.Drawing.Size(120, 23);
            this.rbVideo.TabIndex = 10;
            this.rbVideo.TabStop = true;
            this.rbVideo.Text = "rbVideo";
            this.rbVideo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbVideo.UseVisualStyleBackColor = true;
            this.rbVideo.CheckedChanged += new System.EventHandler(this.rbVideo_CheckedChanged);
            // 
            // rbAudio
            // 
            this.rbAudio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbAudio.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbAudio.Location = new System.Drawing.Point(177, 224);
            this.rbAudio.Name = "rbAudio";
            this.rbAudio.Size = new System.Drawing.Size(120, 23);
            this.rbAudio.TabIndex = 11;
            this.rbAudio.TabStop = true;
            this.rbAudio.Text = "rbAudio";
            this.rbAudio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbAudio.UseVisualStyleBackColor = true;
            this.rbAudio.CheckedChanged += new System.EventHandler(this.rbAudio_CheckedChanged);
            // 
            // rbCustom
            // 
            this.rbCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCustom.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCustom.Location = new System.Drawing.Point(342, 224);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(120, 23);
            this.rbCustom.TabIndex = 12;
            this.rbCustom.TabStop = true;
            this.rbCustom.Text = "rbCustom";
            this.rbCustom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCustom.UseVisualStyleBackColor = true;
            this.rbCustom.CheckedChanged += new System.EventHandler(this.rbCustom_CheckedChanged);
            // 
            // btnDownloadAbortClose
            // 
            this.btnDownloadAbortClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadAbortClose.Enabled = false;
            this.btnDownloadAbortClose.Location = new System.Drawing.Point(371, 460);
            this.btnDownloadAbortClose.Name = "btnDownloadAbortClose";
            this.btnDownloadAbortClose.Size = new System.Drawing.Size(87, 23);
            this.btnDownloadAbortClose.TabIndex = 18;
            this.btnDownloadAbortClose.Text = "btnDownloadAbortClose";
            this.btnDownloadAbortClose.UseVisualStyleBackColor = true;
            this.btnDownloadAbortClose.Click += new System.EventHandler(this.btnDownloadAbortClose_Click);
            // 
            // btnDownloadWithAuthentication
            // 
            this.btnDownloadWithAuthentication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadWithAuthentication.Enabled = false;
            this.btnDownloadWithAuthentication.Location = new System.Drawing.Point(211, 460);
            this.btnDownloadWithAuthentication.Name = "btnDownloadWithAuthentication";
            this.btnDownloadWithAuthentication.Size = new System.Drawing.Size(154, 23);
            this.btnDownloadWithAuthentication.TabIndex = 19;
            this.btnDownloadWithAuthentication.Text = "btnDownloadWithAuthentication";
            this.btnDownloadWithAuthentication.UseVisualStyleBackColor = true;
            this.btnDownloadWithAuthentication.Click += new System.EventHandler(this.btnDownloadWithAuthentication_Click);
            // 
            // chkDownloaderCloseAfterDownload
            // 
            this.chkDownloaderCloseAfterDownload.AutoSize = true;
            this.chkDownloaderCloseAfterDownload.Location = new System.Drawing.Point(336, 12);
            this.chkDownloaderCloseAfterDownload.Name = "chkDownloaderCloseAfterDownload";
            this.chkDownloaderCloseAfterDownload.Size = new System.Drawing.Size(214, 17);
            this.chkDownloaderCloseAfterDownload.TabIndex = 21;
            this.chkDownloaderCloseAfterDownload.Text = "chkDownloaderCloseAfterDownload";
            this.chkDownloaderCloseAfterDownload.UseVisualStyleBackColor = true;
            // 
            // pbStatus
            // 
            this.pbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbStatus.ContainerParent = this;
            this.pbStatus.FastValueUpdate = true;
            this.pbStatus.Location = new System.Drawing.Point(12, 461);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.ShowText = true;
            this.pbStatus.Size = new System.Drawing.Size(193, 21);
            this.pbStatus.TabIndex = 20;
            this.pbStatus.Text = ".  .  .";
            // 
            // txtLink
            // 
            this.txtLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLink.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLink.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLink.Location = new System.Drawing.Point(336, 70);
            this.txtLink.Name = "txtLink";
            this.txtLink.ReadOnly = true;
            this.txtLink.Size = new System.Drawing.Size(128, 22);
            this.txtLink.TabIndex = 23;
            // 
            // lbExtendedDownloaderLink
            // 
            this.lbExtendedDownloaderLink.AutoSize = true;
            this.lbExtendedDownloaderLink.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExtendedDownloaderLink.Location = new System.Drawing.Point(333, 58);
            this.lbExtendedDownloaderLink.Name = "lbExtendedDownloaderLink";
            this.lbExtendedDownloaderLink.Size = new System.Drawing.Size(26, 13);
            this.lbExtendedDownloaderLink.TabIndex = 22;
            this.lbExtendedDownloaderLink.Text = "Link";
            // 
            // frmExtendedDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 495);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.lbExtendedDownloaderLink);
            this.Controls.Add(this.chkDownloaderCloseAfterDownload);
            this.Controls.Add(this.txtViews);
            this.Controls.Add(this.txtUploader);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.btnDownloadWithAuthentication);
            this.Controls.Add(this.btnDownloadAbortClose);
            this.Controls.Add(this.tcVideoData);
            this.Controls.Add(this.rbCustom);
            this.Controls.Add(this.rbAudio);
            this.Controls.Add(this.rbVideo);
            this.Controls.Add(this.lbExtendedDownloaderViews);
            this.Controls.Add(this.lbTimestamp);
            this.Controls.Add(this.btnExtendedDownloaderDownloadThumbnail);
            this.Controls.Add(this.lbExtendedDownloaderDownloadingThumbnail);
            this.Controls.Add(this.lbExtendedDownloaderUploader);
            this.Controls.Add(this.txtMediaTitle);
            this.Controls.Add(this.pbThumbnail);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(490, 530);
            this.Name = "frmExtendedDownload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExtendedDownload";
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).EndInit();
            this.tcVideoData.ResumeLayout(false);
            this.tpFormats.ResumeLayout(false);
            this.tcFormats.ResumeLayout(false);
            this.tabVideoFormats.ResumeLayout(false);
            this.tabAudioFormats.ResumeLayout(false);
            this.tabCustom.ResumeLayout(false);
            this.tabCustom.PerformLayout();
            this.tpFormatOptions.ResumeLayout(false);
            this.tpFormatOptions.PerformLayout();
            this.tpDescription.ResumeLayout(false);
            this.tpVerbose.ResumeLayout(false);
            this.tpVerbose.PerformLayout();
            this.tpDebug.ResumeLayout(false);
            this.tpDebug.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbThumbnail;
        private murrty.controls.ExtendedRichTextBox rtbMediaDescription;
        private System.Windows.Forms.TextBox txtMediaTitle;
        private System.Windows.Forms.Label lbExtendedDownloaderUploader;
        private System.Windows.Forms.TextBox txtUploader;
        private System.Windows.Forms.Label lbExtendedDownloaderDownloadingThumbnail;
        private System.Windows.Forms.Button btnExtendedDownloaderDownloadThumbnail;
        private System.Windows.Forms.Label lbTimestamp;
        private System.Windows.Forms.TextBox txtViews;
        private System.Windows.Forms.Label lbExtendedDownloaderViews;
        private System.Windows.Forms.TabControl tcVideoData;
        private System.Windows.Forms.TabPage tpFormats;
        private System.Windows.Forms.ListView lvVideoFormats;
        private System.Windows.Forms.ColumnHeader chVideoDimension;
        private System.Windows.Forms.ColumnHeader chVideoBitrate;
        private System.Windows.Forms.ColumnHeader chVideoContainer;
        private System.Windows.Forms.ColumnHeader chVideoQuality;
        private System.Windows.Forms.ColumnHeader chVideoFPS;
        private System.Windows.Forms.ColumnHeader chVideoCodec;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rbAudio;
        private System.Windows.Forms.RadioButton rbVideo;
        private System.Windows.Forms.TabPage tpDescription;
        private System.Windows.Forms.ListView lvAudioFormats;
        private System.Windows.Forms.ColumnHeader chAudioBitrate;
        private System.Windows.Forms.ColumnHeader chAudioSampleRate;
        private System.Windows.Forms.ColumnHeader chAudioContainer;
        private System.Windows.Forms.ColumnHeader chAudioCodec;
        private System.Windows.Forms.TextBox txtCustomArguments;
        private System.Windows.Forms.TabPage tpDebug;
        private System.Windows.Forms.Button btnCreateArgs;
        private System.Windows.Forms.ColumnHeader chVideoFileSize;
        private System.Windows.Forms.ColumnHeader chAudioSize;
        private System.Windows.Forms.ComboBox cbVideoEncoders;
        private System.Windows.Forms.ComboBox cbAudioEncoders;
        private System.Windows.Forms.CheckBox chkVideoDownloadAudio;
        private System.Windows.Forms.TabControl tcFormats;
        private System.Windows.Forms.TabPage tabVideoFormats;
        private System.Windows.Forms.TabPage tabAudioFormats;
        private System.Windows.Forms.TabPage tpFormatOptions;
        private System.Windows.Forms.Label lbAudioEncoder;
        private System.Windows.Forms.Label lbVideoEncoder;
        private System.Windows.Forms.Button btnDownloadAbortClose;
        private System.Windows.Forms.Button btnDownloadWithAuthentication;
        private murrty.controls.ExtendedProgressBar pbStatus;
        private System.Windows.Forms.CheckBox chkPbTaskbar;
        private System.Windows.Forms.Button btnPbRemove;
        private System.Windows.Forms.Button btnPbAdd;
        private System.Windows.Forms.TabPage tpVerbose;
        private murrty.controls.ExtendedRichTextBox rtbVerbose;
        private System.Windows.Forms.Button btnKill;
        private System.Windows.Forms.TextBox txtGeneratedArguments;
        private System.Windows.Forms.Label lbSchema;
        private System.Windows.Forms.ComboBox cbSchema;
        private System.Windows.Forms.CheckBox chkAudioVBR;
        private System.Windows.Forms.ComboBox cbVbrQualities;
        private System.Windows.Forms.CheckBox chkVideoSeparateAudio;
        private System.Windows.Forms.TabPage tabCustom;
        private System.Windows.Forms.CheckBox chkDownloaderCloseAfterDownload;
        private System.Windows.Forms.ColumnHeader chVideoFormatId;
        private System.Windows.Forms.ColumnHeader chAudioFormatId;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label lbExtendedDownloaderLink;
    }
}