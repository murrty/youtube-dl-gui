namespace murrty.controls;

using System.ComponentModel;
using System.Windows.Forms;
using murrty.controls.natives;

using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms.Layout;
using Microsoft.Win32;

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
    /// Gets or sets whether the rich text box will only display text and now allow the user to select or highlight messages.
    /// <para>Setting BorderStyle to FixedNone is a good idea.</para>
    /// </summary>
    [Category("Behavior")]
    [DefaultValue(false)]
    [Description("If the control should ignore any inputs from the user.")]
    public bool ViewOnly {
        get; set;
    } = false;

    private const int WM_SETFOCUS = 0x07;
    private const int WM_ENABLE = 0x0A;
    private const int WM_SETCURSOR = 0x20;

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

    protected override void WndProc(ref Message m) {
        switch (m.Msg) {
            case WM_SETFOCUS when ViewOnly:
            case WM_ENABLE when ViewOnly:
            case WM_SETCURSOR when ViewOnly: {
                m.Result = IntPtr.Zero;
            } return;

            case WM_SETCURSOR: {
                if (Cursor == Cursors.Hand) {
                    NativeMethods.SetCursor(Consts.SystemHand);
                    m.Result = IntPtr.Zero;
                    return;
                }
            } break;
        }
        base.WndProc(ref m);
    }
}