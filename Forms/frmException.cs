using System;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmException : Form {
        public Exception ReportedException = null;
        public WebException ReportedWebException = null;
        public string WebAddress = string.Empty;
        public int WebErrorCode = -1;
        public bool SetCustomDescription = false;
        public string CustomDescription = null;
        public bool FromLanguage = false;

        public frmException() {
            InitializeComponent();
            loadLanguage();
            DateTime TimeNow = DateTime.Now;
            lbDate.Text = string.Format("{0}/{1}/{2} {3}:{4}:{5}", TimeNow.Year, TimeNow.Month, TimeNow.Day, TimeNow.Hour, TimeNow.Minute, TimeNow.Second);
        }

        void loadLanguage() {
            RandomNumberGenerator RNG = new RNGCryptoServiceProvider();
            byte[] ByteData = new byte[sizeof(int)];
            RNG.GetBytes(ByteData);
            uint NewInt = BitConverter.ToUInt32(ByteData, 0);
            uint GeneratedNumber = (uint)Math.Floor((0 + ((double)5001 - 0) * NewInt));

            switch (GeneratedNumber) {
                case 621:
                    this.Text = "Exception occowwed unu";
                    lbExceptionHeader.Text = "An exception occowwed qwq";
                    lbExceptionDescription.Text = "The pwogwam accidentawy made a fucky wucky";
                    rtbExceptionDetails.Text = "Sowwy for fucky wucky, u can powst dis as a new issue on githuwb :3";
                    btnExceptionGithub.Text = "Githuwb >w<";
                    btnExceptionOk.Text = "Okie uwu";
                    break;

                default:
                    if (FromLanguage) {
                        this.Text = Language.InternalEnglish.frmException;
                        lbExceptionHeader.Text = Language.InternalEnglish.lbExceptionHeader;
                        lbExceptionDescription.Text = Language.InternalEnglish.lbExceptionDescription;
                        rtbExceptionDetails.Text = Language.InternalEnglish.rtbExceptionDetails;
                        btnExceptionGithub.Text = Language.InternalEnglish.btnExceptionGithub;
                        btnExceptionOk.Text = Language.InternalEnglish.btnExceptionOk;
                    }
                    else {
                        this.Text = Program.lang.frmException;
                        lbExceptionHeader.Text = Program.lang.lbExceptionHeader;
                        lbExceptionDescription.Text = Program.lang.lbExceptionDescription;
                        lbExceptionDescription.Text = Program.lang.lbExceptionDescription;
                        btnExceptionGithub.Text = Program.lang.btnExceptionGithub;
                        btnExceptionOk.Text = Program.lang.btnExceptionOk;
                    }
                    break;
            }

        }

        private void frmError_Load(object sender, EventArgs e) {
            string Exception = string.Empty;
            if (ReportedException != null) {
                Exception += "An exception occured" + "\n";
                Exception += "Message: " + ReportedException.Message + "\n";
                Exception += "Stacktrace: " + ReportedException.StackTrace + "\n";
                Exception += "Source: " + ReportedException.Source + "\n";
                Exception += "Target Site: " + ReportedException.TargetSite + "\n";


                Exception += "Full report:\n" + ReportedException.ToString();
            }
            else if (ReportedWebException != null) {
                Exception += "A web exception occured" + "\n";
                Exception += "Message: " + ReportedWebException.Message + "\n";
                Exception += "Stacktrace: " + ReportedWebException.StackTrace + "\n";
                Exception += "Source: " + ReportedWebException.Source + "\n";
                Exception += "Target Site: " + ReportedWebException.TargetSite + "\n";
                Exception += "Inner Exception: " + ReportedWebException.InnerException + "\n";
                Exception += "Response: " + ReportedWebException.Response + "\n";
                Exception += "Web Address: " + WebAddress + "\n";


                Exception += "Full report:\n" + ReportedWebException.ToString();
            }
            else if (CustomDescription != null) {
                rtbExceptionDetails.Text = CustomDescription;
            }
            else {
                Exception = "An exception occured, but it didn't parse properly.\nCreate a new issue and tell me how you got here.";
            }

            string outputBuffer = "\n\nVersion: {0}\n" + Exception;
            if (Properties.Settings.Default.IsBetaVersion) {
                outputBuffer = string.Format(outputBuffer, Properties.Settings.Default.BetaVersion);
                lbVersion.Text = "v" + Properties.Settings.Default.BetaVersion;
            }
            else {
                outputBuffer = string.Format(outputBuffer, Properties.Settings.Default.CurrentVersion.ToString());
                lbVersion.Text = "v" + Properties.Settings.Default.CurrentVersion.ToString();
            }
            rtbExceptionDetails.Text += outputBuffer;
            System.Media.SystemSounds.Hand.Play();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void btnGithub_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(GitData.Instance.GithubIssuesLink);
        }

    }
}
