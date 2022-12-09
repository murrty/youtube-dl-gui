namespace youtube_dl_gui;
using System.Runtime.InteropServices;
using System.Security;
/// <summary>
/// Represents authentication information for an instance of accessing media.
/// </summary>
public class AuthenticationDetails {
    /// <summary>
    /// Returns an empty <see cref="AuthenticationDetails"/> instance.
    /// </summary>
    public static readonly AuthenticationDetails Default = new();
    
    /// <summary>
    /// Gets or sets the username associated with this authentication instance.
    /// </summary>
    public string Username { get; set; }
    /// <summary>
    /// Gets or sets the password associated with this authentication instance.
    /// </summary>
    public SecureString Password { get; set; }
    /// <summary>
    /// Gets or sets the two-factor password associated with this authentication instance.
    /// </summary>
    public string TwoFactor { get; set; }
    /// <summary>
    /// Gets or sets the password to access the media associated with this authentication instance.
    /// </summary>
    public SecureString MediaPassword { get; set; }
    /// <summary>
    /// Gets or sets whether this authentication instance will rely on netrc for authentication.
    /// </summary>
    public bool NetRC { get; set; }
    /// <summary>
    /// Gets or sets the cookies file for the authentication instance.
    /// </summary>
    public string CookiesFile { get; set; }
    /// <summary>
    /// Gets or sets browsers from the browser for this authentication instance.
    /// </summary>
    public string CookiesFromBrowser { get; set; }

    /// <summary>
    /// Initializes an empty <see cref="AuthenticationDetails"/> instance.
    /// </summary>
    public AuthenticationDetails() {
        Username = string.Empty;
        Password = null;
        TwoFactor = string.Empty;
        MediaPassword = null;
        NetRC = false;
        CookiesFile = string.Empty;
        CookiesFromBrowser = string.Empty;
    }
    /// <summary>
    /// Initializes a new <see cref="AuthenticationDetails"/> instance.
    /// </summary>
    /// <param name="Username">The username for the authentication process.</param>
    /// <param name="Password">The password for the authentication process. This value will be set to <see cref="string.Empty"/> after conversion.</param>
    public AuthenticationDetails(string Username, ref string Password) {
        this.Username = Username;

        this.Password = new();
        for (int i = 0; i < Password.Length; i++)
            this.Password.AppendChar(Password[i]);

        Password = string.Empty;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Username">The username for the authentication process.</param>
    /// <param name="Password">The password for the authentication process. This value will be set to <see cref="string.Empty"/> after conversion.</param>
    /// <param name="TwoFactor"></param>
    public AuthenticationDetails(string Username, ref string Password, string TwoFactor) : this(Username, ref Password) {
        this.TwoFactor = TwoFactor;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Username">The username for the authentication process.</param>
    /// <param name="Password">The password for the authentication process. This value will be set to <see cref="string.Empty"/> after conversion.</param>
    /// <param name="TwoFactor"></param>
    /// <param name="MediaPassword">The password to access the media for the authentication process. This value will be set to <see cref="string.Empty"/> after conversion.</param>
    public AuthenticationDetails(string Username, ref string Password, string TwoFactor, ref string MediaPassword) : this(Username, ref Password, TwoFactor) {
        this.MediaPassword = new();
        for (int i = 0; i < MediaPassword.Length; i++)
            this.MediaPassword.AppendChar(MediaPassword[i]);

        MediaPassword = string.Empty;
    }

    /// <summary>
    /// Attempts to get the password from the secure string.
    /// </summary>
    /// <returns>A decrypted secure string if there is a password set; otherwise, an empty string.</returns>
    public string GetPassword() {
        if (Password.Length > 0) {
            nint Address = Marshal.SecureStringToBSTR(Password);
            return Marshal.PtrToStringBSTR(Address);
        }
        return string.Empty;
    }
    /// <summary>
    /// Attempts to get the media password from the secure string.
    /// </summary>
    /// <returns>A decrypted secure string if there is a password set; otherwise, an empty string.</returns>
    public string GetMediaPassword() {
        if (MediaPassword.Length > 0) {
            nint Address = Marshal.SecureStringToBSTR(MediaPassword);
            return Marshal.PtrToStringBSTR(Address);
        }
        return string.Empty;
    }
}