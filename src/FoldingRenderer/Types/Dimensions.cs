using System.Drawing;

namespace FoldingRenderer.Types {
  public sealed class Dimensions {
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

    bool Equals(Dimensions other) {
      return Width == other.Width && Height == other.Height;
    }

    public override bool Equals(object obj) {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((Dimensions)obj);
    }

    public override int GetHashCode() {
      unchecked {
        return (Width * 397) ^ Height;
      }
    }
  }
}