namespace youtube_dl_gui;

internal static class Initialization {

    static Initialization() {
        Log.Write("Loading Initialization config.");

        ffirstTime = IniProvider.Read(firstTime, true);
        fLanguageFile = IniProvider.Read(LanguageFile, string.Empty);
        fSkippedVersion = IniProvider.Read(SkippedVersion, Version.Empty);
        fSkippedBetaVersion = IniProvider.Read(SkippedVersion, Version.Empty);
        ScreenshotMode = IniProvider.Read(ScreenshotMode, false);
        WritePercentageToConsole = IniProvider.Read(WritePercentageToConsole, false);
    }

    public static bool firstTime {
        get => ffirstTime;
        set {
            if (ffirstTime != value) {
                ffirstTime = value;
                IniProvider.Write(firstTime);
            }
        }
    }
    private static bool ffirstTime;

    public static string LanguageFile {
        get => fLanguageFile;
        set {
            if (fLanguageFile != value) {
                fLanguageFile = value;
                IniProvider.Write(LanguageFile);
            }
        }
    }
    private static string fLanguageFile;

    public static Version SkippedVersion {
        get => fSkippedVersion;
        set {
            if (fSkippedVersion != value) {
                fSkippedVersion = value;
                IniProvider.Write(SkippedVersion);
            }
        }
    }
    private static Version fSkippedVersion;

    public static Version SkippedBetaVersion {
        get => fSkippedBetaVersion;
        set {
            if (fSkippedBetaVersion != value) {
                fSkippedBetaVersion = value;
                IniProvider.Write(SkippedBetaVersion);
            }
        }
    }
    private static Version fSkippedBetaVersion;

    public static bool ScreenshotMode { get; set; }

    public static bool WritePercentageToConsole { get; set; }

}