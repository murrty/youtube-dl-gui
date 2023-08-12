namespace youtube_dl_gui;

using System;

public abstract class LocalizedProcessingForm : LocalizedForm {
    public LocalizedProcessingForm() {
        Program.AddProcessingForm(this);
    }

    protected override void OnClosed(EventArgs e) {
        base.OnClosed(e);
        Program.RemoveProcessingForm(this);
    }
}