using FoldingRenderer.Domain.Types;

namespace FoldingRenderer.Storage.Xml {
  public interface IPanelXmlReader {
    Panel Read(string xml);
  }

  public class PanelXmlReader : IPanelXmlReader {
    public Panel Read(string xml) {
      throw new System.NotImplementedException();
    }
  }
}
