using System.Drawing;

namespace FoldingRenderer.Domain.Types {
  public class Position {
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
  }
}