#nullable enable
namespace youtube_dl_gui;
internal static class Downloads {
    private const string ConfigName = "Downloads";

    static Downloads() {
        Log.Write("Loading Download config.");

        fdownloadPath =
            IniProvider.Read(downloadPath, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\youtube-dl", ConfigName);

        fseparateDownloads =
            IniProvider.Read(separateDownloads, true, ConfigName);

        fSaveFormatQuality =
            IniProvider.Read(SaveFormatQuality, true, ConfigName);

        fdeleteYtdlOnClose =
            IniProvider.Read(deleteYtdlOnClose, false, ConfigName);

        fuseYtdlUpdater =
            IniProvider.Read(useYtdlUpdater, false, ConfigName);

        ffileNameSchema =
            IniProvider.Read(fileNameSchema, "%(title)s-%(id)s.%(ext)s", ConfigName);

        ffixReddit =
            IniProvider.Read(fixReddit, true, ConfigName);

        fseparateIntoWebsiteURL =
            IniProvider.Read(separateIntoWebsiteURL, true, ConfigName);

        fSaveSubtitles =
            IniProvider.Read(SaveSubtitles, false, ConfigName);

        fsubtitlesLanguages =
            IniProvider.Read(subtitlesLanguages, "en", ConfigName);

        fCloseDownloaderAfterFinish =
            IniProvider.Read(CloseDownloaderAfterFinish, true, ConfigName);

        fCloseExtendedDownloaderAfterFinish =
            IniProvider.Read(CloseExtendedDownloaderAfterFinish, false, ConfigName);

        fUseProxy =
            IniProvider.Read(UseProxy, false, ConfigName);

        fProxyType =
            IniProvider.Read(ProxyType, -1, ConfigName);

        fProxyIP =
            IniProvider.Read(ProxyIP, string.Empty, ConfigName);

        fProxyPort =
            IniProvider.Read(ProxyPort, string.Empty, ConfigName);

        fSaveThumbnail =
            IniProvider.Read(SaveThumbnail, false, ConfigName);

        fSaveDescription =
            IniProvider.Read(SaveDescription, false, ConfigName);

        fSaveVideoInfo =
            IniProvider.Read(SaveVideoInfo, false, ConfigName);

        fSaveAnnotations =
            IniProvider.Read(SaveAnnotations, false, ConfigName);

        fSubtitleFormat =
            IniProvider.Read(SubtitleFormat, string.Empty, ConfigName);

        fDownloadLimit =
            IniProvider.Read(DownloadLimit, 0, ConfigName);

        fRetryAttempts =
            IniProvider.Read(RetryAttempts, 10, ConfigName);

        fDownloadLimitType =
            IniProvider.Read(DownloadLimitType, 1, ConfigName);

        fForceIPv4 =
            IniProvider.Read(ForceIPv4, false, ConfigName);

        fForceIPv6 =
            IniProvider.Read(ForceIPv6, false, ConfigName);

        fLimitDownloads =
            IniProvider.Read(LimitDownloads, false, ConfigName);

        fEmbedSubtitles =
            IniProvider.Read(EmbedSubtitles, false, ConfigName);

        fEmbedThumbnails =
            IniProvider.Read(EmbedThumbnails, false, ConfigName);

        fVideoDownloadSound =
            IniProvider.Read(VideoDownloadSound, true, ConfigName);

        fAudioDownloadAsVBR =
            IniProvider.Read(AudioDownloadAsVBR, false, ConfigName);

        fKeepOriginalFiles =
            IniProvider.Read(KeepOriginalFiles, false, ConfigName);

        fWriteMetadata =
            IniProvider.Read(WriteMetadata, false, ConfigName);

        fSkipBatchTip =
            IniProvider.Read(SkipBatchTip, false, ConfigName);

        fAutomaticallyDownloadFromProtocol =
            IniProvider.Read(AutomaticallyDownloadFromProtocol, true, ConfigName);

        fPreferFFmpeg =
            IniProvider.Read(PreferFFmpeg, false, ConfigName);

        fSeparateBatchDownloads =
            IniProvider.Read(SeparateBatchDownloads, true, ConfigName);

        fAddDateToBatchDownloadFolders =
            IniProvider.Read(AddDateToBatchDownloadFolders, true, ConfigName);

        int readType = IniProvider.Read(YtdlType, 0, ConfigName);
        fYtdlType = Verification.GetYoutubeDlType(readType);

        fSubdomainFolderNames =
            IniProvider.Read(SubdomainFolderNames, false, ConfigName);

        fExtendedDownloaderPreferExtendedForm =
            IniProvider.Read(ExtendedDownloaderPreferExtendedForm, false, ConfigName);

        fExtendedDownloaderAutoDownloadThumbnail =
            IniProvider.Read(ExtendedDownloaderAutoDownloadThumbnail, false, ConfigName);

        fExtendedDownloaderIncludeCustomArguments =
            IniProvider.Read(ExtendedDownloaderIncludeCustomArguments, true, ConfigName);

        fSkipUnavailableFragments =
            IniProvider.Read(SkipUnavailableFragments, true, ConfigName);

        fAbortOnError =
            IniProvider.Read(AbortOnError, true, ConfigName);

        fFragmentThreads =
            Math.Max(IniProvider.Read(FragmentThreads, 1, ConfigName), 1);
    }

    public static string downloadPath {
        get => fdownloadPath;
        set {
            if (fdownloadPath != value) {
                fdownloadPath = value;
                IniProvider.Write(downloadPath, ConfigName);
            }
        }
    }
    private static string fdownloadPath;

    public static bool separateDownloads {
        get => fseparateDownloads;
        set {
            if (fseparateDownloads != value) {
                fseparateDownloads = value;
                IniProvider.Write(separateDownloads, ConfigName);
            }
        }
    }
    private static bool fseparateDownloads;

    public static bool SaveFormatQuality {
        get => fSaveFormatQuality;
        set {
            if (fSaveFormatQuality != value) {
                fSaveFormatQuality = value;
                IniProvider.Write(SaveFormatQuality, ConfigName);
            }
        }
    }
    private static bool fSaveFormatQuality;

    public static bool deleteYtdlOnClose {
        get => fdeleteYtdlOnClose;
        set {
            if (fdeleteYtdlOnClose != value) {
                fdeleteYtdlOnClose = value;
                IniProvider.Write(deleteYtdlOnClose, ConfigName);
            }
        }
    }
    private static bool fdeleteYtdlOnClose;

    public static bool useYtdlUpdater {
        get => fuseYtdlUpdater;
        set {
            if (fuseYtdlUpdater != value) {
                fuseYtdlUpdater = value;
                IniProvider.Write(useYtdlUpdater, ConfigName);
            }
        }
    }
    private static bool fuseYtdlUpdater;

    public static string fileNameSchema {
        get => ffileNameSchema;
        set {
            if (ffileNameSchema != value) {
                ffileNameSchema = value;
                IniProvider.Write(fileNameSchema, ConfigName);
            }
        }
    }
    private static string ffileNameSchema;

    public static bool fixReddit {
        get => ffixReddit;
        set {
            if (ffixReddit != value) {
                ffixReddit = value;
                IniProvider.Write(fixReddit, ConfigName);
            }
        }
    }
    private static bool ffixReddit;

    public static bool separateIntoWebsiteURL {
        get => fseparateIntoWebsiteURL;
        set {
            if (fseparateIntoWebsiteURL != value) {
                fseparateIntoWebsiteURL = value;
                IniProvider.Write(separateIntoWebsiteURL, ConfigName);
            }
        }
    }
    private static bool fseparateIntoWebsiteURL;

    public static bool SaveSubtitles {
        get => fSaveSubtitles;
        set {
            if (fSaveSubtitles != value) {
                fSaveSubtitles = value;
                IniProvider.Write(SaveSubtitles, ConfigName);
            }
        }
    }
    private static bool fSaveSubtitles;

    public static string subtitlesLanguages {
        get => fsubtitlesLanguages;
        set {
            if (fsubtitlesLanguages != value) {
                fsubtitlesLanguages = value;
                IniProvider.Write(subtitlesLanguages, ConfigName);
            }
        }
    }
    private static string fsubtitlesLanguages;

    public static bool CloseDownloaderAfterFinish {
        get => fCloseDownloaderAfterFinish;
        set {
            if (fCloseDownloaderAfterFinish != value) {
                fCloseDownloaderAfterFinish = value;
                IniProvider.Write(CloseDownloaderAfterFinish, ConfigName);
            }
        }
    }
    private static bool fCloseDownloaderAfterFinish;

    public static bool CloseExtendedDownloaderAfterFinish {
        get => fCloseExtendedDownloaderAfterFinish;
        set {
            if (fCloseExtendedDownloaderAfterFinish != value) {
                fCloseExtendedDownloaderAfterFinish = value;
                IniProvider.Write(CloseExtendedDownloaderAfterFinish, ConfigName);
            }
        }
    }
    private static bool fCloseExtendedDownloaderAfterFinish;

    public static bool UseProxy {
        get => fUseProxy;
        set {
            if (fUseProxy != value) {
                fUseProxy = value;
                IniProvider.Write(UseProxy, ConfigName);
            }
        }
    }
    private static bool fUseProxy;

    public static int ProxyType {
        get => fProxyType;
        set {
            if (fProxyType != value) {
                fProxyType = value;
                IniProvider.Write(ProxyType, ConfigName);
            }
        }
    }
    private static int fProxyType;

    public static string ProxyIP {
        get => fProxyIP;
        set {
            if (fProxyIP != value) {
                fProxyIP = value;
                IniProvider.Write(ProxyIP, ConfigName);
            }
        }
    }
    private static string fProxyIP;

    public static string ProxyPort {
        get => fProxyPort;
        set {
            if (fProxyPort != value) {
                fProxyPort = value;
                IniProvider.Write(ProxyPort, ConfigName);
            }
        }
    }
    private static string fProxyPort;

    public static bool SaveThumbnail {
        get => fSaveThumbnail;
        set {
            if (fSaveThumbnail != value) {
                fSaveThumbnail = value;
                IniProvider.Write(SaveThumbnail, ConfigName);
            }
        }
    }
    private static bool fSaveThumbnail;

    public static bool SaveDescription {
        get => fSaveDescription;
        set {
            if (fSaveDescription != value) {
                fSaveDescription = value;
                IniProvider.Write(SaveDescription, ConfigName);
            }
        }
    }
    private static bool fSaveDescription;

    public static bool SaveVideoInfo {
        get => fSaveVideoInfo;
        set {
            if (fSaveVideoInfo != value) {
                fSaveVideoInfo = value;
                IniProvider.Write(SaveVideoInfo, ConfigName);
            }
        }
    }
    private static bool fSaveVideoInfo;

    public static bool SaveAnnotations {
        get => fSaveAnnotations;
        set {
            if (fSaveAnnotations != value) {
                fSaveAnnotations = value;
                IniProvider.Write(SaveAnnotations, ConfigName);
            }
        }
    }
    private static bool fSaveAnnotations;

    public static string SubtitleFormat {
        get => fSubtitleFormat;
        set {
            if (fSubtitleFormat != value) {
                fSubtitleFormat = value;
                IniProvider.Write(SubtitleFormat, ConfigName);
            }
        }
    }
    private static string fSubtitleFormat;

    public static int DownloadLimit {
        get => fDownloadLimit;
        set {
            if (fDownloadLimit != value) {
                fDownloadLimit = value;
                IniProvider.Write(DownloadLimit, ConfigName);
            }
        }
    }
    private static int fDownloadLimit;

    public static int RetryAttempts {
        get => fRetryAttempts;
        set {
            if (fRetryAttempts != value) {
                fRetryAttempts = value;
                IniProvider.Write(RetryAttempts, ConfigName);
            }
        }
    }
    private static int fRetryAttempts;

    public static int DownloadLimitType {
        get => fDownloadLimitType;
        set {
            if (fDownloadLimitType != value) {
                fDownloadLimitType = value;
                IniProvider.Write(DownloadLimitType, ConfigName);
            }
        }
    }
    private static int fDownloadLimitType;

    public static bool ForceIPv4 {
        get => fForceIPv4;
        set {
            if (fForceIPv4 != value) {
                fForceIPv4 = value;
                IniProvider.Write(ForceIPv4, ConfigName);
            }
        }
    }
    private static bool fForceIPv4;

    public static bool ForceIPv6 {
        get => fForceIPv6;
        set {
            if (fForceIPv6 != value) {
                fForceIPv6 = value;
                IniProvider.Write(ForceIPv6, ConfigName);
            }
        }
    }
    private static bool fForceIPv6;

    public static bool LimitDownloads {
        get => fLimitDownloads;
        set {
            if (fLimitDownloads != value) {
                fLimitDownloads = value;
                IniProvider.Write(LimitDownloads, ConfigName);
            }
        }
    }
    private static bool fLimitDownloads;

    public static bool EmbedSubtitles {
        get => fEmbedSubtitles;
        set {
            if (fEmbedSubtitles != value) {
                fEmbedSubtitles = value;
                IniProvider.Write(EmbedSubtitles, ConfigName);
            }
        }
    }
    private static bool fEmbedSubtitles;

    public static bool EmbedThumbnails {
        get => fEmbedThumbnails;
        set {
            if (fEmbedThumbnails != value) {
                fEmbedThumbnails = value;
                IniProvider.Write(EmbedThumbnails, ConfigName);
            }
        }
    }
    private static bool fEmbedThumbnails;

    public static bool VideoDownloadSound {
        get => fVideoDownloadSound;
        set {
            if (fVideoDownloadSound != value) {
                fVideoDownloadSound = value;
                IniProvider.Write(VideoDownloadSound, ConfigName);
            }
        }
    }
    private static bool fVideoDownloadSound;

    public static bool AudioDownloadAsVBR {
        get => fAudioDownloadAsVBR;
        set {
            if (fAudioDownloadAsVBR != value) {
                fAudioDownloadAsVBR = value;
                IniProvider.Write(AudioDownloadAsVBR, ConfigName);
            }
        }
    }
    private static bool fAudioDownloadAsVBR;

    public static bool KeepOriginalFiles {
        get => fKeepOriginalFiles;
        set {
            if (fKeepOriginalFiles != value) {
                fKeepOriginalFiles = value;
                IniProvider.Write(KeepOriginalFiles, ConfigName);
            }
        }
    }
    private static bool fKeepOriginalFiles;

    public static bool WriteMetadata {
        get => fWriteMetadata;
        set {
            if (fWriteMetadata != value) {
                fWriteMetadata = value;
                IniProvider.Write(WriteMetadata, ConfigName);
            }
        }
    }
    private static bool fWriteMetadata;

    public static bool SkipBatchTip {
        get => fSkipBatchTip;
        set {
            if (fSkipBatchTip != value) {
                fSkipBatchTip = value;
                IniProvider.Write(SkipBatchTip, ConfigName);
            }
        }
    }
    private static bool fSkipBatchTip;

    public static bool AutomaticallyDownloadFromProtocol {
        get => fAutomaticallyDownloadFromProtocol;
        set {
            if (fAutomaticallyDownloadFromProtocol != value) {
                fAutomaticallyDownloadFromProtocol = value;
                IniProvider.Write(AutomaticallyDownloadFromProtocol, ConfigName);
            }
        }
    }
    private static bool fAutomaticallyDownloadFromProtocol;

    public static bool PreferFFmpeg {
        get => fPreferFFmpeg;
        set {
            if (fPreferFFmpeg != value) {
                fPreferFFmpeg = value;
                IniProvider.Write(PreferFFmpeg, ConfigName);
            }
        }
    }
    private static bool fPreferFFmpeg;

    public static bool SeparateBatchDownloads {
        get => fSeparateBatchDownloads;
        set {
            if (fSeparateBatchDownloads != value) {
                fSeparateBatchDownloads = value;
                IniProvider.Write(SeparateBatchDownloads, ConfigName);
            }
        }
    }
    private static bool fSeparateBatchDownloads;

    public static bool AddDateToBatchDownloadFolders {
        get => fAddDateToBatchDownloadFolders;
        set {
            if (fAddDateToBatchDownloadFolders != value) {
                fAddDateToBatchDownloadFolders = value;
                IniProvider.Write(AddDateToBatchDownloadFolders, ConfigName);
            }
        }
    }
    private static bool fAddDateToBatchDownloadFolders;

    public static int YtdlType {
        get => fYtdlType;
        set {
            if (fYtdlType != value) {
                fYtdlType = value;
                IniProvider.Write(YtdlType, ConfigName);
            }
        }
    }
    private static int fYtdlType;

    public static bool SubdomainFolderNames {
        get => fSubdomainFolderNames;
        set {
            if (fSubdomainFolderNames != value) {
                fSubdomainFolderNames = value;
                IniProvider.Write(SubdomainFolderNames, ConfigName);
            }
        }
    }
    private static bool fSubdomainFolderNames;

    public static bool ExtendedDownloaderPreferExtendedForm {
        get => fExtendedDownloaderPreferExtendedForm;
        set {
            if (fExtendedDownloaderPreferExtendedForm != value) {
                fExtendedDownloaderPreferExtendedForm = value;
                IniProvider.Write(ExtendedDownloaderPreferExtendedForm, ConfigName);
            }
        }
    }
    private static bool fExtendedDownloaderPreferExtendedForm;

    public static bool ExtendedDownloaderAutoDownloadThumbnail {
        get => fExtendedDownloaderAutoDownloadThumbnail;
        set {
            if (fExtendedDownloaderAutoDownloadThumbnail != value) {
                fExtendedDownloaderAutoDownloadThumbnail = value;
                IniProvider.Write(ExtendedDownloaderAutoDownloadThumbnail, ConfigName);
            }
        }
    }
    private static bool fExtendedDownloaderAutoDownloadThumbnail;

    public static bool ExtendedDownloaderIncludeCustomArguments {
        get => fExtendedDownloaderIncludeCustomArguments;
        set {
            if (fExtendedDownloaderIncludeCustomArguments != value) {
                fExtendedDownloaderIncludeCustomArguments = value;
                IniProvider.Write(ExtendedDownloaderIncludeCustomArguments, ConfigName);
            }
        }
    }
    private static bool fExtendedDownloaderIncludeCustomArguments;

    public static bool SkipUnavailableFragments {
        get => fSkipUnavailableFragments;
        set {
            if (fSkipUnavailableFragments != value) {
                fSkipUnavailableFragments = value;
                IniProvider.Write(SkipUnavailableFragments, ConfigName);
            }
        }
    }
    private static bool fSkipUnavailableFragments;

    public static bool AbortOnError {
        get => fAbortOnError;
        set {
            if (fAbortOnError != value) {
                fAbortOnError = value;
                IniProvider.Write(AbortOnError, ConfigName);
            }
        }
    }
    private static bool fAbortOnError;

    public static int FragmentThreads {
        get => fFragmentThreads;
        set {
            if (fFragmentThreads != value) {
                fFragmentThreads = value;
                IniProvider.Write(FragmentThreads, ConfigName);
            }
        }
    }
    private static int fFragmentThreads;
}