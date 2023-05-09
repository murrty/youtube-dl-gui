namespace youtube_dl_gui;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

/// <summary>
/// Represents a simple text-only structure that contains a single string for downloading.
/// The string can contain multiple links joined with a pipe "|" character, and is 65,535 in length.
/// Pipe-allowed values can have "{{%OEMPIPE%}}" as a replacement which will be accounted for, eventually.
/// </summary>
/// <param name="Argument">The argument that contains data passed between instances of youtube-dl-gui.</param>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public record struct SendLinks(
    [field: MarshalAs(UnmanagedType.ByValTStr, SizeConst = 65_536)] string Argument);

internal static class Arguments {
    /// <summary>
    /// The prefix of the protocol.
    /// </summary>
    private const string ProtocolPrefix = "ytdlgui" + ":";

    /// <summary>
    /// Whether the arguments have been parsed.
    /// </summary>
    public static bool ArgumentsParsed {
        get; private set;
    } = false;

    /// <summary>
    /// The tuple list of parsed arguments.
    /// </summary>
    public static List<(ArgumentType Type, string Data)> ParsedArguments {
        get;
    } = new();

    /// <summary>
    /// Parses an array of arguments.
    /// </summary>
    /// <param name="Arguments">The array of arguments that should be parsed.</param>
    /// <returns>True if the arguments were fully parsed; otherwise, false.</returns>
    public static bool ParseArguments(string[] Arguments) {
        if (!ArgumentsParsed) {
            try {
                ParsedArguments.AddRange(RetrieveArguments(Arguments));
                ArgumentsParsed = true;
            }
            catch {
                return false;
            }
        }
        return ArgumentsParsed;
    }

    /// <summary>
    /// Gets a tuple-list of arguments parsed from an array.
    /// </summary>
    /// <param name="Arguments">The arguments array to parse.</param>
    /// <returns>A filled list with valid arguments parsed from the array; otherwise, empty if the array is empty or no valid arguments are within it.</returns>
    public static List<(ArgumentType Type, string Data)> RetrieveArguments(string[] Arguments) {
        List<(ArgumentType Type, string Data)> TemporaryList = new();
        if (Arguments.Length > 0) {
            List<string> Args = Arguments.ToList();
            if (Arguments[0].ToLowerInvariant().StartsWith(ProtocolPrefix.ToLowerInvariant()))
                Arguments[0] = Arguments[0][ProtocolPrefix.Length..];
            var Matches = Regex.Matches(Uri.UnescapeDataString(Arguments[0]), @"\""(\""\""|[^\""])+\""|[^ ]+", RegexOptions.ExplicitCapture);
            if (Matches.Count > 0) {
                Args.RemoveAt(0);
                for (int i = 0; i < Matches.Count; i++) {
                    if (Matches[i].Success) {
                        string NewArgument = Matches[i].Value;
                        if (NewArgument.StartsWith("\"") && NewArgument.EndsWith("\""))
                            NewArgument = NewArgument[1..^1].Replace("\"\"", "\"");
                        if (NewArgument.StartsWith("\\\"") && NewArgument.EndsWith("\""))
                            NewArgument = NewArgument[1..^1];

                        Args.Insert(i, NewArgument);
                    }
                }
                Arguments = Args.ToArray();
            }

            Log.Write($"There are {Arguments.Length} arguments to parse through.");
            bool BreakLoop = false;
            for (int i = 0; i < Arguments.Length; i++) {
                if (Arguments[i].ToLowerInvariant().StartsWith(ProtocolPrefix))
                    Arguments[i] = Arguments[i][ProtocolPrefix.Length..];

                if (Arguments[i].StartsWith("-"))
                    Arguments[i] = Arguments[i][1..];

                switch (Arguments[i].ToLowerInvariant()) {
                    case "v" or "video" when ++i < Arguments.Length: {
                        TemporaryList.Add((ArgumentType.DownloadVideo, Arguments[i]));
                    } break;
                    case "vau" or "vauth" or "videoauth" when ++i < Arguments.Length: {
                        TemporaryList.Add((ArgumentType.DownloadAuthenticateVideo, Arguments[i]));
                    } break;

                    case "a" or "audio" when ++i < Arguments.Length: {
                        TemporaryList.Add((ArgumentType.DownloadAudio, Arguments[i]));
                    } break;
                    case "aau" or "aauth" or "audioauth" when ++i < Arguments.Length: {
                        TemporaryList.Add((ArgumentType.DownloadAuthenticateAudio, Arguments[i]));
                    } break;

                    case "c" or "custom" when ++i < Arguments.Length: {
                        TemporaryList.Add((ArgumentType.DownloadCustom, Arguments[i]));
                    } break;
                    case "cau" or "cauth" or "customauth" when ++i < Arguments.Length: {
                        TemporaryList.Add((ArgumentType.DownloadAuthenticateCustom, Arguments[i]));
                    } break;

                    case "archived" or "ar" when ++i < Arguments.Length: {
                        TemporaryList.Add((ArgumentType.DownloadArchived, Arguments[i]));
                    } break;

                    case "installprotocol": {
                        TemporaryList.Add((ArgumentType.InstallProtocol, null));
                        BreakLoop = true;
                    } break;
                }

                if (BreakLoop)
                    break;
            }
        }
        else Log.Write("No arguments are in the arguments array.");
        TemporaryList.TrimExcess();
        return TemporaryList;
    }
}