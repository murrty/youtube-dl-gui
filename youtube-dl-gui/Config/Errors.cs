#nullable enable
namespace youtube_dl_gui;
internal static class Errors {
    private const string ConfigName = "Errors";

    static Errors() {
        Log.Write("Loading Error config.");
        fdetailedErrors = IniProvider.Read(detailedErrors, false, ConfigName);
        flogErrors = IniProvider.Read(logErrors, false, ConfigName);
        fsuppressErrors = IniProvider.Read(suppressErrors, false, ConfigName);
    }

    public static bool detailedErrors {
        get => fdetailedErrors;
        set {
            if (fdetailedErrors != value) {
                fdetailedErrors = value;
                IniProvider.Write(detailedErrors, ConfigName);
            }
        }
    }
    private static bool fdetailedErrors;

    public static bool logErrors {
        get => flogErrors;
        set {
            if (flogErrors != value) {
                flogErrors = value;
                IniProvider.Write(logErrors, ConfigName);
            }
        }
    }
    private static bool flogErrors;

    public static bool suppressErrors {
        get => fsuppressErrors;
        set {
            if (fsuppressErrors != value) {
                fsuppressErrors = value;
                IniProvider.Write(suppressErrors, ConfigName);
            }
        }
    }
    private static bool fsuppressErrors;
}