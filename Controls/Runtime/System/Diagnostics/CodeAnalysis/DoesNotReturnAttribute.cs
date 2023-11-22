namespace System.Diagnostics.CodeAnalysis;
#nullable enable
using global::System;
/// <summary>
///     Specifies that a method that will never return under any circumstance.
/// </summary>
[AttributeUsage(AttributeTargets.Method, Inherited = false)]
[DebuggerNonUserCode]
[ExcludeFromCodeCoverage]
internal sealed class DoesNotReturnAttribute : Attribute {
    /// <summary>
    ///     Initializes a new instance of the <see cref="DoesNotReturnAttribute"/> class.
    /// </summary>
    ///
    public DoesNotReturnAttribute() { }
}