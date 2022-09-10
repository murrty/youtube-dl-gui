namespace murrty.controls;

using System.ComponentModel;
using System.Windows.Forms;
using murrty.controls.natives;

internal sealed class SplitButton : Button {

    private const int WM_PAINT = 0x0F;
    private const int WM_KILLFOCUS = 0x08;
    private const int WM_LBUTTONDOWN = 0x201;
    private const int WM_LBUTTONUP = 0x202;
    private const int WM_MOUSELEAVE = 0x2A3;
    private const int BCM_SETDROPDOWNSTATE = 0x1606;

    private const nint SplitButtonPressed = 1;
    private const nint SplitButtonReleased = 0;

    private bool IsMouseDown = false;
    private bool IsAtDropDown = false;
    private bool DropDownPushed = false;
    private bool Painting = false;

    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [DefaultValue(null)]
    public new ContextMenu ContextMenu {
        get => base.ContextMenu;
        set {
            if (value != base.ContextMenu && base.ContextMenu is not null) {
                base.ContextMenu.Collapse -= CloseMenu;
            }
            base.ContextMenu = value;
            if (base.ContextMenu is not null) {
                base.ContextMenu.Collapse += CloseMenu;
            }
        }
    }

    [DefaultValue(null)]
    public new ContextMenuStrip ContextMenuStrip {
        get => base.ContextMenuStrip;
        set {
            if (value != base.ContextMenuStrip && base.ContextMenuStrip is not null) {
                base.ContextMenuStrip.Closed -= CloseMenu;
            }
            base.ContextMenuStrip = value;
            if (base.ContextMenuStrip is not null) {
                base.ContextMenuStrip.Closed += CloseMenu;
            }
        }
    }

    public event EventHandler<EventArgs> MenuOpening;
    public event EventHandler<EventArgs> MenuClosing;

    public SplitButton() {
        base.FlatStyle = FlatStyle.System;
    }

    protected override CreateParams CreateParams {
        get {
            CreateParams val = base.CreateParams;
            val.Style |= 0x0C;
            return val;
        }
    }

    protected override void WndProc(ref Message m) {
        switch (m.Msg) {
            case WM_PAINT when DropDownPushed: {
                Painting = true;
                SetDropDown(true);
                Painting = false;
            } break;

            case WM_LBUTTONDOWN: {
                IsMouseDown = true;
            } break;

            case WM_KILLFOCUS when IsAtDropDown:
            case WM_LBUTTONUP when IsAtDropDown:
            case WM_MOUSELEAVE when IsAtDropDown: {
                IsAtDropDown = false;
                IsMouseDown = false;
                SetDropDown(false);
            } break;

            case BCM_SETDROPDOWNSTATE when !Painting && m.HWnd == this.Handle: {
                switch (m.WParam) {
                    case SplitButtonPressed when !DropDownPushed: {
                        DropDownPushed = true;
                        ShowMenu();
                    } break;

                    case SplitButtonReleased when DropDownPushed: {
                        DropDownPushed = false;
                    } break;
                }
                if (IsMouseDown) {
                    IsAtDropDown = true;
                }
            } break;
        }
        base.WndProc(ref m);
    }

    protected override void OnMouseEnter(EventArgs e) {
        base.OnMouseEnter(e);
        IsMouseDown = IsAtDropDown = DropDownPushed = false;
    }

    private void SetDropDown(bool IsPushed) {
        NativeMethods.SendMessage(
            Handle,
            BCM_SETDROPDOWNSTATE,
            IsPushed ? SplitButtonPressed : SplitButtonReleased,
            0);
    }

    private void ShowMenu() {
        Painting = true;
        if (ContextMenu is not null) {
            MenuOpening?.Invoke(this, EventArgs.Empty);
            ContextMenu.Show(this, new(Width, Height), LeftRightAlignment.Left);
        }
        else if (ContextMenuStrip is not null) {
            MenuOpening?.Invoke(this, EventArgs.Empty);
            ContextMenuStrip.Show(this, new(Width, Height));
        }
        Painting = false;
    }

    public void ShowDropDownMenu() {
        if (ContextMenu is not null) {
            MenuOpening?.Invoke(this, EventArgs.Empty);
            ContextMenu.Show(this, new(Width, Height), LeftRightAlignment.Left);
        }
        else if (ContextMenuStrip is not null) {
            MenuOpening?.Invoke(this, EventArgs.Empty);
            ContextMenuStrip.Show(this, new(Width, Height));
        }
    }

    private void CloseMenu(object sender, EventArgs e) {
        MenuClosing?.Invoke(this, EventArgs.Empty);
        SetDropDown(false);
}

}