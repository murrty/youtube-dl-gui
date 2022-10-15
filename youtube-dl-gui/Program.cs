using System.Diagnostics;
using System.IO;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    internal static class Program {

        /// <summary>
        /// Gets the curent version of the program.
        /// </summary>
        public static Version CurrentVersion { get; } = new(3, 1, 1);

        /// <summary>
        /// Gets whether the program is running in debug mode.
        /// </summary>
        internal static bool DebugMode {
            get; private set;
        } = false;

        /// <summary>
        /// Gets or sets the exit code of the application.
        /// </summary>
        public static int ExitCode {
            get; internal set;
        } = 0;

        /// <summary>
        /// Gets or sets whether the update was checked this run.
        /// </summary>
        internal static bool UpdateChecked {
            get; set;
        }

        /// <summary>
        /// Gets or sets whether the program is starting an update.
        /// </summary>
        internal static bool IsUpdating {
            get; set;
        } = false;

        /// <summary>
        /// Represents the GUID of the program. Used for enforcing the mutex.
        /// </summary>
        private static readonly GuidAttribute ProgramGUID =
            (GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), true)[0];
        /// <summary>
        /// The directory of the program.
        /// </summary>
        public static readonly string ProgramPath =
            Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        /// <summary>
        /// The user-agent used for web client calls.
        /// </summary>
        public static readonly string UserAgent = "youtube-dl-gui/" + CurrentVersion;

        /// <summary>
        /// The list of running downloads or conversions.
        /// </summary>
        internal static readonly HashSet<Form> RunningActions = new();
        /// <summary>
        /// The image list used for batch actions.
        /// </summary>
        internal static ImageList BatchStatusImages;
        /// <summary>
        /// The image list used for the extended downloader.
        /// </summary>
        internal static ImageList ExtendedDownloaderSelectedImages;

        /// <summary>
        /// The mutex used for enforcing the applications' single instance.
        /// </summary>
        private static Mutex Instance;
        /// <summary>
        /// The main form used for the application.
        /// </summary>
        private static frmMain MainForm;
        /// <summary>
        /// The idle thread used when argument-downloads are ran, to prevent the program from dying too early.
        /// </summary>
        private static Thread ArgumentWaitThread;
        /// <summary>
        /// The message handler for the updater.
        /// </summary>
        private static MessageHandler Messages;

        [STAThread]
        private static int Main(string[] args) {
#if DEBUG
            DebugMode = true;
            //Uri.IsWellFormedUriString("wherearethefafefjoesgjhersuifhudesfhiua", UriKind.RelativeOrAbsolute);
#endif

            if (DebugMode || (Instance = new(true, ProgramGUID.Value)).WaitOne(TimeSpan.Zero, true)) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
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
                ExtendedDownloaderSelectedImages.Images.Add(Properties.Resources.best);         // 0
                ExtendedDownloaderSelectedImages.Images.Add(Properties.Resources.selected);     // 1
                ExtendedDownloaderSelectedImages.Images.Add(Properties.Resources.best_disabled);    // 2
                ExtendedDownloaderSelectedImages.Images.Add(Properties.Resources.selected_disabled);// 3

                (Config.Settings = new Config()).Load(ConfigType.All);
                Verification.Refresh();
                if (Config.Settings.Initialization.firstTime) {
                    Log.Write("Initiating first time setup.");
                    Language.LoadInternalEnglish();

                    // Select a language first
                    using frmLanguage LangPicker = new();
                    if (LangPicker.ShowDialog() != DialogResult.Yes)
                        return 1;

                    Config.Settings.Initialization.LanguageFile = LangPicker.LanguageFile;
                    Language.LoadLanguage(LangPicker.LanguageFile);
                    Config.Settings.Initialization.Save();

                    if (MessageBox.Show(Language.dlgFirstTimeInitialMessage, Language.ApplicationName, MessageBoxButtons.YesNo) != DialogResult.Yes)
                        return 1;

                    Config.Settings.Initialization.firstTime = false;
                    Config.Settings.Downloads.downloadPath =
                        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\youtube-dl";

                    if (MessageBox.Show(Language.dlgFirstTimeDownloadFolder, Language.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        using BetterFolderBrowserNS.BetterFolderBrowser fbd = new();
                        fbd.Title = Language.dlgFindDownloadFolder;
                        fbd.RootFolder = Config.Settings.Downloads.downloadPath;
                        if (fbd.ShowDialog() == DialogResult.OK)
                            Config.Settings.Downloads.downloadPath = fbd.SelectedPath;
                    }

                    if (MessageBox.Show(Language.dlgFirstTimeDownloadYoutubeDl, Language.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes
                    && UpdateChecker.CheckForYoutubeDlUpdate())
                        UpdateChecker.UpdateYoutubeDl(null);
                    if (MessageBox.Show(Language.dlgFirstTimeDownloadFfmpeg, Language.ApplicationName, MessageBoxButtons.YesNo) == DialogResult.Yes)
                        UpdateChecker.UpdateFfmpeg(null);

                    Config.Settings.Initialization.Save();
                    Config.Settings.Downloads.Save();

                    Log.Write("First time setup has concluded.");
                }
                else {
                    Language.LoadLanguage($"{Environment.CurrentDirectory}\\lang\\{Config.Settings.Initialization.LanguageFile}.ini");
                }

                murrty.controls.natives.Consts.UpdateHand();
                Formats.LoadCustomFormats();
                Messages = new();
                SetTls();

                if (CheckArgs(args, true)) {
                    AwaitActions();
                    return 0;
                }

                //frmExtendedDownloader f = new();
                //f.ShowDialog();

                (MainForm = new frmMain()).ShowDialog();
                if (!DebugMode) {
                    Instance.ReleaseMutex();
                }
            }
            else {
                nint hwnd = CopyData.FindWindow(null, Language.ApplicationName);
                if (hwnd == 0) {
                    if (args.Length > 0) {
                        SentData Data = new() {
                            Argument = string.Join("|", args)
                        };
                        CopyDataStruct DataStruct = new();
                        nint CopyDataBuffer = 0;
                        nint DataBuffer = 0;
                        try {
                            DataBuffer = CopyData.NintAlloc(Data);
                            DataStruct.cbData = Marshal.SizeOf(Data);
                            DataStruct.dwData = 1;
                            DataStruct.lpData = DataBuffer;
                            CopyDataBuffer = CopyData.NintAlloc(DataStruct);
                            CopyData.SendMessage(hwnd, CopyData.WM_COPYDATA, 0, CopyDataBuffer);
                        }
                        finally {
                            CopyData.NintFree(ref CopyDataBuffer);
                            CopyData.NintFree(ref DataBuffer);
                        }
                    }
                    CopyData.SendMessage(hwnd, CopyData.WM_SHOWFORM, 0, 0);
                }

                return 1152;
            }

            if (RunningActions.Count > 0) {
                AwaitActions();
            }

            return ExitCode;
        }

        private static void AwaitActions() {
            Form IdleForm = new() {
                Opacity = 0,
                FormBorderStyle = FormBorderStyle.None,
                ShowIcon = false,
                ShowInTaskbar = false,
            };
            IdleForm.Load += (s, e) => {
                ArgumentWaitThread = new(() => {
                    while (RunningActions.Count > 0) {
                        Thread.Sleep(1000);
                    }
                    IdleForm.Invoke(() => IdleForm.Dispose());
                }) {
                    Name = "Awaiting actions"
                };
                ArgumentWaitThread.Start();
            };
            Application.Run(IdleForm);
            Thread.Sleep(5000);
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
                            Process.GetProcessById((int)id).Kill();
                        }
                        catch (ArgumentException) {
                            // Not running?
                        }
                        catch (Exception ex) {
                            Log.ReportException(ex);
                        }
                    }
                }
            }
        }

        internal static bool CheckArgs(string[] args, bool UseDialog) {
            if (args.Length > 1) {
                int PassedCount = 0;
                for (int i = 0; i < args.Length; i++) {
                    string CurrentArgument = args[i];
                    if (CurrentArgument.StartsWith("ytdl:")) {
                        CurrentArgument = CurrentArgument[5..];
                    }

                    switch (Config.Settings.Downloads.YtdlType) {
                        case 0 when Config.Settings.Downloads.ExtendedDownloaderPreferExtendedForm:
                        case 2 when Config.Settings.Downloads.ExtendedDownloaderPreferExtendedForm: {
                            if (++i >= args.Length)
                                return false;

                            frmExtendedDownloader ExtendedDownload = new(args[i], false);
                            if (UseDialog) {
                                ExtendedDownload.ShowDialog();
                            }
                            else {
                                ExtendedDownload.Show();
                            }
                        } break;

                        default: {
                            switch (CurrentArgument) {
                                case "-v": case "-video": {
                                    if (++i >= args.Length)
                                        return false;

                                    DownloadInfo NewVideo = new() {
                                        DownloadURL = args[i],
                                        Type = DownloadType.Video,
                                        VideoQuality = (VideoQualityType)Config.Settings.Saved.videoQuality
                                    };
                                    frmDownloader VideoDownloader = new(NewVideo);
                                    if (UseDialog) {
                                        VideoDownloader.ShowDialog();
                                    }
                                    else {
                                        VideoDownloader.Show();
                                    }
                                    PassedCount++;

                                } break;

                                case "-a": case "-audio": {
                                    if (++i >= args.Length)
                                        return false;

                                    DownloadInfo NewAudio = new() {
                                        DownloadURL = args[i],
                                        Type = DownloadType.Audio
                                    };
                                    if (Config.Settings.Downloads.AudioDownloadAsVBR) {
                                        NewAudio.AudioVBRQuality = (AudioVBRQualityType)Config.Settings.Saved.audioQuality;
                                    }
                                    else {
                                        NewAudio.AudioCBRQuality = (AudioCBRQualityType)Config.Settings.Saved.audioQuality;
                                    }

                                    frmDownloader AudioDownloader = new(NewAudio);
                                    if (UseDialog) {
                                        AudioDownloader.ShowDialog();
                                    }
                                    else {
                                        AudioDownloader.Show();
                                    }
                                    PassedCount++;
                                } break;
                            }
                        } break;
                    }

                }
            }

            return false;
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
}