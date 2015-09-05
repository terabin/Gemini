namespace Gemini
{
	partial class AutoCompleteForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoCompleteForm));
            this.textBoxList = new System.Windows.Forms.TextBox();
            this.groupBoxGroups = new System.Windows.Forms.GroupBox();
            this.checkedListBoxGroups = new System.Windows.Forms.CheckedListBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxHelp = new System.Windows.Forms.TextBox();
            this.numericUpDownCharacters = new System.Windows.Forms.NumericUpDown();
            this.labelCharacters = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSort = new System.Windows.Forms.Button();
            this.groupBoxGroups.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharacters)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxList
            // 
            this.textBoxList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxList.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxList.Location = new System.Drawing.Point(3, 16);
            this.textBoxList.Multiline = true;
            this.textBoxList.Name = "textBoxList";
            this.textBoxList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxList.Size = new System.Drawing.Size(434, 104);
            this.textBoxList.TabIndex = 0;
            this.toolTip.SetToolTip(this.textBoxList, "The words defined for the autocomplete");
            // 
            // groupBoxGroups
            // 
            this.groupBoxGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxGroups.Controls.Add(this.checkedListBoxGroups);
            this.groupBoxGroups.Location = new System.Drawing.Point(12, 141);
            this.groupBoxGroups.Name = "groupBoxGroups";
            this.groupBoxGroups.Size = new System.Drawing.Size(164, 129);
            this.groupBoxGroups.TabIndex = 2;
            this.groupBoxGroups.TabStop = false;
            this.groupBoxGroups.Text = "Active Word Groups";
            // 
            // checkedListBoxGroups
            // 
            this.checkedListBoxGroups.CheckOnClick = true;
            this.checkedListBoxGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxGroups.FormattingEnabled = true;
            this.checkedListBoxGroups.Items.AddRange(new object[] {
            "Ruby Constants",
            "Ruby Keywords",
            "Kernel Functions",
            "RPG Maker Constants",
            "RPG Maker Globals",
            "Custom Words"});
            this.checkedListBoxGroups.Location = new System.Drawing.Point(3, 16);
            this.checkedListBoxGroups.Name = "checkedListBoxGroups";
            this.checkedListBoxGroups.Size = new System.Drawing.Size(158, 110);
            this.checkedListBoxGroups.TabIndex = 2;
            this.toolTip.SetToolTip(this.checkedListBoxGroups, "Select the word groups");
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(377, 247);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.toolTip.SetToolTip(this.buttonOK, "Apply changes and return to previous window");
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(296, 247);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.toolTip.SetToolTip(this.buttonCancel, "Exit window without applying changes");
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxHelp
            // 
            this.textBoxHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHelp.Location = new System.Drawing.Point(182, 141);
            this.textBoxHelp.Multiline = true;
            this.textBoxHelp.Name = "textBoxHelp";
            this.textBoxHelp.ReadOnly = true;
            this.textBoxHelp.Size = new System.Drawing.Size(270, 74);
            this.textBoxHelp.TabIndex = 5;
            this.textBoxHelp.Text = resources.GetString("textBoxHelp.Text");
            // 
            // numericUpDownCharacters
            // 
            this.numericUpDownCharacters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownCharacters.Location = new System.Drawing.Point(330, 221);
            this.numericUpDownCharacters.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCharacters.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownCharacters.Name = "numericUpDownCharacters";
            this.numericUpDownCharacters.Size = new System.Drawing.Size(44, 20);
            this.numericUpDownCharacters.TabIndex = 6;
            this.toolTip.SetToolTip(this.numericUpDownCharacters, "Determine the number of characters required to enable autocomplete");
            this.numericUpDownCharacters.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // labelCharacters
            // 
            this.labelCharacters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCharacters.AutoSize = true;
            this.labelCharacters.Location = new System.Drawing.Point(380, 223);
            this.labelCharacters.Name = "labelCharacters";
            this.labelCharacters.Size = new System.Drawing.Size(60, 13);
            this.labelCharacters.TabIndex = 7;
            this.labelCharacters.Text = "characters.";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(182, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Auto-Completion begins after";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 123);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom Words List";
            // 
            // buttonSort
            // 
            this.buttonSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSort.Location = new System.Drawing.Point(179, 247);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(75, 23);
            this.buttonSort.TabIndex = 10;
            this.buttonSort.Text = "Sort List";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.buttonSort_Click);
            // 
            // AutoCompleteForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(464, 282);
            this.Controls.Add(this.buttonSort);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCharacters);
            this.Controls.Add(this.numericUpDownCharacters);
            this.Controls.Add(this.textBoxHelp);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxGroups);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 320);
            this.Name = "AutoCompleteForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auto-Complete Configuration";
            this.groupBoxGroups.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCharacters)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.GroupBox groupBoxGroups;
		private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.TextBox textBoxHelp;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label labelCharacters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox textBoxList;
        public System.Windows.Forms.CheckedListBox checkedListBoxGroups;
        public System.Windows.Forms.NumericUpDown numericUpDownCharacters;
        private System.Windows.Forms.Button buttonSort;
	}
}