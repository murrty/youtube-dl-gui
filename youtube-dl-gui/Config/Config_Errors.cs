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
        detailedErrors = fdetailedErrors = Ini.Read(detailedErrors, false, ConfigName);
        logErrors = flogErrors = Ini.Read(logErrors, false, ConfigName);
        suppressErrors = fsuppressErrors = Ini.Read(suppressErrors, false, ConfigName);
    }

    public void Save() {
        Log.Write("Saving Error config.");
        if (detailedErrors != fdetailedErrors)
            fdetailedErrors = Ini.Write(detailedErrors, ConfigName);
        if (logErrors != flogErrors)
            flogErrors = Ini.Write(logErrors, ConfigName);
        if (suppressErrors != fsuppressErrors)
            fsuppressErrors = Ini.Write(suppressErrors, ConfigName);
    }
}