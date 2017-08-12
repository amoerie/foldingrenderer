using FluentAssertions;
using FoldingRenderer.Types;
using Xunit;

namespace FoldingRenderer.Tests.Types {
  public class TestsForDimensions {
    readonly Dimensions _dimensions;

    protected TestsForDimensions() {
      _dimensions = new Dimensions()
        .WithWidth(1)
        .WithHeight(2);
    }

    public class WithWidth : TestsForDimensions {
      readonly int _value;

      public WithWidth() {
        _value = 10;
      }

      [Fact]
      public void ShouldReturnNewPanelDimensionsWithUpdatedWidth() {
        _dimensions.WithWidth(_value).Should().NotBeSameAs(_dimensions);
      }

      [Fact]
      public void ShouldReturnPanelDimensionsWithUpdatedWidth() {
        _dimensions.WithWidth(_value).Width.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelDimensionsWithSamePropertiesExceptForWidth() {
        _dimensions.WithWidth(_value).ShouldBeEquivalentTo(_dimensions, c => c.Excluding(p => p.Width));
      }
    }

    public class WithHeight : TestsForDimensions {
      readonly int _value;

      public WithHeight() {
        _value = 10;
      }

      [Fact]
      public void ShouldReturnNewPanelDimensionsWithUpdatedHeight() {
        _dimensions.WithHeight(_value).Should().NotBeSameAs(_dimensions);
      }

      [Fact]
      public void ShouldReturnPanelDimensionsWithUpdatedHeight() {
        _dimensions.WithHeight(_value).Height.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelDimensionsWithSamePropertiesExceptForHeight() {
        _dimensions.WithHeight(_value).ShouldBeEquivalentTo(_dimensions, c => c.Excluding(p => p.Height));
      }
    }

    public class TestsForEquals : TestsForDimensions {

      [Theory]
      [InlineData(0, 0, 0, 0, true)]
      [InlineData(0, 0, 1, 1, false)]
      [InlineData(0, 0, 0, 1, false)]
      [InlineData(0, 0, 1, 0, false)]
      public void ShouldReturnExpectedResult(int width1, int height1, int width2, int height2, bool expectedResult) {
        var dimensions1 = new Dimensions().WithWidth(width1).WithHeight(height1);
        var dimensions2 = new Dimensions().WithWidth(width2).WithHeight(height2);
        dimensions1.Equals(dimensions2).Should().Be(expectedResult);
      }
    }
  }
}