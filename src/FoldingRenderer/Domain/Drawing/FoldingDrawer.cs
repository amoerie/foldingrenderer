using System;
using System.Drawing;
using FoldingRenderer.Domain.Types;

namespace FoldingRenderer.Domain.Drawing {
  public interface IFoldingDrawer {
    Bitmap Draw(Folding folding);
  }

  public class FoldingDrawer : IFoldingDrawer {
    readonly IRootPanelDrawer _rootPanelDrawer;

    public FoldingDrawer(IRootPanelDrawer rootPanelDrawer) {
      if (rootPanelDrawer == null) throw new ArgumentNullException(nameof(rootPanelDrawer));
      _rootPanelDrawer = rootPanelDrawer;
    }

    public Bitmap Draw(Folding folding) {
      var bitmap = new Bitmap(folding.Dimensions.Width, folding.Dimensions.Height);

      using (var graphics = Graphics.FromImage(bitmap)) {
        graphics.Clear(Color.White);
      }

      _rootPanelDrawer.Draw(bitmap, folding.RootPanel, folding.RootPanelPosition);

      return bitmap;
    }
  }
}