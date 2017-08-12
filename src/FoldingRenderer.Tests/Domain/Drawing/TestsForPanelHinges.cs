using System.Drawing;
using FluentAssertions;
using FoldingRenderer.Domain.Drawing;
using FoldingRenderer.Domain.Types;
using Xunit;

namespace FoldingRenderer.Tests.Domain.Drawing {
  public class TestsForPanelHinges {
    public class BottomHinge : TestsForPanelHinges {
      [Fact]
      public void ShouldReturnCorrectPositionForUnevenWidth() {
        // Top left = (0,0)
        // Dimensions = 15x15
        var rectangle = new Rectangle(0, 0, 15, 15);

        var expectedBottomHinge = new Position().WithX(7).WithY(15);
        var actualBottomHinge = new PanelHinges(rectangle, Rotation.None).Bottom;

        actualBottomHinge.ShouldBeEquivalentTo(expectedBottomHinge);
      }

      [Fact]
      public void ShouldReturnCorrectPositionForEvenWidth() {
        // Top left = (0,0)
        // Dimensions = 150x150
        var rectangle = new Rectangle(0, 0, 150, 150);

        var expectedBottomHinge = new Position().WithX(75).WithY(150);
        var actualBottomHinge = new PanelHinges(rectangle, Rotation.None).Bottom;

        actualBottomHinge.ShouldBeEquivalentTo(expectedBottomHinge);
      }

      [Fact]
      public void ShouldReturnCorrectHingeForEveryRotation() {
        // Top left = (0,0)
        // Dimensions = 15x15
        var rectangle = new Rectangle(0, 0, 15, 15);
        var noRotation = new PanelHinges(rectangle, Rotation.None);
        new PanelHinges(rectangle, Rotation.Right).Bottom.Should().Be(noRotation.Left);
        new PanelHinges(rectangle, Rotation.Left).Bottom.Should().Be(noRotation.Right);
        new PanelHinges(rectangle, Rotation.Down).Bottom.Should().Be(noRotation.Top);
      }
    }

    public class TopHinge : TestsForPanelHinges {
      [Fact]
      public void ShouldReturnCorrectPositionForUnevenWidth() {
        // Top left = (0,0)
        // Dimensions = 15x15
        var rectangle = new Rectangle(0, 0, 15, 15);

        var expectedTopHinge = new Position().WithX(7).WithY(0);
        var actualTopHinge = new PanelHinges(rectangle, Rotation.None).Top;

        actualTopHinge.ShouldBeEquivalentTo(expectedTopHinge);
      }

      [Fact]
      public void ShouldReturnCorrectPositionForEvenWidth() {
        // Top left = (0,0)
        // Dimensions = 150x150
        var rectangle = new Rectangle(0, 0, 150, 150);

        var expectedTopHinge = new Position().WithX(75).WithY(0);
        var actualTopHinge = new PanelHinges(rectangle, Rotation.None).Top;

        actualTopHinge.ShouldBeEquivalentTo(expectedTopHinge);
      }

      [Fact]
      public void ShouldReturnCorrectHingeForEveryRotation() {
        // Top left = (0,0)
        // Dimensions = 15x15
        var rectangle = new Rectangle(0, 0, 15, 15);
        var noRotation = new PanelHinges(rectangle, Rotation.None);
        new PanelHinges(rectangle, Rotation.Right).Top.Should().Be(noRotation.Right);
        new PanelHinges(rectangle, Rotation.Left).Top.Should().Be(noRotation.Left);
        new PanelHinges(rectangle, Rotation.Down).Top.Should().Be(noRotation.Bottom);
      }
    }

    public class LeftHinge : TestsForPanelHinges {
      [Fact]
      public void ShouldReturnCorrectPositionForUnevenHeight() {
        // Top left = (0,0)
        // Dimensions = 15x15
        var rectangle = new Rectangle(0, 0, 15, 15);

        var expectedLeftHinge = new Position().WithX(0).WithY(7);
        var actualLeftHinge = new PanelHinges(rectangle, Rotation.None).Left;

        actualLeftHinge.ShouldBeEquivalentTo(expectedLeftHinge);
      }

      [Fact]
      public void ShouldReturnCorrectPositionForEvenHeight() {
        // Top left = (0,0)
        // Dimensions = 150x150
        var rectangle = new Rectangle(0, 0, 150, 150);

        var expectedLeftHinge = new Position().WithX(0).WithY(75);
        var actualLeftHinge = new PanelHinges(rectangle, Rotation.None).Left;

        actualLeftHinge.ShouldBeEquivalentTo(expectedLeftHinge);
      }

      [Fact]
      public void ShouldReturnCorrectHingeForEveryRotation() {
        // Top left = (0,0)
        // Dimensions = 15x15
        var rectangle = new Rectangle(0, 0, 15, 15);
        var noRotation = new PanelHinges(rectangle, Rotation.None);
        new PanelHinges(rectangle, Rotation.Right).Left.Should().Be(noRotation.Top);
        new PanelHinges(rectangle, Rotation.Left).Left.Should().Be(noRotation.Bottom);
        new PanelHinges(rectangle, Rotation.Down).Left.Should().Be(noRotation.Right);
      }
    }

    public class RightHinge : TestsForPanelHinges {
      [Fact]
      public void ShouldReturnCorrectPositionForUnevenHeight() {
        // Top left = (0,0)
        // Dimensions = 15x15
        var rectangle = new Rectangle(0, 0, 15, 15);

        var expectedRightHinge = new Position().WithX(15).WithY(7);
        var actualRightHinge = new PanelHinges(rectangle, Rotation.None).Right;

        actualRightHinge.ShouldBeEquivalentTo(expectedRightHinge);
      }

      [Fact]
      public void ShouldReturnCorrectPositionForEvenHeight() {
        // Top left = (0,0)
        // Dimensions = 150x150
        var rectangle = new Rectangle(0, 0, 150, 150);

        var expectedRightHinge = new Position().WithX(150).WithY(75);
        var actualRightHinge = new PanelHinges(rectangle, Rotation.None).Right;

        actualRightHinge.ShouldBeEquivalentTo(expectedRightHinge);
      }

      [Fact]
      public void ShouldReturnCorrectHingeForEveryRotation() {
        // Top left = (0,0)
        // Dimensions = 15x15
        var rectangle = new Rectangle(0, 0, 15, 15);
        var noRotation = new PanelHinges(rectangle, Rotation.None);
        new PanelHinges(rectangle, Rotation.Right).Right.Should().Be(noRotation.Bottom);
        new PanelHinges(rectangle, Rotation.Left).Right.Should().Be(noRotation.Top);
        new PanelHinges(rectangle, Rotation.Down).Right.Should().Be(noRotation.Left);
      }
    }
  }
}