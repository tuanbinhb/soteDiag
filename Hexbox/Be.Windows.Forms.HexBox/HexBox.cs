﻿// Decompiled with JetBrains decompiler
// Type: Be.Windows.Forms.HexBox
// Assembly: Be.Windows.Forms.HexBox, Version=1.4.7.13476, Culture=neutral, PublicKeyToken=e0e5adf0ebc99863
// MVID: 989788C2-0B99-46B0-ADFA-DFA056A86ADD
// Assembly location: E:\Test_Program\F57416M4160C\FT1\Be.Windows.Forms.HexBox.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Be.Windows.Forms
{
  [ToolboxBitmap(typeof (HexBox), "HexBox.bmp")]
  public class HexBox : Control
  {
    private System.Windows.Forms.Timer _thumbTrackTimer = new System.Windows.Forms.Timer();
    private int _recBorderLeft = SystemInformation.Border3DSize.Width;
    private int _recBorderRight = SystemInformation.Border3DSize.Width;
    private int _recBorderTop = SystemInformation.Border3DSize.Height;
    private int _recBorderBottom = SystemInformation.Border3DSize.Height;
    private long _bytePos = -1;
    private string _hexStringFormat = "X";
    private Color _backColorDisabled = Color.FromName("WhiteSmoke");
    private int _bytesPerLine = 16;
    private BorderStyle _borderStyle = BorderStyle.Fixed3D;
    private Color _lineInfoForeColor = Color.Empty;
    private Color _selectionBackColor = Color.Blue;
    private Color _selectionForeColor = Color.White;
    private bool _shadowSelectionVisible = true;
    private Color _shadowSelectionColor = Color.FromArgb(100, 60, 188, (int) byte.MaxValue);
    private const int THUMPTRACKDELAY = 50;
    private Rectangle _recContent;
    private Rectangle _recLineInfo;
    private Rectangle _recHex;
    private Rectangle _recStringView;
    private StringFormat _stringFormat;
    private SizeF _charSize;
    private int _iHexMaxHBytes;
    private int _iHexMaxVBytes;
    private int _iHexMaxBytes;
    private long _scrollVmin;
    private long _scrollVmax;
    private long _scrollVpos;
    private VScrollBar _vScrollBar;
    private long _thumbTrackPosition;
    private int _lastThumbtrack;
    private long _startByte;
    private long _endByte;
    private int _byteCharacterPos;
    private HexBox.IKeyInterpreter _keyInterpreter;
    private HexBox.EmptyKeyInterpreter _eki;
    private HexBox.KeyInterpreter _ki;
    private HexBox.StringKeyInterpreter _ski;
    private bool _caretVisible;
    private bool _abortFind;
    private long _findingPos;
    private bool _insertActive;
    private bool _readOnly;
    private bool _useFixedBytesPerLine;
    private bool _vScrollBarVisible;
    private IByteProvider _byteProvider;
    private bool _lineInfoVisible;
    private long _lineInfoOffset;
    private bool _stringViewVisible;
    private long _selectionLength;
    private long _currentLine;
    private int _currentPositionInLine;
    private BuiltInContextMenu _builtInContextMenu;
    private IByteCharConverter _byteCharConverter;

    [Description("Occurs, when the value of InsertActive property has changed.")]
    public event EventHandler InsertActiveChanged;

    [Description("Occurs, when the value of ReadOnly property has changed.")]
    public event EventHandler ReadOnlyChanged;

    [Description("Occurs, when the value of ByteProvider property has changed.")]
    public event EventHandler ByteProviderChanged;

    [Description("Occurs, when the value of SelectionStart property has changed.")]
    public event EventHandler SelectionStartChanged;

    [Description("Occurs, when the value of SelectionLength property has changed.")]
    public event EventHandler SelectionLengthChanged;

    [Description("Occurs, when the value of LineInfoVisible property has changed.")]
    public event EventHandler LineInfoVisibleChanged;

    [Description("Occurs, when the value of StringViewVisible property has changed.")]
    public event EventHandler StringViewVisibleChanged;

    [Description("Occurs, when the value of BorderStyle property has changed.")]
    public event EventHandler BorderStyleChanged;

    [Description("Occurs, when the value of BytesPerLine property has changed.")]
    public event EventHandler BytesPerLineChanged;

    [Description("Occurs, when the value of UseFixedBytesPerLine property has changed.")]
    public event EventHandler UseFixedBytesPerLineChanged;

    [Description("Occurs, when the value of VScrollBarVisible property has changed.")]
    public event EventHandler VScrollBarVisibleChanged;

    [Description("Occurs, when the value of HexCasing property has changed.")]
    public event EventHandler HexCasingChanged;

    [Description("Occurs, when the value of HorizontalByteCount property has changed.")]
    public event EventHandler HorizontalByteCountChanged;

    [Description("Occurs, when the value of VerticalByteCount property has changed.")]
    public event EventHandler VerticalByteCountChanged;

    [Description("Occurs, when the value of CurrentLine property has changed.")]
    public event EventHandler CurrentLineChanged;

    [Description("Occurs, when the value of CurrentPositionInLine property has changed.")]
    public event EventHandler CurrentPositionInLineChanged;

    [Description("Occurs, when Copy method was invoked and ClipBoardData changed.")]
    public event EventHandler Copied;

    [Description("Occurs, when CopyHex method was invoked and ClipBoardData changed.")]
    public event EventHandler CopiedHex;

    public HexBox()
    {
      this._vScrollBar = new VScrollBar();
      this._vScrollBar.Scroll += new ScrollEventHandler(this._vScrollBar_Scroll);
      this._builtInContextMenu = new BuiltInContextMenu(this);
      this.BackColor = Color.White;
      this.Font = new Font("Courier New", 9f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this._stringFormat = new StringFormat(StringFormat.GenericTypographic);
      this._stringFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces;
      this.ActivateEmptyKeyInterpreter();
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this._thumbTrackTimer.Interval = 50;
      this._thumbTrackTimer.Tick += new EventHandler(this.PerformScrollThumbTrack);
    }

    private void _vScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
      switch (e.Type)
      {
        case ScrollEventType.SmallDecrement:
          this.PerformScrollLineUp();
          break;
        case ScrollEventType.SmallIncrement:
          this.PerformScrollLineDown();
          break;
        case ScrollEventType.LargeDecrement:
          this.PerformScrollPageUp();
          break;
        case ScrollEventType.LargeIncrement:
          this.PerformScrollPageDown();
          break;
        case ScrollEventType.ThumbPosition:
          this.PerformScrollThumpPosition(this.FromScrollPos(e.NewValue));
          break;
        case ScrollEventType.ThumbTrack:
          if (this._thumbTrackTimer.Enabled)
            this._thumbTrackTimer.Enabled = false;
          int tickCount = Environment.TickCount;
          if (tickCount - this._lastThumbtrack > 50)
          {
            this.PerformScrollThumbTrack((object) null, (EventArgs) null);
            this._lastThumbtrack = tickCount;
            break;
          }
          this._thumbTrackPosition = this.FromScrollPos(e.NewValue);
          this._thumbTrackTimer.Enabled = true;
          break;
      }
      e.NewValue = this.ToScrollPos(this._scrollVpos);
    }

    private void PerformScrollThumbTrack(object sender, EventArgs e)
    {
      this._thumbTrackTimer.Enabled = false;
      this.PerformScrollThumpPosition(this._thumbTrackPosition);
      this._lastThumbtrack = Environment.TickCount;
    }

    private void UpdateScrollSize()
    {
      if (this.VScrollBarVisible && this._byteProvider != null && (this._byteProvider.Length > 0L && this._iHexMaxHBytes != 0))
      {
        long val2 = Math.Max(0L, (long) Math.Ceiling((double) (this._byteProvider.Length + 1L) / (double) this._iHexMaxHBytes - (double) this._iHexMaxVBytes));
        long val1 = this._startByte / (long) this._iHexMaxHBytes;
        if (val2 < this._scrollVmax && this._scrollVpos == this._scrollVmax)
          this.PerformScrollLineUp();
        if (val2 == this._scrollVmax && val1 == this._scrollVpos)
          return;
        this._scrollVmin = 0L;
        this._scrollVmax = val2;
        this._scrollVpos = Math.Min(val1, val2);
        this.UpdateVScroll();
      }
      else
      {
        if (!this.VScrollBarVisible)
          return;
        this._scrollVmin = 0L;
        this._scrollVmax = 0L;
        this._scrollVpos = 0L;
        this.UpdateVScroll();
      }
    }

    private void UpdateVScroll()
    {
      int scrollMax = this.ToScrollMax(this._scrollVmax);
      if (scrollMax > 0)
      {
        this._vScrollBar.Minimum = 0;
        this._vScrollBar.Maximum = scrollMax;
        this._vScrollBar.Value = this.ToScrollPos(this._scrollVpos);
        this._vScrollBar.Enabled = true;
      }
      else
        this._vScrollBar.Enabled = false;
    }

    private int ToScrollPos(long value)
    {
      int maxValue = (int) ushort.MaxValue;
      if (this._scrollVmax < (long) maxValue)
        return (int) value;
      double num = (double) value / (double) this._scrollVmax * 100.0;
      return (int) Math.Min(this._scrollVmax, (long) (int) Math.Max(this._scrollVmin, (long) (int) Math.Floor((double) maxValue / 100.0 * num)));
    }

    private long FromScrollPos(int value)
    {
      int maxValue = (int) ushort.MaxValue;
      return this._scrollVmax < (long) maxValue ? (long) value : (long) (int) Math.Floor((double) this._scrollVmax / 100.0 * ((double) value / (double) maxValue * 100.0));
    }

    private int ToScrollMax(long value)
    {
      long maxValue = (long) ushort.MaxValue;
      return value > maxValue ? (int) maxValue : (int) value;
    }

    private void PerformScrollToLine(long pos)
    {
      if (pos < this._scrollVmin || pos > this._scrollVmax || pos == this._scrollVpos)
        return;
      this._scrollVpos = pos;
      this.UpdateVScroll();
      this.UpdateVisibilityBytes();
      this.UpdateCaret();
      this.Invalidate();
    }

    private void PerformScrollLines(int lines)
    {
      long pos;
      if (lines > 0)
      {
        pos = Math.Min(this._scrollVmax, this._scrollVpos + (long) lines);
      }
      else
      {
        if (lines >= 0)
          return;
        pos = Math.Max(this._scrollVmin, this._scrollVpos + (long) lines);
      }
      this.PerformScrollToLine(pos);
    }

    private void PerformScrollLineDown()
    {
      this.PerformScrollLines(1);
    }

    private void PerformScrollLineUp()
    {
      this.PerformScrollLines(-1);
    }

    private void PerformScrollPageDown()
    {
      this.PerformScrollLines(this._iHexMaxVBytes);
    }

    private void PerformScrollPageUp()
    {
      this.PerformScrollLines(-this._iHexMaxVBytes);
    }

    private void PerformScrollThumpPosition(long pos)
    {
      int num = this._scrollVmax > (long) ushort.MaxValue ? 10 : 9;
      if (this.ToScrollPos(pos) == this.ToScrollMax(this._scrollVmax) - num)
        pos = this._scrollVmax;
      this.PerformScrollToLine(pos);
    }

    public void ScrollByteIntoView()
    {
      this.ScrollByteIntoView(this._bytePos);
    }

    public void ScrollByteIntoView(long index)
    {
      if (this._byteProvider == null || this._keyInterpreter == null)
        return;
      if (index < this._startByte)
      {
        this.PerformScrollThumpPosition((long) Math.Floor((double) index / (double) this._iHexMaxHBytes));
      }
      else
      {
        if (index <= this._endByte)
          return;
        this.PerformScrollThumpPosition((long) Math.Floor((double) index / (double) this._iHexMaxHBytes) - (long) (this._iHexMaxVBytes - 1));
      }
    }

    private void ReleaseSelection()
    {
      if (this._selectionLength == 0L)
        return;
      this._selectionLength = 0L;
      this.OnSelectionLengthChanged(EventArgs.Empty);
      if (!this._caretVisible)
        this.CreateCaret();
      else
        this.UpdateCaret();
      this.Invalidate();
    }

    public bool CanSelectAll()
    {
      return this.Enabled && this._byteProvider != null;
    }

    public void SelectAll()
    {
      if (this.ByteProvider == null)
        return;
      this.Select(0L, this.ByteProvider.Length);
    }

    public void Select(long start, long length)
    {
      if (this.ByteProvider == null || !this.Enabled)
        return;
      this.InternalSelect(start, length);
      this.ScrollByteIntoView();
    }

    private void InternalSelect(long start, long length)
    {
      long bytePos = start;
      long selectionLength = length;
      int byteCharacterPos = 0;
      if (selectionLength > 0L && this._caretVisible)
        this.DestroyCaret();
      else if (selectionLength == 0L && !this._caretVisible)
        this.CreateCaret();
      this.SetPosition(bytePos, byteCharacterPos);
      this.SetSelectionLength(selectionLength);
      this.UpdateCaret();
      this.Invalidate();
    }

    private void ActivateEmptyKeyInterpreter()
    {
      if (this._eki == null)
        this._eki = new HexBox.EmptyKeyInterpreter(this);
      if (this._eki == this._keyInterpreter)
        return;
      if (this._keyInterpreter != null)
        this._keyInterpreter.Deactivate();
      this._keyInterpreter = (HexBox.IKeyInterpreter) this._eki;
      this._keyInterpreter.Activate();
    }

    private void ActivateKeyInterpreter()
    {
      if (this._ki == null)
        this._ki = new HexBox.KeyInterpreter(this);
      if (this._ki == this._keyInterpreter)
        return;
      if (this._keyInterpreter != null)
        this._keyInterpreter.Deactivate();
      this._keyInterpreter = (HexBox.IKeyInterpreter) this._ki;
      this._keyInterpreter.Activate();
    }

    private void ActivateStringKeyInterpreter()
    {
      if (this._ski == null)
        this._ski = new HexBox.StringKeyInterpreter(this);
      if (this._ski == this._keyInterpreter)
        return;
      if (this._keyInterpreter != null)
        this._keyInterpreter.Deactivate();
      this._keyInterpreter = (HexBox.IKeyInterpreter) this._ski;
      this._keyInterpreter.Activate();
    }

    private void CreateCaret()
    {
      if (this._byteProvider == null || this._keyInterpreter == null || (this._caretVisible || !this.Focused))
        return;
      int nWidth = this.InsertActive ? 1 : (int) this._charSize.Width;
      int height = (int) this._charSize.Height;
      NativeMethods.CreateCaret(this.Handle, IntPtr.Zero, nWidth, height);
      this.UpdateCaret();
      NativeMethods.ShowCaret(this.Handle);
      this._caretVisible = true;
    }

    private void UpdateCaret()
    {
      if (this._byteProvider == null || this._keyInterpreter == null)
        return;
      PointF caretPointF = this._keyInterpreter.GetCaretPointF(this._bytePos - this._startByte);
      caretPointF.X += (float) this._byteCharacterPos * this._charSize.Width;
      NativeMethods.SetCaretPos((int) caretPointF.X, (int) caretPointF.Y);
    }

    private void DestroyCaret()
    {
      if (!this._caretVisible)
        return;
      NativeMethods.DestroyCaret();
      this._caretVisible = false;
    }

    private void SetCaretPosition(Point p)
    {
      if (this._byteProvider == null || this._keyInterpreter == null)
        return;
      long bytePos = this._bytePos;
      int byteCharacterPos = this._byteCharacterPos;
      if (this._recHex.Contains(p))
      {
        BytePositionInfo bytePositionInfo = this.GetHexBytePositionInfo(p);
        this.SetPosition(bytePositionInfo.Index, bytePositionInfo.CharacterPosition);
        this.ActivateKeyInterpreter();
        this.UpdateCaret();
        this.Invalidate();
      }
      else
      {
        if (!this._recStringView.Contains(p))
          return;
        BytePositionInfo bytePositionInfo = this.GetStringBytePositionInfo(p);
        this.SetPosition(bytePositionInfo.Index, bytePositionInfo.CharacterPosition);
        this.ActivateStringKeyInterpreter();
        this.UpdateCaret();
        this.Invalidate();
      }
    }

    private BytePositionInfo GetHexBytePositionInfo(Point p)
    {
      float num1 = (float) (p.X - this._recHex.X) / this._charSize.Width;
      float num2 = (float) (p.Y - this._recHex.Y) / this._charSize.Height;
      int num3 = (int) num1;
      long index = Math.Min(this._byteProvider.Length, this._startByte + (long) (this._iHexMaxHBytes * ((int) num2 + 1) - this._iHexMaxHBytes) + (long) (num3 / 3 + 1) - 1L);
      int characterPosition = num3 % 3;
      if (characterPosition > 1)
        characterPosition = 1;
      if (index == this._byteProvider.Length)
        characterPosition = 0;
      return index < 0L ? new BytePositionInfo(0L, 0) : new BytePositionInfo(index, characterPosition);
    }

    private BytePositionInfo GetStringBytePositionInfo(Point p)
    {
      float num = (float) (p.X - this._recStringView.X) / this._charSize.Width;
      long index = Math.Min(this._byteProvider.Length, this._startByte + (long) (this._iHexMaxHBytes * ((int) ((float) (p.Y - this._recStringView.Y) / this._charSize.Height) + 1) - this._iHexMaxHBytes) + (long) ((int) num + 1) - 1L);
      int characterPosition = 0;
      return index < 0L ? new BytePositionInfo(0L, 0) : new BytePositionInfo(index, characterPosition);
    }

    [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
    [SecurityPermission(SecurityAction.InheritanceDemand, UnmanagedCode = true)]
    public override bool PreProcessMessage(ref Message m)
    {
      switch (m.Msg)
      {
        case 256:
          return this._keyInterpreter.PreProcessWmKeyDown(ref m);
        case 257:
          return this._keyInterpreter.PreProcessWmKeyUp(ref m);
        case 258:
          return this._keyInterpreter.PreProcessWmChar(ref m);
        default:
          return base.PreProcessMessage(ref m);
      }
    }

    private bool BasePreProcessMessage(ref Message m)
    {
      return base.PreProcessMessage(ref m);
    }

    public long Find(byte[] bytes, long startIndex)
    {
      int index1 = 0;
      int length = bytes.Length;
      this._abortFind = false;
      for (long index2 = startIndex; index2 < this._byteProvider.Length; ++index2)
      {
        if (this._abortFind)
          return -2;
        if (index2 % 1000L == 0L)
          Application.DoEvents();
        if ((int) this._byteProvider.ReadByte(index2) != (int) bytes[index1])
        {
          index2 -= (long) index1;
          index1 = 0;
          this._findingPos = index2;
        }
        else
        {
          ++index1;
          if (index1 == length)
          {
            long start = index2 - (long) length + 1L;
            this.Select(start, (long) length);
            this.ScrollByteIntoView(this._bytePos + this._selectionLength);
            this.ScrollByteIntoView(this._bytePos);
            return start;
          }
        }
      }
      return -1;
    }

    public void AbortFind()
    {
      this._abortFind = true;
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public long CurrentFindingPosition
    {
      get
      {
        return this._findingPos;
      }
    }

    private byte[] GetCopyData()
    {
      if (!this.CanCopy())
        return new byte[0];
      byte[] numArray = new byte[this._selectionLength];
      int index = -1;
      for (long bytePos = this._bytePos; bytePos < this._bytePos + this._selectionLength; ++bytePos)
      {
        ++index;
        numArray[index] = this._byteProvider.ReadByte(bytePos);
      }
      return numArray;
    }

    public void Copy()
    {
      if (!this.CanCopy())
        return;
      byte[] copyData = this.GetCopyData();
      DataObject dataObject = new DataObject();
      string str = Encoding.ASCII.GetString(copyData, 0, copyData.Length);
      dataObject.SetData(typeof (string), (object) str);
      MemoryStream memoryStream = new MemoryStream(copyData, 0, copyData.Length, false, true);
      dataObject.SetData("BinaryData", (object) memoryStream);
      Clipboard.SetDataObject((object) dataObject, true);
      this.UpdateCaret();
      this.ScrollByteIntoView();
      this.Invalidate();
      this.OnCopied(EventArgs.Empty);
    }

    public bool CanCopy()
    {
      return this._selectionLength >= 1L && this._byteProvider != null;
    }

    public void Cut()
    {
      if (!this.CanCut())
        return;
      this.Copy();
      this._byteProvider.DeleteBytes(this._bytePos, this._selectionLength);
      this._byteCharacterPos = 0;
      this.UpdateCaret();
      this.ScrollByteIntoView();
      this.ReleaseSelection();
      this.Invalidate();
      this.Refresh();
    }

    public bool CanCut()
    {
      return !this.ReadOnly && this.Enabled && (this._byteProvider != null && this._selectionLength >= 1L) && this._byteProvider.SupportsDeleteBytes();
    }

    public void Paste()
    {
      if (!this.CanPaste())
        return;
      if (this._selectionLength > 0L)
        this._byteProvider.DeleteBytes(this._bytePos, this._selectionLength);
      IDataObject dataObject = Clipboard.GetDataObject();
      byte[] numArray;
      if (dataObject.GetDataPresent("BinaryData"))
      {
        MemoryStream data = (MemoryStream) dataObject.GetData("BinaryData");
        numArray = new byte[data.Length];
        data.Read(numArray, 0, numArray.Length);
      }
      else
      {
        if (!dataObject.GetDataPresent(typeof (string)))
          return;
        numArray = Encoding.ASCII.GetBytes((string) dataObject.GetData(typeof (string)));
      }
      this._byteProvider.InsertBytes(this._bytePos, numArray);
      this.SetPosition(this._bytePos + (long) numArray.Length, 0);
      this.ReleaseSelection();
      this.ScrollByteIntoView();
      this.UpdateCaret();
      this.Invalidate();
    }

    public bool CanPaste()
    {
      if (this.ReadOnly || !this.Enabled || (this._byteProvider == null || !this._byteProvider.SupportsInsertBytes()) || !this._byteProvider.SupportsDeleteBytes() && this._selectionLength > 0L)
        return false;
      IDataObject dataObject = Clipboard.GetDataObject();
      return dataObject.GetDataPresent("BinaryData") || dataObject.GetDataPresent(typeof (string));
    }

    public bool CanPasteHex()
    {
      if (!this.CanPaste())
        return false;
      IDataObject dataObject = Clipboard.GetDataObject();
      return dataObject.GetDataPresent(typeof (string)) && this.ConvertHexToBytes((string) dataObject.GetData(typeof (string))) != null;
    }

    public void PasteHex()
    {
      if (!this.CanPaste())
        return;
      IDataObject dataObject = Clipboard.GetDataObject();
      if (!dataObject.GetDataPresent(typeof (string)))
        return;
      byte[] bytes = this.ConvertHexToBytes((string) dataObject.GetData(typeof (string)));
      if (bytes == null)
        return;
      if (this._selectionLength > 0L)
        this._byteProvider.DeleteBytes(this._bytePos, this._selectionLength);
      this._byteProvider.InsertBytes(this._bytePos, bytes);
      this.SetPosition(this._bytePos + (long) bytes.Length, 0);
      this.ReleaseSelection();
      this.ScrollByteIntoView();
      this.UpdateCaret();
      this.Invalidate();
    }

    public void CopyHex()
    {
      if (!this.CanCopy())
        return;
      byte[] copyData = this.GetCopyData();
      DataObject dataObject = new DataObject();
      string hex = this.ConvertBytesToHex(copyData);
      dataObject.SetData(typeof (string), (object) hex);
      MemoryStream memoryStream = new MemoryStream(copyData, 0, copyData.Length, false, true);
      dataObject.SetData("BinaryData", (object) memoryStream);
      Clipboard.SetDataObject((object) dataObject, true);
      this.UpdateCaret();
      this.ScrollByteIntoView();
      this.Invalidate();
      this.OnCopiedHex(EventArgs.Empty);
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
      switch (this._borderStyle)
      {
        case BorderStyle.FixedSingle:
          e.Graphics.FillRectangle((Brush) new SolidBrush(this.BackColor), this.ClientRectangle);
          ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
          break;
        case BorderStyle.Fixed3D:
          if (TextBoxRenderer.IsSupported)
          {
            VisualStyleElement element = VisualStyleElement.TextBox.TextEdit.Normal;
            Color color = this.BackColor;
            if (this.Enabled)
            {
              if (this.ReadOnly)
                element = VisualStyleElement.TextBox.TextEdit.ReadOnly;
              else if (this.Focused)
                element = VisualStyleElement.TextBox.TextEdit.Focused;
            }
            else
            {
              element = VisualStyleElement.TextBox.TextEdit.Disabled;
              color = this.BackColorDisabled;
            }
            VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(element);
            visualStyleRenderer.DrawBackground((IDeviceContext) e.Graphics, this.ClientRectangle);
            Rectangle contentRectangle = visualStyleRenderer.GetBackgroundContentRectangle((IDeviceContext) e.Graphics, this.ClientRectangle);
            e.Graphics.FillRectangle((Brush) new SolidBrush(color), contentRectangle);
            break;
          }
          e.Graphics.FillRectangle((Brush) new SolidBrush(this.BackColor), this.ClientRectangle);
          ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.Sunken);
          break;
        default:
          e.Graphics.FillRectangle((Brush) new SolidBrush(this.BackColor), this.ClientRectangle);
          break;
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      if (this._byteProvider == null)
        return;
      Region region = new Region(this.ClientRectangle);
      region.Exclude(this._recContent);
      e.Graphics.ExcludeClip(region);
      this.UpdateVisibilityBytes();
      if (this._lineInfoVisible)
        this.PaintLineInfo(e.Graphics, this._startByte, this._endByte);
      if (!this._stringViewVisible)
      {
        this.PaintHex(e.Graphics, this._startByte, this._endByte);
      }
      else
      {
        this.PaintHexAndStringView(e.Graphics, this._startByte, this._endByte);
        if (!this._shadowSelectionVisible)
          return;
        this.PaintCurrentBytesSign(e.Graphics);
      }
    }

    private void PaintLineInfo(Graphics g, long startByte, long endByte)
    {
      endByte = Math.Min(this._byteProvider.Length - 1L, endByte);
      Brush brush = (Brush) new SolidBrush(this.LineInfoForeColor != Color.Empty ? this.LineInfoForeColor : this.ForeColor);
      int num1 = this.GetGridBytePoint(endByte - startByte).Y + 1;
      for (int y = 0; y < num1; ++y)
      {
        long num2 = startByte + (long) (this._iHexMaxHBytes * y) + this._lineInfoOffset;
        PointF bytePointF = this.GetBytePointF(new Point(0, y));
        string str = num2.ToString(this._hexStringFormat, (IFormatProvider) Thread.CurrentThread.CurrentCulture);
        string s = 8 - str.Length <= -1 ? new string('~', 8) : new string('0', 8 - str.Length) + str;
        g.DrawString(s, this.Font, brush, new PointF((float) this._recLineInfo.X, bytePointF.Y), this._stringFormat);
      }
    }

    private void PaintHex(Graphics g, long startByte, long endByte)
    {
      Brush brush1 = (Brush) new SolidBrush(this.GetDefaultForeColor());
      Brush brush2 = (Brush) new SolidBrush(this._selectionForeColor);
      Brush brushBack = (Brush) new SolidBrush(this._selectionBackColor);
      int num1 = -1;
      long num2 = Math.Min(this._byteProvider.Length - 1L, endByte + (long) this._iHexMaxHBytes);
      bool flag = this._keyInterpreter == null || this._keyInterpreter.GetType() == typeof (HexBox.KeyInterpreter);
      for (long index = startByte; index < num2 + 1L; ++index)
      {
        ++num1;
        Point gridBytePoint = this.GetGridBytePoint((long) num1);
        byte b = this._byteProvider.ReadByte(index);
        if (index >= this._bytePos && index <= this._bytePos + this._selectionLength - 1L && this._selectionLength != 0L && flag)
          this.PaintHexStringSelected(g, b, brush2, brushBack, gridBytePoint);
        else
          this.PaintHexString(g, b, brush1, gridBytePoint);
      }
    }

    private void PaintHexString(Graphics g, byte b, Brush brush, Point gridPoint)
    {
      PointF bytePointF = this.GetBytePointF(gridPoint);
      string hex = this.ConvertByteToHex(b);
      g.DrawString(hex.Substring(0, 1), this.Font, brush, bytePointF, this._stringFormat);
      bytePointF.X += this._charSize.Width;
      g.DrawString(hex.Substring(1, 1), this.Font, brush, bytePointF, this._stringFormat);
    }

    private void PaintHexStringSelected(
      Graphics g,
      byte b,
      Brush brush,
      Brush brushBack,
      Point gridPoint)
    {
      string str = b.ToString(this._hexStringFormat, (IFormatProvider) Thread.CurrentThread.CurrentCulture);
      if (str.Length == 1)
        str = "0" + str;
      PointF bytePointF = this.GetBytePointF(gridPoint);
      float width = gridPoint.X + 1 == this._iHexMaxHBytes ? this._charSize.Width * 2f : this._charSize.Width * 3f;
      g.FillRectangle(brushBack, bytePointF.X, bytePointF.Y, width, this._charSize.Height);
      g.DrawString(str.Substring(0, 1), this.Font, brush, bytePointF, this._stringFormat);
      bytePointF.X += this._charSize.Width;
      g.DrawString(str.Substring(1, 1), this.Font, brush, bytePointF, this._stringFormat);
    }

    private void PaintHexAndStringView(Graphics g, long startByte, long endByte)
    {
      Brush brush1 = (Brush) new SolidBrush(this.GetDefaultForeColor());
      Brush brush2 = (Brush) new SolidBrush(this._selectionForeColor);
      Brush brush3 = (Brush) new SolidBrush(this._selectionBackColor);
      int num1 = -1;
      long num2 = Math.Min(this._byteProvider.Length - 1L, endByte + (long) this._iHexMaxHBytes);
      bool flag1 = this._keyInterpreter == null || this._keyInterpreter.GetType() == typeof (HexBox.KeyInterpreter);
      bool flag2 = this._keyInterpreter != null && this._keyInterpreter.GetType() == typeof (HexBox.StringKeyInterpreter);
      for (long index = startByte; index < num2 + 1L; ++index)
      {
        ++num1;
        Point gridBytePoint = this.GetGridBytePoint((long) num1);
        PointF byteStringPointF = this.GetByteStringPointF(gridBytePoint);
        byte b = this._byteProvider.ReadByte(index);
        bool flag3 = index >= this._bytePos && index <= this._bytePos + this._selectionLength - 1L && this._selectionLength != 0L;
        if (flag3 && flag1)
          this.PaintHexStringSelected(g, b, brush2, brush3, gridBytePoint);
        else
          this.PaintHexString(g, b, brush1, gridBytePoint);
        string s = new string(this.ByteCharConverter.ToChar(b), 1);
        if (flag3 && flag2)
        {
          g.FillRectangle(brush3, byteStringPointF.X, byteStringPointF.Y, this._charSize.Width, this._charSize.Height);
          g.DrawString(s, this.Font, brush2, byteStringPointF, this._stringFormat);
        }
        else
          g.DrawString(s, this.Font, brush1, byteStringPointF, this._stringFormat);
      }
    }

    private void PaintCurrentBytesSign(Graphics g)
    {
      if (this._keyInterpreter == null || !this.Focused || (this._bytePos == -1L || !this.Enabled))
        return;
      if (this._keyInterpreter.GetType() == typeof (HexBox.KeyInterpreter))
      {
        if (this._selectionLength == 0L)
        {
          PointF byteStringPointF = this.GetByteStringPointF(this.GetGridBytePoint(this._bytePos - this._startByte));
          Size size = new Size((int) this._charSize.Width, (int) this._charSize.Height);
          Rectangle rec = new Rectangle((int) byteStringPointF.X, (int) byteStringPointF.Y, size.Width, size.Height);
          if (!rec.IntersectsWith(this._recStringView))
            return;
          rec.Intersect(this._recStringView);
          this.PaintCurrentByteSign(g, rec);
        }
        else
        {
          int num1 = (int) ((double) this._recStringView.Width - (double) this._charSize.Width);
          Point gridBytePoint1 = this.GetGridBytePoint(this._bytePos - this._startByte);
          PointF byteStringPointF1 = this.GetByteStringPointF(gridBytePoint1);
          Point gridBytePoint2 = this.GetGridBytePoint(this._bytePos - this._startByte + this._selectionLength - 1L);
          PointF byteStringPointF2 = this.GetByteStringPointF(gridBytePoint2);
          int num2 = gridBytePoint2.Y - gridBytePoint1.Y;
          if (num2 == 0)
          {
            Rectangle rec = new Rectangle((int) byteStringPointF1.X, (int) byteStringPointF1.Y, (int) ((double) byteStringPointF2.X - (double) byteStringPointF1.X + (double) this._charSize.Width), (int) this._charSize.Height);
            if (!rec.IntersectsWith(this._recStringView))
              return;
            rec.Intersect(this._recStringView);
            this.PaintCurrentByteSign(g, rec);
          }
          else
          {
            Rectangle rec1 = new Rectangle((int) byteStringPointF1.X, (int) byteStringPointF1.Y, (int) ((double) (this._recStringView.X + num1) - (double) byteStringPointF1.X + (double) this._charSize.Width), (int) this._charSize.Height);
            if (rec1.IntersectsWith(this._recStringView))
            {
              rec1.Intersect(this._recStringView);
              this.PaintCurrentByteSign(g, rec1);
            }
            if (num2 > 1)
            {
              Rectangle rec2 = new Rectangle(this._recStringView.X, (int) ((double) byteStringPointF1.Y + (double) this._charSize.Height), this._recStringView.Width, (int) ((double) this._charSize.Height * (double) (num2 - 1)));
              if (rec2.IntersectsWith(this._recStringView))
              {
                rec2.Intersect(this._recStringView);
                this.PaintCurrentByteSign(g, rec2);
              }
            }
            Rectangle rec3 = new Rectangle(this._recStringView.X, (int) byteStringPointF2.Y, (int) ((double) byteStringPointF2.X - (double) this._recStringView.X + (double) this._charSize.Width), (int) this._charSize.Height);
            if (!rec3.IntersectsWith(this._recStringView))
              return;
            rec3.Intersect(this._recStringView);
            this.PaintCurrentByteSign(g, rec3);
          }
        }
      }
      else if (this._selectionLength == 0L)
      {
        PointF bytePointF = this.GetBytePointF(this.GetGridBytePoint(this._bytePos - this._startByte));
        Size size = new Size((int) this._charSize.Width * 2, (int) this._charSize.Height);
        Rectangle rec = new Rectangle((int) bytePointF.X, (int) bytePointF.Y, size.Width, size.Height);
        this.PaintCurrentByteSign(g, rec);
      }
      else
      {
        int num1 = (int) ((double) this._recHex.Width - (double) this._charSize.Width * 5.0);
        Point gridBytePoint1 = this.GetGridBytePoint(this._bytePos - this._startByte);
        PointF bytePointF1 = this.GetBytePointF(gridBytePoint1);
        Point gridBytePoint2 = this.GetGridBytePoint(this._bytePos - this._startByte + this._selectionLength - 1L);
        PointF bytePointF2 = this.GetBytePointF(gridBytePoint2);
        int num2 = gridBytePoint2.Y - gridBytePoint1.Y;
        if (num2 == 0)
        {
          Rectangle rec = new Rectangle((int) bytePointF1.X, (int) bytePointF1.Y, (int) ((double) bytePointF2.X - (double) bytePointF1.X + (double) this._charSize.Width * 2.0), (int) this._charSize.Height);
          if (!rec.IntersectsWith(this._recHex))
            return;
          rec.Intersect(this._recHex);
          this.PaintCurrentByteSign(g, rec);
        }
        else
        {
          Rectangle rec1 = new Rectangle((int) bytePointF1.X, (int) bytePointF1.Y, (int) ((double) (this._recHex.X + num1) - (double) bytePointF1.X + (double) this._charSize.Width * 2.0), (int) this._charSize.Height);
          if (rec1.IntersectsWith(this._recHex))
          {
            rec1.Intersect(this._recHex);
            this.PaintCurrentByteSign(g, rec1);
          }
          if (num2 > 1)
          {
            Rectangle rec2 = new Rectangle(this._recHex.X, (int) ((double) bytePointF1.Y + (double) this._charSize.Height), (int) ((double) num1 + (double) this._charSize.Width * 2.0), (int) ((double) this._charSize.Height * (double) (num2 - 1)));
            if (rec2.IntersectsWith(this._recHex))
            {
              rec2.Intersect(this._recHex);
              this.PaintCurrentByteSign(g, rec2);
            }
          }
          Rectangle rec3 = new Rectangle(this._recHex.X, (int) bytePointF2.Y, (int) ((double) bytePointF2.X - (double) this._recHex.X + (double) this._charSize.Width * 2.0), (int) this._charSize.Height);
          if (!rec3.IntersectsWith(this._recHex))
            return;
          rec3.Intersect(this._recHex);
          this.PaintCurrentByteSign(g, rec3);
        }
      }
    }

    private void PaintCurrentByteSign(Graphics g, Rectangle rec)
    {
      if (rec.Top < 0 || rec.Left < 0 || (rec.Width <= 0 || rec.Height <= 0))
        return;
      Bitmap bitmap = new Bitmap(rec.Width, rec.Height);
      Graphics.FromImage((Image) bitmap).FillRectangle((Brush) new SolidBrush(this._shadowSelectionColor), 0, 0, rec.Width, rec.Height);
      g.CompositingQuality = CompositingQuality.GammaCorrected;
      g.DrawImage((Image) bitmap, rec.Left, rec.Top);
    }

    private Color GetDefaultForeColor()
    {
      return this.Enabled ? this.ForeColor : Color.Gray;
    }

    private void UpdateVisibilityBytes()
    {
      if (this._byteProvider == null || this._byteProvider.Length == 0L)
        return;
      this._startByte = (this._scrollVpos + 1L) * (long) this._iHexMaxHBytes - (long) this._iHexMaxHBytes;
      this._endByte = Math.Min(this._byteProvider.Length - 1L, this._startByte + (long) this._iHexMaxBytes);
    }

    private void UpdateRectanglePositioning()
    {
      SizeF sizeF = this.CreateGraphics().MeasureString("A", this.Font, 100, this._stringFormat);
      this._charSize = new SizeF((float) Math.Ceiling((double) sizeF.Width), (float) Math.Ceiling((double) sizeF.Height));
      this._recContent = this.ClientRectangle;
      this._recContent.X += this._recBorderLeft;
      this._recContent.Y += this._recBorderTop;
      this._recContent.Width -= this._recBorderRight + this._recBorderLeft;
      this._recContent.Height -= this._recBorderBottom + this._recBorderTop;
      if (this._vScrollBarVisible)
      {
        this._recContent.Width -= this._vScrollBar.Width;
        this._vScrollBar.Left = this._recContent.X + this._recContent.Width;
        this._vScrollBar.Top = this._recContent.Y;
        this._vScrollBar.Height = this._recContent.Height;
      }
      int num1 = 4;
      if (this._lineInfoVisible)
      {
        this._recLineInfo = new Rectangle(this._recContent.X + num1, this._recContent.Y, (int) ((double) this._charSize.Width * 10.0), this._recContent.Height);
      }
      else
      {
        this._recLineInfo = Rectangle.Empty;
        this._recLineInfo.X = num1;
      }
      this._recHex = new Rectangle(this._recLineInfo.X + this._recLineInfo.Width, this._recLineInfo.Y, this._recContent.Width - this._recLineInfo.Width, this._recContent.Height);
      if (this.UseFixedBytesPerLine)
      {
        this.SetHorizontalByteCount(this._bytesPerLine);
        this._recHex.Width = (int) Math.Floor((double) this._iHexMaxHBytes * (double) this._charSize.Width * 3.0 + 2.0 * (double) this._charSize.Width);
      }
      else
      {
        int num2 = (int) Math.Floor((double) this._recHex.Width / (double) this._charSize.Width);
        if (num2 > 1)
          this.SetHorizontalByteCount((int) Math.Floor((double) num2 / 3.0));
        else
          this.SetHorizontalByteCount(num2);
      }
      this._recStringView = !this._stringViewVisible ? Rectangle.Empty : new Rectangle(this._recHex.X + this._recHex.Width, this._recHex.Y, (int) ((double) this._charSize.Width * (double) this._iHexMaxHBytes), this._recHex.Height);
      this.SetVerticalByteCount((int) Math.Floor((double) this._recHex.Height / (double) this._charSize.Height));
      this._iHexMaxBytes = this._iHexMaxHBytes * this._iHexMaxVBytes;
      this.UpdateScrollSize();
    }

    private PointF GetBytePointF(long byteIndex)
    {
      return this.GetBytePointF(this.GetGridBytePoint(byteIndex));
    }

    private PointF GetBytePointF(Point gp)
    {
      return new PointF(3f * this._charSize.Width * (float) gp.X + (float) this._recHex.X, (float) (gp.Y + 1) * this._charSize.Height - this._charSize.Height + (float) this._recHex.Y);
    }

    private PointF GetByteStringPointF(Point gp)
    {
      return new PointF(this._charSize.Width * (float) gp.X + (float) this._recStringView.X, (float) (gp.Y + 1) * this._charSize.Height - this._charSize.Height + (float) this._recStringView.Y);
    }

    private Point GetGridBytePoint(long byteIndex)
    {
      int y = (int) Math.Floor((double) byteIndex / (double) this._iHexMaxHBytes);
      return new Point((int) (byteIndex + (long) this._iHexMaxHBytes - (long) (this._iHexMaxHBytes * (y + 1))), y);
    }

    [DefaultValue(typeof (Color), "White")]
    public override Color BackColor
    {
      get
      {
        return base.BackColor;
      }
      set
      {
        base.BackColor = value;
      }
    }

    public override Font Font
    {
      get
      {
        return base.Font;
      }
      set
      {
        base.Font = value;
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Bindable(false)]
    [Browsable(false)]
    public override string Text
    {
      get
      {
        return base.Text;
      }
      set
      {
        base.Text = value;
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Bindable(false)]
    public override RightToLeft RightToLeft
    {
      get
      {
        return base.RightToLeft;
      }
      set
      {
        base.RightToLeft = value;
      }
    }

    [DefaultValue(typeof (Color), "WhiteSmoke")]
    [Category("Appearance")]
    public Color BackColorDisabled
    {
      get
      {
        return this._backColorDisabled;
      }
      set
      {
        this._backColorDisabled = value;
      }
    }

    [Category("Hex")]
    [DefaultValue(false)]
    [Description("Gets or sets if the count of bytes in one line is fix.")]
    public bool ReadOnly
    {
      get
      {
        return this._readOnly;
      }
      set
      {
        if (this._readOnly == value)
          return;
        this._readOnly = value;
        this.OnReadOnlyChanged(EventArgs.Empty);
        this.Invalidate();
      }
    }

    [DefaultValue(16)]
    [Description("Gets or sets the maximum count of bytes in one line.")]
    [Category("Hex")]
    public int BytesPerLine
    {
      get
      {
        return this._bytesPerLine;
      }
      set
      {
        if (this._bytesPerLine == value)
          return;
        this._bytesPerLine = value;
        this.OnBytesPerLineChanged(EventArgs.Empty);
        this.UpdateRectanglePositioning();
        this.Invalidate();
      }
    }

    [DefaultValue(false)]
    [Category("Hex")]
    [Description("Gets or sets if the count of bytes in one line is fix.")]
    public bool UseFixedBytesPerLine
    {
      get
      {
        return this._useFixedBytesPerLine;
      }
      set
      {
        if (this._useFixedBytesPerLine == value)
          return;
        this._useFixedBytesPerLine = value;
        this.OnUseFixedBytesPerLineChanged(EventArgs.Empty);
        this.UpdateRectanglePositioning();
        this.Invalidate();
      }
    }

    [DefaultValue(false)]
    [Category("Hex")]
    [Description("Gets or sets the visibility of a vertical scroll bar.")]
    public bool VScrollBarVisible
    {
      get
      {
        return this._vScrollBarVisible;
      }
      set
      {
        if (this._vScrollBarVisible == value)
          return;
        this._vScrollBarVisible = value;
        if (this._vScrollBarVisible)
          this.Controls.Add((Control) this._vScrollBar);
        else
          this.Controls.Remove((Control) this._vScrollBar);
        this.UpdateRectanglePositioning();
        this.UpdateScrollSize();
        this.OnVScrollBarVisibleChanged(EventArgs.Empty);
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public IByteProvider ByteProvider
    {
      get
      {
        return this._byteProvider;
      }
      set
      {
        if (this._byteProvider == value)
          return;
        if (value == null)
          this.ActivateEmptyKeyInterpreter();
        else
          this.ActivateKeyInterpreter();
        if (this._byteProvider != null)
          this._byteProvider.LengthChanged -= new EventHandler(this._byteProvider_LengthChanged);
        this._byteProvider = value;
        if (this._byteProvider != null)
          this._byteProvider.LengthChanged += new EventHandler(this._byteProvider_LengthChanged);
        this.OnByteProviderChanged(EventArgs.Empty);
        if (value == null)
        {
          this._bytePos = -1L;
          this._byteCharacterPos = 0;
          this._selectionLength = 0L;
          this.DestroyCaret();
        }
        else
        {
          this.SetPosition(0L, 0);
          this.SetSelectionLength(0L);
          if (this._caretVisible && this.Focused)
            this.UpdateCaret();
          else
            this.CreateCaret();
        }
        this.CheckCurrentLineChanged();
        this.CheckCurrentPositionInLineChanged();
        this._scrollVpos = 0L;
        this.UpdateVisibilityBytes();
        this.UpdateRectanglePositioning();
        this.Invalidate();
      }
    }

    [Description("Gets or sets the visibility of a line info.")]
    [DefaultValue(false)]
    [Category("Hex")]
    public bool LineInfoVisible
    {
      get
      {
        return this._lineInfoVisible;
      }
      set
      {
        if (this._lineInfoVisible == value)
          return;
        this._lineInfoVisible = value;
        this.OnLineInfoVisibleChanged(EventArgs.Empty);
        this.UpdateRectanglePositioning();
        this.Invalidate();
      }
    }

    [Description("Gets or sets the offset of the line info.")]
    [DefaultValue(0)]
    [Category("Hex")]
    public long LineInfoOffset
    {
      get
      {
        return this._lineInfoOffset;
      }
      set
      {
        if (this._lineInfoOffset == value)
          return;
        this._lineInfoOffset = value;
        this.Invalidate();
      }
    }

    [Category("Hex")]
    [DefaultValue(typeof (BorderStyle), "Fixed3D")]
    [Description("Gets or sets the hex box´s border style.")]
    public BorderStyle BorderStyle
    {
      get
      {
        return this._borderStyle;
      }
      set
      {
        if (this._borderStyle == value)
          return;
        this._borderStyle = value;
        switch (this._borderStyle)
        {
          case BorderStyle.None:
            this._recBorderLeft = this._recBorderTop = this._recBorderRight = this._recBorderBottom = 0;
            break;
          case BorderStyle.FixedSingle:
            this._recBorderLeft = this._recBorderTop = this._recBorderRight = this._recBorderBottom = 1;
            break;
          case BorderStyle.Fixed3D:
            this._recBorderLeft = this._recBorderRight = SystemInformation.Border3DSize.Width;
            this._recBorderTop = this._recBorderBottom = SystemInformation.Border3DSize.Height;
            break;
        }
        this.UpdateRectanglePositioning();
        this.OnBorderStyleChanged(EventArgs.Empty);
      }
    }

    [DefaultValue(false)]
    [Category("Hex")]
    [Description("Gets or sets the visibility of the string view.")]
    public bool StringViewVisible
    {
      get
      {
        return this._stringViewVisible;
      }
      set
      {
        if (this._stringViewVisible == value)
          return;
        this._stringViewVisible = value;
        this.OnStringViewVisibleChanged(EventArgs.Empty);
        this.UpdateRectanglePositioning();
        this.Invalidate();
      }
    }

    [Category("Hex")]
    [Description("Gets or sets whether the HexBox control displays the hex characters in upper or lower case.")]
    [DefaultValue(typeof (HexCasing), "Upper")]
    public HexCasing HexCasing
    {
      get
      {
        return this._hexStringFormat == "X" ? HexCasing.Upper : HexCasing.Lower;
      }
      set
      {
        string str = value != HexCasing.Upper ? "x" : "X";
        if (this._hexStringFormat == str)
          return;
        this._hexStringFormat = str;
        this.OnHexCasingChanged(EventArgs.Empty);
        this.Invalidate();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public long SelectionStart
    {
      get
      {
        return this._bytePos;
      }
      set
      {
        this.SetPosition(value, 0);
        this.ScrollByteIntoView();
        this.Invalidate();
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public long SelectionLength
    {
      get
      {
        return this._selectionLength;
      }
      set
      {
        this.SetSelectionLength(value);
        this.ScrollByteIntoView();
        this.Invalidate();
      }
    }

    [DefaultValue(typeof (Color), "Empty")]
    [Description("Gets or sets the line info color. When this property is null, then ForeColor property is used.")]
    [Category("Hex")]
    public Color LineInfoForeColor
    {
      get
      {
        return this._lineInfoForeColor;
      }
      set
      {
        this._lineInfoForeColor = value;
        this.Invalidate();
      }
    }

    [Description("Gets or sets the background color for the selected bytes.")]
    [DefaultValue(typeof (Color), "Blue")]
    [Category("Hex")]
    public Color SelectionBackColor
    {
      get
      {
        return this._selectionBackColor;
      }
      set
      {
        this._selectionBackColor = value;
        this.Invalidate();
      }
    }

    [Category("Hex")]
    [DefaultValue(typeof (Color), "White")]
    [Description("Gets or sets the foreground color for the selected bytes.")]
    public Color SelectionForeColor
    {
      get
      {
        return this._selectionForeColor;
      }
      set
      {
        this._selectionForeColor = value;
        this.Invalidate();
      }
    }

    [Category("Hex")]
    [DefaultValue(true)]
    [Description("Gets or sets the visibility of a shadow selection.")]
    public bool ShadowSelectionVisible
    {
      get
      {
        return this._shadowSelectionVisible;
      }
      set
      {
        if (this._shadowSelectionVisible == value)
          return;
        this._shadowSelectionVisible = value;
        this.Invalidate();
      }
    }

    [Category("Hex")]
    [Description("Gets or sets the color of the shadow selection.")]
    public Color ShadowSelectionColor
    {
      get
      {
        return this._shadowSelectionColor;
      }
      set
      {
        this._shadowSelectionColor = value;
        this.Invalidate();
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public int HorizontalByteCount
    {
      get
      {
        return this._iHexMaxHBytes;
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int VerticalByteCount
    {
      get
      {
        return this._iHexMaxVBytes;
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public long CurrentLine
    {
      get
      {
        return this._currentLine;
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public long CurrentPositionInLine
    {
      get
      {
        return (long) this._currentPositionInLine;
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public bool InsertActive
    {
      get
      {
        return this._insertActive;
      }
      set
      {
        if (this._insertActive == value)
          return;
        this._insertActive = value;
        this.DestroyCaret();
        this.CreateCaret();
        this.OnInsertActiveChanged(EventArgs.Empty);
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public BuiltInContextMenu BuiltInContextMenu
    {
      get
      {
        return this._builtInContextMenu;
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IByteCharConverter ByteCharConverter
    {
      get
      {
        if (this._byteCharConverter == null)
          this._byteCharConverter = (IByteCharConverter) new DefaultByteCharConverter();
        return this._byteCharConverter;
      }
      set
      {
        if (value == null || value == this._byteCharConverter)
          return;
        this._byteCharConverter = value;
        this.Invalidate();
      }
    }

    private string ConvertBytesToHex(byte[] data)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (byte b in data)
      {
        string hex = this.ConvertByteToHex(b);
        stringBuilder.Append(hex);
        stringBuilder.Append(" ");
      }
      if (stringBuilder.Length > 0)
        stringBuilder.Remove(stringBuilder.Length - 1, 1);
      return stringBuilder.ToString();
    }

    private string ConvertByteToHex(byte b)
    {
      string str = b.ToString(this._hexStringFormat, (IFormatProvider) Thread.CurrentThread.CurrentCulture);
      if (str.Length == 1)
        str = "0" + str;
      return str;
    }

    private byte[] ConvertHexToBytes(string hex)
    {
      if (string.IsNullOrEmpty(hex))
        return (byte[]) null;
      hex = hex.Trim();
      string[] strArray = hex.Split(' ');
      byte[] numArray = new byte[strArray.Length];
      for (int index = 0; index < strArray.Length; ++index)
      {
        byte b;
        if (!this.ConvertHexToByte(strArray[index], out b))
          return (byte[]) null;
        numArray[index] = b;
      }
      return numArray;
    }

    private bool ConvertHexToByte(string hex, out byte b)
    {
      return byte.TryParse(hex, NumberStyles.HexNumber, (IFormatProvider) Thread.CurrentThread.CurrentCulture, out b);
    }

    private void SetPosition(long bytePos)
    {
      this.SetPosition(bytePos, this._byteCharacterPos);
    }

    private void SetPosition(long bytePos, int byteCharacterPos)
    {
      if (this._byteCharacterPos != byteCharacterPos)
        this._byteCharacterPos = byteCharacterPos;
      if (bytePos == this._bytePos)
        return;
      this._bytePos = bytePos;
      this.CheckCurrentLineChanged();
      this.CheckCurrentPositionInLineChanged();
      this.OnSelectionStartChanged(EventArgs.Empty);
    }

    private void SetSelectionLength(long selectionLength)
    {
      if (selectionLength == this._selectionLength)
        return;
      this._selectionLength = selectionLength;
      this.OnSelectionLengthChanged(EventArgs.Empty);
    }

    private void SetHorizontalByteCount(int value)
    {
      if (this._iHexMaxHBytes == value)
        return;
      this._iHexMaxHBytes = value;
      this.OnHorizontalByteCountChanged(EventArgs.Empty);
    }

    private void SetVerticalByteCount(int value)
    {
      if (this._iHexMaxVBytes == value)
        return;
      this._iHexMaxVBytes = value;
      this.OnVerticalByteCountChanged(EventArgs.Empty);
    }

    private void CheckCurrentLineChanged()
    {
      long num = (long) Math.Floor((double) this._bytePos / (double) this._iHexMaxHBytes) + 1L;
      if (this._byteProvider == null && this._currentLine != 0L)
      {
        this._currentLine = 0L;
        this.OnCurrentLineChanged(EventArgs.Empty);
      }
      else
      {
        if (num == this._currentLine)
          return;
        this._currentLine = num;
        this.OnCurrentLineChanged(EventArgs.Empty);
      }
    }

    private void CheckCurrentPositionInLineChanged()
    {
      int num = this.GetGridBytePoint(this._bytePos).X + 1;
      if (this._byteProvider == null && this._currentPositionInLine != 0)
      {
        this._currentPositionInLine = 0;
        this.OnCurrentPositionInLineChanged(EventArgs.Empty);
      }
      else
      {
        if (num == this._currentPositionInLine)
          return;
        this._currentPositionInLine = num;
        this.OnCurrentPositionInLineChanged(EventArgs.Empty);
      }
    }

    protected virtual void OnInsertActiveChanged(EventArgs e)
    {
      if (this.InsertActiveChanged == null)
        return;
      this.InsertActiveChanged((object) this, e);
    }

    protected virtual void OnReadOnlyChanged(EventArgs e)
    {
      if (this.ReadOnlyChanged == null)
        return;
      this.ReadOnlyChanged((object) this, e);
    }

    protected virtual void OnByteProviderChanged(EventArgs e)
    {
      if (this.ByteProviderChanged == null)
        return;
      this.ByteProviderChanged((object) this, e);
    }

    protected virtual void OnSelectionStartChanged(EventArgs e)
    {
      if (this.SelectionStartChanged == null)
        return;
      this.SelectionStartChanged((object) this, e);
    }

    protected virtual void OnSelectionLengthChanged(EventArgs e)
    {
      if (this.SelectionLengthChanged == null)
        return;
      this.SelectionLengthChanged((object) this, e);
    }

    protected virtual void OnLineInfoVisibleChanged(EventArgs e)
    {
      if (this.LineInfoVisibleChanged == null)
        return;
      this.LineInfoVisibleChanged((object) this, e);
    }

    protected virtual void OnStringViewVisibleChanged(EventArgs e)
    {
      if (this.StringViewVisibleChanged == null)
        return;
      this.StringViewVisibleChanged((object) this, e);
    }

    protected virtual void OnBorderStyleChanged(EventArgs e)
    {
      if (this.BorderStyleChanged == null)
        return;
      this.BorderStyleChanged((object) this, e);
    }

    protected virtual void OnUseFixedBytesPerLineChanged(EventArgs e)
    {
      if (this.UseFixedBytesPerLineChanged == null)
        return;
      this.UseFixedBytesPerLineChanged((object) this, e);
    }

    protected virtual void OnBytesPerLineChanged(EventArgs e)
    {
      if (this.BytesPerLineChanged == null)
        return;
      this.BytesPerLineChanged((object) this, e);
    }

    protected virtual void OnVScrollBarVisibleChanged(EventArgs e)
    {
      if (this.VScrollBarVisibleChanged == null)
        return;
      this.VScrollBarVisibleChanged((object) this, e);
    }

    protected virtual void OnHexCasingChanged(EventArgs e)
    {
      if (this.HexCasingChanged == null)
        return;
      this.HexCasingChanged((object) this, e);
    }

    protected virtual void OnHorizontalByteCountChanged(EventArgs e)
    {
      if (this.HorizontalByteCountChanged == null)
        return;
      this.HorizontalByteCountChanged((object) this, e);
    }

    protected virtual void OnVerticalByteCountChanged(EventArgs e)
    {
      if (this.VerticalByteCountChanged == null)
        return;
      this.VerticalByteCountChanged((object) this, e);
    }

    protected virtual void OnCurrentLineChanged(EventArgs e)
    {
      if (this.CurrentLineChanged == null)
        return;
      this.CurrentLineChanged((object) this, e);
    }

    protected virtual void OnCurrentPositionInLineChanged(EventArgs e)
    {
      if (this.CurrentPositionInLineChanged == null)
        return;
      this.CurrentPositionInLineChanged((object) this, e);
    }

    protected virtual void OnCopied(EventArgs e)
    {
      if (this.Copied == null)
        return;
      this.Copied((object) this, e);
    }

    protected virtual void OnCopiedHex(EventArgs e)
    {
      if (this.CopiedHex == null)
        return;
      this.CopiedHex((object) this, e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (!this.Focused)
        this.Focus();
      if (e.Button == MouseButtons.Left)
        this.SetCaretPosition(new Point(e.X, e.Y));
      base.OnMouseDown(e);
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
      this.PerformScrollLines(-(e.Delta * SystemInformation.MouseWheelScrollLines / 120));
      base.OnMouseWheel(e);
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      this.UpdateRectanglePositioning();
    }

    protected override void OnGotFocus(EventArgs e)
    {
      base.OnGotFocus(e);
      this.CreateCaret();
    }

    protected override void OnLostFocus(EventArgs e)
    {
      base.OnLostFocus(e);
      this.DestroyCaret();
    }

    private void _byteProvider_LengthChanged(object sender, EventArgs e)
    {
      this.UpdateScrollSize();
    }

    private interface IKeyInterpreter
    {
      void Activate();

      void Deactivate();

      bool PreProcessWmKeyUp(ref Message m);

      bool PreProcessWmChar(ref Message m);

      bool PreProcessWmKeyDown(ref Message m);

      PointF GetCaretPointF(long byteIndex);
    }

    private class EmptyKeyInterpreter : HexBox.IKeyInterpreter
    {
      private HexBox _hexBox;

      public EmptyKeyInterpreter(HexBox hexBox)
      {
        this._hexBox = hexBox;
      }

      public void Activate()
      {
      }

      public void Deactivate()
      {
      }

      public bool PreProcessWmKeyUp(ref Message m)
      {
        return this._hexBox.BasePreProcessMessage(ref m);
      }

      public bool PreProcessWmChar(ref Message m)
      {
        return this._hexBox.BasePreProcessMessage(ref m);
      }

      public bool PreProcessWmKeyDown(ref Message m)
      {
        return this._hexBox.BasePreProcessMessage(ref m);
      }

      public PointF GetCaretPointF(long byteIndex)
      {
        return new PointF();
      }
    }

    private class KeyInterpreter : HexBox.IKeyInterpreter
    {
      protected HexBox _hexBox;
      protected bool _shiftDown;
      private bool _mouseDown;
      private BytePositionInfo _bpiStart;
      private BytePositionInfo _bpi;
      private Dictionary<Keys, HexBox.KeyInterpreter.MessageDelegate> _messageHandlers;

      public KeyInterpreter(HexBox hexBox)
      {
        this._hexBox = hexBox;
      }

      public virtual void Activate()
      {
        this._hexBox.MouseDown += new MouseEventHandler(this.BeginMouseSelection);
        this._hexBox.MouseMove += new MouseEventHandler(this.UpdateMouseSelection);
        this._hexBox.MouseUp += new MouseEventHandler(this.EndMouseSelection);
      }

      public virtual void Deactivate()
      {
        this._hexBox.MouseDown -= new MouseEventHandler(this.BeginMouseSelection);
        this._hexBox.MouseMove -= new MouseEventHandler(this.UpdateMouseSelection);
        this._hexBox.MouseUp -= new MouseEventHandler(this.EndMouseSelection);
      }

      private void BeginMouseSelection(object sender, MouseEventArgs e)
      {
        if (e.Button != MouseButtons.Left)
          return;
        this._mouseDown = true;
        if (!this._shiftDown)
        {
          this._bpiStart = new BytePositionInfo(this._hexBox._bytePos, this._hexBox._byteCharacterPos);
          this._hexBox.ReleaseSelection();
        }
        else
          this.UpdateMouseSelection((object) this, e);
      }

      private void UpdateMouseSelection(object sender, MouseEventArgs e)
      {
        if (!this._mouseDown)
          return;
        this._bpi = this.GetBytePositionInfo(new Point(e.X, e.Y));
        long index = this._bpi.Index;
        long start;
        long length;
        if (index < this._bpiStart.Index)
        {
          start = index;
          length = this._bpiStart.Index - index;
        }
        else if (index > this._bpiStart.Index)
        {
          start = this._bpiStart.Index;
          length = index - start;
        }
        else
        {
          start = this._hexBox._bytePos;
          length = 0L;
        }
        if (start == this._hexBox._bytePos && length == this._hexBox._selectionLength)
          return;
        this._hexBox.InternalSelect(start, length);
        this._hexBox.ScrollByteIntoView(this._bpi.Index);
      }

      private void EndMouseSelection(object sender, MouseEventArgs e)
      {
        this._mouseDown = false;
      }

      public virtual bool PreProcessWmKeyDown(ref Message m)
      {
        Keys index = (Keys) m.WParam.ToInt32() | Control.ModifierKeys;
        bool flag = this.MessageHandlers.ContainsKey(index);
        HexBox.KeyInterpreter.MessageDelegate messageDelegate;
        return flag && this.RaiseKeyDown(index) || (flag ? this.MessageHandlers[index] : (messageDelegate = new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_Default)))(ref m);
      }

      protected bool PreProcessWmKeyDown_Default(ref Message m)
      {
        this._hexBox.ScrollByteIntoView();
        return this._hexBox.BasePreProcessMessage(ref m);
      }

      protected bool RaiseKeyDown(Keys keyData)
      {
        KeyEventArgs e = new KeyEventArgs(keyData);
        this._hexBox.OnKeyDown(e);
        return e.Handled;
      }

      protected virtual bool PreProcessWmKeyDown_Left(ref Message m)
      {
        return this.PerformPosMoveLeft();
      }

      protected virtual bool PreProcessWmKeyDown_Up(ref Message m)
      {
        long bytePos1 = this._hexBox._bytePos;
        int byteCharacterPos = this._hexBox._byteCharacterPos;
        if (bytePos1 != 0L || byteCharacterPos != 0)
        {
          long bytePos2 = Math.Max(-1L, bytePos1 - (long) this._hexBox._iHexMaxHBytes);
          if (bytePos2 == -1L)
            return true;
          this._hexBox.SetPosition(bytePos2);
          if (bytePos2 < this._hexBox._startByte)
            this._hexBox.PerformScrollLineUp();
          this._hexBox.UpdateCaret();
          this._hexBox.Invalidate();
        }
        this._hexBox.ScrollByteIntoView();
        this._hexBox.ReleaseSelection();
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_Right(ref Message m)
      {
        return this.PerformPosMoveRight();
      }

      protected virtual bool PreProcessWmKeyDown_Down(ref Message m)
      {
        long bytePos1 = this._hexBox._bytePos;
        int byteCharacterPos = this._hexBox._byteCharacterPos;
        if (bytePos1 == this._hexBox._byteProvider.Length && byteCharacterPos == 0)
          return true;
        long bytePos2 = Math.Min(this._hexBox._byteProvider.Length, bytePos1 + (long) this._hexBox._iHexMaxHBytes);
        if (bytePos2 == this._hexBox._byteProvider.Length)
          byteCharacterPos = 0;
        this._hexBox.SetPosition(bytePos2, byteCharacterPos);
        if (bytePos2 > this._hexBox._endByte - 1L)
          this._hexBox.PerformScrollLineDown();
        this._hexBox.UpdateCaret();
        this._hexBox.ScrollByteIntoView();
        this._hexBox.ReleaseSelection();
        this._hexBox.Invalidate();
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_PageUp(ref Message m)
      {
        long bytePos1 = this._hexBox._bytePos;
        int byteCharacterPos = this._hexBox._byteCharacterPos;
        if (bytePos1 == 0L && byteCharacterPos == 0)
          return true;
        long bytePos2 = Math.Max(0L, bytePos1 - (long) this._hexBox._iHexMaxBytes);
        if (bytePos2 == 0L)
          return true;
        this._hexBox.SetPosition(bytePos2);
        if (bytePos2 < this._hexBox._startByte)
          this._hexBox.PerformScrollPageUp();
        this._hexBox.ReleaseSelection();
        this._hexBox.UpdateCaret();
        this._hexBox.Invalidate();
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_PageDown(ref Message m)
      {
        long bytePos1 = this._hexBox._bytePos;
        int byteCharacterPos = this._hexBox._byteCharacterPos;
        if (bytePos1 == this._hexBox._byteProvider.Length && byteCharacterPos == 0)
          return true;
        long bytePos2 = Math.Min(this._hexBox._byteProvider.Length, bytePos1 + (long) this._hexBox._iHexMaxBytes);
        if (bytePos2 == this._hexBox._byteProvider.Length)
          byteCharacterPos = 0;
        this._hexBox.SetPosition(bytePos2, byteCharacterPos);
        if (bytePos2 > this._hexBox._endByte - 1L)
          this._hexBox.PerformScrollPageDown();
        this._hexBox.ReleaseSelection();
        this._hexBox.UpdateCaret();
        this._hexBox.Invalidate();
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_ShiftLeft(ref Message m)
      {
        long bytePos = this._hexBox._bytePos;
        long selectionLength = this._hexBox._selectionLength;
        if (bytePos + selectionLength < 1L)
          return true;
        long length;
        if (bytePos + selectionLength <= this._bpiStart.Index)
        {
          if (bytePos == 0L)
            return true;
          --bytePos;
          length = selectionLength + 1L;
        }
        else
          length = Math.Max(0L, selectionLength - 1L);
        this._hexBox.ScrollByteIntoView();
        this._hexBox.InternalSelect(bytePos, length);
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_ShiftUp(ref Message m)
      {
        long bytePos = this._hexBox._bytePos;
        long selectionLength = this._hexBox._selectionLength;
        if (bytePos - (long) this._hexBox._iHexMaxHBytes < 0L && bytePos <= this._bpiStart.Index)
          return true;
        if (this._bpiStart.Index >= bytePos + selectionLength)
        {
          this._hexBox.InternalSelect(bytePos - (long) this._hexBox._iHexMaxHBytes, selectionLength + (long) this._hexBox._iHexMaxHBytes);
          this._hexBox.ScrollByteIntoView();
        }
        else
        {
          long num = selectionLength - (long) this._hexBox._iHexMaxHBytes;
          if (num < 0L)
          {
            this._hexBox.InternalSelect(this._bpiStart.Index + num, -num);
            this._hexBox.ScrollByteIntoView();
          }
          else
          {
            long length = num - (long) this._hexBox._iHexMaxHBytes;
            this._hexBox.InternalSelect(bytePos, length);
            this._hexBox.ScrollByteIntoView(bytePos + length);
          }
        }
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_ShiftRight(ref Message m)
      {
        long bytePos = this._hexBox._bytePos;
        long selectionLength = this._hexBox._selectionLength;
        if (bytePos + selectionLength >= this._hexBox._byteProvider.Length)
          return true;
        if (this._bpiStart.Index <= bytePos)
        {
          long length = selectionLength + 1L;
          this._hexBox.InternalSelect(bytePos, length);
          this._hexBox.ScrollByteIntoView(bytePos + length);
        }
        else
        {
          this._hexBox.InternalSelect(bytePos + 1L, Math.Max(0L, selectionLength - 1L));
          this._hexBox.ScrollByteIntoView();
        }
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_ShiftDown(ref Message m)
      {
        long bytePos = this._hexBox._bytePos;
        long selectionLength = this._hexBox._selectionLength;
        long length1 = this._hexBox._byteProvider.Length;
        if (bytePos + selectionLength + (long) this._hexBox._iHexMaxHBytes > length1)
          return true;
        if (this._bpiStart.Index <= bytePos)
        {
          long length2 = selectionLength + (long) this._hexBox._iHexMaxHBytes;
          this._hexBox.InternalSelect(bytePos, length2);
          this._hexBox.ScrollByteIntoView(bytePos + length2);
        }
        else
        {
          long length2 = selectionLength - (long) this._hexBox._iHexMaxHBytes;
          long start;
          if (length2 < 0L)
          {
            start = this._bpiStart.Index;
            length2 = -length2;
          }
          else
            start = bytePos + (long) this._hexBox._iHexMaxHBytes;
          this._hexBox.InternalSelect(start, length2);
          this._hexBox.ScrollByteIntoView();
        }
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_Tab(ref Message m)
      {
        if (this._hexBox._stringViewVisible && this._hexBox._keyInterpreter.GetType() == typeof (HexBox.KeyInterpreter))
        {
          this._hexBox.ActivateStringKeyInterpreter();
          this._hexBox.ScrollByteIntoView();
          this._hexBox.ReleaseSelection();
          this._hexBox.UpdateCaret();
          this._hexBox.Invalidate();
          return true;
        }
        if (this._hexBox.Parent == null)
          return true;
        this._hexBox.Parent.SelectNextControl((Control) this._hexBox, true, true, true, true);
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_ShiftTab(ref Message m)
      {
        if (this._hexBox._keyInterpreter is HexBox.StringKeyInterpreter)
        {
          this._shiftDown = false;
          this._hexBox.ActivateKeyInterpreter();
          this._hexBox.ScrollByteIntoView();
          this._hexBox.ReleaseSelection();
          this._hexBox.UpdateCaret();
          this._hexBox.Invalidate();
          return true;
        }
        if (this._hexBox.Parent == null)
          return true;
        this._hexBox.Parent.SelectNextControl((Control) this._hexBox, false, true, true, true);
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_Back(ref Message m)
      {
        if (!this._hexBox._byteProvider.SupportsDeleteBytes() || this._hexBox.ReadOnly)
          return true;
        long bytePos = this._hexBox._bytePos;
        long selectionLength = this._hexBox._selectionLength;
        long val2 = this._hexBox._byteCharacterPos != 0 || selectionLength != 0L ? bytePos : bytePos - 1L;
        if (val2 < 0L && selectionLength < 1L)
          return true;
        long length = selectionLength > 0L ? selectionLength : 1L;
        this._hexBox._byteProvider.DeleteBytes(Math.Max(0L, val2), length);
        this._hexBox.UpdateScrollSize();
        if (selectionLength == 0L)
          this.PerformPosMoveLeftByte();
        this._hexBox.ReleaseSelection();
        this._hexBox.Invalidate();
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_Delete(ref Message m)
      {
        if (!this._hexBox._byteProvider.SupportsDeleteBytes() || this._hexBox.ReadOnly)
          return true;
        long bytePos = this._hexBox._bytePos;
        long selectionLength = this._hexBox._selectionLength;
        if (bytePos >= this._hexBox._byteProvider.Length)
          return true;
        long length = selectionLength > 0L ? selectionLength : 1L;
        this._hexBox._byteProvider.DeleteBytes(bytePos, length);
        this._hexBox.UpdateScrollSize();
        this._hexBox.ReleaseSelection();
        this._hexBox.Invalidate();
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_Home(ref Message m)
      {
        long bytePos = this._hexBox._bytePos;
        int byteCharacterPos = this._hexBox._byteCharacterPos;
        if (bytePos < 1L)
          return true;
        this._hexBox.SetPosition(0L, 0);
        this._hexBox.ScrollByteIntoView();
        this._hexBox.UpdateCaret();
        this._hexBox.ReleaseSelection();
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_End(ref Message m)
      {
        long bytePos = this._hexBox._bytePos;
        int byteCharacterPos = this._hexBox._byteCharacterPos;
        if (bytePos >= this._hexBox._byteProvider.Length - 1L)
          return true;
        this._hexBox.SetPosition(this._hexBox._byteProvider.Length, 0);
        this._hexBox.ScrollByteIntoView();
        this._hexBox.UpdateCaret();
        this._hexBox.ReleaseSelection();
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_ShiftShiftKey(ref Message m)
      {
        if (this._mouseDown || this._shiftDown)
          return true;
        this._shiftDown = true;
        if (this._hexBox._selectionLength > 0L)
          return true;
        this._bpiStart = new BytePositionInfo(this._hexBox._bytePos, this._hexBox._byteCharacterPos);
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_ControlC(ref Message m)
      {
        this._hexBox.Copy();
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_ControlX(ref Message m)
      {
        this._hexBox.Cut();
        return true;
      }

      protected virtual bool PreProcessWmKeyDown_ControlV(ref Message m)
      {
        this._hexBox.Paste();
        return true;
      }

      public virtual bool PreProcessWmChar(ref Message m)
      {
        if (Control.ModifierKeys == Keys.Control)
          return this._hexBox.BasePreProcessMessage(ref m);
        bool flag1 = this._hexBox._byteProvider.SupportsWriteByte();
        bool flag2 = this._hexBox._byteProvider.SupportsInsertBytes();
        bool flag3 = this._hexBox._byteProvider.SupportsDeleteBytes();
        long bytePos = this._hexBox._bytePos;
        long selectionLength = this._hexBox._selectionLength;
        int byteCharacterPos = this._hexBox._byteCharacterPos;
        if (!flag1 && bytePos != this._hexBox._byteProvider.Length || !flag2 && bytePos == this._hexBox._byteProvider.Length)
          return this._hexBox.BasePreProcessMessage(ref m);
        char int32 = (char) m.WParam.ToInt32();
        if (!Uri.IsHexDigit(int32))
          return this._hexBox.BasePreProcessMessage(ref m);
        if (this.RaiseKeyPress(int32) || this._hexBox.ReadOnly)
          return true;
        bool flag4 = bytePos == this._hexBox._byteProvider.Length;
        if (!flag4 && flag2 && (this._hexBox.InsertActive && byteCharacterPos == 0))
          flag4 = true;
        if (flag3 && flag2 && selectionLength > 0L)
        {
          this._hexBox._byteProvider.DeleteBytes(bytePos, selectionLength);
          flag4 = true;
          byteCharacterPos = 0;
          this._hexBox.SetPosition(bytePos, byteCharacterPos);
        }
        this._hexBox.ReleaseSelection();
        string str1 = (!flag4 ? this._hexBox._byteProvider.ReadByte(bytePos) : (byte) 0).ToString("X", (IFormatProvider) Thread.CurrentThread.CurrentCulture);
        if (str1.Length == 1)
          str1 = "0" + str1;
        string str2 = int32.ToString();
        byte num = byte.Parse(byteCharacterPos != 0 ? str1.Substring(0, 1) + str2 : str2 + str1.Substring(1, 1), NumberStyles.AllowHexSpecifier, (IFormatProvider) Thread.CurrentThread.CurrentCulture);
        if (flag4)
          this._hexBox._byteProvider.InsertBytes(bytePos, new byte[1]
          {
            num
          });
        else
          this._hexBox._byteProvider.WriteByte(bytePos, num);
        this.PerformPosMoveRight();
        this._hexBox.Invalidate();
        return true;
      }

      protected bool RaiseKeyPress(char keyChar)
      {
        KeyPressEventArgs e = new KeyPressEventArgs(keyChar);
        this._hexBox.OnKeyPress(e);
        return e.Handled;
      }

      public virtual bool PreProcessWmKeyUp(ref Message m)
      {
        Keys keyData = (Keys) m.WParam.ToInt32() | Control.ModifierKeys;
        switch (keyData)
        {
          case Keys.ShiftKey:
          case Keys.Insert:
            if (this.RaiseKeyUp(keyData))
              return true;
            break;
        }
        switch (keyData)
        {
          case Keys.ShiftKey:
            this._shiftDown = false;
            return true;
          case Keys.Insert:
            return this.PreProcessWmKeyUp_Insert(ref m);
          default:
            return this._hexBox.BasePreProcessMessage(ref m);
        }
      }

      protected virtual bool PreProcessWmKeyUp_Insert(ref Message m)
      {
        this._hexBox.InsertActive = !this._hexBox.InsertActive;
        return true;
      }

      protected bool RaiseKeyUp(Keys keyData)
      {
        KeyEventArgs e = new KeyEventArgs(keyData);
        this._hexBox.OnKeyUp(e);
        return e.Handled;
      }

      private Dictionary<Keys, HexBox.KeyInterpreter.MessageDelegate> MessageHandlers
      {
        get
        {
          if (this._messageHandlers == null)
          {
            this._messageHandlers = new Dictionary<Keys, HexBox.KeyInterpreter.MessageDelegate>();
            this._messageHandlers.Add(Keys.Left, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_Left));
            this._messageHandlers.Add(Keys.Up, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_Up));
            this._messageHandlers.Add(Keys.Right, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_Right));
            this._messageHandlers.Add(Keys.Down, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_Down));
            this._messageHandlers.Add(Keys.Prior, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_PageUp));
            this._messageHandlers.Add(Keys.Next, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_PageDown));
            this._messageHandlers.Add(Keys.Left | Keys.Shift, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_ShiftLeft));
            this._messageHandlers.Add(Keys.Up | Keys.Shift, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_ShiftUp));
            this._messageHandlers.Add(Keys.Right | Keys.Shift, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_ShiftRight));
            this._messageHandlers.Add(Keys.Down | Keys.Shift, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_ShiftDown));
            this._messageHandlers.Add(Keys.Tab, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_Tab));
            this._messageHandlers.Add(Keys.Back, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_Back));
            this._messageHandlers.Add(Keys.Delete, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_Delete));
            this._messageHandlers.Add(Keys.Home, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_Home));
            this._messageHandlers.Add(Keys.End, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_End));
            this._messageHandlers.Add(Keys.ShiftKey | Keys.Shift, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_ShiftShiftKey));
            this._messageHandlers.Add(Keys.C | Keys.Control, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_ControlC));
            this._messageHandlers.Add(Keys.X | Keys.Control, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_ControlX));
            this._messageHandlers.Add(Keys.V | Keys.Control, new HexBox.KeyInterpreter.MessageDelegate(this.PreProcessWmKeyDown_ControlV));
          }
          return this._messageHandlers;
        }
      }

      protected virtual bool PerformPosMoveLeft()
      {
        long bytePos = this._hexBox._bytePos;
        long selectionLength = this._hexBox._selectionLength;
        int byteCharacterPos1 = this._hexBox._byteCharacterPos;
        if (selectionLength != 0L)
        {
          int byteCharacterPos2 = 0;
          this._hexBox.SetPosition(bytePos, byteCharacterPos2);
          this._hexBox.ReleaseSelection();
        }
        else
        {
          if (bytePos == 0L && byteCharacterPos1 == 0)
            return true;
          int byteCharacterPos2;
          if (byteCharacterPos1 > 0)
          {
            byteCharacterPos2 = byteCharacterPos1 - 1;
          }
          else
          {
            bytePos = Math.Max(0L, bytePos - 1L);
            byteCharacterPos2 = byteCharacterPos1 + 1;
          }
          this._hexBox.SetPosition(bytePos, byteCharacterPos2);
          if (bytePos < this._hexBox._startByte)
            this._hexBox.PerformScrollLineUp();
          this._hexBox.UpdateCaret();
          this._hexBox.Invalidate();
        }
        this._hexBox.ScrollByteIntoView();
        return true;
      }

      protected virtual bool PerformPosMoveRight()
      {
        long bytePos = this._hexBox._bytePos;
        int byteCharacterPos1 = this._hexBox._byteCharacterPos;
        long selectionLength = this._hexBox._selectionLength;
        if (selectionLength != 0L)
        {
          this._hexBox.SetPosition(bytePos + selectionLength, 0);
          this._hexBox.ReleaseSelection();
        }
        else if (bytePos != this._hexBox._byteProvider.Length || byteCharacterPos1 != 0)
        {
          int byteCharacterPos2;
          if (byteCharacterPos1 > 0)
          {
            bytePos = Math.Min(this._hexBox._byteProvider.Length, bytePos + 1L);
            byteCharacterPos2 = 0;
          }
          else
            byteCharacterPos2 = byteCharacterPos1 + 1;
          this._hexBox.SetPosition(bytePos, byteCharacterPos2);
          if (bytePos > this._hexBox._endByte - 1L)
            this._hexBox.PerformScrollLineDown();
          this._hexBox.UpdateCaret();
          this._hexBox.Invalidate();
        }
        this._hexBox.ScrollByteIntoView();
        return true;
      }

      protected virtual bool PerformPosMoveLeftByte()
      {
        long bytePos1 = this._hexBox._bytePos;
        int byteCharacterPos1 = this._hexBox._byteCharacterPos;
        if (bytePos1 == 0L)
          return true;
        long bytePos2 = Math.Max(0L, bytePos1 - 1L);
        int byteCharacterPos2 = 0;
        this._hexBox.SetPosition(bytePos2, byteCharacterPos2);
        if (bytePos2 < this._hexBox._startByte)
          this._hexBox.PerformScrollLineUp();
        this._hexBox.UpdateCaret();
        this._hexBox.ScrollByteIntoView();
        this._hexBox.Invalidate();
        return true;
      }

      protected virtual bool PerformPosMoveRightByte()
      {
        long bytePos1 = this._hexBox._bytePos;
        int byteCharacterPos1 = this._hexBox._byteCharacterPos;
        if (bytePos1 == this._hexBox._byteProvider.Length)
          return true;
        long bytePos2 = Math.Min(this._hexBox._byteProvider.Length, bytePos1 + 1L);
        int byteCharacterPos2 = 0;
        this._hexBox.SetPosition(bytePos2, byteCharacterPos2);
        if (bytePos2 > this._hexBox._endByte - 1L)
          this._hexBox.PerformScrollLineDown();
        this._hexBox.UpdateCaret();
        this._hexBox.ScrollByteIntoView();
        this._hexBox.Invalidate();
        return true;
      }

      public virtual PointF GetCaretPointF(long byteIndex)
      {
        return this._hexBox.GetBytePointF(byteIndex);
      }

      protected virtual BytePositionInfo GetBytePositionInfo(Point p)
      {
        return this._hexBox.GetHexBytePositionInfo(p);
      }

      private delegate bool MessageDelegate(ref Message m);
    }

    private class StringKeyInterpreter : HexBox.KeyInterpreter
    {
      public StringKeyInterpreter(HexBox hexBox)
        : base(hexBox)
      {
        this._hexBox._byteCharacterPos = 0;
      }

      public override bool PreProcessWmKeyDown(ref Message m)
      {
        Keys keyData = (Keys) m.WParam.ToInt32() | Control.ModifierKeys;
        switch (keyData)
        {
          case Keys.Tab:
          case Keys.Tab | Keys.Shift:
            if (this.RaiseKeyDown(keyData))
              return true;
            break;
        }
        switch (keyData)
        {
          case Keys.Tab:
            return this.PreProcessWmKeyDown_Tab(ref m);
          case Keys.Tab | Keys.Shift:
            return this.PreProcessWmKeyDown_ShiftTab(ref m);
          default:
            return base.PreProcessWmKeyDown(ref m);
        }
      }

      protected override bool PreProcessWmKeyDown_Left(ref Message m)
      {
        return this.PerformPosMoveLeftByte();
      }

      protected override bool PreProcessWmKeyDown_Right(ref Message m)
      {
        return this.PerformPosMoveRightByte();
      }

      public override bool PreProcessWmChar(ref Message m)
      {
        if (Control.ModifierKeys == Keys.Control)
          return this._hexBox.BasePreProcessMessage(ref m);
        bool flag1 = this._hexBox._byteProvider.SupportsWriteByte();
        bool flag2 = this._hexBox._byteProvider.SupportsInsertBytes();
        bool flag3 = this._hexBox._byteProvider.SupportsDeleteBytes();
        long bytePos = this._hexBox._bytePos;
        long selectionLength = this._hexBox._selectionLength;
        int byteCharacterPos1 = this._hexBox._byteCharacterPos;
        if (!flag1 && bytePos != this._hexBox._byteProvider.Length || !flag2 && bytePos == this._hexBox._byteProvider.Length)
          return this._hexBox.BasePreProcessMessage(ref m);
        char int32 = (char) m.WParam.ToInt32();
        if (this.RaiseKeyPress(int32) || this._hexBox.ReadOnly)
          return true;
        bool flag4 = bytePos == this._hexBox._byteProvider.Length;
        if (!flag4 && flag2 && this._hexBox.InsertActive)
          flag4 = true;
        if (flag3 && flag2 && selectionLength > 0L)
        {
          this._hexBox._byteProvider.DeleteBytes(bytePos, selectionLength);
          flag4 = true;
          int byteCharacterPos2 = 0;
          this._hexBox.SetPosition(bytePos, byteCharacterPos2);
        }
        this._hexBox.ReleaseSelection();
        byte num = this._hexBox.ByteCharConverter.ToByte(int32);
        if (flag4)
          this._hexBox._byteProvider.InsertBytes(bytePos, new byte[1]
          {
            num
          });
        else
          this._hexBox._byteProvider.WriteByte(bytePos, num);
        this.PerformPosMoveRightByte();
        this._hexBox.Invalidate();
        return true;
      }

      public override PointF GetCaretPointF(long byteIndex)
      {
        return this._hexBox.GetByteStringPointF(this._hexBox.GetGridBytePoint(byteIndex));
      }

      protected override BytePositionInfo GetBytePositionInfo(Point p)
      {
        return this._hexBox.GetStringBytePositionInfo(p);
      }
    }
  }
}
