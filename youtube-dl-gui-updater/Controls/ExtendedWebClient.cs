using System;
using System.ComponentModel;
using System.Net;

namespace murrty.classcontrols {

    /// <summary>
    /// The method that the connection should use.
    /// </summary>
    public enum HttpMethod {
        /// <summary>
        /// Starts two-way communications with the requested resource.
        /// </summary>
        CONNECT,
        /// <summary>
        /// Deletes the specified resource.
        /// </summary>
        DELETE,
        /// <summary>
        /// Requests a representation of the specified resource.
        /// </summary>
        GET,
        /// <summary>
        /// Requests the headers that would be returned if the requests' URL was instead requested with GET.
        /// </summary>
        HEAD,
        /// <summary>
        /// Requests permitted communication options for the URL or server.
        /// </summary>
        OPTIONS,
        /// <summary>
        /// Applies partial modifications to a resource.
        /// </summary>
        PATCH,
        /// <summary>
        /// Sends data to the server as an addition to the target.
        /// </summary>
        POST,
        /// <summary>
        /// Sends data to the server as a replacement of the target.
        /// </summary>
        PUT,
        /// <summary>
        /// Performs a message loop-back test along with the path to the target resource, used for debugging.
        /// </summary>
        TRACE
    }

    /// <summary>
    /// An extended control to include extra usability to the base WebClient class.
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    [ToolboxItem(false)]
    internal class ExtendedWebClient : WebClient {

        #region Properties

        /// <summary>
        /// Gets or sets the CookieContainer used to maintain the cookies when accessing online resources.
        /// </summary>
        public CookieContainer CookieContainer { get; set; } = null;

        /// <summary>
        /// Sets the WebClient METHOD when connecting to the online resource.
        /// <para>Default value is GET.</para>
        /// </summary>
        public HttpMethod Method { get; set; } = HttpMethod.GET;

        /// <summary>
        /// Gets or sets the IfModifiedSince DateTime value to when the online resource was last modified.
        /// <para>The default value is null.</para>
        /// </summary>
        public DateTime IfModifiedSince { get; set; } = default;

        /// <summary>
        /// Gets the IfModifiedSince header that the online resource has set as the response headers.
        /// </summary>
        public DateTime ResourceLastModified { get; private set; } = default;

        /// <summary>
        /// Gets or sets the UserAgent of the WebClient.
        /// </summary>
        public string UserAgent { get; set; } = null;

        /// <summary>
        /// Gets or sets the Accept headers of the WebClient.
        /// </summary>
        public string Accept { get; set; } = null;

        /// <summary>
        /// Gets the build <see cref="WebRequest"/> that the control built before contacting the online resource.
        /// </summary>
        public WebRequest BuiltRequest { get; private set; } = null;

        /// <summary>
        /// Gets the received <see cref="WebResponse"/> from the online resource after receiving header data.
        /// </summary>
        public WebResponse ReceivedResponse { get; private set; } = null;

        #endregion

        #region Constructors & Destructor

        /// <summary>
        /// An extended control to include extra usability to the base WebClient class.
        /// </summary>
        public ExtendedWebClient() {
            this.CookieContainer = new();
        }

        /// <summary>
        /// An extended control to include extra usability to the base WebClient class.
        /// </summary>
        /// <param name="CookieContainer">The <seealso cref="System.Net.CookieContainer"/> containing requested cookies that the user wants to use.</param>
        public ExtendedWebClient(CookieContainer CookieContainer) {
            this.CookieContainer = CookieContainer;
        }

        /// <summary>
        /// An extended control to include extra usability to the base WebClient class.
        /// </summary>
        /// <param name="Method">The <see cref="string"/> containing the Method that will be used when contacting online resources.</param>
        public ExtendedWebClient(HttpMethod Method) {
            CookieContainer = new();
            this.Method = Method;
        }

        /// <summary>
        /// An extended control to include extra usability to the base WebClient class.
        /// </summary>
        /// <param name="IfModifiedSince">The <see cref="DateTime"/> containing the last known time that the online resource was modified.</param>
        public ExtendedWebClient(DateTime IfModifiedSince) {
            CookieContainer = new();
            this.IfModifiedSince = IfModifiedSince;
        }

        /// <summary>
        /// An extended control to include extra usability to the base WebClient class.
        /// </summary>
        /// <param name="CookieContainer">The <seealso cref="System.Net.CookieContainer"/> containing requested cookies that the user wants to use.</param>
        /// <param name="Method">The <see cref="string"/> containing the Method that will be used when contacting online resources.</param>
        public ExtendedWebClient(CookieContainer CookieContainer, HttpMethod Method) {
            this.CookieContainer = CookieContainer;
            this.Method = Method;
        }

        /// <summary>
        /// An extended control to include extra usability to the base WebClient class.
        /// </summary>
        /// <param name="Method">The <see cref="string"/> containing the Method that will be used when contacting online resources.</param>
        /// <param name="IfModifiedSince">The <see cref="DateTime"/> containing the last known time that the online resource was modified.</param>
        public ExtendedWebClient(HttpMethod Method, DateTime IfModifiedSince) {
            CookieContainer = new();
            this.Method = Method;
            this.IfModifiedSince = IfModifiedSince;
        }

        /// <summary>
        /// An extended control to include extra usability to the base WebClient class.
        /// </summary>
        /// <param name="CookieContainer">The <seealso cref="System.Net.CookieContainer"/> containing requested cookies that the user wants to use.</param>
        /// <param name="IfModifiedSince">The <see cref="DateTime"/> containing the last known time that the online resource was modified.</param>
        public ExtendedWebClient(CookieContainer CookieContainer, DateTime IfModifiedSince) {
            this.CookieContainer = CookieContainer;
            this.IfModifiedSince = IfModifiedSince;
        }

        /// <summary>
        /// An extended control to include extra usability to the base WebClient class.
        /// </summary>
        /// <param name="CookieContainer">The <seealso cref="System.Net.CookieContainer"/> containing requested cookies that the user wants to use.</param>
        /// <param name="Method">The <see cref="string"/> containing the Method that will be used when contacting online resources.</param>
        /// <param name="IfModifiedSince">The <see cref="DateTime"/> containing the last known time that the online resource was modified.</param>
        public ExtendedWebClient(CookieContainer CookieContainer, HttpMethod Method, DateTime IfModifiedSince) {
            this.CookieContainer = CookieContainer;
            this.Method = Method;
            this.IfModifiedSince = IfModifiedSince;
        }

        /// <summary>
        /// Destructor for the ExtendedWebClient.
        /// </summary>
        ~ExtendedWebClient() {
            Console.WriteLine("Finalized ExtendedWebClient.");
            CookieContainer = null;
        }

        #endregion

        #region Overrides

        [System.Diagnostics.DebuggerHidden]
        protected override WebRequest GetWebRequest(Uri address) =>
            ManageRequest(base.GetWebRequest(address));

        [System.Diagnostics.DebuggerHidden]
        protected override WebResponse GetWebResponse(WebRequest request) =>
            ManageResponse(base.GetWebResponse(request));

        [System.Diagnostics.DebuggerHidden]
        protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result) =>
            ManageResponse(base.GetWebResponse(request, result));

        #endregion

        #region Override Helpers

        /// <summary>
        /// Manages the <see cref="WebRequest"/> before contacting the online resource.
        /// </summary>
        /// <param name="Request">The <see cref="WebRequest"/> that will be modified to include the extended functionality.</param>
        /// <returns>The modified WebRequest conforming to the extensions.</returns>
        private WebRequest ManageRequest(WebRequest Request) {
            // Check the Method property. Use "GET" if the property is null, empty, or whitespace.
            Request.Method = this.Method.ToString();

            // We're gonna cast it as a HttpWebRequest to add Cookies as well as the IfModifiedSince header.
            if (Request is HttpWebRequest RequestAsHttp) {
                // Set the UserAgent.
                RequestAsHttp.UserAgent = this.UserAgent;

                // Set the CookieContainer.
                RequestAsHttp.CookieContainer = this.CookieContainer;

                // Set the IfModifiedSince header.
                RequestAsHttp.IfModifiedSince = IfModifiedSince;

                // Set the Accept header.
                if (this.Accept != null) {
                    RequestAsHttp.Accept = this.Accept;
                }

                // Whats the significance of this?
                //IfModifiedSince = default;
            }

            // Set the property.
            BuiltRequest = Request;

            // Finally, return the modified request.
            return Request;
        }

        /// <summary>
        /// Manages the <see cref="WebResponse"/> that the class received from the online resource.
        /// <para>This only updates locales of the class, and it does not modify the response in any way.</para>
        /// </summary>
        /// <param name="Response">The <see cref="WebResponse"/> that is given from GetWebResponse methods.</param>
        /// <returns>The same <see cref="WebResponse"/> that was given as an overload, fully unmodified.</returns>
        private WebResponse ManageResponse(WebResponse Response) {
                // Set the property.
                ReceivedResponse = Response;

                // Cast the Response as an HttpWebResponse.
                if (Response is HttpWebResponse ResponseAsHttp) {
                    // Change the local ResourceLastModified to the responses' LastModified property.
                    ResourceLastModified = ResponseAsHttp.LastModified;
                }

                return Response;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a cookie to the local <see cref="CookieContainer"/>.
        /// </summary>
        /// <param name="CookieName">The <see cref="string"/> value of the name of the cookie.</param>
        /// <param name="CookieValue">The <see cref="string"/> value of the value of the cookie.</param>
        public void AddCookie(string CookieName, string CookieValue) {
            if (!string.IsNullOrWhiteSpace(CookieName) && CookieValue is not null) {
                this.CookieContainer.Add(new Cookie(CookieName, CookieValue));
            }
        }

        /// <summary>
        /// Adds a cookie to the local <see cref="CookieContainer"/>.
        /// </summary>
        /// <param name="CookieName">The <see cref="string"/> value of the name of the cookie.</param>
        /// <param name="CookieValue">The <see cref="string"/> value of the value of the cookie.</param>
        /// <param name="CookieDomain">The <see cref="string"/> value of the host for the cookie.</param>
        public void AddCookie(string CookieName, string CookieValue, string CookieDomain) {
            if (!string.IsNullOrWhiteSpace(CookieName) && CookieValue is not null) {
                this.CookieContainer.Add(new Cookie(CookieName, CookieValue) {
                    Domain = CookieDomain
                });
            }
        }

        #endregion

    }

}