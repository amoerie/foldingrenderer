using System.Drawing;
using FoldingRenderer.Domain.Types;

namespace FoldingRenderer.Domain.Drawing {
  public interface IPanelRectangleDrawer {
    Bitmap Draw(Bitmap bitmap, PanelRectangle panelRectangle);
  }

  public class PanelRectangleDrawer : IPanelRectangleDrawer {
    public Bitmap Draw(Bitmap bitmap, PanelRectangle panelRectangle) {
      Pen blackPen = new Pen(Color.Black, 3);

      using (var graphics = Graphics.FromImage(bitmap)) {
        // TODO rotate the rectangle if necessary
        if (panelRectangle.Rotation.Equals(Rotation.None)) {
          graphics.DrawRectangle(blackPen, panelRectangle.Rectangle);
        }
      }

      return bitmap;
    }
  }
}