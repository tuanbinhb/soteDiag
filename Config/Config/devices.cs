// Decompiled with JetBrains decompiler
// Type: devices
// Assembly: Config, Version=3.2.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 981CD5E2-C1D2-448D-8326-C60FCE8CDD63
// Assembly location: E:\Test_Program\F57416M4160C\FT1\Config.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[GeneratedCode("xsd", "2.0.50727.42")]
[DesignerCategory("code")]
[XmlRoot(IsNullable = false, Namespace = "")]
[DebuggerStepThrough]
[XmlType(AnonymousType = true)]
[Serializable]
public class devices
{
  private devicesDevice[] deviceField;

  [XmlElement("device")]
  public devicesDevice[] device
  {
    get
    {
      return this.deviceField;
    }
    set
    {
      this.deviceField = value;
    }
  }
}
