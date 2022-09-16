namespace youtube_dl_gui;

public sealed class ConvertInfo {
    /// <summary>
    /// The input of the file to be converted.
    /// </summary>
    public string InputFile = null;
    /// <summary>
    /// The output of the converted file.
    /// </summary>
    public string OutputFile = null;
    /// <summary>
    /// Determines if the current conversion is in a batch conversion.
    /// </summary>
    public bool BatchConversion = false;
    /// <summary>
    /// The conversion type, used for user-specified settings.
    /// </summary>
    public ConversionType Type = ConversionType.Unspecified;
    /// <summary>
    /// The status of the current conversion.
    /// </summary>
    public ConversionStatus Status = ConversionStatus.None;

    /// <summary>
    /// Hides the compile information from ffmpeg.
    /// </summary>
    public bool HideFFmpegCompile = Config.Settings.Converts.hideFFmpegCompile;
    
    /// <summary>
    /// Determines if the video conversions should use bitrate.
    /// </summary>
    public bool VideoUseBitrate = Config.Settings.Converts.videoUseBitrate;
    /// <summary>
    /// The conversion bitrate of the video.
    /// </summary>
    public int VideoBitrate = Config.Settings.Converts.videoBitrate;
    /// <summary>
    /// Determines if video conversions should use a preset.
    /// </summary>
    public bool VideoUsePreset = Config.Settings.Converts.videoUsePreset;
    /// <summary>
    /// The conversion preset of the video.
    /// </summary>
    public int VideoPreset = Config.Settings.Converts.videoPreset;
    /// <summary>
    /// Determines if video conversions should use a profile.
    /// </summary>
    public bool VideoUseProfile = Config.Settings.Converts.videoUseProfile;
    /// <summary>
    /// The conversion profile of the video.
    /// </summary>
    public int VideoProfile = Config.Settings.Converts.videoProfile;
    /// <summary>
    /// Determines if video conversions should use CRF.
    /// </summary>
    public bool VideoUseCRF = Config.Settings.Converts.videoUseCRF;
    /// <summary>
    /// The conversion CRF of the video.
    /// </summary>
    public int VideoCRF = Config.Settings.Converts.videoCRF;
    /// <summary>
    /// Determines if video conversions should have the faststart flag.
    /// </summary>
    public bool VideoFastStart = Config.Settings.Converts.videoFastStart;

    /// <summary>
    /// Determines if audio conversions should use bitrate.
    /// </summary>
    public bool AudioUseBitrate = Config.Settings.Converts.audioUseBitrate;
    /// <summary>
    /// The conversion bitrate of the audio.
    /// </summary>
    public int AudioBitrate = Config.Settings.Converts.audioBitrate;

    /// <summary>
    /// The custom arguments to be used.
    /// </summary>
    public string CustomArguments = Config.Settings.Saved.convertCustom;
    /// <summary>
    /// Whether to skip any argument generation including input/output.
    /// </summary>
    public bool FullCustomArguments = false;
}