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

    public void Load() {
        Log.Write("Loading Batch config.");
        SelectedType = fSelectedType = Ini.Read(SelectedType, -1, ConfigName);
        SelectedVideoQuality = fSelectedVideoQuality = Ini.Read(SelectedVideoQuality, 0, ConfigName);
        SelectedVideoFormat = fSelectedVideoFormat = Ini.Read(SelectedVideoFormat, 0, ConfigName);
        SelectedAudioQuality = fSelectedAudioQuality = Ini.Read(SelectedAudioQuality, 0, ConfigName);
        SelectedAudioFormat = fSelectedAudioFormat = Ini.Read(SelectedAudioFormat, 0, ConfigName);
        DownloadVideoSound = fDownloadVideoSound = Ini.Read(DownloadVideoSound, true, ConfigName);
        DownloadAudioVBR = fDownloadAudioVBR = Ini.Read(DownloadAudioVBR, false, ConfigName);
        SelectedAudioQualityVBR = fSelectedAudioQualityVBR = Ini.Read(SelectedAudioQualityVBR, 0, ConfigName);
        CustomArguments = fCustomArguments = Ini.Read(CustomArguments, string.Empty, ConfigName);
        ClipboardScannerNoticeViewed = fClipboardScannerNoticeViewed = Ini.Read(ClipboardScannerNoticeViewed, false, ConfigName);
        ClipboardScannerVerifyLinks = fClipboardScannerVerifyLinks = Ini.Read(ClipboardScannerVerifyLinks, true, ConfigName);
    }

    public void Save() {
        Log.Write("Saving Batch config.");
        if (SelectedType != fSelectedType)
            fSelectedType = Ini.Write(SelectedType, ConfigName);
        if (SelectedVideoQuality != fSelectedVideoQuality)
            fSelectedVideoQuality = Ini.Write(SelectedVideoQuality, ConfigName);
        if (SelectedVideoFormat != fSelectedVideoFormat)
            fSelectedVideoFormat = Ini.Write(SelectedVideoFormat, ConfigName);
        if (SelectedAudioQuality != fSelectedAudioQuality)
            fSelectedAudioQuality = Ini.Write(SelectedAudioQuality, ConfigName);
        if (SelectedAudioFormat != fSelectedAudioFormat)
            fSelectedAudioFormat = Ini.Write(SelectedAudioFormat, ConfigName);
        if (DownloadVideoSound != fDownloadVideoSound)
            fDownloadVideoSound = Ini.Write(DownloadVideoSound, ConfigName);
        if (DownloadAudioVBR != fDownloadAudioVBR)
            fDownloadAudioVBR = Ini.Write(DownloadAudioVBR, ConfigName);
        if (SelectedAudioQualityVBR != fSelectedAudioQualityVBR)
            fSelectedAudioQualityVBR = Ini.Write(SelectedAudioQualityVBR, ConfigName);
        if (CustomArguments != fCustomArguments)
            fCustomArguments = Ini.Write(CustomArguments, ConfigName);
        if (ClipboardScannerNoticeViewed != fClipboardScannerNoticeViewed)
            fClipboardScannerNoticeViewed = Ini.Write(ClipboardScannerNoticeViewed, ConfigName);
        if (ClipboardScannerVerifyLinks != fClipboardScannerVerifyLinks)
            fClipboardScannerVerifyLinks = Ini.Write(ClipboardScannerVerifyLinks, ConfigName);
    }
}