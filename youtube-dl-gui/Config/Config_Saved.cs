namespace youtube_dl_gui;

internal class Config_Saved {
    private const string ConfigName = "Saved";

    #region Properties
    public int downloadType { get; set; }
    public int convertSaveVideoIndex { get; set; }
    public int convertSaveAudioIndex { get; set; }
    public int convertSaveUnknownIndex { get; set; }
    public int convertType { get; set; }
    public string convertCustom { get; set; }
    public int videoQuality { get; set; }
    public int audioQuality { get; set; }
    public int VideoFormat { get; set; }
    public int AudioFormat { get; set; }
    public int AudioVBRQuality { get; set; }
    public Point BatchDownloaderLocation { get; set; }
    public Point BatchConverterLocation { get; set; }
    public Size MainFormSize { get; set; }
    public Size SettingsFormSize { get; set; }
    public string FileNameSchemaHistory { get; set; }
    public string DownloadCustomArguments { get; set; }
    public int CustomArgumentsIndex { get; set; }
    public Point MainFormLocation { get; set; }
    public Point ExtendedDownloaderLocation { get; set; }
    public Size ExtendedDownloaderSize { get; set; }
    public Point ArchiveDownloaderLocation { get; set; }
    public Point LogLocation { get; set; }
    public Size LogSize { get; set; }
    public string ExtendedDownloadVideoColumns { get; set; }
    public string ExtendedDownloadAudioColumns { get; set; }
    public string ExtendedDownloadUnknownColumns { get; set; }
    public Point QuickDownloaderLocation { get; set; }

    private int fdownloadType { get; set; }
    private int fconvertSaveVideoIndex { get; set; }
    private int fconvertSaveAudioIndex { get; set; }
    private int fconvertSaveUnknownIndex { get; set; }
    private int fconvertType { get; set; }
    private string fconvertCustom { get; set; }
    private int fvideoQuality { get; set; }
    private int faudioQuality { get; set; }
    private int fVideoFormat { get; set; }
    private int fAudioFormat { get; set; }
    private int fAudioVBRQuality { get; set; }
    private Point fBatchDownloaderLocation { get; set; }
    private Point fBatchConverterLocation { get; set; }
    private Size fMainFormSize { get; set; }
    private Size fSettingsFormSize { get; set; }
    private string fFileNameSchemaHistory { get; set; }
    private string fDownloadCustomArguments { get; set; }
    private int fCustomArgumentsIndex { get; set; }
    private Point fMainFormLocation { get; set; }
    private Point fExtendedDownloaderLocation { get; set; }
    private Size fExtendedDownloaderSize { get; set; }
    private Point fArchiveDownloaderLocation { get; set; }
    private Point fLogLocation { get; set; }
    private Size fLogSize { get; set; }
    private string fExtendedDownloadVideoColumns { get; set; }
    private string fExtendedDownloadAudioColumns { get; set; }
    private string fExtendedDownloadUnknownColumns { get; set; }
    private Point fQuickDownloaderLocation { get; set; }
    #endregion

    public void Load() {
        Log.Write("Loading Saved config.");

        downloadType = fdownloadType = IniProvider.Read(downloadType, 0, ConfigName);
        convertSaveVideoIndex = fconvertSaveVideoIndex = IniProvider.Read(convertSaveVideoIndex, 0, "Saved");
        convertSaveAudioIndex = fconvertSaveAudioIndex = IniProvider.Read(convertSaveAudioIndex, 0, "Saved");
        convertSaveUnknownIndex = fconvertSaveUnknownIndex = IniProvider.Read(convertSaveUnknownIndex, 0, "Saved");
        convertType = fconvertType = IniProvider.Read(convertType, 0, ConfigName);
        convertCustom = fconvertCustom = IniProvider.Read(convertCustom, string.Empty, ConfigName);
        videoQuality = fvideoQuality = IniProvider.Read(videoQuality, 0, ConfigName);
        audioQuality = faudioQuality = IniProvider.Read(audioQuality, 0, ConfigName);
        VideoFormat = fVideoFormat = IniProvider.Read(VideoFormat, 0, ConfigName);
        AudioFormat = fAudioFormat = IniProvider.Read(AudioFormat, 0, ConfigName);
        AudioVBRQuality = fAudioVBRQuality = IniProvider.Read(AudioVBRQuality, 0, ConfigName);
        BatchDownloaderLocation = fBatchDownloaderLocation = IniProvider.Read(BatchDownloaderLocation, Point.Invalid, ConfigName);
        BatchConverterLocation = fBatchConverterLocation = IniProvider.Read(BatchConverterLocation, Point.Invalid, ConfigName);
        MainFormSize = fMainFormSize = IniProvider.Read(MainFormSize, Size.Empty, ConfigName);
        SettingsFormSize = fSettingsFormSize = IniProvider.Read(SettingsFormSize, Size.Empty, ConfigName);
        FileNameSchemaHistory = fFileNameSchemaHistory = IniProvider.Read(FileNameSchemaHistory, "%(title)s-%(id)s.%(ext)s|%(uploader)s\\(%(playlist_index)s) %(title)s-%(id)s.%(ext)s", ConfigName);
        DownloadCustomArguments = fDownloadCustomArguments = IniProvider.Read(DownloadCustomArguments, string.Empty, ConfigName);
        CustomArgumentsIndex = fCustomArgumentsIndex = IniProvider.Read(CustomArgumentsIndex, -1, ConfigName);
        MainFormLocation = fMainFormLocation = IniProvider.Read(MainFormLocation, Point.Invalid, ConfigName);
        ExtendedDownloaderLocation = fExtendedDownloaderLocation = IniProvider.Read(ExtendedDownloaderLocation, Point.Invalid, ConfigName);
        ExtendedDownloaderSize = fExtendedDownloaderSize = IniProvider.Read(ExtendedDownloaderSize, Size.Empty, ConfigName);
        ArchiveDownloaderLocation = fArchiveDownloaderLocation = IniProvider.Read(ArchiveDownloaderLocation, Point.Invalid, ConfigName);
        LogLocation = fLogLocation = IniProvider.Read(LogLocation, Point.Invalid, ConfigName);
        LogSize = fLogSize = IniProvider.Read(LogSize, Size.Empty, ConfigName);
        ExtendedDownloadVideoColumns = fExtendedDownloadVideoColumns = IniProvider.Read(ExtendedDownloadVideoColumns, string.Empty, ConfigName);
        ExtendedDownloadAudioColumns = fExtendedDownloadAudioColumns = IniProvider.Read(ExtendedDownloadAudioColumns, string.Empty, ConfigName);
        ExtendedDownloadUnknownColumns = fExtendedDownloadUnknownColumns = IniProvider.Read(ExtendedDownloadUnknownColumns, string.Empty, ConfigName);
        QuickDownloaderLocation = fQuickDownloaderLocation = IniProvider.Read(QuickDownloaderLocation, Point.Invalid, ConfigName);
    }

    public void Save() {
        Log.Write("Saving Saved config.");

        if (downloadType != fdownloadType) 
            fdownloadType = IniProvider.Write(downloadType, ConfigName);
        if (convertSaveVideoIndex != fconvertSaveVideoIndex) 
            fconvertSaveVideoIndex = IniProvider.Write(convertSaveVideoIndex, ConfigName);
        if (convertSaveAudioIndex != fconvertSaveAudioIndex) 
            fconvertSaveAudioIndex = IniProvider.Write(convertSaveAudioIndex, ConfigName);
        if (convertSaveUnknownIndex != fconvertSaveUnknownIndex) 
            fconvertSaveUnknownIndex = IniProvider.Write(convertSaveUnknownIndex, ConfigName);
        if (convertType != fconvertType) 
            fconvertType = IniProvider.Write(convertType, ConfigName);
        if (convertCustom != fconvertCustom) 
            fconvertCustom = IniProvider.Write(convertCustom, ConfigName);
        if (videoQuality != fvideoQuality) 
            fvideoQuality = IniProvider.Write(videoQuality, ConfigName);
        if (audioQuality != faudioQuality) 
            faudioQuality = IniProvider.Write(audioQuality, ConfigName);
        if (VideoFormat != fVideoFormat) 
            fVideoFormat = IniProvider.Write(VideoFormat, ConfigName);
        if (AudioFormat != fAudioFormat) 
            fAudioFormat = IniProvider.Write(AudioFormat, ConfigName);
        if (AudioVBRQuality != fAudioVBRQuality) 
            fAudioVBRQuality = IniProvider.Write(AudioVBRQuality, ConfigName);
        if (BatchDownloaderLocation != fBatchDownloaderLocation) 
            fBatchDownloaderLocation = IniProvider.Write(BatchDownloaderLocation, ConfigName);
        if (BatchConverterLocation != fBatchConverterLocation) 
            fBatchConverterLocation = IniProvider.Write(BatchConverterLocation, ConfigName);
        if (MainFormSize != fMainFormSize) 
            fMainFormSize = IniProvider.Write(MainFormSize, ConfigName);
        if (SettingsFormSize != fSettingsFormSize) 
            fSettingsFormSize = IniProvider.Write(SettingsFormSize, ConfigName);
        if (FileNameSchemaHistory != fFileNameSchemaHistory) 
            fFileNameSchemaHistory = IniProvider.Write(FileNameSchemaHistory, ConfigName);
        if (DownloadCustomArguments != fDownloadCustomArguments) 
            fDownloadCustomArguments = IniProvider.Write(DownloadCustomArguments, ConfigName);
        if (CustomArgumentsIndex != fCustomArgumentsIndex) 
            fCustomArgumentsIndex = IniProvider.Write(CustomArgumentsIndex, ConfigName);
        if (MainFormLocation != fMainFormLocation) 
            fMainFormLocation = IniProvider.Write(MainFormLocation, ConfigName);
        if (ExtendedDownloaderLocation != fExtendedDownloaderLocation) 
            fExtendedDownloaderLocation = IniProvider.Write(ExtendedDownloaderLocation, ConfigName);
        if (ExtendedDownloaderSize != fExtendedDownloaderSize) 
            fExtendedDownloaderSize = IniProvider.Write(ExtendedDownloaderSize, ConfigName);
        if (ArchiveDownloaderLocation != fArchiveDownloaderLocation) 
            fArchiveDownloaderLocation = IniProvider.Write(ArchiveDownloaderLocation, ConfigName);
        if (LogLocation != fLogLocation) 
            fLogLocation = IniProvider.Write(LogLocation, ConfigName);
        if (LogSize != fLogSize) 
            fLogSize = IniProvider.Write(LogSize, ConfigName);
        if (ExtendedDownloadVideoColumns != fExtendedDownloadVideoColumns)
            fExtendedDownloadVideoColumns = IniProvider.Write(ExtendedDownloadVideoColumns, ConfigName);
        if (ExtendedDownloadAudioColumns != fExtendedDownloadAudioColumns)
            fExtendedDownloadAudioColumns = IniProvider.Write(ExtendedDownloadAudioColumns, ConfigName);
        if (ExtendedDownloadUnknownColumns != fExtendedDownloadUnknownColumns)
            fExtendedDownloadUnknownColumns = IniProvider.Write(ExtendedDownloadUnknownColumns, ConfigName);
        if (QuickDownloaderLocation != fQuickDownloaderLocation)
            fQuickDownloaderLocation = IniProvider.Write(QuickDownloaderLocation, ConfigName);
    }
}