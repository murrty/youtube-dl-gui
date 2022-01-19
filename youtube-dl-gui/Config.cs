using Microsoft.Win32;
using System;
using System.Drawing;
using System.Text;

namespace youtube_dl_gui {

    public enum ConfigType {
        None,
        All,
        Initialization,
        Batch,
        Converts,
        Downloads,
        Errors,
        General,
        Saved
    }

    class Config {
        public static volatile Config Settings;

        public Config_Initialization Initialization;
        public Config_Batch Batch;
        public Config_Converts Converts;
        public Config_Downloads Downloads;
        public Config_Errors Errors;
        public Config_General General;
        public Config_Saved Saved;

        public Config() {
            Initialization = new();
            Batch = new();
            Converts = new();
            Downloads = new();
            Errors = new();
            General = new();
            Saved = new();
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
            }
        }

        public void ConvertConfig(bool UseIni) {
            if (Program.UseIni && !UseIni) {
                Ini.Write("UseIni", false);
            }
            else {
                Ini.Write("UseIni", true);
            }

            Program.UseIni = UseIni;
            Initialization.ForceSave();
            Batch.ForceSave();
            Converts.ForceSave();
            Downloads.ForceSave();
            Errors.ForceSave();
            General.ForceSave();
            Saved.ForceSave();
        }

        public void CleanIniFile() {
            if (Program.UseIni) {
                System.IO.File.Delete(Program.ProgramPath + "\\settings.ini");

                Initialization.ForceSave();
                General.ForceSave();
                Downloads.ForceSave();
                Converts.ForceSave();
                Errors.ForceSave();
                Batch.ForceSave();
                Saved.ForceSave();

                Ini.Write("UseIni", true);
            }
        }

        /// <summary>
        /// Checks if a point is a valid one to use.
        /// </summary>
        /// <param name="input">The <seealso cref="Point"/> value to validate.</param>
        /// <returns>If the input is a valid point.</returns>
        public static bool ValidPoint(Point input) {
            return input.X != -32000 && input.Y != -32000;
        }

        /// <summary>
        /// Checks if a size is a valid one to use.
        /// </summary>
        /// <param name="input">The <seealso cref="Size"/> value to validate.</param>
        /// <returns>If the input is a valid size.</returns>
        public static bool ValidSize(Size input) {
            return input.Width > 0 && input.Height > 0;
        }
    }

    class Config_Initialization {

        public string LanguageFile = string.Empty;
        public bool firstTime = true;
        public decimal SkippedVersion = -1;
        public string SkippedBetaVersion = "0";

        private string LanguageFile_First = string.Empty;
        private bool firstTime_First = true;
        private decimal SkippedVersion_First = -1;
        private string SkippedBetaVersion_First = "0";

        public Config_Initialization() { }

        public void Load() {
            switch (Program.UseIni) {
                case true:
                    switch (Ini.KeyExists("firstTime")) {
                        case true:
                            firstTime_First = firstTime = Ini.ReadBool("firstTime");
                            break;
                    }

                    switch (Ini.KeyExists("LanguageFile")) {
                        case true:
                            LanguageFile_First = LanguageFile = Ini.ReadString("LanguageFile");
                            break;
                    }

                    switch (Ini.KeyExists("SkippedVersion")) {
                        case true:
                            SkippedVersion_First = SkippedVersion = Ini.ReadDecimal("SkippedVersion");
                            break;
                    }

                    switch (Ini.KeyExists("SkippedBetaVersion")) {
                        case true:
                            SkippedBetaVersion_First = SkippedBetaVersion = Ini.ReadString("SkippedBetaVersion");
                            break;
                    }
                    break;

                case false:
                    firstTime = Properties.Settings.Default.firstTime;
                    LanguageFile = Properties.Settings.Default.LanguageFile;
                    SkippedVersion = Properties.Settings.Default.SkippedVersion;
                    SkippedBetaVersion = Properties.Settings.Default.SkippedBetaVersion;
                    break;
            }
        }
        public void Save() {
            switch (Program.UseIni) {
                case true:
                    switch (firstTime != firstTime_First) {
                        case true:
                            Ini.Write("firstTime", firstTime);
                            firstTime_First = firstTime;
                            break;
                    }

                    switch (LanguageFile != LanguageFile_First) {
                        case true:
                            Ini.Write("LanguageFile", LanguageFile);
                            LanguageFile_First = LanguageFile;
                            break;
                    }

                    switch (SkippedVersion != SkippedVersion_First) {
                        case true:
                            Ini.Write("SkippedVersion", SkippedVersion);
                            SkippedVersion_First = SkippedVersion;
                            break;
                    }

                    switch (SkippedBetaVersion != SkippedBetaVersion_First) {
                        case true:
                            Ini.Write("SkippedBetaVersion", SkippedBetaVersion);
                            SkippedBetaVersion_First = SkippedBetaVersion;
                            break;
                    }
                    break;

                case false:
                    bool Save = false;

                    if (Properties.Settings.Default.firstTime != firstTime) {
                        Properties.Settings.Default.firstTime = firstTime;
                        Save = true;
                    }

                    if (Properties.Settings.Default.LanguageFile != LanguageFile) {
                        Properties.Settings.Default.LanguageFile = LanguageFile;
                        Save = true;
                    }

                    if (Properties.Settings.Default.SkippedVersion != SkippedVersion) {
                        Properties.Settings.Default.SkippedVersion = SkippedVersion;
                        Save = true;
                    }

                    if (Properties.Settings.Default.SkippedBetaVersion != SkippedBetaVersion) {
                        Properties.Settings.Default.SkippedBetaVersion = SkippedBetaVersion;
                        Save = true;
                    }

                    switch (Save) {
                        case true:
                            Properties.Settings.Default.Save();
                            break;
                    }
                    break;
            }
        }

        public void ForceSave() {
            switch (Program.UseIni) {
                case true:
                    Ini.Write("firstTime", firstTime);
                    Ini.Write("LanguageFile", LanguageFile);
                    Ini.Write("SkippedVersion", SkippedVersion);
                    Ini.Write("SkippedBetaVersion", SkippedBetaVersion);
                    break;

                case false:
                    Properties.Settings.Default.firstTime = firstTime;
                    Properties.Settings.Default.LanguageFile = LanguageFile;
                    Properties.Settings.Default.SkippedVersion = SkippedVersion;
                    Properties.Settings.Default.SkippedBetaVersion = SkippedBetaVersion;
                    Properties.Settings.Default.Save();
                    break;
            }
        }
    }

    class Config_Batch {
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

        private int SelectedType_First = -1;
        private int SelectedVideoQuality_First = 0;
        private int SelectedVideoFormat_First = 0;
        private int SelectedAudioQuality_First = 0;
        private int SelectedAudioFormat_First = 0;
        private bool DownloadVideoSound_First = false;
        private bool DownloadAudioVBR_First = false;
        private int SelectedAudioQualityVBR_First = 0;
        private string CustomArguments_First = string.Empty;

        public Config_Batch() { }

        public void Save() {
            switch (Program.UseIni) {
                case true:
                    switch (SelectedType != SelectedType_First) {
                        case true:
                            Ini.Write("SelectedType", SelectedType, ConfigName);
                            SelectedType_First = SelectedType;
                            break;
                    }
                    switch (SelectedVideoQuality != SelectedVideoQuality_First) {
                        case true:
                            Ini.Write("SelectedVideoQuality", SelectedVideoQuality, ConfigName);
                            SelectedVideoQuality_First = SelectedVideoQuality;
                            break;
                    }
                    switch (SelectedVideoFormat != SelectedVideoFormat_First) {
                        case true:
                            Ini.Write("SelectedVideoFormat", SelectedVideoFormat, ConfigName);
                            SelectedVideoFormat_First = SelectedVideoFormat;
                            break;
                    }
                    switch (SelectedAudioQuality != SelectedAudioQuality_First) {
                        case true:
                            Ini.Write("SelectedAudioQuality", SelectedAudioQuality, ConfigName);
                            SelectedAudioQuality_First = SelectedAudioQuality;
                            break;
                    }
                    switch (SelectedAudioFormat != SelectedAudioFormat_First) {
                        case true:
                            Ini.Write("SelectedAudioFormat", SelectedAudioFormat, ConfigName);
                            SelectedAudioFormat_First = SelectedAudioFormat;
                            break;
                    }
                    switch (DownloadVideoSound != DownloadVideoSound_First) {
                        case true:
                            Ini.Write("DownloadVideoSound", DownloadVideoSound, ConfigName);
                            DownloadVideoSound_First = DownloadVideoSound;
                            break;
                    }
                    switch (DownloadAudioVBR != DownloadAudioVBR_First) {
                        case true:
                            Ini.Write("DownloadAudioVBR", DownloadAudioVBR, ConfigName);
                            DownloadAudioVBR_First = DownloadAudioVBR;
                            break;
                    }
                    switch (SelectedAudioQualityVBR != SelectedAudioQualityVBR_First) {
                        case true:
                            Ini.Write("SelectedAudioQualityVBR", SelectedAudioQualityVBR, ConfigName);
                            SelectedAudioQualityVBR_First = SelectedAudioQualityVBR;
                            break;
                    }
                    switch (CustomArguments != CustomArguments_First) {
                        case true:
                            Ini.Write("CustomArguments", CustomArguments, ConfigName);
                            CustomArguments_First = CustomArguments;
                            break;
                    }

                    break;

                case false:
                    bool Save = false;

                    if (Configurations.Batch.Default.SelectedType != SelectedType) {
                        Configurations.Batch.Default.SelectedType = SelectedType;
                        Save = true;
                    }
                    if (Configurations.Batch.Default.SelectedVideoQuality != SelectedVideoQuality) {
                        Configurations.Batch.Default.SelectedVideoQuality = SelectedVideoQuality;
                        Save = true;
                    }
                    if (Configurations.Batch.Default.SelectedVideoFormat != SelectedVideoFormat) {
                        Configurations.Batch.Default.SelectedVideoFormat = SelectedVideoFormat;
                        Save = true;
                    }
                    if (Configurations.Batch.Default.SelectedAudioQuality != SelectedAudioQuality) {
                        Configurations.Batch.Default.SelectedAudioQuality = SelectedAudioQuality;
                        Save = true;
                    }
                    if (Configurations.Batch.Default.SelectedAudioFormat != SelectedAudioFormat) {
                        Configurations.Batch.Default.SelectedAudioFormat = SelectedAudioFormat;
                        Save = true;
                    }
                    if (Configurations.Batch.Default.DownloadVideoSound != DownloadVideoSound) {
                        Configurations.Batch.Default.DownloadVideoSound = DownloadVideoSound;
                        Save = true;
                    }
                    if (Configurations.Batch.Default.DownloadAudioVBR != DownloadAudioVBR) {
                        Configurations.Batch.Default.DownloadAudioVBR = DownloadAudioVBR;
                        Save = true;
                    }
                    if (Configurations.Batch.Default.SelectedAudioQualityVBR != SelectedAudioQualityVBR) {
                        Configurations.Batch.Default.SelectedAudioQualityVBR = SelectedAudioQualityVBR;
                        Save = true;
                    }
                    if (Configurations.Batch.Default.CustomArguments != CustomArguments) {
                        Configurations.Batch.Default.CustomArguments = CustomArguments;
                        Save = true;
                    }

                    switch (Save) {
                        case true:
                            Configurations.Batch.Default.Save();
                            break;
                    }
                    break;
            }
        }
        public void Load() {
            switch (Program.UseIni) {
                case true:
                    if (Ini.KeyExists("SelectedType", ConfigName)) {
                        SelectedType = Ini.ReadInt("SelectedType", ConfigName);
                        SelectedType_First = SelectedType;
                    }
                    if (Ini.KeyExists("SelectedVideoQuality", ConfigName)) {
                        SelectedVideoQuality = Ini.ReadInt("SelectedVideoQuality", ConfigName);
                        SelectedVideoQuality_First = SelectedVideoQuality;
                    }
                    if (Ini.KeyExists("SelectedVideoFormat", ConfigName)) {
                        SelectedVideoFormat = Ini.ReadInt("SelectedVideoFormat", ConfigName);
                        SelectedVideoFormat_First = SelectedVideoFormat;
                    }
                    if (Ini.KeyExists("SelectedAudioQuality", ConfigName)) {
                        SelectedAudioQuality = Ini.ReadInt("SelectedAudioQuality", ConfigName);
                        SelectedAudioQuality_First = SelectedAudioQuality;
                    }
                    if (Ini.KeyExists("SelectedAudioFormat", ConfigName)) {
                        SelectedAudioFormat = Ini.ReadInt("SelectedAudioFormat", ConfigName);
                        SelectedAudioFormat_First = SelectedAudioFormat;
                    }
                    if (Ini.KeyExists("DownloadVideoSound", ConfigName)) {
                        DownloadVideoSound = Ini.ReadBool("DownloadVideoSound", ConfigName);
                        DownloadVideoSound_First = DownloadVideoSound;
                    }
                    if (Ini.KeyExists("DownloadAudioVBR", ConfigName)) {
                        DownloadAudioVBR = Ini.ReadBool("DownloadAudioVBR", ConfigName);
                        DownloadAudioVBR_First = DownloadAudioVBR;
                    }
                    if (Ini.KeyExists("SelectedAudioQualityVBR", ConfigName)) {
                        SelectedAudioQualityVBR = Ini.ReadInt("SelectedAudioQualityVBR", ConfigName);
                        SelectedAudioQualityVBR_First = SelectedAudioQualityVBR;
                    }
                    if (Ini.KeyExists("CustomArguments", ConfigName)) {
                        CustomArguments = Ini.ReadString("CustomArguments", ConfigName);
                        CustomArguments_First = CustomArguments;
                    }
                    break;

                case false:
                    SelectedType = Configurations.Batch.Default.SelectedType;
                    SelectedVideoQuality = Configurations.Batch.Default.SelectedVideoQuality;
                    SelectedVideoFormat = Configurations.Batch.Default.SelectedVideoFormat;
                    SelectedAudioQuality = Configurations.Batch.Default.SelectedAudioQuality;
                    SelectedAudioFormat = Configurations.Batch.Default.SelectedAudioFormat;
                    DownloadVideoSound = Configurations.Batch.Default.DownloadVideoSound;
                    DownloadAudioVBR = Configurations.Batch.Default.DownloadAudioVBR;
                    SelectedAudioQualityVBR = Configurations.Batch.Default.SelectedAudioQualityVBR;
                    CustomArguments = Configurations.Batch.Default.CustomArguments;
                    break;
            }
        }

        public void ForceSave() {
            switch (Program.UseIni) {
                case true:

                    Ini.Write("SelectedType", SelectedType, ConfigName);
                    SelectedType_First = SelectedType;

                    Ini.Write("SelectedVideoQuality", SelectedVideoQuality, ConfigName);
                    SelectedVideoQuality_First = SelectedVideoQuality;

                    Ini.Write("SelectedVideoFormat", SelectedVideoFormat, ConfigName);
                    SelectedVideoFormat_First = SelectedVideoFormat;

                    Ini.Write("SelectedAudioQuality", SelectedAudioQuality, ConfigName);
                    SelectedAudioQuality_First = SelectedAudioQuality;

                    Ini.Write("SelectedAudioFormat", SelectedAudioFormat, ConfigName);
                    SelectedAudioFormat_First = SelectedAudioFormat;

                    Ini.Write("DownloadVideoSound", DownloadVideoSound, ConfigName);
                    DownloadVideoSound_First = DownloadVideoSound;

                    Ini.Write("DownloadAudioVBR", DownloadAudioVBR, ConfigName);
                    DownloadAudioVBR_First = DownloadAudioVBR;

                    Ini.Write("SelectedAudioQualityVBR", SelectedAudioQualityVBR, ConfigName);
                    SelectedAudioQualityVBR_First = SelectedAudioQualityVBR;

                    Ini.Write("CustomArguments", CustomArguments, ConfigName);
                    CustomArguments_First = CustomArguments;

                    break;

                case false:
                    Configurations.Batch.Default.SelectedType = SelectedType;
                    Configurations.Batch.Default.SelectedVideoQuality = SelectedVideoQuality;
                    Configurations.Batch.Default.SelectedVideoFormat = SelectedVideoFormat;
                    Configurations.Batch.Default.SelectedAudioQuality = SelectedAudioQuality;
                    Configurations.Batch.Default.SelectedAudioFormat = SelectedAudioFormat;
                    Configurations.Batch.Default.DownloadVideoSound = DownloadVideoSound;
                    Configurations.Batch.Default.DownloadAudioVBR = DownloadAudioVBR;
                    Configurations.Batch.Default.SelectedAudioQualityVBR = SelectedAudioQualityVBR;
                    Configurations.Batch.Default.CustomArguments = CustomArguments;
                    Configurations.Batch.Default.Save();
                    break;
            }
        }
    }

    class Config_Converts {
        private const string ConfigName = "Converts";

        #region Variables
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
        public bool CloseAfterFinish = false;

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
        private bool CloseAfterFinish_First = false;
        #endregion

        public Config_Converts() { }

        public void Save() {
            switch (Program.UseIni) {
                case true:
                    switch (detectFiletype != detectFiletype_First) {
                        case true:
                            Ini.Write("detectFiletype", detectFiletype, ConfigName);
                            detectFiletype_First = detectFiletype;
                            break;
                    }
                    switch (clearOutput != clearOutput_First) {
                        case true:
                            Ini.Write("clearOutput", clearOutput, ConfigName);
                            clearOutput_First = clearOutput;
                            break;
                    }
                    switch (clearInput != clearInput_First) {
                        case true:
                            Ini.Write("clearInput", clearInput, ConfigName);
                            clearInput_First = clearInput;
                            break;
                    }
                    switch (videoBitrate != videoBitrate_First) {
                        case true:
                            Ini.Write("videoBitrate", videoBitrate, ConfigName);
                            videoBitrate_First = videoBitrate;
                            break;
                    }
                    switch (videoPreset != videoPreset_First) {
                        case true:
                            Ini.Write("videoPreset", videoPreset, ConfigName);
                            videoPreset_First = videoPreset;
                            break;
                    }
                    switch (videoProfile != videoProfile_First) {
                        case true:
                            Ini.Write("videoProfile", videoProfile, ConfigName);
                            videoProfile_First = videoProfile;
                            break;
                    }
                    switch (videoCRF != videoCRF_First) {
                        case true:
                            Ini.Write("videoCRF", videoCRF, ConfigName);
                            videoCRF_First = videoCRF;
                            break;
                    }
                    switch (videoFastStart != videoFastStart_First) {
                        case true:
                            Ini.Write("videoFastStart", videoFastStart, ConfigName);
                            videoFastStart_First = videoFastStart;
                            break;
                    }
                    switch (hideFFmpegCompile != hideFFmpegCompile_First) {
                        case true:
                            Ini.Write("hideFFmpegCompile", hideFFmpegCompile, ConfigName);
                            hideFFmpegCompile_First = hideFFmpegCompile;
                            break;
                    }
                    switch (audioBitrate != audioBitrate_First) {
                        case true:
                            Ini.Write("audioBitrate", audioBitrate, ConfigName);
                            audioBitrate_First = audioBitrate;
                            break;
                    }
                    switch (videoUseBitrate != videoUseBitrate_First) {
                        case true:
                            Ini.Write("videoUseBitrate", videoUseBitrate, ConfigName);
                            videoUseBitrate_First = videoUseBitrate;
                            break;
                    }
                    switch (videoUsePreset != videoUsePreset_First) {
                        case true:
                            Ini.Write("videoUsePreset", videoUsePreset, ConfigName);
                            videoUsePreset_First = videoUsePreset;
                            break;
                    }
                    switch (videoUseProfile != videoUseProfile_First) {
                        case true:
                            Ini.Write("videoUseProfile", videoUseProfile, ConfigName);
                            videoUseProfile_First = videoUseProfile;
                            break;
                    }
                    switch (videoUseCRF != videoUseCRF_First) {
                        case true:
                            Ini.Write("videoUseCRF", videoUseCRF, ConfigName);
                            videoUseCRF_First = videoUseCRF;
                            break;
                    }
                    switch (audioUseBitrate != audioUseBitrate_First) {
                        case true:
                            Ini.Write("audioUseBitrate", audioUseBitrate, ConfigName);
                            audioUseBitrate_First = audioUseBitrate;
                            break;
                    }
                    switch (CloseAfterFinish != CloseAfterFinish_First) {
                        case true:
                            Ini.Write("CloseAfterFinish", CloseAfterFinish, ConfigName);
                            CloseAfterFinish_First = CloseAfterFinish;
                            break;
                    }

                    break;

                case false:
                    bool Save = false;

                    if (Configurations.Converts.Default.detectFiletype != detectFiletype) {
                        Configurations.Converts.Default.detectFiletype = detectFiletype;
                        Save = true;
                    }
                    if (Configurations.Converts.Default.clearOutput != clearOutput) {
                        Configurations.Converts.Default.clearOutput = clearOutput;
                        Save = true;
                    }
                    if (Configurations.Converts.Default.clearInput != clearInput) {
                        Configurations.Converts.Default.clearInput = clearInput;
                        Save = true;
                    }
                    if (Configurations.Converts.Default.videoBitrate != videoBitrate) {
                        Configurations.Converts.Default.videoBitrate = videoBitrate;
                        Save = true;
                    }
                    if (Configurations.Converts.Default.videoPreset != videoPreset) {
                        Configurations.Converts.Default.videoPreset = videoPreset;
                        Save = true;
                    }
                    if (Configurations.Converts.Default.videoProfile != videoProfile) {
                        Configurations.Converts.Default.videoProfile = videoProfile;
                        Save = true;
                    }
                    if (Configurations.Converts.Default.videoCRF != videoCRF) {
                        Configurations.Converts.Default.videoCRF = videoCRF;
                        Save = true;
                    }
                    if (Configurations.Converts.Default.videoFastStart != videoFastStart) {
                        Configurations.Converts.Default.videoFastStart = videoFastStart;
                        Save = true;
                    }
                    if (Configurations.Converts.Default.hideFFmpegCompile != hideFFmpegCompile) {
                        Configurations.Converts.Default.hideFFmpegCompile = hideFFmpegCompile;
                        Save = true;
                    }
                    if (Configurations.Converts.Default.audioBitrate != audioBitrate) {
                        Configurations.Converts.Default.audioBitrate = audioBitrate;
                        Save = true;
                    }
                    if (Configurations.Converts.Default.videoUseBitrate != videoUseBitrate) {
                        Configurations.Converts.Default.videoUseBitrate = videoUseBitrate;
                        Save = true;
                    }
                    if (Configurations.Converts.Default.videoUsePreset != videoUsePreset) {
                        Configurations.Converts.Default.videoUsePreset = videoUsePreset;
                        Save = true;
                    }
                    if (Configurations.Converts.Default.videoUseProfile != videoUseProfile) {
                        Configurations.Converts.Default.videoUseProfile = videoUseProfile;
                        Save = true;
                    }
                    if (Configurations.Converts.Default.videoUseCRF != videoUseCRF) {
                        Configurations.Converts.Default.videoUseCRF = videoUseCRF;
                        Save = true;
                    }
                    if (Configurations.Converts.Default.audioUseBitrate != audioUseBitrate) {
                        Configurations.Converts.Default.audioUseBitrate = audioUseBitrate;
                        Save = true;
                    }
                    if (Configurations.Converts.Default.CloseAfterFinish != CloseAfterFinish) {
                        Configurations.Converts.Default.CloseAfterFinish = CloseAfterFinish;
                        Save = true;
                    }

                    switch (Save) {
                        case true:
                            Configurations.Converts.Default.Save();
                            break;
                    }
                    break;
            }
        }
        public void Load() {
            switch (Program.UseIni) {
                #region Portable Ini
                case true:
                    if (Ini.KeyExists("detectFiletype", ConfigName)) {
                        detectFiletype = Ini.ReadBool("detectFiletype", ConfigName);
                        detectFiletype_First = detectFiletype;
                    }
                    if (Ini.KeyExists("clearOutput", ConfigName)) {
                        clearOutput = Ini.ReadBool("clearOutput", ConfigName);
                        clearOutput_First = clearOutput;
                    }
                    if (Ini.KeyExists("clearInput", ConfigName)) {
                        clearInput = Ini.ReadBool("clearInput", ConfigName);
                        clearInput_First = clearInput;
                    }
                    if (Ini.KeyExists("videoBitrate", ConfigName)) {
                        videoBitrate = Ini.ReadInt("videoBitrate", ConfigName);
                        videoBitrate_First = videoBitrate;
                    }
                    if (Ini.KeyExists("videoPreset", ConfigName)) {
                        videoPreset = Ini.ReadInt("videoPreset", ConfigName);
                        videoPreset_First = videoPreset;
                    }
                    if (Ini.KeyExists("videoProfile", ConfigName)) {
                        videoProfile = Ini.ReadInt("videoProfile", ConfigName);
                        videoProfile_First = videoProfile;
                    }
                    if (Ini.KeyExists("videoCRF", ConfigName)) {
                        videoCRF = Ini.ReadInt("videoCRF", ConfigName);
                        videoCRF_First = videoCRF;
                    }
                    if (Ini.KeyExists("videoFastStart", ConfigName)) {
                        videoFastStart = Ini.ReadBool("videoFastStart", ConfigName);
                        videoFastStart_First = videoFastStart;
                    }
                    if (Ini.KeyExists("hideFFmpegCompile", ConfigName)) {
                        hideFFmpegCompile = Ini.ReadBool("hideFFmpegCompile", ConfigName);
                        hideFFmpegCompile_First = hideFFmpegCompile;
                    }
                    if (Ini.KeyExists("audioBitrate", ConfigName)) {
                        audioBitrate = Ini.ReadInt("audioBitrate", ConfigName);
                        audioBitrate_First = audioBitrate;
                    }
                    if (Ini.KeyExists("videoUseBitrate", ConfigName)) {
                        videoUseBitrate = Ini.ReadBool("videoUseBitrate", ConfigName);
                        videoUseBitrate_First = videoUseBitrate;
                    }
                    if (Ini.KeyExists("videoUsePreset", ConfigName)) {
                        videoUsePreset = Ini.ReadBool("videoUsePreset", ConfigName);
                        videoUsePreset_First = videoUsePreset;
                    }
                    if (Ini.KeyExists("videoUseProfile", ConfigName)) {
                        videoUseProfile = Ini.ReadBool("videoUseProfile", ConfigName);
                        videoUseProfile_First = videoUseProfile;
                    }
                    if (Ini.KeyExists("videoUseCRF", ConfigName)) {
                        videoUseCRF = Ini.ReadBool("videoUseCRF", ConfigName);
                        videoUseCRF_First = videoUseCRF;
                    }
                    if (Ini.KeyExists("audioUseBitrate", ConfigName)) {
                        audioUseBitrate = Ini.ReadBool("audioUseBitrate", ConfigName);
                        audioUseBitrate_First = audioUseBitrate;
                    }
                    if (Ini.KeyExists("CloseAfterFinish", ConfigName)) {
                        CloseAfterFinish = Ini.ReadBool("CloseAfterFinish", ConfigName);
                        CloseAfterFinish_First = CloseAfterFinish;
                    }
                    break;
                #endregion

                #region Internal
                case false:
                    detectFiletype = Configurations.Converts.Default.detectFiletype;
                    clearOutput = Configurations.Converts.Default.clearOutput;
                    clearInput = Configurations.Converts.Default.clearInput;
                    videoBitrate = Configurations.Converts.Default.videoBitrate;
                    videoPreset = Configurations.Converts.Default.videoPreset;
                    videoProfile = Configurations.Converts.Default.videoProfile;
                    videoCRF = Configurations.Converts.Default.videoCRF;
                    videoFastStart = Configurations.Converts.Default.videoFastStart;
                    hideFFmpegCompile = Configurations.Converts.Default.hideFFmpegCompile;
                    audioBitrate = Configurations.Converts.Default.audioBitrate;
                    videoUseBitrate = Configurations.Converts.Default.videoUseBitrate;
                    videoUsePreset = Configurations.Converts.Default.videoUsePreset;
                    videoUseProfile = Configurations.Converts.Default.videoUseProfile;
                    videoUseCRF = Configurations.Converts.Default.videoUseCRF;
                    audioUseBitrate = Configurations.Converts.Default.audioUseBitrate;
                    CloseAfterFinish = Configurations.Converts.Default.CloseAfterFinish;
                    break;
                #endregion
            }
        }

        public void ForceSave() {
            switch (Program.UseIni) {
                case true:
                    Ini.Write("detectFiletype", detectFiletype, ConfigName);
                    detectFiletype_First = detectFiletype;

                    Ini.Write("clearOutput", clearOutput, ConfigName);
                    clearOutput_First = clearOutput;

                    Ini.Write("clearInput", clearInput, ConfigName);
                    clearInput_First = clearInput;

                    Ini.Write("videoBitrate", videoBitrate, ConfigName);
                    videoBitrate_First = videoBitrate;

                    Ini.Write("videoPreset", videoPreset, ConfigName);
                    videoPreset_First = videoPreset;

                    Ini.Write("videoProfile", videoProfile, ConfigName);
                    videoProfile_First = videoProfile;

                    Ini.Write("videoCRF", videoCRF, ConfigName);
                    videoCRF_First = videoCRF;

                    Ini.Write("videoFastStart", videoFastStart, ConfigName);
                    videoFastStart_First = videoFastStart;

                    Ini.Write("hideFFmpegCompile", hideFFmpegCompile, ConfigName);
                    hideFFmpegCompile_First = hideFFmpegCompile;

                    Ini.Write("audioBitrate", audioBitrate, ConfigName);
                    audioBitrate_First = audioBitrate;

                    Ini.Write("videoUseBitrate", videoUseBitrate, ConfigName);
                    videoUseBitrate_First = videoUseBitrate;

                    Ini.Write("videoUsePreset", videoUsePreset, ConfigName);
                    videoUsePreset_First = videoUsePreset;

                    Ini.Write("videoUseProfile", videoUseProfile, ConfigName);
                    videoUseProfile_First = videoUseProfile;

                    Ini.Write("videoUseCRF", videoUseCRF, ConfigName);
                    videoUseCRF_First = videoUseCRF;

                    Ini.Write("audioUseBitrate", audioUseBitrate, ConfigName);
                    audioUseBitrate_First = audioUseBitrate;

                    Ini.Write("CloseAfterFinish", CloseAfterFinish, ConfigName);
                    CloseAfterFinish_First = CloseAfterFinish;

                    break;

                case false:
                    Configurations.Converts.Default.detectFiletype = detectFiletype;
                    Configurations.Converts.Default.clearOutput = clearOutput;
                    Configurations.Converts.Default.clearInput = clearInput;
                    Configurations.Converts.Default.videoBitrate = videoBitrate;
                    Configurations.Converts.Default.videoPreset = videoPreset;
                    Configurations.Converts.Default.videoProfile = videoProfile;
                    Configurations.Converts.Default.videoCRF = videoCRF;
                    Configurations.Converts.Default.videoFastStart = videoFastStart;
                    Configurations.Converts.Default.hideFFmpegCompile = hideFFmpegCompile;
                    Configurations.Converts.Default.audioBitrate = audioBitrate;
                    Configurations.Converts.Default.videoUseBitrate = videoUseBitrate;
                    Configurations.Converts.Default.videoUsePreset = videoUsePreset;
                    Configurations.Converts.Default.videoUseProfile = videoUseProfile;
                    Configurations.Converts.Default.videoUseCRF = videoUseCRF;
                    Configurations.Converts.Default.audioUseBitrate = audioUseBitrate;
                    Configurations.Converts.Default.CloseAfterFinish = CloseAfterFinish;
                    Configurations.Converts.Default.Save();
                    break;
            }
        }
    }

    class Config_Downloads {
        private const string ConfigName = "Downloads";

        #region Variables
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
        public int YtdlType = 0;

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
        private int YtdlType_First = 0;
        #endregion

        public Config_Downloads() { }

        public void Load() {
            switch (Program.UseIni) {
                case true:
                    switch (Ini.KeyExists("downloadPath", ConfigName)) {
                        case true:
                            downloadPath = Ini.ReadString("downloadPath", ConfigName);
                            downloadPath_First = downloadPath;
                            break;
                    }
                    switch (Ini.KeyExists("separateDownloads", ConfigName)) {
                        case true:
                            separateDownloads = Ini.ReadBool("separateDownloads", ConfigName);
                            separateDownloads_First = separateDownloads;
                            break;
                    }
                    switch (Ini.KeyExists("SaveFormatQuality", ConfigName)) {
                        case true:
                            SaveFormatQuality = Ini.ReadBool("SaveFormatQuality", ConfigName);
                            SaveFormatQuality_First = SaveFormatQuality;
                            break;
                    }
                    switch (Ini.KeyExists("deleteYtdlOnClose", ConfigName)) {
                        case true:
                            deleteYtdlOnClose = Ini.ReadBool("deleteYtdlOnClose", ConfigName);
                            deleteYtdlOnClose_First = deleteYtdlOnClose;
                            break;
                    }
                    switch (Ini.KeyExists("useYtdlUpdater", ConfigName)) {
                        case true:
                            useYtdlUpdater = Ini.ReadBool("useYtdlUpdater", ConfigName);
                            useYtdlUpdater_First = useYtdlUpdater;
                            break;
                    }
                    switch (Ini.KeyExists("fileNameSchema", ConfigName)) {
                        case true:
                            fileNameSchema = Ini.ReadString("fileNameSchema", ConfigName);
                            fileNameSchema_First = fileNameSchema;
                            break;
                    }
                    switch (Ini.KeyExists("fixReddit", ConfigName)) {
                        case true:
                            fixReddit = Ini.ReadBool("fixReddit", ConfigName);
                            fixReddit_First = fixReddit;
                            break;
                    }
                    switch (Ini.KeyExists("separateIntoWebsiteURL", ConfigName)) {
                        case true:
                            separateIntoWebsiteURL = Ini.ReadBool("separateIntoWebsiteURL", ConfigName);
                            separateIntoWebsiteURL_First = separateIntoWebsiteURL;
                            break;
                    }
                    switch (Ini.KeyExists("SaveSubtitles", ConfigName)) {
                        case true:
                            SaveSubtitles = Ini.ReadBool("SaveSubtitles", ConfigName);
                            SaveSubtitles_First = SaveSubtitles;
                            break;
                    }
                    switch (Ini.KeyExists("subtitlesLanguages", ConfigName)) {
                        case true:
                            subtitlesLanguages = Ini.ReadString("subtitlesLanguages", ConfigName);
                            subtitlesLanguages_First = subtitlesLanguages;
                            break;
                    }
                    switch (Ini.KeyExists("CloseDownloaderAfterFinish", ConfigName)) {
                        case true:
                            CloseDownloaderAfterFinish = Ini.ReadBool("CloseDownloaderAfterFinish", ConfigName);
                            CloseDownloaderAfterFinish_First = CloseDownloaderAfterFinish;
                            break;
                    }
                    switch (Ini.KeyExists("UseProxy", ConfigName)) {
                        case true:
                            UseProxy = Ini.ReadBool("UseProxy", ConfigName);
                            UseProxy_First = UseProxy;
                            break;
                    }
                    switch (Ini.KeyExists("ProxyType", ConfigName)) {
                        case true:
                            ProxyType = Ini.ReadInt("ProxyType", ConfigName);
                            ProxyType_First = ProxyType;
                            break;
                    }
                    switch (Ini.KeyExists("ProxyIP", ConfigName)) {
                        case true:
                            ProxyIP = Ini.ReadString("ProxyIP", ConfigName);
                            ProxyIP_First = ProxyIP;
                            break;
                    }
                    switch (Ini.KeyExists("ProxyPort", ConfigName)) {
                        case true:
                            ProxyPort = Ini.ReadString("ProxyPort", ConfigName);
                            ProxyPort_First = ProxyPort;
                            break;
                    }
                    switch (Ini.KeyExists("SaveThumbnail", ConfigName)) {
                        case true:
                            SaveThumbnail = Ini.ReadBool("SaveThumbnail", ConfigName);
                            SaveThumbnail_First = SaveThumbnail;
                            break;
                    }
                    switch (Ini.KeyExists("SaveDescription", ConfigName)) {
                        case true:
                            SaveDescription = Ini.ReadBool("SaveDescription", ConfigName);
                            SaveDescription_First = SaveDescription;
                            break;
                    }
                    switch (Ini.KeyExists("SaveVideoInfo", ConfigName)) {
                        case true:
                            SaveVideoInfo = Ini.ReadBool("SaveVideoInfo", ConfigName);
                            SaveVideoInfo_First = SaveVideoInfo;
                            break;
                    }
                    switch (Ini.KeyExists("SaveAnnotations", ConfigName)) {
                        case true:
                            SaveAnnotations = Ini.ReadBool("SaveAnnotations", ConfigName);
                            SaveAnnotations_First = SaveAnnotations;
                            break;
                    }
                    switch (Ini.KeyExists("SubtitleFormat", ConfigName)) {
                        case true:
                            SubtitleFormat = Ini.ReadString("SubtitleFormat", ConfigName);
                            SubtitleFormat_First = SubtitleFormat;
                            break;
                    }
                    switch (Ini.KeyExists("DownloadLimit", ConfigName)) {
                        case true:
                            DownloadLimit = Ini.ReadInt("DownloadLimit", ConfigName);
                            DownloadLimit_First = DownloadLimit;
                            break;
                    }
                    switch (Ini.KeyExists("RetryAttempts", ConfigName)) {
                        case true:
                            RetryAttempts = Ini.ReadInt("RetryAttempts", ConfigName);
                            RetryAttempts_First = RetryAttempts;
                            break;
                    }
                    switch (Ini.KeyExists("DownloadLimitType", ConfigName)) {
                        case true:
                            DownloadLimitType = Ini.ReadInt("DownloadLimitType", ConfigName);
                            DownloadLimitType_First = DownloadLimitType;
                            break;
                    }
                    switch (Ini.KeyExists("ForceIPv4", ConfigName)) {
                        case true:
                            ForceIPv4 = Ini.ReadBool("ForceIPv4", ConfigName);
                            ForceIPv4_First = ForceIPv4;
                            break;
                    }
                    switch (Ini.KeyExists("ForceIPv6", ConfigName)) {
                        case true:
                            ForceIPv6 = Ini.ReadBool("ForceIPv6", ConfigName);
                            ForceIPv6_First = ForceIPv6;
                            break;
                    }
                    switch (Ini.KeyExists("LimitDownloads", ConfigName)) {
                        case true:
                            LimitDownloads = Ini.ReadBool("LimitDownloads", ConfigName);
                            LimitDownloads_First = LimitDownloads;
                            break;
                    }
                    switch (Ini.KeyExists("EmbedSubtitles", ConfigName)) {
                        case true:
                            EmbedSubtitles = Ini.ReadBool("EmbedSubtitles", ConfigName);
                            EmbedSubtitles_First = EmbedSubtitles;
                            break;
                    }
                    switch (Ini.KeyExists("EmbedThumbnails", ConfigName)) {
                        case true:
                            EmbedThumbnails = Ini.ReadBool("EmbedThumbnails", ConfigName);
                            EmbedThumbnails_First = EmbedThumbnails;
                            break;
                    }
                    switch (Ini.KeyExists("VideoDownloadSound", ConfigName)) {
                        case true:
                            VideoDownloadSound = Ini.ReadBool("VideoDownloadSound", ConfigName);
                            VideoDownloadSound_First = VideoDownloadSound;
                            break;
                    }
                    switch (Ini.KeyExists("AudioDownloadAsVBR", ConfigName)) {
                        case true:
                            AudioDownloadAsVBR = Ini.ReadBool("AudioDownloadAsVBR", ConfigName);
                            AudioDownloadAsVBR_First = AudioDownloadAsVBR;
                            break;
                    }
                    switch (Ini.KeyExists("KeepOriginalFiles", ConfigName)) {
                        case true:
                            KeepOriginalFiles = Ini.ReadBool("KeepOriginalFiles", ConfigName);
                            KeepOriginalFiles_First = KeepOriginalFiles;
                            break;
                    }
                    switch (Ini.KeyExists("WriteMetadata", ConfigName)) {
                        case true:
                            WriteMetadata = Ini.ReadBool("WriteMetadata", ConfigName);
                            WriteMetadata_First = WriteMetadata;
                            break;
                    }
                    switch (Ini.KeyExists("SkipBatchTip", ConfigName)) {
                        case true:
                            SkipBatchTip = Ini.ReadBool("SkipBatchTip", ConfigName);
                            SkipBatchTip_First = SkipBatchTip;
                            break;
                    }
                    switch (Ini.KeyExists("AutomaticallyDownloadFromProtocol", ConfigName)) {
                        case true:
                            AutomaticallyDownloadFromProtocol = Ini.ReadBool("AutomaticallyDownloadFromProtocol", ConfigName);
                            AutomaticallyDownloadFromProtocol_First = AutomaticallyDownloadFromProtocol;
                            break;
                    }
                    switch (Ini.KeyExists("PreferFFmpeg", ConfigName)) {
                        case true:
                            PreferFFmpeg = Ini.ReadBool("PreferFFmpeg", ConfigName);
                            PreferFFmpeg_First = PreferFFmpeg;
                            break;
                    }
                    switch (Ini.KeyExists("SeparateBatchDownloads", ConfigName)) {
                        case true:
                            SeparateBatchDownloads = Ini.ReadBool("SeparateBatchDownloads", ConfigName);
                            SeparateBatchDownloads_First = SeparateBatchDownloads;
                            break;
                    }
                    switch (Ini.KeyExists("AddDateToBatchDownloadFolders", ConfigName)) {
                        case true:
                            AddDateToBatchDownloadFolders = Ini.ReadBool("AddDateToBatchDownloadFolders", ConfigName);
                            AddDateToBatchDownloadFolders_First = AddDateToBatchDownloadFolders;
                            break;
                    }
                    switch (Ini.KeyExists("YtdlType", ConfigName)) {
                        case true:
                            YtdlType = Ini.ReadInt("YtdlType", ConfigName);
                            switch (YtdlType) {
                                case 1: case 2:
                                    break;

                                default:
                                    YtdlType = 0;
                                    break;
                            }
                            YtdlType_First = YtdlType;
                            break;
                    }

                    break;

                case false:
                    downloadPath = Configurations.Downloads.Default.downloadPath;
                    separateDownloads = Configurations.Downloads.Default.separateDownloads;
                    SaveFormatQuality = Configurations.Downloads.Default.SaveFormatQuality;
                    deleteYtdlOnClose = Configurations.Downloads.Default.deleteYtdlOnClose;
                    useYtdlUpdater = Configurations.Downloads.Default.useYtdlUpdater;
                    fileNameSchema = Configurations.Downloads.Default.fileNameSchema;
                    fixReddit = Configurations.Downloads.Default.fixReddit;
                    separateIntoWebsiteURL = Configurations.Downloads.Default.separateIntoWebsiteURL;
                    SaveSubtitles = Configurations.Downloads.Default.SaveSubtitles;
                    subtitlesLanguages = Configurations.Downloads.Default.subtitlesLanguages;
                    CloseDownloaderAfterFinish = Configurations.Downloads.Default.CloseDownloaderAfterFinish;
                    UseProxy = Configurations.Downloads.Default.UseProxy;
                    ProxyType = Configurations.Downloads.Default.ProxyType;
                    ProxyIP = Configurations.Downloads.Default.ProxyIP;
                    ProxyPort = Configurations.Downloads.Default.ProxyPort;
                    SaveThumbnail = Configurations.Downloads.Default.SaveThumbnail;
                    SaveDescription = Configurations.Downloads.Default.SaveDescription;
                    SaveVideoInfo = Configurations.Downloads.Default.SaveVideoInfo;
                    SaveAnnotations = Configurations.Downloads.Default.SaveAnnotations;
                    SubtitleFormat = Configurations.Downloads.Default.SubtitleFormat;
                    DownloadLimit = Configurations.Downloads.Default.DownloadLimit;
                    RetryAttempts = Configurations.Downloads.Default.RetryAttempts;
                    DownloadLimitType = Configurations.Downloads.Default.DownloadLimitType;
                    ForceIPv4 = Configurations.Downloads.Default.ForceIPv4;
                    ForceIPv6 = Configurations.Downloads.Default.ForceIPv6;
                    LimitDownloads = Configurations.Downloads.Default.LimitDownloads;
                    EmbedSubtitles = Configurations.Downloads.Default.EmbedSubtitles;
                    EmbedThumbnails = Configurations.Downloads.Default.EmbedThumbnails;
                    VideoDownloadSound = Configurations.Downloads.Default.VideoDownloadSound;
                    AudioDownloadAsVBR = Configurations.Downloads.Default.AudioDownloadAsVBR;
                    KeepOriginalFiles = Configurations.Downloads.Default.KeepOriginalFiles;
                    WriteMetadata = Configurations.Downloads.Default.WriteMetadata;
                    SkipBatchTip = Configurations.Downloads.Default.SkipBatchTip;
                    AutomaticallyDownloadFromProtocol = Configurations.Downloads.Default.AutomaticallyDownloadFromProtocol;
                    PreferFFmpeg = Configurations.Downloads.Default.PreferFFmpeg;
                    SeparateBatchDownloads = Configurations.Downloads.Default.SeparateBatchDownloads;
                    AddDateToBatchDownloadFolders = Configurations.Downloads.Default.AddDateToBatchDownloadFolders;
                    YtdlType = Configurations.Downloads.Default.YtdlType;

                    switch (YtdlType) {
                        case 0: case 1: case 2:
                            break;

                        default:
                            YtdlType = 0;
                            break;
                    }

                    break;
            }
        }
        public void Save() {
            switch (Program.UseIni) {
                case true:
                    switch (downloadPath != downloadPath_First) {
                        case true:
                            Ini.Write("downloadPath", downloadPath, ConfigName);
                            downloadPath_First = downloadPath;
                            break;
                    }
                    switch (separateDownloads != separateDownloads_First) {
                        case true:
                            Ini.Write("separateDownloads", separateDownloads, ConfigName);
                            separateDownloads_First = separateDownloads;
                            break;
                    }
                    switch (SaveFormatQuality != SaveFormatQuality_First) {
                        case true:
                            Ini.Write("SaveFormatQuality", SaveFormatQuality, ConfigName);
                            SaveFormatQuality_First = SaveFormatQuality;
                            break;
                    }
                    switch (deleteYtdlOnClose != deleteYtdlOnClose_First) {
                        case true:
                            Ini.Write("deleteYtdlOnClose", deleteYtdlOnClose, ConfigName);
                            deleteYtdlOnClose_First = deleteYtdlOnClose;
                            break;
                    }
                    switch (useYtdlUpdater != useYtdlUpdater_First) {
                        case true:
                            Ini.Write("useYtdlUpdater", useYtdlUpdater, ConfigName);
                            useYtdlUpdater_First = useYtdlUpdater;
                            break;
                    }
                    switch (fileNameSchema != fileNameSchema_First) {
                        case true:
                            Ini.Write("fileNameSchema", fileNameSchema, ConfigName);
                            fileNameSchema_First = fileNameSchema;
                            break;
                    }
                    switch (fixReddit != fixReddit_First) {
                        case true:
                            Ini.Write("fixReddit", fixReddit, ConfigName);
                            fixReddit_First = fixReddit;
                            break;
                    }
                    switch (separateIntoWebsiteURL != separateIntoWebsiteURL_First) {
                        case true:
                            Ini.Write("separateIntoWebsiteURL", separateIntoWebsiteURL, ConfigName);
                            separateIntoWebsiteURL_First = separateIntoWebsiteURL;
                            break;
                    }
                    switch (SaveSubtitles != SaveSubtitles_First) {
                        case true:
                            Ini.Write("SaveSubtitles", SaveSubtitles, ConfigName);
                            SaveSubtitles_First = SaveSubtitles;
                            break;
                    }
                    switch (subtitlesLanguages != subtitlesLanguages_First) {
                        case true:
                            Ini.Write("subtitlesLanguages", subtitlesLanguages, ConfigName);
                            subtitlesLanguages_First = subtitlesLanguages;
                            break;
                    }
                    switch (CloseDownloaderAfterFinish != CloseDownloaderAfterFinish_First) {
                        case true:
                            Ini.Write("CloseDownloaderAfterFinish", CloseDownloaderAfterFinish, ConfigName);
                            CloseDownloaderAfterFinish_First = CloseDownloaderAfterFinish;
                            break;
                    }
                    switch (UseProxy != UseProxy_First) {
                        case true:
                            Ini.Write("UseProxy", UseProxy, ConfigName);
                            UseProxy_First = UseProxy;
                            break;
                    }
                    switch (ProxyType != ProxyType_First) {
                        case true:
                            Ini.Write("ProxyType", ProxyType, ConfigName);
                            ProxyType_First = ProxyType;
                            break;
                    }
                    switch (ProxyIP != ProxyIP_First) {
                        case true:
                            Ini.Write("ProxyIP", ProxyIP, ConfigName);
                            ProxyIP_First = ProxyIP;
                            break;
                    }
                    switch (ProxyPort != ProxyPort_First) {
                        case true:
                            Ini.Write("ProxyPort", ProxyPort, ConfigName);
                            ProxyPort_First = ProxyPort;
                            break;
                    }
                    switch (SaveThumbnail != SaveThumbnail_First) {
                        case true:
                            Ini.Write("SaveThumbnail", SaveThumbnail, ConfigName);
                            SaveThumbnail_First = SaveThumbnail;
                            break;
                    }
                    switch (SaveDescription != SaveDescription_First) {
                        case true:
                            Ini.Write("SaveDescription", SaveDescription, ConfigName);
                            SaveDescription_First = SaveDescription;
                            break;
                    }
                    switch (SaveVideoInfo != SaveVideoInfo_First) {
                        case true:
                            Ini.Write("SaveVideoInfo", SaveVideoInfo, ConfigName);
                            SaveVideoInfo_First = SaveVideoInfo;
                            break;
                    }
                    switch (SaveAnnotations != SaveAnnotations_First) {
                        case true:
                            Ini.Write("SaveAnnotations", SaveAnnotations, ConfigName);
                            SaveAnnotations_First = SaveAnnotations;
                            break;
                    }
                    switch (SubtitleFormat != SubtitleFormat_First) {
                        case true:
                            Ini.Write("SubtitleFormat", SubtitleFormat, ConfigName);
                            SubtitleFormat_First = SubtitleFormat;
                            break;
                    }
                    switch (DownloadLimit != DownloadLimit_First) {
                        case true:
                            Ini.Write("DownloadLimit", DownloadLimit, ConfigName);
                            DownloadLimit_First = DownloadLimit;
                            break;
                    }
                    switch (RetryAttempts != RetryAttempts_First) {
                        case true:
                            Ini.Write("RetryAttempts", RetryAttempts, ConfigName);
                            RetryAttempts_First = RetryAttempts;
                            break;
                    }
                    switch (DownloadLimitType != DownloadLimitType_First) {
                        case true:
                            Ini.Write("DownloadLimitType", DownloadLimitType, ConfigName);
                            DownloadLimitType_First = DownloadLimitType;
                            break;
                    }
                    switch (ForceIPv4 != ForceIPv4_First) {
                        case true:
                            Ini.Write("ForceIPv4", ForceIPv4, ConfigName);
                            ForceIPv4_First = ForceIPv4;
                            break;
                    }
                    switch (ForceIPv6 != ForceIPv6_First) {
                        case true:
                            Ini.Write("ForceIPv6", ForceIPv6, ConfigName);
                            ForceIPv6_First = ForceIPv6;
                            break;
                    }
                    switch (LimitDownloads != LimitDownloads_First) {
                        case true:
                            Ini.Write("LimitDownloads", LimitDownloads, ConfigName);
                            LimitDownloads_First = LimitDownloads;
                            break;
                    }
                    switch (EmbedSubtitles != EmbedSubtitles_First) {
                        case true:
                            Ini.Write("EmbedSubtitles", EmbedSubtitles, ConfigName);
                            EmbedSubtitles_First = EmbedSubtitles;
                            break;
                    }
                    switch (EmbedThumbnails != EmbedThumbnails_First) {
                        case true:
                            Ini.Write("EmbedThumbnails", EmbedThumbnails, ConfigName);
                            EmbedThumbnails_First = EmbedThumbnails;
                            break;
                    }
                    switch (VideoDownloadSound != VideoDownloadSound_First) {
                        case true:
                            Ini.Write("VideoDownloadSound", VideoDownloadSound, ConfigName);
                            VideoDownloadSound_First = VideoDownloadSound;
                            break;
                    }
                    switch (AudioDownloadAsVBR != AudioDownloadAsVBR_First) {
                        case true:
                            Ini.Write("AudioDownloadAsVBR", AudioDownloadAsVBR, ConfigName);
                            AudioDownloadAsVBR_First = AudioDownloadAsVBR;
                            break;
                    }
                    switch (KeepOriginalFiles != KeepOriginalFiles_First) {
                        case true:
                            Ini.Write("KeepOriginalFiles", KeepOriginalFiles, ConfigName);
                            KeepOriginalFiles_First = KeepOriginalFiles;
                            break;
                    }
                    switch (WriteMetadata != WriteMetadata_First) {
                        case true:
                            Ini.Write("WriteMetadata", WriteMetadata, ConfigName);
                            WriteMetadata_First = WriteMetadata;
                            break;
                    }
                    switch (SkipBatchTip != SkipBatchTip_First) {
                        case true:
                            Ini.Write("SkipBatchTip", SkipBatchTip, ConfigName);
                            SkipBatchTip_First = SkipBatchTip;
                            break;
                    }
                    switch (AutomaticallyDownloadFromProtocol != AutomaticallyDownloadFromProtocol_First) {
                        case true:
                            Ini.Write("AutomaticallyDownloadFromProtocol", AutomaticallyDownloadFromProtocol, ConfigName);
                            AutomaticallyDownloadFromProtocol_First = AutomaticallyDownloadFromProtocol;
                            break;
                    }
                    switch (PreferFFmpeg != PreferFFmpeg_First) {
                        case true:
                            Ini.Write("PreferFFmpeg", PreferFFmpeg, ConfigName);
                            PreferFFmpeg_First = PreferFFmpeg;
                            break;
                    }
                    switch (SeparateBatchDownloads != SeparateBatchDownloads_First) {
                        case true:
                            Ini.Write("SeparateBatchDownloads", SeparateBatchDownloads, ConfigName);
                            SeparateBatchDownloads_First = SeparateBatchDownloads;
                            break;
                    }
                    switch (AddDateToBatchDownloadFolders != AddDateToBatchDownloadFolders_First) {
                        case true:
                            Ini.Write("AddDateToBatchDownloadFolders", AddDateToBatchDownloadFolders, ConfigName);
                            AddDateToBatchDownloadFolders_First = AddDateToBatchDownloadFolders;
                            break;
                    }

                    switch (YtdlType != YtdlType_First) {
                        case true:
                            Ini.Write("YtdlType", YtdlType, ConfigName);
                            YtdlType_First = YtdlType;
                            break;
                    }
                    break;

                case false:
                    bool Save = false;

                    if (Configurations.Downloads.Default.downloadPath != downloadPath) {
                        Configurations.Downloads.Default.downloadPath = downloadPath;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.separateDownloads != separateDownloads) {
                        Configurations.Downloads.Default.separateDownloads = separateDownloads;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.SaveFormatQuality != SaveFormatQuality) {
                        Configurations.Downloads.Default.SaveFormatQuality = SaveFormatQuality;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.deleteYtdlOnClose != deleteYtdlOnClose) {
                        Configurations.Downloads.Default.deleteYtdlOnClose = deleteYtdlOnClose;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.useYtdlUpdater != useYtdlUpdater) {
                        Configurations.Downloads.Default.useYtdlUpdater = useYtdlUpdater;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.fileNameSchema != fileNameSchema) {
                        Configurations.Downloads.Default.fileNameSchema = fileNameSchema;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.fixReddit != fixReddit) {
                        Configurations.Downloads.Default.fixReddit = fixReddit;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.separateIntoWebsiteURL != separateIntoWebsiteURL) {
                        Configurations.Downloads.Default.separateIntoWebsiteURL = separateIntoWebsiteURL;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.SaveSubtitles != SaveSubtitles) {
                        Configurations.Downloads.Default.SaveSubtitles = SaveSubtitles;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.subtitlesLanguages != subtitlesLanguages) {
                        Configurations.Downloads.Default.subtitlesLanguages = subtitlesLanguages;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.CloseDownloaderAfterFinish != CloseDownloaderAfterFinish) {
                        Configurations.Downloads.Default.CloseDownloaderAfterFinish = CloseDownloaderAfterFinish;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.UseProxy != UseProxy) {
                        Configurations.Downloads.Default.UseProxy = UseProxy;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.ProxyType != ProxyType) {
                        Configurations.Downloads.Default.ProxyType = ProxyType;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.ProxyIP != ProxyIP) {
                        Configurations.Downloads.Default.ProxyIP = ProxyIP;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.ProxyPort != ProxyPort) {
                        Configurations.Downloads.Default.ProxyPort = ProxyPort;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.SaveThumbnail != SaveThumbnail) {
                        Configurations.Downloads.Default.SaveThumbnail = SaveThumbnail;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.SaveDescription != SaveDescription) {
                        Configurations.Downloads.Default.SaveDescription = SaveDescription;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.SaveVideoInfo != SaveVideoInfo) {
                        Configurations.Downloads.Default.SaveVideoInfo = SaveVideoInfo;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.SaveAnnotations != SaveAnnotations) {
                        Configurations.Downloads.Default.SaveAnnotations = SaveAnnotations;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.SubtitleFormat != SubtitleFormat) {
                        Configurations.Downloads.Default.SubtitleFormat = SubtitleFormat;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.DownloadLimit != DownloadLimit) {
                        Configurations.Downloads.Default.DownloadLimit = DownloadLimit;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.RetryAttempts != RetryAttempts) {
                        Configurations.Downloads.Default.RetryAttempts = RetryAttempts;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.DownloadLimitType != DownloadLimitType) {
                        Configurations.Downloads.Default.DownloadLimitType = DownloadLimitType;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.ForceIPv4 != ForceIPv4) {
                        Configurations.Downloads.Default.ForceIPv4 = ForceIPv4;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.ForceIPv6 != ForceIPv6) {
                        Configurations.Downloads.Default.ForceIPv6 = ForceIPv6;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.LimitDownloads != LimitDownloads) {
                        Configurations.Downloads.Default.LimitDownloads = LimitDownloads;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.EmbedSubtitles != EmbedSubtitles) {
                        Configurations.Downloads.Default.EmbedSubtitles = EmbedSubtitles;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.EmbedThumbnails != EmbedThumbnails) {
                        Configurations.Downloads.Default.EmbedThumbnails = EmbedThumbnails;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.VideoDownloadSound != VideoDownloadSound) {
                        Configurations.Downloads.Default.VideoDownloadSound = VideoDownloadSound;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.AudioDownloadAsVBR != AudioDownloadAsVBR) {
                        Configurations.Downloads.Default.AudioDownloadAsVBR = AudioDownloadAsVBR;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.KeepOriginalFiles != KeepOriginalFiles) {
                        Configurations.Downloads.Default.KeepOriginalFiles = KeepOriginalFiles;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.WriteMetadata != WriteMetadata) {
                        Configurations.Downloads.Default.WriteMetadata = WriteMetadata;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.SkipBatchTip != SkipBatchTip) {
                        Configurations.Downloads.Default.SkipBatchTip = SkipBatchTip;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.AutomaticallyDownloadFromProtocol != AutomaticallyDownloadFromProtocol) {
                        Configurations.Downloads.Default.AutomaticallyDownloadFromProtocol = AutomaticallyDownloadFromProtocol;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.PreferFFmpeg != PreferFFmpeg) {
                        Configurations.Downloads.Default.PreferFFmpeg = PreferFFmpeg;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.SeparateBatchDownloads != SeparateBatchDownloads) {
                        Configurations.Downloads.Default.SeparateBatchDownloads = SeparateBatchDownloads;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.AddDateToBatchDownloadFolders != AddDateToBatchDownloadFolders) {
                        Configurations.Downloads.Default.AddDateToBatchDownloadFolders = AddDateToBatchDownloadFolders;
                        Save = true;
                    }
                    if (Configurations.Downloads.Default.YtdlType != YtdlType) {
                        Configurations.Downloads.Default.YtdlType = YtdlType;
                        Save = true;
                    }

                    switch (Save) {
                        case true:
                            Configurations.Downloads.Default.Save();
                            break;
                    }
                    break;
            }
        }

        public void ForceSave() {
            switch (Program.UseIni) {
                case true:
                    Ini.Write("downloadPath", downloadPath, ConfigName);
                    downloadPath_First = downloadPath;

                    Ini.Write("separateDownloads", separateDownloads, ConfigName);
                    separateDownloads_First = separateDownloads;

                    Ini.Write("SaveFormatQuality", SaveFormatQuality, ConfigName);
                    SaveFormatQuality_First = SaveFormatQuality;

                    Ini.Write("deleteYtdlOnClose", deleteYtdlOnClose, ConfigName);
                    deleteYtdlOnClose_First = deleteYtdlOnClose;

                    Ini.Write("useYtdlUpdater", useYtdlUpdater, ConfigName);
                    useYtdlUpdater_First = useYtdlUpdater;

                    Ini.Write("fileNameSchema", fileNameSchema, ConfigName);
                    fileNameSchema_First = fileNameSchema;

                    Ini.Write("fixReddit", fixReddit, ConfigName);
                    fixReddit_First = fixReddit;

                    Ini.Write("separateIntoWebsiteURL", separateIntoWebsiteURL, ConfigName);
                    separateIntoWebsiteURL_First = separateIntoWebsiteURL;

                    Ini.Write("SaveSubtitles", SaveSubtitles, ConfigName);
                    SaveSubtitles_First = SaveSubtitles;

                    Ini.Write("subtitlesLanguages", subtitlesLanguages, ConfigName);
                    subtitlesLanguages_First = subtitlesLanguages;

                    Ini.Write("CloseDownloaderAfterFinish", CloseDownloaderAfterFinish, ConfigName);
                    CloseDownloaderAfterFinish_First = CloseDownloaderAfterFinish;

                    Ini.Write("UseProxy", UseProxy, ConfigName);
                    UseProxy_First = UseProxy;

                    Ini.Write("ProxyType", ProxyType, ConfigName);
                    ProxyType_First = ProxyType;

                    Ini.Write("ProxyIP", ProxyIP, ConfigName);
                    ProxyIP_First = ProxyIP;

                    Ini.Write("ProxyPort", ProxyPort, ConfigName);
                    ProxyPort_First = ProxyPort;

                    Ini.Write("SaveThumbnail", SaveThumbnail, ConfigName);
                    SaveThumbnail_First = SaveThumbnail;

                    Ini.Write("SaveDescription", SaveDescription, ConfigName);
                    SaveDescription_First = SaveDescription;

                    Ini.Write("SaveVideoInfo", SaveVideoInfo, ConfigName);
                    SaveVideoInfo_First = SaveVideoInfo;

                    Ini.Write("SaveAnnotations", SaveAnnotations, ConfigName);
                    SaveAnnotations_First = SaveAnnotations;

                    Ini.Write("SubtitleFormat", SubtitleFormat, ConfigName);
                    SubtitleFormat_First = SubtitleFormat;

                    Ini.Write("DownloadLimit", DownloadLimit, ConfigName);
                    DownloadLimit_First = DownloadLimit;

                    Ini.Write("RetryAttempts", RetryAttempts, ConfigName);
                    RetryAttempts_First = RetryAttempts;

                    Ini.Write("DownloadLimitType", DownloadLimitType, ConfigName);
                    DownloadLimitType_First = DownloadLimitType;

                    Ini.Write("ForceIPv4", ForceIPv4, ConfigName);
                    ForceIPv4_First = ForceIPv4;

                    Ini.Write("ForceIPv6", ForceIPv6, ConfigName);
                    ForceIPv6_First = ForceIPv6;

                    Ini.Write("LimitDownloads", LimitDownloads, ConfigName);
                    LimitDownloads_First = LimitDownloads;

                    Ini.Write("EmbedSubtitles", EmbedSubtitles, ConfigName);
                    EmbedSubtitles_First = EmbedSubtitles;

                    Ini.Write("EmbedThumbnails", EmbedThumbnails, ConfigName);
                    EmbedThumbnails_First = EmbedThumbnails;

                    Ini.Write("VideoDownloadSound", VideoDownloadSound, ConfigName);
                    VideoDownloadSound_First = VideoDownloadSound;

                    Ini.Write("AudioDownloadAsVBR", AudioDownloadAsVBR, ConfigName);
                    AudioDownloadAsVBR_First = AudioDownloadAsVBR;

                    Ini.Write("KeepOriginalFiles", KeepOriginalFiles, ConfigName);
                    KeepOriginalFiles_First = KeepOriginalFiles;

                    Ini.Write("WriteMetadata", WriteMetadata, ConfigName);
                    WriteMetadata_First = WriteMetadata;

                    Ini.Write("SkipBatchTip", SkipBatchTip, ConfigName);
                    SkipBatchTip_First = SkipBatchTip;

                    Ini.Write("AutomaticallyDownloadFromProtocol", AutomaticallyDownloadFromProtocol, ConfigName);
                    AutomaticallyDownloadFromProtocol_First = AutomaticallyDownloadFromProtocol;

                    Ini.Write("PreferFFmpeg", PreferFFmpeg, ConfigName);
                    PreferFFmpeg_First = PreferFFmpeg;

                    Ini.Write("SeparateBatchDownloads", SeparateBatchDownloads, ConfigName);
                    SeparateBatchDownloads_First = SeparateBatchDownloads;

                    Ini.Write("AddDateToBatchDownloadFolders", AddDateToBatchDownloadFolders, ConfigName);
                    AddDateToBatchDownloadFolders_First = AddDateToBatchDownloadFolders;

                    Ini.Write("YtdlType", YtdlType, ConfigName);
                    YtdlType_First = YtdlType;
                    break;

                case false:
                    Configurations.Downloads.Default.downloadPath = downloadPath;
                    Configurations.Downloads.Default.separateDownloads = separateDownloads;
                    Configurations.Downloads.Default.SaveFormatQuality = SaveFormatQuality;
                    Configurations.Downloads.Default.deleteYtdlOnClose = deleteYtdlOnClose;
                    Configurations.Downloads.Default.useYtdlUpdater = useYtdlUpdater;
                    Configurations.Downloads.Default.fileNameSchema = fileNameSchema;
                    Configurations.Downloads.Default.fixReddit = fixReddit;
                    Configurations.Downloads.Default.separateIntoWebsiteURL = separateIntoWebsiteURL;
                    Configurations.Downloads.Default.SaveSubtitles = SaveSubtitles;
                    Configurations.Downloads.Default.subtitlesLanguages = subtitlesLanguages;
                    Configurations.Downloads.Default.CloseDownloaderAfterFinish = CloseDownloaderAfterFinish;
                    Configurations.Downloads.Default.UseProxy = UseProxy;
                    Configurations.Downloads.Default.ProxyType = ProxyType;
                    Configurations.Downloads.Default.ProxyIP = ProxyIP;
                    Configurations.Downloads.Default.ProxyPort = ProxyPort;
                    Configurations.Downloads.Default.SaveThumbnail = SaveThumbnail;
                    Configurations.Downloads.Default.SaveDescription = SaveDescription;
                    Configurations.Downloads.Default.SaveVideoInfo = SaveVideoInfo;
                    Configurations.Downloads.Default.SaveAnnotations = SaveAnnotations;
                    Configurations.Downloads.Default.SubtitleFormat = SubtitleFormat;
                    Configurations.Downloads.Default.DownloadLimit = DownloadLimit;
                    Configurations.Downloads.Default.RetryAttempts = RetryAttempts;
                    Configurations.Downloads.Default.DownloadLimitType = DownloadLimitType;
                    Configurations.Downloads.Default.ForceIPv4 = ForceIPv4;
                    Configurations.Downloads.Default.ForceIPv6 = ForceIPv6;
                    Configurations.Downloads.Default.LimitDownloads = LimitDownloads;
                    Configurations.Downloads.Default.EmbedSubtitles = EmbedSubtitles;
                    Configurations.Downloads.Default.EmbedThumbnails = EmbedThumbnails;
                    Configurations.Downloads.Default.VideoDownloadSound = VideoDownloadSound;
                    Configurations.Downloads.Default.AudioDownloadAsVBR = AudioDownloadAsVBR;
                    Configurations.Downloads.Default.KeepOriginalFiles = KeepOriginalFiles;
                    Configurations.Downloads.Default.WriteMetadata = WriteMetadata;
                    Configurations.Downloads.Default.SkipBatchTip = SkipBatchTip;
                    Configurations.Downloads.Default.AutomaticallyDownloadFromProtocol = AutomaticallyDownloadFromProtocol;
                    Configurations.Downloads.Default.PreferFFmpeg = PreferFFmpeg;
                    Configurations.Downloads.Default.SeparateBatchDownloads = SeparateBatchDownloads;
                    Configurations.Downloads.Default.AddDateToBatchDownloadFolders = AddDateToBatchDownloadFolders;
                    Configurations.Downloads.Default.YtdlType = YtdlType;

                    Configurations.Downloads.Default.Save();
                    break;
            }
        }
    }

    class Config_Errors {
        private const string ConfigName = "Errors";

        public bool detailedErrors = false;
        public bool logErrors = false;
        public bool suppressErrors = false;

        private bool detailedErrors_First = false;
        private bool logErrors_First = false;
        private bool suppressErrors_First = false;

        public Config_Errors() { }

        public void Load() {
            switch (Program.UseIni) {
                case true:
                    switch (Ini.KeyExists("detailedErrors", ConfigName)) {
                        case true:
                            detailedErrors = Ini.ReadBool("detailedErrors", ConfigName);
                            detailedErrors_First = detailedErrors;
                            break;
                    }
                    switch (Ini.KeyExists("logErrors", ConfigName)) {
                        case true:
                            logErrors = Ini.ReadBool("logErrors", ConfigName);
                            logErrors_First = logErrors;
                            break;
                    }
                    switch (Ini.KeyExists("suppressErrors", ConfigName)) {
                        case true:
                            suppressErrors = Ini.ReadBool("suppressErrors", ConfigName);
                            suppressErrors_First = suppressErrors;
                            break;
                    }

                    break;

                case false:
                    detailedErrors = Configurations.Errors.Default.detailedErrors;
                    logErrors = Configurations.Errors.Default.logErrors;
                    suppressErrors = Configurations.Errors.Default.suppressErrors;
                    break;
            }
        }
        public void Save() {
            switch (Program.UseIni) {
                case true:
                    switch (detailedErrors != detailedErrors_First) {
                        case true:
                            Ini.Write("detailedErrors", detailedErrors, ConfigName);
                            detailedErrors_First = detailedErrors;
                            break;
                    }

                    switch (logErrors != logErrors_First) {
                        case true:
                            Ini.Write("logErrors", logErrors, ConfigName);
                            logErrors_First = logErrors;
                            break;
                    }

                    switch (suppressErrors != suppressErrors_First) {
                        case true:
                            Ini.Write("suppressErrors", suppressErrors, ConfigName);
                            suppressErrors_First = suppressErrors;
                            break;
                    }

                    break;

                case false:
                    bool Save = false;

                    if (Configurations.Errors.Default.suppressErrors != suppressErrors) {
                        Configurations.Errors.Default.suppressErrors = suppressErrors;
                        Save = true;
                    }

                    if (Configurations.Errors.Default.logErrors != logErrors) {
                        Configurations.Errors.Default.logErrors = logErrors;
                        Save = true;
                    }

                    if (Configurations.Errors.Default.suppressErrors != suppressErrors) {
                        Configurations.Errors.Default.suppressErrors = suppressErrors;
                        Save = true;
                    }

                    switch (Save) {
                        case true:
                            Configurations.Errors.Default.Save();
                            break;
                    }
                    break;
            }
        }

        public void ForceSave() {
            switch (Program.UseIni) {
                case true:
                    Ini.Write("suppressErrors", suppressErrors, ConfigName);
                    suppressErrors_First = suppressErrors;

                    Ini.Write("logErrors", logErrors, ConfigName);
                    logErrors_First = logErrors;

                    Ini.Write("suppressErrors", suppressErrors, ConfigName);
                    suppressErrors_First = suppressErrors;
                    break;

                case false:
                    Configurations.Errors.Default.suppressErrors = suppressErrors;
                    Configurations.Errors.Default.logErrors = logErrors;
                    Configurations.Errors.Default.suppressErrors = suppressErrors;

                    Configurations.Errors.Default.Save();
                    break;
            }
        }
    }

    class Config_General {
        private const string ConfigName = "General";

        #region Variables
        public bool UseStaticYtdl = false;
        public string ytdlPath = string.Empty;
        public bool UseStaticFFmpeg = false;
        public string ffmpegPath = string.Empty;
        public bool CheckForUpdatesOnLaunch = false;
        public bool DownloadBetaVersions = false;
        public bool HoverOverURLTextBoxToPaste = true;
        public bool ClearURLOnDownload = false;
        public int SaveCustomArgs = 2;
        public bool ClearClipboardOnDownload = false;
        public string extensionsName = string.Empty;
        public string extensionsShort = string.Empty;
        public bool DeleteUpdaterOnStartup = true;
        public bool DeleteBackupOnStartup = false;


        private bool UseStaticYtdl_First = false;
        private string ytdlPath_First = string.Empty;
        private bool UseStaticFFmpeg_First = false;
        private string ffmpegPath_First = string.Empty;
        private bool CheckForUpdatesOnLaunch_First = false;
        private bool DownloadBetaVersions_First = false;
        private bool HoverOverURLTextBoxToPaste_First = true;
        private bool ClearURLOnDownload_First = false;
        private int SaveCustomArgs_First = 2;
        private bool ClearClipboardOnDownload_First = false;
        private string extensionsName_First = string.Empty;
        private string extensionsShort_First = string.Empty;
        private bool DeleteUpdaterOnStartup_First = true;
        private bool DeleteBackupOnStartup_First = false;
        #endregion

        public Config_General() { }

        public void Load() {
            switch (Program.UseIni) {
                case true:
                    switch (Ini.KeyExists("UseStaticYtdl", ConfigName)) {
                        case true:
                            UseStaticYtdl = Ini.ReadBool("UseStaticYtdl", ConfigName);
                            UseStaticYtdl_First = UseStaticYtdl;
                            break;
                    }
                    switch (Ini.KeyExists("ytdlPath", ConfigName)) {
                        case true:
                            ytdlPath = Ini.ReadString("ytdlPath", ConfigName);
                            ytdlPath_First = ytdlPath;
                            break;
                    }
                    switch (Ini.KeyExists("UseStaticFFmpeg", ConfigName)) {
                        case true:
                            UseStaticFFmpeg = Ini.ReadBool("UseStaticFFmpeg", ConfigName);
                            UseStaticFFmpeg_First = UseStaticFFmpeg;
                            break;
                    }
                    switch (Ini.KeyExists("ffmpegPath", ConfigName)) {
                        case true:
                            ffmpegPath = Ini.ReadString("ffmpegPath", ConfigName);
                            ffmpegPath_First = ffmpegPath;
                            break;
                    }
                    switch (Ini.KeyExists("CheckForUpdatesOnLaunch", ConfigName)) {
                        case true:
                            CheckForUpdatesOnLaunch = Ini.ReadBool("CheckForUpdatesOnLaunch", ConfigName);
                            CheckForUpdatesOnLaunch_First = CheckForUpdatesOnLaunch;
                            break;
                    }
                    switch (Ini.KeyExists("DownloadBetaVersions", ConfigName)) {
                        case true:
                            DownloadBetaVersions = Ini.ReadBool("DownloadBetaVersions", ConfigName);
                            DownloadBetaVersions_First = DownloadBetaVersions;
                            break;
                    }
                    switch (Ini.KeyExists("HoverOverURLTextBoxToPaste", ConfigName)) {
                        case true:
                            HoverOverURLTextBoxToPaste = Ini.ReadBool("HoverOverURLTextBoxToPaste", ConfigName);
                            HoverOverURLTextBoxToPaste_First = HoverOverURLTextBoxToPaste;
                            break;
                    }
                    switch (Ini.KeyExists("ClearURLOnDownload", ConfigName)) {
                        case true:
                            ClearURLOnDownload = Ini.ReadBool("ClearURLOnDownload", ConfigName);
                            ClearURLOnDownload_First = ClearURLOnDownload;
                            break;
                    }
                    switch (Ini.KeyExists("SaveCustomArgs", ConfigName)) {
                        case true:
                            SaveCustomArgs_First = SaveCustomArgs = Ini.ReadInt("SaveCustomArgs", ConfigName);
                            break;
                    }
                    switch (Ini.KeyExists("ClearClipboardOnDownload", ConfigName)) {
                        case true:
                            ClearClipboardOnDownload_First = ClearClipboardOnDownload = Ini.ReadBool("ClearClipboardOnDownload", ConfigName);
                            break;
                    }
                    switch (Ini.KeyExists("extensionsName", ConfigName)) {
                        case true:
                            extensionsName_First = extensionsName = Ini.ReadString("extensionsName", ConfigName);
                            break;
                    }

                    switch (Ini.KeyExists("extensionsShort", ConfigName)) {
                        case true:
                            extensionsShort_First = extensionsShort = Ini.ReadString("extensionsShort", ConfigName);
                            break;
                    }

                    switch (Ini.KeyExists("DeleteUpdaterOnStartup", ConfigName)) {
                        case true:
                            DeleteUpdaterOnStartup_First = DeleteUpdaterOnStartup = Ini.ReadBool("DeleteUpdaterOnStartup", ConfigName);
                            break;
                    }

                    switch (Ini.KeyExists("DeleteBackupOnStartup", ConfigName)) {
                        case true:
                            DeleteBackupOnStartup_First = DeleteBackupOnStartup = Ini.ReadBool("DeleteBackupOnStartup", ConfigName);
                            break;
                    }
                    break;

                case false:
                    UseStaticYtdl = Configurations.General.Default.UseStaticYtdl;
                    ytdlPath = Configurations.General.Default.ytdlPath;
                    UseStaticFFmpeg = Configurations.General.Default.UseStaticFFmpeg;
                    ffmpegPath = Configurations.General.Default.ffmpegPath;
                    CheckForUpdatesOnLaunch = Configurations.General.Default.CheckForUpdatesOnLaunch;
                    DownloadBetaVersions = Configurations.General.Default.DownloadBetaVersions;
                    HoverOverURLTextBoxToPaste = Configurations.General.Default.HoverOverURLTextBoxToPaste;
                    ClearURLOnDownload = Configurations.General.Default.ClearURLOnDownload;
                    SaveCustomArgs = Configurations.General.Default.SaveCustomArgs;
                    ClearClipboardOnDownload = Configurations.General.Default.ClearClipboardOnDownload;
                    extensionsName = Configurations.General.Default.extensionsName;
                    extensionsShort = Configurations.General.Default.extensionsShort;
                    DeleteUpdaterOnStartup = Configurations.General.Default.DeleteUpdaterOnStartup;
                    DeleteBackupOnStartup = Configurations.General.Default.DeleteBackupOnStartup;
                    break;
            }
        }
        public void Save() {
            switch (Program.UseIni) {
                case true:
                    switch (UseStaticYtdl != UseStaticYtdl_First) {
                        case true:
                            Ini.Write("UseStaticYtdl", UseStaticYtdl, ConfigName);
                            UseStaticYtdl_First = UseStaticYtdl;
                            break;
                    }
                    switch (ytdlPath != ytdlPath_First) {
                        case true:
                            Ini.Write("ytdlPath", ytdlPath, ConfigName);
                            ytdlPath_First = ytdlPath;
                            break;
                    }
                    switch (UseStaticFFmpeg != UseStaticFFmpeg_First) {
                        case true:
                            Ini.Write("UseStaticFFmpeg", UseStaticFFmpeg, ConfigName);
                            UseStaticFFmpeg_First = UseStaticFFmpeg;
                            break;
                    }
                    switch (ffmpegPath != ffmpegPath_First) {
                        case true:
                            Ini.Write("ffmpegPath", ffmpegPath, ConfigName);
                            ffmpegPath_First = ffmpegPath;
                            break;
                    }
                    switch (CheckForUpdatesOnLaunch != CheckForUpdatesOnLaunch_First) {
                        case true:
                            Ini.Write("CheckForUpdatesOnLaunch", CheckForUpdatesOnLaunch, ConfigName);
                            CheckForUpdatesOnLaunch_First = CheckForUpdatesOnLaunch;
                            break;
                    }
                    switch (DownloadBetaVersions != DownloadBetaVersions_First) {
                        case true:
                            Ini.Write("DownloadBetaVersions", DownloadBetaVersions, ConfigName);
                            DownloadBetaVersions_First = DownloadBetaVersions;
                            break;
                    }
                    switch (HoverOverURLTextBoxToPaste != HoverOverURLTextBoxToPaste_First) {
                        case true:
                            Ini.Write("HoverOverURLTextBoxToPaste", HoverOverURLTextBoxToPaste, ConfigName);
                            HoverOverURLTextBoxToPaste_First = HoverOverURLTextBoxToPaste;
                            break;
                    }
                    switch (ClearURLOnDownload != ClearURLOnDownload_First) {
                        case true:
                            Ini.Write("ClearURLOnDownload", ClearURLOnDownload, ConfigName);
                            ClearURLOnDownload_First = ClearURLOnDownload;
                            break;
                    }
                    switch (SaveCustomArgs != SaveCustomArgs_First) {
                        case true:
                            Ini.Write("SaveCustomArgs", SaveCustomArgs, ConfigName);
                            SaveCustomArgs_First = SaveCustomArgs;
                            break;
                    }
                    switch (ClearClipboardOnDownload != ClearClipboardOnDownload_First) {
                        case true:
                            Ini.Write("ClearClipboardOnDownload", ClearClipboardOnDownload, ConfigName);
                            ClearClipboardOnDownload_First = ClearClipboardOnDownload;
                            break;
                    }
                    switch (extensionsName != extensionsName_First) {
                        case true:
                            Ini.Write("extensionsName", extensionsName, ConfigName);
                            extensionsName_First = extensionsName;
                            break;
                    }
                    switch (extensionsShort != extensionsShort_First) {
                        case true:
                            Ini.Write("extensionsShort", extensionsShort, ConfigName);
                            extensionsShort_First = extensionsShort;
                            break;
                    }
                    switch (DeleteUpdaterOnStartup != DeleteUpdaterOnStartup_First) {
                        case true:
                            Ini.Write("DeleteUpdaterOnStartup", DeleteUpdaterOnStartup, ConfigName);
                            DeleteUpdaterOnStartup_First = DeleteUpdaterOnStartup;
                            break;
                    }
                    switch (DeleteBackupOnStartup != DeleteBackupOnStartup_First) {
                        case true:
                            Ini.Write("DeleteBackupOnStartup", DeleteBackupOnStartup, ConfigName);
                            DeleteBackupOnStartup_First = DeleteBackupOnStartup;
                            break;
                    }

                    break;

                case false:
                    bool Save = false;

                    if (Configurations.General.Default.UseStaticYtdl != UseStaticYtdl) {
                        Configurations.General.Default.UseStaticYtdl = UseStaticYtdl;
                        Save = true;
                    }

                    if (Configurations.General.Default.ytdlPath != ytdlPath) {
                        Configurations.General.Default.ytdlPath = ytdlPath;
                        Save = true;
                    }

                    if (Configurations.General.Default.UseStaticFFmpeg != UseStaticFFmpeg) {
                        Configurations.General.Default.UseStaticFFmpeg = UseStaticFFmpeg;
                        Save = true;
                    }

                    if (Configurations.General.Default.ffmpegPath != ffmpegPath) {
                        Configurations.General.Default.ffmpegPath = ffmpegPath;
                        Save = true;
                    }

                    if (Configurations.General.Default.CheckForUpdatesOnLaunch != CheckForUpdatesOnLaunch) {
                        Configurations.General.Default.CheckForUpdatesOnLaunch = CheckForUpdatesOnLaunch;
                        Save = true;
                    }

                    if (Configurations.General.Default.DownloadBetaVersions != DownloadBetaVersions) {
                        Configurations.General.Default.DownloadBetaVersions = DownloadBetaVersions;
                        Save = true;
                    }

                    if (Configurations.General.Default.HoverOverURLTextBoxToPaste != HoverOverURLTextBoxToPaste) {
                        Configurations.General.Default.HoverOverURLTextBoxToPaste = HoverOverURLTextBoxToPaste;
                        Save = true;
                    }

                    if (Configurations.General.Default.ClearURLOnDownload != ClearURLOnDownload) {
                        Configurations.General.Default.ClearURLOnDownload = ClearURLOnDownload;
                        Save = true;
                    }

                    if (Configurations.General.Default.SaveCustomArgs != SaveCustomArgs) {
                        Configurations.General.Default.SaveCustomArgs = SaveCustomArgs;
                        Save = true;
                    }

                    if (Configurations.General.Default.ClearClipboardOnDownload != ClearClipboardOnDownload) {
                        Configurations.General.Default.ClearClipboardOnDownload = ClearClipboardOnDownload;
                        Save = true;
                    }

                    if (Configurations.General.Default.extensionsName != extensionsName) {
                        Configurations.General.Default.extensionsName = extensionsName;
                        Save = true;
                    }

                    if (Configurations.General.Default.extensionsShort != extensionsShort) {
                        Configurations.General.Default.extensionsShort = extensionsShort;
                        Save = true;
                    }

                    if (Configurations.General.Default.DeleteUpdaterOnStartup != DeleteUpdaterOnStartup) {
                        Configurations.General.Default.DeleteUpdaterOnStartup = DeleteUpdaterOnStartup;
                        Save = true;
                    }

                    if (Configurations.General.Default.DeleteBackupOnStartup != DeleteBackupOnStartup) {
                        Configurations.General.Default.DeleteBackupOnStartup = DeleteBackupOnStartup;
                        Save = true;
                    }

                    switch (Save) {
                        case true:
                            Configurations.General.Default.Save();
                            break;
                    }
                    break;
            }
        }

        public void ForceSave() {
            switch (Program.UseIni) {
                case true:
                    Ini.Write("UseStaticYtdl", UseStaticYtdl, ConfigName);
                    UseStaticYtdl_First = UseStaticYtdl;

                    Ini.Write("ytdlPath", ytdlPath, ConfigName);
                    ytdlPath_First = ytdlPath;

                    Ini.Write("UseStaticFFmpeg", UseStaticFFmpeg, ConfigName);
                    UseStaticFFmpeg_First = UseStaticFFmpeg;

                    Ini.Write("ffmpegPath", ffmpegPath, ConfigName);
                    ffmpegPath_First = ffmpegPath;

                    Ini.Write("CheckForUpdatesOnLaunch", CheckForUpdatesOnLaunch, ConfigName);
                    CheckForUpdatesOnLaunch_First = CheckForUpdatesOnLaunch;

                    Ini.Write("DownloadBetaVersions", DownloadBetaVersions, ConfigName);
                    DownloadBetaVersions_First = DownloadBetaVersions;

                    Ini.Write("HoverOverURLTextBoxToPaste", HoverOverURLTextBoxToPaste, ConfigName);
                    HoverOverURLTextBoxToPaste_First = HoverOverURLTextBoxToPaste;

                    Ini.Write("ClearURLOnDownload", ClearURLOnDownload, ConfigName);
                    ClearURLOnDownload_First = ClearURLOnDownload;

                    Ini.Write("SaveCustomArgs", SaveCustomArgs, ConfigName);
                    SaveCustomArgs_First = SaveCustomArgs;

                    Ini.Write("ClearClipboardOnDownload", ClearClipboardOnDownload, ConfigName);
                    ClearClipboardOnDownload_First = ClearClipboardOnDownload;

                    Ini.Write("extensionsName", extensionsName, ConfigName);
                    extensionsName_First = extensionsName;

                    Ini.Write("extensionsShort", extensionsShort, ConfigName);
                    extensionsShort_First = extensionsShort;

                    Ini.Write("DeleteUpdaterOnStartup", DeleteUpdaterOnStartup, ConfigName);
                    DeleteUpdaterOnStartup_First = DeleteUpdaterOnStartup;

                    Ini.Write("DeleteBackupOnStartup", DeleteBackupOnStartup, ConfigName);
                    DeleteBackupOnStartup_First = DeleteBackupOnStartup;
                    break;

                case false:
                    Configurations.General.Default.UseStaticYtdl = UseStaticYtdl;
                    Configurations.General.Default.ytdlPath = ytdlPath;
                    Configurations.General.Default.UseStaticFFmpeg = UseStaticFFmpeg;
                    Configurations.General.Default.ffmpegPath = ffmpegPath;
                    Configurations.General.Default.CheckForUpdatesOnLaunch = CheckForUpdatesOnLaunch;
                    Configurations.General.Default.ClearClipboardOnDownload = DownloadBetaVersions;
                    Configurations.General.Default.HoverOverURLTextBoxToPaste = HoverOverURLTextBoxToPaste;
                    Configurations.General.Default.ClearURLOnDownload = ClearURLOnDownload;
                    Configurations.General.Default.SaveCustomArgs = SaveCustomArgs;
                    Configurations.General.Default.ClearClipboardOnDownload = ClearClipboardOnDownload;
                    Configurations.General.Default.extensionsName = extensionsName;
                    Configurations.General.Default.extensionsShort = extensionsShort;
                    Configurations.General.Default.DeleteUpdaterOnStartup = DeleteUpdaterOnStartup;
                    Configurations.General.Default.DeleteBackupOnStartup = DeleteBackupOnStartup;

                    Configurations.General.Default.Save();
                    break;
            }
        }
    }

    class Config_Saved {
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

        private int downloadType_First = 0;
        private int convertSaveVideoIndex_First = 0;
        private int convertSaveAudioIndex_First = 0;
        private int convertSaveUnknownIndex_First = 0;
        private int convertType_First = 0;
        private string convertCustom_First = string.Empty;
        private int videoQuality_First = 0;
        private int audioQuality_First = 0;
        private int VideoFormat_First = 0;
        private int AudioFormat_First = 0;
        private int AudioVBRQuality_First = 0;
        private int BatchFormX_First = -32000;
        private int BatchFormY_First = -32000;
        private Size MainFormSize_First = new(0, 0);
        private Size SettingsFormSize_First = new(0, 0);
        private string FileNameSchemaHistory_First = "%(title)s-%(id)s.%(ext)s|%(uploader)s\\(%(playlist_index)s) %(title)s-%(id)s.%(ext)s";
        private string DownloadCustomArguments_First = string.Empty;
        private int CustomArgumentsIndex_First = -1;
        private Point MainFormLocation_First = new(-32000, -32000);
        #endregion

        public Config_Saved() { }

        public void Load() {
            switch (Program.UseIni) {
                case true:
                    switch (Ini.KeyExists("downloadType", ConfigName)) {
                        case true:
                            downloadType = Ini.ReadInt("downloadType", ConfigName);
                            downloadType_First = downloadType;
                            break;
                    }
                    switch (Ini.KeyExists("convertSaveVideoIndex", ConfigName)) {
                        case true:
                            convertSaveVideoIndex = Ini.ReadInt("convertSaveVideoIndex", "Saved");
                            convertSaveVideoIndex_First = convertSaveVideoIndex;
                            break;
                    }
                    switch (Ini.KeyExists("convertSaveAudioIndex", "Saved")) {
                        case true:
                            convertSaveAudioIndex = Ini.ReadInt("convertSaveAudioIndex", "Saved");
                            convertSaveAudioIndex_First = convertSaveAudioIndex;
                            break;
                    }
                    switch (Ini.KeyExists("convertSaveUnknownIndex", ConfigName)) {
                        case true:
                            convertSaveUnknownIndex = Ini.ReadInt("convertSaveUnknownIndex", "Saved");
                            convertSaveUnknownIndex_First = convertSaveUnknownIndex;
                            break;
                    }
                    switch (Ini.KeyExists("convertType", ConfigName)) {
                        case true:
                            convertType = Ini.ReadInt("convertType", ConfigName);
                            convertType_First = convertType;
                            break;
                    }
                    switch (Ini.KeyExists("convertCustom", ConfigName)) {
                        case true:
                            convertCustom = Ini.ReadString("convertCustom", ConfigName);
                            convertCustom_First = convertCustom;
                            break;
                    }
                    switch (Ini.KeyExists("videoQuality", ConfigName)) {
                        case true:
                            videoQuality = Ini.ReadInt("videoQuality", ConfigName);
                            videoQuality_First = videoQuality;
                            break;
                    }
                    switch (Ini.KeyExists("audioQuality", ConfigName)) {
                        case true:
                            audioQuality = Ini.ReadInt("audioQuality", ConfigName);
                            audioQuality_First = audioQuality;
                            break;
                    }
                    switch (Ini.KeyExists("VideoFormat", ConfigName)) {
                        case true:
                            VideoFormat = Ini.ReadInt("VideoFormat", ConfigName);
                            VideoFormat_First = VideoFormat;
                            break;
                    }
                    switch (Ini.KeyExists("AudioFormat", ConfigName)) {
                        case true:
                            AudioFormat = Ini.ReadInt("AudioFormat", ConfigName);
                            AudioFormat_First = AudioFormat;
                            break;
                    }
                    switch (Ini.KeyExists("AudioVBRQuality", ConfigName)) {
                        case true:
                            AudioVBRQuality = Ini.ReadInt("AudioVBRQuality", ConfigName);
                            AudioVBRQuality_First = AudioVBRQuality;
                            break;
                    }
                    switch (Ini.KeyExists("BatchFormX", ConfigName)) {
                        case true:
                            BatchFormX = Ini.ReadInt("BatchFormX", ConfigName);
                            BatchFormX_First = BatchFormX;
                            break;
                    }
                    switch (Ini.KeyExists("BatchFormY", ConfigName)) {
                        case true:
                            BatchFormY = Ini.ReadInt("BatchFormY", ConfigName);
                            BatchFormY_First = BatchFormY;
                            break;
                    }
                    switch (Ini.KeyExists("MainFormSize", ConfigName)) {
                        case true:
                            MainFormSize = Ini.ReadSize("MainFormSize", ConfigName);
                            MainFormSize_First = MainFormSize;
                            break;
                    }
                    switch (Ini.KeyExists("SettingsFormSize", ConfigName)) {
                        case true:
                            SettingsFormSize = Ini.ReadSize("SettingsFormSize", ConfigName);
                            SettingsFormSize_First = SettingsFormSize;
                            break;
                    }
                    switch (Ini.KeyExists("FileNameSchemaHistory", ConfigName)) {
                        case true:
                            FileNameSchemaHistory = Ini.ReadString("FileNameSchemaHistory", ConfigName);
                            FileNameSchemaHistory_First = FileNameSchemaHistory;
                            break;
                    }
                    switch (Ini.KeyExists("DownloadCustomArguments", ConfigName)) {
                        case true:
                            DownloadCustomArguments = Ini.ReadString("DownloadCustomArguments", ConfigName);
                            DownloadCustomArguments_First = DownloadCustomArguments;
                            break;
                    }
                    switch (Ini.KeyExists("CustomArgumentsIndex", ConfigName)) {
                        case true:
                            CustomArgumentsIndex = Ini.ReadInt("CustomArgumentsIndex", ConfigName);
                            CustomArgumentsIndex_First = CustomArgumentsIndex;
                            break;
                    }
                    switch (Ini.KeyExists("MainFormLocation", ConfigName)) {
                        case true:
                            MainFormLocation = Ini.ReadPoint("MainFormLocation", ConfigName);
                            MainFormLocation_First = MainFormLocation;
                            break;
                    }

                    break;

                case false:
                    downloadType = Configurations.Saved.Default.downloadType;
                    convertSaveVideoIndex = Configurations.Saved.Default.convertSaveVideoIndex;
                    convertSaveAudioIndex = Configurations.Saved.Default.convertSaveAudioIndex;
                    convertSaveUnknownIndex = Configurations.Saved.Default.convertSaveUnknownIndex;
                    convertType = Configurations.Saved.Default.convertType;
                    convertCustom = Configurations.Saved.Default.convertCustom;
                    videoQuality = Configurations.Saved.Default.videoQuality;
                    audioQuality = Configurations.Saved.Default.audioQuality;
                    VideoFormat = Configurations.Saved.Default.VideoFormat;
                    AudioFormat = Configurations.Saved.Default.AudioFormat;
                    AudioVBRQuality = Configurations.Saved.Default.AudioVBRQuality;
                    BatchFormX = Configurations.Saved.Default.BatchFormX;
                    BatchFormY = Configurations.Saved.Default.BatchFormY;
                    MainFormSize = Configurations.Saved.Default.MainFormSize;
                    SettingsFormSize = Configurations.Saved.Default.SettingsFormSize;
                    FileNameSchemaHistory = Configurations.Saved.Default.FileNameSchemaHistory;
                    DownloadCustomArguments = Configurations.Saved.Default.DownloadCustomArguments;
                    CustomArgumentsIndex = Configurations.Saved.Default.CustomArgumentsIndex;
                    MainFormLocation = Configurations.Saved.Default.MainFormLocation;
                    break;
            }
        }
        public void Save() {
            switch (Program.UseIni) {
                case true:
                    switch (downloadType != downloadType_First) {
                        case true:
                            Ini.Write("downloadType", downloadType, ConfigName);
                            downloadType_First = downloadType;
                            break;
                    }
                    switch (convertSaveVideoIndex != convertSaveVideoIndex_First) {
                        case true:
                            Ini.Write("convertSaveVideoIndex", convertSaveVideoIndex, ConfigName);
                            convertSaveVideoIndex_First = convertSaveVideoIndex;
                            break;
                    }
                    switch (convertSaveAudioIndex != convertSaveAudioIndex_First) {
                        case true:
                            Ini.Write("convertSaveAudioIndex", convertSaveAudioIndex, ConfigName);
                            convertSaveAudioIndex_First = convertSaveAudioIndex;
                            break;
                    }
                    switch (convertSaveUnknownIndex != convertSaveUnknownIndex_First) {
                        case true:
                            Ini.Write("convertSaveUnknownIndex", convertSaveUnknownIndex, ConfigName);
                            convertSaveUnknownIndex_First = convertSaveUnknownIndex;
                            break;
                    }
                    switch (convertType != convertType_First) {
                        case true:
                            Ini.Write("convertType", convertType, ConfigName);
                            convertType_First = convertType;
                            break;
                    }
                    switch (convertCustom != convertCustom_First) {
                        case true:
                            Ini.Write("convertCustom", convertCustom, ConfigName);
                            convertCustom_First = convertCustom;
                            break;
                    }
                    switch (videoQuality != videoQuality_First) {
                        case true:
                            Ini.Write("videoQuality", videoQuality, ConfigName);
                            videoQuality_First = videoQuality;
                            break;
                    }
                    switch (audioQuality != audioQuality_First) {
                        case true:
                            Ini.Write("audioQuality", audioQuality, ConfigName);
                            audioQuality_First = audioQuality;
                            break;
                    }
                    switch (VideoFormat != VideoFormat_First) {
                        case true:
                            Ini.Write("VideoFormat", VideoFormat, ConfigName);
                            VideoFormat_First = VideoFormat;
                            break;
                    }
                    switch (AudioFormat != AudioFormat_First) {
                        case true:
                            Ini.Write("AudioFormat", AudioFormat, ConfigName);
                            AudioFormat_First = AudioFormat;
                            break;
                    }
                    switch (AudioVBRQuality != AudioVBRQuality_First) {
                        case true:
                            Ini.Write("AudioVBRQuality", AudioVBRQuality, ConfigName);
                            AudioVBRQuality_First = AudioVBRQuality;
                            break;
                    }
                    switch (BatchFormX != BatchFormX_First) {
                        case true:
                            Ini.Write("BatchFormX", BatchFormX, ConfigName);
                            BatchFormX_First = BatchFormX;
                            break;
                    }
                    switch (BatchFormY != BatchFormY_First) {
                        case true:
                            Ini.Write("BatchFormY", BatchFormY, ConfigName);
                            BatchFormY_First = BatchFormY;
                            break;
                    }
                    switch (MainFormSize != MainFormSize_First) {
                        case true:
                            Ini.Write("MainFormSize", MainFormSize, ConfigName);
                            MainFormSize_First = MainFormSize;
                            break;
                    }
                    switch (SettingsFormSize != SettingsFormSize_First) {
                        case true:
                            Ini.Write("SettingsFormSize", SettingsFormSize, ConfigName);
                            SettingsFormSize_First = SettingsFormSize;
                            break;
                    }
                    switch (FileNameSchemaHistory != FileNameSchemaHistory_First) {
                        case true:
                            Ini.Write("FileNameSchemaHistory", FileNameSchemaHistory, ConfigName);
                            FileNameSchemaHistory_First = FileNameSchemaHistory;
                            break;
                    }
                    switch (DownloadCustomArguments != DownloadCustomArguments_First) {
                        case true:
                            Ini.Write("DownloadCustomArguments", DownloadCustomArguments, ConfigName);
                            DownloadCustomArguments_First = DownloadCustomArguments;
                            break;
                    }
                    switch (CustomArgumentsIndex != CustomArgumentsIndex_First) {
                        case true:
                            Ini.Write("CustomArgumentsIndex", CustomArgumentsIndex, ConfigName);
                            CustomArgumentsIndex_First = CustomArgumentsIndex;
                            break;
                    }
                    switch (MainFormLocation != MainFormLocation_First) {
                        case true:
                            Ini.Write("MainFormLocation", MainFormLocation, ConfigName);
                            MainFormLocation_First = MainFormLocation;
                            break;
                    }

                    break;

                case false:
                    bool Save = false;

                    if (Configurations.Saved.Default.downloadType != downloadType) {
                        Configurations.Saved.Default.downloadType = downloadType;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.convertSaveVideoIndex != convertSaveVideoIndex) {
                        Configurations.Saved.Default.convertSaveVideoIndex = convertSaveVideoIndex;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.convertSaveAudioIndex != convertSaveAudioIndex) {
                        Configurations.Saved.Default.convertSaveAudioIndex = convertSaveAudioIndex;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.convertSaveUnknownIndex != convertSaveUnknownIndex) {
                        Configurations.Saved.Default.convertSaveUnknownIndex = convertSaveUnknownIndex;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.convertType != convertType) {
                        Configurations.Saved.Default.convertType = convertType;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.convertCustom != convertCustom) {
                        Configurations.Saved.Default.convertCustom = convertCustom;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.videoQuality != videoQuality) {
                        Configurations.Saved.Default.videoQuality = videoQuality;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.audioQuality != audioQuality) {
                        Configurations.Saved.Default.audioQuality = audioQuality;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.VideoFormat != VideoFormat) {
                        Configurations.Saved.Default.VideoFormat = VideoFormat;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.AudioFormat != AudioFormat) {
                        Configurations.Saved.Default.AudioFormat = AudioFormat;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.AudioVBRQuality != AudioVBRQuality) {
                        Configurations.Saved.Default.AudioVBRQuality = AudioVBRQuality;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.BatchFormX != BatchFormX) {
                        Configurations.Saved.Default.BatchFormX = BatchFormX;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.BatchFormY != BatchFormY) {
                        Configurations.Saved.Default.BatchFormY = BatchFormY;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.MainFormSize != MainFormSize) {
                        Configurations.Saved.Default.MainFormSize = MainFormSize;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.SettingsFormSize != SettingsFormSize) {
                        Configurations.Saved.Default.SettingsFormSize = SettingsFormSize;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.FileNameSchemaHistory != FileNameSchemaHistory) {
                        Configurations.Saved.Default.FileNameSchemaHistory = FileNameSchemaHistory;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.DownloadCustomArguments != DownloadCustomArguments) {
                        Configurations.Saved.Default.DownloadCustomArguments = DownloadCustomArguments;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.CustomArgumentsIndex != CustomArgumentsIndex) {
                        Configurations.Saved.Default.CustomArgumentsIndex = CustomArgumentsIndex;
                        Save = true;
                    }
                    if (Configurations.Saved.Default.MainFormLocation != MainFormLocation) {
                        Configurations.Saved.Default.MainFormLocation = MainFormLocation;
                        Save = true;
                    }

                    switch (Save) {
                        case true:
                            Configurations.Saved.Default.Save();
                            break;
                    }
                    break;
            }
        }

        public void ForceSave() {
            switch (Program.UseIni) {
                case true:
                    Ini.Write("downloadType", downloadType, ConfigName);
                    downloadType_First = downloadType;

                    Ini.Write("convertSaveVideoIndex", convertSaveVideoIndex, ConfigName);
                    convertSaveVideoIndex_First = convertSaveVideoIndex;

                    Ini.Write("convertSaveAudioIndex", convertSaveAudioIndex, ConfigName);
                    convertSaveAudioIndex_First = convertSaveAudioIndex;

                    Ini.Write("convertSaveUnknownIndex", convertSaveUnknownIndex, ConfigName);
                    convertSaveUnknownIndex_First = convertSaveUnknownIndex;

                    Ini.Write("convertType", convertType, ConfigName);
                    convertType_First = convertType;

                    Ini.Write("convertCustom", convertCustom, ConfigName);
                    convertCustom_First = convertCustom;

                    Ini.Write("videoQuality", videoQuality, ConfigName);
                    videoQuality_First = videoQuality;

                    Ini.Write("audioQuality", audioQuality, ConfigName);
                    audioQuality_First = audioQuality;

                    Ini.Write("VideoFormat", VideoFormat, ConfigName);
                    VideoFormat_First = VideoFormat;

                    Ini.Write("AudioFormat", AudioFormat, ConfigName);
                    AudioFormat_First = AudioFormat;

                    Ini.Write("AudioVBRQuality", AudioVBRQuality, ConfigName);
                    AudioVBRQuality_First = AudioVBRQuality;

                    Ini.Write("BatchFormX", BatchFormX, ConfigName);
                    BatchFormX_First = BatchFormX;

                    Ini.Write("BatchFormY", BatchFormY, ConfigName);
                    BatchFormY_First = BatchFormY;

                    Ini.Write("MainFormSize", MainFormSize, ConfigName);
                    MainFormSize_First = MainFormSize;

                    Ini.Write("SettingsFormSize", SettingsFormSize, ConfigName);
                    SettingsFormSize_First = SettingsFormSize;

                    Ini.Write("FileNameSchemaHistory", FileNameSchemaHistory, ConfigName);
                    FileNameSchemaHistory_First = FileNameSchemaHistory;

                    Ini.Write("DownloadCustomArguments", DownloadCustomArguments, ConfigName);
                    DownloadCustomArguments_First = DownloadCustomArguments;

                    Ini.Write("CustomArgumentsIndex", CustomArgumentsIndex, ConfigName);
                    CustomArgumentsIndex_First = CustomArgumentsIndex;

                    Ini.Write("MainFormLocation", MainFormLocation, ConfigName);
                    MainFormLocation_First = MainFormLocation;

                    break;

                case false:
                    Configurations.Saved.Default.downloadType = downloadType;
                    Configurations.Saved.Default.convertSaveVideoIndex = convertSaveVideoIndex;
                    Configurations.Saved.Default.convertSaveAudioIndex = convertSaveAudioIndex;
                    Configurations.Saved.Default.convertSaveUnknownIndex = convertSaveUnknownIndex;
                    Configurations.Saved.Default.convertType = convertType;
                    Configurations.Saved.Default.convertCustom = convertCustom;
                    Configurations.Saved.Default.videoQuality = videoQuality;
                    Configurations.Saved.Default.audioQuality = audioQuality;
                    Configurations.Saved.Default.VideoFormat = VideoFormat;
                    Configurations.Saved.Default.AudioFormat = AudioFormat;
                    Configurations.Saved.Default.AudioVBRQuality = AudioVBRQuality;
                    Configurations.Saved.Default.BatchFormX = BatchFormX;
                    Configurations.Saved.Default.BatchFormY = BatchFormY;
                    Configurations.Saved.Default.MainFormSize = MainFormSize;
                    Configurations.Saved.Default.SettingsFormSize = SettingsFormSize;
                    Configurations.Saved.Default.FileNameSchemaHistory = FileNameSchemaHistory;
                    Configurations.Saved.Default.DownloadCustomArguments = DownloadCustomArguments;
                    Configurations.Saved.Default.CustomArgumentsIndex = CustomArgumentsIndex;
                    Configurations.Saved.Default.MainFormLocation = MainFormLocation;

                    Configurations.Saved.Default.Save();
                    break;
            }
        }
    }

    class Ini {
        public static string Path = Environment.CurrentDirectory + "\\settings.ini";
        public static string ExecutableName = "youtube-dl-gui";

        private static string Read(string Key, string Section = null) {
            var Value = new StringBuilder(65535);
            NativeMethods.GetPrivateProfileString(Section ?? ExecutableName, Key, "", Value, 65535, Path);
            return Value.ToString();
        }
        private static void WriteString(string Key, string Value, string Section = null) {
            NativeMethods.WritePrivateProfileString(Section ?? ExecutableName, Key, Value, Path);
        }

        public static string ReadString(string Key, string Section = null) {
            return Read(Key, Section);
        }
        public static bool ReadBool(string Key, string Section = null) {
            return Read(Key, Section).ToLower() switch {
                "true" => true,
                _ => false
            };
        }
        public static int ReadInt(string Key, string Section = null) {
            return int.TryParse(Read(Key, Section), out int Value) ? Value : -1;
        }
        public static decimal ReadDecimal(string Key, string Section = null) {
            return decimal.TryParse(Read(Key, Section), out decimal Value) ? Value : -1;
        }
        public static Point ReadPoint(string Key, string Section = null) {
            string[] Value = Read(Key, Section).Split(',');
            if (Value.Length == 2 && int.TryParse(Value[0], out int OutX) && int.TryParse(Value[1], out int OutY)) {
                return new(OutX, OutY);
            }
            return new(-32000, -32000);
        }
        public static Size ReadSize(string Key, string Section = null) {
            string[] Value = Read(Key, Section).Split(',');
            if (Value.Length == 2 && int.TryParse(Value[0], out int OutW) && int.TryParse(Value[1], out int OutH)) {
                return new(OutW, OutH);
            }
            return new(-32000, -32000);
        }

        public static void Write(string Key, string Value, string Section = null) {
            WriteString(Key, Value, Section);
        }
        public static void Write(string Key, bool Value, string Section = null) {
            WriteString(Key, Value ? "True" : "False", Section);
        }
        public static void Write(string Key, int Value, string Section = null) {
            WriteString(Key, Value.ToString(), Section);
        }
        public static void Write(string Key, decimal Value, string Section = null) {
            WriteString(Key, Value.ToString(), Section);
        }
        public static void Write(string Key, Point Value, string Section = null) {
            WriteString(Key, $"{Value.X},{Value.Y}", Section);
        }
        public static void Write(string Key, Size Value, string Section = null) {
            WriteString(Key, $"{Value.Width},{Value.Height}", Section);
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

    class Protocol {
        public static bool CreateProtocol(string Protocol, string ApplicationPath, string OptionArguments) {
            try {
                Registry.ClassesRoot.CreateSubKey(Protocol);
                RegistryKey Identifier = Registry.ClassesRoot.OpenSubKey(Protocol, true);
                Identifier.SetValue("URL Protocol", "");
                Registry.ClassesRoot.CreateSubKey(Protocol + "\\shell");
                Registry.ClassesRoot.CreateSubKey(Protocol + "\\shell\\open");
                Registry.ClassesRoot.CreateSubKey(Protocol + "\\shell\\open\\command");
                RegistryKey setProtocol = Registry.ClassesRoot.OpenSubKey(Protocol + "\\shell\\open\\command", true);
                setProtocol.SetValue("", "\"" + ApplicationPath + "\" \"" + OptionArguments + " %1\"");
                Registry.ClassesRoot.CreateSubKey(Protocol + "\\DefaultIcon");
                RegistryKey setIcon = Registry.ClassesRoot.OpenSubKey(Protocol + "\\DefaultIcon", true);
                setIcon.SetValue("", "\"" + ApplicationPath + "\",1");

                return true;
            }
            catch {
                throw;
            }
        }

        public static bool ProtocolExists(string Protocol, string ExpectedValue = null) {
            try {
                RegistryKey OpenKey = Registry.ClassesRoot.OpenSubKey(Protocol);
                if (OpenKey != null && Registry.ClassesRoot.GetValue(Protocol, "URL Protocol") != null) {
                    if (ExpectedValue != null)
                        return Registry.ClassesRoot.OpenSubKey(Protocol + "\\shell\\open\\command").GetValue("").ToString().Equals(ExpectedValue);
                    else
                        return Registry.ClassesRoot.OpenSubKey(Protocol + "\\shell\\open\\command") != null;
                }
                else
                    return false;
            }
            catch {
                throw;
            }
        }
    }

}