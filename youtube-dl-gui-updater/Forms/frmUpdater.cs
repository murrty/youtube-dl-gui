namespace youtube_dl_gui_updater;

using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using murrty.controls;

internal partial class frmUpdater : Form {
    private const int MaxRetries = 5;
    private const int RetryDelay = 1_000;
    private const string ApplicationDownloadUrl = "https://github.com/murrty/{0}/releases/download/{1}/{0}.exe";

    private UpdateData UpdateData;
    private Process ProgramProcess;
    private readonly ApplicationHandles ApplicationData;
    private readonly bool DownloadLatest = false;
    //private bool Received = false;


    private frmUpdater() {
        InitializeComponent();
        LoadLanguage();

        ManagedHttpClient.UpdateSyncContext(SynchronizationContext.Current);
        lbUpdaterVersion.Text = Program.CurrentVersion.ToString();
        pbDownloadProgress.Style = ProgressBarStyle.Marquee;
    }
    public frmUpdater(ApplicationHandles? ApplicationData) : this() {
        if (ApplicationData is null || !ApplicationData.HasValue) {
            DownloadLatest = true;
            pbDownloadProgress.Text = "getting latest version...";
        }
        else {
            this.ApplicationData = ApplicationData.Value;
            ProgramProcess = Process.GetProcessById(this.ApplicationData.ProcessID);
            pbDownloadProgress.Text = "waiting for update data...";
        }
    }
    public frmUpdater(UpdateData? UpdateData) : this() {
        if (UpdateData is null || !UpdateData.HasValue) {
            DownloadLatest = true;
            pbDownloadProgress.Text = "getting latest version...";
        }
        else this.UpdateData = UpdateData.Value;
    }

    protected override void WndProc(ref Message m) {
        switch (m.Msg) {
            case CopyData.WM_COPYDATA: {
                UpdateData = CopyData.GetParam<UpdateData>(m.LParam);
                UpdateData.UpdateHash = UpdateData.UpdateHash.ToLowerInvariant();
                if (!UpdateData.FileName.ToLowerInvariant().EndsWith(".exe"))
                    UpdateData.FileName += ".exe";
                CopyData.SendMessage(ApplicationData.MessageHandle, CopyData.WM_UPDATERREADY, 0, 0);
                //Received = true;
                m.Result = IntPtr.Zero;
            } break;
            default: {
                base.WndProc(ref m);
            } break;
        }
    }

    private async void frmUpdater_Shown(object sender, EventArgs e) {
        await RunUpdate();
    }

    private void LoadLanguage() {
        this.Text = Language.frmUpdater;
        lbUpdaterHeader.Text = Language.lbUpdaterHeader;
        lbUpdaterDetails.Text = Language.lbUpdaterDetails;
        pbDownloadProgress.Text = Language.pbDownloadProgressPreparing;
    }
    private async Task RunUpdate() {
        // Check if the latest version needs to be downloaded.
        if (DownloadLatest)
            await GetVersionFromGithub();

        // Wait for the main application to exit.
        if (ProgramProcess is not null)
            await WaitForApplication();

        // This will be the backup location for the current version.
        string BackupLocation = UpdateData.FileName + ".old";

        // The temp path of the file.
        string UpdateDestination = $"{Environment.CurrentDirectory}\\update.part";

        // The URL that will be downloaded using the client
        string FileUrl = string.Format(ApplicationDownloadUrl, Language.ApplicationName, UpdateData.NewVersion.ToString());

        // Whethre the old and new version have been moved.
        bool MovedOldVersion = false, MovedNewVersion = false;

        try {
            // Delete the old backup, if it exists, since it's clearly unused.
            if (File.Exists(BackupLocation))
                File.Delete(BackupLocation);

            // Add the events.
            Program.DownloadClient.ProgressChanged += DownloadProgressChanged;
            Program.DownloadClient.DownloadComplete += DownloadCompleted;

            // Download the update.
            await GetUpdate(FileUrl, UpdateDestination);

            // Check the file size.
            if (new FileInfo(UpdateDestination).Length <= 512) {
                File.Delete(UpdateDestination);
                tmrForm.Stop();
                this.Text = this.Text.Trim('.');
                pbDownloadProgress.Style = ProgressBarStyle.Blocks;
                pbDownloadProgress.ProgressState = ProgressState.Error;
                pbDownloadProgress.Text = Language.pbDownloadProgressDownloadTooSmall;
                return;
            }

            if (UpdateData.UpdateHash is not null) {
                // Verify the file hash.
                pbDownloadProgress.Text = "calculating new update hash...";
                await VerifyHash(FileUrl, UpdateDestination);
            }
            else {
                pbDownloadProgress.Invoke(() => pbDownloadProgress.Text = Language.pbDownloadProgressSkippingHashCalculating);
            }

            // Move the old file to the backup path.
            if (File.Exists(UpdateData.FileName)) {
                File.Move(UpdateData.FileName, BackupLocation);
                MovedOldVersion = true;
            }

            // Move the new update to the last location.
            File.Move(UpdateDestination, UpdateData.FileName);
            MovedNewVersion = true;

            // Finally, run it.
            pbDownloadProgress.Value = pbDownloadProgress.Maximum;
            pbDownloadProgress.Style = ProgressBarStyle.Blocks;
            pbDownloadProgress.Text = Language.pbDownloadProgressDownloadFinishedLaunching;
            Process.Start(UpdateData.FileName);

            // Kill this process.
            Program.ExitCode = 0;
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
        catch {
            tmrForm.Stop();
            this.Text = this.Text.Trim('.');
            pbDownloadProgress.Style = ProgressBarStyle.Blocks;
            pbDownloadProgress.ProgressState = ProgressState.Error;
            pbDownloadProgress.Text = Language.pbDownloadProgressErrorProcessingDownload;

            if (MovedNewVersion) {
                File.Delete(UpdateData.FileName);
                File.Move(BackupLocation, UpdateData.FileName);
            }
            else if (MovedOldVersion) {
                File.Move(BackupLocation, UpdateData.FileName);
            }
            else if (File.Exists(UpdateDestination)) {
                File.Delete(UpdateDestination);
                pbDownloadProgress.Text = Language.pbDownloadProgressErrorDownloading;
            }
        }
    }
    private async Task GetVersionFromGithub() {
        try {
            UpdateData = await Github.GetUpdateData();
            Process RunningProcess = Process.GetProcessesByName(Language.ApplicationName).FirstOrDefault();
            if (RunningProcess != default)
                ProgramProcess = RunningProcess;
        }
        catch {
            pbDownloadProgress.Text = "could not get latest version.";
        }
    }
    private async Task WaitForApplication() {
        // We are gonna gather the update data from the running process.
        // WM_UPDATEREADY is a non-standard message that tells youtube-dl-gui to send the updater is ready and that it should close.
        // The updater is going to wait for the main program to exit, allowing the user to finish any in-progress downloads.
        CopyData.SendMessage(ApplicationData.MessageHandle, CopyData.WM_UPDATEDATAREQUEST, this.Handle, 0);
        pbDownloadProgress.Text = Language.pbDownloadProgressWaitingForClose;

        //while (!Received)
        //    await Task.Delay(500);

        // Wait for the exit.
        await Task.Run(ProgramProcess.WaitForExit);
    }
    private async Task GetUpdate(string FileUrl, string FileDestination) {
        // The progress bar has a max of 200. Half of it is used for the download progress.
        pbDownloadProgress.Invoke(() => {
            pbDownloadProgress.Style = ProgressBarStyle.Blocks;
            pbDownloadProgress.Value = 50;
        });

        // Delete the previous download part file, if it exists.
        if (File.Exists(FileDestination))
            File.Delete(FileDestination);

        // Set the style to blocks so progress can be reported.
        pbDownloadProgress.Invoke(() => {
            pbDownloadProgress.Style = ProgressBarStyle.Blocks;
            pbDownloadProgress.Text = "0%";
        });

        bool CanRetry;
        int Retries = 0;

        // Going to attempt 5 times to download the update.
        // Additionally allows retrying in case it errors.
        do {
            try {
                // zzz
                await Program.DownloadClient.DownloadFileTaskAsync(new Uri(FileUrl, UriKind.Absolute), FileDestination, Program.CancelToken.Token);
                CanRetry = false;
            }

            // zzz
            catch (Exception ex) {
                while (ex.InnerException is not null)
                    ex = ex.InnerException;

                if (ex is ThreadAbortException or TaskCanceledException or OperationCanceledException)
                    throw ex;

                if (Retries != MaxRetries && (ex is not HttpException hex || (int)hex.StatusCode > 499)) {
                    await Task.Delay(RetryDelay);
                    Retries++;
                    CanRetry = true;
                    continue;
                }

                switch ((DialogResult)this.Invoke(() => Log.ReportException(ex, true, true, this))) {
                    case DialogResult.Abort: throw new OperationCanceledException("Abort requested");
                    case DialogResult.Retry: {
                        CanRetry = true;
                    } break;
                    default: throw;
                }
            }
        } while (CanRetry);

        // zzz
    }
    private async Task VerifyHash(string Url, string FileName) {
        // Simple logic to scan hash and compare it.
        // Not absolutely perfect, but it works well enough.
        pbDownloadProgress.Text = Language.pbDownloadProgressCalculatingHash;
        using SHA256 CNG = SHA256.Create();
        using FileStream UpdateFileStream = File.OpenRead(FileName);

        byte[] Data = await Task.Run(() => CNG.ComputeHash(UpdateFileStream));
        string ReceivedHash = BitConverter.ToString(Data).Replace("-", "").ToLowerInvariant();
        string ExpectedHash = UpdateData.UpdateHash.ToLowerInvariant();

        if (ReceivedHash != ExpectedHash) {
            pbDownloadProgress.Invoke(() => {
                pbDownloadProgress.Text = Language.pbDownloadProgressHashNoMatch;
                pbDownloadProgress.ProgressState = ProgressState.Paused;
            });

            switch ((DialogResult)this.Invoke(() => MessageBox.Show(this, string.Format(Language.dlgUpdaterUpdatedVersionHashNoMatch, ExpectedHash, ReceivedHash), Language.ApplicationName, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning))) {
                case DialogResult.Abort:
                    throw new CryptographicException("The known hash of the file does not match the hash caluclated by the updater.");

                case DialogResult.Retry: {
                    File.Delete(FileName);
                    this.Invoke(() => {
                        tmrForm.Start();
                        pbDownloadProgress.Value = 50;
                        pbDownloadProgress.ProgressState = ProgressState.Normal;
                    });
                    await GetUpdate(Url, FileName);
                } return;

                case DialogResult.Ignore: {
                    pbDownloadProgress.Invoke(() => pbDownloadProgress.ProgressState = ProgressState.Normal);
                } break;
            }
        }
    }

    private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
        this.Invoke(() => {
            pbDownloadProgress.Value = (int)e.Percentage + 50;
            pbDownloadProgress.Text = e.Percentage.ToString();
        });
    }
    private void DownloadCompleted(object sender, DownloadFinishedEventArgs e) {
        pbDownloadProgress.Invoke(() => pbDownloadProgress.Text = "100%");
    }
    private void tmrForm_Tick(object sender, EventArgs e) {
        // This really is just for appearance.
        this.Text = this.Text.EndsWith("...") ? this.Text.Trim('.') : this.Text + ".";
    }
}