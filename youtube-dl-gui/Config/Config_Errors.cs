namespace youtube_dl_gui;

internal class Config_Errors {
    private const string ConfigName = "Errors";

    #region Properties
    public bool detailedErrors { get; set; }
    public bool logErrors { get; set; }
    public bool suppressErrors { get; set; }

    private bool fdetailedErrors { get; set; }
    private bool flogErrors { get; set; }
    private bool fsuppressErrors { get; set; }
    #endregion

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