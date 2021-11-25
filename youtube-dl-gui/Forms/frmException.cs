using System;
using System.Linq;
using System.Management;
using System.Net;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmException : Form {

        public Exception ReportedException = null;
        public WebException ReportedWebException = null;
        public DecimalParsingException ReportedDecimalParsingException = null;
        public ApiParsingException ReportedApiParsingException = null;
        public string WebAddress = string.Empty;
        public int WebErrorCode = -1;
        public bool SetCustomDescription = false;
        public string CustomDescription = null;
        public bool FromLanguage = false;
        public bool EnableRetry = false;

        public frmException() {
            InitializeComponent();
            loadLanguage();
            DateTime TimeNow = DateTime.Now;
            lbDate.Text = string.Format("{0}/{1}/{2} {3}:{4}:{5}", TimeNow.Year, TimeNow.Month, TimeNow.Day, TimeNow.Hour, TimeNow.Minute, TimeNow.Second);
            btnExceptionRetry.Enabled = EnableRetry;
        }

        private void loadLanguage() {
            RandomNumberGenerator RNG = new RNGCryptoServiceProvider();
            byte[] ByteData = new byte[sizeof(int)];
            RNG.GetBytes(ByteData);
            uint NewInt = BitConverter.ToUInt32(ByteData, 0);
            uint GeneratedNumber = (uint)Math.Floor(0 + ((double)5001 - 0) * NewInt);

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
                        btnExceptionOk.Text = Language.InternalEnglish.GenericOk;
                    }
                    else {
                        this.Text = Program.lang.frmException;
                        lbExceptionHeader.Text = Program.lang.lbExceptionHeader;
                        lbExceptionDescription.Text = Program.lang.lbExceptionDescription;
                        lbExceptionDescription.Text = Program.lang.lbExceptionDescription;
                        btnExceptionGithub.Text = Program.lang.btnExceptionGithub;
                        btnExceptionOk.Text = Program.lang.GenericOk;
                    }
                    break;
            }

        }

        public static string GetRelevantInformation() {
            string NewRelevantInfo = "Lanugage: {0}\n Current Culture: {1}\nOS: {2}";

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            ManagementObject info = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
            string OsVersion = string.Format(
                "Version: {0}, Service Pack Major: {1}, Service Pack Minor: {2}, Caption: {3}",
                new object[] {
                    info.Properties["Version"].Value.ToString(),
                    info.Properties["ServicePackMajorVersion"].Value.ToString(),
                    info.Properties["ServicePackMinorVersion"].Value.ToString(),
                    info.Properties["Caption"].Value.ToString()
                }
            );

            if (Properties.Settings.Default.IsBetaVersion) {
                return string.Format(NewRelevantInfo, Properties.Settings.Default.BetaVersion, System.Threading.Thread.CurrentThread.CurrentCulture.EnglishName, OsVersion);
            }
            else {
                return string.Format(NewRelevantInfo,Properties.Settings.Default.CurrentVersion.ToString(), System.Threading.Thread.CurrentThread.CurrentCulture.EnglishName, OsVersion);
            }
        }

        private void frmError_Load(object sender, EventArgs e) {
            string Exception = string.Empty;
            if (ReportedException != null) {
                Exception += "An exception occured" + "\n";
                Exception += GetRelevantInformation();
                Exception += "Message: " + ReportedException.Message + "\n";
                Exception += "Stacktrace: " + ReportedException.StackTrace + "\n";
                Exception += "Source: " + ReportedException.Source + "\n";
                Exception += "Target Site: " + ReportedException.TargetSite + "\n";

                Exception += "\n========== FULL REPORT ==========\n" + ReportedException.ToString();
                Exception += "\n========== END  REPORT ==========";
            }
            else if (ReportedWebException != null) {
                Exception += "A web exception occured" + "\n";
                Exception += GetRelevantInformation();
                Exception += "Web Address: " + WebAddress + "\n";
                Exception += "Message: " + ReportedWebException.Message + "\n";
                Exception += "Stacktrace: " + ReportedWebException.StackTrace + "\n";
                Exception += "Source: " + ReportedWebException.Source + "\n";
                Exception += "Target Site: " + ReportedWebException.TargetSite + "\n";
                Exception += "Inner Exception: " + ReportedWebException.InnerException + "\n";
                Exception += "Response: " + ReportedWebException.Response + "\n";


                Exception += "\n========== FULL REPORT ==========\n" + ReportedWebException.ToString();
                Exception += "\n========== END  REPORT ==========";
            }
            else if (ReportedDecimalParsingException != null) {
                Exception += "A decimal parsing exception occured" + "\n";
                Exception += GetRelevantInformation();
                if (ReportedDecimalParsingException.ExtraInfo != null) {
                    Exception += "Extra information will now be posted before stacktraces, and etc.";
                    Exception += "\n========== EXTRA INFO ==========\n";
                    Exception += ReportedDecimalParsingException.ExtraInfo;
                    Exception += "\n========== EXTRA  END ==========";
                }

                Exception += "Message: " + ReportedDecimalParsingException.Message + "\n";
                Exception += "Stacktrace: " + ReportedDecimalParsingException.StackTrace + "\n";
                Exception += "Source: " + ReportedDecimalParsingException.Source + "\n";
                Exception += "Target Site: " + ReportedDecimalParsingException.TargetSite + "\n";


                Exception += "\n========== FULL REPORT ==========\n" + ReportedDecimalParsingException.ToString();
                Exception += "\n========== END  REPORT ==========";

            }
            else if (ReportedApiParsingException != null) {
                Exception += "A API parsing exception occured" + "\n";
                Exception += GetRelevantInformation();
                if (ReportedApiParsingException.ExtraInfo != null) {
                    Exception += "Extra information will now be posted before stacktraces, and etc.";
                    Exception += "\n========== EXTRA INFO ==========\n";
                    Exception += ReportedApiParsingException.ExtraInfo;
                    Exception += "\n========== EXTRA  END ==========\n";
                }

                Exception += "API URL: " + ReportedApiParsingException.ApiUrl + "\n";
                Exception += "Message: " + ReportedApiParsingException.Message + "\n";
                Exception += "Stacktrace: " + ReportedApiParsingException.StackTrace + "\n";
                Exception += "Source: " + ReportedApiParsingException.Source + "\n";
                Exception += "Target Site: " + ReportedApiParsingException.TargetSite + "\n";


                Exception += "\n========== FULL REPORT ==========\n" + ReportedApiParsingException.ToString();
                Exception += "\n========== END  REPORT ==========";
            }
            else {
                Exception = "An unhandled exception has occured. Please let me know how you got here.";
            }

            rtbExceptionDetails.Text = CustomDescription ?? Exception;

            lbVersion.Text = Properties.Settings.Default.IsBetaVersion?
                "v" + Properties.Settings.Default.BetaVersion :
                "v" + Properties.Settings.Default.CurrentVersion.ToString();

            System.Media.SystemSounds.Hand.Play();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }

        private void btnGithub_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start(UpdateChecker.GitInfo.GithubIssuesLink);
        }

        private void btnExceptionRetry_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Retry;
            this.Dispose();
        }
    }
}
