// Decompiled with JetBrains decompiler
// Type: Util.FileUtil
// Assembly: soteDiag, Version=3.2.3.9, Culture=neutral, PublicKeyToken=null
// MVID: 64B98F7C-FFB0-44BA-B97E-997AD765B8FF
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteDiag.exe

using System;
using System.IO;
using System.Windows.Forms;

namespace Util
{
  internal class FileUtil
  {
    public static byte[] ReadBinaryFile(string path)
    {
      FileStream fileStream = File.OpenRead(path);
      BinaryReader binaryReader = new BinaryReader((Stream) fileStream);
      byte[] buffer;
      try
      {
        buffer = new byte[fileStream.Length];
        binaryReader.Read(buffer, 0, (int) fileStream.Length);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
        return (byte[]) null;
      }
      finally
      {
        binaryReader.Close();
        fileStream.Close();
      }
      return buffer;
    }

    public static void WriteBinaryFile(byte[] buffer, string path)
    {
      FileStream fileStream = File.Create(path);
      BinaryWriter binaryWriter = new BinaryWriter((Stream) fileStream);
      try
      {
        binaryWriter.Write(buffer);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.Message);
      }
      finally
      {
        binaryWriter.Close();
        fileStream.Close();
      }
    }

    public static void WriteCsvFile(
      string column1,
      string column2,
      string column3,
      string column4,
      string path)
    {
      try
      {
        StreamWriter streamWriter = new StreamWriter(path, true);
        streamWriter.WriteLine(column1 + "," + column2 + "," + column3 + "," + column4);
        streamWriter.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    public static void WriteCsvFile(
      int column1,
      string column2,
      string column3,
      int column4,
      string path)
    {
      try
      {
        StreamWriter streamWriter = new StreamWriter(path, true);
        streamWriter.WriteLine(column1.ToString() + "," + column2 + "," + column3 + "," + (object) column4);
        streamWriter.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    public static void WriteCsvFile(
      int column1,
      string column2,
      int column3,
      int column4,
      string path)
    {
      try
      {
        StreamWriter streamWriter = new StreamWriter(path, true);
        streamWriter.WriteLine(column1.ToString() + "," + column2 + "," + (object) column3 + "," + (object) column4);
        streamWriter.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    public static void WriteCsvFile(
      int column1,
      string column2,
      string column3,
      string column4,
      string path)
    {
      try
      {
        StreamWriter streamWriter = new StreamWriter(path, true);
        streamWriter.WriteLine(column1.ToString() + "," + column2 + "," + column3 + "," + column4);
        streamWriter.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }

    public static void WriteCsvFile(
      int column1,
      string column2,
      int column3,
      string column4,
      string path)
    {
      try
      {
        StreamWriter streamWriter = new StreamWriter(path, true);
        streamWriter.WriteLine(column1.ToString() + "," + column2 + "," + (object) column3 + "," + column4);
        streamWriter.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
