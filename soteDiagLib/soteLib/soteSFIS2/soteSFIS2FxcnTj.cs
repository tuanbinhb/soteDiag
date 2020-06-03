// Decompiled with JetBrains decompiler
// Type: soteLib.soteSFIS2.soteSFIS2FxcnTj
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace soteLib.soteSFIS2
{
  public class soteSFIS2FxcnTj : soteLib.soteSFIS2.soteSFIS2
  {
    private const string Db1Header = "# SERIAL NUM,DATE COMPLETED,TIME COMPLETED,SYSTEM ID,FIXTURE ID,FIRMWARE REV,OPERATOR,PROGRAM,DIAGS REV,BIOS REV,UUT REV,TESTING TIME,STATUS,NUM STEPS FAILED,NUM FAILED FACTS,NUM POSTINGS,FAILED STEP PATH,FACT,MEASURED,EXPECTED,ETHERNET ADDR,PARTNUM,PLATFORM";
    private const int Db1Timeout = 30;
    private string m_DbPathname;
    private string m_OperatorId;
    private string m_AppConfig;
    private string m_AppFwCheck;
    private string m_ProgramName;
    private string m_FixtureId;
    private string m_BootCode;
    private string m_PXE;
    private string m_EFI;
    private string m_APE;
    private string m_CCM;
    private string m_FwRev;
    private string m_AppVer;
    private string m_DiagRev;
    private bool m_BeginTimestampValid;
    private DateTime m_BeginTimestamp;
    private string m_PartNum;
    private string m_ProgramId;
    private soteSFIS2FxcnTj.OpenStates m_OpenState;

    public soteSFIS2FxcnTj()
    {
      this.Initialize();
    }

    public soteSFIS2FxcnTj(IContainer container)
      : base(container)
    {
      this.Initialize();
    }

    private void Initialize()
    {
      this.m_DbPathname = (string) null;
      this.m_OperatorId = (string) null;
      this.m_BeginTimestampValid = false;
      if (this.DesignMode || IniFile.FileName == null || !File.Exists(IniFile.FileName))
        return;
      this.m_AppConfig = IniFile.FileName;
      this.m_AppFwCheck = this.m_AppConfig.Substring(0, this.m_AppConfig.Length - 4) + "FwCheck.ini";
      this.DbPathname = IniFile.GetProfile("SFIS2", "DB1PATHNAME");
      this.m_OperatorId = IniFile.GetProfile("SFIS2", "OPERATORID");
      this.m_ProgramName = IniFile.GetProfile("TEST SETUP", "DUT_TYPE");
      this.m_FixtureId = IniFile.GetProfile("SHOPFLOOR", "FIXTURE_ID");
      if (string.IsNullOrEmpty(this.m_FixtureId))
        this.m_FixtureId = "NA";
      this.m_AppVer = Assembly.GetEntryAssembly().GetName().Version.ToString();
      this.m_PartNum = IniFile.GetProfile(this.m_ProgramName, "PART_NUMBER");
      if (string.IsNullOrEmpty(this.m_PartNum))
        this.m_PartNum = "NA";
      if (!new Dictionary<string, string>()
      {
        {
          "GAMMA",
          "M2004G"
        },
        {
          "OBRIEN",
          "AD2000DC"
        },
        {
          "PUTNAM",
          "A1904GH"
        },
        {
          "WOODVILLE",
          "A2003GH"
        },
        {
          "BOERNE",
          "A1913G"
        },
        {
          "CORAK",
          "A1905G"
        },
        {
          "CARDASSIA",
          "A1904GD"
        },
        {
          "BASHIR",
          "A2003GD"
        },
        {
          "MERCURY",
          "A1904AC"
        },
        {
          "PLUTO",
          "A2003AC"
        }
      }.TryGetValue(this.m_ProgramName, out this.m_ProgramId))
        this.m_ProgramId = "NA";
      IniFile.FileName = this.m_AppFwCheck;
      this.m_BootCode = IniFile.GetProfile(this.m_ProgramName, "BootCode");
      this.m_PXE = IniFile.GetProfile(this.m_ProgramName, "PXE");
      this.m_EFI = IniFile.GetProfile(this.m_ProgramName, "EFI");
      this.m_APE = IniFile.GetProfile(this.m_ProgramName, "APE_Firmware");
      this.m_CCM = IniFile.GetProfile(this.m_ProgramName, "CCM");
      this.m_FwRev = "";
      if (!string.IsNullOrEmpty(this.m_BootCode))
      {
        soteSFIS2FxcnTj soteSfiS2FxcnTj = this;
        soteSfiS2FxcnTj.m_FwRev = soteSfiS2FxcnTj.m_FwRev + ";BootCode=" + this.m_BootCode;
      }
      if (!string.IsNullOrEmpty(this.m_PXE))
      {
        soteSFIS2FxcnTj soteSfiS2FxcnTj = this;
        soteSfiS2FxcnTj.m_FwRev = soteSfiS2FxcnTj.m_FwRev + ";PXE=" + this.m_PXE;
      }
      if (!string.IsNullOrEmpty(this.m_EFI))
      {
        soteSFIS2FxcnTj soteSfiS2FxcnTj = this;
        soteSfiS2FxcnTj.m_FwRev = soteSfiS2FxcnTj.m_FwRev + ";EFI=" + this.m_EFI;
      }
      if (!string.IsNullOrEmpty(this.m_APE))
      {
        soteSFIS2FxcnTj soteSfiS2FxcnTj = this;
        soteSfiS2FxcnTj.m_FwRev = soteSfiS2FxcnTj.m_FwRev + ";APE_Firmware=" + this.m_APE;
      }
      if (!string.IsNullOrEmpty(this.m_CCM))
      {
        soteSFIS2FxcnTj soteSfiS2FxcnTj = this;
        soteSfiS2FxcnTj.m_FwRev = soteSfiS2FxcnTj.m_FwRev + ";CCM=" + this.m_CCM;
      }
      this.m_FwRev = this.m_FwRev.Length <= 0 ? "NA" : this.m_FwRev.Substring(1);
      this.m_DiagRev = IniFile.GetProfile(this.m_ProgramName, "Engineering_Diagnostics");
      if (string.IsNullOrEmpty(this.m_DiagRev))
        this.m_DiagRev = "NA";
      IniFile.FileName = this.m_AppConfig;
    }

    public string DbPathname
    {
      get
      {
        return this.m_DbPathname;
      }
      set
      {
        lock (this)
        {
          if (this.m_OpenState != soteSFIS2FxcnTj.OpenStates.Stopped)
            throw new Exception("Invalid attempt to change database (db1) file while it's open.\nPlease close first before changing.");
          string str = value;
          if (str.Contains<char>('%'))
          {
            Match match = Regex.Match(str, "\\%([^%]*)\\%");
            if (match.Success)
            {
              string replacement = DateTime.Now.ToString(match.Groups[1].Value);
              str = Regex.Replace(str, "\\%([^%]*)\\%", replacement);
            }
          }
          string fullPath = Path.GetFullPath(str);
          string directoryName = Path.GetDirectoryName(fullPath);
          if (!Directory.Exists(directoryName))
            throw new ArgumentException("Not valid path: " + directoryName);
          this.m_DbPathname = fullPath;
        }
      }
    }

    public override string OperatorId
    {
      get
      {
        return this.m_OperatorId;
      }
      set
      {
        lock (this)
          this.m_OperatorId = value.Trim();
      }
    }

    public override void Open()
    {
      lock (this)
      {
        if (this.m_DbPathname == null)
          throw new ArgumentNullException("Property \"DbPathname\" must be set properly.");
        if (this.m_OperatorId == null)
          throw new ArgumentNullException("Property \"OperatorId\" must be set properly.");
        if (!File.Exists(this.m_DbPathname))
          this.AppendLine("# SERIAL NUM,DATE COMPLETED,TIME COMPLETED,SYSTEM ID,FIXTURE ID,FIRMWARE REV,OPERATOR,PROGRAM,DIAGS REV,BIOS REV,UUT REV,TESTING TIME,STATUS,NUM STEPS FAILED,NUM FAILED FACTS,NUM POSTINGS,FAILED STEP PATH,FACT,MEASURED,EXPECTED,ETHERNET ADDR,PARTNUM,PLATFORM");
        this.m_OpenState = soteSFIS2FxcnTj.OpenStates.Open;
      }
      base.Open();
      this.OnConnected((IsoteSFIS2) this);
    }

    public override void Close()
    {
      this.m_OpenState = soteSFIS2FxcnTj.OpenStates.Stopped;
      base.Close();
      this.OnDisconnected((IsoteSFIS2) this);
    }

    public override bool PreTestCheck(
      ref string ppid,
      ref string sn,
      ref string mac1st,
      uint macCount,
      uint macIncrement,
      Dictionary<string, string> extraInfo)
    {
      this.m_BeginTimestamp = DateTime.Now;
      this.m_BeginTimestampValid = true;
      if (extraInfo != null)
      {
        foreach (string index in new List<string>((IEnumerable<string>) extraInfo.Keys))
          extraInfo[index] = (string) null;
      }
      this.Log("Pre-test-check Debug (" + this.m_BeginTimestamp.ToString() + "): PPID/CT = " + ppid, LogDetailLevels.TestMessage);
      return true;
    }

    public override bool PostTestResult(
      string ppid,
      string sn,
      string mac1st,
      uint macCount,
      uint macIncrement,
      bool isPass,
      string errorCode)
    {
      DateTime now = DateTime.Now;
      if (string.IsNullOrEmpty(ppid) || ppid.Length < 3 || string.IsNullOrEmpty(mac1st) || !isPass && string.IsNullOrEmpty(errorCode))
        throw new ArgumentNullException("Invalid one of arguments (ppid, mac1st, or errorCode).");
      string str1 = ppid + "," + now.ToString("yyyy-MM-dd") + "," + now.ToString("HH:mm:ss") + "," + Environment.MachineName + ",NA" + "," + this.m_FwRev + "," + this.OperatorId + "," + this.m_AppVer + "," + this.m_DiagRev + ",NA" + "," + ppid.Substring(ppid.Length - 3);
      string str2 = !this.m_BeginTimestampValid ? str1 + ",NA" : str1 + "," + now.Subtract(this.m_BeginTimestamp).TotalSeconds.ToString("F0");
      string str3 = (!isPass ? str2 + ",FAIL" : str2 + ",PASS") + ",NA" + ",NA" + ",NA" + ",NA";
      string str4 = !isPass ? str3 + "," + errorCode : str3 + ",ALL TEST";
      string line = (!isPass ? str4 + ",FAIL" : str4 + ",PASS") + ",NA" + "," + mac1st.Replace(":", "").Replace("-", "") + "," + this.m_PartNum + "," + this.m_ProgramId;
      this.Log("Post-test-result Debug (" + now.ToString() + "): " + line, LogDetailLevels.TestMessage);
      this.AppendLine(line);
      this.m_BeginTimestampValid = false;
      return true;
    }

    private void AppendLine(string line)
    {
      File.AppendAllText(this.m_DbPathname, line + Environment.NewLine);
    }

    private enum OpenStates
    {
      Stopped,
      Open,
    }
  }
}
