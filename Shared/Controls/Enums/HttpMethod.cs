namespace murrty.classcontrols;
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