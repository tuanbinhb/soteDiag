// Decompiled with JetBrains decompiler
// Type: soteDiag.Properties.Resources
// Assembly: soteDiag, Version=3.2.3.9, Culture=neutral, PublicKeyToken=null
// MVID: 64B98F7C-FFB0-44BA-B97E-997AD765B8FF
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteDiag.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace soteDiag.Properties
{
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) soteDiag.Properties.Resources.resourceMan, (object) null))
          soteDiag.Properties.Resources.resourceMan = new ResourceManager("soteDiag.Properties.Resources", typeof (soteDiag.Properties.Resources).Assembly);
        return soteDiag.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return soteDiag.Properties.Resources.resourceCulture;
      }
      set
      {
        soteDiag.Properties.Resources.resourceCulture = value;
      }
    }
  }
}
