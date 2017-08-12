using System;
using System.Drawing;
using FluentAssertions;
using FoldingRenderer.Drawing;
using FoldingRenderer.Types;
using Xunit;

namespace FoldingRenderer.Tests.Drawing {
  public class TestsForRectangleRotator {
    readonly RectangleRotator _sut;

    protected TestsForRectangleRotator() {
      _sut = new RectangleRotator();
    }

    public class Rotate : TestsForRectangleRotator {
      readonly Rectangle _rectangle;
      readonly Position _hinge;

      public Rotate() {
        /*
         *                             300px
         *           <--------------------------------------->
         *         (0,0)                                 (300,0) 
         *       ^   o-------------------o-------------------o
         *       |   |                                       |
         *       |   |                                       |
         * 100px |   |                                       |
         *       |   |                                       |
         *       |   |                                       |
         *       v   o-------------------o-------------------o
         *         (0,100)           (150,100)           (300,100)
         *                          
         */
        _rectangle = new Rectangle(new Point(0,0), new Size(300,100));
        _hinge = new Position().WithX(150).WithY(100);
      }

      [Fact]
      public void ShouldJustReturnTheRectangleWhenRotationIsNone() {
        _sut.Rotate(_hinge, _rectangle, Rotation.None).ShouldBeEquivalentTo(_rectangle);
      }

      [Theory]
      [InlineData(-179)]
      [InlineData(-1)]
      [InlineData(1)]
      [InlineData(179)]
      public void ShouldThrowForUnsupportedRotations(int rotation) {
        new Action(() => _sut.Rotate(_hinge, _rectangle, new Rotation(rotation))).ShouldThrow<NotSupportedException>();
      }

      [Fact]
      public void ShouldCorrectlyRotateRight() {
        var actualRectangle = _sut.Rotate(_hinge, _rectangle, Rotation.Right);
        var expectedRectangle = new Rectangle(new Point(150,-50), new Size(100,300));
        actualRectangle.ShouldBeEquivalentTo(expectedRectangle);
      }

      [Fact]
      public void ShouldCorrectlyRotateLeft() {
        var actualRectangle = _sut.Rotate(_hinge, _rectangle, Rotation.Left);
        var expectedRectangle = new Rectangle(new Point(50,-50), new Size(100, 300));
        actualRectangle.ShouldBeEquivalentTo(expectedRectangle);
      }

      [Fact]
      public void ShouldCorrectlyRotateDown() {
        var actualRectangle = _sut.Rotate(_hinge, _rectangle, Rotation.Down);
        var expectedRectangle = new Rectangle(new Point(0,100), new Size(300, 100));
        actualRectangle.ShouldBeEquivalentTo(expectedRectangle);
      }

    }
  }
}