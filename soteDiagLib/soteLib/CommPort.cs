// Decompiled with JetBrains decompiler
// Type: soteLib.CommPort
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace soteLib
{
  public class CommPort
  {
    private Encoding enc = Encoding.GetEncoding("IBM437");
    private byte[] bytes = new byte[32768];
    private const int BUFFER_SIZE = 32768;
    private SerialPort m_CommPort;
    private CommPort.delegateSerialRead m_cbSerialRead;

    public string[] AvailablePorts()
    {
      return SerialPort.GetPortNames();
    }

    public void EnablePort()
    {
      if (this.m_CommPort == null)
        return;
      this.m_CommPort.Open();
      this.m_CommPort.DiscardInBuffer();
      this.m_CommPort.DiscardOutBuffer();
    }

    public void DisablePort()
    {
      if (this.m_CommPort == null)
        return;
      this.m_CommPort.Close();
    }

    private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      try
      {
        if (!this.m_CommPort.IsOpen)
          return;
        int count = this.m_CommPort.Read(this.bytes, 0, 32768);
        if (this.m_cbSerialRead != null)
          this.m_cbSerialRead(this.enc.GetString(this.bytes, 0, count));
      }
      catch (Exception ex)
      {
      }
    }

    private void SerialErrorReceived(object sender, SerialErrorReceivedEventArgs e)
    {
      switch (e.EventType.ToString())
      {
      }
    }

    public bool Install(
      string portname,
      int baudrate,
      int databits,
      string parity,
      string stopbits,
      string handshake,
      CommPort.delegateSerialRead cbSerialRead)
    {
      try
      {
        this.m_CommPort = new SerialPort(portname, baudrate, (Parity) Enum.Parse(typeof (Parity), parity), databits, (StopBits) Enum.Parse(typeof (StopBits), stopbits));
        this.m_CommPort.Handshake = (Handshake) Enum.Parse(typeof (Handshake), handshake);
        this.m_CommPort.DiscardNull = true;
        this.m_CommPort.RtsEnable = true;
        this.m_CommPort.DtrEnable = true;
        this.m_CommPort.ReadTimeout = 2000;
        this.m_CommPort.WriteTimeout = 2000;
        this.m_CommPort.ReadBufferSize *= 16;
        this.m_CommPort.WriteBufferSize *= 16;
        this.m_CommPort.DataReceived += new SerialDataReceivedEventHandler(this.SerialDataReceived);
        this.m_cbSerialRead = new CommPort.delegateSerialRead(cbSerialRead.Invoke);
        this.m_CommPort.Open();
        this.m_CommPort.DiscardInBuffer();
        this.m_CommPort.DiscardOutBuffer();
      }
      catch (Exception ex)
      {
        this.m_CommPort = (SerialPort) null;
        return false;
      }
      return true;
    }

    private void ClosePortThread()
    {
      try
      {
        this.m_CommPort.Close();
        Thread.Sleep(500);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
    }

    public bool Uninstall()
    {
      try
      {
        if (this.m_CommPort != null)
        {
          if (this.m_CommPort.IsOpen)
          {
            this.m_CommPort.DataReceived -= new SerialDataReceivedEventHandler(this.SerialDataReceived);
            this.m_cbSerialRead = (CommPort.delegateSerialRead) null;
            Thread thread = new Thread(new ThreadStart(this.ClosePortThread));
            thread.Start();
            thread.Join();
          }
          this.m_CommPort.Dispose();
          this.m_CommPort = (SerialPort) null;
        }
      }
      catch (Exception ex)
      {
        return false;
      }
      return true;
    }

    public void Write(string message)
    {
      if (!this.m_CommPort.IsOpen)
        return;
      this.m_CommPort.Write(this.enc.GetBytes(message), 0, message.Length);
    }

    public void WriteByte(byte ch)
    {
      byte[] buffer = new byte[1]{ ch };
      if (!this.m_CommPort.IsOpen)
        return;
      this.m_CommPort.Write(buffer, 0, 1);
    }

    public void WriteLine(string message)
    {
      if (!this.m_CommPort.IsOpen)
        return;
      this.m_CommPort.WriteLine(message);
    }

    public delegate void delegateSerialRead(string msg);
  }
}
