#nullable enable
namespace murrty.updater;
public class GithubRepoContent {
    public string? name { get; init; }
    public string? sha { get; init; }
    public long size { get; init; }
    public string? download_url { get; init; }
}
