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
    public int BatchFormX = -32000;
    public int BatchFormY = -32000;
    public Size MainFormSize = new(0, 0);
    public Size SettingsFormSize = new(0, 0);
    public string FileNameSchemaHistory = "%(title)s-%(id)s.%(ext)s|%(uploader)s\\(%(playlist_index)s) %(title)s-%(id)s.%(ext)s";
    public string DownloadCustomArguments = string.Empty;
    public int CustomArgumentsIndex = -1;
    public Point MainFormLocation = new(-32000, -32000);

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
    private int fBatchFormX = -32000;
    private int fBatchFormY = -32000;
    private Size fMainFormSize = new(0, 0);
    private Size fSettingsFormSize = new(0, 0);
    private string fFileNameSchemaHistory = "%(title)s-%(id)s.%(ext)s|%(uploader)s\\(%(playlist_index)s) %(title)s-%(id)s.%(ext)s";
    private string fDownloadCustomArguments = string.Empty;
    private int fCustomArgumentsIndex = -1;
    private Point fMainFormLocation = new(-32000, -32000);
    #endregion

    public void Load() {
        if (Ini.KeyExists("downloadType", ConfigName)) {
            downloadType = fdownloadType = Ini.ReadInt("downloadType", ConfigName);
        }
        if (Ini.KeyExists("convertSaveVideoIndex", ConfigName)) {
            convertSaveVideoIndex = fconvertSaveVideoIndex = Ini.ReadInt("convertSaveVideoIndex", "Saved");
        }
        if (Ini.KeyExists("convertSaveAudioIndex", "Saved")) {
            convertSaveAudioIndex = fconvertSaveAudioIndex = Ini.ReadInt("convertSaveAudioIndex", "Saved");
        }
        if (Ini.KeyExists("convertSaveUnknownIndex", ConfigName)) {
            convertSaveUnknownIndex = fconvertSaveUnknownIndex = Ini.ReadInt("convertSaveUnknownIndex", "Saved");
        }
        if (Ini.KeyExists("convertType", ConfigName)) {
            convertType = fconvertType = Ini.ReadInt("convertType", ConfigName);
        }
        if (Ini.KeyExists("convertCustom", ConfigName)) {
            convertCustom = fconvertCustom = Ini.ReadString("convertCustom", ConfigName);
        }
        if (Ini.KeyExists("videoQuality", ConfigName)) {
            videoQuality = fvideoQuality = Ini.ReadInt("videoQuality", ConfigName);
        }
        if (Ini.KeyExists("audioQuality", ConfigName)) {
            audioQuality = faudioQuality = Ini.ReadInt("audioQuality", ConfigName);
        }
        if (Ini.KeyExists("VideoFormat", ConfigName)) {
            VideoFormat = fVideoFormat = Ini.ReadInt("VideoFormat", ConfigName);
        }
        if (Ini.KeyExists("AudioFormat", ConfigName)) {
            AudioFormat = fAudioFormat = Ini.ReadInt("AudioFormat", ConfigName);
        }
        if (Ini.KeyExists("AudioVBRQuality", ConfigName)) {
            AudioVBRQuality = fAudioVBRQuality = Ini.ReadInt("AudioVBRQuality", ConfigName);
        }
        if (Ini.KeyExists("BatchFormX", ConfigName)) {
            BatchFormX = fBatchFormX = Ini.ReadInt("BatchFormX", ConfigName);
        }
        if (Ini.KeyExists("BatchFormY", ConfigName)) {
            BatchFormY = fBatchFormY = Ini.ReadInt("BatchFormY", ConfigName);
        }
        if (Ini.KeyExists("MainFormSize", ConfigName)) {
            MainFormSize = fMainFormSize = Ini.ReadSize("MainFormSize", ConfigName);
        }
        if (Ini.KeyExists("SettingsFormSize", ConfigName)) {
            SettingsFormSize = fSettingsFormSize = Ini.ReadSize("SettingsFormSize", ConfigName);
        }
        if (Ini.KeyExists("FileNameSchemaHistory", ConfigName)) {
            FileNameSchemaHistory = fFileNameSchemaHistory = Ini.ReadString("FileNameSchemaHistory", ConfigName);
        }
        if (Ini.KeyExists("DownloadCustomArguments", ConfigName)) {
            DownloadCustomArguments = fDownloadCustomArguments = Ini.ReadString("DownloadCustomArguments", ConfigName);
        }
        if (Ini.KeyExists("CustomArgumentsIndex", ConfigName)) {
            CustomArgumentsIndex = fCustomArgumentsIndex = Ini.ReadInt("CustomArgumentsIndex", ConfigName);
        }
        if (Ini.KeyExists("MainFormLocation", ConfigName)) {
            MainFormLocation = fMainFormLocation = Ini.ReadPoint("MainFormLocation", ConfigName);
        }
    }

    public void Save() {
        if (downloadType != fdownloadType) {
            Ini.Write("downloadType", downloadType, ConfigName);
            fdownloadType = downloadType;
        }
        if (convertSaveVideoIndex != fconvertSaveVideoIndex) {
            Ini.Write("convertSaveVideoIndex", convertSaveVideoIndex, ConfigName);
            fconvertSaveVideoIndex = convertSaveVideoIndex;
        }
        if (convertSaveAudioIndex != fconvertSaveAudioIndex) {
            Ini.Write("convertSaveAudioIndex", convertSaveAudioIndex, ConfigName);
            fconvertSaveAudioIndex = convertSaveAudioIndex;
        }
        if (convertSaveUnknownIndex != fconvertSaveUnknownIndex) {
            Ini.Write("convertSaveUnknownIndex", convertSaveUnknownIndex, ConfigName);
            fconvertSaveUnknownIndex = convertSaveUnknownIndex;
        }
        if (convertType != fconvertType) {
            Ini.Write("convertType", convertType, ConfigName);
            fconvertType = convertType;
        }
        if (convertCustom != fconvertCustom) {
            Ini.Write("convertCustom", convertCustom, ConfigName);
            fconvertCustom = convertCustom;
        }
        if (videoQuality != fvideoQuality) {
            Ini.Write("videoQuality", videoQuality, ConfigName);
            fvideoQuality = videoQuality;
        }
        if (audioQuality != faudioQuality) {
            Ini.Write("audioQuality", audioQuality, ConfigName);
            faudioQuality = audioQuality;
        }
        if (VideoFormat != fVideoFormat) {
            Ini.Write("VideoFormat", VideoFormat, ConfigName);
            fVideoFormat = VideoFormat;
        }
        if (AudioFormat != fAudioFormat) {
            Ini.Write("AudioFormat", AudioFormat, ConfigName);
            fAudioFormat = AudioFormat;
        }
        if (AudioVBRQuality != fAudioVBRQuality) {
            Ini.Write("AudioVBRQuality", AudioVBRQuality, ConfigName);
            fAudioVBRQuality = AudioVBRQuality;
        }
        if (BatchFormX != fBatchFormX) {
            Ini.Write("BatchFormX", BatchFormX, ConfigName);
            fBatchFormX = BatchFormX;
        }
        if (BatchFormY != fBatchFormY) {
            Ini.Write("BatchFormY", BatchFormY, ConfigName);
            fBatchFormY = BatchFormY;
        }
        if (MainFormSize != fMainFormSize) {
            Ini.Write("MainFormSize", MainFormSize, ConfigName);
            fMainFormSize = MainFormSize;
        }
        if (SettingsFormSize != fSettingsFormSize) {
            Ini.Write("SettingsFormSize", SettingsFormSize, ConfigName);
            fSettingsFormSize = SettingsFormSize;
        }
        if (FileNameSchemaHistory != fFileNameSchemaHistory) {
            Ini.Write("FileNameSchemaHistory", FileNameSchemaHistory, ConfigName);
            fFileNameSchemaHistory = FileNameSchemaHistory;
        }
        if (DownloadCustomArguments != fDownloadCustomArguments) {
            Ini.Write("DownloadCustomArguments", DownloadCustomArguments, ConfigName);
            fDownloadCustomArguments = DownloadCustomArguments;
        }
        if (CustomArgumentsIndex != fCustomArgumentsIndex) {
            Ini.Write("CustomArgumentsIndex", CustomArgumentsIndex, ConfigName);
            fCustomArgumentsIndex = CustomArgumentsIndex;
        }
        if (MainFormLocation != fMainFormLocation) {
            Ini.Write("MainFormLocation", MainFormLocation, ConfigName);
            fMainFormLocation = MainFormLocation;
        }
    }
}