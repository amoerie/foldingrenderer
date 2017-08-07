using System;
using System.Collections.Immutable;
using FluentAssertions;
using FoldingRenderer.Domain.Types;
using FoldingRenderer.Storage.Xml;
using Xunit;

namespace FoldingRenderer.Tests.Storage.Xml {
  public class TestsForXmlModelMapper {
    readonly XmlModelMapper _sut;

    protected TestsForXmlModelMapper() {
      _sut = new XmlModelMapper();
    }

    public class Map : TestsForXmlModelMapper {
      [Fact]
      public void ShouldMapAllPanelProperties() {
        var item = new XmlModels.Item {
          PanelId = new Guid("872201A9-2D6E-FD0C-E7E9-A24588D95B5E"),
          PanelName = "Dummy Panel",
          MinRot = 1,
          MaxRot = 2,
          InitialRot = 3,
          StartRot = 4,
          EndRot = 5,
          HingeOffset = 6,
          PanelWidth = 7,
          PanelHeight = 8,
          AttachedToSide = 9,
          CreaseBottom = 10,
          CreaseTop = 11,
          CreaseLeft = 12,
          CreaseRight = 13,
          IgnoreCollisions = true,
          MouseEnabled = true,
          AttachedPanels = new[] {
            new XmlModels.Item {
              PanelId = new Guid("7F7A69B0-125A-44EA-A7C0-3A70A0D75367")
            }
          }
        };

        var expectedPanel = new Panel()
          .WithId(new Guid("872201A9-2D6E-FD0C-E7E9-A24588D95B5E"))
          .WithName("Dummy Panel")
          .WithRotation(new PanelRotation()
            .WithMinimum(new Rotation(1))
            .WithMaximum(new Rotation(2))
            .WithInitial(new Rotation(3))
            .WithStart(new Rotation(4))
            .WithEnd(new Rotation(5)))
          .WithHingeOffset(6)
          .WithDimensions(new PanelDimensions().WithWidth(7).WithHeight(8))
          .WithAttachedToSide(9)
          .WithCrease(new PanelCrease().WithBottom(10).WithTop(11).WithLeft(12).WithRight(13))
          .WithIgnoreCollisions(true)
          .WithMouseEnabled(true)
          .WithAttachedPanels(ImmutableList.Create(new Panel().WithId(new Guid("7F7A69B0-125A-44EA-A7C0-3A70A0D75367"))));

        var actualPanel = _sut.Map(item);

        actualPanel.ShouldBeEquivalentTo(expectedPanel);
      }
    }
  }
}