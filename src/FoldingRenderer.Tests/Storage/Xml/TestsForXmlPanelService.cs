using System;
using FakeItEasy;
using FluentAssertions;
using FoldingRenderer.Storage;
using FoldingRenderer.Storage.Xml;
using FoldingRenderer.Storage.Xml.Exceptions;
using Xunit;

namespace FoldingRenderer.Tests.Storage.Xml {
  public class TestsForXmlPanelService {
    readonly IEmbeddedResourceReader _embeddedResourceReader;
    readonly IXmlModelReader _xmlModelReader;
    readonly IXmlModelMapper _xmlModelMapper;
    readonly XmlFoldingLoader _sut;

    public TestsForXmlPanelService() {
      _embeddedResourceReader = A.Fake<IEmbeddedResourceReader>();
      _xmlModelReader = A.Fake<IXmlModelReader>();
      _xmlModelMapper = A.Fake<IXmlModelMapper>();
      _sut = new XmlFoldingLoader(_embeddedResourceReader, _xmlModelReader, _xmlModelMapper);
    }

    public class Constructor : TestsForXmlPanelService {

      [Fact]
      public void ShouldNotAcceptNullArguments() {
        new Action(() => new XmlFoldingLoader(null, _xmlModelReader, _xmlModelMapper)).ShouldThrow<ArgumentNullException>();
        new Action(() => new XmlFoldingLoader(_embeddedResourceReader, null, _xmlModelMapper)).ShouldThrow<ArgumentNullException>();
        new Action(() => new XmlFoldingLoader(_embeddedResourceReader, _xmlModelReader, null)).ShouldThrow<ArgumentNullException>();
      }

    }

    public class Load : TestsForXmlPanelService {
      readonly EmbeddedResource _embeddedResource;

      public Load() {
        _embeddedResource = new EmbeddedResource(typeof(Load).Assembly, "some file");
      }

      [Fact]
      public void ShouldThrowWhenEmbeddedResourceIsNull() {
        new Action(() => _sut.Load(null)).ShouldThrow<ArgumentNullException>();
      }

      [Fact]
      public void ShouldThrowNoPanelsExceptionWhenItemsAreNull() {
        var xml = @"<?xml version=""1.0"" encoding=""utf-8""?> etc. etc.";
        A.CallTo(() => _embeddedResourceReader.Read(_embeddedResource)).Returns(xml);
        A.CallTo(() => _xmlModelReader.Read(xml)).Returns(new XmlModels.Folding { Items = null });

        new Action(() => _sut.Load(_embeddedResource)).ShouldThrow<NoPanelsException>();
      }

      [Fact]
      public void ShouldThrowNoPanelsExceptionWhenItemsAreEmpty() {
        var xml = @"<?xml version=""1.0"" encoding=""utf-8""?> etc. etc.";
        A.CallTo(() => _embeddedResourceReader.Read(_embeddedResource)).Returns(xml);
        A.CallTo(() => _xmlModelReader.Read(xml)).Returns(new XmlModels.Folding { Items = new XmlModels.Item[0] });

        new Action(() => _sut.Load(_embeddedResource)).ShouldThrow<NoPanelsException>();
      }

    }
  }
}