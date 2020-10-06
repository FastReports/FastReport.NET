namespace CustomPreview
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
      this.components = new System.ComponentModel.Container();
      this.preview1 = new FastReport.Preview.PreviewControl();
      this.btnPrint = new System.Windows.Forms.Button();
      this.btnExport = new System.Windows.Forms.Button();
      this.btnFirst = new System.Windows.Forms.Button();
      this.btnPrior = new System.Windows.Forms.Button();
      this.btnNext = new System.Windows.Forms.Button();
      this.btnLast = new System.Windows.Forms.Button();
      this.tbPageNo = new System.Windows.Forms.TextBox();
      this.btnZoomOut = new System.Windows.Forms.Button();
      this.btnZoomIn = new System.Windows.Forms.Button();
      this.lbReports = new System.Windows.Forms.ListBox();
      this.exportMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.SuspendLayout();
      // 
      // preview1
      // 
      this.preview1.BackColor = System.Drawing.SystemColors.AppWorkspace;
      this.preview1.Font = new System.Drawing.Font("Tahoma", 8F);
      this.preview1.Location = new System.Drawing.Point(156, 44);
      this.preview1.Name = "preview1";
      this.preview1.Size = new System.Drawing.Size(476, 480);
      this.preview1.StatusbarVisible = false;
      this.preview1.TabIndex = 0;
      this.preview1.ToolbarVisible = false;
      this.preview1.UIStyle = FastReport.Utils.UIStyle.VisualStudio2005;
      this.preview1.PageChanged += new System.EventHandler(this.preview1_PageChanged);
      // 
      // btnPrint
      // 
      this.btnPrint.Location = new System.Drawing.Point(156, 12);
      this.btnPrint.Name = "btnPrint";
      this.btnPrint.Size = new System.Drawing.Size(56, 23);
      this.btnPrint.TabIndex = 2;
      this.btnPrint.Text = "Print";
      this.btnPrint.UseVisualStyleBackColor = true;
      this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
      // 
      // btnExport
      // 
      this.btnExport.Location = new System.Drawing.Point(216, 12);
      this.btnExport.Name = "btnExport";
      this.btnExport.Size = new System.Drawing.Size(56, 23);
      this.btnExport.TabIndex = 2;
      this.btnExport.Text = "Export";
      this.btnExport.UseVisualStyleBackColor = true;
      this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
      // 
      // btnFirst
      // 
      this.btnFirst.Location = new System.Drawing.Point(452, 12);
      this.btnFirst.Name = "btnFirst";
      this.btnFirst.Size = new System.Drawing.Size(32, 23);
      this.btnFirst.TabIndex = 2;
      this.btnFirst.Text = "<<";
      this.btnFirst.UseVisualStyleBackColor = true;
      this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
      // 
      // btnPrior
      // 
      this.btnPrior.Location = new System.Drawing.Point(488, 12);
      this.btnPrior.Name = "btnPrior";
      this.btnPrior.Size = new System.Drawing.Size(32, 23);
      this.btnPrior.TabIndex = 2;
      this.btnPrior.Text = "<";
      this.btnPrior.UseVisualStyleBackColor = true;
      this.btnPrior.Click += new System.EventHandler(this.btnPrior_Click);
      // 
      // btnNext
      // 
      this.btnNext.Location = new System.Drawing.Point(564, 12);
      this.btnNext.Name = "btnNext";
      this.btnNext.Size = new System.Drawing.Size(32, 23);
      this.btnNext.TabIndex = 2;
      this.btnNext.Text = ">";
      this.btnNext.UseVisualStyleBackColor = true;
      this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
      // 
      // btnLast
      // 
      this.btnLast.Location = new System.Drawing.Point(600, 12);
      this.btnLast.Name = "btnLast";
      this.btnLast.Size = new System.Drawing.Size(32, 23);
      this.btnLast.TabIndex = 2;
      this.btnLast.Text = ">>";
      this.btnLast.UseVisualStyleBackColor = true;
      this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
      // 
      // tbPageNo
      // 
      this.tbPageNo.Location = new System.Drawing.Point(524, 12);
      this.tbPageNo.Name = "tbPageNo";
      this.tbPageNo.Size = new System.Drawing.Size(36, 21);
      this.tbPageNo.TabIndex = 3;
      this.tbPageNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbPageNo_KeyDown);
      // 
      // btnZoomOut
      // 
      this.btnZoomOut.Location = new System.Drawing.Point(332, 12);
      this.btnZoomOut.Name = "btnZoomOut";
      this.btnZoomOut.Size = new System.Drawing.Size(32, 23);
      this.btnZoomOut.TabIndex = 2;
      this.btnZoomOut.Text = "-";
      this.btnZoomOut.UseVisualStyleBackColor = true;
      this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
      // 
      // btnZoomIn
      // 
      this.btnZoomIn.Location = new System.Drawing.Point(368, 12);
      this.btnZoomIn.Name = "btnZoomIn";
      this.btnZoomIn.Size = new System.Drawing.Size(32, 23);
      this.btnZoomIn.TabIndex = 2;
      this.btnZoomIn.Text = "+";
      this.btnZoomIn.UseVisualStyleBackColor = true;
      this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
      // 
      // lbReports
      // 
      this.lbReports.FormattingEnabled = true;
      this.lbReports.Location = new System.Drawing.Point(12, 12);
      this.lbReports.Name = "lbReports";
      this.lbReports.Size = new System.Drawing.Size(132, 511);
      this.lbReports.TabIndex = 4;
      this.lbReports.SelectedIndexChanged += new System.EventHandler(this.lbReports_SelectedIndexChanged);
      // 
      // exportMenu
      // 
      this.exportMenu.Name = "exportMenu";
      this.exportMenu.Size = new System.Drawing.Size(61, 4);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(643, 537);
      this.Controls.Add(this.lbReports);
      this.Controls.Add(this.tbPageNo);
      this.Controls.Add(this.btnLast);
      this.Controls.Add(this.btnNext);
      this.Controls.Add(this.btnPrior);
      this.Controls.Add(this.btnFirst);
      this.Controls.Add(this.btnZoomIn);
      this.Controls.Add(this.btnZoomOut);
      this.Controls.Add(this.btnExport);
      this.Controls.Add(this.btnPrint);
      this.Controls.Add(this.preview1);
      this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Custom Preview";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private FastReport.Preview.PreviewControl preview1;
    private System.Windows.Forms.Button btnPrint;
    private System.Windows.Forms.Button btnExport;
    private System.Windows.Forms.Button btnFirst;
    private System.Windows.Forms.Button btnPrior;
    private System.Windows.Forms.Button btnNext;
    private System.Windows.Forms.Button btnLast;
    private System.Windows.Forms.TextBox tbPageNo;
    private System.Windows.Forms.Button btnZoomOut;
    private System.Windows.Forms.Button btnZoomIn;
    private System.Windows.Forms.ListBox lbReports;
    private System.Windows.Forms.ContextMenuStrip exportMenu;
  }
}

