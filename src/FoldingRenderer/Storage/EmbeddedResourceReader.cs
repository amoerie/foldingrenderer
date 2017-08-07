using System;
using System.IO;
using System.Text;

namespace FoldingRenderer.Storage {
  public interface IEmbeddedResourceReader {
    string Read(EmbeddedResource embeddedResource);
  }

  public class EmbeddedResourceReader : IEmbeddedResourceReader {
    public string Read(EmbeddedResource embeddedResource) {
      if (embeddedResource == null) throw new ArgumentNullException(nameof(embeddedResource));
      using (var stream = embeddedResource.Assembly.GetManifestResourceStream(embeddedResource.FullPath)) {
        if (stream == null) {
          throw new ArgumentException("Embedded resource '" + embeddedResource.FullPath + "' could not be found.");
        }
        using (var reader = new StreamReader(stream, Encoding.UTF8)) {
          return reader.ReadToEnd();
        }
      }
    }
  }
}