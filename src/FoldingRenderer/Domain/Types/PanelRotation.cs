namespace FoldingRenderer.Domain.Types {
  public class PanelRotation {
    public static readonly PanelRotation None = new PanelRotation();

    public Rotation Minimum { get; }
    public Rotation Maximum { get; }
    public Rotation Initial { get; }
    public Rotation Start { get; }
    public Rotation End { get; }

    public PanelRotation() { }

    PanelRotation(Rotation minimum, Rotation maximum, Rotation initial, Rotation start, Rotation end) {
      Minimum = minimum;
      Maximum = maximum;
      Initial = initial;
      Start = start;
      End = end;
    }

    public PanelRotation WithMinimum(Rotation minimum) => new PanelRotation(minimum, Maximum, Initial, Start, End);
    public PanelRotation WithMaximum(Rotation maximum) => new PanelRotation(Minimum, maximum, Initial, Start, End);
    public PanelRotation WithInitial(Rotation initial) => new PanelRotation(Minimum, Maximum, initial, Start, End);
    public PanelRotation WithStart(Rotation start) => new PanelRotation(Minimum, Maximum, Initial, start, End);
    public PanelRotation WithEnd(Rotation end) => new PanelRotation(Minimum, Maximum, Initial, Start, end);
  }
}