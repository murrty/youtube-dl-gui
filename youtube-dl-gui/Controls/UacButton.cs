#nullable enable
using System.ComponentModel;
using System.Windows.Forms;
namespace murrty.controls;
internal class UacButton : Button {
    // Quick button replacement for the UAC icon. Not a replacement to the ExtendedButton.
    [DefaultValue(true)]
    public bool ShowUacShield {
        get => bShowUacShield;
        set {
            if (value != bShowUacShield) {
                bShowUacShield = value;
                this.RecreateHandle();
            }
        }
    }
    private bool bShowUacShield = true;
    internal const int BCM_SETSHIELD = 0x160C;
    public UacButton() {
        this.FlatStyle = FlatStyle.System;
    }
    protected override void OnHandleCreated(EventArgs e) {
        base.OnHandleCreated(e);
        if (ShowUacShield) {
            natives.NativeMethods.SendMessage(this.Handle, BCM_SETSHIELD, 0, 2);
        }
    }
}