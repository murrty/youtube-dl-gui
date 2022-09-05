namespace youtube_dl_gui;

internal class Config_Downloads {
    private const string ConfigName = "Downloads";

    #region Variables
    public string downloadPath = string.Empty;
    public bool separateDownloads = true;
    public bool SaveFormatQuality = true;
    public bool deleteYtdlOnClose = false;
    public bool useYtdlUpdater = true;
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
    public bool YtdlpExtendedPreferExtendedForm = false;
    public bool YtdlpExtendedAutoDownloadThumbnail = false;

    private string fdownloadPath = string.Empty;
    private bool fseparateDownloads = true;
    private bool fSaveFormatQuality = true;
    private bool fdeleteYtdlOnClose = false;
    private bool fuseYtdlUpdater = true;
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
    private bool fYtdlpExtendedPreferExtendedForm = false;
    private bool fYtdlpExtendedAutoDownloadThumbnail = false;
    #endregion

    public void Load() {
        if (Ini.KeyExists("downloadPath", ConfigName)) {
            downloadPath = fdownloadPath = Ini.ReadString("downloadPath", ConfigName);
        }
        if (Ini.KeyExists("separateDownloads", ConfigName)) {
            separateDownloads = fseparateDownloads = Ini.ReadBool("separateDownloads", ConfigName);
        }
        if (Ini.KeyExists("SaveFormatQuality", ConfigName)) {
            SaveFormatQuality = fSaveFormatQuality = Ini.ReadBool("SaveFormatQuality", ConfigName);
        }
        if (Ini.KeyExists("deleteYtdlOnClose", ConfigName)) {
            deleteYtdlOnClose = fdeleteYtdlOnClose = Ini.ReadBool("deleteYtdlOnClose", ConfigName);
        }
        if (Ini.KeyExists("useYtdlUpdater", ConfigName)) {
            useYtdlUpdater = fuseYtdlUpdater = Ini.ReadBool("useYtdlUpdater", ConfigName);
        }
        if (Ini.KeyExists("fileNameSchema", ConfigName)) {
            fileNameSchema = ffileNameSchema = Ini.ReadString("fileNameSchema", ConfigName);
        }
        if (Ini.KeyExists("fixReddit", ConfigName)) {
            fixReddit = ffixReddit = Ini.ReadBool("fixReddit", ConfigName);
        }
        if (Ini.KeyExists("separateIntoWebsiteURL", ConfigName)) {
            separateIntoWebsiteURL = fseparateIntoWebsiteURL = Ini.ReadBool("separateIntoWebsiteURL", ConfigName);
        }
        if (Ini.KeyExists("SaveSubtitles", ConfigName)) {
            SaveSubtitles = fSaveSubtitles = Ini.ReadBool("SaveSubtitles", ConfigName);
        }
        if (Ini.KeyExists("subtitlesLanguages", ConfigName)) {
            subtitlesLanguages = fsubtitlesLanguages = Ini.ReadString("subtitlesLanguages", ConfigName);
        }
        if (Ini.KeyExists("CloseDownloaderAfterFinish", ConfigName)) {
            CloseDownloaderAfterFinish = fCloseDownloaderAfterFinish = Ini.ReadBool("CloseDownloaderAfterFinish", ConfigName);
        }
        if (Ini.KeyExists("UseProxy", ConfigName)) {
            UseProxy = fUseProxy = Ini.ReadBool("UseProxy", ConfigName);
        }
        if (Ini.KeyExists("ProxyType", ConfigName)) {
            ProxyType = fProxyType = Ini.ReadInt("ProxyType", ConfigName);
        }
        if (Ini.KeyExists("ProxyIP", ConfigName)) {
            ProxyIP = fProxyIP = Ini.ReadString("ProxyIP", ConfigName);
        }
        if (Ini.KeyExists("ProxyPort", ConfigName)) {
            ProxyPort = fProxyPort = Ini.ReadString("ProxyPort", ConfigName);
        }
        if (Ini.KeyExists("SaveThumbnail", ConfigName)) {
            SaveThumbnail = fSaveThumbnail = Ini.ReadBool("SaveThumbnail", ConfigName);
        }
        if (Ini.KeyExists("SaveDescription", ConfigName)) {
            SaveDescription = fSaveDescription = Ini.ReadBool("SaveDescription", ConfigName);
        }
        if (Ini.KeyExists("SaveVideoInfo", ConfigName)) {
            SaveVideoInfo = fSaveVideoInfo = Ini.ReadBool("SaveVideoInfo", ConfigName);
        }
        if (Ini.KeyExists("SaveAnnotations", ConfigName)) {
            SaveAnnotations = fSaveAnnotations = Ini.ReadBool("SaveAnnotations", ConfigName);
        }
        if (Ini.KeyExists("SubtitleFormat", ConfigName)) {
            SubtitleFormat = fSubtitleFormat = Ini.ReadString("SubtitleFormat", ConfigName);
        }
        if (Ini.KeyExists("DownloadLimit", ConfigName)) {
            DownloadLimit = fDownloadLimit = Ini.ReadInt("DownloadLimit", ConfigName);
        }
        if (Ini.KeyExists("RetryAttempts", ConfigName)) {
            RetryAttempts = fRetryAttempts = Ini.ReadInt("RetryAttempts", ConfigName);
        }
        if (Ini.KeyExists("DownloadLimitType", ConfigName)) {
            DownloadLimitType = fDownloadLimitType = Ini.ReadInt("DownloadLimitType", ConfigName);
        }
        if (Ini.KeyExists("ForceIPv4", ConfigName)) {
            ForceIPv4 = fForceIPv4 = Ini.ReadBool("ForceIPv4", ConfigName);
        }
        if (Ini.KeyExists("ForceIPv6", ConfigName)) {
            ForceIPv6 = fForceIPv6 = Ini.ReadBool("ForceIPv6", ConfigName);
        }
        if (Ini.KeyExists("LimitDownloads", ConfigName)) {
            LimitDownloads = fLimitDownloads = Ini.ReadBool("LimitDownloads", ConfigName);
        }
        if (Ini.KeyExists("EmbedSubtitles", ConfigName)) {
            EmbedSubtitles = fEmbedSubtitles = Ini.ReadBool("EmbedSubtitles", ConfigName);
        }
        if (Ini.KeyExists("EmbedThumbnails", ConfigName)) {
            EmbedThumbnails = fEmbedThumbnails = Ini.ReadBool("EmbedThumbnails", ConfigName);
        }
        if (Ini.KeyExists("VideoDownloadSound", ConfigName)) {
            VideoDownloadSound = fVideoDownloadSound = Ini.ReadBool("VideoDownloadSound", ConfigName);
        }
        if (Ini.KeyExists("AudioDownloadAsVBR", ConfigName)) {
            AudioDownloadAsVBR = fAudioDownloadAsVBR = Ini.ReadBool("AudioDownloadAsVBR", ConfigName);
        }
        if (Ini.KeyExists("KeepOriginalFiles", ConfigName)) {
            KeepOriginalFiles = fKeepOriginalFiles = Ini.ReadBool("KeepOriginalFiles", ConfigName);
        }
        if (Ini.KeyExists("WriteMetadata", ConfigName)) {
            WriteMetadata = fWriteMetadata = Ini.ReadBool("WriteMetadata", ConfigName);
        }
        if (Ini.KeyExists("SkipBatchTip", ConfigName)) {
            SkipBatchTip = fSkipBatchTip = Ini.ReadBool("SkipBatchTip", ConfigName);
        }
        if (Ini.KeyExists("AutomaticallyDownloadFromProtocol", ConfigName)) {
            AutomaticallyDownloadFromProtocol = fAutomaticallyDownloadFromProtocol = Ini.ReadBool("AutomaticallyDownloadFromProtocol", ConfigName);
        }
        if (Ini.KeyExists("PreferFFmpeg", ConfigName)) {
            PreferFFmpeg = fPreferFFmpeg = Ini.ReadBool("PreferFFmpeg", ConfigName);
        }
        if (Ini.KeyExists("SeparateBatchDownloads", ConfigName)) {
            SeparateBatchDownloads = fSeparateBatchDownloads = Ini.ReadBool("SeparateBatchDownloads", ConfigName);
        }
        if (Ini.KeyExists("AddDateToBatchDownloadFolders", ConfigName)) {
            AddDateToBatchDownloadFolders = fAddDateToBatchDownloadFolders = Ini.ReadBool("AddDateToBatchDownloadFolders", ConfigName);
        }
        if (Ini.KeyExists("YtdlType", ConfigName)) {
            YtdlType = fYtdlType = Ini.ReadInt("YtdlType", ConfigName) switch {
                1 => 1,
                2 => 2,
                _ => 0,
            };
        }

        if (Ini.KeyExists("SubdomainFolderNames", ConfigName)) {
            SubdomainFolderNames = fSubdomainFolderNames = Ini.ReadBool("SubdomainFolderNames", ConfigName);
        }

        if (Ini.KeyExists("YtdlpExtendedPreferExtendedForm", ConfigName)) {
            YtdlpExtendedPreferExtendedForm = fYtdlpExtendedPreferExtendedForm = Ini.ReadBool("YtdlpExtendedPreferExtendedForm", ConfigName);
        }

        if (Ini.KeyExists("YtdlpExtendedAutoDownloadThumbnail", ConfigName)) {
            YtdlpExtendedAutoDownloadThumbnail = fYtdlpExtendedAutoDownloadThumbnail = Ini.ReadBool("YtdlpExtendedAutoDownloadThumbnail", ConfigName);
        }
    }

    public void Save() {
        if (downloadPath != fdownloadPath) {
            Ini.Write("downloadPath", downloadPath, ConfigName);
            fdownloadPath = downloadPath;
        }
        if (separateDownloads != fseparateDownloads) {
            Ini.Write("separateDownloads", separateDownloads, ConfigName);
            fseparateDownloads = separateDownloads;
        }
        if (SaveFormatQuality != fSaveFormatQuality) {
            Ini.Write("SaveFormatQuality", SaveFormatQuality, ConfigName);
            fSaveFormatQuality = SaveFormatQuality;
        }
        if (deleteYtdlOnClose != fdeleteYtdlOnClose) {
            Ini.Write("deleteYtdlOnClose", deleteYtdlOnClose, ConfigName);
            fdeleteYtdlOnClose = deleteYtdlOnClose;
        }
        if (useYtdlUpdater != fuseYtdlUpdater) {
            Ini.Write("useYtdlUpdater", useYtdlUpdater, ConfigName);
            fuseYtdlUpdater = useYtdlUpdater;
        }
        if (fileNameSchema != ffileNameSchema) {
            Ini.Write("fileNameSchema", fileNameSchema, ConfigName);
            ffileNameSchema = fileNameSchema;
        }
        if (fixReddit != ffixReddit) {
            Ini.Write("fixReddit", fixReddit, ConfigName);
            ffixReddit = fixReddit;
        }
        if (separateIntoWebsiteURL != fseparateIntoWebsiteURL) {
            Ini.Write("separateIntoWebsiteURL", separateIntoWebsiteURL, ConfigName);
            fseparateIntoWebsiteURL = separateIntoWebsiteURL;
        }
        if (SaveSubtitles != fSaveSubtitles) {
            Ini.Write("SaveSubtitles", SaveSubtitles, ConfigName);
            fSaveSubtitles = SaveSubtitles;
        }
        if (subtitlesLanguages != fsubtitlesLanguages) {
            Ini.Write("subtitlesLanguages", subtitlesLanguages, ConfigName);
            fsubtitlesLanguages = subtitlesLanguages;
        }
        if (CloseDownloaderAfterFinish != fCloseDownloaderAfterFinish) {
            Ini.Write("CloseDownloaderAfterFinish", CloseDownloaderAfterFinish, ConfigName);
            fCloseDownloaderAfterFinish = CloseDownloaderAfterFinish;
        }
        if (UseProxy != fUseProxy) {
            Ini.Write("UseProxy", UseProxy, ConfigName);
            fUseProxy = UseProxy;
        }
        if (ProxyType != fProxyType) {
            Ini.Write("ProxyType", ProxyType, ConfigName);
            fProxyType = ProxyType;
        }
        if (ProxyIP != fProxyIP) {
            Ini.Write("ProxyIP", ProxyIP, ConfigName);
            fProxyIP = ProxyIP;
        }
        if (ProxyPort != fProxyPort) {
            Ini.Write("ProxyPort", ProxyPort, ConfigName);
            fProxyPort = ProxyPort;
        }
        if (SaveThumbnail != fSaveThumbnail) {
            Ini.Write("SaveThumbnail", SaveThumbnail, ConfigName);
            fSaveThumbnail = SaveThumbnail;
        }
        if (SaveDescription != fSaveDescription) {
            Ini.Write("SaveDescription", SaveDescription, ConfigName);
            fSaveDescription = SaveDescription;
        }
        if (SaveVideoInfo != fSaveVideoInfo) {
            Ini.Write("SaveVideoInfo", SaveVideoInfo, ConfigName);
            fSaveVideoInfo = SaveVideoInfo;
        }
        if (SaveAnnotations != fSaveAnnotations) {
            Ini.Write("SaveAnnotations", SaveAnnotations, ConfigName);
            fSaveAnnotations = SaveAnnotations;
        }
        if (SubtitleFormat != fSubtitleFormat) {
            Ini.Write("SubtitleFormat", SubtitleFormat, ConfigName);
            fSubtitleFormat = SubtitleFormat;
        }
        if (DownloadLimit != fDownloadLimit) {
            Ini.Write("DownloadLimit", DownloadLimit, ConfigName);
            fDownloadLimit = DownloadLimit;
        }
        if (RetryAttempts != fRetryAttempts) {
            Ini.Write("RetryAttempts", RetryAttempts, ConfigName);
            fRetryAttempts = RetryAttempts;
        }
        if (DownloadLimitType != fDownloadLimitType) {
            Ini.Write("DownloadLimitType", DownloadLimitType, ConfigName);
            fDownloadLimitType = DownloadLimitType;
        }
        if (ForceIPv4 != fForceIPv4) {
            Ini.Write("ForceIPv4", ForceIPv4, ConfigName);
            fForceIPv4 = ForceIPv4;
        }
        if (ForceIPv6 != fForceIPv6) {
            Ini.Write("ForceIPv6", ForceIPv6, ConfigName);
            fForceIPv6 = ForceIPv6;
        }
        if (LimitDownloads != fLimitDownloads) {
            Ini.Write("LimitDownloads", LimitDownloads, ConfigName);
            fLimitDownloads = LimitDownloads;
        }
        if (EmbedSubtitles != fEmbedSubtitles) {
            Ini.Write("EmbedSubtitles", EmbedSubtitles, ConfigName);
            fEmbedSubtitles = EmbedSubtitles;
        }
        if (EmbedThumbnails != fEmbedThumbnails) {
            Ini.Write("EmbedThumbnails", EmbedThumbnails, ConfigName);
            fEmbedThumbnails = EmbedThumbnails;
        }
        if (VideoDownloadSound != fVideoDownloadSound) {
            Ini.Write("VideoDownloadSound", VideoDownloadSound, ConfigName);
            fVideoDownloadSound = VideoDownloadSound;
        }
        if (AudioDownloadAsVBR != fAudioDownloadAsVBR) {
            Ini.Write("AudioDownloadAsVBR", AudioDownloadAsVBR, ConfigName);
            fAudioDownloadAsVBR = AudioDownloadAsVBR;
        }
        if (KeepOriginalFiles != fKeepOriginalFiles) {
            Ini.Write("KeepOriginalFiles", KeepOriginalFiles, ConfigName);
            fKeepOriginalFiles = KeepOriginalFiles;
        }
        if (WriteMetadata != fWriteMetadata) {
            Ini.Write("WriteMetadata", WriteMetadata, ConfigName);
            fWriteMetadata = WriteMetadata;
        }
        if (SkipBatchTip != fSkipBatchTip) {
            Ini.Write("SkipBatchTip", SkipBatchTip, ConfigName);
            fSkipBatchTip = SkipBatchTip;
        }
        if (AutomaticallyDownloadFromProtocol != fAutomaticallyDownloadFromProtocol) {
            Ini.Write("AutomaticallyDownloadFromProtocol", AutomaticallyDownloadFromProtocol, ConfigName);
            fAutomaticallyDownloadFromProtocol = AutomaticallyDownloadFromProtocol;
        }
        if (PreferFFmpeg != fPreferFFmpeg) {
            Ini.Write("PreferFFmpeg", PreferFFmpeg, ConfigName);
            fPreferFFmpeg = PreferFFmpeg;
        }
        if (SeparateBatchDownloads != fSeparateBatchDownloads) {
            Ini.Write("SeparateBatchDownloads", SeparateBatchDownloads, ConfigName);
            fSeparateBatchDownloads = SeparateBatchDownloads;
        }
        if (AddDateToBatchDownloadFolders != fAddDateToBatchDownloadFolders) {
            Ini.Write("AddDateToBatchDownloadFolders", AddDateToBatchDownloadFolders, ConfigName);
            fAddDateToBatchDownloadFolders = AddDateToBatchDownloadFolders;
        }
        if (YtdlType != fYtdlType) {
            Ini.Write("YtdlType", YtdlType, ConfigName);
            fYtdlType = YtdlType;
        }
        if (SubdomainFolderNames != fSubdomainFolderNames) {
            Ini.Write("SubdomainFolderNames", SubdomainFolderNames, ConfigName);
            fSubdomainFolderNames = SubdomainFolderNames;
        }
        if (YtdlpExtendedPreferExtendedForm != fYtdlpExtendedPreferExtendedForm) {
            Ini.Write("YtdlpExtendedPreferExtendedForm", YtdlpExtendedPreferExtendedForm, ConfigName);
            fYtdlpExtendedPreferExtendedForm = YtdlpExtendedPreferExtendedForm;
        }
        if (YtdlpExtendedAutoDownloadThumbnail != fYtdlpExtendedAutoDownloadThumbnail) {
            Ini.Write("YtdlpExtendedAutoDownloadThumbnail", YtdlpExtendedAutoDownloadThumbnail, ConfigName);
            fYtdlpExtendedAutoDownloadThumbnail = YtdlpExtendedAutoDownloadThumbnail;
        }
    }
}