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
        Log.Write("Loading Error config.");
        detailedErrors = fdetailedErrors = IniProvider.Read(detailedErrors, false, ConfigName);
        logErrors = flogErrors = IniProvider.Read(logErrors, false, ConfigName);
        suppressErrors = fsuppressErrors = IniProvider.Read(suppressErrors, false, ConfigName);
    }

    public void Save() {
        Log.Write("Saving Error config.");
        if (detailedErrors != fdetailedErrors)
            fdetailedErrors = IniProvider.Write(detailedErrors, ConfigName);
        if (logErrors != flogErrors)
            flogErrors = IniProvider.Write(logErrors, ConfigName);
        if (suppressErrors != fsuppressErrors)
            fsuppressErrors = IniProvider.Write(suppressErrors, ConfigName);
    }
}