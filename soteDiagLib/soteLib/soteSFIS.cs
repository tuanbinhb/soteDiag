// Decompiled with JetBrains decompiler
// Type: soteLib.soteSFIS
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace soteLib
{
  public class soteSFIS
  {
    private static ManualResetEvent ackEvent = new ManualResetEvent(false);
    private const int KEYDOWN_EVENT = 0;
    private const int KEYUP_EVENT = 2;
    private const int SCANCODE_F12 = 88;
    private const int SCANCODE_LEFT_CONTROL = 29;
    private const int VK_LEFT_CONTROL = 162;
    private const int VK_F12 = 123;
    private static string ackMessage;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern void keybd_event(byte vk, byte scan, int flags, int extrainfo);

    private static void cbSerialRead(string msg)
    {
      soteSFIS.ackMessage += msg;
      if (!soteSFIS.ackMessage.EndsWith("PASS\r\n"))
        return;
      soteSFIS.ackEvent.Set();
    }

    public static string SendReceiveFXCN(
      string comport,
      string sn,
      string mac,
      string station,
      string status,
      string fc,
      out string msg)
    {
      int baudrate = 9600;
      int databits = 8;
      string parity = "None";
      string stopbits = "One";
      string handshake = "None";
      CommPort commPort = new CommPort();
      if (!commPort.Install(comport, baudrate, databits, parity, stopbits, handshake, new CommPort.delegateSerialRead(soteSFIS.cbSerialRead)))
        throw new Exception(string.Format("{0} Not Available", (object) comport));
      msg = string.Format("{0}{1}{2}{3}", (object) sn.PadRight(25), (object) mac.PadRight(12), (object) station.PadRight(12, '-'), status == "PASS" ? (object) "" : (object) (fc + "END"));
      soteSFIS.ackEvent.Reset();
      soteSFIS.ackMessage = "";
      commPort.WriteLine(msg);
      bool flag = soteSFIS.ackEvent.WaitOne(5000, false);
      commPort.Uninstall();
      return (flag ? "" : "TIMEOUT ") + soteSFIS.ackMessage;
    }

    public static string SendReceive(string ip, int port, string msg)
    {
      return new SynchronousSocketClient(ip, port).SendMessage(msg);
    }

    public static string SendReceiveUSI(
      string ip,
      int port,
      string fixture_id,
      string label,
      string badge,
      string line,
      string[] macs,
      string status,
      string fc,
      string version,
      out string msg)
    {
      string str1 = "";
      string str2;
      if (status == "PASS")
      {
        if (macs != null)
        {
          for (int index = 0; index < macs.Length; ++index)
            str1 += string.Format("MAC{0}={1} ", (object) (index + 1), (object) macs[index]);
          str1 = str1 + "MAC_CNT=" + macs.Length.ToString();
        }
        str2 = "OK";
      }
      else
        str2 = string.Format("FAIL,,{0}", (object) fc);
      msg = string.Format("{0},{1},2,{2},{3},{4},{5},{6}", (object) fixture_id, (object) label, (object) badge, (object) line, (object) str1, (object) str2, (object) version);
      return new SynchronousSocketClient(ip, port).SendMessage(msg);
    }

    public static string SendReceiveLiteOn(
      string fn,
      string label,
      string[] macs,
      string status,
      string fc,
      out string msg)
    {
      string str = "";
      if (macs != null)
      {
        for (int index = 0; index < macs.Length; ++index)
          str += string.Format("MAC{0}###{1}###NA###{2}\n", (object) (index + 1), (object) macs[index], (object) status);
      }
      msg = string.Format("{0}\n{1}\n{2}{3}\n{4}\n{5}", status == "PASS" ? (object) "P" : (object) "F", (object) label, status == "PASS" ? (object) "" : (object) (fc + "\n"), (object) "FRU Send_To_SQL test program", (object) "V1.0", (object) str);
      return !soteUtils.log2file(fn, msg) ? "Error logging to " + fn : "";
    }

    public static void LiteOnShopFloorControl()
    {
      soteSFIS.keybd_event((byte) 162, (byte) 29, 0, 0);
      soteSFIS.keybd_event((byte) 123, (byte) 88, 0, 0);
      soteSFIS.keybd_event((byte) 123, (byte) 88, 2, 0);
      soteSFIS.keybd_event((byte) 162, (byte) 29, 2, 0);
    }

    public delegate void delegateSerialRead(string msg);
  }
}
