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

        private bool LoadingForm = false;

        List<string> extensionsName = new List<string>();
        List<string> extensionsShort = new List<string>();
        #endregion

        public frmSettings() {
            InitializeComponent();
            LoadLanguage();
            CalculatePositions();
            loadSettings();
        }
        private void frmSettings_Load(object sender, EventArgs e) {
            LoadingForm = true;
            if (Config.ProgramConfig.Saved.SettingsFormSize != default(System.Drawing.Size)) {
                this.Size = Config.ProgramConfig.Saved.SettingsFormSize;
            }

            chkSettingsPortableToggleIni.Checked = Program.UseIni;
            LoadingForm = false;
        }

        private string GetHistoryFromComboBox(ComboBox CB) {
            string History = string.Empty;
            for (int i = 0; i < CB.Items.Count; i++) {
                History += CB.Items[i] + "|";
            }
            return History.Trim('|');
        }
        void LoadLanguage() {
            this.Text = lang.frmSettings;
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
            tabSettingsPortable.Text = lang.tabSettingsPortable;

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
            chkSettingsGeneralCheckForBetaUpdates.Text = lang.chkSettingsGeneralCheckForBetaUpdates;
            tipSettings.SetToolTip(chkSettingsGeneralCheckForBetaUpdates, lang.chkSettingsGeneralCheckForBetaUpdatesHint);
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
            chkSettingsDownloadsPreferFFmpeg.Text = lang.chkSettingsDownloadsPreferFFmpeg;
            tipSettings.SetToolTip(chkSettingsDownloadsPreferFFmpeg, lang.chkSettingsDownloadsPreferFFmpegHint);

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

            chksettingsDownloadsUseYoutubeDlsUpdater.Text = lang.chkSettingsDownloadsUseYoutubeDlsUpdater;
            tipSettings.SetToolTip(chksettingsDownloadsUseYoutubeDlsUpdater, lang.chksettingsDownloadsUseYoutubeDlsUpdaterHint);

            chkSettingsDownloadsSeparateBatchDownloads.Text = lang.chkSettingsDownloadsSeparateBatchDownloads;
            tipSettings.SetToolTip(chkSettingsDownloadsSeparateBatchDownloads, lang.chkSettingsDownloadsSeparateBatchDownloadsHint);
            chkSettingsDownloadsAddDateToBatchDownloadFolders.Text = lang.chkSettingsDownloadsAddDateToBatchDownloadFolders;
            tipSettings.SetToolTip(chkSettingsDownloadsAddDateToBatchDownloadFolders, lang.chkSettingsDownloadsAddDateToBatchDownloadFoldersHint);

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
            txtSettingsExtensionsExtensionFullName.TextHint = lang.txtSettingsExtensionsExtensionFullName;
            //tipSettings.SetToolTip(lbSettingsExtensionsExtensionFullName, lang.lbSettingsExtensionsExtensionFullNameHint);
            lbSettingsExtensionsExtensionShort.Text = lang.lbSettingsExtensionsExtensionShort;
            txtSettingsExtensionsExtensionShort.TextHint = lang.txtSettingsExtensionsExtensionShort;
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

            lbSettingsPortableInformation.Text = lang.lbSettingsPortableInformation;
            chkSettingsPortableToggleIni.Text = lang.chkSettingsPortableToggleIni;

        }
        void CalculatePositions() {
            chkSettingsGeneralCheckForUpdatesOnLaunch.Location = new System.Drawing.Point(
                (tabSettingsGeneral.Size.Width - chkSettingsGeneralCheckForUpdatesOnLaunch.Size.Width) / 2,
                chkSettingsGeneralCheckForUpdatesOnLaunch.Location.Y
            );
            chkSettingsGeneralCheckForBetaUpdates.Location = new System.Drawing.Point(
                (tabSettingsGeneral.Size.Width - chkSettingsGeneralCheckForBetaUpdates.Size.Width) / 2,
                chkSettingsGeneralCheckForBetaUpdates.Location.Y
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
            if (Config.ProgramConfig.General.UseStaticYtdl && !string.IsNullOrEmpty(Config.ProgramConfig.General.ytdlPath)) {
                txtSettingsGeneralYoutubeDlPath.Text = Config.ProgramConfig.General.ytdlPath;
                chkSettingsGeneralUseStaticYoutubeDl.Checked = Config.ProgramConfig.General.UseStaticYtdl;
            }
            else {
                if (verif.YoutubeDlPath != null) {
                    txtSettingsGeneralYoutubeDlPath.Text = verif.YoutubeDlPath;
                }
            }

            if (Config.ProgramConfig.General.UseStaticFFmpeg && !string.IsNullOrEmpty(Config.ProgramConfig.General.ffmpegPath)) {
                txtSettingsGeneralFFmpegPath.Text = Config.ProgramConfig.General.ffmpegPath;
                chkSettingsGeneralUseStaticFFmpeg.Checked = Config.ProgramConfig.General.UseStaticFFmpeg;
            }
            else {
                if (verif.FFmpegPath != null) {
                    txtSettingsGeneralFFmpegPath.Text = verif.FFmpegPath;
                }
            }

            chkSettingsGeneralCheckForUpdatesOnLaunch.Checked = Config.ProgramConfig.General.CheckForUpdatesOnLaunch;
            chkSettingsGeneralCheckForBetaUpdates.Checked = Config.ProgramConfig.Initialization.DownloadBetaVersions;
            chkSettingsGeneralHoverOverUrlToPasteClipboard.Checked = Config.ProgramConfig.General.HoverOverURLTextBoxToPaste;
            chkSettingsGeneralClearUrlOnDownload.Checked = Config.ProgramConfig.General.ClearURLOnDownload;
            chkSettingsGeneralClearClipboardOnDownload.Checked = Config.ProgramConfig.General.ClearClipboardOnDownload;
            switch (Config.ProgramConfig.General.SaveCustomArgs) {
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


            if (Config.ProgramConfig.Downloads.downloadPath == string.Empty) {
                txtSettingsDownloadsSavePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            }
            else {
                txtSettingsDownloadsSavePath.Text = Config.ProgramConfig.Downloads.downloadPath;
            }
            txtSettingsDownloadsFileNameSchema.Text = Config.ProgramConfig.Downloads.fileNameSchema;
            if (!string.IsNullOrEmpty(Config.ProgramConfig.Saved.FileNameSchemaHistory)) {
                txtSettingsDownloadsFileNameSchema.Items.AddRange(Config.ProgramConfig.Saved.FileNameSchemaHistory.Split('|'));
            }

            chkSettingsDownloadsSaveFormatQuality.Checked = Config.ProgramConfig.Downloads.SaveFormatQuality;
            if (Config.ProgramConfig.Downloads.SaveSubtitles) {
                chkSettingsDownloadsDownloadSubtitles.Checked = true;
                chkSettingsDownloadsEmbedSubtitles.Enabled = true;
            }
            else {
                chkSettingsDownloadsDownloadSubtitles.Checked = false;
                chkSettingsDownloadsEmbedSubtitles.Enabled = false;
            }
            chkSettingsDownloadsEmbedSubtitles.Checked = Config.ProgramConfig.Downloads.EmbedSubtitles;
            chkSettingsDownloadsSaveVideoInfo.Checked = Config.ProgramConfig.Downloads.SaveVideoInfo;
            chkSettingsDownloadsWriteMetadataToFile.Checked = Config.ProgramConfig.Downloads.WriteMetadata;
            chkSettingsDownloadsSaveDescription.Checked = Config.ProgramConfig.Downloads.SaveDescription;
            chkSettingsDownloadsKeepOriginalFiles.Checked = Config.ProgramConfig.Downloads.KeepOriginalFiles;
            chkSettingsDownloadsSaveAnnotations.Checked = Config.ProgramConfig.Downloads.SaveAnnotations;
            if (Config.ProgramConfig.Downloads.SaveThumbnail) {
                chkSettingsDownloadsSaveThumbnails.Checked = true;
                chkSettingsDownloadsEmbedThumbnails.Enabled = true;
            }
            else {
                chkSettingsDownloadsSaveThumbnails.Checked = false;
                chkSettingsDownloadsEmbedThumbnails.Enabled = false;
            }
            chkSettingsDownloadsEmbedThumbnails.Checked = Config.ProgramConfig.Downloads.EmbedThumbnails;
            chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Checked = Config.ProgramConfig.Downloads.deleteYtdlOnClose;
            chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Checked = Config.ProgramConfig.Downloads.separateDownloads;
            chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked = Config.ProgramConfig.Downloads.separateIntoWebsiteURL;
            chkSettingsDownloadsFixVReddIt.Checked = Config.ProgramConfig.Downloads.fixReddit;
            chkSettingsDownloadsPreferFFmpeg.Checked = Config.ProgramConfig.Downloads.PreferFFmpeg;
            chkSettingsDownloadsLimitDownload.Checked = Config.ProgramConfig.Downloads.LimitDownloads;
            numSettingsDownloadsLimitDownload.Value = Config.ProgramConfig.Downloads.DownloadLimit;
            cbSettingsDownloadsLimitDownload.SelectedIndex = Config.ProgramConfig.Downloads.DownloadLimitType;
            numSettingsDownloadsRetryAttempts.Value = Config.ProgramConfig.Downloads.RetryAttempts;
            chkSettingsDownloadsForceIpv4.Checked = Config.ProgramConfig.Downloads.ForceIPv4;
            chkSettingsDownloadsForceIpv6.Checked = Config.ProgramConfig.Downloads.ForceIPv6;
            chkSettingsDownloadsUseProxy.Checked = Config.ProgramConfig.Downloads.UseProxy;
            cbSettingsDownloadsProxyType.SelectedIndex = Config.ProgramConfig.Downloads.ProxyType;
            txtSettingsDownloadsProxyIp.Text = Config.ProgramConfig.Downloads.ProxyIP;
            txtSettingsDownloadsProxyPort.Text = Config.ProgramConfig.Downloads.ProxyPort;
            chksettingsDownloadsUseYoutubeDlsUpdater.Checked = Config.ProgramConfig.Downloads.useYtdlUpdater;

            chkSettingsConverterDetectOutputFileType.Checked = Config.ProgramConfig.Converts.detectFiletype;
            chkSettingsConverterClearOutputAfterConverting.Checked = Config.ProgramConfig.Converts.clearOutput;
            chkSettingsConverterClearInputAfterConverting.Checked = Config.ProgramConfig.Converts.clearInput;
            chkSettingsConverterHideFFmpegCompileInfo.Checked = Config.ProgramConfig.Converts.hideFFmpegCompile;

            chkUseVideoBitrate.Checked = Config.ProgramConfig.Converts.videoUseBitrate;
            numConvertVideoBitrate.Value = Config.ProgramConfig.Converts.videoBitrate;
            chkSettingsConverterVideoPreset.Checked = Config.ProgramConfig.Converts.videoUsePreset;
            cbConvertVideoPreset.SelectedIndex = Config.ProgramConfig.Converts.videoPreset;
            chkUseVideoProfile.Checked = Config.ProgramConfig.Converts.videoUseProfile;
            cbConvertVideoProfile.SelectedIndex = Config.ProgramConfig.Converts.videoProfile;
            chkUseVideoCRF.Checked = Config.ProgramConfig.Converts.videoUseCRF;
            numConvertVideoCRF.Value = Config.ProgramConfig.Converts.videoCRF;

            chkSettingsConverterVideoFastStart.Checked = Config.ProgramConfig.Converts.videoFastStart;

            chkUseAudioBitrate.Checked = Config.ProgramConfig.Converts.audioUseBitrate;
            numConvertAudioBitrate.Value = Config.ProgramConfig.Converts.audioBitrate;

            txtSettingsConverterCustomArguments.Text = Config.ProgramConfig.Saved.convertCustom;

            loadExtensions();

            chkSettingsErrorsShowDetailedErrors.Checked = Config.ProgramConfig.Errors.detailedErrors;
            chkSettingsErrorsSaveErrorsAsErrorLog.Checked = Config.ProgramConfig.Errors.logErrors;
            chkSettingsErrorsSuppressErrors.Checked = Config.ProgramConfig.Errors.suppressErrors;
        }
        private void saveSettings() {
            Config.ProgramConfig.General.UseStaticYtdl = chkSettingsGeneralUseStaticYoutubeDl.Checked;
            if (chkSettingsGeneralUseStaticYoutubeDl.Checked) {
                Config.ProgramConfig.General.ytdlPath = txtSettingsGeneralYoutubeDlPath.Text;
            }
            Config.ProgramConfig.General.UseStaticFFmpeg = chkSettingsGeneralUseStaticFFmpeg.Checked;
            if (chkSettingsGeneralUseStaticFFmpeg.Checked && !string.IsNullOrEmpty(txtSettingsGeneralFFmpegPath.Text)) {
                Config.ProgramConfig.General.ffmpegPath = txtSettingsGeneralFFmpegPath.Text;
            }
            Config.ProgramConfig.General.CheckForUpdatesOnLaunch = chkSettingsGeneralCheckForUpdatesOnLaunch.Checked;
            Config.ProgramConfig.Initialization.DownloadBetaVersions = chkSettingsGeneralCheckForBetaUpdates.Checked;
            Config.ProgramConfig.General.HoverOverURLTextBoxToPaste = chkSettingsGeneralHoverOverUrlToPasteClipboard.Checked;
            Config.ProgramConfig.General.ClearURLOnDownload = chkSettingsGeneralClearUrlOnDownload.Checked;
            Config.ProgramConfig.General.ClearClipboardOnDownload = chkSettingsGeneralClearClipboardOnDownload.Checked;
            if (rbSettingsGeneralCustomArgumentsDontSave.Checked)
                Config.ProgramConfig.General.SaveCustomArgs = 0;
            else if (rbSettingsGeneralCustomArgumentsSaveAsArgsText.Checked)
                Config.ProgramConfig.General.SaveCustomArgs = 1;
            else if (rbSettingsGeneralCustomArgumentsSaveInSettings.Checked)
                Config.ProgramConfig.General.SaveCustomArgs = 2;
            else
                Config.ProgramConfig.General.SaveCustomArgs = 0;

            Config.ProgramConfig.Downloads.downloadPath = txtSettingsDownloadsSavePath.Text;
            Config.ProgramConfig.Downloads.fileNameSchema = txtSettingsDownloadsFileNameSchema.Text;
            if (!txtSettingsDownloadsFileNameSchema.Items.Contains(txtSettingsDownloadsFileNameSchema.Text)) {
                txtSettingsDownloadsFileNameSchema.Items.Add(txtSettingsDownloadsFileNameSchema.Text);
            }
            string FileNameSchemaHistory = GetHistoryFromComboBox(txtSettingsDownloadsFileNameSchema);
            if (Config.ProgramConfig.Saved.FileNameSchemaHistory != FileNameSchemaHistory) {
                Config.ProgramConfig.Saved.FileNameSchemaHistory = FileNameSchemaHistory;
            }

            Config.ProgramConfig.Downloads.SaveFormatQuality = chkSettingsDownloadsSaveFormatQuality.Checked;
            Config.ProgramConfig.Downloads.SaveSubtitles = chkSettingsDownloadsDownloadSubtitles.Checked;
            Config.ProgramConfig.Downloads.EmbedSubtitles = chkSettingsDownloadsEmbedSubtitles.Checked;
            Config.ProgramConfig.Downloads.SaveVideoInfo = chkSettingsDownloadsSaveVideoInfo.Checked;
            Config.ProgramConfig.Downloads.WriteMetadata = chkSettingsDownloadsWriteMetadataToFile.Checked;
            Config.ProgramConfig.Downloads.SaveDescription = chkSettingsDownloadsSaveDescription.Checked;
            Config.ProgramConfig.Downloads.KeepOriginalFiles = chkSettingsDownloadsKeepOriginalFiles.Checked;
            Config.ProgramConfig.Downloads.SaveAnnotations = chkSettingsDownloadsSaveAnnotations.Checked;
            Config.ProgramConfig.Downloads.SaveThumbnail = chkSettingsDownloadsSaveThumbnails.Checked;
            Config.ProgramConfig.Downloads.EmbedThumbnails = chkSettingsDownloadsEmbedThumbnails.Checked;
            Config.ProgramConfig.Downloads.deleteYtdlOnClose = chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Checked;
            Config.ProgramConfig.Downloads.separateDownloads = chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Checked;
            Config.ProgramConfig.Downloads.separateIntoWebsiteURL = chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked;
            Config.ProgramConfig.Downloads.fixReddit = chkSettingsDownloadsFixVReddIt.Checked;
            Config.ProgramConfig.Downloads.PreferFFmpeg = chkSettingsDownloadsPreferFFmpeg.Checked;
            Config.ProgramConfig.Downloads.LimitDownloads = chkSettingsDownloadsLimitDownload.Checked;
            Config.ProgramConfig.Downloads.DownloadLimit = (int)numSettingsDownloadsLimitDownload.Value;
            Config.ProgramConfig.Downloads.DownloadLimitType = cbSettingsDownloadsLimitDownload.SelectedIndex;
            Config.ProgramConfig.Downloads.ForceIPv4 = chkSettingsDownloadsForceIpv4.Checked;
            Config.ProgramConfig.Downloads.ForceIPv6 = chkSettingsDownloadsForceIpv6.Checked;
            Config.ProgramConfig.Downloads.UseProxy = chkSettingsDownloadsUseProxy.Checked;
            Config.ProgramConfig.Downloads.ProxyType = cbSettingsDownloadsProxyType.SelectedIndex;
            Config.ProgramConfig.Downloads.ProxyIP = txtSettingsDownloadsProxyIp.Text;
            Config.ProgramConfig.Downloads.ProxyPort = txtSettingsDownloadsProxyPort.Text;
            Config.ProgramConfig.Downloads.useYtdlUpdater = chksettingsDownloadsUseYoutubeDlsUpdater.Checked;

            Config.ProgramConfig.Converts.detectFiletype = chkSettingsConverterDetectOutputFileType.Checked;
            Config.ProgramConfig.Converts.clearOutput = chkSettingsConverterClearOutputAfterConverting.Checked;
            Config.ProgramConfig.Converts.clearInput = chkSettingsConverterClearInputAfterConverting.Checked;
            Config.ProgramConfig.Converts.hideFFmpegCompile = chkSettingsConverterHideFFmpegCompileInfo.Checked;

            Config.ProgramConfig.Converts.videoUseBitrate = chkUseVideoBitrate.Checked;
            Config.ProgramConfig.Converts.videoBitrate = Decimal.ToInt32(numConvertVideoBitrate.Value);
            Config.ProgramConfig.Converts.videoUsePreset = chkSettingsConverterVideoPreset.Checked;
            Config.ProgramConfig.Converts.videoPreset = cbConvertVideoPreset.SelectedIndex;
            Config.ProgramConfig.Converts.videoUseProfile = chkUseVideoProfile.Checked;
            Config.ProgramConfig.Converts.videoProfile = cbConvertVideoProfile.SelectedIndex;
            Config.ProgramConfig.Converts.videoUseCRF = chkUseVideoCRF.Checked;
            Config.ProgramConfig.Converts.videoCRF = Decimal.ToInt32(numConvertVideoCRF.Value);
            Config.ProgramConfig.Converts.videoFastStart = chkSettingsConverterVideoFastStart.Checked;

            Config.ProgramConfig.Converts.audioUseBitrate = chkUseAudioBitrate.Checked;
            Config.ProgramConfig.Converts.audioBitrate = Decimal.ToInt32(numConvertAudioBitrate.Value);

            Config.ProgramConfig.Saved.convertCustom = txtSettingsConverterCustomArguments.Text;
            Config.ProgramConfig.Saved.SettingsFormSize = this.Size;

            saveExtensions();

            Config.ProgramConfig.Errors.detailedErrors = chkSettingsErrorsShowDetailedErrors.Checked;
            Config.ProgramConfig.Errors.logErrors = chkSettingsErrorsSaveErrorsAsErrorLog.Checked;
            Config.ProgramConfig.Errors.suppressErrors = chkSettingsErrorsSuppressErrors.Checked;

            Config.ProgramConfig.Initialization.Save();
            Config.ProgramConfig.General.Save();
            Config.ProgramConfig.Downloads.Save();
            Config.ProgramConfig.Converts.Save();
            Config.ProgramConfig.SettingsConfig.Save();
            Config.ProgramConfig.Errors.Save();
            Config.ProgramConfig.Saved.Save();
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
            Config.ProgramConfig.General.UseStaticYtdl = chkSettingsGeneralUseStaticYoutubeDl.Checked;
        }
        private void chkSettingsGeneralUseStaticFFmpeg_CheckedChanged(object sender, EventArgs e) {
            Config.ProgramConfig.General.UseStaticFFmpeg = chkSettingsGeneralUseStaticFFmpeg.Checked;
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
            if (!string.IsNullOrEmpty(Config.ProgramConfig.SettingsConfig.extensionsName)) {
                extensionsShort.AddRange(Config.ProgramConfig.SettingsConfig.extensionsShort.Split('|').ToList());
                extensionsName.AddRange(Config.ProgramConfig.SettingsConfig.extensionsName.Split('|').ToList());
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

                Config.ProgramConfig.SettingsConfig.extensionsName = ext;
                Config.ProgramConfig.SettingsConfig.extensionsShort = shrt;
            }
            else {
                Config.ProgramConfig.SettingsConfig.extensionsName = string.Empty;
                Config.ProgramConfig.SettingsConfig.extensionsShort = string.Empty;
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

        private void txtSettingsDownloadsFileNameSchema_KeyPress(object sender, KeyPressEventArgs e) {
            switch (e.KeyChar) {
                case '\\': case '/': case ':': case '*':
                case '?': case '"': case '<': case '>':
                case '|':
                    e.Handled = true;
                    break;
            }
        }

        private void chkSettingsPortableToggleIni_CheckedChanged(object sender, EventArgs e) {
            if (!LoadingForm) {
                Config.ProgramConfig.ConvertConfig(chkSettingsPortableToggleIni.Checked);
            }
        }

    }
}