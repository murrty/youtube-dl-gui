namespace murrty.controls.natives;

using System.Runtime.InteropServices;

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

    private static readonly bool bSupported =
        Environment.OSVersion.Version.Major > 6 ||
        (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor >= 1);
    #endregion

    #region Properties
    internal static readonly SynchronizedCollection<ExtendedProgressBar> AccessorPriorityList = new();
    internal static ExtendedProgressBar Accessor {
        get => fAccessor;
        set {
            if (value is null) {
                if (AccessorPriorityList.Count > 0) {
                    fAccessor = AccessorPriorityList[0];
                    AccessorPriorityList.RemoveAt(0);
                    fAccessor.SetStateInTaskbar();
                    fAccessor.SetValueInTaskbar();
                }
                else {
                    fAccessor = value;
                }
            }
            else {
                fAccessor ??= value;
            }
        }
    }
    private static ExtendedProgressBar fAccessor;

    /// <summary>
    /// Gets if the version of windows running supports using the ITaskbarList interface.
    /// </summary>
    internal static bool Supported {
        get => bSupported;
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
    }

    [Guid("56FDF344-FD6D-11d0-958A-006097C9A090")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComImport()]
    internal class CTaskbarList { }
    #endregion

    #region Methods
    public static void SetProgressState(IntPtr hWnd, TaskbarProgressState NewState) {
        if (Supported)
            TaskbarList3.SetProgressState(hWnd, NewState);
    }

    public static void SetProgressValue(IntPtr hWnd, ulong Value, ulong Maximum) {
        if (Supported)
            TaskbarList3.SetProgressValue(hWnd, Value, Maximum);
    }
    #endregion

}