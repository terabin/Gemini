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
      this.radioGroup = new System.Windows.Forms.RadioButton();
      this.radioPath = new System.Windows.Forms.RadioButton();
      this.radioScript = new System.Windows.Forms.RadioButton();
      this.SuspendLayout();
      // 
      // titleBox
      // 
      this.titleBox.Location = new System.Drawing.Point(12, 38);
      this.titleBox.Name = "titleBox";
      this.titleBox.Size = new System.Drawing.Size(259, 20);
      this.titleBox.TabIndex = 1;
      this.titleBox.Text = "New Item";
      this.toolTip.SetToolTip(this.titleBox, "The name of the new item to insert");
      this.titleBox.TextChanged += new System.EventHandler(this.titleBox_TextChanged);
      // 
      // pathsBox
      // 
      this.pathsBox.Enabled = false;
      this.pathsBox.Location = new System.Drawing.Point(12, 38);
      this.pathsBox.Name = "pathsBox";
      this.pathsBox.Size = new System.Drawing.Size(195, 20);
      this.pathsBox.TabIndex = 3;
      this.toolTip.SetToolTip(this.pathsBox, "A path or some paths to import scripts from");
      this.pathsBox.Visible = false;
      // 
      // buttonBrowse
      // 
      this.buttonBrowse.Enabled = false;
      this.buttonBrowse.Location = new System.Drawing.Point(213, 37);
      this.buttonBrowse.Name = "buttonBrowse";
      this.buttonBrowse.Size = new System.Drawing.Size(59, 22);
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
      this.buttonOK.Location = new System.Drawing.Point(115, 64);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOK.TabIndex = 5;
      this.buttonOK.Text = "OK";
      this.toolTip.SetToolTip(this.buttonOK, "Insert Script or Scripts");
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(196, 64);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 6;
      this.buttonCancel.Text = "Cancel";
      this.toolTip.SetToolTip(this.buttonCancel, "Return to editor");
      this.buttonCancel.UseVisualStyleBackColor = true;
      // 
      // radioGroup
      // 
      this.radioGroup.AutoSize = true;
      this.radioGroup.Location = new System.Drawing.Point(95, 12);
      this.radioGroup.Name = "radioGroup";
      this.radioGroup.Size = new System.Drawing.Size(79, 17);
      this.radioGroup.TabIndex = 7;
      this.radioGroup.Text = "New Group";
      this.radioGroup.UseVisualStyleBackColor = true;
      this.radioGroup.Click += new System.EventHandler(this.radioUpdate);
      // 
      // radioPath
      // 
      this.radioPath.AutoSize = true;
      this.radioPath.Location = new System.Drawing.Point(180, 12);
      this.radioPath.Name = "radioPath";
      this.radioPath.Size = new System.Drawing.Size(91, 17);
      this.radioPath.TabIndex = 7;
      this.radioPath.Text = "Existing File(s)";
      this.radioPath.UseVisualStyleBackColor = true;
      this.radioPath.Click += new System.EventHandler(this.radioUpdate);
      // 
      // radioScript
      // 
      this.radioScript.AutoSize = true;
      this.radioScript.Checked = true;
      this.radioScript.Location = new System.Drawing.Point(12, 12);
      this.radioScript.Name = "radioScript";
      this.radioScript.Size = new System.Drawing.Size(77, 17);
      this.radioScript.TabIndex = 7;
      this.radioScript.TabStop = true;
      this.radioScript.Text = "New Script";
      this.radioScript.UseVisualStyleBackColor = true;
      this.radioScript.Click += new System.EventHandler(this.radioUpdate);
      // 
      // InsertForm
      // 
      this.AcceptButton = this.buttonOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(283, 99);
      this.Controls.Add(this.pathsBox);
      this.Controls.Add(this.titleBox);
      this.Controls.Add(this.radioPath);
      this.Controls.Add(this.radioScript);
      this.Controls.Add(this.radioGroup);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOK);
      this.Controls.Add(this.buttonBrowse);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "InsertForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Insert...";
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TextBox titleBox;
		private System.Windows.Forms.TextBox pathsBox;
		private System.Windows.Forms.Button buttonBrowse;
		private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.RadioButton radioGroup;
        private System.Windows.Forms.RadioButton radioPath;
    private System.Windows.Forms.RadioButton radioScript;
  }
}