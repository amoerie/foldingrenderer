using System;
using FoldingRenderer.Types;

namespace FoldingRenderer.Drawing {
  public interface IRootPanelPositioner {
    PanelRectangle Position(Panel rootPanel, Position rootPanelHinge);
  }

  public class RootPanelPositioner : IRootPanelPositioner {
    readonly IRectangleFactory _rectangleFactory;

    public RootPanelPositioner(IRectangleFactory rectangleFactory) {
      if (rectangleFactory == null) throw new ArgumentNullException(nameof(rectangleFactory));
      _rectangleFactory = rectangleFactory;
    }

    public PanelRectangle Position(Panel rootPanel, Position rootPanelHinge) {
      if (rootPanel == null) throw new ArgumentNullException(nameof(rootPanel));
      if (rootPanelHinge == null) throw new ArgumentNullException(nameof(rootPanelHinge));

      var rectangle = _rectangleFactory.Create(rootPanelHinge, rootPanel.Dimensions);

      return new PanelRectangle(rootPanel, rectangle, Rotation.None);
    }
  }
}