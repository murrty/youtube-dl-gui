namespace youtube_dl_gui_updater;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct CopyDataStruct {
    public nint dwData;
    public int cbData;
    public nint lpData;
}