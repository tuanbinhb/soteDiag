// Decompiled with JetBrains decompiler
// Type: Be.Windows.Forms.NativeMethods
// Assembly: Be.Windows.Forms.HexBox, Version=1.4.7.13476, Culture=neutral, PublicKeyToken=e0e5adf0ebc99863
// MVID: 989788C2-0B99-46B0-ADFA-DFA056A86ADD
// Assembly location: E:\Test_Program\F57416M4160C\FT1\Be.Windows.Forms.HexBox.dll

using System;
using System.Runtime.InteropServices;

namespace Be.Windows.Forms
{
  internal static class NativeMethods
  {
    public const int WM_KEYDOWN = 256;
    public const int WM_KEYUP = 257;
    public const int WM_CHAR = 258;

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool CreateCaret(IntPtr hWnd, IntPtr hBitmap, int nWidth, int nHeight);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool ShowCaret(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool DestroyCaret();

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool SetCaretPos(int X, int Y);
  }
}
