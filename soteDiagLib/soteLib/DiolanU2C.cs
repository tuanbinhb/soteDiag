// Decompiled with JetBrains decompiler
// Type: soteLib.DiolanU2C
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace soteLib
{
  public class DiolanU2C
  {
    private static int m_Subtype = -1;
    private const int I2C_WRITE_DELAY = 30;
    private const int U2C_I2C_FREQ_FAST = 0;
    private const int U2C_I2C_FREQ_STD = 1;
    private const int U2C_I2C_FREQ_83KHZ = 2;
    private const int U2C_I2C_FREQ_71KHZ = 3;
    private const int U2C_I2C_FREQ_62KHZ = 4;
    private const int U2C_I2C_FREQ_50KHZ = 6;
    private const int U2C_I2C_FREQ_25KHZ = 16;
    private const int U2C_I2C_FREQ_10KHZ = 46;
    private const int U2C_I2C_FREQ_5KHZ = 96;
    private const int U2C_I2C_FREQ_2KHZ = 242;
    private const int DLN_I2C_MASTER_CANCEL_TRANSFERS = 0;
    private const int DLN_I2C_MASTER_WAIT_FOR_TRANSFERS = 1;
    private const int DLN_I2C_MASTER_DISABLED = 0;
    private const int DLN_I2C_MASTER_ENABLED = 1;
    private const int DLN_DEFAULT_SERVER_PORT = 9656;
    private static DiolanU2C.EepromTypes[] sm_EepromTypes;
    private static int hDiolan;
    private static byte addrSlave;
    private static ushort hDLN2;

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnI2cMasterSetFrequency(
      ushort hDevice,
      byte nPort,
      uint nFreq,
      ref uint nActualFreq);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnI2cMasterGetFrequency(
      ushort hDevice,
      byte nPort,
      ref uint nActualFreq);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnI2cMasterScanDevices(
      ushort hDevice,
      byte nPort,
      ref byte nSlaveCount,
      ref DiolanU2C.DLN2_SLAVE_ADDR_LIST pList);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnI2cMasterIsEnabled(ushort hDevice, byte nPort, ref byte bEnabled);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnI2cMasterDisable(
      ushort hDevice,
      byte nPort,
      uint waitForTransferCompletion);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnI2cMasterEnable(ushort hDevice, uint nPort, ref ushort nConflict);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnI2cMasterGetPortCount(ushort hDevice, ref byte nPortCount);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnCloseHandle(ushort hDevice);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnCloseAllHandles();

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnGetDeviceId(ushort hDevice, ref uint nIdNum);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnConnect(string sHost, ushort nPort);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnDisconnect(string sHost, ushort nPort);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnDisconnectAll();

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnOpenDeviceBySn(uint nSerialNum, ref ushort hDevice);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnOpenDeviceById(uint nIdNum, ref ushort hDevice);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnOpenDevice(uint nDeviceNum, ref ushort hDevice);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnGetDeviceCount(ref uint pDeviceCount);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnI2cMasterRead(
      ushort hDevice,
      uint nPort,
      byte nSlaveAddress,
      byte nMemoryAddressLength,
      uint nMemoryAddress,
      ushort nBufferLength,
      byte[] pBuffer);

    [DllImport("dln.dll", SetLastError = true)]
    private static extern uint DlnI2cMasterWrite(
      ushort hDevice,
      uint nPort,
      byte nSlaveAddress,
      byte nMemoryAddressLength,
      uint nMemoryAddress,
      ushort nBufferLength,
      byte[] pBuffer);

    [DllImport("U2CCommon.dll", SetLastError = true)]
    private static extern int OpenU2C();

    [DllImport("i2cbrdg.dll", SetLastError = true)]
    private static extern byte U2C_GetDeviceCount();

    [DllImport("i2cbrdg.dll", SetLastError = true)]
    private static extern byte U2C_GetSerialNum(int hDevice, ref ulong pSerialNum);

    [DllImport("i2cbrdg.dll", SetLastError = true)]
    private static extern int U2C_OpenDevice(byte nDevice);

    [DllImport("i2cbrdg.dll", SetLastError = true)]
    private static extern int U2C_OpenDeviceBySerialNum(ulong nSerialNum);

    [DllImport("i2cbrdg.dll", SetLastError = true)]
    private static extern int U2C_CloseDevice(int hDevice);

    [DllImport("i2cbrdg.dll", SetLastError = true)]
    private static extern int U2C_IsHandleValid(int hDevice);

    [DllImport("i2cbrdg.dll", SetLastError = true)]
    private static extern int U2C_ScanDevices(int hDevice, ref DiolanU2C.U2C_SLAVE_ADDR_LIST pList);

    [DllImport("i2cbrdg.dll", SetLastError = true)]
    private static extern DiolanU2C.U2C_VERSION_INFO U2C_GetDllVersion();

    [DllImport("i2cbrdg.dll", SetLastError = true)]
    private static extern int U2C_SetI2cFreq(int hDevice, byte Frequency);

    [DllImport("i2cbrdg.dll", SetLastError = true)]
    private static extern int U2C_Read(int hDevice, ref DiolanU2C.U2C_TRANSACTION pTransaction);

    [DllImport("i2cbrdg.dll", SetLastError = true)]
    private static extern int U2C_Write(int hDevice, ref DiolanU2C.U2C_TRANSACTION pTransaction);

    public static int DLN2Connect()
    {
      DiolanU2C.DlnConnect("localhost", (ushort) 9656);
      uint pDeviceCount = 0;
      int deviceCount = (int) DiolanU2C.DlnGetDeviceCount(ref pDeviceCount);
      return pDeviceCount < 1U ? 0 : 1;
    }

    public static int DLN2Init(ulong sn)
    {
      if (DiolanU2C.sm_EepromTypes == null)
      {
        DiolanU2C.sm_EepromTypes = new DiolanU2C.EepromTypes[12];
        DiolanU2C.sm_EepromTypes[0] = new DiolanU2C.EepromTypes("ATMEL AT24C01", 128U, (ushort) 4, (byte) 1, (byte) 7);
        DiolanU2C.sm_EepromTypes[1] = new DiolanU2C.EepromTypes("ATMEL AT24C02", 256U, (ushort) 8, (byte) 1, (byte) 8);
        DiolanU2C.sm_EepromTypes[2] = new DiolanU2C.EepromTypes("ATMEL AT24C04", 512U, (ushort) 16, (byte) 1, (byte) 9);
        DiolanU2C.sm_EepromTypes[3] = new DiolanU2C.EepromTypes("ATMEL AT24C08", 1024U, (ushort) 16, (byte) 1, (byte) 10);
        DiolanU2C.sm_EepromTypes[4] = new DiolanU2C.EepromTypes("ATMEL AT24C16", 2048U, (ushort) 16, (byte) 1, (byte) 11);
        DiolanU2C.sm_EepromTypes[5] = new DiolanU2C.EepromTypes("ATMEL AT24C32", 4096U, (ushort) 32, (byte) 2, (byte) 12);
        DiolanU2C.sm_EepromTypes[6] = new DiolanU2C.EepromTypes("ATMEL AT24C64", 8192U, (ushort) 32, (byte) 2, (byte) 13);
        DiolanU2C.sm_EepromTypes[7] = new DiolanU2C.EepromTypes("ATMEL AT24C128", 16384U, (ushort) 64, (byte) 2, (byte) 14);
        DiolanU2C.sm_EepromTypes[8] = new DiolanU2C.EepromTypes("ATMEL AT24C256", 32768U, (ushort) 64, (byte) 2, (byte) 15);
        DiolanU2C.sm_EepromTypes[9] = new DiolanU2C.EepromTypes("ATMEL AT24C512", 65536U, (ushort) 128, (byte) 2, (byte) 16);
        DiolanU2C.sm_EepromTypes[10] = new DiolanU2C.EepromTypes("ATMEL AT24C1024", 131072U, (ushort) 256, (byte) 2, (byte) 17);
        DiolanU2C.sm_EepromTypes[11] = new DiolanU2C.EepromTypes("ATMEL ATTINY84", 4096U, (ushort) 16, (byte) 2, (byte) 16);
      }
      for (int index = 0; index < 3; ++index)
      {
        uint num = DiolanU2C.DlnOpenDeviceBySn((uint) sn, ref DiolanU2C.hDLN2);
        if (DiolanU2C.hDLN2 < (ushort) 1)
          return 0;
        byte nPortCount = 0;
        num = DiolanU2C.DlnI2cMasterGetPortCount(DiolanU2C.hDLN2, ref nPortCount);
        if (nPortCount < (byte) 1)
          return 0;
        byte bEnabled = 0;
        num = DiolanU2C.DlnI2cMasterIsEnabled(DiolanU2C.hDLN2, (byte) 0, ref bEnabled);
        if (bEnabled == (byte) 0)
        {
          ushort nConflict = 0;
          num = DiolanU2C.DlnI2cMasterEnable(DiolanU2C.hDLN2, 0U, ref nConflict);
          num = DiolanU2C.DlnI2cMasterIsEnabled(DiolanU2C.hDLN2, (byte) 0, ref bEnabled);
        }
        if (bEnabled == (byte) 1)
        {
          byte nSlaveCount = 0;
          DiolanU2C.DLN2_SLAVE_ADDR_LIST pList = new DiolanU2C.DLN2_SLAVE_ADDR_LIST();
          num = DiolanU2C.DlnI2cMasterScanDevices(DiolanU2C.hDLN2, (byte) 0, ref nSlaveCount, ref pList);
          if (nSlaveCount != (byte) 0)
            return (int) (DiolanU2C.addrSlave = pList.List[(int) nSlaveCount - 1]);
          DiolanU2C.DLN2Close();
          return 0;
        }
        Thread.Sleep(500);
        try
        {
          Process process = new Process()
          {
            StartInfo = new ProcessStartInfo("devcon.exe")
          };
          process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
          process.StartInfo.Arguments = "rescan";
          process.Start();
          process.WaitForExit();
          Thread.Sleep(100);
          Debug.WriteLine("rescan [" + index.ToString() + "] " + (object) sn);
        }
        catch (Exception ex)
        {
          Debug.WriteLine("devcon: " + ex.Message);
          return 0;
        }
      }
      return 0;
    }

    public static int DLN2InitDell(ulong sn)
    {
      if (DiolanU2C.sm_EepromTypes == null)
      {
        DiolanU2C.sm_EepromTypes = new DiolanU2C.EepromTypes[12];
        DiolanU2C.sm_EepromTypes[0] = new DiolanU2C.EepromTypes("ATMEL AT24C01", 128U, (ushort) 4, (byte) 1, (byte) 7);
        DiolanU2C.sm_EepromTypes[1] = new DiolanU2C.EepromTypes("ATMEL AT24C02", 256U, (ushort) 8, (byte) 1, (byte) 8);
        DiolanU2C.sm_EepromTypes[2] = new DiolanU2C.EepromTypes("ATMEL AT24C04", 512U, (ushort) 16, (byte) 1, (byte) 9);
        DiolanU2C.sm_EepromTypes[3] = new DiolanU2C.EepromTypes("ATMEL AT24C08", 1024U, (ushort) 16, (byte) 1, (byte) 10);
        DiolanU2C.sm_EepromTypes[4] = new DiolanU2C.EepromTypes("ATMEL AT24C16", 2048U, (ushort) 16, (byte) 1, (byte) 11);
        DiolanU2C.sm_EepromTypes[5] = new DiolanU2C.EepromTypes("ATMEL AT24C32", 4096U, (ushort) 32, (byte) 2, (byte) 12);
        DiolanU2C.sm_EepromTypes[6] = new DiolanU2C.EepromTypes("ATMEL AT24C64", 8192U, (ushort) 32, (byte) 2, (byte) 13);
        DiolanU2C.sm_EepromTypes[7] = new DiolanU2C.EepromTypes("ATMEL AT24C128", 16384U, (ushort) 64, (byte) 2, (byte) 14);
        DiolanU2C.sm_EepromTypes[8] = new DiolanU2C.EepromTypes("ATMEL AT24C256", 32768U, (ushort) 64, (byte) 2, (byte) 15);
        DiolanU2C.sm_EepromTypes[9] = new DiolanU2C.EepromTypes("ATMEL AT24C512", 65536U, (ushort) 128, (byte) 2, (byte) 16);
        DiolanU2C.sm_EepromTypes[10] = new DiolanU2C.EepromTypes("ATMEL AT24C1024", 131072U, (ushort) 256, (byte) 2, (byte) 17);
        DiolanU2C.sm_EepromTypes[11] = new DiolanU2C.EepromTypes("ATMEL ATTINY84", 4096U, (ushort) 16, (byte) 2, (byte) 16);
      }
      for (int index = 0; index < 3; ++index)
      {
        uint num = DiolanU2C.DlnOpenDeviceBySn((uint) sn, ref DiolanU2C.hDLN2);
        if (DiolanU2C.hDLN2 < (ushort) 1)
          return 0;
        byte nPortCount = 0;
        num = DiolanU2C.DlnI2cMasterGetPortCount(DiolanU2C.hDLN2, ref nPortCount);
        if (nPortCount < (byte) 1)
          return 0;
        byte bEnabled = 0;
        num = DiolanU2C.DlnI2cMasterIsEnabled(DiolanU2C.hDLN2, (byte) 0, ref bEnabled);
        if (bEnabled == (byte) 0)
        {
          ushort nConflict = 0;
          num = DiolanU2C.DlnI2cMasterEnable(DiolanU2C.hDLN2, 0U, ref nConflict);
          num = DiolanU2C.DlnI2cMasterIsEnabled(DiolanU2C.hDLN2, (byte) 0, ref bEnabled);
        }
        if (bEnabled == (byte) 1)
          return 1;
        Thread.Sleep(500);
        try
        {
          Process process = new Process()
          {
            StartInfo = new ProcessStartInfo("devcon.exe")
          };
          process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
          process.StartInfo.Arguments = "rescan";
          process.Start();
          process.WaitForExit();
          Thread.Sleep(100);
          Debug.WriteLine("rescan [" + index.ToString() + "] " + (object) sn);
        }
        catch (Exception ex)
        {
          Debug.WriteLine("devcon: " + ex.Message);
          return 0;
        }
      }
      return 0;
    }

    public static int DiolanInit(ulong sn)
    {
      if (DiolanU2C.sm_EepromTypes == null)
      {
        DiolanU2C.sm_EepromTypes = new DiolanU2C.EepromTypes[12];
        DiolanU2C.sm_EepromTypes[0] = new DiolanU2C.EepromTypes("ATMEL AT24C01", 128U, (ushort) 4, (byte) 1, (byte) 7);
        DiolanU2C.sm_EepromTypes[1] = new DiolanU2C.EepromTypes("ATMEL AT24C02", 256U, (ushort) 8, (byte) 1, (byte) 8);
        DiolanU2C.sm_EepromTypes[2] = new DiolanU2C.EepromTypes("ATMEL AT24C04", 512U, (ushort) 16, (byte) 1, (byte) 9);
        DiolanU2C.sm_EepromTypes[3] = new DiolanU2C.EepromTypes("ATMEL AT24C08", 1024U, (ushort) 16, (byte) 1, (byte) 10);
        DiolanU2C.sm_EepromTypes[4] = new DiolanU2C.EepromTypes("ATMEL AT24C16", 2048U, (ushort) 16, (byte) 1, (byte) 11);
        DiolanU2C.sm_EepromTypes[5] = new DiolanU2C.EepromTypes("ATMEL AT24C32", 4096U, (ushort) 32, (byte) 2, (byte) 12);
        DiolanU2C.sm_EepromTypes[6] = new DiolanU2C.EepromTypes("ATMEL AT24C64", 8192U, (ushort) 32, (byte) 2, (byte) 13);
        DiolanU2C.sm_EepromTypes[7] = new DiolanU2C.EepromTypes("ATMEL AT24C128", 16384U, (ushort) 64, (byte) 2, (byte) 14);
        DiolanU2C.sm_EepromTypes[8] = new DiolanU2C.EepromTypes("ATMEL AT24C256", 32768U, (ushort) 64, (byte) 2, (byte) 15);
        DiolanU2C.sm_EepromTypes[9] = new DiolanU2C.EepromTypes("ATMEL AT24C512", 65536U, (ushort) 128, (byte) 2, (byte) 16);
        DiolanU2C.sm_EepromTypes[10] = new DiolanU2C.EepromTypes("ATMEL AT24C1024", 131072U, (ushort) 256, (byte) 2, (byte) 17);
        DiolanU2C.sm_EepromTypes[11] = new DiolanU2C.EepromTypes("ATMEL ATTINY84", 4096U, (ushort) 16, (byte) 2, (byte) 16);
      }
      for (int index = 0; index < 3; ++index)
      {
        DiolanU2C.hDiolan = DiolanU2C.U2C_OpenDeviceBySerialNum(sn);
        if (DiolanU2C.U2C_IsHandleValid(DiolanU2C.hDiolan) == 0)
        {
          DiolanU2C.U2C_SLAVE_ADDR_LIST pList = new DiolanU2C.U2C_SLAVE_ADDR_LIST();
          if (DiolanU2C.U2C_ScanDevices(DiolanU2C.hDiolan, ref pList) == 0)
          {
            if (pList.nDeviceNumber != (byte) 0)
              return (int) (DiolanU2C.addrSlave = pList.List[(int) pList.nDeviceNumber - 1]);
            DiolanU2C.U2C_CloseDevice(DiolanU2C.hDiolan);
            return 0;
          }
        }
        Thread.Sleep(500);
        try
        {
          Process process = new Process()
          {
            StartInfo = new ProcessStartInfo("devcon.exe")
          };
          process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
          process.StartInfo.Arguments = "rescan";
          process.Start();
          process.WaitForExit();
          Thread.Sleep(100);
          Debug.WriteLine("rescan [" + index.ToString() + "] " + (object) sn);
        }
        catch (Exception ex)
        {
          Debug.WriteLine("devcon: " + ex.Message);
          return 0;
        }
      }
      return 0;
    }

    private static bool prDLN2SetAddress(ref DiolanU2C.DLN2_TRANSACTION Transaction, int Addr)
    {
      if ((long) Addr > (long) DiolanU2C.sm_EepromTypes[DiolanU2C.m_Subtype].m_Size)
        return false;
      Transaction.nMemoryAddressLength = DiolanU2C.sm_EepromTypes[DiolanU2C.m_Subtype].m_AddrByteNum;
      int num = (int) DiolanU2C.sm_EepromTypes[DiolanU2C.m_Subtype].m_AddrByteNum * 8;
      if ((int) DiolanU2C.sm_EepromTypes[DiolanU2C.m_Subtype].m_AddrBitNum <= num)
      {
        Transaction.nSlaveDeviceAddress = DiolanU2C.addrSlave;
        byte[] bytes = BitConverter.GetBytes(Addr);
        Transaction.nMemoryAddress = (uint) ((int) bytes[3] << 24 | (int) bytes[2] << 16 | (int) bytes[1] << 8) | (uint) bytes[0];
      }
      return true;
    }

    private static bool prSetAddress(ref DiolanU2C.U2C_TRANSACTION Transaction, int Addr)
    {
      if ((long) Addr > (long) DiolanU2C.sm_EepromTypes[DiolanU2C.m_Subtype].m_Size)
        return false;
      Transaction.nMemoryAddressLength = DiolanU2C.sm_EepromTypes[DiolanU2C.m_Subtype].m_AddrByteNum;
      int num = (int) DiolanU2C.sm_EepromTypes[DiolanU2C.m_Subtype].m_AddrByteNum * 8;
      if ((int) DiolanU2C.sm_EepromTypes[DiolanU2C.m_Subtype].m_AddrBitNum <= num)
      {
        Transaction.nSlaveDeviceAddress = DiolanU2C.addrSlave;
        byte[] bytes = BitConverter.GetBytes(Addr);
        Transaction.nMemoryAddress.b0 = bytes[3];
        Transaction.nMemoryAddress.b1 = bytes[2];
        Transaction.nMemoryAddress.b2 = bytes[1];
        Transaction.nMemoryAddress.b3 = bytes[0];
      }
      return true;
    }

    public static bool DLN2Read(
      byte slaveaddr,
      string device,
      byte[] tbuffer,
      byte nMemoryAddressLength)
    {
      DiolanU2C.addrSlave = slaveaddr;
      return DiolanU2C.DLN2Read(device, tbuffer, nMemoryAddressLength);
    }

    public static bool DLN2Read(string device, byte[] tbuffer, byte nMemoryAddressLength)
    {
      DiolanU2C.m_Subtype = -1;
      for (int index = 0; index < DiolanU2C.sm_EepromTypes.Length; ++index)
      {
        if (DiolanU2C.sm_EepromTypes[index].m_Name == device.ToUpper())
        {
          DiolanU2C.m_Subtype = index;
          break;
        }
      }
      if (DiolanU2C.m_Subtype == -1)
        return false;
      DiolanU2C.DLN2_TRANSACTION Transaction = new DiolanU2C.DLN2_TRANSACTION();
      Transaction.Buffer = new byte[256];
      Transaction.nSlaveDeviceAddress = DiolanU2C.addrSlave;
      Transaction.nMemoryAddressLength = nMemoryAddressLength;
      ushort num;
      for (int index = 0; index < tbuffer.Length; index += (int) num)
      {
        if (nMemoryAddressLength == (byte) 1)
        {
          byte[] bytes = BitConverter.GetBytes(index);
          Transaction.nMemoryAddress = (uint) ((int) bytes[3] << 24 | (int) bytes[2] << 16 | (int) bytes[1] << 8) | (uint) bytes[0];
        }
        num = DiolanU2C.sm_EepromTypes[DiolanU2C.m_Subtype].m_PageSize;
        if (index + (int) num > tbuffer.Length)
          num = (ushort) (tbuffer.Length - index);
        Transaction.nBufferLength = (ushort) ((uint) num & (uint) byte.MaxValue);
        DiolanU2C.prDLN2SetAddress(ref Transaction, index);
        DiolanU2C.DlnI2cMasterRead(DiolanU2C.hDLN2, 0U, Transaction.nSlaveDeviceAddress, Transaction.nMemoryAddressLength, Transaction.nMemoryAddress, Transaction.nBufferLength, Transaction.Buffer);
        if (index <= tbuffer.Length - (int) num)
          Array.Copy((Array) Transaction.Buffer, 0, (Array) tbuffer, index, (int) num);
        else
          Array.Copy((Array) Transaction.Buffer, 0, (Array) tbuffer, index, tbuffer.Length - index);
      }
      return true;
    }

    public static bool DLN2ReadByte(byte slaveaddr, int addr, byte[] tBuffer, byte addrmode)
    {
      DiolanU2C.DLN2_TRANSACTION dlN2Transaction = new DiolanU2C.DLN2_TRANSACTION();
      dlN2Transaction.Buffer = new byte[1];
      ushort num = 1;
      dlN2Transaction.nBufferLength = num;
      dlN2Transaction.nSlaveDeviceAddress = slaveaddr;
      dlN2Transaction.nMemoryAddressLength = addrmode;
      byte[] bytes = BitConverter.GetBytes(addr);
      dlN2Transaction.nMemoryAddress = (uint) ((int) bytes[3] << 24 | (int) bytes[2] << 16 | (int) bytes[1] << 8) | (uint) bytes[0];
      DiolanU2C.DlnI2cMasterRead(DiolanU2C.hDLN2, 0U, dlN2Transaction.nSlaveDeviceAddress, dlN2Transaction.nMemoryAddressLength, dlN2Transaction.nMemoryAddress, dlN2Transaction.nBufferLength, dlN2Transaction.Buffer);
      tBuffer[0] = dlN2Transaction.Buffer[0];
      Thread.Sleep(30);
      return true;
    }

    public static bool DiolanRead(byte slaveaddr, string device, byte[] tbuffer)
    {
      DiolanU2C.addrSlave = slaveaddr;
      return DiolanU2C.DiolanRead(device, tbuffer);
    }

    public static bool DiolanRead(string device, byte[] tbuffer)
    {
      DiolanU2C.m_Subtype = -1;
      for (int index = 0; index < DiolanU2C.sm_EepromTypes.Length; ++index)
      {
        if (DiolanU2C.sm_EepromTypes[index].m_Name == device.ToUpper())
        {
          DiolanU2C.m_Subtype = index;
          break;
        }
      }
      if (DiolanU2C.m_Subtype == -1)
        return false;
      int num1 = 0;
      num1 = DiolanU2C.U2C_SetI2cFreq(DiolanU2C.hDiolan, (byte) 1);
      DiolanU2C.U2C_TRANSACTION u2CTransaction = new DiolanU2C.U2C_TRANSACTION();
      u2CTransaction.Buffer = new byte[256];
      u2CTransaction.nSlaveDeviceAddress = DiolanU2C.addrSlave;
      u2CTransaction.nMemoryAddressLength = (byte) 2;
      ushort num2;
      for (int index = 0; index < tbuffer.Length; index += (int) num2)
      {
        num2 = DiolanU2C.sm_EepromTypes[DiolanU2C.m_Subtype].m_PageSize;
        if (index + (int) num2 > tbuffer.Length)
          num2 = (ushort) (tbuffer.Length - index);
        u2CTransaction.nBufferLength.bLo = (byte) num2;
        DiolanU2C.prSetAddress(ref u2CTransaction, index);
        if (DiolanU2C.U2C_Read(DiolanU2C.hDiolan, ref u2CTransaction) != 0)
          return false;
        if (index <= tbuffer.Length - (int) num2)
          Array.Copy((Array) u2CTransaction.Buffer, 0, (Array) tbuffer, index, (int) num2);
        else
          Array.Copy((Array) u2CTransaction.Buffer, 0, (Array) tbuffer, index, tbuffer.Length - index);
      }
      return true;
    }

    public static bool DLN2Write(
      byte slaveaddr,
      string device,
      byte[] tbuffer,
      byte nMemoryAddrLength)
    {
      DiolanU2C.addrSlave = slaveaddr;
      return DiolanU2C.DLN2Write(device, tbuffer, nMemoryAddrLength);
    }

    public static bool DLN2Write(string device, byte[] tbuffer, byte nMemoryAddrLength)
    {
      DiolanU2C.m_Subtype = -1;
      for (int index = 0; index < DiolanU2C.sm_EepromTypes.Length; ++index)
      {
        if (DiolanU2C.sm_EepromTypes[index].m_Name == device.ToUpper())
        {
          DiolanU2C.m_Subtype = index;
          break;
        }
      }
      if (DiolanU2C.m_Subtype == -1)
        return false;
      DiolanU2C.DLN2_TRANSACTION Transaction = new DiolanU2C.DLN2_TRANSACTION();
      Transaction.Buffer = new byte[256];
      Transaction.nSlaveDeviceAddress = DiolanU2C.addrSlave;
      Transaction.nMemoryAddressLength = nMemoryAddrLength;
      ushort num;
      for (int index = 0; index < tbuffer.Length; index += (int) num)
      {
        if (nMemoryAddrLength == (byte) 1)
        {
          byte[] bytes = BitConverter.GetBytes(index);
          Transaction.nMemoryAddress = (uint) ((int) bytes[3] << 24 | (int) bytes[2] << 16 | (int) bytes[1] << 8) | (uint) bytes[0];
        }
        num = DiolanU2C.sm_EepromTypes[DiolanU2C.m_Subtype].m_PageSize;
        if (index + (int) num > tbuffer.Length)
          num = (ushort) (tbuffer.Length - index);
        Transaction.nBufferLength = (ushort) ((uint) num & (uint) byte.MaxValue);
        DiolanU2C.prDLN2SetAddress(ref Transaction, index);
        if (index <= tbuffer.Length - (int) num)
          Array.Copy((Array) tbuffer, index, (Array) Transaction.Buffer, 0, (int) num);
        else
          Array.Copy((Array) tbuffer, index, (Array) Transaction.Buffer, 0, tbuffer.Length - index);
        DiolanU2C.DlnI2cMasterWrite(DiolanU2C.hDLN2, 0U, Transaction.nSlaveDeviceAddress, Transaction.nMemoryAddressLength, Transaction.nMemoryAddress, Transaction.nBufferLength, Transaction.Buffer);
        Thread.Sleep(30);
      }
      return true;
    }

    public static bool DLN2WriteByte(byte slaveaddr, int addr, byte val, byte addrmode)
    {
      DiolanU2C.DLN2_TRANSACTION dlN2Transaction = new DiolanU2C.DLN2_TRANSACTION();
      dlN2Transaction.Buffer = new byte[256];
      dlN2Transaction.Buffer[0] = val;
      ushort num = 1;
      dlN2Transaction.nBufferLength = num;
      dlN2Transaction.nSlaveDeviceAddress = slaveaddr;
      dlN2Transaction.nMemoryAddressLength = addrmode;
      byte[] bytes = BitConverter.GetBytes(addr);
      dlN2Transaction.nMemoryAddress = (uint) ((int) bytes[3] << 24 | (int) bytes[2] << 16 | (int) bytes[1] << 8) | (uint) bytes[0];
      DiolanU2C.DlnI2cMasterWrite(DiolanU2C.hDLN2, 0U, dlN2Transaction.nSlaveDeviceAddress, dlN2Transaction.nMemoryAddressLength, dlN2Transaction.nMemoryAddress, dlN2Transaction.nBufferLength, dlN2Transaction.Buffer);
      Thread.Sleep(30);
      return true;
    }

    public static bool DiolanWrite(byte slaveaddr, string device, byte[] tbuffer)
    {
      DiolanU2C.addrSlave = slaveaddr;
      return DiolanU2C.DiolanWrite(device, tbuffer);
    }

    public static bool DiolanWrite(string device, byte[] tbuffer)
    {
      DiolanU2C.m_Subtype = -1;
      for (int index = 0; index < DiolanU2C.sm_EepromTypes.Length; ++index)
      {
        if (DiolanU2C.sm_EepromTypes[index].m_Name == device.ToUpper())
        {
          DiolanU2C.m_Subtype = index;
          break;
        }
      }
      if (DiolanU2C.m_Subtype == -1)
        return false;
      int num1 = 0;
      num1 = DiolanU2C.U2C_SetI2cFreq(DiolanU2C.hDiolan, (byte) 1);
      DiolanU2C.U2C_TRANSACTION u2CTransaction = new DiolanU2C.U2C_TRANSACTION();
      u2CTransaction.Buffer = new byte[256];
      u2CTransaction.nSlaveDeviceAddress = DiolanU2C.addrSlave;
      u2CTransaction.nMemoryAddressLength = (byte) 2;
      ushort num2;
      for (int index = 0; index < tbuffer.Length; index += (int) num2)
      {
        num2 = DiolanU2C.sm_EepromTypes[DiolanU2C.m_Subtype].m_PageSize;
        if (index + (int) num2 > tbuffer.Length)
          num2 = (ushort) (tbuffer.Length - index);
        u2CTransaction.nBufferLength.bLo = (byte) num2;
        DiolanU2C.prSetAddress(ref u2CTransaction, index);
        if (index <= tbuffer.Length - (int) num2)
          Array.Copy((Array) tbuffer, index, (Array) u2CTransaction.Buffer, 0, (int) num2);
        else
          Array.Copy((Array) tbuffer, index, (Array) u2CTransaction.Buffer, 0, tbuffer.Length - index);
        if (DiolanU2C.U2C_Write(DiolanU2C.hDiolan, ref u2CTransaction) != 0)
          return false;
        Thread.Sleep(30);
      }
      return true;
    }

    public static bool DiolanWriteByte(byte slaveaddr, int addr, byte val)
    {
      int num = 0;
      num = DiolanU2C.U2C_SetI2cFreq(DiolanU2C.hDiolan, (byte) 1);
      DiolanU2C.U2C_TRANSACTION pTransaction = new DiolanU2C.U2C_TRANSACTION();
      pTransaction.Buffer = new byte[256];
      pTransaction.Buffer[0] = val;
      DiolanU2C.U2C_WORD u2CWord;
      u2CWord.bHi = (byte) 0;
      u2CWord.bLo = (byte) 1;
      pTransaction.nBufferLength = u2CWord;
      pTransaction.nSlaveDeviceAddress = slaveaddr;
      pTransaction.nMemoryAddressLength = (byte) 1;
      byte[] bytes = BitConverter.GetBytes(addr);
      pTransaction.nMemoryAddress.b0 = bytes[3];
      pTransaction.nMemoryAddress.b1 = bytes[2];
      pTransaction.nMemoryAddress.b2 = bytes[1];
      pTransaction.nMemoryAddress.b3 = bytes[0];
      if (DiolanU2C.U2C_Write(DiolanU2C.hDiolan, ref pTransaction) != 0)
        return false;
      Thread.Sleep(30);
      return true;
    }

    public static void DLN2Disconnect()
    {
      int num = (int) DiolanU2C.DlnDisconnect("localhost", (ushort) 9656);
    }

    public static void DLN2Close()
    {
      int num1 = (int) DiolanU2C.DlnI2cMasterDisable(DiolanU2C.hDLN2, (byte) 0, 1U);
      int num2 = (int) DiolanU2C.DlnCloseHandle(DiolanU2C.hDLN2);
    }

    public static void DiolanClose()
    {
      DiolanU2C.U2C_CloseDevice(DiolanU2C.hDiolan);
    }

    private struct EepromTypes
    {
      public string m_Name;
      public uint m_Size;
      public ushort m_PageSize;
      public byte m_AddrByteNum;
      public byte m_AddrBitNum;

      public EepromTypes(string name, uint size, ushort pagesize, byte addrbyte, byte addrbit)
      {
        this.m_Name = name;
        this.m_Size = size;
        this.m_PageSize = pagesize;
        this.m_AddrByteNum = addrbyte;
        this.m_AddrBitNum = addrbit;
      }
    }

    private struct DLN2_SLAVE_ADDR_LIST
    {
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
      public byte[] List;
    }

    private struct U2C_SLAVE_ADDR_LIST
    {
      public byte nDeviceNumber;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
      public byte[] List;
    }

    private struct U2C_VERSION_INFO
    {
      public ushort MajorVersion;
      public ushort MinorVersion;
    }

    private struct U2C_WORD
    {
      public byte bLo;
      public byte bHi;
    }

    private struct U2C_LONG
    {
      public byte b3;
      public byte b2;
      public byte b1;
      public byte b0;
    }

    private struct U2C_TRANSACTION
    {
      public byte nSlaveDeviceAddress;
      public byte nMemoryAddressLength;
      public DiolanU2C.U2C_LONG nMemoryAddress;
      public DiolanU2C.U2C_WORD nBufferLength;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
      public byte[] Buffer;
    }

    private struct DLN2_TRANSACTION
    {
      public byte nSlaveDeviceAddress;
      public byte nMemoryAddressLength;
      public uint nMemoryAddress;
      public ushort nBufferLength;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
      public byte[] Buffer;
    }
  }
}
