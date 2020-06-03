// Decompiled with JetBrains decompiler
// Type: Be.Windows.Forms.DynamicByteProvider
// Assembly: Be.Windows.Forms.HexBox, Version=1.4.7.13476, Culture=neutral, PublicKeyToken=e0e5adf0ebc99863
// MVID: 989788C2-0B99-46B0-ADFA-DFA056A86ADD
// Assembly location: E:\Test_Program\F57416M4160C\FT1\Be.Windows.Forms.HexBox.dll

using System;
using System.Collections.Generic;

namespace Be.Windows.Forms
{
  public class DynamicByteProvider : IByteProvider
  {
    private bool _hasChanges;
    private List<byte> _bytes;

    public DynamicByteProvider(byte[] data)
      : this(new List<byte>((IEnumerable<byte>) data))
    {
    }

    public DynamicByteProvider(List<byte> bytes)
    {
      this._bytes = bytes;
    }

    private void OnChanged(EventArgs e)
    {
      this._hasChanges = true;
      if (this.Changed == null)
        return;
      this.Changed((object) this, e);
    }

    private void OnLengthChanged(EventArgs e)
    {
      if (this.LengthChanged == null)
        return;
      this.LengthChanged((object) this, e);
    }

    public List<byte> Bytes
    {
      get
      {
        return this._bytes;
      }
    }

    public bool HasChanges()
    {
      return this._hasChanges;
    }

    public void ApplyChanges()
    {
      this._hasChanges = false;
    }

    public event EventHandler Changed;

    public event EventHandler LengthChanged;

    public byte ReadByte(long index)
    {
      return this._bytes[(int) index];
    }

    public void WriteByte(long index, byte value)
    {
      this._bytes[(int) index] = value;
      this.OnChanged(EventArgs.Empty);
    }

    public void DeleteBytes(long index, long length)
    {
      this._bytes.RemoveRange((int) Math.Max(0L, index), (int) Math.Min((long) (int) this.Length, length));
      this.OnLengthChanged(EventArgs.Empty);
      this.OnChanged(EventArgs.Empty);
    }

    public void InsertBytes(long index, byte[] bs)
    {
      this._bytes.InsertRange((int) index, (IEnumerable<byte>) bs);
      this.OnLengthChanged(EventArgs.Empty);
      this.OnChanged(EventArgs.Empty);
    }

    public long Length
    {
      get
      {
        return (long) this._bytes.Count;
      }
    }

    public bool SupportsWriteByte()
    {
      return true;
    }

    public bool SupportsInsertBytes()
    {
      return true;
    }

    public bool SupportsDeleteBytes()
    {
      return true;
    }
  }
}
