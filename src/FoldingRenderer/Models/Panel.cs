using System;

namespace FoldingRenderer.Models
{
  public class Panel
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public PanelRotation Rotation { get; set; }
    public double HingeOffset { get; set; }
    public PanelDimensions Dimensions { get; set; }
    public int AttachedToSide { get; set; }
    public PanelCrease Crease { get; set; }
    public bool IgnoreCollisions { get; set; }
    public bool MouseEnabled { get; set; }
  }
}