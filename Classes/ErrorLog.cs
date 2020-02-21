using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace youtube_dl_gui {
    class ErrorLog {
        /// <summary>
        /// Reports any web errors that are caught
        /// </summary>
        /// <param name="WebException">The WebException that was caught</param>
        /// <param name="url">The URL that (might-have) caused the problem</param>
        public static void ReportWebException(WebException WebException, string WebsiteAddress) {
            if (Errors.Default.suppressErrors)
                return;

            string OutputFile = string.Empty;

            frmException ExceptionDisplay = new frmException();
            ExceptionDisplay.ReportedWebException = WebException;
            ExceptionDisplay.FromLanguage = false;

            if (WebException.Status == WebExceptionStatus.ProtocolError) {
                var WebResponse = WebException.Response as HttpWebResponse;

                if (WebResponse != null) {
                    ExceptionDisplay.SetCustomDescription = true;
                    switch ((int)WebResponse.StatusCode) {
                        #region default / unspecified
                        default:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned " + WebResponse.StatusCode.ToString() +
                                "\n" + WebResponse.StatusDescription.ToString();
                        break;
                        #endregion

                        #region 301 Moved / Moved permanently
                        case 301:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 301 - Moved / Moved permanently" +
                                "\nThe requested information has been moved to the URI specified in the Location header.";
                        break;
                        #endregion

                        #region 400 Bad request
                        case 400:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 400 - Bad request" +
                                "\nThe request could not be understood by the server.";
                        break;
                        #endregion

                        #region 401 Unauthorized
                        case 401:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 401 - Unauthorized" +
                                "\nThe requested resource requires authentication.";
                        break;
                        #endregion

                        #region 402 Payment required
                        case 402:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 402 - Payment required" +
                                "\nPayment is required to view this content.\nThis status code isn't natively used.";
                        break;
                        #endregion

                        #region 403 Forbidden
                        case 403:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 403 - Forbidden" +
                                "\nYou do not have permission to view this file.";
                        break;
                        #endregion

                        #region 404 Not found
                        case 404:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 404 - Not found" +
                                "\nThe file does not exist on the server.";
                        break;
                        #endregion

                        #region 405 Method not allowed
                        case 405:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 405 - Method not allowed" +
                                "\nThe request method (GET) is not allowed on the requested resource.";
                        break;
                        #endregion

                        #region 406 Not acceptable
                        case 406:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 406 - Not acceptable" +
                                "\nThe client has indicated with Accept headers that it will not accept any of the available representations from the resource.";
                        break;
                        #endregion

                        #region 407 Proxy authentication required
                        case 407:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 407 - Proxy authentication required" +
                                "\nThe requested proxy requires authentication.";
                        break;
                        #endregion

                        #region 408 Request timeout
                        case 408:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 408 - Request timeout" +
                                "\nThe client did not send a request within the time the server was expection the request.";
                        break;
                        #endregion

                        #region 409 Conflict
                        case 409:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 409 - Conflict" +
                                "\nThe request could not be carried out because of a conflict on the server.";
                        break;
                        #endregion

                        #region 410 Gone
                        case 410:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 410 - Gone" +
                                "\nThe requested resource is no longer available.";
                        break;
                        #endregion

                        #region 411 Length required
                        case 411:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 410 - Length required" +
                                "\nThe required Content-length header is missing.";
                        break;
                        #endregion

                        #region 412 Precondition failed
                        case 412:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 412 - Precondition failed" +
                                "\nA condition set for this request failed, and the request cannot be carried out.";
                        break;
                        #endregion

                        #region 413 Request entity too large
                        case 413:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 413 - Request entity too large" +
                                "\nThe request is too large for the server to process.";
                        break;
                        #endregion

                        #region 414 Request uri too long
                        case 414:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 414 - Request uri too long" +
                                "\nThe uri is too long.";
                        break;
                        #endregion

                        #region 415 Unsupported media type
                        case 415:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 415 - Unsupported media type" +
                                "\nThe request is an unsupported type.";
                        break;
                        #endregion

                        #region 416 Requested range not satisfiable
                        case 416:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 416 - Requested range not satisfiable" +
                                "\nThe range of data requested from the resource cannot be returned.";
                        break;
                        #endregion

                        #region 417 Expectation failed
                        case 417:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 417 - Expectation failed" +
                                "\nAn expectation given in an Expect header could not be met by the server.";
                        break;
                        #endregion

                        #region 426 Upgrade required
                        case 426:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 426 - Upgrade required" +
                                "\nNo information is available about this error code.";
                        break;
                        #endregion

                        #region 500 Internal server error
                        case 500:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 500 - Internal server error" +
                                "\nAn error occured on the server.";
                        break;
                        #endregion

                        #region 501 Not implemented
                        case 501:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 501 - Not implemented" +
                                "\nThe server does not support the requested function.";
                        break;
                        #endregion

                        #region 502 Bad gateway
                        case 502:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 502 - Bad gateway" +
                                "\nThe proxy server recieved a bad response from another proxy or the origin server.";
                        break;
                        #endregion

                        #region 503  Service unavailable
                        case 503:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 503 - Service unavailable" +
                                "\nThe server is temporarily unavailable, likely due to high load or maintenance.";
                        break;
                        #endregion

                        #region 504 Gateway timeout
                        case 504:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 504 - Gateway timeout" +
                                "\nAn intermediate proxy server timed out while waiting for a response from another proxy or the origin server.";
                        break;
                        #endregion

                        #region 505 Http version not supported
                        case 505:
                            ExceptionDisplay.CustomDescription = "A WebException occured at " + WebsiteAddress +
                                "\n\nThe address returned 505 - Http version not supported" +
                                "\nThe requested HTTP version is not supported by the server.";
                        break;
                        #endregion
                    }
                }
            }

            ExceptionDisplay.ShowDialog();
            ExceptionDisplay.Dispose();

            // build log file


            if (Errors.Default.logErrors) {
                System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\error.log", WebException.ToString());
            }
        }
        /// <summary>
        /// Reports any general exceptions that are caught
        /// </summary>
        /// <param name="Exception">The Exception that was caught</param>
        public static void ReportException(Exception Exception) {
            if (Errors.Default.suppressErrors)
                return;

            string OutputFile = string.Empty;

            frmException ExceptionDisplay = new frmException();
            ExceptionDisplay.ReportedException = Exception;
            ExceptionDisplay.ShowDialog();
            ExceptionDisplay.FromLanguage = false;
            ExceptionDisplay.Dispose();

            if (Errors.Default.logErrors) {
                System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\error.log", Exception.ToString());
            }
        }
    }
}
