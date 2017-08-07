using FluentAssertions;
using FoldingRenderer.Domain.Types;
using Xunit;

namespace FoldingRenderer.Tests.Domain.Types {
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
  }
}