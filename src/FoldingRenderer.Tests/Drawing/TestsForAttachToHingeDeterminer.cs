using System;
using System.Drawing;
using FluentAssertions;
using FoldingRenderer.Domain.Drawing;
using FoldingRenderer.Domain.Types;
using Xunit;

namespace FoldingRenderer.Tests.Domain.Drawing {
  public class TestsForAttachToHingeDeterminer {
    readonly AttachToHingeDeterminer _sut;

    protected TestsForAttachToHingeDeterminer() {
      _sut = new AttachToHingeDeterminer();
    }

    public class Determine : TestsForAttachToHingeDeterminer {
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
      public void ShouldReturnBottomHingeWhenSideIsZero() {
        var hinge = _sut.Determine(_parent, _panel.WithAttachedToSide(0));
        hinge.Should().Be(_parent.Hinges.Bottom);
      }

      [Fact]
      public void ShouldReturnRightHingeWhenSideIsOne() {
        var hinge = _sut.Determine(_parent, _panel.WithAttachedToSide(1));
        hinge.Should().Be(_parent.Hinges.Right);
      }

      [Fact]
      public void ShouldReturnTopHingeWhenSideIsTwo() {
        var hinge = _sut.Determine(_parent, _panel.WithAttachedToSide(2));
        hinge.Should().Be(_parent.Hinges.Top);
      }

      [Fact]
      public void ShouldReturnLeftHingeWhenSideIsThree() {
        var hinge = _sut.Determine(_parent, _panel.WithAttachedToSide(3));
        hinge.Should().Be(_parent.Hinges.Left);
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