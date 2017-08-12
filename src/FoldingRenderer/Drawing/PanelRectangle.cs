using System;
using System.Drawing;
using FoldingRenderer.Domain.Types;

namespace FoldingRenderer.Domain.Drawing {
  public class PanelRectangle {
    /// <summary>
    /// Gets the panel.
    /// </summary>
    public Panel Panel { get; }

    /// <summary>
    /// Gets (already rotated!!) rectangle that represents this panel.
    /// </summary>
    public Rectangle Rectangle { get; }

    /// <summary>
    /// Gets the rotation that was applied to this panel in relation to its parent panel
    /// </summary>
    public Rotation Rotation { get; }

    /// <summary>
    /// Gets the hinges of this panel, that take into account the rotation.
    /// </summary>
    public PanelHinges Hinges { get; }

    public PanelRectangle(Panel panel, Rectangle rectangle, Rotation rotation) {
      if (panel == null) throw new ArgumentNullException(nameof(panel));
      Panel = panel;
      Rectangle = rectangle;
      Rotation = rotation;
      Hinges = new PanelHinges(rectangle, rotation);
    }
  }
}
