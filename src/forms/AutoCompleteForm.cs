using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Gemini.Properties;

namespace Gemini
{
	public partial class AutoCompleteForm : Form
	{

		public AutoCompleteForm()
		{
			InitializeComponent();
			numericUpDownCharacters.Value = Settings.AutoCompleteLength;
            textBoxList.Text = Settings.AutoCompleteCustomWords;
            for (int i = 0; i < checkedListBoxGroups.Items.Count; i++)
                checkedListBoxGroups.SetItemChecked(i, (Settings.AutoCompleteFlag & (1 << i)) != 0);
		}

        private void buttonSort_Click(object sender, EventArgs e)
        {
            List<string> words = new List<string>();
            foreach (string word in textBoxList.Text.Split(' '))
                if (word.Length != 0 && !words.Contains(word))
                    words.Add(word);
            words.Sort();
            textBoxList.Text = string.Join(" ", words);
        }

	}
}
