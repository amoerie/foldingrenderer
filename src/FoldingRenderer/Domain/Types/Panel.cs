using System;
using System.Collections.Immutable;

namespace FoldingRenderer.Domain.Types {
  public class Panel {
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public PanelRotation Rotation { get; private set; }
    public double HingeOffset { get; private set; }
    public PanelDimensions Dimensions { get; private set; }
    public int AttachedToSide { get; private set; }
    public PanelCrease Crease { get; private set; }
    public bool IgnoreCollisions { get; private set; }
    public bool MouseEnabled { get; private set; }
    public IImmutableList<Panel> AttachedPanels { get; private set; }

    public Panel() {
      Rotation = PanelRotation.None;
      Dimensions = PanelDimensions.None;
      Crease = PanelCrease.None;
      AttachedPanels = ImmutableList<Panel>.Empty;
    }

    Panel Clone(Action<Panel> modify) {
      var clone = new Panel {
        Id = Id,
        Name = Name,
        Rotation = Rotation,
        HingeOffset = HingeOffset,
        Dimensions = Dimensions,
        AttachedToSide = AttachedToSide,
        Crease = Crease,
        IgnoreCollisions = IgnoreCollisions,
        MouseEnabled = MouseEnabled,
        AttachedPanels = AttachedPanels
      };
      modify(clone);
      return clone;
    }

    public Panel WithId(Guid id) => Clone(p => p.Id = id);
    public Panel WithName(string name) => Clone(p => p.Name = name);
    public Panel WithRotation(PanelRotation rotation) => Clone(p => p.Rotation = rotation ?? PanelRotation.None);
    public Panel WithHingeOffset(double hingeOffset) => Clone(p => p.HingeOffset = hingeOffset);
    public Panel WithDimensions(PanelDimensions dimensions) => Clone(p => p.Dimensions = dimensions ?? PanelDimensions.None);
    public Panel WithAttachedToSide(int side) => Clone(p => p.AttachedToSide = side);
    public Panel WithCrease(PanelCrease crease) => Clone(p => p.Crease = crease);
    public Panel WithIgnoreCollisions(bool ignoreCollisions) => Clone(p => p.IgnoreCollisions = ignoreCollisions);
    public Panel WithMouseEnabled(bool mouseEnabled) => Clone(p => p.MouseEnabled = mouseEnabled);
    public Panel WithAttachedPanels(IImmutableList<Panel> attachedPanels) => Clone(p => p.AttachedPanels = attachedPanels ?? ImmutableList<Panel>.Empty);
  }
}