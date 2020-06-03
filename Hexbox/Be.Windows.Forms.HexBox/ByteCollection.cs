﻿// Decompiled with JetBrains decompiler
// Type: Be.Windows.Forms.ByteCollection
// Assembly: Be.Windows.Forms.HexBox, Version=1.4.7.13476, Culture=neutral, PublicKeyToken=e0e5adf0ebc99863
// MVID: 989788C2-0B99-46B0-ADFA-DFA056A86ADD
// Assembly location: E:\Test_Program\F57416M4160C\FT1\Be.Windows.Forms.HexBox.dll

using System;
using System.Collections;

namespace Be.Windows.Forms
{
  public class ByteCollection : CollectionBase
  {
    public ByteCollection()
    {
    }

    public ByteCollection(byte[] bs)
    {
      this.AddRange(bs);
    }

    public byte this[int index]
    {
      get
      {
        return (byte) this.List[index];
      }
      set
      {
        this.List[index] = (object) value;
      }
    }

    public void Add(byte b)
    {
      this.List.Add((object) b);
    }

    public void AddRange(byte[] bs)
    {
      this.InnerList.AddRange((ICollection) bs);
    }

    public void Remove(byte b)
    {
      this.List.Remove((object) b);
    }

    public void RemoveRange(int index, int count)
    {
      this.InnerList.RemoveRange(index, count);
    }

    public void InsertRange(int index, byte[] bs)
    {
      this.InnerList.InsertRange(index, (ICollection) bs);
    }

    public byte[] GetBytes()
    {
      byte[] numArray = new byte[this.Count];
      this.InnerList.CopyTo(0, (Array) numArray, 0, numArray.Length);
      return numArray;
    }

    public void Insert(int index, byte b)
    {
      this.InnerList.Insert(index, (object) b);
    }

    public int IndexOf(byte b)
    {
      return this.InnerList.IndexOf((object) b);
    }

    public bool Contains(byte b)
    {
      return this.InnerList.Contains((object) b);
    }

    public void CopyTo(byte[] bs, int index)
    {
      this.InnerList.CopyTo((Array) bs, index);
    }

    public byte[] ToArray()
    {
      byte[] bs = new byte[this.Count];
      this.CopyTo(bs, 0);
      return bs;
    }
  }
}
