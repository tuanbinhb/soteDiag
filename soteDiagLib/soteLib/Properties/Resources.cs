// Decompiled with JetBrains decompiler
// Type: soteLib.Properties.Resources
// Assembly: soteLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4F811DBC-85FF-41C8-BEDD-2723F189B5A6
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteLib.dll

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace soteLib.Properties
{
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [CompilerGenerated]
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
        if (object.ReferenceEquals((object) soteLib.Properties.Resources.resourceMan, (object) null))
          soteLib.Properties.Resources.resourceMan = new ResourceManager("soteLib.Properties.Resources", typeof (soteLib.Properties.Resources).Assembly);
        return soteLib.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return soteLib.Properties.Resources.resourceCulture;
      }
      set
      {
        soteLib.Properties.Resources.resourceCulture = value;
      }
    }
  }
}
