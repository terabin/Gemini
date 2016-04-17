using System;
using System.Drawing;
using System.Windows.Forms;

/*\
 *  ######  ###### ##     ## ###### ##    ## ######
 * ##    ## ##     ###   ###   ##   ###   ##   ##
 * ##       ##     #### ####   ##   ####  ##   ##
 * ##  ###  ####   ## ### ##   ##   ## ## ##   ##
 * ##    ## ##     ##     ##   ##   ##  ####   ##
 * ##    ## ##     ##     ##   ##   ##   ###   ##
 *  ######  ###### ##     ## ###### ##    ## ######
\*/
namespace Gemini
{
  internal partial class StyleEditorForm : Form
  {
    private string[] _exampleStrings = new string[] {
      "a = b + c", "[1, 2, 3]", "# Comment Line", "=begin Comment Block",
            "x = (4 + 8) / 3", "if true then super nil else return end",
            "\"hello world\"", "'hello world'", "class Bitmap", "def add_numbers(num1, num2)",
      "+ - * = ( ) [ ]", "@bitmap.clear", "\"hello\".gsub(/[aeiou]/, '*')",
            "$RGSS_SCRIPTS, $game_player", "attr_accessor :name", "module RPG",
            "@instance_variable", "@@class_variable", "output=`ls no_existing_file`", "" };
    private bool _suppressRefresh = false;
    private Script _sampleScript;
    private ScriptStyle[] _styles;
    public ScriptStyle[] Styles { get { return _styles; } }

    public StyleEditorForm()
    {
      InitializeComponent();
      _styles = (ScriptStyle[])Settings.ScriptStyles.Clone();
      using (System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection())
        for (int i = 0; i < fonts.Families.Length; i++)
          comboBoxFonts.Items.Add(fonts.Families[i].Name);
      foreach (ScriptStyle s in _styles)
        listBoxStyles.Items.Add(s.Name);
      _sampleScript = new Script(0, "Sample", "");
      panelSample.Controls.Add(_sampleScript.Scintilla);
      listBoxStyles.SelectedIndex = 0;
    }

    private void listStyles_IndexChanged(object sender, EventArgs e)
    {
      _suppressRefresh = true;
      int index = listBoxStyles.SelectedIndex;
      if (index >= 0)
      {
        ScriptStyle style = _styles[index];
        comboBoxFonts.SelectedIndex = comboBoxFonts.Items.IndexOf(style.Font.Name);
        string size = Convert.ToString(style.Font.Size);
        comboBoxSizes.SelectedIndex = comboBoxSizes.Items.IndexOf(size);
        checkBoxBold.Checked = style.Font.Get().Bold;
        checkBoxItalic.Checked = style.Font.Get().Italic;
        checkBoxUnderline.Checked = style.Font.Get().Underline;
        panelForeColor.BackColor = style.ForeColor;
        panelBackColor.BackColor = style.BackColor;
        _sampleScript.Scintilla.Text = _exampleStrings[index];
      }
      _suppressRefresh = false;
    }

    private void comboBoxFonts_SelectedIndexChanged(object sender, EventArgs e)
    {
      int fontIndex = comboBoxFonts.SelectedIndex;
      int styleIndex = listBoxStyles.SelectedIndex;
      if (!_suppressRefresh && (styleIndex >= 0) && (fontIndex >= 0))
      {
        _styles[styleIndex].Font.Set(new Font((string)comboBoxFonts.Items[fontIndex],
          _styles[styleIndex].Font.Get().Size));
        _sampleScript.SetStyle(_styles);
      }
    }

    private void comboSize_SelectedIndexChanged(object sender, EventArgs e)
    {
      int sizeIndex = comboBoxSizes.SelectedIndex;
      int styleIndex = listBoxStyles.SelectedIndex;
      if (!_suppressRefresh && (styleIndex >= 0) && (sizeIndex >= 0))
      {
        _styles[styleIndex].Font.Set(new Font(_styles[styleIndex].Font.Name,
          Convert.ToInt32(comboBoxSizes.Items[sizeIndex])));
        _sampleScript.SetStyle(_styles);
      }
    }

    private void checkBoxBold_CheckChanged(object sender, EventArgs e)
    {
      int styleIndex = listBoxStyles.SelectedIndex;
      if (!_suppressRefresh && (styleIndex >= 0))
        ChangeFontStyle(styleIndex, FontStyle.Bold);
    }

    private void checkBoxItalic_CheckChanged(object sender, EventArgs e)
    {
      int styleIndex = listBoxStyles.SelectedIndex;
      if (!_suppressRefresh && (styleIndex >= 0))
        ChangeFontStyle(styleIndex, FontStyle.Italic);
    }

    private void checkBoxUnderline_CheckChanged(object sender, EventArgs e)
    {
      int styleIndex = listBoxStyles.SelectedIndex;
      if (!_suppressRefresh && (styleIndex >= 0))
        ChangeFontStyle(styleIndex, FontStyle.Underline);
    }

    private void ChangeFontStyle(int styleIndex, FontStyle fontStyle)
    {
      FontStyle newStyle = FontStyle.Regular;
      if ((fontStyle == FontStyle.Bold) && (!_styles[styleIndex].Font.Get().Bold))
        newStyle |= fontStyle;
      else if ((fontStyle != FontStyle.Bold) && _styles[styleIndex].Font.Get().Bold)
        newStyle |= FontStyle.Bold;
      if ((fontStyle == FontStyle.Italic) && (!_styles[styleIndex].Font.Get().Italic))
        newStyle |= fontStyle;
      else if ((fontStyle != FontStyle.Italic) && _styles[styleIndex].Font.Get().Italic)
        newStyle |= FontStyle.Italic;
      if ((fontStyle == FontStyle.Underline) && (!_styles[styleIndex].Font.Get().Underline))
        newStyle |= fontStyle;
      else if ((fontStyle != FontStyle.Underline) && _styles[styleIndex].Font.Get().Underline)
        newStyle |= FontStyle.Underline;
      _styles[styleIndex].Font.Set(new Font(_styles[styleIndex].Font.Get(), newStyle));
      _sampleScript.SetStyle(_styles);
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }

    private void panelForeColor_DoubleClick(object sender, EventArgs e)
    {
      int styleIndex = listBoxStyles.SelectedIndex;
      if (styleIndex >= 0)
      {
        using (ColorDialog colorDialog = new ColorDialog())
        {
          colorDialog.FullOpen = true;
          colorDialog.Color = _styles[styleIndex].ForeColor;
          DialogResult result = colorDialog.ShowDialog();
          if (result == DialogResult.OK)
          {
            _styles[styleIndex].ForeColor = colorDialog.Color;
            panelForeColor.BackColor = colorDialog.Color;
            _sampleScript.SetStyle(_styles);
          }
        }
      }
    }

    private void panelBackColor_DoubleClick(object sender, EventArgs e)
    {
      int styleIndex = listBoxStyles.SelectedIndex;
      if (styleIndex >= 0)
      {
        using (ColorDialog colorDialog = new ColorDialog())
        {
          colorDialog.FullOpen = true;
          colorDialog.Color = _styles[styleIndex].BackColor;
          DialogResult result = colorDialog.ShowDialog();
          if (result == DialogResult.OK)
          {
            _styles[styleIndex].BackColor = colorDialog.Color;
            panelBackColor.BackColor = colorDialog.Color;
            _sampleScript.SetStyle(_styles);
          }
        }
      }
    }
  }
}
