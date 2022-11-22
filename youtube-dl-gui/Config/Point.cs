namespace murrty.structs;
using System.Runtime.InteropServices;
[StructLayout(LayoutKind.Sequential)]
public struct Point {
    /// <summary>
    /// Represents an invalid Point value that is considered invalid values for window locations in which the X and Y values are -32,000.
    /// </summary>
    public static readonly Point Invalid = new(-32_000, -32_000);

    /// <summary>
    /// Represents an empty <see cref="Point"/> structure that has the X and Y values initialized to 0.
    /// </summary>
    public static readonly Point Empty = new(0, 0);

    /// <summary>
    /// The X-coordinate of the Point.
    /// </summary>
    public int X {
        get; set;
    }

    /// <summary>
    /// The Y-coordinate of the Point.
    /// </summary>
    public int Y {
        get; set;
    }

    /// <summary>
    /// Whether the <see cref="Point"/> can be considered a valid <see cref="Point"/> compared to <see cref="Invalid"/>.
    /// </summary>
    public bool Valid => this.X != Invalid.X && this.Y != Invalid.Y;

    public Point() {
        X = 0;
        Y = 0;
    }

    public Point(int X, int Y) {
        this.X = X;
        this.Y = Y;
    }

    /// <inheritdoc />
    public override bool Equals(object obj) => obj is Point point && this.X == point.X && this.Y == point.Y;

    /// <inheritdoc />
    public override int GetHashCode() {
        int hashCode = 1861411795;
        hashCode = hashCode * -1521134295 + this.X.GetHashCode();
        hashCode = hashCode * -1521134295 + this.Y.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(Point a, Point b) => a.X == b.X && a.Y == b.Y;

    public static bool operator !=(Point a, Point b) => a.X != b.X || a.Y != b.Y;

    /// <summary>
    /// Implicitly converts this Point structure to a System.Drawing.Point structure.
    /// </summary>
    /// <param name="p"></param>
    public static implicit operator System.Drawing.Point(Point p) => new(p.X, p.Y);

    /// <summary>
    /// Implicity converts a System.Drawing.Point structure to this Point structure.
    /// </summary>
    /// <param name="p"></param>
    public static implicit operator Point(System.Drawing.Point p) => new(p.X, p.Y);
}