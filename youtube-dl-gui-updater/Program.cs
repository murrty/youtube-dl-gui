using System;
using System.Windows.Forms;

namespace youtube_dl_gui_updater {
    static class Program {

        public static bool IsDebug = false;
        public static readonly Language lang = new Language();

        [STAThread]
        static int Main(string[] args) {
            DebugOnlyMethod();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            if (args.Length >= 4) {
                UpdateInfo NewInfo = new UpdateInfo();

                for (int CurrentArg = 0; CurrentArg < args.Length; CurrentArg++) {
                    switch (args[CurrentArg]) {
                        case "-v": case "-version":
                            CurrentArg++;
                            NewInfo.NewVersion = args[CurrentArg];
                            break;

                        case "-n": case "-name":
                            CurrentArg++;
                            NewInfo.OldFileName = args[CurrentArg];
                            break;

                        case "-l": case "-language":
                            CurrentArg++;
                            NewInfo.LanguageFile = args[CurrentArg];
                            break;
                    }
                }

                if (NewInfo.NewVersion == null) {
                    if (MessageBox.Show("The new version wasn't properly passed. Would you like to manually update to the (or check for a) new version of youtube-dl-gui?", "youtube-dl-gui updater", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                        System.Diagnostics.Process.Start("https://github.com/murrty/youtube-dl-gui/releases/latest");
                    }
                    return 1;
                }
                if (NewInfo.OldFileName == null) {
                    NewInfo.OldFileName = "youtube-dl-gui.exe";
                }

                lang.LoadLanguage(NewInfo.LanguageFile);

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                //Application.Run(new frmException());
                Application.Run(new frmUpdater(NewInfo));
                return 0;
            }
            else {
                if (MessageBox.Show("The new version wasn't properly passed. Would you like to manually update to the (or check for a) new version of youtube-dl-gui?", "youtube-dl-gui updater", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    System.Diagnostics.Process.Start("https://github.com/murrty/youtube-dl-gui/releases/latest");
                }
                return 1;
            }
        }

        [System.Diagnostics.Conditional("DEBUG")]
        private static void DebugOnlyMethod() {
            IsDebug = true;
        }

    }
}
