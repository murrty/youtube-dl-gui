namespace youtube_dl_gui;

/// <summary>
/// Controls the language strings of the program. Most, if not all, strings get their text from here.
/// </summary>
public static class Language {
    #region Constants
    public const string ApplicationName = "youtube-dl-gui";
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
    #endregion

    #region frmLanguage
    public static string frmLanguage { get; private set; }
    public static string btnLanguageRefresh { get; private set; }
    public static string btnLanguageDownload { get; private set; }
    #endregion

    #region frmLog
    public static string frmLog { get; private set; }
    public static string frmLogClear { get; private set; }
    #endregion

    #region frmMain
    public static string mSettings { get; private set; }
    public static string mTools { get; private set; }
    public static string mBatchDownload { get; private set; }
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
    public static string msgBatchDownloadFromFile { get; private set; }
    public static string btnMainExtended { get; private set; }

    public static string lbConvertInput { get; private set; }
    public static string lbConvertOutput { get; private set; }
    public static string rbConvertAuto { get; private set; }
    public static string rbConvertAutoFFmpeg { get; private set; }
    public static string btnConvert { get; private set; }

    public static string lbMergeInput1 { get; private set; }
    public static string lbMergeInput2 { get; private set; }
    public static string lbMergeOutput { get; private set; }
    public static string chkMergeAudioTracks { get; private set; }
    public static string chkMergeDeleteInputFiles { get; private set; }
    public static string btnMerge { get; private set; }

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
    public static string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing { get; private set; }
    public static string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint { get; private set; }
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
    #endregion

    #region Updating
    public static string tabDownloadsUpdating { get; private set; }

    public static string chkSettingsDownloadsUseYoutubeDlsUpdater { get; private set; }
    public static string chkSettingsDownloadsUseYoutubeDlsUpdaterHint { get; private set; }
    public static string lbSettingsDownloadsUpdatingYtdlType { get; private set; }
    public static string cbSettingsDownloadsUpdatingYtdlTypeHint { get; private set; }
    public static string llbSettingsDownloadsYtdlTypeViewRepo { get; private set; }
    public static string llbSettingsDownloadsYtdlTypeViewRepoHint { get; private set; }
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
        #endregion

        #region frmLanguage
        public const string frmLanguage = "Language select";
        public const string btnLanguageRefresh = "Refresh";
        public const string btnLanguageDownload = "Download...";
        #endregion

        #region frmLog
        public const string frmLog = "Log";
        public const string frmLogClear = "Clear";
        #endregion

        #region frmMain
        // frmMain
        public const string frmMain = "youtube-dl-gui";
        // frmMain / menu
        public const string mSettings = "Settings";
        public const string mTools = "Tools";
        public const string mBatchDownload = "Batch download";
        public const string mBatchConvert = "Batch convert";
        public const string mDownloadSubtitles = "Download subtitles";
        public const string mArchiveDownloader = "Archive downloader";
        public const string mMiscTools = "Misc tools";
        public const string mClipboardAutoDownload = "Clipboard auto download";
        public const string mHelp = "Help";
        public const string mLanguage = "Language";
        public const string mSupportedSites = "Supported sites";
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
        // frmMain / tcMain / Convert
        public const string lbConvertInput = "Input";
        public const string lbConvertOutput = "Output";
        public const string rbConvertVideo = "Video";
        public const string rbConvertAudio = "Audio";
        public const string rbConvertCustom = "Custom";
        public const string rbConvertAuto = "Automatic";
        public const string rbConvertAutoFFmpeg = "Auto ffmpeg";
        public const string btnConvert = "Convert";
        // frmMain / tcMain / Merge
        public const string lbMergeInput1 = "Input 1";
        public const string lbMergeInput2 = "Input 2";
        public const string lbMergeOutput = "Output";
        public const string chkMergeAudioTracks = "Merge audio tracks";
        public const string chkMergeDeleteInputFiles = "Delete input files";
        public const string btnMerge = "Merge";
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
        public const string rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = "Saves custom arguments as args.txt in youtube-dl-gui's directory";
        public const string rbSettingsGeneralCustomArgumentsSaveInSettings = "Save in settings";
        public const string rbSettingsGeneralCustomArgumentsSaveInSettingsHint = "Saves custom arguments in the application settings";
        #endregion

        #region tabDownloads
        public const string tabSettingsDownloads = "Downloads";

        public const string lbSettingsDownloadsDownloadPath = "download path";
        public const string lbSettingsDownloadsDownloadPathHint = "The path of the folder where files will be downloaded to";
        public const string chkSettingsDownloadsDownloadPathUseRelativePathHint = "Save to the program's relative path\r\n\r\nIf checked, the program will check the save path and use the current directory as the base path.\r\nSaving anywhere outside of the current directory will not set the flag and will set it to wherever you selected.";
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
        public const string chkSettingsDownloadsSaveVideoInfoHint = "Saves the video's info into a .info.json file";
        public const string chkSettingsDownloadsWriteMetadataToFile = "Write metadata to file";
        public const string chkSettingsDownloadsWriteMetadataToFileHint = "Writes the video's metadata to the output file";
        public const string chkSettingsDownloadsSaveDescription = "Save description";
        public const string chkSettingsDownloadsSaveDescriptionHint = "Saves the video's description to a .description file";
        public const string chkSettingsDownloadsKeepOriginalFiles = "Keep original files";
        public const string chkSettingsDownloadsKeepOriginalFilesHint = "Keeps the original files of the download\nBy default, youtube-dl will delete them after merging";
        public const string chkSettingsDownloadsSaveAnnotations = "Save annotations";
        public const string chkSettingsDownloadsSaveAnnotationsHint = "Saves the video's annotations to a .annotations.xml file";
        public const string chkSettingsDownloadsSaveThumbnails = "Save thumbnails";
        public const string chkSettingsDownloadsSaveThumbnailsHint = "Saves the video's thumbnail";
        public const string chkSettingsDownloadsEmbedThumbnails = "Embed thumbnail into file";
        public const string chkSettingsDownloadsEmbedThumbnailsHint = "Embeds downloaded thumbnails into the output file as cover art\nRequires AtomicParsley (https://github.com/wez/atomicparsley), or youtube-dl will result in an error";
        public const string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = "Automatically delete youtube-dl when closing";
        public const string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = "Automatically delete youtube-dl.exe when closing youtube-dl-gui";
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
        public const string chkSettingsDownloadsFixVReddItHint = "Fixes visual corruptions on v.redd.it/reddit.com links using ffmpeg's HTTP Live Streaming (HLS)\n\n" + "Recommended to stay on.\nThis requires FFMPEG to be installed and available, it will fallback to youtube-dl's default.";
        public const string chkSettingsDownloadsPreferFFmpeg = "Prefer ffmpeg for downloads";
        public const string chkSettingsDownloadsPreferFFmpegHint = "Prefer's ffmpeg's hls over youtube-dl's own. This may fix some sites, and break others.";
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
        #endregion

        #region Updating
        public const string tabDownloadsUpdating = "Updating";


        public const string chkSettingsDownloadsUseYoutubeDlsUpdater = "Use youtube-dl's internal updater";
        public const string chkSettingsDownloadsUseYoutubeDlsUpdaterHint = "Use youtube-dl's internal updater instead of this application's updater";
        public const string lbSettingsDownloadsUpdatingYtdlType = "Youtube-DL fork";
        public const string cbSettingsDownloadsUpdatingYtdlTypeHint = "The youtube-dl repo that will be targetted";
        public const string llbSettingsDownloadsYtdlTypeViewRepo = "View source repo";
        public const string llbSettingsDownloadsYtdlTypeViewRepoHint = "Go to the repository page of the selected fork";
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
        #endregion

        #region frmLanguage
        frmLanguage = InternalEnglish.frmLanguage;
        btnLanguageRefresh = InternalEnglish.btnLanguageRefresh;
        btnLanguageDownload = InternalEnglish.btnLanguageDownload;
        #endregion

        #region frmLog
        frmLog = InternalEnglish.frmLog;
        frmLogClear = InternalEnglish.frmLogClear;
        #endregion

        #region frmMain
        mSettings = InternalEnglish.mSettings;
        mTools = InternalEnglish.mTools;
        mBatchDownload = InternalEnglish.mBatchDownload;
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

        lbConvertInput = InternalEnglish.lbConvertInput;
        lbConvertOutput = InternalEnglish.lbConvertOutput;
        rbConvertAuto = InternalEnglish.rbConvertAuto;
        rbConvertAutoFFmpeg = InternalEnglish.rbConvertAutoFFmpeg;
        btnConvert = InternalEnglish.btnConvert;

        lbMergeInput1 = InternalEnglish.lbMergeInput1;
        lbMergeInput2 = InternalEnglish.lbMergeInput2;
        lbMergeOutput = InternalEnglish.lbMergeOutput;
        chkMergeAudioTracks = InternalEnglish.chkMergeAudioTracks;
        chkMergeDeleteInputFiles = InternalEnglish.chkMergeDeleteInputFiles;
        btnMerge = InternalEnglish.btnMerge;

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
        chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = InternalEnglish.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing;
        chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = InternalEnglish.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint;
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
        #endregion

        #region Updating
        tabDownloadsUpdating = InternalEnglish.tabDownloadsUpdating;


        chkSettingsDownloadsUseYoutubeDlsUpdater = InternalEnglish.chkSettingsDownloadsUseYoutubeDlsUpdater;
        chkSettingsDownloadsUseYoutubeDlsUpdaterHint = InternalEnglish.chkSettingsDownloadsUseYoutubeDlsUpdaterHint;
        lbSettingsDownloadsUpdatingYtdlType = InternalEnglish.lbSettingsDownloadsUpdatingYtdlType;
        cbSettingsDownloadsUpdatingYtdlTypeHint = InternalEnglish.cbSettingsDownloadsUpdatingYtdlTypeHint;
        llbSettingsDownloadsYtdlTypeViewRepo = InternalEnglish.llbSettingsDownloadsYtdlTypeViewRepo;
        llbSettingsDownloadsYtdlTypeViewRepoHint = InternalEnglish.llbSettingsDownloadsYtdlTypeViewRepoHint;
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
        #endregion

        #region frmLanguage
        frmLanguage = nameof(frmLanguage);
        btnLanguageRefresh = nameof(btnLanguageRefresh);
        btnLanguageDownload = nameof(btnLanguageDownload);
        #endregion

        #region frmLog
        frmLog = nameof(frmLog);
        frmLogClear = nameof(frmLogClear);
        #endregion

        #region frmMain
        mSettings = nameof(mSettings);
        mTools = nameof(mTools);
        mBatchDownload = nameof(mBatchDownload);
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

        lbConvertInput = nameof(lbConvertInput);
        lbConvertOutput = nameof(lbConvertOutput);
        rbConvertAuto = nameof(rbConvertAuto);
        rbConvertAutoFFmpeg = nameof(rbConvertAutoFFmpeg);
        btnConvert = nameof(btnConvert);

        lbMergeInput1 = nameof(lbMergeInput1);
        lbMergeInput2 = nameof(lbMergeInput2);
        lbMergeOutput = nameof(lbMergeOutput);
        chkMergeAudioTracks = nameof(chkMergeAudioTracks);
        chkMergeDeleteInputFiles = nameof(chkMergeDeleteInputFiles);
        btnMerge = nameof(btnMerge);

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
        chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = nameof(chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing);
        chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = nameof(chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint);
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
        #endregion

        #region Updating
        tabDownloadsUpdating = nameof(tabDownloadsUpdating);


        chkSettingsDownloadsUseYoutubeDlsUpdater = nameof(chkSettingsDownloadsUseYoutubeDlsUpdater);
        chkSettingsDownloadsUseYoutubeDlsUpdaterHint = nameof(chkSettingsDownloadsUseYoutubeDlsUpdaterHint);
        lbSettingsDownloadsUpdatingYtdlType = nameof(lbSettingsDownloadsUpdatingYtdlType);
        cbSettingsDownloadsUpdatingYtdlTypeHint = nameof(cbSettingsDownloadsUpdatingYtdlTypeHint);
        llbSettingsDownloadsYtdlTypeViewRepo = nameof(llbSettingsDownloadsYtdlTypeViewRepo);
        llbSettingsDownloadsYtdlTypeViewRepoHint = nameof(llbSettingsDownloadsYtdlTypeViewRepoHint);
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
                            case "currentlanguageshort":
                                CurrentLanguageShort = ReadValue;
                                continue;
                            case "currentlanguagehint":
                                CurrentLanguageHint = ReadValue;
                                continue;
                            case "currentlanguageversion":
                                CurrentLanguageVersion = ReadValue;
                                continue;
                            #endregion

                            #region Generics
                            case "genericinputbest":
                                GenericInputBest = ReadValue;
                                continue;
                            case "genericinputworst":
                                GenericInputWorst = ReadValue;
                                continue;
                            case "genericcancel":
                                GenericCancel = ReadValue;
                                continue;
                            case "genericskip":
                                GenericSkip = ReadValue;
                                continue;
                            case "genericsound":
                                GenericSound = ReadValue;
                                continue;
                            case "genericvideo":
                                GenericVideo = ReadValue;
                                continue;
                            case "genericaudio":
                                GenericAudio = ReadValue;
                                continue;
                            case "genericcustom":
                                GenericCustom = ReadValue;
                                continue;
                            case "genericretry":
                                GenericRetry = ReadValue;
                                continue;
                            case "genericstart":
                                GenericStart = ReadValue;
                                continue;
                            case "genericstop":
                                GenericStop = ReadValue;
                                continue;
                            case "genericexit":
                                GenericExit = ReadValue;
                                continue;
                            case "genericok":
                                GenericOk = ReadValue;
                                continue;
                            case "genericsave":
                                GenericSave = ReadValue;
                                continue;
                            case "genericadd":
                                GenericAdd = ReadValue;
                                continue;
                            case "genericclose":
                                GenericClose = ReadValue;
                                continue;
                            case "genericclear":
                                GenericClear = ReadValue;
                                continue;
                            case "genericremoveselected":
                                GenericRemoveSelected = ReadValue;
                                continue;
                            case "genericverifylinks":
                                GenericVerifyLinks = ReadValue;
                                continue;
                            case "genericdonotreencode":
                                GenericDoNotReEncode = ReadValue;
                                continue;
                            case "genericdonotremux":
                                GenericDoNotRemux = ReadValue;
                                continue;
                            case "genericdonotdownload":
                                GenericDoNotDownload = ReadValue;
                                continue;
                            case "genericunknownformat":
                                GenericUnknownFormat = ReadValue;
                                continue;
                            case "genericmoreinfo":
                                GenericMoreInfo = ReadValue;
                                continue;
                            case "generictitle":
                                GenericTitle = ReadValue;
                                continue;
                            case "genericlength":
                                GenericLength = ReadValue;
                                continue;
                            case "genericuploadedon":
                                GenericUploadedOn = ReadValue;
                                continue;

                            case "frmgenericdownloadprogress":
                                frmGenericDownloadProgress = ReadValue;
                                continue;
                            case "chcontainer":
                                chContainer = ReadValue;
                                continue;
                            case "chfilesize":
                                chFileSize = ReadValue;
                                continue;
                            case "chformatid":
                                chFormatId = ReadValue;
                                continue;
                            case "chvideoquality":
                                chVideoQuality = ReadValue;
                                continue;
                            case "chvideofps":
                                chVideoFPS = ReadValue;
                                continue;
                            case "chvideobitrate":
                                chVideoBitrate = ReadValue;
                                continue;
                            case "chvideodimension":
                                chVideoDimension = ReadValue;
                                continue;
                            case "chvideocodec":
                                chVideoCodec = ReadValue;
                                continue;
                            case "chaudiobitrate":
                                chAudioBitrate = ReadValue;
                                continue;
                            case "chaudiosamplerate":
                                chAudioSampleRate = ReadValue;
                                continue;
                            case "chaudiocodec":
                                chAudioCodec = ReadValue;
                                continue;
                            case "chaudiochannels":
                                chAudioChannels = ReadValue;
                                continue;
                            #endregion

                            #region Dialogs
                            case "dlgfirsttimeinitialmessage":
                                dlgFirstTimeInitialMessage = ReadValue;
                                continue;
                            case "dlgfirsttimedownloadfolder":
                                dlgFirstTimeDownloadFolder = ReadValue;
                                continue;
                            case "dlgfinddownloadfolder":
                                dlgFindDownloadFolder = ReadValue;
                                continue;
                            case "dlgfirsttimedownloadyoutubedl":
                                dlgFindDownloadFolder = ReadValue;
                                continue;
                            case "dlgfirsttimedownloadffmpeg":
                                dlgFindDownloadFolder = ReadValue;
                                continue;

                            case "dlgclipboardautodownloadnotice":
                                dlgClipboardAutoDownloadNotice = ReadValue;
                                continue;
                            case "dlgbatchdownloadclipboardscannernotice":
                                dlgBatchDownloadClipboardScannerNotice = ReadValue;
                                continue;

                            case "dlgmainargstxtdoesntexist":
                                dlgMainArgsTxtDoesntExist = ReadValue;
                                continue;
                            case "dlgmainargstxtisempty":
                                dlgMainArgsTxtIsEmpty = ReadValue;
                                continue;
                            case "dlgmainargsnonesaved":
                                dlgMainArgsNoneSaved = ReadValue;
                                continue;
                            case "dlgconvertselectfiletoconvert":
                                dlgConvertSelectFileToConvert = ReadValue;
                                continue;
                            case "dlgmergeselectfiletomerge":
                                dlgMergeSelectFileToMerge = ReadValue;
                                continue;
                            case "dlgsaveoutputfileas":
                                dlgSaveOutputFileAs = ReadValue;
                                continue;
                            case "dlglanguagehashnomatch":
                                dlgLanguageHashNoMatch = ReadValue;
                                continue;

                            case "dlgauthenticationcookiesfrombrowser":
                                dlgAuthenticationCookiesFromBrowser = ReadValue;
                                continue;

                            case "dlgupdatefailedtocheck":
                                dlgUpdateFailedToCheck = ReadValue;
                                continue;
                            case "dlgupdatenoupdateavailable":
                                dlgUpdateNoUpdateAvailable = ReadValue;
                                continue;
                            case "dlgupdatenobetaupdateavailable":
                                dlgUpdateNoBetaUpdateAvailable = ReadValue;
                                continue;
                            case "dlgupdatenovalidyoutubedl":
                                dlgUpdateNoValidYoutubeDl = ReadValue;
                                continue;
                            case "dlgupdatedyoutubedl":
                                dlgUpdatedYoutubeDl = ReadValue;
                                continue;
                            case "dlgupateyoutubedlnoupdaterequired":
                                dlgUpateYoutubeDlNoUpdateRequired = ReadValue;
                                continue;
                            case "dlgupdaterhashnomatch":
                                dlgUpdaterHashNoMatch = ReadValue;
                                continue;

                            case "frmfilenameschemahistory":
                                frmFileNameSchemaHistory = ReadValue;
                                continue;
                            #endregion

                            #region Shared downloader
                            case "pbdownloadprogressffmpegpostprocessing":
                                pbDownloadProgressFfmpegPostProcessing = ReadValue;
                                continue;
                            case "pbdownloadprogressembeddingsubtitles":
                                pbDownloadProgressEmbeddingSubtitles = ReadValue;
                                continue;
                            case "pbdownloadprogressembeddingmetadata":
                                pbDownloadProgressEmbeddingMetadata = ReadValue;
                                continue;
                            case "pbdownloadprogressmergingformats":
                                pbDownloadProgressMergingFormats = ReadValue;
                                continue;
                            case "pbdownloadprogressconverting":
                                pbDownloadProgressConverting = ReadValue;
                                continue;
                            #endregion

                            #region frmAbout
                            case "frmabout":
                                frmAbout = ReadValue;
                                continue;
                            case "lbaboutbody":
                                lbAboutBody = ReadValue;
                                continue;
                            case "llbcheckforupdates":
                                llbCheckForUpdates = ReadValue;
                                continue;
                            #endregion

                            #region frmArchiveDownloader
                            case "frmarchivedownloader":
                                frmArchiveDownloader = ReadValue;
                                continue;
                            case "lbarchivedownloaderdescription":
                                lbArchiveDownloaderDescription = ReadValue;
                                continue;
                            case "txtarchivedownloaderhint":
                                txtArchiveDownloaderHint = ReadValue;
                                continue;
                            #endregion

                            #region frmAuthentication
                            case "frmauthentication":
                                frmAuthentication = ReadValue;
                                continue;
                            case "lbauthnotice":
                                lbAuthNotice = ReadValue;
                                continue;
                            case "lbauthusername":
                                lbAuthUsername = ReadValue;
                                continue;
                            case "lbauthpassword":
                                lbAuthPassword = ReadValue;
                                continue;
                            case "lbauth2factor":
                                lbAuth2Factor = ReadValue;
                                continue;
                            case "lbauthcookiesfromfile":
                                lbAuthCookiesFromFile = ReadValue;
                                continue;
                            case "lbauthcookiesfrombrowser":
                                lbAuthCookiesFromBrowser = ReadValue;
                                continue;
                            case "lbauthvideopassword":
                                lbAuthVideoPassword = ReadValue;
                                continue;
                            case "chkauthusenetrc":
                                chkAuthUseNetrc = ReadValue;
                                continue;
                            case "lbauthnosave":
                                lbAuthNoSave = ReadValue;
                                continue;
                            case "btnauthbegindownload":
                                btnAuthBeginDownload = ReadValue;
                                continue;
                            #endregion

                            #region frmBatchConverter
                            case "frmbatchconverter":
                                frmBatchConverter = ReadValue;
                                continue;
                            case "lbbatchconverterinput":
                                lbBatchConverterInput = ReadValue;
                                continue;
                            case "txtbatchconverterinputfile":
                                txtBatchConverterInputFile = ReadValue;
                                continue;
                            case "lbbatchconverteroutput":
                                lbBatchConverterOutput = ReadValue;
                                continue;
                            case "txtbatchconverteroutputfile":
                                txtBatchConverterOutputFile = ReadValue;
                                continue;
                            case "txtbatchconvertercustomconversionarguments":
                                txtBatchConverterCustomConversionArguments = ReadValue;
                                continue;
                            case "sbbatchconverteridle":
                                sbBatchConverterIdle = ReadValue;
                                continue;
                            case "sbbatchconverterconverting":
                                sbBatchConverterConverting = ReadValue;
                                continue;
                            case "sbbatchconverterfinished":
                                sbBatchConverterFinished = ReadValue;
                                continue;
                            case "sbbatchconverteraborted":
                                sbBatchConverterAborted = ReadValue;
                                continue;
                            #endregion

                            #region frmBatchDownloader
                            // frmBatchDownloader
                            case "frmbatchdownload":
                                frmBatchDownload = ReadValue;
                                continue;
                            case "lbbatchdownloadlink":
                                lbBatchDownloadLink = ReadValue;
                                continue;
                            case "lbbatchdownloadtype":
                                lbBatchDownloadType = ReadValue;
                                continue;
                            case "lbbatchdownloadvideospecificargument":
                                lbBatchDownloadVideoSpecificArgument = ReadValue;
                                continue;
                            case "sbbatchdownloadloadargs":
                                sbBatchDownloadLoadArgs = ReadValue;
                                continue;
                            case "mbatchdownloaderloadargsfromsettings":
                                mBatchDownloaderLoadArgsFromSettings = ReadValue;
                                continue;
                            case "mbatchdownloaderloadargsfromargstxt":
                                mBatchDownloaderLoadArgsFromArgsTxt = ReadValue;
                                continue;
                            case "mbatchdownloaderloadargsfromfile":
                                mBatchDownloaderLoadArgsFromFile = ReadValue;
                                continue;
                            case "sbbatchdownloaderimportlinks":
                                sbBatchDownloaderImportLinks = ReadValue;
                                continue;
                            case "mbatchdownloaderimportlinksfromfile":
                                mBatchDownloaderImportLinksFromFile = ReadValue;
                                continue;
                            case "mbatchdownloaderimportlinksfromclipboard":
                                mBatchDownloaderImportLinksFromClipboard = ReadValue;
                                continue;
                            case "sbbatchdownloaderidle":
                                sbBatchDownloaderIdle = ReadValue;
                                continue;
                            case "sbbatchdownloaderdownloading":
                                sbBatchDownloaderDownloading = ReadValue;
                                continue;
                            case "sbbatchdownloaderfinished":
                                sbBatchDownloaderFinished = ReadValue;
                                continue;
                            case "sbbatchdownloaderaborted":
                                sbBatchDownloaderAborted = ReadValue;
                                continue;
                            case "chkbatchdownloadclipboardscanner":
                                chkBatchDownloadClipboardScanner = ReadValue;
                                continue;
                            #endregion

                            #region frmConverter
                            case "frmconverter":
                                frmConverter = ReadValue;
                                continue;
                            case "frmconvertercomplete":
                                frmConverterComplete = ReadValue;
                                continue;
                            case "frmconvertererror":
                                frmConverterError = ReadValue;
                                continue;
                            case "chkconvertercloseafterconversion":
                                chkConverterCloseAfterConversion = ReadValue;
                                continue;
                            case "btnconverterabortbatchconversions":
                                btnConverterAbortBatchConversions = ReadValue;
                                continue;
                            #endregion

                            #region frmDownloader
                            case "frmdownloader":
                                frmDownloader = ReadValue;
                                continue;
                            case "frmdownloadercomplete":
                                frmDownloaderComplete = ReadValue;
                                continue;
                            case "frmdownloadererror":
                                frmDownloaderError = ReadValue;
                                continue;
                            case "chkdownloadercloseafterdownload":
                                chkDownloaderCloseAfterDownload = ReadValue;
                                continue;
                            case "btndownloaderabortbatch":
                                btnDownloaderAbortBatch = ReadValue;
                                continue;
                            #endregion

                            #region frmDownloadLanguage
                            case "frmdownloadlanguage":
                                frmDownloadLanguage = ReadValue;
                                continue;
                            #endregion

                            #region frmException
                            case "frmexception":
                                frmException = ReadValue;
                                continue;
                            case "lbexceptionheader":
                                lbExceptionHeader = ReadValue;
                                continue;
                            case "lbexceptiondescription":
                                lbExceptionDescription = ReadValue;
                                continue;
                            case "rtbexceptiondetails":
                                rtbExceptionDetails = ReadValue;
                                continue;
                            case "btnexceptiongithub":
                                btnExceptionGithub = ReadValue;
                                continue;
                            case "tabexceptiondetails":
                                tabExceptionDetails = ReadValue;
                                continue;
                            case "tabexceptionextrainfo":
                                tabExceptionExtraInfo = ReadValue;
                                continue;
                            #endregion

                            #region frmExtendedDownloader
                            case "frmextendeddownloaderretrieving":
                                frmExtendedDownloaderRetrieving = ReadValue;
                                continue;
                            case "lbextendeddownloaderlink":
                                lbExtendedDownloaderLink = ReadValue;
                                continue;
                            case "lbextendeddownloaderuploader":
                                lbExtendedDownloaderUploader = ReadValue;
                                continue;
                            case "lbextendeddownloaderviews":
                                lbExtendedDownloaderViews = ReadValue;
                                continue;
                            case "lbextendeddownloaderdownloadingthumbnail":
                                lbExtendedDownloaderDownloadingThumbnail = ReadValue;
                                continue;
                            case "lbextendeddownloaderdownloadingthumbnailfailed":
                                lbExtendedDownloaderDownloadingThumbnailFailed = ReadValue;
                                continue;
                            case "btnextendeddownloaderdownloadthumbnail":
                                btnExtendedDownloaderDownloadThumbnail = ReadValue;
                                continue;
                            case "tabextendeddownloaderformatoptions":
                                tabExtendedDownloaderFormatOptions = ReadValue;
                                continue;
                            case "tabextendeddownloaderunknownformats":
                                tabExtendedDownloaderUnknownFormats = ReadValue;
                                continue;
                            case "tabextendeddownloaderdescription":
                                tabExtendedDownloaderDescription = ReadValue;
                                continue;
                            case "tabextendeddownloaderverbose":
                                tabExtendedDownloaderVerbose = ReadValue;
                                continue;
                            case "chkextendeddownloadervideoseparateaudio":
                                chkExtendedDownloaderVideoSeparateAudio = ReadValue;
                                continue;
                            case "lbextendeddownloadernovideoformatsavailable":
                                lbExtendedDownloaderNoVideoFormatsAvailable = ReadValue;
                                continue;
                            case "lbextendeddownloadernoaudioformatsavailable":
                                lbExtendedDownloaderNoAudioFormatsAvailable = ReadValue;
                                continue;
                            case "lbextendeddownloadernounknownformatsfound":
                                lbExtendedDownloaderNoUnknownFormatsFound = ReadValue;
                                continue;
                            case "lbvideoremux":
                                lbVideoRemux = ReadValue;
                                continue;
                            case "txtextendeddownloadermediatitle":
                                txtExtendedDownloaderMediaTitle = ReadValue;
                                continue;
                            #endregion

                            #region frmLanguage
                            case "frmlanguage":
                                frmLanguage = ReadValue;
                                continue;
                            case "btnlanguagerefresh":
                                btnLanguageRefresh = ReadValue;
                                continue;
                            case "btnlanguagedownload":
                                btnLanguageDownload = ReadValue;
                                continue;
                            #endregion

                            #region frmLog
                            case "frmlog":
                                frmLog = ReadValue;
                                continue;
                            case "frmlogclear":
                                frmLogClear = ReadValue;
                                continue;
                            #endregion

                            #region frmMain
                            // frmMain / menu
                            case "msettings":
                                mSettings = ReadValue;
                                continue;
                            case "mtools":
                                mTools = ReadValue;
                                continue;
                            case "mbatchdownload":
                                mBatchDownload = ReadValue;
                                continue;
                            case "mbatchconvert":
                                mBatchConvert = ReadValue;
                                continue;
                            case "marchivedownloader":
                                mArchiveDownloader = ReadValue;
                                continue;
                            case "mdownloadsubtitles":
                                mDownloadSubtitles = ReadValue;
                                continue;
                            case "mmisctools":
                                mMiscTools = ReadValue;
                                continue;
                            case "mclipboardautodownload":
                                mClipboardAutoDownload = ReadValue;
                                continue;
                            case "mhelp":
                                mHelp = ReadValue;
                                continue;
                            case "mlanguage":
                                mLanguage = ReadValue;
                                continue;
                            case "msupportedsites":
                                mSupportedSites = ReadValue;
                                continue;
                            case "mabout":
                                mAbout = ReadValue;
                                continue;

                            // frmMain / tcMain
                            case "tabdownload":
                                tabDownload = ReadValue;
                                continue;
                            case "tabconvert":
                                tabConvert = ReadValue;
                                continue;
                            case "tabmerge":
                                tabMerge = ReadValue;
                                continue;

                            // frmMain / tcMain / Download
                            case "lburl":
                                lbURL = ReadValue;
                                continue;
                            case "txturlhint":
                                txtUrlHint = ReadValue;
                                continue;
                            case "gbdownloadtype":
                                gbDownloadType = ReadValue;
                                continue;
                            case "lbquality":
                                lbQuality = ReadValue;
                                continue;
                            case "lbformat":
                                lbFormat = ReadValue;
                                continue;
                            case "chkuseselection":
                                chkUseSelection = ReadValue;
                                continue;
                            case "rbvideoselectionplaylistindex":
                                rbVideoSelectionPlaylistIndex = ReadValue;
                                continue;
                            case "rbvideoselectionplaylistitems":
                                rbVideoSelectionPlaylistItems = ReadValue;
                                continue;
                            case "rbvideoselectionbeforedate":
                                rbVideoSelectionBeforeDate = ReadValue;
                                continue;
                            case "rbvideoselectionondate":
                                rbVideoSelectionOnDate = ReadValue;
                                continue;
                            case "rbvideoselectionafterdate":
                                rbVideoSelectionAfterDate = ReadValue;
                                continue;
                            case "txtplayliststarthint":
                                txtPlaylistStartHint = ReadValue;
                                continue;
                            case "txtplaylistendhint":
                                txtPlaylistEndHint = ReadValue;
                                continue;
                            case "txtplaylistitemshint":
                                txtPlaylistItemsHint = ReadValue;
                                continue;
                            case "txtvideodatehint":
                                txtVideoDateHint = ReadValue;
                                continue;
                            case "lbcustomarguments":
                                lbCustomArguments = ReadValue;
                                continue;
                            case "sbdownload":
                                sbDownload = ReadValue;
                                continue;
                            case "btnmainextended":
                                btnMainExtended = ReadValue;
                                continue;
                            case "mdownloadwithauthentication":
                                mDownloadWithAuthentication = ReadValue;
                                continue;
                            case "mbatchdownloadfromfile":
                                mBatchDownloadFromFile = ReadValue;
                                continue;
                            case "msgbatchdownloadfromfile":
                                msgBatchDownloadFromFile = ReadValue;
                                continue;
                            case "mquickdownloadform":
                                mQuickDownloadForm = ReadValue;
                                continue;
                            case "mquickdownloadformauthentication":
                                mQuickDownloadFormAuthentication = ReadValue;
                                continue;
                            case "mextendeddownloadform":
                                mExtendedDownloadForm = ReadValue;
                                continue;

                            // frmMain / tcMain / Convert
                            case "lbconvertinput":
                                lbConvertInput = ReadValue;
                                continue;
                            case "lbconvertoutput":
                                lbConvertOutput = ReadValue;
                                continue;
                            case "rbconvertauto":
                                rbConvertAuto = ReadValue;
                                continue;
                            case "rbconvertautoffmpeg":
                                rbConvertAutoFFmpeg = ReadValue;
                                continue;
                            case "btnconvert":
                                btnConvert = ReadValue;
                                continue;

                            // frmMain / tcMain / Merge
                            case "lbmergeinput1":
                                lbMergeInput1 = ReadValue;
                                continue;
                            case "lbmergeinput2":
                                lbMergeInput2 = ReadValue;
                                continue;
                            case "lbmergeoutput":
                                lbMergeOutput = ReadValue;
                                continue;
                            case "chkmergeaudiotracks":
                                chkMergeAudioTracks = ReadValue;
                                continue;
                            case "chkmergedeleteinputfiles":
                                chkMergeDeleteInputFiles = ReadValue;
                                continue;
                            case "btnmerge":
                                btnMerge = ReadValue;
                                continue;

                            // frmMain / tcMain / cmTray
                            case "cmTrayShowForm":
                                cmTrayShowForm = ReadValue;
                                continue;
                            case "cmtraydownloader":
                                cmTrayDownloader = ReadValue;
                                continue;
                            case "cmtraydownloadclipboard":
                                cmTrayDownloadClipboard = ReadValue;
                                continue;
                            case "cmtraydownloadbestvideo":
                                cmTrayDownloadBestVideo = ReadValue;
                                continue;
                            case "cmtraydownloadbestaudio":
                                cmTrayDownloadBestAudio = ReadValue;
                                continue;
                            case "cmtraydownloadcustom":
                                cmTrayDownloadCustom = ReadValue;
                                continue;
                            case "cmtraydownloadcustomtxtbox":
                                cmTrayDownloadCustomTxtBox = ReadValue;
                                continue;
                            case "cmtraydownloadcustomtxt":
                                cmTrayDownloadCustomTxt = ReadValue;
                                continue;
                            case "cmtraydownloadcustomsettings":
                                cmTrayDownloadCustomSettings = ReadValue;
                                continue;
                            case "cmtrayconverter":
                                cmTrayConverter = ReadValue;
                                continue;
                            case "cmtrayconvertto":
                                cmTrayConvertTo = ReadValue;
                                continue;
                            case "cmtrayconvertvideo":
                                cmTrayConvertVideo = ReadValue;
                                continue;
                            case "cmtrayconvertaudio":
                                cmTrayConvertAudio = ReadValue;
                                continue;
                            case "cmtrayconvertcustom":
                                cmTrayConvertCustom = ReadValue;
                                continue;
                            case "cmtrayconvertautomatic":
                                cmTrayConvertAutomatic = ReadValue;
                                continue;
                            case "cmtrayconvertautoffmpeg":
                                cmTrayConvertAutoFFmpeg = ReadValue;
                                continue;
                            case "cmtrayexit":
                                cmTrayExit = ReadValue;
                                continue;
                            #endregion

                            #region frmSettings
                            case "frmsettings":
                                frmSettings = ReadValue;
                                continue;
                            case "btnsettingscancelhint":
                                btnSettingsCancelHint = ReadValue;
                                continue;
                            case "btnsettingssavehint":
                                btnSettingsSaveHint = ReadValue;
                                continue;

                            #region tabGeneral
                            case "tabsettingsgeneral":
                                tabSettingsGeneral = ReadValue;
                                continue;

                            case "tabsettingsgeneralyoutubedl":
                                tabSettingsGeneralYoutubeDl = ReadValue;
                                continue;
                            case "lbsettingsgeneralyoutubedlpath":
                                lbSettingsGeneralYoutubeDlPath = ReadValue;
                                continue;
                            case "lbsettingsgeneralyoutubedlpathhint":
                                lbSettingsGeneralYoutubeDlPathHint = ReadValue;
                                continue;
                            case "chksettingsgeneralusestaticyoutubedl":
                                chkSettingsGeneralUseStaticYoutubeDl = ReadValue;
                                continue;
                            case "chksettingsgeneralusestaticyoutubedlhint":
                                chkSettingsGeneralUseStaticYoutubeDlHint = ReadValue;
                                continue;
                            case "txtsettingsgeneralyoutubedlpathhint":
                                txtSettingsGeneralYoutubeDlPathHint = ReadValue;
                                continue;
                            case "btnsettingsgeneralbrowseyoutubedlhint":
                                btnSettingsGeneralBrowseYoutubeDlHint = ReadValue;
                                continue;
                            case "btnsettingsredownloadyoutubedl":
                                btnSettingsRedownloadYoutubeDl = ReadValue;
                                continue;
                            case "btnsettingsredownloadyoutubedlhint":
                                btnSettingsRedownloadYoutubeDlHint = ReadValue;
                                continue;
                            case "ofdtitleyoutubedl":
                                ofdTitleYoutubeDl = ReadValue;
                                continue;
                            case "ofdfilteryoutubedl":
                                ofdFilterYoutubeDl = ReadValue;
                                continue;


                            case "tabsettingsgeneralffmpeg":
                                tabSettingsGeneralFfmpeg = ReadValue;
                                continue;
                            case "lbsettingsgeneralffmpegdirectory":
                                lbSettingsGeneralFFmpegDirectory = ReadValue;
                                continue;
                            case "lbsettingsgeneralffmpegdirectoryhint":
                                lbSettingsGeneralFFmpegDirectoryHint = ReadValue;
                                continue;
                            case "chksettingsgeneralusestaticffmpeg":
                                chkSettingsGeneralUseStaticFFmpeg = ReadValue;
                                continue;
                            case "chksettingsgeneralusestaticffmpeghint":
                                chkSettingsGeneralUseStaticFFmpegHint = ReadValue;
                                continue;
                            case "txtsettingsgeneralffmpegpathhint":
                                txtSettingsGeneralFFmpegPathHint = ReadValue;
                                continue;
                            case "btnsettingsgeneralbrowseffmpeghint":
                                btnSettingsGeneralBrowseFFmpegHint = ReadValue;
                                continue;
                            case "btnsettingsredownloadffmpeg":
                                btnSettingsRedownloadFfmpeg = ReadValue;
                                continue;
                            case "btnsettingsredownloadffmpeghint":
                                btnSettingsRedownloadFfmpegHint = ReadValue;
                                continue;
                            case "ofdtitleffmpeg":
                                ofdTitleFFmpeg = ReadValue;
                                continue;
                            case "ofdfilterffmpeg":
                                ofdFilterFFmpeg = ReadValue;
                                continue;


                            case "chksettingsgeneralcheckforupdatesonlaunch":
                                chkSettingsGeneralCheckForUpdatesOnLaunch = ReadValue;
                                continue;
                            case "chksettingsgeneralcheckforupdatesonlaunchhint":
                                chkSettingsGeneralCheckForUpdatesOnLaunchHint = ReadValue;
                                continue;
                            case "chksettingsgeneralcheckforbetaupdates":
                                chkSettingsGeneralCheckForBetaUpdates = ReadValue;
                                continue;
                            case "chksettingsgeneralcheckforbetaupdateshint":
                                chkSettingsGeneralCheckForBetaUpdatesHint = ReadValue;
                                continue;
                            case "chksettingsgeneraldeleteupdaterafterupdating":
                                chkSettingsGeneralDeleteUpdaterAfterUpdating = ReadValue;
                                continue;
                            case "chksettingsgeneraldeleteupdaterafterupdatinghint":
                                chkSettingsGeneralDeleteUpdaterAfterUpdatingHint = ReadValue;
                                continue;
                            case "chkdeleteoldversionafterupdating":
                                chkDeleteOldVersionAfterUpdating = ReadValue;
                                continue;
                            case "chkdeleteoldversionafterupdatinghint":
                                chkDeleteOldVersionAfterUpdatingHint = ReadValue;
                                continue;
                            case "chksettingsgeneralhoveroverurltopasteclipboard":
                                chkSettingsGeneralHoverOverUrlToPasteClipboard = ReadValue;
                                continue;
                            case "chksettingsgeneralhoveroverurltopasteclipboardhint":
                                chkSettingsGeneralHoverOverUrlToPasteClipboardHint = ReadValue;
                                continue;
                            case "chksettingsgeneralclearurlondownload":
                                chkSettingsGeneralClearUrlOnDownload = ReadValue;
                                continue;
                            case "chksettingsgeneralclearurlondownloadhint":
                                chkSettingsGeneralClearUrlOnDownloadHint = ReadValue;
                                continue;
                            case "chksettingsgeneralclearclipboardondownload":
                                chkSettingsGeneralClearClipboardOnDownload = ReadValue;
                                continue;
                            case "chksettingsgeneralclearclipboardondownloadhint":
                                chkSettingsGeneralClearClipboardOnDownloadHint = ReadValue;
                                continue;
                            case "chksettingsgeneralautoupdateyoutubedl":
                                chkSettingsGeneralAutoUpdateYoutubeDl = ReadValue;
                                continue;
                            case "chksettingsgeneralautoupdateyoutubedlhint":
                                chkSettingsGeneralAutoUpdateYoutubeDlHint = ReadValue;
                                continue;
                            case "gbsettingsgeneralcustomarguments":
                                gbSettingsGeneralCustomArguments = ReadValue;
                                continue;
                            case "gbsettingsgeneralcustomargumentshint":
                                gbSettingsGeneralCustomArgumentsHint = ReadValue;
                                continue;
                            case "rbsettingsgeneralcustomargumentsdontsave":
                                rbSettingsGeneralCustomArgumentsDontSave = ReadValue;
                                continue;
                            case "rbsettingsgeneralcustomargumentsdontsavehint":
                                rbSettingsGeneralCustomArgumentsDontSaveHint = ReadValue;
                                continue;
                            case "rbsettingsgeneralcustomargumentssaveasargstext":
                                rbSettingsGeneralCustomArgumentsSaveAsArgsText = ReadValue;
                                continue;
                            case "rbsettingsgeneralcustomargumentssaveasargstexthint":
                                rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = ReadValue;
                                continue;
                            case "rbsettingsgeneralcustomargumentssaveinsettings":
                                rbSettingsGeneralCustomArgumentsSaveInSettings = ReadValue;
                                continue;
                            case "rbsettingsgeneralcustomargumentssaveinsettingshint":
                                rbSettingsGeneralCustomArgumentsSaveInSettingsHint = ReadValue;
                                continue;
                            #endregion

                            #region tabDownloads
                            case "tabsettingsdownloads":
                                tabSettingsDownloads = ReadValue;
                                continue;

                            case "lbsettingsdownloadsdownloadpath":
                                lbSettingsDownloadsDownloadPath = ReadValue;
                                continue;
                            case "lbsettingsdownloadsdownloadpathhint":
                                lbSettingsDownloadsDownloadPathHint = ReadValue;
                                continue;
                            case "chksettingsdownloadsdownloadpathuserelativepathhint":
                                chkSettingsDownloadsDownloadPathUseRelativePathHint = ReadValue;
                                continue;
                            case "txtsettingsdownloadssavepathhint":
                                txtSettingsDownloadsSavePathHint = ReadValue;
                                continue;
                            case "btnsettingsdownloadsbrowsesavepathhint":
                                btnSettingsDownloadsBrowseSavePathHint = ReadValue;
                                continue;
                            case "lbsettingsdownloadsfilenameschema":
                                lbSettingsDownloadsFileNameSchema = ReadValue;
                                continue;
                            case "lbsettingsdownloadsfilenameschemahint":
                                lbSettingsDownloadsFileNameSchemaHint = ReadValue;
                                continue;
                            case "llsettingsdownloadsschemahelphint":
                                llSettingsDownloadsSchemaHelpHint = ReadValue;
                                continue;
                            case "txtsettingsdownloadsfilenameschemahint":
                                txtSettingsDownloadsFileNameSchemaHint = ReadValue;
                                continue;
                            case "btnsettingsdownloadsfilenameschemahistory":
                                btnSettingsDownloadsFileNameSchemaHistory = ReadValue;
                                continue;
                            case "btnsettingsdownloadsfilenameschemahistoryhint":
                                btnSettingsDownloadsFileNameSchemaHistoryHint = ReadValue;
                                continue;
                            case "btnsettingsdownloadsinstallprotocolnotinstalled":
                                btnSettingsDownloadsInstallProtocolNotInstalled = ReadValue;
                                continue;
                            case "btnsettingsdownloadsinstallprotocolinstalled":
                                btnSettingsDownloadsInstallProtocolInstalled = ReadValue;
                                continue;
                            case "btnsettingsdownloadsinstallprotocolhint":
                                btnSettingsDownloadsInstallProtocolHint = ReadValue;
                                continue;


                            #region General
                            case "tabdownloadsgeneral":
                                tabDownloadsGeneral = ReadValue;
                                continue;

                            case "chksettingsdownloadssaveformatquality":
                                chkSettingsDownloadsSaveFormatQuality = ReadValue;
                                continue;
                            case "chksettingsdownloadssaveformatqualityhint":
                                chkSettingsDownloadsSaveFormatQualityHint = ReadValue;
                                continue;
                            case "chksettingsdownloadsdownloadsubtitles":
                                chkSettingsDownloadsDownloadSubtitles = ReadValue;
                                continue;
                            case "chksettingsdownloadsdownloadsubtitleshint":
                                chkSettingsDownloadsDownloadSubtitlesHint = ReadValue;
                                continue;
                            case "chksettingsdownloadsembedsubtitles":
                                chkSettingsDownloadsEmbedSubtitles = ReadValue;
                                continue;
                            case "chksettingsdownloadsembedsubtitleshint":
                                chkSettingsDownloadsEmbedSubtitlesHint = ReadValue;
                                continue;
                            case "chksettingsdownloadssavevideoinfo":
                                chkSettingsDownloadsSaveVideoInfo = ReadValue;
                                continue;
                            case "chksettingsdownloadssavevideoinfohint":
                                chkSettingsDownloadsSaveVideoInfoHint = ReadValue;
                                continue;
                            case "chksettingsdownloadswritemetadatatofile":
                                chkSettingsDownloadsWriteMetadataToFile = ReadValue;
                                continue;
                            case "chksettingsdownloadswritemetadatatofilehint":
                                chkSettingsDownloadsWriteMetadataToFileHint = ReadValue;
                                continue;
                            case "chksettingsdownloadssavedescription":
                                chkSettingsDownloadsSaveDescription = ReadValue;
                                continue;
                            case "chksettingsdownloadssavedescriptionhint":
                                chkSettingsDownloadsSaveDescriptionHint = ReadValue;
                                continue;
                            case "chksettingsdownloadskeeporiginalfiles":
                                chkSettingsDownloadsKeepOriginalFiles = ReadValue;
                                continue;
                            case "chksettingsdownloadskeeporiginalfileshint":
                                chkSettingsDownloadsKeepOriginalFilesHint = ReadValue;
                                continue;
                            case "chksettingsdownloadssaveannotations":
                                chkSettingsDownloadsSaveAnnotations = ReadValue;
                                continue;
                            case "chksettingsdownloadssaveannotationshint":
                                chkSettingsDownloadsSaveAnnotationsHint = ReadValue;
                                continue;
                            case "chksettingsdownloadssavethumbnails":
                                chkSettingsDownloadsSaveThumbnails = ReadValue;
                                continue;
                            case "chksettingsdownloadssavethumbnailshint":
                                chkSettingsDownloadsSaveThumbnailsHint = ReadValue;
                                continue;
                            case "chksettingsdownloadsembedthumbnails":
                                chkSettingsDownloadsEmbedThumbnails = ReadValue;
                                continue;
                            case "chksettingsdownloadsembedthumbnailshint":
                                chkSettingsDownloadsEmbedThumbnailsHint = ReadValue;
                                continue;
                            case "chksettingsdownloadsautomaticallydeleteyoutubedlwhenclosing":
                                chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = ReadValue;
                                continue;
                            case "chksettingsdownloadsautomaticallydeleteyoutubedlwhenclosinghint":
                                chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = ReadValue;
                                continue;
                            #endregion

                            #region Sorting
                            case "tabdownloadssorting":
                                tabDownloadsSorting = ReadValue;
                                continue;


                            case "chksettingsdownloadsseparatedownloadstodifferentfolders":
                                chkSettingsDownloadsSeparateDownloadsToDifferentFolders = ReadValue;
                                continue;
                            case "chksettingsdownloadsseparatedownloadstodifferentfoldershint":
                                chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = ReadValue;
                                continue;
                            case "chksettingsdownloadsseparateintowebsiteurl":
                                chkSettingsDownloadsSeparateIntoWebsiteUrl = ReadValue;
                                continue;
                            case "chksettingsdownloadsseparateintowebsiteurlhint":
                                chkSettingsDownloadsSeparateIntoWebsiteUrlHint = ReadValue;
                                continue;
                            case "chksettingsdownloadswebsitesubdomains":
                                chkSettingsDownloadsWebsiteSubdomains = ReadValue;
                                continue;
                            case "chksettingsdownloadswebsitesubdomainshint":
                                chkSettingsDownloadsWebsiteSubdomainsHint = ReadValue;
                                continue;
                            #endregion

                            #region Fixes
                            case "tabdownloadsfixes":
                                tabDownloadsFixes = ReadValue;
                                continue;


                            case "chksettingsdownloadsfixvreddit":
                                chkSettingsDownloadsFixVReddIt = ReadValue;
                                continue;
                            case "chksettingsdownloadsfixvreddithint":
                                chkSettingsDownloadsFixVReddItHint = ReadValue;
                                continue;
                            case "chksettingsdownloadspreferffmpeg":
                                chkSettingsDownloadsPreferFFmpeg = ReadValue;
                                continue;
                            case "chksettingsdownloadspreferffmpeghint":
                                chkSettingsDownloadsPreferFFmpegHint = ReadValue;
                                continue;
                            #endregion

                            #region Connection
                            case "tabdownloadsconnection":
                                tabDownloadsConnection = ReadValue;
                                continue;


                            case "chksettingsdownloadslimitdownload":
                                chkSettingsDownloadsLimitDownload = ReadValue;
                                continue;
                            case "chksettingsdownloadslimitdownloadhint":
                                chkSettingsDownloadsLimitDownloadHint = ReadValue;
                                continue;
                            case "numsettingsdownloadslimitdownloadhint":
                                numSettingsDownloadsLimitDownloadHint = ReadValue;
                                continue;
                            case "cbsettingsdownloadslimitdownloadhint":
                                cbSettingsDownloadsLimitDownloadHint = ReadValue;
                                continue;
                            case "lbsettingsdownloadsretryattempts":
                                lbSettingsDownloadsRetryAttempts = ReadValue;
                                continue;
                            case "lbsettingsdownloadsretryattemptshint":
                                lbSettingsDownloadsRetryAttemptsHint = ReadValue;
                                continue;
                            case "numsettingsdownloadsretryattemptshint":
                                numSettingsDownloadsRetryAttemptsHint = ReadValue;
                                continue;
                            case "chksettingsdownloadsforceipv4":
                                chkSettingsDownloadsForceIpv4 = ReadValue;
                                continue;
                            case "chksettingsdownloadsforceipv4hint":
                                chkSettingsDownloadsForceIpv4Hint = ReadValue;
                                continue;
                            case "chksettingsdownloadsforceipv6":
                                chkSettingsDownloadsForceIpv6 = ReadValue;
                                continue;
                            case "chksettingsdownloadsforceipv6hint":
                                chkSettingsDownloadsForceIpv6Hint = ReadValue;
                                continue;
                            case "chksettingsdownloadsuseproxy":
                                chkSettingsDownloadsUseProxy = ReadValue;
                                continue;
                            case "chksettingsdownloadsuseproxyhint":
                                chkSettingsDownloadsUseProxyHint = ReadValue;
                                continue;
                            case "cbsettingsdownloadsproxytypehint":
                                cbSettingsDownloadsProxyTypeHint = ReadValue;
                                continue;
                            case "txtsettingsdownloadsproxyiphint":
                                txtSettingsDownloadsProxyIpHint = ReadValue;
                                continue;
                            case "txtsettingsdownloadsproxyporthint":
                                txtSettingsDownloadsProxyPortHint = ReadValue;
                                continue;
                            #endregion

                            #region Updating
                            case "tabdownloadsupdating":
                                tabDownloadsUpdating = ReadValue;
                                continue;


                            case "chksettingsdownloadsuseyoutubedlsupdater":
                                chkSettingsDownloadsUseYoutubeDlsUpdater = ReadValue;
                                continue;
                            case "chksettingsdownloadsuseyoutubedlsupdaterhint":
                                chkSettingsDownloadsUseYoutubeDlsUpdaterHint = ReadValue;
                                continue;
                            case "lbsettingsdownloadsupdatingytdltype":
                                lbSettingsDownloadsUpdatingYtdlType = ReadValue;
                                continue;
                            case "cbsettingsdownloadsupdatingytdltypehint":
                                cbSettingsDownloadsUpdatingYtdlTypeHint = ReadValue;
                                continue;
                            case "llbsettingsdownloadsytdltypeviewrepo":
                                llbSettingsDownloadsYtdlTypeViewRepo = ReadValue;
                                continue;
                            case "llbsettingsdownloadsytdltypeviewrepohint":
                                llbSettingsDownloadsYtdlTypeViewRepoHint = ReadValue;
                                continue;
                            #endregion

                            #region Batch
                            case "tabdownloadsbatch":
                                tabDownloadsBatch = ReadValue;
                                continue;


                            case "chksettingsdownloadsseparatebatchdownloads":
                                chkSettingsDownloadsSeparateBatchDownloads = ReadValue;
                                continue;
                            case "chksettingsdownloadsseparatebatchdownloadshint":
                                chkSettingsDownloadsSeparateBatchDownloadsHint = ReadValue;
                                continue;
                            case "chksettingsdownloadsadddatetobatchdownloadfolders":
                                chkSettingsDownloadsAddDateToBatchDownloadFolders = ReadValue;
                                continue;
                            case "chksettingsdownloadsadddatetobatchdownloadfoldershint":
                                chkSettingsDownloadsAddDateToBatchDownloadFoldersHint = ReadValue;
                                continue;
                            #endregion

                            #region Extended downloader
                            case "tabextendedoptions":
                                tabExtendedOptions = ReadValue;
                                continue;


                            case "chkextendedpreferextendeddialog":
                                chkExtendedPreferExtendedDialog = ReadValue;
                                continue;
                            case "chkextendedpreferextendeddialoghint":
                                chkExtendedPreferExtendedDialogHint = ReadValue;
                                continue;
                            case "chkextendedautomaticallydownloadthumbnail":
                                chkExtendedAutomaticallyDownloadThumbnail = ReadValue;
                                continue;
                            case "chkextendedautomaticallydownloadthumbnailhint":
                                chkExtendedAutomaticallyDownloadThumbnailHint = ReadValue;
                                continue;
                            #endregion
                            #endregion

                            #region tabConverter
                            case "tabsettingsconverter":
                                tabSettingsConverter = ReadValue;
                                continue;

                            case "chksettingsconverterclearoutputafterconverting":
                                chkSettingsConverterClearOutputAfterConverting = ReadValue;
                                continue;
                            case "chksettingsconverterclearoutputafterconvertinghint":
                                chkSettingsConverterClearOutputAfterConvertingHint = ReadValue;
                                continue;
                            case "chksettingsconverterdetectoutputfiletype":
                                chkSettingsConverterDetectOutputFileType = ReadValue;
                                continue;
                            case "chksettingsconverterdetectoutputfiletypehint":
                                chkSettingsConverterDetectOutputFileTypeHint = ReadValue;
                                continue;
                            case "chksettingsconverterclearinputafterconverting":
                                chkSettingsConverterClearInputAfterConverting = ReadValue;
                                continue;
                            case "chksettingsconverterclearinputafterconvertinghint":
                                chkSettingsConverterClearInputAfterConvertingHint = ReadValue;
                                continue;
                            case "chksettingsconverterhideffmpegcompileinfo":
                                chkSettingsConverterHideFFmpegCompileInfo = ReadValue;
                                continue;
                            case "chksettingsconverterhideffmpegcompileinfohint":
                                chkSettingsConverterHideFFmpegCompileInfoHint = ReadValue;
                                continue;

                            #region Video
                            case "tcsettingsconvertervideo":
                                tcSettingsConverterVideo = ReadValue;
                                continue;

                            case "lbsettingsconvertervideobitrate":
                                lbSettingsConverterVideoBitrate = ReadValue;
                                continue;
                            case "lbsettingsconvertervideobitratehint":
                                lbSettingsConverterVideoBitrateHint = ReadValue;
                                continue;
                            case "lbsettingsconvertervideopreset":
                                lbSettingsConverterVideoPreset = ReadValue;
                                continue;
                            case "lbsettingsconvertervideopresethint":
                                lbSettingsConverterVideoPresetHint = ReadValue;
                                continue;
                            case "lbsettingsconvertervideoprofile":
                                lbSettingsConverterVideoProfile = ReadValue;
                                continue;
                            case "lbsettingsconvertervideoprofilehint":
                                lbSettingsConverterVideoProfileHint = ReadValue;
                                continue;
                            case "lbsettingsconvertervideocrf":
                                lbSettingsConverterVideoCRF = ReadValue;
                                continue;
                            case "lbsettingsconvertervideocrfhint":
                                lbSettingsConverterVideoCRFHint = ReadValue;
                                continue;
                            case "chksettingsconvertervideofaststart":
                                chkSettingsConverterVideoFastStart = ReadValue;
                                continue;
                            case "chksettingsconvertervideofaststarthint":
                                chkSettingsConverterVideoFastStartHint = ReadValue;
                                continue;
                            #endregion

                            #region Audio
                            case "tcsettingsconverteraudio":
                                tcSettingsConverterAudio = ReadValue;
                                continue;

                            case "lbsettingsconverteraudiobitrate":
                                lbSettingsConverterAudioBitrate = ReadValue;
                                continue;
                            case "lbsettingsconverteraudiobitratehint":
                                lbSettingsConverterAudioBitrateHint = ReadValue;
                                continue;
                            #endregion

                            #region Custom
                            case "tcsettingsconvertercustom":
                                tcSettingsConverterCustom = ReadValue;
                                continue;

                            case "lbsettingsconvertercustomheader":
                                lbSettingsConverterCustomHeader = ReadValue;
                                continue;
                            case "txtsettingsconvertercustomargumentshint":
                                txtSettingsConverterCustomArgumentsHint = ReadValue;
                                continue;
                            #endregion
                            #endregion

                            #region tabExtensions
                            case "tabsettingsextensions":
                                tabSettingsExtensions = ReadValue;
                                continue;

                            case "lbsettingsextensionsheader":
                                lbSettingsExtensionsHeader = ReadValue;
                                continue;
                            case "lbsettingsextensionsextensionfullname":
                                lbSettingsExtensionsExtensionFullName = ReadValue;
                                continue;
                            case "txtsettingsextensionsextensionfullname":
                                txtSettingsExtensionsExtensionFullName = ReadValue;
                                continue;
                            case "lbsettingsextensionsextensionshort":
                                lbSettingsExtensionsExtensionShort = ReadValue;
                                continue;
                            case "txtsettingsextensionsextensionshort":
                                txtSettingsExtensionsExtensionShort = ReadValue;
                                continue;
                            case "btnsettingsextensionsadd":
                                btnSettingsExtensionsAdd = ReadValue;
                                continue;
                            case "lbsettingsextensionsfilename":
                                lbSettingsExtensionsFileName = ReadValue;
                                continue;
                            case "btnsettingsextensionsremoveselected":
                                btnSettingsExtensionsRemoveSelected = ReadValue;
                                continue;
                            #endregion

                            #region tabErrors
                            case "tabsettingserrors":
                                tabSettingsErrors = ReadValue;
                                continue;

                            case "chksettingserrorsshowdetailederrors":
                                chkSettingsErrorsShowDetailedErrors = ReadValue;
                                continue;
                            case "chksettingserrorsshowdetailederrorshint":
                                chkSettingsErrorsShowDetailedErrorsHint = ReadValue;
                                continue;
                            case "chksettingserrorssaveerrorsaserrorlog":
                                chkSettingsErrorsSaveErrorsAsErrorLog = ReadValue;
                                continue;
                            case "chksettingserrorssaveerrorsaserrorloghint":
                                chkSettingsErrorsSaveErrorsAsErrorLogHint = ReadValue;
                                continue;
                            case "chksettingserrorssuppresserrors":
                                chkSettingsErrorsSuppressErrors = ReadValue;
                                continue;
                            case "chksettingserrorssuppresserrorshint":
                                chkSettingsErrorsSuppressErrorsHint = ReadValue;
                                continue;
                            #endregion
                            #endregion

                            #region frmSubtitles
                            case "frmsubtitles":
                                frmSubtitles = ReadValue;
                                continue;
                            case "lbsubtitlesheader":
                                lbSubtitlesHeader = ReadValue;
                                continue;
                            case "lbsubtitlesurl":
                                lbSubtitlesUrl = ReadValue;
                                continue;
                            case "lbsubtitleslanguages":
                                lbSubtitlesLanguages = ReadValue;
                                continue;
                            case "btnsubtitlesaddlanguage":
                                btnSubtitlesAddLanguage = ReadValue;
                                continue;
                            case "btnsubtitlesclearlanguages":
                                btnSubtitlesClearLanguages = ReadValue;
                                continue;
                            case "btnsubtitlesdownload":
                                btnSubtitlesDownload = ReadValue;
                                continue;
                            #endregion

                            #region frmTools
                            case "frmtools":
                                frmTools = ReadValue;
                                continue;
                            case "btnmisctoolsremoveaudio":
                                btnMiscToolsRemoveAudio = ReadValue;
                                continue;
                            case "btnmisctoolsextractaudio":
                                btnMiscToolsExtractAudio = ReadValue;
                                continue;
                            case "btnmisctoolsvideotogif":
                                btnMiscToolsVideoToGif = ReadValue;
                                continue;
                            #endregion

                            #region frmUpdateAvailable
                            case "frmupdateavailable":
                                frmUpdateAvailable = ReadValue;
                                continue;
                            case "lbupdateavailableheader":
                                lbUpdateAvailableHeader = ReadValue;
                                continue;
                            case "lbupdateavailableupdateversion":
                                lbUpdateAvailableUpdateVersion = ReadValue;
                                continue;
                            case "lbupdateavailablecurrentversion":
                                lbUpdateAvailableCurrentVersion = ReadValue;
                                continue;
                            case "lbupdateavailablechangelog":
                                lbUpdateAvailableChangelog = ReadValue;
                                continue;
                            case "lbupdatesize":
                                lbUpdateSize = ReadValue;
                                continue;
                            case "btnupdateavailableskipversion":
                                btnUpdateAvailableSkipVersion = ReadValue;
                                continue;
                            case "btnupdateavailableupdate":
                                btnUpdateAvailableUpdate = ReadValue;
                                continue;
                                #endregion

                        }
                    }
                }
                LoadedFile = LanguageFile;
                UsingInternalEnglish = false;
                Log.Write("Finished loading external language.");
                return true;
            }
        }
        catch (Exception ex) {
            if (Log.ReportLanguageException(ex, true) == System.Windows.Forms.DialogResult.Retry)
                return LoadLanguage(LanguageFile);

            LoadInternalEnglish();
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
                Key = Input.Split('=')[0].ToLowerInvariant().Trim();
                Value = string.Empty;
            } break;

            default: {
                if (Input.Contains("//"))
                    Input = Input[..Input.IndexOf("//")];
                Key = Input.Split('=')[0].ToLowerInvariant().Trim();
                Value = Input[(Input.IndexOf('=') + 1)..].Trim().Replace("\\n", "\n").Replace("\\r", "\r");
            } break;
        }
    }
    #endregion
}
