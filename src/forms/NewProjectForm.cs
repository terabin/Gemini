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
	public partial class NewProjectForm : Form
	{

		public string GameTitle { get { return textBoxTitle.Text; } }
		public string ProjectDirectory { get { return textBoxDirectory.Text; } }
		public bool IncludeLibrary { get { return checkBoxInclude.Checked; } }
		public bool OpenProject { get { return checkBoxOpen.Checked; } }

        private Regex _removeInvalidChars = new Regex(
            "[{" + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "}]",
            RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.CultureInvariant);

		public NewProjectForm(string engine)
		{
            InitializeComponent();
            textBoxDirectory.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			if (engine == "RMXP")
			{
				textBoxDirectory.Text += @"\RPGXP\";
				checkBoxInclude.Text += "RGSS104E.dll";
            }
            else if (engine == "RMVX")
            {
                textBoxDirectory.Text += @"\RPGVX\";
                checkBoxInclude.Text += "RGSS202E.dll";
            }
            else if (engine == "RMVXAce")
            {
                textBoxDirectory.Text += @"\RPGVXAce\";
                checkBoxInclude.Text += "RGSS301.dll";
            }
            int id = 0;
            string title;
            do title = "Project" + (++id).ToString();
            while (Directory.Exists(textBoxDirectory.Text + @"\" + title));
            textBoxTitle.Text = title;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			if (Directory.Exists(ProjectDirectory))
			{
				MessageBox.Show("Directory already exists!\nPlease choose another path.",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog dialog = new FolderBrowserDialog())
			{
				dialog.RootFolder = Environment.SpecialFolder.MyComputer;
				dialog.Description = "Select a directory to create the new project in.";
				dialog.ShowNewFolderButton = false;
				if (dialog.ShowDialog() == DialogResult.OK)
                    textBoxDirectory.Text = dialog.SelectedPath + @"\" + textBoxTitle.Text;
			}
		}

		private void textBoxTitle_TextChanged(object sender, EventArgs e)
		{
            string text = _removeInvalidChars.Replace(textBoxTitle.Text, "");
            textBoxDirectory.Text = Path.GetDirectoryName(textBoxDirectory.Text) + @"\" + text;
		}
	}
}
