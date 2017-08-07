using System;

namespace FoldingRenderer.Storage.Xml.Exceptions {
  public class MultipleRootPanelsException : Exception {
    public MultipleRootPanelsException(int numberOfRootPanels) : base($"Expected one root panel but found {numberOfRootPanels} root panels!") {} 
  }
}