// Decompiled with JetBrains decompiler
// Type: devicesDevice
// Assembly: Config, Version=3.2.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 981CD5E2-C1D2-448D-8326-C60FCE8CDD63
// Assembly location: E:\Test_Program\F57416M4160C\FT1\Config.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

[DesignerCategory("code")]
[DebuggerStepThrough]
[GeneratedCode("xsd", "2.0.50727.42")]
[XmlType(AnonymousType = true)]
[Serializable]
public class devicesDevice
{
  private string methodField;
  private string memoryaddressField;
  private uint pagesizeField;
  private string memorysizeField;
  private string nameField;

  public string method
  {
    get
    {
      return this.methodField;
    }
    set
    {
      this.methodField = value;
    }
  }

  [XmlElement("memory-address")]
  public string memoryaddress
  {
    get
    {
      return this.memoryaddressField;
    }
    set
    {
      this.memoryaddressField = value;
    }
  }

  [XmlElement("page-size")]
  public uint pagesize
  {
    get
    {
      return this.pagesizeField;
    }
    set
    {
      this.pagesizeField = value;
    }
  }

  [XmlElement("memory-size")]
  public string memorysize
  {
    get
    {
      return this.memorysizeField;
    }
    set
    {
      this.memorysizeField = value;
    }
  }

  [XmlAttribute]
  public string name
  {
    get
    {
      return this.nameField;
    }
    set
    {
      this.nameField = value;
    }
  }
}
