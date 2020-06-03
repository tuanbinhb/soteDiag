// Decompiled with JetBrains decompiler
// Type: soteLib.SynchronousSocketListener
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace soteLib
{
  public class SynchronousSocketListener
  {
    public static string data = (string) null;
    private int m_ipPort = 11000;
    private Socket m_handler = (Socket) null;
    private string m_Response = "";
    private UdpClient m_udp = (UdpClient) null;
    private IPHostEntry m_ipHostInfo;
    private IPAddress m_ipAddress;
    private IPEndPoint m_localEndPoint;
    private SynchronousSocketListener.delegateListener m_cbListener;
    private Thread m_udpThread;

    public SynchronousSocketListener()
    {
      this.m_ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
      this.m_ipAddress = this.m_ipHostInfo.AddressList[0];
    }

    public SynchronousSocketListener(
      string ip,
      int port,
      SynchronousSocketListener.delegateListener cbListener)
    {
      this.m_ipAddress = IPAddress.Parse(ip);
      this.m_ipPort = port;
      this.m_cbListener = new SynchronousSocketListener.delegateListener(cbListener.Invoke);
    }

    public string Response
    {
      set
      {
        this.m_Response = value;
      }
    }

    public void StartListening(bool display)
    {
      byte[] numArray = new byte[1024];
      Console.WriteLine("Listening on ..." + this.m_ipAddress.ToString() + ":" + this.m_ipPort.ToString());
      this.m_localEndPoint = new IPEndPoint(this.m_ipAddress, this.m_ipPort);
      Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      try
      {
        socket.Bind((EndPoint) this.m_localEndPoint);
        socket.Listen(10);
        while (true)
        {
          bool flag = true;
          Console.WriteLine("Waiting for a connection...");
          this.m_handler = socket.Accept();
          SynchronousSocketListener.data = (string) null;
          do
          {
            flag = true;
            int count = this.m_handler.Receive(numArray);
            SynchronousSocketListener.data += Encoding.ASCII.GetString(numArray, 0, count);
          }
          while (SynchronousSocketListener.data.IndexOf("\n") <= -1);
          DateTime now;
          if (display)
          {
            now = DateTime.Now;
            Console.WriteLine("[{0}] Rx: {1}", (object) now.ToString(), (object) SynchronousSocketListener.data);
          }
          if (this.m_cbListener != null)
            this.m_cbListener(SynchronousSocketListener.data);
          this.m_handler.Send(Encoding.ASCII.GetBytes(this.m_Response));
          if (display)
          {
            now = DateTime.Now;
            Console.WriteLine("[{0}] Tx: {1}", (object) now.ToString(), (object) SynchronousSocketListener.data);
          }
          this.m_handler.Shutdown(SocketShutdown.Both);
          this.m_handler.Close();
          this.m_handler = (Socket) null;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
      Console.WriteLine("\nPress ENTER to continue...");
      Console.Read();
    }

    private void ThreadListening()
    {
      try
      {
        this.m_localEndPoint = new IPEndPoint(IPAddress.Any, this.m_ipPort);
        this.m_udp = new UdpClient(this.m_localEndPoint);
        Console.WriteLine("listening for messages");
        while (true)
        {
          string msg = Encoding.ASCII.GetString(this.m_udp.Receive(ref this.m_localEndPoint));
          Console.WriteLine("[{0}] Rx: {1}", (object) DateTime.Now.ToString(), (object) msg);
          if (this.m_cbListener != null)
            this.m_cbListener(msg);
        }
      }
      catch (Exception ex)
      {
      }
    }

    public void StartListeningUDP(bool display)
    {
      this.m_udpThread = new Thread(new ThreadStart(this.ThreadListening));
      this.m_udpThread.Start();
    }

    public void EndListteningUDP()
    {
      this.m_udp.Close();
      this.m_udpThread.Join();
    }

    public delegate void delegateListener(string msg);
  }
}
