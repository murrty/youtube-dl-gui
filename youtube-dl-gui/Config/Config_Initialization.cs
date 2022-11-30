namespace youtube_dl_gui;

internal class Config_Initialization {
    #region Properties
    public bool firstTime { get; set; }
    public string LanguageFile { get; set; }
    public Version SkippedVersion { get; set; }
    public Version SkippedBetaVersion { get; set; }
    public bool ScreenshotMode { get; set; }
    public bool WritePercentageToConsole { get; set; }

    private bool ffirstTime { get; set; }
    private string fLanguageFile { get; set; }
    private Version fSkippedVersion { get; set; }
    private Version fSkippedBetaVersion { get; set; }
    #endregion

    public void Load() {
        Log.Write("Loading Initialization config.");

        firstTime = ffirstTime = IniProvider.Read(firstTime, true);
        LanguageFile = fLanguageFile = IniProvider.Read(LanguageFile, string.Empty);
        fSkippedVersion = SkippedVersion = IniProvider.Read(SkippedVersion, Version.Empty);
        SkippedBetaVersion = fSkippedBetaVersion = IniProvider.Read(SkippedVersion, Version.Empty);
        ScreenshotMode = IniProvider.Read(ScreenshotMode, false);
        WritePercentageToConsole = IniProvider.Read(WritePercentageToConsole, false);
    }

    public void Save() {
        Log.Write("Saving Initialization config.");

        if (firstTime != ffirstTime)
            ffirstTime = IniProvider.Write(firstTime);
        if (LanguageFile != fLanguageFile)
            fLanguageFile = IniProvider.Write(LanguageFile);
        if (SkippedVersion != fSkippedVersion) 
            fSkippedVersion = IniProvider.Write(SkippedVersion);
        if (SkippedBetaVersion != fSkippedBetaVersion) 
            fSkippedBetaVersion = IniProvider.Write(SkippedBetaVersion);
    }
}