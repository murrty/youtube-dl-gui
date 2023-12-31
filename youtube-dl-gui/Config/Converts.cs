#nullable enable
namespace youtube_dl_gui;
internal static class Converts {
    private const string ConfigName = "Converts";

    static Converts() {
        Log.Write("Loading Converter config.");

        fdetectFiletype = IniProvider.Read(detectFiletype, true, ConfigName);
        fclearOutput = IniProvider.Read(clearOutput, false, ConfigName);
        fclearInput = IniProvider.Read(clearInput, false, ConfigName);
        fvideoBitrate = IniProvider.Read(videoBitrate, 7500, ConfigName);
        fvideoPreset = IniProvider.Read(videoPreset, 5, ConfigName);
        fvideoProfile = IniProvider.Read(videoProfile, 1, ConfigName);
        fvideoCRF = IniProvider.Read(videoCRF, 8, ConfigName);
        fvideoFastStart = IniProvider.Read(videoFastStart, false, ConfigName);
        fhideFFmpegCompile = IniProvider.Read(hideFFmpegCompile, false, ConfigName);
        faudioBitrate = IniProvider.Read(audioBitrate, 256, ConfigName);
        fvideoUseBitrate = IniProvider.Read(videoUseBitrate, false, ConfigName);
        fvideoUsePreset = IniProvider.Read(videoUsePreset, false, ConfigName);
        fvideoUseProfile = IniProvider.Read(videoUseProfile, false, ConfigName);
        fvideoUseCRF = IniProvider.Read(videoUseCRF, true, ConfigName);
        faudioUseBitrate = IniProvider.Read(audioUseBitrate, true, ConfigName);
        fCloseAfterFinish = IniProvider.Read(CloseAfterFinish, false, ConfigName);
    }

    public static bool detectFiletype {
        get => fdetectFiletype;
        set {
            if (fdetectFiletype != value) {
                fdetectFiletype = value;
                IniProvider.Write(detectFiletype, ConfigName);
            }
        }
    }
    private static bool fdetectFiletype;

    public static bool clearOutput {
        get => fclearOutput;
        set {
            if (fclearOutput != value) {
                fclearOutput = value;
                IniProvider.Write(clearOutput, ConfigName);
            }
        }
    }
    private static bool fclearOutput;

    public static bool clearInput {
        get => fclearInput;
        set {
            if (fclearInput != value) {
                fclearInput = value;
                IniProvider.Write(clearInput, ConfigName);
            }
        }
    }
    private static bool fclearInput;

    public static int videoBitrate {
        get => fvideoBitrate;
        set {
            if (fvideoBitrate != value) {
                fvideoBitrate = value;
                IniProvider.Write(videoBitrate, ConfigName);
            }
        }
    }
    private static int fvideoBitrate;

    public static int videoPreset {
        get => fvideoPreset;
        set {
            if (fvideoPreset != value) {
                fvideoPreset = value;
                IniProvider.Write(videoPreset, ConfigName);
            }
        }
    }
    private static int fvideoPreset;

    public static int videoProfile {
        get => fvideoProfile;
        set {
            if (fvideoProfile != value) {
                fvideoProfile = value;
                IniProvider.Write(videoProfile, ConfigName);
            }
        }
    }
    private static int fvideoProfile;

    public static int videoCRF {
        get => fvideoCRF;
        set {
            if (fvideoCRF != value) {
                fvideoCRF = value;
                IniProvider.Write(videoCRF, ConfigName);
            }
        }
    }
    private static int fvideoCRF;

    public static bool videoFastStart {
        get => fvideoFastStart;
        set {
            if (fvideoFastStart != value) {
                fvideoFastStart = value;
                IniProvider.Write(videoFastStart, ConfigName);
            }
        }
    }
    private static bool fvideoFastStart;

    public static bool hideFFmpegCompile {
        get => fhideFFmpegCompile;
        set {
            if (fhideFFmpegCompile != value) {
                fhideFFmpegCompile = value;
                IniProvider.Write(hideFFmpegCompile, ConfigName);
            }
        }
    }
    private static bool fhideFFmpegCompile;

    public static int audioBitrate {
        get => faudioBitrate;
        set {
            if (faudioBitrate != value) {
                faudioBitrate = value;
                IniProvider.Write(audioBitrate, ConfigName);
            }
        }
    }
    private static int faudioBitrate;

    public static bool videoUseBitrate {
        get => fvideoUseBitrate;
        set {
            if (fvideoUseBitrate != value) {
                fvideoUseBitrate = value;
                IniProvider.Write(videoUseBitrate, ConfigName);
            }
        }
    }
    private static bool fvideoUseBitrate;

    public static bool videoUsePreset {
        get => fvideoUsePreset;
        set {
            if (fvideoUsePreset != value) {
                fvideoUsePreset = value;
                IniProvider.Write(videoUsePreset, ConfigName);
            }
        }
    }
    private static bool fvideoUsePreset;

    public static bool videoUseProfile {
        get => fvideoUseProfile;
        set {
            if (fvideoUseProfile != value) {
                fvideoUseProfile = value;
                IniProvider.Write(videoUseProfile, ConfigName);
            }
        }
    }
    private static bool fvideoUseProfile;

    public static bool videoUseCRF {
        get => fvideoUseCRF;
        set {
            if (fvideoUseCRF != value) {
                fvideoUseCRF = value;
                IniProvider.Write(videoUseCRF, ConfigName);
            }
        }
    }
    private static bool fvideoUseCRF;

    public static bool audioUseBitrate {
        get => faudioUseBitrate;
        set {
            if (faudioUseBitrate != value) {
                faudioUseBitrate = value;
                IniProvider.Write(audioUseBitrate, ConfigName);
            }
        }
    }
    private static bool faudioUseBitrate;

    public static bool CloseAfterFinish {
        get => fCloseAfterFinish;
        set {
            if (fCloseAfterFinish != value) {
                fCloseAfterFinish = value;
                IniProvider.Write(CloseAfterFinish, ConfigName);
            }
        }
    }
    private static bool fCloseAfterFinish;
}