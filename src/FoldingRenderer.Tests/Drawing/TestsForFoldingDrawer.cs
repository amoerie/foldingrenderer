using System;
using System.Collections.Immutable;
using System.Drawing;
using FakeItEasy;
using FluentAssertions;
using FoldingRenderer.Drawing;
using FoldingRenderer.Types;
using Xunit;

namespace FoldingRenderer.Tests.Drawing {
  public class TestsForFoldingDrawer {
    readonly FoldingDrawer _sut;
    readonly IEmptyCanvasFactory _emptyCanvasFactory;
    readonly IPanelRectangleFactory _panelRectangleFactory;
    readonly IRectangleDrawer _rectangleDrawer;

    protected TestsForFoldingDrawer() {
      _emptyCanvasFactory = A.Fake<IEmptyCanvasFactory>();
      _panelRectangleFactory = A.Fake<IPanelRectangleFactory>();
      _rectangleDrawer = A.Fake<IRectangleDrawer>();
      _sut = new FoldingDrawer(_emptyCanvasFactory, _panelRectangleFactory, _rectangleDrawer);
    }

    public class Draw : TestsForFoldingDrawer {
      readonly Folding _folding;
      readonly Dimensions _dimensions;
      readonly Position _rootPanelPosition;
      readonly Panel _rootPanel;

      public Draw() {
        _dimensions = new Dimensions();
        _rootPanel = new Panel();
        _rootPanelPosition = new Position();
        _folding = new Folding(_dimensions, _rootPanelPosition, _rootPanel);
      }

      [Fact]
      public void ShouldThrowWhenFoldingIsNull() {
        new Action(() => _sut.Draw(null)).ShouldThrow<ArgumentNullException>();
      }

      [Fact]
      public void ShouldCorrectlyCreateCanvasAndDrawRectanglesOnIt() {
        var emptyCanvas = A.Dummy<ICanvas>();
        A.CallTo(() => _emptyCanvasFactory.Create(_dimensions)).Returns(emptyCanvas);

        var firstRectangle = A.Dummy<Rectangle>();
        var secondRectangle = A.Dummy<Rectangle>();
        var thirdRectangle = A.Dummy<Rectangle>();
        A.CallTo(() => _panelRectangleFactory.Create(_rootPanel, _rootPanelPosition))
          .Returns(ImmutableList.Create(
            new PanelRectangle(new Panel().WithName("Panel 1"), firstRectangle, Rotation.None),
            new PanelRectangle(new Panel().WithName("Panel 2"), secondRectangle, Rotation.None),
            new PanelRectangle(new Panel().WithName("Panel 3"), thirdRectangle, Rotation.None)
          ));

        var canvasWithFirstRectangle = A.Dummy<ICanvas>();
        var canvasWithSecondRectangle = A.Dummy<ICanvas>();
        var canvasWithThirdRectangle = A.Dummy<ICanvas>();
        A.CallTo(() => _rectangleDrawer.Draw(emptyCanvas, firstRectangle)).Returns(canvasWithFirstRectangle);
        A.CallTo(() => _rectangleDrawer.Draw(canvasWithFirstRectangle, secondRectangle)).Returns(canvasWithSecondRectangle);
        A.CallTo(() => _rectangleDrawer.Draw(canvasWithSecondRectangle, thirdRectangle)).Returns(canvasWithThirdRectangle);

        var canvas = _sut.Draw(_folding);

        A.CallTo(() => _emptyCanvasFactory.Create(_dimensions)).MustHaveHappened();
        A.CallTo(() => _panelRectangleFactory.Create(_rootPanel, _rootPanelPosition)).MustHaveHappened();
        A.CallTo(() => _rectangleDrawer.Draw(emptyCanvas, firstRectangle)).MustHaveHappened();
        A.CallTo(() => _rectangleDrawer.Draw(canvasWithFirstRectangle, secondRectangle)).MustHaveHappened();
        A.CallTo(() => _rectangleDrawer.Draw(canvasWithSecondRectangle, thirdRectangle)).MustHaveHappened();

        canvas.Should().Be(canvasWithThirdRectangle);
      }



    }
  }
}