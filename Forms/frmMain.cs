using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmMain : Form {
        #region variables
        int ytDlAvailable = -1;
        int ffmpegAvailable = -1;
        string[] videoQuality = {
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
                                    "144p"
                                };
        string[] audioQuality = {
                                    "best",
                                    "320k",
                                    "256k",
                                    "224k",
                                    "192k",
                                    "160k",
                                    "128k",
                                    "96k",
                                    "64k"
                                };

        bool Debug = false;
        List<Thread> BatchDownloads = new List<Thread>();   // List of batch download threads
        List<int> BatchCount = new List<int>();             // Int list of positions of the batch download threads
        Language lang = Language.GetInstance();

        //TextBox Hint
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);
        /// <summary>
        /// Set a hint for a Textbox.
        /// </summary>
        /// <param name="TextboxHandle">The handle for the text box. (Usually TextBox.Handle)</param>
        /// <param name="Hint">The string that should be set as the hint.</param>
        private void SetTextBoxHint(IntPtr TextboxHandle, string Hint) {
            SendMessage(TextboxHandle, 0x1501, (IntPtr)1, Hint);
        }
        #endregion

        #region form
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
            Debug = Environment.GetCommandLineArgs().Contains("-debug") ? Debug = true : Debug = false;

            bool SkipLanguage = false;

            if (!SkipLanguage) {
                LoadLanguage();
            }



            if (Debug) {
                lbDebug.Text = Properties.Settings.Default.debugDate;
                lbDebug.Visible = true;
            }
            else {
                tcMain.TabPages.RemoveAt(2);
                lbDebug.Visible = false;
            }

            ytDlAvailable = Verification.ytdlFullCheck();
            ffmpegAvailable = Verification.ffmpegFullCheck();
            trayIcon.ContextMenu = cmTray;
        }

        private void frmMain_Load(object sender, EventArgs e) {
            if (!Debug) {
                UpdateChecker.CheckForUpdate();
            }


            if (Saved.Default.formTrue0) {
                this.Location = new Point(Saved.Default.formLocationX, Saved.Default.formLocationY);
            }
            else if (Saved.Default.formLocationX > 0 || Saved.Default.formLocationY > 0) {
                this.Location = new Point(Saved.Default.formLocationX, Saved.Default.formLocationY);
            }

            switch (General.Default.saveCustomArgs) {
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

        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            if (BatchDownloads.Count > 0) {
                if (MessageBox.Show("A batch job is in progress. Really exit?", "youtube-dl-gui", MessageBoxButtons.YesNoCancel) == System.Windows.Forms.DialogResult.No) {
                    e.Cancel = true;
                }
            }
            if (this.Location.X == 0 || this.Location.Y == 0) {
                Saved.Default.formTrue0 = true;
            }
            else {
                Saved.Default.formTrue0 = false;
            }

            switch (General.Default.saveCustomArgs) {
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

            Saved.Default.Save();
            if (BatchDownloads.Count > 0) {
                for (int i = 0; i < BatchDownloads.Count; i++) {
                    BatchDownloads[i].Abort();
                }
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
        }
        #endregion

        #region main menu
        private void mSettings_Click(object sender, EventArgs e) {
            frmSettings settings = new frmSettings();
            settings.ShowDialog();
            settings.Dispose();
        }

        private void mBatchDownload_Click(object sender, EventArgs e) {
            frmBatchDownloader batch = new frmBatchDownloader();
            batch.Show();
        }
        private void mDownloadSubtitles_Click(object sender, EventArgs e) {
            frmSubtitles downloadSubtitles = new frmSubtitles();
            downloadSubtitles.ShowDialog();
            downloadSubtitles.Dispose();
        }
        private void mMiscTools_Click(object sender, EventArgs e) {
            frmTools tools = new frmTools();
            tools.Show();
        }

        private void mLanguage_Click(object sender, EventArgs e) {
            frmLanguage language = new frmLanguage();
            switch (language.ShowDialog()) {
                case System.Windows.Forms.DialogResult.Yes:
                    Settings.Default.LanguageFile = language.LanguageFile;
                    Settings.Default.Save();
                    LoadLanguage(true);
                    break;
            }
        }
        private void mSupportedSites_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://ytdl-org.github.io/youtube-dl/supportedsites.html");
        }

        private void mAbout_Click(object sender, EventArgs e) {
            frmAbout about = new frmAbout();
            about.ShowDialog();
            about.Dispose();
        }
        #endregion

        #region tray menu
        private void cmTrayShowForm_Click(object sender, EventArgs e) {
            this.Show();
        }

        private void cmTrayDownloadBestVideo_Click(object sender, EventArgs e) {
            Download.startDownload(Clipboard.GetText(), 0, Saved.Default.videoQuality, string.Empty);
        }

        private void cmTrayDownloadBestAudio_Click(object sender, EventArgs e) {
            Download.startDownload(Clipboard.GetText(), 1, Saved.Default.audioQuality, string.Empty);
        }

        private void cmTrayDownloadCustomTxtBox_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtArgs.Text)) {
                MessageBox.Show("No arguments are currently in memory. Enter in custom arguments in the arguments text box on the main form.");
                return;
            }
            else {
                Download.startDownload(Clipboard.GetText(), 2, -1, txtArgs.Text);
            }
        }
        private void cmTrayDownloadCustomTxt_Click(object sender, EventArgs e) {
            if (!System.IO.File.Exists(Environment.CurrentDirectory + "\\args.txt")) {
                MessageBox.Show("args.txt does not exist, create it and put in arguments to use this command");
                return;
            }
            else if (string.IsNullOrEmpty(System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\args.txt"))) {
                MessageBox.Show("args.txt is empty, save arguments to the file to use this command");
                return;
            }
            else {
                Download.startDownload(Clipboard.GetText(), 2, -1, System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\args.txt"));
            }
        }
        private void cmTrayDownloadCustomSettings_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(Saved.Default.downloadArgs)) {
                MessageBox.Show("No arguments are saved in the application settings, save arguments to the settings to use this command");
                return;
            }
            else
            {
                Download.startDownload(Clipboard.GetText(), 2, -1, Saved.Default.downloadArgs);
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
            Environment.Exit(0);
        }
        #endregion

        #region downloader
        private void rbVideo_CheckedChanged(object sender, EventArgs e) {
            if (rbVideo.Checked) {
                cbQuality.SelectedIndex = -1;
                cbQuality.Items.Clear();
                cbQuality.Items.AddRange(videoQuality);
                cbQuality.SelectedIndex = Saved.Default.videoQuality;
                cbQuality.Enabled = true;
                chkDownloadSound.Enabled = true;
            }
        }
        private void rbAudio_CheckedChanged(object sender, EventArgs e) {
            if (rbAudio.Checked) {
                cbQuality.SelectedIndex = -1;
                cbQuality.Items.Clear();
                cbQuality.Items.AddRange(audioQuality);
                cbQuality.SelectedIndex = Saved.Default.audioQuality;
                cbQuality.Enabled = true;
                chkDownloadSound.Enabled = false;
            }
        }
        private void rbCustom_CheckedChanged(object sender, EventArgs e) {
            if (rbCustom.Checked) {
                txtArgs.ReadOnly = false;
                cbQuality.SelectedIndex = -1;
                cbQuality.Enabled = false;
                chkDownloadSound.Enabled = false;
            }
            else {
                txtArgs.ReadOnly = true;
            }
        }

        private void txtUrl_MouseEnter(object sender, EventArgs e) {
            if (General.Default.hoverURL && txtUrl.Text != Clipboard.GetText()) {
                txtUrl.Text = Clipboard.GetText();
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
            if (rbVideo.Checked) {
                string videoArguments = string.Empty;
                if (!chkDownloadSound.Checked) {
                    videoArguments += "-nosound";
                }

                Saved.Default.downloadType = 0;
                if (Download.startDownload(txtUrl.Text, 0, cbQuality.SelectedIndex, videoArguments)) {
                    if (General.Default.clearURL) {
                        txtUrl.Clear();
                        Clipboard.Clear();
                    }
                    lbDownloadStatus.Text = "Download started";
                    tmrDownloadLabel.Enabled = true;
                }
                else {
                    lbDownloadStatus.Text = "Error downloading";
                    tmrDownloadLabel.Enabled = true;
                }
                Saved.Default.videoQuality = cbQuality.SelectedIndex;
            }
            else if (rbAudio.Checked) {
                Saved.Default.downloadType = 1;

                if (Download.startDownload(txtUrl.Text, 1, cbQuality.SelectedIndex, string.Empty)) {
                    if (General.Default.clearURL) {
                        txtUrl.Clear();
                        Clipboard.Clear();
                    }
                    lbDownloadStatus.Text = "Download started";
                    tmrDownloadLabel.Enabled = true;
                }
                else {
                    lbDownloadStatus.Text = "Error downloading";
                    tmrDownloadLabel.Enabled = true;
                }
                Saved.Default.audioQuality = cbQuality.SelectedIndex;
            }
            else if (rbCustom.Checked) {
                Saved.Default.downloadType = 2;

                if (Download.startDownload(txtUrl.Text, 2, -1, txtArgs.Text)) {
                    if (General.Default.clearURL) {
                        txtUrl.Clear();
                        Clipboard.Clear();
                    }

                    lbDownloadStatus.Text = "Download started";
                    tmrDownloadLabel.Enabled = true;
                }
                else {
                    lbDownloadStatus.Text = "Error downloading";
                    tmrDownloadLabel.Enabled = true;
                }
            }
            else {
                if (Download.startDownload(txtUrl.Text, 0, -1, string.Empty)) {
                    if (General.Default.clearURL) {
                        txtUrl.Clear();
                        Clipboard.Clear();
                    }
                    lbDownloadStatus.Text = "Download started";
                    tmrDownloadLabel.Enabled = true;
                }
                else {
                    lbDownloadStatus.Text = "Error downloading";
                    tmrDownloadLabel.Enabled = true;
                }
            }

            Saved.Default.Save();
        }

        private void mBatchDownloadFromFile_Click(object sender, EventArgs e) {
            MessageBox.Show("Create a text file and put all the videos you want to download into it.\nOne URL per line.");
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
            MessageBox.Show("Batch download will now begin. It may take some time.\nyoutube-dl-gui will reappear when it's finished.");

            if (System.IO.File.Exists(TextFile)) {
                string[] ReadFile = System.IO.File.ReadAllLines(TextFile);
                for (int i = 0; i < ReadFile.Length; i++) {
                    if (rbVideo.Checked) {
                        string videoArguments = string.Empty;
                        if (!chkDownloadSound.Checked) { videoArguments += "-nosound"; }
                        if (Download.startDownload(ReadFile[i], 0, cbQuality.SelectedIndex, videoArguments, true)) { }
                    }
                    else if (rbAudio.Checked) { if (Download.startDownload(ReadFile[i], 1, cbQuality.SelectedIndex, string.Empty, true)) { } }
                    else if (rbCustom.Checked) { if (Download.startDownload(ReadFile[i], 2, -1, txtArgs.Text, true)) { } }
                    else { if (Download.startDownload(ReadFile[i], 0, -1, string.Empty, true)) { } }
                }
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
            Saved.Default.Save();

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

    }
}
