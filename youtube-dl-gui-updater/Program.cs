using System;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace youtube_dl_gui_updater {

    static class Program {

        /// <summary>
        /// The exit code that the program will return. Defaults to 0.
        /// </summary>
        public static int ExitStatusCode { get; set; } = 0;
        /// <summary>
        /// If the program is debugging or built under DEBUG.
        /// </summary>
        public static bool IsDebug { get; private set; } = false;
        /// <summary>
        /// The generated string of information regarding the current computer,
        /// used for troubleshooting exceptions.
        /// </summary>
        public static string ComputerVersionInformation;
        /// <summary>
        /// The language class used by (nearly) every user-viewed control.
        /// </summary>
        public static readonly Language lang = new();

        /// <summary>
        /// Sets the <see cref="IsDebug"/> bool to true if running under DEBUG.
        /// </summary>
        [System.Diagnostics.Conditional("DEBUG")]
        private static void CheckDebug() => IsDebug = true;

        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">The array of passed arguments.</param>
        /// <returns>The <see cref="ExitStatusCode"/>.</returns>
        [STAThread]
        static int Main(string[] args) {
            CheckDebug();

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
                    ExitStatusCode = 1;
                }
                if (NewInfo.OldFileName == null) {
                    NewInfo.OldFileName = "youtube-dl-gui.exe";
                }

                InitializeExceptions();
                lang.LoadLanguage(NewInfo.LanguageFile);

                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                Application.Run(new frmUpdater(NewInfo));
                ExitStatusCode = 0;
            }
            else {
                if (MessageBox.Show("The new version wasn't properly passed. Would you like to manually update to the (or check for a) new version of youtube-dl-gui?", "youtube-dl-gui updater", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    System.Diagnostics.Process.Start("https://github.com/murrty/youtube-dl-gui/releases/latest");
                }
                ExitStatusCode = 1;
            }

            return ExitStatusCode;
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

        
    }
}
