// Decompiled with JetBrains decompiler
// Type: soteLib.TestItem
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System.Xml.Serialization;

namespace soteLib
{
  public class TestItem
  {
    [XmlElement(IsNullable = true)]
    public string ING_Test_Type = "b57diag";
    [XmlElement(IsNullable = true)]
    public string ING_Test_Name;
    [XmlElement(IsNullable = true)]
    public string ING_Test_Number;
    [XmlElement(IsNullable = true)]
    public string ING_Test_Time;
    [XmlElement(IsNullable = true)]
    public string ING_Port_Number;
    [XmlElement(IsNullable = true)]
    public string ING_Pass_Fail;
  }
}
