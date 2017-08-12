using System;

namespace FoldingRenderer.Domain.Types {
  public class Folding {
    public Dimensions Dimensions { get; }
    public Position RootPanelPosition { get; }
    public Panel RootPanel { get; }

    public Folding(Dimensions dimensions, Position rootPanelPosition, Panel rootPanel) {
      if (dimensions == null) throw new ArgumentNullException(nameof(dimensions));
      if (rootPanelPosition == null) throw new ArgumentNullException(nameof(rootPanelPosition));
      if (rootPanel == null) throw new ArgumentNullException(nameof(rootPanel));
      Dimensions = dimensions;
      RootPanelPosition = rootPanelPosition;
      RootPanel = rootPanel;
    }
  }
}
