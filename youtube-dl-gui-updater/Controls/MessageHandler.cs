namespace youtube_dl_gui_updater;

using System.Windows.Forms;

internal class MessageHandler : NativeWindow {

    public new nint Handle => base.Handle;

    public MessageHandler() {
        this.CreateHandle(new());
    }

    [System.Diagnostics.DebuggerStepThrough]
    protected override void WndProc(ref Message m) {
        switch (m.Msg) {
            case CopyData.WM_COPYDATA: {
                Program.UpdateData = CopyData.GetParam<UpdaterData>(m.LParam);
                Program.MainForm.StartUpdate();
            } break;

            default: {
                base.WndProc(ref m);
            } break;
        }
    }

    public void Dispose() {
        this.DestroyHandle();
    }

}