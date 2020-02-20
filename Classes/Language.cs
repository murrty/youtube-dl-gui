using System;

namespace youtube_dl_gui {
    public class Language {
        #region Variables
        private static Language LangInstance = new Language();
        private static volatile string LoadedFileString = null;

        #region Language identifier
        // Language identifier
        private static volatile string CurrentLanguageLongString = "CurrentLanguageLong";
        private static volatile string CurrentLanguageShortString = "CurrentLanguageShort";
        private static volatile string CurrentLanguageHintString = "CurrentLanguageHint";
        private static volatile string CurrentLanguageVersionString = "1";
        #endregion

        #region frmBatch
        private static volatile string frmBatchDownloadString = "frmBatchDownload";
        private static volatile string lbBatchDownloadLinkString = "lbBatchDownloadLink";
        private static volatile string lbBatchDownloadTypeString = "lbBatchDownloadType";
        private static volatile string lbBatchDownloadVideoSpecificArgumentString = "lbBatchDownloadVideoSpecificArgument";
        private static volatile string btnBatchDownloadAddString = "btnBatchDownloadAdd";
        private static volatile string btnBatchDownloadRemoveSelectedString = "btnBatchDownloadRemoveSelected";
        private static volatile string btnBatchDownloadStartString = "btnBatchDownloadStart";
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
        private static volatile string lbConvertInputString = "lbInput";
        private static volatile string lbConvertOutputString = "lbOutput";
        private static volatile string rbConvertVideoString = "rbVideo";
        private static volatile string rbConvertCustomString = "rbCustom";
        private static volatile string rbConvertAutoString = "rbAutomatic";
        private static volatile string rbConvertAutoFFmpegString = "rbAutoFFmpeg";
        private static volatile string btnConvertString = "rbConvert";
        private static volatile string lbConvertStartedString = "rbConversionStarted";
        private static volatile string lbConvertFailedString = "rbConversionFailed";
        // frmMain / tcMain / Merge (6 total)
        private static volatile string lbMergeInput1String = "lbMergeInput1";
        private static volatile string lbMergeInput2String = "lbMergeInput2";
        private static volatile string lbMergeOutputString = "lbMergeoutput";
        private static volatile string chkMergeAudioTracksString = "chkMergeAudioTracks";
        private static volatile string chkMergeDeleteInputFilesString = "chkMergeDeleteInputFiles";
        private static volatile string btnMergeString = "btnMerge";
        // frmMain / tcMain / cmTray (17 total)
        private static volatile string cmTrayShowString = "cmTrayShow";
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

        #region frmSettings
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
        // frmSettings / tcMain / tabDownloads
        private static volatile string lbSettingsDownloadsDownloadPathString = "lbSettingsDownloadsDownloadPath";
        private static volatile string lbSettingsDownloadsFileNameSchemaString = "lbSettingsDownloadsFileNameSchema";
        private static volatile string chkSettingsDownloadsSeparateDownloadsToDifferentFoldersString = "chkSettingsDownloadsSeparateDownloadsToDifferentFolders";
        private static volatile string chkSettingsDownloadsSaveFormatQualityString = "chkSettingsDownloadsSaveFormatQuality";
        private static volatile string chkSettingsDownloadsSeparateIntoWebsiteUrlString = "chkSettingsDownloadsSeparateIntoWebsiteUrl";
        private static volatile string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingString = "chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing";
        private static volatile string chksettingsDownloadsUseYoutubeDlsUpdaterString = "chksettingsDownloadsUseYoutubeDlsUpdater";
        private static volatile string chkSettingsDownloadsFixVReddItString = "chkSettingsDownloadsFixVReddIt";
        private static volatile string chkSettingsDownloadsDownloadSubtitlesString = "chkSettingsDownloadsDownloadSubtitles";
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
        // frmSettings / tcMain / tabExtensions
        private static volatile string lbSettingsExtensionsHeaderString = "lbSettingsExtensionsHeader";
        private static volatile string lbSettingsExtensionsExtensionFullNameString = "lbSettingsExtensionsExtensionFullName";
        private static volatile string lbSettingsExtensionsExtensionShortString = "lbSettingsExtensionsExtensionShort";
        private static volatile string btnSettingsExtensionsAddString = "btnSettingsExtensionsAdd";
        private static volatile string lbSettingsExtensionsFileNameString = "lbSettingsExtensionsFileName";
        private static volatile string btnSettingsExtensionsRemoveSelectedString = "btnSettingsExtensionsRemoveSelected";
        // frmSettings / tcMain / tabErrors
        private static volatile string chkSettingsErrorsShowDetailedErrorsString = "chkSettingsErrorsShowDetailedErrors";
        private static volatile string chkSettingsErrorsSaveErrorsAsErrorLogString = "chkSettingsErrorsSaveErrorsAsErrorLog";
        private static volatile string chkSettingsErrorsSuppressErrorsString = "chkSettingsErrorsSuppressErrors";
        #region Hints
        // frmSettings / tipSettings
        private static volatile string btnSettingsRedownloadYoutubeDlHintString = "btnSettingsRedownloadYoutubeDlHint";
        private static volatile string btnSettingsCancelHintString = "btnSettingsCancelHint";
        private static volatile string btnSettingsSaveHintString = "btnSettingsSaveHint";

        private static volatile string lbSettingsGeneralYoutubeDlPathHintString = "";
        private static volatile string chkSettingsGeneralUseStaticYoutubeDlHintString = "";
        private static volatile string lbSettingsGeneralFFmpegDirectoryHintString = "";
        private static volatile string chkSettingsGeneralUseStaticFFmpegHintString = "";
        private static volatile string chkSettingsGeneralCheckForUpdatesOnLaunchHintString = "";
        private static volatile string chkSettingsGeneralHoverOverUrlToPasteClipboardHintString = "";
        private static volatile string chkSettingsGeneralClearUrlClipboardOnDownloadHintString = "";
        private static volatile string gbSettingsGeneralCustomArgumentsHintString = "";
        private static volatile string rbSettingsGeneralCustomArgumentsDontSaveHintString = "";
        private static volatile string rbSettingsGeneralCustomArgumentsSaveAsArgsTextHintString = "";
        private static volatile string rbSettingsGeneralCustomArgumentsSaveInSettingsHintString = "";

        private static volatile string lbSettingsDownloadsDownloadPathHintString = "";
        private static volatile string lbSettingsDownloadsFileNameSchemaHintString = "";
        private static volatile string chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHintString = "";
        private static volatile string chkSettingsDownloadsSaveFormatQualityHintString = "";
        private static volatile string chkSettingsDownloadsSeparateIntoWebsiteUrlHintString = "";
        private static volatile string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHintString = "";
        private static volatile string chksettingsDownloadsUseYoutubeDlsUpdaterHintString = "";
        private static volatile string chkSettingsDownloadsFixVReddItHintString = "";
        private static volatile string chkSettingsDownloadsDownloadSubtitlesHintString = "";

        private static volatile string chkSettingsConverterClearOutputAfterConvertingHintString = "";
        private static volatile string chkSettingsConverterDetectOutputFileTypeHintString = "";
        private static volatile string chkSettingsConverterClearInputAfterConvertingHintString = "";
        private static volatile string chkSettingsConverterHideFFmpegCompileInfoHintString = "";
        private static volatile string lbSettingsConverterVideoBitrateHintString = "";
        private static volatile string lbSettingsConverterVideoPresetHintString = "";
        private static volatile string lbSettingsConverterVideoProfileHintString = "";
        private static volatile string lbSettingsConverterVideoCRFHintString = "";
        private static volatile string chkSettingsConverterVideoFastStartHintString = "";
        private static volatile string lbSettingsConverterAudioBitrateHintString = "";
        private static volatile string txtSettingsConverterCustomArgumentsHintString = "";

        private static volatile string chkSettingsErrorsShowDetailedErrorsHintString = "";
        private static volatile string chkSettingsErrorsSaveErrorsAsErrorLogHintString = "";
        private static volatile string chkSettingsErrorsSuppressErrorsHintString = "";
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
//////////////// Language identifier \\\\\\\\\\\\\\\\
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

//////////////// frmBatch \\\\\\\\\\\\\\\\
        #region frmBatch
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
        public string btnBatchDownloadStart  {
            get { return btnBatchDownloadStartString; }
            private set { btnBatchDownloadStartString = value; }
        }
        #endregion

//////////////// frmException \\\\\\\\\\\\\\\\
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

//////////////// frmMain \\\\\\\\\\\\\\\\
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

        public string cmTrayShow {
            get { return cmTrayShowString; }
            private set{ cmTrayShowString = value; }
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

//////////////// frmSettings \\\\\\\\\\\\\\\\
        #region frmSettings
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
        public string chkSettingsDownloadsSeparateDownloadsToDifferentFolders {
            get { return chkSettingsDownloadsSeparateDownloadsToDifferentFoldersString; }
            private set { chkSettingsDownloadsSeparateDownloadsToDifferentFoldersString = value; }
        }
        public string chkSettingsDownloadsSaveFormatQuality {
            get { return chkSettingsDownloadsSaveFormatQualityString; }
            private set { chkSettingsDownloadsSaveFormatQualityString = value; }
        }
        public string chkSettingsDownloadsSeparateIntoWebsiteUrl {
            get { return chkSettingsDownloadsSeparateIntoWebsiteUrlString; }
            private set { chkSettingsDownloadsSeparateIntoWebsiteUrlString = value; }
        }
        public string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing {
            get { return chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingString; }
            private set { chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingString = value; }
        }
        public string chksettingsDownloadsUseYoutubeDlsUpdater {
            get { return chksettingsDownloadsUseYoutubeDlsUpdaterString; }
            private set { chksettingsDownloadsUseYoutubeDlsUpdaterString = value; }
        }
        public string chkSettingsDownloadsFixVReddIt {
            get { return chkSettingsDownloadsFixVReddItString; }
            private set { chkSettingsDownloadsFixVReddItString = value; }
        }
        public string chkSettingsDownloadsDownloadSubtitles {
            get { return chkSettingsDownloadsDownloadSubtitlesString; }
            private set { chkSettingsDownloadsDownloadSubtitlesString = value; }
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
        public string lbSettingsExtensionsExtensionShort {
            get { return lbSettingsExtensionsExtensionShortString; }
            private set { lbSettingsExtensionsExtensionShortString = value; }
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
        public string lbSettingsGeneralFFmpegDirectoryHint  {
            get { return lbSettingsGeneralFFmpegDirectoryHintString; }
            private set { lbSettingsGeneralFFmpegDirectoryHintString = value; }
        }
        public string chkSettingsGeneralUseStaticFFmpegHint  {
            get { return chkSettingsGeneralUseStaticFFmpegHintString; }
            private set { chkSettingsGeneralUseStaticFFmpegHintString = value; }
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
        public string lbSettingsDownloadsFileNameSchemaHint  {
            get { return lbSettingsDownloadsFileNameSchemaHintString; }
            private set { lbSettingsDownloadsFileNameSchemaHintString = value; }
        }
        public string chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint  {
            get { return chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHintString; }
            private set { chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHintString = value; }
        }
        public string chkSettingsDownloadsSaveFormatQualityHint  {
            get { return chkSettingsDownloadsSaveFormatQualityHintString; }
            private set { chkSettingsDownloadsSaveFormatQualityHintString = value; }
        }
        public string chkSettingsDownloadsSeparateIntoWebsiteUrlHint  {
            get { return chkSettingsDownloadsSeparateIntoWebsiteUrlHintString; }
            private set { chkSettingsDownloadsSeparateIntoWebsiteUrlHintString = value; }
        }
        public string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint  {
            get { return chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHintString; }
            private set { chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHintString = value; }
        }
        public string chksettingsDownloadsUseYoutubeDlsUpdaterHint  {
            get { return chksettingsDownloadsUseYoutubeDlsUpdaterHintString; }
            private set { chksettingsDownloadsUseYoutubeDlsUpdaterHintString = value; }
        }
        public string chkSettingsDownloadsFixVReddItHint  {
            get { return chkSettingsDownloadsFixVReddItHintString; }
            private set { chkSettingsDownloadsFixVReddItHintString = value; }
        }
        public string chkSettingsDownloadsDownloadSubtitlesHint  {
            get { return chkSettingsDownloadsDownloadSubtitlesHintString; }
            private set { chkSettingsDownloadsDownloadSubtitlesHintString = value; }
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

//////////////// frmSubtitles \\\\\\\\\\\\\\\\
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

//////////////// frmTools \\\\\\\\\\\\\\\\
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

//////////////// frmUpdateAvailable \\\\\\\\\\\\\\\\
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
        public static Language GetInstance() {
            return LangInstance;
        }
        #endregion
        #endregion

        #region Integrated English
        public static class InternalEnglish {
            // Language identifier
            public static readonly string CurrentLanguageLong = "English (Internal)";
            public static readonly string CurrentLanguageShort = "en-i";
            public static readonly string CurrentLanguageHint = "Click here to change";
            public static readonly string CurrentLanguageVersion = "1";

            #region frmBatch
            // frmBatch
            public static readonly string frmBatchDownload = "Batch downloader";
            public static readonly string lbBatchDownloadLink = "Download link";
            public static readonly string lbBatchDownloadType = "Download type";
            public static readonly string lbBatchDownloadVideoSpecificArgument = "Video-specific argument";
            public static readonly string btnBatchDownloadAdd = "Add";
            public static readonly string btnBatchDownloadRemoveSelected = "Remove selected";
            public static readonly string btnBatchDownloadStart = "Start";
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
            public static readonly string cmTrayShow = "Show form";
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
            //frmSettings / tcMain / tabGeneral
            public static readonly string lbSettingsGeneralYoutubeDlPath = "youtube-dl path";
            public static readonly string chkSettingsGeneralUseStaticYoutubeDl = "Use static youtube-dl";
            public static readonly string lbSettingsGeneralFFmpegDirectory = "ffmpeg directory";
            public static readonly string chkSettingsGeneralUseStaticFFmpeg = "Use static ffmpeg";
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
            // frmSettings / tcMain / tabDownloads
            public static readonly string lbSettingsDownloadsDownloadPath = "download path";
            public static readonly string lbSettingsDownloadsFileNameSchema = "file name schema";
            public static readonly string chkSettingsDownloadsSeparateDownloadsToDifferentFolders = "Separate downloads to different folders";
            public static readonly string chkSettingsDownloadsSaveFormatQuality = "Save format && quality";
            public static readonly string chkSettingsDownloadsSeparateIntoWebsiteUrl = "Separate into website url";
            public static readonly string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = "Automatically delete youtube-dl when closing";
            public static readonly string chksettingsDownloadsUseYoutubeDlsUpdater = "Use youtube-dl's updater";
            public static readonly string chkSettingsDownloadsFixVReddIt = "fix v.redd.it";
            public static readonly string chkSettingsDownloadsDownloadSubtitles = "Download subtitles:";

            public static readonly string lbSettingsDownloadsDownloadPathHint = "The path of the folder where files will be downloaded to";
            public static readonly string lbSettingsDownloadsFileNameSchemaHint = "The file name schema\n\n"+
                                                                                  "This basically replaces sequences with video information for a custom file name.";
            public static readonly string chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = "Separates downloads into their own folder based on the download type\n\n"+"Videos would be <download directory>\\Video\n"+"Audio would be <download directory>\\Audio\n"+"Custom would be <download directory>\\Custom";
            public static readonly string chkSettingsDownloadsSaveFormatQualityHint = "Save format & quality of downloads on download";
            public static readonly string chkSettingsDownloadsSeparateIntoWebsiteUrlHint = "Downloaded files will be saved to the download path with the URL of the website appended at the end\n"+ "Ex: C:\\Users\\YourName\\Videos\\youtube.com\\Video.mp4";
            public static readonly string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = "Automatically delete youtube-dl.exe when closing youtube-dl-gui";
            public static readonly string chksettingsDownloadsUseYoutubeDlsUpdaterHint = "Use youtube-dl's internal updater instead of this application's updater";
            public static readonly string chkSettingsDownloadsFixVReddItHint = "Fixes visual corruptions on v.redd.it/reddit.com links using ffmpeg's HTTP Live Streaming (HLS)\n\n"+"Recommended to stay on.\n"+"This requires FFMPEG to be installed and available, it will fallback to youtube-dl's default.";
            public static readonly string chkSettingsDownloadsDownloadSubtitlesHint = "Download subtitles in the languages entered in the text box";
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
            public static readonly string lbSettingsConverterAudioBitrateHint = "Bitrate";
            public static readonly string txtSettingsConverterCustomArgumentsHint = "Custom arguments that will be passed through ffmpeg instead of built-in arguments";
            // frmSettings / tcMain / tabExtensions
            public static readonly string lbSettingsExtensionsHeader = "This allows you to input your own extensions\nto be used with this application";
            public static readonly string lbSettingsExtensionsExtensionFullName = "Extension full name";
            public static readonly string lbSettingsExtensionsExtensionShort = "Extension short";
            public static readonly string btnSettingsExtensionsAdd = "Add";
            public static readonly string lbSettingsExtensionsFileName = "FileName";
            public static readonly string btnSettingsExtensionsRemoveSelected = "Remove selected";
            // frmSettings / tcMain / tabErrors
            public static readonly string chkSettingsErrorsShowDetailedErrors = "Show detailed errors";
            public static readonly string chkSettingsErrorsSaveErrorsAsErrorLog = "Save errors as ./error.log";
            public static readonly string chkSettingsErrorsSuppressErrors = "Suppress errors";
            public static readonly string chkSettingsErrorsShowDetailedErrorsHint = "Shows more details in errors";
            public static readonly string chkSettingsErrorsSaveErrorsAsErrorLogHint = "Saves the latest error as error.log in the exeucting directory of youtube-dl-gui";
            public static readonly string chkSettingsErrorsSuppressErrorsHint = "This will silence any errors and will not save any error.log files.\n\n"+
                                                                                "This basically overrides all error settings. Use at your own risk.";
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

            CurrentLanguageLong = InternalEnglish.CurrentLanguageLong;
            CurrentLanguageShort = InternalEnglish.CurrentLanguageShort;
            CurrentLanguageHint = InternalEnglish.CurrentLanguageHint;

            // frmBatch


            // frmException
            frmException = InternalEnglish.frmException;
            lbExceptionHeader = InternalEnglish.lbExceptionHeader;
            lbExceptionDescription = InternalEnglish.lbExceptionDescription;
            rtbExceptionDetails = InternalEnglish.rtbExceptionDetails;
            btnExceptionGithub = InternalEnglish.btnExceptionGithub;
            btnExceptionOk = InternalEnglish.btnExceptionOk;

            // frmMain

            // frmSettings

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

        #region LoadLanguage
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

                            #region frmBatch
                            // frmBatch
                            if (ReadControl == "frmbatchdownload") {
                                frmBatchDownload = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbbatchdownloadlink") {
                                lbBatchDownloadLink = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbbatchdownloadtype") {
                                lbBatchDownloadType = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbbatchdownloadvideospecificargument") {
                                lbBatchDownloadVideoSpecificArgument = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnbatchdownloadadd") {
                                btnBatchDownloadAdd = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnbatchdownloadremoveselected") {
                                btnBatchDownloadRemoveSelected = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnbatchdownloadstart") {
                                btnBatchDownloadStart = ReadValue;
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

                            #region frmMain
                            // frmMain / menu
                            if (ReadControl == "msettings") {
                                mSettings = ReadValue;
                                continue;
                            }
                            if (ReadControl == "mtools") {
                                mTools = ReadValue;
                                continue;
                            }
                            if (ReadControl == "mbatchdownload") {
                                mBatchDownload = ReadValue;
                                continue;
                            }
                            if (ReadControl == "mdownloadsubtitles") {
                                mDownloadSubtitles = ReadValue;
                                continue;
                            }
                            if (ReadControl == "mmisctools") {
                                mMiscTools = ReadValue;
                                continue;
                            }
                            if (ReadControl == "mhelp") {
                                mHelp = ReadValue;
                                continue;
                            }
                            if (ReadControl == "mlanguage") {
                                mLanguage = ReadValue;
                                continue;
                            }
                            if (ReadControl == "msupportedsites") {
                                mSupportedSites = ReadValue;
                                continue;
                            }
                            if (ReadControl == "mabout") {
                                mAbout = ReadValue;
                                continue;
                            }
                            // frmMain / tcMain
                            if (ReadControl == "tabdownload") {
                                tabDownload = ReadValue;
                                continue;
                            }
                            if (ReadControl == "tabconvert") {
                                tabConvert = ReadValue;
                                continue;
                            }
                            if (ReadControl == "tabmerge") {
                                tabMerge = ReadValue;
                                continue;
                            }
                            // frmMain / tcMain / Download
                            if (ReadControl == "lburl") {
                                lbURL = ReadValue;
                                continue;
                            }
                            if (ReadControl == "txturlhint") {
                                txtUrlHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "gbdownloadtype") {
                                gbDownloadType = ReadValue;
                                continue;
                            }
                            if (ReadControl == "rbvideo") {
                                rbVideo = ReadValue;
                                continue;
                            }
                            if (ReadControl == "rbaudio") {
                                rbAudio = ReadValue;
                                continue;
                            }
                            if (ReadControl == "rbcustom") {
                                rbCustom = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbquality") {
                                lbQuality = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chkdownloadsound") {
                                chkDownloadSound = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbcustomarguments") {
                                lbCustomArguments = ReadValue;
                                continue;
                            }
                            if (ReadControl == "txtargshint") {
                                txtArgsHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "sbdownload") {
                                sbDownload = ReadValue;
                                continue;
                            }
                            if (ReadControl == "mbatchdownloadfromfile") {
                                mBatchDownloadFromFile = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbdownloadstatusstarted") {
                                lbDownloadStatusStarted = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbdownloadstatuserror") {
                                lbDownloadStatusError = ReadValue;
                                continue;
                            }
                            // frmMain / tcMain / Convert
                            if (ReadControl == "lbconvertinput") {
                                lbConvertInput = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbconvertoutput") {
                                lbConvertOutput = ReadValue;
                                continue;
                            }
                            if (ReadControl == "rbconvertvideo") {
                                rbConvertVideo = ReadValue;
                                continue;
                            }
                            if (ReadControl == "rbconvertcustom") {
                                rbConvertCustom = ReadValue;
                                continue;
                            }
                            if (ReadControl == "rbconvertauto") {
                                rbConvertAuto = ReadValue;
                                continue;
                            }
                            if (ReadControl == "rbconvertautoffmpeg") {
                                rbConvertAutoFFmpeg = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnconvert") {
                                btnConvert = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbconvertstarted") {
                                lbConvertStarted = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbconvertfailed") {
                                lbConvertFailed = ReadValue;
                                continue;
                            }
                            // frmMain / tcMain / Merge
                            if (ReadControl == "lbmergeinput1") {
                                lbMergeInput1 = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbmergeinput2") {
                                lbMergeInput2 = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbmergeoutput") {
                                lbMergeOutput = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chkmergeaudiotracks") {
                                chkMergeAudioTracks = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chkmergedeleteinputfiles") {
                                chkMergeDeleteInputFiles = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnmerge") {
                                btnMerge = ReadValue;
                                continue;
                            }
                            // frmMain / tcMain / cmTray
                            if (ReadControl == "cmtrayshow") {
                                cmTrayShow = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtraydownloader") {
                                cmTrayDownloader = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtraydownloadclipboard") {
                                cmTrayDownloadClipboard = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtraydownloadbestvideo") {
                                cmTrayDownloadBestVideo = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtraydownloadbestaudio") {
                                cmTrayDownloadBestAudio = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtraydownloadcustom") {
                                cmTrayDownloadCustom = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtraydownloadcustomtxtbox") {
                                cmTrayDownloadCustomTxtBox = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtraydownloadcustomtxt") {
                                cmTrayDownloadCustomTxt = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtraydownloadcustomsettings") {
                                cmTrayDownloadCustomSettings = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtrayconverter") {
                                cmTrayConverter = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtrayconvertto") {
                                cmTrayConvertTo = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtrayconvertvideo") {
                                cmTrayConvertVideo = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtrayconvertaudio") {
                                cmTrayConvertAudio = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtrayconvertcustom") {
                                cmTrayConvertCustom = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtrayconvertautomatic") {
                                cmTrayConvertAutomatic = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtrayconvertautoffmpeg") {
                                cmTrayConvertAutoFFmpeg = ReadValue;
                                continue;
                            }
                            if (ReadControl == "cmtrayexit") {
                                cmTrayExit = ReadValue;
                                continue;
                            }
                            #endregion

                            #region frmSettings
                            // frmSettings
                            if (ReadControl == "btnsettingsredownloadyoutubedl") {
                                btnSettingsRedownloadYoutubeDl = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnsettingscancel") {
                                btnSettingsCancel = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnsettingssave") {
                                btnSettingsSave = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnsettingsredownloadyoutubedlhint") {
                                btnSettingsRedownloadYoutubeDlHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnsettingscancelhint") {
                                btnSettingsCancelHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnsettingssavehint") {
                                btnSettingsSaveHint = ReadValue;
                                continue;
                            }
                            // frmSettings / tcMain
                            if (ReadControl == "tabsettingsgeneral") {
                                tabSettingsGeneral = ReadValue;
                                continue;
                            }
                            if (ReadControl == "tabsettingsdownloads") {
                                tabSettingsDownloads = ReadValue;
                                continue;
                            }
                            if (ReadControl == "tabsettingsconverter") {
                                tabSettingsConverter = ReadValue;
                                continue;
                            }
                            if (ReadControl == "tabsettingsextensions") {
                                tabSettingsExtensions = ReadValue;
                                continue;
                            }
                            if (ReadControl == "tabsettingserrors") {
                                tabSettingsErrors = ReadValue;
                                continue;
                            }
                            //frmSettings / tcMain / tabGeneral
                            if (ReadControl == "lbsettingsgeneralyoutubedlpath") {
                                lbSettingsGeneralYoutubeDlPath = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsgeneralusestaticyoutubedl") {
                                chkSettingsGeneralUseStaticYoutubeDl = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsgeneralffmpegdirectory") {
                                lbSettingsGeneralFFmpegDirectory = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsgeneralusestaticffmpeg") {
                                chkSettingsGeneralUseStaticFFmpeg = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsgeneralcheckforupdatesonlaunch") {
                                chkSettingsGeneralCheckForUpdatesOnLaunch = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsgeneralhoveroverurltopasteclipboard") {
                                chkSettingsGeneralHoverOverUrlToPasteClipboard = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsgeneralclearurlclipboardondownload") {
                                chkSettingsGeneralClearUrlClipboardOnDownload = ReadValue;
                                continue;
                            }
                            if (ReadControl == "gbsettingsgeneralcustomarguments") {
                                gbSettingsGeneralCustomArguments = ReadValue;
                                continue;
                            }
                            if (ReadControl == "rbsettingsgeneralcustomargumentsdontsave") {
                                rbSettingsGeneralCustomArgumentsDontSave = ReadValue;
                                continue;
                            }
                            if (ReadControl == "rbsettingsgeneralcustomargumentssaveasargstext") {
                                rbSettingsGeneralCustomArgumentsSaveAsArgsText = ReadValue;
                                continue;
                            }
                            if (ReadControl == "rbsettingsgeneralcustomargumentssaveinsettings") {
                                rbSettingsGeneralCustomArgumentsSaveInSettings = ReadValue;
                                continue;
                            }

                            if (ReadControl == "lbsettingsgeneralyoutubedlpathhint") {
                                lbSettingsGeneralYoutubeDlPathHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsgeneralusestaticyoutubedlhint") {
                                chkSettingsGeneralUseStaticYoutubeDlHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsgeneralffmpegdirectoryhint") {
                                lbSettingsGeneralFFmpegDirectoryHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsgeneralusestaticffmpeghint") {
                                chkSettingsGeneralUseStaticFFmpegHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsgeneralcheckforupdatesonlaunchhint") {
                                chkSettingsGeneralCheckForUpdatesOnLaunchHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsgeneralhoveroverurltopasteclipboardhint") {
                                chkSettingsGeneralHoverOverUrlToPasteClipboardHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsgeneralclearurlclipboardondownloadhint") {
                                chkSettingsGeneralClearUrlClipboardOnDownloadHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "gbsettingsgeneralcustomargumentshint") {
                                gbSettingsGeneralCustomArgumentsHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "rbsettingsgeneralcustomargumentsdontsavehint") {
                                rbSettingsGeneralCustomArgumentsDontSaveHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "rbsettingsgeneralcustomargumentssaveasargstexthint") {
                                rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "rbsettingsgeneralcustomargumentssaveinsettingshint") {
                                rbSettingsGeneralCustomArgumentsSaveInSettingsHint = ReadValue;
                                continue;
                            }
                            // frmSettings / tcMain / tabDownloads
                            if (ReadControl == "lbsettingsdownloadsdownloadpath") {
                                lbSettingsDownloadsDownloadPath = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsdownloadsfilenameschema") {
                                lbSettingsDownloadsFileNameSchema = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsdownloadsseparatedownloadstodifferentfolders") {
                                chkSettingsDownloadsSeparateDownloadsToDifferentFolders = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsdownloadssaveformatquality") {
                                chkSettingsDownloadsSaveFormatQuality = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsdownloadsseparateintowebsiteurl") {
                                chkSettingsDownloadsSeparateIntoWebsiteUrl = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsdownloadsautomaticallydeleteyoutubedlwhenclosing") {
                                chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsdownloadsuseyoutubedlsupdater") {
                                chksettingsDownloadsUseYoutubeDlsUpdater = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsdownloadsfixvreddit") {
                                chkSettingsDownloadsFixVReddIt = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsdownloadsdownloadsubtitles") {
                                chkSettingsDownloadsDownloadSubtitles = ReadValue;
                                continue;
                            }

                            if (ReadControl == "lbsettingsdownloadsdownloadpathhint") {
                                lbSettingsDownloadsDownloadPathHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsdownloadsfilenameschemahint") {
                                lbSettingsDownloadsFileNameSchemaHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsdownloadsseparatedownloadstodifferentfoldershint") {
                                chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsdownloadssaveformatqualityhint") {
                                chkSettingsDownloadsSaveFormatQualityHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsdownloadsseparateintowebsiteurlhint") {
                                chkSettingsDownloadsSeparateIntoWebsiteUrlHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsdownloadsautomaticallydeleteyoutubedlwhenclosinghint") {
                                chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsdownloadsuseyoutubedlsupdaterhint") {
                                chksettingsDownloadsUseYoutubeDlsUpdaterHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsdownloadsfixvreddithint") {
                                chkSettingsDownloadsFixVReddItHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsdownloadsdownloadsubtitleshint") {
                                chkSettingsDownloadsDownloadSubtitlesHint = ReadValue;
                                continue;
                            }
                            // frmSettings / tcMain / tabConverter
                            if (ReadControl == "chksettingsconverterclearoutputafterconverting") {
                                chkSettingsConverterClearOutputAfterConverting = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsconverterdetectoutputfiletype") {
                                chkSettingsConverterDetectOutputFileType = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsconverterclearinputafterconverting") {
                                chkSettingsConverterClearInputAfterConverting = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsconverterhideffmpegcompileinfo") {
                                chkSettingsConverterHideFFmpegCompileInfo = ReadValue;
                                continue;
                            }
                            if (ReadControl == "tcsettingsconvertervideo") {
                                tcSettingsConverterVideo = ReadValue;
                                continue;
                            }
                            if (ReadControl == "tcsettingsconverteraudio") {
                                tcSettingsConverterAudio = ReadValue;
                                continue;
                            }
                            if (ReadControl == "tcsettingsconvertercustom") {
                                tcSettingsConverterCustom = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsconvertervideobitrate") {
                                lbSettingsConverterVideoBitrate = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsconvertervideopreset") {
                                lbSettingsConverterVideoPreset = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsconvertervideoprofile") {
                                lbSettingsConverterVideoProfile = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsconvertervideocrf") {
                                lbSettingsConverterVideoCRF = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsconvertervideofaststart") {
                                chkSettingsConverterVideoFastStart = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbSettingsConverterAudioBitrate") {
                                lbSettingsConverterAudioBitrate = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsconvertercustomheader") {
                                lbSettingsConverterCustomHeader = ReadValue;
                                continue;
                            }

                            if (ReadControl == "chksettingsconverterclearoutputafterconvertinghint") {
                                chkSettingsConverterClearOutputAfterConvertingHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsconverterdetectoutputfiletypehint") {
                                chkSettingsConverterDetectOutputFileTypeHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsconverterclearinputafterconvertinghint") {
                                chkSettingsConverterClearInputAfterConvertingHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsconverterhideffmpegcompileinfohint") {
                                chkSettingsConverterHideFFmpegCompileInfoHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsconvertervideobitratehint") {
                                lbSettingsConverterVideoBitrateHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsconvertervideopresethint") {
                                lbSettingsConverterVideoPresetHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsconvertervideoprofilehint") {
                                lbSettingsConverterVideoProfileHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsconvertervideocrfhint") {
                                lbSettingsConverterVideoCRFHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingsconvertervideofaststarthint") {
                                chkSettingsConverterVideoFastStartHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbSettingsConverterAudioBitratehint") {
                                lbSettingsConverterAudioBitrateHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "txtsettingsconvertercustomargumentshint") {
                                txtSettingsConverterCustomArgumentsHint = ReadValue;
                                continue;
                            }
                            // frmSettings / tcMain / tabExtensions
                            if (ReadControl == "lbsettingsextensionsheader") {
                                lbSettingsExtensionsHeader = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsextensionsextensionfullname") {
                                lbSettingsExtensionsExtensionFullName = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsextensionsextensionshort") {
                                lbSettingsExtensionsExtensionShort = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnsettingsextensionsadd") {
                                btnSettingsExtensionsAdd = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsettingsextensionsfilename") {
                                lbSettingsExtensionsFileName = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnsettingsextensionsremoveselected") {
                                btnSettingsExtensionsRemoveSelected = ReadValue;
                                continue;
                            }
                            // frmSettings / tcMain / tabErrors
                            if (ReadControl == "chksettingserrorsshowdetailederrors") {
                                chkSettingsErrorsShowDetailedErrors = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingserrorssaveerrorsaserrorlog") {
                                chkSettingsErrorsSaveErrorsAsErrorLog = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingserrorssuppresserrors") {
                                chkSettingsErrorsSuppressErrors = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingserrorsshowdetailederrorshint") {
                                chkSettingsErrorsShowDetailedErrorsHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingserrorssaveerrorsaserrorloghint") {
                                chkSettingsErrorsSaveErrorsAsErrorLogHint = ReadValue;
                                continue;
                            }
                            if (ReadControl == "chksettingserrorssuppresserrorshint") {
                                chkSettingsErrorsSuppressErrorsHint = ReadValue;
                                continue;
                            }
                            #endregion

                            #region frmSubtitles
                            // frmSubtitles
                            if (ReadControl == "frmsubtitles") {
                                frmSubtitles = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsubtitlesheader") {
                                lbSubtitlesHeader = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsubtitlesurl") {
                                lbSubtitlesUrl = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbsubtitleslanguages") {
                                lbSubtitlesLanguages = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnsubtitlesaddlanguage") {
                                btnSubtitlesAddLanguage = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnsubtitlesclearlanguages") {
                                btnSubtitlesClearLanguages = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnsubtitlesdownload") {
                                btnSubtitlesDownload = ReadValue;
                                continue;
                            }
                            #endregion

                            #region frmTools
                            // frmTools
                            if (ReadControl == "frmtools") {
                                frmTools = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnmisctoolsremoveaudio") {
                                btnMiscToolsRemoveAudio = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnmisctoolsextractaudio") {
                                btnMiscToolsExtractAudioString = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnmisctoolsvideotogif") {
                                btnMiscToolsVideoToGifString = ReadValue;
                                continue;
                            }
                            #endregion

                            #region frmUpdateAvailable
                            if (ReadControl == "frmupdateavailable") {
                                frmUpdateAvailable = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbupdateavailableheader") {
                                lbUpdateAvailableHeader = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbupdateavailableupdateversion") {
                                lbUpdateAvailableUpdateVersion = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbupdateavailablecurrentversion") {
                                lbUpdateAvailableCurrentVersion = ReadValue;
                                continue;
                            }
                            if (ReadControl == "lbupdateavailablechangelog") {
                                lbUpdateAvailableChangelog = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnupdateavailableskipversion") {
                                btnUpdateAvailableSkipVersion = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnupdateavailableupdate") {
                                btnUpdateAvailableUpdate = ReadValue;
                                continue;
                            }
                            if (ReadControl == "btnupdateavailableok") {
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
                frmException error = new frmException();
                error.ReportedException = ex;
                error.FromLanguage = true;
                error.ShowDialog();
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
                for (int i = 0; i < Input.Split('=').Length; i++) {
                    OutputBuffer += Input.Split('=')[i] + "=";
                }
                if (!Input.EndsWith("=")) {
                    OutputBuffer = OutputBuffer.Trim('=');
                }
                else {
                    OutputBuffer = OutputBuffer.Substring(0, OutputBuffer.Length - 1);
                }
                return OutputBuffer;
            }
            else if (Input.Split('=').Length == 2) { return Input.Split('=')[1]; }
            else { return null; }
        }
        #endregion
    }
}