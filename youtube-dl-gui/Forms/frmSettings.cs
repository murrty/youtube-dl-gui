#nullable enable
namespace youtube_dl_gui;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
public partial class frmSettings : LocalizedForm {
    // TODO: ytdl type will save every time it changes. Implement a safeguard to prevent oversaving to ini.

    #region vars
    private bool LoadingForm;
    private readonly bool ProtocolAvailable;

    readonly List<string> extensionsName = [];
    readonly List<string> extensionsShort = [];

    private bool RefreshYtdl;
    private bool RefreshFFmpeg;

    private bool useYtdlUpdater_Last;
    private int YtdlType_Last;
    #endregion

    public frmSettings() {
        LoadingForm = true;
        InitializeComponent();

        cbSettingsDownloadsUpdatingYtdlType.Items.Add($"{GithubLinks.ProviderRepos[0].User}/{GithubLinks.ProviderRepos[0].Repo} (default)");
        for (int i = 1; i < GithubLinks.ProviderRepos.Length; i++) {
            var Repo = GithubLinks.ProviderRepos[i];
            cbSettingsDownloadsUpdatingYtdlType.Items.Add($"{Repo.User}/{Repo.Repo}");
        }

        ProtocolAvailable = SystemRegistry.CheckRegistry();

        LoadLanguage();
        LoadSettings();
    }
    private void frmSettings_Load(object sender, EventArgs e) {
        if (Saved.SettingsFormSize.Valid) {
            this.StartPosition = FormStartPosition.Manual;
            this.Size = Saved.SettingsFormSize;
        }
        LoadingForm = false;
    }
    private void frmSettings_FormClosing(object sender, FormClosingEventArgs e) {
    }

    public override void LoadLanguage() {
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
        btnSettingsDownloadsFileNameSchemaHistory.Text = Language.btnSettingsDownloadsFileNameSchemaHistory;
        tipSettings.SetToolTip(btnSettingsDownloadsFileNameSchemaHistory, Language.btnSettingsDownloadsFileNameSchemaHistoryHint);

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
        tabExtendedOptions.Text = Language.tabExtendedOptions;

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
        chkSettingsDownloadsSkipUnavailableFragments.Text = Language.chkSettingsDownloadsSkipUnavailableFragments;
        tipSettings.SetToolTip(chkSettingsDownloadsSkipUnavailableFragments, Language.chkSettingsDownloadsSkipUnavailableFragmentsHint);
        chkSettingsDownloadsAbortOnError.Text = Language.chkSettingsDownloadsAbortOnError;
        tipSettings.SetToolTip(chkSettingsDownloadsAbortOnError, Language.chkSettingsDownloadsAbortOnErrorHint);

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
        lbSettingsDownloadsFragmentThreads.Text = Language.lbSettingsDownloadsFragmentThreads;
        tipSettings.SetToolTip(lbSettingsDownloadsFragmentThreads, Language.lbSettingsDownloadsFragmentThreadsHint);
        tipSettings.SetToolTip(numSettingsDownloadsFragmentThreads, Language.lbSettingsDownloadsFragmentThreadsHint);

        chksettingsDownloadsUseYoutubeDlsUpdater.Text = Language.chkSettingsDownloadsUseYoutubeDlsUpdater;
        tipSettings.SetToolTip(chksettingsDownloadsUseYoutubeDlsUpdater, Language.chkSettingsDownloadsUseYoutubeDlsUpdaterHint);
        lbSettingsDownloadsUpdatingYtdlType.Text = Language.lbSettingsDownloadsUpdatingYtdlType;
        tipSettings.SetToolTip(cbSettingsDownloadsUpdatingYtdlType, Language.cbSettingsDownloadsUpdatingYtdlTypeHint);
        llbSettingsDownloadsYtdlTypeViewRepo.Text = Language.llbSettingsDownloadsYtdlTypeViewRepo;
        tipSettings.SetToolTip(llbSettingsDownloadsYtdlTypeViewRepo, Language.llbSettingsDownloadsYtdlTypeViewRepoHint);
        chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Text = Language.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing;
        tipSettings.SetToolTip(chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing, Language.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint);

        chkSettingsDownloadsSeparateBatchDownloads.Text = Language.chkSettingsDownloadsSeparateBatchDownloads;
        tipSettings.SetToolTip(chkSettingsDownloadsSeparateBatchDownloads, Language.chkSettingsDownloadsSeparateBatchDownloadsHint);
        chkSettingsDownloadsAddDateToBatchDownloadFolders.Text = Language.chkSettingsDownloadsAddDateToBatchDownloadFolders;
        tipSettings.SetToolTip(chkSettingsDownloadsAddDateToBatchDownloadFolders, Language.chkSettingsDownloadsAddDateToBatchDownloadFoldersHint);

        chkExtendedPreferExtendedDialog.Text = Language.chkExtendedPreferExtendedDialog;
        tipSettings.SetToolTip(chkExtendedPreferExtendedDialog, Language.chkExtendedPreferExtendedDialogHint);
        chkExtendedAutomaticallyDownloadThumbnail.Text = Language.chkExtendedAutomaticallyDownloadThumbnail;
        tipSettings.SetToolTip(chkExtendedAutomaticallyDownloadThumbnail, Language.chkExtendedAutomaticallyDownloadThumbnailHint);
        chkExtendedIncludeCustomArguments.Text = Language.chkExtendedIncludeCustomArguments;
        tipSettings.SetToolTip(chkExtendedIncludeCustomArguments, Language.chkExtendedIncludeCustomArgumentsHint);

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

        chkSettingsConverterVideoBitrate.Text = Language.lbSettingsConverterVideoBitrate;
        tipSettings.SetToolTip(chkSettingsConverterVideoBitrate, Language.lbSettingsConverterVideoBitrateHint);
        chkSettingsConverterVideoPreset.Text = Language.lbSettingsConverterVideoPreset;
        tipSettings.SetToolTip(chkSettingsConverterVideoPreset, Language.lbSettingsConverterVideoPresetHint);
        chkSettingsConverterVideoProfile.Text = Language.lbSettingsConverterVideoProfile;
        tipSettings.SetToolTip(chkSettingsConverterVideoProfile, Language.lbSettingsConverterVideoProfileHint);
        chkSettingsConverterVideoCRF.Text = Language.lbSettingsConverterVideoCRF;
        tipSettings.SetToolTip(chkSettingsConverterVideoCRF, Language.lbSettingsConverterVideoCRFHint);
        chkSettingsConverterVideoFastStart.Text = Language.chkSettingsConverterVideoFastStart;
        tipSettings.SetToolTip(chkSettingsConverterVideoFastStart, Language.chkSettingsConverterVideoFastStartHint);
        chkSettingsConverterAudioBitrate.Text = Language.lbSettingsConverterAudioBitrate;
        tipSettings.SetToolTip(chkSettingsConverterAudioBitrate, Language.lbSettingsConverterAudioBitrateHint);
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
            rbSettingsGeneralCustomArgumentsDontSave.Location.X + rbSettingsGeneralCustomArgumentsDontSave.Size.Width + 2,
            rbSettingsGeneralCustomArgumentsDontSave.Location.Y
        );
        rbSettingsGeneralCustomArgumentsSaveInSettings.Location = new(
            rbSettingsGeneralCustomArgumentsSaveAsArgsText.Location.X + rbSettingsGeneralCustomArgumentsSaveAsArgsText.Size.Width + 2,
            rbSettingsGeneralCustomArgumentsSaveAsArgsText.Location.Y
        );

        llSettingsDownloadsSchemaHelp.Location = new(
            (lbSettingsDownloadsFileNameSchema.Location.X + lbSettingsDownloadsFileNameSchema.Size.Width) - 4,
            lbSettingsDownloadsFileNameSchema.Location.Y
        );
        chkSettingsDownloadsEmbedThumbnails.Location = new(
            chkSettingsDownloadsSaveThumbnails.Location.X + chkSettingsDownloadsSaveThumbnails.Size.Width + 2,
            chkSettingsDownloadsSaveThumbnails.Location.Y
        );
        chkSettingsDownloadsWriteMetadataToFile.Location = new(
            chkSettingsDownloadsSaveVideoInfo.Location.X + chkSettingsDownloadsSaveVideoInfo.Size.Width + 2,
            chkSettingsDownloadsSaveVideoInfo.Location.Y
        );
        chkSettingsDownloadsKeepOriginalFiles.Location = new(
            chkSettingsDownloadsSaveDescription.Location.X + chkSettingsDownloadsSaveDescription.Size.Width + 2,
            chkSettingsDownloadsSaveDescription.Location.Y
        );
        chkSettingsDownloadsEmbedSubtitles.Location = new(
            chkSettingsDownloadsDownloadSubtitles.Location.X + chkSettingsDownloadsDownloadSubtitles.Size.Width + 2,
            chkSettingsDownloadsDownloadSubtitles.Location.Y
        );
        chkSettingsDownloadsAbortOnError.Location = new(
            chkSettingsDownloadsSkipUnavailableFragments.Location.X + chkSettingsDownloadsSkipUnavailableFragments.Size.Width + 2,
            chkSettingsDownloadsSkipUnavailableFragments.Location.Y
        );

        numSettingsDownloadsLimitDownload.Location = new(
            chkSettingsDownloadsLimitDownload.Location.X + chkSettingsDownloadsLimitDownload.Size.Width + 2,
            numSettingsDownloadsLimitDownload.Location.Y
        );
        cbSettingsDownloadsLimitDownload.Location = new(
            numSettingsDownloadsLimitDownload.Location.X + numSettingsDownloadsLimitDownload.Size.Width + 2,
            cbSettingsDownloadsLimitDownload.Location.Y
        );
        numSettingsDownloadsRetryAttempts.Location = new(
            lbSettingsDownloadsRetryAttempts.Location.X + lbSettingsDownloadsRetryAttempts.Size.Width,
            numSettingsDownloadsRetryAttempts.Location.Y
        );
        numSettingsDownloadsFragmentThreads.Location = new(
            lbSettingsDownloadsFragmentThreads.Location.X + lbSettingsDownloadsFragmentThreads.Width + 2,
            numSettingsDownloadsFragmentThreads.Location.Y
        );

        chkSettingsConverterVideoBitrate.Location = new(
            numConvertVideoBitrate.Location.X - chkSettingsConverterVideoBitrate.Width - numConvertVideoBitrate.Margin.Left - chkSettingsConverterVideoBitrate.Margin.Left,
            chkSettingsConverterVideoBitrate.Location.Y);
        chkSettingsConverterVideoPreset.Location = new(
            cbConvertVideoPreset.Location.X - chkSettingsConverterVideoPreset.Width - cbConvertVideoPreset.Margin.Left - chkSettingsConverterVideoPreset.Margin.Left,
            chkSettingsConverterVideoPreset.Location.Y);
        chkSettingsConverterVideoProfile.Location = new(
            cbConvertVideoProfile.Location.X - chkSettingsConverterVideoProfile.Width - cbConvertVideoProfile.Margin.Left - chkSettingsConverterVideoProfile.Margin.Left,
            chkSettingsConverterVideoProfile.Location.Y);
        chkSettingsConverterVideoCRF.Location = new(
            numConvertVideoCRF.Location.X - chkSettingsConverterVideoCRF.Width - numConvertVideoCRF.Margin.Left - chkSettingsConverterVideoCRF.Margin.Left,
            chkSettingsConverterVideoCRF.Location.Y);

        chkSettingsConverterAudioBitrate.Location = new(
            numConvertAudioBitrate.Location.X - chkSettingsConverterAudioBitrate.Width - numConvertAudioBitrate.Margin.Left - chkSettingsConverterAudioBitrate.Margin.Left,
            chkSettingsConverterAudioBitrate.Location.Y);
    }
    private void LoadSettings() {
        if (Verification.YoutubeDlAvailable) {
            txtSettingsGeneralYoutubeDlPath.Text = Verification.YoutubeDlPath;
        }
        else {
            txtSettingsGeneralYoutubeDlPath.Text = Verification.GetExpectedYoutubeDlPath();
        }
        chkSettingsGeneralUseStaticYoutubeDl.Checked = General.UseStaticYtdl;

        if (Verification.FfmpegAvailable) {
            txtSettingsGeneralFFmpegPath.Text = Verification.FFmpegPath;
        }
        else {
            txtSettingsGeneralFFmpegPath.Text = Verification.GetExpectedFfmpegPath();
        }
        chkSettingsGeneralUseStaticFFmpeg.Checked = General.UseStaticFFmpeg;

        chkSettingsGeneralCheckForUpdatesOnLaunch.Checked = General.CheckForUpdatesOnLaunch;
        chkSettingsGeneralCheckForBetaUpdates.Checked = General.DownloadBetaVersions;
        chkSettingsGeneralDeleteUpdaterAfterUpdating.Checked = General.DeleteUpdaterOnStartup;
        chkDeleteOldVersionAfterUpdating.Checked = General.DeleteBackupOnStartup;
        chkSettingsGeneralHoverOverUrlToPasteClipboard.Checked = General.HoverOverURLTextBoxToPaste;
        chkSettingsGeneralClearUrlOnDownload.Checked = General.ClearURLOnDownload;
        chkSettingsGeneralClearClipboardOnDownload.Checked = General.ClearClipboardOnDownload;
        chkSettingsGeneralAutoUpdateYoutubeDl.Checked = General.AutoUpdateYoutubeDl;
        switch (General.SaveCustomArgs) {
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

        if (Downloads.downloadPath.IsNullEmptyWhitespace()) {
            txtSettingsDownloadsSavePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
        }
        else {
            if (Downloads.downloadPath.StartsWith(".\\") || Downloads.downloadPath.StartsWith("./")) {
                chkSettingsDownloadsDownloadPathUseRelativePath.Checked = true;
            }
            txtSettingsDownloadsSavePath.Text = Downloads.downloadPath;
        }

        if (!Saved.FileNameSchemaHistory.IsNullEmptyWhitespace()) {
            txtSettingsDownloadsFileNameSchema.Items.AddRange(Saved.FileNameSchemaHistory.Split('|'));
        }

        int index = txtSettingsDownloadsFileNameSchema.Items.IndexOf(Downloads.fileNameSchema);
        if (index > -1) {
            txtSettingsDownloadsFileNameSchema.SelectedIndex = index;
        }
        else {
            txtSettingsDownloadsFileNameSchema.Items.Add(Downloads.fileNameSchema);
            txtSettingsDownloadsFileNameSchema.SelectedIndex = txtSettingsDownloadsFileNameSchema.Items.Count - 1;
        }

        chkSettingsDownloadsSaveFormatQuality.Checked = Downloads.SaveFormatQuality;
        chkSettingsDownloadsDownloadSubtitles.Checked = Downloads.SaveSubtitles;
        chkSettingsDownloadsEmbedSubtitles.Enabled = Downloads.SaveSubtitles;
        chkSettingsDownloadsDownloadSubtitles.Checked = Downloads.SaveSubtitles;
        chkSettingsDownloadsEmbedSubtitles.Enabled = Downloads.SaveSubtitles;
        chkSettingsDownloadsEmbedSubtitles.Checked = Downloads.EmbedSubtitles;
        chkSettingsDownloadsSaveVideoInfo.Checked = Downloads.SaveVideoInfo;
        chkSettingsDownloadsWriteMetadataToFile.Checked = Downloads.WriteMetadata;
        chkSettingsDownloadsSaveDescription.Checked = Downloads.SaveDescription;
        chkSettingsDownloadsKeepOriginalFiles.Checked = Downloads.KeepOriginalFiles;
        chkSettingsDownloadsSaveAnnotations.Checked = Downloads.SaveAnnotations;
        chkSettingsDownloadsSaveThumbnails.Checked = Downloads.SaveThumbnail;
        chkSettingsDownloadsEmbedThumbnails.Enabled = Downloads.SaveThumbnail;
        chkSettingsDownloadsSaveThumbnails.Checked = Downloads.SaveThumbnail;
        chkSettingsDownloadsEmbedThumbnails.Enabled = Downloads.SaveThumbnail;
        chkSettingsDownloadsEmbedThumbnails.Checked = Downloads.EmbedThumbnails;
        chkSettingsDownloadsSkipUnavailableFragments.Checked = Downloads.SkipUnavailableFragments;
        chkSettingsDownloadsAbortOnError.Checked = Downloads.AbortOnError;
        chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Checked = Downloads.separateDownloads;
        chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked = Downloads.separateIntoWebsiteURL;
        chkSettingsDownloadsWebsiteSubdomains.Checked = Downloads.SubdomainFolderNames;
        chkSettingsDownloadsFixVReddIt.Checked = Downloads.fixReddit;
        chkSettingsDownloadsPreferFFmpeg.Checked = Downloads.PreferFFmpeg;
        chkSettingsDownloadsLimitDownload.Checked = Downloads.LimitDownloads;
        numSettingsDownloadsLimitDownload.Value = Downloads.DownloadLimit;
        cbSettingsDownloadsLimitDownload.SelectedIndex = Downloads.DownloadLimitType;
        numSettingsDownloadsRetryAttempts.Value = Downloads.RetryAttempts;
        chkSettingsDownloadsForceIpv4.Checked = Downloads.ForceIPv4;
        chkSettingsDownloadsForceIpv6.Checked = Downloads.ForceIPv6;
        chkSettingsDownloadsUseProxy.Checked = Downloads.UseProxy;
        cbSettingsDownloadsProxyType.SelectedIndex = Downloads.ProxyType;
        txtSettingsDownloadsProxyIp.Text = Downloads.ProxyIP;
        txtSettingsDownloadsProxyPort.Text = Downloads.ProxyPort;
        numSettingsDownloadsFragmentThreads.Value = Downloads.FragmentThreads;
        chksettingsDownloadsUseYoutubeDlsUpdater.Checked = useYtdlUpdater_Last = Downloads.useYtdlUpdater;
        cbSettingsDownloadsUpdatingYtdlType.SelectedIndex = YtdlType_Last = Downloads.YtdlType;
        chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Checked = Downloads.deleteYtdlOnClose;
        chkExtendedPreferExtendedDialog.Checked = Downloads.ExtendedDownloaderPreferExtendedForm;
        chkExtendedAutomaticallyDownloadThumbnail.Checked = Downloads.ExtendedDownloaderAutoDownloadThumbnail;

        chkSettingsConverterDetectOutputFileType.Checked = Converts.detectFiletype;
        chkSettingsConverterClearOutputAfterConverting.Checked = Converts.clearOutput;
        chkSettingsConverterClearInputAfterConverting.Checked = Converts.clearInput;
        chkSettingsConverterHideFFmpegCompileInfo.Checked = Converts.hideFFmpegCompile;

        chkSettingsConverterVideoBitrate.Checked = Converts.videoUseBitrate;
        numConvertVideoBitrate.Value = Converts.videoBitrate;
        chkSettingsConverterVideoPreset.Checked = Converts.videoUsePreset;
        cbConvertVideoPreset.SelectedIndex = Converts.videoPreset;
        chkSettingsConverterVideoProfile.Checked = Converts.videoUseProfile;
        cbConvertVideoProfile.SelectedIndex = Converts.videoProfile;
        chkSettingsConverterVideoCRF.Checked = Converts.videoUseCRF;
        numConvertVideoCRF.Value = Converts.videoCRF;

        chkSettingsConverterVideoFastStart.Checked = Converts.videoFastStart;

        chkSettingsConverterAudioBitrate.Checked = Converts.audioUseBitrate;
        numConvertAudioBitrate.Value = Converts.audioBitrate;

        txtSettingsConverterCustomArguments.Text = Saved.convertCustom;

        LoadExtensions();

        chkSettingsErrorsShowDetailedErrors.Checked = Errors.detailedErrors;
        chkSettingsErrorsSaveErrorsAsErrorLog.Checked = Errors.logErrors;
        chkSettingsErrorsSuppressErrors.Checked = Errors.suppressErrors;
    }
    private void SaveSettings() {
        if (General.UseStaticYtdl != chkSettingsGeneralUseStaticYoutubeDl.Checked) {
            General.UseStaticYtdl = chkSettingsGeneralUseStaticYoutubeDl.Checked;
            RefreshYtdl = true;
        }
        if (chkSettingsGeneralUseStaticYoutubeDl.Checked && !txtSettingsGeneralYoutubeDlPath.Text.IsNullEmptyWhitespace() && General.ytdlPath != txtSettingsGeneralYoutubeDlPath.Text) {
            General.ytdlPath = txtSettingsGeneralYoutubeDlPath.Text;
            RefreshYtdl = true;
        }

        if (General.UseStaticFFmpeg != chkSettingsGeneralUseStaticFFmpeg.Checked) {
            General.UseStaticFFmpeg = chkSettingsGeneralUseStaticFFmpeg.Checked;
            RefreshFFmpeg = true;
        }
        if (chkSettingsGeneralUseStaticFFmpeg.Checked && !txtSettingsGeneralFFmpegPath.Text.IsNullEmptyWhitespace() && General.ffmpegPath != txtSettingsGeneralFFmpegPath.Text) {
            General.ffmpegPath = txtSettingsGeneralFFmpegPath.Text;
            RefreshFFmpeg = true;
        }

        General.CheckForUpdatesOnLaunch = chkSettingsGeneralCheckForUpdatesOnLaunch.Checked;
        General.DownloadBetaVersions = chkSettingsGeneralCheckForBetaUpdates.Checked;
        General.DeleteUpdaterOnStartup = chkSettingsGeneralDeleteUpdaterAfterUpdating.Checked;
        General.DeleteBackupOnStartup = chkDeleteOldVersionAfterUpdating.Checked;
        General.HoverOverURLTextBoxToPaste = chkSettingsGeneralHoverOverUrlToPasteClipboard.Checked;
        General.ClearURLOnDownload = chkSettingsGeneralClearUrlOnDownload.Checked;
        General.ClearClipboardOnDownload = chkSettingsGeneralClearClipboardOnDownload.Checked;
        General.AutoUpdateYoutubeDl = chkSettingsGeneralAutoUpdateYoutubeDl.Checked;

        // this is hilarious to me
        General.SaveCustomArgs = 0 switch {
            _ when rbSettingsGeneralCustomArgumentsSaveAsArgsText.Checked => 1,
            _ when rbSettingsGeneralCustomArgumentsSaveInSettings.Checked => 2,
            _ => 0
        };
        //if (rbSettingsGeneralCustomArgumentsSaveAsArgsText.Checked) {
        //    General.SaveCustomArgs = 1;
        //}
        //else if (rbSettingsGeneralCustomArgumentsSaveInSettings.Checked) {
        //    General.SaveCustomArgs = 2;
        //}
        //else {
        //    General.SaveCustomArgs = 0;
        //}

        Downloads.downloadPath = txtSettingsDownloadsSavePath.Text;
        Downloads.fileNameSchema = txtSettingsDownloadsFileNameSchema.Text;
        if (!txtSettingsDownloadsFileNameSchema.Items.Contains(txtSettingsDownloadsFileNameSchema.Text)) {
            txtSettingsDownloadsFileNameSchema.Items.Add(txtSettingsDownloadsFileNameSchema.Text);
        }
        string FileNameSchemaHistory = string.Join("|", txtSettingsDownloadsFileNameSchema.Items.Cast<string>());
        if (Saved.FileNameSchemaHistory != FileNameSchemaHistory) {
            Saved.FileNameSchemaHistory = FileNameSchemaHistory;
        }
        Downloads.SaveFormatQuality = chkSettingsDownloadsSaveFormatQuality.Checked;
        Downloads.SaveSubtitles = chkSettingsDownloadsDownloadSubtitles.Checked;
        Downloads.EmbedSubtitles = chkSettingsDownloadsEmbedSubtitles.Checked;
        Downloads.SaveVideoInfo = chkSettingsDownloadsSaveVideoInfo.Checked;
        Downloads.WriteMetadata = chkSettingsDownloadsWriteMetadataToFile.Checked;
        Downloads.SaveDescription = chkSettingsDownloadsSaveDescription.Checked;
        Downloads.KeepOriginalFiles = chkSettingsDownloadsKeepOriginalFiles.Checked;
        Downloads.SaveAnnotations = chkSettingsDownloadsSaveAnnotations.Checked;
        Downloads.SaveThumbnail = chkSettingsDownloadsSaveThumbnails.Checked;
        Downloads.EmbedThumbnails = chkSettingsDownloadsEmbedThumbnails.Checked;
        Downloads.SkipUnavailableFragments = chkSettingsDownloadsSkipUnavailableFragments.Checked;
        Downloads.AbortOnError = chkSettingsDownloadsAbortOnError.Checked;
        Downloads.separateDownloads = chkSettingsDownloadsSeparateDownloadsToDifferentFolders.Checked;
        Downloads.separateIntoWebsiteURL = chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked;
        if (chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked) {
            Downloads.SubdomainFolderNames = chkSettingsDownloadsWebsiteSubdomains.Checked;
        }
        Downloads.fixReddit = chkSettingsDownloadsFixVReddIt.Checked;
        Downloads.PreferFFmpeg = chkSettingsDownloadsPreferFFmpeg.Checked;
        Downloads.LimitDownloads = chkSettingsDownloadsLimitDownload.Checked;
        Downloads.DownloadLimit = (int)numSettingsDownloadsLimitDownload.Value;
        Downloads.DownloadLimitType = cbSettingsDownloadsLimitDownload.SelectedIndex;
        Downloads.RetryAttempts = (int)numSettingsDownloadsRetryAttempts.Value;
        Downloads.ForceIPv4 = chkSettingsDownloadsForceIpv4.Checked;
        Downloads.ForceIPv6 = chkSettingsDownloadsForceIpv6.Checked;
        Downloads.UseProxy = chkSettingsDownloadsUseProxy.Checked;
        Downloads.ProxyType = cbSettingsDownloadsProxyType.SelectedIndex;
        Downloads.ProxyIP = txtSettingsDownloadsProxyIp.Text;
        Downloads.ProxyPort = txtSettingsDownloadsProxyPort.Text;
        Downloads.FragmentThreads = (int)numSettingsDownloadsFragmentThreads.Value;
        Downloads.useYtdlUpdater = chksettingsDownloadsUseYoutubeDlsUpdater.Checked;
        if (cbSettingsDownloadsUpdatingYtdlType.SelectedIndex != YtdlType_Last) {
            RefreshYtdl = true;
        }
        Downloads.YtdlType = cbSettingsDownloadsUpdatingYtdlType.SelectedIndex;
        Downloads.deleteYtdlOnClose = chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing.Checked;
        Downloads.ExtendedDownloaderPreferExtendedForm = chkExtendedPreferExtendedDialog.Checked;
        Downloads.ExtendedDownloaderAutoDownloadThumbnail = chkExtendedAutomaticallyDownloadThumbnail.Checked;

        Converts.detectFiletype = chkSettingsConverterDetectOutputFileType.Checked;
        Converts.clearOutput = chkSettingsConverterClearOutputAfterConverting.Checked;
        Converts.clearInput = chkSettingsConverterClearInputAfterConverting.Checked;
        Converts.hideFFmpegCompile = chkSettingsConverterHideFFmpegCompileInfo.Checked;

        Converts.videoUseBitrate = chkSettingsConverterVideoBitrate.Checked;
        Converts.videoBitrate = Decimal.ToInt32(numConvertVideoBitrate.Value);
        Converts.videoUsePreset = chkSettingsConverterVideoPreset.Checked;
        Converts.videoPreset = cbConvertVideoPreset.SelectedIndex;
        Converts.videoUseProfile = chkSettingsConverterVideoProfile.Checked;
        Converts.videoProfile = cbConvertVideoProfile.SelectedIndex;
        Converts.videoUseCRF = chkSettingsConverterVideoCRF.Checked;
        Converts.videoCRF = Decimal.ToInt32(numConvertVideoCRF.Value);
        Converts.videoFastStart = chkSettingsConverterVideoFastStart.Checked;

        Converts.audioUseBitrate = chkSettingsConverterAudioBitrate.Checked;
        Converts.audioBitrate = Decimal.ToInt32(numConvertAudioBitrate.Value);

        Saved.convertCustom = txtSettingsConverterCustomArguments.Text;
        Saved.SettingsFormSize = this.Size;

        SaveExtensions();

        Errors.detailedErrors = chkSettingsErrorsShowDetailedErrors.Checked;
        Errors.logErrors = chkSettingsErrorsSaveErrorsAsErrorLog.Checked;
        Errors.suppressErrors = chkSettingsErrorsSuppressErrors.Checked;

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
        Downloads.useYtdlUpdater = useYtdlUpdater_Last;
        Downloads.YtdlType = YtdlType_Last;
        this.Dispose();
    }

    #region General
    private void chkSettingsGeneralUseStaticYoutubeDl_CheckedChanged(object sender, EventArgs e) {
        General.UseStaticYtdl = chkSettingsGeneralUseStaticYoutubeDl.Checked;
    }
    private void btnSettingsGeneralBrowseYoutubeDl_Click(object sender, EventArgs e) {
        using OpenFileDialog ofd = new() {
            Title = Language.ofdTitleYoutubeDl,
            Filter = Language.ofdFilterYoutubeDl + " (*.EXE)|*.exe",
            FileName = Verification.GetYoutubeDlProvider(true)
        };

        if (ofd.ShowDialog() == DialogResult.OK) {
            txtSettingsGeneralYoutubeDlPath.Text = ofd.FileName;
            chkSettingsGeneralUseStaticYoutubeDl.Checked = true;
        }
    }

    private void chkSettingsGeneralUseStaticFFmpeg_CheckedChanged(object sender, EventArgs e) {
        General.UseStaticFFmpeg = chkSettingsGeneralUseStaticFFmpeg.Checked;
    }
    private void btnSettingsGeneralBrowseFFmpeg_Click(object sender, EventArgs e) {
        using OpenFileDialog ofd = new() {
            Title = Language.ofdTitleFFmpeg,
            Filter = Language.ofdFilterFFmpeg + " (*.EXE)|*.exe",
            FileName = "ffmpeg.exe"
        };

        if (ofd.ShowDialog() == DialogResult.OK) {
            txtSettingsGeneralFFmpegPath.Text = ofd.FileName;
            chkSettingsGeneralUseStaticFFmpeg.Checked = true;
        }
    }

    private async void btnSettingsRedownloadYoutubeDl_Click(object sender, EventArgs e) {
        btnSettingsRedownloadYoutubeDl.Enabled = false;
        if (chksettingsDownloadsUseYoutubeDlsUpdater.Checked) {
            if (!Updater.UpdateYoutubeDl(true))
                System.Media.SystemSounds.Hand.Play();
        }
        else {
            if (!await Updater.CheckForYoutubeDlUpdate(true)) {
                Log.MessageBox(Language.dlgUpateYoutubeDlNoUpdateRequired.Format(Verification.YoutubeDlVersion ?? "Unknown", Updater.LatestYoutubeDl?.VersionTag ?? "unknown"), MessageBoxButtons.OK);
                btnSettingsRedownloadYoutubeDl.Enabled = true;
                return;
            }

            if (Updater.UpdateYoutubeDl(false, new(this.Location.X + 8, this.Location.Y + 8))) {
                System.Media.SystemSounds.Asterisk.Play();
                Log.MessageBox(Language.dlgUpdatedYoutubeDl, MessageBoxButtons.OK);
            }
            else {
                System.Media.SystemSounds.Hand.Play();
            }
        }
        btnSettingsRedownloadYoutubeDl.Enabled = true;
    }
    private async void btnSettingsRedownloadFfmpeg_Click(object sender, EventArgs e) {
        btnSettingsRedownloadFfmpeg.Enabled = false;
        if (await Updater.UpdateFfmpeg(new(this.Location.X + 8, this.Location.Y + 8))) {
            System.Media.SystemSounds.Asterisk.Play();
            Log.MessageBox("Placeholder -- ffmpeg downloaded", MessageBoxButtons.OK);
        }
        else {
            System.Media.SystemSounds.Hand.Play();
        }
        btnSettingsRedownloadFfmpeg.Enabled = true;
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
        string GetSelectedPath(string path) => chkSettingsDownloadsDownloadPathUseRelativePath.Checked
        && path.StartsWith(Program.ProgramPath, StringComparison.InvariantCultureIgnoreCase) ?
            (".\\" + path[(Program.ProgramPath.Length + 1)..]) : path;

        using BetterFolderBrowserNS.BetterFolderBrowser fbd = new() {
            RootFolder = chkSettingsDownloadsDownloadPathUseRelativePath.Checked ?
                Program.ProgramPath : (Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads"),
            Title = Language.dlgFindDownloadFolder
        };

        if (fbd.ShowDialog() == DialogResult.OK)
            txtSettingsDownloadsSavePath.Text = GetSelectedPath(fbd.SelectedPath);
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
            } return;
        }
    }
    private void btnSettingsDownloadsFileNameSchemaHistory_Click(object sender, EventArgs e) {
        using frmFileNameSchemaHistory History = new();
        switch (History.ShowDialog(this)) {
            case DialogResult.OK: {
                txtSettingsDownloadsFileNameSchema.Items.Clear();
                if (!History.NewSchema.IsNullEmptyWhitespace()) {
                    txtSettingsDownloadsFileNameSchema.Items.AddRange(History.NewSchema.Split('|'));
                    int index = txtSettingsDownloadsFileNameSchema.Items.IndexOf(Downloads.fileNameSchema);
                    txtSettingsDownloadsFileNameSchema.SelectedIndex = index > -1 ? index : 0;
                }
                else {
                    txtSettingsDownloadsFileNameSchema.Items.Add(Downloads.fileNameSchema);
                    txtSettingsDownloadsFileNameSchema.SelectedIndex = txtSettingsDownloadsFileNameSchema.Items.Count - 1;
                }
            } break;
        }
    }
    private void btnSettingsDownloadsInstallProtocol_Click(object sender, EventArgs e) {
        if (!ProtocolAvailable) {
            int Result;
            if (Program.IsAdmin) {
                Result = SystemRegistry.SetRegistry();
            }
            else {
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
        Process.Start("https://github.com/murrty/youtube-dl-gui/blob/master/ARGUMENTS.md#protocol-support");
    }
    private void chkSettingsDownloadsDownloadSubtitles_CheckedChanged(object sender, EventArgs e) {
        chkSettingsDownloadsEmbedSubtitles.Enabled = chkSettingsDownloadsDownloadSubtitles.Checked;
    }
    private void chkSettingsDownloadsSaveThumbnails_CheckedChanged(object sender, EventArgs e) {
        chkSettingsDownloadsEmbedThumbnails.Enabled = chkSettingsDownloadsSaveThumbnails.Checked;
    }
    private void chksettingsDownloadsUseYoutubeDlsUpdater_CheckedChanged(object sender, EventArgs e) {
        Downloads.useYtdlUpdater = chksettingsDownloadsUseYoutubeDlsUpdater.Checked;
    }
    private void chkSettingsDownloadsSeparateIntoWebsiteUrl_CheckedChanged(object sender, EventArgs e) {
        chkSettingsDownloadsWebsiteSubdomains.Enabled = chkSettingsDownloadsSeparateIntoWebsiteUrl.Checked;
    }
    private void cbSettingsDownloadsUpdatingYtdlType_SelectedIndexChanged(object sender, EventArgs e) {
        if (LoadingForm) {
            return;
        }
        Downloads.YtdlType = cbSettingsDownloadsUpdatingYtdlType.SelectedIndex;
        Verification.RefreshYoutubeDlLocation();
        if (!Verification.YoutubeDlAvailable)
            txtSettingsGeneralYoutubeDlPath.Text = Verification.GetExpectedYoutubeDlPath();
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
                    GithubLinks.ProviderRepos[cbSettingsDownloadsUpdatingYtdlType.SelectedIndex].User,
                    GithubLinks.ProviderRepos[cbSettingsDownloadsUpdatingYtdlType.SelectedIndex].Repo
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
        if (!string.IsNullOrEmpty(General.extensionsName)) {
            extensionsShort.AddRange(General.extensionsShort.Split('|'));
            extensionsName.AddRange(General.extensionsName.Split('|'));
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

            General.extensionsName = ext;
            General.extensionsShort = shrt;
        }
        else {
            General.extensionsName = string.Empty;
            General.extensionsShort = string.Empty;
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