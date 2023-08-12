namespace murrty.controls;

public sealed class HttpException : Exception {
    public System.Net.HttpStatusCode StatusCode { get; }
    public string StatusDescription => GetDescription((int)StatusCode);
    public bool ReportException { get; }
    public byte[] ResponseContent { get; }
    public HttpException(System.Net.HttpStatusCode status)
    : base($"The remote server returned an error: {(int)status} - {GetDescription((int)status)}") {
        StatusCode = status;
        ReportException = (int)status < 300;
        ResponseContent = Array.Empty<byte>();
    }
    public HttpException(System.Net.HttpStatusCode status, byte[] responseContent) {
        StatusCode = status;
        ReportException = (int)status < 300;
        this.ResponseContent = responseContent;
    }
    private static string GetDescription(int status) {
        return status switch {
            100 => "Continue",
            101 => "Switching protocols",
            102 => "Processing",
            103 => "Early hints",

            200 => "Ok",
            201 => "Created",
            202 => "Accepted",
            203 => "Non-authoritative information",
            204 => "No content",
            205 => "Reset content",
            206 => "Partial content",
            207 => "Multi-status",
            208 => "Already reported",
            226 => "I'm used",

            300 => "Multiple choices",
            301 => "Moved permanently",
            302 => "Found",
            303 => "See other",
            304 => "Not modified",
            305 => "Use proxy",
            307 => "Temporary redirect",
            308 => "Permanent redirect",

            400 => "Bad request",
            401 => "Unauthorized",
            402 => "Payment required",
            403 => "Forbidden",
            404 => "Not found",
            405 => "Method not allowed",
            406 => "Not acceptable",
            407 => "Proxy authentication required",
            408 => "Request timeout",
            409 => "Conflict",
            410 => "Gone",
            411 => "Length required",
            412 => "Precondition failed",
            413 => "Request entity too large",
            414 => "Request-uri too long",
            415 => "Unsupported media type",
            416 => "Requested range not satisfiable",
            417 => "Expectation failed",
            419 => "Teapot",
            421 => "Misdirected request",
            422 => "Unprocessable entity",
            423 => "Locked",
            424 => "Failed dependency",
            426 => "Upgrade required", // RFC 2817
            428 => "Precondition required",
            429 => "Too many requests",
            431 => "Request header fields too large",
            451 => "Unavailable for legal reasons",

            500 => "Internal server error",
            501 => "Not implemented",
            502 => "Bad gateway",
            503 => "Service unavailable",
            504 => "Gateway timeout",
            505 => "Http version not supported",
            506 => "Variant also negotiates",
            507 => "Insufficient storage",
            508 => "Loop detected",
            510 => "Not extended",
            511 => "Network authentication required",

            _ => $"Unknown status code {status}",
        };
    }
}