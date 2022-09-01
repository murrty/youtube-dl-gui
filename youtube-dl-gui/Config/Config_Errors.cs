namespace youtube_dl_gui;

internal class Config_Errors {
    private const string ConfigName = "Errors";

    public bool detailedErrors = false;
    public bool logErrors = false;
    public bool suppressErrors = false;

    private bool fdetailedErrors = false;
    private bool flogErrors = false;
    private bool fsuppressErrors = false;

    public void Load() {
        if (Ini.KeyExists("detailedErrors", ConfigName)) {
            detailedErrors = fdetailedErrors = Ini.ReadBool("detailedErrors", ConfigName);
        }
        if (Ini.KeyExists("logErrors", ConfigName)) {
            logErrors = flogErrors = Ini.ReadBool("logErrors", ConfigName);
        }
        if (Ini.KeyExists("suppressErrors", ConfigName)) {
            suppressErrors = fsuppressErrors = Ini.ReadBool("suppressErrors", ConfigName);
        }

    }

    public void Save() {
        if (detailedErrors != fdetailedErrors) {
            Ini.Write("detailedErrors", detailedErrors, ConfigName);
            fdetailedErrors = detailedErrors;
        }

        if (logErrors != flogErrors) {
            Ini.Write("logErrors", logErrors, ConfigName);
            flogErrors = logErrors;
        }

        if (suppressErrors != fsuppressErrors) {
            Ini.Write("suppressErrors", suppressErrors, ConfigName);
            fsuppressErrors = suppressErrors;
        }
    }
}