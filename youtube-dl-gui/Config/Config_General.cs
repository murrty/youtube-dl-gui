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
        Log.Write("Loading General config.");

        UseStaticYtdl = fUseStaticYtdl = Ini.Read(UseStaticYtdl, false, ConfigName);
        ytdlPath = fytdlPath = Ini.Read(ytdlPath, string.Empty, ConfigName);
        UseStaticFFmpeg = fUseStaticFFmpeg = Ini.Read(UseStaticFFmpeg, false, ConfigName);
        ffmpegPath = fffmpegPath = Ini.Read(ffmpegPath, string.Empty, ConfigName);
        CheckForUpdatesOnLaunch = fCheckForUpdatesOnLaunch = Ini.Read(CheckForUpdatesOnLaunch, false, ConfigName);
        DownloadBetaVersions = fDownloadBetaVersions = Ini.Read(DownloadBetaVersions, false, ConfigName);
        HoverOverURLTextBoxToPaste = fHoverOverURLTextBoxToPaste = Ini.Read(HoverOverURLTextBoxToPaste, true, ConfigName);
        ClearURLOnDownload = fClearURLOnDownload = Ini.Read(ClearURLOnDownload, false, ConfigName);
        SaveCustomArgs = fSaveCustomArgs = Ini.Read(SaveCustomArgs, 2, ConfigName);
        ClearClipboardOnDownload = fClearClipboardOnDownload = Ini.Read(ClearClipboardOnDownload, false, ConfigName);
        extensionsName = fextensionsName = Ini.Read(extensionsName, ConfigName);
        extensionsShort = fextensionsShort = Ini.Read(extensionsShort, ConfigName);
        DeleteUpdaterOnStartup = fDeleteUpdaterOnStartup = Ini.Read(DeleteUpdaterOnStartup, true, ConfigName);
        DeleteBackupOnStartup = fDeleteBackupOnStartup = Ini.Read(DeleteBackupOnStartup, false, ConfigName);
        ClipboardAutoDownloadNoticeRead = fClipboardAutoDownloadNoticeRead = Ini.Read(ClipboardAutoDownloadNoticeRead, false, ConfigName);
        ClipboardAutoDownloadVerifyLinks = fClipboardAutoDownloadVerifyLinks = Ini.Read(ClipboardAutoDownloadVerifyLinks, true, ConfigName);
        AutoUpdateYoutubeDl = fAutoUpdateYoutubeDl = Ini.Read(AutoUpdateYoutubeDl, false, ConfigName);
    }

    public void Save() {
        Log.Write("Saving General config.");

        if (UseStaticYtdl != fUseStaticYtdl)
            fUseStaticYtdl = Ini.Write(UseStaticYtdl, ConfigName);
        if (ytdlPath != fytdlPath)
            fytdlPath = Ini.Write(ytdlPath, ConfigName);
        if (UseStaticFFmpeg != fUseStaticFFmpeg)
            fUseStaticFFmpeg = Ini.Write(UseStaticFFmpeg, ConfigName);
        if (ffmpegPath != fffmpegPath)
            fffmpegPath = Ini.Write(ffmpegPath, ConfigName);
        if (CheckForUpdatesOnLaunch != fCheckForUpdatesOnLaunch)
            fCheckForUpdatesOnLaunch = Ini.Write(CheckForUpdatesOnLaunch, ConfigName);
        if (DownloadBetaVersions != fDownloadBetaVersions)
            fDownloadBetaVersions = Ini.Write(DownloadBetaVersions, ConfigName);
        if (HoverOverURLTextBoxToPaste != fHoverOverURLTextBoxToPaste)
            fHoverOverURLTextBoxToPaste = Ini.Write(HoverOverURLTextBoxToPaste, ConfigName);
        if (ClearURLOnDownload != fClearURLOnDownload)
            fClearURLOnDownload = Ini.Write(ClearURLOnDownload, ConfigName);
        if (SaveCustomArgs != fSaveCustomArgs)
            fSaveCustomArgs = Ini.Write(SaveCustomArgs, ConfigName);
        if (ClearClipboardOnDownload != fClearClipboardOnDownload)
            fClearClipboardOnDownload = Ini.Write(ClearClipboardOnDownload, ConfigName);
        if (extensionsName != fextensionsName)
            fextensionsName = Ini.Write(extensionsName, ConfigName);
        if (extensionsShort != fextensionsShort)
            fextensionsShort = Ini.Write(extensionsShort, ConfigName);
        if (DeleteUpdaterOnStartup != fDeleteUpdaterOnStartup)
            fDeleteUpdaterOnStartup = Ini.Write(DeleteUpdaterOnStartup, ConfigName);
        if (DeleteBackupOnStartup != fDeleteBackupOnStartup)
            fDeleteBackupOnStartup = Ini.Write(DeleteBackupOnStartup, ConfigName);
        if (ClipboardAutoDownloadNoticeRead != fClipboardAutoDownloadNoticeRead)
            fClipboardAutoDownloadNoticeRead = Ini.Write(ClipboardAutoDownloadNoticeRead, ConfigName);
        if (ClipboardAutoDownloadVerifyLinks != fClipboardAutoDownloadVerifyLinks)
            fClipboardAutoDownloadVerifyLinks = Ini.Write(ClipboardAutoDownloadVerifyLinks, ConfigName);
        if (AutoUpdateYoutubeDl != fAutoUpdateYoutubeDl)
            fAutoUpdateYoutubeDl = Ini.Write(AutoUpdateYoutubeDl, ConfigName);
    }
}