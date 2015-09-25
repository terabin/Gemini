using System.Drawing;
using System.Xml.Serialization;
using Gemini.Serializable;

namespace Gemini
{
	[System.Serializable]
	public struct ScriptStyle
  {
    public string Name;

    [XmlIgnore()]
    public Color ForeColor
    {
      get { return ColorSerializetionHelper.Deserialize(ForegroundColor); }
      set { ForegroundColor = ColorSerializetionHelper.Serialize(value); }
    }
    public ColorProperties ForegroundColor;

    [XmlIgnore()]
    public Color BackColor
    {
      get { return ColorSerializetionHelper.Deserialize(BackgroundColor); }
      set { BackgroundColor = ColorSerializetionHelper.Serialize(value); }
    }
    public ColorProperties BackgroundColor;

    [XmlIgnore()]
    public Font Font
    {
      get { return FontSerializetionHelper.Deserialize(FontProperties); }
      set { FontProperties = FontSerializetionHelper.Serialize(value); }
    }
    public FontProperties FontProperties;

    public ScriptStyle(string name, Color fore, Color back, Font font)
		{
			Name = name;
			ForegroundColor = ColorSerializetionHelper.Serialize(fore);
      BackgroundColor = ColorSerializetionHelper.Serialize(back);
      FontProperties = FontSerializetionHelper.Serialize(font);
		}
	}

}
