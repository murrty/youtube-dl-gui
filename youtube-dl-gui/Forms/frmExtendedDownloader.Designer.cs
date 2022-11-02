namespace youtube_dl_gui {
    partial class frmExtendedDownloader {
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
            this.txtExtendedDownloaderMediaTitle = new System.Windows.Forms.TextBox();
            this.lbExtendedDownloaderUploader = new System.Windows.Forms.Label();
            this.txtUploader = new System.Windows.Forms.TextBox();
            this.lbExtendedDownloaderDownloadingThumbnail = new System.Windows.Forms.Label();
            this.btnExtendedDownloaderDownloadThumbnail = new System.Windows.Forms.Button();
            this.lbTimestamp = new System.Windows.Forms.Label();
            this.txtViews = new System.Windows.Forms.TextBox();
            this.lbExtendedDownloaderViews = new System.Windows.Forms.Label();
            this.tcVideoData = new System.Windows.Forms.TabControl();
            this.tabExtendedDownloaderFormats = new System.Windows.Forms.TabPage();
            this.tcFormats = new System.Windows.Forms.TabControl();
            this.tabVideoFormats = new System.Windows.Forms.TabPage();
            this.lbExtendedDownloaderNoVideoFormatsAvailable = new System.Windows.Forms.Label();
            this.lvVideoFormats = new murrty.controls.ExtendedListView();
            this.chVideoQuality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoFPS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoContainer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoBitrate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoDimension = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoCodec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoAudioBitrate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoAudioSampleRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoAudioCodec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoAudioChannels = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoFormatId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabAudioFormats = new System.Windows.Forms.TabPage();
            this.lbExtendedDownloaderNoAudioFormatsAvailable = new System.Windows.Forms.Label();
            this.lvAudioFormats = new murrty.controls.ExtendedListView();
            this.chAudioBitrate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudioContainer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudioFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudioSampleRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudioCodec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudioChannels = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudioFormatId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabExtendedDownloaderUnknownFormats = new System.Windows.Forms.TabPage();
            this.lbExtendedDownloaderNoUnknownFormatsFound = new System.Windows.Forms.Label();
            this.lvUnknownFormats = new murrty.controls.ExtendedListView();
            this.chUnknownQuality = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUnknownFPS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUnknownContainer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUnknownFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUnknownVideoBitrate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUnknownDimensions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUnknownVideoCodec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUnknownAudioBitrate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUnknownAudioSampleRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUnknownAudioCodec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUnknownAudioChannels = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chUnknownFormatId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabCustom = new System.Windows.Forms.TabPage();
            this.txtCustomArguments = new System.Windows.Forms.TextBox();
            this.tabFormatOptions = new System.Windows.Forms.TabPage();
            this.lbVideoRemux = new System.Windows.Forms.Label();
            this.cbVideoRemux = new System.Windows.Forms.ComboBox();
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
            this.tabExtendedDownloaderDescription = new System.Windows.Forms.TabPage();
            this.rtbMediaDescription = new murrty.controls.ExtendedRichTextBox();
            this.tabExtendedDownloaderVerbose = new System.Windows.Forms.TabPage();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.txtGeneratedArguments = new System.Windows.Forms.TextBox();
            this.rtbVerbose = new murrty.controls.ExtendedRichTextBox();
            this.tabDebug = new System.Windows.Forms.TabPage();
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
            this.txtLink = new System.Windows.Forms.TextBox();
            this.lbExtendedDownloaderLink = new System.Windows.Forms.Label();
            this.pbThumbnailBackground = new System.Windows.Forms.PictureBox();
            this.pbStatus = new murrty.controls.ExtendedProgressBar();
            this.rbUnknownFormat = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).BeginInit();
            this.tcVideoData.SuspendLayout();
            this.tabExtendedDownloaderFormats.SuspendLayout();
            this.tcFormats.SuspendLayout();
            this.tabVideoFormats.SuspendLayout();
            this.tabAudioFormats.SuspendLayout();
            this.tabExtendedDownloaderUnknownFormats.SuspendLayout();
            this.tabCustom.SuspendLayout();
            this.tabFormatOptions.SuspendLayout();
            this.tabExtendedDownloaderDescription.SuspendLayout();
            this.tabExtendedDownloaderVerbose.SuspendLayout();
            this.tabDebug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnailBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // pbThumbnail
            // 
            this.pbThumbnail.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbThumbnail.Location = new System.Drawing.Point(12, 12);
            this.pbThumbnail.Name = "pbThumbnail";
            this.pbThumbnail.Size = new System.Drawing.Size(320, 180);
            this.pbThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThumbnail.TabIndex = 0;
            this.pbThumbnail.TabStop = false;
            // 
            // txtExtendedDownloaderMediaTitle
            // 
            this.txtExtendedDownloaderMediaTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExtendedDownloaderMediaTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExtendedDownloaderMediaTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExtendedDownloaderMediaTitle.Location = new System.Drawing.Point(12, 198);
            this.txtExtendedDownloaderMediaTitle.Name = "txtExtendedDownloaderMediaTitle";
            this.txtExtendedDownloaderMediaTitle.ReadOnly = true;
            this.txtExtendedDownloaderMediaTitle.Size = new System.Drawing.Size(450, 22);
            this.txtExtendedDownloaderMediaTitle.TabIndex = 6;
            this.txtExtendedDownloaderMediaTitle.Text = "txtExtendedDownloaderMediaTitle";
            // 
            // lbExtendedDownloaderUploader
            // 
            this.lbExtendedDownloaderUploader.AutoSize = true;
            this.lbExtendedDownloaderUploader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExtendedDownloaderUploader.Location = new System.Drawing.Point(335, 107);
            this.lbExtendedDownloaderUploader.Name = "lbExtendedDownloaderUploader";
            this.lbExtendedDownloaderUploader.Size = new System.Drawing.Size(160, 13);
            this.lbExtendedDownloaderUploader.TabIndex = 10;
            this.lbExtendedDownloaderUploader.Text = "lbExtendedDownloaderUploader";
            // 
            // txtUploader
            // 
            this.txtUploader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUploader.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUploader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUploader.Location = new System.Drawing.Point(338, 119);
            this.txtUploader.Name = "txtUploader";
            this.txtUploader.ReadOnly = true;
            this.txtUploader.Size = new System.Drawing.Size(126, 22);
            this.txtUploader.TabIndex = 11;
            // 
            // lbExtendedDownloaderDownloadingThumbnail
            // 
            this.lbExtendedDownloaderDownloadingThumbnail.AutoSize = true;
            this.lbExtendedDownloaderDownloadingThumbnail.BackColor = System.Drawing.Color.Transparent;
            this.lbExtendedDownloaderDownloadingThumbnail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExtendedDownloaderDownloadingThumbnail.Location = new System.Drawing.Point(20, 20);
            this.lbExtendedDownloaderDownloadingThumbnail.Name = "lbExtendedDownloaderDownloadingThumbnail";
            this.lbExtendedDownloaderDownloadingThumbnail.Size = new System.Drawing.Size(281, 17);
            this.lbExtendedDownloaderDownloadingThumbnail.TabIndex = 12;
            this.lbExtendedDownloaderDownloadingThumbnail.Text = "lbExtendedDownloaderDownloadingThumbnail";
            this.lbExtendedDownloaderDownloadingThumbnail.Visible = false;
            // 
            // btnExtendedDownloaderDownloadThumbnail
            // 
            this.btnExtendedDownloaderDownloadThumbnail.BackColor = System.Drawing.Color.Transparent;
            this.btnExtendedDownloaderDownloadThumbnail.Location = new System.Drawing.Point(20, 159);
            this.btnExtendedDownloaderDownloadThumbnail.Name = "btnExtendedDownloaderDownloadThumbnail";
            this.btnExtendedDownloaderDownloadThumbnail.Size = new System.Drawing.Size(122, 23);
            this.btnExtendedDownloaderDownloadThumbnail.TabIndex = 13;
            this.btnExtendedDownloaderDownloadThumbnail.Text = "btnExtendedDownloaderDownloadThumbnail";
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
            this.txtViews.Location = new System.Drawing.Point(338, 168);
            this.txtViews.Name = "txtViews";
            this.txtViews.ReadOnly = true;
            this.txtViews.Size = new System.Drawing.Size(126, 22);
            this.txtViews.TabIndex = 16;
            // 
            // lbExtendedDownloaderViews
            // 
            this.lbExtendedDownloaderViews.AutoSize = true;
            this.lbExtendedDownloaderViews.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExtendedDownloaderViews.Location = new System.Drawing.Point(335, 156);
            this.lbExtendedDownloaderViews.Name = "lbExtendedDownloaderViews";
            this.lbExtendedDownloaderViews.Size = new System.Drawing.Size(143, 13);
            this.lbExtendedDownloaderViews.TabIndex = 15;
            this.lbExtendedDownloaderViews.Text = "lbExtendedDownloaderViews";
            // 
            // tcVideoData
            // 
            this.tcVideoData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcVideoData.Controls.Add(this.tabExtendedDownloaderFormats);
            this.tcVideoData.Controls.Add(this.tabExtendedDownloaderDescription);
            this.tcVideoData.Controls.Add(this.tabExtendedDownloaderVerbose);
            this.tcVideoData.Controls.Add(this.tabDebug);
            this.tcVideoData.Location = new System.Drawing.Point(12, 255);
            this.tcVideoData.Name = "tcVideoData";
            this.tcVideoData.SelectedIndex = 0;
            this.tcVideoData.Size = new System.Drawing.Size(450, 199);
            this.tcVideoData.TabIndex = 17;
            // 
            // tabExtendedDownloaderFormats
            // 
            this.tabExtendedDownloaderFormats.Controls.Add(this.tcFormats);
            this.tabExtendedDownloaderFormats.Location = new System.Drawing.Point(4, 22);
            this.tabExtendedDownloaderFormats.Name = "tabExtendedDownloaderFormats";
            this.tabExtendedDownloaderFormats.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtendedDownloaderFormats.Size = new System.Drawing.Size(442, 173);
            this.tabExtendedDownloaderFormats.TabIndex = 0;
            this.tabExtendedDownloaderFormats.Text = "tabExtendedDownloaderFormats";
            this.tabExtendedDownloaderFormats.UseVisualStyleBackColor = true;
            // 
            // tcFormats
            // 
            this.tcFormats.Controls.Add(this.tabVideoFormats);
            this.tcFormats.Controls.Add(this.tabAudioFormats);
            this.tcFormats.Controls.Add(this.tabExtendedDownloaderUnknownFormats);
            this.tcFormats.Controls.Add(this.tabCustom);
            this.tcFormats.Controls.Add(this.tabFormatOptions);
            this.tcFormats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcFormats.Location = new System.Drawing.Point(3, 3);
            this.tcFormats.Name = "tcFormats";
            this.tcFormats.SelectedIndex = 0;
            this.tcFormats.Size = new System.Drawing.Size(436, 167);
            this.tcFormats.TabIndex = 0;
            // 
            // tabVideoFormats
            // 
            this.tabVideoFormats.Controls.Add(this.lbExtendedDownloaderNoVideoFormatsAvailable);
            this.tabVideoFormats.Controls.Add(this.lvVideoFormats);
            this.tabVideoFormats.Location = new System.Drawing.Point(4, 22);
            this.tabVideoFormats.Name = "tabVideoFormats";
            this.tabVideoFormats.Padding = new System.Windows.Forms.Padding(3);
            this.tabVideoFormats.Size = new System.Drawing.Size(428, 141);
            this.tabVideoFormats.TabIndex = 0;
            this.tabVideoFormats.Text = "tabVideoFormats";
            this.tabVideoFormats.UseVisualStyleBackColor = true;
            // 
            // lbExtendedDownloaderNoVideoFormatsAvailable
            // 
            this.lbExtendedDownloaderNoVideoFormatsAvailable.AutoSize = true;
            this.lbExtendedDownloaderNoVideoFormatsAvailable.Location = new System.Drawing.Point(11, 35);
            this.lbExtendedDownloaderNoVideoFormatsAvailable.Name = "lbExtendedDownloaderNoVideoFormatsAvailable";
            this.lbExtendedDownloaderNoVideoFormatsAvailable.Size = new System.Drawing.Size(261, 13);
            this.lbExtendedDownloaderNoVideoFormatsAvailable.TabIndex = 14;
            this.lbExtendedDownloaderNoVideoFormatsAvailable.Text = "lbExtendedDownloaderNoVideoFormatsAvailable";
            this.lbExtendedDownloaderNoVideoFormatsAvailable.Visible = false;
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
            this.chVideoAudioBitrate,
            this.chVideoAudioSampleRate,
            this.chVideoAudioCodec,
            this.chVideoAudioChannels,
            this.chVideoFormatId});
            this.lvVideoFormats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvVideoFormats.Enabled = false;
            this.lvVideoFormats.FullRowSelect = true;
            this.lvVideoFormats.HideSelection = false;
            this.lvVideoFormats.Location = new System.Drawing.Point(3, 3);
            this.lvVideoFormats.MultiSelect = false;
            this.lvVideoFormats.Name = "lvVideoFormats";
            this.lvVideoFormats.Size = new System.Drawing.Size(422, 135);
            this.lvVideoFormats.TabIndex = 13;
            this.lvVideoFormats.UseCompatibleStateImageBehavior = false;
            this.lvVideoFormats.View = System.Windows.Forms.View.Details;
            // 
            // chVideoQuality
            // 
            this.chVideoQuality.Text = "chVideoQuality";
            this.chVideoQuality.Width = 69;
            // 
            // chVideoFPS
            // 
            this.chVideoFPS.Text = "chVideoFPS";
            this.chVideoFPS.Width = 31;
            // 
            // chVideoContainer
            // 
            this.chVideoContainer.Text = "chVideoContainer";
            this.chVideoContainer.Width = 65;
            // 
            // chVideoFileSize
            // 
            this.chVideoFileSize.Text = "chVideoFileSize";
            // 
            // chVideoBitrate
            // 
            this.chVideoBitrate.Text = "chVideoBitrate";
            this.chVideoBitrate.Width = 67;
            // 
            // chVideoDimension
            // 
            this.chVideoDimension.Text = "chVideoDimension";
            this.chVideoDimension.Width = 85;
            // 
            // chVideoCodec
            // 
            this.chVideoCodec.Text = "chVideoCodec";
            this.chVideoCodec.Width = 94;
            // 
            // chVideoAudioBitrate
            // 
            this.chVideoAudioBitrate.Text = "chVideoAudioBitrate";
            // 
            // chVideoAudioSampleRate
            // 
            this.chVideoAudioSampleRate.Text = "chVideoAudioSampleRate";
            // 
            // chVideoAudioCodec
            // 
            this.chVideoAudioCodec.Text = "chVideoAudioCodec";
            // 
            // chVideoAudioChannels
            // 
            this.chVideoAudioChannels.Text = "chVideoAudioChannels";
            // 
            // chVideoFormatId
            // 
            this.chVideoFormatId.Text = "chVideoFormatId";
            this.chVideoFormatId.Width = 38;
            // 
            // tabAudioFormats
            // 
            this.tabAudioFormats.Controls.Add(this.lbExtendedDownloaderNoAudioFormatsAvailable);
            this.tabAudioFormats.Controls.Add(this.lvAudioFormats);
            this.tabAudioFormats.Location = new System.Drawing.Point(4, 22);
            this.tabAudioFormats.Name = "tabAudioFormats";
            this.tabAudioFormats.Padding = new System.Windows.Forms.Padding(3);
            this.tabAudioFormats.Size = new System.Drawing.Size(428, 141);
            this.tabAudioFormats.TabIndex = 1;
            this.tabAudioFormats.Text = "tabAudioFormats";
            this.tabAudioFormats.UseVisualStyleBackColor = true;
            // 
            // lbExtendedDownloaderNoAudioFormatsAvailable
            // 
            this.lbExtendedDownloaderNoAudioFormatsAvailable.AutoSize = true;
            this.lbExtendedDownloaderNoAudioFormatsAvailable.Location = new System.Drawing.Point(11, 35);
            this.lbExtendedDownloaderNoAudioFormatsAvailable.Name = "lbExtendedDownloaderNoAudioFormatsAvailable";
            this.lbExtendedDownloaderNoAudioFormatsAvailable.Size = new System.Drawing.Size(262, 13);
            this.lbExtendedDownloaderNoAudioFormatsAvailable.TabIndex = 15;
            this.lbExtendedDownloaderNoAudioFormatsAvailable.Text = "lbExtendedDownloaderNoAudioFormatsAvailable";
            this.lbExtendedDownloaderNoAudioFormatsAvailable.Visible = false;
            // 
            // lvAudioFormats
            // 
            this.lvAudioFormats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAudioBitrate,
            this.chAudioContainer,
            this.chAudioFileSize,
            this.chAudioSampleRate,
            this.chAudioCodec,
            this.chAudioChannels,
            this.chAudioFormatId});
            this.lvAudioFormats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAudioFormats.Enabled = false;
            this.lvAudioFormats.FullRowSelect = true;
            this.lvAudioFormats.HideSelection = false;
            this.lvAudioFormats.Location = new System.Drawing.Point(3, 3);
            this.lvAudioFormats.MultiSelect = false;
            this.lvAudioFormats.Name = "lvAudioFormats";
            this.lvAudioFormats.Size = new System.Drawing.Size(422, 135);
            this.lvAudioFormats.TabIndex = 14;
            this.lvAudioFormats.UseCompatibleStateImageBehavior = false;
            this.lvAudioFormats.View = System.Windows.Forms.View.Details;
            // 
            // chAudioBitrate
            // 
            this.chAudioBitrate.Text = "chAudioBitrate";
            this.chAudioBitrate.Width = 74;
            // 
            // chAudioContainer
            // 
            this.chAudioContainer.Text = "chAudioContainer";
            this.chAudioContainer.Width = 70;
            // 
            // chAudioFileSize
            // 
            this.chAudioFileSize.Text = "chAudioFileSize";
            this.chAudioFileSize.Width = 76;
            // 
            // chAudioSampleRate
            // 
            this.chAudioSampleRate.Text = "chAudioSampleRate";
            this.chAudioSampleRate.Width = 86;
            // 
            // chAudioCodec
            // 
            this.chAudioCodec.Text = "chAudioCodec";
            this.chAudioCodec.Width = 109;
            // 
            // chAudioChannels
            // 
            this.chAudioChannels.Text = "chAudioChannels";
            // 
            // chAudioFormatId
            // 
            this.chAudioFormatId.Text = "chAudioFormatId";
            this.chAudioFormatId.Width = 35;
            // 
            // tabExtendedDownloaderUnknownFormats
            // 
            this.tabExtendedDownloaderUnknownFormats.Controls.Add(this.lbExtendedDownloaderNoUnknownFormatsFound);
            this.tabExtendedDownloaderUnknownFormats.Controls.Add(this.lvUnknownFormats);
            this.tabExtendedDownloaderUnknownFormats.Location = new System.Drawing.Point(4, 22);
            this.tabExtendedDownloaderUnknownFormats.Name = "tabExtendedDownloaderUnknownFormats";
            this.tabExtendedDownloaderUnknownFormats.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtendedDownloaderUnknownFormats.Size = new System.Drawing.Size(428, 141);
            this.tabExtendedDownloaderUnknownFormats.TabIndex = 4;
            this.tabExtendedDownloaderUnknownFormats.Text = "tabExtendedDownloaderUnknownFormats";
            this.tabExtendedDownloaderUnknownFormats.UseVisualStyleBackColor = true;
            // 
            // lbExtendedDownloaderNoUnknownFormatsFound
            // 
            this.lbExtendedDownloaderNoUnknownFormatsFound.AutoSize = true;
            this.lbExtendedDownloaderNoUnknownFormatsFound.Location = new System.Drawing.Point(11, 35);
            this.lbExtendedDownloaderNoUnknownFormatsFound.Name = "lbExtendedDownloaderNoUnknownFormatsFound";
            this.lbExtendedDownloaderNoUnknownFormatsFound.Size = new System.Drawing.Size(270, 13);
            this.lbExtendedDownloaderNoUnknownFormatsFound.TabIndex = 16;
            this.lbExtendedDownloaderNoUnknownFormatsFound.Text = "lbExtendedDownloaderNoUnknownFormatsFound";
            this.lbExtendedDownloaderNoUnknownFormatsFound.Visible = false;
            // 
            // lvUnknownFormats
            // 
            this.lvUnknownFormats.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chUnknownQuality,
            this.chUnknownFPS,
            this.chUnknownContainer,
            this.chUnknownFileSize,
            this.chUnknownVideoBitrate,
            this.chUnknownDimensions,
            this.chUnknownVideoCodec,
            this.chUnknownAudioBitrate,
            this.chUnknownAudioSampleRate,
            this.chUnknownAudioCodec,
            this.chUnknownAudioChannels,
            this.chUnknownFormatId});
            this.lvUnknownFormats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvUnknownFormats.Enabled = false;
            this.lvUnknownFormats.FullRowSelect = true;
            this.lvUnknownFormats.HideSelection = false;
            this.lvUnknownFormats.Location = new System.Drawing.Point(3, 3);
            this.lvUnknownFormats.MultiSelect = false;
            this.lvUnknownFormats.Name = "lvUnknownFormats";
            this.lvUnknownFormats.Size = new System.Drawing.Size(422, 135);
            this.lvUnknownFormats.TabIndex = 15;
            this.lvUnknownFormats.UseCompatibleStateImageBehavior = false;
            this.lvUnknownFormats.View = System.Windows.Forms.View.Details;
            // 
            // chUnknownQuality
            // 
            this.chUnknownQuality.Text = "chUnknownQuality";
            this.chUnknownQuality.Width = 69;
            // 
            // chUnknownFPS
            // 
            this.chUnknownFPS.Text = "chUnknownFPS";
            this.chUnknownFPS.Width = 31;
            // 
            // chUnknownContainer
            // 
            this.chUnknownContainer.Text = "chUnknownContainer";
            this.chUnknownContainer.Width = 65;
            // 
            // chUnknownFileSize
            // 
            this.chUnknownFileSize.Text = "chUnknownFileSize";
            // 
            // chUnknownVideoBitrate
            // 
            this.chUnknownVideoBitrate.Text = "chUnknownVideoBitrate";
            this.chUnknownVideoBitrate.Width = 67;
            // 
            // chUnknownDimensions
            // 
            this.chUnknownDimensions.Text = "chUnknownDimensions";
            this.chUnknownDimensions.Width = 85;
            // 
            // chUnknownVideoCodec
            // 
            this.chUnknownVideoCodec.Text = "chUnknownVideoCodec";
            this.chUnknownVideoCodec.Width = 94;
            // 
            // chUnknownAudioBitrate
            // 
            this.chUnknownAudioBitrate.Text = "chUnknownAudioBitrate";
            // 
            // chUnknownAudioSampleRate
            // 
            this.chUnknownAudioSampleRate.Text = "chUnknownAudioSampleRate";
            // 
            // chUnknownAudioCodec
            // 
            this.chUnknownAudioCodec.Text = "chUnknownAudioCodec";
            // 
            // chUnknownAudioChannels
            // 
            this.chUnknownAudioChannels.Text = "chUnknownAudioChannels";
            // 
            // chUnknownFormatId
            // 
            this.chUnknownFormatId.Text = "chUnknownFormatId";
            this.chUnknownFormatId.Width = 38;
            // 
            // tabCustom
            // 
            this.tabCustom.Controls.Add(this.txtCustomArguments);
            this.tabCustom.Location = new System.Drawing.Point(4, 22);
            this.tabCustom.Name = "tabCustom";
            this.tabCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustom.Size = new System.Drawing.Size(428, 141);
            this.tabCustom.TabIndex = 3;
            this.tabCustom.Text = "tabCustom";
            this.tabCustom.UseVisualStyleBackColor = true;
            // 
            // txtCustomArguments
            // 
            this.txtCustomArguments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCustomArguments.Location = new System.Drawing.Point(3, 3);
            this.txtCustomArguments.Multiline = true;
            this.txtCustomArguments.Name = "txtCustomArguments";
            this.txtCustomArguments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCustomArguments.Size = new System.Drawing.Size(422, 135);
            this.txtCustomArguments.TabIndex = 15;
            // 
            // tabFormatOptions
            // 
            this.tabFormatOptions.Controls.Add(this.lbVideoRemux);
            this.tabFormatOptions.Controls.Add(this.cbVideoRemux);
            this.tabFormatOptions.Controls.Add(this.chkVideoSeparateAudio);
            this.tabFormatOptions.Controls.Add(this.cbVbrQualities);
            this.tabFormatOptions.Controls.Add(this.chkAudioVBR);
            this.tabFormatOptions.Controls.Add(this.chkVideoDownloadAudio);
            this.tabFormatOptions.Controls.Add(this.lbSchema);
            this.tabFormatOptions.Controls.Add(this.cbSchema);
            this.tabFormatOptions.Controls.Add(this.lbAudioEncoder);
            this.tabFormatOptions.Controls.Add(this.lbVideoEncoder);
            this.tabFormatOptions.Controls.Add(this.cbAudioEncoders);
            this.tabFormatOptions.Controls.Add(this.cbVideoEncoders);
            this.tabFormatOptions.Location = new System.Drawing.Point(4, 22);
            this.tabFormatOptions.Name = "tabFormatOptions";
            this.tabFormatOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabFormatOptions.Size = new System.Drawing.Size(428, 141);
            this.tabFormatOptions.TabIndex = 2;
            this.tabFormatOptions.Text = "tabFormatOptions";
            this.tabFormatOptions.UseVisualStyleBackColor = true;
            // 
            // lbVideoRemux
            // 
            this.lbVideoRemux.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVideoRemux.Location = new System.Drawing.Point(180, 60);
            this.lbVideoRemux.Name = "lbVideoRemux";
            this.lbVideoRemux.Size = new System.Drawing.Size(109, 21);
            this.lbVideoRemux.TabIndex = 31;
            this.lbVideoRemux.Text = "lbVideoRemux";
            this.lbVideoRemux.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbVideoRemux
            // 
            this.cbVideoRemux.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVideoRemux.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoRemux.Enabled = false;
            this.cbVideoRemux.FormattingEnabled = true;
            this.cbVideoRemux.Location = new System.Drawing.Point(295, 60);
            this.cbVideoRemux.Name = "cbVideoRemux";
            this.cbVideoRemux.Size = new System.Drawing.Size(127, 21);
            this.cbVideoRemux.TabIndex = 29;
            // 
            // chkVideoSeparateAudio
            // 
            this.chkVideoSeparateAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkVideoSeparateAudio.AutoSize = true;
            this.chkVideoSeparateAudio.Enabled = false;
            this.chkVideoSeparateAudio.Location = new System.Drawing.Point(6, 118);
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
            this.cbVbrQualities.Location = new System.Drawing.Point(57, 70);
            this.cbVbrQualities.Name = "cbVbrQualities";
            this.cbVbrQualities.Size = new System.Drawing.Size(74, 21);
            this.cbVbrQualities.TabIndex = 27;
            // 
            // chkAudioVBR
            // 
            this.chkAudioVBR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAudioVBR.AutoSize = true;
            this.chkAudioVBR.Enabled = false;
            this.chkAudioVBR.Location = new System.Drawing.Point(6, 72);
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
            this.chkVideoDownloadAudio.Enabled = false;
            this.chkVideoDownloadAudio.Location = new System.Drawing.Point(6, 95);
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
            this.lbSchema.Location = new System.Drawing.Point(140, 8);
            this.lbSchema.Name = "lbSchema";
            this.lbSchema.Size = new System.Drawing.Size(113, 15);
            this.lbSchema.TabIndex = 25;
            this.lbSchema.Text = "lbSchema";
            this.lbSchema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSchema
            // 
            this.cbSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSchema.Enabled = false;
            this.cbSchema.FormattingEnabled = true;
            this.cbSchema.Location = new System.Drawing.Point(255, 6);
            this.cbSchema.Name = "cbSchema";
            this.cbSchema.Size = new System.Drawing.Size(167, 21);
            this.cbSchema.TabIndex = 24;
            this.cbSchema.Text = "%(title)s-%(id)s.%(ext)s";
            // 
            // lbAudioEncoder
            // 
            this.lbAudioEncoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAudioEncoder.Location = new System.Drawing.Point(180, 114);
            this.lbAudioEncoder.Name = "lbAudioEncoder";
            this.lbAudioEncoder.Size = new System.Drawing.Size(109, 21);
            this.lbAudioEncoder.TabIndex = 20;
            this.lbAudioEncoder.Text = "lbAudioEncoder";
            this.lbAudioEncoder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbVideoEncoder
            // 
            this.lbVideoEncoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVideoEncoder.Location = new System.Drawing.Point(180, 87);
            this.lbVideoEncoder.Name = "lbVideoEncoder";
            this.lbVideoEncoder.Size = new System.Drawing.Size(109, 21);
            this.lbVideoEncoder.TabIndex = 19;
            this.lbVideoEncoder.Text = "lbVideoEncoder";
            this.lbVideoEncoder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbAudioEncoders
            // 
            this.cbAudioEncoders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioEncoders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioEncoders.Enabled = false;
            this.cbAudioEncoders.FormattingEnabled = true;
            this.cbAudioEncoders.Location = new System.Drawing.Point(295, 114);
            this.cbAudioEncoders.Name = "cbAudioEncoders";
            this.cbAudioEncoders.Size = new System.Drawing.Size(127, 21);
            this.cbAudioEncoders.TabIndex = 18;
            // 
            // cbVideoEncoders
            // 
            this.cbVideoEncoders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVideoEncoders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoEncoders.Enabled = false;
            this.cbVideoEncoders.FormattingEnabled = true;
            this.cbVideoEncoders.Location = new System.Drawing.Point(295, 87);
            this.cbVideoEncoders.Name = "cbVideoEncoders";
            this.cbVideoEncoders.Size = new System.Drawing.Size(127, 21);
            this.cbVideoEncoders.TabIndex = 16;
            // 
            // tabExtendedDownloaderDescription
            // 
            this.tabExtendedDownloaderDescription.Controls.Add(this.rtbMediaDescription);
            this.tabExtendedDownloaderDescription.Location = new System.Drawing.Point(4, 22);
            this.tabExtendedDownloaderDescription.Name = "tabExtendedDownloaderDescription";
            this.tabExtendedDownloaderDescription.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtendedDownloaderDescription.Size = new System.Drawing.Size(442, 173);
            this.tabExtendedDownloaderDescription.TabIndex = 1;
            this.tabExtendedDownloaderDescription.Text = "tabExtendedDownloaderDescription";
            this.tabExtendedDownloaderDescription.UseVisualStyleBackColor = true;
            // 
            // rtbMediaDescription
            // 
            this.rtbMediaDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMediaDescription.Location = new System.Drawing.Point(3, 3);
            this.rtbMediaDescription.Name = "rtbMediaDescription";
            this.rtbMediaDescription.ReadOnly = true;
            this.rtbMediaDescription.Size = new System.Drawing.Size(436, 167);
            this.rtbMediaDescription.TabIndex = 2;
            this.rtbMediaDescription.Text = "";
            // 
            // tabExtendedDownloaderVerbose
            // 
            this.tabExtendedDownloaderVerbose.Controls.Add(this.btnClearOutput);
            this.tabExtendedDownloaderVerbose.Controls.Add(this.txtGeneratedArguments);
            this.tabExtendedDownloaderVerbose.Controls.Add(this.rtbVerbose);
            this.tabExtendedDownloaderVerbose.Location = new System.Drawing.Point(4, 22);
            this.tabExtendedDownloaderVerbose.Name = "tabExtendedDownloaderVerbose";
            this.tabExtendedDownloaderVerbose.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtendedDownloaderVerbose.Size = new System.Drawing.Size(442, 173);
            this.tabExtendedDownloaderVerbose.TabIndex = 3;
            this.tabExtendedDownloaderVerbose.Text = "tabExtendedDownloaderVerbose";
            this.tabExtendedDownloaderVerbose.UseVisualStyleBackColor = true;
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearOutput.Location = new System.Drawing.Point(361, 144);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(75, 23);
            this.btnClearOutput.TabIndex = 8;
            this.btnClearOutput.Text = "btnClearOutput";
            this.btnClearOutput.UseVisualStyleBackColor = true;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // txtGeneratedArguments
            // 
            this.txtGeneratedArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeneratedArguments.Location = new System.Drawing.Point(6, 145);
            this.txtGeneratedArguments.Name = "txtGeneratedArguments";
            this.txtGeneratedArguments.ReadOnly = true;
            this.txtGeneratedArguments.Size = new System.Drawing.Size(349, 22);
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
            this.rtbVerbose.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbVerbose.Size = new System.Drawing.Size(436, 138);
            this.rtbVerbose.TabIndex = 0;
            this.rtbVerbose.Text = "";
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.btnKill);
            this.tabDebug.Controls.Add(this.chkPbTaskbar);
            this.tabDebug.Controls.Add(this.btnPbRemove);
            this.tabDebug.Controls.Add(this.btnPbAdd);
            this.tabDebug.Controls.Add(this.btnCreateArgs);
            this.tabDebug.Location = new System.Drawing.Point(4, 22);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabDebug.Size = new System.Drawing.Size(442, 173);
            this.tabDebug.TabIndex = 2;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
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
            this.chkPbTaskbar.Location = new System.Drawing.Point(79, 148);
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
            this.btnPbRemove.Location = new System.Drawing.Point(43, 144);
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
            this.btnPbAdd.Location = new System.Drawing.Point(7, 144);
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
            this.rbVideo.Enabled = false;
            this.rbVideo.Location = new System.Drawing.Point(12, 226);
            this.rbVideo.Name = "rbVideo";
            this.rbVideo.Size = new System.Drawing.Size(100, 23);
            this.rbVideo.TabIndex = 10;
            this.rbVideo.Text = "rbVideo";
            this.rbVideo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbVideo.UseVisualStyleBackColor = true;
            this.rbVideo.CheckedChanged += new System.EventHandler(this.rbVideo_CheckedChanged);
            // 
            // rbAudio
            // 
            this.rbAudio.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbAudio.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbAudio.Enabled = false;
            this.rbAudio.Location = new System.Drawing.Point(128, 226);
            this.rbAudio.Name = "rbAudio";
            this.rbAudio.Size = new System.Drawing.Size(100, 23);
            this.rbAudio.TabIndex = 11;
            this.rbAudio.Text = "rbAudio";
            this.rbAudio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbAudio.UseVisualStyleBackColor = true;
            this.rbAudio.CheckedChanged += new System.EventHandler(this.rbAudio_CheckedChanged);
            // 
            // rbCustom
            // 
            this.rbCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCustom.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbCustom.Enabled = false;
            this.rbCustom.Location = new System.Drawing.Point(362, 226);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(100, 23);
            this.rbCustom.TabIndex = 12;
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
            this.chkDownloaderCloseAfterDownload.Location = new System.Drawing.Point(338, 12);
            this.chkDownloaderCloseAfterDownload.Name = "chkDownloaderCloseAfterDownload";
            this.chkDownloaderCloseAfterDownload.Size = new System.Drawing.Size(214, 17);
            this.chkDownloaderCloseAfterDownload.TabIndex = 21;
            this.chkDownloaderCloseAfterDownload.Text = "chkDownloaderCloseAfterDownload";
            this.chkDownloaderCloseAfterDownload.UseVisualStyleBackColor = true;
            // 
            // txtLink
            // 
            this.txtLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLink.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLink.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLink.Location = new System.Drawing.Point(338, 70);
            this.txtLink.Name = "txtLink";
            this.txtLink.ReadOnly = true;
            this.txtLink.Size = new System.Drawing.Size(126, 22);
            this.txtLink.TabIndex = 23;
            // 
            // lbExtendedDownloaderLink
            // 
            this.lbExtendedDownloaderLink.AutoSize = true;
            this.lbExtendedDownloaderLink.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExtendedDownloaderLink.Location = new System.Drawing.Point(335, 58);
            this.lbExtendedDownloaderLink.Name = "lbExtendedDownloaderLink";
            this.lbExtendedDownloaderLink.Size = new System.Drawing.Size(135, 13);
            this.lbExtendedDownloaderLink.TabIndex = 22;
            this.lbExtendedDownloaderLink.Text = "lbExtendedDownloaderLink";
            // 
            // pbThumbnailBackground
            // 
            this.pbThumbnailBackground.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pbThumbnailBackground.Location = new System.Drawing.Point(11, 11);
            this.pbThumbnailBackground.Name = "pbThumbnailBackground";
            this.pbThumbnailBackground.Size = new System.Drawing.Size(322, 182);
            this.pbThumbnailBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThumbnailBackground.TabIndex = 24;
            this.pbThumbnailBackground.TabStop = false;
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
            // rbUnknownFormat
            // 
            this.rbUnknownFormat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbUnknownFormat.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbUnknownFormat.Enabled = false;
            this.rbUnknownFormat.Location = new System.Drawing.Point(246, 226);
            this.rbUnknownFormat.Name = "rbUnknownFormat";
            this.rbUnknownFormat.Size = new System.Drawing.Size(100, 23);
            this.rbUnknownFormat.TabIndex = 25;
            this.rbUnknownFormat.Text = "rbUnknownFormat";
            this.rbUnknownFormat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbUnknownFormat.UseVisualStyleBackColor = true;
            this.rbUnknownFormat.CheckedChanged += new System.EventHandler(this.rbUnknownFormat_CheckedChanged);
            // 
            // frmExtendedDownloader
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
            this.Controls.Add(this.txtExtendedDownloaderMediaTitle);
            this.Controls.Add(this.pbThumbnail);
            this.Controls.Add(this.pbThumbnailBackground);
            this.Controls.Add(this.rbUnknownFormat);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(490, 530);
            this.Name = "frmExtendedDownloader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExtendedDownload";
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).EndInit();
            this.tcVideoData.ResumeLayout(false);
            this.tabExtendedDownloaderFormats.ResumeLayout(false);
            this.tcFormats.ResumeLayout(false);
            this.tabVideoFormats.ResumeLayout(false);
            this.tabVideoFormats.PerformLayout();
            this.tabAudioFormats.ResumeLayout(false);
            this.tabAudioFormats.PerformLayout();
            this.tabExtendedDownloaderUnknownFormats.ResumeLayout(false);
            this.tabExtendedDownloaderUnknownFormats.PerformLayout();
            this.tabCustom.ResumeLayout(false);
            this.tabCustom.PerformLayout();
            this.tabFormatOptions.ResumeLayout(false);
            this.tabFormatOptions.PerformLayout();
            this.tabExtendedDownloaderDescription.ResumeLayout(false);
            this.tabExtendedDownloaderVerbose.ResumeLayout(false);
            this.tabExtendedDownloaderVerbose.PerformLayout();
            this.tabDebug.ResumeLayout(false);
            this.tabDebug.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnailBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbThumbnail;
        private murrty.controls.ExtendedRichTextBox rtbMediaDescription;
        private System.Windows.Forms.TextBox txtExtendedDownloaderMediaTitle;
        private System.Windows.Forms.Label lbExtendedDownloaderUploader;
        private System.Windows.Forms.TextBox txtUploader;
        private System.Windows.Forms.Label lbExtendedDownloaderDownloadingThumbnail;
        private System.Windows.Forms.Button btnExtendedDownloaderDownloadThumbnail;
        private System.Windows.Forms.Label lbTimestamp;
        private System.Windows.Forms.TextBox txtViews;
        private System.Windows.Forms.Label lbExtendedDownloaderViews;
        private System.Windows.Forms.TabControl tcVideoData;
        private System.Windows.Forms.TabPage tabExtendedDownloaderFormats;
        private murrty.controls.ExtendedListView lvVideoFormats;
        private System.Windows.Forms.ColumnHeader chVideoDimension;
        private System.Windows.Forms.ColumnHeader chVideoBitrate;
        private System.Windows.Forms.ColumnHeader chVideoContainer;
        private System.Windows.Forms.ColumnHeader chVideoQuality;
        private System.Windows.Forms.ColumnHeader chVideoFPS;
        private System.Windows.Forms.ColumnHeader chVideoCodec;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rbAudio;
        private System.Windows.Forms.RadioButton rbVideo;
        private System.Windows.Forms.TabPage tabExtendedDownloaderDescription;
        private murrty.controls.ExtendedListView lvAudioFormats;
        private System.Windows.Forms.ColumnHeader chAudioBitrate;
        private System.Windows.Forms.ColumnHeader chAudioSampleRate;
        private System.Windows.Forms.ColumnHeader chAudioContainer;
        private System.Windows.Forms.ColumnHeader chAudioCodec;
        private System.Windows.Forms.TextBox txtCustomArguments;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.Button btnCreateArgs;
        private System.Windows.Forms.ColumnHeader chVideoFileSize;
        private System.Windows.Forms.ColumnHeader chAudioFileSize;
        private System.Windows.Forms.ComboBox cbVideoEncoders;
        private System.Windows.Forms.ComboBox cbAudioEncoders;
        private System.Windows.Forms.CheckBox chkVideoDownloadAudio;
        private System.Windows.Forms.TabControl tcFormats;
        private System.Windows.Forms.TabPage tabVideoFormats;
        private System.Windows.Forms.TabPage tabAudioFormats;
        private System.Windows.Forms.TabPage tabFormatOptions;
        private System.Windows.Forms.Label lbAudioEncoder;
        private System.Windows.Forms.Label lbVideoEncoder;
        private System.Windows.Forms.Button btnDownloadAbortClose;
        private System.Windows.Forms.Button btnDownloadWithAuthentication;
        private murrty.controls.ExtendedProgressBar pbStatus;
        private System.Windows.Forms.CheckBox chkPbTaskbar;
        private System.Windows.Forms.Button btnPbRemove;
        private System.Windows.Forms.Button btnPbAdd;
        private System.Windows.Forms.TabPage tabExtendedDownloaderVerbose;
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
        private System.Windows.Forms.Label lbExtendedDownloaderNoVideoFormatsAvailable;
        private System.Windows.Forms.Label lbExtendedDownloaderNoAudioFormatsAvailable;
        private System.Windows.Forms.Label lbVideoRemux;
        private System.Windows.Forms.ComboBox cbVideoRemux;
        private System.Windows.Forms.ColumnHeader chVideoAudioSampleRate;
        private System.Windows.Forms.ColumnHeader chVideoAudioCodec;
        private System.Windows.Forms.ColumnHeader chVideoAudioBitrate;
        private System.Windows.Forms.PictureBox pbThumbnailBackground;
        private System.Windows.Forms.TabPage tabExtendedDownloaderUnknownFormats;
        private System.Windows.Forms.RadioButton rbUnknownFormat;
        private System.Windows.Forms.Label lbExtendedDownloaderNoUnknownFormatsFound;
        private murrty.controls.ExtendedListView lvUnknownFormats;
        private System.Windows.Forms.ColumnHeader chUnknownQuality;
        private System.Windows.Forms.ColumnHeader chUnknownFPS;
        private System.Windows.Forms.ColumnHeader chUnknownContainer;
        private System.Windows.Forms.ColumnHeader chUnknownFileSize;
        private System.Windows.Forms.ColumnHeader chUnknownVideoBitrate;
        private System.Windows.Forms.ColumnHeader chUnknownDimensions;
        private System.Windows.Forms.ColumnHeader chUnknownVideoCodec;
        private System.Windows.Forms.ColumnHeader chUnknownAudioBitrate;
        private System.Windows.Forms.ColumnHeader chUnknownAudioSampleRate;
        private System.Windows.Forms.ColumnHeader chUnknownAudioCodec;
        private System.Windows.Forms.ColumnHeader chUnknownFormatId;
        private System.Windows.Forms.ColumnHeader chVideoAudioChannels;
        private System.Windows.Forms.ColumnHeader chAudioChannels;
        private System.Windows.Forms.ColumnHeader chUnknownAudioChannels;
        private System.Windows.Forms.Button btnClearOutput;
    }
}