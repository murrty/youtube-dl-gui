namespace youtube_dl_gui;

using System.Runtime.Serialization;

/// <summary>
/// Represents a format of a downloadable media source.
/// </summary>
[DataContract(Name = "formats")]
public class YoutubeDlFormat {
    /// <summary>
    /// Gets whether this format is a known invalid formats.
    /// </summary>
    [IgnoreDataMember]
    private bool ExtensionValidGeneric =>
        Extension.ToLower() switch {
            "mhtml" or "none" => false,
            _ => true
        };

    /// <summary>
    /// Gets whether this format is a valid video format.
    /// </summary>
    [IgnoreDataMember]
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

    /// <summary>
    /// Gets whether this format is a valid audio format.
    /// </summary>
    [IgnoreDataMember]
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

    /// <summary>
    /// Gets the size string of this format.
    /// </summary>
    [IgnoreDataMember]
    public string Size {
        get {
            return FileSize is not null ?
                FileSize.Value.SizeToString() : ApproximateFileSize is not null ? ApproximateFileSize.Value.SizeToString() : "null";
        }
    }

    /// <summary>
    /// Gets whether this format can support thumbnail embedding, if it is a video format.
    /// </summary>
    [IgnoreDataMember]
    public bool VideoThumbnailEmbedding => Extension.ToLowerInvariant() == "mp4";

    /// <summary>
    /// Gets whether this format can support thumbnail embedding, if it is an audio format.
    /// </summary>
    [IgnoreDataMember]
    public bool AudioThumbnailEmbedding => Extension.ToLowerInvariant() switch {
        "mp3" or "m4a" => true,
        _ => false
    };

    [IgnoreDataMember]
    public bool Best { get; set; }

    /// <summary>
    /// Get ListViewItem associated with this format.
    /// </summary>
    [IgnoreDataMember]
    public System.Windows.Forms.ListViewItem ListViewItem { get; set;}

    /// <summary>
    /// Gets the identifier of this format.
    /// </summary>
    [DataMember(Name = "format_id")]
    public string Identifier { get; set; }

    /// <summary>
    /// Gets the quality name of this format.
    /// </summary>
    [DataMember(Name = "format_note")]
    public string QualityName { get; set; }

    /// <summary>
    /// Gets the extension used for this format.
    /// </summary>
    [DataMember(Name = "ext")]
    public string Extension { get; set; }

    /// <summary>
    /// Gets the audio codec of this format.
    /// </summary>
    [DataMember(Name = "acodec")]
    public string AudioCodec { get; set; }

    /// <summary>
    /// Gets the video codec of this format.
    /// </summary>
    [DataMember(Name = "vcodec")]
    public string VideoCodec { get; set; }

    /// <summary>
    /// Gets the video width of this format.
    /// </summary>
    [DataMember(Name = "width")]
    public int? VideoWidth { get; set; }

    /// <summary>
    /// Gets the video height of this format.
    /// </summary>
    [DataMember(Name = "height")]
    public int? VideoHeight { get; set; }

    /// <summary>
    /// Gets the video frames per second (fps) of this format.
    /// </summary>
    [DataMember(Name = "fps")]
    public float? VideoFps { get; set; }

    /// <summary>
    /// Gets the audio sample rate of this format.
    /// </summary>
    [DataMember(Name = "asr")]
    public int? AudioSampleRate { get; set; }

    /// <summary>
    /// Gets the byte-size of this format.
    /// </summary>
    [DataMember(Name = "filesize")]
    public long? FileSize { get; set; }

    /// <summary>
    /// Gets the video bitrate for this format.
    /// </summary>
    [DataMember(Name = "tbr")]
    public decimal? VideoBitrate { get; set; }

    /// <summary>
    /// Gets the audio bitrate for this format.
    /// </summary>
    [DataMember(Name = "abr")]
    public decimal? AudioBitrate { get; set; }

    /// <summary>
    /// Gets the approximate file size which for this format.
    /// </summary>
    [DataMember(Name = "filesize_approx")]
    public long? ApproximateFileSize { get; set; }

    /// <summary>
    /// Gets the video resolution for this format.
    /// </summary>
    [DataMember(Name = "resolution")]
    public string VideoResolution { get; set; }

    /// <summary>
    /// Gets the amount of audio channels for this format.
    /// </summary>
    [DataMember(Name = "audio_channels")]
    public byte? AudioChannels { get; set; }

    /// <inheritdoc/>
    public override string ToString() {
        StringBuilder ts = new("{ ");
        if (ValidVideoFormat)
            ts.Append("Video");
        else if (ValidAudioFormat)
            ts.Append("Audio");
        else
            ts.Append("Unknown");

        return ts.Append($" -> {Identifier} }}").ToString();
    }
}