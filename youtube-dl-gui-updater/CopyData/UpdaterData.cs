namespace youtube_dl_gui_updater;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct UpdaterData {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    public string RepoName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public string FileName;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    public string NewVersion;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public string UpdateHash;
}