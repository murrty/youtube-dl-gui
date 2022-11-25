namespace murrty.controls.natives;
using System.Reflection;
using System.Windows.Forms;

internal static class Consts {

    /// <summary>
    /// Sets the left margin.
    /// </summary>
    public const nint EC_LEFTMARGIN = 1;
    /// <summary>
    /// Sets the right margin.
    /// </summary>
    public const nint EC_RIGHTMARGIN = 2;
    /// <summary>
    /// Sets the widths of the left and right margins for an edit control. The message redraws the control to reflect the new margins. You can send this message to either an edit control or a rich edit control.
    /// </summary>
    public const int EM_SETMARGINS = 0xd3;

    /// <summary>
    /// The PBM_SETSTATE message for setting the state of a progress bar.
    /// </summary>
    public const int PBM_SETSTATE = 0x410;

    /// <summary>
    /// The WndProc message for setting the systems' cursor.
    /// </summary>
    public const int WM_SETCURSOR = 0x20;
    /// <summary>
    /// The user32.h resource identifier for the systems' hand cursor.
    /// </summary>
    public const nint IDC_HAND = 32649;
    /// <summary>
    /// The WM_PAINT message is sent when the system or another application makes a request to paint a portion of an application's window.
    /// The message is sent when the UpdateWindow or RedrawWindow function is called, or by the DispatchMessage function when the application obtains a WM_PAINT message by using the GetMessage or PeekMessage function.
    /// </summary>
    public const int WM_PAINT = 0xF;
    public const int WS_EX_COMPOSITED = 0x02000000;
    public const int WM_ERASEBKGND = 0x14;

    public static void UpdateHand() =>
        typeof(Cursors)
        .GetField("hand", BindingFlags.Static | BindingFlags.NonPublic)?
        .SetValue(null, new Cursor(NativeMethods.LoadCursor(0, IDC_HAND)));

}
