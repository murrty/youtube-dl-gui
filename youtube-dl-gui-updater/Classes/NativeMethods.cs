using System;
using System.Runtime.InteropServices;

namespace murrty.controls {
    internal class NativeMethods {

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

    }
}
