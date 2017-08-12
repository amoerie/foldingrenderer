using System;
using FoldingRenderer.Types;

namespace FoldingRenderer.Drawing {
  public interface IPanelPositioner {
    PanelRectangle Position(PanelRectangle parent, Panel panel);
  }

  public class PanelPositioner : IPanelPositioner {
    readonly IAttachToHingeDeterminer _attachToHingeDeterminer;
    readonly IRotationDeterminer _rotationDeterminer;
    readonly IRectangleFactory _rectangleFactory;
    readonly IRectangleRotator _rectangleRotator;
    readonly IHingeOffsetApplier _hingeOffsetApplier;

    public PanelPositioner(IAttachToHingeDeterminer attachToHingeDeterminer,
      IRotationDeterminer rotationDeterminer,
      IRectangleFactory rectangleFactory,
      IRectangleRotator rectangleRotator,
      IHingeOffsetApplier hingeOffsetApplier) {
      if (attachToHingeDeterminer == null) throw new ArgumentNullException(nameof(attachToHingeDeterminer));
      if (rotationDeterminer == null) throw new ArgumentNullException(nameof(rotationDeterminer));
      if (rectangleFactory == null) throw new ArgumentNullException(nameof(rectangleFactory));
      if (rectangleRotator == null) throw new ArgumentNullException(nameof(rectangleRotator));
      if (hingeOffsetApplier == null) throw new ArgumentNullException(nameof(hingeOffsetApplier));
      _attachToHingeDeterminer = attachToHingeDeterminer;
      _rotationDeterminer = rotationDeterminer;
      _rectangleFactory = rectangleFactory;
      _rectangleRotator = rectangleRotator;
      _hingeOffsetApplier = hingeOffsetApplier;
    }

    public PanelRectangle Position(PanelRectangle parent, Panel panel) {
      if (parent == null) throw new ArgumentNullException(nameof(parent));
      if (panel == null) throw new ArgumentNullException(nameof(panel));
      var hingeToAttachTo = _attachToHingeDeterminer.Determine(parent, panel);
      var rectangle = _rectangleFactory.Create(hingeToAttachTo, panel.Dimensions);
      var rotation = _rotationDeterminer.Determine(parent, panel);
      var rotatedRectangle = _rectangleRotator.Rotate(hingeToAttachTo, rectangle, rotation);
      var rotatedRectangleWithHingeOffset = _hingeOffsetApplier.Apply(rotatedRectangle, rotation, panel.HingeOffset);
      return new PanelRectangle(panel, rotatedRectangleWithHingeOffset, rotation);
    }
  }
}
