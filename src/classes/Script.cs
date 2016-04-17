using IronRuby.Builtins;
using ScintillaNet;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gemini
{
  public class Script
  {
    #region Fields and Properties

    // Fields
    private bool _needSave = false;

    private int _section;
    private string _name;
    private string _tabName;
    private string _text;
    private RubyArray _rmScript;
    private TabPage _tabPage;
    private Scintilla _scintilla;
    private static List<char> _braces = new List<char>() { '(', ')', '[', ']', '{', '}' };

    private static List<char> _suppressedChars = new List<char>() {
      ' ', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '=',
      '{', '}', '[', ']', ':', ';', '<', '>', '.', ',', '?', '/', '\\',
      '\n', '\r', '\t', '`', '~', '|' , '\'', '"' };

    private static List<string> _unindentWords = new List<string>() {
      "else", "elsif", "rescue", "ensure", "when", "end", ")", "]", "}" };

    // Properties
    public int Section { get { return _section; } set { _section = value; _rmScript[0] = _section; } }

    public string Name { get { return _name; } set { _name = value; _rmScript[1] = Ruby.ConvertString(_name); UpdateTabName(); } }
    public string Text { get { return _scintilla == null ? GetText() : _scintilla.Text; } }
    public string TabName { get { return _tabName; } }
    public RubyArray RMScript { get { return _rmScript; } }
    public TabPage TabPage { get { return GetTabPage(); } }
    public Scintilla Scintilla { get { return GetScintilla(); } }
    public bool NeedSave { get { return _needSave || NeedApplyChanges; } set { _needSave = value; UpdateTabName(); } }
    public bool NeedApplyChanges { get { return _scintilla != null && _text != _scintilla.Text; } }
    public bool Opened { get { return _tabPage != null; } }

    #endregion Fields and Properties

    public Script(RubyArray rmScript)
    {
      _rmScript = rmScript;
      _section = int.Parse(rmScript[0].ToString());
      _name = Ruby.ConvertString((MutableString)_rmScript[1]);
      UpdateTabName();
    }

    public Script(int section, string title, string text)
    {
      _rmScript = new RubyArray() { section, Ruby.ConvertString(title), Ruby.ZlibDeflate(text) };
      _section = section;
      _name = title;
      UpdateTabName();
    }
    
    public void Dispose()
    {
      if (_tabPage != null)
      {
        _tabPage.Dispose();
        _tabPage = null;
      }
      if (_scintilla != null)
      {
        _scintilla.Dispose();
        _scintilla = null;
      }
      _text = null;
      UpdateTabName();
    }

    public void ApplyChanges()
    {
      if (NeedApplyChanges)
      {
        _rmScript[2] = Ruby.ZlibDeflate(_text = Text);
        NeedSave = true;
      }
    }

    private void UpdateTabName()
    {
      _tabName = NeedSave ? "* " + Name : Name;
      if (Opened)
        _tabPage.Text = _tabName;
    }

    private string GetText()
    {
      if (_text == null)
        _text = Ruby.ZlibInflate((MutableString)_rmScript[2]);
      return _text;
    }

    private TabPage GetTabPage()
    {
      if (_tabPage == null)
      {
        _tabPage = new TabPage(Name);
        _tabPage.Controls.Add(Scintilla);
      }
      return _tabPage;
    }

    private Scintilla GetScintilla()
    {
      if (_scintilla == null)
        InitializeScintilla();
      return _scintilla;
    }

    private void InitializeScintilla()
    {
      _scintilla = new Scintilla();
      // Lexer
      _scintilla.ConfigurationManager.Language = "ruby";
      _scintilla.Lexing.Lexer = Lexer.Ruby;
      _scintilla.Lexing.SetKeywords(0, Properties.Resources.Ruby_Keywords);
      _scintilla.Lexing.LineCommentPrefix = "#~ ";
      //Folding
      _scintilla.Folding.Flags = FoldFlag.LineAfterContracted;
      _scintilla.Folding.UseCompactFolding = true;
      _scintilla.Folding.IsEnabled = true;
      // Indentation
      _scintilla.Indentation.TabWidth = 2;
      // AutoComplete
      _scintilla.AutoComplete.DropRestOfWord = false;
      _scintilla.AutoComplete.CancelAtStart = true;
      _scintilla.AutoComplete.IsCaseSensitive = false;
      // Margins
      _scintilla.Margins.Margin0.Width = 20;
      _scintilla.Margins.Margin1.Width = 2;
      // Edge Line
      _scintilla.LongLines.EdgeColumn = 80;
      _scintilla.LongLines.EdgeMode = EdgeMode.Line;
      // Events
      _scintilla.KeyDown += new KeyEventHandler(Scintilla_KeyDown);
      _scintilla.CharAdded += new EventHandler<CharAddedEventArgs>(Scintilla_CharAdded);
      _scintilla.NativeInterface.UpdateUI += new EventHandler<NativeScintillaEventArgs>(Scintilla_NativeInterface_UpdateUI);
      _scintilla.TextChanged += new EventHandler<EventArgs>(Scintilla_TextChanged);
      // Setup
      _scintilla.SupressControlCharacters = false;
      _scintilla.Dock = DockStyle.Fill;
      _scintilla.Text = GetText();
      _scintilla.UndoRedo.EmptyUndoBuffer();
      UpdateSettings();
      SetStyle();
    }

    public void UpdateSettings()
    {
      if (_scintilla != null)
      {
        _scintilla.Indentation.ShowGuides = Settings.GuideLines;
        _scintilla.Margins.Margin2.Width = Settings.CodeFolding ? 16 : 0;
        _scintilla.Caret.CurrentLineBackgroundColor = Settings.LineHighLightColor;
        _scintilla.Caret.CurrentLineBackgroundAlpha = Settings.LineHighLightColor.A;
        _scintilla.Caret.HighlightCurrentLine = Settings.LineHighLight;
        _scintilla.Indentation.SmartIndentType = Settings.AutoIndent ? ScintillaNet.SmartIndent.None : ScintillaNet.SmartIndent.Simple;
        if (!Settings.CodeFolding)
          UnfoldAllLines();
      }
    }

    public void SetStyle(ScriptStyle[] styles)
    {
      if (_scintilla != null)
      {
        for (int i = 0; i < 19; i++)
        {
          if (i == 1)
            continue;
          _scintilla.Styles[i].ForeColor = styles[i].ForeColor;
          _scintilla.Styles[i].BackColor = styles[i].BackColor;
          _scintilla.Styles[i].Font = styles[i].Font.Get();
        }
        // demoted keywords style
        _scintilla.Styles[29].ForeColor = _scintilla.Styles[5].ForeColor;
        _scintilla.Styles[29].BackColor = _scintilla.Styles[5].BackColor;
        _scintilla.Styles[29].Font = _scintilla.Styles[5].Font;
        // braces style
        _scintilla.Styles.BraceLight.ForeColor = styles[1].ForeColor;
        _scintilla.Styles.BraceLight.BackColor = styles[1].BackColor;
        _scintilla.Styles.BraceLight.Font = styles[1].Font.Get();
        _scintilla.Styles.BraceBad.ForeColor = styles[1].BackColor;
        _scintilla.Styles.BraceBad.BackColor = styles[1].ForeColor;
        _scintilla.Styles.BraceBad.Font = styles[1].Font.Get();
        // left margin style
        _scintilla.Styles.LineNumber.ForeColor = styles[19].ForeColor;
        _scintilla.Styles.LineNumber.BackColor = styles[19].BackColor;
        _scintilla.Styles.LineNumber.Font = styles[19].Font.Get();
        _scintilla.Margins.FoldMarginColor = styles[19].BackColor;
      }
    }

    public void SetStyle()
    {
      SetStyle(Settings.ScriptStyles);
    }

    public SearchResult[] Search(string searchString, SearchFlags flags)
    {
      List<ScintillaNet.Range> findings = Scintilla.FindReplace.FindAll(searchString, flags);
      SearchResult[] result = new SearchResult[findings.Count];
      for (int i = 0; i < findings.Count; i++)
      {
        Line line = findings[i].StartingLine;
        result[i] = new SearchResult(Section, Name, line.Number, line.Text);
      }
      if (!Opened)
        Dispose();
      return result;
    }

    /// <summary>
    /// Normalizes indentation of the script according to standard Ruby conventions
    /// </summary>
    /// <returns>Return true if changes have been applied</returns>
    public void StructureScript()
    {
      Scintilla.UndoRedo.BeginUndoAction();
      foreach (Line line in _scintilla.Lines)
      {
        int indent = GetLineIndent(line);
        if (indent != -1)
        {
          line.Indentation = 0; // so even if the indent is the same thereafter it will replace "  " by "\t"
          line.Indentation = indent * _scintilla.Indentation.TabWidth;
        }
      }
      _scintilla.UndoRedo.EndUndoAction();
      if (!Opened)
      {
        ApplyChanges();
        Dispose();
      }
    }

    /// <summary>
    /// Make the script shorter by deleting all unneeded lines
    /// </summary>
    /// <returns>Return true if changes have been applied</returns>
    public void RemoveEmptyLines()
    {
      Scintilla.UndoRedo.BeginUndoAction();
      for (int i = _scintilla.Lines.Count - 1; i >= 0; i--)
        if (_scintilla.Lines[i].Text.Trim().Length == 0)
        {
          _scintilla.CurrentPos = _scintilla.Lines[i].StartPosition;
          _scintilla.Commands.Execute(BindableCommand.LineDelete);
        }
      Line lastLine = _scintilla.Lines[_scintilla.Lines.Count - 1];
      if (lastLine.Text.Length == 0)
      {
        _scintilla.CurrentPos = lastLine.StartPosition;
        _scintilla.Commands.Execute(BindableCommand.DeleteBack);
      }
      _scintilla.UndoRedo.EndUndoAction();
      if (!Opened)
      {
        ApplyChanges();
        Dispose();
      }
    }

    public void UnfoldAllLines()
    {
      if (_scintilla != null)
        foreach (Line line in _scintilla.Lines)
          if (!line.FoldExpanded)
            line.ToggleFoldExpanded();
    }

    /// <summary>
    /// Return the requiered indent for this line or -1 if the line is a multiline comment or string
    /// </summary>
    private int GetLineIndent(Line line)
    {
      int pos = line.StartPosition - 1;
      _scintilla.NativeInterface.Colourise(pos, pos + 1); // styles are used to determine indent so we must load them before proceeding
      int style = _scintilla.Styles.GetStyleAt(pos);
      if (style == 3 || style == 6 || style == 7 || style == 12 || style == 18 || line.Text.StartsWith("=begin"))
        return -1;
      int indent = line.FoldLevel - 1024;
      string w1 = _scintilla.GetWordFromPosition(line.IndentPosition);
      string w2 = _scintilla.CharAt(line.IndentPosition).ToString();
      if (_unindentWords.Contains(w1) || _unindentWords.Contains(w2))
        indent--;
      return indent;
    }

    private bool IsBrace(int pos)
    {
      return _scintilla != null && _braces.Contains(_scintilla.CharAt(pos)) && _scintilla.Styles.GetStyleAt(pos) == 10;
    }

    #region Scintilla Events

    /// <summary>
    /// Checks key input for the hotkeys
    /// </summary>
    private void Scintilla_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Control)
      {
        Scintilla scintilla = (Scintilla)sender;
        if (e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.D0)
          scintilla.Zoom = 0;
        // Just for GG, we add the Ctrl button for dropping autocomplete :)
        if (scintilla.AutoComplete.IsActive)
          scintilla.AutoComplete.Accept();
      }
    }

    /// <summary>
    /// Registers characters added to the control for controlling auto-indentation and autocomplete
    /// </summary>
    private void Scintilla_CharAdded(object sender, CharAddedEventArgs e)
    {
      Scintilla scintilla = (Scintilla)sender;
      // Update AutoIndent depending on words typed
      if (Settings.AutoIndent && e.Ch == '\n')
      {
        // Correct previous line indent
        string prevText = scintilla.Lines.Current.Previous.Text.Trim();
        int prevIndent = -1;
        if (prevText == "=begin" || prevText == "=end")
          scintilla.Lines.Current.Previous.Indentation = 0;
        else
          prevIndent = GetLineIndent(scintilla.Lines.Current.Previous);
        if (prevIndent != -1)
          scintilla.Lines.Current.Previous.Indentation = prevIndent * scintilla.Indentation.TabWidth;
        // Indent new line
        string indentStr = "";
        int indent = GetLineIndent(scintilla.Lines.Current);
        for (int i = 0; i < indent; i++)
          indentStr += "\t";
        _scintilla.InsertText(indentStr);
      }
      // Update AutoComplete depending on the words typed
      if (Settings.AutoComplete)
      {
        int pos = scintilla.CurrentPos;
        // Prevents auto-complete for comments and strings
        int style = _scintilla.Styles.GetStyleAt(pos - 2);
        if (style == 2 || style == 3 || style == 6 || style == 7 || style == 12 || style == 18)
          return;
        // Prevents certain characters from raising the auto-complete window
        string word = scintilla.GetWordFromPosition(pos).ToLower();
        if (_suppressedChars.Contains(e.Ch) || word.Length < Settings.AutoCompleteLength)
          return;
        // Select the matched words (we assume that Settings.AutoCompleteWords is already sorted)
        scintilla.AutoComplete.List = Settings.AutoCompleteWords.FindAll(
            delegate (string listWord) { return (listWord.ToLower().Contains(word)); });
        if (scintilla.AutoComplete.List.Count > 0)
          scintilla.AutoComplete.Show();
        else
          scintilla.AutoComplete.Cancel();
      }
    }

    /// <summary>
    /// Ensures the margin is sized correctly to allow display of the line numbers
    /// </summary>
    private int _maxLineNumberCharLength;

    private void Scintilla_TextChanged(object sender, EventArgs e)
    {
      Scintilla scintilla = (Scintilla)sender;
      var maxLength = scintilla.Lines.Count.ToString().Length;
      if (maxLength == _maxLineNumberCharLength)
        return;
      scintilla.Margins[0].Width = scintilla.NativeInterface.TextWidth((int)StylesCommon.LineNumber,
        new string('9', maxLength + 1)) + 2;
      _maxLineNumberCharLength = maxLength;
      UpdateTabName();
    }

    /// <summary>
    /// Check if cursor is on a brace or not, highlighting if necessary
    /// </summary>
    private void Scintilla_NativeInterface_UpdateUI(object sender, NativeScintillaEventArgs e)
    {
      Scintilla scintilla = (Scintilla)sender;
      int pos = scintilla.CurrentPos;
      if (IsBrace(pos) || IsBrace(--pos))
      {
        int match = scintilla.NativeInterface.BraceMatch(pos, 0);
        if (match != -1)
          scintilla.NativeInterface.BraceHighlight(pos, match);
        else
          scintilla.NativeInterface.BraceBadLight(pos);
      }
      else
        scintilla.NativeInterface.BraceHighlight(-1, -1);
    }

    #endregion Scintilla Events
  }
}