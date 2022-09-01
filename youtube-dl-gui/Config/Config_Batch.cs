namespace youtube_dl_gui;

internal class Config_Batch {
    private const string ConfigName = "Batch";

    public int SelectedType = -1;
    public int SelectedVideoQuality = 0;
    public int SelectedVideoFormat = 0;
    public int SelectedAudioQuality = 0;
    public int SelectedAudioFormat = 0;
    public bool DownloadVideoSound = false;
    public bool DownloadAudioVBR = false;
    public int SelectedAudioQualityVBR = 0;
    public string CustomArguments = string.Empty;
    public bool ClipboardScannerNoticeViewed = false;
    public bool ClipboardScannerVerifyLinks = true;

    private int fSelectedType = -1;
    private int fSelectedVideoQuality = 0;
    private int fSelectedVideoFormat = 0;
    private int fSelectedAudioQuality = 0;
    private int fSelectedAudioFormat = 0;
    private bool fDownloadVideoSound = false;
    private bool fDownloadAudioVBR = false;
    private int fSelectedAudioQualityVBR = 0;
    private string fCustomArguments = string.Empty;
    private bool fClipboardScannerNoticeViewed = false;
    private bool fClipboardScannerVerifyLinks = true;

    public void Save() {
        if (SelectedType != fSelectedType) {
            Ini.Write("SelectedType", SelectedType, ConfigName);
            fSelectedType = SelectedType;
        }
        if (SelectedVideoQuality != fSelectedVideoQuality) {
            Ini.Write("SelectedVideoQuality", SelectedVideoQuality, ConfigName);
            fSelectedVideoQuality = SelectedVideoQuality;
        }
        if (SelectedVideoFormat != fSelectedVideoFormat) {
            Ini.Write("SelectedVideoFormat", SelectedVideoFormat, ConfigName);
            fSelectedVideoFormat = SelectedVideoFormat;
        }
        if (SelectedAudioQuality != fSelectedAudioQuality) {
            Ini.Write("SelectedAudioQuality", SelectedAudioQuality, ConfigName);
            fSelectedAudioQuality = SelectedAudioQuality;
        }
        if (SelectedAudioFormat != fSelectedAudioFormat) {
            Ini.Write("SelectedAudioFormat", SelectedAudioFormat, ConfigName);
            fSelectedAudioFormat = SelectedAudioFormat;
        }
        if (DownloadVideoSound != fDownloadVideoSound) {
            Ini.Write("DownloadVideoSound", DownloadVideoSound, ConfigName);
            fDownloadVideoSound = DownloadVideoSound;
        }
        if (DownloadAudioVBR != fDownloadAudioVBR) {
            Ini.Write("DownloadAudioVBR", DownloadAudioVBR, ConfigName);
            fDownloadAudioVBR = DownloadAudioVBR;
        }
        if (SelectedAudioQualityVBR != fSelectedAudioQualityVBR) {
            Ini.Write("SelectedAudioQualityVBR", SelectedAudioQualityVBR, ConfigName);
            fSelectedAudioQualityVBR = SelectedAudioQualityVBR;
        }
        if (CustomArguments != fCustomArguments) {
            Ini.Write("CustomArguments", CustomArguments, ConfigName);
            fCustomArguments = CustomArguments;
        }
        if (ClipboardScannerNoticeViewed != fClipboardScannerNoticeViewed) {
            Ini.Write("ClipboardScannerNoticeViewed", ClipboardScannerNoticeViewed, ConfigName);
            fClipboardScannerNoticeViewed = ClipboardScannerNoticeViewed;
        }
        if (ClipboardScannerVerifyLinks != fClipboardScannerVerifyLinks) {
            Ini.Write("ClipboardScannerVerifyLinks", ClipboardScannerVerifyLinks, ConfigName);
            fClipboardScannerVerifyLinks = ClipboardScannerVerifyLinks;
        }
    }

    public void Load() {
        if (Ini.KeyExists("SelectedType", ConfigName)) {
            SelectedType = fSelectedType = Ini.ReadInt("SelectedType", ConfigName);
        }
        if (Ini.KeyExists("SelectedVideoQuality", ConfigName)) {
            SelectedVideoQuality = fSelectedVideoQuality = Ini.ReadInt("SelectedVideoQuality", ConfigName);
        }
        if (Ini.KeyExists("SelectedVideoFormat", ConfigName)) {
            SelectedVideoFormat = fSelectedVideoFormat = Ini.ReadInt("SelectedVideoFormat", ConfigName);
        }
        if (Ini.KeyExists("SelectedAudioQuality", ConfigName)) {
            SelectedAudioQuality = fSelectedAudioQuality = Ini.ReadInt("SelectedAudioQuality", ConfigName);
        }
        if (Ini.KeyExists("SelectedAudioFormat", ConfigName)) {
            SelectedAudioFormat = fSelectedAudioFormat = Ini.ReadInt("SelectedAudioFormat", ConfigName);
        }
        if (Ini.KeyExists("DownloadVideoSound", ConfigName)) {
            DownloadVideoSound = fDownloadVideoSound = Ini.ReadBool("DownloadVideoSound", ConfigName);
        }
        if (Ini.KeyExists("DownloadAudioVBR", ConfigName)) {
            DownloadAudioVBR = fDownloadAudioVBR = Ini.ReadBool("DownloadAudioVBR", ConfigName);
        }
        if (Ini.KeyExists("SelectedAudioQualityVBR", ConfigName)) {
            SelectedAudioQualityVBR = fSelectedAudioQualityVBR = Ini.ReadInt("SelectedAudioQualityVBR", ConfigName);
        }
        if (Ini.KeyExists("CustomArguments", ConfigName)) {
            CustomArguments = fCustomArguments = Ini.ReadString("CustomArguments", ConfigName);
        }
        if (Ini.KeyExists("ClipboardScannerNoticeViewed", ConfigName)) {
            ClipboardScannerNoticeViewed = fClipboardScannerNoticeViewed = Ini.ReadBool("ClipboardScannerNoticeViewed", ConfigName);
        }
        if (Ini.KeyExists("ClipboardScannerVerifyLinks", ConfigName)) {
            ClipboardScannerVerifyLinks = fClipboardScannerVerifyLinks = Ini.ReadBool("ClipboardScannerVerifyLinks", ConfigName);
        }
    }
}