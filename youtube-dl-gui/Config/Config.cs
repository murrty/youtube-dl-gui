namespace youtube_dl_gui;
internal class Config {
    public static volatile Config Settings;

    public Config_Initialization Initialization;
    public Config_Batch Batch;
    public Config_Converts Converts;
    public Config_Downloads Downloads;
    public Config_Errors Errors;
    public Config_General General;
    public Config_Saved Saved;

    public Config() {
        if (System.IO.File.Exists(Environment.CurrentDirectory + "\\settings.ini")
        && !System.IO.File.Exists(Environment.CurrentDirectory + "\\youtube-dl-gui.ini"))
            System.IO.File.Move(Environment.CurrentDirectory + "\\settings.ini", Environment.CurrentDirectory + "\\youtube-dl-gui.ini");

        Initialization = new();
        Batch = new();
        Converts = new();
        Downloads = new();
        Errors = new();
        General = new();
        Saved = new();
    }

    public void Load(ConfigType Type) {
        switch (Type) {
            case ConfigType.All:
                Batch.Load();
                Converts.Load();
                Downloads.Load();
                Errors.Load();
                General.Load();
                Saved.Load();
                break;

            case ConfigType.Initialization:
                Initialization.Load();
                break;

            case ConfigType.Batch:
                Batch.Load();
                break;

            case ConfigType.Converts:
                Converts.Load();
                break;

            case ConfigType.Downloads:
                Downloads.Load();
                break;

            case ConfigType.Errors:
                Errors.Load();
                break;

            case ConfigType.General:
                General.Load();
                break;

            case ConfigType.Saved:
                Saved.Load();
                break;
        }
    }

    public void Save(ConfigType Type) {
        switch (Type) {
            case ConfigType.All:
                Batch.Save();
                Converts.Save();
                Downloads.Save();
                Errors.Save();
                General.Save();
                Saved.Save();
                break;

            case ConfigType.Initialization:
                Initialization.Save();
                break;

            case ConfigType.Batch:
                Batch.Save();
                break;

            case ConfigType.Converts:
                Converts.Save();
                break;

            case ConfigType.Downloads:
                Downloads.Save();
                break;

            case ConfigType.Errors:
                Errors.Save();
                break;

            case ConfigType.General:
                General.Save();
                break;

            case ConfigType.Saved:
                Saved.Save();
                break;
        }
    }
}