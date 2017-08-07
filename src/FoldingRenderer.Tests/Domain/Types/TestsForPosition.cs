﻿using FluentAssertions;
using FoldingRenderer.Domain.Types;
using Xunit;

namespace FoldingRenderer.Tests.Domain.Types {
  public class TestsForPosition {
    readonly Position _position;

    protected TestsForPosition() {
      _position = new Position()
        .WithX(1)
        .WithY(2);
    }

    public class WithX : TestsForPosition {
      readonly int _value;

      public WithX() {
        _value = 10;
      }

      [Fact]
      public void ShouldReturnNewPanelPositionWithUpdatedX() {
        _position.WithX(_value).Should().NotBeSameAs(_position);
      }

      [Fact]
      public void ShouldReturnPanelPositionWithUpdatedX() {
        _position.WithX(_value).X.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelPositionWithSamePropertiesExceptForX() {
        _position.WithX(_value).ShouldBeEquivalentTo(_position, c => c.Excluding(p => p.X));
      }
    }

    public class WithY : TestsForPosition {
      readonly int _value;

      public WithY() {
        _value = 10;
      }

      [Fact]
      public void ShouldReturnNewPanelPositionWithUpdatedY() {
        _position.WithY(_value).Should().NotBeSameAs(_position);
      }

      [Fact]
      public void ShouldReturnPanelPositionWithUpdatedY() {
        _position.WithY(_value).Y.Should().Be(_value);
      }

      [Fact]
      public void ShouldReturnPanelPositionWithSamePropertiesExceptForY() {
        _position.WithY(_value).ShouldBeEquivalentTo(_position, c => c.Excluding(p => p.Y));
      }
    }
  }
}