namespace CustomOpenSaveDialogs
{
  partial class Form1
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
      this.btnDesign = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnDesign
      // 
      this.btnDesign.Location = new System.Drawing.Point(76, 212);
      this.btnDesign.Name = "btnDesign";
      this.btnDesign.Size = new System.Drawing.Size(144, 23);
      this.btnDesign.TabIndex = 0;
      this.btnDesign.Text = "Run the Designer";
      this.btnDesign.UseVisualStyleBackColor = true;
      this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Controls.Add(this.btnDesign);
      this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Name = "Form1";
      this.Text = "Custom Open/Save dialogs";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnDesign;
  }
}

