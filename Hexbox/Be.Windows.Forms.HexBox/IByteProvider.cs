// Decompiled with JetBrains decompiler
// Type: Be.Windows.Forms.IByteProvider
// Assembly: Be.Windows.Forms.HexBox, Version=1.4.7.13476, Culture=neutral, PublicKeyToken=e0e5adf0ebc99863
// MVID: 989788C2-0B99-46B0-ADFA-DFA056A86ADD
// Assembly location: E:\Test_Program\F57416M4160C\FT1\Be.Windows.Forms.HexBox.dll

using System;

namespace Be.Windows.Forms
{
  public interface IByteProvider
  {
    byte ReadByte(long index);

    void WriteByte(long index, byte value);

    void InsertBytes(long index, byte[] bs);

    void DeleteBytes(long index, long length);

    long Length { get; }

    event EventHandler LengthChanged;

    bool HasChanges();

    void ApplyChanges();

    event EventHandler Changed;

    bool SupportsWriteByte();

    bool SupportsInsertBytes();

    bool SupportsDeleteBytes();
  }
}
