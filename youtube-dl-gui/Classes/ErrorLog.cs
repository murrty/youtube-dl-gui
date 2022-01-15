// ErrorLog 1.0.0

using System;
using System.Linq;
using System.Management;
using System.Net;
using System.Windows.Forms;

namespace youtube_dl_gui {

    /// <summary>
    /// This class will control the Errors that get reported in try statements.
    /// </summary>
    class ErrorLog {

        public static string ComputerVersionInformation;

        /// <summary>
        /// Assembles the computer information one time so exceptions do not require parsing through the management objects.
        /// </summary>
        public static void AssembleComputerVersionInformation() {
            ManagementObjectSearcher searcher = new("SELECT * FROM Win32_OperatingSystem");
            ManagementObject info = searcher.Get().Cast<ManagementObject>().FirstOrDefault();
            ComputerVersionInformation =
                $"Version: {info.Properties["Version"].Value} " +
                $"Service Pack Major: {info.Properties["ServicePackMajorVersion"].Value} " +
                $"Service Pack Minor: {info.Properties["ServicePackMinorVersion"].Value} " +
                $"System Caption: {info.Properties["Caption"].Value}";
        }

        /// <summary>
        /// Reports any web errors that are caught
        /// </summary>
        /// <param name="WebException">The WebException that was caught</param>
        /// <param name="url">The URL that (might-have) caused the problem</param>
        public static DialogResult Report(WebException ReceivedException, string WebsiteAddress) {
            if (!Config.Settings.Errors.suppressErrors) {
                string CustomDescriptionBuffer = string.Empty;
                bool UseCustomDescription = false;

                switch (ReceivedException.Status) {
                    #region NameResolutionFailure
                    case WebExceptionStatus.NameResolutionFailure:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nName resolution failure" +
                                        "\nThe name resolver service could not resolve the host name.";
                        break;
                    #endregion
                    #region ConnectFailure
                    case WebExceptionStatus.ConnectFailure:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nConnection failure" +
                                        "\nThe remote service point could not be contacted at the transport level.";
                        break;
                    #endregion
                    #region RecieveFailure
                    case WebExceptionStatus.ReceiveFailure:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nRecieve failure" +
                                        "\nA complete response was not received from the remote server.";
                        break;
                    #endregion
                    #region SendFailure
                    case WebExceptionStatus.SendFailure:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nSend failure" +
                                        "\nA complete response could not be sent to the remote server.";
                        break;
                    #endregion
                    #region PipelineFailure
                    case WebExceptionStatus.PipelineFailure:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nPipeline failure" +
                                        "\nThe request was a piplined request and the connection was closed before the response was received.";
                        break;
                    #endregion
                    #region RequestCanceled
                    case WebExceptionStatus.RequestCanceled:
                        return DialogResult.OK;
                    #endregion
                    #region ProtocolError
                    case WebExceptionStatus.ProtocolError:
                        HttpWebResponse WebResponse = (HttpWebResponse)ReceivedException.Response;

                        if (WebResponse != null) {
                            UseCustomDescription = true;
                            CustomDescriptionBuffer += (int)WebResponse.StatusCode switch {

                                // Hold on
                                #region 100 Continue
                                100 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 100 - Continue" +
                                       "\nThe server is processing the request and nothing bad has occured yet. The client may continue with the request, or ignore the response.",
                                #endregion

                                #region 101 Switching protocols
                                101 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 101 - Switching protocols" +
                                       "\nThe server is switching to another protocol by request of the client.",
                                #endregion

                                #region 103 Early hints
                                103 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 103 - Early hints" +
                                       "\nThe server requested that the requester start preloading resources. Or something else.",
                                #endregion

                                // Here you go
                                #region 200  OK
                                200 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 200 - OK" +
                                       "\nThe request succeeded. Why are you here?",
                                #endregion

                                #region 201 Created
                                201 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 201 - Created" +
                                       "\nThe request has succeeded, and a resource was created from it.",
                                #endregion

                                #region 202 Accepted
                                202 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 202 - Accepted" +
                                       "\nThe request was accepted for processing, but it has not started or completed.",
                                #endregion

                                #region 203 Non-authoritative information
                                203 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 203 - Non-authoritative information" +
                                       "\nThe request succeeded, but the payload was modified by a transformative proxy.",
                                #endregion

                                #region 204 No content
                                204 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 204 - No content" +
                                       "\nThe request has succeeded, but no redirect is required.",
                                #endregion

                                #region 205 Reset content
                                205 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 205 - Reset content" +
                                       "\nThe resource requested that the content be refreshed.",
                                #endregion

                                #region 206 Partial content
                                206 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 206 - Partial content" +
                                       "\nThe request succeeded to the range requested.",
                                #endregion

                                // Go away
                                #region 300 Multiple choices
                                300 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 300 - Multiple choice" +
                                       "\nThe requested resource has more than one possible response.",
                                #endregion

                                #region 301 Moved / Moved permanently
                                301 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 301 - Moved / Moved permanently" +
                                       "\nThe requested information has been moved to the URI specified in the Location header.",
                                #endregion

                                #region 302 Found
                                302 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 302 - Found" +
                                       "\nThe requested resource was moved to another area.",
                                #endregion

                                #region 303 See other
                                303 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 303 - See other" +
                                       "\nThe accessed resource doesn't link to the newly uploaded resource, but it links elsewhere.",
                                #endregion

                                #region 304 Not modified
                                304 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 304 - Not modified" +
                                       "\nThe requested resource has not been modified since the last time it was accessed, due to a \"If-Modified-Since\" or \"If-None-Match\" header.",
                                #endregion

                                #region 307 Temporary redirect
                                307 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 307 - Temporary redirect" +
                                       "\nThe requested resource has temporarily moved to a different area.",
                                #endregion

                                #region 308 Permanent redirect
                                308 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 308 - Permanent redirect" +
                                       "\nThe requested resource has been moved to a different area.",
                                #endregion

                                // You fucked up
                                #region 400 Bad request
                                400 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 400 - Bad request" +
                                       "\nThe request could not be understood by the server.",
                                #endregion

                                #region 401 Unauthorized
                                401 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 401 - Unauthorized" +
                                       "\nThe requested resource requires authentication.",
                                #endregion

                                #region 402 Payment required
                                402 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 402 - Payment required" +
                                       "\nPayment is required to view this content.\nThis status code isn't natively used.",
                                #endregion

                                #region 403 Forbidden
                                403 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 403 - Forbidden" +
                                       "\nYou do not have permission to view this file.",
                                #endregion

                                #region 404 Not found
                                404 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 404 - Not found" +
                                       "\nThe file does not exist on the server.",
                                #endregion

                                #region 405 Method not allowed
                                405 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 405 - Method not allowed" +
                                       "\nThe request method (GET) is not allowed on the requested resource.",
                                #endregion

                                #region 406 Not acceptable
                                406 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 406 - Not acceptable" +
                                       "\nThe client has indicated with Accept headers that it will not accept any of the available representations from the resource.",
                                #endregion

                                #region 407 Proxy authentication required
                                407 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 407 - Proxy authentication required" +
                                       "\nThe requested proxy requires authentication.",
                                #endregion

                                #region 408 Request timeout
                                408 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 408 - Request timeout" +
                                       "\nThe client did not send a request within the time the server was expection the request.",
                                #endregion

                                #region 409 Conflict
                                409 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 409 - Conflict" +
                                       "\nThe request could not be carried out because of a conflict on the server.",
                                #endregion

                                #region 410 Gone
                                410 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 410 - Gone" +
                                       "\nThe requested resource is no longer available.",
                                #endregion

                                #region 411 Length required
                                411 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 410 - Length required" +
                                       "\nThe required Content-length header is missing.",
                                #endregion

                                #region 412 Precondition failed
                                412 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 412 - Precondition failed" +
                                       "\nThe server refused to process the request because an unmatched conditional header is present in the headers.",
                                //"\nA condition set for this request failed, and the request cannot be carried out.",
                                #endregion

                                #region 413 Request entity too large
                                413 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 413 - Request entity too large" +
                                       "\nThe request is too large for the server to process.",
                                #endregion

                                #region 414 Request uri too long
                                414 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 414 - Request uri too long" +
                                       "\nThe uri is too long.",
                                #endregion

                                #region 415 Unsupported media type
                                415 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 415 - Unsupported media type" +
                                       "\nThe request is an unsupported type.",
                                #endregion

                                #region 416 Requested range not satisfiable
                                416 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 416 - Requested range not satisfiable" +
                                       "\nThe range of data requested from the resource cannot be returned.",
                                #endregion

                                #region 417 Expectation failed
                                417 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 417 - Expectation failed" +
                                       "\nAn expectation given in an Expect header could not be met by the server.",
                                #endregion

                                #region 418 I'm a teapot
                                418 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 418 - I'm a teapot" +
                                       "\nThe server cannot brew coffee at this time.",
                                #endregion

                                #region 422 Unprocessable Entity
                                422 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 422 - Unprocessable entity" +
                                       "\nThe server refused to process the request because it is considered unprocessable.",
                                #endregion

                                #region 425 Too early
                                425 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 425 - Too early" +
                                       "\nThe server refused to process the request due to a replay attack mitigation.",
                                #endregion

                                #region 426 Upgrade required
                                426 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 426 - Upgrade required" +
                                       "\nThe server refused to process the request using your current protocol.",
                                #endregion

                                #region 428 Precondition required
                                428 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 428 - Precondition required" +
                                       "\nThe server refused the connection because there are no required conditional headers.",
                                #endregion

                                #region 429 Too many requests
                                429 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 429 - Too many requests" +
                                       "\nThe server refused to process the request because it was sent too many requests. You may be rate limited.",
                                #endregion

                                #region 431 Request header fields too large
                                431 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 431 - Request header fields too large" +
                                       "\nThe server refused to process the request because one header or all headers are too large.",
                                #endregion

                                #region 451 Unavailable for legal reasons
                                451 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 451 - Unavailable for legal reasons" +
                                       "\nThe server cannot process the request due to a legal reason in your IPs' region.",
                                #endregion

                                // I fucked up
                                #region 500 Internal server error
                                500 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 500 - Internal server error" +
                                       "\nAn error occured on the server.",
                                #endregion

                                #region 501 Not implemented
                                501 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 501 - Not implemented" +
                                       "\nThe server does not support the requested function.",
                                #endregion

                                #region 502 Bad gateway
                                502 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 502 - Bad gateway" +
                                       "\nThe proxy server recieved a bad response from another proxy or the origin server.",
                                #endregion

                                #region 503  Service unavailable
                                503 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 503 - Service unavailable" +
                                       "\nThe server is temporarily unavailable, likely due to high load or maintenance.",
                                #endregion

                                #region 504 Gateway timeout
                                504 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 504 - Gateway timeout" +
                                       "\nAn intermediate proxy server timed out while waiting for a response from another proxy or the origin server.",
                                #endregion

                                #region 505 Http version not supported
                                505 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 505 - Http version not supported" +
                                       "\nThe requested HTTP version is not supported by the server.",
                                #endregion

                                #region  506 Variant also negotiates
                                506 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 506 - Variant also negotiates" +
                                       "\nAn internal server configuration error in which, who knows, I don't. I'm not well versed in networking.",
                                #endregion

                                #region  507 Insufficient storage
                                507 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 507 - Insufficient storage" +
                                       "\nThe server cannot store the data with the request.",
                                #endregion

                                #region  508 Loop detected
                                508 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 508 - Loop detected" +
                                       "\nThe server encountered an infinite loop, and the operation failed.",
                                #endregion

                                #region  510 Not extended
                                510 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 510 - Not extended" +
                                       "\nThe server... okay i have no idea.",
                                #endregion

                                #region  511 Network authentication required
                                511 => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                       "\n\nThe address returned 511 - Network authentication required" +
                                       "\nThe user must authenticate to gain access to the resources' network.",
                                #endregion

                                _ => $"A WebException occured{(WebsiteAddress is not null ? $" at {WebsiteAddress}" : "")}." +
                                     "\n\nThe address returned " + WebResponse.StatusCode.ToString() +
                                     "\n" + WebResponse.StatusDescription.ToString()

                            };
                        }
                        break;
                    #endregion
                    #region ConnectionClosed
                    case WebExceptionStatus.ConnectionClosed:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nConnection closed" +
                                        "\nThe connection was prematurely closed.";
                        break;
                    #endregion
                    #region TrustFailure
                    case WebExceptionStatus.TrustFailure:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nTrust failure" +
                                        "\nA server certificate could not be validated.";
                        break;
                    #endregion
                    #region SecureChannelFailure
                    case WebExceptionStatus.SecureChannelFailure:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nSecure channel failure" +
                                        "\nAn error occurred while establishing a connection using SSL.";
                        break;
                    #endregion
                    #region ServerProtocolViolation
                    case WebExceptionStatus.ServerProtocolViolation:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nServer protocol violation" +
                                        "\nThe server response was not a valid HTTP response.";
                        break;
                    #endregion
                    #region KeepAliveFailure
                    case WebExceptionStatus.KeepAliveFailure:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nKeep alive failure" +
                                        "\nThe connection for a request that specifies the Keep-alive header was closed unexpectedly.";
                        break;
                    #endregion
                    #region Pending
                    case WebExceptionStatus.Pending:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nPending" +
                                        "\nAn internal asynchronous request is pending.";
                        break;
                    #endregion
                    #region Timeout
                    case WebExceptionStatus.Timeout:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nTimeout" +
                                        "\nNo response was received during the time-out period for a request.";
                        break;
                    #endregion
                    #region ProxyNameResolutionFailure
                    case WebExceptionStatus.ProxyNameResolutionFailure:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nProxy name resolution failure" +
                                        "\nThe name resolver service could not resolve the proxy host name.";
                        break;
                    #endregion
                    #region UnknownError
                    case WebExceptionStatus.UnknownError:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nUnknown error" +
                                        "\nAn exception of unknown type has occurred.";
                        break;
                    #endregion
                    #region MessageLengthLimitExceeded
                    case WebExceptionStatus.MessageLengthLimitExceeded:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nMessage length limit exceeded" +
                                        "\nA message was received that exceeded the specified limit when sending a request or receiving a response from the server.";
                        break;
                    #endregion
                    #region CacheEntryNotFound
                    case WebExceptionStatus.CacheEntryNotFound:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nCache entry not found" +
                                        "\nThe specified cache entry was not found.";
                        break;
                    #endregion
                    #region RequestProhibitedByCachePolicy
                    case WebExceptionStatus.RequestProhibitedByCachePolicy:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nRequest prohibited by cache policy" +
                                        "\nThe request was not permitted by the cache policy.";
                        break;
                    #endregion
                    #region RequestProhibitedByProxy
                    case WebExceptionStatus.RequestProhibitedByProxy:
                        UseCustomDescription = true;
                        CustomDescriptionBuffer += "A WebException occured at " + WebsiteAddress +
                                        "\n\nRequest prohibited by proxy" +
                                        "\nThis request was not permitted by the proxy.";
                        break;
                        #endregion
                }

                if (UseCustomDescription) {
                    CustomDescriptionBuffer += ReceivedException.InnerException + "\n\nStackTrace:\n" +
                                               ReceivedException.StackTrace;
                }

                if (UseCustomDescription) { WriteToFile(CustomDescriptionBuffer); }
                else { WriteToFile(ReceivedException.ToString()); }

                using murrty.frmException ExceptionDisplay = new(new(ReceivedException) {
                    FromLanguage = false,
                    ExtraInfo = WebsiteAddress,
                    CustomDescription = UseCustomDescription ? CustomDescriptionBuffer : null
                });
                return ExceptionDisplay.ShowDialog();
            }
            else return DialogResult.OK;
        }

        /// <summary>
        /// Reports any general exceptions that are caught
        /// </summary>
        /// <param name="Exception">The Exception that was caught</param>
        public static DialogResult Report(Exception ReceivedException, bool IsWriteToFile = false) {
            if (!Config.Settings.Errors.suppressErrors) {
                if (!IsWriteToFile) WriteToFile(ReceivedException.ToString());
                using murrty.frmException ExceptionDisplay = new(new(ReceivedException));
                return ExceptionDisplay.ShowDialog();
            }
            else return DialogResult.OK;

        }

        /// <summary>
        /// Reports a decimal parsing exception that may get caught.
        /// </summary>
        /// <param name="ReceivedException">The <seealso cref="DecimalParsingException"/> received.</param>
        public static DialogResult Report(DecimalParsingException ReceivedException) {
            if (!Config.Settings.Errors.suppressErrors) {
                WriteToFile(ReceivedException.ToString());
                using murrty.frmException ExceptionDisplay = new(new(ReceivedException));
                return ExceptionDisplay.ShowDialog();
            }
            else return DialogResult.OK;
        }

        /// <summary>
        /// Reports a api parsing exception that may get caught.
        /// </summary>
        /// <param name="ReceivedException">The <seealso cref="ApiParsingException"/> received.</param>
        public static DialogResult Report (ApiParsingException ReceivedException) {
            if (!Config.Settings.Errors.suppressErrors) {
                WriteToFile(ReceivedException.ToString());
                using murrty.frmException ExceptionDisplay = new(new(ReceivedException));
                return ExceptionDisplay.ShowDialog();
            }
            else return DialogResult.OK;
        }

        /// <summary>
        /// Writes the error to a .log file in the working directory.
        /// </summary>
        /// <param name="Buffer">The data that will be written to the log file</param>
        private static void WriteToFile(string LogData) {
            if (Config.Settings.Errors.logErrors && !Program.IsDebug) {
                try {
                    string FileName = $"\\error_{DateTime.Now:yyyy-MM-dd-HH-mm-ss.fff}.log";
                    System.IO.File.WriteAllText(FileName, LogData);
                }
                catch (Exception ex) { Report(ex, true); }
            }
        }

    }

    /// <summary>
    /// A exception that occurs when decimal.TryParse returns false.
    /// </summary>
    [Serializable]
    public class DecimalParsingException : Exception {
        public string ExtraInfo { get; set; } = "No extra info provided.";
        public DecimalParsingException() : base("No message has been provided.") { }
        public DecimalParsingException(string message) : base(message) { }
        public DecimalParsingException(string message, string extraInfo) : base(message) { ExtraInfo = extraInfo; }
    }

    /// <summary>
    /// An exception that occurs when parsing an API fails at a critical point.
    /// </summary>
    [Serializable]
    public class ApiParsingException : Exception {
        public string ExtraInfo { get; set; } = "No extra info provided.";
        public string ApiUrl { get; set; } = "No API URL provided.";
        public ApiParsingException(string url) : base("No message has been provided.") { ApiUrl = url; }
        public ApiParsingException(string message, string url) : base(message) { ApiUrl = url; }
        public ApiParsingException(string message, string url, string extraInfo) : base(message) { ApiUrl = url; ExtraInfo = extraInfo; }
    }

}