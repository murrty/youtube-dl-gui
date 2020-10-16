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
        Verification verif = Verification.GetInstance();
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
            CalculatePositions();
            loadSettings();
        }
        private void frmSettings_Load(object sender, EventArgs e) {
            this.Icon = Properties.Resources.youtube_dl_gui;
            if (Saved.Default.SettingsFormSize != default(System.Drawing.Size)) {
                this.Size = Saved.Default.SettingsFormSize;
            }
        }

        void LoadLanguage() {
            btnSettingsRedownloadYoutubeDl.Text = lang.btnSettingsRedownloadYoutubeDl;
            tipSettings.SetToolTip(btnSettingsRedownloadYoutubeDl, lang.btnSettingsRedownloadYoutubeDlHint);
            btnSettingsCancel.Text = lang.GenericCancel;
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
            chkSettingsGeneralClearUrlOnDownload.Text = lang.chkSettingsGeneralClearUrlOnDownload;
            tipSettings.SetToolTip(chkSettingsGeneralClearUrlOnDownload, lang.chkSettingsGeneralClearUrlOnDownloadHint);
            chkSettingsGeneralClearClipboardOnDownload.Text = lang.chkSettingsGeneralClearClipboardOnDownload;
            tipSettings.SetToolTip(chkSettingsGeneralClearClipboardOnDownload, lang.chkSettingsGeneralClearClipboardOnDownloadHint);
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

            tabDownloadsGeneral.Text = lang.tabDownloadsGeneral;
            tabDownloadsSorting.Text = lang.tabDownloadsSorting;
            tabDownloadsFixes.Text = lang.tabDownloadsFixes;
            tabDownloadsConnection.Text = lang.tabDownloadsConnection;
            tabDownloadsUpdating.Text = lang.tabDownloadsUpdating;

            chkSettingsDownloadsSaveFormatQuality.Text = lang.chkSettingsDownloadsSaveFormatQuality;
            tipSettings.SetToolTip(chkSettingsDownloadsSaveFormatQuality, lang.chkSettingsDownloadsSaveFormatQualityHint);
            chkSettingsDownloadsDownloadSubtitles.Text = lang.chkSettingsDownloadsDownloadSubtitles;
            tipSettings.SetToolTip(chkSettingsDownloadsDownloadSubtitles, lang.chkSettingsDownloadsDownloadSubtitlesHint);
            chkSettingsDownloadsEmbedSubtitles.Text = lang.chkSettingsDownloadsEmbedSubtitles;
            tipSettings.SetToolTip(chkSettingsDownloadsEmbedSubtitles, lang.chkSettingsDownloadsEmbedSubtitlesHint);
            chkSettingsDownloadsSaveVideoInfo.Text = lang.chkSettingsDownloadsSaveVideoInfo;
            tipSettings.SetToolTip(chkSettingsDownloadsSaveVideoInfo, lang.chkSettingsDownloadsSaveVideoInfoHint);
            chkSettingsDownloadsWriteMetadataToFile.Text = lang.chkSettingsDownloadsWriteMetadataToFile;
            tipSettings.SetToolTip(chkSettingsDownloadsWriteMetadataToFile, lang.chkSettingsDownloadsWriteMetadataToFileHint);
            chkSettingsDownloadsSaveDescription.Text = lang.chkSettingsDownloadsSaveDescription;
            tipSettings.SetToolTip(chkSettingsDownloadsSaveDescription, lang.chkSettingsDownloadsSaveDescriptionHint);
            chkSettingsDownloadsKeepOriginalFiles.Text = lang.chkSettingsDownloadsKeepOriginalFiles;
            tipSettings.SetToolTip(chkSettingsDownloadsKeepOriginalFiles, lang.chkSettingsDownloadsKeepOriginalFilesHint);
            chkSettingsDownloadsSaveAnnotations.Text = lang.chkSettingsDownloadsSaveAnnotations;
            tipSettings.SetToolTip(chkSettingsDownloadsSaveAnnotations, lang.chkSettingsDownloadsSaveAnnotationsHint);
            chkSettingsDownloadsSaveThumbnails.Text = lang.chkSettingsDownloadsSaveThumbnails;
            tipSettings.SetToolTip(chkSettingsDownloadsSaveThumbnails, lang.chkSettingsDownloadsSaveThumbnailsHint);
            chkSettingsDownloadsEmbedThumbnails.Text = lang.chkSettingsDownloadsEmbedThumbnails;
            tipSettings.SetToolTip(chkSettingsDownloadsEmbedThumbnails, lang.chkSettingsDownloadsEmbedThumbnailsHint);
            chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Text = lang.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing;
            tipSettings.SetToolTip(chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing, lang.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint);
            chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Text = lang.chkSettingsDownloadsSeparateDownloadsToDifferentFolders;
            tipSettings.SetToolTip(chkSettingsDownloadsSeparateDownloadsToDifferentFolders, lang.chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint);
            chkSettingsDownloadsSeparateIntoWebsiteUrl.Text = lang.chkSettingsDownloadsSeparateIntoWebsiteUrl;
            tipSettings.SetToolTip(chkSettingsDownloadsSeparateIntoWebsiteUrl, lang.chkSettingsDownloadsSeparateIntoWebsiteUrlHint);
            chkSettingsDownloadsFixVReddIt.Text = lang.chkSettingsDownloadsFixVReddIt;
            tipSettings.SetToolTip(chkSettingsDownloadsFixVReddIt, lang.chkSettingsDownloadsFixVReddItHint);

            chkSettingsDownloadsLimitDownload.Text = lang.chkSettingsDownloadsLimitDownload;
            tipSettings.SetToolTip(chkSettingsDownloadsLimitDownload, lang.chkSettingsDownloadsLimitDownloadHint);
            tipSettings.SetToolTip(numSettingsDownloadsLimitDownload, lang.numSettingsDownloadsLimitDownloadHint);
            tipSettings.SetToolTip(cbSettingsDownloadsLimitDownload, lang.cbSettingsDownloadsLimitDownloadHint);
            lbSettingsDownloadsRetryAttempts.Text = lang.lbSettingsDownloadsRetryAttempts;
            tipSettings.SetToolTip(lbSettingsDownloadsRetryAttempts, lang.lbSettingsDownloadsRetryAttemptsHint);
            tipSettings.SetToolTip(numSettingsDownloadsRetryAttempts, lang.numSettingsDownloadsRetryAttemptsHint);
            chkSettingsDownloadsForceIpv4.Text = lang.chkSettingsDownloadsForceIpv4;
            tipSettings.SetToolTip(chkSettingsDownloadsForceIpv4, lang.chkSettingsDownloadsForceIpv4Hint);
            chkSettingsDownloadsForceIpv6.Text = lang.chkSettingsDownloadsForceIpv6;
            tipSettings.SetToolTip(chkSettingsDownloadsForceIpv6, lang.chkSettingsDownloadsForceIpv6Hint);
            chkSettingsDownloadsUseProxy.Text = lang.chkSettingsDownloadsUseProxy;
            tipSettings.SetToolTip(chkSettingsDownloadsUseProxy, lang.chkSettingsDownloadsUseProxyHint);
            tipSettings.SetToolTip(cbSettingsDownloadsProxyType, lang.cbSettingsDownloadsProxyTypeHint);
            tipSettings.SetToolTip(txtSettingsDownloadsProxyIp, lang.txtSettingsDownloadsProxyIpHint);
            tipSettings.SetToolTip(txtSettingsDownloadsProxyPort, lang.txtSettingsDownloadsProxyPortHint);

            chksettingsDownloadsUseYoutubeDlsUpdater.Text = lang.chksettingsDownloadsUseYoutubeDlsUpdater;
            tipSettings.SetToolTip(chksettingsDownloadsUseYoutubeDlsUpdater, lang.chksettingsDownloadsUseYoutubeDlsUpdaterHint);

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
            lbSettingsExtensionsFileName.Text = lang.lbSettingsExtensionsFileName + ".ext";
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
        void CalculatePositions() {
            chkSettingsGeneralCheckForUpdatesOnLaunch.Location = new System.Drawing.Point(
                (tabSettingsGeneral.Size.Width - chkSettingsGeneralCheckForUpdatesOnLaunch.Size.Width) / 2,
                chkSettingsGeneralCheckForUpdatesOnLaunch.Location.Y
                );
            chkSettingsGeneralHoverOverUrlToPasteClipboard.Location = new System.Drawing.Point(
                (tabSettingsGeneral.Size.Width - chkSettingsGeneralHoverOverUrlToPasteClipboard.Size.Width) / 2,
                chkSettingsGeneralHoverOverUrlToPasteClipboard.Location.Y
                );
            chkSettingsGeneralClearUrlOnDownload.Location = new System.Drawing.Point(
                (tabSettingsGeneral.Size.Width - chkSettingsGeneralClearUrlOnDownload.Size.Width) / 2,
                chkSettingsGeneralClearUrlOnDownload.Location.Y
                );
            chkSettingsGeneralClearClipboardOnDownload.Location = new System.Drawing.Point(
                (tabSettingsGeneral.Size.Width - chkSettingsGeneralClearClipboardOnDownload.Size.Width) / 2,
                chkSettingsGeneralClearClipboardOnDownload.Location.Y
                );

            rbSettingsGeneralCustomArgumentsDontSave.Location = new System.Drawing.Point(
                (gbSettingsGeneralCustomArguments.Size.Width - (rbSettingsGeneralCustomArgumentsDontSave.Size.Width + rbSettingsGeneralCustomArgumentsSaveAsArgsText.Size.Width + rbSettingsGeneralCustomArgumentsSaveInSettings.Size.Width)) / 2,
                rbSettingsGeneralCustomArgumentsDontSave.Location.Y
                );
            rbSettingsGeneralCustomArgumentsSaveAsArgsText.Location = new System.Drawing.Point(
                (rbSettingsGeneralCustomArgumentsDontSave.Location.X + rbSettingsGeneralCustomArgumentsDontSave.Size.Width) + 2,
                rbSettingsGeneralCustomArgumentsDontSave.Location.Y
                );
            rbSettingsGeneralCustomArgumentsSaveInSettings.Location = new System.Drawing.Point(
                (rbSettingsGeneralCustomArgumentsSaveAsArgsText.Location.X + rbSettingsGeneralCustomArgumentsSaveAsArgsText.Size.Width) + 2,
                rbSettingsGeneralCustomArgumentsSaveAsArgsText.Location.Y
                );


            llSettingsDownloadsSchemaHelp.Location = new System.Drawing.Point(
                (lbSettingsDownloadsFileNameSchema.Location.X + lbSettingsDownloadsFileNameSchema.Size.Width) - 4,
                lbSettingsDownloadsFileNameSchema.Location.Y
                );
            chkSettingsDownloadsEmbedThumbnails.Location = new System.Drawing.Point(
                (chkSettingsDownloadsSaveThumbnails.Location.X + chkSettingsDownloadsSaveThumbnails.Size.Width + 2),
                chkSettingsDownloadsSaveThumbnails.Location.Y
                );
            chkSettingsDownloadsWriteMetadataToFile.Location = new System.Drawing.Point(
                (chkSettingsDownloadsSaveVideoInfo.Location.X + chkSettingsDownloadsSaveVideoInfo.Size.Width + 2),
                chkSettingsDownloadsSaveVideoInfo.Location.Y
                );
            chkSettingsDownloadsKeepOriginalFiles.Location = new System.Drawing.Point(
                (chkSettingsDownloadsSaveDescription.Location.X + chkSettingsDownloadsSaveDescription.Size.Width + 2),
                chkSettingsDownloadsSaveDescription.Location.Y
                );
            chkSettingsDownloadsEmbedSubtitles.Location = new System.Drawing.Point(
                (chkSettingsDownloadsDownloadSubtitles.Location.X + chkSettingsDownloadsDownloadSubtitles.Size.Width + 2),
                chkSettingsDownloadsDownloadSubtitles.Location.Y
                );

            numSettingsDownloadsLimitDownload.Location = new System.Drawing.Point(
                (chkSettingsDownloadsLimitDownload.Location.X + chkSettingsDownloadsLimitDownload.Size.Width) + 2,
                numSettingsDownloadsLimitDownload.Location.Y
                );
            cbSettingsDownloadsLimitDownload.Location = new System.Drawing.Point(
                (numSettingsDownloadsLimitDownload.Location.X + numSettingsDownloadsLimitDownload.Size.Width) + 2,
                cbSettingsDownloadsLimitDownload.Location.Y
                );
            numSettingsDownloadsRetryAttempts.Location = new System.Drawing.Point(
                (lbSettingsDownloadsRetryAttempts.Location.X + lbSettingsDownloadsRetryAttempts.Size.Width),
                numSettingsDownloadsRetryAttempts.Location.Y
                );
        }
        private void loadSettings() {
            if (General.Default.UseStaticYtdl && !string.IsNullOrEmpty(General.Default.ytdlPath)) {
                txtSettingsGeneralYoutubeDlPath.Text = General.Default.ytdlPath;
                chkSettingsGeneralUseStaticYoutubeDl.Checked = General.Default.UseStaticYtdl;
            }
            else {
                if (verif.YoutubeDlPath != null) {
                    txtSettingsGeneralYoutubeDlPath.Text = verif.YoutubeDlPath;
                }
            }

            if (General.Default.UseStaticFFmpeg && !string.IsNullOrEmpty(General.Default.ffmpegPath)) {
                txtSettingsGeneralFFmpegPath.Text = General.Default.ffmpegPath;
                chkSettingsGeneralUseStaticFFmpeg.Checked = General.Default.UseStaticFFmpeg;
            }
            else {
                if (verif.FFmpegPath != null) {
                    txtSettingsGeneralFFmpegPath.Text = verif.FFmpegPath;
                }
            }

            chkSettingsGeneralCheckForUpdatesOnLaunch.Checked = General.Default.CheckForUpdatesOnLaunch;
            chkSettingsGeneralHoverOverUrlToPasteClipboard.Checked = General.Default.HoverOverURLTextBoxToPaste;
            chkSettingsGeneralClearUrlOnDownload.Checked = General.Default.ClearURLOnDownload;
            chkSettingsGeneralClearClipboardOnDownload.Checked = General.Default.ClearClipboardOnDownload;
            switch (General.Default.SaveCustomArgs) {
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

            chkSettingsDownloadsSaveFormatQuality.Checked = Downloads.Default.SaveFormatQuality;
            //chkSettingsDownloadsDownloadSubtitles.Checked = Downloads.Default.SaveSubtitles;
            if (Downloads.Default.SaveSubtitles) {
                chkSettingsDownloadsDownloadSubtitles.Checked = true;
                chkSettingsDownloadsEmbedSubtitles.Enabled = true;
            }
            else {
                chkSettingsDownloadsDownloadSubtitles.Checked = false;
                chkSettingsDownloadsEmbedSubtitles.Enabled = false;
            }
            chkSettingsDownloadsEmbedSubtitles.Checked = Downloads.Default.EmbedSubtitles;
            chkSettingsDownloadsSaveVideoInfo.Checked = Downloads.Default.SaveVideoInfo;
            chkSettingsDownloadsWriteMetadataToFile.Checked = Downloads.Default.WriteMetadata;
            chkSettingsDownloadsSaveDescription.Checked = Downloads.Default.SaveDescription;
            chkSettingsDownloadsKeepOriginalFiles.Checked = Downloads.Default.KeepOriginalFiles;
            chkSettingsDownloadsSaveAnnotations.Checked = Downloads.Default.SaveAnnotations;
            //chkSettingsDownloadsSaveThumbnails.Checked = Downloads.Default.SaveThumbnail;
            if (Downloads.Default.SaveThumbnail) {
                chkSettingsDownloadsSaveThumbnails.Checked = true;
                chkSettingsDownloadsEmbedThumbnails.Enabled = true;
            }
            else {
                chkSettingsDownloadsSaveThumbnails.Checked = false;
                chkSettingsDownloadsEmbedThumbnails.Enabled = false;
            }
            chkSettingsDownloadsEmbedThumbnails.Checked = Downloads.Default.EmbedThumbnails;
            chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Checked = Downloads.Default.deleteYtdlOnClose;
            chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Checked = Downloads.Default.separateDownloads;
            chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked = Downloads.Default.separateIntoWebsiteURL;
            chkSettingsDownloadsFixVReddIt.Checked = Downloads.Default.fixReddit;
            chkSettingsDownloadsLimitDownload.Checked = Downloads.Default.LimitDownloads;
            numSettingsDownloadsLimitDownload.Value = Downloads.Default.DownloadLimit;
            cbSettingsDownloadsLimitDownload.SelectedIndex = Downloads.Default.DownloadLimitType;
            numSettingsDownloadsRetryAttempts.Value = Downloads.Default.RetryAttempts;
            chkSettingsDownloadsForceIpv4.Checked = Downloads.Default.ForceIPv4;
            chkSettingsDownloadsForceIpv6.Checked = Downloads.Default.ForceIPv6;
            chkSettingsDownloadsUseProxy.Checked = Downloads.Default.UseProxy;
            cbSettingsDownloadsProxyType.SelectedIndex = Downloads.Default.ProxyType;
            txtSettingsDownloadsProxyIp.Text = Downloads.Default.ProxyIP;
            txtSettingsDownloadsProxyPort.Text = Downloads.Default.ProxyPort;
            chksettingsDownloadsUseYoutubeDlsUpdater.Checked = Downloads.Default.useYtdlUpdater;

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
            General.Default.UseStaticYtdl = chkSettingsGeneralUseStaticYoutubeDl.Checked;
            if (chkSettingsGeneralUseStaticYoutubeDl.Checked) {
                General.Default.ytdlPath = txtSettingsGeneralYoutubeDlPath.Text;
            }
            General.Default.UseStaticFFmpeg = chkSettingsGeneralUseStaticFFmpeg.Checked;
            if (chkSettingsGeneralUseStaticFFmpeg.Checked && !string.IsNullOrEmpty(txtSettingsGeneralFFmpegPath.Text)) {
                General.Default.ffmpegPath = txtSettingsGeneralFFmpegPath.Text;
            }
            General.Default.CheckForUpdatesOnLaunch = chkSettingsGeneralCheckForUpdatesOnLaunch.Checked;
            General.Default.HoverOverURLTextBoxToPaste = chkSettingsGeneralHoverOverUrlToPasteClipboard.Checked;
            General.Default.ClearURLOnDownload = chkSettingsGeneralClearUrlOnDownload.Checked;
            General.Default.ClearClipboardOnDownload = chkSettingsGeneralClearClipboardOnDownload.Checked;
            if (rbSettingsGeneralCustomArgumentsDontSave.Checked)
                General.Default.SaveCustomArgs = 0;
            else if (rbSettingsGeneralCustomArgumentsSaveAsArgsText.Checked)
                General.Default.SaveCustomArgs = 1;
            else if (rbSettingsGeneralCustomArgumentsSaveInSettings.Checked)
                General.Default.SaveCustomArgs = 2;
            else
                General.Default.SaveCustomArgs = 0;

            Downloads.Default.fileNameSchema = txtSettingsDownloadsFileNameSchema.Text;
            Downloads.Default.downloadPath = txtSettingsDownloadsSavePath.Text;

            Downloads.Default.SaveFormatQuality = chkSettingsDownloadsSaveFormatQuality.Checked;
            Downloads.Default.SaveSubtitles = chkSettingsDownloadsDownloadSubtitles.Checked;
            Downloads.Default.EmbedSubtitles = chkSettingsDownloadsEmbedSubtitles.Checked;
            Downloads.Default.SaveVideoInfo = chkSettingsDownloadsSaveVideoInfo.Checked;
            Downloads.Default.WriteMetadata = chkSettingsDownloadsWriteMetadataToFile.Checked;
            Downloads.Default.SaveDescription = chkSettingsDownloadsSaveDescription.Checked;
            Downloads.Default.KeepOriginalFiles = chkSettingsDownloadsKeepOriginalFiles.Checked;
            Downloads.Default.SaveAnnotations = chkSettingsDownloadsSaveAnnotations.Checked;
            Downloads.Default.SaveThumbnail = chkSettingsDownloadsSaveThumbnails.Checked;
            Downloads.Default.EmbedThumbnails = chkSettingsDownloadsEmbedThumbnails.Checked;
            Downloads.Default.deleteYtdlOnClose = chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Checked;
            Downloads.Default.separateDownloads = chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Checked;
            Downloads.Default.separateIntoWebsiteURL = chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked;
            Downloads.Default.fixReddit = chkSettingsDownloadsFixVReddIt.Checked;
            Downloads.Default.LimitDownloads = chkSettingsDownloadsLimitDownload.Checked;
            Downloads.Default.DownloadLimit = (int)numSettingsDownloadsLimitDownload.Value;
            Downloads.Default.DownloadLimitType = cbSettingsDownloadsLimitDownload.SelectedIndex;
            Downloads.Default.ForceIPv4 = chkSettingsDownloadsForceIpv4.Checked;
            Downloads.Default.ForceIPv6 = chkSettingsDownloadsForceIpv6.Checked;
            Downloads.Default.UseProxy = chkSettingsDownloadsUseProxy.Checked;
            Downloads.Default.ProxyType = cbSettingsDownloadsProxyType.SelectedIndex;
            Downloads.Default.ProxyIP = txtSettingsDownloadsProxyIp.Text;
            Downloads.Default.ProxyPort = txtSettingsDownloadsProxyPort.Text;
            Downloads.Default.useYtdlUpdater = chksettingsDownloadsUseYoutubeDlsUpdater.Checked;

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
            Saved.Default.SettingsFormSize = this.Size;

            saveExtensions();

            Errors.Default.detailedErrors = chkSettingsErrorsShowDetailedErrors.Checked;
            Errors.Default.logErrors = chkSettingsErrorsSaveErrorsAsErrorLog.Checked;
            Errors.Default.suppressErrors = chkSettingsErrorsSuppressErrors.Checked;

            if (!Program.IsPortable) {
                General.Default.Save();
                Downloads.Default.Save();
                Converts.Default.Save();
                Settings.Default.Save();
                Errors.Default.Save();
                Saved.Default.Save();
            }
            else {
                CheckSettings.SavePortableSettings();
            }
        }

        private void btnSettingsRedownloadYoutubeDl_Click(object sender, EventArgs e) {
            UpdateChecker.UpdateYoutubeDl();
        }

        private void btnSettingsSave_Click(object sender, EventArgs e) {
            saveSettings();
            verif.RefreshLocation();
            this.Dispose();
        }
        private void btnSettingsCancel_Click(object sender, EventArgs e) {
            this.Dispose();
        }

        #region General
        private void chkSettingsGeneralUseStaticYoutubeDl_CheckedChanged(object sender, EventArgs e) {
            General.Default.UseStaticYtdl = chkSettingsGeneralUseStaticYoutubeDl.Checked;
        }
        private void chkSettingsGeneralUseStaticFFmpeg_CheckedChanged(object sender, EventArgs e) {
            General.Default.UseStaticFFmpeg = chkSettingsGeneralUseStaticFFmpeg.Checked;
        }
        private void btnSettingsGeneralBrowseYoutubeDl_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = lang.ofdTitleYoutubeDl;
                ofd.Filter = lang.ofdFilterYoutubeDl + " (*.EXE)|*.exe";
                ofd.FileName = "youtube-dl.exe";

                if (ofd.ShowDialog() == DialogResult.OK) {
                    txtSettingsGeneralYoutubeDlPath.Text = ofd.FileName;
                }
            }
        }
        private void btnSettingsGeneralBrowseFFmpeg_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = lang.ofdTitleFFmpeg;
                ofd.Filter = lang.ofdFilterFFmpeg + " (*.EXE)|*.exe";
                ofd.FileName = "ffmpeg.exe";


                if (ofd.ShowDialog() == DialogResult.OK) {
                    txtSettingsGeneralFFmpegPath.Text = Path.GetDirectoryName(ofd.FileName);
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
        private void chkSettingsDownloadsDownloadSubtitles_CheckedChanged(object sender, EventArgs e) {
            if (chkSettingsDownloadsDownloadSubtitles.Checked) {
                chkSettingsDownloadsEmbedSubtitles.Enabled = true;
            }
            else {
                chkSettingsDownloadsEmbedSubtitles.Enabled = false;
            }
        }
        private void chkSettingsDownloadsSaveThumbnails_CheckedChanged(object sender, EventArgs e) {
            if (chkSettingsDownloadsSaveThumbnails.Checked) {
                chkSettingsDownloadsEmbedThumbnails.Enabled = true;
            }
            else {
                chkSettingsDownloadsEmbedThumbnails.Enabled = false;
            }
        }

        private void chkSettingsDownloadsForceIpv4_CheckedChanged(object sender, EventArgs e) {
            if (chkSettingsDownloadsForceIpv4.Checked && chkSettingsDownloadsForceIpv6.Checked) {
                chkSettingsDownloadsForceIpv6.Checked = false;
            }
        }
        private void chkSettingsDownloadsForceIpv6_CheckedChanged(object sender, EventArgs e) {
            if (chkSettingsDownloadsForceIpv6.Checked && chkSettingsDownloadsForceIpv4.Checked) {
                chkSettingsDownloadsForceIpv4.Checked = false;
            }
        }

        private void txtSettingsDownloadsProxyIp_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)46 && e.KeyChar != (char)8) {
                e.Handled = true;
            }
        }
        private void txtSettingsDownloadsProxyPort_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
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
            extensionsShort.Add(txtSettingsExtensionsExtensionShort.Text.Replace("|", "/"));

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