namespace youtube_dl_gui.Controls;

using System.ComponentModel;
using System.Windows.Forms;

class ExtendedRichTextBox : RichTextBox {
    private bool fAutoWordSelection = false;

    [Category("Behavior")]
    [DefaultValue(false)]
    [Description("Disables auto-word selection.")]
    public new bool AutoWordSelection {
        get => fAutoWordSelection;
        set {
            fAutoWordSelection = value;
            base.AutoWordSelection = value;
        }
    }

    /// <summary>
    /// Appends text to the rich text box, scrolling to the bottom when necessary.
    /// </summary>
    /// <param name="text">Text to append.</param>
    public new void AppendText(string text) {
        try {
            this.Text += text;
            NativeMethods.SendMessage(this.Handle, 0x115, 7, 0);
        }
        catch { }
    }

    protected override void OnMouseDown(MouseEventArgs e) {
        base.OnMouseDown(e);
        if (!AutoWordSelection) {
            base.AutoWordSelection = true;
            base.AutoWordSelection = false;
        }
    }
}
