/* ExtendedWebClient by murrty */

namespace murrty.classcontrols;

using System;
using System.ComponentModel;
using System.Net;

/// <summary>
/// An extended control to include extra usability to the base WebClient class.
/// </summary>
[System.Diagnostics.DebuggerStepThrough]
[ToolboxItem(false)]
internal class ExtendedWebClient : WebClient {

    #region Properties
    /// <summary>
    /// Sets the WebClient METHOD when connecting to the online resource.
    /// <para>Default value is GET.</para>
    /// </summary>
    public HttpMethod Method { get; set; } = HttpMethod.GET;

    /// <summary>
    /// Gets or sets the UserAgent of the WebClient.
    /// </summary>
    public string UserAgent { get; set; } = null;

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
    public ExtendedWebClient() {
        this.Method = HttpMethod.GET;
    }
    /// <summary>
    /// An extended control to include extra usability to the base WebClient class.
    /// </summary>
    /// <param name="Method">The <see cref="string"/> containing the Method that will be used when contacting online resources.</param>
    public ExtendedWebClient(HttpMethod Method) {
        this.Method = Method;
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
        return Response;
    }
    #endregion

}