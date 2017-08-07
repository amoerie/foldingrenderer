using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace FoldingRenderer.Storage.Jpg {
  public interface IDrawingSaver {
    FileInfo Save(Bitmap drawing);
  }

  public class DrawingSaver : IDrawingSaver {
    public FileInfo Save(Bitmap drawing) {
      var jpegFilePath = Path.Combine("./", "beerpack.jpg");
      var jpegFile = new FileInfo(jpegFilePath);
      if (jpegFile.Exists) {
        jpegFile.Delete();
      }
      drawing.Save(jpegFile.FullName, ImageFormat.Jpeg);
      return jpegFile;
    }
  }
}