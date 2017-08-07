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
      readonly XmlModels.Folding _folding;

      public Map() {
        _folding = new XmlModels.Folding {
          RootX = 17.4,
          RootY = 3232.3,
          OriginalDocumentWidth = 2410,
          OriginalDocumentHeight = 1500,
          Items = new [] {
            new XmlModels.Item {
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
            }
          }
        };
      }

      [Fact]
      public void ShouldMapDocumentDimensions() {
        var actualDimensions = _sut.Map(_folding).Dimensions;
        var expectedDimensions = new Dimensions().WithWidth(2410).WithHeight(1500);
        actualDimensions.ShouldBeEquivalentTo(expectedDimensions);
      }

      [Fact]
      public void ShouldMapRootPanelPosition() {
        var actualRootPanelPosition = _sut.Map(_folding).RootPanelPosition;
        var expectedRootPanelPosition = new Position().WithX(17.4).WithY(3232.3);
        actualRootPanelPosition.ShouldBeEquivalentTo(expectedRootPanelPosition);
      }

      [Fact]
      public void ShouldMapRootPanel() {
        var actualRootPanel = _sut.Map(_folding).RootPanel;
        var expectedRootPanel = new Panel()
          .WithId(new Guid("872201A9-2D6E-FD0C-E7E9-A24588D95B5E"))
          .WithName("Dummy Panel")
          .WithRotation(new PanelRotation()
            .WithMinimum(new Rotation(1))
            .WithMaximum(new Rotation(2))
            .WithInitial(new Rotation(3))
            .WithStart(new Rotation(4))
            .WithEnd(new Rotation(5)))
          .WithHingeOffset(6)
          .WithDimensions(new Dimensions().WithWidth(7).WithHeight(8))
          .WithAttachedToSide(9)
          .WithCrease(new PanelCrease().WithBottom(10).WithTop(11).WithLeft(12).WithRight(13))
          .WithIgnoreCollisions(true)
          .WithMouseEnabled(true)
          .WithAttachedPanels(ImmutableList.Create(new Panel().WithId(new Guid("7F7A69B0-125A-44EA-A7C0-3A70A0D75367"))));

        actualRootPanel.ShouldBeEquivalentTo(expectedRootPanel);
      }
    }
  }
}