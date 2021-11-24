using System;
using System.Windows.Forms;

namespace youtube_dl_gui_updater {
    static class Program {

        public static volatile bool IsDebug = false;

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DebugOnlyMethod();

            Application.Run(new frmUpdater());
        }

        [System.Diagnostics.Conditional("DEBUG")]
        static void DebugOnlyMethod() {
            IsDebug = true;
        }
    }
}
