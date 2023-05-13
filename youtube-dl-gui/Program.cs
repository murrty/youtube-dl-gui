namespace youtube_dl_gui;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
internal static class Program {
    /// <summary>
    /// Gets the curent version of the program.
    /// </summary>
    public static Version CurrentVersion { get; } = new(3, 3, 0, 1);
    /// <summary>
    /// Gets whether the program is running in debug mode.
    /// </summary>
    internal static bool DebugMode { get; private set; } = false;
    /// <summary>
    /// Gets whether the program is running as administrator.
    /// </summary>
    public static bool IsAdmin { get; private set; } = false;
    /// <summary>
    /// Gets or sets the exit code of the application.
    /// </summary>
    public static int ExitCode { get; internal set; } = 0;
    /// <summary>
    /// Gets or sets whether the update was checked this run.
    /// </summary>
    internal static bool UpdateChecked { get; set; } = false;
    /// <summary>
    /// Gets or sets whether the program is starting an update.
    /// </summary>
    internal static bool IsUpdating { get; set; } = false;

    /// <summary>
    /// Represents the GUID of the program. Used for enforcing the mutex.
    /// </summary>
    public static string ProgramGUID { get; } = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value;
    /// <summary>
    /// The full path of the program.
    /// </summary>
    public static string FullProgramPath { get; private set; } = Process.GetCurrentProcess().MainModule.FileName;
    /// <summary>
    /// The path of the program, not inculding file name.
    /// </summary>
    public static string ProgramPath { get; } = Path.GetDirectoryName(FullProgramPath);
    /// <summary>
    /// The user-agent used for web client calls.
    /// </summary>
    public static string UserAgent { get; } = "youtube-dl-gui/" + CurrentVersion;

    /// <summary>
    /// The list of running downloads or conversions.
    /// </summary>
    internal static HashSet<Form> RunningActions { get; } = new();
    /// <summary>
    /// The image list used for batch actions.
    /// </summary>
    internal static ImageList BatchStatusImages { get; private set; }
    /// <summary>
    /// The image list used for the extended downloader.
    /// </summary>
    internal static ImageList ExtendedDownloaderSelectedImages { get; private set; }

    /// <summary>
    /// The mutex used for enforcing the applications' single instance.
    /// </summary>
    private static Mutex Instance { get; set; }
    /// <summary>
    /// The main form used for the application.
    /// </summary>
    private static frmMain MainForm { get; set; }
    /// <summary>
    /// The message handler for the updater.
    /// </summary>
    private static MessageHandler Messages { get; set; }

    [STAThread]
    private static int Main(string[] args) {
#if DEBUG
        DebugMode = true;
#endif

        if (DebugMode || (Instance = new(true, ProgramGUID)).WaitOne(TimeSpan.Zero, true)) {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IsAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
            Log.InitializeLogging();

            if (Environment.CurrentDirectory != ProgramPath) {
                Log.Write("The current directory is wrong.");
                Environment.CurrentDirectory = ProgramPath;
            }

            BatchStatusImages = new() {
                ColorDepth = ColorDepth.Depth32Bit,
                TransparentColor = System.Drawing.Color.Transparent
            };
            BatchStatusImages.Images.Add(Properties.Resources.waiting);  // 0
            BatchStatusImages.Images.Add(Properties.Resources.download); // 1
            BatchStatusImages.Images.Add(Properties.Resources.finished); // 2
            BatchStatusImages.Images.Add(Properties.Resources.error);    // 3

            ExtendedDownloaderSelectedImages = new() {
                ColorDepth = ColorDepth.Depth32Bit,
                TransparentColor = System.Drawing.Color.Transparent
            };
            ExtendedDownloaderSelectedImages.Images.Add(Properties.Resources.best);             // 0
            ExtendedDownloaderSelectedImages.Images.Add(Properties.Resources.selected);         // 1
            ExtendedDownloaderSelectedImages.Images.Add(Properties.Resources.best_disabled);    // 2
            ExtendedDownloaderSelectedImages.Images.Add(Properties.Resources.selected_disabled);// 3

            (Config.Settings = new Config()).Load(ConfigType.All);
            Verification.Refresh();
            if (Config.Settings.Initialization.firstTime) {
                Log.Write("Initiating first time setup.");
                Language.LoadInternalEnglish();

                // Select a language first
                using frmLanguage LangPicker = new();
                if (LangPicker.ShowDialog() != DialogResult.OK)
                    return 1;
                Config.Settings.Initialization.Save();

                if (Log.MessageBox(Language.dlgFirstTimeInitialMessage, MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return 1;

                Config.Settings.Initialization.firstTime = false;
                Config.Settings.Downloads.downloadPath =
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\youtube-dl";

                if (Log.MessageBox(Language.dlgFirstTimeDownloadFolder, MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    if (Environment.OSVersion.Platform == PlatformID.Win32NT) {
                        using BetterFolderBrowserNS.BetterFolderBrowser fbd = new() {
                            RootFolder = Config.Settings.Downloads.downloadPath,
                            Title = Language.dlgFindDownloadFolder
                        };

                        if (fbd.ShowDialog() == DialogResult.OK)
                            Config.Settings.Downloads.downloadPath = fbd.SelectedPath;
                    }
                    else {
                        using FolderBrowserDialog fbd = new() {
                            SelectedPath = Config.Settings.Downloads.downloadPath,
                            Description = Language.dlgFindDownloadFolder
                        };

                        if (fbd.ShowDialog() == DialogResult.OK)
                            Config.Settings.Downloads.downloadPath = fbd.SelectedPath;
                    }
                }

                if (!Verification.YoutubeDlAvailable
                && Log.MessageBox(Language.dlgFirstTimeDownloadYoutubeDl, MessageBoxButtons.YesNo) == DialogResult.Yes
                && UpdateChecker.CheckForYoutubeDlUpdate())
                    UpdateChecker.UpdateYoutubeDl(null);

                if (!Verification.FfmpegAvailable &&
                Log.MessageBox(Language.dlgFirstTimeDownloadFfmpeg, MessageBoxButtons.YesNo) == DialogResult.Yes)
                    UpdateChecker.UpdateFfmpeg(null);

                Config.Settings.Initialization.Save();
                Config.Settings.Downloads.Save();

                Log.Write("First time setup has concluded.");
            }
            else {
                Language.LoadLanguage($"{Environment.CurrentDirectory}\\lang\\{Config.Settings.Initialization.LanguageFile}.ini");
            }

            //throw new Exception("test");
            murrty.controls.natives.Consts.UpdateHand();
            Formats.LoadCustomFormats();
            Messages = new();
            SetTls();

            Arguments.ParseArguments(args);
            if (CheckArgs()) {
                AwaitActions();
                return 0;
            }

            (MainForm = new frmMain()).ShowDialog();

            if (RunningActions.Count > 0)
                AwaitActions();

            if (!DebugMode)
                Instance.ReleaseMutex();
        }
        else {
            nint hwnd = CopyData.FindWindow(null, Language.ApplicationName);

            if (hwnd == 0 && args.Length > 0)
                hwnd = CopyData.FindWindow(null, ProgramGUID);

            if (hwnd != 0) {
                List<(ArgumentType Type, string Data)> Arguments;
                if (args.Length > 0 && (Arguments = youtube_dl_gui.Arguments.RetrieveArguments(args)).Count > 0) {
                    for (int i = 0; i < Arguments.Count; i++) {
                        nint valPointer = 0;
                        nint cdsPointer = 0;
                        try {
                            byte[] bytes = Encoding.Unicode.GetBytes(Arguments[0].Data);
                            valPointer = Marshal.AllocHGlobal(bytes.Length);
                            Marshal.Copy(bytes, 0, valPointer, bytes.Length);

                            CopyDataStruct copyData = new() {
                                dwData = (nint)Arguments[i].Type,
                                cbData = Encoding.Unicode.GetByteCount(Arguments[i].Data),
                                lpData = valPointer
                            };

                            cdsPointer = CopyData.NintAlloc(copyData);
                            CopyData.SendMessage(
                                hWnd: hwnd,
                                Msg: CopyData.WM_COPYDATA,
                                wParam: 0x1,
                                lParam: cdsPointer);

                            // wParam should be the handle to the Window that sent the message.
                            // Since WM_COPYDATA is overridden, I can DO WHAT I WANT.
                            // Regardless, wParam is unused in this program, so.
                            // 0x1 = The data was sent from another instance.

                            Marshal.FreeHGlobal(cdsPointer);
                            Marshal.FreeHGlobal(valPointer);
                        }
                        finally {
                            if (valPointer != 0)
                                Marshal.FreeHGlobal(valPointer);
                            if (cdsPointer != 0)
                                Marshal.FreeHGlobal(cdsPointer);
                        }
                    }
                    //nint ArgAddress = 0;
                    //SendLinks Arg = new(args.JoinUntilLimit("|", 65_535));
                    //nint CopyDataAddress = 0;
                    //CopyDataStruct DataStruct = new();
                    //try {
                    //    ArgAddress = CopyData.NintAlloc(Arg);
                    //    DataStruct.cbData = Marshal.SizeOf(Arg);
                    //    DataStruct.dwData = 1;
                    //    DataStruct.lpData = ArgAddress;
                    //    CopyDataAddress = CopyData.NintAlloc(DataStruct);
                    //    CopyData.SendMessage(hwnd, CopyData.WM_COPYDATA, 0, CopyDataAddress);
                    //}
                    //finally {
                    //    CopyData.NintFree(ref CopyDataAddress);
                    //    CopyData.NintFree(ref ArgAddress);
                    //}
                }
                else {
                    CopyData.SendMessage(hwnd, CopyData.WM_SHOWFORM, 0, 0);
                }
            }

            return 1152;
        }

        if (RunningActions.Count > 0) {
            AwaitActions();
        }

        return ExitCode;
    }

    private static void AwaitActions() {
        Application.Run(new ExitQueueHandler());
    }

    internal static void KillProcessTree(uint ProcessId) {
        ManagementObjectSearcher searcher = new("SELECT * FROM Win32_Process WHERE ParentProcessId=" + ProcessId);
        ManagementObjectCollection collection = searcher.Get();
        if (collection.Count > 0) {
            foreach (var proc in collection) {
                uint id = (uint)proc["ProcessID"];
                if ((int)id != ProcessId) {
                    try {
                        KillProcessTree(id);
                        Process procInstance = Process.GetProcessById((int)id);
                        if (!procInstance.HasExited)
                            procInstance.Kill();
                    }
                    //catch (ArgumentException) {
                    //    // Not running?
                    //}
                    //catch (System.ComponentModel.Win32Exception w32) {
                    //    //w32.NativeErrorCode
                    //}
                    catch (Exception ex) {
                        Log.ReportException(ex);
                    }
                }
            }
        }
    }

    internal static bool CheckArgs(List<(ArgumentType Type, string Data)> args = null) {
        args ??= Arguments.ParsedArguments;
        if (args.Count > 0) {
            int PassedCount = 0;
            for (int i = 0; i < args.Count; i++) {
                if (!args[i].Data.IsNullEmptyWhitespace()) {
                    if (Config.Settings.Downloads.ExtendedDownloaderPreferExtendedForm) {
                        new frmExtendedDownloader(args[i].Data, false).Show();
                    }
                    else {
                        switch (args[i].Type) {
                            case ArgumentType.DownloadVideo: {
                                DownloadInfo NewVideo = new() {
                                    DownloadURL = args[i].Data,
                                    Type = DownloadType.Video,
                                    VideoQuality = (VideoQualityType)Config.Settings.Saved.videoQuality
                                };
                                new frmDownloader(NewVideo).Show();
                            } break;
                            case ArgumentType.DownloadAudio: {
                                DownloadInfo NewAudio = new() {
                                    DownloadURL = args[i].Data,
                                    Type = DownloadType.Audio,
                                };
                                if (Config.Settings.Downloads.AudioDownloadAsVBR)
                                    NewAudio.AudioVBRQuality = (AudioVBRQualityType)Config.Settings.Saved.audioQuality;
                                else
                                    NewAudio.AudioCBRQuality = (AudioCBRQualityType)Config.Settings.Saved.audioQuality;
                                new frmDownloader(NewAudio).Show();
                            } break;
                            case ArgumentType.DownloadCustom: {
                                DownloadInfo NewCustom = new() {
                                    DownloadURL = args[i].Data,
                                    Type = DownloadType.Custom,
                                };
                                new frmDownloader(NewCustom).Show();
                            } break;
                        }
                    }
                    PassedCount++;
                }
            }
            return PassedCount > 0;
        }
        return false;
    }

    internal static void ParseCopyData(ref Message m, string CustomArguments) {
        CopyDataStruct cds = Marshal.PtrToStructure<CopyDataStruct>(m.LParam);
        byte[] bytes = new byte[cds.cbData];
        Marshal.Copy(cds.lpData, bytes, 0, cds.cbData);
        string URL = Encoding.Unicode.GetString(bytes);
        ArgumentType Type = (ArgumentType)cds.dwData;
        switch (Type) {
            case ArgumentType.DownloadVideo:
            case ArgumentType.DownloadAudio:
            case ArgumentType.DownloadCustom:
            case ArgumentType.DownloadAuthenticateVideo:
            case ArgumentType.DownloadAuthenticateAudio:
            case ArgumentType.DownloadAuthenticateCustom:
            case ArgumentType.DownloadArchived: {
                ProcessCopyData(URL, Type, CustomArguments);
            } break;

            default: break;
        }
    }

    internal static void ProcessCopyData(string URL, ArgumentType Type, string CustomArguments) {
        Log.Write($"ProcessCopyData called: {Type} > {URL ?? "null"}");

        switch (Type) {
            case ArgumentType.DownloadVideo:
            case ArgumentType.DownloadAuthenticateVideo: {
                AuthenticationDetails Auth = null;
                if (Type == ArgumentType.DownloadAuthenticateVideo) {
                    Auth = AuthenticationDetails.GetAuthentication();
                    if (Auth is null) {
                        Log.Write("Authentication required, but the user cancelled the dialog.");
                        return;
                    }
                }

                Form DownloadForm;
                if (Config.Settings.Downloads.ExtendedDownloaderPreferExtendedForm) {
                    DownloadForm = new frmExtendedDownloader(
                        URL: URL,
                        CustomArguments: CustomArguments,
                        Archived: false,
                        Auth: Auth);
                }
                else {
                    DownloadInfo NewInfo = new(URL: URL) {
                        Type = DownloadType.Video,
                        VideoQuality = (VideoQualityType)Config.Settings.Saved.videoQuality,
                        VideoFormat = (VideoFormatType)Config.Settings.Saved.VideoFormat,
                        SkipAudioForVideos = !Config.Settings.Downloads.VideoDownloadSound,
                        DownloadArguments = CustomArguments,
                        Authentication = Auth,
                    };
                    DownloadForm = new frmDownloader(Info: NewInfo);
                }
                DownloadForm.Show();
            } break;

            case ArgumentType.DownloadAudio:
            case ArgumentType.DownloadAuthenticateAudio: {
                AuthenticationDetails Auth = null;
                if (Type == ArgumentType.DownloadAuthenticateAudio) {
                    Auth = AuthenticationDetails.GetAuthentication();
                    if (Auth is null) {
                        Log.Write("Authentication required, but the user cancelled the dialog.");
                        return;
                    }
                }

                Form DownloadForm;
                if (Config.Settings.Downloads.ExtendedDownloaderPreferExtendedForm) {
                    DownloadForm = new frmExtendedDownloader(
                        URL: URL,
                        CustomArguments: CustomArguments,
                        Archived: false,
                        Auth: Auth);
                }
                else {
                    DownloadInfo NewInfo = new(URL: URL) {
                        Type = DownloadType.Audio,
                        UseVBR = Config.Settings.Downloads.AudioDownloadAsVBR,
                        AudioFormat = (AudioFormatType)Config.Settings.Saved.AudioFormat,
                        DownloadArguments = CustomArguments,
                        Authentication = Auth,
                    };

                    if (Config.Settings.Downloads.AudioDownloadAsVBR) {
                        NewInfo.AudioVBRQuality = (AudioVBRQualityType)Config.Settings.Saved.AudioVBRQuality;
                    }
                    else {
                        NewInfo.AudioCBRQuality = (AudioCBRQualityType)Config.Settings.Saved.audioQuality;
                    }

                    DownloadForm = new frmDownloader(Info: NewInfo);
                }
                DownloadForm.Show();
            } break;

            case ArgumentType.DownloadCustom:
            case ArgumentType.DownloadAuthenticateCustom: {
                AuthenticationDetails Auth = null;
                if (Type == ArgumentType.DownloadAuthenticateCustom) {
                    Auth = AuthenticationDetails.GetAuthentication();
                    if (Auth is null) {
                        Log.Write("Authentication required, but the user cancelled the dialog.");
                        return;
                    }
                }

                Form DownloadForm;
                if (Config.Settings.Downloads.ExtendedDownloaderPreferExtendedForm) {
                    DownloadForm = new frmExtendedDownloader(
                        URL: URL,
                        CustomArguments: CustomArguments,
                        Archived: false,
                        Auth: Auth);
                }
                else {
                    DownloadInfo NewInfo = new(URL: URL) {
                        Type = DownloadType.Custom,
                        DownloadArguments = CustomArguments,
                    Authentication = Auth,
                    };
                    DownloadForm = new frmDownloader(Info: NewInfo);
                }
               DownloadForm.Show();
            } break;

            case ArgumentType.DownloadArchived: {
                if (DownloadHelper.IsYoutubeLink(URL)) {
                    Log.Write("YouTube link given for archival download.");
                    URL = DownloadHelper.GetYoutubeVideoKey(URL);
                }
                if (!DownloadHelper.IsYoutubeKey(URL)) {
                    Log.Write("The YouTube key given for archival download is not a valid video key.");
                    return;
                }

                Form DownloadForm;
                if (Config.Settings.Downloads.ExtendedDownloaderPreferExtendedForm) {
                    DownloadForm = new frmExtendedDownloader($"ytarchive:{URL}", true);
                }
                else {
                    DownloadInfo NewInfo = new() {
                        DownloadArguments = $"ytarchive:{URL}",
                        DownloadURL = $"https://archived.youtube.com/watch?v={URL}",
                        MostlyCustomArguments = true,
                        Type = DownloadType.Custom
                    };
                    DownloadForm = new frmDownloader(NewInfo);
                }
                DownloadForm.Show();
            } break;
        }
    }

    internal static string CalculateSha256Hash(string File) {
        using SHA256 ComputeUpdaterHash = SHA256.Create();
        using FileStream UpdaterStream = System.IO.File.OpenRead(File);
        string UpdaterHash = BitConverter.ToString(ComputeUpdaterHash.ComputeHash(UpdaterStream)).Replace("-", "").ToLowerInvariant();
        UpdaterStream.Close();
        return UpdaterHash;
    }

    internal static nint GetMessagesHandle() {
        return Messages.Handle;
    }

    internal static void KillForUpdate() {
        // Form diposes
        // Any downloads/conversion/merges in progress will finish before fully closing for updates.
        MainForm?.RemoveTrayIcon();
        MainForm?.Dispose();
        Messages?.Dispose();
    }

    internal static void SetTls() {
        try { //try TLS 1.3
            System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)12288
                                                            | (System.Net.SecurityProtocolType)3072
                                                            | (System.Net.SecurityProtocolType)768
                                                            |  System.Net.SecurityProtocolType.Tls;
            Log.Write("TLS 1.3 will be used.");
        }
        catch (NotSupportedException) {
            try { //try TLS 1.2
                System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072
                                                                | (System.Net.SecurityProtocolType)768
                                                                |  System.Net.SecurityProtocolType.Tls;
                Log.Write("TLS 1.2 will be used.");
            }
            catch (NotSupportedException) {
                try { //try TLS 1.1
                    System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)768
                                                                    |  System.Net.SecurityProtocolType.Tls;
                    Log.Write("TLS 1.1 will be used, Github updating may be affected.");
                }
                catch (NotSupportedException) { //TLS 1.0
                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls;
                    Log.Write("TLS 1.0 will be used, Github updating may be affected.");
                }
            }
        }
    }
}