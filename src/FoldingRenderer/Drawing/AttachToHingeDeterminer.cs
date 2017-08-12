using System;
using FoldingRenderer.Types;

namespace FoldingRenderer.Drawing {
  public interface IAttachToHingeDeterminer {
    /// <summary>
    /// Determines the hinge of the <paramref name="parent"/> to which the <paramref name="child"/> panel should attach.
    /// </summary>
    Position Determine(PanelRectangle parent, Panel child);
  }

  public class AttachToHingeDeterminer : IAttachToHingeDeterminer {
    public Position Determine(PanelRectangle parent, Panel panel) {
      if (parent == null) throw new ArgumentNullException(nameof(parent));
      if (panel == null) throw new ArgumentNullException(nameof(panel));

      switch (panel.AttachedToSide) {
        case 0: return parent.Hinges.Bottom;
        case 1: return parent.Hinges.Right;
        case 2: return parent.Hinges.Top;
        case 3: return parent.Hinges.Left;
        default:
          throw new ArgumentOutOfRangeException($"Panel '{panel.Name}' ({panel.Id}) does not have a valid side to attach to: {panel.AttachedToSide}");
      }
    }
  }
}
