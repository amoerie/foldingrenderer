using System.Drawing;
using FoldingRenderer.Domain.Types;

namespace FoldingRenderer.Drawing {
  public interface IFoldingDrawer {
    Bitmap Draw(Folding folding);
  }

  public class FoldingDrawer : IFoldingDrawer {
    public Bitmap Draw(Folding folding) {
      var bitmap = new Bitmap(folding.Dimensions.Width, folding.Dimensions.Height);



      return bitmap;
    }
  }
}