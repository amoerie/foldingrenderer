using System.Drawing;

namespace FoldingRenderer.Types {
  public sealed class Position {
    public static readonly Position None = new Position();

    public int X { get; }
    public int Y { get; }

    public Position() : this(0, 0) {}

    Position(int x, int y) {
      X = x;
      Y = y;
    }

    public Position WithX(int x) => new Position(x, Y);
    public Position WithY(int y) => new Position(X, y);

    public Point ToPoint() {
      return new Point(X, Y);
    }

    bool Equals(Position other) {
      return X == other.X && Y == other.Y;
    }

    public override bool Equals(object obj) {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != GetType()) return false;
      return Equals((Position)obj);
    }

    public override int GetHashCode() {
      unchecked {
        return (X * 397) ^ Y;
      }
    }
  }
}