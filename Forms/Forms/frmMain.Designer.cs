namespace youtube_dl_gui {
    partial class frmMain {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lbDownloadURL = new System.Windows.Forms.Label();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabDownload = new System.Windows.Forms.TabPage();
            this.chkDownloadSound = new System.Windows.Forms.CheckBox();
            this.cbQuality = new System.Windows.Forms.ComboBox();
            this.lbQuality = new System.Windows.Forms.Label();
            this.lbDownloadStatus = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.lbDownloadArgs = new System.Windows.Forms.Label();
            this.txtArgs = new System.Windows.Forms.TextBox();
            this.gbDownloadType = new System.Windows.Forms.GroupBox();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbAudio = new System.Windows.Forms.RadioButton();
            this.rbVideo = new System.Windows.Forms.RadioButton();
            this.tabConvert = new System.Windows.Forms.TabPage();
            this.rbConvertCustom = new System.Windows.Forms.RadioButton();
            this.rbConvertAutoFFmpeg = new System.Windows.Forms.RadioButton();
            this.rbConvertAuto = new System.Windows.Forms.RadioButton();
            this.lbConvStatus = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.rbConvertVideo = new System.Windows.Forms.RadioButton();
            this.rbConvertAudio = new System.Windows.Forms.RadioButton();
            this.btnConvertOutput = new System.Windows.Forms.Button();
            this.lbConvertOutput = new System.Windows.Forms.Label();
            this.txtConvertOutput = new System.Windows.Forms.TextBox();
            this.btnConvertInput = new System.Windows.Forms.Button();
            this.lbConvertInput = new System.Windows.Forms.Label();
            this.txtConvertInput = new System.Windows.Forms.TextBox();
            this.tabMerge = new System.Windows.Forms.TabPage();
            this.chkMergeDeleteInput = new System.Windows.Forms.CheckBox();
            this.chkMergeAudio = new System.Windows.Forms.CheckBox();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnBrwsMergeOutput = new System.Windows.Forms.Button();
            this.txtMergeOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrwsMergeInput2 = new System.Windows.Forms.Button();
            this.txtMergeInput2 = new System.Windows.Forms.TextBox();
            this.btnBrwsMergeInput1 = new System.Windows.Forms.Button();
            this.txtMergeInput1 = new System.Windows.Forms.TextBox();
            this.lbMergeInput2 = new System.Windows.Forms.Label();
            this.lbMergeInput1 = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MainMenu(this.components);
            this.mSettings = new System.Windows.Forms.MenuItem();
            this.mTools = new System.Windows.Forms.MenuItem();
            this.mBatch = new System.Windows.Forms.MenuItem();
            this.mMiscTools = new System.Windows.Forms.MenuItem();
            this.mHelp = new System.Windows.Forms.MenuItem();
            this.mSites = new System.Windows.Forms.MenuItem();
            this.mAbout = new System.Windows.Forms.MenuItem();
            this.lbDebug = new System.Windows.Forms.Label();
            this.cmTray = new System.Windows.Forms.ContextMenu();
            this.cmShow = new System.Windows.Forms.MenuItem();
            this.mDownloader = new System.Windows.Forms.MenuItem();
            this.cmClipboardDownload = new System.Windows.Forms.MenuItem();
            this.cmDownloadVideo = new System.Windows.Forms.MenuItem();
            this.cmDownloadAudio = new System.Windows.Forms.MenuItem();
            this.cmDownloadCustom = new System.Windows.Forms.MenuItem();
            this.cmCustomTxtBox = new System.Windows.Forms.MenuItem();
            this.cmCustomSep = new System.Windows.Forms.MenuItem();
            this.cmCustomTxt = new System.Windows.Forms.MenuItem();
            this.cmCustomSettings = new System.Windows.Forms.MenuItem();
            this.mConverter = new System.Windows.Forms.MenuItem();
            this.mConvertTo = new System.Windows.Forms.MenuItem();
            this.mConvertVideo = new System.Windows.Forms.MenuItem();
            this.mConvertAudio = new System.Windows.Forms.MenuItem();
            this.mConvertCustom = new System.Windows.Forms.MenuItem();
            this.mConvertAutomatic = new System.Windows.Forms.MenuItem();
            this.mConvertAutoFFmpeg = new System.Windows.Forms.MenuItem();
            this.cmSep = new System.Windows.Forms.MenuItem();
            this.cmExit = new System.Windows.Forms.MenuItem();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tmrConvertLabel = new System.Windows.Forms.Timer(this.components);
            this.tmrDownloadLabel = new System.Windows.Forms.Timer(this.components);
            this.tcMain.SuspendLayout();
            this.tabDownload.SuspendLayout();
            this.gbDownloadType.SuspendLayout();
            this.tabConvert.SuspendLayout();
            this.tabMerge.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(22, 27);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(200, 20);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.MouseEnter += new System.EventHandler(this.txtUrl_MouseEnter);
            // 
            // lbDownloadURL
            // 
            this.lbDownloadURL.AutoSize = true;
            this.lbDownloadURL.Location = new System.Drawing.Point(15, 8);
            this.lbDownloadURL.Name = "lbDownloadURL";
            this.lbDownloadURL.Size = new System.Drawing.Size(29, 13);
            this.lbDownloadURL.TabIndex = 1;
            this.lbDownloadURL.Text = "URL";
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabDownload);
            this.tcMain.Controls.Add(this.tabConvert);
            this.tcMain.Controls.Add(this.tabMerge);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(252, 229);
            this.tcMain.TabIndex = 1;
            // 
            // tabDownload
            // 
            this.tabDownload.Controls.Add(this.chkDownloadSound);
            this.tabDownload.Controls.Add(this.cbQuality);
            this.tabDownload.Controls.Add(this.lbQuality);
            this.tabDownload.Controls.Add(this.lbDownloadStatus);
            this.tabDownload.Controls.Add(this.btnDownload);
            this.tabDownload.Controls.Add(this.lbDownloadArgs);
            this.tabDownload.Controls.Add(this.lbDownloadURL);
            this.tabDownload.Controls.Add(this.txtArgs);
            this.tabDownload.Controls.Add(this.gbDownloadType);
            this.tabDownload.Controls.Add(this.txtUrl);
            this.tabDownload.Location = new System.Drawing.Point(4, 22);
            this.tabDownload.Name = "tabDownload";
            this.tabDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownload.Size = new System.Drawing.Size(244, 203);
            this.tabDownload.TabIndex = 0;
            this.tabDownload.Text = "Download";
            this.tabDownload.UseVisualStyleBackColor = true;
            // 
            // chkDownloadSound
            // 
            this.chkDownloadSound.AutoSize = true;
            this.chkDownloadSound.Checked = true;
            this.chkDownloadSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDownloadSound.Location = new System.Drawing.Point(160, 104);
            this.chkDownloadSound.Name = "chkDownloadSound";
            this.chkDownloadSound.Size = new System.Drawing.Size(56, 17);
            this.chkDownloadSound.TabIndex = 21;
            this.chkDownloadSound.Text = "Sound";
            this.chkDownloadSound.UseVisualStyleBackColor = true;
            // 
            // cbQuality
            // 
            this.cbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuality.FormattingEnabled = true;
            this.cbQuality.Items.AddRange(new object[] {
            "best",
            "4320p60",
            "4320p",
            "2160p60",
            "2160p",
            "1440p60",
            "1440p",
            "1080p60",
            "1080p",
            "720p60",
            "720p",
            "480p",
            "360p",
            "240p",
            "144p"});
            this.cbQuality.Location = new System.Drawing.Point(74, 102);
            this.cbQuality.Name = "cbQuality";
            this.cbQuality.Size = new System.Drawing.Size(80, 21);
            this.cbQuality.TabIndex = 19;
            // 
            // lbQuality
            // 
            this.lbQuality.AutoSize = true;
            this.lbQuality.Location = new System.Drawing.Point(29, 105);
            this.lbQuality.Name = "lbQuality";
            this.lbQuality.Size = new System.Drawing.Size(39, 13);
            this.lbQuality.TabIndex = 18;
            this.lbQuality.Text = "Quality";
            // 
            // lbDownloadStatus
            // 
            this.lbDownloadStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDownloadStatus.Location = new System.Drawing.Point(3, 200);
            this.lbDownloadStatus.Name = "lbDownloadStatus";
            this.lbDownloadStatus.Size = new System.Drawing.Size(238, 20);
            this.lbDownloadStatus.TabIndex = 17;
            this.lbDownloadStatus.Text = "waiting";
            this.lbDownloadStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDownloadStatus.Visible = false;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(83, 172);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(79, 25);
            this.btnDownload.TabIndex = 4;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // lbDownloadArgs
            // 
            this.lbDownloadArgs.AutoSize = true;
            this.lbDownloadArgs.Location = new System.Drawing.Point(15, 128);
            this.lbDownloadArgs.Name = "lbDownloadArgs";
            this.lbDownloadArgs.Size = new System.Drawing.Size(94, 13);
            this.lbDownloadArgs.TabIndex = 2;
            this.lbDownloadArgs.Text = "Custom arguments";
            // 
            // txtArgs
            // 
            this.txtArgs.Location = new System.Drawing.Point(22, 148);
            this.txtArgs.Name = "txtArgs";
            this.txtArgs.ReadOnly = true;
            this.txtArgs.Size = new System.Drawing.Size(200, 20);
            this.txtArgs.TabIndex = 3;
            // 
            // gbDownloadType
            // 
            this.gbDownloadType.Controls.Add(this.rbCustom);
            this.gbDownloadType.Controls.Add(this.rbAudio);
            this.gbDownloadType.Controls.Add(this.rbVideo);
            this.gbDownloadType.Location = new System.Drawing.Point(26, 54);
            this.gbDownloadType.Name = "gbDownloadType";
            this.gbDownloadType.Size = new System.Drawing.Size(192, 40);
            this.gbDownloadType.TabIndex = 2;
            this.gbDownloadType.TabStop = false;
            this.gbDownloadType.Text = "Download type";
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(125, 15);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(59, 17);
            this.rbCustom.TabIndex = 3;
            this.rbCustom.TabStop = true;
            this.rbCustom.Text = "Custom";
            this.rbCustom.UseVisualStyleBackColor = true;
            this.rbCustom.CheckedChanged += new System.EventHandler(this.rbCustom_CheckedChanged);
            // 
            // rbAudio
            // 
            this.rbAudio.AutoSize = true;
            this.rbAudio.Location = new System.Drawing.Point(67, 15);
            this.rbAudio.Name = "rbAudio";
            this.rbAudio.Size = new System.Drawing.Size(51, 17);
            this.rbAudio.TabIndex = 2;
            this.rbAudio.TabStop = true;
            this.rbAudio.Text = "Audio";
            this.rbAudio.UseVisualStyleBackColor = true;
            this.rbAudio.CheckedChanged += new System.EventHandler(this.rbAudio_CheckedChanged);
            // 
            // rbVideo
            // 
            this.rbVideo.AutoSize = true;
            this.rbVideo.Location = new System.Drawing.Point(8, 15);
            this.rbVideo.Name = "rbVideo";
            this.rbVideo.Size = new System.Drawing.Size(51, 17);
            this.rbVideo.TabIndex = 1;
            this.rbVideo.TabStop = true;
            this.rbVideo.Text = "Video";
            this.rbVideo.UseVisualStyleBackColor = true;
            this.rbVideo.CheckedChanged += new System.EventHandler(this.rbVideo_CheckedChanged);
            // 
            // tabConvert
            // 
            this.tabConvert.Controls.Add(this.rbConvertCustom);
            this.tabConvert.Controls.Add(this.rbConvertAutoFFmpeg);
            this.tabConvert.Controls.Add(this.rbConvertAuto);
            this.tabConvert.Controls.Add(this.lbConvStatus);
            this.tabConvert.Controls.Add(this.btnConvert);
            this.tabConvert.Controls.Add(this.rbConvertVideo);
            this.tabConvert.Controls.Add(this.rbConvertAudio);
            this.tabConvert.Controls.Add(this.btnConvertOutput);
            this.tabConvert.Controls.Add(this.lbConvertOutput);
            this.tabConvert.Controls.Add(this.txtConvertOutput);
            this.tabConvert.Controls.Add(this.btnConvertInput);
            this.tabConvert.Controls.Add(this.lbConvertInput);
            this.tabConvert.Controls.Add(this.txtConvertInput);
            this.tabConvert.Location = new System.Drawing.Point(4, 22);
            this.tabConvert.Name = "tabConvert";
            this.tabConvert.Padding = new System.Windows.Forms.Padding(3);
            this.tabConvert.Size = new System.Drawing.Size(244, 203);
            this.tabConvert.TabIndex = 1;
            this.tabConvert.Text = "Convert";
            this.tabConvert.UseVisualStyleBackColor = true;
            // 
            // rbConvertCustom
            // 
            this.rbConvertCustom.AutoSize = true;
            this.rbConvertCustom.Location = new System.Drawing.Point(151, 112);
            this.rbConvertCustom.Name = "rbConvertCustom";
            this.rbConvertCustom.Size = new System.Drawing.Size(59, 17);
            this.rbConvertCustom.TabIndex = 7;
            this.rbConvertCustom.TabStop = true;
            this.rbConvertCustom.Text = "Custom";
            this.rbConvertCustom.UseVisualStyleBackColor = true;
            // 
            // rbConvertAutoFFmpeg
            // 
            this.rbConvertAutoFFmpeg.AutoSize = true;
            this.rbConvertAutoFFmpeg.Location = new System.Drawing.Point(120, 135);
            this.rbConvertAutoFFmpeg.Name = "rbConvertAutoFFmpeg";
            this.rbConvertAutoFFmpeg.Size = new System.Drawing.Size(81, 17);
            this.rbConvertAutoFFmpeg.TabIndex = 9;
            this.rbConvertAutoFFmpeg.TabStop = true;
            this.rbConvertAutoFFmpeg.Text = "Auto ffmpeg";
            this.rbConvertAutoFFmpeg.UseVisualStyleBackColor = true;
            // 
            // rbConvertAuto
            // 
            this.rbConvertAuto.AutoSize = true;
            this.rbConvertAuto.Location = new System.Drawing.Point(43, 135);
            this.rbConvertAuto.Name = "rbConvertAuto";
            this.rbConvertAuto.Size = new System.Drawing.Size(71, 17);
            this.rbConvertAuto.TabIndex = 8;
            this.rbConvertAuto.TabStop = true;
            this.rbConvertAuto.Text = "Automatic";
            this.rbConvertAuto.UseVisualStyleBackColor = true;
            // 
            // lbConvStatus
            // 
            this.lbConvStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbConvStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConvStatus.Location = new System.Drawing.Point(3, 178);
            this.lbConvStatus.Name = "lbConvStatus";
            this.lbConvStatus.Size = new System.Drawing.Size(238, 22);
            this.lbConvStatus.TabIndex = 16;
            this.lbConvStatus.Text = "waiting";
            this.lbConvStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbConvStatus.Visible = false;
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(83, 170);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(79, 25);
            this.btnConvert.TabIndex = 10;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // rbConvertVideo
            // 
            this.rbConvertVideo.AutoSize = true;
            this.rbConvertVideo.Location = new System.Drawing.Point(35, 112);
            this.rbConvertVideo.Name = "rbConvertVideo";
            this.rbConvertVideo.Size = new System.Drawing.Size(51, 17);
            this.rbConvertVideo.TabIndex = 5;
            this.rbConvertVideo.TabStop = true;
            this.rbConvertVideo.Text = "Video";
            this.rbConvertVideo.UseVisualStyleBackColor = true;
            // 
            // rbConvertAudio
            // 
            this.rbConvertAudio.AutoSize = true;
            this.rbConvertAudio.Location = new System.Drawing.Point(94, 112);
            this.rbConvertAudio.Name = "rbConvertAudio";
            this.rbConvertAudio.Size = new System.Drawing.Size(51, 17);
            this.rbConvertAudio.TabIndex = 6;
            this.rbConvertAudio.TabStop = true;
            this.rbConvertAudio.Text = "Audio";
            this.rbConvertAudio.UseVisualStyleBackColor = true;
            // 
            // btnConvertOutput
            // 
            this.btnConvertOutput.Enabled = false;
            this.btnConvertOutput.Location = new System.Drawing.Point(193, 72);
            this.btnConvertOutput.Name = "btnConvertOutput";
            this.btnConvertOutput.Size = new System.Drawing.Size(29, 23);
            this.btnConvertOutput.TabIndex = 4;
            this.btnConvertOutput.Text = "...";
            this.btnConvertOutput.UseVisualStyleBackColor = true;
            this.btnConvertOutput.Click += new System.EventHandler(this.btnConvertOutput_Click);
            // 
            // lbConvertOutput
            // 
            this.lbConvertOutput.AutoSize = true;
            this.lbConvertOutput.Location = new System.Drawing.Point(19, 54);
            this.lbConvertOutput.Name = "lbConvertOutput";
            this.lbConvertOutput.Size = new System.Drawing.Size(39, 13);
            this.lbConvertOutput.TabIndex = 7;
            this.lbConvertOutput.Text = "Output";
            // 
            // txtConvertOutput
            // 
            this.txtConvertOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConvertOutput.Location = new System.Drawing.Point(26, 74);
            this.txtConvertOutput.Name = "txtConvertOutput";
            this.txtConvertOutput.ReadOnly = true;
            this.txtConvertOutput.Size = new System.Drawing.Size(161, 20);
            this.txtConvertOutput.TabIndex = 3;
            // 
            // btnConvertInput
            // 
            this.btnConvertInput.Location = new System.Drawing.Point(193, 25);
            this.btnConvertInput.Name = "btnConvertInput";
            this.btnConvertInput.Size = new System.Drawing.Size(29, 23);
            this.btnConvertInput.TabIndex = 2;
            this.btnConvertInput.Text = "...";
            this.btnConvertInput.UseVisualStyleBackColor = true;
            this.btnConvertInput.Click += new System.EventHandler(this.btnConvertInput_Click);
            // 
            // lbConvertInput
            // 
            this.lbConvertInput.AutoSize = true;
            this.lbConvertInput.Location = new System.Drawing.Point(19, 7);
            this.lbConvertInput.Name = "lbConvertInput";
            this.lbConvertInput.Size = new System.Drawing.Size(31, 13);
            this.lbConvertInput.TabIndex = 3;
            this.lbConvertInput.Text = "Input";
            // 
            // txtConvertInput
            // 
            this.txtConvertInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConvertInput.Location = new System.Drawing.Point(26, 27);
            this.txtConvertInput.Name = "txtConvertInput";
            this.txtConvertInput.ReadOnly = true;
            this.txtConvertInput.Size = new System.Drawing.Size(161, 20);
            this.txtConvertInput.TabIndex = 1;
            // 
            // tabMerge
            // 
            this.tabMerge.Controls.Add(this.chkMergeDeleteInput);
            this.tabMerge.Controls.Add(this.chkMergeAudio);
            this.tabMerge.Controls.Add(this.btnMerge);
            this.tabMerge.Controls.Add(this.btnBrwsMergeOutput);
            this.tabMerge.Controls.Add(this.txtMergeOutput);
            this.tabMerge.Controls.Add(this.label1);
            this.tabMerge.Controls.Add(this.btnBrwsMergeInput2);
            this.tabMerge.Controls.Add(this.txtMergeInput2);
            this.tabMerge.Controls.Add(this.btnBrwsMergeInput1);
            this.tabMerge.Controls.Add(this.txtMergeInput1);
            this.tabMerge.Controls.Add(this.lbMergeInput2);
            this.tabMerge.Controls.Add(this.lbMergeInput1);
            this.tabMerge.Location = new System.Drawing.Point(4, 22);
            this.tabMerge.Name = "tabMerge";
            this.tabMerge.Padding = new System.Windows.Forms.Padding(3);
            this.tabMerge.Size = new System.Drawing.Size(244, 203);
            this.tabMerge.TabIndex = 2;
            this.tabMerge.Text = "Merge";
            this.tabMerge.UseVisualStyleBackColor = true;
            // 
            // chkMergeDeleteInput
            // 
            this.chkMergeDeleteInput.AutoSize = true;
            this.chkMergeDeleteInput.Location = new System.Drawing.Point(64, 170);
            this.chkMergeDeleteInput.Name = "chkMergeDeleteInput";
            this.chkMergeDeleteInput.Size = new System.Drawing.Size(103, 17);
            this.chkMergeDeleteInput.TabIndex = 15;
            this.chkMergeDeleteInput.Text = "Delete input files";
            this.chkMergeDeleteInput.UseVisualStyleBackColor = true;
            // 
            // chkMergeAudio
            // 
            this.chkMergeAudio.AutoSize = true;
            this.chkMergeAudio.Checked = true;
            this.chkMergeAudio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMergeAudio.Location = new System.Drawing.Point(64, 147);
            this.chkMergeAudio.Name = "chkMergeAudio";
            this.chkMergeAudio.Size = new System.Drawing.Size(116, 17);
            this.chkMergeAudio.TabIndex = 14;
            this.chkMergeAudio.Text = "Merge audio tracks";
            this.chkMergeAudio.UseVisualStyleBackColor = true;
            // 
            // btnMerge
            // 
            this.btnMerge.Enabled = false;
            this.btnMerge.Location = new System.Drawing.Point(83, 190);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(79, 25);
            this.btnMerge.TabIndex = 13;
            this.btnMerge.Text = "Merge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnBrwsMergeOutput
            // 
            this.btnBrwsMergeOutput.Enabled = false;
            this.btnBrwsMergeOutput.Location = new System.Drawing.Point(193, 119);
            this.btnBrwsMergeOutput.Name = "btnBrwsMergeOutput";
            this.btnBrwsMergeOutput.Size = new System.Drawing.Size(29, 23);
            this.btnBrwsMergeOutput.TabIndex = 11;
            this.btnBrwsMergeOutput.Text = "...";
            this.btnBrwsMergeOutput.UseVisualStyleBackColor = true;
            this.btnBrwsMergeOutput.Click += new System.EventHandler(this.btnBrwsMergeOutput_Click);
            // 
            // txtMergeOutput
            // 
            this.txtMergeOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMergeOutput.Location = new System.Drawing.Point(26, 121);
            this.txtMergeOutput.Name = "txtMergeOutput";
            this.txtMergeOutput.ReadOnly = true;
            this.txtMergeOutput.Size = new System.Drawing.Size(161, 20);
            this.txtMergeOutput.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Output";
            // 
            // btnBrwsMergeInput2
            // 
            this.btnBrwsMergeInput2.Enabled = false;
            this.btnBrwsMergeInput2.Location = new System.Drawing.Point(193, 72);
            this.btnBrwsMergeInput2.Name = "btnBrwsMergeInput2";
            this.btnBrwsMergeInput2.Size = new System.Drawing.Size(29, 23);
            this.btnBrwsMergeInput2.TabIndex = 8;
            this.btnBrwsMergeInput2.Text = "...";
            this.btnBrwsMergeInput2.UseVisualStyleBackColor = true;
            this.btnBrwsMergeInput2.Click += new System.EventHandler(this.btnBrwsMergeInput2_Click);
            // 
            // txtMergeInput2
            // 
            this.txtMergeInput2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMergeInput2.Location = new System.Drawing.Point(26, 74);
            this.txtMergeInput2.Name = "txtMergeInput2";
            this.txtMergeInput2.ReadOnly = true;
            this.txtMergeInput2.Size = new System.Drawing.Size(161, 20);
            this.txtMergeInput2.TabIndex = 7;
            // 
            // btnBrwsMergeInput1
            // 
            this.btnBrwsMergeInput1.Location = new System.Drawing.Point(193, 25);
            this.btnBrwsMergeInput1.Name = "btnBrwsMergeInput1";
            this.btnBrwsMergeInput1.Size = new System.Drawing.Size(29, 23);
            this.btnBrwsMergeInput1.TabIndex = 6;
            this.btnBrwsMergeInput1.Text = "...";
            this.btnBrwsMergeInput1.UseVisualStyleBackColor = true;
            this.btnBrwsMergeInput1.Click += new System.EventHandler(this.btnBrwsMergeInput1_Click);
            // 
            // txtMergeInput1
            // 
            this.txtMergeInput1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMergeInput1.Location = new System.Drawing.Point(26, 27);
            this.txtMergeInput1.Name = "txtMergeInput1";
            this.txtMergeInput1.ReadOnly = true;
            this.txtMergeInput1.Size = new System.Drawing.Size(161, 20);
            this.txtMergeInput1.TabIndex = 5;
            // 
            // lbMergeInput2
            // 
            this.lbMergeInput2.AutoSize = true;
            this.lbMergeInput2.Location = new System.Drawing.Point(19, 54);
            this.lbMergeInput2.Name = "lbMergeInput2";
            this.lbMergeInput2.Size = new System.Drawing.Size(40, 13);
            this.lbMergeInput2.TabIndex = 1;
            this.lbMergeInput2.Text = "Input 2";
            // 
            // lbMergeInput1
            // 
            this.lbMergeInput1.AutoSize = true;
            this.lbMergeInput1.Location = new System.Drawing.Point(19, 7);
            this.lbMergeInput1.Name = "lbMergeInput1";
            this.lbMergeInput1.Size = new System.Drawing.Size(40, 13);
            this.lbMergeInput1.TabIndex = 0;
            this.lbMergeInput1.Text = "Input 1";
            // 
            // menu
            // 
            this.menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mSettings,
            this.mTools,
            this.mHelp,
            this.mAbout});
            // 
            // mSettings
            // 
            this.mSettings.Index = 0;
            this.mSettings.Text = "Settings";
            this.mSettings.Click += new System.EventHandler(this.mSettings_Click);
            // 
            // mTools
            // 
            this.mTools.Index = 1;
            this.mTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mBatch,
            this.mMiscTools});
            this.mTools.Text = "Tools";
            // 
            // mBatch
            // 
            this.mBatch.Enabled = false;
            this.mBatch.Index = 0;
            this.mBatch.Text = "Batch download";
            this.mBatch.Click += new System.EventHandler(this.mBatch_Click);
            // 
            // mMiscTools
            // 
            this.mMiscTools.Index = 1;
            this.mMiscTools.Text = "Misc tools";
            this.mMiscTools.Click += new System.EventHandler(this.mMiscTools_Click);
            // 
            // mHelp
            // 
            this.mHelp.Index = 2;
            this.mHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mSites});
            this.mHelp.Text = "Help";
            // 
            // mSites
            // 
            this.mSites.Index = 0;
            this.mSites.Text = "Supported sites";
            this.mSites.Click += new System.EventHandler(this.mSites_Click);
            // 
            // mAbout
            // 
            this.mAbout.Index = 3;
            this.mAbout.Text = "About";
            this.mAbout.Click += new System.EventHandler(this.mAbout_Click);
            // 
            // lbDebug
            // 
            this.lbDebug.AutoSize = true;
            this.lbDebug.Location = new System.Drawing.Point(179, 3);
            this.lbDebug.Name = "lbDebug";
            this.lbDebug.Size = new System.Drawing.Size(61, 13);
            this.lbDebug.TabIndex = 3;
            this.lbDebug.Text = "2019-07-24";
            this.lbDebug.Visible = false;
            // 
            // cmTray
            // 
            this.cmTray.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmShow,
            this.mDownloader,
            this.mConverter,
            this.cmSep,
            this.cmExit});
            // 
            // cmShow
            // 
            this.cmShow.Index = 0;
            this.cmShow.Text = "Show";
            this.cmShow.Click += new System.EventHandler(this.cmShow_Click);
            // 
            // mDownloader
            // 
            this.mDownloader.Index = 1;
            this.mDownloader.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmClipboardDownload});
            this.mDownloader.Text = "Downloader";
            // 
            // cmClipboardDownload
            // 
            this.cmClipboardDownload.Index = 0;
            this.cmClipboardDownload.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmDownloadVideo,
            this.cmDownloadAudio,
            this.cmDownloadCustom});
            this.cmClipboardDownload.Text = "Clipboard...";
            // 
            // cmDownloadVideo
            // 
            this.cmDownloadVideo.Index = 0;
            this.cmDownloadVideo.Text = "Download Best Video";
            this.cmDownloadVideo.Click += new System.EventHandler(this.cmDownloadVideo_Click);
            // 
            // cmDownloadAudio
            // 
            this.cmDownloadAudio.Index = 1;
            this.cmDownloadAudio.Text = "Download Best Audio";
            this.cmDownloadAudio.Click += new System.EventHandler(this.cmDownloadAudio_Click);
            // 
            // cmDownloadCustom
            // 
            this.cmDownloadCustom.Index = 2;
            this.cmDownloadCustom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmCustomTxtBox,
            this.cmCustomSep,
            this.cmCustomTxt,
            this.cmCustomSettings});
            this.cmDownloadCustom.Text = "Download Custom";
            // 
            // cmCustomTxtBox
            // 
            this.cmCustomTxtBox.Index = 0;
            this.cmCustomTxtBox.Text = "From form textbox";
            this.cmCustomTxtBox.Click += new System.EventHandler(this.cmCustomTxtBox_Click);
            // 
            // cmCustomSep
            // 
            this.cmCustomSep.Index = 1;
            this.cmCustomSep.Text = "-";
            // 
            // cmCustomTxt
            // 
            this.cmCustomTxt.Index = 2;
            this.cmCustomTxt.Text = "From args.txt";
            this.cmCustomTxt.Click += new System.EventHandler(this.cmCustomTxt_Click);
            // 
            // cmCustomSettings
            // 
            this.cmCustomSettings.Index = 3;
            this.cmCustomSettings.Text = "From settings";
            this.cmCustomSettings.Click += new System.EventHandler(this.cmCustomSettings_Click);
            // 
            // mConverter
            // 
            this.mConverter.Index = 2;
            this.mConverter.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mConvertTo});
            this.mConverter.Text = "Converter";
            // 
            // mConvertTo
            // 
            this.mConvertTo.Index = 0;
            this.mConvertTo.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mConvertVideo,
            this.mConvertAudio,
            this.mConvertCustom,
            this.mConvertAutomatic,
            this.mConvertAutoFFmpeg});
            this.mConvertTo.Text = "Convert to...";
            // 
            // mConvertVideo
            // 
            this.mConvertVideo.Index = 0;
            this.mConvertVideo.Text = "Video";
            this.mConvertVideo.Click += new System.EventHandler(this.mConvertVideo_Click);
            // 
            // mConvertAudio
            // 
            this.mConvertAudio.Index = 1;
            this.mConvertAudio.Text = "Audio";
            this.mConvertAudio.Click += new System.EventHandler(this.mConvertAudio_Click);
            // 
            // mConvertCustom
            // 
            this.mConvertCustom.Index = 2;
            this.mConvertCustom.Text = "Custom";
            this.mConvertCustom.Click += new System.EventHandler(this.mConvertCustom_Click);
            // 
            // mConvertAutomatic
            // 
            this.mConvertAutomatic.Index = 3;
            this.mConvertAutomatic.Text = "Automatic";
            this.mConvertAutomatic.Click += new System.EventHandler(this.mConvertAutomatic_Click);
            // 
            // mConvertAutoFFmpeg
            // 
            this.mConvertAutoFFmpeg.Index = 4;
            this.mConvertAutoFFmpeg.Text = "Auto ffmpeg";
            this.mConvertAutoFFmpeg.Click += new System.EventHandler(this.mConvertAutoFFmpeg_Click);
            // 
            // cmSep
            // 
            this.cmSep.Index = 3;
            this.cmSep.Text = "-";
            // 
            // cmExit
            // 
            this.cmExit.Index = 4;
            this.cmExit.Text = "Exit";
            this.cmExit.Click += new System.EventHandler(this.cmExit_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipText = "You click this thing, and BADA-BOOM, you\'re back in it again";
            this.trayIcon.BalloonTipTitle = "Unseen easter egg";
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "youtube-dl-gui";
            this.trayIcon.Visible = true;
            // 
            // tmrConvertLabel
            // 
            this.tmrConvertLabel.Interval = 5000;
            this.tmrConvertLabel.Tick += new System.EventHandler(this.tmrConvertLabel_Tick);
            // 
            // tmrDownloadLabel
            // 
            this.tmrDownloadLabel.Interval = 5000;
            this.tmrDownloadLabel.Tick += new System.EventHandler(this.tmrDownloadLabel_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(252, 229);
            this.Controls.Add(this.lbDebug);
            this.Controls.Add(this.tcMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(260, 300);
            this.Menu = this.menu;
            this.MinimumSize = new System.Drawing.Size(260, 300);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "youtube-dl-gui";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tcMain.ResumeLayout(false);
            this.tabDownload.ResumeLayout(false);
            this.tabDownload.PerformLayout();
            this.gbDownloadType.ResumeLayout(false);
            this.gbDownloadType.PerformLayout();
            this.tabConvert.ResumeLayout(false);
            this.tabConvert.PerformLayout();
            this.tabMerge.ResumeLayout(false);
            this.tabMerge.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lbDownloadURL;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabDownload;
        private System.Windows.Forms.TabPage tabConvert;
        private System.Windows.Forms.MainMenu menu;
        private System.Windows.Forms.MenuItem mSettings;
        private System.Windows.Forms.MenuItem mHelp;
        private System.Windows.Forms.Label lbDebug;
        private System.Windows.Forms.GroupBox gbDownloadType;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rbAudio;
        private System.Windows.Forms.RadioButton rbVideo;
        private System.Windows.Forms.Label lbDownloadArgs;
        private System.Windows.Forms.TextBox txtArgs;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.MenuItem mAbout;
        private System.Windows.Forms.ContextMenu cmTray;
        private System.Windows.Forms.MenuItem cmShow;
        private System.Windows.Forms.MenuItem cmClipboardDownload;
        private System.Windows.Forms.MenuItem cmDownloadAudio;
        private System.Windows.Forms.MenuItem cmDownloadVideo;
        private System.Windows.Forms.MenuItem cmDownloadCustom;
        private System.Windows.Forms.MenuItem cmCustomTxtBox;
        private System.Windows.Forms.MenuItem cmCustomSep;
        private System.Windows.Forms.MenuItem cmCustomTxt;
        private System.Windows.Forms.MenuItem cmCustomSettings;
        private System.Windows.Forms.MenuItem cmSep;
        private System.Windows.Forms.MenuItem cmExit;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.MenuItem mSites;
        private System.Windows.Forms.Button btnConvertOutput;
        private System.Windows.Forms.Label lbConvertOutput;
        private System.Windows.Forms.TextBox txtConvertOutput;
        private System.Windows.Forms.Button btnConvertInput;
        private System.Windows.Forms.Label lbConvertInput;
        private System.Windows.Forms.TextBox txtConvertInput;
        private System.Windows.Forms.RadioButton rbConvertAudio;
        private System.Windows.Forms.RadioButton rbConvertVideo;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label lbConvStatus;
        private System.Windows.Forms.Timer tmrConvertLabel;
        private System.Windows.Forms.RadioButton rbConvertAuto;
        private System.Windows.Forms.RadioButton rbConvertAutoFFmpeg;
        private System.Windows.Forms.RadioButton rbConvertCustom;
        private System.Windows.Forms.MenuItem mDownloader;
        private System.Windows.Forms.MenuItem mConverter;
        private System.Windows.Forms.MenuItem mConvertTo;
        private System.Windows.Forms.MenuItem mConvertVideo;
        private System.Windows.Forms.MenuItem mConvertAudio;
        private System.Windows.Forms.MenuItem mConvertCustom;
        private System.Windows.Forms.MenuItem mConvertAutomatic;
        private System.Windows.Forms.MenuItem mConvertAutoFFmpeg;
        private System.Windows.Forms.TabPage tabMerge;
        private System.Windows.Forms.Label lbDownloadStatus;
        private System.Windows.Forms.Timer tmrDownloadLabel;
        private System.Windows.Forms.ComboBox cbQuality;
        private System.Windows.Forms.Label lbQuality;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnBrwsMergeOutput;
        private System.Windows.Forms.TextBox txtMergeOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrwsMergeInput2;
        private System.Windows.Forms.TextBox txtMergeInput2;
        private System.Windows.Forms.Button btnBrwsMergeInput1;
        private System.Windows.Forms.TextBox txtMergeInput1;
        private System.Windows.Forms.Label lbMergeInput2;
        private System.Windows.Forms.Label lbMergeInput1;
        private System.Windows.Forms.CheckBox chkMergeAudio;
        private System.Windows.Forms.CheckBox chkMergeDeleteInput;
        private System.Windows.Forms.CheckBox chkDownloadSound;
        private System.Windows.Forms.MenuItem mTools;
        private System.Windows.Forms.MenuItem mBatch;
        private System.Windows.Forms.MenuItem mMiscTools;
    }
}

