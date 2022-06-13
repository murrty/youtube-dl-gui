using System;
using System.Windows.Forms;

namespace youtube_dl_gui.Controls {
    class ExtendedRichTextBox : RichTextBox {

        /// <summary>
        /// Appends text to the rich text box, scrolling to the bottom when necessary.
        /// </summary>
        /// <param name="text">Text to append.</param>
        public new void AppendText(string text) {
            try {
                this.Text += text;
                NativeMethods.SendMessage(this.Handle, 0x115, (IntPtr)7, IntPtr.Zero);
            }
            catch { }
        }
    }
}
