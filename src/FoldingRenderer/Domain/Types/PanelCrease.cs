namespace FoldingRenderer.Domain.Types {
  public class PanelCrease {
    public static readonly PanelCrease None = new PanelCrease();

    public double Bottom { get; }
    public double Top { get; }
    public double Left { get; }
    public double Right { get; }

    public PanelCrease() : this(0, 0, 0, 0) { }

    PanelCrease(double bottom, double top, double left, double right) {
      Bottom = bottom;
      Top = top;
      Left = left;
      Right = right;
    }

    public PanelCrease WithBottom(int bottom) => new PanelCrease(bottom, Top, Left, Right);
    public PanelCrease WithTop(int top) => new PanelCrease(Bottom, top, Left, Right);
    public PanelCrease WithLeft(int left) => new PanelCrease(Bottom, Top, left, Right);
    public PanelCrease WithRight(int right) => new PanelCrease(Bottom, Top, Left, right);
  }
}