using System;
using FoldingRenderer.Domain.Types;

namespace FoldingRenderer.Domain.Drawing {
  public interface IRotationDeterminer {
    /// <summary>
    /// Determines the rotation of the panel relative to its parent.
    /// </summary>
    Rotation Determine(PanelRectangle parent, Panel child);
  }

  public class RotationDeterminer : IRotationDeterminer {
    public Rotation Determine(PanelRectangle parent, Panel panel) {
      if (parent == null) throw new ArgumentNullException(nameof(parent));
      if (panel == null) throw new ArgumentNullException(nameof(panel));

      switch (panel.AttachedToSide) {
        case 0: return parent.Rotation + Rotation.Down;
        case 1: return parent.Rotation + Rotation.Right;
        case 2: return parent.Rotation + Rotation.None;
        case 3: return parent.Rotation + Rotation.Left;
        default:
          throw new ArgumentOutOfRangeException($"Panel '{panel.Name}' ({panel.Id}) does not have a valid side to attach to: {panel.AttachedToSide}");
      }
    }
  }
}
