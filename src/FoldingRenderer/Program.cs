using System;
using System.Diagnostics;
using FoldingRenderer.Drawing;
using FoldingRenderer.Storage;
using FoldingRenderer.Storage.Jpg;
using FoldingRenderer.Storage.Xml;

namespace FoldingRenderer {
  public class Program {
    public static void Main(string[] args) {
      var foldingLoader = CreateFoldingLoader();
      var foldingDrawer = CreateFoldingDrawer();
      var drawingSaver = CreateDrawingSaver();

      /**
       * Future improvement: accept file path from command line and load file from file system
       */
      Console.WriteLine("Loading file");
      var folding = foldingLoader.Load(EmbeddedResources.BeerPack);
      Console.WriteLine("Drawing panels");
      var canvas = foldingDrawer.Draw(folding);
      Console.WriteLine("Saving drawing");
      var savedDrawing = drawingSaver.Save(canvas);

      Console.WriteLine($"Saved drawing to {savedDrawing.FullName}");
      Console.WriteLine("Press enter to open the containing folder");
      Console.ReadLine();
      Process.Start("explorer.exe", ".");
    }

    /// <summary>
    ///   When this becomes sufficiently complex, it might be beneficial to introduce dependency injection here
    ///   While the object trees are still sparse, keep it simple.
    /// </summary>
    static IXmlFoldingLoader CreateFoldingLoader() {
      return new XmlFoldingLoader(
        new EmbeddedResourceReader(),
        new XmlModelReader(),
        new XmlModelMapper());
    }
    
    static IFoldingDrawer CreateFoldingDrawer() {
      return new FoldingDrawer(
        new RootPanelDrawer(
          new RootPanelPositioner(new RectangleFactory()),
          new PanelRectangleDrawer()));
    }

    static IDrawingSaver CreateDrawingSaver() {
      return new DrawingSaver();
    }
  }
}