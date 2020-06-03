// Decompiled with JetBrains decompiler
// Type: soteLib.soteSFIS2.soteSFIS2Fxcn
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace soteLib.soteSFIS2
{
  public class soteSFIS2Fxcn : soteLib.soteSFIS2.soteSFIS2
  {
    private const int PingInterval = 3000;
    private int m_Port;
    private EndPoint m_RemoteEndPoint;
    private string m_OperatorId;
    private TcpListener m_Listener;
    private TcpClient m_Client;
    private NetworkStream m_ClientStream;
    private soteSFIS2Fxcn.OpenStates m_OpenState;
    private byte[] m_DataBuffer;
    private string[] m_PretestCheckRequest;
    private AutoResetEvent m_PretestCheckEvent;
    private string[] m_PretestResult;
    private System.Threading.Timer m_Timer;

    public soteSFIS2Fxcn()
    {
      this.Initialize();
    }

    public soteSFIS2Fxcn(IContainer container)
      : base(container)
    {
      this.Initialize();
    }

    private void Initialize()
    {
      this.m_Port = 3000;
      this.m_RemoteEndPoint = (EndPoint) null;
      this.m_OperatorId = (string) null;
      this.m_Listener = (TcpListener) null;
      this.m_Client = (TcpClient) null;
      this.m_ClientStream = (NetworkStream) null;
      this.m_DataBuffer = new byte[1024];
      this.m_PretestCheckRequest = (string[]) null;
      this.m_PretestCheckEvent = new AutoResetEvent(false);
      this.m_PretestResult = (string[]) null;
      this.m_Timer = new System.Threading.Timer(new TimerCallback(this.OnTimer), (object) null, -1, 3000);
      if (this.DesignMode || IniFile.FileName == null || !System.IO.File.Exists(IniFile.FileName))
        return;
      string profile1 = IniFile.GetProfile("SFIS2", "LOCALPORT");
      string profile2 = IniFile.GetProfile("SFIS2", "OPERATORID");
      this.m_Port = Convert.ToInt32(profile1);
      this.m_OperatorId = profile2;
    }

    public int Port
    {
      get
      {
        return this.m_Port;
      }
      set
      {
        lock (this)
        {
          if (this.m_Port < 0 || this.m_Port > (int) ushort.MaxValue)
            throw new ArgumentOutOfRangeException("Port number must be within range (" + (object) 0 + ", " + (object) (int) ushort.MaxValue + ").");
          if (this.m_Port == value)
            return;
          if (this.m_OpenState != soteSFIS2Fxcn.OpenStates.Stopped)
            throw new Exception("Invalid attempt to change port while it's open.\nPlease close port before changing.");
          this.m_Port = value;
          if (this.m_Listener == null)
            this.m_Listener = new TcpListener(IPAddress.Any, this.m_Port);
          else
            this.m_Listener.Server.Bind((EndPoint) new IPEndPoint(IPAddress.Any, this.m_Port));
        }
      }
    }

    public EndPoint RemoteEndPoint
    {
      get
      {
        return this.m_RemoteEndPoint;
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
        {
          if (string.IsNullOrEmpty(value) || value.Trim().Length == 0)
            throw new ArgumentNullException("Property \"OperatorId\" must be set properly.");
          this.m_OperatorId = value.Trim();
          this.SendMessageUnlocked("UNDO", false);
          this.SendMessageUnlocked(this.m_OperatorId, false);
        }
      }
    }

    public override void Open()
    {
      lock (this)
      {
        if (this.m_OperatorId == null)
          throw new ArgumentNullException("Property \"OperatorId\" must be set properly.");
        if (this.m_OpenState != soteSFIS2Fxcn.OpenStates.Stopped)
          return;
        if (this.m_Listener == null)
          this.m_Listener = new TcpListener(IPAddress.Any, this.m_Port);
        this.m_Listener.Start();
        this.m_Listener.BeginAcceptTcpClient(new AsyncCallback(soteSFIS2Fxcn.OnAcceptTcpClient), (object) this);
        this.m_OpenState = soteSFIS2Fxcn.OpenStates.Listening;
      }
      base.Open();
    }

    public override void Close()
    {
      if (this.m_OpenState == soteSFIS2Fxcn.OpenStates.Stopped)
        return;
      lock (this)
      {
        switch (this.m_OpenState)
        {
          case soteSFIS2Fxcn.OpenStates.Listening:
            this.m_Listener.Stop();
            break;
          case soteSFIS2Fxcn.OpenStates.Connected:
            this.m_ClientStream.Close();
            this.m_ClientStream = (NetworkStream) null;
            this.m_Client.Close();
            this.m_Client = (TcpClient) null;
            this.m_RemoteEndPoint = (EndPoint) null;
            this.m_Timer.Change(-1, 3000);
            break;
        }
        this.m_OpenState = soteSFIS2Fxcn.OpenStates.Stopped;
      }
      base.Close();
    }

    public override bool PreTestCheck(
      ref string ppid,
      ref string sn,
      ref string mac1st,
      uint macCount,
      uint macIncrement,
      Dictionary<string, string> extraInfo)
    {
      if (mac1st == null || macCount == 0U || macIncrement == 0U)
        throw new ArgumentNullException("Invalid argument (mac1st, macCount, or macIncrement).");
      string message = string.Format("{0,-12:G}", (object) mac1st.Replace(":", "").Replace("-", ""));
      string[] strArray1 = new string[6];
      strArray1[0] = mac1st;
      string[] strArray2 = strArray1;
      lock (this)
      {
        if (this.m_PretestCheckRequest != null)
          throw new InvalidOperationException("There is pending PreTestCheck.");
        this.m_PretestResult = (string[]) null;
        this.m_PretestCheckRequest = strArray2;
        this.SendMessageUnlocked(message, false);
      }
      bool flag = this.m_PretestCheckEvent.WaitOne(2000);
      lock (this)
        this.m_PretestCheckRequest = (string[]) null;
      if (!flag)
        return false;
      this.Log("Pre-test-check Debug: " + strArray2[0] + ", " + strArray2[1] + ", " + strArray2[2] + strArray2[3] + ", PPID/CT = " + ppid + ", " + strArray2[4] + ", " + strArray2[5], LogDetailLevels.TestMessage);
      if (ppid == null)
        ppid = strArray2[1];
      else if (ppid != strArray2[1])
        return false;
      if (sn == null)
        sn = strArray2[2];
      else if (sn != strArray2[2])
        return false;
      if (extraInfo != null)
      {
        if (extraInfo.ContainsKey("Retest"))
          extraInfo["Retest"] = strArray2[4];
        if (extraInfo.ContainsKey("MO_Number"))
          extraInfo["MO_Number"] = strArray2[5];
      }
      if (string.Compare(strArray2[3], "PASS", true) != 0)
        return false;
      lock (this)
        this.m_PretestResult = new string[3]
        {
          mac1st,
          ppid,
          sn
        };
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
      if (ppid == null || mac1st == null || (macCount == 0U || macIncrement == 0U) || !isPass && string.IsNullOrEmpty(errorCode))
        throw new ArgumentNullException("Invalid one of arguments (ppid, mac1st, macCount, macIncrement, or errorCode).");
      if (!isPass && errorCode.Equals("LOCK01"))
      {
        if (this.m_PretestResult == null)
          throw new InvalidOperationException("PostTestResult is called without successful PreTestCheck.");
        if (string.IsNullOrEmpty(sn) && !string.IsNullOrEmpty(this.m_PretestResult[2]))
          throw new ArgumentNullException("SN is missing in PostTestResult arguments, but is present in PreTestCheck arguments.");
        if (!string.IsNullOrEmpty(sn) && string.IsNullOrEmpty(this.m_PretestResult[2]))
          throw new ArgumentNullException("SN is missing in PreTestCheck arguments, but is present in PostTestResult arguments.");
      }
      string str1 = Environment.MachineName.Length <= 12 ? Environment.MachineName : Environment.MachineName.Substring(0, 12);
      string str2 = !string.IsNullOrEmpty(sn) ? string.Format("{0,-25:G}{1,-30:G}{2,-15:G}", (object) mac1st.Replace(":", "").Replace("-", ""), (object) ppid, (object) sn) : string.Format("{0,-25:G}{1,-30:G}", (object) mac1st.Replace(":", "").Replace("-", ""), (object) ppid);
      string str3 = string.Format("{0,-12:G}", (object) str1);
      string message;
      if (!isPass)
      {
        if (errorCode.Equals("LOCK01"))
          message = (!string.IsNullOrEmpty(this.m_PretestResult[2]) ? string.Format("{0,-25:G}{1,-30:G}{2,-15:G}", (object) this.m_PretestResult[0], (object) this.m_PretestResult[1], (object) this.m_PretestResult[2]) : string.Format("{0,-25:G}{1,-30:G}", (object) this.m_PretestResult[0], (object) this.m_PretestResult[1])) + str3 + str2 + errorCode;
        else
          message = str2 + str3 + errorCode;
      }
      else
        message = str2 + str3;
      lock (this)
      {
        if (this.m_ClientStream == null)
          throw new InvalidOperationException("Not connected.");
        this.SendMessageUnlocked(message, true);
      }
      return true;
    }

    private void SendMessageUnlocked(string message, bool needEscape)
    {
      if (this.m_ClientStream == null || string.IsNullOrEmpty(message))
        return;
      string str = needEscape ? "\x001B\a" + message + "\r\r\n" : message + "\r\r\n";
      byte[] bytes = this.m_Encoding.GetBytes(str);
      if (needEscape || message[0] != '\x001B')
        this.Log(message, LogDetailLevels.TestMessage);
      this.Log(str, LogDetailLevels.RawMessage);
      this.m_ClientStream.Write(bytes, 0, bytes.Length);
    }

    private static void OnAcceptTcpClient(IAsyncResult ar)
    {
      soteSFIS2Fxcn asyncState = (soteSFIS2Fxcn) ar.AsyncState;
      bool flag1 = false;
      bool flag2 = false;
      Exception e = (Exception) null;
      lock (asyncState)
      {
        try
        {
          asyncState.m_Client = asyncState.m_Listener.EndAcceptTcpClient(ar);
          asyncState.m_RemoteEndPoint = asyncState.m_Client.Client.RemoteEndPoint;
          asyncState.m_ClientStream = asyncState.m_Client.GetStream();
          asyncState.SendMessageUnlocked(asyncState.m_OperatorId, false);
          asyncState.m_ClientStream.BeginRead(asyncState.m_DataBuffer, 0, asyncState.m_DataBuffer.Length, new AsyncCallback(soteSFIS2Fxcn.OnStreamRead), (object) asyncState);
          asyncState.m_Timer.Change(0, 3000);
          asyncState.m_Listener.Stop();
          asyncState.m_OpenState = soteSFIS2Fxcn.OpenStates.Connected;
          flag1 = true;
        }
        catch (Exception ex)
        {
          flag2 = true;
          e = ex;
          if (asyncState.m_ClientStream != null)
          {
            asyncState.m_ClientStream.Close();
            asyncState.m_ClientStream = (NetworkStream) null;
          }
          if (asyncState.m_Client != null)
          {
            asyncState.m_Client.Close();
            asyncState.m_Client = (TcpClient) null;
          }
          asyncState.m_RemoteEndPoint = (EndPoint) null;
          asyncState.m_Timer.Change(-1, 3000);
        }
      }
      if (flag2)
      {
        asyncState.OnError((IsoteSFIS2) asyncState, e);
      }
      else
      {
        if (!flag1)
          return;
        asyncState.OnConnected((IsoteSFIS2) asyncState);
      }
    }

    private void HandleSocketFailure(Exception ex1, ref List<Exception> exceptionList)
    {
      if (exceptionList == null)
        exceptionList = new List<Exception>();
      if (ex1 != null)
        exceptionList.Add(ex1);
      if (this.m_ClientStream != null)
      {
        this.m_ClientStream.Close();
        this.m_ClientStream = (NetworkStream) null;
      }
      if (this.m_Client != null)
      {
        this.m_Client.Close();
        this.m_Client = (TcpClient) null;
      }
      this.m_RemoteEndPoint = (EndPoint) null;
      this.m_Timer.Change(-1, 3000);
      this.m_OpenState = soteSFIS2Fxcn.OpenStates.Stopped;
      try
      {
        this.m_Listener.Start();
        this.m_Listener.BeginAcceptTcpClient(new AsyncCallback(soteSFIS2Fxcn.OnAcceptTcpClient), (object) this);
        this.m_OpenState = soteSFIS2Fxcn.OpenStates.Listening;
      }
      catch (Exception ex)
      {
        exceptionList.Add(ex);
      }
    }

    private void ProcessMessageUnlocked(string msg)
    {
      if (msg.Length < 3 || msg[0] != '\x001B')
        return;
      switch (msg[1])
      {
        case '\a':
        case '!':
          this.Log(msg.Substring(2), LogDetailLevels.TestMessage);
          if (this.m_PretestCheckRequest == null)
            break;
          int num = msg.IndexOf(this.m_PretestCheckRequest[0], StringComparison.OrdinalIgnoreCase);
          if (num >= 0 && msg.Length >= num + 84)
          {
            string str1 = (string) null;
            string str2 = (string) null;
            string str3 = (string) null;
            string str4;
            string str5;
            if (msg.Length < num + 99)
            {
              str4 = msg.Substring(num + 25, 30).Trim();
              str5 = msg.Substring(num + 80, 4).Trim();
            }
            else if (msg.Length < num + 101)
            {
              str4 = msg.Substring(num + 25, 30).Trim();
              str1 = msg.Substring(num + 55, 15).Trim();
              str5 = msg.Substring(num + 95, 4).Trim();
            }
            else if (msg.Length < num + 116)
            {
              str4 = msg.Substring(num + 25, 30).Trim();
              str3 = msg.Substring(num + 80, 15).Trim();
              str2 = msg.Substring(num + 95, 2).Trim();
              str5 = msg.Substring(num + 97, 4).Trim();
            }
            else
            {
              str4 = msg.Substring(num + 25, 30).Trim();
              str1 = msg.Substring(num + 55, 15).Trim();
              str3 = msg.Substring(num + 95, 15).Trim();
              str2 = msg.Substring(num + 110, 2).Trim();
              str5 = msg.Substring(num + 112, 4).Trim();
            }
            this.m_PretestCheckRequest[1] = str4;
            this.m_PretestCheckRequest[2] = str1;
            this.m_PretestCheckRequest[3] = str5;
            this.m_PretestCheckRequest[4] = str2;
            this.m_PretestCheckRequest[5] = str3;
            this.m_PretestCheckEvent.Set();
          }
          break;
        case '\f':
          if (msg.IndexOf("EMP ?") >= 0)
          {
            this.SendMessageUnlocked(this.m_OperatorId, false);
            break;
          }
          this.Log(msg.Substring(2), LogDetailLevels.TestMessage);
          if (this.m_PretestCheckRequest != null && msg.IndexOf(this.m_PretestCheckRequest[0], StringComparison.OrdinalIgnoreCase) >= 0)
          {
            this.m_PretestCheckRequest[1] = (string) null;
            this.m_PretestCheckRequest[2] = (string) null;
            this.m_PretestCheckRequest[3] = "FAIL";
            this.m_PretestCheckRequest[4] = (string) null;
            this.m_PretestCheckRequest[5] = (string) null;
            this.m_PretestCheckEvent.Set();
          }
          break;
        case '\x0010':
          this.SendMessageUnlocked("\x001B\x0010", false);
          break;
      }
    }

    private static void OnStreamRead(IAsyncResult ar)
    {
      soteSFIS2Fxcn asyncState = (soteSFIS2Fxcn) ar.AsyncState;
      bool flag1 = false;
      List<Exception> exceptionList = (List<Exception>) null;
      bool flag2 = false;
      lock (asyncState)
      {
        if (asyncState.m_ClientStream == null)
          return;
        try
        {
          int count1 = asyncState.m_ClientStream.EndRead(ar);
          if (count1 > 0)
          {
            string rawMessage = asyncState.m_Encoding.GetString(asyncState.m_DataBuffer, 0, count1);
            while (asyncState.m_ClientStream.DataAvailable)
            {
              int count2 = asyncState.m_ClientStream.Read(asyncState.m_DataBuffer, 0, asyncState.m_DataBuffer.Length);
              if (count2 > 0)
                rawMessage += asyncState.m_Encoding.GetString(asyncState.m_DataBuffer, 0, count2);
            }
            asyncState.Log(rawMessage, LogDetailLevels.RawMessage);
            string str1 = rawMessage;
            char[] separator = new char[2]{ '\r', '\n' };
            foreach (string str2 in str1.Split(separator, StringSplitOptions.RemoveEmptyEntries))
              asyncState.ProcessMessageUnlocked(str2.Trim());
            asyncState.m_ClientStream.BeginRead(asyncState.m_DataBuffer, 0, asyncState.m_DataBuffer.Length, new AsyncCallback(soteSFIS2Fxcn.OnStreamRead), (object) asyncState);
          }
          else
          {
            flag1 = true;
            asyncState.HandleSocketFailure((Exception) null, ref exceptionList);
          }
        }
        catch (Exception ex)
        {
          flag1 = true;
          flag2 = true;
          asyncState.HandleSocketFailure(ex, ref exceptionList);
        }
      }
      if (flag1)
        asyncState.OnDisconnected((IsoteSFIS2) asyncState);
      if (!flag2)
        return;
      foreach (Exception e in exceptionList)
        asyncState.OnError((IsoteSFIS2) asyncState, e);
    }

    private void OnTimer(object state)
    {
      bool flag1 = false;
      List<Exception> exceptionList = (List<Exception>) null;
      bool flag2 = false;
      lock (this)
      {
        if (this.m_ClientStream == null)
          return;
        try
        {
          this.SendMessageUnlocked("\x001B\x0011", false);
        }
        catch (Exception ex)
        {
          flag1 = true;
          flag2 = true;
          this.HandleSocketFailure(ex, ref exceptionList);
        }
      }
      if (flag1)
        this.OnDisconnected((IsoteSFIS2) this);
      if (!flag2)
        return;
      foreach (Exception e in exceptionList)
        this.OnError((IsoteSFIS2) this, e);
    }

    private enum OpenStates
    {
      Stopped,
      Listening,
      Connected,
    }
  }
}
