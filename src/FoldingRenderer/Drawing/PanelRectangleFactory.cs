using System;
using System.Collections.Immutable;
using System.Linq;
using FoldingRenderer.Types;

namespace FoldingRenderer.Drawing {
  public interface IPanelRectangleFactory {
    ImmutableList<PanelRectangle> Create(Panel rootPanel, Position rootPanelHinge);
  }

  public class PanelRectangleFactory : IPanelRectangleFactory {
    readonly IRootPanelPositioner _rootPanelPositioner;
    readonly IPanelPositioner _panelPositioner;

    public PanelRectangleFactory(IRootPanelPositioner rootPanelPositioner, IPanelPositioner panelPositioner) {
      if (rootPanelPositioner == null) throw new ArgumentNullException(nameof(rootPanelPositioner));
      if (panelPositioner == null) throw new ArgumentNullException(nameof(panelPositioner));
      _rootPanelPositioner = rootPanelPositioner;
      _panelPositioner = panelPositioner;
    }

    public ImmutableList<PanelRectangle> Create(Panel rootPanel, Position rootPanelHinge) {
      if (rootPanel == null) throw new ArgumentNullException(nameof(rootPanel));
      if (rootPanelHinge == null) throw new ArgumentNullException(nameof(rootPanelHinge));
      var rootPanelRectangle = _rootPanelPositioner.Position(rootPanel, rootPanelHinge);
      return ImmutableList.Create(rootPanelRectangle)
        .AddRange(rootPanel.AttachedPanels.SelectMany(attachedPanel => Create(rootPanelRectangle, attachedPanel)));
    }

    ImmutableList<PanelRectangle> Create(PanelRectangle parent, Panel panel) {
      var panelRectangle = _panelPositioner.Position(parent, panel);
      return ImmutableList.Create(panelRectangle)
        .AddRange(panel.AttachedPanels.SelectMany(attachedPanel => Create(panelRectangle, attachedPanel)));
    }
  }
}
