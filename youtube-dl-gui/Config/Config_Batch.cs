namespace youtube_dl_gui;

internal class Config_Batch {
    private const string ConfigName = "Batch";

    #region Properties
    public int SelectedType { get; set; }
    public int SelectedVideoQuality { get; set; }
    public int SelectedVideoFormat { get; set; }
    public int SelectedAudioQuality { get; set; }
    public int SelectedAudioFormat { get; set; }
    public bool DownloadVideoSound { get; set; }
    public bool DownloadAudioVBR { get; set; }
    public int SelectedAudioQualityVBR { get; set; }
    public string CustomArguments { get; set; }
    public bool ClipboardScannerNoticeViewed { get; set; }
    public bool ClipboardScannerVerifyLinks { get; set; }

    private int fSelectedType { get; set; }
    private int fSelectedVideoQuality { get; set; }
    private int fSelectedVideoFormat { get; set; }
    private int fSelectedAudioQuality { get; set; }
    private int fSelectedAudioFormat { get; set; }
    private bool fDownloadVideoSound { get; set; }
    private bool fDownloadAudioVBR { get; set; }
    private int fSelectedAudioQualityVBR { get; set; }
    private string fCustomArguments { get; set; }
    private bool fClipboardScannerNoticeViewed { get; set; }
    private bool fClipboardScannerVerifyLinks { get; set; }
    #endregion

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