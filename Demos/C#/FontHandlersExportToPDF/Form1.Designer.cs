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
            this.button1 = new System.Windows.Forms.Button();
            this.WYSIWYG = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExportWithDialog
            // 
            this.btnExportWithDialog.Location = new System.Drawing.Point(24, 50);
            this.btnExportWithDialog.Name = "btnExportWithDialog";
            this.btnExportWithDialog.Size = new System.Drawing.Size(172, 23);
            this.btnExportWithDialog.TabIndex = 0;
            this.btnExportWithDialog.Text = "Run designer...";
            this.btnExportWithDialog.UseVisualStyleBackColor = true;
            this.btnExportWithDialog.Click += new System.EventHandler(this.btnExportWithDialog_Click);
            // 
            // btnSilentExport
            // 
            this.btnSilentExport.Location = new System.Drawing.Point(36, 123);
            this.btnSilentExport.Name = "btnSilentExport";
            this.btnSilentExport.Size = new System.Drawing.Size(172, 23);
            this.btnSilentExport.TabIndex = 0;
            this.btnSilentExport.Text = "Export list of fonts to PDF";
            this.btnSilentExport.UseVisualStyleBackColor = true;
            this.btnSilentExport.Click += new System.EventHandler(this.btnSilentExport_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Enumerate fonts...\'";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.EnumerateFonts_Click);
            // 
            // WYSIWYG
            // 
            this.WYSIWYG.AutoSize = true;
            this.WYSIWYG.Location = new System.Drawing.Point(24, 23);
            this.WYSIWYG.Name = "WYSIWYG";
            this.WYSIWYG.Size = new System.Drawing.Size(130, 21);
            this.WYSIWYG.TabIndex = 2;
            this.WYSIWYG.Text = "WYSIWYG fonts";
            this.WYSIWYG.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.WYSIWYG);
            this.groupBox1.Controls.Add(this.btnExportWithDialog);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 88);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create font list report";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 193);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSilentExport);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "font.list";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnExportWithDialog;
    private System.Windows.Forms.Button btnSilentExport;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox WYSIWYG;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

