using FluentAssertions;
using FoldingRenderer.Types;
using Xunit;

namespace FoldingRenderer.Tests.Types {
  public class TestsForPanelRotation {
    readonly PanelRotation _panelRotation;

    protected TestsForPanelRotation() {
      _panelRotation = new PanelRotation()
        .WithMinimum(new Rotation(1))
        .WithMaximum(new Rotation(2))
        .WithInitial(new Rotation(3))
        .WithStart(new Rotation(4))
        .WithEnd(new Rotation(5));
    }

    public class WithMinimum : TestsForPanelRotation {
      public WithMinimum() {
        _value = new Rotation(10);
      }

      readonly Rotation _value;

      [Fact]
      public void ShouldReturnNewPanelRotationWithUpdatedMinimum() {
        _panelRotation.WithMinimum(_value).Should().NotBeSameAs(_panelRotation);
      }

      [Fact]
      public void ShouldReturnPanelRotationWithSamePropertiesExceptForMinimum() {
        _panelRotation.WithMinimum(_value).ShouldBeEquivalentTo(_panelRotation, c => c.Excluding(p => p.Minimum));
      }

      [Fact]
      public void ShouldReturnPanelRotationWithUpdatedMinimum() {
        _panelRotation.WithMinimum(_value).Minimum.Should().Be(_value);
      }
    }

    public class WithMaximum : TestsForPanelRotation {
      public WithMaximum() {
        _value = new Rotation(10);
      }

      readonly Rotation _value;

      [Fact]
      public void ShouldReturnNewPanelRotationWithUpdatedMaximum() {
        _panelRotation.WithMaximum(_value).Should().NotBeSameAs(_panelRotation);
      }

      [Fact]
      public void ShouldReturnPanelRotationWithSamePropertiesExceptForMaximum() {
        _panelRotation.WithMaximum(_value).ShouldBeEquivalentTo(_panelRotation, c => c.Excluding(p => p.Maximum));
      }

      [Fact]
      public void ShouldReturnPanelRotationWithUpdatedMaximum() {
        _panelRotation.WithMaximum(_value).Maximum.Should().Be(_value);
      }
    }

    public class WithInitial : TestsForPanelRotation {
      public WithInitial() {
        _value = new Rotation(10);
      }

      readonly Rotation _value;

      [Fact]
      public void ShouldReturnNewPanelRotationWithUpdatedInitial() {
        _panelRotation.WithInitial(_value).Should().NotBeSameAs(_panelRotation);
      }

      [Fact]
      public void ShouldReturnPanelRotationWithSamePropertiesExceptForInitial() {
        _panelRotation.WithInitial(_value).ShouldBeEquivalentTo(_panelRotation, c => c.Excluding(p => p.Initial));
      }

      [Fact]
      public void ShouldReturnPanelRotationWithUpdatedInitial() {
        _panelRotation.WithInitial(_value).Initial.Should().Be(_value);
      }
    }

    public class WithStart : TestsForPanelRotation {
      public WithStart() {
        _value = new Rotation(10);
      }

      readonly Rotation _value;

      [Fact]
      public void ShouldReturnNewPanelRotationWithUpdatedStart() {
        _panelRotation.WithStart(_value).Should().NotBeSameAs(_panelRotation);
      }

      [Fact]
      public void ShouldReturnPanelRotationWithSamePropertiesExceptForStart() {
        _panelRotation.WithStart(_value).ShouldBeEquivalentTo(_panelRotation, c => c.Excluding(p => p.Start));
      }

      [Fact]
      public void ShouldReturnPanelRotationWithUpdatedStart() {
        _panelRotation.WithStart(_value).Start.Should().Be(_value);
      }
    }

    public class WithEnd : TestsForPanelRotation {
      public WithEnd() {
        _value = new Rotation(10);
      }

      readonly Rotation _value;

      [Fact]
      public void ShouldReturnNewPanelRotationWithUpdatedEnd() {
        _panelRotation.WithEnd(_value).Should().NotBeSameAs(_panelRotation);
      }

      [Fact]
      public void ShouldReturnPanelRotationWithSamePropertiesExceptForEnd() {
        _panelRotation.WithEnd(_value).ShouldBeEquivalentTo(_panelRotation, c => c.Excluding(p => p.End));
      }

      [Fact]
      public void ShouldReturnPanelRotationWithUpdatedEnd() {
        _panelRotation.WithEnd(_value).End.Should().Be(_value);
      }
    }
  }
}