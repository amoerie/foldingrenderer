using System.Drawing;
using FoldingRenderer.Types;

namespace FoldingRenderer.Drawing {
  public interface IRectangleFactory {
    Rectangle Create(Position bottomHinge, Dimensions dimensions);
  }

  public class RectangleFactory : IRectangleFactory {
    public Rectangle Create(Position bottomHinge, Dimensions dimensions) {
      /*
       * The rectangle needs a top left position, which we can derive from the bottom hinge and the dimensions
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
       *          bottom hinge      
       * 
       */
      var rectangleTopLeftPosition = new Position()
        .WithX(bottomHinge.X - dimensions.Width / 2)
        .WithY(bottomHinge.Y - dimensions.Height);
      return new Rectangle(rectangleTopLeftPosition.ToPoint(), dimensions.ToSize());
    }
  }
}
