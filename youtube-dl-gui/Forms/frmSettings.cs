namespace youtube_dl_gui;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
public partial class frmSettings : Form {

    #region vars
    public bool ffmpegAvailabled = false;
    public bool ytdlAvailable = false;

    private bool LoadingForm = false;
    private bool ProtocolAvailable = false;

    readonly List<string> extensionsName = new();
    readonly List<string> extensionsShort = new();

    private bool RefreshYtdl = false;
    private bool RefreshFFmpeg = false;

    private bool useYtdlUpdater_Last;
    private int YtdlType_Last;

    private Thread YtdlUpdateCheck;
    #endregion

    public frmSettings() {
        InitializeComponent();

        for (int i = 0; i < GithubLinks.Repos.Length; i++)
            cbSettingsDownloadsUpdatingYtdlType.Items.Add($"{GithubLinks.Users[i]}/{GithubLinks.Repos[i]}{(i == 0 ? " (default)" : "")}");

        ProtocolAvailable = SystemRegistry.CheckRegistry();

        LoadingForm = true;
        LoadLanguage();
        CalculatePositions();
        LoadSettings();

    }
    private void frmSettings_Load(object sender, EventArgs e) {
        if (Config.Settings.Saved.SettingsFormSize.Valid) {
            this.StartPosition = FormStartPosition.Manual;
            this.Size = Config.Settings.Saved.SettingsFormSize;
        }
        LoadingForm = false;
    }
    private void frmSettings_FormClosing(object sender, FormClosingEventArgs e) {
        if (YtdlUpdateCheck != null && YtdlUpdateCheck.IsAlive) {
            YtdlUpdateCheck.Abort();
        }
    }

    private void LoadLanguage() {
        this.Text = Language.frmSettings;
        btnSettingsCancel.Text = Language.GenericCancel;
        tipSettings.SetToolTip(btnSettingsCancel, Language.btnSettingsCancelHint);
        btnSettingsSave.Text = Language.GenericSave;
        tipSettings.SetToolTip(btnSettingsSave, Language.btnSettingsSaveHint);

        tabSettingsGeneral.Text = Language.tabSettingsGeneral;
        tabSettingsDownloads.Text = Language.tabSettingsDownloads;
        tabSettingsConverter.Text = Language.tabSettingsConverter;
        tabSettingsExtensions.Text = Language.tabSettingsExtensions;
        tabSettingsErrors.Text = Language.tabSettingsErrors;

        tabSettingsGeneralYoutubeDl.Text = Language.tabSettingsGeneralYoutubeDl;
        tabSettingsGeneralFfmpeg.Text = Language.tabSettingsGeneralFfmpeg;
        lbSettingsGeneralYoutubeDlPath.Text = Language.lbSettingsGeneralYoutubeDlPath;
        tipSettings.SetToolTip(lbSettingsGeneralYoutubeDlPath, Language.lbSettingsGeneralYoutubeDlPathHint);
        chkSettingsGeneralUseStaticYoutubeDl.Text = Language.chkSettingsGeneralUseStaticYoutubeDl;
        tipSettings.SetToolTip(chkSettingsGeneralUseStaticYoutubeDl, Language.chkSettingsGeneralUseStaticYoutubeDlHint);
        tipSettings.SetToolTip(txtSettingsGeneralYoutubeDlPath, Language.txtSettingsGeneralYoutubeDlPathHint);
        tipSettings.SetToolTip(btnSettingsGeneralBrowseYoutubeDl, Language.btnSettingsGeneralBrowseYoutubeDlHint);
        lbSettingsGeneralFFmpegDirectory.Text = Language.lbSettingsGeneralFFmpegDirectory;
        tipSettings.SetToolTip(lbSettingsGeneralFFmpegDirectory, Language.lbSettingsGeneralFFmpegDirectoryHint);
        chkSettingsGeneralUseStaticFFmpeg.Text = Language.chkSettingsGeneralUseStaticFFmpeg;
        tipSettings.SetToolTip(chkSettingsGeneralUseStaticFFmpeg, Language.chkSettingsGeneralUseStaticFFmpegHint);
        tipSettings.SetToolTip(txtSettingsGeneralFFmpegPath, Language.txtSettingsGeneralFFmpegPathHint);
        tipSettings.SetToolTip(btnSettingsGeneralBrowseFFmpeg, Language.btnSettingsGeneralBrowseFFmpegHint);
        btnSettingsRedownloadYoutubeDl.Text = Language.btnSettingsRedownloadYoutubeDl;
        tipSettings.SetToolTip(btnSettingsRedownloadYoutubeDl, Language.btnSettingsRedownloadYoutubeDlHint);
        btnSettingsRedownloadFfmpeg.Text = Language.btnSettingsRedownloadFfmpeg;
        tipSettings.SetToolTip(btnSettingsRedownloadFfmpeg, Language.btnSettingsRedownloadFfmpegHint);
        chkSettingsGeneralCheckForUpdatesOnLaunch.Text = Language.chkSettingsGeneralCheckForUpdatesOnLaunch;
        tipSettings.SetToolTip(chkSettingsGeneralCheckForUpdatesOnLaunch, Language.chkSettingsGeneralCheckForUpdatesOnLaunchHint);
        chkSettingsGeneralCheckForBetaUpdates.Text = Language.chkSettingsGeneralCheckForBetaUpdates;
        tipSettings.SetToolTip(chkSettingsGeneralCheckForBetaUpdates, Language.chkSettingsGeneralCheckForBetaUpdatesHint);
        chkSettingsGeneralDeleteUpdaterAfterUpdating.Text = Language.chkSettingsGeneralDeleteUpdaterAfterUpdating;
        tipSettings.SetToolTip(chkSettingsGeneralDeleteUpdaterAfterUpdating, Language.chkSettingsGeneralDeleteUpdaterAfterUpdatingHint);
        chkDeleteOldVersionAfterUpdating.Text = Language.chkDeleteOldVersionAfterUpdating;
        tipSettings.SetToolTip(chkDeleteOldVersionAfterUpdating, Language.chkDeleteOldVersionAfterUpdatingHint);
        chkSettingsGeneralHoverOverUrlToPasteClipboard.Text = Language.chkSettingsGeneralHoverOverUrlToPasteClipboard;
        tipSettings.SetToolTip(chkSettingsGeneralHoverOverUrlToPasteClipboard, Language.chkSettingsGeneralHoverOverUrlToPasteClipboardHint);
        chkSettingsGeneralClearUrlOnDownload.Text = Language.chkSettingsGeneralClearUrlOnDownload;
        tipSettings.SetToolTip(chkSettingsGeneralClearUrlOnDownload, Language.chkSettingsGeneralClearUrlOnDownloadHint);
        chkSettingsGeneralClearClipboardOnDownload.Text = Language.chkSettingsGeneralClearClipboardOnDownload;
        tipSettings.SetToolTip(chkSettingsGeneralClearClipboardOnDownload, Language.chkSettingsGeneralClearClipboardOnDownloadHint);
        chkSettingsGeneralAutoUpdateYoutubeDl.Text = Language.chkSettingsGeneralAutoUpdateYoutubeDl;
        tipSettings.SetToolTip(chkSettingsGeneralAutoUpdateYoutubeDl, Language.chkSettingsGeneralAutoUpdateYoutubeDlHint);
        gbSettingsGeneralCustomArguments.Text = Language.gbSettingsGeneralCustomArguments;
        tipSettings.SetToolTip(gbSettingsGeneralCustomArguments, Language.gbSettingsGeneralCustomArgumentsHint);
        rbSettingsGeneralCustomArgumentsDontSave.Text = Language.rbSettingsGeneralCustomArgumentsDontSave;
        tipSettings.SetToolTip(rbSettingsGeneralCustomArgumentsDontSave, Language.rbSettingsGeneralCustomArgumentsDontSaveHint);
        rbSettingsGeneralCustomArgumentsSaveAsArgsText.Text = Language.rbSettingsGeneralCustomArgumentsSaveAsArgsText;
        tipSettings.SetToolTip(rbSettingsGeneralCustomArgumentsSaveAsArgsText, Language.rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint);
        rbSettingsGeneralCustomArgumentsSaveInSettings.Text = Language.rbSettingsGeneralCustomArgumentsSaveInSettings;
        tipSettings.SetToolTip(rbSettingsGeneralCustomArgumentsSaveInSettings, Language.rbSettingsGeneralCustomArgumentsSaveInSettingsHint);

        lbSettingsDownloadsDownloadPath.Text = Language.lbSettingsDownloadsDownloadPath;
        tipSettings.SetToolTip(lbSettingsDownloadsDownloadPath, Language.lbSettingsDownloadsDownloadPathHint);
        tipSettings.SetToolTip(chkSettingsDownloadsDownloadPathUseRelativePath, Language.chkSettingsDownloadsDownloadPathUseRelativePathHint);
        tipSettings.SetToolTip(txtSettingsDownloadsSavePath, Language.txtSettingsDownloadsSavePathHint);
        tipSettings.SetToolTip(btnSettingsDownloadsBrowseSavePath, Language.btnSettingsDownloadsBrowseSavePathHint);
        tipSettings.SetToolTip(llSettingsDownloadsSchemaHelp, Language.llSettingsDownloadsSchemaHelpHint);
        lbSettingsDownloadsFileNameSchema.Text = Language.lbSettingsDownloadsFileNameSchema;
        tipSettings.SetToolTip(lbSettingsDownloadsFileNameSchema, Language.lbSettingsDownloadsFileNameSchemaHint);
        tipSettings.SetToolTip(txtSettingsDownloadsFileNameSchema, Language.txtSettingsDownloadsFileNameSchemaHint);

        if (ProtocolAvailable) {
            btnSettingsDownloadsInstallProtocol.Enabled = btnSettingsDownloadsInstallProtocol.ShowUacShield = false;
            btnSettingsDownloadsInstallProtocol.Text = Language.btnSettingsDownloadsInstallProtocolInstalled;
        }
        else {
            btnSettingsDownloadsInstallProtocol.Enabled = btnSettingsDownloadsInstallProtocol.ShowUacShield = true;
            btnSettingsDownloadsInstallProtocol.Text = " " + Language.btnSettingsDownloadsInstallProtocolNotInstalled;
            tipSettings.SetToolTip(btnSettingsDownloadsInstallProtocol, Language.btnSettingsDownloadsInstallProtocolHint);
        }
        llbSettingsDownloadsInstallProtocolMoreInfo.Text = Language.GenericMoreInfo;

        tabDownloadsGeneral.Text = Language.tabDownloadsGeneral;
        tabDownloadsSorting.Text = Language.tabDownloadsSorting;
        tabDownloadsFixes.Text = Language.tabDownloadsFixes;
        tabDownloadsConnection.Text = Language.tabDownloadsConnection;
        tabDownloadsUpdating.Text = Language.tabDownloadsUpdating;
        tabDownloadsBatch.Text = Language.tabDownloadsBatch;
        tabYtdlpExtendedOptions.Text = Language.tabExtendedOptions;

        chkSettingsDownloadsSaveFormatQuality.Text = Language.chkSettingsDownloadsSaveFormatQuality;
        tipSettings.SetToolTip(chkSettingsDownloadsSaveFormatQuality, Language.chkSettingsDownloadsSaveFormatQualityHint);
        chkSettingsDownloadsDownloadSubtitles.Text = Language.chkSettingsDownloadsDownloadSubtitles;
        tipSettings.SetToolTip(chkSettingsDownloadsDownloadSubtitles, Language.chkSettingsDownloadsDownloadSubtitlesHint);
        chkSettingsDownloadsEmbedSubtitles.Text = Language.chkSettingsDownloadsEmbedSubtitles;
        tipSettings.SetToolTip(chkSettingsDownloadsEmbedSubtitles, Language.chkSettingsDownloadsEmbedSubtitlesHint);
        chkSettingsDownloadsSaveVideoInfo.Text = Language.chkSettingsDownloadsSaveVideoInfo;
        tipSettings.SetToolTip(chkSettingsDownloadsSaveVideoInfo, Language.chkSettingsDownloadsSaveVideoInfoHint);
        chkSettingsDownloadsWriteMetadataToFile.Text = Language.chkSettingsDownloadsWriteMetadataToFile;
        tipSettings.SetToolTip(chkSettingsDownloadsWriteMetadataToFile, Language.chkSettingsDownloadsWriteMetadataToFileHint);
        chkSettingsDownloadsSaveDescription.Text = Language.chkSettingsDownloadsSaveDescription;
        tipSettings.SetToolTip(chkSettingsDownloadsSaveDescription, Language.chkSettingsDownloadsSaveDescriptionHint);
        chkSettingsDownloadsKeepOriginalFiles.Text = Language.chkSettingsDownloadsKeepOriginalFiles;
        tipSettings.SetToolTip(chkSettingsDownloadsKeepOriginalFiles, Language.chkSettingsDownloadsKeepOriginalFilesHint);
        chkSettingsDownloadsSaveAnnotations.Text = Language.chkSettingsDownloadsSaveAnnotations;
        tipSettings.SetToolTip(chkSettingsDownloadsSaveAnnotations, Language.chkSettingsDownloadsSaveAnnotationsHint);
        chkSettingsDownloadsSaveThumbnails.Text = Language.chkSettingsDownloadsSaveThumbnails;
        tipSettings.SetToolTip(chkSettingsDownloadsSaveThumbnails, Language.chkSettingsDownloadsSaveThumbnailsHint);
        chkSettingsDownloadsEmbedThumbnails.Text = Language.chkSettingsDownloadsEmbedThumbnails;
        tipSettings.SetToolTip(chkSettingsDownloadsEmbedThumbnails, Language.chkSettingsDownloadsEmbedThumbnailsHint);
        chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Text = Language.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing;
        tipSettings.SetToolTip(chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing, Language.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint);
        chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Text = Language.chkSettingsDownloadsSeparateDownloadsToDifferentFolders;
        tipSettings.SetToolTip(chkSettingsDownloadsSeparateDownloadsToDifferentFolders, Language.chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint);
        chkSettingsDownloadsSeparateIntoWebsiteUrl.Text = Language.chkSettingsDownloadsSeparateIntoWebsiteUrl;
        tipSettings.SetToolTip(chkSettingsDownloadsSeparateIntoWebsiteUrl, Language.chkSettingsDownloadsSeparateIntoWebsiteUrlHint);
        chkSettingsDownloadsWebsiteSubdomains.Text = Language.chkSettingsDownloadsWebsiteSubdomains;
        tipSettings.SetToolTip(chkSettingsDownloadsWebsiteSubdomains, Language.chkSettingsDownloadsWebsiteSubdomainsHint);
        chkSettingsDownloadsFixVReddIt.Text = Language.chkSettingsDownloadsFixVReddIt;
        tipSettings.SetToolTip(chkSettingsDownloadsFixVReddIt, Language.chkSettingsDownloadsFixVReddItHint);
        chkSettingsDownloadsPreferFFmpeg.Text = Language.chkSettingsDownloadsPreferFFmpeg;
        tipSettings.SetToolTip(chkSettingsDownloadsPreferFFmpeg, Language.chkSettingsDownloadsPreferFFmpegHint);

        chkSettingsDownloadsLimitDownload.Text = Language.chkSettingsDownloadsLimitDownload;
        tipSettings.SetToolTip(chkSettingsDownloadsLimitDownload, Language.chkSettingsDownloadsLimitDownloadHint);
        tipSettings.SetToolTip(numSettingsDownloadsLimitDownload, Language.numSettingsDownloadsLimitDownloadHint);
        tipSettings.SetToolTip(cbSettingsDownloadsLimitDownload, Language.cbSettingsDownloadsLimitDownloadHint);
        lbSettingsDownloadsRetryAttempts.Text = Language.lbSettingsDownloadsRetryAttempts;
        tipSettings.SetToolTip(lbSettingsDownloadsRetryAttempts, Language.lbSettingsDownloadsRetryAttemptsHint);
        tipSettings.SetToolTip(numSettingsDownloadsRetryAttempts, Language.numSettingsDownloadsRetryAttemptsHint);
        chkSettingsDownloadsForceIpv4.Text = Language.chkSettingsDownloadsForceIpv4;
        tipSettings.SetToolTip(chkSettingsDownloadsForceIpv4, Language.chkSettingsDownloadsForceIpv4Hint);
        chkSettingsDownloadsForceIpv6.Text = Language.chkSettingsDownloadsForceIpv6;
        tipSettings.SetToolTip(chkSettingsDownloadsForceIpv6, Language.chkSettingsDownloadsForceIpv6Hint);
        chkSettingsDownloadsUseProxy.Text = Language.chkSettingsDownloadsUseProxy;
        tipSettings.SetToolTip(chkSettingsDownloadsUseProxy, Language.chkSettingsDownloadsUseProxyHint);
        tipSettings.SetToolTip(cbSettingsDownloadsProxyType, Language.cbSettingsDownloadsProxyTypeHint);
        tipSettings.SetToolTip(txtSettingsDownloadsProxyIp, Language.txtSettingsDownloadsProxyIpHint);
        tipSettings.SetToolTip(txtSettingsDownloadsProxyPort, Language.txtSettingsDownloadsProxyPortHint);

        chksettingsDownloadsUseYoutubeDlsUpdater.Text = Language.chkSettingsDownloadsUseYoutubeDlsUpdater;
        tipSettings.SetToolTip(chksettingsDownloadsUseYoutubeDlsUpdater, Language.chksettingsDownloadsUseYoutubeDlsUpdaterHint);
        lbSettingsDownloadsUpdatingYtdlType.Text = Language.lbSettingsDownloadsUpdatingYtdlType;
        tipSettings.SetToolTip(cbSettingsDownloadsUpdatingYtdlType, Language.cbSettingsDownloadsUpdatingYtdlTypeHint);
        llbSettingsDownloadsYtdlTypeViewRepo.Text = Language.llbSettingsDownloadsYtdlTypeViewRepo;
        tipSettings.SetToolTip(llbSettingsDownloadsYtdlTypeViewRepo, Language.llbSettingsDownloadsYtdlTypeViewRepoHint);

        chkSettingsDownloadsSeparateBatchDownloads.Text = Language.chkSettingsDownloadsSeparateBatchDownloads;
        tipSettings.SetToolTip(chkSettingsDownloadsSeparateBatchDownloads, Language.chkSettingsDownloadsSeparateBatchDownloadsHint);
        chkSettingsDownloadsAddDateToBatchDownloadFolders.Text = Language.chkSettingsDownloadsAddDateToBatchDownloadFolders;
        tipSettings.SetToolTip(chkSettingsDownloadsAddDateToBatchDownloadFolders, Language.chkSettingsDownloadsAddDateToBatchDownloadFoldersHint);

        chkYtdlpPreferExtendedDialog.Text = Language.chkExtendedPreferExtendedDialog;
        tipSettings.SetToolTip(chkYtdlpPreferExtendedDialog, Language.chkExtendedPreferExtendedDialogHint);
        chkYtdlpExtendedAutomaticallyDownloadThumbnail.Text = Language.chkExtendedAutomaticallyDownloadThumbnail;
        tipSettings.SetToolTip(chkYtdlpExtendedAutomaticallyDownloadThumbnail, Language.chkExtendedAutomaticallyDownloadThumbnailHint);

        chkSettingsConverterClearOutputAfterConverting.Text = Language.chkSettingsConverterClearOutputAfterConverting;
        tipSettings.SetToolTip(chkSettingsConverterClearOutputAfterConverting, Language.chkSettingsConverterClearOutputAfterConvertingHint);
        chkSettingsConverterDetectOutputFileType.Text = Language.chkSettingsConverterDetectOutputFileType;
        tipSettings.SetToolTip(chkSettingsConverterDetectOutputFileType, Language.chkSettingsConverterDetectOutputFileTypeHint);
        chkSettingsConverterClearInputAfterConverting.Text = Language.chkSettingsConverterClearInputAfterConverting;
        tipSettings.SetToolTip(chkSettingsConverterClearInputAfterConverting, Language.chkSettingsConverterClearInputAfterConvertingHint);
        chkSettingsConverterHideFFmpegCompileInfo.Text = Language.chkSettingsConverterHideFFmpegCompileInfo;
        tipSettings.SetToolTip(chkSettingsConverterHideFFmpegCompileInfo, Language.chkSettingsConverterHideFFmpegCompileInfoHint);

        tcSettingsConverterVideo.Text = Language.tcSettingsConverterVideo;
        tcSettingsConverterAudio.Text = Language.tcSettingsConverterAudio;
        tcSettingsConverterCustom.Text = Language.tcSettingsConverterCustom;

        lbSettingsConverterVideoBitrate.Text = Language.lbSettingsConverterVideoBitrate;
        tipSettings.SetToolTip(lbSettingsConverterVideoBitrate, Language.lbSettingsConverterVideoBitrateHint);
        lbSettingsConverterVideoPreset.Text = Language.lbSettingsConverterVideoPreset;
        tipSettings.SetToolTip(lbSettingsConverterVideoPreset, Language.lbSettingsConverterVideoPresetHint);
        lbSettingsConverterVideoProfile.Text = Language.lbSettingsConverterVideoProfile;
        tipSettings.SetToolTip(lbSettingsConverterVideoProfile, Language.lbSettingsConverterVideoProfileHint);
        lbSettingsConverterVideoCRF.Text = Language.lbSettingsConverterVideoCRF;
        tipSettings.SetToolTip(lbSettingsConverterVideoCRF, Language.lbSettingsConverterVideoCRFHint);
        chkSettingsConverterVideoFastStart.Text = Language.chkSettingsConverterVideoFastStart;
        tipSettings.SetToolTip(chkSettingsConverterVideoFastStart, Language.chkSettingsConverterVideoFastStartHint);
        lbSettingsConverterAudioBitrate.Text = Language.lbSettingsConverterAudioBitrate;
        tipSettings.SetToolTip(lbSettingsConverterAudioBitrate, Language.lbSettingsConverterAudioBitrateHint);
        lbSettingsConverterCustomHeader.Text = Language.lbSettingsConverterCustomHeader;
        tipSettings.SetToolTip(txtSettingsConverterCustomArguments, Language.txtSettingsConverterCustomArgumentsHint);

        lbSettingsExtensionsHeader.Text = Language.lbSettingsExtensionsHeader;
        //tipSettings.SetToolTip(lbSettingsExtensionsHeader, Language.lbSettingsExtensionsHeaderHint);
        lbSettingsExtensionsExtensionFullName.Text = Language.lbSettingsExtensionsExtensionFullName;
        txtSettingsExtensionsExtensionFullName.TextHint = Language.txtSettingsExtensionsExtensionFullName;
        //tipSettings.SetToolTip(lbSettingsExtensionsExtensionFullName, Language.lbSettingsExtensionsExtensionFullNameHint);
        lbSettingsExtensionsExtensionShort.Text = Language.lbSettingsExtensionsExtensionShort;
        txtSettingsExtensionsExtensionShort.TextHint = Language.txtSettingsExtensionsExtensionShort;
        //tipSettings.SetToolTip(lbSettingsExtensionsExtensionShort, Language.lbSettingsExtensionsExtensionShortHint);
        btnSettingsExtensionsAdd.Text = Language.btnSettingsExtensionsAdd;
        //tipSettings.SetToolTip(btnSettingsExtensionsAdd, Language.btnSettingsExtensionsAddHint);
        lbSettingsExtensionsFileName.Text = Language.lbSettingsExtensionsFileName + ".ext";
        //tipSettings.SetToolTip(lbSettingsExtensionsFileName, Language.lbSettingsExtensionsFileNameHint);
        btnSettingsExtensionsRemoveSelected.Text = Language.btnSettingsExtensionsRemoveSelected;
        //tipSettings.SetToolTip(btnSettingsExtensionsRemoveSelected, Language.btnSettingsExtensionsRemoveSelectedHint);

        chkSettingsErrorsShowDetailedErrors.Text = Language.chkSettingsErrorsShowDetailedErrors;
        tipSettings.SetToolTip(chkSettingsErrorsShowDetailedErrors, Language.chkSettingsErrorsShowDetailedErrorsHint);
        chkSettingsErrorsSaveErrorsAsErrorLog.Text = Language.chkSettingsErrorsSaveErrorsAsErrorLog;
        tipSettings.SetToolTip(chkSettingsErrorsSaveErrorsAsErrorLog, Language.chkSettingsErrorsSaveErrorsAsErrorLogHint);
        chkSettingsErrorsSuppressErrors.Text = Language.chkSettingsErrorsSuppressErrors;
        tipSettings.SetToolTip(chkSettingsErrorsSuppressErrors, Language.chkSettingsErrorsSuppressErrorsHint);
    }
    private void CalculatePositions() {
        chkSettingsGeneralCheckForUpdatesOnLaunch.Location = new(
            (tabSettingsGeneral.Size.Width - chkSettingsGeneralCheckForUpdatesOnLaunch.Size.Width) / 2,
            chkSettingsGeneralCheckForUpdatesOnLaunch.Location.Y
        );
        chkSettingsGeneralCheckForBetaUpdates.Location = new(
            (tabSettingsGeneral.Size.Width - chkSettingsGeneralCheckForBetaUpdates.Size.Width) / 2,
            chkSettingsGeneralCheckForBetaUpdates.Location.Y
        );
        chkSettingsGeneralDeleteUpdaterAfterUpdating.Location = new(
            (tabSettingsGeneral.Size.Width - chkSettingsGeneralDeleteUpdaterAfterUpdating.Size.Width) / 2,
            chkSettingsGeneralDeleteUpdaterAfterUpdating.Location.Y
        );
        chkDeleteOldVersionAfterUpdating.Location = new(
            (tabSettingsGeneral.Size.Width - chkDeleteOldVersionAfterUpdating.Size.Width) / 2,
            chkDeleteOldVersionAfterUpdating.Location.Y
        );
        chkSettingsGeneralHoverOverUrlToPasteClipboard.Location = new(
            (tabSettingsGeneral.Size.Width - chkSettingsGeneralHoverOverUrlToPasteClipboard.Size.Width) / 2,
            chkSettingsGeneralHoverOverUrlToPasteClipboard.Location.Y
        );
        chkSettingsGeneralClearUrlOnDownload.Location = new(
            (tabSettingsGeneral.Size.Width - chkSettingsGeneralClearUrlOnDownload.Size.Width) / 2,
            chkSettingsGeneralClearUrlOnDownload.Location.Y
        );
        chkSettingsGeneralClearClipboardOnDownload.Location = new(
            (tabSettingsGeneral.Size.Width - chkSettingsGeneralClearClipboardOnDownload.Size.Width) / 2,
            chkSettingsGeneralClearClipboardOnDownload.Location.Y
        );
        chkSettingsGeneralAutoUpdateYoutubeDl.Location = new(
            (tabSettingsGeneral.Size.Width - chkSettingsGeneralAutoUpdateYoutubeDl.Size.Width) / 2,
            chkSettingsGeneralAutoUpdateYoutubeDl.Location.Y
        );
        rbSettingsGeneralCustomArgumentsDontSave.Location = new(
            (gbSettingsGeneralCustomArguments.Size.Width - (rbSettingsGeneralCustomArgumentsDontSave.Size.Width + rbSettingsGeneralCustomArgumentsSaveAsArgsText.Size.Width + rbSettingsGeneralCustomArgumentsSaveInSettings.Size.Width)) / 2,
            rbSettingsGeneralCustomArgumentsDontSave.Location.Y
        );
        rbSettingsGeneralCustomArgumentsSaveAsArgsText.Location = new(
            (rbSettingsGeneralCustomArgumentsDontSave.Location.X + rbSettingsGeneralCustomArgumentsDontSave.Size.Width) + 2,
            rbSettingsGeneralCustomArgumentsDontSave.Location.Y
        );
        rbSettingsGeneralCustomArgumentsSaveInSettings.Location = new(
            (rbSettingsGeneralCustomArgumentsSaveAsArgsText.Location.X + rbSettingsGeneralCustomArgumentsSaveAsArgsText.Size.Width) + 2,
            rbSettingsGeneralCustomArgumentsSaveAsArgsText.Location.Y
        );


        llSettingsDownloadsSchemaHelp.Location = new(
            (lbSettingsDownloadsFileNameSchema.Location.X + lbSettingsDownloadsFileNameSchema.Size.Width) - 4,
            lbSettingsDownloadsFileNameSchema.Location.Y
        );
        chkSettingsDownloadsEmbedThumbnails.Location = new(
            (chkSettingsDownloadsSaveThumbnails.Location.X + chkSettingsDownloadsSaveThumbnails.Size.Width + 2),
            chkSettingsDownloadsSaveThumbnails.Location.Y
        );
        chkSettingsDownloadsWriteMetadataToFile.Location = new(
            (chkSettingsDownloadsSaveVideoInfo.Location.X + chkSettingsDownloadsSaveVideoInfo.Size.Width + 2),
            chkSettingsDownloadsSaveVideoInfo.Location.Y
        );
        chkSettingsDownloadsKeepOriginalFiles.Location = new(
            (chkSettingsDownloadsSaveDescription.Location.X + chkSettingsDownloadsSaveDescription.Size.Width + 2),
            chkSettingsDownloadsSaveDescription.Location.Y
        );
        chkSettingsDownloadsEmbedSubtitles.Location = new(
            (chkSettingsDownloadsDownloadSubtitles.Location.X + chkSettingsDownloadsDownloadSubtitles.Size.Width + 2),
            chkSettingsDownloadsDownloadSubtitles.Location.Y
        );

        numSettingsDownloadsLimitDownload.Location = new(
            (chkSettingsDownloadsLimitDownload.Location.X + chkSettingsDownloadsLimitDownload.Size.Width) + 2,
            numSettingsDownloadsLimitDownload.Location.Y
        );
        cbSettingsDownloadsLimitDownload.Location = new(
            (numSettingsDownloadsLimitDownload.Location.X + numSettingsDownloadsLimitDownload.Size.Width) + 2,
            cbSettingsDownloadsLimitDownload.Location.Y
        );
        numSettingsDownloadsRetryAttempts.Location = new(
            (lbSettingsDownloadsRetryAttempts.Location.X + lbSettingsDownloadsRetryAttempts.Size.Width),
            numSettingsDownloadsRetryAttempts.Location.Y
        );
    }
    private void LoadSettings() {
        if (Config.Settings.General.UseStaticYtdl && !string.IsNullOrEmpty(Config.Settings.General.ytdlPath)) {
            txtSettingsGeneralYoutubeDlPath.Text = Config.Settings.General.ytdlPath;
            chkSettingsGeneralUseStaticYoutubeDl.Checked = Config.Settings.General.UseStaticYtdl;
        }
        else {
            if (Verification.YoutubeDlPath != null) {
                txtSettingsGeneralYoutubeDlPath.Text = Verification.YoutubeDlPath;
            }
        }

        if (Config.Settings.General.UseStaticFFmpeg && !string.IsNullOrEmpty(Config.Settings.General.ffmpegPath)) {
            txtSettingsGeneralFFmpegPath.Text = Config.Settings.General.ffmpegPath;
            chkSettingsGeneralUseStaticFFmpeg.Checked = Config.Settings.General.UseStaticFFmpeg;
        }
        else {
            if (Verification.FFmpegPath != null) {
                txtSettingsGeneralFFmpegPath.Text = Verification.FFmpegPath;
            }
        }

        chkSettingsGeneralCheckForUpdatesOnLaunch.Checked = Config.Settings.General.CheckForUpdatesOnLaunch;
        chkSettingsGeneralCheckForBetaUpdates.Checked = Config.Settings.General.DownloadBetaVersions;
        chkSettingsGeneralDeleteUpdaterAfterUpdating.Checked = Config.Settings.General.DeleteUpdaterOnStartup;
        chkDeleteOldVersionAfterUpdating.Checked = Config.Settings.General.DeleteBackupOnStartup;
        chkSettingsGeneralHoverOverUrlToPasteClipboard.Checked = Config.Settings.General.HoverOverURLTextBoxToPaste;
        chkSettingsGeneralClearUrlOnDownload.Checked = Config.Settings.General.ClearURLOnDownload;
        chkSettingsGeneralClearClipboardOnDownload.Checked = Config.Settings.General.ClearClipboardOnDownload;
        chkSettingsGeneralAutoUpdateYoutubeDl.Checked = Config.Settings.General.AutoUpdateYoutubeDl;
        switch (Config.Settings.General.SaveCustomArgs) {
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
        chkSettingsDownloadsDownloadSubtitles.Checked = Config.Settings.Downloads.SaveSubtitles;
        chkSettingsDownloadsEmbedSubtitles.Enabled = Config.Settings.Downloads.SaveSubtitles;
        chkSettingsDownloadsDownloadSubtitles.Checked = Config.Settings.Downloads.SaveSubtitles;
        chkSettingsDownloadsEmbedSubtitles.Enabled = Config.Settings.Downloads.SaveSubtitles;
        chkSettingsDownloadsEmbedSubtitles.Checked = Config.Settings.Downloads.EmbedSubtitles;
        chkSettingsDownloadsSaveVideoInfo.Checked = Config.Settings.Downloads.SaveVideoInfo;
        chkSettingsDownloadsWriteMetadataToFile.Checked = Config.Settings.Downloads.WriteMetadata;
        chkSettingsDownloadsSaveDescription.Checked = Config.Settings.Downloads.SaveDescription;
        chkSettingsDownloadsKeepOriginalFiles.Checked = Config.Settings.Downloads.KeepOriginalFiles;
        chkSettingsDownloadsSaveAnnotations.Checked = Config.Settings.Downloads.SaveAnnotations;
        chkSettingsDownloadsSaveThumbnails.Checked = Config.Settings.Downloads.SaveThumbnail;
        chkSettingsDownloadsEmbedThumbnails.Enabled = Config.Settings.Downloads.SaveThumbnail;
        chkSettingsDownloadsSaveThumbnails.Checked = Config.Settings.Downloads.SaveThumbnail;
        chkSettingsDownloadsEmbedThumbnails.Enabled = Config.Settings.Downloads.SaveThumbnail;
        chkSettingsDownloadsEmbedThumbnails.Checked = Config.Settings.Downloads.EmbedThumbnails;
        chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Checked = Config.Settings.Downloads.deleteYtdlOnClose;
        chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Checked = Config.Settings.Downloads.separateDownloads;
        chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked = Config.Settings.Downloads.separateIntoWebsiteURL;
        chkSettingsDownloadsWebsiteSubdomains.Checked = Config.Settings.Downloads.SubdomainFolderNames;
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
        chksettingsDownloadsUseYoutubeDlsUpdater.Checked = useYtdlUpdater_Last = Config.Settings.Downloads.useYtdlUpdater;
        cbSettingsDownloadsUpdatingYtdlType.SelectedIndex = YtdlType_Last = Config.Settings.Downloads.YtdlType;
        chkYtdlpPreferExtendedDialog.Checked = Config.Settings.Downloads.ExtendedDownloaderPreferExtendedForm;
        chkYtdlpExtendedAutomaticallyDownloadThumbnail.Checked = Config.Settings.Downloads.ExtendedDownloaderAutoDownloadThumbnail;

        chkSettingsConverterDetectOutputFileType.Checked = Config.Settings.Converts.detectFiletype;
        chkSettingsConverterClearOutputAfterConverting.Checked = Config.Settings.Converts.clearOutput;
        chkSettingsConverterClearInputAfterConverting.Checked = Config.Settings.Converts.clearInput;
        chkSettingsConverterHideFFmpegCompileInfo.Checked = Config.Settings.Converts.hideFFmpegCompile;

        chkSettingsConverterVideoBitrate.Checked = Config.Settings.Converts.videoUseBitrate;
        numConvertVideoBitrate.Value = Config.Settings.Converts.videoBitrate;
        chkSettingsConverterVideoPreset.Checked = Config.Settings.Converts.videoUsePreset;
        cbConvertVideoPreset.SelectedIndex = Config.Settings.Converts.videoPreset;
        chkSettingsConverterVideoProfile.Checked = Config.Settings.Converts.videoUseProfile;
        cbConvertVideoProfile.SelectedIndex = Config.Settings.Converts.videoProfile;
        chkSettingsConverterVideoCRF.Checked = Config.Settings.Converts.videoUseCRF;
        numConvertVideoCRF.Value = Config.Settings.Converts.videoCRF;

        chkSettingsConverterVideoFastStart.Checked = Config.Settings.Converts.videoFastStart;

        chkUseAudioBitrate.Checked = Config.Settings.Converts.audioUseBitrate;
        numConvertAudioBitrate.Value = Config.Settings.Converts.audioBitrate;

        txtSettingsConverterCustomArguments.Text = Config.Settings.Saved.convertCustom;

        LoadExtensions();

        chkSettingsErrorsShowDetailedErrors.Checked = Config.Settings.Errors.detailedErrors;
        chkSettingsErrorsSaveErrorsAsErrorLog.Checked = Config.Settings.Errors.logErrors;
        chkSettingsErrorsSuppressErrors.Checked = Config.Settings.Errors.suppressErrors;
    }
    private void SaveSettings() {
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
        Config.Settings.General.DeleteUpdaterOnStartup = chkSettingsGeneralDeleteUpdaterAfterUpdating.Checked;
        Config.Settings.General.DeleteBackupOnStartup = chkDeleteOldVersionAfterUpdating.Checked;
        Config.Settings.General.HoverOverURLTextBoxToPaste = chkSettingsGeneralHoverOverUrlToPasteClipboard.Checked;
        Config.Settings.General.ClearURLOnDownload = chkSettingsGeneralClearUrlOnDownload.Checked;
        Config.Settings.General.ClearClipboardOnDownload = chkSettingsGeneralClearClipboardOnDownload.Checked;
        Config.Settings.General.AutoUpdateYoutubeDl = chkSettingsGeneralAutoUpdateYoutubeDl.Checked;

        // this is hilarious to me
        Config.Settings.General.SaveCustomArgs = 0 switch {
            _ when rbSettingsGeneralCustomArgumentsSaveAsArgsText.Checked => 1,
            _ when rbSettingsGeneralCustomArgumentsSaveInSettings.Checked => 2,
            _ => 0
        };
        //if (rbSettingsGeneralCustomArgumentsSaveAsArgsText.Checked) {
        //    Config.Settings.General.SaveCustomArgs = 1;
        //}
        //else if (rbSettingsGeneralCustomArgumentsSaveInSettings.Checked) {
        //    Config.Settings.General.SaveCustomArgs = 2;
        //}
        //else {
        //    Config.Settings.General.SaveCustomArgs = 0;
        //}

        Config.Settings.Downloads.downloadPath = txtSettingsDownloadsSavePath.Text;
        Config.Settings.Downloads.fileNameSchema = txtSettingsDownloadsFileNameSchema.Text;
        if (!txtSettingsDownloadsFileNameSchema.Items.Contains(txtSettingsDownloadsFileNameSchema.Text)) {
            txtSettingsDownloadsFileNameSchema.Items.Add(txtSettingsDownloadsFileNameSchema.Text);
        }
        string FileNameSchemaHistory = string.Join("|", txtSettingsDownloadsFileNameSchema.Items.Cast<string>());
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
        if (chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked) {
            Config.Settings.Downloads.SubdomainFolderNames = chkSettingsDownloadsWebsiteSubdomains.Checked;
        }
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
        Config.Settings.Downloads.ExtendedDownloaderPreferExtendedForm = chkYtdlpPreferExtendedDialog.Checked;
        Config.Settings.Downloads.ExtendedDownloaderAutoDownloadThumbnail = chkYtdlpExtendedAutomaticallyDownloadThumbnail.Checked;

        Config.Settings.Converts.detectFiletype = chkSettingsConverterDetectOutputFileType.Checked;
        Config.Settings.Converts.clearOutput = chkSettingsConverterClearOutputAfterConverting.Checked;
        Config.Settings.Converts.clearInput = chkSettingsConverterClearInputAfterConverting.Checked;
        Config.Settings.Converts.hideFFmpegCompile = chkSettingsConverterHideFFmpegCompileInfo.Checked;

        Config.Settings.Converts.videoUseBitrate = chkSettingsConverterVideoBitrate.Checked;
        Config.Settings.Converts.videoBitrate = Decimal.ToInt32(numConvertVideoBitrate.Value);
        Config.Settings.Converts.videoUsePreset = chkSettingsConverterVideoPreset.Checked;
        Config.Settings.Converts.videoPreset = cbConvertVideoPreset.SelectedIndex;
        Config.Settings.Converts.videoUseProfile = chkSettingsConverterVideoProfile.Checked;
        Config.Settings.Converts.videoProfile = cbConvertVideoProfile.SelectedIndex;
        Config.Settings.Converts.videoUseCRF = chkSettingsConverterVideoCRF.Checked;
        Config.Settings.Converts.videoCRF = Decimal.ToInt32(numConvertVideoCRF.Value);
        Config.Settings.Converts.videoFastStart = chkSettingsConverterVideoFastStart.Checked;

        Config.Settings.Converts.audioUseBitrate = chkUseAudioBitrate.Checked;
        Config.Settings.Converts.audioBitrate = Decimal.ToInt32(numConvertAudioBitrate.Value);

        Config.Settings.Saved.convertCustom = txtSettingsConverterCustomArguments.Text;
        Config.Settings.Saved.SettingsFormSize = this.Size;

        SaveExtensions();

        Config.Settings.Errors.detailedErrors = chkSettingsErrorsShowDetailedErrors.Checked;
        Config.Settings.Errors.logErrors = chkSettingsErrorsSaveErrorsAsErrorLog.Checked;
        Config.Settings.Errors.suppressErrors = chkSettingsErrorsSuppressErrors.Checked;

        Config.Settings.General.Save();
        Config.Settings.Downloads.Save();
        Config.Settings.Converts.Save();
        Config.Settings.Errors.Save();
        Config.Settings.Saved.Save();

        if (RefreshYtdl) {
            Verification.RefreshYoutubeDlLocation();
        }
        if (RefreshFFmpeg) {
            Verification.RefreshFFmpegLocation();
        }
    }
    
    private void btnSettingsSave_Click(object sender, EventArgs e) {
        SaveSettings();
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
    private void btnSettingsGeneralBrowseYoutubeDl_Click(object sender, EventArgs e) {
        using OpenFileDialog ofd = new() {
            Title = Language.ofdTitleYoutubeDl,
            Filter = Language.ofdFilterYoutubeDl + " (*.EXE)|*.exe",
            FileName = "yt-dlp.exe"
        };

        if (ofd.ShowDialog() == DialogResult.OK) {
            txtSettingsGeneralYoutubeDlPath.Text = ofd.FileName;
        }
    }

    private void chkSettingsGeneralUseStaticFFmpeg_CheckedChanged(object sender, EventArgs e) {
        Config.Settings.General.UseStaticFFmpeg = chkSettingsGeneralUseStaticFFmpeg.Checked;
    }
    private void btnSettingsGeneralBrowseFFmpeg_Click(object sender, EventArgs e) {
        using OpenFileDialog ofd = new() {
            Title = Language.ofdTitleFFmpeg,
            Filter = Language.ofdFilterFFmpeg + " (*.EXE)|*.exe",
            FileName = "ffmpeg.exe"
        };


        if (ofd.ShowDialog() == DialogResult.OK) {
            txtSettingsGeneralFFmpegPath.Text = ofd.FileName;
        }
    }

    private void btnSettingsRedownloadYoutubeDl_Click(object sender, EventArgs e) {
        YtdlUpdateCheck = new(() => {
            if (UpdateChecker.CheckForYoutubeDlUpdate(true)) {
                if (UpdateChecker.UpdateYoutubeDl(new(this.Location.X + 8, this.Location.Y + 8))) {
                    this.BeginInvoke(() => MessageBox.Show(Language.dlgUpdatedYoutubeDl, Language.ApplicationName, MessageBoxButtons.OK));
                    System.Media.SystemSounds.Asterisk.Play();
                }
                else {
                    System.Media.SystemSounds.Hand.Play();
                }
            }
            else {
                this.BeginInvoke((Action)delegate {
                    MessageBox.Show(string.Format(Language.dlgUpateYoutubeDlNoUpdateRequired, Verification.YoutubeDlVersion, UpdateChecker.LatestYoutubeDl.VersionTag), Language.ApplicationName, MessageBoxButtons.OK);
                });
            }
        }) {
            IsBackground = true
        };
        YtdlUpdateCheck.Start();
    }
    private void btnSettingsRedownloadFfmpeg_Click(object sender, EventArgs e) {
        UpdateChecker.UpdateFfmpeg(new(this.Location.X + 8, this.Location.Y + 8));
    }
    #endregion

    #region Downloads
    private void chkSettingsDownloadsDownloadPathUseRelativePath_CheckedChanged(object sender, EventArgs e) {
        if (!LoadingForm) {
            if (chkSettingsDownloadsDownloadPathUseRelativePath.Checked && txtSettingsDownloadsSavePath.Text.StartsWith(Program.ProgramPath)) {
                txtSettingsDownloadsSavePath.Text = ".\\" + txtSettingsDownloadsSavePath.Text[(Program.ProgramPath.Length + 1)..];
            }
            else if (txtSettingsDownloadsSavePath.Text.StartsWith("./") || txtSettingsDownloadsSavePath.Text.StartsWith(".\\")) {
                txtSettingsDownloadsSavePath.Text = Program.ProgramPath + "\\" + txtSettingsDownloadsSavePath.Text[2..];
            }
        }
    }
    private void btnSettingsDownloadsBrowseSavePath_Click(object sender, EventArgs e) {
        using BetterFolderBrowserNS.BetterFolderBrowser fbd = new();
        fbd.Title = Language.dlgFindDownloadFolder;
        if (chkSettingsDownloadsDownloadPathUseRelativePath.Checked) {
            fbd.RootFolder = Program.ProgramPath;
        }
        else {
            fbd.RootFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
        }

        if (fbd.ShowDialog() == DialogResult.OK) {
            if (chkSettingsDownloadsDownloadPathUseRelativePath.Checked && fbd.SelectedPath.StartsWith(Program.ProgramPath)) {
                txtSettingsDownloadsSavePath.Text = ".\\" + fbd.SelectedPath[(Program.ProgramPath.Length + 1)..];
            }
            else {
                txtSettingsDownloadsSavePath.Text = fbd.SelectedPath;
            }
        }
    }
    private void llSettingsDownloadsSchemaHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
        Process.Start("https://github.com/ytdl-org/youtube-dl/blob/master/README.md#output-template");
    }
    private void txtSettingsDownloadsFileNameSchema_KeyPress(object sender, KeyPressEventArgs e) {
        switch (e.KeyChar) {
            case '\\': case '/': case ':':
            case '*': case '?': case '"':
            case '<': case '>': case '|': {
                System.Media.SystemSounds.Beep.Play();
                e.Handled = true;
            } break;
        }
    }
    private void btnSettingsDownloadsInstallProtocol_Click(object sender, EventArgs e) {
        if (!ProtocolAvailable) {
            int Result;
            bool NewProcess = false;
            if (Program.IsAdmin) {
                Result = SystemRegistry.SetRegistry();
            }
            else {
                NewProcess = true;
                Process InstallerProcess = new() {
                    StartInfo = new() {
                        Arguments = "installprotocol",
                        FileName = Program.FullProgramPath,
                        Verb = "runas",
                        WorkingDirectory = Environment.CurrentDirectory,
                    }
                };
                InstallerProcess.Start();
                InstallerProcess.WaitForExit();
                Result = InstallerProcess.ExitCode;
            }

            switch (Result) {
                case 0: {
                    btnSettingsDownloadsInstallProtocol.Enabled = btnSettingsDownloadsInstallProtocol.ShowUacShield = false;
                    btnSettingsDownloadsInstallProtocol.Text = Language.btnSettingsDownloadsInstallProtocolInstalled;
                } break;

                case 1: {
                    Log.Write("Could not install protocol.");
                } break;

                case 2: {
                    Log.ReportException(new Exception("The process could not gain Administrative permission."));
                } break;
            }
        }
    }
    private void llbSettingsDownloadsInstallProtocolMoreInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
        // TODO: Open link to protocol info.
    }
    private void chkSettingsDownloadsDownloadSubtitles_CheckedChanged(object sender, EventArgs e) {
        chkSettingsDownloadsEmbedSubtitles.Enabled = chkSettingsDownloadsDownloadSubtitles.Checked;
    }
    private void chkSettingsDownloadsSaveThumbnails_CheckedChanged(object sender, EventArgs e) {
        chkSettingsDownloadsEmbedThumbnails.Enabled = chkSettingsDownloadsSaveThumbnails.Checked;
    }
    private void chksettingsDownloadsUseYoutubeDlsUpdater_CheckedChanged(object sender, EventArgs e) {
        Config.Settings.Downloads.useYtdlUpdater = chksettingsDownloadsUseYoutubeDlsUpdater.Checked;
    }
    private void chkSettingsDownloadsSeparateIntoWebsiteUrl_CheckedChanged(object sender, EventArgs e) {
        chkSettingsDownloadsWebsiteSubdomains.Enabled = chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked;
    }
    private void cbSettingsDownloadsUpdatingYtdlType_SelectedIndexChanged(object sender, EventArgs e) {
        Config.Settings.Downloads.YtdlType = cbSettingsDownloadsUpdatingYtdlType.SelectedIndex;
        Verification.RefreshYoutubeDlLocation();
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
            System.Media.SystemSounds.Beep.Play();
            e.Handled = true;
        }
    }
    private void txtSettingsDownloadsProxyPort_KeyPress(object sender, KeyPressEventArgs e) {
        if (!char.IsDigit(e.KeyChar)) {
            System.Media.SystemSounds.Beep.Play();
            e.Handled = true;
        }
    }
    private void llbSettingsDownloadsYtdlTypeViewRepo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
        if (cbSettingsDownloadsUpdatingYtdlType.SelectedIndex > -1) {
            Process.Start(
                string.Format(
                    GithubLinks.GithubRepoUrl,
                    GithubLinks.Users[cbSettingsDownloadsUpdatingYtdlType.SelectedIndex],
                    GithubLinks.Repos[cbSettingsDownloadsUpdatingYtdlType.SelectedIndex]
                )
            );
        }
    }
    #endregion

    #region Converts
    private void lbSettingsConverterVideoBitrate_Click(object sender, EventArgs e) {
        chkSettingsConverterVideoBitrate.Checked ^= true;
    }
    private void lbSettingsConverterVideoPreset_Click(object sender, EventArgs e) {
        chkSettingsConverterVideoPreset.Checked ^= true;
    }
    private void lbSettingsConverterVideoProfile_Click(object sender, EventArgs e) {
        chkSettingsConverterVideoProfile.Checked ^= true;
    }
    private void lbSettingsConverterVideoCRF_Click(object sender, EventArgs e) {
        chkSettingsConverterVideoCRF.Checked ^= true;
    }
    #endregion

    #region Extensions
    private void LoadExtensions() {
        if (!string.IsNullOrEmpty(Config.Settings.General.extensionsName)) {
            extensionsShort.AddRange(Config.Settings.General.extensionsShort.Split('|'));
            extensionsName.AddRange(Config.Settings.General.extensionsName.Split('|'));
            for (int i = 0; i < extensionsShort.Count; i++) {
                listExtensions.Items.Add(extensionsName[i] + " (*." + extensionsShort[i] + ")");
            }
        }
    }
    private void SaveExtensions() {
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

        Formats.LoadCustomFormats();
    }

    private void btnSettingsExtensionsAdd_Click(object sender, EventArgs e) {
        if (txtSettingsExtensionsExtensionFullName.Text.Length == 0) {
            System.Media.SystemSounds.Asterisk.Play();
            txtSettingsExtensionsExtensionFullName.Focus();
            return;
        }

        if (txtSettingsExtensionsExtensionShort.Text.Length == 0) {
            System.Media.SystemSounds.Asterisk.Play();
            txtSettingsExtensionsExtensionShort.Focus();
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