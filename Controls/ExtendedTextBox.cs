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

        private Button btn = new Button() {
            Cursor = Cursors.Default,
            Enabled = false,
            TextAlign = ContentAlignment.MiddleCenter,
            UseVisualStyleBackColor = true,
            Visible = false,
        };

        public ExtendedTextBox() {
            UpdateButton();
            this.Controls.Add(btn);
            this.Refresh();
        }

        #region Private variables
        private ButtonAlignments _ButtonAlignment = ButtonAlignments.Left;
        private string _TextHint = string.Empty;
        private AllowedTextTypes _TextType = AllowedTextTypes.All;
        private bool _ButtonEnabled = false;
        #endregion

        #region Methods
        private void UpdateButton() {
            btn.Size = new Size(22, this.ClientSize.Height + 3);
            switch (_ButtonAlignment) {
                default:
                    btn.Location = new Point(this.ClientSize.Width - btn.Width, -2);
                    break;

                case ButtonAlignments.Right:
                    btn.Location = new Point(0, -2);
                    break;
            }
        }
        #endregion

        #region Overrides
        /// <summary>
        /// Refreshes the TextBox and realigns the Text to fit with the Button.
        /// </summary>
        public override void Refresh() {
            switch (_ButtonEnabled) {
                case true:
                    switch (_ButtonAlignment) {
                        default:
                            NativeMethods.SendMessage(this.Handle, NativeMethods.EM_SETMARGINS, (IntPtr)NativeMethods.EC_RIGHTMARGIN, (IntPtr)(btn.Width << 16));
                            break;

                        case ButtonAlignments.Right:
                            NativeMethods.SendMessage(this.Handle, NativeMethods.EM_SETMARGINS, (IntPtr)NativeMethods.EC_LEFTMARGIN, (IntPtr)(btn.Width));
                            break;
                    }
                    break;

                case false:
                    NativeMethods.SendMessage(this.Handle, NativeMethods.EM_SETMARGINS, (IntPtr)NativeMethods.EC_LEFTMARGIN, IntPtr.Zero);
                    NativeMethods.SendMessage(this.Handle, NativeMethods.EM_SETMARGINS, (IntPtr)NativeMethods.EC_RIGHTMARGIN, IntPtr.Zero);
                    break;
            }
            base.Refresh();
        }

        protected override void OnResize(EventArgs e) {
            UpdateButton();
            this.Refresh();
            base.OnResize(e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e) {

            switch (_TextType) {
                case AllowedTextTypes.AlphabeticalOnly:
                    switch (e.KeyChar) {
                        case (char)Keys.Back: case (char)Keys.Space:
                        case (char)Keys.Return:
                        case 'a': case 'A': case 'b': case 'B': case 'c': case 'C':
                        case 'd': case 'D': case 'e': case 'E': case 'f': case 'F':
                        case 'g': case 'G': case 'h': case 'H': case 'i': case 'I':
                        case 'j': case 'J': case 'k': case 'K': case 'l': case 'L':
                        case 'm': case 'M': case 'o': case 'O': case 'p': case 'P':
                        case 'q': case 'Q': case 'r': case 'R': case 's': case 'S':
                        case 't': case 'T': case 'u': case 'U': case 'v': case 'V':
                        case 'w': case 'W': case 'x': case 'X': case 'y': case 'Y':
                        case 'z': case 'Z':
                            e.Handled = false;
                            break;

                        default:
                            e.Handled = true;
                            break;
                    }
                    break;

                case AllowedTextTypes.NumericOnly:
                    switch (e.KeyChar) {
                        case (char)Keys.Back: case (char)Keys.Space:
                        case (char)Keys.Return:
                        case '.': case '0':
                        case '1': case '2': case '3':
                        case '4': case '5': case '6':
                        case '7': case '8': case '9':
                            e.Handled = false;
                            break;

                        default:
                            e.Handled = true;
                            break;
                    }
                    break;

                case AllowedTextTypes.AlphaNumericOnly:
                    switch (e.KeyChar) {
                        case (char)Keys.Back: case (char)Keys.Space:
                        case (char)Keys.Return:
                        case '.': case '0':
                        case '1': case '2': case '3':
                        case '4': case '5': case '6':
                        case '7': case '8': case '9':
                        case 'a': case 'A': case 'b': case 'B': case 'c': case 'C':
                        case 'd': case 'D': case 'e': case 'E': case 'f': case 'F':
                        case 'g': case 'G': case 'h': case 'H': case 'i': case 'I':
                        case 'j': case 'J': case 'k': case 'K': case 'l': case 'L':
                        case 'm': case 'M': case 'o': case 'O': case 'p': case 'P':
                        case 'q': case 'Q': case 'r': case 'R': case 's': case 'S':
                        case 't': case 'T': case 'u': case 'U': case 'v': case 'V':
                        case 'w': case 'W': case 'x': case 'X': case 'y': case 'Y':
                        case 'z': case 'Z':
                            e.Handled = false;
                            break;

                        default:
                            e.Handled = true;
                            break;
                    }
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
                            this.SelectAll();
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
            get { return _ButtonAlignment; }
            set { _ButtonAlignment = value; UpdateButton(); this.Refresh(); }
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
            get { return _ButtonEnabled; }
            set {
                btn.Visible = value;
                btn.Enabled = value;
                _ButtonEnabled = value;
            }
        }

        [Category("Appearance"), Description("The Text that will appear as a hint in the Text Box."), DefaultValue(null)]
        public string TextHint {
            get { return _TextHint; }
            set {
                _TextHint = value;
                NativeMethods.SendMessage(this.Handle, 0x1501, (IntPtr)1, value);
            }
        }

        [Category("Appearance"), Description("Determines if the Text Box wil only accept certain kinds of characters."), DefaultValue(AllowedTextTypes.All)]
        public AllowedTextTypes TextType {
            get { return _TextType; }
            set { _TextType = value; }
        }
        #endregion

    }
}