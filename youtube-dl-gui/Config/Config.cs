namespace youtube_dl_gui;

using System.Drawing;

internal class Config {
    public static volatile Config Settings;

    internal static readonly Point InvalidPoint = new(-32_000, -32_000);

    public Config_Initialization Initialization;
    public Config_Batch Batch;
    public Config_Converts Converts;
    public Config_Downloads Downloads;
    public Config_Errors Errors;
    public Config_General General;
    public Config_Saved Saved;

    public Config() {
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

    /// <summary>
    /// Checks if a point is a valid one to use.
    /// </summary>
    /// <param name="input">The <seealso cref="Point"/> value to validate.</param>
    /// <returns>If the input is a valid point.</returns>
    public static bool ValidPoint(Point input) {
        return input.X != InvalidPoint.X && input.Y != InvalidPoint.Y;
    }

    /// <summary>
    /// Checks if a size is a valid one to use.
    /// </summary>
    /// <param name="input">The <seealso cref="Size"/> value to validate.</param>
    /// <returns>If the input is a valid size.</returns>
    public static bool ValidSize(Size input) {
        return input.Width > 0 && input.Height > 0;
    }
}
