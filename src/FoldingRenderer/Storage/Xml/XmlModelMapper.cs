using System;
using System.Collections.Immutable;
using System.Linq;
using FoldingRenderer.Types;

namespace FoldingRenderer.Storage.Xml {
  public interface IXmlModelMapper {
    Folding Map(XmlModels.Folding folding);
  }

  public class XmlModelMapper : IXmlModelMapper {
    Panel Map(XmlModels.Item panel) {
      if (panel == null) throw new ArgumentNullException(nameof(panel));
      return new Panel()
        .WithId(panel.PanelId)
        .WithName(panel.PanelName)
        .WithRotation(new PanelRotation()
          .WithMinimum(new Rotation(panel.MinRot))
          .WithMaximum(new Rotation(panel.MaxRot))
          .WithInitial(new Rotation(panel.InitialRot))
          .WithStart(new Rotation(panel.StartRot))
          .WithEnd(new Rotation(panel.EndRot)))
        .WithHingeOffset(panel.HingeOffset)
        .WithDimensions(new Dimensions()
          .WithWidth((int) panel.PanelWidth)
          .WithHeight((int) panel.PanelHeight))
        .WithAttachedToSide(panel.AttachedToSide)
        .WithCrease(new PanelCrease()
          .WithBottom(panel.CreaseBottom)
          .WithTop(panel.CreaseTop)
          .WithLeft(panel.CreaseLeft)
          .WithRight(panel.CreaseRight))
        .WithIgnoreCollisions(panel.IgnoreCollisions)
        .WithMouseEnabled(panel.MouseEnabled)
        .WithAttachedPanels(panel.AttachedPanels?.Select(Map).ToImmutableList() ?? ImmutableList<Panel>.Empty);
    }

    public Folding Map(XmlModels.Folding folding) {
      if(folding == null) throw new ArgumentNullException(nameof(folding));
      return new Folding(
        new Dimensions().WithWidth(folding.OriginalDocumentWidth).WithHeight(folding.OriginalDocumentHeight),
        new Position().WithX((int) folding.RootX).WithY((int) folding.RootY),
        Map(folding.Items.Single()));
    }
  }
}

