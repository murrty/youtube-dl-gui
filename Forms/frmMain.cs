using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmMain : Form {
        #region variables
        Language lang = Language.GetInstance();
        Verification verif = Verification.GetInstance();

        public bool ProtocolInput = false;

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);
        private void SetTextBoxHint(IntPtr TextboxHandle, string Hint) {
            SendMessage(TextboxHandle, 0x1501, (IntPtr)1, Hint);
        }
        #endregion

        #region form
        [DebuggerStepThrough]
        protected override void WndProc(ref Message m) {
            if (m.Msg == Controller.WM_SHOWYTDLGUIFORM) {
                this.Show();
                if (this.WindowState != FormWindowState.Normal)
                    this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
            base.WndProc(ref m);
        }
        public frmMain() {
            InitializeComponent();
            verif.RefreshLocation();
            LoadLanguage();

            trayIcon.ContextMenu = cmTray;
            if (Program.IsDebug) {
                lbDebug.Text = "debugging " + Properties.Settings.Default.debugDate;
                lbDebug.Visible = true;
                trayIcon.Visible = false;
                trayIcon.Dispose();
            }
            else {
                trayIcon.Icon = Properties.Resources.youtube_dl_gui;
                tcMain.TabPages.RemoveAt(3);
                lbDebug.Visible = false;
            }
        }

        private void frmMain_Load(object sender, EventArgs e) {
            UpdateChecker.CheckForUpdate();
            this.Icon = Properties.Resources.youtube_dl_gui;
            if (Saved.Default.MainFormSize != default(System.Drawing.Size)) {
                this.Size = Saved.Default.MainFormSize;
            }
            if (!Program.IsDebug) {
                mDownloadSubtitles.Enabled = false;
            }


            if (Saved.Default.formTrue0) {
                this.Location = new Point(Saved.Default.formLocationX, Saved.Default.formLocationY);
            }
            else if (Saved.Default.formLocationX > 0 || Saved.Default.formLocationY > 0) {
                this.Location = new Point(Saved.Default.formLocationX, Saved.Default.formLocationY);
            }

            switch (General.Default.SaveCustomArgs) {
                case 1:
                    if (System.IO.File.Exists(Environment.CurrentDirectory + "\\args.txt"))
                        txtArgs.Text = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\args.txt");
                    break;
                case 2:
                    txtArgs.Text = Saved.Default.downloadArgs;
                    break;
            }
            switch (Saved.Default.downloadType) {
                case 0:
                    rbVideo.Checked = true;
                    break;
                case 1:
                    rbAudio.Checked = true;
                    break;
                case 2:
                    rbCustom.Checked = true;
                    break;
                default:
                    rbVideo.Checked = true;
                    break;
            }

            switch (Saved.Default.convertType) {
                case 0:
                    rbConvertVideo.Checked = true;
                    break;
                case 1:
                    rbConvertAudio.Checked = true;
                    break;
                case 2:
                    rbConvertCustom.Checked = true;
                    break;
                case 6:
                    rbConvertAutoFFmpeg.Checked = true;
                    break;
                default:
                    rbConvertAuto.Checked = true;
                    break;
            }
            CalculateLocations();

            if (ProtocolInput) {
                if (Downloads.Default.AutomaticallyDownloadFromProtocol) {
                    // download ...
                }
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.Location.X == 0 || this.Location.Y == 0) {
                Saved.Default.formTrue0 = true;
            }
            else {
                Saved.Default.formTrue0 = false;
            }
            Saved.Default.MainFormSize = this.Size;

            switch (General.Default.SaveCustomArgs) {
                case 1: // txt
                    System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\args.txt", txtArgs.Text.TrimEnd('\n'));
                    break;
                case 2: // settings
                    Saved.Default.downloadArgs = txtArgs.Text;
                    break;
            }

            if (rbVideo.Checked)
                Saved.Default.downloadType = 0;
            else if (rbAudio.Checked)
                Saved.Default.downloadType = 1;
            else if (rbCustom.Checked)
                Saved.Default.downloadType = 2;
            else
                Saved.Default.downloadType = -1;

            if (rbConvertVideo.Checked)
                Saved.Default.convertType = 0;
            else if (rbConvertAudio.Checked)
                Saved.Default.convertType = 1;
            else if (rbConvertCustom.Checked)
                Saved.Default.convertType = 2;
            else if (rbConvertAutoFFmpeg.Checked)
                Saved.Default.convertType = 6;
            else
                Saved.Default.convertType = -1;

            Saved.Default.formLocationX = this.Location.X;
            Saved.Default.formLocationY = this.Location.Y;

            if (Program.IsPortable) {
                CheckSettings.SavePortableSettings();
            }
            else {
                Saved.Default.Save();
            }
            trayIcon.Visible = false;
        }

        void LoadLanguage(bool ChangedLanguage = false) {
            if (Settings.Default.LanguageFile != string.Empty) {
                if (System.IO.File.Exists(Environment.CurrentDirectory + "\\lang\\" + Settings.Default.LanguageFile + ".ini")) {
                    lang.LoadLanguage(Environment.CurrentDirectory + "\\lang\\" + Settings.Default.LanguageFile + ".ini");
                }
                else {
                    lang.LoadInternalEnglish();
                }
            }
            else {
                lang.LoadInternalEnglish();

            }

            mSettings.Text = lang.mSettings;
            mTools.Text = lang.mTools;
            mBatchDownload.Text = lang.mBatchDownload;
            mDownloadSubtitles.Text = lang.mDownloadSubtitles;
            mMiscTools.Text = lang.mMiscTools;
            mHelp.Text = lang.mHelp;
            mLanguage.Text = lang.mLanguage;
            mSupportedSites.Text = lang.mSupportedSites;
            mAbout.Text = lang.mAbout;

            tabDownload.Text = lang.tabDownload;
            tabConvert.Text = lang.tabConvert;
            tabMerge.Text = lang.tabMerge;

            lbURL.Text = lang.lbURL;
            SetTextBoxHint(txtUrl.Handle, lang.txtUrlHint);
            gbDownloadType.Text = lang.gbDownloadType;
            rbVideo.Text = lang.rbVideo;
            rbAudio.Text = lang.rbAudio;
            rbCustom.Text = lang.rbCustom;
            lbQuality.Text = lang.lbQuality;
            lbFormat.Text = lang.lbFormat;
            chkDownloadSound.Text = lang.chkDownloadSound;
            lbCustomArguments.Text = lang.lbCustomArguments;
            SetTextBoxHint(txtArgs.Handle, lang.txtArgsHint);
            sbDownload.Text = lang.sbDownload;
            mBatchDownloadFromFile.Text = lang.mBatchDownloadFromFile;
            lbDownloadStatus.Text = "...";

            lbConvertInput.Text = lang.lbConvertInput;
            lbConvertOutput.Text = lang.lbConvertOutput;
            rbConvertVideo.Text = lang.rbConvertVideo;
            rbConvertAudio.Text = lang.rbConvertAudio;
            rbConvertCustom.Text = lang.rbConvertCustom;
            rbConvertAuto.Text = lang.rbConvertAuto;
            rbConvertAutoFFmpeg.Text = lang.rbConvertAutoFFmpeg;
            btnConvert.Text = lang.btnConvert;
            lbConvertStatus.Text = "...";

            lbMergeInput1.Text = lang.lbMergeInput1;
            lbMergeInput2.Text = lang.lbMergeInput2;
            lbMergeOutput.Text = lang.lbMergeOutput;
            chkMergeAudioTracks.Text = lang.chkMergeAudioTracks;
            chkMergeDeleteInputFiles.Text = lang.chkMergeDeleteInputFiles;
            btnMerge.Text = lang.btnMerge;

            cmTrayShowForm.Text = lang.cmTrayShowForm;
            cmTrayDownloader.Text = lang.cmTrayDownloader;
            cmTrayDownloadClipboard.Text = lang.cmTrayDownloadClipboard;
            cmTrayDownloadBestVideo.Text = lang.cmTrayDownloadBestVideo;
            cmTrayDownloadBestAudio.Text = lang.cmTrayDownloadBestAudio;
            cmTrayDownloadCustom.Text = lang.cmTrayDownloadCustom;
            cmTrayDownloadCustomTxtBox.Text = lang.cmTrayDownloadCustomTxtBox;
            cmTrayDownloadCustomTxt.Text = lang.cmTrayDownloadCustomTxt;
            cmTrayDownloadCustomSettings.Text = lang.cmTrayDownloadCustomSettings;
            cmTrayConverter.Text = lang.cmTrayConverter;
            cmTrayConvertTo.Text = lang.cmTrayConvertTo;
            cmTrayConvertVideo.Text = lang.cmTrayConvertVideo;
            cmTrayConvertAudio.Text = lang.cmTrayConvertAudio;
            cmTrayConvertCustom.Text = lang.cmTrayConvertCustom;
            cmTrayConvertAutomatic.Text = lang.cmTrayConvertAutomatic;
            cmTrayConvertAutoFFmpeg.Text = lang.cmTrayConvertAutoFFmpeg;
            cmTrayExit.Text = lang.cmTrayExit;

            if (cbFormat.Items.Count > 0) {
                cbFormat.Items[0] = lang.GenericInputBest;
            }
            if (cbQuality.Items.Count > 0) {
                cbQuality.Items[0] = lang.GenericInputBest;
            }

            CalculateLocations();
        }
        void CalculateLocations() {
            gbDownloadType.Size = new Size(((rbVideo.Size.Width + 2) + rbAudio.Size.Width +  (rbCustom.Size.Width - 2)) + 12, gbDownloadType.Size.Height);
            gbDownloadType.Location = new System.Drawing.Point(
                (tabDownload.Size.Width - gbDownloadType.Size.Width) / 2,
                gbDownloadType.Location.Y
                );

            rbVideo.Location = new System.Drawing.Point(
                (gbDownloadType.Size.Width - (rbVideo.Size.Width + rbAudio.Size.Width + rbCustom.Size.Width)) / 2,
                rbVideo.Location.Y
                );
            rbAudio.Location = new System.Drawing.Point(
                (rbVideo.Location.X + rbVideo.Size.Width) + 2,
                rbAudio.Location.Y
                );
            rbCustom.Location = new System.Drawing.Point(
                ((rbAudio.Location.X + rbAudio.Size.Width) + 2),
                rbCustom.Location.Y
                );

            rbConvertVideo.Location = new System.Drawing.Point(
                (tabConvert.Size.Width - (rbConvertVideo.Size.Width + rbConvertAudio.Size.Width + rbConvertCustom.Size.Width)) / 2,
                rbConvertVideo.Location.Y
                );
            rbConvertAudio.Location = new System.Drawing.Point(
                (rbConvertVideo.Location.X + rbConvertVideo.Width) - 2,
                rbConvertVideo.Location.Y
                );
            rbConvertCustom.Location = new System.Drawing.Point(
                (rbConvertAudio.Location.X + rbConvertAudio.Size.Width) + 2,
                rbConvertAudio.Location.Y
                );
            rbConvertAuto.Location = new System.Drawing.Point(
                ((tabConvert.Size.Width / 2) - ((rbConvertAuto.Width + rbConvertAutoFFmpeg.Width) / 2)),
                rbConvertAuto.Location.Y
                );
            rbConvertAutoFFmpeg.Location = new System.Drawing.Point(
                (rbConvertAuto.Location.X + rbConvertAuto.Size.Width) + 2,
                rbConvertAutoFFmpeg.Location.Y
                );

            chkMergeAudioTracks.Location = new System.Drawing.Point(
                (tabMerge.Size.Width - chkMergeAudioTracks.Size.Width) / 2,
                chkMergeAudioTracks.Location.Y
                );
            chkMergeDeleteInputFiles.Location = new System.Drawing.Point(
                (tabMerge.Size.Width - chkMergeDeleteInputFiles.Size.Width) / 2,
                chkMergeDeleteInputFiles.Location.Y
                );
        }
        #endregion

        #region main menu
        private void mSettings_Click(object sender, EventArgs e) {
            using (frmSettings settings = new frmSettings()) { settings.ShowDialog(); }
        }

        private void mBatchDownload_Click(object sender, EventArgs e) {
            frmBatchDownloader batch = new frmBatchDownloader();
            batch.Show();
        }
        private void mDownloadSubtitles_Click(object sender, EventArgs e) {
            using (frmSubtitles downloadSubtitles = new frmSubtitles()) { downloadSubtitles.ShowDialog(); }
        }
        private void mMiscTools_Click(object sender, EventArgs e) {
            using (frmMiscTools tools = new frmMiscTools()) { tools.ShowDialog(); }
        }

        private void mLanguage_Click(object sender, EventArgs e) {
            using (frmLanguage language = new frmLanguage()) {
                switch (language.ShowDialog()) {
                    case System.Windows.Forms.DialogResult.Yes:
                        if (language.LanguageFile == null) { Settings.Default.LanguageFile = string.Empty; }
                        else { Settings.Default.LanguageFile = language.LanguageFile; }
                        if (!Program.IsPortable) {
                            Settings.Default.Save();
                        }
                        else {
                            Ini.WriteString("LanguageFile", language.LanguageFile, "Settings");
                        }
                        LoadLanguage(true);
                        CalculateLocations();
                        break;
                }
            }
        }
        private void mSupportedSites_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://ytdl-org.github.io/youtube-dl/supportedsites.html");
        }

        private void mAbout_Click(object sender, EventArgs e) {
            using (frmAbout about = new frmAbout()) { about.ShowDialog(); }
        }
        #endregion

        #region tray menu
        private void cmTrayShowForm_Click(object sender, EventArgs e) {
            this.Show();
        }

        private void cmTrayDownloadBestVideo_Click(object sender, EventArgs e) {
            if (!Clipboard.ContainsText()) { return; }
            frmDownloader Downloader = new frmDownloader();
            Downloader.DownloadPath = Downloads.Default.downloadPath;
            Downloader.DownloadQuality = Saved.Default.videoQuality;
            Downloader.DownloadType = 0;
            Downloader.DownloadUrl = Clipboard.GetText();
            Downloader.Show();
        }

        private void cmTrayDownloadBestAudio_Click(object sender, EventArgs e) {
            frmDownloader Downloader = new frmDownloader();
            Downloader.DownloadPath = Downloads.Default.downloadPath;
            Downloader.DownloadQuality = Saved.Default.audioQuality;
            Downloader.DownloadType = 1;
            Downloader.DownloadUrl = Clipboard.GetText();
            Downloader.Show();
        }

        private void cmTrayDownloadCustomTxtBox_Click(object sender, EventArgs e) {
            if (!Clipboard.ContainsText()) { return; }

            if (string.IsNullOrEmpty(txtArgs.Text)) {
                MessageBox.Show("No arguments are currently in memory. Enter in custom arguments in the arguments text box on the main form.");
                return;
            }
            else {
                frmDownloader Downloader = new frmDownloader();
                Downloader.DownloadArguments = txtArgs.Text;
                Downloader.DownloadPath = Downloads.Default.downloadPath;
                Downloader.DownloadQuality = -1;
                Downloader.DownloadType = 2;
                Downloader.DownloadUrl = Clipboard.GetText();
                Downloader.Show();
            }
        }
        private void cmTrayDownloadCustomTxt_Click(object sender, EventArgs e) {
            if (!Clipboard.ContainsText()) { return; }

            if (!System.IO.File.Exists(Environment.CurrentDirectory + "\\args.txt")) {
                MessageBox.Show("args.txt does not exist, create it and put in arguments to use this command");
                return;
            }
            else if (string.IsNullOrEmpty(System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\args.txt"))) {
                MessageBox.Show("args.txt is empty, save arguments to the file to use this command");
                return;
            }
            else {
                frmDownloader Downloader = new frmDownloader();
                Downloader.DownloadArguments = System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\args.txt");
                Downloader.DownloadPath = Downloads.Default.downloadPath;
                Downloader.DownloadQuality = -1;
                Downloader.DownloadType = 2;
                Downloader.DownloadUrl = Clipboard.GetText();
                Downloader.Show();
            }
        }
        private void cmTrayDownloadCustomSettings_Click(object sender, EventArgs e) {
            if (!Clipboard.ContainsText()) { return; }
            if (string.IsNullOrEmpty(Saved.Default.downloadArgs)) {
                MessageBox.Show("No arguments are saved in the application settings, save arguments to the settings to use this command");
                return;
            }
            else
            {
                frmDownloader Downloader = new frmDownloader();
                Downloader.DownloadArguments = Saved.Default.downloadArgs;
                Downloader.DownloadPath = Downloads.Default.downloadPath;
                Downloader.DownloadQuality = -1;
                Downloader.DownloadType = 2;
                Downloader.DownloadUrl = Clipboard.GetText();
                Downloader.Show();
            }
        }

        private void cmTrayConvertVideo_Click(object sender, EventArgs e) {
            convertFromTray(0);
        }
        private void cmTrayConvertAudio_Click(object sender, EventArgs e) {
            convertFromTray(1);
        }
        private void cmTrayConvertCustom_Click(object sender, EventArgs e) {
            convertFromTray(2);
        }
        private void cmTrayConvertAutomatic_Click(object sender, EventArgs e) {
            convertFromTray();
        }
        private void cmTrayConvertAutoFFmpeg_Click(object sender, EventArgs e) {
            convertFromTray(6);
        }

        private void cmTrayExit_Click(object sender, EventArgs e) {
            if (Program.IsPortable) {
                CheckSettings.SavePortableSettings();
            }
            else {
                Saved.Default.Save();
            }
            trayIcon.Visible = false;
            Environment.Exit(0);
        }
        #endregion

        #region downloader
        private void rbVideo_CheckedChanged(object sender, EventArgs e) {
            if (rbVideo.Checked) {
                cbQuality.SelectedIndex = -1;
                cbQuality.Items.Clear();
                cbQuality.Items.AddRange(DownloadFormats.VideoQualityArray);
                cbQuality.Items[0] = lang.GenericInputBest;
                cbFormat.SelectedIndex = -1;
                cbFormat.Items.Clear();
                cbFormat.Items.AddRange(DownloadFormats.VideoFormatsNamesArray);
                cbFormat.Items[0] = lang.GenericInputBest;
                cbQuality.Enabled = true;
                cbFormat.Enabled = true;
                chkDownloadSound.Enabled = true;
                chkDownloadSound.Text = "Sound";
                if (Downloads.Default.SaveFormatQuality) {
                    cbQuality.SelectedIndex = Saved.Default.videoQuality;
                    cbFormat.SelectedIndex = Saved.Default.VideoFormat;
                    chkDownloadSound.Checked = Downloads.Default.VideoDownloadSound;
                }
                else {
                    cbQuality.SelectedIndex = 0;
                    cbFormat.SelectedIndex = 0;
                }
            }
        }
        private void rbAudio_CheckedChanged(object sender, EventArgs e) {
            if (rbAudio.Checked) {
                cbQuality.SelectedIndex = -1;
                cbFormat.SelectedIndex = -1;
                cbQuality.Items.Clear();
                cbFormat.Items.Clear();
                cbQuality.Enabled = true;
                cbFormat.Enabled = true;
                chkDownloadSound.Enabled = true;
                chkDownloadSound.Checked = Downloads.Default.AudioDownloadAsVBR;
                chkDownloadSound.Text = "Use VBR";
            }
        }
        private void rbCustom_CheckedChanged(object sender, EventArgs e) {
            if (rbCustom.Checked) {
                txtArgs.ReadOnly = false;
                cbQuality.SelectedIndex = -1;
                cbFormat.SelectedIndex = -1;
                cbQuality.Enabled = false;
                cbFormat.Enabled = false;
                chkDownloadSound.Checked = false;
                chkDownloadSound.Enabled = false;
                if (Downloads.Default.SaveFormatQuality) {
                    txtArgs.Text = Saved.Default.downloadArgs;
                }
            }
            else {
                txtArgs.ReadOnly = true;
            }
        }
        private void chkDownloadSound_CheckedChanged(object sender, EventArgs e) {
            if (rbAudio.Checked) {
                cbFormat.Items.AddRange(DownloadFormats.AudioFormatsArray);
                cbFormat.Items[0] = lang.GenericInputBest;

                if (chkDownloadSound.Checked) {
                    cbQuality.SelectedIndex = -1;
                    cbQuality.Items.AddRange(new string[]{"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"});
                    if (Downloads.Default.SaveFormatQuality) {
                        cbQuality.SelectedIndex = Saved.Default.AudioVBRQuality;
                        cbFormat.SelectedIndex = Saved.Default.AudioFormat;
                    }
                    else {
                        cbQuality.SelectedIndex = 0;
                        cbFormat.SelectedIndex = 0;
                    }
                }
                else {
                    cbQuality.Items.AddRange(DownloadFormats.AudioQualityNamesArray);
                    cbQuality.Items[0] = lang.GenericInputBest;
                    if (Downloads.Default.SaveFormatQuality) {
                        cbQuality.SelectedIndex = Saved.Default.audioQuality;
                        cbFormat.SelectedIndex = Saved.Default.AudioFormat;
                    }
                    else {
                        cbQuality.SelectedIndex = 0;
                        cbFormat.SelectedIndex = 0;
                    }
                }
            }
        }

        private void txtUrl_MouseEnter(object sender, EventArgs e) {
            if (General.Default.HoverOverURLTextBoxToPaste && txtUrl.Text != Clipboard.GetText()) {
                txtUrl.Text = Clipboard.GetText();
            }
        }
        private void txtUrl_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                StartDownload();
            }
        }
        private void txtArgs_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                StartDownload();
            }
        }
        private void tmrDownloadLabel_Tick(object sender, EventArgs e) {
            if (!lbDownloadStatus.Visible) {
                lbDownloadStatus.Visible = true;
            }
            else {
                lbDownloadStatus.Visible = false;
                tmrDownloadLabel.Enabled = false;
            }
        }
        private void sbDownload_Click(object sender, EventArgs e) {
            StartDownload();
        }
        private void mBatchDownloadFromFile_Click(object sender, EventArgs e) {
            // Todo: translation

            if (!Downloads.Default.SkipBatchTip) {
                switch (MessageBox.Show("Create a text file and put all the video links you want to download into it, separated as one per line.\nDo you want to skip seeing this message when batch downloading?", "youtube-dl-gui", MessageBoxButtons.YesNoCancel)) {
                    case System.Windows.Forms.DialogResult.Cancel:
                        return;
                    case System.Windows.Forms.DialogResult.Yes:
                        Downloads.Default.SkipBatchTip = true;
                        if (!Program.IsPortable) {
                            Downloads.Default.Save();
                        }
                        else {
                            CheckSettings.SavePortableSettings();
                        }
                        break;
                }
            }

            string TextFile = string.Empty;
            using (OpenFileDialog ofd = new OpenFileDialog()){
                ofd.Filter = "Text Document (*.txt)|*.txt";
                ofd.Title = "Select a file with URLs...";
                ofd.Multiselect = false;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                if (ofd.ShowDialog() == DialogResult.OK) {
                    TextFile = ofd.FileName;
                }
                else {
                    return;
                }
            }

            Thread BatchThread = new Thread(() => {
                string videoArguments = string.Empty;
                int DownloadType = 0;
                int BatchQuality = 0;

                this.BeginInvoke(new MethodInvoker(() => {
                    if (!chkDownloadSound.Checked) { videoArguments += "-nosound"; }
                    BatchQuality = cbQuality.SelectedIndex;
                    if (rbVideo.Checked) { DownloadType = 0; }
                    else if (rbAudio.Checked) { DownloadType = 1; }
                    else if (rbCustom.Checked) { DownloadType = 2; }
                    else { DownloadType = 3; }
                }));

                if (System.IO.File.Exists(TextFile)) {
                    string[] ReadFile = System.IO.File.ReadAllLines(TextFile);
                    if (ReadFile.Length == 0) {
                        return;
                    }
                    for (int i = 0; i < ReadFile.Length; i++) {
                        using (frmDownloader Downloader = new frmDownloader()) {
                            Downloader.BatchDownload = true;
                            switch (DownloadType) {
                                case 0:
                                    Downloader.DownloadArguments = videoArguments;
                                    Downloader.DownloadPath = Downloads.Default.downloadPath;
                                    Downloader.DownloadQuality = BatchQuality;
                                    Downloader.DownloadType = 0;
                                    Downloader.DownloadUrl = ReadFile[i].Trim(' ');
                                    Downloader.ShowDialog();
                                    break;
                                case 1:
                                    Downloader.DownloadPath = Downloads.Default.downloadPath;
                                    Downloader.DownloadQuality = BatchQuality;
                                    Downloader.DownloadType = 1;
                                    Downloader.DownloadUrl = ReadFile[i].Trim(' ');
                                    Downloader.ShowDialog();
                                    break;
                                case 2:
                                    Downloader.DownloadArguments = txtArgs.Text;
                                    Downloader.DownloadPath = Downloads.Default.downloadPath;
                                    Downloader.DownloadQuality = 0;
                                    Downloader.DownloadType = 2;
                                    Downloader.DownloadUrl = ReadFile[i].Trim(' ');
                                    Downloader.ShowDialog();
                                    break;
                                case 3:
                                    Downloader.DownloadPath = Downloads.Default.downloadPath;
                                    Downloader.DownloadQuality = 0;
                                    Downloader.DownloadType = 0;
                                    Downloader.DownloadUrl = ReadFile[i].Trim(' ');
                                    Downloader.ShowDialog();
                                    break;
                            }
                        }
                    }
                }
            });
            BatchThread.Start();
        }

        [DebuggerStepThrough]
        private void StartDownload() {
            if (string.IsNullOrEmpty(txtUrl.Text)) { return; }
            frmDownloader Downloader = new frmDownloader();
            if (rbVideo.Checked) {
                Downloader.DownloadPath = Downloads.Default.downloadPath;
                Downloader.DownloadQuality = cbQuality.SelectedIndex;
                Downloader.DownloadFormat = cbFormat.SelectedIndex;
                Downloader.DownloadType = 0;
                Downloader.Set60FPS = cbQuality.GetItemText(cbQuality.SelectedItem).EndsWith("p60");
                Downloader.DownloadVideoAudio = chkDownloadSound.Checked;
                Downloader.DownloadUrl = txtUrl.Text;
                Downloader.Show();
                Saved.Default.downloadType = 0;
                Saved.Default.videoQuality = cbQuality.SelectedIndex;
                Saved.Default.VideoFormat = cbFormat.SelectedIndex;
                Downloads.Default.VideoDownloadSound = chkDownloadSound.Checked;
            }
            else if (rbAudio.Checked) {
                Downloader.DownloadType = 1;
                Downloader.DownloadPath = Downloads.Default.downloadPath;
                Downloader.DownloadQuality = cbQuality.SelectedIndex;
                Downloader.UseVBR = chkDownloadSound.Checked;
                Downloader.DownloadFormat = cbFormat.SelectedIndex;
                Downloader.DownloadUrl = txtUrl.Text;
                Downloader.Show();
                Saved.Default.downloadType = 1;
                Saved.Default.audioQuality = cbQuality.SelectedIndex;
                Saved.Default.AudioFormat = cbFormat.SelectedIndex;
                Downloads.Default.AudioDownloadAsVBR = chkDownloadSound.Checked;
            }
            else if (rbCustom.Checked) {
                Downloader.DownloadType = 2;
                Downloader.DownloadArguments = txtArgs.Text;
                Downloader.DownloadPath = Downloads.Default.downloadPath;
                Downloader.DownloadQuality = -1;
                Downloader.DownloadUrl = txtUrl.Text;
                Downloader.Show();
                Saved.Default.downloadType = 2;
                Saved.Default.downloadArgs = txtArgs.Text;
            }
            else {
                Downloader.Dispose();
                try {
                    throw new Exception("Video, Audio, or Custom was not selected in the form, please select an actual download option to proceed.");
                }
                catch (Exception ex) {
                    ErrorLog.ReportException(ex);
                }
            }

            if (Downloads.Default.SaveFormatQuality && !Program.IsPortable) {
                Saved.Default.Save();
            }

            if (General.Default.ClearURLOnDownload) {
                txtUrl.Clear();
            }
            if (General.Default.ClearClipboardOnDownload) {
                Clipboard.Clear();
            }

            if (!Program.IsPortable) {
                Downloads.Default.Save();
            }
        }
        #endregion

        #region converter
        private void btnConvertInput_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Browse for file to convert";
                ofd.AutoUpgradeEnabled = true;
                string filter = Convert.getCustomExtensions() + Convert.allVideoFormats + "|" + Convert.allAudioFormats + "|" + Convert.allMediaFormats + "|" + Convert.allFormatsFilter;

                ofd.Filter = filter;
                ofd.FilterIndex = 4;
                if (!string.IsNullOrEmpty(txtConvertOutput.Text))
                    btnConvert.Enabled = true;

                if (ofd.ShowDialog() == DialogResult.OK) {
                    txtConvertInput.Text = ofd.FileName;
                    btnConvertOutput.Enabled = true;

                    string fileWithoutExt  = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
                    using (SaveFileDialog sfd = new SaveFileDialog()) { 
                        sfd.Title = "Save ouput to...";
                        sfd.FileName = fileWithoutExt;
                        if (rbConvertVideo.Checked) {
                            sfd.Filter = Convert.allVideoFormats + "|" + Convert.allAudioFormats + "|" + Convert.allMediaFormats + "|" + Convert.videoFormatsFilter;
                            if (Saved.Default.convertSaveVideoIndex > -1 && Converts.Default.detectFiletype)
                                sfd.FilterIndex = Saved.Default.convertSaveVideoIndex;
                            else
                                sfd.FilterIndex = 7;
                        }
                        else if (rbConvertAudio.Checked) {
                            sfd.Filter = Convert.allVideoFormats + "|" + Convert.allAudioFormats + "|" + Convert.allMediaFormats + "|" + Convert.audioFormatsFilter;
                            if (Saved.Default.convertSaveAudioIndex > -1 && Converts.Default.detectFiletype)
                                sfd.FilterIndex = Saved.Default.convertSaveAudioIndex;
                            else
                                sfd.FilterIndex = 7;
                        }
                        else {
                            sfd.Filter = Convert.allVideoFormats + "|" + Convert.allAudioFormats + "|" + Convert.allMediaFormats + "|" + "All File Formats (*.*)|(*.*)";
                        }
                        if (sfd.ShowDialog() == DialogResult.OK) {
                            txtConvertOutput.Text = sfd.FileName;
                            if (rbConvertVideo.Checked && Converts.Default.detectFiletype)
                                Saved.Default.convertSaveAudioIndex = sfd.FilterIndex;
                            else if (rbConvertAudio.Checked && Converts.Default.detectFiletype)
                                Saved.Default.convertSaveVideoIndex = sfd.FilterIndex;

                            btnConvert.Enabled = true;
                        }
                    }
                }
            }
        }

        private void btnConvertOutput_Click(object sender, EventArgs e) {
            using (SaveFileDialog sfd = new SaveFileDialog()) {
                sfd.Title = "Save ouput to...";
                sfd.FileName = System.IO.Path.GetFileNameWithoutExtension(txtConvertInput.Text);
                if (rbConvertVideo.Checked) {
                    string filter = Convert.getCustomExtensions() + Convert.videoFormatsFilter;
                    sfd.Filter = filter;
                    if (Saved.Default.convertSaveVideoIndex > -1 && Converts.Default.detectFiletype)
                        sfd.FilterIndex = Saved.Default.convertSaveVideoIndex;
                    else
                        sfd.FilterIndex = 7;
                }
                else if (rbConvertAudio.Checked) {
                    string filter = Convert.getCustomExtensions() +  Convert.audioFormatsFilter;
                    if (Settings.Default.extensionsShort.Length > 0) {
                        List<string> ext = new List<string>(Settings.Default.extensionsShort.Split('|'));
                        List<string> name = new List<string>(Settings.Default.extensionsName.Split('|'));

                        for (int i = 0; i < ext.Count; i++) {
                            filter += "|" + name[i] + " (*." + ext[i] + ")|*." + ext[i];
                        }
                    }
                    sfd.Filter = filter;
                    if (Saved.Default.convertSaveAudioIndex > -1 && Converts.Default.detectFiletype)
                        sfd.FilterIndex = Saved.Default.convertSaveAudioIndex;
                    else
                        sfd.FilterIndex = 7;
                }
                else {
                    sfd.Filter = Convert.getCustomExtensions() + Convert.allVideoFormats + "|" + Convert.allAudioFormats + "|" + Convert.allMediaFormats + "|" + Convert.allFormatsFilter;
                }
                if (sfd.ShowDialog() == DialogResult.OK) {
                    txtConvertOutput.Text = sfd.FileName;
                    if (rbConvertVideo.Checked && Converts.Default.detectFiletype)
                        Saved.Default.convertSaveAudioIndex = sfd.FilterIndex;
                    else if (rbConvertAudio.Checked && Converts.Default.detectFiletype)
                        Saved.Default.convertSaveVideoIndex = sfd.FilterIndex;

                    btnConvert.Enabled = true;
                }
            }
        }

        private void tmrConvertLabel_Tick(object sender, EventArgs e) {
            if (!lbConvertStatus.Visible) {
                lbConvertStatus.Visible = true;
            }
            else {
                lbConvertStatus.Visible = false;
                tmrConvertLabel.Enabled = false;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e) {
            btnConvert.Enabled = false;
            btnConvertInput.Enabled = false;
            btnConvertOutput.Enabled = false;

            int convType = -1;

            if (rbConvertVideo.Checked)
                convType = 0;
            else if (rbConvertAudio.Checked)
                convType = 1;
            else if (rbConvertCustom.Checked)
                convType = 2;
            else if (rbConvertAutoFFmpeg.Checked)
                convType = 6;

            if (Convert.convertFile(txtConvertInput.Text, txtConvertOutput.Text, convType)) {
                lbConvertStatus.Text = "Conversion started";
                tmrConvertLabel.Enabled = true;
                if (Converts.Default.clearOutput) {
                    txtConvertOutput.Clear();
                    btnConvert.Enabled = false;
                }
                if (Converts.Default.clearInput) {
                    txtConvertInput.Clear();
                    btnConvert.Enabled = false;
                }
            }
            else {
                lbConvertStatus.Text = "Conversion failed";
                tmrConvertLabel.Enabled = true;
            }

            btnConvert.Enabled = true;
            btnConvertInput.Enabled = true;
            btnConvertOutput.Enabled = true;

            Saved.Default.convertType = convType;
            if (!Program.IsPortable) {
                Saved.Default.Save();
            }

            GC.Collect();
        }

        private void convertFromTray(int conversionType = -1) {
            // -1 = automatic
            // 0 = video
            // 1 = audio
            // 2 = custom
            // 6 = ffmpeg auto

            string inputFile = string.Empty;
            string outputFile = string.Empty;

            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Browse for file to convert";
                if (ofd.ShowDialog() == DialogResult.OK) {
                    txtConvertInput.Text = ofd.FileName;
                    string fileWithoutExt = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
                    btnConvertOutput.Enabled = true;

                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "Save ouput to...";
                    sfd.FileName = fileWithoutExt;
                    switch (conversionType) {
                        case 0:
                            sfd.Filter = Convert.videoFormatsFilter;
                            if (Saved.Default.convertSaveVideoIndex > -1 && Converts.Default.detectFiletype)
                                sfd.FilterIndex = Saved.Default.convertSaveVideoIndex;
                        else
                            sfd.FilterIndex = 7;
                            break;
                        case 1:
                            sfd.Filter = Convert.audioFormatsFilter;
                            if (Saved.Default.convertSaveAudioIndex > -1 && Converts.Default.detectFiletype)
                                sfd.FilterIndex = Saved.Default.convertSaveAudioIndex;
                            else
                                sfd.FilterIndex = 7;
                            break;
                        default:
                            sfd.Filter = "All File Formats (*.*)|*.*";
                            break;
                    }
                    if (sfd.ShowDialog() == DialogResult.OK) {
                        inputFile = sfd.FileName;
                    }
                }
            }

            using (SaveFileDialog sfd = new SaveFileDialog()) {
                sfd.Title = "Save ouput to...";
                sfd.FileName = System.IO.Path.GetFileNameWithoutExtension(txtConvertInput.Text);
                switch (conversionType) {
                    case 0:
                        sfd.Filter = Convert.videoFormatsFilter;
                        if (Saved.Default.convertSaveVideoIndex > -1 && Converts.Default.detectFiletype)
                            sfd.FilterIndex = Saved.Default.convertSaveVideoIndex;
                        else
                            sfd.FilterIndex = 7;
                        break;
                    case 1:
                        sfd.Filter = Convert.audioFormatsFilter;
                        if (Saved.Default.convertSaveAudioIndex > -1 && Converts.Default.detectFiletype)
                            sfd.FilterIndex = Saved.Default.convertSaveAudioIndex;
                        else
                            sfd.FilterIndex = 7;
                        break;
                    default:
                        sfd.Filter = "All File Formats (*.*)|(*.*)";
                        break;
                }

                if (sfd.ShowDialog() == DialogResult.OK) {
                    txtConvertOutput.Text = sfd.FileName;
                }
            }

            Convert.convertFile(inputFile, outputFile, conversionType);
        }
        #endregion

        #region merger
        private void btnBrwsMergeInput1_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Browsing for file to convert";
                ofd.Filter = Convert.allMediaFormats;
                if (ofd.ShowDialog() == DialogResult.OK) {
                    txtMergeInput1.Text = ofd.FileName;
                    btnBrwsMergeInput2.Enabled = true;
                    txtMergeOutput.Text = System.IO.Path.GetDirectoryName(ofd.FileName) + "\\" + System.IO.Path.GetFileNameWithoutExtension(ofd.FileName) + "-merged" + System.IO.Path.GetExtension(ofd.FileName);
                }
            }
        }
        private void btnBrwsMergeInput2_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Browsing for file to convert";
                ofd.Filter = Convert.allMediaFormats;
                if (ofd.ShowDialog() == DialogResult.OK) {
                    txtMergeInput2.Text = ofd.FileName;
                    btnBrwsMergeOutput.Enabled = true;
                    if (!string.IsNullOrEmpty(txtMergeOutput.Text)) {
                        btnMerge.Enabled = true;
                    }
                }
            }
        }
        private void btnBrwsMergeOutput_Click(object sender, EventArgs e) {
            using (SaveFileDialog sfd = new SaveFileDialog()) {
                sfd.Title = "Browsing for file to convert";
                sfd.Filter = Convert.allMediaFormats;
                if (sfd.ShowDialog() == DialogResult.OK) {
                    txtMergeOutput.Text = sfd.FileName;
                    btnMerge.Enabled = true;
                }
            }
        }

        private void btnMerge_Click(object sender, EventArgs e) {
            Convert.mergeFiles(txtMergeInput1.Text, txtMergeInput2.Text, txtMergeOutput.Text, chkMergeAudioTracks.Checked, chkMergeDeleteInputFiles.Checked);
        }
        #endregion

        #region debug
        private void btnDebugForceUpdateCheck_Click(object sender, EventArgs e) {
            UpdateChecker.CheckForUpdate(true);
        }
        private void btnDebugForceAvailableUpdate_Click(object sender, EventArgs e) {
            UpdateChecker.UpdateDebug.UpdateAvailable();
        }
        private void btnDebugDownloadArgs_Click(object sender, EventArgs e) {
            if (!Clipboard.ContainsText()) { return; }
            frmDownloader Downloader = new frmDownloader();
            Downloader.DownloadPath = Downloads.Default.downloadPath;
            Downloader.DownloadQuality = Saved.Default.videoQuality;
            Downloader.DownloadType = 0;
            Downloader.DownloadUrl = Clipboard.GetText();
            Downloader.Debugging = true;
            Downloader.BatchDownload = true;
            Downloader.Show();
        }
        #endregion

        private void btnDebugRotateQualityFormat_Click(object sender, EventArgs e) {
            Point s = lbQuality.Location;
            Point t = lbFormat.Location;
            Point u = cbQuality.Location;
            Point v = cbFormat.Location;

            lbQuality.Location = t;
            lbFormat.Location = s;
            cbQuality.Location = v;
            cbFormat.Location = u;
        }

    }
}
