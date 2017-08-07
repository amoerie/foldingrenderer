using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace FoldingRenderer.Storage.Xml {
  public interface IXmlModelReader {
    XmlModels.Folding Read(string xml);
  }

  public class XmlModelReader : IXmlModelReader {
    public XmlModels.Folding Read(string xml) {
      var xmlSerializer = new XmlSerializer(typeof(XmlModels.Folding));
      using (var stringReader = new StringReader(xml))
      using (var xmlReader = XmlReader.Create(stringReader)) {
        return (XmlModels.Folding)xmlSerializer.Deserialize(xmlReader);
      }
    }
  }
}