namespace youtube_dl_gui_shared;

using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// Contains data to be passed to another application by the WM_COPYDATA message.
/// </summary>
/// <param name="dwData">The type of the data to be passed to the receiving application. The receiving application defines the valid types.</param>
/// <param name="cbData">The size, in bytes, of the data pointed to by the lpData member.</param>
/// <param name="lpData">The data to be passed to the receiving application.</param>
[StructLayout(LayoutKind.Sequential)]
public record struct CopyDataStruct(
    [MarshalAs(UnmanagedType.SysInt)] nint dwData,
    [MarshalAs(UnmanagedType.I4)] int cbData,
    [MarshalAs(UnmanagedType.SysInt)] nint lpData);

/// <summary>
/// Represents a structure with data for passing update data between youtube-dl-gui and the updater.
/// </summary>
/// <param name="FileName">
/// The full path to the file, with the desired file name.
/// <para/>
/// The length of the string is limited to 256 characters.
/// </param>
/// <param name="NewVersion">
/// The tag of the new version.
/// <para/>
/// The length of the string is limited to 15 characters.
/// </param>
/// <param name="UpdateHash">
/// The SHA-256 hash of the new version to verify.
/// The program will display a warning if the value is NULL or does not match the generated SHA-256 of the downloaded stub.
/// <para/>
/// The length of the string is limited to 64 characters, which is the length of a standard SHA-256 hash.
/// </param>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public record struct UpdaterData(
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 257)] string FileName,
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)] string NewVersion,
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65)] string UpdateHash);

internal static class CopyData {
    /// <summary>
    /// An application sends the WM_COPYDATA message to pass data to another application.
    /// <para />
    /// wParam should have the handle of the window passing the data, and lParam must be a pointer to a COPYDATASTRUCT that contains the data.
    /// </summary>
    public const int WM_COPYDATA = 0x004A;
    /// <summary>
    /// A non-standard window message that tells a form to display itself.
    /// </summary>
    public const int WM_SHOWFORM = 0x1000;
    /// <summary>
    /// A non-standard window message that tells the main application to generate and send the new update data to the stub application.
    /// </summary>
    public const int WM_UPDATEDATAREQUEST = 0x1001;
    /// <summary>
    /// A non-standard window message that tells the main application that the updater is ready and that it can exit.
    /// The stub applcation should await for the process to end before performing the update, but it may download the update to prepare to move instead.
    /// </summary>
    public const int WM_UPDATERREADY = 0x1002;

    /// <summary>
    /// Allocates a structure to unmanaged memory.
    /// </summary>
    /// <typeparam name="StructVal">The struct type that will be allocated.</typeparam>
    /// <param name="Structure">The structure object to allocate.</param>
    /// <returns>A pointer address to the structure data in unmanaged memory.</returns>
    public static nint NintAlloc<StructVal>(StructVal Structure) {
        nint PointerAddress = Marshal.AllocHGlobal(Marshal.SizeOf(Structure));
        Marshal.StructureToPtr(Structure, PointerAddress, true);
        return PointerAddress;
    }

    /// <summary>
    /// De-allocates a structure from unmanaged memory.
    /// </summary>
    /// <param name="PreAlloc">The allocated address to free from unmanaged memory.</param>
    public static void NintFree(ref nint PreAlloc) {
        if (PreAlloc != 0) {
            Marshal.FreeHGlobal(PreAlloc);
            PreAlloc = 0;
        }
    }

    /// <summary>
    /// Generates a structure from the data in the LParam value of a WM_COPYDATA message.
    /// </summary>
    /// <typeparam name="T">The struct type that will be generated from the message.</typeparam>
    /// <param name="LParam">The structure object address to generate the data from.</param>
    /// <returns>A new struct with the data passed from WM_COPYDATA if the address contains valid data for the structure; otherwise, the default value.</returns>
    public static T GetParam<T>(nint LParam) {
        try {
            var DataStruct = Marshal.PtrToStructure<CopyDataStruct>(LParam);
            return Marshal.PtrToStructure<T>(DataStruct.lpData);
        }
        catch {
            return default;
        }
    }

    /// <summary>
    /// The FindWindow function retrieves a handle to the top-level 
    /// window whose class name and window name match the specified strings.
    /// This function does not search child windows. This function does not perform a case-sensitive search.
    /// </summary>
    /// <param name="strClassName">the class name for the window to search for</param>
    /// <param name="strWindowName">the name of the window to search for</param>
    /// <returns>The HANDLE of the found window if one was found; otherwise, 0.</returns>
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern nint FindWindow(
        string strClassName,
        string strWindowName);

    //[DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    //public static extern int GetClassName(
    //    nint hWnd,
    //    StringBuilder lpClassName,
    //    int nMaxCount);

    /// <summary>
    /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
    /// </summary>
    /// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
    /// <param name="Msg">The message to be sent.</param>
    /// <param name="wParam">Additional message-specific information.</param>
    /// <param name="lParam">Additional message-specific information.</param>
    /// <returns></returns>
    [DllImport("user32.dll", SetLastError = true)]
    public static extern int SendMessage(
        nint hWnd,
        int Msg,
        nint wParam,
        nint lParam);
}