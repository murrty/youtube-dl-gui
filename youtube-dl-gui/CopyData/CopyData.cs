namespace youtube_dl_gui;

using System.Runtime.InteropServices;

internal sealed class CopyData {

    public const int WM_COPYDATA = 0x004A;
    public const int WM_SHOWFORM = 0x1000;
    public const int WM_UPDATEDATAREQUEST = 0x1001;
    public const int WM_UPDATEDATA = 0x1002;
    public const int WM_UPDATERREADY = 0x1003;

    public static nint NintAlloc<StructVal>(StructVal param) {
        nint retval = Marshal.AllocHGlobal(Marshal.SizeOf(param));
        Marshal.StructureToPtr(param, retval, false);
        return retval;
    }

    public static void NintFree(ref nint PreAlloc) {
        if (PreAlloc != 0) {
            Marshal.FreeHGlobal(PreAlloc);
            PreAlloc = 0;
        }
    }

    public static T GetParam<T>(nint LParam) {
        var DataStruct = Marshal.PtrToStructure<CopyDataStruct>(LParam);
        return Marshal.PtrToStructure<T>(DataStruct.lpData);
    }

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern nint FindWindow(string strClassName, string strWindowName);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern int SendMessage(nint hWnd, int Msg, nint wParam, nint lParam);
}