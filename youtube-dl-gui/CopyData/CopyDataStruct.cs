namespace youtube_dl_gui;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
public struct CopyDataStruct {
    public nint dwData;
    public int cbData;
    public nint lpData;
}