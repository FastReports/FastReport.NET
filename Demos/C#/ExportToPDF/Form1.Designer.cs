namespace ExportToPDF
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
      this.btnExportWithDialog = new System.Windows.Forms.Button();
      this.btnSilentExport = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnExportWithDialog
      // 
      this.btnExportWithDialog.Location = new System.Drawing.Point(44, 148);
      this.btnExportWithDialog.Name = "btnExportWithDialog";
      this.btnExportWithDialog.Size = new System.Drawing.Size(208, 23);
      this.btnExportWithDialog.TabIndex = 0;
      this.btnExportWithDialog.Text = "Export to PDF with dialog";
      this.btnExportWithDialog.UseVisualStyleBackColor = true;
      this.btnExportWithDialog.Click += new System.EventHandler(this.btnExportWithDialog_Click);
      // 
      // btnSilentExport
      // 
      this.btnSilentExport.Location = new System.Drawing.Point(44, 180);
      this.btnSilentExport.Name = "btnSilentExport";
      this.btnSilentExport.Size = new System.Drawing.Size(208, 23);
      this.btnSilentExport.TabIndex = 0;
      this.btnSilentExport.Text = "Silent export";
      this.btnSilentExport.UseVisualStyleBackColor = true;
      this.btnSilentExport.Click += new System.EventHandler(this.btnSilentExport_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Controls.Add(this.btnSilentExport);
      this.Controls.Add(this.btnExportWithDialog);
      this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Name = "Form1";
      this.Text = "Form1";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnExportWithDialog;
    private System.Windows.Forms.Button btnSilentExport;
  }
}

