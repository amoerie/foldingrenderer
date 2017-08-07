namespace FoldingRenderer.Models {
  public class PanelDimensions {
    public static readonly PanelDimensions None = new PanelDimensions();

    public double Width { get; }
    public double Height { get; }

    public PanelDimensions() : this(0, 0) {}

    PanelDimensions(double width, double height) {
      Width = width;
      Height = height;
    }

    public PanelDimensions WithWidth(int width) => new PanelDimensions(width, Height);
    public PanelDimensions WithHeight(int height) => new PanelDimensions(Width, height);
  }
}