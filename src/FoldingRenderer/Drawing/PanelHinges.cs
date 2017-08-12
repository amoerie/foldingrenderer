using System.Drawing;
using FoldingRenderer.Types;

namespace FoldingRenderer.Drawing {
  public class PanelHinges {
    public Position Top { get; }
    public Position Right { get; }
    public Position Bottom { get; }
    public Position Left { get; }

    public PanelHinges(Rectangle rectangle, Rotation rotation) {
      var bottomPosition = new Position().WithX(rectangle.X + rectangle.Width / 2).WithY(rectangle.Y + rectangle.Height);
      var topPosition = new Position().WithX(rectangle.X + rectangle.Width / 2).WithY(rectangle.Y);
      var leftPosition = new Position().WithX(rectangle.X).WithY(rectangle.Y + rectangle.Height / 2);
      var rightPosition = new Position().WithX(rectangle.X + rectangle.Width).WithY(rectangle.Y + rectangle.Height / 2);

      if (Rotation.None.Equals(rotation)) {
        Bottom = bottomPosition;
        Top = topPosition;
        Left = leftPosition;
        Right = rightPosition;
      } else if (Rotation.Right.Equals(rotation)) {
        Bottom = leftPosition;
        Top = rightPosition;
        Left = topPosition;
        Right = bottomPosition;
      } else if (Rotation.Left.Equals(rotation)) {
        Bottom = rightPosition;
        Top = leftPosition;
        Left = bottomPosition;
        Right = topPosition;
      } else if (Rotation.Down.Equals(rotation)) {
        Bottom = topPosition;
        Top = bottomPosition;
        Left = rightPosition;
        Right = leftPosition;
      }
    }
  }
}