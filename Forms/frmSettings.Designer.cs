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
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabSettingsGeneral = new System.Windows.Forms.TabPage();
            this.gbSettingsGeneralCustomArguments = new System.Windows.Forms.GroupBox();
            this.rbSettingsGeneralCustomArgumentsSaveInSettings = new System.Windows.Forms.RadioButton();
            this.rbSettingsGeneralCustomArgumentsSaveAsArgsText = new System.Windows.Forms.RadioButton();
            this.rbSettingsGeneralCustomArgumentsDontSave = new System.Windows.Forms.RadioButton();
            this.chkSettingsGeneralClearUrlClipboardOnDownload = new System.Windows.Forms.CheckBox();
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard = new System.Windows.Forms.CheckBox();
            this.chkSettingsGeneralCheckForUpdatesOnLaunch = new System.Windows.Forms.CheckBox();
            this.lbSepGeneral = new System.Windows.Forms.Label();
            this.btnBrwsFF = new System.Windows.Forms.Button();
            this.btnBrwsYtdl = new System.Windows.Forms.Button();
            this.chkSettingsGeneralUseStaticYoutubeDl = new System.Windows.Forms.CheckBox();
            this.chkSettingsGeneralUseStaticFFmpeg = new System.Windows.Forms.CheckBox();
            this.txtFFmpeg = new System.Windows.Forms.TextBox();
            this.lbSettingsGeneralFFmpegDirectory = new System.Windows.Forms.Label();
            this.txtYtdl = new System.Windows.Forms.TextBox();
            this.lbSettingsGeneralYoutubeDlPath = new System.Windows.Forms.Label();
            this.tbSettingsDownloads = new System.Windows.Forms.TabPage();
            this.txtSubtitlesLanguages = new System.Windows.Forms.TextBox();
            this.chkSettingsDownloadsDownloadSubtitles = new System.Windows.Forms.CheckBox();
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl = new System.Windows.Forms.CheckBox();
            this.lbSettingsDownloadsDownloadPath = new System.Windows.Forms.Label();
            this.chkSettingsDownloadsFixVReddIt = new System.Windows.Forms.CheckBox();
            this.txtSaveto = new System.Windows.Forms.TextBox();
            this.chkSettingsDownloadsSaveFormatQuality = new System.Windows.Forms.CheckBox();
            this.llSchema = new System.Windows.Forms.LinkLabel();
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders = new System.Windows.Forms.CheckBox();
            this.btnBrowseSaveto = new System.Windows.Forms.Button();
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = new System.Windows.Forms.CheckBox();
            this.txtFileNameSchema = new System.Windows.Forms.TextBox();
            this.lbSepDownloads = new System.Windows.Forms.Label();
            this.chksettingsDownloadsUseYoutubeDlsUpdater = new System.Windows.Forms.CheckBox();
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
            this.lbkSettingsConverterVideoPreset = new System.Windows.Forms.Label();
            this.lbSettingsConverterVideoProfile = new System.Windows.Forms.Label();
            this.lbSettingsConverterVideoCRF = new System.Windows.Forms.Label();
            this.tcSettingsConverterAudio = new System.Windows.Forms.TabPage();
            this.chkUseAudioBitrate = new System.Windows.Forms.CheckBox();
            this.numConvertAudioBitrate = new System.Windows.Forms.NumericUpDown();
            this.lbidkwhatsup = new System.Windows.Forms.Label();
            this.lbConvertAudioThousands = new System.Windows.Forms.Label();
            this.chkSettingsConverterAudioBitrate = new System.Windows.Forms.Label();
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
            this.txtExtensionsShort = new System.Windows.Forms.TextBox();
            this.lbSettingsExtensionsExtensionFullName = new System.Windows.Forms.Label();
            this.txtExtensionsName = new System.Windows.Forms.TextBox();
            this.lbSettingsExtensionsHeader = new System.Windows.Forms.Label();
            this.tabSettingsErrors = new System.Windows.Forms.TabPage();
            this.chkSettingsErrorsSaveErrorsAsErrorLog = new System.Windows.Forms.CheckBox();
            this.chkSettingsErrorsShowDetailedErrors = new System.Windows.Forms.CheckBox();
            this.chkSettingsErrorsSuppressErrors = new System.Windows.Forms.CheckBox();
            this.btnSettingsRedownloadYoutubeDl = new System.Windows.Forms.Button();
            this.btnSettingsCancel = new System.Windows.Forms.Button();
            this.btnSettingsSave = new System.Windows.Forms.Button();
            this.tipSettings = new System.Windows.Forms.ToolTip(this.components);
            this.tcMain.SuspendLayout();
            this.tabSettingsGeneral.SuspendLayout();
            this.gbSettingsGeneralCustomArguments.SuspendLayout();
            this.tbSettingsDownloads.SuspendLayout();
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
            this.tcMain.Controls.Add(this.tabSettingsGeneral);
            this.tcMain.Controls.Add(this.tbSettingsDownloads);
            this.tcMain.Controls.Add(this.tabSettingsConverter);
            this.tcMain.Controls.Add(this.tabSettingsExtensions);
            this.tcMain.Controls.Add(this.tabSettingsErrors);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(328, 279);
            this.tcMain.TabIndex = 0;
            // 
            // tabSettingsGeneral
            // 
            this.tabSettingsGeneral.Controls.Add(this.gbSettingsGeneralCustomArguments);
            this.tabSettingsGeneral.Controls.Add(this.lbSepGeneral);
            this.tabSettingsGeneral.Controls.Add(this.btnBrwsFF);
            this.tabSettingsGeneral.Controls.Add(this.btnBrwsYtdl);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralUseStaticYoutubeDl);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralUseStaticFFmpeg);
            this.tabSettingsGeneral.Controls.Add(this.txtFFmpeg);
            this.tabSettingsGeneral.Controls.Add(this.lbSettingsGeneralFFmpegDirectory);
            this.tabSettingsGeneral.Controls.Add(this.txtYtdl);
            this.tabSettingsGeneral.Controls.Add(this.lbSettingsGeneralYoutubeDlPath);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralClearUrlClipboardOnDownload);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralHoverOverUrlToPasteClipboard);
            this.tabSettingsGeneral.Controls.Add(this.chkSettingsGeneralCheckForUpdatesOnLaunch);
            this.tabSettingsGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsGeneral.Name = "tabSettingsGeneral";
            this.tabSettingsGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsGeneral.Size = new System.Drawing.Size(320, 253);
            this.tabSettingsGeneral.TabIndex = 0;
            this.tabSettingsGeneral.Text = "General";
            this.tabSettingsGeneral.UseVisualStyleBackColor = true;
            // 
            // gbSettingsGeneralCustomArguments
            // 
            this.gbSettingsGeneralCustomArguments.Controls.Add(this.rbSettingsGeneralCustomArgumentsSaveInSettings);
            this.gbSettingsGeneralCustomArguments.Controls.Add(this.rbSettingsGeneralCustomArgumentsSaveAsArgsText);
            this.gbSettingsGeneralCustomArguments.Controls.Add(this.rbSettingsGeneralCustomArgumentsDontSave);
            this.gbSettingsGeneralCustomArguments.Location = new System.Drawing.Point(6, 196);
            this.gbSettingsGeneralCustomArguments.Name = "gbSettingsGeneralCustomArguments";
            this.gbSettingsGeneralCustomArguments.Size = new System.Drawing.Size(308, 46);
            this.gbSettingsGeneralCustomArguments.TabIndex = 12;
            this.gbSettingsGeneralCustomArguments.TabStop = false;
            this.gbSettingsGeneralCustomArguments.Text = "gbSettingsGeneralCustomArguments";
            this.tipSettings.SetToolTip(this.gbSettingsGeneralCustomArguments, "Controls how custom arguments for youtube-dl will be saved");
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
            this.tipSettings.SetToolTip(this.rbSettingsGeneralCustomArgumentsSaveInSettings, "Saves custom arguments in the application settings");
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
            this.tipSettings.SetToolTip(this.rbSettingsGeneralCustomArgumentsSaveAsArgsText, "Saves custom arguments as args.txt in youtube-dl-gui\'s directory");
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
            this.tipSettings.SetToolTip(this.rbSettingsGeneralCustomArgumentsDontSave, "Doesn\'t save any custom arguments");
            this.rbSettingsGeneralCustomArgumentsDontSave.UseVisualStyleBackColor = true;
            // 
            // chkSettingsGeneralClearUrlClipboardOnDownload
            // 
            this.chkSettingsGeneralClearUrlClipboardOnDownload.AutoSize = true;
            this.chkSettingsGeneralClearUrlClipboardOnDownload.Location = new System.Drawing.Point(64, 165);
            this.chkSettingsGeneralClearUrlClipboardOnDownload.Name = "chkSettingsGeneralClearUrlClipboardOnDownload";
            this.chkSettingsGeneralClearUrlClipboardOnDownload.Size = new System.Drawing.Size(261, 17);
            this.chkSettingsGeneralClearUrlClipboardOnDownload.TabIndex = 11;
            this.chkSettingsGeneralClearUrlClipboardOnDownload.Text = "chkSettingsGeneralClearUrlClipboardOnDownload";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralClearUrlClipboardOnDownload, "Clears the URL from the textbox and clipboard on video download");
            this.chkSettingsGeneralClearUrlClipboardOnDownload.UseVisualStyleBackColor = true;
            // 
            // chkSettingsGeneralHoverOverUrlToPasteClipboard
            // 
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.AutoSize = true;
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Checked = true;
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Location = new System.Drawing.Point(65, 142);
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Name = "chkSettingsGeneralHoverOverUrlToPasteClipboard";
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Size = new System.Drawing.Size(267, 17);
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.TabIndex = 10;
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.Text = "chkSettingsGeneralHoverOverUrlToPasteClipboard";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralHoverOverUrlToPasteClipboard, "Hover over the URL textbox to paste the URL from the clipboard");
            this.chkSettingsGeneralHoverOverUrlToPasteClipboard.UseVisualStyleBackColor = true;
            // 
            // chkSettingsGeneralCheckForUpdatesOnLaunch
            // 
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.AutoSize = true;
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.Location = new System.Drawing.Point(79, 119);
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.Name = "chkSettingsGeneralCheckForUpdatesOnLaunch";
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.Size = new System.Drawing.Size(254, 17);
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.TabIndex = 9;
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.Text = "chkSettingsGeneralCheckForUpdatesOnLaunch";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralCheckForUpdatesOnLaunch, "Check for updates on launch of youtube-dl-gui");
            this.chkSettingsGeneralCheckForUpdatesOnLaunch.UseVisualStyleBackColor = true;
            // 
            // lbSepGeneral
            // 
            this.lbSepGeneral.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSepGeneral.Location = new System.Drawing.Point(25, 107);
            this.lbSepGeneral.Name = "lbSepGeneral";
            this.lbSepGeneral.Size = new System.Drawing.Size(270, 2);
            this.lbSepGeneral.TabIndex = 8;
            this.lbSepGeneral.Text = "HELLO WORLD";
            // 
            // btnBrwsFF
            // 
            this.btnBrwsFF.Location = new System.Drawing.Point(269, 77);
            this.btnBrwsFF.Name = "btnBrwsFF";
            this.btnBrwsFF.Size = new System.Drawing.Size(33, 23);
            this.btnBrwsFF.TabIndex = 7;
            this.btnBrwsFF.Text = "...";
            this.tipSettings.SetToolTip(this.btnBrwsFF, "Browse for the folder that contains ffmpeg.exe & ffprobe.exe");
            this.btnBrwsFF.UseVisualStyleBackColor = true;
            this.btnBrwsFF.Click += new System.EventHandler(this.btnBrwsFF_Click);
            // 
            // btnBrwsYtdl
            // 
            this.btnBrwsYtdl.Location = new System.Drawing.Point(269, 30);
            this.btnBrwsYtdl.Name = "btnBrwsYtdl";
            this.btnBrwsYtdl.Size = new System.Drawing.Size(33, 23);
            this.btnBrwsYtdl.TabIndex = 6;
            this.btnBrwsYtdl.Text = "...";
            this.tipSettings.SetToolTip(this.btnBrwsYtdl, "Browse for youtube-dl.exe");
            this.btnBrwsYtdl.UseVisualStyleBackColor = true;
            this.btnBrwsYtdl.Click += new System.EventHandler(this.btnBrwsYtdl_Click);
            // 
            // chkSettingsGeneralUseStaticYoutubeDl
            // 
            this.chkSettingsGeneralUseStaticYoutubeDl.AutoSize = true;
            this.chkSettingsGeneralUseStaticYoutubeDl.Location = new System.Drawing.Point(122, 11);
            this.chkSettingsGeneralUseStaticYoutubeDl.Name = "chkSettingsGeneralUseStaticYoutubeDl";
            this.chkSettingsGeneralUseStaticYoutubeDl.Size = new System.Drawing.Size(214, 17);
            this.chkSettingsGeneralUseStaticYoutubeDl.TabIndex = 5;
            this.chkSettingsGeneralUseStaticYoutubeDl.Text = "chkSettingsGeneralUseStaticYoutubeDl";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralUseStaticYoutubeDl, "Use a static placed youtube-dl.exe file");
            this.chkSettingsGeneralUseStaticYoutubeDl.UseVisualStyleBackColor = true;
            // 
            // chkSettingsGeneralUseStaticFFmpeg
            // 
            this.chkSettingsGeneralUseStaticFFmpeg.AutoSize = true;
            this.chkSettingsGeneralUseStaticFFmpeg.Location = new System.Drawing.Point(122, 58);
            this.chkSettingsGeneralUseStaticFFmpeg.Name = "chkSettingsGeneralUseStaticFFmpeg";
            this.chkSettingsGeneralUseStaticFFmpeg.Size = new System.Drawing.Size(202, 17);
            this.chkSettingsGeneralUseStaticFFmpeg.TabIndex = 4;
            this.chkSettingsGeneralUseStaticFFmpeg.Text = "chkSettingsGeneralUseStaticFFmpeg";
            this.tipSettings.SetToolTip(this.chkSettingsGeneralUseStaticFFmpeg, "Use a static placed ffmpeg.exe and ffprobe.exe files");
            this.chkSettingsGeneralUseStaticFFmpeg.UseVisualStyleBackColor = true;
            // 
            // txtFFmpeg
            // 
            this.txtFFmpeg.Location = new System.Drawing.Point(30, 79);
            this.txtFFmpeg.Name = "txtFFmpeg";
            this.txtFFmpeg.ReadOnly = true;
            this.txtFFmpeg.Size = new System.Drawing.Size(233, 20);
            this.txtFFmpeg.TabIndex = 3;
            this.tipSettings.SetToolTip(this.txtFFmpeg, "The path of ffmpeg");
            // 
            // lbSettingsGeneralFFmpegDirectory
            // 
            this.lbSettingsGeneralFFmpegDirectory.AutoSize = true;
            this.lbSettingsGeneralFFmpegDirectory.Location = new System.Drawing.Point(19, 59);
            this.lbSettingsGeneralFFmpegDirectory.Name = "lbSettingsGeneralFFmpegDirectory";
            this.lbSettingsGeneralFFmpegDirectory.Size = new System.Drawing.Size(170, 13);
            this.lbSettingsGeneralFFmpegDirectory.TabIndex = 2;
            this.lbSettingsGeneralFFmpegDirectory.Text = "lbSettingsGeneralFFmpegDirectory";
            this.tipSettings.SetToolTip(this.lbSettingsGeneralFFmpegDirectory, "Static ffmpeg directory\r\n\r\nStatic ffmpeg means ffmpeg will always be located in t" +
        "hat one directory.");
            // 
            // txtYtdl
            // 
            this.txtYtdl.Location = new System.Drawing.Point(30, 32);
            this.txtYtdl.Name = "txtYtdl";
            this.txtYtdl.ReadOnly = true;
            this.txtYtdl.Size = new System.Drawing.Size(233, 20);
            this.txtYtdl.TabIndex = 1;
            this.tipSettings.SetToolTip(this.txtYtdl, "The path of youtube-dl.exe");
            // 
            // lbSettingsGeneralYoutubeDlPath
            // 
            this.lbSettingsGeneralYoutubeDlPath.AutoSize = true;
            this.lbSettingsGeneralYoutubeDlPath.Location = new System.Drawing.Point(19, 12);
            this.lbSettingsGeneralYoutubeDlPath.Name = "lbSettingsGeneralYoutubeDlPath";
            this.lbSettingsGeneralYoutubeDlPath.Size = new System.Drawing.Size(162, 13);
            this.lbSettingsGeneralYoutubeDlPath.TabIndex = 0;
            this.lbSettingsGeneralYoutubeDlPath.Text = "lbSettingsGeneralYoutubeDlPath";
            this.tipSettings.SetToolTip(this.lbSettingsGeneralYoutubeDlPath, "Static youtube-dl directory\r\n\r\nStatic youtube-dl means youtube-dl will always be " +
        "located in that one directory.\r\n");
            // 
            // tbSettingsDownloads
            // 
            this.tbSettingsDownloads.Controls.Add(this.txtSubtitlesLanguages);
            this.tbSettingsDownloads.Controls.Add(this.chkSettingsDownloadsSeparateIntoWebsiteUrl);
            this.tbSettingsDownloads.Controls.Add(this.lbSettingsDownloadsDownloadPath);
            this.tbSettingsDownloads.Controls.Add(this.chkSettingsDownloadsFixVReddIt);
            this.tbSettingsDownloads.Controls.Add(this.txtSaveto);
            this.tbSettingsDownloads.Controls.Add(this.llSchema);
            this.tbSettingsDownloads.Controls.Add(this.btnBrowseSaveto);
            this.tbSettingsDownloads.Controls.Add(this.txtFileNameSchema);
            this.tbSettingsDownloads.Controls.Add(this.lbSepDownloads);
            this.tbSettingsDownloads.Controls.Add(this.lbSettingsDownloadsFileNameSchema);
            this.tbSettingsDownloads.Controls.Add(this.chkSettingsDownloadsDownloadSubtitles);
            this.tbSettingsDownloads.Controls.Add(this.chkSettingsDownloadsSaveFormatQuality);
            this.tbSettingsDownloads.Controls.Add(this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing);
            this.tbSettingsDownloads.Controls.Add(this.chksettingsDownloadsUseYoutubeDlsUpdater);
            this.tbSettingsDownloads.Controls.Add(this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders);
            this.tbSettingsDownloads.Location = new System.Drawing.Point(4, 22);
            this.tbSettingsDownloads.Name = "tbSettingsDownloads";
            this.tbSettingsDownloads.Padding = new System.Windows.Forms.Padding(3);
            this.tbSettingsDownloads.Size = new System.Drawing.Size(320, 253);
            this.tbSettingsDownloads.TabIndex = 1;
            this.tbSettingsDownloads.Text = "Downloads";
            this.tbSettingsDownloads.UseVisualStyleBackColor = true;
            // 
            // txtSubtitlesLanguages
            // 
            this.txtSubtitlesLanguages.Location = new System.Drawing.Point(162, 219);
            this.txtSubtitlesLanguages.Name = "txtSubtitlesLanguages";
            this.txtSubtitlesLanguages.Size = new System.Drawing.Size(116, 20);
            this.txtSubtitlesLanguages.TabIndex = 25;
            this.tipSettings.SetToolTip(this.txtSubtitlesLanguages, "Download subtitles in the languages entered in the text box");
            // 
            // chkSettingsDownloadsDownloadSubtitles
            // 
            this.chkSettingsDownloadsDownloadSubtitles.AutoSize = true;
            this.chkSettingsDownloadsDownloadSubtitles.Location = new System.Drawing.Point(42, 221);
            this.chkSettingsDownloadsDownloadSubtitles.Name = "chkSettingsDownloadsDownloadSubtitles";
            this.chkSettingsDownloadsDownloadSubtitles.Size = new System.Drawing.Size(222, 17);
            this.chkSettingsDownloadsDownloadSubtitles.TabIndex = 24;
            this.chkSettingsDownloadsDownloadSubtitles.Text = "chkSettingsDownloadsDownloadSubtitles";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsDownloadSubtitles, "Download subtitles in the languages entered in the text box");
            this.chkSettingsDownloadsDownloadSubtitles.UseVisualStyleBackColor = true;
            // 
            // chkSettingsDownloadsSeparateIntoWebsiteUrl
            // 
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.AutoSize = true;
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked = true;
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.Location = new System.Drawing.Point(172, 147);
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.Name = "chkSettingsDownloadsSeparateIntoWebsiteUrl";
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.Size = new System.Drawing.Size(247, 17);
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.TabIndex = 23;
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.Text = "chkSettingsDownloadsSeparateIntoWebsiteUrl";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsSeparateIntoWebsiteUrl, "Downloaded files will be saved to the download path with the URL of the website a" +
        "ppended at the end\r\nEx: C:\\Users\\YourName\\Videos\\youtube.com\\Video.mp4");
            this.chkSettingsDownloadsSeparateIntoWebsiteUrl.UseVisualStyleBackColor = true;
            // 
            // lbSettingsDownloadsDownloadPath
            // 
            this.lbSettingsDownloadsDownloadPath.AutoSize = true;
            this.lbSettingsDownloadsDownloadPath.Location = new System.Drawing.Point(19, 12);
            this.lbSettingsDownloadsDownloadPath.Name = "lbSettingsDownloadsDownloadPath";
            this.lbSettingsDownloadsDownloadPath.Size = new System.Drawing.Size(176, 13);
            this.lbSettingsDownloadsDownloadPath.TabIndex = 7;
            this.lbSettingsDownloadsDownloadPath.Text = "lbSettingsDownloadsDownloadPath";
            this.tipSettings.SetToolTip(this.lbSettingsDownloadsDownloadPath, "The path of the folder where files will be downloaded to");
            // 
            // chkSettingsDownloadsFixVReddIt
            // 
            this.chkSettingsDownloadsFixVReddIt.AutoSize = true;
            this.chkSettingsDownloadsFixVReddIt.Checked = true;
            this.chkSettingsDownloadsFixVReddIt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsDownloadsFixVReddIt.Location = new System.Drawing.Point(190, 193);
            this.chkSettingsDownloadsFixVReddIt.Name = "chkSettingsDownloadsFixVReddIt";
            this.chkSettingsDownloadsFixVReddIt.Size = new System.Drawing.Size(186, 17);
            this.chkSettingsDownloadsFixVReddIt.TabIndex = 22;
            this.chkSettingsDownloadsFixVReddIt.Text = "chkSettingsDownloadsFixVReddIt";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsFixVReddIt, resources.GetString("chkSettingsDownloadsFixVReddIt.ToolTip"));
            this.chkSettingsDownloadsFixVReddIt.UseVisualStyleBackColor = true;
            // 
            // txtSaveto
            // 
            this.txtSaveto.Location = new System.Drawing.Point(30, 32);
            this.txtSaveto.Name = "txtSaveto";
            this.txtSaveto.ReadOnly = true;
            this.txtSaveto.Size = new System.Drawing.Size(233, 20);
            this.txtSaveto.TabIndex = 8;
            this.tipSettings.SetToolTip(this.txtSaveto, "The path of the folder where files will be downloaded to");
            // 
            // chkSettingsDownloadsSaveFormatQuality
            // 
            this.chkSettingsDownloadsSaveFormatQuality.AutoSize = true;
            this.chkSettingsDownloadsSaveFormatQuality.Enabled = false;
            this.chkSettingsDownloadsSaveFormatQuality.Location = new System.Drawing.Point(42, 147);
            this.chkSettingsDownloadsSaveFormatQuality.Name = "chkSettingsDownloadsSaveFormatQuality";
            this.chkSettingsDownloadsSaveFormatQuality.Size = new System.Drawing.Size(223, 17);
            this.chkSettingsDownloadsSaveFormatQuality.TabIndex = 15;
            this.chkSettingsDownloadsSaveFormatQuality.Text = "chkSettingsDownloadsSaveFormatQuality";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsSaveFormatQuality, "Save format & quality of downloads on download");
            this.chkSettingsDownloadsSaveFormatQuality.UseVisualStyleBackColor = true;
            // 
            // llSchema
            // 
            this.llSchema.AutoSize = true;
            this.llSchema.Location = new System.Drawing.Point(6, 59);
            this.llSchema.Name = "llSchema";
            this.llSchema.Size = new System.Drawing.Size(13, 13);
            this.llSchema.TabIndex = 21;
            this.llSchema.TabStop = true;
            this.llSchema.Text = "?";
            this.tipSettings.SetToolTip(this.llSchema, "Click this to show a list of replaceable words");
            this.llSchema.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSchema_LinkClicked);
            // 
            // chkSettingsDownloadsSeparateDownloadsToDifferentFolders
            // 
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.AutoSize = true;
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Checked = true;
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Location = new System.Drawing.Point(42, 124);
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Name = "chkSettingsDownloadsSeparateDownloadsToDifferentFolders";
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Size = new System.Drawing.Size(317, 17);
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.TabIndex = 17;
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Text = "chkSettingsDownloadsSeparateDownloadsToDifferentFolders";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders, resources.GetString("chkSettingsDownloadsSeparateDownloadsToDifferentFolders.ToolTip"));
            this.chkSettingsDownloadsSeparateDownloadsToDifferentFolders.UseVisualStyleBackColor = true;
            // 
            // btnBrowseSaveto
            // 
            this.btnBrowseSaveto.Location = new System.Drawing.Point(269, 30);
            this.btnBrowseSaveto.Name = "btnBrowseSaveto";
            this.btnBrowseSaveto.Size = new System.Drawing.Size(33, 23);
            this.btnBrowseSaveto.TabIndex = 10;
            this.btnBrowseSaveto.Text = "...";
            this.tipSettings.SetToolTip(this.btnBrowseSaveto, "Browse for a folder to save downloaded files");
            this.btnBrowseSaveto.UseVisualStyleBackColor = true;
            this.btnBrowseSaveto.Click += new System.EventHandler(this.btnBrowseSaveto_Click);
            // 
            // chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing
            // 
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.AutoSize = true;
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Location = new System.Drawing.Point(42, 170);
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Name = "chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing";
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Size = new System.Drawing.Size(340, 17);
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.TabIndex = 14;
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Text = "chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing";
            this.tipSettings.SetToolTip(this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing, "Automatically delete youtube-dl.exe when closing youtube-dl-gui");
            this.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.UseVisualStyleBackColor = true;
            // 
            // txtFileNameSchema
            // 
            this.txtFileNameSchema.Location = new System.Drawing.Point(30, 79);
            this.txtFileNameSchema.Name = "txtFileNameSchema";
            this.txtFileNameSchema.Size = new System.Drawing.Size(260, 20);
            this.txtFileNameSchema.TabIndex = 20;
            this.txtFileNameSchema.Text = "%(title)s-%(id)s.%(ext)s";
            this.tipSettings.SetToolTip(this.txtFileNameSchema, "The file name schema\r\n\r\nThis basically replaces sequences with video information " +
        "for a custom file name.");
            // 
            // lbSepDownloads
            // 
            this.lbSepDownloads.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSepDownloads.Location = new System.Drawing.Point(25, 107);
            this.lbSepDownloads.Name = "lbSepDownloads";
            this.lbSepDownloads.Size = new System.Drawing.Size(270, 2);
            this.lbSepDownloads.TabIndex = 11;
            this.lbSepDownloads.Text = "HELLO WORLD";
            this.tipSettings.SetToolTip(this.lbSepDownloads, "this is not an easter egg");
            // 
            // chksettingsDownloadsUseYoutubeDlsUpdater
            // 
            this.chksettingsDownloadsUseYoutubeDlsUpdater.AutoSize = true;
            this.chksettingsDownloadsUseYoutubeDlsUpdater.Checked = true;
            this.chksettingsDownloadsUseYoutubeDlsUpdater.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chksettingsDownloadsUseYoutubeDlsUpdater.Enabled = false;
            this.chksettingsDownloadsUseYoutubeDlsUpdater.Location = new System.Drawing.Point(42, 193);
            this.chksettingsDownloadsUseYoutubeDlsUpdater.Name = "chksettingsDownloadsUseYoutubeDlsUpdater";
            this.chksettingsDownloadsUseYoutubeDlsUpdater.Size = new System.Drawing.Size(244, 17);
            this.chksettingsDownloadsUseYoutubeDlsUpdater.TabIndex = 13;
            this.chksettingsDownloadsUseYoutubeDlsUpdater.Text = "chksettingsDownloadsUseYoutubeDlsUpdater";
            this.tipSettings.SetToolTip(this.chksettingsDownloadsUseYoutubeDlsUpdater, "Use youtube-dl\'s internal updater instead of this application\'s updater");
            this.chksettingsDownloadsUseYoutubeDlsUpdater.UseVisualStyleBackColor = true;
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
            this.tabSettingsConverter.Size = new System.Drawing.Size(320, 253);
            this.tabSettingsConverter.TabIndex = 2;
            this.tabSettingsConverter.Text = "Converter";
            this.tabSettingsConverter.UseVisualStyleBackColor = true;
            // 
            // chkSettingsConverterHideFFmpegCompileInfo
            // 
            this.chkSettingsConverterHideFFmpegCompileInfo.AutoSize = true;
            this.chkSettingsConverterHideFFmpegCompileInfo.Location = new System.Drawing.Point(175, 35);
            this.chkSettingsConverterHideFFmpegCompileInfo.Name = "chkSettingsConverterHideFFmpegCompileInfo";
            this.chkSettingsConverterHideFFmpegCompileInfo.Size = new System.Drawing.Size(242, 17);
            this.chkSettingsConverterHideFFmpegCompileInfo.TabIndex = 19;
            this.chkSettingsConverterHideFFmpegCompileInfo.Text = "chkSettingsConverterHideFFmpegCompileInfo";
            this.tipSettings.SetToolTip(this.chkSettingsConverterHideFFmpegCompileInfo, "Enabling this will hide some compilation information of ffmpeg.");
            this.chkSettingsConverterHideFFmpegCompileInfo.UseVisualStyleBackColor = true;
            // 
            // chkSettingsConverterDetectOutputFileType
            // 
            this.chkSettingsConverterDetectOutputFileType.AutoSize = true;
            this.chkSettingsConverterDetectOutputFileType.Checked = true;
            this.chkSettingsConverterDetectOutputFileType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettingsConverterDetectOutputFileType.Location = new System.Drawing.Point(182, 12);
            this.chkSettingsConverterDetectOutputFileType.Name = "chkSettingsConverterDetectOutputFileType";
            this.chkSettingsConverterDetectOutputFileType.Size = new System.Drawing.Size(231, 17);
            this.chkSettingsConverterDetectOutputFileType.TabIndex = 0;
            this.chkSettingsConverterDetectOutputFileType.Text = "chkSettingsConverterDetectOutputFileType";
            this.tipSettings.SetToolTip(this.chkSettingsConverterDetectOutputFileType, "If Automatic is checked on converting, this will attempt to detect the output fil" +
        "e type.\r\n\r\nDisable this if you want a simple conversion. The quality may suffer " +
        "as a result.");
            this.chkSettingsConverterDetectOutputFileType.UseVisualStyleBackColor = true;
            // 
            // tcConverter
            // 
            this.tcConverter.Controls.Add(this.tcSettingsConverterVideo);
            this.tcConverter.Controls.Add(this.tcSettingsConverterAudio);
            this.tcConverter.Controls.Add(this.tcSettingsConverterCustom);
            this.tcConverter.Location = new System.Drawing.Point(8, 67);
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
            this.tcSettingsConverterVideo.Controls.Add(this.lbkSettingsConverterVideoPreset);
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
            this.chkUseVideoProfile.AutoSize = true;
            this.chkUseVideoProfile.Location = new System.Drawing.Point(72, 70);
            this.chkUseVideoProfile.Name = "chkUseVideoProfile";
            this.chkUseVideoProfile.Size = new System.Drawing.Size(14, 13);
            this.chkUseVideoProfile.TabIndex = 12;
            this.chkUseVideoProfile.UseVisualStyleBackColor = true;
            // 
            // chkSettingsConverterVideoPreset
            // 
            this.chkSettingsConverterVideoPreset.AutoSize = true;
            this.chkSettingsConverterVideoPreset.Location = new System.Drawing.Point(72, 43);
            this.chkSettingsConverterVideoPreset.Name = "chkSettingsConverterVideoPreset";
            this.chkSettingsConverterVideoPreset.Size = new System.Drawing.Size(14, 13);
            this.chkSettingsConverterVideoPreset.TabIndex = 11;
            this.chkSettingsConverterVideoPreset.UseVisualStyleBackColor = true;
            // 
            // chkUseVideoBitrate
            // 
            this.chkUseVideoBitrate.AutoSize = true;
            this.chkUseVideoBitrate.Location = new System.Drawing.Point(72, 16);
            this.chkUseVideoBitrate.Name = "chkUseVideoBitrate";
            this.chkUseVideoBitrate.Size = new System.Drawing.Size(14, 13);
            this.chkUseVideoBitrate.TabIndex = 10;
            this.chkUseVideoBitrate.UseVisualStyleBackColor = true;
            // 
            // chkSettingsConverterVideoFastStart
            // 
            this.chkSettingsConverterVideoFastStart.AutoSize = true;
            this.chkSettingsConverterVideoFastStart.Location = new System.Drawing.Point(117, 126);
            this.chkSettingsConverterVideoFastStart.Name = "chkSettingsConverterVideoFastStart";
            this.chkSettingsConverterVideoFastStart.Size = new System.Drawing.Size(196, 17);
            this.chkSettingsConverterVideoFastStart.TabIndex = 9;
            this.chkSettingsConverterVideoFastStart.Text = "chkSettingsConverterVideoFastStart";
            this.tipSettings.SetToolTip(this.chkSettingsConverterVideoFastStart, "Faststart moves the metadata to the front of the file.\r\n\r\nEnabling this allows vi" +
        "deos to be played before they are fully downloaded.");
            this.chkSettingsConverterVideoFastStart.UseVisualStyleBackColor = true;
            // 
            // numConvertVideoCRF
            // 
            this.numConvertVideoCRF.Location = new System.Drawing.Point(131, 94);
            this.numConvertVideoCRF.Maximum = new decimal(new int[] {
            51,
            0,
            0,
            0});
            this.numConvertVideoCRF.Name = "numConvertVideoCRF";
            this.numConvertVideoCRF.Size = new System.Drawing.Size(39, 20);
            this.numConvertVideoCRF.TabIndex = 7;
            this.tipSettings.SetToolTip(this.numConvertVideoCRF, "CRF is constant rate factor.\r\n\r\nLower = Higher quality");
            this.numConvertVideoCRF.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // cbConvertVideoProfile
            // 
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
            this.tipSettings.SetToolTip(this.cbConvertVideoProfile, "The encoder profile to be used during conversion. It affects the compression of t" +
        "he video.\r\n\r\nIt\'s generally a good idea to stick with the main profile\r\n\r\nThis w" +
        "ill not effect certain conversions.");
            // 
            // cbConvertVideoPreset
            // 
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
            this.tipSettings.SetToolTip(this.cbConvertVideoPreset, "The video preset of the conversion\r\n\r\nultrafast = fastest, but lower quality\r\nver" +
        "yslow = slowest, but higher quality");
            // 
            // numConvertVideoBitrate
            // 
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
            this.tipSettings.SetToolTip(this.numConvertVideoBitrate, resources.GetString("numConvertVideoBitrate.ToolTip"));
            this.numConvertVideoBitrate.Value = new decimal(new int[] {
            7500,
            0,
            0,
            0});
            // 
            // lbConvertVideoThousands
            // 
            this.lbConvertVideoThousands.AutoSize = true;
            this.lbConvertVideoThousands.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConvertVideoThousands.Location = new System.Drawing.Point(208, 14);
            this.lbConvertVideoThousands.Name = "lbConvertVideoThousands";
            this.lbConvertVideoThousands.Size = new System.Drawing.Size(16, 17);
            this.lbConvertVideoThousands.TabIndex = 2;
            this.lbConvertVideoThousands.Text = "K";
            this.tipSettings.SetToolTip(this.lbConvertVideoThousands, "If you were to input \"10,000\" as the bitrate, it would be interpreted as \"10,000," +
        "000\" bits per second.");
            // 
            // lbSettingsConverterVideoBitrate
            // 
            this.lbSettingsConverterVideoBitrate.AutoSize = true;
            this.lbSettingsConverterVideoBitrate.Location = new System.Drawing.Point(86, 16);
            this.lbSettingsConverterVideoBitrate.Name = "lbSettingsConverterVideoBitrate";
            this.lbSettingsConverterVideoBitrate.Size = new System.Drawing.Size(156, 13);
            this.lbSettingsConverterVideoBitrate.TabIndex = 1;
            this.lbSettingsConverterVideoBitrate.Text = "lbSettingsConverterVideoBitrate";
            this.tipSettings.SetToolTip(this.lbSettingsConverterVideoBitrate, resources.GetString("lbSettingsConverterVideoBitrate.ToolTip"));
            // 
            // lbkSettingsConverterVideoPreset
            // 
            this.lbkSettingsConverterVideoPreset.AutoSize = true;
            this.lbkSettingsConverterVideoPreset.Location = new System.Drawing.Point(86, 43);
            this.lbkSettingsConverterVideoPreset.Name = "lbkSettingsConverterVideoPreset";
            this.lbkSettingsConverterVideoPreset.Size = new System.Drawing.Size(162, 13);
            this.lbkSettingsConverterVideoPreset.TabIndex = 4;
            this.lbkSettingsConverterVideoPreset.Text = "lbkSettingsConverterVideoPreset";
            this.tipSettings.SetToolTip(this.lbkSettingsConverterVideoPreset, "The video preset of the conversion\r\n\r\nultrafast = fastest, but lower quality\r\nver" +
        "yslow = slowest, but higher quality");
            // 
            // lbSettingsConverterVideoProfile
            // 
            this.lbSettingsConverterVideoProfile.AutoSize = true;
            this.lbSettingsConverterVideoProfile.Location = new System.Drawing.Point(87, 70);
            this.lbSettingsConverterVideoProfile.Name = "lbSettingsConverterVideoProfile";
            this.lbSettingsConverterVideoProfile.Size = new System.Drawing.Size(155, 13);
            this.lbSettingsConverterVideoProfile.TabIndex = 6;
            this.lbSettingsConverterVideoProfile.Text = "lbSettingsConverterVideoProfile";
            this.tipSettings.SetToolTip(this.lbSettingsConverterVideoProfile, "The encoder profile to be used during conversion. It affects the compression of t" +
        "he video.\r\nIt\'s generally a good idea to stick with the main profile");
            // 
            // lbSettingsConverterVideoCRF
            // 
            this.lbSettingsConverterVideoCRF.AutoSize = true;
            this.lbSettingsConverterVideoCRF.Location = new System.Drawing.Point(95, 96);
            this.lbSettingsConverterVideoCRF.Name = "lbSettingsConverterVideoCRF";
            this.lbSettingsConverterVideoCRF.Size = new System.Drawing.Size(147, 13);
            this.lbSettingsConverterVideoCRF.TabIndex = 8;
            this.lbSettingsConverterVideoCRF.Text = "lbSettingsConverterVideoCRF";
            this.tipSettings.SetToolTip(this.lbSettingsConverterVideoCRF, "CRF is constant rate factor.\r\n\r\nLower = Higher quality");
            // 
            // tcSettingsConverterAudio
            // 
            this.tcSettingsConverterAudio.Controls.Add(this.chkUseAudioBitrate);
            this.tcSettingsConverterAudio.Controls.Add(this.numConvertAudioBitrate);
            this.tcSettingsConverterAudio.Controls.Add(this.lbidkwhatsup);
            this.tcSettingsConverterAudio.Controls.Add(this.lbConvertAudioThousands);
            this.tcSettingsConverterAudio.Controls.Add(this.chkSettingsConverterAudioBitrate);
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
            this.tipSettings.SetToolTip(this.numConvertAudioBitrate, resources.GetString("numConvertAudioBitrate.ToolTip"));
            this.numConvertAudioBitrate.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            // 
            // lbidkwhatsup
            // 
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
            this.lbConvertAudioThousands.AutoSize = true;
            this.lbConvertAudioThousands.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConvertAudioThousands.Location = new System.Drawing.Point(192, 20);
            this.lbConvertAudioThousands.Name = "lbConvertAudioThousands";
            this.lbConvertAudioThousands.Size = new System.Drawing.Size(16, 17);
            this.lbConvertAudioThousands.TabIndex = 18;
            this.lbConvertAudioThousands.Text = "K";
            this.tipSettings.SetToolTip(this.lbConvertAudioThousands, "If you were to input \"256\" as the bitrate, it would be interpreted as \"256,000\" b" +
        "its per second.");
            // 
            // chkSettingsConverterAudioBitrate
            // 
            this.chkSettingsConverterAudioBitrate.AutoSize = true;
            this.chkSettingsConverterAudioBitrate.Location = new System.Drawing.Point(102, 21);
            this.chkSettingsConverterAudioBitrate.Name = "chkSettingsConverterAudioBitrate";
            this.chkSettingsConverterAudioBitrate.Size = new System.Drawing.Size(166, 13);
            this.chkSettingsConverterAudioBitrate.TabIndex = 19;
            this.chkSettingsConverterAudioBitrate.Text = "chkSettingsConverterAudioBitrate";
            this.tipSettings.SetToolTip(this.chkSettingsConverterAudioBitrate, resources.GetString("chkSettingsConverterAudioBitrate.ToolTip"));
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
            this.txtSettingsConverterCustomArguments.Location = new System.Drawing.Point(36, 97);
            this.txtSettingsConverterCustomArguments.Name = "txtSettingsConverterCustomArguments";
            this.txtSettingsConverterCustomArguments.Size = new System.Drawing.Size(228, 20);
            this.txtSettingsConverterCustomArguments.TabIndex = 1;
            this.tipSettings.SetToolTip(this.txtSettingsConverterCustomArguments, "Custom arguments that will be passed through ffmpeg instead of built-in arguments" +
        "");
            // 
            // lbSettingsConverterCustomHeader
            // 
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
            this.tipSettings.SetToolTip(this.chkSettingsConverterClearInputAfterConverting, "Clears the input file after a successful conversion");
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
            this.tipSettings.SetToolTip(this.chkSettingsConverterClearOutputAfterConverting, "Clears the output file after a successful conversion\r\n");
            this.chkSettingsConverterClearOutputAfterConverting.UseVisualStyleBackColor = true;
            // 
            // tabSettingsExtensions
            // 
            this.tabSettingsExtensions.Controls.Add(this.lbSettingsExtensionsFileName);
            this.tabSettingsExtensions.Controls.Add(this.btnSettingsExtensionsAdd);
            this.tabSettingsExtensions.Controls.Add(this.btnSettingsExtensionsRemoveSelected);
            this.tabSettingsExtensions.Controls.Add(this.listExtensions);
            this.tabSettingsExtensions.Controls.Add(this.lbSettingsExtensionsExtensionShort);
            this.tabSettingsExtensions.Controls.Add(this.txtExtensionsShort);
            this.tabSettingsExtensions.Controls.Add(this.lbSettingsExtensionsExtensionFullName);
            this.tabSettingsExtensions.Controls.Add(this.txtExtensionsName);
            this.tabSettingsExtensions.Controls.Add(this.lbSettingsExtensionsHeader);
            this.tabSettingsExtensions.Location = new System.Drawing.Point(4, 22);
            this.tabSettingsExtensions.Name = "tabSettingsExtensions";
            this.tabSettingsExtensions.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettingsExtensions.Size = new System.Drawing.Size(320, 253);
            this.tabSettingsExtensions.TabIndex = 4;
            this.tabSettingsExtensions.Text = "Extensions";
            this.tabSettingsExtensions.UseVisualStyleBackColor = true;
            // 
            // lbSettingsExtensionsFileName
            // 
            this.lbSettingsExtensionsFileName.AutoSize = true;
            this.lbSettingsExtensionsFileName.Location = new System.Drawing.Point(30, 226);
            this.lbSettingsExtensionsFileName.Name = "lbSettingsExtensionsFileName";
            this.lbSettingsExtensionsFileName.Size = new System.Drawing.Size(148, 13);
            this.lbSettingsExtensionsFileName.TabIndex = 9;
            this.lbSettingsExtensionsFileName.Text = "lbSettingsExtensionsFileName";
            // 
            // btnSettingsExtensionsAdd
            // 
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
            this.btnSettingsExtensionsRemoveSelected.Location = new System.Drawing.Point(192, 222);
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
            this.listExtensions.FormattingEnabled = true;
            this.listExtensions.Location = new System.Drawing.Point(31, 96);
            this.listExtensions.Name = "listExtensions";
            this.listExtensions.Size = new System.Drawing.Size(261, 121);
            this.listExtensions.TabIndex = 6;
            this.listExtensions.SelectedIndexChanged += new System.EventHandler(this.listExtensions_SelectedIndexChanged);
            // 
            // lbSettingsExtensionsExtensionShort
            // 
            this.lbSettingsExtensionsExtensionShort.AutoSize = true;
            this.lbSettingsExtensionsExtensionShort.Location = new System.Drawing.Point(178, 49);
            this.lbSettingsExtensionsExtensionShort.Name = "lbSettingsExtensionsExtensionShort";
            this.lbSettingsExtensionsExtensionShort.Size = new System.Drawing.Size(175, 13);
            this.lbSettingsExtensionsExtensionShort.TabIndex = 5;
            this.lbSettingsExtensionsExtensionShort.Text = "lbSettingsExtensionsExtensionShort";
            // 
            // txtExtensionsShort
            // 
            this.txtExtensionsShort.Location = new System.Drawing.Point(181, 65);
            this.txtExtensionsShort.Name = "txtExtensionsShort";
            this.txtExtensionsShort.Size = new System.Drawing.Size(57, 20);
            this.txtExtensionsShort.TabIndex = 4;
            // 
            // lbSettingsExtensionsExtensionFullName
            // 
            this.lbSettingsExtensionsExtensionFullName.AutoSize = true;
            this.lbSettingsExtensionsExtensionFullName.Location = new System.Drawing.Point(28, 49);
            this.lbSettingsExtensionsExtensionFullName.Name = "lbSettingsExtensionsExtensionFullName";
            this.lbSettingsExtensionsExtensionFullName.Size = new System.Drawing.Size(194, 13);
            this.lbSettingsExtensionsExtensionFullName.TabIndex = 3;
            this.lbSettingsExtensionsExtensionFullName.Text = "lbSettingsExtensionsExtensionFullName";
            // 
            // txtExtensionsName
            // 
            this.txtExtensionsName.Location = new System.Drawing.Point(31, 65);
            this.txtExtensionsName.Name = "txtExtensionsName";
            this.txtExtensionsName.Size = new System.Drawing.Size(144, 20);
            this.txtExtensionsName.TabIndex = 2;
            // 
            // lbSettingsExtensionsHeader
            // 
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
            this.tabSettingsErrors.Size = new System.Drawing.Size(320, 253);
            this.tabSettingsErrors.TabIndex = 3;
            this.tabSettingsErrors.Text = "Errors";
            this.tabSettingsErrors.UseVisualStyleBackColor = true;
            // 
            // chkSettingsErrorsSaveErrorsAsErrorLog
            // 
            this.chkSettingsErrorsSaveErrorsAsErrorLog.AutoSize = true;
            this.chkSettingsErrorsSaveErrorsAsErrorLog.Location = new System.Drawing.Point(93, 129);
            this.chkSettingsErrorsSaveErrorsAsErrorLog.Name = "chkSettingsErrorsSaveErrorsAsErrorLog";
            this.chkSettingsErrorsSaveErrorsAsErrorLog.Size = new System.Drawing.Size(212, 17);
            this.chkSettingsErrorsSaveErrorsAsErrorLog.TabIndex = 2;
            this.chkSettingsErrorsSaveErrorsAsErrorLog.Text = "chkSettingsErrorsSaveErrorsAsErrorLog";
            this.tipSettings.SetToolTip(this.chkSettingsErrorsSaveErrorsAsErrorLog, "Saves the latest error as error.log in the exeucting directory of youtube-dl-gui");
            this.chkSettingsErrorsSaveErrorsAsErrorLog.UseVisualStyleBackColor = true;
            // 
            // chkSettingsErrorsShowDetailedErrors
            // 
            this.chkSettingsErrorsShowDetailedErrors.AutoSize = true;
            this.chkSettingsErrorsShowDetailedErrors.Location = new System.Drawing.Point(93, 106);
            this.chkSettingsErrorsShowDetailedErrors.Name = "chkSettingsErrorsShowDetailedErrors";
            this.chkSettingsErrorsShowDetailedErrors.Size = new System.Drawing.Size(201, 17);
            this.chkSettingsErrorsShowDetailedErrors.TabIndex = 1;
            this.chkSettingsErrorsShowDetailedErrors.Text = "chkSettingsErrorsShowDetailedErrors";
            this.tipSettings.SetToolTip(this.chkSettingsErrorsShowDetailedErrors, "Shows more details in errors");
            this.chkSettingsErrorsShowDetailedErrors.UseVisualStyleBackColor = true;
            // 
            // chkSettingsErrorsSuppressErrors
            // 
            this.chkSettingsErrorsSuppressErrors.AutoSize = true;
            this.chkSettingsErrorsSuppressErrors.Location = new System.Drawing.Point(111, 213);
            this.chkSettingsErrorsSuppressErrors.Name = "chkSettingsErrorsSuppressErrors";
            this.chkSettingsErrorsSuppressErrors.Size = new System.Drawing.Size(179, 17);
            this.chkSettingsErrorsSuppressErrors.TabIndex = 0;
            this.chkSettingsErrorsSuppressErrors.Text = "chkSettingsErrorsSuppressErrors";
            this.tipSettings.SetToolTip(this.chkSettingsErrorsSuppressErrors, "This will silence any errors and will not save any error.log files.\r\n\r\nThis basic" +
        "ally overrides all error settings. Use at your own risk.");
            this.chkSettingsErrorsSuppressErrors.UseVisualStyleBackColor = true;
            // 
            // btnSettingsRedownloadYoutubeDl
            // 
            this.btnSettingsRedownloadYoutubeDl.Location = new System.Drawing.Point(4, 289);
            this.btnSettingsRedownloadYoutubeDl.Name = "btnSettingsRedownloadYoutubeDl";
            this.btnSettingsRedownloadYoutubeDl.Size = new System.Drawing.Size(140, 23);
            this.btnSettingsRedownloadYoutubeDl.TabIndex = 18;
            this.btnSettingsRedownloadYoutubeDl.Text = "btnSettingsRedownloadYoutubeDl";
            this.tipSettings.SetToolTip(this.btnSettingsRedownloadYoutubeDl, "Redownloads youtube-dl if one is already present, otherwise, updates youtube-dl");
            this.btnSettingsRedownloadYoutubeDl.UseVisualStyleBackColor = true;
            this.btnSettingsRedownloadYoutubeDl.Click += new System.EventHandler(this.btnSettingsRedownloadYoutubeDl_Click);
            // 
            // btnSettingsCancel
            // 
            this.btnSettingsCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsCancel.Location = new System.Drawing.Point(168, 289);
            this.btnSettingsCancel.Name = "btnSettingsCancel";
            this.btnSettingsCancel.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsCancel.TabIndex = 1;
            this.btnSettingsCancel.Text = "btnSettingsCancel";
            this.tipSettings.SetToolTip(this.btnSettingsCancel, "Discard any changed settings");
            this.btnSettingsCancel.UseVisualStyleBackColor = true;
            this.btnSettingsCancel.Click += new System.EventHandler(this.btnSettingsCancel_Click);
            // 
            // btnSettingsSave
            // 
            this.btnSettingsSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSettingsSave.Location = new System.Drawing.Point(249, 289);
            this.btnSettingsSave.Name = "btnSettingsSave";
            this.btnSettingsSave.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsSave.TabIndex = 2;
            this.btnSettingsSave.Text = "btnSettingsSave";
            this.tipSettings.SetToolTip(this.btnSettingsSave, "Save all configured settings");
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
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(328, 324);
            this.Controls.Add(this.btnSettingsSave);
            this.Controls.Add(this.btnSettingsCancel);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.btnSettingsRedownloadYoutubeDl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(336, 354);
            this.MinimumSize = new System.Drawing.Size(336, 354);
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
            this.tbSettingsDownloads.ResumeLayout(false);
            this.tbSettingsDownloads.PerformLayout();
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
        private System.Windows.Forms.Button btnBrwsFF;
        private System.Windows.Forms.Button btnBrwsYtdl;
        private System.Windows.Forms.CheckBox chkSettingsGeneralUseStaticYoutubeDl;
        private System.Windows.Forms.CheckBox chkSettingsGeneralUseStaticFFmpeg;
        private System.Windows.Forms.TextBox txtFFmpeg;
        private System.Windows.Forms.Label lbSettingsGeneralFFmpegDirectory;
        private System.Windows.Forms.TextBox txtYtdl;
        private System.Windows.Forms.Label lbSettingsGeneralYoutubeDlPath;
        private System.Windows.Forms.TabPage tbSettingsDownloads;
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
        private System.Windows.Forms.Button btnBrowseSaveto;
        private System.Windows.Forms.TextBox txtSaveto;
        private System.Windows.Forms.Label lbSettingsDownloadsDownloadPath;
        private System.Windows.Forms.Label lbSepDownloads;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsSeparateDownloadsToDifferentFolders;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsSaveFormatQuality;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing;
        private System.Windows.Forms.Button btnSettingsRedownloadYoutubeDl;
        private System.Windows.Forms.CheckBox chkSettingsConverterDetectOutputFileType;
        private System.Windows.Forms.TextBox txtFileNameSchema;
        private System.Windows.Forms.Label lbSettingsDownloadsFileNameSchema;
        private System.Windows.Forms.LinkLabel llSchema;
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
        private System.Windows.Forms.Label lbkSettingsConverterVideoPreset;
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
        private System.Windows.Forms.TextBox txtExtensionsShort;
        private System.Windows.Forms.Label lbSettingsExtensionsExtensionFullName;
        private System.Windows.Forms.TextBox txtExtensionsName;
        private System.Windows.Forms.Button btnSettingsExtensionsAdd;
        private System.Windows.Forms.Label lbSettingsExtensionsFileName;
        private System.Windows.Forms.CheckBox chkUseVideoCRF;
        private System.Windows.Forms.CheckBox chkUseVideoProfile;
        private System.Windows.Forms.CheckBox chkSettingsConverterVideoPreset;
        private System.Windows.Forms.CheckBox chkUseVideoBitrate;
        private System.Windows.Forms.CheckBox chkUseAudioBitrate;
        private System.Windows.Forms.Label chkSettingsConverterAudioBitrate;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsFixVReddIt;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsSeparateIntoWebsiteUrl;
        private System.Windows.Forms.TextBox txtSubtitlesLanguages;
        private System.Windows.Forms.CheckBox chkSettingsDownloadsDownloadSubtitles;
    }
}