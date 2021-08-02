using System;

namespace youtube_dl_gui {

    /// <summary>
    /// Controls the language strings of the program. Most, if not all, strings get their text from here.
    /// </summary>
    public class Language {

        #region Instance
        /// <summary>
        /// The single instance of the language that contains all the strings.
        /// </summary>
        private static volatile Language LangInstance = new Language();
        /// <summary>
        /// Returns the shared Language instance between all forms.
        /// </summary>
        /// <returns>The Lanuage.LangInstance will be returned.</returns>
        public static Language GetInstance() {
            return LangInstance;
        }
        #endregion

        public Language() {
            //ResetControlNames();
        }

        #region Variables
        #region Language identifier
        // Language identifier
        private static volatile string LoadedFileString = null;
        private static volatile string CurrentLanguageLongString = "CurrentLanguageLong";
        private static volatile string CurrentLanguageShortString = "CurrentLanguageShort";
        private static volatile string CurrentLanguageHintString = "CurrentLanguageHint";
        private static volatile string CurrentLanguageVersionString = "1";
        #endregion

        #region Generics
        private static volatile string GenericInputBestString = "GenericInputBest";
        private static volatile string GenericCancelString = "GenericCancel";
        private static volatile string GenericSkipString = "GenericSkip";
        private static volatile string GenericSoundString = "GenericSound";
        private static volatile string GenericVideoString = "GenericVideo";
        private static volatile string GenericAudioString = "GenericAudio";
        private static volatile string GenericCustomString = "GenericCustom";
        private static volatile string GenericRetryString = "GenericRetry";
        #endregion

        #region frmAbout
        private static volatile string frmAboutString = "frmAbout";
        private static volatile string lbAboutBodyString = "lbAboutBody";
        private static volatile string llbCheckForUpdatesString = "llbCheckForUpdates";
        #endregion

        #region frmAuthentication
        private static volatile string frmAuthenticationString = "frmAuthentication";

        private static volatile string lbAuthNoticeString = "lbAuthNotice";

        private static volatile string lbAuthUsernameString = "lbAuthUsername";
        private static volatile string lbAuthPasswordString = "lbAuthPassword";
        private static volatile string lbAuth2FactorString = "lbAuth2Factor";
        private static volatile string lbAuthVideoPasswordString = "lbAuthVideoPassword";
        private static volatile string chkAuthUseNetrcString = "chkAuthUseNetrc";

        private static volatile string lbAuthNoSaveString = "lbAuthNoSave";

        private static volatile string btnAuthBeginDownloadString = "btnAuthBeginDownload";
        #endregion

        #region frmBatchDownload
        private static volatile string frmBatchDownloadString = "frmBatchDownload";
        private static volatile string lbBatchDownloadLinkString = "lbBatchDownloadLink";
        private static volatile string lbBatchDownloadTypeString = "lbBatchDownloadType";
        private static volatile string lbBatchDownloadVideoSpecificArgumentString = "lbBatchDownloadVideoSpecificArgument";
        private static volatile string btnBatchDownloadAddString = "btnBatchDownloadAdd";
        private static volatile string sbBatchDownloadLoadArgsString = "sbBatchDownloadLoadArgs";
        private static volatile string mBatchDownloaderLoadArgsFromSettingsString = "mBatchDownloaderLoadArgsFromSettings";
        private static volatile string mBatchDownloaderLoadArgsFromArgsTxtString = "mBatchDownloaderLoadArgsFromArgsTxt";
        private static volatile string mBatchDownloaderLoadArgsFromFileString = "mBatchDownloaderLoadArgsFromFile";
        private static volatile string btnBatchDownloadRemoveSelectedString = "btnBatchDownloadRemoveSelected";
        private static volatile string btnBatchDownloadStartString = "btnBatchDownloadStart";
        private static volatile string btnBatchDownloadStopString = "btnBatchDownloadStop";
        private static volatile string btnBatchDownloadExitString = "btnBatchDownloadExit";
        private static volatile string sbBatchDownloaderIdleString = "sbBatchDownloaderIdle";
        private static volatile string sbBatchDownloaderDownloadingString = "sbBatchDownloaderDownloading";
        private static volatile string sbBatchDownloaderFinishedString = "sbBatchDownloaderFinished";
        private static volatile string sbBatchDownloaderAbortedString = "sbBatchDownloaderAborted";
        #endregion

        #region frmDownloader
        private static volatile string frmDownloaderString = "frmDownloader";
        private static volatile string frmDownloaderCompleteString = "frmDownloaderComplete";
        private static volatile string frmDownloaderErrorString = "frmDownloaderError";
        private static volatile string chkDownloaderCloseAfterDownloadString = "chkDownloaderCloseAfterDownload";
        private static volatile string btnDownloaderAbortBatchString = "btnDownloaderAbortBatch";
        private static volatile string btnDownloaderExitString = "btnDownloaderExit";
        #endregion

        #region frmException
        // frmException
        private static volatile string frmExceptionString = "frmException";
        private static volatile string lbExceptionHeaderString = "lbExceptionHeader";
        private static volatile string lbExceptionDescriptionString = "lbExceptionDescription";
        private static volatile string rtbExceptionDetailsString = "rtbExceptionDetails";
        private static volatile string btnExceptionGithubString = "btnExceptionGithub";
        private static volatile string btnExceptionOkString = "btnExceptionOk";
        #endregion

        #region frmMain
        // frmMain / menu
        private static volatile string mSettingsString = "mSettings";
        private static volatile string mToolsString = "mTools";
        private static volatile string mBatchDownloadString = "mBatchDownload";
        private static volatile string mDownloadSubtitlesString = "mDownloadSubtitles";
        private static volatile string mMiscToolsString = "mMiscTools";
        private static volatile string mHelpString = "mHelp";
        private static volatile string mLanguageString = "mLanguage";
        private static volatile string mSupportedSitesString = "mSupportedSites";
        private static volatile string mAboutString = "mAbout";
        // frmMain /  tcMain
        private static volatile string tabDownloadString = "tabDownload";
        private static volatile string tabConvertString = "tabConvert";
        private static volatile string tabMergeString = "tabMerge";
        // frmMain / tcMain / Download (16 total)
        private static volatile string lbURLString = "lbURL";
        private static volatile string txtUrlHintString = "txtUrlHint";
        private static volatile string gbDownloadTypeString = "gbDownloadType";
        private static volatile string lbQualityString = "lbQuality";
        private static volatile string lbFormatString = "lbFormat";
        private static volatile string chkDownloadSoundString = "chkDownloadSound";
        private static volatile string chkUseSelectionString = "chkUseSelection";
        private static volatile string rbVideoSelectionPlaylistIndexString = "rbVideoSelectionPlaylistIndex";
        private static volatile string rbVideoSelectionPlaylistItemsString = "rbVideoSelectionPlaylistItems";
        private static volatile string rbVideoSelectionBeforeDateString = "rbVideoSelectionBeforeDate";
        private static volatile string rbVideoSelectionOnDateString = "rbVideoSelectionOnDate";
        private static volatile string rbVideoSelectionAfterDateString = "rbVideoSelectionAfterDate";
        private static volatile string txtPlaylistStartHintString = "txtPlaylistStartHint";
        private static volatile string txtPlaylistEndHintString = "txtPlaylistEndHint";
        private static volatile string txtPlaylistItemsHintString = "txtPlaylistItemsHint";
        private static volatile string txtVideoDateHintString = "txtVideoDateHint";
        private static volatile string lbCustomArgumentsString = "lbCustomArguments";
        private static volatile string txtArgsHintString = "txtArgsHint";
        private static volatile string sbDownloadString = "sbDownload";
        private static volatile string mDownloadWithAuthenticationString = "mDownloadWithAuthentication";
        private static volatile string mBatchDownloadFromFileString = "mBatchDownloadFromFile";
        private static volatile string msgBatchDownloadFromFileString = "msgBatchDownloadFromFile";
        private static volatile string lbDownloadStatusStartedString = "lbDownloadStatusStarted";
        private static volatile string lbDownloadStatusErrorString = "lbDownloadStatusError";
        // frmMain / tcMain / Convert (10 total)
        private static volatile string lbConvertInputString = "lbConvertInput";
        private static volatile string lbConvertOutputString = "lbConvertOutput";
        private static volatile string rbConvertAutoString = "rbConvertAutomatic";
        private static volatile string rbConvertAutoFFmpegString = "rbConvertAutoFFmpeg";
        private static volatile string btnConvertString = "btnConvert";
        private static volatile string lbConvertStartedString = "lbConvertStarted";
        private static volatile string lbConvertFailedString = "lbConvertFailed";
        // frmMain / tcMain / Merge (6 total)
        private static volatile string lbMergeInput1String = "lbMergeInput1";
        private static volatile string lbMergeInput2String = "lbMergeInput2";
        private static volatile string lbMergeOutputString = "lbMergeoutput";
        private static volatile string chkMergeAudioTracksString = "chkMergeAudioTracks";
        private static volatile string chkMergeDeleteInputFilesString = "chkMergeDeleteInputFiles";
        private static volatile string btnMergeString = "btnMerge";
        // frmMain / tcMain / cmTray (17 total)
        private static volatile string cmTrayShowFormString = "cmTrayShowForm";
        private static volatile string cmTrayDownloaderString = "cmTrayDownloader";
        private static volatile string cmTrayDownloadClipboardString = "cmTrayDownloadClipboard";
        private static volatile string cmTrayDownloadBestVideoString = "cmTrayDownloadBestVideo";
        private static volatile string cmTrayDownloadBestAudioString = "cmTrayDownloadBestAudio";
        private static volatile string cmTrayDownloadCustomString = "cmTrayDownloadCustom";
        private static volatile string cmTrayDownloadCustomTxtBoxString = "cmTrayDownloadCustomTxtBox";
        private static volatile string cmTrayDownloadCustomTxtString = "cmTrayDownloadCustomTxt";
        private static volatile string cmTrayDownloadCustomSettingsString = "cmTrayDownloadCustomSettings";
        private static volatile string cmTrayConverterString = "cmTrayConverter";
        private static volatile string cmTrayConvertToString = "cmTrayConvertTo";
        private static volatile string cmTrayConvertVideoString = "cmTrayConvertVideo";
        private static volatile string cmTrayConvertAudioString = "cmTrayConvertAudio";
        private static volatile string cmTrayConvertCustomString = "cmTrayConvertCustom";
        private static volatile string cmTrayConvertAutomaticString = "cmTrayConvertAutomatic";
        private static volatile string cmTrayConvertAutoFFmpegString = "cmTrayConvertAutoFFmpeg";
        private static volatile string cmTrayExitString = "cmTrayExit";
        #endregion

        #region frmLanguage
        private static volatile string frmLanguageString = "frmLanguage";
        private static volatile string btnLanguageRefreshString = "btnLanguageRefresh";
        private static volatile string btnLanguageCancelString = "btnLanguageCancel";
        private static volatile string btnLanguageSaveString = "btnLanguageSave";
        #endregion

        #region frmSettings

        #region frmSettings form
        // frmSettings
        private static volatile string frmSettingsString = "frmSettings";
        private static volatile string btnSettingsRedownloadYoutubeDlString = "btnSettingsRedownloadYoutubeDl";
        private static volatile string btnSettingsSaveString = "btnSettingsSave";
        // frmSettings / tcMain
        private static volatile string tabSettingsGeneralString = "tabSettingsGeneral";
        private static volatile string tabSettingsDownloadsString = "tabSettingsDownloads";
        private static volatile string tabSettingsConverterString = "tabSettingsConverter";
        private static volatile string tabSettingsExtensionsString = "tabSettingsExtensions";
        private static volatile string tabSettingsErrorsString = "tabSettingsErrors";
        #region tabGeneral
        // frmSettings / tcMain / tabGeneral
        private static volatile string lbSettingsGeneralYoutubeDlPathString = "lbSettingsGeneralYoutubeDlPath";
        private static volatile string chkSettingsGeneralUseStaticYoutubeDlString = "chkSettingsGeneralUseStaticYoutubeDl";
        private static volatile string ofdTitleYoutubeDlString = "ofdTitleYoutubeDl";
        private static volatile string ofdFilterYoutubeDlString = "ofdFilterYoutubeDl";
        private static volatile string lbSettingsGeneralFFmpegDirectoryString = "lbSettingsGeneralFFmpegDirectory";
        private static volatile string chkSettingsGeneralUseStaticFFmpegString = "chkSettingsGeneralUseStaticFFmpeg";
        private static volatile string ofdTitleFFmpegString = "ofdTitleFFmpeg";
        private static volatile string ofdFilterFFmpegString = "ofdFilterFFmpeg";
        private static volatile string chkSettingsGeneralCheckForUpdatesOnLaunchString = "chkSettingsGeneralCheckForUpdatesOnLaunch";
        private static volatile string chkSettingsGeneralCheckForBetaUpdatesString = "chkSettingsGeneralCheckForBetaUpdates";
        private static volatile string chkSettingsGeneralHoverOverUrlToPasteClipboardString = "chkSettingsGeneralHoverOverUrlToPasteClipboard";
        private static volatile string chkSettingsGeneralClearUrlOnDownloadString = "chkSettingsGeneralClearUrlOnDownload";
        private static volatile string chkSettingsGeneralClearClipboardOnDownloadString = "chkSettingsGeneralClearClipboardOnDownload";
        private static volatile string gbSettingsGeneralCustomArgumentsString = "gbSettingsGeneralCustomArguments";
        private static volatile string rbSettingsGeneralCustomArgumentsDontSaveString = "rbSettingsGeneralCustomArgumentsDontSave";
        private static volatile string rbSettingsGeneralCustomArgumentsSaveAsArgsTextString = "rbSettingsGeneralCustomArgumentsSaveAsArgsText";
        private static volatile string rbSettingsGeneralCustomArgumentsSaveInSettingsString = "rbSettingsGeneralCustomArgumentsSaveInSettings";
        #endregion
        #region tabDownloads
        // frmSettings / tcMain / tabDownloads
        private static volatile string lbSettingsDownloadsDownloadPathString = "lbSettingsDownloadsDownloadPath";
        private static volatile string lbSettingsDownloadsFileNameSchemaString = "lbSettingsDownloadsFileNameSchema";
        private static volatile string tabDownloadsGeneralString = "tabDownloadsGeneral";
        private static volatile string tabDownloadsSortingString = "tabDownloadsSorting";
        private static volatile string tabDownloadsFixesString = "tabsDownloadsFixes";
        private static volatile string tabDownloadsConnectionString = "tabsDownloadsConnection";
        private static volatile string tabDownloadsUpdatingString = "tabDownloadsUpdating";
        private static volatile string chkSettingsDownloadsSaveFormatQualityString = "chkSettingsDownloadsSaveFormatQuality";
        private static volatile string chkSettingsDownloadsDownloadSubtitlesString = "chkSettingsDownloadsDownloadSubtitles";
        private static volatile string chkSettingsDownloadsEmbedSubtitlesString = "chkSettingsDownloadsEmbedSubtitles";
        private static volatile string chkSettingsDownloadsSaveVideoInfoString = "chkSettingsDownloadsSaveVideoInfo";
        private static volatile string chkSettingsDownloadsWriteMetadataToFileString = "chkSettingsDownloadsWriteMetadataToFile";
        private static volatile string chkSettingsDownloadsSaveDescriptionString = "chkSettingsDownloadsSaveDescription";
        private static volatile string chkSettingsDownloadsKeepOriginalFilesString = "chkSettingsDownloadsKeepOriginalFiles";
        private static volatile string chkSettingsDownloadsSaveAnnotationsString = "chkSettingsDownloadsSaveAnnotations";
        private static volatile string chkSettingsDownloadsSaveThumbnailsString = "chkSettingsDownloadsSaveThumbnails";
        private static volatile string chkSettingsDownloadsEmbedThumbnailsString = "chkSettingsDownloadsEmbedThumbnails";
        private static volatile string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingString = "chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing";
        private static volatile string chkSettingsDownloadsSeparateDownloadsToDifferentFoldersString = "chkSettingsDownloadsSeparateDownloadsToDifferentFolders";
        private static volatile string chkSettingsDownloadsSeparateIntoWebsiteUrlString = "chkSettingsDownloadsSeparateIntoWebsiteUrl";
        private static volatile string chkSettingsDownloadsFixVReddItString = "chkSettingsDownloadsFixVReddIt";
        private static volatile string chkSettingsDownloadsPreferFFmpegString = "chkSettingsDownloadsPreferFFmpeg";
        private static volatile string chkSettingsDownloadsLimitDownloadString = "chkSettingsDownloadsLimitDownload";
        private static volatile string lbSettingsDownloadsRetryAttemptsString = "lbSettingsDownloadsRetryAttempts";
        private static volatile string chkSettingsDownloadsForceIpv4String = "chkSettingsDownloadsForceIpv4";
        private static volatile string chkSettingsDownloadsForceIpv6String = "chkSettingsDownloadsForceIpv6";
        private static volatile string chkSettingsDownloadsUseProxyString = "chkSettingsDownloadsUseProxy";
        private static volatile string chksettingsDownloadsUseYoutubeDlsUpdaterString = "chksettingsDownloadsUseYoutubeDlsUpdater";
        private static volatile string lbSettingsDownloadsUpdatingYtdlTypeString = "lbSettingsDownloadsUpdatingYtdlType";
        private static volatile string cbSettingsDownloadsUpdatingYtdlTypeHintString = "cbSettingsDownloadsUpdatingYtdlTypeHint";
        private static volatile string llbSettingsDownloadsYtdlTypeViewRepoString = "llbSettingsDownloadsYtdlTypeViewRepo";
        private static volatile string llbSettingsDownloadsYtdlTypeViewRepoHintString = "llbSettingsDownloadsYtdlTypeViewRepoHint";
        private static volatile string chkSettingsDownloadsSeparateBatchDownloadsString = "chkSettingsDownloadsSeparateBatchDownloads";
        private static volatile string chkSettingsDownloadsAddDateToBatchDownloadFoldersString = "chkSettingsDownloadsAddDateToBatchDownloadFolders";
        #endregion
        #region tabConverter
        // frmSettings / tcMain / tabConverter
        private static volatile string chkSettingsConverterClearOutputAfterConvertingString = "chkSettingsConverterClearOutputAfterConverting";
        private static volatile string chkSettingsConverterDetectOutputFileTypeString = "chkSettingsConverterDetectOutputFileType";
        private static volatile string chkSettingsConverterClearInputAfterConvertingString = "chkSettingsConverterClearInputAfterConverting";
        private static volatile string chkSettingsConverterHideFFmpegCompileInfoString = "chkSettingsConverterHideFFmpegCompileInfo";
        private static volatile string tcSettingsConverterVideoString = "tcSettingsConverterVideo";
        private static volatile string tcSettingsConverterAudioString = "tcSettingsConverterAudio";
        private static volatile string tcSettingsConverterCustomString = "tcSettingsConverterCustom";
        private static volatile string lbSettingsConverterVideoBitrateString = "lbSettingsConverterVideoBitrate";
        private static volatile string lbSettingsConverterVideoPresetString = "lbSettingsConverterVideoPreset";
        private static volatile string lbSettingsConverterVideoProfileString = "lbSettingsConverterVideoProfile";
        private static volatile string lbSettingsConverterVideoCRFString = "lbSettingsConverterVideoCRF";
        private static volatile string chkSettingsConverterVideoFastStartString = "chkSettingsConverterVideoFastStart";
        private static volatile string lbSettingsConverterAudioBitrateString = "lbSettingsConverterAudioBitrate";
        private static volatile string lbSettingsConverterCustomHeaderString = "lbSettingsConverterCustomHeader";
        #endregion
        #region tabExtensions
        // frmSettings / tcMain / tabExtensions
        private static volatile string lbSettingsExtensionsHeaderString = "lbSettingsExtensionsHeader";
        private static volatile string lbSettingsExtensionsExtensionFullNameString = "lbSettingsExtensionsExtensionFullName";
        private static volatile string txtSettingsExtensionsExtensionFullNameString = "txtSettingsExtensionsExtensionFullName";
        private static volatile string lbSettingsExtensionsExtensionShortString = "lbSettingsExtensionsExtensionShort";
        private static volatile string txtSettingsExtensionsExtensionShortString = "txtSettingsExtensionsExtensionShort";
        private static volatile string btnSettingsExtensionsAddString = "btnSettingsExtensionsAdd";
        private static volatile string lbSettingsExtensionsFileNameString = "lbSettingsExtensionsFileName";
        private static volatile string btnSettingsExtensionsRemoveSelectedString = "btnSettingsExtensionsRemoveSelected";
        #endregion
        #region tabErrors
        // frmSettings / tcMain / tabErrors
        private static volatile string chkSettingsErrorsShowDetailedErrorsString = "chkSettingsErrorsShowDetailedErrors";
        private static volatile string chkSettingsErrorsSaveErrorsAsErrorLogString = "chkSettingsErrorsSaveErrorsAsErrorLog";
        private static volatile string chkSettingsErrorsSuppressErrorsString = "chkSettingsErrorsSuppressErrors";
        #endregion
        #region tabSettingsPortable
        private static volatile string tabSettingsPortableString = "tabSettingsPortable";
        private static volatile string lbSettingsPortableInformationString = "lbPortableInformation";
        private static volatile string chkSettingsPortableToggleIniString = "chkPortableEnableIni";
        #endregion
        #endregion

        #region tipSettings
        // frmSettings / tipSettings
        private static volatile string btnSettingsRedownloadYoutubeDlHintString = "btnSettingsRedownloadYoutubeDlHint";
        private static volatile string btnSettingsCancelHintString = "btnSettingsCancelHint";
        private static volatile string btnSettingsSaveHintString = "btnSettingsSaveHint";

        #region tabGeneral
        private static volatile string lbSettingsGeneralYoutubeDlPathHintString = "lbSettingsGeneralYoutubeDlPathHint";
        private static volatile string chkSettingsGeneralUseStaticYoutubeDlHintString = "chkSettingsGeneralUseStaticYoutubeDlHint";
        private static volatile string txtSettingsGeneralYoutubeDlPathHintString = "txtSettingsGeneralYoutubeDlPathHint";
        private static volatile string btnSettingsGeneralBrowseYoutubeDlHintString = "btnSettingsGeneralBrowseYoutubeDlHint";
        private static volatile string lbSettingsGeneralFFmpegDirectoryHintString = "lbSettingsGeneralFFmpegDirectoryHint";
        private static volatile string chkSettingsGeneralUseStaticFFmpegHintString = "chkSettingsGeneralUseStaticFFmpegHint";
        private static volatile string txtSettingsGeneralFFmpegPathHintString = "txtSettingsGeneralFFmpegPathHint";
        private static volatile string btnSettingsGeneralBrowseFFmpegHintString = "btnSettingsGeneralBrowseFFmpegHint";
        private static volatile string chkSettingsGeneralCheckForUpdatesOnLaunchHintString = "chkSettingsGeneralCheckForUpdatesOnLaunchHint";
        private static volatile string chkSettingsGeneralCheckForBetaUpdatesHintString = "chkSettingsGeneralCheckForBetaUpdatesHint";
        private static volatile string chkSettingsGeneralHoverOverUrlToPasteClipboardHintString = "chkSettingsGeneralHoverOverUrlToPasteClipboardHint";
        private static volatile string chkSettingsGeneralClearUrlOnDownloadHintString = "chkSettingsGeneralClearUrlOnDownloadHint";
        private static volatile string chkSettingsGeneralClearClipboardOnDownloadHintString = "chkSettingsGeneralClearClipboardOnDownloadHint";
        private static volatile string gbSettingsGeneralCustomArgumentsHintString = "gbSettingsGeneralCustomArgumentsHint";
        private static volatile string rbSettingsGeneralCustomArgumentsDontSaveHintString = "rbSettingsGeneralCustomArgumentsDontSaveHint";
        private static volatile string rbSettingsGeneralCustomArgumentsSaveAsArgsTextHintString = "rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint";
        private static volatile string rbSettingsGeneralCustomArgumentsSaveInSettingsHintString = "rbSettingsGeneralCustomArgumentsSaveInSettingsHint";
        #endregion
        #region tabDownloads
        private static volatile string lbSettingsDownloadsDownloadPathHintString = "lbSettingsDownloadsDownloadPathHint";
        private static volatile string chkSettingsDownloadsDownloadPathUseRelativePathHintString = "chkSettingsDownloadsDownloadPathUseRelativePathHint";
        private static volatile string txtSettingsDownloadsSavePathHintString = "txtSettingsDownloadsSavePathHint";
        private static volatile string btnSettingsDownloadsBrowseSavePathHintString = "btnSettingsDownloadsBrowseSavePathHint";
        private static volatile string llSettingsDownloadsSchemaHelpHintString = "llSettingsDownloadsSchemaHelpHint";
        private static volatile string lbSettingsDownloadsFileNameSchemaHintString = "lbSettingsDownloadsFileNameSchemaHint";
        private static volatile string txtSettingsDownloadsFileNameSchemaHintString = "txtSettingsDownloadsFileNameSchemaHint";


        private static volatile string chkSettingsDownloadsSaveFormatQualityHintString = "chkSettingsDownloadsSaveFormatQualityHint";
        private static volatile string chkSettingsDownloadsDownloadSubtitlesHintString = "chkSettingsDownloadsDownloadSubtitlesHint";
        private static volatile string chkSettingsDownloadsEmbedSubtitlesHintString = "chkSettingsDownloadsEmbedSubtitlesHint";
        private static volatile string chkSettingsDownloadsSaveVideoInfoHintString = "chkSettingsDownloadsSaveVideoInfoHint";
        private static volatile string chkSettingsDownloadsWriteMetadataToFileHintString = "chkSettingsDownloadsWriteMetadataToFileHint";
        private static volatile string chkSettingsDownloadsSaveDescriptionHintString = "chkSettingsDownloadsSaveDescriptionHint";
        private static volatile string chkSettingsDownloadsKeepOriginalFilesHintString = "chkSettingsDownloadsKeepOriginalFilesHint";
        private static volatile string chkSettingsDownloadsSaveAnnotationsHintString = "chkSettingsDownloadsSaveAnnotationsHint";
        private static volatile string chkSettingsDownloadsSaveThumbnailsHintString = "chkSettingsDownloadsSaveThumbnailsHint";
        private static volatile string chkSettingsDownloadsEmbedThumbnailsHintString = "chkSettingsDownloadsEmbedThumbnails";
        private static volatile string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHintString = "chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint";
        private static volatile string chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHintString = "chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint";
        private static volatile string chkSettingsDownloadsSeparateIntoWebsiteUrlHintString = "chkSettingsDownloadsSeparateIntoWebsiteUrlHint";
        private static volatile string chkSettingsDownloadsFixVReddItHintString = "chkSettingsDownloadsFixVReddItHint";
        private static volatile string chkSettingsDownloadsPreferFFmpegHintString = "chkSettingsDownloadsPreferFFmpegHint";
        private static volatile string chkSettingsDownloadsLimitDownloadHintString = "chkSettingsDownloadsLimitDownloadHint";
        private static volatile string numSettingsDownloadsLimitDownloadHintString = "numSettingsDownloadsLimitDownloadHint";
        private static volatile string cbSettingsDownloadsLimitDownloadHintString = "cbSettingsDownloadsDownloadLimitHint";
        private static volatile string lbSettingsDownloadsRetryAttemptsHintString = "lbSettingsDownloadsRetryAttemptsHint";
        private static volatile string numSettingsDownloadsRetryAttemptsHintString = "numSettingsDownloadsRetryAttemptsHint";
        private static volatile string chkSettingsDownloadsForceIpv4HintString = "chkSettingsDownloadsForceIpv4Hint";
        private static volatile string chkSettingsDownloadsForceIpv6HintString = "chkSettingsDownloadsForceIpv6Hint";
        private static volatile string chkSettingsDownloadsUseProxyHintString = "chkSettingsDownloadsUseProxyHint";
        private static volatile string cbSettingsDownloadsProxyTypeHintString = "cbSettingsDownloadsProxyTypeHint";
        private static volatile string txtSettingsDownloadsProxyIpHintString = "txtSettingsDownloadsProxyIpHint";
        private static volatile string txtSettingsDownloadsProxyPortHintString = "txtSettingsDownloadsProxyPortHint";
        private static volatile string chksettingsDownloadsUseYoutubeDlsUpdaterHintString = "chksettingsDownloadsUseYoutubeDlsUpdaterHint";
        private static volatile string chkSettingsDownloadsSeparateBatchDownloadsHintString = "chkSettingsDownloadsSeparateBatchDownloadsHint";
        private static volatile string chkSettingsDownloadsAddDateToBatchDownloadFoldersHintString = "chkSettingsDownloadsAddDateToBatchDownloadFoldersHint";
        #endregion
        #region tabConverter
        private static volatile string chkSettingsConverterClearOutputAfterConvertingHintString = "chkSettingsConverterClearOutputAfterConvertingHint";
        private static volatile string chkSettingsConverterDetectOutputFileTypeHintString = "chkSettingsConverterDetectOutputFileTypeHint";
        private static volatile string chkSettingsConverterClearInputAfterConvertingHintString = "chkSettingsConverterClearInputAfterConvertingHint";
        private static volatile string chkSettingsConverterHideFFmpegCompileInfoHintString = "chkSettingsConverterHideFFmpegCompileInfoHint";
        private static volatile string lbSettingsConverterVideoBitrateHintString = "lbSettingsConverterVideoBitrateHint";
        private static volatile string lbSettingsConverterVideoPresetHintString = "lbSettingsConverterVideoPresetHint";
        private static volatile string lbSettingsConverterVideoProfileHintString = "lbSettingsConverterVideoProfileHint";
        private static volatile string lbSettingsConverterVideoCRFHintString = "lbSettingsConverterVideoCRFHint";
        private static volatile string chkSettingsConverterVideoFastStartHintString = "chkSettingsConverterVideoFastStartHint";
        private static volatile string lbSettingsConverterAudioBitrateHintString = "lbSettingsConverterAudioBitrateHint";
        private static volatile string txtSettingsConverterCustomArgumentsHintString = "txtSettingsConverterCustomArgumentsHint";
        #endregion
        #region tabExtension

        #endregion
        #region tabErrors
        private static volatile string chkSettingsErrorsShowDetailedErrorsHintString = "chkSettingsErrorsShowDetailedErrorsHint";
        private static volatile string chkSettingsErrorsSaveErrorsAsErrorLogHintString = "chkSettingsErrorsSaveErrorsAsErrorLogHint";
        private static volatile string chkSettingsErrorsSuppressErrorsHintString = "chkSettingsErrorsSuppressErrorsHint";
        #endregion

        #endregion

        #endregion

        #region frmSubtitles
        //frmSubtitles
        private static volatile string frmSubtitlesString = "frmSubtitles";
        private static volatile string lbSubtitlesHeaderString = "lbSubtitlesHeader";
        private static volatile string lbSubtitlesUrlString = "lbSubtitlesUrl";
        private static volatile string lbSubtitlesLanguagesString = "lbSubtitlesLanguages";
        private static volatile string btnSubtitlesAddLanguageString = "btnSubtitlesAddLanguages";
        private static volatile string btnSubtitlesClearLanguagesString = "btnSubtitlesClearLanguages";
        private static volatile string btnSubtitlesDownloadString = "btnSubtitlesDownload";
        #endregion

        #region frmTools
        // frmTools
        private static volatile string frmToolsString = "frmTools";
        private static volatile string btnMiscToolsRemoveAudioString = "btnMiscToolsRemoveAudio";
        private static volatile string btnMiscToolsExtractAudioString = "btnExtractAudio";
        private static volatile string btnMiscToolsVideoToGifString = "btnVideoToGif";
        #endregion

        #region frmUpdateAvailable
        private static volatile string frmUpdateAvailableString = "frmUpdateAvailable";
        private static volatile string lbUpdateAvailableHeaderString = "lbUpdateAvailableHeader";
        private static volatile string lbUpdateAvailableUpdateVersionString = "lbUpdateAvailableUpdateVersion";
        private static volatile string lbUpdateAvailableCurrentVersionString = "lbUpdateAvailableCurrentVersion";
        private static volatile string lbUpdateAvailableChangelogString = "lbUpdateAvailableChangelog";
        private static volatile string btnUpdateAvailableSkipVersionString = "btnUpdateAvailableSkipVersion";
        private static volatile string btnUpdateAvailableUpdateString = "btnUpdateAvailableUpdate";
        private static volatile string btnUpdateAvailableOkString = "btnUpdateAvailableOk";
        #endregion
        #endregion

        #region GetSetRadio
        #region Language identifier
        public string CurrentLanguageShort {
            get { return CurrentLanguageShortString; }
            private set { CurrentLanguageShortString = value; }
        }
        public string CurrentLanguageLong {
            get { return CurrentLanguageLongString; }
            private set { CurrentLanguageLongString = value; }
        }
        public string CurrentLanguageHint {
            get { return CurrentLanguageHintString; }
            private set { CurrentLanguageHintString = value; }
        }
        public string CurrentLanguageVersion {
            get { return CurrentLanguageVersionString; }
            private set { CurrentLanguageVersionString = value; }
        }
        #endregion

        #region Generics
        public string GenericInputBest {
            get { return GenericInputBestString; }
            private set { GenericInputBestString = value; }
        }
        public string GenericCancel {
            get { return GenericCancelString; }
            private set { GenericCancelString = value; }
        }
        public string GenericSkip {
            get { return GenericSkipString; }
            private set { GenericSkipString = value; }
        }
        public string GenericSound {
            get { return GenericSoundString; }
            private set { GenericSoundString = value; }
        }
        public string GenericVideo {
            get { return GenericVideoString; }
            private set { GenericVideoString = value; }
        }
        public string GenericAudio {
            get { return GenericAudioString; }
            private set { GenericAudioString = value; }
        }
        public string GenericCustom {
            get { return GenericCustomString; }
            private set { GenericCustomString = value; }
        }
        public string GenericRetry {
            get { return GenericRetryString; }
            private set { GenericRetryString = value; }
        }
        #endregion

        #region frmAbout
        public string frmAbout {
            get { return frmAboutString; }
            private set { frmAboutString = value; }
        }
        public string lbAboutBody {
            get { return lbAboutBodyString; }
            private set { lbAboutBodyString = value; }
        }
        public string llbCheckForUpdates {
            get { return llbCheckForUpdatesString; }
            private set { llbCheckForUpdatesString = value; }
        }
        #endregion

        #region frmAuthentication
        public string frmAuthentication {
            get { return frmAuthenticationString; }
            private set { frmAuthenticationString = value; }
        }
        public string lbAuthNotice {
            get { return lbAuthNoticeString; }
            private set { lbAuthNoticeString = value; }
        }
        public string lbAuthUsername {
            get { return lbAuthUsernameString; }
            private set { lbAuthUsernameString = value; }
        }
        public string lbAuthPassword {
            get { return lbAuthPasswordString; }
            private set { lbAuthPasswordString = value; }
        }
        public string lbAuth2Factor {
            get { return lbAuth2FactorString; }
            private set { lbAuth2FactorString = value; }
        }
        public string lbAuthVideoPassword {
            get { return lbAuthVideoPasswordString; }
            private set { lbAuthVideoPasswordString = value; }
        }
        public string chkAuthUseNetrc {
            get { return chkAuthUseNetrcString; }
            private set { chkAuthUseNetrcString = value; }
        }
        public string lbAuthNoSave {
            get { return lbAuthNoSaveString; }
            private set { lbAuthNoSaveString = value; }
        }
        public string btnAuthBeginDownload {
            get { return btnAuthBeginDownloadString; }
            private set { btnAuthBeginDownloadString = value; }
        }
        #endregion

        #region frmBatchDownloader
        public string frmBatchDownload {
            get { return frmBatchDownloadString; }
            private set { frmBatchDownloadString = value; }
        }
        public string lbBatchDownloadLink {
            get { return lbBatchDownloadLinkString; }
            private set { lbBatchDownloadLinkString = value; }
        }
        public string lbBatchDownloadType {
            get { return lbBatchDownloadTypeString; }
            private set { lbBatchDownloadTypeString = value; }
        }
        public string lbBatchDownloadVideoSpecificArgument {
            get { return lbBatchDownloadVideoSpecificArgumentString; }
            private set { lbBatchDownloadVideoSpecificArgumentString = value; }
        }
        public string btnBatchDownloadAdd {
            get { return btnBatchDownloadAddString; }
            private set { btnBatchDownloadAddString = value; }
        }
        public string btnBatchDownloadRemoveSelected {
            get { return btnBatchDownloadRemoveSelectedString; }
            private set { btnBatchDownloadRemoveSelectedString = value; }
        }
        public string sbBatchDownloadLoadArgs {
            get { return sbBatchDownloadLoadArgsString; }
            private set { sbBatchDownloadLoadArgsString = value; }
        }
        public string mBatchDownloaderLoadArgsFromSettings {
            get { return mBatchDownloaderLoadArgsFromSettingsString; }
            private set { mBatchDownloaderLoadArgsFromSettingsString = value; }
        }
        public string mBatchDownloaderLoadArgsFromArgsTxt {
            get { return mBatchDownloaderLoadArgsFromArgsTxtString; }
            private set { mBatchDownloaderLoadArgsFromArgsTxtString = value; }
        }
        public string mBatchDownloaderLoadArgsFromFile {
            get { return mBatchDownloaderLoadArgsFromFileString; }
            private set { mBatchDownloaderLoadArgsFromFileString = value; }
        }
        public string btnBatchDownloadStart {
            get { return btnBatchDownloadStartString; }
            private set { btnBatchDownloadStartString = value; }
        }
        public string btnBatchDownloadStop {
            get { return btnBatchDownloadStopString; }
            private set { btnBatchDownloadStopString = value; }
        }
        public string btnBatchDownloadExit {
            get { return btnBatchDownloadExitString; }
            private set { btnBatchDownloadExitString = value; }
        }
        public string sbBatchDownloaderIdle {
            get { return sbBatchDownloaderIdleString; }
            private set { sbBatchDownloaderIdleString = value; }
        }
        public string sbBatchDownloaderDownloading {
            get { return sbBatchDownloaderDownloadingString; }
            private set { sbBatchDownloaderDownloadingString = value; }
        }
        public string sbBatchDownloaderFinished {
            get { return sbBatchDownloaderFinishedString; }
            private set { sbBatchDownloaderFinishedString = value; }
        }
        public string sbBatchDownloaderAborted {
            get { return sbBatchDownloaderAbortedString; }
            private set { sbBatchDownloaderAbortedString = value; }
        }
        #endregion

        #region frmDownloader
        public string frmDownloader {
            get { return frmDownloaderString; }
            private set { frmDownloaderString = value; }
        }
        public string frmDownloaderComplete {
            get { return frmDownloaderCompleteString; }
            private set { frmDownloaderCompleteString = value; }
        }
        public string frmDownloaderError {
            get { return frmDownloaderErrorString; }
            private set { frmDownloaderErrorString = value; }
        }
        public string chkDownloaderCloseAfterDownload {
            get { return chkDownloaderCloseAfterDownloadString; }
            private set { chkDownloaderCloseAfterDownloadString = value; }
        }
        public string btnDownloaderAbortBatch {
            get { return btnDownloaderAbortBatchString; }
            private set { btnDownloaderAbortBatchString = value; }
        }
        public string btnDownloaderExit {
            get { return btnDownloaderExitString; }
            private set { btnDownloaderExitString = value; }
        }
        #endregion

        #region frmException
        public string frmException {
            get { return frmExceptionString; }
            private set { frmExceptionString = value; }
        }
        public string lbExceptionHeader {
            get { return lbExceptionHeaderString; }
            private set { lbExceptionHeaderString = value; }
        }
        public string lbExceptionDescription {
            get { return lbExceptionDescriptionString; }
            private set { lbExceptionDescriptionString = value; }
        }
        public string rtbExceptionDetails {
            get { return rtbExceptionDetailsString; }
            private set { rtbExceptionDetailsString = value; }
        }
        public string btnExceptionGithub {
            get { return btnExceptionGithubString; }
            private set { btnExceptionGithubString = value; }
        }
        public string btnExceptionOk {
            get { return btnExceptionOkString; }
            private set { btnExceptionOkString = value; }
        }
        #endregion

        #region frmLanguage
        public string frmLanguage {
            get { return frmLanguageString; }
            private set { frmLanguageString = value; }
        }
        public string btnLanguageRefresh {
            get { return btnLanguageRefreshString; }
            private set { btnLanguageRefreshString = value; }
        }
        public string btnLanguageCancel {
            get { return btnLanguageCancelString; }
            private set { btnLanguageCancelString = value; }
        }
        public string btnLanguageSave {
            get { return btnLanguageSaveString; }
            private set { btnLanguageSaveString = value; }
        }
        #endregion

        #region frmMain
        public string mSettings {
            get { return mSettingsString; }
            private set { mSettingsString = value; }
        }
        public string mTools {
            get { return mToolsString; }
            private set { mToolsString = value; }
        }
        public string mBatchDownload {
            get { return mBatchDownloadString; }
            private set { mBatchDownloadString = value; }
        }
        public string mDownloadSubtitles {
            get { return mDownloadSubtitlesString; }
            private set { mDownloadSubtitlesString = value; }
        }
        public string mMiscTools {
            get { return mMiscToolsString; }
            private set { mMiscToolsString = value; }
        }
        public string mHelp {
            get { return mHelpString; }
            private set { mHelpString = value; }
        }
        public string mLanguage {
            get { return mLanguageString; }
            private set { mLanguageString = value; }
        }
        public string mSupportedSites {
            get { return mSupportedSitesString; }
            private set { mSupportedSitesString = value; }
        }
        public string mAbout {
            get { return mAboutString; }
            private set { mAboutString = value; }
        }

        public string tabDownload {
            get { return tabDownloadString; }
            private set { tabDownloadString = value; }
        }
        public string tabConvert {
            get { return tabConvertString; }
            private set { tabConvertString = value; }
        }
        public string tabMerge {
            get { return tabMergeString; }
            private set { tabMergeString = value; }
        }

        public string lbURL {
            get { return lbURLString; }
            private set { lbURLString = value; }
        }
        public string txtUrlHint {
            get { return txtUrlHintString; }
            private set { txtUrlHintString = value; }
        }
        public string gbDownloadType {
            get { return gbDownloadTypeString; }
            private set { gbDownloadTypeString = value; }
        }
        public string lbQuality {
            get { return lbQualityString; }
            private set { lbQualityString = value; }
        }
        public string lbFormat {
            get { return lbFormatString; }
            private set { lbFormatString = value; }
        }
        public string chkDownloadSound {
            get { return chkDownloadSoundString; }
            private set { chkDownloadSoundString = value; }
        }
        public string chkUseSelection {
            get { return chkUseSelectionString; }
            private set { chkUseSelectionString = value; }
        }
        public string rbVideoSelectionPlaylistIndex {
            get { return rbVideoSelectionPlaylistIndexString; }
            private set { rbVideoSelectionPlaylistIndexString = value; }
        }
        public string rbVideoSelectionPlaylistItems {
            get { return rbVideoSelectionPlaylistItemsString; }
            private set { rbVideoSelectionPlaylistItemsString = value; }
        }
        public string rbVideoSelectionBeforeDate {
            get { return rbVideoSelectionBeforeDateString; }
            private set { rbVideoSelectionBeforeDateString = value; }
        }
        public string rbVideoSelectionOnDate {
            get { return rbVideoSelectionOnDateString; }
            private set { rbVideoSelectionOnDateString = value; }
        }
        public string rbVideoSelectionAfterDate {
            get { return rbVideoSelectionAfterDateString; }
            private set { rbVideoSelectionAfterDateString = value; }
        }
        public string txtPlaylistStartHint {
            get { return txtPlaylistStartHintString; }
            private set { txtPlaylistStartHintString = value; }
        }
        public string txtPlaylistEndHint {
            get { return txtPlaylistEndHintString; }
            private set { txtPlaylistEndHintString = value; }
        }
        public string txtPlaylistItemsHint {
            get { return txtPlaylistItemsHintString; }
            private set { txtPlaylistItemsHintString = value; }
        }
        public string txtVideoDateHint {
            get { return txtVideoDateHintString; }
            private set { txtVideoDateHintString = value; }
        }
        public string lbCustomArguments {
            get { return lbCustomArgumentsString; }
            private set { lbCustomArgumentsString = value; }
        }
        public string txtArgsHint {
            get { return txtArgsHintString; }
            private set { txtArgsHintString = value; }
        }
        public string sbDownload {
            get { return sbDownloadString; }
            private set { sbDownloadString = value; }
        }
        public string mDownloadWithAuthentication {
            get { return mDownloadWithAuthenticationString; }
            private set { mDownloadWithAuthenticationString = value; }
        }
        public string mBatchDownloadFromFile {
            get { return mBatchDownloadFromFileString; }
            private set { mBatchDownloadFromFileString = value; }
        }
        public string msgBatchDownloadFromFile {
            get { return msgBatchDownloadFromFileString; }
            private set { msgBatchDownloadFromFileString = value; }
        }
        public string lbDownloadStatusStarted {
            get { return lbDownloadStatusStartedString; }
            private set { lbDownloadStatusStartedString = value; }
        }
        public string lbDownloadStatusError {
            get { return lbDownloadStatusErrorString; }
            private set { lbDownloadStatusErrorString = value; }
        }

        public string lbConvertInput {
            get { return lbConvertInputString; }
            private set { lbConvertInputString = value; }
        }
        public string lbConvertOutput {
            get { return lbConvertOutputString; }
            private set { lbConvertOutputString = value; }
        }
        public string rbConvertAuto {
            get { return rbConvertAutoString; }
            private set { rbConvertAutoString = value; }
        }
        public string rbConvertAutoFFmpeg {
            get { return rbConvertAutoFFmpegString; }
            private set { rbConvertAutoFFmpegString = value; }
        }
        public string btnConvert {
            get { return btnConvertString; }
            private set { btnConvertString = value; }
        }
        public string lbConvertStarted {
            get { return lbConvertStartedString; }
            private set { lbConvertStartedString = value; }
        }
        public string lbConvertFailed {
            get { return lbConvertFailedString; }
            private set { lbConvertFailedString = value; }
        }

        public string lbMergeInput1 {
            get { return lbMergeInput1String; }
            private set { lbMergeInput1String = value; }
        }
        public string lbMergeInput2 {
            get { return lbMergeInput2String; }
            private set { lbMergeInput2String = value; }
        }
        public string lbMergeOutput {
            get { return lbMergeOutputString; }
            private set { lbMergeOutputString = value; }
        }
        public string chkMergeAudioTracks {
            get { return chkMergeAudioTracksString; }
            private set { chkMergeAudioTracksString = value; }
        }
        public string chkMergeDeleteInputFiles {
            get { return chkMergeDeleteInputFilesString; }
            private set { chkMergeDeleteInputFilesString = value; }
        }
        public string btnMerge {
            get { return btnMergeString; }
            private set { btnMergeString = value; }
        }

        public string cmTrayShowForm {
            get { return cmTrayShowFormString; }
            private set { cmTrayShowFormString = value; }
        }
        public string cmTrayDownloader {
            get { return cmTrayDownloaderString; }
            private set { cmTrayDownloaderString = value; }
        }
        public string cmTrayDownloadClipboard {
            get { return cmTrayDownloadClipboardString; }
            private set { cmTrayDownloadClipboardString = value; }
        }
        public string cmTrayDownloadBestVideo {
            get { return cmTrayDownloadBestVideoString; }
            private set { cmTrayDownloadBestVideoString = value; }
        }
        public string cmTrayDownloadBestAudio {
            get { return cmTrayDownloadBestAudioString; }
            private set { cmTrayDownloadBestAudioString = value; }
        }
        public string cmTrayDownloadCustom {
            get { return cmTrayDownloadCustomString; }
            private set { cmTrayDownloadCustomString = value; }
        }
        public string cmTrayDownloadCustomTxtBox {
            get { return cmTrayDownloadCustomTxtBoxString; }
            private set { cmTrayDownloadCustomTxtBoxString = value; }
        }
        public string cmTrayDownloadCustomTxt {
            get { return cmTrayDownloadCustomTxtString; }
            private set { cmTrayDownloadCustomTxtString = value; }
        }
        public string cmTrayDownloadCustomSettings {
            get { return cmTrayDownloadCustomSettingsString; }
            private set { cmTrayDownloadCustomSettingsString = value; }
        }
        public string cmTrayConverter {
            get { return cmTrayConverterString; }
            private set { cmTrayConverterString = value; }
        }
        public string cmTrayConvertTo {
            get { return cmTrayConvertToString; }
            private set { cmTrayConvertToString = value; }
        }
        public string cmTrayConvertVideo {
            get { return cmTrayConvertVideoString; }
            private set { cmTrayConvertVideoString = value; }
        }
        public string cmTrayConvertAudio {
            get { return cmTrayConvertAudioString; }
            private set { cmTrayConvertAudioString = value; }
        }
        public string cmTrayConvertCustom {
            get { return cmTrayConvertCustomString; }
            private set { cmTrayConvertCustomString = value; }
        }
        public string cmTrayConvertAutomatic {
            get { return cmTrayConvertAutomaticString; }
            private set { cmTrayConvertAutomaticString = value; }
        }
        public string cmTrayConvertAutoFFmpeg {
            get { return cmTrayConvertAutoFFmpegString; }
            private set { cmTrayConvertAutoFFmpegString = value; }
        }
        public string cmTrayExit {
            get { return cmTrayExitString; }
            private set { cmTrayExitString = value; }
        }
        #endregion

        #region frmSettings

        #region frmSettings form
        public string frmSettings {
            get { return frmSettingsString; }
            private set { frmSettingsString = value; }
        }
        public string btnSettingsRedownloadYoutubeDl {
            get { return btnSettingsRedownloadYoutubeDlString; }
            private set { btnSettingsRedownloadYoutubeDlString = value; }
        }
        public string btnSettingsSave {
            get { return btnSettingsSaveString; }
            private set { btnSettingsSaveString = value; }
        }

        public string tabSettingsGeneral {
            get { return tabSettingsGeneralString; }
            private set { tabSettingsGeneralString = value; }
        }
        public string tabSettingsDownloads {
            get { return tabSettingsDownloadsString; }
            private set { tabSettingsDownloadsString = value; }
        }
        public string tabSettingsConverter {
            get { return tabSettingsConverterString; }
            private set { tabSettingsConverterString = value; }
        }
        public string tabSettingsExtensions {
            get { return tabSettingsExtensionsString; }
            private set { tabSettingsExtensionsString = value; }
        }
        public string tabSettingsErrors {
            get { return tabSettingsErrorsString; }
            private set { tabSettingsErrorsString = value; }
        }
        public string tabSettingsPortable {
            get { return tabSettingsPortableString; }
            private set { tabSettingsPortableString = value; }
        }

        public string lbSettingsGeneralYoutubeDlPath {
            get { return lbSettingsGeneralYoutubeDlPathString; }
            private set { lbSettingsGeneralYoutubeDlPathString = value; }
        }
        public string chkSettingsGeneralUseStaticYoutubeDl {
            get { return chkSettingsGeneralUseStaticYoutubeDlString; }
            private set { chkSettingsGeneralUseStaticYoutubeDlString = value; }
        }
        public string ofdTitleYoutubeDl {
            get { return ofdTitleYoutubeDlString; }
            private set { ofdTitleYoutubeDlString = value; }
        }
        public string ofdFilterYoutubeDl {
            get { return ofdFilterYoutubeDlString; }
            private set { ofdFilterYoutubeDlString = value; }
        }
        public string lbSettingsGeneralFFmpegDirectory {
            get { return lbSettingsGeneralFFmpegDirectoryString; }
            private set { lbSettingsGeneralFFmpegDirectoryString = value; }
        }
        public string chkSettingsGeneralUseStaticFFmpeg {
            get { return chkSettingsGeneralUseStaticFFmpegString; }
            private set { chkSettingsGeneralUseStaticFFmpegString = value; }
        }
        public string ofdTitleFFmpeg {
            get { return ofdTitleFFmpegString; }
            private set { ofdTitleFFmpegString = value; }
        }
        public string ofdFilterFFmpeg {
            get { return ofdFilterFFmpegString; }
            private set { ofdFilterFFmpegString = value; }
        }
        public string chkSettingsGeneralCheckForUpdatesOnLaunch {
            get { return chkSettingsGeneralCheckForUpdatesOnLaunchString; }
            private set { chkSettingsGeneralCheckForUpdatesOnLaunchString = value; }
        }
        public string chkSettingsGeneralCheckForBetaUpdates {
            get { return chkSettingsGeneralCheckForBetaUpdatesString; }
            private set { chkSettingsGeneralCheckForBetaUpdatesString = value; }
        }
        public string chkSettingsGeneralHoverOverUrlToPasteClipboard {
            get { return chkSettingsGeneralHoverOverUrlToPasteClipboardString; }
            private set { chkSettingsGeneralHoverOverUrlToPasteClipboardString = value; }
        }
        public string chkSettingsGeneralClearUrlOnDownload {
            get { return chkSettingsGeneralClearUrlOnDownloadString; }
            private set { chkSettingsGeneralClearUrlOnDownloadString = value; }
        }
        public string chkSettingsGeneralClearClipboardOnDownload {
            get { return chkSettingsGeneralClearClipboardOnDownloadString; }
            private set { chkSettingsGeneralClearClipboardOnDownloadString = value; }
        }
        public string gbSettingsGeneralCustomArguments {
            get { return gbSettingsGeneralCustomArgumentsString; }
            private set { gbSettingsGeneralCustomArgumentsString = value; }
        }
        public string rbSettingsGeneralCustomArgumentsDontSave {
            get { return rbSettingsGeneralCustomArgumentsDontSaveString; }
            private set { rbSettingsGeneralCustomArgumentsDontSaveString = value; }
        }
        public string rbSettingsGeneralCustomArgumentsSaveAsArgsText {
            get { return rbSettingsGeneralCustomArgumentsSaveAsArgsTextString; }
            private set { rbSettingsGeneralCustomArgumentsSaveAsArgsTextString = value; }
        }
        public string rbSettingsGeneralCustomArgumentsSaveInSettings {
            get { return rbSettingsGeneralCustomArgumentsSaveInSettingsString; }
            private set { rbSettingsGeneralCustomArgumentsSaveInSettingsString = value; }
        }

        public string lbSettingsDownloadsDownloadPath {
            get { return lbSettingsDownloadsDownloadPathString; }
            private set { lbSettingsDownloadsDownloadPathString = value; }
        }
        public string lbSettingsDownloadsFileNameSchema {
            get { return lbSettingsDownloadsFileNameSchemaString; }
            private set { lbSettingsDownloadsFileNameSchemaString = value; }
        }
        public string tabDownloadsGeneral {
            get { return tabDownloadsGeneralString; }
            private set { tabDownloadsGeneralString = value; }
        }
        public string tabDownloadsSorting {
            get { return tabDownloadsSortingString; }
            private set { tabDownloadsSortingString = value; }
        }
        public string tabDownloadsFixes {
            get { return tabDownloadsFixesString; }
            private set { tabDownloadsFixesString = value; }
        }
        public string tabDownloadsConnection {
            get { return tabDownloadsConnectionString; }
            private set { tabDownloadsConnectionString = value; }
        }
        public string tabDownloadsUpdating {
            get { return tabDownloadsUpdatingString; }
            private set { tabDownloadsUpdatingString = value; }
        }
        public string chkSettingsDownloadsSaveFormatQuality {
            get { return chkSettingsDownloadsSaveFormatQualityString; }
            private set { chkSettingsDownloadsSaveFormatQualityString = value; }
        }
        public string chkSettingsDownloadsDownloadSubtitles {
            get { return chkSettingsDownloadsDownloadSubtitlesString; }
            private set { chkSettingsDownloadsDownloadSubtitlesString = value; }
        }
        public string chkSettingsDownloadsEmbedSubtitles {
            get { return chkSettingsDownloadsEmbedSubtitlesString; }
            private set { chkSettingsDownloadsEmbedSubtitlesString = value; }
        }
        public string chkSettingsDownloadsSaveVideoInfo {
            get { return chkSettingsDownloadsSaveVideoInfoString; }
            private set { chkSettingsDownloadsSaveVideoInfoString = value; }
        }
        public string chkSettingsDownloadsWriteMetadataToFile {
            get { return chkSettingsDownloadsWriteMetadataToFileString; }
            private set { chkSettingsDownloadsWriteMetadataToFileString = value; }
        }
        public string chkSettingsDownloadsSaveDescription {
            get { return chkSettingsDownloadsSaveDescriptionString; }
            private set { chkSettingsDownloadsSaveDescriptionString = value; }
        }
        public string chkSettingsDownloadsKeepOriginalFiles {
            get { return chkSettingsDownloadsKeepOriginalFilesString; }
            private set { chkSettingsDownloadsKeepOriginalFilesString = value; }
        }
        public string chkSettingsDownloadsSaveAnnotations {
            get { return chkSettingsDownloadsSaveAnnotationsString; }
            private set { chkSettingsDownloadsSaveAnnotationsString = value; }
        }
        public string chkSettingsDownloadsSaveThumbnails {
            get { return chkSettingsDownloadsSaveThumbnailsString; }
            private set { chkSettingsDownloadsSaveThumbnailsString = value; }
        }
        public string chkSettingsDownloadsEmbedThumbnails {
            get { return chkSettingsDownloadsEmbedThumbnailsString; }
            private set { chkSettingsDownloadsEmbedThumbnailsString = value; }
        }
        public string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing {
            get { return chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingString; }
            private set { chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingString = value; }
        }
        public string chkSettingsDownloadsSeparateDownloadsToDifferentFolders {
            get { return chkSettingsDownloadsSeparateDownloadsToDifferentFoldersString; }
            private set { chkSettingsDownloadsSeparateDownloadsToDifferentFoldersString = value; }
        }
        public string chkSettingsDownloadsSeparateIntoWebsiteUrl {
            get { return chkSettingsDownloadsSeparateIntoWebsiteUrlString; }
            private set { chkSettingsDownloadsSeparateIntoWebsiteUrlString = value; }
        }
        public string chkSettingsDownloadsFixVReddIt {
            get { return chkSettingsDownloadsFixVReddItString; }
            private set { chkSettingsDownloadsFixVReddItString = value; }
        }
        public string chkSettingsDownloadsPreferFFmpeg {
            get { return chkSettingsDownloadsPreferFFmpegString; }
            private set { chkSettingsDownloadsPreferFFmpegString = value; }
        }
        public string chkSettingsDownloadsLimitDownload {
            get { return chkSettingsDownloadsLimitDownloadString; }
            private set { chkSettingsDownloadsLimitDownloadString = value; }
        }
        public string lbSettingsDownloadsRetryAttempts {
            get { return lbSettingsDownloadsRetryAttemptsString; }
            private set { lbSettingsDownloadsRetryAttemptsString = value; }
        }
        public string chkSettingsDownloadsForceIpv4 {
            get { return chkSettingsDownloadsForceIpv4String; }
            private set { chkSettingsDownloadsForceIpv4String = value; }
        }
        public string chkSettingsDownloadsForceIpv6 {
            get { return chkSettingsDownloadsForceIpv6String; }
            private set { chkSettingsDownloadsForceIpv6String = value; }
        }
        public string chkSettingsDownloadsUseProxy {
            get { return chkSettingsDownloadsUseProxyString; }
            private set { chkSettingsDownloadsUseProxyString = value; }
        }
        public string chkSettingsDownloadsUseYoutubeDlsUpdater {
            get { return chksettingsDownloadsUseYoutubeDlsUpdaterString; }
            private set { chksettingsDownloadsUseYoutubeDlsUpdaterString = value; }
        }
        public string lbSettingsDownloadsUpdatingYtdlType {
            get { return lbSettingsDownloadsUpdatingYtdlTypeString; }
            private set { lbSettingsDownloadsUpdatingYtdlTypeString = value; }
        }
        public string cbSettingsDownloadsUpdatingYtdlTypeHint {
            get { return cbSettingsDownloadsUpdatingYtdlTypeHintString; }
            private set { cbSettingsDownloadsUpdatingYtdlTypeHintString = value; }
        }
        public string llbSettingsDownloadsYtdlTypeViewRepo {
            get { return llbSettingsDownloadsYtdlTypeViewRepoString; }
            private set { llbSettingsDownloadsYtdlTypeViewRepoString = value; }
        }
        public string llbSettingsDownloadsYtdlTypeViewRepoHint {
            get { return llbSettingsDownloadsYtdlTypeViewRepoHintString; }
            private set { llbSettingsDownloadsYtdlTypeViewRepoHintString = value; }
        }
        public string chkSettingsDownloadsSeparateBatchDownloads {
            get { return chkSettingsDownloadsSeparateBatchDownloadsString; }
            private set { chkSettingsDownloadsSeparateBatchDownloadsString = value; }
        }
        public string chkSettingsDownloadsAddDateToBatchDownloadFolders {
            get { return chkSettingsDownloadsAddDateToBatchDownloadFoldersString; }
            private set { chkSettingsDownloadsAddDateToBatchDownloadFoldersString = value; }
        }

        public string chkSettingsConverterClearOutputAfterConverting {
            get { return chkSettingsConverterClearOutputAfterConvertingString; }
            private set { chkSettingsConverterClearOutputAfterConvertingString = value; }
        }
        public string chkSettingsConverterDetectOutputFileType {
            get { return chkSettingsConverterDetectOutputFileTypeString; }
            private set { chkSettingsConverterDetectOutputFileTypeString = value; }
        }
        public string chkSettingsConverterClearInputAfterConverting {
            get { return chkSettingsConverterClearInputAfterConvertingString; }
            private set { chkSettingsConverterClearInputAfterConvertingString = value; }
        }
        public string chkSettingsConverterHideFFmpegCompileInfo {
            get { return chkSettingsConverterHideFFmpegCompileInfoString; }
            private set { chkSettingsConverterHideFFmpegCompileInfoString = value; }
        }
        public string tcSettingsConverterVideo {
            get { return tcSettingsConverterVideoString; }
            private set { tcSettingsConverterVideoString = value; }
        }
        public string tcSettingsConverterAudio {
            get { return tcSettingsConverterAudioString; }
            private set { tcSettingsConverterAudioString = value; }
        }
        public string tcSettingsConverterCustom {
            get { return tcSettingsConverterCustomString; }
            private set { tcSettingsConverterCustomString = value; }
        }
        public string lbSettingsConverterVideoBitrate {
            get { return lbSettingsConverterVideoBitrateString; }
            private set { lbSettingsConverterVideoBitrateString = value; }
        }
        public string lbSettingsConverterVideoPreset {
            get { return lbSettingsConverterVideoPresetString; }
            private set { lbSettingsConverterVideoPresetString = value; }
        }
        public string lbSettingsConverterVideoProfile {
            get { return lbSettingsConverterVideoProfileString; }
            private set { lbSettingsConverterVideoProfileString = value; }
        }
        public string lbSettingsConverterVideoCRF {
            get { return lbSettingsConverterVideoCRFString; }
            private set { lbSettingsConverterVideoCRFString = value; }
        }
        public string chkSettingsConverterVideoFastStart {
            get { return chkSettingsConverterVideoFastStartString; }
            private set { chkSettingsConverterVideoFastStartString = value; }
        }
        public string lbSettingsConverterAudioBitrate {
            get { return lbSettingsConverterAudioBitrateString; }
            private set { lbSettingsConverterAudioBitrateString = value; }
        }
        public string lbSettingsConverterCustomHeader {
            get { return lbSettingsConverterCustomHeaderString; }
            private set { lbSettingsConverterCustomHeaderString = value; }
        }

        public string lbSettingsExtensionsHeader {
            get { return lbSettingsExtensionsHeaderString; }
            private set { lbSettingsExtensionsHeaderString = value; }
        }
        public string lbSettingsExtensionsExtensionFullName {
            get { return lbSettingsExtensionsExtensionFullNameString; }
            private set { lbSettingsExtensionsExtensionFullNameString = value; }
        }
        public string txtSettingsExtensionsExtensionFullName {
            get { return txtSettingsExtensionsExtensionFullNameString; }
            private set { txtSettingsExtensionsExtensionFullNameString = value; }
        }
        public string lbSettingsExtensionsExtensionShort {
            get { return lbSettingsExtensionsExtensionShortString; }
            private set { lbSettingsExtensionsExtensionShortString = value; }
        }
        public string txtSettingsExtensionsExtensionShort {
            get { return txtSettingsExtensionsExtensionShortString; }
            private set { txtSettingsExtensionsExtensionShortString = value; }
        }
        public string btnSettingsExtensionsAdd {
            get { return btnSettingsExtensionsAddString; }
            private set { btnSettingsExtensionsAddString = value; }
        }
        public string lbSettingsExtensionsFileName {
            get { return lbSettingsExtensionsFileNameString; }
            private set { lbSettingsExtensionsFileNameString = value; }
        }
        public string btnSettingsExtensionsRemoveSelected {
            get { return btnSettingsExtensionsRemoveSelectedString; }
            private set { btnSettingsExtensionsRemoveSelectedString = value; }
        }

        public string chkSettingsErrorsShowDetailedErrors {
            get { return chkSettingsErrorsShowDetailedErrorsString; }
            private set { chkSettingsErrorsShowDetailedErrorsString = value; }
        }
        public string chkSettingsErrorsSaveErrorsAsErrorLog {
            get { return chkSettingsErrorsSaveErrorsAsErrorLogString; }
            private set { chkSettingsErrorsSaveErrorsAsErrorLogString = value; }
        }
        public string chkSettingsErrorsSuppressErrors {
            get { return chkSettingsErrorsSuppressErrorsString; }
            private set { chkSettingsErrorsSuppressErrorsString = value; }
        }

        public string lbSettingsPortableInformation {
            get { return lbSettingsPortableInformationString; }
            private set { lbSettingsPortableInformationString = value; }
        }
        public string chkSettingsPortableToggleIni {
            get { return chkSettingsPortableToggleIniString; }
            private set { chkSettingsPortableToggleIniString = value; }
        }
        #endregion

        #region tipSettings
        public string btnSettingsRedownloadYoutubeDlHint {
            get { return btnSettingsRedownloadYoutubeDlHintString; }
            private set { btnSettingsRedownloadYoutubeDlHintString = value; }
        }
        public string btnSettingsCancelHint {
            get { return btnSettingsCancelHintString; }
            private set { btnSettingsCancelHintString = value; }
        }
        public string btnSettingsSaveHint {
            get { return btnSettingsSaveHintString; }
            private set { btnSettingsSaveHintString = value; }
        }

        public string lbSettingsGeneralYoutubeDlPathHint {
            get { return lbSettingsGeneralYoutubeDlPathHintString; }
            private set { lbSettingsGeneralYoutubeDlPathHintString = value; }
        }
        public string chkSettingsGeneralUseStaticYoutubeDlHint {
            get { return chkSettingsGeneralUseStaticYoutubeDlHintString; }
            private set { chkSettingsGeneralUseStaticYoutubeDlHintString = value; }
        }
        public string txtSettingsGeneralYoutubeDlPathHint {
            get { return txtSettingsGeneralYoutubeDlPathHintString; }
            private set { txtSettingsGeneralYoutubeDlPathHintString = value; }
        }
        public string btnSettingsGeneralBrowseYoutubeDlHint {
            get { return btnSettingsGeneralBrowseYoutubeDlHintString; }
            private set { btnSettingsGeneralBrowseYoutubeDlHintString = value; }
        }
        public string lbSettingsGeneralFFmpegDirectoryHint {
            get { return lbSettingsGeneralFFmpegDirectoryHintString; }
            private set { lbSettingsGeneralFFmpegDirectoryHintString = value; }
        }
        public string chkSettingsGeneralUseStaticFFmpegHint {
            get { return chkSettingsGeneralUseStaticFFmpegHintString; }
            private set { chkSettingsGeneralUseStaticFFmpegHintString = value; }
        }
        public string txtSettingsGeneralFFmpegPathHint {
            get { return txtSettingsGeneralFFmpegPathHintString; }
            private set { txtSettingsGeneralFFmpegPathHintString = value; }
        }
        public string btnSettingsGeneralBrowseFFmpegHint {
            get { return btnSettingsGeneralBrowseFFmpegHintString; }
            private set { btnSettingsGeneralBrowseFFmpegHintString = value; }
        }
        public string chkSettingsGeneralCheckForUpdatesOnLaunchHint {
            get { return chkSettingsGeneralCheckForUpdatesOnLaunchHintString; }
            private set { chkSettingsGeneralCheckForUpdatesOnLaunchHintString = value; }
        }
        public string chkSettingsGeneralCheckForBetaUpdatesHint {
            get { return chkSettingsGeneralCheckForBetaUpdatesHintString; }
            private set { chkSettingsGeneralCheckForBetaUpdatesHintString = value; }
        }
        public string chkSettingsGeneralHoverOverUrlToPasteClipboardHint {
            get { return chkSettingsGeneralHoverOverUrlToPasteClipboardHintString; }
            private set { chkSettingsGeneralHoverOverUrlToPasteClipboardHintString = value; }
        }
        public string chkSettingsGeneralClearUrlOnDownloadHint {
            get { return chkSettingsGeneralClearUrlOnDownloadHintString; }
            private set { chkSettingsGeneralClearUrlOnDownloadHintString = value; }
        }
        public string chkSettingsGeneralClearClipboardOnDownloadHint {
            get { return chkSettingsGeneralClearClipboardOnDownloadHintString; }
            private set { chkSettingsGeneralClearClipboardOnDownloadHintString = value; }
        }
        public string gbSettingsGeneralCustomArgumentsHint {
            get { return gbSettingsGeneralCustomArgumentsHintString; }
            private set { gbSettingsGeneralCustomArgumentsHintString = value; }
        }
        public string rbSettingsGeneralCustomArgumentsDontSaveHint {
            get { return rbSettingsGeneralCustomArgumentsDontSaveHintString; }
            private set { rbSettingsGeneralCustomArgumentsDontSaveHintString = value; }
        }
        public string rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint {
            get { return rbSettingsGeneralCustomArgumentsSaveAsArgsTextHintString; }
            private set { rbSettingsGeneralCustomArgumentsSaveAsArgsTextHintString = value; }
        }
        public string rbSettingsGeneralCustomArgumentsSaveInSettingsHint {
            get { return rbSettingsGeneralCustomArgumentsSaveInSettingsHintString; }
            private set { rbSettingsGeneralCustomArgumentsSaveInSettingsHintString = value; }
        }

        public string lbSettingsDownloadsDownloadPathHint {
            get { return lbSettingsDownloadsDownloadPathHintString; }
            private set { lbSettingsDownloadsDownloadPathHintString = value; }
        }
        public string chkSettingsDownloadsDownloadPathUseRelativePathHint {
            get { return chkSettingsDownloadsDownloadPathUseRelativePathHintString; }
            private set { chkSettingsDownloadsDownloadPathUseRelativePathHintString = value; }
        }
        public string txtSettingsDownloadsSavePathHint {
            get { return txtSettingsDownloadsSavePathHintString; }
            private set { txtSettingsDownloadsSavePathHintString = value; }
        }
        public string btnSettingsDownloadsBrowseSavePathHint {
            get { return btnSettingsDownloadsBrowseSavePathHintString; }
            private set { btnSettingsDownloadsBrowseSavePathHintString = value; }
        }
        public string llSettingsDownloadsSchemaHelpHint {
            get { return llSettingsDownloadsSchemaHelpHintString; }
            private set { llSettingsDownloadsSchemaHelpHintString = value; }
        }
        public string lbSettingsDownloadsFileNameSchemaHint {
            get { return lbSettingsDownloadsFileNameSchemaHintString; }
            private set { lbSettingsDownloadsFileNameSchemaHintString = value; }
        }
        public string txtSettingsDownloadsFileNameSchemaHint {
            get { return txtSettingsDownloadsFileNameSchemaHintString; }
            private set { txtSettingsDownloadsFileNameSchemaHintString = value; }
        }
        public string chkSettingsDownloadsSaveFormatQualityHint {
            get { return chkSettingsDownloadsSaveFormatQualityHintString; }
            private set { chkSettingsDownloadsSaveFormatQualityHintString = value; }
        }
        public string chkSettingsDownloadsDownloadSubtitlesHint {
            get { return chkSettingsDownloadsDownloadSubtitlesHintString; }
            private set { chkSettingsDownloadsDownloadSubtitlesHintString = value; }
        }
        public string chkSettingsDownloadsEmbedSubtitlesHint {
            get { return chkSettingsDownloadsEmbedSubtitlesHintString; }
            private set { chkSettingsDownloadsEmbedSubtitlesHintString = value; }
        }
        public string chkSettingsDownloadsSaveVideoInfoHint {
            get { return chkSettingsDownloadsSaveVideoInfoHintString; }
            private set { chkSettingsDownloadsSaveVideoInfoHintString = value; }
        }
        public string chkSettingsDownloadsWriteMetadataToFileHint {
            get { return chkSettingsDownloadsWriteMetadataToFileHintString; }
            private set { chkSettingsDownloadsWriteMetadataToFileHintString = value; }
        }
        public string chkSettingsDownloadsSaveDescriptionHint {
            get { return chkSettingsDownloadsSaveDescriptionHintString; }
            private set { chkSettingsDownloadsSaveDescriptionHintString = value; }
        }
        public string chkSettingsDownloadsKeepOriginalFilesHint {
            get { return chkSettingsDownloadsKeepOriginalFilesHintString; }
            private set { chkSettingsDownloadsKeepOriginalFilesHintString = value; }
        }
        public string chkSettingsDownloadsSaveAnnotationsHint {
            get { return chkSettingsDownloadsSaveAnnotationsHintString; }
            private set { chkSettingsDownloadsSaveAnnotationsHintString = value; }
        }
        public string chkSettingsDownloadsSaveThumbnailsHint {
            get { return chkSettingsDownloadsSaveThumbnailsHintString; }
            private set { chkSettingsDownloadsSaveThumbnailsHintString = value; }
        }
        public string chkSettingsDownloadsEmbedThumbnailsHint {
            get { return chkSettingsDownloadsEmbedThumbnailsHintString; }
            private set { chkSettingsDownloadsEmbedThumbnailsHintString = value; }
        }
        public string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint {
            get { return chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHintString; }
            private set { chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHintString = value; }
        }
        public string chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint {
            get { return chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHintString; }
            private set { chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHintString = value; }
        }
        public string chkSettingsDownloadsSeparateIntoWebsiteUrlHint {
            get { return chkSettingsDownloadsSeparateIntoWebsiteUrlHintString; }
            private set { chkSettingsDownloadsSeparateIntoWebsiteUrlHintString = value; }
        }
        public string chkSettingsDownloadsFixVReddItHint {
            get { return chkSettingsDownloadsFixVReddItHintString; }
            private set { chkSettingsDownloadsFixVReddItHintString = value; }
        }
        public string chkSettingsDownloadsPreferFFmpegHint {
            get { return chkSettingsDownloadsPreferFFmpegHintString; }
            private set { chkSettingsDownloadsPreferFFmpegHintString = value; }
        }
        public string chkSettingsDownloadsLimitDownloadHint {
            get { return chkSettingsDownloadsLimitDownloadHintString; }
            private set { chkSettingsDownloadsLimitDownloadHintString = value; }
        }
        public string numSettingsDownloadsLimitDownloadHint {
            get { return numSettingsDownloadsLimitDownloadHintString; }
            private set { numSettingsDownloadsLimitDownloadHintString = value; }
        }
        public string cbSettingsDownloadsLimitDownloadHint {
            get { return cbSettingsDownloadsLimitDownloadHintString; }
            private set { cbSettingsDownloadsLimitDownloadHintString = value; }
        }
        public string lbSettingsDownloadsRetryAttemptsHint {
            get { return lbSettingsDownloadsRetryAttemptsHintString; }
            private set { lbSettingsDownloadsRetryAttemptsHintString = value; }
        }
        public string numSettingsDownloadsRetryAttemptsHint {
            get { return numSettingsDownloadsRetryAttemptsHintString; }
            private set { numSettingsDownloadsRetryAttemptsHintString = value; }
        }
        public string chkSettingsDownloadsForceIpv4Hint {
            get { return chkSettingsDownloadsForceIpv4HintString; }
            private set { chkSettingsDownloadsForceIpv4HintString = value; }
        }
        public string chkSettingsDownloadsForceIpv6Hint {
            get { return chkSettingsDownloadsForceIpv6HintString; }
            private set { chkSettingsDownloadsForceIpv6HintString = value; }
        }
        public string chkSettingsDownloadsUseProxyHint {
            get { return chkSettingsDownloadsUseProxyHintString; }
            private set { chkSettingsDownloadsUseProxyHintString = value; }
        }
        public string cbSettingsDownloadsProxyTypeHint {
            get { return cbSettingsDownloadsProxyTypeHintString; }
            private set { cbSettingsDownloadsProxyTypeHintString = value; }
        }
        public string txtSettingsDownloadsProxyIpHint {
            get { return txtSettingsDownloadsProxyIpHintString; }
            private set { txtSettingsDownloadsProxyIpHintString = value; }
        }
        public string txtSettingsDownloadsProxyPortHint {
            get { return txtSettingsDownloadsProxyPortHintString; }
            private set { txtSettingsDownloadsProxyPortHintString = value; }
        }
        public string chksettingsDownloadsUseYoutubeDlsUpdaterHint {
            get { return chksettingsDownloadsUseYoutubeDlsUpdaterHintString; }
            private set { chksettingsDownloadsUseYoutubeDlsUpdaterHintString = value; }
        }
        public string chkSettingsDownloadsSeparateBatchDownloadsHint {
            get { return chkSettingsDownloadsSeparateBatchDownloadsHintString; }
            private set { chkSettingsDownloadsSeparateBatchDownloadsHintString = value; }
        }
        public string chkSettingsDownloadsAddDateToBatchDownloadFoldersHint {
            get { return chkSettingsDownloadsAddDateToBatchDownloadFoldersHintString; }
            private set { chkSettingsDownloadsAddDateToBatchDownloadFoldersHintString = value; }
        }

        public string chkSettingsConverterClearOutputAfterConvertingHint {
            get { return chkSettingsConverterClearOutputAfterConvertingHintString; }
            private set { chkSettingsConverterClearOutputAfterConvertingHintString = value; }
        }
        public string chkSettingsConverterDetectOutputFileTypeHint {
            get { return chkSettingsConverterDetectOutputFileTypeHintString; }
            private set { chkSettingsConverterDetectOutputFileTypeHintString = value; }
        }
        public string chkSettingsConverterClearInputAfterConvertingHint {
            get { return chkSettingsConverterClearInputAfterConvertingHintString; }
            private set { chkSettingsConverterClearInputAfterConvertingHintString = value; }
        }
        public string chkSettingsConverterHideFFmpegCompileInfoHint {
            get { return chkSettingsConverterHideFFmpegCompileInfoHintString; }
            private set { chkSettingsConverterHideFFmpegCompileInfoHintString = value; }
        }
        public string lbSettingsConverterVideoBitrateHint {
            get { return lbSettingsConverterVideoBitrateHintString; }
            private set { lbSettingsConverterVideoBitrateHintString = value; }
        }
        public string lbSettingsConverterVideoPresetHint {
            get { return lbSettingsConverterVideoPresetHintString; }
            private set { lbSettingsConverterVideoPresetHintString = value; }
        }
        public string lbSettingsConverterVideoProfileHint {
            get { return lbSettingsConverterVideoProfileHintString; }
            private set { lbSettingsConverterVideoProfileHintString = value; }
        }
        public string lbSettingsConverterVideoCRFHint {
            get { return lbSettingsConverterVideoCRFHintString; }
            private set { lbSettingsConverterVideoCRFHintString = value; }
        }
        public string chkSettingsConverterVideoFastStartHint {
            get { return chkSettingsConverterVideoFastStartHintString; }
            private set { chkSettingsConverterVideoFastStartHintString = value; }
        }
        public string lbSettingsConverterAudioBitrateHint {
            get { return lbSettingsConverterAudioBitrateHintString; }
            private set { lbSettingsConverterAudioBitrateHintString = value; }
        }
        public string txtSettingsConverterCustomArgumentsHint {
            get { return txtSettingsConverterCustomArgumentsHintString; }
            private set { txtSettingsConverterCustomArgumentsHintString = value; }
        }

        public string chkSettingsErrorsShowDetailedErrorsHint {
            get { return chkSettingsErrorsShowDetailedErrorsHintString; }
            private set { chkSettingsErrorsShowDetailedErrorsHintString = value; }
        }
        public string chkSettingsErrorsSaveErrorsAsErrorLogHint {
            get { return chkSettingsErrorsSaveErrorsAsErrorLogHintString; }
            private set { chkSettingsErrorsSaveErrorsAsErrorLogHintString = value; }
        }
        public string chkSettingsErrorsSuppressErrorsHint {
            get { return chkSettingsErrorsSuppressErrorsHintString; }
            private set { chkSettingsErrorsSuppressErrorsHintString = value; }
        }
        #endregion

        #endregion

        #region frmSubtitles
        public string frmSubtitles {
            get { return frmSubtitlesString; }
            private set { frmSubtitlesString = value; }
        }
        public string lbSubtitlesHeader {
            get { return lbSubtitlesHeaderString; }
            private set { lbSubtitlesHeaderString = value; }
        }
        public string lbSubtitlesUrl {
            get { return lbSubtitlesUrlString; }
            private set { lbSubtitlesUrlString = value; }
        }
        public string lbSubtitlesLanguages {
            get { return lbSubtitlesLanguagesString; }
            private set { lbSubtitlesLanguagesString = value; }
        }
        public string btnSubtitlesAddLanguage {
            get { return btnSubtitlesAddLanguageString; }
            private set { btnSubtitlesAddLanguageString = value; }
        }
        public string btnSubtitlesClearLanguages {
            get { return btnSubtitlesClearLanguagesString; }
            private set { btnSubtitlesClearLanguagesString = value; }
        }
        public string btnSubtitlesDownload {
            get { return btnSubtitlesDownloadString; }
            private set { btnSubtitlesDownloadString = value; }
        }
        #endregion

        #region frmTools
        public string frmTools {
            get { return frmToolsString; }
            private set { frmToolsString = value; }
        }
        public string btnMiscToolsRemoveAudio {
            get { return btnMiscToolsRemoveAudioString; }
            private set { btnMiscToolsRemoveAudioString = value; }
        }
        public string btnMiscToolsExtractAudio {
            get { return btnMiscToolsExtractAudioString; }
            private set { btnMiscToolsExtractAudioString = value; }
        }
        public string btnMiscToolsVideoToGif {
            get { return btnMiscToolsVideoToGifString; }
            private set { btnMiscToolsVideoToGifString = value; }
        }
        #endregion

        #region frmUpdateAvailable
        public string frmUpdateAvailable {
            get { return frmUpdateAvailableString; }
            private set { frmUpdateAvailableString = value; }
        }
        public string lbUpdateAvailableHeader {
            get { return lbUpdateAvailableHeaderString; }
            private set { lbUpdateAvailableHeaderString = value; }
        }
        public string lbUpdateAvailableUpdateVersion {
            get { return lbUpdateAvailableUpdateVersionString; }
            private set { lbUpdateAvailableUpdateVersionString = value; }
        }
        public string lbUpdateAvailableCurrentVersion {
            get { return lbUpdateAvailableCurrentVersionString; }
            private set { lbUpdateAvailableCurrentVersionString = value; }
        }
        public string lbUpdateAvailableChangelog {
            get { return lbUpdateAvailableChangelogString; }
            private set { lbUpdateAvailableChangelogString = value; }
        }
        public string btnUpdateAvailableSkipVersion {
            get { return btnUpdateAvailableSkipVersionString; }
            private set { btnUpdateAvailableSkipVersionString = value; }
        }
        public string btnUpdateAvailableUpdate {
            get { return btnUpdateAvailableUpdateString; }
            private set { btnUpdateAvailableUpdateString = value; }
        }
        public string btnUpdateAvailableOk {
            get { return btnUpdateAvailableOkString; }
            private set { btnUpdateAvailableOkString = value; }
        }
        #endregion

        //////////////// Language class \\\\\\\\\\\\\\\\
        #region Instance manager
        public string LoadedFile {
            get { return LoadedFileString; }
            private set { LoadedFileString = value; }
        }
        #endregion

        #endregion

        #region Internal English
        /// <summary>
        /// Contains all English strings internally.
        /// </summary>
        public static class InternalEnglish {
            // Language identifier
            public static readonly string CurrentLanguageLong = "English (Internal)";
            public static readonly string CurrentLanguageShort = "en-i";
            public static readonly string CurrentLanguageHint = "Click here to change";
            public static readonly string CurrentLanguageVersion = "1";

            // Generics
            public static readonly string GenericInputBest = "best";
            public static readonly string GenericCancel = "Cancel";
            public static readonly string GenericSkip = "Skip";
            public static readonly string GenericSound = "Sound";
            public static readonly string GenericVideo = "Video";
            public static readonly string GenericAudio = "Audio";
            public static readonly string GenericCustom = "Custom";
            public static readonly string GenericRetry = "Retry";

            #region frmAbout
            public static readonly string frmAbout = "About";
            public static readonly string lbAboutBody = "youtube-dl by {0}\nyoutube-dl-gui by {1}\ndebug date {2}";
            public static readonly string llbCheckForUpdates = "Check for updates";
            #endregion

            #region frmAuthentication
            public static readonly string frmAuthentication = "Authentication";

            public static readonly string lbAuthNotice = "Enter your authentication information:";

            public static readonly string lbAuthUsername = "Username";
            public static readonly string lbAuthPassword = "Password";
            public static readonly string lbAuth2Factor = "2-Factor";
            public static readonly string lbAuthVideoPassword = "Video password";
            public static readonly string chkAuthUseNetrc = "Use .netrc for authentication";

            public static readonly string lbAuthNoSave = "Your information will not be saved for security reasons.";

            public static readonly string btnAuthBeginDownload = "Begin download";
            #endregion

            #region frmBatchDownloader
            // frmBatch
            public static readonly string frmBatchDownload = "Batch downloader";
            public static readonly string lbBatchDownloadLink = "Download link";
            public static readonly string lbBatchDownloadType = "Download type";
            public static readonly string lbBatchDownloadVideoSpecificArgument = "Video-specific argument";
            public static readonly string btnBatchDownloadAdd = "Add";
            public static readonly string sbBatchDownloadLoadArgs = "Load args";
            public static readonly string mBatchDownloaderLoadArgsFromSettings = "Load args from settings";
            public static readonly string mBatchDownloaderLoadArgsFromArgsTxt = "Load args from ./args.txt";
            public static readonly string mBatchDownloaderLoadArgsFromFile = "Load args from file...";
            public static readonly string btnBatchDownloadRemoveSelected = "Remove selected";
            public static readonly string btnBatchDownloadStart = "Start";
            public static readonly string btnBatchDownloadStop = "Stop";
            public static readonly string btnBatchDownloadExit = "Exit";
            public static readonly string sbBatchDownloaderIdle = "Waiting for batch download start";
            public static readonly string sbBatchDownloaderDownloading = "Batch download in progress...";
            public static readonly string sbBatchDownloaderFinished = "Batch download finished. Add more items to start another batch, or exit";
            public static readonly string sbBatchDownloaderAborted = "The batch process has been aborted";
            #endregion

            #region frmDownloader
            public static readonly string frmDownloader = "Downloading";
            public static readonly string frmDownloaderComplete = "Download finished";
            public static readonly string frmDownloaderError = "Error downloading";
            public static readonly string chkDownloaderCloseAfterDownload = "Close after download";
            public static readonly string btnDownloaderAbortBatch = "Abort batch download";
            public static readonly string btnDownloaderExit = "Exit";
            #endregion

            #region frmException
            // frmException
            public static readonly string frmException = "An exception occured";
            public static readonly string lbExceptionHeader = "An exception has occured";
            public static readonly string lbExceptionDescription = "Below is the error that occured. Feel free to open a new issue and report it.";
            public static readonly string rtbExceptionDetails = "Feel free to copy + paste this entire text wall into a new issue on Github";
            public static readonly string btnExceptionGithub = "Open Github";
            public static readonly string btnExceptionOk = "OK";
            #endregion

            #region frmLanguage
            public static readonly string frmLanguage = "Language select";
            public static readonly string btnLanguageRefresh = "Refresh";
            public static readonly string btnLanguageCancel = "Cancel";
            public static readonly string btnLanguageSave = "Save";
            #endregion

            #region frmMain
            // frmMain
            public static readonly string frmMain = "youtube-dl-gui";
            // frmMain / menu
            public static readonly string mSettings = "Settings";
            public static readonly string mTools = "Tools";
            public static readonly string mBatchDownload = "Batch download";
            public static readonly string mDownloadSubtitles = "Download subtitles";
            public static readonly string mMiscTools = "Misc tools";
            public static readonly string mHelp = "Help";
            public static readonly string mLanguage = "Language";
            public static readonly string mSupportedSites = "Supported sites";
            public static readonly string mAbout = "About";
            // frmMain / tcMain
            public static readonly string tabDownload = "Download";
            public static readonly string tabConvert = "Convert";
            public static readonly string tabMerge = "Merge";
            // frmMain / tcMain / Download
            public static readonly string lbURL = "URL";
            public static readonly string txtUrlHint = "Video URL";
            public static readonly string gbDownloadType = "Download type";
            public static readonly string rbVideo = "Video";
            public static readonly string rbAudio = "Audio";
            public static readonly string rbCustom = "Custom";
            public static readonly string lbQuality = "Quality";
            public static readonly string lbFormat = "Format";
            public static readonly string chkDownloadSound = "Sound";
            public static readonly string chkUseSelection = "Video Selection";
            public static readonly string rbVideoSelectionPlaylistIndex = "Playlist index";
            public static readonly string rbVideoSelectionPlaylistItems = "Playlist items";
            public static readonly string rbVideoSelectionBeforeDate = "Before date";
            public static readonly string rbVideoSelectionOnDate = "On date";
            public static readonly string rbVideoSelectionAfterDate = "After date";
            public static readonly string txtPlaylistStartHint = "Start index";
            public static readonly string txtPlaylistEndHint = "End index";
            public static readonly string txtPlaylistItemsHint = "Video indexes (separated by commas)";
            public static readonly string txtVideoDateHint = "Date (YYYYMMDD)";
            public static readonly string lbCustomArguments = "Custom arguments";
            public static readonly string txtArgsHint = "Custom youtube-dl arguments";
            public static readonly string sbDownload = "Download";
            public static readonly string mDownloadWithAuthentication = "Download with authentication...";
            public static readonly string msgBatchDownloadFromFile = "Create a text file and put all the video links you want to download into it, separated as one per line.\nDo you want to skip seeing this message when batch downloading using this option?";
            public static readonly string mBatchDownloadFromFile = "Batch download from file...";
            public static readonly string lbDownloadStatusStarted = "Download started";
            public static readonly string lbDownloadStatusError = "Error downloading";
            // frmMain / tcMain / Convert
            public static readonly string lbConvertInput = "Input";
            public static readonly string lbConvertOutput = "Output";
            public static readonly string rbConvertVideo = "Video";
            public static readonly string rbConvertAudio = "Audio";
            public static readonly string rbConvertCustom = "Custom";
            public static readonly string rbConvertAuto = "Automatic";
            public static readonly string rbConvertAutoFFmpeg = "Auto ffmpeg";
            public static readonly string btnConvert = "Convert";
            public static readonly string lbConvertStarted = "Conversion started";
            public static readonly string lbConvertFailed = "Conversion failed";
            // frmMain / tcMain / Merge
            public static readonly string lbMergeInput1 = "Input 1";
            public static readonly string lbMergeInput2 = "Input 2";
            public static readonly string lbMergeOutput = "Output";
            public static readonly string chkMergeAudioTracks = "Merge audio tracks";
            public static readonly string chkMergeDeleteInputFiles = "Delete input files";
            public static readonly string btnMerge = "Merge";
            // frmMain / tcMain / cmTray
            public static readonly string cmTrayShowForm = "Show form";
            public static readonly string cmTrayDownloader = "Downloader...";
            public static readonly string cmTrayDownloadClipboard = "From clipboard...";
            public static readonly string cmTrayDownloadBestVideo = "Download best video";
            public static readonly string cmTrayDownloadBestAudio = "Download best audio";
            public static readonly string cmTrayDownloadCustom = "Download custom...";
            public static readonly string cmTrayDownloadCustomTxtBox = "From form textbox";
            public static readonly string cmTrayDownloadCustomTxt = "From ./args.txt";
            public static readonly string cmTrayDownloadCustomSettings = "From settings";
            public static readonly string cmTrayConverter = "Converter...";
            public static readonly string cmTrayConvertTo = "Conver to...";
            public static readonly string cmTrayConvertVideo = "Video";
            public static readonly string cmTrayConvertAudio = "Audio";
            public static readonly string cmTrayConvertCustom = "Custom";
            public static readonly string cmTrayConvertAutomatic = "Automatic";
            public static readonly string cmTrayConvertAutoFFmpeg = "Auto ffmpeg";
            public static readonly string cmTrayExit = "Exit";
            #endregion

            #region frmSettings

            // frmSettings
            public static readonly string frmSettings = "youtube-dl-gui settings";
            public static readonly string btnSettingsRedownloadYoutubeDl = "(re)download youtube-dl";
            public static readonly string btnSettingsSave = "Save";
            public static readonly string btnSettingsRedownloadYoutubeDlHint = "Redownloads youtube-dl if one is already present, otherwise, updates youtube-dl";
            public static readonly string btnSettingsCancelHint = "Discard any changed settings";
            public static readonly string btnSettingsSaveHint = "Save all configured settings";
            // frmSettings / tcMain
            public static readonly string tabSettingsGeneral = "General";
            public static readonly string tabSettingsDownloads = "Downloads";
            public static readonly string tabSettingsConverter = "Converter";
            public static readonly string tabSettingsExtensions = "Extensions";
            public static readonly string tabSettingsErrors = "Errors";
            public static readonly string tabSettingsPortable = "Portable";
            #region tabGeneral
            //frmSettings / tcMain / tabGeneral
            public static readonly string lbSettingsGeneralYoutubeDlPath = "youtube-dl path";
            public static readonly string chkSettingsGeneralUseStaticYoutubeDl = "Use static youtube-dl";
            public static readonly string txtSettingsGeneralYoutubeDlPathHint = "The path of youtube-dl where it won't be moved";
            public static readonly string btnSettingsGeneralBrowseYoutubeDlHint = "Browse for a new folder where you'll store youtube-dl";
            public static readonly string ofdTitleYoutubeDl = "Select youtube-dl";
            public static readonly string ofdFilterYoutubeDl = "youtube-dl executable";
            public static readonly string lbSettingsGeneralFFmpegDirectory = "ffmpeg directory";
            public static readonly string chkSettingsGeneralUseStaticFFmpeg = "Use static ffmpeg";
            public static readonly string txtSettingsGeneralFFmpegPathHint = "The path of ffmpeg where it won't be moved";
            public static readonly string btnSettingsGeneralBrowseFFmpegHint = "Browse for a new folder where you'll store ffmpeg";
            public static readonly string ofdTitleFFmpeg = "Select ffmpeg.exe and ffprobe.exe";
            public static readonly string ofdFilterFFmpeg = "ffmpeg and ffprobe executable";

            public static readonly string chkSettingsGeneralCheckForUpdatesOnLaunch = "Check for updates on launch";
            public static readonly string chkSettingsGeneralCheckForBetaUpdates = "Check for beta updates";
            public static readonly string chkSettingsGeneralHoverOverUrlToPasteClipboard = "Hover over URL to paste clipboard";
            public static readonly string chkSettingsGeneralClearUrlOnDownload = "Clear URL on download";
            public static readonly string chkSettingsGeneralClearClipboardOnDownload = "Clear clipboard on download";
            public static readonly string gbSettingsGeneralCustomArguments = "Custom arguments (saves on download)";
            public static readonly string rbSettingsGeneralCustomArgumentsDontSave = "Don't save";
            public static readonly string rbSettingsGeneralCustomArgumentsSaveAsArgsText = "Save as ./args.txt";
            public static readonly string rbSettingsGeneralCustomArgumentsSaveInSettings = "Save in settings";

            public static readonly string lbSettingsGeneralYoutubeDlPathHint = "Static youtube-dl directory\n\n" +
                                                                               "Static youtube-dl means youtube-dl will always be located in that one directory.";
            public static readonly string chkSettingsGeneralUseStaticYoutubeDlHint = "Use a static placed youtube-dl.exe file";
            public static readonly string lbSettingsGeneralFFmpegDirectoryHint = "Static ffmpeg directory\n\n" +
                                                                                 "Static ffmpeg means ffmpeg will always be located in that one directory.";
            public static readonly string chkSettingsGeneralUseStaticFFmpegHint = "Use a static placed ffmpeg.exe and ffprobe.exe files";
            public static readonly string chkSettingsGeneralCheckForUpdatesOnLaunchHint = "Check for updates on launch of youtube-dl-gui";
            public static readonly string chkSettingsGeneralCheckForBetaUpdatesHint = "Checks for beta updates instead of regular updates";
            public static readonly string chkSettingsGeneralHoverOverUrlToPasteClipboardHint = "Hover over the URL textbox to paste the URL from the clipboard";
            public static readonly string chkSettingsGeneralClearUrlOnDownloadHint = "Clears the URL from the textbox on video download";
            public static readonly string chkSettingsGeneralClearClipboardOnDownloadHint = "Clears the clipboard on video download";
            public static readonly string gbSettingsGeneralCustomArgumentsHint = "Controls how custom arguments for youtube-dl will be saved";
            public static readonly string rbSettingsGeneralCustomArgumentsDontSaveHint = "Doesn't save any custom arguments";
            public static readonly string rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = "Saves custom arguments as args.txt in youtube-dl-gui's directory";
            public static readonly string rbSettingsGeneralCustomArgumentsSaveInSettingsHint = "Saves custom arguments in the application settings";
            #endregion
            #region tabDownloads
            // frmSettings / tcMain / tabDownloads
            public static readonly string lbSettingsDownloadsDownloadPath = "download path";
            public static readonly string chkSettingsDownloadsDownloadPathUseRelativePathHint = "Save to the program's relative path\r\n\r\nIf checked, the program will check the save path and use the current directory as the base path.\r\nSaving anywhere outside of the current directory will not set the flag and will set it to wherever you selected.";
            public static readonly string txtSettingsDownloadsSavePathHint = "where your downloads will be saved to";
            public static readonly string btnSettingsDownloadsBrowseSavePathHint = "browse for a new save folder";
            public static readonly string lbSettingsDownloadsFileNameSchema = "file name schema";

            public static readonly string tabDownloadsGeneral = "General";
            public static readonly string tabDownloadsSorting = "Sorting";
            public static readonly string tabdownloadsFixes = "Fixes";
            public static readonly string tabDownloadsConnection = "Connection";
            public static readonly string tabDownloadsUpdating = "Updating";

            public static readonly string chkSettingsDownloadsSaveFormatQuality = "Save quality, format, && args on download";
            public static readonly string chkSettingsDownloadsDownloadSubtitles = "Download subtitles";
            public static readonly string chkSettingsDownloadsEmbedSubtitles = "Embed subtitles into file";
            public static readonly string chkSettingsDownloadsSaveVideoInfo = "Save video info";
            public static readonly string chkSettingsDownloadsWriteMetadataToFile = "Write metadata to file";
            public static readonly string chkSettingsDownloadsSaveDescription = "Save description";
            public static readonly string chkSettingsDownloadsKeepOriginalFiles = "Keep original files";
            public static readonly string chkSettingsDownloadsSaveAnnotations = "Save annotations";
            public static readonly string chkSettingsDownloadsSaveThumbnails = "Save thumbnails";
            public static readonly string chkSettingsDownloadsEmbedThumbnails = "Embed thumbnail into file";
            public static readonly string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = "Automatically delete youtube-dl when closing";
            public static readonly string chkSettingsDownloadsSeparateDownloadsToDifferentFolders = "Separate downloads to different folders";
            public static readonly string chkSettingsDownloadsSeparateIntoWebsiteUrl = "Separate into website url";
            public static readonly string chkSettingsDownloadsFixVReddIt = "Fix v.redd.it";
            public static readonly string chkSettingsDownloadsPreferFFmpeg = "Prefer ffmpeg for downloads";
            public static readonly string chkSettingsDownloadsLimitDownload = "Limit download";
            public static readonly string lbSettingsDownloadsRetryAttempts = "Retry attempts";
            public static readonly string chkSettingsDownloadsForceIpv4 = "Force IPv4";
            public static readonly string chkSettingsDownloadsForceIpv6 = "Force IPv6";
            public static readonly string chkSettingsDownloadsUseProxy = "Use a proxy";
            public static readonly string chksettingsDownloadsUseYoutubeDlsUpdater = "Use youtube-dl's internal updater";
            public static readonly string lbSettingsDownloadsUpdatingYtdlType = "Youtube-DL fork";
            public static readonly string llbSettingsDownloadsYtdlTypeViewRepo = "View source repo";
            public static readonly string chkSettingsDownloadsSeparateBatchDownloads = "Separate Batch Downloads";
            public static readonly string chkSettingsDownloadsAddDateToBatchDownloadFolders = "Include Date onto Download Folders";

            public static readonly string lbSettingsDownloadsDownloadPathHint = "The path of the folder where files will be downloaded to";
            public static readonly string lbSettingsDownloadsFileNameSchemaHint = "The file name schema\n\n" +
                                                                                  "This basically replaces sequences with video information for a custom file name.";
            public static readonly string llSettingsDownloadsSchemaHelpHint = "Click here to view supported arguments";
            public static readonly string txtSettingsDownloadsFileNameSchemaHint = "The file name schema that will be used by youtube-dl";

            public static readonly string chkSettingsDownloadsSaveFormatQualityHint = "Saves the quality selection, format selection, and custom arguments on download on the main form";
            public static readonly string chkSettingsDownloadsDownloadSubtitlesHint = "Download all available subtitles for the video\nIf no subtitles are available, nothing will download";
            public static readonly string chkSettingsDownloadsEmbedSubtitlesHint = "Embeds downloaded subtitles into the output file\nOnly works for mp4, webm, and mkv videos";
            public static readonly string chkSettingsDownloadsSaveVideoInfoHint = "Saves the video's info into a .info.json file";
            public static readonly string chkSettingsDownloadsWriteMetadataToFileHint = "Writes the video's metadata to the output file";
            public static readonly string chkSettingsDownloadsSaveDescriptionHint = "Saves the video's description to a .description file";
            public static readonly string chkSettingsDownloadsKeepOriginalFilesHint = "Keeps the original files of the download\nBy default, youtube-dl will delete them after merging";
            public static readonly string chkSettingsDownloadsSaveAnnotationsHint = "Saves the video's annotations to a .annotations.xml file";
            public static readonly string chkSettingsDownloadsSaveThumbnailsHint = "Saves the video's thumbnail";
            public static readonly string chkSettingsDownloadsEmbedThumbnailsHint = "Embeds downloaded thumbnails into the output file as cover art\nRequires AtomicParsley (https://github.com/wez/atomicparsley), or youtube-dl will result in an error";
            public static readonly string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = "Automatically delete youtube-dl.exe when closing youtube-dl-gui";
            public static readonly string chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = "Separates downloads into their own folder based on the download type\n\n" + "Videos would be <download directory>\\Video\n" + "Audio would be <download directory>\\Audio\n" + "Custom would be <download directory>\\Custom";
            public static readonly string chkSettingsDownloadsSeparateIntoWebsiteUrlHint = "Downloaded files will be saved to the download path with the URL of the website appended at the end\n" + "Ex: C:\\Users\\YourName\\Videos\\youtube.com\\Video.mp4";
            public static readonly string chkSettingsDownloadsFixVReddItHint = "Fixes visual corruptions on v.redd.it/reddit.com links using ffmpeg's HTTP Live Streaming (HLS)\n\n" + "Recommended to stay on.\n" + "This requires FFMPEG to be installed and available, it will fallback to youtube-dl's default.";
            public static readonly string chkSettingsDownloadsPreferFFmpegHint = "Prefer's ffmpeg's hls over youtube-dl's own. This may fix some sites, and break others.";
            public static readonly string chkSettingsDownloadsLimitDownloadHint = "Limits the downloads to the specified speed";
            public static readonly string numSettingsDownloadsLimitDownloadHint = "The speed that the download will be throttled to\nSet the number to 0 to disable limiting";
            public static readonly string cbSettingsDownloadsLimitDownloadHint = "The *byte size limit";
            public static readonly string lbSettingsDownloadsRetryAttemptsHint = "Retry downloading the specified amount of times if it fails";
            public static readonly string numSettingsDownloadsRetryAttemptsHint = "The maximum amount of retries allowed";
            public static readonly string chkSettingsDownloadsForceIpv4Hint = "Force the connection to tunnel through IPv4";
            public static readonly string chkSettingsDownloadsForceIpv6Hint = "Force the connection to tunnel through IPv6";
            public static readonly string chkSettingsDownloadsUseProxyHint = "Download using a proxy";
            public static readonly string cbSettingsDownloadsProxyTypeHint = "The proxy protocol that will be used";
            public static readonly string txtSettingsDownloadsProxyIpHint = "The proxy IP that will be used";
            public static readonly string txtSettingsDownloadsProxyPortHint = "The proxy port that will be used";
            public static readonly string chksettingsDownloadsUseYoutubeDlsUpdaterHint = "Use youtube-dl's internal updater instead of this application's updater";
            public static readonly string cbSettingsDownloadsUpdatingYtdlTypeHint = "The youtube-dl repo that will be targetted";
            public static readonly string llbSettingsDownloadsYtdlTypeViewRepoHint = "Go to the repository page of the selected fork";
            public static readonly string chkSettingsDownloadsSeparateBatchDownloadsHint = "Batch downloads are separated into a new folder in the designated download path";
            public static readonly string chkSettingsDownloadsAddDateToBatchDownloadFoldersHint = "Batch downloads are further separated into a new folder that is the date and time the batch started";

            #endregion
            #region tabConverter
            // frmSettings / tcMain / tabConverter
            public static readonly string chkSettingsConverterClearOutputAfterConverting = "Clear output after converting";
            public static readonly string chkSettingsConverterDetectOutputFileType = "Detect output filetype";
            public static readonly string chkSettingsConverterClearInputAfterConverting = "Clear input after converting";
            public static readonly string chkSettingsConverterHideFFmpegCompileInfo = "Hide ffmpeg compile info";
            public static readonly string tcSettingsConverterVideo = "Video";
            public static readonly string tcSettingsConverterAudio = "Audio";
            public static readonly string tcSettingsConverterCustom = "Custom";
            public static readonly string lbSettingsConverterVideoBitrate = "Bitrate";
            public static readonly string lbSettingsConverterVideoPreset = "Preset";
            public static readonly string lbSettingsConverterVideoProfile = "Profile";
            public static readonly string lbSettingsConverterVideoCRF = "CRF";
            public static readonly string chkSettingsConverterVideoFastStart = "faststart";
            public static readonly string lbSettingsConverterAudioBitrate = "Bitrate";
            public static readonly string lbSettingsConverterCustomHeader = "Don't pass input or output directories/fies,\nit's automatically handled by the program";

            public static readonly string chkSettingsConverterClearOutputAfterConvertingHint = "Clears the output file after a successful conversion";
            public static readonly string chkSettingsConverterDetectOutputFileTypeHint = "If Automatic is checked on converting, this will attempt to detect the output file type.\n\n" + "Disable this if you want a simple conversion. The quality may suffer as a result.";
            public static readonly string chkSettingsConverterClearInputAfterConvertingHint = "Clears the input file after a successful conversion";
            public static readonly string chkSettingsConverterHideFFmpegCompileInfoHint = "Enabling this will hide some compilation information of ffmpeg.";
            public static readonly string lbSettingsConverterVideoBitrateHint = "The bitrate of the video\n" +
                                                                "A bitrate is how many bits per second are streamed to the player\n\n" +
                                                                "higher = better, at the cost of file size\n\n" +
                                                                "If you were to input \"10,000\" as the bitrate, it would be interpreted as \"10,000,000\" bits per second.";
            public static readonly string lbSettingsConverterVideoPresetHint = "The video preset of the conversion\n\n" +
                                                                                "ultrafast = fastest, but lower quality\n" +
                                                                                "veryslow = slowest, but higher quality";
            public static readonly string lbSettingsConverterVideoProfileHint = "The encoder profile to be used during conversion. It affects the compression of the video.\n" +
                                                                                "It's generally a good idea to stick with the main profile";
            public static readonly string lbSettingsConverterVideoCRFHint = "CRF is constant rate factor.\n\n" +
                                                                             "Lower = Higher quality";
            public static readonly string chkSettingsConverterVideoFastStartHint = "Faststart moves the metadata to the front of the file.\n\n" +
                                                                                   "Enabling this allows videos to be played before they are fully downloaded.";
            public static readonly string lbSettingsConverterAudioBitrateHint = "The bitrate of the audio\nA bitrate is how many bits are streamed to the player\n\nHigher = better, at the cost of size\n\nIf you were to put \"256\", it would be interpreted as \"256,000\" bits per second.";
            public static readonly string txtSettingsConverterCustomArgumentsHint = "Custom arguments that will be passed through ffmpeg instead of built-in arguments";
            #endregion
            #region tabExtensions
            // frmSettings / tcMain / tabExtensions
            public static readonly string lbSettingsExtensionsHeader = "This allows you to input your own extensions\nto be used with this application";
            public static readonly string lbSettingsExtensionsExtensionFullName = "Extension full name";
            public static readonly string txtSettingsExtensionsExtensionFullName = "Example extension";
            public static readonly string lbSettingsExtensionsExtensionShort = "Extension short";
            public static readonly string txtSettingsExtensionsExtensionShort = "ext";
            public static readonly string btnSettingsExtensionsAdd = "Add";
            public static readonly string lbSettingsExtensionsFileName = "FileName";
            public static readonly string btnSettingsExtensionsRemoveSelected = "Remove selected";
            #endregion
            #region tabErrors
            // frmSettings / tcMain / tabErrors
            public static readonly string chkSettingsErrorsShowDetailedErrors = "Show detailed errors";
            public static readonly string chkSettingsErrorsSaveErrorsAsErrorLog = "Save errors as ./error.log";
            public static readonly string chkSettingsErrorsSuppressErrors = "Suppress errors";
            public static readonly string chkSettingsErrorsShowDetailedErrorsHint = "Shows more details in errors";
            public static readonly string chkSettingsErrorsSaveErrorsAsErrorLogHint = "Saves the latest error as error.log in the exeucting directory of youtube-dl-gui";
            public static readonly string chkSettingsErrorsSuppressErrorsHint = "This will silence any errors and will not save any error.log files.\n\n" +
                                                                                "This basically overrides all error settings. Use at your own risk.";
            #endregion
            #region tabSettingsPortable
            public static readonly string lbSettingsPortableInformation = "You can toggle the use of a portable ini file here.\r\n\r\nIf enabled, the program will contain all your settings in the \"settings.ini\" file located in the same directory as youtube-dl-gui.\r\n\r\nThis is useful if you want to use this program with your settings on other systems, which is fine.\r\n\r\nToggling the ini file will transfer your current settings.\r\n\r\n";
            public static readonly string chkSettingsPortableToggleIni = "Toggle portable ini";
            #endregion

            #endregion

            #region frmSubtitles
            // frmSubtitles
            public static readonly string frmSubtitles = "Download subtitles";
            public static readonly string lbSubtitlesHeader = "This only downloads subtitles";
            public static readonly string lbSubtitlesUrl = "URL";
            public static readonly string lbSubtitlesLanguages = "Language(s)";
            public static readonly string btnSubtitlesAddLanguage = "Add";
            public static readonly string btnSubtitlesClearLanguages = "Clear";
            public static readonly string btnSubtitlesDownload = "Download subtitles";
            #endregion

            #region frmTools
            // frmTools
            public static readonly string frmTools = "Misc tools";
            public static readonly string btnMiscToolsRemoveAudio = "Remove audio...";
            public static readonly string btnMiscToolsExtractAudio = "Extract audio...";
            public static readonly string btnMiscToolsVideoToGif = "Video to gif...";
            #endregion

            #region frmUpdateAvailable
            public static readonly string frmUpdateAvailable = "Update available";
            public static readonly string lbUpdateAvailableHeader = "An update is available";
            public static readonly string lbUpdateAvailableUpdateVersion = "Update version:";
            public static readonly string lbUpdateAvailableCurrentVersion = "Current version:";
            public static readonly string lbUpdateAvailableChangelog = "Changelog:";
            public static readonly string btnUpdateAvailableSkipVersion = "Skip version";
            public static readonly string btnUpdateAvailableUpdate = "Update";
            public static readonly string btnUpdateAvailableOk = "OK";
            #endregion
        }

        /// <summary>
        /// Loads all the internal English strings to the instance.
        /// </summary>
        public void LoadInternalEnglish() {
            if (!Properties.Settings.Default.SkipInternalEnglish) {
                LoadedFile = null;

                // Langauge identifier
                CurrentLanguageLong = InternalEnglish.CurrentLanguageLong;
                CurrentLanguageShort = InternalEnglish.CurrentLanguageShort;
                CurrentLanguageHint = InternalEnglish.CurrentLanguageHint;

                // Generics
                GenericInputBest = InternalEnglish.GenericInputBest;
                GenericCancel = InternalEnglish.GenericCancel;
                GenericSkip = InternalEnglish.GenericSkip;
                GenericSound = InternalEnglish.GenericSound;
                GenericVideo = InternalEnglish.GenericVideo;
                GenericAudio = InternalEnglish.GenericAudio;
                GenericCustom = InternalEnglish.GenericCustom;
                GenericRetryString = InternalEnglish.GenericRetry;

                // frmAbout
                frmAbout = InternalEnglish.frmAbout;
                lbAboutBody = InternalEnglish.lbAboutBody;
                llbCheckForUpdates = InternalEnglish.llbCheckForUpdates;

                // frmAuthentication
                frmAuthentication = InternalEnglish.frmAuthentication;
                lbAuthNotice = InternalEnglish.lbAuthNotice;
                lbAuthUsername = InternalEnglish.lbAuthUsername;
                lbAuthPassword = InternalEnglish.lbAuthPassword;
                lbAuth2Factor = InternalEnglish.lbAuth2Factor;
                lbAuthVideoPassword = InternalEnglish.lbAuthVideoPassword;
                chkAuthUseNetrc = InternalEnglish.chkAuthUseNetrc;
                lbAuthNoSave = InternalEnglish.lbAuthNoSave;
                btnAuthBeginDownload = InternalEnglish.btnAuthBeginDownload;

                // frmBatch
                frmBatchDownload = InternalEnglish.frmBatchDownload;
                lbBatchDownloadLink = InternalEnglish.lbBatchDownloadLink;
                lbBatchDownloadType = InternalEnglish.lbBatchDownloadType;
                lbBatchDownloadVideoSpecificArgument = InternalEnglish.lbBatchDownloadVideoSpecificArgument;
                btnBatchDownloadAdd = InternalEnglish.btnBatchDownloadAdd;
                sbBatchDownloadLoadArgs = InternalEnglish.sbBatchDownloadLoadArgs;
                mBatchDownloaderLoadArgsFromSettings = InternalEnglish.mBatchDownloaderLoadArgsFromSettings;
                mBatchDownloaderLoadArgsFromArgsTxt = InternalEnglish.mBatchDownloaderLoadArgsFromArgsTxt;
                mBatchDownloaderLoadArgsFromFile = InternalEnglish.mBatchDownloaderLoadArgsFromFile;
                btnBatchDownloadRemoveSelected = InternalEnglish.btnBatchDownloadRemoveSelected;
                btnBatchDownloadStart = InternalEnglish.btnBatchDownloadStart;
                btnBatchDownloadStop = InternalEnglish.btnBatchDownloadStop;
                btnBatchDownloadExit = InternalEnglish.btnBatchDownloadExit;
                sbBatchDownloaderIdle = InternalEnglish.sbBatchDownloaderIdle;
                sbBatchDownloaderDownloading = InternalEnglish.sbBatchDownloaderDownloading;
                sbBatchDownloaderFinished = InternalEnglish.sbBatchDownloaderFinished;
                sbBatchDownloaderAborted = InternalEnglish.sbBatchDownloaderAborted;

                // frmDownloader
                frmDownloader = InternalEnglish.frmDownloader;
                frmDownloaderComplete = InternalEnglish.frmDownloaderComplete;
                frmDownloaderError = InternalEnglish.frmDownloaderError;
                chkDownloaderCloseAfterDownload = InternalEnglish.chkDownloaderCloseAfterDownload;
                btnDownloaderAbortBatch = InternalEnglish.btnDownloaderAbortBatch;
                btnDownloaderExit = InternalEnglish.btnDownloaderExit;

                // frmException
                frmException = InternalEnglish.frmException;
                lbExceptionHeader = InternalEnglish.lbExceptionHeader;
                lbExceptionDescription = InternalEnglish.lbExceptionDescription;
                rtbExceptionDetails = InternalEnglish.rtbExceptionDetails;
                btnExceptionGithub = InternalEnglish.btnExceptionGithub;
                btnExceptionOk = InternalEnglish.btnExceptionOk;

                // frmLanguage
                frmLanguage = InternalEnglish.frmLanguage;
                btnLanguageRefresh = InternalEnglish.btnLanguageRefresh;
                btnLanguageCancel = InternalEnglish.btnLanguageCancel;
                btnLanguageSave = InternalEnglish.btnLanguageSave;

                // frmMain
                mSettings = InternalEnglish.mSettings;
                mTools = InternalEnglish.mTools;
                mBatchDownload = InternalEnglish.mBatchDownload;
                mDownloadSubtitles = InternalEnglish.mDownloadSubtitles;
                mMiscTools = InternalEnglish.mMiscTools;
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
                chkDownloadSound = InternalEnglish.chkDownloadSound;
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
                txtArgsHint = InternalEnglish.txtArgsHint;
                sbDownload = InternalEnglish.sbDownload;
                mDownloadWithAuthentication = InternalEnglish.mDownloadWithAuthentication;
                msgBatchDownloadFromFile = InternalEnglish.msgBatchDownloadFromFile;
                mBatchDownloadFromFile = InternalEnglish.mBatchDownloadFromFile;
                lbDownloadStatusStarted = InternalEnglish.lbDownloadStatusStarted;
                lbDownloadStatusError = InternalEnglish.lbDownloadStatusError;

                lbConvertInput = InternalEnglish.lbConvertInput;
                lbConvertOutput = InternalEnglish.lbConvertOutput;
                rbConvertAuto = InternalEnglish.rbConvertAuto;
                rbConvertAutoFFmpeg = InternalEnglish.rbConvertAutoFFmpeg;
                btnConvert = InternalEnglish.btnConvert;
                lbConvertStarted = InternalEnglish.lbConvertStarted;
                lbConvertFailed = InternalEnglish.lbConvertFailed;

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

                // frmSettings
                frmSettings = InternalEnglish.frmSettings;
                btnSettingsRedownloadYoutubeDl = InternalEnglish.btnSettingsRedownloadYoutubeDl;
                btnSettingsSave = InternalEnglish.btnSettingsSave;

                tabSettingsGeneral = InternalEnglish.tabSettingsGeneral;
                tabSettingsDownloads = InternalEnglish.tabSettingsDownloads;
                tabSettingsConverter = InternalEnglish.tabSettingsConverter;
                tabSettingsExtensions = InternalEnglish.tabSettingsExtensions;
                tabSettingsErrors = InternalEnglish.tabSettingsErrors;
                tabSettingsPortable = InternalEnglish.tabSettingsPortable;

                lbSettingsGeneralYoutubeDlPath = InternalEnglish.lbSettingsGeneralYoutubeDlPath;
                chkSettingsGeneralUseStaticYoutubeDl = InternalEnglish.chkSettingsGeneralUseStaticYoutubeDl;
                ofdTitleYoutubeDl = InternalEnglish.ofdTitleYoutubeDl;
                ofdFilterYoutubeDl = InternalEnglish.ofdFilterYoutubeDl;
                lbSettingsGeneralFFmpegDirectory = InternalEnglish.lbSettingsGeneralFFmpegDirectory;
                chkSettingsGeneralUseStaticFFmpeg = InternalEnglish.chkSettingsGeneralUseStaticFFmpeg;
                ofdTitleFFmpeg = InternalEnglish.ofdTitleFFmpeg;
                ofdFilterFFmpeg = InternalEnglish.ofdFilterFFmpeg;
                chkSettingsGeneralCheckForUpdatesOnLaunch = InternalEnglish.chkSettingsGeneralCheckForUpdatesOnLaunch;
                chkSettingsGeneralCheckForBetaUpdates = InternalEnglish.chkSettingsGeneralCheckForBetaUpdates;
                chkSettingsGeneralHoverOverUrlToPasteClipboard = InternalEnglish.chkSettingsGeneralHoverOverUrlToPasteClipboard;
                chkSettingsGeneralClearUrlOnDownload = InternalEnglish.chkSettingsGeneralClearUrlOnDownload;
                chkSettingsGeneralClearClipboardOnDownload = InternalEnglish.chkSettingsGeneralClearClipboardOnDownload;
                gbSettingsGeneralCustomArguments = InternalEnglish.gbSettingsGeneralCustomArguments;
                rbSettingsGeneralCustomArgumentsDontSave = InternalEnglish.rbSettingsGeneralCustomArgumentsDontSave;
                rbSettingsGeneralCustomArgumentsSaveAsArgsText = InternalEnglish.rbSettingsGeneralCustomArgumentsSaveAsArgsText;
                rbSettingsGeneralCustomArgumentsSaveInSettings = InternalEnglish.rbSettingsGeneralCustomArgumentsSaveInSettings;

                lbSettingsDownloadsDownloadPath = InternalEnglish.lbSettingsDownloadsDownloadPath;
                lbSettingsDownloadsFileNameSchema = InternalEnglish.lbSettingsDownloadsFileNameSchema;
                tabDownloadsGeneral = InternalEnglish.tabDownloadsGeneral;
                tabDownloadsSorting = InternalEnglish.tabDownloadsSorting;
                tabDownloadsFixes = InternalEnglish.tabdownloadsFixes;
                tabDownloadsConnection = InternalEnglish.tabDownloadsConnection;
                tabDownloadsUpdating = InternalEnglish.tabDownloadsUpdating;

                chkSettingsDownloadsSaveFormatQuality = InternalEnglish.chkSettingsDownloadsSaveFormatQuality;
                chkSettingsDownloadsDownloadSubtitles = InternalEnglish.chkSettingsDownloadsDownloadSubtitles;
                chkSettingsDownloadsEmbedSubtitles = InternalEnglish.chkSettingsDownloadsEmbedSubtitles;
                chkSettingsDownloadsSaveVideoInfo = InternalEnglish.chkSettingsDownloadsSaveVideoInfo;
                chkSettingsDownloadsWriteMetadataToFile = InternalEnglish.chkSettingsDownloadsWriteMetadataToFile;
                chkSettingsDownloadsSaveDescription = InternalEnglish.chkSettingsDownloadsSaveDescription;
                chkSettingsDownloadsKeepOriginalFiles = InternalEnglish.chkSettingsDownloadsKeepOriginalFiles;
                chkSettingsDownloadsSaveAnnotations = InternalEnglish.chkSettingsDownloadsSaveAnnotations;
                chkSettingsDownloadsSaveThumbnails = InternalEnglish.chkSettingsDownloadsSaveThumbnails;
                chkSettingsDownloadsEmbedThumbnails = InternalEnglish.chkSettingsDownloadsEmbedThumbnails;
                chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = InternalEnglish.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing;
                chkSettingsDownloadsSeparateDownloadsToDifferentFolders = InternalEnglish.chkSettingsDownloadsSeparateDownloadsToDifferentFolders;
                chkSettingsDownloadsSeparateIntoWebsiteUrl = InternalEnglish.chkSettingsDownloadsSeparateIntoWebsiteUrl;
                chkSettingsDownloadsFixVReddIt = InternalEnglish.chkSettingsDownloadsFixVReddIt;
                chkSettingsDownloadsPreferFFmpeg = InternalEnglish.chkSettingsDownloadsPreferFFmpeg;
                chkSettingsDownloadsLimitDownload = InternalEnglish.chkSettingsDownloadsLimitDownload;
                lbSettingsDownloadsRetryAttempts = InternalEnglish.lbSettingsDownloadsRetryAttempts;
                chkSettingsDownloadsForceIpv4 = InternalEnglish.chkSettingsDownloadsForceIpv4;
                chkSettingsDownloadsForceIpv6 = InternalEnglish.chkSettingsDownloadsForceIpv6;
                chkSettingsDownloadsUseProxy = InternalEnglish.chkSettingsDownloadsUseProxy;
                chkSettingsDownloadsUseYoutubeDlsUpdater = InternalEnglish.chksettingsDownloadsUseYoutubeDlsUpdater;
                lbSettingsDownloadsUpdatingYtdlType = InternalEnglish.lbSettingsDownloadsUpdatingYtdlType;
                llbSettingsDownloadsYtdlTypeViewRepo = InternalEnglish.llbSettingsDownloadsYtdlTypeViewRepo;
                chkSettingsDownloadsSeparateBatchDownloads = InternalEnglish.chkSettingsDownloadsSeparateBatchDownloads;
                chkSettingsDownloadsAddDateToBatchDownloadFolders = InternalEnglish.chkSettingsDownloadsAddDateToBatchDownloadFolders;

                chkSettingsConverterClearOutputAfterConverting = InternalEnglish.chkSettingsConverterClearOutputAfterConverting;
                chkSettingsConverterDetectOutputFileType = InternalEnglish.chkSettingsConverterDetectOutputFileType;
                chkSettingsConverterClearInputAfterConverting = InternalEnglish.chkSettingsConverterClearInputAfterConverting;
                chkSettingsConverterHideFFmpegCompileInfo = InternalEnglish.chkSettingsConverterHideFFmpegCompileInfo;
                tcSettingsConverterVideo = InternalEnglish.tcSettingsConverterVideo;
                tcSettingsConverterAudio = InternalEnglish.tcSettingsConverterAudio;
                tcSettingsConverterCustom = InternalEnglish.tcSettingsConverterCustom;
                lbSettingsConverterVideoBitrate = InternalEnglish.lbSettingsConverterVideoBitrate;
                lbSettingsConverterVideoPreset = InternalEnglish.lbSettingsConverterVideoPreset;
                lbSettingsConverterVideoProfile = InternalEnglish.lbSettingsConverterVideoProfile;
                lbSettingsConverterVideoCRF = InternalEnglish.lbSettingsConverterVideoCRF;
                chkSettingsConverterVideoFastStart = InternalEnglish.chkSettingsConverterVideoFastStart;
                lbSettingsConverterAudioBitrate = InternalEnglish.lbSettingsConverterAudioBitrate;
                lbSettingsConverterCustomHeader = InternalEnglish.lbSettingsConverterCustomHeader;

                lbSettingsExtensionsHeader = InternalEnglish.lbSettingsExtensionsHeader;
                lbSettingsExtensionsExtensionFullName = InternalEnglish.lbSettingsExtensionsExtensionFullName;
                txtSettingsExtensionsExtensionFullName = InternalEnglish.txtSettingsExtensionsExtensionFullName;
                lbSettingsExtensionsExtensionShort = InternalEnglish.lbSettingsExtensionsExtensionShort;
                txtSettingsExtensionsExtensionShort = InternalEnglish.txtSettingsExtensionsExtensionShort;
                btnSettingsExtensionsAdd = InternalEnglish.btnSettingsExtensionsAdd;
                lbSettingsExtensionsFileName = InternalEnglish.lbSettingsExtensionsFileName;
                btnSettingsExtensionsRemoveSelected = InternalEnglish.btnSettingsExtensionsRemoveSelected;

                chkSettingsErrorsShowDetailedErrors = InternalEnglish.chkSettingsErrorsShowDetailedErrors;
                chkSettingsErrorsSaveErrorsAsErrorLog = InternalEnglish.chkSettingsErrorsSaveErrorsAsErrorLog;
                chkSettingsErrorsSuppressErrors = InternalEnglish.chkSettingsErrorsSuppressErrors;

                lbSettingsPortableInformation = InternalEnglish.lbSettingsPortableInformation;
                chkSettingsPortableToggleIni = InternalEnglish.chkSettingsPortableToggleIni;

                // frmSettings tipSettings
                btnSettingsRedownloadYoutubeDlHint = InternalEnglish.btnSettingsRedownloadYoutubeDlHint;
                btnSettingsCancelHint = InternalEnglish.btnSettingsCancelHint;
                btnSettingsSaveHint = InternalEnglish.btnSettingsSaveHint;

                lbSettingsGeneralYoutubeDlPathHint = InternalEnglish.lbSettingsGeneralYoutubeDlPathHint;
                chkSettingsGeneralUseStaticYoutubeDlHint = InternalEnglish.chkSettingsGeneralUseStaticYoutubeDlHint;
                txtSettingsGeneralYoutubeDlPathHint = InternalEnglish.txtSettingsGeneralYoutubeDlPathHint;
                btnSettingsGeneralBrowseYoutubeDlHint = InternalEnglish.btnSettingsGeneralBrowseYoutubeDlHint;
                lbSettingsGeneralFFmpegDirectoryHint = InternalEnglish.lbSettingsGeneralFFmpegDirectoryHint;
                chkSettingsGeneralUseStaticFFmpegHint = InternalEnglish.chkSettingsGeneralUseStaticFFmpegHint;
                txtSettingsGeneralFFmpegPathHint = InternalEnglish.txtSettingsGeneralFFmpegPathHint;
                btnSettingsGeneralBrowseFFmpegHint = InternalEnglish.btnSettingsGeneralBrowseFFmpegHint;
                chkSettingsGeneralCheckForUpdatesOnLaunchHint = InternalEnglish.chkSettingsGeneralCheckForUpdatesOnLaunchHint;
                chkSettingsGeneralCheckForBetaUpdatesHint = InternalEnglish.chkSettingsGeneralCheckForBetaUpdatesHint;
                chkSettingsGeneralHoverOverUrlToPasteClipboardHint = InternalEnglish.chkSettingsGeneralHoverOverUrlToPasteClipboardHint;
                chkSettingsGeneralClearUrlOnDownloadHint = InternalEnglish.chkSettingsGeneralClearUrlOnDownloadHint;
                chkSettingsGeneralClearClipboardOnDownloadHint = InternalEnglish.chkSettingsGeneralClearClipboardOnDownloadHint;
                gbSettingsGeneralCustomArgumentsHint = InternalEnglish.gbSettingsGeneralCustomArgumentsHint;
                rbSettingsGeneralCustomArgumentsDontSaveHint = InternalEnglish.rbSettingsGeneralCustomArgumentsDontSaveHint;
                rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = InternalEnglish.rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint;
                rbSettingsGeneralCustomArgumentsSaveInSettingsHint = InternalEnglish.rbSettingsGeneralCustomArgumentsSaveInSettingsHint;

                lbSettingsDownloadsDownloadPathHint = InternalEnglish.lbSettingsDownloadsDownloadPathHint;
                chkSettingsDownloadsDownloadPathUseRelativePathHint = InternalEnglish.chkSettingsDownloadsDownloadPathUseRelativePathHint;
                txtSettingsDownloadsSavePathHint = InternalEnglish.txtSettingsDownloadsSavePathHint;
                btnSettingsDownloadsBrowseSavePathHint = InternalEnglish.btnSettingsDownloadsBrowseSavePathHint;
                llSettingsDownloadsSchemaHelpHint = InternalEnglish.llSettingsDownloadsSchemaHelpHint;
                lbSettingsDownloadsFileNameSchemaHint = InternalEnglish.lbSettingsDownloadsFileNameSchemaHint;
                txtSettingsDownloadsFileNameSchemaHint = InternalEnglish.txtSettingsDownloadsFileNameSchemaHint;

                chkSettingsDownloadsSaveFormatQualityHint = InternalEnglish.chkSettingsDownloadsSaveFormatQualityHint;
                chkSettingsDownloadsDownloadSubtitlesHint = InternalEnglish.chkSettingsDownloadsDownloadSubtitlesHint;
                chkSettingsDownloadsEmbedSubtitlesHint = InternalEnglish.chkSettingsDownloadsEmbedSubtitlesHint;
                chkSettingsDownloadsSaveVideoInfoHint = InternalEnglish.chkSettingsDownloadsSaveVideoInfoHint;
                chkSettingsDownloadsWriteMetadataToFileHint = InternalEnglish.chkSettingsDownloadsWriteMetadataToFileHint;
                chkSettingsDownloadsSaveDescriptionHint = InternalEnglish.chkSettingsDownloadsSaveDescriptionHint;
                chkSettingsDownloadsKeepOriginalFilesHint = InternalEnglish.chkSettingsDownloadsKeepOriginalFilesHint;
                chkSettingsDownloadsSaveAnnotationsHint = InternalEnglish.chkSettingsDownloadsSaveAnnotationsHint;
                chkSettingsDownloadsSaveThumbnailsHint = InternalEnglish.chkSettingsDownloadsSaveThumbnailsHint;
                chkSettingsDownloadsEmbedThumbnailsHint = InternalEnglish.chkSettingsDownloadsEmbedThumbnailsHint;
                chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = InternalEnglish.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint;
                chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = InternalEnglish.chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint;
                chkSettingsDownloadsSeparateIntoWebsiteUrlHint = InternalEnglish.chkSettingsDownloadsSeparateIntoWebsiteUrlHint;
                chkSettingsDownloadsFixVReddItHint = InternalEnglish.chkSettingsDownloadsFixVReddItHint;
                chkSettingsDownloadsPreferFFmpegHint = InternalEnglish.chkSettingsDownloadsPreferFFmpegHint;
                chkSettingsDownloadsLimitDownloadHint = InternalEnglish.chkSettingsDownloadsLimitDownloadHint;
                numSettingsDownloadsLimitDownloadHint = InternalEnglish.numSettingsDownloadsLimitDownloadHint;
                cbSettingsDownloadsLimitDownloadHint = InternalEnglish.cbSettingsDownloadsLimitDownloadHint;
                lbSettingsDownloadsRetryAttemptsHint = InternalEnglish.lbSettingsDownloadsRetryAttemptsHint;
                numSettingsDownloadsRetryAttemptsHint = InternalEnglish.numSettingsDownloadsRetryAttemptsHint;
                chkSettingsDownloadsForceIpv4Hint = InternalEnglish.chkSettingsDownloadsForceIpv4Hint;
                chkSettingsDownloadsForceIpv6Hint = InternalEnglish.chkSettingsDownloadsForceIpv6Hint;
                chkSettingsDownloadsUseProxyHint = InternalEnglish.chkSettingsDownloadsUseProxyHint;
                cbSettingsDownloadsProxyTypeHint = InternalEnglish.cbSettingsDownloadsProxyTypeHint;
                txtSettingsDownloadsProxyIpHint = InternalEnglish.txtSettingsDownloadsProxyIpHint;
                txtSettingsDownloadsProxyPortHint = InternalEnglish.txtSettingsDownloadsProxyPortHint;
                chksettingsDownloadsUseYoutubeDlsUpdaterHint = InternalEnglish.chksettingsDownloadsUseYoutubeDlsUpdaterHint;
                cbSettingsDownloadsUpdatingYtdlTypeHint = InternalEnglish.cbSettingsDownloadsUpdatingYtdlTypeHint;
                llbSettingsDownloadsYtdlTypeViewRepoHint = InternalEnglish.llbSettingsDownloadsYtdlTypeViewRepoHint;
                chkSettingsDownloadsSeparateBatchDownloadsHint = InternalEnglish.chkSettingsDownloadsSeparateBatchDownloadsHint;
                chkSettingsDownloadsAddDateToBatchDownloadFoldersHint = InternalEnglish.chkSettingsDownloadsAddDateToBatchDownloadFoldersHint;

                chkSettingsConverterClearOutputAfterConvertingHint = InternalEnglish.chkSettingsConverterClearOutputAfterConvertingHint;
                chkSettingsConverterDetectOutputFileTypeHint = InternalEnglish.chkSettingsConverterDetectOutputFileTypeHint;
                chkSettingsConverterClearInputAfterConvertingHint = InternalEnglish.chkSettingsConverterClearInputAfterConvertingHint;
                chkSettingsConverterHideFFmpegCompileInfoHint = InternalEnglish.chkSettingsConverterHideFFmpegCompileInfoHint;
                lbSettingsConverterVideoBitrateHint = InternalEnglish.lbSettingsConverterVideoBitrateHint;
                lbSettingsConverterVideoPresetHint = InternalEnglish.lbSettingsConverterVideoPresetHint;
                lbSettingsConverterVideoProfileHint = InternalEnglish.lbSettingsConverterVideoProfileHint;
                lbSettingsConverterVideoCRFHint = InternalEnglish.lbSettingsConverterVideoCRFHint;
                chkSettingsConverterVideoFastStartHint = InternalEnglish.chkSettingsConverterVideoFastStartHint;
                lbSettingsConverterAudioBitrateHint = InternalEnglish.lbSettingsConverterAudioBitrateHint;
                txtSettingsConverterCustomArgumentsHint = InternalEnglish.txtSettingsConverterCustomArgumentsHint;

                //lbSettingsExtensionsHeader = InternalEnglish.lbSettingsExtensionsHeader;
                //lbSettingsExtensionsExtensionFullName = InternalEnglish.lbSettingsExtensionsExtensionFullName;
                //lbSettingsExtensionsExtensionShort = InternalEnglish.lbSettingsExtensionsExtensionShort;
                //btnSettingsExtensionsAdd = InternalEnglish.btnSettingsExtensionsAdd;
                //btnSettingsExtensionsRemoveSelected = InternalEnglish.btnSettingsExtensionsRemoveSelected;

                chkSettingsErrorsShowDetailedErrorsHint = InternalEnglish.chkSettingsErrorsShowDetailedErrorsHint;
                chkSettingsErrorsSaveErrorsAsErrorLogHint = InternalEnglish.chkSettingsErrorsSaveErrorsAsErrorLogHint;
                chkSettingsErrorsSuppressErrorsHint = InternalEnglish.chkSettingsErrorsSuppressErrorsHint;


                // frmSubtitles
                frmSubtitles = InternalEnglish.frmSubtitles;
                lbSubtitlesHeader = InternalEnglish.lbSubtitlesHeader;
                lbSubtitlesUrl = InternalEnglish.lbSubtitlesUrl;
                lbSubtitlesLanguages = InternalEnglish.lbSubtitlesLanguages;
                btnSubtitlesAddLanguage = InternalEnglish.btnSubtitlesAddLanguage;
                btnSubtitlesClearLanguages = InternalEnglish.btnSubtitlesClearLanguages;
                btnSubtitlesDownload = InternalEnglish.btnSubtitlesDownload;

                // frmTools
                frmTools = InternalEnglish.frmTools;
                btnMiscToolsRemoveAudio = InternalEnglish.btnMiscToolsRemoveAudio;
                btnMiscToolsExtractAudio = InternalEnglish.btnMiscToolsExtractAudio;
                btnMiscToolsVideoToGif = InternalEnglish.btnMiscToolsVideoToGif;

                // frmUpdateAvailable
                frmUpdateAvailable = InternalEnglish.frmUpdateAvailable;
                lbUpdateAvailableHeader = InternalEnglish.lbUpdateAvailableHeader;
                lbUpdateAvailableUpdateVersion = InternalEnglish.lbUpdateAvailableUpdateVersion;
                lbUpdateAvailableCurrentVersion = InternalEnglish.lbUpdateAvailableCurrentVersion;
                lbUpdateAvailableChangelog = InternalEnglish.lbUpdateAvailableChangelog;
                btnUpdateAvailableSkipVersion = InternalEnglish.btnUpdateAvailableSkipVersion;
                btnUpdateAvailableUpdate = InternalEnglish.btnUpdateAvailableUpdate;
                btnUpdateAvailableOk = InternalEnglish.btnUpdateAvailableOk;
            }
        }

        /// <summary>
        /// Resets the control names to their internal names.
        /// </summary>
        public void ResetControlNames() {
            LoadedFile = null;

            // Langauge identifier
            CurrentLanguageLong = "CurrentLanguageLong";
            CurrentLanguageShort = "CurrentLanguageShort";
            CurrentLanguageHint = "CurrentLanguageHint";

            // Generics
            GenericInputBest = "GenericInputBest";
            GenericCancel = "GenericCancel";
            GenericSkip = "GenericSkip";
            GenericSound = "GenericSound";
            GenericVideo = "GenericVideo";
            GenericAudio = "GenericAudio";
            GenericCustom = "GenericCustom";
            GenericRetry = "GenericRetry";

            // frmAbout
            frmAbout = "frmAbout";
            lbAboutBody = "lbAboutBody";
            llbCheckForUpdates = "llbCheckForUpdates";

            // frmAuthentication
            frmAuthentication = "frmAuthentication";
            lbAuthNotice = "lbAuthNotice";
            lbAuthUsername = "lbAuthUsername";
            lbAuthPassword = "lbAuthPassword";
            lbAuth2Factor = "lbAuth2Factor";
            lbAuthVideoPassword = "lbAuthVideoPassword";
            chkAuthUseNetrc = "chkAuthUseNetrc";
            lbAuthNoSave = "lbAuthNoSave";
            btnAuthBeginDownload = "btnAuthBeginDownload";

            // frmBatch
            frmBatchDownload = "frmBatchDownload";
            lbBatchDownloadLink = "lbBatchDownloadLink";
            lbBatchDownloadType = "lbBatchDownloadType";
            lbBatchDownloadVideoSpecificArgument = "lbBatchDownloadVideoSpecificArgument";
            btnBatchDownloadAdd = "btnBatchDownloadAdd";
            sbBatchDownloadLoadArgs = "sbBatchDownloadLoadArgs";
            mBatchDownloaderLoadArgsFromSettings = "mBatchDownloaderLoadArgsFromSettings";
            mBatchDownloaderLoadArgsFromArgsTxt = "mBatchDownloaderLoadArgsFromArgsTxt";
            mBatchDownloaderLoadArgsFromFile = "mBatchDownloaderLoadArgsFromFile";
            btnBatchDownloadRemoveSelected = "btnBatchDownloadRemoveSelected";
            btnBatchDownloadStart = "btnBatchDownloadStart";
            btnBatchDownloadStop = "btnBatchDownloadStop";
            btnBatchDownloadExit = "btnBatchDownloadExit";
            sbBatchDownloaderIdle = "sbBatchDownloaderIdle";
            sbBatchDownloaderDownloading = "sbBatchDownloaderDownloading";
            sbBatchDownloaderFinished = "sbBatchDownloaderFinished";
            sbBatchDownloaderAborted = "sbBatchDownloaderAborted";

            // frmDownloader
            frmDownloader = "frmDownloader";
            frmDownloaderComplete = "frmDownloaderComplete";
            frmDownloaderError = "frmDownloaderError";
            chkDownloaderCloseAfterDownload = "chkDownloaderCloseAfterDownload";
            btnDownloaderAbortBatch = "btnDownloaderAbortBatch";
            btnDownloaderExit = "btnDownloaderExit";

            // frmException
            frmException = "frmException";
            lbExceptionHeader = "lbExceptionHeader";
            lbExceptionDescription = "lbExceptionDescription";
            rtbExceptionDetails = "rtbExceptionDetails";
            btnExceptionGithub = "btnExceptionGithub";
            btnExceptionOk = "btnExceptionOk";

            // frmLanguage
            frmLanguage = "frmLanguage";
            btnLanguageRefresh = "btnLanguageRefresh";
            btnLanguageCancel = "btnLanguageCancel";
            btnLanguageSave = "btnLanguageSave";

            // frmMain
            mSettings = "mSettings";
            mTools = "mTools";
            mBatchDownload = "mBatchDownload";
            mDownloadSubtitles = "mDownloadSubtitles";
            mMiscTools = "mMiscTools";
            mHelp = "mHelp";
            mLanguage = "mLanguage";
            mSupportedSites = "mSupportedSites";
            mAbout = "mAbout";

            tabDownload = "tabDownload";
            tabConvert = "tabConvert";
            tabMerge = "tabMerge";

            lbURL = "lbURL";
            txtUrlHint = "txtUrlHint";
            gbDownloadType = "gbDownloadType";
            lbQuality = "lbQuality";
            lbFormat = "lbFormat";
            chkDownloadSound = "chkDownloadSound";
            chkUseSelection = "chkUseSelection";
            rbVideoSelectionPlaylistIndex = "rbVideoSelectionPlaylistIndex";
            rbVideoSelectionPlaylistItems = "rbVideoSelectionPlaylistItems";
            rbVideoSelectionBeforeDate = "rbVideoSelectionBeforeDate";
            rbVideoSelectionOnDate = "rbVideoSelectionOnDate";
            rbVideoSelectionAfterDate = "rbVideoSelectionAfterDate";
            txtPlaylistStartHint = "txtPlaylistStartHint";
            txtPlaylistEndHint = "txtPlaylistEndHint";
            txtPlaylistItemsHint = "txtPlaylistItemsHint";
            txtVideoDateHint = "txtVideoDateHint";
            lbCustomArguments = "lbCustomArguments";
            txtArgsHint = "txtArgsHint";
            sbDownload = "sbDownload";
            mDownloadWithAuthentication = "mDownloadWithAuthentication";
            msgBatchDownloadFromFile = "msgBatchDownloadFromFile";
            mBatchDownloadFromFile = "mBatchDownloadFromFile";
            lbDownloadStatusStarted = "lbDownloadStatusStarted";
            lbDownloadStatusError = "lbDownloadStatusError";

            lbConvertInput = "lbConvertInput";
            lbConvertOutput = "lbConvertOutput";
            rbConvertAuto = "rbConvertAuto";
            rbConvertAutoFFmpeg = "rbConvertAutoFFmpeg";
            btnConvert = "btnConvert";
            lbConvertStarted = "lbConvertStarted";
            lbConvertFailed = "lbConvertFailed";

            lbMergeInput1 = "lbMergeInput1";
            lbMergeInput2 = "lbMergeInput2";
            lbMergeOutput = "lbMergeOutput";
            chkMergeAudioTracks = "chkMergeAudioTracks";
            chkMergeDeleteInputFiles = "chkMergeDeleteInputFiles";
            btnMerge = "btnMerge";

            cmTrayShowForm = "cmTrayShowForm";
            cmTrayDownloader = "cmTrayDownloader";
            cmTrayDownloadClipboard = "cmTrayDownloadClipboard";
            cmTrayDownloadBestVideo = "cmTrayDownloadBestVideo";
            cmTrayDownloadBestAudio = "cmTrayDownloadBestAudio";
            cmTrayDownloadCustom = "cmTrayDownloadCustom";
            cmTrayDownloadCustomTxtBox = "cmTrayDownloadCustomTxtBox";
            cmTrayDownloadCustomTxt = "cmTrayDownloadCustomTxt";
            cmTrayDownloadCustomSettings = "cmTrayDownloadCustomSettings";
            cmTrayConverter = "cmTrayConverter";
            cmTrayConvertTo = "cmTrayConvertTo";
            cmTrayConvertVideo = "cmTrayConvertVideo";
            cmTrayConvertAudio = "cmTrayConvertAudio";
            cmTrayConvertCustom = "cmTrayConvertCustom";
            cmTrayConvertAutomatic = "cmTrayConvertAutomatic";
            cmTrayConvertAutoFFmpeg = "cmTrayConvertAutoFFmpeg";
            cmTrayExit = "cmTrayExit";

            // frmSettings
            frmSettings = "frmSettings";
            btnSettingsRedownloadYoutubeDl = "btnSettingsRedownloadYoutubeDl";
            btnSettingsSave = "btnSettingsSave";

            tabSettingsGeneral = "tabSettingsGeneral";
            tabSettingsDownloads = "tabSettingsDownloads";
            tabSettingsConverter = "tabSettingsConverter";
            tabSettingsExtensions = "tabSettingsExtensions";
            tabSettingsErrors = "tabSettingsErrors";
            tabSettingsPortable = "tabSettingsPortable";

            lbSettingsGeneralYoutubeDlPath = "lbSettingsGeneralYoutubeDlPath";
            chkSettingsGeneralUseStaticYoutubeDl = "chkSettingsGeneralUseStaticYoutubeDl";
            ofdTitleYoutubeDl = "ofdTitleYoutubeDl";
            ofdFilterYoutubeDl = "ofdFilterYoutubeDl";
            lbSettingsGeneralFFmpegDirectory = "lbSettingsGeneralFFmpegDirectory";
            chkSettingsGeneralUseStaticFFmpeg = "chkSettingsGeneralUseStaticFFmpeg";
            ofdTitleFFmpeg = "ofdTitleFFmpeg";
            ofdFilterFFmpeg = "ofdFilterFFmpeg";
            chkSettingsGeneralCheckForUpdatesOnLaunch = "chkSettingsGeneralCheckForUpdatesOnLaunch";
            chkSettingsGeneralCheckForBetaUpdates = "chkSettingsGeneralCheckForBetaUpdates";
            chkSettingsGeneralHoverOverUrlToPasteClipboard = "chkSettingsGeneralHoverOverUrlToPasteClipboard";
            chkSettingsGeneralClearUrlOnDownload = "chkSettingsGeneralClearUrlOnDownload";
            chkSettingsGeneralClearClipboardOnDownload = "chkSettingsGeneralClearClipboardOnDownload";
            gbSettingsGeneralCustomArguments = "gbSettingsGeneralCustomArguments";
            rbSettingsGeneralCustomArgumentsDontSave = "rbSettingsGeneralCustomArgumentsDontSave";
            rbSettingsGeneralCustomArgumentsSaveAsArgsText = "rbSettingsGeneralCustomArgumentsSaveAsArgsText";
            rbSettingsGeneralCustomArgumentsSaveInSettings = "rbSettingsGeneralCustomArgumentsSaveInSettings";

            lbSettingsDownloadsDownloadPath = "lbSettingsDownloadsDownloadPath";
            lbSettingsDownloadsFileNameSchema = "lbSettingsDownloadsFileNameSchema";
            tabDownloadsGeneral = "tabDownloadsGeneral";
            tabDownloadsSorting = "tabDownloadsSorting";
            tabDownloadsFixes = "tabdownloadsFixes";
            tabDownloadsConnection = "tabDownloadsConnection";
            tabDownloadsUpdating = "tabDownloadsUpdating";

            chkSettingsDownloadsSaveFormatQuality = "chkSettingsDownloadsSaveFormatQuality";
            chkSettingsDownloadsDownloadSubtitles = "chkSettingsDownloadsDownloadSubtitles";
            chkSettingsDownloadsEmbedSubtitles = "chkSettingsDownloadsEmbedSubtitles";
            chkSettingsDownloadsSaveVideoInfo = "chkSettingsDownloadsSaveVideoInfo";
            chkSettingsDownloadsWriteMetadataToFile = "chkSettingsDownloadsWriteMetadataToFile";
            chkSettingsDownloadsSaveDescription = "chkSettingsDownloadsSaveDescription";
            chkSettingsDownloadsKeepOriginalFiles = "chkSettingsDownloadsKeepOriginalFiles";
            chkSettingsDownloadsSaveAnnotations = "chkSettingsDownloadsSaveAnnotations";
            chkSettingsDownloadsSaveThumbnails = "chkSettingsDownloadsSaveThumbnails";
            chkSettingsDownloadsEmbedThumbnails = "chkSettingsDownloadsEmbedThumbnails";
            chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = "chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing";
            chkSettingsDownloadsSeparateDownloadsToDifferentFolders = "chkSettingsDownloadsSeparateDownloadsToDifferentFolders";
            chkSettingsDownloadsSeparateIntoWebsiteUrl = "chkSettingsDownloadsSeparateIntoWebsiteUrl";
            chkSettingsDownloadsFixVReddIt = "chkSettingsDownloadsFixVReddIt";
            chkSettingsDownloadsPreferFFmpeg = "chkSettingsDownloadsPreferFFmpeg";
            chkSettingsDownloadsLimitDownload = "chkSettingsDownloadsLimitDownload";
            lbSettingsDownloadsRetryAttempts = "lbSettingsDownloadsRetryAttempts";
            chkSettingsDownloadsForceIpv4 = "chkSettingsDownloadsForceIpv4";
            chkSettingsDownloadsForceIpv6 = "chkSettingsDownloadsForceIpv6";
            chkSettingsDownloadsUseProxy = "chkSettingsDownloadsUseProxy";
            chkSettingsDownloadsUseYoutubeDlsUpdater = "chksettingsDownloadsUseYoutubeDlsUpdater";
            lbSettingsDownloadsUpdatingYtdlType = "lbSettingsDownloadsUpdatingYtdlType";
            llbSettingsDownloadsYtdlTypeViewRepo = "llbSettingsDownloadsYtdlTypeViewRepo";
            chkSettingsDownloadsSeparateBatchDownloads = "chkSettingsDownloadsSeparateBatchDownloads";
            chkSettingsDownloadsAddDateToBatchDownloadFolders = "chkSettingsDownloadsAddDateToBatchDownloadFolders";

            chkSettingsConverterClearOutputAfterConverting = "chkSettingsConverterClearOutputAfterConverting";
            chkSettingsConverterDetectOutputFileType = "chkSettingsConverterDetectOutputFileType";
            chkSettingsConverterClearInputAfterConverting = "chkSettingsConverterClearInputAfterConverting";
            chkSettingsConverterHideFFmpegCompileInfo = "chkSettingsConverterHideFFmpegCompileInfo";
            tcSettingsConverterVideo = "tcSettingsConverterVideo";
            tcSettingsConverterAudio = "tcSettingsConverterAudio";
            tcSettingsConverterCustom = "tcSettingsConverterCustom";
            lbSettingsConverterVideoBitrate = "lbSettingsConverterVideoBitrate";
            lbSettingsConverterVideoPreset = "lbSettingsConverterVideoPreset";
            lbSettingsConverterVideoProfile = "lbSettingsConverterVideoProfile";
            lbSettingsConverterVideoCRF = "lbSettingsConverterVideoCRF";
            chkSettingsConverterVideoFastStart = "chkSettingsConverterVideoFastStart";
            lbSettingsConverterAudioBitrate = "lbSettingsConverterAudioBitrate";
            lbSettingsConverterCustomHeader = "lbSettingsConverterCustomHeader";

            lbSettingsExtensionsHeader = "lbSettingsExtensionsHeader";
            lbSettingsExtensionsExtensionFullName = "lbSettingsExtensionsExtensionFullName";
            txtSettingsExtensionsExtensionFullName = "txtSettingsExtensionsExtensionFullName";
            lbSettingsExtensionsExtensionShort = "lbSettingsExtensionsExtensionShort";
            txtSettingsExtensionsExtensionShort = "txtSettingsExtensionsExtensionShort";
            btnSettingsExtensionsAdd = "btnSettingsExtensionsAdd";
            lbSettingsExtensionsFileName = "lbSettingsExtensionsFileName";
            btnSettingsExtensionsRemoveSelected = "btnSettingsExtensionsRemoveSelected";

            chkSettingsErrorsShowDetailedErrors = "chkSettingsErrorsShowDetailedErrors";
            chkSettingsErrorsSaveErrorsAsErrorLog = "chkSettingsErrorsSaveErrorsAsErrorLog";
            chkSettingsErrorsSuppressErrors = "chkSettingsErrorsSuppressErrors";

            lbSettingsPortableInformation = "lbPortableInformation";
            chkSettingsPortableToggleIni = "chkPortableToggleIni";

            // frmSettings tipSettings
            btnSettingsRedownloadYoutubeDlHint = "btnSettingsRedownloadYoutubeDlHint";
            btnSettingsCancelHint = "btnSettingsCancelHint";
            btnSettingsSaveHint = "btnSettingsSaveHint";

            lbSettingsGeneralYoutubeDlPathHint = "lbSettingsGeneralYoutubeDlPathHint";
            chkSettingsGeneralUseStaticYoutubeDlHint = "chkSettingsGeneralUseStaticYoutubeDlHint";
            txtSettingsGeneralYoutubeDlPathHint = "txtSettingsGeneralYoutubeDlPathHint";
            btnSettingsGeneralBrowseYoutubeDlHint = "btnSettingsGeneralBrowseYoutubeDlHint";
            lbSettingsGeneralFFmpegDirectoryHint = "lbSettingsGeneralFFmpegDirectoryHint";
            chkSettingsGeneralUseStaticFFmpegHint = "chkSettingsGeneralUseStaticFFmpegHint";
            txtSettingsGeneralFFmpegPathHint = "txtSettingsGeneralFFmpegPathHint";
            btnSettingsGeneralBrowseFFmpegHint = "btnSettingsGeneralBrowseFFmpegHint";
            chkSettingsGeneralCheckForUpdatesOnLaunchHint = "chkSettingsGeneralCheckForUpdatesOnLaunchHint";
            chkSettingsGeneralCheckForBetaUpdatesHint = "chkSettingsGeneralCheckForBetaUpdatesHint";
            chkSettingsGeneralHoverOverUrlToPasteClipboardHint = "chkSettingsGeneralHoverOverUrlToPasteClipboardHint";
            chkSettingsGeneralClearUrlOnDownloadHint = "chkSettingsGeneralClearUrlOnDownloadHint";
            chkSettingsGeneralClearClipboardOnDownloadHint = "chkSettingsGeneralClearClipboardOnDownloadHint";
            gbSettingsGeneralCustomArgumentsHint = "gbSettingsGeneralCustomArgumentsHint";
            rbSettingsGeneralCustomArgumentsDontSaveHint = "rbSettingsGeneralCustomArgumentsDontSaveHint";
            rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = "rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint";
            rbSettingsGeneralCustomArgumentsSaveInSettingsHint = "rbSettingsGeneralCustomArgumentsSaveInSettingsHint";

            lbSettingsDownloadsDownloadPathHint = "lbSettingsDownloadsDownloadPathHint";
            chkSettingsDownloadsDownloadPathUseRelativePathHint = "chkSettingsDownloadsDownloadPathUseRelativePathHint";
            txtSettingsDownloadsSavePathHint = "txtSettingsDownloadsSavePathHint";
            btnSettingsDownloadsBrowseSavePathHint = "btnSettingsDownloadsBrowseSavePathHint";
            llSettingsDownloadsSchemaHelpHint = "llSettingsDownloadsSchemaHelpHint";
            lbSettingsDownloadsFileNameSchemaHint = "lbSettingsDownloadsFileNameSchemaHint";
            txtSettingsDownloadsFileNameSchemaHint = "txtSettingsDownloadsFileNameSchemaHint";

            chkSettingsDownloadsSaveFormatQualityHint = "chkSettingsDownloadsSaveFormatQualityHint";
            chkSettingsDownloadsDownloadSubtitlesHint = "chkSettingsDownloadsDownloadSubtitlesHint";
            chkSettingsDownloadsEmbedSubtitlesHint = "chkSettingsDownloadsEmbedSubtitlesHint";
            chkSettingsDownloadsSaveVideoInfoHint = "chkSettingsDownloadsSaveVideoInfoHint";
            chkSettingsDownloadsWriteMetadataToFileHint = "chkSettingsDownloadsWriteMetadataToFileHint";
            chkSettingsDownloadsSaveDescriptionHint = "chkSettingsDownloadsSaveDescriptionHint";
            chkSettingsDownloadsKeepOriginalFilesHint = "chkSettingsDownloadsKeepOriginalFilesHint";
            chkSettingsDownloadsSaveAnnotationsHint = "chkSettingsDownloadsSaveAnnotationsHint";
            chkSettingsDownloadsSaveThumbnailsHint = "chkSettingsDownloadsSaveThumbnailsHint";
            chkSettingsDownloadsEmbedThumbnailsHint = "chkSettingsDownloadsEmbedThumbnailsHint";
            chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = "chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint";
            chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = "chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint";
            chkSettingsDownloadsSeparateIntoWebsiteUrlHint = "chkSettingsDownloadsSeparateIntoWebsiteUrlHint";
            chkSettingsDownloadsFixVReddItHint = "chkSettingsDownloadsFixVReddItHint";
            chkSettingsDownloadsPreferFFmpegHint = "chkSettingsDownloadsPreferFFmpeg";
            chkSettingsDownloadsLimitDownloadHint = "chkSettingsDownloadsLimitDownloadHint";
            numSettingsDownloadsLimitDownloadHint = "numSettingsDownloadsLimitDownloadHint";
            cbSettingsDownloadsLimitDownloadHint = "cbSettingsDownloadsLimitDownloadHint";
            lbSettingsDownloadsRetryAttemptsHint = "lbSettingsDownloadsRetryAttemptsHint";
            numSettingsDownloadsRetryAttemptsHint = "numSettingsDownloadsRetryAttemptsHint";
            chkSettingsDownloadsForceIpv4Hint = "chkSettingsDownloadsForceIpv4Hint";
            chkSettingsDownloadsForceIpv6Hint = "chkSettingsDownloadsForceIpv6Hint";
            chkSettingsDownloadsUseProxyHint = "chkSettingsDownloadsUseProxyHint";
            cbSettingsDownloadsProxyTypeHint = "cbSettingsDownloadsProxyTypeHint";
            txtSettingsDownloadsProxyIpHint = "txtSettingsDownloadsProxyIpHint";
            txtSettingsDownloadsProxyPortHint = "txtSettingsDownloadsProxyPortHint";
            chksettingsDownloadsUseYoutubeDlsUpdaterHint = "chksettingsDownloadsUseYoutubeDlsUpdaterHint";
            cbSettingsDownloadsUpdatingYtdlTypeHint = "cbSettingsDownloadsUpdatingYtdlTypeHint";
            llbSettingsDownloadsYtdlTypeViewRepoHint = "llbSettingsDownloadsYtdlTypeViewRepoHint";
            chkSettingsDownloadsSeparateBatchDownloadsHint = "chkSettingsDownloadsSeparateBatchDownloadsHint";
            chkSettingsDownloadsAddDateToBatchDownloadFoldersHint = "chkSettingsDownloadsAddDateToBatchDownloadFoldersHint";

            chkSettingsConverterClearOutputAfterConvertingHint = "chkSettingsConverterClearOutputAfterConvertingHint";
            chkSettingsConverterDetectOutputFileTypeHint = "chkSettingsConverterDetectOutputFileTypeHint";
            chkSettingsConverterClearInputAfterConvertingHint = "chkSettingsConverterClearInputAfterConvertingHint";
            chkSettingsConverterHideFFmpegCompileInfoHint = "chkSettingsConverterHideFFmpegCompileInfoHint";
            lbSettingsConverterVideoBitrateHint = "lbSettingsConverterVideoBitrateHint";
            lbSettingsConverterVideoPresetHint = "lbSettingsConverterVideoPresetHint";
            lbSettingsConverterVideoProfileHint = "lbSettingsConverterVideoProfileHint";
            lbSettingsConverterVideoCRFHint = "lbSettingsConverterVideoCRFHint";
            chkSettingsConverterVideoFastStartHint = "chkSettingsConverterVideoFastStartHint";
            lbSettingsConverterAudioBitrateHint = "lbSettingsConverterAudioBitrateHint";
            txtSettingsConverterCustomArgumentsHint = "txtSettingsConverterCustomArgumentsHint";

            chkSettingsErrorsShowDetailedErrorsHint = "chkSettingsErrorsShowDetailedErrorsHint";
            chkSettingsErrorsSaveErrorsAsErrorLogHint = "chkSettingsErrorsSaveErrorsAsErrorLogHint";
            chkSettingsErrorsSuppressErrorsHint = "chkSettingsErrorsSuppressErrorsHint";


            // frmSubtitles
            frmSubtitles = "frmSubtitles";
            lbSubtitlesHeader = "lbSubtitlesHeader";
            lbSubtitlesUrl = "lbSubtitlesUrl";
            lbSubtitlesLanguages = "lbSubtitlesLanguages";
            btnSubtitlesAddLanguage = "btnSubtitlesAddLanguage";
            btnSubtitlesClearLanguages = "btnSubtitlesClearLanguages";
            btnSubtitlesDownload = "btnSubtitlesDownload";

            // frmTools
            frmTools = "frmTools";
            btnMiscToolsRemoveAudio = "btnMiscToolsRemoveAudio";
            btnMiscToolsExtractAudio = "btnMiscToolsExtractAudio";
            btnMiscToolsVideoToGif = "btnMiscToolsVideoToGif";

            // frmUpdateAvailable
            frmUpdateAvailable = "frmUpdateAvailable";
            lbUpdateAvailableHeader = "lbUpdateAvailableHeader";
            lbUpdateAvailableUpdateVersion = "lbUpdateAvailableUpdateVersion";
            lbUpdateAvailableCurrentVersion = "lbUpdateAvailableCurrentVersion";
            lbUpdateAvailableChangelog = "lbUpdateAvailableChangelog";
            btnUpdateAvailableSkipVersion = "btnUpdateAvailableSkipVersion";
            btnUpdateAvailableUpdate = "btnUpdateAvailableUpdate";
            btnUpdateAvailableOk = "btnUpdateAvailableOk";
        }
        #endregion

        #region Load Language File
        /// <summary>
        /// Loads the ini file for the Language file, based on the ini structure.
        /// </summary>
        /// <param name="LanguageFile">The string of the location of the language file.</param>
        /// <returns>Returns a boolean based on success.</returns>
        public bool LoadLanguage(string LanguageFile = null) {
            try {
                if (string.IsNullOrWhiteSpace(LanguageFile)) {
                    if (Properties.Settings.Default.SkipInternalEnglish) {
                        ResetControlNames();
                    }
                    else {
                        LoadInternalEnglish();
                    }
                    return true;
                }
                else {
                    ResetControlNames(); // Load the control IDs for any untranslated & undocumented strings

                    if (!LanguageFile.EndsWith(".ini")) { LanguageFile += ".ini"; }

                    if (System.IO.File.Exists(LanguageFile)) {
                        string[] ReadFile = System.IO.File.ReadAllLines(LanguageFile);

                        string ReadLine;    // The line of the file
                        string ReadHeader;  // The current section based on the header
                        string ReadControl; // The name of the control
                        string ReadValue;   // The value of the control

                        for (int i = 0; i < ReadFile.Length; i++) {
                            ReadLine = ReadFile[i].Trim(' ');

                            if (ReadLine.StartsWith("//") || string.IsNullOrWhiteSpace(ReadFile[i])) {
                                continue;
                            }
                            else if (ReadLine.StartsWith("[")) {
                                ReadHeader = ReadHeaderValue(ReadLine);

                                if (ReadHeader == null) {
                                    throw new Exception("Unable to read the language ini header\nReadValue returned null.\nProblematic line is \"" + ReadLine + "\"\n\n");
                                }
                                else {
                                    CurrentLanguageLong = ReadHeader;
                                    continue;
                                }
                            }
                            else if (ReadLine.Contains("=")) {
                                ReadControl = GetControlName(ReadLine).ToLower();
                                ReadValue = GetControlValue(ReadLine);
                            }
                            else { continue; }

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
                                case "btnbatchdownloadadd":
                                    btnBatchDownloadAdd = ReadValue;
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
                                case "btnbatchdownloadremoveselected":
                                    btnBatchDownloadRemoveSelected = ReadValue;
                                    continue;
                                case "btnbatchdownloadstart":
                                    btnBatchDownloadStart = ReadValue;
                                    continue;
                                case "btnbatchdownloadstop":
                                    btnBatchDownloadStop = ReadValue;
                                    continue;
                                case "btnbatchdownloadexit":
                                    btnBatchDownloadExit = ReadValue;
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
                                case "btndownloaderexit":
                                    btnDownloaderExit = ReadValue;
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
                                case "btnexceptionok":
                                    btnExceptionOk = ReadValue;
                                    continue;
                                #endregion

                                #region frmLanguage
                                case "frmlanguage":
                                    frmLanguage = ReadValue;
                                    continue;
                                case "btnlanguagerefresh":
                                    btnLanguageRefresh = ReadValue;
                                    continue;
                                case "btnlanguagecancel":
                                    btnLanguageCancel = ReadValue;
                                    continue;
                                case "btnlanguagesave":
                                    btnLanguageSave = ReadValue;
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
                                case "mdownloadsubtitles":
                                    mDownloadSubtitles = ReadValue;
                                    continue;
                                case "mmisctools":
                                    mMiscTools = ReadValue;
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
                                case "chkdownloadsound":
                                    chkDownloadSound = ReadValue;
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
                                    lbDownloadStatusStarted = ReadValue;
                                    continue;
                                case "txtvideodatehint":
                                    txtVideoDateHint = ReadValue;
                                    continue;
                                case "lbcustomarguments":
                                    lbCustomArguments = ReadValue;
                                    continue;
                                case "txtargshint":
                                    txtArgsHint = ReadValue;
                                    continue;
                                case "sbdownload":
                                    sbDownload = ReadValue;
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
                                case "lbdownloadstatusstarted":
                                    lbDownloadStatusStarted = ReadValue;
                                    continue;
                                case "lbdownloadstatuserror":
                                    lbDownloadStatusError = ReadValue;
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
                                case "lbconvertstarted":
                                    lbConvertStarted = ReadValue;
                                    continue;
                                case "lbconvertfailed":
                                    lbConvertFailed = ReadValue;
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
                                // frmSettings
                                case "frmsettings":
                                    frmSettings = ReadValue;
                                    continue;
                                case "btnsettingsredownloadyoutubedl":
                                    btnSettingsRedownloadYoutubeDl = ReadValue;
                                    continue;
                                case "btnsettingssave":
                                    btnSettingsSave = ReadValue;
                                    continue;
                                case "btnsettingsredownloadyoutubedlhint":
                                    btnSettingsRedownloadYoutubeDlHint = ReadValue;
                                    continue;
                                case "btnsettingscancelhint":
                                    btnSettingsCancelHint = ReadValue;
                                    continue;
                                case "btnsettingssavehint":
                                    btnSettingsSaveHint = ReadValue;
                                    continue;

                                // frmSettings / tcMain
                                case "tabsettingsgeneral":
                                    tabSettingsGeneral = ReadValue;
                                    continue;
                                case "tabsettingsdownloads":
                                    tabSettingsDownloads = ReadValue;
                                    continue;
                                case "tabsettingsconverter":
                                    tabSettingsConverter = ReadValue;
                                    continue;
                                case "tabsettingsextensions":
                                    tabSettingsExtensions = ReadValue;
                                    continue;
                                case "tabsettingserrors":
                                    tabSettingsErrors = ReadValue;
                                    continue;

                                case "tabsettingsportable":
                                    tabSettingsPortable = ReadValue;
                                    continue;

                                //frmSettings / tcMain / tabGeneral
                                case "lbsettingsgeneralyoutubedlpath":
                                    lbSettingsGeneralYoutubeDlPath = ReadValue;
                                    continue;
                                case "chksettingsgeneralusestaticyoutubedl":
                                    chkSettingsGeneralUseStaticYoutubeDl = ReadValue;
                                    continue;
                                case "ofdtitleYoutubedl":
                                    ofdTitleYoutubeDl = ReadValue;
                                    continue;
                                case "ofdfilteryoutubedl":
                                    ofdFilterYoutubeDl = ReadValue;
                                    continue;
                                case "lbsettingsgeneralffmpegdirectory":
                                    lbSettingsGeneralFFmpegDirectory = ReadValue;
                                    continue;
                                case "chksettingsgeneralusestaticffmpeg":
                                    chkSettingsGeneralUseStaticFFmpeg = ReadValue;
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
                                case "chksettingsgeneralcheckforbetaupdates":
                                    chkSettingsGeneralCheckForBetaUpdates = ReadValue;
                                    continue;
                                case "chksettingsgeneralhoveroverurltopasteclipboard":
                                    chkSettingsGeneralHoverOverUrlToPasteClipboard = ReadValue;
                                    continue;
                                case "chksettingsgeneralclearurlondownload":
                                    chkSettingsGeneralClearUrlOnDownload = ReadValue;
                                    continue;
                                case "chksettingsgeneralclearclipboardondownload":
                                    chkSettingsGeneralClearClipboardOnDownload = ReadValue;
                                    continue;
                                case "gbsettingsgeneralcustomarguments":
                                    gbSettingsGeneralCustomArguments = ReadValue;
                                    continue;
                                case "rbsettingsgeneralcustomargumentsdontsave":
                                    rbSettingsGeneralCustomArgumentsDontSave = ReadValue;
                                    continue;
                                case "rbsettingsgeneralcustomargumentssaveasargstext":
                                    rbSettingsGeneralCustomArgumentsSaveAsArgsText = ReadValue;
                                    continue;
                                case "rbsettingsgeneralcustomargumentssaveinsettings":
                                    rbSettingsGeneralCustomArgumentsSaveInSettings = ReadValue;
                                    continue;
                                case "lbsettingsgeneralyoutubedlpathhint":
                                    lbSettingsGeneralYoutubeDlPathHint = ReadValue;
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
                                case "lbsettingsgeneralffmpegdirectoryhint":
                                    lbSettingsGeneralFFmpegDirectoryHint = ReadValue;
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
                                case "chksettingsgeneralcheckforupdatesonlaunchhint":
                                    chkSettingsGeneralCheckForUpdatesOnLaunchHint = ReadValue;
                                    continue;
                                case "chksettingsgeneralcheckforbetaupdateshint":
                                    chkSettingsGeneralCheckForBetaUpdatesHint = ReadValue;
                                    continue;
                                case "chksettingsgeneralhoveroverurltopasteclipboardhint":
                                    chkSettingsGeneralHoverOverUrlToPasteClipboardHint = ReadValue;
                                    continue;
                                case "chksettingsgeneralclearurlondownloadhint":
                                    chkSettingsGeneralClearUrlOnDownloadHint = ReadValue;
                                    continue;
                                case "chksettingsgeneralclearclipboardondownloadhint":
                                    chkSettingsGeneralClearClipboardOnDownloadHint = ReadValue;
                                    continue;
                                case "gbsettingsgeneralcustomargumentshint":
                                    gbSettingsGeneralCustomArgumentsHint = ReadValue;
                                    continue;
                                case "rbsettingsgeneralcustomargumentsdontsavehint":
                                    rbSettingsGeneralCustomArgumentsDontSaveHint = ReadValue;
                                    continue;
                                case "rbsettingsgeneralcustomargumentssaveasargstexthint":
                                    rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = ReadValue;
                                    continue;
                                case "rbsettingsgeneralcustomargumentssaveinsettingshint":
                                    rbSettingsGeneralCustomArgumentsSaveInSettingsHint = ReadValue;
                                    continue;

                                // frmSettings / tcMain / tabDownloads
                                case "lbsettingsdownloadsdownloadpath":
                                    lbSettingsDownloadsDownloadPath = ReadValue;
                                    continue;
                                case "lbsettingsdownloadsfilenameschema":
                                    lbSettingsDownloadsFileNameSchema = ReadValue;
                                    continue;
                                case "tabdownloadsgeneral":
                                    tabDownloadsGeneral = ReadValue;
                                    continue;
                                case "tabdownloadssorting":
                                    tabDownloadsSorting = ReadValue;
                                    continue;
                                case "tabdownloadsfixes":
                                    tabDownloadsFixes = ReadValue;
                                    continue;
                                case "tabdownloadsconnection":
                                    tabDownloadsConnection = ReadValue;
                                    continue;
                                case "tabdownloadsupdating":
                                    tabDownloadsUpdating = ReadValue;
                                    continue;
                                case "chksettingsdownloadssaveformatquality":
                                    chkSettingsDownloadsSaveFormatQuality = ReadValue;
                                    continue;
                                case "chksettingsdownloadsdownloadsubtitles":
                                    chkSettingsDownloadsDownloadSubtitles = ReadValue;
                                    continue;
                                case "chksettingsdownloadsembedsubtitles":
                                    chkSettingsDownloadsEmbedSubtitles = ReadValue;
                                    continue;
                                case "chksettingsdownloadssavevideoinfo":
                                    chkSettingsDownloadsSaveVideoInfo = ReadValue;
                                    continue;
                                case "chksettingsdownloadswritemetadatatofile":
                                    chkSettingsDownloadsWriteMetadataToFile = ReadValue;
                                    continue;
                                case "chksettingsdownloadssavedescription":
                                    chkSettingsDownloadsSaveDescription = ReadValue;
                                    continue;
                                case "chksettingsdownloadskeeporiginalfiles":
                                    chkSettingsDownloadsKeepOriginalFiles = ReadValue;
                                    continue;
                                case "chksettingsdownloadssaveannotations":
                                    chkSettingsDownloadsSaveAnnotations = ReadValue;
                                    continue;
                                case "chksettingsdownloadssavethumbnails":
                                    chkSettingsDownloadsSaveThumbnails = ReadValue;
                                    continue;
                                case "chksettingsdownloadsembedthumbnails":
                                    chkSettingsDownloadsEmbedThumbnails = ReadValue;
                                    continue;
                                case "chksettingsdownloadsautomaticallydeleteyoutubedlwhenclosing":
                                    chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = ReadValue;
                                    continue;
                                case "chksettingsdownloadsseparatedownloadstodifferentfolders":
                                    chkSettingsDownloadsSeparateDownloadsToDifferentFolders = ReadValue;
                                    continue;
                                case "chksettingsdownloadsseparateintowebsiteurl":
                                    chkSettingsDownloadsSeparateIntoWebsiteUrl = ReadValue;
                                    continue;
                                case "chksettingsdownloadsfixvreddit":
                                    chkSettingsDownloadsFixVReddIt = ReadValue;
                                    continue;
                                case "chksettingsdownloadspreferffmpeg":
                                    chkSettingsDownloadsPreferFFmpeg = ReadValue;
                                    continue;
                                case "chksettingsdownloadslimitdownload":
                                    chkSettingsDownloadsLimitDownload = ReadValue;
                                    continue;
                                case "lbsettingsdownloadsretryattempts":
                                    lbSettingsDownloadsRetryAttempts = ReadValue;
                                    continue;
                                case "chksettingsdownloadsforceipv4":
                                    chkSettingsDownloadsForceIpv4 = ReadValue;
                                    continue;
                                case "chksettingsdownloadsforceipv6":
                                    chkSettingsDownloadsForceIpv6 = ReadValue;
                                    continue;
                                case "chksettingsdownloadsuseproxy":
                                    chkSettingsDownloadsUseProxy = ReadValue;
                                    continue;
                                case "chksettingsdownloadsuseyoutubedlsupdater":
                                    chkSettingsDownloadsUseYoutubeDlsUpdater = ReadValue;
                                    continue;
                                case "lbsettingsdownloadsupdatingytdltype":
                                    lbSettingsDownloadsUpdatingYtdlType = ReadValue;
                                    continue;
                                case "llbsettingsdownloadsytdltypeviewrepo":
                                    llbSettingsDownloadsYtdlTypeViewRepo = ReadValue;
                                    continue;
                                case "chksettingsdownloadsseparatebatchdownloads":
                                    chkSettingsDownloadsSeparateBatchDownloads = ReadValue;
                                    continue;
                                case "chksettingsdownloadsadddatetobatchdownloadfolders":
                                    chkSettingsDownloadsAddDateToBatchDownloadFolders = ReadValue;
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
                                case "llsettingsdownloadsschemahelphint":
                                    llSettingsDownloadsSchemaHelpHint = ReadValue;
                                    continue;
                                case "lbsettingsdownloadsfilenameschemahint":
                                    lbSettingsDownloadsFileNameSchemaHint = ReadValue;
                                    continue;
                                case "txtsettingsdownloadsfilenameschemahint":
                                    txtSettingsDownloadsFileNameSchemaHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadssaveformatqualityhint":
                                    chkSettingsDownloadsSaveFormatQualityHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadsdownloadsubtitleshint":
                                    chkSettingsDownloadsDownloadSubtitlesHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadsembedsubtitleshint":
                                    chkSettingsDownloadsEmbedSubtitlesHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadssavevideoinfohint":
                                    chkSettingsDownloadsSaveVideoInfoHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadswritemetadatatofilehint":
                                    chkSettingsDownloadsWriteMetadataToFileHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadssavedescriptionhint":
                                    chkSettingsDownloadsSaveDescriptionHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadskeeporiginalfileshint":
                                    chkSettingsDownloadsKeepOriginalFilesHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadssaveannotationshint":
                                    chkSettingsDownloadsSaveAnnotationsHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadssavethumbnailshint":
                                    chkSettingsDownloadsSaveThumbnailsHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadsembedthumbnailshint":
                                    chkSettingsDownloadsEmbedThumbnailsHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadsautomaticallydeleteyoutubedlwhenclosinghint":
                                    chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadsseparatedownloadstodifferentfoldershint":
                                    chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadsseparateintowebsiteurlhint":
                                    chkSettingsDownloadsSeparateIntoWebsiteUrlHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadsfixvreddithint":
                                    chkSettingsDownloadsFixVReddItHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadspreferffmpeghint":
                                    chkSettingsDownloadsPreferFFmpegHint = ReadValue;
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
                                case "lbsettingsdownloadsretryattemptshint":
                                    lbSettingsDownloadsRetryAttemptsHint = ReadValue;
                                    continue;
                                case "numsettingsdownloadsretryattemptshint":
                                    numSettingsDownloadsRetryAttemptsHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadsforceipv4hint":
                                    chkSettingsDownloadsForceIpv4Hint = ReadValue;
                                    continue;
                                case "chksettingsdownloadsforceipv6hint":
                                    chkSettingsDownloadsForceIpv6Hint = ReadValue;
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
                                case "chksettingsdownloadsuseyoutubedlsupdaterhint":
                                    chksettingsDownloadsUseYoutubeDlsUpdaterHint = ReadValue;
                                    continue;
                                case "cbsettingsdownloadsupdatingytdltypehint":
                                    cbSettingsDownloadsUpdatingYtdlTypeHint = ReadValue;
                                    continue;
                                case "llbsettingsdownloadsytdltypeviewrepohint":
                                    llbSettingsDownloadsYtdlTypeViewRepoHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadsseparatebatchdownloadshint":
                                    chkSettingsDownloadsSeparateBatchDownloadsHint = ReadValue;
                                    continue;
                                case "chksettingsdownloadsadddatetobatchdownloadfoldershint":
                                    chkSettingsDownloadsAddDateToBatchDownloadFoldersHint = ReadValue;
                                    continue;

                                // frmSettings / tcMain / tabConverter
                                case "chksettingsconverterclearoutputafterconverting":
                                    chkSettingsConverterClearOutputAfterConverting = ReadValue;
                                    continue;
                                case "chksettingsconverterdetectoutputfiletype":
                                    chkSettingsConverterDetectOutputFileType = ReadValue;
                                    continue;
                                case "chksettingsconverterclearinputafterconverting":
                                    chkSettingsConverterClearInputAfterConverting = ReadValue;
                                    continue;
                                case "chksettingsconverterhideffmpegcompileinfo":
                                    chkSettingsConverterHideFFmpegCompileInfo = ReadValue;
                                    continue;
                                case "tcsettingsconvertervideo":
                                    tcSettingsConverterVideo = ReadValue;
                                    continue;
                                case "tcsettingsconverteraudio":
                                    tcSettingsConverterAudio = ReadValue;
                                    continue;
                                case "tcsettingsconvertercustom":
                                    tcSettingsConverterCustom = ReadValue;
                                    continue;
                                case "lbsettingsconvertervideobitrate":
                                    lbSettingsConverterVideoBitrate = ReadValue;
                                    continue;
                                case "lbsettingsconvertervideopreset":
                                    lbSettingsConverterVideoPreset = ReadValue;
                                    continue;
                                case "lbsettingsconvertervideoprofile":
                                    lbSettingsConverterVideoProfile = ReadValue;
                                    continue;
                                case "lbsettingsconvertervideocrf":
                                    lbSettingsConverterVideoCRF = ReadValue;
                                    continue;
                                case "chksettingsconvertervideofaststart":
                                    chkSettingsConverterVideoFastStart = ReadValue;
                                    continue;
                                case "lbsettingsconverteraudiobitrate":
                                    lbSettingsConverterAudioBitrate = ReadValue;
                                    continue;
                                case "lbsettingsconvertercustomheader":
                                    lbSettingsConverterCustomHeader = ReadValue;
                                    continue;
                                case "chksettingsconverterclearoutputafterconvertinghint":
                                    chkSettingsConverterClearOutputAfterConvertingHint = ReadValue;
                                    continue;
                                case "chksettingsconverterdetectoutputfiletypehint":
                                    chkSettingsConverterDetectOutputFileTypeHint = ReadValue;
                                    continue;
                                case "chksettingsconverterclearinputafterconvertinghint":
                                    chkSettingsConverterClearInputAfterConvertingHint = ReadValue;
                                    continue;
                                case "chksettingsconverterhideffmpegcompileinfohint":
                                    chkSettingsConverterHideFFmpegCompileInfoHint = ReadValue;
                                    continue;
                                case "lbsettingsconvertervideobitratehint":
                                    lbSettingsConverterVideoBitrateHint = ReadValue;
                                    continue;
                                case "lbsettingsconvertervideopresethint":
                                    lbSettingsConverterVideoPresetHint = ReadValue;
                                    continue;
                                case "lbsettingsconvertervideoprofilehint":
                                    lbSettingsConverterVideoProfileHint = ReadValue;
                                    continue;
                                case "lbsettingsconvertervideocrfhint":
                                    lbSettingsConverterVideoCRFHint = ReadValue;
                                    continue;
                                case "chksettingsconvertervideofaststarthint":
                                    chkSettingsConverterVideoFastStartHint = ReadValue;
                                    continue;
                                case "lbsettingsconverteraudiobitratehint":
                                    lbSettingsConverterAudioBitrateHint = ReadValue;
                                    continue;
                                case "txtsettingsconvertercustomargumentshint":
                                    txtSettingsConverterCustomArgumentsHint = ReadValue;
                                    continue;

                                // frmSettings / tcMain / tabExtensions
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

                                // frmSettings / tcMain / tabErrors
                                case "chksettingserrorsshowdetailederrors":
                                    chkSettingsErrorsShowDetailedErrors = ReadValue;
                                    continue;
                                case "chksettingserrorssaveerrorsaserrorlog":
                                    chkSettingsErrorsSaveErrorsAsErrorLog = ReadValue;
                                    continue;
                                case "chksettingserrorssuppresserrors":
                                    chkSettingsErrorsSuppressErrors = ReadValue;
                                    continue;
                                case "chksettingserrorsshowdetailederrorshint":
                                    chkSettingsErrorsShowDetailedErrorsHint = ReadValue;
                                    continue;
                                case "chksettingserrorssaveerrorsaserrorloghint":
                                    chkSettingsErrorsSaveErrorsAsErrorLogHint = ReadValue;
                                    continue;
                                case "chksettingserrorssuppresserrorshint":
                                    chkSettingsErrorsSuppressErrorsHint = ReadValue;
                                    continue;

                                // frmSettings /tcMain /tabSettingsPortable
                                case "lbsettingsportableinformation":
                                    lbSettingsPortableInformation = ReadValue;
                                    continue;

                                case "chksettingsportabletoggleini":
                                    chkSettingsPortableToggleIni = ReadValue;
                                    continue;
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
                                    btnMiscToolsExtractAudioString = ReadValue;
                                    continue;
                                case "btnmisctoolsvideotogif":
                                    btnMiscToolsVideoToGifString = ReadValue;
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
                                case "btnupdateavailableskipversion":
                                    btnUpdateAvailableSkipVersion = ReadValue;
                                    continue;
                                case "btnupdateavailableupdate":
                                    btnUpdateAvailableUpdate = ReadValue;
                                    continue;
                                case "btnupdateavailableok":
                                    btnUpdateAvailableOk = ReadValue;
                                    continue;
                                #endregion

                            }
                        }

                        return true;
                    }
                    else {
                        throw new Exception("LangaugeFile does not exist.");
                    }
                }
            }
            catch (Exception ex) {
                using (frmException error = new frmException()) {
                    error.ReportedException = ex;
                    error.FromLanguage = true;
                    error.ShowDialog();
                }
                return false;
            }
        }

        /// <summary>
        /// Parses the header value from a string.
        /// </summary>
        /// <param name="Input">The string that may contain a header.</param>
        /// <returns>Returns the absolute header.</returns>
        private string ReadHeaderValue(string Input) {
            string ReadValue = null;
            int CountedLength = 0;
            ReadValue = Input.Trim(' ');
            if (Input.Contains("//")) {
                ReadValue = Input.Substring(0, Input.IndexOf("//")).Trim(' ');
            }

            if (ReadValue.Trim(' ').Trim('[').Trim(']') == null) {
                throw new Exception("Unable to read the language ini header\nReadValue returned null.\nProblematic line is \"" + Input + "\" on line " + CountedLength.ToString() + "\n\n");
            }

            return ReadValue.Trim(' ').Trim('[').Trim(']').Trim(' ');
        }
        /// <summary>
        /// Parses the control name from a string.
        /// </summary>
        /// <param name="Input">The string that may contain a control name.</param>
        /// <returns>Returns the absolute control name.</returns>
        private string GetControlName(string Input) {

            switch (Input.Split('=').Length) {
                case 1: case 0: case -1:
                    return null;

                default:
                    return Input.Split('=')[0].Trim(' ');
            }

            //if (Input.Split('=').Length > 1) {
            //    return Input.Split('=')[0].Trim(' ');
            //}
            //else { return null; }
        }
        /// <summary>
        /// Parses the control value from a string.
        /// </summary>
        /// <param name="Input">The string that may contain a control value.</param>
        /// <returns>Returns the absolute conntrol value.</returns>
        private string GetControlValue(string Input) {
            string OutputBuffer = null;

            switch (Input.Contains("//")) {
                case true:
                    OutputBuffer = Input.Substring(0, Input.IndexOf("//")).Trim(' ');
                    break;

                case false:
                    OutputBuffer = Input;
                    break;
            }

            return OutputBuffer.Substring(OutputBuffer.IndexOf('=') + 1);
        }
        #endregion

    }
}