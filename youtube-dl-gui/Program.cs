using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {
    static class Program {
        private static readonly GuidAttribute ProgramGUID = (GuidAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(GuidAttribute), true)[0];
        //public static readonly string ProgramPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        public static readonly string ProgramPath = Environment.CurrentDirectory;
        public static readonly string LocalAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
                                                         "\\youtube_dl_gui";
        public static readonly string UserAgent = "User-Agent: youtube-dl-gui/" + Properties.Settings.Default.CurrentVersion;
        public static bool IsDebug = false;
        public static bool UseIni = false;
        static Mutex mtx;

        public static readonly Language lang = new();
        public static readonly Verification verif = new();
        static frmMain MainForm;

        [STAThread]
        static int Main(string[] args) {

            Convert.GetFiletype("Test.flv");

            mtx = new Mutex(true, ProgramGUID.Value);
            DebugOnlyMethod();
            ErrorLog.AssembleComputerVersionInformation();

            if (mtx.WaitOne(TimeSpan.Zero, true) || IsDebug) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (File.Exists(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe")) {
                    File.Delete(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe");
                }
                if (File.Exists(Environment.CurrentDirectory + "\\youtube-dl-gui.old.exe")) {
                    File.Delete(Environment.CurrentDirectory + "\\youtube-dl-gui.old.exe");
                }

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
                        if (MessageBox.Show("youtube-dl-gui is a visual extension to youtube-dl and is not affiliated with the developers of youtube-dl in any way.\n\nThis program (and I) does not condone piracy or illegally downloading of any video you do not own the rights to or is not in public domain.\n\nAny help regarding any problems when downloading anything illegal (in my jurisdiction) will be ignored. This message will not appear again.\n\nHave you read the above?", "youtube-dl-gui", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                            Config.Settings.Initialization.firstTime = false;

                            if (MessageBox.Show("Downloads are saved to your downloads folder by default, would you like to specify a different location now?\n(You can change this in the settings at any time)", "youtube-dl-gui", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                                using BetterFolderBrowserNS.BetterFolderBrowser fbd = new();
                                fbd.Title = "Select a directory to save downloads to...";
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
                    MainForm = new();
                    Application.Run(MainForm);
                    mtx.ReleaseMutex();
                }
                return 0;

            }
            else {
                int hwnd = Win32.FindWindow(null, "youtube-dl-gui");
                if (hwnd == 0) {
                    hwnd = Win32.FindWindow(null, "youtube-dl-gui (ini)");
                }

                if (hwnd != 0) {
                    Win32.CopyDataStruct DataStruct = new();
                    try {
                        if (args.Length >= 1) {
                            string NewArgumnet = string.Join("|", args);
                            DataStruct.cbData = (NewArgumnet.Length + 1) * 2;
                            DataStruct.lpData = Win32.LocalAlloc(0x40, DataStruct.cbData);
                            Marshal.Copy(NewArgumnet.ToCharArray(), 0, DataStruct.lpData, NewArgumnet.Length);
                            DataStruct.dwData = (IntPtr)1;
                            Win32.SendMessage((IntPtr)hwnd, Win32.WM_COPYDATA, IntPtr.Zero, ref DataStruct);
                        }
                        Win32.SendMessage((IntPtr)hwnd, Win32.WM_SHOWFORM, IntPtr.Zero, ref DataStruct);
                    }
                    finally {
                        DataStruct.Dispose();
                    }
                }
                return 0;
            }
        }

        [System.Diagnostics.Conditional("DEBUG")]
        static void DebugOnlyMethod() {
            IsDebug = true;
        }

        static void LoadClasses() {
            Config.Settings.Load(ConfigType.All);

            verif.RefreshLocation();
            Formats.LoadCustomFormats();

            if (Config.Settings.Initialization.LanguageFile != string.Empty) {
                if (File.Exists(Environment.CurrentDirectory + "\\lang\\" + Config.Settings.Initialization.LanguageFile + ".ini")) {
                    lang.LoadLanguage(Environment.CurrentDirectory + "\\lang\\" + Config.Settings.Initialization.LanguageFile + ".ini");
                }
            }
            else {
                lang.LoadInternalEnglish();
            }
        }

        public static bool CheckArgs(string[] args, bool UseDialog) {
            if (args.Length > 1) {
                for (int i = 0; i < args.Length; i++) {
                    string CurrentArgument = args[i];
                    if (CurrentArgument.StartsWith("ytdl:")) {
                        CurrentArgument = CurrentArgument.Substring(5);
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
    }
}
