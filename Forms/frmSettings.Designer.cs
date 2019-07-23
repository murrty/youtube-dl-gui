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
            this.tbGeneral = new System.Windows.Forms.TabPage();
            this.gbArguments = new System.Windows.Forms.GroupBox();
            this.rbArgsAsSettings = new System.Windows.Forms.RadioButton();
            this.rbArgsAsTxt = new System.Windows.Forms.RadioButton();
            this.rbDontSaveArgs = new System.Windows.Forms.RadioButton();
            this.chkClear = new System.Windows.Forms.CheckBox();
            this.chkHover = new System.Windows.Forms.CheckBox();
            this.chkUpdates = new System.Windows.Forms.CheckBox();
            this.lbSepGeneral = new System.Windows.Forms.Label();
            this.btnBrwsFF = new System.Windows.Forms.Button();
            this.btnBrwsYtdl = new System.Windows.Forms.Button();
            this.chkStaticYtdl = new System.Windows.Forms.CheckBox();
            this.chkStaticFF = new System.Windows.Forms.CheckBox();
            this.txtFFmpeg = new System.Windows.Forms.TextBox();
            this.lbFFmpegPath = new System.Windows.Forms.Label();
            this.txtYtdl = new System.Windows.Forms.TextBox();
            this.lbYtdlPath = new System.Windows.Forms.Label();
            this.tbDownloads = new System.Windows.Forms.TabPage();
            this.lbDownloadPath = new System.Windows.Forms.Label();
            this.chkFixReddit = new System.Windows.Forms.CheckBox();
            this.txtSaveto = new System.Windows.Forms.TextBox();
            this.chkSaveParams = new System.Windows.Forms.CheckBox();
            this.llSchema = new System.Windows.Forms.LinkLabel();
            this.chkSeparate = new System.Windows.Forms.CheckBox();
            this.btnBrowseSaveto = new System.Windows.Forms.Button();
            this.chkAutomaticallyDelete = new System.Windows.Forms.CheckBox();
            this.txtFileNameSchema = new System.Windows.Forms.TextBox();
            this.btnRedownloadYtdl = new System.Windows.Forms.Button();
            this.lbSepDownloads = new System.Windows.Forms.Label();
            this.chkYtdlUpdate = new System.Windows.Forms.CheckBox();
            this.lbFileSchema = new System.Windows.Forms.Label();
            this.tbConverter = new System.Windows.Forms.TabPage();
            this.chkConvertHideFFmpeg = new System.Windows.Forms.CheckBox();
            this.tcConverter = new System.Windows.Forms.TabControl();
            this.tabConvertVideo = new System.Windows.Forms.TabPage();
            this.chkUseVideoCRF = new System.Windows.Forms.CheckBox();
            this.chkUseVideoProfile = new System.Windows.Forms.CheckBox();
            this.chkUseVideoPreset = new System.Windows.Forms.CheckBox();
            this.chkUseVideoBitrate = new System.Windows.Forms.CheckBox();
            this.chkVideoFastStart = new System.Windows.Forms.CheckBox();
            this.lbConvertVideoCRF = new System.Windows.Forms.Label();
            this.numConvertVideoCRF = new System.Windows.Forms.NumericUpDown();
            this.lbConvertVideoProfile = new System.Windows.Forms.Label();
            this.cbConvertVideoProfile = new System.Windows.Forms.ComboBox();
            this.lbConvertVideoPreset = new System.Windows.Forms.Label();
            this.cbConvertVideoPreset = new System.Windows.Forms.ComboBox();
            this.lbConvertVideoBitrate = new System.Windows.Forms.Label();
            this.numConvertVideoBitrate = new System.Windows.Forms.NumericUpDown();
            this.lbConvertVideoThousands = new System.Windows.Forms.Label();
            this.tabConvertAudio = new System.Windows.Forms.TabPage();
            this.chkUseAudioBitrate = new System.Windows.Forms.CheckBox();
            this.lbAudioBitrate = new System.Windows.Forms.Label();
            this.numConvertAudioBitrate = new System.Windows.Forms.NumericUpDown();
            this.lbidkwhatsup = new System.Windows.Forms.Label();
            this.lbConvertAudioThousands = new System.Windows.Forms.Label();
            this.tabConvertCustom = new System.Windows.Forms.TabPage();
            this.txtConvertCustom = new System.Windows.Forms.TextBox();
            this.lbConverterCustom = new System.Windows.Forms.Label();
            this.chkConvClearInput = new System.Windows.Forms.CheckBox();
            this.chkConvClearOutput = new System.Windows.Forms.CheckBox();
            this.chkConvertDetectFiletype = new System.Windows.Forms.CheckBox();
            this.tabExtensions = new System.Windows.Forms.TabPage();
            this.lbFileExtension = new System.Windows.Forms.Label();
            this.btnAddExtension = new System.Windows.Forms.Button();
            this.btnRemoveExtension = new System.Windows.Forms.Button();
            this.listExtensions = new System.Windows.Forms.ListBox();
            this.lbExtensionShortName = new System.Windows.Forms.Label();
            this.txtExtensionsShort = new System.Windows.Forms.TextBox();
            this.lbExtensionFull = new System.Windows.Forms.Label();
            this.txtExtensionsName = new System.Windows.Forms.TextBox();
            this.lbExtensions = new System.Windows.Forms.Label();
            this.tabError = new System.Windows.Forms.TabPage();
            this.chkErrorsLogFile = new System.Windows.Forms.CheckBox();
            this.chkErrorsDetailed = new System.Windows.Forms.CheckBox();
            this.chkErrorsSuppressed = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tipSettings = new System.Windows.Forms.ToolTip(this.components);
            this.tcMain.SuspendLayout();
            this.tbGeneral.SuspendLayout();
            this.gbArguments.SuspendLayout();
            this.tbDownloads.SuspendLayout();
            this.tbConverter.SuspendLayout();
            this.tcConverter.SuspendLayout();
            this.tabConvertVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertVideoCRF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertVideoBitrate)).BeginInit();
            this.tabConvertAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertAudioBitrate)).BeginInit();
            this.tabConvertCustom.SuspendLayout();
            this.tabExtensions.SuspendLayout();
            this.tabError.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tbGeneral);
            this.tcMain.Controls.Add(this.tbDownloads);
            this.tcMain.Controls.Add(this.tbConverter);
            this.tcMain.Controls.Add(this.tabExtensions);
            this.tcMain.Controls.Add(this.tabError);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(328, 279);
            this.tcMain.TabIndex = 0;
            // 
            // tbGeneral
            // 
            this.tbGeneral.Controls.Add(this.gbArguments);
            this.tbGeneral.Controls.Add(this.chkClear);
            this.tbGeneral.Controls.Add(this.chkHover);
            this.tbGeneral.Controls.Add(this.chkUpdates);
            this.tbGeneral.Controls.Add(this.lbSepGeneral);
            this.tbGeneral.Controls.Add(this.btnBrwsFF);
            this.tbGeneral.Controls.Add(this.btnBrwsYtdl);
            this.tbGeneral.Controls.Add(this.chkStaticYtdl);
            this.tbGeneral.Controls.Add(this.chkStaticFF);
            this.tbGeneral.Controls.Add(this.txtFFmpeg);
            this.tbGeneral.Controls.Add(this.lbFFmpegPath);
            this.tbGeneral.Controls.Add(this.txtYtdl);
            this.tbGeneral.Controls.Add(this.lbYtdlPath);
            this.tbGeneral.Location = new System.Drawing.Point(4, 22);
            this.tbGeneral.Name = "tbGeneral";
            this.tbGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbGeneral.Size = new System.Drawing.Size(320, 253);
            this.tbGeneral.TabIndex = 0;
            this.tbGeneral.Text = "General";
            this.tbGeneral.UseVisualStyleBackColor = true;
            // 
            // gbArguments
            // 
            this.gbArguments.Controls.Add(this.rbArgsAsSettings);
            this.gbArguments.Controls.Add(this.rbArgsAsTxt);
            this.gbArguments.Controls.Add(this.rbDontSaveArgs);
            this.gbArguments.Location = new System.Drawing.Point(6, 196);
            this.gbArguments.Name = "gbArguments";
            this.gbArguments.Size = new System.Drawing.Size(308, 46);
            this.gbArguments.TabIndex = 12;
            this.gbArguments.TabStop = false;
            this.gbArguments.Text = "Custom arguments (saves on download)";
            this.tipSettings.SetToolTip(this.gbArguments, "Controls how custom arguments for youtube-dl will be saved");
            // 
            // rbArgsAsSettings
            // 
            this.rbArgsAsSettings.AutoSize = true;
            this.rbArgsAsSettings.Checked = true;
            this.rbArgsAsSettings.Location = new System.Drawing.Point(203, 20);
            this.rbArgsAsSettings.Name = "rbArgsAsSettings";
            this.rbArgsAsSettings.Size = new System.Drawing.Size(101, 17);
            this.rbArgsAsSettings.TabIndex = 2;
            this.rbArgsAsSettings.TabStop = true;
            this.rbArgsAsSettings.Text = "Save in Settings";
            this.tipSettings.SetToolTip(this.rbArgsAsSettings, "Saves custom arguments in the application settings");
            this.rbArgsAsSettings.UseVisualStyleBackColor = true;
            // 
            // rbArgsAsTxt
            // 
            this.rbArgsAsTxt.AutoSize = true;
            this.rbArgsAsTxt.Location = new System.Drawing.Point(89, 20);
            this.rbArgsAsTxt.Name = "rbArgsAsTxt";
            this.rbArgsAsTxt.Size = new System.Drawing.Size(108, 17);
            this.rbArgsAsTxt.TabIndex = 1;
            this.rbArgsAsTxt.Text = "Save as ./args.txt";
            this.tipSettings.SetToolTip(this.rbArgsAsTxt, "Saves custom arguments as args.txt in youtube-dl-gui\'s directory");
            this.rbArgsAsTxt.UseVisualStyleBackColor = true;
            // 
            // rbDontSaveArgs
            // 
            this.rbDontSaveArgs.AutoSize = true;
            this.rbDontSaveArgs.Location = new System.Drawing.Point(8, 20);
            this.rbDontSaveArgs.Name = "rbDontSaveArgs";
            this.rbDontSaveArgs.Size = new System.Drawing.Size(75, 17);
            this.rbDontSaveArgs.TabIndex = 0;
            this.rbDontSaveArgs.Text = "Don\'t save";
            this.tipSettings.SetToolTip(this.rbDontSaveArgs, "Doesn\'t save any custom arguments");
            this.rbDontSaveArgs.UseVisualStyleBackColor = true;
            // 
            // chkClear
            // 
            this.chkClear.AutoSize = true;
            this.chkClear.Location = new System.Drawing.Point(64, 165);
            this.chkClear.Name = "chkClear";
            this.chkClear.Size = new System.Drawing.Size(193, 17);
            this.chkClear.TabIndex = 11;
            this.chkClear.Text = "Clear URL + clipboard on download";
            this.tipSettings.SetToolTip(this.chkClear, "Clears the URL from the textbox and clipboard on video download");
            this.chkClear.UseVisualStyleBackColor = true;
            // 
            // chkHover
            // 
            this.chkHover.AutoSize = true;
            this.chkHover.Checked = true;
            this.chkHover.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHover.Location = new System.Drawing.Point(65, 142);
            this.chkHover.Name = "chkHover";
            this.chkHover.Size = new System.Drawing.Size(190, 17);
            this.chkHover.TabIndex = 10;
            this.chkHover.Text = "Hover over URL to paste clipboard";
            this.tipSettings.SetToolTip(this.chkHover, "Hover over the URL textbox to paste the URL from the clipboard");
            this.chkHover.UseVisualStyleBackColor = true;
            // 
            // chkUpdates
            // 
            this.chkUpdates.AutoSize = true;
            this.chkUpdates.Location = new System.Drawing.Point(79, 119);
            this.chkUpdates.Name = "chkUpdates";
            this.chkUpdates.Size = new System.Drawing.Size(162, 17);
            this.chkUpdates.TabIndex = 9;
            this.chkUpdates.Text = "Check for updates on launch";
            this.tipSettings.SetToolTip(this.chkUpdates, "Check for updates on launch of youtube-dl-gui");
            this.chkUpdates.UseVisualStyleBackColor = true;
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
            // chkStaticYtdl
            // 
            this.chkStaticYtdl.AutoSize = true;
            this.chkStaticYtdl.Location = new System.Drawing.Point(122, 11);
            this.chkStaticYtdl.Name = "chkStaticYtdl";
            this.chkStaticYtdl.Size = new System.Drawing.Size(124, 17);
            this.chkStaticYtdl.TabIndex = 5;
            this.chkStaticYtdl.Text = "Use static youtube-dl";
            this.tipSettings.SetToolTip(this.chkStaticYtdl, "Use a static placed youtube-dl.exe file");
            this.chkStaticYtdl.UseVisualStyleBackColor = true;
            // 
            // chkStaticFF
            // 
            this.chkStaticFF.AutoSize = true;
            this.chkStaticFF.Location = new System.Drawing.Point(122, 58);
            this.chkStaticFF.Name = "chkStaticFF";
            this.chkStaticFF.Size = new System.Drawing.Size(107, 17);
            this.chkStaticFF.TabIndex = 4;
            this.chkStaticFF.Text = "Use static ffmpeg";
            this.tipSettings.SetToolTip(this.chkStaticFF, "Use a static placed ffmpeg.exe and ffprobe.exe files");
            this.chkStaticFF.UseVisualStyleBackColor = true;
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
            // lbFFmpegPath
            // 
            this.lbFFmpegPath.AutoSize = true;
            this.lbFFmpegPath.Location = new System.Drawing.Point(19, 59);
            this.lbFFmpegPath.Name = "lbFFmpegPath";
            this.lbFFmpegPath.Size = new System.Drawing.Size(82, 13);
            this.lbFFmpegPath.TabIndex = 2;
            this.lbFFmpegPath.Text = "ffmpeg directory";
            this.tipSettings.SetToolTip(this.lbFFmpegPath, "Static ffmpeg directory\r\n\r\nStatic ffmpeg means ffmpeg will always be located in t" +
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
            // lbYtdlPath
            // 
            this.lbYtdlPath.AutoSize = true;
            this.lbYtdlPath.Location = new System.Drawing.Point(19, 12);
            this.lbYtdlPath.Name = "lbYtdlPath";
            this.lbYtdlPath.Size = new System.Drawing.Size(80, 13);
            this.lbYtdlPath.TabIndex = 0;
            this.lbYtdlPath.Text = "youtube-dl path";
            this.tipSettings.SetToolTip(this.lbYtdlPath, "Static youtube-dl directory\r\n\r\nStatic youtube-dl means youtube-dl will always be " +
        "located in that one directory.\r\n");
            // 
            // tbDownloads
            // 
            this.tbDownloads.Controls.Add(this.lbDownloadPath);
            this.tbDownloads.Controls.Add(this.chkFixReddit);
            this.tbDownloads.Controls.Add(this.txtSaveto);
            this.tbDownloads.Controls.Add(this.chkSaveParams);
            this.tbDownloads.Controls.Add(this.llSchema);
            this.tbDownloads.Controls.Add(this.chkSeparate);
            this.tbDownloads.Controls.Add(this.btnBrowseSaveto);
            this.tbDownloads.Controls.Add(this.chkAutomaticallyDelete);
            this.tbDownloads.Controls.Add(this.txtFileNameSchema);
            this.tbDownloads.Controls.Add(this.btnRedownloadYtdl);
            this.tbDownloads.Controls.Add(this.lbSepDownloads);
            this.tbDownloads.Controls.Add(this.chkYtdlUpdate);
            this.tbDownloads.Controls.Add(this.lbFileSchema);
            this.tbDownloads.Location = new System.Drawing.Point(4, 22);
            this.tbDownloads.Name = "tbDownloads";
            this.tbDownloads.Padding = new System.Windows.Forms.Padding(3);
            this.tbDownloads.Size = new System.Drawing.Size(320, 253);
            this.tbDownloads.TabIndex = 1;
            this.tbDownloads.Text = "Downloads";
            this.tbDownloads.UseVisualStyleBackColor = true;
            // 
            // lbDownloadPath
            // 
            this.lbDownloadPath.AutoSize = true;
            this.lbDownloadPath.Location = new System.Drawing.Point(19, 12);
            this.lbDownloadPath.Name = "lbDownloadPath";
            this.lbDownloadPath.Size = new System.Drawing.Size(77, 13);
            this.lbDownloadPath.TabIndex = 7;
            this.lbDownloadPath.Text = "download path";
            this.tipSettings.SetToolTip(this.lbDownloadPath, "The path of the folder where files will be downloaded to");
            this.lbDownloadPath.Click += new System.EventHandler(this.lbDownloadPath_Click);
            // 
            // chkFixReddit
            // 
            this.chkFixReddit.AutoSize = true;
            this.chkFixReddit.Checked = true;
            this.chkFixReddit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFixReddit.Location = new System.Drawing.Point(190, 193);
            this.chkFixReddit.Name = "chkFixReddit";
            this.chkFixReddit.Size = new System.Drawing.Size(79, 17);
            this.chkFixReddit.TabIndex = 22;
            this.chkFixReddit.Text = "Fix v.redd.it";
            this.tipSettings.SetToolTip(this.chkFixReddit, resources.GetString("chkFixReddit.ToolTip"));
            this.chkFixReddit.UseVisualStyleBackColor = true;
            this.chkFixReddit.CheckedChanged += new System.EventHandler(this.chkFixReddit_CheckedChanged);
            // 
            // txtSaveto
            // 
            this.txtSaveto.Location = new System.Drawing.Point(30, 32);
            this.txtSaveto.Name = "txtSaveto";
            this.txtSaveto.ReadOnly = true;
            this.txtSaveto.Size = new System.Drawing.Size(233, 20);
            this.txtSaveto.TabIndex = 8;
            this.tipSettings.SetToolTip(this.txtSaveto, "The path of the folder where files will be downloaded to");
            this.txtSaveto.TextChanged += new System.EventHandler(this.txtSaveto_TextChanged);
            // 
            // chkSaveParams
            // 
            this.chkSaveParams.AutoSize = true;
            this.chkSaveParams.Enabled = false;
            this.chkSaveParams.Location = new System.Drawing.Point(42, 147);
            this.chkSaveParams.Name = "chkSaveParams";
            this.chkSaveParams.Size = new System.Drawing.Size(124, 17);
            this.chkSaveParams.TabIndex = 15;
            this.chkSaveParams.Text = "Save format && quality";
            this.tipSettings.SetToolTip(this.chkSaveParams, "Save format & quality of downloads on download");
            this.chkSaveParams.UseVisualStyleBackColor = true;
            this.chkSaveParams.CheckedChanged += new System.EventHandler(this.chkSaveParams_CheckedChanged);
            // 
            // llSchema
            // 
            this.llSchema.AutoSize = true;
            this.llSchema.Location = new System.Drawing.Point(105, 58);
            this.llSchema.Name = "llSchema";
            this.llSchema.Size = new System.Drawing.Size(13, 13);
            this.llSchema.TabIndex = 21;
            this.llSchema.TabStop = true;
            this.llSchema.Text = "?";
            this.tipSettings.SetToolTip(this.llSchema, "Click this to show a list of replaceable words");
            this.llSchema.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llSchema_LinkClicked);
            // 
            // chkSeparate
            // 
            this.chkSeparate.AutoSize = true;
            this.chkSeparate.Checked = true;
            this.chkSeparate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSeparate.Location = new System.Drawing.Point(42, 124);
            this.chkSeparate.Name = "chkSeparate";
            this.chkSeparate.Size = new System.Drawing.Size(209, 17);
            this.chkSeparate.TabIndex = 17;
            this.chkSeparate.Text = "Separate downloads to different folders";
            this.tipSettings.SetToolTip(this.chkSeparate, resources.GetString("chkSeparate.ToolTip"));
            this.chkSeparate.UseVisualStyleBackColor = true;
            this.chkSeparate.CheckedChanged += new System.EventHandler(this.chkSeparate_CheckedChanged);
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
            // chkAutomaticallyDelete
            // 
            this.chkAutomaticallyDelete.AutoSize = true;
            this.chkAutomaticallyDelete.Location = new System.Drawing.Point(42, 170);
            this.chkAutomaticallyDelete.Name = "chkAutomaticallyDelete";
            this.chkAutomaticallyDelete.Size = new System.Drawing.Size(236, 17);
            this.chkAutomaticallyDelete.TabIndex = 14;
            this.chkAutomaticallyDelete.Text = "Automatically delete youtube-dl when closing";
            this.tipSettings.SetToolTip(this.chkAutomaticallyDelete, "Automatically delete youtube-dl.exe when closing youtube-dl-gui");
            this.chkAutomaticallyDelete.UseVisualStyleBackColor = true;
            this.chkAutomaticallyDelete.CheckedChanged += new System.EventHandler(this.chkAutomaticallyDelete_CheckedChanged);
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
            this.txtFileNameSchema.TextChanged += new System.EventHandler(this.txtFileNameSchema_TextChanged);
            // 
            // btnRedownloadYtdl
            // 
            this.btnRedownloadYtdl.Location = new System.Drawing.Point(90, 218);
            this.btnRedownloadYtdl.Name = "btnRedownloadYtdl";
            this.btnRedownloadYtdl.Size = new System.Drawing.Size(140, 23);
            this.btnRedownloadYtdl.TabIndex = 18;
            this.btnRedownloadYtdl.Text = "(re)download youtube-dl";
            this.tipSettings.SetToolTip(this.btnRedownloadYtdl, "Redownloads youtube-dl if one is already present, otherwise, updates youtube-dl");
            this.btnRedownloadYtdl.UseVisualStyleBackColor = true;
            this.btnRedownloadYtdl.Click += new System.EventHandler(this.btnRedownloadYtdl_Click);
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
            this.lbSepDownloads.Click += new System.EventHandler(this.lbSepDownloads_Click);
            // 
            // chkYtdlUpdate
            // 
            this.chkYtdlUpdate.AutoSize = true;
            this.chkYtdlUpdate.Checked = true;
            this.chkYtdlUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkYtdlUpdate.Enabled = false;
            this.chkYtdlUpdate.Location = new System.Drawing.Point(42, 193);
            this.chkYtdlUpdate.Name = "chkYtdlUpdate";
            this.chkYtdlUpdate.Size = new System.Drawing.Size(142, 17);
            this.chkYtdlUpdate.TabIndex = 13;
            this.chkYtdlUpdate.Text = "Use youtube-dl\'s updater";
            this.tipSettings.SetToolTip(this.chkYtdlUpdate, "Use youtube-dl\'s internal updater instead of this application\'s updater");
            this.chkYtdlUpdate.UseVisualStyleBackColor = true;
            this.chkYtdlUpdate.CheckedChanged += new System.EventHandler(this.chkYtdlUpdate_CheckedChanged);
            // 
            // lbFileSchema
            // 
            this.lbFileSchema.AutoSize = true;
            this.lbFileSchema.Location = new System.Drawing.Point(19, 59);
            this.lbFileSchema.Name = "lbFileSchema";
            this.lbFileSchema.Size = new System.Drawing.Size(89, 13);
            this.lbFileSchema.TabIndex = 19;
            this.lbFileSchema.Text = "file name schema";
            this.lbFileSchema.Click += new System.EventHandler(this.lbFileSchema_Click);
            // 
            // tbConverter
            // 
            this.tbConverter.Controls.Add(this.chkConvertHideFFmpeg);
            this.tbConverter.Controls.Add(this.tcConverter);
            this.tbConverter.Controls.Add(this.chkConvClearInput);
            this.tbConverter.Controls.Add(this.chkConvClearOutput);
            this.tbConverter.Controls.Add(this.chkConvertDetectFiletype);
            this.tbConverter.Location = new System.Drawing.Point(4, 22);
            this.tbConverter.Name = "tbConverter";
            this.tbConverter.Padding = new System.Windows.Forms.Padding(3);
            this.tbConverter.Size = new System.Drawing.Size(320, 253);
            this.tbConverter.TabIndex = 2;
            this.tbConverter.Text = "Converter";
            this.tbConverter.UseVisualStyleBackColor = true;
            // 
            // chkConvertHideFFmpeg
            // 
            this.chkConvertHideFFmpeg.AutoSize = true;
            this.chkConvertHideFFmpeg.Location = new System.Drawing.Point(175, 35);
            this.chkConvertHideFFmpeg.Name = "chkConvertHideFFmpeg";
            this.chkConvertHideFFmpeg.Size = new System.Drawing.Size(141, 17);
            this.chkConvertHideFFmpeg.TabIndex = 19;
            this.chkConvertHideFFmpeg.Text = "Hide ffmpeg compile info";
            this.tipSettings.SetToolTip(this.chkConvertHideFFmpeg, "Enabling this will hide some compilation information of ffmpeg.");
            this.chkConvertHideFFmpeg.UseVisualStyleBackColor = true;
            // 
            // tcConverter
            // 
            this.tcConverter.Controls.Add(this.tabConvertVideo);
            this.tcConverter.Controls.Add(this.tabConvertAudio);
            this.tcConverter.Controls.Add(this.tabConvertCustom);
            this.tcConverter.Location = new System.Drawing.Point(8, 67);
            this.tcConverter.Name = "tcConverter";
            this.tcConverter.SelectedIndex = 0;
            this.tcConverter.Size = new System.Drawing.Size(304, 180);
            this.tcConverter.TabIndex = 18;
            // 
            // tabConvertVideo
            // 
            this.tabConvertVideo.Controls.Add(this.chkUseVideoCRF);
            this.tabConvertVideo.Controls.Add(this.chkUseVideoProfile);
            this.tabConvertVideo.Controls.Add(this.chkUseVideoPreset);
            this.tabConvertVideo.Controls.Add(this.chkUseVideoBitrate);
            this.tabConvertVideo.Controls.Add(this.chkVideoFastStart);
            this.tabConvertVideo.Controls.Add(this.lbConvertVideoCRF);
            this.tabConvertVideo.Controls.Add(this.numConvertVideoCRF);
            this.tabConvertVideo.Controls.Add(this.lbConvertVideoProfile);
            this.tabConvertVideo.Controls.Add(this.cbConvertVideoProfile);
            this.tabConvertVideo.Controls.Add(this.lbConvertVideoPreset);
            this.tabConvertVideo.Controls.Add(this.cbConvertVideoPreset);
            this.tabConvertVideo.Controls.Add(this.lbConvertVideoBitrate);
            this.tabConvertVideo.Controls.Add(this.numConvertVideoBitrate);
            this.tabConvertVideo.Controls.Add(this.lbConvertVideoThousands);
            this.tabConvertVideo.Location = new System.Drawing.Point(4, 22);
            this.tabConvertVideo.Name = "tabConvertVideo";
            this.tabConvertVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabConvertVideo.Size = new System.Drawing.Size(296, 154);
            this.tabConvertVideo.TabIndex = 0;
            this.tabConvertVideo.Text = "Video";
            this.tabConvertVideo.UseVisualStyleBackColor = true;
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
            // chkUseVideoPreset
            // 
            this.chkUseVideoPreset.AutoSize = true;
            this.chkUseVideoPreset.Location = new System.Drawing.Point(72, 43);
            this.chkUseVideoPreset.Name = "chkUseVideoPreset";
            this.chkUseVideoPreset.Size = new System.Drawing.Size(14, 13);
            this.chkUseVideoPreset.TabIndex = 11;
            this.chkUseVideoPreset.UseVisualStyleBackColor = true;
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
            // chkVideoFastStart
            // 
            this.chkVideoFastStart.AutoSize = true;
            this.chkVideoFastStart.Location = new System.Drawing.Point(117, 126);
            this.chkVideoFastStart.Name = "chkVideoFastStart";
            this.chkVideoFastStart.Size = new System.Drawing.Size(62, 17);
            this.chkVideoFastStart.TabIndex = 9;
            this.chkVideoFastStart.Text = "faststart";
            this.tipSettings.SetToolTip(this.chkVideoFastStart, "Faststart moves the metadata to the front of the file.\r\n\r\nEnabling this allows vi" +
        "deos to be played before they are fully downloaded.");
            this.chkVideoFastStart.UseVisualStyleBackColor = true;
            // 
            // lbConvertVideoCRF
            // 
            this.lbConvertVideoCRF.AutoSize = true;
            this.lbConvertVideoCRF.Location = new System.Drawing.Point(95, 96);
            this.lbConvertVideoCRF.Name = "lbConvertVideoCRF";
            this.lbConvertVideoCRF.Size = new System.Drawing.Size(28, 13);
            this.lbConvertVideoCRF.TabIndex = 8;
            this.lbConvertVideoCRF.Text = "CRF";
            this.tipSettings.SetToolTip(this.lbConvertVideoCRF, "CRF is constant rate factor.\r\n\r\nLower = Higher quality");
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
            // lbConvertVideoProfile
            // 
            this.lbConvertVideoProfile.AutoSize = true;
            this.lbConvertVideoProfile.Location = new System.Drawing.Point(87, 70);
            this.lbConvertVideoProfile.Name = "lbConvertVideoProfile";
            this.lbConvertVideoProfile.Size = new System.Drawing.Size(36, 13);
            this.lbConvertVideoProfile.TabIndex = 6;
            this.lbConvertVideoProfile.Text = "Profile";
            this.tipSettings.SetToolTip(this.lbConvertVideoProfile, "The encoder profile to be used during conversion. It affects the compression of t" +
        "he video.\r\nIt\'s generally a good idea to stick with the main profile");
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
            // lbConvertVideoPreset
            // 
            this.lbConvertVideoPreset.AutoSize = true;
            this.lbConvertVideoPreset.Location = new System.Drawing.Point(86, 43);
            this.lbConvertVideoPreset.Name = "lbConvertVideoPreset";
            this.lbConvertVideoPreset.Size = new System.Drawing.Size(37, 13);
            this.lbConvertVideoPreset.TabIndex = 4;
            this.lbConvertVideoPreset.Text = "Preset";
            this.tipSettings.SetToolTip(this.lbConvertVideoPreset, "The video preset of the conversion\r\n\r\nultrafast = fastest, but lower quality\r\nver" +
        "yslow = slowest, but higher quality");
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
            // lbConvertVideoBitrate
            // 
            this.lbConvertVideoBitrate.AutoSize = true;
            this.lbConvertVideoBitrate.Location = new System.Drawing.Point(86, 16);
            this.lbConvertVideoBitrate.Name = "lbConvertVideoBitrate";
            this.lbConvertVideoBitrate.Size = new System.Drawing.Size(37, 13);
            this.lbConvertVideoBitrate.TabIndex = 1;
            this.lbConvertVideoBitrate.Text = "Bitrate";
            this.tipSettings.SetToolTip(this.lbConvertVideoBitrate, resources.GetString("lbConvertVideoBitrate.ToolTip"));
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
            // tabConvertAudio
            // 
            this.tabConvertAudio.Controls.Add(this.chkUseAudioBitrate);
            this.tabConvertAudio.Controls.Add(this.lbAudioBitrate);
            this.tabConvertAudio.Controls.Add(this.numConvertAudioBitrate);
            this.tabConvertAudio.Controls.Add(this.lbidkwhatsup);
            this.tabConvertAudio.Controls.Add(this.lbConvertAudioThousands);
            this.tabConvertAudio.Location = new System.Drawing.Point(4, 22);
            this.tabConvertAudio.Name = "tabConvertAudio";
            this.tabConvertAudio.Padding = new System.Windows.Forms.Padding(3);
            this.tabConvertAudio.Size = new System.Drawing.Size(296, 154);
            this.tabConvertAudio.TabIndex = 1;
            this.tabConvertAudio.Text = "Audio";
            this.tabConvertAudio.UseVisualStyleBackColor = true;
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
            // lbAudioBitrate
            // 
            this.lbAudioBitrate.AutoSize = true;
            this.lbAudioBitrate.Location = new System.Drawing.Point(102, 21);
            this.lbAudioBitrate.Name = "lbAudioBitrate";
            this.lbAudioBitrate.Size = new System.Drawing.Size(37, 13);
            this.lbAudioBitrate.TabIndex = 19;
            this.lbAudioBitrate.Text = "Bitrate";
            this.tipSettings.SetToolTip(this.lbAudioBitrate, resources.GetString("lbAudioBitrate.ToolTip"));
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
            // tabConvertCustom
            // 
            this.tabConvertCustom.Controls.Add(this.txtConvertCustom);
            this.tabConvertCustom.Controls.Add(this.lbConverterCustom);
            this.tabConvertCustom.Location = new System.Drawing.Point(4, 22);
            this.tabConvertCustom.Name = "tabConvertCustom";
            this.tabConvertCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tabConvertCustom.Size = new System.Drawing.Size(296, 154);
            this.tabConvertCustom.TabIndex = 2;
            this.tabConvertCustom.Text = "Custom";
            this.tabConvertCustom.UseVisualStyleBackColor = true;
            // 
            // txtConvertCustom
            // 
            this.txtConvertCustom.Location = new System.Drawing.Point(36, 97);
            this.txtConvertCustom.Name = "txtConvertCustom";
            this.txtConvertCustom.Size = new System.Drawing.Size(228, 20);
            this.txtConvertCustom.TabIndex = 1;
            this.tipSettings.SetToolTip(this.txtConvertCustom, "Custom arguments that will be passed through ffmpeg instead of built-in arguments" +
        "");
            // 
            // lbConverterCustom
            // 
            this.lbConverterCustom.AutoSize = true;
            this.lbConverterCustom.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConverterCustom.Location = new System.Drawing.Point(33, 37);
            this.lbConverterCustom.Name = "lbConverterCustom";
            this.lbConverterCustom.Size = new System.Drawing.Size(231, 26);
            this.lbConverterCustom.TabIndex = 0;
            this.lbConverterCustom.Text = "Don\'t pass input or output directories/files,\r\nit\'s automatically handled by the " +
    "program";
            this.lbConverterCustom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkConvClearInput
            // 
            this.chkConvClearInput.AutoSize = true;
            this.chkConvClearInput.Location = new System.Drawing.Point(17, 35);
            this.chkConvClearInput.Name = "chkConvClearInput";
            this.chkConvClearInput.Size = new System.Drawing.Size(152, 17);
            this.chkConvClearInput.TabIndex = 17;
            this.chkConvClearInput.Text = "Clear input after converting";
            this.tipSettings.SetToolTip(this.chkConvClearInput, "Clears the input file after a successful conversion");
            this.chkConvClearInput.UseVisualStyleBackColor = true;
            // 
            // chkConvClearOutput
            // 
            this.chkConvClearOutput.AutoSize = true;
            this.chkConvClearOutput.Location = new System.Drawing.Point(17, 12);
            this.chkConvClearOutput.Name = "chkConvClearOutput";
            this.chkConvClearOutput.Size = new System.Drawing.Size(159, 17);
            this.chkConvClearOutput.TabIndex = 16;
            this.chkConvClearOutput.Text = "Clear output after converting";
            this.tipSettings.SetToolTip(this.chkConvClearOutput, "Clears the output file after a successful conversion\r\n");
            this.chkConvClearOutput.UseVisualStyleBackColor = true;
            // 
            // chkConvertDetectFiletype
            // 
            this.chkConvertDetectFiletype.AutoSize = true;
            this.chkConvertDetectFiletype.Checked = true;
            this.chkConvertDetectFiletype.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConvertDetectFiletype.Location = new System.Drawing.Point(182, 12);
            this.chkConvertDetectFiletype.Name = "chkConvertDetectFiletype";
            this.chkConvertDetectFiletype.Size = new System.Drawing.Size(126, 17);
            this.chkConvertDetectFiletype.TabIndex = 0;
            this.chkConvertDetectFiletype.Text = "Detect output filetype";
            this.tipSettings.SetToolTip(this.chkConvertDetectFiletype, "If Automatic is checked on converting, this will attempt to detect the output fil" +
        "e type.\r\n\r\nDisable this if you want a simple conversion. The quality may suffer " +
        "as a result.");
            this.chkConvertDetectFiletype.UseVisualStyleBackColor = true;
            // 
            // tabExtensions
            // 
            this.tabExtensions.Controls.Add(this.lbFileExtension);
            this.tabExtensions.Controls.Add(this.btnAddExtension);
            this.tabExtensions.Controls.Add(this.btnRemoveExtension);
            this.tabExtensions.Controls.Add(this.listExtensions);
            this.tabExtensions.Controls.Add(this.lbExtensionShortName);
            this.tabExtensions.Controls.Add(this.txtExtensionsShort);
            this.tabExtensions.Controls.Add(this.lbExtensionFull);
            this.tabExtensions.Controls.Add(this.txtExtensionsName);
            this.tabExtensions.Controls.Add(this.lbExtensions);
            this.tabExtensions.Location = new System.Drawing.Point(4, 22);
            this.tabExtensions.Name = "tabExtensions";
            this.tabExtensions.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtensions.Size = new System.Drawing.Size(320, 253);
            this.tabExtensions.TabIndex = 4;
            this.tabExtensions.Text = "Extensions";
            this.tabExtensions.UseVisualStyleBackColor = true;
            // 
            // lbFileExtension
            // 
            this.lbFileExtension.AutoSize = true;
            this.lbFileExtension.Location = new System.Drawing.Point(30, 226);
            this.lbFileExtension.Name = "lbFileExtension";
            this.lbFileExtension.Size = new System.Drawing.Size(68, 13);
            this.lbFileExtension.TabIndex = 9;
            this.lbFileExtension.Text = "FileName.ext";
            // 
            // btnAddExtension
            // 
            this.btnAddExtension.Location = new System.Drawing.Point(242, 63);
            this.btnAddExtension.Name = "btnAddExtension";
            this.btnAddExtension.Size = new System.Drawing.Size(50, 23);
            this.btnAddExtension.TabIndex = 8;
            this.btnAddExtension.Text = "Add";
            this.btnAddExtension.UseVisualStyleBackColor = true;
            this.btnAddExtension.Click += new System.EventHandler(this.btnAddExtension_Click);
            // 
            // btnRemoveExtension
            // 
            this.btnRemoveExtension.Location = new System.Drawing.Point(192, 222);
            this.btnRemoveExtension.Name = "btnRemoveExtension";
            this.btnRemoveExtension.Size = new System.Drawing.Size(100, 23);
            this.btnRemoveExtension.TabIndex = 7;
            this.btnRemoveExtension.Text = "Remove selected";
            this.btnRemoveExtension.UseVisualStyleBackColor = true;
            this.btnRemoveExtension.Click += new System.EventHandler(this.btnRemoveExtension_Click);
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
            // lbExtensionShortName
            // 
            this.lbExtensionShortName.AutoSize = true;
            this.lbExtensionShortName.Location = new System.Drawing.Point(178, 49);
            this.lbExtensionShortName.Name = "lbExtensionShortName";
            this.lbExtensionShortName.Size = new System.Drawing.Size(79, 13);
            this.lbExtensionShortName.TabIndex = 5;
            this.lbExtensionShortName.Text = "Extension short";
            // 
            // txtExtensionsShort
            // 
            this.txtExtensionsShort.Location = new System.Drawing.Point(181, 65);
            this.txtExtensionsShort.Name = "txtExtensionsShort";
            this.txtExtensionsShort.Size = new System.Drawing.Size(57, 20);
            this.txtExtensionsShort.TabIndex = 4;
            // 
            // lbExtensionFull
            // 
            this.lbExtensionFull.AutoSize = true;
            this.lbExtensionFull.Location = new System.Drawing.Point(28, 49);
            this.lbExtensionFull.Name = "lbExtensionFull";
            this.lbExtensionFull.Size = new System.Drawing.Size(98, 13);
            this.lbExtensionFull.TabIndex = 3;
            this.lbExtensionFull.Text = "Extension full name";
            // 
            // txtExtensionsName
            // 
            this.txtExtensionsName.Location = new System.Drawing.Point(31, 65);
            this.txtExtensionsName.Name = "txtExtensionsName";
            this.txtExtensionsName.Size = new System.Drawing.Size(144, 20);
            this.txtExtensionsName.TabIndex = 2;
            // 
            // lbExtensions
            // 
            this.lbExtensions.AutoSize = true;
            this.lbExtensions.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExtensions.Location = new System.Drawing.Point(40, 10);
            this.lbExtensions.Name = "lbExtensions";
            this.lbExtensions.Size = new System.Drawing.Size(240, 26);
            this.lbExtensions.TabIndex = 1;
            this.lbExtensions.Text = "This allows you to input your own extensions\r\nto be used with this application";
            this.lbExtensions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabError
            // 
            this.tabError.Controls.Add(this.chkErrorsLogFile);
            this.tabError.Controls.Add(this.chkErrorsDetailed);
            this.tabError.Controls.Add(this.chkErrorsSuppressed);
            this.tabError.Location = new System.Drawing.Point(4, 22);
            this.tabError.Name = "tabError";
            this.tabError.Padding = new System.Windows.Forms.Padding(3);
            this.tabError.Size = new System.Drawing.Size(320, 253);
            this.tabError.TabIndex = 3;
            this.tabError.Text = "Errors";
            this.tabError.UseVisualStyleBackColor = true;
            // 
            // chkErrorsLogFile
            // 
            this.chkErrorsLogFile.AutoSize = true;
            this.chkErrorsLogFile.Location = new System.Drawing.Point(93, 129);
            this.chkErrorsLogFile.Name = "chkErrorsLogFile";
            this.chkErrorsLogFile.Size = new System.Drawing.Size(134, 17);
            this.chkErrorsLogFile.TabIndex = 2;
            this.chkErrorsLogFile.Text = "Save errors as error.log";
            this.tipSettings.SetToolTip(this.chkErrorsLogFile, "Saves the latest error as error.log in the exeucting directory of youtube-dl-gui");
            this.chkErrorsLogFile.UseVisualStyleBackColor = true;
            // 
            // chkErrorsDetailed
            // 
            this.chkErrorsDetailed.AutoSize = true;
            this.chkErrorsDetailed.Location = new System.Drawing.Point(93, 106);
            this.chkErrorsDetailed.Name = "chkErrorsDetailed";
            this.chkErrorsDetailed.Size = new System.Drawing.Size(121, 17);
            this.chkErrorsDetailed.TabIndex = 1;
            this.chkErrorsDetailed.Text = "Show detailed errors";
            this.tipSettings.SetToolTip(this.chkErrorsDetailed, "Shows more details in errors");
            this.chkErrorsDetailed.UseVisualStyleBackColor = true;
            // 
            // chkErrorsSuppressed
            // 
            this.chkErrorsSuppressed.AutoSize = true;
            this.chkErrorsSuppressed.Location = new System.Drawing.Point(111, 213);
            this.chkErrorsSuppressed.Name = "chkErrorsSuppressed";
            this.chkErrorsSuppressed.Size = new System.Drawing.Size(98, 17);
            this.chkErrorsSuppressed.TabIndex = 0;
            this.chkErrorsSuppressed.Text = "Suppress errors";
            this.tipSettings.SetToolTip(this.chkErrorsSuppressed, "This will silence any errors and will not save any error.log files.\r\n\r\nThis basic" +
        "ally overrides all error settings. Use at your own risk.");
            this.chkErrorsSuppressed.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(241, 289);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.tipSettings.SetToolTip(this.btnCancel, "Discard any changed settings");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(158, 289);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.tipSettings.SetToolTip(this.btnSave, "Save all configured settings");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tcMain);
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
            this.tbGeneral.ResumeLayout(false);
            this.tbGeneral.PerformLayout();
            this.gbArguments.ResumeLayout(false);
            this.gbArguments.PerformLayout();
            this.tbDownloads.ResumeLayout(false);
            this.tbDownloads.PerformLayout();
            this.tbConverter.ResumeLayout(false);
            this.tbConverter.PerformLayout();
            this.tcConverter.ResumeLayout(false);
            this.tabConvertVideo.ResumeLayout(false);
            this.tabConvertVideo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertVideoCRF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertVideoBitrate)).EndInit();
            this.tabConvertAudio.ResumeLayout(false);
            this.tabConvertAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertAudioBitrate)).EndInit();
            this.tabConvertCustom.ResumeLayout(false);
            this.tabConvertCustom.PerformLayout();
            this.tabExtensions.ResumeLayout(false);
            this.tabExtensions.PerformLayout();
            this.tabError.ResumeLayout(false);
            this.tabError.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tbGeneral;
        private System.Windows.Forms.Label lbSepGeneral;
        private System.Windows.Forms.Button btnBrwsFF;
        private System.Windows.Forms.Button btnBrwsYtdl;
        private System.Windows.Forms.CheckBox chkStaticYtdl;
        private System.Windows.Forms.CheckBox chkStaticFF;
        private System.Windows.Forms.TextBox txtFFmpeg;
        private System.Windows.Forms.Label lbFFmpegPath;
        private System.Windows.Forms.TextBox txtYtdl;
        private System.Windows.Forms.Label lbYtdlPath;
        private System.Windows.Forms.TabPage tbDownloads;
        private System.Windows.Forms.TabPage tbConverter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbArguments;
        private System.Windows.Forms.RadioButton rbArgsAsSettings;
        private System.Windows.Forms.RadioButton rbArgsAsTxt;
        private System.Windows.Forms.RadioButton rbDontSaveArgs;
        private System.Windows.Forms.CheckBox chkClear;
        private System.Windows.Forms.CheckBox chkHover;
        private System.Windows.Forms.CheckBox chkUpdates;
        private System.Windows.Forms.CheckBox chkYtdlUpdate;
        private System.Windows.Forms.Button btnBrowseSaveto;
        private System.Windows.Forms.TextBox txtSaveto;
        private System.Windows.Forms.Label lbDownloadPath;
        private System.Windows.Forms.Label lbSepDownloads;
        private System.Windows.Forms.CheckBox chkSeparate;
        private System.Windows.Forms.CheckBox chkSaveParams;
        private System.Windows.Forms.CheckBox chkAutomaticallyDelete;
        private System.Windows.Forms.Button btnRedownloadYtdl;
        private System.Windows.Forms.CheckBox chkConvertDetectFiletype;
        private System.Windows.Forms.TextBox txtFileNameSchema;
        private System.Windows.Forms.Label lbFileSchema;
        private System.Windows.Forms.LinkLabel llSchema;
        private System.Windows.Forms.Label lbidkwhatsup;
        private System.Windows.Forms.ToolTip tipSettings;
        private System.Windows.Forms.CheckBox chkConvClearInput;
        private System.Windows.Forms.CheckBox chkConvClearOutput;
        private System.Windows.Forms.TabControl tcConverter;
        private System.Windows.Forms.TabPage tabConvertVideo;
        private System.Windows.Forms.TabPage tabConvertAudio;
        private System.Windows.Forms.NumericUpDown numConvertVideoBitrate;
        private System.Windows.Forms.Label lbConvertVideoThousands;
        private System.Windows.Forms.Label lbConvertVideoBitrate;
        private System.Windows.Forms.ComboBox cbConvertVideoPreset;
        private System.Windows.Forms.Label lbConvertVideoPreset;
        private System.Windows.Forms.Label lbConvertVideoProfile;
        private System.Windows.Forms.ComboBox cbConvertVideoProfile;
        private System.Windows.Forms.Label lbConvertVideoCRF;
        private System.Windows.Forms.NumericUpDown numConvertVideoCRF;
        private System.Windows.Forms.CheckBox chkVideoFastStart;
        private System.Windows.Forms.TabPage tabConvertCustom;
        private System.Windows.Forms.TextBox txtConvertCustom;
        private System.Windows.Forms.Label lbConverterCustom;
        private System.Windows.Forms.CheckBox chkConvertHideFFmpeg;
        private System.Windows.Forms.TabPage tabError;
        private System.Windows.Forms.CheckBox chkErrorsLogFile;
        private System.Windows.Forms.CheckBox chkErrorsDetailed;
        private System.Windows.Forms.CheckBox chkErrorsSuppressed;
        private System.Windows.Forms.NumericUpDown numConvertAudioBitrate;
        private System.Windows.Forms.Label lbConvertAudioThousands;
        private System.Windows.Forms.TabPage tabExtensions;
        private System.Windows.Forms.Label lbExtensions;
        private System.Windows.Forms.Button btnRemoveExtension;
        private System.Windows.Forms.ListBox listExtensions;
        private System.Windows.Forms.Label lbExtensionShortName;
        private System.Windows.Forms.TextBox txtExtensionsShort;
        private System.Windows.Forms.Label lbExtensionFull;
        private System.Windows.Forms.TextBox txtExtensionsName;
        private System.Windows.Forms.Button btnAddExtension;
        private System.Windows.Forms.Label lbFileExtension;
        private System.Windows.Forms.CheckBox chkUseVideoCRF;
        private System.Windows.Forms.CheckBox chkUseVideoProfile;
        private System.Windows.Forms.CheckBox chkUseVideoPreset;
        private System.Windows.Forms.CheckBox chkUseVideoBitrate;
        private System.Windows.Forms.CheckBox chkUseAudioBitrate;
        private System.Windows.Forms.Label lbAudioBitrate;
        private System.Windows.Forms.CheckBox chkFixReddit;
    }
}