using System;
using System.Drawing;
using FakeItEasy;
using FluentAssertions;
using FoldingRenderer.Domain.Drawing;
using FoldingRenderer.Domain.Types;
using Xunit;

namespace FoldingRenderer.Tests.Domain.Drawing {
  public class TestsForRootPanelPositioner {
    readonly RootPanelPositioner _sut;
    readonly IRectangleFactory _rectangleFactory;

    protected TestsForRootPanelPositioner() {
      _rectangleFactory = A.Fake<IRectangleFactory>();
      _sut = new RootPanelPositioner(_rectangleFactory);
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
      public void ShouldCreateCorrectRectangle() {
        var expectedRectangle = new Rectangle(new Point(0, 100), new Size(100, 200));
        A.CallTo(() => _rectangleFactory.Create(_rootPanelPosition, _rootPanel.Dimensions)).Returns(expectedRectangle);
        _sut.Position(_rootPanel, _rootPanelPosition).Rectangle.Should().Be(expectedRectangle);
      }
    }
  }
}