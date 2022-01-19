// ExceptionForm Base 1.0.0

using System;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace murrty {

    public partial class frmException : Form {

        private readonly ExceptionInfo ReportedException;
        private const string GithubPage = "https://github.com/murrty/youtube-dl-gui/issues";

        public frmException(ExceptionInfo ReportedException) {
            this.ReportedException = ReportedException;
            
            InitializeComponent();
            LoadLanguage();
            
            if (string.IsNullOrEmpty(GithubPage)) {
                btnExceptionGithub.Enabled = false;
                btnExceptionGithub.Visible = false;
                lbDate.Location = new(btnExceptionRetry.Location.X - 119, lbDate.Location.Y);
            }
            
            lbDate.Text = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss}";
            btnExceptionRetry.Enabled = ReportedException.AllowRetry;
        }

        void LoadLanguage() {
            RandomNumberGenerator RNG = new RNGCryptoServiceProvider();
            byte[] ByteData = new byte[sizeof(int)];
            RNG.GetBytes(ByteData);
            uint GeneratedNumber = (uint)Math.Floor(0 + ((double)5001 - 0) * BitConverter.ToUInt32(ByteData, 0));

            switch (GeneratedNumber) {
                case 621: {
                    this.Text = "Exception occowwed unu";
                    lbExceptionHeader.Text = "An exception occowwed qwq";
                    lbExceptionDescription.Text = "The pwogwam accidentawy made a fucky wucky";
                    rtbExceptionDetails.Text = "Sowwy for fucky wucky, u can powst dis as a new issue on githuwb :3";
                    btnExceptionGithub.Text = "Githuwb >w<";
                    btnExceptionOk.Text = "Okie uwu";
                } break;

                default: {
                    if (ReportedException.FromLanguage) {
                        this.Text = youtube_dl_gui.Language.InternalEnglish.frmException;
                        lbExceptionHeader.Text = youtube_dl_gui.Language.InternalEnglish.lbExceptionHeader;
                        lbExceptionDescription.Text = youtube_dl_gui.Language.InternalEnglish.lbExceptionDescription;
                        rtbExceptionDetails.Text = youtube_dl_gui.Language.InternalEnglish.rtbExceptionDetails;
                        btnExceptionGithub.Text = youtube_dl_gui.Language.InternalEnglish.btnExceptionGithub;
                        btnExceptionOk.Text = youtube_dl_gui.Language.InternalEnglish.GenericOk;
                    }
                    else {
                        this.Text = youtube_dl_gui.Program.lang.frmException;
                        lbExceptionHeader.Text = youtube_dl_gui.Program.lang.lbExceptionHeader;
                        lbExceptionDescription.Text = youtube_dl_gui.Program.lang.lbExceptionDescription;
                        lbExceptionDescription.Text = youtube_dl_gui.Program.lang.lbExceptionDescription;
                        btnExceptionGithub.Text = youtube_dl_gui.Program.lang.btnExceptionGithub;
                        btnExceptionOk.Text = youtube_dl_gui.Program.lang.GenericOk;
                    }
                } break;
            }
        }

        public static string GetRelevantInformation() {
            return $"Current version: {(youtube_dl_gui.Properties.Settings.Default.IsBetaVersion ? youtube_dl_gui.Properties.Settings.Default.BetaVersion : youtube_dl_gui.Properties.Settings.Default.CurrentVersion)}\nCurrent culture: {System.Threading.Thread.CurrentThread.CurrentCulture.EnglishName}\nOS: {youtube_dl_gui.ErrorLog.ComputerVersionInformation}";
        }

        private void frmError_Load(object sender, EventArgs e) {
            if (ReportedException.CustomDescription is null) {
                switch (ReportedException.ReceivedException) {
                    case UnhandledExceptionEventArgs UnEx: {
                        rtbExceptionDetails.Text = "An unhandled exception occurred." +
                                                   "\nThe program will exit after closing this dialog.\n\n" +
                                                   UnEx.ExceptionObject + "\n";
                    } break;

                    case System.Threading.ThreadExceptionEventArgs ThrEx: {
                        rtbExceptionDetails.Text = "An unhandled thread exception occurred." +
                                                   "\nThe program will exit after closing this dialog.\n\n" +
                                                   ThrEx.Exception + "\n";
                    } break;

                    case youtube_dl_gui.DecimalParsingException DecParEx: {
                        rtbExceptionDetails.Text = "A decimal parsing exception occurred.\n\n" +
                                                   $"Message: {DecParEx.Message}\n" +
                                                   $"Stacktrace: {DecParEx.StackTrace}\n" +
                                                   $"Source: {DecParEx.Source}\n" +
                                                   $"Target Site: {DecParEx.TargetSite}\n" +
                                                   $"Inner Exception: {DecParEx.InnerException}\n" +
                                                   $"ExtraInfo:\n{DecParEx.ExtraInfo}\n";
                    } break;

                    case youtube_dl_gui.ApiParsingException ApiParEx: {
                        rtbExceptionDetails.Text = "A api parsing exception occurred.\n\n" +
                                                   $"API Url: {ApiParEx.ApiUrl}\n" +
                                                   $"Message: {ApiParEx.Message}\n" +
                                                   $"Stacktrace: {ApiParEx.StackTrace}\n" +
                                                   $"Source: {ApiParEx.Source}\n" +
                                                   $"Target Site: {ApiParEx.TargetSite}\n" +
                                                   $"Inner Exception: {ApiParEx.InnerException}\n" +
                                                   $"ExtraInfo:\n{ApiParEx.ExtraInfo}\n";
                    } break;

                    case WebException WebEx: {
                        rtbExceptionDetails.Text = (ReportedException.Unrecoverable ? "An unrecoverable web exception occurred, and the application will exit." : "A web exception occured.") + "\n\n" + $"Web Address: {ReportedException.ExtraInfo}\n" +
                                                 $"Message: {WebEx.Message}\n" +
                                                 $"Stacktrace: {WebEx.StackTrace}\n" +
                                                 $"Source: {WebEx.Source}\n" +
                                                 $"Target Site: {WebEx.TargetSite}\n" +
                                                 $"Inner Exception: {WebEx.InnerException}\n" +
                                                 $"Response: {WebEx.Response}\n";
                    } break;

                    case System.Threading.ThreadAbortException ThrAbrEx: {
                        rtbExceptionDetails.Text = (ReportedException.Unrecoverable ? "An unrecoverable thread abort exception occurred, and the application will exit." : "A thread abort exception occurred.") + "\n\n" + "This exception may have been pushed here on accident and not handled where it should've been.\n\n" +
                                                   $"Message: {ThrAbrEx.Message}\n" +
                                                   $"Stacktrace: {ThrAbrEx.StackTrace}\n" +
                                                   $"Source: {ThrAbrEx.Source}\n" +
                                                   $"Target Site: {ThrAbrEx.TargetSite}\n" +
                                                   $"Inner Exception: {ThrAbrEx.InnerException}\n";
                    } break;

                    case Exception Ex: {
                        rtbExceptionDetails.Text = (ReportedException.Unrecoverable ? "An unrecoverable exception occurred, and the application will exit." : "An exception occured.") + "\n\n" +
                                                   $"Message: {Ex.Message}\n" +
                                                   $"Stacktrace: {Ex.StackTrace}\n" +
                                                   $"Source: {Ex.Source}\n" +
                                                   $"Target Site: {Ex.TargetSite}\n" +
                                                   $"Inner Exception: {Ex.InnerException}\n";
                    } break;

                    default: {
                        rtbExceptionDetails.Text = $"An uncast exception occurred. The updater may exit after this dialog closes.\n";
                    } break;
                }

                rtbExceptionDetails.Text += "\n========== FULL REPORT ==========\n" +
                                            ReportedException.ReceivedException.ToString() +
                                            "\n========== END  REPORT ==========\n";

                rtbExceptionDetails.Text += "\n========== OS  INFO ==========\n" +
                                            "(Please don't omit this info, it may be important)\n" +
                                            GetRelevantInformation() +
                                            "\n========== END INFO ==========";
            }
            else {
                rtbExceptionDetails.Text = ReportedException.CustomDescription;
            }

            lbVersion.Text = youtube_dl_gui.Properties.Settings.Default.IsBetaVersion ?
                "v" + youtube_dl_gui.Properties.Settings.Default.BetaVersion :
                "v" + youtube_dl_gui.Properties.Settings.Default.CurrentVersion.ToString();
            
            System.Media.SystemSounds.Hand.Play();
        }

        private void btnExceptionOk_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void btnExceptionGithub_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(GithubPage);
        }

        private void btnExceptionRetry_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Retry;
            this.Dispose();
        }

    }

    /// <summary>
    /// The base exception detail class containing information about the exception, and modifiers about the actions.
    /// </summary>
    public class ExceptionInfo {
        #region Variables / Fields / Whatever
        /// <summary>
        /// The dynamic exception that is received.
        /// </summary>
        public dynamic ReceivedException = null;
        /// <summary>
        /// Any extra info regarding the exception.
        /// </summary>
        public object ExtraInfo = null;
        /// <summary>
        /// A description that is posted in the rich text box when an exception occurs.
        /// </summary>
        public string CustomDescription = null;
        /// <summary>
        /// If the exception was caused from loading the language file.
        /// </summary>
        public bool FromLanguage = false;
        /// <summary>
        /// If the cause of exception can be retried.
        /// </summary>
        public bool AllowRetry = false;
        /// <summary>
        /// If the exception is not recoverable, and the progarm must be terminated.
        /// </summary>
        public bool Unrecoverable = false;
        #endregion

        #region Constructor
        public ExceptionInfo(dynamic ReceivedException) {
            this.ReceivedException = ReceivedException;
        }
        #endregion
    }

}
