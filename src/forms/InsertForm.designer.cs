namespace Gemini
{
    partial class InsertForm
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
            this.titleBox = new System.Windows.Forms.TextBox();
            this.pathsBox = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.radioPath = new System.Windows.Forms.RadioButton();
            this.radioScript = new System.Windows.Forms.RadioButton();
            this.radioBelow = new System.Windows.Forms.RadioButton();
            this.radioUnder = new System.Windows.Forms.RadioButton();
            this.groupInsert = new System.Windows.Forms.GroupBox();
            this.groupScript = new System.Windows.Forms.GroupBox();
            this.groupInsert.SuspendLayout();
            this.groupScript.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleBox
            // 
            this.titleBox.Location = new System.Drawing.Point(6, 42);
            this.titleBox.Name = "titleBox";
            this.titleBox.Size = new System.Drawing.Size(246, 20);
            this.titleBox.TabIndex = 3;
            this.titleBox.Text = "New Item";
            this.toolTip.SetToolTip(this.titleBox, "The name of the new item to insert");
            this.titleBox.TextChanged += new System.EventHandler(this.titleBox_TextChanged);
            // 
            // pathsBox
            // 
            this.pathsBox.Enabled = false;
            this.pathsBox.Location = new System.Drawing.Point(6, 42);
            this.pathsBox.Name = "pathsBox";
            this.pathsBox.Size = new System.Drawing.Size(182, 20);
            this.pathsBox.TabIndex = 3;
            this.toolTip.SetToolTip(this.pathsBox, "A path or some paths to import scripts from");
            this.pathsBox.Visible = false;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Enabled = false;
            this.buttonBrowse.Location = new System.Drawing.Point(193, 42);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(59, 20);
            this.buttonBrowse.TabIndex = 4;
            this.buttonBrowse.Text = "Browse";
            this.toolTip.SetToolTip(this.buttonBrowse, "Browse for a directory");
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Visible = false;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(115, 141);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "OK";
            this.toolTip.SetToolTip(this.buttonOK, "Insert Script or Scripts");
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(196, 141);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.toolTip.SetToolTip(this.buttonCancel, "Return to editor");
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // radioPath
            // 
            this.radioPath.AutoSize = true;
            this.radioPath.Location = new System.Drawing.Point(89, 19);
            this.radioPath.Name = "radioPath";
            this.radioPath.Size = new System.Drawing.Size(91, 17);
            this.radioPath.TabIndex = 2;
            this.radioPath.Text = "Existing File(s)";
            this.radioPath.UseVisualStyleBackColor = true;
            this.radioPath.Click += new System.EventHandler(this.radioTopUpdate);
            // 
            // radioScript
            // 
            this.radioScript.AutoSize = true;
            this.radioScript.Location = new System.Drawing.Point(6, 19);
            this.radioScript.Name = "radioScript";
            this.radioScript.Size = new System.Drawing.Size(77, 17);
            this.radioScript.TabIndex = 1;
            this.radioScript.Text = "New Script";
            this.radioScript.UseVisualStyleBackColor = true;
            this.radioScript.Click += new System.EventHandler(this.radioTopUpdate);
            // 
            // radioBelow
            // 
            this.radioBelow.AutoSize = true;
            this.radioBelow.Location = new System.Drawing.Point(6, 19);
            this.radioBelow.Name = "radioBelow";
            this.radioBelow.Size = new System.Drawing.Size(82, 17);
            this.radioBelow.TabIndex = 4;
            this.radioBelow.Text = "Insert below";
            this.radioBelow.UseVisualStyleBackColor = true;
            // 
            // radioUnder
            // 
            this.radioUnder.AutoSize = true;
            this.radioUnder.Location = new System.Drawing.Point(93, 19);
            this.radioUnder.Name = "radioUnder";
            this.radioUnder.Size = new System.Drawing.Size(81, 17);
            this.radioUnder.TabIndex = 5;
            this.radioUnder.Text = "Insert under";
            this.radioUnder.UseVisualStyleBackColor = true;
            // 
            // groupInsert
            // 
            this.groupInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupInsert.Controls.Add(this.radioBelow);
            this.groupInsert.Controls.Add(this.radioUnder);
            this.groupInsert.Location = new System.Drawing.Point(12, 93);
            this.groupInsert.Name = "groupInsert";
            this.groupInsert.Size = new System.Drawing.Size(259, 42);
            this.groupInsert.TabIndex = 1;
            this.groupInsert.TabStop = false;
            this.groupInsert.Text = "Insert Options";
            // 
            // groupScript
            // 
            this.groupScript.Controls.Add(this.radioScript);
            this.groupScript.Controls.Add(this.radioPath);
            this.groupScript.Controls.Add(this.pathsBox);
            this.groupScript.Controls.Add(this.titleBox);
            this.groupScript.Controls.Add(this.buttonBrowse);
            this.groupScript.Location = new System.Drawing.Point(12, 12);
            this.groupScript.Name = "groupScript";
            this.groupScript.Size = new System.Drawing.Size(258, 70);
            this.groupScript.TabIndex = 0;
            this.groupScript.TabStop = false;
            this.groupScript.Text = "Script Options";
            // 
            // InsertForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(283, 176);
            this.Controls.Add(this.groupScript);
            this.Controls.Add(this.groupInsert);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsertForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Insert...";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formClosing);
            this.groupInsert.ResumeLayout(false);
            this.groupInsert.PerformLayout();
            this.groupScript.ResumeLayout(false);
            this.groupScript.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TextBox titleBox;
		private System.Windows.Forms.TextBox pathsBox;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.RadioButton radioPath;
    private System.Windows.Forms.RadioButton radioScript;
    private System.Windows.Forms.RadioButton radioBelow;
    private System.Windows.Forms.RadioButton radioUnder;
    private System.Windows.Forms.GroupBox groupInsert;
    private System.Windows.Forms.GroupBox groupScript;
  }
}