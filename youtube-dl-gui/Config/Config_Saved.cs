namespace youtube_dl_gui;

using System.Drawing;

internal class Config_Saved {
    private const string ConfigName = "Saved";

    #region Variables
    public int downloadType = 0;
    public int convertSaveVideoIndex = 0;
    public int convertSaveAudioIndex = 0;
    public int convertSaveUnknownIndex = 0;
    public int convertType = 0;
    public string convertCustom = string.Empty;
    public int videoQuality = 0;
    public int audioQuality = 0;
    public int VideoFormat = 0;
    public int AudioFormat = 0;
    public int AudioVBRQuality = 0;
    public Point BatchDownloaderLocation = Config.InvalidPoint;
    public Point BatchConverterLocation = Config.InvalidPoint;
    public Size MainFormSize = Size.Empty;
    public Size SettingsFormSize = Size.Empty;
    public string FileNameSchemaHistory = "%(title)s-%(id)s.%(ext)s|%(uploader)s\\(%(playlist_index)s) %(title)s-%(id)s.%(ext)s";
    public string DownloadCustomArguments = string.Empty;
    public int CustomArgumentsIndex = -1;
    public Point MainFormLocation = Config.InvalidPoint;
    public Point ExtendedDownloaderLocation = Config.InvalidPoint;
    public Size ExtendedDownloaderSize = Size.Empty;
    public Point ArchiveDownloaderLocation = Config.InvalidPoint;
    public Point LogLocation = Config.InvalidPoint;
    public Size LogSize = Size.Empty;

    private int fdownloadType = 0;
    private int fconvertSaveVideoIndex = 0;
    private int fconvertSaveAudioIndex = 0;
    private int fconvertSaveUnknownIndex = 0;
    private int fconvertType = 0;
    private string fconvertCustom = string.Empty;
    private int fvideoQuality = 0;
    private int faudioQuality = 0;
    private int fVideoFormat = 0;
    private int fAudioFormat = 0;
    private int fAudioVBRQuality = 0;
    private Point fBatchDownloaderLocation = Config.InvalidPoint;
    private Point fBatchConverterLocation = Config.InvalidPoint;
    private Size fMainFormSize = Size.Empty;
    private Size fSettingsFormSize = Size.Empty;
    private string fFileNameSchemaHistory = "%(title)s-%(id)s.%(ext)s|%(uploader)s\\(%(playlist_index)s) %(title)s-%(id)s.%(ext)s";
    private string fDownloadCustomArguments = string.Empty;
    private int fCustomArgumentsIndex = -1;
    private Point fMainFormLocation = Config.InvalidPoint;
    private Point fExtendedDownloaderLocation = Config.InvalidPoint;
    private Size fExtendedDownloaderSize = Size.Empty;
    public Point fArchiveDownloaderLocation = Config.InvalidPoint;
    public Point fLogLocation = Config.InvalidPoint;
    public Size fLogSize = Size.Empty;
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
    }
}