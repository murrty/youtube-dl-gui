namespace youtube_dl_gui_updater;

using System;
using System.IO;

public static class Language {

    #region Get Set Radio
    public static string GenericRetry { get; private set; }
    public static string GenericOk { get; private set; }

    public static string dlgUpdaterUpdatedVersionHashNoMatch { get; private set; }
    public static string dlgUpdaterHashNotGiven { get; private set; }

    public static string frmException { get; private set; }
    public static string lbExceptionHeader { get; private set; }
    public static string lbExceptionDescription { get; private set; }
    public static string rtbExceptionDetails { get; private set; }
    public static string btnExceptionGithub { get; private set; }
    public static string tabExceptionDetails { get; private set; }
    public static string tabExceptionExtraInfo { get; private set; }

    public static string frmUpdater { get; private set; }
    public static string lbUpdaterHeader { get; private set; }
    public static string lbUpdaterDetails { get; private set; }
    public static string pbDownloadProgressWaitingForData { get; private set; }
    public static string pbDownloadProgressWaitingForClose { get; private set; }
    public static string pbDownloadProgressPreparing { get; private set; }
    public static string pbDownloadProgressCalculatingHash { get; private set; }
    public static string pbDownloadProgressHashNoMatch { get; private set; }
    public static string pbDownloadProgressSkippingHashCalculating { get; private set; }
    public static string pbDownloadProgressCancelled { get; private set; }
    public static string pbDownloadProgressWebException { get; private set; }
    public static string pbDownloadProgressDownloadException { get; private set; }
    public static string pbDownloadProgressErrorDownloading { get; private set; }
    public static string pbDownloadProgressDownloadTooSmall { get; private set; }
    public static string pbDownloadProgressDownloadFinishedLaunching { get; private set; }
    public static string pbDownloadProgressErrorProcessingDownload { get; private set; }
    #endregion

    #region Interal English
    public static class InternalEnglish {
        public const string GenericRetry = "Retry";
        public const string GenericOk = "OK";

        public const string dlgUpdaterUpdatedVersionHashNoMatch = "The hash calculated by the updater does not match the known hash of the update.\r\n\r\nExpected: {0}\r\n\r\nCalculated: {1}\r\n\r\nYou can continue without it matching, there are some instances where it may be different.";
        public const string dlgUpdaterHashNotGiven = "The UpdateHash hasn't been set, so I can't calculate the hash to sanity-check that it's the one from release. Your mileage may vary.";

        public const string frmException = "An exception occured";
        public const string lbExceptionHeader = "An exception has occured";
        public const string lbExceptionDescription = "Below is the error that occured. Feel free to open a new issue and report it.";
        public const string rtbExceptionDetails = "Feel free to copy + paste this entire text wall into a new issue on Github";
        public const string btnExceptionGithub = "Github";
        public const string tabExceptionDetails = "Exception details";
        public const string tabExceptionExtraInfo = "Extra info";

        public const string frmUpdater = "Updating";
        public const string lbUpdaterHeader = "Updating youtube-dl-gui";
        public const string lbUpdaterDetails = "The previous version won't be deleted if it fails.";
        public const string rtbUpdaterExceptionDetails = "Feel free to copy + paste this entire text wall into a new issue on Github. The old youtube-dl-gui will be restored, and you can attempt to redownload the update through the application, or manually from Github.";
        public const string pbDownloadProgressWaitingForData = "Waiting for update data";
        public const string pbDownloadProgressWaitingForClose = "Waiting for program to close";
        public const string pbDownloadProgressPreparing = "Preparing download to do things";
        public const string pbDownloadProgressCalculatingHash = "Calculating hash";
        public const string pbDownloadProgressHashNoMatch = "Hash does not match";
        public const string pbDownloadProgressSkippingHashCalculating = "Skipping hash calculating...";
        public const string pbDownloadProgressCancelled = "Cancelled";
        public const string pbDownloadProgressWebException = "A web exception occurred";
        public const string pbDownloadProgressDownloadException = "An exception occurred";
        public const string pbDownloadProgressErrorDownloading = "Error downloading";
        public const string pbDownloadProgressDownloadTooSmall = "Error: the download is too small";
        public const string pbDownloadProgressDownloadFinishedLaunching = "Download finished, launching...";
        public const string pbDownloadProgressErrorProcessingDownload = "Error processing download";
    }

    public static void LoadInternalEnglish() {
        GenericRetry = InternalEnglish.GenericRetry;
        GenericOk = InternalEnglish.GenericOk;

        dlgUpdaterUpdatedVersionHashNoMatch = InternalEnglish.dlgUpdaterUpdatedVersionHashNoMatch;
        dlgUpdaterHashNotGiven = InternalEnglish.dlgUpdaterHashNotGiven;

        frmException = InternalEnglish.frmException;
        lbExceptionHeader = InternalEnglish.lbExceptionHeader;
        lbExceptionDescription = InternalEnglish.lbExceptionDescription;
        rtbExceptionDetails = InternalEnglish.rtbExceptionDetails;
        btnExceptionGithub = InternalEnglish.btnExceptionGithub;
        tabExceptionDetails = InternalEnglish.tabExceptionDetails;
        tabExceptionExtraInfo = InternalEnglish.tabExceptionExtraInfo;

        frmUpdater = InternalEnglish.frmUpdater;
        lbUpdaterHeader = InternalEnglish.lbUpdaterHeader;
        lbUpdaterDetails = InternalEnglish.lbUpdaterDetails;

        pbDownloadProgressWaitingForData = InternalEnglish.pbDownloadProgressWaitingForData;
        pbDownloadProgressWaitingForClose = InternalEnglish.pbDownloadProgressWaitingForClose;
        pbDownloadProgressPreparing = InternalEnglish.pbDownloadProgressPreparing;
        pbDownloadProgressCalculatingHash = InternalEnglish.pbDownloadProgressCalculatingHash;
        pbDownloadProgressHashNoMatch = InternalEnglish.pbDownloadProgressHashNoMatch;
        pbDownloadProgressSkippingHashCalculating = InternalEnglish.pbDownloadProgressSkippingHashCalculating;
        pbDownloadProgressCancelled = InternalEnglish.pbDownloadProgressCancelled;
        pbDownloadProgressWebException = InternalEnglish.pbDownloadProgressWebException;
        pbDownloadProgressDownloadException = InternalEnglish.pbDownloadProgressDownloadException;
        pbDownloadProgressErrorDownloading = InternalEnglish.pbDownloadProgressErrorDownloading;
        pbDownloadProgressDownloadTooSmall = InternalEnglish.pbDownloadProgressDownloadTooSmall;
        pbDownloadProgressDownloadFinishedLaunching = InternalEnglish.pbDownloadProgressDownloadFinishedLaunching;
        pbDownloadProgressErrorProcessingDownload = InternalEnglish.pbDownloadProgressErrorProcessingDownload;
    }
    #endregion

    public static bool LoadLanguage(string LanguageFile = null) {
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

                                case "dlgupdaterupdatedversionhashnomatch":
                                    dlgUpdaterUpdatedVersionHashNoMatch = ReadValue;
                                    continue;
                                case "dlgupdaterhashnotgiven":
                                    dlgUpdaterHashNotGiven = ReadValue;
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
                                case "tabexceptiondetails":
                                    tabExceptionDetails = ReadValue;
                                    continue;
                                case "tabexceptionextrainfo":
                                    tabExceptionExtraInfo = ReadValue;
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
                                case "pbdownloadprogresswaitingfordata":
                                    pbDownloadProgressWaitingForData = ReadValue;
                                    continue;
                                case "pbdownloadprogresswaitingforclose":
                                    pbDownloadProgressWaitingForClose = ReadValue;
                                    continue;
                                case "pbdownloadprogresspreparing":
                                    pbDownloadProgressPreparing = ReadValue;
                                    continue;
                                case "pbdownloadprogresscalculatinghash":
                                    pbDownloadProgressCalculatingHash = ReadValue;
                                    continue;
                                case "pbdownloadprogresshashnomatch":
                                    pbDownloadProgressHashNoMatch = ReadValue;
                                    continue;
                                case "pbdownloadprogressskippinghashcalculating":
                                    pbDownloadProgressSkippingHashCalculating = ReadValue;
                                    continue;
                                case "pbdownloadprogresscancelled":
                                    pbDownloadProgressCancelled = ReadValue;
                                    continue;
                                case "pbdownloadprogresswebexception":
                                    pbDownloadProgressWebException = ReadValue;
                                    continue;
                                case "pbdownloadprogressdownloadexception":
                                    pbDownloadProgressDownloadException = ReadValue;
                                    continue;
                                case "pbdownloadprogresserrordownloading":
                                    pbDownloadProgressErrorDownloading = ReadValue;
                                    continue;
                                case "pbdownloadprogressdownloadtoosmall":
                                    pbDownloadProgressDownloadTooSmall = ReadValue;
                                    continue;
                                case "pbdownloadprogressdownloadfinishedlaunching":
                                    pbDownloadProgressDownloadFinishedLaunching = ReadValue;
                                    continue;
                                case "pbdownloadprogresserrorprocessingdownload":
                                    pbDownloadProgressErrorProcessingDownload = ReadValue;
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
            Log.ReportRetriableLanguageException(ex);
            return false;
        }
    }

    /// <summary>
    /// Parses the header value from a string.
    /// </summary>
    /// <param name="Input">The string that may contain a header.</param>
    /// <returns>Returns the absolute header.</returns>
    private static void ReadHeaderValue(string Input, out string Header) {
        Input = Input.Contains("//") ? Input.Substring(0, Input.IndexOf("//")) : Input;
        Header = Input.Substring(1, Input.IndexOf(']') - 1);
    }

    /// <summary>
    /// Parses the control name and value from a string.
    /// </summary>
    /// <param name="Input">The string that will be parsed.</param>
    /// <param name="Name">The output of the Name of the control to be named, as lowercase.</param>
    /// <param name="Value">The vlaue of the control.</param>
    private static void GetControlInfo(string Input, out string Name, out string Value) {
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