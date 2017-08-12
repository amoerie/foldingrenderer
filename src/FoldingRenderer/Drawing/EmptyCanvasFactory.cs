using System.Drawing;
using FoldingRenderer.Types;

namespace FoldingRenderer.Drawing {
  public interface IEmptyCanvasFactory {
    ICanvas Create(Dimensions dimensions);
  }

  public class EmptyCanvasFactory : IEmptyCanvasFactory {
    public ICanvas Create(Dimensions dimensions) {
      var canvas = new Canvas(new Bitmap(dimensions.Width, dimensions.Height));

      using (var graphics = Graphics.FromImage(canvas.Bitmap)) {
        graphics.Clear(Color.White);
      }

      return canvas;
    }
  }
}