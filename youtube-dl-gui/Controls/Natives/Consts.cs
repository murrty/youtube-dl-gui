namespace murrty.controls.natives;

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
    public const int WM_SETCURSOR = 0x0020;
    /// <summary>
    /// The user32.h resource identifier for the systems' hand cursor.
    /// </summary>
    public const nint IDC_HAND = 32649;
    /// <summary>
    /// The WM_PAINT message is sent when the system or another application makes a request to paint a portion of an application's window.
    /// The message is sent when the UpdateWindow or RedrawWindow function is called, or by the DispatchMessage function when the application obtains a WM_PAINT message by using the GetMessage or PeekMessage function.
    /// </summary>
    public const int WM_PAINT = 0xF;

    /// <summary>
    /// The IntPtr value of IDC_HAND.
    /// </summary>
    public static readonly nint SystemHand = NativeMethods.LoadCursor(0, IDC_HAND);

}
