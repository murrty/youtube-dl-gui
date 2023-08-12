namespace youtube_dl_gui;

using System.Windows.Forms;

internal class ExplorerTreeView : TreeView {
    /// <inheritdoc/>
    protected override CreateParams CreateParams {
        get {
            CreateParams param = base.CreateParams;
            param.ExStyle |= 0x10000; // WS_EX_CONTROLPARENT
            param.ExStyle &= 0x200; // WS_EX_CLIENTEDGE
            param.Style &= (~0x800000); // WS_BORDER
            param.Style |= 0x800000;
            return param;
        }
    }

    /// <inheritdoc/>
    protected override void OnHandleCreated(EventArgs e) {
        base.OnHandleCreated(e);
        murrty.controls.natives.NativeMethods.SetWindowTheme(this.Handle, "Explorer", null);
    }
}