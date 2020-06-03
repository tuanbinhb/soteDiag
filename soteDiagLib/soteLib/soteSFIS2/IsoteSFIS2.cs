// Decompiled with JetBrains decompiler
// Type: soteLib.soteSFIS2.IsoteSFIS2
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System.Collections.Generic;
using System.Text;

namespace soteLib.soteSFIS2
{
  public interface IsoteSFIS2
  {
    event SfisConnectionChanged Connected;

    event SfisConnectionChanged Disconnected;

    event SfisConnectionError Error;

    event soteLib.soteSFIS2.SfisLog SfisLog;

    Encoding Encoding { get; set; }

    string OperatorId { get; set; }

    LogDetailLevels LogDetailLevel { get; set; }

    void Open();

    void Close();

    bool PreTestCheck(
      ref string ppid,
      ref string sn,
      ref string mac1st,
      uint macCount,
      uint macIncrement,
      Dictionary<string, string> extraInfo = null);

    bool PostTestResult(
      string ppid,
      string sn,
      string mac1st,
      uint macCount,
      uint macIncrement,
      bool isPass,
      string errorCode);
  }
}
