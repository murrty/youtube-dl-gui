using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace youtube_dl_gui {

    public enum ConfigType : int {
        None = -1,
        All = 0,
        Initialization = 1,
        Batch = 2,
        Converts = 3,
        Downloads = 4,
        Errors = 5,
        General = 6,
        Saved = 7,
        Settings = 8
    }

    class Config {
        public static volatile Config ProgramConfig;

        public Config_Initialization Initialization;
        public Config_Batch Batch;
        public Config_Converts Converts;
        public Config_Downloads Downloads;
        public Config_Errors Errors;
        public Config_General General;
        public Config_Saved Saved;
        public Config_Settings SettingsConfig;

        public Config() {
            Initialization = new Config_Initialization();
            Batch = new Config_Batch();
            Converts = new Config_Converts();
            Downloads = new Config_Downloads();
            Errors = new Config_Errors();
            General = new Config_General();
            Saved = new Config_Saved();
            SettingsConfig = new Config_Settings();
        }

        public void Load(ConfigType Type) {
            switch (Type) {
                case ConfigType.All:
                    Batch.Load();
                    Converts.Load();
                    Downloads.Load();
                    Errors.Load();
                    General.Load();
                    Saved.Load();
                    SettingsConfig.Load();
                    break;

                case ConfigType.Initialization:
                    Initialization.Load();
                    break;

                case ConfigType.Batch:
                    Batch.Load();
                    break;

                case ConfigType.Converts:
                    Converts.Load();
                    break;

                case ConfigType.Downloads:
                    Downloads.Load();
                    break;

                case ConfigType.Errors:
                    Errors.Load();
                    break;

                case ConfigType.General:
                    General.Load();
                    break;

                case ConfigType.Saved:
                    Saved.Load();
                    break;

                case ConfigType.Settings:
                    SettingsConfig.Load();
                    break;
            }
        }

        public void Save(ConfigType Type) {
            switch (Type) {
                case ConfigType.All:
                    Batch.Save();
                    Converts.Save();
                    Downloads.Save();
                    Errors.Save();
                    General.Save();
                    Saved.Save();
                    SettingsConfig.Save();
                    break;

                case ConfigType.Initialization:
                    Initialization.Save();
                    break;

                case ConfigType.Batch:
                    Batch.Save();
                    break;

                case ConfigType.Converts:
                    Converts.Save();
                    break;

                case ConfigType.Downloads:
                    Downloads.Save();
                    break;

                case ConfigType.Errors:
                    Errors.Save();
                    break;

                case ConfigType.General:
                    General.Save();
                    break;

                case ConfigType.Saved:
                    Saved.Save();
                    break;

                case ConfigType.Settings:
                    SettingsConfig.Save();
                    break;
            }
        }
        public void ConvertConfig(bool UseIni) {
            if (Program.UseIni && !UseIni) {
                Ini.Write("useIni", false);
            }
            else {
                Ini.Write("useIni", true);
            }

            Program.UseIni = UseIni;
            Initialization.ForceSave();
            Batch.ForceSave();
            Converts.ForceSave();
            Downloads.ForceSave();
            Errors.ForceSave();
            General.ForceSave();
            Saved.ForceSave();
            SettingsConfig.ForceSave();
        }

    }

    class Config_Initialization {
        public Config_Initialization() {
            Load();
        }

        public string LanguageFile = string.Empty;
        public bool firstTime = true;
        public decimal SkippedVersion = -1;

        private string LanguageFile_First = string.Empty;
        private bool firstTime_First = true;
        public decimal SkippedVersion_First = -1;

        public void Load() {
            switch (Program.UseIni) {
                case true:
                    switch (Ini.KeyExists("LanguageFile", "Settings")) {
                        case true:
                            LanguageFile = Ini.ReadString("LanguageFile", "Settings");
                            LanguageFile_First = LanguageFile;
                            break;
                    }

                    switch (Ini.KeyExists("firstTime", "youtube-dl-gui")) {
                        case true:
                            firstTime = Ini.ReadBool("firstTime", "youtube-dl-gui");
                            firstTime_First = firstTime;
                            break;
                    }

                    switch (Ini.KeyExists("SkippedVersion", "youtube-dl-gui")) {
                        case true:
                            SkippedVersion = Ini.ReadDecimal("SkippedVersion", "youtube-dl-gui");
                            SkippedVersion_First = SkippedVersion;
                            break;
                    }
                    break;

                case false:
                    LanguageFile = Settings.Settings.Default.LanguageFile;
                    firstTime = Properties.Settings.Default.firstTime;
                    SkippedVersion = Properties.Settings.Default.SkippedVersion;
                    break;
            }
        }
        public void Save() {
            switch (Program.UseIni) {
                case true:
                    switch (LanguageFile != LanguageFile_First) {
                        case true:
                            Ini.Write("LanguageFile", LanguageFile, "Settings");
                            break;
                    }

                    switch (firstTime != firstTime_First) {
                        case true:
                            Ini.Write("firstTime", firstTime, "youtube-dl-gui");
                            break;
                    }

                    switch (SkippedVersion != SkippedVersion_First) {
                        case true:
                            Ini.Write("SkippedVersion", SkippedVersion, "youtube-dl-gui");
                            break;
                    }
                    break;

                case false:
                    bool Save = false;

                    if (Settings.Settings.Default.LanguageFile != LanguageFile) {
                        Settings.Settings.Default.LanguageFile = LanguageFile;
                        Save = true;
                    }

                    if (Properties.Settings.Default.firstTime != firstTime) {
                        Properties.Settings.Default.firstTime = firstTime;
                        Save = true;
                    }

                    if (Properties.Settings.Default.SkippedVersion != SkippedVersion) {
                        Properties.Settings.Default.SkippedVersion = SkippedVersion;
                        Save = true;
                    }

                    switch (Save) {
                        case true:
                            Settings.Settings.Default.Save();
                            Properties.Settings.Default.Save();
                            break;
                    }
                    break;
            }
        }

        public void ForceSave() {
            switch (Program.UseIni) {
                case true:
                    Ini.Write("LanguageFile", LanguageFile, "Settings");
                    Ini.Write("firstTime", firstTime, "youtube-dl-gui");
                    Ini.Write("SkippedVersion", SkippedVersion, "youtube-dl-gui");
                    break;

                case false:
                    Settings.Settings.Default.LanguageFile = LanguageFile;
                    Properties.Settings.Default.firstTime = firstTime;
                    Properties.Settings.Default.SkippedVersion = SkippedVersion;
                    Settings.Settings.Default.Save();
                    Properties.Settings.Default.Save();
                    break;
            }
        }
    }

    class Config_Batch {
        public Config_Batch() {
            Load();
        }

        public int SelectedType = -1;
        public int SelectedVideoQuality = 0;
        public int SelectedVideoFormat = 0;
        public int SelectedAudioQuality = 0;
        public int SelectedAudioFormat = 0;
        public bool DownloadVideoSound = false;
        public bool DownloadAudioVBR = false;
        public int SelectedAudioQualityVBR = 0;
        public string CustomArguments = string.Empty;

        private int SelectedType_First = -1;
        private int SelectedVideoQuality_First = 0;
        private int SelectedVideoFormat_First = 0;
        private int SelectedAudioQuality_First = 0;
        private int SelectedAudioFormat_First = 0;
        private bool DownloadVideoSound_First = false;
        private bool DownloadAudioVBR_First = false;
        private int SelectedAudioQualityVBR_First = 0;
        private string CustomArguments_First = string.Empty;

        public void Save() {
            switch (Program.UseIni) {
                case true:
                    switch (SelectedType != SelectedType_First) {
                        case true:
                            Ini.Write("SelectedType", SelectedType, "Batch");
                            SelectedType_First = SelectedType;
                            break;
                    }
                    switch (SelectedVideoQuality != SelectedVideoQuality_First) {
                        case true:
                            Ini.Write("SelectedVideoQuality", SelectedVideoQuality, "Batch");
                            SelectedVideoQuality_First = SelectedVideoQuality;
                            break;
                    }
                    switch (SelectedVideoFormat != SelectedVideoFormat_First) {
                        case true:
                            Ini.Write("SelectedVideoFormat", SelectedVideoFormat, "Batch");
                            SelectedVideoFormat_First = SelectedVideoFormat;
                            break;
                    }
                    switch (SelectedAudioQuality != SelectedAudioQuality_First) {
                        case true:
                            Ini.Write("SelectedAudioQuality", SelectedAudioQuality, "Batch");
                            SelectedAudioQuality_First = SelectedAudioQuality;
                            break;
                    }
                    switch (SelectedAudioFormat != SelectedAudioFormat_First) {
                        case true:
                            Ini.Write("SelectedAudioFormat", SelectedAudioFormat, "Batch");
                            SelectedAudioFormat_First = SelectedAudioFormat;
                            break;
                    }
                    switch (DownloadVideoSound != DownloadVideoSound_First) {
                        case true:
                            Ini.Write("DownloadVideoSound", DownloadVideoSound, "Batch");
                            DownloadVideoSound_First = DownloadVideoSound;
                            break;
                    }
                    switch (DownloadAudioVBR != DownloadAudioVBR_First) {
                        case true:
                            Ini.Write("DownloadAudioVBR", DownloadAudioVBR, "Batch");
                            DownloadAudioVBR_First = DownloadAudioVBR;
                            break;
                    }
                    switch (SelectedAudioQualityVBR != SelectedAudioQualityVBR_First) {
                        case true:
                            Ini.Write("SelectedAudioQualityVBR", SelectedAudioQualityVBR, "Batch");
                            SelectedAudioQualityVBR_First = SelectedAudioQualityVBR;
                            break;
                    }
                    switch (CustomArguments != CustomArguments_First) {
                        case true:
                            Ini.Write("CustomArguments", CustomArguments, "Batch");
                            CustomArguments_First = CustomArguments;
                            break;
                    }

                    break;

                case false:
                    bool Save = false;

                    if (Settings.Batch.Default.SelectedType != SelectedType) {
                        Settings.Batch.Default.SelectedType = SelectedType;
                        Save = true;
                    }
                    if (Settings.Batch.Default.SelectedVideoQuality != SelectedVideoQuality) {
                        Settings.Batch.Default.SelectedVideoQuality = SelectedVideoQuality;
                        Save = true;
                    }
                    if (Settings.Batch.Default.SelectedVideoFormat != SelectedVideoFormat) {
                        Settings.Batch.Default.SelectedVideoFormat = SelectedVideoFormat;
                        Save = true;
                    }
                    if (Settings.Batch.Default.SelectedAudioQuality != SelectedAudioQuality) {
                        Settings.Batch.Default.SelectedAudioQuality = SelectedAudioQuality;
                        Save = true;
                    }
                    if (Settings.Batch.Default.SelectedAudioFormat != SelectedAudioFormat) {
                        Settings.Batch.Default.SelectedAudioFormat = SelectedAudioFormat;
                        Save = true;
                    }
                    if (Settings.Batch.Default.DownloadVideoSound != DownloadVideoSound) {
                        Settings.Batch.Default.DownloadVideoSound = DownloadVideoSound;
                        Save = true;
                    }
                    if (Settings.Batch.Default.DownloadAudioVBR != DownloadAudioVBR) {
                        Settings.Batch.Default.DownloadAudioVBR = DownloadAudioVBR;
                        Save = true;
                    }
                    if (Settings.Batch.Default.SelectedAudioQualityVBR != SelectedAudioQualityVBR) {
                        Settings.Batch.Default.SelectedAudioQualityVBR = SelectedAudioQualityVBR;
                        Save = true;
                    }
                    if (Settings.Batch.Default.CustomArguments != CustomArguments) {
                        Settings.Batch.Default.CustomArguments = CustomArguments;
                        Save = true;
                    }

                    switch (Save) {
                        case true:
                            Settings.Batch.Default.Save();
                            break;
                    }
                    break;
            }
        }
        public void Load() {
            switch (Program.UseIni) {
                case true:
                    if (Ini.KeyExists("SelectedType", "Batch")) {
                        SelectedType = Ini.ReadInt("SelectedType", "Batch");
                        SelectedType_First = SelectedType;
                    }
                    if (Ini.KeyExists("SelectedVideoQuality", "Batch")) {
                        SelectedVideoQuality = Ini.ReadInt("SelectedVideoQuality", "Batch");
                        SelectedVideoQuality_First = SelectedVideoQuality;
                    }
                    if (Ini.KeyExists("SelectedVideoFormat", "Batch")) {
                        SelectedVideoFormat = Ini.ReadInt("SelectedVideoFormat", "Batch");
                        SelectedVideoFormat_First = SelectedVideoFormat;
                    }
                    if (Ini.KeyExists("SelectedAudioQuality", "Batch")) {
                        SelectedAudioQuality = Ini.ReadInt("SelectedAudioQuality", "Batch");
                        SelectedAudioQuality_First = SelectedAudioQuality;
                    }
                    if (Ini.KeyExists("SelectedAudioFormat", "Batch")) {
                        SelectedAudioFormat = Ini.ReadInt("SelectedAudioFormat", "Batch");
                        SelectedAudioFormat_First = SelectedAudioFormat;
                    }
                    if (Ini.KeyExists("DownloadVideoSound", "Batch")) {
                        DownloadVideoSound = Ini.ReadBool("DownloadVideoSound", "Batch");
                        DownloadVideoSound_First = DownloadVideoSound;
                    }
                    if (Ini.KeyExists("DownloadAudioVBR", "Batch")) {
                        DownloadAudioVBR = Ini.ReadBool("DownloadAudioVBR", "Batch");
                        DownloadAudioVBR_First = DownloadAudioVBR;
                    }
                    if (Ini.KeyExists("SelectedAudioQualityVBR", "Batch")) {
                        SelectedAudioQualityVBR = Ini.ReadInt("SelectedAudioQualityVBR", "Batch");
                        SelectedAudioQualityVBR_First = SelectedAudioQualityVBR;
                    }
                    if (Ini.KeyExists("CustomArguments", "Batch")) {
                        CustomArguments = Ini.ReadString("CustomArguments", "Batch");
                        CustomArguments_First = CustomArguments;
                    }
                    break;

                case false:
                    SelectedType = Settings.Batch.Default.SelectedType;
                    SelectedVideoQuality = Settings.Batch.Default.SelectedVideoQuality;
                    SelectedVideoFormat = Settings.Batch.Default.SelectedVideoFormat;
                    SelectedAudioQuality = Settings.Batch.Default.SelectedAudioQuality;
                    SelectedAudioFormat = Settings.Batch.Default.SelectedAudioFormat;
                    DownloadVideoSound = Settings.Batch.Default.DownloadVideoSound;
                    DownloadAudioVBR = Settings.Batch.Default.DownloadAudioVBR;
                    SelectedAudioQualityVBR = Settings.Batch.Default.SelectedAudioQualityVBR;
                    CustomArguments = Settings.Batch.Default.CustomArguments;
                    break;
            }
        }

        public void ForceSave() {
            switch (Program.UseIni) {
                case true:

                    Ini.Write("SelectedType", SelectedType, "Batch");
                    SelectedType_First = SelectedType;

                    Ini.Write("SelectedVideoQuality", SelectedVideoQuality, "Batch");
                    SelectedVideoQuality_First = SelectedVideoQuality;

                    Ini.Write("SelectedVideoFormat", SelectedVideoFormat, "Batch");
                    SelectedVideoFormat_First = SelectedVideoFormat;

                    Ini.Write("SelectedAudioQuality", SelectedAudioQuality, "Batch");
                    SelectedAudioQuality_First = SelectedAudioQuality;

                    Ini.Write("SelectedAudioFormat", SelectedAudioFormat, "Batch");
                    SelectedAudioFormat_First = SelectedAudioFormat;

                    Ini.Write("DownloadVideoSound", DownloadVideoSound, "Batch");
                    DownloadVideoSound_First = DownloadVideoSound;

                    Ini.Write("DownloadAudioVBR", DownloadAudioVBR, "Batch");
                    DownloadAudioVBR_First = DownloadAudioVBR;

                    Ini.Write("SelectedAudioQualityVBR", SelectedAudioQualityVBR, "Batch");
                    SelectedAudioQualityVBR_First = SelectedAudioQualityVBR;

                    Ini.Write("CustomArguments", CustomArguments, "Batch");
                    CustomArguments_First = CustomArguments;

                    break;

                case false:
                    Settings.Batch.Default.SelectedType = SelectedType;
                    Settings.Batch.Default.SelectedVideoQuality = SelectedVideoQuality;
                    Settings.Batch.Default.SelectedVideoFormat = SelectedVideoFormat;
                    Settings.Batch.Default.SelectedAudioQuality = SelectedAudioQuality;
                    Settings.Batch.Default.SelectedAudioFormat = SelectedAudioFormat;
                    Settings.Batch.Default.DownloadVideoSound = DownloadVideoSound;
                    Settings.Batch.Default.DownloadAudioVBR = DownloadAudioVBR;
                    Settings.Batch.Default.SelectedAudioQualityVBR = SelectedAudioQualityVBR;
                    Settings.Batch.Default.CustomArguments = CustomArguments;
                    Settings.Batch.Default.Save();
                    break;
            }
        }
    }

    class Config_Converts {
        public Config_Converts() { }

        public bool detectFiletype = true;
        public bool clearOutput = false;
        public bool clearInput = false;
        public int videoBitrate = 7500;
        public int videoPreset = 5;
        public int videoProfile = 1;
        public int videoCRF = 8;
        public bool videoFastStart = false;
        public bool hideFFmpegCompile = false;
        public int audioBitrate = 256;
        public bool videoUseBitrate = false;
        public bool videoUsePreset = false;
        public bool videoUseProfile = false;
        public bool videoUseCRF = true;
        public bool audioUseBitrate = true;

        private bool detectFiletype_First = true;
        private bool clearOutput_First = false;
        private bool clearInput_First = false;
        private int videoBitrate_First = 7500;
        private int videoPreset_First = 5;
        private int videoProfile_First = 1;
        private int videoCRF_First = 8;
        private bool videoFastStart_First = false;
        private bool hideFFmpegCompile_First = false;
        private int audioBitrate_First = 256;
        private bool videoUseBitrate_First = false;
        private bool videoUsePreset_First = false;
        private bool videoUseProfile_First = false;
        private bool videoUseCRF_First = true;
        private bool audioUseBitrate_First = true;

        public void Save() {
            switch (Program.UseIni) {
                case true:
                    switch (detectFiletype != detectFiletype_First) {
                        case true:
                            Ini.Write("detectFiletype", detectFiletype, "Converts");
                            detectFiletype_First = detectFiletype;
                            break;
                    }
                    switch (clearOutput != clearOutput_First) {
                        case true:
                            Ini.Write("clearOutput", clearOutput, "Converts");
                            clearOutput_First = clearOutput;
                            break;
                    }
                    switch (clearInput != clearInput_First) {
                        case true:
                            Ini.Write("clearInput", clearInput, "Converts");
                            clearInput_First = clearInput;
                            break;
                    }
                    switch (videoBitrate != videoBitrate_First) {
                        case true:
                            Ini.Write("videoBitrate", videoBitrate, "Converts");
                            videoBitrate_First = videoBitrate;
                            break;
                    }
                    switch (videoPreset != videoPreset_First) {
                        case true:
                            Ini.Write("videoPreset", videoPreset, "Converts");
                            videoPreset_First = videoPreset;
                            break;
                    }
                    switch (videoProfile != videoProfile_First) {
                        case true:
                            Ini.Write("videoProfile", videoProfile, "Converts");
                            videoProfile_First = videoProfile;
                            break;
                    }
                    switch (videoCRF != videoCRF_First) {
                        case true:
                            Ini.Write("videoCRF", videoCRF, "Converts");
                            videoCRF_First = videoCRF;
                            break;
                    }
                    switch (videoFastStart != videoFastStart_First) {
                        case true:
                            Ini.Write("videoFastStart", videoFastStart, "Converts");
                            videoFastStart_First = videoFastStart;
                            break;
                    }
                    switch (hideFFmpegCompile != hideFFmpegCompile_First) {
                        case true:
                            Ini.Write("hideFFmpegCompile", hideFFmpegCompile, "Converts");
                            hideFFmpegCompile_First = hideFFmpegCompile;
                            break;
                    }
                    switch (audioBitrate != audioBitrate_First) {
                        case true:
                            Ini.Write("audioBitrate", audioBitrate, "Converts");
                            audioBitrate_First = audioBitrate;
                            break;
                    }
                    switch (videoUseBitrate != videoUseBitrate_First) {
                        case true:
                            Ini.Write("videoUseBitrate", videoUseBitrate, "Converts");
                            videoUseBitrate_First = videoUseBitrate;
                            break;
                    }
                    switch (videoUsePreset != videoUsePreset_First) {
                        case true:
                            Ini.Write("videoUsePreset", videoUsePreset, "Converts");
                            videoUsePreset_First = videoUsePreset;
                            break;
                    }
                    switch (videoUseProfile != videoUseProfile_First) {
                        case true:
                            Ini.Write("videoUseProfile", videoUseProfile, "Converts");
                            videoUseProfile_First = videoUseProfile;
                            break;
                    }
                    switch (videoUseCRF != videoUseCRF_First) {
                        case true:
                            Ini.Write("videoUseCRF", videoUseCRF, "Converts");
                            videoUseCRF_First = videoUseCRF;
                            break;
                    }
                    switch (audioUseBitrate != audioUseBitrate_First) {
                        case true:
                            Ini.Write("audioUseBitrate", audioUseBitrate, "Converts");
                            audioUseBitrate_First = audioUseBitrate;
                            break;
                    }

                    break;

                case false:
                    bool Save = false;

                    if (Settings.Converts.Default.detectFiletype != detectFiletype) {
                        Settings.Converts.Default.detectFiletype = detectFiletype;
                        Save = true;
                    }
                    if (Settings.Converts.Default.clearOutput != clearOutput) {
                        Settings.Converts.Default.clearOutput = clearOutput;
                        Save = true;
                    }
                    if (Settings.Converts.Default.clearInput != clearInput) {
                        Settings.Converts.Default.clearInput = clearInput;
                        Save = true;
                    }
                    if (Settings.Converts.Default.videoBitrate != videoBitrate) {
                        Settings.Converts.Default.videoBitrate = videoBitrate;
                        Save = true;
                    }
                    if (Settings.Converts.Default.videoPreset != videoPreset) {
                        Settings.Converts.Default.videoPreset = videoPreset;
                        Save = true;
                    }
                    if (Settings.Converts.Default.videoProfile != videoProfile) {
                        Settings.Converts.Default.videoProfile = videoProfile;
                        Save = true;
                    }
                    if (Settings.Converts.Default.videoCRF != videoCRF) {
                        Settings.Converts.Default.videoCRF = videoCRF;
                        Save = true;
                    }
                    if (Settings.Converts.Default.videoFastStart != videoFastStart) {
                        Settings.Converts.Default.videoFastStart = videoFastStart;
                        Save = true;
                    }
                    if (Settings.Converts.Default.hideFFmpegCompile != hideFFmpegCompile) {
                        Settings.Converts.Default.hideFFmpegCompile = hideFFmpegCompile;
                        Save = true;
                    }
                    if (Settings.Converts.Default.audioBitrate != audioBitrate) {
                        Settings.Converts.Default.audioBitrate = audioBitrate;
                        Save = true;
                    }
                    if (Settings.Converts.Default.videoUseBitrate != videoUseBitrate) {
                        Settings.Converts.Default.videoUseBitrate = videoUseBitrate;
                        Save = true;
                    }
                    if (Settings.Converts.Default.videoUsePreset != videoUsePreset) {
                        Settings.Converts.Default.videoUsePreset = videoUsePreset;
                        Save = true;
                    }
                    if (Settings.Converts.Default.videoUseProfile != videoUseProfile) {
                        Settings.Converts.Default.videoUseProfile = videoUseProfile;
                        Save = true;
                    }
                    if (Settings.Converts.Default.videoUseCRF != videoUseCRF) {
                        Settings.Converts.Default.videoUseCRF = videoUseCRF;
                        Save = true;
                    }
                    if (Settings.Converts.Default.audioUseBitrate != audioUseBitrate) {
                        Settings.Converts.Default.audioUseBitrate = audioUseBitrate;
                        Save = true;
                    }

                    switch (Save) {
                        case true:
                            Settings.Converts.Default.Save();
                            break;
                    }
                    break;
            }
        }
        public void Load() {
            switch (Program.UseIni) {
                #region Portable Ini
                case true:
                    if (Ini.KeyExists("detectFiletype", "Converts")) {
                        detectFiletype = Ini.ReadBool("detectFiletype", "Converts");
                        detectFiletype_First = detectFiletype;
                    }
                    if (Ini.KeyExists("clearOutput", "Converts")) {
                        clearOutput = Ini.ReadBool("clearOutput", "Converts");
                        clearOutput_First = clearOutput;
                    }
                    if (Ini.KeyExists("clearInput", "Converts")) {
                        clearInput = Ini.ReadBool("clearInput", "Converts");
                        clearInput_First = clearInput;
                    }
                    if (Ini.KeyExists("videoBitrate", "Converts")) {
                        videoBitrate = Ini.ReadInt("videoBitrate", "Converts");
                        videoBitrate_First = videoBitrate;
                    }
                    if (Ini.KeyExists("videoPreset", "Converts")) {
                        videoPreset = Ini.ReadInt("videoPreset", "Converts");
                        videoPreset_First = videoPreset;
                    }
                    if (Ini.KeyExists("videoProfile", "Converts")) {
                        videoProfile = Ini.ReadInt("videoProfile", "Converts");
                        videoProfile_First = videoProfile;
                    }
                    if (Ini.KeyExists("videoCRF", "Converts")) {
                        videoCRF = Ini.ReadInt("videoCRF", "Converts");
                        videoCRF_First = videoCRF;
                    }
                    if (Ini.KeyExists("videoFastStart", "Converts")) {
                        videoFastStart = Ini.ReadBool("videoFastStart", "Converts");
                        videoFastStart_First = videoFastStart;
                    }
                    if (Ini.KeyExists("hideFFmpegCompile", "Converts")) {
                        hideFFmpegCompile = Ini.ReadBool("hideFFmpegCompile", "Converts");
                        hideFFmpegCompile_First = hideFFmpegCompile;
                    }
                    if (Ini.KeyExists("audioBitrate", "Converts")) {
                        audioBitrate = Ini.ReadInt("audioBitrate", "Converts");
                        audioBitrate_First = audioBitrate;
                    }
                    if (Ini.KeyExists("videoUseBitrate", "Converts")) {
                        videoUseBitrate = Ini.ReadBool("videoUseBitrate", "Converts");
                        videoUseBitrate_First = videoUseBitrate;
                    }
                    if (Ini.KeyExists("videoUsePreset", "Converts")) {
                        videoUsePreset = Ini.ReadBool("videoUsePreset", "Converts");
                        videoUsePreset_First = videoUsePreset;
                    }
                    if (Ini.KeyExists("videoUseProfile", "Converts")) {
                        videoUseProfile = Ini.ReadBool("videoUseProfile", "Converts");
                        videoUseProfile_First = videoUseProfile;
                    }
                    if (Ini.KeyExists("videoUseCRF", "Converts")) {
                        videoUseCRF = Ini.ReadBool("videoUseCRF", "Converts");
                        videoUseCRF_First = videoUseCRF;
                    }
                    if (Ini.KeyExists("audioUseBitrate", "Converts")) {
                        audioUseBitrate = Ini.ReadBool("audioUseBitrate", "Converts");
                        audioUseBitrate_First = audioUseBitrate;
                    }
                    break;
                #endregion

                #region Internal
                case false:
                    detectFiletype = Settings.Converts.Default.detectFiletype;
                    clearOutput = Settings.Converts.Default.clearOutput;
                    clearInput = Settings.Converts.Default.clearInput;
                    videoBitrate = Settings.Converts.Default.videoBitrate;
                    videoPreset = Settings.Converts.Default.videoPreset;
                    videoProfile = Settings.Converts.Default.videoProfile;
                    videoCRF = Settings.Converts.Default.videoCRF;
                    videoFastStart = Settings.Converts.Default.videoFastStart;
                    hideFFmpegCompile = Settings.Converts.Default.hideFFmpegCompile;
                    audioBitrate = Settings.Converts.Default.audioBitrate;
                    videoUseBitrate = Settings.Converts.Default.videoUseBitrate;
                    videoUsePreset = Settings.Converts.Default.videoUsePreset;
                    videoUseProfile = Settings.Converts.Default.videoUseProfile;
                    videoUseCRF = Settings.Converts.Default.videoUseCRF;
                    audioUseBitrate = Settings.Converts.Default.audioUseBitrate;
                    break;
                #endregion
            }
        }

        public void ForceSave() {
            switch (Program.UseIni) {
                case true:
                    Ini.Write("detectFiletype", detectFiletype, "Converts");
                    detectFiletype_First = detectFiletype;

                    Ini.Write("clearOutput", clearOutput, "Converts");
                    clearOutput_First = clearOutput;

                    Ini.Write("clearInput", clearInput, "Converts");
                    clearInput_First = clearInput;

                    Ini.Write("videoBitrate", videoBitrate, "Converts");
                    videoBitrate_First = videoBitrate;

                    Ini.Write("videoPreset", videoPreset, "Converts");
                    videoPreset_First = videoPreset;

                    Ini.Write("videoProfile", videoProfile, "Converts");
                    videoProfile_First = videoProfile;

                    Ini.Write("videoCRF", videoCRF, "Converts");
                    videoCRF_First = videoCRF;

                    Ini.Write("videoFastStart", videoFastStart, "Converts");
                    videoFastStart_First = videoFastStart;

                    Ini.Write("hideFFmpegCompile", hideFFmpegCompile, "Converts");
                    hideFFmpegCompile_First = hideFFmpegCompile;

                    Ini.Write("audioBitrate", audioBitrate, "Converts");
                    audioBitrate_First = audioBitrate;

                    Ini.Write("videoUseBitrate", videoUseBitrate, "Converts");
                    videoUseBitrate_First = videoUseBitrate;

                    Ini.Write("videoUsePreset", videoUsePreset, "Converts");
                    videoUsePreset_First = videoUsePreset;

                    Ini.Write("videoUseProfile", videoUseProfile, "Converts");
                    videoUseProfile_First = videoUseProfile;

                    Ini.Write("videoUseCRF", videoUseCRF, "Converts");
                    videoUseCRF_First = videoUseCRF;

                    Ini.Write("audioUseBitrate", audioUseBitrate, "Converts");
                    audioUseBitrate_First = audioUseBitrate;

                    break;

                case false:
                    Settings.Converts.Default.detectFiletype = detectFiletype;
                    Settings.Converts.Default.clearOutput = clearOutput;
                    Settings.Converts.Default.clearInput = clearInput;
                    Settings.Converts.Default.videoBitrate = videoBitrate;
                    Settings.Converts.Default.videoPreset = videoPreset;
                    Settings.Converts.Default.videoProfile = videoProfile;
                    Settings.Converts.Default.videoCRF = videoCRF;
                    Settings.Converts.Default.videoFastStart = videoFastStart;
                    Settings.Converts.Default.hideFFmpegCompile = hideFFmpegCompile;
                    Settings.Converts.Default.audioBitrate = audioBitrate;
                    Settings.Converts.Default.videoUseBitrate = videoUseBitrate;
                    Settings.Converts.Default.videoUsePreset = videoUsePreset;
                    Settings.Converts.Default.videoUseProfile = videoUseProfile;
                    Settings.Converts.Default.videoUseCRF = videoUseCRF;
                    Settings.Converts.Default.audioUseBitrate = audioUseBitrate;
                    Settings.Converts.Default.Save();
                    break;
            }
        }
    }

    class Config_Downloads {

        public Config_Downloads() {
            Load();
        }

        #region variables
        public string downloadPath = string.Empty;
        public bool separateDownloads = true;
        public bool SaveFormatQuality = true;
        public bool deleteYtdlOnClose = false;
        public bool useYtdlUpdater = true;
        public string fileNameSchema = "%(title)s-%(id)s.%(ext)s";
        public bool fixReddit = true;
        public bool separateIntoWebsiteURL = true;
        public bool SaveSubtitles = false;
        public string subtitlesLanguages = "en";
        public bool CloseDownloaderAfterFinish = true;
        public bool UseProxy = false;
        public int ProxyType = -1;
        public string ProxyIP = string.Empty;
        public string ProxyPort = string.Empty;
        public bool SaveThumbnail = false;
        public bool SaveDescription = false;
        public bool SaveVideoInfo = false;
        public bool SaveAnnotations = false;
        public string SubtitleFormat = string.Empty;
        public int DownloadLimit = 0;
        public int RetryAttempts = 10;
        public int DownloadLimitType = 1;
        public bool ForceIPv4 = false;
        public bool ForceIPv6 = false;
        public bool LimitDownloads = false;
        public bool EmbedSubtitles = false;
        public bool EmbedThumbnails = false;
        public bool VideoDownloadSound = true;
        public bool AudioDownloadAsVBR = false;
        public bool KeepOriginalFiles = false;
        public bool WriteMetadata = false;
        public bool SkipBatchTip = false;
        public bool AutomaticallyDownloadFromProtocol = true;
        public bool PreferFFmpeg = true;
        public bool SeparateBatchDownloads = true;
        public bool AddDateToBatchDownloadFolders = true;

        private string downloadPath_First = string.Empty;
        private bool separateDownloads_First = true;
        private bool SaveFormatQuality_First = true;
        private bool deleteYtdlOnClose_First = false;
        private bool useYtdlUpdater_First = true;
        private string fileNameSchema_First = "%(title)s-%(id)s.%(ext)s";
        private bool fixReddit_First = true;
        private bool separateIntoWebsiteURL_First = true;
        private bool SaveSubtitles_First = false;
        private string subtitlesLanguages_First = "en";
        private bool CloseDownloaderAfterFinish_First = true;
        private bool UseProxy_First = false;
        private int ProxyType_First = -1;
        private string ProxyIP_First = string.Empty;
        private string ProxyPort_First = string.Empty;
        private bool SaveThumbnail_First = false;
        private bool SaveDescription_First = false;
        private bool SaveVideoInfo_First = false;
        private bool SaveAnnotations_First = false;
        private string SubtitleFormat_First = string.Empty;
        private int DownloadLimit_First = 0;
        private int RetryAttempts_First = 10;
        private int DownloadLimitType_First = 1;
        private bool ForceIPv4_First = false;
        private bool ForceIPv6_First = false;
        private bool LimitDownloads_First = false;
        private bool EmbedSubtitles_First = false;
        private bool EmbedThumbnails_First = false;
        private bool VideoDownloadSound_First = true;
        private bool AudioDownloadAsVBR_First = false;
        private bool KeepOriginalFiles_First = false;
        private bool WriteMetadata_First = false;
        private bool SkipBatchTip_First = false;
        private bool AutomaticallyDownloadFromProtocol_First = true;
        private bool PreferFFmpeg_First = true;
        private bool SeparateBatchDownloads_First = true;
        private bool AddDateToBatchDownloadFolders_First = true;
        #endregion

        public void Load() {
            switch (Program.UseIni) {
                case true:
                    switch (Ini.KeyExists("downloadPath", "Downloads")) {
                        case true:
                            downloadPath = Ini.ReadString("downloadPath", "Downloads");
                            downloadPath_First = downloadPath;
                            break;
                    }
                    switch (Ini.KeyExists("separateDownloads", "Downloads")) {
                        case true:
                            separateDownloads = Ini.ReadBool("separateDownloads", "Downloads");
                            separateDownloads_First = separateDownloads;
                            break;
                    }
                    switch (Ini.KeyExists("SaveFormatQuality", "Downloads")) {
                        case true:
                            SaveFormatQuality = Ini.ReadBool("SaveFormatQuality", "Downloads");
                            SaveFormatQuality_First = SaveFormatQuality;
                            break;
                    }
                    switch (Ini.KeyExists("deleteYtdlOnClose", "Downloads")) {
                        case true:
                            deleteYtdlOnClose = Ini.ReadBool("deleteYtdlOnClose", "Downloads");
                            deleteYtdlOnClose_First = deleteYtdlOnClose;
                            break;
                    }
                    switch (Ini.KeyExists("useYtdlUpdater", "Downloads")) {
                        case true:
                            useYtdlUpdater = Ini.ReadBool("useYtdlUpdater", "Downloads");
                            useYtdlUpdater_First = useYtdlUpdater;
                            break;
                    }
                    switch (Ini.KeyExists("fileNameSchema", "Downloads")) {
                        case true:
                            fileNameSchema = Ini.ReadString("fileNameSchema", "Downloads");
                            fileNameSchema_First = fileNameSchema;
                            break;
                    }
                    switch (Ini.KeyExists("fixReddit", "Downloads")) {
                        case true:
                            fixReddit = Ini.ReadBool("fixReddit", "Downloads");
                            fixReddit_First = fixReddit;
                            break;
                    }
                    switch (Ini.KeyExists("separateIntoWebsiteURL", "Downloads")) {
                        case true:
                            separateIntoWebsiteURL = Ini.ReadBool("separateIntoWebsiteURL", "Downloads");
                            separateIntoWebsiteURL_First = separateIntoWebsiteURL;
                            break;
                    }
                    switch (Ini.KeyExists("SaveSubtitles", "Downloads")) {
                        case true:
                            SaveSubtitles = Ini.ReadBool("SaveSubtitles", "Downloads");
                            SaveSubtitles_First = SaveSubtitles;
                            break;
                    }
                    switch (Ini.KeyExists("subtitlesLanguages", "Downloads")) {
                        case true:
                            subtitlesLanguages = Ini.ReadString("subtitlesLanguages", "Downloads");
                            subtitlesLanguages_First = subtitlesLanguages;
                            break;
                    }
                    switch (Ini.KeyExists("CloseDownloaderAfterFinish", "Downloads")) {
                        case true:
                            CloseDownloaderAfterFinish = Ini.ReadBool("CloseDownloaderAfterFinish", "Downloads");
                            CloseDownloaderAfterFinish_First = CloseDownloaderAfterFinish;
                            break;
                    }
                    switch (Ini.KeyExists("UseProxy", "Downloads")) {
                        case true:
                            UseProxy = Ini.ReadBool("UseProxy", "Downloads");
                            UseProxy_First = UseProxy;
                            break;
                    }
                    switch (Ini.KeyExists("ProxyType", "Downloads")) {
                        case true:
                            ProxyType = Ini.ReadInt("ProxyType", "Downloads");
                            ProxyType_First = ProxyType;
                            break;
                    }
                    switch (Ini.KeyExists("ProxyIP", "Downloads")) {
                        case true:
                            ProxyIP = Ini.ReadString("ProxyIP", "Downloads");
                            ProxyIP_First = ProxyIP;
                            break;
                    }
                    switch (Ini.KeyExists("ProxyPort", "Downloads")) {
                        case true:
                            ProxyPort = Ini.ReadString("ProxyPort", "Downloads");
                            ProxyPort_First = ProxyPort;
                            break;
                    }
                    switch (Ini.KeyExists("SaveThumbnail", "Downloads")) {
                        case true:
                            SaveThumbnail = Ini.ReadBool("SaveThumbnail", "Downloads");
                            SaveThumbnail_First = SaveThumbnail;
                            break;
                    }
                    switch (Ini.KeyExists("SaveDescription", "Downloads")) {
                        case true:
                            SaveDescription = Ini.ReadBool("SaveDescription", "Downloads");
                            SaveDescription_First = SaveDescription;
                            break;
                    }
                    switch (Ini.KeyExists("SaveVideoInfo", "Downloads")) {
                        case true:
                            SaveVideoInfo = Ini.ReadBool("SaveVideoInfo", "Downloads");
                            SaveVideoInfo_First = SaveVideoInfo;
                            break;
                    }
                    switch (Ini.KeyExists("SaveAnnotations", "Downloads")) {
                        case true:
                            SaveAnnotations = Ini.ReadBool("SaveAnnotations", "Downloads");
                            SaveAnnotations_First = SaveAnnotations;
                            break;
                    }
                    switch (Ini.KeyExists("SubtitleFormat", "Downloads")) {
                        case true:
                            SubtitleFormat = Ini.ReadString("SubtitleFormat", "Downloads");
                            SubtitleFormat_First = SubtitleFormat;
                            break;
                    }
                    switch (Ini.KeyExists("DownloadLimit", "Downloads")) {
                        case true:
                            DownloadLimit = Ini.ReadInt("DownloadLimit", "Downloads");
                            DownloadLimit_First = DownloadLimit;
                            break;
                    }
                    switch (Ini.KeyExists("RetryAttempts", "Downloads")) {
                        case true:
                            RetryAttempts = Ini.ReadInt("RetryAttempts", "Downloads");
                            RetryAttempts_First = RetryAttempts;
                            break;
                    }
                    switch (Ini.KeyExists("DownloadLimitType", "Downloads")) {
                        case true:
                            DownloadLimitType = Ini.ReadInt("DownloadLimitType", "Downloads");
                            DownloadLimitType_First = DownloadLimitType;
                            break;
                    }
                    switch (Ini.KeyExists("ForceIPv4", "Downloads")) {
                        case true:
                            ForceIPv4 = Ini.ReadBool("ForceIPv4", "Downloads");
                            ForceIPv4_First = ForceIPv4;
                            break;
                    }
                    switch (Ini.KeyExists("ForceIPv6", "Downloads")) {
                        case true:
                            ForceIPv6 = Ini.ReadBool("ForceIPv6", "Downloads");
                            ForceIPv6_First = ForceIPv6;
                            break;
                    }
                    switch (Ini.KeyExists("LimitDownloads", "Downloads")) {
                        case true:
                            LimitDownloads = Ini.ReadBool("LimitDownloads", "Downloads");
                            LimitDownloads_First = LimitDownloads;
                            break;
                    }
                    switch (Ini.KeyExists("EmbedSubtitles", "Downloads")) {
                        case true:
                            EmbedSubtitles = Ini.ReadBool("EmbedSubtitles", "Downloads");
                            EmbedSubtitles_First = EmbedSubtitles;
                            break;
                    }
                    switch (Ini.KeyExists("EmbedThumbnails", "Downloads")) {
                        case true:
                            EmbedThumbnails = Ini.ReadBool("EmbedThumbnails", "Downloads");
                            EmbedThumbnails_First = EmbedThumbnails;
                            break;
                    }
                    switch (Ini.KeyExists("VideoDownloadSound", "Downloads")) {
                        case true:
                            VideoDownloadSound = Ini.ReadBool("VideoDownloadSound", "Downloads");
                            VideoDownloadSound_First = VideoDownloadSound;
                            break;
                    }
                    switch (Ini.KeyExists("AudioDownloadAsVBR", "Downloads")) {
                        case true:
                            AudioDownloadAsVBR = Ini.ReadBool("AudioDownloadAsVBR", "Downloads");
                            AudioDownloadAsVBR_First = AudioDownloadAsVBR;
                            break;
                    }
                    switch (Ini.KeyExists("KeepOriginalFiles", "Downloads")) {
                        case true:
                            KeepOriginalFiles = Ini.ReadBool("KeepOriginalFiles", "Downloads");
                            KeepOriginalFiles_First = KeepOriginalFiles;
                            break;
                    }
                    switch (Ini.KeyExists("WriteMetadata", "Downloads")) {
                        case true:
                            WriteMetadata = Ini.ReadBool("WriteMetadata", "Downloads");
                            WriteMetadata_First = WriteMetadata;
                            break;
                    }
                    switch (Ini.KeyExists("SkipBatchTip", "Downloads")) {
                        case true:
                            SkipBatchTip = Ini.ReadBool("SkipBatchTip", "Downloads");
                            SkipBatchTip_First = SkipBatchTip;
                            break;
                    }
                    switch (Ini.KeyExists("AutomaticallyDownloadFromProtocol", "Downloads")) {
                        case true:
                            AutomaticallyDownloadFromProtocol = Ini.ReadBool("AutomaticallyDownloadFromProtocol", "Downloads");
                            AutomaticallyDownloadFromProtocol_First = AutomaticallyDownloadFromProtocol;
                            break;
                    }
                    switch (Ini.KeyExists("PreferFFmpeg", "Downloads")) {
                        case true:
                            PreferFFmpeg = Ini.ReadBool("PreferFFmpeg", "Downloads");
                            PreferFFmpeg_First = PreferFFmpeg;
                            break;
                    }
                    switch (Ini.KeyExists("SeparateBatchDownloads", "Downloads")) {
                        case true:
                            SeparateBatchDownloads = Ini.ReadBool("SeparateBatchDownloads", "Downloads");
                            SeparateBatchDownloads_First = SeparateBatchDownloads;
                            break;
                    }
                    switch (Ini.KeyExists("AddDateToBatchDownloadFolders", "Downloads")) {
                        case true:
                            AddDateToBatchDownloadFolders = Ini.ReadBool("AddDateToBatchDownloadFolders", "Downloads");
                            AddDateToBatchDownloadFolders_First = AddDateToBatchDownloadFolders;
                            break;
                    }

                    break;

                case false:
                    downloadPath = Settings.Downloads.Default.downloadPath;
                    separateDownloads = Settings.Downloads.Default.separateDownloads;
                    SaveFormatQuality = Settings.Downloads.Default.SaveFormatQuality;
                    deleteYtdlOnClose = Settings.Downloads.Default.deleteYtdlOnClose;
                    useYtdlUpdater = Settings.Downloads.Default.useYtdlUpdater;
                    fileNameSchema = Settings.Downloads.Default.fileNameSchema;
                    fixReddit = Settings.Downloads.Default.fixReddit;
                    separateIntoWebsiteURL = Settings.Downloads.Default.separateIntoWebsiteURL;
                    SaveSubtitles = Settings.Downloads.Default.SaveSubtitles;
                    subtitlesLanguages = Settings.Downloads.Default.subtitlesLanguages;
                    CloseDownloaderAfterFinish = Settings.Downloads.Default.CloseDownloaderAfterFinish;
                    UseProxy = Settings.Downloads.Default.UseProxy;
                    ProxyType = Settings.Downloads.Default.ProxyType;
                    ProxyIP = Settings.Downloads.Default.ProxyIP;
                    ProxyPort = Settings.Downloads.Default.ProxyPort;
                    SaveThumbnail = Settings.Downloads.Default.SaveThumbnail;
                    SaveDescription = Settings.Downloads.Default.SaveDescription;
                    SaveVideoInfo = Settings.Downloads.Default.SaveVideoInfo;
                    SaveAnnotations = Settings.Downloads.Default.SaveAnnotations;
                    SubtitleFormat = Settings.Downloads.Default.SubtitleFormat;
                    DownloadLimit = Settings.Downloads.Default.DownloadLimit;
                    RetryAttempts = Settings.Downloads.Default.RetryAttempts;
                    DownloadLimitType = Settings.Downloads.Default.DownloadLimitType;
                    ForceIPv4 = Settings.Downloads.Default.ForceIPv4;
                    ForceIPv6 = Settings.Downloads.Default.ForceIPv6;
                    LimitDownloads = Settings.Downloads.Default.LimitDownloads;
                    EmbedSubtitles = Settings.Downloads.Default.EmbedSubtitles;
                    EmbedThumbnails = Settings.Downloads.Default.EmbedThumbnails;
                    VideoDownloadSound = Settings.Downloads.Default.VideoDownloadSound;
                    AudioDownloadAsVBR = Settings.Downloads.Default.AudioDownloadAsVBR;
                    KeepOriginalFiles = Settings.Downloads.Default.KeepOriginalFiles;
                    WriteMetadata = Settings.Downloads.Default.WriteMetadata;
                    SkipBatchTip = Settings.Downloads.Default.SkipBatchTip;
                    AutomaticallyDownloadFromProtocol = Settings.Downloads.Default.AutomaticallyDownloadFromProtocol;
                    PreferFFmpeg = Settings.Downloads.Default.PreferFFmpeg;
                    SeparateBatchDownloads = Settings.Downloads.Default.SeparateBatchDownloads;
                    AddDateToBatchDownloadFolders = Settings.Downloads.Default.AddDateToBatchDownloadFolders;

                    break;
            }
        }
        public void Save() {
            switch (Program.UseIni) {
                case true:
                    switch (downloadPath != downloadPath_First) {
                        case true:
                            Ini.Write("downloadPath", downloadPath, "Downloads");
                            downloadPath_First = downloadPath;
                            break;
                    }
                    switch (separateDownloads != separateDownloads_First) {
                        case true:
                            Ini.Write("separateDownloads", separateDownloads, "Downloads");
                            separateDownloads_First = separateDownloads;
                            break;
                    }
                    switch (SaveFormatQuality != SaveFormatQuality_First) {
                        case true:
                            Ini.Write("SaveFormatQuality", SaveFormatQuality, "Downloads");
                            SaveFormatQuality_First = SaveFormatQuality;
                            break;
                    }
                    switch (deleteYtdlOnClose != deleteYtdlOnClose_First) {
                        case true:
                            Ini.Write("deleteYtdlOnClose", deleteYtdlOnClose, "Downloads");
                            deleteYtdlOnClose_First = deleteYtdlOnClose;
                            break;
                    }
                    switch (useYtdlUpdater != useYtdlUpdater_First) {
                        case true:
                            Ini.Write("useYtdlUpdater", useYtdlUpdater, "Downloads");
                            useYtdlUpdater_First = useYtdlUpdater;
                            break;
                    }
                    switch (fileNameSchema != fileNameSchema_First) {
                        case true:
                            Ini.Write("fileNameSchema", fileNameSchema, "Downloads");
                            fileNameSchema_First = fileNameSchema;
                            break;
                    }
                    switch (fixReddit != fixReddit_First) {
                        case true:
                            Ini.Write("fixReddit", fixReddit, "Downloads");
                            fixReddit_First = fixReddit;
                            break;
                    }
                    switch (separateIntoWebsiteURL != separateIntoWebsiteURL_First) {
                        case true:
                            Ini.Write("separateIntoWebsiteURL", separateIntoWebsiteURL, "Downloads");
                            separateIntoWebsiteURL_First = separateIntoWebsiteURL;
                            break;
                    }
                    switch (SaveSubtitles != SaveSubtitles_First) {
                        case true:
                            Ini.Write("SaveSubtitles", SaveSubtitles, "Downloads");
                            SaveSubtitles_First = SaveSubtitles;
                            break;
                    }
                    switch (subtitlesLanguages != subtitlesLanguages_First) {
                        case true:
                            Ini.Write("subtitlesLanguages", subtitlesLanguages, "Downloads");
                            subtitlesLanguages_First = subtitlesLanguages;
                            break;
                    }
                    switch (CloseDownloaderAfterFinish != CloseDownloaderAfterFinish_First) {
                        case true:
                            Ini.Write("CloseDownloaderAfterFinish", CloseDownloaderAfterFinish, "Downloads");
                            CloseDownloaderAfterFinish_First = CloseDownloaderAfterFinish;
                            break;
                    }
                    switch (UseProxy != UseProxy_First) {
                        case true:
                            Ini.Write("UseProxy", UseProxy, "Downloads");
                            UseProxy_First = UseProxy;
                            break;
                    }
                    switch (ProxyType != ProxyType_First) {
                        case true:
                            Ini.Write("ProxyType", ProxyType, "Downloads");
                            ProxyType_First = ProxyType;
                            break;
                    }
                    switch (ProxyIP != ProxyIP_First) {
                        case true:
                            Ini.Write("ProxyIP", ProxyIP, "Downloads");
                            ProxyIP_First = ProxyIP;
                            break;
                    }
                    switch (ProxyPort != ProxyPort_First) {
                        case true:
                            Ini.Write("ProxyPort", ProxyPort, "Downloads");
                            ProxyPort_First = ProxyPort;
                            break;
                    }
                    switch (SaveThumbnail != SaveThumbnail_First) {
                        case true:
                            Ini.Write("SaveThumbnail", SaveThumbnail, "Downloads");
                            SaveThumbnail_First = SaveThumbnail;
                            break;
                    }
                    switch (SaveDescription != SaveDescription_First) {
                        case true:
                            Ini.Write("SaveDescription", SaveDescription, "Downloads");
                            SaveDescription_First = SaveDescription;
                            break;
                    }
                    switch (SaveVideoInfo != SaveVideoInfo_First) {
                        case true:
                            Ini.Write("SaveVideoInfo", SaveVideoInfo, "Downloads");
                            SaveVideoInfo_First = SaveVideoInfo;
                            break;
                    }
                    switch (SaveAnnotations != SaveAnnotations_First) {
                        case true:
                            Ini.Write("SaveAnnotations", SaveAnnotations, "Downloads");
                            SaveAnnotations_First = SaveAnnotations;
                            break;
                    }
                    switch (SubtitleFormat != SubtitleFormat_First) {
                        case true:
                            Ini.Write("SubtitleFormat", SubtitleFormat, "Downloads");
                            SubtitleFormat_First = SubtitleFormat;
                            break;
                    }
                    switch (DownloadLimit != DownloadLimit_First) {
                        case true:
                            Ini.Write("DownloadLimit", DownloadLimit, "Downloads");
                            DownloadLimit_First = DownloadLimit;
                            break;
                    }
                    switch (RetryAttempts != RetryAttempts_First) {
                        case true:
                            Ini.Write("RetryAttempts", RetryAttempts, "Downloads");
                            RetryAttempts_First = RetryAttempts;
                            break;
                    }
                    switch (DownloadLimitType != DownloadLimitType_First) {
                        case true:
                            Ini.Write("DownloadLimitType", DownloadLimitType, "Downloads");
                            DownloadLimitType_First = DownloadLimitType;
                            break;
                    }
                    switch (ForceIPv4 != ForceIPv4_First) {
                        case true:
                            Ini.Write("ForceIPv4", ForceIPv4, "Downloads");
                            ForceIPv4_First = ForceIPv4;
                            break;
                    }
                    switch (ForceIPv6 != ForceIPv6_First) {
                        case true:
                            Ini.Write("ForceIPv6", ForceIPv6, "Downloads");
                            ForceIPv6_First = ForceIPv6;
                            break;
                    }
                    switch (LimitDownloads != LimitDownloads_First) {
                        case true:
                            Ini.Write("LimitDownloads", LimitDownloads, "Downloads");
                            LimitDownloads_First = LimitDownloads;
                            break;
                    }
                    switch (EmbedSubtitles != EmbedSubtitles_First) {
                        case true:
                            Ini.Write("EmbedSubtitles", EmbedSubtitles, "Downloads");
                            EmbedSubtitles_First = EmbedSubtitles;
                            break;
                    }
                    switch (EmbedThumbnails != EmbedThumbnails_First) {
                        case true:
                            Ini.Write("EmbedThumbnails", EmbedThumbnails, "Downloads");
                            EmbedThumbnails_First = EmbedThumbnails;
                            break;
                    }
                    switch (VideoDownloadSound != VideoDownloadSound_First) {
                        case true:
                            Ini.Write("VideoDownloadSound", VideoDownloadSound, "Downloads");
                            VideoDownloadSound_First = VideoDownloadSound;
                            break;
                    }
                    switch (AudioDownloadAsVBR != AudioDownloadAsVBR_First) {
                        case true:
                            Ini.Write("AudioDownloadAsVBR", AudioDownloadAsVBR, "Downloads");
                            AudioDownloadAsVBR_First = AudioDownloadAsVBR;
                            break;
                    }
                    switch (KeepOriginalFiles != KeepOriginalFiles_First) {
                        case true:
                            Ini.Write("KeepOriginalFiles", KeepOriginalFiles, "Downloads");
                            KeepOriginalFiles_First = KeepOriginalFiles;
                            break;
                    }
                    switch (WriteMetadata != WriteMetadata_First) {
                        case true:
                            Ini.Write("WriteMetadata", WriteMetadata, "Downloads");
                            WriteMetadata_First = WriteMetadata;
                            break;
                    }
                    switch (SkipBatchTip != SkipBatchTip_First) {
                        case true:
                            Ini.Write("SkipBatchTip", SkipBatchTip, "Downloads");
                            SkipBatchTip_First = SkipBatchTip;
                            break;
                    }
                    switch (AutomaticallyDownloadFromProtocol != AutomaticallyDownloadFromProtocol_First) {
                        case true:
                            Ini.Write("AutomaticallyDownloadFromProtocol", AutomaticallyDownloadFromProtocol, "Downloads");
                            AutomaticallyDownloadFromProtocol_First = AutomaticallyDownloadFromProtocol;
                            break;
                    }
                    switch (PreferFFmpeg != PreferFFmpeg_First) {
                        case true:
                            Ini.Write("PreferFFmpeg", PreferFFmpeg, "Downloads");
                            PreferFFmpeg_First = PreferFFmpeg;
                            break;
                    }
                    switch (SeparateBatchDownloads != SeparateBatchDownloads_First) {
                        case true:
                            Ini.Write("SeparateBatchDownloads", SeparateBatchDownloads, "Downloads");
                            SeparateBatchDownloads_First = SeparateBatchDownloads;
                            break;
                    }
                    switch (AddDateToBatchDownloadFolders != AddDateToBatchDownloadFolders_First) {
                        case true:
                            Ini.Write("AddDateToBatchDownloadFolders", AddDateToBatchDownloadFolders, "Downloads");
                            AddDateToBatchDownloadFolders_First = AddDateToBatchDownloadFolders;
                            break;
                    }

                    break;

                case false:
                    bool Save = false;

                    if (Settings.Downloads.Default.downloadPath != downloadPath) {
                        Settings.Downloads.Default.downloadPath = downloadPath;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.separateDownloads != separateDownloads) {
                        Settings.Downloads.Default.separateDownloads = separateDownloads;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.SaveFormatQuality != SaveFormatQuality) {
                        Settings.Downloads.Default.SaveFormatQuality = SaveFormatQuality;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.deleteYtdlOnClose != deleteYtdlOnClose) {
                        Settings.Downloads.Default.deleteYtdlOnClose = deleteYtdlOnClose;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.useYtdlUpdater != useYtdlUpdater) {
                        Settings.Downloads.Default.useYtdlUpdater = useYtdlUpdater;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.fileNameSchema != fileNameSchema) {
                        Settings.Downloads.Default.fileNameSchema = fileNameSchema;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.fixReddit != fixReddit) {
                        Settings.Downloads.Default.fixReddit = fixReddit;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.separateIntoWebsiteURL != separateIntoWebsiteURL) {
                        Settings.Downloads.Default.separateIntoWebsiteURL = separateIntoWebsiteURL;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.SaveSubtitles != SaveSubtitles) {
                        Settings.Downloads.Default.SaveSubtitles = SaveSubtitles;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.subtitlesLanguages != subtitlesLanguages) {
                        Settings.Downloads.Default.subtitlesLanguages = subtitlesLanguages;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.CloseDownloaderAfterFinish != CloseDownloaderAfterFinish) {
                        Settings.Downloads.Default.CloseDownloaderAfterFinish = CloseDownloaderAfterFinish;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.UseProxy != UseProxy) {
                        Settings.Downloads.Default.UseProxy = UseProxy;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.ProxyType != ProxyType) {
                        Settings.Downloads.Default.ProxyType = ProxyType;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.ProxyIP != ProxyIP) {
                        Settings.Downloads.Default.ProxyIP = ProxyIP;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.ProxyPort != ProxyPort) {
                        Settings.Downloads.Default.ProxyPort = ProxyPort;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.SaveThumbnail != SaveThumbnail) {
                        Settings.Downloads.Default.SaveThumbnail = SaveThumbnail;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.SaveDescription != SaveDescription) {
                        Settings.Downloads.Default.SaveDescription = SaveDescription;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.SaveVideoInfo != SaveVideoInfo) {
                        Settings.Downloads.Default.SaveVideoInfo = SaveVideoInfo;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.SaveAnnotations != SaveAnnotations) {
                        Settings.Downloads.Default.SaveAnnotations = SaveAnnotations;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.SubtitleFormat != SubtitleFormat) {
                        Settings.Downloads.Default.SubtitleFormat = SubtitleFormat;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.DownloadLimit != DownloadLimit) {
                        Settings.Downloads.Default.DownloadLimit = DownloadLimit;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.RetryAttempts != RetryAttempts) {
                        Settings.Downloads.Default.RetryAttempts = RetryAttempts;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.DownloadLimitType != DownloadLimitType) {
                        Settings.Downloads.Default.DownloadLimitType = DownloadLimitType;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.ForceIPv4 != ForceIPv4) {
                        Settings.Downloads.Default.ForceIPv4 = ForceIPv4;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.ForceIPv6 != ForceIPv6) {
                        Settings.Downloads.Default.ForceIPv6 = ForceIPv6;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.LimitDownloads != LimitDownloads) {
                        Settings.Downloads.Default.LimitDownloads = LimitDownloads;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.EmbedSubtitles != EmbedSubtitles) {
                        Settings.Downloads.Default.EmbedSubtitles = EmbedSubtitles;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.EmbedThumbnails != EmbedThumbnails) {
                        Settings.Downloads.Default.EmbedThumbnails = EmbedThumbnails;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.VideoDownloadSound != VideoDownloadSound) {
                        Settings.Downloads.Default.VideoDownloadSound = VideoDownloadSound;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.AudioDownloadAsVBR != AudioDownloadAsVBR) {
                        Settings.Downloads.Default.AudioDownloadAsVBR = AudioDownloadAsVBR;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.KeepOriginalFiles != KeepOriginalFiles) {
                        Settings.Downloads.Default.KeepOriginalFiles = KeepOriginalFiles;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.WriteMetadata != WriteMetadata) {
                        Settings.Downloads.Default.WriteMetadata = WriteMetadata;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.SkipBatchTip != SkipBatchTip) {
                        Settings.Downloads.Default.SkipBatchTip = SkipBatchTip;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.AutomaticallyDownloadFromProtocol != AutomaticallyDownloadFromProtocol) {
                        Settings.Downloads.Default.AutomaticallyDownloadFromProtocol = AutomaticallyDownloadFromProtocol;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.PreferFFmpeg != PreferFFmpeg) {
                        Settings.Downloads.Default.PreferFFmpeg = PreferFFmpeg;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.SeparateBatchDownloads != SeparateBatchDownloads) {
                        Settings.Downloads.Default.SeparateBatchDownloads = SeparateBatchDownloads;
                        Save = true;
                    }
                    if (Settings.Downloads.Default.AddDateToBatchDownloadFolders != AddDateToBatchDownloadFolders) {
                        Settings.Downloads.Default.AddDateToBatchDownloadFolders = AddDateToBatchDownloadFolders;
                        Save = true;
                    }

                    switch (Save) {
                        case true:
                            Settings.Downloads.Default.Save();
                            break;
                    }
                    break;
            }
        }

        public void ForceSave() {
            switch (Program.UseIni) {
                case true:
                    Ini.Write("downloadPath", downloadPath, "Downloads");
                    downloadPath_First = downloadPath;

                    Ini.Write("separateDownloads", separateDownloads, "Downloads");
                    separateDownloads_First = separateDownloads;

                    Ini.Write("SaveFormatQuality", SaveFormatQuality, "Downloads");
                    SaveFormatQuality_First = SaveFormatQuality;

                    Ini.Write("deleteYtdlOnClose", deleteYtdlOnClose, "Downloads");
                    deleteYtdlOnClose_First = deleteYtdlOnClose;

                    Ini.Write("useYtdlUpdater", useYtdlUpdater, "Downloads");
                    useYtdlUpdater_First = useYtdlUpdater;

                    Ini.Write("fileNameSchema", fileNameSchema, "Downloads");
                    fileNameSchema_First = fileNameSchema;

                    Ini.Write("fixReddit", fixReddit, "Downloads");
                    fixReddit_First = fixReddit;

                    Ini.Write("separateIntoWebsiteURL", separateIntoWebsiteURL, "Downloads");
                    separateIntoWebsiteURL_First = separateIntoWebsiteURL;

                    Ini.Write("SaveSubtitles", SaveSubtitles, "Downloads");
                    SaveSubtitles_First = SaveSubtitles;

                    Ini.Write("subtitlesLanguages", subtitlesLanguages, "Downloads");
                    subtitlesLanguages_First = subtitlesLanguages;

                    Ini.Write("CloseDownloaderAfterFinish", CloseDownloaderAfterFinish, "Downloads");
                    CloseDownloaderAfterFinish_First = CloseDownloaderAfterFinish;

                    Ini.Write("UseProxy", UseProxy, "Downloads");
                    UseProxy_First = UseProxy;

                    Ini.Write("ProxyType", ProxyType, "Downloads");
                    ProxyType_First = ProxyType;

                    Ini.Write("ProxyIP", ProxyIP, "Downloads");
                    ProxyIP_First = ProxyIP;

                    Ini.Write("ProxyPort", ProxyPort, "Downloads");
                    ProxyPort_First = ProxyPort;

                    Ini.Write("SaveThumbnail", SaveThumbnail, "Downloads");
                    SaveThumbnail_First = SaveThumbnail;

                    Ini.Write("SaveDescription", SaveDescription, "Downloads");
                    SaveDescription_First = SaveDescription;

                    Ini.Write("SaveVideoInfo", SaveVideoInfo, "Downloads");
                    SaveVideoInfo_First = SaveVideoInfo;

                    Ini.Write("SaveAnnotations", SaveAnnotations, "Downloads");
                    SaveAnnotations_First = SaveAnnotations;

                    Ini.Write("SubtitleFormat", SubtitleFormat, "Downloads");
                    SubtitleFormat_First = SubtitleFormat;

                    Ini.Write("DownloadLimit", DownloadLimit, "Downloads");
                    DownloadLimit_First = DownloadLimit;

                    Ini.Write("RetryAttempts", RetryAttempts, "Downloads");
                    RetryAttempts_First = RetryAttempts;

                    Ini.Write("DownloadLimitType", DownloadLimitType, "Downloads");
                    DownloadLimitType_First = DownloadLimitType;

                    Ini.Write("ForceIPv4", ForceIPv4, "Downloads");
                    ForceIPv4_First = ForceIPv4;

                    Ini.Write("ForceIPv6", ForceIPv6, "Downloads");
                    ForceIPv6_First = ForceIPv6;

                    Ini.Write("LimitDownloads", LimitDownloads, "Downloads");
                    LimitDownloads_First = LimitDownloads;

                    Ini.Write("EmbedSubtitles", EmbedSubtitles, "Downloads");
                    EmbedSubtitles_First = EmbedSubtitles;

                    Ini.Write("EmbedThumbnails", EmbedThumbnails, "Downloads");
                    EmbedThumbnails_First = EmbedThumbnails;

                    Ini.Write("VideoDownloadSound", VideoDownloadSound, "Downloads");
                    VideoDownloadSound_First = VideoDownloadSound;

                    Ini.Write("AudioDownloadAsVBR", AudioDownloadAsVBR, "Downloads");
                    AudioDownloadAsVBR_First = AudioDownloadAsVBR;

                    Ini.Write("KeepOriginalFiles", KeepOriginalFiles, "Downloads");
                    KeepOriginalFiles_First = KeepOriginalFiles;

                    Ini.Write("WriteMetadata", WriteMetadata, "Downloads");
                    WriteMetadata_First = WriteMetadata;

                    Ini.Write("SkipBatchTip", SkipBatchTip, "Downloads");
                    SkipBatchTip_First = SkipBatchTip;

                    Ini.Write("AutomaticallyDownloadFromProtocol", AutomaticallyDownloadFromProtocol, "Downloads");
                    AutomaticallyDownloadFromProtocol_First = AutomaticallyDownloadFromProtocol;

                    Ini.Write("PreferFFmpeg", PreferFFmpeg, "Downloads");
                    PreferFFmpeg_First = PreferFFmpeg;

                    Ini.Write("SeparateBatchDownloads", SeparateBatchDownloads, "Downloads");
                    SeparateBatchDownloads_First = SeparateBatchDownloads;

                    Ini.Write("AddDateToBatchDownloadFolders", AddDateToBatchDownloadFolders, "Downloads");
                    AddDateToBatchDownloadFolders_First = AddDateToBatchDownloadFolders;
                    break;

                case false:
                    Settings.Downloads.Default.downloadPath = downloadPath;
                    Settings.Downloads.Default.separateDownloads = separateDownloads;
                    Settings.Downloads.Default.SaveFormatQuality = SaveFormatQuality;
                    Settings.Downloads.Default.deleteYtdlOnClose = deleteYtdlOnClose;
                    Settings.Downloads.Default.useYtdlUpdater = useYtdlUpdater;
                    Settings.Downloads.Default.fileNameSchema = fileNameSchema;
                    Settings.Downloads.Default.fixReddit = fixReddit;
                    Settings.Downloads.Default.separateIntoWebsiteURL = separateIntoWebsiteURL;
                    Settings.Downloads.Default.SaveSubtitles = SaveSubtitles;
                    Settings.Downloads.Default.subtitlesLanguages = subtitlesLanguages;
                    Settings.Downloads.Default.CloseDownloaderAfterFinish = CloseDownloaderAfterFinish;
                    Settings.Downloads.Default.UseProxy = UseProxy;
                    Settings.Downloads.Default.ProxyType = ProxyType;
                    Settings.Downloads.Default.ProxyIP = ProxyIP;
                    Settings.Downloads.Default.ProxyPort = ProxyPort;
                    Settings.Downloads.Default.SaveThumbnail = SaveThumbnail;
                    Settings.Downloads.Default.SaveDescription = SaveDescription;
                    Settings.Downloads.Default.SaveVideoInfo = SaveVideoInfo;
                    Settings.Downloads.Default.SaveAnnotations = SaveAnnotations;
                    Settings.Downloads.Default.SubtitleFormat = SubtitleFormat;
                    Settings.Downloads.Default.DownloadLimit = DownloadLimit;
                    Settings.Downloads.Default.RetryAttempts = RetryAttempts;
                    Settings.Downloads.Default.DownloadLimitType = DownloadLimitType;
                    Settings.Downloads.Default.ForceIPv4 = ForceIPv4;
                    Settings.Downloads.Default.ForceIPv6 = ForceIPv6;
                    Settings.Downloads.Default.LimitDownloads = LimitDownloads;
                    Settings.Downloads.Default.EmbedSubtitles = EmbedSubtitles;
                    Settings.Downloads.Default.EmbedThumbnails = EmbedThumbnails;
                    Settings.Downloads.Default.VideoDownloadSound = VideoDownloadSound;
                    Settings.Downloads.Default.AudioDownloadAsVBR = AudioDownloadAsVBR;
                    Settings.Downloads.Default.KeepOriginalFiles = KeepOriginalFiles;
                    Settings.Downloads.Default.WriteMetadata = WriteMetadata;
                    Settings.Downloads.Default.SkipBatchTip = SkipBatchTip;
                    Settings.Downloads.Default.AutomaticallyDownloadFromProtocol = AutomaticallyDownloadFromProtocol;
                    Settings.Downloads.Default.PreferFFmpeg = PreferFFmpeg;
                    Settings.Downloads.Default.SeparateBatchDownloads = SeparateBatchDownloads;
                    Settings.Downloads.Default.AddDateToBatchDownloadFolders = AddDateToBatchDownloadFolders;

                    Settings.Downloads.Default.Save();
                    break;
            }
        }
    }

    class Config_Errors {

        public Config_Errors() {
            Load();
        }

        public bool detailedErrors = false;
        public bool logErrors = false;
        public bool suppressErrors = false;

        private bool detailedErrors_First = false;
        private bool logErrors_First = false;
        private bool suppressErrors_First = false;

        public void Load() {
            switch (Program.UseIni) {
                case true:
                    switch (Ini.KeyExists("detailedErrors", "Errors")) {
                        case true:
                            detailedErrors = Ini.ReadBool("detailedErrors", "Errors");
                            detailedErrors_First = detailedErrors;
                            break;
                    }
                    switch (Ini.KeyExists("logErrors", "Errors")) {
                        case true:
                            logErrors = Ini.ReadBool("logErrors", "Errors");
                            logErrors_First = logErrors;
                            break;
                    }
                    switch (Ini.KeyExists("suppressErrors", "Errors")) {
                        case true:
                            suppressErrors = Ini.ReadBool("suppressErrors", "Errors");
                            suppressErrors_First = suppressErrors;
                            break;
                    }

                    break;

                case false:
                    detailedErrors = Settings.Errors.Default.detailedErrors;
                    logErrors = Settings.Errors.Default.logErrors;
                    suppressErrors = Settings.Errors.Default.suppressErrors;
                    break;
            }
        }
        public void Save() {
            switch (Program.UseIni) {
                case true:
                    switch (detailedErrors != detailedErrors_First) {
                        case true:
                            Ini.Write("detailedErrors", detailedErrors, "Errors");
                            detailedErrors_First = detailedErrors;
                            break;
                    }

                    switch (logErrors != logErrors_First) {
                        case true:
                            Ini.Write("logErrors", logErrors, "Errors");
                            logErrors_First = logErrors;
                            break;
                    }

                    switch (suppressErrors != suppressErrors_First) {
                        case true:
                            Ini.Write("suppressErrors", suppressErrors, "Errors");
                            suppressErrors_First = suppressErrors;
                            break;
                    }

                    break;

                case false:
                    bool Save = false;

                    if (Settings.Errors.Default.suppressErrors != suppressErrors) {
                        Settings.Errors.Default.suppressErrors = suppressErrors;
                        Save = true;
                    }

                    if (Settings.Errors.Default.logErrors != logErrors) {
                        Settings.Errors.Default.logErrors = logErrors;
                        Save = true;
                    }

                    if (Settings.Errors.Default.suppressErrors != suppressErrors) {
                        Settings.Errors.Default.suppressErrors = suppressErrors;
                        Save = true;
                    }

                    switch (Save) {
                        case true:
                            Settings.Errors.Default.Save();
                            break;
                    }
                    break;
            }
        }

        public void ForceSave() {
            switch (Program.UseIni) {
                case true:
                    Ini.Write("suppressErrors", suppressErrors, "Errors");
                    suppressErrors_First = suppressErrors;

                    Ini.Write("logErrors", logErrors, "Errors");
                    logErrors_First = logErrors;

                    Ini.Write("suppressErrors", suppressErrors, "Errors");
                    suppressErrors_First = suppressErrors;
                    break;

                case false:
                    Settings.Errors.Default.suppressErrors = suppressErrors;
                    Settings.Errors.Default.logErrors = logErrors;
                    Settings.Errors.Default.suppressErrors = suppressErrors;

                    Settings.Errors.Default.Save();
                    break;
            }
        }
    }

    class Config_General {

        public Config_General() {
            Load();
        }

        public bool UseStaticYtdl = false;
        public string ytdlPath = string.Empty;
        public bool UseStaticFFmpeg = false;
        public string ffmpegPath = string.Empty;
        public bool CheckForUpdatesOnLaunch = false;
        public bool HoverOverURLTextBoxToPaste = true;
        public bool ClearURLOnDownload = false;
        public int SaveCustomArgs = 2;
        public bool ClearClipboardOnDownload = false;

        private bool UseStaticYtdl_First = false;
        private string ytdlPath_First = string.Empty;
        private bool UseStaticFFmpeg_First = false;
        private string ffmpegPath_First = string.Empty;
        private bool CheckForUpdatesOnLaunch_First = false;
        private bool HoverOverURLTextBoxToPaste_First = true;
        private bool ClearURLOnDownload_First = false;
        private int SaveCustomArgs_First = 2;
        private bool ClearClipboardOnDownload_First = false;

        public void Load() {
            switch (Program.UseIni) {
                case true:
                    switch (Ini.KeyExists("UseStaticYtdl", "General")) {
                        case true:
                            UseStaticYtdl = Ini.ReadBool("UseStaticYtdl", "General");
                            UseStaticYtdl_First = UseStaticYtdl;
                            break;
                    }
                    switch (Ini.KeyExists("ytdlPath", "General")) {
                        case true:
                            ytdlPath = Ini.ReadString("ytdlPath", "General");
                            ytdlPath_First = ytdlPath;
                            break;
                    }
                    switch (Ini.KeyExists("UseStaticFFmpeg", "General")) {
                        case true:
                            UseStaticFFmpeg = Ini.ReadBool("UseStaticFFmpeg", "General");
                            UseStaticFFmpeg_First = UseStaticFFmpeg;
                            break;
                    }
                    switch (Ini.KeyExists("ffmpegPath", "General")) {
                        case true:
                            ffmpegPath = Ini.ReadString("ffmpegPath", "General");
                            ffmpegPath_First = ffmpegPath;
                            break;
                    }
                    switch (Ini.KeyExists("CheckForUpdatesOnLaunch", "General")) {
                        case true:
                            CheckForUpdatesOnLaunch = Ini.ReadBool("CheckForUpdatesOnLaunch", "General");
                            CheckForUpdatesOnLaunch_First = CheckForUpdatesOnLaunch;
                            break;
                    }
                    switch (Ini.KeyExists("HoverOverURLTextBoxToPaste", "General")) {
                        case true:
                            HoverOverURLTextBoxToPaste = Ini.ReadBool("HoverOverURLTextBoxToPaste", "General");
                            HoverOverURLTextBoxToPaste_First = HoverOverURLTextBoxToPaste;
                            break;
                    }
                    switch (Ini.KeyExists("ClearURLOnDownload", "General")) {
                        case true:
                            ClearURLOnDownload = Ini.ReadBool("ClearURLOnDownload", "General");
                            ClearURLOnDownload_First = ClearURLOnDownload;
                            break;
                    }
                    switch (Ini.KeyExists("SaveCustomArgs", "General")) {
                        case true:
                            SaveCustomArgs = Ini.ReadInt("SaveCustomArgs", "General");
                            SaveCustomArgs_First = SaveCustomArgs;
                            break;
                    }
                    switch (Ini.KeyExists("ClearClipboardOnDownload", "General")) {
                        case true:
                            ClearClipboardOnDownload = Ini.ReadBool("ClearClipboardOnDownload", "General");
                            ClearClipboardOnDownload_First = ClearClipboardOnDownload;
                            break;
                    }
                    break;

                case false:
                    UseStaticYtdl = Settings.General.Default.UseStaticYtdl;
                    ytdlPath = Settings.General.Default.ytdlPath;
                    UseStaticFFmpeg = Settings.General.Default.UseStaticFFmpeg;
                    ffmpegPath = Settings.General.Default.ffmpegPath;
                    CheckForUpdatesOnLaunch = Settings.General.Default.CheckForUpdatesOnLaunch;
                    HoverOverURLTextBoxToPaste = Settings.General.Default.HoverOverURLTextBoxToPaste;
                    ClearURLOnDownload = Settings.General.Default.ClearURLOnDownload;
                    SaveCustomArgs = Settings.General.Default.SaveCustomArgs;
                    ClearClipboardOnDownload = Settings.General.Default.ClearClipboardOnDownload;
                    break;
            }
        }
        public void Save() {
            switch (Program.UseIni) {
                case true:
                    switch (UseStaticYtdl != UseStaticYtdl_First) {
                        case true:
                            Ini.Write("UseStaticYtdl", UseStaticYtdl, "General");
                            UseStaticYtdl_First = UseStaticYtdl;
                            break;
                    }
                    switch (ytdlPath != ytdlPath_First) {
                        case true:
                            Ini.Write("ytdlPath", ytdlPath, "General");
                            ytdlPath_First = ytdlPath;
                            break;
                    }
                    switch (UseStaticFFmpeg != UseStaticFFmpeg_First) {
                        case true:
                            Ini.Write("UseStaticFFmpeg", UseStaticFFmpeg, "General");
                            UseStaticFFmpeg_First = UseStaticFFmpeg;
                            break;
                    }
                    switch (ffmpegPath != ffmpegPath_First) {
                        case true:
                            Ini.Write("ffmpegPath", ffmpegPath, "General");
                            ffmpegPath_First = ffmpegPath;
                            break;
                    }
                    switch (CheckForUpdatesOnLaunch != CheckForUpdatesOnLaunch_First) {
                        case true:
                            Ini.Write("CheckForUpdatesOnLaunch", CheckForUpdatesOnLaunch, "General");
                            CheckForUpdatesOnLaunch_First = CheckForUpdatesOnLaunch;
                            break;
                    }
                    switch (HoverOverURLTextBoxToPaste != HoverOverURLTextBoxToPaste_First) {
                        case true:
                            Ini.Write("HoverOverURLTextBoxToPaste", HoverOverURLTextBoxToPaste, "General");
                            HoverOverURLTextBoxToPaste_First = HoverOverURLTextBoxToPaste;
                            break;
                    }
                    switch (ClearURLOnDownload != ClearURLOnDownload_First) {
                        case true:
                            Ini.Write("ClearURLOnDownload", ClearURLOnDownload, "General");
                            ClearURLOnDownload_First = ClearURLOnDownload;
                            break;
                    }
                    switch (SaveCustomArgs != SaveCustomArgs_First) {
                        case true:
                            Ini.Write("SaveCustomArgs", SaveCustomArgs, "General");
                            SaveCustomArgs_First = SaveCustomArgs;
                            break;
                    }
                    switch (ClearClipboardOnDownload != ClearClipboardOnDownload_First) {
                        case true:
                            Ini.Write("ClearClipboardOnDownload", ClearClipboardOnDownload, "General");
                            ClearClipboardOnDownload_First = ClearClipboardOnDownload;
                            break;
                    }

                    break;

                case false:
                    bool Save = false;

                    if (Settings.General.Default.UseStaticYtdl != UseStaticYtdl) {
                        Settings.General.Default.UseStaticYtdl = UseStaticYtdl;
                        Save = true;
                    }

                    if (Settings.General.Default.ytdlPath != ytdlPath) {
                        Settings.General.Default.ytdlPath = ytdlPath;
                        Save = true;
                    }

                    if (Settings.General.Default.UseStaticFFmpeg != UseStaticFFmpeg) {
                        Settings.General.Default.UseStaticFFmpeg = UseStaticFFmpeg;
                        Save = true;
                    }

                    if (Settings.General.Default.ffmpegPath != ffmpegPath) {
                        Settings.General.Default.ffmpegPath = ffmpegPath;
                        Save = true;
                    }

                    if (Settings.General.Default.CheckForUpdatesOnLaunch != CheckForUpdatesOnLaunch) {
                        Settings.General.Default.CheckForUpdatesOnLaunch = CheckForUpdatesOnLaunch;
                        Save = true;
                    }

                    if (Settings.General.Default.HoverOverURLTextBoxToPaste != HoverOverURLTextBoxToPaste) {
                        Settings.General.Default.HoverOverURLTextBoxToPaste = HoverOverURLTextBoxToPaste;
                        Save = true;
                    }

                    if (Settings.General.Default.ClearURLOnDownload != ClearURLOnDownload) {
                        Settings.General.Default.ClearURLOnDownload = ClearURLOnDownload;
                        Save = true;
                    }

                    if (Settings.General.Default.SaveCustomArgs != SaveCustomArgs) {
                        Settings.General.Default.SaveCustomArgs = SaveCustomArgs;
                        Save = true;
                    }

                    if (Settings.General.Default.ClearClipboardOnDownload != ClearClipboardOnDownload) {
                        Settings.General.Default.ClearClipboardOnDownload = ClearClipboardOnDownload;
                        Save = true;
                    }
                    switch (Save) {
                        case true:
                            Settings.General.Default.Save();
                            break;
                    }
                    break;
            }
        }

        public void ForceSave() {
            switch (Program.UseIni) {
                case true:
                    Ini.Write("UseStaticYtdl", UseStaticYtdl, "General");
                    UseStaticYtdl_First = UseStaticYtdl;

                    Ini.Write("ytdlPath", ytdlPath, "General");
                    ytdlPath_First = ytdlPath;

                    Ini.Write("UseStaticFFmpeg", UseStaticFFmpeg, "General");
                    UseStaticFFmpeg_First = UseStaticFFmpeg;

                    Ini.Write("ffmpegPath", ffmpegPath, "General");
                    ffmpegPath_First = ffmpegPath;

                    Ini.Write("CheckForUpdatesOnLaunch", CheckForUpdatesOnLaunch, "General");
                    CheckForUpdatesOnLaunch_First = CheckForUpdatesOnLaunch;

                    Ini.Write("HoverOverURLTextBoxToPaste", HoverOverURLTextBoxToPaste, "General");
                    HoverOverURLTextBoxToPaste_First = HoverOverURLTextBoxToPaste;

                    Ini.Write("ClearURLOnDownload", ClearURLOnDownload, "General");
                    ClearURLOnDownload_First = ClearURLOnDownload;

                    Ini.Write("SaveCustomArgs", SaveCustomArgs, "General");
                    SaveCustomArgs_First = SaveCustomArgs;

                    Ini.Write("ClearClipboardOnDownload", ClearClipboardOnDownload, "General");
                    ClearClipboardOnDownload_First = ClearClipboardOnDownload;
                    break;

                case false:
                    Settings.General.Default.UseStaticYtdl = UseStaticYtdl;
                    Settings.General.Default.ytdlPath = ytdlPath;
                    Settings.General.Default.UseStaticFFmpeg = UseStaticFFmpeg;
                    Settings.General.Default.ffmpegPath = ffmpegPath;
                    Settings.General.Default.CheckForUpdatesOnLaunch = CheckForUpdatesOnLaunch;
                    Settings.General.Default.HoverOverURLTextBoxToPaste = HoverOverURLTextBoxToPaste;
                    Settings.General.Default.ClearURLOnDownload = ClearURLOnDownload;
                    Settings.General.Default.SaveCustomArgs = SaveCustomArgs;
                    Settings.General.Default.ClearClipboardOnDownload = ClearClipboardOnDownload;

                    Settings.General.Default.Save();
                    break;
            }
        }
    }

    class Config_Saved {

        public Config_Saved() {
            Load();
        }

        #region variables
        public int downloadType = 0;
        public int UseStaticYtdl = 0;
        public int convertSaveAudioIndex = 0;
        public int convertType = 0;
        public string convertCustom = string.Empty;
        public int videoQuality = 0;
        public int audioQuality = 0;
        public int VideoFormat = 0;
        public int AudioFormat = 0;
        public int AudioVBRQuality = 0;
        public int BatchFormX = -32000;
        public int BatchFormY = -32000;
        public Size MainFormSize = new Size(0, 0);
        public Size SettingsFormSize = new Size(0, 0);
        public string FileNameSchemaHistory = "%(title)s-%(id)s.%(ext)s|%(uploader)s\\(%(playlist_index)s) %(title)s-%(id)s.%(ext)s";
        public string DownloadCustomArguments = string.Empty;
        public int CustomArgumentsIndex = -1;
        public Point MainFormLocation = new Point(-32000, -32000);

        private int downloadType_First = 0;
        private int UseStaticYtdl_First = 0;
        private int convertSaveAudioIndex_First = 0;
        private int convertType_First = 0;
        private string convertCustom_First = string.Empty;
        private int videoQuality_First = 0;
        private int audioQuality_First = 0;
        private int VideoFormat_First = 0;
        private int AudioFormat_First = 0;
        private int AudioVBRQuality_First = 0;
        private int BatchFormX_First = -32000;
        private int BatchFormY_First = -32000;
        private Size MainFormSize_First = new Size(0, 0);
        private Size SettingsFormSize_First = new Size(0, 0);
        private string FileNameSchemaHistory_First = "%(title)s-%(id)s.%(ext)s|%(uploader)s\\(%(playlist_index)s) %(title)s-%(id)s.%(ext)s";
        private string DownloadCustomArguments_First = string.Empty;
        private int CustomArgumentsIndex_First = -1;
        private Point MainFormLocation_First = new Point(-32000, -32000);
        #endregion

        //_First private

        public void Load() {
            switch (Program.UseIni) {
                case true:
                    switch (Ini.KeyExists("downloadType", "Saved")) {
                        case true:
                            downloadType = Ini.ReadInt("downloadType", "Saved");
                            downloadType_First = downloadType;
                            break;
                    }
                    switch (Ini.KeyExists("UseStaticYtdl", "Saved")) {
                        case true:
                            UseStaticYtdl = Ini.ReadInt("UseStaticYtdl", "Saved");
                            UseStaticYtdl_First = UseStaticYtdl;
                            break;
                    }
                    switch (Ini.KeyExists("convertSaveAudioIndex", "Saved")) {
                        case true:
                            convertSaveAudioIndex = Ini.ReadInt("convertSaveAudioIndex", "Saved");
                            convertSaveAudioIndex_First = convertSaveAudioIndex;
                            break;
                    }
                    switch (Ini.KeyExists("convertType", "Saved")) {
                        case true:
                            convertType = Ini.ReadInt("convertType", "Saved");
                            convertType_First = convertType;
                            break;
                    }
                    switch (Ini.KeyExists("convertCustom", "Saved")) {
                        case true:
                            convertCustom = Ini.ReadString("convertCustom", "Saved");
                            convertCustom_First = convertCustom;
                            break;
                    }
                    switch (Ini.KeyExists("videoQuality", "Saved")) {
                        case true:
                            videoQuality = Ini.ReadInt("videoQuality", "Saved");
                            videoQuality_First = videoQuality;
                            break;
                    }
                    switch (Ini.KeyExists("audioQuality", "Saved")) {
                        case true:
                            audioQuality = Ini.ReadInt("audioQuality", "Saved");
                            audioQuality_First = audioQuality;
                            break;
                    }
                    switch (Ini.KeyExists("VideoFormat", "Saved")) {
                        case true:
                            VideoFormat = Ini.ReadInt("VideoFormat", "Saved");
                            VideoFormat_First = VideoFormat;
                            break;
                    }
                    switch (Ini.KeyExists("AudioFormat", "Saved")) {
                        case true:
                            AudioFormat = Ini.ReadInt("AudioFormat", "Saved");
                            AudioFormat_First = AudioFormat;
                            break;
                    }
                    switch (Ini.KeyExists("AudioVBRQuality", "Saved")) {
                        case true:
                            AudioVBRQuality = Ini.ReadInt("AudioVBRQuality", "Saved");
                            AudioVBRQuality_First = AudioVBRQuality;
                            break;
                    }
                    switch (Ini.KeyExists("BatchFormX", "Saved")) {
                        case true:
                            BatchFormX = Ini.ReadInt("BatchFormX", "Saved");
                            BatchFormX_First = BatchFormX;
                            break;
                    }
                    switch (Ini.KeyExists("BatchFormY", "Saved")) {
                        case true:
                            BatchFormY = Ini.ReadInt("BatchFormY", "Saved");
                            BatchFormY_First = BatchFormY;
                            break;
                    }
                    switch (Ini.KeyExists("MainFormSize", "Saved")) {
                        case true:
                            MainFormSize = Ini.ReadSize("MainFormSize", "Saved");
                            MainFormSize_First = MainFormSize;
                            break;
                    }
                    switch (Ini.KeyExists("SettingsFormSize", "Saved")) {
                        case true:
                            SettingsFormSize = Ini.ReadSize("SettingsFormSize", "Saved");
                            SettingsFormSize_First = SettingsFormSize;
                            break;
                    }
                    switch (Ini.KeyExists("FileNameSchemaHistory", "Saved")) {
                        case true:
                            FileNameSchemaHistory = Ini.ReadString("FileNameSchemaHistory", "Saved");
                            FileNameSchemaHistory_First = FileNameSchemaHistory;
                            break;
                    }
                    switch (Ini.KeyExists("DownloadCustomArguments", "Saved")) {
                        case true:
                            DownloadCustomArguments = Ini.ReadString("DownloadCustomArguments", "Saved");
                            DownloadCustomArguments_First = DownloadCustomArguments;
                            break;
                    }
                    switch (Ini.KeyExists("CustomArgumentsIndex", "Saved")) {
                        case true:
                            CustomArgumentsIndex = Ini.ReadInt("CustomArgumentsIndex", "Saved");
                            CustomArgumentsIndex_First = CustomArgumentsIndex;
                            break;
                    }
                    switch (Ini.KeyExists("MainFormLocation", "Saved")) {
                        case true:
                            MainFormLocation = Ini.ReadPoint("MainFormLocation", "Saved");
                            MainFormLocation_First = MainFormLocation;
                            break;
                    }

                    break;

                case false:
                    downloadType = Settings.Saved.Default.downloadType;
                    UseStaticYtdl = Settings.Saved.Default.UseStaticYtdl;
                    convertSaveAudioIndex = Settings.Saved.Default.convertSaveAudioIndex;
                    convertType = Settings.Saved.Default.convertType;
                    convertCustom = Settings.Saved.Default.convertCustom;
                    videoQuality = Settings.Saved.Default.videoQuality;
                    audioQuality = Settings.Saved.Default.audioQuality;
                    VideoFormat = Settings.Saved.Default.VideoFormat;
                    AudioFormat = Settings.Saved.Default.AudioFormat;
                    AudioVBRQuality = Settings.Saved.Default.AudioVBRQuality;
                    BatchFormX = Settings.Saved.Default.BatchFormX;
                    BatchFormY = Settings.Saved.Default.BatchFormY;
                    MainFormSize = Settings.Saved.Default.MainFormSize;
                    SettingsFormSize = Settings.Saved.Default.SettingsFormSize;
                    FileNameSchemaHistory = Settings.Saved.Default.FileNameSchemaHistory;
                    DownloadCustomArguments = Settings.Saved.Default.DownloadCustomArguments;
                    CustomArgumentsIndex = Settings.Saved.Default.CustomArgumentsIndex;
                    MainFormLocation = Settings.Saved.Default.MainFormLocation;
                    break;
            }
        }
        public void Save() {
            switch (Program.UseIni) {
                case true:
                    switch (downloadType != downloadType_First) {
                        case true:
                            Ini.Write("downloadType", downloadType, "Saved");
                            downloadType_First = downloadType;
                            break;
                    }
                    switch (UseStaticYtdl != UseStaticYtdl_First) {
                        case true:
                            Ini.Write("UseStaticYtdl", UseStaticYtdl, "Saved");
                            UseStaticYtdl_First = UseStaticYtdl;
                            break;
                    }
                    switch (convertSaveAudioIndex != convertSaveAudioIndex_First) {
                        case true:
                            Ini.Write("convertSaveAudioIndex", convertSaveAudioIndex, "Saved");
                            convertSaveAudioIndex_First = convertSaveAudioIndex;
                            break;
                    }
                    switch (convertType != convertType_First) {
                        case true:
                            Ini.Write("convertType", convertType, "Saved");
                            convertType_First = convertType;
                            break;
                    }
                    switch (convertCustom != convertCustom_First) {
                        case true:
                            Ini.Write("convertCustom", convertCustom, "Saved");
                            convertCustom_First = convertCustom;
                            break;
                    }
                    switch (videoQuality != videoQuality_First) {
                        case true:
                            Ini.Write("videoQuality", videoQuality, "Saved");
                            videoQuality_First = videoQuality;
                            break;
                    }
                    switch (audioQuality != audioQuality_First) {
                        case true:
                            Ini.Write("audioQuality", audioQuality, "Saved");
                            audioQuality_First = audioQuality;
                            break;
                    }
                    switch (VideoFormat != VideoFormat_First) {
                        case true:
                            Ini.Write("VideoFormat", VideoFormat, "Saved");
                            VideoFormat_First = VideoFormat;
                            break;
                    }
                    switch (AudioFormat != AudioFormat_First) {
                        case true:
                            Ini.Write("AudioFormat", AudioFormat, "Saved");
                            AudioFormat_First = AudioFormat;
                            break;
                    }
                    switch (AudioVBRQuality != AudioVBRQuality_First) {
                        case true:
                            Ini.Write("AudioVBRQuality", AudioVBRQuality, "Saved");
                            AudioVBRQuality_First = AudioVBRQuality;
                            break;
                    }
                    switch (BatchFormX != BatchFormX_First) {
                        case true:
                            Ini.Write("BatchFormX", BatchFormX, "Saved");
                            BatchFormX_First = BatchFormX;
                            break;
                    }
                    switch (BatchFormY != BatchFormY_First) {
                        case true:
                            Ini.Write("BatchFormY", BatchFormY, "Saved");
                            BatchFormY_First = BatchFormY;
                            break;
                    }
                    switch (MainFormSize != MainFormSize_First) {
                        case true:
                            Ini.Write("MainFormSize", MainFormSize, "Saved");
                            MainFormSize_First = MainFormSize;
                            break;
                    }
                    switch (SettingsFormSize != SettingsFormSize_First) {
                        case true:
                            Ini.Write("SettingsFormSize", SettingsFormSize, "Saved");
                            SettingsFormSize_First = SettingsFormSize;
                            break;
                    }
                    switch (FileNameSchemaHistory != FileNameSchemaHistory_First) {
                        case true:
                            Ini.Write("FileNameSchemaHistory", FileNameSchemaHistory, "Saved");
                            FileNameSchemaHistory_First = FileNameSchemaHistory;
                            break;
                    }
                    switch (DownloadCustomArguments != DownloadCustomArguments_First) {
                        case true:
                            Ini.Write("DownloadCustomArguments", DownloadCustomArguments, "Saved");
                            DownloadCustomArguments_First = DownloadCustomArguments;
                            break;
                    }
                    switch (CustomArgumentsIndex != CustomArgumentsIndex_First) {
                        case true:
                            Ini.Write("CustomArgumentsIndex", CustomArgumentsIndex, "Saved");
                            CustomArgumentsIndex_First = CustomArgumentsIndex;
                            break;
                    }
                    switch (MainFormLocation != MainFormLocation_First) {
                        case true:
                            Ini.Write("MainFormLocation", MainFormLocation, "Saved");
                            MainFormLocation_First = MainFormLocation;
                            break;
                    }

                    break;

                case false:
                    bool Save = false;

                    if (Settings.Saved.Default.downloadType != downloadType) {
                        Settings.Saved.Default.downloadType = downloadType;
                        Save = true;
                    }
                    if (Settings.Saved.Default.UseStaticYtdl != UseStaticYtdl) {
                        Settings.Saved.Default.UseStaticYtdl = UseStaticYtdl;
                        Save = true;
                    }
                    if (Settings.Saved.Default.convertSaveAudioIndex != convertSaveAudioIndex) {
                        Settings.Saved.Default.convertSaveAudioIndex = convertSaveAudioIndex;
                        Save = true;
                    }
                    if (Settings.Saved.Default.convertType != convertType) {
                        Settings.Saved.Default.convertType = convertType;
                        Save = true;
                    }
                    if (Settings.Saved.Default.convertCustom != convertCustom) {
                        Settings.Saved.Default.convertCustom = convertCustom;
                        Save = true;
                    }
                    if (Settings.Saved.Default.videoQuality != videoQuality) {
                        Settings.Saved.Default.videoQuality = videoQuality;
                        Save = true;
                    }
                    if (Settings.Saved.Default.audioQuality != audioQuality) {
                        Settings.Saved.Default.audioQuality = audioQuality;
                        Save = true;
                    }
                    if (Settings.Saved.Default.VideoFormat != VideoFormat) {
                        Settings.Saved.Default.VideoFormat = VideoFormat;
                        Save = true;
                    }
                    if (Settings.Saved.Default.AudioFormat != AudioFormat) {
                        Settings.Saved.Default.AudioFormat = AudioFormat;
                        Save = true;
                    }
                    if (Settings.Saved.Default.AudioVBRQuality != AudioVBRQuality) {
                        Settings.Saved.Default.AudioVBRQuality = AudioVBRQuality;
                        Save = true;
                    }
                    if (Settings.Saved.Default.BatchFormX != BatchFormX) {
                        Settings.Saved.Default.BatchFormX = BatchFormX;
                        Save = true;
                    }
                    if (Settings.Saved.Default.BatchFormY != BatchFormY) {
                        Settings.Saved.Default.BatchFormY = BatchFormY;
                        Save = true;
                    }
                    if (Settings.Saved.Default.MainFormSize != MainFormSize) {
                        Settings.Saved.Default.MainFormSize = MainFormSize;
                        Save = true;
                    }
                    if (Settings.Saved.Default.SettingsFormSize != SettingsFormSize) {
                        Settings.Saved.Default.SettingsFormSize = SettingsFormSize;
                        Save = true;
                    }
                    if (Settings.Saved.Default.FileNameSchemaHistory != FileNameSchemaHistory) {
                        Settings.Saved.Default.FileNameSchemaHistory = FileNameSchemaHistory;
                        Save = true;
                    }
                    if (Settings.Saved.Default.DownloadCustomArguments != DownloadCustomArguments) {
                        Settings.Saved.Default.DownloadCustomArguments = DownloadCustomArguments;
                        Save = true;
                    }
                    if (Settings.Saved.Default.CustomArgumentsIndex != CustomArgumentsIndex) {
                        Settings.Saved.Default.CustomArgumentsIndex = CustomArgumentsIndex;
                        Save = true;
                    }
                    if (Settings.Saved.Default.MainFormLocation != MainFormLocation) {
                        Settings.Saved.Default.MainFormLocation = MainFormLocation;
                        Save = true;
                    }

                    switch (Save) {
                        case true:
                            Settings.Saved.Default.Save();
                            break;
                    }
                    break;
            }
        }

        public void ForceSave() {
            switch (Program.UseIni) {
                case true:
                    Ini.Write("downloadType", downloadType, "Saved");
                    downloadType_First = downloadType;

                    Ini.Write("UseStaticYtdl", UseStaticYtdl, "Saved");
                    UseStaticYtdl_First = UseStaticYtdl;

                    Ini.Write("convertSaveAudioIndex", convertSaveAudioIndex, "Saved");
                    convertSaveAudioIndex_First = convertSaveAudioIndex;

                    Ini.Write("convertType", convertType, "Saved");
                    convertType_First = convertType;

                    Ini.Write("convertCustom", convertCustom, "Saved");
                    convertCustom_First = convertCustom;

                    Ini.Write("videoQuality", videoQuality, "Saved");
                    videoQuality_First = videoQuality;

                    Ini.Write("audioQuality", audioQuality, "Saved");
                    audioQuality_First = audioQuality;

                    Ini.Write("VideoFormat", VideoFormat, "Saved");
                    VideoFormat_First = VideoFormat;

                    Ini.Write("AudioFormat", AudioFormat, "Saved");
                    AudioFormat_First = AudioFormat;

                    Ini.Write("AudioVBRQuality", AudioVBRQuality, "Saved");
                    AudioVBRQuality_First = AudioVBRQuality;

                    Ini.Write("BatchFormX", BatchFormX, "Saved");
                    BatchFormX_First = BatchFormX;

                    Ini.Write("BatchFormY", BatchFormY, "Saved");
                    BatchFormY_First = BatchFormY;

                    Ini.Write("MainFormSize", MainFormSize, "Saved");
                    MainFormSize_First = MainFormSize;

                    Ini.Write("SettingsFormSize", SettingsFormSize, "Saved");
                    SettingsFormSize_First = SettingsFormSize;

                    Ini.Write("FileNameSchemaHistory", FileNameSchemaHistory, "Saved");
                    FileNameSchemaHistory_First = FileNameSchemaHistory;

                    Ini.Write("DownloadCustomArguments", DownloadCustomArguments, "Saved");
                    DownloadCustomArguments_First = DownloadCustomArguments;

                    Ini.Write("CustomArgumentsIndex", CustomArgumentsIndex, "Saved");
                    CustomArgumentsIndex_First = CustomArgumentsIndex;

                    Ini.Write("MainFormLocation", MainFormLocation, "Saved");
                    MainFormLocation_First = MainFormLocation;

                    break;

                case false:
                    Settings.Saved.Default.downloadType = downloadType;
                    Settings.Saved.Default.UseStaticYtdl = UseStaticYtdl;
                    Settings.Saved.Default.convertSaveAudioIndex = convertSaveAudioIndex;
                    Settings.Saved.Default.convertType = convertType;
                    Settings.Saved.Default.convertCustom = convertCustom;
                    Settings.Saved.Default.videoQuality = videoQuality;
                    Settings.Saved.Default.audioQuality = audioQuality;
                    Settings.Saved.Default.VideoFormat = VideoFormat;
                    Settings.Saved.Default.AudioFormat = AudioFormat;
                    Settings.Saved.Default.AudioVBRQuality = AudioVBRQuality;
                    Settings.Saved.Default.BatchFormX = BatchFormX;
                    Settings.Saved.Default.BatchFormY = BatchFormY;
                    Settings.Saved.Default.MainFormSize = MainFormSize;
                    Settings.Saved.Default.SettingsFormSize = SettingsFormSize;
                    Settings.Saved.Default.FileNameSchemaHistory = FileNameSchemaHistory;
                    Settings.Saved.Default.DownloadCustomArguments = DownloadCustomArguments;
                    Settings.Saved.Default.CustomArgumentsIndex = CustomArgumentsIndex;
                    Settings.Saved.Default.MainFormLocation = MainFormLocation;
                    Settings.Saved.Default.Save();
                    break;
            }
        }
    }

    class Config_Settings {
        public Config_Settings() {
            Load();
        }

        //LanguageFile is Initialization

        public string extensionsName = string.Empty;
        public string extensionsShort = string.Empty;

        private string extensionsName_First = string.Empty;
        private string extensionsShort_First = string.Empty;

        //_First private
        public void Load() {
            switch (Program.UseIni) {
                case true:
                    switch (Ini.KeyExists("extensionsName", "Settings")) {
                        case true:
                            extensionsName = Ini.ReadString("extensionsName", "Settings");
                            extensionsName_First = extensionsName;
                            break;
                    }

                    switch (Ini.KeyExists("extensionsShort", "Settings")) {
                        case true:
                            extensionsShort = Ini.ReadString("extensionsShort", "Settings");
                            extensionsShort_First = extensionsShort;
                            break;
                    }
                    break;

                case false:
                    extensionsName = Settings.Settings.Default.extensionsName;
                    extensionsShort = Settings.Settings.Default.extensionsShort;
                    break;
            }
        }
        public void Save() {
            switch (Program.UseIni) {
                case true:
                    switch (extensionsName != extensionsName_First) {
                        case true:
                            Ini.Write("extensionsName", extensionsName, "Settings");
                            extensionsName_First = extensionsName;
                            break;
                    }
                    switch (extensionsShort != extensionsShort_First) {
                        case true:
                            Ini.Write("extensionsShort", extensionsShort, "Settings");
                            extensionsShort_First = extensionsShort;
                            break;
                    }

                    break;

                case false:
                    bool Save = false;

                    if (Settings.Settings.Default.extensionsName != extensionsName) {
                        Settings.Settings.Default.extensionsName = extensionsName;
                        Save = true;
                    }

                    if (Settings.Settings.Default.extensionsShort != extensionsShort) {
                        Settings.Settings.Default.extensionsShort = extensionsShort;
                        Save = true;
                    }

                    switch (Save) {
                        case true:
                            Settings.Settings.Default.Save();
                            break;
                    }
                    break;
            }
        }

        public void ForceSave() {
            switch (Program.UseIni) {
                case true:
                    Ini.Write("extensionsName", extensionsName, "Settings");
                    extensionsName_First = extensionsName;

                    Ini.Write("extensionsShort", extensionsShort, "Settings");
                    extensionsShort_First = extensionsShort;
                    break;

                case false:
                    Settings.Settings.Default.extensionsName = extensionsName;
                    Settings.Settings.Default.extensionsShort = extensionsShort;
                    Settings.Settings.Default.Save();
                    break;
            }
        }
    }

    class Ini {
        public static string Path = Environment.CurrentDirectory + "\\settings.ini";
        public static string ExecutableName = Assembly.GetExecutingAssembly().GetName().Name;

        public static string ReadString(string Key, string Section = null) {
            var RetVal = new StringBuilder(65535);
            NativeMethods.GetPrivateProfileString(Section ?? ExecutableName, Key, "", RetVal, 65535, Path);
            return RetVal.ToString();
        }
        public static bool ReadBool(string Key, string Section = null) {
            var RetVal = new StringBuilder(255);
            NativeMethods.GetPrivateProfileString(Section ?? ExecutableName, Key.ToLower(), "", RetVal, 255, Path);
            switch (RetVal.ToString().ToLower()) {
                case "true":
                    return true;

                default:
                    return false;
            }
        }
        public static int ReadInt(string Key, string Section = null) {
            var RetVal = new StringBuilder(255);
            NativeMethods.GetPrivateProfileString(Section ?? ExecutableName, Key.ToLower(), "", RetVal, 255, Path);
            string RetStr = RetVal.ToString();
            int RetInt;
            if (int.TryParse(RetStr, out RetInt)) {
                return RetInt;
            }
            else {
                return -1;
            }
        }
        public static decimal ReadDecimal(string Key, string Section = null) {
            var RetVal = new StringBuilder(255);
            NativeMethods.GetPrivateProfileString(Section ?? ExecutableName, Key, "", RetVal, 255, Path);
            decimal RetDec;
            if (decimal.TryParse(RetVal.ToString(), out RetDec)) {
                return RetDec;
            }
            else {
                return -1;
            }
        }
        public static Point ReadPoint(string Key, string Section = null) {
            var RetVal = new StringBuilder(255);
            NativeMethods.GetPrivateProfileString(Section ?? ExecutableName, Key, "", RetVal, 255, Path);
            string[] Value = RetVal.ToString().Split(',');
            if (Value.Length == 2) {
                int Temp;
                Point OutputPoint = new Point();
                if (int.TryParse(Value[0], out Temp)) {
                    OutputPoint.X = Temp;
                }
                else {
                    OutputPoint.X = -32000;
                }
                if (int.TryParse(Value[1], out Temp)) {
                    OutputPoint.Y = Temp;
                }
                else {
                    OutputPoint.Y = -32000;
                }
                return OutputPoint;
            }
            else {
                return new Point(-32000, -32000);
            }
        }
        public static Size ReadSize(string Key, string Section = null) {
            var RetVal = new StringBuilder(255);
            NativeMethods.GetPrivateProfileString(Section ?? ExecutableName, Key, "", RetVal, 255, Path);
            string[] Value = RetVal.ToString().Split(',');
            if (Value.Length == 2) {
                int Temp;
                Size OutputPoint = new Size();
                if (int.TryParse(Value[0], out Temp)) {
                    OutputPoint.Width = Temp;
                }
                else {
                    OutputPoint.Width = -32000;
                }
                if (int.TryParse(Value[1], out Temp)) {
                    OutputPoint.Height = Temp;
                }
                else {
                    OutputPoint.Height = -32000;
                }
                return OutputPoint;
            }
            else {
                return new Size(-32000, -32000);
            }
        }

        public static void Write(string Key, string Value, string Section = null) {
            NativeMethods.WritePrivateProfileString(Section ?? ExecutableName, Key, Value, Path);
        }
        public static void Write(string Key, bool Value, string Section = null) {
            NativeMethods.WritePrivateProfileString(Section ?? ExecutableName, Key, Value ? "True" : "False", Path);
        }
        public static void Write(string Key, int Value, string Section = null) {
            NativeMethods.WritePrivateProfileString(Section ?? ExecutableName, Key, Value.ToString(), Path);
        }
        public static void Write(string Key, decimal Value, string Section = null) {
            NativeMethods.WritePrivateProfileString(Section ?? ExecutableName, Key, Value.ToString(), Path);
        }
        public static void Write(string Key, Point Value, string Section = null) {
            NativeMethods.WritePrivateProfileString(Section ?? ExecutableName, Key, Value.X + "," + Value.Y, Path);
        }
        public static void Write(string Key, Size Value, string Section = null) {
            NativeMethods.WritePrivateProfileString(Section ?? ExecutableName, Key, Value.Width + "," + Value.Height, Path);
        }

        public static void DeleteKey(string Key, string Section = null) {
            Write(Key, null, Section ?? ExecutableName);
        }
        public static void DeleteSection(string Section = null) {
            Write(null, null, Section ?? ExecutableName);
        }

        public static bool KeyExists(string Key, string Section = null) {
            return ReadString(Key, Section ?? ExecutableName).Length > 0;
        }
    }
}