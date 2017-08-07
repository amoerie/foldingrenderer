using System;

namespace FoldingRenderer.Domain.Types {
  public class Folding {
    public Dimensions Dimensions { get; set; }
    public Position RootPanelPosition { get; set; }
    public Panel RootPanel { get; set; }

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
