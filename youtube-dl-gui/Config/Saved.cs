#nullable enable
namespace youtube_dl_gui;
internal static class Saved {
    private const string ConfigName = "Saved";

    static Saved() {
        Log.Write("Loading Saved config.");

        fdownloadType = IniProvider.Read(downloadType, 0, ConfigName);
        fconvertSaveVideoIndex = IniProvider.Read(convertSaveVideoIndex, 0, "Saved");
        fconvertSaveAudioIndex = IniProvider.Read(convertSaveAudioIndex, 0, "Saved");
        fconvertSaveUnknownIndex = IniProvider.Read(convertSaveUnknownIndex, 0, "Saved");
        fconvertType = IniProvider.Read(convertType, 0, ConfigName);
        fconvertCustom = IniProvider.Read(convertCustom, string.Empty, ConfigName);
        fvideoQuality = IniProvider.Read(videoQuality, 0, ConfigName);
        faudioQuality = IniProvider.Read(audioQuality, 0, ConfigName);
        fVideoFormat = IniProvider.Read(VideoFormat, 0, ConfigName);
        fAudioFormat = IniProvider.Read(AudioFormat, 0, ConfigName);
        fAudioVBRQuality = IniProvider.Read(AudioVBRQuality, 0, ConfigName);
        fBatchDownloaderLocation = IniProvider.Read(BatchDownloaderLocation, Point.Invalid, ConfigName);
        fBatchConverterLocation = IniProvider.Read(BatchConverterLocation, Point.Invalid, ConfigName);
        fMainFormSize = IniProvider.Read(MainFormSize, Size.Empty, ConfigName);
        fSettingsFormSize = IniProvider.Read(SettingsFormSize, Size.Empty, ConfigName);
        fFileNameSchemaHistory = IniProvider.Read(FileNameSchemaHistory, "%(title)s-%(id)s.%(ext)s|%(uploader)s\\(%(playlist_index)s) %(title)s-%(id)s.%(ext)s", ConfigName);
        fDownloadCustomArguments = IniProvider.Read(DownloadCustomArguments, string.Empty, ConfigName);
        fCustomArgumentsIndex = IniProvider.Read(CustomArgumentsIndex, -1, ConfigName);
        fConvertCustomArguments = IniProvider.Read(ConvertCustomArguments, string.Empty, ConfigName);
        fConvertCustomArgumentsIndex = IniProvider.Read(ConvertCustomArgumentsIndex, -1, ConfigName);
        fMainFormLocation = IniProvider.Read(MainFormLocation, Point.Invalid, ConfigName);
        fExtendedDownloaderLocation = IniProvider.Read(ExtendedDownloaderLocation, Point.Invalid, ConfigName);
        fExtendedDownloaderSize = IniProvider.Read(ExtendedDownloaderSize, Size.Empty, ConfigName);
        fArchiveDownloaderLocation = IniProvider.Read(ArchiveDownloaderLocation, Point.Invalid, ConfigName);
        fLogLocation = IniProvider.Read(LogLocation, Point.Invalid, ConfigName);
        fLogSize = IniProvider.Read(LogSize, Size.Empty, ConfigName);
        fExtendedDownloaderVideoColumns = IniProvider.Read(ExtendedDownloaderVideoColumns, string.Empty, ConfigName);
        fExtendedDownloaderAudioColumns = IniProvider.Read(ExtendedDownloaderAudioColumns, string.Empty, ConfigName);
        fExtendedDownloaderUnknownColumns = IniProvider.Read(ExtendedDownloaderUnknownColumns, string.Empty, ConfigName);
        fQuickDownloaderLocation = IniProvider.Read(QuickDownloaderLocation, Point.Invalid, ConfigName);
        fFileNameSchemaHistoryLocation = IniProvider.Read(FileNameSchemaHistoryLocation, Point.Invalid, ConfigName);
        fFileNameSchemaHistorySize = IniProvider.Read(FileNameSchemaHistorySize, Size.Empty, ConfigName);
        fExtendedBatchDownloaderLocation = IniProvider.Read(ExtendedBatchDownloaderLocation, Point.Invalid, ConfigName);
        fExtendedBatchDownloaderSize = IniProvider.Read(ExtendedBatchDownloaderSize, Size.Empty, ConfigName);
        fExtendedBatchDownloaderQueuedColumns = IniProvider.Read(ExtendedBatchDownloaderQueuedColumns, string.Empty, ConfigName);
    }

    public static int downloadType {
        get => fdownloadType;
        set {
            if (fdownloadType != value) {
                fdownloadType = value;
                IniProvider.Write(downloadType, ConfigName);
            }
        }
    }
    private static int fdownloadType;

    public static int convertSaveVideoIndex {
        get => fconvertSaveVideoIndex;
        set {
            if (fconvertSaveVideoIndex != value) {
                fconvertSaveVideoIndex = value;
                IniProvider.Write(convertSaveVideoIndex, ConfigName);
            }
        }
    }
    private static int fconvertSaveVideoIndex;

    public static int convertSaveAudioIndex {
        get => fconvertSaveAudioIndex;
        set {
            if (fconvertSaveAudioIndex != value) {
                fconvertSaveAudioIndex = value;
                IniProvider.Write(convertSaveAudioIndex, ConfigName);
            }
        }
    }
    private static int fconvertSaveAudioIndex;

    public static int convertSaveUnknownIndex {
        get => fconvertSaveUnknownIndex;
        set {
            if (fconvertSaveUnknownIndex != value) {
                fconvertSaveUnknownIndex = value;
                IniProvider.Write(convertSaveUnknownIndex, ConfigName);
            }
        }
    }
    private static int fconvertSaveUnknownIndex;

    public static int convertType {
        get => fconvertType;
        set {
            if (fconvertType != value) {
                fconvertType = value;
                IniProvider.Write(convertType, ConfigName);
            }
        }
    }
    private static int fconvertType;

    public static string convertCustom {
        get => fconvertCustom;
        set {
            if (fconvertCustom != value) {
                fconvertCustom = value;
                IniProvider.Write(convertCustom, ConfigName);
            }
        }
    }
    private static string fconvertCustom;

    public static int videoQuality {
        get => fvideoQuality;
        set {
            if (fvideoQuality != value) {
                fvideoQuality = value;
                IniProvider.Write(videoQuality, ConfigName);
            }
        }
    }
    private static int fvideoQuality;

    public static int audioQuality {
        get => faudioQuality;
        set {
            if (faudioQuality != value) {
                faudioQuality = value;
                IniProvider.Write(audioQuality, ConfigName);
            }
        }
    }
    private static int faudioQuality;

    public static int VideoFormat {
        get => fVideoFormat;
        set {
            if (fVideoFormat != value) {
                fVideoFormat = value;
                IniProvider.Write(VideoFormat, ConfigName);
            }
        }
    }
    private static int fVideoFormat;

    public static int AudioFormat {
        get => fAudioFormat;
        set {
            if (fAudioFormat != value) {
                fAudioFormat = value;
                IniProvider.Write(AudioFormat, ConfigName);
            }
        }
    }
    private static int fAudioFormat;

    public static int AudioVBRQuality {
        get => fAudioVBRQuality;
        set {
            if (fAudioVBRQuality != value) {
                fAudioVBRQuality = value;
                IniProvider.Write(AudioVBRQuality, ConfigName);
            }
        }
    }
    private static int fAudioVBRQuality;

    public static Point BatchDownloaderLocation {
        get => fBatchDownloaderLocation;
        set {
            if (fBatchDownloaderLocation != value) {
                fBatchDownloaderLocation = value;
                IniProvider.Write(BatchDownloaderLocation, ConfigName);
            }
        }
    }
    private static Point fBatchDownloaderLocation;

    public static Point BatchConverterLocation {
        get => fBatchConverterLocation;
        set {
            if (fBatchConverterLocation != value) {
                fBatchConverterLocation = value;
                IniProvider.Write(BatchConverterLocation, ConfigName);
            }
        }
    }
    private static Point fBatchConverterLocation;

    public static Size MainFormSize {
        get => fMainFormSize;
        set {
            if (fMainFormSize != value) {
                fMainFormSize = value;
                IniProvider.Write(MainFormSize, ConfigName);
            }
        }
    }
    private static Size fMainFormSize;

    public static Size SettingsFormSize {
        get => fSettingsFormSize;
        set {
            if (fSettingsFormSize != value) {
                fSettingsFormSize = value;
                IniProvider.Write(SettingsFormSize, ConfigName);
            }
        }
    }
    private static Size fSettingsFormSize;

    public static string FileNameSchemaHistory {
        get => fFileNameSchemaHistory;
        set {
            if (fFileNameSchemaHistory != value) {
                fFileNameSchemaHistory = value;
                IniProvider.Write(FileNameSchemaHistory, ConfigName);
            }
        }
    }
    private static string fFileNameSchemaHistory;

    public static string DownloadCustomArguments {
        get => fDownloadCustomArguments;
        set {
            if (fDownloadCustomArguments != value) {
                fDownloadCustomArguments = value;
                IniProvider.Write(DownloadCustomArguments, ConfigName);
            }
        }
    }
    private static string fDownloadCustomArguments;

    public static int CustomArgumentsIndex {
        get => fCustomArgumentsIndex;
        set {
            if (fCustomArgumentsIndex != value) {
                fCustomArgumentsIndex = value;
                IniProvider.Write(CustomArgumentsIndex, ConfigName);
            }
        }
    }
    private static int fCustomArgumentsIndex;

    public static string ConvertCustomArguments {
        get => fConvertCustomArguments;
        set {
            if (fConvertCustomArguments != value) {
                fConvertCustomArguments = value;
                IniProvider.Write(ConvertCustomArguments, ConfigName);
            }
        }
    }
    private static string fConvertCustomArguments;

    public static int ConvertCustomArgumentsIndex {
        get => fConvertCustomArgumentsIndex;
        set {
            if (fConvertCustomArgumentsIndex != value) {
                fConvertCustomArgumentsIndex = value;
                IniProvider.Write(ConvertCustomArgumentsIndex, ConfigName);
            }
        }
    }
    private static int fConvertCustomArgumentsIndex;

    public static Point MainFormLocation {
        get => fMainFormLocation;
        set {
            if (fMainFormLocation != value) {
                fMainFormLocation = value;
                IniProvider.Write(MainFormLocation, ConfigName);
            }
        }
    }
    private static Point fMainFormLocation;

    public static Point ExtendedDownloaderLocation {
        get => fExtendedDownloaderLocation;
        set {
            if (fExtendedDownloaderLocation != value) {
                fExtendedDownloaderLocation = value;
                IniProvider.Write(ExtendedDownloaderLocation, ConfigName);
            }
        }
    }
    private static Point fExtendedDownloaderLocation;

    public static Size ExtendedDownloaderSize {
        get => fExtendedDownloaderSize;
        set {
            if (fExtendedDownloaderSize != value) {
                fExtendedDownloaderSize = value;
                IniProvider.Write(ExtendedDownloaderSize, ConfigName);
            }
        }
    }
    private static Size fExtendedDownloaderSize;

    public static Point ArchiveDownloaderLocation {
        get => fArchiveDownloaderLocation;
        set {
            if (fArchiveDownloaderLocation != value) {
                fArchiveDownloaderLocation = value;
                IniProvider.Write(ArchiveDownloaderLocation, ConfigName);
            }
        }
    }
    private static Point fArchiveDownloaderLocation;

    public static Point LogLocation {
        get => fLogLocation;
        set {
            if (fLogLocation != value) {
                fLogLocation = value;
                IniProvider.Write(LogLocation, ConfigName);
            }
        }
    }
    private static Point fLogLocation;

    public static Size LogSize {
        get => fLogSize;
        set {
            if (fLogSize != value) {
                fLogSize = value;
                IniProvider.Write(LogSize, ConfigName);
            }
        }
    }
    private static Size fLogSize;

    public static string ExtendedDownloaderVideoColumns {
        get => fExtendedDownloaderVideoColumns;
        set {
            if (fExtendedDownloaderVideoColumns != value) {
                fExtendedDownloaderVideoColumns = value;
                IniProvider.Write(ExtendedDownloaderVideoColumns, ConfigName);
            }
        }
    }
    private static string fExtendedDownloaderVideoColumns;

    public static string ExtendedDownloaderAudioColumns {
        get => fExtendedDownloaderAudioColumns;
        set {
            if (fExtendedDownloaderAudioColumns != value) {
                fExtendedDownloaderAudioColumns = value;
                IniProvider.Write(ExtendedDownloaderAudioColumns, ConfigName);
            }
        }
    }
    private static string fExtendedDownloaderAudioColumns;

    public static string ExtendedDownloaderUnknownColumns {
        get => fExtendedDownloaderUnknownColumns;
        set {
            if (fExtendedDownloaderUnknownColumns != value) {
                fExtendedDownloaderUnknownColumns = value;
                IniProvider.Write(ExtendedDownloaderUnknownColumns, ConfigName);
            }
        }
    }
    private static string fExtendedDownloaderUnknownColumns;

    public static Point QuickDownloaderLocation {
        get => fQuickDownloaderLocation;
        set {
            if (fQuickDownloaderLocation != value) {
                fQuickDownloaderLocation = value;
                IniProvider.Write(QuickDownloaderLocation, ConfigName);
            }
        }
    }
    private static Point fQuickDownloaderLocation;

    public static Point FileNameSchemaHistoryLocation {
        get => fFileNameSchemaHistoryLocation;
        set {
            if (fFileNameSchemaHistoryLocation != value) {
                fFileNameSchemaHistoryLocation = value;
                IniProvider.Write(FileNameSchemaHistoryLocation, ConfigName);
            }
        }
    }
    private static Point fFileNameSchemaHistoryLocation;

    public static Size FileNameSchemaHistorySize {
        get => fFileNameSchemaHistorySize;
        set {
            if (fFileNameSchemaHistorySize != value) {
                fFileNameSchemaHistorySize = value;
                IniProvider.Write(FileNameSchemaHistorySize, ConfigName);
            }
        }
    }
    private static Size fFileNameSchemaHistorySize;

    public static Point ExtendedBatchDownloaderLocation {
        get => fExtendedBatchDownloaderLocation;
        set {
            if (fExtendedBatchDownloaderLocation != value) {
                fExtendedBatchDownloaderLocation = value;
                IniProvider.Write(ExtendedBatchDownloaderLocation, ConfigName);
            }
        }
    }
    private static Point fExtendedBatchDownloaderLocation;

    public static Size ExtendedBatchDownloaderSize {
        get => fExtendedBatchDownloaderSize;
        set {
            if (fExtendedBatchDownloaderSize != value) {
                fExtendedBatchDownloaderSize = value;
                IniProvider.Write(ExtendedBatchDownloaderSize, ConfigName);
            }
        }
    }
    private static Size fExtendedBatchDownloaderSize;

    public static string ExtendedBatchDownloaderQueuedColumns {
        get => fExtendedBatchDownloaderQueuedColumns;
        set {
            if (fExtendedBatchDownloaderQueuedColumns != value) {
                fExtendedBatchDownloaderQueuedColumns = value;
                IniProvider.Write(ExtendedBatchDownloaderQueuedColumns, ConfigName);
            }
        }
    }
    private static string fExtendedBatchDownloaderQueuedColumns;
}