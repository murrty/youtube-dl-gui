namespace youtube_dl_gui;

using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

public partial class MessageHandler : Form {
    public bool AcceptMessages { get; private set;} = false;
    public bool AwaitingExit { get; private set; } = false;
    private bool CanUpdate { get; set; } = false;

    public MessageHandler() {
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new(1, 1);
        this.ControlBox = false;
        this.Font = new("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.FormBorderStyle = FormBorderStyle.None;
        this.Icon = Properties.Resources.ProgramIcon;
        this.Location = new(-31999, -31999);
        this.MaximumSize = new(1, 1);
        this.Name = Program.ProgramGUID;
        this.Opacity = 0D;
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.Text = Program.ProgramGUID;
        this.WindowState = FormWindowState.Minimized;

        this.Load += (s, e) => {
            AcceptMessages = true;
            Log.Write("Message queue handler loaded.");
            //Log.Write($"Handle: {Handle} (0x{(int)Handle:X})");
            //Log.Write($"ProcID: {Process.GetCurrentProcess().Id}");
        };
        this.Shown +=(s, e) => this.Hide();
    }
    public void AwaitExit() {
        AwaitingExit = true;
    }

    public void CheckExit() {
        if (!AwaitingExit || Program.RunningActions.Count > 0)
            return;
        AcceptMessages = false;
        AwaitingExit = false;
        this.Dispose();
    }

    [DebuggerStepThrough]
    protected override void WndProc(ref Message m) {
        switch (m.Msg) {
            case CopyData.WM_COPYDATA when AcceptMessages: {
                nint wp = m.WParam;
                // wParam should be the handle to the Window that sent the message.
                // Since WM_COPYDATA is overridden, I can DO WHAT I WANT.
                switch (wp) {
                    // 0x1 = The data was sent from another instance.
                    case 0x1: {
                        Program.ParseCopyData(ref m, null); // TODO: Extract the last selected custom argument from the saved config.
                        m.Result = IntPtr.Zero;
                    } break;

                    // No associated processing for this instance.
                    default: {
                        base.WndProc(ref m);
                    } break;
                }
            } break;

            // WM_SHOWFORM is a custom message.
            case CopyData.WM_SHOWFORM when AcceptMessages: {
                if (Program.MainForm is not null)
                    Program.MainForm.Activate();
                else if (Program.RunningActions.Count > 0)
                    Program.RunningActions[0].Show();
                m.Result = IntPtr.Zero;
            } break;

            // WM_UPDATEDATAREQUEST is a custom message.
            // Only allowed when the updater is launched from youtube-dl-gui.
            case CopyData.WM_UPDATEDATAREQUEST: {
                UpdateData Data = new() {
                    FileName = AppDomain.CurrentDomain.FriendlyName,
                    NewVersion = Updater.LastChecked.Version,
                    UpdateHash = Updater.LastChecked.ExecutableHash
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
                    CanUpdate = true;
                }
                finally {
                    CopyData.NintFree(ref CopyDataBuffer);
                    CopyData.NintFree(ref DataBuffer);
                }
            } break;

            // WM_UPDATERREADY is a custom message.
            // Only ran when WM_UPDATEDATAREQUEST has been called at least once.
            // Other cases, this is not a valid request.
            case CopyData.WM_UPDATERREADY when CanUpdate: {
                Program.KillForUpdate();
            } break;

            default: {
                base.WndProc(ref m);
            } break;
        }
    }
}