using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Gemini.Serializable
{
  [TypeConverter(typeof(ColorConverter))]
  internal class ColorSerializetionHelper
  {
    public static Color Deserialize(ColorProperties value)
    {
      return Color.FromArgb(int.Parse(value.Hex.Replace("#",""), NumberStyles.HexNumber));
    }
    
    public static ColorProperties Serialize(Color value)
    {
      return new ColorProperties("#" + value.A.ToString("X2") + value.R.ToString("X2")+ value.G.ToString("X2")+ value.B.ToString("X2"));
    }
  }

  [Serializable]
  public struct ColorProperties
  {
    public ColorProperties(string hex)
    {
      Hex = hex;
    }
    public string Hex;
  }
}
