/// frmException is a part of https://github.com/murrty/aphrodite booru downloader.
/// Licensed via GPL-3.0, if you did not receieve a license with this file; idk figure it out.
/// This code, *as-is*, should not be a part of another project; it should really only be used as reference or testing.
namespace murrty.logging;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

using aphrodite;
using murrty.classes;
/// <summary>
/// Represents a form that displays exception information to the user.
/// </summary>
public partial class frmException : Form {
    /// <summary>
    /// The private ExceptionInfo holding information about the exception.
    /// </summary>
    private ExceptionInfo ReportedException { get; }
    /// <summary>
    /// The DWM compositor, for making the form look prettier.
    /// </summary>
    private DwmComposition DwmCompositor { get; }
    /// <summary>
    /// Composition info relating to each form instance.
    /// </summary>
    private DwmCompositionInfo DwmInfo { get; }

    /// <summary>
    /// Initializes a new <see cref="frmException"/> instance.
    /// </summary>
    /// <param name="ReportedException">A <see cref="ExceptionInfo"/> instnace for a specific exception.</param>
    public frmException(ExceptionInfo ReportedException) {
        if (ReportedException is null) {
            MessageBox.Show("The reported exception is null and the exception cannot be displayed.");
            this.Load += (s, e) => this.Dispose();
            return;
        }

        this.ReportedException = ReportedException;
        InitializeComponent();
        LoadLanguage();
        rtbExtraData.Clear();

        // The icon for the exception form.
        this.Icon = global::aphrodite.Properties.Resources.ProgramIcon;

        // Check if there is a valid github link
        btnExceptionGithub.Enabled = true;
        btnExceptionGithub.Visible = true;

        // Check if allow retry.
        if (ReportedException.AllowRetry) {
            btnExceptionRetry.Enabled = btnExceptionRetry.Visible = true;
        }
        else {
            btnExceptionRetry.Enabled = btnExceptionRetry.Visible = false;
            btnExceptionGithub.Location = btnExceptionRetry.Location;
            lbDate.Location = new(
                btnExceptionGithub.Location.X - (lbDate.Size.Width + lbDate.Margin.Right + btnExceptionGithub.Margin.Left),
                lbDate.Location.Y);
        }

        // Add the date
        lbDate.Text = $"{ReportedException.ExceptionTime:yyyy/MM/dd HH:mm:ss}";

        if (DwmComposition.CompositionSupported && !ReportedException.SkipDwmComposition) {
            DwmCompositor = new();
            DwmInfo = new(
                this.Handle,
                new() {
                    m_Top = pnDWM.Height,
                    m_Bottom = 0,
                    m_Left = 0,
                    m_Right = 0
                },
                new(
                    pnDWM.Location.X,
                    pnDWM.Location.Y,
                    this.MaximumSize.Width,
                    pnDWM.Size.Height
                ),
                new(
                    lbExceptionHeader.Text,
                    lbExceptionHeader.Font,
                    Color.FromKnownColor(KnownColor.ActiveCaptionText),
                    10,
                    new(
                        lbExceptionHeader.Location.X,
                        lbExceptionHeader.Location.Y,
                        lbExceptionHeader.Size.Width,
                        lbExceptionHeader.Size.Height
                    )
                )
            );

            pnDWM.Visible = false;
            lbExceptionHeader.Visible = false;
            DwmCompositor.ExtendFrame(DwmInfo);
            this.Paint += (s, e) => {
                DwmCompositor.FillBlackRegion(DwmInfo);
                DwmCompositor.DrawTextOnGlass(DwmInfo, DwmInfo.Text);
            };
            this.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left && DwmInfo.DwmRectangle.Contains(e.Location)) {
                    DwmCompositor.MoveForm(DwmInfo);
                }
            };
        }
        else {
            lbExceptionHeader.Visible = true;
            pnDWM.BackColor = Color.FromKnownColor(KnownColor.Menu);
            pnDWM.Visible = true;
        }

        this.Shown += (s, e) => System.Media.SystemSounds.Hand.Play();
    }
    
    /// <summary>
    /// Loads the Language for the form.
    /// </summary>
    private void LoadLanguage() {
        // Just fuck my shit up
        this.Text = "Exception occowwed unu";
        lbExceptionHeader.Text = "An exception occowwed qwq";
        lbExceptionDescription.Text = "The pwogwam accidentawy made a fucky wucky";
        rtbExceptionDetails.Text = "Sowwy for fucky wucky, u can powst dis as a new issue on githuwb :3";
        btnExceptionGithub.Text = "Githuwb >w<";
        btnExceptionRetry.Text = "Retwy";
        btnExceptionOk.Text = "Okie uwu";
        tabExceptionDetails.Text = "Detaiws";
        tabExceptionExtraInfo.Text = "Extwa info";
    }

    /// <summary>
    /// Form loading event. The parsing happens here.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmError_Load(object sender, EventArgs e) {
        // A custom description was set, so we aren't going to write anything except for
        // what was written in the custom descrption.
        if (ReportedException.CustomDescription is not null) rtbExceptionDetails.Text = $"{ReportedException.CustomDescription}\n";

        // We need to figure out what exception occurred.
        // If the custom description is null, we can generate one.
        else if (ReportedException.Exception is not null) {
            rtbExceptionDetails.Text = ReportedException.ExceptionType switch {
                ExceptionType.Caught => $"A caught {ReportedException.Exception.GetType().Name} occurred.",
                ExceptionType.Unhandled => $"An unrecoverable {ReportedException.Exception.GetType().Name} occurred and the application will exit.",
                ExceptionType.ThreadException => $"An uncaught {ReportedException.Exception.GetType().Name} occurred and the application may resume.",
                _ => $"A caught {ReportedException.Exception.GetType().Name} occurred and the state of the application is undeterminable.",
            } + "\n\n";

            switch (ReportedException.Exception) {
                case ThreadAbortException ThrAbrEx: {
                    rtbExceptionDetails.AppendText(
                        $"This exception may have been pushed here on accident.\n" +
                        $"{(ReportedException.ExtraMessage is not null ? $"{ReportedException.ExtraMessage}\n\n" : "")}" +
                        $"Message: {ThrAbrEx.Message}\n" +
                        $"Stacktrace: {ThrAbrEx.StackTrace}\n" +
                        $"Source: {ThrAbrEx.Source}\n" +
                        $"Target Site: {ThrAbrEx.TargetSite}\n" +
                        $"Inner Exception: {ThrAbrEx.InnerException}\n");
                }
                break;

                case ApiReturnedNullOrEmptyException ApRtNuEmpEx: {
                    rtbExceptionDetails.AppendText(
                            $"This exception may have been pushed here on accident.\n" +
                            $"{(ReportedException.ExtraMessage is not null ? $"{ReportedException.ExtraMessage}\n\n" : "")}" +
                            $"Message: {ApRtNuEmpEx.Message}\n" +
                            $"Stacktrace: {ApRtNuEmpEx.StackTrace}\n" +
                            $"Source: {ApRtNuEmpEx.Source}\n" +
                            $"Target Site: {ApRtNuEmpEx.TargetSite}\n" +
                            $"Inner Exception: {ApRtNuEmpEx.InnerException}\n");
                }
                break;

                case ImageWasNullAfterBypassingException ImNuBypEx: {
                    rtbExceptionDetails.AppendText(
                            $"This exception may have been pushed here on accident.\n" +
                            $"{(ReportedException.ExtraMessage is not null ? $"{ReportedException.ExtraMessage}\n\n" : "")}" +
                            $"Message: {ImNuBypEx.Message}\n" +
                            $"Stacktrace: {ImNuBypEx.StackTrace}\n" +
                            $"Source: {ImNuBypEx.Source}\n" +
                            $"Target Site: {ImNuBypEx.TargetSite}\n" +
                            $"Inner Exception: {ImNuBypEx.InnerException}\n");
                }
                break;

                case NoFilesToDownloadException NoDlEx: {
                    rtbExceptionDetails.AppendText(
                            $"This exception may have been pushed here on accident.\n" +
                            $"{(ReportedException.ExtraMessage is not null ? $"{ReportedException.ExtraMessage}\n\n" : "")}" +
                            $"Message: {NoDlEx.Message}\n" +
                            $"Stacktrace: {NoDlEx.StackTrace}\n" +
                            $"Source: {NoDlEx.Source}\n" +
                            $"Target Site: {NoDlEx.TargetSite}\n" +
                            $"Inner Exception: {NoDlEx.InnerException}\n");
                }
                break;

                case PoolOrPostWasDeletedException PwdEx: {
                    rtbExceptionDetails.AppendText(
                            $"This exception may have been pushed here on accident.\n" +
                            $"{(ReportedException.ExtraMessage is not null ? $"{ReportedException.ExtraMessage}\n\n" : "")}" +
                            $"Message: {PwdEx.Message}\n" +
                            $"Stacktrace: {PwdEx.StackTrace}\n" +
                            $"Source: {PwdEx.Source}\n" +
                            $"Target Site: {PwdEx.TargetSite}\n" +
                            $"Inner Exception: {PwdEx.InnerException}\n");
                }
                break;

                case WebException WebEx: {
                    rtbExceptionDetails.AppendText(
                            $"{(ReportedException.ExtraMessage is not null ? $"{ReportedException.ExtraMessage}\n\n" : "")}" +
                            $"Message: {WebEx.Message}\n" +
                            $"Response: {WebEx.Response}\n" +
                            $"Stacktrace: {WebEx.StackTrace}\n" +
                            $"Source: {WebEx.Source}\n" +
                            $"Target Site: {WebEx.TargetSite}\n" +
                            $"Inner Exception: {WebEx.InnerException}\n");
                }
                break;

                case Exception Ex: {
                    rtbExceptionDetails.AppendText(
                            $"{(ReportedException.ExtraMessage is not null ? $"{ReportedException.ExtraMessage}\n\n" : "")}" +
                            $"Message: {Ex.Message}\n" +
                            $"Stacktrace: {Ex.StackTrace}\n" +
                            $"Source: {Ex.Source}\n" +
                            $"Target Site: {Ex.TargetSite}\n" +
                            $"Inner Exception: {Ex.InnerException}\n");
                }
                break;

                default: {
                    rtbExceptionDetails.Text = ReportedException.ExceptionType switch {
                        ExceptionType.Caught => "A caught unknown-typed exception occured.",
                        ExceptionType.Unhandled => "An unrecoverable unknown-typed exception occurred, and the application will exit.",
                        ExceptionType.ThreadException => "An uncaught unknown-typed exception occurred and the application may resume.",
                        _ => "A caught unknown-typed exception occurred and the state of the application is undeterminable.",
                    } + "\n\n" + $"{(ReportedException.ExtraMessage is not null ? $"\n\n{ReportedException.ExtraMessage}" : "")}\n";
                }
                break;
            }

            rtbExceptionDetails.AppendText("\n========== FULL REPORT ==========\n" +
                                           ReportedException.Exception.ToString() +
                                           "\n========== END  REPORT ==========\n");

        }

        // The exception itself is null, but the reported data is not.
        else rtbExceptionDetails.Text = "An exception occurred, but the received exception is null.";

        if (ReportedException is not null && ReportedException.ExtraInfo is not null) {
            string ExtraInfo = ReportedException.ExtraInfo.ToString();
            rtbExtraData.Text = ExtraInfo.Length > 0 ? ExtraInfo : "Extra info was provided, but it doesn't contain data.";
        }

        rtbExceptionDetails.AppendText("\n========== OS  INFO ==========\n" +
                                       "(Please don't omit this info, it may be important)\n" +
                                       Log.ComputerVersionInformation +
                                       "\n========== END INFO ==========");

        lbVersion.Text = "v" + Program.CurrentVersion.ToString();
    }

    /// <summary>
    /// Displays the github page.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnExceptionGithub_Click(object sender, EventArgs e) =>
        System.Diagnostics.Process.Start("https://github.com/murrty/aphrodite/issues");
}