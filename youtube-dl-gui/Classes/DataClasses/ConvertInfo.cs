#nullable enable
namespace youtube_dl_gui;
/// <summary>
/// Base class to represent a quick conversion.
/// </summary>
/// <param name="Input">
/// The input of the file to be converted.
/// </param>
/// <param name="Output">
/// The output of the converted file.
/// </param>
public sealed class ConvertInfo(string Input, string Output) {
    /// <summary>
    /// The input of the file to be converted.
    /// </summary>
    public string InputFile { get; set; } = Input;
    /// <summary>
    /// The output of the converted file.
    /// </summary>
    public string? OutputFile { get; set; } = Output;
    /// <summary>
    /// Determines if the current conversion is in a batch conversion.
    /// </summary>
    public bool BatchConversion { get; set; }
    /// <summary>
    /// The conversion type, used for user-specified settings.
    /// </summary>
    public ConversionType Type { get; set; } = ConversionType.Unspecified;
    /// <summary>
    /// The status of the current conversion.
    /// </summary>
    public ConversionStatus Status { get; set; } = ConversionStatus.None;

    /// <summary>
    /// Hides the compile information from ffmpeg.
    /// </summary>
    public bool HideFFmpegCompile { get; set; } = Converts.hideFFmpegCompile;

    /// <summary>
    /// Determines if the video conversions should use bitrate.
    /// </summary>
    public bool VideoUseBitrate { get; set; } = Converts.videoUseBitrate;
    /// <summary>
    /// The conversion bitrate of the video.
    /// </summary>
    public int VideoBitrate { get; set; } = Converts.videoBitrate;
    /// <summary>
    /// Determines if video conversions should use a preset.
    /// </summary>
    public bool VideoUsePreset { get; set; } = Converts.videoUsePreset;
    /// <summary>
    /// The conversion preset of the video.
    /// </summary>
    public int VideoPreset { get; set; } = Converts.videoPreset;
    /// <summary>
    /// Determines if video conversions should use a profile.
    /// </summary>
    public bool VideoUseProfile { get; set; } = Converts.videoUseProfile;
    /// <summary>
    /// The conversion profile of the video.
    /// </summary>
    public int VideoProfile { get; set; } = Converts.videoProfile;
    /// <summary>
    /// Determines if video conversions should use CRF.
    /// </summary>
    public bool VideoUseCRF { get; set; } = Converts.videoUseCRF;
    /// <summary>
    /// The conversion CRF of the video.
    /// </summary>
    public int VideoCRF { get; set; } = Converts.videoCRF;
    /// <summary>
    /// Determines if video conversions should have the faststart flag.
    /// </summary>
    public bool VideoFastStart { get; set; } = Converts.videoFastStart;

    /// <summary>
    /// Determines if audio conversions should use bitrate.
    /// </summary>
    public bool AudioUseBitrate { get; set; } = Converts.audioUseBitrate;
    /// <summary>
    /// The conversion bitrate of the audio.
    /// </summary>
    public int AudioBitrate { get; set; } = Converts.audioBitrate;

    /// <summary>
    /// The custom arguments to be used.
    /// </summary>
    public string CustomArguments { get; set; } = Saved.convertCustom;
    /// <summary>
    /// Whether to skip any argument generation including input/output.
    /// </summary>
    public bool FullCustomArguments { get; set; }

    public ConvertInfo(string Arguments) : this(string.Empty, string.Empty) {
        this.FullCustomArguments = true;
        this.CustomArguments = Arguments;
    }
}