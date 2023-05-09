namespace youtube_dl_gui;

internal class Config_Downloads {
    private const string ConfigName = "Downloads";

    #region Properties
    public string downloadPath { get; set; }
    public bool separateDownloads { get; set; }
    public bool SaveFormatQuality { get; set; }
    public bool deleteYtdlOnClose { get; set; }
    public bool useYtdlUpdater { get; set; }
    public string fileNameSchema { get; set; }
    public bool fixReddit { get; set; }
    public bool separateIntoWebsiteURL { get; set; }
    public bool SaveSubtitles { get; set; }
    public string subtitlesLanguages { get; set; }
    public bool CloseDownloaderAfterFinish { get; set; }
    public bool CloseExtendedDownloaderAfterFinish { get; set; }
    public bool UseProxy { get; set; }
    public int ProxyType { get; set; }
    public string ProxyIP { get; set; }
    public string ProxyPort { get; set; }
    public bool SaveThumbnail { get; set; }
    public bool SaveDescription { get; set; }
    public bool SaveVideoInfo { get; set; }
    public bool SaveAnnotations { get; set; }
    public string SubtitleFormat { get; set; }
    public int DownloadLimit { get; set; }
    public int RetryAttempts { get; set; }
    public int DownloadLimitType { get; set; }
    public bool ForceIPv4 { get; set; }
    public bool ForceIPv6 { get; set; }
    public bool LimitDownloads { get; set; }
    public bool EmbedSubtitles { get; set; }
    public bool EmbedThumbnails { get; set; }
    public bool VideoDownloadSound { get; set; }
    public bool AudioDownloadAsVBR { get; set; }
    public bool KeepOriginalFiles { get; set; }
    public bool WriteMetadata { get; set; }
    public bool SkipBatchTip { get; set; }
    public bool AutomaticallyDownloadFromProtocol { get; set; }
    public bool PreferFFmpeg { get; set; }
    public bool SeparateBatchDownloads { get; set; }
    public bool AddDateToBatchDownloadFolders { get; set; }
    public int YtdlType { get; set; }
    public bool SubdomainFolderNames { get; set; }
    public bool ExtendedDownloaderPreferExtendedForm { get; set; }
    public bool ExtendedDownloaderAutoDownloadThumbnail { get; set; }
    public bool ExtendedDownloaderIncludeCustomArguments { get; set; }
    public bool AbortForUnavailableFragments { get; set; }
    public bool AbortOnError { get; set; }
    public int FragmentThreads { get; set; }

    private string fdownloadPath { get; set; }
    private bool fseparateDownloads { get; set; }
    private bool fSaveFormatQuality { get; set; }
    private bool fdeleteYtdlOnClose { get; set; }
    private bool fuseYtdlUpdater { get; set; }
    private string ffileNameSchema { get; set; }
    private bool ffixReddit { get; set; }
    private bool fseparateIntoWebsiteURL { get; set; }
    private bool fSaveSubtitles { get; set; }
    private string fsubtitlesLanguages { get; set; }
    private bool fCloseDownloaderAfterFinish { get; set; }
    private bool fCloseExtendedDownloaderAfterFinish { get; set; }
    private bool fUseProxy { get; set; }
    private int fProxyType { get; set; }
    private string fProxyIP { get; set; }
    private string fProxyPort { get; set; }
    private bool fSaveThumbnail { get; set; }
    private bool fSaveDescription { get; set; }
    private bool fSaveVideoInfo { get; set; }
    private bool fSaveAnnotations { get; set; }
    private string fSubtitleFormat { get; set; }
    private int fDownloadLimit { get; set; }
    private int fRetryAttempts { get; set; }
    private int fDownloadLimitType { get; set; }
    private bool fForceIPv4 { get; set; }
    private bool fForceIPv6 { get; set; }
    private bool fLimitDownloads { get; set; }
    private bool fEmbedSubtitles { get; set; }
    private bool fEmbedThumbnails { get; set; }
    private bool fVideoDownloadSound { get; set; }
    private bool fAudioDownloadAsVBR { get; set; }
    private bool fKeepOriginalFiles { get; set; }
    private bool fWriteMetadata { get; set; }
    private bool fSkipBatchTip { get; set; }
    private bool fAutomaticallyDownloadFromProtocol { get; set; }
    private bool fPreferFFmpeg { get; set; }
    private bool fSeparateBatchDownloads { get; set; }
    private bool fAddDateToBatchDownloadFolders { get; set; }
    private int fYtdlType { get; set; }
    private bool fSubdomainFolderNames { get; set; }
    private bool fExtendedDownloaderPreferExtendedForm { get; set; }
    private bool fExtendedDownloaderAutoDownloadThumbnail { get; set; }
    private bool fExtendedDownloaderIncludeCustomArguments { get; set; }
    public bool fAbortForUnavailableFragments { get; set; }
    public bool fAbortOnError { get; set; }
    public int fFragmentThreads { get; set; }
    #endregion

    public void Load() {
        Log.Write("Loading Download config.");

        downloadPath = fdownloadPath =
            IniProvider.Read(downloadPath, Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\youtube-dl", ConfigName);

        separateDownloads = fseparateDownloads =
            IniProvider.Read(separateDownloads, true, ConfigName);

        SaveFormatQuality = fSaveFormatQuality =
            IniProvider.Read(SaveFormatQuality, true, ConfigName);

        deleteYtdlOnClose = fdeleteYtdlOnClose =
            IniProvider.Read(deleteYtdlOnClose, false, ConfigName);

        useYtdlUpdater = fuseYtdlUpdater =
            IniProvider.Read(useYtdlUpdater, false, ConfigName);

        fileNameSchema = ffileNameSchema =
            IniProvider.Read(fileNameSchema, "%(title)s-%(id)s.%(ext)s", ConfigName);

        fixReddit = ffixReddit =
            IniProvider.Read(fixReddit, true, ConfigName);

        separateIntoWebsiteURL = fseparateIntoWebsiteURL =
            IniProvider.Read(separateIntoWebsiteURL, true, ConfigName);

        SaveSubtitles = fSaveSubtitles =
            IniProvider.Read(SaveSubtitles, false, ConfigName);

        subtitlesLanguages = fsubtitlesLanguages =
            IniProvider.Read(subtitlesLanguages, "en", ConfigName);

        CloseDownloaderAfterFinish = fCloseDownloaderAfterFinish =
            IniProvider.Read(CloseDownloaderAfterFinish, true, ConfigName);

        CloseExtendedDownloaderAfterFinish = fCloseExtendedDownloaderAfterFinish =
            IniProvider.Read(CloseExtendedDownloaderAfterFinish, false, ConfigName);

        UseProxy = fUseProxy =
            IniProvider.Read(UseProxy, false, ConfigName);

        ProxyType = fProxyType =
            IniProvider.Read(ProxyType, -1, ConfigName);

        ProxyIP = fProxyIP =
            IniProvider.Read(ProxyIP, string.Empty, ConfigName);

        ProxyPort = fProxyPort =
            IniProvider.Read(ProxyPort, string.Empty, ConfigName);

        SaveThumbnail = fSaveThumbnail =
            IniProvider.Read(SaveThumbnail, false, ConfigName);

        SaveDescription = fSaveDescription =
            IniProvider.Read(SaveDescription, false, ConfigName);

        SaveVideoInfo = fSaveVideoInfo =
            IniProvider.Read(SaveVideoInfo, false, ConfigName);

        SaveAnnotations = fSaveAnnotations =
            IniProvider.Read(SaveAnnotations, false, ConfigName);

        SubtitleFormat = fSubtitleFormat =
            IniProvider.Read(SubtitleFormat, string.Empty, ConfigName);

        DownloadLimit = fDownloadLimit =
            IniProvider.Read(DownloadLimit, 0, ConfigName);

        RetryAttempts = fRetryAttempts =
            IniProvider.Read(RetryAttempts, 10, ConfigName);

        DownloadLimitType = fDownloadLimitType =
            IniProvider.Read(DownloadLimitType, 1, ConfigName);

        ForceIPv4 = fForceIPv4 =
            IniProvider.Read(ForceIPv4, false, ConfigName);

        ForceIPv6 = fForceIPv6 =
            IniProvider.Read(ForceIPv6, false, ConfigName);

        LimitDownloads = fLimitDownloads =
            IniProvider.Read(LimitDownloads, false, ConfigName);

        EmbedSubtitles = fEmbedSubtitles =
            IniProvider.Read(EmbedSubtitles, false, ConfigName);

        EmbedThumbnails = fEmbedThumbnails =
            IniProvider.Read(EmbedThumbnails, false, ConfigName);

        VideoDownloadSound = fVideoDownloadSound =
            IniProvider.Read(VideoDownloadSound, true, ConfigName);

        AudioDownloadAsVBR = fAudioDownloadAsVBR =
            IniProvider.Read(AudioDownloadAsVBR, false, ConfigName);

        KeepOriginalFiles = fKeepOriginalFiles =
            IniProvider.Read(KeepOriginalFiles, false, ConfigName);

        WriteMetadata = fWriteMetadata =
            IniProvider.Read(WriteMetadata, false, ConfigName);

        SkipBatchTip = fSkipBatchTip =
            IniProvider.Read(SkipBatchTip, false, ConfigName);

        AutomaticallyDownloadFromProtocol = fAutomaticallyDownloadFromProtocol =
            IniProvider.Read(AutomaticallyDownloadFromProtocol, true, ConfigName);

        PreferFFmpeg = fPreferFFmpeg =
            IniProvider.Read(PreferFFmpeg, false, ConfigName);

        SeparateBatchDownloads = fSeparateBatchDownloads =
            IniProvider.Read(SeparateBatchDownloads, true, ConfigName);

        AddDateToBatchDownloadFolders = fAddDateToBatchDownloadFolders =
            IniProvider.Read(AddDateToBatchDownloadFolders, true, ConfigName);

        YtdlType = fYtdlType =
            IniProvider.Read(YtdlType, 0, ConfigName) switch {
                1 => 1,
                2 => 2,
                _ => 0,
            };

        SubdomainFolderNames = fSubdomainFolderNames =
            IniProvider.Read(SubdomainFolderNames, false, ConfigName);

        ExtendedDownloaderPreferExtendedForm = fExtendedDownloaderPreferExtendedForm =
            IniProvider.Read(ExtendedDownloaderPreferExtendedForm, false, ConfigName);

        ExtendedDownloaderAutoDownloadThumbnail = fExtendedDownloaderAutoDownloadThumbnail =
            IniProvider.Read(ExtendedDownloaderAutoDownloadThumbnail, false, ConfigName);

        ExtendedDownloaderIncludeCustomArguments = fExtendedDownloaderIncludeCustomArguments =
            IniProvider.Read(ExtendedDownloaderIncludeCustomArguments, true, ConfigName);

        AbortForUnavailableFragments = fAbortForUnavailableFragments =
            IniProvider.Read(AbortForUnavailableFragments, true, ConfigName);

        AbortOnError = fAbortOnError =
            IniProvider.Read(AbortOnError, true, ConfigName);

        FragmentThreads = fFragmentThreads =
            IniProvider.Read(FragmentThreads, 1, ConfigName);

        if (FragmentThreads < 1)
            FragmentThreads = 1;
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

        if (CloseExtendedDownloaderAfterFinish != fCloseExtendedDownloaderAfterFinish)
            fCloseExtendedDownloaderAfterFinish = IniProvider.Write(CloseExtendedDownloaderAfterFinish, ConfigName);

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

        if (ExtendedDownloaderIncludeCustomArguments != fExtendedDownloaderIncludeCustomArguments)
            fExtendedDownloaderIncludeCustomArguments = IniProvider.Write(ExtendedDownloaderIncludeCustomArguments, ConfigName);

        if (AbortForUnavailableFragments != fAbortForUnavailableFragments)
            fAbortForUnavailableFragments = IniProvider.Write(AbortForUnavailableFragments, ConfigName);

        if (AbortOnError != fAbortOnError)
            fAbortOnError = IniProvider.Write(AbortOnError, ConfigName);

        if (FragmentThreads < 1)
            FragmentThreads = 1;
        if (FragmentThreads != fFragmentThreads)
            fFragmentThreads = IniProvider.Write(FragmentThreads, ConfigName);

    }
}