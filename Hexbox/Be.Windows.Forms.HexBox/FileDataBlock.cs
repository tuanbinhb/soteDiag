// Decompiled with JetBrains decompiler
// Type: Be.Windows.Forms.FileDataBlock
// Assembly: Be.Windows.Forms.HexBox, Version=1.4.7.13476, Culture=neutral, PublicKeyToken=e0e5adf0ebc99863
// MVID: 989788C2-0B99-46B0-ADFA-DFA056A86ADD
// Assembly location: E:\Test_Program\F57416M4160C\FT1\Be.Windows.Forms.HexBox.dll

using System;

namespace Be.Windows.Forms
{
  internal sealed class FileDataBlock : DataBlock
  {
    private long _length;
    private long _fileOffset;

    public FileDataBlock(long fileOffset, long length)
    {
      this._fileOffset = fileOffset;
      this._length = length;
    }

    public long FileOffset
    {
      get
      {
        return this._fileOffset;
      }
    }

    public override long Length
    {
      get
      {
        return this._length;
      }
    }

    public void SetFileOffset(long value)
    {
      this._fileOffset = value;
    }

    public void RemoveBytesFromEnd(long count)
    {
      if (count > this._length)
        throw new ArgumentOutOfRangeException(nameof (count));
      this._length -= count;
    }

    public void RemoveBytesFromStart(long count)
    {
      if (count > this._length)
        throw new ArgumentOutOfRangeException(nameof (count));
      this._fileOffset += count;
      this._length -= count;
    }

    public override void RemoveBytes(long position, long count)
    {
      if (position > this._length)
        throw new ArgumentOutOfRangeException(nameof (position));
      if (position + count > this._length)
        throw new ArgumentOutOfRangeException(nameof (count));
      long num = position;
      long fileOffset1 = this._fileOffset;
      long length = this._length - count - num;
      long fileOffset2 = this._fileOffset + position + count;
      if (num > 0L && length > 0L)
      {
        this._fileOffset = fileOffset1;
        this._length = num;
        this._map.AddAfter((DataBlock) this, (DataBlock) new FileDataBlock(fileOffset2, length));
      }
      else if (num > 0L)
      {
        this._fileOffset = fileOffset1;
        this._length = num;
      }
      else
      {
        this._fileOffset = fileOffset2;
        this._length = length;
      }
    }
  }
}
