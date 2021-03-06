﻿using System;
using System.Xml.Serialization;

namespace FoldingRenderer.Storage.Xml {
  public class XmlModels {
    [XmlRoot("folding", Namespace = "", IsNullable = false)]
    public class Folding {
      [XmlAttribute("rootX")]
      public double RootX { get; set; }

      [XmlAttribute("rootY")]
      public double RootY { get; set; }

      [XmlAttribute("originalDocumentHeight")]
      public int OriginalDocumentHeight { get; set; }

      [XmlAttribute("originalDocumentWidth")]
      public int OriginalDocumentWidth { get; set; }

      [XmlArray("panels")]
      [XmlArrayItem("item", typeof(Item))]
      public Item[] Items { get; set; }
    }

    [XmlType("item")]
    public class Item {
      [XmlAttribute("panelId")]
      public Guid PanelId { get; set; }

      [XmlAttribute("panelName")]
      public string PanelName { get; set; }

      [XmlAttribute("minRot")]
      public int MinRot { get; set; }

      [XmlAttribute("maxRot")]
      public int MaxRot { get; set; }

      [XmlAttribute("initialRot")]
      public int InitialRot { get; set; }

      [XmlAttribute("startRot")]
      public int StartRot { get; set; }

      [XmlAttribute("endRot")]
      public int EndRot { get; set; }

      [XmlAttribute("hingeOffset")]
      public double HingeOffset { get; set; }

      [XmlAttribute("panelWidth")]
      public double PanelWidth { get; set; }

      [XmlAttribute("panelHeight")]
      public double PanelHeight { get; set; }

      [XmlAttribute("attachedToSide")]
      public int AttachedToSide { get; set; }

      [XmlAttribute("creaseBottom")]
      public double CreaseBottom { get; set; }

      [XmlAttribute("creaseTop")]
      public double CreaseTop { get; set; }

      [XmlAttribute("creaseLeft")]
      public double CreaseLeft { get; set; }

      [XmlAttribute("creaseRight")]
      public double CreaseRight { get; set; }

      [XmlAttribute("ignoreCollisions")]
      public bool IgnoreCollisions { get; set; }

      [XmlAttribute("mouseEnabled")]
      public bool MouseEnabled { get; set; }

      [XmlArray("attachedPanels")]
      [XmlArrayItem("item", typeof(Item))]
      public Item[] AttachedPanels { get; set; }
    }
  }
}
