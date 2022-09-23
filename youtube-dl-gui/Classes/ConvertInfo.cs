namespace youtube_dl_gui;

public sealed class ConvertInfo {
    /// <summary>
    /// The input of the file to be converted.
    /// </summary>
    public string InputFile { get; set; } = null;
    /// <summary>
    /// The output of the converted file.
    /// </summary>
    public string OutputFile { get; set; } = null;
    /// <summary>
    /// Determines if the current conversion is in a batch conversion.
    /// </summary>
    public bool BatchConversion { get; set; } = false;
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
    public bool HideFFmpegCompile { get; set; } = Config.Settings.Converts.hideFFmpegCompile;
    
    /// <summary>
    /// Determines if the video conversions should use bitrate.
    /// </summary>
    public bool VideoUseBitrate { get; set; } = Config.Settings.Converts.videoUseBitrate;
    /// <summary>
    /// The conversion bitrate of the video.
    /// </summary>
    public int VideoBitrate { get; set; } = Config.Settings.Converts.videoBitrate;
    /// <summary>
    /// Determines if video conversions should use a preset.
    /// </summary>
    public bool VideoUsePreset { get; set; } = Config.Settings.Converts.videoUsePreset;
    /// <summary>
    /// The conversion preset of the video.
    /// </summary>
    public int VideoPreset { get; set; } = Config.Settings.Converts.videoPreset;
    /// <summary>
    /// Determines if video conversions should use a profile.
    /// </summary>
    public bool VideoUseProfile { get; set; } = Config.Settings.Converts.videoUseProfile;
    /// <summary>
    /// The conversion profile of the video.
    /// </summary>
    public int VideoProfile { get; set; } = Config.Settings.Converts.videoProfile;
    /// <summary>
    /// Determines if video conversions should use CRF.
    /// </summary>
    public bool VideoUseCRF { get; set; } = Config.Settings.Converts.videoUseCRF;
    /// <summary>
    /// The conversion CRF of the video.
    /// </summary>
    public int VideoCRF { get; set; } = Config.Settings.Converts.videoCRF;
    /// <summary>
    /// Determines if video conversions should have the faststart flag.
    /// </summary>
    public bool VideoFastStart { get; set; } = Config.Settings.Converts.videoFastStart;

    /// <summary>
    /// Determines if audio conversions should use bitrate.
    /// </summary>
    public bool AudioUseBitrate { get; set; } = Config.Settings.Converts.audioUseBitrate;
    /// <summary>
    /// The conversion bitrate of the audio.
    /// </summary>
    public int AudioBitrate { get; set; } = Config.Settings.Converts.audioBitrate;

    /// <summary>
    /// The custom arguments to be used.
    /// </summary>
    public string CustomArguments { get; set; } = Config.Settings.Saved.convertCustom;
    /// <summary>
    /// Whether to skip any argument generation including input/output.
    /// </summary>
    public bool FullCustomArguments { get; set; } = false;
}