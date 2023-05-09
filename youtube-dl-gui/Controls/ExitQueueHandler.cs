namespace youtube_dl_gui;
using System.Windows.Forms;
using System.Threading;
public partial class ExitQueueHandler : Form {
    private readonly Thread AwaitTasksThread;
    public ExitQueueHandler() {
        this.AutoScaleDimensions = new(6F, 13F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new(100, 100);
        this.ControlBox = false;
        this.Font = new("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
        this.FormBorderStyle = FormBorderStyle.None;
        this.Icon = Properties.Resources.ProgramIcon;
        this.MaximumSize = new(1, 1);
        this.Name = Program.ProgramGUID;
        this.Opacity = 0D;
        this.ShowIcon = false;
        this.ShowInTaskbar = false;
        this.Text = Program.ProgramGUID;
        this.WindowState = FormWindowState.Minimized;

        AwaitTasksThread = new(() => {
            Log.Write("Awaiting for the rest of the download actions.");

            while (Program.RunningActions.Count > 0)
                Thread.Sleep(500);

            Log.Write("Idle form no longer required.");
            this.Invoke(() => this.Dispose());
        }) {
            Name = "Awaiting actions"
        };

        this.Load += (s, e) => AwaitTasksThread.Start();
    }
    protected override void WndProc(ref Message m) {
        switch (m.Msg) {
            case CopyData.WM_COPYDATA: {
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

            case CopyData.WM_SHOWFORM: {
                if (Program.RunningActions.Count > 0)
                    Program.RunningActions.ElementAt(0).Show();
                m.Result = IntPtr.Zero;
            } break;

            default: {
                base.WndProc(ref m);
            } break;
        }
    }
}