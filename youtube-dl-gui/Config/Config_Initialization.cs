namespace youtube_dl_gui;

internal class Config_Initialization {
    public bool firstTime = true;
    public string LanguageFile = string.Empty;
    public Version SkippedVersion = Version.Empty;
    public Version SkippedBetaVersion = Version.Empty;

    private bool ffirstTime = true;
    private string fLanguageFile = string.Empty;
    private Version fSkippedVersion = Version.Empty;
    private Version fSkippedBetaVersion = Version.Empty;

    public void Load() {
        Log.Write("Loading Initialization config.");

        firstTime = ffirstTime = Ini.Read(firstTime, true);
        LanguageFile = fLanguageFile = Ini.Read(LanguageFile, string.Empty);
        fSkippedVersion = SkippedVersion = Ini.Read(SkippedVersion, Version.Empty);
        SkippedBetaVersion = fSkippedBetaVersion = Ini.Read(SkippedVersion, Version.Empty);
    }

    public void Save() {
        Log.Write("Saving Initialization config.");

        if (firstTime != ffirstTime)
            ffirstTime = Ini.Write(firstTime);
        if (LanguageFile != fLanguageFile)
            fLanguageFile = Ini.Write(LanguageFile);
        if (SkippedVersion != fSkippedVersion) 
            fSkippedVersion = Ini.Write(SkippedVersion);
        if (SkippedBetaVersion != fSkippedBetaVersion) 
            fSkippedBetaVersion = Ini.Write(SkippedBetaVersion);
    }
}