namespace Gemini
{
  public class SearchResult : System.Windows.Forms.ListViewItem
  {
    private int _section;
    private int _line;
    public int Section { get { return _section; } }
    public int Line { get { return _line; } }

    public SearchResult(int scriptSection, string scriptTitle, int lineNumber, string lineText)
        : base(new string[] { scriptTitle, (lineNumber + 1).ToString(), lineText })
    {
      _section = scriptSection;
      _line = lineNumber;
    }
  }
}