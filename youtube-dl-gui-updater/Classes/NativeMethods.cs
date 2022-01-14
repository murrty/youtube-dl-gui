using System;
using System.Runtime.InteropServices;

namespace youtube_dl_gui_updater {
    class NativeMethods {

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

    }
}
