using System;
using System.Drawing;
using System.Windows.Forms;

namespace youtube_dl_gui.Controls {
    public delegate void DropDownClicked();
    [System.Diagnostics.DebuggerStepThrough]
    public class SplitButton : Button {

        private const int BS_SPLITBUTTON = 0x0000000C;

        public SplitButton() {
            SuspendLayout();
            ResumeLayout(false);

            FlatStyle = FlatStyle.System;
            DropDown_Clicked += new DropDownClicked(LaunchMenu);
            _ContextMenu.Collapse += new EventHandler(CloseMenuDropdown);
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams cParams = base.CreateParams;
                cParams.Style |= BS_SPLITBUTTON;
                return cParams;
            }
        }

        public int IsBumped = 0;
        public int IsMouseDown = 0;
        public int IsAtDropDown = 0;
        public int DropDownPushed = 0;
        protected override void WndProc(ref Message WndMessage) {
            switch (WndMessage.Msg) {
                case (0x00001600 + 0x0006):
                    if (WndMessage.HWnd == Handle) {
                        if (WndMessage.WParam == (IntPtr)1) {
                            if (DropDownPushed == 0) {
                                DropDownPushed = 1;
                                DropDown_Clicked();
                            }
                        }
                        if (IsMouseDown == 1) {
                            IsAtDropDown = 1;
                        }
                    }
                    break;
                case (0x0F):
                    if (DropDownPushed == 1) {
                        SetDropDownState(1);
                    }
                    break;
                case (0x201):
                    IsMouseDown = 1;
                    break;
                case (0x2A3):
                    if (IsAtDropDown == 1) {
                        SetDropDownState(0);
                        IsAtDropDown = 0;
                        IsMouseDown = 0;
                    }
                    break;
                case (0x202):
                    if (IsAtDropDown == 1) {
                        SetDropDownState(0);
                        IsAtDropDown = 0;
                        IsMouseDown = 0;
                    }
                    break;
                case (0x08):
                    if (IsAtDropDown == 1) {
                        SetDropDownState(0);
                        IsAtDropDown = 0;
                        IsMouseDown = 0;
                    }
                    break;
            }
            base.WndProc(ref WndMessage);
        }
        public void SetDropDownState(int Pushed) {
            switch (Pushed) {
                case 0:
                    DropDownPushed = 0;
                    break;
            }
            NativeMethods.SendMessage(Handle, (0x1606 + 0x0006), Pushed, 0);
        }
        public event DropDownClicked DropDown_Clicked;

        public void LaunchMenu() {
            if (_ContextMenu.MenuItems.Count > 0) {
                //_ContextMenu.Show(this, new Point(Width + 190, Height), LeftRightAlignment.Left);
                _ContextMenu.Show(this, new Point(Width, Height), LeftRightAlignment.Left);
            }
        }

        public void CloseMenuDropdown(object sender, EventArgs e) {
            SetDropDownState(0);
        }
        ContextMenu _ContextMenu = new();
        public ContextMenu DropDownContextMenu {
            get { return _ContextMenu; }
            set { _ContextMenu = value; }
        }
    }
}
