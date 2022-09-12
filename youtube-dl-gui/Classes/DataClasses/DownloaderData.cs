﻿namespace youtube_dl_gui;

using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization;

/// <summary>
/// Class used for information relating to the video.
/// </summary>
[DataContract]
internal sealed class DownloaderData {

    public static DownloaderData GenerateData(string URL, out string RetrievedData) {
        RetrievedData = null;
        if (!URL.IsNullEmptyWhitespace()) {
            if (Verification.YoutubeDlPath.IsNullEmptyWhitespace())
                Verification.RefreshYoutubeDlLocation();

            if (Verification.YoutubeDlPath.IsNullEmptyWhitespace())
                return null;


            StringBuilder ConnectionArgs = new(string.Empty);

            if (Config.Settings.Downloads.RetryAttempts != 10 && Config.Settings.Downloads.RetryAttempts > 0) {
                ConnectionArgs.Append($"--retries {Config.Settings.Downloads.RetryAttempts} ");
            }

            if (Config.Settings.Downloads.ForceIPv4) {
                ConnectionArgs.Append("--force-ipv4 ");
            }
            else if (Config.Settings.Downloads.ForceIPv6) {
                ConnectionArgs.Append("--force-ipv6 ");
            }

            if (Config.Settings.Downloads.UseProxy && Config.Settings.Downloads.ProxyType > -1 && !string.IsNullOrEmpty(Config.Settings.Downloads.ProxyIP) && !string.IsNullOrEmpty(Config.Settings.Downloads.ProxyPort)) {
                ConnectionArgs.Append($"--proxy {DownloadHelper.ProxyProtocols[Config.Settings.Downloads.ProxyType]}{Config.Settings.Downloads.ProxyIP}:{Config.Settings.Downloads.ProxyPort}/ ");
            }

            Process Enumeration = new() {
                StartInfo = new() {
                    Arguments = $"--simulate --no-warnings --no-cache-dir --print-json {ConnectionArgs}{URL}",
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

            if (!Error.ToString().IsNullEmptyWhitespace()) {
                Log.Write(Error.ToString());
            }
            if (!Output.ToString().IsNullEmptyWhitespace()) {
                RetrievedData = Output.ToString();
                var data = RetrievedData.JsonDeserialize<DownloaderData>();
                return data;
            }
        }
        return null;
    }
    public Image GetThumbnail() {
        if (Config.Settings.Downloads.YtdlType != 2) {
            return null;
        }

        using WebClient wc = new();
        byte[] thumbBytes = wc.DownloadData(this.ThumbnailLink);

        if (this.ThumbnailLink.Split('?')[0].EndsWith(".webp")) {
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
                    //RedirectStandardError = true,
                    //RedirectStandardOutput = true,
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
            if (DurationTime is not null) {
                int hours = 0;
                int minutes = 0;
                long seconds = DurationTime.Value;

                while (seconds >= 60) {
                    minutes++;
                    seconds -= 60;
                }

                while (minutes >= 60) {
                    hours++;
                    minutes -= 60;
                }

                return $"{(hours > 0 ? $"{hours:N0}:{minutes:00.##}" : $"{minutes}")}:{seconds:00.##}";
            }

            return DurationString.IsNullEmptyWhitespace() ? "???" : DurationString;
        }
    }

    [DataMember(Name = "title")]
    public string Title { get; set; }

    [DataMember(Name = "formats")]
    public Format[] AvailableFormats { get; set; }

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
    public long? DurationTime { get; set; }

    [DataContract(Name = "formats")]
    public class Format {

        public bool ValidVideoFormat =>
            Extension.ToLower() switch {
                "mhtml" => false,
                _ => true,
            };

        [DataMember(Name = "format_id")]
        public string Identifier { get; set; }

        [DataMember(Name = "format_note")]
        public string QualityName { get; set; }

        [DataMember(Name = "ext")]
        public string Extension { get; set; }

        [DataMember(Name = "acodec")]
        public string AudioCodec { get; set; }

        [DataMember(Name = "vcodec")]
        public string VideoCodec { get; set; }

        [DataMember(Name = "width")]
        public int? VideoWidth { get; set; }

        [DataMember(Name = "height")]
        public int? VideoHeight { get; set; }

        [DataMember(Name = "fps")]
        public float? VideoFps { get; set; }

        [DataMember(Name = "asr")]
        public int? AudioSampleRate { get; set; }

        [DataMember(Name = "filesize")]
        public long? FileSize { get; set; }

        [DataMember(Name = "tbr")]
        public decimal? VideoBitrate { get; set; }

        [DataMember(Name = "abr")]
        public decimal? AudioBitrate { get; set; }

        [DataMember(Name = "filesize_approx")]
        public long? ApproximateFileSize { get; set; }
    }

}