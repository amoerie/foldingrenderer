using System;
using System.Drawing;
using FakeItEasy;
using FluentAssertions;
using FoldingRenderer.Drawing;
using FoldingRenderer.Types;
using Xunit;

namespace FoldingRenderer.Tests.Drawing {
  public class TestsForPanelPositioner {
    readonly PanelPositioner _sut;
    readonly IAttachToHingeDeterminer _attachToHingeDeterminer;
    readonly IRotationDeterminer _rotationDeterminer;
    readonly IRectangleFactory _rectangleFactory;
    readonly IRectangleRotator _rectangleRotator;
    readonly IHingeOffsetApplier _hingeOffsetApplier;

    protected TestsForPanelPositioner() {
      _attachToHingeDeterminer = A.Fake<IAttachToHingeDeterminer>();
      _rotationDeterminer = A.Fake<IRotationDeterminer>();
      _rectangleFactory = A.Fake<IRectangleFactory>();
      _rectangleRotator = A.Fake<IRectangleRotator>();
      _hingeOffsetApplier = A.Fake<IHingeOffsetApplier>();
      _sut = new PanelPositioner(
        _attachToHingeDeterminer, _rotationDeterminer, _rectangleFactory,
        _rectangleRotator, _hingeOffsetApplier);
    }

    public class TestsForPosition : TestsForPanelPositioner {
      public TestsForPosition() {
        _panel = A.Dummy<Panel>();
        var rectangle = new Rectangle(10,20,30,40);
        var rotation = new Rotation(154);
        _parent = new PanelRectangle(_panel, rectangle, rotation);
      }

      readonly PanelRectangle _parent;
      readonly Panel _panel;

      [Fact]
      public void ShouldApplyTheVariousContributorsToAPanelRectangleInTheCorrectOrder() {
        var hingeToAttachTo = new Position().WithX(10).WithY(20);
        A.CallTo(() => _attachToHingeDeterminer.Determine(_parent, _panel)).Returns(hingeToAttachTo);
        var rectangle = new Rectangle(0, 1, 2, 3);
        A.CallTo(() => _rectangleFactory.Create(hingeToAttachTo, _panel.Dimensions)).Returns(rectangle);
        A.CallTo(() => _rotationDeterminer.Determine(_parent, _panel)).Returns(Rotation.Right);
        var rotatedRectangle = new Rectangle(1, 2, 3, 4);
        A.CallTo(() => _rectangleRotator.Rotate(hingeToAttachTo, rectangle, Rotation.Right)).Returns(rotatedRectangle);
        var rotatedRectangleWithHingeOffset = new Rectangle(2, 3, 4, 5);
        A.CallTo(() => _hingeOffsetApplier.Apply(rotatedRectangle, Rotation.Right, _panel.HingeOffset))
          .Returns(rotatedRectangleWithHingeOffset);

        var actualPanelRectangle = _sut.Position(_parent, _panel);
        var expectedPanelRectangle = new PanelRectangle(_panel, rotatedRectangleWithHingeOffset, Rotation.Right);

        actualPanelRectangle.ShouldBeEquivalentTo(expectedPanelRectangle);
      }

      [Fact]
      public void ShouldThrowWhenPanelIsNull() {
        new Action(() => _sut.Position(_parent, null)).ShouldThrow<ArgumentNullException>();
      }

      [Fact]
      public void ShouldThrowWhenParentIsNull() {
        new Action(() => _sut.Position(null, _panel)).ShouldThrow<ArgumentNullException>();
      }
    }
  }
}