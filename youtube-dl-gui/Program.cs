using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    static class Program {

        /// <summary>
        /// The current version of the program.
        /// </summary>
        public const decimal CurrentVersion = 2.3m;
        /// <summary>
        /// Whether the program is a beta version.
        /// </summary>
        public const bool IsBetaVersion = true;
        /// <summary>
        /// The version of the current beta program.
        /// </summary>
        public const string BetaVersion = "2.31-pre2";

        /// <summary>
        /// Gets or sets whether the update was checked this run.
        /// </summary>
        public static bool UpdateChecked {
            get; set;
        }

        //public static readonly string ProgramPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        private static readonly GuidAttribute ProgramGUID = (GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), true)[0];
        public static readonly string LocalAppDataPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\youtube_dl_gui";
        public static readonly string ProgramPath = Environment.CurrentDirectory;
        public static readonly string UserAgent = "User-Agent: youtube-dl-gui/" + CurrentVersion;
        public static bool IsDebug = false;
        public static bool UseIni = false;
        static Mutex mtx;

        public static readonly Language lang = new();
        public static readonly Verification verif = new();
        static frmMain MainForm;
        private static bool IsFirstTime = false;

        [STAThread]
        static int Main(string[] args) {
            mtx = new Mutex(true, ProgramGUID.Value);
#if DEBUG
            IsDebug = true;
#endif

            if (mtx.WaitOne(TimeSpan.Zero, true) || IsDebug) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Log.InitializeLogging();

                UseIni = File.Exists(Ini.Path) && Ini.KeyExists("useIni") && Ini.ReadBool("useIni");
                Config.Settings = new Config();
                Config.Settings.Load(ConfigType.Initialization);

                if (IsDebug) {
                    LoadClasses();
                    MainForm = new frmMain();
                    Application.Run(MainForm);
                }
                else {
                    if (Config.Settings.Initialization.firstTime) {
                        // set this so the initializer won't load the language a second time
                        IsFirstTime = true;

                        // Select a language first
                        using frmLanguage LangPicker = new();
                        if (LangPicker.ShowDialog() == DialogResult.Yes) {
                            Config.Settings.Initialization.LanguageFile = LangPicker.LanguageFile;
                            lang.LoadLanguage(LangPicker.LanguageFile);
                        }
                        else {
                            return 1;
                        }


                        if (MessageBox.Show(lang.dlgFirstTimeInitialMessage, "youtube-dl-gui", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                            Config.Settings.Initialization.firstTime = false;

                            if (MessageBox.Show(lang.dlgFirstTimeDownloadFolder, "youtube-dl-gui", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                using BetterFolderBrowserNS.BetterFolderBrowser fbd = new();
                                fbd.Title = lang.dlgFindDownloadFolder;
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
                    Application.Run(MainForm = new());
                    mtx.ReleaseMutex();
                }
                return 0;

            }
            else {
                IntPtr hwnd = CopyData.FindWindow(null, "youtube-dl-gui");
                if (hwnd == IntPtr.Zero) {
                    hwnd = CopyData.FindWindow(null, "youtube-dl-gui (ini)");
                }
                if (hwnd != IntPtr.Zero) {
                    if (args.Length > 0) {
                        CopyData.SentData Data = new() {
                            Argument = string.Join("|", args)
                        };
                        CopyData.CopyDataStruct DataStruct = new();
                        IntPtr CopyDataBuffer = IntPtr.Zero;
                        IntPtr DataBuffer = IntPtr.Zero;
                        try {
                            DataBuffer = CopyData.IntPtrAlloc(Data);
                            DataStruct.cbData = Marshal.SizeOf(Data);
                            DataStruct.dwData = new(1);
                            DataStruct.lpData = DataBuffer;
                            CopyDataBuffer = CopyData.IntPtrAlloc(DataStruct);
                            CopyData.SendMessage(hwnd, CopyData.WM_COPYDATA, IntPtr.Zero, CopyDataBuffer);
                        }
                        finally {
                            CopyData.IntPtrFree(ref CopyDataBuffer);
                            CopyData.IntPtrFree(ref DataBuffer);
                        }
                    }
                    CopyData.SendMessage(hwnd, CopyData.WM_SHOWFORM, IntPtr.Zero, IntPtr.Zero);
                }

                return 0;
            }
        }

        static void LoadClasses() {
            if (!IsFirstTime) {
                Config.Settings.Load(ConfigType.All);

                if (Config.Settings.Initialization.LanguageFile != string.Empty && File.Exists(Environment.CurrentDirectory + "\\lang\\" + Config.Settings.Initialization.LanguageFile + ".ini")) {
                    lang.LoadLanguage(Environment.CurrentDirectory + "\\lang\\" + Config.Settings.Initialization.LanguageFile + ".ini");
                }
                else {
                    lang.LoadInternalEnglish();
                }
            }

            verif.Refresh();
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
    }
}
