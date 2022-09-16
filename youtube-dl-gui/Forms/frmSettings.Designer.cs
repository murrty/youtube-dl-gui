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
            this.chkDeleteOldVersionAfterUpdating = new System.Windows.Forms.CheckBox();
            this.chkSettingsGeneralDeleteUpdaterAfterUpdating = new System.Windows.Forms.CheckBox();
            this.chkSettingsGeneralCheckForBetaUpdates = new System.Windows.Forms.CheckBox();
            this.chkSettingsGeneralAutoUpdateYoutubeDl = new System.Windows.Forms.CheckBox();
            this.chkSettingsGeneralClearClipboardOnDownload = new System.Windows.Forms.CheckBox();
            this.gbSettingsGeneralCustomArguments = new System.Windows.Forms.GroupBox();
            this.rbSettingsGeneralCustomArgumentsSaveInSettings = new System.Windows.Forms.RadioButton();
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText = new System.Windows.Forms.RadioButton();
            this.rbSettingsGeneralCustomArgumentsDontSave = new System.Windows.Forms.RadioButton();
            this.chkSettingsGeneralClearUrlOnDownload = new System.Windows.Forms.CheckBox();
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard = new System.Windows.Forms.CheckBox();
            this.chkSettingsGeneralCheckForUpdatesOnLaunch = new System.Windows.Forms.CheckBox();
            this.tcExternalApplications = new System.Windows.Forms.TabControl();
            this.tabSettingsGeneralYoutubeDl = new System.Windows.Forms.TabPage();
            this.chkSettingsGeneralUseStaticYoutubeDl = new System.Windows.Forms.CheckBox();
            this.lbSettingsGeneralYoutubeDlPath = new System.Windows.Forms.Label();
            this.btnSettingsRedownloadYoutubeDl = new System.Windows.Forms.Button();
            this.txtSettingsGeneralYoutubeDlPath = new murrty.controls.ExtendedTextBox();
            this.btnSettingsGeneralBrowseYoutubeDl = new System.Windows.Forms.Button();
            this.tabSettingsGeneralFfmpeg = new System.Windows.Forms.TabPage();
            this.chkSettingsGeneralUseStaticFFmpeg = new System.Windows.Forms.CheckBox();
            this.btnSettingsGeneralBrowseFFmpeg = new System.Windows.Forms.Button();
            this.btnSettingsRedownloadFfmpeg = new System.Windows.Forms.Button();
            this.txtSettingsGeneralFFmpegPath = new murrty.controls.ExtendedTextBox();
            this.lbSettingsGeneralFFmpegDirectory = new System.Windows.Forms.Label();
            this.tabSettingsDownloads = new System.Windows.Forms.TabPage();
            this.chkSettingsDownloadsDownloadPathUseRelativePath = new System.Windows.Forms.CheckBox();
            this.tabDownloads = new System.Windows.Forms.TabControl();
            this.tabDownloadsGeneral = new System.Windows.Forms.TabPage();
            this.chkSettingsDownloadsKeepOriginalFiles = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsWriteMetadataToFile = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsEmbedSubtitles = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsEmbedThumbnails = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsSaveThumbnails = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsSaveFormatQuality = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsSaveAnnotations = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsSaveDescription = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsDownloadSubtitles = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsSaveVideoInfo = new System.Windows.Forms.CheckBox();
            this.tabDownloadsSorting = new System.Windows.Forms.TabPage();
            this.chkSettingsDownloadsWebsiteSubdomains = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl = new System.Windows.Forms.CheckBox();
            this.tabDownloadsFixes = new System.Windows.Forms.TabPage();
            this.chkSettingsDownloadsPreferFFmpeg = new System.Windows.Forms.CheckBox();
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
            this.txtSettingsDownloadsProxyPort = new murrty.controls.ExtendedTextBox();
            this.txtSettingsDownloadsProxyIp = new murrty.controls.ExtendedTextBox();
            this.tabDownloadsUpdating = new System.Windows.Forms.TabPage();
            this.llbSettingsDownloadsYtdlTypeViewRepo = new murrty.controls.ExtendedLinkLabel();
            this.lbSettingsDownloadsUpdatingYtdlType = new System.Windows.Forms.Label();
            this.cbSettingsDownloadsUpdatingYtdlType = new System.Windows.Forms.ComboBox();
            this.chksettingsDownloadsUseYoutubeDlsUpdater = new System.Windows.Forms.CheckBox();
            this.tabDownloadsBatch = new System.Windows.Forms.TabPage();
            this.chkSettingsDownloadsAddDateToBatchDownloadFolders = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsSeparateBatchDownloads = new System.Windows.Forms.CheckBox();
            this.tabYtdlpExtendedOptions = new System.Windows.Forms.TabPage();
            this.chkYtdlpExtendedAutomaticallyDownloadThumbnail = new System.Windows.Forms.CheckBox();
            this.chkYtdlpPreferExtendedDialog = new System.Windows.Forms.CheckBox();
            this.llSettingsDownloadsSchemaHelp = new murrty.controls.ExtendedLinkLabel();
            this.lbSettingsDownloadsDownloadPath = new System.Windows.Forms.Label();
            this.txtSettingsDownloadsSavePath = new murrty.controls.ExtendedTextBox();
            this.btnSettingsDownloadsBrowseSavePath = new System.Windows.Forms.Button();
            this.lbSepDownloads = new System.Windows.Forms.Label();
            this.lbSettingsDownloadsFileNameSchema = new System.Windows.Forms.Label();
            this.txtSettingsDownloadsFileNameSchema = new System.Windows.Forms.ComboBox();
            this.tabSettingsConverter = new System.Windows.Forms.TabPage();
            this.chkSettingsConverterHideFFmpegCompileInfo = new System.Windows.Forms.CheckBox();
            this.chkSettingsConverterDetectOutputFileType = new System.Windows.Forms.CheckBox();
            this.tcConverter = new System.Windows.Forms.TabControl();
            this.tcSettingsConverterVideo = new System.Windows.Forms.TabPage();
            this.chkSettingsConverterVideoCRF = new System.Windows.Forms.CheckBox();
            this.chkSettingsConverterVideoProfile = new System.Windows.Forms.CheckBox();
            this.chkSettingsConverterVideoPreset = new System.Windows.Forms.CheckBox();
            this.chkSettingsConverterVideoBitrate = new System.Windows.Forms.CheckBox();
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
            this.txtSettingsConverterCustomArguments = new murrty.controls.ExtendedTextBox();
            this.lbSettingsConverterCustomHeader = new System.Windows.Forms.Label();
            this.chkSettingsConverterClearInputAfterConverting = new System.Windows.Forms.CheckBox();
            this.chkSettingsConverterClearOutputAfterConverting = new System.Windows.Forms.CheckBox();
            this.tabSettingsExtensions = new System.Windows.Forms.TabPage();
            this.lbSettingsExtensionsFileName = new System.Windows.Forms.Label();
            this.btnSettingsExtensionsAdd = new System.Windows.Forms.Button();
            this.btnSettingsExtensionsRemoveSelected = new System.Windows.Forms.Button();
            this.listExtensions = new System.Windows.Forms.ListBox();
            this.lbSettingsExtensionsExtensionShort = new System.Windows.Forms.Label();
            this.lbSettingsExtensionsExtensionFullName = new System.Windows.Forms.Label();
            this.lbSettingsExtensionsHeader = new System.Windows.Forms.Label();
            this.txtSettingsExtensionsExtensionShort = new murrty.controls.ExtendedTextBox();
            this.txtSettingsExtensionsExtensionFullName = new murrty.controls.ExtendedTextBox();
            this.tabSettingsErrors = new System.Windows.Forms.TabPage();
            this.chkSettingsErrorsSaveErrorsAsErrorLog = new System.Windows.Forms.CheckBox();
            this.chkSettingsErrorsShowDetailedErrors = new System.Windows.Forms.CheckBox();
            this.chkSettingsErrorsSuppressErrors = new System.Windows.Forms.CheckBox();
            this.btnSettingsCancel = new System.Windows.Forms.Button();
            this.btnSettingsSave = new System.Windows.Forms.Button();
            this.tipSettings = new System.Windows.Forms.ToolTip(this.components);
            this.tcMain.SuspendLayout();
            this.tabSettingsGeneral.SuspendLayout();
            this.gbSettingsGeneralCustomArguments.SuspendLayout();
            this.tcExternalApplications.SuspendLayout();
            this.tabSettingsGeneralYoutubeDl.SuspendLayout();
            this.tabSettingsGeneralFfmpeg.SuspendLayout();
            this.tabSettingsDownloads.SuspendLayout();
            this.tabDownloads.SuspendLayout();
            this.tabDownloadsGeneral.SuspendLayout();
            this.tabDownloadsSorting.SuspendLayout();
            this.tabDownloadsFixes.SuspendLayout();
            this.tabDownloadsConnection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSettingsDownloadsRetryAttempts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSettingsDownloadsLimitDownload)).BeginInit();
            this.tabDownloadsUpdating.SuspendLayout();
            this.tabDownloadsBatch.SuspendLayout();
            this.tabYtdlpExtendedOptions.SuspendLayout();
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
            this.tcMain.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(328, 388);
            this.tcMain.TabIndex = 0;
            // 
            // tabSettingsGeneral
            // 
            this.tabSettingsGeneral.Controls.Add(this.chkDeleteOldVersionAfterUpdating);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralDeleteUpdaterAfterUpdating);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralCheckForBetaUpdates);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralAutoUpdateYoutubeDl);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralClearClipboardOnDownload);
            this.tabSettingsGeneral.Controls.Add(this.gbSettingsGeneralCustomArguments);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralClearUrlOnDownload);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralHoverOverUrlToPasteClipboard);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralCheckForUpdatesOnLaunch);
            this.tabSettingsGeneral.Controls.Add(this.tcExternalApplications);
            this.tabSettingsGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsGeneral.Name = "tabSettingsGeneral";
            this.tabSettingsGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsGeneral.Size = new System.Drawing.Size(320, 362);
            this.tabSettingsGeneral.TabIndex = 0;
            this.tabSettingsGeneral.Text = "tabSettingsGeneral";
            this.tabSettingsGeneral.UseVisualStyleBackColor = true;
            // 
            // chkDeleteOldVersionAfterUpdating
            // 
            this.chkDeleteOldVersionAfterUpdating.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkDeleteOldVersionAfterUpdating.AutoSize = true;
            this.chkDeleteOldVersionAfterUpdating.Location = new System.Drawing.Point(57, 189);
            this.chkDeleteOldVersionAfterUpdating.Name = "chkDeleteOldVersionAfterUpdating";
            this.chkDeleteOldVersionAfterUpdating.Size = new System.Drawing.Size(207, 17);
            this.chkDeleteOldVersionAfterUpdating.TabIndex = 18;
            this.chkDeleteOldVersionAfterUpdating.Text = "chkDeleteOldVersionAfterUpdating";
            this.tipSettings.SetToolTip(this.chkDeleteOldVersionAfterUpdating, "chkDeleteOldVersionAfterUpdatingHint");
            this.chkDeleteOldVersionAfterUpdating.UseVisualStyleBackColor = true;
            // 
            // chkSettingsGeneralDeleteUpdaterAfterUpdating
            // 
            this.chkSettingsGeneralDeleteUpdaterAfterUpdating.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkSettingsGeneralDeleteUpdaterAfterUpdating.AutoSize = true;
            this.chkSettingsGeneralDeleteUpdaterAfterUpdating.Location = new System.Drawing.Point(23, 168);
            this.chkSettingsGeneralDeleteUpdaterAfterUpdating.Name = "chkSettingsGeneralDeleteUpdaterAfterUpdating";
            this.chkSettingsGeneralDeleteUpdaterAfterUpdating.Size = new System.Drawing.Size(274, 17);
            this.chkSettingsGeneralDeleteUpdaterAfterUpdating.TabIndex = 17;
            this.chkSettingsGeneralDeleteUpdaterAfterUpdating.Text = "chkSettingsGeneralDeleteUpdaterAfterUpdating";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralDeleteUpdaterAfterUpdating, "chkSettingsGeneralDeleteUpdaterAfterUpdatingHint");
            this.chkSettingsGeneralDeleteUpdaterAfterUpdating.UseVisualStyleBackColor = true;
            // 
            // chkSettingsGeneralCheckForBetaUpdates
            // 
            this.chkSettingsGeneralCheckForBetaUpdates.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkSettingsGeneralCheckForBetaUpdates.AutoSize = true;
            this.chkSettingsGeneralCheckForBetaUpdates.Location = new System.Drawing.Point(41, 147);
            this.chkSettingsGeneralCheckForBetaUpdates.Name = "chkSettingsGeneralCheckForBetaUpdates";
            this.chkSettingsGeneralCheckForBetaUpdates.Size = new System.Drawing.Size(238, 17);
            this.chkSettingsGeneralCheckForBetaUpdates.TabIndex = 16;
            this.chkSettingsGeneralCheckForBetaUpdates.Text = "chkSettingsGeneralCheckForBetaUpdates";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralCheckForBetaUpdates, "chkSettingsGeneralCheckForBetaUpdatesHint");
            this.chkSettingsGeneralCheckForBetaUpdates.UseVisualStyleBackColor = true;
            // 
            // chkSettingsGeneralAutoUpdateYoutubeDl
            // 
            this.chkSettingsGeneralAutoUpdateYoutubeDl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkSettingsGeneralAutoUpdateYoutubeDl.AutoSize = true;
            this.chkSettingsGeneralAutoUpdateYoutubeDl.Location = new System.Drawing.Point(53, 273);
            this.chkSettingsGeneralAutoUpdateYoutubeDl.Name = "chkSettingsGeneralAutoUpdateYoutubeDl";
            this.chkSettingsGeneralAutoUpdateYoutubeDl.Size = new System.Drawing.Size(241, 17);
            this.chkSettingsGeneralAutoUpdateYoutubeDl.TabIndex = 15;
            this.chkSettingsGeneralAutoUpdateYoutubeDl.Text = "chkSettingsGeneralAutoUpdateYoutubeDl";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralAutoUpdateYoutubeDl, "chkSettingsGeneralAutoUpdateYoutubeDlHint");
            this.chkSettingsGeneralAutoUpdateYoutubeDl.UseVisualStyleBackColor = true;
            // 
            // chkSettingsGeneralClearClipboardOnDownload
            // 
            this.chkSettingsGeneralClearClipboardOnDownload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkSettingsGeneralClearClipboardOnDownload.AutoSize = true;
            this.chkSettingsGeneralClearClipboardOnDownload.Location = new System.Drawing.Point(36, 252);
            this.chkSettingsGeneralClearClipboardOnDownload.Name = "chkSettingsGeneralClearClipboardOnDownload";
            this.chkSettingsGeneralClearClipboardOnDownload.Size = new System.Drawing.Size(272, 17);
            this.chkSettingsGeneralClearClipboardOnDownload.TabIndex = 13;
            this.chkSettingsGeneralClearClipboardOnDownload.Text = "chkSettingsGeneralClearClipboardOnDownload";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralClearClipboardOnDownload, "chkSettingsGeneralClearClipboardOnDownloadHint");
            this.chkSettingsGeneralClearClipboardOnDownload.UseVisualStyleBackColor = true;
            // 
            // gbSettingsGeneralCustomArguments
            // 
            this.gbSettingsGeneralCustomArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSettingsGeneralCustomArguments.Controls.Add(this.rbSettingsGeneralCustomArgumentsSaveInSettings);
            this.gbSettingsGeneralCustomArguments.Controls.Add(this.rbSettingsGeneralCustomArgumentsSaveAsArgsText);
            this.gbSettingsGeneralCustomArguments.Controls.Add(this.rbSettingsGeneralCustomArgumentsDontSave);
            this.gbSettingsGeneralCustomArguments.Location = new System.Drawing.Point(4, 305);
            this.gbSettingsGeneralCustomArguments.Name = "gbSettingsGeneralCustomArguments";
            this.gbSettingsGeneralCustomArguments.Size = new System.Drawing.Size(308, 44);
            this.gbSettingsGeneralCustomArguments.TabIndex = 14;
            this.gbSettingsGeneralCustomArguments.TabStop = false;
            this.gbSettingsGeneralCustomArguments.Text = "gbSettingsGeneralCustomArguments";
            this.tipSettings.SetToolTip(this.gbSettingsGeneralCustomArguments, "gbSettingsGeneralCustomArguments");
            // 
            // rbSettingsGeneralCustomArgumentsSaveInSettings
            // 
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.AutoSize = true;
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.Checked = true;
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.Location = new System.Drawing.Point(200, 18);
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.Name = "rbSettingsGeneralCustomArgumentsSaveInSettings";
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.Size = new System.Drawing.Size(287, 17);
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.TabIndex = 17;
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.TabStop = true;
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.Text = "rbSettingsGeneralCustomArgumentsSaveInSettings";
            this.tipSettings.SetToolTip(this.rbSettingsGeneralCustomArgumentsSaveInSettings, "rbSettingsGeneralCustomArgumentsSaveInSettings");
            this.rbSettingsGeneralCustomArgumentsSaveInSettings.UseVisualStyleBackColor = true;
            // 
            // rbSettingsGeneralCustomArgumentsSaveAsArgsText
            // 
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText.AutoSize = true;
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText.Location = new System.Drawing.Point(89, 18);
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText.Name = "rbSettingsGeneralCustomArgumentsSaveAsArgsText";
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText.Size = new System.Drawing.Size(290, 17);
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText.TabIndex = 16;
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText.Text = "rbSettingsGeneralCustomArgumentsSaveAsArgsText";
            this.tipSettings.SetToolTip(this.rbSettingsGeneralCustomArgumentsSaveAsArgsText, "rbSettingsGeneralCustomArgumentsSaveAsArgsText");
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText.UseVisualStyleBackColor = true;
            // 
            // rbSettingsGeneralCustomArgumentsDontSave
            // 
            this.rbSettingsGeneralCustomArgumentsDontSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.rbSettingsGeneralCustomArgumentsDontSave.AutoSize = true;
            this.rbSettingsGeneralCustomArgumentsDontSave.Location = new System.Drawing.Point(8, 18);
            this.rbSettingsGeneralCustomArgumentsDontSave.Name = "rbSettingsGeneralCustomArgumentsDontSave";
            this.rbSettingsGeneralCustomArgumentsDontSave.Size = new System.Drawing.Size(261, 17);
            this.rbSettingsGeneralCustomArgumentsDontSave.TabIndex = 15;
            this.rbSettingsGeneralCustomArgumentsDontSave.Text = "rbSettingsGeneralCustomArgumentsDontSave";
            this.tipSettings.SetToolTip(this.rbSettingsGeneralCustomArgumentsDontSave, "rbSettingsGeneralCustomArgumentsDontSave");
            this.rbSettingsGeneralCustomArgumentsDontSave.UseVisualStyleBackColor = true;
            // 
            // chkSettingsGeneralClearUrlOnDownload
            // 
            this.chkSettingsGeneralClearUrlOnDownload.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkSettingsGeneralClearUrlOnDownload.AutoSize = true;
            this.chkSettingsGeneralClearUrlOnDownload.Location = new System.Drawing.Point(52, 231);
            this.chkSettingsGeneralClearUrlOnDownload.Name = "chkSettingsGeneralClearUrlOnDownload";
            this.chkSettingsGeneralClearUrlOnDownload.Size = new System.Drawing.Size(236, 17);
            this.chkSettingsGeneralClearUrlOnDownload.TabIndex = 12;
            this.chkSettingsGeneralClearUrlOnDownload.Text = "chkSettingsGeneralClearUrlOnDownload";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralClearUrlOnDownload, "chkSettingsGeneralClearUrlOnDownloadHint");
            this.chkSettingsGeneralClearUrlOnDownload.UseVisualStyleBackColor = true;
            // 
            // chkSettingsGeneralHoverOverUrlToPasteClipboard
            // 
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.AutoSize = true;
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Checked = true;
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Location = new System.Drawing.Point(27, 210);
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Name = "chkSettingsGeneralHoverOverUrlToPasteClipboard";
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Size = new System.Drawing.Size(284, 17);
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.TabIndex = 11;
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Text = "chkSettingsGeneralHoverOverUrlToPasteClipboard";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralHoverOverUrlToPasteClipboard, "chkSettingsGeneralHoverOverUrlToPasteClipboard");
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.UseVisualStyleBackColor = true;
            // 
            // chkSettingsGeneralCheckForUpdatesOnLaunch
            // 
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.AutoSize = true;
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.Location = new System.Drawing.Point(33, 126);
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.Name = "chkSettingsGeneralCheckForUpdatesOnLaunch";
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.Size = new System.Drawing.Size(269, 17);
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.TabIndex = 10;
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.Text = "chkSettingsGeneralCheckForUpdatesOnLaunch";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralCheckForUpdatesOnLaunch, "chkSettingsGeneralCheckForUpdatesOnLaunch");
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.UseVisualStyleBackColor = true;
            // 
            // tcExternalApplications
            // 
            this.tcExternalApplications.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcExternalApplications.Controls.Add(this.tabSettingsGeneralYoutubeDl);
            this.tcExternalApplications.Controls.Add(this.tabSettingsGeneralFfmpeg);
            this.tcExternalApplications.Location = new System.Drawing.Point(6, 2);
            this.tcExternalApplications.Name = "tcExternalApplications";
            this.tcExternalApplications.SelectedIndex = 0;
            this.tcExternalApplications.Size = new System.Drawing.Size(306, 110);
            this.tcExternalApplications.TabIndex = 19;
            // 
            // tabSettingsGeneralYoutubeDl
            // 
            this.tabSettingsGeneralYoutubeDl.Controls.Add(this.chkSettingsGeneralUseStaticYoutubeDl);
            this.tabSettingsGeneralYoutubeDl.Controls.Add(this.lbSettingsGeneralYoutubeDlPath);
            this.tabSettingsGeneralYoutubeDl.Controls.Add(this.btnSettingsRedownloadYoutubeDl);
            this.tabSettingsGeneralYoutubeDl.Controls.Add(this.txtSettingsGeneralYoutubeDlPath);
            this.tabSettingsGeneralYoutubeDl.Controls.Add(this.btnSettingsGeneralBrowseYoutubeDl);
            this.tabSettingsGeneralYoutubeDl.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsGeneralYoutubeDl.Name = "tabSettingsGeneralYoutubeDl";
            this.tabSettingsGeneralYoutubeDl.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsGeneralYoutubeDl.Size = new System.Drawing.Size(298, 84);
            this.tabSettingsGeneralYoutubeDl.TabIndex = 0;
            this.tabSettingsGeneralYoutubeDl.Text = "tabSettingsGeneralYoutubeDl";
            this.tabSettingsGeneralYoutubeDl.UseVisualStyleBackColor = true;
            // 
            // chkSettingsGeneralUseStaticYoutubeDl
            // 
            this.chkSettingsGeneralUseStaticYoutubeDl.AutoSize = true;
            this.chkSettingsGeneralUseStaticYoutubeDl.Location = new System.Drawing.Point(105, 6);
            this.chkSettingsGeneralUseStaticYoutubeDl.Name = "chkSettingsGeneralUseStaticYoutubeDl";
            this.chkSettingsGeneralUseStaticYoutubeDl.Size = new System.Drawing.Size(225, 17);
            this.chkSettingsGeneralUseStaticYoutubeDl.TabIndex = 2;
            this.chkSettingsGeneralUseStaticYoutubeDl.Text = "chkSettingsGeneralUseStaticYoutubeDl";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralUseStaticYoutubeDl, "chkSettingsGeneralUseStaticYoutubeDl");
            this.chkSettingsGeneralUseStaticYoutubeDl.UseVisualStyleBackColor = true;
            this.chkSettingsGeneralUseStaticYoutubeDl.CheckedChanged += new System.EventHandler(this.chkSettingsGeneralUseStaticYoutubeDl_CheckedChanged);
            // 
            // lbSettingsGeneralYoutubeDlPath
            // 
            this.lbSettingsGeneralYoutubeDlPath.AutoSize = true;
            this.lbSettingsGeneralYoutubeDlPath.Location = new System.Drawing.Point(2, 7);
            this.lbSettingsGeneralYoutubeDlPath.Name = "lbSettingsGeneralYoutubeDlPath";
            this.lbSettingsGeneralYoutubeDlPath.Size = new System.Drawing.Size(175, 13);
            this.lbSettingsGeneralYoutubeDlPath.TabIndex = 1;
            this.lbSettingsGeneralYoutubeDlPath.Text = "lbSettingsGeneralYoutubeDlPath";
            this.tipSettings.SetToolTip(this.lbSettingsGeneralYoutubeDlPath, "lbSettingsGeneralYoutubeDlPath");
            // 
            // btnSettingsRedownloadYoutubeDl
            // 
            this.btnSettingsRedownloadYoutubeDl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSettingsRedownloadYoutubeDl.Location = new System.Drawing.Point(46, 55);
            this.btnSettingsRedownloadYoutubeDl.Name = "btnSettingsRedownloadYoutubeDl";
            this.btnSettingsRedownloadYoutubeDl.Size = new System.Drawing.Size(207, 23);
            this.btnSettingsRedownloadYoutubeDl.TabIndex = 1;
            this.btnSettingsRedownloadYoutubeDl.Text = "btnSettingsRedownloadYoutubeDl";
            this.tipSettings.SetToolTip(this.btnSettingsRedownloadYoutubeDl, "btnSettingsRedownloadYoutubeDl");
            this.btnSettingsRedownloadYoutubeDl.UseVisualStyleBackColor = true;
            this.btnSettingsRedownloadYoutubeDl.Click += new System.EventHandler(this.btnSettingsRedownloadYoutubeDl_Click);
            // 
            // txtSettingsGeneralYoutubeDlPath
            // 
            this.txtSettingsGeneralYoutubeDlPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsGeneralYoutubeDlPath.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtSettingsGeneralYoutubeDlPath.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtSettingsGeneralYoutubeDlPath.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettingsGeneralYoutubeDlPath.ButtonImageIndex = -1;
            this.txtSettingsGeneralYoutubeDlPath.ButtonSize = new System.Drawing.Size(22, 21);
            this.txtSettingsGeneralYoutubeDlPath.ButtonText = "";
            this.txtSettingsGeneralYoutubeDlPath.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtSettingsGeneralYoutubeDlPath.Location = new System.Drawing.Point(13, 27);
            this.txtSettingsGeneralYoutubeDlPath.Name = "txtSettingsGeneralYoutubeDlPath";
            this.txtSettingsGeneralYoutubeDlPath.ReadOnly = true;
            this.txtSettingsGeneralYoutubeDlPath.RegexPatterns = null;
            this.txtSettingsGeneralYoutubeDlPath.Size = new System.Drawing.Size(233, 22);
            this.txtSettingsGeneralYoutubeDlPath.TabIndex = 3;
            this.tipSettings.SetToolTip(this.txtSettingsGeneralYoutubeDlPath, "txtYtdl");
            // 
            // btnSettingsGeneralBrowseYoutubeDl
            // 
            this.btnSettingsGeneralBrowseYoutubeDl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsGeneralBrowseYoutubeDl.Location = new System.Drawing.Point(252, 25);
            this.btnSettingsGeneralBrowseYoutubeDl.Name = "btnSettingsGeneralBrowseYoutubeDl";
            this.btnSettingsGeneralBrowseYoutubeDl.Size = new System.Drawing.Size(33, 23);
            this.btnSettingsGeneralBrowseYoutubeDl.TabIndex = 4;
            this.btnSettingsGeneralBrowseYoutubeDl.Text = "...";
            this.tipSettings.SetToolTip(this.btnSettingsGeneralBrowseYoutubeDl, "btnBrwsYtdl");
            this.btnSettingsGeneralBrowseYoutubeDl.UseVisualStyleBackColor = true;
            this.btnSettingsGeneralBrowseYoutubeDl.Click += new System.EventHandler(this.btnSettingsGeneralBrowseYoutubeDl_Click);
            // 
            // tabSettingsGeneralFfmpeg
            // 
            this.tabSettingsGeneralFfmpeg.Controls.Add(this.chkSettingsGeneralUseStaticFFmpeg);
            this.tabSettingsGeneralFfmpeg.Controls.Add(this.btnSettingsGeneralBrowseFFmpeg);
            this.tabSettingsGeneralFfmpeg.Controls.Add(this.btnSettingsRedownloadFfmpeg);
            this.tabSettingsGeneralFfmpeg.Controls.Add(this.txtSettingsGeneralFFmpegPath);
            this.tabSettingsGeneralFfmpeg.Controls.Add(this.lbSettingsGeneralFFmpegDirectory);
            this.tabSettingsGeneralFfmpeg.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsGeneralFfmpeg.Name = "tabSettingsGeneralFfmpeg";
            this.tabSettingsGeneralFfmpeg.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsGeneralFfmpeg.Size = new System.Drawing.Size(298, 84);
            this.tabSettingsGeneralFfmpeg.TabIndex = 1;
            this.tabSettingsGeneralFfmpeg.Text = "tabSettingsGeneralFfmpeg";
            this.tabSettingsGeneralFfmpeg.UseVisualStyleBackColor = true;
            // 
            // chkSettingsGeneralUseStaticFFmpeg
            // 
            this.chkSettingsGeneralUseStaticFFmpeg.AutoSize = true;
            this.chkSettingsGeneralUseStaticFFmpeg.Location = new System.Drawing.Point(105, 6);
            this.chkSettingsGeneralUseStaticFFmpeg.Name = "chkSettingsGeneralUseStaticFFmpeg";
            this.chkSettingsGeneralUseStaticFFmpeg.Size = new System.Drawing.Size(213, 17);
            this.chkSettingsGeneralUseStaticFFmpeg.TabIndex = 6;
            this.chkSettingsGeneralUseStaticFFmpeg.Text = "chkSettingsGeneralUseStaticFFmpeg";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralUseStaticFFmpeg, "chkSettingsGeneralUseStaticFFmpeg");
            this.chkSettingsGeneralUseStaticFFmpeg.UseVisualStyleBackColor = true;
            this.chkSettingsGeneralUseStaticFFmpeg.CheckedChanged += new System.EventHandler(this.chkSettingsGeneralUseStaticFFmpeg_CheckedChanged);
            // 
            // btnSettingsGeneralBrowseFFmpeg
            // 
            this.btnSettingsGeneralBrowseFFmpeg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsGeneralBrowseFFmpeg.Location = new System.Drawing.Point(252, 25);
            this.btnSettingsGeneralBrowseFFmpeg.Name = "btnSettingsGeneralBrowseFFmpeg";
            this.btnSettingsGeneralBrowseFFmpeg.Size = new System.Drawing.Size(33, 23);
            this.btnSettingsGeneralBrowseFFmpeg.TabIndex = 8;
            this.btnSettingsGeneralBrowseFFmpeg.Text = "...";
            this.tipSettings.SetToolTip(this.btnSettingsGeneralBrowseFFmpeg, "btnBrwsFF");
            this.btnSettingsGeneralBrowseFFmpeg.UseVisualStyleBackColor = true;
            this.btnSettingsGeneralBrowseFFmpeg.Click += new System.EventHandler(this.btnSettingsGeneralBrowseFFmpeg_Click);
            // 
            // btnSettingsRedownloadFfmpeg
            // 
            this.btnSettingsRedownloadFfmpeg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSettingsRedownloadFfmpeg.Location = new System.Drawing.Point(46, 55);
            this.btnSettingsRedownloadFfmpeg.Name = "btnSettingsRedownloadFfmpeg";
            this.btnSettingsRedownloadFfmpeg.Size = new System.Drawing.Size(207, 23);
            this.btnSettingsRedownloadFfmpeg.TabIndex = 2;
            this.btnSettingsRedownloadFfmpeg.Text = "btnSettingsRedownloadFfmpeg";
            this.tipSettings.SetToolTip(this.btnSettingsRedownloadFfmpeg, "btnSettingsRedownloadYoutubeDl");
            this.btnSettingsRedownloadFfmpeg.UseVisualStyleBackColor = true;
            this.btnSettingsRedownloadFfmpeg.Click += new System.EventHandler(this.btnSettingsRedownloadFfmpeg_Click);
            // 
            // txtSettingsGeneralFFmpegPath
            // 
            this.txtSettingsGeneralFFmpegPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsGeneralFFmpegPath.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtSettingsGeneralFFmpegPath.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtSettingsGeneralFFmpegPath.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettingsGeneralFFmpegPath.ButtonImageIndex = -1;
            this.txtSettingsGeneralFFmpegPath.ButtonSize = new System.Drawing.Size(22, 21);
            this.txtSettingsGeneralFFmpegPath.ButtonText = "";
            this.txtSettingsGeneralFFmpegPath.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtSettingsGeneralFFmpegPath.Location = new System.Drawing.Point(13, 27);
            this.txtSettingsGeneralFFmpegPath.Name = "txtSettingsGeneralFFmpegPath";
            this.txtSettingsGeneralFFmpegPath.ReadOnly = true;
            this.txtSettingsGeneralFFmpegPath.RegexPatterns = null;
            this.txtSettingsGeneralFFmpegPath.Size = new System.Drawing.Size(233, 22);
            this.txtSettingsGeneralFFmpegPath.TabIndex = 7;
            this.tipSettings.SetToolTip(this.txtSettingsGeneralFFmpegPath, "txtFFmpeg");
            // 
            // lbSettingsGeneralFFmpegDirectory
            // 
            this.lbSettingsGeneralFFmpegDirectory.AutoSize = true;
            this.lbSettingsGeneralFFmpegDirectory.Location = new System.Drawing.Point(2, 7);
            this.lbSettingsGeneralFFmpegDirectory.Name = "lbSettingsGeneralFFmpegDirectory";
            this.lbSettingsGeneralFFmpegDirectory.Size = new System.Drawing.Size(186, 13);
            this.lbSettingsGeneralFFmpegDirectory.TabIndex = 2;
            this.lbSettingsGeneralFFmpegDirectory.Text = "lbSettingsGeneralFFmpegDirectory";
            this.tipSettings.SetToolTip(this.lbSettingsGeneralFFmpegDirectory, "lbSettingsGeneralFFmpegDirectory");
            // 
            // tabSettingsDownloads
            // 
            this.tabSettingsDownloads.Controls.Add(this.chkSettingsDownloadsDownloadPathUseRelativePath);
            this.tabSettingsDownloads.Controls.Add(this.tabDownloads);
            this.tabSettingsDownloads.Controls.Add(this.llSettingsDownloadsSchemaHelp);
            this.tabSettingsDownloads.Controls.Add(this.lbSettingsDownloadsDownloadPath);
            this.tabSettingsDownloads.Controls.Add(this.txtSettingsDownloadsSavePath);
            this.tabSettingsDownloads.Controls.Add(this.btnSettingsDownloadsBrowseSavePath);
            this.tabSettingsDownloads.Controls.Add(this.lbSepDownloads);
            this.tabSettingsDownloads.Controls.Add(this.lbSettingsDownloadsFileNameSchema);
            this.tabSettingsDownloads.Controls.Add(this.txtSettingsDownloadsFileNameSchema);
            this.tabSettingsDownloads.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsDownloads.Name = "tabSettingsDownloads";
            this.tabSettingsDownloads.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsDownloads.Size = new System.Drawing.Size(320, 362);
            this.tabSettingsDownloads.TabIndex = 1;
            this.tabSettingsDownloads.Text = "tabSettingsDownloads";
            this.tabSettingsDownloads.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsDownloadPathUseRelativePath
            // 
            this.chkSettingsDownloadsDownloadPathUseRelativePath.AutoSize = true;
            this.chkSettingsDownloadsDownloadPathUseRelativePath.Location = new System.Drawing.Point(10, 36);
            this.chkSettingsDownloadsDownloadPathUseRelativePath.Name = "chkSettingsDownloadsDownloadPathUseRelativePath";
            this.chkSettingsDownloadsDownloadPathUseRelativePath.Size = new System.Drawing.Size(14, 13);
            this.chkSettingsDownloadsDownloadPathUseRelativePath.TabIndex = 10;
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsDownloadPathUseRelativePath, "chkSettingsDownloadsDownloadPathUseRelativePathHint");
            this.chkSettingsDownloadsDownloadPathUseRelativePath.UseVisualStyleBackColor = true;
            this.chkSettingsDownloadsDownloadPathUseRelativePath.CheckedChanged += new System.EventHandler(this.chkSettingsDownloadsDownloadPathUseRelativePath_CheckedChanged);
            // 
            // tabDownloads
            // 
            this.tabDownloads.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDownloads.Controls.Add(this.tabDownloadsGeneral);
            this.tabDownloads.Controls.Add(this.tabDownloadsSorting);
            this.tabDownloads.Controls.Add(this.tabDownloadsFixes);
            this.tabDownloads.Controls.Add(this.tabDownloadsConnection);
            this.tabDownloads.Controls.Add(this.tabDownloadsUpdating);
            this.tabDownloads.Controls.Add(this.tabDownloadsBatch);
            this.tabDownloads.Controls.Add(this.tabYtdlpExtendedOptions);
            this.tabDownloads.Location = new System.Drawing.Point(6, 116);
            this.tabDownloads.Name = "tabDownloads";
            this.tabDownloads.SelectedIndex = 0;
            this.tabDownloads.Size = new System.Drawing.Size(308, 223);
            this.tabDownloads.TabIndex = 8;
            // 
            // tabDownloadsGeneral
            // 
            this.tabDownloadsGeneral.Controls.Add(this.chkSettingsDownloadsKeepOriginalFiles);
            this.tabDownloadsGeneral.Controls.Add(this.chkSettingsDownloadsWriteMetadataToFile);
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
            this.tabDownloadsGeneral.Size = new System.Drawing.Size(300, 197);
            this.tabDownloadsGeneral.TabIndex = 0;
            this.tabDownloadsGeneral.Text = "tabDownloadsGeneral";
            this.tabDownloadsGeneral.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsKeepOriginalFiles
            // 
            this.chkSettingsDownloadsKeepOriginalFiles.AutoSize = true;
            this.chkSettingsDownloadsKeepOriginalFiles.Location = new System.Drawing.Point(224, 75);
            this.chkSettingsDownloadsKeepOriginalFiles.Name = "chkSettingsDownloadsKeepOriginalFiles";
            this.chkSettingsDownloadsKeepOriginalFiles.Size = new System.Drawing.Size(234, 17);
            this.chkSettingsDownloadsKeepOriginalFiles.TabIndex = 7;
            this.chkSettingsDownloadsKeepOriginalFiles.Text = "chkSettingsDownloadsKeepOriginalFiles";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsKeepOriginalFiles, "chkSettingsDownloadsKeepOriginalFilesHint");
            this.chkSettingsDownloadsKeepOriginalFiles.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsWriteMetadataToFile
            // 
            this.chkSettingsDownloadsWriteMetadataToFile.AutoSize = true;
            this.chkSettingsDownloadsWriteMetadataToFile.Location = new System.Drawing.Point(216, 52);
            this.chkSettingsDownloadsWriteMetadataToFile.Name = "chkSettingsDownloadsWriteMetadataToFile";
            this.chkSettingsDownloadsWriteMetadataToFile.Size = new System.Drawing.Size(251, 17);
            this.chkSettingsDownloadsWriteMetadataToFile.TabIndex = 5;
            this.chkSettingsDownloadsWriteMetadataToFile.Text = "chkSettingsDownloadsWriteMetadataToFile";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsWriteMetadataToFile, "chkSettingsDownloadsWriteMetadataToFileHint");
            this.chkSettingsDownloadsWriteMetadataToFile.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsEmbedSubtitles
            // 
            this.chkSettingsDownloadsEmbedSubtitles.AutoSize = true;
            this.chkSettingsDownloadsEmbedSubtitles.Location = new System.Drawing.Point(234, 29);
            this.chkSettingsDownloadsEmbedSubtitles.Name = "chkSettingsDownloadsEmbedSubtitles";
            this.chkSettingsDownloadsEmbedSubtitles.Size = new System.Drawing.Size(224, 17);
            this.chkSettingsDownloadsEmbedSubtitles.TabIndex = 3;
            this.chkSettingsDownloadsEmbedSubtitles.Text = "chkSettingsDownloadsEmbedSubtitles";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsEmbedSubtitles, "chkSettingsDownloadsEmbedSubtitlesHint");
            this.chkSettingsDownloadsEmbedSubtitles.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsEmbedThumbnails
            // 
            this.chkSettingsDownloadsEmbedThumbnails.AutoSize = true;
            this.chkSettingsDownloadsEmbedThumbnails.Location = new System.Drawing.Point(225, 121);
            this.chkSettingsDownloadsEmbedThumbnails.Name = "chkSettingsDownloadsEmbedThumbnails";
            this.chkSettingsDownloadsEmbedThumbnails.Size = new System.Drawing.Size(239, 17);
            this.chkSettingsDownloadsEmbedThumbnails.TabIndex = 10;
            this.chkSettingsDownloadsEmbedThumbnails.Text = "chkSettingsDownloadsEmbedThumbnails";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsEmbedThumbnails, "chkSettingsDownloadsEmbedSubtitlesHint");
            this.chkSettingsDownloadsEmbedThumbnails.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsSaveThumbnails
            // 
            this.chkSettingsDownloadsSaveThumbnails.AutoSize = true;
            this.chkSettingsDownloadsSaveThumbnails.Location = new System.Drawing.Point(6, 121);
            this.chkSettingsDownloadsSaveThumbnails.Name = "chkSettingsDownloadsSaveThumbnails";
            this.chkSettingsDownloadsSaveThumbnails.Size = new System.Drawing.Size(227, 17);
            this.chkSettingsDownloadsSaveThumbnails.TabIndex = 9;
            this.chkSettingsDownloadsSaveThumbnails.Text = "chkSettingsDownloadsSaveThumbnails";
            this.chkSettingsDownloadsSaveThumbnails.UseVisualStyleBackColor = true;
            this.chkSettingsDownloadsSaveThumbnails.CheckedChanged += new System.EventHandler(this.chkSettingsDownloadsSaveThumbnails_CheckedChanged);
            // 
            // chkSettingsDownloadsSaveFormatQuality
            // 
            this.chkSettingsDownloadsSaveFormatQuality.AutoSize = true;
            this.chkSettingsDownloadsSaveFormatQuality.Location = new System.Drawing.Point(6, 6);
            this.chkSettingsDownloadsSaveFormatQuality.Name = "chkSettingsDownloadsSaveFormatQuality";
            this.chkSettingsDownloadsSaveFormatQuality.Size = new System.Drawing.Size(239, 17);
            this.chkSettingsDownloadsSaveFormatQuality.TabIndex = 1;
            this.chkSettingsDownloadsSaveFormatQuality.Text = "chkSettingsDownloadsSaveFormatQuality";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsSaveFormatQuality, "chkSettingsDownloadsSaveFormatQuality");
            this.chkSettingsDownloadsSaveFormatQuality.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsSaveAnnotations
            // 
            this.chkSettingsDownloadsSaveAnnotations.AutoSize = true;
            this.chkSettingsDownloadsSaveAnnotations.Location = new System.Drawing.Point(6, 98);
            this.chkSettingsDownloadsSaveAnnotations.Name = "chkSettingsDownloadsSaveAnnotations";
            this.chkSettingsDownloadsSaveAnnotations.Size = new System.Drawing.Size(231, 17);
            this.chkSettingsDownloadsSaveAnnotations.TabIndex = 8;
            this.chkSettingsDownloadsSaveAnnotations.Text = "chkSettingsDownloadsSaveAnnotations";
            this.chkSettingsDownloadsSaveAnnotations.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing
            // 
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.AutoSize = true;
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Location = new System.Drawing.Point(6, 144);
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Name = "chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing";
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Size = new System.Drawing.Size(369, 17);
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.TabIndex = 11;
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Text = "chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing, "chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing");
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.UseVisualStyleBackColor = true;
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Visible = false;
            // 
            // chkSettingsDownloadsSaveDescription
            // 
            this.chkSettingsDownloadsSaveDescription.AutoSize = true;
            this.chkSettingsDownloadsSaveDescription.Location = new System.Drawing.Point(6, 75);
            this.chkSettingsDownloadsSaveDescription.Name = "chkSettingsDownloadsSaveDescription";
            this.chkSettingsDownloadsSaveDescription.Size = new System.Drawing.Size(226, 17);
            this.chkSettingsDownloadsSaveDescription.TabIndex = 6;
            this.chkSettingsDownloadsSaveDescription.Text = "chkSettingsDownloadsSaveDescription";
            this.chkSettingsDownloadsSaveDescription.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsDownloadSubtitles
            // 
            this.chkSettingsDownloadsDownloadSubtitles.AutoSize = true;
            this.chkSettingsDownloadsDownloadSubtitles.Location = new System.Drawing.Point(6, 29);
            this.chkSettingsDownloadsDownloadSubtitles.Name = "chkSettingsDownloadsDownloadSubtitles";
            this.chkSettingsDownloadsDownloadSubtitles.Size = new System.Drawing.Size(243, 17);
            this.chkSettingsDownloadsDownloadSubtitles.TabIndex = 2;
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
            this.chkSettingsDownloadsSaveVideoInfo.Size = new System.Drawing.Size(218, 17);
            this.chkSettingsDownloadsSaveVideoInfo.TabIndex = 4;
            this.chkSettingsDownloadsSaveVideoInfo.Text = "chkSettingsDownloadsSaveVideoInfo";
            this.chkSettingsDownloadsSaveVideoInfo.UseVisualStyleBackColor = true;
            // 
            // tabDownloadsSorting
            // 
            this.tabDownloadsSorting.Controls.Add(this.chkSettingsDownloadsWebsiteSubdomains);
            this.tabDownloadsSorting.Controls.Add(this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders);
            this.tabDownloadsSorting.Controls.Add(this.chkSettingsDownloadsSeparateIntoWebsiteUrl);
            this.tabDownloadsSorting.Location = new System.Drawing.Point(4, 22);
            this.tabDownloadsSorting.Name = "tabDownloadsSorting";
            this.tabDownloadsSorting.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownloadsSorting.Size = new System.Drawing.Size(300, 197);
            this.tabDownloadsSorting.TabIndex = 3;
            this.tabDownloadsSorting.Text = "tabDownloadsSorting";
            this.tabDownloadsSorting.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsWebsiteSubdomains
            // 
            this.chkSettingsDownloadsWebsiteSubdomains.AutoSize = true;
            this.chkSettingsDownloadsWebsiteSubdomains.Location = new System.Drawing.Point(6, 52);
            this.chkSettingsDownloadsWebsiteSubdomains.Name = "chkSettingsDownloadsWebsiteSubdomains";
            this.chkSettingsDownloadsWebsiteSubdomains.Size = new System.Drawing.Size(250, 17);
            this.chkSettingsDownloadsWebsiteSubdomains.TabIndex = 3;
            this.chkSettingsDownloadsWebsiteSubdomains.Text = "chkSettingsDownloadsWebsiteSubdomains";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsWebsiteSubdomains, "chkSettingsDownloadsWebsiteSubdomainsHint");
            this.chkSettingsDownloadsWebsiteSubdomains.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsSeparateDownloadsToDifferentFolders
            // 
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.AutoSize = true;
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Checked = true;
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Location = new System.Drawing.Point(6, 6);
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Name = "chkSettingsDownloadsSeparateDownloadsToDifferentFolders";
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Size = new System.Drawing.Size(344, 17);
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.TabIndex = 1;
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
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.Size = new System.Drawing.Size(267, 17);
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.TabIndex = 2;
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.Text = "chkSettingsDownloadsSeparateIntoWebsiteUrl";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsSeparateIntoWebsiteUrl, "chkSettingsDownloadsSeparateIntoWebsiteUrl");
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.UseVisualStyleBackColor = true;
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.CheckedChanged += new System.EventHandler(this.chkSettingsDownloadsSeparateIntoWebsiteUrl_CheckedChanged);
            // 
            // tabDownloadsFixes
            // 
            this.tabDownloadsFixes.Controls.Add(this.chkSettingsDownloadsPreferFFmpeg);
            this.tabDownloadsFixes.Controls.Add(this.chkSettingsDownloadsFixVReddIt);
            this.tabDownloadsFixes.Location = new System.Drawing.Point(4, 22);
            this.tabDownloadsFixes.Name = "tabDownloadsFixes";
            this.tabDownloadsFixes.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownloadsFixes.Size = new System.Drawing.Size(300, 197);
            this.tabDownloadsFixes.TabIndex = 4;
            this.tabDownloadsFixes.Text = "tabDownloadsFixes";
            this.tabDownloadsFixes.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsPreferFFmpeg
            // 
            this.chkSettingsDownloadsPreferFFmpeg.AutoSize = true;
            this.chkSettingsDownloadsPreferFFmpeg.Location = new System.Drawing.Point(6, 29);
            this.chkSettingsDownloadsPreferFFmpeg.Name = "chkSettingsDownloadsPreferFFmpeg";
            this.chkSettingsDownloadsPreferFFmpeg.Size = new System.Drawing.Size(215, 17);
            this.chkSettingsDownloadsPreferFFmpeg.TabIndex = 2;
            this.chkSettingsDownloadsPreferFFmpeg.Text = "chkSettingsDownloadsPreferFFmpeg";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsPreferFFmpeg, "chkSettingsDownloadsPreferFFmpegHint");
            this.chkSettingsDownloadsPreferFFmpeg.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsFixVReddIt
            // 
            this.chkSettingsDownloadsFixVReddIt.AutoSize = true;
            this.chkSettingsDownloadsFixVReddIt.Checked = true;
            this.chkSettingsDownloadsFixVReddIt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsDownloadsFixVReddIt.Location = new System.Drawing.Point(6, 6);
            this.chkSettingsDownloadsFixVReddIt.Name = "chkSettingsDownloadsFixVReddIt";
            this.chkSettingsDownloadsFixVReddIt.Size = new System.Drawing.Size(199, 17);
            this.chkSettingsDownloadsFixVReddIt.TabIndex = 1;
            this.chkSettingsDownloadsFixVReddIt.Text = "chkSettingsDownloadsFixVReddIt";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsFixVReddIt, "chkSettingsDownloadsFixVReddItHint");
            this.chkSettingsDownloadsFixVReddIt.UseVisualStyleBackColor = true;
            // 
            // tabDownloadsConnection
            // 
            this.tabDownloadsConnection.Controls.Add(this.cbSettingsDownloadsProxyType);
            this.tabDownloadsConnection.Controls.Add(this.chkSettingsDownloadsForceIpv6);
            this.tabDownloadsConnection.Controls.Add(this.chkSettingsDownloadsForceIpv4);
            this.tabDownloadsConnection.Controls.Add(this.chkSettingsDownloadsUseProxy);
            this.tabDownloadsConnection.Controls.Add(this.numSettingsDownloadsRetryAttempts);
            this.tabDownloadsConnection.Controls.Add(this.lbSettingsDownloadsRetryAttempts);
            this.tabDownloadsConnection.Controls.Add(this.cbSettingsDownloadsLimitDownload);
            this.tabDownloadsConnection.Controls.Add(this.numSettingsDownloadsLimitDownload);
            this.tabDownloadsConnection.Controls.Add(this.lbSettingsDownloadsIpPort);
            this.tabDownloadsConnection.Controls.Add(this.chkSettingsDownloadsLimitDownload);
            this.tabDownloadsConnection.Controls.Add(this.txtSettingsDownloadsProxyPort);
            this.tabDownloadsConnection.Controls.Add(this.txtSettingsDownloadsProxyIp);
            this.tabDownloadsConnection.Location = new System.Drawing.Point(4, 22);
            this.tabDownloadsConnection.Name = "tabDownloadsConnection";
            this.tabDownloadsConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownloadsConnection.Size = new System.Drawing.Size(300, 197);
            this.tabDownloadsConnection.TabIndex = 1;
            this.tabDownloadsConnection.Text = "tabDownloadsConnection";
            this.tabDownloadsConnection.UseVisualStyleBackColor = true;
            // 
            // cbSettingsDownloadsProxyType
            // 
            this.cbSettingsDownloadsProxyType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSettingsDownloadsProxyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSettingsDownloadsProxyType.FormattingEnabled = true;
            this.cbSettingsDownloadsProxyType.Items.AddRange(new object[] {
            "https://",
            "http://",
            "socks4://",
            "socks5://"});
            this.cbSettingsDownloadsProxyType.Location = new System.Drawing.Point(9, 161);
            this.cbSettingsDownloadsProxyType.Name = "cbSettingsDownloadsProxyType";
            this.cbSettingsDownloadsProxyType.Size = new System.Drawing.Size(77, 21);
            this.cbSettingsDownloadsProxyType.TabIndex = 9;
            this.tipSettings.SetToolTip(this.cbSettingsDownloadsProxyType, "cbSettingsDownloadsProxyTypeHint");
            // 
            // chkSettingsDownloadsForceIpv6
            // 
            this.chkSettingsDownloadsForceIpv6.AutoSize = true;
            this.chkSettingsDownloadsForceIpv6.Location = new System.Drawing.Point(6, 81);
            this.chkSettingsDownloadsForceIpv6.Name = "chkSettingsDownloadsForceIpv6";
            this.chkSettingsDownloadsForceIpv6.Size = new System.Drawing.Size(193, 17);
            this.chkSettingsDownloadsForceIpv6.TabIndex = 7;
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
            this.chkSettingsDownloadsForceIpv4.Size = new System.Drawing.Size(193, 17);
            this.chkSettingsDownloadsForceIpv4.TabIndex = 6;
            this.chkSettingsDownloadsForceIpv4.Text = "chkSettingsDownloadsForceIpv4";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsForceIpv4, "chkSettingsDownloadsForceIpv4Hint");
            this.chkSettingsDownloadsForceIpv4.UseVisualStyleBackColor = true;
            this.chkSettingsDownloadsForceIpv4.CheckedChanged += new System.EventHandler(this.chkSettingsDownloadsForceIpv4_CheckedChanged);
            // 
            // chkSettingsDownloadsUseProxy
            // 
            this.chkSettingsDownloadsUseProxy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSettingsDownloadsUseProxy.AutoSize = true;
            this.chkSettingsDownloadsUseProxy.Location = new System.Drawing.Point(6, 140);
            this.chkSettingsDownloadsUseProxy.Name = "chkSettingsDownloadsUseProxy";
            this.chkSettingsDownloadsUseProxy.Size = new System.Drawing.Size(190, 17);
            this.chkSettingsDownloadsUseProxy.TabIndex = 8;
            this.chkSettingsDownloadsUseProxy.Text = "chkSettingsDownloadsUseProxy";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsUseProxy, "chkSettingsDownloadsUseProxy");
            this.chkSettingsDownloadsUseProxy.UseVisualStyleBackColor = true;
            // 
            // numSettingsDownloadsRetryAttempts
            // 
            this.numSettingsDownloadsRetryAttempts.Location = new System.Drawing.Point(115, 29);
            this.numSettingsDownloadsRetryAttempts.Name = "numSettingsDownloadsRetryAttempts";
            this.numSettingsDownloadsRetryAttempts.Size = new System.Drawing.Size(63, 22);
            this.numSettingsDownloadsRetryAttempts.TabIndex = 5;
            this.tipSettings.SetToolTip(this.numSettingsDownloadsRetryAttempts, "numSettingsDownloadsRetryAttemptsHint");
            // 
            // lbSettingsDownloadsRetryAttempts
            // 
            this.lbSettingsDownloadsRetryAttempts.AutoSize = true;
            this.lbSettingsDownloadsRetryAttempts.Location = new System.Drawing.Point(6, 32);
            this.lbSettingsDownloadsRetryAttempts.Name = "lbSettingsDownloadsRetryAttempts";
            this.lbSettingsDownloadsRetryAttempts.Size = new System.Drawing.Size(190, 13);
            this.lbSettingsDownloadsRetryAttempts.TabIndex = 4;
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
            this.cbSettingsDownloadsLimitDownload.Location = new System.Drawing.Point(186, 4);
            this.cbSettingsDownloadsLimitDownload.Name = "cbSettingsDownloadsLimitDownload";
            this.cbSettingsDownloadsLimitDownload.Size = new System.Drawing.Size(44, 21);
            this.cbSettingsDownloadsLimitDownload.TabIndex = 3;
            this.tipSettings.SetToolTip(this.cbSettingsDownloadsLimitDownload, "cbSettingsDownloadsDownloadLimit");
            // 
            // numSettingsDownloadsLimitDownload
            // 
            this.numSettingsDownloadsLimitDownload.Location = new System.Drawing.Point(127, 5);
            this.numSettingsDownloadsLimitDownload.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSettingsDownloadsLimitDownload.Name = "numSettingsDownloadsLimitDownload";
            this.numSettingsDownloadsLimitDownload.Size = new System.Drawing.Size(57, 22);
            this.numSettingsDownloadsLimitDownload.TabIndex = 2;
            this.tipSettings.SetToolTip(this.numSettingsDownloadsLimitDownload, "numSettingsDownloadsDownloadLimitHint");
            // 
            // lbSettingsDownloadsIpPort
            // 
            this.lbSettingsDownloadsIpPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSettingsDownloadsIpPort.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSettingsDownloadsIpPort.Location = new System.Drawing.Point(178, 162);
            this.lbSettingsDownloadsIpPort.Name = "lbSettingsDownloadsIpPort";
            this.lbSettingsDownloadsIpPort.Size = new System.Drawing.Size(12, 20);
            this.lbSettingsDownloadsIpPort.TabIndex = 11;
            this.lbSettingsDownloadsIpPort.Text = ":";
            // 
            // chkSettingsDownloadsLimitDownload
            // 
            this.chkSettingsDownloadsLimitDownload.AutoSize = true;
            this.chkSettingsDownloadsLimitDownload.Location = new System.Drawing.Point(6, 6);
            this.chkSettingsDownloadsLimitDownload.Name = "chkSettingsDownloadsLimitDownload";
            this.chkSettingsDownloadsLimitDownload.Size = new System.Drawing.Size(222, 17);
            this.chkSettingsDownloadsLimitDownload.TabIndex = 1;
            this.chkSettingsDownloadsLimitDownload.Text = "chkSettingsDownloadsLimitDownload";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsLimitDownload, "chkSettingsDownloadsLimitDownloadHint");
            this.chkSettingsDownloadsLimitDownload.UseVisualStyleBackColor = true;
            // 
            // txtSettingsDownloadsProxyPort
            // 
            this.txtSettingsDownloadsProxyPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSettingsDownloadsProxyPort.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtSettingsDownloadsProxyPort.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtSettingsDownloadsProxyPort.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettingsDownloadsProxyPort.ButtonImageIndex = -1;
            this.txtSettingsDownloadsProxyPort.ButtonSize = new System.Drawing.Size(22, 21);
            this.txtSettingsDownloadsProxyPort.ButtonText = "";
            this.txtSettingsDownloadsProxyPort.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtSettingsDownloadsProxyPort.Location = new System.Drawing.Point(189, 162);
            this.txtSettingsDownloadsProxyPort.MaxLength = 5;
            this.txtSettingsDownloadsProxyPort.Name = "txtSettingsDownloadsProxyPort";
            this.txtSettingsDownloadsProxyPort.RegexPatterns = null;
            this.txtSettingsDownloadsProxyPort.Size = new System.Drawing.Size(44, 22);
            this.txtSettingsDownloadsProxyPort.TabIndex = 12;
            this.txtSettingsDownloadsProxyPort.TextHint = "12345";
            this.tipSettings.SetToolTip(this.txtSettingsDownloadsProxyPort, "txtSettingsDownloadsProxyPortHint");
            this.txtSettingsDownloadsProxyPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSettingsDownloadsProxyPort_KeyPress);
            // 
            // txtSettingsDownloadsProxyIp
            // 
            this.txtSettingsDownloadsProxyIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSettingsDownloadsProxyIp.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtSettingsDownloadsProxyIp.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtSettingsDownloadsProxyIp.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettingsDownloadsProxyIp.ButtonImageIndex = -1;
            this.txtSettingsDownloadsProxyIp.ButtonSize = new System.Drawing.Size(22, 21);
            this.txtSettingsDownloadsProxyIp.ButtonText = "";
            this.txtSettingsDownloadsProxyIp.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtSettingsDownloadsProxyIp.Location = new System.Drawing.Point(92, 162);
            this.txtSettingsDownloadsProxyIp.MaxLength = 15;
            this.txtSettingsDownloadsProxyIp.Name = "txtSettingsDownloadsProxyIp";
            this.txtSettingsDownloadsProxyIp.RegexPatterns = null;
            this.txtSettingsDownloadsProxyIp.Size = new System.Drawing.Size(89, 22);
            this.txtSettingsDownloadsProxyIp.TabIndex = 10;
            this.txtSettingsDownloadsProxyIp.TextHint = "255.255.255.255";
            this.tipSettings.SetToolTip(this.txtSettingsDownloadsProxyIp, "txtSettingsDownloadsProxyIpHint");
            this.txtSettingsDownloadsProxyIp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSettingsDownloadsProxyIp_KeyPress);
            // 
            // tabDownloadsUpdating
            // 
            this.tabDownloadsUpdating.Controls.Add(this.llbSettingsDownloadsYtdlTypeViewRepo);
            this.tabDownloadsUpdating.Controls.Add(this.lbSettingsDownloadsUpdatingYtdlType);
            this.tabDownloadsUpdating.Controls.Add(this.cbSettingsDownloadsUpdatingYtdlType);
            this.tabDownloadsUpdating.Controls.Add(this.chksettingsDownloadsUseYoutubeDlsUpdater);
            this.tabDownloadsUpdating.Location = new System.Drawing.Point(4, 22);
            this.tabDownloadsUpdating.Name = "tabDownloadsUpdating";
            this.tabDownloadsUpdating.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownloadsUpdating.Size = new System.Drawing.Size(300, 197);
            this.tabDownloadsUpdating.TabIndex = 2;
            this.tabDownloadsUpdating.Text = "tabDownloadsUpdating";
            this.tabDownloadsUpdating.UseVisualStyleBackColor = true;
            // 
            // llbSettingsDownloadsYtdlTypeViewRepo
            // 
            this.llbSettingsDownloadsYtdlTypeViewRepo.AutoSize = true;
            this.llbSettingsDownloadsYtdlTypeViewRepo.Location = new System.Drawing.Point(194, 54);
            this.llbSettingsDownloadsYtdlTypeViewRepo.Name = "llbSettingsDownloadsYtdlTypeViewRepo";
            this.llbSettingsDownloadsYtdlTypeViewRepo.Size = new System.Drawing.Size(215, 13);
            this.llbSettingsDownloadsYtdlTypeViewRepo.TabIndex = 4;
            this.llbSettingsDownloadsYtdlTypeViewRepo.TabStop = true;
            this.llbSettingsDownloadsYtdlTypeViewRepo.Text = "llbSettingsDownloadsYtdlTypeViewRepo";
            this.tipSettings.SetToolTip(this.llbSettingsDownloadsYtdlTypeViewRepo, "llbSettingsDownloadsYtdlTypeViewRepoHint");
            this.llbSettingsDownloadsYtdlTypeViewRepo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbSettingsDownloadsYtdlTypeViewRepo_LinkClicked);
            // 
            // lbSettingsDownloadsUpdatingYtdlType
            // 
            this.lbSettingsDownloadsUpdatingYtdlType.AutoSize = true;
            this.lbSettingsDownloadsUpdatingYtdlType.Location = new System.Drawing.Point(6, 35);
            this.lbSettingsDownloadsUpdatingYtdlType.Name = "lbSettingsDownloadsUpdatingYtdlType";
            this.lbSettingsDownloadsUpdatingYtdlType.Size = new System.Drawing.Size(209, 13);
            this.lbSettingsDownloadsUpdatingYtdlType.TabIndex = 3;
            this.lbSettingsDownloadsUpdatingYtdlType.Text = "lbSettingsDownloadsUpdatingYtdlType";
            this.lbSettingsDownloadsUpdatingYtdlType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbSettingsDownloadsUpdatingYtdlType
            // 
            this.cbSettingsDownloadsUpdatingYtdlType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSettingsDownloadsUpdatingYtdlType.FormattingEnabled = true;
            this.cbSettingsDownloadsUpdatingYtdlType.Items.AddRange(new object[] {
            "yt-dlp/yt-dlp (Default)",
            "ytdl-org/youtube-dl",
            "blackjack4494/youtube-dlc",
            "ytdl-patched/youtube-dl (nightly)",
            "ytdl-patched/yt-dlp (nightly)"});
            this.cbSettingsDownloadsUpdatingYtdlType.Location = new System.Drawing.Point(9, 51);
            this.cbSettingsDownloadsUpdatingYtdlType.Name = "cbSettingsDownloadsUpdatingYtdlType";
            this.cbSettingsDownloadsUpdatingYtdlType.Size = new System.Drawing.Size(179, 21);
            this.cbSettingsDownloadsUpdatingYtdlType.TabIndex = 2;
            this.tipSettings.SetToolTip(this.cbSettingsDownloadsUpdatingYtdlType, "cbSettingsDownloadsUpdatingYtdlTypeHint");
            this.cbSettingsDownloadsUpdatingYtdlType.SelectedIndexChanged += new System.EventHandler(this.cbSettingsDownloadsUpdatingYtdlType_SelectedIndexChanged);
            // 
            // chksettingsDownloadsUseYoutubeDlsUpdater
            // 
            this.chksettingsDownloadsUseYoutubeDlsUpdater.AutoSize = true;
            this.chksettingsDownloadsUseYoutubeDlsUpdater.Location = new System.Drawing.Point(6, 6);
            this.chksettingsDownloadsUseYoutubeDlsUpdater.Name = "chksettingsDownloadsUseYoutubeDlsUpdater";
            this.chksettingsDownloadsUseYoutubeDlsUpdater.Size = new System.Drawing.Size(262, 17);
            this.chksettingsDownloadsUseYoutubeDlsUpdater.TabIndex = 1;
            this.chksettingsDownloadsUseYoutubeDlsUpdater.Text = "chksettingsDownloadsUseYoutubeDlsUpdater";
            this.tipSettings.SetToolTip(this.chksettingsDownloadsUseYoutubeDlsUpdater, "chksettingsDownloadsUseYoutubeDlsUpdater");
            this.chksettingsDownloadsUseYoutubeDlsUpdater.UseVisualStyleBackColor = true;
            this.chksettingsDownloadsUseYoutubeDlsUpdater.CheckedChanged += new System.EventHandler(this.chksettingsDownloadsUseYoutubeDlsUpdater_CheckedChanged);
            // 
            // tabDownloadsBatch
            // 
            this.tabDownloadsBatch.Controls.Add(this.chkSettingsDownloadsAddDateToBatchDownloadFolders);
            this.tabDownloadsBatch.Controls.Add(this.chkSettingsDownloadsSeparateBatchDownloads);
            this.tabDownloadsBatch.Location = new System.Drawing.Point(4, 22);
            this.tabDownloadsBatch.Name = "tabDownloadsBatch";
            this.tabDownloadsBatch.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownloadsBatch.Size = new System.Drawing.Size(300, 197);
            this.tabDownloadsBatch.TabIndex = 5;
            this.tabDownloadsBatch.Text = "tabDownloadsBatch";
            this.tabDownloadsBatch.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsAddDateToBatchDownloadFolders
            // 
            this.chkSettingsDownloadsAddDateToBatchDownloadFolders.AutoSize = true;
            this.chkSettingsDownloadsAddDateToBatchDownloadFolders.Location = new System.Drawing.Point(6, 29);
            this.chkSettingsDownloadsAddDateToBatchDownloadFolders.Name = "chkSettingsDownloadsAddDateToBatchDownloadFolders";
            this.chkSettingsDownloadsAddDateToBatchDownloadFolders.Size = new System.Drawing.Size(321, 17);
            this.chkSettingsDownloadsAddDateToBatchDownloadFolders.TabIndex = 1;
            this.chkSettingsDownloadsAddDateToBatchDownloadFolders.Text = "chkSettingsDownloadsAddDateToBatchDownloadFolders";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsAddDateToBatchDownloadFolders, "chkSettingsDownloadsAddDateToBatchDownloadFoldersHint");
            this.chkSettingsDownloadsAddDateToBatchDownloadFolders.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsSeparateBatchDownloads
            // 
            this.chkSettingsDownloadsSeparateBatchDownloads.AutoSize = true;
            this.chkSettingsDownloadsSeparateBatchDownloads.Location = new System.Drawing.Point(6, 6);
            this.chkSettingsDownloadsSeparateBatchDownloads.Name = "chkSettingsDownloadsSeparateBatchDownloads";
            this.chkSettingsDownloadsSeparateBatchDownloads.Size = new System.Drawing.Size(276, 17);
            this.chkSettingsDownloadsSeparateBatchDownloads.TabIndex = 0;
            this.chkSettingsDownloadsSeparateBatchDownloads.Text = "chkSettingsDownloadsSeparateBatchDownloads";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsSeparateBatchDownloads, "chkSettingsDownloadsSeparateBatchDownloadsHint");
            this.chkSettingsDownloadsSeparateBatchDownloads.UseVisualStyleBackColor = true;
            // 
            // tabYtdlpExtendedOptions
            // 
            this.tabYtdlpExtendedOptions.Controls.Add(this.chkYtdlpExtendedAutomaticallyDownloadThumbnail);
            this.tabYtdlpExtendedOptions.Controls.Add(this.chkYtdlpPreferExtendedDialog);
            this.tabYtdlpExtendedOptions.Location = new System.Drawing.Point(4, 22);
            this.tabYtdlpExtendedOptions.Name = "tabYtdlpExtendedOptions";
            this.tabYtdlpExtendedOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabYtdlpExtendedOptions.Size = new System.Drawing.Size(300, 197);
            this.tabYtdlpExtendedOptions.TabIndex = 6;
            this.tabYtdlpExtendedOptions.Text = "tabYtdlpExtendedOptions";
            this.tabYtdlpExtendedOptions.UseVisualStyleBackColor = true;
            // 
            // chkYtdlpExtendedAutomaticallyDownloadThumbnail
            // 
            this.chkYtdlpExtendedAutomaticallyDownloadThumbnail.AutoSize = true;
            this.chkYtdlpExtendedAutomaticallyDownloadThumbnail.Location = new System.Drawing.Point(6, 29);
            this.chkYtdlpExtendedAutomaticallyDownloadThumbnail.Name = "chkYtdlpExtendedAutomaticallyDownloadThumbnail";
            this.chkYtdlpExtendedAutomaticallyDownloadThumbnail.Size = new System.Drawing.Size(295, 17);
            this.chkYtdlpExtendedAutomaticallyDownloadThumbnail.TabIndex = 1;
            this.chkYtdlpExtendedAutomaticallyDownloadThumbnail.Text = "chkYtdlpExtendedAutomaticallyDownloadThumbnail";
            this.tipSettings.SetToolTip(this.chkYtdlpExtendedAutomaticallyDownloadThumbnail, "chkYtdlpExtendedAutomaticallyDownloadThumbnailHint");
            this.chkYtdlpExtendedAutomaticallyDownloadThumbnail.UseVisualStyleBackColor = true;
            // 
            // chkYtdlpPreferExtendedDialog
            // 
            this.chkYtdlpPreferExtendedDialog.AutoSize = true;
            this.chkYtdlpPreferExtendedDialog.Location = new System.Drawing.Point(6, 6);
            this.chkYtdlpPreferExtendedDialog.Name = "chkYtdlpPreferExtendedDialog";
            this.chkYtdlpPreferExtendedDialog.Size = new System.Drawing.Size(181, 17);
            this.chkYtdlpPreferExtendedDialog.TabIndex = 0;
            this.chkYtdlpPreferExtendedDialog.Text = "chkYtdlpPreferExtendedDialog";
            this.tipSettings.SetToolTip(this.chkYtdlpPreferExtendedDialog, "chkYtdlpPreferExtendedDialogHint");
            this.chkYtdlpPreferExtendedDialog.UseVisualStyleBackColor = true;
            // 
            // llSettingsDownloadsSchemaHelp
            // 
            this.llSettingsDownloadsSchemaHelp.AutoSize = true;
            this.llSettingsDownloadsSchemaHelp.Location = new System.Drawing.Point(210, 59);
            this.llSettingsDownloadsSchemaHelp.Name = "llSettingsDownloadsSchemaHelp";
            this.llSettingsDownloadsSchemaHelp.Size = new System.Drawing.Size(12, 13);
            this.llSettingsDownloadsSchemaHelp.TabIndex = 5;
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
            this.lbSettingsDownloadsDownloadPath.Size = new System.Drawing.Size(195, 13);
            this.lbSettingsDownloadsDownloadPath.TabIndex = 1;
            this.lbSettingsDownloadsDownloadPath.Text = "lbSettingsDownloadsDownloadPath";
            this.tipSettings.SetToolTip(this.lbSettingsDownloadsDownloadPath, "lbSettingsDownloadsDownloadPath");
            // 
            // txtSettingsDownloadsSavePath
            // 
            this.txtSettingsDownloadsSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsDownloadsSavePath.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtSettingsDownloadsSavePath.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtSettingsDownloadsSavePath.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettingsDownloadsSavePath.ButtonImageIndex = -1;
            this.txtSettingsDownloadsSavePath.ButtonSize = new System.Drawing.Size(22, 21);
            this.txtSettingsDownloadsSavePath.ButtonText = "";
            this.txtSettingsDownloadsSavePath.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtSettingsDownloadsSavePath.Location = new System.Drawing.Point(30, 32);
            this.txtSettingsDownloadsSavePath.Name = "txtSettingsDownloadsSavePath";
            this.txtSettingsDownloadsSavePath.ReadOnly = true;
            this.txtSettingsDownloadsSavePath.RegexPatterns = null;
            this.txtSettingsDownloadsSavePath.Size = new System.Drawing.Size(233, 22);
            this.txtSettingsDownloadsSavePath.TabIndex = 2;
            this.tipSettings.SetToolTip(this.txtSettingsDownloadsSavePath, "txtSaveto");
            // 
            // btnSettingsDownloadsBrowseSavePath
            // 
            this.btnSettingsDownloadsBrowseSavePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsDownloadsBrowseSavePath.Location = new System.Drawing.Point(269, 30);
            this.btnSettingsDownloadsBrowseSavePath.Name = "btnSettingsDownloadsBrowseSavePath";
            this.btnSettingsDownloadsBrowseSavePath.Size = new System.Drawing.Size(33, 23);
            this.btnSettingsDownloadsBrowseSavePath.TabIndex = 3;
            this.btnSettingsDownloadsBrowseSavePath.Text = "...";
            this.tipSettings.SetToolTip(this.btnSettingsDownloadsBrowseSavePath, "btnSettingsDownloadsBrowseSavePath");
            this.btnSettingsDownloadsBrowseSavePath.UseVisualStyleBackColor = true;
            this.btnSettingsDownloadsBrowseSavePath.Click += new System.EventHandler(this.btnSettingsDownloadsBrowseSavePath_Click);
            // 
            // lbSepDownloads
            // 
            this.lbSepDownloads.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSepDownloads.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSepDownloads.Location = new System.Drawing.Point(25, 107);
            this.lbSepDownloads.Name = "lbSepDownloads";
            this.lbSepDownloads.Size = new System.Drawing.Size(270, 2);
            this.lbSepDownloads.TabIndex = 7;
            this.lbSepDownloads.Text = "HELLO WORLD";
            this.tipSettings.SetToolTip(this.lbSepDownloads, "this is not an easter egg");
            // 
            // lbSettingsDownloadsFileNameSchema
            // 
            this.lbSettingsDownloadsFileNameSchema.AutoSize = true;
            this.lbSettingsDownloadsFileNameSchema.Location = new System.Drawing.Point(19, 59);
            this.lbSettingsDownloadsFileNameSchema.Name = "lbSettingsDownloadsFileNameSchema";
            this.lbSettingsDownloadsFileNameSchema.Size = new System.Drawing.Size(204, 13);
            this.lbSettingsDownloadsFileNameSchema.TabIndex = 4;
            this.lbSettingsDownloadsFileNameSchema.Text = "lbSettingsDownloadsFileNameSchema";
            // 
            // txtSettingsDownloadsFileNameSchema
            // 
            this.txtSettingsDownloadsFileNameSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsDownloadsFileNameSchema.FormattingEnabled = true;
            this.txtSettingsDownloadsFileNameSchema.Location = new System.Drawing.Point(30, 79);
            this.txtSettingsDownloadsFileNameSchema.Name = "txtSettingsDownloadsFileNameSchema";
            this.txtSettingsDownloadsFileNameSchema.Size = new System.Drawing.Size(260, 21);
            this.txtSettingsDownloadsFileNameSchema.TabIndex = 9;
            this.txtSettingsDownloadsFileNameSchema.Text = "%(title)s-%(id)s.%(ext)s";
            this.tipSettings.SetToolTip(this.txtSettingsDownloadsFileNameSchema, "txtSettingsDownloadsFileNameSchemaHint");
            this.txtSettingsDownloadsFileNameSchema.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSettingsDownloadsFileNameSchema_KeyPress);
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
            this.tabSettingsConverter.Size = new System.Drawing.Size(320, 362);
            this.tabSettingsConverter.TabIndex = 2;
            this.tabSettingsConverter.Text = "tabSettingsConverterConverter";
            this.tabSettingsConverter.UseVisualStyleBackColor = true;
            // 
            // chkSettingsConverterHideFFmpegCompileInfo
            // 
            this.chkSettingsConverterHideFFmpegCompileInfo.AutoSize = true;
            this.chkSettingsConverterHideFFmpegCompileInfo.Location = new System.Drawing.Point(17, 81);
            this.chkSettingsConverterHideFFmpegCompileInfo.Name = "chkSettingsConverterHideFFmpegCompileInfo";
            this.chkSettingsConverterHideFFmpegCompileInfo.Size = new System.Drawing.Size(263, 17);
            this.chkSettingsConverterHideFFmpegCompileInfo.TabIndex = 4;
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
            this.chkSettingsConverterDetectOutputFileType.Size = new System.Drawing.Size(247, 17);
            this.chkSettingsConverterDetectOutputFileType.TabIndex = 3;
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
            this.tcConverter.TabIndex = 5;
            // 
            // tcSettingsConverterVideo
            // 
            this.tcSettingsConverterVideo.Controls.Add(this.chkSettingsConverterVideoCRF);
            this.tcSettingsConverterVideo.Controls.Add(this.chkSettingsConverterVideoProfile);
            this.tcSettingsConverterVideo.Controls.Add(this.chkSettingsConverterVideoPreset);
            this.tcSettingsConverterVideo.Controls.Add(this.chkSettingsConverterVideoBitrate);
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
            // chkSettingsConverterVideoCRF
            // 
            this.chkSettingsConverterVideoCRF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkSettingsConverterVideoCRF.AutoSize = true;
            this.chkSettingsConverterVideoCRF.Checked = true;
            this.chkSettingsConverterVideoCRF.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsConverterVideoCRF.Location = new System.Drawing.Point(72, 96);
            this.chkSettingsConverterVideoCRF.Name = "chkSettingsConverterVideoCRF";
            this.chkSettingsConverterVideoCRF.Size = new System.Drawing.Size(14, 13);
            this.chkSettingsConverterVideoCRF.TabIndex = 11;
            this.chkSettingsConverterVideoCRF.UseVisualStyleBackColor = true;
            // 
            // chkSettingsConverterVideoProfile
            // 
            this.chkSettingsConverterVideoProfile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkSettingsConverterVideoProfile.AutoSize = true;
            this.chkSettingsConverterVideoProfile.Location = new System.Drawing.Point(72, 70);
            this.chkSettingsConverterVideoProfile.Name = "chkSettingsConverterVideoProfile";
            this.chkSettingsConverterVideoProfile.Size = new System.Drawing.Size(14, 13);
            this.chkSettingsConverterVideoProfile.TabIndex = 8;
            this.chkSettingsConverterVideoProfile.UseVisualStyleBackColor = true;
            // 
            // chkSettingsConverterVideoPreset
            // 
            this.chkSettingsConverterVideoPreset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkSettingsConverterVideoPreset.AutoSize = true;
            this.chkSettingsConverterVideoPreset.Location = new System.Drawing.Point(72, 43);
            this.chkSettingsConverterVideoPreset.Name = "chkSettingsConverterVideoPreset";
            this.chkSettingsConverterVideoPreset.Size = new System.Drawing.Size(14, 13);
            this.chkSettingsConverterVideoPreset.TabIndex = 5;
            this.chkSettingsConverterVideoPreset.UseVisualStyleBackColor = true;
            // 
            // chkSettingsConverterVideoBitrate
            // 
            this.chkSettingsConverterVideoBitrate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkSettingsConverterVideoBitrate.AutoSize = true;
            this.chkSettingsConverterVideoBitrate.Location = new System.Drawing.Point(72, 16);
            this.chkSettingsConverterVideoBitrate.Name = "chkSettingsConverterVideoBitrate";
            this.chkSettingsConverterVideoBitrate.Size = new System.Drawing.Size(14, 13);
            this.chkSettingsConverterVideoBitrate.TabIndex = 1;
            this.chkSettingsConverterVideoBitrate.UseVisualStyleBackColor = true;
            // 
            // chkSettingsConverterVideoFastStart
            // 
            this.chkSettingsConverterVideoFastStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkSettingsConverterVideoFastStart.AutoSize = true;
            this.chkSettingsConverterVideoFastStart.Location = new System.Drawing.Point(117, 126);
            this.chkSettingsConverterVideoFastStart.Name = "chkSettingsConverterVideoFastStart";
            this.chkSettingsConverterVideoFastStart.Size = new System.Drawing.Size(210, 17);
            this.chkSettingsConverterVideoFastStart.TabIndex = 14;
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
            this.numConvertVideoCRF.Size = new System.Drawing.Size(39, 22);
            this.numConvertVideoCRF.TabIndex = 13;
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
            this.cbConvertVideoProfile.TabIndex = 10;
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
            this.cbConvertVideoPreset.TabIndex = 7;
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
            this.numConvertVideoBitrate.Size = new System.Drawing.Size(79, 22);
            this.numConvertVideoBitrate.TabIndex = 3;
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
            this.lbConvertVideoThousands.TabIndex = 4;
            this.lbConvertVideoThousands.Text = "K";
            // 
            // lbSettingsConverterVideoBitrate
            // 
            this.lbSettingsConverterVideoBitrate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSettingsConverterVideoBitrate.AutoSize = true;
            this.lbSettingsConverterVideoBitrate.Location = new System.Drawing.Point(86, 16);
            this.lbSettingsConverterVideoBitrate.Name = "lbSettingsConverterVideoBitrate";
            this.lbSettingsConverterVideoBitrate.Size = new System.Drawing.Size(172, 13);
            this.lbSettingsConverterVideoBitrate.TabIndex = 2;
            this.lbSettingsConverterVideoBitrate.Text = "lbSettingsConverterVideoBitrate";
            this.tipSettings.SetToolTip(this.lbSettingsConverterVideoBitrate, "lbSettingsConverterVideoBitrate");
            this.lbSettingsConverterVideoBitrate.Click += new System.EventHandler(this.lbSettingsConverterVideoBitrate_Click);
            // 
            // lbSettingsConverterVideoPreset
            // 
            this.lbSettingsConverterVideoPreset.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSettingsConverterVideoPreset.AutoSize = true;
            this.lbSettingsConverterVideoPreset.Location = new System.Drawing.Point(86, 43);
            this.lbSettingsConverterVideoPreset.Name = "lbSettingsConverterVideoPreset";
            this.lbSettingsConverterVideoPreset.Size = new System.Drawing.Size(176, 13);
            this.lbSettingsConverterVideoPreset.TabIndex = 6;
            this.lbSettingsConverterVideoPreset.Text = "lbkSettingsConverterVideoPreset";
            this.tipSettings.SetToolTip(this.lbSettingsConverterVideoPreset, "lbSettingsConverterVideoPreset");
            this.lbSettingsConverterVideoPreset.Click += new System.EventHandler(this.lbSettingsConverterVideoPreset_Click);
            // 
            // lbSettingsConverterVideoProfile
            // 
            this.lbSettingsConverterVideoProfile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSettingsConverterVideoProfile.AutoSize = true;
            this.lbSettingsConverterVideoProfile.Location = new System.Drawing.Point(87, 70);
            this.lbSettingsConverterVideoProfile.Name = "lbSettingsConverterVideoProfile";
            this.lbSettingsConverterVideoProfile.Size = new System.Drawing.Size(172, 13);
            this.lbSettingsConverterVideoProfile.TabIndex = 9;
            this.lbSettingsConverterVideoProfile.Text = "lbSettingsConverterVideoProfile";
            this.tipSettings.SetToolTip(this.lbSettingsConverterVideoProfile, "lbSettingsConverterVideoProfile");
            this.lbSettingsConverterVideoProfile.Click += new System.EventHandler(this.lbSettingsConverterVideoProfile_Click);
            // 
            // lbSettingsConverterVideoCRF
            // 
            this.lbSettingsConverterVideoCRF.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSettingsConverterVideoCRF.AutoSize = true;
            this.lbSettingsConverterVideoCRF.Location = new System.Drawing.Point(95, 96);
            this.lbSettingsConverterVideoCRF.Name = "lbSettingsConverterVideoCRF";
            this.lbSettingsConverterVideoCRF.Size = new System.Drawing.Size(159, 13);
            this.lbSettingsConverterVideoCRF.TabIndex = 12;
            this.lbSettingsConverterVideoCRF.Text = "lbSettingsConverterVideoCRF";
            this.tipSettings.SetToolTip(this.lbSettingsConverterVideoCRF, "lbSettingsConverterVideoCRF");
            this.lbSettingsConverterVideoCRF.Click += new System.EventHandler(this.lbSettingsConverterVideoCRF_Click);
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
            this.chkUseAudioBitrate.TabIndex = 1;
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
            this.numConvertAudioBitrate.Size = new System.Drawing.Size(49, 22);
            this.numConvertAudioBitrate.TabIndex = 3;
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
            this.lbidkwhatsup.TabIndex = 5;
            this.lbidkwhatsup.Text = "nothing but us empties";
            this.lbidkwhatsup.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.tipSettings.SetToolTip(this.lbidkwhatsup, "No settings for converting audio has been implemented at this time");
            this.lbidkwhatsup.Visible = false;
            // 
            // lbConvertAudioThousands
            // 
            this.lbConvertAudioThousands.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbConvertAudioThousands.AutoSize = true;
            this.lbConvertAudioThousands.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConvertAudioThousands.Location = new System.Drawing.Point(192, 20);
            this.lbConvertAudioThousands.Name = "lbConvertAudioThousands";
            this.lbConvertAudioThousands.Size = new System.Drawing.Size(16, 17);
            this.lbConvertAudioThousands.TabIndex = 4;
            this.lbConvertAudioThousands.Text = "K";
            // 
            // lbSettingsConverterAudioBitrate
            // 
            this.lbSettingsConverterAudioBitrate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbSettingsConverterAudioBitrate.AutoSize = true;
            this.lbSettingsConverterAudioBitrate.Location = new System.Drawing.Point(102, 21);
            this.lbSettingsConverterAudioBitrate.Name = "lbSettingsConverterAudioBitrate";
            this.lbSettingsConverterAudioBitrate.Size = new System.Drawing.Size(181, 13);
            this.lbSettingsConverterAudioBitrate.TabIndex = 2;
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
            this.txtSettingsConverterCustomArguments.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtSettingsConverterCustomArguments.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtSettingsConverterCustomArguments.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettingsConverterCustomArguments.ButtonImageIndex = -1;
            this.txtSettingsConverterCustomArguments.ButtonSize = new System.Drawing.Size(22, 21);
            this.txtSettingsConverterCustomArguments.ButtonText = "";
            this.txtSettingsConverterCustomArguments.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtSettingsConverterCustomArguments.Location = new System.Drawing.Point(36, 97);
            this.txtSettingsConverterCustomArguments.Name = "txtSettingsConverterCustomArguments";
            this.txtSettingsConverterCustomArguments.RegexPatterns = null;
            this.txtSettingsConverterCustomArguments.Size = new System.Drawing.Size(228, 22);
            this.txtSettingsConverterCustomArguments.TabIndex = 2;
            this.tipSettings.SetToolTip(this.txtSettingsConverterCustomArguments, "txtSettingsConverterCustomArguments");
            // 
            // lbSettingsConverterCustomHeader
            // 
            this.lbSettingsConverterCustomHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSettingsConverterCustomHeader.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSettingsConverterCustomHeader.Location = new System.Drawing.Point(6, 37);
            this.lbSettingsConverterCustomHeader.Name = "lbSettingsConverterCustomHeader";
            this.lbSettingsConverterCustomHeader.Size = new System.Drawing.Size(284, 26);
            this.lbSettingsConverterCustomHeader.TabIndex = 1;
            this.lbSettingsConverterCustomHeader.Text = "lbSettingsConverterCustomHeader";
            this.lbSettingsConverterCustomHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkSettingsConverterClearInputAfterConverting
            // 
            this.chkSettingsConverterClearInputAfterConverting.AutoSize = true;
            this.chkSettingsConverterClearInputAfterConverting.Location = new System.Drawing.Point(17, 35);
            this.chkSettingsConverterClearInputAfterConverting.Name = "chkSettingsConverterClearInputAfterConverting";
            this.chkSettingsConverterClearInputAfterConverting.Size = new System.Drawing.Size(271, 17);
            this.chkSettingsConverterClearInputAfterConverting.TabIndex = 2;
            this.chkSettingsConverterClearInputAfterConverting.Text = "chkSettingsConverterClearInputAfterConverting";
            this.tipSettings.SetToolTip(this.chkSettingsConverterClearInputAfterConverting, "chkSettingsConverterClearInputAfterConverting");
            this.chkSettingsConverterClearInputAfterConverting.UseVisualStyleBackColor = true;
            // 
            // chkSettingsConverterClearOutputAfterConverting
            // 
            this.chkSettingsConverterClearOutputAfterConverting.AutoSize = true;
            this.chkSettingsConverterClearOutputAfterConverting.Location = new System.Drawing.Point(17, 12);
            this.chkSettingsConverterClearOutputAfterConverting.Name = "chkSettingsConverterClearOutputAfterConverting";
            this.chkSettingsConverterClearOutputAfterConverting.Size = new System.Drawing.Size(281, 17);
            this.chkSettingsConverterClearOutputAfterConverting.TabIndex = 1;
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
            this.tabSettingsExtensions.Controls.Add(this.lbSettingsExtensionsExtensionFullName);
            this.tabSettingsExtensions.Controls.Add(this.lbSettingsExtensionsHeader);
            this.tabSettingsExtensions.Controls.Add(this.txtSettingsExtensionsExtensionShort);
            this.tabSettingsExtensions.Controls.Add(this.txtSettingsExtensionsExtensionFullName);
            this.tabSettingsExtensions.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsExtensions.Name = "tabSettingsExtensions";
            this.tabSettingsExtensions.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsExtensions.Size = new System.Drawing.Size(320, 362);
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
            this.lbSettingsExtensionsFileName.Size = new System.Drawing.Size(161, 13);
            this.lbSettingsExtensionsFileName.TabIndex = 8;
            this.lbSettingsExtensionsFileName.Text = "lbSettingsExtensionsFileName";
            // 
            // btnSettingsExtensionsAdd
            // 
            this.btnSettingsExtensionsAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsExtensionsAdd.Location = new System.Drawing.Point(229, 63);
            this.btnSettingsExtensionsAdd.Name = "btnSettingsExtensionsAdd";
            this.btnSettingsExtensionsAdd.Size = new System.Drawing.Size(63, 23);
            this.btnSettingsExtensionsAdd.TabIndex = 6;
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
            this.btnSettingsExtensionsRemoveSelected.TabIndex = 9;
            this.btnSettingsExtensionsRemoveSelected.Text = "btnSettingsExtensionsRemoveSelected";
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
            this.listExtensions.TabIndex = 7;
            this.listExtensions.SelectedIndexChanged += new System.EventHandler(this.listExtensions_SelectedIndexChanged);
            // 
            // lbSettingsExtensionsExtensionShort
            // 
            this.lbSettingsExtensionsExtensionShort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSettingsExtensionsExtensionShort.AutoSize = true;
            this.lbSettingsExtensionsExtensionShort.Location = new System.Drawing.Point(163, 49);
            this.lbSettingsExtensionsExtensionShort.Name = "lbSettingsExtensionsExtensionShort";
            this.lbSettingsExtensionsExtensionShort.Size = new System.Drawing.Size(192, 13);
            this.lbSettingsExtensionsExtensionShort.TabIndex = 3;
            this.lbSettingsExtensionsExtensionShort.Text = "lbSettingsExtensionsExtensionShort";
            // 
            // lbSettingsExtensionsExtensionFullName
            // 
            this.lbSettingsExtensionsExtensionFullName.AutoSize = true;
            this.lbSettingsExtensionsExtensionFullName.Location = new System.Drawing.Point(28, 49);
            this.lbSettingsExtensionsExtensionFullName.Name = "lbSettingsExtensionsExtensionFullName";
            this.lbSettingsExtensionsExtensionFullName.Size = new System.Drawing.Size(212, 13);
            this.lbSettingsExtensionsExtensionFullName.TabIndex = 2;
            this.lbSettingsExtensionsExtensionFullName.Text = "lbSettingsExtensionsExtensionFullName";
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
            // txtSettingsExtensionsExtensionShort
            // 
            this.txtSettingsExtensionsExtensionShort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsExtensionsExtensionShort.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtSettingsExtensionsExtensionShort.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtSettingsExtensionsExtensionShort.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettingsExtensionsExtensionShort.ButtonImageIndex = -1;
            this.txtSettingsExtensionsExtensionShort.ButtonSize = new System.Drawing.Size(22, 21);
            this.txtSettingsExtensionsExtensionShort.ButtonText = "";
            this.txtSettingsExtensionsExtensionShort.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtSettingsExtensionsExtensionShort.Location = new System.Drawing.Point(166, 65);
            this.txtSettingsExtensionsExtensionShort.Name = "txtSettingsExtensionsExtensionShort";
            this.txtSettingsExtensionsExtensionShort.RegexPatterns = null;
            this.txtSettingsExtensionsExtensionShort.Size = new System.Drawing.Size(57, 22);
            this.txtSettingsExtensionsExtensionShort.TabIndex = 5;
            // 
            // txtSettingsExtensionsExtensionFullName
            // 
            this.txtSettingsExtensionsExtensionFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSettingsExtensionsExtensionFullName.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtSettingsExtensionsExtensionFullName.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtSettingsExtensionsExtensionFullName.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSettingsExtensionsExtensionFullName.ButtonImageIndex = -1;
            this.txtSettingsExtensionsExtensionFullName.ButtonSize = new System.Drawing.Size(22, 21);
            this.txtSettingsExtensionsExtensionFullName.ButtonText = "";
            this.txtSettingsExtensionsExtensionFullName.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtSettingsExtensionsExtensionFullName.Location = new System.Drawing.Point(31, 65);
            this.txtSettingsExtensionsExtensionFullName.Name = "txtSettingsExtensionsExtensionFullName";
            this.txtSettingsExtensionsExtensionFullName.RegexPatterns = null;
            this.txtSettingsExtensionsExtensionFullName.Size = new System.Drawing.Size(129, 22);
            this.txtSettingsExtensionsExtensionFullName.TabIndex = 4;
            // 
            // tabSettingsErrors
            // 
            this.tabSettingsErrors.Controls.Add(this.chkSettingsErrorsSaveErrorsAsErrorLog);
            this.tabSettingsErrors.Controls.Add(this.chkSettingsErrorsShowDetailedErrors);
            this.tabSettingsErrors.Controls.Add(this.chkSettingsErrorsSuppressErrors);
            this.tabSettingsErrors.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsErrors.Name = "tabSettingsErrors";
            this.tabSettingsErrors.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsErrors.Size = new System.Drawing.Size(320, 362);
            this.tabSettingsErrors.TabIndex = 3;
            this.tabSettingsErrors.Text = "tabSettingsErrors";
            this.tabSettingsErrors.UseVisualStyleBackColor = true;
            // 
            // chkSettingsErrorsSaveErrorsAsErrorLog
            // 
            this.chkSettingsErrorsSaveErrorsAsErrorLog.AutoSize = true;
            this.chkSettingsErrorsSaveErrorsAsErrorLog.Location = new System.Drawing.Point(8, 6);
            this.chkSettingsErrorsSaveErrorsAsErrorLog.Name = "chkSettingsErrorsSaveErrorsAsErrorLog";
            this.chkSettingsErrorsSaveErrorsAsErrorLog.Size = new System.Drawing.Size(224, 17);
            this.chkSettingsErrorsSaveErrorsAsErrorLog.TabIndex = 1;
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
            this.chkSettingsErrorsShowDetailedErrors.Size = new System.Drawing.Size(217, 17);
            this.chkSettingsErrorsShowDetailedErrors.TabIndex = 3;
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
            this.chkSettingsErrorsSuppressErrors.Size = new System.Drawing.Size(192, 17);
            this.chkSettingsErrorsSuppressErrors.TabIndex = 2;
            this.chkSettingsErrorsSuppressErrors.Text = "chkSettingsErrorsSuppressErrors";
            this.tipSettings.SetToolTip(this.chkSettingsErrorsSuppressErrors, "chkSettingsErrorsSuppressErrors");
            this.chkSettingsErrorsSuppressErrors.UseVisualStyleBackColor = true;
            // 
            // btnSettingsCancel
            // 
            this.btnSettingsCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsCancel.Location = new System.Drawing.Point(160, 398);
            this.btnSettingsCancel.Name = "btnSettingsCancel";
            this.btnSettingsCancel.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsCancel.TabIndex = 2;
            this.btnSettingsCancel.Text = "btnSettingsCancel";
            this.tipSettings.SetToolTip(this.btnSettingsCancel, "btnSettingsCancel");
            this.btnSettingsCancel.UseVisualStyleBackColor = true;
            this.btnSettingsCancel.Click += new System.EventHandler(this.btnSettingsCancel_Click);
            // 
            // btnSettingsSave
            // 
            this.btnSettingsSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsSave.Location = new System.Drawing.Point(241, 398);
            this.btnSettingsSave.Name = "btnSettingsSave";
            this.btnSettingsSave.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsSave.TabIndex = 3;
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
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 435);
            this.Controls.Add(this.btnSettingsSave);
            this.Controls.Add(this.btnSettingsCancel);
            this.Controls.Add(this.tcMain);
            this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(346, 470);
            this.Name = "frmSettings";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "youtube-dl-gui settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSettings_FormClosing);
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.tcMain.ResumeLayout(false);
            this.tabSettingsGeneral.ResumeLayout(false);
            this.tabSettingsGeneral.PerformLayout();
            this.gbSettingsGeneralCustomArguments.ResumeLayout(false);
            this.gbSettingsGeneralCustomArguments.PerformLayout();
            this.tcExternalApplications.ResumeLayout(false);
            this.tabSettingsGeneralYoutubeDl.ResumeLayout(false);
            this.tabSettingsGeneralYoutubeDl.PerformLayout();
            this.tabSettingsGeneralFfmpeg.ResumeLayout(false);
            this.tabSettingsGeneralFfmpeg.PerformLayout();
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
            this.tabDownloadsBatch.ResumeLayout(false);
            this.tabDownloadsBatch.PerformLayout();
            this.tabYtdlpExtendedOptions.ResumeLayout(false);
            this.tabYtdlpExtendedOptions.PerformLayout();
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
        private System.Windows.Forms.Button btnSettingsGeneralBrowseFFmpeg;
        private System.Windows.Forms.Button btnSettingsGeneralBrowseYoutubeDl;
        private System.Windows.Forms.CheckBox chkSettingsGeneralUseStaticYoutubeDl;
        private System.Windows.Forms.CheckBox chkSettingsGeneralUseStaticFFmpeg;
        private murrty.controls.ExtendedTextBox txtSettingsGeneralFFmpegPath;
        private System.Windows.Forms.Label lbSettingsGeneralFFmpegDirectory;
        private murrty.controls.ExtendedTextBox txtSettingsGeneralYoutubeDlPath;
        private System.Windows.Forms.Label lbSettingsGeneralYoutubeDlPath;
        private System.Windows.Forms.TabPage tabSettingsDownloads;
        private System.Windows.Forms.TabPage tabSettingsConverter;
        private System.Windows.Forms.Button btnSettingsCancel;
        private System.Windows.Forms.Button btnSettingsSave;
        private System.Windows.Forms.GroupBox gbSettingsGeneralCustomArguments;
        private System.Windows.Forms.RadioButton rbSettingsGeneralCustomArgumentsSaveInSettings;
        private System.Windows.Forms.RadioButton rbSettingsGeneralCustomArgumentsSaveAsArgsText;
        private System.Windows.Forms.RadioButton rbSettingsGeneralCustomArgumentsDontSave;
        private System.Windows.Forms.CheckBox chkSettingsGeneralClearUrlOnDownload;
        private System.Windows.Forms.CheckBox chkSettingsGeneralHoverOverUrlToPasteClipboard;
        private System.Windows.Forms.CheckBox chkSettingsGeneralCheckForUpdatesOnLaunch;
        private System.Windows.Forms.CheckBox chksettingsDownloadsUseYoutubeDlsUpdater;
        private System.Windows.Forms.Button btnSettingsDownloadsBrowseSavePath;
        private murrty.controls.ExtendedTextBox txtSettingsDownloadsSavePath;
        private System.Windows.Forms.Label lbSettingsDownloadsDownloadPath;
        private System.Windows.Forms.Label lbSepDownloads;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsSeparateDownloadsToDifferentFolders;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsSaveFormatQuality;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing;
        private System.Windows.Forms.Button btnSettingsRedownloadYoutubeDl;
        private System.Windows.Forms.CheckBox chkSettingsConverterDetectOutputFileType;
        private System.Windows.Forms.Label lbSettingsDownloadsFileNameSchema;
        private murrty.controls.ExtendedLinkLabel llSettingsDownloadsSchemaHelp;
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
        private murrty.controls.ExtendedTextBox txtSettingsConverterCustomArguments;
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
        private murrty.controls.ExtendedTextBox txtSettingsExtensionsExtensionShort;
        private System.Windows.Forms.Label lbSettingsExtensionsExtensionFullName;
        private murrty.controls.ExtendedTextBox txtSettingsExtensionsExtensionFullName;
        private System.Windows.Forms.Button btnSettingsExtensionsAdd;
        private System.Windows.Forms.Label lbSettingsExtensionsFileName;
        private System.Windows.Forms.CheckBox chkSettingsConverterVideoCRF;
        private System.Windows.Forms.CheckBox chkSettingsConverterVideoProfile;
        private System.Windows.Forms.CheckBox chkSettingsConverterVideoPreset;
        private System.Windows.Forms.CheckBox chkSettingsConverterVideoBitrate;
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
        private murrty.controls.ExtendedTextBox txtSettingsDownloadsProxyPort;
        private murrty.controls.ExtendedTextBox txtSettingsDownloadsProxyIp;
        private System.Windows.Forms.Label lbSettingsDownloadsIpPort;
        private System.Windows.Forms.ComboBox cbSettingsDownloadsProxyType;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsLimitDownload;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsEmbedSubtitles;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsEmbedThumbnails;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsKeepOriginalFiles;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsWriteMetadataToFile;
        private System.Windows.Forms.CheckBox chkSettingsGeneralClearClipboardOnDownload;
        private System.Windows.Forms.CheckBox chkSettingsGeneralAutoUpdateYoutubeDl;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsPreferFFmpeg;
        private System.Windows.Forms.ComboBox txtSettingsDownloadsFileNameSchema;
        private System.Windows.Forms.TabPage tabDownloadsBatch;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsSeparateBatchDownloads;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsAddDateToBatchDownloadFolders;
        private System.Windows.Forms.CheckBox chkSettingsGeneralCheckForBetaUpdates;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsDownloadPathUseRelativePath;
        private System.Windows.Forms.Label lbSettingsDownloadsUpdatingYtdlType;
        private System.Windows.Forms.ComboBox cbSettingsDownloadsUpdatingYtdlType;
        private murrty.controls.ExtendedLinkLabel llbSettingsDownloadsYtdlTypeViewRepo;
        private System.Windows.Forms.CheckBox chkDeleteOldVersionAfterUpdating;
        private System.Windows.Forms.CheckBox chkSettingsGeneralDeleteUpdaterAfterUpdating;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsWebsiteSubdomains;
        private System.Windows.Forms.TabPage tabYtdlpExtendedOptions;
        private System.Windows.Forms.CheckBox chkYtdlpExtendedAutomaticallyDownloadThumbnail;
        private System.Windows.Forms.CheckBox chkYtdlpPreferExtendedDialog;
        private System.Windows.Forms.TabControl tcExternalApplications;
        private System.Windows.Forms.TabPage tabSettingsGeneralYoutubeDl;
        private System.Windows.Forms.TabPage tabSettingsGeneralFfmpeg;
        private System.Windows.Forms.Button btnSettingsRedownloadFfmpeg;
    }
}