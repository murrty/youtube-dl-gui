namespace youtube_dl_gui_updater;
using System.Windows.Forms;
internal class MessageHandler : NativeWindow {
    /// <summary>
    /// Gets the handle to the window.
    /// </summary>
    public new nint Handle => base.Handle;
    /// <summary>
    /// Gets whether the windows handle has been destroyed and the object is considered disposed.
    /// </summary>
    public bool Disposed { get; private set; }
    /// <summary>
    /// Initializes a new <see cref="MessageHandler"/> class.
    /// </summary>
    public MessageHandler() {
        this.CreateHandle(new());
        Disposed = false;
    }
    /// <inheritdoc/>
    [System.Diagnostics.DebuggerStepThrough]
    protected override void WndProc(ref Message m) {
        switch (m.Msg) {
            case CopyData.WM_COPYDATA: {
                Program.UpdateData = CopyData.GetParam<UpdaterData>(m.LParam);
                Program.UpdateData.UpdateHash = Program.UpdateData.UpdateHash.ToLowerInvariant();
                if (!Program.UpdateData.FileName.ToLowerInvariant().EndsWith(".exe"))
                    Program.UpdateData.FileName += ".exe";
                Program.MainForm.StartUpdate();
            } break;

            default: {
                base.WndProc(ref m);
            } break;
        }
    }
    /// <summary>
    /// Destroys the windows handle.
    /// </summary>
    public void Dispose() {
        if (!Disposed) {
            this.DestroyHandle();
            Disposed = true;
        }
    }
}