using System;
using FluentAssertions;
using FoldingRenderer.Storage;
using Xunit;

namespace FoldingRenderer.Tests.Storage
{
  public class TestsForEmbeddedResourceReader
  {
    private readonly EmbeddedResourceReader _sut;

    public TestsForEmbeddedResourceReader()
    {
      _sut = new EmbeddedResourceReader();
    }

    public class Read : TestsForEmbeddedResourceReader
    {
      [Fact]
      public void ShouldCorrectlyReadAllContents()
      {
        var contents = _sut.Read(typeof(TestsForEmbeddedResourceReader).Assembly,
          typeof(TestsForEmbeddedResourceReader).Namespace + ".HelloWorld.txt");
        contents.Should().NotBeNullOrEmpty().And.Be("Hello world!");
      }

      [Fact]
      public void ShouldFailToReadIncorrectPath()
      {
        Action invalidPathRead = () => _sut.Read(typeof(TestsForEmbeddedResourceReader).Assembly,
          typeof(TestsForEmbeddedResourceReader).Namespace + ".HelloWorld2.txt");
        invalidPathRead.ShouldThrow<ArgumentException>();
      }
    }
  }
}