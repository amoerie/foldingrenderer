using System;

namespace FoldingRenderer.Types {
  public struct Rotation {
    public static Rotation None = new Rotation(0);
    public static Rotation Right = new Rotation(90);
    public static Rotation Down = new Rotation(180);
    public static Rotation Left = new Rotation(-90);

    public Rotation(int value) {
      if (value < -180 || value > 180) throw new ArgumentException($"Rotation must be between -180° and 180°, tried to pass in {value}°");
      Value = value;
    }

    public static implicit operator int(Rotation r) {
      return r.Value;
    }

    public int Value { get; }

    public static Rotation operator +(Rotation first, Rotation second) {
      return new Rotation((first.Value + second.Value) % 360);
    }

    public bool Equals(Rotation other) {
      return (Value + 180) % 360 == (other.Value + 180) % 360;
    }

    public override bool Equals(object obj) {
      if (ReferenceEquals(null, obj)) return false;
      return obj is Rotation && Equals((Rotation)obj);
    }

    public override int GetHashCode() {
      return Value;
    }
  }
}