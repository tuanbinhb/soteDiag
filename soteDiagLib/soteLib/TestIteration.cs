// Decompiled with JetBrains decompiler
// Type: soteLib.TestIteration
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System.Xml.Serialization;

namespace soteLib
{
  public class TestIteration
  {
    [XmlIgnore]
    public int Test_Iteration;
    [XmlElement(IsNullable = true)]
    public string Functional_Test_Pass_Fail;
    [XmlElement(IsNullable = true)]
    public string NvramVerify_Test_Pass_Fail;
    [XmlElement(IsNullable = true)]
    public string FRUVPD_Test_Pass_Fail;
    [XmlElement(IsNullable = true)]
    public string FRUVerify_Test_Pass_Fail;
    [XmlElement(IsNullable = true)]
    public string Overall_Test_Pass_Fail;
    [XmlElement(IsNullable = true)]
    public string Error_Code;
    [XmlElement(IsNullable = true)]
    public string Error_Description;
    public TestNicPort[] Ports;
  }
}
