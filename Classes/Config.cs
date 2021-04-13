using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace youtube_dl_gui {

    //public enum ConfigType : int {
    //    None = -1,
    //    All = 0,
    //    Initialization = 1,
    //    Batch = 2,
    //    Converts = 3,
    //    Downloads = 4,
    //    Errors = 5,
    //    General = 6,
    //    Save = 7,
    //    Settings = 8
    //}

    //class Config {
    //    public Config_Batch Batch;
    //    public Config_Converts Converts;
    //    public Config_Downloads Downloads;
    //    public Config_Errors Errors;
    //    public Config_General General;
    //    public Config_Saved Saved;
    //    public Config_Settings Settings;

    //    public Config() {

    //    }

    //    public void Load(ConfigType Type) {

    //    }
    //}

    //class Config_Batch {

    //}

    //class Config_Converts {

    //}

    //class Config_Downloads {

    //}

    //class Config_Errors {

    //}

    //class Config_General {

    //}

    //class Config_Saved {

    //}

    //class Config_Settings {

    //}

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