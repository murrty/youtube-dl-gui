namespace murrty.controls.natives;

using System.Runtime.InteropServices;

internal static class NativeMethods {
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
    public static extern nint SendMessage(nint hWnd, int wMsg, nint wParam, nint lParam);
}