// Decompiled with JetBrains decompiler
// Type: Util.Constant
// Assembly: soteDiag, Version=3.2.3.9, Culture=neutral, PublicKeyToken=null
// MVID: 64B98F7C-FFB0-44BA-B97E-997AD765B8FF
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteDiag.exe

using System;
using System.Collections.Generic;
using System.IO;

namespace Util
{
  public static class Constant
  {
    public static Dictionary<string, int> MemorySizeList = new Dictionary<string, int>();
    public static string AppLocation = Path.GetDirectoryName(typeof (Constant).Assembly.Location) + "\\";
    public static string AppLocationDir = AppDomain.CurrentDomain.BaseDirectory;
    public static string devInfoFile = Constant.AppLocation + "Default\\DeviceInformation.xml";

    static Constant()
    {
      Constant.MemorySizeList["1K"] = 128;
      Constant.MemorySizeList["2K"] = 256;
      Constant.MemorySizeList["4K"] = 512;
      Constant.MemorySizeList["8K"] = 1024;
      Constant.MemorySizeList["16K"] = 2048;
      Constant.MemorySizeList["32K"] = 4096;
      Constant.MemorySizeList["64K"] = 8192;
      Constant.MemorySizeList["128K"] = 16384;
      Constant.MemorySizeList["256K"] = 32768;
      Constant.MemorySizeList["512K"] = 65536;
      Constant.MemorySizeList["1024K"] = 131072;
    }
  }
}
