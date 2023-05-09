namespace youtube_dl_gui;
using System.Security.Cryptography;
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
    public string Username { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the encrypted password associated with this authentication instance.
    /// </summary>
    public byte[] Password { get; set; } = new byte[0];
    /// <summary>
    /// Gets or sets the two-factor password associated with this authentication instance.
    /// </summary>
    public string TwoFactor { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the encrypted password to access the media associated with this authentication instance.
    /// </summary>
    public byte[] MediaPassword { get; set; } = new byte[0];
    /// <summary>
    /// Gets or sets whether this authentication instance will rely on netrc for authentication.
    /// </summary>
    public bool NetRC { get; set; } = false;
    /// <summary>
    /// Gets or sets the cookies file for the authentication instance.
    /// </summary>
    public string CookiesFile { get; set; } = string.Empty; 
    /// <summary>
    /// Gets or sets browsers from the browser for this authentication instance.
    /// </summary>
    public string CookiesFromBrowser { get; set; } = string.Empty;

    /// <summary>
    /// Initializes an empty <see cref="AuthenticationDetails"/> instance.
    /// </summary>
    public AuthenticationDetails() { }
    /// <summary>
    /// Initializes a new <see cref="AuthenticationDetails"/> instance.
    /// </summary>
    /// <param name="Username">The username for the authentication process.</param>
    /// <param name="Password">The password for the authentication process. This value will be set to <see cref="string.Empty"/> after conversion.</param>
    public AuthenticationDetails(string Username, ref string Password) {
        this.Username = Username;
        SetPassword(Password);
        Password = string.Empty;
    }
    /// <summary>
    /// Initializes a new <see cref="AuthenticationDetails"/> instance.
    /// </summary>
    /// <param name="Username">The username for the authentication process.</param>
    /// <param name="Password">The password for the authentication process. This value will be set to <see cref="string.Empty"/> after conversion.</param>
    /// <param name="TwoFactor">The two-factor authentication for the authentication process.</param>
    public AuthenticationDetails(string Username, ref string Password, string TwoFactor) :
    this(Username, ref Password) {
        this.TwoFactor = TwoFactor;
    }
    /// <summary>
    /// Initializes a new <see cref="AuthenticationDetails"/> instance.
    /// </summary>
    /// <param name="Username">The username for the authentication process.</param>
    /// <param name="Password">The password for the authentication process. This value will be set to <see cref="string.Empty"/> after conversion.</param>
    /// <param name="TwoFactor">The two-factor authentication for the authentication process.</param>
    /// <param name="MediaPassword">The password to access the media for the authentication process. This value will be set to <see cref="string.Empty"/> after conversion.</param>
    public AuthenticationDetails(string Username, ref string Password, string TwoFactor, ref string MediaPassword) :
    this(Username, ref Password, TwoFactor) {
        SetMediaPassword(MediaPassword);
        MediaPassword = string.Empty;
    }

    /// <summary>
    /// Sets the password for the authentication details.
    /// </summary>
    /// <param name="password">The password that will be encrypted.</param>
    public void SetPassword(string password) {
        byte[] passBytes = Encoding.UTF8.GetBytes(password);
        Password = ProtectedData.Protect(
            userData: passBytes,
            optionalEntropy: null,
            scope: DataProtectionScope.CurrentUser);
        Array.Clear(passBytes, 0, passBytes.Length);
    }

    /// <summary>
    /// Sets the media password for the authentication details.
    /// </summary>
    /// <param name="password">The password that will be encrypted.</param>
    public void SetMediaPassword(string password) {
        byte[] passBytes = Encoding.UTF8.GetBytes(password);
        MediaPassword = ProtectedData.Protect(
            userData: passBytes,
            optionalEntropy: null,
            scope: DataProtectionScope.CurrentUser);
        Array.Clear(passBytes, 0, passBytes.Length);
    }

    /// <summary>
    /// Attempts to get the password from the secure string.
    /// </summary>
    /// <returns>A decrypted string if there is a password set; otherwise, an empty string.</returns>
    public string GetPassword() {
        if (Password.Length > 0) {
            return Encoding.UTF8.GetString(ProtectedData.Unprotect(
                encryptedData: Password,
                optionalEntropy: null,
                scope: DataProtectionScope.CurrentUser));
        }
        return string.Empty;
    }

    /// <summary>
    /// Attempts to get the media password from the secure string.
    /// </summary>
    /// <returns>A decrypted string if there is a password set; otherwise, an empty string.</returns>
    public string GetMediaPassword() {
        if (MediaPassword.Length > 0) {
            return Encoding.UTF8.GetString(ProtectedData.Unprotect(
                encryptedData: MediaPassword,
                optionalEntropy: null,
                scope: DataProtectionScope.CurrentUser));

            //nint Address = Marshal.SecureStringToBSTR(MediaPassword);
            //return Marshal.PtrToStringBSTR(Address);
        }
        return string.Empty;
    }

    /// <summary>
    /// Duplicates this media authentication instance.
    /// </summary>
    /// <returns>A new instance of <see cref="AuthenticationDetails"/> with duplicate data within this one.</returns>
    public AuthenticationDetails Clone() {
        AuthenticationDetails clone = new() {
            Username = this.Username,
            Password = new byte[this.Password.Length],
            TwoFactor = this.TwoFactor,
            MediaPassword = new byte[this.MediaPassword.Length],
            NetRC = this.NetRC,
            CookiesFile = this.CookiesFile,
            CookiesFromBrowser = this.CookiesFromBrowser,
        };

        if (this.Password.Length > 0)
            Array.Copy(this.Password, clone.Password, this.Password.Length);

        if (this.MediaPassword.Length > 0)
            Array.Copy(this.MediaPassword, clone.MediaPassword, this.MediaPassword.Length);

        return clone;
    }

    /// <summary>
    /// Displays the authentication form to gather authentication details for the media.
    /// </summary>
    /// <returns>An instance of the <see cref="AuthenticationDetails"/> class with user authentication available.</returns>
    public static AuthenticationDetails GetAuthentication() {
        using frmAuthentication Authenticator = new();
        if (Authenticator.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            return null;

        return Authenticator.Authentication;
    }
}