namespace murrty.controls;

using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using murrty.controls.natives;

/// <summary>
/// An extension of Windows.Forms.TextBox to include extra functionality.
/// </summary>
[System.Diagnostics.DebuggerStepThrough]
public class ExtendedTextBox : TextBox {

    #region Fields
    /// <summary>
    /// The text hint.
    /// </summary>
    private string fTextHint = string.Empty;
    /// <summary>
    /// What kind of text is allowed.
    /// </summary>
    private AllowedCharacters fTextType = AllowedCharacters.All;
    /// <summary>
    /// If the button is shown in the textbox.
    /// </summary>
    private bool fShowButton = false;
    /// <summary>
    /// The alignment of the button.
    /// </summary>
    private ButtonAlignment fButtonAlignment = ButtonAlignment.Left;
    /// <summary>
    /// If the font should be syncronized across the button and text.
    /// </summary>
    private bool fSyncFont = false;
    /// <summary>
    /// The allowed <see cref="char"/> values in filters.
    /// </summary>
    private char[] fUnfilteredCharacters = null;
    /// <summary>
    /// Whether the space key is allowed.
    /// </summary>
    private bool fAllowSpace = true;
    /// <summary>
    /// The regular expression patterns array.
    /// </summary>
    private string[] fRegexPatterns = null;

    /// <summary>
    /// The button that appears inside the textbox.
    /// </summary>
    private readonly Button InsetButton = new() {
        Cursor = Cursors.Default,
        Enabled = false,
        TextAlign = ContentAlignment.MiddleCenter,
        UseVisualStyleBackColor = true,
        Visible = false,
    };
    /// <summary>
    /// Whether the KeyDown event has a SUSSY BAKA key that needs to be checked in the Unfiltered Characters array.
    /// </summary>
    private bool fCheckChar = false;
    /// <summary>
    /// Whether the regex matched.
    /// </summary>
    private bool fRegexMatched = false;
    /// <summary>
    /// Whether the button is enabled.
    /// </summary>
    private bool fButtonEnabled = true;
    /// <summary>
    /// Whether the button is visible.
    /// </summary>
    private bool fButtonVisible = true;
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets whether the Space key is an allowed key when filtered.
    /// </summary>
    [Category("Behavior")]
    [DefaultValue(true)]
    [Description("Whether the Space key will be allowed. The unfiltered characters list takes precedent over this value, if this value is false.")]
    public bool AllowSpace {
        get => fAllowSpace;
        set => fAllowSpace = value;
    }

    /// <summary>
    /// Gets or sets the ButtonAlignment of the button.
    /// </summary>
    [Category("Appearance")]
    [DefaultValue(ButtonAlignment.Right)]
    [Description("The position of the button inside the Text Box.")]
    public ButtonAlignment ButtonAlignment {
        get => fButtonAlignment;
        set {
            fButtonAlignment = value;
            this.Refresh();
        }
    }
    
    /// <summary>
    /// Gets or sets the cursor of the button.
    /// </summary>
    [Category("Appearance")]
    [Description("The cursor that will appear when hovering over the Button.")]
    public Cursor ButtonCursor {
        get => InsetButton.Cursor;
        set => InsetButton.Cursor = value;
    }

    /// <summary>
    /// Gets or sets whether the button is enabled.
    /// </summary>
    [Category("Behavior")]
    [DefaultValue(true)]
    [Description("The Button on the TextBox is enabled.")]
    public bool ButtonEnabled {
        get => fButtonEnabled;
        set {
            fButtonEnabled = value;
            if (fShowButton) {
                InsetButton.Enabled = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the text font of the button.
    /// </summary>
    [Category("Appearance")]
    [Description("The Font of the text that appears within the Button.")]
    public Font ButtonFont {
        get => InsetButton.Font;
        set {
            InsetButton.Font = value;
            if (fSyncFont) {
                base.Font = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the image in the button.
    /// </summary>
    [Category("Appearance")]
    [DefaultValue(null)]
    [Description("The Image that appears on the Button.")]
    public Image ButtonImage {
        get => InsetButton.Image;
        set => InsetButton.Image = value;
    }

    /// <summary>
    /// Gets or sets the image alignment of the buttons' image.
    /// </summary>
    [Category("Appearance")]
    [DefaultValue(ContentAlignment.MiddleCenter)]
    [Description("The Image Alignment of an Image on the Button.")]
    public ContentAlignment ButtonImageAlign {
        get => InsetButton.ImageAlign;
        set => InsetButton.ImageAlign = value;
    }

    /// <summary>
    /// Gets or sets the image index of the buttons' image key or image list.
    /// </summary>
    [Category("Appearance")]
    [Description("The Image Index of the Image on the Button within the Image List.")]
    public int ButtonImageIndex {
        get => InsetButton.ImageIndex;
        set => InsetButton.ImageIndex = value;
    }

    /// <summary>
    /// Gets or sets the buttons' image key.
    /// </summary>
    [Category("Appearance")]
    [DefaultValue("")]
    [Description("The Image Key of the Image on the Button.")]
    public string ButtonImageKey {
        get => InsetButton.ImageKey;
        set => InsetButton.ImageKey = value;
    }

    /// <summary>
    /// Gets or sets the buttons' image list.
    /// </summary>
    [Category("Appearance")]
    [DefaultValue(null)]
    [Description("The Image List for use with the Button.")]
    public ImageList ButtonImageList {
        get => InsetButton.ImageList;
        set => InsetButton.ImageList = value;
    }

    /// <summary>
    /// Gets or sets the size of the button.
    /// </summary>
    [Category("Appearance")]
    [Description("The Size of the Button.")]
    public Size ButtonSize {
        get => InsetButton.Size;
        set {
            InsetButton.Size = value;
            this.Refresh();
        }
    }

    /// <summary>
    /// Gets or sets the text of the button.
    /// </summary>
    [Category("Appearance")]
    [Description("The text that appears on the Button.")]
    public string ButtonText {
        get => InsetButton.Text;
        set => InsetButton.Text = value;
    }

    /// <summary>
    /// Gets or sets the text alignment of the buttons' text.
    /// </summary>
    [Category("Appearance")]
    [DefaultValue(ContentAlignment.MiddleRight)]
    [Description("The Alignment of the text on the Button.")]
    public ContentAlignment ButtonTextAlign {
        get => InsetButton.TextAlign;
        set => InsetButton.TextAlign = value;
    }

    /// <summary>
    /// Gets or sets whether the button is visible.
    /// </summary>
    [Category("Behavior")]
    [DefaultValue(true)]
    [Description("The Button on the TextBox is visible.")]
    public bool ButtonVisible {
        get => fButtonVisible;
        set {
            fButtonVisible = value;
            if (fShowButton) {
                InsetButton.Visible = value;
            }
            this.Refresh();
        }
    }

    /// <summary>
    /// Gets or sets the Font of the TextBox.
    /// </summary>
    [Category("Appearance")]
    [Description("The Font of the text that appears within the TextBox.")]
    public new Font Font {
        get => base.Font;
        set {
            base.Font = value;
            if (fSyncFont) {
                InsetButton.Font = value;
            }
        }
    }

    /// <summary>
    /// Gets or sets the Regular Expression patterns array that will match strings when pasted.
    /// </summary>
    [Category("Behavior")]
    [Description("An array of regular expression patterns that can match strings being pasted.")]
    public string[] RegexPatterns {
        get => fRegexPatterns;
        set => fRegexPatterns = value;
    }

    /// <summary>
    /// Gets or sets the bool of whether the button inside the textbox is useable.
    /// </summary>
    [Category("Behavior")]
    [DefaultValue(false)]
    [Description("The Button on the TextBox is enabled and usable.")]
    public bool ShowButton {
        get => fShowButton;
        set {
            if (value) {
                InsetButton.Enabled = fButtonEnabled;
                InsetButton.Visible = fButtonVisible;
            }
            else {
                InsetButton.Enabled = false;
                InsetButton.Visible = false;
            }
            fShowButton = value;
            this.Refresh();
        }
    }

    /// <summary>
    /// Gets or sets the bool whether the font should be in sync between the TextBox and Button.
    /// </summary>
    [Category("Behavior")]
    [DefaultValue(false)]
    [Description("Whether the font on the button and text box should be in sync. Text box takes precedent, changing either updates the other.")]
    public bool SyncronizeFont {
        get => fSyncFont;
        set {
            fSyncFont = value;
            if (value) {
                InsetButton.Font = base.Font;
            }
        }
    }

    ///// <summary>
    ///// Gets or sets the alignment of the text in the text box.
    ///// </summary>
    //[Category("Appearance")]
    //[DefaultValue(HorizontalAlignment.Left)]
    //[Description("Indicates how the text should be aligned for edit controls.")]
    //[Localizable(true)]
    //public new HorizontalAlignment TextAlign {
    //    get => base.TextAlign;
    //    set {
    //        base.TextAlign = value;
    //        this.Refresh();
    //    }
    //}

    /// <summary>
    /// Gets or sets the hint on the TextBox.
    /// </summary>
    [Category("Appearance")]
    [DefaultValue("")]
    [Description("The Text that will appear as a hint in the Text Box.")]
    public string TextHint {
        get => fTextHint;
        set {
            fTextHint = value;
            if (this.IsHandleCreated) {
                NativeMethods.SendMessage(this.Handle, 0x1501, 1, Marshal.StringToHGlobalUni(value));
            }
        }
    }

    /// <summary>
    /// Gets or sets the allowed characters to be typed in the TextBox.
    /// </summary>
    [Category("Behavior")]
    [DefaultValue(AllowedCharacters.All)]
    [Description("Determines if the Text Box wil only accept certain kinds of characters.")]
    public AllowedCharacters TextType {
        get => fTextType;
        set => fTextType = value;
    }

    /// <summary>
    /// Gets or sets the unfiltered char array for filters to allow characters to be typed.
    /// </summary>
    [Category("Behavior")]
    [DefaultValue(null)]
    [Description("The array of characters that will be allowed to be entered in the filtered text box.")]
    public char[] UnfilteredCharacters {
        get => fUnfilteredCharacters;
        set => fUnfilteredCharacters = value;
    }
    #endregion

    #region Constructor
    /// <summary>
    /// Initializes a new instace of the <see cref="ExtendedTextBox"/> class.
    /// </summary>
    public ExtendedTextBox() : base() {
        Controls.Add(InsetButton);
    }
    #endregion

    #region Overrides
    /// <inheritdoc/>
    protected override void OnHandleCreated(EventArgs e) {
        base.OnHandleCreated(e);
        Refresh();
    }

    /// <inheritdoc/>
    public override void Refresh() {
        base.Refresh();
        if (this.IsHandleCreated) {
            if (fShowButton) {
                UpdateButton();
                switch (fButtonAlignment) {
                    default: {
                        NativeMethods.SendMessage(Handle, Consts.EM_SETMARGINS, Consts.EC_RIGHTMARGIN, (InsetButton.Width << 16));
                    } break;

                    case ButtonAlignment.Right: {
                        NativeMethods.SendMessage(Handle, Consts.EM_SETMARGINS, Consts.EC_LEFTMARGIN, InsetButton.Width);
                    } break;
                }
            }
            else {
                NativeMethods.SendMessage(Handle, Consts.EM_SETMARGINS, Consts.EC_LEFTMARGIN, 0);
                NativeMethods.SendMessage(Handle, Consts.EM_SETMARGINS, Consts.EC_RIGHTMARGIN, 0);
            }

            if (!string.IsNullOrWhiteSpace(fTextHint)) {
                NativeMethods.SendMessage(this.Handle, 0x1501, 1, Marshal.StringToHGlobalUni(fTextHint));
            }
        }
    }

    /// <inheritdoc/>
    protected override void OnResize(EventArgs e) {
        UpdateButton();
        Refresh();
        base.OnResize(e);
    }

    /// <inheritdoc/>
    protected override void OnKeyDown(KeyEventArgs e) {
        if (fTextType == AllowedCharacters.UnfilteredCharactersOnly) {
            fCheckChar = true;
            base.OnKeyDown(e);
            return;
        }

        switch (e.KeyCode) {
            // Backspace can have either Control or Shift key held down,
            // Shift doesnt' change the behavior, but Control does.
            case Keys.Back: {
                e.SuppressKeyPress = e.Alt;
            } break;

            // Return can have the Shift key held down.
            // It doesn't change the behavior.
            case Keys.Return:{
                e.SuppressKeyPress = e.Control || e.Alt;
            } break;

            // Space doesn't really have much going on for it.
            case Keys.Space: {
                e.SuppressKeyPress = fTextType != AllowedCharacters.All && !fAllowSpace;
            } break;

            // Catch the modifier keys, so it won't
            // play the sound if they're pressed.
            case Keys.Control: case Keys.ControlKey:
            case Keys.LControlKey: case Keys.RControlKey:
            case Keys.Alt: case Keys.Menu:
            case Keys.LMenu: case Keys.RMenu:
            case Keys.Shift: case Keys.ShiftKey:
            case Keys.LShiftKey: case Keys.RShiftKey: {
            } break;

            // Major keys that are sussy.
            case Keys.A: case Keys.B: case Keys.C: case Keys.D:
            case Keys.E: case Keys.F: case Keys.G: case Keys.H:
            case Keys.I: case Keys.J: case Keys.K: case Keys.L:
            case Keys.M: case Keys.N: case Keys.O: case Keys.P:
            case Keys.Q: case Keys.R: case Keys.S: case Keys.T:
            case Keys.U: case Keys.V: case Keys.W: case Keys.X:
            case Keys.Y: case Keys.Z: {
                switch (fTextType) {
                    case AllowedCharacters.AlphabeticalOnly:
                    case AllowedCharacters.AlphaNumericOnly: {
                        e.SuppressKeyPress = e.Alt || e.Control;
                        if (e.Control) {
                            switch (e.KeyCode) {
                                case Keys.A: case Keys.C: case Keys.X: {
                                    e.SuppressKeyPress = false;
                                } break;

                                case Keys.V: {
                                    if (Clipboard.ContainsText()) {
                                        e.SuppressKeyPress = !Regex.IsMatch(Clipboard.GetText(),
                                            fTextType switch {
                                                AllowedCharacters.AlphabeticalOnly => $"^[a-zA-Z{(fAllowSpace ? " " : "")}]+$",
                                                AllowedCharacters.AlphaNumericOnly => $"^[a-zA-Z0-9{(fAllowSpace ? " " : "")}]+$",
                                                _ => throw new ArgumentOutOfRangeException("Ctrl + V was pressed but regex couldn't use a proper TextType.")
                                            }
                                        );
                                        if (fRegexPatterns.Length > 0 && Clipboard.ContainsText()) {
                                            Match FoundMatch;
                                            string ClipboardData = Clipboard.GetText();
                                            for (int i = 0; i < fRegexPatterns.Length; i++) {
                                                FoundMatch = Regex.Match(ClipboardData, fRegexPatterns[i]);
                                                if (FoundMatch.Success) {
                                                    e.SuppressKeyPress = true;
                                                    fRegexMatched = true;
                                                    RegexMatch?.Invoke(this, new(FoundMatch));
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                } break;
                            }
                        }
                    } break;

                    case AllowedCharacters.NumericOnly: {
                        if (e.Control) {
                            switch (e.KeyCode) {
                                case Keys.A:
                                case Keys.C:
                                case Keys.X: {
                                } break;

                                case Keys.V: {
                                    e.SuppressKeyPress = Clipboard.ContainsText() && Regex.IsMatch(Clipboard.GetText(), $"^[0-9{(fAllowSpace ? " " : "")}]+$", RegexOptions.Compiled);
                                } break;

                                default: {
                                    e.SuppressKeyPress = true;
                                } break;
                            }
                        }
                        else {
                            e.SuppressKeyPress = true;
                        }
                    } break;

                    default: {
                        e.SuppressKeyPress = fTextType != AllowedCharacters.All;
                    } break;
                }
            } break;

            // General numbers.
            case Keys.D1: case Keys.D2: case Keys.D3:
            case Keys.D4: case Keys.D5: case Keys.D6:
            case Keys.D7: case Keys.D8: case Keys.D9:
            case Keys.D0: {
                switch (fTextType) {
                    case AllowedCharacters.NumericOnly:
                    case AllowedCharacters.AlphaNumericOnly: {
                        e.SuppressKeyPress = e.Shift || e.Alt;
                    } break;

                    default: {
                        e.SuppressKeyPress = fTextType != AllowedCharacters.All;
                    } break;
                } break;
            }

            // Umbrella check.
            default: {
                e.SuppressKeyPress = fTextType != AllowedCharacters.All;
            } break;
        }

        if (e.SuppressKeyPress && !fRegexMatched) {
            fCheckChar = true;
            e.SuppressKeyPress = false;
        }
        else {
            fRegexMatched = false;
        }

        base.OnKeyDown(e);
    }

    /// <inheritdoc/>
    protected override void OnKeyPress(KeyPressEventArgs e) {
        if (fCheckChar) {
            fCheckChar = false;
            e.Handled = fUnfilteredCharacters == null || !fUnfilteredCharacters.Any(x => x == e.KeyChar);
            if (e.Handled) {
                System.Media.SystemSounds.Beep.Play();
            }
        }
        base.OnKeyPress(e);
    }
    #endregion

    #region Events
    /// <summary>
    /// Event raised when the Button in the TextBox is clicked.
    /// </summary>
    public event EventHandler ButtonClick {
        add => InsetButton.Click += value;
        remove => InsetButton.Click -= value;
    }

    /// <summary>
    /// Event raised when a Regular Expression pattern gets matched.
    /// </summary>
    public event EventHandler<RegexMatchEventArgs> RegexMatch;
    #endregion

    #region Methods
    /// <summary>
    /// Updates the button to fix appearance issues when size or alignment changes.
    /// </summary>
    private void UpdateButton() {
        if (this.IsHandleCreated) {
            InsetButton.Size = new(InsetButton.Size.Width, ClientSize.Height + 3);
            InsetButton.Location = fButtonAlignment switch {
                ButtonAlignment.Right => new(0, -2),
                _ => new(ClientSize.Width - InsetButton.Width, -2),
            };
        }
    }
    #endregion

}