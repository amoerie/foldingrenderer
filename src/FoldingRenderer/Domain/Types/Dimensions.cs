using System.Drawing;

namespace FoldingRenderer.Domain.Types {
  public class Dimensions {
    public static readonly Dimensions None = new Dimensions();

    public int Width { get; }
    public int Height { get; }

    public Dimensions() : this(0, 0) {}

    Dimensions(int width, int height) {
      Width = width;
      Height = height;
    }

    public Dimensions WithWidth(int width) => new Dimensions(width, Height);
    public Dimensions WithHeight(int height) => new Dimensions(Width, height);

    public Size ToSize() {
      return new Size(Width, Height);
    }
  }
}