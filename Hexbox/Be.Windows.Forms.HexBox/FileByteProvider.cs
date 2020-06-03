// Decompiled with JetBrains decompiler
// Type: Be.Windows.Forms.FileByteProvider
// Assembly: Be.Windows.Forms.HexBox, Version=1.4.7.13476, Culture=neutral, PublicKeyToken=e0e5adf0ebc99863
// MVID: 989788C2-0B99-46B0-ADFA-DFA056A86ADD
// Assembly location: E:\Test_Program\F57416M4160C\FT1\Be.Windows.Forms.HexBox.dll

using System;
using System.Collections;
using System.IO;

namespace Be.Windows.Forms
{
  public class FileByteProvider : IByteProvider, IDisposable
  {
    private FileByteProvider.WriteCollection _writes = new FileByteProvider.WriteCollection();
    private string _fileName;
    private FileStream _fileStream;
    private bool _readOnly;

    public event EventHandler Changed;

    public FileByteProvider(string fileName)
    {
      this._fileName = fileName;
      try
      {
        this._fileStream = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
      }
      catch
      {
        try
        {
          this._fileStream = File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
          this._readOnly = true;
        }
        catch
        {
          throw;
        }
      }
    }

    ~FileByteProvider()
    {
      this.Dispose();
    }

    private void OnChanged(EventArgs e)
    {
      if (this.Changed == null)
        return;
      this.Changed((object) this, e);
    }

    public string FileName
    {
      get
      {
        return this._fileName;
      }
    }

    public bool HasChanges()
    {
      return this._writes.Count > 0;
    }

    public void ApplyChanges()
    {
      if (this._readOnly)
        throw new Exception("File is in read-only mode.");
      if (!this.HasChanges())
        return;
      IDictionaryEnumerator enumerator = this._writes.GetEnumerator();
      while (enumerator.MoveNext())
      {
        long key = (long) enumerator.Key;
        byte num = (byte) enumerator.Value;
        if (this._fileStream.Position != key)
          this._fileStream.Position = key;
        this._fileStream.Write(new byte[1]{ num }, 0, 1);
      }
      this._writes.Clear();
    }

    public void RejectChanges()
    {
      this._writes.Clear();
    }

    public event EventHandler LengthChanged;

    public byte ReadByte(long index)
    {
      if (this._writes.Contains(index))
        return this._writes[index];
      if (this._fileStream.Position != index)
        this._fileStream.Position = index;
      return (byte) this._fileStream.ReadByte();
    }

    public long Length
    {
      get
      {
        return this._fileStream.Length;
      }
    }

    public void WriteByte(long index, byte value)
    {
      if (this._writes.Contains(index))
        this._writes[index] = value;
      else
        this._writes.Add(index, value);
      this.OnChanged(EventArgs.Empty);
    }

    public void DeleteBytes(long index, long length)
    {
      throw new NotSupportedException("FileByteProvider.DeleteBytes");
    }

    public void InsertBytes(long index, byte[] bs)
    {
      throw new NotSupportedException("FileByteProvider.InsertBytes");
    }

    public bool SupportsWriteByte()
    {
      return !this._readOnly;
    }

    public bool SupportsInsertBytes()
    {
      return false;
    }

    public bool SupportsDeleteBytes()
    {
      return false;
    }

    public void Dispose()
    {
      if (this._fileStream != null)
      {
        this._fileName = (string) null;
        this._fileStream.Close();
        this._fileStream = (FileStream) null;
      }
      GC.SuppressFinalize((object) this);
    }

    private class WriteCollection : DictionaryBase
    {
      public byte this[long index]
      {
        get
        {
          return (byte) this.Dictionary[(object) index];
        }
        set
        {
          this.Dictionary[(object) index] = (object) value;
        }
      }

      public void Add(long index, byte value)
      {
        this.Dictionary.Add((object) index, (object) value);
      }

      public bool Contains(long index)
      {
        return this.Dictionary.Contains((object) index);
      }
    }
  }
}
