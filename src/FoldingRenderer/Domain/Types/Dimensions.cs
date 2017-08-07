namespace FoldingRenderer.Domain.Types {
  public class Dimensions {
    public static readonly Dimensions None = new Dimensions();

    public double Width { get; }
    public double Height { get; }

    public Dimensions() : this(0, 0) {}

    Dimensions(double width, double height) {
      Width = width;
      Height = height;
    }

    public Dimensions WithWidth(int width) => new Dimensions(width, Height);
    public Dimensions WithHeight(int height) => new Dimensions(Width, height);
  }
}