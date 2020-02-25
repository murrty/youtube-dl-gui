using System;

namespace youtube_dl_gui {
    public class Language {
        #region Variables
        private static volatile Language LangInstance = new Language();
        private static volatile string LoadedFileString = null;

        #region Language identifier
        // Language identifier
        private static volatile string CurrentLanguageLongString = "CurrentLanguageLong";
        private static volatile string CurrentLanguageShortString = "CurrentLanguageShort";
        private static volatile string CurrentLanguageHintString = "CurrentLanguageHint";
        private static volatile string CurrentLanguageVersionString = "1";
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
        private static volatile string btnDownloaderCancelString = "btnDownloaderCancelExit";
        private static volatile string btnDownloaderExitString = "btnDownloaderCancelExit";
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
        // frmMain / tcMain / Download (12 total)
        private static volatile string lbURLString = "lbURL";
        private static volatile string txtUrlHintString = "txtUrlHint";
        private static volatile string gbDownloadTypeString = "gbDownloadType";
        private static volatile string rbVideoString = "rbVideo";
        private static volatile string rbAudioString = "rbAudio";
        private static volatile string rbCustomString = "rbCustom";
        private static volatile string lbQualityString = "lbQuality";
        private static volatile string chkDownloadSoundString = "chkDownloadSound";
        private static volatile string lbCustomArgumentsString = "lbCustomArguments";
        private static volatile string txtArgsHintString = "txtArgsHint";
        private static volatile string sbDownloadString = "sbDownload";
        private static volatile string mBatchDownloadFromFileString = "mBatchDownloadFromFile";
        private static volatile string lbDownloadStatusStartedString = "lbDownloadStatusStarted";
        private static volatile string lbDownloadStatusErrorString = "lbDownloadStatusError";
        // frmMain / tcMain / Convert (9 total)
        private static volatile string lbConvertInputString = "lbConvertInput";
        private static volatile string lbConvertOutputString = "lbConvertOutput";
        private static volatile string rbConvertVideoString = "rbConvertVideo";
        private static volatile string rbConvertAudioString = "rbConvertAudio";
        private static volatile string rbConvertCustomString = "rbConvertCustom";
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
        private static volatile string btnSettingsRedownloadYoutubeDlString = "btnSettingsRedownloadYoutubeDl";
        private static volatile string btnSettingsCancelString = "btnSettingsCancel";
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
        private static volatile string lbSettingsGeneralFFmpegDirectoryString = "lbSettingsGeneralFFmpegDirectory";
        private static volatile string chkSettingsGeneralUseStaticFFmpegString = "chkSettingsGeneralUseStaticFFmpeg";
        private static volatile string chkSettingsGeneralCheckForUpdatesOnLaunchString = "chkSettingsGeneralCheckForUpdatesOnLaunch";
        private static volatile string chkSettingsGeneralHoverOverUrlToPasteClipboardString = "chkSettingsGeneralHoverOverUrlToPasteClipboard";
        private static volatile string chkSettingsGeneralClearUrlClipboardOnDownloadString = "chkSettingsGeneralClearUrlClipboardOnDownload";
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
        private static volatile string chkSettingsDownloadsLimitDownloadString = "chkSettingsDownloadsLimitDownload";
        private static volatile string lbSettingsDownloadsRetryAttemptsString = "lbSettingsDownloadsRetryAttempts";
        private static volatile string chkSettingsDownloadsForceIpv4String = "chkSettingsDownloadsForceIpv4";
        private static volatile string chkSettingsDownloadsForceIpv6String = "chkSettingsDownloadsForceIpv6";
        private static volatile string chkSettingsDownloadsUseProxyString = "chkSettingsDownloadsUseProxy";


        private static volatile string chksettingsDownloadsUseYoutubeDlsUpdaterString = "chksettingsDownloadsUseYoutubeDlsUpdater";
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
        private static volatile string chkSettingsGeneralHoverOverUrlToPasteClipboardHintString = "chkSettingsGeneralHoverOverUrlToPasteClipboardHint";
        private static volatile string chkSettingsGeneralClearUrlClipboardOnDownloadHintString = "chkSettingsGeneralClearUrlClipboardOnDownloadHint";
        private static volatile string gbSettingsGeneralCustomArgumentsHintString = "gbSettingsGeneralCustomArgumentsHint";
        private static volatile string rbSettingsGeneralCustomArgumentsDontSaveHintString = "rbSettingsGeneralCustomArgumentsDontSaveHint";
        private static volatile string rbSettingsGeneralCustomArgumentsSaveAsArgsTextHintString = "rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint";
        private static volatile string rbSettingsGeneralCustomArgumentsSaveInSettingsHintString = "rbSettingsGeneralCustomArgumentsSaveInSettingsHint";
        #endregion
        #region tabDownloads
        private static volatile string lbSettingsDownloadsDownloadPathHintString = "lbSettingsDownloadsDownloadPathHint";
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
        public string btnBatchDownloadStart  {
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
            private set { }
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
            get { return frmDownloaderString; }
            private set { frmDownloaderErrorString = value; }
        }
        public string chkDownloaderCloseAfterDownload {
            get { return chkDownloaderCloseAfterDownloadString; }
            private set { chkDownloaderCloseAfterDownloadString = value; }
        }
        public string btnDownloaderCancel {
            get { return btnDownloaderCancelString; }
            private set { btnDownloaderCancelString = value; }
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
            private set{ mSettingsString = value; }
        }
        public string mTools {
            get { return mToolsString; }
            private set{ mToolsString = value; }
        }
        public string mBatchDownload {
            get { return mBatchDownloadString; }
            private set{ mBatchDownloadString = value; }
        }
        public string mDownloadSubtitles {
            get { return mDownloadSubtitlesString; }
            private set{ mDownloadSubtitlesString = value; }
        }
        public string mMiscTools {
            get { return mMiscToolsString; }
            private set{ mMiscToolsString = value; }
        }
        public string mHelp {
            get { return mHelpString; }
            private set{ mHelpString = value; }
        }
        public string mLanguage {
            get { return mLanguageString; }
            private set{ mLanguageString = value; }
        }
        public string mSupportedSites {
            get { return mSupportedSitesString; }
            private set{ mSupportedSitesString = value; }
        }
        public string mAbout {
            get { return mAboutString; }
            private set{ mAboutString = value; }
        }

        public string tabDownload {
            get { return tabDownloadString; }
            private set{ tabDownloadString = value; }
        }
        public string tabConvert {
            get { return tabConvertString; }
            private set{ tabConvertString = value; }
        }
        public string tabMerge {
            get { return tabMergeString; }
            private set{ tabMergeString = value; }
        }

        public string lbURL {
            get { return lbURLString; }
            private set{ lbURLString = value; }
        }
        public string txtUrlHint {
            get { return txtUrlHintString; }
            private set{ txtUrlHintString = value; }
        }
        public string gbDownloadType {
            get { return gbDownloadTypeString; }
            private set{ gbDownloadTypeString = value; }
        }
        public string rbVideo {
            get { return rbVideoString; }
            private set{ rbVideoString = value; }
        }
        public string rbAudio {
            get { return rbAudioString; }
            private set{ rbAudioString = value; }
        }
		public string rbCustom {
            get { return rbCustomString; }
            private set{ rbCustomString = value; }
        }
        public string lbQuality {
            get { return lbQualityString; }
            private set{ lbQualityString = value; }
        }
        public string chkDownloadSound {
            get { return chkDownloadSoundString; }
            private set{ chkDownloadSoundString = value; }
        }
        public string lbCustomArguments {
            get { return lbCustomArgumentsString; }
            private set{ lbCustomArgumentsString = value; }
        }
        public string txtArgsHint {
            get { return txtArgsHintString; }
            private set{ txtArgsHintString = value; }
        }
        public string sbDownload {
            get { return sbDownloadString; }
            private set{ sbDownloadString = value; }
        }
        public string mBatchDownloadFromFile {
            get { return mBatchDownloadFromFileString; }
            private set{ mBatchDownloadFromFileString = value; }
        }
        public string lbDownloadStatusStarted {
            get { return lbDownloadStatusStartedString; }
            private set{ lbDownloadStatusStartedString = value; }
        }
        public string lbDownloadStatusError {
            get { return lbDownloadStatusErrorString; }
            private set{ lbDownloadStatusErrorString = value; }
        }

        public string lbConvertInput {
            get { return lbConvertInputString; }
            private set{ lbConvertInputString = value; }
        }
        public string lbConvertOutput {
            get { return lbConvertOutputString; }
            private set{ lbConvertOutputString = value; }
        }
        public string rbConvertVideo {
            get { return rbConvertVideoString; }
            private set{ rbConvertVideoString = value; }
        }
        public string rbConvertAudio {
            get { return rbConvertAudioString; }
            private set { rbConvertAudioString = value; }
        }
        public string rbConvertCustom {
            get { return rbConvertCustomString; }
            private set{ rbConvertCustomString = value; }
        }
        public string rbConvertAuto {
            get { return rbConvertAutoString; }
            private set{ rbConvertAutoString = value; }
        }
        public string rbConvertAutoFFmpeg {
            get { return rbConvertAutoFFmpegString; }
            private set{ rbConvertAutoFFmpegString = value; }
        }
        public string btnConvert {
            get { return btnConvertString; }
            private set{ btnConvertString = value; }
        }
        public string lbConvertStarted {
            get { return lbConvertStartedString; }
            private set{ lbConvertStartedString = value; }
        }
        public string lbConvertFailed {
            get { return lbConvertFailedString; }
            private set{ lbConvertFailedString = value; }
        }

        public string lbMergeInput1 {
            get { return lbMergeInput1String; }
            private set{ lbMergeInput1String = value; }
        }
        public string lbMergeInput2 {
            get { return lbMergeInput2String; }
            private set{ lbMergeInput2String = value; }
        }
        public string lbMergeOutput {
            get { return lbMergeOutputString; }
            private set{ lbMergeOutputString = value; }
        }
        public string chkMergeAudioTracks {
            get { return chkMergeAudioTracksString; }
            private set{ chkMergeAudioTracksString = value; }
        }
        public string chkMergeDeleteInputFiles {
            get { return chkMergeDeleteInputFilesString; }
            private set{ chkMergeDeleteInputFilesString = value; }
        }
        public string btnMerge {
            get { return btnMergeString; }
            private set{ btnMergeString = value; }
        }

        public string cmTrayShowForm {
            get { return cmTrayShowFormString; }
            private set{ cmTrayShowFormString = value; }
        }
        public string cmTrayDownloader {
            get { return cmTrayDownloaderString; }
            private set{ cmTrayDownloaderString = value; }
        }
        public string cmTrayDownloadClipboard {
            get { return cmTrayDownloadClipboardString; }
            private set{ cmTrayDownloadClipboardString = value; }
        }
        public string cmTrayDownloadBestVideo {
            get { return cmTrayDownloadBestVideoString; }
            private set{ cmTrayDownloadBestVideoString = value; }
        }
        public string cmTrayDownloadBestAudio {
            get { return cmTrayDownloadBestAudioString; }
            private set{ cmTrayDownloadBestAudioString = value; }
        }
        public string cmTrayDownloadCustom {
            get { return cmTrayDownloadCustomString; }
            private set{ cmTrayDownloadCustomString = value; }
        }
        public string cmTrayDownloadCustomTxtBox {
            get { return cmTrayDownloadCustomTxtBoxString; }
            private set{ cmTrayDownloadCustomTxtBoxString = value; }
        }
        public string cmTrayDownloadCustomTxt {
            get { return cmTrayDownloadCustomTxtString; }
            private set{ cmTrayDownloadCustomTxtString = value; }
        }
        public string cmTrayDownloadCustomSettings {
            get { return cmTrayDownloadCustomSettingsString; }
            private set{ cmTrayDownloadCustomSettingsString = value; }
        }
        public string cmTrayConverter {
            get { return cmTrayConverterString; }
            private set{ cmTrayConverterString = value; }
        }
        public string cmTrayConvertTo {
            get { return cmTrayConvertToString; }
            private set{ cmTrayConvertToString = value; }
        }
        public string cmTrayConvertVideo {
            get { return cmTrayConvertVideoString; }
            private set{ cmTrayConvertVideoString = value; }
        }
        public string cmTrayConvertAudio {
            get { return cmTrayConvertAudioString; }
            private set{ cmTrayConvertAudioString = value; }
        }
        public string cmTrayConvertCustom {
            get { return cmTrayConvertCustomString; }
            private set{ cmTrayConvertCustomString = value; }
        }
        public string cmTrayConvertAutomatic {
            get { return cmTrayConvertAutomaticString; }
            private set{ cmTrayConvertAutomaticString = value; }
        }
        public string cmTrayConvertAutoFFmpeg {
            get { return cmTrayConvertAutoFFmpegString; }
            private set{ cmTrayConvertAutoFFmpegString = value; }
        }
        public string cmTrayExit {
            get { return cmTrayExitString; }
            private set{ cmTrayExitString = value; }
        }
        #endregion

        #region frmSettings

        #region frmSettings form
        public string btnSettingsRedownloadYoutubeDl {
            get { return btnSettingsRedownloadYoutubeDlString; }
            private set { btnSettingsRedownloadYoutubeDlString = value; }
        }
        public string btnSettingsCancel {
            get { return btnSettingsCancelString; }
            private set { btnSettingsCancelString = value; }
        }
        public string btnSettingsSave {
            get { return btnSettingsSaveString; }
            private set { btnSettingsSaveString = value; }
        }

        public string tabSettingsGeneral {
            get {return tabSettingsGeneralString; }
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

        public string lbSettingsGeneralYoutubeDlPath {
            get { return lbSettingsGeneralYoutubeDlPathString; }
            private set { lbSettingsGeneralYoutubeDlPathString = value; }
        }
        public string chkSettingsGeneralUseStaticYoutubeDl {
            get { return chkSettingsGeneralUseStaticYoutubeDlString; }
            private set { chkSettingsGeneralUseStaticYoutubeDlString = value; }
        }
        public string lbSettingsGeneralFFmpegDirectory {
            get { return lbSettingsGeneralFFmpegDirectoryString; }
            private set { lbSettingsGeneralFFmpegDirectoryString = value; }
        }
        public string chkSettingsGeneralUseStaticFFmpeg {
            get { return chkSettingsGeneralUseStaticFFmpegString; }
            private set { chkSettingsGeneralUseStaticFFmpegString = value; }
        }
        public string chkSettingsGeneralCheckForUpdatesOnLaunch {
            get { return chkSettingsGeneralCheckForUpdatesOnLaunchString; }
            private set { chkSettingsGeneralCheckForUpdatesOnLaunchString = value; }
        }
        public string chkSettingsGeneralHoverOverUrlToPasteClipboard {
            get { return chkSettingsGeneralHoverOverUrlToPasteClipboardString; }
            private set { chkSettingsGeneralHoverOverUrlToPasteClipboardString = value; }
        }
        public string chkSettingsGeneralClearUrlClipboardOnDownload {
            get { return chkSettingsGeneralClearUrlClipboardOnDownloadString; }
            private set { chkSettingsGeneralClearUrlClipboardOnDownloadString = value; }
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
        public string chksettingsDownloadsUseYoutubeDlsUpdater {
            get { return chksettingsDownloadsUseYoutubeDlsUpdaterString; }
            private set { chksettingsDownloadsUseYoutubeDlsUpdaterString = value; }
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

        public string lbSettingsGeneralYoutubeDlPathHint  {
            get { return lbSettingsGeneralYoutubeDlPathHintString; }
            private set { lbSettingsGeneralYoutubeDlPathHintString = value; }
        }
        public string chkSettingsGeneralUseStaticYoutubeDlHint  {
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
        public string lbSettingsGeneralFFmpegDirectoryHint  {
            get { return lbSettingsGeneralFFmpegDirectoryHintString; }
            private set { lbSettingsGeneralFFmpegDirectoryHintString = value; }
        }
        public string chkSettingsGeneralUseStaticFFmpegHint  {
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
        public string chkSettingsGeneralCheckForUpdatesOnLaunchHint  {
            get { return chkSettingsGeneralCheckForUpdatesOnLaunchHintString; }
            private set { chkSettingsGeneralCheckForUpdatesOnLaunchHintString = value; }
        }
        public string chkSettingsGeneralHoverOverUrlToPasteClipboardHint  {
            get { return chkSettingsGeneralHoverOverUrlToPasteClipboardHintString; }
            private set { chkSettingsGeneralHoverOverUrlToPasteClipboardHintString = value; }
        }
        public string chkSettingsGeneralClearUrlClipboardOnDownloadHint  {
            get { return chkSettingsGeneralClearUrlClipboardOnDownloadHintString; }
            private set { chkSettingsGeneralClearUrlClipboardOnDownloadHintString = value; }
        }
        public string gbSettingsGeneralCustomArgumentsHint  {
            get { return gbSettingsGeneralCustomArgumentsHintString; }
            private set { gbSettingsGeneralCustomArgumentsHintString = value; }
        }
        public string rbSettingsGeneralCustomArgumentsDontSaveHint  {
            get { return rbSettingsGeneralCustomArgumentsDontSaveHintString; }
            private set { rbSettingsGeneralCustomArgumentsDontSaveHintString = value; }
        }
        public string rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint  {
            get { return rbSettingsGeneralCustomArgumentsSaveAsArgsTextHintString; }
            private set { rbSettingsGeneralCustomArgumentsSaveAsArgsTextHintString = value; }
        }
        public string rbSettingsGeneralCustomArgumentsSaveInSettingsHint  {
            get { return rbSettingsGeneralCustomArgumentsSaveInSettingsHintString; }
            private set { rbSettingsGeneralCustomArgumentsSaveInSettingsHintString = value; }
        }

        public string lbSettingsDownloadsDownloadPathHint  {
            get { return lbSettingsDownloadsDownloadPathHintString; }
            private set { lbSettingsDownloadsDownloadPathHintString = value; }
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
        public string lbSettingsDownloadsFileNameSchemaHint  {
            get { return lbSettingsDownloadsFileNameSchemaHintString; }
            private set { lbSettingsDownloadsFileNameSchemaHintString = value; }
        }
        public string txtSettingsDownloadsFileNameSchemaHint {
            get { return txtSettingsDownloadsFileNameSchemaHintString; }
            private set { txtSettingsDownloadsFileNameSchemaHintString = value; }
        }
        public string chkSettingsDownloadsSaveFormatQualityHint  {
            get { return chkSettingsDownloadsSaveFormatQualityHintString; }
            private set { chkSettingsDownloadsSaveFormatQualityHintString = value; }
        }
        public string chkSettingsDownloadsDownloadSubtitlesHint  {
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
        public string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint  {
            get { return chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHintString; }
            private set { chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHintString = value; }
        }
        public string chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint  {
            get { return chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHintString; }
            private set { chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHintString = value; }
        }
        public string chkSettingsDownloadsSeparateIntoWebsiteUrlHint  {
            get { return chkSettingsDownloadsSeparateIntoWebsiteUrlHintString; }
            private set { chkSettingsDownloadsSeparateIntoWebsiteUrlHintString = value; }
        }
        public string chkSettingsDownloadsFixVReddItHint  {
            get { return chkSettingsDownloadsFixVReddItHintString; }
            private set { chkSettingsDownloadsFixVReddItHintString = value; }
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
        public string chksettingsDownloadsUseYoutubeDlsUpdaterHint  {
            get { return chksettingsDownloadsUseYoutubeDlsUpdaterHintString; }
            private set { chksettingsDownloadsUseYoutubeDlsUpdaterHintString = value; }
        }

        public string chkSettingsConverterClearOutputAfterConvertingHint  {
            get { return chkSettingsConverterClearOutputAfterConvertingHintString; }
            private set { chkSettingsConverterClearOutputAfterConvertingHintString = value; }
        }
        public string chkSettingsConverterDetectOutputFileTypeHint  {
            get { return chkSettingsConverterDetectOutputFileTypeHintString; }
            private set { chkSettingsConverterDetectOutputFileTypeHintString = value; }
        }
        public string chkSettingsConverterClearInputAfterConvertingHint  {
            get { return chkSettingsConverterClearInputAfterConvertingHintString; }
            private set { chkSettingsConverterClearInputAfterConvertingHintString = value; }
        }
        public string chkSettingsConverterHideFFmpegCompileInfoHint  {
            get { return chkSettingsConverterHideFFmpegCompileInfoHintString; }
            private set { chkSettingsConverterHideFFmpegCompileInfoHintString = value; }
        }
        public string lbSettingsConverterVideoBitrateHint  {
            get { return lbSettingsConverterVideoBitrateHintString; }
            private set { lbSettingsConverterVideoBitrateHintString = value; }
        }
        public string lbSettingsConverterVideoPresetHint  {
            get { return lbSettingsConverterVideoPresetHintString; }
            private set { lbSettingsConverterVideoPresetHintString = value; }
        }
        public string lbSettingsConverterVideoProfileHint  {
            get { return lbSettingsConverterVideoProfileHintString; }
            private set { lbSettingsConverterVideoProfileHintString = value; }
        }
        public string lbSettingsConverterVideoCRFHint  {
            get { return lbSettingsConverterVideoCRFHintString; }
            private set { lbSettingsConverterVideoCRFHintString = value; }
        }
        public string chkSettingsConverterVideoFastStartHint  {
            get { return chkSettingsConverterVideoFastStartHintString; }
            private set { chkSettingsConverterVideoFastStartHintString = value; }
        }
        public string lbSettingsConverterAudioBitrateHint  {
            get { return lbSettingsConverterAudioBitrateHintString; }
            private set { lbSettingsConverterAudioBitrateHintString = value; }
        }
        public string txtSettingsConverterCustomArgumentsHint  {
            get { return txtSettingsConverterCustomArgumentsHintString; }
            private set { txtSettingsConverterCustomArgumentsHintString = value; }
        }

        public string chkSettingsErrorsShowDetailedErrorsHint  {
            get { return chkSettingsErrorsShowDetailedErrorsHintString; }
            private set { chkSettingsErrorsShowDetailedErrorsHintString = value; }
        }
        public string chkSettingsErrorsSaveErrorsAsErrorLogHint  {
            get { return chkSettingsErrorsSaveErrorsAsErrorLogHintString; }
            private set { chkSettingsErrorsSaveErrorsAsErrorLogHintString = value; }
        }
        public string chkSettingsErrorsSuppressErrorsHint  {
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
        public static class InternalEnglish {
            // Language identifier
            public static readonly string CurrentLanguageLong = "English (Internal)";
            public static readonly string CurrentLanguageShort = "en-i";
            public static readonly string CurrentLanguageHint = "Click here to change";
            public static readonly string CurrentLanguageVersion = "1";

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
            public static readonly string btnDownloaderCancel = "Cancel";
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
            public static readonly string chkDownloadSound = "Sound";
            public static readonly string lbCustomArguments = "Custom arguments";
            public static readonly string txtArgsHint = "Custom youtube-dl arguments";
            public static readonly string sbDownload = "Download";
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
            public static readonly string btnSettingsCancel = "Cancel";
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
            #region tabGeneral
            //frmSettings / tcMain / tabGeneral
            public static readonly string lbSettingsGeneralYoutubeDlPath = "youtube-dl path";
            public static readonly string chkSettingsGeneralUseStaticYoutubeDl = "Use static youtube-dl";
            public static readonly string txtSettingsGeneralYoutubeDlPathHint = "The path of youtube-dl where it won't be moved";
            public static readonly string btnSettingsGeneralBrowseYoutubeDlHint = "Browse for a new folder where you'll store youtube-dl";
            public static readonly string lbSettingsGeneralFFmpegDirectory = "ffmpeg directory";
            public static readonly string chkSettingsGeneralUseStaticFFmpeg = "Use static ffmpeg";
            public static readonly string txtSettingsGeneralFFmpegPathHint = "The path of ffmpeg where it won't be moved";
            public static readonly string btnSettingsGeneralBrowseFFmpegHint = "Browse for a new folder where you'll store ffmpeg";
            public static readonly string chkSettingsGeneralCheckForUpdatesOnLaunch = "Check for updates on launch";
            public static readonly string chkSettingsGeneralHoverOverUrlToPasteClipboard = "Hover over URL to paste clipboard";
            public static readonly string chkSettingsGeneralClearUrlClipboardOnDownload = "Clear URL + clipboard on download";
            public static readonly string gbSettingsGeneralCustomArguments = "Custom arguments (saves on download)";
            public static readonly string rbSettingsGeneralCustomArgumentsDontSave = "Don't save";
            public static readonly string rbSettingsGeneralCustomArgumentsSaveAsArgsText = "Save as ./args.txt";
            public static readonly string rbSettingsGeneralCustomArgumentsSaveInSettings = "Save in settings";

            public static readonly string lbSettingsGeneralYoutubeDlPathHint = "Static youtube-dl directory\n\n"+
                                                                               "Static youtube-dl means youtube-dl will always be located in that one directory.";
            public static readonly string chkSettingsGeneralUseStaticYoutubeDlHint = "Use a static placed youtube-dl.exe file";
            public static readonly string lbSettingsGeneralFFmpegDirectoryHint = "Static ffmpeg directory\n\n"+
                                                                                 "Static ffmpeg means ffmpeg will always be located in that one directory.";
            public static readonly string chkSettingsGeneralUseStaticFFmpegHint = "Use a static placed ffmpeg.exe and ffprobe.exe files";
            public static readonly string chkSettingsGeneralCheckForUpdatesOnLaunchHint = "Check for updates on launch of youtube-dl-gui";
            public static readonly string chkSettingsGeneralHoverOverUrlToPasteClipboardHint = "Hover over the URL textbox to paste the URL from the clipboard";
            public static readonly string chkSettingsGeneralClearUrlClipboardOnDownloadHint = "Clears the URL from the textbox and clipboard on video download";
            public static readonly string gbSettingsGeneralCustomArgumentsHint = "Controls how custom arguments for youtube-dl will be saved";
            public static readonly string rbSettingsGeneralCustomArgumentsDontSaveHint = "Doesn't save any custom arguments";
            public static readonly string rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = "Saves custom arguments as args.txt in youtube-dl-gui's directory";
            public static readonly string rbSettingsGeneralCustomArgumentsSaveInSettingsHint = "Saves custom arguments in the application settings";
            #endregion
            #region tabDownloads
            // frmSettings / tcMain / tabDownloads
            public static readonly string lbSettingsDownloadsDownloadPath = "download path";
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
            public static readonly string chkSettingsDownloadsFixVReddIt = "fix v.redd.it";
            public static readonly string chkSettingsDownloadsLimitDownload = "Limit download";
            public static readonly string lbSettingsDownloadsRetryAttempts = "Retry attempts";
            public static readonly string chkSettingsDownloadsForceIpv4 = "Force IPv4";
            public static readonly string chkSettingsDownloadsForceIpv6 = "Force IPv6";
            public static readonly string chkSettingsDownloadsUseProxy = "Use a proxy";
            public static readonly string chksettingsDownloadsUseYoutubeDlsUpdater = "Use youtube-dl's internal updater";

            public static readonly string lbSettingsDownloadsDownloadPathHint = "The path of the folder where files will be downloaded to";
            public static readonly string lbSettingsDownloadsFileNameSchemaHint = "The file name schema\n\n"+
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
            public static readonly string chkSettingsConverterDetectOutputFileTypeHint = "If Automatic is checked on converting, this will attempt to detect the output file type.\n\n"+"Disable this if you want a simple conversion. The quality may suffer as a result.";
            public static readonly string chkSettingsConverterClearInputAfterConvertingHint = "Clears the input file after a successful conversion";
            public static readonly string chkSettingsConverterHideFFmpegCompileInfoHint = "Enabling this will hide some compilation information of ffmpeg.";
            public static readonly string lbSettingsConverterVideoBitrateHint = "The bitrate of the video\n"+
                                                                "A bitrate is how many bits per second are streamed to the player\n\n"+
                                                                "higher = better, at the cost of file size\n\n"+
                                                                "If you were to input \"10,000\" as the bitrate, it would be interpreted as \"10,000,000\" bits per second.";
            public static readonly string lbSettingsConverterVideoPresetHint = "The video preset of the conversion\n\n"+
                                                                                "ultrafast = fastest, but lower quality\n"+
                                                                                "veryslow = slowest, but higher quality";
            public static readonly string lbSettingsConverterVideoProfileHint = "The encoder profile to be used during conversion. It affects the compression of the video.\n"+
                                                                                "It's generally a good idea to stick with the main profile";
            public static readonly string lbSettingsConverterVideoCRFHint = "CRF is constant rate factor.\n\n"+
                                                                             "Lower = Higher quality";
            public static readonly string chkSettingsConverterVideoFastStartHint = "Faststart moves the metadata to the front of the file.\n\n"+
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
            public static readonly string chkSettingsErrorsSuppressErrorsHint = "This will silence any errors and will not save any error.log files.\n\n"+
                                                                                "This basically overrides all error settings. Use at your own risk.";
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

        public bool LoadInternalEnglish() {
            LoadedFile = null;

            // Langauge identifier
            CurrentLanguageLong = InternalEnglish.CurrentLanguageLong;
            CurrentLanguageShort = InternalEnglish.CurrentLanguageShort;
            CurrentLanguageHint = InternalEnglish.CurrentLanguageHint;

            // frmBatch
            frmBatchDownloadString = InternalEnglish.frmBatchDownload;
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
            btnDownloaderCancel = InternalEnglish.btnDownloaderCancel;
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
            mSettingsString = InternalEnglish.mSettings;
            mToolsString = InternalEnglish.mTools;
            mBatchDownloadString = InternalEnglish.mBatchDownload;
            mDownloadSubtitlesString = InternalEnglish.mDownloadSubtitles;
            mMiscToolsString = InternalEnglish.mMiscTools;
            mHelpString = InternalEnglish.mHelp;
            mLanguageString = InternalEnglish.mLanguage;
            mSupportedSitesString = InternalEnglish.mSupportedSites;
            mAboutString = InternalEnglish.mAbout;

            tabDownloadString = InternalEnglish.tabDownload;
            tabConvertString = InternalEnglish.tabConvert;
            tabMergeString = InternalEnglish.tabMerge;

            lbURLString = InternalEnglish.lbURL;
            txtUrlHintString = InternalEnglish.txtUrlHint;
            gbDownloadTypeString = InternalEnglish.gbDownloadType;
            rbVideoString = InternalEnglish.rbVideo;
            rbAudioString = InternalEnglish.rbAudio;
            rbCustomString = InternalEnglish.rbCustom;
            lbQualityString = InternalEnglish.lbQuality;
            chkDownloadSoundString = InternalEnglish.chkDownloadSound;
            lbCustomArgumentsString = InternalEnglish.lbCustomArguments;
            txtArgsHintString = InternalEnglish.txtArgsHint;
            sbDownloadString = InternalEnglish.sbDownload;
            mBatchDownloadFromFileString = InternalEnglish.mBatchDownloadFromFile;
            lbDownloadStatusStartedString = InternalEnglish.lbDownloadStatusStarted;
            lbDownloadStatusErrorString = InternalEnglish.lbDownloadStatusError;

            lbConvertInputString = InternalEnglish.lbConvertInput;
            lbConvertOutputString = InternalEnglish.lbConvertOutput;
            rbConvertVideoString = InternalEnglish.rbConvertVideo;
            rbConvertAudioString = InternalEnglish.rbConvertAudio;
            rbConvertCustomString = InternalEnglish.rbConvertCustom;
            rbConvertAutoString = InternalEnglish.rbConvertAuto;
            rbConvertAutoFFmpegString = InternalEnglish.rbConvertAutoFFmpeg;
            btnConvertString = InternalEnglish.btnConvert;
            lbConvertStartedString = InternalEnglish.lbConvertStarted;
            lbConvertFailedString = InternalEnglish.lbConvertFailed;

            lbMergeInput1String = InternalEnglish.lbMergeInput1;
            lbMergeInput2String = InternalEnglish.lbMergeInput2;
            lbMergeOutputString = InternalEnglish.lbMergeOutput;
            chkMergeAudioTracksString = InternalEnglish.chkMergeAudioTracks;
            chkMergeDeleteInputFilesString = InternalEnglish.chkMergeDeleteInputFiles;
            btnMergeString = InternalEnglish.btnMerge;

            cmTrayShowFormString = InternalEnglish.cmTrayShowForm;
            cmTrayDownloaderString = InternalEnglish.cmTrayDownloader;
            cmTrayDownloadClipboardString = InternalEnglish.cmTrayDownloadClipboard;
            cmTrayDownloadBestVideoString = InternalEnglish.cmTrayDownloadBestVideo;
            cmTrayDownloadBestAudioString = InternalEnglish.cmTrayDownloadBestAudio;
            cmTrayDownloadCustomString = InternalEnglish.cmTrayDownloadCustom;
            cmTrayDownloadCustomTxtBoxString = InternalEnglish.cmTrayDownloadCustomTxtBox;
            cmTrayDownloadCustomTxtString = InternalEnglish.cmTrayDownloadCustomTxt;
            cmTrayDownloadCustomSettingsString = InternalEnglish.cmTrayDownloadCustomSettings;
            cmTrayConverterString = InternalEnglish.cmTrayConverter;
            cmTrayConvertToString = InternalEnglish.cmTrayConvertTo;
            cmTrayConvertVideoString = InternalEnglish.cmTrayConvertVideo;
            cmTrayConvertAudioString = InternalEnglish.cmTrayConvertAudio;
            cmTrayConvertCustomString = InternalEnglish.cmTrayConvertCustom;
            cmTrayConvertAutomaticString = InternalEnglish.cmTrayConvertAutomatic;
            cmTrayConvertAutoFFmpegString = InternalEnglish.cmTrayConvertAutoFFmpeg;
            cmTrayExitString = InternalEnglish.cmTrayExit;

            // frmSettings
            btnSettingsRedownloadYoutubeDl = InternalEnglish.btnSettingsRedownloadYoutubeDl;
            btnSettingsCancel = InternalEnglish.btnSettingsCancel;
            btnSettingsSave = InternalEnglish.btnSettingsSave;

            tabSettingsGeneral = InternalEnglish.tabSettingsGeneral;
            tabSettingsDownloads = InternalEnglish.tabSettingsDownloads;
            tabSettingsConverter = InternalEnglish.tabSettingsConverter;
            tabSettingsExtensions = InternalEnglish.tabSettingsExtensions;
            tabSettingsErrors = InternalEnglish.tabSettingsErrors;

            lbSettingsGeneralYoutubeDlPath = InternalEnglish.lbSettingsGeneralYoutubeDlPath;
            chkSettingsGeneralUseStaticYoutubeDl = InternalEnglish.chkSettingsGeneralUseStaticYoutubeDl;
            lbSettingsGeneralFFmpegDirectory = InternalEnglish.lbSettingsGeneralFFmpegDirectory;
            chkSettingsGeneralUseStaticFFmpeg = InternalEnglish.chkSettingsGeneralUseStaticFFmpeg;
            chkSettingsGeneralCheckForUpdatesOnLaunch = InternalEnglish.chkSettingsGeneralCheckForUpdatesOnLaunch;
            chkSettingsGeneralHoverOverUrlToPasteClipboard = InternalEnglish.chkSettingsGeneralHoverOverUrlToPasteClipboard;
            chkSettingsGeneralClearUrlClipboardOnDownload = InternalEnglish.chkSettingsGeneralClearUrlClipboardOnDownload;
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
            chkSettingsDownloadsLimitDownload = InternalEnglish.chkSettingsDownloadsLimitDownload;
            lbSettingsDownloadsRetryAttempts = InternalEnglish.lbSettingsDownloadsRetryAttempts;
            chkSettingsDownloadsForceIpv4 = InternalEnglish.chkSettingsDownloadsForceIpv4;
            chkSettingsDownloadsForceIpv6 = InternalEnglish.chkSettingsDownloadsForceIpv6;
            chkSettingsDownloadsUseProxy = InternalEnglish.chkSettingsDownloadsUseProxy;
            chksettingsDownloadsUseYoutubeDlsUpdater = InternalEnglish.chksettingsDownloadsUseYoutubeDlsUpdater;

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
            chkSettingsGeneralHoverOverUrlToPasteClipboardHint = InternalEnglish.chkSettingsGeneralHoverOverUrlToPasteClipboardHint;
            chkSettingsGeneralClearUrlClipboardOnDownloadHint = InternalEnglish.chkSettingsGeneralClearUrlClipboardOnDownloadHint;
            gbSettingsGeneralCustomArgumentsHint = InternalEnglish.gbSettingsGeneralCustomArgumentsHint;
            rbSettingsGeneralCustomArgumentsDontSaveHint = InternalEnglish.rbSettingsGeneralCustomArgumentsDontSaveHint;
            rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = InternalEnglish.rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint;
            rbSettingsGeneralCustomArgumentsSaveInSettingsHint = InternalEnglish.rbSettingsGeneralCustomArgumentsSaveInSettingsHint;

            lbSettingsDownloadsDownloadPathHint = InternalEnglish.lbSettingsDownloadsDownloadPathHint;
            txtSettingsDownloadsSavePathHint = InternalEnglish.txtSettingsDownloadsSavePathHint;
            btnSettingsDownloadsBrowseSavePathHint = InternalEnglish.btnSettingsDownloadsBrowseSavePathHint;
            llSettingsDownloadsSchemaHelpHint = InternalEnglish.llSettingsDownloadsSchemaHelpHint;
            lbSettingsDownloadsFileNameSchemaHint = InternalEnglish.lbSettingsDownloadsFileNameSchemaHint;

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

            lbSettingsExtensionsHeader = InternalEnglish.lbSettingsExtensionsHeader;
            lbSettingsExtensionsExtensionFullName = InternalEnglish.lbSettingsExtensionsExtensionFullName;
            lbSettingsExtensionsExtensionShort = InternalEnglish.lbSettingsExtensionsExtensionShort;
            btnSettingsExtensionsAdd = InternalEnglish.btnSettingsExtensionsAdd;
            btnSettingsExtensionsRemoveSelected = InternalEnglish.btnSettingsExtensionsRemoveSelected;

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
            btnMiscToolsExtractAudioString = InternalEnglish.btnMiscToolsExtractAudio;
            btnMiscToolsVideoToGifString = InternalEnglish.btnMiscToolsVideoToGif;

            // frmUpdateAvailable
            frmUpdateAvailable = InternalEnglish.frmUpdateAvailable;
            lbUpdateAvailableHeader = InternalEnglish.lbUpdateAvailableHeader;
            lbUpdateAvailableUpdateVersion = InternalEnglish.lbUpdateAvailableUpdateVersion;
            lbUpdateAvailableCurrentVersion = InternalEnglish.lbUpdateAvailableCurrentVersion;
            lbUpdateAvailableChangelog = InternalEnglish.lbUpdateAvailableChangelog;
            btnUpdateAvailableSkipVersion = InternalEnglish.btnUpdateAvailableSkipVersion;
            btnUpdateAvailableUpdate = InternalEnglish.btnUpdateAvailableUpdate;
            btnUpdateAvailableOk = InternalEnglish.btnUpdateAvailableOk;

            return true;
        }
        #endregion

        public static Language GetInstance() {
            return LangInstance;
        }

        #region Load Language File
        public bool LoadLanguage(string LanguageFile = null) {
            try {
                if (LanguageFile == null || LanguageFile == string.Empty) {
                    LoadInternalEnglish();
                    return true;
                }
                else {
                    if (!LanguageFile.EndsWith(".ini")) { LanguageFile += ".ini"; }

                    if (System.IO.File.Exists(LanguageFile)) {
                        string[] ReadFile = System.IO.File.ReadAllLines(LanguageFile);

                        for (int i = 0; i < ReadFile.Length; i++) {
                            string ReadLine = ReadFile[i];
                            string ReadControl = null;
                            string ReadValue = null;
                            string ReadHeader = null;
                            if (ReadLine.StartsWith("//")) { continue; }

                            if (ReadLine.StartsWith("[")) {
                                ReadHeader = ReadHeaderValue(ReadLine);

                                if (ReadHeader == null) {
                                    throw new Exception("Unable to read the language ini header\nReadValue returned null.");
                                }
                                else {
                                    CurrentLanguageLong = ReadHeader;
                                    continue;
                                }
                            }
                            else {
                                if (ReadLine == null || ReadLine.Split('=').Length < 2) { continue; }
                                ReadControl = GetControlName(ReadLine).ToLower();
                                ReadValue = GetControlValue(ReadLine);
                            }

                            #region Language File
                            if (ReadControl == "currentlanguageshort") {
                                CurrentLanguageShort = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "currentlanguagehint") {
                                CurrentLanguageHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "currentlanguageversion") {
                                CurrentLanguageVersion = ReadValue;
                                continue;
                            }
                            #endregion

                            #region frmBatchDownloader
                            // frmBatchDownloader
                            else if (ReadControl == "frmbatchdownload") {
                                frmBatchDownload = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbbatchdownloadlink") {
                                lbBatchDownloadLink = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbbatchdownloadtype") {
                                lbBatchDownloadType = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbbatchdownloadvideospecificargument") {
                                lbBatchDownloadVideoSpecificArgument = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnbatchdownloadadd") {
                                btnBatchDownloadAdd = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "sbbatchdownloadloadargs") {
                                sbBatchDownloadLoadArgs = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "mbatchdownloaderloadargsfromsettings") {
                                mBatchDownloaderLoadArgsFromSettings = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "mbatchdownloaderloadargsfromargstxt") {
                                mBatchDownloaderLoadArgsFromArgsTxt = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "mbatchdownloaderloadargsfromfile") {
                                mBatchDownloaderLoadArgsFromFile = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnbatchdownloadremoveselected") {
                                btnBatchDownloadRemoveSelected = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnbatchdownloadstart") {
                                btnBatchDownloadStart = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnbatchdownloadstop") {
                                btnBatchDownloadStop = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnbatchdownloadexit") {
                                btnBatchDownloadExit = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "sbbatchdownloaderidle") {
                                sbBatchDownloaderIdle = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "sbbatchdownloaderdownloading") {
                                sbBatchDownloaderDownloading = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "sbbatchdownloaderfinished") {
                                sbBatchDownloaderFinished = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "sbbatchdownloaderaborted") {
                                sbBatchDownloaderAborted = ReadValue;
                                continue;
                            }
                            #endregion

                            #region frmDownloader
                            else if (ReadLine == "frmdownloader") {
                                frmDownloader = ReadValue;
                                continue;
                            }
                            else if (ReadLine == "frmdownloadercomplete") {
                                frmDownloaderComplete = ReadValue;
                                continue;
                            }
                            else if (ReadLine == "frmdownloadererror") {
                                frmDownloaderError = ReadValue;
                                continue;
                            }
                            else if (ReadLine == "chkdownloadercloseafterdownload") {
                                chkDownloaderCloseAfterDownload = ReadValue;
                                continue;
                            }
                            else if (ReadLine == "btndownloadercancel") {
                                btnDownloaderCancel = ReadValue;
                                continue;
                            }
                            else if (ReadLine == "btndownloaderexit") {
                                btnDownloaderExit = ReadValue;
                                continue;
                            }
                            #endregion

                            #region frmException
                            else if (ReadControl == "frmexception") {
                                frmException = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbexceptionheader") {
                                lbExceptionHeader = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbexceptiondescription") {
                                lbExceptionDescription = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "rtbexceptiondetails") {
                                rtbExceptionDetails = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnexceptiongithub") {
                                btnExceptionGithub = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnexceptionok") {
                                btnExceptionOk = ReadValue;
                                continue;
                            }
                            #endregion

                            #region frmLanguage
                            else if (ReadControl == "frmlanguage") {
                                frmLanguage = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnlanguagerefresh") {
                                btnLanguageRefresh = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnlanguagecancel") {
                                btnLanguageCancel = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnlanguagesave") {
                                btnLanguageSave = ReadValue;
                                continue;
                            }
                            #endregion

                            #region frmMain
                            // frmMain / menu
                            else if (ReadControl == "msettings") {
                                mSettings = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "mtools") {
                                mTools = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "mbatchdownload") {
                                mBatchDownload = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "mdownloadsubtitles") {
                                mDownloadSubtitles = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "mmisctools") {
                                mMiscTools = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "mhelp") {
                                mHelp = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "mlanguage") {
                                mLanguage = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "msupportedsites") {
                                mSupportedSites = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "mabout") {
                                mAbout = ReadValue;
                                continue;
                            }
                            // frmMain / tcMain
                            else if (ReadControl == "tabdownload") {
                                tabDownload = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "tabconvert") {
                                tabConvert = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "tabmerge") {
                                tabMerge = ReadValue;
                                continue;
                            }
                            // frmMain / tcMain / Download
                            else if (ReadControl == "lburl") {
                                lbURL = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "txturlhint") {
                                txtUrlHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "gbdownloadtype") {
                                gbDownloadType = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "rbvideo") {
                                rbVideo = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "rbaudio") {
                                rbAudio = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "rbcustom") {
                                rbCustom = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbquality") {
                                lbQuality = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chkdownloadsound") {
                                chkDownloadSound = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbcustomarguments") {
                                lbCustomArguments = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "txtargshint") {
                                txtArgsHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "sbdownload") {
                                sbDownload = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "mbatchdownloadfromfile") {
                                mBatchDownloadFromFile = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbdownloadstatusstarted") {
                                lbDownloadStatusStarted = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbdownloadstatuserror") {
                                lbDownloadStatusError = ReadValue;
                                continue;
                            }
                            // frmMain / tcMain / Convert
                            else if (ReadControl == "lbconvertinput") {
                                lbConvertInput = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbconvertoutput") {
                                lbConvertOutput = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "rbconvertvideo") {
                                rbConvertVideo = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "rbconvertaudio") {
                                rbConvertAudio = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "rbconvertcustom") {
                                rbConvertCustom = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "rbconvertauto") {
                                rbConvertAuto = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "rbconvertautoffmpeg") {
                                rbConvertAutoFFmpeg = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnconvert") {
                                btnConvert = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbconvertstarted") {
                                lbConvertStarted = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbconvertfailed") {
                                lbConvertFailed = ReadValue;
                                continue;
                            }
                            // frmMain / tcMain / Merge
                            else if (ReadControl == "lbmergeinput1") {
                                lbMergeInput1 = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbmergeinput2") {
                                lbMergeInput2 = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbmergeoutput") {
                                lbMergeOutput = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chkmergeaudiotracks") {
                                chkMergeAudioTracks = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chkmergedeleteinputfiles") {
                                chkMergeDeleteInputFiles = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnmerge") {
                                btnMerge = ReadValue;
                                continue;
                            }
                            // frmMain / tcMain / cmTray
                            else if (ReadControl == "cmTrayShowForm") {
                                cmTrayShowForm = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtraydownloader") {
                                cmTrayDownloader = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtraydownloadclipboard") {
                                cmTrayDownloadClipboard = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtraydownloadbestvideo") {
                                cmTrayDownloadBestVideo = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtraydownloadbestaudio") {
                                cmTrayDownloadBestAudio = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtraydownloadcustom") {
                                cmTrayDownloadCustom = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtraydownloadcustomtxtbox") {
                                cmTrayDownloadCustomTxtBox = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtraydownloadcustomtxt") {
                                cmTrayDownloadCustomTxt = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtraydownloadcustomsettings") {
                                cmTrayDownloadCustomSettings = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtrayconverter") {
                                cmTrayConverter = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtrayconvertto") {
                                cmTrayConvertTo = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtrayconvertvideo") {
                                cmTrayConvertVideo = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtrayconvertaudio") {
                                cmTrayConvertAudio = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtrayconvertcustom") {
                                cmTrayConvertCustom = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtrayconvertautomatic") {
                                cmTrayConvertAutomatic = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtrayconvertautoffmpeg") {
                                cmTrayConvertAutoFFmpeg = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cmtrayexit") {
                                cmTrayExit = ReadValue;
                                continue;
                            }
                            #endregion

                            #region frmSettings
                            // frmSettings
                            else if (ReadControl == "btnsettingsredownloadyoutubedl") {
                                btnSettingsRedownloadYoutubeDl = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnsettingscancel") {
                                btnSettingsCancel = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnsettingssave") {
                                btnSettingsSave = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnsettingsredownloadyoutubedlhint") {
                                btnSettingsRedownloadYoutubeDlHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnsettingscancelhint") {
                                btnSettingsCancelHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnsettingssavehint") {
                                btnSettingsSaveHint = ReadValue;
                                continue;
                            }
                            // frmSettings / tcMain
                            else if (ReadControl == "tabsettingsgeneral") {
                                tabSettingsGeneral = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "tabsettingsdownloads") {
                                tabSettingsDownloads = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "tabsettingsconverter") {
                                tabSettingsConverter = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "tabsettingsextensions") {
                                tabSettingsExtensions = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "tabsettingserrors") {
                                tabSettingsErrors = ReadValue;
                                continue;
                            }
                            //frmSettings / tcMain / tabGeneral
                            else if (ReadControl == "lbsettingsgeneralyoutubedlpath") {
                                lbSettingsGeneralYoutubeDlPath = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsgeneralusestaticyoutubedl") {
                                chkSettingsGeneralUseStaticYoutubeDl = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsgeneralffmpegdirectory") {
                                lbSettingsGeneralFFmpegDirectory = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsgeneralusestaticffmpeg") {
                                chkSettingsGeneralUseStaticFFmpeg = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsgeneralcheckforupdatesonlaunch") {
                                chkSettingsGeneralCheckForUpdatesOnLaunch = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsgeneralhoveroverurltopasteclipboard") {
                                chkSettingsGeneralHoverOverUrlToPasteClipboard = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsgeneralclearurlclipboardondownload") {
                                chkSettingsGeneralClearUrlClipboardOnDownload = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "gbsettingsgeneralcustomarguments") {
                                gbSettingsGeneralCustomArguments = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "rbsettingsgeneralcustomargumentsdontsave") {
                                rbSettingsGeneralCustomArgumentsDontSave = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "rbsettingsgeneralcustomargumentssaveasargstext") {
                                rbSettingsGeneralCustomArgumentsSaveAsArgsText = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "rbsettingsgeneralcustomargumentssaveinsettings") {
                                rbSettingsGeneralCustomArgumentsSaveInSettings = ReadValue;
                                continue;
                            }

                            else if (ReadControl == "lbsettingsgeneralyoutubedlpathhint") {
                                lbSettingsGeneralYoutubeDlPathHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsgeneralusestaticyoutubedlhint") {
                                chkSettingsGeneralUseStaticYoutubeDlHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "txtsettingsgeneralyoutubedlpathhint") {
                                txtSettingsGeneralYoutubeDlPathHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnsettingsgeneralbrowseyoutubedlhint") {
                                btnSettingsGeneralBrowseYoutubeDlHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsgeneralffmpegdirectoryhint") {
                                lbSettingsGeneralFFmpegDirectoryHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsgeneralusestaticffmpeghint") {
                                chkSettingsGeneralUseStaticFFmpegHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "txtsettingsgeneralffmpegpathhint") {
                                txtSettingsGeneralFFmpegPathHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnsettingsgeneralbrowseffmpeghint") {
                                btnSettingsGeneralBrowseFFmpegHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsgeneralcheckforupdatesonlaunchhint") {
                                chkSettingsGeneralCheckForUpdatesOnLaunchHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsgeneralhoveroverurltopasteclipboardhint") {
                                chkSettingsGeneralHoverOverUrlToPasteClipboardHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsgeneralclearurlclipboardondownloadhint") {
                                chkSettingsGeneralClearUrlClipboardOnDownloadHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "gbsettingsgeneralcustomargumentshint") {
                                gbSettingsGeneralCustomArgumentsHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "rbsettingsgeneralcustomargumentsdontsavehint") {
                                rbSettingsGeneralCustomArgumentsDontSaveHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "rbsettingsgeneralcustomargumentssaveasargstexthint") {
                                rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "rbsettingsgeneralcustomargumentssaveinsettingshint") {
                                rbSettingsGeneralCustomArgumentsSaveInSettingsHint = ReadValue;
                                continue;
                            }
                            // frmSettings / tcMain / tabDownloads
                            else if (ReadControl == "lbsettingsdownloadsdownloadpath") {
                                lbSettingsDownloadsDownloadPath = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsdownloadsfilenameschema") {
                                lbSettingsDownloadsFileNameSchema = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadssaveformatquality") {
                                chkSettingsDownloadsSaveFormatQuality = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsdownloadsubtitles") {
                                chkSettingsDownloadsDownloadSubtitles = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsembedsubtitles") {
                                chkSettingsDownloadsEmbedSubtitles = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadssavevideoinfo") {
                                chkSettingsDownloadsSaveVideoInfo = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadswritemetadatatofile") {
                                chkSettingsDownloadsWriteMetadataToFile = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadssavedescriptionstring") {
                                chkSettingsDownloadsSaveDescriptionString = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadskeeporiginalfiles") {
                                chkSettingsDownloadsKeepOriginalFiles = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadssaveannotationsstring") {
                                chkSettingsDownloadsSaveAnnotationsString = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadssavethumbnailsstring") {
                                chkSettingsDownloadsSaveThumbnailsString = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsembedthumbnails") {
                                chkSettingsDownloadsEmbedThumbnails = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsautomaticallydeleteyoutubedlwhenclosing") {
                                chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsseparatedownloadstodifferentfolders") {
                                chkSettingsDownloadsSeparateDownloadsToDifferentFolders = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsseparateintowebsiteurl") {
                                chkSettingsDownloadsSeparateIntoWebsiteUrl = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsfixvreddit") {
                                chkSettingsDownloadsFixVReddIt = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadslimitdownloadstring") {
                                chkSettingsDownloadsLimitDownloadString = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsdownloadsretryattemptsstring") {
                                lbSettingsDownloadsRetryAttemptsString = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsforceipv4string") {
                                chkSettingsDownloadsForceIpv4String = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsforceipv6string") {
                                chkSettingsDownloadsForceIpv6String = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsuseproxystring") {
                                chkSettingsDownloadsUseProxyString = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsuseyoutubedlsupdater") {
                                chksettingsDownloadsUseYoutubeDlsUpdater = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsdownloadsdownloadpathhint") {
                                lbSettingsDownloadsDownloadPathHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "txtsettingsdownloadssavepathhint") {
                                txtSettingsDownloadsSavePathHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnsettingsdownloadsbrowsesavepathhint") {
                                btnSettingsDownloadsBrowseSavePathHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "llsettingsdownloadsschemahelphint") {
                                llSettingsDownloadsSchemaHelpHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsdownloadsfilenameschemahint") {
                                lbSettingsDownloadsFileNameSchemaHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "txtsettingsdownloadsfilenameschemahint") {
                                txtSettingsDownloadsFileNameSchemaHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadssaveformatqualityhint") {
                                chkSettingsDownloadsSaveFormatQualityHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsdownloadsubtitleshint") {
                                chkSettingsDownloadsDownloadSubtitlesHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsembedthumbnailshint") {
                                chkSettingsDownloadsEmbedThumbnailsHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadssavevideoinfohint") {
                                chkSettingsDownloadsSaveVideoInfoHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadswritemetadatatofilehint") {
                                chkSettingsDownloadsWriteMetadataToFileHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadssavedescriptionhint") {
                                chkSettingsDownloadsSaveDescriptionHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadskeeporiginalfileshint") {
                                chkSettingsDownloadsKeepOriginalFilesHint = ReadValue;
                            }
                            else if (ReadControl == "chksettingsdownloadssaveannotationshint") {
                                chkSettingsDownloadsSaveAnnotationsHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadssavethumbnailshint") {
                                chkSettingsDownloadsSaveThumbnailsHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsembedthumbnailshint") {
                                chkSettingsDownloadsEmbedThumbnailsHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsautomaticallydeleteyoutubedlwhenclosinghint") {
                                chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsseparatedownloadstodifferentfoldershint") {
                                chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsseparateintowebsiteurlhint") {
                                chkSettingsDownloadsSeparateIntoWebsiteUrlHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsfixvreddithint") {
                                chkSettingsDownloadsFixVReddItHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chkSettingsDownloadsLimitDownloadhint") {
                                chkSettingsDownloadsLimitDownloadHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "numsettingsdownloadslimitdownloadhint") {
                                numSettingsDownloadsLimitDownloadHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cbsettingsdownloadslimitdownloadhint") {
                                cbSettingsDownloadsLimitDownloadHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsdownloadsretryattemptshint") {
                                lbSettingsDownloadsRetryAttemptsHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "numsettingsdownloadsretryattemptshint") {
                                numSettingsDownloadsRetryAttemptsHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsforceipv4hint") {
                                chkSettingsDownloadsForceIpv4Hint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsforceipv6hint") {
                                chkSettingsDownloadsForceIpv6Hint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsuseproxyhint") {
                                chkSettingsDownloadsUseProxyHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "cbsettingsdownloadsproxytypehint") {
                                cbSettingsDownloadsProxyTypeHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsdownloadsuseyoutubedlsupdaterhint") {
                                chksettingsDownloadsUseYoutubeDlsUpdaterHint = ReadValue;
                                continue;
                            }

                            // frmSettings / tcMain / tabConverter
                            else if (ReadControl == "chksettingsconverterclearoutputafterconverting") {
                                chkSettingsConverterClearOutputAfterConverting = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsconverterdetectoutputfiletype") {
                                chkSettingsConverterDetectOutputFileType = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsconverterclearinputafterconverting") {
                                chkSettingsConverterClearInputAfterConverting = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsconverterhideffmpegcompileinfo") {
                                chkSettingsConverterHideFFmpegCompileInfo = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "tcsettingsconvertervideo") {
                                tcSettingsConverterVideo = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "tcsettingsconverteraudio") {
                                tcSettingsConverterAudio = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "tcsettingsconvertercustom") {
                                tcSettingsConverterCustom = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsconvertervideobitrate") {
                                lbSettingsConverterVideoBitrate = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsconvertervideopreset") {
                                lbSettingsConverterVideoPreset = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsconvertervideoprofile") {
                                lbSettingsConverterVideoProfile = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsconvertervideocrf") {
                                lbSettingsConverterVideoCRF = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsconvertervideofaststart") {
                                chkSettingsConverterVideoFastStart = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsconverteraudiobitrate") {
                                lbSettingsConverterAudioBitrate = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsconvertercustomheader") {
                                lbSettingsConverterCustomHeader = ReadValue;
                                continue;
                            }

                            else if (ReadControl == "chksettingsconverterclearoutputafterconvertinghint") {
                                chkSettingsConverterClearOutputAfterConvertingHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsconverterdetectoutputfiletypehint") {
                                chkSettingsConverterDetectOutputFileTypeHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsconverterclearinputafterconvertinghint") {
                                chkSettingsConverterClearInputAfterConvertingHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsconverterhideffmpegcompileinfohint") {
                                chkSettingsConverterHideFFmpegCompileInfoHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsconvertervideobitratehint") {
                                lbSettingsConverterVideoBitrateHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsconvertervideopresethint") {
                                lbSettingsConverterVideoPresetHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsconvertervideoprofilehint") {
                                lbSettingsConverterVideoProfileHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsconvertervideocrfhint") {
                                lbSettingsConverterVideoCRFHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingsconvertervideofaststarthint") {
                                chkSettingsConverterVideoFastStartHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsconverteraudiobitratehint") {
                                lbSettingsConverterAudioBitrateHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "txtsettingsconvertercustomargumentshint") {
                                txtSettingsConverterCustomArgumentsHint = ReadValue;
                                continue;
                            }
                            // frmSettings / tcMain / tabExtensions
                            else if (ReadControl == "lbsettingsextensionsheader") {
                                lbSettingsExtensionsHeader = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsextensionsextensionfullname") {
                                lbSettingsExtensionsExtensionFullName = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "txtsettingsextensionsextensionfullname") {
                                txtSettingsExtensionsExtensionFullName = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsextensionsextensionshort") {
                                lbSettingsExtensionsExtensionShort = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "txtsettingsextensionsextensionshort") {
                                txtSettingsExtensionsExtensionShort = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnsettingsextensionsadd") {
                                btnSettingsExtensionsAdd = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsettingsextensionsfilename") {
                                lbSettingsExtensionsFileName = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnsettingsextensionsremoveselected") {
                                btnSettingsExtensionsRemoveSelected = ReadValue;
                                continue;
                            }
                            // frmSettings / tcMain / tabErrors
                            else if (ReadControl == "chksettingserrorsshowdetailederrors") {
                                chkSettingsErrorsShowDetailedErrors = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingserrorssaveerrorsaserrorlog") {
                                chkSettingsErrorsSaveErrorsAsErrorLog = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingserrorssuppresserrors") {
                                chkSettingsErrorsSuppressErrors = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingserrorsshowdetailederrorshint") {
                                chkSettingsErrorsShowDetailedErrorsHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingserrorssaveerrorsaserrorloghint") {
                                chkSettingsErrorsSaveErrorsAsErrorLogHint = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "chksettingserrorssuppresserrorshint") {
                                chkSettingsErrorsSuppressErrorsHint = ReadValue;
                                continue;
                            }
                            #endregion

                            #region frmSubtitles
                            // frmSubtitles
                            else if (ReadControl == "frmsubtitles") {
                                frmSubtitles = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsubtitlesheader") {
                                lbSubtitlesHeader = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsubtitlesurl") {
                                lbSubtitlesUrl = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbsubtitleslanguages") {
                                lbSubtitlesLanguages = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnsubtitlesaddlanguage") {
                                btnSubtitlesAddLanguage = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnsubtitlesclearlanguages") {
                                btnSubtitlesClearLanguages = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnsubtitlesdownload") {
                                btnSubtitlesDownload = ReadValue;
                                continue;
                            }
                            #endregion

                            #region frmTools
                            // frmTools
                            else if (ReadControl == "frmtools") {
                                frmTools = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnmisctoolsremoveaudio") {
                                btnMiscToolsRemoveAudio = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnmisctoolsextractaudio") {
                                btnMiscToolsExtractAudioString = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnmisctoolsvideotogif") {
                                btnMiscToolsVideoToGifString = ReadValue;
                                continue;
                            }
                            #endregion

                            #region frmUpdateAvailable
                            else if (ReadControl == "frmupdateavailable") {
                                frmUpdateAvailable = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbupdateavailableheader") {
                                lbUpdateAvailableHeader = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbupdateavailableupdateversion") {
                                lbUpdateAvailableUpdateVersion = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbupdateavailablecurrentversion") {
                                lbUpdateAvailableCurrentVersion = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "lbupdateavailablechangelog") {
                                lbUpdateAvailableChangelog = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnupdateavailableskipversion") {
                                btnUpdateAvailableSkipVersion = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnupdateavailableupdate") {
                                btnUpdateAvailableUpdate = ReadValue;
                                continue;
                            }
                            else if (ReadControl == "btnupdateavailableok") {
                                btnUpdateAvailableOk = ReadValue;
                                continue;
                            }
                            #endregion
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

        private string ReadHeaderValue(string Input) {
            string ReadValue = null;
            if (Input.Contains("//")) {
                int CountedForwardSlashes = 0;
                int CountedLength = 0;
                for (int j = 0; j < Input.Length; j++) {
                    CountedLength++;
                    if (Input[j] == '/') {
                        CountedForwardSlashes++;
                        if (CountedForwardSlashes == 2) { break; }
                        continue;
                    }
                }
                CountedLength = CountedLength - 2;
                ReadValue = Input.Substring(0, CountedLength);
            }
            return ReadValue.Trim(' ').Trim('[').Trim(']');
        }
        private string GetControlName(string Input) {
            if (Input.Split('=').Length > 1) {
                return Input.Split('=')[0].Trim(' ');
            }
            else { return null; }
        }
        private string GetControlValue(string Input) {
            if (Input.Split('=').Length > 2) {
                string OutputBuffer = null;

                if (Input.Contains("//")) {
                    int CountedForwardSlashes = 0;
                    int CountedLength = 0;
                    for (int i = 1; i < Input.Length; i++) {
                        CountedLength++;
                        if (Input[i] == '/') {
                            CountedForwardSlashes++;
                            if (CountedForwardSlashes == 2) { break; }
                            else { continue; }
                        }
                    }
                    CountedLength = CountedLength - 2;
                    OutputBuffer = Input.Substring(0, CountedLength).Trim(' ');
                }
                for (int i = 1; i < Input.Split('=').Length; i++) {
                    OutputBuffer += Input.Split('=')[i] + "=";
                }
                if (!Input.EndsWith("=")) {
                    OutputBuffer = OutputBuffer.Trim('=');
                }
                else {
                    OutputBuffer = OutputBuffer.Substring(0, OutputBuffer.Length - 1);
                }
                return OutputBuffer.Replace("\\n", "\n").Replace("\\r", "\r").Replace("\\\"", "\"").Replace("\\'", "'");
            }
            else if (Input.Split('=').Length == 2) { return Input.Split('=')[1].Replace("\\n", "\n").Replace("\\r", "\r").Replace("\\\"", "\"").Replace("\\'", "'"); }
            else { return null; }
        }
        #endregion
    }
}