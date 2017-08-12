using System;
using System.Collections.Immutable;
using FluentAssertions;
using FoldingRenderer.Domain.Types;
using Xunit;

namespace FoldingRenderer.Tests.Domain.Types {
  public class TestsForPanel {
    readonly Panel _panel;

    protected TestsForPanel() {
      _panel = new Panel()
        .WithId(Guid.NewGuid())
        .WithName("Panel 1")
        .WithRotation(new PanelRotation().WithInitial(new Rotation(154)))
        .WithHingeOffset(0.5)
        .WithDimensions(new Dimensions().WithWidth(411))
        .WithAttachedToSide(3)
        .WithCrease(new PanelCrease().WithRight(45))
        .WithIgnoreCollisions(true)
        .WithMouseEnabled(true)
        .WithAttachedPanels(ImmutableList.Create(new Panel()));
    }

    public class WithId : TestsForPanel {
      readonly Guid _value;

      public WithId() {
        _value = new Guid("3073F7DE-6864-4714-9901-66347123387C");
      }

      [Fact]
      public void ShouldReturnNewPanelWithUpdatedId() {
        _panel.WithId(_value).Should().NotBeSameAs(_panel);
      }

      [Fact]
      public void ShouldReturnPanelWithUpdatedId() {
        _panel.WithId(_value).Id.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelWithSamePropertiesExceptForId() {
        _panel.WithId(_value).ShouldBeEquivalentTo(_panel, c => c.Excluding(p => p.Id));
      }
    }

    public class WithName : TestsForPanel {
      readonly string _value;

      public WithName() {
        _value = "Panel 2";
      }

      [Fact]
      public void ShouldReturnNewPanelWithUpdatedName() {
        _panel.WithName(_value).Should().NotBeSameAs(_panel);
      }

      [Fact]
      public void ShouldReturnPanelWithUpdatedName() {
        _panel.WithName(_value).Name.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelWithSamePropertiesExceptForName() {
        _panel.WithName(_value).ShouldBeEquivalentTo(_panel, c => c.Excluding(p => p.Name));
      }
    }

    public class WithRotation : TestsForPanel {
      readonly PanelRotation _value;

      public WithRotation() {
        _value = new PanelRotation().WithStart(new Rotation(47));
      }

      [Fact]
      public void ShouldReturnNewPanelWithUpdatedRotation() {
        _panel.WithRotation(_value).Should().NotBeSameAs(_panel);
      }

      [Fact]
      public void ShouldReturnPanelWithUpdatedRotation() {
        _panel.WithRotation(_value).Rotation.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelWithSamePropertiesExceptForRotation() {
        _panel.WithRotation(_value).ShouldBeEquivalentTo(_panel, c => c.Excluding(p => p.Rotation));
      }
    }

    public class WithHingeOffset : TestsForPanel {
      readonly int _value;

      public WithHingeOffset() {
        _value = 444;
      }

      [Fact]
      public void ShouldReturnNewPanelWithUpdatedHingeOffset() {
        _panel.WithHingeOffset(_value).Should().NotBeSameAs(_panel);
      }

      [Fact]
      public void ShouldReturnPanelWithUpdatedHingeOffset() {
        _panel.WithHingeOffset(_value).HingeOffset.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelWithSamePropertiesExceptForHingeOffset() {
        _panel.WithHingeOffset(_value).ShouldBeEquivalentTo(_panel, c => c.Excluding(p => p.HingeOffset));
      }
    }

    public class WithDimensions : TestsForPanel {
      readonly Dimensions _value;

      public WithDimensions() {
        _value = new Dimensions().WithHeight(448);
      }

      [Fact]
      public void ShouldReturnNewPanelWithUpdatedDimensions() {
        _panel.WithDimensions(_value).Should().NotBeSameAs(_panel);
      }

      [Fact]
      public void ShouldReturnPanelWithUpdatedDimensions() {
        _panel.WithDimensions(_value).Dimensions.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelWithSamePropertiesExceptForDimensions() {
        _panel.WithDimensions(_value).ShouldBeEquivalentTo(_panel, c => c.Excluding(p => p.Dimensions));
      }
    }

    public class WithAttachedToSide : TestsForPanel {
      readonly int _value;

      public WithAttachedToSide() {
        _value = 474;
      }

      [Fact]
      public void ShouldReturnNewPanelWithUpdatedAttachedToSide() {
        _panel.WithAttachedToSide(_value).Should().NotBeSameAs(_panel);
      }

      [Fact]
      public void ShouldReturnPanelWithUpdatedAttachedToSide() {
        _panel.WithAttachedToSide(_value).AttachedToSide.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelWithSamePropertiesExceptForAttachedToSide() {
        _panel.WithAttachedToSide(_value).ShouldBeEquivalentTo(_panel, c => c.Excluding(p => p.AttachedToSide));
      }
    }

    public class WithCrease : TestsForPanel {
      readonly PanelCrease _value;

      public WithCrease() {
        _value = new PanelCrease().WithLeft(11);
      }

      [Fact]
      public void ShouldReturnNewPanelWithUpdatedCrease() {
        _panel.WithCrease(_value).Should().NotBeSameAs(_panel);
      }

      [Fact]
      public void ShouldReturnPanelWithUpdatedCrease() {
        _panel.WithCrease(_value).Crease.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelWithSamePropertiesExceptForCrease() {
        _panel.WithCrease(_value).ShouldBeEquivalentTo(_panel, c => c.Excluding(p => p.Crease));
      }
    }

    public class WithIgnoreCollisions : TestsForPanel {
      readonly bool _value;

      public WithIgnoreCollisions() {
        _value = !_panel.IgnoreCollisions;
      }

      [Fact]
      public void ShouldReturnNewPanelWithUpdatedIgnoreCollisions() {
        _panel.WithIgnoreCollisions(_value).Should().NotBeSameAs(_panel);
      }

      [Fact]
      public void ShouldReturnPanelWithUpdatedIgnoreCollisions() {
        _panel.WithIgnoreCollisions(_value).IgnoreCollisions.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelWithSamePropertiesExceptForIgnoreCollisions() {
        _panel.WithIgnoreCollisions(_value).ShouldBeEquivalentTo(_panel, c => c.Excluding(p => p.IgnoreCollisions));
      }
    }

    public class WithMouseEnabled : TestsForPanel {
      readonly bool _value;

      public WithMouseEnabled() {
        _value = !_panel.MouseEnabled;
      }

      [Fact]
      public void ShouldReturnNewPanelWithUpdatedMouseEnabled() {
        _panel.WithMouseEnabled(_value).Should().NotBeSameAs(_panel);
      }

      [Fact]
      public void ShouldReturnPanelWithUpdatedMouseEnabled() {
        _panel.WithMouseEnabled(_value).MouseEnabled.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelWithSamePropertiesExceptForMouseEnabled() {
        _panel.WithMouseEnabled(_value).ShouldBeEquivalentTo(_panel, c => c.Excluding(p => p.MouseEnabled));
      }
    }

    public class WithAttachedPanels : TestsForPanel {
      readonly IImmutableList<Panel> _value;

      public WithAttachedPanels() {
        _value = ImmutableList.Create(new Panel().WithId(Guid.NewGuid()), new Panel().WithId(Guid.NewGuid()));
      }

      [Fact]
      public void ShouldReturnNewPanelWithUpdatedAttachedPanels() {
        _panel.WithAttachedPanels(_value).Should().NotBeSameAs(_panel);
      }

      [Fact]
      public void ShouldReturnPanelWithUpdatedAttachedPanels() {
        _panel.WithAttachedPanels(_value).AttachedPanels.ShouldBeEquivalentTo(_value);
      }

      [Fact]
      public void ShouldReturnPanelWithSamePropertiesExceptForAttachedPanels() {
        _panel.WithAttachedPanels(_value).ShouldBeEquivalentTo(_panel, c => c.Excluding(p => p.AttachedPanels));
      }
    }
  }
}