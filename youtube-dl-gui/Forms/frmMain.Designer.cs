namespace youtube_dl_gui {
    partial class frmMain {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lbURL = new System.Windows.Forms.Label();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabDownload = new System.Windows.Forms.TabPage();
            this.lbSchema = new System.Windows.Forms.Label();
            this.cbSchema = new System.Windows.Forms.ComboBox();
            this.cbCustomArguments = new System.Windows.Forms.ComboBox();
            this.chkUseSelection = new System.Windows.Forms.CheckBox();
            this.gbSelection = new System.Windows.Forms.GroupBox();
            this.rbVideoSelectionPlaylistItems = new System.Windows.Forms.RadioButton();
            this.rbVideoSelectionAfterDate = new System.Windows.Forms.RadioButton();
            this.rbVideoSelectionOnDate = new System.Windows.Forms.RadioButton();
            this.rbVideoSelectionBeforeDate = new System.Windows.Forms.RadioButton();
            this.rbVideoSelectionPlaylistIndex = new System.Windows.Forms.RadioButton();
            this.panelDate = new System.Windows.Forms.Panel();
            this.txtVideoDate = new murrty.controls.ExtendedTextBox();
            this.panelPlaylistStartEnd = new System.Windows.Forms.Panel();
            this.txtPlaylistEnd = new murrty.controls.ExtendedTextBox();
            this.txtPlaylistStart = new murrty.controls.ExtendedTextBox();
            this.panelPlaylistItems = new System.Windows.Forms.Panel();
            this.txtPlaylistItems = new murrty.controls.ExtendedTextBox();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            this.lbFormat = new System.Windows.Forms.Label();
            this.sbDownload = new murrty.controls.SplitButton();
            this.cmDownload = new System.Windows.Forms.ContextMenu();
            this.mDownloadWithAuthentication = new System.Windows.Forms.MenuItem();
            this.mBatchDownloadFromFile = new System.Windows.Forms.MenuItem();
            this.mDownloadSeparator = new System.Windows.Forms.MenuItem();
            this.mQuickDownloadForm = new System.Windows.Forms.MenuItem();
            this.mQuickDownloadFormAuthentication = new System.Windows.Forms.MenuItem();
            this.mExtendedDownloadForm = new System.Windows.Forms.MenuItem();
            this.chkDownloadSound = new System.Windows.Forms.CheckBox();
            this.cbQuality = new System.Windows.Forms.ComboBox();
            this.lbQuality = new System.Windows.Forms.Label();
            this.lbCustomArguments = new System.Windows.Forms.Label();
            this.gbDownloadType = new System.Windows.Forms.GroupBox();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbAudio = new System.Windows.Forms.RadioButton();
            this.rbVideo = new System.Windows.Forms.RadioButton();
            this.txtUrl = new murrty.controls.ExtendedTextBox();
            this.tabConvert = new System.Windows.Forms.TabPage();
            this.rbConvertCustom = new System.Windows.Forms.RadioButton();
            this.rbConvertAudio = new System.Windows.Forms.RadioButton();
            this.rbConvertAutoFFmpeg = new System.Windows.Forms.RadioButton();
            this.rbConvertAuto = new System.Windows.Forms.RadioButton();
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
            this.chkDebugDontDownload = new System.Windows.Forms.CheckBox();
            this.btnDebugCheckVerification = new System.Windows.Forms.Button();
            this.btnYtdlVersion = new System.Windows.Forms.Button();
            this.btnDebugThrowException = new System.Windows.Forms.Button();
            this.btnDebugRotateQualityFormat = new System.Windows.Forms.Button();
            this.btnDebugDownloadArgs = new System.Windows.Forms.Button();
            this.btnDebugForceAvailableUpdate = new System.Windows.Forms.Button();
            this.btnDebugForceUpdateCheck = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MainMenu(this.components);
            this.mSettings = new System.Windows.Forms.MenuItem();
            this.mTools = new System.Windows.Forms.MenuItem();
            this.mBatchDownload = new System.Windows.Forms.MenuItem();
            this.mBatchConverter = new System.Windows.Forms.MenuItem();
            this.mArchiveDownloader = new System.Windows.Forms.MenuItem();
            this.mMerger = new System.Windows.Forms.MenuItem();
            this.mDownloadSubtitles = new System.Windows.Forms.MenuItem();
            this.mMiscTools = new System.Windows.Forms.MenuItem();
            this.mToolsSeparator = new System.Windows.Forms.MenuItem();
            this.mClipboardAutoDownload = new System.Windows.Forms.MenuItem();
            this.mClipboardAutoDownloadVerifyLinks = new System.Windows.Forms.MenuItem();
            this.mHelp = new System.Windows.Forms.MenuItem();
            this.mLanguage = new System.Windows.Forms.MenuItem();
            this.mSupportedSites = new System.Windows.Forms.MenuItem();
            this.mLog = new System.Windows.Forms.MenuItem();
            this.mAbout = new System.Windows.Forms.MenuItem();
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
            this.cmDownloadSeparator = new System.Windows.Forms.MenuItem();
            this.cmTrayClipboardAutoDownload = new System.Windows.Forms.MenuItem();
            this.cmTrayClipboardAutoDownloadVerifyLinks = new System.Windows.Forms.MenuItem();
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
            this.tcMain.SuspendLayout();
            this.tabDownload.SuspendLayout();
            this.gbSelection.SuspendLayout();
            this.panelDate.SuspendLayout();
            this.panelPlaylistStartEnd.SuspendLayout();
            this.panelPlaylistItems.SuspendLayout();
            this.gbDownloadType.SuspendLayout();
            this.tabConvert.SuspendLayout();
            this.tabMerge.SuspendLayout();
            this.tabDebug.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbURL
            // 
            this.lbURL.AutoSize = true;
            this.lbURL.Location = new System.Drawing.Point(15, 7);
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
            this.tcMain.Size = new System.Drawing.Size(246, 365);
            this.tcMain.TabIndex = 0;
            // 
            // tabDownload
            // 
            this.tabDownload.Controls.Add(this.lbSchema);
            this.tabDownload.Controls.Add(this.cbSchema);
            this.tabDownload.Controls.Add(this.cbCustomArguments);
            this.tabDownload.Controls.Add(this.chkUseSelection);
            this.tabDownload.Controls.Add(this.gbSelection);
            this.tabDownload.Controls.Add(this.cbFormat);
            this.tabDownload.Controls.Add(this.lbFormat);
            this.tabDownload.Controls.Add(this.sbDownload);
            this.tabDownload.Controls.Add(this.chkDownloadSound);
            this.tabDownload.Controls.Add(this.cbQuality);
            this.tabDownload.Controls.Add(this.lbQuality);
            this.tabDownload.Controls.Add(this.lbCustomArguments);
            this.tabDownload.Controls.Add(this.lbURL);
            this.tabDownload.Controls.Add(this.gbDownloadType);
            this.tabDownload.Controls.Add(this.txtUrl);
            this.tabDownload.Location = new System.Drawing.Point(4, 22);
            this.tabDownload.Name = "tabDownload";
            this.tabDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownload.Size = new System.Drawing.Size(238, 339);
            this.tabDownload.TabIndex = 0;
            this.tabDownload.Text = "tabDownload";
            this.tabDownload.UseVisualStyleBackColor = true;
            // 
            // lbSchema
            // 
            this.lbSchema.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSchema.Location = new System.Drawing.Point(-5, 217);
            this.lbSchema.Name = "lbSchema";
            this.lbSchema.Size = new System.Drawing.Size(63, 15);
            this.lbSchema.TabIndex = 23;
            this.lbSchema.Text = "lbSchema";
            this.lbSchema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSchema
            // 
            this.cbSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSchema.FormattingEnabled = true;
            this.cbSchema.Location = new System.Drawing.Point(60, 215);
            this.cbSchema.Name = "cbSchema";
            this.cbSchema.Size = new System.Drawing.Size(167, 21);
            this.cbSchema.TabIndex = 22;
            this.cbSchema.Text = "%(title)s-%(id)s.%(ext)s";
            // 
            // cbCustomArguments
            // 
            this.cbCustomArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCustomArguments.FormattingEnabled = true;
            this.cbCustomArguments.Location = new System.Drawing.Point(22, 265);
            this.cbCustomArguments.Name = "cbCustomArguments";
            this.cbCustomArguments.Size = new System.Drawing.Size(194, 21);
            this.cbCustomArguments.TabIndex = 21;
            // 
            // chkUseSelection
            // 
            this.chkUseSelection.AutoSize = true;
            this.chkUseSelection.Location = new System.Drawing.Point(8, 163);
            this.chkUseSelection.Name = "chkUseSelection";
            this.chkUseSelection.Size = new System.Drawing.Size(109, 17);
            this.chkUseSelection.TabIndex = 20;
            this.chkUseSelection.Text = "chkUseSelection";
            this.chkUseSelection.UseVisualStyleBackColor = true;
            this.chkUseSelection.CheckedChanged += new System.EventHandler(this.chkUseSelection_CheckedChanged);
            // 
            // gbSelection
            // 
            this.gbSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSelection.Controls.Add(this.rbVideoSelectionPlaylistItems);
            this.gbSelection.Controls.Add(this.rbVideoSelectionAfterDate);
            this.gbSelection.Controls.Add(this.rbVideoSelectionOnDate);
            this.gbSelection.Controls.Add(this.rbVideoSelectionBeforeDate);
            this.gbSelection.Controls.Add(this.rbVideoSelectionPlaylistIndex);
            this.gbSelection.Controls.Add(this.panelDate);
            this.gbSelection.Controls.Add(this.panelPlaylistStartEnd);
            this.gbSelection.Controls.Add(this.panelPlaylistItems);
            this.gbSelection.Location = new System.Drawing.Point(7, 163);
            this.gbSelection.MinimumSize = new System.Drawing.Size(0, 20);
            this.gbSelection.Name = "gbSelection";
            this.gbSelection.Size = new System.Drawing.Size(227, 20);
            this.gbSelection.TabIndex = 19;
            this.gbSelection.TabStop = false;
            // 
            // rbVideoSelectionPlaylistItems
            // 
            this.rbVideoSelectionPlaylistItems.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbVideoSelectionPlaylistItems.AutoSize = true;
            this.rbVideoSelectionPlaylistItems.Location = new System.Drawing.Point(116, 19);
            this.rbVideoSelectionPlaylistItems.Name = "rbVideoSelectionPlaylistItems";
            this.rbVideoSelectionPlaylistItems.Size = new System.Drawing.Size(174, 17);
            this.rbVideoSelectionPlaylistItems.TabIndex = 20;
            this.rbVideoSelectionPlaylistItems.TabStop = true;
            this.rbVideoSelectionPlaylistItems.Text = "rbVideoSelectionPlaylistItems";
            this.rbVideoSelectionPlaylistItems.UseVisualStyleBackColor = true;
            this.rbVideoSelectionPlaylistItems.CheckedChanged += new System.EventHandler(this.rbVideoSelectionPlaylistItems_CheckedChanged);
            // 
            // rbVideoSelectionAfterDate
            // 
            this.rbVideoSelectionAfterDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbVideoSelectionAfterDate.AutoSize = true;
            this.rbVideoSelectionAfterDate.Location = new System.Drawing.Point(157, 42);
            this.rbVideoSelectionAfterDate.Name = "rbVideoSelectionAfterDate";
            this.rbVideoSelectionAfterDate.Size = new System.Drawing.Size(161, 17);
            this.rbVideoSelectionAfterDate.TabIndex = 23;
            this.rbVideoSelectionAfterDate.TabStop = true;
            this.rbVideoSelectionAfterDate.Text = "rbVideoSelectionAfterDate";
            this.rbVideoSelectionAfterDate.UseVisualStyleBackColor = true;
            this.rbVideoSelectionAfterDate.CheckedChanged += new System.EventHandler(this.rbVideoSelectionAfterDate_CheckedChanged);
            // 
            // rbVideoSelectionOnDate
            // 
            this.rbVideoSelectionOnDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbVideoSelectionOnDate.AutoSize = true;
            this.rbVideoSelectionOnDate.Location = new System.Drawing.Point(89, 42);
            this.rbVideoSelectionOnDate.Name = "rbVideoSelectionOnDate";
            this.rbVideoSelectionOnDate.Size = new System.Drawing.Size(152, 17);
            this.rbVideoSelectionOnDate.TabIndex = 21;
            this.rbVideoSelectionOnDate.TabStop = true;
            this.rbVideoSelectionOnDate.Text = "rbVideoSelectionOnDate";
            this.rbVideoSelectionOnDate.UseVisualStyleBackColor = true;
            this.rbVideoSelectionOnDate.CheckedChanged += new System.EventHandler(this.rbVideoSelectionOnDate_CheckedChanged);
            // 
            // rbVideoSelectionBeforeDate
            // 
            this.rbVideoSelectionBeforeDate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbVideoSelectionBeforeDate.AutoSize = true;
            this.rbVideoSelectionBeforeDate.Location = new System.Drawing.Point(7, 42);
            this.rbVideoSelectionBeforeDate.Name = "rbVideoSelectionBeforeDate";
            this.rbVideoSelectionBeforeDate.Size = new System.Drawing.Size(169, 17);
            this.rbVideoSelectionBeforeDate.TabIndex = 22;
            this.rbVideoSelectionBeforeDate.TabStop = true;
            this.rbVideoSelectionBeforeDate.Text = "rbVideoSelectionBeforeDate";
            this.rbVideoSelectionBeforeDate.UseVisualStyleBackColor = true;
            this.rbVideoSelectionBeforeDate.CheckedChanged += new System.EventHandler(this.rbVideoSelectionBeforeDate_CheckedChanged);
            // 
            // rbVideoSelectionPlaylistIndex
            // 
            this.rbVideoSelectionPlaylistIndex.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rbVideoSelectionPlaylistIndex.AutoSize = true;
            this.rbVideoSelectionPlaylistIndex.Location = new System.Drawing.Point(26, 19);
            this.rbVideoSelectionPlaylistIndex.Name = "rbVideoSelectionPlaylistIndex";
            this.rbVideoSelectionPlaylistIndex.Size = new System.Drawing.Size(175, 17);
            this.rbVideoSelectionPlaylistIndex.TabIndex = 19;
            this.rbVideoSelectionPlaylistIndex.TabStop = true;
            this.rbVideoSelectionPlaylistIndex.Text = "rbVideoSelectionPlaylistIndex";
            this.rbVideoSelectionPlaylistIndex.UseVisualStyleBackColor = true;
            this.rbVideoSelectionPlaylistIndex.CheckedChanged += new System.EventHandler(this.rbVideoSelectionPlaylistIndex_CheckedChanged);
            // 
            // panelDate
            // 
            this.panelDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDate.Controls.Add(this.txtVideoDate);
            this.panelDate.Location = new System.Drawing.Point(7, 69);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(213, 26);
            this.panelDate.TabIndex = 18;
            this.panelDate.Visible = false;
            // 
            // txtVideoDate
            // 
            this.txtVideoDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVideoDate.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtVideoDate.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtVideoDate.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVideoDate.ButtonImageIndex = -1;
            this.txtVideoDate.ButtonSize = new System.Drawing.Size(22, 21);
            this.txtVideoDate.ButtonText = "";
            this.txtVideoDate.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtVideoDate.Location = new System.Drawing.Point(3, 3);
            this.txtVideoDate.MaxLength = 8;
            this.txtVideoDate.Name = "txtVideoDate";
            this.txtVideoDate.RegexPatterns = null;
            this.txtVideoDate.Size = new System.Drawing.Size(207, 22);
            this.txtVideoDate.TabIndex = 0;
            this.txtVideoDate.TextHint = "txtVideoDateHint";
            this.txtVideoDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVideoDate_KeyPress);
            // 
            // panelPlaylistStartEnd
            // 
            this.panelPlaylistStartEnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelPlaylistStartEnd.Controls.Add(this.txtPlaylistEnd);
            this.panelPlaylistStartEnd.Controls.Add(this.txtPlaylistStart);
            this.panelPlaylistStartEnd.Location = new System.Drawing.Point(8, 69);
            this.panelPlaylistStartEnd.Name = "panelPlaylistStartEnd";
            this.panelPlaylistStartEnd.Size = new System.Drawing.Size(211, 26);
            this.panelPlaylistStartEnd.TabIndex = 16;
            this.panelPlaylistStartEnd.Visible = false;
            // 
            // txtPlaylistEnd
            // 
            this.txtPlaylistEnd.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtPlaylistEnd.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtPlaylistEnd.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaylistEnd.ButtonImageIndex = -1;
            this.txtPlaylistEnd.ButtonSize = new System.Drawing.Size(22, 21);
            this.txtPlaylistEnd.ButtonText = "";
            this.txtPlaylistEnd.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtPlaylistEnd.Location = new System.Drawing.Point(108, 3);
            this.txtPlaylistEnd.Name = "txtPlaylistEnd";
            this.txtPlaylistEnd.RegexPatterns = null;
            this.txtPlaylistEnd.Size = new System.Drawing.Size(100, 22);
            this.txtPlaylistEnd.TabIndex = 1;
            this.txtPlaylistEnd.TextHint = "txtPlaylistEndHint";
            this.txtPlaylistEnd.TextType = murrty.controls.AllowedCharacters.NumericOnly;
            // 
            // txtPlaylistStart
            // 
            this.txtPlaylistStart.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtPlaylistStart.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtPlaylistStart.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaylistStart.ButtonImageIndex = -1;
            this.txtPlaylistStart.ButtonSize = new System.Drawing.Size(22, 21);
            this.txtPlaylistStart.ButtonText = "";
            this.txtPlaylistStart.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtPlaylistStart.Location = new System.Drawing.Point(3, 3);
            this.txtPlaylistStart.Name = "txtPlaylistStart";
            this.txtPlaylistStart.RegexPatterns = null;
            this.txtPlaylistStart.Size = new System.Drawing.Size(100, 22);
            this.txtPlaylistStart.TabIndex = 0;
            this.txtPlaylistStart.TextHint = "txtPlaylistStartHint";
            this.txtPlaylistStart.TextType = murrty.controls.AllowedCharacters.NumericOnly;
            // 
            // panelPlaylistItems
            // 
            this.panelPlaylistItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPlaylistItems.Controls.Add(this.txtPlaylistItems);
            this.panelPlaylistItems.Location = new System.Drawing.Point(7, 69);
            this.panelPlaylistItems.Name = "panelPlaylistItems";
            this.panelPlaylistItems.Size = new System.Drawing.Size(213, 26);
            this.panelPlaylistItems.TabIndex = 17;
            this.panelPlaylistItems.Visible = false;
            // 
            // txtPlaylistItems
            // 
            this.txtPlaylistItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaylistItems.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtPlaylistItems.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtPlaylistItems.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaylistItems.ButtonImageIndex = -1;
            this.txtPlaylistItems.ButtonSize = new System.Drawing.Size(22, 21);
            this.txtPlaylistItems.ButtonText = "";
            this.txtPlaylistItems.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtPlaylistItems.Location = new System.Drawing.Point(3, 3);
            this.txtPlaylistItems.Name = "txtPlaylistItems";
            this.txtPlaylistItems.RegexPatterns = null;
            this.txtPlaylistItems.Size = new System.Drawing.Size(207, 22);
            this.txtPlaylistItems.TabIndex = 0;
            this.txtPlaylistItems.TextHint = "txtPlaylistItemsHint";
            this.txtPlaylistItems.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPlaylistItems_KeyPress);
            // 
            // cbFormat
            // 
            this.cbFormat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Location = new System.Drawing.Point(71, 136);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(80, 21);
            this.cbFormat.TabIndex = 11;
            // 
            // lbFormat
            // 
            this.lbFormat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbFormat.Location = new System.Drawing.Point(5, 139);
            this.lbFormat.Name = "lbFormat";
            this.lbFormat.Size = new System.Drawing.Size(63, 13);
            this.lbFormat.TabIndex = 10;
            this.lbFormat.Text = "lbFormat";
            this.lbFormat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sbDownload
            // 
            this.sbDownload.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.sbDownload.ContextMenu = this.cmDownload;
            this.sbDownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.sbDownload.Location = new System.Drawing.Point(78, 297);
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
            this.mDownloadWithAuthentication,
            this.mBatchDownloadFromFile,
            this.mDownloadSeparator,
            this.mQuickDownloadForm,
            this.mQuickDownloadFormAuthentication,
            this.mExtendedDownloadForm});
            // 
            // mDownloadWithAuthentication
            // 
            this.mDownloadWithAuthentication.Index = 0;
            this.mDownloadWithAuthentication.Text = "mDownloadWithAuthentication";
            this.mDownloadWithAuthentication.Click += new System.EventHandler(this.mDownloadWithAuthentication_Click);
            // 
            // mBatchDownloadFromFile
            // 
            this.mBatchDownloadFromFile.Index = 1;
            this.mBatchDownloadFromFile.Text = "mBatchDownloadFromFile";
            this.mBatchDownloadFromFile.Click += new System.EventHandler(this.mBatchDownloadFromFile_Click);
            // 
            // mDownloadSeparator
            // 
            this.mDownloadSeparator.Index = 2;
            this.mDownloadSeparator.Text = "-";
            // 
            // mQuickDownloadForm
            // 
            this.mQuickDownloadForm.Index = 3;
            this.mQuickDownloadForm.Text = "mQuickDownloadForm";
            this.mQuickDownloadForm.Click += new System.EventHandler(this.mQuickDownloadForm_Click);
            // 
            // mQuickDownloadFormAuthentication
            // 
            this.mQuickDownloadFormAuthentication.Index = 4;
            this.mQuickDownloadFormAuthentication.Text = "mQuickDownloadFormAuthentication";
            this.mQuickDownloadFormAuthentication.Click += new System.EventHandler(this.mQuickDownloadFormAuthentication_Click);
            // 
            // mExtendedDownloadForm
            // 
            this.mExtendedDownloadForm.Index = 5;
            this.mExtendedDownloadForm.Text = "mExtendedDownloadForm";
            this.mExtendedDownloadForm.Click += new System.EventHandler(this.mExtendedDownloadForm_Click);
            // 
            // chkDownloadSound
            // 
            this.chkDownloadSound.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkDownloadSound.AutoSize = true;
            this.chkDownloadSound.Checked = true;
            this.chkDownloadSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDownloadSound.Location = new System.Drawing.Point(157, 109);
            this.chkDownloadSound.Name = "chkDownloadSound";
            this.chkDownloadSound.Size = new System.Drawing.Size(131, 17);
            this.chkDownloadSound.TabIndex = 9;
            this.chkDownloadSound.Text = "chkDownloadSound";
            this.chkDownloadSound.UseVisualStyleBackColor = true;
            this.chkDownloadSound.CheckedChanged += new System.EventHandler(this.chkDownloadSound_CheckedChanged);
            // 
            // cbQuality
            // 
            this.cbQuality.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuality.FormattingEnabled = true;
            this.cbQuality.Location = new System.Drawing.Point(71, 107);
            this.cbQuality.Name = "cbQuality";
            this.cbQuality.Size = new System.Drawing.Size(80, 21);
            this.cbQuality.TabIndex = 8;
            // 
            // lbQuality
            // 
            this.lbQuality.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbQuality.Location = new System.Drawing.Point(5, 109);
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
            this.lbCustomArguments.Location = new System.Drawing.Point(15, 244);
            this.lbCustomArguments.Name = "lbCustomArguments";
            this.lbCustomArguments.Size = new System.Drawing.Size(112, 13);
            this.lbCustomArguments.TabIndex = 12;
            this.lbCustomArguments.Text = "lbCustomArguments";
            // 
            // gbDownloadType
            // 
            this.gbDownloadType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbDownloadType.Controls.Add(this.rbCustom);
            this.gbDownloadType.Controls.Add(this.rbAudio);
            this.gbDownloadType.Controls.Add(this.rbVideo);
            this.gbDownloadType.Location = new System.Drawing.Point(8, 59);
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
            this.rbCustom.Size = new System.Drawing.Size(74, 17);
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
            this.rbAudio.Size = new System.Drawing.Size(66, 17);
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
            this.rbVideo.Size = new System.Drawing.Size(65, 17);
            this.rbVideo.TabIndex = 4;
            this.rbVideo.TabStop = true;
            this.rbVideo.Text = "rbVideo";
            this.rbVideo.UseVisualStyleBackColor = true;
            this.rbVideo.CheckedChanged += new System.EventHandler(this.rbVideo_CheckedChanged);
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.ButtonAlignment = murrty.controls.ButtonAlignment.Left;
            this.txtUrl.ButtonCursor = System.Windows.Forms.Cursors.Default;
            this.txtUrl.ButtonFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUrl.ButtonImageIndex = -1;
            this.txtUrl.ButtonSize = new System.Drawing.Size(22, 21);
            this.txtUrl.ButtonText = "";
            this.txtUrl.ButtonTextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtUrl.Location = new System.Drawing.Point(22, 26);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.RegexPatterns = null;
            this.txtUrl.Size = new System.Drawing.Size(194, 22);
            this.txtUrl.TabIndex = 2;
            this.txtUrl.TextChanged += new System.EventHandler(this.txtUrl_TextChanged);
            this.txtUrl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUrl_KeyPress);
            this.txtUrl.MouseEnter += new System.EventHandler(this.txtUrl_MouseEnter);
            // 
            // tabConvert
            // 
            this.tabConvert.Controls.Add(this.rbConvertCustom);
            this.tabConvert.Controls.Add(this.rbConvertAudio);
            this.tabConvert.Controls.Add(this.rbConvertAutoFFmpeg);
            this.tabConvert.Controls.Add(this.rbConvertAuto);
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
            this.tabConvert.Size = new System.Drawing.Size(238, 339);
            this.tabConvert.TabIndex = 1;
            this.tabConvert.Text = "tabConvert";
            this.tabConvert.UseVisualStyleBackColor = true;
            // 
            // rbConvertCustom
            // 
            this.rbConvertCustom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbConvertCustom.AutoSize = true;
            this.rbConvertCustom.Location = new System.Drawing.Point(124, 79);
            this.rbConvertCustom.Name = "rbConvertCustom";
            this.rbConvertCustom.Size = new System.Drawing.Size(114, 17);
            this.rbConvertCustom.TabIndex = 9;
            this.rbConvertCustom.TabStop = true;
            this.rbConvertCustom.Text = "rbConvertCustom";
            this.rbConvertCustom.UseVisualStyleBackColor = true;
            // 
            // rbConvertAudio
            // 
            this.rbConvertAudio.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbConvertAudio.AutoSize = true;
            this.rbConvertAudio.Location = new System.Drawing.Point(67, 79);
            this.rbConvertAudio.Name = "rbConvertAudio";
            this.rbConvertAudio.Size = new System.Drawing.Size(106, 17);
            this.rbConvertAudio.TabIndex = 8;
            this.rbConvertAudio.TabStop = true;
            this.rbConvertAudio.Text = "rbConvertAudio";
            this.rbConvertAudio.UseVisualStyleBackColor = true;
            // 
            // rbConvertAutoFFmpeg
            // 
            this.rbConvertAutoFFmpeg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbConvertAutoFFmpeg.AutoSize = true;
            this.rbConvertAutoFFmpeg.Location = new System.Drawing.Point(93, 102);
            this.rbConvertAutoFFmpeg.Name = "rbConvertAutoFFmpeg";
            this.rbConvertAutoFFmpeg.Size = new System.Drawing.Size(141, 17);
            this.rbConvertAutoFFmpeg.TabIndex = 11;
            this.rbConvertAutoFFmpeg.TabStop = true;
            this.rbConvertAutoFFmpeg.Text = "rbConvertAutoFFmpeg";
            this.rbConvertAutoFFmpeg.UseVisualStyleBackColor = true;
            // 
            // rbConvertAuto
            // 
            this.rbConvertAuto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rbConvertAuto.AutoSize = true;
            this.rbConvertAuto.Location = new System.Drawing.Point(16, 102);
            this.rbConvertAuto.Name = "rbConvertAuto";
            this.rbConvertAuto.Size = new System.Drawing.Size(100, 17);
            this.rbConvertAuto.TabIndex = 10;
            this.rbConvertAuto.TabStop = true;
            this.rbConvertAuto.Text = "rbConvertAuto";
            this.rbConvertAuto.UseVisualStyleBackColor = true;
            // 
            // btnConvert
            // 
            this.btnConvert.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(79, 232);
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
            this.rbConvertVideo.Location = new System.Drawing.Point(8, 79);
            this.rbConvertVideo.Name = "rbConvertVideo";
            this.rbConvertVideo.Size = new System.Drawing.Size(105, 17);
            this.rbConvertVideo.TabIndex = 7;
            this.rbConvertVideo.TabStop = true;
            this.rbConvertVideo.Text = "rbConvertVideo";
            this.rbConvertVideo.UseVisualStyleBackColor = true;
            // 
            // btnConvertOutput
            // 
            this.btnConvertOutput.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnConvertOutput.Enabled = false;
            this.btnConvertOutput.Location = new System.Drawing.Point(199, 162);
            this.btnConvertOutput.Name = "btnConvertOutput";
            this.btnConvertOutput.Size = new System.Drawing.Size(29, 23);
            this.btnConvertOutput.TabIndex = 6;
            this.btnConvertOutput.Text = "...";
            this.btnConvertOutput.UseVisualStyleBackColor = true;
            this.btnConvertOutput.Click += new System.EventHandler(this.btnConvertOutput_Click);
            // 
            // lbConvertOutput
            // 
            this.lbConvertOutput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbConvertOutput.AutoSize = true;
            this.lbConvertOutput.Location = new System.Drawing.Point(19, 144);
            this.lbConvertOutput.Name = "lbConvertOutput";
            this.lbConvertOutput.Size = new System.Drawing.Size(95, 13);
            this.lbConvertOutput.TabIndex = 4;
            this.lbConvertOutput.Text = "lbConvertOutput";
            // 
            // txtConvertOutput
            // 
            this.txtConvertOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConvertOutput.Location = new System.Drawing.Point(26, 164);
            this.txtConvertOutput.Name = "txtConvertOutput";
            this.txtConvertOutput.ReadOnly = true;
            this.txtConvertOutput.Size = new System.Drawing.Size(167, 22);
            this.txtConvertOutput.TabIndex = 5;
            // 
            // btnConvertInput
            // 
            this.btnConvertInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertInput.Location = new System.Drawing.Point(199, 25);
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
            this.lbConvertInput.Size = new System.Drawing.Size(85, 13);
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
            this.txtConvertInput.Size = new System.Drawing.Size(167, 22);
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
            this.tabMerge.Size = new System.Drawing.Size(238, 339);
            this.tabMerge.TabIndex = 2;
            this.tabMerge.Text = "tabMerge";
            this.tabMerge.UseVisualStyleBackColor = true;
            // 
            // chkMergeDeleteInputFiles
            // 
            this.chkMergeDeleteInputFiles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkMergeDeleteInputFiles.AutoSize = true;
            this.chkMergeDeleteInputFiles.Location = new System.Drawing.Point(52, 192);
            this.chkMergeDeleteInputFiles.Name = "chkMergeDeleteInputFiles";
            this.chkMergeDeleteInputFiles.Size = new System.Drawing.Size(160, 17);
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
            this.chkMergeAudioTracks.Location = new System.Drawing.Point(52, 169);
            this.chkMergeAudioTracks.Name = "chkMergeAudioTracks";
            this.chkMergeAudioTracks.Size = new System.Drawing.Size(138, 17);
            this.chkMergeAudioTracks.TabIndex = 10;
            this.chkMergeAudioTracks.Text = "chkMergeAudioTracks";
            this.chkMergeAudioTracks.UseVisualStyleBackColor = true;
            // 
            // btnMerge
            // 
            this.btnMerge.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMerge.Enabled = false;
            this.btnMerge.Location = new System.Drawing.Point(79, 232);
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
            this.btnBrwsMergeOutput.Location = new System.Drawing.Point(199, 119);
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
            this.txtMergeOutput.Size = new System.Drawing.Size(167, 22);
            this.txtMergeOutput.TabIndex = 8;
            // 
            // lbMergeOutput
            // 
            this.lbMergeOutput.AutoSize = true;
            this.lbMergeOutput.Location = new System.Drawing.Point(19, 101);
            this.lbMergeOutput.Name = "lbMergeOutput";
            this.lbMergeOutput.Size = new System.Drawing.Size(88, 13);
            this.lbMergeOutput.TabIndex = 7;
            this.lbMergeOutput.Text = "lbMergeOutput";
            // 
            // btnBrwsMergeInput2
            // 
            this.btnBrwsMergeInput2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrwsMergeInput2.Enabled = false;
            this.btnBrwsMergeInput2.Location = new System.Drawing.Point(199, 72);
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
            this.txtMergeInput2.Size = new System.Drawing.Size(167, 22);
            this.txtMergeInput2.TabIndex = 5;
            // 
            // btnBrwsMergeInput1
            // 
            this.btnBrwsMergeInput1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrwsMergeInput1.Location = new System.Drawing.Point(199, 25);
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
            this.txtMergeInput1.Size = new System.Drawing.Size(167, 22);
            this.txtMergeInput1.TabIndex = 2;
            // 
            // lbMergeInput2
            // 
            this.lbMergeInput2.AutoSize = true;
            this.lbMergeInput2.Location = new System.Drawing.Point(19, 54);
            this.lbMergeInput2.Name = "lbMergeInput2";
            this.lbMergeInput2.Size = new System.Drawing.Size(84, 13);
            this.lbMergeInput2.TabIndex = 4;
            this.lbMergeInput2.Text = "lbMergeInput2";
            // 
            // lbMergeInput1
            // 
            this.lbMergeInput1.AutoSize = true;
            this.lbMergeInput1.Location = new System.Drawing.Point(19, 7);
            this.lbMergeInput1.Name = "lbMergeInput1";
            this.lbMergeInput1.Size = new System.Drawing.Size(84, 13);
            this.lbMergeInput1.TabIndex = 1;
            this.lbMergeInput1.Text = "lbMergeInput1";
            // 
            // tabDebug
            // 
            this.tabDebug.Controls.Add(this.chkDebugDontDownload);
            this.tabDebug.Controls.Add(this.btnDebugCheckVerification);
            this.tabDebug.Controls.Add(this.btnYtdlVersion);
            this.tabDebug.Controls.Add(this.btnDebugThrowException);
            this.tabDebug.Controls.Add(this.btnDebugRotateQualityFormat);
            this.tabDebug.Controls.Add(this.btnDebugDownloadArgs);
            this.tabDebug.Controls.Add(this.btnDebugForceAvailableUpdate);
            this.tabDebug.Controls.Add(this.btnDebugForceUpdateCheck);
            this.tabDebug.Location = new System.Drawing.Point(4, 22);
            this.tabDebug.Name = "tabDebug";
            this.tabDebug.Padding = new System.Windows.Forms.Padding(3);
            this.tabDebug.Size = new System.Drawing.Size(238, 339);
            this.tabDebug.TabIndex = 3;
            this.tabDebug.Text = "Debug";
            this.tabDebug.UseVisualStyleBackColor = true;
            // 
            // chkDebugDontDownload
            // 
            this.chkDebugDontDownload.AutoSize = true;
            this.chkDebugDontDownload.Location = new System.Drawing.Point(8, 261);
            this.chkDebugDontDownload.Name = "chkDebugDontDownload";
            this.chkDebugDontDownload.Size = new System.Drawing.Size(110, 17);
            this.chkDebugDontDownload.TabIndex = 7;
            this.chkDebugDontDownload.Text = "Don\'t download";
            this.chkDebugDontDownload.UseVisualStyleBackColor = true;
            // 
            // btnDebugCheckVerification
            // 
            this.btnDebugCheckVerification.Location = new System.Drawing.Point(8, 182);
            this.btnDebugCheckVerification.Name = "btnDebugCheckVerification";
            this.btnDebugCheckVerification.Size = new System.Drawing.Size(123, 23);
            this.btnDebugCheckVerification.TabIndex = 6;
            this.btnDebugCheckVerification.Text = "Check Verification";
            this.btnDebugCheckVerification.UseVisualStyleBackColor = true;
            this.btnDebugCheckVerification.Click += new System.EventHandler(this.btnDebugCheckVerification_Click);
            // 
            // btnYtdlVersion
            // 
            this.btnYtdlVersion.Location = new System.Drawing.Point(8, 153);
            this.btnYtdlVersion.Name = "btnYtdlVersion";
            this.btnYtdlVersion.Size = new System.Drawing.Size(123, 23);
            this.btnYtdlVersion.TabIndex = 5;
            this.btnYtdlVersion.Text = "Youtube-Dl Version";
            this.btnYtdlVersion.UseVisualStyleBackColor = true;
            this.btnYtdlVersion.Click += new System.EventHandler(this.btnYtdlVersion_Click);
            // 
            // btnDebugThrowException
            // 
            this.btnDebugThrowException.Location = new System.Drawing.Point(8, 124);
            this.btnDebugThrowException.Name = "btnDebugThrowException";
            this.btnDebugThrowException.Size = new System.Drawing.Size(123, 23);
            this.btnDebugThrowException.TabIndex = 4;
            this.btnDebugThrowException.Text = "Throw exception";
            this.btnDebugThrowException.UseVisualStyleBackColor = true;
            this.btnDebugThrowException.Click += new System.EventHandler(this.btnDebugThrowException_Click);
            // 
            // btnDebugRotateQualityFormat
            // 
            this.btnDebugRotateQualityFormat.Location = new System.Drawing.Point(8, 95);
            this.btnDebugRotateQualityFormat.Name = "btnDebugRotateQualityFormat";
            this.btnDebugRotateQualityFormat.Size = new System.Drawing.Size(123, 23);
            this.btnDebugRotateQualityFormat.TabIndex = 3;
            this.btnDebugRotateQualityFormat.Text = "Rotate quality && format";
            this.btnDebugRotateQualityFormat.UseVisualStyleBackColor = true;
            this.btnDebugRotateQualityFormat.Click += new System.EventHandler(this.btnDebugRotateQualityFormat_Click);
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
            this.mSettings.Text = "ms";
            this.mSettings.Click += new System.EventHandler(this.mSettings_Click);
            // 
            // mTools
            // 
            this.mTools.Index = 1;
            this.mTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mBatchDownload,
            this.mBatchConverter,
            this.mArchiveDownloader,
            this.mMerger,
            this.mDownloadSubtitles,
            this.mMiscTools,
            this.mToolsSeparator,
            this.mClipboardAutoDownload,
            this.mClipboardAutoDownloadVerifyLinks});
            this.mTools.Text = "mt";
            // 
            // mBatchDownload
            // 
            this.mBatchDownload.Index = 0;
            this.mBatchDownload.Text = "mBatchDownload";
            this.mBatchDownload.Click += new System.EventHandler(this.mBatchDownload_Click);
            // 
            // mBatchConverter
            // 
            this.mBatchConverter.Index = 1;
            this.mBatchConverter.Text = "mBatchConverter";
            this.mBatchConverter.Click += new System.EventHandler(this.mBatchConverter_Click);
            // 
            // mArchiveDownloader
            // 
            this.mArchiveDownloader.Index = 2;
            this.mArchiveDownloader.Text = "mArchiveDownloader";
            this.mArchiveDownloader.Click += new System.EventHandler(this.mArchiveDownloader_Click);
            // 
            // mMerger
            // 
            this.mMerger.Index = 3;
            this.mMerger.Text = "mMerger";
            this.mMerger.Click += new System.EventHandler(this.mMerger_Click);
            // 
            // mDownloadSubtitles
            // 
            this.mDownloadSubtitles.Index = 4;
            this.mDownloadSubtitles.Text = "mDownloadSubtitles";
            this.mDownloadSubtitles.Click += new System.EventHandler(this.mDownloadSubtitles_Click);
            // 
            // mMiscTools
            // 
            this.mMiscTools.Index = 5;
            this.mMiscTools.Text = "mMiscTools";
            this.mMiscTools.Click += new System.EventHandler(this.mMiscTools_Click);
            // 
            // mToolsSeparator
            // 
            this.mToolsSeparator.Index = 6;
            this.mToolsSeparator.Text = "-";
            // 
            // mClipboardAutoDownload
            // 
            this.mClipboardAutoDownload.Index = 7;
            this.mClipboardAutoDownload.Text = "mClipboardAutoDownload";
            this.mClipboardAutoDownload.Click += new System.EventHandler(this.mClipboardAutoDownload_Click);
            // 
            // mClipboardAutoDownloadVerifyLinks
            // 
            this.mClipboardAutoDownloadVerifyLinks.Enabled = false;
            this.mClipboardAutoDownloadVerifyLinks.Index = 8;
            this.mClipboardAutoDownloadVerifyLinks.Text = "GenericVerifyLinks";
            this.mClipboardAutoDownloadVerifyLinks.Click += new System.EventHandler(this.mClipboardAutoDownloadVerifyLinks_Click);
            // 
            // mHelp
            // 
            this.mHelp.Index = 2;
            this.mHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mLanguage,
            this.mSupportedSites,
            this.mLog});
            this.mHelp.Text = "mh";
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
            // mLog
            // 
            this.mLog.Index = 2;
            this.mLog.Text = "mLog";
            this.mLog.Click += new System.EventHandler(this.mLog_Click);
            // 
            // mAbout
            // 
            this.mAbout.Index = 3;
            this.mAbout.Text = "ma";
            this.mAbout.Click += new System.EventHandler(this.mAbout_Click);
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
            this.cmTrayDownloadClipboard,
            this.cmDownloadSeparator,
            this.cmTrayClipboardAutoDownload,
            this.cmTrayClipboardAutoDownloadVerifyLinks});
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
            // cmDownloadSeparator
            // 
            this.cmDownloadSeparator.Index = 1;
            this.cmDownloadSeparator.Text = "-";
            // 
            // cmTrayClipboardAutoDownload
            // 
            this.cmTrayClipboardAutoDownload.Index = 2;
            this.cmTrayClipboardAutoDownload.Text = "mClipboardAutoDownload";
            this.cmTrayClipboardAutoDownload.Click += new System.EventHandler(this.cmTrayClipboardAutoDownload_Click);
            // 
            // cmTrayClipboardAutoDownloadVerifyLinks
            // 
            this.cmTrayClipboardAutoDownloadVerifyLinks.Checked = true;
            this.cmTrayClipboardAutoDownloadVerifyLinks.Enabled = false;
            this.cmTrayClipboardAutoDownloadVerifyLinks.Index = 3;
            this.cmTrayClipboardAutoDownloadVerifyLinks.Text = "GenericVerifyLinks";
            this.cmTrayClipboardAutoDownloadVerifyLinks.Click += new System.EventHandler(this.cmTrayClipboardAutoDownloadVerifyLinks_Click);
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
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 365);
            this.Controls.Add(this.tcMain);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;
            this.MaximizeBox = false;
            this.Menu = this.menu;
            this.MinimumSize = new System.Drawing.Size(262, 400);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "youtube-dl-gui";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tcMain.ResumeLayout(false);
            this.tabDownload.ResumeLayout(false);
            this.tabDownload.PerformLayout();
            this.gbSelection.ResumeLayout(false);
            this.gbSelection.PerformLayout();
            this.panelDate.ResumeLayout(false);
            this.panelDate.PerformLayout();
            this.panelPlaylistStartEnd.ResumeLayout(false);
            this.panelPlaylistStartEnd.PerformLayout();
            this.panelPlaylistItems.ResumeLayout(false);
            this.panelPlaylistItems.PerformLayout();
            this.gbDownloadType.ResumeLayout(false);
            this.gbDownloadType.PerformLayout();
            this.tabConvert.ResumeLayout(false);
            this.tabConvert.PerformLayout();
            this.tabMerge.ResumeLayout(false);
            this.tabMerge.PerformLayout();
            this.tabDebug.ResumeLayout(false);
            this.tabDebug.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbURL;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabDownload;
        private System.Windows.Forms.TabPage tabConvert;
        private System.Windows.Forms.MainMenu menu;
        private System.Windows.Forms.MenuItem mSettings;
        private System.Windows.Forms.MenuItem mHelp;
        private System.Windows.Forms.GroupBox gbDownloadType;
        private System.Windows.Forms.RadioButton rbCustom;
        private System.Windows.Forms.RadioButton rbAudio;
        private System.Windows.Forms.RadioButton rbVideo;
        private System.Windows.Forms.Label lbCustomArguments;
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
        private murrty.controls.SplitButton sbDownload;
        private System.Windows.Forms.ContextMenu cmDownload;
        private System.Windows.Forms.MenuItem mBatchDownloadFromFile;
        private System.Windows.Forms.MenuItem mLanguage;
        private System.Windows.Forms.TabPage tabDebug;
        private System.Windows.Forms.Button btnDebugForceUpdateCheck;
        private System.Windows.Forms.Button btnDebugForceAvailableUpdate;
        private System.Windows.Forms.Button btnDebugDownloadArgs;
        private System.Windows.Forms.ComboBox cbFormat;
        private System.Windows.Forms.Label lbFormat;
        private System.Windows.Forms.Button btnDebugRotateQualityFormat;
        public murrty.controls.ExtendedTextBox txtUrl;
        private System.Windows.Forms.MenuItem mDownloadWithAuthentication;
        private System.Windows.Forms.Button btnDebugThrowException;
        private System.Windows.Forms.Panel panelPlaylistStartEnd;
        private murrty.controls.ExtendedTextBox txtPlaylistEnd;
        private murrty.controls.ExtendedTextBox txtPlaylistStart;
        private System.Windows.Forms.Panel panelPlaylistItems;
        private murrty.controls.ExtendedTextBox txtPlaylistItems;
        private System.Windows.Forms.Panel panelDate;
        private murrty.controls.ExtendedTextBox txtVideoDate;
        private System.Windows.Forms.GroupBox gbSelection;
        private System.Windows.Forms.RadioButton rbVideoSelectionAfterDate;
        private System.Windows.Forms.RadioButton rbVideoSelectionBeforeDate;
        private System.Windows.Forms.RadioButton rbVideoSelectionOnDate;
        private System.Windows.Forms.RadioButton rbVideoSelectionPlaylistItems;
        private System.Windows.Forms.RadioButton rbVideoSelectionPlaylistIndex;
        private System.Windows.Forms.CheckBox chkUseSelection;
        private System.Windows.Forms.ComboBox cbCustomArguments;
        private System.Windows.Forms.Button btnYtdlVersion;
        private System.Windows.Forms.Button btnDebugCheckVerification;
        private System.Windows.Forms.CheckBox chkDebugDontDownload;
        private System.Windows.Forms.Label lbSchema;
        private System.Windows.Forms.ComboBox cbSchema;
        private System.Windows.Forms.MenuItem mBatchConverter;
        private System.Windows.Forms.MenuItem mClipboardAutoDownload;
        private System.Windows.Forms.MenuItem mClipboardAutoDownloadVerifyLinks;
        private System.Windows.Forms.MenuItem mToolsSeparator;
        private System.Windows.Forms.MenuItem cmTrayClipboardAutoDownload;
        private System.Windows.Forms.MenuItem cmTrayClipboardAutoDownloadVerifyLinks;
        private System.Windows.Forms.MenuItem cmDownloadSeparator;
        private System.Windows.Forms.MenuItem mDownloadSeparator;
        private System.Windows.Forms.MenuItem mQuickDownloadForm;
        private System.Windows.Forms.MenuItem mExtendedDownloadForm;
        private System.Windows.Forms.MenuItem mQuickDownloadFormAuthentication;
        private System.Windows.Forms.MenuItem mMerger;
        private System.Windows.Forms.MenuItem mArchiveDownloader;
        private System.Windows.Forms.MenuItem mLog;
    }
}

