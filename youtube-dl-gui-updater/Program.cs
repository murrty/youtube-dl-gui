using System.Windows.Forms;

namespace youtube_dl_gui_updater {

    static class Program {

        public const string CurrentVersion = "1.5.0";
        public static IUpdateForm MainForm;
        public static ProgramData ProgramData;
        public static UpdaterData UpdateData;

        /// <summary>
        /// The exit code that the program will return. Defaults to 0.
        /// </summary>
        public static int StatusCode { get; set; } = 0;
        /// <summary>
        /// If the program is debugging or built under DEBUG.
        /// </summary>
        public static bool DebugMode { get; private set; } = false;

        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">The array of passed arguments.</param>
        /// <returns>The <see cref="StatusCode"/>.</returns>
        [STAThread]
        static int Main(string[] args) {
#if DEBUG
            DebugMode = true;
            Language.LoadInternalEnglish();
#else
            var Value = new StringBuilder(65535);
            NativeMethods.GetPrivateProfileString("youtube-dl-gui", "LanguageFile", "${empty}", Value, 65535, $"{Environment.CurrentDirectory}\\settings.ini");
            string LanguageFile = Value.ToString() == "${empty}" ? null : Value.ToString();
            Language.LoadLanguage(LanguageFile);
#endif

            ProgramData = new() {
                hWnd = null,
                pid = null,
                ProgramSet = false
            };

            if (args.Length >= 4) {
                bool BreakLoop = false;
                for (int i = 0; i < args.Length; i++) {
                    switch (args[i].ToLower()) {
                        case "-hwnd": {
                            if (++i >= args.Length) {
                                BreakLoop = true;
                                break;
                            }

                            if (int.TryParse(args[i], out int hwnd) && ProgramData.hWnd is null) {
                                ProgramData.hWnd = hwnd;
                            }
                        }
                        break;

                        case "-pid": {
                            if (++i >= args.Length) {
                                BreakLoop = true;
                                break;
                            }

                            if (int.TryParse(args[i], out int pid) && ProgramData.pid is null) {
                                ProgramData.pid = pid;
                            }
                        }
                        break;
                    }
                    if (BreakLoop) {
                        break;
                    }
                }
                ProgramData.ProgramSet = ProgramData.hWnd is not null && ProgramData.pid is not null;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //if (!RunningProgram.ProgramSet) {
            //    //Ask to update to the newest version, or latest.
            //}
            Application.Run((Form)(MainForm = new frmUpdater()));
            return StatusCode;
        }
        
    }
}
