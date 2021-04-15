using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        public Config_Batch Batch;
        public Config_Converts Converts;
        public Config_Downloads Downloads;
        public Config_Errors Errors;
        public Config_General General;
        public Config_Saved Saved;
        public Config_Settings Settings;

        public Config() {

        }

        public void Load(ConfigType Type) {
            switch (Type) {
                case ConfigType.All:
                    break;

                case ConfigType.Initialization:
                    break;

                case ConfigType.Batch:
                    break;

                case ConfigType.Converts:
                    break;

                case ConfigType.Downloads:
                    break;

                case ConfigType.Errors:
                    break;

                case ConfigType.General:
                    break;

                case ConfigType.Saved:
                    break;

                case ConfigType.Settings:
                    break;
            }
        }

        public void Save(ConfigType Type) {
            switch (Type) {
                case ConfigType.All:
                    break;

                case ConfigType.Initialization:
                    break;

                case ConfigType.Batch:
                    break;

                case ConfigType.Converts:
                    break;

                case ConfigType.Downloads:
                    break;

                case ConfigType.Errors:
                    break;

                case ConfigType.General:
                    break;

                case ConfigType.Saved:
                    break;

                case ConfigType.Settings:
                    break;
            }
        }
    }

    class Config_Initialization {
        public Config_Initialization() {

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
            switch (Program.IsPortable) {
                case true:
                    switch (SelectedType != SelectedType_First) {
                        case true:
                            Ini.WriteInt("SelectedType", SelectedType, "Batch");
                            SelectedType_First = SelectedType;
                            break;
                    }
                    switch (SelectedVideoQuality != SelectedVideoQuality_First) {
                        case true:
                            Ini.WriteInt("SelectedVideoQuality", SelectedVideoQuality, "Batch");
                            SelectedVideoQuality_First = SelectedVideoQuality;
                            break;
                    }
                    switch (SelectedVideoFormat != SelectedVideoFormat_First) {
                        case true:
                            Ini.WriteInt("SelectedVideoFormat", SelectedVideoFormat, "Batch");
                            SelectedVideoFormat_First = SelectedVideoFormat;
                            break;
                    }
                    switch (SelectedAudioQuality != SelectedAudioQuality_First) {
                        case true:
                            Ini.WriteInt("SelectedAudioQuality", SelectedAudioQuality, "Batch");
                            SelectedAudioQuality_First = SelectedAudioQuality;
                            break;
                    }
                    switch (SelectedAudioFormat != SelectedAudioFormat_First) {
                        case true:
                            Ini.WriteInt("SelectedAudioFormat", SelectedAudioFormat, "Batch");
                            SelectedAudioFormat_First = SelectedAudioFormat;
                            break;
                    }
                    switch (DownloadVideoSound != DownloadVideoSound_First) {
                        case true:
                            Ini.WriteBool("DownloadVideoSound", DownloadVideoSound, "Batch");
                            DownloadVideoSound_First = DownloadVideoSound;
                            break;
                    }
                    switch (DownloadAudioVBR != DownloadAudioVBR_First) {
                        case true:
                            Ini.WriteBool("DownloadAudioVBR", DownloadAudioVBR, "Batch");
                            DownloadAudioVBR_First = DownloadAudioVBR;
                            break;
                    }
                    switch (SelectedAudioQualityVBR != SelectedAudioQualityVBR_First) {
                        case true:
                            Ini.WriteInt("SelectedAudioQualityVBR", SelectedAudioQualityVBR, "Batch");
                            SelectedAudioQualityVBR_First = SelectedAudioQualityVBR;
                            break;
                    }
                    switch (CustomArguments != CustomArguments_First) {
                        case true:
                            Ini.WriteString("CustomArguments", CustomArguments, "Batch");
                            CustomArguments_First = CustomArguments;
                            break;
                    }

                    break;

                case false:
                    bool Save = false;

                    if (Batch.Default.SelectedType != SelectedType) {
                        Batch.Default.SelectedType = SelectedType;
                    }
                    if (Batch.Default.SelectedVideoQuality != SelectedVideoQuality) {
                        Batch.Default.SelectedVideoQuality = SelectedVideoQuality;
                    }
                    if (Batch.Default.SelectedVideoFormat != SelectedVideoFormat) {
                        Batch.Default.SelectedVideoFormat = SelectedVideoFormat;
                    }
                    if (Batch.Default.SelectedAudioQuality != SelectedAudioQuality) {
                        Batch.Default.SelectedAudioQuality = SelectedAudioQuality;
                    }
                    if (Batch.Default.SelectedAudioFormat != SelectedAudioFormat) {
                        Batch.Default.SelectedAudioFormat = SelectedAudioFormat;
                    }
                    if (Batch.Default.DownloadVideoSound != DownloadVideoSound) {
                        Batch.Default.DownloadVideoSound = DownloadVideoSound;
                    }
                    if (Batch.Default.DownloadAudioVBR != DownloadAudioVBR) {
                        Batch.Default.DownloadAudioVBR = DownloadAudioVBR;
                    }
                    if (Batch.Default.SelectedAudioQualityVBR != SelectedAudioQualityVBR) {
                        Batch.Default.SelectedAudioQualityVBR = SelectedAudioQualityVBR;
                    }
                    if (Batch.Default.CustomArguments != CustomArguments) {
                        Batch.Default.CustomArguments = CustomArguments;
                    }

                    switch (Save) {
                        case true:
                            Batch.Default.Save();
                            break;
                    }
                    break;
            }
        }
        public void Load() {
            switch (Program.IsPortable) {
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
                    SelectedType = Batch.Default.SelectedType;
                    SelectedVideoQuality = Batch.Default.SelectedVideoQuality;
                    SelectedVideoFormat = Batch.Default.SelectedVideoFormat;
                    SelectedAudioQuality = Batch.Default.SelectedAudioQuality;
                    SelectedAudioFormat = Batch.Default.SelectedAudioFormat;
                    DownloadVideoSound = Batch.Default.DownloadVideoSound;
                    DownloadAudioVBR = Batch.Default.DownloadAudioVBR;
                    SelectedAudioQualityVBR = Batch.Default.SelectedAudioQualityVBR;
                    CustomArguments = Batch.Default.CustomArguments;
                    break;
            }
        }
    }

    class Config_Converts {
        public Config_Converts() {

        }
        //_First private
    }

    class Config_Downloads {
        public Config_Downloads() {

        }
        //_First private
    }

    class Config_Errors {
        public Config_Errors() {

        }
        //_First private
    }

    class Config_General {
        public Config_General() {

        }
        //_First private
    }

    class Config_Saved {
        public Config_Saved() {

        }
        //_First private
    }

    class Config_Settings {
        public Config_Settings() {

        }
        //_First private
    }

    class Ini {
        static string Path = Environment.CurrentDirectory + "\\settings.ini";

        public static string ReadString(string Key, string Section) {
            var RetVal = new StringBuilder(255);
            NativeMethods.GetPrivateProfileString(Section, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }
        public static bool ReadBool(string Key, string Section) {
            var RetVal = new StringBuilder(255);
            NativeMethods.GetPrivateProfileString(Section, Key.ToLower(), "", RetVal, 255, Path);
            string RetStr = RetVal.ToString().ToLower();

            if (RetStr == "true")
                return true;
            else
                return false;
        }
        public static int ReadInt(string Key, string Section) {
            var RetVal = new StringBuilder(255);
            NativeMethods.GetPrivateProfileString(Section, Key.ToLower(), "", RetVal, 255, Path);
            string RetStr = RetVal.ToString();
            int RetInt;
            int.TryParse(RetStr, out RetInt);
            return RetInt;
        }
        public static Size ReadSize(string Key, string Section) {
            var RetVal = new StringBuilder(255);
            NativeMethods.GetPrivateProfileString(Section, Key, "", RetVal, 255, Path);
            string[] Value = RetVal.ToString().Split(',');
            return new Size(int.Parse(Value[0]), int.Parse(Value[1]));
        }
        public static decimal ReadDecimal(string Key, string Section) {
            var RetVal = new StringBuilder(255);
            NativeMethods.GetPrivateProfileString(Section, Key, "", RetVal, 255, Path);
            decimal RetDec;
            decimal.TryParse(RetVal.ToString(), out RetDec);
            return RetDec;
        }

        public static void WriteString(string Key, string Value, string Section) {
            NativeMethods.WritePrivateProfileString(Section, Key, Value, Path);
        }
        public static void WriteBool(string Key, bool Value, string Section) {
            string outKey;

            if (Value)
                outKey = "True";
            else
                outKey = "False";

            NativeMethods.WritePrivateProfileString(Section, Key, outKey, Path);
        }
        public static void WriteInt(string Key, int Value, string Section) {
            string outKey = Value.ToString();

            NativeMethods.WritePrivateProfileString(Section, Key, outKey, Path);
        }
        public static void WriteDecimal(string Key, decimal Value, string Section) {
            NativeMethods.WritePrivateProfileString(Section, Key, Value.ToString(), Path);
        }
        public static void WriteSize(string Key, Size Value, string Section) {
            string outKey = Value.Width + "," + Value.Height;

            NativeMethods.WritePrivateProfileString(Section, Key, outKey, Path);
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