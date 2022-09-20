namespace murrty.controls;

using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

internal class ExtendedListView : ListView {
    [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
    private static extern int SetWindowTheme(nint hwnd, string pszSubAppName, string pszSubIdList);

    [Browsable(false)]
    [DefaultValue(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public bool IgnoreSelectionChange {
        get; set;
    } = false;
    protected override void OnItemSelectionChanged(ListViewItemSelectionChangedEventArgs e) {
        if (!IgnoreSelectionChange)
            base.OnItemSelectionChanged(e);
    }
    protected override void OnSelectedIndexChanged(EventArgs e) {
        if (!IgnoreSelectionChange)
            base.OnSelectedIndexChanged(e);
    }
    protected override void OnHandleCreated(EventArgs e) {
        base.OnHandleCreated(e);
        SetWindowTheme(this.Handle, "explorer", null);
    }
    public string GetColumnWidths() {
        StringBuilder Output = new();
        for (int i = 0; i < Columns.Count; i++)
            Output.Append(Columns[i].Width + ",");
        return Output.Remove(Output.Length - 1, 1).ToString();
    }
    public void SetColumnWidths(string ColumnSizes) {
        string[] Values = ColumnSizes.Split(',');

        if (Values.Length > this.Columns.Count)
            Array.Resize(ref Values, this.Columns.Count);

        for (int i = 0; i < Values.Length; i++) {
            if (int.TryParse(Values[i], out int Width))
                this.Columns[i].Width = Width;
        }
    }
}