
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.ComponentModel;

[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
partial class Form2 : System.Windows.Forms.Form
{

	// Form overrides dispose to clean up the component list.
	[System.Diagnostics.DebuggerNonUserCode()]
	protected override void Dispose(bool disposing)
	{
		try {
			if (disposing && Components != null) {
				Components.Dispose();
			}
		} finally {
			base.Dispose(disposing);
		}
	}

	// Required by the Windows Form Designer

	private System.ComponentModel.IContainer components;

    public IContainer Components { get => components; set => components = value; }

    // NOTE: The following procedure is required by the Windows Form Designer
    // It can be modified using the Windows Form Designer.  
    // Do not modify it using the code editor.
    [System.Diagnostics.DebuggerStepThrough()]
	private void InitializeComponent()
	{
		this.SuspendLayout();
		// 
		// Form2
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
		this.ClientSize = new System.Drawing.Size(284, 262);
		this.MinimizeBox = false;
		this.Name = "Form2";
		this.ShowIcon = false;
		this.Text = "Picture View";
		this.ResumeLayout(false);

	}
}
