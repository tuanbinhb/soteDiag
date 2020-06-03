// Decompiled with JetBrains decompiler
// Type: Be.Windows.Forms.Util
// Assembly: Be.Windows.Forms.HexBox, Version=1.4.7.13476, Culture=neutral, PublicKeyToken=e0e5adf0ebc99863
// MVID: 989788C2-0B99-46B0-ADFA-DFA056A86ADD
// Assembly location: E:\Test_Program\F57416M4160C\FT1\Be.Windows.Forms.HexBox.dll

using System.Diagnostics;

namespace Be.Windows.Forms
{
  internal static class Util
  {
    private static bool _designMode = Process.GetCurrentProcess().ProcessName.ToLower() == "devenv";

    public static bool DesignMode
    {
      get
      {
        return Util._designMode;
      }
    }
  }
}
