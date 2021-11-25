using System;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;

namespace youtube_dl_gui {
    public class Win32 {

        public const int WM_COPYDATA = 0x004A;
        public const int WM_SHOWFORM = 0x0040;

        public struct CopyDataStruct : IDisposable {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;

            public void Dispose() {
                if (this.lpData != IntPtr.Zero) {
                    LocalFree(this.lpData);
                    this.lpData = IntPtr.Zero;
                }
            }
        }

        /// <summary>
        /// Contains message information from a thread's message queue.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct Message {
            public IntPtr hWnd;
            public uint msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public System.Drawing.Point p;
        }

        /// <summary>
        /// The FindWindow function retrieves a handle to the top-level 
        /// window whose class name and window name match the specified strings.
        /// This function does not search child windows. This function does not perform a case-sensitive search.
        /// </summary>
        /// <param name="strClassName">the class name for the window to search for</param>
        /// <param name="strWindowName">the name of the window to search for</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern int FindWindow(string strClassName, string strWindowName);

        /// <summary>
        /// The SendMessage API
        /// </summary>
        /// <param name="hWnd">handle to the required window</param>
        /// <param name="Msg">the system/Custom message to send</param>
        /// <param name="wParam">first message parameter</param>
        /// <param name="lParam">second message parameter</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref CopyDataStruct lParam);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LocalAlloc(int flag, int size);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr LocalFree(IntPtr p);

        /// <summary>
        /// Constructor
        /// </summary>
        public Win32() {
        }

        /// <summary>
        /// Deconstructor
        /// </summary>
        ~Win32() {
        }

        public static void KillProcessTree(uint ParentProcess) {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE ParentProcessId=" + ParentProcess);
            ManagementObjectCollection collection = searcher.Get();
            if (collection.Count > 0) {
                foreach (var proc in collection) {
                    uint id = (uint)proc["ProcessID"];
                    if ((int)id != ParentProcess) {
                        Process subProcess = Process.GetProcessById((int)id);
                        subProcess.Kill();
                    }
                }
            }
        }

        public static string ReceiveData(IntPtr Param) {
            CopyDataStruct Data = (CopyDataStruct)Marshal.PtrToStructure(Param, typeof(CopyDataStruct));
            return Marshal.PtrToStringUni(Data.lpData);
        }
    }
}
