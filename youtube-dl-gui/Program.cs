namespace youtube_dl_gui;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using murrty.controls;
internal static class Program {
    /// <summary>
    /// Gets the curent version of the program.
    /// </summary>
    public static Version CurrentVersion { get; } = new(3, 0, 0, 2);
    /// <summary>
    /// Gets whether the program is running in debug mode.
    /// </summary>
    internal static bool DebugMode { get; private set; }
    /// <summary>
    /// Gets whether the program is running as administrator.
    /// </summary>
    public static bool IsAdmin { get; private set; }
    /// <summary>
    /// Gets or sets the exit code of the application.
    /// </summary>
    public static int ExitCode { get; internal set; }
    /// <summary>
    /// Gets or sets whether the update was checked this run.
    /// </summary>
    internal static bool UpdateChecked { get; set; }
    /// <summary>
    /// Gets or sets whether the program is starting an update.
    /// </summary>
    internal static bool IsUpdating { get; set; }

    /// <summary>
    /// Represents the GUID of the program. Used for enforcing the mutex.
    /// </summary>
    public static string ProgramGUID { get; } = ((GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), true)[0]).Value;
    /// <summary>
    /// The full path of the program.
    /// </summary>
    public static string FullProgramPath { get; } = Process.GetCurrentProcess().MainModule.FileName;
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
    internal static QueueList<Form> RunningActions { get; } = new();
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
    public static frmMain MainForm { get; private set; }
    /// <summary>
    /// The argument handler for sent arguments.
    /// </summary>
    private static MessageHandler QueueHandler { get; set; }
    /// <summary>
    /// Represents the HttpClient used through the applications' life.
    /// </summary>
    internal static ManagedHttpClient HttpClient { get; private set; }
    internal static bool UpdaterEnabled { get; private set; } = true;

    [STAThread]
    private static int Main(string[] args) {
#if DEBUG
        DebugMode = true;
        Instance = new(true, ProgramGUID);
#else
        if (!(Instance = new(true, ProgramGUID)).WaitOne(TimeSpan.Zero, true)) {
            nint hwnd = CopyData.FindWindow(null, ProgramGUID);

            if (hwnd != 0) {
                List<(ArgumentType Type, string Data)> Arguments;
                if (args.Length > 0 && (Arguments = youtube_dl_gui.Arguments.RetrieveArguments(args)).Count > 0) {
                    for (int i = 0; i < Arguments.Count; i++) {
                        nint valPointer = 0;
                        nint cdsPointer = 0;
                        try {
                            byte[] bytes = Encoding.Unicode.GetBytes(Arguments[i].Data);
                            valPointer = Marshal.AllocHGlobal(bytes.Length);
                            Marshal.Copy(bytes, 0, valPointer, bytes.Length);

                            CopyDataStruct copyData = new() {
                                dwData = (nint)Arguments[i].Type,
                                cbData = bytes.Length,
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
                            cdsPointer = 0;
                            Marshal.FreeHGlobal(valPointer);
                            valPointer = 0;
                        }
                        finally {
                            if (cdsPointer != 0) {
                                Marshal.FreeHGlobal(cdsPointer);
                            }
                            if (valPointer != 0) {
                                Marshal.FreeHGlobal(valPointer);
                            }
                        }
                    }
                }
                else CopyData.SendMessage(hwnd, CopyData.WM_SHOWFORM, 0, 0);
            }

            return 1152;
        }
#endif

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        IsAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);

        if (Environment.CurrentDirectory != ProgramPath) {
            Log.Write("The current directory is wrong.");
            Environment.CurrentDirectory = ProgramPath;
        }

        if (Initialization.firstTime) {
            Log.Write("Initiating first time setup.");
            Language.LoadInternalEnglish();

            // Select a language first
            using frmLanguage LangPicker = new();
            if (LangPicker.ShowDialog() != DialogResult.OK) {
                return 1;
            }

            if (Log.MessageBox(Language.dlgFirstTimeInitialMessage, MessageBoxButtons.YesNo) != DialogResult.Yes) {
                return 1;
            }

            Initialization.firstTime = false;
            Downloads.downloadPath =
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\youtube-dl";

            if (Log.MessageBox(Language.dlgFirstTimeDownloadFolder, MessageBoxButtons.YesNo) == DialogResult.Yes) {
                using BetterFolderBrowserNS.BetterFolderBrowser fbd = new() {
                    RootFolder = Downloads.downloadPath,
                    Title = Language.dlgFindDownloadFolder
                };

                if (fbd.ShowDialog() == DialogResult.OK) {
                    Downloads.downloadPath = fbd.SelectedPath;
                }
            }

            if (!Verification.YoutubeDlAvailable && Log.MessageBox(Language.dlgFirstTimeDownloadYoutubeDl, MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Task<bool> UpdateCheckTask = Updater.CheckForYoutubeDlUpdate();
                UpdateCheckTask.Wait();

                if (UpdateCheckTask.Result) {
                    Updater.UpdateYoutubeDl(false, null);
                }
            }

            if (!Verification.FfmpegAvailable && Log.MessageBox(Language.dlgFirstTimeDownloadFfmpeg, MessageBoxButtons.YesNo) == DialogResult.Yes) {
                Updater.UpdateFfmpeg(null).Wait();
            }

            Log.Write("First time setup has concluded.");
        }
        else {
            Language.LoadLanguage($"{Environment.CurrentDirectory}\\lang\\{Initialization.LanguageFile}.ini");
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

        //throw new Exception("test");
        murrty.controls.natives.Consts.UpdateHand();
        Formats.LoadCustomFormats();
        SetTls();

        (QueueHandler = new()).Show();

        Arguments.ParseArguments(args);
        if (CheckArgs()) {
            AwaitActions();
            return ExitCode;
        }

        // Etc.
        Thread.CurrentThread.Name = "Main application thread";
        ManagedHttpClient.UpdateDownloadClient(UserAgent);
        ManagedHttpClient.UpdateSyncContext(SynchronizationContext.Current);
        HttpClient = new();
        (MainForm = new frmMain()).ShowDialog();
        MainForm = null;

        if (RunningActions.Count > 0) {
            AwaitActions();
        }

        Instance?.ReleaseMutex();

        return ExitCode;
    }

    private static void AwaitActions() {
        QueueHandler.AwaitExit();
        Application.Run(QueueHandler);
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
                    PassedCount++;
                    if (Downloads.ExtendedDownloaderPreferExtendedForm) {
                        new frmExtendedDownloader(args[i].Data, false).Show();
                        continue;
                    }

                    // TODO: Implement the rest of the argument types
                    switch (args[i].Type) {
                        case ArgumentType.DownloadVideo: {
                            DownloadInfo NewVideo = new(args[i].Data) {
                                Type = DownloadType.Video,
                                VideoQuality = (VideoQualityType)Saved.videoQuality,
                            };
                            new frmDownloader(NewVideo).Show();
                        } break;
                        case ArgumentType.DownloadAudio: {
                            DownloadInfo NewAudio = new(args[i].Data) {
                                Type = DownloadType.Audio,
                            };
                            if (Downloads.AudioDownloadAsVBR)
                                NewAudio.AudioVBRQuality = (AudioVBRQualityType)Saved.audioQuality;
                            else
                                NewAudio.AudioCBRQuality = (AudioCBRQualityType)Saved.audioQuality;
                            new frmDownloader(NewAudio).Show();
                        } break;
                        case ArgumentType.DownloadCustom: {
                            DownloadInfo NewCustom = new(args[i].Data) {
                                Type = DownloadType.Custom,
                            };
                            new frmDownloader(NewCustom).Show();
                        } break;
                        default: {
                            PassedCount--;
                        } break;
                    }
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
            case ArgumentType.DownloadAuthenticateVideo:
            case ArgumentType.DownloadVideoNoSound:
            case ArgumentType.DownloadAuthenticateVideoNoSound: {
                AuthenticationDetails Auth = null;
                if (Type == ArgumentType.DownloadAuthenticateVideo) {
                    Auth = AuthenticationDetails.GetAuthentication();
                    if (Auth is null) {
                        Log.Write("Authentication required, but the user cancelled the dialog.");
                        return;
                    }
                }

                Form DownloadForm;
                if (Downloads.ExtendedDownloaderPreferExtendedForm) {
                    DownloadForm = new frmExtendedDownloader(
                        URL: URL,
                        CustomArguments: CustomArguments,
                        Archived: false,
                        Auth: Auth);
                }
                else {
                    DownloadInfo NewInfo = new(URL: URL) {
                        Type = DownloadType.Video,
                        VideoQuality = (VideoQualityType)Saved.videoQuality,
                        VideoFormat = (VideoFormatType)Saved.VideoFormat,
                        SkipAudioForVideos = Type == ArgumentType.DownloadVideoNoSound || Type == ArgumentType.DownloadAuthenticateVideoNoSound,
                        Arguments = CustomArguments,
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
                if (Downloads.ExtendedDownloaderPreferExtendedForm) {
                    DownloadForm = new frmExtendedDownloader(
                        URL: URL,
                        CustomArguments: CustomArguments,
                        Archived: false,
                        Auth: Auth);
                }
                else {
                    DownloadInfo NewInfo = new(URL: URL) {
                        Type = DownloadType.Audio,
                        UseVBR = Downloads.AudioDownloadAsVBR,
                        AudioFormat = (AudioFormatType)Saved.AudioFormat,
                        Arguments = CustomArguments,
                        Authentication = Auth,
                    };

                    if (Downloads.AudioDownloadAsVBR)
                        NewInfo.AudioVBRQuality = (AudioVBRQualityType)Saved.AudioVBRQuality;
                    else
                        NewInfo.AudioCBRQuality = (AudioCBRQualityType)Saved.audioQuality;

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
                if (Downloads.ExtendedDownloaderPreferExtendedForm) {
                    DownloadForm = new frmExtendedDownloader(
                        URL: URL,
                        CustomArguments: CustomArguments,
                        Archived: false,
                        Auth: Auth);
                }
                else {
                    DownloadInfo NewInfo = new(URL: URL) {
                        Type = DownloadType.Custom,
                        Arguments = CustomArguments,
                        Authentication = Auth,
                    };
                    DownloadForm = new frmDownloader(Info: NewInfo);
                }
                DownloadForm.Show();
            } break;

            case ArgumentType.DownloadArchived: {
                // TODO: Implement download archived argument
            } break;
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
                if (Downloads.ExtendedDownloaderPreferExtendedForm) {
                    DownloadForm = new frmExtendedDownloader(
                        URL: URL,
                        CustomArguments: CustomArguments,
                        Archived: false,
                        Auth: Auth);
                }
                else {
                    DownloadInfo NewInfo = new(URL: URL) {
                        Type = DownloadType.Video,
                        VideoQuality = (VideoQualityType)Saved.videoQuality,
                        VideoFormat = (VideoFormatType)Saved.VideoFormat,
                        SkipAudioForVideos = !Downloads.VideoDownloadSound,
                        Arguments = CustomArguments,
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
                if (Downloads.ExtendedDownloaderPreferExtendedForm) {
                    DownloadForm = new frmExtendedDownloader(
                        URL: URL,
                        CustomArguments: CustomArguments,
                        Archived: false,
                        Auth: Auth);
                }
                else {
                    DownloadInfo NewInfo = new(URL: URL) {
                        Type = DownloadType.Audio,
                        UseVBR = Downloads.AudioDownloadAsVBR,
                        AudioFormat = (AudioFormatType)Saved.AudioFormat,
                        Arguments = CustomArguments,
                        Authentication = Auth,
                    };

                    if (Downloads.AudioDownloadAsVBR)
                        NewInfo.AudioVBRQuality = (AudioVBRQualityType)Saved.AudioVBRQuality;
                    else
                        NewInfo.AudioCBRQuality = (AudioCBRQualityType)Saved.audioQuality;

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
                if (Downloads.ExtendedDownloaderPreferExtendedForm) {
                    DownloadForm = new frmExtendedDownloader(
                        URL: URL,
                        CustomArguments: CustomArguments,
                        Archived: false,
                        Auth: Auth);
                }
                else {
                    DownloadInfo NewInfo = new(URL: URL) {
                        Type = DownloadType.Custom,
                        Arguments = CustomArguments,
                    Authentication = Auth,
                    };
                    DownloadForm = new frmDownloader(Info: NewInfo);
                }
               DownloadForm.Show();
            } break;

            case ArgumentType.DownloadArchived: {
                if (!DownloadHelper.IsYoutubeLink(URL)) {
                    Log.Write("YouTube link given for archival download.");
                    URL = DownloadHelper.GetYoutubeVideoKey(URL);
                }

                if (!DownloadHelper.IsYoutubeKey(URL)) {
                    Log.Write("The YouTube key given for archival download is not a valid video key.");
                    return;
                }

                Form DownloadForm;
                if (Downloads.ExtendedDownloaderPreferExtendedForm) {
                    DownloadForm = new frmExtendedDownloader($"ytarchive:{URL}", true);
                }
                else {
                    DownloadInfo NewInfo = new($"https://archived.youtube.com/watch?v={URL}") {
                        Arguments = $"ytarchive:{URL}",
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

    internal static void KillForUpdate() {
        // Form diposes
        // Any downloads/conversion/merges in progress will finish before fully closing for updates.
        MainForm?.RemoveTrayIcon();
        MainForm?.Dispose();
    }

    internal static nint GetMessagesHandle() => QueueHandler.Handle;

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
                UpdaterEnabled = false;

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

    internal static void AddProcessingForm(Form form) {
        RunningActions.TryAdd(form);
    }

    internal static void RemoveProcessingForm(Form form) {
        if (RunningActions.TryRemove(form))
            QueueHandler.CheckExit();
    }
}