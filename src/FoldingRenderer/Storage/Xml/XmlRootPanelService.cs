using System;
using System.Linq;
using FoldingRenderer.Domain.Types;
using FoldingRenderer.Storage.Xml.Exceptions;

namespace FoldingRenderer.Storage.Xml {
  public interface IXmlPanelService {
    Panel Load(EmbeddedResource embeddedResource);
  }

  public class XmlRootPanelService : IXmlPanelService {
    readonly IEmbeddedResourceReader _embeddedResourceReader;
    readonly IXmlModelReader _xmlModelReader;
    readonly IXmlModelMapper _xmlModelMapper;

    public XmlRootPanelService(IEmbeddedResourceReader embeddedResourceReader, IXmlModelReader xmlModelReader, IXmlModelMapper xmlModelMapper) {
      if (embeddedResourceReader == null) throw new ArgumentNullException(nameof(embeddedResourceReader));
      if (xmlModelReader == null) throw new ArgumentNullException(nameof(xmlModelReader));
      if (xmlModelMapper == null) throw new ArgumentNullException(nameof(xmlModelMapper));
      _embeddedResourceReader = embeddedResourceReader;
      _xmlModelReader = xmlModelReader;
      _xmlModelMapper = xmlModelMapper;
    }

    public Panel Load(EmbeddedResource embeddedResource) {
      if (embeddedResource == null) throw new ArgumentNullException(nameof(embeddedResource));
      var embeddedResourceContents = _embeddedResourceReader.Read(embeddedResource);
      var xmlModel = _xmlModelReader.Read(embeddedResourceContents);
      if(xmlModel.Items == null || xmlModel.Items.Length == 0)
        throw new NoPanelsException();
      if (xmlModel.Items.Length != 1) {
        throw new MultipleRootPanelsException(xmlModel.Items.Length);
      }
      var rootPanel = xmlModel.Items.SingleOrDefault();
      return _xmlModelMapper.Map(rootPanel);
    }
  }
}

