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
        SelectedType = fSelectedType = IniProvider.Read(SelectedType, -1, ConfigName);
        SelectedVideoQuality = fSelectedVideoQuality = IniProvider.Read(SelectedVideoQuality, 0, ConfigName);
        SelectedVideoFormat = fSelectedVideoFormat = IniProvider.Read(SelectedVideoFormat, 0, ConfigName);
        SelectedAudioQuality = fSelectedAudioQuality = IniProvider.Read(SelectedAudioQuality, 0, ConfigName);
        SelectedAudioFormat = fSelectedAudioFormat = IniProvider.Read(SelectedAudioFormat, 0, ConfigName);
        DownloadVideoSound = fDownloadVideoSound = IniProvider.Read(DownloadVideoSound, true, ConfigName);
        DownloadAudioVBR = fDownloadAudioVBR = IniProvider.Read(DownloadAudioVBR, false, ConfigName);
        SelectedAudioQualityVBR = fSelectedAudioQualityVBR = IniProvider.Read(SelectedAudioQualityVBR, 0, ConfigName);
        CustomArguments = fCustomArguments = IniProvider.Read(CustomArguments, string.Empty, ConfigName);
        ClipboardScannerNoticeViewed = fClipboardScannerNoticeViewed = IniProvider.Read(ClipboardScannerNoticeViewed, false, ConfigName);
        ClipboardScannerVerifyLinks = fClipboardScannerVerifyLinks = IniProvider.Read(ClipboardScannerVerifyLinks, true, ConfigName);
    }

    public void Save() {
        Log.Write("Saving Batch config.");
        if (SelectedType != fSelectedType)
            fSelectedType = IniProvider.Write(SelectedType, ConfigName);
        if (SelectedVideoQuality != fSelectedVideoQuality)
            fSelectedVideoQuality = IniProvider.Write(SelectedVideoQuality, ConfigName);
        if (SelectedVideoFormat != fSelectedVideoFormat)
            fSelectedVideoFormat = IniProvider.Write(SelectedVideoFormat, ConfigName);
        if (SelectedAudioQuality != fSelectedAudioQuality)
            fSelectedAudioQuality = IniProvider.Write(SelectedAudioQuality, ConfigName);
        if (SelectedAudioFormat != fSelectedAudioFormat)
            fSelectedAudioFormat = IniProvider.Write(SelectedAudioFormat, ConfigName);
        if (DownloadVideoSound != fDownloadVideoSound)
            fDownloadVideoSound = IniProvider.Write(DownloadVideoSound, ConfigName);
        if (DownloadAudioVBR != fDownloadAudioVBR)
            fDownloadAudioVBR = IniProvider.Write(DownloadAudioVBR, ConfigName);
        if (SelectedAudioQualityVBR != fSelectedAudioQualityVBR)
            fSelectedAudioQualityVBR = IniProvider.Write(SelectedAudioQualityVBR, ConfigName);
        if (CustomArguments != fCustomArguments)
            fCustomArguments = IniProvider.Write(CustomArguments, ConfigName);
        if (ClipboardScannerNoticeViewed != fClipboardScannerNoticeViewed)
            fClipboardScannerNoticeViewed = IniProvider.Write(ClipboardScannerNoticeViewed, ConfigName);
        if (ClipboardScannerVerifyLinks != fClipboardScannerVerifyLinks)
            fClipboardScannerVerifyLinks = IniProvider.Write(ClipboardScannerVerifyLinks, ConfigName);
    }
}