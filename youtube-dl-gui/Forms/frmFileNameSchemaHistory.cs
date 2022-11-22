namespace youtube_dl_gui;
using System.Windows.Forms;
public partial class frmFileNameSchemaHistory : Form {
    public string NewSchema { get; private set; }

    public frmFileNameSchemaHistory() {
        InitializeComponent();
        this.Text = Language.frmFileNameSchemaHistory;
        btnSave.Text = Language.GenericSave;
        btnCancel.Text = Language.GenericCancel;
    }

    private void frmFileNameSchemaHistory_Load(object sender, EventArgs e) {
        if (!Config.Settings.Saved.FileNameSchemaHistory.IsNullEmptyWhitespace())
            listHistory.Items.AddRange(Config.Settings.Saved.FileNameSchemaHistory.Split('|'));
    }

    private void listHistory_SelectedIndexChanged(object sender, EventArgs e) {
        if (listHistory.SelectedIndex > -1) {
            txtSchema.Text = listHistory.Items[listHistory.SelectedIndex] as string;
            btnRemove.Enabled = btnUpdate.Enabled = true;
        }
    }

    private void btnAdd_Click(object sender, EventArgs e) {
        if (!listHistory.Items.Contains(txtSchema.Text))
            listHistory.Items.Add(txtSchema.Text);
    }

    private void btnRemove_Click(object sender, EventArgs e) {
        if (listHistory.SelectedIndex > -1)
            listHistory.Items.RemoveAt(listHistory.SelectedIndex);
    }

    private void btnUpdate_Click(object sender, EventArgs e) {
        if (listHistory.SelectedIndex > -1)
            listHistory.Items[listHistory.SelectedIndex] = txtSchema.Text;
    }

    private void btnCancel_Click(object sender, EventArgs e) {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    private void btnSave_Click(object sender, EventArgs e) {
        if (!listHistory.Items.Contains(Config.Settings.Downloads.fileNameSchema))
            listHistory.Items.Add(Config.Settings.Downloads.fileNameSchema);

        NewSchema = listHistory.Items.Cast<string>().Join("|");
        this.DialogResult = Config.Settings.Saved.FileNameSchemaHistory != NewSchema ? DialogResult.OK : DialogResult.Cancel;
        this.Close();
    }
}