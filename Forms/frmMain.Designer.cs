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
        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.lbURL = new System.Windows.Forms.Label();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabDownload = new System.Windows.Forms.TabPage();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.lbFormat = new System.Windows.Forms.Label();
            this.lbDownloadStatus = new System.Windows.Forms.Label();
            this.sbDownload = new youtube_dl_gui.SplitButton();
            this.cmDownload = new System.Windows.Forms.ContextMenu();
            this.mBatchDownloadFromFile = new System.Windows.Forms.MenuItem();
            this.chkDownloadSound = new System.Windows.Forms.CheckBox();
            this.cbQuality = new System.Windows.Forms.ComboBox();
            this.lbQuality = new System.Windows.Forms.Label();
            this.lbCustomArguments = new System.Windows.Forms.Label();
            this.txtArgs = new System.Windows.Forms.TextBox();
            this.gbDownloadType = new System.Windows.Forms.GroupBox();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbAudio = new System.Windows.Forms.RadioButton();
            this.rbVideo = new System.Windows.Forms.RadioButton();
            this.tabConvert = new System.Windows.Forms.TabPage();
            this.rbConvertCustom = new System.Windows.Forms.RadioButton();
            this.rbConvertAudio = new System.Windows.Forms.RadioButton();
            this.rbConvertAutoFFmpeg = new System.Windows.Forms.RadioButton();
            this.rbConvertAuto = new System.Windows.Forms.RadioButton();
            this.lbConvertStatus = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.rbConvertVideo = new System.Windows.Forms.RadioButton();
            this.btnConvertOutput = new System.Windows.Forms.Button();
            this.lbConvertOutput = new System.Windows.Forms.Label();
            this.txtConvertOutput = new System.Windows.Forms.TextBox();
            this.btnConvertInput = new System.Windows.Forms.Button();
            this.lbConvertInput = new System.Windows.Forms.Label();
            this.txtConvertInput = new System.Windows.Forms.TextBox();
            this.tabMerge = new System.Windows.Forms.TabPage();
            this.chkMergeDeleteInputFiles = new System.Windows.Forms.CheckBox();
            this.chkMergeAudioTracks = new System.Windows.Forms.CheckBox();
            this.btnMerge = new System.Windows.Forms.Button();
            this.btnBrwsMergeOutput = new System.Windows.Forms.Button();
            this.txtMergeOutput = new System.Windows.Forms.TextBox();
            this.lbMergeOutput = new System.Windows.Forms.Label();
            this.btnBrwsMergeInput2 = new System.Windows.Forms.Button();
            this.txtMergeInput2 = new System.Windows.Forms.TextBox();
            this.btnBrwsMergeInput1 = new System.Windows.Forms.Button();
            this.txtMergeInput1 = new System.Windows.Forms.TextBox();
            this.lbMergeInput2 = new System.Windows.Forms.Label();
            this.lbMergeInput1 = new System.Windows.Forms.Label();
            this.tabDebug = new System.Windows.Forms.TabPage();
            this.btnDebugDownloadArgs = new System.Windows.Forms.Button();
            this.btnDebugForceAvailableUpdate = new System.Windows.Forms.Button();
            this.btnDebugForceUpdateCheck = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MainMenu(this.components);
            this.mSettings = new System.Windows.Forms.MenuItem();
            this.mTools = new System.Windows.Forms.MenuItem();
            this.mBatchDownload = new System.Windows.Forms.MenuItem();
            this.mDownloadSubtitles = new System.Windows.Forms.MenuItem();
            this.mMiscTools = new System.Windows.Forms.MenuItem();
            this.mHelp = new System.Windows.Forms.MenuItem();
            this.mLanguage = new System.Windows.Forms.MenuItem();
            this.mSupportedSites = new System.Windows.Forms.MenuItem();
            this.mAbout = new System.Windows.Forms.MenuItem();
            this.lbDebug = new System.Windows.Forms.Label();
            this.cmTray = new System.Windows.Forms.ContextMenu();
            this.cmTrayShowForm = new System.Windows.Forms.MenuItem();
            this.cmTrayDownloader = new System.Windows.Forms.MenuItem();
            this.cmTrayDownloadClipboard = new System.Windows.Forms.MenuItem();
            this.cmTrayDownloadBestVideo = new System.Windows.Forms.MenuItem();
            this.cmTrayDownloadBestAudio = new System.Windows.Forms.MenuItem();
            this.cmTrayDownloadCustom = new System.Windows.Forms.MenuItem();
            this.cmTrayDownloadCustomTxtBox = new System.Windows.Forms.MenuItem();
            this.cmTrayCustomSep = new System.Windows.Forms.MenuItem();
            this.cmTrayDownloadCustomTxt = new System.Windows.Forms.MenuItem();
            this.cmTrayDownloadCustomSettings = new System.Windows.Forms.MenuItem();
            this.cmTrayConverter = new System.Windows.Forms.MenuItem();
            this.cmTrayConvertTo = new System.Windows.Forms.MenuItem();
            this.cmTrayConvertVideo = new System.Windows.Forms.MenuItem();
            this.cmTrayConvertAudio = new System.Windows.Forms.MenuItem();
            this.cmTrayConvertCustom = new System.Windows.Forms.MenuItem();
            this.cmTrayConvertAutomatic = new System.Windows.Forms.MenuItem();
            this.cmTrayConvertAutoFFmpeg = new System.Windows.Forms.MenuItem();
            this.cmTraySep = new System.Windows.Forms.MenuItem();
            this.cmTrayExit = new System.Windows.Forms.MenuItem();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tmrConvertLabel = new System.Windows.Forms.Timer(this.components);
            this.tmrDownloadLabel = new System.Windows.Forms.Timer(this.components);
            this.tcMain.SuspendLayout();
            this.tabDownload.SuspendLayout();
            this.gbDownloadType.SuspendLayout();
            this.tabConvert.SuspendLayout();
            this.tabMerge.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(22, 27);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(200, 20);
            this.txtUrl.TabIndex = 2;
            this.txtUrl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUrl_KeyPress);
            this.txtUrl.MouseEnter += new System.EventHandler(this.txtUrl_MouseEnter);
            // 
            // lbURL
            // 
            this.lbURL.AutoSize = true;
            this.lbURL.Location = new System.Drawing.Point(15, 8);
            this.lbURL.Name = "lbURL";
            this.lbURL.Size = new System.Drawing.Size(37, 13);
            this.lbURL.TabIndex = 1;
            this.lbURL.Text = "lbURL";
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabDownload);
            this.tcMain.Controls.Add(this.tabConvert);
            this.tcMain.Controls.Add(this.tabMerge);
            this.tcMain.Controls.Add(this.tabDebug);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 0);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(252, 301);
            this.tcMain.TabIndex = 0;
            // 
            // tabDownload
            // 
            this.tabDownload.Controls.Add(this.cbFormat);
            this.tabDownload.Controls.Add(this.lbFormat);
            this.tabDownload.Controls.Add(this.lbDownloadStatus);
            this.tabDownload.Controls.Add(this.sbDownload);
            this.tabDownload.Controls.Add(this.chkDownloadSound);
            this.tabDownload.Controls.Add(this.cbQuality);
            this.tabDownload.Controls.Add(this.lbQuality);
            this.tabDownload.Controls.Add(this.lbCustomArguments);
            this.tabDownload.Controls.Add(this.lbURL);
            this.tabDownload.Controls.Add(this.txtArgs);
            this.tabDownload.Controls.Add(this.gbDownloadType);
            this.tabDownload.Controls.Add(this.txtUrl);
            this.tabDownload.Location = new System.Drawing.Point(4, 22);
            this.tabDownload.Name = "tabDownload";
            this.tabDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownload.Size = new System.Drawing.Size(244, 275);
            this.tabDownload.TabIndex = 0;
            this.tabDownload.Text = "tabDownload";
            this.tabDownload.UseVisualStyleBackColor = true;
            // 
            // cbFormat
            // 
            this.cbFormat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Location = new System.Drawing.Point(74, 147);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(80, 21);
            this.cbFormat.TabIndex = 11;
            // 
            // lbFormat
            // 
            this.lbFormat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbFormat.AutoSize = true;
            this.lbFormat.Location = new System.Drawing.Point(24, 150);
            this.lbFormat.Name = "lbFormat";
            this.lbFormat.Size = new System.Drawing.Size(47, 13);
            this.lbFormat.TabIndex = 10;
            this.lbFormat.Text = "lbFormat";
            // 
            // lbDownloadStatus
            // 
            this.lbDownloadStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbDownloadStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDownloadStatus.Location = new System.Drawing.Point(3, 268);
            this.lbDownloadStatus.Name = "lbDownloadStatus";
            this.lbDownloadStatus.Size = new System.Drawing.Size(238, 20);
            this.lbDownloadStatus.TabIndex = 15;
            this.lbDownloadStatus.Text = "waiting";
            this.lbDownloadStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDownloadStatus.Visible = false;
            // 
            // sbDownload
            // 
            this.sbDownload.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sbDownload.DropDownContextMenu = this.cmDownload;
            this.sbDownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sbDownload.Location = new System.Drawing.Point(81, 240);
            this.sbDownload.Name = "sbDownload";
            this.sbDownload.Size = new System.Drawing.Size(83, 25);
            this.sbDownload.TabIndex = 14;
            this.sbDownload.Text = "sbDownload";
            this.sbDownload.UseVisualStyleBackColor = true;
            this.sbDownload.Click += new System.EventHandler(this.sbDownload_Click);
            // 
            // cmDownload
            // 
            this.cmDownload.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mBatchDownloadFromFile});
            // 
            // mBatchDownloadFromFile
            // 
            this.mBatchDownloadFromFile.Index = 0;
            this.mBatchDownloadFromFile.Text = "mBatchDownloadFromFile";
            this.mBatchDownloadFromFile.Click += new System.EventHandler(this.mBatchDownloadFromFile_Click);
            // 
            // chkDownloadSound
            // 
            this.chkDownloadSound.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkDownloadSound.AutoSize = true;
            this.chkDownloadSound.Checked = true;
            this.chkDownloadSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDownloadSound.Location = new System.Drawing.Point(160, 120);
            this.chkDownloadSound.Name = "chkDownloadSound";
            this.chkDownloadSound.Size = new System.Drawing.Size(123, 17);
            this.chkDownloadSound.TabIndex = 9;
            this.chkDownloadSound.Text = "chkDownloadSound";
            this.chkDownloadSound.UseVisualStyleBackColor = true;
            this.chkDownloadSound.CheckedChanged += new System.EventHandler(this.chkDownloadSound_CheckedChanged);
            // 
            // cbQuality
            // 
            this.cbQuality.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuality.FormattingEnabled = true;
            this.cbQuality.Location = new System.Drawing.Point(74, 118);
            this.cbQuality.Name = "cbQuality";
            this.cbQuality.Size = new System.Drawing.Size(80, 21);
            this.cbQuality.TabIndex = 8;
            // 
            // lbQuality
            // 
            this.lbQuality.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbQuality.Location = new System.Drawing.Point(8, 121);
            this.lbQuality.Name = "lbQuality";
            this.lbQuality.Size = new System.Drawing.Size(63, 15);
            this.lbQuality.TabIndex = 7;
            this.lbQuality.Text = "lbQuality";
            this.lbQuality.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCustomArguments
            // 
            this.lbCustomArguments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbCustomArguments.AutoSize = true;
            this.lbCustomArguments.Location = new System.Drawing.Point(15, 196);
            this.lbCustomArguments.Name = "lbCustomArguments";
            this.lbCustomArguments.Size = new System.Drawing.Size(100, 13);
            this.lbCustomArguments.TabIndex = 12;
            this.lbCustomArguments.Text = "lbCustomArguments";
            // 
            // txtArgs
            // 
            this.txtArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArgs.Location = new System.Drawing.Point(22, 216);
            this.txtArgs.Name = "txtArgs";
            this.txtArgs.ReadOnly = true;
            this.txtArgs.Size = new System.Drawing.Size(200, 20);
            this.txtArgs.TabIndex = 13;
            this.txtArgs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArgs_KeyPress);
            // 
            // gbDownloadType
            // 
            this.gbDownloadType.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbDownloadType.Controls.Add(this.rbCustom);
            this.gbDownloadType.Controls.Add(this.rbAudio);
            this.gbDownloadType.Controls.Add(this.rbVideo);
            this.gbDownloadType.Location = new System.Drawing.Point(11, 70);
            this.gbDownloadType.Name = "gbDownloadType";
            this.gbDownloadType.Size = new System.Drawing.Size(225, 40);
            this.gbDownloadType.TabIndex = 3;
            this.gbDownloadType.TabStop = false;
            this.gbDownloadType.Text = "gbDownloadType";
            // 
            // rbCustom
            // 
            this.rbCustom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(151, 17);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(69, 17);
            this.rbCustom.TabIndex = 6;
            this.rbCustom.TabStop = true;
            this.rbCustom.Text = "rbCustom";
            this.rbCustom.UseVisualStyleBackColor = true;
            this.rbCustom.CheckedChanged += new System.EventHandler(this.rbCustom_CheckedChanged);
            // 
            // rbAudio
            // 
            this.rbAudio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbAudio.AutoSize = true;
            this.rbAudio.Location = new System.Drawing.Point(82, 17);
            this.rbAudio.Name = "rbAudio";
            this.rbAudio.Size = new System.Drawing.Size(61, 17);
            this.rbAudio.TabIndex = 5;
            this.rbAudio.TabStop = true;
            this.rbAudio.Text = "rbAudio";
            this.rbAudio.UseVisualStyleBackColor = true;
            this.rbAudio.CheckedChanged += new System.EventHandler(this.rbAudio_CheckedChanged);
            // 
            // rbVideo
            // 
            this.rbVideo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbVideo.AutoSize = true;
            this.rbVideo.Location = new System.Drawing.Point(8, 17);
            this.rbVideo.Name = "rbVideo";
            this.rbVideo.Size = new System.Drawing.Size(61, 17);
            this.rbVideo.TabIndex = 4;
            this.rbVideo.TabStop = true;
            this.rbVideo.Text = "rbVideo";
            this.rbVideo.UseVisualStyleBackColor = true;
            this.rbVideo.CheckedChanged += new System.EventHandler(this.rbVideo_CheckedChanged);
            // 
            // tabConvert
            // 
            this.tabConvert.Controls.Add(this.rbConvertCustom);
            this.tabConvert.Controls.Add(this.rbConvertAudio);
            this.tabConvert.Controls.Add(this.rbConvertAutoFFmpeg);
            this.tabConvert.Controls.Add(this.rbConvertAuto);
            this.tabConvert.Controls.Add(this.lbConvertStatus);
            this.tabConvert.Controls.Add(this.btnConvert);
            this.tabConvert.Controls.Add(this.rbConvertVideo);
            this.tabConvert.Controls.Add(this.btnConvertOutput);
            this.tabConvert.Controls.Add(this.lbConvertOutput);
            this.tabConvert.Controls.Add(this.txtConvertOutput);
            this.tabConvert.Controls.Add(this.btnConvertInput);
            this.tabConvert.Controls.Add(this.lbConvertInput);
            this.tabConvert.Controls.Add(this.txtConvertInput);
            this.tabConvert.Location = new System.Drawing.Point(4, 22);
            this.tabConvert.Name = "tabConvert";
            this.tabConvert.Padding = new System.Windows.Forms.Padding(3);
            this.tabConvert.Size = new System.Drawing.Size(244, 284);
            this.tabConvert.TabIndex = 1;
            this.tabConvert.Text = "tabConvert";
            this.tabConvert.UseVisualStyleBackColor = true;
            // 
            // rbConvertCustom
            // 
            this.rbConvertCustom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbConvertCustom.AutoSize = true;
            this.rbConvertCustom.Location = new System.Drawing.Point(151, 112);
            this.rbConvertCustom.Name = "rbConvertCustom";
            this.rbConvertCustom.Size = new System.Drawing.Size(106, 17);
            this.rbConvertCustom.TabIndex = 9;
            this.rbConvertCustom.TabStop = true;
            this.rbConvertCustom.Text = "rbConvertCustom";
            this.rbConvertCustom.UseVisualStyleBackColor = true;
            // 
            // rbConvertAudio
            // 
            this.rbConvertAudio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbConvertAudio.AutoSize = true;
            this.rbConvertAudio.Location = new System.Drawing.Point(94, 112);
            this.rbConvertAudio.Name = "rbConvertAudio";
            this.rbConvertAudio.Size = new System.Drawing.Size(98, 17);
            this.rbConvertAudio.TabIndex = 8;
            this.rbConvertAudio.TabStop = true;
            this.rbConvertAudio.Text = "rbConvertAudio";
            this.rbConvertAudio.UseVisualStyleBackColor = true;
            // 
            // rbConvertAutoFFmpeg
            // 
            this.rbConvertAutoFFmpeg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbConvertAutoFFmpeg.AutoSize = true;
            this.rbConvertAutoFFmpeg.Location = new System.Drawing.Point(120, 135);
            this.rbConvertAutoFFmpeg.Name = "rbConvertAutoFFmpeg";
            this.rbConvertAutoFFmpeg.Size = new System.Drawing.Size(131, 17);
            this.rbConvertAutoFFmpeg.TabIndex = 11;
            this.rbConvertAutoFFmpeg.TabStop = true;
            this.rbConvertAutoFFmpeg.Text = "rbConvertAutoFFmpeg";
            this.rbConvertAutoFFmpeg.UseVisualStyleBackColor = true;
            // 
            // rbConvertAuto
            // 
            this.rbConvertAuto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbConvertAuto.AutoSize = true;
            this.rbConvertAuto.Location = new System.Drawing.Point(43, 135);
            this.rbConvertAuto.Name = "rbConvertAuto";
            this.rbConvertAuto.Size = new System.Drawing.Size(93, 17);
            this.rbConvertAuto.TabIndex = 10;
            this.rbConvertAuto.TabStop = true;
            this.rbConvertAuto.Text = "rbConvertAuto";
            this.rbConvertAuto.UseVisualStyleBackColor = true;
            // 
            // lbConvertStatus
            // 
            this.lbConvertStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbConvertStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConvertStatus.Location = new System.Drawing.Point(3, 259);
            this.lbConvertStatus.Name = "lbConvertStatus";
            this.lbConvertStatus.Size = new System.Drawing.Size(238, 22);
            this.lbConvertStatus.TabIndex = 13;
            this.lbConvertStatus.Text = "waiting";
            this.lbConvertStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbConvertStatus.Visible = false;
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(83, 170);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(79, 25);
            this.btnConvert.TabIndex = 12;
            this.btnConvert.Text = "btnConvert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // rbConvertVideo
            // 
            this.rbConvertVideo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbConvertVideo.AutoSize = true;
            this.rbConvertVideo.Location = new System.Drawing.Point(35, 112);
            this.rbConvertVideo.Name = "rbConvertVideo";
            this.rbConvertVideo.Size = new System.Drawing.Size(98, 17);
            this.rbConvertVideo.TabIndex = 7;
            this.rbConvertVideo.TabStop = true;
            this.rbConvertVideo.Text = "rbConvertVideo";
            this.rbConvertVideo.UseVisualStyleBackColor = true;
            // 
            // btnConvertOutput
            // 
            this.btnConvertOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertOutput.Enabled = false;
            this.btnConvertOutput.Location = new System.Drawing.Point(193, 72);
            this.btnConvertOutput.Name = "btnConvertOutput";
            this.btnConvertOutput.Size = new System.Drawing.Size(29, 23);
            this.btnConvertOutput.TabIndex = 6;
            this.btnConvertOutput.Text = "...";
            this.btnConvertOutput.UseVisualStyleBackColor = true;
            this.btnConvertOutput.Click += new System.EventHandler(this.btnConvertOutput_Click);
            // 
            // lbConvertOutput
            // 
            this.lbConvertOutput.AutoSize = true;
            this.lbConvertOutput.Location = new System.Drawing.Point(19, 54);
            this.lbConvertOutput.Name = "lbConvertOutput";
            this.lbConvertOutput.Size = new System.Drawing.Size(84, 13);
            this.lbConvertOutput.TabIndex = 4;
            this.lbConvertOutput.Text = "lbConvertOutput";
            // 
            // txtConvertOutput
            // 
            this.txtConvertOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConvertOutput.Location = new System.Drawing.Point(26, 74);
            this.txtConvertOutput.Name = "txtConvertOutput";
            this.txtConvertOutput.ReadOnly = true;
            this.txtConvertOutput.Size = new System.Drawing.Size(161, 20);
            this.txtConvertOutput.TabIndex = 5;
            // 
            // btnConvertInput
            // 
            this.btnConvertInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertInput.Location = new System.Drawing.Point(193, 25);
            this.btnConvertInput.Name = "btnConvertInput";
            this.btnConvertInput.Size = new System.Drawing.Size(29, 23);
            this.btnConvertInput.TabIndex = 3;
            this.btnConvertInput.Text = "...";
            this.btnConvertInput.UseVisualStyleBackColor = true;
            this.btnConvertInput.Click += new System.EventHandler(this.btnConvertInput_Click);
            // 
            // lbConvertInput
            // 
            this.lbConvertInput.AutoSize = true;
            this.lbConvertInput.Location = new System.Drawing.Point(19, 7);
            this.lbConvertInput.Name = "lbConvertInput";
            this.lbConvertInput.Size = new System.Drawing.Size(76, 13);
            this.lbConvertInput.TabIndex = 1;
            this.lbConvertInput.Text = "lbConvertInput";
            // 
            // txtConvertInput
            // 
            this.txtConvertInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConvertInput.Location = new System.Drawing.Point(26, 27);
            this.txtConvertInput.Name = "txtConvertInput";
            this.txtConvertInput.ReadOnly = true;
            this.txtConvertInput.Size = new System.Drawing.Size(161, 20);
            this.txtConvertInput.TabIndex = 2;
            // 
            // tabMerge
            // 
            this.tabMerge.Controls.Add(this.chkMergeDeleteInputFiles);
            this.tabMerge.Controls.Add(this.chkMergeAudioTracks);
            this.tabMerge.Controls.Add(this.btnMerge);
            this.tabMerge.Controls.Add(this.btnBrwsMergeOutput);
            this.tabMerge.Controls.Add(this.txtMergeOutput);
            this.tabMerge.Controls.Add(this.lbMergeOutput);
            this.tabMerge.Controls.Add(this.btnBrwsMergeInput2);
            this.tabMerge.Controls.Add(this.txtMergeInput2);
            this.tabMerge.Controls.Add(this.btnBrwsMergeInput1);
            this.tabMerge.Controls.Add(this.txtMergeInput1);
            this.tabMerge.Controls.Add(this.lbMergeInput2);
            this.tabMerge.Controls.Add(this.lbMergeInput1);
            this.tabMerge.Location = new System.Drawing.Point(4, 22);
            this.tabMerge.Name = "tabMerge";
            this.tabMerge.Padding = new System.Windows.Forms.Padding(3);
            this.tabMerge.Size = new System.Drawing.Size(244, 284);
            this.tabMerge.TabIndex = 2;
            this.tabMerge.Text = "tabMerge";
            this.tabMerge.UseVisualStyleBackColor = true;
            // 
            // chkMergeDeleteInputFiles
            // 
            this.chkMergeDeleteInputFiles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkMergeDeleteInputFiles.AutoSize = true;
            this.chkMergeDeleteInputFiles.Location = new System.Drawing.Point(64, 180);
            this.chkMergeDeleteInputFiles.Name = "chkMergeDeleteInputFiles";
            this.chkMergeDeleteInputFiles.Size = new System.Drawing.Size(150, 17);
            this.chkMergeDeleteInputFiles.TabIndex = 11;
            this.chkMergeDeleteInputFiles.Text = "chkMergeDeleteInputFiles";
            this.chkMergeDeleteInputFiles.UseVisualStyleBackColor = true;
            // 
            // chkMergeAudioTracks
            // 
            this.chkMergeAudioTracks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkMergeAudioTracks.AutoSize = true;
            this.chkMergeAudioTracks.Checked = true;
            this.chkMergeAudioTracks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMergeAudioTracks.Location = new System.Drawing.Point(64, 157);
            this.chkMergeAudioTracks.Name = "chkMergeAudioTracks";
            this.chkMergeAudioTracks.Size = new System.Drawing.Size(134, 17);
            this.chkMergeAudioTracks.TabIndex = 10;
            this.chkMergeAudioTracks.Text = "chkMergeAudioTracks";
            this.chkMergeAudioTracks.UseVisualStyleBackColor = true;
            // 
            // btnMerge
            // 
            this.btnMerge.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMerge.Enabled = false;
            this.btnMerge.Location = new System.Drawing.Point(83, 210);
            this.btnMerge.Name = "btnMerge";
            this.btnMerge.Size = new System.Drawing.Size(79, 25);
            this.btnMerge.TabIndex = 12;
            this.btnMerge.Text = "btnMerge";
            this.btnMerge.UseVisualStyleBackColor = true;
            this.btnMerge.Click += new System.EventHandler(this.btnMerge_Click);
            // 
            // btnBrwsMergeOutput
            // 
            this.btnBrwsMergeOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrwsMergeOutput.Enabled = false;
            this.btnBrwsMergeOutput.Location = new System.Drawing.Point(193, 119);
            this.btnBrwsMergeOutput.Name = "btnBrwsMergeOutput";
            this.btnBrwsMergeOutput.Size = new System.Drawing.Size(29, 23);
            this.btnBrwsMergeOutput.TabIndex = 9;
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
            this.txtMergeOutput.TabIndex = 8;
            // 
            // lbMergeOutput
            // 
            this.lbMergeOutput.AutoSize = true;
            this.lbMergeOutput.Location = new System.Drawing.Point(19, 101);
            this.lbMergeOutput.Name = "lbMergeOutput";
            this.lbMergeOutput.Size = new System.Drawing.Size(77, 13);
            this.lbMergeOutput.TabIndex = 7;
            this.lbMergeOutput.Text = "lbMergeOutput";
            // 
            // btnBrwsMergeInput2
            // 
            this.btnBrwsMergeInput2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrwsMergeInput2.Enabled = false;
            this.btnBrwsMergeInput2.Location = new System.Drawing.Point(193, 72);
            this.btnBrwsMergeInput2.Name = "btnBrwsMergeInput2";
            this.btnBrwsMergeInput2.Size = new System.Drawing.Size(29, 23);
            this.btnBrwsMergeInput2.TabIndex = 6;
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
            this.txtMergeInput2.TabIndex = 5;
            // 
            // btnBrwsMergeInput1
            // 
            this.btnBrwsMergeInput1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrwsMergeInput1.Location = new System.Drawing.Point(193, 25);
            this.btnBrwsMergeInput1.Name = "btnBrwsMergeInput1";
            this.btnBrwsMergeInput1.Size = new System.Drawing.Size(29, 23);
            this.btnBrwsMergeInput1.TabIndex = 3;
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
            this.txtMergeInput1.TabIndex = 2;
            // 
            // lbMergeInput2
            // 
            this.lbMergeInput2.AutoSize = true;
            this.lbMergeInput2.Location = new System.Drawing.Point(19, 54);
            this.lbMergeInput2.Name = "lbMergeInput2";
            this.lbMergeInput2.Size = new System.Drawing.Size(75, 13);
            this.lbMergeInput2.TabIndex = 4;
            this.lbMergeInput2.Text = "lbMergeInput2";
            // 
            // lbMergeInput1
            // 
            this.lbMergeInput1.AutoSize = true;
            this.lbMergeInput1.Location = new System.Drawing.Point(19, 7);
            this.lbMergeInput1.Name = "lbMergeInput1";
            this.lbMergeInput1.Size = new System.Drawing.Size(75, 13);
            this.lbMergeInput1.TabIndex = 1;
            this.lbMergeInput1.Text = "lbMergeInput1";
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.btnDebugDownloadArgs);
            this.tabDebug.Controls.Add(this.btnDebugForceAvailableUpdate);
            this.tabDebug.Controls.Add(this.btnDebugForceUpdateCheck);
            this.tabDebug.Location = new System.Drawing.Point(4, 22);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabDebug.Size = new System.Drawing.Size(244, 284);
            this.tabDebug.TabIndex = 3;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // btnDebugDownloadArgs
            // 
            this.btnDebugDownloadArgs.Location = new System.Drawing.Point(8, 66);
            this.btnDebugDownloadArgs.Name = "btnDebugDownloadArgs";
            this.btnDebugDownloadArgs.Size = new System.Drawing.Size(123, 23);
            this.btnDebugDownloadArgs.TabIndex = 2;
            this.btnDebugDownloadArgs.Text = "Debug download args";
            this.btnDebugDownloadArgs.UseVisualStyleBackColor = true;
            this.btnDebugDownloadArgs.Click += new System.EventHandler(this.btnDebugDownloadArgs_Click);
            // 
            // btnDebugForceAvailableUpdate
            // 
            this.btnDebugForceAvailableUpdate.Location = new System.Drawing.Point(8, 36);
            this.btnDebugForceAvailableUpdate.Name = "btnDebugForceAvailableUpdate";
            this.btnDebugForceAvailableUpdate.Size = new System.Drawing.Size(123, 24);
            this.btnDebugForceAvailableUpdate.TabIndex = 1;
            this.btnDebugForceAvailableUpdate.Text = "Force update available";
            this.btnDebugForceAvailableUpdate.UseVisualStyleBackColor = true;
            this.btnDebugForceAvailableUpdate.Click += new System.EventHandler(this.btnDebugForceAvailableUpdate_Click);
            // 
            // btnDebugForceUpdateCheck
            // 
            this.btnDebugForceUpdateCheck.Location = new System.Drawing.Point(8, 6);
            this.btnDebugForceUpdateCheck.Name = "btnDebugForceUpdateCheck";
            this.btnDebugForceUpdateCheck.Size = new System.Drawing.Size(123, 24);
            this.btnDebugForceUpdateCheck.TabIndex = 0;
            this.btnDebugForceUpdateCheck.Text = "Force update check";
            this.btnDebugForceUpdateCheck.UseVisualStyleBackColor = true;
            this.btnDebugForceUpdateCheck.Click += new System.EventHandler(this.btnDebugForceUpdateCheck_Click);
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
            this.mSettings.Text = "mSettings";
            this.mSettings.Click += new System.EventHandler(this.mSettings_Click);
            // 
            // mTools
            // 
            this.mTools.Index = 1;
            this.mTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mBatchDownload,
            this.mDownloadSubtitles,
            this.mMiscTools});
            this.mTools.Text = "mTools";
            // 
            // mBatchDownload
            // 
            this.mBatchDownload.Index = 0;
            this.mBatchDownload.Text = "mBatchDownload";
            this.mBatchDownload.Click += new System.EventHandler(this.mBatchDownload_Click);
            // 
            // mDownloadSubtitles
            // 
            this.mDownloadSubtitles.Index = 1;
            this.mDownloadSubtitles.Text = "mDownloadSubtitles";
            this.mDownloadSubtitles.Click += new System.EventHandler(this.mDownloadSubtitles_Click);
            // 
            // mMiscTools
            // 
            this.mMiscTools.Index = 2;
            this.mMiscTools.Text = "mMiscTools";
            this.mMiscTools.Click += new System.EventHandler(this.mMiscTools_Click);
            // 
            // mHelp
            // 
            this.mHelp.Index = 2;
            this.mHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mLanguage,
            this.mSupportedSites});
            this.mHelp.Text = "mHelp";
            // 
            // mLanguage
            // 
            this.mLanguage.Index = 0;
            this.mLanguage.Text = "mLanguage";
            this.mLanguage.Click += new System.EventHandler(this.mLanguage_Click);
            // 
            // mSupportedSites
            // 
            this.mSupportedSites.Index = 1;
            this.mSupportedSites.Text = "mSupportedSites";
            this.mSupportedSites.Click += new System.EventHandler(this.mSupportedSites_Click);
            // 
            // mAbout
            // 
            this.mAbout.Index = 3;
            this.mAbout.Text = "mAbout";
            this.mAbout.Click += new System.EventHandler(this.mAbout_Click);
            // 
            // lbDebug
            // 
            this.lbDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDebug.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDebug.Location = new System.Drawing.Point(81, 274);
            this.lbDebug.Name = "lbDebug";
            this.lbDebug.Size = new System.Drawing.Size(168, 19);
            this.lbDebug.TabIndex = 3;
            this.lbDebug.Text = "debug 2019-07-24";
            this.lbDebug.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbDebug.Visible = false;
            // 
            // cmTray
            // 
            this.cmTray.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmTrayShowForm,
            this.cmTrayDownloader,
            this.cmTrayConverter,
            this.cmTraySep,
            this.cmTrayExit});
            // 
            // cmTrayShowForm
            // 
            this.cmTrayShowForm.Index = 0;
            this.cmTrayShowForm.Text = "cmTrayShow";
            this.cmTrayShowForm.Click += new System.EventHandler(this.cmTrayShowForm_Click);
            // 
            // cmTrayDownloader
            // 
            this.cmTrayDownloader.Index = 1;
            this.cmTrayDownloader.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmTrayDownloadClipboard});
            this.cmTrayDownloader.Text = "cmTrayDownloader";
            // 
            // cmTrayDownloadClipboard
            // 
            this.cmTrayDownloadClipboard.Index = 0;
            this.cmTrayDownloadClipboard.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmTrayDownloadBestVideo,
            this.cmTrayDownloadBestAudio,
            this.cmTrayDownloadCustom});
            this.cmTrayDownloadClipboard.Text = "cmTrayDownloadClipboard";
            // 
            // cmTrayDownloadBestVideo
            // 
            this.cmTrayDownloadBestVideo.Index = 0;
            this.cmTrayDownloadBestVideo.Text = "cmTrayDownloadBestVideo";
            this.cmTrayDownloadBestVideo.Click += new System.EventHandler(this.cmTrayDownloadBestVideo_Click);
            // 
            // cmTrayDownloadBestAudio
            // 
            this.cmTrayDownloadBestAudio.Index = 1;
            this.cmTrayDownloadBestAudio.Text = "cmTrayDownloadBestAudio";
            this.cmTrayDownloadBestAudio.Click += new System.EventHandler(this.cmTrayDownloadBestAudio_Click);
            // 
            // cmTrayDownloadCustom
            // 
            this.cmTrayDownloadCustom.Index = 2;
            this.cmTrayDownloadCustom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmTrayDownloadCustomTxtBox,
            this.cmTrayCustomSep,
            this.cmTrayDownloadCustomTxt,
            this.cmTrayDownloadCustomSettings});
            this.cmTrayDownloadCustom.Text = "cmTrayDownloadCustom";
            // 
            // cmTrayDownloadCustomTxtBox
            // 
            this.cmTrayDownloadCustomTxtBox.Index = 0;
            this.cmTrayDownloadCustomTxtBox.Text = "cmTrayDownloadCustomTxtBox";
            this.cmTrayDownloadCustomTxtBox.Click += new System.EventHandler(this.cmTrayDownloadCustomTxtBox_Click);
            // 
            // cmTrayCustomSep
            // 
            this.cmTrayCustomSep.Index = 1;
            this.cmTrayCustomSep.Text = "-";
            // 
            // cmTrayDownloadCustomTxt
            // 
            this.cmTrayDownloadCustomTxt.Index = 2;
            this.cmTrayDownloadCustomTxt.Text = "cmTrayDownloadCustomTxt";
            this.cmTrayDownloadCustomTxt.Click += new System.EventHandler(this.cmTrayDownloadCustomTxt_Click);
            // 
            // cmTrayDownloadCustomSettings
            // 
            this.cmTrayDownloadCustomSettings.Index = 3;
            this.cmTrayDownloadCustomSettings.Text = "cmTrayDownloadCustomSettings";
            this.cmTrayDownloadCustomSettings.Click += new System.EventHandler(this.cmTrayDownloadCustomSettings_Click);
            // 
            // cmTrayConverter
            // 
            this.cmTrayConverter.Index = 2;
            this.cmTrayConverter.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmTrayConvertTo});
            this.cmTrayConverter.Text = "cmTrayConverter";
            // 
            // cmTrayConvertTo
            // 
            this.cmTrayConvertTo.Index = 0;
            this.cmTrayConvertTo.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmTrayConvertVideo,
            this.cmTrayConvertAudio,
            this.cmTrayConvertCustom,
            this.cmTrayConvertAutomatic,
            this.cmTrayConvertAutoFFmpeg});
            this.cmTrayConvertTo.Text = "cmTrayConvertTo";
            // 
            // cmTrayConvertVideo
            // 
            this.cmTrayConvertVideo.Index = 0;
            this.cmTrayConvertVideo.Text = "cmTrayConvertVideo";
            this.cmTrayConvertVideo.Click += new System.EventHandler(this.cmTrayConvertVideo_Click);
            // 
            // cmTrayConvertAudio
            // 
            this.cmTrayConvertAudio.Index = 1;
            this.cmTrayConvertAudio.Text = "cmTrayConvertAudio";
            this.cmTrayConvertAudio.Click += new System.EventHandler(this.cmTrayConvertAudio_Click);
            // 
            // cmTrayConvertCustom
            // 
            this.cmTrayConvertCustom.Index = 2;
            this.cmTrayConvertCustom.Text = "cmTrayConvertCustom";
            this.cmTrayConvertCustom.Click += new System.EventHandler(this.cmTrayConvertCustom_Click);
            // 
            // cmTrayConvertAutomatic
            // 
            this.cmTrayConvertAutomatic.Index = 3;
            this.cmTrayConvertAutomatic.Text = "cmTrayConvertAutomatic";
            this.cmTrayConvertAutomatic.Click += new System.EventHandler(this.cmTrayConvertAutomatic_Click);
            // 
            // cmTrayConvertAutoFFmpeg
            // 
            this.cmTrayConvertAutoFFmpeg.Index = 4;
            this.cmTrayConvertAutoFFmpeg.Text = "cmTrayConvertAutoFFmpeg";
            this.cmTrayConvertAutoFFmpeg.Click += new System.EventHandler(this.cmTrayConvertAutoFFmpeg_Click);
            // 
            // cmTraySep
            // 
            this.cmTraySep.Index = 3;
            this.cmTraySep.Text = "-";
            // 
            // cmTrayExit
            // 
            this.cmTrayExit.Index = 4;
            this.cmTrayExit.Text = "cmTrayExit";
            this.cmTrayExit.Click += new System.EventHandler(this.cmTrayExit_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.BalloonTipText = "You click this thing, and BADA-BOOM, you\'re back in it again";
            this.trayIcon.BalloonTipTitle = "Unseen easter egg";
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
            this.ClientSize = new System.Drawing.Size(252, 301);
            this.Controls.Add(this.lbDebug);
            this.Controls.Add(this.tcMain);
            this.MaximizeBox = false;
            this.Menu = this.menu;
            this.MinimumSize = new System.Drawing.Size(260, 340);
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
            this.tabDebug.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label lbURL;
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
        private System.Windows.Forms.Label lbCustomArguments;
        private System.Windows.Forms.TextBox txtArgs;
        private System.Windows.Forms.MenuItem mAbout;
        private System.Windows.Forms.ContextMenu cmTray;
        private System.Windows.Forms.MenuItem cmTrayShowForm;
        private System.Windows.Forms.MenuItem cmTrayDownloadClipboard;
        private System.Windows.Forms.MenuItem cmTrayDownloadBestAudio;
        private System.Windows.Forms.MenuItem cmTrayDownloadBestVideo;
        private System.Windows.Forms.MenuItem cmTrayDownloadCustom;
        private System.Windows.Forms.MenuItem cmTrayDownloadCustomTxtBox;
        private System.Windows.Forms.MenuItem cmTrayCustomSep;
        private System.Windows.Forms.MenuItem cmTrayDownloadCustomTxt;
        private System.Windows.Forms.MenuItem cmTrayDownloadCustomSettings;
        private System.Windows.Forms.MenuItem cmTraySep;
        private System.Windows.Forms.MenuItem cmTrayExit;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.MenuItem mSupportedSites;
        private System.Windows.Forms.Button btnConvertOutput;
        private System.Windows.Forms.Label lbConvertOutput;
        private System.Windows.Forms.TextBox txtConvertOutput;
        private System.Windows.Forms.Button btnConvertInput;
        private System.Windows.Forms.Label lbConvertInput;
        private System.Windows.Forms.TextBox txtConvertInput;
        private System.Windows.Forms.RadioButton rbConvertAudio;
        private System.Windows.Forms.RadioButton rbConvertVideo;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label lbConvertStatus;
        private System.Windows.Forms.Timer tmrConvertLabel;
        private System.Windows.Forms.RadioButton rbConvertAuto;
        private System.Windows.Forms.RadioButton rbConvertAutoFFmpeg;
        private System.Windows.Forms.RadioButton rbConvertCustom;
        private System.Windows.Forms.MenuItem cmTrayDownloader;
        private System.Windows.Forms.MenuItem cmTrayConverter;
        private System.Windows.Forms.MenuItem cmTrayConvertTo;
        private System.Windows.Forms.MenuItem cmTrayConvertVideo;
        private System.Windows.Forms.MenuItem cmTrayConvertAudio;
        private System.Windows.Forms.MenuItem cmTrayConvertCustom;
        private System.Windows.Forms.MenuItem cmTrayConvertAutomatic;
        private System.Windows.Forms.MenuItem cmTrayConvertAutoFFmpeg;
        private System.Windows.Forms.TabPage tabMerge;
        private System.Windows.Forms.Label lbDownloadStatus;
        private System.Windows.Forms.Timer tmrDownloadLabel;
        private System.Windows.Forms.ComboBox cbQuality;
        private System.Windows.Forms.Label lbQuality;
        private System.Windows.Forms.Button btnMerge;
        private System.Windows.Forms.Button btnBrwsMergeOutput;
        private System.Windows.Forms.TextBox txtMergeOutput;
        private System.Windows.Forms.Label lbMergeOutput;
        private System.Windows.Forms.Button btnBrwsMergeInput2;
        private System.Windows.Forms.TextBox txtMergeInput2;
        private System.Windows.Forms.Button btnBrwsMergeInput1;
        private System.Windows.Forms.TextBox txtMergeInput1;
        private System.Windows.Forms.Label lbMergeInput2;
        private System.Windows.Forms.Label lbMergeInput1;
        private System.Windows.Forms.CheckBox chkMergeAudioTracks;
        private System.Windows.Forms.CheckBox chkMergeDeleteInputFiles;
        private System.Windows.Forms.CheckBox chkDownloadSound;
        private System.Windows.Forms.MenuItem mTools;
        private System.Windows.Forms.MenuItem mBatchDownload;
        private System.Windows.Forms.MenuItem mMiscTools;
        private System.Windows.Forms.MenuItem mDownloadSubtitles;
        private SplitButton sbDownload;
        private System.Windows.Forms.ContextMenu cmDownload;
        private System.Windows.Forms.MenuItem mBatchDownloadFromFile;
        private System.Windows.Forms.MenuItem mLanguage;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.Button btnDebugForceUpdateCheck;
        private System.Windows.Forms.Button btnDebugForceAvailableUpdate;
        private System.Windows.Forms.Button btnDebugDownloadArgs;
        private System.Windows.Forms.ComboBox cbFormat;
        private System.Windows.Forms.Label lbFormat;
    }
}

