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

        detectFiletype = fdetectFiletype = Ini.Read(detectFiletype, true, ConfigName);
        clearOutput = fclearOutput = Ini.Read(clearOutput, false, ConfigName);
        clearInput = fclearInput = Ini.Read(clearInput, false, ConfigName);
        videoBitrate = fvideoBitrate = Ini.Read(videoBitrate, 7500, ConfigName);
        videoPreset = fvideoPreset = Ini.Read(videoPreset, 5, ConfigName);
        videoProfile = fvideoProfile = Ini.Read(videoProfile, 1, ConfigName);
        videoCRF = fvideoCRF = Ini.Read(videoCRF, 8, ConfigName);
        videoFastStart = fvideoFastStart = Ini.Read(videoFastStart, false, ConfigName);
        hideFFmpegCompile = fhideFFmpegCompile = Ini.Read(hideFFmpegCompile, false, ConfigName);
        audioBitrate = faudioBitrate = Ini.Read(audioBitrate, 256, ConfigName);
        videoUseBitrate = fvideoUseBitrate = Ini.Read(videoUseBitrate, false, ConfigName);
        videoUsePreset = fvideoUsePreset = Ini.Read(videoUsePreset, false, ConfigName);
        videoUseProfile = fvideoUseProfile = Ini.Read(videoUseProfile, false, ConfigName);
        videoUseCRF = fvideoUseCRF = Ini.Read(videoUseCRF, true, ConfigName);
        audioUseBitrate = faudioUseBitrate = Ini.Read(audioUseBitrate, true, ConfigName);
        CloseAfterFinish = fCloseAfterFinish = Ini.Read(CloseAfterFinish, false, ConfigName);
    }

    public void Save() {
        Log.Write("Saving Converter config.");

        if (detectFiletype != fdetectFiletype)
            fdetectFiletype = Ini.Write(detectFiletype, ConfigName);
        if (clearOutput != fclearOutput)
            fclearOutput = Ini.Write(clearOutput, ConfigName);
        if (clearInput != fclearInput)
            fclearInput = Ini.Write(clearInput, ConfigName);
        if (videoBitrate != fvideoBitrate)
            fvideoBitrate = Ini.Write(videoBitrate, ConfigName);
        if (videoPreset != fvideoPreset)
            fvideoPreset = Ini.Write(videoPreset, ConfigName);
        if (videoProfile != fvideoProfile)
            fvideoProfile = Ini.Write(videoProfile, ConfigName);
        if (videoCRF != fvideoCRF)
            fvideoCRF = Ini.Write(videoCRF, ConfigName);
        if (videoFastStart != fvideoFastStart)
            fvideoFastStart = Ini.Write(videoFastStart, ConfigName);
        if (hideFFmpegCompile != fhideFFmpegCompile)
            fhideFFmpegCompile = Ini.Write(hideFFmpegCompile, ConfigName);
        if (audioBitrate != faudioBitrate)
            faudioBitrate = Ini.Write(audioBitrate, ConfigName);
        if (videoUseBitrate != fvideoUseBitrate)
            fvideoUseBitrate = Ini.Write(videoUseBitrate, ConfigName);
        if (videoUsePreset != fvideoUsePreset)
            fvideoUsePreset = Ini.Write(videoUsePreset, ConfigName);
        if (videoUseProfile != fvideoUseProfile)
            fvideoUseProfile = Ini.Write(videoUseProfile, ConfigName);
        if (videoUseCRF != fvideoUseCRF)
            fvideoUseCRF = Ini.Write(videoUseCRF, ConfigName);
        if (audioUseBitrate != faudioUseBitrate)
            faudioUseBitrate = Ini.Write(audioUseBitrate, ConfigName);
        if (CloseAfterFinish != fCloseAfterFinish)
            fCloseAfterFinish = Ini.Write(CloseAfterFinish, ConfigName);
    }

}