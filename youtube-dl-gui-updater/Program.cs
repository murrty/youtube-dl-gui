using System;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace youtube_dl_gui_updater {
    static class Program {

        public static bool IsDebug = false;
        public static string ComputerVersionInformation;
        public static readonly Language lang = new();


        [STAThread]
        static int Main(string[] args) {
            DebugOnlyMethod();
            //string TestString = "exe sha-256: 7B72019C7800821B81710509B6D0E97EDFE27456A93CFE44E21BAB0BF2F92471\r\nzip sha-256: DD916EFF6F34CEE4AB1479165768CA7D3BF37AE1E04D109852AD4C12332C75EA(languages updated)";

            //TestString = TestString.Substring(TestString.IndexOf("exe sha-256: ") + 13);
            //TestString = TestString.Substring(0, TestString.IndexOf("\r\nzip sha"));
            //MessageBox.Show(TestString);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length >= 4) {
                UpdateInfo NewInfo = new();
                for (int CurrentArg = 0; CurrentArg < args.Length; CurrentArg++) {
                    switch (args[CurrentArg]) {

                        case "-v": case "-version": {
                            CurrentArg++;
                            NewInfo.NewVersion = args[CurrentArg];
                        } break;

                        case "-n": case "-name": {
                            CurrentArg++;
                            NewInfo.OldFileName = args[CurrentArg];
                        } break;

                        case "-l": case "-language": {
                            CurrentArg++;
                            NewInfo.LanguageFile = args[CurrentArg];
                        } break;

                        case "-h": case "-hash": {
                            CurrentArg++;
                            NewInfo.UpdateHash = args[CurrentArg].ToLower();
                        } break;

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

                InitializeExceptions();
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

        public static void InitializeExceptions() {
            using ManagementObjectSearcher searcher = new("SELECT * FROM Win32_OperatingSystem");
            using ManagementObject info = searcher.Get().Cast<ManagementObject>().FirstOrDefault();

            ComputerVersionInformation = string.Empty;

            try {
                ComputerVersionInformation +=
                    $"Version: {info.Properties["Version"].Value}\n";
            }
            catch {
                ComputerVersionInformation +=
                    $"Version: Couldn't retrieve data.\n";
            }

            try {
                ComputerVersionInformation +=
                    $"Service Pack Major: {info.Properties["ServicePackMajorVersion"].Value}\n";
            }
            catch {
                ComputerVersionInformation +=
                    $"Service Pack Major: Couldn't retrieve data.\n";
            }

            try {
                ComputerVersionInformation +=
                    $"Service Pack Minor: {info.Properties["ServicePackMinorVersion"].Value}\n";
            }
            catch {
                ComputerVersionInformation +=
                    $"Service Pack Minor: Couldn't retrieve data.\n";
            }

            try {
                ComputerVersionInformation +=
                    $"System Caption: {info.Properties["Caption"].Value}";
            }
            catch {
                ComputerVersionInformation +=
                    $"System Caption: Couldn't retrieve data.";
            }

            //ComputerVersionInformation =
            //    $"Version: {info.Properties["Version"].Value} " +
            //    $"Service Pack Major: {info.Properties["ServicePackMajorVersion"].Value} " +
            //    $"Service Pack Minor: {info.Properties["ServicePackMinorVersion"].Value} " +
            //    $"System Caption: {info.Properties["Caption"].Value}";

            AppDomain.CurrentDomain.UnhandledException += (sender, exception) => {
                using murrty.frmException UnrecoverableException = new(new(exception) {
                    Unrecoverable = true
                });
                UnrecoverableException.ShowDialog();
            };
            Application.ThreadException += (sender, exception) => {
                using murrty.frmException UnrecoverableException = new(new(exception) {
                    Unrecoverable = true
                });
                UnrecoverableException.ShowDialog();
            };
        }

        [System.Diagnostics.Conditional("DEBUG")]
        private static void DebugOnlyMethod() {
            IsDebug = true;
        }

    }
}
