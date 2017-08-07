using System;
using System.Drawing;
using FoldingRenderer.Domain.Types;

namespace FoldingRenderer.Domain.Drawing {
  public class PanelRectangle { 
    public Panel Panel { get; }
    public Rectangle Rectangle { get; }
    public Rotation Rotation { get; }
    public Position BottomHinge => new Position().WithX(Rectangle.X + Rectangle.Width / 2).WithY(Rectangle.Y - Rectangle.Height);
    public Position TopHinge => new Position().WithX(Rectangle.X + Rectangle.Width / 2).WithY(Rectangle.Y);
    public Position LeftHinge => new Position().WithX(Rectangle.X).WithY(Rectangle.Y - Rectangle.Height / 2);
    public Position RightHinge => new Position().WithX(Rectangle.X + Rectangle.Width).WithY(Rectangle.Y - Rectangle.Height / 2);


    public PanelRectangle(Panel panel, Rectangle rectangle, Rotation rotation) {
      if (panel == null) throw new ArgumentNullException(nameof(panel));
      Panel = panel;
      Rectangle = rectangle;
      Rotation = rotation;
    }
  }
}
