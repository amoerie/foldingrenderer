using System;
using System.IO;
using System.Reflection;

namespace FoldingRenderer.Storage.Xml {
  public interface IEmbeddedResourceReader {
    string Read(Assembly assembly, string path);
  }

  public class EmbeddedResourceReader : IEmbeddedResourceReader {
    public string Read(Assembly assembly, string path) {
      using (var stream = assembly.GetManifestResourceStream(path)) {
        if (stream == null) {
          throw new ArgumentException("Embedded resource '" + path + "' could not be found.");
        }
        using (var reader = new StreamReader(stream)) {
          return reader.ReadToEnd();
        }
      }
    }
  }
}