namespace youtube_dl_gui_shared;
using System.Runtime.InteropServices;
/// <summary>
/// Represents a structure with data for passing update data between youtube-dl-gui and the updater.
/// </summary>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct UpdaterData {
    /// <summary>
    /// The full path to the file, with the desired file name.
    /// <para/>
    /// The length of the string is limited to 256 characters.
    /// </summary>
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 257)]
    public string FileName { get; set; }
    /// <summary>
    /// The tag of the new version.
    /// <para/>
    /// The length of the string is limited to 15 characters.
    /// </summary>
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
    public string NewVersion { get; set; }
    /// <summary>
    /// The SHA-256 hash of the new version to verify. The program will display a warning if the value is NULL or does not match the generated SHA-256 of the downloaded stub.
    /// <para/>
    /// The length of the string is limited to 64 characters, which is the length of a standard SHA-256 hash.
    /// </summary>
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65)]
    public string UpdateHash { get; set; }
}