namespace youtube_dl_gui;

internal class Config_General {
    private const string ConfigName = "General";

    #region Properties
    public bool UseStaticYtdl { get; set; }
    public string ytdlPath { get; set; }
    public bool UseStaticFFmpeg { get; set; }
    public string ffmpegPath { get; set; }
    public bool CheckForUpdatesOnLaunch { get; set; }
    public bool DownloadBetaVersions { get; set; }
    public bool HoverOverURLTextBoxToPaste { get; set; }
    public bool ClearURLOnDownload { get; set; }
    public int SaveCustomArgs { get; set; }
    public bool ClearClipboardOnDownload { get; set; }
    public string extensionsName { get; set; }
    public string extensionsShort { get; set; }
    public bool DeleteUpdaterOnStartup { get; set; }
    public bool DeleteBackupOnStartup { get; set; }
    public bool ClipboardAutoDownloadNoticeRead { get; set; }
    public bool ClipboardAutoDownloadVerifyLinks { get; set; }
    public bool AutoUpdateYoutubeDl { get; set; }


    private bool fUseStaticYtdl { get; set; }
    private string fytdlPath { get; set; }
    private bool fUseStaticFFmpeg { get; set; }
    private string fffmpegPath { get; set; }
    private bool fCheckForUpdatesOnLaunch { get; set; }
    private bool fDownloadBetaVersions { get; set; }
    private bool fHoverOverURLTextBoxToPaste { get; set; }
    private bool fClearURLOnDownload { get; set; }
    private int fSaveCustomArgs { get; set; }
    private bool fClearClipboardOnDownload { get; set; }
    private string fextensionsName { get; set; }
    private string fextensionsShort { get; set; }
    private bool fDeleteUpdaterOnStartup { get; set; }
    private bool fDeleteBackupOnStartup { get; set; }
    private bool fClipboardAutoDownloadNoticeRead { get; set; }
    private bool fClipboardAutoDownloadVerifyLinks { get; set; }
    private bool fAutoUpdateYoutubeDl { get; set; }
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