namespace murrty.controls;

using murrty.controls.natives;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/// <summary>
/// Represents a derived Windows progress bar control that includes added functionality, Vista-styling, and Win7-style taskbar progress.
/// <para>Try to keep only one instance of the taskbars' progress on one progress bar at a time.</para>
/// </summary>
[ComVisible(true)]
[DefaultBindingProperty("Value")]
[DefaultProperty("Value")]
[ToolboxBitmap(typeof(ProgressBar))]
[ToolboxItem(true)]
public class ExtendedProgressBar : ProgressBar {

    #region Fields
    /// <summary>
    /// The parent container of the progress bar.
    /// </summary>
    private ContainerControl _ContainerParent = null;

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
    /// The alignment of the text.
    /// </summary>
    private ContentAlignment _TextAlignment = ContentAlignment.MiddleCenter;
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
            Invalidate();
        }
    }

    /// <summary>
    /// Gets or sets the Color of the text on the progress bar.
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue(KnownColor.ControlText)]
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
                NativeMethods.SendMessage(Handle, Consts.PBM_SETSTATE, (IntPtr)value, IntPtr.Zero);
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
    /// Gets or sets the progress bar style.
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Appearance")]
    [DefaultValue(ProgressBarStyle.Continuous)]
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
                NativeMethods.SendMessage(Handle, Consts.PBM_SETSTATE, (IntPtr)_ProgressState, IntPtr.Zero);
            }
        }
    }

    /// <summary>
    /// Gets or sets the text on the progress bar.
    /// </summary>
    [Bindable(true)]
    [Browsable(true)]
    [Category("Appearance")]
    [Description("The text that will be drawn within the progress bar, if enabled.")]
    [EditorBrowsable(EditorBrowsableState.Always)]
    public new string Text {
        get => base.Text;
        set {
            base.Text = value;
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

    #region Constructor
    /// <summary>
    /// Creates a new instance of the <see cref="ExtendedProgressBar"/> class.
    /// </summary>
    public ExtendedProgressBar() : base() {
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        this.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="ExtendedProgressBar"/> class.
    /// </summary>
    /// <param name="parent">The parent control of the progress bar.</param>
    public ExtendedProgressBar(ContainerControl parent) : base() {
        SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        _ContainerParent = parent;
        this.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
    }
    #endregion

    #region Overrides
    /// <summary>
    /// Advances the current position of the progress bar by the specified amount.
    /// </summary>
    /// <param name="value">The amount by which to increment the progress bar's current position.</param>
    /// <exception cref="InvalidOperationException"><see cref="T:System.Windows.Forms.ProgressBar.Style"/> is set to <see cref="T:System.Windows.Forms.ProgressBarStyle.Marquee"/>.</exception>
    public new void Increment(int value) {
        base.Increment(value);
        SetValueInTaskbar();
    }

    /// <inheritdoc/>
    override protected void OnPaint(PaintEventArgs e) {
        base.OnPaint(e);
        DrawText();
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
    public override ISite Site {
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
                DrawText();
            } break;

            case Consts.WM_SETCURSOR: {
                if (Cursor == Cursors.Hand) {
                    NativeMethods.SetCursor(Consts.SystemHand);
                    m.Result = new IntPtr(1);
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
        using Graphics graphics = CreateGraphics();
        SizeF size = graphics.MeasureString(base.Text, Font);
        graphics.DrawString(
            base.Text, Font, new SolidBrush(ForeColor),

            _TextAlignment switch {
                ContentAlignment.TopLeft or
                ContentAlignment.MiddleLeft or
                ContentAlignment.BottomLeft => RightToLeft == RightToLeft.Yes ? Width - size.Width : -1,

                ContentAlignment.TopCenter or
                ContentAlignment.MiddleCenter or
                ContentAlignment.BottomCenter => (Width - size.Width) / 2,

                ContentAlignment.TopRight or
                ContentAlignment.MiddleRight or
                ContentAlignment.BottomRight => RightToLeft == RightToLeft.Yes ? -1 : Width - size.Width,

                _ => 0
            },

            _TextAlignment switch {
                ContentAlignment.MiddleLeft or
                ContentAlignment.MiddleCenter or
                ContentAlignment.MiddleRight => (Height - size.Height) / 2,


                ContentAlignment.BottomLeft or
                ContentAlignment.BottomCenter or
                ContentAlignment.BottomRight => Height - size.Height,

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