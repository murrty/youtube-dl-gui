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

        UseStaticYtdl = fUseStaticYtdl = IniProvider.Read(UseStaticYtdl, false, ConfigName);
        ytdlPath = fytdlPath = IniProvider.Read(ytdlPath, string.Empty, ConfigName);
        UseStaticFFmpeg = fUseStaticFFmpeg = IniProvider.Read(UseStaticFFmpeg, false, ConfigName);
        ffmpegPath = fffmpegPath = IniProvider.Read(ffmpegPath, string.Empty, ConfigName);
        CheckForUpdatesOnLaunch = fCheckForUpdatesOnLaunch = IniProvider.Read(CheckForUpdatesOnLaunch, false, ConfigName);
        DownloadBetaVersions = fDownloadBetaVersions = IniProvider.Read(DownloadBetaVersions, false, ConfigName);
        HoverOverURLTextBoxToPaste = fHoverOverURLTextBoxToPaste = IniProvider.Read(HoverOverURLTextBoxToPaste, true, ConfigName);
        ClearURLOnDownload = fClearURLOnDownload = IniProvider.Read(ClearURLOnDownload, false, ConfigName);
        SaveCustomArgs = fSaveCustomArgs = IniProvider.Read(SaveCustomArgs, 2, ConfigName);
        ClearClipboardOnDownload = fClearClipboardOnDownload = IniProvider.Read(ClearClipboardOnDownload, false, ConfigName);
        extensionsName = fextensionsName = IniProvider.Read(extensionsName, ConfigName);
        extensionsShort = fextensionsShort = IniProvider.Read(extensionsShort, ConfigName);
        DeleteUpdaterOnStartup = fDeleteUpdaterOnStartup = IniProvider.Read(DeleteUpdaterOnStartup, true, ConfigName);
        DeleteBackupOnStartup = fDeleteBackupOnStartup = IniProvider.Read(DeleteBackupOnStartup, false, ConfigName);
        ClipboardAutoDownloadNoticeRead = fClipboardAutoDownloadNoticeRead = IniProvider.Read(ClipboardAutoDownloadNoticeRead, false, ConfigName);
        ClipboardAutoDownloadVerifyLinks = fClipboardAutoDownloadVerifyLinks = IniProvider.Read(ClipboardAutoDownloadVerifyLinks, true, ConfigName);
        AutoUpdateYoutubeDl = fAutoUpdateYoutubeDl = IniProvider.Read(AutoUpdateYoutubeDl, false, ConfigName);
    }

    public void Save() {
        Log.Write("Saving General config.");

        if (UseStaticYtdl != fUseStaticYtdl)
            fUseStaticYtdl = IniProvider.Write(UseStaticYtdl, ConfigName);
        if (ytdlPath != fytdlPath)
            fytdlPath = IniProvider.Write(ytdlPath, ConfigName);
        if (UseStaticFFmpeg != fUseStaticFFmpeg)
            fUseStaticFFmpeg = IniProvider.Write(UseStaticFFmpeg, ConfigName);
        if (ffmpegPath != fffmpegPath)
            fffmpegPath = IniProvider.Write(ffmpegPath, ConfigName);
        if (CheckForUpdatesOnLaunch != fCheckForUpdatesOnLaunch)
            fCheckForUpdatesOnLaunch = IniProvider.Write(CheckForUpdatesOnLaunch, ConfigName);
        if (DownloadBetaVersions != fDownloadBetaVersions)
            fDownloadBetaVersions = IniProvider.Write(DownloadBetaVersions, ConfigName);
        if (HoverOverURLTextBoxToPaste != fHoverOverURLTextBoxToPaste)
            fHoverOverURLTextBoxToPaste = IniProvider.Write(HoverOverURLTextBoxToPaste, ConfigName);
        if (ClearURLOnDownload != fClearURLOnDownload)
            fClearURLOnDownload = IniProvider.Write(ClearURLOnDownload, ConfigName);
        if (SaveCustomArgs != fSaveCustomArgs)
            fSaveCustomArgs = IniProvider.Write(SaveCustomArgs, ConfigName);
        if (ClearClipboardOnDownload != fClearClipboardOnDownload)
            fClearClipboardOnDownload = IniProvider.Write(ClearClipboardOnDownload, ConfigName);
        if (extensionsName != fextensionsName)
            fextensionsName = IniProvider.Write(extensionsName, ConfigName);
        if (extensionsShort != fextensionsShort)
            fextensionsShort = IniProvider.Write(extensionsShort, ConfigName);
        if (DeleteUpdaterOnStartup != fDeleteUpdaterOnStartup)
            fDeleteUpdaterOnStartup = IniProvider.Write(DeleteUpdaterOnStartup, ConfigName);
        if (DeleteBackupOnStartup != fDeleteBackupOnStartup)
            fDeleteBackupOnStartup = IniProvider.Write(DeleteBackupOnStartup, ConfigName);
        if (ClipboardAutoDownloadNoticeRead != fClipboardAutoDownloadNoticeRead)
            fClipboardAutoDownloadNoticeRead = IniProvider.Write(ClipboardAutoDownloadNoticeRead, ConfigName);
        if (ClipboardAutoDownloadVerifyLinks != fClipboardAutoDownloadVerifyLinks)
            fClipboardAutoDownloadVerifyLinks = IniProvider.Write(ClipboardAutoDownloadVerifyLinks, ConfigName);
        if (AutoUpdateYoutubeDl != fAutoUpdateYoutubeDl)
            fAutoUpdateYoutubeDl = IniProvider.Write(AutoUpdateYoutubeDl, ConfigName);
    }
}