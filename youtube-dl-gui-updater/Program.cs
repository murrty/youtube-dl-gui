namespace youtube_dl_gui_updater;

using System.IO;
using System.Reflection;
using System.Windows.Forms;
using murrty.controls;
using murrty.updater;

static class Program {
    internal static string ApplicationName => fApplicationName;
    internal static string ApplicationPath => fApplicationPath;
    internal static string FullApplicationPath => fFullApplicationPath;

    private static readonly string fApplicationName = AppDomain.CurrentDomain.FriendlyName;
    private static readonly string fApplicationPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    private static readonly string fFullApplicationPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

    internal static ManagedHttpClient DownloadClient { get; private set; }
    internal static CancellationTokenSource CancelToken { get; private set; }

    public static Version CurrentVersion { get; } = new(1, 6, 0);
    internal static string UserAgent { get; } = $"youtube_dl_gui-updater/{CurrentVersion}";
    internal static DownloadType Type { get; private set; } = DownloadType.None;

    public static int ExitCode { get; set; } = 0;

    [STAThread]
    static int Main(string[] args) {
#if DEBUG
        Language.LoadInternalEnglish();
#else
        var Value = new StringBuilder(65535);
        NativeMethods.GetPrivateProfileString("youtube-dl-gui", "LanguageFile", "${empty}", Value, 65535, $"{Environment.CurrentDirectory}\\youtube-dl-gui.ini");
        string LanguageFile = Value.ToString() == "${empty}" ? null : Value.ToString();
        Language.LoadLanguage(LanguageFile);
#endif

        nint Handle = 0;
        int ProcessID = 0;
        if (args.Length > 0) {
            bool BreakLoop = false;
            for (int i = 0; i < args.Length; i++) {
                switch (args[i].ToLowerInvariant()) {
                    case "-hwnd": {
                        if (++i >= args.Length) {
                            BreakLoop = true;
                            break;
                        }
                        if (int.TryParse(args[i], out int hwnd))
                            Handle = hwnd;
                    }
                    break;
                    case "-pid": {
                        if (++i >= args.Length) {
                            BreakLoop = true;
                            break;
                        }
                        if (int.TryParse(args[i], out int pid))
                            ProcessID = pid;
                    }
                    break;
                }
                if (BreakLoop) break;
            }
        }

        ApplicationHandles? ApplicationData = null;
        UpdateData? UpdateData = null;

        ManagedHttpClient.UpdateDownloadClient(UserAgent);
        DownloadClient = new();
        CancelToken = new();

        if (Handle != 0 && ProcessID != 0) {
            ApplicationData = new(Handle, ProcessID);
        }

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        murrty.controls.natives.Consts.UpdateHand();

        if (Environment.CurrentDirectory != ApplicationPath)
            Environment.CurrentDirectory = ApplicationPath;

        if (ApplicationData is null && UpdateData is null && !InvalidData())
            return 1;

        SetTls();
        Application.Run(ApplicationData is not null ? new frmUpdater(ApplicationData) : new frmUpdater(UpdateData));
        return ExitCode;
    }
    
    private static bool InvalidData() {
        using frmUpdaterInvalidData Invalid = new();
        Type = Invalid.ShowDialog() switch {
            DialogResult.Yes => DownloadType.PreRelease,
            DialogResult.No => DownloadType.Latest,
            _ => DownloadType.None
        };
        return Type != DownloadType.None;
    }
    internal static void SetTls() {
        try { //try TLS 1.3
            System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)12288
                                                            | (System.Net.SecurityProtocolType)3072
                                                            | (System.Net.SecurityProtocolType)768
                                                            | System.Net.SecurityProtocolType.Tls;
        }
        catch (NotSupportedException) {
            try { //try TLS 1.2
                System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072
                                                                | (System.Net.SecurityProtocolType)768
                                                                | System.Net.SecurityProtocolType.Tls;
            }
            catch (NotSupportedException) {
                try { //try TLS 1.1
                    System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)768
                                                                    | System.Net.SecurityProtocolType.Tls;
                }
                catch (NotSupportedException) { //TLS 1.0
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls;
                }
            }
        }
    }
}