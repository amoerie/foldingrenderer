using FluentAssertions;
using FoldingRenderer.Domain.Types;
using Xunit;

namespace FoldingRenderer.Tests.Domain.Types {
  public class TestsForPanelDimensions {
    readonly PanelDimensions _panelDimensions;

    protected TestsForPanelDimensions() {
      _panelDimensions = new PanelDimensions()
        .WithWidth(1)
        .WithHeight(2);
    }

    public class WithWidth : TestsForPanelDimensions {
      readonly int _value;

      public WithWidth() {
        _value = 10;
      }

      [Fact]
      public void ShouldReturnNewPanelDimensionsWithUpdatedWidth() {
        _panelDimensions.WithWidth(_value).Should().NotBeSameAs(_panelDimensions);
      }

      [Fact]
      public void ShouldReturnPanelDimensionsWithUpdatedWidth() {
        _panelDimensions.WithWidth(_value).Width.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelDimensionsWithSamePropertiesExceptForWidth() {
        _panelDimensions.WithWidth(_value).ShouldBeEquivalentTo(_panelDimensions, c => c.Excluding(p => p.Width));
      }
    }

    public class WithHeight : TestsForPanelDimensions {
      readonly int _value;

      public WithHeight() {
        _value = 10;
      }

      [Fact]
      public void ShouldReturnNewPanelDimensionsWithUpdatedHeight() {
        _panelDimensions.WithHeight(_value).Should().NotBeSameAs(_panelDimensions);
      }

      [Fact]
      public void ShouldReturnPanelDimensionsWithUpdatedHeight() {
        _panelDimensions.WithHeight(_value).Height.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelDimensionsWithSamePropertiesExceptForHeight() {
        _panelDimensions.WithHeight(_value).ShouldBeEquivalentTo(_panelDimensions, c => c.Excluding(p => p.Height));
      }
    }
  }
}