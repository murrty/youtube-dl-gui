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

        static readonly Language lang = Language.GetInstance();
        static readonly Verification verif = Verification.GetInstance();
        static frmMain MainForm;

        [STAThread]
        static void Main(string[] args) {
            mtx = new Mutex(true, ProgramGUID.Value);
            DebugOnlyMethod();

            if (mtx.WaitOne(TimeSpan.Zero, true) || IsDebug) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (File.Exists(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe")) {
                    File.Delete(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe");
                }
                if (File.Exists(Environment.CurrentDirectory + "\\youtube-dl-gui.old.exe")) {
                    File.Delete(Environment.CurrentDirectory + "\\youtube-dl-gui.old.exe");
                }

                if (File.Exists(Ini.Path) && Ini.KeyExists("useIni") && Ini.ReadBool("useIni")) {
                    UseIni = true;
                }
                else {
                    UseIni = false;
                }

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
                                using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
                                    fbd.Description = "Select a location to save downloads to";
                                    fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                                    if (fbd.ShowDialog() == DialogResult.OK) {
                                        Config.Settings.Downloads.downloadPath = fbd.SelectedPath;
                                    }
                                    else {
                                        Config.Settings.Downloads.downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                                    }

                                }
                            }
                            else {
                                Config.Settings.Downloads.downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                            }

                            Config.Settings.Initialization.Save();
                            Config.Settings.Downloads.Save();
                        }
                        else {
                            Environment.Exit(0);
                            return;
                        }
                    }

                    if (CheckArgs(args)) {
                        Environment.Exit(0);
                        return;
                    }


                    MainForm = new frmMain();
                    Application.Run(MainForm);
                    mtx.ReleaseMutex();
                }

            }
            else {
                int hwnd = Win32.FindWindow(null, "youtube-dl-gui");
                if (hwnd == 0) {
                    hwnd = Win32.FindWindow(null, "youtube-dl-gui (ini)");
                }

                if (hwnd != 0) {
                    Win32.CopyDataStruct DataStruct = new Win32.CopyDataStruct();
                    try {
                        // check args?
                        Win32.SendMessage((IntPtr)hwnd, Win32.WM_SHOWFORM, IntPtr.Zero, ref DataStruct);
                    }
                    finally {
                        DataStruct.Dispose();
                    }
                }
            }
        }

        [System.Diagnostics.Conditional("DEBUG")]
        static void DebugOnlyMethod() {
            IsDebug = true;
        }

        static void LoadClasses() {
            Config.Settings.Load(ConfigType.All);

            verif.RefreshLocation();

            if (Config.Settings.Initialization.LanguageFile != string.Empty) {
                if (File.Exists(Environment.CurrentDirectory + "\\lang\\" + Config.Settings.Initialization.LanguageFile + ".ini")) {
                    lang.LoadLanguage(Environment.CurrentDirectory + "\\lang\\" + Config.Settings.Initialization.LanguageFile + ".ini");
                }
            }
            else {
                lang.LoadInternalEnglish();
            }
        }

        static bool CheckArgs(string[] args) {
            if (args[0].StartsWith("ytdl:")) {
                string url = args[0].Substring(5);
                frmDownloader Downloader = new frmDownloader();
                DownloadInfo NewInfo = new DownloadInfo() {
                    DownloadURL = url
                };

                switch (args[1]) {
                    case "-video":
                        NewInfo.Type = DownloadType.Video;
                        NewInfo.VideoQuality = (VideoQualityType)Config.Settings.Saved.videoQuality;
                        Downloader.ShowDialog();
                        break;
                    case "-audio":
                        NewInfo.Type = DownloadType.Audio;
                        if (Config.Settings.Downloads.AudioDownloadAsVBR) {
                            NewInfo.AudioVBRQuality = (AudioVBRQualityType)Config.Settings.Saved.audioQuality;
                        }
                        else {
                            NewInfo.AudioCBRQuality = (AudioCBRQualityType)Config.Settings.Saved.audioQuality;
                        }
                        Downloader.ShowDialog();
                        break;

                    default:
                        NewInfo.Dispose();
                        Downloader.Dispose();
                        return false;
                }

                return true;
            }

            return false;
        }
    }
}
