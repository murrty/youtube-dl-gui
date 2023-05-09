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
            murrty.controls.Time time1 = new murrty.controls.Time();
            murrty.controls.Time time2 = new murrty.controls.Time();
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
            this.tabExtendedDownloaderVideoFormats = new System.Windows.Forms.TabPage();
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
            this.tabExtendedDownloaderAudioFormats = new System.Windows.Forms.TabPage();
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
            this.tabExtendedDownloaderCustom = new System.Windows.Forms.TabPage();
            this.txtCustomArguments = new System.Windows.Forms.TextBox();
            this.tabExtendedDownloaderFormatOptions = new System.Windows.Forms.TabPage();
            this.tpStartTime = new murrty.controls.TimePicker();
            this.lbExtendedTimePicker = new System.Windows.Forms.Label();
            this.tpEndTime = new murrty.controls.TimePicker();
            this.lbFragmentThreads = new System.Windows.Forms.Label();
            this.numFragmentThreads = new System.Windows.Forms.NumericUpDown();
            this.chkAbortOnError = new System.Windows.Forms.CheckBox();
            this.chkSkipUnavailableFragments = new System.Windows.Forms.CheckBox();
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
            this.lbTimePickSeparator = new System.Windows.Forms.Label();
            this.llbSpecifyTimesHint = new murrty.controls.ExtendedLinkLabel();
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
            this.chkDownloaderCloseAfterDownload = new System.Windows.Forms.CheckBox();
            this.pbThumbnailBackground = new System.Windows.Forms.PictureBox();
            this.rbUnknown = new System.Windows.Forms.RadioButton();
            this.cmDownload = new System.Windows.Forms.ContextMenu();
            this.mDownload = new System.Windows.Forms.MenuItem();
            this.mDownloadWithAuthentication = new System.Windows.Forms.MenuItem();
            this.sbtnDownload = new murrty.controls.SplitButton();
            this.pbStatus = new murrty.controls.ExtendedProgressBar();
            this.pnSingleDownload = new System.Windows.Forms.Panel();
            this.llbLink = new murrty.controls.ExtendedLinkLabel();
            this.pnBatchDownload = new System.Windows.Forms.Panel();
            this.btnEnqueue = new murrty.controls.SplitButton();
            this.cmEnqueue = new System.Windows.Forms.ContextMenu();
            this.mEnqueue = new System.Windows.Forms.MenuItem();
            this.mEnqueueCopyOptions = new System.Windows.Forms.MenuItem();
            this.mEnqueueWithAuthentication = new System.Windows.Forms.MenuItem();
            this.mEnqueueCopyAuthentication = new System.Windows.Forms.MenuItem();
            this.lvQueuedMedia = new System.Windows.Forms.ListView();
            this.chBatchURL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBatchTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBatchLength = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBatchUploader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBatchUploadedOn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBatchViews = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtQueueLink = new murrty.controls.ExtendedTextBox();
            this.cmQueuedMedia = new System.Windows.Forms.ContextMenu();
            this.mQueueCopyLink = new System.Windows.Forms.MenuItem();
            this.mQueueViewInBrowser = new System.Windows.Forms.MenuItem();
            this.mQueueSeparator = new System.Windows.Forms.MenuItem();
            this.mQueueRemoveSelected = new System.Windows.Forms.MenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).BeginInit();
            this.tcVideoData.SuspendLayout();
            this.tabExtendedDownloaderFormats.SuspendLayout();
            this.tcFormats.SuspendLayout();
            this.tabExtendedDownloaderVideoFormats.SuspendLayout();
            this.tabExtendedDownloaderAudioFormats.SuspendLayout();
            this.tabExtendedDownloaderUnknownFormats.SuspendLayout();
            this.tabExtendedDownloaderCustom.SuspendLayout();
            this.tabExtendedDownloaderFormatOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFragmentThreads)).BeginInit();
            this.tabExtendedDownloaderDescription.SuspendLayout();
            this.tabExtendedDownloaderVerbose.SuspendLayout();
            this.tabDebug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnailBackground)).BeginInit();
            this.pnSingleDownload.SuspendLayout();
            this.pnBatchDownload.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbThumbnail
            // 
            this.pbThumbnail.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbThumbnail.Location = new System.Drawing.Point(3, 24);
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
            this.txtExtendedDownloaderMediaTitle.Location = new System.Drawing.Point(12, 214);
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
            this.lbExtendedDownloaderUploader.Location = new System.Drawing.Point(327, 118);
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
            this.txtUploader.Location = new System.Drawing.Point(330, 130);
            this.txtUploader.Name = "txtUploader";
            this.txtUploader.ReadOnly = true;
            this.txtUploader.Size = new System.Drawing.Size(204, 22);
            this.txtUploader.TabIndex = 11;
            // 
            // lbExtendedDownloaderDownloadingThumbnail
            // 
            this.lbExtendedDownloaderDownloadingThumbnail.AutoSize = true;
            this.lbExtendedDownloaderDownloadingThumbnail.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lbExtendedDownloaderDownloadingThumbnail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExtendedDownloaderDownloadingThumbnail.Location = new System.Drawing.Point(11, 32);
            this.lbExtendedDownloaderDownloadingThumbnail.Name = "lbExtendedDownloaderDownloadingThumbnail";
            this.lbExtendedDownloaderDownloadingThumbnail.Size = new System.Drawing.Size(281, 17);
            this.lbExtendedDownloaderDownloadingThumbnail.TabIndex = 12;
            this.lbExtendedDownloaderDownloadingThumbnail.Text = "lbExtendedDownloaderDownloadingThumbnail";
            this.lbExtendedDownloaderDownloadingThumbnail.Visible = false;
            // 
            // btnExtendedDownloaderDownloadThumbnail
            // 
            this.btnExtendedDownloaderDownloadThumbnail.BackColor = System.Drawing.Color.Transparent;
            this.btnExtendedDownloaderDownloadThumbnail.Location = new System.Drawing.Point(11, 171);
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
            this.lbTimestamp.Location = new System.Drawing.Point(285, 181);
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
            this.txtViews.Location = new System.Drawing.Point(330, 179);
            this.txtViews.Name = "txtViews";
            this.txtViews.ReadOnly = true;
            this.txtViews.Size = new System.Drawing.Size(204, 22);
            this.txtViews.TabIndex = 16;
            // 
            // lbExtendedDownloaderViews
            // 
            this.lbExtendedDownloaderViews.AutoSize = true;
            this.lbExtendedDownloaderViews.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExtendedDownloaderViews.Location = new System.Drawing.Point(327, 167);
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
            this.tcVideoData.Controls.Add(this.tabExtendedDownloaderFormatOptions);
            this.tcVideoData.Controls.Add(this.tabExtendedDownloaderDescription);
            this.tcVideoData.Controls.Add(this.tabExtendedDownloaderVerbose);
            this.tcVideoData.Controls.Add(this.tabDebug);
            this.tcVideoData.Enabled = false;
            this.tcVideoData.Location = new System.Drawing.Point(12, 271);
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
            this.tcFormats.Controls.Add(this.tabExtendedDownloaderVideoFormats);
            this.tcFormats.Controls.Add(this.tabExtendedDownloaderAudioFormats);
            this.tcFormats.Controls.Add(this.tabExtendedDownloaderUnknownFormats);
            this.tcFormats.Controls.Add(this.tabExtendedDownloaderCustom);
            this.tcFormats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcFormats.Location = new System.Drawing.Point(3, 3);
            this.tcFormats.Name = "tcFormats";
            this.tcFormats.SelectedIndex = 0;
            this.tcFormats.Size = new System.Drawing.Size(436, 167);
            this.tcFormats.TabIndex = 0;
            // 
            // tabExtendedDownloaderVideoFormats
            // 
            this.tabExtendedDownloaderVideoFormats.Controls.Add(this.lbExtendedDownloaderNoVideoFormatsAvailable);
            this.tabExtendedDownloaderVideoFormats.Controls.Add(this.lvVideoFormats);
            this.tabExtendedDownloaderVideoFormats.Location = new System.Drawing.Point(4, 22);
            this.tabExtendedDownloaderVideoFormats.Name = "tabExtendedDownloaderVideoFormats";
            this.tabExtendedDownloaderVideoFormats.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtendedDownloaderVideoFormats.Size = new System.Drawing.Size(428, 141);
            this.tabExtendedDownloaderVideoFormats.TabIndex = 0;
            this.tabExtendedDownloaderVideoFormats.Text = "tabExtendedDownloaderVideoFormats";
            this.tabExtendedDownloaderVideoFormats.UseVisualStyleBackColor = true;
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
            this.lvVideoFormats.SelectedIndexChanged += new System.EventHandler(this.lvVideoFormats_SelectedIndexChanged);
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
            // tabExtendedDownloaderAudioFormats
            // 
            this.tabExtendedDownloaderAudioFormats.Controls.Add(this.lbExtendedDownloaderNoAudioFormatsAvailable);
            this.tabExtendedDownloaderAudioFormats.Controls.Add(this.lvAudioFormats);
            this.tabExtendedDownloaderAudioFormats.Location = new System.Drawing.Point(4, 22);
            this.tabExtendedDownloaderAudioFormats.Name = "tabExtendedDownloaderAudioFormats";
            this.tabExtendedDownloaderAudioFormats.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtendedDownloaderAudioFormats.Size = new System.Drawing.Size(428, 141);
            this.tabExtendedDownloaderAudioFormats.TabIndex = 1;
            this.tabExtendedDownloaderAudioFormats.Text = "tabExtendedDownloaderAudioFormats";
            this.tabExtendedDownloaderAudioFormats.UseVisualStyleBackColor = true;
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
            this.lvAudioFormats.SelectedIndexChanged += new System.EventHandler(this.lvAudioFormats_SelectedIndexChanged);
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
            this.lvUnknownFormats.SelectedIndexChanged += new System.EventHandler(this.lvUnknownFormats_SelectedIndexChanged);
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
            // tabExtendedDownloaderCustom
            // 
            this.tabExtendedDownloaderCustom.Controls.Add(this.txtCustomArguments);
            this.tabExtendedDownloaderCustom.Location = new System.Drawing.Point(4, 22);
            this.tabExtendedDownloaderCustom.Name = "tabExtendedDownloaderCustom";
            this.tabExtendedDownloaderCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtendedDownloaderCustom.Size = new System.Drawing.Size(428, 141);
            this.tabExtendedDownloaderCustom.TabIndex = 3;
            this.tabExtendedDownloaderCustom.Text = "tabExtendedDownloaderCustom";
            this.tabExtendedDownloaderCustom.UseVisualStyleBackColor = true;
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
            this.txtCustomArguments.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomArguments_KeyDown);
            // 
            // tabExtendedDownloaderFormatOptions
            // 
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.tpStartTime);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.lbExtendedTimePicker);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.tpEndTime);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.lbFragmentThreads);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.numFragmentThreads);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.chkAbortOnError);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.chkSkipUnavailableFragments);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.lbVideoRemux);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.cbVideoRemux);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.chkVideoSeparateAudio);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.cbVbrQualities);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.chkAudioVBR);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.chkVideoDownloadAudio);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.lbSchema);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.cbSchema);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.lbAudioEncoder);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.lbVideoEncoder);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.cbAudioEncoders);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.cbVideoEncoders);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.lbTimePickSeparator);
            this.tabExtendedDownloaderFormatOptions.Controls.Add(this.llbSpecifyTimesHint);
            this.tabExtendedDownloaderFormatOptions.Location = new System.Drawing.Point(4, 22);
            this.tabExtendedDownloaderFormatOptions.Name = "tabExtendedDownloaderFormatOptions";
            this.tabExtendedDownloaderFormatOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtendedDownloaderFormatOptions.Size = new System.Drawing.Size(442, 173);
            this.tabExtendedDownloaderFormatOptions.TabIndex = 2;
            this.tabExtendedDownloaderFormatOptions.Text = "tabExtendedDownloaderFormatOptions";
            this.tabExtendedDownloaderFormatOptions.UseVisualStyleBackColor = true;
            // 
            // tpStartTime
            // 
            this.tpStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tpStartTime.Location = new System.Drawing.Point(8, 50);
            this.tpStartTime.Name = "tpStartTime";
            this.tpStartTime.Size = new System.Drawing.Size(96, 23);
            this.tpStartTime.TabIndex = 41;
            this.tpStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tpStartTime.TimeValue = time1;
            this.tpStartTime.Value = System.TimeSpan.Parse("00:00:00");
            // 
            // lbExtendedTimePicker
            // 
            this.lbExtendedTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbExtendedTimePicker.AutoSize = true;
            this.lbExtendedTimePicker.Location = new System.Drawing.Point(6, 34);
            this.lbExtendedTimePicker.Name = "lbExtendedTimePicker";
            this.lbExtendedTimePicker.Size = new System.Drawing.Size(148, 13);
            this.lbExtendedTimePicker.TabIndex = 39;
            this.lbExtendedTimePicker.Text = "Specific times (hh:mm:ss.fff)";
            // 
            // tpEndTime
            // 
            this.tpEndTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tpEndTime.DateBasedTime = false;
            this.tpEndTime.Location = new System.Drawing.Point(117, 50);
            this.tpEndTime.Name = "tpEndTime";
            this.tpEndTime.Size = new System.Drawing.Size(96, 23);
            this.tpEndTime.TabIndex = 37;
            this.tpEndTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tpEndTime.TimeValue = time2;
            this.tpEndTime.Value = System.TimeSpan.Parse("00:00:00");
            // 
            // lbFragmentThreads
            // 
            this.lbFragmentThreads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFragmentThreads.Location = new System.Drawing.Point(248, 34);
            this.lbFragmentThreads.Name = "lbFragmentThreads";
            this.lbFragmentThreads.Size = new System.Drawing.Size(128, 20);
            this.lbFragmentThreads.TabIndex = 35;
            this.lbFragmentThreads.Text = "lbFragmentThreads";
            this.lbFragmentThreads.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numFragmentThreads
            // 
            this.numFragmentThreads.Location = new System.Drawing.Point(382, 35);
            this.numFragmentThreads.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numFragmentThreads.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFragmentThreads.Name = "numFragmentThreads";
            this.numFragmentThreads.Size = new System.Drawing.Size(52, 22);
            this.numFragmentThreads.TabIndex = 34;
            this.numFragmentThreads.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkAbortOnError
            // 
            this.chkAbortOnError.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkAbortOnError.AutoSize = true;
            this.chkAbortOnError.Checked = true;
            this.chkAbortOnError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAbortOnError.Location = new System.Drawing.Point(8, 102);
            this.chkAbortOnError.Name = "chkAbortOnError";
            this.chkAbortOnError.Size = new System.Drawing.Size(113, 17);
            this.chkAbortOnError.TabIndex = 33;
            this.chkAbortOnError.Text = "chkAbortOnError";
            this.chkAbortOnError.UseVisualStyleBackColor = true;
            // 
            // chkSkipUnavailableFragments
            // 
            this.chkSkipUnavailableFragments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSkipUnavailableFragments.AutoSize = true;
            this.chkSkipUnavailableFragments.Location = new System.Drawing.Point(8, 79);
            this.chkSkipUnavailableFragments.Name = "chkSkipUnavailableFragments";
            this.chkSkipUnavailableFragments.Size = new System.Drawing.Size(179, 17);
            this.chkSkipUnavailableFragments.TabIndex = 32;
            this.chkSkipUnavailableFragments.Text = "chkSkipUnavailableFragments";
            this.chkSkipUnavailableFragments.UseVisualStyleBackColor = true;
            // 
            // lbVideoRemux
            // 
            this.lbVideoRemux.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVideoRemux.Location = new System.Drawing.Point(173, 90);
            this.lbVideoRemux.Name = "lbVideoRemux";
            this.lbVideoRemux.Size = new System.Drawing.Size(128, 21);
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
            this.cbVideoRemux.Location = new System.Drawing.Point(307, 90);
            this.cbVideoRemux.Name = "cbVideoRemux";
            this.cbVideoRemux.Size = new System.Drawing.Size(127, 21);
            this.cbVideoRemux.TabIndex = 29;
            // 
            // chkVideoSeparateAudio
            // 
            this.chkVideoSeparateAudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkVideoSeparateAudio.AutoSize = true;
            this.chkVideoSeparateAudio.Enabled = false;
            this.chkVideoSeparateAudio.Location = new System.Drawing.Point(8, 148);
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
            this.cbVbrQualities.Location = new System.Drawing.Point(360, 63);
            this.cbVbrQualities.Name = "cbVbrQualities";
            this.cbVbrQualities.Size = new System.Drawing.Size(74, 21);
            this.cbVbrQualities.TabIndex = 27;
            // 
            // chkAudioVBR
            // 
            this.chkAudioVBR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAudioVBR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAudioVBR.Enabled = false;
            this.chkAudioVBR.Location = new System.Drawing.Point(230, 65);
            this.chkAudioVBR.Name = "chkAudioVBR";
            this.chkAudioVBR.Size = new System.Drawing.Size(124, 17);
            this.chkAudioVBR.TabIndex = 26;
            this.chkAudioVBR.Text = "VBR";
            this.chkAudioVBR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.chkVideoDownloadAudio.Location = new System.Drawing.Point(8, 125);
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
            this.lbSchema.Location = new System.Drawing.Point(145, 10);
            this.lbSchema.Name = "lbSchema";
            this.lbSchema.Size = new System.Drawing.Size(120, 15);
            this.lbSchema.TabIndex = 25;
            this.lbSchema.Text = "lbSchema";
            this.lbSchema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSchema
            // 
            this.cbSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSchema.Enabled = false;
            this.cbSchema.FormattingEnabled = true;
            this.cbSchema.Location = new System.Drawing.Point(267, 8);
            this.cbSchema.Name = "cbSchema";
            this.cbSchema.Size = new System.Drawing.Size(167, 21);
            this.cbSchema.TabIndex = 24;
            this.cbSchema.Text = "%(title)s-%(id)s.%(ext)s";
            this.cbSchema.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbSchema_KeyPress);
            // 
            // lbAudioEncoder
            // 
            this.lbAudioEncoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAudioEncoder.Location = new System.Drawing.Point(173, 144);
            this.lbAudioEncoder.Name = "lbAudioEncoder";
            this.lbAudioEncoder.Size = new System.Drawing.Size(128, 21);
            this.lbAudioEncoder.TabIndex = 20;
            this.lbAudioEncoder.Text = "lbAudioEncoder";
            this.lbAudioEncoder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbVideoEncoder
            // 
            this.lbVideoEncoder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbVideoEncoder.Location = new System.Drawing.Point(173, 117);
            this.lbVideoEncoder.Name = "lbVideoEncoder";
            this.lbVideoEncoder.Size = new System.Drawing.Size(128, 21);
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
            this.cbAudioEncoders.Location = new System.Drawing.Point(307, 144);
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
            this.cbVideoEncoders.Location = new System.Drawing.Point(307, 117);
            this.cbVideoEncoders.Name = "cbVideoEncoders";
            this.cbVideoEncoders.Size = new System.Drawing.Size(127, 21);
            this.cbVideoEncoders.TabIndex = 16;
            // 
            // lbTimePickSeparator
            // 
            this.lbTimePickSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbTimePickSeparator.AutoSize = true;
            this.lbTimePickSeparator.Location = new System.Drawing.Point(105, 49);
            this.lbTimePickSeparator.Name = "lbTimePickSeparator";
            this.lbTimePickSeparator.Size = new System.Drawing.Size(12, 13);
            this.lbTimePickSeparator.TabIndex = 38;
            this.lbTimePickSeparator.Text = "_";
            // 
            // llbSpecifyTimesHint
            // 
            this.llbSpecifyTimesHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.llbSpecifyTimesHint.AutoSize = true;
            this.llbSpecifyTimesHint.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llbSpecifyTimesHint.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llbSpecifyTimesHint.Location = new System.Drawing.Point(214, 53);
            this.llbSpecifyTimesHint.Name = "llbSpecifyTimesHint";
            this.llbSpecifyTimesHint.Size = new System.Drawing.Size(14, 17);
            this.llbSpecifyTimesHint.TabIndex = 40;
            this.llbSpecifyTimesHint.TabStop = true;
            this.llbSpecifyTimesHint.Text = "?";
            this.llbSpecifyTimesHint.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
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
            this.rbVideo.Location = new System.Drawing.Point(12, 242);
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
            this.rbAudio.Location = new System.Drawing.Point(128, 242);
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
            this.rbCustom.Location = new System.Drawing.Point(362, 242);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(100, 23);
            this.rbCustom.TabIndex = 12;
            this.rbCustom.Text = "rbCustom";
            this.rbCustom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbCustom.UseVisualStyleBackColor = true;
            this.rbCustom.CheckedChanged += new System.EventHandler(this.rbCustom_CheckedChanged);
            // 
            // chkDownloaderCloseAfterDownload
            // 
            this.chkDownloaderCloseAfterDownload.AutoSize = true;
            this.chkDownloaderCloseAfterDownload.Location = new System.Drawing.Point(330, 23);
            this.chkDownloaderCloseAfterDownload.Name = "chkDownloaderCloseAfterDownload";
            this.chkDownloaderCloseAfterDownload.Size = new System.Drawing.Size(214, 17);
            this.chkDownloaderCloseAfterDownload.TabIndex = 21;
            this.chkDownloaderCloseAfterDownload.Text = "chkDownloaderCloseAfterDownload";
            this.chkDownloaderCloseAfterDownload.UseVisualStyleBackColor = true;
            // 
            // pbThumbnailBackground
            // 
            this.pbThumbnailBackground.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pbThumbnailBackground.Location = new System.Drawing.Point(2, 23);
            this.pbThumbnailBackground.Name = "pbThumbnailBackground";
            this.pbThumbnailBackground.Size = new System.Drawing.Size(322, 182);
            this.pbThumbnailBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThumbnailBackground.TabIndex = 24;
            this.pbThumbnailBackground.TabStop = false;
            // 
            // rbUnknown
            // 
            this.rbUnknown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbUnknown.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbUnknown.Enabled = false;
            this.rbUnknown.Location = new System.Drawing.Point(246, 242);
            this.rbUnknown.Name = "rbUnknown";
            this.rbUnknown.Size = new System.Drawing.Size(100, 23);
            this.rbUnknown.TabIndex = 25;
            this.rbUnknown.Text = "rbUnknown";
            this.rbUnknown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbUnknown.UseVisualStyleBackColor = true;
            this.rbUnknown.CheckedChanged += new System.EventHandler(this.rbUnknown_CheckedChanged);
            // 
            // cmDownload
            // 
            this.cmDownload.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mDownload,
            this.mDownloadWithAuthentication});
            // 
            // mDownload
            // 
            this.mDownload.Index = 0;
            this.mDownload.Text = "mDownload";
            this.mDownload.Click += new System.EventHandler(this.mDownload_Click);
            // 
            // mDownloadWithAuthentication
            // 
            this.mDownloadWithAuthentication.Index = 1;
            this.mDownloadWithAuthentication.Text = "mDownloadWithAuthentication";
            this.mDownloadWithAuthentication.Click += new System.EventHandler(this.mDownloadWithAuthentication_Click);
            // 
            // sbtnDownload
            // 
            this.sbtnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sbtnDownload.ContextMenu = this.cmDownload;
            this.sbtnDownload.Enabled = false;
            this.sbtnDownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sbtnDownload.Location = new System.Drawing.Point(362, 476);
            this.sbtnDownload.Name = "sbtnDownload";
            this.sbtnDownload.Size = new System.Drawing.Size(100, 23);
            this.sbtnDownload.TabIndex = 26;
            this.sbtnDownload.Text = "sbtnDownload";
            this.sbtnDownload.UseVisualStyleBackColor = true;
            this.sbtnDownload.Click += new System.EventHandler(this.sbtnDownload_Click);
            // 
            // pbStatus
            // 
            this.pbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbStatus.ContainerParent = this;
            this.pbStatus.FastValueUpdate = true;
            this.pbStatus.Location = new System.Drawing.Point(12, 478);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.ShowText = true;
            this.pbStatus.Size = new System.Drawing.Size(344, 21);
            this.pbStatus.TabIndex = 20;
            this.pbStatus.Text = ".  .  .";
            // 
            // pnSingleDownload
            // 
            this.pnSingleDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnSingleDownload.Controls.Add(this.llbLink);
            this.pnSingleDownload.Controls.Add(this.lbExtendedDownloaderDownloadingThumbnail);
            this.pnSingleDownload.Controls.Add(this.lbExtendedDownloaderViews);
            this.pnSingleDownload.Controls.Add(this.btnExtendedDownloaderDownloadThumbnail);
            this.pnSingleDownload.Controls.Add(this.lbExtendedDownloaderUploader);
            this.pnSingleDownload.Controls.Add(this.lbTimestamp);
            this.pnSingleDownload.Controls.Add(this.txtUploader);
            this.pnSingleDownload.Controls.Add(this.chkDownloaderCloseAfterDownload);
            this.pnSingleDownload.Controls.Add(this.txtViews);
            this.pnSingleDownload.Controls.Add(this.pbThumbnail);
            this.pnSingleDownload.Controls.Add(this.pbThumbnailBackground);
            this.pnSingleDownload.Location = new System.Drawing.Point(4, 4);
            this.pnSingleDownload.Name = "pnSingleDownload";
            this.pnSingleDownload.Size = new System.Drawing.Size(466, 208);
            this.pnSingleDownload.TabIndex = 28;
            // 
            // llbLink
            // 
            this.llbLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.llbLink.AutoEllipsis = true;
            this.llbLink.AutoSize = true;
            this.llbLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.llbLink.Location = new System.Drawing.Point(5, 1);
            this.llbLink.Name = "llbLink";
            this.llbLink.Size = new System.Drawing.Size(54, 13);
            this.llbLink.TabIndex = 25;
            this.llbLink.TabStop = true;
            this.llbLink.Text = "https://...";
            this.llbLink.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            // 
            // pnBatchDownload
            // 
            this.pnBatchDownload.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnBatchDownload.Controls.Add(this.btnEnqueue);
            this.pnBatchDownload.Controls.Add(this.lvQueuedMedia);
            this.pnBatchDownload.Controls.Add(this.txtQueueLink);
            this.pnBatchDownload.Location = new System.Drawing.Point(4, 4);
            this.pnBatchDownload.Name = "pnBatchDownload";
            this.pnBatchDownload.Size = new System.Drawing.Size(466, 208);
            this.pnBatchDownload.TabIndex = 29;
            // 
            // btnEnqueue
            // 
            this.btnEnqueue.ContextMenu = this.cmEnqueue;
            this.btnEnqueue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEnqueue.Location = new System.Drawing.Point(367, 8);
            this.btnEnqueue.Name = "btnEnqueue";
            this.btnEnqueue.Size = new System.Drawing.Size(91, 23);
            this.btnEnqueue.TabIndex = 31;
            this.btnEnqueue.Text = "btnEnqueue";
            this.btnEnqueue.UseVisualStyleBackColor = true;
            this.btnEnqueue.Click += new System.EventHandler(this.btnEnqueue_Click);
            // 
            // cmEnqueue
            // 
            this.cmEnqueue.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mEnqueue,
            this.mEnqueueCopyOptions,
            this.mEnqueueWithAuthentication,
            this.mEnqueueCopyAuthentication});
            // 
            // mEnqueue
            // 
            this.mEnqueue.Index = 0;
            this.mEnqueue.Text = "mEnqueue";
            this.mEnqueue.Click += new System.EventHandler(this.mEnqueue_Click);
            // 
            // mEnqueueCopyOptions
            // 
            this.mEnqueueCopyOptions.Index = 1;
            this.mEnqueueCopyOptions.Text = "mEnqueueCopyOptions";
            this.mEnqueueCopyOptions.Click += new System.EventHandler(this.mEnqueueCopyOptions_Click);
            // 
            // mEnqueueWithAuthentication
            // 
            this.mEnqueueWithAuthentication.Index = 2;
            this.mEnqueueWithAuthentication.Text = "mEnqueueWithAuthentication";
            this.mEnqueueWithAuthentication.Click += new System.EventHandler(this.mEnqueueWithAuthentication_Click);
            // 
            // mEnqueueCopyAuthentication
            // 
            this.mEnqueueCopyAuthentication.Index = 3;
            this.mEnqueueCopyAuthentication.Text = "mEnqueueCopyAuthentication";
            this.mEnqueueCopyAuthentication.Click += new System.EventHandler(this.mEnqueueCopyAuthentication_Click);
            // 
            // lvQueuedMedia
            // 
            this.lvQueuedMedia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvQueuedMedia.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chBatchURL,
            this.chBatchTitle,
            this.chBatchLength,
            this.chBatchUploader,
            this.chBatchUploadedOn,
            this.chBatchViews});
            this.lvQueuedMedia.FullRowSelect = true;
            this.lvQueuedMedia.HideSelection = false;
            this.lvQueuedMedia.Location = new System.Drawing.Point(8, 36);
            this.lvQueuedMedia.MultiSelect = false;
            this.lvQueuedMedia.Name = "lvQueuedMedia";
            this.lvQueuedMedia.Size = new System.Drawing.Size(450, 168);
            this.lvQueuedMedia.TabIndex = 29;
            this.lvQueuedMedia.UseCompatibleStateImageBehavior = false;
            this.lvQueuedMedia.View = System.Windows.Forms.View.Details;
            this.lvQueuedMedia.SelectedIndexChanged += new System.EventHandler(this.lvQueuedMedia_SelectedIndexChanged);
            // 
            // chBatchURL
            // 
            this.chBatchURL.Text = "URL";
            this.chBatchURL.Width = 136;
            // 
            // chBatchTitle
            // 
            this.chBatchTitle.Text = "Title";
            this.chBatchTitle.Width = 169;
            // 
            // chBatchLength
            // 
            this.chBatchLength.Text = "Length";
            this.chBatchLength.Width = 50;
            // 
            // chBatchUploader
            // 
            this.chBatchUploader.Text = "Uploader";
            this.chBatchUploader.Width = 93;
            // 
            // chBatchUploadedOn
            // 
            this.chBatchUploadedOn.Text = "Uploaded on";
            // 
            // chBatchViews
            // 
            this.chBatchViews.Text = "Views";
            // 
            // txtQueueLink
            // 
            this.txtQueueLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQueueLink.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtQueueLink.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtQueueLink.ButtonFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQueueLink.ButtonImageIndex = -1;
            this.txtQueueLink.ButtonSize = new System.Drawing.Size(75, 21);
            this.txtQueueLink.ButtonText = "";
            this.txtQueueLink.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtQueueLink.Location = new System.Drawing.Point(8, 8);
            this.txtQueueLink.Name = "txtQueueLink";
            this.txtQueueLink.Size = new System.Drawing.Size(353, 22);
            this.txtQueueLink.TabIndex = 30;
            // 
            // cmQueuedMedia
            // 
            this.cmQueuedMedia.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mQueueCopyLink,
            this.mQueueViewInBrowser,
            this.mQueueSeparator,
            this.mQueueRemoveSelected});
            // 
            // mQueueCopyLink
            // 
            this.mQueueCopyLink.Index = 0;
            this.mQueueCopyLink.Text = "&Copy link";
            this.mQueueCopyLink.Click += new System.EventHandler(this.mQueueCopyLink_Click);
            // 
            // mQueueViewInBrowser
            // 
            this.mQueueViewInBrowser.Index = 1;
            this.mQueueViewInBrowser.Text = "&View in WebBrowser";
            this.mQueueViewInBrowser.Click += new System.EventHandler(this.mQueueViewInBrowser_Click);
            // 
            // mQueueSeparator
            // 
            this.mQueueSeparator.Index = 2;
            this.mQueueSeparator.Text = "-";
            // 
            // mQueueRemoveSelected
            // 
            this.mQueueRemoveSelected.Index = 3;
            this.mQueueRemoveSelected.Text = "&Remove";
            this.mQueueRemoveSelected.Click += new System.EventHandler(this.mQueueRemoveSelected_Click);
            // 
            // frmExtendedDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 511);
            this.Controls.Add(this.sbtnDownload);
            this.Controls.Add(this.pbStatus);
            this.Controls.Add(this.tcVideoData);
            this.Controls.Add(this.rbCustom);
            this.Controls.Add(this.rbAudio);
            this.Controls.Add(this.rbVideo);
            this.Controls.Add(this.txtExtendedDownloaderMediaTitle);
            this.Controls.Add(this.rbUnknown);
            this.Controls.Add(this.pnBatchDownload);
            this.Controls.Add(this.pnSingleDownload);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(490, 546);
            this.Name = "frmExtendedDownloader";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExtendedDownload";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExtendedDownloader_FormClosing);
            this.Load += new System.EventHandler(this.frmExtendedDownloader_Load);
            this.Shown += new System.EventHandler(this.frmExtendedDownloader_Shown);
            this.SizeChanged += new System.EventHandler(this.frmExtendedDownloader_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).EndInit();
            this.tcVideoData.ResumeLayout(false);
            this.tabExtendedDownloaderFormats.ResumeLayout(false);
            this.tcFormats.ResumeLayout(false);
            this.tabExtendedDownloaderVideoFormats.ResumeLayout(false);
            this.tabExtendedDownloaderVideoFormats.PerformLayout();
            this.tabExtendedDownloaderAudioFormats.ResumeLayout(false);
            this.tabExtendedDownloaderAudioFormats.PerformLayout();
            this.tabExtendedDownloaderUnknownFormats.ResumeLayout(false);
            this.tabExtendedDownloaderUnknownFormats.PerformLayout();
            this.tabExtendedDownloaderCustom.ResumeLayout(false);
            this.tabExtendedDownloaderCustom.PerformLayout();
            this.tabExtendedDownloaderFormatOptions.ResumeLayout(false);
            this.tabExtendedDownloaderFormatOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFragmentThreads)).EndInit();
            this.tabExtendedDownloaderDescription.ResumeLayout(false);
            this.tabExtendedDownloaderVerbose.ResumeLayout(false);
            this.tabExtendedDownloaderVerbose.PerformLayout();
            this.tabDebug.ResumeLayout(false);
            this.tabDebug.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnailBackground)).EndInit();
            this.pnSingleDownload.ResumeLayout(false);
            this.pnSingleDownload.PerformLayout();
            this.pnBatchDownload.ResumeLayout(false);
            this.pnBatchDownload.PerformLayout();
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
        private System.Windows.Forms.TabPage tabExtendedDownloaderVideoFormats;
        private System.Windows.Forms.TabPage tabExtendedDownloaderAudioFormats;
        private System.Windows.Forms.TabPage tabExtendedDownloaderFormatOptions;
        private System.Windows.Forms.Label lbAudioEncoder;
        private System.Windows.Forms.Label lbVideoEncoder;
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
        private System.Windows.Forms.TabPage tabExtendedDownloaderCustom;
        private System.Windows.Forms.CheckBox chkDownloaderCloseAfterDownload;
        private System.Windows.Forms.ColumnHeader chVideoFormatId;
        private System.Windows.Forms.ColumnHeader chAudioFormatId;
        private System.Windows.Forms.Label lbExtendedDownloaderNoVideoFormatsAvailable;
        private System.Windows.Forms.Label lbExtendedDownloaderNoAudioFormatsAvailable;
        private System.Windows.Forms.Label lbVideoRemux;
        private System.Windows.Forms.ComboBox cbVideoRemux;
        private System.Windows.Forms.ColumnHeader chVideoAudioSampleRate;
        private System.Windows.Forms.ColumnHeader chVideoAudioCodec;
        private System.Windows.Forms.ColumnHeader chVideoAudioBitrate;
        private System.Windows.Forms.PictureBox pbThumbnailBackground;
        private System.Windows.Forms.TabPage tabExtendedDownloaderUnknownFormats;
        private System.Windows.Forms.RadioButton rbUnknown;
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
        private murrty.controls.SplitButton sbtnDownload;
        private System.Windows.Forms.ContextMenu cmDownload;
        private System.Windows.Forms.MenuItem mDownload;
        private System.Windows.Forms.MenuItem mDownloadWithAuthentication;
        private System.Windows.Forms.CheckBox chkAbortOnError;
        private System.Windows.Forms.CheckBox chkSkipUnavailableFragments;
        private System.Windows.Forms.Label lbFragmentThreads;
        private System.Windows.Forms.NumericUpDown numFragmentThreads;
        private System.Windows.Forms.Label lbExtendedTimePicker;
        private murrty.controls.TimePicker tpEndTime;
        private System.Windows.Forms.Label lbTimePickSeparator;
        private murrty.controls.ExtendedLinkLabel llbSpecifyTimesHint;
        private murrty.controls.TimePicker tpStartTime;
        private System.Windows.Forms.Panel pnSingleDownload;
        private System.Windows.Forms.Panel pnBatchDownload;
        private murrty.controls.ExtendedLinkLabel llbLink;
        private murrty.controls.SplitButton btnEnqueue;
        private System.Windows.Forms.ListView lvQueuedMedia;
        private System.Windows.Forms.ColumnHeader chBatchURL;
        private System.Windows.Forms.ColumnHeader chBatchTitle;
        private System.Windows.Forms.ColumnHeader chBatchLength;
        private System.Windows.Forms.ColumnHeader chBatchUploader;
        private System.Windows.Forms.ColumnHeader chBatchUploadedOn;
        private System.Windows.Forms.ColumnHeader chBatchViews;
        private murrty.controls.ExtendedTextBox txtQueueLink;
        private System.Windows.Forms.ContextMenu cmQueuedMedia;
        private System.Windows.Forms.MenuItem mQueueRemoveSelected;
        private System.Windows.Forms.MenuItem mQueueViewInBrowser;
        private System.Windows.Forms.ContextMenu cmEnqueue;
        private System.Windows.Forms.MenuItem mEnqueue;
        private System.Windows.Forms.MenuItem mEnqueueWithAuthentication;
        private System.Windows.Forms.MenuItem mEnqueueCopyAuthentication;
        private System.Windows.Forms.MenuItem mQueueCopyLink;
        private System.Windows.Forms.MenuItem mQueueSeparator;
        private System.Windows.Forms.MenuItem mEnqueueCopyOptions;
    }
}