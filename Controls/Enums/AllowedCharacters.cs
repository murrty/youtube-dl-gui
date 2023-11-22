#nullable enable
namespace murrty.controls;

/// <summary>
/// An enumeration of types of characters allowed in the textbox.
/// </summary>
public enum AllowedCharacters {
    /// <summary>
    /// All characters are allowed.
    /// </summary>
    All,
    /// <summary>
    /// Only Upper and lowercase alphabetical letters are allowed.
    /// </summary>
    AlphabeticalOnly,
    /// <summary>
    /// Only numbers are allowed.
    /// </summary>
    NumericOnly,
    /// <summary>
    /// Only letters and numbers are allowed.
    /// </summary>
    AlphaNumericOnly,
    /// <summary>
    /// Only characters in the Unfiltered Characters array are allowed.
    /// </summary>
    UnfilteredCharactersOnly,
}
