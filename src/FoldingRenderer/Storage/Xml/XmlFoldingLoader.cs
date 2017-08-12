using System;
using FoldingRenderer.Storage.Xml.Exceptions;
using FoldingRenderer.Types;

namespace FoldingRenderer.Storage.Xml {
  public interface IXmlFoldingLoader {
    Folding Load(EmbeddedResource embeddedResource);
  }

  public class XmlFoldingLoader : IXmlFoldingLoader {
    readonly IEmbeddedResourceReader _embeddedResourceReader;
    readonly IXmlModelReader _xmlModelReader;
    readonly IXmlModelMapper _xmlModelMapper;

    public XmlFoldingLoader(IEmbeddedResourceReader embeddedResourceReader, IXmlModelReader xmlModelReader, IXmlModelMapper xmlModelMapper) {
      if (embeddedResourceReader == null) throw new ArgumentNullException(nameof(embeddedResourceReader));
      if (xmlModelReader == null) throw new ArgumentNullException(nameof(xmlModelReader));
      if (xmlModelMapper == null) throw new ArgumentNullException(nameof(xmlModelMapper));
      _embeddedResourceReader = embeddedResourceReader;
      _xmlModelReader = xmlModelReader;
      _xmlModelMapper = xmlModelMapper;
    }

    public Folding Load(EmbeddedResource embeddedResource) {
      if (embeddedResource == null) throw new ArgumentNullException(nameof(embeddedResource));
      var embeddedResourceContents = _embeddedResourceReader.Read(embeddedResource);
      var xmlModel = _xmlModelReader.Read(embeddedResourceContents);
      if(xmlModel.Items == null || xmlModel.Items.Length == 0)
        throw new NoPanelsException();
      if (xmlModel.Items.Length != 1) {
        throw new MultipleRootPanelsException(xmlModel.Items.Length);
      }
      return _xmlModelMapper.Map(xmlModel);
    }
  }
}