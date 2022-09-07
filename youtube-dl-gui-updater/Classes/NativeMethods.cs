using System;
using System.Runtime.InteropServices;

namespace murrty.controls {
    internal class NativeMethods {

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern nint SendMessage(nint hWnd, int wMsg, nint wParam, nint lParam);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        public static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

    }
}
