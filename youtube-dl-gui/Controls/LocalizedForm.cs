namespace youtube_dl_gui;
using System;
using System.Windows.Forms;
public class LocalizedForm : Form, ILocalizedForm {
    // This is supposed to be overridden.
    public virtual void LoadLanguage() {
        throw new InvalidProgramException("Method LoadLanguage was not overridden.");
    }
    public string GetFormName() => this.Name;
    /// <inheritdoc/>
    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        Language.RegisterForm(this);
    }
    /// <inheritdoc/>
    protected override void OnFormClosing(FormClosingEventArgs e) {
        base.OnFormClosing(e);
        if (!e.Cancel)
            Language.UnregisterForm(this);
    }
}

/// <summary>
/// Represents a localized form that has text that is dependant on the loaded language.
/// </summary>
internal interface ILocalizedForm {
    /// <summary>
    /// Applies the localized text onto controls.
    /// </summary>
    public void LoadLanguage();
    public string GetFormName();
}