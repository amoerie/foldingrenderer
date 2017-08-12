using System;
using System.Drawing;
using FoldingRenderer.Types;

namespace FoldingRenderer.Drawing {
  public interface IRectangleRotator {
    Rectangle Rotate(Position hinge, Rectangle rectangle, Rotation rotation);
  }

  public class RectangleRotator : IRectangleRotator {
    public Rectangle Rotate(Position hinge, Rectangle rectangle, Rotation rotation) {
      if (Rotation.None.Equals(rotation)) return rectangle;
      if (Rotation.Right.Equals(rotation)) {
        var topLeft = new Point(hinge.X, hinge.Y - rectangle.Width / 2);
        return new Rectangle(topLeft, new Size(rectangle.Size.Height, rectangle.Size.Width));
      }
      if (Rotation.Left.Equals(rotation)) {
        var topLeft = new Point(hinge.X - rectangle.Height, hinge.Y - rectangle.Width / 2);
        return new Rectangle(topLeft, new Size(rectangle.Size.Height, rectangle.Size.Width));
      }
      if (Rotation.Down.Equals(rotation)) {
        var topLeft = new Point(hinge.X - rectangle.Width / 2, hinge.Y);
        return new Rectangle(topLeft, new Size(rectangle.Size.Width, rectangle.Size.Height));
      }
      throw new NotSupportedException($"Rotations other than None, Right, Left or Down are not supported. Attempted to rotate by {rotation.Value}°");
    }
  }
}
