namespace youtube_dl_gui_updater;
using System.Windows.Forms;
public partial class frmUpdaterInvalidData : Form {
    public frmUpdaterInvalidData() {
        InitializeComponent();
        LoadLanguage();
        this.Shown += (s, e) => System.Media.SystemSounds.Hand.Play();
    }
    private void LoadLanguage() {
        this.Text = Language.frmUpdaterInvalidData;
        lbUpdaterInvalidData.Text = Language.lbUpdaterInvalidData;
        btnUpdaterInvalidDataUpdateLatest.Text = Language.btnUpdaterInvalidDataUpdateLatest;
        btnUpdaterInvalidDataUpdatePreRelease.Text = Language.btnUpdaterInvalidDataUpdatePreRelease;
        btnUpdaterInvalidDataDoNotUpdate.Text = Language.btnUpdaterInvalidDataDoNotUpdate;
    }
}