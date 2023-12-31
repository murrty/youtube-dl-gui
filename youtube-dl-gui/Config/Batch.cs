#nullable enable
namespace youtube_dl_gui;
internal static class Batch {
    private const string ConfigName = "Batch";

    static Batch() {
        Log.Write("Loading Batch config.");

        fSelectedType = IniProvider.Read(SelectedType, -1, ConfigName);
        fSelectedVideoQuality = IniProvider.Read(SelectedVideoQuality, 0, ConfigName);
        fSelectedVideoFormat = IniProvider.Read(SelectedVideoFormat, 0, ConfigName);
        fSelectedAudioQuality = IniProvider.Read(SelectedAudioQuality, 0, ConfigName);
        fSelectedAudioFormat = IniProvider.Read(SelectedAudioFormat, 0, ConfigName);
        fDownloadVideoSound = IniProvider.Read(DownloadVideoSound, true, ConfigName);
        fDownloadAudioVBR = IniProvider.Read(DownloadAudioVBR, false, ConfigName);
        fSelectedAudioQualityVBR = IniProvider.Read(SelectedAudioQualityVBR, 0, ConfigName);
        fCustomArguments = IniProvider.Read(CustomArguments, string.Empty, ConfigName);
        fClipboardScannerNoticeViewed = IniProvider.Read(ClipboardScannerNoticeViewed, false, ConfigName);
        fClipboardScannerVerifyLinks = IniProvider.Read(ClipboardScannerVerifyLinks, true, ConfigName);
    }

    public static int SelectedType {
        get => fSelectedType;
        set {
            if (fSelectedType != value) {
                fSelectedType = value;
                IniProvider.Write(SelectedType, ConfigName);
            }
        }
    }
    private static int fSelectedType;

    public static int SelectedVideoQuality {
        get => fSelectedVideoQuality;
        set {
            if (fSelectedVideoQuality != value) {
                fSelectedVideoQuality = value;
                IniProvider.Write(SelectedVideoQuality, ConfigName);
            }
        }
    }
    private static int fSelectedVideoQuality;

    public static int SelectedVideoFormat {
        get => fSelectedVideoFormat;
        set {
            if (fSelectedVideoFormat != value) {
                fSelectedVideoFormat = value;
                IniProvider.Write(SelectedVideoFormat, ConfigName);
            }
        }
    }
    private static int fSelectedVideoFormat;

    public static int SelectedAudioQuality {
        get => fSelectedAudioQuality;
        set {
            if (fSelectedAudioQuality != value) {
                fSelectedAudioQuality = value;
                IniProvider.Write(SelectedAudioQuality, ConfigName);
            }
        }
    }
    private static int fSelectedAudioQuality;

    public static int SelectedAudioFormat {
        get => fSelectedAudioFormat;
        set {
            if (fSelectedAudioFormat != value) {
                fSelectedAudioFormat = value;
                IniProvider.Write(SelectedAudioFormat, ConfigName);
            }
        }
    }
    private static int fSelectedAudioFormat;

    public static bool DownloadVideoSound {
        get => fDownloadVideoSound;
        set {
            if (fDownloadVideoSound != value) {
                fDownloadVideoSound = value;
                IniProvider.Write(DownloadVideoSound, ConfigName);
            }
        }
    }
    private static bool fDownloadVideoSound;

    public static bool DownloadAudioVBR {
        get => fDownloadAudioVBR;
        set {
            if (fDownloadAudioVBR != value) {
                fDownloadAudioVBR = value;
                IniProvider.Write(DownloadAudioVBR, ConfigName);
            }
        }
    }
    private static bool fDownloadAudioVBR;

    public static int SelectedAudioQualityVBR {
        get => fSelectedAudioQualityVBR;
        set {
            if (fSelectedAudioQualityVBR != value) {
                fSelectedAudioQualityVBR = value;
                IniProvider.Write(SelectedAudioQualityVBR, ConfigName);
            }
        }
    }
    private static int fSelectedAudioQualityVBR;

    public static string CustomArguments {
        get => fCustomArguments;
        set {
            if (fCustomArguments != value) {
                fCustomArguments = value;
                IniProvider.Write(CustomArguments, ConfigName);
            }
        }
    }
    private static string fCustomArguments;

    public static bool ClipboardScannerNoticeViewed {
        get => fClipboardScannerNoticeViewed;
        set {
            if (fClipboardScannerNoticeViewed != value) {
                fClipboardScannerNoticeViewed = value;
                IniProvider.Write(ClipboardScannerNoticeViewed, ConfigName);
            }
        }
    }
    private static bool fClipboardScannerNoticeViewed;

    public static bool ClipboardScannerVerifyLinks {
        get => fClipboardScannerVerifyLinks;
        set {
            if (fClipboardScannerVerifyLinks != value) {
                fClipboardScannerVerifyLinks = value;
                IniProvider.Write(ClipboardScannerVerifyLinks, ConfigName);
            }
        }
    }
    private static bool fClipboardScannerVerifyLinks;
}