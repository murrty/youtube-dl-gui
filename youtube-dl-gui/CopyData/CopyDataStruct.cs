namespace youtube_dl_gui;

using System.Runtime.InteropServices;

internal sealed partial class CopyData {
    [StructLayout(LayoutKind.Sequential)]
    public struct CopyDataStruct {
        public nint dwData;
        public int cbData;
        public nint lpData;
    }
}