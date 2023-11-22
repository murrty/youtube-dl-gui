#nullable enable
namespace murrty.controls.natives;
using System.Runtime.InteropServices;
internal static class NativeMethods {
    /// <summary>
    /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window and does not return until the window procedure has processed the message.
    /// <para>To send a message and return immediately, use the SendMessageCallback or SendNotifyMessage function.To post a message to a thread's message queue and return immediately, use the PostMessage or PostThreadMessage function.</para>
    /// </summary>
    /// <param name="hWnd">A handle to the window whose window procedure will receive the message. If this parameter is HWND_BROADCAST ((HWND)0xffff), the message is sent to all top-level windows in the system, including disabled or invisible unowned windows, overlapped windows, and pop-up windows; but the message is not sent to child windows.</param>
    /// <param name="wMsg">The message to be sent.</param>
    /// <param name="wParam">Additional message-specific information.</param>
    /// <param name="lParam">Additional message-specific information.</param>
    /// <returns>The return value specifies the result of the message processing; it depends on the message sent.</returns>
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    internal static extern nint SendMessage(
        [In] nint hWnd,
        [In] nint wMsg,
        [In] nint wParam,
        [In] nint lParam);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    internal static extern nint SendMessage(
        [In] nint hWnd,
        [In] nint wMsg,
        [In] nint wParam,
        [In] ref System.Drawing.Point lParam);

    /// <summary>
    /// Loads the specified cursor resource from the executable (.EXE) file associated with an application instance.
    /// This function has been superseded by the LoadImage function.
    /// </summary>
    /// <param name="hInstance">A handle to an instance of the module whose executable file contains the cursor to be loaded.</param>
    /// <param name="lpCursorName">The name of the cursor resource to be loaded. Alternatively, this parameter can consist of the resource identifier in the low-order word and zero in the high-order word. The MAKEINTRESOURCE macro can also be used to create this value. To use one of the predefined cursors, the application must set the hInstance parameter to NULL and the lpCursorName parameter to a valid value.</param>
    /// <returns>If the function succeeds, the return value is the handle to the newly loaded cursor. If the function fails, the return value is NULL.</returns>
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    internal static extern nint LoadCursor(
        [In, Optional] nint hInstance,
        [In] nint lpCursorName);

    /// <summary>
    /// Sets the cursor shape.
    /// </summary>
    /// <param name="hCursor">A handle to the cursor. The cursor must have been created by the CreateCursor function or loaded by the LoadCursor or LoadImage function. If this parameter is NULL, the cursor is removed from the screen.</param>
    /// <returns>The return value is the handle to the previous cursor, if there was one. If there was no previous cursor, the return value is NULL.</returns>
    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    internal static extern nint SetCursor(
       [In, Optional] nint hCursor);

    /// <summary>
    /// Causes a window to use a different set of visual style information than its class normally uses.
    /// </summary>
    /// <param name="hwnd">Handle to the window whose visual style information is to be changed.</param>
    /// <param name="pszSubAppName">Pointer to a string that contains the application name to use in place of the calling application's name. If this parameter is NULL, the calling application's name is used.</param>
    /// <param name="pszSubIdList">Pointer to a string that contains a semicolon-separated list of CLSID names to use in place of the actual list passed by the window's class. If this parameter is NULL, the ID list from the calling class is used.</param>
    /// <returns>If this function succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code.</returns>
    [DllImport("uxtheme.dll", EntryPoint = "SetWindowTheme", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
    internal static extern int SetWindowTheme(
        [In] nint hwnd,
        [In] string pszSubAppName,
        [In] string pszSubIdList);
}