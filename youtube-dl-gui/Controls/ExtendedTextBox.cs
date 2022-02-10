using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace youtube_dl_gui.Controls {

    public enum AllowedTextTypes {
        All,
        AlphabeticalOnly,
        NumericOnly,
        AlphaNumericOnly
    }

    public enum ButtonAlignments {
        Left,
        Right
    }

    /// <summary>
    /// An extension of Windows.Forms.TextBox to include extra functionality.
    /// </summary>
    public class ExtendedTextBox : TextBox {

        private readonly Button btn = new() {
            Cursor = Cursors.Default,
            Enabled = false,
            TextAlign = ContentAlignment.MiddleCenter,
            UseVisualStyleBackColor = true,
            Visible = false,
        };

        public ExtendedTextBox() {
            UpdateButton();
            Controls.Add(btn);
            Refresh();
        }

        #region Private variables
        private ButtonAlignments fButtonAlignment = ButtonAlignments.Left;
        private string fTextHint = string.Empty;
        private AllowedTextTypes fTextType = AllowedTextTypes.All;
        private bool fButtonEnabled = false;
        #endregion

        #region Methods
        private void UpdateButton() {
            btn.Size = new(22, ClientSize.Height + 3);
            btn.Location = fButtonAlignment switch {
                ButtonAlignments.Right => new(0, -2),
                _ => new(ClientSize.Width - btn.Width, -2),
            };
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Refreshes the TextBox and realigns the Text to fit with the Button.
        /// </summary>
        public override void Refresh() {
            switch (fButtonEnabled) {
                case true:
                    switch (fButtonAlignment) {
                        default:
                            NativeMethods.SendMessage(Handle, NativeMethods.EM_SETMARGINS, (IntPtr)NativeMethods.EC_RIGHTMARGIN, (IntPtr)(btn.Width << 16));
                            break;

                        case ButtonAlignments.Right:
                            NativeMethods.SendMessage(Handle, NativeMethods.EM_SETMARGINS, (IntPtr)NativeMethods.EC_LEFTMARGIN, (IntPtr)(btn.Width));
                            break;
                    }
                    break;

                case false:
                    NativeMethods.SendMessage(Handle, NativeMethods.EM_SETMARGINS, (IntPtr)NativeMethods.EC_LEFTMARGIN, IntPtr.Zero);
                    NativeMethods.SendMessage(Handle, NativeMethods.EM_SETMARGINS, (IntPtr)NativeMethods.EC_RIGHTMARGIN, IntPtr.Zero);
                    break;
            }
            base.Refresh();
        }

        protected override void OnResize(EventArgs e) {
            UpdateButton();
            Refresh();
            base.OnResize(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e) {

            switch (fTextType) {
                case AllowedTextTypes.AlphabeticalOnly:
                    e.Handled = e.KeyChar switch {
                        (char)Keys.Back or (char)Keys.Space or (char)Keys.Return or 'a' or 'A' or 'b' or 'B' or 'c' or 'C' or 'd' or 'D' or 'e' or 'E' or 'f' or 'F' or 'g' or 'G' or 'h' or 'H' or 'i' or 'I' or 'j' or 'J' or 'k' or 'K' or 'l' or 'L' or 'm' or 'M' or 'o' or 'O' or 'p' or 'P' or 'q' or 'Q' or 'r' or 'R' or 's' or 'S' or 't' or 'T' or 'u' or 'U' or 'v' or 'V' or 'w' or 'W' or 'x' or 'X' or 'y' or 'Y' or 'z' or 'Z' => false,
                        _ => true,
                    };
                    break;

                case AllowedTextTypes.NumericOnly:
                    e.Handled = e.KeyChar switch {
                        (char)Keys.Back or (char)Keys.Space or (char)Keys.Return or '.' or '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9' => false,
                        _ => true,
                    };
                    break;

                case AllowedTextTypes.AlphaNumericOnly:
                    e.Handled = e.KeyChar switch {
                        (char)Keys.Back or (char)Keys.Space or (char)Keys.Return or '.' or '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8' or '9' or 'a' or 'A' or 'b' or 'B' or 'c' or 'C' or 'd' or 'D' or 'e' or 'E' or 'f' or 'F' or 'g' or 'G' or 'h' or 'H' or 'i' or 'I' or 'j' or 'J' or 'k' or 'K' or 'l' or 'L' or 'm' or 'M' or 'o' or 'O' or 'p' or 'P' or 'q' or 'Q' or 'r' or 'R' or 's' or 'S' or 't' or 'T' or 'u' or 'U' or 'v' or 'V' or 'w' or 'W' or 'x' or 'X' or 'y' or 'Y' or 'z' or 'Z' => false,
                        _ => true,
                    };
                    break;
            }

            base.OnKeyPress(e);
        }

        protected override void OnKeyDown(KeyEventArgs e) {
            switch (e.Modifiers == Keys.Control) {
                case true:
                    switch (e.KeyCode) {
                        //case Keys.V:
                        //    switch (Clipboard.ContainsText()) {
                        //        case true:
                        //            e.SuppressKeyPress = true;
                        //            this.Text = Clipboard.GetText();
                        //            break;
                        //    }
                        //    break;

                        case Keys.A:
                            e.SuppressKeyPress = true;
                            SelectAll();
                            break;
                    }
                    break;
            }
            base.OnKeyDown(e);
        }
        #endregion

        #region Events
        /// <summary>
        /// Event raised when the Button in the TextBox is clicked.
        /// </summary>
        public event EventHandler ButtonClick {
            add { btn.Click += value; }
            remove { btn.Click -= value; }
        }
        #endregion

        #region Public Properties
        [Category("Appearance"), Description("The position of the button inside the Text Box."), DefaultValue(ButtonAlignments.Right)]
        public ButtonAlignments ButtonAlignment {
            get { return fButtonAlignment; }
            set { fButtonAlignment = value; UpdateButton(); this.Refresh(); }
        }

        [Category("Appearance"), Description("The cursor that will appear when hovering over the Button.")]
        public Cursor ButtonCursor {
            get { return btn.Cursor; }
            set { btn.Cursor = value; }
        }

        [Category("Appearance"), Description("The Font of the Text that appears within the Button.")]
        public Font ButtonFont {
            get { return btn.Font; }
            set { btn.Font = value; }
        }

        [Category("Appearance"), Description("The Image that appears on the Button."), DefaultValue(null)]
        public Image ButtonImage {
            get { return btn.Image; }
            set { btn.Image = value; }
        }

        [Category("Appearance"), Description("The Image Alignment of an Image on the Button."), DefaultValue(ContentAlignment.MiddleCenter)]
        public ContentAlignment ButtonImageAlign {
            get { return btn.ImageAlign; }
            set { btn.ImageAlign = value; }
        }

        [Category("Appearance"), Description("The Image Index of the Image on the Button within the Image List."), DefaultValue(null)]
        public int ButtonImageIndex {
            get { return btn.ImageIndex; }
            set { btn.ImageIndex = value; }
        }

        [Category("Appearance"), Description("The Image Key of the Image on the Button."), DefaultValue(null)]
        public string ButtonImageKey {
            get { return btn.ImageKey; }
            set { btn.ImageKey = value; }
        }

        [Category("Appearance"), Description("The Image List for use with the Button."), DefaultValue(null)]
        public ImageList ButtonImageList {
            get { return btn.ImageList; }
            set { btn.ImageList = value; }
        }

        [Category("Appearance"), Description("The Size of the Button.")]
        public Size ButtonSize {
            get { return btn.Size; }
            set { btn.Size = value; }
        }

        [Category("Appearance"), Description("The Text that appears on the Button.")]
        public string ButtonText {
            get { return btn.Text; }
            set { btn.Text = value; }
        }

        [Category("Appearance"), Description("The Alignment of the Text on the Button."), DefaultValue(ContentAlignment.MiddleRight)]
        public ContentAlignment ButtonTextAlign {
            get { return btn.TextAlign; }
            set { btn.TextAlign = value; }
        }

        [Category("Appearance"), Description("The Button on the Text Box is enabled and usable."), DefaultValue(false)]
        public bool ButtonEnabled {
            get { return fButtonEnabled; }
            set {
                btn.Visible = value;
                btn.Enabled = value;
                fButtonEnabled = value;
            }
        }

        [Category("Appearance"), Description("The Text that will appear as a hint in the Text Box."), DefaultValue(null)]
        public string TextHint {
            get { return fTextHint; }
            set {
                fTextHint = value;
                NativeMethods.SendMessage(this.Handle, 0x1501, (IntPtr)1, value);
            }
        }

        [Category("Appearance"), Description("Determines if the Text Box wil only accept certain kinds of characters."), DefaultValue(AllowedTextTypes.All)]
        public AllowedTextTypes TextType {
            get { return fTextType; }
            set { fTextType = value; }
        }
        #endregion

    }
}