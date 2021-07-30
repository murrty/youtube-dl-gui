using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmMain : Form {

        #region variables
        Language lang = Language.GetInstance();
        Verification verif = Verification.GetInstance();

        public bool ProtocolInput = false;
        #endregion

        #region form
        [DebuggerStepThrough]
        protected override void WndProc(ref Message m) {
            if (m.Msg == NativeMethods.WM_SHOWYTDLGUIFORM) {
                this.Show();
                if (this.WindowState != FormWindowState.Normal)
                    this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
            base.WndProc(ref m);
        }
        public frmMain() {
            InitializeComponent();
            LoadLanguage();
            trayIcon.ContextMenu = cmTray;
            if (Program.IsDebug) {
                lbDebug.Text = "debugging " + Properties.Settings.Default.debugDate;
                lbDebug.Visible = true;
                trayIcon.Visible = false;
                trayIcon.Dispose();
            }
            else {
                tcMain.TabPages.RemoveAt(3);
                lbDebug.Visible = false;
            }
        }

        private void frmMain_Load(object sender, EventArgs e) {
            UpdateChecker.CheckForUpdate();
            if (Config.ProgramConfig.Saved.MainFormSize != default(System.Drawing.Size)) {
                this.Size = Config.ProgramConfig.Saved.MainFormSize;
            }
            if (!Program.IsDebug) {
                mDownloadSubtitles.Enabled = false;
            }

            if (Config.ProgramConfig.Saved.MainFormLocation.X != -3200 && Config.ProgramConfig.Saved.MainFormLocation.Y != -32000) {
                this.Location = Config.ProgramConfig.Saved.MainFormLocation;
            }

            switch (Config.ProgramConfig.General.SaveCustomArgs) {
                case 1:
                    if (System.IO.File.Exists(Environment.CurrentDirectory + "\\args.txt")) {
                        cbCustomArguments.Items.AddRange(System.IO.File.ReadAllLines(Environment.CurrentDirectory + "\\args.txt"));
                        if (Config.ProgramConfig.Saved.CustomArgumentsIndex > -1 && Config.ProgramConfig.Saved.CustomArgumentsIndex <= cbCustomArguments.Items.Count) {
                            cbCustomArguments.SelectedIndex = Config.ProgramConfig.Saved.CustomArgumentsIndex;
                        }
                    }
                    break;
                case 2:
                    if (Config.ProgramConfig.Saved.CustomArgumentsIndex > -1) {
                        cbCustomArguments.SelectedIndex = Config.ProgramConfig.Saved.CustomArgumentsIndex;
                    }
                    break;
            }
            switch (Config.ProgramConfig.Saved.downloadType) {
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

            switch (Config.ProgramConfig.Saved.convertType) {
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

            if (ProtocolInput) {
                if (Config.ProgramConfig.Downloads.AutomaticallyDownloadFromProtocol) {
                    // download ...
                }
            }

            if (Program.UseIni) {
                this.Text += " (ini)";
            }
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            this.Opacity = 0;
            if (this.WindowState == FormWindowState.Minimized) {
                this.WindowState = FormWindowState.Normal;
            }

            chkUseSelection.Checked = false;
            Config.ProgramConfig.Saved.MainFormSize = this.Size;

            switch (Config.ProgramConfig.General.SaveCustomArgs) {
                case 1: // txt
                    StringBuilder txtOutputBuffer = new StringBuilder();
                    for (int i = 0; i < cbCustomArguments.Items.Count; i++) {
                        txtOutputBuffer.AppendLine(cbCustomArguments.GetItemText(cbCustomArguments.Items[i]));
                    }
                    System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\args.txt", txtOutputBuffer.ToString());
                    Config.ProgramConfig.Saved.CustomArgumentsIndex = cbCustomArguments.SelectedIndex;
                    break;
                case 2: // settings
                    string stngOutputBuffer = string.Empty;
                    for (int i = 0; i < cbCustomArguments.Items.Count; i++) {
                        stngOutputBuffer += cbCustomArguments.GetItemText(cbCustomArguments.Items[i]) + "|";
                    }
                    Config.ProgramConfig.Saved.DownloadCustomArguments = stngOutputBuffer.Trim('|');
                    Config.ProgramConfig.Saved.CustomArgumentsIndex = cbCustomArguments.SelectedIndex;
                    break;
            }

            if (rbVideo.Checked)
                Config.ProgramConfig.Saved.downloadType = 0;
            else if (rbAudio.Checked)
                Config.ProgramConfig.Saved.downloadType = 1;
            else if (rbCustom.Checked)
                Config.ProgramConfig.Saved.downloadType = 2;
            else
                Config.ProgramConfig.Saved.downloadType = -1;

            if (rbConvertVideo.Checked)
                Config.ProgramConfig.Saved.convertType = 0;
            else if (rbConvertAudio.Checked)
                Config.ProgramConfig.Saved.convertType = 1;
            else if (rbConvertCustom.Checked)
                Config.ProgramConfig.Saved.convertType = 2;
            else if (rbConvertAutoFFmpeg.Checked)
                Config.ProgramConfig.Saved.convertType = 6;
            else
                Config.ProgramConfig.Saved.convertType = -1;

            Config.ProgramConfig.Saved.MainFormLocation = this.Location;

            Config.ProgramConfig.Save(ConfigType.Saved);
            trayIcon.Visible = false;
        }

        void LoadLanguage() {
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
            txtUrl.TextHint = lang.txtUrlHint;
            gbDownloadType.Text = lang.gbDownloadType;
            rbVideo.Text = lang.GenericVideo;
            rbAudio.Text = lang.GenericAudio;
            rbCustom.Text = lang.GenericCustom;
            lbQuality.Text = lang.lbQuality;
            lbFormat.Text = lang.lbFormat;
            chkDownloadSound.Text = lang.chkDownloadSound;
            chkUseSelection.Text = lang.chkUseSelection;
            rbVideoSelectionPlaylistIndex.Text = lang.rbVideoSelectionPlaylistIndex;
            rbVideoSelectionPlaylistItems.Text = lang.rbVideoSelectionPlaylistItems;
            rbVideoSelectionBeforeDate.Text = lang.rbVideoSelectionBeforeDate;
            rbVideoSelectionOnDate.Text = lang.rbVideoSelectionOnDate;
            rbVideoSelectionAfterDate.Text = lang.rbVideoSelectionAfterDate;

            lbCustomArguments.Text = lang.lbCustomArguments;
            sbDownload.Text = lang.sbDownload;
            mDownloadWithAuthentication.Text = lang.mDownloadWithAuthentication;
            mBatchDownloadFromFile.Text = lang.mBatchDownloadFromFile;
            lbDownloadStatus.Text = "...";

            lbConvertInput.Text = lang.lbConvertInput;
            lbConvertOutput.Text = lang.lbConvertOutput;
            rbConvertVideo.Text = lang.GenericVideo;
            rbConvertAudio.Text = lang.GenericAudio;
            rbConvertCustom.Text = lang.GenericCustom;
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
            gbDownloadType.Size = new Size(
                ((rbVideo.Size.Width + 2) + rbAudio.Size.Width +  (rbCustom.Size.Width - 2)) + 12,
                gbDownloadType.Size.Height
            );
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

            gbSelection.Size = new Size(
                (rbVideoSelectionBeforeDate.Size.Width + rbVideoSelectionOnDate.Size.Width + rbVideoSelectionAfterDate.Size.Width) + 12,
                20
            );
            gbSelection.Location = new Point(
                (tabDownload.Size.Width - gbSelection.Size.Width) / 2,
                gbSelection.Location.Y
            );
            rbVideoSelectionPlaylistIndex.Location = new Point(
                (gbSelection.Size.Width - (rbVideoSelectionPlaylistIndex.Size.Width + rbVideoSelectionPlaylistItems.Size.Width)) / 2,
                rbVideoSelectionPlaylistIndex.Location.Y
            );
            rbVideoSelectionPlaylistItems.Location = new Point(
                (rbVideoSelectionPlaylistIndex.Location.X + rbVideoSelectionPlaylistItems.Size.Width) + 2,
                rbVideoSelectionPlaylistItems.Location.Y
            );
            rbVideoSelectionBeforeDate.Location = new Point(
                (gbSelection.Size.Width - (rbVideoSelectionBeforeDate.Size.Width + rbVideoSelectionOnDate.Size.Width + rbVideoSelectionAfterDate.Size.Width)) / 2,
                rbVideoSelectionBeforeDate.Location.Y
            );
            rbVideoSelectionOnDate.Location = new Point(
                (rbVideoSelectionBeforeDate.Location.X + rbVideoSelectionBeforeDate.Size.Width) + 2,
                rbVideoSelectionOnDate.Location.Y
            );
            rbVideoSelectionAfterDate.Location = new Point(
                (rbVideoSelectionOnDate.Location.X + rbVideoSelectionOnDate.Width) + 2,
                rbVideoSelectionAfterDate.Location.Y
            );

            rbConvertVideo.Location = new System.Drawing.Point(
                (tabConvert.Size.Width - (rbConvertVideo.Size.Width + rbConvertAudio.Size.Width + rbConvertCustom.Size.Width + 2)) / 2,
                rbConvertVideo.Location.Y
            );
            rbConvertAudio.Location = new System.Drawing.Point(
                (rbConvertVideo.Location.X + rbConvertVideo.Width) + 2,
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
            using (frmSettings settings = new frmSettings()) {
                settings.ShowDialog();
                if (Program.UseIni && !this.Text.EndsWith(" (ini)")) {
                    this.Text += " (ini)";
                }
                else if (!Program.UseIni && this.Text.EndsWith(" (ini)")) {
                    this.Text = this.Text.Substring(0, this.Text.Length - 6);
                }
            }
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
                        if (language.LanguageFile == null) {
                            Config.ProgramConfig.Initialization.LanguageFile = string.Empty;
                        }
                        else {
                            Config.ProgramConfig.Initialization.LanguageFile = language.LanguageFile;
                        
                        }
                        Config.ProgramConfig.Initialization.Save();
                        LoadLanguage();
                        break;
                }
            }
        }
        private void mSupportedSites_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://web.archive.org/web/20201004065152/http://ytdl-org.github.io/youtube-dl/supportedsites.html");
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
            DownloadInfo NewInfo = new DownloadInfo();
            NewInfo.VideoQuality = (VideoQualityType)Config.ProgramConfig.Saved.videoQuality;
            NewInfo.Type = 0;
            NewInfo.DownloadURL = Clipboard.GetText();
            Downloader.CurrentDownload = NewInfo;
            Downloader.Show();
        }

        private void cmTrayDownloadBestAudio_Click(object sender, EventArgs e) {
            frmDownloader Downloader = new frmDownloader();
            DownloadInfo NewInfo = new DownloadInfo();
            NewInfo.AudioCBRQuality = AudioCBRQualityType.best;
            NewInfo.Type = DownloadType.Audio;
            NewInfo.DownloadURL = Clipboard.GetText();
            Downloader.CurrentDownload = NewInfo;
            Downloader.Show();
        }

        private void cmTrayDownloadCustomTxtBox_Click(object sender, EventArgs e) {
            if (!Clipboard.ContainsText()) { return; }

            if (string.IsNullOrEmpty(cbCustomArguments.Text)) {
                MessageBox.Show("No arguments are currently in memory. Enter in custom arguments in the arguments text box on the main form.");
                return;
            }
            else {
                frmDownloader Downloader = new frmDownloader();
                DownloadInfo NewInfo = new DownloadInfo();
                NewInfo.DownloadArguments = cbCustomArguments.Text;
                NewInfo.Type = DownloadType.Custom;
                NewInfo.DownloadURL = Clipboard.GetText();
                Downloader.CurrentDownload = NewInfo;
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
                DownloadInfo NewInfo = new DownloadInfo();
                NewInfo.DownloadArguments = System.IO.File.ReadAllLines(Environment.CurrentDirectory + "\\args.txt")[0];
                NewInfo.Type = DownloadType.Custom;
                NewInfo.DownloadURL = Clipboard.GetText();
                Downloader.CurrentDownload = NewInfo;
                Downloader.Show();
            }
        }
        private void cmTrayDownloadCustomSettings_Click(object sender, EventArgs e) {
            if (!Clipboard.ContainsText() && Config.ProgramConfig.Saved.CustomArgumentsIndex < 0) { return; }
            if (string.IsNullOrEmpty(Config.ProgramConfig.Saved.DownloadCustomArguments)) {
                MessageBox.Show("No arguments are saved in the application settings, save arguments to the settings to use this command");
                return;
            }
            else
            {
                frmDownloader Downloader = new frmDownloader();
                DownloadInfo NewInfo = new DownloadInfo();
                NewInfo.DownloadArguments = Config.ProgramConfig.Saved.DownloadCustomArguments.Split('|')[Config.ProgramConfig.Saved.CustomArgumentsIndex];
                NewInfo.Type = DownloadType.Custom;
                NewInfo.DownloadURL = Clipboard.GetText();
                Downloader.CurrentDownload = NewInfo;
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
            Config.ProgramConfig.Save(ConfigType.All);
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
                if (Config.ProgramConfig.Downloads.SaveFormatQuality) {
                    cbQuality.SelectedIndex = Config.ProgramConfig.Saved.videoQuality;
                    cbFormat.SelectedIndex = Config.ProgramConfig.Saved.VideoFormat;
                    chkDownloadSound.Checked = Config.ProgramConfig.Downloads.VideoDownloadSound;
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
                if (Config.ProgramConfig.Downloads.AudioDownloadAsVBR) {
                    cbQuality.Items.AddRange(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
                }
                else {
                    cbQuality.Items.AddRange(DownloadFormats.AudioQualityNamesArray);
                }
                cbFormat.Items.Clear();
                cbFormat.Items.AddRange(DownloadFormats.AudioFormatsArray);
                cbQuality.Enabled = true;
                cbFormat.Enabled = true;
                chkDownloadSound.Enabled = true;
                chkDownloadSound.Checked = Config.ProgramConfig.Downloads.AudioDownloadAsVBR;
                chkDownloadSound.Text = "VBR";
                if (Config.ProgramConfig.Downloads.SaveFormatQuality) {
                    cbQuality.SelectedIndex = Config.ProgramConfig.Saved.audioQuality;
                    cbFormat.SelectedIndex = Config.ProgramConfig.Saved.AudioFormat;
                }
                else {
                    cbQuality.SelectedIndex = 0;
                    cbFormat.SelectedIndex = 0;
                }
            }
        }
        private void rbCustom_CheckedChanged(object sender, EventArgs e) {
            if (rbCustom.Checked) {
                cbCustomArguments.Enabled = true;
                cbQuality.SelectedIndex = -1;
                cbFormat.SelectedIndex = -1;
                cbQuality.Enabled = false;
                cbFormat.Enabled = false;
                chkDownloadSound.Checked = false;
                chkDownloadSound.Enabled = false;
                if (Config.ProgramConfig.Downloads.SaveFormatQuality) {
                    cbCustomArguments.SelectedIndex = Config.ProgramConfig.Saved.CustomArgumentsIndex;
                }
            }
            else {
                cbCustomArguments.Enabled = false;
            }
        }
        private void chkDownloadSound_CheckedChanged(object sender, EventArgs e) {
            if (rbAudio.Checked) {
                cbQuality.Items.Clear();

                if (chkDownloadSound.Checked) {
                    cbQuality.SelectedIndex = -1;
                    cbQuality.Items.AddRange(new string[]{"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"});
                    if (Config.ProgramConfig.Downloads.SaveFormatQuality) {
                        cbQuality.SelectedIndex = Config.ProgramConfig.Saved.AudioVBRQuality;
                    }
                    else {
                        cbQuality.SelectedIndex = 0;
                    }
                }
                else {
                    cbQuality.Items.AddRange(DownloadFormats.AudioQualityNamesArray);
                    cbQuality.Items[0] = lang.GenericInputBest;
                    if (Config.ProgramConfig.Downloads.SaveFormatQuality) {
                        cbQuality.SelectedIndex = Config.ProgramConfig.Saved.audioQuality;
                    }
                    else {
                        cbQuality.SelectedIndex = 0;
                    }
                }
            }
        }
        private void chkUseSelection_CheckedChanged(object sender, EventArgs e) {
            // 360 minimum height

            // 86 difference

            // 274 ?? 446

            if (chkUseSelection.Checked) {
                //if (this.Size.Height < 446) {
                //    AddedHeight = (446 - this.Size.Height);
                //    gbSelection.Size = new Size(gbSelection.Size.Width, 106);
                //    this.Size = new Size(this.Width, this.Height + AddedHeight);
                //}
                //else {
                //    gbSelection.Size = new Size(gbSelection.Size.Width, 106);
                //}

                gbSelection.Size = new Size(gbSelection.Size.Width, 106);
                this.Size = new Size(this.Width, this.Height + 86);
                this.MinimumSize = new Size(this.MinimumSize.Width, this.MinimumSize.Height + 86);
            }
            else {
                //gbSelection.Size = new Size(gbSelection.Size.Width, 20);
                //if (this.Size.Height > 446) {
                //    this.Size = new Size(this.Width, this.Height - 86);
                //}
                //else {
                //    this.Size = new Size(this.Width, this.Height - AddedHeight);
                //}

                gbSelection.Size = new Size(gbSelection.Size.Width, 20);
                this.MinimumSize = new Size(this.MinimumSize.Width, this.MinimumSize.Height - 86);
                this.Size = new Size(this.Width, this.Height - 86);
            }
        }
        private void txtPlaylistItems_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',') {
                e.Handled = true;
            }
        }
        private void txtVideoDate_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) {
                e.Handled = true;
            }
        }
        private void rbVideoSelectionPlaylistIndex_CheckedChanged(object sender, EventArgs e) {
            if (rbVideoSelectionPlaylistIndex.Checked) {
                panelPlaylistStartEnd.Visible = true;
                panelPlaylistItems.Visible = false;
                panelDate.Visible = false;
                chkUseSelection.Checked = true;
            }
        }
        private void rbVideoSelectionPlaylistItems_CheckedChanged(object sender, EventArgs e) {
            if (rbVideoSelectionPlaylistItems.Checked) {
                panelPlaylistStartEnd.Visible = false;
                panelPlaylistItems.Visible = true;
                panelDate.Visible = false;
                chkUseSelection.Checked = true;
            }
        }
        private void rbVideoSelectionBeforeDate_CheckedChanged(object sender, EventArgs e) {
            if (rbVideoSelectionBeforeDate.Checked) {
                panelPlaylistStartEnd.Visible = false;
                panelPlaylistItems.Visible = false;
                panelDate.Visible = true;
                chkUseSelection.Checked = true;
            }
        }
        private void rbVideoSelectionOnDate_CheckedChanged(object sender, EventArgs e) {
            if (rbVideoSelectionOnDate.Checked) {
                panelPlaylistStartEnd.Visible = false;
                panelPlaylistItems.Visible = false;
                panelDate.Visible = true;
                chkUseSelection.Checked = true;
            }
        }
        private void rbVideoSelectionAfterDate_CheckedChanged(object sender, EventArgs e) {
            if (rbVideoSelectionAfterDate.Checked) {
                panelPlaylistStartEnd.Visible = false;
                panelPlaylistItems.Visible = false;
                panelDate.Visible = true;
                chkUseSelection.Checked = true;
            }
        }

        private void txtUrl_MouseEnter(object sender, EventArgs e) {
            if (Config.ProgramConfig.General.HoverOverURLTextBoxToPaste && txtUrl.Text != Clipboard.GetText()) {
                txtUrl.Text = Clipboard.GetText();
            }
        }
        private void txtUrl_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                StartDownload(false);
            }
        }
        private void txtArgs_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                StartDownload(false);
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
            StartDownload(false);
        }
        private void mDownloadWithAuthentication_Click(object sender, EventArgs e) {
            StartDownload(true);
        }
        private void mBatchDownloadFromFile_Click(object sender, EventArgs e) {
            if (!Config.ProgramConfig.Downloads.SkipBatchTip) {
                switch (MessageBox.Show(lang.msgBatchDownloadFromFile, "youtube-dl-gui", MessageBoxButtons.YesNoCancel)) {
                    case System.Windows.Forms.DialogResult.Cancel:
                        return;
                    case System.Windows.Forms.DialogResult.Yes:
                        Config.ProgramConfig.Downloads.SkipBatchTip = true;
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
                DownloadType Type = DownloadType.None;
                int BatchQuality = 0;

                this.BeginInvoke(new MethodInvoker(() => {
                    if (!chkDownloadSound.Checked) { videoArguments += "-nosound"; }
                    BatchQuality = cbQuality.SelectedIndex;
                    if (rbVideo.Checked) { Type = DownloadType.Video; }
                    else if (rbAudio.Checked) { Type = DownloadType.Audio; }
                    else if (rbCustom.Checked) { Type = DownloadType.Custom; }
                    else { Type = DownloadType.Unknown; }
                }));

                if (System.IO.File.Exists(TextFile)) {
                    string[] ReadFile = System.IO.File.ReadAllLines(TextFile);
                    if (ReadFile.Length == 0) {
                        return;
                    }
                    for (int i = 0; i < ReadFile.Length; i++) {
                        using (frmDownloader Downloader = new frmDownloader()) {
                            DownloadInfo NewInfo = new DownloadInfo();
                            NewInfo.BatchDownload = true;
                            NewInfo.DownloadURL = ReadFile[i].Trim(' ');
                            switch (Type) {
                                case DownloadType.Video:
                                    if (!chkDownloadSound.Checked) {
                                        NewInfo.SkipAudioForVideos = true;
                                    }
                                    NewInfo.DownloadArguments = videoArguments;
                                    NewInfo.VideoQuality = (VideoQualityType)BatchQuality;
                                    NewInfo.Type = DownloadType.Video;
                                    break;
                                case DownloadType.Audio:
                                    if (chkDownloadSound.Checked) {
                                        NewInfo.AudioVBRQuality = (AudioVBRQualityType)BatchQuality;
                                    }
                                    else {
                                        NewInfo.AudioCBRQuality = (AudioCBRQualityType)BatchQuality;
                                    }
                                    NewInfo.Type = DownloadType.Audio;
                                    break;
                                case DownloadType.Custom:
                                    NewInfo.DownloadArguments = cbCustomArguments.Text;
                                    NewInfo.Type = DownloadType.Custom;
                                    break;
                                case DownloadType.Unknown:
                                    NewInfo.VideoQuality = (VideoQualityType)0;
                                    NewInfo.Type = DownloadType.Video;
                                    break;
                            }
                            Downloader.CurrentDownload = NewInfo;
                            Downloader.ShowDialog();
                            if (Downloader.DialogResult == DialogResult.Abort) {
                                break;
                            }
                        }
                    }
                }
            });
            BatchThread.Name = "Batch download";
            BatchThread.Start();
        }

        [DebuggerStepThrough]
        private void StartDownload(bool WithAuth = false) {
            if (string.IsNullOrEmpty(txtUrl.Text)) { return; }
            txtUrl.Text = txtUrl.Text.Replace("\\", "-");
            frmDownloader Downloader = new frmDownloader();
            DownloadInfo NewInfo = new DownloadInfo();

            // First, authenticate.
            if (WithAuth) {
                frmAuthentication auth = new frmAuthentication();
                if (auth.ShowDialog() == DialogResult.OK) {
                    if (auth.Username != null) {
                        NewInfo.AuthUsername = auth.Username;
                        auth.Username = null;
                    }
                    if (auth.Password != null) {
                        NewInfo.AuthPassword = auth.Password;
                        auth.Password = null;
                    }
                    if (auth.TwoFactor != null) {
                        NewInfo.Auth2Factor = auth.TwoFactor;
                        auth.TwoFactor = null;
                    }
                    if (auth.VideoPassword != null) {
                        NewInfo.AuthVideoPassword = auth.VideoPassword;
                        auth.VideoPassword = null;
                    }
                    NewInfo.AuthNetrc = auth.Netrc;
                    auth.Dispose();
                }
                else {
                    auth.Dispose();
                    return;
                }
            }
            if (!rbCustom.Checked) {
                if (chkUseSelection.Checked) {
                    if (rbVideoSelectionPlaylistIndex.Checked && txtPlaylistStart.Text.Length > 0 || txtPlaylistEnd.Text.Length > 0) {
                        NewInfo.PlaylistSelection = PlaylistSelectionType.PlaylistStartPlaylistEnd;
                        int PlaylistStart;
                        int PlaylistEnd;
                        if (int.TryParse(txtPlaylistStart.Text, out PlaylistStart)) {
                            NewInfo.PlaylistSelectionIndexStart = PlaylistStart;
                        }
                        if (int.TryParse(txtPlaylistEnd.Text, out PlaylistEnd)) {
                            NewInfo.PlaylistSelectionIndexEnd = PlaylistEnd;
                        }
                    }
                    else if (rbVideoSelectionPlaylistItems.Checked && txtPlaylistItems.Text.Length > 0) {
                        NewInfo.PlaylistSelection = PlaylistSelectionType.PlaylistItems;
                        NewInfo.PlaylistSelectionArg = txtPlaylistItems.Text;
                    }
                    else if (rbVideoSelectionBeforeDate.Checked && txtVideoDate.Text.Length > 0) {
                        NewInfo.PlaylistSelection = PlaylistSelectionType.DateBefore;
                        NewInfo.PlaylistSelectionArg = txtVideoDate.Text;
                    }
                    else if (rbVideoSelectionOnDate.Checked && txtVideoDate.Text.Length > 0) {
                        NewInfo.PlaylistSelection = PlaylistSelectionType.DateDuring;
                        NewInfo.PlaylistSelectionArg = txtVideoDate.Text;
                    }
                    else if (rbVideoSelectionAfterDate.Checked && txtVideoDate.Text.Length > 0) {
                        NewInfo.PlaylistSelection = PlaylistSelectionType.DateAfter;
                        NewInfo.PlaylistSelectionArg = txtVideoDate.Text;
                    }
                }

                if (rbVideo.Checked) {
                    NewInfo.VideoQuality = (VideoQualityType)cbQuality.SelectedIndex;
                    NewInfo.VideoFormat = (VideoFormatType)cbFormat.SelectedIndex;
                    NewInfo.Type = DownloadType.Video;
                    NewInfo.SkipAudioForVideos = !chkDownloadSound.Checked;
                    NewInfo.DownloadURL = txtUrl.Text;

                    Config.ProgramConfig.Saved.downloadType = (int)DownloadType.Video;
                    Config.ProgramConfig.Saved.videoQuality = cbQuality.SelectedIndex;
                    Config.ProgramConfig.Saved.VideoFormat = cbFormat.SelectedIndex;
                    Config.ProgramConfig.Downloads.VideoDownloadSound = chkDownloadSound.Checked;
                }
                else if (rbAudio.Checked) {
                    NewInfo.Type = DownloadType.Audio;
                    if (chkDownloadSound.Checked) {
                        NewInfo.AudioVBRQuality = (AudioVBRQualityType)cbQuality.SelectedIndex;
                    }
                    else {
                        NewInfo.AudioCBRQuality = (AudioCBRQualityType)cbQuality.SelectedIndex;
                    }
                    NewInfo.UseVBR = chkDownloadSound.Checked;
                    NewInfo.AudioFormat = (AudioFormatType)cbFormat.SelectedIndex;
                    NewInfo.DownloadURL = txtUrl.Text;


                    Config.ProgramConfig.Saved.downloadType = (int)DownloadType.Audio;
                    Config.ProgramConfig.Saved.audioQuality = cbQuality.SelectedIndex;
                    Config.ProgramConfig.Saved.AudioFormat = cbFormat.SelectedIndex;
                    Config.ProgramConfig.Downloads.AudioDownloadAsVBR = chkDownloadSound.Checked;
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
            }
            else {
                NewInfo.Type = DownloadType.Custom;
                NewInfo.DownloadArguments = cbCustomArguments.Text;
                NewInfo.DownloadURL = txtUrl.Text;
                Config.ProgramConfig.Saved.downloadType = (int)DownloadType.Custom;
                if (!cbCustomArguments.Items.Contains(cbCustomArguments.Text)) {
                    cbCustomArguments.Items.Add(cbCustomArguments.Text);
                }
            }

            Downloader.CurrentDownload = NewInfo;
            Downloader.Show();

            if (Config.ProgramConfig.General.ClearURLOnDownload) {
                txtUrl.Clear();
            }
            if (Config.ProgramConfig.General.ClearClipboardOnDownload) {
                Clipboard.Clear();
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
                            if (Config.ProgramConfig.Saved.UseStaticYtdl > -1 && Config.ProgramConfig.Converts.detectFiletype)
                                sfd.FilterIndex = Config.ProgramConfig.Saved.UseStaticYtdl;
                            else
                                sfd.FilterIndex = 7;
                        }
                        else if (rbConvertAudio.Checked) {
                            sfd.Filter = Convert.allVideoFormats + "|" + Convert.allAudioFormats + "|" + Convert.allMediaFormats + "|" + Convert.audioFormatsFilter;
                            if (Config.ProgramConfig.Saved.convertSaveAudioIndex > -1 && Config.ProgramConfig.Converts.detectFiletype)
                                sfd.FilterIndex = Config.ProgramConfig.Saved.convertSaveAudioIndex;
                            else
                                sfd.FilterIndex = 7;
                        }
                        else {
                            sfd.Filter = Convert.allVideoFormats + "|" + Convert.allAudioFormats + "|" + Convert.allMediaFormats + "|" + "All File Formats (*.*)|(*.*)";
                        }
                        if (sfd.ShowDialog() == DialogResult.OK) {
                            txtConvertOutput.Text = sfd.FileName;
                            if (rbConvertVideo.Checked && Config.ProgramConfig.Converts.detectFiletype)
                                Config.ProgramConfig.Saved.convertSaveAudioIndex = sfd.FilterIndex;
                            else if (rbConvertAudio.Checked && Config.ProgramConfig.Converts.detectFiletype)
                                Config.ProgramConfig.Saved.UseStaticYtdl = sfd.FilterIndex;

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
                    if (Config.ProgramConfig.Saved.UseStaticYtdl > -1 && Config.ProgramConfig.Converts.detectFiletype)
                        sfd.FilterIndex = Config.ProgramConfig.Saved.UseStaticYtdl;
                    else
                        sfd.FilterIndex = 7;
                }
                else if (rbConvertAudio.Checked) {
                    string filter = Convert.getCustomExtensions() +  Convert.audioFormatsFilter;
                    if (Config.ProgramConfig.SettingsConfig.extensionsShort.Length > 0) {
                        List<string> ext = new List<string>(Config.ProgramConfig.SettingsConfig.extensionsShort.Split('|'));
                        List<string> name = new List<string>(Config.ProgramConfig.SettingsConfig.extensionsName.Split('|'));

                        for (int i = 0; i < ext.Count; i++) {
                            filter += "|" + name[i] + " (*." + ext[i] + ")|*." + ext[i];
                        }
                    }
                    sfd.Filter = filter;
                    if (Config.ProgramConfig.Saved.convertSaveAudioIndex > -1 && Config.ProgramConfig.Converts.detectFiletype)
                        sfd.FilterIndex = Config.ProgramConfig.Saved.convertSaveAudioIndex;
                    else
                        sfd.FilterIndex = 7;
                }
                else {
                    sfd.Filter = Convert.getCustomExtensions() + Convert.allVideoFormats + "|" + Convert.allAudioFormats + "|" + Convert.allMediaFormats + "|" + Convert.allFormatsFilter;
                }
                if (sfd.ShowDialog() == DialogResult.OK) {
                    txtConvertOutput.Text = sfd.FileName;
                    if (rbConvertVideo.Checked && Config.ProgramConfig.Converts.detectFiletype)
                        Config.ProgramConfig.Saved.convertSaveAudioIndex = sfd.FilterIndex;
                    else if (rbConvertAudio.Checked && Config.ProgramConfig.Converts.detectFiletype)
                        Config.ProgramConfig.Saved.UseStaticYtdl = sfd.FilterIndex;

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
                if (Config.ProgramConfig.Converts.clearOutput) {
                    txtConvertOutput.Clear();
                    btnConvert.Enabled = false;
                }
                if (Config.ProgramConfig.Converts.clearInput) {
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

            Config.ProgramConfig.Saved.convertType = convType;

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
                            if (Config.ProgramConfig.Saved.UseStaticYtdl > -1 && Config.ProgramConfig.Converts.detectFiletype)
                                sfd.FilterIndex = Config.ProgramConfig.Saved.UseStaticYtdl;
                        else
                            sfd.FilterIndex = 7;
                            break;
                        case 1:
                            sfd.Filter = Convert.audioFormatsFilter;
                            if (Config.ProgramConfig.Saved.convertSaveAudioIndex > -1 && Config.ProgramConfig.Converts.detectFiletype)
                                sfd.FilterIndex = Config.ProgramConfig.Saved.convertSaveAudioIndex;
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
                        if (Config.ProgramConfig.Saved.UseStaticYtdl > -1 && Config.ProgramConfig.Converts.detectFiletype)
                            sfd.FilterIndex = Config.ProgramConfig.Saved.UseStaticYtdl;
                        else
                            sfd.FilterIndex = 7;
                        break;
                    case 1:
                        sfd.Filter = Convert.audioFormatsFilter;
                        if (Config.ProgramConfig.Saved.convertSaveAudioIndex > -1 && Config.ProgramConfig.Converts.detectFiletype)
                            sfd.FilterIndex = Config.ProgramConfig.Saved.convertSaveAudioIndex;
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
            DownloadInfo NewInfo = new DownloadInfo();
            NewInfo.VideoQuality = (VideoQualityType)Config.ProgramConfig.Saved.videoQuality;
            NewInfo.Type = DownloadType.Video;
            NewInfo.DownloadURL = Clipboard.GetText();
            NewInfo.BatchDownload = true;
            Downloader.Debugging = true;
            Downloader.Show();
        }
        private void btnDebugRotateQualityFormat_Click(object sender, EventArgs e) {
            Point s = lbQuality.Location;
            Point t = lbFormat.Location;
            Point u = cbQuality.Location;
            Point v = cbFormat.Location;

            lbFormat.Location = s;
            lbQuality.Location = t;
            cbFormat.Location = u;
            cbQuality.Location = v;
        }
        private void btnDebugThrowException_Click(object sender, EventArgs e) {
            try {
                throw new Exception("An exception has been thrown.");
            }
            catch (Exception ex) {
                ErrorLog.ReportException(ex, false);
            }
        }
        #endregion

    }
}
