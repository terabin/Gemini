using System.Drawing;
using Gemini.Serializable;

namespace Gemini
{
	[System.Serializable]
	public struct ScriptStyle
  {
    public string Name;

    [Newtonsoft.Json.JsonIgnore]
    public Color ForeColor
    {
      get { return ColorSerializetionHelper.Deserialize(Fore); }
      set { Fore = ColorSerializetionHelper.Serialize(value); }
    }
    [Newtonsoft.Json.JsonRequired]
    private string Fore;

    [Newtonsoft.Json.JsonIgnore]
    public Color BackColor
    {
      get { return ColorSerializetionHelper.Deserialize(Back); }
      set { Back = ColorSerializetionHelper.Serialize(value); }
    }
    [Newtonsoft.Json.JsonRequired]
    private string Back;
    
    public FontProperties Font;

    public ScriptStyle(string name, Color fore, Color back, Font font)
		{
			Name = name;
			Fore = ColorSerializetionHelper.Serialize(fore);
      Back = ColorSerializetionHelper.Serialize(back);
      Font = FontSerializetionHelper.Serialize(font);
		}
	}

}
