using System;
using System.Drawing;
using FoldingRenderer.Domain.Types;

namespace FoldingRenderer.Domain.Drawing {
  public interface IRootPanelPositioner {
    PanelRectangle Position(Panel rootPanel, Position rootPanelPosition);
  }

  public class RootPanelPositioner : IRootPanelPositioner {
    public PanelRectangle Position(Panel rootPanel, Position rootPanelPosition) {
      if (rootPanel == null) throw new ArgumentNullException(nameof(rootPanel));
      if (rootPanelPosition == null) throw new ArgumentNullException(nameof(rootPanelPosition));
      /*
       * the root panel position serves as the bottom hinge
       * 
       * 
       *   top left position
       *      v 
       *      o---------o---------o
       *      |                   |
       *      |                   |
       *      o                   o
       *      |                   |
       *      |                   |
       *      o---------o---------o
       *                ^
       *        root panel position        
       * 
       */
      var rectangleTopLeftPosition = new Position()
        .WithX(rootPanelPosition.X - rootPanel.Dimensions.Width / 2)
        .WithY(rootPanelPosition.Y + rootPanel.Dimensions.Height);
      var rectangle = new Rectangle(rectangleTopLeftPosition.ToPoint(), rootPanel.Dimensions.ToSize());

      return new PanelRectangle(rootPanel, rectangle, Rotation.None);
    }
  }
}