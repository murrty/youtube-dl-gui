using System;
using System.Windows.Forms;

namespace youtube_dl_gui_updater {
    static class Program {
        public static volatile bool IsDebug = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
#if DEBUG
            IsDebug = true;
#else
            IsDebug = false;
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmUpdater());
        }
    }
}
