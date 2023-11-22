namespace System.Diagnostics.CodeAnalysis;
#nullable enable
using global::System;
/// <summary>
///     Specifies that <see langword="null"/> is allowed as an input even if the
///     corresponding type disallows it.
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, Inherited = false)]
[DebuggerNonUserCode]
[ExcludeFromCodeCoverage]
internal sealed class AllowNullAttribute : Attribute {
    /// <summary>
    ///     Initializes a new instance of the <see cref="AllowNullAttribute"/> class.
    /// </summary>
    public AllowNullAttribute() { }
}