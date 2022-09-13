namespace murrty.classes;

using System.Runtime.InteropServices;

/// <summary>
/// Contains p/invoke and consts used for rendering dwm and text.
/// </summary>
internal sealed class DwmNatives {
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
