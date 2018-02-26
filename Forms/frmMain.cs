using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;

// Please read the github readme. \\

namespace youtube_dl_gui {
    public partial class frmMain : Form {

        #region Variables
        bool hasUpdated = false;
        string ytdl = "";

        Thread checkUpdates;
        #endregion

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

        protected override void WndProc(ref Message m) {
            if (m.Msg == Controller.WM_SHOWFORM) {
                this.Show();
                if (this.WindowState != FormWindowState.Normal)
                    this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
            base.WndProc(ref m);
        }

        #region Form Methods
        public frmMain() {
            InitializeComponent();
            SetTextBoxHint(txtURL.Handle, "Enter URL...");
            SetTextBoxHint(txtArgs.Handle, "Custom arguments...");
        }

        private void frmMain_Load(object sender, EventArgs e) {
            niTray.ContextMenu = cmTray;
            // Check for updater batch file & delete it. Set "HasUpdated" to true to signify an update MIGHT have occured, not 100% sure.
            if (File.Exists(System.Windows.Forms.Application.StartupPath + @"\ydgu.bat"))
                hasUpdated = true;

            if (Settings.Default.updateCheck) {
                checkUpdates = new Thread(() => {
                    decimal cV = Updater.getCloudVersion();
                    if (Updater.isUpdateAvailable(cV)) {
                        if (MessageBox.Show("An update is available.\nNew verison: " + cV.ToString() + " | Your version: " + Properties.Settings.Default.currentVersion.ToString() + "\n\nWould you like to update?", "youtube-dl-gui", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                            Updater.createUpdaterStub(cV);
                            Updater.runUpdater();
                        }
                        this.Invoke((MethodInvoker)(() => mUpdate.Visible = true));
                        this.Invoke((MethodInvoker)(() => mUpdate.Enabled = true));
                    }
                    this.Invoke((MethodInvoker)(() => checkUpdates.Abort()));
                });
                checkUpdates.Start();
            }

            if (String.IsNullOrWhiteSpace(Settings.Default.DownloadDir)) {
                switch (MessageBox.Show("Would you like to use " + Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads" + " as your download path?", "youtube-dl-gui", MessageBoxButtons.YesNoCancel)) {
                    case System.Windows.Forms.DialogResult.Yes:
                        Settings.Default.DownloadDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads";
                        break;
                    case System.Windows.Forms.DialogResult.No:
                        FolderBrowserDialog fbd = new FolderBrowserDialog { Description = "Select a folder for videos to download to" };
                        switch (fbd.ShowDialog()) {
                            case System.Windows.Forms.DialogResult.OK:
                                Settings.Default.DownloadDir = fbd.SelectedPath;
                                break;
                            case System.Windows.Forms.DialogResult.Cancel:
                                Environment.Exit(0);
                                break;
                        }
                        break;
                }
                Settings.Default.Save();
            }

            if (String.IsNullOrWhiteSpace(Settings.Default.youtubedlDir) && Settings.Default.staticYTD) {
                if (MessageBox.Show("Would you like to use a static youtube-dl.exe path? Select \"No\" to keep youtube-dl.exe with youtube-dl-gui.exe.", "youtube-dl-gui", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                    FolderBrowserDialog fbd = new FolderBrowserDialog { Description = "Select a folder to store youtube-dl.exe" };
                    if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                        Settings.Default.youtubedlDir = fbd.SelectedPath + @"\youtube-dl.exe";
                    }
                }
                else {
                    Settings.Default.staticYTD = false;
                }
                Settings.Default.Save();
            }

            if (Settings.Default.staticYTD) {
                ytdl = Settings.Default.youtubedlDir;
            }
            else {
                ytdl = System.Windows.Forms.Application.StartupPath + @"\youtube-dl.exe";
                Settings.Default.youtubedlDir = System.Windows.Forms.Application.StartupPath + @"\youtube-dl.exe";
            }
            // Downloads the youtube-dl application if it does not exist, otherwise it checks for updates.
            if (!File.Exists(ytdl)) {
                MessageBox.Show("youtube-dl will now be downloaded.");
                Download.downloadYoutubeDL(ytdl);
            }
        }
        private void frmMain_Shown(object sender, EventArgs e) {
            if (hasUpdated) {
                niTray.BalloonTipIcon = ToolTipIcon.Info;
                niTray.BalloonTipTitle = "youtube-dl-gui updated";
                niTray.BalloonTipText = "youtube-dl-gui has been updated to " + Properties.Settings.Default.currentVersion + ".";
                File.Delete(System.Windows.Forms.Application.StartupPath + @"\ydgu.bat");
            }

            if (rbVideo.Checked)
                reloadVideoParams();
            else if (rbVideo.Checked)
                reloadAudioParams();

            if (Settings.Default.saveDlParams) {
                cbFormat.SelectedIndex = Settings.Default.vidFormat;
                cbQuality.SelectedIndex = Settings.Default.vidQuality;
            }
            else {
                cbFormat.SelectedIndex = 0;
                cbQuality.SelectedIndex = 0;
            }

            if (Settings.Default.saveConvParams) {
                cbConvQuality.SelectedIndex = Settings.Default.convQualityAud;
            }
            else {
                cbConvQuality.SelectedIndex = 14;
            }

            cbBit.SelectedIndex = 18;

            if (Settings.Default.dlType == 0)
                rbVideo.Checked = true;
            else if (Settings.Default.dlType == 1)
                rbAudio.Checked = true;
            else
                rbCustom.Checked = true;

            txtArgs.Text = Settings.Default.savedArgs;
        }
        private void frmMain_SizeChanged(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized)
                this.Hide();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            if (Settings.Default.DeleteAfterClose)
                File.Delete(ytdl);

            niTray.Visible = false;
        }
        #endregion

        #region Methods
        private void reloadAudioParams() {
            cbQuality.Items.Clear();
            cbQuality.Items.Add("best");
            cbQuality.Items.Add("8K");
            cbQuality.Items.Add("16K");
            cbQuality.Items.Add("24K");
            cbQuality.Items.Add("32K");
            cbQuality.Items.Add("40K");
            cbQuality.Items.Add("48K");
            cbQuality.Items.Add("56K");
            cbQuality.Items.Add("64K");
            cbQuality.Items.Add("80K");
            cbQuality.Items.Add("96K");
            cbQuality.Items.Add("112K");
            cbQuality.Items.Add("128K");
            cbQuality.Items.Add("144K");
            cbQuality.Items.Add("160K");
            cbQuality.Items.Add("192K");
            cbQuality.Items.Add("224K");
            cbQuality.Items.Add("256K");
            cbQuality.Items.Add("320K");

            cbFormat.Items.Clear();
            cbFormat.Items.Add("best");
            cbFormat.Items.Add("aac");
            cbFormat.Items.Add("flac");
            cbFormat.Items.Add("m4a");
            cbFormat.Items.Add("mp3");
            cbFormat.Items.Add("opus");
            cbFormat.Items.Add("vorbis");
            cbFormat.Items.Add("wav");
        }
        private void reloadVideoParams() {
            cbQuality.Items.Clear();
            cbQuality.Items.Add("best");
            //cbQuality.Items.Add("1080p");
            //cbQuality.Items.Add("720p");
            //cbQuality.Items.Add("640p");
            //cbQuality.Items.Add("480p");
            //cbQuality.Items.Add("360p");
            //cbQuality.Items.Add("240p");
            //cbQuality.Items.Add("144p");

            cbFormat.Items.Clear();
            cbFormat.Items.Add("best");
            cbFormat.Items.Add("3gp");
            cbFormat.Items.Add("flv");
            cbFormat.Items.Add("mp4");
            cbFormat.Items.Add("webm");
        }

        private void reloadConvAudio() {
            cbConvQuality.Items.Clear();
            cbConvQuality.Items.Add("8K");
            cbConvQuality.Items.Add("16K");
            cbConvQuality.Items.Add("24K");
            cbConvQuality.Items.Add("32K");
            cbConvQuality.Items.Add("40K");
            cbConvQuality.Items.Add("48K");
            cbConvQuality.Items.Add("56K");
            cbConvQuality.Items.Add("64K");
            cbConvQuality.Items.Add("80K");
            cbConvQuality.Items.Add("96K");
            cbConvQuality.Items.Add("112K");
            cbConvQuality.Items.Add("128K");
            cbConvQuality.Items.Add("144K");
            cbConvQuality.Items.Add("160K");
            cbConvQuality.Items.Add("192K");
            cbConvQuality.Items.Add("224K");
            cbConvQuality.Items.Add("256K");
            cbConvQuality.Items.Add("320K");
            cbConvQuality.SelectedIndex = 0;
        }
        private void reloadConvVideo() {
            cbConvQuality.Items.Clear();
            cbConvQuality.Items.Add("1920x1080");
            cbConvQuality.Items.Add("1600x900");
            cbConvQuality.Items.Add("1280x720");
            cbConvQuality.Items.Add("960x540");
            cbConvQuality.Items.Add("640x360");
            cbConvQuality.SelectedIndex = 0;
        }

        public static bool pingGoogle() {
            Ping pingGoogle = new Ping();
            String host = "google.com";
            byte[] buffer = new byte[32];
            int pingTimeout = 5000;
            PingOptions pingOpt = new PingOptions();
            PingReply getPing = pingGoogle.Send(host, pingTimeout, buffer, pingOpt);

            if (getPing.Status == IPStatus.Success)
                return true;
            else
                return false;
        }
        #endregion

        #region Downloader
        private void txtURL_MouseEnter(object sender, EventArgs e) {
            if (Settings.Default.HoverURL == true)
                if (Clipboard.ContainsText() && txtURL.Text != Clipboard.GetText()) {
                    txtURL.Clear();
                    txtURL.Text = Clipboard.GetText();
                }
        }
        private void txtURL_TextChanged(object sender, EventArgs e) { }

        private void rbVideo_CheckedChanged(object sender, EventArgs e) {
            if (rbVideo.Checked) {
                cbQuality.Enabled = false;
                cbFormat.Enabled = true;
                txtArgs.ReadOnly = true;
                reloadVideoParams();
                txtArgs.Clear();

                if (Settings.Default.saveDlParams) {
                    //cbFormat.SelectedIndex = Properties.Settings.Default.vidFormat;
                    //cbQuality.SelectedIndex = Properties.Settings.Default.vidQuality;
                }

                cbFormat.SelectedIndex = 0;
                cbQuality.SelectedIndex = 0;
            }
        }
        private void rbAudio_CheckedChanged(object sender, EventArgs e) {
            if (rbAudio.Checked) {
                cbQuality.Enabled = true;
                cbFormat.Enabled = true;
                txtArgs.ReadOnly = true;
                reloadAudioParams();
                txtArgs.Clear();

                if (Settings.Default.saveDlParams) {
                    cbFormat.SelectedIndex = Settings.Default.audFormat;
                    cbQuality.SelectedIndex = Settings.Default.audQuality;
                }
            }
        }
        private void rbCustom_CheckedChanged(object sender, EventArgs e) {
            if (rbCustom.Checked) {
                cbQuality.Enabled = false;
                cbFormat.Enabled = false;
                txtArgs.ReadOnly = false;

                if (!string.IsNullOrWhiteSpace(Settings.Default.savedArgs))
                    txtArgs.Text = Settings.Default.savedArgs;

                cbQuality.SelectedIndex = -1;
                cbFormat.SelectedIndex = -1;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtURL.Text)) {
                MessageBox.Show("Please enter a URL before trying to download.");
                return;
            }

            int dlType = -1;
            string args = txtArgs.Text;
            string suffix = "";


            if (rbVideo.Checked) {
                if (Settings.Default.sortDownloads)
                    suffix = "\\Video";
                dlType = 0;
            }
            else if (rbAudio.Checked) {
                if (Settings.Default.sortDownloads)
                    suffix = "\\Audio";
                dlType = 1;
            }
            else if (rbCustom.Checked) {
                dlType = 2;
            }

            if (Download.downloadCustom(txtURL.Text, Settings.Default.DownloadDir + suffix, dlType, null, cbFormat.Text, cbQuality.Text))
                if (Settings.Default.ClearURL == true) {
                    txtURL.Clear();
                    Clipboard.Clear();
                }

            if (rbVideo.Checked) {
                if (Settings.Default.saveDlParams) {
                    Settings.Default.vidFormat = cbFormat.SelectedIndex;
                    Settings.Default.vidQuality = cbQuality.SelectedIndex;
                }
                Settings.Default.dlType = 0;
            }
            else if (rbAudio.Checked) {
                if (Settings.Default.saveDlParams) {
                    Settings.Default.audFormat = cbFormat.SelectedIndex;
                    Settings.Default.audQuality = cbQuality.SelectedIndex;
                }
                Settings.Default.dlType = 1;
            }
            else {
                if (Settings.Default.saveArgs)
                    Settings.Default.savedArgs = txtArgs.Text;
                Settings.Default.dlType = 2;
            }

            Settings.Default.Save();
        }
        #endregion
        #region Converter
        private void btnBrowseConvFile_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog { Title = "Select file to convert" };
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                txtConvFile.Text = ofd.FileName;
                btnBrowseConvSaveFile.Enabled = true;
                if (Settings.Default.SaveToMaster) {
                    if (rbConvAudio.Checked)
                        txtConvSave.Text = Path.GetDirectoryName(ofd.FileName) + "\\Output.mp3";
                    else if (rbConvVideo.Checked)
                        txtConvSave.Text = Path.GetDirectoryName(ofd.FileName) + "\\Output.mp4";
                }
                else {
                    if (rbConvAudio.Checked)
                        txtConvSave.Text = Environment.CurrentDirectory + "\\Output.mp3";
                    else if (rbConvVideo.Checked)
                        txtConvSave.Text = Environment.CurrentDirectory + "\\Output.mp4";
                }

                if (!btnConvert.Enabled)
                    btnConvert.Enabled = true;
            }
        }
        private void btnBrowseConvSaveFile_Click(object sender, EventArgs e) {
            string filt;
            SaveFileDialog sfd = new SaveFileDialog { Title = "Save converted file as...", AddExtension = true };
            if (rbConvAudio.Checked) {
                filt = "AAC (*.aac)|*.aac|FLAC (*.flac)|*.flac|M4A (*m4a)|*.m4a|MP3 (*.mp3)|*.mp3|OPUS (*.opus)|*.opus|Vorbis (*.ogg)|*.ogg|WAV (*.wav)|*wav";
                sfd.Filter = filt;
                sfd.DefaultExt = "MP3 (*.mp3)|*.mp3";
                sfd.FilterIndex = 4;
            }
            else if (rbConvVideo.Checked) {
                filt = "AVI (*.avi)|*.avi|FLV ( *.flv)|*.flv|MP4 (*.mp4)|*.mp4)|MKV (*.mkv)|*.mkv|WEBM (*.webm)|*.webm";
                sfd.Filter = filt;
                sfd.DefaultExt = "MP4 (*.mp4)|*.mp4";
                sfd.FilterIndex = 3;
            }
            else {
                filt = "All files (*.*)|*.*";
                sfd.Filter = filt;
                sfd.FilterIndex = 0;
            }
            if (Settings.Default.SaveToMaster) {
                sfd.InitialDirectory = Path.GetDirectoryName(txtConvFile.Text);
            }
            else {
                sfd.InitialDirectory = Environment.CurrentDirectory;
            }

            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                txtConvSave.Text = sfd.FileName;
                if (!btnConvert.Enabled)
                    btnConvert.Enabled = true;
            }
        }

        private void rbConvAudio_CheckedChanged(object sender, EventArgs e) {
            if (rbConvAudio.Checked) {
                reloadConvAudio();
                cbBit.Enabled = false;
                if (Settings.Default.saveConvParams) {
                    cbConvQuality.SelectedIndex = Settings.Default.convQualityAud;
                }
            }
        }
        private void rbConvVideo_CheckedChanged(object sender, EventArgs e) {
            if (rbConvVideo.Checked) {
                reloadConvVideo();
                cbBit.Enabled = true;
                if (Settings.Default.saveConvParams) {
                    cbConvQuality.SelectedIndex = Settings.Default.convQualityVid;
                    cbBit.SelectedIndex = Settings.Default.convVidBit;
                }
            }
        }

        private void cbConvQuality_SelectedIndexChanged(object sender, EventArgs e) {
        }

        private void btnConvert_Click(object sender, EventArgs e) {
            if (rbConvAudio.Checked) {
                Converter.convert(txtConvFile.Text, txtConvSave.Text, 1, Path.GetExtension(txtConvSave.Text), Int32.Parse(cbConvQuality.Text.Replace("K", "")));
            }
            else if (rbConvVideo.Checked) {
                Converter.convert(txtConvFile.Text, txtConvSave.Text, 0, Path.GetExtension(txtConvSave.Text), 0, Int32.Parse(cbConvQuality.Text.Split('x')[1]), Int32.Parse(cbBit.Text));
            }

            txtConvSave.Clear();
            btnConvert.Enabled = false;

            if (Settings.Default.saveConvParams)
                if (rbAudio.Checked) {
                    if (Settings.Default.convQualityAud != cbConvQuality.SelectedIndex)
                        Settings.Default.convQualityAud = cbConvQuality.SelectedIndex;
                }
                else if (rbVideo.Checked) {
                    if (Settings.Default.convQualityVid != cbConvQuality.SelectedIndex)
                        Settings.Default.convQualityVid = cbConvQuality.SelectedIndex;
                    if (Settings.Default.convVidBit != cbBit.SelectedIndex)
                        Settings.Default.convVidBit = cbBit.SelectedIndex;
                }
            Settings.Default.Save();
        }
        #endregion

        #region About / Settings


        #endregion
        #region Notification icon + ContextMenu
        private void niTray_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (this.Visible)
                this.Hide();
            else {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void cmTrayShow_Click(object sender, EventArgs e) {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
        private void cmTrayDownloadAudio_Click(object sender, EventArgs e) {
            Download.downloadBest(Clipboard.GetText(), Settings.Default.DownloadDir, 1);
        }
        private void cmTrayDownloadVideo_Click(object sender, EventArgs e) {
            Download.downloadBest(Clipboard.GetText(), Settings.Default.DownloadDir, 0);
        }
        private void cmTrayExit_Click(object sender, EventArgs e) {
            niTray.Visible = false;
            Environment.Exit(0);
        }
        #endregion

        #region mFrmMain
        private void mFrmMainSettings_Click(object sender, EventArgs e) {
            frmSettings settingsForm = new frmSettings();
            settingsForm.ShowDialog();
            settingsForm.Dispose();
            GC.Collect();
        }
        private void mFrmMainSupported_Click(object sender, EventArgs e) {
            Process.Start("https://rg3.github.io/youtube-dl/supportedsites.html");
        }
        private void mFrmMainAbout_Click(object sender, EventArgs e) {
            frmAbout aboutForm = new frmAbout();
            aboutForm.Show();
        }
        private void MainTabs_SelectedIndexChanged(object sender, EventArgs e) {
            if (MainTabs.SelectedIndex == 0)
                txtURL.Enabled = true;
            else
                txtURL.Enabled = false;
        }
        #endregion

        private void mUpdate_Click(object sender, EventArgs e) {
            if (Properties.Settings.Default.cloudVersion == -1)
                return;

            if (MessageBox.Show("Would you like to update to version " + Properties.Settings.Default.cloudVersion.ToString() + "?") == System.Windows.Forms.DialogResult.Yes) {
                Updater.createUpdaterStub(Properties.Settings.Default.cloudVersion);
                Updater.runUpdater();
            }
        }
    }
}