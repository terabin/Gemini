namespace Gemini
{
	partial class StyleEditorForm
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
				_sampleScript.Dispose();
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
			this.listBoxStyles = new System.Windows.Forms.ListBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBoxColor = new System.Windows.Forms.GroupBox();
			this.panelBackColor = new System.Windows.Forms.Panel();
			this.labelBackColor = new System.Windows.Forms.Label();
			this.panelForeColor = new System.Windows.Forms.Panel();
			this.labelForeColor = new System.Windows.Forms.Label();
			this.groupBoxFont = new System.Windows.Forms.GroupBox();
			this.checkBoxUnderline = new System.Windows.Forms.CheckBox();
			this.checkBoxItalic = new System.Windows.Forms.CheckBox();
			this.checkBoxBold = new System.Windows.Forms.CheckBox();
			this.comboBoxSizes = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxFonts = new System.Windows.Forms.ComboBox();
			this.panelSample = new System.Windows.Forms.Panel();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.groupBoxColor.SuspendLayout();
			this.groupBoxFont.SuspendLayout();
			this.SuspendLayout();
			// 
			// listBoxStyles
			// 
			this.listBoxStyles.FormattingEnabled = true;
			this.listBoxStyles.Location = new System.Drawing.Point(12, 12);
			this.listBoxStyles.Name = "listBoxStyles";
			this.listBoxStyles.Size = new System.Drawing.Size(120, 225);
			this.listBoxStyles.TabIndex = 0;
			this.toolTip.SetToolTip(this.listBoxStyles, "Select lexer paremeter to change");
			this.listBoxStyles.SelectedIndexChanged += new System.EventHandler(this.listStyles_IndexChanged);
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(449, 215);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "OK";
			this.toolTip.SetToolTip(this.buttonOK, "Apply changes");
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(368, 215);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 2;
			this.buttonCancel.Text = "Cancel";
			this.toolTip.SetToolTip(this.buttonCancel, "Cancel changes");
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// groupBoxColor
			// 
			this.groupBoxColor.Controls.Add(this.panelBackColor);
			this.groupBoxColor.Controls.Add(this.labelBackColor);
			this.groupBoxColor.Controls.Add(this.panelForeColor);
			this.groupBoxColor.Controls.Add(this.labelForeColor);
			this.groupBoxColor.Location = new System.Drawing.Point(444, 12);
			this.groupBoxColor.Name = "groupBoxColor";
			this.groupBoxColor.Size = new System.Drawing.Size(80, 118);
			this.groupBoxColor.TabIndex = 6;
			this.groupBoxColor.TabStop = false;
			this.groupBoxColor.Text = "Color Style";
			// 
			// panelBackColor
			// 
			this.panelBackColor.BackColor = System.Drawing.Color.Black;
			this.panelBackColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelBackColor.Location = new System.Drawing.Point(9, 83);
			this.panelBackColor.Name = "panelBackColor";
			this.panelBackColor.Size = new System.Drawing.Size(65, 24);
			this.panelBackColor.TabIndex = 3;
			this.toolTip.SetToolTip(this.panelBackColor, "Backcolor\nDouble-Click to change");
			this.panelBackColor.Click += new System.EventHandler(this.panelBackColor_DoubleClick);
			// 
			// labelBackColor
			// 
			this.labelBackColor.AutoSize = true;
			this.labelBackColor.Location = new System.Drawing.Point(6, 67);
			this.labelBackColor.Name = "labelBackColor";
			this.labelBackColor.Size = new System.Drawing.Size(59, 13);
			this.labelBackColor.TabIndex = 2;
			this.labelBackColor.Text = "Back Color";
			// 
			// panelForeColor
			// 
			this.panelForeColor.BackColor = System.Drawing.Color.Black;
			this.panelForeColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelForeColor.Location = new System.Drawing.Point(6, 35);
			this.panelForeColor.Name = "panelForeColor";
			this.panelForeColor.Size = new System.Drawing.Size(68, 24);
			this.panelForeColor.TabIndex = 1;
			this.toolTip.SetToolTip(this.panelForeColor, "Forecolor\nDouble-Click to change");
			this.panelForeColor.DoubleClick += new System.EventHandler(this.panelForeColor_DoubleClick);
			// 
			// labelForeColor
			// 
			this.labelForeColor.AutoSize = true;
			this.labelForeColor.Location = new System.Drawing.Point(6, 19);
			this.labelForeColor.Name = "labelForeColor";
			this.labelForeColor.Size = new System.Drawing.Size(55, 13);
			this.labelForeColor.TabIndex = 0;
			this.labelForeColor.Text = "Fore Color";
			// 
			// groupBoxFont
			// 
			this.groupBoxFont.Controls.Add(this.checkBoxUnderline);
			this.groupBoxFont.Controls.Add(this.checkBoxItalic);
			this.groupBoxFont.Controls.Add(this.checkBoxBold);
			this.groupBoxFont.Controls.Add(this.comboBoxSizes);
			this.groupBoxFont.Controls.Add(this.label2);
			this.groupBoxFont.Controls.Add(this.label1);
			this.groupBoxFont.Controls.Add(this.comboBoxFonts);
			this.groupBoxFont.Location = new System.Drawing.Point(138, 12);
			this.groupBoxFont.Name = "groupBoxFont";
			this.groupBoxFont.Size = new System.Drawing.Size(300, 118);
			this.groupBoxFont.TabIndex = 7;
			this.groupBoxFont.TabStop = false;
			this.groupBoxFont.Text = "Font Style";
			// 
			// checkBoxUnderline
			// 
			this.checkBoxUnderline.AutoSize = true;
			this.checkBoxUnderline.Location = new System.Drawing.Point(68, 60);
			this.checkBoxUnderline.Name = "checkBoxUnderline";
			this.checkBoxUnderline.Size = new System.Drawing.Size(71, 17);
			this.checkBoxUnderline.TabIndex = 6;
			this.checkBoxUnderline.Text = "Underline";
			this.toolTip.SetToolTip(this.checkBoxUnderline, "Font underline");
			this.checkBoxUnderline.UseVisualStyleBackColor = true;
			this.checkBoxUnderline.CheckedChanged += new System.EventHandler(this.checkBoxUnderline_CheckChanged);
			// 
			// checkBoxItalic
			// 
			this.checkBoxItalic.AutoSize = true;
			this.checkBoxItalic.Location = new System.Drawing.Point(9, 83);
			this.checkBoxItalic.Name = "checkBoxItalic";
			this.checkBoxItalic.Size = new System.Drawing.Size(48, 17);
			this.checkBoxItalic.TabIndex = 5;
			this.checkBoxItalic.Text = "Italic";
			this.toolTip.SetToolTip(this.checkBoxItalic, "Font italic");
			this.checkBoxItalic.UseVisualStyleBackColor = true;
			this.checkBoxItalic.CheckedChanged += new System.EventHandler(this.checkBoxItalic_CheckChanged);
			// 
			// checkBoxBold
			// 
			this.checkBoxBold.AutoSize = true;
			this.checkBoxBold.Location = new System.Drawing.Point(9, 60);
			this.checkBoxBold.Name = "checkBoxBold";
			this.checkBoxBold.Size = new System.Drawing.Size(47, 17);
			this.checkBoxBold.TabIndex = 4;
			this.checkBoxBold.Text = "Bold";
			this.toolTip.SetToolTip(this.checkBoxBold, "Font bold ");
			this.checkBoxBold.UseVisualStyleBackColor = true;
			this.checkBoxBold.CheckedChanged += new System.EventHandler(this.checkBoxBold_CheckChanged);
			// 
			// comboBoxSizes
			// 
			this.comboBoxSizes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSizes.FormattingEnabled = true;
			this.comboBoxSizes.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28"});
			this.comboBoxSizes.Location = new System.Drawing.Point(237, 69);
			this.comboBoxSizes.Name = "comboBoxSizes";
			this.comboBoxSizes.Size = new System.Drawing.Size(57, 21);
			this.comboBoxSizes.TabIndex = 3;
			this.toolTip.SetToolTip(this.comboBoxSizes, "Font size");
			this.comboBoxSizes.SelectedIndexChanged += new System.EventHandler(this.comboSize_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(177, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Font Size:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Font Name:";
			// 
			// comboBoxFonts
			// 
			this.comboBoxFonts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxFonts.FormattingEnabled = true;
			this.comboBoxFonts.Location = new System.Drawing.Point(68, 19);
			this.comboBoxFonts.Name = "comboBoxFonts";
			this.comboBoxFonts.Size = new System.Drawing.Size(226, 21);
			this.comboBoxFonts.TabIndex = 0;
			this.toolTip.SetToolTip(this.comboBoxFonts, "Change font used for this lexer");
			this.comboBoxFonts.SelectedIndexChanged += new System.EventHandler(this.comboBoxFonts_SelectedIndexChanged);
			// 
			// panelSample
			// 
			this.panelSample.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panelSample.Location = new System.Drawing.Point(138, 136);
			this.panelSample.Name = "panelSample";
			this.panelSample.Size = new System.Drawing.Size(386, 73);
			this.panelSample.TabIndex = 8;
			this.toolTip.SetToolTip(this.panelSample, "Test lexer configuration");
			// 
			// StyleEditorForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(534, 250);
			this.Controls.Add(this.panelSample);
			this.Controls.Add(this.groupBoxFont);
			this.Controls.Add(this.groupBoxColor);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.listBoxStyles);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StyleEditorForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Style Configurator";
			this.groupBoxColor.ResumeLayout(false);
			this.groupBoxColor.PerformLayout();
			this.groupBoxFont.ResumeLayout(false);
			this.groupBoxFont.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxStyles;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.GroupBox groupBoxColor;
		private System.Windows.Forms.Panel panelBackColor;
		private System.Windows.Forms.Label labelBackColor;
		private System.Windows.Forms.Panel panelForeColor;
		private System.Windows.Forms.Label labelForeColor;
		private System.Windows.Forms.GroupBox groupBoxFont;
		private System.Windows.Forms.Panel panelSample;
		private System.Windows.Forms.CheckBox checkBoxUnderline;
		private System.Windows.Forms.CheckBox checkBoxItalic;
		private System.Windows.Forms.CheckBox checkBoxBold;
		private System.Windows.Forms.ComboBox comboBoxSizes;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxFonts;
		private System.Windows.Forms.ToolTip toolTip;
	}
}