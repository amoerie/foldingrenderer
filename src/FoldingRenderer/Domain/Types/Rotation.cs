using System;

namespace FoldingRenderer.Domain.Types {
  public struct Rotation {
    public static Rotation None = new Rotation(0);

    readonly int _value;

    public Rotation(int value) {
      if(value < -180 || value > 180)
        throw new ArgumentException("Rotation must be between -180° and 180°");
      _value = value;
    }

    public static implicit operator int(Rotation r) {
      return r._value;
    }

    public bool Equals(Rotation other) {
      return _value == other._value;
    }

    public override bool Equals(object obj) {
      if (ReferenceEquals(null, obj)) return false;
      return obj is Rotation && Equals((Rotation)obj);
    }

    public override int GetHashCode() {
      return _value;
    }
  }
}
