using System;
using FakeItEasy;
using FluentAssertions;
using FoldingRenderer.Drawing;
using FoldingRenderer.Types;
using Xunit;

namespace FoldingRenderer.Tests.Drawing {
  public class TestsForRootPanelDrawer {
    readonly IRootPanelPositioner _rootPanelPositioner;
    readonly IPanelRectangleDrawer _panelRectangleDrawer;
    readonly RootPanelDrawer _sut;

    public TestsForRootPanelDrawer() {
      _rootPanelPositioner = A.Fake<IRootPanelPositioner>();
      _panelRectangleDrawer = A.Fake<IPanelRectangleDrawer>();
      _sut = new RootPanelDrawer(_rootPanelPositioner, _panelRectangleDrawer);
    }

    public class Draw : TestsForRootPanelDrawer {
      readonly Panel _rootPanel;
      readonly Position _rootPanelPosition;
      readonly ICanvas _originalCanvas;

      public Draw() {
        _originalCanvas = A.Dummy<ICanvas>();
        _rootPanel = new Panel();
        _rootPanelPosition = new Position();
      }

      [Fact]
      public void ShouldThrowWhenBitmapIsNull() {
        new Action(() => _sut.Draw(null, _rootPanel, _rootPanelPosition)).ShouldThrow<ArgumentNullException>();
      }

      [Fact]
      public void ShouldThrowWhenRootPanelIsNull() {
        new Action(() => _sut.Draw(_originalCanvas, null, _rootPanelPosition)).ShouldThrow<ArgumentNullException>();
      }

      [Fact]
      public void ShouldThrowWhenRootPanelPositionIsNull() {
        new Action(() => _sut.Draw(_originalCanvas, _rootPanel, null)).ShouldThrow<ArgumentNullException>();
      }

      [Fact]
      public void ShouldDrawRootPanelInCorrectPosition() {
        var panelRectangle = A.Dummy<PanelRectangle>();
        A.CallTo(() => _rootPanelPositioner.Position(_rootPanel, _rootPanelPosition)).Returns(panelRectangle);
        var modifiedCanvas = A.Dummy<ICanvas>();
        A.CallTo(() => _panelRectangleDrawer.Draw(_originalCanvas, panelRectangle)).Returns(modifiedCanvas);
        _sut.Draw(_originalCanvas, _rootPanel, _rootPanelPosition).Should().BeSameAs(modifiedCanvas);
      }

    }

  }
}