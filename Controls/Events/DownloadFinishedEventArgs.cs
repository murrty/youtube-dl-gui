#nullable enable
namespace murrty.controls;
public sealed class DownloadFinishedEventArgs : EventArgs {
    public long BytesReceived { get; }
    public DownloadFinishedEventArgs(long bytesReceived) {
        BytesReceived = bytesReceived;
    }
}