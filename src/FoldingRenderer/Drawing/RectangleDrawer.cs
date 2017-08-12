using System.Drawing;

namespace FoldingRenderer.Drawing {
  public interface IRectangleDrawer {
    ICanvas Draw(ICanvas canvas, Rectangle rectangle);
  }

  public class RectangleDrawer : IRectangleDrawer {
    public ICanvas Draw(ICanvas canvas, Rectangle rectangle) {
      Pen blackPen = new Pen(Color.Black, 3);

      using (var graphics = Graphics.FromImage(canvas.Bitmap)) {
        graphics.DrawRectangle(blackPen, rectangle);
      }

      return canvas;
    }
  }
}