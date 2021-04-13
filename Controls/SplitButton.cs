using System;
using System.Drawing;
using System.Windows.Forms;

namespace youtube_dl_gui.Controls {
    public delegate void DropDownClicked();
    [System.Diagnostics.DebuggerStepThrough]
    public class SplitButton : Button {


        public SplitButton() {
            this.FlatStyle = FlatStyle.System;
            this.DropDown_Clicked += new DropDownClicked(this.LaunchMenu);
            this._ContextMenu.Collapse += new EventHandler(this.CloseMenuDropdown);
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams cParams = base.CreateParams;
                cParams.Style |= 0x0000000C;
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
                    if (WndMessage.HWnd == this.Handle) {
                        if (WndMessage.WParam.ToString() == "1") {
                            if (DropDownPushed == 0) {
                                this.DropDownPushed = 1;
                                DropDown_Clicked();
                            }
                        }
                        if (this.IsMouseDown == 1) {
                            this.IsAtDropDown = 1;
                        }
                    }
                    break;
                case (0x0F):
                    if (this.DropDownPushed == 1) {
                        this.SetDropDownState(1);
                    }
                    break;
                case (0x201):
                    this.IsMouseDown = 1;
                    break;
                case (0x2A3):
                    if (this.IsAtDropDown == 1) {
                        this.SetDropDownState(0);
                        this.IsAtDropDown = 0;
                        this.IsMouseDown = 0;
                    }
                    break;
                case (0x202):
                    if (this.IsAtDropDown == 1) {
                        this.SetDropDownState(0);
                        this.IsAtDropDown = 0;
                        this.IsMouseDown = 0;
                    }
                    break;
                case (0x08):
                    if (this.IsAtDropDown == 1) {
                        this.SetDropDownState(0);
                        this.IsAtDropDown = 0;
                        this.IsMouseDown = 0;
                    }
                    break;
            }
            base.WndProc(ref WndMessage);
        }
        public void SetDropDownState(int Pushed) {
            switch (Pushed) {
                case 0:
                    this.DropDownPushed = 0;
                    break;
            }
            NativeMethods.SendMessage(this.Handle, (0x1606 + 0x0006), (IntPtr)Pushed, IntPtr.Zero);
        }
        public event DropDownClicked DropDown_Clicked;
        private void InitializeComponent() {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        public void LaunchMenu() {
            if (this._ContextMenu.MenuItems.Count > 0) {
                this._ContextMenu.Show(this, new Point(this.Width + 190, this.Height), LeftRightAlignment.Left);
            }
        }

        public void CloseMenuDropdown(object sender, EventArgs e) {
            this.SetDropDownState(0);
        }
        ContextMenu _ContextMenu = new ContextMenu();
        public ContextMenu DropDownContextMenu {
            get { return this._ContextMenu; }
            set { this._ContextMenu = value; }
        }
    }
}
