namespace youtube_dl_gui;

internal class Config_Initialization {
    public bool firstTime = true;
    public string LanguageFile = string.Empty;
    public Version SkippedVersion = Version.Empty;
    public Version SkippedBetaVersion = Version.Empty;
    public bool AboutFormDialog = true;

    private bool ffirstTime = true;
    private string fLanguageFile = string.Empty;
    private Version fSkippedVersion = Version.Empty;
    private Version fSkippedBetaVersion = Version.Empty;

    public void Load() {
        Log.Write("Loading Initialization config.");

        firstTime = ffirstTime = IniProvider.Read(firstTime, true);
        LanguageFile = fLanguageFile = IniProvider.Read(LanguageFile, string.Empty);
        fSkippedVersion = SkippedVersion = IniProvider.Read(SkippedVersion, Version.Empty);
        SkippedBetaVersion = fSkippedBetaVersion = IniProvider.Read(SkippedVersion, Version.Empty);
        AboutFormDialog = IniProvider.Read(AboutFormDialog, true);
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