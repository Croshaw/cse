using Lab6.GUI.Controls;

namespace Lab6.GUI
{
	partial class VariantForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
			plotView1 = new OxyPlot.WindowsForms.PlotView();
			panel1 = new System.Windows.Forms.Panel();
			flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			AddUnknownXBTN = new System.Windows.Forms.Button();
			RemoveUnknownXBTN = new System.Windows.Forms.Button();
			UnknownXPanel = new System.Windows.Forms.FlowLayoutPanel();
			flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
			label3 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			panel2 = new System.Windows.Forms.Panel();
			flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			AddPointBTN = new System.Windows.Forms.Button();
			RemovePointBTN = new System.Windows.Forms.Button();
			PointsPanel = new System.Windows.Forms.FlowLayoutPanel();
			flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			RunButton = new System.Windows.Forms.Button();
			label5 = new System.Windows.Forms.Label();
			panel1.SuspendLayout();
			flowLayoutPanel2.SuspendLayout();
			flowLayoutPanel4.SuspendLayout();
			panel2.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			flowLayoutPanel3.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			// 
			// plotView1
			// 
			plotView1.Dock = System.Windows.Forms.DockStyle.Fill;
			plotView1.Location = new System.Drawing.Point(0, 0);
			plotView1.Name = "plotView1";
			plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
			plotView1.Size = new System.Drawing.Size(821, 166);
			plotView1.TabIndex = 1;
			plotView1.Text = "plotView1";
			plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
			plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
			plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
			// 
			// panel1
			// 
			panel1.AutoScroll = true;
			panel1.Controls.Add(flowLayoutPanel2);
			panel1.Controls.Add(UnknownXPanel);
			panel1.Controls.Add(flowLayoutPanel4);
			panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			panel1.Location = new System.Drawing.Point(0, 325);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(821, 83);
			panel1.TabIndex = 2;
			// 
			// flowLayoutPanel2
			// 
			flowLayoutPanel2.AutoSize = true;
			flowLayoutPanel2.Controls.Add(AddUnknownXBTN);
			flowLayoutPanel2.Controls.Add(RemoveUnknownXBTN);
			flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Left;
			flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			flowLayoutPanel2.Location = new System.Drawing.Point(23, 0);
			flowLayoutPanel2.Name = "flowLayoutPanel2";
			flowLayoutPanel2.Size = new System.Drawing.Size(28, 83);
			flowLayoutPanel2.TabIndex = 2;
			// 
			// AddUnknownXBTN
			// 
			AddUnknownXBTN.Location = new System.Drawing.Point(3, 3);
			AddUnknownXBTN.Name = "AddUnknownXBTN";
			AddUnknownXBTN.Size = new System.Drawing.Size(22, 25);
			AddUnknownXBTN.TabIndex = 1;
			AddUnknownXBTN.Text = "+";
			AddUnknownXBTN.UseVisualStyleBackColor = true;
			// 
			// RemoveUnknownXBTN
			// 
			RemoveUnknownXBTN.Location = new System.Drawing.Point(3, 34);
			RemoveUnknownXBTN.Name = "RemoveUnknownXBTN";
			RemoveUnknownXBTN.Size = new System.Drawing.Size(22, 25);
			RemoveUnknownXBTN.TabIndex = 0;
			RemoveUnknownXBTN.Text = "-";
			RemoveUnknownXBTN.UseVisualStyleBackColor = true;
			// 
			// UnknownXPanel
			// 
			UnknownXPanel.AutoSize = true;
			UnknownXPanel.Dock = System.Windows.Forms.DockStyle.Left;
			UnknownXPanel.Location = new System.Drawing.Point(23, 0);
			UnknownXPanel.Name = "UnknownXPanel";
			UnknownXPanel.Size = new System.Drawing.Size(0, 83);
			UnknownXPanel.TabIndex = 0;
			UnknownXPanel.WrapContents = false;
			// 
			// flowLayoutPanel4
			// 
			flowLayoutPanel4.AutoSize = true;
			flowLayoutPanel4.Controls.Add(label3);
			flowLayoutPanel4.Controls.Add(label4);
			flowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Left;
			flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			flowLayoutPanel4.Location = new System.Drawing.Point(0, 0);
			flowLayoutPanel4.Name = "flowLayoutPanel4";
			flowLayoutPanel4.Size = new System.Drawing.Size(23, 83);
			flowLayoutPanel4.TabIndex = 3;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(3, 0);
			label3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 17);
			label3.Name = "label3";
			label3.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
			label3.Size = new System.Drawing.Size(17, 22);
			label3.TabIndex = 3;
			label3.Text = "X:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(3, 39);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(17, 15);
			label4.TabIndex = 2;
			label4.Text = "Y:";
			// 
			// panel2
			// 
			panel2.AutoScroll = true;
			panel2.Controls.Add(flowLayoutPanel1);
			panel2.Controls.Add(PointsPanel);
			panel2.Controls.Add(flowLayoutPanel3);
			panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			panel2.Location = new System.Drawing.Point(0, 166);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(821, 95);
			panel2.TabIndex = 3;
			// 
			// flowLayoutPanel1
			// 
			flowLayoutPanel1.AutoSize = true;
			flowLayoutPanel1.Controls.Add(AddPointBTN);
			flowLayoutPanel1.Controls.Add(RemovePointBTN);
			flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
			flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			flowLayoutPanel1.Location = new System.Drawing.Point(23, 0);
			flowLayoutPanel1.Name = "flowLayoutPanel1";
			flowLayoutPanel1.Size = new System.Drawing.Size(28, 95);
			flowLayoutPanel1.TabIndex = 1;
			// 
			// AddPointBTN
			// 
			AddPointBTN.Location = new System.Drawing.Point(3, 3);
			AddPointBTN.Name = "AddPointBTN";
			AddPointBTN.Size = new System.Drawing.Size(22, 25);
			AddPointBTN.TabIndex = 1;
			AddPointBTN.Text = "+";
			AddPointBTN.UseVisualStyleBackColor = true;
			// 
			// RemovePointBTN
			// 
			RemovePointBTN.Location = new System.Drawing.Point(3, 34);
			RemovePointBTN.Name = "RemovePointBTN";
			RemovePointBTN.Size = new System.Drawing.Size(22, 25);
			RemovePointBTN.TabIndex = 0;
			RemovePointBTN.Text = "-";
			RemovePointBTN.UseVisualStyleBackColor = true;
			// 
			// PointsPanel
			// 
			PointsPanel.AutoSize = true;
			PointsPanel.Dock = System.Windows.Forms.DockStyle.Left;
			PointsPanel.Location = new System.Drawing.Point(23, 0);
			PointsPanel.Name = "PointsPanel";
			PointsPanel.Size = new System.Drawing.Size(0, 95);
			PointsPanel.TabIndex = 0;
			PointsPanel.WrapContents = false;
			// 
			// flowLayoutPanel3
			// 
			flowLayoutPanel3.AutoSize = true;
			flowLayoutPanel3.Controls.Add(label2);
			flowLayoutPanel3.Controls.Add(label1);
			flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
			flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			flowLayoutPanel3.Location = new System.Drawing.Point(0, 0);
			flowLayoutPanel3.Name = "flowLayoutPanel3";
			flowLayoutPanel3.Size = new System.Drawing.Size(23, 95);
			flowLayoutPanel3.TabIndex = 2;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(3, 0);
			label2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 17);
			label2.Name = "label2";
			label2.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
			label2.Size = new System.Drawing.Size(17, 22);
			label2.TabIndex = 3;
			label2.Text = "X:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(3, 39);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(17, 15);
			label1.TabIndex = 2;
			label1.Text = "Y:";
			// 
			// panel3
			// 
			panel3.Controls.Add(RunButton);
			panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
			panel3.Location = new System.Drawing.Point(0, 408);
			panel3.Name = "panel3";
			panel3.Padding = new System.Windows.Forms.Padding(100, 10, 100, 10);
			panel3.Size = new System.Drawing.Size(821, 42);
			panel3.TabIndex = 4;
			// 
			// RunButton
			// 
			RunButton.AutoSize = true;
			RunButton.Dock = System.Windows.Forms.DockStyle.Fill;
			RunButton.Location = new System.Drawing.Point(100, 10);
			RunButton.Name = "RunButton";
			RunButton.Size = new System.Drawing.Size(621, 22);
			RunButton.TabIndex = 0;
			RunButton.Text = "Запустить";
			RunButton.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			label5.AutoEllipsis = true;
			label5.Dock = System.Windows.Forms.DockStyle.Bottom;
			label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)204));
			label5.Location = new System.Drawing.Point(0, 261);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(821, 64);
			label5.TabIndex = 5;
			label5.Text = "Результат:";
			// 
			// VariantForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(821, 450);
			Controls.Add(plotView1);
			Controls.Add(panel2);
			Controls.Add(label5);
			Controls.Add(panel1);
			Controls.Add(panel3);
			Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			Text = "Form1";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			flowLayoutPanel2.ResumeLayout(false);
			flowLayoutPanel4.ResumeLayout(false);
			flowLayoutPanel4.PerformLayout();
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			flowLayoutPanel1.ResumeLayout(false);
			flowLayoutPanel3.ResumeLayout(false);
			flowLayoutPanel3.PerformLayout();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			ResumeLayout(false);
		}

		private System.Windows.Forms.Label label5;

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;

		private System.Windows.Forms.Button AddUnknownXBTN;
		private System.Windows.Forms.Button RemoveUnknownXBTN;

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.FlowLayoutPanel UnknownXPanel;

		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button RunButton;

		private System.Windows.Forms.Button RemovePointBTN;
		private System.Windows.Forms.Button AddPointBTN;

		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.FlowLayoutPanel PointsPanel;

		private System.Windows.Forms.Panel panel1;

		#endregion

		private OxyPlot.WindowsForms.PlotView plotView1;
	}
}
