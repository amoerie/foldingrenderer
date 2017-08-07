namespace FoldingRenderer.Domain.Types {
  public class Position {
    public static readonly Position None = new Position();

    public double X { get; }
    public double Y { get; }

    public Position() : this(0, 0) {}

    Position(double x, double y) {
      X = x;
      Y = y;
    }

    public Position WithX(double x) => new Position(x, Y);
    public Position WithY(double y) => new Position(X, y);
  }
}