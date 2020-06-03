// Decompiled with JetBrains decompiler
// Type: soteLib.soteUtils
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace soteLib
{
  public class soteUtils
  {
    private static soteUtils.delegateListener m_cbListener = (soteUtils.delegateListener) null;
    private static bool m_redirectEnable = false;
    private static bool m_createNoWindow = false;
    private static int m_timeoutMS = 0;
    private static string m_logfile = "";
    private static string exe_devcon = string.Format("{0}\\{1}", (object) Environment.CurrentDirectory, (object) "devcon.exe");
    private static string _HW = "USB";
    private static string _CHIPS = "";
    private static string _PCIID = "";
    private static string[] full_pciids = (string[]) null;
    public static StringBuilder cmdLineOutput;
    private static Process m_Process;
    private static Thread m_cmdThread;
    private static string m_exename;
    private static string m_args;
    private static string chipnum;
    private static string chipname;

    private static void ErrorOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
    {
      if (string.IsNullOrEmpty(outLine.Data))
        return;
      Console.WriteLine("Error: " + outLine.Data.ToString());
    }

    private static void ProcessOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
    {
      try
      {
        if (string.IsNullOrEmpty(outLine.Data))
          return;
        if (soteUtils.m_cbListener != null)
          soteUtils.m_cbListener(outLine.Data.ToString());
        soteUtils.cmdLineOutput.Append(string.Format("{0}\n", (object) outLine.Data.ToString()));
      }
      catch (Exception ex)
      {
        Console.WriteLine("hDataReceivedEvent: " + ex.Message);
      }
    }

    public static void abortCmdLine()
    {
      try
      {
        if (soteUtils.m_Process == null)
          return;
        soteUtils.m_Process.Kill();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    public static void writeCmdLine(string cmds)
    {
      try
      {
        if (soteUtils.m_Process == null)
          return;
        soteUtils.m_Process.StandardInput.WriteLine(cmds);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    public static bool runCmdLine(
      string exename,
      string args,
      soteUtils.delegateListener cbListener,
      bool redirectEnable,
      bool noDOSWindow,
      int timeoutMS)
    {
      try
      {
        if (soteUtils.m_Process == null)
        {
          soteUtils.m_exename = exename;
          soteUtils.m_args = args;
          soteUtils.m_createNoWindow = noDOSWindow;
          soteUtils.m_timeoutMS = timeoutMS;
          if (cbListener != null)
            soteUtils.m_cbListener = new soteUtils.delegateListener(cbListener.Invoke);
          soteUtils.m_redirectEnable = redirectEnable;
          soteUtils.m_cmdThread = new Thread(new ThreadStart(soteUtils.threadCmdLine));
          soteUtils.m_cmdThread.Start();
          if (soteUtils.m_redirectEnable)
            soteUtils.m_cmdThread.Join();
          return true;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return false;
    }

    public static bool runCmdLine(
      string exename,
      string args,
      soteUtils.delegateListener cbListener,
      bool redirectEnable)
    {
      try
      {
        if (soteUtils.m_Process == null)
        {
          soteUtils.m_exename = exename;
          soteUtils.m_args = args;
          if (cbListener != null)
            soteUtils.m_cbListener = new soteUtils.delegateListener(cbListener.Invoke);
          soteUtils.m_redirectEnable = redirectEnable;
          soteUtils.m_cmdThread = new Thread(new ThreadStart(soteUtils.threadCmdLine));
          soteUtils.m_cmdThread.Start();
          if (soteUtils.m_redirectEnable)
            soteUtils.m_cmdThread.Join();
          return true;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
      return false;
    }

    public static bool runCmdLine(
      string exename,
      string args,
      soteUtils.delegateListener cbListener)
    {
      soteUtils.m_redirectEnable = cbListener != null;
      return soteUtils.runCmdLine(exename, args, cbListener);
    }

    private static void threadCmdLine()
    {
      try
      {
        soteUtils.m_Process = new Process();
        soteUtils.m_Process.StartInfo.FileName = soteUtils.m_exename;
        soteUtils.m_Process.StartInfo.Arguments = soteUtils.m_args;
        soteUtils.m_Process.StartInfo.UseShellExecute = false;
        soteUtils.m_Process.StartInfo.CreateNoWindow = soteUtils.m_createNoWindow;
        if (soteUtils.m_redirectEnable)
        {
          soteUtils.m_Process.StartInfo.RedirectStandardInput = true;
          soteUtils.m_Process.StartInfo.RedirectStandardOutput = true;
          soteUtils.m_Process.StartInfo.RedirectStandardError = true;
          soteUtils.m_Process.OutputDataReceived += new DataReceivedEventHandler(soteUtils.ProcessOutputHandler);
          soteUtils.m_Process.ErrorDataReceived += new DataReceivedEventHandler(soteUtils.ErrorOutputHandler);
        }
        soteUtils.cmdLineOutput = new StringBuilder();
        soteUtils.m_Process.Start();
        if (soteUtils.m_redirectEnable)
        {
          soteUtils.m_Process.BeginOutputReadLine();
          soteUtils.m_Process.BeginErrorReadLine();
        }
        if (soteUtils.m_timeoutMS == 0)
          soteUtils.m_Process.WaitForExit();
        else
          soteUtils.m_Process.WaitForExit(soteUtils.m_timeoutMS);
      }
      catch (Exception ex)
      {
        Console.WriteLine("runCmdLine: " + ex.Message);
      }
      soteUtils.m_Process.Close();
      soteUtils.m_Process = (Process) null;
    }

    public static void email(
      string to,
      string from,
      string subject,
      string body,
      string attachment)
    {
      MailMessage message = new MailMessage(from, to, subject, body);
      SmtpClient smtpClient = new SmtpClient("smtphost.broadcom.com");
      try
      {
        smtpClient.Send(message);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("email: " + ex.ToString());
      }
    }

    public static int WeekOfYear(string date)
    {
      try
      {
        if (date != "")
        {
          CultureInfo cultureInfo = new CultureInfo("en-US");
          Calendar calendar = cultureInfo.Calendar;
          CalendarWeekRule calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
          DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;
          return calendar.GetWeekOfYear(Convert.ToDateTime(date), calendarWeekRule, firstDayOfWeek);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("WeekOfYear: " + ex.Message);
      }
      return 0;
    }

    public static string logfile
    {
      set
      {
        soteUtils.m_logfile = value;
      }
    }

    public static bool log2file(string msg)
    {
      return !(soteUtils.m_logfile == "") && soteUtils.log2file(soteUtils.m_logfile, msg);
    }

    public static bool log2file(string fn, string msg)
    {
      try
      {
        StreamWriter streamWriter = new StreamWriter(fn, true);
        streamWriter.WriteLine(msg);
        streamWriter.Close();
        return true;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("log2file: " + ex.Message);
      }
      return false;
    }

    public static bool log2fileOverWrite(string fn, string msg)
    {
      try
      {
        StreamWriter streamWriter = new StreamWriter(fn, false);
        streamWriter.WriteLine(msg);
        streamWriter.Close();
        return true;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("log2file: " + ex.Message);
      }
      return false;
    }

    public static byte[] readbin(string fn)
    {
      return soteUtils.readbin(fn, out string _, false);
    }

    public static byte[] readbin(string fn, out string buffer)
    {
      return soteUtils.readbin(fn, out buffer, false);
    }

    public static byte[] readbin(string fn, out string buffer, bool log)
    {
      FileStream fileStream = (FileStream) null;
      byte[] numArray = (byte[]) null;
      buffer = "";
      try
      {
        fileStream = new FileStream(fn, FileMode.Open);
        BinaryReader binaryReader = new BinaryReader((Stream) fileStream);
        numArray = new byte[binaryReader.BaseStream.Length];
        int index = 0;
        string msg = "";
        while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
        {
          numArray[index] = binaryReader.ReadByte();
          buffer += (string) (object) (char) numArray[index];
          msg += string.Format("{0:X2} ", (object) numArray[index]);
          ++index;
        }
        if (log)
          soteUtils.log2file(msg);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("readbin: " + ex.Message);
        buffer = (string) null;
      }
      fileStream.Close();
      return numArray;
    }

    public static string DEVCON_CHIPS
    {
      get
      {
        return soteUtils._CHIPS;
      }
      set
      {
        soteUtils._CHIPS = value;
      }
    }

    public static string DEVCON_PCIID
    {
      get
      {
        return soteUtils._PCIID;
      }
      set
      {
        soteUtils._PCIID = value;
      }
    }

    public static string DEVCON_HW
    {
      get
      {
        return soteUtils._HW;
      }
      set
      {
        soteUtils._HW = value;
      }
    }

    public static int DEVCON_numdevices()
    {
      if (soteUtils._PCIID == "")
      {
        soteUtils.log2file("\nFAIL: PCIID is not initialized");
        return 0;
      }
      if (!File.Exists(soteUtils.exe_devcon))
      {
        soteUtils.log2file(string.Format("\nFAIL: File not found: {0}", (object) soteUtils.exe_devcon));
        return 0;
      }
      try
      {
        string[] array = new string[100];
        switch (soteUtils._HW)
        {
          case "PCI":
            soteUtils.runCmdLine(soteUtils.exe_devcon, "find PCI\\VEN*", (soteUtils.delegateListener) null, true);
            break;
          case "USB":
            soteUtils.runCmdLine(soteUtils.exe_devcon, "find USB\\VID*", (soteUtils.delegateListener) null, true);
            break;
        }
        string str1 = soteUtils.cmdLineOutput.ToString();
        if (str1.Length > 0)
        {
          int newSize = 0;
          char[] chArray = new char[2]{ ':', '\n' };
          string[] strArray1 = str1.Split(chArray);
          for (int index = 0; index < strArray1.Length; ++index)
          {
            if (strArray1[index].StartsWith(soteUtils._HW))
            {
              array[newSize] = strArray1[index].ToString();
              if (newSize++ > 99)
                break;
            }
          }
          Array.Resize<string>(ref array, newSize);
          string[] all = Array.FindAll<string>(array, new Predicate<string>(soteUtils.ContainReqIDs));
          if (all.Length == 0)
          {
            soteUtils.log2file(string.Format("\nFAIL: Could not find pci device\n{0}", (object) soteUtils._PCIID));
            return 0;
          }
          soteUtils.full_pciids = new string[all.Length];
          Array.Copy((Array) all, (Array) soteUtils.full_pciids, all.Length);
          int length = all.Length;
          string str2 = all[0].Substring(all[0].IndexOf("VEN_") + 4, 4);
          string str3 = all[0].Substring(all[0].IndexOf("DEV_") + 4, 4);
          string[] strArray2 = "".Split(',');
          int index1;
          for (index1 = 0; index1 < strArray2.Length - 1; ++index1)
          {
            string str4 = string.Format("0x{0}:0x{1}", (object) str2, (object) str3);
            if (strArray2[index1].Equals(str4.ToUpper()))
            {
              soteUtils.chipnum = strArray2[index1 + 1];
              soteUtils.chipname = strArray2[index1 + 2];
              break;
            }
          }
          return index1 == strArray2.Length ? 0 : length;
        }
        soteUtils.log2file(string.Format("\nFAIL: Could not find pci device\n{0}", (object) str1));
      }
      catch (Exception ex)
      {
        soteUtils.log2file(string.Format("\nFAIL: DEVCON_find exception was raised: {0}", (object) ex.Message));
      }
      return 0;
    }

    private static bool ContainReqIDs(string s)
    {
      string devconPciid = soteUtils.DEVCON_PCIID;
      char[] chArray1 = new char[1]{ ',' };
      foreach (string str1 in devconPciid.Split(chArray1))
      {
        char[] chArray2 = new char[1]{ ':' };
        string[] strArray = str1.Split(chArray2);
        string str2 = strArray[0].Remove(0, 2);
        string str3 = strArray[1].Remove(0, 2);
        string str4 = "";
        switch (soteUtils._HW)
        {
          case "PCI":
            str4 = string.Format("PCI\\VEN_{0}&DEV_{1}", (object) str2, (object) str3);
            break;
          case "USB":
            str4 = string.Format("USB\\VID_{0}&PID_{1}", (object) str2, (object) str3);
            break;
        }
        if (s.Contains(str4.ToUpper()))
          return true;
      }
      return false;
    }

    public static bool DEVCON_status(int hDevice)
    {
      if (soteUtils.full_pciids == null)
      {
        soteUtils.log2file("\nFAIL: PCIID is not initialized");
        return false;
      }
      if (hDevice > soteUtils.full_pciids.Length - 1)
      {
        soteUtils.log2file("\nFAIL: Invalid handle to device");
        return false;
      }
      try
      {
        string fullPciid = soteUtils.full_pciids[hDevice];
        soteUtils.runCmdLine(soteUtils.exe_devcon, string.Format("find @{0}", (object) fullPciid), (soteUtils.delegateListener) null, true);
        if (!soteUtils.cmdLineOutput.ToString().Contains(fullPciid))
        {
          soteUtils.log2file(string.Format("\nFAIL: Device not found [{0}]", (object) fullPciid));
          return false;
        }
        soteUtils.runCmdLine(soteUtils.exe_devcon, string.Format("status @{0}", (object) fullPciid), (soteUtils.delegateListener) null, true);
        if (soteUtils.cmdLineOutput.ToString().Contains("Driver is running"))
          return true;
      }
      catch (Exception ex)
      {
        soteUtils.log2file(string.Format("\nFAIL: DEVCON_status exception was raised: {0}", (object) ex.Message));
      }
      return false;
    }

    public static bool DEVCON_rescan()
    {
      try
      {
        soteUtils.runCmdLine(soteUtils.exe_devcon, "rescan", (soteUtils.delegateListener) null, true);
        string str = soteUtils.cmdLineOutput.ToString();
        if (str.Contains("Scanning completed"))
          return true;
        soteUtils.log2file(string.Format("\nFAIL: DEVCON_rescan\n->{0}", (object) str));
      }
      catch (Exception ex)
      {
        soteUtils.log2file(string.Format("\nFAIL: DEVCON_rescan exception was raised: {0}", (object) ex.Message));
      }
      return false;
    }

    public static bool DEVCON_enable(int hDevice)
    {
      if (soteUtils.full_pciids == null)
      {
        soteUtils.log2file("\nFAIL: PCIID is not initialized");
        return false;
      }
      if (hDevice > soteUtils.full_pciids.Length - 1)
      {
        soteUtils.log2file("\nFAIL: Invalid handle to device");
        return false;
      }
      try
      {
        string fullPciid = soteUtils.full_pciids[hDevice];
        soteUtils.runCmdLine(soteUtils.exe_devcon, string.Format("enable @{0}", (object) fullPciid), (soteUtils.delegateListener) null, true);
        if (soteUtils.cmdLineOutput.ToString().Contains("Enabled"))
          return true;
        soteUtils.log2file(string.Format("\nFAIL: Device not enabled [{0}]", (object) fullPciid));
      }
      catch (Exception ex)
      {
        soteUtils.log2file(string.Format("\nFAIL: DEVCON_enable exception was raised: {0}", (object) ex.Message));
      }
      return false;
    }

    public static bool DEVCON_disable(int hDevice)
    {
      if (soteUtils.full_pciids == null)
      {
        soteUtils.log2file("\nFAIL: PCIID is not initialized");
        return false;
      }
      if (hDevice > soteUtils.full_pciids.Length - 1)
      {
        soteUtils.log2file("\nFAIL: Invalid handle to device");
        return false;
      }
      try
      {
        string fullPciid = soteUtils.full_pciids[hDevice];
        soteUtils.runCmdLine(soteUtils.exe_devcon, string.Format("disable @{0}", (object) fullPciid), (soteUtils.delegateListener) null, true);
        if (soteUtils.cmdLineOutput.ToString().Contains("disabled"))
          return true;
        soteUtils.log2file(string.Format("\nFAIL: Device not disabled [{0}]", (object) fullPciid));
      }
      catch (Exception ex)
      {
        soteUtils.log2file(string.Format("\nFAIL: DEVCON_disable exception was raised: {0}", (object) ex.Message));
      }
      return false;
    }

    public static bool DEVCON_restart(int hDevice)
    {
      if (soteUtils.full_pciids == null)
      {
        soteUtils.log2file("\nFAIL: PCIID is not initialized");
        return false;
      }
      if (hDevice > soteUtils.full_pciids.Length - 1)
      {
        soteUtils.log2file("\nFAIL: Invalid handle to device");
        return false;
      }
      try
      {
        string fullPciid = soteUtils.full_pciids[hDevice];
        soteUtils.runCmdLine(soteUtils.exe_devcon, string.Format("restart @{0}", (object) fullPciid), (soteUtils.delegateListener) null, true);
        string str = soteUtils.cmdLineOutput.ToString();
        if (str.Contains("Restarted"))
          return true;
        soteUtils.log2file(string.Format("\nFAIL: Could not restart driver\n{0}", (object) str));
      }
      catch (Exception ex)
      {
        soteUtils.log2file(string.Format("\nFAIL: DEVCON_restart exception was raised: {0}", (object) ex.Message));
      }
      return false;
    }

    public delegate void delegateListener(string msg);
  }
}
