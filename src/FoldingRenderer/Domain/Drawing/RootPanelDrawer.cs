using System;
using FoldingRenderer.Domain.Types;

namespace FoldingRenderer.Domain.Drawing {
  public interface IRootPanelDrawer {
    ICanvas Draw(ICanvas canvas, Panel rootPanel, Position rootPanelPosition);
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

    public ICanvas Draw(ICanvas canvas, Panel rootPanel, Position rootPanelPosition) {
      if (canvas == null) throw new ArgumentNullException(nameof(canvas));
      if (rootPanel == null) throw new ArgumentNullException(nameof(rootPanel));
      if (rootPanelPosition == null) throw new ArgumentNullException(nameof(rootPanelPosition));

      var rootPanelRectangle = _rootPanelPositioner.Position(rootPanel, rootPanelPosition);
      return _panelRectangleDrawer.Draw(canvas, rootPanelRectangle);
    }
  }
}
