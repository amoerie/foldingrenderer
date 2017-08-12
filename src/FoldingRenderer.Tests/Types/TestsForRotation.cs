using System;
using FluentAssertions;
using FoldingRenderer.Types;
using Xunit;

namespace FoldingRenderer.Tests.Types {
  public class TestsForRotation {
    public class Constructor {
      [Theory]
      [InlineData(-180)]
      [InlineData(180)]
      [InlineData(0)]
      [InlineData(90)]
      public void ShouldAcceptValuesBetweenMinus180AndPlus180(int rotation) {
        new Action(() => new Rotation(rotation)).ShouldNotThrow<ArgumentException>();
      }

      [Theory]
      [InlineData(-181)]
      [InlineData(181)]
      [InlineData(9000)]
      [InlineData(-9000)]
      public void ShouldRejectValuesOutsideMinus180AndPlus180(int rotation) {
        new Action(() => new Rotation(rotation)).ShouldThrow<ArgumentException>();
      }
    }

    public class ImplicitOperatorToInt {
      [Fact]
      public void ShouldReturnPrivateValue() {
        Rotation rotation = new Rotation(27);
        int rotationAsInt = rotation;
        rotationAsInt.Should().Be(27);
      }
    }

    public class PlusOperator {
      [Theory]
      [InlineData(0, 0, 0)]
      [InlineData(1, 1, 2)]
      [InlineData(180, 180, 0)]
      [InlineData(-180, -180, 0)]
      [InlineData(180, -180, 0)]
      [InlineData(90, -180, -90)]
      [InlineData(-90, 180, 90)]
      [InlineData(-90, -90, -180)]
      [InlineData(90, 90, 180)]
      public void ShouldProduceCorrectRotation(int first, int second, int expected) {
        (new Rotation(first) + new Rotation(second)).Should().Be(new Rotation(expected));
      }
    }
  }
}