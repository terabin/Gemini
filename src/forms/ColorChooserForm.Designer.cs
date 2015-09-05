using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

namespace Gemini
{
	public partial class ColorChooserForm : Form
	{
		private ColorHandler.ARGB argb;
		private Button btnCancel;
		private Button btnOk;
		private ChangeStyle changeType = ChangeStyle.None;
		private ColorHandler.HSV hsv;
		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private Label lblAlpha;
		private Label lblBlue;
		private Label lblGreen;
		private Label lblHue;
		private Label lblRed;
		private Label lblSaturation;
		private Label lblValue;
		private ColorWheel myColorWheel;
		private Panel pnlBrightness;
		private Panel pnlColor;
		private Panel pnlSelectedColor;
		private Point selectedPoint;
		private TrackBar tbAlpha;
		private TrackBar tbBlue;
		private TrackBar tbGreen;
		private TextBox tbHexCode;
		private TrackBar tbHue;
		private TrackBar tbRed;
		private TrackBar tbSaturation;
		private TrackBar tbValue;

		#region Windows Form Designer generated code

		/// <summary>
		///   Required method for Designer support - do not modify
		///   the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.lblBlue = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.lblSaturation = new System.Windows.Forms.Label();
            this.lblHue = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlBrightness = new System.Windows.Forms.Panel();
            this.lblAlpha = new System.Windows.Forms.Label();
            this.tbHexCode = new System.Windows.Forms.TextBox();
            this.tbHue = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSaturation = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRed = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.tbGreen = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.tbBlue = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.tbAlpha = new System.Windows.Forms.TrackBar();
            this.pnlSelectedColor = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.tbHue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAlpha)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBlue
            // 
            this.lblBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBlue.Location = new System.Drawing.Point(312, 152);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(39, 23);
            this.lblBlue.TabIndex = 54;
            this.lblBlue.Text = "Blue";
            this.lblBlue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGreen
            // 
            this.lblGreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGreen.Location = new System.Drawing.Point(312, 126);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(39, 23);
            this.lblGreen.TabIndex = 53;
            this.lblGreen.Text = "Green";
            this.lblGreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRed
            // 
            this.lblRed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRed.Location = new System.Drawing.Point(312, 100);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(39, 23);
            this.lblRed.TabIndex = 52;
            this.lblRed.Text = "Red";
            this.lblRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblValue
            // 
            this.lblValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValue.Location = new System.Drawing.Point(312, 74);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(39, 23);
            this.lblValue.TabIndex = 51;
            this.lblValue.Text = "Value";
            this.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSaturation
            // 
            this.lblSaturation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaturation.Location = new System.Drawing.Point(312, 48);
            this.lblSaturation.Name = "lblSaturation";
            this.lblSaturation.Size = new System.Drawing.Size(39, 23);
            this.lblSaturation.TabIndex = 50;
            this.lblSaturation.Text = "Sat";
            this.lblSaturation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHue
            // 
            this.lblHue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHue.Location = new System.Drawing.Point(312, 22);
            this.lblHue.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.lblHue.Name = "lblHue";
            this.lblHue.Size = new System.Drawing.Size(41, 23);
            this.lblHue.TabIndex = 49;
            this.lblHue.Text = "Hue";
            this.lblHue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(488, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 42;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(569, 231);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 41;
            this.btnOk.Text = "OK";
            // 
            // pnlColor
            // 
            this.pnlColor.Location = new System.Drawing.Point(5, 8);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(224, 216);
            this.pnlColor.TabIndex = 38;
            this.pnlColor.Visible = false;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.TabIndex = 35;
            this.label5.Text = "Hue";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlBrightness
            // 
            this.pnlBrightness.Location = new System.Drawing.Point(235, 8);
            this.pnlBrightness.Name = "pnlBrightness";
            this.pnlBrightness.Size = new System.Drawing.Size(24, 216);
            this.pnlBrightness.TabIndex = 39;
            this.pnlBrightness.Visible = false;
            // 
            // lblAlpha
            // 
            this.lblAlpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlpha.Location = new System.Drawing.Point(312, 177);
            this.lblAlpha.Name = "lblAlpha";
            this.lblAlpha.Size = new System.Drawing.Size(39, 24);
            this.lblAlpha.TabIndex = 57;
            this.lblAlpha.Text = "Alpha";
            this.lblAlpha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbHexCode
            // 
            this.tbHexCode.BackColor = System.Drawing.Color.White;
            this.tbHexCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHexCode.Location = new System.Drawing.Point(357, 231);
            this.tbHexCode.MaxLength = 8;
            this.tbHexCode.Name = "tbHexCode";
            this.tbHexCode.ReadOnly = true;
            this.tbHexCode.Size = new System.Drawing.Size(96, 22);
            this.tbHexCode.TabIndex = 58;
            this.tbHexCode.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TbHexCodeMouseDown);
            // 
            // tbHue
            // 
            this.tbHue.AutoSize = false;
            this.tbHue.LargeChange = 16;
            this.tbHue.Location = new System.Drawing.Point(68, 24);
            this.tbHue.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.tbHue.Maximum = 255;
            this.tbHue.Name = "tbHue";
            this.tbHue.Size = new System.Drawing.Size(238, 32);
            this.tbHue.TabIndex = 36;
            this.tbHue.TickFrequency = 32;
            this.tbHue.Scroll += new System.EventHandler(this.HandleHSVScroll);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 38;
            this.label1.Text = "Saturation";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbSaturation
            // 
            this.tbSaturation.AutoSize = false;
            this.tbSaturation.LargeChange = 16;
            this.tbSaturation.Location = new System.Drawing.Point(68, 50);
            this.tbSaturation.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.tbSaturation.Maximum = 255;
            this.tbSaturation.Name = "tbSaturation";
            this.tbSaturation.Size = new System.Drawing.Size(238, 32);
            this.tbSaturation.TabIndex = 39;
            this.tbSaturation.TickFrequency = 32;
            this.tbSaturation.Scroll += new System.EventHandler(this.HandleHSVScroll);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 40;
            this.label2.Text = "Value";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbValue
            // 
            this.tbValue.AutoSize = false;
            this.tbValue.LargeChange = 16;
            this.tbValue.Location = new System.Drawing.Point(68, 76);
            this.tbValue.Margin = new System.Windows.Forms.Padding(0, 3, 3, 6);
            this.tbValue.Maximum = 255;
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(238, 32);
            this.tbValue.TabIndex = 41;
            this.tbValue.TickFrequency = 32;
            this.tbValue.Scroll += new System.EventHandler(this.HandleHSVScroll);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 42;
            this.label3.Text = "Red";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbRed
            // 
            this.tbRed.AutoSize = false;
            this.tbRed.LargeChange = 16;
            this.tbRed.Location = new System.Drawing.Point(68, 102);
            this.tbRed.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.tbRed.Maximum = 255;
            this.tbRed.Name = "tbRed";
            this.tbRed.Size = new System.Drawing.Size(238, 32);
            this.tbRed.TabIndex = 43;
            this.tbRed.TickFrequency = 32;
            this.tbRed.Scroll += new System.EventHandler(this.HandleRGBScroll);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 128);
            this.label4.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 18);
            this.label4.TabIndex = 44;
            this.label4.Text = "Green";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbGreen
            // 
            this.tbGreen.AutoSize = false;
            this.tbGreen.LargeChange = 16;
            this.tbGreen.Location = new System.Drawing.Point(68, 128);
            this.tbGreen.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.tbGreen.Maximum = 255;
            this.tbGreen.Name = "tbGreen";
            this.tbGreen.Size = new System.Drawing.Size(238, 32);
            this.tbGreen.TabIndex = 45;
            this.tbGreen.TickFrequency = 32;
            this.tbGreen.Scroll += new System.EventHandler(this.HandleRGBScroll);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 154);
            this.label6.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 18);
            this.label6.TabIndex = 46;
            this.label6.Text = "Blue";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbBlue
            // 
            this.tbBlue.AutoSize = false;
            this.tbBlue.LargeChange = 16;
            this.tbBlue.Location = new System.Drawing.Point(68, 154);
            this.tbBlue.Margin = new System.Windows.Forms.Padding(0, 3, 3, 6);
            this.tbBlue.Maximum = 255;
            this.tbBlue.Name = "tbBlue";
            this.tbBlue.Size = new System.Drawing.Size(238, 32);
            this.tbBlue.TabIndex = 47;
            this.tbBlue.TickFrequency = 32;
            this.tbBlue.Scroll += new System.EventHandler(this.HandleRGBScroll);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 180);
            this.label7.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 18);
            this.label7.TabIndex = 55;
            this.label7.Text = "Alpha";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbAlpha
            // 
            this.tbAlpha.AutoSize = false;
            this.tbAlpha.LargeChange = 16;
            this.tbAlpha.Location = new System.Drawing.Point(68, 180);
            this.tbAlpha.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
            this.tbAlpha.Maximum = 255;
            this.tbAlpha.Name = "tbAlpha";
            this.tbAlpha.Size = new System.Drawing.Size(238, 32);
            this.tbAlpha.TabIndex = 56;
            this.tbAlpha.TickFrequency = 32;
            this.tbAlpha.Scroll += new System.EventHandler(this.TbAlphaScroll);
            // 
            // pnlSelectedColor
            // 
            this.pnlSelectedColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlSelectedColor.Location = new System.Drawing.Point(287, 230);
            this.pnlSelectedColor.Name = "pnlSelectedColor";
            this.pnlSelectedColor.Size = new System.Drawing.Size(64, 24);
            this.pnlSelectedColor.TabIndex = 40;
            this.pnlSelectedColor.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblAlpha);
            this.groupBox1.Controls.Add(this.lblBlue);
            this.groupBox1.Controls.Add(this.lblGreen);
            this.groupBox1.Controls.Add(this.lblRed);
            this.groupBox1.Controls.Add(this.lblValue);
            this.groupBox1.Controls.Add(this.lblSaturation);
            this.groupBox1.Controls.Add(this.lblHue);
            this.groupBox1.Controls.Add(this.tbHue);
            this.groupBox1.Controls.Add(this.tbSaturation);
            this.groupBox1.Controls.Add(this.tbValue);
            this.groupBox1.Controls.Add(this.tbRed);
            this.groupBox1.Controls.Add(this.tbGreen);
            this.groupBox1.Controls.Add(this.tbBlue);
            this.groupBox1.Controls.Add(this.tbAlpha);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(287, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 216);
            this.groupBox1.TabIndex = 60;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Values";
            // 
            // ColorChooserForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(658, 262);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbHexCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.pnlColor);
            this.Controls.Add(this.pnlSelectedColor);
            this.Controls.Add(this.pnlBrightness);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ColorChooserForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Highlight Color";
            this.Load += new System.EventHandler(this.ColorChooserLoad);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ColorChooserPaint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.HandleMouse);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HandleMouse);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMainMouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.tbHue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSaturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbAlpha)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private GroupBox groupBox1;
	}
}