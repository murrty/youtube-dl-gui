namespace youtube_dl_gui;

using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

/// <summary>
/// Class used for information relating to the video.
/// </summary>
[DataContract]
internal sealed class YoutubeDlData {
    // Tested on yt-dlp

    public static YoutubeDlData GenerateData(string URL, out string RetrievedData) =>
        Generate(URL, "-j --no-playlist", null, out RetrievedData);
    public static YoutubeDlData GenerateData(string URL, AuthenticationDetails Auth, out string RetrievedData) =>
        Generate(URL, "-j --no-playlist", Auth, out RetrievedData);
    public static YoutubeDlData GeneratePlaylist(string URL, out string RetrievedData) =>
        Generate(URL, "-J", null, out RetrievedData);
    public static YoutubeDlData GeneratePlaylist(string URL, AuthenticationDetails Auth, out string RetrievedData) =>
        Generate(URL, "-J", Auth, out RetrievedData);
    private static YoutubeDlData Generate(string URL, string GenerateCommand, AuthenticationDetails Auth, out string RetrievedData) {
        RetrievedData = null;
        if (!URL.IsNullEmptyWhitespace()) {
            Log.Write($"Gathering data for \"{URL}\".");
            if (Verification.YoutubeDlPath.IsNullEmptyWhitespace())
                Verification.RefreshYoutubeDlLocation();

            if (Verification.YoutubeDlPath.IsNullEmptyWhitespace())
                return null;

            StringBuilder ConnectionArgs = new(string.Empty);

            if (Config.Settings.Downloads.RetryAttempts != 10 && Config.Settings.Downloads.RetryAttempts > 0)
                ConnectionArgs.Append($"--retries {Config.Settings.Downloads.RetryAttempts} ");

            if (Config.Settings.Downloads.ForceIPv4)
                ConnectionArgs.Append("--force-ipv4 ");
            else if (Config.Settings.Downloads.ForceIPv6)
                ConnectionArgs.Append("--force-ipv6 ");

            if (Config.Settings.Downloads.UseProxy && Config.Settings.Downloads.ProxyType > -1 &&
            !string.IsNullOrEmpty(Config.Settings.Downloads.ProxyIP) && !string.IsNullOrEmpty(Config.Settings.Downloads.ProxyPort))
                ConnectionArgs.Append($"--proxy {DownloadHelper.ProxyProtocols[Config.Settings.Downloads.ProxyType]}{Config.Settings.Downloads.ProxyIP}:{Config.Settings.Downloads.ProxyPort}/ ");

            if (Auth is not null) {
                if (!Auth.Username.IsNullEmptyWhitespace())
                    ConnectionArgs.Append($"--username {Auth.Username} ");
                if (Auth.Password?.Length > 0)
                    ConnectionArgs.Append($"--password {Auth.GetPassword()} ");
                if (!Auth.TwoFactor.IsNullEmptyWhitespace())
                    ConnectionArgs.Append($" --twofactor {Auth.TwoFactor} ");
                if (Auth.MediaPassword?.Length > 0)
                    ConnectionArgs.Append($"--video-password {Auth.GetMediaPassword()} ");
                if (Auth.NetRC)
                    ConnectionArgs.Append("--netrc ");
                if (!Auth.CookiesFile.IsNullEmptyWhitespace())
                    ConnectionArgs.Append($"--cookies {Auth.CookiesFile} ");
                if (!Auth.CookiesFromBrowser.IsNullEmptyWhitespace())
                    ConnectionArgs.Append($"--cookies-from-browser {Auth.CookiesFromBrowser} ");
            }

            Process Enumeration = new() {
                StartInfo = new() {
                    Arguments = $"--simulate --no-warnings --no-cache-dir {GenerateCommand} {ConnectionArgs}{URL}",
                    FileName = Verification.YoutubeDlPath,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                }
            };

            StringBuilder Output = new(string.Empty);
            StringBuilder Error = new(string.Empty);
            Enumeration.OutputDataReceived += (s, e) => Output.Append(e.Data);
            Enumeration.ErrorDataReceived += (s, e) => Error.Append(e.Data);
            Enumeration.Start();
            Enumeration.BeginOutputReadLine();
            Enumeration.BeginErrorReadLine();
            Enumeration.WaitForExit();

            Enumeration.StartInfo.Arguments = null;

            if (!Error.ToString().IsNullEmptyWhitespace()) {
                Log.Write($"Downloading info for \"{URL}\" output some errors.");
                Log.Write(Error.ToString());
            }

            if (!Output.ToString().IsNullEmptyWhitespace()) {
                Log.Write($"Finished downloading info for \"{URL}\", deserializing the data.");
                RetrievedData = Output.ToString();
                var data = RetrievedData.JsonDeserialize<YoutubeDlData>();
                data.URL = URL;
                return data;
            }
        }
        return null;
    }

    public Image GetThumbnail() {
        Log.Write($"Downloading the thumbnail for \"{URL}\".");
        using WebClient wc = new();
        byte[] thumbBytes = wc.DownloadData(this.ThumbnailLink);

        if (this.ThumbnailLink.Split('?')[0].EndsWith(".webp")) {
            Log.Write("The thumbnail is a .webp file and must be converted to be viewable.");
            string ThumbPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + $"\\temp\\{DateTime.Now:yyyyMMddhmmssfffffff}s";
            File.WriteAllBytes($"{ThumbPath}.webp", thumbBytes);
            if (Verification.FFmpegPath.IsNullEmptyWhitespace())
                Verification.RefreshFFmpegLocation();
            if (Verification.FFmpegPath.IsNullEmptyWhitespace())
                return null;

            //-vf \"scale=1920:-1\"
            Process ffmpegConvert = new() {
                StartInfo = new() {
                    Arguments = $"-nostats -hide_banner -i \"{ThumbPath}.webp\" \"{ThumbPath}.jpg\"",
                    FileName = Verification.FFmpegPath,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                }
            };
            ffmpegConvert.Start();
            ffmpegConvert.WaitForExit();

            if (File.Exists(ThumbPath + ".jpg")) {
                thumbBytes = File.ReadAllBytes(ThumbPath + ".jpg");
                File.Delete(ThumbPath + ".webp");
                File.Delete(ThumbPath + ".jpg");
            }
            else return null;
        }

        using MemoryStream Stream = new(thumbBytes);
        return Image.FromStream(Stream);
    }

    [IgnoreDataMember]
    public string Duration {
        get {
            int hours = 0;
            int minutes = 0;
            decimal seconds = 0;

            if (DurationTime is not null) {
                seconds = DurationTime.Value;
            }
            else if (IsPlaylist) {
                for (int i = 0; i < PlaylistVideos.Length; i++) {
                    if (PlaylistVideos[i].DurationTime is not null)
                        seconds += PlaylistVideos[i].DurationTime.Value;
                }
            }

            if (seconds > 0) {
                while (seconds >= 60) {
                    minutes++;
                    seconds -= 60;
                }

                while (minutes >= 60) {
                    hours++;
                    minutes -= 60;
                }

                return $"{(hours > 0 ? $"{hours:N0}:{minutes:00.##}" : $"{minutes}")}:{Math.Round(seconds, MidpointRounding.ToEven):00.##}";
            }

            return DurationString.IsNullEmptyWhitespace() ? "?:??" : DurationString;
        }
    }

    [IgnoreDataMember]
    public string URL { get; private set; }

    [IgnoreDataMember]
    public bool IsPlaylist => PlaylistVideos is not null && PlaylistVideos.Length > 0;

    [DataMember(Name = "entries")]
    public YoutubeDlData[] PlaylistVideos { get; set; }

    [DataMember(Name = "title")]
    public string Title { get; set; }

    [DataMember(Name = "formats")]
    public YoutubeDlFormat[] AvailableFormats { get; set; }

    [DataMember(Name = "thumbnail")]
    public string ThumbnailLink { get; set; }

    [DataMember(Name = "description")]
    public string Description { get; set; }

    [DataMember(Name = "uploader")]
    public string Uploader { get; set; }

    [DataMember(Name = "view_count")]
    public long? Views { get; set; }

    [DataMember(Name = "duration_string")]
    public string DurationString { get; set; }

    [DataMember(Name = "duration")]
    public decimal? DurationTime { get; set; }

    [DataMember(Name = "upload_date")]
    public string UploadedOn { get; set; }
}