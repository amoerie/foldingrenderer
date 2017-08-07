using System;
using System.Drawing;
using FoldingRenderer.Domain.Types;

namespace FoldingRenderer.Domain.Drawing {
  public interface IRootPanelDrawer {
    Bitmap Draw(Bitmap bitmap, Panel rootPanel, Position rootPanelPosition);
  }

  public class RootPanelDrawer : IRootPanelDrawer {
    readonly IRootPanelPositioner _rootPanelPositioner;
    readonly IPanelRectangleDrawer _panelRectangleDrawer;

    public RootPanelDrawer(IRootPanelPositioner rootPanelPositioner, IPanelRectangleDrawer panelRectangleDrawer) {
      if (rootPanelPositioner == null) throw new ArgumentNullException(nameof(rootPanelPositioner));
      if (panelRectangleDrawer == null) throw new ArgumentNullException(nameof(panelRectangleDrawer));
      _rootPanelPositioner = rootPanelPositioner;
      _panelRectangleDrawer = panelRectangleDrawer;
    }

    public Bitmap Draw(Bitmap bitmap, Panel rootPanel, Position rootPanelPosition) {
      var panelRectangle = _rootPanelPositioner.Position(rootPanel, rootPanelPosition);
      return _panelRectangleDrawer.Draw(bitmap, panelRectangle);
    }
  }
}
