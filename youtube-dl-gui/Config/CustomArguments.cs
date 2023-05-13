namespace youtube_dl_gui;

// TODO: implement

/// <summary>
/// Manages the custom arguments the user provides.
/// </summary>
internal static class CustomArguments {

    /// <summary>
    /// Represends a list of all used youtube-dl arguments.
    /// </summary>
    public static List<string> YtdlArguments { get; } = new();
    /// <summary>
    /// Represents the last used youtube-dl argument by the user.
    /// </summary>
    public static string LastUsedYtdlArgument { get; set; } = string.Empty;

    /// <summary>
    /// Represends a list of all used ffmpeg arguments.
    /// </summary>
    public static List<string> FfmpegArguments { get; } = new();
    /// <summary>
    /// Represents the last used ffmpeg argument by the user.
    /// </summary>
    public static string LastUsedFfmpegArgument { get; set; } = string.Empty;

    /// <summary>
    /// Loads the custom arguments.
    /// </summary>
    public static void Load() {
        if (!Config.Settings.Saved.DownloadCustomArguments.IsNullEmptyWhitespace()) {
            HashSet<string> Arguments = new();
            string[] Args = Config.Settings.Saved.DownloadCustomArguments.Trim('|', ' ').Split('|');
            Args.For((Arg) => Arguments.Add(Arg));

            foreach (string Arg in Arguments) {
                if (Arg.IsNullEmptyWhitespace())
                    continue;

                YtdlArguments.Add(Arg);
            }

            int Index = Config.Settings.Saved.CustomArgumentsIndex;
            if (Index > -1 && Index < YtdlArguments.Count)
                LastUsedYtdlArgument = YtdlArguments[Index];
        }

        if (!Config.Settings.Saved.ConvertCustomArguments.IsNullEmptyWhitespace()) {
            HashSet<string> Arguments = new();
            string[] Args = Config.Settings.Saved.ConvertCustomArguments.Trim('|', ' ').Split('|');
            Args.For((Arg) => Arguments.Add(Arg));

            foreach (string Arg in Arguments) {
                if (Arg.IsNullEmptyWhitespace())
                    continue;

                FfmpegArguments.Add(Arg);
            }

            int Index = Config.Settings.Saved.ConvertCustomArgumentsIndex;
            if (Index > -1 && Index < FfmpegArguments.Count)
                LastUsedFfmpegArgument = FfmpegArguments[Index];
        }
    }
    /// <summary>
    /// Saves the custom arguments.
    /// </summary>
    public static void Save() {
        if (YtdlArguments.Count > 0) {
            Config.Settings.Saved.DownloadCustomArguments = YtdlArguments.Join("|");
            Config.Settings.Saved.CustomArgumentsIndex = YtdlArguments.IndexOf(LastUsedYtdlArgument);
        }
        else {
            Config.Settings.Saved.DownloadCustomArguments = null;
            Config.Settings.Saved.CustomArgumentsIndex = -1;
        }

        if (FfmpegArguments.Count > 0) {
            Config.Settings.Saved.ConvertCustomArguments = FfmpegArguments.Join("|");
            Config.Settings.Saved.ConvertCustomArgumentsIndex = FfmpegArguments.IndexOf(LastUsedFfmpegArgument);
        }
        else {
            Config.Settings.Saved.ConvertCustomArguments = null;
            Config.Settings.Saved.ConvertCustomArgumentsIndex = -1;
        }
    }

    /// <summary>
    ///     Adds a custom argument to the youtube-dl argument list.
    /// </summary>
    /// <param name="Arg">
    ///     The argument to add to the argument list.
    /// </param>
    /// <param name="SetAsLastUsed">
    ///     Whether the last used argument should be set to the <paramref name="Arg"/> value.
    /// </param>
    public static void AddYtdlArgument(string Arg, bool SetAsLastUsed) {
        if (!YtdlArguments.Contains(Arg)) {
            YtdlArguments.Add(Arg);
            Config.Settings.Saved.DownloadCustomArguments += "|" + Arg;
        }

        if (SetAsLastUsed)
            LastUsedYtdlArgument = Arg;
    }
    /// <summary>
    ///     Adds a custom argument to the ffmpeg argument list.
    /// </summary>
    /// <param name="Arg">
    ///     The argument to add to the argument list.
    /// </param>
    /// <param name="SetAsLastUsed">
    ///     Whether the last used argument should be set to the <paramref name="Arg"/> value.
    /// </param>
    public static void AddFfmpegArgument(string Arg, bool SetAsLastUsed) {
        if (!FfmpegArguments.Contains(Arg)) {
            FfmpegArguments.Add(Arg);
            Config.Settings.Saved.ConvertCustomArguments += "|" + Arg;
        }

        if (SetAsLastUsed)
            LastUsedFfmpegArgument = Arg;
    }

}