namespace youtube_dl_gui;

internal class Config_Converts {
    private const string ConfigName = "Converts";

    #region Variables
    public bool detectFiletype = true;
    public bool clearOutput = false;
    public bool clearInput = false;
    public int videoBitrate = 7500;
    public int videoPreset = 5;
    public int videoProfile = 1;
    public int videoCRF = 8;
    public bool videoFastStart = false;
    public bool hideFFmpegCompile = false;
    public int audioBitrate = 256;
    public bool videoUseBitrate = false;
    public bool videoUsePreset = false;
    public bool videoUseProfile = false;
    public bool videoUseCRF = true;
    public bool audioUseBitrate = true;
    public bool CloseAfterFinish = false;

    private bool fdetectFiletype = true;
    private bool fclearOutput = false;
    private bool fclearInput = false;
    private int fvideoBitrate = 7500;
    private int fvideoPreset = 5;
    private int fvideoProfile = 1;
    private int fvideoCRF = 8;
    private bool fvideoFastStart = false;
    private bool fhideFFmpegCompile = false;
    private int faudioBitrate = 256;
    private bool fvideoUseBitrate = false;
    private bool fvideoUsePreset = false;
    private bool fvideoUseProfile = false;
    private bool fvideoUseCRF = true;
    private bool faudioUseBitrate = true;
    private bool fCloseAfterFinish = false;
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