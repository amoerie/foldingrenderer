using System;

namespace FoldingRenderer.Types {
  public struct Rotation {
    public static Rotation None = new Rotation(0);
    public static Rotation Right = new Rotation(90);
    public static Rotation Down = new Rotation(180);
    public static Rotation Left = new Rotation(-90);

    readonly int _value;

    public Rotation(int value) {
      if(value < -180 || value > 180)
        throw new ArgumentException($"Rotation must be between -180° and 180°, tried to pass in {value}°");
      _value = value;
    }

    public static implicit operator int(Rotation r) {
      return r._value;
    }

    public int Value => _value;

    public static Rotation operator +(Rotation first, Rotation second) {
      return new Rotation((first.Value + second.Value)%360);
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
