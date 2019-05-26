using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmSettings : Form {
        public bool ffmpegAvailabled = false;
        public bool ytdlAvailable = false;

        public string ffmpegPath = string.Empty;

        public frmSettings() {
            InitializeComponent();
            loadSettings();
        }
        private void frmSettings_Load(object sender, EventArgs e) {

        }

        private void loadSettings() {
            if (General.Default.useStaticYtdl && !string.IsNullOrEmpty(General.Default.ytdlPath)) {
                txtYtdl.Text = General.Default.ytdlPath;
                chkStaticYtdl.Checked = General.Default.useStaticYtdl;
            }
            else {
                switch (Verification.ytdlFullCheck()) {
                    case 1:
                        txtYtdl.Text = Environment.CurrentDirectory + "\\youtube-dl.exe";
                        break;
                    case 2:
                        txtYtdl.Text = Verification.ytdlPathLocation() + "\\youtube-dl.exe";
                        break;
                    case 3:
                        txtYtdl.Text = "CommandLine";
                        break;
                    case 0:
                        txtYtdl.Text = General.Default.ytdlPath;
                        break;
                }
            }

            if (General.Default.useStaticFFmpeg && !string.IsNullOrEmpty(General.Default.ffmpegPath)) {
                txtFFmpeg.Text = General.Default.ffmpegPath;
                chkStaticFF.Checked = General.Default.useStaticFFmpeg;
            }
            else {
                switch (Verification.ffmpegFullCheck()) {
                    case 1:
                        txtFFmpeg.Text = Environment.CurrentDirectory;
                        break;
                    case 2:
                        txtFFmpeg.Text = Verification.ffmpegPathLocation();
                        break;
                    case 3:
                        txtFFmpeg.Text = "CommandLine";
                        break;
                    case 0:
                        txtFFmpeg.Text = General.Default.ffmpegPath;
                        break;
                }
            }

            chkUpdates.Checked = General.Default.checkForUpdates;
            chkHover.Checked = General.Default.hoverURL;
            chkClear.Checked = General.Default.clearURL;
            switch (General.Default.saveCustomArgs) {
                case 0:
                    rbDontSaveArgs.Checked = true;
                    break;
                case 1:
                    rbArgsAsTxt.Checked = true;
                    break;
                case 2:
                    rbArgsAsSettings.Checked = true;
                    break;
                default:
                    rbDontSaveArgs.Checked = true;
                    break;
            }


            if (Downloads.Default.downloadPath == string.Empty) {
                txtSaveto.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            }
            else {
                txtSaveto.Text = Downloads.Default.downloadPath;
            }

            chkSeparate.Checked = Downloads.Default.separateDownloads;
            chkConvertDetectFiletype.Checked = Downloads.Default.saveParams;
            chkAutomaticallyDelete.Checked = Downloads.Default.deleteYtdlOnClose;
            chkYtdlUpdate.Checked = Downloads.Default.useYtdlUpdater;

            chkConvertDetectFiletype.Checked = Converts.Default.detectFiletype;
            chkConvClearOutput.Checked = Converts.Default.clearOutput;
            chkConvClearInput.Checked = Converts.Default.clearInput;
            chkConvertHideFFmpeg.Checked = Converts.Default.hideFFmpegCompile;

            numConvertVideoBitrate.Value = Converts.Default.videoBitrate;
            cbConvertVideoPreset.SelectedIndex = Converts.Default.videoPreset;
            cbConvertVideoProfile.SelectedIndex = Converts.Default.videoProfile;
            numConvertVideoCRF.Value = Converts.Default.videoCRF;
            chkVideoFastStart.Checked = Converts.Default.videoFastStart;

            txtConvertCustom.Text = Saved.Default.convertCustom;
            
        }
        private void saveSettings() {
            General.Default.useStaticYtdl = chkStaticYtdl.Checked;
            if (chkStaticYtdl.Checked) {
                General.Default.ytdlPath = txtYtdl.Text;
            }
            General.Default.useStaticFFmpeg = chkStaticFF.Checked;
            if (chkStaticFF.Checked && !string.IsNullOrEmpty(ffmpegPath)) {
                General.Default.ffmpegPath = ffmpegPath;
            }
            General.Default.checkForUpdates = chkUpdates.Checked;
            General.Default.hoverURL = chkHover.Checked;
            General.Default.clearURL = chkClear.Checked;
            if (rbDontSaveArgs.Checked)
                General.Default.saveCustomArgs = 0;
            else if (rbArgsAsTxt.Checked)
                General.Default.saveCustomArgs = 1;
            else if (rbArgsAsSettings.Checked)
                General.Default.saveCustomArgs = 2;
            else
                General.Default.saveCustomArgs = 0;

            Downloads.Default.downloadPath = txtSaveto.Text;
            Downloads.Default.separateDownloads = chkSeparate.Checked;
            Downloads.Default.deleteYtdlOnClose = chkAutomaticallyDelete.Checked;
            Downloads.Default.useYtdlUpdater = chkYtdlUpdate.Checked;

            Converts.Default.detectFiletype = chkConvertDetectFiletype.Checked;
            Converts.Default.clearOutput = chkConvClearOutput.Checked;
            Converts.Default.clearInput = chkConvClearInput.Checked;
            Converts.Default.hideFFmpegCompile = chkConvertHideFFmpeg.Checked;

            Converts.Default.videoBitrate = Decimal.ToInt32(numConvertVideoBitrate.Value);
            Converts.Default.videoPreset = cbConvertVideoPreset.SelectedIndex;
            Converts.Default.videoProfile = cbConvertVideoProfile.SelectedIndex;
            Converts.Default.videoCRF = Decimal.ToInt32(numConvertVideoCRF.Value);
            Converts.Default.videoFastStart = chkVideoFastStart.Checked;

            Saved.Default.convertCustom = txtConvertCustom.Text;

            General.Default.Save();
            Downloads.Default.Save();
            Converts.Default.Save();
        }

        private void llSchema_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/ytdl-org/youtube-dl/blob/master/README.md#output-template");
        }


        private void btnBrwsYtdl_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Select youtube-dl.exe";
                ofd.Filter = "youtube-dl executable (*.EXE)|*.exe";
                ofd.FileName = "youtube-dl.exe";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK) {
                    txtYtdl.Text = ofd.FileName;
                }
            }
        }

        private void btnBrwsFF_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = "Select ffmpeg.exe and ffprobe.exe";
                ofd.Filter = "ffmpeg & ffprobe executable (*.EXE)|*.exe";
                ofd.FileName = "ffmpeg.exe & ffprobe.exe";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK) {
                    txtFFmpeg.Text = Path.GetDirectoryName(ofd.FileName);
                }
            }
        }

        private void btnBrowseSaveto_Click(object sender, EventArgs e) {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
                fbd.Description = "Select a destionation where downloads will be saved to";
                fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

                if (fbd.ShowDialog() == DialogResult.OK) {
                    txtSaveto.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            saveSettings();
            this.Dispose();
        }
        private void btnCancel_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        private void btnRedownloadYtdl_Click(object sender, EventArgs e) {
            if (General.Default.useStaticYtdl && !string.IsNullOrEmpty(General.Default.ytdlPath)) {

            }
            else {

            }
        }

    }
}
