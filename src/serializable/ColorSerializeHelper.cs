using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace Gemini.Serializable
{
  [TypeConverter(typeof(ColorConverter))]
  internal class ColorSerializetionHelper
  {
    public static Color Deserialize(string value)
    {
      return Color.FromArgb(int.Parse(value.Replace("#", ""), NumberStyles.HexNumber));
    }

    public static string Serialize(Color value)
    {
      return "#" + value.A.ToString("X2") + value.R.ToString("X2") + value.G.ToString("X2") + value.B.ToString("X2");
    }
  }
}