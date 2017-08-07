using System;
using System.Collections.Generic;

namespace FoldingRenderer.Storage.Xml {
  public class XmlModels {
    public class Folding {
      public Panels Panels { get; set; }
    }

    public class Panels {
      public ICollection<Item> Items { get; set; }
    }

    public class Item {
      public Guid PanelId { get; set; }
      public string PanelName { get; set; }
      public int MinRot { get; set; }
      public int MaxRot { get; set; }
      public int InitialRot { get; set; }
      public int StartRot { get; set; }
      public int HingeOffset { get; set; }
      public int PanelWidth { get; set; }
      public int PanelHeight { get; set; }
      public int AttachedToSide { get; set; }
      public int CreaseBottom { get; set; }
      public int CreaseTop { get; set; }
      public int CreaseLeft { get; set; }
      public int CreaseRight { get; set; }
      public bool IgnoreCollisions { get; set; }
      public bool MouseEnabled { get; set; }

      public Panels AttachedPanels { get; set; }
    }
  }
}
