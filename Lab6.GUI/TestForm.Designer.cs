using System.ComponentModel;

namespace Lab6.GUI;

partial class TestForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        FunctionTB = new System.Windows.Forms.TextBox();
        FromNUD = new System.Windows.Forms.NumericUpDown();
        ToNUD = new System.Windows.Forms.NumericUpDown();
        StepNUD = new System.Windows.Forms.NumericUpDown();
        PointTB = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
        flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
        flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
        flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
        flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
        flowLayoutPanel6 = new System.Windows.Forms.FlowLayoutPanel();
        flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
        label6 = new System.Windows.Forms.Label();
        XStepTB = new System.Windows.Forms.TextBox();
        RunBTN = new System.Windows.Forms.Button();
        ConvergenceDGV = new System.Windows.Forms.DataGridView();
        tabControl1 = new System.Windows.Forms.TabControl();
        tabPage1 = new System.Windows.Forms.TabPage();
        tabPage2 = new System.Windows.Forms.TabPage();
        ErrorDGV = new System.Windows.Forms.DataGridView();
        ExactValueTB = new System.Windows.Forms.TextBox();
        label7 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)FromNUD).BeginInit();
        ((System.ComponentModel.ISupportInitialize)ToNUD).BeginInit();
        ((System.ComponentModel.ISupportInitialize)StepNUD).BeginInit();
        flowLayoutPanel1.SuspendLayout();
        flowLayoutPanel2.SuspendLayout();
        flowLayoutPanel3.SuspendLayout();
        flowLayoutPanel4.SuspendLayout();
        flowLayoutPanel5.SuspendLayout();
        flowLayoutPanel6.SuspendLayout();
        flowLayoutPanel7.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)ConvergenceDGV).BeginInit();
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        tabPage2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)ErrorDGV).BeginInit();
        SuspendLayout();
        // 
        // FunctionTB
        // 
        FunctionTB.Location = new System.Drawing.Point(3, 18);
        FunctionTB.Name = "FunctionTB";
        FunctionTB.Size = new System.Drawing.Size(213, 23);
        FunctionTB.TabIndex = 0;
        // 
        // FromNUD
        // 
        FromNUD.Location = new System.Drawing.Point(3, 21);
        FromNUD.Name = "FromNUD";
        FromNUD.Size = new System.Drawing.Size(59, 23);
        FromNUD.TabIndex = 1;
        // 
        // ToNUD
        // 
        ToNUD.Location = new System.Drawing.Point(3, 21);
        ToNUD.Name = "ToNUD";
        ToNUD.Size = new System.Drawing.Size(59, 23);
        ToNUD.TabIndex = 2;
        // 
        // StepNUD
        // 
        StepNUD.Location = new System.Drawing.Point(3, 21);
        StepNUD.Name = "StepNUD";
        StepNUD.Size = new System.Drawing.Size(59, 23);
        StepNUD.TabIndex = 3;
        // 
        // PointTB
        // 
        PointTB.Location = new System.Drawing.Point(3, 21);
        PointTB.Name = "PointTB";
        PointTB.Size = new System.Drawing.Size(78, 23);
        PointTB.TabIndex = 4;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Dock = System.Windows.Forms.DockStyle.Top;
        label1.Location = new System.Drawing.Point(3, 0);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(213, 15);
        label1.TabIndex = 5;
        label1.Text = "Функция:";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(3, 0);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(59, 18);
        label2.TabIndex = 6;
        label2.Text = "От:";
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(3, 0);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(59, 18);
        label3.TabIndex = 7;
        label3.Text = "До:";
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(3, 0);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(59, 18);
        label4.TabIndex = 8;
        label4.Text = "Шаг:";
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(3, 0);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(59, 18);
        label5.TabIndex = 9;
        label5.Text = "Точка:";
        // 
        // flowLayoutPanel1
        // 
        flowLayoutPanel1.AutoSize = true;
        flowLayoutPanel1.Controls.Add(flowLayoutPanel2);
        flowLayoutPanel1.Controls.Add(flowLayoutPanel3);
        flowLayoutPanel1.Controls.Add(flowLayoutPanel4);
        flowLayoutPanel1.Controls.Add(flowLayoutPanel5);
        flowLayoutPanel1.Controls.Add(flowLayoutPanel6);
        flowLayoutPanel1.Controls.Add(flowLayoutPanel7);
        flowLayoutPanel1.Controls.Add(RunBTN);
        flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
        flowLayoutPanel1.Location = new System.Drawing.Point(0, 391);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Size = new System.Drawing.Size(760, 59);
        flowLayoutPanel1.TabIndex = 10;
        // 
        // flowLayoutPanel2
        // 
        flowLayoutPanel2.AutoSize = true;
        flowLayoutPanel2.Controls.Add(label1);
        flowLayoutPanel2.Controls.Add(FunctionTB);
        flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
        flowLayoutPanel2.Name = "flowLayoutPanel2";
        flowLayoutPanel2.Size = new System.Drawing.Size(219, 44);
        flowLayoutPanel2.TabIndex = 11;
        // 
        // flowLayoutPanel3
        // 
        flowLayoutPanel3.AutoSize = true;
        flowLayoutPanel3.Controls.Add(label2);
        flowLayoutPanel3.Controls.Add(FromNUD);
        flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        flowLayoutPanel3.Location = new System.Drawing.Point(228, 3);
        flowLayoutPanel3.Name = "flowLayoutPanel3";
        flowLayoutPanel3.Size = new System.Drawing.Size(65, 47);
        flowLayoutPanel3.TabIndex = 12;
        // 
        // flowLayoutPanel4
        // 
        flowLayoutPanel4.AutoSize = true;
        flowLayoutPanel4.Controls.Add(label3);
        flowLayoutPanel4.Controls.Add(ToNUD);
        flowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        flowLayoutPanel4.Location = new System.Drawing.Point(299, 3);
        flowLayoutPanel4.Name = "flowLayoutPanel4";
        flowLayoutPanel4.Size = new System.Drawing.Size(65, 47);
        flowLayoutPanel4.TabIndex = 13;
        // 
        // flowLayoutPanel5
        // 
        flowLayoutPanel5.AutoSize = true;
        flowLayoutPanel5.Controls.Add(label4);
        flowLayoutPanel5.Controls.Add(StepNUD);
        flowLayoutPanel5.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        flowLayoutPanel5.Location = new System.Drawing.Point(370, 3);
        flowLayoutPanel5.Name = "flowLayoutPanel5";
        flowLayoutPanel5.Size = new System.Drawing.Size(65, 47);
        flowLayoutPanel5.TabIndex = 14;
        // 
        // flowLayoutPanel6
        // 
        flowLayoutPanel6.AutoSize = true;
        flowLayoutPanel6.Controls.Add(label5);
        flowLayoutPanel6.Controls.Add(PointTB);
        flowLayoutPanel6.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        flowLayoutPanel6.Location = new System.Drawing.Point(441, 3);
        flowLayoutPanel6.Name = "flowLayoutPanel6";
        flowLayoutPanel6.Size = new System.Drawing.Size(84, 47);
        flowLayoutPanel6.TabIndex = 15;
        // 
        // flowLayoutPanel7
        // 
        flowLayoutPanel7.AutoSize = true;
        flowLayoutPanel7.Controls.Add(label6);
        flowLayoutPanel7.Controls.Add(XStepTB);
        flowLayoutPanel7.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        flowLayoutPanel7.Location = new System.Drawing.Point(531, 3);
        flowLayoutPanel7.Name = "flowLayoutPanel7";
        flowLayoutPanel7.Size = new System.Drawing.Size(84, 47);
        flowLayoutPanel7.TabIndex = 17;
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(3, 0);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(78, 18);
        label6.TabIndex = 9;
        label6.Text = "Шаг для X:";
        // 
        // XStepTB
        // 
        XStepTB.Location = new System.Drawing.Point(3, 21);
        XStepTB.Name = "XStepTB";
        XStepTB.Size = new System.Drawing.Size(78, 23);
        XStepTB.TabIndex = 4;
        // 
        // RunBTN
        // 
        RunBTN.Dock = System.Windows.Forms.DockStyle.Fill;
        RunBTN.Location = new System.Drawing.Point(621, 3);
        RunBTN.Name = "RunBTN";
        RunBTN.Size = new System.Drawing.Size(124, 47);
        RunBTN.TabIndex = 16;
        RunBTN.Text = "Запустить";
        RunBTN.UseVisualStyleBackColor = true;
        // 
        // ConvergenceDGV
        // 
        ConvergenceDGV.AllowUserToAddRows = false;
        ConvergenceDGV.AllowUserToDeleteRows = false;
        ConvergenceDGV.AllowUserToResizeRows = false;
        ConvergenceDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        ConvergenceDGV.BackgroundColor = System.Drawing.SystemColors.Control;
        ConvergenceDGV.Dock = System.Windows.Forms.DockStyle.Fill;
        ConvergenceDGV.Location = new System.Drawing.Point(3, 3);
        ConvergenceDGV.Name = "ConvergenceDGV";
        ConvergenceDGV.ReadOnly = true;
        ConvergenceDGV.RowHeadersVisible = false;
        ConvergenceDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        ConvergenceDGV.Size = new System.Drawing.Size(746, 326);
        ConvergenceDGV.TabIndex = 11;
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabPage1);
        tabControl1.Controls.Add(tabPage2);
        tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        tabControl1.Location = new System.Drawing.Point(0, 0);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new System.Drawing.Size(760, 360);
        tabControl1.TabIndex = 12;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(ConvergenceDGV);
        tabPage1.Location = new System.Drawing.Point(4, 24);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new System.Windows.Forms.Padding(3);
        tabPage1.Size = new System.Drawing.Size(752, 332);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Сходимость";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(ErrorDGV);
        tabPage2.Location = new System.Drawing.Point(4, 24);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new System.Windows.Forms.Padding(3);
        tabPage2.Size = new System.Drawing.Size(752, 363);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Погрешность";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // ErrorDGV
        // 
        ErrorDGV.AllowUserToAddRows = false;
        ErrorDGV.AllowUserToDeleteRows = false;
        ErrorDGV.AllowUserToResizeRows = false;
        ErrorDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        ErrorDGV.BackgroundColor = System.Drawing.SystemColors.Control;
        ErrorDGV.Dock = System.Windows.Forms.DockStyle.Fill;
        ErrorDGV.Location = new System.Drawing.Point(3, 3);
        ErrorDGV.Name = "ErrorDGV";
        ErrorDGV.ReadOnly = true;
        ErrorDGV.RowHeadersVisible = false;
        ErrorDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        ErrorDGV.Size = new System.Drawing.Size(746, 357);
        ErrorDGV.TabIndex = 12;
        // 
        // ExactValueTB
        // 
        ExactValueTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
        ExactValueTB.Dock = System.Windows.Forms.DockStyle.Bottom;
        ExactValueTB.Location = new System.Drawing.Point(0, 375);
        ExactValueTB.Name = "ExactValueTB";
        ExactValueTB.ReadOnly = true;
        ExactValueTB.Size = new System.Drawing.Size(760, 16);
        ExactValueTB.TabIndex = 13;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Dock = System.Windows.Forms.DockStyle.Bottom;
        label7.Location = new System.Drawing.Point(0, 360);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(104, 15);
        label7.TabIndex = 14;
        label7.Text = "Точное значение:";
        // 
        // TestForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(760, 450);
        Controls.Add(tabControl1);
        Controls.Add(label7);
        Controls.Add(ExactValueTB);
        Controls.Add(flowLayoutPanel1);
        MinimumSize = new System.Drawing.Size(331, 489);
        Text = "TestForm";
        ((System.ComponentModel.ISupportInitialize)FromNUD).EndInit();
        ((System.ComponentModel.ISupportInitialize)ToNUD).EndInit();
        ((System.ComponentModel.ISupportInitialize)StepNUD).EndInit();
        flowLayoutPanel1.ResumeLayout(false);
        flowLayoutPanel1.PerformLayout();
        flowLayoutPanel2.ResumeLayout(false);
        flowLayoutPanel2.PerformLayout();
        flowLayoutPanel3.ResumeLayout(false);
        flowLayoutPanel4.ResumeLayout(false);
        flowLayoutPanel5.ResumeLayout(false);
        flowLayoutPanel6.ResumeLayout(false);
        flowLayoutPanel6.PerformLayout();
        flowLayoutPanel7.ResumeLayout(false);
        flowLayoutPanel7.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)ConvergenceDGV).EndInit();
        tabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        tabPage2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)ErrorDGV).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.TextBox ExactValueTB;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox XStepTB;

    private System.Windows.Forms.DataGridView ErrorDGV;

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;

    private System.Windows.Forms.DataGridView ConvergenceDGV;

    private System.Windows.Forms.Button RunBTN;

    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel6;

    private System.Windows.Forms.TextBox PointTB;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;

    private System.Windows.Forms.TextBox FunctionTB;
    private System.Windows.Forms.NumericUpDown FromNUD;
    private System.Windows.Forms.NumericUpDown ToNUD;
    private System.Windows.Forms.NumericUpDown StepNUD;

    #endregion
}