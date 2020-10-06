namespace ReportFromCode
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
      this.btnSimpleList = new System.Windows.Forms.Button();
      this.btnMasterDetail = new System.Windows.Forms.Button();
      this.btnGroup = new System.Windows.Forms.Button();
      this.btnNestedGroups = new System.Windows.Forms.Button();
      this.btnSubreport = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // btnSimpleList
      // 
      this.btnSimpleList.Location = new System.Drawing.Point(28, 32);
      this.btnSimpleList.Name = "btnSimpleList";
      this.btnSimpleList.Size = new System.Drawing.Size(236, 23);
      this.btnSimpleList.TabIndex = 0;
      this.btnSimpleList.Text = "Simple list from code";
      this.btnSimpleList.UseVisualStyleBackColor = true;
      this.btnSimpleList.Click += new System.EventHandler(this.btnSimpleList_Click);
      // 
      // btnMasterDetail
      // 
      this.btnMasterDetail.Location = new System.Drawing.Point(28, 64);
      this.btnMasterDetail.Name = "btnMasterDetail";
      this.btnMasterDetail.Size = new System.Drawing.Size(236, 23);
      this.btnMasterDetail.TabIndex = 0;
      this.btnMasterDetail.Text = "Master-Detail from code";
      this.btnMasterDetail.UseVisualStyleBackColor = true;
      this.btnMasterDetail.Click += new System.EventHandler(this.btnMasterDetail_Click);
      // 
      // btnGroup
      // 
      this.btnGroup.Location = new System.Drawing.Point(28, 96);
      this.btnGroup.Name = "btnGroup";
      this.btnGroup.Size = new System.Drawing.Size(236, 23);
      this.btnGroup.TabIndex = 0;
      this.btnGroup.Text = "Group from code";
      this.btnGroup.UseVisualStyleBackColor = true;
      this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
      // 
      // btnNestedGroups
      // 
      this.btnNestedGroups.Location = new System.Drawing.Point(28, 128);
      this.btnNestedGroups.Name = "btnNestedGroups";
      this.btnNestedGroups.Size = new System.Drawing.Size(236, 23);
      this.btnNestedGroups.TabIndex = 0;
      this.btnNestedGroups.Text = "Nested groups from code";
      this.btnNestedGroups.UseVisualStyleBackColor = true;
      this.btnNestedGroups.Click += new System.EventHandler(this.btnNestedGroups_Click);
      // 
      // btnSubreport
      // 
      this.btnSubreport.Location = new System.Drawing.Point(28, 160);
      this.btnSubreport.Name = "btnSubreport";
      this.btnSubreport.Size = new System.Drawing.Size(236, 23);
      this.btnSubreport.TabIndex = 0;
      this.btnSubreport.Text = "Subreport from code";
      this.btnSubreport.UseVisualStyleBackColor = true;
      this.btnSubreport.Click += new System.EventHandler(this.btnSubreport_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
      this.ClientSize = new System.Drawing.Size(292, 213);
      this.Controls.Add(this.btnSubreport);
      this.Controls.Add(this.btnNestedGroups);
      this.Controls.Add(this.btnGroup);
      this.Controls.Add(this.btnMasterDetail);
      this.Controls.Add(this.btnSimpleList);
      this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Report from code";
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button btnSimpleList;
    private System.Windows.Forms.Button btnMasterDetail;
    private System.Windows.Forms.Button btnGroup;
    private System.Windows.Forms.Button btnNestedGroups;
    private System.Windows.Forms.Button btnSubreport;
  }
}

