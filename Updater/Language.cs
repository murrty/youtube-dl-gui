using System;

public class Language {
    private static Language LanguageInstance = new Language();
    public static Language GetLangInstance() {
        return LanguageInstance;
    }
    private static volatile string CurrentLanguageLongString = "CurrentLanguageLong";
    private static volatile string CurrentLanguageShortString = "CurrentLanguageShort";
    private static volatile string CurrentLanguageHintString = "CurrentLanguageHint";
    private static volatile string CurrentLanguageVersionString = "-1";

    private static volatile string frmUpdaterString = "frmUpdater";
    private static volatile string lbUpdaterHeaderString = "lbUpdaterHeader";
    private static volatile string lbUpdaterDescriptionString = "lbUpdaterDescription";

    private static volatile string frmExceptionString = "frmException";
    private static volatile string lbExceptionHeaderString = "lbExceptionHeader";
    private static volatile string lbExceptionDescriptionString = "lbExceptionDescription";
    private static volatile string rtbExceptionDetailsString = "rtbExceptionDetails";
    private static volatile string btnExceptionGithubString = "btnExceptionGithub";
    private static volatile string btnExceptionOkString = "btnExceptionOk";

    public string CurrentLanguageLong {
        get { return CurrentLanguageLongString; }
        private set { CurrentLanguageLongString = value; }
    }
    public string CurrentLanguageShort {
        get { return CurrentLanguageShortString; }
        private set { CurrentLanguageShortString = value; }
    }
    public string CurrentLanguageHint {
        get { return CurrentLanguageHintString; }
        private set { CurrentLanguageHintString = value; }
    }
    public string CurrentLanguageVersion {
        get { return CurrentLanguageVersionString; }
        private set { CurrentLanguageVersionString = value; }
    }

    public string frmUpdater {
        get { return frmUpdaterString; }
        private set { frmUpdaterString = value; }
    }
    public string lbUpdaterHeader {
        get { return lbUpdaterHeaderString; }
        private set { lbUpdaterHeaderString = value; }
    }
    public string lbUpdaterDescription {
        get { return lbUpdaterDescriptionString; }
        private set { lbUpdaterDescriptionString = value; }
    }

    public string frmException {
        get { return frmExceptionString; }
        private set { frmExceptionString = value; }
    }
    public string lbExceptionHeader {
        get { return lbExceptionHeaderString; }
        private set { lbExceptionHeaderString = value; }
    }
    public string lbExceptionDescription {
        get { return lbExceptionDescriptionString; }
        private set { lbExceptionDescriptionString = value; }
    }
    public string rtbExceptionDetails {
        get { return rtbExceptionDetailsString; }
        private set { rtbExceptionDetailsString = value; }
    }
    public string btnExceptionGithub {
        get { return btnExceptionGithubString; }
        private set { btnExceptionGithubString = value; }
    }
    public string btnExceptionOk {
        get { return btnExceptionOkString; }
        private set { btnExceptionOkString = value; }
    }

    public class InternalEnglish {
        public static readonly string CurrentLanguageLong = "English (Internal)";
        public static readonly string CurrentLanguageShort = "en-i";
        public static readonly string CurrentLanguageHint = "Can't change in form";
        public static readonly string CurrentLanguageVersion = "1";
        public static readonly string frmUpdater = "Updating";
        public static readonly string lbUpdaterHeader = "Updating youtube-dl-gui";
        public static readonly string lbUpdaterDescription = "The previous version won't be deleted if it fails.";
        public static readonly string frmException = "An exception occured";
        public static readonly string lbExceptionHeader = "An exception has occured";
        public static readonly string lbExceptionDescription = "Below is the error that occured. Feel free to open a new issue and report it. The old youtube-dl-gui will be restored, and you can attempt to redownload the update through the application, or manually from Github.";
        public static readonly string rtbExceptionDetails = "Feel free to copy + paste this entire text wall into a new issue on Github";
        public static readonly string btnExceptionGithub = "Open Github";
        public static readonly string btnExceptionOk = "OK";
    }

    public void LoadInternalEnglish() {
        CurrentLanguageShort = InternalEnglish.CurrentLanguageShort;
        CurrentLanguageLong = InternalEnglish.CurrentLanguageLong;
        CurrentLanguageHint = InternalEnglish.CurrentLanguageHint;
        CurrentLanguageVersion = InternalEnglish.CurrentLanguageVersion;
        frmUpdater = InternalEnglish.frmUpdater;
        lbUpdaterHeader = InternalEnglish.lbUpdaterHeader;
        lbUpdaterDescription = InternalEnglish.lbUpdaterDescription;
        frmException = InternalEnglish.frmException;
        lbExceptionHeader = InternalEnglish.lbExceptionHeader;
        lbExceptionDescription = InternalEnglish.lbExceptionDescription;
        rtbExceptionDetails = InternalEnglish.rtbExceptionDetails;
        btnExceptionGithub = InternalEnglish.btnExceptionGithub;
        btnExceptionOk = InternalEnglish.btnExceptionOk;
    }

    public void LoadLanguage(string LanguageFile = null) {
        if (LanguageFile == null || LanguageFile == string.Empty) {
            LoadInternalEnglish();
        }
        else {
            if (!LanguageFile.EndsWith(".ini")) { LanguageFile += ".ini"; }

            if (System.IO.File.Exists(LanguageFile)) {
                string[] ReadFile = System.IO.File.ReadAllLines(LanguageFile);

                for (int i = 0; i < ReadFile.Length; i++) {
                    string ReadLine = ReadFile[i];
                    string ReadControl = null;
                    string ReadValue = null;
                    string ReadHeader = null;
                    if (ReadLine.StartsWith("//")) { continue; }

                    if (ReadLine.StartsWith("[")) {
                        ReadHeader = ReadHeaderValue(ReadLine);

                        if (ReadHeader == null) {
                            throw new Exception("Unable to read the language ini header\nReadValue returned null.");
                        }
                        else {
                            CurrentLanguageLong = ReadHeader;
                            continue;
                        }
                    }
                    else {
                        if (ReadLine == null || ReadLine.Split('=').Length < 2) { continue; }
                        ReadControl = GetControlName(ReadLine).ToLower();
                        ReadValue = GetControlValue(ReadLine);
                    }

                    // Set language here
                    if (ReadControl == "currentlanguageshort") {
                        CurrentLanguageShort = ReadValue;
                        continue;
                    }
                    else if (ReadControl == "currentlanguagehint") {
                        CurrentLanguageHint = ReadValue;
                        continue;
                    }
                    else if (ReadControl == "currentlanguageversion") {
                        CurrentLanguageVersion = ReadValue;
                        continue;
                    }
                    else if (ReadControl == "frmupdater") {
                        frmUpdater = ReadValue;
                        continue;
                    }
                    else if (ReadControl == "lbupdaterheader") {
                        lbUpdaterHeader = ReadValue;
                        continue;
                    }
                    else if (ReadControl == "lbupdaterdescription") {
                        lbUpdaterDescription = ReadValue;
                        continue;
                    }
                    else if (ReadControl == "frmexception") {
                        frmException = ReadValue;
                        continue;
                    }
                    else if (ReadControl == "lbexceptionheader") {
                        lbExceptionHeader = ReadValue;
                        continue;
                    }
                    else if (ReadControl == "lbexceptiondescription") {
                        lbExceptionDescription = ReadValue;
                        continue;
                    }
                    else if (ReadControl == "rtbexceptiondetails") {
                        rtbExceptionDetails = ReadValue;
                        continue;
                    }
                    else if (ReadControl == "btnexceptiongithub") {
                        btnExceptionGithub = ReadValue;
                        continue;
                    }
                    else if (ReadControl == "btnexceptionok") {
                        btnExceptionOk = ReadValue;
                        continue;
                    }
                }
            }
            else {
                throw new Exception("LangaugeFile does not exist.");
            }
        }
    }

    private string ReadHeaderValue(string Input) {
        string ReadValue = null;
        if (Input.Contains("//")) {
            int CountedForwardSlashes = 0;
            int CountedLength = 0;
            for (int j = 0; j < Input.Length; j++) {
                CountedLength++;
                if (Input[j] == '/') {
                    CountedForwardSlashes++;
                    if (CountedForwardSlashes == 2) { break; }
                    continue;
                }
            }
            CountedLength = CountedLength - 2;
            ReadValue = Input.Substring(0, CountedLength);
        }
        return ReadValue.Trim(' ').Trim('[').Trim(']');
    }
    private string GetControlName(string Input) {
        if (Input.Split('=').Length > 1) {
            return Input.Split('=')[0].Trim(' ');
        }
        else { return null; }
    }
    private string GetControlValue(string Input) {
        if (Input.Split('=').Length > 2) {
            string OutputBuffer = null;

            if (Input.Contains("//")) {
                int CountedForwardSlashes = 0;
                int CountedLength = 0;
                for (int i = 1; i < Input.Length; i++) {
                    CountedLength++;
                    if (Input[i] == '/') {
                        CountedForwardSlashes++;
                        if (CountedForwardSlashes == 2) { break; }
                        else { continue; }
                    }
                }
                CountedLength = CountedLength - 2;
                OutputBuffer = Input.Substring(0, CountedLength).Trim(' ');
            }
            for (int i = 0; i < Input.Split('=').Length; i++) {
                OutputBuffer += Input.Split('=')[i] + "=";
            }
            if (!Input.EndsWith("=")) {
                OutputBuffer = OutputBuffer.Trim('=');
            }
            else {
                OutputBuffer = OutputBuffer.Substring(0, OutputBuffer.Length - 1);
            }
            return OutputBuffer;
        }
        else if (Input.Split('=').Length == 2) { return Input.Split('=')[1]; }
        else { return null; }
    }
}