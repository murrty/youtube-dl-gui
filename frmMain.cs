using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmMain : Form {
        int ytDlAvailable = -1;
        int ffmpegAvailable = -1;


        string[] videoQuality = { "1920x1080", "1600x900", "1280x720", "960x540", "640x360" };
        string[] audioQuality = { "best", "8K", "16K", "24K", "32K", "40K", "48K", "56K", "64K", "80K", "96K", "112K", "128K", "160K", "192K", "224K", "256K", "320K" };

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

            ytDlAvailable = Verification.ytdlFullCheck();
            ffmpegAvailable = Verification.ffmpegFullCheck();
            trayIcon.ContextMenu = cmTray;
        }

        private void frmMain_Load(object sender, EventArgs e) {
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
                case -1:
                    rbConvertAuto.Checked = true;
                    break;
                case 0:
                    rbConvertVideo.Checked = true;
                    break;
                case 1:
                    rbConvertAudio.Checked = true;
                    break;
                default:
                    rbConvertAuto.Checked = true;
                    break;
            }

        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
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

            Saved.Default.formLocationX = this.Location.X;
            Saved.Default.formLocationY = this.Location.Y;

            Saved.Default.Save();
        }

        #region main menu
        private void mSettings_Click(object sender, EventArgs e) {
            frmSettings settings = new frmSettings();
            settings.ShowDialog();
            settings.Dispose();
        }
        private void mSites_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://ytdl-org.github.io/youtube-dl/supportedsites.html");
        }
        private void mAbout_Click(object sender, EventArgs e) {
            frmAbout about = new frmAbout();
            about.ShowDialog();
            about.Dispose();
        }
        #endregion

        #region tray menu
        private void cmShow_Click(object sender, EventArgs e) {
            this.Show();
        }

        private void cmDownloadAudio_Click(object sender, EventArgs e) {
            Download.downloadBest(Clipboard.GetText(), 1);
        }

        private void cmDownloadVideo_Click(object sender, EventArgs e) {
            Download.downloadBest(Clipboard.GetText(), 0);
        }

        private void cmCustomTxtBox_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtArgs.Text)) {
                MessageBox.Show("No arguments are currently in memory. Enter in custom arguments in the arguments text box on the main form.");
                return;
            }
            else {
                Download.downloadBest(Clipboard.GetText(), 2, txtArgs.Text);
            }
        }
        private void cmCustomTxt_Click(object sender, EventArgs e) {
            if (!System.IO.File.Exists(Environment.CurrentDirectory + "\\args.txt")) {
                MessageBox.Show("args.txt does not exist, create it and put in arguments to use this command");
                return;
            }
            else if (string.IsNullOrEmpty(System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\args.txt"))) {
                MessageBox.Show("args.txt is empty, save arguments to the file to use this command");
                return;
            }
            else {
                Download.downloadBest(Clipboard.GetText(), 2, System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\args.txt"));
            }
        }
        private void cmCustomSettings_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(Saved.Default.downloadArgs)) {
                MessageBox.Show("No arguments are saved in the application settings, save arguments to the settings to use this command");
                return;
            }
            else
            {
                Download.downloadBest(Clipboard.GetText(), 2, Saved.Default.downloadArgs);
            }
        }

        private void mConvertVideo_Click(object sender, EventArgs e) {
            convertFromTray(0);
        }
        private void mConvertAudio_Click(object sender, EventArgs e) {
            convertFromTray(1);
        }
        private void mConvertCustom_Click(object sender, EventArgs e) {
            convertFromTray(2);
        }
        private void mConvertAutomatic_Click(object sender, EventArgs e) {
            convertFromTray();
        }
        private void mConvertAutoFFmpeg_Click(object sender, EventArgs e) {
            convertFromTray(6);
        }

        private void cmExit_Click(object sender, EventArgs e) {
            Environment.Exit(0);
        }
        #endregion

        #region downloader
        private void rbCustom_CheckedChanged(object sender, EventArgs e) {
            txtArgs.ReadOnly = rbCustom.Checked;
        }

        private void txtUrl_MouseEnter(object sender, EventArgs e) {
            if (General.Default.hoverURL && txtUrl.Text != Clipboard.GetText()) {
                txtUrl.Text = Clipboard.GetText();
            }
        }

        private void btnDownload_Click(object sender, EventArgs e) {
            if (rbAudio.Checked) {
                if (General.Default.clearURL)
                    txtUrl.Clear();

                if (Download.downloadBest(txtUrl.Text, 1)) {
                }
                else {

                }
            }
            else if (rbVideo.Checked) {
                if (General.Default.clearURL)
                    txtUrl.Clear();

                if (Download.downloadBest(txtUrl.Text, 0)) {
                }
                else {

                }
            }
            else if (rbCustom.Checked) {
                if (General.Default.clearURL)
                    txtUrl.Clear();

                if (Download.downloadBest(txtUrl.Text, 2, txtArgs.Text)) {
                }
                else {

                }
            }


        }
        #endregion

        #region converter
        private void btnConvertInput_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Browse for file to convert";
                if (ofd.ShowDialog() == DialogResult.OK) {
                    txtConvertInput.Text = ofd.FileName;
                    string fileWithoutExt  = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
                    btnConvertOutput.Enabled = true;

                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "Save ouput to...";
                    sfd.FileName = fileWithoutExt;
                    if (rbConvertVideo.Checked) {
                        sfd.Filter = Convert.videoFormatsFilter;
                        if (Saved.Default.convertSaveVideoIndex > -1 && Converts.Default.detectFiletype)
                            sfd.FilterIndex = Saved.Default.convertSaveVideoIndex;
                        else
                            sfd.FilterIndex = 7;
                    }
                    else if (rbConvertAudio.Checked) {
                        sfd.Filter = Convert.audioFormatsFilter;
                        if (Saved.Default.convertSaveAudioIndex > -1 && Converts.Default.detectFiletype)
                            sfd.FilterIndex = Saved.Default.convertSaveAudioIndex;
                        else
                            sfd.FilterIndex = 7;
                    }
                    else {
                        sfd.Filter = "All File Formats (*.*)|(*.*)";
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

        private void btnConvertOutput_Click(object sender, EventArgs e) {
            using (SaveFileDialog sfd = new SaveFileDialog()) {
                sfd.Title = "Save ouput to...";
                sfd.FileName = System.IO.Path.GetFileNameWithoutExtension(txtConvertInput.Text);
                if (rbConvertVideo.Checked) {
                    sfd.Filter = Convert.videoFormatsFilter;
                    if (Saved.Default.convertSaveVideoIndex > -1 && Converts.Default.detectFiletype)
                        sfd.FilterIndex = Saved.Default.convertSaveVideoIndex;
                    else
                        sfd.FilterIndex = 7;
                }
                else if (rbConvertAudio.Checked) {
                    sfd.Filter = Convert.audioFormatsFilter;
                    if (Saved.Default.convertSaveAudioIndex > -1 && Converts.Default.detectFiletype)
                        sfd.FilterIndex = Saved.Default.convertSaveAudioIndex;
                    else
                        sfd.FilterIndex = 7;
                }
                else {
                    sfd.Filter = "All File Formats (*.*)|(*.*)";
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

        private void tmrToggleLabel_Tick(object sender, EventArgs e) {
            if (!lbConvStatus.Visible) {
                lbConvStatus.Visible = true;
            }
            else {
                lbConvStatus.Visible = false;
                tmrToggleLabel.Enabled = false;
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
                lbConvStatus.Text = "Finished converting";
                tmrToggleLabel.Enabled = true;
                if (Converts.Default.clearOutput)
                    txtConvertOutput.Clear();
                if (Converts.Default.clearInput)
                    txtConvertInput.Clear();
            }
            else {
                lbConvStatus.Text = "Conversion failed";
                tmrToggleLabel.Enabled = true;
            }

            btnConvert.Enabled = true;
            btnConvertInput.Enabled = true;
            btnConvertOutput.Enabled = true;

            GC.Collect();
        }

        private void cbConvertQuality_SelectedIndexChanged(object sender, EventArgs e) {
            //if (rbConvertVideo.Checked && cbConvertQuality.SelectedIndex > -1)
            //    videoIndex = cbConvertQuality.SelectedIndex;
            //else if (rbConvertAudio.Checked && cbConvertQuality.SelectedIndex > -1)
            //    audioIndex = cbConvertQuality.SelectedIndex;
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

    }
}
