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

        downloadPath = fdownloadPath = IniProvider.Read(downloadPath, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\youtube-dl", ConfigName);
        separateDownloads = fseparateDownloads = IniProvider.Read(separateDownloads, true, ConfigName);
        SaveFormatQuality = fSaveFormatQuality = IniProvider.Read(SaveFormatQuality, true, ConfigName);
        deleteYtdlOnClose = fdeleteYtdlOnClose = IniProvider.Read(deleteYtdlOnClose, false, ConfigName);
        useYtdlUpdater = fuseYtdlUpdater = IniProvider.Read(useYtdlUpdater, false, ConfigName);
        fileNameSchema = ffileNameSchema = IniProvider.Read(fileNameSchema, "%(title)s-%(id)s.%(ext)s", ConfigName);
        fixReddit = ffixReddit = IniProvider.Read(fixReddit, true, ConfigName);
        separateIntoWebsiteURL = fseparateIntoWebsiteURL = IniProvider.Read(separateIntoWebsiteURL, true, ConfigName);
        SaveSubtitles = fSaveSubtitles = IniProvider.Read(SaveSubtitles, false, ConfigName);
        subtitlesLanguages = fsubtitlesLanguages = IniProvider.Read(subtitlesLanguages, "en", ConfigName);
        CloseDownloaderAfterFinish = fCloseDownloaderAfterFinish = IniProvider.Read(CloseDownloaderAfterFinish, true, ConfigName);
        UseProxy = fUseProxy = IniProvider.Read(UseProxy, false, ConfigName);
        ProxyType = fProxyType = IniProvider.Read(ProxyType, -1, ConfigName);
        ProxyIP = fProxyIP = IniProvider.Read(ProxyIP, string.Empty, ConfigName);
        ProxyPort = fProxyPort = IniProvider.Read(ProxyPort, string.Empty, ConfigName);
        SaveThumbnail = fSaveThumbnail = IniProvider.Read(SaveThumbnail, false, ConfigName);
        SaveDescription = fSaveDescription = IniProvider.Read(SaveDescription, false, ConfigName);
        SaveVideoInfo = fSaveVideoInfo = IniProvider.Read(SaveVideoInfo, false, ConfigName);
        SaveAnnotations = fSaveAnnotations = IniProvider.Read(SaveAnnotations, false, ConfigName);
        SubtitleFormat = fSubtitleFormat = IniProvider.Read(SubtitleFormat, string.Empty, ConfigName);
        DownloadLimit = fDownloadLimit = IniProvider.Read(DownloadLimit, 0, ConfigName);
        RetryAttempts = fRetryAttempts = IniProvider.Read(RetryAttempts, 10, ConfigName);
        DownloadLimitType = fDownloadLimitType = IniProvider.Read(DownloadLimitType, 1, ConfigName);
        ForceIPv4 = fForceIPv4 = IniProvider.Read(ForceIPv4, false, ConfigName);
        ForceIPv6 = fForceIPv6 = IniProvider.Read(ForceIPv6, false, ConfigName);
        LimitDownloads = fLimitDownloads = IniProvider.Read(LimitDownloads, false, ConfigName);
        EmbedSubtitles = fEmbedSubtitles = IniProvider.Read(EmbedSubtitles, false, ConfigName);
        EmbedThumbnails = fEmbedThumbnails = IniProvider.Read(EmbedThumbnails, false, ConfigName);
        VideoDownloadSound = fVideoDownloadSound = IniProvider.Read(VideoDownloadSound, true, ConfigName);
        AudioDownloadAsVBR = fAudioDownloadAsVBR = IniProvider.Read(AudioDownloadAsVBR, false, ConfigName);
        KeepOriginalFiles = fKeepOriginalFiles = IniProvider.Read(KeepOriginalFiles, false, ConfigName);
        WriteMetadata = fWriteMetadata = IniProvider.Read(WriteMetadata, false, ConfigName);
        SkipBatchTip = fSkipBatchTip = IniProvider.Read(SkipBatchTip, false, ConfigName);
        AutomaticallyDownloadFromProtocol = fAutomaticallyDownloadFromProtocol = IniProvider.Read(AutomaticallyDownloadFromProtocol, true, ConfigName);
        PreferFFmpeg = fPreferFFmpeg = IniProvider.Read(PreferFFmpeg, true, ConfigName);
        SeparateBatchDownloads = fSeparateBatchDownloads = IniProvider.Read(SeparateBatchDownloads, true, ConfigName);
        AddDateToBatchDownloadFolders = fAddDateToBatchDownloadFolders = IniProvider.Read(AddDateToBatchDownloadFolders, true, ConfigName);
        YtdlType = fYtdlType = IniProvider.Read(YtdlType, 0, ConfigName) switch {
            1 => 1,
            2 => 2,
            _ => 0,
        };
        SubdomainFolderNames = fSubdomainFolderNames = IniProvider.Read(SubdomainFolderNames, false, ConfigName);
        ExtendedDownloaderPreferExtendedForm = fExtendedDownloaderPreferExtendedForm = IniProvider.Read(ExtendedDownloaderPreferExtendedForm, false, ConfigName);
        ExtendedDownloaderAutoDownloadThumbnail = fExtendedDownloaderAutoDownloadThumbnail = IniProvider.Read(ExtendedDownloaderAutoDownloadThumbnail, false, ConfigName);
    }

    public void Save() {
        Log.Write("Saving Download config.");

        if (downloadPath != fdownloadPath)
            fdownloadPath = IniProvider.Write(downloadPath, ConfigName);
        if (separateDownloads != fseparateDownloads)
            fseparateDownloads = IniProvider.Write(separateDownloads, ConfigName);
        if (SaveFormatQuality != fSaveFormatQuality)
            fSaveFormatQuality = IniProvider.Write(SaveFormatQuality, ConfigName);
        if (deleteYtdlOnClose != fdeleteYtdlOnClose)
            fdeleteYtdlOnClose = IniProvider.Write(deleteYtdlOnClose, ConfigName);
        if (useYtdlUpdater != fuseYtdlUpdater)
            fuseYtdlUpdater = IniProvider.Write(useYtdlUpdater, ConfigName);
        if (fileNameSchema != ffileNameSchema)
            ffileNameSchema = IniProvider.Write(fileNameSchema, ConfigName);
        if (fixReddit != ffixReddit)
            ffixReddit = IniProvider.Write(fixReddit, ConfigName);
        if (separateIntoWebsiteURL != fseparateIntoWebsiteURL)
            fseparateIntoWebsiteURL = IniProvider.Write(separateIntoWebsiteURL, ConfigName);
        if (SaveSubtitles != fSaveSubtitles)
            fSaveSubtitles = IniProvider.Write(SaveSubtitles, ConfigName);
        if (subtitlesLanguages != fsubtitlesLanguages)
            fsubtitlesLanguages = IniProvider.Write(subtitlesLanguages, ConfigName);
        if (CloseDownloaderAfterFinish != fCloseDownloaderAfterFinish)
            fCloseDownloaderAfterFinish = IniProvider.Write(CloseDownloaderAfterFinish, ConfigName);
        if (UseProxy != fUseProxy)
            fUseProxy = IniProvider.Write(UseProxy, ConfigName);
        if (ProxyType != fProxyType)
            fProxyType = IniProvider.Write(ProxyType, ConfigName);
        if (ProxyIP != fProxyIP)
            fProxyIP = IniProvider.Write(ProxyIP, ConfigName);
        if (ProxyPort != fProxyPort)
            fProxyPort = IniProvider.Write(ProxyPort, ConfigName);
        if (SaveThumbnail != fSaveThumbnail)
            fSaveThumbnail = IniProvider.Write(SaveThumbnail, ConfigName);
        if (SaveDescription != fSaveDescription)
            fSaveDescription = IniProvider.Write(SaveDescription, ConfigName);
        if (SaveVideoInfo != fSaveVideoInfo)
            fSaveVideoInfo = IniProvider.Write(SaveVideoInfo, ConfigName);
        if (SaveAnnotations != fSaveAnnotations)
            fSaveAnnotations = IniProvider.Write(SaveAnnotations, ConfigName);
        if (SubtitleFormat != fSubtitleFormat)
            fSubtitleFormat = IniProvider.Write(SubtitleFormat, ConfigName);
        if (DownloadLimit != fDownloadLimit)
            fDownloadLimit = IniProvider.Write(DownloadLimit, ConfigName);
        if (RetryAttempts != fRetryAttempts)
            fRetryAttempts = IniProvider.Write(RetryAttempts, ConfigName);
        if (DownloadLimitType != fDownloadLimitType)
            fDownloadLimitType = IniProvider.Write(DownloadLimitType, ConfigName);
        if (ForceIPv4 != fForceIPv4)
            fForceIPv4 = IniProvider.Write(ForceIPv4, ConfigName);
        if (ForceIPv6 != fForceIPv6)
            fForceIPv6 = IniProvider.Write(ForceIPv6, ConfigName);
        if (LimitDownloads != fLimitDownloads)
            fLimitDownloads = IniProvider.Write(LimitDownloads, ConfigName);
        if (EmbedSubtitles != fEmbedSubtitles)
            fEmbedSubtitles = IniProvider.Write(EmbedSubtitles, ConfigName);
        if (EmbedThumbnails != fEmbedThumbnails)
            fEmbedThumbnails = IniProvider.Write(EmbedThumbnails, ConfigName);
        if (VideoDownloadSound != fVideoDownloadSound)
            fVideoDownloadSound = IniProvider.Write(VideoDownloadSound, ConfigName);
        if (AudioDownloadAsVBR != fAudioDownloadAsVBR)
            fAudioDownloadAsVBR = IniProvider.Write(AudioDownloadAsVBR, ConfigName);
        if (KeepOriginalFiles != fKeepOriginalFiles)
            fKeepOriginalFiles = IniProvider.Write(KeepOriginalFiles, ConfigName);
        if (WriteMetadata != fWriteMetadata)
            fWriteMetadata = IniProvider.Write(WriteMetadata, ConfigName);
        if (SkipBatchTip != fSkipBatchTip)
            fSkipBatchTip = IniProvider.Write(SkipBatchTip, ConfigName);
        if (AutomaticallyDownloadFromProtocol != fAutomaticallyDownloadFromProtocol)
            fAutomaticallyDownloadFromProtocol = IniProvider.Write(AutomaticallyDownloadFromProtocol, ConfigName);
        if (PreferFFmpeg != fPreferFFmpeg)
            fPreferFFmpeg = IniProvider.Write(PreferFFmpeg, ConfigName);
        if (SeparateBatchDownloads != fSeparateBatchDownloads)
            fSeparateBatchDownloads = IniProvider.Write(SeparateBatchDownloads, ConfigName);
        if (AddDateToBatchDownloadFolders != fAddDateToBatchDownloadFolders)
            fAddDateToBatchDownloadFolders = IniProvider.Write(AddDateToBatchDownloadFolders, ConfigName);
        if (YtdlType != fYtdlType)
            fYtdlType = IniProvider.Write(YtdlType, ConfigName);
        if (SubdomainFolderNames != fSubdomainFolderNames)
            fSubdomainFolderNames = IniProvider.Write(SubdomainFolderNames, ConfigName);
        if (ExtendedDownloaderPreferExtendedForm != fExtendedDownloaderPreferExtendedForm)
            fExtendedDownloaderPreferExtendedForm = IniProvider.Write(ExtendedDownloaderPreferExtendedForm, ConfigName);
        if (ExtendedDownloaderAutoDownloadThumbnail != fExtendedDownloaderAutoDownloadThumbnail)
            fExtendedDownloaderAutoDownloadThumbnail = IniProvider.Write(ExtendedDownloaderAutoDownloadThumbnail, ConfigName);
    }
}