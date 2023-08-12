namespace murrty.logging;

using System.Windows.Forms;
using youtube_dl_gui;

internal partial class frmLog : Form, ILocalizedForm {
    public bool IsShown {
        get; private set;
    } = false;

    public frmLog() {
        InitializeComponent();

        if (!Program.DebugMode)
            btnTestLine.Enabled = btnTestLine.Visible = false;

        // The icon for the exception form.
        this.Icon = global::youtube_dl_gui.Properties.Resources.ProgramIcon;

        lbLines.Dispose();
        rtbLog.ContextMenu = cmLog;

        Language.RegisterForm(this);
    }
    private void frmLog_Load(object sender, EventArgs e) {
        if (Saved.LogLocation.Valid) {
            this.StartPosition = FormStartPosition.Manual;
            this.Location = Saved.LogLocation;
        }

        if (Saved.LogSize.Valid)
            this.Size = Saved.LogSize;
    }
    private void frmLog_FormClosing(object sender, FormClosingEventArgs e) {
        e.Cancel = true;
        this.Hide();
        IsShown = false;
        Language.UnregisterForm(this);
    }

    public void LoadLanguage() {
        this.Text = Language.frmLog;
        tpMainLog.Text = Language.frmLog;
        tpExceptions.Text = Language.frmLogExceptions;
        lbExceptionDetails.Text = Language.lbLogPastExceptions;
        btnRemoveException.Text = Language.GenericRemove;
        btnClear.Text = Language.frmLogClear;
        btnClose.Text = Language.GenericClose;
    }
    public string GetFormName() => this.Name;

    private void mCopyText_Click(object sender, EventArgs e) {
        if (tcMain.SelectedTab == tpMainLog) {
            if (rtbLog.SelectionLength > 0) {
                rtbLog.Copy();
            }
        }
        else if (tcMain.SelectedTab == tpExceptions) {
            if (tcExceptions.SelectedTab != null) {
                Control[] ex = tcExceptions.SelectedTab.Controls.Find("TextBox", false);
                if (ex.Length > 0 && ex[0] is TextBox txt) {
                    if (txt.SelectionLength > 0) {
                        txt.Copy();
                    }
                }
            }
        }
    }
    private void btnClear_Click(object sender, EventArgs e) {
        rtbLog.Clear();
        Append("Log has been cleared");
    }
    private void btnRemoveException_Click(object sender, EventArgs e) {
        if (tcExceptions.SelectedTab is not null) {
            Control[] ex = tcExceptions.SelectedTab.Controls.Find("TextBox", false);
            if (ex.Length > 0 && ex[0] is TextBox txt)
                txt.Dispose();

            int Index = tcExceptions.SelectedIndex;
            if (tcExceptions.TabCount > 1)
                tcExceptions.SelectTab(
                    tcExceptions.TabCount > 0 ? Index + 1 < tcExceptions.TabCount ?
                    Index + 1 : Index - 1 : 0);

            tcExceptions.TabPages[Index].Dispose();
            btnRemoveException.Enabled = tcExceptions.TabCount > 0;
        }
    }
    private void btnClose_Click(object sender, EventArgs e) {
        this.Hide();
        IsShown = false;
    }

    /// <summary>
    /// Displays the log.
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public void ShowLog() {
        if (!IsShown) {
            this.Show();

            this.Text = Language.frmLog;
            btnClear.Text = Language.frmLogClear;
            btnClose.Text = Language.GenericClose;

            IsShown = true;
        }
        else {
            this.Activate();
        }
    }

    /// <summary>
    /// Hides the log.
    /// </summary>
    [System.Diagnostics.DebuggerStepThrough]
    public void HideLog() {
        if (IsShown) {
            this.Hide();
            IsShown = false;
        }
    }

    /// <summary>
    /// Appends text to the log.
    /// </summary>
    /// <param name="message">The message to append.</param>
    [System.Diagnostics.DebuggerStepThrough]
    public void Append(string message) {
        if (rtbLog.InvokeRequired)
            rtbLog.Invoke(() => rtbLog.AppendText($"[{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff}] {message}", true));
        else
            rtbLog.AppendText($"[{DateTime.Now:yyyy/MM/dd HH:mm:ss.fff}] {message}", true);
    }

    /// <summary>
    /// Appends text to the log, not including date/time of the message.
    /// </summary>
    /// <param name="message">The message to append.</param>
    [System.Diagnostics.DebuggerStepThrough]
    public void AppendNoDate(string message) {
        if (rtbLog.InvokeRequired)
            rtbLog.Invoke(() => rtbLog.AppendText(message, true));
        else
            rtbLog.AppendText(message, true);
    }

    /// <summary>
    /// Adds a new exception to the log.
    /// </summary>
    /// <param name="type">The exception type</param>
    /// <param name="exception">The inner exception details.</param>
    [System.Diagnostics.DebuggerStepThrough]
    public void AddException(ExceptionInfo Exception) {
        TabPage ExceptionPage = new($"{Exception.Exception.GetType().Name} @ {Exception.ExceptionTime:yyyy/MM/dd HH:mm:ss.fff}");
        TextBox ExceptionDetails = new() {
            Multiline = true,
            ReadOnly = true,
            Name = "TextBox"
        };
        ExceptionPage.Controls.Add(ExceptionDetails);
        ExceptionDetails.Dock = DockStyle.Fill;
        ExceptionDetails.Text = $$"""
            A {{Exception.ExceptionType switch {
                ExceptionType.Caught => "caught ",
                ExceptionType.Unhandled => "unhandled ",
                ExceptionType.ThreadException => "thread-exception ",
                _ => ""
            }}}{{Exception.Exception.GetType().Name}} occurred.

            {{Exception.Exception.GetType().FullName}} -> {{Exception.Exception.Source}}
            {{Exception.Exception.StackTrace}}
            """;
        ExceptionDetails.ContextMenu = cmLog;
        ExceptionDetails.Font = rtbLog.Font;
        tcExceptions.TabPages.Add(ExceptionPage);
        tcExceptions.SelectedTab = ExceptionPage;
        btnRemoveException.Enabled = tcExceptions.TabCount > 0;
    }

    private void btnTestLine_Click(object sender, EventArgs e) {
        rtbLog.AppendLine("Hello!");
    }

}