using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui;
public partial class frmGenericDownloadProgress : Form {
    public string URL { get; private set; }
    public string Output { get; private set; }
    private readonly Thread DownloadThread;
    private WebClient DownloadClient;
    private int ThrottleCount;
    private bool Cancelled = false;
    public frmGenericDownloadProgress(string URL, string Output) {
        InitializeComponent();
        this.Text = Language.frmGenericDownloadProgress;
        this.URL = URL;
        this.Output = Output;
        DownloadThread = new(async() => {
            using (DownloadClient = new()) {
                DownloadClient.DownloadProgressChanged += (s, e) => {
                    ThrottleCount++;
                    switch (ThrottleCount % 40) {
                        case 0: {
                            if (DownloadClient.IsBusy) {
                                pbProgress.BeginInvoke(() => {
                                    pbProgress.Value = e.ProgressPercentage;
                                    pbProgress.Text = $"{e.ProgressPercentage}% ({e.BytesReceived.SizeToString()} / {e.TotalBytesToReceive.SizeToString()})";
                                });
                                ThrottleCount = 0;
                            }
                        } break;
                    }
                };
                DownloadClient.DownloadFileCompleted += (s, e) => {
                    this.DialogResult = Cancelled ? DialogResult.Abort : DialogResult.OK;
                };
                DownloadClient.Headers.Add("user-agent", Program.UserAgent);

                bool CanRetry = true;
                do {
                    pbProgress.Invoke(() => {
                        pbProgress.ProgressState = murrty.controls.ProgressBarState.Normal;
                        pbProgress.Value = 0;
                    });
                    try {
                        await DownloadClient.DownloadFileTaskAsync(URL, Output);
                        CanRetry = false;
                    }
                    catch (ThreadAbortException) { }
                    catch (Exception ex) {
                        if (Cancelled) {
                            CanRetry = false;
                        }
                        else if (Log.ReportRetriableException(ex, URL) != DialogResult.Retry) {
                            CanRetry = false;
                            pbProgress.Invoke(() => {
                                pbProgress.ProgressState = murrty.controls.ProgressBarState.Error;
                                pbProgress.Text = "An error occurred.";
                            });
                            System.Media.SystemSounds.Hand.Play();
                            return;
                        }
                    }
                } while (CanRetry);
            }
        });
        this.Shown += (s, e) => {
            DownloadThread.Start();
        };
        this.FormClosing += (s, e) => {
            Cancelled = true;
            if (DownloadClient is not null && DownloadClient.IsBusy) {
                DownloadClient.CancelAsync();
                e.Cancel = true;
            }
            if (DownloadThread is not null && DownloadThread.IsAlive) {
                DownloadThread.Abort();
                e.Cancel = true;
            }
        };
    }
    public frmGenericDownloadProgress(string URL, string Output, System.Drawing.Point Location) : this(URL, Output) {
        this.Load += (s, e) => {
            if (Config.ValidPoint(Location)) {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Location;
            }
        };
    }
}