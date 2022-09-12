namespace youtube_dl_gui;

internal class Config_Initialization {
    public string LanguageFile = string.Empty;
    public bool firstTime = true;
    public Version SkippedVersion = Version.Empty;
    public Version SkippedBetaVersion = Version.Empty;

    private string fLanguageFile = string.Empty;
    private bool ffirstTime = true;
    private Version fSkippedVersion = Version.Empty;
    private Version fSkippedBetaVersion = Version.Empty;

    public void Load() {
        if (Ini.KeyExists("firstTime")) {
            firstTime = ffirstTime = Ini.ReadBool("firstTime");
        }

        if (Ini.KeyExists("LanguageFile")) {
            LanguageFile = fLanguageFile = Ini.ReadString("LanguageFile");
        }

        if (Ini.KeyExists("SkippedVersion")) {
            if (Version.TryParse(Ini.ReadString("SkippedVersion"), out SkippedVersion)) {
                fSkippedVersion = SkippedVersion;
            }
        }
        if (Ini.KeyExists("SkippedBetaVersion")) {
            if (Version.TryParse(Ini.ReadString("SkippedBetaVersion"), out SkippedBetaVersion)) {
                fSkippedBetaVersion = SkippedBetaVersion;
            }
        }
    }

    public void Save() {
        if (firstTime != ffirstTime) {
            Ini.Write("firstTime", firstTime);
            ffirstTime = firstTime;
        }

        if (LanguageFile != fLanguageFile) {
            Ini.Write("LanguageFile", LanguageFile);
            fLanguageFile = LanguageFile;
        }

        if (SkippedVersion != fSkippedVersion) {
            Ini.Write("SkippedVersion", SkippedVersion.ToString());
            fSkippedVersion = SkippedVersion;
        }

        if (SkippedBetaVersion != fSkippedBetaVersion) {
            Ini.Write("SkippedBetaVersion", SkippedBetaVersion.ToString());
            fSkippedBetaVersion = SkippedBetaVersion;
        }
    }
}