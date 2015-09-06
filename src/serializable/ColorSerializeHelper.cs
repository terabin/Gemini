using System;
using System.ComponentModel;
using System.Drawing;

namespace Gemini.Serializable
{
  [TypeConverter(typeof(ColorConverter))]
  internal class ColorSerializetionHelper
  {
    public static Color Deserialize(ColorProperties value)
    {
      return Color.FromArgb(value.Alpha, value.Red, value.Green, value.Blue);
    }
    
    public static ColorProperties Serialize(Color value)
    {
      ColorProperties prop;
      prop.Alpha = value.A;
      prop.Red = value.R;
      prop.Green = value.G;
      prop.Blue = value.B;
      return prop;
    }
  }

  [Serializable]
  public struct ColorProperties
  {
    public int Alpha;
    public int Red;
    public int Green;
    public int Blue;
  }
}
