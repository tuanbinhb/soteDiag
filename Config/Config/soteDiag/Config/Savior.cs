// Decompiled with JetBrains decompiler
// Type: soteDiag.Config.Savior
// Assembly: Config, Version=3.2.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 981CD5E2-C1D2-448D-8326-C60FCE8CDD63
// Assembly location: E:\Test_Program\F57416M4160C\FT1\Config.dll

using Microsoft.Win32;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace soteDiag.Config
{
  public class Savior
  {
    public static string ToString(object settings)
    {
      string str1 = (string) null;
      foreach (FieldInfo field in settings.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
      {
        string str2 = (string) null;
        if (field.GetValue(settings) != null)
          str2 = field.GetValue(settings).ToString();
        str1 = str1 + "Name: " + field.Name + " = " + str2 + "\n    FieldType: " + (object) field.FieldType + "\n\n";
      }
      return str1;
    }

    public static void Save(object settings, RegistryKey Key)
    {
      foreach (FieldInfo field in settings.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
      {
        if (field.FieldType.IsEnum)
        {
          Key.SetValue(field.Name, (object) Enum.GetName(field.FieldType, field.GetValue(settings)));
        }
        else
        {
          switch (field.FieldType.Name.ToLower())
          {
            case "string":
              Key.SetValue(field.Name, (object) (string) field.GetValue(settings));
              break;
            case "boolean":
              Key.SetValue(field.Name, (object) (bool) field.GetValue(settings));
              break;
            case "int32":
              Key.SetValue(field.Name, (object) (int) field.GetValue(settings));
              break;
            case "decimal":
              Decimal num1 = (Decimal) field.GetValue(settings);
              Key.SetValue(field.Name, (object) (int) num1);
              break;
            case "single":
              Key.SetValue(field.Name, (object) (float) field.GetValue(settings));
              break;
            case "double":
              Key.SetValue(field.Name, (object) (double) field.GetValue(settings));
              break;
            case "point":
              Point point = (Point) field.GetValue(settings);
              Key.SetValue(field.Name + ".X", (object) point.X);
              Key.SetValue(field.Name + ".Y", (object) point.Y);
              break;
            case "size":
              Size size = (Size) field.GetValue(settings);
              Key.SetValue(field.Name + ".Height", (object) size.Height);
              Key.SetValue(field.Name + ".Width", (object) size.Width);
              break;
            case "byte[]":
              byte[] numArray1 = (byte[]) field.GetValue(settings);
              if (numArray1 != null)
              {
                Key.SetValue(field.Name, (object) numArray1);
                break;
              }
              break;
            case "string[]":
              string[] strArray = (string[]) field.GetValue(settings);
              if (strArray != null)
              {
                Key.SetValue(field.Name, (object) strArray);
                break;
              }
              break;
            case "int32[]":
              int[] numArray2 = (int[]) field.GetValue(settings);
              if (numArray2 != null)
              {
                Key.DeleteSubKey(field.Name, false);
                RegistryKey subKey = Key.CreateSubKey(field.Name);
                for (int index = 0; index < numArray2.Length; ++index)
                  subKey.SetValue(index.ToString(), (object) numArray2[index]);
                break;
              }
              break;
            case "boolean[]":
              bool[] flagArray = (bool[]) field.GetValue(settings);
              if (flagArray != null)
              {
                Key.DeleteSubKey(field.Name, false);
                RegistryKey subKey = Key.CreateSubKey(field.Name);
                for (int index = 0; index < flagArray.Length; ++index)
                  subKey.SetValue(index.ToString(), (object) flagArray[index]);
                break;
              }
              break;
            case "single[]":
              float[] numArray3 = (float[]) field.GetValue(settings);
              if (numArray3 != null)
              {
                Key.DeleteSubKey(field.Name, false);
                RegistryKey subKey = Key.CreateSubKey(field.Name);
                for (int index = 0; index < numArray3.Length; ++index)
                  subKey.SetValue(index.ToString(), (object) numArray3[index]);
                break;
              }
              break;
            case "double[]":
              double[] numArray4 = (double[]) field.GetValue(settings);
              if (numArray4 != null)
              {
                Key.DeleteSubKey(field.Name, false);
                RegistryKey subKey = Key.CreateSubKey(field.Name);
                for (int index = 0; index < numArray4.Length; ++index)
                  subKey.SetValue(index.ToString(), (object) numArray4[index]);
                break;
              }
              break;
            case "color":
              Key.SetValue(field.Name, (object) ((System.Drawing.Color) field.GetValue(settings)).Name);
              break;
            case "timespan":
              Key.SetValue(field.Name, (object) ((TimeSpan) field.GetValue(settings)).ToString());
              break;
            case "datetime":
              Key.SetValue(field.Name, (object) ((DateTime) field.GetValue(settings)).ToString());
              break;
            case "font":
              Key.SetValue(field.Name + ".Name", (object) ((Font) field.GetValue(settings)).Name);
              Key.SetValue(field.Name + ".Size", (object) ((Font) field.GetValue(settings)).Size);
              Key.SetValue(field.Name + ".Style", (object) ((Font) field.GetValue(settings)).Style);
              break;
            default:
              int num2 = (int) MessageBox.Show("This Field type cannot be saved by the Savior class: " + (object) field.FieldType);
              break;
          }
        }
      }
    }

    public static void Save(object settings, string key)
    {
      RegistryKey subKey = Registry.CurrentUser.CreateSubKey(key);
      Savior.Save(settings, subKey);
    }

    public static void Save(object settings)
    {
      RegistryKey userAppDataRegistry = Application.UserAppDataRegistry;
      Savior.Save(settings, userAppDataRegistry);
    }

    public static void Read(object settings, RegistryKey Key)
    {
      int index;
      foreach (FieldInfo field in settings.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
      {
        if (field.FieldType.IsEnum)
        {
          object obj;
          if ((obj = Key.GetValue(field.Name)) != null)
            field.SetValue(settings, Enum.Parse(field.FieldType, (string) obj));
        }
        else
        {
          switch (field.FieldType.Name.ToLower())
          {
            case "string":
              object obj1;
              if ((obj1 = Key.GetValue(field.Name)) != null)
              {
                field.SetValue(settings, (object) (string) obj1);
                break;
              }
              break;
            case "boolean":
              object obj2;
              if ((obj2 = Key.GetValue(field.Name)) != null)
              {
                field.SetValue(settings, (object) bool.Parse((string) obj2));
                break;
              }
              break;
            case "int32":
              object obj3;
              if ((obj3 = Key.GetValue(field.Name)) != null)
              {
                field.SetValue(settings, (object) (int) obj3);
                break;
              }
              break;
            case "decimal":
              object obj4;
              if ((obj4 = Key.GetValue(field.Name)) != null)
              {
                int num = (int) obj4;
                field.SetValue(settings, (object) (Decimal) num);
                break;
              }
              break;
            case "single":
              object obj5;
              if ((obj5 = Key.GetValue(field.Name)) != null)
              {
                field.SetValue(settings, (object) float.Parse((string) obj5));
                break;
              }
              break;
            case "double":
              object obj6;
              if ((obj6 = Key.GetValue(field.Name)) != null)
              {
                field.SetValue(settings, (object) double.Parse((string) obj6));
                break;
              }
              break;
            case "point":
              object obj7;
              if ((obj7 = Key.GetValue(field.Name + ".X")) != null)
              {
                int x = (int) obj7;
                object obj8;
                if ((obj8 = Key.GetValue(field.Name + ".Y")) != null)
                {
                  int y = (int) obj8;
                  field.SetValue(settings, (object) new Point(x, y));
                }
                break;
              }
              break;
            case "size":
              object obj9;
              if ((obj9 = Key.GetValue(field.Name + ".Height")) != null)
              {
                int height = (int) obj9;
                object obj8;
                if ((obj8 = Key.GetValue(field.Name + ".Width")) != null)
                {
                  int width = (int) obj8;
                  field.SetValue(settings, (object) new Size(width, height));
                }
                break;
              }
              break;
            case "string[]":
              object obj10;
              if ((obj10 = Key.GetValue(field.Name)) != null)
              {
                field.SetValue(settings, (object) (string[]) obj10);
                break;
              }
              break;
            case "byte[]":
              object obj11;
              if ((obj11 = Key.GetValue(field.Name)) != null)
              {
                field.SetValue(settings, (object) (byte[]) obj11);
                break;
              }
              break;
            case "int32[]":
              RegistryKey registryKey1;
              if ((registryKey1 = Key.OpenSubKey(field.Name)) != null)
              {
                index = 0;
                int[] numArray = new int[registryKey1.ValueCount];
                object obj8;
                while ((obj8 = registryKey1.GetValue(index.ToString())) != null)
                  numArray[index++] = (int) obj8;
                field.SetValue(settings, (object) numArray);
                break;
              }
              break;
            case "single[]":
              RegistryKey registryKey2;
              if ((registryKey2 = Key.OpenSubKey(field.Name)) != null)
              {
                index = 0;
                float[] numArray = new float[registryKey2.ValueCount];
                object obj8;
                while ((obj8 = registryKey2.GetValue(index.ToString())) != null)
                  numArray[index++] = float.Parse((string) obj8);
                field.SetValue(settings, (object) numArray);
                break;
              }
              break;
            case "double[]":
              RegistryKey registryKey3;
              if ((registryKey3 = Key.OpenSubKey(field.Name)) != null)
              {
                index = 0;
                double[] numArray = new double[registryKey3.ValueCount];
                object obj8;
                while ((obj8 = registryKey3.GetValue(index.ToString())) != null)
                  numArray[index++] = double.Parse((string) obj8);
                field.SetValue(settings, (object) numArray);
                break;
              }
              break;
            case "boolean[]":
              RegistryKey registryKey4;
              if ((registryKey4 = Key.OpenSubKey(field.Name)) != null)
              {
                index = 0;
                bool[] flagArray = new bool[registryKey4.ValueCount];
                object obj8;
                for (; (obj8 = registryKey4.GetValue(index.ToString())) != null; ++index)
                  flagArray[index] = bool.Parse((string) obj8);
                field.SetValue(settings, (object) flagArray);
                break;
              }
              break;
            case "color":
              object obj12;
              if ((obj12 = Key.GetValue(field.Name)) != null)
              {
                string str = (string) obj12;
                System.Drawing.Color color = !Savior.IsHexadecimal(str) ? System.Drawing.Color.FromName(str) : System.Drawing.Color.FromArgb(int.Parse(str, NumberStyles.HexNumber));
                field.SetValue(settings, (object) color);
                break;
              }
              break;
            case "timespan":
              object obj13;
              if ((obj13 = Key.GetValue(field.Name)) != null)
              {
                field.SetValue(settings, (object) TimeSpan.Parse((string) obj13));
                break;
              }
              break;
            case "datetime":
              object obj14;
              if ((obj14 = Key.GetValue(field.Name)) != null)
              {
                field.SetValue(settings, (object) DateTime.Parse((string) obj14));
                break;
              }
              break;
            case "font":
              object obj15;
              if ((obj15 = Key.GetValue(field.Name + ".Name")) != null)
              {
                string familyName = (string) obj15;
                object obj8;
                if ((obj8 = Key.GetValue(field.Name + ".Size")) != null)
                {
                  float emSize = float.Parse((string) obj8);
                  object obj16;
                  if ((obj16 = Key.GetValue(field.Name + ".Style")) != null)
                  {
                    FontStyle style = (FontStyle) Enum.Parse(typeof (FontStyle), (string) obj16);
                    field.SetValue(settings, (object) new Font(familyName, emSize, style));
                  }
                }
                break;
              }
              break;
            default:
              int num1 = (int) MessageBox.Show("This type has not been implemented: " + (object) field.FieldType);
              break;
          }
        }
      }
    }

    public static void Read(object settings, string key)
    {
      RegistryKey subKey = Registry.CurrentUser.CreateSubKey(key);
      Savior.Read(settings, subKey);
    }

    public static void Read(object settings)
    {
      RegistryKey userAppDataRegistry = Application.UserAppDataRegistry;
      Savior.Read(settings, userAppDataRegistry);
    }

    public static bool SaveToFile(object settings, string FileName)
    {
      try
      {
        IFormatter formatter = (IFormatter) new BinaryFormatter();
        Stream serializationStream = (Stream) new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
        formatter.Serialize(serializationStream, settings);
        serializationStream.Close();
        return true;
      }
      catch
      {
        int num = (int) MessageBox.Show("Error attempting to save the settings to a file\n\n" + FileName, "Expresso Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return false;
      }
    }

    public static object ReadFromFile(string FileName)
    {
      try
      {
        IFormatter formatter = (IFormatter) new BinaryFormatter();
        Stream serializationStream = (Stream) new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
        object obj = formatter.Deserialize(serializationStream);
        serializationStream.Close();
        return obj;
      }
      catch
      {
        int num = (int) MessageBox.Show("Error attempting to read the settings from a file\n\n" + FileName, "Expresso Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        return (object) null;
      }
    }

    public static bool IsHexadecimal(string input)
    {
      foreach (char character in input)
      {
        if (!Uri.IsHexDigit(character))
          return false;
      }
      return true;
    }
  }
}
