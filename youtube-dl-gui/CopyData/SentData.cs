namespace youtube_dl_gui;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct SentData {
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65_534)]
    public string Argument;
}