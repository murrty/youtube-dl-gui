using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui {
    static class Program {
        static Mutex mtx = new Mutex(true, "{youtube-dl-gui-69-420-ayylmao}");

        [STAThread]
        static void Main() {
            if (mtx.WaitOne(TimeSpan.Zero, true)) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmMain());
                mtx.ReleaseMutex();
            }
            else {
                Controller.PostMessage((IntPtr)Controller.HWND_BROADCAST, Controller.WM_SHOWFORM, IntPtr.Zero, IntPtr.Zero);
            }
        }
    }
}