namespace youtube_dl_gui;

internal class Config_Initialization {
    public string LanguageFile = string.Empty;
    public bool firstTime = true;
    public updater.Version SkippedVersion = updater.Version.Empty;
    public updater.Version SkippedBetaVersion = updater.Version.Empty;

    private string fLanguageFile = string.Empty;
    private bool ffirstTime = true;
    private updater.Version fSkippedVersion = updater.Version.Empty;
    private updater.Version fSkippedBetaVersion = updater.Version.Empty;

    public void Load() {
        if (Ini.KeyExists("firstTime")) {
            firstTime = ffirstTime = Ini.ReadBool("firstTime");
        }

        if (Ini.KeyExists("LanguageFile")) {
            LanguageFile = fLanguageFile = Ini.ReadString("LanguageFile");
        }

        if (Ini.KeyExists("SkippedVersion")) {
            if (updater.Version.TryParse(Ini.ReadString("SkippedVersion"), out SkippedVersion)) {
                fSkippedVersion = SkippedVersion;
            }
        }
        if (Ini.KeyExists("SkippedBetaVersion")) {
            if (updater.Version.TryParse(Ini.ReadString("SkippedBetaVersion"), out SkippedBetaVersion)) {
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