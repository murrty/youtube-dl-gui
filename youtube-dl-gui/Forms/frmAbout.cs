namespace youtube_dl_gui;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
public partial class frmAbout : Form, ILocalizedForm {
    Thread UpdateCheckThread;
    public frmAbout() {
        InitializeComponent();
        LoadLanguage();
        RegisterLocalizedForm();
        pbIcon.Image = Properties.Resources.AboutImage;
        pbIcon.Cursor = NativeMethods.SystemHandCursor;
        lbVersion.Text = $"v{Program.CurrentVersion}";
        llbCheckForUpdates.LinkVisited = Program.UpdateChecked;
        llbCheckForUpdates.Location = new(
            (this.ClientSize.Width - llbCheckForUpdates.Width) / 2,
            llbCheckForUpdates.Location.Y
        );

        if (Config.Settings.Initialization.ScreenshotMode)
            this.FormClosing += (s, e) => this.Dispose();

        this.FormClosing += (s, e) => UnregisterLocalizedForm();
    }

    public void LoadLanguage() {
        lbAboutBody.Text = string.Format(Language.lbAboutBody + "\n\n\nKnown as a gross red monster.", "murrty", Properties.Resources.BuildDate);
        llbCheckForUpdates.Text = Language.llbCheckForUpdates;
        this.Text = $"{Language.frmAbout} youtube-dl-gui";
    }

    public void RegisterLocalizedForm() => Language.RegisterForm(this);

    public void UnregisterLocalizedForm() => Language.UnregisterForm(this);

    private void llbCheckForUpdates_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
        if (UpdateCheckThread is null || !UpdateCheckThread.IsAlive) {
            UpdateCheckThread = new Thread(() => {
                try {
                    bool? result;
                    if ((result = UpdateChecker.CheckForUpdate(chkForceCheckUpdate.Checked, false, this)) is not null) {
                        if (result == false) {
                            this.BeginInvoke(() => {
                                Log.MessageBox(
                                    Program.CurrentVersion.IsBeta ?
                                        Language.dlgUpdateNoBetaUpdateAvailable.Format(Program.CurrentVersion, UpdateChecker.LastChecked.Version) :
                                        Language.dlgUpdateNoUpdateAvailable.Format(Program.CurrentVersion, UpdateChecker.LastChecked.Version));
                            });
                        }
                        Program.UpdateChecked = true;
                        if (!Program.IsUpdating && this.IsHandleCreated)
                            llbCheckForUpdates.Invoke(() => llbCheckForUpdates.LinkVisited = true);
                    }
                }
                catch (ThreadAbortException) {
                    // do nothing
                }
                catch (Exception ex) {
                    Log.ReportException(ex);
                }
            }) {
                Name = "Checks for updates",
                IsBackground = true
            };
            UpdateCheckThread.Start();
        }
    }

    private void pbIcon_Click(object sender, EventArgs e) =>
        Process.Start("https://github.com/murrty/youtube-dl-gui/");

    private void llbGithub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) =>
        Process.Start("https://github.com/murrty/youtube-dl-gui");
}
