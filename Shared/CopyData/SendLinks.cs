namespace youtube_dl_gui_shared;
using System.Runtime.InteropServices;
/// <summary>
/// Represents a simple text-only structure that contains a single string for downloading. The string can contain multiple links joined with a pipe "|" character, and is 65,535 in length.
/// </summary>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct SendLinks {
    /// <summary>
    /// The argument that contains data passed between instances of youtube-dl-gui.
    /// </summary>
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65_536)]
    public string Argument { get; set; }
}