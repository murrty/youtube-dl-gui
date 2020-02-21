using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui {
    static class Program {
        static Mutex mtx = new Mutex(true, "{youtube-dl-gui-2019-05-13}");
        public static readonly string UserAgent = "User-Agent: youtube-dl-gui/" + Properties.Settings.Default.appVersion;
        public static volatile bool IsDebug = false;

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #if DEBUG
                IsDebug = true;
            #else 
                IsDebug = false;
            #endif

            // boot determines if the application can proceed.
            bool AllowLaunch = false;

            if (Properties.Settings.Default.firstTime && !IsDebug) {
                if (MessageBox.Show("youtube-dl-gui is a visual extension to youtube-dl and is not affiliated with the developers of youtube-dl in any way.\n\nThis program (and I) does not condone piracy or illegally downloading of any video you do not own the rights to or is not in public domain.\n\nAny help regarding any problems when downloading anything illegal (in my jurisdiction) will be ignored. If you've read the above, click no to continue into the application. This message will not appear again.\n\nHave you read the above?", "youtube-dl-gui", MessageBoxButtons.YesNo) == DialogResult.No) {
                    Properties.Settings.Default.firstTime = false;

                    if (MessageBox.Show("Downloads are saved to your downloads folder by default, would you like to specify a different location now?\n(You can change this in the settings at any time)", "youtube-dl-gui", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
                            fbd.Description = "Select a location to save downloads to";
                            fbd.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                            if (fbd.ShowDialog() == DialogResult.OK) {
                                Downloads.Default.downloadPath = fbd.SelectedPath;
                                Downloads.Default.Save();
                            }
                        }
                    }
                    else {
                        Downloads.Default.downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                    }

                    Properties.Settings.Default.Save();
                    AllowLaunch = true;
                }
            }
            else {
                AllowLaunch = true;
            }

            if (AllowLaunch) {
                if (mtx.WaitOne(TimeSpan.Zero, true)) {
                    Application.Run(new frmMain());
                    mtx.ReleaseMutex();
                }
                else {
                    Controller.PostMessage((IntPtr)Controller.HWND_YTDLGUIBROADCAST, Controller.WM_SHOWYTDLGUIFORM, IntPtr.Zero, IntPtr.Zero);
                }
            }
            else {
                Environment.Exit(0);
            }
        }
    }
}
