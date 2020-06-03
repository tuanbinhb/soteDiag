// Decompiled with JetBrains decompiler
// Type: Util.ArrayUtil
// Assembly: soteDiag, Version=3.2.3.9, Culture=neutral, PublicKeyToken=null
// MVID: 64B98F7C-FFB0-44BA-B97E-997AD765B8FF
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteDiag.exe

namespace Util
{
  public class ArrayUtil
  {
    public static byte[] ToByteArray(int[] intArray)
    {
      byte[] numArray = new byte[intArray.Length];
      for (int index = 0; index < intArray.Length; ++index)
        numArray[index] = (byte) intArray[index];
      return numArray;
    }

    public static int[] ToIntArray(byte[] byteArray)
    {
      int[] numArray = new int[byteArray.Length];
      for (int index = 0; index < byteArray.Length; ++index)
        numArray[index] = (int) byteArray[index];
      return numArray;
    }

    public static byte[] SubsetArray(byte[] byteArray, int startIndex, int length)
    {
      byte[] numArray = new byte[length];
      for (int index = 0; index < length; ++index)
        numArray[index] = byteArray[startIndex + index];
      return numArray;
    }

    public static bool Compare2Array(byte[] array1, byte[] array2)
    {
      if (array1.Length != array2.Length)
        return false;
      int num = array1.Length <= array2.Length ? array1.Length : array2.Length;
      for (int index = 0; index < num; ++index)
      {
        if ((int) array1[index] != (int) array2[index])
          return false;
      }
      return true;
    }
  }
}
