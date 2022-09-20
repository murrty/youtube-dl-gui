namespace youtube_dl_gui;

using System.Runtime.InteropServices;
using System.Windows.Forms;

internal class MessageHandler : NativeWindow {

    public MessageHandler() => this.CreateHandle(new());

    [System.Diagnostics.DebuggerStepThrough]
    protected override void WndProc(ref Message m) {
        switch (m.Msg) {
            case CopyData.WM_UPDATEDATAREQUEST: {
                UpdaterData Data = new() {
                    FileName = AppDomain.CurrentDomain.FriendlyName,
                    NewVersion = UpdateChecker.LastChecked.Version.ToString(),
                    UpdateHash = UpdateChecker.LastChecked.ExecutableHash
                };
                CopyDataStruct DataStruct = new();
                nint CopyDataBuffer = 0;
                nint DataBuffer = 0;
                try {
                    DataBuffer = CopyData.NintAlloc(Data);
                    DataStruct.cbData = Marshal.SizeOf(Data);
                    DataStruct.dwData = 1;
                    DataStruct.lpData = DataBuffer;
                    CopyDataBuffer = CopyData.NintAlloc(DataStruct);
                    CopyData.SendMessage(m.WParam, CopyData.WM_COPYDATA, Handle, CopyDataBuffer);
                }
                finally {
                    CopyData.NintFree(ref CopyDataBuffer);
                    CopyData.NintFree(ref DataBuffer);
                }
            } break;

            case CopyData.WM_UPDATERREADY: {
                Program.KillForUpdate();
            } break;

            default: {
                base.WndProc(ref m);
            } break;
        }
    }

    public void Dispose() => this.DestroyHandle();

}