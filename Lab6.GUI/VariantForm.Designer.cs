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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			LeftPanel = new HoverablePanel();
			textBox1 = new TextBox();
			LeftPanel.SuspendLayout();
			SuspendLayout();
			// 
			// LeftPanel
			// 
			LeftPanel.BackColor = SystemColors.ControlDark;
			LeftPanel.Controls.Add(textBox1);
			LeftPanel.Dock = DockStyle.Left;
			LeftPanel.Location = new Point(0, 0);
			LeftPanel.MaximumSize = new Size(200, 0);
			LeftPanel.MinimumSize = new Size(32, 0);
			LeftPanel.Name = "LeftPanel";
			LeftPanel.Size = new Size(200, 450);
			LeftPanel.TabIndex = 0;
			// 
			// textBox1
			// 
			textBox1.Location = new Point(12, 39);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(125, 27);
			textBox1.TabIndex = 0;
			// 
			// VariantForm
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(LeftPanel);
			Name = "VariantForm";
			Text = "Form1";
			LeftPanel.ResumeLayout(false);
			LeftPanel.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private HoverablePanel LeftPanel;
		private TextBox textBox1;
	}
}
