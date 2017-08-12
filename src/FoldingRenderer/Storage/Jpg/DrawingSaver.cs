using System;
using System.Drawing.Imaging;
using System.IO;
using FoldingRenderer.Drawing;

namespace FoldingRenderer.Storage.Jpg {
  public interface IDrawingSaver {
    FileInfo Save(ICanvas canvas);
  }

  public class DrawingSaver : IDrawingSaver {
    public FileInfo Save(ICanvas canvas) {
      if (canvas == null) throw new ArgumentNullException(nameof(canvas));
      var jpegFilePath = Path.Combine("./", "beerpack.jpg");
      var jpegFile = new FileInfo(jpegFilePath);
      if (jpegFile.Exists) {
        jpegFile.Delete();
      }
      canvas.Bitmap.Save(jpegFile.FullName, ImageFormat.Jpeg);
      return jpegFile;
    }
  }
}