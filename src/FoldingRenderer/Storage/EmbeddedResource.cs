using System;
using System.Reflection;

namespace FoldingRenderer.Storage {
  public class EmbeddedResource {
    public Assembly Assembly { get; }
    public string FullPath { get; }

    public EmbeddedResource(Assembly assembly, string fullPath) {
      if (assembly == null) throw new ArgumentNullException(nameof(assembly));
      if (fullPath == null) throw new ArgumentNullException(nameof(fullPath));
      Assembly = assembly;
      FullPath = fullPath;
    }
  }
}
