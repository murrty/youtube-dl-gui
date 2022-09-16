namespace murrty.controls;

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using murrty.controls.natives;

/// <summary>
/// Represents a derived Windows label control that can display hyperlinks, with added functionality.
/// </summary>
[System.Diagnostics.DebuggerStepThrough]
internal class ExtendedLinkLabel : LinkLabel {

    #region Fields
    /// <summary>
    /// The color the link label appears as when active (mouse down).
    /// </summary>
    private static readonly Color ActiveColor = Color.FromArgb(0xFF, 0x4B, 0x4B);

    /// <summary>
    /// The color the link label appears as.
    /// </summary>
    private static readonly Color DefaultColor = Color.FromArgb(0x00, 0x66, 0xCC);
    /// <summary>
    /// The color the link label appears as when hovered.
    /// </summary>
    private static readonly Color DefaultHoverColor = Color.FromArgb(0x33, 0x99, 0xFF);

    /// <summary>
    /// The color the link label appears as when already visited.
    /// </summary>
    private static readonly Color VisitedColor = Color.FromArgb(0x80, 0x00, 0x80);
    /// <summary>
    /// The color the link label appears as when already visted and hovered.
    /// </summary>
    private static readonly Color VisitedHoverColor = Color.FromArgb(0xA4, 0x00, 0xA4);
    #endregion

    #region Properties
    [DefaultValue(typeof(Color), "0xFF, 0xFF, 0x4B, 0x4B")]
    //[DefaultValue(typeof(Color), "0xFF, 0x4B, 0x4B")]
    //[DefaultValue(typeof(Color), "0xFF4B4B")]
    //[DefaultValue(typeof(Color), "0xFFFF4B4B")]
    //[DefaultValue(typeof(Color), "0, 255, 75, 75")]
    //[DefaultValue(typeof(Color), "255, 75, 75")]
    public new Color ActiveLinkColor {
        get => base.ActiveLinkColor;
        set => base.ActiveLinkColor = value;
    }

    [DefaultValue(typeof(Color), "0xFF, 0x00, 0x66, 0xCC")]
    //[DefaultValue(typeof(Color), "0x00, 0x66, 0xCC")]
    //[DefaultValue(typeof(Color), "0x0066CC")]
    //[DefaultValue(typeof(Color), "0xFF0066CC")]
    //[DefaultValue(typeof(Color), "0, 0, 102, 204")]
    //[DefaultValue(typeof(Color), "0, 102, 204")]
    public new Color LinkColor {
        get => base.LinkColor;
        set => base.LinkColor = value;
    }

    [DefaultValue(typeof(Color), "0xFF, 0x80, 0x00, 0x80")]
    //[DefaultValue(typeof(Color), "0x80, 0x00, 0x80")]
    //[DefaultValue(typeof(Color), "0x800080")]
    //[DefaultValue(typeof(Color), "0xFF800080")]
    //[DefaultValue(typeof(Color), "0, 128, 0, 128")]
    //[DefaultValue(typeof(Color), "128, 0, 128")]
    public new Color VisitedLinkColor {
        get => base.VisitedLinkColor;
        set => base.VisitedLinkColor = value;
    }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="ExtendedLinkLabel"/> class.
    /// </summary>
    public ExtendedLinkLabel() {
        base.ActiveLinkColor = ActiveColor;
        base.LinkColor = DefaultColor;
        base.VisitedLinkColor = VisitedColor;
    }
    #endregion

    #region Overrides
    protected override void OnHandleCreated(EventArgs e) {
        base.OnHandleCreated(e);
    }


    /// <summary>
    /// Processes the specified Windows message, overriding WM_SETCURSOR.
    /// </summary>
    /// <param name="m">The message to process.</param>
    [System.Diagnostics.DebuggerStepThrough]
    protected override void WndProc(ref Message m) {
        switch (m.Msg) {
            case Consts.WM_SETCURSOR: {
                NativeMethods.SetCursor(Consts.SystemHand);
                m.Result = IntPtr.Zero;
            } break;

            default: {
                base.WndProc(ref m);
            } break;
        }
    }

    protected override void OnMouseEnter(EventArgs e) {
        base.OnMouseEnter(e);
        this.LinkColor = DefaultHoverColor;
        this.VisitedLinkColor = VisitedHoverColor;
    }

    protected override void OnMouseLeave(EventArgs e) {
        base.OnMouseLeave(e);
        this.LinkColor = DefaultColor;
        this.VisitedLinkColor = VisitedColor;
    }
    #endregion

}