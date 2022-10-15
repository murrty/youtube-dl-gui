namespace youtube_dl_gui_updater;

using System.Windows.Forms;

static class Program {
    /// <summary>
    /// Current updater version. This is not really used outside of identification diagnostics, so `VERSION` struct is not used here.
    /// </summary>
    public const string CurrentVersion = "1.5.0";
    /// <summary>
    /// The repository name that the updater is tied to.
    /// </summary>
    public const string RepositoryName = "youtube-dl-gui";
    /// <summary>
    /// The user-agent string used for the webclient.
    /// </summary>
    internal const string UserAgent = $"{RepositoryName}-updater/{CurrentVersion}";
    /// <summary>
    /// The update form interface.
    /// </summary>
    public static IUpdateForm MainForm;
    /// <summary>
    /// The program data that represents information about the program itself, used for messaging between each other.
    /// </summary>
    public static ProgramData ProgramData;
    /// <summary>
    /// The update data that represents data about the new version.
    /// </summary>
    public static UpdaterData UpdateData;

    /// <summary>
    /// The exit code that the program will return. Defaults to 0.
    /// </summary>
    public static int StatusCode { get; set; } = 0;
    /// <summary>
    /// If the program is debugging or built under DEBUG.
    /// </summary>
    public static bool DebugMode { get; private set; } = false;
    public static bool GotLatestUpdate { get; private set; } = false;

    /// <summary>
    /// Entry point.
    /// </summary>
    /// <param name="args">The array of passed arguments.</param>
    /// <returns>The <see cref="StatusCode"/>.</returns>
    [STAThread]
    static int Main(string[] args) {
#if DEBUG
        DebugMode = true;
        Language.LoadInternalEnglish();
#else
        var Value = new StringBuilder(65535);
        NativeMethods.GetPrivateProfileString(RepositoryName, "LanguageFile", "${empty}", Value, 65535, $"{Environment.CurrentDirectory}\\youtube-dl-gui.ini");
        string LanguageFile = Value.ToString() == "${empty}" ? null : Value.ToString();
        Language.LoadLanguage(LanguageFile);
#endif

        ProgramData = new() {
            hWnd = null,
            pid = null,
            ProgramSet = false
        };

        if (args.Length >= 4) {
            bool BreakLoop = false;
            for (int i = 0; i < args.Length; i++) {
                switch (args[i].ToLower()) {
                    case "-hwnd": {
                        if (++i >= args.Length) {
                            BreakLoop = true;
                            break;
                        }

                        if (int.TryParse(args[i], out int hwnd) && ProgramData.hWnd is null) {
                            ProgramData.hWnd = hwnd;
                        }
                    }
                    break;

                    case "-pid": {
                        if (++i >= args.Length) {
                            BreakLoop = true;
                            break;
                        }

                        if (int.TryParse(args[i], out int pid) && ProgramData.pid is null) {
                            ProgramData.pid = pid;
                        }
                    }
                    break;
                }
                if (BreakLoop) {
                    break;
                }
            }
            ProgramData.ProgramSet = ProgramData.hWnd is not null && ProgramData.pid is not null;
        }

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        if (!ProgramData.ProgramSet) {
            if (!InvalidData())
                return 1;
        }
        Application.Run((Form)(MainForm = new frmUpdater()));
        return StatusCode;
    }
    
    internal static bool InvalidData() {
        using frmUpdaterInvalidData Invalid = new();
        return Invalid.ShowDialog() switch {
            DialogResult.Yes => GetUpdate(true), // Get pre-release
            DialogResult.No => GetUpdate(false), // Get latest
            _ => false // Invalid data
        };
    }
    private static bool GetUpdate(bool PreRelease) {
        using murrty.classcontrols.ExtendedWebClient wc = new();
        wc.Method = murrty.classcontrols.HttpMethod.GET;
        wc.UserAgent = UserAgent;
        GithubData Data = null;
        bool CanRetry = true;
        do {
            try {
                if (PreRelease) {
                    Data = wc.DownloadString($"https://api.github.com/repos/murrty/{RepositoryName}/releases").JsonDeserialize<GithubData[]>()[0];
                    CanRetry = false;
                }
                else {
                    Data = wc.DownloadString($"https://api.github.com/repos/murrty/{RepositoryName}/releases/latest").JsonDeserialize<GithubData>();
                    CanRetry = false;
                }
            }
            catch (Exception ex) {
                if (Log.ReportRetriableLanguageException(ex) != DialogResult.Retry) {
                    CanRetry = false;
                    return false;
                }
            }

        } while (CanRetry);
        if (Data is not null) {
            Data.ParseData();
            UpdateData = new() {
                FileName = RepositoryName,
                UpdateHash = Data.ExecutableHash.ToLower(),
                NewVersion = Data.VersionTag
            };
            return GotLatestUpdate = true;
        }
        return false;
    }
}