namespace youtube_dl_gui_updater;

using System.Runtime.InteropServices;

internal class NativeMethods {
    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    public static extern int WritePrivateProfileString(string lpAppName,
        string lpKeyName,
        string lpString,
        string lpFileName);
    [DllImport("kernel32", CharSet = CharSet.Unicode)]
    public static extern int GetPrivateProfileString(string lpAppName,
        string lpKeyName,
        string lpDefault,
        StringBuilder lpReturnedString,
        int nSize,
        string lpFileName);
}