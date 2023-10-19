namespace youtube_dl_gui;

partial class frmExtendedConverter {
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpVideoStreams = new System.Windows.Forms.TabPage();
            this.lvVideoStreams = new murrty.controls.ExtendedListView();
            this.chVideoIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoCodec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chVideoDisplay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnVideoOptions = new System.Windows.Forms.Panel();
            this.chkSetVideoQuality = new System.Windows.Forms.CheckBox();
            this.cbVideoProfile = new System.Windows.Forms.ComboBox();
            this.cbVideoPreset = new System.Windows.Forms.ComboBox();
            this.chkVideoFaststart = new System.Windows.Forms.CheckBox();
            this.chkVideoUseCRF = new System.Windows.Forms.CheckBox();
            this.numVideoBitrate = new System.Windows.Forms.NumericUpDown();
            this.lbVideoBitrate = new System.Windows.Forms.Label();
            this.cbVideoCRF = new System.Windows.Forms.ComboBox();
            this.chkVideoSetPreset = new System.Windows.Forms.CheckBox();
            this.chkVideoSetProfile = new System.Windows.Forms.CheckBox();
            this.tpAudioStreams = new System.Windows.Forms.TabPage();
            this.lvAudioStreams = new murrty.controls.ExtendedListView();
            this.chAudioIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudioTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudioCodec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudioBitrate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAudioSamplingRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnAudioSettings = new System.Windows.Forms.Panel();
            this.chkSetAudioQuality = new System.Windows.Forms.CheckBox();
            this.chkAudioUseVBR = new System.Windows.Forms.CheckBox();
            this.numAudioBitrate = new System.Windows.Forms.NumericUpDown();
            this.lbAudioBitrate = new System.Windows.Forms.Label();
            this.cbAudioVBR = new System.Windows.Forms.ComboBox();
            this.tpSubtitles = new System.Windows.Forms.TabPage();
            this.lvSubtitles = new murrty.controls.ExtendedListView();
            this.chSubtitleIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSubtitleTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSubtitleLanguage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSubtitleFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpAttachments = new System.Windows.Forms.TabPage();
            this.lvAttachments = new murrty.controls.ExtendedListView();
            this.chAttachmentIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAttachmentTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAttachmentCodec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpData = new System.Windows.Forms.TabPage();
            this.lvData = new murrty.controls.ExtendedListView();
            this.chDataIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDataTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tpEndingTime = new murrty.controls.TimePicker();
            this.tpStartingTime = new murrty.controls.TimePicker();
            this.txtOutput = new murrty.controls.ExtendedTextBox();
            this.txtInput = new murrty.controls.ExtendedTextBox();
            this.chkRemoveMetadata = new System.Windows.Forms.CheckBox();
            this.chkHideFfmpegMetadata = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGeneratedArgs = new System.Windows.Forms.TextBox();
            this.btnDebugGenerateArgs = new System.Windows.Forms.Button();
            this.chkCopyCodecs = new System.Windows.Forms.CheckBox();
            this.chkSelectOutputOnOk = new System.Windows.Forms.CheckBox();
            this.cbAudioSampleRate = new System.Windows.Forms.ComboBox();
            this.chkAudioSampleRate = new System.Windows.Forms.CheckBox();
            this.tcMain.SuspendLayout();
            this.tpVideoStreams.SuspendLayout();
            this.pnVideoOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVideoBitrate)).BeginInit();
            this.tpAudioStreams.SuspendLayout();
            this.pnAudioSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAudioBitrate)).BeginInit();
            this.tpSubtitles.SuspendLayout();
            this.tpAttachments.SuspendLayout();
            this.tpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 324);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "starting time";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "ending time";
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConvert.Location = new System.Drawing.Point(180, 374);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 23);
            this.btnConvert.TabIndex = 7;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tpVideoStreams);
            this.tcMain.Controls.Add(this.tpAudioStreams);
            this.tcMain.Controls.Add(this.tpSubtitles);
            this.tcMain.Controls.Add(this.tpAttachments);
            this.tcMain.Controls.Add(this.tpData);
            this.tcMain.Location = new System.Drawing.Point(12, 64);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(413, 212);
            this.tcMain.TabIndex = 8;
            // 
            // tpVideoStreams
            // 
            this.tpVideoStreams.Controls.Add(this.lvVideoStreams);
            this.tpVideoStreams.Controls.Add(this.pnVideoOptions);
            this.tpVideoStreams.Location = new System.Drawing.Point(4, 22);
            this.tpVideoStreams.Name = "tpVideoStreams";
            this.tpVideoStreams.Padding = new System.Windows.Forms.Padding(3);
            this.tpVideoStreams.Size = new System.Drawing.Size(405, 186);
            this.tpVideoStreams.TabIndex = 0;
            this.tpVideoStreams.Text = "Video streams";
            this.tpVideoStreams.UseVisualStyleBackColor = true;
            // 
            // lvVideoStreams
            // 
            this.lvVideoStreams.CheckBoxes = true;
            this.lvVideoStreams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chVideoIndex,
            this.chVideoTitle,
            this.chVideoCodec,
            this.chVideoDisplay});
            this.lvVideoStreams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvVideoStreams.FullRowSelect = true;
            this.lvVideoStreams.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvVideoStreams.HideSelection = false;
            this.lvVideoStreams.Location = new System.Drawing.Point(3, 3);
            this.lvVideoStreams.MultiSelect = false;
            this.lvVideoStreams.Name = "lvVideoStreams";
            this.lvVideoStreams.Size = new System.Drawing.Size(399, 122);
            this.lvVideoStreams.TabIndex = 0;
            this.lvVideoStreams.UseCompatibleStateImageBehavior = false;
            this.lvVideoStreams.View = System.Windows.Forms.View.Details;
            // 
            // chVideoIndex
            // 
            this.chVideoIndex.Text = "#";
            this.chVideoIndex.Width = 35;
            // 
            // chVideoTitle
            // 
            this.chVideoTitle.Text = "Title";
            this.chVideoTitle.Width = 67;
            // 
            // chVideoCodec
            // 
            this.chVideoCodec.Text = "Codec";
            this.chVideoCodec.Width = 116;
            // 
            // chVideoDisplay
            // 
            this.chVideoDisplay.Text = "Display";
            this.chVideoDisplay.Width = 174;
            // 
            // pnVideoOptions
            // 
            this.pnVideoOptions.Controls.Add(this.chkSetVideoQuality);
            this.pnVideoOptions.Controls.Add(this.cbVideoProfile);
            this.pnVideoOptions.Controls.Add(this.cbVideoPreset);
            this.pnVideoOptions.Controls.Add(this.chkVideoFaststart);
            this.pnVideoOptions.Controls.Add(this.chkVideoUseCRF);
            this.pnVideoOptions.Controls.Add(this.numVideoBitrate);
            this.pnVideoOptions.Controls.Add(this.lbVideoBitrate);
            this.pnVideoOptions.Controls.Add(this.cbVideoCRF);
            this.pnVideoOptions.Controls.Add(this.chkVideoSetPreset);
            this.pnVideoOptions.Controls.Add(this.chkVideoSetProfile);
            this.pnVideoOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnVideoOptions.Location = new System.Drawing.Point(3, 125);
            this.pnVideoOptions.Name = "pnVideoOptions";
            this.pnVideoOptions.Size = new System.Drawing.Size(399, 58);
            this.pnVideoOptions.TabIndex = 1;
            // 
            // chkSetVideoQuality
            // 
            this.chkSetVideoQuality.AutoSize = true;
            this.chkSetVideoQuality.Location = new System.Drawing.Point(9, 12);
            this.chkSetVideoQuality.Name = "chkSetVideoQuality";
            this.chkSetVideoQuality.Size = new System.Drawing.Size(14, 13);
            this.chkSetVideoQuality.TabIndex = 20;
            this.chkSetVideoQuality.UseVisualStyleBackColor = true;
            this.chkSetVideoQuality.CheckedChanged += new System.EventHandler(this.chkSetVideoQuality_CheckedChanged);
            // 
            // cbVideoProfile
            // 
            this.cbVideoProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVideoProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoProfile.Enabled = false;
            this.cbVideoProfile.FormattingEnabled = true;
            this.cbVideoProfile.Items.AddRange(new object[] {
            "baseline",
            "main",
            "high",
            "high10",
            "high442",
            "high444"});
            this.cbVideoProfile.Location = new System.Drawing.Point(299, 34);
            this.cbVideoProfile.Name = "cbVideoProfile";
            this.cbVideoProfile.Size = new System.Drawing.Size(94, 21);
            this.cbVideoProfile.TabIndex = 17;
            // 
            // cbVideoPreset
            // 
            this.cbVideoPreset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVideoPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoPreset.Enabled = false;
            this.cbVideoPreset.FormattingEnabled = true;
            this.cbVideoPreset.Items.AddRange(new object[] {
            "ultrafast",
            "superfast",
            "veryfast",
            "faster",
            "fast",
            "medium",
            "slow",
            "slower",
            "veryslow"});
            this.cbVideoPreset.Location = new System.Drawing.Point(299, 7);
            this.cbVideoPreset.Name = "cbVideoPreset";
            this.cbVideoPreset.Size = new System.Drawing.Size(94, 21);
            this.cbVideoPreset.TabIndex = 16;
            // 
            // chkVideoFaststart
            // 
            this.chkVideoFaststart.AutoSize = true;
            this.chkVideoFaststart.Location = new System.Drawing.Point(8, 37);
            this.chkVideoFaststart.Name = "chkVideoFaststart";
            this.chkVideoFaststart.Size = new System.Drawing.Size(92, 17);
            this.chkVideoFaststart.TabIndex = 15;
            this.chkVideoFaststart.Text = "Faststart flag";
            this.chkVideoFaststart.UseVisualStyleBackColor = true;
            // 
            // chkVideoUseCRF
            // 
            this.chkVideoUseCRF.AutoSize = true;
            this.chkVideoUseCRF.Enabled = false;
            this.chkVideoUseCRF.Location = new System.Drawing.Point(125, 10);
            this.chkVideoUseCRF.Name = "chkVideoUseCRF";
            this.chkVideoUseCRF.Size = new System.Drawing.Size(67, 17);
            this.chkVideoUseCRF.TabIndex = 7;
            this.chkVideoUseCRF.Text = "Use CRF";
            this.chkVideoUseCRF.UseVisualStyleBackColor = true;
            this.chkVideoUseCRF.CheckedChanged += new System.EventHandler(this.chkVideoUseCRF_CheckedChanged);
            // 
            // numVideoBitrate
            // 
            this.numVideoBitrate.Enabled = false;
            this.numVideoBitrate.Location = new System.Drawing.Point(27, 8);
            this.numVideoBitrate.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numVideoBitrate.Name = "numVideoBitrate";
            this.numVideoBitrate.Size = new System.Drawing.Size(79, 22);
            this.numVideoBitrate.TabIndex = 5;
            this.numVideoBitrate.ThousandsSeparator = true;
            this.numVideoBitrate.Value = new decimal(new int[] {
            7500,
            0,
            0,
            0});
            // 
            // lbVideoBitrate
            // 
            this.lbVideoBitrate.AutoSize = true;
            this.lbVideoBitrate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVideoBitrate.Location = new System.Drawing.Point(104, 9);
            this.lbVideoBitrate.Name = "lbVideoBitrate";
            this.lbVideoBitrate.Size = new System.Drawing.Size(16, 17);
            this.lbVideoBitrate.TabIndex = 6;
            this.lbVideoBitrate.Text = "K";
            // 
            // cbVideoCRF
            // 
            this.cbVideoCRF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVideoCRF.Enabled = false;
            this.cbVideoCRF.FormattingEnabled = true;
            this.cbVideoCRF.Items.AddRange(new object[] {
            "0 (x264) (BEST)",
            "1 (x264)",
            "2 (x264)",
            "3 (x264)",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10 (VPx avg)",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18 (x264 avg)",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52 (VPx)",
            "53 (VPx)",
            "54 (VPx)",
            "55 (VPx)",
            "56 (VPx)",
            "57 (VPx)",
            "58 (VPx)",
            "59 (VPx)",
            "60 (VPx)",
            "61 (VPx)",
            "62 (VPx)",
            "63 (VPx) (WORST)"});
            this.cbVideoCRF.Location = new System.Drawing.Point(27, 8);
            this.cbVideoCRF.Name = "cbVideoCRF";
            this.cbVideoCRF.Size = new System.Drawing.Size(93, 21);
            this.cbVideoCRF.TabIndex = 8;
            this.cbVideoCRF.Visible = false;
            // 
            // chkVideoSetPreset
            // 
            this.chkVideoSetPreset.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVideoSetPreset.Location = new System.Drawing.Point(208, 10);
            this.chkVideoSetPreset.Name = "chkVideoSetPreset";
            this.chkVideoSetPreset.Size = new System.Drawing.Size(85, 17);
            this.chkVideoSetPreset.TabIndex = 21;
            this.chkVideoSetPreset.Text = "Preset";
            this.chkVideoSetPreset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVideoSetPreset.UseVisualStyleBackColor = true;
            this.chkVideoSetPreset.CheckedChanged += new System.EventHandler(this.chkVideoSetPreset_CheckedChanged);
            // 
            // chkVideoSetProfile
            // 
            this.chkVideoSetProfile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVideoSetProfile.Location = new System.Drawing.Point(208, 36);
            this.chkVideoSetProfile.Name = "chkVideoSetProfile";
            this.chkVideoSetProfile.Size = new System.Drawing.Size(85, 17);
            this.chkVideoSetProfile.TabIndex = 22;
            this.chkVideoSetProfile.Text = "Profiles";
            this.chkVideoSetProfile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVideoSetProfile.UseVisualStyleBackColor = true;
            this.chkVideoSetProfile.CheckedChanged += new System.EventHandler(this.chkVideoSetProfile_CheckedChanged);
            // 
            // tpAudioStreams
            // 
            this.tpAudioStreams.Controls.Add(this.lvAudioStreams);
            this.tpAudioStreams.Controls.Add(this.pnAudioSettings);
            this.tpAudioStreams.Location = new System.Drawing.Point(4, 22);
            this.tpAudioStreams.Name = "tpAudioStreams";
            this.tpAudioStreams.Padding = new System.Windows.Forms.Padding(3);
            this.tpAudioStreams.Size = new System.Drawing.Size(405, 186);
            this.tpAudioStreams.TabIndex = 1;
            this.tpAudioStreams.Text = "Audio streams";
            this.tpAudioStreams.UseVisualStyleBackColor = true;
            // 
            // lvAudioStreams
            // 
            this.lvAudioStreams.CheckBoxes = true;
            this.lvAudioStreams.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAudioIndex,
            this.chAudioTitle,
            this.chAudioCodec,
            this.chAudioBitrate,
            this.chAudioSamplingRate});
            this.lvAudioStreams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAudioStreams.FullRowSelect = true;
            this.lvAudioStreams.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvAudioStreams.HideSelection = false;
            this.lvAudioStreams.Location = new System.Drawing.Point(3, 3);
            this.lvAudioStreams.MultiSelect = false;
            this.lvAudioStreams.Name = "lvAudioStreams";
            this.lvAudioStreams.Size = new System.Drawing.Size(399, 122);
            this.lvAudioStreams.TabIndex = 1;
            this.lvAudioStreams.UseCompatibleStateImageBehavior = false;
            this.lvAudioStreams.View = System.Windows.Forms.View.Details;
            // 
            // chAudioIndex
            // 
            this.chAudioIndex.Text = "#";
            this.chAudioIndex.Width = 35;
            // 
            // chAudioTitle
            // 
            this.chAudioTitle.Text = "Title";
            this.chAudioTitle.Width = 67;
            // 
            // chAudioCodec
            // 
            this.chAudioCodec.Text = "Codec";
            this.chAudioCodec.Width = 116;
            // 
            // chAudioBitrate
            // 
            this.chAudioBitrate.Text = "Bitrate";
            this.chAudioBitrate.Width = 94;
            // 
            // chAudioSamplingRate
            // 
            this.chAudioSamplingRate.Text = "Sample rate";
            this.chAudioSamplingRate.Width = 77;
            // 
            // pnAudioSettings
            // 
            this.pnAudioSettings.Controls.Add(this.cbAudioSampleRate);
            this.pnAudioSettings.Controls.Add(this.chkAudioSampleRate);
            this.pnAudioSettings.Controls.Add(this.chkSetAudioQuality);
            this.pnAudioSettings.Controls.Add(this.chkAudioUseVBR);
            this.pnAudioSettings.Controls.Add(this.numAudioBitrate);
            this.pnAudioSettings.Controls.Add(this.lbAudioBitrate);
            this.pnAudioSettings.Controls.Add(this.cbAudioVBR);
            this.pnAudioSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnAudioSettings.Location = new System.Drawing.Point(3, 125);
            this.pnAudioSettings.Name = "pnAudioSettings";
            this.pnAudioSettings.Size = new System.Drawing.Size(399, 58);
            this.pnAudioSettings.TabIndex = 2;
            // 
            // chkSetAudioQuality
            // 
            this.chkSetAudioQuality.AutoSize = true;
            this.chkSetAudioQuality.Location = new System.Drawing.Point(9, 12);
            this.chkSetAudioQuality.Name = "chkSetAudioQuality";
            this.chkSetAudioQuality.Size = new System.Drawing.Size(14, 13);
            this.chkSetAudioQuality.TabIndex = 21;
            this.chkSetAudioQuality.UseVisualStyleBackColor = true;
            this.chkSetAudioQuality.CheckedChanged += new System.EventHandler(this.chkSetAudioQuality_CheckedChanged);
            // 
            // chkAudioUseVBR
            // 
            this.chkAudioUseVBR.AutoSize = true;
            this.chkAudioUseVBR.Enabled = false;
            this.chkAudioUseVBR.Location = new System.Drawing.Point(125, 10);
            this.chkAudioUseVBR.Name = "chkAudioUseVBR";
            this.chkAudioUseVBR.Size = new System.Drawing.Size(67, 17);
            this.chkAudioUseVBR.TabIndex = 11;
            this.chkAudioUseVBR.Text = "Use VBR";
            this.chkAudioUseVBR.UseVisualStyleBackColor = true;
            // 
            // numAudioBitrate
            // 
            this.numAudioBitrate.Enabled = false;
            this.numAudioBitrate.Location = new System.Drawing.Point(27, 8);
            this.numAudioBitrate.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numAudioBitrate.Name = "numAudioBitrate";
            this.numAudioBitrate.Size = new System.Drawing.Size(79, 22);
            this.numAudioBitrate.TabIndex = 9;
            this.numAudioBitrate.ThousandsSeparator = true;
            this.numAudioBitrate.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            // 
            // lbAudioBitrate
            // 
            this.lbAudioBitrate.AutoSize = true;
            this.lbAudioBitrate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAudioBitrate.Location = new System.Drawing.Point(104, 9);
            this.lbAudioBitrate.Name = "lbAudioBitrate";
            this.lbAudioBitrate.Size = new System.Drawing.Size(16, 17);
            this.lbAudioBitrate.TabIndex = 10;
            this.lbAudioBitrate.Text = "K";
            // 
            // cbAudioVBR
            // 
            this.cbAudioVBR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioVBR.Enabled = false;
            this.cbAudioVBR.FormattingEnabled = true;
            this.cbAudioVBR.Items.AddRange(new object[] {
            "0 (BEST)",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10 (WORST)"});
            this.cbAudioVBR.Location = new System.Drawing.Point(27, 8);
            this.cbAudioVBR.Name = "cbAudioVBR";
            this.cbAudioVBR.Size = new System.Drawing.Size(93, 21);
            this.cbAudioVBR.TabIndex = 12;
            this.cbAudioVBR.Visible = false;
            // 
            // tpSubtitles
            // 
            this.tpSubtitles.Controls.Add(this.lvSubtitles);
            this.tpSubtitles.Location = new System.Drawing.Point(4, 22);
            this.tpSubtitles.Name = "tpSubtitles";
            this.tpSubtitles.Padding = new System.Windows.Forms.Padding(3);
            this.tpSubtitles.Size = new System.Drawing.Size(405, 186);
            this.tpSubtitles.TabIndex = 2;
            this.tpSubtitles.Text = "Subtitles";
            this.tpSubtitles.UseVisualStyleBackColor = true;
            // 
            // lvSubtitles
            // 
            this.lvSubtitles.CheckBoxes = true;
            this.lvSubtitles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSubtitleIndex,
            this.chSubtitleTitle,
            this.chSubtitleLanguage,
            this.chSubtitleFormat});
            this.lvSubtitles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSubtitles.FullRowSelect = true;
            this.lvSubtitles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvSubtitles.HideSelection = false;
            this.lvSubtitles.Location = new System.Drawing.Point(3, 3);
            this.lvSubtitles.Name = "lvSubtitles";
            this.lvSubtitles.Size = new System.Drawing.Size(399, 180);
            this.lvSubtitles.TabIndex = 1;
            this.lvSubtitles.UseCompatibleStateImageBehavior = false;
            this.lvSubtitles.View = System.Windows.Forms.View.Details;
            // 
            // chSubtitleIndex
            // 
            this.chSubtitleIndex.Text = "#";
            this.chSubtitleIndex.Width = 35;
            // 
            // chSubtitleTitle
            // 
            this.chSubtitleTitle.Text = "Title";
            this.chSubtitleTitle.Width = 159;
            // 
            // chSubtitleLanguage
            // 
            this.chSubtitleLanguage.Text = "Language";
            this.chSubtitleLanguage.Width = 61;
            // 
            // chSubtitleFormat
            // 
            this.chSubtitleFormat.Text = "Format";
            this.chSubtitleFormat.Width = 138;
            // 
            // tpAttachments
            // 
            this.tpAttachments.Controls.Add(this.lvAttachments);
            this.tpAttachments.Location = new System.Drawing.Point(4, 22);
            this.tpAttachments.Name = "tpAttachments";
            this.tpAttachments.Padding = new System.Windows.Forms.Padding(3);
            this.tpAttachments.Size = new System.Drawing.Size(405, 186);
            this.tpAttachments.TabIndex = 3;
            this.tpAttachments.Text = "Attachments";
            this.tpAttachments.UseVisualStyleBackColor = true;
            // 
            // lvAttachments
            // 
            this.lvAttachments.CheckBoxes = true;
            this.lvAttachments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chAttachmentIndex,
            this.chAttachmentTitle,
            this.chAttachmentCodec});
            this.lvAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAttachments.FullRowSelect = true;
            this.lvAttachments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvAttachments.HideSelection = false;
            this.lvAttachments.Location = new System.Drawing.Point(3, 3);
            this.lvAttachments.Name = "lvAttachments";
            this.lvAttachments.Size = new System.Drawing.Size(399, 180);
            this.lvAttachments.TabIndex = 1;
            this.lvAttachments.UseCompatibleStateImageBehavior = false;
            this.lvAttachments.View = System.Windows.Forms.View.Details;
            // 
            // chAttachmentIndex
            // 
            this.chAttachmentIndex.Text = "#";
            this.chAttachmentIndex.Width = 35;
            // 
            // chAttachmentTitle
            // 
            this.chAttachmentTitle.Text = "Title";
            this.chAttachmentTitle.Width = 67;
            // 
            // chAttachmentCodec
            // 
            this.chAttachmentCodec.Text = "Codec";
            this.chAttachmentCodec.Width = 91;
            // 
            // tpData
            // 
            this.tpData.Controls.Add(this.lvData);
            this.tpData.Location = new System.Drawing.Point(4, 22);
            this.tpData.Name = "tpData";
            this.tpData.Padding = new System.Windows.Forms.Padding(3);
            this.tpData.Size = new System.Drawing.Size(405, 186);
            this.tpData.TabIndex = 4;
            this.tpData.Text = "Data";
            this.tpData.UseVisualStyleBackColor = true;
            // 
            // lvData
            // 
            this.lvData.CheckBoxes = true;
            this.lvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDataIndex,
            this.chDataTitle});
            this.lvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvData.FullRowSelect = true;
            this.lvData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvData.HideSelection = false;
            this.lvData.Location = new System.Drawing.Point(3, 3);
            this.lvData.Name = "lvData";
            this.lvData.Size = new System.Drawing.Size(399, 180);
            this.lvData.TabIndex = 2;
            this.lvData.UseCompatibleStateImageBehavior = false;
            this.lvData.View = System.Windows.Forms.View.Details;
            // 
            // chDataIndex
            // 
            this.chDataIndex.Text = "#";
            this.chDataIndex.Width = 35;
            // 
            // chDataTitle
            // 
            this.chDataTitle.Text = "Title";
            this.chDataTitle.Width = 340;
            // 
            // tpEndingTime
            // 
            this.tpEndingTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tpEndingTime.Location = new System.Drawing.Point(227, 340);
            this.tpEndingTime.Name = "tpEndingTime";
            this.tpEndingTime.ShowMilliseconds = true;
            this.tpEndingTime.Size = new System.Drawing.Size(90, 20);
            this.tpEndingTime.TabIndex = 4;
            this.tpEndingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tpStartingTime
            // 
            this.tpStartingTime.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tpStartingTime.Location = new System.Drawing.Point(120, 340);
            this.tpStartingTime.Name = "tpStartingTime";
            this.tpStartingTime.ShowMilliseconds = true;
            this.tpStartingTime.Size = new System.Drawing.Size(90, 20);
            this.tpStartingTime.TabIndex = 3;
            this.tpStartingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtOutput.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtOutput.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.ButtonImageIndex = -1;
            this.txtOutput.ButtonSize = new System.Drawing.Size(24, 21);
            this.txtOutput.ButtonText = "...";
            this.txtOutput.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtOutput.Location = new System.Drawing.Point(12, 38);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ShowButton = true;
            this.txtOutput.Size = new System.Drawing.Size(410, 22);
            this.txtOutput.TabIndex = 1;
            this.txtOutput.TextHint = "Output";
            this.txtOutput.ButtonClick += new System.EventHandler(this.txtOutput_ButtonClick);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtInput.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtInput.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.ButtonImageIndex = -1;
            this.txtInput.ButtonSize = new System.Drawing.Size(24, 21);
            this.txtInput.ButtonText = "...";
            this.txtInput.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtInput.Location = new System.Drawing.Point(12, 12);
            this.txtInput.Name = "txtInput";
            this.txtInput.ShowButton = true;
            this.txtInput.Size = new System.Drawing.Size(390, 22);
            this.txtInput.TabIndex = 0;
            this.txtInput.TextHint = "Input";
            this.txtInput.ButtonClick += new System.EventHandler(this.txtInput_ButtonClick);
            // 
            // chkRemoveMetadata
            // 
            this.chkRemoveMetadata.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkRemoveMetadata.AutoSize = true;
            this.chkRemoveMetadata.Location = new System.Drawing.Point(39, 296);
            this.chkRemoveMetadata.Name = "chkRemoveMetadata";
            this.chkRemoveMetadata.Size = new System.Drawing.Size(116, 17);
            this.chkRemoveMetadata.TabIndex = 9;
            this.chkRemoveMetadata.Text = "Remove metadata";
            this.chkRemoveMetadata.UseVisualStyleBackColor = true;
            // 
            // chkHideFfmpegMetadata
            // 
            this.chkHideFfmpegMetadata.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkHideFfmpegMetadata.AutoSize = true;
            this.chkHideFfmpegMetadata.Location = new System.Drawing.Point(161, 296);
            this.chkHideFfmpegMetadata.Name = "chkHideFfmpegMetadata";
            this.chkHideFfmpegMetadata.Size = new System.Drawing.Size(140, 17);
            this.chkHideFfmpegMetadata.TabIndex = 10;
            this.chkHideFfmpegMetadata.Text = "Hide ffmpeg metadata";
            this.chkHideFfmpegMetadata.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(29, 408);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(379, 2);
            this.label3.TabIndex = 11;
            this.label3.Text = "label3";
            // 
            // txtGeneratedArgs
            // 
            this.txtGeneratedArgs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeneratedArgs.Location = new System.Drawing.Point(19, 423);
            this.txtGeneratedArgs.Name = "txtGeneratedArgs";
            this.txtGeneratedArgs.ReadOnly = true;
            this.txtGeneratedArgs.Size = new System.Drawing.Size(399, 22);
            this.txtGeneratedArgs.TabIndex = 12;
            // 
            // btnDebugGenerateArgs
            // 
            this.btnDebugGenerateArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDebugGenerateArgs.Location = new System.Drawing.Point(343, 374);
            this.btnDebugGenerateArgs.Name = "btnDebugGenerateArgs";
            this.btnDebugGenerateArgs.Size = new System.Drawing.Size(75, 23);
            this.btnDebugGenerateArgs.TabIndex = 13;
            this.btnDebugGenerateArgs.Text = "Gen args";
            this.btnDebugGenerateArgs.UseVisualStyleBackColor = true;
            this.btnDebugGenerateArgs.Click += new System.EventHandler(this.btnDebugGenerateArgs_Click);
            // 
            // chkCopyCodecs
            // 
            this.chkCopyCodecs.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.chkCopyCodecs.AutoSize = true;
            this.chkCopyCodecs.Location = new System.Drawing.Point(307, 296);
            this.chkCopyCodecs.Name = "chkCopyCodecs";
            this.chkCopyCodecs.Size = new System.Drawing.Size(89, 17);
            this.chkCopyCodecs.TabIndex = 14;
            this.chkCopyCodecs.Text = "Copy codecs";
            this.chkCopyCodecs.UseVisualStyleBackColor = true;
            // 
            // chkSelectOutputOnOk
            // 
            this.chkSelectOutputOnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSelectOutputOnOk.AutoSize = true;
            this.chkSelectOutputOnOk.Location = new System.Drawing.Point(408, 16);
            this.chkSelectOutputOnOk.Name = "chkSelectOutputOnOk";
            this.chkSelectOutputOnOk.Size = new System.Drawing.Size(14, 13);
            this.chkSelectOutputOnOk.TabIndex = 15;
            this.chkSelectOutputOnOk.UseVisualStyleBackColor = true;
            // 
            // cbAudioSampleRate
            // 
            this.cbAudioSampleRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAudioSampleRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAudioSampleRate.Enabled = false;
            this.cbAudioSampleRate.FormattingEnabled = true;
            this.cbAudioSampleRate.Items.AddRange(new object[] {
            "48000",
            "44100",
            "32000",
            "22050",
            "11025",
            "8000"});
            this.cbAudioSampleRate.Location = new System.Drawing.Point(299, 7);
            this.cbAudioSampleRate.Name = "cbAudioSampleRate";
            this.cbAudioSampleRate.Size = new System.Drawing.Size(94, 21);
            this.cbAudioSampleRate.TabIndex = 22;
            // 
            // chkAudioSampleRate
            // 
            this.chkAudioSampleRate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAudioSampleRate.Location = new System.Drawing.Point(208, 10);
            this.chkAudioSampleRate.Name = "chkAudioSampleRate";
            this.chkAudioSampleRate.Size = new System.Drawing.Size(85, 17);
            this.chkAudioSampleRate.TabIndex = 23;
            this.chkAudioSampleRate.Text = "Sample rate";
            this.chkAudioSampleRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAudioSampleRate.UseVisualStyleBackColor = true;
            this.chkAudioSampleRate.CheckedChanged += new System.EventHandler(this.chkAudioSampleRate_CheckedChanged);
            // 
            // frmExtendedConverter
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 455);
            this.Controls.Add(this.chkSelectOutputOnOk);
            this.Controls.Add(this.chkCopyCodecs);
            this.Controls.Add(this.btnDebugGenerateArgs);
            this.Controls.Add(this.txtGeneratedArgs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkHideFfmpegMetadata);
            this.Controls.Add(this.chkRemoveMetadata);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tpEndingTime);
            this.Controls.Add(this.tpStartingTime);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtInput);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;
            this.MinimumSize = new System.Drawing.Size(450, 490);
            this.Name = "frmExtendedConverter";
            this.Text = "frmExtendedConverter";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmExtendedConverter_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmExtendedConverter_DragEnter);
            this.tcMain.ResumeLayout(false);
            this.tpVideoStreams.ResumeLayout(false);
            this.pnVideoOptions.ResumeLayout(false);
            this.pnVideoOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numVideoBitrate)).EndInit();
            this.tpAudioStreams.ResumeLayout(false);
            this.pnAudioSettings.ResumeLayout(false);
            this.pnAudioSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAudioBitrate)).EndInit();
            this.tpSubtitles.ResumeLayout(false);
            this.tpAttachments.ResumeLayout(false);
            this.tpData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private murrty.controls.ExtendedTextBox txtInput;
    private murrty.controls.ExtendedTextBox txtOutput;
    private murrty.controls.TimePicker tpStartingTime;
    private murrty.controls.TimePicker tpEndingTime;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btnConvert;
    private System.Windows.Forms.TabControl tcMain;
    private System.Windows.Forms.TabPage tpVideoStreams;
    private System.Windows.Forms.TabPage tpAudioStreams;
    private System.Windows.Forms.TabPage tpSubtitles;
    private System.Windows.Forms.TabPage tpAttachments;
    private System.Windows.Forms.TabPage tpData;
    private murrty.controls.ExtendedListView lvVideoStreams;
    private System.Windows.Forms.ColumnHeader chVideoIndex;
    private System.Windows.Forms.ColumnHeader chVideoCodec;
    private System.Windows.Forms.ColumnHeader chVideoDisplay;
    private System.Windows.Forms.ColumnHeader chVideoTitle;
    private murrty.controls.ExtendedListView lvAudioStreams;
    private System.Windows.Forms.ColumnHeader chAudioIndex;
    private System.Windows.Forms.ColumnHeader chAudioTitle;
    private System.Windows.Forms.ColumnHeader chAudioBitrate;
    private System.Windows.Forms.ColumnHeader chAudioCodec;
    private System.Windows.Forms.ColumnHeader chAudioSamplingRate;
    private murrty.controls.ExtendedListView lvSubtitles;
    private System.Windows.Forms.ColumnHeader chSubtitleIndex;
    private System.Windows.Forms.ColumnHeader chSubtitleTitle;
    private System.Windows.Forms.ColumnHeader chSubtitleLanguage;
    private System.Windows.Forms.ColumnHeader chSubtitleFormat;
    private murrty.controls.ExtendedListView lvAttachments;
    private System.Windows.Forms.ColumnHeader chAttachmentIndex;
    private System.Windows.Forms.ColumnHeader chAttachmentTitle;
    private System.Windows.Forms.ColumnHeader chAttachmentCodec;
    private murrty.controls.ExtendedListView lvData;
    private System.Windows.Forms.ColumnHeader chDataIndex;
    private System.Windows.Forms.ColumnHeader chDataTitle;
    private System.Windows.Forms.CheckBox chkRemoveMetadata;
    private System.Windows.Forms.CheckBox chkHideFfmpegMetadata;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtGeneratedArgs;
    private System.Windows.Forms.Button btnDebugGenerateArgs;
    private System.Windows.Forms.CheckBox chkCopyCodecs;
    private System.Windows.Forms.CheckBox chkSelectOutputOnOk;
    private System.Windows.Forms.Panel pnVideoOptions;
    private System.Windows.Forms.Panel pnAudioSettings;
    private System.Windows.Forms.ComboBox cbVideoCRF;
    private System.Windows.Forms.CheckBox chkVideoUseCRF;
    private System.Windows.Forms.NumericUpDown numVideoBitrate;
    private System.Windows.Forms.Label lbVideoBitrate;
    private System.Windows.Forms.CheckBox chkAudioUseVBR;
    private System.Windows.Forms.NumericUpDown numAudioBitrate;
    private System.Windows.Forms.Label lbAudioBitrate;
    private System.Windows.Forms.ComboBox cbAudioVBR;
    private System.Windows.Forms.CheckBox chkVideoFaststart;
    private System.Windows.Forms.ComboBox cbVideoProfile;
    private System.Windows.Forms.ComboBox cbVideoPreset;
    private System.Windows.Forms.CheckBox chkSetVideoQuality;
    private System.Windows.Forms.CheckBox chkVideoSetPreset;
    private System.Windows.Forms.CheckBox chkVideoSetProfile;
    private System.Windows.Forms.CheckBox chkSetAudioQuality;
    private System.Windows.Forms.ComboBox cbAudioSampleRate;
    private System.Windows.Forms.CheckBox chkAudioSampleRate;
}