// Decompiled with JetBrains decompiler
// Type: soteLib.IniFile
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System.Runtime.InteropServices;
using System.Text;

namespace soteLib
{
  public class IniFile
  {
    private static string _FileName = "";

    [DllImport("kernel32", SetLastError = true)]
    private static extern long WritePrivateProfileString(
      string sectionName,
      string keyName,
      string keyValue,
      string filename);

    [DllImport("kernel32", SetLastError = true)]
    private static extern int GetPrivateProfileString(
      string sectionName,
      string keyName,
      string defaultValue,
      StringBuilder retVal,
      int size,
      string filename);

    [DllImport("kernel32", SetLastError = true)]
    private static extern long WritePrivateProfileSection(
      string sectionName,
      string keyValues,
      string filename);

    public static string FileName
    {
      get
      {
        return IniFile._FileName;
      }
      set
      {
        IniFile._FileName = value;
      }
    }

    public static string GetProfile(string section, string key)
    {
      StringBuilder retVal = new StringBuilder(500);
      IniFile.GetPrivateProfileString(section, key, "", retVal, 500, IniFile._FileName);
      return retVal.ToString();
    }

    public static string GetProfile(string section, string key, string value)
    {
      StringBuilder retVal = new StringBuilder(500);
      IniFile.GetPrivateProfileString(section, key, value, retVal, 500, IniFile._FileName);
      return retVal.ToString();
    }

    public static void SaveProfile(string section, string key, string value)
    {
      IniFile.WritePrivateProfileString(section, key, value, IniFile._FileName);
    }
  }
}
