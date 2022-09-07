namespace murrty.controls.natives;

using System.Runtime.InteropServices;

internal class NativeMethods {

    [DllImport("user32.dll")]
    public static extern nint SendMessage(nint hWnd, int Msg, nint wParam, nint lParam);

}
