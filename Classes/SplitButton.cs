using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public delegate void DropDownClicked();
    public class SplitButton : Button {

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [System.Diagnostics.DebuggerStepThrough]
        public SplitButton() {
            this.FlatStyle = FlatStyle.System;
            this.DropDown_Clicked += new youtube_dl_gui.DropDownClicked(this.LaunchMenu);
            this.setDropDownContextMenu.Collapse += new EventHandler(this.CloseMenuDropdown);
        }

        protected override CreateParams CreateParams {
            get {
                CreateParams cParams = base.CreateParams;
                cParams.Style |= 0x0000000C;
                return cParams;
            }
        }

        const int BCM_FIRST = 0x1600;
        const int WM_NOTIFY = 0x004E;
        const int BCM_SETDROPDOWNSTATE = 0x1606;

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
            if (Pushed == 0) {
                this.DropDownPushed = 0;
            }
            SendMessage(this.Handle, BCM_FIRST + 0x0006, Pushed, 0);
        }
        public event DropDownClicked DropDown_Clicked;
        private void InitializeComponent() {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }

        public void LaunchMenu() {
            if (setDropDownContextMenu.MenuItems.Count > 0) {
                this.setDropDownContextMenu.Show(this, new Point(this.Width + 190, this.Height), LeftRightAlignment.Left);
            }
            else if (setDropDownContextMenuStrip.Items.Count > 0) {
                this.setDropDownContextMenuStrip.Show(this, this.Width - 25, this.Height);
            }
        }

        public void CloseMenuDropdown(object sender, EventArgs e) {
            this.SetDropDownState(0);
        }

        private ContextMenu setDropDownContextMenu = new ContextMenu();
        public ContextMenu DropDownContextMenu {
            get {
                return setDropDownContextMenu;
            }
            set {
                setDropDownContextMenu = value;
            }
        }
        private ContextMenuStrip setDropDownContextMenuStrip = new ContextMenuStrip();
        public ContextMenuStrip DropDownConextMenuStrip {
            get {
                return setDropDownContextMenuStrip;
            }
            set {
                setDropDownContextMenuStrip = value;
            }
        }

    }
}