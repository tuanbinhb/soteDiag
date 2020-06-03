// Decompiled with JetBrains decompiler
// Type: soteLib.TestLog
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System.Collections.Generic;
using System.Xml.Serialization;

namespace soteLib
{
  public class TestLog
  {
    [XmlIgnore]
    public TestLog.DiagType Diag_Type = TestLog.DiagType.Unknown;
    [XmlElement(IsNullable = true)]
    public string Template_Version = "v1.7";
    [XmlElement(IsNullable = true)]
    public string MAC_Increment = "1";
    [XmlIgnore]
    public int NumberOfPorts = 0;
    [XmlElement(IsNullable = true)]
    public string Date;
    [XmlElement(IsNullable = true)]
    public string Time;
    [XmlElement(IsNullable = true)]
    public string Tester_Name;
    [XmlElement(IsNullable = true)]
    public string User_ID;
    [XmlElement(IsNullable = true)]
    public string Work_Order_Number;
    [XmlElement(IsNullable = true)]
    public string Product_ID;
    [XmlElement(IsNullable = true)]
    public string Test_App_Version;
    [XmlElement(IsNullable = true)]
    public string Bootcode_Version;
    [XmlElement(IsNullable = true)]
    public string MBA_Version;
    [XmlElement(IsNullable = true)]
    public string EFI_Version;
    [XmlElement(IsNullable = true)]
    public string ISCSI_Version;
    [XmlElement(IsNullable = true)]
    public string FCoE_Version;
    [XmlElement(IsNullable = true)]
    public string L2_Version;
    [XmlElement(IsNullable = true)]
    public string APE_Version;
    [XmlElement(IsNullable = true)]
    public string CCM_Version;
    [XmlElement(IsNullable = true)]
    public string Test_Configuration;
    [XmlElement(IsNullable = true)]
    public string FRU_VPD_Test_App_Version;
    [XmlElement(IsNullable = true)]
    public string Serial_No;
    [XmlElement(IsNullable = true)]
    public string MAC_Count;
    [XmlElement(IsNullable = true)]
    public string MAC_ID_1st;
    [XmlElement(IsNullable = true)]
    public string CM_Part_No;
    [XmlElement(IsNullable = true)]
    public string SFIS_Real_Data;
    [XmlElement(IsNullable = true)]
    public string SFIS_Retest;
    [XmlElement(IsNullable = true)]
    public string SFIS_Rework;
    [XmlElement(IsNullable = true)]
    public string Pcie_Lanes;
    [XmlElement(IsNullable = true)]
    public string Pcie_Speed;
    public List<TestIteration> TestIterrations;
    public string RawLogFile;

    public enum DiagType
    {
      Unknown,
      B57diag,
      Cdiag,
    }
  }
}
