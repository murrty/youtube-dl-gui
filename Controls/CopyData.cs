namespace youtube_dl_gui_shared;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal struct CopyDataStruct {
    [MarshalAs(UnmanagedType.SysInt)] public nint dwData;
    [MarshalAs(UnmanagedType.I4)] public int cbData;
    [MarshalAs(UnmanagedType.SysInt)] public nint lpData;
}
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct UpdateData {
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 257)]
    public string FileName { get; set; }
    [field: MarshalAs(UnmanagedType.Struct)]
    public Version NewVersion { get; set; }
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65)]
    public string UpdateHash { get; set; }
    public UpdateData(string FileName, Version NewVersion, string UpdateHash) {
        this.FileName = FileName;
        this.NewVersion = NewVersion;
        this.UpdateHash = UpdateHash;
    }
}
[StructLayout(LayoutKind.Sequential)]
internal readonly struct ApplicationHandles {
    public nint MessageHandle { get; }
    public int ProcessID { get; }
    public ApplicationHandles(nint MessageHandle, int ProcessID) {
        this.MessageHandle = MessageHandle;
        this.ProcessID = ProcessID;
    }
}

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
    /// Returns the LParam of a <see cref="System.Windows.Forms.Message"/> structure.
    /// </summary>
    /// <typeparam name="T">The type of the LParam to marshal as.</typeparam>
    /// <param name="msg">The message to get the param of.</param>
    /// <returns>A <typeparamref name="T"/> value from <paramref name="msg"/>.</returns>
    public static T GetParam<T>(this System.Windows.Forms.Message msg) => (T)msg.GetLParam(typeof(T));

    /// <summary>
    /// Gets the <see cref="CopyDataStruct"/> associated with the message.
    /// </summary>
    /// <param name="msg">The message to get the param of.</param>
    /// <returns>A <see cref="CopyDataStruct"/> representing the data from the LParam associated with <paramref name="msg"/>.</returns>
    public static CopyDataStruct GetCopyDataStructure(this System.Windows.Forms.Message msg) => Marshal.PtrToStructure<CopyDataStruct>(msg.LParam);

    /// <summary>
    /// Gets the bytes for the update data.
    /// </summary>
    /// <param name="Data">The updater data struct that will be sent.</param>
    /// <returns>A byte array for the update info.</returns>
    public static byte[] GetUpdateBytes(UpdateData Data) {
        byte[] FileNameBytes = Encoding.UTF8.GetBytes(Data.FileName);
        byte[] HashBytes = Encoding.ASCII.GetBytes(Data.UpdateHash);
        byte[] VersionBytes = Data.NewVersion.ToArray();
        byte[] SendBuffer = new byte[4 + HashBytes.Length + FileNameBytes.Length];
        int offset = 0;

        // 4 = Version (Major, Minor, Revision, Beta)
        //SendBuffer[offset++] = Data.NewVersion.Major;
        //SendBuffer[offset++] = Data.NewVersion.Minor;
        //SendBuffer[offset++] = Data.NewVersion.Revision;
        //SendBuffer[offset++] = Data.NewVersion.Beta;
        SendBuffer[offset++] = VersionBytes[0];
        SendBuffer[offset++] = VersionBytes[1];
        SendBuffer[offset++] = VersionBytes[2];
        SendBuffer[offset++] = VersionBytes[3];

        // 64 = Hash (Standard SHA-256)
        // This is an ASCII charset so the byte size is 1.
        for (int i = 0; i < HashBytes.Length; i++)
            SendBuffer[offset++] = HashBytes[i];

        // n = full FileName (path + name + extension)
        for (int i = 0; i < FileNameBytes.Length; i++)
            SendBuffer[offset++] = FileNameBytes[i];

        return SendBuffer;
    }
    /// <summary>
    /// Gets the UpdaterData value from the bytes sent from yt-dl-gui.
    /// </summary>
    /// <param name="LParam">Pointer to the copy data struct.</param>
    /// <returns>An updater data struct value that represents the bytes received.</returns>
    public static UpdateData GetUpdateData(nint LParam) {
        CopyDataStruct cds = Marshal.PtrToStructure<CopyDataStruct>(LParam);
        byte[] bytes = new byte[cds.cbData - 1];
        Marshal.Copy(cds.lpData, bytes, 0, cds.cbData - 1);
        return GetUpdateData(bytes);
    }
    /// <summary>
    /// Gets the UpdaterData value from the bytes sent from yt-dl-gui.
    /// </summary>
    /// <param name="Bytes">The byte array to read from.</param>
    /// <returns>An updater data struct value that represents the bytes received.</returns>
    public static UpdateData GetUpdateData(byte[] Bytes) {
        int offset = 0;
        Version NewVersion = new(Bytes[offset++], Bytes[offset++], Bytes[offset++], Bytes[offset++]);

        byte[] HashBytes = new byte[64];
        for (int i = 0; i < 64; i++)
            HashBytes[i] = Bytes[offset++];
        string UpdateHash = Encoding.ASCII.GetString(HashBytes);

        byte[] FileNameBytes = new byte[Bytes.Length - offset];
        int nameOffset = 0;
        while (offset < Bytes.Length)
            FileNameBytes[nameOffset++] = Bytes[offset++];
        string FileName = Encoding.UTF8.GetString(FileNameBytes);

        return new(FileName, NewVersion, UpdateHash);
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