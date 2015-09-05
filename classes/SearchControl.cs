using System.Windows.Forms;

namespace Gemini
{
    public partial class SearchControl : UserControl
    {
        public SearchControl()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
            toolStripComboBox_Scope.SelectedIndex = 0;
        }

        private void toolStripMenuItem_OptionsItem_Click(object sender, System.EventArgs e)
        {
            toolStripDropDownButton_Options.ShowDropDown();
            ((ToolStripMenuItem)sender).Select();
        }

        private void toolStripTextBox_SearchString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                toolStripButton_Search.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
