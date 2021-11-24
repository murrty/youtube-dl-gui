using System;

public class Language {
    public string CurrentLanguageLong { get; private set; }
    public string CurrentLanguageShort { get; private set; }
    public string CurrentLanguageHint { get; private set; }
    public string CurrentLanguageVersion { get; private set; }

    public string frmUpdater { get; private set; }
    public string lbUpdaterHeader { get; private set; }
    public string lbUpdaterDescription { get; private set; }

    public string frmException { get; private set; }
    public string lbExceptionHeader { get; private set; }
    public string lbExceptionDescription { get; private set; }
    public string rtbExceptionDetails { get; private set; }
    public string btnExceptionGithub { get; private set; }
    public string btnExceptionOk { get; private set; }
    public string btnExceptionRetry { get; private set; }

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
        public static readonly string btnExceptionRetry = "Retry";
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
        btnExceptionRetry = InternalEnglish.btnExceptionRetry;
    }

    public void LoadLanguage(string LanguageFile = null) {
        if (LanguageFile == null || LanguageFile == string.Empty) {
            LoadInternalEnglish();
        }
        else {
            if (!LanguageFile.EndsWith(".ini")) { LanguageFile += ".ini"; }

            if (System.IO.File.Exists(LanguageFile)) {
                string[] ReadFile = System.IO.File.ReadAllLines(LanguageFile);

                string ReadLine = null;
                string ReadHeader = null;
                string ReadControl = null;
                string ReadValue = null;

                for (int i = 0; i < ReadFile.Length; i++) {
                    ReadLine = ReadFile[i].Trim(' ');
                    if (ReadLine.StartsWith("//") || string.IsNullOrWhiteSpace(ReadFile[i])) {
                        continue;
                    }
                    else if (ReadLine.StartsWith("[")) {
                        ReadHeader = ReadHeaderValue(ReadLine);

                        if (ReadHeader == null) {
                            throw new Exception("Unable to read the language ini header\nReadValue returned null.");
                        }
                        else {
                            CurrentLanguageLong = ReadHeader;
                            continue;
                        }
                    }
                    else if (ReadLine.Contains("=")) {
                        ReadControl = GetControlName(ReadLine).ToLower();
                        ReadValue = GetControlValue(ReadLine);
                    }
                    else {
                        continue;
                    }

                    // Set language here
                    switch (ReadControl) {
                        case "currentlanguageshort":
                            CurrentLanguageShort = ReadValue;
                            continue;
                        case "currentlanguagehint":
                            CurrentLanguageHint = ReadValue;
                            continue;
                        case "currentlanguageversion":
                            CurrentLanguageVersion = ReadValue;
                            continue;
                        case "frmupdater":
                            frmUpdater = ReadValue;
                            continue;
                        case "lbupdaterheader":
                            lbUpdaterHeader = ReadValue;
                            continue;
                        case "lbupdaterdescription":
                            lbUpdaterDescription = ReadValue;
                            continue;
                        case "frmexception":
                            frmException = ReadValue;
                            continue;
                        case "lbexceptionheader":
                            lbExceptionHeader = ReadValue;
                            continue;
                        case "lbexceptiondescription":
                            lbExceptionDescription = ReadValue;
                            continue;
                        case "rtbexceptiondetails":
                            rtbExceptionDetails = ReadValue;
                            continue;
                        case "btnexceptiongithub":
                            btnExceptionGithub = ReadValue;
                            continue;
                        case "btnexceptionok":
                            btnExceptionOk = ReadValue;
                            continue;
                        case "btnexceptionretry":
                            btnExceptionRetry = ReadValue;
                            continue;
                    }
                }
            }
            else {
                throw new Exception("LangaugeFile does not exist.");
            }
        }
    }

    /// <summary>
    /// Parses the header value from a string.
    /// </summary>
    /// <param name="Input">The string that may contain a header.</param>
    /// <returns>Returns the absolute header.</returns>
    private string ReadHeaderValue(string Input) {
        string ReadValue = null;
        int CountedLength = 0;
        ReadValue = Input.Trim(' ');
        if (Input.Contains("//")) {
            ReadValue = Input.Substring(0, Input.IndexOf("//")).Trim(' ');
        }

        if (ReadValue.Trim(' ').Trim('[').Trim(']') == null) {
            throw new Exception("Unable to read the language ini header\nReadValue returned null.\nProblematic line is \"" + Input + "\" on line " + CountedLength.ToString() + "\n\n");
        }

        return ReadValue.Trim(' ').Trim('[').Trim(']').Trim(' ');
    }
    /// <summary>
    /// Parses the control name from a string.
    /// </summary>
    /// <param name="Input">The string that may contain a control name.</param>
    /// <returns>Returns the absolute control name.</returns>
    private string GetControlName(string Input) {

        switch (Input.Split('=').Length) {
            case 1:
            case 0:
            case -1:
                return null;

            default:
                return Input.Split('=')[0].Trim(' ');
        }

        //if (Input.Split('=').Length > 1) {
        //    return Input.Split('=')[0].Trim(' ');
        //}
        //else { return null; }
    }
    /// <summary>
    /// Parses the control value from a string.
    /// </summary>
    /// <param name="Input">The string that may contain a control value.</param>
    /// <returns>Returns the absolute conntrol value.</returns>
    private string GetControlValue(string Input) {
        string OutputBuffer = null;

        switch (Input.Contains("//")) {
            case true:
                OutputBuffer = Input.Substring(0, Input.IndexOf("//")).Trim(' ');
                break;

            case false:
                OutputBuffer = Input;
                break;
        }

        return OutputBuffer.Substring(OutputBuffer.IndexOf('=') + 1);
    }
}