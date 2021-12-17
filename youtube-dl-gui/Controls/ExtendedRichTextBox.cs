using System;
using System.Windows.Forms;

namespace youtube_dl_gui.Controls {
    class ExtendedRichTextBox : RichTextBox {
        public const int WM_VSCROLL = 277;
        public const int SB_PAGEBOTTOM = 7;

        /// <summary>
        /// Appends text to the rich text box, scrolling to the bottom when necessary.
        /// </summary>
        /// <param name="text">Text to append.</param>
        public new void AppendText(string text) {
            this.Text += text;
            NativeMethods.SendMessage(this.Handle, WM_VSCROLL, (IntPtr)SB_PAGEBOTTOM, IntPtr.Zero);
        }
    }
}
