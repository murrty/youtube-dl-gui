#nullable enable
namespace murrty.controls.natives;
using System.Runtime.InteropServices;
/// <summary>
/// The class for interfacing with the system taskbar.
/// </summary>
internal static class TaskbarInterface {
    #region Properties
    internal static readonly SynchronizedCollection<ExtendedProgressBar> AccessorPriorityList = new();
    internal static ExtendedProgressBar? Accessor {
        get => fAccessor;
        set {
            if (value is null) {
                if (AccessorPriorityList.Count > 0) {
                    while (AccessorPriorityList[0]?.IsDisposed != false) {
                        AccessorPriorityList.RemoveAt(0);
                    }

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
    private static ExtendedProgressBar? fAccessor;

    /// <summary>
    /// Gets the ITaskbarList3 for interfacing with the taskbar.
    /// </summary>
    internal static ITaskbarList3 TaskbarList3 { get; }
    #endregion

    static TaskbarInterface() {
        TaskbarList3 = (ITaskbarList3)new CTaskbarList();
        TaskbarList3.HrInit();
    }

    #region Interfaces
    [ComImport]
    [Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ITaskbarList3 {
        // ITaskbarList
        [PreserveSig]
        void HrInit();
        [PreserveSig]
        void AddTab(nint hwnd);
        [PreserveSig]
        void DeleteTab(nint hwnd);
        [PreserveSig]
        void ActivateTab(nint hwnd);
        [PreserveSig]
        void SetActiveAlt(nint hwnd);

        // ITaskbarList2
        [PreserveSig]
        void MarkFullscreenWindow(nint hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);

        // ITaskbarList3
        void SetProgressValue(nint hwnd, ulong ullCompleted, ulong ullTotal);
        void SetProgressState(nint hwnd, TaskbarProgressState tbpFlags);
    }

    [ClassInterface(ClassInterfaceType.None)]
    [ComImport]
    [Guid("56FDF344-FD6D-11d0-958A-006097C9A090")]
    internal class CTaskbarList { }
    #endregion

    #region Methods
    public static void SetProgressState(nint hWnd, TaskbarProgressState NewState) {
        TaskbarList3.SetProgressState(hWnd, NewState);
    }

    public static void SetProgressValue(nint hWnd, ulong Value, ulong Maximum) {
        TaskbarList3.SetProgressValue(hWnd, Value, Maximum);
    }
    #endregion
}