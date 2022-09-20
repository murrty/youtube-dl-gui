namespace youtube_dl_gui;

using System.Drawing;

internal class Config_Saved {
    private const string ConfigName = "Saved";

    #region Variables
    public int downloadType;
    public int convertSaveVideoIndex;
    public int convertSaveAudioIndex;
    public int convertSaveUnknownIndex;
    public int convertType;
    public string convertCustom;
    public int videoQuality;
    public int audioQuality;
    public int VideoFormat;
    public int AudioFormat;
    public int AudioVBRQuality;
    public Point BatchDownloaderLocation;
    public Point BatchConverterLocation;
    public Size MainFormSize;
    public Size SettingsFormSize;
    public string FileNameSchemaHistory;
    public string DownloadCustomArguments;
    public int CustomArgumentsIndex;
    public Point MainFormLocation;
    public Point ExtendedDownloaderLocation;
    public Size ExtendedDownloaderSize;
    public Point ArchiveDownloaderLocation;
    public Point LogLocation;
    public Size LogSize;
    public string ExtendedDownloadVideoColumns;
    public string ExtendedDownloadAudioColumns;
    public string ExtendedDownloadUnknownColumns;

    private int fdownloadType;
    private int fconvertSaveVideoIndex;
    private int fconvertSaveAudioIndex;
    private int fconvertSaveUnknownIndex;
    private int fconvertType;
    private string fconvertCustom;
    private int fvideoQuality;
    private int faudioQuality;
    private int fVideoFormat;
    private int fAudioFormat;
    private int fAudioVBRQuality;
    private Point fBatchDownloaderLocation;
    private Point fBatchConverterLocation;
    private Size fMainFormSize;
    private Size fSettingsFormSize;
    private string fFileNameSchemaHistory;
    private string fDownloadCustomArguments;
    private int fCustomArgumentsIndex;
    private Point fMainFormLocation;
    private Point fExtendedDownloaderLocation;
    private Size fExtendedDownloaderSize;
    private Point fArchiveDownloaderLocation;
    private Point fLogLocation;
    private Size fLogSize;
    private string fExtendedDownloadVideoColumns;
    private string fExtendedDownloadAudioColumns;
    private string fExtendedDownloadUnknownColumns;
    #endregion

    public void Load() {
        Log.Write("Loading Saved config.");

        downloadType = fdownloadType = Ini.Read(downloadType, 0, ConfigName);
        convertSaveVideoIndex = fconvertSaveVideoIndex = Ini.Read(convertSaveVideoIndex, 0, "Saved");
        convertSaveAudioIndex = fconvertSaveAudioIndex = Ini.Read(convertSaveAudioIndex, 0, "Saved");
        convertSaveUnknownIndex = fconvertSaveUnknownIndex = Ini.Read(convertSaveUnknownIndex, 0, "Saved");
        convertType = fconvertType = Ini.Read(convertType, 0, ConfigName);
        convertCustom = fconvertCustom = Ini.Read(convertCustom, string.Empty, ConfigName);
        videoQuality = fvideoQuality = Ini.Read(videoQuality, 0, ConfigName);
        audioQuality = faudioQuality = Ini.Read(audioQuality, 0, ConfigName);
        VideoFormat = fVideoFormat = Ini.Read(VideoFormat, 0, ConfigName);
        AudioFormat = fAudioFormat = Ini.Read(AudioFormat, 0, ConfigName);
        AudioVBRQuality = fAudioVBRQuality = Ini.Read(AudioVBRQuality, 0, ConfigName);
        BatchDownloaderLocation = fBatchDownloaderLocation = Ini.Read(BatchDownloaderLocation, Config.InvalidPoint, ConfigName);
        BatchConverterLocation = fBatchConverterLocation = Ini.Read(BatchConverterLocation, Config.InvalidPoint, ConfigName);
        MainFormSize = fMainFormSize = Ini.Read(MainFormSize, Size.Empty, ConfigName);
        SettingsFormSize = fSettingsFormSize = Ini.Read(SettingsFormSize, Size.Empty, ConfigName);
        FileNameSchemaHistory = fFileNameSchemaHistory = Ini.Read(FileNameSchemaHistory, "%(title)s-%(id)s.%(ext)s|%(uploader)s\\(%(playlist_index)s) %(title)s-%(id)s.%(ext)s", ConfigName);
        DownloadCustomArguments = fDownloadCustomArguments = Ini.Read(DownloadCustomArguments, string.Empty, ConfigName);
        CustomArgumentsIndex = fCustomArgumentsIndex = Ini.Read(CustomArgumentsIndex, -1, ConfigName);
        MainFormLocation = fMainFormLocation = Ini.Read(MainFormLocation, Config.InvalidPoint, ConfigName);
        MainFormLocation = fMainFormLocation = Ini.Read(MainFormLocation, Config.InvalidPoint, ConfigName);
        ExtendedDownloaderLocation = fExtendedDownloaderLocation = Ini.Read(ExtendedDownloaderLocation, Config.InvalidPoint, ConfigName);
        ExtendedDownloaderSize = fExtendedDownloaderSize = Ini.Read(ExtendedDownloaderSize, Size.Empty, ConfigName);
        ArchiveDownloaderLocation = fArchiveDownloaderLocation = Ini.Read(ArchiveDownloaderLocation, Config.InvalidPoint, ConfigName);
        LogLocation = fLogLocation = Ini.Read(LogLocation, Config.InvalidPoint, ConfigName);
        LogSize = fLogSize = Ini.Read(LogSize, Size.Empty, ConfigName);
        ExtendedDownloadVideoColumns = fExtendedDownloadVideoColumns = Ini.Read(ExtendedDownloadVideoColumns, string.Empty, ConfigName);
        ExtendedDownloadAudioColumns = fExtendedDownloadAudioColumns = Ini.Read(ExtendedDownloadAudioColumns, string.Empty, ConfigName);
        ExtendedDownloadUnknownColumns = fExtendedDownloadUnknownColumns = Ini.Read(ExtendedDownloadUnknownColumns, string.Empty, ConfigName);
    }

    public void Save() {
        Log.Write("Saving Saved config.");

        if (downloadType != fdownloadType) 
            fdownloadType = Ini.Write(downloadType, ConfigName);
        if (convertSaveVideoIndex != fconvertSaveVideoIndex) 
            fconvertSaveVideoIndex = Ini.Write(convertSaveVideoIndex, ConfigName);
        if (convertSaveAudioIndex != fconvertSaveAudioIndex) 
            fconvertSaveAudioIndex = Ini.Write(convertSaveAudioIndex, ConfigName);
        if (convertSaveUnknownIndex != fconvertSaveUnknownIndex) 
            fconvertSaveUnknownIndex = Ini.Write(convertSaveUnknownIndex, ConfigName);
        if (convertType != fconvertType) 
            fconvertType = Ini.Write(convertType, ConfigName);
        if (convertCustom != fconvertCustom) 
            fconvertCustom = Ini.Write(convertCustom, ConfigName);
        if (videoQuality != fvideoQuality) 
            fvideoQuality = Ini.Write(videoQuality, ConfigName);
        if (audioQuality != faudioQuality) 
            faudioQuality = Ini.Write(audioQuality, ConfigName);
        if (VideoFormat != fVideoFormat) 
            fVideoFormat = Ini.Write(VideoFormat, ConfigName);
        if (AudioFormat != fAudioFormat) 
            fAudioFormat = Ini.Write(AudioFormat, ConfigName);
        if (AudioVBRQuality != fAudioVBRQuality) 
            fAudioVBRQuality = Ini.Write(AudioVBRQuality, ConfigName);
        if (BatchDownloaderLocation != fBatchDownloaderLocation) 
            fBatchDownloaderLocation = Ini.Write(BatchDownloaderLocation, ConfigName);
        if (BatchConverterLocation != fBatchConverterLocation) 
            fBatchConverterLocation = Ini.Write(BatchConverterLocation, ConfigName);
        if (MainFormSize != fMainFormSize) 
            fMainFormSize = Ini.Write(MainFormSize, ConfigName);
        if (SettingsFormSize != fSettingsFormSize) 
            fSettingsFormSize = Ini.Write(SettingsFormSize, ConfigName);
        if (FileNameSchemaHistory != fFileNameSchemaHistory) 
            fFileNameSchemaHistory = Ini.Write(FileNameSchemaHistory, ConfigName);
        if (DownloadCustomArguments != fDownloadCustomArguments) 
            fDownloadCustomArguments = Ini.Write(DownloadCustomArguments, ConfigName);
        if (CustomArgumentsIndex != fCustomArgumentsIndex) 
            fCustomArgumentsIndex = Ini.Write(CustomArgumentsIndex, ConfigName);
        if (MainFormLocation != fMainFormLocation) 
            fMainFormLocation = Ini.Write(MainFormLocation, ConfigName);
        if (ExtendedDownloaderLocation != fExtendedDownloaderLocation) 
            fExtendedDownloaderLocation = Ini.Write(ExtendedDownloaderLocation, ConfigName);
        if (ExtendedDownloaderSize != fExtendedDownloaderSize) 
            fExtendedDownloaderSize = Ini.Write(ExtendedDownloaderSize, ConfigName);
        if (ArchiveDownloaderLocation != fArchiveDownloaderLocation) 
            fArchiveDownloaderLocation = Ini.Write(ArchiveDownloaderLocation, ConfigName);
        if (LogLocation != fLogLocation) 
            fLogLocation = Ini.Write(LogLocation, ConfigName);
        if (LogSize != fLogSize) 
            fLogSize = Ini.Write(LogSize, ConfigName);
        if (ExtendedDownloadVideoColumns != fExtendedDownloadVideoColumns)
            fExtendedDownloadVideoColumns = Ini.Write(ExtendedDownloadVideoColumns, ConfigName);
        if (ExtendedDownloadAudioColumns != fExtendedDownloadAudioColumns)
            fExtendedDownloadAudioColumns = Ini.Write(ExtendedDownloadAudioColumns, ConfigName);
        if (ExtendedDownloadUnknownColumns != fExtendedDownloadUnknownColumns)
            fExtendedDownloadUnknownColumns = Ini.Write(ExtendedDownloadUnknownColumns, ConfigName);
    }
}