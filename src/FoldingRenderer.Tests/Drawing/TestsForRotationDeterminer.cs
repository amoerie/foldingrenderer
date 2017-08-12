using System;
using System.Drawing;
using FluentAssertions;
using FoldingRenderer.Domain.Drawing;
using FoldingRenderer.Domain.Types;
using Xunit;

namespace FoldingRenderer.Tests.Domain.Drawing {
  public class TestsForRotationDeterminer {
    readonly RotationDeterminer _sut;

    protected TestsForRotationDeterminer() {
      _sut = new RotationDeterminer();
    }

    public class Determine : TestsForRotationDeterminer {
      readonly PanelRectangle _parent;
      readonly Panel _panel;

      public Determine() {
        _panel = new Panel();
        _parent = new PanelRectangle(_panel, new Rectangle(0,0,100,100), Rotation.None);
      }

      [Fact]
      public void ShouldThrowForNullArguments() {
        new Action(() => _sut.Determine(null, _panel)).ShouldThrow<ArgumentNullException>();
        new Action(() => _sut.Determine(_parent, null)).ShouldThrow<ArgumentNullException>();
      }

      [Fact]
      public void ShouldReturnDownWhenSideIsZero() {
        var hinge = _sut.Determine(_parent, _panel.WithAttachedToSide(0));
        hinge.Should().Be(Rotation.Down);
      }

      [Fact]
      public void ShouldReturnRightWhenSideIsOne() {
        var hinge = _sut.Determine(_parent, _panel.WithAttachedToSide(1));
        hinge.Should().Be(Rotation.Right);
      }

      [Fact]
      public void ShouldReturnNoneWhenSideIsTwo() {
        var hinge = _sut.Determine(_parent, _panel.WithAttachedToSide(2));
        hinge.Should().Be(Rotation.None);
      }

      [Fact]
      public void ShouldReturnLeftWhenSideIsThree() {
        var hinge = _sut.Determine(_parent, _panel.WithAttachedToSide(3));
        hinge.Should().Be(Rotation.Left);
      }

      [Theory]
      [InlineData(-1)]
      [InlineData(4)]
      [InlineData(500)]
      public void ShouldThrowArgumentOutOfRangeExceptionWhenSideIsOutsideValidRange(int side) {
        new Action(() => _sut.Determine(_parent, _panel.WithAttachedToSide(side))).ShouldThrow<ArgumentOutOfRangeException>();
      }


    }
  }
}