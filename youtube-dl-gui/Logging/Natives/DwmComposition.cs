namespace murrty.classes;

/// <summary>
/// An implementation of DrawThemeTextEx which supports setting color, glow, and other stuff.
/// Too bad I'm only 14 years late. This would have looked so cool on 7.
/// </summary>
internal sealed class DwmComposition {

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