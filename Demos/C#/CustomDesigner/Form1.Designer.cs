namespace CustomDesigner
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.designerControl1 = new FastReport.Design.StandardDesigner.DesignerControl();
      this.btnNew = new System.Windows.Forms.Button();
      this.btnOpen = new System.Windows.Forms.Button();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnUndo = new System.Windows.Forms.Button();
      this.btnRedo = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.designerControl1)).BeginInit();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // designerControl1
      // 
      this.designerControl1.AskSave = true;
      this.designerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.designerControl1.LayoutState = resources.GetString("designerControl1.LayoutState");
      this.designerControl1.Location = new System.Drawing.Point(0, 40);
      this.designerControl1.Name = "designerControl1";
      this.designerControl1.ShowMainMenu = false;
      this.designerControl1.Size = new System.Drawing.Size(685, 555);
      this.designerControl1.TabIndex = 0;
      this.designerControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black;
      this.designerControl1.UIStateChanged += new System.EventHandler(this.designerControl1_UIStateChanged);
      // 
      // btnNew
      // 
      this.btnNew.Location = new System.Drawing.Point(8, 8);
      this.btnNew.Name = "btnNew";
      this.btnNew.Size = new System.Drawing.Size(75, 23);
      this.btnNew.TabIndex = 1;
      this.btnNew.Text = "New report";
      this.btnNew.UseVisualStyleBackColor = true;
      this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
      // 
      // btnOpen
      // 
      this.btnOpen.Location = new System.Drawing.Point(88, 8);
      this.btnOpen.Name = "btnOpen";
      this.btnOpen.Size = new System.Drawing.Size(75, 23);
      this.btnOpen.TabIndex = 2;
      this.btnOpen.Text = "Open";
      this.btnOpen.UseVisualStyleBackColor = true;
      this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
      // 
      // btnSave
      // 
      this.btnSave.Location = new System.Drawing.Point(168, 8);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(75, 23);
      this.btnSave.TabIndex = 2;
      this.btnSave.Text = "Save";
      this.btnSave.UseVisualStyleBackColor = true;
      this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
      // 
      // btnUndo
      // 
      this.btnUndo.Location = new System.Drawing.Point(248, 8);
      this.btnUndo.Name = "btnUndo";
      this.btnUndo.Size = new System.Drawing.Size(75, 23);
      this.btnUndo.TabIndex = 2;
      this.btnUndo.Text = "Undo";
      this.btnUndo.UseVisualStyleBackColor = true;
      this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
      // 
      // btnRedo
      // 
      this.btnRedo.Location = new System.Drawing.Point(328, 8);
      this.btnRedo.Name = "btnRedo";
      this.btnRedo.Size = new System.Drawing.Size(75, 23);
      this.btnRedo.TabIndex = 2;
      this.btnRedo.Text = "Redo";
      this.btnRedo.UseVisualStyleBackColor = true;
      this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.btnNew);
      this.panel1.Controls.Add(this.btnRedo);
      this.panel1.Controls.Add(this.btnOpen);
      this.panel1.Controls.Add(this.btnUndo);
      this.panel1.Controls.Add(this.btnSave);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(685, 40);
      this.panel1.TabIndex = 3;
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(685, 595);
      this.Controls.Add(this.designerControl1);
      this.Controls.Add(this.panel1);
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      ((System.ComponentModel.ISupportInitialize)(this.designerControl1)).EndInit();
      this.panel1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private FastReport.Design.StandardDesigner.DesignerControl designerControl1;
    private System.Windows.Forms.Button btnNew;
    private System.Windows.Forms.Button btnOpen;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnUndo;
    private System.Windows.Forms.Button btnRedo;
    private System.Windows.Forms.Panel panel1;
  }
}

