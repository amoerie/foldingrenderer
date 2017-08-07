using FluentAssertions;
using FoldingRenderer.Domain.Types;
using Xunit;

namespace FoldingRenderer.Tests.Domain.Types {
  public class TestsForPanelCrease {
    readonly PanelCrease _panelCrease;

    protected TestsForPanelCrease() {
      _panelCrease = new PanelCrease()
        .WithBottom(1)
        .WithTop(2)
        .WithLeft(3)
        .WithRight(4);
    }

    public class WithBottom : TestsForPanelCrease {
      readonly int _value;

      public WithBottom() {
        _value = 10;
      }

      [Fact]
      public void ShouldReturnNewPanelCreaseWithUpdatedBottom() {
        _panelCrease.WithBottom(_value).Should().NotBeSameAs(_panelCrease);
      }

      [Fact]
      public void ShouldReturnPanelCreaseWithUpdatedBottom() {
        _panelCrease.WithBottom(_value).Bottom.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelCreaseWithSamePropertiesExceptForBottom() {
        _panelCrease.WithBottom(_value).ShouldBeEquivalentTo(_panelCrease, c => c.Excluding(p => p.Bottom));
      }
    }

    public class WithTop : TestsForPanelCrease {
      readonly int _value;

      public WithTop() {
        _value = 10;
      }

      [Fact]
      public void ShouldReturnNewPanelCreaseWithUpdatedTop() {
        _panelCrease.WithTop(_value).Should().NotBeSameAs(_panelCrease);
      }

      [Fact]
      public void ShouldReturnPanelCreaseWithUpdatedTop() {
        _panelCrease.WithTop(_value).Top.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelCreaseWithSamePropertiesExceptForTop() {
        _panelCrease.WithTop(_value).ShouldBeEquivalentTo(_panelCrease, c => c.Excluding(p => p.Top));
      }
    }

    public class WithLeft : TestsForPanelCrease {
      readonly int _value;

      public WithLeft() {
        _value = 10;
      }

      [Fact]
      public void ShouldReturnNewPanelCreaseWithUpdatedLeft() {
        _panelCrease.WithLeft(_value).Should().NotBeSameAs(_panelCrease);
      }

      [Fact]
      public void ShouldReturnPanelCreaseWithUpdatedLeft() {
        _panelCrease.WithLeft(_value).Left.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelCreaseWithSamePropertiesExceptForLeft() {
        _panelCrease.WithLeft(_value).ShouldBeEquivalentTo(_panelCrease, c => c.Excluding(p => p.Left));
      }
    }

    public class WithRight : TestsForPanelCrease {
      readonly int _value;

      public WithRight() {
        _value = 10;
      }

      [Fact]
      public void ShouldReturnNewPanelCreaseWithUpdatedRight() {
        _panelCrease.WithRight(_value).Should().NotBeSameAs(_panelCrease);
      }

      [Fact]
      public void ShouldReturnPanelCreaseWithUpdatedRight() {
        _panelCrease.WithRight(_value).Right.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelCreaseWithSamePropertiesExceptForRight() {
        _panelCrease.WithRight(_value).ShouldBeEquivalentTo(_panelCrease, c => c.Excluding(p => p.Right));
      }
    }

  }
}