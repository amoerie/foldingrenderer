using System.Drawing;
using FluentAssertions;
using FoldingRenderer.Domain.Drawing;
using FoldingRenderer.Domain.Types;
using Xunit;

namespace FoldingRenderer.Tests.Domain.Drawing {
  public class TestsForRectangleFactory {
    readonly RectangleFactory _sut;

    public TestsForRectangleFactory() {
      _sut = new RectangleFactory();
    }

    public class Create : TestsForRectangleFactory {

      [Fact]
      public void ShouldCreateCorrectRectangle() {
        var dimensions = new Dimensions().WithWidth(100).WithHeight(200);
        var bottomHingePosition = new Position().WithX(50).WithY(300);
        var actualRectangle = _sut.Create(bottomHingePosition, dimensions);
        var expectedRectangle = new Rectangle(new Point(0, 100), new Size(100, 200));

        actualRectangle.ShouldBeEquivalentTo(expectedRectangle);
      }

    }
  }
}