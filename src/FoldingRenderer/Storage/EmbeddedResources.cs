namespace FoldingRenderer.Storage {
  public static class EmbeddedResources {
    public static readonly EmbeddedResource BeerPack = new EmbeddedResource(typeof(EmbeddedResource).Assembly, typeof(EmbeddedResources).Namespace + ".Xml.BeerPack.xml");
  }
}