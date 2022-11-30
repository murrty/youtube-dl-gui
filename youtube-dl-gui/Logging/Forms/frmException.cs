namespace murrty.logging;
using System.Drawing;
using System.Net;
using System.Security.Cryptography;
using System.Threading;
using System.Windows.Forms;
using youtube_dl_gui;
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
    /// Whether the form will be UwU-ified.
    /// </summary>
    private bool UwU_ify { get; }

    /// <summary>
    /// Initializes a new <see cref="frmException"/> instance.
    /// </summary>
    /// <param name="ReportedException">A <see cref="ExceptionInfo"/> instnace for a specific exception.</param>
    public frmException(ExceptionInfo ReportedException) {
        if (ReportedException is null) {
            Log.MessageBox("The reported exception is null and the exception cannot be displayed.");
            this.Load += (s, e) => this.Dispose();
            return;
        }

        this.ReportedException = ReportedException;
        InitializeComponent();
        this.MaximumSize = new(1280, 720);
        rtbExtraData.Clear();

        // Roll for UwU-ification.
        RandomNumberGenerator RNG = new RNGCryptoServiceProvider();
        byte[] ByteData = new byte[sizeof(double)];
        RNG.GetBytes(ByteData);
        uint RandUint = BitConverter.ToUInt32(ByteData, 0);
        int GeneratedNumber = (int)Math.Floor(5000d * (RandUint / (uint.MaxValue + 1.0)));
        UwU_ify = GeneratedNumber == 621;
        Log.WriteToConsole($"The generated exception number was {GeneratedNumber}.");

        // Set the language.
        LoadLanguage();

        // The icon for the exception form.
        this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;

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

        // Hell
        if (DwmComposition.CompositionSupported && !ReportedException.SkipDwmComposition) {
            DwmCompositor = new();
            DwmInfo = new(
                hWnd: this.Handle,
                Margins: new() {
                    m_Top = pnDWM.Height,
                    m_Bottom = 0,
                    m_Left = 0,
                    m_Right = 0 },
                DwmRectangle: new(
                    pnDWM.Location.X,
                    pnDWM.Location.Y,
                    this.MaximumSize.Width,
                    pnDWM.Size.Height),
                NewInfo: new(
                    text: lbExceptionHeader.Text,
                    font: lbExceptionHeader.Font,
                    color: Color.FromKnownColor(KnownColor.ActiveCaptionText),
                    glowsize: 10,
                    rectangle: new(
                        lbExceptionHeader.Location.X,
                        lbExceptionHeader.Location.Y,
                        lbExceptionHeader.Size.Width,
                        lbExceptionHeader.Size.Height))
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
        if (UwU_ify) {
            // Just fuck my shit up
            this.Text = "Exception occowwed unu";
            lbExceptionHeader.Text = "An exception occowwed qwq";
            lbExceptionDescription.Text = "The pwogwam accidentawy made a fucky wucky";
            rtbExceptionDetails.Text = "Sowwy for fucky wucky, u can powst dis as a new issue on githuwb :3";
            btnExceptionGithub.Text = "Githuwb";
            btnExceptionRetry.Text = "Retwy";
            btnExceptionOk.Text = "Okie uwu";
            tabExceptionDetails.Text = "Detaiws";
            tabExceptionExtraInfo.Text = "Extwa info";
        }
        else {
            if (ReportedException.FromLanguage) {
                this.Text = Language.InternalEnglish.frmException;
                lbExceptionHeader.Text = Language.InternalEnglish.lbExceptionHeader;
                lbExceptionDescription.Text = Language.InternalEnglish.lbExceptionDescription;
                rtbExceptionDetails.Text = Language.InternalEnglish.rtbExceptionDetails;
                btnExceptionGithub.Text = Language.InternalEnglish.btnExceptionGithub;
                btnExceptionRetry.Text = Language.InternalEnglish.GenericRetry;
                btnExceptionOk.Text = Language.InternalEnglish.GenericOk;
                tabExceptionDetails.Text = Language.InternalEnglish.tabExceptionDetails;
                tabExceptionExtraInfo.Text = Language.InternalEnglish.tabExceptionExtraInfo;
            }
            else {
                this.Text = Language.frmException;
                lbExceptionHeader.Text = Language.lbExceptionHeader;
                lbExceptionDescription.Text = Language.lbExceptionDescription;
                rtbExceptionDetails.Text = Language.rtbExceptionDetails;
                btnExceptionGithub.Text = Language.btnExceptionGithub;
                btnExceptionRetry.Text = Language.GenericRetry;
                btnExceptionOk.Text = Language.GenericOk;
                tabExceptionDetails.Text = Language.tabExceptionDetails;
                tabExceptionExtraInfo.Text = Language.tabExceptionExtraInfo;
            }
        }
    }

    /// <summary>
    /// Form loading event. The parsing happens here.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void frmException_Load(object sender, EventArgs e) {
        // A custom description was set, so we aren't going to write anything except for
        // what was written in the custom descrption.
        if (ReportedException.CustomDescription is not null) rtbExceptionDetails.Text = $"{ReportedException.CustomDescription}\n";

        // We need to figure out what exception occurred.
        // If the custom description is null, we can generate one.
        else if (ReportedException.Exception is not null) {
            rtbExceptionDetails.Text = ReportedException.ExceptionType switch {
                ExceptionType.Caught => $"A caught {ReportedException.Exception.GetType().Name} occurred.",
                ExceptionType.Unhandled => $"An unrecoverable {ReportedException.Exception.GetType().Name} occurred and the application will need to exit.",
                ExceptionType.ThreadException => $"An uncaught {ReportedException.Exception.GetType().Name} occurred and the application may resume.",
                _ => $"A caught {ReportedException.Exception.GetType().Name} occurred and the state of the application is undeterminable.",
            } + "\n\n";

            switch (ReportedException.Exception) {
                case ThreadAbortException ThrAbrEx: {
                    rtbExceptionDetails.AppendText("This exception may have been pushed here on accident.\n");

                    if (ReportedException.ExtraMessage is not null)
                        rtbExceptionDetails.AppendText(ReportedException.ExtraMessage + "\n");

                    rtbExceptionDetails.AppendText($$"""
                        Message: {{ThrAbrEx.Message}}
                        Type: {{ThrAbrEx.GetType().FullName}}
                        Source: {{ThrAbrEx.Source}}
                        Target Site: {{ThrAbrEx.TargetSite}}
                        Stacktrace:
                        {{ThrAbrEx.StackTrace}}
                        """ + (ThrAbrEx.InnerException is not null ? "\nInner Exception: " + ThrAbrEx.InnerException : "") + "\n");
                } break;
                case System.Threading.Tasks.TaskCanceledException TkCdEx: {
                    rtbExceptionDetails.AppendText("This exception may have been pushed here on accident.\n");

                    if (ReportedException.ExtraMessage is not null)
                        rtbExceptionDetails.AppendText(ReportedException.ExtraMessage + "\n");

                    rtbExceptionDetails.AppendText($$"""
                        Message: {{TkCdEx.Message}}
                        Type: {{TkCdEx.GetType().FullName}}
                        Source: {{TkCdEx.Source}}
                        Target Site: {{TkCdEx.TargetSite}}
                        Stacktrace:
                        {{TkCdEx.StackTrace}}
                        """ + (TkCdEx.InnerException is not null ? "\nInner Exception: " + TkCdEx.InnerException : "") + "\n");
                } break;
                case OperationCanceledException OpCdEx: {
                    rtbExceptionDetails.AppendText("This exception may have been pushed here on accident.\n");

                    if (ReportedException.ExtraMessage is not null)
                        rtbExceptionDetails.AppendText(ReportedException.ExtraMessage + "\n");

                    rtbExceptionDetails.AppendText($$"""
                        Message: {{OpCdEx.Message}}
                        Type: {{OpCdEx.GetType().FullName}}
                        Source: {{OpCdEx.Source}}
                        Target Site: {{OpCdEx.TargetSite}}
                        Stacktrace:
                        {{OpCdEx.StackTrace}}
                        """ + (OpCdEx.InnerException is not null ? "\nInner Exception: " + OpCdEx.InnerException : "") + "\n");
                } break;

                case DownloadException DlEx: {
                    if (ReportedException.ExtraMessage is not null)
                        rtbExceptionDetails.AppendText(ReportedException.ExtraMessage + "\n");

                    rtbExceptionDetails.AppendText($$"""
                        Message: {{DlEx.Message}}
                        Media URL: {{DlEx.URL}}
                        Type: {{DlEx.GetType().FullName}}
                        Source: {{DlEx.Source}}
                        Target Site: {{DlEx.TargetSite}}
                        Stacktrace:
                        {{DlEx.StackTrace}}
                        """ + (DlEx.InnerException is not null ? "\nInner Exception: " + DlEx.InnerException : "") + "\n");
                } break;
                case WebException WebEx: {
                    if (ReportedException.ExtraMessage is not null)
                        rtbExceptionDetails.AppendText(ReportedException.ExtraMessage + "\n");

                    rtbExceptionDetails.AppendText($$"""
                        Message: {{WebEx.Message}}
                        Type: {{WebEx.GetType().FullName}}
                        Response: {{WebEx.Response}}
                        Source: {{WebEx.Source}}
                        Target Site: {{WebEx.TargetSite}}
                        Stacktrace:
                        {{WebEx.StackTrace}}
                        """ + (WebEx.InnerException is not null ? "\nInner Exception: " + WebEx.InnerException : "") + "\n");
                } break;
                case Exception Ex: {
                    if (ReportedException.ExtraMessage is not null)
                        rtbExceptionDetails.AppendText(ReportedException.ExtraMessage + "\n");

                    rtbExceptionDetails.AppendText($$"""
                        Message: {{Ex.Message}}
                        Type: {{Ex.GetType().FullName}}
                        Source: {{Ex.Source}}
                        Target Site: {{Ex.TargetSite}}
                        Stacktrace:
                        {{Ex.StackTrace}}
                        """ + (Ex.InnerException is not null ? "\nInner Exception: " + Ex.InnerException : "") + "\n");
                } break;

                default: {
                    rtbExceptionDetails.Text = ReportedException.ExceptionType switch {
                        ExceptionType.Caught => "A caught unknown-typed exception occured.",
                        ExceptionType.Unhandled => "An unrecoverable unknown-typed exception occurred, and the application will exit.",
                        ExceptionType.ThreadException => "An uncaught unknown-typed exception occurred and the application may resume.",
                        _ => "A caught unknown-typed exception occurred and the state of the application is undeterminable.",
                    } + "\n\n" + $"{(ReportedException.ExtraMessage is not null ? ReportedException.ExtraMessage : "")}\n";
                } break;
            }
        }

        // The exception itself is null, but the reported data is not.
        else rtbExceptionDetails.Text = "An exception occurred, but the received exception is null.\n";

        // Add the OS info to the end of the main exception display.
        rtbExceptionDetails.AppendText("\n" + $$"""
                ========== OS  INFO ==========
                {{Log.ComputerVersionInformation}}
                ========== END INFO ==========
                """);

        // Display the extra info, as a ToString value.
        if (ReportedException is not null && ReportedException.ExtraInfo is not null) {
            string ExtraInfo = ReportedException.ExtraInfo.ToString();
            rtbExtraData.Text = ExtraInfo.Length > 0 ? ExtraInfo : "Extra info was provided, but it doesn't contain data.";
        }

        // Sets the version of the program to the exception form.
        lbVersion.Text = "v" + Program.CurrentVersion.ToString();

        // Scroll to the top, because my rtb control is funny.
        rtbExceptionDetails.ScrollToTop();
        rtbExtraData.ScrollToTop();
    }

    /// <summary>
    /// Displays the github page.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnExceptionGithub_Click(object sender, EventArgs e) =>
        System.Diagnostics.Process.Start("https://github.com/murrty/youtube-dl-gui/issues");
}