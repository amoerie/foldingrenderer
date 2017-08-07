using System;

namespace FoldingRenderer.Storage.Xml.Exceptions {
  public class NoPanelsException : Exception {
    public NoPanelsException() : base("Failed to load any panels!") { }
  }
}