namespace youtube_dl_gui_shared;
using System.Runtime.InteropServices;
/// <summary>
/// Contains data to be passed to another application by the WM_COPYDATA message.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct CopyDataStruct {
    /// <summary>
    /// The type of the data to be passed to the receiving application. The receiving application defines the valid types.
    /// </summary>
    public nint dwData { get; set; }
    /// <summary>
    /// The size, in bytes, of the data pointed to by the lpData member.
    /// </summary>
    public int cbData { get; set; }
    /// <summary>
    /// The data to be passed to the receiving application. This member can be NULL.
    /// </summary>
    public nint lpData { get; set; }
}