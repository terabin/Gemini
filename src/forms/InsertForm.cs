using System;
using System.IO;
using System.Text.RegularExpressions;
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
  public partial class InsertForm : Form
  {
    private string[] _filePaths;
    private bool _finished = false;
    private int _state;
    public string Title { get { return titleBox.Text; } }
    public string[] Paths { get { return _filePaths; } }
    public int State { get { return _state; } }

    private Regex _removeInvalidChars = new Regex(
      @"[^A-Za-z0-9 ▼+\-_=.,!@#$%^&();'(){}[\]]+",
      RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public InsertForm()
    {
      InitializeComponent();
      pathsBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      radioBelow.Checked = true;
      RefreshElements();
    }

    private void buttonOK_Click( object sender, EventArgs e )
    {
      // Set state, used by GeminiForm to determine what and  where to put our new script(s).
      _state = 0;
      if (radioScript.Checked)
        _state += 1;
      if (radioPath.Checked)
        _state += 2;
      if (radioBelow.Checked)
        _state += 4;
      if (radioUnder.Checked)
        _state += 8;

      // Used with formClosingEvent
      _finished = true;
      // Close the form.
      Close();
    }

    private void buttonBrowse_Click( object sender, EventArgs e )
    {
      using (OpenFileDialog dialog = new OpenFileDialog())
      {
        dialog.Filter = "Ruby Script|*.rb|Text Files|*.txt|All Documents|*";
        dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        dialog.Title = "Browse for scripts...";
        dialog.Multiselect = true;
        DialogResult result = dialog.ShowDialog();
        if (result == DialogResult.OK)
        {
          _filePaths = dialog.FileNames;
          pathsBox.Text = "";
          foreach (string s in _filePaths)
          pathsBox.Text += s + ", ";
        }
      }
    }

    private void titleBox_TextChanged( object sender, EventArgs e )
    { titleBox.Text = _removeInvalidChars.Replace(titleBox.Text, ""); }

    private void radioTopUpdate( object sender, EventArgs e )
    {
      RefreshElements();
    }

    private void RefreshElements()
    {
      if (radioScript.Checked)
      {
        Text = "Insert new script";
        titleBox.Enabled = true;
        titleBox.Visible = true;
        pathsBox.Enabled = false;
        pathsBox.Visible = false;
        buttonBrowse.Enabled = false;
        buttonBrowse.Visible = false;
      }
      else if (radioPath.Checked)
      {
        Text = "Insert from path(s)";
        titleBox.Enabled = false;
        titleBox.Visible = false;
        pathsBox.Enabled = true;
        pathsBox.Visible = true;
        buttonBrowse.Enabled = true;
        buttonBrowse.Visible = true;
      }
      else
      {
        radioScript.Checked = true;
        RefreshElements();
      }
    }
  }
}
