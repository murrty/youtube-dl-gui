#nullable enable
namespace youtube_dl_gui;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
public partial class frmExtendedDownloader : LocalizedProcessingForm {
    private bool Debug { get; }
    public bool BatchDownload { get; }
    private bool SwitchingQueuedItem { get; set; }
    private bool FailedInfoRetrieval { get; set; }

    private Thread? ProcessingThread { get; set; }
    private Process? DownloadProcess { get; set; }
    private ExtendedMediaDetails? MediaDetails { get; set; }
    private List<ExtendedMediaDetails>? QueueList { get; }
    private DownloadStatus Status { get; set; } = DownloadStatus.None;

    private bool ClipboardScannerActive;    // Whether the clipboard scanner is active.
    private string? ClipboardData;          // Clipboard data buffer.

    public frmExtendedDownloader() : this (true) { }
    private frmExtendedDownloader(bool BatchDownload) {
        this.BatchDownload = BatchDownload;

        InitializeComponent();
        LoadLanguage();

        if (!Program.DebugMode) {
            tcVideoData.TabPages.Remove(tabDebug);
        }

        cbVideoRemux.Items.Add(Language.GenericDoNotRemux);
        cbVideoRemux.Items.AddRange(Formats.ExtendedVideoFormats);
        cbVideoRemux.SelectedIndex = 0;

        cbVideoEncoders.Items.Add(Language.GenericDoNotReEncode);
        cbVideoEncoders.Items.AddRange(Formats.ExtendedVideoFormats);
        cbVideoEncoders.SelectedIndex = 0;

        cbAudioEncoders.Items.Add(Language.GenericDoNotReEncode);
        cbAudioEncoders.Items.AddRange(Formats.ExtendedAudioFormats);
        cbAudioEncoders.SelectedIndex = 0;

        cbVbrQualities.Items.AddRange(Formats.VbrQualities);
        cbVbrQualities.SelectedIndex = 0;

        if (!string.IsNullOrEmpty(Saved.FileNameSchemaHistory)) {
            cbSchema.Items.AddRange(Saved.FileNameSchemaHistory.Split('|'));
        }

        int SchemaIndex = cbSchema.Items.IndexOf(Downloads.fileNameSchema);
        if (SchemaIndex > -1) {
            cbSchema.SelectedIndex = SchemaIndex;
        }
        else {
            cbSchema.Text = Downloads.fileNameSchema;
        }

        lvVideoFormats.SmallImageList = Program.ExtendedDownloaderSelectedImages;
        lvAudioFormats.SmallImageList = Program.ExtendedDownloaderSelectedImages;
        lvUnknownFormats.SmallImageList = Program.ExtendedDownloaderSelectedImages;

        if (BatchDownload) {
            this.BatchDownload = true;
            pnSingleDownload.Enabled = pnSingleDownload.Visible = false;
            lvQueuedMedia.ContextMenu = cmQueuedMedia;
            lvQueuedMedia.SmallImageList = Program.BatchStatusImages;
            pnSingleDownload.Dispose();
            QueueList = new();
        }
        else {
            pnBatchDownload.Dispose();
            cmEnqueue.Dispose();
            cmQueuedMedia.Dispose();
        }
    }
    public frmExtendedDownloader(string URL, bool Archived) : this(false) {
        MediaDetails = new(URL) {
            Archived = Archived
        };

        llbLink.Text = (Archived ? URL.Split(':')[1] : URL);
    }
    public frmExtendedDownloader(string URL, string? CustomArguments, bool Archived) : this(URL, Archived) {
        txtCustomArguments.Text = CustomArguments.IsNullEmptyWhitespace() ? string.Empty : CustomArguments;
        pnBatchDownload.Enabled = pnBatchDownload.Visible = false;
    }
    public frmExtendedDownloader(string URL, string? CustomArguments, bool Archived, AuthenticationDetails? Auth) : this(URL, CustomArguments, Archived) {
        MediaDetails!.Authentication = Auth;
    }

    public override void LoadLanguage() {
        if (BatchDownload) {
            this.Text = Language.frmBatchDownload;
            if (lvQueuedMedia.SelectedItems.Count > 0 && MediaDetails is not null) {
                txtExtendedDownloaderMediaTitle.Text = MediaDetails.InfoRetrieved ? MediaDetails.MediaName : Language.txtExtendedDownloaderMediaTitle;
                txtExtendedDownloaderMediaTitle.Enabled = true;
            }
            else {
                txtExtendedDownloaderMediaTitle.Text = Language.txtExtendedDownloaderBatchMediaTitle;
                txtExtendedDownloaderMediaTitle.Enabled = false;
            }

            btnEnqueue.Text = Language.GenericAdd;
            mEnqueue.Text = Language.GenericAdd;
            mEnqueueCopyOptions.Text = Language.mExtendedDownloaderEnqueueCopyOptions;
            mEnqueueWithAuthentication.Text = Language.mExtendedDownloaderEnqueueWithAuthentication;
            mEnqueueCopyAuthentication.Text = Language.mExtendedDownloaderEnqueueCopyAuthentication;

            mEnqueueImportLinksFromClipboard.Text = Language.mBatchDownloaderImportLinksFromClipboard;
            mEnqueueClipboardLinks.Text = Language.mBatchDownloaderImportLinksFromClipboard;
            mEnqueueClipboardLinksWithAuthentication.Text = Language.mExtendedDownloaderEnqueueImportLinksWithAuthentication;
            mEnqueueClipboardLinksCopyOptions.Text = Language.mExtendedDownloaderEnqueueImportLinksCopyOptions;
            mEnqueueClipboardLinksCopyAuthentication.Text = Language.mExtendedDownloaderEnqueueImportLinksCopyAuthentication;
            mEnqueueImportLinksFromFile.Text = Language.mBatchDownloaderImportLinksFromFile;
            mEnqueueFileLinks.Text = Language.mBatchDownloaderImportLinksFromFile;
            mEnqueueFileLinksWithAuthentication.Text = Language.mExtendedDownloaderEnqueueImportLinksWithAuthentication;
            mEnqueueFileLinksCopyOptions.Text = Language.mExtendedDownloaderEnqueueImportLinksCopyOptions;
            mEnqueueFileLinksCopyAuthentication.Text = Language.mExtendedDownloaderEnqueueImportLinksCopyAuthentication;

            mEnqueueClipboardScanner.Text = Language.chkBatchDownloadClipboardScanner;
            mEnqueueClipboardScannerVerifyLinks.Text = Language.GenericVerifyLinks;

            mQueueCopyLink.Text = Language.mExtendedDownloaderQueueCopyLink;
            mQueueViewInBrowser.Text = Language.mExtendedDownloaderQueueViewInBrowser;
            mQueueRemove.Text = Language.GenericRemoveSelected;
        }
        else {
            if (MediaDetails?.InfoRetrieved == true) {
                this.Text = MediaDetails.ProgressMediaName;
                txtExtendedDownloaderMediaTitle.Text = MediaDetails.MediaName;
            }
            else {
                this.Text = Language.frmExtendedDownloaderRetrieving.Format(Language.ApplicationName);
                txtExtendedDownloaderMediaTitle.Text = Language.txtExtendedDownloaderMediaTitle;
            }

            lbExtendedDownloaderUploader.Text = Language.lbExtendedDownloaderUploader;
            lbExtendedDownloaderViews.Text = Language.lbExtendedDownloaderViews;
            btnExtendedDownloaderDownloadThumbnail.Text = Language.btnExtendedDownloaderDownloadThumbnail;
        }

        switch (Status) {
            case DownloadStatus.Aborted: {
                pbStatus.Text = Language.GenericAborted;
                sbtnDownload.Text = Language.GenericRetry;
            } break;
            case DownloadStatus.YtdlError: {
                pbStatus.Text = Language.GenericError.Format("youtube-dl");
                sbtnDownload.Text = Language.GenericRetry;
            } break;
            case DownloadStatus.ProgramError: {
                pbStatus.Text = Language.GenericError;
                sbtnDownload.Text = Language.GenericRetry;
            } break;
            case DownloadStatus.AbortForClose: {
                sbtnDownload.Text = Language.GenericRetry;
            } break;
            case DownloadStatus.Preparing: {
                pbStatus.Text = Language.dlBeginningDownload;
                sbtnDownload.Text = Language.GenericCancel;
            } break;
            case DownloadStatus.Downloading: {
                sbtnDownload.Text = Language.GenericCancel;
            } break;
            case DownloadStatus.MergingFiles: {
                pbStatus.Text = Language.pbDownloadProgressMergingFormats;
                sbtnDownload.Text = Language.GenericCancel;
            } break;
            case DownloadStatus.Converting: {
                pbStatus.Text = Language.pbDownloadProgressConverting;
                sbtnDownload.Text = Language.GenericCancel;
            } break;
            case DownloadStatus.FfmpegPostProcessing: {
                pbStatus.Text = Language.pbDownloadProgressFfmpegPostProcessing;
                sbtnDownload.Text = Language.GenericCancel;
            } break;
            case DownloadStatus.EmbeddingSubtitles: {
                pbStatus.Text = Language.pbDownloadProgressEmbeddingSubtitles;
                sbtnDownload.Text = Language.GenericCancel;
            } break;
            case DownloadStatus.EmbeddingMetadata: {
                Status = DownloadStatus.EmbeddingMetadata;
                sbtnDownload.Text = Language.GenericCancel;
            } break;
            case DownloadStatus.Finished: {
                pbStatus.Text = Language.GenericCompleted;
                sbtnDownload.Text = Language.sbDownload;
            } break;
            default: {
                pbStatus.Text = ".  .  .";
                sbtnDownload.Text = Language.sbDownload;
            } break;
        }

        rbVideo.Text = Language.GenericVideo;
        rbAudio.Text = Language.GenericAudio;
        rbUnknown.Text = Language.GenericUnknownFormat;
        rbCustom.Text = Language.GenericCustom;

        tabExtendedDownloaderFormats.Text = Language.lbFormat;
        tabExtendedDownloaderDescription.Text = Language.tabExtendedDownloaderDescription;
        tabExtendedDownloaderVerbose.Text = Language.tabExtendedDownloaderVerbose;
        tabExtendedDownloaderVideoFormats.Text = Language.GenericVideo;
        lbExtendedDownloaderNoVideoFormatsAvailable.Text = Language.lbExtendedDownloaderNoVideoFormatsAvailable;
        tabExtendedDownloaderAudioFormats.Text = Language.GenericAudio;
        lbExtendedDownloaderNoAudioFormatsAvailable.Text = Language.lbExtendedDownloaderNoAudioFormatsAvailable;
        tabExtendedDownloaderUnknownFormats.Text = Language.tabExtendedDownloaderUnknownFormats;
        lbExtendedDownloaderNoUnknownFormatsFound.Text = Language.lbExtendedDownloaderNoUnknownFormatsFound;
        tabExtendedDownloaderFormatOptions.Text = Language.tabExtendedDownloaderFormatOptions;
        tabExtendedDownloaderCustom.Text = Language.GenericCustom;

        lbSchema.Text = Language.lbSettingsDownloadsFileNameSchema;
        lbVideoEncoder.Text = Language.GenericVideo;
        lbVideoRemux.Text = Language.lbVideoRemux;
        lbAudioEncoder.Text = Language.GenericAudio;
        chkVideoSeparateAudio.Text = Language.chkExtendedDownloaderVideoSeparateAudio;
        chkVideoDownloadAudio.Text = Language.GenericSound;
        chkDownloaderCloseAfterDownload.Text = Language.chkDownloaderCloseAfterDownload;
        lbFragmentThreads.Text = Language.lbSettingsDownloadsFragmentThreads;
        chkSkipUnavailableFragments.Text = Language.chkSettingsDownloadsSkipUnavailableFragments;
        chkAbortOnError.Text = Language.chkSettingsDownloadsAbortOnError;

        btnClearOutput.Text = Language.GenericClear;

        mDownload.Text = Language.sbDownload;
        mDownloadWithAuthentication.Text = Language.mDownloadWithAuthentication;

        // lvVideoFormats
        chVideoQuality.Text = Language.chVideoQuality;
        chVideoFPS.Text = Language.chVideoFPS;
        chVideoContainer.Text = Language.chContainer;
        chVideoFileSize.Text = Language.chFileSize;
        chVideoBitrate.Text = Language.chVideoBitrate;
        chVideoDimension.Text = Language.chVideoDimension;
        chVideoCodec.Text = Language.chVideoCodec;
        chVideoAudioBitrate.Text = Language.chAudioBitrate;
        chVideoAudioSampleRate.Text = Language.chAudioSampleRate;
        chVideoAudioCodec.Text = Language.chAudioCodec;
        chVideoAudioChannels.Text = Language.chAudioChannels;
        chVideoFormatId.Text = Language.chFormatId;

        // lvAudioFormats
        chAudioBitrate.Text = Language.chAudioBitrate;
        chAudioContainer.Text = Language.chContainer;
        chAudioFileSize.Text = Language.chFileSize;
        chAudioSampleRate.Text = Language.chAudioSampleRate;
        chAudioCodec.Text = Language.chAudioCodec;
        chAudioChannels.Text = Language.chAudioChannels;
        chAudioFormatId.Text = Language.chFormatId;

        // lvUnknownFormats
        chUnknownQuality.Text = Language.chVideoQuality;
        chUnknownFPS.Text = Language.chVideoFPS;
        chUnknownContainer.Text = Language.chContainer;
        chUnknownFileSize.Text = Language.chFileSize;
        chUnknownVideoBitrate.Text = Language.chVideoBitrate;
        chUnknownDimensions.Text = Language.chVideoDimension;
        chUnknownVideoCodec.Text = Language.chVideoCodec;
        chUnknownAudioBitrate.Text = Language.chAudioBitrate;
        chUnknownAudioSampleRate.Text = Language.chAudioSampleRate;
        chUnknownAudioCodec.Text = Language.chAudioCodec;
        chUnknownAudioChannels.Text = Language.chAudioChannels;
        chUnknownFormatId.Text = Language.chFormatId;

        if (this.IsHandleCreated) {
            cbVideoRemux.Items[0] = Language.GenericDoNotRemux;
            cbVideoEncoders.Items[0] = Language.GenericDoNotReEncode;
            cbAudioEncoders.Items[0] = Language.GenericDoNotReEncode;
        }
    }
    private void frmExtendedDownloader_Load(object sender, EventArgs e) {
        if (Saved.ExtendedDownloaderLocation.Valid) {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Saved.ExtendedDownloaderLocation;
        }
        if (Saved.ExtendedDownloaderSize.Valid) {
            this.Size = Saved.ExtendedDownloaderSize;
        }
        if (!Saved.ExtendedDownloaderVideoColumns.IsNullEmptyWhitespace()) {
            lvVideoFormats.SetColumnWidths(Saved.ExtendedDownloaderVideoColumns);
        }
        if (!Saved.ExtendedDownloaderAudioColumns.IsNullEmptyWhitespace()) {
            lvAudioFormats.SetColumnWidths(Saved.ExtendedDownloaderAudioColumns);
        }
        if (!Saved.ExtendedDownloaderUnknownColumns.IsNullEmptyWhitespace()) {
            lvUnknownFormats.SetColumnWidths(Saved.ExtendedDownloaderUnknownColumns);
        }

        if (CustomArguments.YtdlArguments.Count > 0) {
            CustomArguments.YtdlArguments.For((Arg) => cbCustomArguments.Items.Add(Arg));
        }

        chkDownloaderCloseAfterDownload.Checked = Downloads.CloseExtendedDownloaderAfterFinish;
        llbLink.MaximumSize = new(this.Width - 30, llbLink.Height);
    }
    private void frmExtendedDownloader_Shown(object sender, EventArgs e) {
        if (!BatchDownload) {
            DownloadInfo();
            lbExtendedDownloaderUploader.Focus();
        }
        else {
            txtQueueLink.Focus();
        }
    }
    private void frmExtendedDownloader_SizeChanged(object sender, EventArgs e) {
        llbLink.MaximumSize = new(this.Width - 32, llbLink.Height);
    }
    private void frmExtendedDownloader_FormClosing(object sender, FormClosingEventArgs e) {
        switch (Status) {
            case DownloadStatus.Downloading: {
                Status = DownloadStatus.Aborted;
                e.Cancel = true;
            } break;
            default: {
                if (ProcessingThread?.IsAlive == true) {
                    ProcessingThread.Abort();
                }

                Downloads.CloseExtendedDownloaderAfterFinish = chkDownloaderCloseAfterDownload.Checked;
                Saved.ExtendedDownloaderLocation = this.Location;
                Saved.ExtendedDownloaderSize = this.Size;
                Saved.ExtendedDownloaderVideoColumns = lvVideoFormats.GetColumnWidths();
                Saved.ExtendedDownloaderAudioColumns = lvAudioFormats.GetColumnWidths();
                Saved.ExtendedDownloaderUnknownColumns = lvUnknownFormats.GetColumnWidths();

                if (BatchDownload) {
                    if (lvQueuedMedia.Items.Count > 0) {
                        for (int i = 0; i < lvQueuedMedia.Items.Count; i++) {
                            (lvQueuedMedia.Items[i].Tag as ExtendedMediaDetails)?.Dispose();
                        }
                    }
                }
                else {
                    MediaDetails?.Dispose();
                }

                this.Dispose();
            } break;
        }
    }

    [DebuggerStepThrough]
    protected override void WndProc(ref Message m) {
        switch (m.Msg) {
            case NativeMethods.WM_CLIPBOARDUPDATE: {
                if (Clipboard.ContainsText()) {
                    ClipboardData = Clipboard.GetText();
                    if (!mEnqueueClipboardScannerVerifyLinks.Checked || DownloadHelper.SupportedDownloadLink(ClipboardData)) {
                        QueueNewItem(ClipboardData, false, false, false, MediaDetails);
                    }
                    ClipboardData = null;
                }
            } break;
        }
        base.WndProc(ref m);
    }
    protected internal void ApplicationExit(object sender, EventArgs e) {
        if (ClipboardScannerActive && NativeMethods.RemoveClipboardFormatListener(this.Handle)) {
            ClipboardScannerActive = false;
        }
    }

    private void DownloadInfo() {
        if (MediaDetails is null) {
            return;
        }

        ProcessingThread = new(() => {
            try {
                if (MediaDetails.URL.IsNullEmptyWhitespace()) {
                    throw new DownloadException(MediaDetails.URL, "The media you are trying to access was not entered in correctly.");
                }

                MediaDetails.GetMediaDetails();
                this.Invoke(() => SelectedMediaChanged(MediaDetails));
            }
            catch (ThreadAbortException) { }
            catch (DownloadException dex) {
                this.Invoke(() => {
                    sbtnDownload.Enabled = true;
                    sbtnDownload.Text = Language.GenericRetry;
                    txtExtendedDownloaderMediaTitle.Text = "Failed to retrieve download info";
                    rtbVerbose.AppendText(dex.Message);
                });
                FailedInfoRetrieval = true;
            }
            catch (Exception ex) {
                this.Invoke(() => Log.ReportException(ex));
            }
        }) {
            Name = $"InfoThread {MediaDetails.URL}",
            IsBackground = true,
            Priority = ThreadPriority.BelowNormal
        };

        rtbVerbose.AppendLine(Verification.GetYoutubeDlProvider(false) + " as the download provider.");
        ProcessingThread.Start();
    }
    private void ProcessThumbnail() {
        if (MediaDetails is null) {
            return;
        }

        try {
            Image? Thumb = MediaDetails.DownloadThumbnail();
            if (Thumb is null) {
                this.Invoke(() => {
                    btnExtendedDownloaderDownloadThumbnail.Enabled = btnExtendedDownloaderDownloadThumbnail.Visible = true;
                    lbExtendedDownloaderDownloadingThumbnail.Text = Language.lbExtendedDownloaderDownloadingThumbnailFailed;
                });
                return;
            }

            this.Invoke(() => {
                pbThumbnail.Image = Thumb;
                lbExtendedDownloaderDownloadingThumbnail.Visible = false;
                btnExtendedDownloaderDownloadThumbnail.Enabled = btnExtendedDownloaderDownloadThumbnail.Visible = false;
            });
        }
        catch (ThreadAbortException) { throw; }
        catch (Exception) {
            this.Invoke(() => {
                btnExtendedDownloaderDownloadThumbnail.Enabled = btnExtendedDownloaderDownloadThumbnail.Visible = true;
                lbExtendedDownloaderDownloadingThumbnail.Text = Language.lbExtendedDownloaderDownloadingThumbnailFailed;
            });
            throw;
        }
    }
    private void DownloadThumbnail() {
        if (ProcessingThread?.IsAlive != true && MediaDetails is not null) {
            ProcessingThread = new(ProcessThumbnail) {
                Name = $"ThumbThread {MediaDetails.URL}",
                IsBackground = true,
                Priority = ThreadPriority.BelowNormal
            };
            lbExtendedDownloaderDownloadingThumbnail.Visible = true;
            btnExtendedDownloaderDownloadThumbnail.Enabled = btnExtendedDownloaderDownloadThumbnail.Visible = false;
            lbExtendedDownloaderDownloadingThumbnail.Text = Language.lbExtendedDownloaderDownloadingThumbnail;
            ProcessingThread.Start();
        }
    }

    private void BeginDownload(bool Auth) {
        if (BatchDownload) {
            BeginBatchDownload();
            return;
        }

        if (MediaDetails is null) {
            return;
        }

        rtbVerbose.Invoke(() => rtbVerbose.AppendLine($"Starting download @ {DateTime.Now:yyyy-MM-dd HH:mm:ss.fffffff} \r\n------------------------"));

        if (!Verification.YoutubeDlAvailable) {
            Verification.RefreshYoutubeDlLocation();
            if (!Verification.YoutubeDlAvailable) {
                throw new NullReferenceException("Youtube-dl path is invalid and cannot be used.");
            }
        }

        if (Auth && !MediaDetails.Authenticate()) {
            rtbVerbose.Invoke(() => rtbVerbose.AppendLine("Authentication was not provided; cancelling."));
            return;
        }

        if (Verification.YtDlpProgressProblem) {
            rtbVerbose.AppendLine("""
            WARNING: Progress MAY not be made using yt-dlp on Windows 7 (and below) with limiting downloads enabled.
            youtube-dl-gui is NOT the cause of this issue, it lies on yt-dlp to implement a fix for.
            """);
        }

        SaveMediaOptions();

        if (!MediaDetails.GenerateArguments()) {
            return;
        }

        txtGeneratedArguments.Text = MediaDetails.ArgumentsCensored;
        mDownload.Enabled = mDownloadWithAuthentication.Enabled = false;
        sbtnDownload.Text = Language.GenericCancel;
        pbStatus.ShowInTaskbar = true;
        pbStatus.Value = 0;
        pbStatus.ProgressState = murrty.controls.ProgressState.Normal;
        pbStatus.Text = "Beginning download";
        ProcessingThread = new(() => {
            Status = DownloadStatus.Downloading;
            string? Msg = null;
            int MsgIndex = -1;

            DownloadProcess = new() {
                StartInfo = new(Verification.YoutubeDlPath) {
                    Arguments = MediaDetails.Arguments,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                }
            };
            DownloadProcess.OutputDataReceived += (s, e) => {
                if (e.Data?.Length > 0) {
                    switch (e.Data[..8].ToLowerInvariant()) {
                        case "[downloa": case "[ffmpeg]":
                        case "[embedsu": case "[metadat": {
                            Msg = e.Data;
                        } break;

                        default: {
                            Msg = e.Data.ToLowerInvariant();
                            if ((MsgIndex = Msg.IndexOf(']')) > -1) {
                                switch (Msg[..(MsgIndex + 1)]) {
                                    case "[merger]": {
                                        Status = DownloadStatus.MergingFiles;
                                        pbStatus.Invoke(() => {
                                            pbStatus.Style = ProgressBarStyle.Marquee;
                                            pbStatus.Value = pbStatus.Maximum;
                                            pbStatus.Text = Language.pbDownloadProgressMergingFormats;
                                        });
                                    } break;
                                    case "[videoconvertor]": {
                                        Status = DownloadStatus.Converting;
                                        pbStatus.Invoke(() => {
                                            pbStatus.Style = ProgressBarStyle.Marquee;
                                            pbStatus.Value = pbStatus.Maximum;
                                            pbStatus.Text = Language.pbDownloadProgressConverting;
                                        });
                                    } break;
                                    case "[extractaudio]": {
                                        Status = DownloadStatus.ExtractingAudio;
                                        pbStatus.Invoke(() => {
                                            pbStatus.Style = ProgressBarStyle.Marquee;
                                            pbStatus.Value = pbStatus.Maximum;
                                            pbStatus.Text = Language.pbDownloadProgressExtractingAudio;
                                        });
                                    } break;
                                }
                            }
                            else {
                                if (pbStatus.Style != ProgressBarStyle.Blocks) {
                                    pbStatus.Invoke(() => pbStatus.Style = ProgressBarStyle.Blocks);
                                }
                                if (pbStatus.Text != ".  .  .") {
                                    pbStatus.Invoke(() => pbStatus.Text = ".  .  .");
                                }
                                if (pbStatus.Value != 0) {
                                    pbStatus.Invoke(() => pbStatus.Value = 0);
                                }
                            }
                            Msg = null;
                            rtbVerbose.Invoke(() => rtbVerbose.AppendLine(e.Data));
                        } break;
                    }
                }
            };
            DownloadProcess.ErrorDataReceived += (s, e) => {
                if (e.Data?.Length > 0) {
                    rtbVerbose.Invoke(() => rtbVerbose.AppendLine(e.Data.Trim()));
                }
            };
            DownloadProcess.Start();
            DownloadProcess.BeginOutputReadLine();
            DownloadProcess.BeginErrorReadLine();

            float Percentage = 0;
            string ETA = "Unknown";

            while (!DownloadProcess.HasExited) {
                if (Status == DownloadStatus.Aborted || Status == DownloadStatus.AbortForClose) {
                    if (!DownloadProcess.HasExited) {
                        Program.KillProcessTree((uint)DownloadProcess.Id);
                        DownloadProcess.Kill();
                    }
                    break;
                }

                if (Msg is not null) {
                    string Line = Msg.ReplaceWhitespace();
                    string[] LineParts = Line.Split(' ');
                    switch (Line[..5].ToLowerInvariant()) {
                        case "[down": {
                            Status = DownloadStatus.Downloading;
                            switch (LineParts[1][0]) {
                                case '1': case '2': case '3':
                                case '4': case '5': case '6':
                                case '7': case '8': case '9':
                                case '0': {
                                    if (!LineParts[1].Contains('%') || !this.IsHandleCreated) {
                                        break;
                                    }

                                    if (pbStatus.Style != ProgressBarStyle.Blocks) {
                                        pbStatus.Invoke(() => pbStatus.Style = ProgressBarStyle.Blocks);
                                    }

                                    this.Invoke(() => {
                                        pbStatus.Text = DownloadHelper.GetTransferData(
                                            LineParts: LineParts,
                                            Percentage: ref Percentage,
                                            Eta: ref ETA);

                                        pbStatus.Value = (int)Math.Floor(Percentage);

                                        this.Text = $"ETA: {ETA} - {MediaDetails.ProgressMediaName}";
                                    });
                                } break;
                            }
                        } break;
                        case "[ffmp": {
                            Status = DownloadStatus.FfmpegPostProcessing;
                            rtbVerbose.Invoke(() => rtbVerbose.AppendLine(Line));
                            pbStatus.Invoke(() => {
                                pbStatus.Style = ProgressBarStyle.Marquee;
                                pbStatus.Text = Language.pbDownloadProgressFfmpegPostProcessing;
                                pbStatus.Value = 100;
                            });
                            Msg = null;
                        } break;
                        case "[embe": {
                            Status = DownloadStatus.EmbeddingSubtitles;
                            rtbVerbose.Invoke(() => rtbVerbose.AppendLine(Line));
                            pbStatus.Invoke(() => {
                                pbStatus.Style = ProgressBarStyle.Marquee;
                                pbStatus.Text = Language.pbDownloadProgressEmbeddingSubtitles;
                                pbStatus.Value = 100;
                            });
                            Msg = null;
                        } break;
                        case "[meta": {
                            Status = DownloadStatus.EmbeddingMetadata;
                            rtbVerbose.Invoke(() => rtbVerbose.AppendLine(Line));
                            pbStatus.Invoke(() => {
                                pbStatus.Style = ProgressBarStyle.Marquee;
                                pbStatus.Text = Language.pbDownloadProgressEmbeddingMetadata;
                                pbStatus.Value = 100;
                            });
                            Msg = null;
                        } break;
                    }
                }

                Thread.Sleep(250);
            }

            if (Status != DownloadStatus.Aborted && Status != DownloadStatus.AbortForClose) {
                Status = DownloadProcess.ExitCode == 0 ? DownloadStatus.Finished : DownloadStatus.YtdlError;
            }

            this.Invoke(() => {
                if (chkDownloaderCloseAfterDownload.Checked && Status == DownloadStatus.Finished) {
                    this.Close();
                    return;
                }

                pbStatus.Style = ProgressBarStyle.Continuous;
                pbStatus.ShowInTaskbar = false;
                mDownload.Enabled = mDownloadWithAuthentication.Enabled = true;
                this.Text = MediaDetails.MediaName;
                switch (Status) {
                    case DownloadStatus.Aborted: {
                        rtbVerbose.AppendLine("Aborted download");
                        pbStatus.Text = Language.GenericAborted;
                        pbStatus.Value = pbStatus.Minimum;
                        sbtnDownload.Text = Language.GenericRetry;
                        System.Media.SystemSounds.Exclamation.Play();
                    } break;
                    case DownloadStatus.Finished: {
                        rtbVerbose.AppendLine("Download completed");
                        pbStatus.Text = Language.GenericCompleted;
                        pbStatus.Value = pbStatus.Maximum;
                        sbtnDownload.Text = Language.sbDownload;
                        System.Media.SystemSounds.Asterisk.Play();
                    } break;
                    case DownloadStatus.AbortForClose: { } break;
                    default: {
                        rtbVerbose.AppendLine("Download error");
                        pbStatus.Text = Status == DownloadStatus.YtdlError ? Language.GenericAltError.Format("youtube-dl") : Language.GenericError;
                        pbStatus.Value = pbStatus.Minimum;
                        sbtnDownload.Text = Language.GenericRetry;
                        tcVideoData.SelectedTab = tabExtendedDownloaderVerbose;
                        System.Media.SystemSounds.Hand.Play();
                    } break;
                }
            });
        }) {
            Name = $"Download {MediaDetails.URL}",
            IsBackground = true,
            Priority = ThreadPriority.BelowNormal
        };
        ProcessingThread.Start();
    }
    private void BeginBatchDownload() {
        if (lvQueuedMedia.Items.Count < 1) {
            return;
        }

        rtbVerbose.Invoke(() => rtbVerbose.AppendLine($"Starting batch download @ {DateTime.Now:yyyy-MM-dd HH:mm:ss.fffffff} \r\n------------------------"));

        if (!Verification.YoutubeDlAvailable) {
            Verification.RefreshYoutubeDlLocation();
            if (!Verification.YoutubeDlAvailable) {
                throw new NullReferenceException("Youtube-dl path is invalid and cannot be used.");
            }
        }

        if (Verification.YtDlpProgressProblem) {
            rtbVerbose.AppendLine("""
                WARNING: Progress MAY not be made using yt-dlp on Windows 7 (and below) with limiting downloads enabled.
                youtube-dl-gui is NOT the cause of this issue, it lies on yt-dlp to implement a fix for.
                """);
        }

        SaveMediaOptions();

        mDownload.Enabled = mDownloadWithAuthentication.Enabled = false;
        sbtnDownload.Text = Language.GenericCancel;
        pbStatus.ShowInTaskbar = true;
        pbStatus.Value = 0;
        pbStatus.ProgressState = murrty.controls.ProgressState.Normal;
        pbStatus.Text = "Beginning download";
        Status = DownloadStatus.Downloading;

        ProcessingThread = new(() => {
            string? args = null;
            string? Msg = null;
            float Percentage = 0;
            string ETA = "Unknown";
            ExtendedMediaDetails MediaDetails;
            string BatchTime = BatchHelper.CurrentTime;

            for (int i = 0; i < lvQueuedMedia.Items.Count; i++) {
                if ((bool)lvQueuedMedia.Invoke(() => lvQueuedMedia.Items[i].Tag is not ExtendedMediaDetails)) {
                    lvQueuedMedia.Invoke(() => lvQueuedMedia.Items[i].ImageIndex = StatusIcon.Errored);
                    continue;
                }
                else {
                    MediaDetails = (ExtendedMediaDetails)lvQueuedMedia.Invoke(() => lvQueuedMedia.Items[i].Tag);
                }

                lvQueuedMedia.Invoke(() => lvQueuedMedia.Items[i].ImageIndex = StatusIcon.Processing);

                MediaDetails.BatchDownloadTime = BatchTime;
                args = MediaDetails.Arguments;

                DownloadProcess = new() {
                    StartInfo = new(Verification.YoutubeDlPath) {
                        Arguments = args,
                        CreateNoWindow = true,
                        RedirectStandardError = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        WindowStyle = ProcessWindowStyle.Hidden,
                    }
                };
                DownloadProcess.OutputDataReceived += (s, e) => {
                    if (e.Data?.Length > 0) {
                        switch (e.Data[..8].ToLower()) {
                            case "[downloa": case "[ffmpeg]":
                            case "[embedsu": case "[metadat": {
                                Msg = e.Data;
                            } break;

                            default: {
                                Msg = e.Data.ToLower();
                                if (Msg.StartsWith("[merger]")) {
                                    pbStatus.Invoke(() => {
                                        pbStatus.Style = ProgressBarStyle.Marquee;
                                        pbStatus.Value = pbStatus.Maximum;
                                        pbStatus.Text = Language.pbDownloadProgressMergingFormats;
                                    });
                                }
                                else if (Msg.StartsWith("[videoconvertor]")) { // Converter?
                                    pbStatus.Invoke(() => {
                                        pbStatus.Style = ProgressBarStyle.Marquee;
                                        pbStatus.Value = pbStatus.Maximum;
                                        pbStatus.Text = Language.pbDownloadProgressConverting;
                                    });
                                }
                                Msg = null;
                                rtbVerbose.Invoke(() => rtbVerbose.AppendLine(e.Data));
                            } break;
                        }
                    }
                };
                DownloadProcess.ErrorDataReceived += (s, e) => {
                    if (e.Data?.Length > 0) {
                        rtbVerbose.Invoke(() => rtbVerbose.AppendLine($"Error: {e.Data.Trim()}"));
                    }
                };
                DownloadProcess.Start();
                DownloadProcess.BeginOutputReadLine();
                DownloadProcess.BeginErrorReadLine();

                args = null;
                while (!DownloadProcess.HasExited) {
                    if (Status == DownloadStatus.Aborted || Status == DownloadStatus.AbortForClose) {
                        if (!DownloadProcess.HasExited) {
                            Program.KillProcessTree((uint)DownloadProcess.Id);
                            DownloadProcess.Kill();
                        }
                        break;
                    }

                    if (Msg is not null) {
                        string Line = Msg.ReplaceWhitespace();
                        string[] LineParts = Line.Split(' ');
                        switch (Line[..5].ToLower()) {
                            case "[down": {
                                switch (LineParts[1][0]) {
                                    case '1': case '2': case '3':
                                    case '4': case '5': case '6':
                                    case '7': case '8': case '9':
                                    case '0': {
                                        if (LineParts[1].Contains('%')) {
                                            if (pbStatus.Style != ProgressBarStyle.Blocks)
                                                pbStatus.Invoke(() => pbStatus.Style = ProgressBarStyle.Blocks);

                                            if (pbStatus.IsHandleCreated) {
                                                this.Invoke(() => {
                                                    pbStatus.Text = DownloadHelper.GetTransferData(
                                                        LineParts: LineParts,
                                                        Percentage: ref Percentage,
                                                        Eta: ref ETA);

                                                    pbStatus.Value = (int)Math.Floor(Percentage);

                                                    this.Text = $"ETA: {ETA} - {MediaDetails.ProgressMediaName}";
                                                });
                                            }
                                        }
                                    } break;
                                }
                            } break;
                            case "[ffmp": {
                                rtbVerbose.Invoke(() => rtbVerbose.AppendLine(Line));
                                pbStatus.Invoke(() => {
                                    pbStatus.Style = ProgressBarStyle.Marquee;
                                    pbStatus.Text = Language.pbDownloadProgressFfmpegPostProcessing;
                                    pbStatus.Value = 100;
                                });
                                Msg = null;
                            } break;
                            case "[embe": {
                                rtbVerbose.Invoke(() => rtbVerbose.AppendLine(Line));
                                pbStatus.Invoke(() => {
                                    pbStatus.Style = ProgressBarStyle.Marquee;
                                    pbStatus.Text = Language.pbDownloadProgressEmbeddingSubtitles;
                                    pbStatus.Value = 100;
                                });
                                Msg = null;
                            } break;
                            case "[meta": {
                                rtbVerbose.Invoke(() => rtbVerbose.AppendLine(Line));
                                pbStatus.Invoke(() => {
                                    pbStatus.Style = ProgressBarStyle.Marquee;
                                    pbStatus.Text = Language.pbDownloadProgressEmbeddingMetadata;
                                    pbStatus.Value = 100;
                                });
                                Msg = null;
                            } break;
                        }
                    }

                    Thread.Sleep(250);
                }

                if (Status != DownloadStatus.Aborted && Status != DownloadStatus.AbortForClose) {
                    lvQueuedMedia.Invoke(() => lvQueuedMedia.Items[i].ImageIndex = DownloadProcess.ExitCode == 0 ? StatusIcon.Finished : StatusIcon.Errored);
                }
                else {
                    lvQueuedMedia.Invoke(() => lvQueuedMedia.Items[i].ImageIndex = StatusIcon.Waiting);
                    break;
                }

                this.Invoke(() => {
                    pbStatus.Style = ProgressBarStyle.Continuous;
                    pbStatus.Value = 0;
                    pbStatus.Text = "Queueing next download";
                });
            }

            this.Invoke(() => {
                switch (Status) {
                    case DownloadStatus.Aborted: {
                        rtbVerbose.AppendLine("Aborted download");
                        pbStatus.Text = Language.GenericAborted;
                        pbStatus.Value = pbStatus.Minimum;
                        sbtnDownload.Text = Language.GenericRetry;
                        System.Media.SystemSounds.Exclamation.Play();
                    } break;
                    case DownloadStatus.AbortForClose: break;
                    case DownloadStatus.Downloading: {
                        Status = DownloadStatus.Finished;
                        rtbVerbose.AppendLine("Download completed");
                        pbStatus.Text = Language.GenericCompleted;
                        pbStatus.Value = pbStatus.Maximum;
                        sbtnDownload.Text = Language.sbDownload;
                        System.Media.SystemSounds.Asterisk.Play();
                    } break;
                    default: {
                        rtbVerbose.AppendLine("Download error");
                        pbStatus.Text = Status == DownloadStatus.YtdlError ? Language.GenericAltError.Format("youtube-dl") : Language.GenericError;
                        pbStatus.Value = pbStatus.Minimum;
                        sbtnDownload.Text = Language.GenericRetry;
                        tcVideoData.SelectedTab = tabExtendedDownloaderVerbose;
                        System.Media.SystemSounds.Hand.Play();
                    } break;
                }
            });
        }) {
            Name = "Batch download",
            IsBackground = true,
            Priority = ThreadPriority.BelowNormal
        };
        ProcessingThread.Start();
    }
    private void SaveMediaOptions() {
        if (MediaDetails is null) {
            return;
        }

        Console.WriteLine("Saving media");
        MediaDetails.CustomArguments = txtCustomArguments.Text;
        MediaDetails.FileNameSchema = cbSchema.Text;
        MediaDetails.FileNameSchemaIndex = cbSchema.SelectedIndex;
        MediaDetails.FragmentThreads = numFragmentThreads.Value;
        MediaDetails.AudioVBR = chkAudioVBR.Checked;
        MediaDetails.VBRIndex = cbVbrQualities.SelectedIndex;
        MediaDetails.VideoDownloadAudio = chkVideoDownloadAudio.Checked;
        MediaDetails.VideoSeparateAudio = chkVideoSeparateAudio.Checked;
        MediaDetails.AbortOnError = chkAbortOnError.Checked;
        MediaDetails.SkipUnavailableFragments = chkSkipUnavailableFragments.Checked;
        MediaDetails.VideoRemuxIndex = cbVideoRemux.SelectedIndex;
        MediaDetails.VideoEncoderIndex = cbVideoEncoders.SelectedIndex;
        MediaDetails.AudioEncoderIndex = cbAudioEncoders.SelectedIndex;
        MediaDetails.StartTime = tpStartTime.Value;
        MediaDetails.EndTime = tpEndTime.Value;
    }
    private void LoadMediaOptions() {
        if (MediaDetails is null) {
            return;
        }

        Console.WriteLine("Loading media");
        txtCustomArguments.Text = MediaDetails.CustomArguments;
        cbSchema.Text = MediaDetails.FileNameSchema;
        cbSchema.SelectedIndex = MediaDetails.FileNameSchemaIndex;
        numFragmentThreads.Value = MediaDetails.FragmentThreads;
        chkAudioVBR.Checked = MediaDetails.AudioVBR;
        cbVbrQualities.SelectedIndex = MediaDetails.VBRIndex;
        chkVideoDownloadAudio.Checked = MediaDetails.VideoDownloadAudio;
        chkVideoSeparateAudio.Checked = MediaDetails.VideoSeparateAudio;
        chkAbortOnError.Checked = MediaDetails.AbortOnError;
        chkSkipUnavailableFragments.Checked = MediaDetails.SkipUnavailableFragments;
        cbVideoRemux.SelectedIndex = MediaDetails.VideoRemuxIndex;
        cbVideoEncoders.SelectedIndex = MediaDetails.VideoEncoderIndex;
        cbAudioEncoders.SelectedIndex = MediaDetails.AudioEncoderIndex;
        tpStartTime.Value = MediaDetails.StartTime;
        tpEndTime.Value = MediaDetails.EndTime;
    }
    private void SelectedMediaChanged(ExtendedMediaDetails MediaDetails) {
        if (this.MediaDetails is not null) {
            SaveMediaOptions();
        }

        this.MediaDetails = MediaDetails;

        if (MediaDetails is null) {
            rbVideo.Checked = rbVideo.Enabled = false;
            if (lvVideoFormats.Items.Count > 0) {
                lvVideoFormats.Items.Clear();
            }

            rbAudio.Checked = rbAudio.Enabled = false;
            if (lvAudioFormats.Items.Count > 0) {
                lvAudioFormats.Items.Clear();
            }

            rbUnknown.Checked = rbUnknown.Enabled = false;
            if (lvUnknownFormats.Items.Count > 0) {
                lvUnknownFormats.Items.Clear();
            }

            rbCustom.Checked = rbCustom.Enabled = false;
            txtCustomArguments.Text = string.Empty;
            tcVideoData.Enabled = false;

            if (!BatchDownload) {
                this.Text = Language.frmExtendedDownloaderRetrieving.Format(Language.ApplicationName);
                lbTimestamp.Visible = false;
                btnExtendedDownloaderDownloadThumbnail.Visible = false;
            }
            else {
                txtExtendedDownloaderMediaTitle.Text = "Select an item to view the details";
                txtExtendedDownloaderMediaTitle.Enabled = false;
            }
        }
        else {
            if (!MediaDetails.InfoRetrieved) {
                return;
            }

            void LoadItems() {
                if (MediaDetails.VideoItems.Count > 0) {
                    MediaDetails.VideoItems.For((Format) => lvVideoFormats.Items.Add(Format));
                    rbVideo.Enabled = true;
                    if (MediaDetails.SelectedVideoItem is not null) {
                        MediaDetails.SelectedVideoItem.Selected = true;
                    }
                }
                else {
                    rbVideo.Enabled = false;
                    lbExtendedDownloaderNoVideoFormatsAvailable.Visible = true;
                }

                if (MediaDetails.AudioItems.Count > 0) {
                    MediaDetails.AudioItems.For((Format) => lvAudioFormats.Items.Add(Format));
                    rbAudio.Enabled = true;
                    if (MediaDetails.SelectedAudioItem is not null) {
                        MediaDetails.SelectedAudioItem.Selected = true;
                    }
                }
                else {
                    rbAudio.Enabled = false;
                    lbExtendedDownloaderNoAudioFormatsAvailable.Visible = true;
                }

                if (MediaDetails.UnknownItems.Count > 0) {
                    MediaDetails.UnknownItems.For((Format) => lvUnknownFormats.Items.Add(Format));
                    rbUnknown.Enabled = true;
                    if (MediaDetails.SelectedUnknownItem is not null) {
                        MediaDetails.SelectedUnknownItem.Selected = true;
                    }
                }
                else {
                    rbUnknown.Enabled = false;
                    lbExtendedDownloaderNoUnknownFormatsFound.Visible = true;
                }

                rbVideo.Checked = rbAudio.Checked = rbUnknown.Checked = rbCustom.Checked = false;
            }

            switch (MediaDetails.SelectedType) {
                case DownloadType.Video: {
                    rbVideo.CheckedChanged -= rbVideo_CheckedChanged;
                    rbVideo.Checked = true;
                    LoadItems();
                    rbVideo.CheckedChanged += rbVideo_CheckedChanged;
                    rbVideo.Checked = true;
                    tcFormats.SelectedTab = tabExtendedDownloaderVideoFormats;
                } break;
                case DownloadType.Audio: {
                    rbAudio.CheckedChanged -= rbAudio_CheckedChanged;
                    rbAudio.Checked = true;
                    LoadItems();
                    rbAudio.CheckedChanged += rbAudio_CheckedChanged;
                    rbAudio.Checked = true;
                    tcFormats.SelectedTab = tabExtendedDownloaderAudioFormats;
                } break;
                case DownloadType.Unknown: {
                    rbUnknown.CheckedChanged -= rbUnknown_CheckedChanged;
                    rbUnknown.Checked = true;
                    LoadItems();
                    rbUnknown.CheckedChanged += rbUnknown_CheckedChanged;
                    rbUnknown.Checked = true;
                    tcFormats.SelectedTab = tabExtendedDownloaderUnknownFormats;
                    rbUnknown.Checked = true;
                } break;
                case DownloadType.Custom: {
                    rbCustom.CheckedChanged -= rbCustom_CheckedChanged;
                    rbCustom.Checked = true;
                    LoadItems();
                    rbCustom.CheckedChanged += rbCustom_CheckedChanged;
                    rbCustom.Checked = true;
                    tcFormats.SelectedTab = tabExtendedDownloaderCustom;
                    rbCustom.Checked = true;
                } break;
            }

            rtbMediaDescription.Text = MediaDetails.MediaDescription;
            txtExtendedDownloaderMediaTitle.Text = MediaDetails.MediaName;

            if (!BatchDownload) {
                this.Text = MediaDetails.ProgressMediaName;

                if (MediaDetails.MediaData is not null) {
                    txtUploader.Text = MediaDetails.MediaData.Uploader;
                    txtViews.Text = $"{(MediaDetails.MediaData.Views is not null ? MediaDetails.MediaData.Views.Value.ToString("#,000") : "Unknown")}";
                    lbTimestamp.Text = MediaDetails.MediaData.Duration;

                    if (!MediaDetails.MediaData.ThumbnailLink.IsNullEmptyWhitespace()) {
                        if (Downloads.ExtendedDownloaderAutoDownloadThumbnail) {
                            ProcessThumbnail();
                        }
                        else {
                            btnExtendedDownloaderDownloadThumbnail.Enabled = btnExtendedDownloaderDownloadThumbnail.Visible = true;
                        }
                    }
                }

                lbTimestamp.Location = new(
                    (pbThumbnail.Location.X + pbThumbnail.Size.Width) - lbTimestamp.Size.Width - 8,
                    (pbThumbnail.Location.Y + pbThumbnail.Size.Height) - lbTimestamp.Size.Height - 8);
                lbTimestamp.Visible = true;
            }
            else {
                txtExtendedDownloaderMediaTitle.Enabled = true;
            }

            tcVideoData.Enabled = true;
            sbtnDownload.Enabled = true;
            mDownload.Enabled = true;
            mDownloadWithAuthentication.Enabled = true;
            rbCustom.Enabled = true;
            cbSchema.Enabled = true;
            LoadMediaOptions();
        }
    }

    private void rbVideo_CheckedChanged(object sender, EventArgs e) {
        if (!rbVideo.Checked) {
            return;
        }

        if (!SwitchingQueuedItem) {
            MediaDetails?.ChangeMediaType(DownloadType.Video);
        }

        lvVideoFormats.Enabled = true;
        lvUnknownFormats.Enabled = lvUnknownFormats.Items.Count > 1;
        cbVideoRemux.Enabled = true;
        cbVideoEncoders.Enabled = true;
        chkVideoDownloadAudio.Enabled = true;
        lvAudioFormats.Enabled = chkAudioVBR.Enabled = chkVideoSeparateAudio.Enabled = chkVideoDownloadAudio.Checked;
        cbVbrQualities.Enabled = chkAudioVBR.Checked && chkVideoDownloadAudio.Checked;

        // Does this work with videos?
        cbAudioEncoders.Enabled = false;
    }
    private void rbAudio_CheckedChanged(object sender, EventArgs e) {
        if (!rbAudio.Checked) {
            return;
        }

        if (!SwitchingQueuedItem) {
            MediaDetails?.ChangeMediaType(DownloadType.Audio);
        }

        lvVideoFormats.Enabled = false;
        lvUnknownFormats.Enabled = lvUnknownFormats.Items.Count > 1;
        chkVideoDownloadAudio.Enabled = false;
        cbVideoRemux.Enabled = false;
        cbVideoEncoders.Enabled = false;
        chkVideoSeparateAudio.Enabled = false;
        lvAudioFormats.Enabled = true;
        chkAudioVBR.Enabled = true;
        cbAudioEncoders.Enabled = true;
        cbVbrQualities.Enabled = chkAudioVBR.Checked;
    }
    private void rbUnknown_CheckedChanged(object sender, EventArgs e) {
        if (!rbUnknown.Checked) {
            return;
        }

        if (MediaDetails is not null) {
            if (!SwitchingQueuedItem) {
                MediaDetails.ChangeMediaType(DownloadType.Unknown);
            }

            if (!MediaDetails.UnknownFormatsOnly && lvUnknownFormats.SelectedItems.Count > 0 && lvUnknownFormats.Items[0].Selected) {
                lvUnknownFormats.Items[1].Selected = true;
            }
        }

        lvVideoFormats.Enabled = false;
        lvAudioFormats.Enabled = false;
        lvUnknownFormats.Enabled = true;
        chkAudioVBR.Enabled = false;
        cbVbrQualities.Enabled = false;
        chkVideoDownloadAudio.Enabled = false;
        chkVideoSeparateAudio.Enabled = false;
        cbVideoRemux.Enabled = false;
        cbVideoEncoders.Enabled = false;
        cbAudioEncoders.Enabled = false;
    }
    private void rbCustom_CheckedChanged(object sender, EventArgs e) {
        if (!rbCustom.Checked) {
            return;
        }

        if (!SwitchingQueuedItem) {
            MediaDetails?.ChangeMediaType(DownloadType.Custom);
        }

        lvVideoFormats.Enabled = false;
        lvAudioFormats.Enabled = false;
        lvUnknownFormats.Enabled = false;
        chkAudioVBR.Enabled = false;
        cbVbrQualities.Enabled = false;
        chkVideoDownloadAudio.Enabled = false;
        chkVideoSeparateAudio.Enabled = false;
        cbVideoRemux.Enabled = false;
        cbVideoEncoders.Enabled = false;
        cbAudioEncoders.Enabled = false;
    }

    private void llbLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
        if (MediaDetails?.URL.IsNullEmptyWhitespace() != false) {
            return;
        }

        switch (e.Button) {
            case MouseButtons.Left: {
                Process.Start(MediaDetails.URL);
            } break;
            case MouseButtons.Right: {
                Clipboard.SetText(MediaDetails.URL);
                System.Media.SystemSounds.Exclamation.Play();
            } break;
        }
    }
    private void lvVideoFormats_SelectedIndexChanged(object sender, EventArgs e) {
        if (lvVideoFormats.SelectedItems.Count < 1 || MediaDetails is null) {
            return;
        }

        if (MediaDetails.SelectedVideoItem is not null) {
            MediaDetails.SelectedVideoItem.ImageIndex = MediaDetails.SelectedVideoItem.Index == 0 ?
                rbVideo.Checked ? MediaStatusIcon.Best : MediaStatusIcon.BestDisabled : MediaStatusIcon.NotSelected;
        }
        lvVideoFormats.SelectedItems[0].ImageIndex = rbVideo.Checked ? MediaStatusIcon.Selected : MediaStatusIcon.SelectedDisabled;
        MediaDetails.SelectedVideoItem = lvVideoFormats.SelectedItems[0];
    }
    private void lvAudioFormats_SelectedIndexChanged(object sender, EventArgs e) {
        if (lvAudioFormats.SelectedItems.Count < 1 || MediaDetails is null) {
            return;
        }

        if (MediaDetails.SelectedAudioItem is not null) {
            MediaDetails.SelectedAudioItem.ImageIndex = MediaDetails.SelectedAudioItem.Index == 0 ?
                rbAudio.Checked || (rbVideo.Checked && chkVideoDownloadAudio.Checked) ? MediaStatusIcon.Best : MediaStatusIcon.BestDisabled : MediaStatusIcon.NotSelected;
        }
        lvAudioFormats.SelectedItems[0].ImageIndex = rbAudio.Checked || (rbVideo.Checked && chkVideoDownloadAudio.Checked) ? MediaStatusIcon.Selected : MediaStatusIcon.SelectedDisabled;
        MediaDetails.SelectedAudioItem = lvAudioFormats.SelectedItems[0];
    }
    private void lvUnknownFormats_SelectedIndexChanged(object sender, EventArgs e) {
        if (lvUnknownFormats.SelectedItems.Count < 1 || MediaDetails is null) {
            return;
        }

        // There are only unknown formats.
        if (MediaDetails.UnknownFormatsOnly) {
            if (MediaDetails.SelectedUnknownItem is not null) {
                MediaDetails.SelectedUnknownItem.ImageIndex = MediaDetails.SelectedUnknownItem.Index == 0 ?
                    rbVideo.Checked || rbAudio.Checked || rbUnknown.Checked ?
                        MediaStatusIcon.Best : MediaStatusIcon.BestDisabled : MediaStatusIcon.NotSelected;
            }
        }
        // There are other formats.
        else {
            if (rbUnknown.Checked && lvUnknownFormats.SelectedItems[0].Index == 0) {
                lvUnknownFormats.Items[1].Selected = true;
                return;
            }

            if (MediaDetails.SelectedUnknownItem is not null) {
                MediaDetails.SelectedUnknownItem.ImageIndex = MediaDetails.SelectedUnknownItem.Index == 1 ?
                    rbVideo.Checked || rbAudio.Checked || rbUnknown.Checked ?
                        MediaStatusIcon.Best : MediaStatusIcon.BestDisabled : MediaStatusIcon.NotSelected;
            }
        }

        lvUnknownFormats.SelectedItems[0].ImageIndex = rbVideo.Checked || rbAudio.Checked || rbUnknown.Checked ? MediaStatusIcon.Selected : MediaStatusIcon.SelectedDisabled;
        MediaDetails.SelectedUnknownItem = lvUnknownFormats.SelectedItems[0];
    }
    private void txtCustomArguments_KeyDown(object sender, KeyEventArgs e) {
        switch (e.KeyCode) {
            case Keys.OemPipe when e.Shift: {
                e.Handled = e.SuppressKeyPress = true;
                System.Media.SystemSounds.Exclamation.Play();
            } break;
        }
    }
    private void cbCustomArguments_SelectedIndexChanged(object sender, EventArgs e) {
        if (cbCustomArguments.SelectedIndex > -1) {
            txtCustomArguments.Text = txtCustomArguments.Text.Length > 0 ?
                txtCustomArguments.Text.Trim(' ') + " " + cbCustomArguments.SelectedItem :
                cbCustomArguments.SelectedItem.ToString();
            cbCustomArguments.SelectedIndex = -1;
        }
    }

    private void cbSchema_KeyPress(object sender, KeyPressEventArgs e) {
        switch (e.KeyChar) {
            case ':': case '*': case '?':
            case '"': case '<': case '>':
            case '|': {
                System.Media.SystemSounds.Beep.Play();
                e.Handled = true;
            } break;
        }
    }
    private void chkAudioVBR_CheckedChanged(object sender, EventArgs e) {
        cbVbrQualities.Enabled =
            chkAudioVBR.Checked && (rbAudio.Checked || (rbVideo.Checked && chkVideoDownloadAudio.Checked));
    }
    private void chkVideoDownloadAudio_CheckedChanged(object sender, EventArgs e) {
        chkAudioVBR.Enabled = cbAudioEncoders.Enabled = lvAudioFormats.Enabled = chkVideoSeparateAudio.Enabled =
            chkVideoDownloadAudio.Checked;

        cbVbrQualities.Enabled = chkVideoDownloadAudio.Checked && chkAudioVBR.Checked;

        if (MediaDetails?.SelectedAudioItem is not null) {
            if (chkVideoDownloadAudio.Checked) {
                if (MediaDetails.SelectedAudioItem.Index != 0) {
                    lvAudioFormats.Items[0].ImageIndex = MediaStatusIcon.Best;
                }
                MediaDetails.SelectedAudioItem.ImageIndex = MediaStatusIcon.Selected;
            }
            else {
                if (MediaDetails.SelectedAudioItem.Index != 0) {
                    lvAudioFormats.Items[0].ImageIndex = MediaStatusIcon.BestDisabled;
                }
                MediaDetails.SelectedAudioItem.ImageIndex = MediaStatusIcon.SelectedDisabled;
            }
        }
    }
    private void btnDownloadThumbnail_Click(object sender, EventArgs e) {
        DownloadThumbnail();
        lbExtendedDownloaderUploader.Focus();
    }
    private void btnClearOutput_Click(object sender, EventArgs e) {
        if (Debug) {
            rtbVerbose.AppendLine("This is a line of text being used for debugging; if you see it, that's not good.");
        }
        else {
            rtbVerbose.Clear();
        }
    }
    private void sbtnDownload_Click(object sender, EventArgs e) {
        if (FailedInfoRetrieval) {
            FailedInfoRetrieval = false;
            sbtnDownload.Enabled = false;
            sbtnDownload.Text = Language.sbDownload;
            txtExtendedDownloaderMediaTitle.Text = Language.txtExtendedDownloaderMediaTitle;
            DownloadInfo();
            return;
        }
        mDownload_Click(sbtnDownload, e);
    }
    private void mDownload_Click(object sender, EventArgs e) {
        switch (Status) {
            case DownloadStatus.Downloading: {
                Status = DownloadStatus.Aborted;
            } break;

            default: {
                BeginDownload(false);
            } break;
        }
    }
    private void mDownloadWithAuthentication_Click(object sender, EventArgs e) {
        switch (Status) {
            case DownloadStatus.Downloading: {
                Status = DownloadStatus.Aborted;
            } break;

            default: {
                BeginDownload(true);
            } break;
        }
    }

    /// <summary>
    /// Adds a new item to the batch queue.
    /// </summary>
    /// <param name="Link">
    ///     The link that will be added.
    /// </param>
    /// <param name="Authenticate">
    ///     Whether authentication is required.
    ///     Ignored if <paramref name="CopySelectedOptions"/> is <see langword="true"/>
    /// </param>
    /// <param name="CopySelectedAuthentication">
    ///     Whether to copy authentication details from the selected queue item, if there is one.
    ///     Ignored it <paramref name="CopySelectedOptions"/> is <see langword="true"/>.
    /// </param>
    /// <param name="CopySelectedOptions">
    ///     Whether to copy download options from the selected queue item, if there is one.
    ///     Everything (including Authentication details) will be copied over.
    /// </param>
    /// <param name="CopyFrom">
    ///     The <see cref="ExtendedMediaDetails"/> that will be copied, if required.
    /// </param>
    private void QueueNewItem(string Link, bool Authenticate, bool CopySelectedAuthentication, bool CopySelectedOptions, ExtendedMediaDetails? CopyFrom) {
        if (Link.IsNullEmptyWhitespace()) {
            txtQueueLink.Focus();
            System.Media.SystemSounds.Exclamation.Play();
            return;
        }
        sbtnDownload.Enabled = false;

        ListViewItem NewItem = new(Link) {
            ImageIndex = StatusIcon.Waiting,
        };

        NewItem.SubItems.Add("-"); // Title
        NewItem.SubItems.Add("-"); // Length
        NewItem.SubItems.Add("-"); // Uploader
        NewItem.SubItems.Add("-"); // UploadedOn
        NewItem.SubItems.Add("-"); // Views

        ExtendedMediaDetails NewMedia = new(Link) {
            QueueItem = NewItem,
            BatchDownloadItem = true,
        };

        NewItem.Tag = NewMedia;
        lvQueuedMedia.Items.Add(NewItem);

        if (CopySelectedOptions && CopyFrom is not null) {
            SaveMediaOptions();
            NewMedia.Authentication = CopyFrom.Authentication;
            NewMedia.SelectedType = CopyFrom.SelectedType;
            NewMedia.FileNameSchema = CopyFrom.FileNameSchema;
            NewMedia.FileNameSchemaIndex = CopyFrom.FileNameSchemaIndex;
            NewMedia.AudioVBR = CopyFrom.AudioVBR;
            NewMedia.VBRIndex = CopyFrom.VBRIndex;
            NewMedia.VideoDownloadAudio = CopyFrom.VideoDownloadAudio;
            NewMedia.VideoSeparateAudio = CopyFrom.VideoSeparateAudio;
            NewMedia.VideoRemuxIndex = CopyFrom.VideoRemuxIndex;
            NewMedia.VideoEncoderIndex = CopyFrom.VideoEncoderIndex;
            NewMedia.AudioEncoderIndex = CopyFrom.AudioEncoderIndex;
            NewMedia.AbortOnError = CopyFrom.AbortOnError;
            NewMedia.SkipUnavailableFragments = CopyFrom.SkipUnavailableFragments;
            NewMedia.CustomArguments = CopyFrom.CustomArguments;
            NewMedia.StartTime = CopyFrom.StartTime;
            NewMedia.EndTime = CopyFrom.EndTime;
            NewMedia.FragmentThreads = CopyFrom.FragmentThreads;
        }

        if (Authenticate && !CopySelectedOptions) {
            if (CopySelectedAuthentication && CopyFrom is not null) {
                NewMedia.Authentication = CopyFrom.Authentication;
            }
            else {
                using frmAuthentication Auth = new();
                if (Auth.ShowDialog() != DialogResult.OK) {
                    return;
                }
                NewMedia.Authentication = Auth.Authentication;
            }
        }

        QueueList!.Add(NewMedia);

        if (ProcessingThread?.IsAlive != true) {
            ProcessingThread = new(() => {
                Status = DownloadStatus.Preparing;
                while (QueueList.Count > 0) {
                    ExtendedMediaDetails CurrentMedia = QueueList[0];
                    CurrentMedia.GetMediaDetails();

                    // If the queued list does not have the finished queued item, skip it
                    if (!lvQueuedMedia.Items.Contains(CurrentMedia.QueueItem) || (CurrentMedia.QueueItem is null || CurrentMedia.MediaData is null)) {
                        QueueList.RemoveAt(0);
                        continue;
                    }

                    this.Invoke(() => {
                        CurrentMedia.QueueItem.SubItems[1].Text = CurrentMedia.MediaName;
                        CurrentMedia.QueueItem.SubItems[2].Text = CurrentMedia.MediaData.Duration;
                        CurrentMedia.QueueItem.SubItems[3].Text = CurrentMedia.MediaData.Uploader;
                        CurrentMedia.QueueItem.SubItems[4].Text = CurrentMedia.MediaData.UploadedOn;
                        CurrentMedia.QueueItem.SubItems[5].Text = CurrentMedia.MediaData.Views.HasValue ?
                            CurrentMedia.MediaData.Views.Value.ToString("#,000") : "-";

                        if (!lvQueuedMedia.SelectedItems.Contains(CurrentMedia.QueueItem)) {
                            return;
                        }

                        SelectedMediaChanged(CurrentMedia);
                    });
                    QueueList.RemoveAt(0);
                    Thread.Sleep(100);
                }
                Status = DownloadStatus.None;
                sbtnDownload.Invoke(() => sbtnDownload.Enabled = true);
            }) {
                Name = "Batch download info queue resolver",
                IsBackground = true
            };
            ProcessingThread.Start();
        }
    }
    private string[] GetLinksFromClipboard() {
        if (!Clipboard.ContainsText()) {
            return Array.Empty<string>();
        }
        string ClipboardData = Clipboard.GetText().Replace("\r\n", "\n");
        return ClipboardData.Split('\n');
    }
    private string[] GetLinksFromFile() {
        using OpenFileDialog OFD = new() {
            Multiselect = false,
            Title = Language.mBatchDownloaderImportLinksFromFile
        };

        if (OFD.ShowDialog() != DialogResult.OK)
            return Array.Empty<string>();

        FileInfo Info = new(OFD.FileName);
        if (!Info.Exists || Info.Length < 2)
            return Array.Empty<string>();

        string FileData = File.ReadAllText(OFD.FileName);
        return FileData.Replace("\r\n", "\n").Split('\n');
    }
    private void lvQueuedMedia_SelectedIndexChanged(object sender, EventArgs e) {
        ExtendedMediaDetails? Details;
        if (lvQueuedMedia.SelectedItems.Count < 1 || (Details = lvQueuedMedia.SelectedItems[0].Tag as ExtendedMediaDetails) is null) {
            return;
        }

        SwitchingQueuedItem = true;
        SelectedMediaChanged(Details);
        SwitchingQueuedItem = false;
    }
    private void btnEnqueue_Click(object sender, EventArgs e) {
        QueueNewItem(txtQueueLink.Text, false, false, false, MediaDetails);
        txtQueueLink.Clear();
    }
    private void mEnqueue_Click(object sender, EventArgs e) {
        QueueNewItem(txtQueueLink.Text, false, false, false, MediaDetails);
        txtQueueLink.Clear();
    }
    private void mEnqueueCopyOptions_Click(object sender, EventArgs e) {
        QueueNewItem(txtQueueLink.Text, false, false, true, MediaDetails);
        txtQueueLink.Clear();
    }
    private void mEnqueueWithAuthentication_Click(object sender, EventArgs e) {
        QueueNewItem(txtQueueLink.Text, true, false, false, MediaDetails);
        txtQueueLink.Clear();
    }
    private void mEnqueueCopyAuthentication_Click(object sender, EventArgs e) {
        QueueNewItem(txtQueueLink.Text, true, true, false, MediaDetails);
        txtQueueLink.Clear();
    }
    private void mEnqueueClipboardLinks_Click(object sender, EventArgs e) {
        string[] Links = GetLinksFromClipboard();
        if (Links.Length < 1) {
            System.Media.SystemSounds.Asterisk.Play();
            return;
        }
        Links.For((Link) => QueueNewItem(Link, false, false, false, MediaDetails));
    }
    private void mEnqueueClipboardLinksWithAuthentication_Click(object sender, EventArgs e) {
        string[] Links = GetLinksFromClipboard();
        if (Links.Length < 1) {
            System.Media.SystemSounds.Asterisk.Play();
            return;
        }
        Links.For((Link) => QueueNewItem(Link, true, false, false, MediaDetails));
    }
    private void mEnqueueClipboardLinksCopyOptions_Click(object sender, EventArgs e) {
        string[] Links = GetLinksFromClipboard();
        if (Links.Length < 1) {
            System.Media.SystemSounds.Asterisk.Play();
            return;
        }
        Links.For((Link) => QueueNewItem(Link, false, false, true, MediaDetails));
    }
    private void mEnqueueClipboardLinksCopyAuthentication_Click(object sender, EventArgs e) {
        string[] Links = GetLinksFromClipboard();
        if (Links.Length < 1) {
            System.Media.SystemSounds.Asterisk.Play();
            return;
        }
        Links.For((Link) => QueueNewItem(Link, true, true, false, MediaDetails));
    }
    private void mEnqueueFileLinks_Click(object sender, EventArgs e) {
        string[] Links = GetLinksFromFile();
        if (Links.Length < 1) {
            System.Media.SystemSounds.Asterisk.Play();
            return;
        }
        Links.For((Link) => QueueNewItem(Link, false, false, false, MediaDetails));
    }
    private void mEnqueueFileLinksWithAuthentication_Click(object sender, EventArgs e) {
        string[] Links = GetLinksFromFile();
        if (Links.Length < 1) {
            System.Media.SystemSounds.Asterisk.Play();
            return;
        }
        Links.For((Link) => QueueNewItem(Link, true, false, false, MediaDetails));
    }
    private void mEnqueueFileLinksCopyOptions_Click(object sender, EventArgs e) {
        string[] Links = GetLinksFromFile();
        if (Links.Length < 1) {
            System.Media.SystemSounds.Asterisk.Play();
            return;
        }
        Links.For((Link) => QueueNewItem(Link, false, false, true, MediaDetails));
    }
    private void mEnqueueFileLinksCopyAuthentication_Click(object sender, EventArgs e) {
        string[] Links = GetLinksFromFile();
        if (Links.Length < 1) {
            System.Media.SystemSounds.Asterisk.Play();
            return;
        }
        Links.For((Link) => QueueNewItem(Link, true, true, false, MediaDetails));
    }
    private void mEnqueueClipboardScanner_Click(object sender, EventArgs e) {
        mEnqueueClipboardScanner.Checked ^=  true;

        if (mEnqueueClipboardScanner.Checked) {
            if (!Batch.ClipboardScannerNoticeViewed) {
                if (Log.MessageBox(Language.dlgBatchDownloadClipboardScannerNotice, MessageBoxButtons.OKCancel) == DialogResult.Cancel) {
                    mEnqueueClipboardScanner.Checked = false;
                    return;
                }
                else {
                    Batch.ClipboardScannerNoticeViewed = true;
                }
            }
            if (NativeMethods.AddClipboardFormatListener(this.Handle)) {
                Application.ApplicationExit += ApplicationExit;
                mEnqueueClipboardScannerVerifyLinks.Enabled = true;
                ClipboardScannerActive = true;
                Log.Write("Clipboard scanning for batch download queueing stopped.");
            }
            else {
                mEnqueueClipboardScanner.Checked = false;
            }
        }
        else {
            if (ClipboardScannerActive) {
                if (NativeMethods.RemoveClipboardFormatListener(this.Handle)) {
                    Application.ApplicationExit -= ApplicationExit;
                    mEnqueueClipboardScannerVerifyLinks.Enabled = false;
                    ClipboardScannerActive = false;
                    Log.Write("Clipboard scanning for batch download queueing started.");
                }
            }
        }
    }
    private void mEnqueueClipboardScannerVerifyLinks_Click(object sender, EventArgs e) {
        mEnqueueClipboardScannerVerifyLinks.Checked ^= true;
    }
    private void mQueueCopyLink_Click(object sender, EventArgs e) {
        if (MediaDetails is not null) {
            Clipboard.SetText(MediaDetails.URL);
        }
    }
    private void mQueueViewInBrowser_Click(object sender, EventArgs e) {
        if (MediaDetails is not null) {
            Process.Start(MediaDetails.URL);
        }
    }
    private void mQueueRemoveSelected_Click(object sender, EventArgs e) {
        if (lvQueuedMedia.SelectedItems.Count > 0) {
            lvQueuedMedia.Items.RemoveAt(lvQueuedMedia.SelectedItems[0].Index);
        }

        if (lvQueuedMedia.Items.Count == 0) {
            sbtnDownload.Enabled = false;
        }
    }

    // Debug
    private void btnCreateArgs_Click(object sender, EventArgs e) {
        Log.MessageBox(MediaDetails?.Arguments ?? "No args");
    }
    private void btnKill_Click(object sender, EventArgs e) {
        if (DownloadProcess?.HasExited == false) {
            Program.KillProcessTree((uint)DownloadProcess.Id);
            DownloadProcess.Kill();
        }
    }
}