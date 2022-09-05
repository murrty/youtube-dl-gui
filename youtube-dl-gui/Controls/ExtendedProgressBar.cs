using murrty.controls.natives;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace murrty.controls {
    #region Enumerations
    /// <summary>
    /// Represents the state of the progress bar control.
    /// </summary>
    [Flags]
    public enum ProgressBarState {
        /// <summary>
        /// Indicates the progress is succeeding so far, or finished.
        /// </summary>
        Normal = 0x1,
        /// <summary>
        /// Indicates the progress has encountered an error.
        /// </summary>
        Error = 0x2,
        /// <summary>
        /// Indicates the progress has been haulted. Can also represent a warning during progress.
        /// </summary>
        Paused = 0x3
    }

    /// <summary>
    /// Represents the state of the progress bars' taskbar influence.
    /// </summary>
    [Flags]
    public enum TaskbarProgressState {
        /// <summary>
        /// No progress is displayed in the taskbar.
        /// </summary>
        None = 0x0,
        /// <summary>
        /// Indicates the progress is indeterminate, or appears as a marquee.
        /// </summary>
        Indeterminate = 0x1,
        /// <summary>
        /// Indicates the progress is succeeding so far, or finished.
        /// </summary>
        Normal = 0x2,
        /// <summary>
        /// Indicates the progress has encountered an error.
        /// </summary>
        Error = 0x4,
        /// <summary>
        /// Indicates the progress has been haulted. Can also represent a warning during progress.
        /// </summary>
        Paused = 0x8
    }
    #endregion

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
                    Shared.SendMessage(Handle, PBM_SETSTATE, (IntPtr)value, IntPtr.Zero);
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
                    Shared.SendMessage(Handle, PBM_SETSTATE, (IntPtr)_ProgressState, IntPtr.Zero);
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
                case Shared.WM_PAINT: {
                    base.WndProc(ref m);
                    DrawText();
                } break;

                case Shared.WM_SETCURSOR: {
                    if (Cursor == Cursors.Hand) {
                        Shared.SetCursor(Shared.SystemHand);
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
}

#region Taskbar Interface
namespace murrty.controls.natives {

    /// <summary>
    /// The class for interfacing with the system taskbar.
    /// </summary>
    internal static class TaskbarInterface {

        #region Enumerations
        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT {
            public int left;
            public int top;
            public int right;
            public int bottom;

            public RECT(int left, int top, int right, int bottom) {
                this.left = left;
                this.top = top;
                this.right = right;
                this.bottom = bottom;
            }
        }

        internal enum TBATFLAG {
            TBATF_USEMDITHUMBNAIL = 0x1,
            TBATF_USEMDILIVEPREVIEW = 0x2
        }

        internal enum TBPFLAG {
            TBPF_NOPROGRESS = 0,
            TBPF_INDETERMINATE = 0x1,
            TBPF_NORMAL = 0x2,
            TBPF_ERROR = 0x4,
            TBPF_PAUSED = 0x8
        }

        internal enum THBMASK {
            THB_BITMAP = 0x1,
            THB_ICON = 0x2,
            THB_TOOLTIP = 0x4,
            THB_FLAGS = 0x8
        }

        internal enum THBFLAGS {
            THBF_ENABLED = 0,
            THBF_DISABLED = 0x1,
            THBF_DISMISSONCLICK = 0x2,
            THBF_NOBACKGROUND = 0x4,
            THBF_HIDDEN = 0x8
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct THUMBBUTTON {
            [MarshalAs(UnmanagedType.U4)]
            public THBMASK dwMask;
            public uint iId;
            public uint iBitmap;
            public IntPtr hIcon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szTip;
            [MarshalAs(UnmanagedType.U4)]
            public THBFLAGS dwFlags;
        }
        #endregion

        #region Fields
        /// <summary>
        /// The TaskbarList interface used to interface with the taskbar.
        /// </summary>
        private static ITaskbarList3 _TaskbarList3;
        #endregion

        #region Properties
        /// <summary>
        /// Gets if the version of windows running supports using the ITaskbarList interface.
        /// </summary>
        internal static bool Supported {
            get {
                return
                    Environment.OSVersion.Version.Major >= 6 ||
                    Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor >= 1;
            }
        }

        /// <summary>
        /// Gets the ITaskbarList3 for interfacing with the taskbar.
        /// </summary>
        internal static ITaskbarList3 TaskbarList3 {
            get {
                if (_TaskbarList3 == null) {
                    //lock (ListLock) {
                    lock (typeof(TaskbarInterface)) {
                        // Are second checks required?
                        if (_TaskbarList3 == null) {
                            _TaskbarList3 = (ITaskbarList3)new CTaskbarList();
                            _TaskbarList3.HrInit();
                        }
                    }
                }
                return _TaskbarList3;
            }
        }
        #endregion

        #region Interfaces
        [ComImport()]
        [Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface ITaskbarList3 {

            // ITaskbarList
            [PreserveSig]
            void HrInit();
            [PreserveSig]
            void AddTab(IntPtr hwnd);
            [PreserveSig]
            void DeleteTab(IntPtr hwnd);
            [PreserveSig]
            void ActivateTab(IntPtr hwnd);
            [PreserveSig]
            void SetActiveAlt(IntPtr hwnd);

            // ITaskbarList2
            [PreserveSig]
            void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

            // ITaskbarList3
            void SetProgressValue(IntPtr hwnd, UInt64 ullCompleted, UInt64 ullTotal);
            void SetProgressState(IntPtr hwnd, TaskbarProgressState tbpFlags);
            void RegisterTab(IntPtr hwndTab, IntPtr hwndMDI);
            void UnregisterTab(IntPtr hwndTab);
            void SetTabOrder(IntPtr hwndTab, IntPtr hwndInsertBefore);
            void SetTabActive(IntPtr hwndTab, IntPtr hwndMDI, TBATFLAG tbatFlags);
            void ThumbBarAddButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray)] THUMBBUTTON[] pButtons);
            void ThumbBarUpdateButtons(IntPtr hwnd, uint cButtons, [MarshalAs(UnmanagedType.LPArray)] THUMBBUTTON[] pButtons);
            void ThumbBarSetImageList(IntPtr hwnd, IntPtr himl);
            void SetOverlayIcon(IntPtr hwnd, IntPtr hIcon, [MarshalAs(UnmanagedType.LPWStr)] string pszDescription);
            void SetThumbnailTooltip(IntPtr hwnd, [MarshalAs(UnmanagedType.LPWStr)] string pszTip);
            void SetThumbnailClip(IntPtr hwnd, [MarshalAs(UnmanagedType.LPStruct)] ref RECT prcClip);
        }

        [Guid("56FDF344-FD6D-11d0-958A-006097C9A090")]
        [ClassInterface(ClassInterfaceType.None)]
        [ComImport()]
        internal class CTaskbarList { }
        #endregion

        #region Methods
        public static void SetOverlayIcon(IntPtr Handle, IntPtr Icon, string Description) {
            TaskbarList3.SetOverlayIcon(Handle, Icon, Description);
        }

        public static void SetProgressState(IntPtr hWnd, TaskbarProgressState NewState) {
            if (Supported) {
                TaskbarList3.SetProgressState(hWnd, NewState);
            }
        }

        public static void SetProgressValue(IntPtr hWnd, ulong Value, ulong Maximum) {
            if (Supported) {
                TaskbarList3.SetProgressValue(hWnd, Value, Maximum);
            }
        }
        #endregion

    }
}
#endregion