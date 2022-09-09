namespace youtube_dl_gui_updater;

using System.Runtime.InteropServices;

internal class NativeMethods {
    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    public static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);
}