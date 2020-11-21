using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace youtube_dl_gui {
    class CheckSettings {
        public static bool IsPortable() {
            return File.Exists(Environment.CurrentDirectory + "\\settings.ini");
        }
        public static void LoadPortableSettings() {
            #region Batch
            if (Ini.KeyExists("SelectedType", "Batch")) {
                Batch.Default.SelectedType = Ini.ReadInt("SelectedType", "Batch");
            }
            if (Ini.KeyExists("SelectedVideoQuality", "Batch")) {
                Batch.Default.SelectedVideoQuality = Ini.ReadInt("SelectedVideoQuality", "Batch");
            }
            if (Ini.KeyExists("SelectedVideoFormat", "Batch")) {
                Batch.Default.SelectedVideoFormat = Ini.ReadInt("SelectedVideoFormat", "Batch");
            }
            if (Ini.KeyExists("SelectedAudioQuality", "Batch")) {
                Batch.Default.SelectedAudioQuality = Ini.ReadInt("SelectedAudioQuality", "Batch");
            }
            if (Ini.KeyExists("SelectedAudioFormat", "Batch")) {
                Batch.Default.SelectedAudioFormat = Ini.ReadInt("SelectedAudioFormat", "Batch");
            }
            if (Ini.KeyExists("DownloadVideoSound", "Batch")) {
                Batch.Default.DownloadVideoSound = Ini.ReadBool("DownloadVideoSound", "Batch");
            }
            if (Ini.KeyExists("DownloadAudioVBR", "Batch")) {
                Batch.Default.DownloadAudioVBR = Ini.ReadBool("DownloadAudioVBR", "Batch");
            }
            if (Ini.KeyExists("SelectedAudioQualityVBR", "Batch")) {
                Batch.Default.SelectedAudioQualityVBR = Ini.ReadInt("SelectedAudioQualityVBR", "Batch");
            }
            if (Ini.KeyExists("CustomArguments", "Batch")) {
                Batch.Default.CustomArguments = Ini.ReadString("CustomArguments", "Batch");
            }
            #endregion
            #region Converts
            if (Ini.KeyExists("detectFiletype", "Converts")) {
                Converts.Default.detectFiletype = Ini.ReadBool("detectFiletype", "Converts");
            }
            if (Ini.KeyExists("clearOutput", "Converts")) {
                Converts.Default.clearOutput = Ini.ReadBool("clearOutput", "Converts");
            }
            if (Ini.KeyExists("clearInput", "Converts")) {
                Converts.Default.clearInput = Ini.ReadBool("clearInput", "Converts");
            }
            if (Ini.KeyExists("videoBitrate", "Converts")) {
                Converts.Default.videoBitrate = Ini.ReadInt("videoBitrate", "Converts");
            }
            if (Ini.KeyExists("videoPreset", "Converts")) {
                Converts.Default.videoPreset = Ini.ReadInt("videoPreset", "Converts");
            }
            if (Ini.KeyExists("videoProfile", "Converts")) {
                Converts.Default.videoProfile = Ini.ReadInt("videoProfile", "Converts");
            }
            if (Ini.KeyExists("videoCRF", "Converts")) {
                Converts.Default.videoCRF = Ini.ReadInt("videoCRF", "Converts");
            }
            if (Ini.KeyExists("videoFastStart", "Converts")) {
                Converts.Default.videoFastStart = Ini.ReadBool("videoFastStart", "Converts");
            }
            if (Ini.KeyExists("hideFFmpegCompile", "Converts")) {
                Converts.Default.hideFFmpegCompile = Ini.ReadBool("hideFFmpegCompile", "Converts");
            }
            if (Ini.KeyExists("audioBitrate", "Converts")) {
                Converts.Default.audioBitrate = Ini.ReadInt("audioBitrate", "Converts");
            }
            if (Ini.KeyExists("videoUseBitrate", "Converts")) {
                Converts.Default.videoUseBitrate = Ini.ReadBool("videoUseBitrate", "Converts");
            }
            if (Ini.KeyExists("videoUsePreset", "Converts")) {
                Converts.Default.videoUsePreset = Ini.ReadBool("videoUsePreset", "Converts");
            }
            if (Ini.KeyExists("videoUseProfile", "Converts")) {
                Converts.Default.videoUseProfile = Ini.ReadBool("videoUseProfile", "Converts");
            }
            if (Ini.KeyExists("videoUseCRF", "Converts")) {
                Converts.Default.videoUseCRF = Ini.ReadBool("videoUseCRF", "Converts");
            }
            if (Ini.KeyExists("audioUseBitrate", "Converts")) {
                Converts.Default.audioUseBitrate = Ini.ReadBool("audioUseBitrate", "Converts");
            }
            #endregion
            #region Downloads
            if (Ini.KeyExists("downloadPath", "Downloads")) {
                Downloads.Default.downloadPath = Ini.ReadString("downloadPath", "Downloads");
            }
            if (Ini.KeyExists("separateDownloads", "Downloads")) {
                Downloads.Default.separateDownloads = Ini.ReadBool("separateDownloads", "Downloads");
            }
            if (Ini.KeyExists("SaveFormatQuality", "Downloads")) {
                Downloads.Default.SaveFormatQuality = Ini.ReadBool("SaveFormatQuality", "Downloads");
            }
            if (Ini.KeyExists("deleteYtdlOnClose", "Downloads")) {
                Downloads.Default.deleteYtdlOnClose = Ini.ReadBool("deleteYtdlOnClose", "Downloads");
            }
            if (Ini.KeyExists("useYtdlUpdater", "Downloads")) {
                Downloads.Default.useYtdlUpdater = Ini.ReadBool("useYtdlUpdater", "Downloads");
            }
            if (Ini.KeyExists("fileNameSchema", "Downloads")) {
                Downloads.Default.fileNameSchema = Ini.ReadString("fileNameSchema", "Downloads");
            }
            if (Ini.KeyExists("fixReddit", "Downloads")) {
                Downloads.Default.fixReddit = Ini.ReadBool("fixReddit", "Downloads");
            }
            if (Ini.KeyExists("PreferFFmpeg", "Downloads")) {
                Downloads.Default.PreferFFmpeg = Ini.ReadBool("PreferFFmpeg", "Downloads");
            }
            if (Ini.KeyExists("separateIntoWebsiteURL", "Downloads")) {
                Downloads.Default.separateIntoWebsiteURL = Ini.ReadBool("separateIntoWebsiteURL", "Downloads");
            }
            if (Ini.KeyExists("SaveSubtitles", "Downloads")) {
                Downloads.Default.SaveSubtitles = Ini.ReadBool("SaveSubtitles", "Downloads");
            }
            if (Ini.KeyExists("subtitlesLanguages", "Downloads")) {
                Downloads.Default.subtitlesLanguages = Ini.ReadString("subtitlesLanguages", "Downloads");
            }
            if (Ini.KeyExists("CloseDownloaderAfterFinish", "Downloads")) {
                Downloads.Default.CloseDownloaderAfterFinish = Ini.ReadBool("CloseDownloaderAfterFinish", "Downloads");
            }
            if (Ini.KeyExists("UseProxy", "Downloads")) {
                Downloads.Default.UseProxy = Ini.ReadBool("UseProxy", "Downloads");
            }
            if (Ini.KeyExists("ProxyType", "Downloads")) {
                Downloads.Default.ProxyType = Ini.ReadInt("ProxyType", "Downloads");
            }
            if (Ini.KeyExists("ProxyIP", "Downloads")) {
                Downloads.Default.ProxyIP = Ini.ReadString("ProxyIP", "Downloads");
            }
            if (Ini.KeyExists("ProxyPort", "Downloads")) {
                Downloads.Default.ProxyPort = Ini.ReadString("ProxyPort", "Downloads");
            }
            if (Ini.KeyExists("SaveThumbnail", "Downloads")) {
                Downloads.Default.SaveThumbnail = Ini.ReadBool("SaveThumbnail", "Downloads");
            }
            if (Ini.KeyExists("SaveDescription", "Downloads")) {
                Downloads.Default.SaveDescription = Ini.ReadBool("SaveDescription", "Downloads");
            }
            if (Ini.KeyExists("SaveVideoInfo", "Downloads")) {
                Downloads.Default.SaveVideoInfo = Ini.ReadBool("SaveVideoInfo", "Downloads");
            }
            if (Ini.KeyExists("SaveAnnotations", "Downloads")) {
                Downloads.Default.SaveAnnotations = Ini.ReadBool("SaveAnnotations", "Downloads");
            }
            if (Ini.KeyExists("SubtitleFormat", "Downloads")) {
                Downloads.Default.SubtitleFormat = Ini.ReadString("SubtitleFormat", "Downloads");
            }
            if (Ini.KeyExists("DownloadLimit", "Downloads")) {
                Downloads.Default.DownloadLimit = Ini.ReadInt("DownloadLimit", "Downloads");
            }
            if (Ini.KeyExists("RetryAttempts", "Downloads")) {
                Downloads.Default.RetryAttempts = Ini.ReadInt("RetryAttempts", "Downloads");
            }
            if (Ini.KeyExists("DownloadLimitType", "Downloads")) {
                Downloads.Default.DownloadLimitType = Ini.ReadInt("DownloadLimitType", "Downloads");
            }
            if (Ini.KeyExists("ForceIPv4", "Downloads")) {
                Downloads.Default.ForceIPv4 = Ini.ReadBool("ForceIPv4", "Downloads");
            }
            if (Ini.KeyExists("ForceIPv6", "Downloads")) {
                Downloads.Default.ForceIPv6 = Ini.ReadBool("ForceIPv6", "Downloads");
            }
            if (Ini.KeyExists("LimitDownloads", "Downloads")) {
                Downloads.Default.LimitDownloads = Ini.ReadBool("LimitDownloads", "Downloads");
            }
            if (Ini.KeyExists("EmbedSubtitles", "Downloads")) {
                Downloads.Default.EmbedSubtitles = Ini.ReadBool("EmbedSubtitles", "Downloads");
            }
            if (Ini.KeyExists("EmbedThumbnails", "Downloads")) {
                Downloads.Default.EmbedThumbnails = Ini.ReadBool("EmbedThumbnails", "Downloads");
            }
            if (Ini.KeyExists("VideoDownloadSound", "Downloads")) {
                Downloads.Default.VideoDownloadSound = Ini.ReadBool("VideoDownloadSound", "Downloads");
            }
            if (Ini.KeyExists("AudioDownloadAsVBR", "Downloads")) {
                Downloads.Default.AudioDownloadAsVBR = Ini.ReadBool("AudioDownloadAsVBR", "Downloads");
            }
            if (Ini.KeyExists("KeepOriginalFiles", "Downloads")) {
                Downloads.Default.KeepOriginalFiles = Ini.ReadBool("KeepOriginalFiles", "Downloads");
            }
            if (Ini.KeyExists("WriteMetadata", "Downloads")) {
                Downloads.Default.WriteMetadata = Ini.ReadBool("WriteMetadata", "Downloads");
            }
            if (Ini.KeyExists("SkipBatchTip", "Downloads")) {
                Downloads.Default.SkipBatchTip = Ini.ReadBool("SkipBatchTip", "Downloads");
            }
            if (Ini.KeyExists("AutomaticallyDownloadFromProtocol", "Downloads")) {
                Downloads.Default.AutomaticallyDownloadFromProtocol = Ini.ReadBool("AutomaticallyDownloadFromProtocol", "Downloads");
            }
            #endregion
            #region Errors
            if (Ini.KeyExists("detailedErrors", "Errors")) {
                Errors.Default.detailedErrors = Ini.ReadBool("detailedErrors", "Errors");
            }
            if (Ini.KeyExists("logErrors", "Errors")) {
                Errors.Default.logErrors = Ini.ReadBool("logErrors", "Errors");
            }
            if (Ini.KeyExists("suppressErrors", "Errors")) {
                Errors.Default.suppressErrors = Ini.ReadBool("suppressErrors", "Errors");
            }
            #endregion
            #region General
            if (Ini.KeyExists("UseStaticYtdl", "General")) {
                General.Default.UseStaticYtdl = Ini.ReadBool("UseStaticYtdl", "General");
            }
            if (Ini.KeyExists("ytdlPath", "General")) {
                General.Default.ytdlPath = Ini.ReadString("ytdlPath", "General");
            }
            if (Ini.KeyExists("UseStaticFFmpeg", "General")) {
                General.Default.UseStaticFFmpeg = Ini.ReadBool("UseStaticFFmpeg", "General");
            }
            if (Ini.KeyExists("ffmpegPath", "General")) {
                General.Default.ffmpegPath = Ini.ReadString("ffmpegPath", "General");
            }
            if (Ini.KeyExists("CheckForUpdatesOnLaunch", "General")) {
                General.Default.CheckForUpdatesOnLaunch = Ini.ReadBool("CheckForUpdatesOnLaunch", "General");
            }
            if (Ini.KeyExists("HoverOverURLTextBoxToPaste", "General")) {
                General.Default.HoverOverURLTextBoxToPaste = Ini.ReadBool("HoverOverURLTextBoxToPaste", "General");
            }
            if (Ini.KeyExists("ClearURLOnDownload", "General")) {
                General.Default.ClearURLOnDownload = Ini.ReadBool("ClearURLOnDownload", "General");
            }
            if (Ini.KeyExists("SaveCustomArgs", "General")) {
                General.Default.SaveCustomArgs = Ini.ReadInt("SaveCustomArgs", "General");
            }
            if (Ini.KeyExists("ClearClipboardOnDownload", "General")) {
                General.Default.ClearClipboardOnDownload = Ini.ReadBool("ClearClipboardOnDownload", "General");
            }
            #endregion
            #region Saved
            if (Ini.KeyExists("formLocationX", "Saved")) {
                Saved.Default.formLocationX = Ini.ReadInt("formLocationX", "Saved");
            }
            if (Ini.KeyExists("formLocationY", "Saved")) {
                Saved.Default.formLocationY = Ini.ReadInt("formLocationY", "Saved");
            }
            if (Ini.KeyExists("downloadType", "Saved")) {
                Saved.Default.downloadType = Ini.ReadInt("downloadType", "Saved");
            }
            if (Ini.KeyExists("downloadArgs", "Saved")) {
                Saved.Default.downloadArgs = Ini.ReadString("downloadArgs", "Saved");
            }
            if (Ini.KeyExists("formTrue0", "Saved")) {
                Saved.Default.formTrue0 = Ini.ReadBool("formTrue0", "Saved");
            }
            if (Ini.KeyExists("convertSaveVideoIndex", "Saved")) {
                Saved.Default.convertSaveVideoIndex = Ini.ReadInt("convertSaveVideoIndex", "Saved");
            }
            if (Ini.KeyExists("convertSaveAudioIndex", "Saved")) {
                Saved.Default.convertSaveAudioIndex = Ini.ReadInt("convertSaveAudioIndex", "Saved");
            }
            if (Ini.KeyExists("convertType", "Saved")) {
                Saved.Default.convertType = Ini.ReadInt("convertType", "Saved");
            }
            if (Ini.KeyExists("convertCustom", "Saved")) {
                Saved.Default.convertCustom = Ini.ReadString("convertCustom", "Saved");
            }
            if (Ini.KeyExists("videoQuality", "Saved")) {
                Saved.Default.videoQuality = Ini.ReadInt("videoQuality", "Saved");
            }
            if (Ini.KeyExists("audioQuality", "Saved")) {
                Saved.Default.audioQuality = Ini.ReadInt("audioQuality", "Saved");
            }
            if (Ini.KeyExists("VideoFormat", "Saved")) {
                Saved.Default.VideoFormat = Ini.ReadInt("VideoFormat", "Saved");
            }
            if (Ini.KeyExists("AudioFormat", "Saved")) {
                Saved.Default.AudioFormat = Ini.ReadInt("AudioFormat", "Saved");
            }
            if (Ini.KeyExists("AudioVBRQuality", "Saved")) {
                Saved.Default.AudioVBRQuality = Ini.ReadInt("AudioVBRQuality", "Saved");
            }
            if (Ini.KeyExists("BatchFormX", "Saved")) {
                Saved.Default.BatchFormX = Ini.ReadInt("BatchFormX", "Saved");
            }
            if (Ini.KeyExists("BatchFormY", "Saved")) {
                Saved.Default.BatchFormY = Ini.ReadInt("BatchFormY", "Saved");
            }
            if (Ini.KeyExists("MainFormSize", "Saved")) {
                Saved.Default.MainFormSize = Ini.ReadSize("MainFormSize", "Saved");
            }
            if (Ini.KeyExists("SettingsFormSize", "Saved")) {
                Saved.Default.SettingsFormSize = Ini.ReadSize("SettingsFormSize", "Saved");
            }
            #endregion
            #region Settings
            if (Ini.KeyExists("extensionsName", "Settings")) {
                Settings.Default.extensionsName = Ini.ReadString("extensionsName", "Saved");
            }
            if (Ini.KeyExists("extensionsShort", "Settings")) {
                Settings.Default.extensionsShort = Ini.ReadString("extensionsShort", "Saved");
            }
            if (Ini.KeyExists("LanguageFile", "Settings")) {
                Settings.Default.LanguageFile = Ini.ReadString("LanguageFile", "Saved");
            }
            #endregion
        }
        public static void SavePortableSettings() {
            #region Batch
            Ini.WriteInt("SelectedType", Batch.Default.SelectedType, "Batch");
            Ini.WriteInt("SelectedVideoQuality", Batch.Default.SelectedVideoQuality, "Batch");
            Ini.WriteInt("SelectedVideoFormat", Batch.Default.SelectedVideoFormat, "Batch");
            Ini.WriteInt("SelectedAudioQuality", Batch.Default.SelectedAudioQuality, "Batch");
            Ini.WriteInt("SelectedAudioFormat", Batch.Default.SelectedAudioFormat, "Batch");
            Ini.WriteBool("DownloadVideoSound", Batch.Default.DownloadVideoSound, "Batch");
            Ini.WriteBool("DownloadAudioVBR", Batch.Default.DownloadAudioVBR, "Batch");
            Ini.WriteInt("SelectedAudioQualityVBR", Batch.Default.SelectedAudioQualityVBR, "Batch");
            Ini.WriteString("CustomArguments", Batch.Default.CustomArguments, "Batch");
            #endregion
            #region Converts
            Ini.WriteBool("detectFiletype", Converts.Default.detectFiletype, "Converts");
            Ini.WriteBool("clearOutput", Converts.Default.clearOutput, "Converts");
            Ini.WriteBool("clearInput", Converts.Default.clearInput, "Converts");
            Ini.WriteInt("videoBitrate", Converts.Default.videoBitrate, "Converts");
            Ini.WriteInt("videoPreset", Converts.Default.videoPreset, "Converts");
            Ini.WriteInt("videoProfile", Converts.Default.videoProfile, "Converts");
            Ini.WriteInt("videoCRF", Converts.Default.videoCRF, "Converts");
            Ini.WriteBool("videoFastStart", Converts.Default.videoFastStart, "Converts");
            Ini.WriteBool("hideFFmpegCompile", Converts.Default.hideFFmpegCompile, "Converts");
            Ini.WriteInt("audioBitrate", Converts.Default.audioBitrate, "Converts");
            Ini.WriteBool("videoUseBitrate", Converts.Default.videoUseBitrate, "Converts");
            Ini.WriteBool("videoUsePreset", Converts.Default.videoUsePreset, "Converts");
            Ini.WriteBool("videoUseProfile", Converts.Default.videoUseProfile, "Converts");
            Ini.WriteBool("videoUseCRF", Converts.Default.videoUseCRF, "Converts");
            Ini.WriteBool("audioUseBitrate", Converts.Default.audioUseBitrate, "Converts");
            #endregion
            #region Downloads
            Ini.WriteString("downloadPath", Downloads.Default.downloadPath, "Downloads");
            Ini.WriteBool("separateDownloads", Downloads.Default.separateDownloads, "Downloads");
            Ini.WriteBool("SaveFormatQuality", Downloads.Default.SaveFormatQuality, "Downloads");
            Ini.WriteBool("deleteYtdlOnClose", Downloads.Default.deleteYtdlOnClose, "Downloads");
            Ini.WriteBool("useYtdlUpdater", Downloads.Default.useYtdlUpdater, "Downloads");
            Ini.WriteString("fileNameSchema", Downloads.Default.fileNameSchema, "Downloads");
            Ini.WriteBool("fixReddit", Downloads.Default.fixReddit, "Downloads");
            Ini.WriteBool("PreferFFmpeg", Downloads.Default.PreferFFmpeg, "Downloads");
            Ini.WriteBool("separateIntoWebsiteURL", Downloads.Default.separateIntoWebsiteURL, "Downloads");
            Ini.WriteBool("SaveSubtitles", Downloads.Default.SaveSubtitles, "Downloads");
            Ini.WriteString("subtitlesLanguages", Downloads.Default.subtitlesLanguages, "Downloads");
            Ini.WriteBool("CloseDownloaderAfterFinish", Downloads.Default.CloseDownloaderAfterFinish, "Downloads");
            Ini.WriteBool("UseProxy", Downloads.Default.UseProxy, "Downloads");
            Ini.WriteInt("ProxyType", Downloads.Default.ProxyType, "Downloads");
            Ini.WriteString("ProxyIP", Downloads.Default.ProxyIP, "Downloads");
            Ini.WriteString("ProxyPort", Downloads.Default.ProxyPort, "Downloads");
            Ini.WriteBool("SaveThumbnail", Downloads.Default.SaveThumbnail, "Downloads");
            Ini.WriteBool("SaveDescription", Downloads.Default.SaveDescription, "Downloads");
            Ini.WriteBool("SaveVideoInfo", Downloads.Default.SaveVideoInfo, "Downloads");
            Ini.WriteBool("SaveAnnotations", Downloads.Default.SaveAnnotations, "Downloads");
            Ini.WriteString("SubtitleFormat", Downloads.Default.SubtitleFormat, "Downloads");
            Ini.WriteInt("DownloadLimit", Downloads.Default.DownloadLimit, "Downloads");
            Ini.WriteInt("RetryAttempts", Downloads.Default.RetryAttempts, "Downloads");
            Ini.WriteInt("DownloadLimitType", Downloads.Default.DownloadLimitType, "Downloads");
            Ini.WriteBool("ForceIPv4", Downloads.Default.ForceIPv4, "Downloads");
            Ini.WriteBool("ForceIPv6", Downloads.Default.ForceIPv6, "Downloads");
            Ini.WriteBool("LimitDownloads", Downloads.Default.LimitDownloads, "Downloads");
            Ini.WriteBool("EmbedSubtitles", Downloads.Default.EmbedSubtitles, "Downloads");
            Ini.WriteBool("EmbedThumbnails", Downloads.Default.EmbedThumbnails, "Downloads");
            Ini.WriteBool("VideoDownloadSound", Downloads.Default.VideoDownloadSound, "Downloads");
            Ini.WriteBool("AudioDownloadAsVBR", Downloads.Default.AudioDownloadAsVBR, "Downloads");
            Ini.WriteBool("KeepOriginalFiles", Downloads.Default.KeepOriginalFiles, "Downloads");
            Ini.WriteBool("WriteMetadata", Downloads.Default.WriteMetadata, "Downloads");
            Ini.WriteBool("SkipBatchTip", Downloads.Default.SkipBatchTip, "Downloads");
            Ini.WriteBool("AutomaticallyDownloadFromProtocol", Downloads.Default.AutomaticallyDownloadFromProtocol, "Downloads");
            #endregion
            #region Errors
            Ini.WriteBool("detailedErrors", Errors.Default.detailedErrors, "Errors");
            Ini.WriteBool("logErrors", Errors.Default.logErrors, "Errors");
            Ini.WriteBool("suppressErrors", Errors.Default.suppressErrors, "Errors");
            #endregion
            #region General
            Ini.WriteBool("UseStaticYtdl", General.Default.UseStaticYtdl, "General");
            Ini.WriteString("ytdlPath", General.Default.ytdlPath, "General");
            Ini.WriteBool("UseStaticFFmpeg", General.Default.UseStaticFFmpeg, "General");
            Ini.WriteString("ffmpegPath", General.Default.ffmpegPath, "General");
            Ini.WriteBool("CheckForUpdatesOnLaunch", General.Default.CheckForUpdatesOnLaunch, "General");
            Ini.WriteBool("HoverOverURLTextBoxToPaste", General.Default.HoverOverURLTextBoxToPaste, "General");
            Ini.WriteBool("ClearURLOnDownload", General.Default.ClearURLOnDownload, "General");
            Ini.WriteInt("SaveCustomArgs", General.Default.SaveCustomArgs, "General");
            Ini.WriteBool("ClearClipboardOnDownload", General.Default.ClearClipboardOnDownload, "General");
            #endregion
            #region Saved
            Ini.WriteInt("downloadType", Saved.Default.downloadType, "Saved");
            Ini.WriteString("downloadArgs", Saved.Default.downloadArgs, "Saved");
            Ini.WriteBool("formTrue0", Saved.Default.formTrue0, "Saved");
            Ini.WriteInt("convertSaveVideoIndex", Saved.Default.convertSaveVideoIndex, "Saved");
            Ini.WriteInt("convertSaveAudioIndex", Saved.Default.convertSaveAudioIndex, "Saved");
            Ini.WriteInt("convertType", Saved.Default.convertType, "Saved");
            Ini.WriteString("convertCustom", Saved.Default.convertCustom, "Saved");
            Ini.WriteInt("videoQuality", Saved.Default.videoQuality, "Saved");
            Ini.WriteInt("audioQuality", Saved.Default.audioQuality, "Saved");
            Ini.WriteInt("VideoFormat", Saved.Default.VideoFormat, "Saved");
            Ini.WriteInt("AudioFormat", Saved.Default.AudioFormat, "Saved");
            Ini.WriteInt("AudioVBRQuality", Saved.Default.AudioVBRQuality, "Saved");
            Ini.WriteInt("BatchFormX", Saved.Default.BatchFormX, "Saved");
            Ini.WriteInt("BatchFormY", Saved.Default.BatchFormY, "Saved");
            Ini.WriteSize("MainFormSize", Saved.Default.MainFormSize, "Saved");
            Ini.WriteSize("SettingsFormSize", Saved.Default.SettingsFormSize, "Saved");
            #endregion
            #region Settings
            Ini.WriteString("extensionsName", Settings.Default.extensionsName, "Settings");
            Ini.WriteString("extensionsShort", Settings.Default.extensionsShort, "Settings");
            Ini.WriteString("LanguageFile", Settings.Default.LanguageFile, "Settings");
            #endregion
        }
        public static void CreatePortableSettings() {
            Ini.WriteBool("FirstTime", true, "youtube-dl-gui");
            Ini.WriteString("downloadPath", Downloads.Default.downloadPath, "Downloads");
        }
    }

    class Ini {
        static string Path = Environment.CurrentDirectory + "\\settings.ini";

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);


        public static string ReadString(string Key, string Section) {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }
        public static bool ReadBool(string Key, string Section) {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section, Key.ToLower(), "", RetVal, 255, Path);
            string RetStr = RetVal.ToString().ToLower();

            if (RetStr == "true")
                return true;
            else
                return false;
        }
        public static int ReadInt(string Key, string Section) {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section, Key.ToLower(), "", RetVal, 255, Path);
            string RetStr = RetVal.ToString();
            int RetInt;
            int.TryParse(RetStr, out RetInt);
            return RetInt;
        }

        public static void WriteString(string Key, string Value, string Section) {
            WritePrivateProfileString(Section, Key, Value, Path);
        }
        public static void WriteBool(string Key, bool Value, string Section) {
            string outKey;

            if (Value)
                outKey = "True";
            else
                outKey = "False";

            WritePrivateProfileString(Section, Key, outKey, Path);
        }
        public static void WriteInt(string Key, int Value, string Section) {
            string outKey = Value.ToString();

            WritePrivateProfileString(Section, Key, outKey, Path);
        }

        public static Size ReadSize(string Key, string Section) {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, "", RetVal, 255, Path);
            string[] Value = RetVal.ToString().Split(',');
            return new Size(int.Parse(Value[0]), int.Parse(Value[1]));
        }
        public static void WriteSize(string Key, Size Value, string Section) {
            string outKey = Value.Width + "," + Value.Height;

            WritePrivateProfileString(Section, Key, outKey, Path);
        }

        public static void DeleteKey(string Key, string Section) {
            WriteString(Key, null, Section);
        }
        public static void DeleteSection(string Section) {
            WriteString(null, null, Section);
        }

        public static bool KeyExists(string Key, string Section) {
            return ReadString(Key, Section).Length > 0;
        }
    }

}