// Decompiled with JetBrains decompiler
// Type: Be.Windows.Forms.DefaultByteCharConverter
// Assembly: Be.Windows.Forms.HexBox, Version=1.4.7.13476, Culture=neutral, PublicKeyToken=e0e5adf0ebc99863
// MVID: 989788C2-0B99-46B0-ADFA-DFA056A86ADD
// Assembly location: E:\Test_Program\F57416M4160C\FT1\Be.Windows.Forms.HexBox.dll

namespace Be.Windows.Forms
{
  public class DefaultByteCharConverter : IByteCharConverter
  {
    public virtual char ToChar(byte b)
    {
      return b <= (byte) 31 || b > (byte) 126 && b < (byte) 160 ? '.' : (char) b;
    }

    public virtual byte ToByte(char c)
    {
      return (byte) c;
    }

    public override string ToString()
    {
      return "Default";
    }
  }
}
