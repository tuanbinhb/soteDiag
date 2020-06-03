// Decompiled with JetBrains decompiler
// Type: Util.XmlUtil
// Assembly: soteDiag, Version=3.2.3.9, Culture=neutral, PublicKeyToken=null
// MVID: 64B98F7C-FFB0-44BA-B97E-997AD765B8FF
// Assembly location: E:\Test_Program\F57416M4160C\FT1\soteDiag.exe

using System.IO;
using System.Xml.Serialization;

namespace Util
{
  public static class XmlUtil
  {
    public static T LoadObject<T>(string xmlFile)
    {
      FileStream fileStream = new FileStream(xmlFile, FileMode.Open);
      T obj = (T) new XmlSerializer(typeof (T)).Deserialize((Stream) fileStream);
      fileStream.Close();
      return obj;
    }
  }
}
