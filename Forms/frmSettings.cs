using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmSettings : Form {
        #region const
        public bool ffmpegAvailabled = false;
        public bool ytdlAvailable = false;

        List<string> extensionsName = new List<string>();
        List<string> extensionsShort = new List<string>();
        #endregion

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);
        private void SetTextBoxHint(IntPtr TextboxHandle, string Hint) {
            SendMessage(TextboxHandle, 0x1501, (IntPtr)1, Hint);
        }

        public frmSettings() {
            InitializeComponent();
            loadSettings();

            SetTextBoxHint(txtExtensionsName.Handle, "Example Extension");
            SetTextBoxHint(txtExtensionsShort.Handle, "ext");
        }
        private void frmSettings_Load(object sender, EventArgs e) {

        }

        private void loadSettings() {
            if (General.Default.useStaticYtdl && !string.IsNullOrEmpty(General.Default.ytdlPath)) {
                txtYtdl.Text = General.Default.ytdlPath;
                chkSettingsGeneralUseStaticYoutubeDl.Checked = General.Default.useStaticYtdl;
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
                chkSettingsGeneralUseStaticFFmpeg.Checked = General.Default.useStaticFFmpeg;
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

            chkSettingsGeneralCheckForUpdatesOnLaunch.Checked = General.Default.checkForUpdates;
            chkSettingsGeneralHoverOverUrlToPasteClipboard.Checked = General.Default.hoverURL;
            chkSettingsGeneralClearUrlClipboardOnDownload.Checked = General.Default.clearURL;
            switch (General.Default.saveCustomArgs) {
                case 0:
                    rbSettingsGeneralCustomArgumentsDontSave.Checked = true;
                    break;
                case 1:
                    rbSettingsGeneralCustomArgumentsSaveAsArgsText.Checked = true;
                    break;
                case 2:
                    rbSettingsGeneralCustomArgumentsSaveInSettings.Checked = true;
                    break;
                default:
                    rbSettingsGeneralCustomArgumentsDontSave.Checked = true;
                    break;
            }


            if (Downloads.Default.downloadPath == string.Empty) {
                txtSaveto.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            }
            else {
                txtSaveto.Text = Downloads.Default.downloadPath;
            }

            txtFileNameSchema.Text = Downloads.Default.fileNameSchema;
            chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Checked = Downloads.Default.separateDownloads;
            chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked = Downloads.Default.separateIntoWebsiteURL;
            chkSettingsConverterDetectOutputFileType.Checked = Downloads.Default.saveParams;
            chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Checked = Downloads.Default.deleteYtdlOnClose;
            chksettingsDownloadsUseYoutubeDlsUpdater.Checked = Downloads.Default.useYtdlUpdater;
            chkSettingsDownloadsFixVReddIt.Checked = Downloads.Default.fixReddit;

            chkSettingsConverterDetectOutputFileType.Checked = Converts.Default.detectFiletype;
            chkSettingsConverterClearOutputAfterConverting.Checked = Converts.Default.clearOutput;
            chkSettingsConverterClearInputAfterConverting.Checked = Converts.Default.clearInput;
            chkSettingsConverterHideFFmpegCompileInfo.Checked = Converts.Default.hideFFmpegCompile;

            chkUseVideoBitrate.Checked = Converts.Default.videoUseBitrate;
            numConvertVideoBitrate.Value = Converts.Default.videoBitrate;
            chkSettingsConverterVideoPreset.Checked = Converts.Default.videoUsePreset;
            cbConvertVideoPreset.SelectedIndex = Converts.Default.videoPreset;
            chkUseVideoProfile.Checked = Converts.Default.videoUseProfile;
            cbConvertVideoProfile.SelectedIndex = Converts.Default.videoProfile;
            chkUseVideoCRF.Checked = Converts.Default.videoUseCRF;
            numConvertVideoCRF.Value = Converts.Default.videoCRF;

            chkSettingsConverterVideoFastStart.Checked = Converts.Default.videoFastStart;

            chkUseAudioBitrate.Checked = Converts.Default.audioUseBitrate;
            numConvertAudioBitrate.Value = Converts.Default.audioBitrate;

            txtSettingsConverterCustomArguments.Text = Saved.Default.convertCustom;

            loadExtensions();

            chkSettingsErrorsShowDetailedErrors.Checked = Errors.Default.detailedErrors;
            chkSettingsErrorsSaveErrorsAsErrorLog.Checked = Errors.Default.logErrors;
            chkSettingsErrorsSuppressErrors.Checked = Errors.Default.suppressErrors;

        }
        private void saveSettings() {
            General.Default.useStaticYtdl = chkSettingsGeneralUseStaticYoutubeDl.Checked;
            if (chkSettingsGeneralUseStaticYoutubeDl.Checked) {
                General.Default.ytdlPath = txtYtdl.Text;
            }
            General.Default.useStaticFFmpeg = chkSettingsGeneralUseStaticFFmpeg.Checked;
            if (chkSettingsGeneralUseStaticFFmpeg.Checked && !string.IsNullOrEmpty(txtFFmpeg.Text)) {
                General.Default.ffmpegPath = txtFFmpeg.Text;
            }
            General.Default.checkForUpdates = chkSettingsGeneralCheckForUpdatesOnLaunch.Checked;
            General.Default.hoverURL = chkSettingsGeneralHoverOverUrlToPasteClipboard.Checked;
            General.Default.clearURL = chkSettingsGeneralClearUrlClipboardOnDownload.Checked;
            if (rbSettingsGeneralCustomArgumentsDontSave.Checked)
                General.Default.saveCustomArgs = 0;
            else if (rbSettingsGeneralCustomArgumentsSaveAsArgsText.Checked)
                General.Default.saveCustomArgs = 1;
            else if (rbSettingsGeneralCustomArgumentsSaveInSettings.Checked)
                General.Default.saveCustomArgs = 2;
            else
                General.Default.saveCustomArgs = 0;

            Downloads.Default.fileNameSchema = txtFileNameSchema.Text;
            Downloads.Default.downloadPath = txtSaveto.Text;
            Downloads.Default.separateDownloads = chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Checked;
            Downloads.Default.separateIntoWebsiteURL = chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked;
            Downloads.Default.deleteYtdlOnClose = chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Checked;
            Downloads.Default.useYtdlUpdater = chksettingsDownloadsUseYoutubeDlsUpdater.Checked;
            Downloads.Default.fixReddit = chkSettingsDownloadsFixVReddIt.Checked;

            Converts.Default.detectFiletype = chkSettingsConverterDetectOutputFileType.Checked;
            Converts.Default.clearOutput = chkSettingsConverterClearOutputAfterConverting.Checked;
            Converts.Default.clearInput = chkSettingsConverterClearInputAfterConverting.Checked;
            Converts.Default.hideFFmpegCompile = chkSettingsConverterHideFFmpegCompileInfo.Checked;

            Converts.Default.videoUseBitrate = chkUseVideoBitrate.Checked;
            Converts.Default.videoBitrate = Decimal.ToInt32(numConvertVideoBitrate.Value);
            Converts.Default.videoUsePreset = chkSettingsConverterVideoPreset.Checked;
            Converts.Default.videoPreset = cbConvertVideoPreset.SelectedIndex;
            Converts.Default.videoUseProfile = chkUseVideoProfile.Checked;
            Converts.Default.videoProfile = cbConvertVideoProfile.SelectedIndex;
            Converts.Default.videoUseCRF = chkUseVideoCRF.Checked;
            Converts.Default.videoCRF = Decimal.ToInt32(numConvertVideoCRF.Value);
            Converts.Default.videoFastStart = chkSettingsConverterVideoFastStart.Checked;

            Converts.Default.audioUseBitrate = chkUseAudioBitrate.Checked;
            Converts.Default.audioBitrate = Decimal.ToInt32(numConvertAudioBitrate.Value);

            Saved.Default.convertCustom = txtSettingsConverterCustomArguments.Text;

            saveExtensions();

            Errors.Default.detailedErrors = chkSettingsErrorsShowDetailedErrors.Checked;
            Errors.Default.logErrors = chkSettingsErrorsSaveErrorsAsErrorLog.Checked;
            Errors.Default.suppressErrors = chkSettingsErrorsSuppressErrors.Checked;

            General.Default.Save();
            Downloads.Default.Save();
            Converts.Default.Save();
            Settings.Default.Save();
            Errors.Default.Save();
        }

        private void btnSettingsRedownloadYoutubeDl_Click(object sender, EventArgs e) {
            string ytdlPath = string.Empty;

            if (General.Default.useStaticYtdl && !string.IsNullOrEmpty(General.Default.ytdlPath)) {
                if (File.Exists(General.Default.ytdlPath)) {
                    // update
                    if (Downloads.Default.useYtdlUpdater) {
                        Process updateYtdl = new Process();
                        updateYtdl.StartInfo.FileName = General.Default.ytdlPath;
                        updateYtdl.StartInfo.Arguments = "-U";
                        updateYtdl.Start();
                        updateYtdl.WaitForExit();
                        MessageBox.Show("Youtube-dl is update, as far as i know");
                    }
                    else {
                        File.Delete(General.Default.ytdlPath);
                        if (Download.downloadYoutubeDL(General.Default.ytdlPath)) {
                            MessageBox.Show("Youtube-dl has been update.");
                        }
                        else {
                            MessageBox.Show("Youtube-dl has not been updated.");
                        }
                    }
                }
                else {
                    Download.downloadYoutubeDL(General.Default.ytdlPath);
                }
            }
            else {
                switch (Verification.ytdlFullCheck()) {
                    case 0:
                        // static
                        break;
                    case 1:
                        //current directory
                        break;
                    case 2:
                        //path
                        break;
                    case 3:
                        //cmd, can't find it though. default to current directory.
                        break;
                    default:
                        //none, so download
                        break;
                }
            }
        }

        private void btnSettingsSave_Click(object sender, EventArgs e) {
            saveSettings();
            this.Dispose();
        }
        private void btnSettingsCancel_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        #region General
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
        #endregion

        #region Downloads
        private void btnBrowseSaveto_Click(object sender, EventArgs e) {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
                fbd.Description = "Select a destionation where downloads will be saved to";
                fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

                if (fbd.ShowDialog() == DialogResult.OK) {
                    txtSaveto.Text = fbd.SelectedPath;
                }
            }
        }
        private void llSchema_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/ytdl-org/youtube-dl/blob/master/README.md#output-template");
        }
        #endregion

        #region Extensions
        private void loadExtensions() {
            if (!string.IsNullOrEmpty(Settings.Default.extensionsName)) {
                extensionsShort.AddRange(Settings.Default.extensionsShort.Split('|').ToList());
                extensionsName.AddRange(Settings.Default.extensionsName.Split('|').ToList());
                for (int i = 0; i < extensionsShort.Count; i++) {
                    listExtensions.Items.Add(extensionsName[i] + " (*." + extensionsShort[i] + ")");
                }
            }
        }
        private void saveExtensions() {
            if (extensionsName.Count > 0) {
                string ext = string.Empty;
                string shrt = string.Empty;
                for (int i = 0; i < extensionsName.Count; i++) {
                    ext += extensionsName[i] + '|';
                    shrt += extensionsShort[i] + '|';
                }
                ext = ext.TrimEnd('|');
                shrt = shrt.TrimEnd('|');

                Settings.Default.extensionsName = ext;
                Settings.Default.extensionsShort = shrt;
            }
            else {
                Settings.Default.extensionsName = string.Empty;
                Settings.Default.extensionsShort = string.Empty;
            }
        }

        private void btnSettingsExtensionsAdd_Click(object sender, EventArgs e) {
            if (txtExtensionsName.Text.Length == 0) {
                MessageBox.Show("Enter an extension name");
                return;
            }

            if (txtExtensionsShort.Text.Length == 0) {
                MessageBox.Show("Enter an extension");
                return;
            }

            extensionsName.Add(txtExtensionsName.Text.Replace("|", "/"));
            extensionsShort.Add(txtExtensionsShort.Text.Replace("|","/"));

            listExtensions.Items.Add(txtExtensionsName.Text + " (*." + txtExtensionsShort.Text + ")");
            txtExtensionsName.Clear();
            txtExtensionsShort.Clear();
        }
        private void listExtensions_SelectedIndexChanged(object sender, EventArgs e) {
            if (listExtensions.SelectedIndex > -1) {
                lbSettingsExtensionsFileName.Text = "FileName." + extensionsShort[listExtensions.SelectedIndex];
            }
        }
        private void btnSettingsExtensionsRemoveSelected_Click(object sender, EventArgs e) {
            extensionsName.RemoveAt(listExtensions.SelectedIndex);
            extensionsShort.RemoveAt(listExtensions.SelectedIndex);
            listExtensions.Items.RemoveAt(listExtensions.SelectedIndex);
            listExtensions.SelectedIndex = -1;
            lbSettingsExtensionsFileName.Text = "FileName.ext";
        }
        #endregion

    }
}
