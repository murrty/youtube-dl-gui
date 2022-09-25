namespace youtube_dl_gui;

internal class Config_Converts {
    private const string ConfigName = "Converts";

    #region Properties
    public bool detectFiletype { get; set; }
    public bool clearOutput { get; set; }
    public bool clearInput { get; set; }
    public int videoBitrate { get; set; }
    public int videoPreset { get; set; }
    public int videoProfile { get; set; }
    public int videoCRF { get; set; }
    public bool videoFastStart { get; set; }
    public bool hideFFmpegCompile { get; set; }
    public int audioBitrate { get; set; }
    public bool videoUseBitrate { get; set; }
    public bool videoUsePreset { get; set; }
    public bool videoUseProfile { get; set; }
    public bool videoUseCRF { get; set; }
    public bool audioUseBitrate { get; set; }
    public bool CloseAfterFinish { get; set; }

    private bool fdetectFiletype { get; set; }
    private bool fclearOutput { get; set; }
    private bool fclearInput { get; set; }
    private int fvideoBitrate { get; set; }
    private int fvideoPreset { get; set; }
    private int fvideoProfile { get; set; }
    private int fvideoCRF { get; set; }
    private bool fvideoFastStart { get; set; }
    private bool fhideFFmpegCompile { get; set; }
    private int faudioBitrate { get; set; }
    private bool fvideoUseBitrate { get; set; }
    private bool fvideoUsePreset { get; set; }
    private bool fvideoUseProfile { get; set; }
    private bool fvideoUseCRF { get; set; }
    private bool faudioUseBitrate { get; set; }
    private bool fCloseAfterFinish { get; set; }
    #endregion

    public void Load() {
        Log.Write("Loading Converter config.");

        detectFiletype = fdetectFiletype = IniProvider.Read(detectFiletype, true, ConfigName);
        clearOutput = fclearOutput = IniProvider.Read(clearOutput, false, ConfigName);
        clearInput = fclearInput = IniProvider.Read(clearInput, false, ConfigName);
        videoBitrate = fvideoBitrate = IniProvider.Read(videoBitrate, 7500, ConfigName);
        videoPreset = fvideoPreset = IniProvider.Read(videoPreset, 5, ConfigName);
        videoProfile = fvideoProfile = IniProvider.Read(videoProfile, 1, ConfigName);
        videoCRF = fvideoCRF = IniProvider.Read(videoCRF, 8, ConfigName);
        videoFastStart = fvideoFastStart = IniProvider.Read(videoFastStart, false, ConfigName);
        hideFFmpegCompile = fhideFFmpegCompile = IniProvider.Read(hideFFmpegCompile, false, ConfigName);
        audioBitrate = faudioBitrate = IniProvider.Read(audioBitrate, 256, ConfigName);
        videoUseBitrate = fvideoUseBitrate = IniProvider.Read(videoUseBitrate, false, ConfigName);
        videoUsePreset = fvideoUsePreset = IniProvider.Read(videoUsePreset, false, ConfigName);
        videoUseProfile = fvideoUseProfile = IniProvider.Read(videoUseProfile, false, ConfigName);
        videoUseCRF = fvideoUseCRF = IniProvider.Read(videoUseCRF, true, ConfigName);
        audioUseBitrate = faudioUseBitrate = IniProvider.Read(audioUseBitrate, true, ConfigName);
        CloseAfterFinish = fCloseAfterFinish = IniProvider.Read(CloseAfterFinish, false, ConfigName);
    }

    public void Save() {
        Log.Write("Saving Converter config.");

        if (detectFiletype != fdetectFiletype)
            fdetectFiletype = IniProvider.Write(detectFiletype, ConfigName);
        if (clearOutput != fclearOutput)
            fclearOutput = IniProvider.Write(clearOutput, ConfigName);
        if (clearInput != fclearInput)
            fclearInput = IniProvider.Write(clearInput, ConfigName);
        if (videoBitrate != fvideoBitrate)
            fvideoBitrate = IniProvider.Write(videoBitrate, ConfigName);
        if (videoPreset != fvideoPreset)
            fvideoPreset = IniProvider.Write(videoPreset, ConfigName);
        if (videoProfile != fvideoProfile)
            fvideoProfile = IniProvider.Write(videoProfile, ConfigName);
        if (videoCRF != fvideoCRF)
            fvideoCRF = IniProvider.Write(videoCRF, ConfigName);
        if (videoFastStart != fvideoFastStart)
            fvideoFastStart = IniProvider.Write(videoFastStart, ConfigName);
        if (hideFFmpegCompile != fhideFFmpegCompile)
            fhideFFmpegCompile = IniProvider.Write(hideFFmpegCompile, ConfigName);
        if (audioBitrate != faudioBitrate)
            faudioBitrate = IniProvider.Write(audioBitrate, ConfigName);
        if (videoUseBitrate != fvideoUseBitrate)
            fvideoUseBitrate = IniProvider.Write(videoUseBitrate, ConfigName);
        if (videoUsePreset != fvideoUsePreset)
            fvideoUsePreset = IniProvider.Write(videoUsePreset, ConfigName);
        if (videoUseProfile != fvideoUseProfile)
            fvideoUseProfile = IniProvider.Write(videoUseProfile, ConfigName);
        if (videoUseCRF != fvideoUseCRF)
            fvideoUseCRF = IniProvider.Write(videoUseCRF, ConfigName);
        if (audioUseBitrate != faudioUseBitrate)
            faudioUseBitrate = IniProvider.Write(audioUseBitrate, ConfigName);
        if (CloseAfterFinish != fCloseAfterFinish)
            fCloseAfterFinish = IniProvider.Write(CloseAfterFinish, ConfigName);
    }

}