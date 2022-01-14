// ExceptionForm Base 1.0.0

using System;
using System.Net;
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
            }

            lbDate.Text = $"{DateTime.Now:yyyy/MM/dd HH:mm:ss}";
            btnExceptionRetry.Enabled = ReportedException.AllowRetry;
        }

        void LoadLanguage() {
            if (ReportedException.FromLanguage) {
                this.Text = youtube_dl_gui_updater.Language.InternalEnglish.frmException;
                lbExceptionHeader.Text = youtube_dl_gui_updater.Language.InternalEnglish.lbExceptionHeader;
                lbExceptionDescription.Text = youtube_dl_gui_updater.Language.InternalEnglish.lbExceptionDescription;
                rtbExceptionDetails.Text = youtube_dl_gui_updater.Language.InternalEnglish.rtbUpdaterExceptionDetails;
                btnExceptionGithub.Text = youtube_dl_gui_updater.Language.InternalEnglish.btnExceptionGithub;
                btnExceptionOk.Text = youtube_dl_gui_updater.Language.InternalEnglish.GenericOk;
                btnExceptionRetry.Text = youtube_dl_gui_updater.Language.InternalEnglish.GenericRetry;
            }
            else {
                this.Text = youtube_dl_gui_updater.Program.lang.frmException;
                lbExceptionHeader.Text = youtube_dl_gui_updater.Program.lang.lbExceptionHeader;
                lbExceptionDescription.Text = youtube_dl_gui_updater.Program.lang.lbExceptionDescription;
                lbExceptionDescription.Text = youtube_dl_gui_updater.Program.lang.lbExceptionDescription;
                btnExceptionGithub.Text = youtube_dl_gui_updater.Program.lang.btnExceptionGithub;
                btnExceptionOk.Text = youtube_dl_gui_updater.Program.lang.GenericOk;
                btnExceptionRetry.Text = youtube_dl_gui_updater.Program.lang.GenericRetry;
            }
        }

        public static string GetRelevantInformation() {
            return $"Current updater version: {(youtube_dl_gui_updater.Properties.Settings.Default.IsBetaVersion ? youtube_dl_gui_updater.Properties.Settings.Default.BetaVersion : youtube_dl_gui_updater.Properties.Settings.Default.CurrentVersion)}\nCurrent culture: {System.Threading.Thread.CurrentThread.CurrentCulture.EnglishName}\nOS: {youtube_dl_gui_updater.Program.ComputerVersionInformation}";
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
                        rtbExceptionDetails.Text = (ReportedException.Unrecoverable ? "An unrecoverable thread abort exception occurred, and the application will exit." : "A thread abort exception occurred.") + "\n\n" + "This exception may have been thrown on accident.";
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

            rtbExceptionDetails.Text += "\n========== FULL REPORT ==========\n" +
                                        ReportedException.ReceivedException.ToString() +
                                        "\n========== END  REPORT ==========\n";

            rtbExceptionDetails.Text += "\n========== OS  INFO ==========\n" +
                                        "(Please don't omit this info, it may be important)\n" +
                                        GetRelevantInformation() +
                                        "\n========== END INFO ==========";

            lbVersion.Text = youtube_dl_gui_updater.Properties.Settings.Default.IsBetaVersion ?
                "v" + youtube_dl_gui_updater.Properties.Settings.Default.BetaVersion :
                "v" + youtube_dl_gui_updater.Properties.Settings.Default.CurrentVersion.ToString();

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
