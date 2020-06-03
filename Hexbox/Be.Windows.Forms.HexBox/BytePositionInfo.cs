// Decompiled with JetBrains decompiler
// Type: Be.Windows.Forms.BytePositionInfo
// Assembly: Be.Windows.Forms.HexBox, Version=1.4.7.13476, Culture=neutral, PublicKeyToken=e0e5adf0ebc99863
// MVID: 989788C2-0B99-46B0-ADFA-DFA056A86ADD
// Assembly location: E:\Test_Program\F57416M4160C\FT1\Be.Windows.Forms.HexBox.dll

namespace Be.Windows.Forms
{
  internal struct BytePositionInfo
  {
    private int _characterPosition;
    private long _index;

    public BytePositionInfo(long index, int characterPosition)
    {
      this._index = index;
      this._characterPosition = characterPosition;
    }

    public int CharacterPosition
    {
      get
      {
        return this._characterPosition;
      }
    }

    public long Index
    {
      get
      {
        return this._index;
      }
    }
  }
}
