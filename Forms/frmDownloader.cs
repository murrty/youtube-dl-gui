using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace youtube_dl_gui {
    public partial class frmDownloader : Form {
        Language lang = Language.GetInstance();

        public string DownloadUrl = null;       // The URL of the download
        public string DownloadPath = null;      // The path of the destination directory
        public string DownloadArguments = null; // The arguments passed for youtube-dl
        public int DownloadType = -1;           // The type of download
        public int DownloadQuality = 0;        // The quality of download

        private Process DownloadProcess = null; // The process of youtube-dl which we'll redirect
        private Thread DownloadThread = null;   // The thread of the process for youtube-dl
        private bool DownloadFinished = false;  // Determines if the download finished successfully
        private bool DownloadAborted = false;   // Determines if the download was aborted
        private bool DownloadErrored = false;   // Determines if the thread resulted in an error

        public frmDownloader() {
            InitializeComponent();
            this.Text = lang.frmDownloader + " ";
            chkDownloaderCloseAfterDownloader.Text = lang.chkDownloaderCloseAfterDownload;
            btnDownloaderCancelExit.Text = lang.btnDownloaderCancel;
            chkDownloaderCloseAfterDownloader.Checked = Downloads.Default.CloseDownloaderAfterFinish;
        }
        private void frmDownloader_Shown(object sender, EventArgs e) { BeginDownload(); }

        private void btnDownloaderCancelExit_Click(object sender, EventArgs e) {
            if (!DownloadFinished && !DownloadAborted && !DownloadErrored) {
                DownloadProcess.Kill();
                DownloadThread.Abort();
            }
            else {
                if (Downloads.Default.CloseDownloaderAfterFinish != chkDownloaderCloseAfterDownloader.Checked) {
                    Downloads.Default.CloseDownloaderAfterFinish = chkDownloaderCloseAfterDownloader.Checked;
                    Downloads.Default.Save();
                }
            }
            this.Dispose();
        }

        private void BeginDownload() {
            if (string.IsNullOrEmpty(DownloadUrl) || string.IsNullOrEmpty(DownloadPath)) {
                MessageBox.Show("The URL or Destination is null or empty. Please enter a URL or Download path.");
                return;
            }

            if (DownloadUrl.StartsWith("http://")) { DownloadUrl = "https" + DownloadUrl.Substring(4); }

            string YoutubeDlFileName = null;
            string ArgumentsBuffer = string.Empty;
            string hlsFF = string.Empty;
            string webFolder = string.Empty;
            bool usehlsFF = Downloads.Default.fixReddit;

            if (General.Default.useStaticYtdl && File.Exists(General.Default.ytdlPath)) {
                YoutubeDlFileName = General.Default.ytdlPath;
            }
            else {
                switch (Verification.ytdlFullCheck()) {
                    case 1:
                        YoutubeDlFileName = Environment.CurrentDirectory + "\\youtube-dl.exe";
                        break;
                    case 2:
                        YoutubeDlFileName = Verification.ytdlPathLocation() + "\\youtube-dl.exe";
                        break;
                    case 3:
                        YoutubeDlFileName = "youtube-dl.exe";
                        break;
                    case 0:
                        YoutubeDlFileName = General.Default.ytdlPath;
                        break;
                    default:
                        MessageBox.Show("Youtube-dl.exe is not present. Please download it from the Settings.");
                        return;
                }
            }

            if (YoutubeDlFileName == null) { return; }

            if (Downloads.Default.separateIntoWebsiteURL) { webFolder = Download.getUrlBase(DownloadUrl) + "\\"; }

            if (DownloadUrl.StartsWith("https://v.redd.it") || DownloadUrl.StartsWith("https://reddit.com/") || DownloadUrl.StartsWith("https://www.reddit.com/") && DownloadType != 2 && usehlsFF) {
                switch (Verification.ffmpegFullCheck()) {
                    case 0:
                        hlsFF = " --ffmpeg-location \"" + General.Default.ffmpegPath + "\\ffmpeg.exe\" --hls-prefer-ffmpeg ";
                        break;
                    case 1:
                        hlsFF = " --ffmpeg-location \"" + Environment.CurrentDirectory + "\\ffmpeg.exe\" --hls-prefer-ffmpeg ";
                        break;
                    case 2:
                        hlsFF = " --ffmpeg-location \"" + Verification.ffmpegPathLocation() + "\\ffmpeg.exe\"  --hls-prefer-ffmpeg ";
                        break;
                }
            }

            switch (DownloadType) {
                case 0: // video
                    if (Downloads.Default.separateDownloads)
                        DownloadPath = " -o \"" + Downloads.Default.downloadPath + "\\" + webFolder + "Video\\" + Downloads.Default.fileNameSchema + "\"";
                    else
                        DownloadPath = " -o \"" + Downloads.Default.downloadPath + "\\" + webFolder + "" + Downloads.Default.fileNameSchema + "\"";

                    if (usehlsFF && Download.isReddit(DownloadUrl))
                        ArgumentsBuffer = DownloadUrl + hlsFF + DownloadPath;
                    else
                        ArgumentsBuffer = DownloadUrl + Download.videoQualities[DownloadQuality] + hlsFF + DownloadPath;

                    if (!string.IsNullOrEmpty(DownloadArguments)) {
                        string[] arguments = DownloadArguments.Split(';');
                        for (int i = 0; i < arguments.Length; i++) {
                            if (arguments[i] == "-nosound" || arguments[i] == "-ns") {
                                ArgumentsBuffer = ArgumentsBuffer.Replace("+bestaudio[ext=m4a]", "");
                            }
                        }
                    }

                    break;
                case 1: // audio
                    if (Downloads.Default.separateDownloads)
                        DownloadPath = " -o \"" + Downloads.Default.downloadPath + "\\" + webFolder + "Audio\\" + Downloads.Default.fileNameSchema + "\"";
                    else
                        DownloadPath = " -o \"" + Downloads.Default.downloadPath + "\\" + webFolder + Downloads.Default.fileNameSchema + "\"";

                    if (usehlsFF && Download.isReddit(DownloadUrl))
                        ArgumentsBuffer = DownloadUrl + hlsFF + DownloadPath;
                    else
                        ArgumentsBuffer = DownloadUrl + Download.audioQualities[DownloadQuality] + hlsFF + DownloadPath;
                    break;
                case 2: // custom
                    if (Downloads.Default.separateDownloads)
                        DownloadPath = " -o \"" + Downloads.Default.downloadPath + "\\" + webFolder + "Custom\\" + Downloads.Default.fileNameSchema + "\"";
                    else
                        DownloadPath = " -o \"" + Downloads.Default.downloadPath + "\\" + webFolder + "\"";

                    ArgumentsBuffer = DownloadUrl + DownloadArguments + DownloadPath;
                    break;
                default:
                    MessageBox.Show("Wow, this is weird. Your download was classified as 'default'. Let me know how this happened, please");
                    return;
            }

            DownloadThread = new Thread(() => {
                try {
                    DownloadProcess = new System.Diagnostics.Process() {
                        StartInfo = new System.Diagnostics.ProcessStartInfo(YoutubeDlFileName) {
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            CreateNoWindow = true,
                            Arguments = ArgumentsBuffer
                        }
                    };

                    DownloadProcess.OutputDataReceived += (s, e) => {
                        this.BeginInvoke(new MethodInvoker(() => {
                            if (e.Data != null)
                                rtbConsoleOutput.AppendText(e.Data + "\n");
                        }));
                    };
                    DownloadProcess.ErrorDataReceived += (s, e) => {
                        this.BeginInvoke(new MethodInvoker(() => {
                            if (e.Data != null) {
                                rtbConsoleOutput.AppendText("Error:\n");
                                rtbConsoleOutput.AppendText(e.Data + "\n");
                            }
                        }));
                    };

                    DownloadProcess.Start();
                    DownloadProcess.BeginOutputReadLine();
                    DownloadProcess.BeginErrorReadLine();
                    DownloadProcess.WaitForExit();

                    DownloadFinished = true;
                }
                catch (ThreadAbortException) {
                    // Thread was aborted
                    DownloadAborted = true;
                    return;
                }
                catch (Exception ex) {
                    ErrorLog.ReportException(ex);
                    DownloadErrored = true;
                }
                finally {
                    DownloadFinishedMethod();
                }
            });
            DownloadThread.Start();
        }

        private void DownloadFinishedMethod() {
            this.BeginInvoke(new MethodInvoker(() => {

                if (DownloadErrored) {
                    tmrTitleActivity.Stop();
                    btnDownloaderCancelExit.Text = lang.btnDownloaderExit;
                    rtbConsoleOutput.AppendText("\nAn error occured");
                }

                else if (chkDownloaderCloseAfterDownloader.Checked || DownloadAborted) { this.Dispose(); }

                else if (DownloadFinished) {
                    tmrTitleActivity.Stop();
                    btnDownloaderCancelExit.Text = lang.btnDownloaderExit;
                    this.Text = lang.frmDownloaderComplete;
                    rtbConsoleOutput.AppendText("Download has finished.");
                }

            }));
        }

        private void tmrTitleActivity_Tick(object sender, EventArgs e) {
            if (this.Text.EndsWith("....")) this.Text = this.Text.TrimEnd('.');
            else this.Text += ".";
        }
    }
}
