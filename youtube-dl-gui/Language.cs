namespace youtube_dl_gui;

using murrty.logging;

/// <summary>
/// Controls the language strings of the program. Most, if not all, strings get their text from here.
/// </summary>
public static class Language {
    #region Constants
    public const string ApplicationName = "youtube-dl-gui";
    internal static List<ILocalizedForm> OpenedForms = new();
    #endregion

    #region GetSetRadio (AKA Properties)
    public static bool UsingInternalEnglish { get; private set; }
    public static string LoadedFile { get; private set; }

    #region Language identifier
    public static string CurrentLanguageLong { get; private set; }
    public static string CurrentLanguageShort { get; private set; }
    public static string CurrentLanguageHint { get; private set; }
    public static string CurrentLanguageVersion { get; private set; }
    #endregion

    #region Generics
    public static string GenericInputBest { get; private set; }
    public static string GenericInputWorst { get; private set; }
    public static string GenericCancel { get; private set; }
    public static string GenericSkip { get; private set; }
    public static string GenericSound { get; private set; }
    public static string GenericVideo { get; private set; }
    public static string GenericAudio { get; private set; }
    public static string GenericCustom { get; private set; }
    public static string GenericRetry { get; private set; }
    public static string GenericStart { get; private set; }
    public static string GenericStop { get; private set; }
    public static string GenericExit { get; private set; }
    public static string GenericOk { get; private set; }
    public static string GenericSave { get; private set; }
    public static string GenericAdd { get; private set; }
    public static string GenericClose { get; private set; }
    public static string GenericClear { get; private set; }
    public static string GenericRemoveSelected { get; private set; }
    public static string GenericVerifyLinks { get; private set; }
    public static string GenericDoNotReEncode { get; private set; }
    public static string GenericDoNotRemux { get; private set; }
    public static string GenericDoNotDownload { get; private set; }
    public static string GenericUnknownFormat { get; private set; }
    public static string GenericMoreInfo { get; private set; }
    public static string GenericTitle { get; private set; }
    public static string GenericLength { get; private set; }
    public static string GenericUploadedOn { get; private set; }
    public static string GenericInput { get; private set; }
    public static string GenericOutput { get; private set; }
    public static string GenericArguments { get; private set; }
    public static string GenericAborted { get; private set; }
    public static string GenericError { get; private set; }
    public static string GenericAltError { get; private set; }
    public static string GenericCompleted { get; private set; }
    public static string GenericRemove { get; private set; }

    public static string frmGenericDownloadProgress { get; private set; }
    public static string chContainer { get; private set; }
    public static string chFileSize { get; private set; }
    public static string chFormatId { get; private set; }
    public static string chVideoQuality { get; private set; }
    public static string chVideoFPS { get; private set; }
    public static string chVideoBitrate { get; private set; }
    public static string chVideoDimension { get; private set; }
    public static string chVideoCodec { get; private set; }
    public static string chAudioBitrate { get; private set; }
    public static string chAudioSampleRate { get; private set; }
    public static string chAudioCodec { get; private set; }
    public static string chAudioChannels { get; private set; }
    public static string dlBeginningDownload { get; private set; }
    public static string cvBeginningConversion { get; private set; }
    #endregion

    #region Dialogs
    public static string dlgFirstTimeInitialMessage { get; private set; }
    public static string dlgFirstTimeDownloadFolder { get; private set; }
    public static string dlgFirstTimeDownloadYoutubeDl { get; private set; }
    public static string dlgFirstTimeDownloadFfmpeg { get; private set; }

    public static string dlgClipboardAutoDownloadNotice { get; private set; }
    public static string dlgBatchDownloadClipboardScannerNotice { get; private set; }

    public static string dlgMainArgsTxtDoesntExist { get; private set; }
    public static string dlgMainArgsTxtIsEmpty { get; private set; }
    public static string dlgMainArgsNoneSaved { get; private set; }
    public static string dlgConvertSelectFileToConvert { get; private set; }
    public static string dlgMergeSelectFileToMerge { get; private set; }
    public static string dlgSaveOutputFileAs { get; private set; }
    public static string dlgLanguageHashNoMatch { get; private set; }

    public static string dlgAuthenticationCookiesFromBrowser { get; private set; }

    public static string dlgFindDownloadFolder { get; private set; }
    public static string dlgUpdateFailedToCheck { get; private set; }
    public static string dlgUpdateNoUpdateAvailable { get; private set; }
    public static string dlgUpdateNoBetaUpdateAvailable { get; private set; }
    public static string dlgUpdateNoValidYoutubeDl { get; private set; }
    public static string dlgUpdatedYoutubeDl { get; private set; }
    public static string dlgUpdaterHashNoMatch { get; private set; }
    public static string dlgUpateYoutubeDlNoUpdateRequired { get; private set; }

    public static string frmFileNameSchemaHistory { get; private set; }
    #endregion

    #region Shared downloader
    public static string pbDownloadProgressFfmpegPostProcessing { get; private set; }
    public static string pbDownloadProgressEmbeddingSubtitles { get; private set; }
    public static string pbDownloadProgressEmbeddingMetadata { get; private set; }
    public static string pbDownloadProgressMergingFormats { get; private set; }
    public static string pbDownloadProgressConverting { get; private set; }
    #endregion

    #region frmAbout
    public static string frmAbout { get; private set; }
    public static string lbAboutBody { get; private set; }
    public static string llbCheckForUpdates { get; private set; }
    #endregion

    #region frmArchiveDownloader
    public static string frmArchiveDownloader { get; private set; }
    public static string lbArchiveDownloaderDescription { get; private set; }
    public static string txtArchiveDownloaderHint { get; private set; }
    #endregion

    #region frmAuthentication
    public static string frmAuthentication { get; private set; }
    public static string lbAuthNotice { get; private set; }
    public static string lbAuthUsername { get; private set; }
    public static string lbAuthPassword { get; private set; }
    public static string lbAuth2Factor { get; private set; }
    public static string lbAuthVideoPassword { get; private set; }
    public static string lbAuthCookiesFromFile { get; private set; }
    public static string lbAuthCookiesFromBrowser { get; private set; }
    public static string chkAuthUseNetrc { get; private set; }
    public static string lbAuthNoSave { get; private set; }
    public static string btnAuthBeginDownload { get; private set; }
    #endregion

    #region frmBatchConverter
    public static string frmBatchConverter { get; private set; }
    public static string lbBatchConverterInput { get; private set; }
    public static string txtBatchConverterInputFile { get; private set; }
    public static string lbBatchConverterOutput { get; private set; }
    public static string txtBatchConverterOutputFile { get; private set; }
    public static string txtBatchConverterCustomConversionArguments { get; private set; }
    public static string sbBatchConverterIdle { get; private set; }
    public static string sbBatchConverterConverting { get; private set; }
    public static string sbBatchConverterFinished { get; private set; }
    public static string sbBatchConverterAborted { get; private set; }
    #endregion

    #region frmBatchDownloader
    public static string frmBatchDownload { get; private set; }
    public static string lbBatchDownloadLink { get; private set; }
    public static string lbBatchDownloadType { get; private set; }
    public static string lbBatchDownloadVideoSpecificArgument { get; private set; }
    public static string sbBatchDownloadLoadArgs { get; private set; }
    public static string mBatchDownloaderLoadArgsFromSettings { get; private set; }
    public static string mBatchDownloaderLoadArgsFromArgsTxt { get; private set; }
    public static string mBatchDownloaderLoadArgsFromFile { get; private set; }
    public static string sbBatchDownloaderImportLinks { get; private set; }
    public static string mBatchDownloaderImportLinksFromFile { get; private set; }
    public static string mBatchDownloaderImportLinksFromClipboard { get; private set; }
    public static string sbBatchDownloaderIdle { get; private set; }
    public static string sbBatchDownloaderDownloading { get; private set; }
    public static string sbBatchDownloaderFinished { get; private set; }
    public static string sbBatchDownloaderAborted { get; private set; }
    public static string chkBatchDownloadClipboardScanner { get; private set; }
    #endregion

    #region frmConverter
    public static string frmConverter { get; private set; }
    public static string frmConverterComplete { get; private set; }
    public static string frmConverterError { get; private set; }
    public static string chkConverterCloseAfterConversion { get; private set; }
    public static string btnConverterAbortBatchConversions { get; private set; }
    #endregion

    #region frmDownloader
    public static string frmDownloader { get; private set; }
    public static string frmDownloaderComplete { get; private set; }
    public static string frmDownloaderError { get; private set; }
    public static string chkDownloaderCloseAfterDownload { get; private set; }
    public static string btnDownloaderAbortBatch { get; private set; }
    #endregion

    #region frmDownloadLanguage
    public static string frmDownloadLanguage { get; private set; }
    #endregion

    #region frmException
    public static string frmException { get; private set; }
    public static string lbExceptionHeader { get; private set; }
    public static string lbExceptionDescription { get; private set; }
    public static string rtbExceptionDetails { get; private set; }
    public static string btnExceptionGithub { get; private set; }
    public static string tabExceptionDetails { get; private set; }
    public static string tabExceptionExtraInfo { get; private set; }
    #endregion

    #region frmExtendedDownloader
    public static string frmExtendedDownloaderRetrieving { get; private set; }
    public static string lbExtendedDownloaderLink { get; private set; }
    public static string lbExtendedDownloaderUploader { get; private set; }
    public static string lbExtendedDownloaderViews { get; private set; }
    public static string lbExtendedDownloaderDownloadingThumbnail { get; private set; }
    public static string lbExtendedDownloaderDownloadingThumbnailFailed { get; private set; }
    public static string btnExtendedDownloaderDownloadThumbnail { get; private set; }
    public static string tabExtendedDownloaderUnknownFormats { get; private set; }
    public static string tabExtendedDownloaderDescription { get; private set; }
    public static string tabExtendedDownloaderVerbose { get; private set; }
    public static string tabExtendedDownloaderFormatOptions { get; private set; }
    public static string chkExtendedDownloaderVideoSeparateAudio { get; private set; }
    public static string lbExtendedDownloaderNoVideoFormatsAvailable { get; private set; }
    public static string lbExtendedDownloaderNoAudioFormatsAvailable { get; private set; }
    public static string lbExtendedDownloaderNoUnknownFormatsFound { get; private set; }
    public static string lbVideoRemux { get; private set; }
    public static string txtExtendedDownloaderMediaTitle { get; private set; }
    public static string txtExtendedDownloaderBatchMediaTitle { get; private set; }
    public static string mExtendedDownloaderEnqueueCopyOptions { get; private set ;}
    public static string mExtendedDownloaderEnqueueWithAuthentication { get; private set; }
    public static string mExtendedDownloaderEnqueueCopyAuthentication { get; private set; }
    public static string mExtendedDownloaderQueueCopyLink { get; private set; }
    public static string mExtendedDownloaderQueueViewInBrowser { get; private set; }
    public static string mExtendedDownloaderEnqueueImportLinksWithAuthentication { get; private set; }
    public static string mExtendedDownloaderEnqueueImportLinksCopyOptions { get; private set; }
    public static string mExtendedDownloaderEnqueueImportLinksCopyAuthentication { get; private set; }
    #endregion

    #region frmLanguage
    public static string frmLanguage { get; private set; }
    public static string btnLanguageRefresh { get; private set; }
    public static string btnLanguageDownload { get; private set; }
    #endregion

    #region frmLog
    public static string frmLog { get; private set; }
    public static string frmLogClear { get; private set; }
    public static string frmLogExceptions { get; private set; }
    public static string lbLogPastExceptions { get; private set; }
    #endregion

    #region frmMain
    public static string mSettings { get; private set; }
    public static string mTools { get; private set; }
    public static string mBatch { get; private set; }
    public static string mBatchDownload { get; private set; }
    public static string mBatchExtendedDownload { get; private set; }
    public static string mBatchConvert { get; private set; }
    public static string mArchiveDownloader { get; private set; }
    public static string mDownloadSubtitles { get; private set; }
    public static string mMiscTools { get; private set; }
    public static string mClipboardAutoDownload { get; private set; }
    public static string mHelp { get; private set; }
    public static string mLanguage { get; private set; }
    public static string mSupportedSites { get; private set; }
    public static string mAbout { get; private set; }

    public static string tabDownload { get; private set; }
    public static string tabConvert { get; private set; }
    public static string tabMerge { get; private set; }

    public static string lbURL { get; private set; }
    public static string txtUrlHint { get; private set; }
    public static string gbDownloadType { get; private set; }
    public static string lbQuality { get; private set; }
    public static string lbFormat { get; private set; }
    public static string chkUseSelection { get; private set; }
    public static string rbVideoSelectionPlaylistIndex { get; private set; }
    public static string rbVideoSelectionPlaylistItems { get; private set; }
    public static string rbVideoSelectionBeforeDate { get; private set; }
    public static string rbVideoSelectionOnDate { get; private set; }
    public static string rbVideoSelectionAfterDate { get; private set; }
    public static string txtPlaylistStartHint { get; private set; }
    public static string txtPlaylistEndHint { get; private set; }
    public static string txtPlaylistItemsHint { get; private set; }
    public static string txtVideoDateHint { get; private set; }
    public static string lbCustomArguments { get; private set; }
    public static string sbDownload { get; private set; }
    public static string mDownloadWithAuthentication { get; private set; }
    public static string mBatchDownloadFromFile { get; private set; }
    public static string mQuickDownloadForm { get; private set; }
    public static string mQuickDownloadFormAuthentication { get; private set; }
    public static string mExtendedDownloadForm { get; private set; }
    public static string mExtendedDownloadFormAuthentication { get; private set; }
    public static string msgBatchDownloadFromFile { get; private set; }
    public static string btnMainExtended { get; private set; }

    public static string lbConvertInput { get; private set; }
    public static string lbConvertOutput { get; private set; }
    public static string rbConvertAuto { get; private set; }
    public static string rbConvertAutoFFmpeg { get; private set; }
    public static string btnConvert { get; private set; }

    public static string cmTrayShowForm { get; private set; }
    public static string cmTrayDownloader { get; private set; }
    public static string cmTrayDownloadClipboard { get; private set; }
    public static string cmTrayDownloadBestVideo { get; private set; }
    public static string cmTrayDownloadBestAudio { get; private set; }
    public static string cmTrayDownloadCustom { get; private set; }
    public static string cmTrayDownloadCustomTxtBox { get; private set; }
    public static string cmTrayDownloadCustomTxt { get; private set; }
    public static string cmTrayDownloadCustomSettings { get; private set; }
    public static string cmTrayConverter { get; private set; }
    public static string cmTrayConvertTo { get; private set; }
    public static string cmTrayConvertVideo { get; private set; }
    public static string cmTrayConvertAudio { get; private set; }
    public static string cmTrayConvertCustom { get; private set; }
    public static string cmTrayConvertAutomatic { get; private set; }
    public static string cmTrayConvertAutoFFmpeg { get; private set; }
    public static string cmTrayExit { get; private set; }
    #endregion

    #region frmMerger
    public static string frmMerger { get; private set; }
    public static string btnMerge { get; private set; }
    public static string frmMergerVideoSources { get; private set; }
    public static string frmMergerAudioSources { get; private set; }
    public static string frmMergerSubtitleSources { get; private set; }
    public static string frmMergerAttatchmentSources { get; private set; }
    #endregion

    #region frmSettings
    public static string frmSettings { get; private set; }

    public static string tabSettingsGeneral { get; private set; }
    public static string tabSettingsDownloads { get; private set; }
    public static string tabSettingsConverter { get; private set; }
    public static string tabSettingsExtensions { get; private set; }
    public static string tabSettingsErrors { get; private set; }

    public static string btnSettingsCancelHint { get; private set; }
    public static string btnSettingsSaveHint { get; private set; }

    #region General
    public static string tabSettingsGeneralYoutubeDl { get; private set; }
    public static string lbSettingsGeneralYoutubeDlPath { get; private set; }
    public static string lbSettingsGeneralYoutubeDlPathHint { get; private set; }
    public static string chkSettingsGeneralUseStaticYoutubeDl { get; private set; }
    public static string chkSettingsGeneralUseStaticYoutubeDlHint { get; private set; }
    public static string txtSettingsGeneralYoutubeDlPathHint { get; private set; }
    public static string btnSettingsGeneralBrowseYoutubeDlHint { get; private set; }
    public static string btnSettingsRedownloadYoutubeDl { get; private set; }
    public static string btnSettingsRedownloadYoutubeDlHint { get; private set; }
    public static string ofdTitleYoutubeDl { get; private set; }
    public static string ofdFilterYoutubeDl { get; private set; }

    public static string tabSettingsGeneralFfmpeg { get; private set; }
    public static string lbSettingsGeneralFFmpegDirectory { get; private set; }
    public static string lbSettingsGeneralFFmpegDirectoryHint { get; private set; }
    public static string chkSettingsGeneralUseStaticFFmpeg { get; private set; }
    public static string chkSettingsGeneralUseStaticFFmpegHint { get; private set; }
    public static string txtSettingsGeneralFFmpegPathHint { get; private set; }
    public static string btnSettingsGeneralBrowseFFmpegHint { get; private set; }
    public static string btnSettingsRedownloadFfmpeg { get; private set; }
    public static string btnSettingsRedownloadFfmpegHint { get; private set; }
    public static string ofdTitleFFmpeg { get; private set; }
    public static string ofdFilterFFmpeg { get; private set; }


    public static string chkSettingsGeneralCheckForUpdatesOnLaunch { get; private set; }
    public static string chkSettingsGeneralCheckForUpdatesOnLaunchHint { get; private set; }
    public static string chkSettingsGeneralCheckForBetaUpdates { get; private set; }
    public static string chkSettingsGeneralCheckForBetaUpdatesHint { get; private set; }
    public static string chkSettingsGeneralDeleteUpdaterAfterUpdating { get; private set; }
    public static string chkSettingsGeneralDeleteUpdaterAfterUpdatingHint { get; private set; }
    public static string chkDeleteOldVersionAfterUpdating { get; private set; }
    public static string chkDeleteOldVersionAfterUpdatingHint { get; private set; }
    public static string chkSettingsGeneralHoverOverUrlToPasteClipboard { get; private set; }
    public static string chkSettingsGeneralHoverOverUrlToPasteClipboardHint { get; private set; }
    public static string chkSettingsGeneralClearUrlOnDownload { get; private set; }
    public static string chkSettingsGeneralClearUrlOnDownloadHint { get; private set; }
    public static string chkSettingsGeneralClearClipboardOnDownload { get; private set; }
    public static string chkSettingsGeneralClearClipboardOnDownloadHint { get; private set; }
    public static string chkSettingsGeneralAutoUpdateYoutubeDl { get; private set; }
    public static string chkSettingsGeneralAutoUpdateYoutubeDlHint { get; private set; }
    public static string gbSettingsGeneralCustomArguments { get; private set; }
    public static string gbSettingsGeneralCustomArgumentsHint { get; private set; }
    public static string rbSettingsGeneralCustomArgumentsDontSave { get; private set; }
    public static string rbSettingsGeneralCustomArgumentsDontSaveHint { get; private set; }
    public static string rbSettingsGeneralCustomArgumentsSaveAsArgsText { get; private set; }
    public static string rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint { get; private set; }
    public static string rbSettingsGeneralCustomArgumentsSaveInSettings { get; private set; }
    public static string rbSettingsGeneralCustomArgumentsSaveInSettingsHint { get; private set; }
    #endregion

    #region Downloads
    public static string chkSettingsDownloadsDownloadPathUseRelativePathHint { get; private set; }
    public static string lbSettingsDownloadsDownloadPath { get; private set; }
    public static string lbSettingsDownloadsDownloadPathHint { get; private set; }
    public static string txtSettingsDownloadsSavePathHint { get; private set; }
    public static string btnSettingsDownloadsBrowseSavePathHint { get; private set; }
    public static string lbSettingsDownloadsFileNameSchema { get; private set; }
    public static string lbSettingsDownloadsFileNameSchemaHint { get; private set; }
    public static string llSettingsDownloadsSchemaHelpHint { get; private set; }
    public static string txtSettingsDownloadsFileNameSchemaHint { get; private set; }
    public static string btnSettingsDownloadsFileNameSchemaHistory { get; private set; }
    public static string btnSettingsDownloadsFileNameSchemaHistoryHint { get; private set; }

    public static string btnSettingsDownloadsInstallProtocolNotInstalled { get; private set; }
    public static string btnSettingsDownloadsInstallProtocolInstalled { get; private set; }
    public static string btnSettingsDownloadsInstallProtocolHint { get; private set; }

    #region General
    public static string tabDownloadsGeneral { get; private set; }

    public static string chkSettingsDownloadsSaveFormatQuality { get; private set; }
    public static string chkSettingsDownloadsSaveFormatQualityHint { get; private set; }
    public static string chkSettingsDownloadsDownloadSubtitles { get; private set; }
    public static string chkSettingsDownloadsDownloadSubtitlesHint { get; private set; }
    public static string chkSettingsDownloadsEmbedSubtitles { get; private set; }
    public static string chkSettingsDownloadsEmbedSubtitlesHint { get; private set; }
    public static string chkSettingsDownloadsSaveVideoInfo { get; private set; }
    public static string chkSettingsDownloadsSaveVideoInfoHint { get; private set; }
    public static string chkSettingsDownloadsWriteMetadataToFile { get; private set; }
    public static string chkSettingsDownloadsWriteMetadataToFileHint { get; private set; }
    public static string chkSettingsDownloadsSaveDescription { get; private set; }
    public static string chkSettingsDownloadsSaveDescriptionHint { get; private set; }
    public static string chkSettingsDownloadsKeepOriginalFiles { get; private set; }
    public static string chkSettingsDownloadsKeepOriginalFilesHint { get; private set; }
    public static string chkSettingsDownloadsSaveAnnotations { get; private set; }
    public static string chkSettingsDownloadsSaveAnnotationsHint { get; private set; }
    public static string chkSettingsDownloadsSaveThumbnails { get; private set; }
    public static string chkSettingsDownloadsSaveThumbnailsHint { get; private set; }
    public static string chkSettingsDownloadsEmbedThumbnails { get; private set; }
    public static string chkSettingsDownloadsEmbedThumbnailsHint { get; private set; }
    public static string chkSettingsDownloadsSkipUnavailableFragments { get; private set; }
    public static string chkSettingsDownloadsSkipUnavailableFragmentsHint { get; private set; }
    public static string chkSettingsDownloadsAbortOnError { get; private set; }
    public static string chkSettingsDownloadsAbortOnErrorHint { get; private set; }
    #endregion

    #region Sorting
    public static string tabDownloadsSorting { get; private set; }

    public static string chkSettingsDownloadsSeparateDownloadsToDifferentFolders { get; private set; }
    public static string chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint { get; private set; }
    public static string chkSettingsDownloadsSeparateIntoWebsiteUrl { get; private set; }
    public static string chkSettingsDownloadsSeparateIntoWebsiteUrlHint { get; private set; }
    public static string chkSettingsDownloadsWebsiteSubdomains { get; private set; }
    public static string chkSettingsDownloadsWebsiteSubdomainsHint { get; private set; }
    #endregion

    #region Fixes
    public static string tabDownloadsFixes { get; private set; }

    public static string chkSettingsDownloadsFixVReddIt { get; private set; }
    public static string chkSettingsDownloadsFixVReddItHint { get; private set; }
    public static string chkSettingsDownloadsPreferFFmpeg { get; private set; }
    public static string chkSettingsDownloadsPreferFFmpegHint { get; private set; }
    #endregion

    #region Connection
    public static string tabDownloadsConnection { get; private set; }

    public static string chkSettingsDownloadsLimitDownload { get; private set; }
    public static string chkSettingsDownloadsLimitDownloadHint { get; private set; }
    public static string numSettingsDownloadsLimitDownloadHint { get; private set; }
    public static string cbSettingsDownloadsLimitDownloadHint { get; private set; }
    public static string lbSettingsDownloadsRetryAttempts { get; private set; }
    public static string lbSettingsDownloadsRetryAttemptsHint { get; private set; }
    public static string numSettingsDownloadsRetryAttemptsHint { get; private set; }
    public static string chkSettingsDownloadsForceIpv4 { get; private set; }
    public static string chkSettingsDownloadsForceIpv4Hint { get; private set; }
    public static string chkSettingsDownloadsForceIpv6 { get; private set; }
    public static string chkSettingsDownloadsForceIpv6Hint { get; private set; }
    public static string chkSettingsDownloadsUseProxy { get; private set; }
    public static string chkSettingsDownloadsUseProxyHint { get; private set; }
    public static string cbSettingsDownloadsProxyTypeHint { get; private set; }
    public static string txtSettingsDownloadsProxyIpHint { get; private set; }
    public static string txtSettingsDownloadsProxyPortHint { get; private set; }
    public static string lbSettingsDownloadsFragmentThreads { get; private set; }
    public static string lbSettingsDownloadsFragmentThreadsHint { get; private set; }
    #endregion

    #region Updating
    public static string tabDownloadsUpdating { get; private set; }

    public static string chkSettingsDownloadsUseYoutubeDlsUpdater { get; private set; }
    public static string chkSettingsDownloadsUseYoutubeDlsUpdaterHint { get; private set; }
    public static string lbSettingsDownloadsUpdatingYtdlType { get; private set; }
    public static string cbSettingsDownloadsUpdatingYtdlTypeHint { get; private set; }
    public static string llbSettingsDownloadsYtdlTypeViewRepo { get; private set; }
    public static string llbSettingsDownloadsYtdlTypeViewRepoHint { get; private set; }
    public static string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing { get; private set; }
    public static string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint { get; private set; }
    #endregion

    #region Batch
    public static string tabDownloadsBatch { get; private set; }

    public static string chkSettingsDownloadsSeparateBatchDownloads { get; private set; }
    public static string chkSettingsDownloadsSeparateBatchDownloadsHint { get; private set; }
    public static string chkSettingsDownloadsAddDateToBatchDownloadFolders { get; private set; }
    public static string chkSettingsDownloadsAddDateToBatchDownloadFoldersHint { get; private set; }
    #endregion

    #region Extended downloader
    public static string tabExtendedOptions { get; private set; }

    public static string chkExtendedPreferExtendedDialog { get; private set; }
    public static string chkExtendedPreferExtendedDialogHint { get; private set; }
    public static string chkExtendedAutomaticallyDownloadThumbnail { get; private set; }
    public static string chkExtendedAutomaticallyDownloadThumbnailHint { get; private set; }
    public static string chkExtendedIncludeCustomArguments { get; private set;}
    public static string chkExtendedIncludeCustomArgumentsHint { get; private set; }
    #endregion

    #endregion

    #region Converter
    public static string chkSettingsConverterClearOutputAfterConverting { get; private set; }
    public static string chkSettingsConverterClearOutputAfterConvertingHint { get; private set; }
    public static string chkSettingsConverterDetectOutputFileType { get; private set; }
    public static string chkSettingsConverterDetectOutputFileTypeHint { get; private set; }
    public static string chkSettingsConverterClearInputAfterConverting { get; private set; }
    public static string chkSettingsConverterClearInputAfterConvertingHint { get; private set; }
    public static string chkSettingsConverterHideFFmpegCompileInfo { get; private set; }
    public static string chkSettingsConverterHideFFmpegCompileInfoHint { get; private set; }

    public static string tcSettingsConverterVideo { get; private set; }
    public static string lbSettingsConverterVideoBitrate { get; private set; }
    public static string lbSettingsConverterVideoBitrateHint { get; private set; }
    public static string lbSettingsConverterVideoPreset { get; private set; }
    public static string lbSettingsConverterVideoPresetHint { get; private set; }
    public static string lbSettingsConverterVideoProfile { get; private set; }
    public static string lbSettingsConverterVideoProfileHint { get; private set; }
    public static string lbSettingsConverterVideoCRF { get; private set; }
    public static string lbSettingsConverterVideoCRFHint { get; private set; }
    public static string chkSettingsConverterVideoFastStart { get; private set; }
    public static string chkSettingsConverterVideoFastStartHint { get; private set; }

    public static string tcSettingsConverterAudio { get; private set; }
    public static string lbSettingsConverterAudioBitrate { get; private set; }
    public static string lbSettingsConverterAudioBitrateHint { get; private set; }

    public static string tcSettingsConverterCustom { get; private set; }
    public static string lbSettingsConverterCustomHeader { get; private set; }
    public static string txtSettingsConverterCustomArgumentsHint { get; private set; }
    #endregion

    #region Extensions
    public static string lbSettingsExtensionsHeader { get; private set; }
    public static string lbSettingsExtensionsExtensionFullName { get; private set; }
    public static string txtSettingsExtensionsExtensionFullName { get; private set; }
    public static string lbSettingsExtensionsExtensionShort { get; private set; }
    public static string txtSettingsExtensionsExtensionShort { get; private set; }
    public static string btnSettingsExtensionsAdd { get; private set; }
    public static string lbSettingsExtensionsFileName { get; private set; }
    public static string btnSettingsExtensionsRemoveSelected { get; private set; }
    #endregion

    #region Errors
    public static string chkSettingsErrorsShowDetailedErrors { get; private set; }
    public static string chkSettingsErrorsShowDetailedErrorsHint { get; private set; }
    public static string chkSettingsErrorsSaveErrorsAsErrorLog { get; private set; }
    public static string chkSettingsErrorsSaveErrorsAsErrorLogHint { get; private set; }
    public static string chkSettingsErrorsSuppressErrors { get; private set; }
    public static string chkSettingsErrorsSuppressErrorsHint { get; private set; }
    #endregion
    #endregion

    #region frmSubtitles
    public static string frmSubtitles { get; private set; }
    public static string lbSubtitlesHeader { get; private set; }
    public static string lbSubtitlesUrl { get; private set; }
    public static string lbSubtitlesLanguages { get; private set; }
    public static string btnSubtitlesAddLanguage { get; private set; }
    public static string btnSubtitlesClearLanguages { get; private set; }
    public static string btnSubtitlesDownload { get; private set; }
    #endregion

    #region frmTools
    public static string frmTools { get; private set; }
    public static string btnMiscToolsRemoveAudio { get; private set; }
    public static string btnMiscToolsExtractAudio { get; private set; }
    public static string btnMiscToolsVideoToGif { get; private set; }
    #endregion

    #region frmUpdateAvailable
    public static string frmUpdateAvailable { get; private set; }
    public static string lbUpdateAvailableHeader { get; private set; }
    public static string lbUpdateAvailableUpdateVersion { get; private set; }
    public static string lbUpdateAvailableCurrentVersion { get; private set; }
    public static string lbUpdateAvailableChangelog { get; private set; }
    public static string lbUpdateSize { get; private set; }
    public static string btnUpdateAvailableSkipVersion { get; private set; }
    public static string btnUpdateAvailableUpdate { get; private set; }
    #endregion
    #endregion

    #region Internal English
    /// <summary>
    /// Contains all English strings internally.
    /// </summary>
    public static class InternalEnglish {
        // Language identifier
        public const string CurrentLanguageLong = "English (Internal)";
        public const string CurrentLanguageShort = "en-i";
        public const string CurrentLanguageHint = "Click here to change";
        public const string CurrentLanguageVersion = "1";

        #region Generics
        public const string GenericInputBest = "best";
        public const string GenericInputWorst = "worst";
        public const string GenericCancel = "Cancel";
        public const string GenericSkip = "Skip";
        public const string GenericSound = "Sound";
        public const string GenericVideo = "Video";
        public const string GenericAudio = "Audio";
        public const string GenericCustom = "Custom";
        public const string GenericRetry = "Retry";
        public const string GenericStart = "Start";
        public const string GenericStop = "Stop";
        public const string GenericExit = "Exit";
        public const string GenericOk = "OK";
        public const string GenericSave = "Save";
        public const string GenericAdd = "Add";
        public const string GenericClose = "Close";
        public const string GenericClear = "Clear";
        public const string GenericRemoveSelected = "Remove selected";
        public const string GenericVerifyLinks = "Verify copied links";
        public const string GenericDoNotReEncode = "(Do not re-encode)";
        public const string GenericDoNotRemux = "(Do not remux)";
        public const string GenericDoNotDownload = "(Do not download)";
        public const string GenericUnknownFormat = "Unknown format";
        public const string GenericMoreInfo = "More info";
        public const string GenericTitle = "Title";
        public const string GenericLength = "Length";
        public const string GenericUploadedOn = "Uploaded on";
        public const string GenericInput = "Input";
        public const string GenericOutput = "Output";
        public const string GenericArguments = "Arguments";
        public const string GenericAborted = "Aborted";
        public const string GenericError = "Error";
        public const string GenericAltError = "{0} error";
        public const string GenericCompleted = "Completed";
        public const string GenericRemove = "Remove";

        public const string frmGenericDownloadProgress = "Downloading...";
        public const string chContainer = "Container";
        public const string chFileSize = "File size";
        public const string chFormatId = "ID";
        public const string chVideoQuality = "Quality";
        public const string chVideoFPS = "FPS";
        public const string chVideoBitrate = "Video bitrate";
        public const string chVideoDimension = "Video dimensions";
        public const string chVideoCodec = "Video codec";
        public const string chAudioBitrate = "Audio bitrate";
        public const string chAudioSampleRate = "Audio sample rate";
        public const string chAudioCodec = "Audio codec";
        public const string chAudioChannels = "Audio channels";
        public const string dlBeginningDownload = "Beginning download";
        public const string cvBeginningConversion = "Beginning conversion";
        #endregion

        #region Dialogs
        public const string dlgFirstTimeInitialMessage = "youtube-dl-gui is a visual extension to youtube-dl and is not affiliated with the developers of youtube-dl in any way.\n\nThis program (and I) does not condone piracy or illegally downloading of any video you do not own the rights to or is not in public domain.\n\nAny help regarding any problems when downloading anything illegal (in my jurisdiction) will be ignored. This message will not appear again.\n\nHave you read the above?";
        public const string dlgFirstTimeDownloadFolder = "Downloads are saved to your downloads folder by default, would you like to specify a different location now?\n(You can change this in the settings at any time)";
        public const string dlgFirstTimeDownloadYoutubeDl = "Would you like to download youtube-dl? You can do this manually in the settings if you do not wish to do it now.\n\n* yt-dlp will be the default fork used.\n* If youtube-dl exists in a known context (current directory, system path, etc...) it will update that instead if an update is required.";
        public const string dlgFirstTimeDownloadFfmpeg = "Would you like to download ffmpeg? You can do this manually in the settings if you do not wish to do it now.\n\n* If ffmpeg exists in a known context (current directory, system path, etc...) it will automatically replace it with the latest version.";

        public const string dlgClipboardAutoDownloadNotice = "Using the clipboard auto downloader will automatically attempt to download verified links from the clipboard using the selected settings on the main form. Please do not copy any sensitive information while this option is enabled, ever.";
        public const string dlgBatchDownloadClipboardScannerNotice = "Enabling this option will add anything from your clipboard when something is copied (link or not). It will need to be manually enabled per-converter instance. Take care to not copy any sensitive information to the cipboard.";

        public const string dlgFindDownloadFolder = "Select a directory to save downloads to...";
        public const string dlgMainArgsTxtDoesntExist = "args.txt does not exist, create it and put in arguments to use this command";
        public const string dlgMainArgsTxtIsEmpty = "args.txt is empty, save arguments to the file to use this command";
        public const string dlgMainArgsNoneSaved = "No arguments are saved in the application settings, save arguments to the settings to use this command";
        public const string dlgConvertSelectFileToConvert = "Select a file to convert...";
        public const string dlgMergeSelectFileToMerge = "Select a file to merge...";
        public const string dlgSaveOutputFileAs = "Save the output file as...";
        public const string dlgLanguageHashNoMatch = "The langauge file hash doesn't match. This isn't very important since it's not important to the runtime of the program, but your language may be wrong.";

        public const string dlgAuthenticationCookiesFromBrowser = "The name of the browser to load cookies from. It can optionally include a keyring, browser profile, and/or container (using Firefox). From the yt-dlp readme - BROWSER[+KEYRING][:PROFILE][::CONTAINER]\\n\\nCurrently supported browsers are: brave, chrome, chromium, edge, firefox, opera, safari, vivaldi.\\nOptionally, the KEYRING used for decrypting Chromium cookies on Linux, the name/path of the PROFILE to load cookies from, and the CONTAINER name (if Firefox) (\"none\" for no container) can be given with their respective seperators.\\nBy default, all containers of the most recently accessed profile are used.\\nCurrently supported keyrings are: basictext, gnomekeyring, kwallet";

        public const string dlgUpdateFailedToCheck = "The update check has failed. Would you like to manually check?";
        public const string dlgUpdateNoUpdateAvailable = "No updates available.\r\n\r\nCurrent version: {0}\r\nLatest version: {1}";
        public const string dlgUpdateNoBetaUpdateAvailable = "No beta updates available.\r\n\r\nCurrent version: {0}\r\nNewest version: {1}";
        public const string dlgUpdateNoValidYoutubeDl = "Could not find a valid youtube-dl to download or update.";
        public const string dlgUpdatedYoutubeDl = "Youtube-dl has been updated.";
        public const string dlgUpateYoutubeDlNoUpdateRequired = "Youtube-dl does not require an update at this moment.\r\n\r\nCurrent version: {0}\r\nLatest release: {1}";
        public const string dlgUpdaterHashNoMatch = "The hash of the updater does not match the internally known hash. It might still work but yknow. Update anyways?";

        public const string frmFileNameSchemaHistory = "File name schema history editor";
        #endregion

        #region Shared downloading
        public const string pbDownloadProgressFfmpegPostProcessing = "Post-processing in ffmpeg...";
        public const string pbDownloadProgressEmbeddingSubtitles = "Emedding subtitles...";
        public const string pbDownloadProgressEmbeddingMetadata = "Emedding metadata...";
        public const string pbDownloadProgressMergingFormats = "Merging formats...";
        public const string pbDownloadProgressConverting = "Converting media...";
        #endregion

        #region frmAbout
        public const string frmAbout = "About";
        public const string lbAboutBody = "youtube-dl-gui by {0}\ndebug date {1}\nReport any issues to the Github repo";
        public const string llbCheckForUpdates = "Check for updates";
        #endregion

        #region frmArchiveDownloader
        public const string frmArchiveDownloader = "Archive downloader";
        public const string lbArchiveDownloaderDescription = "This will download any removed youtube video, if it was archived before removal.";
        public const string txtArchiveDownloaderHint = "Enter the youtube URL or video id";
        #endregion

        #region frmAuthentication
        public const string frmAuthentication = "Authentication";

        public const string lbAuthNotice = "Enter your authentication information:";

        public const string lbAuthUsername = "Username";
        public const string lbAuthPassword = "Password";
        public const string lbAuth2Factor = "2-Factor";
        public const string lbAuthVideoPassword = "Video password";
        public const string chkAuthUseNetrc = "Use .netrc for authentication";
        public const string lbAuthCookiesFromFile = "Cookies from file";
        public const string lbAuthCookiesFromBrowser = "Cookies from browser";

        public const string lbAuthNoSave = "Your information will not be saved for security reasons.";

        public const string btnAuthBeginDownload = "Begin download";
        #endregion

        #region frmBatchConverter
        public const string frmBatchConverter = "Batch converter";
        public const string lbBatchConverterInput = "Input file";
        public const string txtBatchConverterInputFile = "File to be converted...";
        public const string lbBatchConverterOutput = "Output file";
        public const string txtBatchConverterOutputFile = "File to be created...";
        public const string txtBatchConverterCustomConversionArguments = "Custom arguments (Leave empty for defaults)";
        public const string sbBatchConverterIdle = "Waiting for batch conversion to start";
        public const string sbBatchConverterConverting = "Batch conversion in progress...";
        public const string sbBatchConverterFinished = "Batch conversion finished. Add more items to start another batch, or exit";
        public const string sbBatchConverterAborted = "The batch conversion has been aborted";
        #endregion

        #region frmBatchDownloader
        // frmBatch
        public const string frmBatchDownload = "Batch downloader";
        public const string lbBatchDownloadLink = "Download link";
        public const string lbBatchDownloadType = "Download type";
        public const string lbBatchDownloadVideoSpecificArgument = "Video-specific argument";
        public const string sbBatchDownloadLoadArgs = "Load args";
        public const string mBatchDownloaderLoadArgsFromSettings = "Load args from settings";
        public const string mBatchDownloaderLoadArgsFromArgsTxt = "Load args from ./args.txt";
        public const string mBatchDownloaderLoadArgsFromFile = "Load args from file...";
        public const string sbBatchDownloaderImportLinks = "Import links...";
        public const string mBatchDownloaderImportLinksFromFile = "Import links from a file";
        public const string mBatchDownloaderImportLinksFromClipboard = "Import links from the clipboard";
        public const string sbBatchDownloaderIdle = "Waiting for batch download start";
        public const string sbBatchDownloaderDownloading = "Batch download in progress...";
        public const string sbBatchDownloaderFinished = "Batch download finished. Add more items to start another batch, or exit";
        public const string sbBatchDownloaderAborted = "The batch download has been aborted";
        public const string chkBatchDownloadClipboardScanner = "Scan clipboard";
        #endregion

        #region frmConverter
        public const string frmConverter = "Converting";
        public const string frmConverterComplete = "Conversion finished";
        public const string frmConverterError = "Error converting";
        public const string chkConverterCloseAfterConversion = "Close after converting";
        public const string btnConverterAbortBatchConversions = "Abort batch conversions";
        #endregion

        #region frmDownloader
        public const string frmDownloader = "Downloading";
        public const string frmDownloaderComplete = "Download finished";
        public const string frmDownloaderError = "Error downloading";
        public const string chkDownloaderCloseAfterDownload = "Close after download";
        public const string btnDownloaderAbortBatch = "Abort batch download";
        #endregion

        // frmDownloadLanguage
        public const string frmDownloadLanguage = "Download a language file...";

        #region frmException
        // frmException
        public const string frmException = "An exception occured";
        public const string lbExceptionHeader = "An exception has occured";
        public const string lbExceptionDescription = "Below is the error that occured. Feel free to open a new issue and report it.";
        public const string rtbExceptionDetails = "Feel free to copy + paste this entire text wall into a new issue on Github";
        public const string btnExceptionGithub = "Github";
        public const string tabExceptionDetails = "Exception details";
        public const string tabExceptionExtraInfo = "Extra info";
        #endregion

        #region frmExtendedDownloader
        public const string frmExtendedDownloaderRetrieving = "Retrieving data... - {0}";
        public const string lbExtendedDownloaderLink = "Link";
        public const string lbExtendedDownloaderUploader = "Uploader";
        public const string lbExtendedDownloaderViews = "Views";
        public const string lbExtendedDownloaderDownloadingThumbnail = "Downloading thumbnail...";
        public const string lbExtendedDownloaderDownloadingThumbnailFailed = "Unable to download thumbnail";
        public const string btnExtendedDownloaderDownloadThumbnail = "Get thumbnail";
        public const string tabExtendedDownloaderUnknownFormats = "Unknown formats";
        public const string tabExtendedDownloaderDescription = "Description";
        public const string tabExtendedDownloaderVerbose = "Verbose";
        public const string tabExtendedDownloaderFormatOptions = "Format download options";
        public const string chkExtendedDownloaderVideoSeparateAudio = "Separate audio from video";
        public const string lbExtendedDownloaderNoVideoFormatsAvailable = "No video formats are available.";
        public const string lbExtendedDownloaderNoAudioFormatsAvailable = "No audio formats are available.";
        public const string lbExtendedDownloaderNoUnknownFormatsFound = "No unknown formats were found.";
        public const string lbVideoRemux = "Video remux";
        public const string txtExtendedDownloaderMediaTitle = "Retrieving media information...";
        public const string txtExtendedDownloaderBatchMediaTitle = "Select an item to view the details";
        public const string mExtendedDownloaderEnqueueCopyOptions = "Add (Copy selected options)";
        public const string mExtendedDownloaderEnqueueWithAuthentication = "Add (Authenticate)";
        public const string mExtendedDownloaderEnqueueCopyAuthentication = "Add (Copy selected auth)";
        public const string mExtendedDownloaderQueueCopyLink = "Copy link";
        public const string mExtendedDownloaderQueueViewInBrowser = "View in browser";
        public const string mExtendedDownloaderEnqueueImportLinksWithAuthentication = "Import with authentication";
        public const string mExtendedDownloaderEnqueueImportLinksCopyOptions = "Import and copy selected item options";
        public const string mExtendedDownloaderEnqueueImportLinksCopyAuthentication = "Import and copy select item auth";
        #endregion

        #region frmLanguage
        public const string frmLanguage = "Language select";
        public const string btnLanguageRefresh = "Refresh";
        public const string btnLanguageDownload = "Download...";
        #endregion

        #region frmLog
        public const string frmLog = "Log";
        public const string frmLogClear = "Clear";
        public const string frmLogExceptions = "Exceptions";
        public const string lbLogPastExceptions = "Past exceptions will appear here";
        #endregion

        #region frmMain
        // frmMain
        public const string frmMain = "youtube-dl-gui";
        // frmMain / menu
        public const string mSettings = "Settings";
        public const string mTools = "Tools";
        public const string mBatch = "Batch operations";
        public const string mBatchDownload = "Batch download...";
        public const string mBatchExtendedDownload = "Batch extended download...";
        public const string mBatchConvert = "Batch convert...";
        public const string mDownloadSubtitles = "Download subtitles...";
        public const string mArchiveDownloader = "Archive downloader...";
        public const string mMiscTools = "Misc tools...";
        public const string mClipboardAutoDownload = "Clipboard auto download";
        public const string mHelp = "Help";
        public const string mLanguage = "Language...";
        public const string mSupportedSites = "Supported sites...";
        public const string mAbout = "About";
        // frmMain / tcMain
        public const string tabDownload = "Download";
        public const string tabConvert = "Convert";
        public const string tabMerge = "Merge";
        // frmMain / tcMain / Download
        public const string lbURL = "URL";
        public const string txtUrlHint = "Video URL";
        public const string gbDownloadType = "Download type";
        public const string rbVideo = "Video";
        public const string rbAudio = "Audio";
        public const string rbCustom = "Custom";
        public const string lbQuality = "Quality";
        public const string lbFormat = "Format";
        public const string chkUseSelection = "Video Selection";
        public const string rbVideoSelectionPlaylistIndex = "Playlist index";
        public const string rbVideoSelectionPlaylistItems = "Playlist items";
        public const string rbVideoSelectionBeforeDate = "Before date";
        public const string rbVideoSelectionOnDate = "On date";
        public const string rbVideoSelectionAfterDate = "After date";
        public const string txtPlaylistStartHint = "Start index";
        public const string txtPlaylistEndHint = "End index";
        public const string txtPlaylistItemsHint = "Video indexes (separated by commas)";
        public const string txtVideoDateHint = "Date (YYYYMMDD)";
        public const string lbCustomArguments = "Custom arguments";
        public const string sbDownload = "Download";
        public const string btnMainExtended = "Details...";
        public const string mDownloadWithAuthentication = "Download with authentication...";
        public const string msgBatchDownloadFromFile = "Create a text file and put all the video links you want to download into it, separated as one per line.\nDo you want to skip seeing this message when batch downloading using this option?";
        public const string mBatchDownloadFromFile = "Batch download from file...";
        public const string mQuickDownloadForm = "Quick download";
        public const string mQuickDownloadFormAuthentication = "Quick download (authenticate)";
        public const string mExtendedDownloadForm = "Extended download...";
        public const string mExtendedDownloadFormAuthentication = "Extended download (authenticate)...";
        // frmMain / tcMain / Convert
        public const string lbConvertInput = "Input";
        public const string lbConvertOutput = "Output";
        public const string rbConvertVideo = "Video";
        public const string rbConvertAudio = "Audio";
        public const string rbConvertCustom = "Custom";
        public const string rbConvertAuto = "Automatic";
        public const string rbConvertAutoFFmpeg = "Auto ffmpeg";
        public const string btnConvert = "Convert";
        // frmMain / tcMain / cmTray
        public const string cmTrayShowForm = "Show form";
        public const string cmTrayDownloader = "Downloader...";
        public const string cmTrayDownloadClipboard = "From clipboard...";
        public const string cmTrayDownloadBestVideo = "Download best video";
        public const string cmTrayDownloadBestAudio = "Download best audio";
        public const string cmTrayDownloadCustom = "Download custom...";
        public const string cmTrayDownloadCustomTxtBox = "From form textbox";
        public const string cmTrayDownloadCustomTxt = "From ./args.txt";
        public const string cmTrayDownloadCustomSettings = "From settings";
        public const string cmTrayConverter = "Converter...";
        public const string cmTrayConvertTo = "Conver to...";
        public const string cmTrayConvertVideo = "Video";
        public const string cmTrayConvertAudio = "Audio";
        public const string cmTrayConvertCustom = "Custom";
        public const string cmTrayConvertAutomatic = "Automatic";
        public const string cmTrayConvertAutoFFmpeg = "Auto ffmpeg";
        public const string cmTrayExit = "Exit";
        #endregion

        #region frmMerger
        public const string frmMerger = "Media merger";
        public const string btnMerge = "Merge";
        public const string frmMergerVideoSources = "Video sources";
        public const string frmMergerAudioSources = "Audio sources";
        public const string frmMergerSubtitleSources = "Subtitle sources";
        public const string frmMergerAttatchmentSources = "Attatchment sources";
        #endregion

        #region frmSettings
        public const string frmSettings = "youtube-dl-gui settings";
        public const string btnSettingsCancelHint = "Discard any changed settings";
        public const string btnSettingsSaveHint = "Save all configured settings";

        #region tabGeneral
        //frmSettings / tcMain / tabGeneral
        public const string tabSettingsGeneral = "General";

        public const string tabSettingsGeneralYoutubeDl = "youtube-dl";
        public const string lbSettingsGeneralYoutubeDlPath = "youtube-dl path";
        public const string lbSettingsGeneralYoutubeDlPathHint = "Static youtube-dl directory\n\nStatic youtube-dl means youtube-dl will always be located in that one directory.";
        public const string chkSettingsGeneralUseStaticYoutubeDl = "Use static youtube-dl";
        public const string chkSettingsGeneralUseStaticYoutubeDlHint = "Use a static placed youtube-dl.exe file";
        public const string txtSettingsGeneralYoutubeDlPathHint = "The path of youtube-dl where it won't be moved";
        public const string btnSettingsGeneralBrowseYoutubeDlHint = "Browse for a new folder where you'll store youtube-dl";
        public const string btnSettingsRedownloadYoutubeDl = "(re)download youtube-dl";
        public const string btnSettingsRedownloadYoutubeDlHint = "Downloads or updates youtube-dl to the known path of youtube-dl if one is known; otherwise, the same directory as the program.\n\nIf the path to youtube-dl is not accessible or writeable by this program, the download will fail.";
        public const string ofdTitleYoutubeDl = "Select youtube-dl";
        public const string ofdFilterYoutubeDl = "youtube-dl executable";


        public const string tabSettingsGeneralFfmpeg = "ffmpeg";
        public const string lbSettingsGeneralFFmpegDirectory = "ffmpeg directory";
        public const string lbSettingsGeneralFFmpegDirectoryHint = "Static ffmpeg directory\n\nStatic ffmpeg means ffmpeg will always be located in that one directory.";
        public const string chkSettingsGeneralUseStaticFFmpeg = "Use static ffmpeg";
        public const string chkSettingsGeneralUseStaticFFmpegHint = "Use a static placed ffmpeg.exe and ffprobe.exe files";
        public const string txtSettingsGeneralFFmpegPathHint = "The path of ffmpeg where it won't be moved";
        public const string btnSettingsGeneralBrowseFFmpegHint = "Browse for a new folder where you'll store ffmpeg";
        public const string btnSettingsRedownloadFfmpeg = "(re)download ffmpeg";
        public const string btnSettingsRedownloadFfmpegHint = "Downloads the latest version of ffmpeg and extracts it to the path to ffmpeg if one is known; otherwise, the same directory as the program.\n\nIf the path to ffmpeg is not accessible or writeable by this program, the download will fail.";
        public const string ofdTitleFFmpeg = "Select ffmpeg.exe and ffprobe.exe";
        public const string ofdFilterFFmpeg = "ffmpeg and ffprobe executable";


        public const string chkSettingsGeneralCheckForUpdatesOnLaunch = "Check for updates on launch";
        public const string chkSettingsGeneralCheckForUpdatesOnLaunchHint = "Check for updates on launch of youtube-dl-gui";
        public const string chkSettingsGeneralCheckForBetaUpdates = "Check for beta updates";
        public const string chkSettingsGeneralCheckForBetaUpdatesHint = "Checks for beta updates instead of regular updates";
        public const string chkSettingsGeneralDeleteUpdaterAfterUpdating = "Delete updater after updating";
        public const string chkSettingsGeneralDeleteUpdaterAfterUpdatingHint = "Deletes the youtube-dl-gui updater when it successfully updates.";
        public const string chkDeleteOldVersionAfterUpdating = "Delete old version after updating";
        public const string chkDeleteOldVersionAfterUpdatingHint = "Deletes the old version of youtube-dl-gui when it successfully updates.";
        public const string chkSettingsGeneralHoverOverUrlToPasteClipboard = "Hover over URL to paste clipboard";
        public const string chkSettingsGeneralHoverOverUrlToPasteClipboardHint = "Hover over the URL textbox to paste the URL from the clipboard";
        public const string chkSettingsGeneralClearUrlOnDownload = "Clear URL on download";
        public const string chkSettingsGeneralClearUrlOnDownloadHint = "Clears the URL from the textbox on video download";
        public const string chkSettingsGeneralClearClipboardOnDownload = "Clear clipboard on download";
        public const string chkSettingsGeneralClearClipboardOnDownloadHint = "Clears the clipboard on video download";
        public const string chkSettingsGeneralAutoUpdateYoutubeDl = "Auto update youtube-dl on launch";
        public const string chkSettingsGeneralAutoUpdateYoutubeDlHint = "Auto updates youtube-dl (or fork) when launching youtube-dl-gui.";
        public const string gbSettingsGeneralCustomArguments = "Custom arguments (saves on download)";
        public const string gbSettingsGeneralCustomArgumentsHint = "Controls how custom arguments for youtube-dl will be saved";
        public const string rbSettingsGeneralCustomArgumentsDontSave = "Don't save";
        public const string rbSettingsGeneralCustomArgumentsDontSaveHint = "Doesn't save any custom arguments";
        public const string rbSettingsGeneralCustomArgumentsSaveAsArgsText = "Save as ./args.txt";
        public const string rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = "Saves custom arguments as args.txt in youtube-dl-guis directory";
        public const string rbSettingsGeneralCustomArgumentsSaveInSettings = "Save in settings";
        public const string rbSettingsGeneralCustomArgumentsSaveInSettingsHint = "Saves custom arguments in the application settings";
        #endregion

        #region tabDownloads
        public const string tabSettingsDownloads = "Downloads";

        public const string lbSettingsDownloadsDownloadPath = "download path";
        public const string lbSettingsDownloadsDownloadPathHint = "The path of the folder where files will be downloaded to";
        public const string chkSettingsDownloadsDownloadPathUseRelativePathHint = "Save to the programs relative path\r\n\r\nIf checked, the program will check the save path and use the current directory as the base path.\r\nSaving anywhere outside of the current directory will not set the flag and will set it to wherever you selected.";
        public const string txtSettingsDownloadsSavePathHint = "where your downloads will be saved to";
        public const string btnSettingsDownloadsBrowseSavePathHint = "browse for a new save folder";
        public const string lbSettingsDownloadsFileNameSchema = "file name schema";
        public const string lbSettingsDownloadsFileNameSchemaHint = "The file name schema\n\nThis basically replaces sequences with video information for a custom file name.";
        public const string llSettingsDownloadsSchemaHelpHint = "Click here to view supported arguments";
        public const string txtSettingsDownloadsFileNameSchemaHint = "The file name schema that will be used by youtube-dl";
        public const string btnSettingsDownloadsFileNameSchemaHistory = "History";
        public const string btnSettingsDownloadsFileNameSchemaHistoryHint = "Shows a basic history editor to modify the schema list.";
        public const string btnSettingsDownloadsInstallProtocolNotInstalled = "Install browser protocol";
        public const string btnSettingsDownloadsInstallProtocolInstalled = "Browser protocol installed";
        public const string btnSettingsDownloadsInstallProtocolHint = "This will add a key to the registry which will allow browsers to send data to this program. Installing it requires Administrative permissions.";


        #region General
        public const string tabDownloadsGeneral = "General";

        public const string chkSettingsDownloadsSaveFormatQuality = "Save quality, format, && args on download";
        public const string chkSettingsDownloadsSaveFormatQualityHint = "Saves the quality selection, format selection, and custom arguments on download on the main form";
        public const string chkSettingsDownloadsDownloadSubtitles = "Download subtitles";
        public const string chkSettingsDownloadsDownloadSubtitlesHint = "Download all available subtitles for the video\nIf no subtitles are available, nothing will download";
        public const string chkSettingsDownloadsEmbedSubtitles = "Embed subtitles into file";
        public const string chkSettingsDownloadsEmbedSubtitlesHint = "Embeds downloaded subtitles into the output file\nOnly works for mp4, webm, and mkv videos";
        public const string chkSettingsDownloadsSaveVideoInfo = "Save video info";
        public const string chkSettingsDownloadsSaveVideoInfoHint = "Saves the videos info into a .info.json file";
        public const string chkSettingsDownloadsWriteMetadataToFile = "Write metadata to file";
        public const string chkSettingsDownloadsWriteMetadataToFileHint = "Writes the videos metadata to the output file";
        public const string chkSettingsDownloadsSaveDescription = "Save description";
        public const string chkSettingsDownloadsSaveDescriptionHint = "Saves the videos description to a .description file";
        public const string chkSettingsDownloadsKeepOriginalFiles = "Keep original files";
        public const string chkSettingsDownloadsKeepOriginalFilesHint = "Keeps the original files of the download\nBy default, youtube-dl will delete them after merging";
        public const string chkSettingsDownloadsSaveAnnotations = "Save annotations";
        public const string chkSettingsDownloadsSaveAnnotationsHint = "Saves the videos annotations to a .annotations.xml file";
        public const string chkSettingsDownloadsSaveThumbnails = "Save thumbnails";
        public const string chkSettingsDownloadsSaveThumbnailsHint = "Saves the videos thumbnail";
        public const string chkSettingsDownloadsEmbedThumbnails = "Embed thumbnail into file";
        public const string chkSettingsDownloadsEmbedThumbnailsHint = "Embeds downloaded thumbnails into the output file as cover art\nRequires AtomicParsley (https://github.com/wez/atomicparsley), or youtube-dl will result in an error";
        public const string chkSettingsDownloadsSkipUnavailableFragments = "Skip unavailable fragments";
        public const string chkSettingsDownloadsSkipUnavailableFragmentsHint = "Skips any fragments of a video that may be unavailable. Disabling this will abort downloads if any unavailable fragments are caught.";
        public const string chkSettingsDownloadsAbortOnError = "Abort on error";
        public const string chkSettingsDownloadsAbortOnErrorHint = "Aborts a download if an error occurs. Disabling this will make downloads continue if an error occurs during download.";
        #endregion

        #region Sorting
        public const string tabDownloadsSorting = "Sorting";


        public const string chkSettingsDownloadsSeparateDownloadsToDifferentFolders = "Separate downloads to different folders";
        public const string chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = "Separates downloads into their own folder based on the download type\n\nVideos would be <download directory>\\Video\nAudio would be <download directory>\\Audio\nCustom would be <download directory>\\Custom";
        public const string chkSettingsDownloadsSeparateIntoWebsiteUrl = "Separate into website url";
        public const string chkSettingsDownloadsSeparateIntoWebsiteUrlHint = "Downloaded files will be saved to the download path with the URL of the website appended at the end\nEx: C:\\Users\\YourName\\Videos\\youtube.com\\Video.mp4";
        public const string chkSettingsDownloadsWebsiteSubdomains = "Use subdomains in folder names";
        public const string chkSettingsDownloadsWebsiteSubdomainsHint = "Any downloads on a website using a subdomain will be separated into its own folder.\nEx: C:\\Users\\YourName\\Videos\\mobile.youtube.com\\Video.mp4 (mobile would be the subdomain of youtube.com)";
        #endregion

        #region Fixes
        public const string tabDownloadsFixes = "Fixes";


        public const string chkSettingsDownloadsFixVReddIt = "Fix v.redd.it";
        public const string chkSettingsDownloadsFixVReddItHint = "Fixes visual corruptions on v.redd.it/reddit.com links using ffmpegs HTTP Live Streaming (HLS)\n\n" + "Recommended to stay on.\nThis requires FFMPEG to be installed and available, it will fallback to youtube-dls default.";
        public const string chkSettingsDownloadsPreferFFmpeg = "Prefer ffmpeg for downloads";
        public const string chkSettingsDownloadsPreferFFmpegHint = "Prefers ffmpegs hls over youtube-dls own. This may fix some sites, and break others.";
        #endregion

        #region Connection
        public const string tabDownloadsConnection = "Connection";

        public const string chkSettingsDownloadsLimitDownload = "Limit download";
        public const string chkSettingsDownloadsLimitDownloadHint = "Limits the downloads to the specified speed";
        public const string numSettingsDownloadsLimitDownloadHint = "The speed that the download will be throttled to\nSet the number to 0 to disable limiting";
        public const string cbSettingsDownloadsLimitDownloadHint = "The *byte size limit";
        public const string lbSettingsDownloadsRetryAttempts = "Retry attempts";
        public const string lbSettingsDownloadsRetryAttemptsHint = "Retry downloading the specified amount of times if it fails";
        public const string numSettingsDownloadsRetryAttemptsHint = "The maximum amount of retries allowed";
        public const string chkSettingsDownloadsForceIpv4 = "Force IPv4";
        public const string chkSettingsDownloadsForceIpv4Hint = "Force the connection to tunnel through IPv4";
        public const string chkSettingsDownloadsForceIpv6 = "Force IPv6";
        public const string chkSettingsDownloadsForceIpv6Hint = "Force the connection to tunnel through IPv6";
        public const string chkSettingsDownloadsUseProxy = "Use a proxy";
        public const string chkSettingsDownloadsUseProxyHint = "Download using a proxy";
        public const string cbSettingsDownloadsProxyTypeHint = "The proxy protocol that will be used";
        public const string txtSettingsDownloadsProxyIpHint = "The proxy IP that will be used";
        public const string txtSettingsDownloadsProxyPortHint = "The proxy port that will be used";
        public const string lbSettingsDownloadsFragmentThreads = "Fragment threads";
        public const string lbSettingsDownloadsFragmentThreadsHint = "The amount of fragments of a video that will be downloaded in parallel (if supported).";
        #endregion

        #region Updating
        public const string tabDownloadsUpdating = "Updating";

        public const string chkSettingsDownloadsUseYoutubeDlsUpdater = "Use youtube-dls internal updater";
        public const string chkSettingsDownloadsUseYoutubeDlsUpdaterHint = "Use youtube-dls internal updater instead of this applications updater";
        public const string lbSettingsDownloadsUpdatingYtdlType = "Youtube-DL fork";
        public const string cbSettingsDownloadsUpdatingYtdlTypeHint = "The youtube-dl repo that will be targetted";
        public const string llbSettingsDownloadsYtdlTypeViewRepo = "View source repo";
        public const string llbSettingsDownloadsYtdlTypeViewRepoHint = "Go to the repository page of the selected fork";
        public const string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = "Automatically delete youtube-dl when closing";
        public const string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = "Automatically delete youtube-dl.exe when closing youtube-dl-gui";
        #endregion

        #region Batch
        public const string tabDownloadsBatch = "Batch";


        public const string chkSettingsDownloadsSeparateBatchDownloads = "Separate Batch Downloads";
        public const string chkSettingsDownloadsSeparateBatchDownloadsHint = "Batch downloads are separated into a new folder in the designated download path";
        public const string chkSettingsDownloadsAddDateToBatchDownloadFolders = "Include Date onto Download Folders";
        public const string chkSettingsDownloadsAddDateToBatchDownloadFoldersHint = "Batch downloads are further separated into a new folder that is the date and time the batch started";
        #endregion

        #region Extended downloader
        public const string tabExtendedOptions = "Extended downloader";

        public const string chkExtendedPreferExtendedDialog = "Prefer extended downloader";
        public const string chkExtendedPreferExtendedDialogHint = "Uses the extended downloader instead of the quick downloader when clicking \"Download\" on the main form.";
        public const string chkExtendedAutomaticallyDownloadThumbnail = "Automatically download thumbnails";
        public const string chkExtendedAutomaticallyDownloadThumbnailHint = "Automatically downloads the videos thumbnail to display in the form, when available.";
        public const string chkExtendedIncludeCustomArguments = "Include custom arguments";
        public const string chkExtendedIncludeCustomArgumentsHint = "Copies the custom arguments from the main form onto the extended form.";
        #endregion
        #endregion

        #region tabConverter
        public const string tabSettingsConverter = "Converter";

        public const string chkSettingsConverterClearOutputAfterConverting = "Clear output after converting";
        public const string chkSettingsConverterClearOutputAfterConvertingHint = "Clears the output file after a successful conversion";
        public const string chkSettingsConverterDetectOutputFileType = "Detect output filetype";
        public const string chkSettingsConverterDetectOutputFileTypeHint = "If Automatic is checked on converting, this will attempt to detect the output file type.\n\nDisable this if you want a simple conversion. The quality may suffer as a result.";
        public const string chkSettingsConverterClearInputAfterConverting = "Clear input after converting";
        public const string chkSettingsConverterClearInputAfterConvertingHint = "Clears the input file after a successful conversion";
        public const string chkSettingsConverterHideFFmpegCompileInfo = "Hide ffmpeg compile info";
        public const string chkSettingsConverterHideFFmpegCompileInfoHint = "Enabling this will hide some compilation information of ffmpeg.";

        #region Video
        public const string tcSettingsConverterVideo = "Video";
        
        public const string lbSettingsConverterVideoBitrate = "Bitrate";
        public const string lbSettingsConverterVideoBitrateHint = "The bitrate of the video\nA bitrate is how many bits per second are streamed to the player\n\nhigher = better, at the cost of file size\n\nIf you were to input \"10,000\" as the bitrate, it would be interpreted as \"10,000,000\" bits per second.";
        public const string lbSettingsConverterVideoPreset = "Preset";
        public const string lbSettingsConverterVideoPresetHint = "The video preset of the conversion\n\nultrafast = fastest, but lower quality\nveryslow = slowest, but higher quality";
        public const string lbSettingsConverterVideoProfile = "Profile";
        public const string lbSettingsConverterVideoProfileHint = "The encoder profile to be used during conversion. It affects the compression of the video.\nIt's generally a good idea to stick with the main profile";
        public const string lbSettingsConverterVideoCRF = "CRF";
        public const string lbSettingsConverterVideoCRFHint = "CRF is constant rate factor.\n\nLower = Higher quality";
        public const string chkSettingsConverterVideoFastStart = "faststart";
        public const string chkSettingsConverterVideoFastStartHint = "Faststart moves the metadata to the front of the file.\n\nEnabling this allows videos to be played before they are fully downloaded.";
        #endregion

        #region Audio
        public const string tcSettingsConverterAudio = "Audio";
        
        public const string lbSettingsConverterAudioBitrate = "Bitrate";
        public const string lbSettingsConverterAudioBitrateHint = "The bitrate of the audio\nA bitrate is how many bits are streamed to the player\n\nHigher = better, at the cost of size\n\nIf you were to put \"256\", it would be interpreted as \"256,000\" bits per second.";
        #endregion

        #region Custom
        public const string tcSettingsConverterCustom = "Custom";
        
        public const string lbSettingsConverterCustomHeader = "Don't pass input or output directories/fies,\nit's automatically handled by the program";
        public const string txtSettingsConverterCustomArgumentsHint = "Custom arguments that will be passed through ffmpeg instead of built-in arguments";
        #endregion
        #endregion

        #region tabExtensions
        public const string tabSettingsExtensions = "Extensions";
        
        public const string lbSettingsExtensionsHeader = "This allows you to input your own extensions\nto be used with this application";
        public const string lbSettingsExtensionsExtensionFullName = "Extension full name";
        public const string txtSettingsExtensionsExtensionFullName = "Example extension";
        public const string lbSettingsExtensionsExtensionShort = "Extension short";
        public const string txtSettingsExtensionsExtensionShort = "ext";
        public const string btnSettingsExtensionsAdd = "Add";
        public const string lbSettingsExtensionsFileName = "FileName";
        public const string btnSettingsExtensionsRemoveSelected = "Remove selected";
        #endregion

        #region tabErrors
        public const string tabSettingsErrors = "Errors";

        public const string chkSettingsErrorsShowDetailedErrors = "Show detailed errors";
        public const string chkSettingsErrorsShowDetailedErrorsHint = "Shows more details in errors";
        public const string chkSettingsErrorsSaveErrorsAsErrorLog = "Save errors as ./error.log";
        public const string chkSettingsErrorsSaveErrorsAsErrorLogHint = "Saves the latest error as error.log in the exeucting directory of youtube-dl-gui";
        public const string chkSettingsErrorsSuppressErrors = "Suppress errors";
        public const string chkSettingsErrorsSuppressErrorsHint = "This will silence any errors and will not save any error.log files.\nRetriable errors are exempt from this option.\n\nThis basically overrides all error settings. Use at your own risk.";
        #endregion
        #endregion

        #region frmSubtitles
        // frmSubtitles
        public const string frmSubtitles = "Download subtitles";
        public const string lbSubtitlesHeader = "This only downloads subtitles";
        public const string lbSubtitlesUrl = "URL";
        public const string lbSubtitlesLanguages = "Language(s)";
        public const string btnSubtitlesAddLanguage = "Add";
        public const string btnSubtitlesClearLanguages = "Clear";
        public const string btnSubtitlesDownload = "Download subtitles";
        #endregion

        #region frmTools
        // frmTools
        public const string frmTools = "Misc tools";
        public const string btnMiscToolsRemoveAudio = "Remove audio...";
        public const string btnMiscToolsExtractAudio = "Extract audio...";
        public const string btnMiscToolsVideoToGif = "Video to gif...";
        #endregion

        #region frmUpdateAvailable
        public const string frmUpdateAvailable = "Update available";
        public const string lbUpdateAvailableHeader = "An update is available";
        public const string lbUpdateAvailableUpdateVersion = "Update version: {0}";
        public const string lbUpdateAvailableCurrentVersion = "Current version: {0}";
        public const string lbUpdateAvailableChangelog = "Changelog:";
        public const string lbUpdateSize = "The new executable size is {0}";
        public const string btnUpdateAvailableSkipVersion = "Skip version";
        public const string btnUpdateAvailableUpdate = "Update";
        #endregion
    }

    /// <summary>
    /// Loads all the internal English strings to the instance.
    /// </summary>
    public static void LoadInternalEnglish() {
        Log.Write("Loading internal english.");
        LoadedFile = null;
        UsingInternalEnglish = true;

        #region Identifier
        CurrentLanguageLong = InternalEnglish.CurrentLanguageLong;
        CurrentLanguageShort = InternalEnglish.CurrentLanguageShort;
        CurrentLanguageHint = InternalEnglish.CurrentLanguageHint;
        CurrentLanguageVersion = Program.CurrentVersion.ToString();
        #endregion

        #region Generic
        GenericInputBest = InternalEnglish.GenericInputBest;
        GenericInputWorst = InternalEnglish.GenericInputWorst;
        GenericCancel = InternalEnglish.GenericCancel;
        GenericSkip = InternalEnglish.GenericSkip;
        GenericSound = InternalEnglish.GenericSound;
        GenericVideo = InternalEnglish.GenericVideo;
        GenericAudio = InternalEnglish.GenericAudio;
        GenericCustom = InternalEnglish.GenericCustom;
        GenericRetry = InternalEnglish.GenericRetry;
        GenericStart = InternalEnglish.GenericStart;
        GenericStop = InternalEnglish.GenericStop;
        GenericExit = InternalEnglish.GenericExit;
        GenericOk = InternalEnglish.GenericOk;
        GenericSave = InternalEnglish.GenericSave;
        GenericAdd = InternalEnglish.GenericAdd;
        GenericClose = InternalEnglish.GenericClose;
        GenericClear = InternalEnglish.GenericClear;
        GenericRemoveSelected = InternalEnglish.GenericRemoveSelected;
        GenericVerifyLinks = InternalEnglish.GenericVerifyLinks;
        GenericDoNotReEncode = InternalEnglish.GenericDoNotReEncode;
        GenericDoNotRemux = InternalEnglish.GenericDoNotRemux;
        GenericDoNotDownload = InternalEnglish.GenericDoNotDownload;
        GenericUnknownFormat = InternalEnglish.GenericUnknownFormat;
        GenericMoreInfo = InternalEnglish.GenericMoreInfo;
        GenericTitle = InternalEnglish.GenericTitle;
        GenericLength = InternalEnglish.GenericLength;
        GenericUploadedOn = InternalEnglish.GenericUploadedOn;
        GenericInput = InternalEnglish.GenericInput;
        GenericOutput = InternalEnglish.GenericOutput;
        GenericArguments = InternalEnglish.GenericArguments;
        GenericAborted = InternalEnglish.GenericAborted;
        GenericError = InternalEnglish.GenericError;
        GenericAltError = InternalEnglish.GenericAltError;
        GenericCompleted = InternalEnglish.GenericCompleted;
        GenericRemove = InternalEnglish.GenericRemove;

        frmGenericDownloadProgress = InternalEnglish.frmGenericDownloadProgress;
        chContainer = InternalEnglish.chContainer;
        chFileSize = InternalEnglish.chFileSize;
        chFormatId = InternalEnglish.chFormatId;
        chVideoQuality = InternalEnglish.chVideoQuality;
        chVideoFPS = InternalEnglish.chVideoFPS;
        chVideoBitrate = InternalEnglish.chVideoBitrate;
        chVideoDimension = InternalEnglish.chVideoDimension;
        chVideoCodec = InternalEnglish.chVideoCodec;
        chAudioBitrate = InternalEnglish.chAudioBitrate;
        chAudioSampleRate = InternalEnglish.chAudioSampleRate;
        chAudioCodec = InternalEnglish.chAudioCodec;
        chAudioChannels = InternalEnglish.chAudioChannels;
        dlBeginningDownload = InternalEnglish.dlBeginningDownload;
        cvBeginningConversion = InternalEnglish.cvBeginningConversion;
        #endregion

        #region Dialogs
        dlgFirstTimeInitialMessage = InternalEnglish.dlgFirstTimeInitialMessage;
        dlgFirstTimeDownloadFolder = InternalEnglish.dlgFirstTimeDownloadFolder;
        dlgFirstTimeDownloadYoutubeDl = InternalEnglish.dlgFirstTimeDownloadYoutubeDl;
        dlgFirstTimeDownloadFfmpeg = InternalEnglish.dlgFirstTimeDownloadFfmpeg;

        dlgClipboardAutoDownloadNotice = InternalEnglish.dlgClipboardAutoDownloadNotice;
        dlgBatchDownloadClipboardScannerNotice = InternalEnglish.dlgBatchDownloadClipboardScannerNotice;

        dlgFindDownloadFolder = InternalEnglish.dlgFindDownloadFolder;
        dlgMainArgsTxtDoesntExist = InternalEnglish.dlgMainArgsTxtDoesntExist;
        dlgMainArgsTxtIsEmpty = InternalEnglish.dlgMainArgsTxtIsEmpty;
        dlgMainArgsNoneSaved = InternalEnglish.dlgMainArgsNoneSaved;
        dlgConvertSelectFileToConvert = InternalEnglish.dlgConvertSelectFileToConvert;
        dlgMergeSelectFileToMerge = InternalEnglish.dlgMergeSelectFileToMerge;
        dlgSaveOutputFileAs = InternalEnglish.dlgSaveOutputFileAs;
        dlgLanguageHashNoMatch = InternalEnglish.dlgLanguageHashNoMatch;

        dlgAuthenticationCookiesFromBrowser = InternalEnglish.dlgAuthenticationCookiesFromBrowser;

        dlgUpdateFailedToCheck = InternalEnglish.dlgUpdateFailedToCheck;
        dlgUpdateNoUpdateAvailable = InternalEnglish.dlgUpdateNoUpdateAvailable;
        dlgUpdateNoBetaUpdateAvailable = InternalEnglish.dlgUpdateNoBetaUpdateAvailable;
        dlgUpdateNoValidYoutubeDl = InternalEnglish.dlgUpdateNoValidYoutubeDl;
        dlgUpdatedYoutubeDl = InternalEnglish.dlgUpdatedYoutubeDl;
        dlgUpdaterHashNoMatch = InternalEnglish.dlgUpdaterHashNoMatch;
        dlgUpateYoutubeDlNoUpdateRequired = InternalEnglish.dlgUpateYoutubeDlNoUpdateRequired;

        frmFileNameSchemaHistory = InternalEnglish.frmFileNameSchemaHistory;
        #endregion

        #region Downloading status (shared)
        pbDownloadProgressFfmpegPostProcessing = InternalEnglish.pbDownloadProgressFfmpegPostProcessing;
        pbDownloadProgressEmbeddingSubtitles = InternalEnglish.pbDownloadProgressEmbeddingSubtitles;
        pbDownloadProgressEmbeddingMetadata = InternalEnglish.pbDownloadProgressEmbeddingMetadata;
        pbDownloadProgressMergingFormats = InternalEnglish.pbDownloadProgressMergingFormats;
        pbDownloadProgressConverting = InternalEnglish.pbDownloadProgressConverting;
        #endregion

        #region frmAbout
        frmAbout = InternalEnglish.frmAbout;
        lbAboutBody = InternalEnglish.lbAboutBody;
        llbCheckForUpdates = InternalEnglish.llbCheckForUpdates;
        #endregion

        #region frmArchiveDownloader
        frmArchiveDownloader = InternalEnglish.frmArchiveDownloader;
        lbArchiveDownloaderDescription = InternalEnglish.lbArchiveDownloaderDescription;
        txtArchiveDownloaderHint = InternalEnglish.txtArchiveDownloaderHint;
        #endregion

        #region frmAuthentication
        frmAuthentication = InternalEnglish.frmAuthentication;
        lbAuthNotice = InternalEnglish.lbAuthNotice;
        lbAuthUsername = InternalEnglish.lbAuthUsername;
        lbAuthPassword = InternalEnglish.lbAuthPassword;
        lbAuth2Factor = InternalEnglish.lbAuth2Factor;
        lbAuthVideoPassword = InternalEnglish.lbAuthVideoPassword;
        lbAuthCookiesFromFile = InternalEnglish.lbAuthCookiesFromFile;
        lbAuthCookiesFromBrowser = InternalEnglish.lbAuthCookiesFromBrowser;
        chkAuthUseNetrc = InternalEnglish.chkAuthUseNetrc;
        lbAuthNoSave = InternalEnglish.lbAuthNoSave;
        btnAuthBeginDownload = InternalEnglish.btnAuthBeginDownload;
        #endregion

        #region frmBatchConvert
        frmBatchConverter = InternalEnglish.frmBatchConverter;
        lbBatchConverterInput = InternalEnglish.lbBatchConverterInput;
        txtBatchConverterInputFile = InternalEnglish.txtBatchConverterInputFile;
        lbBatchConverterOutput = InternalEnglish.lbBatchConverterOutput;
        txtBatchConverterOutputFile = InternalEnglish.txtBatchConverterOutputFile;
        txtBatchConverterCustomConversionArguments = InternalEnglish.txtBatchConverterCustomConversionArguments;
        sbBatchConverterIdle = InternalEnglish.sbBatchConverterIdle;
        sbBatchConverterConverting = InternalEnglish.sbBatchConverterConverting;
        sbBatchConverterFinished = InternalEnglish.sbBatchConverterFinished;
        sbBatchConverterAborted = InternalEnglish.sbBatchConverterAborted;
        #endregion

        #region frmBatchDownload
        frmBatchDownload = InternalEnglish.frmBatchDownload;
        lbBatchDownloadLink = InternalEnglish.lbBatchDownloadLink;
        lbBatchDownloadType = InternalEnglish.lbBatchDownloadType;
        lbBatchDownloadVideoSpecificArgument = InternalEnglish.lbBatchDownloadVideoSpecificArgument;
        sbBatchDownloadLoadArgs = InternalEnglish.sbBatchDownloadLoadArgs;
        mBatchDownloaderLoadArgsFromSettings = InternalEnglish.mBatchDownloaderLoadArgsFromSettings;
        mBatchDownloaderLoadArgsFromArgsTxt = InternalEnglish.mBatchDownloaderLoadArgsFromArgsTxt;
        mBatchDownloaderLoadArgsFromFile = InternalEnglish.mBatchDownloaderLoadArgsFromFile;
        sbBatchDownloaderImportLinks = InternalEnglish.sbBatchDownloaderImportLinks;
        mBatchDownloaderImportLinksFromFile = InternalEnglish.mBatchDownloaderImportLinksFromFile;
        mBatchDownloaderImportLinksFromClipboard = InternalEnglish.mBatchDownloaderImportLinksFromClipboard;
        sbBatchDownloaderIdle = InternalEnglish.sbBatchDownloaderIdle;
        sbBatchDownloaderDownloading = InternalEnglish.sbBatchDownloaderDownloading;
        sbBatchDownloaderFinished = InternalEnglish.sbBatchDownloaderFinished;
        sbBatchDownloaderAborted = InternalEnglish.sbBatchDownloaderAborted;
        chkBatchDownloadClipboardScanner = InternalEnglish.chkBatchDownloadClipboardScanner;
        #endregion

        #region frmConverter
        frmConverter = InternalEnglish.frmConverter;
        frmConverterComplete = InternalEnglish.frmConverterComplete;
        frmConverterError = InternalEnglish.frmConverterError;
        chkConverterCloseAfterConversion = InternalEnglish.chkConverterCloseAfterConversion;
        btnConverterAbortBatchConversions = InternalEnglish.btnConverterAbortBatchConversions;
        #endregion

        #region frmDownloader
        frmDownloader = InternalEnglish.frmDownloader;
        frmDownloaderComplete = InternalEnglish.frmDownloaderComplete;
        frmDownloaderError = InternalEnglish.frmDownloaderError;
        chkDownloaderCloseAfterDownload = InternalEnglish.chkDownloaderCloseAfterDownload;
        btnDownloaderAbortBatch = InternalEnglish.btnDownloaderAbortBatch;
        #endregion

        #region frmDownloadLanguage
        frmDownloadLanguage = InternalEnglish.frmDownloadLanguage;
        #endregion

        #region frmException
        frmException = InternalEnglish.frmException;
        lbExceptionHeader = InternalEnglish.lbExceptionHeader;
        lbExceptionDescription = InternalEnglish.lbExceptionDescription;
        rtbExceptionDetails = InternalEnglish.rtbExceptionDetails;
        btnExceptionGithub = InternalEnglish.btnExceptionGithub;
        tabExceptionDetails = InternalEnglish.tabExceptionDetails;
        tabExceptionExtraInfo = InternalEnglish.tabExceptionExtraInfo;
        #endregion

        #region frmExtendedDownloader
        frmExtendedDownloaderRetrieving = InternalEnglish.frmExtendedDownloaderRetrieving;
        lbExtendedDownloaderLink = InternalEnglish.lbExtendedDownloaderLink;
        lbExtendedDownloaderUploader = InternalEnglish.lbExtendedDownloaderUploader;
        lbExtendedDownloaderViews = InternalEnglish.lbExtendedDownloaderViews;
        lbExtendedDownloaderDownloadingThumbnail = InternalEnglish.lbExtendedDownloaderDownloadingThumbnail;
        lbExtendedDownloaderDownloadingThumbnailFailed = InternalEnglish.lbExtendedDownloaderDownloadingThumbnailFailed;
        btnExtendedDownloaderDownloadThumbnail = InternalEnglish.btnExtendedDownloaderDownloadThumbnail;
        tabExtendedDownloaderUnknownFormats = InternalEnglish.tabExtendedDownloaderUnknownFormats;
        tabExtendedDownloaderDescription = InternalEnglish.tabExtendedDownloaderDescription;
        tabExtendedDownloaderVerbose = InternalEnglish.tabExtendedDownloaderVerbose;
        tabExtendedDownloaderFormatOptions = InternalEnglish.tabExtendedDownloaderFormatOptions;
        chkExtendedDownloaderVideoSeparateAudio = InternalEnglish.chkExtendedDownloaderVideoSeparateAudio;
        lbExtendedDownloaderNoVideoFormatsAvailable = InternalEnglish.lbExtendedDownloaderNoVideoFormatsAvailable;
        lbExtendedDownloaderNoAudioFormatsAvailable = InternalEnglish.lbExtendedDownloaderNoAudioFormatsAvailable;
        lbExtendedDownloaderNoUnknownFormatsFound = InternalEnglish.lbExtendedDownloaderNoUnknownFormatsFound;
        lbVideoRemux = InternalEnglish.lbVideoRemux;
        txtExtendedDownloaderMediaTitle = InternalEnglish.txtExtendedDownloaderMediaTitle;
        txtExtendedDownloaderBatchMediaTitle = InternalEnglish.txtExtendedDownloaderBatchMediaTitle;
        mExtendedDownloaderEnqueueCopyOptions = InternalEnglish.mExtendedDownloaderEnqueueCopyOptions;
        mExtendedDownloaderEnqueueWithAuthentication = InternalEnglish.mExtendedDownloaderEnqueueWithAuthentication;
        mExtendedDownloaderEnqueueCopyAuthentication = InternalEnglish.mExtendedDownloaderEnqueueCopyAuthentication;
        mExtendedDownloaderQueueCopyLink = InternalEnglish.mExtendedDownloaderQueueCopyLink;
        mExtendedDownloaderQueueViewInBrowser = InternalEnglish.mExtendedDownloaderQueueViewInBrowser;
        mExtendedDownloaderEnqueueImportLinksWithAuthentication = InternalEnglish.mExtendedDownloaderEnqueueImportLinksWithAuthentication;
        mExtendedDownloaderEnqueueImportLinksCopyOptions = InternalEnglish.mExtendedDownloaderEnqueueImportLinksCopyOptions;
        mExtendedDownloaderEnqueueImportLinksCopyAuthentication = InternalEnglish.mExtendedDownloaderEnqueueImportLinksCopyAuthentication;
        #endregion

        #region frmLanguage
        frmLanguage = InternalEnglish.frmLanguage;
        btnLanguageRefresh = InternalEnglish.btnLanguageRefresh;
        btnLanguageDownload = InternalEnglish.btnLanguageDownload;
        #endregion

        #region frmLog
        frmLog = InternalEnglish.frmLog;
        frmLogClear = InternalEnglish.frmLogClear;
        frmLogExceptions = InternalEnglish.frmLogExceptions;
        lbLogPastExceptions = InternalEnglish.lbLogPastExceptions;
        #endregion

        #region frmMain
        mSettings = InternalEnglish.mSettings;
        mTools = InternalEnglish.mTools;
        mBatch = InternalEnglish.mBatch;
        mBatchDownload = InternalEnglish.mBatchDownload;
        mBatchExtendedDownload = InternalEnglish.mBatchExtendedDownload;
        mBatchConvert = InternalEnglish.mBatchConvert;
        mArchiveDownloader = InternalEnglish.mArchiveDownloader;
        mDownloadSubtitles = InternalEnglish.mDownloadSubtitles;
        mMiscTools = InternalEnglish.mMiscTools;
        mClipboardAutoDownload = InternalEnglish.mClipboardAutoDownload;
        mHelp = InternalEnglish.mHelp;
        mLanguage = InternalEnglish.mLanguage;
        mSupportedSites = InternalEnglish.mSupportedSites;
        mAbout = InternalEnglish.mAbout;

        tabDownload = InternalEnglish.tabDownload;
        tabConvert = InternalEnglish.tabConvert;
        tabMerge = InternalEnglish.tabMerge;

        lbURL = InternalEnglish.lbURL;
        txtUrlHint = InternalEnglish.txtUrlHint;
        gbDownloadType = InternalEnglish.gbDownloadType;
        lbQuality = InternalEnglish.lbQuality;
        lbFormat = InternalEnglish.lbFormat;
        chkUseSelection = InternalEnglish.chkUseSelection;
        rbVideoSelectionPlaylistIndex = InternalEnglish.rbVideoSelectionPlaylistIndex;
        rbVideoSelectionPlaylistItems = InternalEnglish.rbVideoSelectionPlaylistItems;
        rbVideoSelectionBeforeDate = InternalEnglish.rbVideoSelectionBeforeDate;
        rbVideoSelectionOnDate = InternalEnglish.rbVideoSelectionOnDate;
        rbVideoSelectionAfterDate = InternalEnglish.rbVideoSelectionAfterDate;
        txtPlaylistStartHint = InternalEnglish.txtPlaylistStartHint;
        txtPlaylistEndHint = InternalEnglish.txtPlaylistEndHint;
        txtPlaylistItemsHint = InternalEnglish.txtPlaylistItemsHint;
        txtVideoDateHint = InternalEnglish.txtVideoDateHint;
        lbCustomArguments = InternalEnglish.lbCustomArguments;
        sbDownload = InternalEnglish.sbDownload;
        btnMainExtended = InternalEnglish.btnMainExtended;
        mDownloadWithAuthentication = InternalEnglish.mDownloadWithAuthentication;
        mBatchDownloadFromFile = InternalEnglish.mBatchDownloadFromFile;
        msgBatchDownloadFromFile = InternalEnglish.msgBatchDownloadFromFile;
        mQuickDownloadForm = InternalEnglish.mQuickDownloadForm;
        mQuickDownloadFormAuthentication = InternalEnglish.mQuickDownloadFormAuthentication;
        mExtendedDownloadForm = InternalEnglish.mExtendedDownloadForm;
        mExtendedDownloadFormAuthentication = InternalEnglish.mExtendedDownloadFormAuthentication;

        lbConvertInput = InternalEnglish.lbConvertInput;
        lbConvertOutput = InternalEnglish.lbConvertOutput;
        rbConvertAuto = InternalEnglish.rbConvertAuto;
        rbConvertAutoFFmpeg = InternalEnglish.rbConvertAutoFFmpeg;
        btnConvert = InternalEnglish.btnConvert;

        cmTrayShowForm = InternalEnglish.cmTrayShowForm;
        cmTrayDownloader = InternalEnglish.cmTrayDownloader;
        cmTrayDownloadClipboard = InternalEnglish.cmTrayDownloadClipboard;
        cmTrayDownloadBestVideo = InternalEnglish.cmTrayDownloadBestVideo;
        cmTrayDownloadBestAudio = InternalEnglish.cmTrayDownloadBestAudio;
        cmTrayDownloadCustom = InternalEnglish.cmTrayDownloadCustom;
        cmTrayDownloadCustomTxtBox = InternalEnglish.cmTrayDownloadCustomTxtBox;
        cmTrayDownloadCustomTxt = InternalEnglish.cmTrayDownloadCustomTxt;
        cmTrayDownloadCustomSettings = InternalEnglish.cmTrayDownloadCustomSettings;
        cmTrayConverter = InternalEnglish.cmTrayConverter;
        cmTrayConvertTo = InternalEnglish.cmTrayConvertTo;
        cmTrayConvertVideo = InternalEnglish.cmTrayConvertVideo;
        cmTrayConvertAudio = InternalEnglish.cmTrayConvertAudio;
        cmTrayConvertCustom = InternalEnglish.cmTrayConvertCustom;
        cmTrayConvertAutomatic = InternalEnglish.cmTrayConvertAutomatic;
        cmTrayConvertAutoFFmpeg = InternalEnglish.cmTrayConvertAutoFFmpeg;
        cmTrayExit = InternalEnglish.cmTrayExit;
        #endregion
        
        #region frmMerger
        frmMerger = InternalEnglish.frmMerger;
        btnMerge = InternalEnglish.btnMerge;
        frmMergerVideoSources = InternalEnglish.frmMergerVideoSources;
        frmMergerAudioSources = InternalEnglish.frmMergerAudioSources;
        frmMergerSubtitleSources = InternalEnglish.frmMergerSubtitleSources;
        frmMergerAttatchmentSources = InternalEnglish.frmMergerAttatchmentSources;
        #endregion

        #region frmSettings
        frmSettings = InternalEnglish.frmSettings;
        btnSettingsCancelHint = InternalEnglish.btnSettingsCancelHint;
        btnSettingsSaveHint = InternalEnglish.btnSettingsSaveHint;

        #region tabGeneral
        //frmSettings / tcMain / tabGeneral
        tabSettingsGeneral = InternalEnglish.tabSettingsGeneral;

        tabSettingsGeneralYoutubeDl = InternalEnglish.tabSettingsGeneralYoutubeDl;
        lbSettingsGeneralYoutubeDlPath = InternalEnglish.lbSettingsGeneralYoutubeDlPath;
        lbSettingsGeneralYoutubeDlPathHint = InternalEnglish.lbSettingsGeneralYoutubeDlPathHint;
        chkSettingsGeneralUseStaticYoutubeDl = InternalEnglish.chkSettingsGeneralUseStaticYoutubeDl;
        chkSettingsGeneralUseStaticYoutubeDlHint = InternalEnglish.chkSettingsGeneralUseStaticYoutubeDlHint;
        txtSettingsGeneralYoutubeDlPathHint = InternalEnglish.txtSettingsGeneralYoutubeDlPathHint;
        btnSettingsGeneralBrowseYoutubeDlHint = InternalEnglish.btnSettingsGeneralBrowseYoutubeDlHint;
        btnSettingsRedownloadYoutubeDl = InternalEnglish.btnSettingsRedownloadYoutubeDl;
        btnSettingsRedownloadYoutubeDlHint = InternalEnglish.btnSettingsRedownloadYoutubeDlHint;
        ofdTitleYoutubeDl = InternalEnglish.ofdTitleYoutubeDl;
        ofdFilterYoutubeDl = InternalEnglish.ofdFilterYoutubeDl;


        tabSettingsGeneralFfmpeg = InternalEnglish.tabSettingsGeneralFfmpeg;
        lbSettingsGeneralFFmpegDirectory = InternalEnglish.lbSettingsGeneralFFmpegDirectory;
        lbSettingsGeneralFFmpegDirectoryHint = InternalEnglish.lbSettingsGeneralFFmpegDirectoryHint;
        chkSettingsGeneralUseStaticFFmpeg = InternalEnglish.chkSettingsGeneralUseStaticFFmpeg;
        chkSettingsGeneralUseStaticFFmpegHint = InternalEnglish.chkSettingsGeneralUseStaticFFmpegHint;
        txtSettingsGeneralFFmpegPathHint = InternalEnglish.txtSettingsGeneralFFmpegPathHint;
        btnSettingsGeneralBrowseFFmpegHint = InternalEnglish.btnSettingsGeneralBrowseFFmpegHint;
        btnSettingsRedownloadFfmpeg = InternalEnglish.btnSettingsRedownloadFfmpeg;
        btnSettingsRedownloadFfmpegHint = InternalEnglish.btnSettingsRedownloadFfmpegHint;
        ofdTitleFFmpeg = InternalEnglish.ofdTitleFFmpeg;
        ofdFilterFFmpeg = InternalEnglish.ofdFilterFFmpeg;


        chkSettingsGeneralCheckForUpdatesOnLaunch = InternalEnglish.chkSettingsGeneralCheckForUpdatesOnLaunch;
        chkSettingsGeneralCheckForUpdatesOnLaunchHint = InternalEnglish.chkSettingsGeneralCheckForUpdatesOnLaunchHint;
        chkSettingsGeneralCheckForBetaUpdates = InternalEnglish.chkSettingsGeneralCheckForBetaUpdates;
        chkSettingsGeneralCheckForBetaUpdatesHint = InternalEnglish.chkSettingsGeneralCheckForBetaUpdatesHint;
        chkSettingsGeneralDeleteUpdaterAfterUpdating = InternalEnglish.chkSettingsGeneralDeleteUpdaterAfterUpdating;
        chkSettingsGeneralDeleteUpdaterAfterUpdatingHint = InternalEnglish.chkSettingsGeneralDeleteUpdaterAfterUpdatingHint;
        chkDeleteOldVersionAfterUpdating = InternalEnglish.chkDeleteOldVersionAfterUpdating;
        chkDeleteOldVersionAfterUpdatingHint = InternalEnglish.chkDeleteOldVersionAfterUpdatingHint;
        chkSettingsGeneralHoverOverUrlToPasteClipboard = InternalEnglish.chkSettingsGeneralHoverOverUrlToPasteClipboard;
        chkSettingsGeneralHoverOverUrlToPasteClipboardHint = InternalEnglish.chkSettingsGeneralHoverOverUrlToPasteClipboardHint;
        chkSettingsGeneralClearUrlOnDownload = InternalEnglish.chkSettingsGeneralClearUrlOnDownload;
        chkSettingsGeneralClearUrlOnDownloadHint = InternalEnglish.chkSettingsGeneralClearUrlOnDownloadHint;
        chkSettingsGeneralClearClipboardOnDownload = InternalEnglish.chkSettingsGeneralClearClipboardOnDownload;
        chkSettingsGeneralClearClipboardOnDownloadHint = InternalEnglish.chkSettingsGeneralClearClipboardOnDownloadHint;
        chkSettingsGeneralAutoUpdateYoutubeDl = InternalEnglish.chkSettingsGeneralAutoUpdateYoutubeDl;
        chkSettingsGeneralAutoUpdateYoutubeDlHint = InternalEnglish.chkSettingsGeneralAutoUpdateYoutubeDlHint;
        gbSettingsGeneralCustomArguments = InternalEnglish.gbSettingsGeneralCustomArguments;
        gbSettingsGeneralCustomArgumentsHint = InternalEnglish.gbSettingsGeneralCustomArgumentsHint;
        rbSettingsGeneralCustomArgumentsDontSave = InternalEnglish.rbSettingsGeneralCustomArgumentsDontSave;
        rbSettingsGeneralCustomArgumentsDontSaveHint = InternalEnglish.rbSettingsGeneralCustomArgumentsDontSaveHint;
        rbSettingsGeneralCustomArgumentsSaveAsArgsText = InternalEnglish.rbSettingsGeneralCustomArgumentsSaveAsArgsText;
        rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = InternalEnglish.rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint;
        rbSettingsGeneralCustomArgumentsSaveInSettings = InternalEnglish.rbSettingsGeneralCustomArgumentsSaveInSettings;
        rbSettingsGeneralCustomArgumentsSaveInSettingsHint = InternalEnglish.rbSettingsGeneralCustomArgumentsSaveInSettingsHint;
        #endregion

        #region tabDownloads
        tabSettingsDownloads = InternalEnglish.tabSettingsDownloads;

        lbSettingsDownloadsDownloadPath = InternalEnglish.lbSettingsDownloadsDownloadPath;
        lbSettingsDownloadsDownloadPathHint = InternalEnglish.lbSettingsDownloadsDownloadPathHint;
        chkSettingsDownloadsDownloadPathUseRelativePathHint = InternalEnglish.chkSettingsDownloadsDownloadPathUseRelativePathHint;
        txtSettingsDownloadsSavePathHint = InternalEnglish.txtSettingsDownloadsSavePathHint;
        btnSettingsDownloadsBrowseSavePathHint = InternalEnglish.btnSettingsDownloadsBrowseSavePathHint;
        lbSettingsDownloadsFileNameSchema = InternalEnglish.lbSettingsDownloadsFileNameSchema;
        lbSettingsDownloadsFileNameSchemaHint = InternalEnglish.lbSettingsDownloadsFileNameSchemaHint;
        llSettingsDownloadsSchemaHelpHint = InternalEnglish.llSettingsDownloadsSchemaHelpHint;
        txtSettingsDownloadsFileNameSchemaHint = InternalEnglish.txtSettingsDownloadsFileNameSchemaHint;
        btnSettingsDownloadsFileNameSchemaHistory = InternalEnglish.btnSettingsDownloadsFileNameSchemaHistory;
        btnSettingsDownloadsFileNameSchemaHistoryHint = InternalEnglish.btnSettingsDownloadsFileNameSchemaHistoryHint;
        btnSettingsDownloadsInstallProtocolNotInstalled = InternalEnglish.btnSettingsDownloadsInstallProtocolNotInstalled;
        btnSettingsDownloadsInstallProtocolInstalled = InternalEnglish.btnSettingsDownloadsInstallProtocolInstalled;
        btnSettingsDownloadsInstallProtocolHint = InternalEnglish.btnSettingsDownloadsInstallProtocolHint;


        #region General
        tabDownloadsGeneral = InternalEnglish.tabDownloadsGeneral;

        chkSettingsDownloadsSaveFormatQuality = InternalEnglish.chkSettingsDownloadsSaveFormatQuality;
        chkSettingsDownloadsSaveFormatQualityHint = InternalEnglish.chkSettingsDownloadsSaveFormatQualityHint;
        chkSettingsDownloadsDownloadSubtitles = InternalEnglish.chkSettingsDownloadsDownloadSubtitles;
        chkSettingsDownloadsDownloadSubtitlesHint = InternalEnglish.chkSettingsDownloadsDownloadSubtitlesHint;
        chkSettingsDownloadsEmbedSubtitles = InternalEnglish.chkSettingsDownloadsEmbedSubtitles;
        chkSettingsDownloadsEmbedSubtitlesHint = InternalEnglish.chkSettingsDownloadsEmbedSubtitlesHint;
        chkSettingsDownloadsSaveVideoInfo = InternalEnglish.chkSettingsDownloadsSaveVideoInfo;
        chkSettingsDownloadsSaveVideoInfoHint = InternalEnglish.chkSettingsDownloadsSaveVideoInfoHint;
        chkSettingsDownloadsWriteMetadataToFile = InternalEnglish.chkSettingsDownloadsWriteMetadataToFile;
        chkSettingsDownloadsWriteMetadataToFileHint = InternalEnglish.chkSettingsDownloadsWriteMetadataToFileHint;
        chkSettingsDownloadsSaveDescription = InternalEnglish.chkSettingsDownloadsSaveDescription;
        chkSettingsDownloadsSaveDescriptionHint = InternalEnglish.chkSettingsDownloadsSaveDescriptionHint;
        chkSettingsDownloadsKeepOriginalFiles = InternalEnglish.chkSettingsDownloadsKeepOriginalFiles;
        chkSettingsDownloadsKeepOriginalFilesHint = InternalEnglish.chkSettingsDownloadsKeepOriginalFilesHint;
        chkSettingsDownloadsSaveAnnotations = InternalEnglish.chkSettingsDownloadsSaveAnnotations;
        chkSettingsDownloadsSaveAnnotationsHint = InternalEnglish.chkSettingsDownloadsSaveAnnotationsHint;
        chkSettingsDownloadsSaveThumbnails = InternalEnglish.chkSettingsDownloadsSaveThumbnails;
        chkSettingsDownloadsSaveThumbnailsHint = InternalEnglish.chkSettingsDownloadsSaveThumbnailsHint;
        chkSettingsDownloadsEmbedThumbnails = InternalEnglish.chkSettingsDownloadsEmbedThumbnails;
        chkSettingsDownloadsEmbedThumbnailsHint = InternalEnglish.chkSettingsDownloadsEmbedThumbnailsHint;
        chkSettingsDownloadsSkipUnavailableFragments = InternalEnglish.chkSettingsDownloadsSkipUnavailableFragments;
        chkSettingsDownloadsSkipUnavailableFragmentsHint = InternalEnglish.chkSettingsDownloadsSkipUnavailableFragmentsHint;
        chkSettingsDownloadsAbortOnError = InternalEnglish.chkSettingsDownloadsAbortOnError;
        chkSettingsDownloadsAbortOnErrorHint = InternalEnglish.chkSettingsDownloadsAbortOnErrorHint;
        #endregion

        #region Sorting
        tabDownloadsSorting = InternalEnglish.tabDownloadsSorting;


        chkSettingsDownloadsSeparateDownloadsToDifferentFolders = InternalEnglish.chkSettingsDownloadsSeparateDownloadsToDifferentFolders;
        chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = InternalEnglish.chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint;
        chkSettingsDownloadsSeparateIntoWebsiteUrl = InternalEnglish.chkSettingsDownloadsSeparateIntoWebsiteUrl;
        chkSettingsDownloadsSeparateIntoWebsiteUrlHint = InternalEnglish.chkSettingsDownloadsSeparateIntoWebsiteUrlHint;
        chkSettingsDownloadsWebsiteSubdomains = InternalEnglish.chkSettingsDownloadsWebsiteSubdomains;
        chkSettingsDownloadsWebsiteSubdomainsHint = InternalEnglish.chkSettingsDownloadsWebsiteSubdomainsHint;
        #endregion

        #region Fixes
        tabDownloadsFixes = InternalEnglish.tabDownloadsFixes;


        chkSettingsDownloadsFixVReddIt = InternalEnglish.chkSettingsDownloadsFixVReddIt;
        chkSettingsDownloadsFixVReddItHint = InternalEnglish.chkSettingsDownloadsFixVReddItHint;
        chkSettingsDownloadsPreferFFmpeg = InternalEnglish.chkSettingsDownloadsPreferFFmpeg;
        chkSettingsDownloadsPreferFFmpegHint = InternalEnglish.chkSettingsDownloadsPreferFFmpegHint;
        #endregion

        #region Connection
        tabDownloadsConnection = InternalEnglish.tabDownloadsConnection;

        chkSettingsDownloadsLimitDownload = InternalEnglish.chkSettingsDownloadsLimitDownload;
        chkSettingsDownloadsLimitDownloadHint = InternalEnglish.chkSettingsDownloadsLimitDownloadHint;
        numSettingsDownloadsLimitDownloadHint = InternalEnglish.numSettingsDownloadsLimitDownloadHint;
        cbSettingsDownloadsLimitDownloadHint = InternalEnglish.cbSettingsDownloadsLimitDownloadHint;
        lbSettingsDownloadsRetryAttempts = InternalEnglish.lbSettingsDownloadsRetryAttempts;
        lbSettingsDownloadsRetryAttemptsHint = InternalEnglish.lbSettingsDownloadsRetryAttemptsHint;
        numSettingsDownloadsRetryAttemptsHint = InternalEnglish.numSettingsDownloadsRetryAttemptsHint;
        chkSettingsDownloadsForceIpv4 = InternalEnglish.chkSettingsDownloadsForceIpv4;
        chkSettingsDownloadsForceIpv4Hint = InternalEnglish.chkSettingsDownloadsForceIpv4Hint;
        chkSettingsDownloadsForceIpv6 = InternalEnglish.chkSettingsDownloadsForceIpv6;
        chkSettingsDownloadsForceIpv6Hint = InternalEnglish.chkSettingsDownloadsForceIpv6Hint;
        chkSettingsDownloadsUseProxy = InternalEnglish.chkSettingsDownloadsUseProxy;
        chkSettingsDownloadsUseProxyHint = InternalEnglish.chkSettingsDownloadsUseProxyHint;
        cbSettingsDownloadsProxyTypeHint = InternalEnglish.cbSettingsDownloadsProxyTypeHint;
        txtSettingsDownloadsProxyIpHint = InternalEnglish.txtSettingsDownloadsProxyIpHint;
        txtSettingsDownloadsProxyPortHint = InternalEnglish.txtSettingsDownloadsProxyPortHint;
        lbSettingsDownloadsFragmentThreads = InternalEnglish.lbSettingsDownloadsFragmentThreads;
        lbSettingsDownloadsFragmentThreadsHint = InternalEnglish.lbSettingsDownloadsFragmentThreadsHint;
        #endregion

        #region Updating
        tabDownloadsUpdating = InternalEnglish.tabDownloadsUpdating;

        chkSettingsDownloadsUseYoutubeDlsUpdater = InternalEnglish.chkSettingsDownloadsUseYoutubeDlsUpdater;
        chkSettingsDownloadsUseYoutubeDlsUpdaterHint = InternalEnglish.chkSettingsDownloadsUseYoutubeDlsUpdaterHint;
        lbSettingsDownloadsUpdatingYtdlType = InternalEnglish.lbSettingsDownloadsUpdatingYtdlType;
        cbSettingsDownloadsUpdatingYtdlTypeHint = InternalEnglish.cbSettingsDownloadsUpdatingYtdlTypeHint;
        llbSettingsDownloadsYtdlTypeViewRepo = InternalEnglish.llbSettingsDownloadsYtdlTypeViewRepo;
        llbSettingsDownloadsYtdlTypeViewRepoHint = InternalEnglish.llbSettingsDownloadsYtdlTypeViewRepoHint;
        chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = InternalEnglish.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing;
        chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = InternalEnglish.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint;
        #endregion

        #region Batch
        tabDownloadsBatch = InternalEnglish.tabDownloadsBatch;


        chkSettingsDownloadsSeparateBatchDownloads = InternalEnglish.chkSettingsDownloadsSeparateBatchDownloads;
        chkSettingsDownloadsSeparateBatchDownloadsHint = InternalEnglish.chkSettingsDownloadsSeparateBatchDownloadsHint;
        chkSettingsDownloadsAddDateToBatchDownloadFolders = InternalEnglish.chkSettingsDownloadsAddDateToBatchDownloadFolders;
        chkSettingsDownloadsAddDateToBatchDownloadFoldersHint = InternalEnglish.chkSettingsDownloadsAddDateToBatchDownloadFoldersHint;
        #endregion

        #region Extended downloader
        tabExtendedOptions = InternalEnglish.tabExtendedOptions;


        chkExtendedPreferExtendedDialog = InternalEnglish.chkExtendedPreferExtendedDialog;
        chkExtendedPreferExtendedDialogHint = InternalEnglish.chkExtendedPreferExtendedDialogHint;
        chkExtendedAutomaticallyDownloadThumbnail = InternalEnglish.chkExtendedAutomaticallyDownloadThumbnail;
        chkExtendedAutomaticallyDownloadThumbnailHint = InternalEnglish.chkExtendedAutomaticallyDownloadThumbnailHint;
        chkExtendedIncludeCustomArguments = InternalEnglish.chkExtendedIncludeCustomArguments;
        chkExtendedIncludeCustomArgumentsHint = InternalEnglish.chkExtendedIncludeCustomArguments;
        #endregion
        #endregion

        #region tabConverter
        tabSettingsConverter = InternalEnglish.tabSettingsConverter;

        chkSettingsConverterClearOutputAfterConverting = InternalEnglish.chkSettingsConverterClearOutputAfterConverting;
        chkSettingsConverterClearOutputAfterConvertingHint = InternalEnglish.chkSettingsConverterClearOutputAfterConvertingHint;
        chkSettingsConverterDetectOutputFileType = InternalEnglish.chkSettingsConverterDetectOutputFileType;
        chkSettingsConverterDetectOutputFileTypeHint = InternalEnglish.chkSettingsConverterDetectOutputFileTypeHint;
        chkSettingsConverterClearInputAfterConverting = InternalEnglish.chkSettingsConverterClearInputAfterConverting;
        chkSettingsConverterClearInputAfterConvertingHint = InternalEnglish.chkSettingsConverterClearInputAfterConvertingHint;
        chkSettingsConverterHideFFmpegCompileInfo = InternalEnglish.chkSettingsConverterHideFFmpegCompileInfo;
        chkSettingsConverterHideFFmpegCompileInfoHint = InternalEnglish.chkSettingsConverterHideFFmpegCompileInfoHint;

        #region Video
        tcSettingsConverterVideo = InternalEnglish.tcSettingsConverterVideo;

        lbSettingsConverterVideoBitrate = InternalEnglish.lbSettingsConverterVideoBitrate;
        lbSettingsConverterVideoBitrateHint = InternalEnglish.lbSettingsConverterVideoBitrateHint;
        lbSettingsConverterVideoPreset = InternalEnglish.lbSettingsConverterVideoPreset;
        lbSettingsConverterVideoPresetHint = InternalEnglish.lbSettingsConverterVideoPresetHint;
        lbSettingsConverterVideoProfile = InternalEnglish.lbSettingsConverterVideoProfile;
        lbSettingsConverterVideoProfileHint = InternalEnglish.lbSettingsConverterVideoProfileHint;
        lbSettingsConverterVideoCRF = InternalEnglish.lbSettingsConverterVideoCRF;
        lbSettingsConverterVideoCRFHint = InternalEnglish.lbSettingsConverterVideoCRFHint;
        chkSettingsConverterVideoFastStart = InternalEnglish.chkSettingsConverterVideoFastStart;
        chkSettingsConverterVideoFastStartHint = InternalEnglish.chkSettingsConverterVideoFastStartHint;
        #endregion

        #region Audio
        tcSettingsConverterAudio = InternalEnglish.tcSettingsConverterAudio;

        lbSettingsConverterAudioBitrate = InternalEnglish.lbSettingsConverterAudioBitrate;
        lbSettingsConverterAudioBitrateHint = InternalEnglish.lbSettingsConverterAudioBitrateHint;
        #endregion

        #region Custom
        tcSettingsConverterCustom = InternalEnglish.tcSettingsConverterCustom;

        lbSettingsConverterCustomHeader = InternalEnglish.lbSettingsConverterCustomHeader;
        txtSettingsConverterCustomArgumentsHint = InternalEnglish.txtSettingsConverterCustomArgumentsHint;
        #endregion
        #endregion

        #region tabExtensions
        tabSettingsExtensions = InternalEnglish.tabSettingsExtensions;

        lbSettingsExtensionsHeader = InternalEnglish.lbSettingsExtensionsHeader;
        lbSettingsExtensionsExtensionFullName = InternalEnglish.lbSettingsExtensionsExtensionFullName;
        txtSettingsExtensionsExtensionFullName = InternalEnglish.txtSettingsExtensionsExtensionFullName;
        lbSettingsExtensionsExtensionShort = InternalEnglish.lbSettingsExtensionsExtensionShort;
        txtSettingsExtensionsExtensionShort = InternalEnglish.txtSettingsExtensionsExtensionShort;
        btnSettingsExtensionsAdd = InternalEnglish.btnSettingsExtensionsAdd;
        lbSettingsExtensionsFileName = InternalEnglish.lbSettingsExtensionsFileName;
        btnSettingsExtensionsRemoveSelected = InternalEnglish.btnSettingsExtensionsRemoveSelected;
        #endregion

        #region tabErrors
        tabSettingsErrors = InternalEnglish.tabSettingsErrors;

        chkSettingsErrorsShowDetailedErrors = InternalEnglish.chkSettingsErrorsShowDetailedErrors;
        chkSettingsErrorsShowDetailedErrorsHint = InternalEnglish.chkSettingsErrorsShowDetailedErrorsHint;
        chkSettingsErrorsSaveErrorsAsErrorLog = InternalEnglish.chkSettingsErrorsSaveErrorsAsErrorLog;
        chkSettingsErrorsSaveErrorsAsErrorLogHint = InternalEnglish.chkSettingsErrorsSaveErrorsAsErrorLogHint;
        chkSettingsErrorsSuppressErrors = InternalEnglish.chkSettingsErrorsSuppressErrors;
        chkSettingsErrorsSuppressErrorsHint = InternalEnglish.chkSettingsErrorsSuppressErrorsHint;
        #endregion
        #endregion

        #region frmSubtitles
        frmSubtitles = InternalEnglish.frmSubtitles;
        lbSubtitlesHeader = InternalEnglish.lbSubtitlesHeader;
        lbSubtitlesUrl = InternalEnglish.lbSubtitlesUrl;
        lbSubtitlesLanguages = InternalEnglish.lbSubtitlesLanguages;
        btnSubtitlesAddLanguage = InternalEnglish.btnSubtitlesAddLanguage;
        btnSubtitlesClearLanguages = InternalEnglish.btnSubtitlesClearLanguages;
        btnSubtitlesDownload = InternalEnglish.btnSubtitlesDownload;
        #endregion

        #region frmTools
        frmTools = InternalEnglish.frmTools;
        btnMiscToolsRemoveAudio = InternalEnglish.btnMiscToolsRemoveAudio;
        btnMiscToolsExtractAudio = InternalEnglish.btnMiscToolsExtractAudio;
        btnMiscToolsVideoToGif = InternalEnglish.btnMiscToolsVideoToGif;
        #endregion

        #region frmUpdateAvailable
        frmUpdateAvailable = InternalEnglish.frmUpdateAvailable;
        lbUpdateAvailableHeader = InternalEnglish.lbUpdateAvailableHeader;
        lbUpdateAvailableUpdateVersion = InternalEnglish.lbUpdateAvailableUpdateVersion;
        lbUpdateAvailableCurrentVersion = InternalEnglish.lbUpdateAvailableCurrentVersion;
        lbUpdateAvailableChangelog = InternalEnglish.lbUpdateAvailableChangelog;
        lbUpdateSize = InternalEnglish.lbUpdateSize;
        btnUpdateAvailableSkipVersion = InternalEnglish.btnUpdateAvailableSkipVersion;
        btnUpdateAvailableUpdate = InternalEnglish.btnUpdateAvailableUpdate;
        #endregion
    }

    /// <summary>
    /// Resets the control names to their internal names.
    /// </summary>
    public static void ResetControlNames() {
        Log.Write("Resetting language values.");
        LoadedFile = null;

        #region Langauge identifier
        CurrentLanguageLong = nameof(CurrentLanguageLong);
        CurrentLanguageShort = nameof(CurrentLanguageShort);
        CurrentLanguageHint = nameof(CurrentLanguageHint);
        CurrentLanguageVersion = string.Empty;
        #endregion

        #region Generics
        GenericInputBest = nameof(GenericInputBest);
        GenericInputWorst = nameof(GenericInputWorst);
        GenericCancel = nameof(GenericCancel);
        GenericSkip = nameof(GenericSkip);
        GenericSound = nameof(GenericSound);
        GenericVideo = nameof(GenericVideo);
        GenericAudio = nameof(GenericAudio);
        GenericCustom = nameof(GenericCustom);
        GenericRetry = nameof(GenericRetry);
        GenericStart = nameof(GenericStart);
        GenericStop = nameof(GenericStop);
        GenericExit = nameof(GenericExit);
        GenericOk = nameof(GenericOk);
        GenericSave = nameof(GenericSave);
        GenericAdd = nameof(GenericAdd);
        GenericClose = nameof(GenericClose);
        GenericClear = nameof(GenericClear);
        GenericRemoveSelected = nameof(GenericRemoveSelected);
        GenericVerifyLinks = nameof(GenericVerifyLinks);
        GenericDoNotReEncode = nameof(GenericDoNotReEncode);
        GenericDoNotRemux = nameof(GenericDoNotRemux);
        GenericDoNotDownload = nameof(GenericDoNotDownload);
        GenericUnknownFormat = nameof(GenericUnknownFormat);
        GenericMoreInfo = nameof(GenericMoreInfo);
        GenericTitle = nameof(GenericTitle);
        GenericLength = nameof(GenericLength);
        GenericUploadedOn = nameof(GenericUploadedOn);
        GenericInput = nameof(GenericInput);
        GenericOutput = nameof(GenericOutput);
        GenericArguments = nameof(GenericArguments);
        GenericAborted = nameof(GenericAborted);
        GenericError = nameof(GenericError);
        GenericAltError = nameof(GenericAltError);
        GenericCompleted = nameof(GenericCompleted);
        GenericRemove = nameof(GenericRemove);

        frmGenericDownloadProgress = nameof(frmGenericDownloadProgress);
        chContainer = nameof(chContainer);
        chFileSize = nameof(chFileSize);
        chFormatId = nameof(chFormatId);
        chVideoQuality = nameof(chVideoQuality);
        chVideoFPS = nameof(chVideoFPS);
        chVideoBitrate = nameof(chVideoBitrate);
        chVideoDimension = nameof(chVideoDimension);
        chVideoCodec = nameof(chVideoCodec);
        chAudioBitrate = nameof(chAudioBitrate);
        chAudioSampleRate = nameof(chAudioSampleRate);
        chAudioCodec = nameof(chAudioCodec);
        chAudioChannels = nameof(chAudioChannels);
        dlBeginningDownload = nameof(dlBeginningDownload);
        cvBeginningConversion = nameof(cvBeginningConversion);
        #endregion

        #region Dialogs
        dlgFirstTimeInitialMessage = nameof(dlgFirstTimeInitialMessage);
        dlgFirstTimeDownloadFolder = nameof(dlgFirstTimeDownloadFolder);
        dlgFirstTimeDownloadYoutubeDl = nameof(dlgFirstTimeDownloadYoutubeDl);
        dlgFirstTimeDownloadFfmpeg = nameof(dlgFirstTimeDownloadFfmpeg);

        dlgClipboardAutoDownloadNotice = nameof(dlgClipboardAutoDownloadNotice);
        dlgBatchDownloadClipboardScannerNotice = nameof(dlgBatchDownloadClipboardScannerNotice);

        dlgFindDownloadFolder = nameof(dlgFindDownloadFolder);
        dlgMainArgsTxtDoesntExist = nameof(dlgMainArgsTxtDoesntExist);
        dlgMainArgsTxtIsEmpty = nameof(dlgMainArgsTxtIsEmpty);
        dlgMainArgsNoneSaved = nameof(dlgMainArgsNoneSaved);
        dlgConvertSelectFileToConvert = nameof(dlgConvertSelectFileToConvert);
        dlgMergeSelectFileToMerge = nameof(dlgMergeSelectFileToMerge);
        dlgSaveOutputFileAs = nameof(dlgSaveOutputFileAs);
        dlgLanguageHashNoMatch = nameof(dlgLanguageHashNoMatch);

        dlgAuthenticationCookiesFromBrowser = nameof(dlgAuthenticationCookiesFromBrowser);

        dlgUpdateFailedToCheck = nameof(dlgUpdateFailedToCheck);
        dlgUpdateNoUpdateAvailable = nameof(dlgUpdateNoUpdateAvailable);
        dlgUpdateNoBetaUpdateAvailable = nameof(dlgUpdateNoBetaUpdateAvailable);
        dlgUpdateNoValidYoutubeDl = nameof(dlgUpdateNoValidYoutubeDl);
        dlgUpdatedYoutubeDl = nameof(dlgUpdatedYoutubeDl);
        dlgUpateYoutubeDlNoUpdateRequired = nameof(dlgUpateYoutubeDlNoUpdateRequired);
        dlgUpdaterHashNoMatch = nameof(dlgUpdaterHashNoMatch);

        frmFileNameSchemaHistory = nameof(frmFileNameSchemaHistory);
        #endregion

        #region Shared downloader
        pbDownloadProgressFfmpegPostProcessing = nameof(pbDownloadProgressFfmpegPostProcessing);
        pbDownloadProgressEmbeddingSubtitles = nameof(pbDownloadProgressEmbeddingSubtitles);
        pbDownloadProgressEmbeddingMetadata = nameof(pbDownloadProgressEmbeddingMetadata);
        pbDownloadProgressMergingFormats = nameof(pbDownloadProgressMergingFormats);
        pbDownloadProgressConverting = nameof(pbDownloadProgressConverting);
        #endregion

        #region frmAbout
        frmAbout = nameof(frmAbout);
        lbAboutBody = nameof(lbAboutBody);
        llbCheckForUpdates = nameof(llbCheckForUpdates);
        #endregion

        #region frmArchiveDownloader
        frmArchiveDownloader = nameof(frmArchiveDownloader);
        lbArchiveDownloaderDescription = nameof(lbArchiveDownloaderDescription);
        txtArchiveDownloaderHint = nameof(txtArchiveDownloaderHint);
        #endregion

        #region frmAuthentication
        frmAuthentication = nameof(frmAuthentication);
        lbAuthNotice = nameof(lbAuthNotice);
        lbAuthUsername = nameof(lbAuthUsername);
        lbAuthPassword = nameof(lbAuthPassword);
        lbAuth2Factor = nameof(lbAuth2Factor);
        lbAuthVideoPassword = nameof(lbAuthVideoPassword);
        lbAuthCookiesFromFile = nameof(lbAuthCookiesFromFile);
        lbAuthCookiesFromBrowser = nameof(lbAuthCookiesFromBrowser);
        chkAuthUseNetrc = nameof(chkAuthUseNetrc);
        lbAuthNoSave = nameof(lbAuthNoSave);
        btnAuthBeginDownload = nameof(btnAuthBeginDownload);
        #endregion

        #region frmBatchConvert
        frmBatchConverter = nameof(frmBatchConverter);
        lbBatchConverterInput = nameof(lbBatchConverterInput);
        txtBatchConverterInputFile = nameof(txtBatchConverterInputFile);
        lbBatchConverterOutput = nameof(lbBatchConverterOutput);
        txtBatchConverterOutputFile = nameof(txtBatchConverterOutputFile);
        txtBatchConverterCustomConversionArguments = nameof(txtBatchConverterCustomConversionArguments);
        sbBatchConverterIdle = nameof(sbBatchConverterIdle);
        sbBatchConverterConverting = nameof(sbBatchConverterConverting);
        sbBatchConverterFinished = nameof(sbBatchConverterFinished);
        sbBatchConverterAborted = nameof(sbBatchConverterAborted);
        #endregion

        #region frmBatchDownload
        frmBatchDownload = nameof(frmBatchDownload);
        lbBatchDownloadLink = nameof(lbBatchDownloadLink);
        lbBatchDownloadType = nameof(lbBatchDownloadType);
        lbBatchDownloadVideoSpecificArgument = nameof(lbBatchDownloadVideoSpecificArgument);
        sbBatchDownloadLoadArgs = nameof(sbBatchDownloadLoadArgs);
        mBatchDownloaderLoadArgsFromSettings = nameof(mBatchDownloaderLoadArgsFromSettings);
        mBatchDownloaderLoadArgsFromArgsTxt = nameof(mBatchDownloaderLoadArgsFromArgsTxt);
        mBatchDownloaderLoadArgsFromFile = nameof(mBatchDownloaderLoadArgsFromFile);
        sbBatchDownloaderImportLinks = nameof(sbBatchDownloaderImportLinks);
        mBatchDownloaderImportLinksFromFile = nameof(mBatchDownloaderImportLinksFromFile);
        mBatchDownloaderImportLinksFromClipboard = nameof(mBatchDownloaderImportLinksFromClipboard);
        sbBatchDownloaderIdle = nameof(sbBatchDownloaderIdle);
        sbBatchDownloaderDownloading = nameof(sbBatchDownloaderDownloading);
        sbBatchDownloaderFinished = nameof(sbBatchDownloaderFinished);
        sbBatchDownloaderAborted = nameof(sbBatchDownloaderAborted);
        chkBatchDownloadClipboardScanner = nameof(chkBatchDownloadClipboardScanner);
        #endregion

        #region frmConverter
        frmConverter = nameof(frmConverter);
        frmConverterComplete = nameof(frmConverterComplete);
        frmConverterError = nameof(frmConverterError);
        chkConverterCloseAfterConversion = nameof(chkConverterCloseAfterConversion);
        btnConverterAbortBatchConversions = nameof(btnConverterAbortBatchConversions);
        #endregion

        #region frmDownloader
        frmDownloader = nameof(frmDownloader);
        frmDownloaderComplete = nameof(frmDownloaderComplete);
        frmDownloaderError = nameof(frmDownloaderError);
        chkDownloaderCloseAfterDownload = nameof(chkDownloaderCloseAfterDownload);
        btnDownloaderAbortBatch = nameof(btnDownloaderAbortBatch);
        #endregion

        #region frmDownloadLanuage
        frmDownloadLanguage = nameof(frmDownloadLanguage);
        #endregion

        #region frmException
        frmException = nameof(frmException);
        lbExceptionHeader = nameof(lbExceptionHeader);
        lbExceptionDescription = nameof(lbExceptionDescription);
        rtbExceptionDetails = nameof(rtbExceptionDetails);
        btnExceptionGithub = nameof(btnExceptionGithub);
        tabExceptionDetails = nameof(tabExceptionDetails);
        tabExceptionExtraInfo = nameof(tabExceptionExtraInfo);
        #endregion

        #region frmExtendedDownloader
        frmExtendedDownloaderRetrieving = nameof(frmExtendedDownloaderRetrieving);
        lbExtendedDownloaderLink = nameof(lbExtendedDownloaderLink);
        lbExtendedDownloaderUploader = nameof(lbExtendedDownloaderUploader);
        lbExtendedDownloaderViews = nameof(lbExtendedDownloaderViews);
        lbExtendedDownloaderDownloadingThumbnail = nameof(lbExtendedDownloaderDownloadingThumbnail);
        lbExtendedDownloaderDownloadingThumbnailFailed = nameof(lbExtendedDownloaderDownloadingThumbnailFailed);
        btnExtendedDownloaderDownloadThumbnail = nameof(btnExtendedDownloaderDownloadThumbnail);
        tabExtendedDownloaderUnknownFormats = nameof(tabExtendedDownloaderUnknownFormats);
        tabExtendedDownloaderDescription = nameof(tabExtendedDownloaderDescription);
        tabExtendedDownloaderVerbose = nameof(tabExtendedDownloaderVerbose);
        tabExtendedDownloaderFormatOptions = nameof(tabExtendedDownloaderFormatOptions);
        chkExtendedDownloaderVideoSeparateAudio = nameof(chkExtendedDownloaderVideoSeparateAudio);
        lbExtendedDownloaderNoVideoFormatsAvailable = nameof(lbExtendedDownloaderNoVideoFormatsAvailable);
        lbExtendedDownloaderNoAudioFormatsAvailable = nameof(lbExtendedDownloaderNoAudioFormatsAvailable);
        lbExtendedDownloaderNoUnknownFormatsFound = nameof(lbExtendedDownloaderNoUnknownFormatsFound);
        lbVideoRemux = nameof(lbVideoRemux);
        txtExtendedDownloaderMediaTitle = nameof(txtExtendedDownloaderMediaTitle);
        txtExtendedDownloaderBatchMediaTitle = nameof(txtExtendedDownloaderBatchMediaTitle);
        mExtendedDownloaderEnqueueCopyOptions = nameof(mExtendedDownloaderEnqueueCopyOptions);
        mExtendedDownloaderEnqueueWithAuthentication = nameof(mExtendedDownloaderEnqueueWithAuthentication);
        mExtendedDownloaderEnqueueCopyAuthentication = nameof(mExtendedDownloaderEnqueueCopyAuthentication);
        mExtendedDownloaderQueueCopyLink = nameof(mExtendedDownloaderQueueCopyLink);
        mExtendedDownloaderQueueViewInBrowser = nameof(mExtendedDownloaderQueueViewInBrowser);
        mExtendedDownloaderEnqueueImportLinksWithAuthentication = nameof(mExtendedDownloaderEnqueueImportLinksWithAuthentication);
        mExtendedDownloaderEnqueueImportLinksCopyOptions = nameof(mExtendedDownloaderEnqueueImportLinksCopyOptions);
        mExtendedDownloaderEnqueueImportLinksCopyAuthentication = nameof(mExtendedDownloaderEnqueueImportLinksCopyAuthentication);
        #endregion

        #region frmLanguage
        frmLanguage = nameof(frmLanguage);
        btnLanguageRefresh = nameof(btnLanguageRefresh);
        btnLanguageDownload = nameof(btnLanguageDownload);
        #endregion

        #region frmLog
        frmLog = nameof(frmLog);
        frmLogClear = nameof(frmLogClear);
        frmLogExceptions = nameof(frmLogExceptions);
        lbLogPastExceptions = nameof(lbLogPastExceptions);
        #endregion

        #region frmMain
        mSettings = nameof(mSettings);
        mTools = nameof(mTools);
        mBatch = nameof(mBatch);
        mBatchDownload = nameof(mBatchDownload);
        mBatchExtendedDownload = nameof(mBatchExtendedDownload);
        mBatchConvert = nameof(mBatchConvert);
        mArchiveDownloader = nameof(mArchiveDownloader);
        mDownloadSubtitles = nameof(mDownloadSubtitles);
        mMiscTools = nameof(mMiscTools);
        mClipboardAutoDownload = nameof(mClipboardAutoDownload);
        mHelp = nameof(mHelp);
        mLanguage = nameof(mLanguage);
        mSupportedSites = nameof(mSupportedSites);
        mAbout = nameof(mAbout);

        tabDownload = nameof(tabDownload);
        tabConvert = nameof(tabConvert);
        tabMerge = nameof(tabMerge);

        lbURL = nameof(lbURL);
        txtUrlHint = nameof(txtUrlHint);
        gbDownloadType = nameof(gbDownloadType);
        lbQuality = nameof(lbQuality);
        lbFormat = nameof(lbFormat);
        chkUseSelection = nameof(chkUseSelection);
        rbVideoSelectionPlaylistIndex = nameof(rbVideoSelectionPlaylistIndex);
        rbVideoSelectionPlaylistItems = nameof(rbVideoSelectionPlaylistItems);
        rbVideoSelectionBeforeDate = nameof(rbVideoSelectionBeforeDate);
        rbVideoSelectionOnDate = nameof(rbVideoSelectionOnDate);
        rbVideoSelectionAfterDate = nameof(rbVideoSelectionAfterDate);
        txtPlaylistStartHint = nameof(txtPlaylistStartHint);
        txtPlaylistEndHint = nameof(txtPlaylistEndHint);
        txtPlaylistItemsHint = nameof(txtPlaylistItemsHint);
        txtVideoDateHint = nameof(txtVideoDateHint);
        lbCustomArguments = nameof(lbCustomArguments);
        sbDownload = nameof(sbDownload);
        btnMainExtended = nameof(btnMainExtended);
        mDownloadWithAuthentication = nameof(mDownloadWithAuthentication);
        mBatchDownloadFromFile = nameof(mBatchDownloadFromFile);
        msgBatchDownloadFromFile = nameof(msgBatchDownloadFromFile);
        mQuickDownloadForm = nameof(mQuickDownloadForm);
        mQuickDownloadFormAuthentication = nameof(mQuickDownloadFormAuthentication);
        mExtendedDownloadForm = nameof(mExtendedDownloadForm);
        mExtendedDownloadFormAuthentication = nameof(mExtendedDownloadFormAuthentication);

        lbConvertInput = nameof(lbConvertInput);
        lbConvertOutput = nameof(lbConvertOutput);
        rbConvertAuto = nameof(rbConvertAuto);
        rbConvertAutoFFmpeg = nameof(rbConvertAutoFFmpeg);
        btnConvert = nameof(btnConvert);

        cmTrayShowForm = nameof(cmTrayShowForm);
        cmTrayDownloader = nameof(cmTrayDownloader);
        cmTrayDownloadClipboard = nameof(cmTrayDownloadClipboard);
        cmTrayDownloadBestVideo = nameof(cmTrayDownloadBestVideo);
        cmTrayDownloadBestAudio = nameof(cmTrayDownloadBestAudio);
        cmTrayDownloadCustom = nameof(cmTrayDownloadCustom);
        cmTrayDownloadCustomTxtBox = nameof(cmTrayDownloadCustomTxtBox);
        cmTrayDownloadCustomTxt = nameof(cmTrayDownloadCustomTxt);
        cmTrayDownloadCustomSettings = nameof(cmTrayDownloadCustomSettings);
        cmTrayConverter = nameof(cmTrayConverter);
        cmTrayConvertTo = nameof(cmTrayConvertTo);
        cmTrayConvertVideo = nameof(cmTrayConvertVideo);
        cmTrayConvertAudio = nameof(cmTrayConvertAudio);
        cmTrayConvertCustom = nameof(cmTrayConvertCustom);
        cmTrayConvertAutomatic = nameof(cmTrayConvertAutomatic);
        cmTrayConvertAutoFFmpeg = nameof(cmTrayConvertAutoFFmpeg);
        cmTrayExit = nameof(cmTrayExit);
        #endregion

        #region frmMerger
        frmMerger = nameof(frmMerger);
        btnMerge = nameof(btnMerge);
        frmMergerVideoSources = nameof(frmMergerVideoSources);
        frmMergerAudioSources = nameof(frmMergerAudioSources);
        frmMergerSubtitleSources = nameof(frmMergerSubtitleSources);
        frmMergerAttatchmentSources = nameof(frmMergerAttatchmentSources);
        #endregion

        #region frmSettings
        frmSettings = nameof(frmSettings);
        btnSettingsCancelHint = nameof(btnSettingsCancelHint);
        btnSettingsSaveHint = nameof(btnSettingsSaveHint);

        #region tabGeneral
        tabSettingsGeneral = nameof(tabSettingsGeneral);

        tabSettingsGeneralYoutubeDl = nameof(tabSettingsGeneralYoutubeDl);
        lbSettingsGeneralYoutubeDlPath = nameof(lbSettingsGeneralYoutubeDlPath);
        lbSettingsGeneralYoutubeDlPathHint = nameof(lbSettingsGeneralYoutubeDlPathHint);
        chkSettingsGeneralUseStaticYoutubeDl = nameof(chkSettingsGeneralUseStaticYoutubeDl);
        chkSettingsGeneralUseStaticYoutubeDlHint = nameof(chkSettingsGeneralUseStaticYoutubeDlHint);
        txtSettingsGeneralYoutubeDlPathHint = nameof(txtSettingsGeneralYoutubeDlPathHint);
        btnSettingsGeneralBrowseYoutubeDlHint = nameof(btnSettingsGeneralBrowseYoutubeDlHint);
        btnSettingsRedownloadYoutubeDl = nameof(btnSettingsRedownloadYoutubeDl);
        btnSettingsRedownloadYoutubeDlHint = nameof(btnSettingsRedownloadYoutubeDlHint);
        ofdTitleYoutubeDl = nameof(ofdTitleYoutubeDl);
        ofdFilterYoutubeDl = nameof(ofdFilterYoutubeDl);


        tabSettingsGeneralFfmpeg = nameof(tabSettingsGeneralFfmpeg);
        lbSettingsGeneralFFmpegDirectory = nameof(lbSettingsGeneralFFmpegDirectory);
        lbSettingsGeneralFFmpegDirectoryHint = nameof(lbSettingsGeneralFFmpegDirectoryHint);
        chkSettingsGeneralUseStaticFFmpeg = nameof(chkSettingsGeneralUseStaticFFmpeg);
        chkSettingsGeneralUseStaticFFmpegHint = nameof(chkSettingsGeneralUseStaticFFmpegHint);
        txtSettingsGeneralFFmpegPathHint = nameof(txtSettingsGeneralFFmpegPathHint);
        btnSettingsGeneralBrowseFFmpegHint = nameof(btnSettingsGeneralBrowseFFmpegHint);
        btnSettingsRedownloadFfmpeg = nameof(btnSettingsRedownloadFfmpeg);
        btnSettingsRedownloadFfmpegHint = nameof(btnSettingsRedownloadFfmpegHint);
        ofdTitleFFmpeg = nameof(ofdTitleFFmpeg);
        ofdFilterFFmpeg = nameof(ofdFilterFFmpeg);


        chkSettingsGeneralCheckForUpdatesOnLaunch = nameof(chkSettingsGeneralCheckForUpdatesOnLaunch);
        chkSettingsGeneralCheckForUpdatesOnLaunchHint = nameof(chkSettingsGeneralCheckForUpdatesOnLaunchHint);
        chkSettingsGeneralCheckForBetaUpdates = nameof(chkSettingsGeneralCheckForBetaUpdates);
        chkSettingsGeneralCheckForBetaUpdatesHint = nameof(chkSettingsGeneralCheckForBetaUpdatesHint);
        chkSettingsGeneralDeleteUpdaterAfterUpdating = nameof(chkSettingsGeneralDeleteUpdaterAfterUpdating);
        chkSettingsGeneralDeleteUpdaterAfterUpdatingHint = nameof(chkSettingsGeneralDeleteUpdaterAfterUpdatingHint);
        chkDeleteOldVersionAfterUpdating = nameof(chkDeleteOldVersionAfterUpdating);
        chkDeleteOldVersionAfterUpdatingHint = nameof(chkDeleteOldVersionAfterUpdatingHint);
        chkSettingsGeneralHoverOverUrlToPasteClipboard = nameof(chkSettingsGeneralHoverOverUrlToPasteClipboard);
        chkSettingsGeneralHoverOverUrlToPasteClipboardHint = nameof(chkSettingsGeneralHoverOverUrlToPasteClipboardHint);
        chkSettingsGeneralClearUrlOnDownload = nameof(chkSettingsGeneralClearUrlOnDownload);
        chkSettingsGeneralClearUrlOnDownloadHint = nameof(chkSettingsGeneralClearUrlOnDownloadHint);
        chkSettingsGeneralClearClipboardOnDownload = nameof(chkSettingsGeneralClearClipboardOnDownload);
        chkSettingsGeneralClearClipboardOnDownloadHint = nameof(chkSettingsGeneralClearClipboardOnDownloadHint);
        chkSettingsGeneralAutoUpdateYoutubeDl = nameof(chkSettingsGeneralAutoUpdateYoutubeDl);
        chkSettingsGeneralAutoUpdateYoutubeDlHint = nameof(chkSettingsGeneralAutoUpdateYoutubeDlHint);
        gbSettingsGeneralCustomArguments = nameof(gbSettingsGeneralCustomArguments);
        gbSettingsGeneralCustomArgumentsHint = nameof(gbSettingsGeneralCustomArgumentsHint);
        rbSettingsGeneralCustomArgumentsDontSave = nameof(rbSettingsGeneralCustomArgumentsDontSave);
        rbSettingsGeneralCustomArgumentsDontSaveHint = nameof(rbSettingsGeneralCustomArgumentsDontSaveHint);
        rbSettingsGeneralCustomArgumentsSaveAsArgsText = nameof(rbSettingsGeneralCustomArgumentsSaveAsArgsText);
        rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = nameof(rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint);
        rbSettingsGeneralCustomArgumentsSaveInSettings = nameof(rbSettingsGeneralCustomArgumentsSaveInSettings);
        rbSettingsGeneralCustomArgumentsSaveInSettingsHint = nameof(rbSettingsGeneralCustomArgumentsSaveInSettingsHint);
        #endregion

        #region tabDownloads
        tabSettingsDownloads = nameof(tabSettingsDownloads);

        lbSettingsDownloadsDownloadPath = nameof(lbSettingsDownloadsDownloadPath);
        lbSettingsDownloadsDownloadPathHint = nameof(lbSettingsDownloadsDownloadPathHint);
        chkSettingsDownloadsDownloadPathUseRelativePathHint = nameof(chkSettingsDownloadsDownloadPathUseRelativePathHint);
        txtSettingsDownloadsSavePathHint = nameof(txtSettingsDownloadsSavePathHint);
        btnSettingsDownloadsBrowseSavePathHint = nameof(btnSettingsDownloadsBrowseSavePathHint);
        lbSettingsDownloadsFileNameSchema = nameof(lbSettingsDownloadsFileNameSchema);
        lbSettingsDownloadsFileNameSchemaHint = nameof(lbSettingsDownloadsFileNameSchemaHint);
        llSettingsDownloadsSchemaHelpHint = nameof(llSettingsDownloadsSchemaHelpHint);
        txtSettingsDownloadsFileNameSchemaHint = nameof(txtSettingsDownloadsFileNameSchemaHint);
        btnSettingsDownloadsFileNameSchemaHistory = nameof(btnSettingsDownloadsFileNameSchemaHistory);
        btnSettingsDownloadsFileNameSchemaHistoryHint = nameof(btnSettingsDownloadsFileNameSchemaHistoryHint);
        btnSettingsDownloadsInstallProtocolNotInstalled = nameof(btnSettingsDownloadsInstallProtocolNotInstalled);
        btnSettingsDownloadsInstallProtocolInstalled = nameof(btnSettingsDownloadsInstallProtocolInstalled);
        btnSettingsDownloadsInstallProtocolHint = nameof(btnSettingsDownloadsInstallProtocolHint);


        #region General
        tabDownloadsGeneral = nameof(tabDownloadsGeneral);

        chkSettingsDownloadsSaveFormatQuality = nameof(chkSettingsDownloadsSaveFormatQuality);
        chkSettingsDownloadsSaveFormatQualityHint = nameof(chkSettingsDownloadsSaveFormatQualityHint);
        chkSettingsDownloadsDownloadSubtitles = nameof(chkSettingsDownloadsDownloadSubtitles);
        chkSettingsDownloadsDownloadSubtitlesHint = nameof(chkSettingsDownloadsDownloadSubtitlesHint);
        chkSettingsDownloadsEmbedSubtitles = nameof(chkSettingsDownloadsEmbedSubtitles);
        chkSettingsDownloadsEmbedSubtitlesHint = nameof(chkSettingsDownloadsEmbedSubtitlesHint);
        chkSettingsDownloadsSaveVideoInfo = nameof(chkSettingsDownloadsSaveVideoInfo);
        chkSettingsDownloadsSaveVideoInfoHint = nameof(chkSettingsDownloadsSaveVideoInfoHint);
        chkSettingsDownloadsWriteMetadataToFile = nameof(chkSettingsDownloadsWriteMetadataToFile);
        chkSettingsDownloadsWriteMetadataToFileHint = nameof(chkSettingsDownloadsWriteMetadataToFileHint);
        chkSettingsDownloadsSaveDescription = nameof(chkSettingsDownloadsSaveDescription);
        chkSettingsDownloadsSaveDescriptionHint = nameof(chkSettingsDownloadsSaveDescriptionHint);
        chkSettingsDownloadsKeepOriginalFiles = nameof(chkSettingsDownloadsKeepOriginalFiles);
        chkSettingsDownloadsKeepOriginalFilesHint = nameof(chkSettingsDownloadsKeepOriginalFilesHint);
        chkSettingsDownloadsSaveAnnotations = nameof(chkSettingsDownloadsSaveAnnotations);
        chkSettingsDownloadsSaveAnnotationsHint = nameof(chkSettingsDownloadsSaveAnnotationsHint);
        chkSettingsDownloadsSaveThumbnails = nameof(chkSettingsDownloadsSaveThumbnails);
        chkSettingsDownloadsSaveThumbnailsHint = nameof(chkSettingsDownloadsSaveThumbnailsHint);
        chkSettingsDownloadsEmbedThumbnails = nameof(chkSettingsDownloadsEmbedThumbnails);
        chkSettingsDownloadsEmbedThumbnailsHint = nameof(chkSettingsDownloadsEmbedThumbnailsHint);
        chkSettingsDownloadsSkipUnavailableFragments = nameof(chkSettingsDownloadsSkipUnavailableFragments);
        chkSettingsDownloadsSkipUnavailableFragmentsHint = nameof(chkSettingsDownloadsSkipUnavailableFragmentsHint);
        chkSettingsDownloadsAbortOnError = nameof(chkSettingsDownloadsAbortOnError);
        chkSettingsDownloadsAbortOnErrorHint = nameof(chkSettingsDownloadsAbortOnErrorHint);
        #endregion

        #region Sorting
        tabDownloadsSorting = nameof(tabDownloadsSorting);


        chkSettingsDownloadsSeparateDownloadsToDifferentFolders = nameof(chkSettingsDownloadsSeparateDownloadsToDifferentFolders);
        chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = nameof(chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint);
        chkSettingsDownloadsSeparateIntoWebsiteUrl = nameof(chkSettingsDownloadsSeparateIntoWebsiteUrl);
        chkSettingsDownloadsSeparateIntoWebsiteUrlHint = nameof(chkSettingsDownloadsSeparateIntoWebsiteUrlHint);
        chkSettingsDownloadsWebsiteSubdomains = nameof(chkSettingsDownloadsWebsiteSubdomains);
        chkSettingsDownloadsWebsiteSubdomainsHint = nameof(chkSettingsDownloadsWebsiteSubdomainsHint);
        #endregion

        #region Fixes
        tabDownloadsFixes = nameof(tabDownloadsFixes);


        chkSettingsDownloadsFixVReddIt = nameof(chkSettingsDownloadsFixVReddIt);
        chkSettingsDownloadsFixVReddItHint = nameof(chkSettingsDownloadsFixVReddItHint);
        chkSettingsDownloadsPreferFFmpeg = nameof(chkSettingsDownloadsPreferFFmpeg);
        chkSettingsDownloadsPreferFFmpegHint = nameof(chkSettingsDownloadsPreferFFmpegHint);
        #endregion

        #region Connection
        tabDownloadsConnection = nameof(tabDownloadsConnection);


        chkSettingsDownloadsLimitDownload = nameof(chkSettingsDownloadsLimitDownload);
        chkSettingsDownloadsLimitDownloadHint = nameof(chkSettingsDownloadsLimitDownloadHint);
        numSettingsDownloadsLimitDownloadHint = nameof(numSettingsDownloadsLimitDownloadHint);
        cbSettingsDownloadsLimitDownloadHint = nameof(cbSettingsDownloadsLimitDownloadHint);
        lbSettingsDownloadsRetryAttempts = nameof(lbSettingsDownloadsRetryAttempts);
        lbSettingsDownloadsRetryAttemptsHint = nameof(lbSettingsDownloadsRetryAttemptsHint);
        numSettingsDownloadsRetryAttemptsHint = nameof(numSettingsDownloadsRetryAttemptsHint);
        chkSettingsDownloadsForceIpv4 = nameof(chkSettingsDownloadsForceIpv4);
        chkSettingsDownloadsForceIpv4Hint = nameof(chkSettingsDownloadsForceIpv4Hint);
        chkSettingsDownloadsForceIpv6 = nameof(chkSettingsDownloadsForceIpv6);
        chkSettingsDownloadsForceIpv6Hint = nameof(chkSettingsDownloadsForceIpv6Hint);
        chkSettingsDownloadsUseProxy = nameof(chkSettingsDownloadsUseProxy);
        chkSettingsDownloadsUseProxyHint = nameof(chkSettingsDownloadsUseProxyHint);
        cbSettingsDownloadsProxyTypeHint = nameof(cbSettingsDownloadsProxyTypeHint);
        txtSettingsDownloadsProxyIpHint = nameof(txtSettingsDownloadsProxyIpHint);
        txtSettingsDownloadsProxyPortHint = nameof(txtSettingsDownloadsProxyPortHint);
        lbSettingsDownloadsFragmentThreads = nameof(lbSettingsDownloadsFragmentThreads);
        lbSettingsDownloadsFragmentThreadsHint = nameof(lbSettingsDownloadsFragmentThreadsHint);
        #endregion

        #region Updating
        tabDownloadsUpdating = nameof(tabDownloadsUpdating);

        chkSettingsDownloadsUseYoutubeDlsUpdater = nameof(chkSettingsDownloadsUseYoutubeDlsUpdater);
        chkSettingsDownloadsUseYoutubeDlsUpdaterHint = nameof(chkSettingsDownloadsUseYoutubeDlsUpdaterHint);
        lbSettingsDownloadsUpdatingYtdlType = nameof(lbSettingsDownloadsUpdatingYtdlType);
        cbSettingsDownloadsUpdatingYtdlTypeHint = nameof(cbSettingsDownloadsUpdatingYtdlTypeHint);
        llbSettingsDownloadsYtdlTypeViewRepo = nameof(llbSettingsDownloadsYtdlTypeViewRepo);
        llbSettingsDownloadsYtdlTypeViewRepoHint = nameof(llbSettingsDownloadsYtdlTypeViewRepoHint);
        chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = nameof(chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing);
        chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = nameof(chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint);
        #endregion

        #region Batch
        tabDownloadsBatch = nameof(tabDownloadsBatch);


        chkSettingsDownloadsSeparateBatchDownloads = nameof(chkSettingsDownloadsSeparateBatchDownloads);
        chkSettingsDownloadsSeparateBatchDownloadsHint = nameof(chkSettingsDownloadsSeparateBatchDownloadsHint);
        chkSettingsDownloadsAddDateToBatchDownloadFolders = nameof(chkSettingsDownloadsAddDateToBatchDownloadFolders);
        chkSettingsDownloadsAddDateToBatchDownloadFoldersHint = nameof(chkSettingsDownloadsAddDateToBatchDownloadFoldersHint);
        #endregion

        #region Extended downloader
        tabExtendedOptions = nameof(tabExtendedOptions);


        chkExtendedPreferExtendedDialog = nameof(chkExtendedPreferExtendedDialog);
        chkExtendedPreferExtendedDialogHint = nameof(chkExtendedPreferExtendedDialogHint);
        chkExtendedAutomaticallyDownloadThumbnail = nameof(chkExtendedAutomaticallyDownloadThumbnail);
        chkExtendedAutomaticallyDownloadThumbnailHint = nameof(chkExtendedAutomaticallyDownloadThumbnailHint);
        chkExtendedIncludeCustomArguments = nameof(chkExtendedIncludeCustomArguments);
        chkExtendedIncludeCustomArgumentsHint = nameof(chkExtendedIncludeCustomArgumentsHint);
        #endregion
        #endregion

        #region tabConverter
        tabSettingsConverter = nameof(tabSettingsConverter);

        chkSettingsConverterClearOutputAfterConverting = nameof(chkSettingsConverterClearOutputAfterConverting);
        chkSettingsConverterClearOutputAfterConvertingHint = nameof(chkSettingsConverterClearOutputAfterConvertingHint);
        chkSettingsConverterDetectOutputFileType = nameof(chkSettingsConverterDetectOutputFileType);
        chkSettingsConverterDetectOutputFileTypeHint = nameof(chkSettingsConverterDetectOutputFileTypeHint);
        chkSettingsConverterClearInputAfterConverting = nameof(chkSettingsConverterClearInputAfterConverting);
        chkSettingsConverterClearInputAfterConvertingHint = nameof(chkSettingsConverterClearInputAfterConvertingHint);
        chkSettingsConverterHideFFmpegCompileInfo = nameof(chkSettingsConverterHideFFmpegCompileInfo);
        chkSettingsConverterHideFFmpegCompileInfoHint = nameof(chkSettingsConverterHideFFmpegCompileInfoHint);

        #region Video
        tcSettingsConverterVideo = nameof(tcSettingsConverterVideo);

        lbSettingsConverterVideoBitrate = nameof(lbSettingsConverterVideoBitrate);
        lbSettingsConverterVideoBitrateHint = nameof(lbSettingsConverterVideoBitrateHint);
        lbSettingsConverterVideoPreset = nameof(lbSettingsConverterVideoPreset);
        lbSettingsConverterVideoPresetHint = nameof(lbSettingsConverterVideoPresetHint);
        lbSettingsConverterVideoProfile = nameof(lbSettingsConverterVideoProfile);
        lbSettingsConverterVideoProfileHint = nameof(lbSettingsConverterVideoProfileHint);
        lbSettingsConverterVideoCRF = nameof(lbSettingsConverterVideoCRF);
        lbSettingsConverterVideoCRFHint = nameof(lbSettingsConverterVideoCRFHint);
        chkSettingsConverterVideoFastStart = nameof(chkSettingsConverterVideoFastStart);
        chkSettingsConverterVideoFastStartHint = nameof(chkSettingsConverterVideoFastStartHint);
        #endregion

        #region Audio
        tcSettingsConverterAudio = nameof(tcSettingsConverterAudio);

        lbSettingsConverterAudioBitrate = nameof(lbSettingsConverterAudioBitrate);
        lbSettingsConverterAudioBitrateHint = nameof(lbSettingsConverterAudioBitrateHint);
        #endregion

        #region Custom
        tcSettingsConverterCustom = nameof(tcSettingsConverterCustom);

        lbSettingsConverterCustomHeader = nameof(lbSettingsConverterCustomHeader);
        txtSettingsConverterCustomArgumentsHint = nameof(txtSettingsConverterCustomArgumentsHint);
        #endregion
        #endregion

        #region tabExtensions
        tabSettingsExtensions = nameof(tabSettingsExtensions);

        lbSettingsExtensionsHeader = nameof(lbSettingsExtensionsHeader);
        lbSettingsExtensionsExtensionFullName = nameof(lbSettingsExtensionsExtensionFullName);
        txtSettingsExtensionsExtensionFullName = nameof(txtSettingsExtensionsExtensionFullName);
        lbSettingsExtensionsExtensionShort = nameof(lbSettingsExtensionsExtensionShort);
        txtSettingsExtensionsExtensionShort = nameof(txtSettingsExtensionsExtensionShort);
        btnSettingsExtensionsAdd = nameof(btnSettingsExtensionsAdd);
        lbSettingsExtensionsFileName = nameof(lbSettingsExtensionsFileName);
        btnSettingsExtensionsRemoveSelected = nameof(btnSettingsExtensionsRemoveSelected);
        #endregion

        #region tabErrors
        tabSettingsErrors = nameof(tabSettingsErrors);

        chkSettingsErrorsShowDetailedErrors = nameof(chkSettingsErrorsShowDetailedErrors);
        chkSettingsErrorsShowDetailedErrorsHint = nameof(chkSettingsErrorsShowDetailedErrorsHint);
        chkSettingsErrorsSaveErrorsAsErrorLog = nameof(chkSettingsErrorsSaveErrorsAsErrorLog);
        chkSettingsErrorsSaveErrorsAsErrorLogHint = nameof(chkSettingsErrorsSaveErrorsAsErrorLogHint);
        chkSettingsErrorsSuppressErrors = nameof(chkSettingsErrorsSuppressErrors);
        chkSettingsErrorsSuppressErrorsHint = nameof(chkSettingsErrorsSuppressErrorsHint);
        #endregion
        #endregion

        #region frmSubtitles
        frmSubtitles = nameof(frmSubtitles);
        lbSubtitlesHeader = nameof(lbSubtitlesHeader);
        lbSubtitlesUrl = nameof(lbSubtitlesUrl);
        lbSubtitlesLanguages = nameof(lbSubtitlesLanguages);
        btnSubtitlesAddLanguage = nameof(btnSubtitlesAddLanguage);
        btnSubtitlesClearLanguages = nameof(btnSubtitlesClearLanguages);
        btnSubtitlesDownload = nameof(btnSubtitlesDownload);
        #endregion

        #region frmTools
        frmTools = nameof(frmTools);
        btnMiscToolsRemoveAudio = nameof(btnMiscToolsRemoveAudio);
        btnMiscToolsExtractAudio = nameof(btnMiscToolsExtractAudio);
        btnMiscToolsVideoToGif = nameof(btnMiscToolsVideoToGif);
        #endregion

        #region frmUpdateAvailable
        frmUpdateAvailable = nameof(frmUpdateAvailable);
        lbUpdateAvailableHeader = nameof(lbUpdateAvailableHeader);
        lbUpdateAvailableUpdateVersion = nameof(lbUpdateAvailableUpdateVersion);
        lbUpdateAvailableCurrentVersion = nameof(lbUpdateAvailableCurrentVersion);
        lbUpdateAvailableChangelog = nameof(lbUpdateAvailableChangelog);
        lbUpdateSize = nameof(lbUpdateSize);
        btnUpdateAvailableSkipVersion = nameof(btnUpdateAvailableSkipVersion);
        btnUpdateAvailableUpdate = nameof(btnUpdateAvailableUpdate);
        #endregion
    }
    #endregion

    #region Load Language File
    /// <summary>
    /// Loads the ini file for the Language file, based on the ini structure.
    /// </summary>
    /// <param name="LanguageFile">The string of the location of the language file.</param>
    /// <returns>Returns a boolean based on success.</returns>
    public static bool LoadLanguage(string LanguageFile = null) {
        try {
            ResetControlNames(); // Load the control IDs for any untranslated & undocumented strings

            if (LanguageFile.IsNullEmptyWhitespace() || !System.IO.File.Exists(LanguageFile)) {
                LoadInternalEnglish();
                LoadedFile = null;
                UsingInternalEnglish = true;
                LocalizationChanged();
                return true;
            }
            else {
                if (!LanguageFile.EndsWith(".ini")) { LanguageFile += ".ini"; }
                Log.Write($"Loading external language file \"{System.IO.Path.GetFileName(LanguageFile)}\".");

                using System.IO.StreamReader ReadLanguageFile = new(LanguageFile);
                string ReadLine;    // The line of the file
                while ((ReadLine = ReadLanguageFile.ReadLine()) != null) {
                    if (ReadLine.StartsWith("//") || string.IsNullOrWhiteSpace(ReadLine))
                        continue;
                    else if (ReadLine.StartsWith("[") && ReadLine.Contains("]")) {
                        ReadHeaderValue(ReadLine, out string ReadHeader);

                        if (ReadHeader == null) {
                            throw new Exception("Unable to read the language ini header\nReadValue returned null.\nProblematic line is \"" + ReadLine + "\"\n\n");
                        }
                        else
                            CurrentLanguageLong = ReadHeader;
                    }
                    else if (ReadLine.Contains("=")) {
                        GetControlInfo(ReadLine, out string ReadControl, out string ReadValue);

                        switch (ReadControl) {

                            #region Language File
                            case nameof(CurrentLanguageShort):
                                CurrentLanguageShort = ReadValue;
                                continue;
                            case nameof(CurrentLanguageHint):
                                CurrentLanguageHint = ReadValue;
                                continue;
                            case nameof(CurrentLanguageVersion):
                                CurrentLanguageVersion = ReadValue;
                                continue;
                            #endregion

                            #region Generics
                            case nameof(GenericInputBest):
                                GenericInputBest = ReadValue;
                                continue;
                            case nameof(GenericInputWorst):
                                GenericInputWorst = ReadValue;
                                continue;
                            case nameof(GenericCancel):
                                GenericCancel = ReadValue;
                                continue;
                            case nameof(GenericSkip):
                                GenericSkip = ReadValue;
                                continue;
                            case nameof(GenericSound):
                                GenericSound = ReadValue;
                                continue;
                            case nameof(GenericVideo):
                                GenericVideo = ReadValue;
                                continue;
                            case nameof(GenericAudio):
                                GenericAudio = ReadValue;
                                continue;
                            case nameof(GenericCustom):
                                GenericCustom = ReadValue;
                                continue;
                            case nameof(GenericRetry):
                                GenericRetry = ReadValue;
                                continue;
                            case nameof(GenericStart):
                                GenericStart = ReadValue;
                                continue;
                            case nameof(GenericStop):
                                GenericStop = ReadValue;
                                continue;
                            case nameof(GenericExit):
                                GenericExit = ReadValue;
                                continue;
                            case nameof(GenericOk):
                                GenericOk = ReadValue;
                                continue;
                            case nameof(GenericSave):
                                GenericSave = ReadValue;
                                continue;
                            case nameof(GenericAdd):
                                GenericAdd = ReadValue;
                                continue;
                            case nameof(GenericClose):
                                GenericClose = ReadValue;
                                continue;
                            case nameof(GenericClear):
                                GenericClear = ReadValue;
                                continue;
                            case nameof(GenericRemoveSelected):
                                GenericRemoveSelected = ReadValue;
                                continue;
                            case nameof(GenericVerifyLinks):
                                GenericVerifyLinks = ReadValue;
                                continue;
                            case nameof(GenericDoNotReEncode):
                                GenericDoNotReEncode = ReadValue;
                                continue;
                            case nameof(GenericDoNotRemux):
                                GenericDoNotRemux = ReadValue;
                                continue;
                            case nameof(GenericDoNotDownload):
                                GenericDoNotDownload = ReadValue;
                                continue;
                            case nameof(GenericUnknownFormat):
                                GenericUnknownFormat = ReadValue;
                                continue;
                            case nameof(GenericMoreInfo):
                                GenericMoreInfo = ReadValue;
                                continue;
                            case nameof(GenericTitle):
                                GenericTitle = ReadValue;
                                continue;
                            case nameof(GenericLength):
                                GenericLength = ReadValue;
                                continue;
                            case nameof(GenericUploadedOn):
                                GenericUploadedOn = ReadValue;
                                continue;
                            case nameof(GenericInput):
                                GenericInput = ReadValue;
                                continue;
                            case nameof(GenericOutput):
                                GenericOutput = ReadValue;
                                continue;
                            case nameof(GenericArguments):
                                GenericArguments = ReadValue;
                                continue;
                            case nameof(GenericAborted):
                                GenericAborted = ReadValue;
                                continue;
                            case nameof(GenericError):
                                GenericError = ReadValue;
                                continue;
                            case nameof(GenericAltError):
                                GenericAltError = ReadValue;
                                continue;
                            case nameof(GenericCompleted):
                                GenericCompleted = ReadValue;
                                continue;
                            case nameof(GenericRemove):
                                GenericRemove = ReadValue;
                                continue;

                            case nameof(frmGenericDownloadProgress):
                                frmGenericDownloadProgress = ReadValue;
                                continue;
                            case nameof(chContainer):
                                chContainer = ReadValue;
                                continue;
                            case nameof(chFileSize):
                                chFileSize = ReadValue;
                                continue;
                            case nameof(chFormatId):
                                chFormatId = ReadValue;
                                continue;
                            case nameof(chVideoQuality):
                                chVideoQuality = ReadValue;
                                continue;
                            case nameof(chVideoFPS):
                                chVideoFPS = ReadValue;
                                continue;
                            case nameof(chVideoBitrate):
                                chVideoBitrate = ReadValue;
                                continue;
                            case nameof(chVideoDimension):
                                chVideoDimension = ReadValue;
                                continue;
                            case nameof(chVideoCodec):
                                chVideoCodec = ReadValue;
                                continue;
                            case nameof(chAudioBitrate):
                                chAudioBitrate = ReadValue;
                                continue;
                            case nameof(chAudioSampleRate):
                                chAudioSampleRate = ReadValue;
                                continue;
                            case nameof(chAudioCodec):
                                chAudioCodec = ReadValue;
                                continue;
                            case nameof(chAudioChannels):
                                chAudioChannels = ReadValue;
                                continue;
                            case nameof(dlBeginningDownload):
                                dlBeginningDownload = ReadValue;
                                continue;
                            case nameof(cvBeginningConversion):
                                cvBeginningConversion = ReadValue;
                                continue;
                            #endregion

                            #region Dialogs
                            case nameof(dlgFirstTimeInitialMessage):
                                dlgFirstTimeInitialMessage = ReadValue;
                                continue;
                            case nameof(dlgFirstTimeDownloadFolder):
                                dlgFirstTimeDownloadFolder = ReadValue;
                                continue;
                            case nameof(dlgFindDownloadFolder):
                                dlgFindDownloadFolder = ReadValue;
                                continue;
                            case nameof(dlgFirstTimeDownloadYoutubeDl):
                                dlgFirstTimeDownloadYoutubeDl = ReadValue;
                                continue;
                            case nameof(dlgFirstTimeDownloadFfmpeg):
                                dlgFirstTimeDownloadFfmpeg = ReadValue;
                                continue;

                            case nameof(dlgClipboardAutoDownloadNotice):
                                dlgClipboardAutoDownloadNotice = ReadValue;
                                continue;
                            case nameof(dlgBatchDownloadClipboardScannerNotice):
                                dlgBatchDownloadClipboardScannerNotice = ReadValue;
                                continue;

                            case nameof(dlgMainArgsTxtDoesntExist):
                                dlgMainArgsTxtDoesntExist = ReadValue;
                                continue;
                            case nameof(dlgMainArgsTxtIsEmpty):
                                dlgMainArgsTxtIsEmpty = ReadValue;
                                continue;
                            case nameof(dlgMainArgsNoneSaved):
                                dlgMainArgsNoneSaved = ReadValue;
                                continue;
                            case nameof(dlgConvertSelectFileToConvert):
                                dlgConvertSelectFileToConvert = ReadValue;
                                continue;
                            case nameof(dlgMergeSelectFileToMerge):
                                dlgMergeSelectFileToMerge = ReadValue;
                                continue;
                            case nameof(dlgSaveOutputFileAs):
                                dlgSaveOutputFileAs = ReadValue;
                                continue;
                            case nameof(dlgLanguageHashNoMatch):
                                dlgLanguageHashNoMatch = ReadValue;
                                continue;

                            case nameof(dlgAuthenticationCookiesFromBrowser):
                                dlgAuthenticationCookiesFromBrowser = ReadValue;
                                continue;

                            case nameof(dlgUpdateFailedToCheck):
                                dlgUpdateFailedToCheck = ReadValue;
                                continue;
                            case nameof(dlgUpdateNoUpdateAvailable):
                                dlgUpdateNoUpdateAvailable = ReadValue;
                                continue;
                            case nameof(dlgUpdateNoBetaUpdateAvailable):
                                dlgUpdateNoBetaUpdateAvailable = ReadValue;
                                continue;
                            case nameof(dlgUpdateNoValidYoutubeDl):
                                dlgUpdateNoValidYoutubeDl = ReadValue;
                                continue;
                            case nameof(dlgUpdatedYoutubeDl):
                                dlgUpdatedYoutubeDl = ReadValue;
                                continue;
                            case nameof(dlgUpateYoutubeDlNoUpdateRequired):
                                dlgUpateYoutubeDlNoUpdateRequired = ReadValue;
                                continue;
                            case nameof(dlgUpdaterHashNoMatch):
                                dlgUpdaterHashNoMatch = ReadValue;
                                continue;

                            case nameof(frmFileNameSchemaHistory):
                                frmFileNameSchemaHistory = ReadValue;
                                continue;
                            #endregion

                            #region Shared downloader
                            case nameof(pbDownloadProgressFfmpegPostProcessing):
                                pbDownloadProgressFfmpegPostProcessing = ReadValue;
                                continue;
                            case nameof(pbDownloadProgressEmbeddingSubtitles):
                                pbDownloadProgressEmbeddingSubtitles = ReadValue;
                                continue;
                            case nameof(pbDownloadProgressEmbeddingMetadata):
                                pbDownloadProgressEmbeddingMetadata = ReadValue;
                                continue;
                            case nameof(pbDownloadProgressMergingFormats):
                                pbDownloadProgressMergingFormats = ReadValue;
                                continue;
                            case nameof(pbDownloadProgressConverting):
                                pbDownloadProgressConverting = ReadValue;
                                continue;
                            #endregion

                            #region frmAbout
                            case nameof(frmAbout):
                                frmAbout = ReadValue;
                                continue;
                            case nameof(lbAboutBody):
                                lbAboutBody = ReadValue;
                                continue;
                            case nameof(llbCheckForUpdates):
                                llbCheckForUpdates = ReadValue;
                                continue;
                            #endregion

                            #region frmArchiveDownloader
                            case nameof(frmArchiveDownloader):
                                frmArchiveDownloader = ReadValue;
                                continue;
                            case nameof(lbArchiveDownloaderDescription):
                                lbArchiveDownloaderDescription = ReadValue;
                                continue;
                            case nameof(txtArchiveDownloaderHint):
                                txtArchiveDownloaderHint = ReadValue;
                                continue;
                            #endregion

                            #region frmAuthentication
                            case nameof(frmAuthentication):
                                frmAuthentication = ReadValue;
                                continue;
                            case nameof(lbAuthNotice):
                                lbAuthNotice = ReadValue;
                                continue;
                            case nameof(lbAuthUsername):
                                lbAuthUsername = ReadValue;
                                continue;
                            case nameof(lbAuthPassword):
                                lbAuthPassword = ReadValue;
                                continue;
                            case nameof(lbAuth2Factor):
                                lbAuth2Factor = ReadValue;
                                continue;
                            case nameof(lbAuthCookiesFromFile):
                                lbAuthCookiesFromFile = ReadValue;
                                continue;
                            case nameof(lbAuthCookiesFromBrowser):
                                lbAuthCookiesFromBrowser = ReadValue;
                                continue;
                            case nameof(lbAuthVideoPassword):
                                lbAuthVideoPassword = ReadValue;
                                continue;
                            case nameof(chkAuthUseNetrc):
                                chkAuthUseNetrc = ReadValue;
                                continue;
                            case nameof(lbAuthNoSave):
                                lbAuthNoSave = ReadValue;
                                continue;
                            case nameof(btnAuthBeginDownload):
                                btnAuthBeginDownload = ReadValue;
                                continue;
                            #endregion

                            #region frmBatchConverter
                            case nameof(frmBatchConverter):
                                frmBatchConverter = ReadValue;
                                continue;
                            case nameof(lbBatchConverterInput):
                                lbBatchConverterInput = ReadValue;
                                continue;
                            case nameof(txtBatchConverterInputFile):
                                txtBatchConverterInputFile = ReadValue;
                                continue;
                            case nameof(lbBatchConverterOutput):
                                lbBatchConverterOutput = ReadValue;
                                continue;
                            case nameof(txtBatchConverterOutputFile):
                                txtBatchConverterOutputFile = ReadValue;
                                continue;
                            case nameof(txtBatchConverterCustomConversionArguments):
                                txtBatchConverterCustomConversionArguments = ReadValue;
                                continue;
                            case nameof(sbBatchConverterIdle):
                                sbBatchConverterIdle = ReadValue;
                                continue;
                            case nameof(sbBatchConverterConverting):
                                sbBatchConverterConverting = ReadValue;
                                continue;
                            case nameof(sbBatchConverterFinished):
                                sbBatchConverterFinished = ReadValue;
                                continue;
                            case nameof(sbBatchConverterAborted):
                                sbBatchConverterAborted = ReadValue;
                                continue;
                            #endregion

                            #region frmBatchDownloader
                            // frmBatchDownloader
                            case nameof(frmBatchDownload):
                                frmBatchDownload = ReadValue;
                                continue;
                            case nameof(lbBatchDownloadLink):
                                lbBatchDownloadLink = ReadValue;
                                continue;
                            case nameof(lbBatchDownloadType):
                                lbBatchDownloadType = ReadValue;
                                continue;
                            case nameof(lbBatchDownloadVideoSpecificArgument):
                                lbBatchDownloadVideoSpecificArgument = ReadValue;
                                continue;
                            case nameof(sbBatchDownloadLoadArgs):
                                sbBatchDownloadLoadArgs = ReadValue;
                                continue;
                            case nameof(mBatchDownloaderLoadArgsFromSettings):
                                mBatchDownloaderLoadArgsFromSettings = ReadValue;
                                continue;
                            case nameof(mBatchDownloaderLoadArgsFromArgsTxt):
                                mBatchDownloaderLoadArgsFromArgsTxt = ReadValue;
                                continue;
                            case nameof(mBatchDownloaderLoadArgsFromFile):
                                mBatchDownloaderLoadArgsFromFile = ReadValue;
                                continue;
                            case nameof(sbBatchDownloaderImportLinks):
                                sbBatchDownloaderImportLinks = ReadValue;
                                continue;
                            case nameof(mBatchDownloaderImportLinksFromFile):
                                mBatchDownloaderImportLinksFromFile = ReadValue;
                                continue;
                            case nameof(mBatchDownloaderImportLinksFromClipboard):
                                mBatchDownloaderImportLinksFromClipboard = ReadValue;
                                continue;
                            case nameof(sbBatchDownloaderIdle):
                                sbBatchDownloaderIdle = ReadValue;
                                continue;
                            case nameof(sbBatchDownloaderDownloading):
                                sbBatchDownloaderDownloading = ReadValue;
                                continue;
                            case nameof(sbBatchDownloaderFinished):
                                sbBatchDownloaderFinished = ReadValue;
                                continue;
                            case nameof(sbBatchDownloaderAborted):
                                sbBatchDownloaderAborted = ReadValue;
                                continue;
                            case nameof(chkBatchDownloadClipboardScanner):
                                chkBatchDownloadClipboardScanner = ReadValue;
                                continue;
                            #endregion

                            #region frmConverter
                            case nameof(frmConverter):
                                frmConverter = ReadValue;
                                continue;
                            case nameof(frmConverterComplete):
                                frmConverterComplete = ReadValue;
                                continue;
                            case nameof(frmConverterError):
                                frmConverterError = ReadValue;
                                continue;
                            case nameof(chkConverterCloseAfterConversion):
                                chkConverterCloseAfterConversion = ReadValue;
                                continue;
                            case nameof(btnConverterAbortBatchConversions):
                                btnConverterAbortBatchConversions = ReadValue;
                                continue;
                            #endregion

                            #region frmDownloader
                            case nameof(frmDownloader):
                                frmDownloader = ReadValue;
                                continue;
                            case nameof(frmDownloaderComplete):
                                frmDownloaderComplete = ReadValue;
                                continue;
                            case nameof(frmDownloaderError):
                                frmDownloaderError = ReadValue;
                                continue;
                            case nameof(chkDownloaderCloseAfterDownload):
                                chkDownloaderCloseAfterDownload = ReadValue;
                                continue;
                            case nameof(btnDownloaderAbortBatch):
                                btnDownloaderAbortBatch = ReadValue;
                                continue;
                            #endregion

                            #region frmDownloadLanguage
                            case nameof(frmDownloadLanguage):
                                frmDownloadLanguage = ReadValue;
                                continue;
                            #endregion

                            #region frmException
                            case nameof(frmException):
                                frmException = ReadValue;
                                continue;
                            case nameof(lbExceptionHeader):
                                lbExceptionHeader = ReadValue;
                                continue;
                            case nameof(lbExceptionDescription):
                                lbExceptionDescription = ReadValue;
                                continue;
                            case nameof(rtbExceptionDetails):
                                rtbExceptionDetails = ReadValue;
                                continue;
                            case nameof(btnExceptionGithub):
                                btnExceptionGithub = ReadValue;
                                continue;
                            case nameof(tabExceptionDetails):
                                tabExceptionDetails = ReadValue;
                                continue;
                            case nameof(tabExceptionExtraInfo):
                                tabExceptionExtraInfo = ReadValue;
                                continue;
                            #endregion

                            #region frmExtendedDownloader
                            case nameof(frmExtendedDownloaderRetrieving):
                                frmExtendedDownloaderRetrieving = ReadValue;
                                continue;
                            case nameof(lbExtendedDownloaderLink):
                                lbExtendedDownloaderLink = ReadValue;
                                continue;
                            case nameof(lbExtendedDownloaderUploader):
                                lbExtendedDownloaderUploader = ReadValue;
                                continue;
                            case nameof(lbExtendedDownloaderViews):
                                lbExtendedDownloaderViews = ReadValue;
                                continue;
                            case nameof(lbExtendedDownloaderDownloadingThumbnail):
                                lbExtendedDownloaderDownloadingThumbnail = ReadValue;
                                continue;
                            case nameof(lbExtendedDownloaderDownloadingThumbnailFailed):
                                lbExtendedDownloaderDownloadingThumbnailFailed = ReadValue;
                                continue;
                            case nameof(btnExtendedDownloaderDownloadThumbnail):
                                btnExtendedDownloaderDownloadThumbnail = ReadValue;
                                continue;
                            case nameof(tabExtendedDownloaderFormatOptions):
                                tabExtendedDownloaderFormatOptions = ReadValue;
                                continue;
                            case nameof(tabExtendedDownloaderUnknownFormats):
                                tabExtendedDownloaderUnknownFormats = ReadValue;
                                continue;
                            case nameof(tabExtendedDownloaderDescription):
                                tabExtendedDownloaderDescription = ReadValue;
                                continue;
                            case nameof(tabExtendedDownloaderVerbose):
                                tabExtendedDownloaderVerbose = ReadValue;
                                continue;
                            case nameof(chkExtendedDownloaderVideoSeparateAudio):
                                chkExtendedDownloaderVideoSeparateAudio = ReadValue;
                                continue;
                            case nameof(lbExtendedDownloaderNoVideoFormatsAvailable):
                                lbExtendedDownloaderNoVideoFormatsAvailable = ReadValue;
                                continue;
                            case nameof(lbExtendedDownloaderNoAudioFormatsAvailable):
                                lbExtendedDownloaderNoAudioFormatsAvailable = ReadValue;
                                continue;
                            case nameof(lbExtendedDownloaderNoUnknownFormatsFound):
                                lbExtendedDownloaderNoUnknownFormatsFound = ReadValue;
                                continue;
                            case nameof(lbVideoRemux):
                                lbVideoRemux = ReadValue;
                                continue;
                            case nameof(txtExtendedDownloaderMediaTitle):
                                txtExtendedDownloaderMediaTitle = ReadValue;
                                continue;
                            case nameof(txtExtendedDownloaderBatchMediaTitle):
                                txtExtendedDownloaderBatchMediaTitle = ReadValue;
                                continue;
                            case nameof(mExtendedDownloaderEnqueueCopyOptions):
                                mExtendedDownloaderEnqueueCopyOptions = ReadValue;
                                continue;
                            case nameof(mExtendedDownloaderEnqueueWithAuthentication):
                                mExtendedDownloaderEnqueueWithAuthentication = ReadValue;
                                continue;
                            case nameof(mExtendedDownloaderEnqueueCopyAuthentication):
                                mExtendedDownloaderEnqueueCopyAuthentication = ReadValue;
                                continue;
                            case nameof(mExtendedDownloaderQueueCopyLink):
                                mExtendedDownloaderQueueCopyLink = ReadValue;
                                continue;
                            case nameof(mExtendedDownloaderQueueViewInBrowser):
                                mExtendedDownloaderQueueViewInBrowser = ReadValue;
                                continue;
                            case nameof(mExtendedDownloaderEnqueueImportLinksWithAuthentication):
                                mExtendedDownloaderEnqueueImportLinksWithAuthentication = ReadValue;
                                continue;
                            case nameof(mExtendedDownloaderEnqueueImportLinksCopyOptions):
                                mExtendedDownloaderEnqueueImportLinksCopyOptions = ReadValue;
                                continue;
                            case nameof(mExtendedDownloaderEnqueueImportLinksCopyAuthentication):
                                mExtendedDownloaderEnqueueImportLinksCopyAuthentication = ReadValue;
                                continue;
                            #endregion

                            #region frmLanguage
                            case nameof(frmLanguage):
                                frmLanguage = ReadValue;
                                continue;
                            case nameof(btnLanguageRefresh):
                                btnLanguageRefresh = ReadValue;
                                continue;
                            case nameof(btnLanguageDownload):
                                btnLanguageDownload = ReadValue;
                                continue;
                            #endregion

                            #region frmLog
                            case nameof(frmLog):
                                frmLog = ReadValue;
                                continue;
                            case nameof(frmLogClear):
                                frmLogClear = ReadValue;
                                continue;
                            case nameof(frmLogExceptions):
                                frmLogExceptions = ReadValue;
                                continue;
                            case nameof(lbLogPastExceptions):
                                lbLogPastExceptions = ReadValue;
                                continue;
                            #endregion

                            #region frmMain
                            // frmMain / menu
                            case nameof(mSettings):
                                mSettings = ReadValue;
                                continue;
                            case nameof(mTools):
                                mTools = ReadValue;
                                continue;
                            case nameof(mBatch):
                                mBatch = ReadValue;
                                continue;
                            case nameof(mBatchDownload):
                                mBatchDownload = ReadValue;
                                continue;
                            case nameof(mBatchExtendedDownload):
                                mBatchExtendedDownload = ReadValue;
                                continue;
                            case nameof(mBatchConvert):
                                mBatchConvert = ReadValue;
                                continue;
                            case nameof(mArchiveDownloader):
                                mArchiveDownloader = ReadValue;
                                continue;
                            case nameof(mDownloadSubtitles):
                                mDownloadSubtitles = ReadValue;
                                continue;
                            case nameof(mMiscTools):
                                mMiscTools = ReadValue;
                                continue;
                            case nameof(mClipboardAutoDownload):
                                mClipboardAutoDownload = ReadValue;
                                continue;
                            case nameof(mHelp):
                                mHelp = ReadValue;
                                continue;
                            case nameof(mLanguage):
                                mLanguage = ReadValue;
                                continue;
                            case nameof(mSupportedSites):
                                mSupportedSites = ReadValue;
                                continue;
                            case nameof(mAbout):
                                mAbout = ReadValue;
                                continue;

                            // frmMain / tcMain
                            case nameof(tabDownload):
                                tabDownload = ReadValue;
                                continue;
                            case nameof(tabConvert):
                                tabConvert = ReadValue;
                                continue;
                            case nameof(tabMerge):
                                tabMerge = ReadValue;
                                continue;

                            // frmMain / tcMain / Download
                            case nameof(lbURL):
                                lbURL = ReadValue;
                                continue;
                            case nameof(txtUrlHint):
                                txtUrlHint = ReadValue;
                                continue;
                            case nameof(gbDownloadType):
                                gbDownloadType = ReadValue;
                                continue;
                            case nameof(lbQuality):
                                lbQuality = ReadValue;
                                continue;
                            case nameof(lbFormat):
                                lbFormat = ReadValue;
                                continue;
                            case nameof(chkUseSelection):
                                chkUseSelection = ReadValue;
                                continue;
                            case nameof(rbVideoSelectionPlaylistIndex):
                                rbVideoSelectionPlaylistIndex = ReadValue;
                                continue;
                            case nameof(rbVideoSelectionPlaylistItems):
                                rbVideoSelectionPlaylistItems = ReadValue;
                                continue;
                            case nameof(rbVideoSelectionBeforeDate):
                                rbVideoSelectionBeforeDate = ReadValue;
                                continue;
                            case nameof(rbVideoSelectionOnDate):
                                rbVideoSelectionOnDate = ReadValue;
                                continue;
                            case nameof(rbVideoSelectionAfterDate):
                                rbVideoSelectionAfterDate = ReadValue;
                                continue;
                            case nameof(txtPlaylistStartHint):
                                txtPlaylistStartHint = ReadValue;
                                continue;
                            case nameof(txtPlaylistEndHint):
                                txtPlaylistEndHint = ReadValue;
                                continue;
                            case nameof(txtPlaylistItemsHint):
                                txtPlaylistItemsHint = ReadValue;
                                continue;
                            case nameof(txtVideoDateHint):
                                txtVideoDateHint = ReadValue;
                                continue;
                            case nameof(lbCustomArguments):
                                lbCustomArguments = ReadValue;
                                continue;
                            case nameof(sbDownload):
                                sbDownload = ReadValue;
                                continue;
                            case nameof(btnMainExtended):
                                btnMainExtended = ReadValue;
                                continue;
                            case nameof(mDownloadWithAuthentication):
                                mDownloadWithAuthentication = ReadValue;
                                continue;
                            case nameof(mBatchDownloadFromFile):
                                mBatchDownloadFromFile = ReadValue;
                                continue;
                            case nameof(msgBatchDownloadFromFile):
                                msgBatchDownloadFromFile = ReadValue;
                                continue;
                            case nameof(mQuickDownloadForm):
                                mQuickDownloadForm = ReadValue;
                                continue;
                            case nameof(mQuickDownloadFormAuthentication):
                                mQuickDownloadFormAuthentication = ReadValue;
                                continue;
                            case nameof(mExtendedDownloadForm):
                                mExtendedDownloadForm = ReadValue;
                                continue;
                            case nameof(mExtendedDownloadFormAuthentication):
                                mExtendedDownloadFormAuthentication = ReadValue;
                                continue;

                            // frmMain / tcMain / Convert
                            case nameof(lbConvertInput):
                                lbConvertInput = ReadValue;
                                continue;
                            case nameof(lbConvertOutput):
                                lbConvertOutput = ReadValue;
                                continue;
                            case nameof(rbConvertAuto):
                                rbConvertAuto = ReadValue;
                                continue;
                            case nameof(rbConvertAutoFFmpeg):
                                rbConvertAutoFFmpeg = ReadValue;
                                continue;
                            case nameof(btnConvert):
                                btnConvert = ReadValue;
                                continue;

                            // frmMain / tcMain / cmTray
                            case nameof(cmTrayShowForm):
                                cmTrayShowForm = ReadValue;
                                continue;
                            case nameof(cmTrayDownloader):
                                cmTrayDownloader = ReadValue;
                                continue;
                            case nameof(cmTrayDownloadClipboard):
                                cmTrayDownloadClipboard = ReadValue;
                                continue;
                            case nameof(cmTrayDownloadBestVideo):
                                cmTrayDownloadBestVideo = ReadValue;
                                continue;
                            case nameof(cmTrayDownloadBestAudio):
                                cmTrayDownloadBestAudio = ReadValue;
                                continue;
                            case nameof(cmTrayDownloadCustom):
                                cmTrayDownloadCustom = ReadValue;
                                continue;
                            case nameof(cmTrayDownloadCustomTxtBox):
                                cmTrayDownloadCustomTxtBox = ReadValue;
                                continue;
                            case nameof(cmTrayDownloadCustomTxt):
                                cmTrayDownloadCustomTxt = ReadValue;
                                continue;
                            case nameof(cmTrayDownloadCustomSettings):
                                cmTrayDownloadCustomSettings = ReadValue;
                                continue;
                            case nameof(cmTrayConverter):
                                cmTrayConverter = ReadValue;
                                continue;
                            case nameof(cmTrayConvertTo):
                                cmTrayConvertTo = ReadValue;
                                continue;
                            case nameof(cmTrayConvertVideo):
                                cmTrayConvertVideo = ReadValue;
                                continue;
                            case nameof(cmTrayConvertAudio):
                                cmTrayConvertAudio = ReadValue;
                                continue;
                            case nameof(cmTrayConvertCustom):
                                cmTrayConvertCustom = ReadValue;
                                continue;
                            case nameof(cmTrayConvertAutomatic):
                                cmTrayConvertAutomatic = ReadValue;
                                continue;
                            case nameof(cmTrayConvertAutoFFmpeg):
                                cmTrayConvertAutoFFmpeg = ReadValue;
                                continue;
                            case nameof(cmTrayExit):
                                cmTrayExit = ReadValue;
                                continue;
                            #endregion

                            #region frmMerger
                            case nameof(frmMerger):
                                frmMerger = ReadValue;
                                continue;
                            case nameof(btnMerge):
                                btnMerge = ReadValue;
                                continue;
                            case nameof(frmMergerVideoSources):
                                frmMergerVideoSources = ReadValue;
                                continue;
                            case nameof(frmMergerAudioSources):
                                frmMergerAudioSources = ReadValue;
                                continue;
                            case nameof(frmMergerSubtitleSources):
                                frmMergerSubtitleSources = ReadValue;
                                continue;
                            case nameof(frmMergerAttatchmentSources):
                                frmMergerAttatchmentSources = ReadValue;
                                continue;
                            #endregion

                            #region frmSettings
                            case nameof(frmSettings):
                                frmSettings = ReadValue;
                                continue;
                            case nameof(btnSettingsCancelHint):
                                btnSettingsCancelHint = ReadValue;
                                continue;
                            case nameof(btnSettingsSaveHint):
                                btnSettingsSaveHint = ReadValue;
                                continue;

                            #region tabGeneral
                            case nameof(tabSettingsGeneral):
                                tabSettingsGeneral = ReadValue;
                                continue;

                            case nameof(tabSettingsGeneralYoutubeDl):
                                tabSettingsGeneralYoutubeDl = ReadValue;
                                continue;
                            case nameof(lbSettingsGeneralYoutubeDlPath):
                                lbSettingsGeneralYoutubeDlPath = ReadValue;
                                continue;
                            case nameof(lbSettingsGeneralYoutubeDlPathHint):
                                lbSettingsGeneralYoutubeDlPathHint = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralUseStaticYoutubeDl):
                                chkSettingsGeneralUseStaticYoutubeDl = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralUseStaticYoutubeDlHint):
                                chkSettingsGeneralUseStaticYoutubeDlHint = ReadValue;
                                continue;
                            case nameof(txtSettingsGeneralYoutubeDlPathHint):
                                txtSettingsGeneralYoutubeDlPathHint = ReadValue;
                                continue;
                            case nameof(btnSettingsGeneralBrowseYoutubeDlHint):
                                btnSettingsGeneralBrowseYoutubeDlHint = ReadValue;
                                continue;
                            case nameof(btnSettingsRedownloadYoutubeDl):
                                btnSettingsRedownloadYoutubeDl = ReadValue;
                                continue;
                            case nameof(btnSettingsRedownloadYoutubeDlHint):
                                btnSettingsRedownloadYoutubeDlHint = ReadValue;
                                continue;
                            case nameof(ofdTitleYoutubeDl):
                                ofdTitleYoutubeDl = ReadValue;
                                continue;
                            case nameof(ofdFilterYoutubeDl):
                                ofdFilterYoutubeDl = ReadValue;
                                continue;


                            case nameof(tabSettingsGeneralFfmpeg):
                                tabSettingsGeneralFfmpeg = ReadValue;
                                continue;
                            case nameof(lbSettingsGeneralFFmpegDirectory):
                                lbSettingsGeneralFFmpegDirectory = ReadValue;
                                continue;
                            case nameof(lbSettingsGeneralFFmpegDirectoryHint):
                                lbSettingsGeneralFFmpegDirectoryHint = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralUseStaticFFmpeg):
                                chkSettingsGeneralUseStaticFFmpeg = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralUseStaticFFmpegHint):
                                chkSettingsGeneralUseStaticFFmpegHint = ReadValue;
                                continue;
                            case nameof(txtSettingsGeneralFFmpegPathHint):
                                txtSettingsGeneralFFmpegPathHint = ReadValue;
                                continue;
                            case nameof(btnSettingsGeneralBrowseFFmpegHint):
                                btnSettingsGeneralBrowseFFmpegHint = ReadValue;
                                continue;
                            case nameof(btnSettingsRedownloadFfmpeg):
                                btnSettingsRedownloadFfmpeg = ReadValue;
                                continue;
                            case nameof(btnSettingsRedownloadFfmpegHint):
                                btnSettingsRedownloadFfmpegHint = ReadValue;
                                continue;
                            case nameof(ofdTitleFFmpeg):
                                ofdTitleFFmpeg = ReadValue;
                                continue;
                            case nameof(ofdFilterFFmpeg):
                                ofdFilterFFmpeg = ReadValue;
                                continue;


                            case nameof(chkSettingsGeneralCheckForUpdatesOnLaunch):
                                chkSettingsGeneralCheckForUpdatesOnLaunch = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralCheckForUpdatesOnLaunchHint):
                                chkSettingsGeneralCheckForUpdatesOnLaunchHint = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralCheckForBetaUpdates):
                                chkSettingsGeneralCheckForBetaUpdates = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralCheckForBetaUpdatesHint):
                                chkSettingsGeneralCheckForBetaUpdatesHint = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralDeleteUpdaterAfterUpdating):
                                chkSettingsGeneralDeleteUpdaterAfterUpdating = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralDeleteUpdaterAfterUpdatingHint):
                                chkSettingsGeneralDeleteUpdaterAfterUpdatingHint = ReadValue;
                                continue;
                            case nameof(chkDeleteOldVersionAfterUpdating):
                                chkDeleteOldVersionAfterUpdating = ReadValue;
                                continue;
                            case nameof(chkDeleteOldVersionAfterUpdatingHint):
                                chkDeleteOldVersionAfterUpdatingHint = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralHoverOverUrlToPasteClipboard):
                                chkSettingsGeneralHoverOverUrlToPasteClipboard = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralHoverOverUrlToPasteClipboardHint):
                                chkSettingsGeneralHoverOverUrlToPasteClipboardHint = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralClearUrlOnDownload):
                                chkSettingsGeneralClearUrlOnDownload = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralClearUrlOnDownloadHint):
                                chkSettingsGeneralClearUrlOnDownloadHint = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralClearClipboardOnDownload):
                                chkSettingsGeneralClearClipboardOnDownload = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralClearClipboardOnDownloadHint):
                                chkSettingsGeneralClearClipboardOnDownloadHint = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralAutoUpdateYoutubeDl):
                                chkSettingsGeneralAutoUpdateYoutubeDl = ReadValue;
                                continue;
                            case nameof(chkSettingsGeneralAutoUpdateYoutubeDlHint):
                                chkSettingsGeneralAutoUpdateYoutubeDlHint = ReadValue;
                                continue;
                            case nameof(gbSettingsGeneralCustomArguments):
                                gbSettingsGeneralCustomArguments = ReadValue;
                                continue;
                            case nameof(gbSettingsGeneralCustomArgumentsHint):
                                gbSettingsGeneralCustomArgumentsHint = ReadValue;
                                continue;
                            case nameof(rbSettingsGeneralCustomArgumentsDontSave):
                                rbSettingsGeneralCustomArgumentsDontSave = ReadValue;
                                continue;
                            case nameof(rbSettingsGeneralCustomArgumentsDontSaveHint):
                                rbSettingsGeneralCustomArgumentsDontSaveHint = ReadValue;
                                continue;
                            case nameof(rbSettingsGeneralCustomArgumentsSaveAsArgsText):
                                rbSettingsGeneralCustomArgumentsSaveAsArgsText = ReadValue;
                                continue;
                            case nameof(rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint):
                                rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = ReadValue;
                                continue;
                            case nameof(rbSettingsGeneralCustomArgumentsSaveInSettings):
                                rbSettingsGeneralCustomArgumentsSaveInSettings = ReadValue;
                                continue;
                            case nameof(rbSettingsGeneralCustomArgumentsSaveInSettingsHint):
                                rbSettingsGeneralCustomArgumentsSaveInSettingsHint = ReadValue;
                                continue;
                            #endregion

                            #region tabDownloads
                            case nameof(tabSettingsDownloads):
                                tabSettingsDownloads = ReadValue;
                                continue;

                            case nameof(lbSettingsDownloadsDownloadPath):
                                lbSettingsDownloadsDownloadPath = ReadValue;
                                continue;
                            case nameof(lbSettingsDownloadsDownloadPathHint):
                                lbSettingsDownloadsDownloadPathHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsDownloadPathUseRelativePathHint):
                                chkSettingsDownloadsDownloadPathUseRelativePathHint = ReadValue;
                                continue;
                            case nameof(txtSettingsDownloadsSavePathHint):
                                txtSettingsDownloadsSavePathHint = ReadValue;
                                continue;
                            case nameof(btnSettingsDownloadsBrowseSavePathHint):
                                btnSettingsDownloadsBrowseSavePathHint = ReadValue;
                                continue;
                            case nameof(lbSettingsDownloadsFileNameSchema):
                                lbSettingsDownloadsFileNameSchema = ReadValue;
                                continue;
                            case nameof(lbSettingsDownloadsFileNameSchemaHint):
                                lbSettingsDownloadsFileNameSchemaHint = ReadValue;
                                continue;
                            case nameof(llSettingsDownloadsSchemaHelpHint):
                                llSettingsDownloadsSchemaHelpHint = ReadValue;
                                continue;
                            case nameof(txtSettingsDownloadsFileNameSchemaHint):
                                txtSettingsDownloadsFileNameSchemaHint = ReadValue;
                                continue;
                            case nameof(btnSettingsDownloadsFileNameSchemaHistory):
                                btnSettingsDownloadsFileNameSchemaHistory = ReadValue;
                                continue;
                            case nameof(btnSettingsDownloadsFileNameSchemaHistoryHint):
                                btnSettingsDownloadsFileNameSchemaHistoryHint = ReadValue;
                                continue;
                            case nameof(btnSettingsDownloadsInstallProtocolNotInstalled):
                                btnSettingsDownloadsInstallProtocolNotInstalled = ReadValue;
                                continue;
                            case nameof(btnSettingsDownloadsInstallProtocolInstalled):
                                btnSettingsDownloadsInstallProtocolInstalled = ReadValue;
                                continue;
                            case nameof(btnSettingsDownloadsInstallProtocolHint):
                                btnSettingsDownloadsInstallProtocolHint = ReadValue;
                                continue;

                            #region General
                            case nameof(tabDownloadsGeneral):
                                tabDownloadsGeneral = ReadValue;
                                continue;

                            case nameof(chkSettingsDownloadsSaveFormatQuality):
                                chkSettingsDownloadsSaveFormatQuality = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsSaveFormatQualityHint):
                                chkSettingsDownloadsSaveFormatQualityHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsDownloadSubtitles):
                                chkSettingsDownloadsDownloadSubtitles = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsDownloadSubtitlesHint):
                                chkSettingsDownloadsDownloadSubtitlesHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsEmbedSubtitles):
                                chkSettingsDownloadsEmbedSubtitles = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsEmbedSubtitlesHint):
                                chkSettingsDownloadsEmbedSubtitlesHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsSaveVideoInfo):
                                chkSettingsDownloadsSaveVideoInfo = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsSaveVideoInfoHint):
                                chkSettingsDownloadsSaveVideoInfoHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsWriteMetadataToFile):
                                chkSettingsDownloadsWriteMetadataToFile = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsWriteMetadataToFileHint):
                                chkSettingsDownloadsWriteMetadataToFileHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsSaveDescription):
                                chkSettingsDownloadsSaveDescription = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsSaveDescriptionHint):
                                chkSettingsDownloadsSaveDescriptionHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsKeepOriginalFiles):
                                chkSettingsDownloadsKeepOriginalFiles = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsKeepOriginalFilesHint):
                                chkSettingsDownloadsKeepOriginalFilesHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsSaveAnnotations):
                                chkSettingsDownloadsSaveAnnotations = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsSaveAnnotationsHint):
                                chkSettingsDownloadsSaveAnnotationsHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsSaveThumbnails):
                                chkSettingsDownloadsSaveThumbnails = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsSaveThumbnailsHint):
                                chkSettingsDownloadsSaveThumbnailsHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsEmbedThumbnails):
                                chkSettingsDownloadsEmbedThumbnails = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsEmbedThumbnailsHint):
                                chkSettingsDownloadsEmbedThumbnailsHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsSkipUnavailableFragments):
                                chkSettingsDownloadsSkipUnavailableFragments = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsSkipUnavailableFragmentsHint):
                                chkSettingsDownloadsSkipUnavailableFragmentsHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsAbortOnError):
                                chkSettingsDownloadsAbortOnError = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsAbortOnErrorHint):
                                chkSettingsDownloadsAbortOnErrorHint = ReadValue;
                                continue;
                            #endregion

                            #region Sorting
                            case nameof(tabDownloadsSorting):
                                tabDownloadsSorting = ReadValue;
                                continue;

                            case nameof(chkSettingsDownloadsSeparateDownloadsToDifferentFolders):
                                chkSettingsDownloadsSeparateDownloadsToDifferentFolders = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint):
                                chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsSeparateIntoWebsiteUrl):
                                chkSettingsDownloadsSeparateIntoWebsiteUrl = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsSeparateIntoWebsiteUrlHint):
                                chkSettingsDownloadsSeparateIntoWebsiteUrlHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsWebsiteSubdomains):
                                chkSettingsDownloadsWebsiteSubdomains = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsWebsiteSubdomainsHint):
                                chkSettingsDownloadsWebsiteSubdomainsHint = ReadValue;
                                continue;
                            #endregion

                            #region Fixes
                            case nameof(tabDownloadsFixes):
                                tabDownloadsFixes = ReadValue;
                                continue;

                            case nameof(chkSettingsDownloadsFixVReddIt):
                                chkSettingsDownloadsFixVReddIt = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsFixVReddItHint):
                                chkSettingsDownloadsFixVReddItHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsPreferFFmpeg):
                                chkSettingsDownloadsPreferFFmpeg = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsPreferFFmpegHint):
                                chkSettingsDownloadsPreferFFmpegHint = ReadValue;
                                continue;
                            #endregion

                            #region Connection
                            case nameof(tabDownloadsConnection):
                                tabDownloadsConnection = ReadValue;
                                continue;

                            case nameof(chkSettingsDownloadsLimitDownload):
                                chkSettingsDownloadsLimitDownload = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsLimitDownloadHint):
                                chkSettingsDownloadsLimitDownloadHint = ReadValue;
                                continue;
                            case nameof(numSettingsDownloadsLimitDownloadHint):
                                numSettingsDownloadsLimitDownloadHint = ReadValue;
                                continue;
                            case nameof(cbSettingsDownloadsLimitDownloadHint):
                                cbSettingsDownloadsLimitDownloadHint = ReadValue;
                                continue;
                            case nameof(lbSettingsDownloadsRetryAttempts):
                                lbSettingsDownloadsRetryAttempts = ReadValue;
                                continue;
                            case nameof(lbSettingsDownloadsRetryAttemptsHint):
                                lbSettingsDownloadsRetryAttemptsHint = ReadValue;
                                continue;
                            case nameof(numSettingsDownloadsRetryAttemptsHint):
                                numSettingsDownloadsRetryAttemptsHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsForceIpv4):
                                chkSettingsDownloadsForceIpv4 = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsForceIpv4Hint):
                                chkSettingsDownloadsForceIpv4Hint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsForceIpv6):
                                chkSettingsDownloadsForceIpv6 = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsForceIpv6Hint):
                                chkSettingsDownloadsForceIpv6Hint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsUseProxy):
                                chkSettingsDownloadsUseProxy = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsUseProxyHint):
                                chkSettingsDownloadsUseProxyHint = ReadValue;
                                continue;
                            case nameof(cbSettingsDownloadsProxyTypeHint):
                                cbSettingsDownloadsProxyTypeHint = ReadValue;
                                continue;
                            case nameof(txtSettingsDownloadsProxyIpHint):
                                txtSettingsDownloadsProxyIpHint = ReadValue;
                                continue;
                            case nameof(txtSettingsDownloadsProxyPortHint):
                                txtSettingsDownloadsProxyPortHint = ReadValue;
                                continue;
                            case nameof(lbSettingsDownloadsFragmentThreads):
                                lbSettingsDownloadsFragmentThreads = ReadValue;
                                continue;
                            case nameof(lbSettingsDownloadsFragmentThreadsHint):
                                lbSettingsDownloadsFragmentThreadsHint = ReadValue;
                                continue;
                            #endregion

                            #region Updating
                            case nameof(tabDownloadsUpdating):
                                tabDownloadsUpdating = ReadValue;
                                continue;

                            case nameof(chkSettingsDownloadsUseYoutubeDlsUpdater):
                                chkSettingsDownloadsUseYoutubeDlsUpdater = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsUseYoutubeDlsUpdaterHint):
                                chkSettingsDownloadsUseYoutubeDlsUpdaterHint = ReadValue;
                                continue;
                            case nameof(lbSettingsDownloadsUpdatingYtdlType):
                                lbSettingsDownloadsUpdatingYtdlType = ReadValue;
                                continue;
                            case nameof(cbSettingsDownloadsUpdatingYtdlTypeHint):
                                cbSettingsDownloadsUpdatingYtdlTypeHint = ReadValue;
                                continue;
                            case nameof(llbSettingsDownloadsYtdlTypeViewRepo):
                                llbSettingsDownloadsYtdlTypeViewRepo = ReadValue;
                                continue;
                            case nameof(llbSettingsDownloadsYtdlTypeViewRepoHint):
                                llbSettingsDownloadsYtdlTypeViewRepoHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing):
                                chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint):
                                chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = ReadValue;
                                continue;
                            #endregion

                            #region Batch
                            case nameof(tabDownloadsBatch):
                                tabDownloadsBatch = ReadValue;
                                continue;

                            case nameof(chkSettingsDownloadsSeparateBatchDownloads):
                                chkSettingsDownloadsSeparateBatchDownloads = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsSeparateBatchDownloadsHint):
                                chkSettingsDownloadsSeparateBatchDownloadsHint = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsAddDateToBatchDownloadFolders):
                                chkSettingsDownloadsAddDateToBatchDownloadFolders = ReadValue;
                                continue;
                            case nameof(chkSettingsDownloadsAddDateToBatchDownloadFoldersHint):
                                chkSettingsDownloadsAddDateToBatchDownloadFoldersHint = ReadValue;
                                continue;
                            #endregion

                            #region Extended downloader
                            case nameof(tabExtendedOptions):
                                tabExtendedOptions = ReadValue;
                                continue;

                            case nameof(chkExtendedPreferExtendedDialog):
                                chkExtendedPreferExtendedDialog = ReadValue;
                                continue;
                            case nameof(chkExtendedPreferExtendedDialogHint):
                                chkExtendedPreferExtendedDialogHint = ReadValue;
                                continue;
                            case nameof(chkExtendedAutomaticallyDownloadThumbnail):
                                chkExtendedAutomaticallyDownloadThumbnail = ReadValue;
                                continue;
                            case nameof(chkExtendedAutomaticallyDownloadThumbnailHint):
                                chkExtendedAutomaticallyDownloadThumbnailHint = ReadValue;
                                continue;
                            case nameof(chkExtendedIncludeCustomArguments):
                                chkExtendedIncludeCustomArguments = ReadValue;
                                continue;
                            case nameof(chkExtendedIncludeCustomArgumentsHint):
                                chkExtendedIncludeCustomArgumentsHint = ReadValue;
                                continue;
                            #endregion
                            #endregion

                            #region tabConverter
                            case nameof(tabSettingsConverter):
                                tabSettingsConverter = ReadValue;
                                continue;

                            case nameof(chkSettingsConverterClearOutputAfterConverting):
                                chkSettingsConverterClearOutputAfterConverting = ReadValue;
                                continue;
                            case nameof(chkSettingsConverterClearOutputAfterConvertingHint):
                                chkSettingsConverterClearOutputAfterConvertingHint = ReadValue;
                                continue;
                            case nameof(chkSettingsConverterDetectOutputFileType):
                                chkSettingsConverterDetectOutputFileType = ReadValue;
                                continue;
                            case nameof(chkSettingsConverterDetectOutputFileTypeHint):
                                chkSettingsConverterDetectOutputFileTypeHint = ReadValue;
                                continue;
                            case nameof(chkSettingsConverterClearInputAfterConverting):
                                chkSettingsConverterClearInputAfterConverting = ReadValue;
                                continue;
                            case nameof(chkSettingsConverterClearInputAfterConvertingHint):
                                chkSettingsConverterClearInputAfterConvertingHint = ReadValue;
                                continue;
                            case nameof(chkSettingsConverterHideFFmpegCompileInfo):
                                chkSettingsConverterHideFFmpegCompileInfo = ReadValue;
                                continue;
                            case nameof(chkSettingsConverterHideFFmpegCompileInfoHint):
                                chkSettingsConverterHideFFmpegCompileInfoHint = ReadValue;
                                continue;

                            #region Video
                            case nameof(tcSettingsConverterVideo):
                                tcSettingsConverterVideo = ReadValue;
                                continue;

                            case nameof(lbSettingsConverterVideoBitrate):
                                lbSettingsConverterVideoBitrate = ReadValue;
                                continue;
                            case nameof(lbSettingsConverterVideoBitrateHint):
                                lbSettingsConverterVideoBitrateHint = ReadValue;
                                continue;
                            case nameof(lbSettingsConverterVideoPreset):
                                lbSettingsConverterVideoPreset = ReadValue;
                                continue;
                            case nameof(lbSettingsConverterVideoPresetHint):
                                lbSettingsConverterVideoPresetHint = ReadValue;
                                continue;
                            case nameof(lbSettingsConverterVideoProfile):
                                lbSettingsConverterVideoProfile = ReadValue;
                                continue;
                            case nameof(lbSettingsConverterVideoProfileHint):
                                lbSettingsConverterVideoProfileHint = ReadValue;
                                continue;
                            case nameof(lbSettingsConverterVideoCRF):
                                lbSettingsConverterVideoCRF = ReadValue;
                                continue;
                            case nameof(lbSettingsConverterVideoCRFHint):
                                lbSettingsConverterVideoCRFHint = ReadValue;
                                continue;
                            case nameof(chkSettingsConverterVideoFastStart):
                                chkSettingsConverterVideoFastStart = ReadValue;
                                continue;
                            case nameof(chkSettingsConverterVideoFastStartHint):
                                chkSettingsConverterVideoFastStartHint = ReadValue;
                                continue;
                            #endregion

                            #region Audio
                            case nameof(tcSettingsConverterAudio):
                                tcSettingsConverterAudio = ReadValue;
                                continue;

                            case nameof(lbSettingsConverterAudioBitrate):
                                lbSettingsConverterAudioBitrate = ReadValue;
                                continue;
                            case nameof(lbSettingsConverterAudioBitrateHint):
                                lbSettingsConverterAudioBitrateHint = ReadValue;
                                continue;
                            #endregion

                            #region Custom
                            case nameof(tcSettingsConverterCustom):
                                tcSettingsConverterCustom = ReadValue;
                                continue;

                            case nameof(lbSettingsConverterCustomHeader):
                                lbSettingsConverterCustomHeader = ReadValue;
                                continue;
                            case nameof(txtSettingsConverterCustomArgumentsHint):
                                txtSettingsConverterCustomArgumentsHint = ReadValue;
                                continue;
                            #endregion
                            #endregion

                            #region tabExtensions
                            case nameof(tabSettingsExtensions):
                                tabSettingsExtensions = ReadValue;
                                continue;

                            case nameof(lbSettingsExtensionsHeader):
                                lbSettingsExtensionsHeader = ReadValue;
                                continue;
                            case nameof(lbSettingsExtensionsExtensionFullName):
                                lbSettingsExtensionsExtensionFullName = ReadValue;
                                continue;
                            case nameof(txtSettingsExtensionsExtensionFullName):
                                txtSettingsExtensionsExtensionFullName = ReadValue;
                                continue;
                            case nameof(lbSettingsExtensionsExtensionShort):
                                lbSettingsExtensionsExtensionShort = ReadValue;
                                continue;
                            case nameof(txtSettingsExtensionsExtensionShort):
                                txtSettingsExtensionsExtensionShort = ReadValue;
                                continue;
                            case nameof(btnSettingsExtensionsAdd):
                                btnSettingsExtensionsAdd = ReadValue;
                                continue;
                            case nameof(lbSettingsExtensionsFileName):
                                lbSettingsExtensionsFileName = ReadValue;
                                continue;
                            case nameof(btnSettingsExtensionsRemoveSelected):
                                btnSettingsExtensionsRemoveSelected = ReadValue;
                                continue;
                            #endregion

                            #region tabErrors
                            case nameof(tabSettingsErrors):
                                tabSettingsErrors = ReadValue;
                                continue;

                            case nameof(chkSettingsErrorsShowDetailedErrors):
                                chkSettingsErrorsShowDetailedErrors = ReadValue;
                                continue;
                            case nameof(chkSettingsErrorsShowDetailedErrorsHint):
                                chkSettingsErrorsShowDetailedErrorsHint = ReadValue;
                                continue;
                            case nameof(chkSettingsErrorsSaveErrorsAsErrorLog):
                                chkSettingsErrorsSaveErrorsAsErrorLog = ReadValue;
                                continue;
                            case nameof(chkSettingsErrorsSaveErrorsAsErrorLogHint):
                                chkSettingsErrorsSaveErrorsAsErrorLogHint = ReadValue;
                                continue;
                            case nameof(chkSettingsErrorsSuppressErrors):
                                chkSettingsErrorsSuppressErrors = ReadValue;
                                continue;
                            case nameof(chkSettingsErrorsSuppressErrorsHint):
                                chkSettingsErrorsSuppressErrorsHint = ReadValue;
                                continue;
                            #endregion
                            #endregion

                            #region frmSubtitles
                            case nameof(frmSubtitles):
                                frmSubtitles = ReadValue;
                                continue;
                            case nameof(lbSubtitlesHeader):
                                lbSubtitlesHeader = ReadValue;
                                continue;
                            case nameof(lbSubtitlesUrl):
                                lbSubtitlesUrl = ReadValue;
                                continue;
                            case nameof(lbSubtitlesLanguages):
                                lbSubtitlesLanguages = ReadValue;
                                continue;
                            case nameof(btnSubtitlesAddLanguage):
                                btnSubtitlesAddLanguage = ReadValue;
                                continue;
                            case nameof(btnSubtitlesClearLanguages):
                                btnSubtitlesClearLanguages = ReadValue;
                                continue;
                            case nameof(btnSubtitlesDownload):
                                btnSubtitlesDownload = ReadValue;
                                continue;
                            #endregion

                            #region frmTools
                            case nameof(frmTools):
                                frmTools = ReadValue;
                                continue;
                            case nameof(btnMiscToolsRemoveAudio):
                                btnMiscToolsRemoveAudio = ReadValue;
                                continue;
                            case nameof(btnMiscToolsExtractAudio):
                                btnMiscToolsExtractAudio = ReadValue;
                                continue;
                            case nameof(btnMiscToolsVideoToGif):
                                btnMiscToolsVideoToGif = ReadValue;
                                continue;
                            #endregion

                            #region frmUpdateAvailable
                            case nameof(frmUpdateAvailable):
                                frmUpdateAvailable = ReadValue;
                                continue;
                            case nameof(lbUpdateAvailableHeader):
                                lbUpdateAvailableHeader = ReadValue;
                                continue;
                            case nameof(lbUpdateAvailableUpdateVersion):
                                lbUpdateAvailableUpdateVersion = ReadValue;
                                continue;
                            case nameof(lbUpdateAvailableCurrentVersion):
                                lbUpdateAvailableCurrentVersion = ReadValue;
                                continue;
                            case nameof(lbUpdateAvailableChangelog):
                                lbUpdateAvailableChangelog = ReadValue;
                                continue;
                            case nameof(lbUpdateSize):
                                lbUpdateSize = ReadValue;
                                continue;
                            case nameof(btnUpdateAvailableSkipVersion):
                                btnUpdateAvailableSkipVersion = ReadValue;
                                continue;
                            case nameof(btnUpdateAvailableUpdate):
                                btnUpdateAvailableUpdate = ReadValue;
                                continue;
                            #endregion

                        }
                    }
                }
                LoadedFile = LanguageFile;
                UsingInternalEnglish = false;
                Log.Write("Finished loading external language.");
                LocalizationChanged();
                return true;
            }
        }
        catch (Exception ex) {
            if (Log.ReportLanguageException(ex, true) == System.Windows.Forms.DialogResult.Retry)
                return LoadLanguage(LanguageFile);

            LoadInternalEnglish();
            LocalizationChanged();
            return false;
        }
    }

    /// <summary>
    /// Parses the header value from a string.
    /// </summary>
    /// <param name="Input">The string that may contain a header.</param>
    /// <returns>Returns the absolute header.</returns>
    private static void ReadHeaderValue(string Input, out string Header) {
        if (Input.Contains("//"))
            Input = Input[..Input.IndexOf("//")];
        Header = Input[1..Input.IndexOf(']')];
    }

    /// <summary>
    /// Parses the control name and value from a string.
    /// </summary>
    /// <param name="Input">The string that will be parsed. Empty values are permitted.</param>
    /// <param name="Key">The output of the Name of the control to be named, as lowercase.</param>
    /// <param name="Value">The value of the control.</param>
    private static void GetControlInfo(string Input, out string Key, out string Value) {
        switch (Input.Split('=').Length) {
            case -1: case 0: {
                Key = null;
                Value = null;
            } return;

            case 1: {
                if (Input.Contains("//"))
                    Input = Input[..Input.IndexOf("//")];
                Key = Input.Split('=')[0].Trim();
                Value = string.Empty;
            } break;

            default: {
                if (Input.Contains("//"))
                    Input = Input[..Input.IndexOf("//")];
                Key = Input.Split('=')[0].Trim();
                Value = Input[(Input.IndexOf('=') + 1)..].Trim().Replace("\\n", "\n").Replace("\\r", "\r");
            } break;
        }
    }

    /// <summary>
    /// Registers a <see cref="ILocalizedForm"/> to the callback when the localization is changed.
    /// </summary>
    /// <param name="Form"></param>
    internal static void RegisterForm(ILocalizedForm Form) {
        if (OpenedForms.Contains(Form)) {
            Log.Write($"Localized form {Form.GetFormName()} already in the list.");
            return;
        }
        OpenedForms.Add(Form);
        Log.Write($"Added new localized form {Form.GetFormName()}");
    }

    /// <summary>
    /// Unregisters a <see cref="ILocalizedForm"/> from the callback when the localization is changed.
    /// </summary>
    /// <param name="Form"></param>
    internal static void UnregisterForm(ILocalizedForm Form) {
        if (OpenedForms.Remove(Form)) {
            Log.Write($"Form {Form.GetFormName()} was removed from the list.");
        }
        else {
            Log.Write($"Form {Form.GetFormName()} was not in the list.");
        }
    }

    /// <summary>
    /// Occurs when the localization has been changed.
    /// </summary>
    private static void LocalizationChanged() {
        if (OpenedForms.Count < 1)
            return;
        OpenedForms.For((f) => f.LoadLanguage());
    }
    #endregion
}