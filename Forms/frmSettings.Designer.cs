namespace youtube_dl_gui {
    partial class frmSettings {
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
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabSettingsGeneral = new System.Windows.Forms.TabPage();
            this.gbSettingsGeneralCustomArguments = new System.Windows.Forms.GroupBox();
            this.rbSettingsGeneralCustomArgumentsSaveInSettings = new System.Windows.Forms.RadioButton();
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText = new System.Windows.Forms.RadioButton();
            this.rbSettingsGeneralCustomArgumentsDontSave = new System.Windows.Forms.RadioButton();
            this.lbSepGeneral = new System.Windows.Forms.Label();
            this.btnSettingsGeneralBrowseFFmpeg = new System.Windows.Forms.Button();
            this.btnSettingsGeneralBrowseYoutubeDl = new System.Windows.Forms.Button();
            this.chkSettingsGeneralUseStaticYoutubeDl = new System.Windows.Forms.CheckBox();
            this.chkSettingsGeneralUseStaticFFmpeg = new System.Windows.Forms.CheckBox();
            this.txtSettingsGeneralFFmpegPath = new System.Windows.Forms.TextBox();
            this.lbSettingsGeneralFFmpegDirectory = new System.Windows.Forms.Label();
            this.txtSettingsGeneralYoutubeDlPath = new System.Windows.Forms.TextBox();
            this.lbSettingsGeneralYoutubeDlPath = new System.Windows.Forms.Label();
            this.chkSettingsGeneralClearUrlClipboardOnDownload = new System.Windows.Forms.CheckBox();
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard = new System.Windows.Forms.CheckBox();
            this.chkSettingsGeneralCheckForUpdatesOnLaunch = new System.Windows.Forms.CheckBox();
            this.tabSettingsDownloads = new System.Windows.Forms.TabPage();
            this.tabDownloads = new System.Windows.Forms.TabControl();
            this.tabDownloadsGeneral = new System.Windows.Forms.TabPage();
            this.chkSettingsDownloadsSaveThumbnails = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsSaveFormatQuality = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsSaveAnnotations = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsSaveDescription = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsDownloadSubtitles = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsSaveVideoInfo = new System.Windows.Forms.CheckBox();
            this.tabDownloadsSorting = new System.Windows.Forms.TabPage();
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl = new System.Windows.Forms.CheckBox();
            this.tabDownloadsFixes = new System.Windows.Forms.TabPage();
            this.chkSettingsDownloadsFixVReddIt = new System.Windows.Forms.CheckBox();
            this.tabDownloadsConnection = new System.Windows.Forms.TabPage();
            this.cbSettingsDownloadsProxyType = new System.Windows.Forms.ComboBox();
            this.chkSettingsDownloadsForceIpv6 = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsForceIpv4 = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsUseProxy = new System.Windows.Forms.CheckBox();
            this.numSettingsDownloadsRetryAttempts = new System.Windows.Forms.NumericUpDown();
            this.lbSettingsDownloadsRetryAttempts = new System.Windows.Forms.Label();
            this.cbSettingsDownloadsLimitDownload = new System.Windows.Forms.ComboBox();
            this.numSettingsDownloadsLimitDownload = new System.Windows.Forms.NumericUpDown();
            this.lbSettingsDownloadsIpPort = new System.Windows.Forms.Label();
            this.chkSettingsDownloadsLimitDownload = new System.Windows.Forms.CheckBox();
            this.tabDownloadsUpdating = new System.Windows.Forms.TabPage();
            this.chksettingsDownloadsUseYoutubeDlsUpdater = new System.Windows.Forms.CheckBox();
            this.llSettingsDownloadsSchemaHelp = new System.Windows.Forms.LinkLabel();
            this.lbSettingsDownloadsDownloadPath = new System.Windows.Forms.Label();
            this.txtSettingsDownloadsSavePath = new System.Windows.Forms.TextBox();
            this.btnSettingsDownloadsBrowseSavePath = new System.Windows.Forms.Button();
            this.txtSettingsDownloadsFileNameSchema = new System.Windows.Forms.TextBox();
            this.lbSepDownloads = new System.Windows.Forms.Label();
            this.lbSettingsDownloadsFileNameSchema = new System.Windows.Forms.Label();
            this.tabSettingsConverter = new System.Windows.Forms.TabPage();
            this.chkSettingsConverterHideFFmpegCompileInfo = new System.Windows.Forms.CheckBox();
            this.chkSettingsConverterDetectOutputFileType = new System.Windows.Forms.CheckBox();
            this.tcConverter = new System.Windows.Forms.TabControl();
            this.tcSettingsConverterVideo = new System.Windows.Forms.TabPage();
            this.chkUseVideoCRF = new System.Windows.Forms.CheckBox();
            this.chkUseVideoProfile = new System.Windows.Forms.CheckBox();
            this.chkSettingsConverterVideoPreset = new System.Windows.Forms.CheckBox();
            this.chkUseVideoBitrate = new System.Windows.Forms.CheckBox();
            this.chkSettingsConverterVideoFastStart = new System.Windows.Forms.CheckBox();
            this.numConvertVideoCRF = new System.Windows.Forms.NumericUpDown();
            this.cbConvertVideoProfile = new System.Windows.Forms.ComboBox();
            this.cbConvertVideoPreset = new System.Windows.Forms.ComboBox();
            this.numConvertVideoBitrate = new System.Windows.Forms.NumericUpDown();
            this.lbConvertVideoThousands = new System.Windows.Forms.Label();
            this.lbSettingsConverterVideoBitrate = new System.Windows.Forms.Label();
            this.lbSettingsConverterVideoPreset = new System.Windows.Forms.Label();
            this.lbSettingsConverterVideoProfile = new System.Windows.Forms.Label();
            this.lbSettingsConverterVideoCRF = new System.Windows.Forms.Label();
            this.tcSettingsConverterAudio = new System.Windows.Forms.TabPage();
            this.chkUseAudioBitrate = new System.Windows.Forms.CheckBox();
            this.numConvertAudioBitrate = new System.Windows.Forms.NumericUpDown();
            this.lbidkwhatsup = new System.Windows.Forms.Label();
            this.lbConvertAudioThousands = new System.Windows.Forms.Label();
            this.lbSettingsConverterAudioBitrate = new System.Windows.Forms.Label();
            this.tcSettingsConverterCustom = new System.Windows.Forms.TabPage();
            this.txtSettingsConverterCustomArguments = new System.Windows.Forms.TextBox();
            this.lbSettingsConverterCustomHeader = new System.Windows.Forms.Label();
            this.chkSettingsConverterClearInputAfterConverting = new System.Windows.Forms.CheckBox();
            this.chkSettingsConverterClearOutputAfterConverting = new System.Windows.Forms.CheckBox();
            this.tabSettingsExtensions = new System.Windows.Forms.TabPage();
            this.lbSettingsExtensionsFileName = new System.Windows.Forms.Label();
            this.btnSettingsExtensionsAdd = new System.Windows.Forms.Button();
            this.btnSettingsExtensionsRemoveSelected = new System.Windows.Forms.Button();
            this.listExtensions = new System.Windows.Forms.ListBox();
            this.lbSettingsExtensionsExtensionShort = new System.Windows.Forms.Label();
            this.txtSettingsExtensionsExtensionShort = new System.Windows.Forms.TextBox();
            this.lbSettingsExtensionsExtensionFullName = new System.Windows.Forms.Label();
            this.txtSettingsExtensionsExtensionFullName = new System.Windows.Forms.TextBox();
            this.lbSettingsExtensionsHeader = new System.Windows.Forms.Label();
            this.tabSettingsErrors = new System.Windows.Forms.TabPage();
            this.chkSettingsErrorsSaveErrorsAsErrorLog = new System.Windows.Forms.CheckBox();
            this.chkSettingsErrorsShowDetailedErrors = new System.Windows.Forms.CheckBox();
            this.chkSettingsErrorsSuppressErrors = new System.Windows.Forms.CheckBox();
            this.btnSettingsRedownloadYoutubeDl = new System.Windows.Forms.Button();
            this.btnSettingsCancel = new System.Windows.Forms.Button();
            this.btnSettingsSave = new System.Windows.Forms.Button();
            this.tipSettings = new System.Windows.Forms.ToolTip(this.components);
            this.chkSettingsDownloadsEmbedThumbnails = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsEmbedSubtitles = new System.Windows.Forms.CheckBox();
            this.txtSettingsDownloadsProxyPort = new youtube_dl_gui.HintTextBox();
            this.txtSettingsDownloadsProxyIp = new youtube_dl_gui.HintTextBox();
            this.tcMain.SuspendLayout();
            this.tabSettingsGeneral.SuspendLayout();
            this.gbSettingsGeneralCustomArguments.SuspendLayout();
            this.tabSettingsDownloads.SuspendLayout();
            this.tabDownloads.SuspendLayout();
            this.tabDownloadsGeneral.SuspendLayout();
            this.tabDownloadsSorting.SuspendLayout();
            this.tabDownloadsFixes.SuspendLayout();
            this.tabDownloadsConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSettingsDownloadsRetryAttempts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSettingsDownloadsLimitDownload)).BeginInit();
            this.tabDownloadsUpdating.SuspendLayout();
            this.tabSettingsConverter.SuspendLayout();
            this.tcConverter.SuspendLayout();
            this.tcSettingsConverterVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertVideoCRF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertVideoBitrate)).BeginInit();
            this.tcSettingsConverterAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertAudioBitrate)).BeginInit();
            this.tcSettingsConverterCustom.SuspendLayout();
            this.tabSettingsExtensions.SuspendLayout();
            this.tabSettingsErrors.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tabSettingsGeneral);
            this.tcMain.Controls.Add(this.tabSettingsDownloads);
            this.tcMain.Controls.Add(this.tabSettingsConverter);
            this.tcMain.Controls.Add(this.tabSettingsExtensions);
            this.tcMain.Controls.Add(this.tabSettingsErrors);
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(328, 341);
            this.tcMain.TabIndex = 0;
            // 
            // tabSettingsGeneral
            // 
            this.tabSettingsGeneral.Controls.Add(this.gbSettingsGeneralCustomArguments);
            this.tabSettingsGeneral.Controls.Add(this.lbSepGeneral);
            this.tabSettingsGeneral.Controls.Add(this.btnSettingsGeneralBrowseFFmpeg);
            this.tabSettingsGeneral.Controls.Add(this.btnSettingsGeneralBrowseYoutubeDl);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralUseStaticYoutubeDl);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralUseStaticFFmpeg);
            this.tabSettingsGeneral.Controls.Add(this.txtSettingsGeneralFFmpegPath);
            this.tabSettingsGeneral.Controls.Add(this.lbSettingsGeneralFFmpegDirectory);
            this.tabSettingsGeneral.Controls.Add(this.txtSettingsGeneralYoutubeDlPath);
            this.tabSettingsGeneral.Controls.Add(this.lbSettingsGeneralYoutubeDlPath);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralClearUrlClipboardOnDownload);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralHoverOverUrlToPasteClipboard);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralCheckForUpdatesOnLaunch);
            this.tabSettingsGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsGeneral.Name = "tabSettingsGeneral";
            this.tabSettingsGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsGeneral.Size = new System.Drawing.Size(320, 315);
            this.tabSettingsGeneral.TabIndex = 0;
            this.tabSettingsGeneral.Text = "tabSettingsGeneral";
            this.tabSettingsGeneral.UseVisualStyleBackColor = true;
            // 
            // gbSettingsGeneralCustomArguments
            // 
            this.gbSettingsGeneralCustomArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSettingsGeneralCustomArguments.Controls.Add(this.rbSettingsGeneralCustomArgumentsSaveInSettings);
            this.gbSettingsGeneralCustomArguments.Controls.Add(this.rbSettingsGeneralCustomArgumentsSaveAsArgsText);
            this.gbSettingsGeneralCustomArguments.Controls.Add(this.rbSettingsGeneralCustomArgumentsDontSave);
            this.gbSettingsGeneralCustomArguments.Location = new System.Drawing.Point(6, 258);
            this.gbSettingsGeneralCustomArguments.Name = "gbSettingsGeneralCustomArguments";
            this.gbSettingsGeneralCustomArguments.Size = new System.Drawing.Size(308, 46);
            this.gbSettingsGeneralCustomArguments.TabIndex = 12;
            this.gbSettingsGeneralCustomArguments.TabStop = false;
            this.gbSettingsGeneralCustomArguments.Text = "gbSettingsGeneralCustomArguments";
            this.tipSettings.SetToolTip(this.gbSettingsGeneralCustomArguments, "gbSettingsGeneralCustomArguments");
            // 
            // rbSettingsGeneralCustomArgumentsSaveInSettings
            // 
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.AutoSize = true;
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.Checked = true;
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.Location = new System.Drawing.Point(203, 20);
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.Name = "rbSettingsGeneralCustomArgumentsSaveInSettings";
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.Size = new System.Drawing.Size(265, 17);
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.TabIndex = 2;
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.TabStop = true;
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.Text = "rbSettingsGeneralCustomArgumentsSaveInSettings";
            this.tipSettings.SetToolTip(this.rbSettingsGeneralCustomArgumentsSaveInSettings, "rbSettingsGeneralCustomArgumentsSaveInSettings");
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.UseVisualStyleBackColor = true;
            // 
            // rbSettingsGeneralCustomArgumentsSaveAsArgsText
            // 
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText.AutoSize = true;
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText.Location = new System.Drawing.Point(89, 20);
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText.Name = "rbSettingsGeneralCustomArgumentsSaveAsArgsText";
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText.Size = new System.Drawing.Size(272, 17);
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText.TabIndex = 1;
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText.Text = "rbSettingsGeneralCustomArgumentsSaveAsArgsText";
            this.tipSettings.SetToolTip(this.rbSettingsGeneralCustomArgumentsSaveAsArgsText, "rbSettingsGeneralCustomArgumentsSaveAsArgsText");
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText.UseVisualStyleBackColor = true;
            // 
            // rbSettingsGeneralCustomArgumentsDontSave
            // 
            this.rbSettingsGeneralCustomArgumentsDontSave.AutoSize = true;
            this.rbSettingsGeneralCustomArgumentsDontSave.Location = new System.Drawing.Point(8, 20);
            this.rbSettingsGeneralCustomArgumentsDontSave.Name = "rbSettingsGeneralCustomArgumentsDontSave";
            this.rbSettingsGeneralCustomArgumentsDontSave.Size = new System.Drawing.Size(241, 17);
            this.rbSettingsGeneralCustomArgumentsDontSave.TabIndex = 0;
            this.rbSettingsGeneralCustomArgumentsDontSave.Text = "rbSettingsGeneralCustomArgumentsDontSave";
            this.tipSettings.SetToolTip(this.rbSettingsGeneralCustomArgumentsDontSave, "rbSettingsGeneralCustomArgumentsDontSave");
            this.rbSettingsGeneralCustomArgumentsDontSave.UseVisualStyleBackColor = true;
            // 
            // lbSepGeneral
            // 
            this.lbSepGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSepGeneral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSepGeneral.Location = new System.Drawing.Point(25, 107);
            this.lbSepGeneral.Name = "lbSepGeneral";
            this.lbSepGeneral.Size = new System.Drawing.Size(270, 2);
            this.lbSepGeneral.TabIndex = 8;
            this.lbSepGeneral.Text = "HELLO WORLD";
            // 
            // btnSettingsGeneralBrowseFFmpeg
            // 
            this.btnSettingsGeneralBrowseFFmpeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsGeneralBrowseFFmpeg.Location = new System.Drawing.Point(269, 77);
            this.btnSettingsGeneralBrowseFFmpeg.Name = "btnSettingsGeneralBrowseFFmpeg";
            this.btnSettingsGeneralBrowseFFmpeg.Size = new System.Drawing.Size(33, 23);
            this.btnSettingsGeneralBrowseFFmpeg.TabIndex = 7;
            this.btnSettingsGeneralBrowseFFmpeg.Text = "...";
            this.tipSettings.SetToolTip(this.btnSettingsGeneralBrowseFFmpeg, "btnBrwsFF");
            this.btnSettingsGeneralBrowseFFmpeg.UseVisualStyleBackColor = true;
            this.btnSettingsGeneralBrowseFFmpeg.Click += new System.EventHandler(this.btnSettingsGeneralBrowseFFmpeg_Click);
            // 
            // btnSettingsGeneralBrowseYoutubeDl
            // 
            this.btnSettingsGeneralBrowseYoutubeDl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsGeneralBrowseYoutubeDl.Location = new System.Drawing.Point(269, 30);
            this.btnSettingsGeneralBrowseYoutubeDl.Name = "btnSettingsGeneralBrowseYoutubeDl";
            this.btnSettingsGeneralBrowseYoutubeDl.Size = new System.Drawing.Size(33, 23);
            this.btnSettingsGeneralBrowseYoutubeDl.TabIndex = 6;
            this.btnSettingsGeneralBrowseYoutubeDl.Text = "...";
            this.tipSettings.SetToolTip(this.btnSettingsGeneralBrowseYoutubeDl, "btnBrwsYtdl");
            this.btnSettingsGeneralBrowseYoutubeDl.UseVisualStyleBackColor = true;
            this.btnSettingsGeneralBrowseYoutubeDl.Click += new System.EventHandler(this.btnSettingsGeneralBrowseYoutubeDl_Click);
            // 
            // chkSettingsGeneralUseStaticYoutubeDl
            // 
            this.chkSettingsGeneralUseStaticYoutubeDl.AutoSize = true;
            this.chkSettingsGeneralUseStaticYoutubeDl.Location = new System.Drawing.Point(122, 11);
            this.chkSettingsGeneralUseStaticYoutubeDl.Name = "chkSettingsGeneralUseStaticYoutubeDl";
            this.chkSettingsGeneralUseStaticYoutubeDl.Size = new System.Drawing.Size(214, 17);
            this.chkSettingsGeneralUseStaticYoutubeDl.TabIndex = 5;
            this.chkSettingsGeneralUseStaticYoutubeDl.Text = "chkSettingsGeneralUseStaticYoutubeDl";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralUseStaticYoutubeDl, "chkSettingsGeneralUseStaticYoutubeDl");
            this.chkSettingsGeneralUseStaticYoutubeDl.UseVisualStyleBackColor = true;
            this.chkSettingsGeneralUseStaticYoutubeDl.CheckedChanged += new System.EventHandler(this.chkSettingsGeneralUseStaticYoutubeDl_CheckedChanged);
            // 
            // chkSettingsGeneralUseStaticFFmpeg
            // 
            this.chkSettingsGeneralUseStaticFFmpeg.AutoSize = true;
            this.chkSettingsGeneralUseStaticFFmpeg.Location = new System.Drawing.Point(122, 58);
            this.chkSettingsGeneralUseStaticFFmpeg.Name = "chkSettingsGeneralUseStaticFFmpeg";
            this.chkSettingsGeneralUseStaticFFmpeg.Size = new System.Drawing.Size(202, 17);
            this.chkSettingsGeneralUseStaticFFmpeg.TabIndex = 4;
            this.chkSettingsGeneralUseStaticFFmpeg.Text = "chkSettingsGeneralUseStaticFFmpeg";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralUseStaticFFmpeg, "chkSettingsGeneralUseStaticFFmpeg");
            this.chkSettingsGeneralUseStaticFFmpeg.UseVisualStyleBackColor = true;
            this.chkSettingsGeneralUseStaticFFmpeg.CheckedChanged += new System.EventHandler(this.chkSettingsGeneralUseStaticFFmpeg_CheckedChanged);
            // 
            // txtSettingsGeneralFFmpegPath
            // 
            this.txtSettingsGeneralFFmpegPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsGeneralFFmpegPath.Location = new System.Drawing.Point(30, 79);
            this.txtSettingsGeneralFFmpegPath.Name = "txtSettingsGeneralFFmpegPath";
            this.txtSettingsGeneralFFmpegPath.ReadOnly = true;
            this.txtSettingsGeneralFFmpegPath.Size = new System.Drawing.Size(233, 20);
            this.txtSettingsGeneralFFmpegPath.TabIndex = 3;
            this.tipSettings.SetToolTip(this.txtSettingsGeneralFFmpegPath, "txtFFmpeg");
            // 
            // lbSettingsGeneralFFmpegDirectory
            // 
            this.lbSettingsGeneralFFmpegDirectory.AutoSize = true;
            this.lbSettingsGeneralFFmpegDirectory.Location = new System.Drawing.Point(19, 59);
            this.lbSettingsGeneralFFmpegDirectory.Name = "lbSettingsGeneralFFmpegDirectory";
            this.lbSettingsGeneralFFmpegDirectory.Size = new System.Drawing.Size(170, 13);
            this.lbSettingsGeneralFFmpegDirectory.TabIndex = 2;
            this.lbSettingsGeneralFFmpegDirectory.Text = "lbSettingsGeneralFFmpegDirectory";
            this.tipSettings.SetToolTip(this.lbSettingsGeneralFFmpegDirectory, "lbSettingsGeneralFFmpegDirectory");
            // 
            // txtSettingsGeneralYoutubeDlPath
            // 
            this.txtSettingsGeneralYoutubeDlPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsGeneralYoutubeDlPath.Location = new System.Drawing.Point(30, 32);
            this.txtSettingsGeneralYoutubeDlPath.Name = "txtSettingsGeneralYoutubeDlPath";
            this.txtSettingsGeneralYoutubeDlPath.ReadOnly = true;
            this.txtSettingsGeneralYoutubeDlPath.Size = new System.Drawing.Size(233, 20);
            this.txtSettingsGeneralYoutubeDlPath.TabIndex = 1;
            this.tipSettings.SetToolTip(this.txtSettingsGeneralYoutubeDlPath, "txtYtdl");
            // 
            // lbSettingsGeneralYoutubeDlPath
            // 
            this.lbSettingsGeneralYoutubeDlPath.AutoSize = true;
            this.lbSettingsGeneralYoutubeDlPath.Location = new System.Drawing.Point(19, 12);
            this.lbSettingsGeneralYoutubeDlPath.Name = "lbSettingsGeneralYoutubeDlPath";
            this.lbSettingsGeneralYoutubeDlPath.Size = new System.Drawing.Size(162, 13);
            this.lbSettingsGeneralYoutubeDlPath.TabIndex = 0;
            this.lbSettingsGeneralYoutubeDlPath.Text = "lbSettingsGeneralYoutubeDlPath";
            this.tipSettings.SetToolTip(this.lbSettingsGeneralYoutubeDlPath, "lbSettingsGeneralYoutubeDlPath");
            // 
            // chkSettingsGeneralClearUrlClipboardOnDownload
            // 
            this.chkSettingsGeneralClearUrlClipboardOnDownload.AutoSize = true;
            this.chkSettingsGeneralClearUrlClipboardOnDownload.Location = new System.Drawing.Point(30, 195);
            this.chkSettingsGeneralClearUrlClipboardOnDownload.Name = "chkSettingsGeneralClearUrlClipboardOnDownload";
            this.chkSettingsGeneralClearUrlClipboardOnDownload.Size = new System.Drawing.Size(261, 17);
            this.chkSettingsGeneralClearUrlClipboardOnDownload.TabIndex = 11;
            this.chkSettingsGeneralClearUrlClipboardOnDownload.Text = "chkSettingsGeneralClearUrlClipboardOnDownload";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralClearUrlClipboardOnDownload, "chkSettingsGeneralClearUrlClipboardOnDownload");
            this.chkSettingsGeneralClearUrlClipboardOnDownload.UseVisualStyleBackColor = true;
            // 
            // chkSettingsGeneralHoverOverUrlToPasteClipboard
            // 
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.AutoSize = true;
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Checked = true;
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Location = new System.Drawing.Point(27, 172);
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Name = "chkSettingsGeneralHoverOverUrlToPasteClipboard";
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Size = new System.Drawing.Size(267, 17);
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.TabIndex = 10;
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Text = "chkSettingsGeneralHoverOverUrlToPasteClipboard";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralHoverOverUrlToPasteClipboard, "chkSettingsGeneralHoverOverUrlToPasteClipboard");
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.UseVisualStyleBackColor = true;
            // 
            // chkSettingsGeneralCheckForUpdatesOnLaunch
            // 
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.AutoSize = true;
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.Location = new System.Drawing.Point(33, 149);
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.Name = "chkSettingsGeneralCheckForUpdatesOnLaunch";
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.Size = new System.Drawing.Size(254, 17);
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.TabIndex = 9;
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.Text = "chkSettingsGeneralCheckForUpdatesOnLaunch";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralCheckForUpdatesOnLaunch, "chkSettingsGeneralCheckForUpdatesOnLaunch");
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.UseVisualStyleBackColor = true;
            // 
            // tabSettingsDownloads
            // 
            this.tabSettingsDownloads.Controls.Add(this.tabDownloads);
            this.tabSettingsDownloads.Controls.Add(this.llSettingsDownloadsSchemaHelp);
            this.tabSettingsDownloads.Controls.Add(this.lbSettingsDownloadsDownloadPath);
            this.tabSettingsDownloads.Controls.Add(this.txtSettingsDownloadsSavePath);
            this.tabSettingsDownloads.Controls.Add(this.btnSettingsDownloadsBrowseSavePath);
            this.tabSettingsDownloads.Controls.Add(this.txtSettingsDownloadsFileNameSchema);
            this.tabSettingsDownloads.Controls.Add(this.lbSepDownloads);
            this.tabSettingsDownloads.Controls.Add(this.lbSettingsDownloadsFileNameSchema);
            this.tabSettingsDownloads.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsDownloads.Name = "tabSettingsDownloads";
            this.tabSettingsDownloads.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsDownloads.Size = new System.Drawing.Size(320, 315);
            this.tabSettingsDownloads.TabIndex = 1;
            this.tabSettingsDownloads.Text = "tabSettingsDownloads";
            this.tabSettingsDownloads.UseVisualStyleBackColor = true;
            // 
            // tabDownloads
            // 
            this.tabDownloads.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tabDownloads.Controls.Add(this.tabDownloadsGeneral);
            this.tabDownloads.Controls.Add(this.tabDownloadsSorting);
            this.tabDownloads.Controls.Add(this.tabDownloadsFixes);
            this.tabDownloads.Controls.Add(this.tabDownloadsConnection);
            this.tabDownloads.Controls.Add(this.tabDownloadsUpdating);
            this.tabDownloads.Location = new System.Drawing.Point(6, 116);
            this.tabDownloads.Name = "tabDownloads";
            this.tabDownloads.SelectedIndex = 0;
            this.tabDownloads.Size = new System.Drawing.Size(308, 193);
            this.tabDownloads.TabIndex = 25;
            // 
            // tabDownloadsGeneral
            // 
            this.tabDownloadsGeneral.Controls.Add(this.chkSettingsDownloadsEmbedSubtitles);
            this.tabDownloadsGeneral.Controls.Add(this.chkSettingsDownloadsEmbedThumbnails);
            this.tabDownloadsGeneral.Controls.Add(this.chkSettingsDownloadsSaveThumbnails);
            this.tabDownloadsGeneral.Controls.Add(this.chkSettingsDownloadsSaveFormatQuality);
            this.tabDownloadsGeneral.Controls.Add(this.chkSettingsDownloadsSaveAnnotations);
            this.tabDownloadsGeneral.Controls.Add(this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing);
            this.tabDownloadsGeneral.Controls.Add(this.chkSettingsDownloadsSaveDescription);
            this.tabDownloadsGeneral.Controls.Add(this.chkSettingsDownloadsDownloadSubtitles);
            this.tabDownloadsGeneral.Controls.Add(this.chkSettingsDownloadsSaveVideoInfo);
            this.tabDownloadsGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabDownloadsGeneral.Name = "tabDownloadsGeneral";
            this.tabDownloadsGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownloadsGeneral.Size = new System.Drawing.Size(300, 167);
            this.tabDownloadsGeneral.TabIndex = 0;
            this.tabDownloadsGeneral.Text = "Downloads";
            this.tabDownloadsGeneral.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsSaveThumbnails
            // 
            this.chkSettingsDownloadsSaveThumbnails.AutoSize = true;
            this.chkSettingsDownloadsSaveThumbnails.Location = new System.Drawing.Point(6, 121);
            this.chkSettingsDownloadsSaveThumbnails.Name = "chkSettingsDownloadsSaveThumbnails";
            this.chkSettingsDownloadsSaveThumbnails.Size = new System.Drawing.Size(213, 17);
            this.chkSettingsDownloadsSaveThumbnails.TabIndex = 29;
            this.chkSettingsDownloadsSaveThumbnails.Text = "chkSettingsDownloadsSaveThumbnails";
            this.chkSettingsDownloadsSaveThumbnails.UseVisualStyleBackColor = true;
            this.chkSettingsDownloadsSaveThumbnails.CheckedChanged += new System.EventHandler(this.chkSettingsDownloadsSaveThumbnails_CheckedChanged);
            // 
            // chkSettingsDownloadsSaveFormatQuality
            // 
            this.chkSettingsDownloadsSaveFormatQuality.AutoSize = true;
            this.chkSettingsDownloadsSaveFormatQuality.Location = new System.Drawing.Point(6, 6);
            this.chkSettingsDownloadsSaveFormatQuality.Name = "chkSettingsDownloadsSaveFormatQuality";
            this.chkSettingsDownloadsSaveFormatQuality.Size = new System.Drawing.Size(223, 17);
            this.chkSettingsDownloadsSaveFormatQuality.TabIndex = 15;
            this.chkSettingsDownloadsSaveFormatQuality.Text = "chkSettingsDownloadsSaveFormatQuality";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsSaveFormatQuality, "chkSettingsDownloadsSaveFormatQuality");
            this.chkSettingsDownloadsSaveFormatQuality.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsSaveAnnotations
            // 
            this.chkSettingsDownloadsSaveAnnotations.AutoSize = true;
            this.chkSettingsDownloadsSaveAnnotations.Location = new System.Drawing.Point(6, 98);
            this.chkSettingsDownloadsSaveAnnotations.Name = "chkSettingsDownloadsSaveAnnotations";
            this.chkSettingsDownloadsSaveAnnotations.Size = new System.Drawing.Size(215, 17);
            this.chkSettingsDownloadsSaveAnnotations.TabIndex = 28;
            this.chkSettingsDownloadsSaveAnnotations.Text = "chkSettingsDownloadsSaveAnnotations";
            this.chkSettingsDownloadsSaveAnnotations.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing
            // 
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.AutoSize = true;
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Location = new System.Drawing.Point(6, 144);
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Name = "chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing";
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Size = new System.Drawing.Size(340, 17);
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.TabIndex = 14;
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Text = "chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing, "chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing");
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsSaveDescription
            // 
            this.chkSettingsDownloadsSaveDescription.AutoSize = true;
            this.chkSettingsDownloadsSaveDescription.Location = new System.Drawing.Point(6, 75);
            this.chkSettingsDownloadsSaveDescription.Name = "chkSettingsDownloadsSaveDescription";
            this.chkSettingsDownloadsSaveDescription.Size = new System.Drawing.Size(212, 17);
            this.chkSettingsDownloadsSaveDescription.TabIndex = 27;
            this.chkSettingsDownloadsSaveDescription.Text = "chkSettingsDownloadsSaveDescription";
            this.chkSettingsDownloadsSaveDescription.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsDownloadSubtitles
            // 
            this.chkSettingsDownloadsDownloadSubtitles.AutoSize = true;
            this.chkSettingsDownloadsDownloadSubtitles.Location = new System.Drawing.Point(6, 29);
            this.chkSettingsDownloadsDownloadSubtitles.Name = "chkSettingsDownloadsDownloadSubtitles";
            this.chkSettingsDownloadsDownloadSubtitles.Size = new System.Drawing.Size(222, 17);
            this.chkSettingsDownloadsDownloadSubtitles.TabIndex = 24;
            this.chkSettingsDownloadsDownloadSubtitles.Text = "chkSettingsDownloadsDownloadSubtitles";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsDownloadSubtitles, "chkSettingsDownloadsDownloadSubtitles");
            this.chkSettingsDownloadsDownloadSubtitles.UseVisualStyleBackColor = true;
            this.chkSettingsDownloadsDownloadSubtitles.CheckedChanged += new System.EventHandler(this.chkSettingsDownloadsDownloadSubtitles_CheckedChanged);
            // 
            // chkSettingsDownloadsSaveVideoInfo
            // 
            this.chkSettingsDownloadsSaveVideoInfo.AutoSize = true;
            this.chkSettingsDownloadsSaveVideoInfo.Location = new System.Drawing.Point(6, 52);
            this.chkSettingsDownloadsSaveVideoInfo.Name = "chkSettingsDownloadsSaveVideoInfo";
            this.chkSettingsDownloadsSaveVideoInfo.Size = new System.Drawing.Size(204, 17);
            this.chkSettingsDownloadsSaveVideoInfo.TabIndex = 26;
            this.chkSettingsDownloadsSaveVideoInfo.Text = "chkSettingsDownloadsSaveVideoInfo";
            this.chkSettingsDownloadsSaveVideoInfo.UseVisualStyleBackColor = true;
            // 
            // tabDownloadsSorting
            // 
            this.tabDownloadsSorting.Controls.Add(this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders);
            this.tabDownloadsSorting.Controls.Add(this.chkSettingsDownloadsSeparateIntoWebsiteUrl);
            this.tabDownloadsSorting.Location = new System.Drawing.Point(4, 22);
            this.tabDownloadsSorting.Name = "tabDownloadsSorting";
            this.tabDownloadsSorting.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownloadsSorting.Size = new System.Drawing.Size(300, 167);
            this.tabDownloadsSorting.TabIndex = 3;
            this.tabDownloadsSorting.Text = "Sorting";
            this.tabDownloadsSorting.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsSeparateDownloadsToDifferentFolders
            // 
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.AutoSize = true;
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Checked = true;
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Location = new System.Drawing.Point(6, 6);
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Name = "chkSettingsDownloadsSeparateDownloadsToDifferentFolders";
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Size = new System.Drawing.Size(317, 17);
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.TabIndex = 17;
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Text = "chkSettingsDownloadsSeparateDownloadsToDifferentFolders";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders, "chkSettingsDownloadsSeparateDownloadsToDifferentFolders");
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsSeparateIntoWebsiteUrl
            // 
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.AutoSize = true;
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked = true;
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.Location = new System.Drawing.Point(6, 29);
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.Name = "chkSettingsDownloadsSeparateIntoWebsiteUrl";
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.Size = new System.Drawing.Size(247, 17);
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.TabIndex = 23;
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.Text = "chkSettingsDownloadsSeparateIntoWebsiteUrl";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsSeparateIntoWebsiteUrl, "chkSettingsDownloadsSeparateIntoWebsiteUrl");
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.UseVisualStyleBackColor = true;
            // 
            // tabDownloadsFixes
            // 
            this.tabDownloadsFixes.Controls.Add(this.chkSettingsDownloadsFixVReddIt);
            this.tabDownloadsFixes.Location = new System.Drawing.Point(4, 22);
            this.tabDownloadsFixes.Name = "tabDownloadsFixes";
            this.tabDownloadsFixes.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownloadsFixes.Size = new System.Drawing.Size(300, 167);
            this.tabDownloadsFixes.TabIndex = 4;
            this.tabDownloadsFixes.Text = "Fixes";
            this.tabDownloadsFixes.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsFixVReddIt
            // 
            this.chkSettingsDownloadsFixVReddIt.AutoSize = true;
            this.chkSettingsDownloadsFixVReddIt.Checked = true;
            this.chkSettingsDownloadsFixVReddIt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsDownloadsFixVReddIt.Location = new System.Drawing.Point(6, 6);
            this.chkSettingsDownloadsFixVReddIt.Name = "chkSettingsDownloadsFixVReddIt";
            this.chkSettingsDownloadsFixVReddIt.Size = new System.Drawing.Size(186, 17);
            this.chkSettingsDownloadsFixVReddIt.TabIndex = 22;
            this.chkSettingsDownloadsFixVReddIt.Text = "chkSettingsDownloadsFixVReddIt";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsFixVReddIt, "chkSettingsDownloadsFixVReddIt");
            this.chkSettingsDownloadsFixVReddIt.UseVisualStyleBackColor = true;
            // 
            // tabDownloadsConnection
            // 
            this.tabDownloadsConnection.Controls.Add(this.cbSettingsDownloadsProxyType);
            this.tabDownloadsConnection.Controls.Add(this.txtSettingsDownloadsProxyPort);
            this.tabDownloadsConnection.Controls.Add(this.txtSettingsDownloadsProxyIp);
            this.tabDownloadsConnection.Controls.Add(this.chkSettingsDownloadsForceIpv6);
            this.tabDownloadsConnection.Controls.Add(this.chkSettingsDownloadsForceIpv4);
            this.tabDownloadsConnection.Controls.Add(this.chkSettingsDownloadsUseProxy);
            this.tabDownloadsConnection.Controls.Add(this.numSettingsDownloadsRetryAttempts);
            this.tabDownloadsConnection.Controls.Add(this.lbSettingsDownloadsRetryAttempts);
            this.tabDownloadsConnection.Controls.Add(this.cbSettingsDownloadsLimitDownload);
            this.tabDownloadsConnection.Controls.Add(this.numSettingsDownloadsLimitDownload);
            this.tabDownloadsConnection.Controls.Add(this.lbSettingsDownloadsIpPort);
            this.tabDownloadsConnection.Controls.Add(this.chkSettingsDownloadsLimitDownload);
            this.tabDownloadsConnection.Location = new System.Drawing.Point(4, 22);
            this.tabDownloadsConnection.Name = "tabDownloadsConnection";
            this.tabDownloadsConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownloadsConnection.Size = new System.Drawing.Size(300, 167);
            this.tabDownloadsConnection.TabIndex = 1;
            this.tabDownloadsConnection.Text = "Connection";
            this.tabDownloadsConnection.UseVisualStyleBackColor = true;
            // 
            // cbSettingsDownloadsProxyType
            // 
            this.cbSettingsDownloadsProxyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSettingsDownloadsProxyType.FormattingEnabled = true;
            this.cbSettingsDownloadsProxyType.Items.AddRange(new object[] {
            "https://",
            "http://",
            "socks4://",
            "socks5://"});
            this.cbSettingsDownloadsProxyType.Location = new System.Drawing.Point(9, 131);
            this.cbSettingsDownloadsProxyType.Name = "cbSettingsDownloadsProxyType";
            this.cbSettingsDownloadsProxyType.Size = new System.Drawing.Size(77, 21);
            this.cbSettingsDownloadsProxyType.TabIndex = 43;
            this.tipSettings.SetToolTip(this.cbSettingsDownloadsProxyType, "cbSettingsDownloadsProxyTypeHint");
            // 
            // chkSettingsDownloadsForceIpv6
            // 
            this.chkSettingsDownloadsForceIpv6.AutoSize = true;
            this.chkSettingsDownloadsForceIpv6.Location = new System.Drawing.Point(6, 81);
            this.chkSettingsDownloadsForceIpv6.Name = "chkSettingsDownloadsForceIpv6";
            this.chkSettingsDownloadsForceIpv6.Size = new System.Drawing.Size(182, 17);
            this.chkSettingsDownloadsForceIpv6.TabIndex = 39;
            this.chkSettingsDownloadsForceIpv6.Text = "chkSettingsDownloadsForceIpv6";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsForceIpv6, "chkSettingsDownloadsForceIpv6Hint");
            this.chkSettingsDownloadsForceIpv6.UseVisualStyleBackColor = true;
            this.chkSettingsDownloadsForceIpv6.CheckedChanged += new System.EventHandler(this.chkSettingsDownloadsForceIpv6_CheckedChanged);
            // 
            // chkSettingsDownloadsForceIpv4
            // 
            this.chkSettingsDownloadsForceIpv4.AutoSize = true;
            this.chkSettingsDownloadsForceIpv4.Location = new System.Drawing.Point(6, 58);
            this.chkSettingsDownloadsForceIpv4.Name = "chkSettingsDownloadsForceIpv4";
            this.chkSettingsDownloadsForceIpv4.Size = new System.Drawing.Size(182, 17);
            this.chkSettingsDownloadsForceIpv4.TabIndex = 38;
            this.chkSettingsDownloadsForceIpv4.Text = "chkSettingsDownloadsForceIpv4";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsForceIpv4, "chkSettingsDownloadsForceIpv4Hint");
            this.chkSettingsDownloadsForceIpv4.UseVisualStyleBackColor = true;
            this.chkSettingsDownloadsForceIpv4.CheckedChanged += new System.EventHandler(this.chkSettingsDownloadsForceIpv4_CheckedChanged);
            // 
            // chkSettingsDownloadsUseProxy
            // 
            this.chkSettingsDownloadsUseProxy.AutoSize = true;
            this.chkSettingsDownloadsUseProxy.Location = new System.Drawing.Point(6, 110);
            this.chkSettingsDownloadsUseProxy.Name = "chkSettingsDownloadsUseProxy";
            this.chkSettingsDownloadsUseProxy.Size = new System.Drawing.Size(179, 17);
            this.chkSettingsDownloadsUseProxy.TabIndex = 37;
            this.chkSettingsDownloadsUseProxy.Text = "chkSettingsDownloadsUseProxy";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsUseProxy, "chkSettingsDownloadsUseProxy");
            this.chkSettingsDownloadsUseProxy.UseVisualStyleBackColor = true;
            // 
            // numSettingsDownloadsRetryAttempts
            // 
            this.numSettingsDownloadsRetryAttempts.Location = new System.Drawing.Point(115, 30);
            this.numSettingsDownloadsRetryAttempts.Name = "numSettingsDownloadsRetryAttempts";
            this.numSettingsDownloadsRetryAttempts.Size = new System.Drawing.Size(63, 20);
            this.numSettingsDownloadsRetryAttempts.TabIndex = 34;
            this.tipSettings.SetToolTip(this.numSettingsDownloadsRetryAttempts, "numSettingsDownloadsRetryAttemptsHint");
            // 
            // lbSettingsDownloadsRetryAttempts
            // 
            this.lbSettingsDownloadsRetryAttempts.AutoSize = true;
            this.lbSettingsDownloadsRetryAttempts.Location = new System.Drawing.Point(6, 32);
            this.lbSettingsDownloadsRetryAttempts.Name = "lbSettingsDownloadsRetryAttempts";
            this.lbSettingsDownloadsRetryAttempts.Size = new System.Drawing.Size(172, 13);
            this.lbSettingsDownloadsRetryAttempts.TabIndex = 35;
            this.lbSettingsDownloadsRetryAttempts.Text = "lbSettingsDownloadsRetryAttempts";
            this.tipSettings.SetToolTip(this.lbSettingsDownloadsRetryAttempts, "lbSettingsDownloadsRetryAttempts");
            // 
            // cbSettingsDownloadsLimitDownload
            // 
            this.cbSettingsDownloadsLimitDownload.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSettingsDownloadsLimitDownload.FormattingEnabled = true;
            this.cbSettingsDownloadsLimitDownload.Items.AddRange(new object[] {
            "KB",
            "MB",
            "GB"});
            this.cbSettingsDownloadsLimitDownload.Location = new System.Drawing.Point(187, 5);
            this.cbSettingsDownloadsLimitDownload.Name = "cbSettingsDownloadsLimitDownload";
            this.cbSettingsDownloadsLimitDownload.Size = new System.Drawing.Size(44, 21);
            this.cbSettingsDownloadsLimitDownload.TabIndex = 33;
            this.tipSettings.SetToolTip(this.cbSettingsDownloadsLimitDownload, "cbSettingsDownloadsDownloadLimit");
            // 
            // numSettingsDownloadsLimitDownload
            // 
            this.numSettingsDownloadsLimitDownload.Location = new System.Drawing.Point(126, 6);
            this.numSettingsDownloadsLimitDownload.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSettingsDownloadsLimitDownload.Name = "numSettingsDownloadsLimitDownload";
            this.numSettingsDownloadsLimitDownload.Size = new System.Drawing.Size(57, 20);
            this.numSettingsDownloadsLimitDownload.TabIndex = 32;
            this.tipSettings.SetToolTip(this.numSettingsDownloadsLimitDownload, "numSettingsDownloadsDownloadLimitHint");
            // 
            // lbSettingsDownloadsIpPort
            // 
            this.lbSettingsDownloadsIpPort.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSettingsDownloadsIpPort.Location = new System.Drawing.Point(178, 132);
            this.lbSettingsDownloadsIpPort.Name = "lbSettingsDownloadsIpPort";
            this.lbSettingsDownloadsIpPort.Size = new System.Drawing.Size(12, 20);
            this.lbSettingsDownloadsIpPort.TabIndex = 41;
            this.lbSettingsDownloadsIpPort.Text = ":";
            // 
            // chkSettingsDownloadsLimitDownload
            // 
            this.chkSettingsDownloadsLimitDownload.AutoSize = true;
            this.chkSettingsDownloadsLimitDownload.Location = new System.Drawing.Point(6, 6);
            this.chkSettingsDownloadsLimitDownload.Name = "chkSettingsDownloadsLimitDownload";
            this.chkSettingsDownloadsLimitDownload.Size = new System.Drawing.Size(203, 17);
            this.chkSettingsDownloadsLimitDownload.TabIndex = 44;
            this.chkSettingsDownloadsLimitDownload.Text = "chkSettingsDownloadsLimitDownload";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsLimitDownload, "chkSettingsDownloadsLimitDownloadHint");
            this.chkSettingsDownloadsLimitDownload.UseVisualStyleBackColor = true;
            // 
            // tabDownloadsUpdating
            // 
            this.tabDownloadsUpdating.Controls.Add(this.chksettingsDownloadsUseYoutubeDlsUpdater);
            this.tabDownloadsUpdating.Location = new System.Drawing.Point(4, 22);
            this.tabDownloadsUpdating.Name = "tabDownloadsUpdating";
            this.tabDownloadsUpdating.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownloadsUpdating.Size = new System.Drawing.Size(300, 167);
            this.tabDownloadsUpdating.TabIndex = 2;
            this.tabDownloadsUpdating.Text = "Updating";
            this.tabDownloadsUpdating.UseVisualStyleBackColor = true;
            // 
            // chksettingsDownloadsUseYoutubeDlsUpdater
            // 
            this.chksettingsDownloadsUseYoutubeDlsUpdater.AutoSize = true;
            this.chksettingsDownloadsUseYoutubeDlsUpdater.Location = new System.Drawing.Point(6, 6);
            this.chksettingsDownloadsUseYoutubeDlsUpdater.Name = "chksettingsDownloadsUseYoutubeDlsUpdater";
            this.chksettingsDownloadsUseYoutubeDlsUpdater.Size = new System.Drawing.Size(244, 17);
            this.chksettingsDownloadsUseYoutubeDlsUpdater.TabIndex = 13;
            this.chksettingsDownloadsUseYoutubeDlsUpdater.Text = "chksettingsDownloadsUseYoutubeDlsUpdater";
            this.tipSettings.SetToolTip(this.chksettingsDownloadsUseYoutubeDlsUpdater, "chksettingsDownloadsUseYoutubeDlsUpdater");
            this.chksettingsDownloadsUseYoutubeDlsUpdater.UseVisualStyleBackColor = true;
            // 
            // llSettingsDownloadsSchemaHelp
            // 
            this.llSettingsDownloadsSchemaHelp.AutoSize = true;
            this.llSettingsDownloadsSchemaHelp.Location = new System.Drawing.Point(210, 59);
            this.llSettingsDownloadsSchemaHelp.Name = "llSettingsDownloadsSchemaHelp";
            this.llSettingsDownloadsSchemaHelp.Size = new System.Drawing.Size(13, 13);
            this.llSettingsDownloadsSchemaHelp.TabIndex = 21;
            this.llSettingsDownloadsSchemaHelp.TabStop = true;
            this.llSettingsDownloadsSchemaHelp.Text = "?";
            this.tipSettings.SetToolTip(this.llSettingsDownloadsSchemaHelp, "llSchema");
            this.llSettingsDownloadsSchemaHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSettingsDownloadsSchemaHelp_LinkClicked);
            // 
            // lbSettingsDownloadsDownloadPath
            // 
            this.lbSettingsDownloadsDownloadPath.AutoSize = true;
            this.lbSettingsDownloadsDownloadPath.Location = new System.Drawing.Point(19, 12);
            this.lbSettingsDownloadsDownloadPath.Name = "lbSettingsDownloadsDownloadPath";
            this.lbSettingsDownloadsDownloadPath.Size = new System.Drawing.Size(176, 13);
            this.lbSettingsDownloadsDownloadPath.TabIndex = 7;
            this.lbSettingsDownloadsDownloadPath.Text = "lbSettingsDownloadsDownloadPath";
            this.tipSettings.SetToolTip(this.lbSettingsDownloadsDownloadPath, "lbSettingsDownloadsDownloadPath");
            // 
            // txtSettingsDownloadsSavePath
            // 
            this.txtSettingsDownloadsSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsDownloadsSavePath.Location = new System.Drawing.Point(30, 32);
            this.txtSettingsDownloadsSavePath.Name = "txtSettingsDownloadsSavePath";
            this.txtSettingsDownloadsSavePath.ReadOnly = true;
            this.txtSettingsDownloadsSavePath.Size = new System.Drawing.Size(233, 20);
            this.txtSettingsDownloadsSavePath.TabIndex = 8;
            this.tipSettings.SetToolTip(this.txtSettingsDownloadsSavePath, "txtSaveto");
            // 
            // btnSettingsDownloadsBrowseSavePath
            // 
            this.btnSettingsDownloadsBrowseSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsDownloadsBrowseSavePath.Location = new System.Drawing.Point(269, 30);
            this.btnSettingsDownloadsBrowseSavePath.Name = "btnSettingsDownloadsBrowseSavePath";
            this.btnSettingsDownloadsBrowseSavePath.Size = new System.Drawing.Size(33, 23);
            this.btnSettingsDownloadsBrowseSavePath.TabIndex = 10;
            this.btnSettingsDownloadsBrowseSavePath.Text = "...";
            this.tipSettings.SetToolTip(this.btnSettingsDownloadsBrowseSavePath, "btnSettingsDownloadsBrowseSavePath");
            this.btnSettingsDownloadsBrowseSavePath.UseVisualStyleBackColor = true;
            this.btnSettingsDownloadsBrowseSavePath.Click += new System.EventHandler(this.btnSettingsDownloadsBrowseSavePath_Click);
            // 
            // txtSettingsDownloadsFileNameSchema
            // 
            this.txtSettingsDownloadsFileNameSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsDownloadsFileNameSchema.Location = new System.Drawing.Point(30, 79);
            this.txtSettingsDownloadsFileNameSchema.Name = "txtSettingsDownloadsFileNameSchema";
            this.txtSettingsDownloadsFileNameSchema.Size = new System.Drawing.Size(260, 20);
            this.txtSettingsDownloadsFileNameSchema.TabIndex = 20;
            this.txtSettingsDownloadsFileNameSchema.Text = "%(title)s-%(id)s.%(ext)s";
            this.tipSettings.SetToolTip(this.txtSettingsDownloadsFileNameSchema, "txtSettingsDownloadsFileNameSchema");
            // 
            // lbSepDownloads
            // 
            this.lbSepDownloads.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSepDownloads.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSepDownloads.Location = new System.Drawing.Point(25, 107);
            this.lbSepDownloads.Name = "lbSepDownloads";
            this.lbSepDownloads.Size = new System.Drawing.Size(270, 2);
            this.lbSepDownloads.TabIndex = 11;
            this.lbSepDownloads.Text = "HELLO WORLD";
            this.tipSettings.SetToolTip(this.lbSepDownloads, "this is not an easter egg");
            // 
            // lbSettingsDownloadsFileNameSchema
            // 
            this.lbSettingsDownloadsFileNameSchema.AutoSize = true;
            this.lbSettingsDownloadsFileNameSchema.Location = new System.Drawing.Point(19, 59);
            this.lbSettingsDownloadsFileNameSchema.Name = "lbSettingsDownloadsFileNameSchema";
            this.lbSettingsDownloadsFileNameSchema.Size = new System.Drawing.Size(189, 13);
            this.lbSettingsDownloadsFileNameSchema.TabIndex = 19;
            this.lbSettingsDownloadsFileNameSchema.Text = "lbSettingsDownloadsFileNameSchema";
            // 
            // tabSettingsConverter
            // 
            this.tabSettingsConverter.Controls.Add(this.chkSettingsConverterHideFFmpegCompileInfo);
            this.tabSettingsConverter.Controls.Add(this.chkSettingsConverterDetectOutputFileType);
            this.tabSettingsConverter.Controls.Add(this.tcConverter);
            this.tabSettingsConverter.Controls.Add(this.chkSettingsConverterClearInputAfterConverting);
            this.tabSettingsConverter.Controls.Add(this.chkSettingsConverterClearOutputAfterConverting);
            this.tabSettingsConverter.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsConverter.Name = "tabSettingsConverter";
            this.tabSettingsConverter.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsConverter.Size = new System.Drawing.Size(320, 315);
            this.tabSettingsConverter.TabIndex = 2;
            this.tabSettingsConverter.Text = "tabSettingsConverterConverter";
            this.tabSettingsConverter.UseVisualStyleBackColor = true;
            // 
            // chkSettingsConverterHideFFmpegCompileInfo
            // 
            this.chkSettingsConverterHideFFmpegCompileInfo.AutoSize = true;
            this.chkSettingsConverterHideFFmpegCompileInfo.Location = new System.Drawing.Point(17, 81);
            this.chkSettingsConverterHideFFmpegCompileInfo.Name = "chkSettingsConverterHideFFmpegCompileInfo";
            this.chkSettingsConverterHideFFmpegCompileInfo.Size = new System.Drawing.Size(242, 17);
            this.chkSettingsConverterHideFFmpegCompileInfo.TabIndex = 19;
            this.chkSettingsConverterHideFFmpegCompileInfo.Text = "chkSettingsConverterHideFFmpegCompileInfo";
            this.tipSettings.SetToolTip(this.chkSettingsConverterHideFFmpegCompileInfo, "chkSettingsConverterHideFFmpegCompileInfo");
            this.chkSettingsConverterHideFFmpegCompileInfo.UseVisualStyleBackColor = true;
            // 
            // chkSettingsConverterDetectOutputFileType
            // 
            this.chkSettingsConverterDetectOutputFileType.AutoSize = true;
            this.chkSettingsConverterDetectOutputFileType.Checked = true;
            this.chkSettingsConverterDetectOutputFileType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsConverterDetectOutputFileType.Location = new System.Drawing.Point(17, 58);
            this.chkSettingsConverterDetectOutputFileType.Name = "chkSettingsConverterDetectOutputFileType";
            this.chkSettingsConverterDetectOutputFileType.Size = new System.Drawing.Size(231, 17);
            this.chkSettingsConverterDetectOutputFileType.TabIndex = 0;
            this.chkSettingsConverterDetectOutputFileType.Text = "chkSettingsConverterDetectOutputFileType";
            this.tipSettings.SetToolTip(this.chkSettingsConverterDetectOutputFileType, "chkSettingsConverterDetectOutputFileType");
            this.chkSettingsConverterDetectOutputFileType.UseVisualStyleBackColor = true;
            // 
            // tcConverter
            // 
            this.tcConverter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcConverter.Controls.Add(this.tcSettingsConverterVideo);
            this.tcConverter.Controls.Add(this.tcSettingsConverterAudio);
            this.tcConverter.Controls.Add(this.tcSettingsConverterCustom);
            this.tcConverter.Location = new System.Drawing.Point(8, 129);
            this.tcConverter.Name = "tcConverter";
            this.tcConverter.SelectedIndex = 0;
            this.tcConverter.Size = new System.Drawing.Size(304, 180);
            this.tcConverter.TabIndex = 18;
            // 
            // tcSettingsConverterVideo
            // 
            this.tcSettingsConverterVideo.Controls.Add(this.chkUseVideoCRF);
            this.tcSettingsConverterVideo.Controls.Add(this.chkUseVideoProfile);
            this.tcSettingsConverterVideo.Controls.Add(this.chkSettingsConverterVideoPreset);
            this.tcSettingsConverterVideo.Controls.Add(this.chkUseVideoBitrate);
            this.tcSettingsConverterVideo.Controls.Add(this.chkSettingsConverterVideoFastStart);
            this.tcSettingsConverterVideo.Controls.Add(this.numConvertVideoCRF);
            this.tcSettingsConverterVideo.Controls.Add(this.cbConvertVideoProfile);
            this.tcSettingsConverterVideo.Controls.Add(this.cbConvertVideoPreset);
            this.tcSettingsConverterVideo.Controls.Add(this.numConvertVideoBitrate);
            this.tcSettingsConverterVideo.Controls.Add(this.lbConvertVideoThousands);
            this.tcSettingsConverterVideo.Controls.Add(this.lbSettingsConverterVideoBitrate);
            this.tcSettingsConverterVideo.Controls.Add(this.lbSettingsConverterVideoPreset);
            this.tcSettingsConverterVideo.Controls.Add(this.lbSettingsConverterVideoProfile);
            this.tcSettingsConverterVideo.Controls.Add(this.lbSettingsConverterVideoCRF);
            this.tcSettingsConverterVideo.Location = new System.Drawing.Point(4, 22);
            this.tcSettingsConverterVideo.Name = "tcSettingsConverterVideo";
            this.tcSettingsConverterVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tcSettingsConverterVideo.Size = new System.Drawing.Size(296, 154);
            this.tcSettingsConverterVideo.TabIndex = 0;
            this.tcSettingsConverterVideo.Text = "tcSettingsConverterVideo";
            this.tcSettingsConverterVideo.UseVisualStyleBackColor = true;
            // 
            // chkUseVideoCRF
            // 
            this.chkUseVideoCRF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkUseVideoCRF.AutoSize = true;
            this.chkUseVideoCRF.Checked = true;
            this.chkUseVideoCRF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseVideoCRF.Location = new System.Drawing.Point(72, 96);
            this.chkUseVideoCRF.Name = "chkUseVideoCRF";
            this.chkUseVideoCRF.Size = new System.Drawing.Size(14, 13);
            this.chkUseVideoCRF.TabIndex = 13;
            this.chkUseVideoCRF.UseVisualStyleBackColor = true;
            // 
            // chkUseVideoProfile
            // 
            this.chkUseVideoProfile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkUseVideoProfile.AutoSize = true;
            this.chkUseVideoProfile.Location = new System.Drawing.Point(72, 70);
            this.chkUseVideoProfile.Name = "chkUseVideoProfile";
            this.chkUseVideoProfile.Size = new System.Drawing.Size(14, 13);
            this.chkUseVideoProfile.TabIndex = 12;
            this.chkUseVideoProfile.UseVisualStyleBackColor = true;
            // 
            // chkSettingsConverterVideoPreset
            // 
            this.chkSettingsConverterVideoPreset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkSettingsConverterVideoPreset.AutoSize = true;
            this.chkSettingsConverterVideoPreset.Location = new System.Drawing.Point(72, 43);
            this.chkSettingsConverterVideoPreset.Name = "chkSettingsConverterVideoPreset";
            this.chkSettingsConverterVideoPreset.Size = new System.Drawing.Size(14, 13);
            this.chkSettingsConverterVideoPreset.TabIndex = 11;
            this.chkSettingsConverterVideoPreset.UseVisualStyleBackColor = true;
            // 
            // chkUseVideoBitrate
            // 
            this.chkUseVideoBitrate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkUseVideoBitrate.AutoSize = true;
            this.chkUseVideoBitrate.Location = new System.Drawing.Point(72, 16);
            this.chkUseVideoBitrate.Name = "chkUseVideoBitrate";
            this.chkUseVideoBitrate.Size = new System.Drawing.Size(14, 13);
            this.chkUseVideoBitrate.TabIndex = 10;
            this.chkUseVideoBitrate.UseVisualStyleBackColor = true;
            // 
            // chkSettingsConverterVideoFastStart
            // 
            this.chkSettingsConverterVideoFastStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkSettingsConverterVideoFastStart.AutoSize = true;
            this.chkSettingsConverterVideoFastStart.Location = new System.Drawing.Point(117, 126);
            this.chkSettingsConverterVideoFastStart.Name = "chkSettingsConverterVideoFastStart";
            this.chkSettingsConverterVideoFastStart.Size = new System.Drawing.Size(196, 17);
            this.chkSettingsConverterVideoFastStart.TabIndex = 9;
            this.chkSettingsConverterVideoFastStart.Text = "chkSettingsConverterVideoFastStart";
            this.tipSettings.SetToolTip(this.chkSettingsConverterVideoFastStart, "chkSettingsConverterVideoFastStart");
            this.chkSettingsConverterVideoFastStart.UseVisualStyleBackColor = true;
            // 
            // numConvertVideoCRF
            // 
            this.numConvertVideoCRF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numConvertVideoCRF.Location = new System.Drawing.Point(131, 94);
            this.numConvertVideoCRF.Maximum = new decimal(new int[] {
            51,
            0,
            0,
            0});
            this.numConvertVideoCRF.Name = "numConvertVideoCRF";
            this.numConvertVideoCRF.Size = new System.Drawing.Size(39, 20);
            this.numConvertVideoCRF.TabIndex = 7;
            this.numConvertVideoCRF.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // cbConvertVideoProfile
            // 
            this.cbConvertVideoProfile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbConvertVideoProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConvertVideoProfile.FormattingEnabled = true;
            this.cbConvertVideoProfile.Items.AddRange(new object[] {
            "baseline",
            "main",
            "high",
            "high10",
            "high442",
            "high444"});
            this.cbConvertVideoProfile.Location = new System.Drawing.Point(131, 67);
            this.cbConvertVideoProfile.Name = "cbConvertVideoProfile";
            this.cbConvertVideoProfile.Size = new System.Drawing.Size(94, 21);
            this.cbConvertVideoProfile.TabIndex = 5;
            // 
            // cbConvertVideoPreset
            // 
            this.cbConvertVideoPreset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbConvertVideoPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConvertVideoPreset.FormattingEnabled = true;
            this.cbConvertVideoPreset.Items.AddRange(new object[] {
            "ultrafast",
            "superfast",
            "veryfast",
            "faster",
            "fast",
            "medium",
            "slow",
            "slower",
            "veryslow"});
            this.cbConvertVideoPreset.Location = new System.Drawing.Point(131, 40);
            this.cbConvertVideoPreset.Name = "cbConvertVideoPreset";
            this.cbConvertVideoPreset.Size = new System.Drawing.Size(94, 21);
            this.cbConvertVideoPreset.TabIndex = 3;
            // 
            // numConvertVideoBitrate
            // 
            this.numConvertVideoBitrate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numConvertVideoBitrate.Location = new System.Drawing.Point(131, 14);
            this.numConvertVideoBitrate.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numConvertVideoBitrate.Name = "numConvertVideoBitrate";
            this.numConvertVideoBitrate.Size = new System.Drawing.Size(79, 20);
            this.numConvertVideoBitrate.TabIndex = 0;
            this.numConvertVideoBitrate.ThousandsSeparator = true;
            this.numConvertVideoBitrate.Value = new decimal(new int[] {
            7500,
            0,
            0,
            0});
            // 
            // lbConvertVideoThousands
            // 
            this.lbConvertVideoThousands.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbConvertVideoThousands.AutoSize = true;
            this.lbConvertVideoThousands.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConvertVideoThousands.Location = new System.Drawing.Point(208, 14);
            this.lbConvertVideoThousands.Name = "lbConvertVideoThousands";
            this.lbConvertVideoThousands.Size = new System.Drawing.Size(16, 17);
            this.lbConvertVideoThousands.TabIndex = 2;
            this.lbConvertVideoThousands.Text = "K";
            // 
            // lbSettingsConverterVideoBitrate
            // 
            this.lbSettingsConverterVideoBitrate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSettingsConverterVideoBitrate.AutoSize = true;
            this.lbSettingsConverterVideoBitrate.Location = new System.Drawing.Point(86, 16);
            this.lbSettingsConverterVideoBitrate.Name = "lbSettingsConverterVideoBitrate";
            this.lbSettingsConverterVideoBitrate.Size = new System.Drawing.Size(156, 13);
            this.lbSettingsConverterVideoBitrate.TabIndex = 1;
            this.lbSettingsConverterVideoBitrate.Text = "lbSettingsConverterVideoBitrate";
            this.tipSettings.SetToolTip(this.lbSettingsConverterVideoBitrate, "lbSettingsConverterVideoBitrate");
            // 
            // lbSettingsConverterVideoPreset
            // 
            this.lbSettingsConverterVideoPreset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSettingsConverterVideoPreset.AutoSize = true;
            this.lbSettingsConverterVideoPreset.Location = new System.Drawing.Point(86, 43);
            this.lbSettingsConverterVideoPreset.Name = "lbSettingsConverterVideoPreset";
            this.lbSettingsConverterVideoPreset.Size = new System.Drawing.Size(162, 13);
            this.lbSettingsConverterVideoPreset.TabIndex = 4;
            this.lbSettingsConverterVideoPreset.Text = "lbkSettingsConverterVideoPreset";
            this.tipSettings.SetToolTip(this.lbSettingsConverterVideoPreset, "lbSettingsConverterVideoPreset");
            // 
            // lbSettingsConverterVideoProfile
            // 
            this.lbSettingsConverterVideoProfile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSettingsConverterVideoProfile.AutoSize = true;
            this.lbSettingsConverterVideoProfile.Location = new System.Drawing.Point(87, 70);
            this.lbSettingsConverterVideoProfile.Name = "lbSettingsConverterVideoProfile";
            this.lbSettingsConverterVideoProfile.Size = new System.Drawing.Size(155, 13);
            this.lbSettingsConverterVideoProfile.TabIndex = 6;
            this.lbSettingsConverterVideoProfile.Text = "lbSettingsConverterVideoProfile";
            this.tipSettings.SetToolTip(this.lbSettingsConverterVideoProfile, "lbSettingsConverterVideoProfile");
            // 
            // lbSettingsConverterVideoCRF
            // 
            this.lbSettingsConverterVideoCRF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSettingsConverterVideoCRF.AutoSize = true;
            this.lbSettingsConverterVideoCRF.Location = new System.Drawing.Point(95, 96);
            this.lbSettingsConverterVideoCRF.Name = "lbSettingsConverterVideoCRF";
            this.lbSettingsConverterVideoCRF.Size = new System.Drawing.Size(147, 13);
            this.lbSettingsConverterVideoCRF.TabIndex = 8;
            this.lbSettingsConverterVideoCRF.Text = "lbSettingsConverterVideoCRF";
            this.tipSettings.SetToolTip(this.lbSettingsConverterVideoCRF, "lbSettingsConverterVideoCRF");
            // 
            // tcSettingsConverterAudio
            // 
            this.tcSettingsConverterAudio.Controls.Add(this.chkUseAudioBitrate);
            this.tcSettingsConverterAudio.Controls.Add(this.numConvertAudioBitrate);
            this.tcSettingsConverterAudio.Controls.Add(this.lbidkwhatsup);
            this.tcSettingsConverterAudio.Controls.Add(this.lbConvertAudioThousands);
            this.tcSettingsConverterAudio.Controls.Add(this.lbSettingsConverterAudioBitrate);
            this.tcSettingsConverterAudio.Location = new System.Drawing.Point(4, 22);
            this.tcSettingsConverterAudio.Name = "tcSettingsConverterAudio";
            this.tcSettingsConverterAudio.Padding = new System.Windows.Forms.Padding(3);
            this.tcSettingsConverterAudio.Size = new System.Drawing.Size(296, 154);
            this.tcSettingsConverterAudio.TabIndex = 1;
            this.tcSettingsConverterAudio.Text = "tcSettingsConverterAudio";
            this.tcSettingsConverterAudio.UseVisualStyleBackColor = true;
            // 
            // chkUseAudioBitrate
            // 
            this.chkUseAudioBitrate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkUseAudioBitrate.AutoSize = true;
            this.chkUseAudioBitrate.Checked = true;
            this.chkUseAudioBitrate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseAudioBitrate.Location = new System.Drawing.Point(88, 21);
            this.chkUseAudioBitrate.Name = "chkUseAudioBitrate";
            this.chkUseAudioBitrate.Size = new System.Drawing.Size(14, 13);
            this.chkUseAudioBitrate.TabIndex = 20;
            this.chkUseAudioBitrate.UseVisualStyleBackColor = true;
            // 
            // numConvertAudioBitrate
            // 
            this.numConvertAudioBitrate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numConvertAudioBitrate.Location = new System.Drawing.Point(145, 19);
            this.numConvertAudioBitrate.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numConvertAudioBitrate.Name = "numConvertAudioBitrate";
            this.numConvertAudioBitrate.Size = new System.Drawing.Size(49, 20);
            this.numConvertAudioBitrate.TabIndex = 16;
            this.numConvertAudioBitrate.ThousandsSeparator = true;
            this.numConvertAudioBitrate.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // lbidkwhatsup
            // 
            this.lbidkwhatsup.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbidkwhatsup.AutoSize = true;
            this.lbidkwhatsup.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbidkwhatsup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbidkwhatsup.Location = new System.Drawing.Point(72, 120);
            this.lbidkwhatsup.Name = "lbidkwhatsup";
            this.lbidkwhatsup.Size = new System.Drawing.Size(153, 17);
            this.lbidkwhatsup.TabIndex = 15;
            this.lbidkwhatsup.Text = "nothing but us empties";
            this.lbidkwhatsup.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tipSettings.SetToolTip(this.lbidkwhatsup, "No settings for converting audio has been implemented at this time");
            // 
            // lbConvertAudioThousands
            // 
            this.lbConvertAudioThousands.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbConvertAudioThousands.AutoSize = true;
            this.lbConvertAudioThousands.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConvertAudioThousands.Location = new System.Drawing.Point(192, 20);
            this.lbConvertAudioThousands.Name = "lbConvertAudioThousands";
            this.lbConvertAudioThousands.Size = new System.Drawing.Size(16, 17);
            this.lbConvertAudioThousands.TabIndex = 18;
            this.lbConvertAudioThousands.Text = "K";
            // 
            // lbSettingsConverterAudioBitrate
            // 
            this.lbSettingsConverterAudioBitrate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSettingsConverterAudioBitrate.AutoSize = true;
            this.lbSettingsConverterAudioBitrate.Location = new System.Drawing.Point(102, 21);
            this.lbSettingsConverterAudioBitrate.Name = "lbSettingsConverterAudioBitrate";
            this.lbSettingsConverterAudioBitrate.Size = new System.Drawing.Size(166, 13);
            this.lbSettingsConverterAudioBitrate.TabIndex = 19;
            this.lbSettingsConverterAudioBitrate.Text = "chkSettingsConverterAudioBitrate";
            this.tipSettings.SetToolTip(this.lbSettingsConverterAudioBitrate, "lbSettingsConverterAudioBitrate");
            // 
            // tcSettingsConverterCustom
            // 
            this.tcSettingsConverterCustom.Controls.Add(this.txtSettingsConverterCustomArguments);
            this.tcSettingsConverterCustom.Controls.Add(this.lbSettingsConverterCustomHeader);
            this.tcSettingsConverterCustom.Location = new System.Drawing.Point(4, 22);
            this.tcSettingsConverterCustom.Name = "tcSettingsConverterCustom";
            this.tcSettingsConverterCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tcSettingsConverterCustom.Size = new System.Drawing.Size(296, 154);
            this.tcSettingsConverterCustom.TabIndex = 2;
            this.tcSettingsConverterCustom.Text = "tcSettingsConverterCustom";
            this.tcSettingsConverterCustom.UseVisualStyleBackColor = true;
            // 
            // txtSettingsConverterCustomArguments
            // 
            this.txtSettingsConverterCustomArguments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsConverterCustomArguments.Location = new System.Drawing.Point(36, 97);
            this.txtSettingsConverterCustomArguments.Name = "txtSettingsConverterCustomArguments";
            this.txtSettingsConverterCustomArguments.Size = new System.Drawing.Size(228, 20);
            this.txtSettingsConverterCustomArguments.TabIndex = 1;
            this.tipSettings.SetToolTip(this.txtSettingsConverterCustomArguments, "txtSettingsConverterCustomArguments");
            // 
            // lbSettingsConverterCustomHeader
            // 
            this.lbSettingsConverterCustomHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSettingsConverterCustomHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSettingsConverterCustomHeader.Location = new System.Drawing.Point(6, 37);
            this.lbSettingsConverterCustomHeader.Name = "lbSettingsConverterCustomHeader";
            this.lbSettingsConverterCustomHeader.Size = new System.Drawing.Size(284, 26);
            this.lbSettingsConverterCustomHeader.TabIndex = 0;
            this.lbSettingsConverterCustomHeader.Text = "lbSettingsConverterCustomHeader";
            this.lbSettingsConverterCustomHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkSettingsConverterClearInputAfterConverting
            // 
            this.chkSettingsConverterClearInputAfterConverting.AutoSize = true;
            this.chkSettingsConverterClearInputAfterConverting.Location = new System.Drawing.Point(17, 35);
            this.chkSettingsConverterClearInputAfterConverting.Name = "chkSettingsConverterClearInputAfterConverting";
            this.chkSettingsConverterClearInputAfterConverting.Size = new System.Drawing.Size(248, 17);
            this.chkSettingsConverterClearInputAfterConverting.TabIndex = 17;
            this.chkSettingsConverterClearInputAfterConverting.Text = "chkSettingsConverterClearInputAfterConverting";
            this.tipSettings.SetToolTip(this.chkSettingsConverterClearInputAfterConverting, "chkSettingsConverterClearInputAfterConverting");
            this.chkSettingsConverterClearInputAfterConverting.UseVisualStyleBackColor = true;
            // 
            // chkSettingsConverterClearOutputAfterConverting
            // 
            this.chkSettingsConverterClearOutputAfterConverting.AutoSize = true;
            this.chkSettingsConverterClearOutputAfterConverting.Location = new System.Drawing.Point(17, 12);
            this.chkSettingsConverterClearOutputAfterConverting.Name = "chkSettingsConverterClearOutputAfterConverting";
            this.chkSettingsConverterClearOutputAfterConverting.Size = new System.Drawing.Size(256, 17);
            this.chkSettingsConverterClearOutputAfterConverting.TabIndex = 16;
            this.chkSettingsConverterClearOutputAfterConverting.Text = "chkSettingsConverterClearOutputAfterConverting";
            this.tipSettings.SetToolTip(this.chkSettingsConverterClearOutputAfterConverting, "chkSettingsConverterClearOutputAfterConverting");
            this.chkSettingsConverterClearOutputAfterConverting.UseVisualStyleBackColor = true;
            // 
            // tabSettingsExtensions
            // 
            this.tabSettingsExtensions.Controls.Add(this.lbSettingsExtensionsFileName);
            this.tabSettingsExtensions.Controls.Add(this.btnSettingsExtensionsAdd);
            this.tabSettingsExtensions.Controls.Add(this.btnSettingsExtensionsRemoveSelected);
            this.tabSettingsExtensions.Controls.Add(this.listExtensions);
            this.tabSettingsExtensions.Controls.Add(this.lbSettingsExtensionsExtensionShort);
            this.tabSettingsExtensions.Controls.Add(this.txtSettingsExtensionsExtensionShort);
            this.tabSettingsExtensions.Controls.Add(this.lbSettingsExtensionsExtensionFullName);
            this.tabSettingsExtensions.Controls.Add(this.txtSettingsExtensionsExtensionFullName);
            this.tabSettingsExtensions.Controls.Add(this.lbSettingsExtensionsHeader);
            this.tabSettingsExtensions.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsExtensions.Name = "tabSettingsExtensions";
            this.tabSettingsExtensions.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsExtensions.Size = new System.Drawing.Size(320, 315);
            this.tabSettingsExtensions.TabIndex = 4;
            this.tabSettingsExtensions.Text = "tabSettingsExtensions";
            this.tabSettingsExtensions.UseVisualStyleBackColor = true;
            // 
            // lbSettingsExtensionsFileName
            // 
            this.lbSettingsExtensionsFileName.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbSettingsExtensionsFileName.AutoSize = true;
            this.lbSettingsExtensionsFileName.Location = new System.Drawing.Point(30, 288);
            this.lbSettingsExtensionsFileName.Name = "lbSettingsExtensionsFileName";
            this.lbSettingsExtensionsFileName.Size = new System.Drawing.Size(148, 13);
            this.lbSettingsExtensionsFileName.TabIndex = 9;
            this.lbSettingsExtensionsFileName.Text = "lbSettingsExtensionsFileName";
            // 
            // btnSettingsExtensionsAdd
            // 
            this.btnSettingsExtensionsAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSettingsExtensionsAdd.Location = new System.Drawing.Point(242, 63);
            this.btnSettingsExtensionsAdd.Name = "btnSettingsExtensionsAdd";
            this.btnSettingsExtensionsAdd.Size = new System.Drawing.Size(50, 23);
            this.btnSettingsExtensionsAdd.TabIndex = 8;
            this.btnSettingsExtensionsAdd.Text = "btnSettingsExtensionsAdd";
            this.btnSettingsExtensionsAdd.UseVisualStyleBackColor = true;
            this.btnSettingsExtensionsAdd.Click += new System.EventHandler(this.btnSettingsExtensionsAdd_Click);
            // 
            // btnSettingsExtensionsRemoveSelected
            // 
            this.btnSettingsExtensionsRemoveSelected.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSettingsExtensionsRemoveSelected.Location = new System.Drawing.Point(192, 284);
            this.btnSettingsExtensionsRemoveSelected.Name = "btnSettingsExtensionsRemoveSelected";
            this.btnSettingsExtensionsRemoveSelected.Size = new System.Drawing.Size(100, 23);
            this.btnSettingsExtensionsRemoveSelected.TabIndex = 7;
            this.btnSettingsExtensionsRemoveSelected.Text = "btnSettingsExtensionsRemoveSelected";
            this.btnSettingsExtensionsRemoveSelected.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSettingsExtensionsRemoveSelected.UseVisualStyleBackColor = true;
            this.btnSettingsExtensionsRemoveSelected.Click += new System.EventHandler(this.btnSettingsExtensionsRemoveSelected_Click);
            // 
            // listExtensions
            // 
            this.listExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listExtensions.FormattingEnabled = true;
            this.listExtensions.Location = new System.Drawing.Point(31, 96);
            this.listExtensions.Name = "listExtensions";
            this.listExtensions.Size = new System.Drawing.Size(261, 173);
            this.listExtensions.TabIndex = 6;
            this.listExtensions.SelectedIndexChanged += new System.EventHandler(this.listExtensions_SelectedIndexChanged);
            // 
            // lbSettingsExtensionsExtensionShort
            // 
            this.lbSettingsExtensionsExtensionShort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbSettingsExtensionsExtensionShort.AutoSize = true;
            this.lbSettingsExtensionsExtensionShort.Location = new System.Drawing.Point(178, 49);
            this.lbSettingsExtensionsExtensionShort.Name = "lbSettingsExtensionsExtensionShort";
            this.lbSettingsExtensionsExtensionShort.Size = new System.Drawing.Size(175, 13);
            this.lbSettingsExtensionsExtensionShort.TabIndex = 5;
            this.lbSettingsExtensionsExtensionShort.Text = "lbSettingsExtensionsExtensionShort";
            // 
            // txtSettingsExtensionsExtensionShort
            // 
            this.txtSettingsExtensionsExtensionShort.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSettingsExtensionsExtensionShort.Location = new System.Drawing.Point(181, 65);
            this.txtSettingsExtensionsExtensionShort.Name = "txtSettingsExtensionsExtensionShort";
            this.txtSettingsExtensionsExtensionShort.Size = new System.Drawing.Size(57, 20);
            this.txtSettingsExtensionsExtensionShort.TabIndex = 4;
            // 
            // lbSettingsExtensionsExtensionFullName
            // 
            this.lbSettingsExtensionsExtensionFullName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbSettingsExtensionsExtensionFullName.AutoSize = true;
            this.lbSettingsExtensionsExtensionFullName.Location = new System.Drawing.Point(28, 49);
            this.lbSettingsExtensionsExtensionFullName.Name = "lbSettingsExtensionsExtensionFullName";
            this.lbSettingsExtensionsExtensionFullName.Size = new System.Drawing.Size(194, 13);
            this.lbSettingsExtensionsExtensionFullName.TabIndex = 3;
            this.lbSettingsExtensionsExtensionFullName.Text = "lbSettingsExtensionsExtensionFullName";
            // 
            // txtSettingsExtensionsExtensionFullName
            // 
            this.txtSettingsExtensionsExtensionFullName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSettingsExtensionsExtensionFullName.Location = new System.Drawing.Point(31, 65);
            this.txtSettingsExtensionsExtensionFullName.Name = "txtSettingsExtensionsExtensionFullName";
            this.txtSettingsExtensionsExtensionFullName.Size = new System.Drawing.Size(144, 20);
            this.txtSettingsExtensionsExtensionFullName.TabIndex = 2;
            // 
            // lbSettingsExtensionsHeader
            // 
            this.lbSettingsExtensionsHeader.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbSettingsExtensionsHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSettingsExtensionsHeader.Location = new System.Drawing.Point(8, 10);
            this.lbSettingsExtensionsHeader.Name = "lbSettingsExtensionsHeader";
            this.lbSettingsExtensionsHeader.Size = new System.Drawing.Size(304, 26);
            this.lbSettingsExtensionsHeader.TabIndex = 1;
            this.lbSettingsExtensionsHeader.Text = "lbSettingsExtensionsHeader";
            this.lbSettingsExtensionsHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabSettingsErrors
            // 
            this.tabSettingsErrors.Controls.Add(this.chkSettingsErrorsSaveErrorsAsErrorLog);
            this.tabSettingsErrors.Controls.Add(this.chkSettingsErrorsShowDetailedErrors);
            this.tabSettingsErrors.Controls.Add(this.chkSettingsErrorsSuppressErrors);
            this.tabSettingsErrors.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsErrors.Name = "tabSettingsErrors";
            this.tabSettingsErrors.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsErrors.Size = new System.Drawing.Size(320, 315);
            this.tabSettingsErrors.TabIndex = 3;
            this.tabSettingsErrors.Text = "tabSettingsErrors";
            this.tabSettingsErrors.UseVisualStyleBackColor = true;
            // 
            // chkSettingsErrorsSaveErrorsAsErrorLog
            // 
            this.chkSettingsErrorsSaveErrorsAsErrorLog.AutoSize = true;
            this.chkSettingsErrorsSaveErrorsAsErrorLog.Location = new System.Drawing.Point(8, 6);
            this.chkSettingsErrorsSaveErrorsAsErrorLog.Name = "chkSettingsErrorsSaveErrorsAsErrorLog";
            this.chkSettingsErrorsSaveErrorsAsErrorLog.Size = new System.Drawing.Size(212, 17);
            this.chkSettingsErrorsSaveErrorsAsErrorLog.TabIndex = 2;
            this.chkSettingsErrorsSaveErrorsAsErrorLog.Text = "chkSettingsErrorsSaveErrorsAsErrorLog";
            this.tipSettings.SetToolTip(this.chkSettingsErrorsSaveErrorsAsErrorLog, "chkSettingsErrorsSaveErrorsAsErrorLog");
            this.chkSettingsErrorsSaveErrorsAsErrorLog.UseVisualStyleBackColor = true;
            // 
            // chkSettingsErrorsShowDetailedErrors
            // 
            this.chkSettingsErrorsShowDetailedErrors.AutoSize = true;
            this.chkSettingsErrorsShowDetailedErrors.Enabled = false;
            this.chkSettingsErrorsShowDetailedErrors.Location = new System.Drawing.Point(8, 52);
            this.chkSettingsErrorsShowDetailedErrors.Name = "chkSettingsErrorsShowDetailedErrors";
            this.chkSettingsErrorsShowDetailedErrors.Size = new System.Drawing.Size(201, 17);
            this.chkSettingsErrorsShowDetailedErrors.TabIndex = 1;
            this.chkSettingsErrorsShowDetailedErrors.Text = "chkSettingsErrorsShowDetailedErrors";
            this.tipSettings.SetToolTip(this.chkSettingsErrorsShowDetailedErrors, "chkSettingsErrorsShowDetailedErrors");
            this.chkSettingsErrorsShowDetailedErrors.UseVisualStyleBackColor = true;
            this.chkSettingsErrorsShowDetailedErrors.Visible = false;
            // 
            // chkSettingsErrorsSuppressErrors
            // 
            this.chkSettingsErrorsSuppressErrors.AutoSize = true;
            this.chkSettingsErrorsSuppressErrors.Location = new System.Drawing.Point(8, 29);
            this.chkSettingsErrorsSuppressErrors.Name = "chkSettingsErrorsSuppressErrors";
            this.chkSettingsErrorsSuppressErrors.Size = new System.Drawing.Size(179, 17);
            this.chkSettingsErrorsSuppressErrors.TabIndex = 0;
            this.chkSettingsErrorsSuppressErrors.Text = "chkSettingsErrorsSuppressErrors";
            this.tipSettings.SetToolTip(this.chkSettingsErrorsSuppressErrors, "chkSettingsErrorsSuppressErrors");
            this.chkSettingsErrorsSuppressErrors.UseVisualStyleBackColor = true;
            // 
            // btnSettingsRedownloadYoutubeDl
            // 
            this.btnSettingsRedownloadYoutubeDl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettingsRedownloadYoutubeDl.Location = new System.Drawing.Point(4, 351);
            this.btnSettingsRedownloadYoutubeDl.Name = "btnSettingsRedownloadYoutubeDl";
            this.btnSettingsRedownloadYoutubeDl.Size = new System.Drawing.Size(140, 23);
            this.btnSettingsRedownloadYoutubeDl.TabIndex = 18;
            this.btnSettingsRedownloadYoutubeDl.Text = "btnSettingsRedownloadYoutubeDl";
            this.tipSettings.SetToolTip(this.btnSettingsRedownloadYoutubeDl, "btnSettingsRedownloadYoutubeDl");
            this.btnSettingsRedownloadYoutubeDl.UseVisualStyleBackColor = true;
            this.btnSettingsRedownloadYoutubeDl.Click += new System.EventHandler(this.btnSettingsRedownloadYoutubeDl_Click);
            // 
            // btnSettingsCancel
            // 
            this.btnSettingsCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsCancel.Location = new System.Drawing.Point(168, 351);
            this.btnSettingsCancel.Name = "btnSettingsCancel";
            this.btnSettingsCancel.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsCancel.TabIndex = 1;
            this.btnSettingsCancel.Text = "btnSettingsCancel";
            this.tipSettings.SetToolTip(this.btnSettingsCancel, "btnSettingsCancel");
            this.btnSettingsCancel.UseVisualStyleBackColor = true;
            this.btnSettingsCancel.Click += new System.EventHandler(this.btnSettingsCancel_Click);
            // 
            // btnSettingsSave
            // 
            this.btnSettingsSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsSave.Location = new System.Drawing.Point(249, 351);
            this.btnSettingsSave.Name = "btnSettingsSave";
            this.btnSettingsSave.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsSave.TabIndex = 2;
            this.btnSettingsSave.Text = "btnSettingsSave";
            this.tipSettings.SetToolTip(this.btnSettingsSave, "btnSettingsSave");
            this.btnSettingsSave.UseVisualStyleBackColor = true;
            this.btnSettingsSave.Click += new System.EventHandler(this.btnSettingsSave_Click);
            // 
            // tipSettings
            // 
            this.tipSettings.AutoPopDelay = 25000;
            this.tipSettings.InitialDelay = 500;
            this.tipSettings.ReshowDelay = 100;
            this.tipSettings.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // chkSettingsDownloadsEmbedThumbnails
            // 
            this.chkSettingsDownloadsEmbedThumbnails.AutoSize = true;
            this.chkSettingsDownloadsEmbedThumbnails.Location = new System.Drawing.Point(225, 121);
            this.chkSettingsDownloadsEmbedThumbnails.Name = "chkSettingsDownloadsEmbedThumbnails";
            this.chkSettingsDownloadsEmbedThumbnails.Size = new System.Drawing.Size(221, 17);
            this.chkSettingsDownloadsEmbedThumbnails.TabIndex = 30;
            this.chkSettingsDownloadsEmbedThumbnails.Text = "chkSettingsDownloadsEmbedThumbnails";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsEmbedThumbnails, "chkSettingsDownloadsEmbedSubtitlesHint");
            this.chkSettingsDownloadsEmbedThumbnails.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsEmbedSubtitles
            // 
            this.chkSettingsDownloadsEmbedSubtitles.AutoSize = true;
            this.chkSettingsDownloadsEmbedSubtitles.Location = new System.Drawing.Point(234, 29);
            this.chkSettingsDownloadsEmbedSubtitles.Name = "chkSettingsDownloadsEmbedSubtitles";
            this.chkSettingsDownloadsEmbedSubtitles.Size = new System.Drawing.Size(207, 17);
            this.chkSettingsDownloadsEmbedSubtitles.TabIndex = 31;
            this.chkSettingsDownloadsEmbedSubtitles.Text = "chkSettingsDownloadsEmbedSubtitles";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsEmbedSubtitles, "chkSettingsDownloadsEmbedSubtitlesHint");
            this.chkSettingsDownloadsEmbedSubtitles.UseVisualStyleBackColor = true;
            // 
            // txtSettingsDownloadsProxyPort
            // 
            this.txtSettingsDownloadsProxyPort.Location = new System.Drawing.Point(189, 132);
            this.txtSettingsDownloadsProxyPort.MaxLength = 5;
            this.txtSettingsDownloadsProxyPort.Name = "txtSettingsDownloadsProxyPort";
            this.txtSettingsDownloadsProxyPort.Size = new System.Drawing.Size(44, 20);
            this.txtSettingsDownloadsProxyPort.TabIndex = 42;
            this.txtSettingsDownloadsProxyPort.TextHint = "12345";
            this.tipSettings.SetToolTip(this.txtSettingsDownloadsProxyPort, "txtSettingsDownloadsProxyPortHint");
            this.txtSettingsDownloadsProxyPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSettingsDownloadsProxyPort_KeyPress);
            // 
            // txtSettingsDownloadsProxyIp
            // 
            this.txtSettingsDownloadsProxyIp.Location = new System.Drawing.Point(92, 132);
            this.txtSettingsDownloadsProxyIp.MaxLength = 15;
            this.txtSettingsDownloadsProxyIp.Name = "txtSettingsDownloadsProxyIp";
            this.txtSettingsDownloadsProxyIp.Size = new System.Drawing.Size(89, 20);
            this.txtSettingsDownloadsProxyIp.TabIndex = 40;
            this.txtSettingsDownloadsProxyIp.TextHint = "255.255.255.255";
            this.tipSettings.SetToolTip(this.txtSettingsDownloadsProxyIp, "txtSettingsDownloadsProxyIpHint");
            this.txtSettingsDownloadsProxyIp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSettingsDownloadsProxyIp_KeyPress);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(328, 386);
            this.Controls.Add(this.btnSettingsSave);
            this.Controls.Add(this.btnSettingsCancel);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.btnSettingsRedownloadYoutubeDl);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(336, 416);
            this.Name = "frmSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "youtube-dl-gui settings";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tcMain.ResumeLayout(false);
            this.tabSettingsGeneral.ResumeLayout(false);
            this.tabSettingsGeneral.PerformLayout();
            this.gbSettingsGeneralCustomArguments.ResumeLayout(false);
            this.gbSettingsGeneralCustomArguments.PerformLayout();
            this.tabSettingsDownloads.ResumeLayout(false);
            this.tabSettingsDownloads.PerformLayout();
            this.tabDownloads.ResumeLayout(false);
            this.tabDownloadsGeneral.ResumeLayout(false);
            this.tabDownloadsGeneral.PerformLayout();
            this.tabDownloadsSorting.ResumeLayout(false);
            this.tabDownloadsSorting.PerformLayout();
            this.tabDownloadsFixes.ResumeLayout(false);
            this.tabDownloadsFixes.PerformLayout();
            this.tabDownloadsConnection.ResumeLayout(false);
            this.tabDownloadsConnection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSettingsDownloadsRetryAttempts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSettingsDownloadsLimitDownload)).EndInit();
            this.tabDownloadsUpdating.ResumeLayout(false);
            this.tabDownloadsUpdating.PerformLayout();
            this.tabSettingsConverter.ResumeLayout(false);
            this.tabSettingsConverter.PerformLayout();
            this.tcConverter.ResumeLayout(false);
            this.tcSettingsConverterVideo.ResumeLayout(false);
            this.tcSettingsConverterVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertVideoCRF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertVideoBitrate)).EndInit();
            this.tcSettingsConverterAudio.ResumeLayout(false);
            this.tcSettingsConverterAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertAudioBitrate)).EndInit();
            this.tcSettingsConverterCustom.ResumeLayout(false);
            this.tcSettingsConverterCustom.PerformLayout();
            this.tabSettingsExtensions.ResumeLayout(false);
            this.tabSettingsExtensions.PerformLayout();
            this.tabSettingsErrors.ResumeLayout(false);
            this.tabSettingsErrors.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabSettingsGeneral;
        private System.Windows.Forms.Label lbSepGeneral;
        private System.Windows.Forms.Button btnSettingsGeneralBrowseFFmpeg;
        private System.Windows.Forms.Button btnSettingsGeneralBrowseYoutubeDl;
        private System.Windows.Forms.CheckBox chkSettingsGeneralUseStaticYoutubeDl;
        private System.Windows.Forms.CheckBox chkSettingsGeneralUseStaticFFmpeg;
        private System.Windows.Forms.TextBox txtSettingsGeneralFFmpegPath;
        private System.Windows.Forms.Label lbSettingsGeneralFFmpegDirectory;
        private System.Windows.Forms.TextBox txtSettingsGeneralYoutubeDlPath;
        private System.Windows.Forms.Label lbSettingsGeneralYoutubeDlPath;
        private System.Windows.Forms.TabPage tabSettingsDownloads;
        private System.Windows.Forms.TabPage tabSettingsConverter;
        private System.Windows.Forms.Button btnSettingsCancel;
        private System.Windows.Forms.Button btnSettingsSave;
        private System.Windows.Forms.GroupBox gbSettingsGeneralCustomArguments;
        private System.Windows.Forms.RadioButton rbSettingsGeneralCustomArgumentsSaveInSettings;
        private System.Windows.Forms.RadioButton rbSettingsGeneralCustomArgumentsSaveAsArgsText;
        private System.Windows.Forms.RadioButton rbSettingsGeneralCustomArgumentsDontSave;
        private System.Windows.Forms.CheckBox chkSettingsGeneralClearUrlClipboardOnDownload;
        private System.Windows.Forms.CheckBox chkSettingsGeneralHoverOverUrlToPasteClipboard;
        private System.Windows.Forms.CheckBox chkSettingsGeneralCheckForUpdatesOnLaunch;
        private System.Windows.Forms.CheckBox chksettingsDownloadsUseYoutubeDlsUpdater;
        private System.Windows.Forms.Button btnSettingsDownloadsBrowseSavePath;
        private System.Windows.Forms.TextBox txtSettingsDownloadsSavePath;
        private System.Windows.Forms.Label lbSettingsDownloadsDownloadPath;
        private System.Windows.Forms.Label lbSepDownloads;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsSeparateDownloadsToDifferentFolders;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsSaveFormatQuality;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing;
        private System.Windows.Forms.Button btnSettingsRedownloadYoutubeDl;
        private System.Windows.Forms.CheckBox chkSettingsConverterDetectOutputFileType;
        private System.Windows.Forms.TextBox txtSettingsDownloadsFileNameSchema;
        private System.Windows.Forms.Label lbSettingsDownloadsFileNameSchema;
        private System.Windows.Forms.LinkLabel llSettingsDownloadsSchemaHelp;
        private System.Windows.Forms.Label lbidkwhatsup;
        private System.Windows.Forms.ToolTip tipSettings;
        private System.Windows.Forms.CheckBox chkSettingsConverterClearInputAfterConverting;
        private System.Windows.Forms.CheckBox chkSettingsConverterClearOutputAfterConverting;
        private System.Windows.Forms.TabControl tcConverter;
        private System.Windows.Forms.TabPage tcSettingsConverterVideo;
        private System.Windows.Forms.TabPage tcSettingsConverterAudio;
        private System.Windows.Forms.NumericUpDown numConvertVideoBitrate;
        private System.Windows.Forms.Label lbConvertVideoThousands;
        private System.Windows.Forms.Label lbSettingsConverterVideoBitrate;
        private System.Windows.Forms.ComboBox cbConvertVideoPreset;
        private System.Windows.Forms.Label lbSettingsConverterVideoPreset;
        private System.Windows.Forms.Label lbSettingsConverterVideoProfile;
        private System.Windows.Forms.ComboBox cbConvertVideoProfile;
        private System.Windows.Forms.Label lbSettingsConverterVideoCRF;
        private System.Windows.Forms.NumericUpDown numConvertVideoCRF;
        private System.Windows.Forms.CheckBox chkSettingsConverterVideoFastStart;
        private System.Windows.Forms.TabPage tcSettingsConverterCustom;
        private System.Windows.Forms.TextBox txtSettingsConverterCustomArguments;
        private System.Windows.Forms.Label lbSettingsConverterCustomHeader;
        private System.Windows.Forms.CheckBox chkSettingsConverterHideFFmpegCompileInfo;
        private System.Windows.Forms.TabPage tabSettingsErrors;
        private System.Windows.Forms.CheckBox chkSettingsErrorsSaveErrorsAsErrorLog;
        private System.Windows.Forms.CheckBox chkSettingsErrorsShowDetailedErrors;
        private System.Windows.Forms.CheckBox chkSettingsErrorsSuppressErrors;
        private System.Windows.Forms.NumericUpDown numConvertAudioBitrate;
        private System.Windows.Forms.Label lbConvertAudioThousands;
        private System.Windows.Forms.TabPage tabSettingsExtensions;
        private System.Windows.Forms.Label lbSettingsExtensionsHeader;
        private System.Windows.Forms.Button btnSettingsExtensionsRemoveSelected;
        private System.Windows.Forms.ListBox listExtensions;
        private System.Windows.Forms.Label lbSettingsExtensionsExtensionShort;
        private System.Windows.Forms.TextBox txtSettingsExtensionsExtensionShort;
        private System.Windows.Forms.Label lbSettingsExtensionsExtensionFullName;
        private System.Windows.Forms.TextBox txtSettingsExtensionsExtensionFullName;
        private System.Windows.Forms.Button btnSettingsExtensionsAdd;
        private System.Windows.Forms.Label lbSettingsExtensionsFileName;
        private System.Windows.Forms.CheckBox chkUseVideoCRF;
        private System.Windows.Forms.CheckBox chkUseVideoProfile;
        private System.Windows.Forms.CheckBox chkSettingsConverterVideoPreset;
        private System.Windows.Forms.CheckBox chkUseVideoBitrate;
        private System.Windows.Forms.CheckBox chkUseAudioBitrate;
        private System.Windows.Forms.Label lbSettingsConverterAudioBitrate;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsFixVReddIt;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsSeparateIntoWebsiteUrl;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsDownloadSubtitles;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsSaveThumbnails;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsSaveAnnotations;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsSaveDescription;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsSaveVideoInfo;
        private System.Windows.Forms.TabControl tabDownloads;
        private System.Windows.Forms.TabPage tabDownloadsGeneral;
        private System.Windows.Forms.TabPage tabDownloadsSorting;
        private System.Windows.Forms.TabPage tabDownloadsFixes;
        private System.Windows.Forms.TabPage tabDownloadsConnection;
        private System.Windows.Forms.TabPage tabDownloadsUpdating;
        private System.Windows.Forms.NumericUpDown numSettingsDownloadsLimitDownload;
        private System.Windows.Forms.ComboBox cbSettingsDownloadsLimitDownload;
        private System.Windows.Forms.NumericUpDown numSettingsDownloadsRetryAttempts;
        private System.Windows.Forms.Label lbSettingsDownloadsRetryAttempts;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsUseProxy;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsForceIpv6;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsForceIpv4;
        private HintTextBox txtSettingsDownloadsProxyPort;
        private HintTextBox txtSettingsDownloadsProxyIp;
        private System.Windows.Forms.Label lbSettingsDownloadsIpPort;
        private System.Windows.Forms.ComboBox cbSettingsDownloadsProxyType;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsLimitDownload;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsEmbedSubtitles;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsEmbedThumbnails;
    }
}