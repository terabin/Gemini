namespace Gemini
{
  partial class UpdateChannelForm
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
        _webClient.Dispose();
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
      this.labelBranch = new System.Windows.Forms.Label();
      this.buttonCancel = new System.Windows.Forms.Button();
      this.labelInfo = new System.Windows.Forms.Label();
      this.listBox = new System.Windows.Forms.ComboBox();
      this.buttonOk = new System.Windows.Forms.Button();
      this.buttonUpdate = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // labelBranch
      // 
      this.labelBranch.AutoSize = true;
      this.labelBranch.Location = new System.Drawing.Point(12, 9);
      this.labelBranch.Name = "labelBranch";
      this.labelBranch.Size = new System.Drawing.Size(87, 13);
      this.labelBranch.TabIndex = 1;
      this.labelBranch.Text = "Current Branch : ";
      // 
      // buttonCancel
      // 
      this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonCancel.Location = new System.Drawing.Point(239, 52);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new System.Drawing.Size(75, 23);
      this.buttonCancel.TabIndex = 2;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      // 
      // buttonOk
      // 
      this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.buttonOk.Location = new System.Drawing.Point(158, 52);
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.Size = new System.Drawing.Size(75, 23);
      this.buttonOk.TabIndex = 1;
      this.buttonOk.Text = "Ok";
      this.buttonOk.UseVisualStyleBackColor = true;
      // 
      // buttonUpdate
      // 
      this.buttonUpdate.Location = new System.Drawing.Point(12, 52);
      this.buttonUpdate.Name = "buttonUpdate";
      this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
      this.buttonUpdate.TabIndex = 1;
      this.buttonUpdate.Text = "Update";
      this.buttonUpdate.UseVisualStyleBackColor = true;
      this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
      // 
      // labelInfo
      // 
      this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.labelInfo.Location = new System.Drawing.Point(105, 9);
      this.labelInfo.Name = "labelInfo";
      this.labelInfo.Size = new System.Drawing.Size(209, 13);
      this.labelInfo.TabIndex = 6;
      this.labelInfo.Text = "Retriving list...";
      this.labelInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // listBox
      // 
      this.listBox.FormattingEnabled = true;
      this.listBox.Items.AddRange(new object[] {
            "master"});
      this.listBox.Location = new System.Drawing.Point(12, 25);
      this.listBox.Name = "listBox";
      this.listBox.Size = new System.Drawing.Size(302, 21);
      this.listBox.TabIndex = 0;
      this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
      // 
      // UpdateChannelForm
      // 
      this.AcceptButton = this.buttonOk;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonCancel;
      this.ClientSize = new System.Drawing.Size(326, 87);
      this.Controls.Add(this.labelBranch);
      this.Controls.Add(this.buttonUpdate);
      this.Controls.Add(this.buttonOk);
      this.Controls.Add(this.buttonCancel);
      this.Controls.Add(this.listBox);
      this.Controls.Add(this.labelInfo);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "UpdateChannelForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Branch Selection";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateForm_FormClosing);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label labelBranch;
    private System.Windows.Forms.Label labelInfo;
    private System.Windows.Forms.Button buttonCancel;
    private System.Windows.Forms.ComboBox listBox;
    private System.Windows.Forms.Button buttonOk;
    private System.Windows.Forms.Button buttonUpdate;
  }
}