using System;
using System.Windows.Forms;

namespace youtube_dl_gui_updater {
    static class Program {

        public static volatile bool IsDebug = false;
        public static readonly Language lang = new Language();

        [STAThread]
        static void Main() {
            DebugOnlyMethod();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmUpdater());
        }

        [System.Diagnostics.Conditional("DEBUG")]
        static void DebugOnlyMethod() {
            IsDebug = true;
        }
    }
}
