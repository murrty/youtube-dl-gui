namespace youtube_dl_gui;

internal static class General {

    private const string ConfigName = "General";

    static General() {
        Log.Write("Loading General config.");

        fUseStaticYtdl = IniProvider.Read(UseStaticYtdl, false, ConfigName);
        fytdlPath = IniProvider.Read(ytdlPath, string.Empty, ConfigName);
        fUseStaticFFmpeg = IniProvider.Read(UseStaticFFmpeg, false, ConfigName);
        fffmpegPath = IniProvider.Read(ffmpegPath, string.Empty, ConfigName);
        fCheckForUpdatesOnLaunch = IniProvider.Read(CheckForUpdatesOnLaunch, false, ConfigName);
        fDownloadBetaVersions = IniProvider.Read(DownloadBetaVersions, false, ConfigName);
        fHoverOverURLTextBoxToPaste = IniProvider.Read(HoverOverURLTextBoxToPaste, true, ConfigName);
        fClearURLOnDownload = IniProvider.Read(ClearURLOnDownload, false, ConfigName);
        fSaveCustomArgs = IniProvider.Read(SaveCustomArgs, 2, ConfigName);
        fClearClipboardOnDownload = IniProvider.Read(ClearClipboardOnDownload, false, ConfigName);
        fextensionsName = IniProvider.Read(extensionsName, string.Empty, ConfigName);
        fextensionsShort = IniProvider.Read(extensionsShort, string.Empty, ConfigName);
        fDeleteUpdaterOnStartup = IniProvider.Read(DeleteUpdaterOnStartup, true, ConfigName);
        fDeleteBackupOnStartup = IniProvider.Read(DeleteBackupOnStartup, false, ConfigName);
        fClipboardAutoDownloadNoticeRead = IniProvider.Read(ClipboardAutoDownloadNoticeRead, false, ConfigName);
        fClipboardAutoDownloadVerifyLinks = IniProvider.Read(ClipboardAutoDownloadVerifyLinks, true, ConfigName);
        fAutoUpdateYoutubeDl = IniProvider.Read(AutoUpdateYoutubeDl, false, ConfigName);
    }

    public static bool UseStaticYtdl {
        get => fUseStaticYtdl;
        set {
            if (fUseStaticYtdl != value) {
                fUseStaticYtdl = value;
                IniProvider.Write(UseStaticYtdl, ConfigName);
            }
        }
    }
    private static bool fUseStaticYtdl;

    public static string ytdlPath {
        get => fytdlPath;
        set {
            if (fytdlPath != value) {
                fytdlPath = value;
                IniProvider.Write(ytdlPath, ConfigName);
            }
        }
    }
    private static string fytdlPath;

    public static bool UseStaticFFmpeg {
        get => fUseStaticFFmpeg;
        set {
            if (fUseStaticFFmpeg != value) {
                fUseStaticFFmpeg = value;
                IniProvider.Write(UseStaticFFmpeg, ConfigName);
            }
        }
    }
    private static bool fUseStaticFFmpeg;

    public static string ffmpegPath {
        get => fffmpegPath;
        set {
            if (fffmpegPath != value) {
                fffmpegPath = value;
                IniProvider.Write(ffmpegPath, ConfigName);
            }
        }
    }
    private static string fffmpegPath;

    public static bool CheckForUpdatesOnLaunch {
        get => fCheckForUpdatesOnLaunch;
        set {
            if (fCheckForUpdatesOnLaunch != value) {
                fCheckForUpdatesOnLaunch = value;
                IniProvider.Write(CheckForUpdatesOnLaunch, ConfigName);
            }
        }
    }
    private static bool fCheckForUpdatesOnLaunch;

    public static bool DownloadBetaVersions {
        get => fDownloadBetaVersions;
        set {
            if (fDownloadBetaVersions != value) {
                fDownloadBetaVersions = value;
                IniProvider.Write(DownloadBetaVersions, ConfigName);
            }
        }
    }
    private static bool fDownloadBetaVersions;

    public static bool HoverOverURLTextBoxToPaste {
        get => fHoverOverURLTextBoxToPaste;
        set {
            if (fHoverOverURLTextBoxToPaste != value) {
                fHoverOverURLTextBoxToPaste = value;
                IniProvider.Write(HoverOverURLTextBoxToPaste, ConfigName);
            }
        }
    }
    private static bool fHoverOverURLTextBoxToPaste;

    public static bool ClearURLOnDownload {
        get => fClearURLOnDownload;
        set {
            if (fClearURLOnDownload != value) {
                fClearURLOnDownload = value;
                IniProvider.Write(ClearURLOnDownload, ConfigName);
            }
        }
    }
    private static bool fClearURLOnDownload;

    public static int SaveCustomArgs {
        get => fSaveCustomArgs;
        set {
            if (fSaveCustomArgs != value) {
                fSaveCustomArgs = value;
                IniProvider.Write(SaveCustomArgs, ConfigName);
            }
        }
    }
    private static int fSaveCustomArgs;

    public static bool ClearClipboardOnDownload {
        get => fClearClipboardOnDownload;
        set {
            if (fClearClipboardOnDownload != value) {
                fClearClipboardOnDownload = value;
                IniProvider.Write(ClearClipboardOnDownload, ConfigName);
            }
        }
    }
    private static bool fClearClipboardOnDownload;

    public static string extensionsName {
        get => fextensionsName;
        set {
            if (fextensionsName != value) {
                fextensionsName = value;
                IniProvider.Write(extensionsName, ConfigName);
            }
        }
    }
    private static string fextensionsName;

    public static string extensionsShort {
        get => fextensionsShort;
        set {
            if (fextensionsShort != value) {
                fextensionsShort = value;
                IniProvider.Write(extensionsShort, ConfigName);
            }
        }
    }
    private static string fextensionsShort;

    public static bool DeleteUpdaterOnStartup {
        get => fDeleteUpdaterOnStartup;
        set {
            if (fDeleteUpdaterOnStartup != value) {
                fDeleteUpdaterOnStartup = value;
                IniProvider.Write(DeleteUpdaterOnStartup, ConfigName);
            }
        }
    }
    private static bool fDeleteUpdaterOnStartup;

    public static bool DeleteBackupOnStartup {
        get => fDeleteBackupOnStartup;
        set {
            if (fDeleteBackupOnStartup != value) {
                fDeleteBackupOnStartup = value;
                IniProvider.Write(DeleteBackupOnStartup, ConfigName);
            }
        }
    }
    private static bool fDeleteBackupOnStartup;

    public static bool ClipboardAutoDownloadNoticeRead {
        get => fClipboardAutoDownloadNoticeRead;
        set {
            if (fClipboardAutoDownloadNoticeRead != value) {
                fClipboardAutoDownloadNoticeRead = value;
                IniProvider.Write(ClipboardAutoDownloadNoticeRead, ConfigName);
            }
        }
    }
    private static bool fClipboardAutoDownloadNoticeRead;

    public static bool ClipboardAutoDownloadVerifyLinks {
        get => fClipboardAutoDownloadVerifyLinks;
        set {
            if (fClipboardAutoDownloadVerifyLinks != value) {
                fClipboardAutoDownloadVerifyLinks = value;
                IniProvider.Write(ClipboardAutoDownloadVerifyLinks, ConfigName);
            }
        }
    }
    private static bool fClipboardAutoDownloadVerifyLinks;

    public static bool AutoUpdateYoutubeDl {
        get => fAutoUpdateYoutubeDl;
        set {
            if (fAutoUpdateYoutubeDl != value) {
                fAutoUpdateYoutubeDl = value;
                IniProvider.Write(AutoUpdateYoutubeDl, ConfigName);
            }
        }
    }
    private static bool fAutoUpdateYoutubeDl;

}