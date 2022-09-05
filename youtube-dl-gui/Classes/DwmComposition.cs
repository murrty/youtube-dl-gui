namespace murrty.classes;

using System.Drawing;
using System.Runtime.InteropServices;

/// <summary>
/// Contains p/invoke and consts used for rendering dwm and text.
/// </summary>
public sealed class DwmNatives {
    /// <summary>
    /// Draws text with antialiased alpha.
    /// Use of this flag requires a top-down DIB section.
    /// This flag works only if the HDC passed to function DrawThemeTextEx has a top-down DIB section currently selected in it.
    /// </summary>
    public const int DTT_COMPOSITED = (int)(1UL << 13);
    /// <summary>
    /// The iGlowSize member value is valid.
    /// </summary>
    public const int DTT_GLOWSIZE = (int)(1UL << 11);
    /// <summary>
    /// The crText member value is valid.
    /// </summary>
    public const int DTT_TEXTCOLOR = 1;

    //Text format consts
    /// <summary>
    /// Displays text on a single line only.
    /// Carriage returns and line feeds do not break the line.
    /// </summary>
    public const int DT_SINGLELINE = 0x00000020;
    /// <summary>
    /// Centers text horizontally in the rectangle.
    /// </summary>
    public const int DT_CENTER = 0x00000001;
    /// <summary>
    /// Centers text vertically. This value is used only with the DT_SINGLELINE value.
    /// </summary>
    public const int DT_VCENTER = 0x00000004;
    /// <summary>
    /// Turns off processing of prefix characters.
    /// Normally, DrawText interprets the mnemonic-prefix character & as a directive to underscore the character that follows, and the mnemonic-prefix characters && as a directive to print a single &.
    /// By specifying DT_NOPREFIX, this processing is turned off.
    /// </summary>
    public const int DT_NOPREFIX = 0x00000800;

    //Const for BitBlt
    /// <summary>
    /// Copies the source rectangle directly to the destination rectangle.
    /// </summary>
    public const int SRCCOPY = 0x00CC0020;

    //Consts for CreateDIBSection
    /// <summary>
    /// Uncompressed RGB.
    /// </summary>
    public const int BI_RGB = 0;
    /// <summary>
    /// The color table contains literal RGB values.
    /// </summary>
    public const int DIB_RGB_COLORS = 0; //color table in RGBs

    // Moving the form.
    /// <summary>
    /// Posted when the user presses the left mouse button while the cursor is within the nonclient area of a window.
    /// This message is posted to the window that contains the cursor.
    /// If a window has captured the mouse, this message is not posted.
    /// </summary>
    public const int WM_NCLBUTTONDOWN = 0xA1;
    /// <summary>
    /// In a title bar.
    /// </summary>
    public const int HT_CAPTION = 0x2;

    public struct MARGINS {
        public int m_Left;
        public int m_Right;
        public int m_Top;
        public int m_Bottom;
    };

    public struct POINTAPI {
        public int x;
        public int y;
    };

    public struct DTTOPTS {
        public uint dwSize;
        public uint dwFlags;
        public uint crText;
        public uint crBorder;
        public uint crShadow;
        public int iTextShadowType;
        public POINTAPI ptShadowOffset;
        public int iBorderSize;
        public int iFontPropId;
        public int iColorPropId;
        public int iStateId;
        public int fApplyOverlay;
        public int iGlowSize;
        public IntPtr pfnDrawTextCallback;
        public int lParam;
    };

    public struct RECT {
        public int left;
        public int top;
        public int right;
        public int bottom;
    };

    public struct BITMAPINFOHEADER {
        public int biSize;
        public int biWidth;
        public int biHeight;
        public short biPlanes;
        public short biBitCount;
        public int biCompression;
        public int biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public int biClrUsed;
        public int biClrImportant;
    };

    public struct RGBQUAD {
        public byte rgbBlue;
        public byte rgbGreen;
        public byte rgbRed;
        public byte rgbReserved;
    };

    public struct BITMAPINFO {
        public BITMAPINFOHEADER bmiHeader;
        public RGBQUAD bmiColors;
    };

    [DllImport("dwmapi.dll")]
    public extern static int DwmIsCompositionEnabled(ref bool isEnabled);
    [DllImport("dwmapi.dll", EntryPoint = "DwmEnableComposition")]
    public extern static uint DwmEnableComposition(uint compositionAction);
    [DllImport("dwmapi.dll")]
    public static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margin);
    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern IntPtr GetDC(IntPtr hdc);
    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern int SaveDC(IntPtr hdc);
    [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern int ReleaseDC(IntPtr hdc, int state);
    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
    [DllImport("gdi32.dll", ExactSpelling = true)]
    public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern bool DeleteObject(IntPtr hObject);
    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern bool DeleteDC(IntPtr hdc);
    [DllImport("gdi32.dll")]
    public static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);
    [DllImport("UxTheme.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int DrawThemeTextEx(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string text, int iCharCount, int dwFlags, ref RECT pRect, ref DTTOPTS pOptions);
    [DllImport("UxTheme.dll", ExactSpelling = true, SetLastError = true)]
    public static extern int DrawThemeText(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string text, int iCharCount, int dwFlags1, int dwFlags2, ref RECT pRect);
    [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
    public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO pbmi, uint iUsage, int ppvBits, IntPtr hSection, uint dwOffset);
    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
}

/// <summary>
/// An implementation of DrawThemeTextEx which supports setting color, glow, and other stuff.
/// Too bad I'm only 14 years late. This would have looked so cool on 7.
/// </summary>
public sealed class DwmComposition {

    /// <summary>
    /// Gets whether the composition is supported.
    /// </summary>
    public static bool CompositionSupported {
        get {
            bool CompositionEnabled = false;
            DwmNatives.DwmIsCompositionEnabled(ref CompositionEnabled);
            return Environment.OSVersion.Version.Major >= 6 && CompositionEnabled;
        }
    }

    /// <summary>
    /// Extends the dwm frame into the client area.
    /// </summary>
    /// <param name="hwnd">The handle of the form to extend into.</param>
    /// <param name="margins">The margins it'll refer to when extending.</param>
    public void ExtendFrame(DwmCompositionInfo Info) {
        DwmNatives.DwmExtendFrameIntoClientArea(Info.hWnd, ref Info.Margins);
    }

    /// <summary>
    /// Enables the form movement function. Be sure to check the mouse button, or this will be funky.
    /// </summary>
    /// <param name="hwnd">The handle of the form to move.</param>
    public void MoveForm(DwmCompositionInfo Info) {
        DwmNatives.ReleaseCapture();
        DwmNatives.SendMessage(Info.hWnd, DwmNatives.WM_NCLBUTTONDOWN, DwmNatives.HT_CAPTION, 0);
    }

    /// <summary>
    /// Fills a region with dwm-aware black, used for rendering the desktop window managers' composition onto the form.
    /// </summary>
    /// <param name="gph">The graphics that will be painted with, should be from a forms' paint event.</param>
    /// <param name="rgn">The rectangle where the region should be rendered at.</param>
    public void FillBlackRegion(DwmCompositionInfo Info) {
        IntPtr Memdc = DwmNatives.CreateCompatibleDC(Info.destdc);
        if (!(DwmNatives.SaveDC(Memdc) == 0)) {
            IntPtr bitmap = DwmNatives.CreateDIBSection(Memdc, ref Info.dib, DwmNatives.DIB_RGB_COLORS, 0, IntPtr.Zero, 0);
            if (!(bitmap == IntPtr.Zero)) {
                IntPtr bitmapOld = DwmNatives.SelectObject(Memdc, bitmap);
                try {
                    DwmNatives.BitBlt(Info.destdc, Info.Rect.left, Info.Rect.top, Info.Rect.right - Info.Rect.left, Info.Rect.bottom - Info.Rect.top, Memdc, 0, 0, DwmNatives.SRCCOPY);
                }
                finally {
                    //Remember to clean up
                    DwmNatives.SelectObject(Memdc, bitmapOld);
                    DwmNatives.DeleteObject(bitmap);
                    DwmNatives.ReleaseDC(Memdc, -1);
                    DwmNatives.DeleteDC(Memdc);
                }
            }
        }
        //gph.ReleaseHdc();
    }

    /// <summary>
    /// Draws text onto the DWM composition.
    /// </summary>
    /// <param name="Info">The <see cref="DwmCompositionInfo"/> object that contains information used to render the text.</param>
    public void DrawTextOnGlass(DwmCompositionInfo DwmInfo, DwmCompositionTextInfo Info) {
        IntPtr Memdc = DwmNatives.CreateCompatibleDC(DwmInfo.destdc); // Set up a memory DC where we'll draw the text.
        if (!(DwmNatives.SaveDC(Memdc) == 0)) {
            IntPtr bitmap = DwmNatives.CreateDIBSection(Memdc, ref Info.BitmapInfo, DwmNatives.DIB_RGB_COLORS, 0, IntPtr.Zero, 0); // Create a 32-bit bmp for use in offscreen drawing when glass is on
            if (!(bitmap == IntPtr.Zero)) {
                IntPtr bitmapOld = DwmNatives.SelectObject(Memdc, bitmap);
                IntPtr hFont = Info.Font.ToHfont();
                IntPtr logfnotOld = DwmNatives.SelectObject(Memdc, hFont);
                try {
                    DwmNatives.DrawThemeTextEx(Info.renderer.Handle, Memdc, 0, 0, Info.Text, -1, Info.uFormat, ref Info.Rect2, ref Info.dttOpts);
                    DwmNatives.BitBlt(DwmInfo.destdc, Info.Rect1.left, Info.Rect1.top, Info.Rect1.right - Info.Rect1.left, Info.Rect1.bottom - Info.Rect1.top, Memdc, 0, 0, DwmNatives.SRCCOPY);
                }
                catch {
                    throw;
                }
                finally {
                    DwmNatives.SelectObject(Memdc, bitmapOld);
                    DwmNatives.SelectObject(Memdc, logfnotOld);
                    DwmNatives.DeleteObject(bitmap);
                    DwmNatives.DeleteObject(hFont);
                    DwmNatives.ReleaseDC(Memdc, -1);
                    DwmNatives.DeleteDC(Memdc);
                }

            }
        }
    }

}

/// <summary>
/// A class that contains information about how the dwm will composite on the form
/// </summary>
public sealed class DwmCompositionInfo {

    /// <summary>
    /// The handle that will be written to.
    /// </summary>
    public IntPtr hWnd { get; }

    /// <summary>
    /// The rectangle where the dwm composition will be drawn at.
    /// </summary>
    public Rectangle DwmRectangle;

    /// <summary>
    /// Contains relevant information about the positioning of the frame.
    /// </summary>
    public DwmNatives.MARGINS Margins;

    /// <summary>
    /// Contains the text that will be rendered.
    /// </summary>
    public DwmCompositionTextInfo Text;

    /// <summary>
    /// Device context handle.
    /// </summary>
    public IntPtr destdc;

    /// <summary>
    /// Rect struct to render composition at.
    /// </summary>
    public DwmNatives.RECT Rect;

    /// <summary>
    /// DIB bitmap for the dwm composition.
    /// </summary>
    public DwmNatives.BITMAPINFO dib;

    public DwmCompositionInfo(IntPtr hWnd, DwmNatives.MARGINS Margins, Rectangle DwmRectangle) {
        this.hWnd = hWnd;
        this.Margins = Margins;
        this.DwmRectangle = DwmRectangle;

        GenerateValues();
    }

    public DwmCompositionInfo(IntPtr hWnd, DwmNatives.MARGINS Margins, Rectangle DwmRectangle, DwmCompositionTextInfo NewInfo) {
        this.hWnd = hWnd;
        this.Margins = Margins;
        this.DwmRectangle = DwmRectangle;
        Text = NewInfo;

        GenerateValues();
    }

    /// <summary>
    /// Generates used-values for rendering. Created to save lines when generating dwm info with or without text.
    /// </summary>
    private void GenerateValues() {
        destdc = DwmNatives.GetDC(hWnd);

        Rect = new() {
            top = DwmRectangle.Top,
            bottom = DwmRectangle.Bottom,
            left = DwmRectangle.Left,
            right = DwmRectangle.Right
        };

        dib = new();
        dib.bmiHeader.biHeight = -(Rect.bottom - Rect.top);
        dib.bmiHeader.biWidth = Rect.right - Rect.left;
        dib.bmiHeader.biPlanes = 1;
        dib.bmiHeader.biSize = Marshal.SizeOf(typeof(DwmNatives.BITMAPINFOHEADER));
        dib.bmiHeader.biBitCount = 32;
        dib.bmiHeader.biCompression = DwmNatives.BI_RGB;
    }

}

/// <summary>
/// A class that contains information about the text when rendering in the dwm composition.
/// </summary>
public sealed class DwmCompositionTextInfo {
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