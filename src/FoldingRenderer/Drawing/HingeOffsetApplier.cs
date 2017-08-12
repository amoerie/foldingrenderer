using System;
using System.Drawing;
using FoldingRenderer.Types;

namespace FoldingRenderer.Drawing {
  public interface IHingeOffsetApplier {
    Rectangle Apply(Rectangle rectangle, Rotation rotation, int hingeOffset);
  }

  public class HingeOffsetApplier : IHingeOffsetApplier {
    public Rectangle Apply(Rectangle rectangle, Rotation rotation, int hingeOffset) {
      if (Rotation.None.Equals(rotation))
        return new Rectangle(new Point(rectangle.X + hingeOffset, rectangle.Y), rectangle.Size);
      if (Rotation.Down.Equals(rotation))
        return new Rectangle(new Point(rectangle.X - hingeOffset, rectangle.Y), rectangle.Size);
      if (Rotation.Right.Equals(rotation))
        return new Rectangle(new Point(rectangle.X, rectangle.Y + hingeOffset), rectangle.Size);
      if (Rotation.Left.Equals(rotation))
        return new Rectangle(new Point(rectangle.X, rectangle.Y - hingeOffset), rectangle.Size);
      throw new NotSupportedException($"Rotations other than None, Right, Left or Down are not supported. Found rotation {rotation.Value}°");
    }
  }
}
