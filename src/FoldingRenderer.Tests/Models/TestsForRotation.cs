using System;
using FluentAssertions;
using FoldingRenderer.Models;
using Xunit;

namespace FoldingRenderer.Tests.Models {
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
  }
}