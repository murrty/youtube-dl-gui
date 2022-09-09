namespace murrty.controls;
// Derived from wyDay's progress bar.

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using murrty.controls.natives;

/// <summary>
/// Represents a derived Windows progress bar control that includes added functionality, Vista-styling, and Win7-style taskbar progress.
/// <para>Try to keep only one instance of the taskbars' progress on one progress bar at a time.</para>
/// </summary>
[ComVisible(true)]
[DefaultBindingProperty("Value")]
[DefaultProperty("Value")]
[ToolboxBitmap(typeof(ProgressBar))]
[ToolboxItem(true)]
public sealed class ExtendedProgressBar : ProgressBar {

    #region Fields
    /// <summary>
    /// The parent container of the progress bar.
    /// </summary>
    private ContainerControl _ContainerParent = null;

    /// <summary>
    /// The color used for the drop shadow.
    /// </summary>
    private Color _DropShadowColor = Color.FromKnownColor(KnownColor.ControlDark);

    /// <summary>
    /// If the progress bar should update the value faster than default.
    /// <para>Used to bypass the slow progress build of vista progress bars.</para>
    /// </summary>
    private bool _FastValueUpdate = true;

    /// <summary>
    /// The state of the progress.
    /// </summary>
    private ProgressBarState _ProgressState = ProgressBarState.Normal;

    /// <summary>
    /// Whether the value and state should appear in the taskbars' icon.
    /// </summary>
    private bool _ShowInTaskbar = false;

    /// <summary>
    /// Whether text should render on the progressbar.
    /// </summary>
    private bool _ShowText = false;

    /// <summary>
    /// Whether the drop shadow on the text should be visible.
    /// </summary>
    private bool _ShowTextDropShadow = true;

    /// <summary>
    /// The alignment of the text.
    /// </summary>
    private ContentAlignment _TextAlignment = ContentAlignment.MiddleCenter;

    /// <summary>
    /// The graphics used for drawing text.
    /// </summary>
    private Graphics TextGraphics;

    /// <summary>
    /// The size of the text (Measured once)
    /// </summary>
    private SizeF TextSize;
    #endregion

    #region Properties
    /// <summary>
    /// Gets or sets the parent of the progress bar.
    /// </summary>
    [Bindable(false)]
    [Browsable(false)]
    [Category("Advanced")]
    [Description("The parent of the progress bar.")]
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public ContainerControl ContainerParent {
        get => _ContainerParent;
        set {
            _ContainerParent = value;

            if (_ContainerParent != null && !_ContainerParent.Visible) {
                ((Form)_ContainerParent).Shown += ExtendedProgressBar_Shown;
            }
        }
    }

    /// <summary>
    /// Gets or sets the color used for the text drop shadow.
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Appearance")]
    [Description("The color used for the drop shadow behind the text.")]
    [DefaultValue(typeof(Color), "ControlDark")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public Color DropShadowColor {
        get => _DropShadowColor;
        set {
            _DropShadowColor = value;
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets if the value of the progress bar updates faster than default.
    /// <para>Used to bypass the slow progress build of vista progress bars.</para>
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Behavior")]
    [DefaultValue(false)]
    [Description("Whether the value will update quickly when updating the value.")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public bool FastValueUpdate {
        get => _FastValueUpdate;
        set {
            _FastValueUpdate = value;
        }
    }

    /// <summary>
    /// Gets or sets the Font of the text on the progress bar.
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Appearance")]
    [Description("The font of the text that appears within the progress bar.")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public new Font Font {
        get => base.Font;
        set {
            base.Font = value;
            if (TextGraphics is not null)
                TextSize = TextGraphics.MeasureString(Text, value);
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets the Color of the text on the progress bar.
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue(typeof(Color), "ControlText")]
    [Description("The color of the text that appears within the progress bar.")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public new Color ForeColor {
        get => base.ForeColor;
        set {
            base.ForeColor = value;
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets the ProgressState of the progress bar.
    /// <para>Changing this option will force the ProgressBarStyle to ProgressBarStyle.Blocks if it is ProgressBarStyle.Marquee.</para>
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue(ProgressBarState.Normal)]
    [Description("The state of the progress bars' current \"action\".")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public ProgressBarState ProgressState {
        get => _ProgressState;
        set {
            _ProgressState = value;

            if (Style == ProgressBarStyle.Marquee) {
                Style = ProgressBarStyle.Blocks;
                SetValueInTaskbar();
            }
            else if (this.IsHandleCreated) {
                NativeMethods.SendMessage(Handle, PBM_SETSTATE, (IntPtr)value, IntPtr.Zero);
                SetStateInTaskbar();
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the progress bars' state and value will appear on the taskbar.
    /// <para>Keep only one instance on the taskbars' progress.</para>
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Behavior")]
    [DefaultValue(false)]
    [Description("Whether the taskbars' state and value should appear on the icon in the taskbar.")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public bool ShowInTaskbar {
        get => _ShowInTaskbar;
        set {
            if (_ShowInTaskbar != value) {
                _ShowInTaskbar = value;

                if (ContainerParent != null) {
                    if (Style != ProgressBarStyle.Marquee) {
                        SetValueInTaskbar();
                    }
                    SetStateInTaskbar();
                }
            }
        }
    }

    /// <summary>
    /// Gets or sets whether the text will appear on the progress bar.
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue(false)]
    [Description("Whether text should be rendered within the progress bar.")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public bool ShowText {
        get => _ShowText;
        set {
            _ShowText = value;
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets whether the text will appear with a drop shadow.
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue(true)]
    [Description("Whether text should be rendered with a drop shadow to distinguish it more clearly.")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public bool ShowTextDropShadow {
        get => _ShowTextDropShadow;
        set {
            _ShowTextDropShadow = value;
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets the progress bar style.
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue(ProgressBarStyle.Blocks)]
    [Description("The style of the progress bar.")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public new ProgressBarStyle Style {
        get => base.Style;
        set {
            base.Style = value;
            if (_ShowInTaskbar && _ContainerParent != null) {
                SetStateInTaskbar();
                SetValueInTaskbar();
            }
            if (value != ProgressBarStyle.Marquee && this.IsHandleCreated) {
                NativeMethods.SendMessage(Handle, PBM_SETSTATE, (IntPtr)_ProgressState, IntPtr.Zero);
            }
        }
    }

    /// <summary>
    /// Gets or sets the text on the progress bar.
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue("")]
    [Description("The text that will be drawn within the progress bar, if enabled.")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public new string Text {
        get => base.Text;
        set {
            base.Text = value;
            if (TextGraphics is not null)
                TextSize = TextGraphics.MeasureString(value, Font);
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets the ContentAlignment of the text on the progress bar.
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue(ContentAlignment.MiddleCenter)]
    [Description("The alignment of the text within the progress bar.")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public ContentAlignment TextAlignment {
        get => _TextAlignment;
        set {
            _TextAlignment = value;
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets the value in the progress bar.
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue(0)]
    [Description("The value that is displayed on the progress bar.")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public new int Value {
        get => base.Value;
        set {
            if (value > base.Maximum || value < base.Minimum)
                return;

            if (_FastValueUpdate && base.Value != base.Maximum) {
                base.Value++;
                base.Value--;
            }

            base.Value = value;
            SetValueInTaskbar();
        }
    }
    #endregion

    #region Native Methods
    /// <summary>
    /// The PBM_SETSTATE message for setting the state of a progress bar.
    /// </summary>
    private const int PBM_SETSTATE = 0x410;
    #endregion

    #region Constructor
    /// <summary>
    /// Creates a new instance of the <see cref="ExtendedProgressBar"/> class.
    /// </summary>
    public ExtendedProgressBar() : base() {
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        base.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="ExtendedProgressBar"/> class.
    /// </summary>
    /// <param name="parent">The parent control of the progress bar.</param>
    public ExtendedProgressBar(ContainerControl parent) : this() {
        _ContainerParent = parent;
    }
    #endregion

    #region Overrides
    /// <summary>
    /// Advances the current position of the progress bar by the specified amount.
    /// </summary>
    /// <param name="value">The amount by which to increment the progress bars' current position.</param>
    /// <exception cref="InvalidOperationException"><see cref="T:System.Windows.Forms.ProgressBar.Style"/> is set to <see cref="T:System.Windows.Forms.ProgressBarStyle.Marquee"/>.</exception>
    public new void Increment(int value) {
        base.Increment(value);
        SetValueInTaskbar();
    }

    /// <summary>
    /// Advances the current position of the progress bar by the amount of the <see cref="P:System.Windows.Forms.ProgressBar.Step"/> property.
    /// </summary>
    /// <exception cref="InvalidOperationException"><see cref="T:System.Windows.Forms.ProgressBar.Style"/> is set to <see cref="T:System.Windows.Forms.ProgressBarStyle.Marquee"/>.</exception>
    public new void PerformStep() {
        base.PerformStep();
        SetValueInTaskbar();
    }
    
    /// <inheritdoc/>
    protected override CreateParams CreateParams {
        get {
            CreateParams res = base.CreateParams;
            res.ExStyle |= Consts.WS_EX_COMPOSITED;
            return res;
        }
    }

    protected override void OnHandleCreated(EventArgs e) {
        base.OnHandleCreated(e);
        TextGraphics = CreateGraphics();
        TextSize = TextGraphics.MeasureString(Text, Font);
        if (ProgressState != ProgressBarState.Normal) {
            NativeMethods.SendMessage(Handle, PBM_SETSTATE, (nint)ProgressState, IntPtr.Zero);
            SetStateInTaskbar();
        }
    }

    /// <inheritdoc/>
    public override ISite Site {
        get => base.Site;
        set {
            // Runs at design time, ensures designer initializes ContainerControl
            base.Site = value;
            if (value != null && value.GetService(typeof(IDesignerHost)) is IDesignerHost service) {
                IComponent rootComponent = service.RootComponent;
                ContainerParent = rootComponent as ContainerControl;
            }
        }
    }

    /// <inheritdoc/>
    protected override void WndProc(ref Message m) {
        switch (m.Msg) {
            case Consts.WM_PAINT: {
                base.WndProc(ref m);
                if (_ShowText) {
                    DrawText();
                }
            } break;

            case Consts.WM_ERASEBKGND: {
                if (!DesignMode && Style != ProgressBarStyle.Marquee) {
                    Invalidate();
                }
            } break;

            case Consts.WM_SETCURSOR: {
                if (Cursor == Cursors.Hand) {
                    NativeMethods.SetCursor(Consts.SystemHand);
                    m.Result = IntPtr.Zero;
                }
                else base.WndProc(ref m);
            } break;

            default: {
                base.WndProc(ref m);
            } break;
        }
    }
    #endregion

    #region Events
    internal void ExtendedProgressBar_Shown(object sender, EventArgs e) {
        if (_ShowInTaskbar) {
            if (Style != ProgressBarStyle.Marquee) {
                SetValueInTaskbar();
            }
            SetStateInTaskbar();
        }

        ((Form)_ContainerParent).Shown -= ExtendedProgressBar_Shown;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Draws the text onto the control.
    /// </summary>
    private void DrawText() {
        if (_ShowTextDropShadow) {
            TextGraphics.DrawString(Text, Font, new SolidBrush(_DropShadowColor),
                _TextAlignment switch {
                    ContentAlignment.TopLeft or
                    ContentAlignment.MiddleLeft or
                    ContentAlignment.BottomLeft => RightToLeft == RightToLeft.Yes ? Width - TextSize.Width : -1,

                    ContentAlignment.TopCenter or
                    ContentAlignment.MiddleCenter or
                    ContentAlignment.BottomCenter => (Width - TextSize.Width) / 2,

                    ContentAlignment.TopRight or
                    ContentAlignment.MiddleRight or
                    ContentAlignment.BottomRight => RightToLeft == RightToLeft.Yes ? -1 : Width - TextSize.Width,

                    _ => 0
                } + 1,

                _TextAlignment switch {
                    ContentAlignment.MiddleLeft or
                    ContentAlignment.MiddleCenter or
                    ContentAlignment.MiddleRight => (Height - TextSize.Height) / 2,


                    ContentAlignment.BottomLeft or
                    ContentAlignment.BottomCenter or
                    ContentAlignment.BottomRight => Height - TextSize.Height,

                    _ => 0
                } + 1
            );
        }
        TextGraphics.DrawString(Text, Font, new SolidBrush(ForeColor),
            _TextAlignment switch {
                ContentAlignment.TopLeft or
                ContentAlignment.MiddleLeft or
                ContentAlignment.BottomLeft => RightToLeft == RightToLeft.Yes ? Width - TextSize.Width : -1,

                ContentAlignment.TopCenter or
                ContentAlignment.MiddleCenter or
                ContentAlignment.BottomCenter => (Width - TextSize.Width) / 2,

                ContentAlignment.TopRight or
                ContentAlignment.MiddleRight or
                ContentAlignment.BottomRight => RightToLeft == RightToLeft.Yes ? -1 : Width - TextSize.Width,

                _ => 0
            },

            _TextAlignment switch {
                ContentAlignment.MiddleLeft or
                ContentAlignment.MiddleCenter or
                ContentAlignment.MiddleRight => (Height - TextSize.Height) / 2,


                ContentAlignment.BottomLeft or
                ContentAlignment.BottomCenter or
                ContentAlignment.BottomRight => Height - TextSize.Height,

                _ => 0
            }
        );
    }

    /// <summary>
    /// Sets the progress bars' taskbar instance to the updated state.
    /// </summary>
    private void SetStateInTaskbar() {
        if (_ContainerParent != null && !DesignMode) {
            TaskbarInterface.SetProgressState(_ContainerParent.Handle, _ProgressState switch {
                _ when !_ShowInTaskbar => TaskbarProgressState.None,
                _ when Style == ProgressBarStyle.Marquee => TaskbarProgressState.Indeterminate,
                ProgressBarState.Error => TaskbarProgressState.Error,
                ProgressBarState.Paused => TaskbarProgressState.Paused,
                _ => TaskbarProgressState.Normal
            });
        }
    }

    /// <summary>
    /// Sets the progress bars' taskbar instance to the updated values.
    /// </summary>
    private void SetValueInTaskbar() {
        if (_ShowInTaskbar && _ContainerParent != null && Style != ProgressBarStyle.Marquee && !DesignMode) {
            TaskbarInterface.SetProgressValue(
                _ContainerParent.Handle,
                (ulong)(Value - Minimum),
                (ulong)(Maximum - Minimum)
            );
        }
    }
    #endregion

}