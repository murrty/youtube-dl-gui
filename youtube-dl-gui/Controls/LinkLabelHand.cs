using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace murrty.controls {

    /// <summary>
    /// Represents a derived Windows label control that can display hyperlinks, with added functionality.
    /// </summary>
    [ComVisible(true)]
    [DefaultBindingProperty("Text")]
    [DefaultProperty("Text")]
    [ToolboxBitmap(typeof(LinkLabel))]
    [ToolboxItem(true)]
    internal class ExtendedLinkLabel : LinkLabel {

        #region Native Methods

        /// <summary>
        /// The WndProc message for setting the systems' cursor.
        /// </summary>
        private const int WM_SETCURSOR = 0x0020;

        /// <summary>
        /// The user32.h resource identifier for the systems' hand cursor.
        /// </summary>
        private const int IDC_HAND = 32649;

        /// <summary>
        /// The IntPtr value of IDC_HAND.
        /// </summary>
        private static readonly IntPtr SystemHand = LoadCursor(IntPtr.Zero, (IntPtr)IDC_HAND);

        /// <summary>
        /// Loads the specified cursor resource from the executable
        /// </summary>
        /// <param name="hInstance">A handle to an instance of the module whose executable file contains the cursor to be loaded.</param>
        /// <param name="lpCursorName">The name of the cursor resource to be loaded. Alternatively, this parameter can consist of the resource identifier in the low-order word and zero in the high-order word. To use one of the predefined cursors, the application must set the hInstance parameter to NULL and the lpCursorName parameter to a IDC cursor value.</param>
        /// <returns>If the function succeeds, the return value is the handle to the newly loaded cursor; otherwise null.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr LoadCursor(IntPtr hInstance, IntPtr lpCursorName);

        /// <summary>
        /// Sets the cursor shape.
        /// </summary>
        /// <param name="hCursor">A handle to the cursor. The cursor must have been created by the CreateCursor function or loaded by the LoadCursor or LoadImage function. If this parameter is NULL, the cursor is removed from the screen.</param>
        /// <returns>The return value is the handle to the previous cursor, if there was one; otherwise, null.</returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SetCursor(IntPtr hCursor);

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public ExtendedLinkLabel() {
            this.LinkColor = Color.FromArgb(0x00, 0x66, 0xCC);
            this.VisitedLinkColor = Color.FromArgb(0x80, 0x00, 0x80);
            this.ActiveLinkColor = Color.FromArgb(0xFF, 0x00, 0x00);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Processes the specified Windows message, overriding WM_SETCURSOR.
        /// </summary>
        /// <param name="m">The message to process.</param>
        [System.Diagnostics.DebuggerStepThrough]
        protected override void WndProc(ref Message m) {
            switch (m.Msg) {
                case WM_SETCURSOR: {
                    SetCursor(SystemHand);
                    m.Result = IntPtr.Zero;
                }
                break;

                default: {
                    base.WndProc(ref m);
                }
                break;
            }
        }

        #endregion

    }
}
