using System.Drawing;

namespace FoldingRenderer.Drawing {
  public interface IPanelRectangleDrawer {
    ICanvas Draw(ICanvas canvas, PanelRectangle panelRectangle);
  }

  public class PanelRectangleDrawer : IPanelRectangleDrawer {
    public ICanvas Draw(ICanvas canvas, PanelRectangle panelRectangle) {
      Pen blackPen = new Pen(Color.Black, 3);

      using (var graphics = Graphics.FromImage(canvas.Bitmap)) {
        graphics.DrawRectangle(blackPen, panelRectangle.Rectangle);
      }

      return canvas;
    }
  }
}