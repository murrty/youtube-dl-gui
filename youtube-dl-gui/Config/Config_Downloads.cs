namespace youtube_dl_gui;

internal class Config_Downloads {
    private const string ConfigName = "Downloads";

    #region Variables
    public string downloadPath = string.Empty;
    public bool separateDownloads = true;
    public bool SaveFormatQuality = true;
    public bool deleteYtdlOnClose = false;
    public bool useYtdlUpdater = false;
    public string fileNameSchema = "%(title)s-%(id)s.%(ext)s";
    public bool fixReddit = true;
    public bool separateIntoWebsiteURL = true;
    public bool SaveSubtitles = false;
    public string subtitlesLanguages = "en";
    public bool CloseDownloaderAfterFinish = true;
    public bool UseProxy = false;
    public int ProxyType = -1;
    public string ProxyIP = string.Empty;
    public string ProxyPort = string.Empty;
    public bool SaveThumbnail = false;
    public bool SaveDescription = false;
    public bool SaveVideoInfo = false;
    public bool SaveAnnotations = false;
    public string SubtitleFormat = string.Empty;
    public int DownloadLimit = 0;
    public int RetryAttempts = 10;
    public int DownloadLimitType = 1;
    public bool ForceIPv4 = false;
    public bool ForceIPv6 = false;
    public bool LimitDownloads = false;
    public bool EmbedSubtitles = false;
    public bool EmbedThumbnails = false;
    public bool VideoDownloadSound = true;
    public bool AudioDownloadAsVBR = false;
    public bool KeepOriginalFiles = false;
    public bool WriteMetadata = false;
    public bool SkipBatchTip = false;
    public bool AutomaticallyDownloadFromProtocol = true;
    public bool PreferFFmpeg = true;
    public bool SeparateBatchDownloads = true;
    public bool AddDateToBatchDownloadFolders = true;
    public int YtdlType = 0;
    public bool SubdomainFolderNames = false;
    public bool ExtendedDownloaderPreferExtendedForm = false;
    public bool ExtendedDownloaderAutoDownloadThumbnail = false;

    private string fdownloadPath = string.Empty;
    private bool fseparateDownloads = true;
    private bool fSaveFormatQuality = true;
    private bool fdeleteYtdlOnClose = false;
    private bool fuseYtdlUpdater = false;
    private string ffileNameSchema = "%(title)s-%(id)s.%(ext)s";
    private bool ffixReddit = true;
    private bool fseparateIntoWebsiteURL = true;
    private bool fSaveSubtitles = false;
    private string fsubtitlesLanguages = "en";
    private bool fCloseDownloaderAfterFinish = true;
    private bool fUseProxy = false;
    private int fProxyType = -1;
    private string fProxyIP = string.Empty;
    private string fProxyPort = string.Empty;
    private bool fSaveThumbnail = false;
    private bool fSaveDescription = false;
    private bool fSaveVideoInfo = false;
    private bool fSaveAnnotations = false;
    private string fSubtitleFormat = string.Empty;
    private int fDownloadLimit = 0;
    private int fRetryAttempts = 10;
    private int fDownloadLimitType = 1;
    private bool fForceIPv4 = false;
    private bool fForceIPv6 = false;
    private bool fLimitDownloads = false;
    private bool fEmbedSubtitles = false;
    private bool fEmbedThumbnails = false;
    private bool fVideoDownloadSound = true;
    private bool fAudioDownloadAsVBR = false;
    private bool fKeepOriginalFiles = false;
    private bool fWriteMetadata = false;
    private bool fSkipBatchTip = false;
    private bool fAutomaticallyDownloadFromProtocol = true;
    private bool fPreferFFmpeg = true;
    private bool fSeparateBatchDownloads = true;
    private bool fAddDateToBatchDownloadFolders = true;
    private int fYtdlType = 0;
    private bool fSubdomainFolderNames = false;
    private bool fExtendedDownloaderPreferExtendedForm = false;
    private bool fExtendedDownloaderAutoDownloadThumbnail = false;
    #endregion

    public void Load() {
        Log.Write("Loading Download config.");

        downloadPath = fdownloadPath = Ini.Read(downloadPath, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\youtube-dl", ConfigName);
        separateDownloads = fseparateDownloads = Ini.Read(separateDownloads, true, ConfigName);
        SaveFormatQuality = fSaveFormatQuality = Ini.Read(SaveFormatQuality, true, ConfigName);
        deleteYtdlOnClose = fdeleteYtdlOnClose = Ini.Read(deleteYtdlOnClose, false, ConfigName);
        useYtdlUpdater = fuseYtdlUpdater = Ini.Read(useYtdlUpdater, false, ConfigName);
        fileNameSchema = ffileNameSchema = Ini.Read(fileNameSchema, "%(title)s-%(id)s.%(ext)s", ConfigName);
        fixReddit = ffixReddit = Ini.Read(fixReddit, true, ConfigName);
        separateIntoWebsiteURL = fseparateIntoWebsiteURL = Ini.Read(separateIntoWebsiteURL, true, ConfigName);
        SaveSubtitles = fSaveSubtitles = Ini.Read(SaveSubtitles, false, ConfigName);
        subtitlesLanguages = fsubtitlesLanguages = Ini.Read(subtitlesLanguages, "en", ConfigName);
        CloseDownloaderAfterFinish = fCloseDownloaderAfterFinish = Ini.Read(CloseDownloaderAfterFinish, true, ConfigName);
        UseProxy = fUseProxy = Ini.Read(UseProxy, false, ConfigName);
        ProxyType = fProxyType = Ini.Read(ProxyType, -1, ConfigName);
        ProxyIP = fProxyIP = Ini.Read(ProxyIP, string.Empty, ConfigName);
        ProxyPort = fProxyPort = Ini.Read(ProxyPort, string.Empty, ConfigName);
        SaveThumbnail = fSaveThumbnail = Ini.Read(SaveThumbnail, false, ConfigName);
        SaveDescription = fSaveDescription = Ini.Read(SaveDescription, false, ConfigName);
        SaveVideoInfo = fSaveVideoInfo = Ini.Read(SaveVideoInfo, false, ConfigName);
        SaveAnnotations = fSaveAnnotations = Ini.Read(SaveAnnotations, false, ConfigName);
        SubtitleFormat = fSubtitleFormat = Ini.Read(SubtitleFormat, string.Empty, ConfigName);
        DownloadLimit = fDownloadLimit = Ini.Read(DownloadLimit, 0, ConfigName);
        RetryAttempts = fRetryAttempts = Ini.Read(RetryAttempts, 10, ConfigName);
        DownloadLimitType = fDownloadLimitType = Ini.Read(DownloadLimitType, 1, ConfigName);
        ForceIPv4 = fForceIPv4 = Ini.Read(ForceIPv4, false, ConfigName);
        ForceIPv6 = fForceIPv6 = Ini.Read(ForceIPv6, false, ConfigName);
        LimitDownloads = fLimitDownloads = Ini.Read(LimitDownloads, false, ConfigName);
        EmbedSubtitles = fEmbedSubtitles = Ini.Read(EmbedSubtitles, false, ConfigName);
        EmbedThumbnails = fEmbedThumbnails = Ini.Read(EmbedThumbnails, false, ConfigName);
        VideoDownloadSound = fVideoDownloadSound = Ini.Read(VideoDownloadSound, true, ConfigName);
        AudioDownloadAsVBR = fAudioDownloadAsVBR = Ini.Read(AudioDownloadAsVBR, false, ConfigName);
        KeepOriginalFiles = fKeepOriginalFiles = Ini.Read(KeepOriginalFiles, false, ConfigName);
        WriteMetadata = fWriteMetadata = Ini.Read(WriteMetadata, false, ConfigName);
        SkipBatchTip = fSkipBatchTip = Ini.Read(SkipBatchTip, false, ConfigName);
        AutomaticallyDownloadFromProtocol = fAutomaticallyDownloadFromProtocol = Ini.Read(AutomaticallyDownloadFromProtocol, true, ConfigName);
        PreferFFmpeg = fPreferFFmpeg = Ini.Read(PreferFFmpeg, true, ConfigName);
        SeparateBatchDownloads = fSeparateBatchDownloads = Ini.Read(SeparateBatchDownloads, true, ConfigName);
        AddDateToBatchDownloadFolders = fAddDateToBatchDownloadFolders = Ini.Read(AddDateToBatchDownloadFolders, true, ConfigName);
        YtdlType = fYtdlType = Ini.Read(YtdlType, 0, ConfigName) switch {
            1 => 1,
            2 => 2,
            _ => 0,
        };
        SubdomainFolderNames = fSubdomainFolderNames = Ini.Read(SubdomainFolderNames, false, ConfigName);
        ExtendedDownloaderPreferExtendedForm = fExtendedDownloaderPreferExtendedForm = Ini.Read(ExtendedDownloaderPreferExtendedForm, false, ConfigName);
        ExtendedDownloaderAutoDownloadThumbnail = fExtendedDownloaderAutoDownloadThumbnail = Ini.Read(ExtendedDownloaderAutoDownloadThumbnail, false, ConfigName);
    }

    public void Save() {
        Log.Write("Saving Download config.");

        if (downloadPath != fdownloadPath)
            fdownloadPath = Ini.Write(downloadPath, ConfigName);
        if (separateDownloads != fseparateDownloads)
            fseparateDownloads = Ini.Write(separateDownloads, ConfigName);
        if (SaveFormatQuality != fSaveFormatQuality)
            fSaveFormatQuality = Ini.Write(SaveFormatQuality, ConfigName);
        if (deleteYtdlOnClose != fdeleteYtdlOnClose)
            fdeleteYtdlOnClose = Ini.Write(deleteYtdlOnClose, ConfigName);
        if (useYtdlUpdater != fuseYtdlUpdater)
            fuseYtdlUpdater = Ini.Write(useYtdlUpdater, ConfigName);
        if (fileNameSchema != ffileNameSchema)
            ffileNameSchema = Ini.Write(fileNameSchema, ConfigName);
        if (fixReddit != ffixReddit)
            ffixReddit = Ini.Write(fixReddit, ConfigName);
        if (separateIntoWebsiteURL != fseparateIntoWebsiteURL)
            fseparateIntoWebsiteURL = Ini.Write(separateIntoWebsiteURL, ConfigName);
        if (SaveSubtitles != fSaveSubtitles)
            fSaveSubtitles = Ini.Write(SaveSubtitles, ConfigName);
        if (subtitlesLanguages != fsubtitlesLanguages)
            fsubtitlesLanguages = Ini.Write(subtitlesLanguages, ConfigName);
        if (CloseDownloaderAfterFinish != fCloseDownloaderAfterFinish)
            fCloseDownloaderAfterFinish = Ini.Write(CloseDownloaderAfterFinish, ConfigName);
        if (UseProxy != fUseProxy)
            fUseProxy = Ini.Write(UseProxy, ConfigName);
        if (ProxyType != fProxyType)
            fProxyType = Ini.Write(ProxyType, ConfigName);
        if (ProxyIP != fProxyIP)
            fProxyIP = Ini.Write(ProxyIP, ConfigName);
        if (ProxyPort != fProxyPort)
            fProxyPort = Ini.Write(ProxyPort, ConfigName);
        if (SaveThumbnail != fSaveThumbnail)
            fSaveThumbnail = Ini.Write(SaveThumbnail, ConfigName);
        if (SaveDescription != fSaveDescription)
            fSaveDescription = Ini.Write(SaveDescription, ConfigName);
        if (SaveVideoInfo != fSaveVideoInfo)
            fSaveVideoInfo = Ini.Write(SaveVideoInfo, ConfigName);
        if (SaveAnnotations != fSaveAnnotations)
            fSaveAnnotations = Ini.Write(SaveAnnotations, ConfigName);
        if (SubtitleFormat != fSubtitleFormat)
            fSubtitleFormat = Ini.Write(SubtitleFormat, ConfigName);
        if (DownloadLimit != fDownloadLimit)
            fDownloadLimit = Ini.Write(DownloadLimit, ConfigName);
        if (RetryAttempts != fRetryAttempts)
            fRetryAttempts = Ini.Write(RetryAttempts, ConfigName);
        if (DownloadLimitType != fDownloadLimitType)
            fDownloadLimitType = Ini.Write(DownloadLimitType, ConfigName);
        if (ForceIPv4 != fForceIPv4)
            fForceIPv4 = Ini.Write(ForceIPv4, ConfigName);
        if (ForceIPv6 != fForceIPv6)
            fForceIPv6 = Ini.Write(ForceIPv6, ConfigName);
        if (LimitDownloads != fLimitDownloads)
            fLimitDownloads = Ini.Write(LimitDownloads, ConfigName);
        if (EmbedSubtitles != fEmbedSubtitles)
            fEmbedSubtitles = Ini.Write(EmbedSubtitles, ConfigName);
        if (EmbedThumbnails != fEmbedThumbnails)
            fEmbedThumbnails = Ini.Write(EmbedThumbnails, ConfigName);
        if (VideoDownloadSound != fVideoDownloadSound)
            fVideoDownloadSound = Ini.Write(VideoDownloadSound, ConfigName);
        if (AudioDownloadAsVBR != fAudioDownloadAsVBR)
            fAudioDownloadAsVBR = Ini.Write(AudioDownloadAsVBR, ConfigName);
        if (KeepOriginalFiles != fKeepOriginalFiles)
            fKeepOriginalFiles = Ini.Write(KeepOriginalFiles, ConfigName);
        if (WriteMetadata != fWriteMetadata)
            fWriteMetadata = Ini.Write(WriteMetadata, ConfigName);
        if (SkipBatchTip != fSkipBatchTip)
            fSkipBatchTip = Ini.Write(SkipBatchTip, ConfigName);
        if (AutomaticallyDownloadFromProtocol != fAutomaticallyDownloadFromProtocol)
            fAutomaticallyDownloadFromProtocol = Ini.Write(AutomaticallyDownloadFromProtocol, ConfigName);
        if (PreferFFmpeg != fPreferFFmpeg)
            fPreferFFmpeg = Ini.Write(PreferFFmpeg, ConfigName);
        if (SeparateBatchDownloads != fSeparateBatchDownloads)
            fSeparateBatchDownloads = Ini.Write(SeparateBatchDownloads, ConfigName);
        if (AddDateToBatchDownloadFolders != fAddDateToBatchDownloadFolders)
            fAddDateToBatchDownloadFolders = Ini.Write(AddDateToBatchDownloadFolders, ConfigName);
        if (YtdlType != fYtdlType)
            fYtdlType = Ini.Write(YtdlType, ConfigName);
        if (SubdomainFolderNames != fSubdomainFolderNames)
            fSubdomainFolderNames = Ini.Write(SubdomainFolderNames, ConfigName);
        if (ExtendedDownloaderPreferExtendedForm != fExtendedDownloaderPreferExtendedForm)
            fExtendedDownloaderPreferExtendedForm = Ini.Write(ExtendedDownloaderPreferExtendedForm, ConfigName);
        if (ExtendedDownloaderAutoDownloadThumbnail != fExtendedDownloaderAutoDownloadThumbnail)
            fExtendedDownloaderAutoDownloadThumbnail = Ini.Write(ExtendedDownloaderAutoDownloadThumbnail, ConfigName);
    }
}