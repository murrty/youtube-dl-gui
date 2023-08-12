namespace System.Runtime.CompilerServices;

internal static class RuntimeHelpers {
    /// <summary>
    /// Slices the specified array using the specified range.
    /// </summary>
    public static T[] GetSubArray<T>(T[] array, Range range) {
        if (array == null) {
            throw new ArgumentNullException();
        }

        (int offset, int length) = range.GetOffsetAndLength(array.Length);

        // T_DO-NULLABLE: default(T) == null warning (https://github.com/dotnet/roslyn/issues/34757)
        if (default(T)! != null || typeof(T[]) == array.GetType()) {
            // We know the type of the array to be exactly T[].

            if (length == 0) {
                return Array.Empty<T>();
            }

            var dest = new T[length];
            Array.Copy(array, offset, dest, 0, length);
            return dest;
        }
        else {
            // The array is actually a U[] where U:T.
            T[] dest = (T[])Array.CreateInstance(array.GetType().GetElementType()!, length);
            Array.Copy(array, offset, dest, 0, length);
            return dest;
        }
    }
}