namespace youtube_dl_gui;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct UpdaterData {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 257)]
    public string FileName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    public string NewVersion;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65)]
    public string UpdateHash;
}