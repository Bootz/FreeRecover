
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
partial class Form1 : System.Windows.Forms.Form
{

    // Form overrides dispose to clean up the component list.
    [System.Diagnostics.DebuggerNonUserCode()]
    protected override void Dispose(bool disposing)
    {
        try
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
        }
        finally
        {
            base.Dispose(disposing);
        }
    }

    // Required by the Windows Form Designer

    private System.ComponentModel.IContainer components;
    // NOTE: The following procedure is required by the Windows Form Designer
    // It can be modified using the Windows Form Designer.  
    // Do not modify it using the code editor.
    [System.Diagnostics.DebuggerStepThrough()]
    private void InitializeComponent()
    {
            this.ListView1 = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.Button2 = new System.Windows.Forms.Button();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.ComboBox1 = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.CheckBox1 = new System.Windows.Forms.CheckBox();
            this.CheckBox2 = new System.Windows.Forms.CheckBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.Button3 = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ListView2 = new System.Windows.Forms.ListView();
            this.ColumnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.Panel1.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListView1
            // 
            this.ListView1.CheckBoxes = true;
            this.ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader10});
            this.ListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView1.FullRowSelect = true;
            this.ListView1.GridLines = true;
            this.ListView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListView1.HideSelection = false;
            this.ListView1.Location = new System.Drawing.Point(0, 31);
            this.ListView1.Margin = new System.Windows.Forms.Padding(4);
            this.ListView1.Name = "ListView1";
            this.ListView1.Size = new System.Drawing.Size(1033, 346);
            this.ListView1.TabIndex = 3;
            this.ListView1.UseCompatibleStateImageBehavior = false;
            this.ListView1.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "File Name";
            this.ColumnHeader1.Width = 168;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "File Path";
            this.ColumnHeader2.Width = 324;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Size";
            this.ColumnHeader3.Width = 107;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "MFT Sector Address";
            this.ColumnHeader4.Width = 81;
            // 
            // ColumnHeader10
            // 
            this.ColumnHeader10.Text = "File Integrity (Estimated)";
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ProgressBar1.Location = new System.Drawing.Point(0, 229);
            this.ProgressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(933, 28);
            this.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar1.TabIndex = 4;
            // 
            // Button2
            // 
            this.Button2.Dock = System.Windows.Forms.DockStyle.Right;
            this.Button2.Location = new System.Drawing.Point(933, 0);
            this.Button2.Margin = new System.Windows.Forms.Padding(4);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(100, 257);
            this.Button2.TabIndex = 5;
            this.Button2.Text = "Recover Files";
            this.Button2.UseVisualStyleBackColor = true;
            // 
            // TextBox1
            // 
            this.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox1.Location = new System.Drawing.Point(0, 28);
            this.TextBox1.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox1.Multiline = true;
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.ReadOnly = true;
            this.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBox1.Size = new System.Drawing.Size(933, 201);
            this.TextBox1.TabIndex = 6;
            this.TextBox1.Visible = false;
            this.TextBox1.WordWrap = false;
            // 
            // PictureBox1
            // 
            this.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PictureBox1.Location = new System.Drawing.Point(0, 28);
            this.PictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(933, 201);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 7;
            this.PictureBox1.TabStop = false;
            this.PictureBox1.Visible = false;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.ComboBox1);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.Button1);
            this.Panel1.Controls.Add(this.CheckBox1);
            this.Panel1.Controls.Add(this.CheckBox2);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel1.Location = new System.Drawing.Point(0, 0);
            this.Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1033, 31);
            this.Panel1.TabIndex = 8;
            // 
            // ComboBox1
            // 
            this.ComboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox1.FormattingEnabled = true;
            this.ComboBox1.ItemHeight = 16;
            this.ComboBox1.Location = new System.Drawing.Point(58, 0);
            this.ComboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.ComboBox1.Name = "ComboBox1";
            this.ComboBox1.Size = new System.Drawing.Size(596, 24);
            this.ComboBox1.TabIndex = 3;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(58, 24);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Drive:";
            // 
            // Button1
            // 
            this.Button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.Button1.Location = new System.Drawing.Point(654, 0);
            this.Button1.Margin = new System.Windows.Forms.Padding(4);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(100, 31);
            this.Button1.TabIndex = 5;
            this.Button1.Text = "SEARCH";
            this.Button1.UseVisualStyleBackColor = true;
            // 
            // CheckBox1
            // 
            this.CheckBox1.AutoSize = true;
            this.CheckBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.CheckBox1.Location = new System.Drawing.Point(754, 0);
            this.CheckBox1.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBox1.Name = "CheckBox1";
            this.CheckBox1.Size = new System.Drawing.Size(119, 31);
            this.CheckBox1.TabIndex = 6;
            this.CheckBox1.Text = "Get File Paths";
            this.CheckBox1.UseVisualStyleBackColor = true;
            // 
            // CheckBox2
            // 
            this.CheckBox2.AutoSize = true;
            this.CheckBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.CheckBox2.Location = new System.Drawing.Point(873, 0);
            this.CheckBox2.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBox2.Name = "CheckBox2";
            this.CheckBox2.Size = new System.Drawing.Size(160, 31);
            this.CheckBox2.TabIndex = 12;
            this.CheckBox2.Text = "Check File Integrities";
            this.CheckBox2.UseVisualStyleBackColor = true;
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.PictureBox1);
            this.Panel2.Controls.Add(this.TextBox1);
            this.Panel2.Controls.Add(this.Panel3);
            this.Panel2.Controls.Add(this.ProgressBar1);
            this.Panel2.Controls.Add(this.Button2);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Panel2.Location = new System.Drawing.Point(0, 377);
            this.Panel2.Margin = new System.Windows.Forms.Padding(4);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1033, 257);
            this.Panel2.TabIndex = 9;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.TextBox2);
            this.Panel3.Controls.Add(this.Button3);
            this.Panel3.Controls.Add(this.Label2);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Margin = new System.Windows.Forms.Padding(4);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(933, 28);
            this.Panel3.TabIndex = 9;
            // 
            // TextBox2
            // 
            this.TextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextBox2.Location = new System.Drawing.Point(128, 0);
            this.TextBox2.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(737, 22);
            this.TextBox2.TabIndex = 8;
            // 
            // Button3
            // 
            this.Button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.Button3.Location = new System.Drawing.Point(865, 0);
            this.Button3.Margin = new System.Windows.Forms.Padding(4);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(68, 28);
            this.Button3.TabIndex = 10;
            this.Button3.Text = "Search";
            this.Button3.UseVisualStyleBackColor = true;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(0, 0);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(128, 24);
            this.Label2.TabIndex = 9;
            this.Label2.Text = "Search String:";
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel1});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 634);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(1033, 22);
            this.StatusStrip1.TabIndex = 10;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // FolderBrowserDialog1
            // 
            this.FolderBrowserDialog1.Description = "Choose A Folder To Restore Items To";
            // 
            // ListView2
            // 
            this.ListView2.CheckBoxes = true;
            this.ListView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader5,
            this.ColumnHeader6,
            this.ColumnHeader7,
            this.ColumnHeader8,
            this.ColumnHeader9});
            this.ListView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView2.FullRowSelect = true;
            this.ListView2.GridLines = true;
            this.ListView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListView2.HideSelection = false;
            this.ListView2.Location = new System.Drawing.Point(0, 31);
            this.ListView2.Margin = new System.Windows.Forms.Padding(4);
            this.ListView2.Name = "ListView2";
            this.ListView2.Size = new System.Drawing.Size(1033, 346);
            this.ListView2.TabIndex = 11;
            this.ListView2.UseCompatibleStateImageBehavior = false;
            this.ListView2.View = System.Windows.Forms.View.Details;
            this.ListView2.Visible = false;
            // 
            // ColumnHeader5
            // 
            this.ColumnHeader5.Text = "File Name";
            this.ColumnHeader5.Width = 168;
            // 
            // ColumnHeader6
            // 
            this.ColumnHeader6.Text = "File Path";
            this.ColumnHeader6.Width = 323;
            // 
            // ColumnHeader7
            // 
            this.ColumnHeader7.Text = "Size";
            this.ColumnHeader7.Width = 107;
            // 
            // ColumnHeader8
            // 
            this.ColumnHeader8.Text = "MFT Sector Address";
            this.ColumnHeader8.Width = 81;
            // 
            // ColumnHeader9
            // 
            this.ColumnHeader9.Text = "File Integrity";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 656);
            this.Controls.Add(this.ListView1);
            this.Controls.Add(this.ListView2);
            this.Controls.Add(this.Panel2);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.StatusStrip1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "FreeRecover";
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    internal System.Windows.Forms.ListView ListView1;
    internal System.Windows.Forms.ProgressBar ProgressBar1;
    internal System.Windows.Forms.Button Button2;
    internal System.Windows.Forms.TextBox TextBox1;
    internal System.Windows.Forms.PictureBox PictureBox1;
    internal System.Windows.Forms.ColumnHeader ColumnHeader1;
    internal System.Windows.Forms.ColumnHeader ColumnHeader2;
    internal System.Windows.Forms.ColumnHeader ColumnHeader3;
    internal System.Windows.Forms.ColumnHeader ColumnHeader4;
    internal System.Windows.Forms.SaveFileDialog SaveFileDialog1;
    internal System.Windows.Forms.Panel Panel1;
    internal System.Windows.Forms.Button Button1;
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.ComboBox ComboBox1;
    internal System.Windows.Forms.Panel Panel2;
    internal System.Windows.Forms.StatusStrip StatusStrip1;
    internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
    internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
    internal System.Windows.Forms.Panel Panel3;
    internal System.Windows.Forms.TextBox TextBox2;
    internal System.Windows.Forms.Button Button3;
    internal System.Windows.Forms.Label Label2;
    internal System.Windows.Forms.ListView ListView2;
    internal System.Windows.Forms.ColumnHeader ColumnHeader5;
    internal System.Windows.Forms.ColumnHeader ColumnHeader6;
    internal System.Windows.Forms.ColumnHeader ColumnHeader7;
    internal System.Windows.Forms.ColumnHeader ColumnHeader8;
    internal System.Windows.Forms.CheckBox CheckBox1;
    internal System.Windows.Forms.ColumnHeader ColumnHeader10;
    internal System.Windows.Forms.ColumnHeader ColumnHeader9;

    internal System.Windows.Forms.CheckBox CheckBox2;
}
