using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Gemini.Serializable
{
  [TypeConverter(typeof(FontConverter))]
  internal class FontSerializetionHelper
  {
    public static Font Deserialize(FontProperties value)
    {
      if (value.Attributes.Length < 5)
        return new Font(value.Name, value.Size);
      else
      {
        FontStyle fs = new FontStyle();
        if (value.Attributes.Contains("R"))
          fs |= FontStyle.Regular;
        if (value.Attributes.Contains("B"))
          fs |= FontStyle.Bold;
        if (value.Attributes.Contains("I"))
          fs |= FontStyle.Italic;
        if (value.Attributes.Contains("U"))
          fs |= FontStyle.Underline;
        if (value.Attributes.Contains("S"))
          fs |= FontStyle.Strikeout;
        return new Font(value.Name, value.Size, fs);
      }
    }

    public static FontProperties Serialize(Font value)
    {
      FontProperties fprop;
      fprop.Name = value.Name;
      fprop.Size = value.Size;
      string str = "";
      if (value.Style == FontStyle.Regular) str += "R";
      if (value.Bold) str += "B";
      if (value.Italic) str += "I";
      if (value.Underline) str += "U";
      if (value.Strikeout) str += "S";
      fprop.Attributes = str;
      return fprop;
    }
  }

  [Serializable]
  public struct FontProperties
  {
    public string Name;
    public float Size;
    public string Attributes;
  }
}
