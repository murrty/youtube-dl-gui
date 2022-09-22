namespace youtube_dl_gui;

using System.Runtime.Serialization;

[DataContract(Name = "formats")]
public class YoutubeDlFormat {
    private bool ExtensionValidGeneric =>
        Extension.ToLower() switch {
            "mhtml" or "none" => false,
            _ => true
        };

    public bool ValidVideoFormat {
        get {
            if (Extension is null || !ExtensionValidGeneric)
                return false;

            if (VideoResolution is not null && VideoResolution.ToLower() == "audio only")
                return false;

            return 
                VideoCodec.IsNotNullEmptyWhitespace() && VideoCodec.ToLower() != "none" && (
                VideoWidth is not null && VideoWidth > 0 ||
                VideoHeight is not null && VideoHeight > 0 ||
                VideoFps is not null && VideoFps > 0 ||
                VideoBitrate is not null && VideoBitrate > 0
                );
        }
    }

    public bool ValidAudioFormat {
        get {
            if (Extension is null || !ExtensionValidGeneric)
                return false;

            if (Extension is not null) {
                if (Extension.ToLower() == "wav")
                    return true;
            }

            return (
                AudioCodec.IsNotNullEmptyWhitespace() && AudioCodec.ToLower() != "none" ||
                AudioSampleRate is not null && AudioSampleRate > 0 ||
                AudioBitrate is not null && AudioBitrate > 0 ||
                AudioChannels is not null && AudioChannels > 0);
        }
    }

    public string Size {
        get {
            return FileSize is not null ?
                FileSize.Value.SizeToString() : ApproximateFileSize is not null ? ApproximateFileSize.Value.SizeToString() : "null";
        }
    }

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

    [DataMember(Name = "resolution")]
    public string VideoResolution { get; set; }

    [DataMember(Name = "audio_channels")]
    public byte? AudioChannels { get; set; }
}