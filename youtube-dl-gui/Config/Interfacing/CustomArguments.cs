namespace youtube_dl_gui;

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

    static CustomArguments() {
        if (!Saved.DownloadCustomArguments.IsNullEmptyWhitespace()) {
            HashSet<string> Arguments = new();
            string[] Args = Saved.DownloadCustomArguments.Trim('|', ' ').Split('|');
            Args.For((Arg) => {
                if (!Arg.IsNullEmptyWhitespace())
                    Arguments.Add(Arg);
            });

            foreach (string Arg in Arguments) {
                if (Arg.IsNullEmptyWhitespace())
                    continue;

                YtdlArguments.Add(Arg);
            }

            int Index = Saved.CustomArgumentsIndex;
            if (Index > -1 && Index < YtdlArguments.Count)
                LastUsedYtdlArgument = YtdlArguments[Index];
        }

        if (!Saved.ConvertCustomArguments.IsNullEmptyWhitespace()) {
            HashSet<string> Arguments = new();
            string[] Args = Saved.ConvertCustomArguments.Trim('|', ' ').Split('|');
            Args.For((Arg) => {
                if (!Arg.IsNullEmptyWhitespace())
                    Arguments.Add(Arg);
            });

            foreach (string Arg in Arguments) {
                if (Arg.IsNullEmptyWhitespace())
                    continue;

                FfmpegArguments.Add(Arg);
            }

            int Index = Saved.ConvertCustomArgumentsIndex;
            if (Index > -1 && Index < FfmpegArguments.Count)
                LastUsedFfmpegArgument = FfmpegArguments[Index];
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
            Saved.DownloadCustomArguments += "|" + Arg;
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
            Saved.ConvertCustomArguments += "|" + Arg;
        }

        if (SetAsLastUsed)
            LastUsedFfmpegArgument = Arg;
    }
}