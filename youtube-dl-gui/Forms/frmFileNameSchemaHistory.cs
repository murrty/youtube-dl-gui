namespace youtube_dl_gui;
using System.Windows.Forms;
public partial class frmFileNameSchemaHistory : LocalizedForm {
    public string NewSchema { get; private set; }
    public frmFileNameSchemaHistory() {
        InitializeComponent();
        LoadLanguage();

        this.Load += (s, e) => {
            if (Saved.FileNameSchemaHistoryLocation.Valid) {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Saved.FileNameSchemaHistoryLocation;
            }

            if (Saved.FileNameSchemaHistorySize.Valid)
                this.Size = Saved.FileNameSchemaHistorySize;

            if (!Saved.FileNameSchemaHistory.IsNullEmptyWhitespace())
                listHistory.Items.AddRange(Saved.FileNameSchemaHistory.Split('|'));
        };
        this.FormClosed += (s, e) => {
            Saved.FileNameSchemaHistoryLocation = this.Location;
            Saved.FileNameSchemaHistorySize = this.Size;
        };
    }
    public override void LoadLanguage() {
        this.Text = Language.frmFileNameSchemaHistory;
        btnSave.Text = Language.GenericSave;
        btnCancel.Text = Language.GenericCancel;
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
        if (listHistory.SelectedIndex > -1) {
            listHistory.Items.RemoveAt(listHistory.SelectedIndex);
            txtSchema.Clear();
        }
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
        if (!listHistory.Items.Contains(Downloads.fileNameSchema))
            listHistory.Items.Add(Downloads.fileNameSchema);

        NewSchema = listHistory.Items.Cast<string>().Join("|");
        this.DialogResult = Saved.FileNameSchemaHistory != NewSchema ? DialogResult.OK : DialogResult.Cancel;
        this.Close();
    }
}