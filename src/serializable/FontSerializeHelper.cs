using System;
using System.ComponentModel;
using System.Drawing;

namespace Gemini.Serializable
{
  [TypeConverter(typeof(FontConverter))]
  internal class FontSerializetionHelper
  {
    public static Font Deserialize(FontProperties value)
    {
      if (value.Meta.Length < 5)
        return new Font(value.Name, value.Size);
      else
      {
        FontStyle fs = new FontStyle();
        if (value.Meta.Contains("R"))
          fs |= FontStyle.Regular;
        if (value.Meta.Contains("B"))
          fs |= FontStyle.Bold;
        if (value.Meta.Contains("I"))
          fs |= FontStyle.Italic;
        if (value.Meta.Contains("U"))
          fs |= FontStyle.Underline;
        if (value.Meta.Contains("S"))
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
      fprop.Meta = str;
      return fprop;
    }
  }

  [Serializable]
  public struct FontProperties
  {
    public Font Get()
    {
      return FontSerializetionHelper.Deserialize(this);
    }

    public void Set(Font font)
    {
      this = FontSerializetionHelper.Serialize(font);
    }

    public string Name;
    public float Size;
    public string Meta;
  }
}