using System;
using System.Linq;
using FoldingRenderer.Types;

namespace FoldingRenderer.Drawing {
  public interface IFoldingDrawer {
    /// <summary>
    /// Draws the specified folding on a new canvas.
    /// </summary>
    ICanvas Draw(Folding folding);
  }

  public class FoldingDrawer : IFoldingDrawer {
    readonly IEmptyCanvasFactory _emptyCanvasFactory;
    readonly IPanelRectangleFactory _panelRectangleFactory;
    readonly IRectangleDrawer _rectangleDrawer;

    public FoldingDrawer(IEmptyCanvasFactory emptyCanvasFactory, IPanelRectangleFactory panelRectangleFactory, IRectangleDrawer rectangleDrawer) {
      if (emptyCanvasFactory == null) throw new ArgumentNullException(nameof(emptyCanvasFactory));
      if (panelRectangleFactory == null) throw new ArgumentNullException(nameof(panelRectangleFactory));
      if (rectangleDrawer == null) throw new ArgumentNullException(nameof(rectangleDrawer));
      _emptyCanvasFactory = emptyCanvasFactory;
      _panelRectangleFactory = panelRectangleFactory;
      _rectangleDrawer = rectangleDrawer;
    }

    public ICanvas Draw(Folding folding) {
      if (folding == null) throw new ArgumentNullException(nameof(folding));
      var emptyCanvas = _emptyCanvasFactory.Create(folding.Dimensions);
      var panelRectangles = _panelRectangleFactory.Create(folding.RootPanel, folding.RootPanelPosition);
      var canvasWithRectangles = panelRectangles
        .Select(panelRectangle => panelRectangle.Rectangle)
        .Aggregate(emptyCanvas, (canvas, rectangle) => _rectangleDrawer.Draw(canvas, rectangle));
      return canvasWithRectangles;
    }
  }
}