namespace youtube_dl_gui;

using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

public partial class frmGenericDownloadProgress : LocalizedForm {
    public string URL { get; private set; }
    public string Output { get; private set; }
    private readonly Thread DownloadThread;
    private WebClient DownloadClient;
    private int ThrottleCount;
    private bool Cancelled = false;
    private bool Finished = false;
    public frmGenericDownloadProgress(string URL, string Output) {
        InitializeComponent();
        this.URL = URL;
        this.Output = Output;
        Log.Write($"Using generic downloader to display progress for \"{URL}\".");
        DownloadThread = new(async() => {
            using (DownloadClient = new()) {
                DownloadClient.DownloadProgressChanged += (s, e) => {
                    ThrottleCount++;
                    switch (ThrottleCount % 40) {
                        case 0: {
                            if (DownloadClient.IsBusy && !Cancelled) {
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
                    Finished = true;
                    this.DialogResult = Cancelled ? DialogResult.Cancel : DialogResult.OK;
                };
                DownloadClient.Headers.Add("user-agent", Program.UserAgent);

                bool CanRetry = true;
                do {
                    pbProgress.Invoke(() => {
                        pbProgress.ProgressState = murrty.controls.ProgressState.Normal;
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
                                pbProgress.ProgressState = murrty.controls.ProgressState.Error;
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
            if (!Finished && !Cancelled) {
                Cancelled = true;
                Log.Write("Cancelling download.");
                if (DownloadClient is not null && DownloadClient.IsBusy) {
                    DownloadClient.CancelAsync();
                    e.Cancel = true;
                }
                if (DownloadThread is not null && DownloadThread.IsAlive) {
                    DownloadThread.Abort();
                    e.Cancel = true;
                }
                return;
            }
        };
    }
    public frmGenericDownloadProgress(string URL, string Output, Point? Location) : this(URL, Output) {
        this.Load += (s, e) => {
            if (Location is not null && Location.HasValue && Location.Value.Valid) {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Location.Value;
            }
        };
    }
    public override void LoadLanguage() {
        this.Text = Language.frmGenericDownloadProgress;
    }
}