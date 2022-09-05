using System.Diagnostics;
using System.IO;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    static class Program {

        /// <summary>
        /// Gets the curent version of the program.
        /// </summary>
        public static Version CurrentVersion { get; } = new(3, 0, 0, 1);

        /// <summary>
        /// Gets whether the program is running in debug mode.
        /// </summary>
        public static bool DebugMode {
            get; private set;
        } = false;

        /// <summary>
        /// Gets or sets the exit code of the application.
        /// </summary>
        public static int ExitCode {
            get; set;
        } = 0;

        /// <summary>
        /// Gets or sets whether the update was checked this run.
        /// </summary>
        public static bool UpdateChecked {
            get; set;
        }

        private static Mutex Instance;
        private static readonly GuidAttribute ProgramGUID =
            (GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), true)[0];

        public static readonly string LocalAppDataPath =
            $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\youtube_dl_gui";
        public static readonly string ProgramPath =
            Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
        public static readonly string UserAgent =
            "User-Agent: youtube-dl-gui/" + CurrentVersion;

        static Form MainForm;
        private static bool IsFirstTime = false;

        [STAThread]
        static int Main(string[] args) {
            Instance = new Mutex(true, ProgramGUID.Value);
#if DEBUG
            DebugMode = true;
#endif

            if (Instance.WaitOne(TimeSpan.Zero, true) || DebugMode) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Log.InitializeLogging();

                if (Environment.CurrentDirectory != ProgramPath) {
                    Log.Write("The current directory is wrong. Setting it right.");
                    Environment.CurrentDirectory = ProgramPath;
                }

                Config.Settings = new Config();
                Config.Settings.Load(ConfigType.Initialization);

                if (DebugMode) {
                    LoadClasses();
                    //Application.Run(new frmExtendedDownload("https://www.youtube.com/watch?v=F8xIr28fns0"));
                    Application.Run(new frmMain());
                }
                else {
                    if (Config.Settings.Initialization.firstTime) {
                        // set this so the initializer won't load the language a second time
                        IsFirstTime = true;

                        // Select a language first
                        using frmLanguage LangPicker = new();
                        if (LangPicker.ShowDialog() == DialogResult.Yes) {
                            Config.Settings.Initialization.LanguageFile = LangPicker.LanguageFile;
                            Language.LoadLanguage(LangPicker.LanguageFile);
                        }
                        else {
                            return 1;
                        }


                        if (MessageBox.Show(Language.dlgFirstTimeInitialMessage, "youtube-dl-gui", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                            Config.Settings.Initialization.firstTime = false;

                            if (MessageBox.Show(Language.dlgFirstTimeDownloadFolder, "youtube-dl-gui", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                using BetterFolderBrowserNS.BetterFolderBrowser fbd = new();
                                fbd.Title = Language.dlgFindDownloadFolder;
                                fbd.RootFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                                if (fbd.ShowDialog() == DialogResult.OK) {
                                    Config.Settings.Downloads.downloadPath = fbd.SelectedPath;
                                }
                                else {
                                    Config.Settings.Downloads.downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                                }
                            }
                            else {
                                Config.Settings.Downloads.downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                            }

                            Config.Settings.Initialization.Save();
                            Config.Settings.Downloads.Save();
                        }
                        else {
                            return 1;
                        }
                    }

                    LoadClasses();

                    if (CheckArgs(args, true)) {
                        return 0;
                    }

                    System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                    Application.Run(MainForm = new frmMain());
                    Instance.ReleaseMutex();
                }
            }
            else {
                nint hwnd = CopyData.FindWindow(null, "youtube-dl-gui");
                if (hwnd == 0) {
                    if (args.Length > 0) {
                        CopyData.SentData Data = new() {
                            Argument = string.Join("|", args)
                        };
                        CopyData.CopyDataStruct DataStruct = new();
                        nint CopyDataBuffer = 0;
                        nint DataBuffer = 0;
                        try {
                            DataBuffer = CopyData.IntPtrAlloc(Data);
                            DataStruct.cbData = Marshal.SizeOf(Data);
                            DataStruct.dwData = 1;
                            DataStruct.lpData = DataBuffer;
                            CopyDataBuffer = CopyData.IntPtrAlloc(DataStruct);
                            CopyData.SendMessage(hwnd, CopyData.WM_COPYDATA, 0, CopyDataBuffer);
                        }
                        finally {
                            CopyData.IntPtrFree(ref CopyDataBuffer);
                            CopyData.IntPtrFree(ref DataBuffer);
                        }
                    }
                    CopyData.SendMessage(hwnd, CopyData.WM_SHOWFORM, 0, 0);
                }

                ExitCode = 1152;
            }

            return ExitCode;
        }

        static void LoadClasses() {
            if (!IsFirstTime) {
                Config.Settings.Load(ConfigType.All);

                if (Config.Settings.Initialization.LanguageFile != string.Empty && File.Exists(Environment.CurrentDirectory + "\\lang\\" + Config.Settings.Initialization.LanguageFile + ".ini")) {
                    Language.LoadLanguage(Environment.CurrentDirectory + "\\lang\\" + Config.Settings.Initialization.LanguageFile + ".ini");
                }
                else {
                    Language.LoadInternalEnglish();
                }
            }

            Verification.Refresh();
            Formats.LoadCustomFormats();
        }

        public static void KillProcessTree(uint ProcessId) {
            ManagementObjectSearcher searcher = new("SELECT * FROM Win32_Process WHERE ParentProcessId=" + ProcessId);
            ManagementObjectCollection collection = searcher.Get();
            if (collection.Count > 0) {
                foreach (var proc in collection) {
                    uint id = (uint)proc["ProcessID"];
                    if ((int)id != ProcessId) {
                        Process subProcess = Process.GetProcessById((int)id);
                        subProcess.Kill();
                    }
                }
            }
        }

        public static bool CheckArgs(string[] args, bool UseDialog) {
            if (args.Length > 1) {
                for (int i = 0; i < args.Length; i++) {
                    string CurrentArgument = args[i];
                    if (CurrentArgument.StartsWith("ytdl:")) {
                        CurrentArgument = CurrentArgument[5..];
                    }

                    switch (CurrentArgument) {
                        case "-v": case "-video":
                            i++;
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
                            break;

                        case "-a": case "-audio":
                            i++;
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
                            break;
                    }
                }
            }

            return false;
        }

        public static string CalculateSha256Hash(string File) {
            using SHA256 ComputeUpdaterHash = SHA256Cng.Create();
            using FileStream UpdaterStream = System.IO.File.OpenRead(File);
            string UpdaterHash = BitConverter.ToString(ComputeUpdaterHash.ComputeHash(UpdaterStream)).Replace("-", "").ToLower();
            UpdaterStream.Close();
            return UpdaterHash;
        }

        public static string CalculateSha1Hash(string File) {
            using SHA1 ComputeUpdaterHash = SHA1Cng.Create();
            using FileStream UpdaterStream = System.IO.File.OpenRead(File);
            string UpdaterHash = BitConverter.ToString(ComputeUpdaterHash.ComputeHash(UpdaterStream)).Replace("-", "").ToLower();
            UpdaterStream.Close();
            return UpdaterHash;
        }

        public static void RemoveTrayIcon() {
            //MainForm.RemoveTrayIcon();
        }
    }
}