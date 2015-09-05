using System.Windows.Forms;

namespace Gemini
{
  public partial class RunVarsForm : Form
  {
    public string Executable { get { return textExecutable.Text; } }
    public string Arguments { get { return textArguments.Text; } }

    public RunVarsForm()
    {
      InitializeComponent();
      textExecutable.Text = Settings.RuntimeExecutable;
      textArguments.Text = Settings.RuntimeArguments;
    }

    private void buttonOK_Click( object sender, System.EventArgs e )
    { Close(); }
    
  }
}
