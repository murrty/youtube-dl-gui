using System.Drawing;
using System.Net;

using youtube_dl_gui;
using murrty.classes;
using System.Threading;
using System.Security.Cryptography;

namespace murrty.forms {

    public partial class frmException : ExtendedForm {

        /// <summary>
        /// The private ExceptionInfo holding information about the exception.
        /// </summary>
        private ExceptionInfo ReportedException { get; }

        private readonly DwmComposition DwmCompositor;
        private readonly DwmCompositionInfo DwmInfo;

        public frmException(ExceptionInfo ReportedException) {
            this.ReportedException = ReportedException;

            InitializeComponent();
            LoadLanguage();

            // Check if there is a valid github link
            btnExceptionGithub.Enabled = true;
            btnExceptionGithub.Visible = true;

            // Check if allow retry.
            if (!ReportedException.AllowRetry) {
                btnExceptionRetry.Enabled = false;
                btnExceptionRetry.Visible = false;
                btnExceptionGithub.Location = btnExceptionRetry.Location;
                lbDate.Location = new(btnExceptionGithub.Location.X - 119, lbDate.Location.Y);
            }
            else {
                btnExceptionRetry.Enabled = true;
                btnExceptionRetry.Visible = true;
            }

            // Add the date
            lbDate.Text = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss}";

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
                    if (e.Button == System.Windows.Forms.MouseButtons.Left && DwmInfo.DwmRectangle.Contains(e.Location)) {
                        DwmCompositor.MoveForm(DwmInfo);
                    }
                };
            }
            else {
                lbExceptionHeader.Visible = true;
                pnDWM.BackColor = Color.FromKnownColor(KnownColor.Menu);
                pnDWM.Visible = true;
            }

            this.ShownSound = System.Media.SystemSounds.Hand;
        }
        
        private void LoadLanguage() {
            // Just fuck my shit up
            RandomNumberGenerator RNG = new RNGCryptoServiceProvider();
            byte[] ByteData = new byte[sizeof(double)];
            RNG.GetBytes(ByteData);
            uint RandUint = BitConverter.ToUInt32(ByteData, 0);
            int GeneratedNumber = (int)Math.Floor(0 + ((double)5000 - 0) * (RandUint / (uint.MaxValue + 1.0)));
            switch (GeneratedNumber) {
                case 621: {
                    this.Text = "Exception occowwed unu";
                    lbExceptionHeader.Text = "An exception occowwed qwq";
                    lbExceptionDescription.Text = "The pwogwam accidentawy made a fucky wucky";
                    rtbExceptionDetails.Text = "Sowwy for fucky wucky, u can powst dis as a new issue on githuwb :3";
                    btnExceptionGithub.Text = "Githuwb >w<";
                    btnExceptionRetry.Text = "Retwy";
                    btnExceptionOk.Text = "Okie uwu";
                    tpExceptionDetails.Text = "Detaiws";
                    tpExceptionExtraInfo.Text = "Extwa info";
                } break;

                default: {
                    if (ReportedException.FromLanguage) {
                        this.Text = Language.InternalEnglish.frmException;
                        lbExceptionHeader.Text = Language.InternalEnglish.lbExceptionHeader;
                        lbExceptionDescription.Text = Language.InternalEnglish.lbExceptionDescription;
                        rtbExceptionDetails.Text = Language.InternalEnglish.rtbExceptionDetails;
                        btnExceptionGithub.Text = Language.InternalEnglish.btnExceptionGithub;
                        btnExceptionRetry.Text = Language.InternalEnglish.GenericRetry;
                        btnExceptionOk.Text = Language.InternalEnglish.GenericOk;
                        btnExceptionOk.Text = Language.InternalEnglish.GenericOk;
                        btnExceptionOk.Text = Language.InternalEnglish.GenericOk;
                    }
                    else {
                        this.Text = Program.lang.frmException;
                        lbExceptionHeader.Text = Program.lang.lbExceptionHeader;
                        lbExceptionDescription.Text = Program.lang.lbExceptionDescription;
                        rtbExceptionDetails.Text = Program.lang.rtbExceptionDetails;
                        btnExceptionGithub.Text = Program.lang.btnExceptionGithub;
                        btnExceptionRetry.Text = Program.lang.GenericRetry;
                        btnExceptionOk.Text = Program.lang.GenericOk;
                        tpExceptionDetails.Text = Program.lang.tpExceptionDetails;
                        tpExceptionExtraInfo.Text = Program.lang.tpExceptionExtraInfo;
                    }
                } break;
            }
        }

        private void frmError_Load(object sender, EventArgs e) {
            // We need to figure out what exception occurred.
            // If the custom description is null, we can generate one.
            if (ReportedException.CustomDescription is null) {
                switch (ReportedException.ReceivedException) {
                    case UnhandledExceptionEventArgs UnEx: {
                        rtbExceptionDetails.Text = "An unhandled exception occurred.\n" +
                                                  $"The application will exit after closing this dialog.\n\n" +
                                                  $"{(ReportedException.ExtraMessage is not null ? $"{ReportedException.ExtraMessage}\n\n" : "")}" +
                                                  $"{UnEx.ExceptionObject}\n";
                    } break;

                    case ThreadExceptionEventArgs ThrEx: {
                        rtbExceptionDetails.Text = "An unhandled thread exception occurred.\n" +
                                                  $"The application will exit after closing this dialog.\n\n" +
                                                  $"{(ReportedException.ExtraMessage is not null ? $"{ReportedException.ExtraMessage}\n\n" : "")}" +
                                                  $"{ThrEx.Exception}\n";
                    } break;

                    case DecimalParsingException DecParEx: {
                        rtbExceptionDetails.Text = (ReportedException.Unrecoverable ? "An unrecoverable DecimalParsingException occurred, and the application will exit." : "A caught DecimalParsingException occurred.") + "\n\n" +
                                                  $"{(ReportedException.ExtraMessage is not null ? $"{ReportedException.ExtraMessage}\n\n" : "")}" +
                                                  $"Message: {DecParEx.Message}\n" +
                                                  $"Stacktrace: {DecParEx.StackTrace}\n" +
                                                  $"Source: {DecParEx.Source}\n" +
                                                  $"Target Site: {DecParEx.TargetSite}\n" +
                                                  $"Inner Exception: {DecParEx.InnerException}\n";
                    } break;

                    case ApiParsingException ApiParEx: {
                        rtbExceptionDetails.Text = (ReportedException.Unrecoverable ? "An unrecoverable ApiParsingException occurred, and the application will exit." : "A caught ApiParsingException occurred.") + "\n\n" +
                                                  $"{(ReportedException.ExtraMessage is not null ? $"{ReportedException.ExtraMessage}\n\n" : "")}" +
                                                  $"Message: {ApiParEx.Message}\n" +
                                                  $"Stacktrace: {ApiParEx.StackTrace}\n" +
                                                  $"Source: {ApiParEx.Source}\n" +
                                                  $"Target Site: {ApiParEx.TargetSite}\n" +
                                                  $"Inner Exception: {ApiParEx.InnerException}\n";
                    } break;

                    case ThreadAbortException ThrAbrEx: {
                        rtbExceptionDetails.Text = (ReportedException.Unrecoverable ? "An unrecoverable ThreadAbortException occurred, and the application will exit." : "A caught ThreadAbortException occurred.") + "\n\n" +
                                                  $"This exception may have been pushed here on accident.\n" +
                                                  $"{(ReportedException.ExtraMessage is not null ? $"{ReportedException.ExtraMessage}\n\n" : "")}" +
                                                  $"Message: {ThrAbrEx.Message}\n" +
                                                  $"Stacktrace: {ThrAbrEx.StackTrace}\n" +
                                                  $"Source: {ThrAbrEx.Source}\n" +
                                                  $"Target Site: {ThrAbrEx.TargetSite}\n" +
                                                  $"Inner Exception: {ThrAbrEx.InnerException}\n";
                    } break;

                    case WebException WebEx: {
                        rtbExceptionDetails.Text = (ReportedException.Unrecoverable ? "An unrecoverable WebException occurred, and the application will exit." : "A caught WebException occured.") + "\n\n" +
                                                  $"{(ReportedException.ExtraMessage is not null ? $"{ReportedException.ExtraMessage}\n\n" : "")}" +
                                                  $"{(ReportedException.ExtraInfo is not null ? "Web Address: " + $"{ReportedException.ExtraInfo}\n" : "")}" +
                                                  $"Message: {WebEx.Message}\n" +
                                                  $"Stacktrace: {WebEx.StackTrace}\n" +
                                                  $"Source: {WebEx.Source}\n" +
                                                  $"Target Site: {WebEx.TargetSite}\n" +
                                                  $"Inner Exception: {WebEx.InnerException}\n" +
                                                  $"Response: {WebEx.Response}\n";
                    } break;

                    case Exception Ex: {
                        rtbExceptionDetails.Text = (ReportedException.Unrecoverable ? $"An unrecoverable {ReportedException.ReceivedException.GetType().Name} occurred, and the application will exit." : $"A caught {ReportedException.ReceivedException.GetType().Name} occured.") + "\n\n" +
                                                  $"{(ReportedException.ExtraMessage is not null ? $"{ReportedException.ExtraMessage}\n\n" : "")}" +
                                                  $"Message: {Ex.Message}\n" +
                                                  $"Stacktrace: {Ex.StackTrace}\n" +
                                                  $"Source: {Ex.Source}\n" +
                                                  $"Target Site: {Ex.TargetSite}\n" +
                                                  $"Inner Exception: {Ex.InnerException}\n";
                    } break;

                    default: {
                        rtbExceptionDetails.Text = "An uncast exception occurred. The updater may exit after this dialog closes." +
                                                  $"{(ReportedException.ExtraMessage is not null ? $"\n\n{ReportedException.ExtraMessage}" : "")}\n";
                    } break;
                }

                rtbExceptionDetails.Text += "\n========== FULL REPORT ==========\n" +
                                            ReportedException.ReceivedException.ToString() +
                                            "\n========== END  REPORT ==========\n";

            }
            // A custom description was set, so we aren't going to write anything except for
            // what was written in the custom descrption.
            else rtbExceptionDetails.Text = $"{ReportedException.CustomDescription}\n";

            if (ReportedException.ExtraInfo is not null) {
                rtbExtraData.Text = ReportedException.ExtraInfo.ToString();
            }

            rtbExceptionDetails.Text += "\n========== OS  INFO ==========\n" +
                                        "(Please don't omit this info, it may be important)\n" +
                                        Log.DiagnosticInformation +
                                        "\n========== END INFO ==========";

            lbVersion.Text = "v" + Program.CurrentVersion.ToString();
        }

        private void btnExceptionGithub_Click(object sender, EventArgs e) =>
            System.Diagnostics.Process.Start("https://github.com/murrty/youtube-dl-gui/issues");

    }

    /// <summary>
    /// The base exception detail class containing information about the exception, and modifiers about the actions.
    /// </summary>
    public sealed class ExceptionInfo {

        #region Fields
        /// <summary>
        /// The dynamic exception that is received.
        /// </summary>
        public dynamic ReceivedException { get; init; } = null;
        /// <summary>
        /// Extra information regarding the exception.
        /// </summary>
        public object ExtraInfo { get; init; } = null;

        /// <summary>
        /// An extra message that's printed before the main exception text.
        /// </summary>
        public string ExtraMessage { get; init; } = null;
        /// <summary>
        /// The description that is posted to the exception form instead of one that gets parsed.
        /// </summary>
        public string CustomDescription { get; init; } = null;
        /// <summary>
        /// If the exception was caused from loading the language file.
        /// </summary>
        public bool FromLanguage { get; init; } = false;
        /// <summary>
        /// If the cause of exception can be retried.
        /// </summary>
        public bool AllowRetry { get; init; } = false;
        /// <summary>
        /// If the exception is not recoverable, and the progarm must be terminated.
        /// </summary>
        public bool Unrecoverable { get; init; } = false;
        /// <summary>
        /// If the exception form should skip dwm compositing.
        /// </summary>
        public bool SkipDwmComposition { get; init; } = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of <see cref="ExceptionInfo"/>.
        /// </summary>
        /// <param name="ReceivedException">The received exception.</param>
        public ExceptionInfo(dynamic ReceivedException) {
            this.ReceivedException = ReceivedException;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ExceptionInfo"/>.
        /// </summary>
        /// <param name="ReceivedException">The received exception.</param>
        /// <param name="ExtraInfo">Extra information of the exception.</param>
        public ExceptionInfo(dynamic ReceivedException, object ExtraInfo) {
            this.ReceivedException = ReceivedException;
            this.ExtraInfo = ExtraInfo;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ExceptionInfo"/>.
        /// </summary>
        /// <param name="ReceivedException">The received exception.</param>
        /// <param name="ExtraMessage">The extra message relating to the exception.</param>
        public ExceptionInfo(dynamic ReceivedException, string ExtraMessage) {
            this.ReceivedException = ReceivedException;
            this.ExtraMessage = ExtraMessage;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="ExceptionInfo"/>.
        /// </summary>
        /// <param name="ReceivedException">The received exception.</param>
        /// <param name="ExtraInfo">Extra information of the exception.</param>
        /// <param name="ExtraMessage">The extra message relating to the exception.</param>
        public ExceptionInfo(dynamic ReceivedException, object ExtraInfo, string ExtraMessage) {
            this.ReceivedException = ReceivedException;
            this.ExtraInfo = ExtraInfo;
            this.ExtraMessage = ExtraMessage;
        }
        #endregion

    }

    public class ExtendedForm : System.Windows.Forms.Form {
        /// <summary>
        /// Gets or sets the sound that plays when the form is shown.
        /// </summary>
        public System.Media.SystemSound ShownSound {
            get;
            set;
        } = null;
        /// <inheritdoc />
        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            ShownSound?.Play();
        }
    }

}
