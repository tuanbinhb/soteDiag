// Decompiled with JetBrains decompiler
// Type: Be.Windows.Forms.DataBlock
// Assembly: Be.Windows.Forms.HexBox, Version=1.4.7.13476, Culture=neutral, PublicKeyToken=e0e5adf0ebc99863
// MVID: 989788C2-0B99-46B0-ADFA-DFA056A86ADD
// Assembly location: E:\Test_Program\F57416M4160C\FT1\Be.Windows.Forms.HexBox.dll

namespace Be.Windows.Forms
{
  internal abstract class DataBlock
  {
    internal DataMap _map;
    internal DataBlock _nextBlock;
    internal DataBlock _previousBlock;

    public abstract long Length { get; }

    public DataMap Map
    {
      get
      {
        return this._map;
      }
    }

    public DataBlock NextBlock
    {
      get
      {
        return this._nextBlock;
      }
    }

    public DataBlock PreviousBlock
    {
      get
      {
        return this._previousBlock;
      }
    }

    public abstract void RemoveBytes(long position, long count);
  }
}
