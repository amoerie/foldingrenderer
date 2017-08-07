using System;
using FluentAssertions;
using FoldingRenderer.Storage.Xml;
using Xunit;

namespace FoldingRenderer.Tests.Storage.Xml {
  public class TestsForXmlModelReader {
    readonly XmlModelReader _sut;

    protected TestsForXmlModelReader() {
      _sut = new XmlModelReader();
    }

    public class Read : TestsForXmlModelReader {
      public Read() {
        _embeddedResourceReader = new EmbeddedResourceReader();
      }

      readonly EmbeddedResourceReader _embeddedResourceReader;

      [Fact]
      public void ShouldReadFoldingWithSinglePanelCorrectly() {
        var xml = _embeddedResourceReader.Read(typeof(TestsForXmlModelReader).Assembly, typeof(TestsForXmlModelReader).Namespace + ".SinglePanel.xml");
        var actualFolding = _sut.Read(xml);

        var expectedFolding = new XmlModels.Folding {
          Items = new[] {
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
              AttachedPanels = new XmlModels.Item[0]
            }
          }
        };

        actualFolding.Should().NotBeNull();
        actualFolding.Items.Should().NotBeNull().And.NotBeEmpty();
        actualFolding.Items[0].ShouldBeEquivalentTo(expectedFolding.Items[0]);
        actualFolding.Items.Should().HaveCount(1);
      }

      [Fact]
      public void ShouldReadFoldingWithNestedPanelsCorrectly() {
        var xml = _embeddedResourceReader.Read(typeof(TestsForXmlModelReader).Assembly, typeof(TestsForXmlModelReader).Namespace + ".NestedPanels.xml");
        var actualFolding = _sut.Read(xml);

        var expectedFolding = new XmlModels.Folding {
          Items = new[] {
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
              AttachedPanels = new [] {
                new XmlModels.Item {
                  PanelId = new Guid("F81E0416-1B71-4ECF-BF38-CAABE546554C"),
                  PanelName = "Dummy Panel 2",
                  MinRot = 10,
                  MaxRot = 20,
                  InitialRot = 30,
                  StartRot = 40,
                  EndRot = 50,
                  HingeOffset = 60,
                  PanelWidth = 70,
                  PanelHeight = 80,
                  AttachedToSide = 90,
                  CreaseBottom = 100,
                  CreaseTop = 110,
                  CreaseLeft = 120,
                  CreaseRight = 130,
                  IgnoreCollisions = false,
                  MouseEnabled = false,
                  AttachedPanels = new XmlModels.Item[0]
                }
              }
            }
          }
        };

        actualFolding.Should().NotBeNull();
        actualFolding.Items.Should().NotBeNull().And.NotBeEmpty();
        actualFolding.Items[0].ShouldBeEquivalentTo(expectedFolding.Items[0]);
        actualFolding.Items.Should().HaveCount(1);
      }
    }
  }
}