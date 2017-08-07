using System;
using FluentAssertions;
using FoldingRenderer.Storage;
using Xunit;

namespace FoldingRenderer.Tests.Storage {
  public class TestsForEmbeddedResourceReader {
    readonly EmbeddedResourceReader _sut;

    public TestsForEmbeddedResourceReader() {
      _sut = new EmbeddedResourceReader();
    }

    public class Read : TestsForEmbeddedResourceReader {

      [Fact]
      public void ShouldThrowWhenEmbeddedResourceIsNull() {
        new Action(() => _sut.Read(null)).ShouldThrow<ArgumentNullException>();
      }

      [Fact]
      public void ShouldCorrectlyReadAllContents() {
        var embeddedResource = new EmbeddedResource(typeof(TestsForEmbeddedResourceReader).Assembly,
          typeof(TestsForEmbeddedResourceReader).Namespace + ".HelloWorld.txt");
        var contents = _sut.Read(embeddedResource);
        contents.Should().NotBeNullOrEmpty().And.Be("Hello world!");
      }

      [Fact]
      public void ShouldFailToReadIncorrectPath() {
        var embeddedResource = new EmbeddedResource(typeof(TestsForEmbeddedResourceReader).Assembly,
          typeof(TestsForEmbeddedResourceReader).Namespace + ".HelloWorld2.txt");
        Action invalidPathRead = () => _sut.Read(embeddedResource);
        invalidPathRead.ShouldThrow<ArgumentException>();
      }
    }
  }
}