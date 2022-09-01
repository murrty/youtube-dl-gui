using System.Runtime.InteropServices;

namespace youtube_dl_gui {
    internal sealed partial class CopyData {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SentData {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65_534)]
            public string Argument;
        }

    }
}
