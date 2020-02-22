using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmSettings : Form {
        #region vars
        Language lang = Language.GetInstance();
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
            LoadLanguage();
            loadSettings();
        }
        private void frmSettings_Load(object sender, EventArgs e) {

        }

        void LoadLanguage() {
            btnSettingsRedownloadYoutubeDl.Text = lang.btnSettingsRedownloadYoutubeDl;
            tipSettings.SetToolTip(btnSettingsRedownloadYoutubeDl, lang.btnSettingsRedownloadYoutubeDlHint);
            btnSettingsCancel.Text = lang.btnSettingsCancel;
            tipSettings.SetToolTip(btnSettingsCancel, lang.btnSettingsCancelHint);
            btnSettingsSave.Text = lang.btnSettingsSave;
            tipSettings.SetToolTip(btnSettingsSave, lang.btnSettingsSaveHint);

            tabSettingsGeneral.Text = lang.tabSettingsGeneral;
            tabSettingsDownloads.Text = lang.tabSettingsDownloads;
            tabSettingsConverter.Text = lang.tabSettingsConverter;
            tabSettingsExtensions.Text = lang.tabSettingsExtensions;
            tabSettingsErrors.Text = lang.tabSettingsErrors;

            lbSettingsGeneralYoutubeDlPath.Text = lang.lbSettingsGeneralYoutubeDlPath;
            tipSettings.SetToolTip(lbSettingsGeneralYoutubeDlPath, lang.lbSettingsGeneralYoutubeDlPathHint);
            chkSettingsGeneralUseStaticYoutubeDl.Text = lang.chkSettingsGeneralUseStaticYoutubeDl;
            tipSettings.SetToolTip(chkSettingsGeneralUseStaticYoutubeDl, lang.chkSettingsGeneralUseStaticYoutubeDlHint);
            tipSettings.SetToolTip(txtSettingsGeneralYoutubeDlPath, lang.txtSettingsGeneralYoutubeDlPathHint);
            tipSettings.SetToolTip(btnSettingsGeneralBrowseYoutubeDl, lang.btnSettingsGeneralBrowseYoutubeDlHint);
            lbSettingsGeneralFFmpegDirectory.Text = lang.lbSettingsGeneralFFmpegDirectory;
            tipSettings.SetToolTip(lbSettingsGeneralFFmpegDirectory, lang.lbSettingsGeneralFFmpegDirectoryHint);
            chkSettingsGeneralUseStaticFFmpeg.Text = lang.chkSettingsGeneralUseStaticFFmpeg;
            tipSettings.SetToolTip(chkSettingsGeneralUseStaticFFmpeg, lang.chkSettingsGeneralUseStaticFFmpegHint);
            tipSettings.SetToolTip(txtSettingsGeneralFFmpegPath, lang.txtSettingsGeneralFFmpegPathHint);
            tipSettings.SetToolTip(btnSettingsGeneralBrowseFFmpeg, lang.btnSettingsGeneralBrowseFFmpegHint);
            chkSettingsGeneralCheckForUpdatesOnLaunch.Text = lang.chkSettingsGeneralCheckForUpdatesOnLaunch;
            tipSettings.SetToolTip(chkSettingsGeneralCheckForUpdatesOnLaunch, lang.chkSettingsGeneralCheckForUpdatesOnLaunchHint);
            chkSettingsGeneralHoverOverUrlToPasteClipboard.Text = lang.chkSettingsGeneralHoverOverUrlToPasteClipboard;
            tipSettings.SetToolTip(chkSettingsGeneralHoverOverUrlToPasteClipboard, lang.chkSettingsGeneralHoverOverUrlToPasteClipboardHint);
            chkSettingsGeneralClearUrlClipboardOnDownload.Text = lang.chkSettingsGeneralClearUrlClipboardOnDownload;
            tipSettings.SetToolTip(chkSettingsGeneralClearUrlClipboardOnDownload, lang.chkSettingsGeneralClearUrlClipboardOnDownloadHint);
            gbSettingsGeneralCustomArguments.Text = lang.gbSettingsGeneralCustomArguments;
            tipSettings.SetToolTip(gbSettingsGeneralCustomArguments, lang.gbSettingsGeneralCustomArgumentsHint);
            rbSettingsGeneralCustomArgumentsDontSave.Text = lang.rbSettingsGeneralCustomArgumentsDontSave;
            tipSettings.SetToolTip(rbSettingsGeneralCustomArgumentsDontSave, lang.rbSettingsGeneralCustomArgumentsDontSaveHint);
            rbSettingsGeneralCustomArgumentsSaveAsArgsText.Text = lang.rbSettingsGeneralCustomArgumentsSaveAsArgsText;
            tipSettings.SetToolTip(rbSettingsGeneralCustomArgumentsSaveAsArgsText, lang.rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint);
            rbSettingsGeneralCustomArgumentsSaveInSettings.Text = lang.rbSettingsGeneralCustomArgumentsSaveInSettings;
            tipSettings.SetToolTip(rbSettingsGeneralCustomArgumentsSaveInSettings, lang.rbSettingsGeneralCustomArgumentsSaveInSettingsHint);

            lbSettingsDownloadsDownloadPath.Text = lang.lbSettingsDownloadsDownloadPath;
            tipSettings.SetToolTip(lbSettingsDownloadsDownloadPath, lang.lbSettingsDownloadsDownloadPathHint);
            tipSettings.SetToolTip(txtSettingsDownloadsSavePath, lang.txtSettingsDownloadsSavePathHint);
            tipSettings.SetToolTip(btnSettingsDownloadsBrowseSavePath, lang.btnSettingsDownloadsBrowseSavePathHint);
            tipSettings.SetToolTip(llSettingsDownloadsSchemaHelp, lang.llSettingsDownloadsSchemaHelpHint);
            lbSettingsDownloadsFileNameSchema.Text = lang.lbSettingsDownloadsFileNameSchema;
            tipSettings.SetToolTip(lbSettingsDownloadsFileNameSchema, lang.lbSettingsDownloadsFileNameSchemaHint);
            tipSettings.SetToolTip(txtSettingsDownloadsFileNameSchema, lang.txtSettingsDownloadsFileNameSchemaHint);
            chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Text = lang.chkSettingsDownloadsSeparateDownloadsToDifferentFolders;
            tipSettings.SetToolTip(chkSettingsDownloadsSeparateDownloadsToDifferentFolders, lang.chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint);
            chkSettingsDownloadsSaveFormatQuality.Text = lang.chkSettingsDownloadsSaveFormatQuality;
            tipSettings.SetToolTip(chkSettingsDownloadsSaveFormatQuality, lang.chkSettingsDownloadsSaveFormatQualityHint);
            chkSettingsDownloadsSeparateIntoWebsiteUrl.Text = lang.chkSettingsDownloadsSeparateIntoWebsiteUrl;
            tipSettings.SetToolTip(chkSettingsDownloadsSeparateIntoWebsiteUrl, lang.chkSettingsDownloadsSeparateIntoWebsiteUrlHint);
            chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Text = lang.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing;
            tipSettings.SetToolTip(chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing, lang.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint);
            chksettingsDownloadsUseYoutubeDlsUpdater.Text = lang.chksettingsDownloadsUseYoutubeDlsUpdater;
            tipSettings.SetToolTip(chksettingsDownloadsUseYoutubeDlsUpdater, lang.chksettingsDownloadsUseYoutubeDlsUpdaterHint);
            chkSettingsDownloadsFixVReddIt.Text = lang.chkSettingsDownloadsFixVReddIt;
            tipSettings.SetToolTip(chkSettingsDownloadsFixVReddIt, lang.chkSettingsDownloadsFixVReddItHint);
            chkSettingsDownloadsDownloadSubtitles.Text = lang.chkSettingsDownloadsDownloadSubtitles;
            tipSettings.SetToolTip(chkSettingsDownloadsDownloadSubtitles, lang.chkSettingsDownloadsDownloadSubtitlesHint);

            chkSettingsConverterClearOutputAfterConverting.Text = lang.chkSettingsConverterClearOutputAfterConverting;
            tipSettings.SetToolTip(chkSettingsConverterClearOutputAfterConverting, lang.chkSettingsConverterClearOutputAfterConvertingHint);
            chkSettingsConverterDetectOutputFileType.Text = lang.chkSettingsConverterDetectOutputFileType;
            tipSettings.SetToolTip(chkSettingsConverterDetectOutputFileType, lang.chkSettingsConverterDetectOutputFileTypeHint);
            chkSettingsConverterClearInputAfterConverting.Text = lang.chkSettingsConverterClearInputAfterConverting;
            tipSettings.SetToolTip(chkSettingsConverterClearInputAfterConverting, lang.chkSettingsConverterClearInputAfterConvertingHint);
            chkSettingsConverterHideFFmpegCompileInfo.Text = lang.chkSettingsConverterHideFFmpegCompileInfo;
            tipSettings.SetToolTip(chkSettingsConverterHideFFmpegCompileInfo, lang.chkSettingsConverterHideFFmpegCompileInfoHint);

            tcSettingsConverterVideo.Text = lang.tcSettingsConverterVideo;
            tcSettingsConverterAudio.Text = lang.tcSettingsConverterAudio;
            tcSettingsConverterCustom.Text = lang.tcSettingsConverterCustom;

            lbSettingsConverterVideoBitrate.Text = lang.lbSettingsConverterVideoBitrate;
            tipSettings.SetToolTip(lbSettingsConverterVideoBitrate, lang.lbSettingsConverterVideoBitrateHint);
            lbSettingsConverterVideoPreset.Text = lang.lbSettingsConverterVideoPreset;
            tipSettings.SetToolTip(lbSettingsConverterVideoPreset, lang.lbSettingsConverterVideoPresetHint);
            lbSettingsConverterVideoProfile.Text = lang.lbSettingsConverterVideoProfile;
            tipSettings.SetToolTip(lbSettingsConverterVideoProfile, lang.lbSettingsConverterVideoProfileHint);
            lbSettingsConverterVideoCRF.Text = lang.lbSettingsConverterVideoCRF;
            tipSettings.SetToolTip(lbSettingsConverterVideoCRF, lang.lbSettingsConverterVideoCRFHint);
            chkSettingsConverterVideoFastStart.Text = lang.chkSettingsConverterVideoFastStart;
            tipSettings.SetToolTip(chkSettingsConverterVideoFastStart, lang.chkSettingsConverterVideoFastStartHint);
            lbSettingsConverterAudioBitrate.Text = lang.lbSettingsConverterAudioBitrate;
            tipSettings.SetToolTip(lbSettingsConverterAudioBitrate, lang.lbSettingsConverterAudioBitrateHint);
            lbSettingsConverterCustomHeader.Text = lang.lbSettingsConverterCustomHeader;
            tipSettings.SetToolTip(txtSettingsConverterCustomArguments, lang.txtSettingsConverterCustomArgumentsHint);

            lbSettingsExtensionsHeader.Text = lang.lbSettingsExtensionsHeader;
            //tipSettings.SetToolTip(lbSettingsExtensionsHeader, lang.lbSettingsExtensionsHeaderHint);
            lbSettingsExtensionsExtensionFullName.Text = lang.lbSettingsExtensionsExtensionFullName;
            SetTextBoxHint(txtSettingsExtensionsExtensionFullName.Handle, lang.txtSettingsExtensionsExtensionFullName);
            //tipSettings.SetToolTip(lbSettingsExtensionsExtensionFullName, lang.lbSettingsExtensionsExtensionFullNameHint);
            lbSettingsExtensionsExtensionShort.Text = lang.lbSettingsExtensionsExtensionShort;
            SetTextBoxHint(txtSettingsExtensionsExtensionShort.Handle, lang.txtSettingsExtensionsExtensionShort);
            //tipSettings.SetToolTip(lbSettingsExtensionsExtensionShort, lang.lbSettingsExtensionsExtensionShortHint);
            btnSettingsExtensionsAdd.Text = lang.btnSettingsExtensionsAdd;
            //tipSettings.SetToolTip(btnSettingsExtensionsAdd, lang.btnSettingsExtensionsAddHint);
            lbSettingsExtensionsFileName.Text = lang.lbSettingsExtensionsFileName;
            //tipSettings.SetToolTip(lbSettingsExtensionsFileName, lang.lbSettingsExtensionsFileNameHint);
            btnSettingsExtensionsRemoveSelected.Text = lang.btnSettingsExtensionsRemoveSelected;
            //tipSettings.SetToolTip(btnSettingsExtensionsRemoveSelected, lang.btnSettingsExtensionsRemoveSelectedHint);

            chkSettingsErrorsShowDetailedErrors.Text = lang.chkSettingsErrorsShowDetailedErrors;
            tipSettings.SetToolTip(chkSettingsErrorsShowDetailedErrors, lang.chkSettingsErrorsShowDetailedErrorsHint);
            chkSettingsErrorsSaveErrorsAsErrorLog.Text = lang.chkSettingsErrorsSaveErrorsAsErrorLog;
            tipSettings.SetToolTip(chkSettingsErrorsSaveErrorsAsErrorLog, lang.chkSettingsErrorsSaveErrorsAsErrorLogHint);
            chkSettingsErrorsSuppressErrors.Text = lang.chkSettingsErrorsSuppressErrors;
            tipSettings.SetToolTip(chkSettingsErrorsSuppressErrors, lang.chkSettingsErrorsSuppressErrorsHint);

        }

        private void loadSettings() {
            if (General.Default.useStaticYtdl && !string.IsNullOrEmpty(General.Default.ytdlPath)) {
                txtSettingsGeneralYoutubeDlPath.Text = General.Default.ytdlPath;
                chkSettingsGeneralUseStaticYoutubeDl.Checked = General.Default.useStaticYtdl;
            }
            else {
                switch (Verification.ytdlFullCheck()) {
                    case 1:
                        txtSettingsGeneralYoutubeDlPath.Text = Environment.CurrentDirectory + "\\youtube-dl.exe";
                        break;
                    case 2:
                        txtSettingsGeneralYoutubeDlPath.Text = Verification.ytdlPathLocation() + "\\youtube-dl.exe";
                        break;
                    case 3:
                        txtSettingsGeneralYoutubeDlPath.Text = "CommandLine";
                        break;
                    case 0:
                        txtSettingsGeneralYoutubeDlPath.Text = General.Default.ytdlPath;
                        break;
                }
            }

            if (General.Default.useStaticFFmpeg && !string.IsNullOrEmpty(General.Default.ffmpegPath)) {
                txtSettingsGeneralFFmpegPath.Text = General.Default.ffmpegPath;
                chkSettingsGeneralUseStaticFFmpeg.Checked = General.Default.useStaticFFmpeg;
            }
            else {
                switch (Verification.ffmpegFullCheck()) {
                    case 1:
                        txtSettingsGeneralFFmpegPath.Text = Environment.CurrentDirectory;
                        break;
                    case 2:
                        txtSettingsGeneralFFmpegPath.Text = Verification.ffmpegPathLocation();
                        break;
                    case 3:
                        txtSettingsGeneralFFmpegPath.Text = "CommandLine";
                        break;
                    case 0:
                        txtSettingsGeneralFFmpegPath.Text = General.Default.ffmpegPath;
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
                txtSettingsDownloadsSavePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            }
            else {
                txtSettingsDownloadsSavePath.Text = Downloads.Default.downloadPath;
            }

            txtSettingsDownloadsFileNameSchema.Text = Downloads.Default.fileNameSchema;
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
                General.Default.ytdlPath = txtSettingsGeneralYoutubeDlPath.Text;
            }
            General.Default.useStaticFFmpeg = chkSettingsGeneralUseStaticFFmpeg.Checked;
            if (chkSettingsGeneralUseStaticFFmpeg.Checked && !string.IsNullOrEmpty(txtSettingsGeneralFFmpegPath.Text)) {
                General.Default.ffmpegPath = txtSettingsGeneralFFmpegPath.Text;
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

            Downloads.Default.fileNameSchema = txtSettingsDownloadsFileNameSchema.Text;
            Downloads.Default.downloadPath = txtSettingsDownloadsSavePath.Text;
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
            UpdateChecker.UpdateYoutubeDl();
        }

        private void btnSettingsSave_Click(object sender, EventArgs e) {
            saveSettings();
            this.Dispose();
        }
        private void btnSettingsCancel_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        #region General
        private void chkSettingsGeneralUseStaticYoutubeDl_CheckedChanged(object sender, EventArgs e) {
            General.Default.useStaticYtdl = chkSettingsGeneralUseStaticYoutubeDl.Checked;
        }
        private void chkSettingsGeneralUseStaticFFmpeg_CheckedChanged(object sender, EventArgs e) {
            General.Default.useStaticFFmpeg = chkSettingsGeneralUseStaticFFmpeg.Checked;
        }
        private void btnSettingsGeneralBrowseYoutubeDl_Click(object sender, EventArgs e) {
            using (SaveFileDialog sfd = new SaveFileDialog()) {
                sfd.Title = "Select youtube-dl.exe";
                sfd.Filter = "youtube-dl executable (*.EXE)|*.exe";
                sfd.FileName = "youtube-dl.exe";

                if (sfd.ShowDialog() == DialogResult.OK) {
                    txtSettingsGeneralYoutubeDlPath.Text = sfd.FileName;
                }
            }
        }
        private void btnSettingsGeneralBrowseFFmpeg_Click(object sender, EventArgs e) {
            using (SaveFileDialog sfd = new SaveFileDialog()) {
                sfd.Title = "Select ffmpeg.exe and ffprobe.exe";
                sfd.Filter = "ffmpeg & ffprobe executable (*.EXE)|*.exe";
                sfd.FileName = "ffmpeg.exe";


                if (sfd.ShowDialog() == DialogResult.OK) {
                    txtSettingsGeneralFFmpegPath.Text = Path.GetDirectoryName(sfd.FileName);
                }
            }
        }
        #endregion

        #region Downloads
        private void btnSettingsDownloadsBrowseSavePath_Click(object sender, EventArgs e) {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
                fbd.Description = "Select a destionation where downloads will be saved to";
                fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";

                if (fbd.ShowDialog() == DialogResult.OK) {
                    txtSettingsDownloadsSavePath.Text = fbd.SelectedPath;
                }
            }
        }
        private void llSettingsDownloadsSchemaHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
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
            if (txtSettingsExtensionsExtensionFullName.Text.Length == 0) {
                MessageBox.Show("Enter an extension name");
                return;
            }

            if (txtSettingsExtensionsExtensionShort.Text.Length == 0) {
                MessageBox.Show("Enter an extension");
                return;
            }

            extensionsName.Add(txtSettingsExtensionsExtensionFullName.Text.Replace("|", "/"));
            extensionsShort.Add(txtSettingsExtensionsExtensionShort.Text.Replace("|","/"));

            listExtensions.Items.Add(txtSettingsExtensionsExtensionFullName.Text + " (*." + txtSettingsExtensionsExtensionShort.Text + ")");
            txtSettingsExtensionsExtensionFullName.Clear();
            txtSettingsExtensionsExtensionShort.Clear();
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
