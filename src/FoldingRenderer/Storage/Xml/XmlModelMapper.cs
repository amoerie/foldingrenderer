using System;
using System.Collections.Immutable;
using System.Linq;
using FoldingRenderer.Domain.Types;

namespace FoldingRenderer.Storage.Xml {
  public interface IXmlModelMapper {
    Panel Map(XmlModels.Item panel);
  }

  public class XmlModelMapper : IXmlModelMapper {
    public Panel Map(XmlModels.Item panel) {
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
        .WithDimensions(new PanelDimensions()
          .WithWidth(panel.PanelWidth)
          .WithHeight(panel.PanelHeight))
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
  }
}

