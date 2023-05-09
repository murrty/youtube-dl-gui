namespace youtube_dl_gui;
/// <summary>
/// Represents a localized form that has text that is dependant on the loaded language.
/// </summary>
internal interface ILocalizedForm {
    /// <summary>
    /// Applies the localized text onto controls.
    /// </summary>
    public void LoadLanguage();

    /// <summary>
    /// Registers the form to the language callback.
    /// </summary>
    public void RegisterLocalizedForm();

    /// <summary>
    /// Unregisters the form from the language callback.
    /// </summary>
    public void UnregisterLocalizedForm();
}