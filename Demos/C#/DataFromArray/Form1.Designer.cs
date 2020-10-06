namespace DataFromArray
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
      this.btnRunExisting = new System.Windows.Forms.Button();
      this.btnCreateNew = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnRunExisting
      // 
      this.btnRunExisting.Location = new System.Drawing.Point(76, 140);
      this.btnRunExisting.Name = "btnRunExisting";
      this.btnRunExisting.Size = new System.Drawing.Size(140, 23);
      this.btnRunExisting.TabIndex = 0;
      this.btnRunExisting.Text = "Run Existing Report";
      this.btnRunExisting.UseVisualStyleBackColor = true;
      this.btnRunExisting.Click += new System.EventHandler(this.btnRunExisting_Click);
      // 
      // btnCreateNew
      // 
      this.btnCreateNew.Location = new System.Drawing.Point(76, 104);
      this.btnCreateNew.Name = "btnCreateNew";
      this.btnCreateNew.Size = new System.Drawing.Size(140, 23);
      this.btnCreateNew.TabIndex = 1;
      this.btnCreateNew.Text = "Create New Report";
      this.btnCreateNew.UseVisualStyleBackColor = true;
      this.btnCreateNew.Click += new System.EventHandler(this.btnCreateNew_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 236);
      this.Controls.Add(this.btnCreateNew);
      this.Controls.Add(this.btnRunExisting);
      this.Name = "Form1";
      this.Text = "Data From Array";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnRunExisting;
    private System.Windows.Forms.Button btnCreateNew;
  }
}

