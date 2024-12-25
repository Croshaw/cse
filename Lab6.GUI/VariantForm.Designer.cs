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
			panel2 = new System.Windows.Forms.Panel();
			flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			AddPointBTN = new System.Windows.Forms.Button();
			RemovePointBTN = new System.Windows.Forms.Button();
			PointsPanel = new System.Windows.Forms.FlowLayoutPanel();
			panel3 = new System.Windows.Forms.Panel();
			RunButton = new System.Windows.Forms.Button();
			panel1.SuspendLayout();
			flowLayoutPanel2.SuspendLayout();
			panel2.SuspendLayout();
			flowLayoutPanel1.SuspendLayout();
			panel3.SuspendLayout();
			SuspendLayout();
			// 
			// plotView1
			// 
			plotView1.Dock = System.Windows.Forms.DockStyle.Fill;
			plotView1.Location = new System.Drawing.Point(0, 0);
			plotView1.Name = "plotView1";
			plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
			plotView1.Size = new System.Drawing.Size(821, 230);
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
			flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
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
			UnknownXPanel.Location = new System.Drawing.Point(0, 0);
			UnknownXPanel.Name = "UnknownXPanel";
			UnknownXPanel.Size = new System.Drawing.Size(0, 83);
			UnknownXPanel.TabIndex = 0;
			UnknownXPanel.WrapContents = false;
			// 
			// panel2
			// 
			panel2.AutoScroll = true;
			panel2.Controls.Add(flowLayoutPanel1);
			panel2.Controls.Add(PointsPanel);
			panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			panel2.Location = new System.Drawing.Point(0, 230);
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
			flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
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
			PointsPanel.Location = new System.Drawing.Point(0, 0);
			PointsPanel.Name = "PointsPanel";
			PointsPanel.Size = new System.Drawing.Size(0, 95);
			PointsPanel.TabIndex = 0;
			PointsPanel.WrapContents = false;
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
			// VariantForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(821, 450);
			Controls.Add(plotView1);
			Controls.Add(panel2);
			Controls.Add(panel1);
			Controls.Add(panel3);
			Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			Text = "Form1";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			flowLayoutPanel2.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			flowLayoutPanel1.ResumeLayout(false);
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			ResumeLayout(false);
		}

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
