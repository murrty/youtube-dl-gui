namespace youtube_dl_gui;
internal class InvalidDownloadProviderException : Exception {
    public int DownloadType { get; }
    public InvalidDownloadProviderException(int DownloadType) : base("The download provider being used is an invalid provider for this operation.") {
        this.DownloadType = DownloadType;
    }
}