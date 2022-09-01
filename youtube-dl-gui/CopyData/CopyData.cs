namespace youtube_dl_gui;

using System.Runtime.InteropServices;

internal sealed partial class CopyData {
    //  0x40 is an unused message.
    public const int WM_SHOWFORM = 0x0040;
    public const int WM_COPYDATA = 0x004A;

    public static nint IntPtrAlloc<T>(T param) {
        nint retval = Marshal.AllocHGlobal(Marshal.SizeOf(param));
        Marshal.StructureToPtr(param, retval, false);
        return retval;
    }
    public static void IntPtrFree(ref nint PreAlloc) {
        if (PreAlloc != 0) {
            Marshal.FreeHGlobal(PreAlloc);
            PreAlloc = 0;
        }
    }

    /// <summary>
    /// The FindWindow function retrieves a handle to the top-level 
    /// window whose class name and window name match the specified strings.
    /// This function does not search child windows. This function does not perform a case-sensitive search.
    /// </summary>
    /// <param name="strClassName">the class name for the window to search for</param>
    /// <param name="strWindowName">the name of the window to search for</param>
    /// <returns></returns>
    [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern nint FindWindow(string strClassName, string strWindowName);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int GetClassName(nint hWnd, StringBuilder lpClassName, int nMaxCount);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern int SendMessage(nint hWnd, int Msg, nint wParam, nint lParam);
}