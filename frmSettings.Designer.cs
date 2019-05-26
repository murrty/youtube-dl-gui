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
            this.llSchema = new System.Windows.Forms.LinkLabel();
            this.txtFileNameSchema = new System.Windows.Forms.TextBox();
            this.lbFileSchema = new System.Windows.Forms.Label();
            this.btnRedownloadYtdl = new System.Windows.Forms.Button();
            this.chkSeparate = new System.Windows.Forms.CheckBox();
            this.chkSaveParams = new System.Windows.Forms.CheckBox();
            this.chkAutomaticallyDelete = new System.Windows.Forms.CheckBox();
            this.chkYtdlUpdate = new System.Windows.Forms.CheckBox();
            this.lbSepDownloads = new System.Windows.Forms.Label();
            this.btnBrowseSaveto = new System.Windows.Forms.Button();
            this.txtSaveto = new System.Windows.Forms.TextBox();
            this.lbDownloadPath = new System.Windows.Forms.Label();
            this.tbConverter = new System.Windows.Forms.TabPage();
            this.lbidkwhatsup = new System.Windows.Forms.Label();
            this.chkConvertDetectFiletype = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tipSettings = new System.Windows.Forms.ToolTip(this.components);
            this.chkConvClearOutput = new System.Windows.Forms.CheckBox();
            this.chkConvClearInput = new System.Windows.Forms.CheckBox();
            this.tcConverter = new System.Windows.Forms.TabControl();
            this.tabConvertVideo = new System.Windows.Forms.TabPage();
            this.tabConvertAudio = new System.Windows.Forms.TabPage();
            this.numConvertVideoBitrate = new System.Windows.Forms.NumericUpDown();
            this.lbConvertVideoBitrate = new System.Windows.Forms.Label();
            this.lbConvertVideoThousands = new System.Windows.Forms.Label();
            this.cbConvertVideoPreset = new System.Windows.Forms.ComboBox();
            this.lbConvertVideoPreset = new System.Windows.Forms.Label();
            this.lbConvertVideoProfile = new System.Windows.Forms.Label();
            this.cbConvertVideoProfile = new System.Windows.Forms.ComboBox();
            this.numConvertVideoCRF = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chkVideoFastStart = new System.Windows.Forms.CheckBox();
            this.tabConvertCustom = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConvertCustom = new System.Windows.Forms.TextBox();
            this.chkConvertHideFFmpeg = new System.Windows.Forms.CheckBox();
            this.tcMain.SuspendLayout();
            this.tbGeneral.SuspendLayout();
            this.gbArguments.SuspendLayout();
            this.tbDownloads.SuspendLayout();
            this.tbConverter.SuspendLayout();
            this.tcConverter.SuspendLayout();
            this.tabConvertVideo.SuspendLayout();
            this.tabConvertAudio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertVideoBitrate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertVideoCRF)).BeginInit();
            this.tabConvertCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tbGeneral);
            this.tcMain.Controls.Add(this.tbDownloads);
            this.tcMain.Controls.Add(this.tbConverter);
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
            // 
            // tbDownloads
            // 
            this.tbDownloads.Controls.Add(this.llSchema);
            this.tbDownloads.Controls.Add(this.txtFileNameSchema);
            this.tbDownloads.Controls.Add(this.lbFileSchema);
            this.tbDownloads.Controls.Add(this.btnRedownloadYtdl);
            this.tbDownloads.Controls.Add(this.chkSeparate);
            this.tbDownloads.Controls.Add(this.chkSaveParams);
            this.tbDownloads.Controls.Add(this.chkAutomaticallyDelete);
            this.tbDownloads.Controls.Add(this.chkYtdlUpdate);
            this.tbDownloads.Controls.Add(this.lbSepDownloads);
            this.tbDownloads.Controls.Add(this.btnBrowseSaveto);
            this.tbDownloads.Controls.Add(this.txtSaveto);
            this.tbDownloads.Controls.Add(this.lbDownloadPath);
            this.tbDownloads.Location = new System.Drawing.Point(4, 22);
            this.tbDownloads.Name = "tbDownloads";
            this.tbDownloads.Padding = new System.Windows.Forms.Padding(3);
            this.tbDownloads.Size = new System.Drawing.Size(320, 253);
            this.tbDownloads.TabIndex = 1;
            this.tbDownloads.Text = "Downloads";
            this.tbDownloads.UseVisualStyleBackColor = true;
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
            // txtFileNameSchema
            // 
            this.txtFileNameSchema.Location = new System.Drawing.Point(30, 79);
            this.txtFileNameSchema.Name = "txtFileNameSchema";
            this.txtFileNameSchema.Size = new System.Drawing.Size(260, 20);
            this.txtFileNameSchema.TabIndex = 20;
            this.txtFileNameSchema.Text = "%(title)s-%(id)s.%(ext)s";
            this.tipSettings.SetToolTip(this.txtFileNameSchema, "The file name schema\r\nThis basically replaces words that are abnormally used with" +
        " useful information for a custom file name.");
            // 
            // lbFileSchema
            // 
            this.lbFileSchema.AutoSize = true;
            this.lbFileSchema.Location = new System.Drawing.Point(19, 59);
            this.lbFileSchema.Name = "lbFileSchema";
            this.lbFileSchema.Size = new System.Drawing.Size(89, 13);
            this.lbFileSchema.TabIndex = 19;
            this.lbFileSchema.Text = "file name schema";
            // 
            // btnRedownloadYtdl
            // 
            this.btnRedownloadYtdl.Location = new System.Drawing.Point(91, 218);
            this.btnRedownloadYtdl.Name = "btnRedownloadYtdl";
            this.btnRedownloadYtdl.Size = new System.Drawing.Size(139, 23);
            this.btnRedownloadYtdl.TabIndex = 18;
            this.btnRedownloadYtdl.Text = "redownload youtube-dl";
            this.tipSettings.SetToolTip(this.btnRedownloadYtdl, "redownloads youtube-dl");
            this.btnRedownloadYtdl.UseVisualStyleBackColor = true;
            this.btnRedownloadYtdl.Click += new System.EventHandler(this.btnRedownloadYtdl_Click);
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
            this.tipSettings.SetToolTip(this.chkSeparate, "Separates downloads into their own folder based on the download type");
            this.chkSeparate.UseVisualStyleBackColor = true;
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
            // 
            // lbSepDownloads
            // 
            this.lbSepDownloads.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbSepDownloads.Location = new System.Drawing.Point(25, 107);
            this.lbSepDownloads.Name = "lbSepDownloads";
            this.lbSepDownloads.Size = new System.Drawing.Size(270, 2);
            this.lbSepDownloads.TabIndex = 11;
            this.lbSepDownloads.Text = "HELLO WORLD";
            // 
            // btnBrowseSaveto
            // 
            this.btnBrowseSaveto.Location = new System.Drawing.Point(269, 30);
            this.btnBrowseSaveto.Name = "btnBrowseSaveto";
            this.btnBrowseSaveto.Size = new System.Drawing.Size(33, 23);
            this.btnBrowseSaveto.TabIndex = 10;
            this.btnBrowseSaveto.Text = "...";
            this.btnBrowseSaveto.UseVisualStyleBackColor = true;
            this.btnBrowseSaveto.Click += new System.EventHandler(this.btnBrowseSaveto_Click);
            // 
            // txtSaveto
            // 
            this.txtSaveto.Location = new System.Drawing.Point(30, 32);
            this.txtSaveto.Name = "txtSaveto";
            this.txtSaveto.ReadOnly = true;
            this.txtSaveto.Size = new System.Drawing.Size(233, 20);
            this.txtSaveto.TabIndex = 8;
            this.tipSettings.SetToolTip(this.txtSaveto, "The path where downloads will be saved to");
            // 
            // lbDownloadPath
            // 
            this.lbDownloadPath.AutoSize = true;
            this.lbDownloadPath.Location = new System.Drawing.Point(19, 12);
            this.lbDownloadPath.Name = "lbDownloadPath";
            this.lbDownloadPath.Size = new System.Drawing.Size(77, 13);
            this.lbDownloadPath.TabIndex = 7;
            this.lbDownloadPath.Text = "download path";
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
            // lbidkwhatsup
            // 
            this.lbidkwhatsup.AutoSize = true;
            this.lbidkwhatsup.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbidkwhatsup.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbidkwhatsup.Location = new System.Drawing.Point(72, 69);
            this.lbidkwhatsup.Name = "lbidkwhatsup";
            this.lbidkwhatsup.Size = new System.Drawing.Size(153, 17);
            this.lbidkwhatsup.TabIndex = 15;
            this.lbidkwhatsup.Text = "nothing but us empties";
            this.lbidkwhatsup.TextAlign = System.Drawing.ContentAlignment.TopCenter;
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
        "e type.\r\nDisable this if you want a simple conversion. The quality may suffer as" +
        " a result.");
            this.chkConvertDetectFiletype.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(241, 289);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
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
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tipSettings
            // 
            this.tipSettings.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
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
            this.tabConvertVideo.Controls.Add(this.chkVideoFastStart);
            this.tabConvertVideo.Controls.Add(this.label1);
            this.tabConvertVideo.Controls.Add(this.numConvertVideoCRF);
            this.tabConvertVideo.Controls.Add(this.lbConvertVideoProfile);
            this.tabConvertVideo.Controls.Add(this.cbConvertVideoProfile);
            this.tabConvertVideo.Controls.Add(this.lbConvertVideoPreset);
            this.tabConvertVideo.Controls.Add(this.cbConvertVideoPreset);
            this.tabConvertVideo.Controls.Add(this.lbConvertVideoThousands);
            this.tabConvertVideo.Controls.Add(this.lbConvertVideoBitrate);
            this.tabConvertVideo.Controls.Add(this.numConvertVideoBitrate);
            this.tabConvertVideo.Location = new System.Drawing.Point(4, 22);
            this.tabConvertVideo.Name = "tabConvertVideo";
            this.tabConvertVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabConvertVideo.Size = new System.Drawing.Size(296, 154);
            this.tabConvertVideo.TabIndex = 0;
            this.tabConvertVideo.Text = "Video";
            this.tabConvertVideo.UseVisualStyleBackColor = true;
            // 
            // tabConvertAudio
            // 
            this.tabConvertAudio.Controls.Add(this.lbidkwhatsup);
            this.tabConvertAudio.Location = new System.Drawing.Point(4, 22);
            this.tabConvertAudio.Name = "tabConvertAudio";
            this.tabConvertAudio.Padding = new System.Windows.Forms.Padding(3);
            this.tabConvertAudio.Size = new System.Drawing.Size(296, 154);
            this.tabConvertAudio.TabIndex = 1;
            this.tabConvertAudio.Text = "Audio";
            this.tabConvertAudio.UseVisualStyleBackColor = true;
            // 
            // numConvertVideoBitrate
            // 
            this.numConvertVideoBitrate.Location = new System.Drawing.Point(124, 14);
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
            // lbConvertVideoBitrate
            // 
            this.lbConvertVideoBitrate.AutoSize = true;
            this.lbConvertVideoBitrate.Location = new System.Drawing.Point(79, 16);
            this.lbConvertVideoBitrate.Name = "lbConvertVideoBitrate";
            this.lbConvertVideoBitrate.Size = new System.Drawing.Size(37, 13);
            this.lbConvertVideoBitrate.TabIndex = 1;
            this.lbConvertVideoBitrate.Text = "Bitrate";
            this.tipSettings.SetToolTip(this.lbConvertVideoBitrate, resources.GetString("lbConvertVideoBitrate.ToolTip"));
            // 
            // lbConvertVideoThousands
            // 
            this.lbConvertVideoThousands.AutoSize = true;
            this.lbConvertVideoThousands.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConvertVideoThousands.Location = new System.Drawing.Point(202, 14);
            this.lbConvertVideoThousands.Name = "lbConvertVideoThousands";
            this.lbConvertVideoThousands.Size = new System.Drawing.Size(16, 17);
            this.lbConvertVideoThousands.TabIndex = 2;
            this.lbConvertVideoThousands.Text = "K";
            this.tipSettings.SetToolTip(this.lbConvertVideoThousands, "If you were to input \"10,000\" as the bitrate, it would be interpreted as \"10,000," +
        "000\" bits per second.");
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
            this.cbConvertVideoPreset.Location = new System.Drawing.Point(124, 40);
            this.cbConvertVideoPreset.Name = "cbConvertVideoPreset";
            this.cbConvertVideoPreset.Size = new System.Drawing.Size(94, 21);
            this.cbConvertVideoPreset.TabIndex = 3;
            this.tipSettings.SetToolTip(this.cbConvertVideoPreset, "The video preset of the conversion\r\n\r\nultrafast = fastest, but lower quality\r\nver" +
        "yslow = slowest, but higher quality");
            // 
            // lbConvertVideoPreset
            // 
            this.lbConvertVideoPreset.AutoSize = true;
            this.lbConvertVideoPreset.Location = new System.Drawing.Point(79, 43);
            this.lbConvertVideoPreset.Name = "lbConvertVideoPreset";
            this.lbConvertVideoPreset.Size = new System.Drawing.Size(37, 13);
            this.lbConvertVideoPreset.TabIndex = 4;
            this.lbConvertVideoPreset.Text = "Preset";
            this.tipSettings.SetToolTip(this.lbConvertVideoPreset, "The video preset of the conversion\r\n\r\nultrafast = fastest, but lower quality\r\nver" +
        "yslow = slowest, but higher quality");
            // 
            // lbConvertVideoProfile
            // 
            this.lbConvertVideoProfile.AutoSize = true;
            this.lbConvertVideoProfile.Location = new System.Drawing.Point(80, 70);
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
            this.cbConvertVideoProfile.Location = new System.Drawing.Point(124, 67);
            this.cbConvertVideoProfile.Name = "cbConvertVideoProfile";
            this.cbConvertVideoProfile.Size = new System.Drawing.Size(94, 21);
            this.cbConvertVideoProfile.TabIndex = 5;
            this.tipSettings.SetToolTip(this.cbConvertVideoProfile, "The encoder profile to be used during conversion. It affects the compression of t" +
        "he video.\r\nIt\'s generally a good idea to stick with the main profile");
            // 
            // numConvertVideoCRF
            // 
            this.numConvertVideoCRF.Location = new System.Drawing.Point(124, 94);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "CRF";
            this.tipSettings.SetToolTip(this.label1, "CRF is constant rate factor.\r\n\r\nLower = Higher quality");
            // 
            // chkVideoFastStart
            // 
            this.chkVideoFastStart.AutoSize = true;
            this.chkVideoFastStart.Location = new System.Drawing.Point(117, 123);
            this.chkVideoFastStart.Name = "chkVideoFastStart";
            this.chkVideoFastStart.Size = new System.Drawing.Size(62, 17);
            this.chkVideoFastStart.TabIndex = 9;
            this.chkVideoFastStart.Text = "faststart";
            this.tipSettings.SetToolTip(this.chkVideoFastStart, "Faststart moves the metadata to the front of the file.\r\nThis allows videos to be " +
        "played before they are fully downloaded.");
            this.chkVideoFastStart.UseVisualStyleBackColor = true;
            // 
            // tabConvertCustom
            // 
            this.tabConvertCustom.Controls.Add(this.txtConvertCustom);
            this.tabConvertCustom.Controls.Add(this.label2);
            this.tabConvertCustom.Location = new System.Drawing.Point(4, 22);
            this.tabConvertCustom.Name = "tabConvertCustom";
            this.tabConvertCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tabConvertCustom.Size = new System.Drawing.Size(296, 154);
            this.tabConvertCustom.TabIndex = 2;
            this.tabConvertCustom.Text = "Custom";
            this.tabConvertCustom.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Don\'t pass input or output directories/files,\r\nit\'s automatically handled by the " +
    "program";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtConvertCustom
            // 
            this.txtConvertCustom.Location = new System.Drawing.Point(36, 97);
            this.txtConvertCustom.Name = "txtConvertCustom";
            this.txtConvertCustom.Size = new System.Drawing.Size(228, 20);
            this.txtConvertCustom.TabIndex = 1;
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
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 324);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.tabConvertAudio.ResumeLayout(false);
            this.tabConvertAudio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertVideoBitrate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConvertVideoCRF)).EndInit();
            this.tabConvertCustom.ResumeLayout(false);
            this.tabConvertCustom.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numConvertVideoCRF;
        private System.Windows.Forms.CheckBox chkVideoFastStart;
        private System.Windows.Forms.TabPage tabConvertCustom;
        private System.Windows.Forms.TextBox txtConvertCustom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkConvertHideFFmpeg;
    }
}