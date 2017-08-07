using System;

namespace FoldingRenderer.Models {
  public struct Rotation {
    readonly int _value;

    public Rotation(int value) {
      if(value < -180 || value > 180)
        throw new ArgumentException("Rotation must be between -180° and 180°");
      _value = value;
    }

    public static implicit operator int(Rotation r) {
      return r._value;
    }
  }
}
