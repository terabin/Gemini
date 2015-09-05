namespace Gemini
{
    partial class RunVarsForm
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
      this.textExecutable = new System.Windows.Forms.TextBox();
      this.textArguments = new System.Windows.Forms.TextBox();
      this.buttonOK = new System.Windows.Forms.Button();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.toolTip = new System.Windows.Forms.ToolTip(this.components);
      this.labelName = new System.Windows.Forms.Label();
      this.labelDebug = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // textExecutable
      // 
      this.textExecutable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textExecutable.Location = new System.Drawing.Point(104, 9);
      this.textExecutable.Name = "textExecutable";
      this.textExecutable.Size = new System.Drawing.Size(167, 20);
      this.textExecutable.TabIndex = 3;
      this.toolTip.SetToolTip(this.textExecutable, "The name of the new item to insert");
      // 
      // textArguments
      // 
      this.textArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textArguments.Location = new System.Drawing.Point(104, 35);
      this.textArguments.Name = "textArguments";
      this.textArguments.Size = new System.Drawing.Size(167, 20);
      this.textArguments.TabIndex = 3;
      this.toolTip.SetToolTip(this.textArguments, "A path or some paths to import scripts from");
      // 
      // buttonOK
      // 
      this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOK.Location = new System.Drawing.Point(115, 61);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOK.TabIndex = 0;
      this.buttonOK.Text = "OK";
      this.toolTip.SetToolTip(this.buttonOK, "Insert Script or Scripts");
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
      // 
      // buttonCancel
      // 
      this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(196, 61);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 1;
      this.buttonCancel.Text = "Cancel";
      this.toolTip.SetToolTip(this.buttonCancel, "Return to editor");
      this.buttonCancel.UseVisualStyleBackColor = true;
      // 
      // labelName
      // 
      this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.labelName.AutoSize = true;
      this.labelName.Location = new System.Drawing.Point(9, 12);
      this.labelName.Name = "labelName";
      this.labelName.Size = new System.Drawing.Size(91, 13);
      this.labelName.TabIndex = 8;
      this.labelName.Text = "Executable Name";
      // 
      // labelDebug
      // 
      this.labelDebug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.labelDebug.AutoSize = true;
      this.labelDebug.Location = new System.Drawing.Point(9, 38);
      this.labelDebug.Name = "labelDebug";
      this.labelDebug.Size = new System.Drawing.Size(92, 13);
      this.labelDebug.TabIndex = 8;
      this.labelDebug.Text = "Debug Arguments";
      // 
      // RunVarsForm
      // 
      this.AcceptButton = this.buttonOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(283, 96);
      this.Controls.Add(this.labelDebug);
      this.Controls.Add(this.labelName);
      this.Controls.Add(this.textArguments);
      this.Controls.Add(this.textExecutable);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.buttonOK);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "RunVarsForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Configure Runtime";
      this.ResumeLayout(false);
      this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TextBox textExecutable;
		private System.Windows.Forms.TextBox textArguments;
		private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.Label labelName;
    private System.Windows.Forms.Label labelDebug;
  }
}