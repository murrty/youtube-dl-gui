namespace System.Diagnostics.CodeAnalysis;
#nullable enable
using global::System;
/// <summary>
///     Specifies that the output will be non-<see langword="null"/> if the
///     named parameter is non-<see langword="null"/>.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue, AllowMultiple = true, Inherited = false)]
[DebuggerNonUserCode]
[ExcludeFromCodeCoverage]
internal sealed class NotNullIfNotNullAttribute : Attribute {
    /// <summary>
    ///     Gets the associated parameter name.
    ///     The output will be non-<see langword="null"/> if the argument to the
    ///     parameter specified is non-<see langword="null"/>.
    /// </summary>
    public string ParameterName { get; }

    /// <summary>
    ///     Initializes the attribute with the associated parameter name.
    /// </summary>
    /// <param name="parameterName">
    ///     The associated parameter name.
    ///     The output will be non-<see langword="null"/> if the argument to the
    ///     parameter specified is non-<see langword="null"/>.
    /// </param>
    public NotNullIfNotNullAttribute(string parameterName) {
        ParameterName = parameterName;
    }
}