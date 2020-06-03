// Decompiled with JetBrains decompiler
// Type: soteLib.soteSFIS2.soteSFIS2
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace soteLib.soteSFIS2
{
  public class soteSFIS2 : Component, IsoteSFIS2
  {
    protected Encoding m_Encoding;
    protected LogDetailLevels m_LogDetailLevel;
    protected string m_LogFilePathname;
    private StreamWriter m_LogFile;
    private Queue<string[]> m_LogMessageQueue;
    private BackgroundWorker m_LogMessageThread;

    public virtual event SfisConnectionChanged Connected;

    public virtual event SfisConnectionChanged Disconnected;

    public virtual event SfisConnectionError Error;

    public virtual event soteLib.soteSFIS2.SfisLog SfisLog;

    protected virtual void OnConnected(IsoteSFIS2 sender)
    {
      SfisConnectionChanged connected = this.Connected;
      if (connected == null)
        return;
      connected(sender);
    }

    protected virtual void OnDisconnected(IsoteSFIS2 sender)
    {
      SfisConnectionChanged disconnected = this.Disconnected;
      if (disconnected == null)
        return;
      disconnected(sender);
    }

    protected virtual void OnError(IsoteSFIS2 sender, Exception e)
    {
      SfisConnectionError error = this.Error;
      if (error == null)
        return;
      error(sender, e);
    }

    protected virtual void OnSfisLog(IsoteSFIS2 sender, string rawMessage, string displayMessage)
    {
      soteLib.soteSFIS2.SfisLog sfisLog = this.SfisLog;
      if (sfisLog == null)
        return;
      sfisLog(sender, rawMessage, displayMessage);
    }

    public virtual Encoding Encoding
    {
      get
      {
        return this.m_Encoding;
      }
      set
      {
        this.m_Encoding = value;
      }
    }

    public virtual string OperatorId { get; set; }

    public virtual LogDetailLevels LogDetailLevel
    {
      get
      {
        return this.m_LogDetailLevel;
      }
      set
      {
        this.m_LogDetailLevel = value;
      }
    }

    public virtual string LogFilePathname
    {
      get
      {
        lock (this.m_LogMessageQueue)
          return this.m_LogFilePathname;
      }
      set
      {
        lock (this.m_LogMessageQueue)
        {
          if (this.DesignMode)
            this.m_LogFilePathname = value;
          else if (string.IsNullOrEmpty(value))
          {
            if (this.m_LogFile == null)
              return;
            this.m_LogFile.Close();
            this.m_LogFile = (StreamWriter) null;
          }
          else if (string.Compare(((FileStream) this.m_LogFile.BaseStream).Name, Path.GetFullPath(value), true) != 0)
          {
            this.m_LogFile.Close();
            this.m_LogFilePathname = value;
            this.m_LogFile = new StreamWriter(value, true);
            this.m_LogFile.WriteLine("Log created for " + this.GetType().Name + " on " + (object) DateTime.Now.ToLocalTime());
          }
        }
      }
    }

    public virtual void Open()
    {
      lock (this.m_LogMessageQueue)
      {
        if (string.IsNullOrEmpty(this.m_LogFilePathname) || this.m_LogFile != null)
          return;
        this.m_LogFile = new StreamWriter(this.m_LogFilePathname, true);
        this.m_LogFile.WriteLine("Log created for " + this.GetType().Name + " on " + (object) DateTime.Now.ToLocalTime());
      }
    }

    public virtual void Close()
    {
      lock (this.m_LogMessageQueue)
      {
        if (this.m_LogFile == null)
          return;
        this.m_LogFile.Close();
        this.m_LogFile = (StreamWriter) null;
      }
    }

    public virtual bool PreTestCheck(
      ref string ppid,
      ref string sn,
      ref string mac1st,
      uint macCount,
      uint macIncrement,
      Dictionary<string, string> extraInfo)
    {
      throw new NotImplementedException("Please derived from class soteSFIS2.");
    }

    public virtual bool PostTestResult(
      string ppid,
      string sn,
      string mac1st,
      uint macCount,
      uint macIncrement,
      bool isPass,
      string errorCode)
    {
      throw new NotImplementedException("Please derived from class soteSFIS2.");
    }

    public soteSFIS2()
    {
      this.initialize();
    }

    public soteSFIS2(IContainer container)
    {
      container.Add((IComponent) this);
      this.initialize();
    }

    private void initialize()
    {
      this.m_Encoding = Encoding.ASCII;
      this.m_LogDetailLevel = LogDetailLevels.TestMessage;
      this.m_LogFilePathname = (string) null;
      this.Connected = (SfisConnectionChanged) null;
      this.Disconnected = (SfisConnectionChanged) null;
      this.Error = (SfisConnectionError) null;
      this.SfisLog = (soteLib.soteSFIS2.SfisLog) null;
      this.m_LogFile = (StreamWriter) null;
      this.m_LogMessageQueue = new Queue<string[]>();
      this.m_LogMessageThread = new BackgroundWorker();
      this.m_LogMessageThread.DoWork += new DoWorkEventHandler(this.LogMessageWorker);
      this.m_LogMessageThread.WorkerSupportsCancellation = true;
      if (this.DesignMode || IniFile.FileName == null || !File.Exists(IniFile.FileName))
        return;
      string profile1 = IniFile.GetProfile("SFIS2", "LOGDETAILLEVEL");
      string profile2 = IniFile.GetProfile("SFIS2", "LOGFILEPATHNAME");
      switch (profile1)
      {
        case "NONE":
          this.m_LogDetailLevel = LogDetailLevels.None;
          break;
        case "RAWMESSAGE":
          this.m_LogDetailLevel = LogDetailLevels.RawMessage;
          break;
      }
      if (!string.IsNullOrEmpty(profile2))
        this.m_LogFilePathname = profile2;
    }

    public static IsoteSFIS2 Create()
    {
      if (IniFile.FileName == null || !File.Exists(IniFile.FileName))
        throw new InvalidOperationException("Failed in loading INI file.");
      string profile = IniFile.GetProfile("SFIS2", "CM");
      if (string.IsNullOrEmpty(profile))
        throw new InvalidOperationException("Failed in get SFIS2:CM in INI file.");
      switch (profile)
      {
        case "FXCN":
        case "FXCN-CQ":
        case "FXCNCQ":
          return (IsoteSFIS2) new soteSFIS2Fxcn();
        case "FXCN-TJ":
        case "FXCNTJ":
          return (IsoteSFIS2) new soteSFIS2FxcnTj();
        case "USI":
          throw new NotImplementedException("CM USI is not supported.");
        default:
          throw new NotImplementedException("CM " + profile + " is not supported.");
      }
    }

    public static IsoteSFIS2 Create(CmNames name)
    {
      switch (name)
      {
        case CmNames.FXCN:
          return (IsoteSFIS2) new soteSFIS2Fxcn();
        case CmNames.USI:
          throw new NotImplementedException("CM USI is not supported.");
        default:
          throw new NotImplementedException("CM " + name.ToString() + " is not supported.");
      }
    }

    protected virtual void Log(string rawMessage, LogDetailLevels level)
    {
      if (level != this.m_LogDetailLevel)
        return;
      lock (this.m_LogMessageQueue)
      {
        if (this.m_LogFile != null || this.SfisLog != null)
        {
          this.m_LogMessageQueue.Enqueue(new string[2]
          {
            rawMessage,
            DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")
          });
          try
          {
            this.m_LogMessageThread.RunWorkerAsync();
          }
          catch (InvalidOperationException ex)
          {
          }
        }
      }
    }

    private void LogMessageWorker(object sender, EventArgs args)
    {
      while (!this.m_LogMessageThread.CancellationPending)
      {
        string[] strArray = (string[]) null;
        lock (this.m_LogMessageQueue)
        {
          if (this.m_LogMessageQueue.Count == 0)
            break;
          strArray = this.m_LogMessageQueue.Dequeue();
        }
        string input = strArray[0].Replace("\r", "\\r").Replace("\n", "\\n").Replace("\t", "\\t");
        string displayMessage = strArray[1] + " - " + Regex.Replace(input, "\\p{Cc}", (MatchEvaluator) (a => string.Format("\\x{0:X2}", (object) (byte) a.Value[0])));
        try
        {
          lock (this.m_LogMessageQueue)
          {
            if (this.m_LogFile != null)
              this.m_LogFile.WriteLine(displayMessage);
          }
          this.OnSfisLog((IsoteSFIS2) this, strArray[0], displayMessage);
        }
        catch (Exception ex)
        {
        }
      }
    }
  }
}
