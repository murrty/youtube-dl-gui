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

    public void Save() {
        if (detectFiletype != fdetectFiletype) {
            Ini.Write("detectFiletype", detectFiletype, ConfigName);
            fdetectFiletype = detectFiletype;
        }
        if (clearOutput != fclearOutput) {
            Ini.Write("clearOutput", clearOutput, ConfigName);
            fclearOutput = clearOutput;
        }
        if (clearInput != fclearInput) {
            Ini.Write("clearInput", clearInput, ConfigName);
            fclearInput = clearInput;
        }
        if (videoBitrate != fvideoBitrate) {
            Ini.Write("videoBitrate", videoBitrate, ConfigName);
            fvideoBitrate = videoBitrate;
        }
        if (videoPreset != fvideoPreset) {
            Ini.Write("videoPreset", videoPreset, ConfigName);
            fvideoPreset = videoPreset;
        }
        if (videoProfile != fvideoProfile) {
            Ini.Write("videoProfile", videoProfile, ConfigName);
            fvideoProfile = videoProfile;
        }
        if (videoCRF != fvideoCRF) {
            Ini.Write("videoCRF", videoCRF, ConfigName);
            fvideoCRF = videoCRF;
        }
        if (videoFastStart != fvideoFastStart) {
            Ini.Write("videoFastStart", videoFastStart, ConfigName);
            fvideoFastStart = videoFastStart;
        }
        if (hideFFmpegCompile != fhideFFmpegCompile) {
            Ini.Write("hideFFmpegCompile", hideFFmpegCompile, ConfigName);
            fhideFFmpegCompile = hideFFmpegCompile;
        }
        if (audioBitrate != faudioBitrate) {
            Ini.Write("audioBitrate", audioBitrate, ConfigName);
            faudioBitrate = audioBitrate;
        }
        if (videoUseBitrate != fvideoUseBitrate) {
            Ini.Write("videoUseBitrate", videoUseBitrate, ConfigName);
            fvideoUseBitrate = videoUseBitrate;
        }
        if (videoUsePreset != fvideoUsePreset) {
            Ini.Write("videoUsePreset", videoUsePreset, ConfigName);
            fvideoUsePreset = videoUsePreset;
        }
        if (videoUseProfile != fvideoUseProfile) {
            Ini.Write("videoUseProfile", videoUseProfile, ConfigName);
            fvideoUseProfile = videoUseProfile;
        }
        if (videoUseCRF != fvideoUseCRF) {
            Ini.Write("videoUseCRF", videoUseCRF, ConfigName);
            fvideoUseCRF = videoUseCRF;
        }
        if (audioUseBitrate != faudioUseBitrate) {
            Ini.Write("audioUseBitrate", audioUseBitrate, ConfigName);
            faudioUseBitrate = audioUseBitrate;
        }
        if (CloseAfterFinish != fCloseAfterFinish) {
            Ini.Write("CloseAfterFinish", CloseAfterFinish, ConfigName);
            fCloseAfterFinish = CloseAfterFinish;
        }
    }

    public void Load() {
        if (Ini.KeyExists("detectFiletype", ConfigName)) {
            detectFiletype = fdetectFiletype = Ini.ReadBool("detectFiletype", ConfigName);
        }
        if (Ini.KeyExists("clearOutput", ConfigName)) {
            clearOutput = fclearOutput = Ini.ReadBool("clearOutput", ConfigName);
        }
        if (Ini.KeyExists("clearInput", ConfigName)) {
            clearInput = fclearInput = Ini.ReadBool("clearInput", ConfigName);
        }
        if (Ini.KeyExists("videoBitrate", ConfigName)) {
            videoBitrate = fvideoBitrate = Ini.ReadInt("videoBitrate", ConfigName);
        }
        if (Ini.KeyExists("videoPreset", ConfigName)) {
            videoPreset = fvideoPreset = Ini.ReadInt("videoPreset", ConfigName);
        }
        if (Ini.KeyExists("videoProfile", ConfigName)) {
            videoProfile = fvideoProfile = Ini.ReadInt("videoProfile", ConfigName);
        }
        if (Ini.KeyExists("videoCRF", ConfigName)) {
            videoCRF = fvideoCRF = Ini.ReadInt("videoCRF", ConfigName);
        }
        if (Ini.KeyExists("videoFastStart", ConfigName)) {
            videoFastStart = fvideoFastStart = Ini.ReadBool("videoFastStart", ConfigName);
        }
        if (Ini.KeyExists("hideFFmpegCompile", ConfigName)) {
            hideFFmpegCompile = fhideFFmpegCompile = Ini.ReadBool("hideFFmpegCompile", ConfigName);
        }
        if (Ini.KeyExists("audioBitrate", ConfigName)) {
            audioBitrate = faudioBitrate = Ini.ReadInt("audioBitrate", ConfigName);
        }
        if (Ini.KeyExists("videoUseBitrate", ConfigName)) {
            videoUseBitrate = fvideoUseBitrate = Ini.ReadBool("videoUseBitrate", ConfigName);
        }
        if (Ini.KeyExists("videoUsePreset", ConfigName)) {
            videoUsePreset = fvideoUsePreset = Ini.ReadBool("videoUsePreset", ConfigName);
        }
        if (Ini.KeyExists("videoUseProfile", ConfigName)) {
            videoUseProfile = fvideoUseProfile = Ini.ReadBool("videoUseProfile", ConfigName);
        }
        if (Ini.KeyExists("videoUseCRF", ConfigName)) {
            videoUseCRF = fvideoUseCRF = Ini.ReadBool("videoUseCRF", ConfigName);
        }
        if (Ini.KeyExists("audioUseBitrate", ConfigName)) {
            audioUseBitrate = faudioUseBitrate = Ini.ReadBool("audioUseBitrate", ConfigName);
        }
        if (Ini.KeyExists("CloseAfterFinish", ConfigName)) {
            CloseAfterFinish = fCloseAfterFinish = Ini.ReadBool("CloseAfterFinish", ConfigName);
        }
    }

}