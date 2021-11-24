using System;
using System.Windows.Forms;

namespace youtube_dl_gui.Controls {
    class LinkLabelHand : LinkLabel {
        [System.Diagnostics.DebuggerStepThrough]
        protected override void WndProc(ref Message m) {
            switch (m.Msg) {
                case 0x0020:
                    NativeMethods.SetCursor(NativeMethods.LoadCursor(IntPtr.Zero, NativeMethods.HAND));
                    m.Result = IntPtr.Zero;
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
    }
}
