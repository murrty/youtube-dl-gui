using System;
using System.IO;

namespace youtube_dl_gui_updater {
    public class Language {
        public string CurrentLanguageShort { get; private set; }
        public string CurrentLanguageLong { get; private set; }
        public string CurrentLanguageHint { get; private set; }
        public string CurrentLanguageVersion { get; private set; }

        public string GenericRetry { get; private set; }
        public string GenericOk { get; private set; }

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

        public bool LoadLanguage(string LanguageFile = null) {
            try {
                if (!LanguageFile.EndsWith(".ini")) { LanguageFile += ".ini"; }

                if (File.Exists(LanguageFile)) {
                    using (StreamReader ReadLanguageFile = new StreamReader(LanguageFile)) {
                        string ReadLine;    // The line of the file
                        while ((ReadLine = ReadLanguageFile.ReadLine()) != null) {
                            if (ReadLine.StartsWith("//") || string.IsNullOrWhiteSpace(ReadLine))
                                continue;
                            else if (ReadLine.StartsWith("[") && ReadLine.Contains("]")) {
                                ReadHeaderValue(ReadLine, out string ReadHeader);

                                if (ReadHeader == null) {
                                    throw new Exception("Unable to read the language ini header\nReadValue returned null.\nProblematic line is \"" + ReadLine + "\"\n\n");
                                }
                                else
                                    CurrentLanguageLong = ReadHeader;
                            }
                            else if (ReadLine.Contains("=")) {
                                GetControlInfo(ReadLine, out string ReadControl, out string ReadValue);

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
                    }
                }
                else {
                    LoadInternalEnglish();
                }
                return true;
            }
            catch (Exception ex) {
                using (frmException error = new frmException()) {
                    error.ReportedException = ex;
                    error.FromLanguage = true;
                    error.ShowDialog();
                }
                return false;
            }
        }

        /// <summary>
        /// Parses the header value from a string.
        /// </summary>
        /// <param name="Input">The string that may contain a header.</param>
        /// <returns>Returns the absolute header.</returns>
        private void ReadHeaderValue(string Input, out string Header) {
            if (Input.Contains("//"))
                Input = Input.Substring(0, Input.IndexOf("//"));
            Header = Input.Substring(1, Input.IndexOf(']') - 1);
        }
        /// <summary>
        /// Parses the control name and value from a string.
        /// </summary>
        /// <param name="Input">The string that will be parsed.</param>
        /// <param name="Name">The output of the Name of the control to be named, as lowercase.</param>
        /// <param name="Value">The vlaue of the control.</param>
        private void GetControlInfo(string Input, out string Name, out string Value) {
            switch (Input.Split('=').Length) {
                case -1:
                case 0:
                case 1:
                    Name = null;
                    Value = null;
                    return;

                default:
                    if (Input.Contains("//"))
                        Input.Substring(0, Input.IndexOf("//"));
                    Name = Input.Split('=')[0].ToLower().Trim();
                    Value = Input.Substring(Input.IndexOf('=') + 1).Trim();
                    break;
            }
        }
    }
}