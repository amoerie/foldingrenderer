using System;
using FoldingRenderer.Types;

namespace FoldingRenderer.Drawing {
  public interface IRootPanelPositioner {
    PanelRectangle Position(Panel rootPanel, Position rootPanelPosition);
  }

  public class RootPanelPositioner : IRootPanelPositioner {
    readonly IRectangleFactory _rectangleFactory;

    public RootPanelPositioner(IRectangleFactory rectangleFactory) {
      if (rectangleFactory == null) throw new ArgumentNullException(nameof(rectangleFactory));
      _rectangleFactory = rectangleFactory;
    }

    public PanelRectangle Position(Panel rootPanel, Position rootPanelPosition) {
      if (rootPanel == null) throw new ArgumentNullException(nameof(rootPanel));
      if (rootPanelPosition == null) throw new ArgumentNullException(nameof(rootPanelPosition));

      var rectangle = _rectangleFactory.Create(rootPanelPosition, rootPanel.Dimensions);

      return new PanelRectangle(rootPanel, rectangle, Rotation.None);
    }
  }
}