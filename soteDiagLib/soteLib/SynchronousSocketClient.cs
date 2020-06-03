// Decompiled with JetBrains decompiler
// Type: soteLib.SynchronousSocketClient
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace soteLib
{
  public class SynchronousSocketClient
  {
    private int ipPort = 11000;
    private IPHostEntry ipHostInfo;
    private IPAddress ipAddress;
    private IPEndPoint remoteEP;

    public SynchronousSocketClient()
    {
      this.ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
      this.ipAddress = this.ipHostInfo.AddressList[0];
    }

    public SynchronousSocketClient(string ip, int port)
    {
      this.ipAddress = IPAddress.Parse(ip);
      this.ipPort = port;
    }

    public string SendMessage(string message)
    {
      byte[] numArray = new byte[1024];
      try
      {
        Console.WriteLine("Connecting to ..." + this.ipAddress.ToString() + ":" + this.ipPort.ToString());
        this.remoteEP = new IPEndPoint(this.ipAddress, this.ipPort);
        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
          socket.Connect((EndPoint) this.remoteEP);
          Console.WriteLine("Socket connected to {0}", (object) socket.RemoteEndPoint.ToString());
          byte[] bytes = Encoding.ASCII.GetBytes(message + "\n");
          socket.Send(bytes);
          int count = socket.Receive(numArray);
          string str = Encoding.ASCII.GetString(numArray, 0, count);
          socket.Shutdown(SocketShutdown.Both);
          socket.Close();
          return str;
        }
        catch (ArgumentNullException ex)
        {
          return string.Format("ERROR: ArgumentNullException : {0}", (object) ex.ToString());
        }
        catch (SocketException ex)
        {
          return string.Format("ERROR: SocketException", (object) ex.ToString());
        }
        catch (Exception ex)
        {
          return string.Format("ERROR: Unexpected exception : {0}", (object) ex.ToString());
        }
      }
      catch (Exception ex)
      {
        return string.Format("ERROR: {0}", (object) ex.ToString());
      }
    }

    public string SendMessageUDP(string message)
    {
      try
      {
        byte[] bytes = Encoding.ASCII.GetBytes(message);
        UdpClient udpClient = new UdpClient();
        IPEndPoint endPoint = new IPEndPoint(this.ipAddress, this.ipPort);
        udpClient.Connect(endPoint);
        udpClient.Send(bytes, bytes.Length);
        udpClient.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine("SendMessageUDP: " + ex.Message);
        return ex.Message;
      }
      return "";
    }
  }
}
