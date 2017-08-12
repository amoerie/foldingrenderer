using System;
using System.Drawing;

namespace FoldingRenderer.Drawing {
  public interface ICanvas {
    Bitmap Bitmap { get; }
  }

  public class Canvas : ICanvas {
    public Canvas(Bitmap bitmap) {
      if (bitmap == null) throw new ArgumentNullException(nameof(bitmap));
      Bitmap = bitmap;
    }

    public Bitmap Bitmap { get; }
  }
}
