namespace System.Diagnostics.CodeAnalysis;
#nullable enable
using global::System;
/// <summary>
///     Specifies that <see langword="null"/> is disallowed as an input even if the
///     corresponding type allows it.
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, Inherited = false)]
[DebuggerNonUserCode]
[ExcludeFromCodeCoverage]
internal sealed class DisallowNullAttribute : Attribute {
    /// <summary>
    ///     Initializes a new instance of the <see cref="DisallowNullAttribute"/> class.
    /// </summary>
    public DisallowNullAttribute() { }
}