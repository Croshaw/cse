namespace Lab7
{
	partial class MainForm
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
			tabControl1 = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			tabPage2 = new System.Windows.Forms.TabPage();
			tabPage3 = new System.Windows.Forms.TabPage();
			tabControl1.SuspendLayout();
			SuspendLayout();
			// 
			// plotView1
			// 
			plotView1.Dock = System.Windows.Forms.DockStyle.Fill;
			plotView1.Location = new System.Drawing.Point(0, 0);
			plotView1.Name = "plotView1";
			plotView1.PanCursor = System.Windows.Forms.Cursors.Hand;
			plotView1.Size = new System.Drawing.Size(550, 450);
			plotView1.TabIndex = 0;
			plotView1.Text = "plotView1";
			plotView1.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
			plotView1.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
			plotView1.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Controls.Add(tabPage3);
			tabControl1.Dock = System.Windows.Forms.DockStyle.Right;
			tabControl1.Location = new System.Drawing.Point(550, 0);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new System.Drawing.Size(250, 450);
			tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			tabPage1.Location = new System.Drawing.Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(242, 422);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Входные данные";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			tabPage2.Location = new System.Drawing.Point(4, 24);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(242, 422);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Линейная";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			tabPage3.Location = new System.Drawing.Point(4, 24);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new System.Drawing.Size(242, 422);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Степенная";
			tabPage3.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			ClientSize = new System.Drawing.Size(800, 450);
			Controls.Add(plotView1);
			Controls.Add(tabControl1);
			Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			Text = "Form1";
			tabControl1.ResumeLayout(false);
			ResumeLayout(false);
		}

		private System.Windows.Forms.TabPage tabPage3;

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;

		#endregion

		private OxyPlot.WindowsForms.PlotView plotView1;
	}
}
