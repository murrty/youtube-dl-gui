namespace youtube_dl_gui;
using System.Windows.Forms;
public partial class frmAuthentication : Form, ILocalizedForm {

    /// <summary>
    /// Gets or sets the authentication data for the instance.
    /// </summary>
    public AuthenticationDetails Authentication { get; set; }

    public frmAuthentication() {
        InitializeComponent();
        LoadLanguage();

        this.Load += (s, e) => RegisterLocalizedForm();
        this.FormClosing += (s, e) => UnregisterLocalizedForm();
    }
    public frmAuthentication(AuthenticationDetails Details) : this() => Authentication = Details;

    public void LoadLanguage() {
        this.Text = Language.frmAuthentication;
        lbAuthNotice.Text = Language.lbAuthNotice;
        lbAuthUsername.Text = Language.lbAuthUsername;
        lbAuthPassword.Text = Language.lbAuthPassword;
        lbAuth2Factor.Text = Language.lbAuth2Factor;
        lbAuthVideoPassword.Text = Language.lbAuthVideoPassword;
        chkAuthUseNetrc.Text = Language.chkAuthUseNetrc;
        lbAuthCookiesFromFile.Text = Language.lbAuthCookiesFromFile;
        lbAuthCookiesFromBrowser.Text = Language.lbAuthCookiesFromBrowser;
        lbAuthNoSave.Text = Language.lbAuthNoSave;
        btnAuthBeginDownload.Text = Language.btnAuthBeginDownload;
        btnAuthGenericCancel.Text = Language.GenericCancel;

        chkAuthUseNetrc.Location = new(
            //(this.Size.Width - chkAuthUseNetrc.Size.Width) / 2,
            (this.ClientSize.Width - chkAuthUseNetrc.Size.Width) / 2,
            chkAuthUseNetrc.Location.Y
        );
    }
    public void RegisterLocalizedForm() => Language.RegisterForm(this);
    public void UnregisterLocalizedForm() => Language.UnregisterForm(this);

    private void chkPasswordVisible_CheckedChanged(object sender, EventArgs e) {
        txtPassword.PasswordChar = chkPasswordVisible.Checked ? '\0' : '●';
    }
    private void chkVideoPassVisible_CheckedChanged(object sender, EventArgs e) {
        txtVideoPassword.PasswordChar = chkVideoPassVisible.Checked ? '\0' : '●';
    }
    private void btnAuthBeginDownload_Click(object sender, EventArgs e) {
        Authentication = new();

        if (!txtUsername.Text.IsNullEmptyWhitespace()) {
            Authentication.Username = txtUsername.Text;
            txtUsername.Text = string.Empty;
        }
        if (!txtPassword.Text.IsNullEmptyWhitespace()) {
            Authentication.SetPassword(txtPassword.Text);
            txtPassword.Text = string.Empty;
        }
        if (!txt2Factor.Text.IsNullEmptyWhitespace()) {
            Authentication.TwoFactor = txt2Factor.Text;
            txt2Factor.Text = string.Empty;
        }
        if (!txtVideoPassword.Text.IsNullEmptyWhitespace()) {
            Authentication.SetMediaPassword(txtVideoPassword.Text);
            txtVideoPassword.Text = string.Empty;
        }
        if (!txtCookiesFile.Text.IsNullEmptyWhitespace() && System.IO.File.Exists(txtCookiesFile.Text)) {
            Authentication.CookiesFile = txtCookiesFile.Text;
            txtCookiesFile.Text = string.Empty;
        }
        if (!txtCookiesFromBrowser.Text.IsNullEmptyWhitespace()) {
            Authentication.CookiesFromBrowser = txtCookiesFromBrowser.Text;
            txtCookiesFromBrowser.Text = string.Empty;
        }
        Authentication.NetRC = chkAuthUseNetrc.Checked;

        this.DialogResult = DialogResult.OK;
    }
    private void btnAuthGenericCancel_Click(object sender, EventArgs e) {
        txtUsername.Text = string.Empty;
        txtPassword.Text = string.Empty;
        txt2Factor.Text = string.Empty;
        txtVideoPassword.Text = string.Empty;
        chkAuthUseNetrc.Checked = false;
        this.DialogResult = DialogResult.Cancel;
    }

    private void llCookiesFromBrowserHint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {

    }
}