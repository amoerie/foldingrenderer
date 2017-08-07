using System;
using System.Drawing;
using FluentAssertions;
using FoldingRenderer.Domain.Drawing;
using FoldingRenderer.Domain.Types;
using Xunit;

namespace FoldingRenderer.Tests.Domain.Drawing {
  public class TestsForRootPanelPositioner {
    readonly RootPanelPositioner _sut;

    protected TestsForRootPanelPositioner() {
      _sut = new RootPanelPositioner();
    }

    public class TestsForPosition : TestsForRootPanelPositioner {
      readonly Panel _rootPanel;
      readonly Position _rootPanelPosition;

      public TestsForPosition() {
        _rootPanel = new Panel();
        _rootPanelPosition = new Position();
      }

      [Fact]
      public void ShouldThrowIfArgumentsAreNull() {
        new Action(() => _sut.Position(null, _rootPanelPosition)).ShouldThrow<ArgumentNullException>();
        new Action(() => _sut.Position(_rootPanel, null)).ShouldThrow<ArgumentNullException>();
      }

      [Fact]
      public void ShouldReturnPanelRectangleWhichContainsRootRectangle() {
        _sut.Position(_rootPanel, _rootPanelPosition).Panel.Should().BeSameAs(_rootPanel);

      }

      [Fact]
      public void ShouldNotRotateTheRectangle() {
        _sut.Position(_rootPanel, _rootPanelPosition).Rotation.Should().Be(Rotation.None);
      }

      [Fact]
      public void ShouldCreateCorrectRectangle() {
        var panel = _rootPanel.WithDimensions(new Dimensions().WithWidth(100).WithHeight(200));
        var position = _rootPanelPosition.WithX(50).WithY(100);
        var actualRectangle = _sut.Position(panel, position).Rectangle;
        var expectedRectangle = new Rectangle(new Point(0, 300), new Size(100, 200));

        actualRectangle.ShouldBeEquivalentTo(expectedRectangle);
      }
    }
  }
}