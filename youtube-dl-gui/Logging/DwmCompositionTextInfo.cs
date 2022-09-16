namespace murrty.classes;

using System.Drawing;
using System.Runtime.InteropServices;

/// <summary>
/// A class that contains information about the text when rendering in the dwm composition.
/// </summary>
internal sealed class DwmCompositionTextInfo {
    /// <summary>
    /// The text that will be drawn.
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// The font of the text.
    /// </summary>
    public Font Font { get; set; }

    /// <summary>
    /// The color of the text.
    /// </summary>
    public Color Color { get; set; }

    /// <summary>
    /// The size of the glow behind the text. 0 is off.
    /// </summary>
    public int GlowSize { get; set; }

    /// <summary>
    /// The rectangle where the text will render in.
    /// </summary>
    public Rectangle RenderingRectangle { get; set; }

    /// <summary>
    /// Rect 1 based for the text
    /// </summary>
    public DwmNatives.RECT Rect1;

    /// <summary>
    /// Rext 2 based for the glow. ?
    /// </summary>
    public DwmNatives.RECT Rect2;

    /// <summary>
    /// DIB bitmap for the text.
    /// </summary>
    public DwmNatives.BITMAPINFO BitmapInfo;

    /// <summary>
    /// Text formatting options.
    /// </summary>
    public DwmNatives.DTTOPTS dttOpts;

    /// <summary>
    /// Format for the text.
    /// </summary>
    public int uFormat = DwmNatives.DT_SINGLELINE |
                         DwmNatives.DT_CENTER |
                         DwmNatives.DT_VCENTER |
                         DwmNatives.DT_NOPREFIX;

    /// <summary>
    /// Renderer.
    /// </summary>
    public System.Windows.Forms.VisualStyles.VisualStyleRenderer renderer =
                        new(System.Windows.Forms.VisualStyles.VisualStyleElement.Window.Caption.Active);

    public DwmCompositionTextInfo(string text, Font font, Color color, int glowsize, Rectangle rectangle) {
        Text = text;
        Font = font;
        Color = color;
        GlowSize = glowsize;
        RenderingRectangle = rectangle;

        Rect1.left = rectangle.Left;
        Rect1.right = rectangle.Right + 2;
        Rect1.top = rectangle.Top;
        Rect1.bottom = rectangle.Bottom + 2;

        Rect2.left = 0;
        Rect2.top = 0;
        Rect2.right = Rect1.right - Rect1.left;
        Rect2.bottom = Rect1.bottom - Rect1.top;

        BitmapInfo = new();
        BitmapInfo.bmiHeader.biHeight = -(Rect1.bottom - Rect1.top); // negative because DrawThemeTextEx() uses a top-down DIB
        BitmapInfo.bmiHeader.biWidth = Rect1.right - Rect1.left;
        BitmapInfo.bmiHeader.biPlanes = 1;
        BitmapInfo.bmiHeader.biSize = Marshal.SizeOf(typeof(DwmNatives.BITMAPINFOHEADER));
        BitmapInfo.bmiHeader.biBitCount = 32;
        BitmapInfo.bmiHeader.biCompression = DwmNatives.BI_RGB;

        dttOpts = new() {
            dwSize = (uint)Marshal.SizeOf(typeof(DwmNatives.DTTOPTS))
        };
        if (glowsize > 0) {
            dttOpts.dwFlags = DwmNatives.DTT_COMPOSITED |
                              DwmNatives.DTT_GLOWSIZE |
                              DwmNatives.DTT_TEXTCOLOR;
        }
        else {
            dttOpts.dwFlags = DwmNatives.DTT_COMPOSITED |
                              DwmNatives.DTT_TEXTCOLOR;
        }
        dttOpts.iGlowSize = glowsize;
        dttOpts.crText = (uint)ColorTranslator.ToWin32(color);
    }

}