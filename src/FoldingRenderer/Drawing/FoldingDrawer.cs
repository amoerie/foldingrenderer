using System;
using System.Drawing;
using FoldingRenderer.Types;

namespace FoldingRenderer.Drawing {
  public interface IFoldingDrawer {
    /// <summary>
    /// Draws the specified folding on a new canvas.
    /// </summary>
    ICanvas Draw(Folding folding);
  }

  public class FoldingDrawer : IFoldingDrawer {
    readonly IRootPanelDrawer _rootPanelDrawer;

    public FoldingDrawer(IRootPanelDrawer rootPanelDrawer) {
      if (rootPanelDrawer == null) throw new ArgumentNullException(nameof(rootPanelDrawer));
      _rootPanelDrawer = rootPanelDrawer;
    }

    public ICanvas Draw(Folding folding) {
      var canvas = new Canvas(new Bitmap(folding.Dimensions.Width, folding.Dimensions.Height));

      using (var graphics = Graphics.FromImage(canvas.Bitmap)) {
        graphics.Clear(Color.White);
      }

      return _rootPanelDrawer.Draw(canvas, folding.RootPanel, folding.RootPanelPosition);
    }
  }
}