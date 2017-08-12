using System;
using FoldingRenderer.Domain.Types;

namespace FoldingRenderer.Domain.Drawing {
  public interface IPanelPositioner {
    PanelRectangle Position(PanelRectangle parent, Panel panel);
  }

  public class PanelPositioner : IPanelPositioner {
    readonly IAttachToHingeDeterminer _attachToHingeDeterminer;
    readonly IRotationDeterminer _rotationDeterminer;
    readonly IRectangleFactory _rectangleFactory;

    public PanelPositioner(IAttachToHingeDeterminer attachToHingeDeterminer,
      IRotationDeterminer rotationDeterminer,
      IRectangleFactory rectangleFactory) {
      if (attachToHingeDeterminer == null) throw new ArgumentNullException(nameof(attachToHingeDeterminer));
      if (rotationDeterminer == null) throw new ArgumentNullException(nameof(rotationDeterminer));
      if (rectangleFactory == null) throw new ArgumentNullException(nameof(rectangleFactory));
      _attachToHingeDeterminer = attachToHingeDeterminer;
      _rotationDeterminer = rotationDeterminer;
      _rectangleFactory = rectangleFactory;
    }

    public PanelRectangle Position(PanelRectangle parent, Panel panel) {
      if (parent == null) throw new ArgumentNullException(nameof(parent));
      if (panel == null) throw new ArgumentNullException(nameof(panel));
      var hingeToAttachTo = _attachToHingeDeterminer.Determine(parent, panel);
      var rotation = _rotationDeterminer.Determine(parent, panel);
      var rectangle = _rectangleFactory.Create(hingeToAttachTo, panel.Dimensions);

      //var panelRectangle = new PanelRectangle(panel, rectangle);

      throw new NotImplementedException();
    }
  }
}
