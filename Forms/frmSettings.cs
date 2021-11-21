using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmSettings : Form {

        #region vars
        public bool ffmpegAvailabled = false;
        public bool ytdlAvailable = false;

        private bool LoadingForm = false;

        readonly List<string> extensionsName = new List<string>();
        readonly List<string> extensionsShort = new List<string>();

        bool RefreshYtdl = false;
        bool RefreshFFmpeg = false;

        private bool useYtdlUpdater_Last;
        private int YtdlType_Last;
        #endregion

        public frmSettings() {
            InitializeComponent();
            LoadingForm = true;
            LoadLanguage();
            CalculatePositions();
            loadSettings();
        }
        private void frmSettings_Load(object sender, EventArgs e) {
            if (Config.Settings.Saved.SettingsFormSize != default) {
                this.Size = Config.Settings.Saved.SettingsFormSize;
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
            this.Text = Program.lang.frmSettings;
            btnSettingsRedownloadYoutubeDl.Text = Program.lang.btnSettingsRedownloadYoutubeDl;
            tipSettings.SetToolTip(btnSettingsRedownloadYoutubeDl, Program.lang.btnSettingsRedownloadYoutubeDlHint);
            btnSettingsCancel.Text = Program.lang.GenericCancel;
            tipSettings.SetToolTip(btnSettingsCancel, Program.lang.btnSettingsCancelHint);
            btnSettingsSave.Text = Program.lang.btnSettingsSave;
            tipSettings.SetToolTip(btnSettingsSave, Program.lang.btnSettingsSaveHint);

            //if (File.Exists(Program.verif.YoutubeDlPath)) {
            //    btnSettingsRedownloadYoutubeDl.Text = "Update youtube-dl";
            //}
            //else {
            //    btnSettingsRedownloadYoutubeDl.Text = "Download youtube-dl";
            //}

            tabSettingsGeneral.Text = Program.lang.tabSettingsGeneral;
            tabSettingsDownloads.Text = Program.lang.tabSettingsDownloads;
            tabSettingsConverter.Text = Program.lang.tabSettingsConverter;
            tabSettingsExtensions.Text = Program.lang.tabSettingsExtensions;
            tabSettingsErrors.Text = Program.lang.tabSettingsErrors;
            tabSettingsPortable.Text = Program.lang.tabSettingsPortable;

            lbSettingsGeneralYoutubeDlPath.Text = Program.lang.lbSettingsGeneralYoutubeDlPath;
            tipSettings.SetToolTip(lbSettingsGeneralYoutubeDlPath, Program.lang.lbSettingsGeneralYoutubeDlPathHint);
            chkSettingsGeneralUseStaticYoutubeDl.Text = Program.lang.chkSettingsGeneralUseStaticYoutubeDl;
            tipSettings.SetToolTip(chkSettingsGeneralUseStaticYoutubeDl, Program.lang.chkSettingsGeneralUseStaticYoutubeDlHint);
            tipSettings.SetToolTip(txtSettingsGeneralYoutubeDlPath, Program.lang.txtSettingsGeneralYoutubeDlPathHint);
            tipSettings.SetToolTip(btnSettingsGeneralBrowseYoutubeDl, Program.lang.btnSettingsGeneralBrowseYoutubeDlHint);
            lbSettingsGeneralFFmpegDirectory.Text = Program.lang.lbSettingsGeneralFFmpegDirectory;
            tipSettings.SetToolTip(lbSettingsGeneralFFmpegDirectory, Program.lang.lbSettingsGeneralFFmpegDirectoryHint);
            chkSettingsGeneralUseStaticFFmpeg.Text = Program.lang.chkSettingsGeneralUseStaticFFmpeg;
            tipSettings.SetToolTip(chkSettingsGeneralUseStaticFFmpeg, Program.lang.chkSettingsGeneralUseStaticFFmpegHint);
            tipSettings.SetToolTip(txtSettingsGeneralFFmpegPath, Program.lang.txtSettingsGeneralFFmpegPathHint);
            tipSettings.SetToolTip(btnSettingsGeneralBrowseFFmpeg, Program.lang.btnSettingsGeneralBrowseFFmpegHint);
            chkSettingsGeneralCheckForUpdatesOnLaunch.Text = Program.lang.chkSettingsGeneralCheckForUpdatesOnLaunch;
            tipSettings.SetToolTip(chkSettingsGeneralCheckForUpdatesOnLaunch, Program.lang.chkSettingsGeneralCheckForUpdatesOnLaunchHint);
            chkSettingsGeneralCheckForBetaUpdates.Text = Program.lang.chkSettingsGeneralCheckForBetaUpdates;
            tipSettings.SetToolTip(chkSettingsGeneralCheckForBetaUpdates, Program.lang.chkSettingsGeneralCheckForBetaUpdatesHint);
            chkSettingsGeneralHoverOverUrlToPasteClipboard.Text = Program.lang.chkSettingsGeneralHoverOverUrlToPasteClipboard;
            tipSettings.SetToolTip(chkSettingsGeneralHoverOverUrlToPasteClipboard, Program.lang.chkSettingsGeneralHoverOverUrlToPasteClipboardHint);
            chkSettingsGeneralClearUrlOnDownload.Text = Program.lang.chkSettingsGeneralClearUrlOnDownload;
            tipSettings.SetToolTip(chkSettingsGeneralClearUrlOnDownload, Program.lang.chkSettingsGeneralClearUrlOnDownloadHint);
            chkSettingsGeneralClearClipboardOnDownload.Text = Program.lang.chkSettingsGeneralClearClipboardOnDownload;
            tipSettings.SetToolTip(chkSettingsGeneralClearClipboardOnDownload, Program.lang.chkSettingsGeneralClearClipboardOnDownloadHint);
            gbSettingsGeneralCustomArguments.Text = Program.lang.gbSettingsGeneralCustomArguments;
            tipSettings.SetToolTip(gbSettingsGeneralCustomArguments, Program.lang.gbSettingsGeneralCustomArgumentsHint);
            rbSettingsGeneralCustomArgumentsDontSave.Text = Program.lang.rbSettingsGeneralCustomArgumentsDontSave;
            tipSettings.SetToolTip(rbSettingsGeneralCustomArgumentsDontSave, Program.lang.rbSettingsGeneralCustomArgumentsDontSaveHint);
            rbSettingsGeneralCustomArgumentsSaveAsArgsText.Text = Program.lang.rbSettingsGeneralCustomArgumentsSaveAsArgsText;
            tipSettings.SetToolTip(rbSettingsGeneralCustomArgumentsSaveAsArgsText, Program.lang.rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint);
            rbSettingsGeneralCustomArgumentsSaveInSettings.Text = Program.lang.rbSettingsGeneralCustomArgumentsSaveInSettings;
            tipSettings.SetToolTip(rbSettingsGeneralCustomArgumentsSaveInSettings, Program.lang.rbSettingsGeneralCustomArgumentsSaveInSettingsHint);

            lbSettingsDownloadsDownloadPath.Text = Program.lang.lbSettingsDownloadsDownloadPath;
            tipSettings.SetToolTip(lbSettingsDownloadsDownloadPath, Program.lang.lbSettingsDownloadsDownloadPathHint);
            tipSettings.SetToolTip(chkSettingsDownloadsDownloadPathUseRelativePath, Program.lang.chkSettingsDownloadsDownloadPathUseRelativePathHint);
            tipSettings.SetToolTip(txtSettingsDownloadsSavePath, Program.lang.txtSettingsDownloadsSavePathHint);
            tipSettings.SetToolTip(btnSettingsDownloadsBrowseSavePath, Program.lang.btnSettingsDownloadsBrowseSavePathHint);
            tipSettings.SetToolTip(llSettingsDownloadsSchemaHelp, Program.lang.llSettingsDownloadsSchemaHelpHint);
            lbSettingsDownloadsFileNameSchema.Text = Program.lang.lbSettingsDownloadsFileNameSchema;
            tipSettings.SetToolTip(lbSettingsDownloadsFileNameSchema, Program.lang.lbSettingsDownloadsFileNameSchemaHint);
            tipSettings.SetToolTip(txtSettingsDownloadsFileNameSchema, Program.lang.txtSettingsDownloadsFileNameSchemaHint);

            tabDownloadsGeneral.Text = Program.lang.tabDownloadsGeneral;
            tabDownloadsSorting.Text = Program.lang.tabDownloadsSorting;
            tabDownloadsFixes.Text = Program.lang.tabDownloadsFixes;
            tabDownloadsConnection.Text = Program.lang.tabDownloadsConnection;
            tabDownloadsUpdating.Text = Program.lang.tabDownloadsUpdating;

            chkSettingsDownloadsSaveFormatQuality.Text = Program.lang.chkSettingsDownloadsSaveFormatQuality;
            tipSettings.SetToolTip(chkSettingsDownloadsSaveFormatQuality, Program.lang.chkSettingsDownloadsSaveFormatQualityHint);
            chkSettingsDownloadsDownloadSubtitles.Text = Program.lang.chkSettingsDownloadsDownloadSubtitles;
            tipSettings.SetToolTip(chkSettingsDownloadsDownloadSubtitles, Program.lang.chkSettingsDownloadsDownloadSubtitlesHint);
            chkSettingsDownloadsEmbedSubtitles.Text = Program.lang.chkSettingsDownloadsEmbedSubtitles;
            tipSettings.SetToolTip(chkSettingsDownloadsEmbedSubtitles, Program.lang.chkSettingsDownloadsEmbedSubtitlesHint);
            chkSettingsDownloadsSaveVideoInfo.Text = Program.lang.chkSettingsDownloadsSaveVideoInfo;
            tipSettings.SetToolTip(chkSettingsDownloadsSaveVideoInfo, Program.lang.chkSettingsDownloadsSaveVideoInfoHint);
            chkSettingsDownloadsWriteMetadataToFile.Text = Program.lang.chkSettingsDownloadsWriteMetadataToFile;
            tipSettings.SetToolTip(chkSettingsDownloadsWriteMetadataToFile, Program.lang.chkSettingsDownloadsWriteMetadataToFileHint);
            chkSettingsDownloadsSaveDescription.Text = Program.lang.chkSettingsDownloadsSaveDescription;
            tipSettings.SetToolTip(chkSettingsDownloadsSaveDescription, Program.lang.chkSettingsDownloadsSaveDescriptionHint);
            chkSettingsDownloadsKeepOriginalFiles.Text = Program.lang.chkSettingsDownloadsKeepOriginalFiles;
            tipSettings.SetToolTip(chkSettingsDownloadsKeepOriginalFiles, Program.lang.chkSettingsDownloadsKeepOriginalFilesHint);
            chkSettingsDownloadsSaveAnnotations.Text = Program.lang.chkSettingsDownloadsSaveAnnotations;
            tipSettings.SetToolTip(chkSettingsDownloadsSaveAnnotations, Program.lang.chkSettingsDownloadsSaveAnnotationsHint);
            chkSettingsDownloadsSaveThumbnails.Text = Program.lang.chkSettingsDownloadsSaveThumbnails;
            tipSettings.SetToolTip(chkSettingsDownloadsSaveThumbnails, Program.lang.chkSettingsDownloadsSaveThumbnailsHint);
            chkSettingsDownloadsEmbedThumbnails.Text = Program.lang.chkSettingsDownloadsEmbedThumbnails;
            tipSettings.SetToolTip(chkSettingsDownloadsEmbedThumbnails, Program.lang.chkSettingsDownloadsEmbedThumbnailsHint);
            chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Text = Program.lang.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing;
            tipSettings.SetToolTip(chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing, Program.lang.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint);
            chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Text = Program.lang.chkSettingsDownloadsSeparateDownloadsToDifferentFolders;
            tipSettings.SetToolTip(chkSettingsDownloadsSeparateDownloadsToDifferentFolders, Program.lang.chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint);
            chkSettingsDownloadsSeparateIntoWebsiteUrl.Text = Program.lang.chkSettingsDownloadsSeparateIntoWebsiteUrl;
            tipSettings.SetToolTip(chkSettingsDownloadsSeparateIntoWebsiteUrl, Program.lang.chkSettingsDownloadsSeparateIntoWebsiteUrlHint);
            chkSettingsDownloadsFixVReddIt.Text = Program.lang.chkSettingsDownloadsFixVReddIt;
            tipSettings.SetToolTip(chkSettingsDownloadsFixVReddIt, Program.lang.chkSettingsDownloadsFixVReddItHint);
            chkSettingsDownloadsPreferFFmpeg.Text = Program.lang.chkSettingsDownloadsPreferFFmpeg;
            tipSettings.SetToolTip(chkSettingsDownloadsPreferFFmpeg, Program.lang.chkSettingsDownloadsPreferFFmpegHint);

            chkSettingsDownloadsLimitDownload.Text = Program.lang.chkSettingsDownloadsLimitDownload;
            tipSettings.SetToolTip(chkSettingsDownloadsLimitDownload, Program.lang.chkSettingsDownloadsLimitDownloadHint);
            tipSettings.SetToolTip(numSettingsDownloadsLimitDownload, Program.lang.numSettingsDownloadsLimitDownloadHint);
            tipSettings.SetToolTip(cbSettingsDownloadsLimitDownload, Program.lang.cbSettingsDownloadsLimitDownloadHint);
            lbSettingsDownloadsRetryAttempts.Text = Program.lang.lbSettingsDownloadsRetryAttempts;
            tipSettings.SetToolTip(lbSettingsDownloadsRetryAttempts, Program.lang.lbSettingsDownloadsRetryAttemptsHint);
            tipSettings.SetToolTip(numSettingsDownloadsRetryAttempts, Program.lang.numSettingsDownloadsRetryAttemptsHint);
            chkSettingsDownloadsForceIpv4.Text = Program.lang.chkSettingsDownloadsForceIpv4;
            tipSettings.SetToolTip(chkSettingsDownloadsForceIpv4, Program.lang.chkSettingsDownloadsForceIpv4Hint);
            chkSettingsDownloadsForceIpv6.Text = Program.lang.chkSettingsDownloadsForceIpv6;
            tipSettings.SetToolTip(chkSettingsDownloadsForceIpv6, Program.lang.chkSettingsDownloadsForceIpv6Hint);
            chkSettingsDownloadsUseProxy.Text = Program.lang.chkSettingsDownloadsUseProxy;
            tipSettings.SetToolTip(chkSettingsDownloadsUseProxy, Program.lang.chkSettingsDownloadsUseProxyHint);
            tipSettings.SetToolTip(cbSettingsDownloadsProxyType, Program.lang.cbSettingsDownloadsProxyTypeHint);
            tipSettings.SetToolTip(txtSettingsDownloadsProxyIp, Program.lang.txtSettingsDownloadsProxyIpHint);
            tipSettings.SetToolTip(txtSettingsDownloadsProxyPort, Program.lang.txtSettingsDownloadsProxyPortHint);

            chksettingsDownloadsUseYoutubeDlsUpdater.Text = Program.lang.chkSettingsDownloadsUseYoutubeDlsUpdater;
            tipSettings.SetToolTip(chksettingsDownloadsUseYoutubeDlsUpdater, Program.lang.chksettingsDownloadsUseYoutubeDlsUpdaterHint);
            lbSettingsDownloadsUpdatingYtdlType.Text = Program.lang.lbSettingsDownloadsUpdatingYtdlType;
            tipSettings.SetToolTip(cbSettingsDownloadsUpdatingYtdlType, Program.lang.cbSettingsDownloadsUpdatingYtdlTypeHint);
            llbSettingsDownloadsYtdlTypeViewRepo.Text = Program.lang.llbSettingsDownloadsYtdlTypeViewRepo;
            tipSettings.SetToolTip(llbSettingsDownloadsYtdlTypeViewRepo, Program.lang.llbSettingsDownloadsYtdlTypeViewRepoHint);

            chkSettingsDownloadsSeparateBatchDownloads.Text = Program.lang.chkSettingsDownloadsSeparateBatchDownloads;
            tipSettings.SetToolTip(chkSettingsDownloadsSeparateBatchDownloads, Program.lang.chkSettingsDownloadsSeparateBatchDownloadsHint);
            chkSettingsDownloadsAddDateToBatchDownloadFolders.Text = Program.lang.chkSettingsDownloadsAddDateToBatchDownloadFolders;
            tipSettings.SetToolTip(chkSettingsDownloadsAddDateToBatchDownloadFolders, Program.lang.chkSettingsDownloadsAddDateToBatchDownloadFoldersHint);

            chkSettingsConverterClearOutputAfterConverting.Text = Program.lang.chkSettingsConverterClearOutputAfterConverting;
            tipSettings.SetToolTip(chkSettingsConverterClearOutputAfterConverting, Program.lang.chkSettingsConverterClearOutputAfterConvertingHint);
            chkSettingsConverterDetectOutputFileType.Text = Program.lang.chkSettingsConverterDetectOutputFileType;
            tipSettings.SetToolTip(chkSettingsConverterDetectOutputFileType, Program.lang.chkSettingsConverterDetectOutputFileTypeHint);
            chkSettingsConverterClearInputAfterConverting.Text = Program.lang.chkSettingsConverterClearInputAfterConverting;
            tipSettings.SetToolTip(chkSettingsConverterClearInputAfterConverting, Program.lang.chkSettingsConverterClearInputAfterConvertingHint);
            chkSettingsConverterHideFFmpegCompileInfo.Text = Program.lang.chkSettingsConverterHideFFmpegCompileInfo;
            tipSettings.SetToolTip(chkSettingsConverterHideFFmpegCompileInfo, Program.lang.chkSettingsConverterHideFFmpegCompileInfoHint);

            tcSettingsConverterVideo.Text = Program.lang.tcSettingsConverterVideo;
            tcSettingsConverterAudio.Text = Program.lang.tcSettingsConverterAudio;
            tcSettingsConverterCustom.Text = Program.lang.tcSettingsConverterCustom;

            lbSettingsConverterVideoBitrate.Text = Program.lang.lbSettingsConverterVideoBitrate;
            tipSettings.SetToolTip(lbSettingsConverterVideoBitrate, Program.lang.lbSettingsConverterVideoBitrateHint);
            lbSettingsConverterVideoPreset.Text = Program.lang.lbSettingsConverterVideoPreset;
            tipSettings.SetToolTip(lbSettingsConverterVideoPreset, Program.lang.lbSettingsConverterVideoPresetHint);
            lbSettingsConverterVideoProfile.Text = Program.lang.lbSettingsConverterVideoProfile;
            tipSettings.SetToolTip(lbSettingsConverterVideoProfile, Program.lang.lbSettingsConverterVideoProfileHint);
            lbSettingsConverterVideoCRF.Text = Program.lang.lbSettingsConverterVideoCRF;
            tipSettings.SetToolTip(lbSettingsConverterVideoCRF, Program.lang.lbSettingsConverterVideoCRFHint);
            chkSettingsConverterVideoFastStart.Text = Program.lang.chkSettingsConverterVideoFastStart;
            tipSettings.SetToolTip(chkSettingsConverterVideoFastStart, Program.lang.chkSettingsConverterVideoFastStartHint);
            lbSettingsConverterAudioBitrate.Text = Program.lang.lbSettingsConverterAudioBitrate;
            tipSettings.SetToolTip(lbSettingsConverterAudioBitrate, Program.lang.lbSettingsConverterAudioBitrateHint);
            lbSettingsConverterCustomHeader.Text = Program.lang.lbSettingsConverterCustomHeader;
            tipSettings.SetToolTip(txtSettingsConverterCustomArguments, Program.lang.txtSettingsConverterCustomArgumentsHint);

            lbSettingsExtensionsHeader.Text = Program.lang.lbSettingsExtensionsHeader;
            //tipSettings.SetToolTip(lbSettingsExtensionsHeader, Program.lang.lbSettingsExtensionsHeaderHint);
            lbSettingsExtensionsExtensionFullName.Text = Program.lang.lbSettingsExtensionsExtensionFullName;
            txtSettingsExtensionsExtensionFullName.TextHint = Program.lang.txtSettingsExtensionsExtensionFullName;
            //tipSettings.SetToolTip(lbSettingsExtensionsExtensionFullName, Program.lang.lbSettingsExtensionsExtensionFullNameHint);
            lbSettingsExtensionsExtensionShort.Text = Program.lang.lbSettingsExtensionsExtensionShort;
            txtSettingsExtensionsExtensionShort.TextHint = Program.lang.txtSettingsExtensionsExtensionShort;
            //tipSettings.SetToolTip(lbSettingsExtensionsExtensionShort, Program.lang.lbSettingsExtensionsExtensionShortHint);
            btnSettingsExtensionsAdd.Text = Program.lang.btnSettingsExtensionsAdd;
            //tipSettings.SetToolTip(btnSettingsExtensionsAdd, Program.lang.btnSettingsExtensionsAddHint);
            lbSettingsExtensionsFileName.Text = Program.lang.lbSettingsExtensionsFileName + ".ext";
            //tipSettings.SetToolTip(lbSettingsExtensionsFileName, Program.lang.lbSettingsExtensionsFileNameHint);
            btnSettingsExtensionsRemoveSelected.Text = Program.lang.btnSettingsExtensionsRemoveSelected;
            //tipSettings.SetToolTip(btnSettingsExtensionsRemoveSelected, Program.lang.btnSettingsExtensionsRemoveSelectedHint);

            chkSettingsErrorsShowDetailedErrors.Text = Program.lang.chkSettingsErrorsShowDetailedErrors;
            tipSettings.SetToolTip(chkSettingsErrorsShowDetailedErrors, Program.lang.chkSettingsErrorsShowDetailedErrorsHint);
            chkSettingsErrorsSaveErrorsAsErrorLog.Text = Program.lang.chkSettingsErrorsSaveErrorsAsErrorLog;
            tipSettings.SetToolTip(chkSettingsErrorsSaveErrorsAsErrorLog, Program.lang.chkSettingsErrorsSaveErrorsAsErrorLogHint);
            chkSettingsErrorsSuppressErrors.Text = Program.lang.chkSettingsErrorsSuppressErrors;
            tipSettings.SetToolTip(chkSettingsErrorsSuppressErrors, Program.lang.chkSettingsErrorsSuppressErrorsHint);

            lbSettingsPortableInformation.Text = Program.lang.lbSettingsPortableInformation;
            chkSettingsPortableToggleIni.Text = Program.lang.chkSettingsPortableToggleIni;

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
            if (Config.Settings.General.UseStaticYtdl && !string.IsNullOrEmpty(Config.Settings.General.ytdlPath)) {
                txtSettingsGeneralYoutubeDlPath.Text = Config.Settings.General.ytdlPath;
                chkSettingsGeneralUseStaticYoutubeDl.Checked = Config.Settings.General.UseStaticYtdl;
            }
            else {
                if (Program.verif.YoutubeDlPath != null) {
                    txtSettingsGeneralYoutubeDlPath.Text = Program.verif.YoutubeDlPath;
                }
            }

            if (Config.Settings.General.UseStaticFFmpeg && !string.IsNullOrEmpty(Config.Settings.General.ffmpegPath)) {
                txtSettingsGeneralFFmpegPath.Text = Config.Settings.General.ffmpegPath;
                chkSettingsGeneralUseStaticFFmpeg.Checked = Config.Settings.General.UseStaticFFmpeg;
            }
            else {
                if (Program.verif.FFmpegPath != null) {
                    txtSettingsGeneralFFmpegPath.Text = Program.verif.FFmpegPath;
                }
            }

            chkSettingsGeneralCheckForUpdatesOnLaunch.Checked = Config.Settings.General.CheckForUpdatesOnLaunch;
            chkSettingsGeneralCheckForBetaUpdates.Checked = Config.Settings.General.DownloadBetaVersions;
            chkSettingsGeneralHoverOverUrlToPasteClipboard.Checked = Config.Settings.General.HoverOverURLTextBoxToPaste;
            chkSettingsGeneralClearUrlOnDownload.Checked = Config.Settings.General.ClearURLOnDownload;
            chkSettingsGeneralClearClipboardOnDownload.Checked = Config.Settings.General.ClearClipboardOnDownload;
            switch (Config.Settings.General.SaveCustomArgs) {
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


            if (string.IsNullOrWhiteSpace(Config.Settings.Downloads.downloadPath)) {
                txtSettingsDownloadsSavePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            }
            else {
                if (Config.Settings.Downloads.downloadPath.StartsWith(".\\") || Config.Settings.Downloads.downloadPath.StartsWith("./")) {
                    chkSettingsDownloadsDownloadPathUseRelativePath.Checked = true;
                }
                txtSettingsDownloadsSavePath.Text = Config.Settings.Downloads.downloadPath;
            }
            txtSettingsDownloadsFileNameSchema.Text = Config.Settings.Downloads.fileNameSchema;
            if (!string.IsNullOrEmpty(Config.Settings.Saved.FileNameSchemaHistory)) {
                txtSettingsDownloadsFileNameSchema.Items.AddRange(Config.Settings.Saved.FileNameSchemaHistory.Split('|'));
            }

            chkSettingsDownloadsSaveFormatQuality.Checked = Config.Settings.Downloads.SaveFormatQuality;
            if (Config.Settings.Downloads.SaveSubtitles) {
                chkSettingsDownloadsDownloadSubtitles.Checked = true;
                chkSettingsDownloadsEmbedSubtitles.Enabled = true;
            }
            else {
                chkSettingsDownloadsDownloadSubtitles.Checked = false;
                chkSettingsDownloadsEmbedSubtitles.Enabled = false;
            }
            chkSettingsDownloadsEmbedSubtitles.Checked = Config.Settings.Downloads.EmbedSubtitles;
            chkSettingsDownloadsSaveVideoInfo.Checked = Config.Settings.Downloads.SaveVideoInfo;
            chkSettingsDownloadsWriteMetadataToFile.Checked = Config.Settings.Downloads.WriteMetadata;
            chkSettingsDownloadsSaveDescription.Checked = Config.Settings.Downloads.SaveDescription;
            chkSettingsDownloadsKeepOriginalFiles.Checked = Config.Settings.Downloads.KeepOriginalFiles;
            chkSettingsDownloadsSaveAnnotations.Checked = Config.Settings.Downloads.SaveAnnotations;
            if (Config.Settings.Downloads.SaveThumbnail) {
                chkSettingsDownloadsSaveThumbnails.Checked = true;
                chkSettingsDownloadsEmbedThumbnails.Enabled = true;
            }
            else {
                chkSettingsDownloadsSaveThumbnails.Checked = false;
                chkSettingsDownloadsEmbedThumbnails.Enabled = false;
            }
            chkSettingsDownloadsEmbedThumbnails.Checked = Config.Settings.Downloads.EmbedThumbnails;
            chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Checked = Config.Settings.Downloads.deleteYtdlOnClose;
            chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Checked = Config.Settings.Downloads.separateDownloads;
            chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked = Config.Settings.Downloads.separateIntoWebsiteURL;
            chkSettingsDownloadsFixVReddIt.Checked = Config.Settings.Downloads.fixReddit;
            chkSettingsDownloadsPreferFFmpeg.Checked = Config.Settings.Downloads.PreferFFmpeg;
            chkSettingsDownloadsLimitDownload.Checked = Config.Settings.Downloads.LimitDownloads;
            numSettingsDownloadsLimitDownload.Value = Config.Settings.Downloads.DownloadLimit;
            cbSettingsDownloadsLimitDownload.SelectedIndex = Config.Settings.Downloads.DownloadLimitType;
            numSettingsDownloadsRetryAttempts.Value = Config.Settings.Downloads.RetryAttempts;
            chkSettingsDownloadsForceIpv4.Checked = Config.Settings.Downloads.ForceIPv4;
            chkSettingsDownloadsForceIpv6.Checked = Config.Settings.Downloads.ForceIPv6;
            chkSettingsDownloadsUseProxy.Checked = Config.Settings.Downloads.UseProxy;
            cbSettingsDownloadsProxyType.SelectedIndex = Config.Settings.Downloads.ProxyType;
            txtSettingsDownloadsProxyIp.Text = Config.Settings.Downloads.ProxyIP;
            txtSettingsDownloadsProxyPort.Text = Config.Settings.Downloads.ProxyPort;
            chksettingsDownloadsUseYoutubeDlsUpdater.Checked = Config.Settings.Downloads.useYtdlUpdater;
            cbSettingsDownloadsUpdatingYtdlType.SelectedIndex = Config.Settings.Downloads.YtdlType;
            useYtdlUpdater_Last = Config.Settings.Downloads.useYtdlUpdater;
            YtdlType_Last = Config.Settings.Downloads.YtdlType;

            chkSettingsConverterDetectOutputFileType.Checked = Config.Settings.Converts.detectFiletype;
            chkSettingsConverterClearOutputAfterConverting.Checked = Config.Settings.Converts.clearOutput;
            chkSettingsConverterClearInputAfterConverting.Checked = Config.Settings.Converts.clearInput;
            chkSettingsConverterHideFFmpegCompileInfo.Checked = Config.Settings.Converts.hideFFmpegCompile;

            chkUseVideoBitrate.Checked = Config.Settings.Converts.videoUseBitrate;
            numConvertVideoBitrate.Value = Config.Settings.Converts.videoBitrate;
            chkSettingsConverterVideoPreset.Checked = Config.Settings.Converts.videoUsePreset;
            cbConvertVideoPreset.SelectedIndex = Config.Settings.Converts.videoPreset;
            chkUseVideoProfile.Checked = Config.Settings.Converts.videoUseProfile;
            cbConvertVideoProfile.SelectedIndex = Config.Settings.Converts.videoProfile;
            chkUseVideoCRF.Checked = Config.Settings.Converts.videoUseCRF;
            numConvertVideoCRF.Value = Config.Settings.Converts.videoCRF;

            chkSettingsConverterVideoFastStart.Checked = Config.Settings.Converts.videoFastStart;

            chkUseAudioBitrate.Checked = Config.Settings.Converts.audioUseBitrate;
            numConvertAudioBitrate.Value = Config.Settings.Converts.audioBitrate;

            txtSettingsConverterCustomArguments.Text = Config.Settings.Saved.convertCustom;

            loadExtensions();

            chkSettingsErrorsShowDetailedErrors.Checked = Config.Settings.Errors.detailedErrors;
            chkSettingsErrorsSaveErrorsAsErrorLog.Checked = Config.Settings.Errors.logErrors;
            chkSettingsErrorsSuppressErrors.Checked = Config.Settings.Errors.suppressErrors;
        }
        private void saveSettings() {
            if (Config.Settings.General.UseStaticYtdl != chkSettingsGeneralUseStaticYoutubeDl.Checked) {
                Config.Settings.General.UseStaticYtdl = chkSettingsGeneralUseStaticYoutubeDl.Checked;
                RefreshYtdl = true;
            }
            if (chkSettingsGeneralUseStaticYoutubeDl.Checked && !string.IsNullOrEmpty(txtSettingsGeneralYoutubeDlPath.Text)) {
                if (Config.Settings.General.ytdlPath != txtSettingsGeneralYoutubeDlPath.Text) {
                    RefreshYtdl = true;
                }
                Config.Settings.General.ytdlPath = txtSettingsGeneralYoutubeDlPath.Text;
            }

            if (Config.Settings.General.UseStaticFFmpeg != chkSettingsGeneralUseStaticFFmpeg.Checked) {
                Config.Settings.General.UseStaticFFmpeg = chkSettingsGeneralUseStaticFFmpeg.Checked;
                RefreshFFmpeg = true;
            }
            if (chkSettingsGeneralUseStaticFFmpeg.Checked && !string.IsNullOrEmpty(txtSettingsGeneralFFmpegPath.Text)) {
                if (Config.Settings.General.ffmpegPath != txtSettingsGeneralFFmpegPath.Text) {
                    RefreshFFmpeg = true;
                }
                Config.Settings.General.ffmpegPath = txtSettingsGeneralFFmpegPath.Text;
            }

            Config.Settings.General.CheckForUpdatesOnLaunch = chkSettingsGeneralCheckForUpdatesOnLaunch.Checked;
            Config.Settings.General.DownloadBetaVersions = chkSettingsGeneralCheckForBetaUpdates.Checked;
            Config.Settings.General.HoverOverURLTextBoxToPaste = chkSettingsGeneralHoverOverUrlToPasteClipboard.Checked;
            Config.Settings.General.ClearURLOnDownload = chkSettingsGeneralClearUrlOnDownload.Checked;
            Config.Settings.General.ClearClipboardOnDownload = chkSettingsGeneralClearClipboardOnDownload.Checked;

            if (rbSettingsGeneralCustomArgumentsDontSave.Checked) {
                Config.Settings.General.SaveCustomArgs = 0;
            }
            else if (rbSettingsGeneralCustomArgumentsSaveAsArgsText.Checked) {
                Config.Settings.General.SaveCustomArgs = 1;
            }
            else if (rbSettingsGeneralCustomArgumentsSaveInSettings.Checked) {
                Config.Settings.General.SaveCustomArgs = 2;
            }
            else {
                Config.Settings.General.SaveCustomArgs = 0;
            }

            Config.Settings.Downloads.downloadPath = txtSettingsDownloadsSavePath.Text;
            Config.Settings.Downloads.fileNameSchema = txtSettingsDownloadsFileNameSchema.Text;
            if (!txtSettingsDownloadsFileNameSchema.Items.Contains(txtSettingsDownloadsFileNameSchema.Text)) {
                txtSettingsDownloadsFileNameSchema.Items.Add(txtSettingsDownloadsFileNameSchema.Text);
            }
            string FileNameSchemaHistory = GetHistoryFromComboBox(txtSettingsDownloadsFileNameSchema);
            if (Config.Settings.Saved.FileNameSchemaHistory != FileNameSchemaHistory) {
                Config.Settings.Saved.FileNameSchemaHistory = FileNameSchemaHistory;
            }

            Config.Settings.Downloads.SaveFormatQuality = chkSettingsDownloadsSaveFormatQuality.Checked;
            Config.Settings.Downloads.SaveSubtitles = chkSettingsDownloadsDownloadSubtitles.Checked;
            Config.Settings.Downloads.EmbedSubtitles = chkSettingsDownloadsEmbedSubtitles.Checked;
            Config.Settings.Downloads.SaveVideoInfo = chkSettingsDownloadsSaveVideoInfo.Checked;
            Config.Settings.Downloads.WriteMetadata = chkSettingsDownloadsWriteMetadataToFile.Checked;
            Config.Settings.Downloads.SaveDescription = chkSettingsDownloadsSaveDescription.Checked;
            Config.Settings.Downloads.KeepOriginalFiles = chkSettingsDownloadsKeepOriginalFiles.Checked;
            Config.Settings.Downloads.SaveAnnotations = chkSettingsDownloadsSaveAnnotations.Checked;
            Config.Settings.Downloads.SaveThumbnail = chkSettingsDownloadsSaveThumbnails.Checked;
            Config.Settings.Downloads.EmbedThumbnails = chkSettingsDownloadsEmbedThumbnails.Checked;
            Config.Settings.Downloads.deleteYtdlOnClose = chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Checked;
            Config.Settings.Downloads.separateDownloads = chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Checked;
            Config.Settings.Downloads.separateIntoWebsiteURL = chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked;
            Config.Settings.Downloads.fixReddit = chkSettingsDownloadsFixVReddIt.Checked;
            Config.Settings.Downloads.PreferFFmpeg = chkSettingsDownloadsPreferFFmpeg.Checked;
            Config.Settings.Downloads.LimitDownloads = chkSettingsDownloadsLimitDownload.Checked;
            Config.Settings.Downloads.DownloadLimit = (int)numSettingsDownloadsLimitDownload.Value;
            Config.Settings.Downloads.DownloadLimitType = cbSettingsDownloadsLimitDownload.SelectedIndex;
            Config.Settings.Downloads.ForceIPv4 = chkSettingsDownloadsForceIpv4.Checked;
            Config.Settings.Downloads.ForceIPv6 = chkSettingsDownloadsForceIpv6.Checked;
            Config.Settings.Downloads.UseProxy = chkSettingsDownloadsUseProxy.Checked;
            Config.Settings.Downloads.ProxyType = cbSettingsDownloadsProxyType.SelectedIndex;
            Config.Settings.Downloads.ProxyIP = txtSettingsDownloadsProxyIp.Text;
            Config.Settings.Downloads.ProxyPort = txtSettingsDownloadsProxyPort.Text;
            Config.Settings.Downloads.useYtdlUpdater = chksettingsDownloadsUseYoutubeDlsUpdater.Checked;
            if (cbSettingsDownloadsUpdatingYtdlType.SelectedIndex != YtdlType_Last) {
                RefreshYtdl = true;
            }
            Config.Settings.Downloads.YtdlType = cbSettingsDownloadsUpdatingYtdlType.SelectedIndex;

            Config.Settings.Converts.detectFiletype = chkSettingsConverterDetectOutputFileType.Checked;
            Config.Settings.Converts.clearOutput = chkSettingsConverterClearOutputAfterConverting.Checked;
            Config.Settings.Converts.clearInput = chkSettingsConverterClearInputAfterConverting.Checked;
            Config.Settings.Converts.hideFFmpegCompile = chkSettingsConverterHideFFmpegCompileInfo.Checked;

            Config.Settings.Converts.videoUseBitrate = chkUseVideoBitrate.Checked;
            Config.Settings.Converts.videoBitrate = Decimal.ToInt32(numConvertVideoBitrate.Value);
            Config.Settings.Converts.videoUsePreset = chkSettingsConverterVideoPreset.Checked;
            Config.Settings.Converts.videoPreset = cbConvertVideoPreset.SelectedIndex;
            Config.Settings.Converts.videoUseProfile = chkUseVideoProfile.Checked;
            Config.Settings.Converts.videoProfile = cbConvertVideoProfile.SelectedIndex;
            Config.Settings.Converts.videoUseCRF = chkUseVideoCRF.Checked;
            Config.Settings.Converts.videoCRF = Decimal.ToInt32(numConvertVideoCRF.Value);
            Config.Settings.Converts.videoFastStart = chkSettingsConverterVideoFastStart.Checked;

            Config.Settings.Converts.audioUseBitrate = chkUseAudioBitrate.Checked;
            Config.Settings.Converts.audioBitrate = Decimal.ToInt32(numConvertAudioBitrate.Value);

            Config.Settings.Saved.convertCustom = txtSettingsConverterCustomArguments.Text;
            Config.Settings.Saved.SettingsFormSize = this.Size;

            saveExtensions();

            Config.Settings.Errors.detailedErrors = chkSettingsErrorsShowDetailedErrors.Checked;
            Config.Settings.Errors.logErrors = chkSettingsErrorsSaveErrorsAsErrorLog.Checked;
            Config.Settings.Errors.suppressErrors = chkSettingsErrorsSuppressErrors.Checked;

            Config.Settings.General.Save();
            Config.Settings.Downloads.Save();
            Config.Settings.Converts.Save();
            Config.Settings.Errors.Save();
            Config.Settings.Saved.Save();

            if (RefreshYtdl) {
                Program.verif.RefreshYoutubeDlLocation();
            }
            if (RefreshFFmpeg) {
                Program.verif.RefreshFFmpegLocation();
            }
        }

        private void btnSettingsRedownloadYoutubeDl_Click(object sender, EventArgs e) {
            UpdateChecker.UpdateYoutubeDl();
        }

        private void btnSettingsSave_Click(object sender, EventArgs e) {
            saveSettings();
            this.Dispose();
        }
        private void btnSettingsCancel_Click(object sender, EventArgs e) {
            Config.Settings.Downloads.useYtdlUpdater = useYtdlUpdater_Last;
            Config.Settings.Downloads.YtdlType = YtdlType_Last;
            this.Dispose();
        }

        #region General
        private void chkSettingsGeneralUseStaticYoutubeDl_CheckedChanged(object sender, EventArgs e) {
            Config.Settings.General.UseStaticYtdl = chkSettingsGeneralUseStaticYoutubeDl.Checked;
        }
        private void chkSettingsGeneralUseStaticFFmpeg_CheckedChanged(object sender, EventArgs e) {
            Config.Settings.General.UseStaticFFmpeg = chkSettingsGeneralUseStaticFFmpeg.Checked;
        }
        private void btnSettingsGeneralBrowseYoutubeDl_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = Program.lang.ofdTitleYoutubeDl;
                ofd.Filter = Program.lang.ofdFilterYoutubeDl + " (*.EXE)|*.exe";
                ofd.FileName = "youtube-dl.exe";

                if (ofd.ShowDialog() == DialogResult.OK) {
                    txtSettingsGeneralYoutubeDlPath.Text = ofd.FileName;
                }
            }
        }
        private void btnSettingsGeneralBrowseFFmpeg_Click(object sender, EventArgs e) {
            using (OpenFileDialog ofd = new OpenFileDialog()) {
                ofd.Title = Program.lang.ofdTitleFFmpeg;
                ofd.Filter = Program.lang.ofdFilterFFmpeg + " (*.EXE)|*.exe";
                ofd.FileName = "ffmpeg.exe";


                if (ofd.ShowDialog() == DialogResult.OK) {
                    txtSettingsGeneralFFmpegPath.Text = ofd.FileName;
                }
            }
        }
        private void chkSettingsGeneralCheckForUpdatesOnLaunch_CheckedChanged(object sender, EventArgs e) {
            chkSettingsGeneralCheckForBetaUpdates.Enabled = chkSettingsGeneralCheckForUpdatesOnLaunch.Checked;
        }
        #endregion

        #region Downloads
        private void chkSettingsDownloadsDownloadPathUseRelativePath_CheckedChanged(object sender, EventArgs e) {
            if (!LoadingForm) {
                if (chkSettingsDownloadsDownloadPathUseRelativePath.Checked && txtSettingsDownloadsSavePath.Text.StartsWith(Program.ProgramPath)) {
                    txtSettingsDownloadsSavePath.Text = ".\\" + txtSettingsDownloadsSavePath.Text.Substring(Program.ProgramPath.Length + 1);
                }
                else if (txtSettingsDownloadsSavePath.Text.StartsWith("./") || txtSettingsDownloadsSavePath.Text.StartsWith(".\\")) {
                    txtSettingsDownloadsSavePath.Text = Program.ProgramPath + "\\" + txtSettingsDownloadsSavePath.Text.Substring(2);
                }
            }
        }
        private void btnSettingsDownloadsBrowseSavePath_Click(object sender, EventArgs e) {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
                fbd.Description = "Select a destionation where downloads will be saved to";
                if (chkSettingsDownloadsDownloadPathUseRelativePath.Checked) {
                    fbd.SelectedPath = Program.ProgramPath;
                }
                else {
                    fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                }

                if (fbd.ShowDialog() == DialogResult.OK) {
                    if (chkSettingsDownloadsDownloadPathUseRelativePath.Checked && fbd.SelectedPath.StartsWith(Program.ProgramPath)) {
                        txtSettingsDownloadsSavePath.Text = ".\\" + fbd.SelectedPath.Substring(Program.ProgramPath.Length + 1);
                    }
                    else {
                        txtSettingsDownloadsSavePath.Text = fbd.SelectedPath;
                    }
                }
            }
        }
        private void llSettingsDownloadsSchemaHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Process.Start("https://github.com/ytdl-org/youtube-dl/blob/master/README.md#output-template");
        }
        private void txtSettingsDownloadsFileNameSchema_KeyPress(object sender, KeyPressEventArgs e) {
            switch (e.KeyChar) {
                case '\\': case '/': case ':': case '*':
                case '?': case '"': case '<': case '>':
                case '|':
                    e.Handled = true;
                    break;
            }
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

        private void chksettingsDownloadsUseYoutubeDlsUpdater_CheckedChanged(object sender, EventArgs e) {
            Config.Settings.Downloads.useYtdlUpdater = chksettingsDownloadsUseYoutubeDlsUpdater.Checked;
        }
        private void cbSettingsDownloadsUpdatingYtdlType_SelectedIndexChanged(object sender, EventArgs e) {
            Config.Settings.Downloads.YtdlType = cbSettingsDownloadsUpdatingYtdlType.SelectedIndex;
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

        private void llbSettingsDownloadsYtdlTypeViewRepo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (cbSettingsDownloadsUpdatingYtdlType.SelectedIndex > -1 && cbSettingsDownloadsUpdatingYtdlType.SelectedIndex < 3) {
                Process.Start(
                    string.Format(
                        GitData.GitLinks.GithubRepoUrl,
                        GitData.GitLinks.Users[cbSettingsDownloadsUpdatingYtdlType.SelectedIndex],
                        GitData.GitLinks.Repos[cbSettingsDownloadsUpdatingYtdlType.SelectedIndex]
                    )
                );
            }
        }
        #endregion

        #region Extensions
        private void loadExtensions() {
            if (!string.IsNullOrEmpty(Config.Settings.General.extensionsName)) {
                extensionsShort.AddRange(Config.Settings.General.extensionsShort.Split('|').ToList());
                extensionsName.AddRange(Config.Settings.General.extensionsName.Split('|').ToList());
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

                Config.Settings.General.extensionsName = ext;
                Config.Settings.General.extensionsShort = shrt;
            }
            else {
                Config.Settings.General.extensionsName = string.Empty;
                Config.Settings.General.extensionsShort = string.Empty;
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

        #region Portable
        private void chkSettingsPortableToggleIni_CheckedChanged(object sender, EventArgs e) {
            if (!LoadingForm) {
                Config.Settings.ConvertConfig(chkSettingsPortableToggleIni.Checked);
            }
        }

        private void btnCleanIni_Click(object sender, EventArgs e) {
            Config.Settings.CleanIniFile();
        }
        #endregion

    }
}