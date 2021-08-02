using System;

namespace youtube_dl_gui {
    public sealed class DownloadInfo : IDisposable {

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public bool IsDisposed { get; private set; }
        public void Dispose(bool disposing) {
            IsDisposed = true;
        }

        /// <summary>
        /// The URL of the video to download.
        /// </summary>
        private string _DownloadURL = null;
        /// <summary>
        /// The arguments passed for youtube-dl
        /// </summary>
        private string _DownloadArguments = null;
        /// <summary>
        /// The status of the current download
        /// </summary>
        private DownloadStatus _Status = DownloadStatus.None;

        /// <summary>
        /// The type of the download.
        /// </summary>
        private DownloadType _Type = DownloadType.None;
        /// <summary>
        /// The quality of the video download.
        /// </summary>
        private VideoQualityType _VideoQuality = VideoQualityType.none;
        /// <summary>
        /// The format of the video download.
        /// </summary>
        private VideoFormatType _VideoFormat = VideoFormatType.none;
        /// <summary>
        /// The CBR quality of the audio download.
        /// </summary>
        private AudioCBRQualityType _AudioCBRQuality = AudioCBRQualityType.none;
        /// <summary>
        /// The VBR quality of the audio download.
        /// </summary>
        private AudioVBRQualityType _AudioVBRQuality = AudioVBRQualityType.none;
        /// <summary>
        /// the format of the audio download.
        /// </summary>
        private AudioFormatType _AudioFormat = AudioFormatType.none;
        /// <summary>
        /// The playlist selection type.
        /// </summary>
        private PlaylistSelectionType _PlaylistSelection = PlaylistSelectionType.None;

        /// <summary>
        /// Determines of the video should skip downloading the audio
        /// </summary>
        private bool _SkipAudioForVideos = true;
        /// <summary>
        /// Determines if the audio should be in VBR (Variable bit rate)
        /// </summary>
        private bool _UseVBR = false;
        /// <summary>
        /// Determines if the download is a part of a batch process.
        /// </summary>
        private bool _BatchDownload = false;
        /// <summary>
        /// The time of the batch download start.
        /// </summary>
        private string _BatchTime = null;
        /// <summary>
        /// The username for authentication.
        /// </summary>
        private string _AuthUsername = null;
        /// <summary>
        /// The password for authentication.
        /// </summary>
        private string _AuthPassword = null;
        /// <summary>
        /// The 2-factor answer for authentication.
        /// </summary>
        private string _Auth2Factor = null;
        /// <summary>
        /// The video password for authentication.
        /// </summary>
        private string _AuthVideoPassword = null;
        /// <summary>
        /// Determines if authentication should use NetRC.
        /// </summary>
        private bool _AuthNetrc = false;
        /// <summary>
        /// The arguments for playlist selection.
        /// </summary>
        private string _PlaylistSelectionArg = null;
        /// <summary>
        /// The int index of the start of the playlist.
        /// </summary>
        private int _PlaylistSelectionIndexStart = -1;
        /// <summary>
        /// The int index of the end of the playlist.
        /// </summary>
        private int _PlaylistSelectionIndexEnd = -1;

        public string DownloadURL {
            get { return _DownloadURL; }
            set { _DownloadURL = value; }
        }
        public string DownloadArguments {
            get { return _DownloadArguments; }
            set { _DownloadArguments = value; }
        }
        public DownloadStatus Status {
            get { return _Status; }
            set { _Status = value; }
        }

        public DownloadType Type {
            get { return _Type; }
            set { _Type = value; }
        }
        public VideoQualityType VideoQuality {
            get { return _VideoQuality; }
            set { _VideoQuality = value; }
        }
        public VideoFormatType VideoFormat {
            get { return _VideoFormat; }
            set { _VideoFormat = value; }
        }
        public AudioCBRQualityType AudioCBRQuality {
            get { return _AudioCBRQuality; }
            set { _AudioCBRQuality = value; }
        }
        public AudioVBRQualityType AudioVBRQuality {
            get { return _AudioVBRQuality; }
            set { _AudioVBRQuality = value; }
        }
        public AudioFormatType AudioFormat {
            get { return _AudioFormat; }
            set { _AudioFormat = value; }
        }
        public PlaylistSelectionType PlaylistSelection {
            get { return _PlaylistSelection; }
            set { _PlaylistSelection = value; }
        }

        public bool SkipAudioForVideos {
            get { return _SkipAudioForVideos; }
            set { _SkipAudioForVideos = value; }
        }
        public bool UseVBR {
            get { return _UseVBR; }
            set { _UseVBR = value; }
        }
        public bool BatchDownload {
            get { return _BatchDownload; }
            set { _BatchDownload = value; }
        }
        public string BatchTime {
            get { return _BatchTime; }
            set { _BatchTime = value; }
        }
        public string AuthUsername {
            get { return _AuthUsername; }
            set { _AuthUsername = value; }
        }
        public string AuthPassword {
            get { return _AuthPassword; }
            set { _AuthPassword = value; }
        }
        public string Auth2Factor {
            get { return _Auth2Factor; }
            set { _Auth2Factor = value; }
        }
        public string AuthVideoPassword {
            get { return _AuthVideoPassword; }
            set { _AuthVideoPassword = value; }
        }
        public bool AuthNetrc {
            get { return _AuthNetrc; }
            set { _AuthNetrc = value; }
        }
        public string PlaylistSelectionArg {
            get { return _PlaylistSelectionArg; }
            set { _PlaylistSelectionArg = value; }
        }
        public int PlaylistSelectionIndexStart {
            get { return _PlaylistSelectionIndexStart; }
            set { _PlaylistSelectionIndexStart = value; }
        }
        public int PlaylistSelectionIndexEnd {
            get { return _PlaylistSelectionIndexEnd; }
            set { _PlaylistSelectionIndexEnd = value; }
        }

    }
}
