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
    public string Title { get { return (radioGroup.Checked ? "▼ " : "") + titleBox.Text; } }
    public string[] Paths { get { return _filePaths; } }
    public bool AddNew { get { return radioScript.Checked || radioGroup.Checked; } }

    private Regex _removeInvalidChars = new Regex(
      @"[^A-Za-z0-9 +\-_=.,!@#$%^&();'(){}[\]]+",
      RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public InsertForm()
    {
      InitializeComponent();
      pathsBox.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      RefreshElements();
    }

    private void buttonOK_Click( object sender, EventArgs e )
    { Close(); }

    private void buttonBrowse_Click( object sender, EventArgs e )
    {
      using (OpenFileDialog dialog = new OpenFileDialog())
      {
        dialog.Filter = "Ruby Script|*.rb|Text Files|*.txt|All Documents|*";
        dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        dialog.Title = "Browse for Scripts...";
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

    private void radioUpdate( object sender, EventArgs e )
    {
      RefreshElements();
    }

    public void RefreshElements()
    {
      if (radioScript.Checked)
      {
        titleBox.Enabled = true;
        titleBox.Visible = true;
        pathsBox.Enabled = false;
        pathsBox.Visible = false;
        buttonBrowse.Enabled = false;
        buttonBrowse.Visible = false;
      }
      else if (radioGroup.Checked)
      {
        titleBox.Enabled = true;
        titleBox.Visible = true;
        pathsBox.Enabled = false;
        pathsBox.Visible = false;
        buttonBrowse.Enabled = false;
        buttonBrowse.Visible = false;
      }
      else if (radioPath.Checked)
      {
        titleBox.Enabled = false;
        titleBox.Visible = false;
        pathsBox.Enabled = true;
        pathsBox.Visible = true;
        buttonBrowse.Enabled = true;
        buttonBrowse.Visible = true;
      }
      else
      {
        radioGroup.Checked = true;
        RefreshElements();
      }
    }
  }
}
