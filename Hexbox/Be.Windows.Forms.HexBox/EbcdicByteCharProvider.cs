// Decompiled with JetBrains decompiler
// Type: Be.Windows.Forms.EbcdicByteCharProvider
// Assembly: Be.Windows.Forms.HexBox, Version=1.4.7.13476, Culture=neutral, PublicKeyToken=e0e5adf0ebc99863
// MVID: 989788C2-0B99-46B0-ADFA-DFA056A86ADD
// Assembly location: E:\Test_Program\F57416M4160C\FT1\Be.Windows.Forms.HexBox.dll

using System.Text;

namespace Be.Windows.Forms
{
  public class EbcdicByteCharProvider : IByteCharConverter
  {
    private Encoding _ebcdicEncoding = Encoding.GetEncoding(500);

    public virtual char ToChar(byte b)
    {
      string str = this._ebcdicEncoding.GetString(new byte[1]
      {
        b
      });
      return str.Length <= 0 ? '.' : str[0];
    }

    public virtual byte ToByte(char c)
    {
      byte[] bytes = this._ebcdicEncoding.GetBytes(new char[1]
      {
        c
      });
      return bytes.Length <= 0 ? (byte) 0 : bytes[0];
    }

    public override string ToString()
    {
      return "EBCDIC (Code Page 500)";
    }
  }
}
