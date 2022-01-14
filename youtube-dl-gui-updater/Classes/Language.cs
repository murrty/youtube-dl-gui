using System;
using System.IO;

namespace youtube_dl_gui_updater {
    public class Language {

        #region Get Set Radio
        public string GenericRetry { get; private set; }
        public string GenericOk { get; private set; }

        public string frmUpdater { get; private set; }
        public string lbUpdaterHeader { get; private set; }
        public string lbUpdaterDetails { get; private set; }

        public string frmException { get; private set; }
        public string lbExceptionHeader { get; private set; }
        public string lbExceptionDescription { get; private set; }
        public string btnExceptionGithub { get; private set; }
        public string rtbUpdaterExceptionDetails { get; private set; }
        #endregion

        #region Interal English
        public class InternalEnglish {
            public static readonly string GenericRetry = "Retry";
            public static readonly string GenericOk = "OK";

            public static readonly string frmException = "An exception occured";
            public static readonly string lbExceptionHeader = "An exception has occured";
            public static readonly string lbExceptionDescription = "Below is the error that occured. Feel free to open a new issue and report it.";
            public static readonly string btnExceptionGithub = "Open Github";

            public static readonly string frmUpdater = "Updating";
            public static readonly string lbUpdaterHeader = "Updating youtube-dl-gui";
            public static readonly string lbUpdaterDetails = "The previous version won't be deleted if it fails.";
            public static readonly string rtbUpdaterExceptionDetails = "Feel free to copy + paste this entire text wall into a new issue on Github. The old youtube-dl-gui will be restored, and you can attempt to redownload the update through the application, or manually from Github.";
        }

        public void LoadInternalEnglish() {
            GenericRetry = InternalEnglish.GenericRetry;
            GenericOk = InternalEnglish.GenericOk;

            frmException = InternalEnglish.frmException;
            lbExceptionHeader = InternalEnglish.lbExceptionHeader;
            lbExceptionDescription = InternalEnglish.lbExceptionDescription;
            btnExceptionGithub = InternalEnglish.btnExceptionGithub;

            frmUpdater = InternalEnglish.frmUpdater;
            lbUpdaterHeader = InternalEnglish.lbUpdaterHeader;
            lbUpdaterDetails = InternalEnglish.lbUpdaterDetails;
            rtbUpdaterExceptionDetails = InternalEnglish.rtbUpdaterExceptionDetails;
        }
        #endregion

        public bool LoadLanguage(string LanguageFile = null) {
            try {
                if (string.IsNullOrWhiteSpace(LanguageFile)) {
                    LoadInternalEnglish();
                    return true;
                }
                else {
                    if (!LanguageFile.EndsWith(".ini")) { LanguageFile += ".ini"; }

                    if (File.Exists(LanguageFile)) {
                        using StreamReader ReadLanguageFile = new(LanguageFile);
                        string ReadLine;    // The line of the file
                        while ((ReadLine = ReadLanguageFile.ReadLine()) != null) {
                            if (ReadLine.StartsWith("//") || string.IsNullOrWhiteSpace(ReadLine))
                                continue;
                            else if (ReadLine.StartsWith("[") && ReadLine.Contains("]")) {
                                ReadHeaderValue(ReadLine, out string ReadHeader);

                                if (ReadHeader == null) {
                                    throw new Exception("Unable to read the language ini header\nReadValue returned null.\nProblematic line is \"" + ReadLine + "\"\n\n");
                                }
                            }
                            else if (ReadLine.Contains("=")) {
                                GetControlInfo(ReadLine, out string ReadControl, out string ReadValue);

                                switch (ReadControl) {
                                    case "genericretry":
                                        GenericRetry = ReadValue;
                                        continue;
                                    case "genericok":
                                        GenericOk = ReadValue;
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
                                    case "btnexceptiongithub":
                                        btnExceptionGithub = ReadValue;
                                        continue;

                                    case "frmupdater":
                                        frmUpdater = ReadValue;
                                        continue;
                                    case "lbupdaterheader":
                                        lbUpdaterHeader = ReadValue;
                                        continue;
                                    case "lbupdaterdetails":
                                        lbUpdaterDetails = ReadValue;
                                        continue;
                                    case "rtbupdaterexceptiondetails":
                                        rtbUpdaterExceptionDetails = ReadValue;
                                        continue;
                                }
                            }
                        }

                    }
                    else {
                        LoadInternalEnglish();
                    }
                    return true;
                }
            }
            catch (Exception ex) {
                using murrty.frmException error = new(new(ex) {
                    FromLanguage = true
                });
                error.ShowDialog();
                return false;
            }
        }

        /// <summary>
        /// Parses the header value from a string.
        /// </summary>
        /// <param name="Input">The string that may contain a header.</param>
        /// <returns>Returns the absolute header.</returns>
        private void ReadHeaderValue(string Input, out string Header) {
            Input = Input.Contains("//") ? Input.Substring(0, Input.IndexOf("//")) : Input;
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
                case -1: case 0: {
                    Name = null;
                    Value = null;
                } return;

                default: {
                    Input = Input.Contains("//") ? Input.Substring(0, Input.IndexOf("//")) : Input;
                    Name = Input.Split('=')[0].ToLower().Trim();
                    Value = Input.Substring(Input.IndexOf('=') + 1).Trim();
                } break;
            }
        }
    }
}