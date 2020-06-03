// Decompiled with JetBrains decompiler
// Type: soteDiag.Program
// Assembly: soteDiag, Version=3.2.3.9, Culture=neutral, PublicKeyToken=null
// MVID: 64B98F7C-FFB0-44BA-B97E-997AD765B8FF
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteDiag.exe

using System;
using System.Windows.Forms;

namespace soteDiag
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run((Form) new soteDiag.soteDiag());
    }
  }
}
