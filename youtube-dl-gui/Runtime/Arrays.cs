namespace System;

using System.Diagnostics.Contracts;
using System.Runtime.ConstrainedExecution;

internal static class Arrays {
    [Pure]
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
    public static T[] Empty<T>() {
        Contract.Ensures(Contract.Result<T[]>() != null);
        Contract.Ensures(Contract.Result<T[]>().Length == 0);
        Contract.EndContractBlock();

        return EmptyArray<T>.Value;
    }
    internal static class EmptyArray<T> {
        public static readonly T[] Value = new T[0];
    }
}