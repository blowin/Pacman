namespace Pacman.Console;

public readonly struct IntVector2 : IEquatable<IntVector2>
{
    public static IntVector2 Zero => new IntVector2(0, 0);
    
    public int X { get; }
    public int Y { get; }

    public IntVector2(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static IntVector2 operator +(IntVector2 lft, IntVector2 rgt) => new(lft.X + rgt.X, lft.Y + rgt.Y);
    
    public static IntVector2 operator -(IntVector2 lft, IntVector2 rgt) => new(lft.X + rgt.X, lft.Y + rgt.Y);
    
    public bool Equals(IntVector2 other) => X == other.X && Y == other.Y;

    public override bool Equals(object? obj) => obj is IntVector2 other && Equals(other);

    public override int GetHashCode() => HashCode.Combine(X, Y);
}