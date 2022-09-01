namespace youtube_dl_gui;

internal class Config_General {
    private const string ConfigName = "General";

    #region Variables
    public bool UseStaticYtdl = false;
    public string ytdlPath = string.Empty;
    public bool UseStaticFFmpeg = false;
    public string ffmpegPath = string.Empty;
    public bool CheckForUpdatesOnLaunch = false;
    public bool DownloadBetaVersions = false;
    public bool HoverOverURLTextBoxToPaste = true;
    public bool ClearURLOnDownload = false;
    public int SaveCustomArgs = 2;
    public bool ClearClipboardOnDownload = false;
    public string extensionsName = string.Empty;
    public string extensionsShort = string.Empty;
    public bool DeleteUpdaterOnStartup = true;
    public bool DeleteBackupOnStartup = false;
    public bool ClipboardAutoDownloadNoticeRead = false;
    public bool ClipboardAutoDownloadVerifyLinks = true;
    public bool AutoUpdateYoutubeDl = false;


    private bool fUseStaticYtdl = false;
    private string fytdlPath = string.Empty;
    private bool fUseStaticFFmpeg = false;
    private string fffmpegPath = string.Empty;
    private bool fCheckForUpdatesOnLaunch = false;
    private bool fDownloadBetaVersions = false;
    private bool fHoverOverURLTextBoxToPaste = true;
    private bool fClearURLOnDownload = false;
    private int fSaveCustomArgs = 2;
    private bool fClearClipboardOnDownload = false;
    private string fextensionsName = string.Empty;
    private string fextensionsShort = string.Empty;
    private bool fDeleteUpdaterOnStartup = true;
    private bool fDeleteBackupOnStartup = false;
    private bool fClipboardAutoDownloadNoticeRead = false;
    private bool fClipboardAutoDownloadVerifyLinks = true;
    private bool fAutoUpdateYoutubeDl = false;
    #endregion

    public void Load() {
        if (Ini.KeyExists("UseStaticYtdl", ConfigName)) {
            UseStaticYtdl = fUseStaticYtdl = Ini.ReadBool("UseStaticYtdl", ConfigName);
        }
        if (Ini.KeyExists("ytdlPath", ConfigName)) {
            ytdlPath = fytdlPath = Ini.ReadString("ytdlPath", ConfigName);
        }
        if (Ini.KeyExists("UseStaticFFmpeg", ConfigName)) {
            UseStaticFFmpeg = fUseStaticFFmpeg = Ini.ReadBool("UseStaticFFmpeg", ConfigName);
        }
        if (Ini.KeyExists("ffmpegPath", ConfigName)) {
            ffmpegPath = fffmpegPath = Ini.ReadString("ffmpegPath", ConfigName);
        }
        if (Ini.KeyExists("CheckForUpdatesOnLaunch", ConfigName)) {
            CheckForUpdatesOnLaunch = fCheckForUpdatesOnLaunch = Ini.ReadBool("CheckForUpdatesOnLaunch", ConfigName);
        }
        if (Ini.KeyExists("DownloadBetaVersions", ConfigName)) {
            DownloadBetaVersions = fDownloadBetaVersions = Ini.ReadBool("DownloadBetaVersions", ConfigName);
        }
        if (Ini.KeyExists("HoverOverURLTextBoxToPaste", ConfigName)) {
            HoverOverURLTextBoxToPaste = fHoverOverURLTextBoxToPaste = Ini.ReadBool("HoverOverURLTextBoxToPaste", ConfigName);
        }
        if (Ini.KeyExists("ClearURLOnDownload", ConfigName)) {
            ClearURLOnDownload = fClearURLOnDownload = Ini.ReadBool("ClearURLOnDownload", ConfigName);
        }
        if (Ini.KeyExists("SaveCustomArgs", ConfigName)) {
            SaveCustomArgs = fSaveCustomArgs = Ini.ReadInt("SaveCustomArgs", ConfigName);
        }
        if (Ini.KeyExists("ClearClipboardOnDownload", ConfigName)) {
            ClearClipboardOnDownload = fClearClipboardOnDownload = Ini.ReadBool("ClearClipboardOnDownload", ConfigName);
        }
        if (Ini.KeyExists("extensionsName", ConfigName)) {
            extensionsName = fextensionsName = Ini.ReadString("extensionsName", ConfigName);
        }
        if (Ini.KeyExists("extensionsShort", ConfigName)) {
            extensionsShort = fextensionsShort = Ini.ReadString("extensionsShort", ConfigName);
        }
        if (Ini.KeyExists("DeleteUpdaterOnStartup", ConfigName)) {
            DeleteUpdaterOnStartup = fDeleteUpdaterOnStartup = Ini.ReadBool("DeleteUpdaterOnStartup", ConfigName);
        }
        if (Ini.KeyExists("DeleteBackupOnStartup", ConfigName)) {
            DeleteBackupOnStartup = fDeleteBackupOnStartup = Ini.ReadBool("DeleteBackupOnStartup", ConfigName);
        }
        if (Ini.KeyExists("ClipboardAutoDownloadNoticeRead", ConfigName)) {
            ClipboardAutoDownloadNoticeRead = fClipboardAutoDownloadNoticeRead = Ini.ReadBool("ClipboardAutoDownloadNoticeRead", ConfigName);
        }
        if (Ini.KeyExists("ClipboardAutoDownloadVerifyLinks", ConfigName)) {
            ClipboardAutoDownloadVerifyLinks = fClipboardAutoDownloadVerifyLinks = Ini.ReadBool("ClipboardAutoDownloadVerifyLinks", ConfigName);
        }
        if (Ini.KeyExists("AutoUpdateYoutubeDl", ConfigName)) {
            AutoUpdateYoutubeDl = fAutoUpdateYoutubeDl = Ini.ReadBool("AutoUpdateYoutubeDl", ConfigName);
        }
    }

    public void Save() {
        if (UseStaticYtdl != fUseStaticYtdl) {
            Ini.Write("UseStaticYtdl", UseStaticYtdl, ConfigName);
            fUseStaticYtdl = UseStaticYtdl;
        }
        if (ytdlPath != fytdlPath) {
            Ini.Write("ytdlPath", ytdlPath, ConfigName);
            fytdlPath = ytdlPath;
        }
        if (UseStaticFFmpeg != fUseStaticFFmpeg) {
            Ini.Write("UseStaticFFmpeg", UseStaticFFmpeg, ConfigName);
            fUseStaticFFmpeg = UseStaticFFmpeg;
        }
        if (ffmpegPath != fffmpegPath) {
            Ini.Write("ffmpegPath", ffmpegPath, ConfigName);
            fffmpegPath = ffmpegPath;
        }
        if (CheckForUpdatesOnLaunch != fCheckForUpdatesOnLaunch) {
            Ini.Write("CheckForUpdatesOnLaunch", CheckForUpdatesOnLaunch, ConfigName);
            fCheckForUpdatesOnLaunch = CheckForUpdatesOnLaunch;
        }
        if (DownloadBetaVersions != fDownloadBetaVersions) {
            Ini.Write("DownloadBetaVersions", DownloadBetaVersions, ConfigName);
            fDownloadBetaVersions = DownloadBetaVersions;
        }
        if (HoverOverURLTextBoxToPaste != fHoverOverURLTextBoxToPaste) {
            Ini.Write("HoverOverURLTextBoxToPaste", HoverOverURLTextBoxToPaste, ConfigName);
            fHoverOverURLTextBoxToPaste = HoverOverURLTextBoxToPaste;
        }
        if (ClearURLOnDownload != fClearURLOnDownload) {
            Ini.Write("ClearURLOnDownload", ClearURLOnDownload, ConfigName);
            fClearURLOnDownload = ClearURLOnDownload;
        }
        if (SaveCustomArgs != fSaveCustomArgs) {
            Ini.Write("SaveCustomArgs", SaveCustomArgs, ConfigName);
            fSaveCustomArgs = SaveCustomArgs;
        }
        if (ClearClipboardOnDownload != fClearClipboardOnDownload) {
            Ini.Write("ClearClipboardOnDownload", ClearClipboardOnDownload, ConfigName);
            fClearClipboardOnDownload = ClearClipboardOnDownload;
        }
        if (extensionsName != fextensionsName) {
            Ini.Write("extensionsName", extensionsName, ConfigName);
            fextensionsName = extensionsName;
        }
        if (extensionsShort != fextensionsShort) {
            Ini.Write("extensionsShort", extensionsShort, ConfigName);
            fextensionsShort = extensionsShort;
        }
        if (DeleteUpdaterOnStartup != fDeleteUpdaterOnStartup) {
            Ini.Write("DeleteUpdaterOnStartup", DeleteUpdaterOnStartup, ConfigName);
            fDeleteUpdaterOnStartup = DeleteUpdaterOnStartup;
        }
        if (DeleteBackupOnStartup != fDeleteBackupOnStartup) {
            Ini.Write("DeleteBackupOnStartup", DeleteBackupOnStartup, ConfigName);
            fDeleteBackupOnStartup = DeleteBackupOnStartup;
        }
        if (ClipboardAutoDownloadNoticeRead != fClipboardAutoDownloadNoticeRead) {
            Ini.Write("ClipboardAutoDownloadNoticeRead", ClipboardAutoDownloadNoticeRead, ConfigName);
            fClipboardAutoDownloadNoticeRead = ClipboardAutoDownloadNoticeRead;
        }
        if (ClipboardAutoDownloadVerifyLinks != fClipboardAutoDownloadVerifyLinks) {
            Ini.Write("ClipboardAutoDownloadVerifyLinks", ClipboardAutoDownloadVerifyLinks, ConfigName);
            fClipboardAutoDownloadVerifyLinks = ClipboardAutoDownloadVerifyLinks;
        }
        if (AutoUpdateYoutubeDl != fAutoUpdateYoutubeDl) {
            Ini.Write("AutoUpdateYoutubeDl", AutoUpdateYoutubeDl, ConfigName);
            fAutoUpdateYoutubeDl = AutoUpdateYoutubeDl;
        }
    }
}