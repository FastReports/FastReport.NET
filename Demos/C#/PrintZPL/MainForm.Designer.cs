namespace PrintZPL
{
    partial class MainForm
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.cbPrinters = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbPrintAsBitmap = new System.Windows.Forms.CheckBox();
            this.tbPrinterFont = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudFontScale = new System.Windows.Forms.NumericUpDown();
            this.tbPageInit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPrinterFinish = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbCodePage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPrinterInit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbDensity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.btnDesignReport = new System.Windows.Forms.Button();
            this.lblReportName = new System.Windows.Forms.Label();
            this.btnSelectReport = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnLoad = new System.Windows.Forms.Button();
            this.textEditor = new System.Windows.Forms.TextBox();
            this.btnShowZPL = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontScale)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(519, 485);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 38);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // cbPrinters
            // 
            this.cbPrinters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrinters.FormattingEnabled = true;
            this.cbPrinters.Location = new System.Drawing.Point(88, 493);
            this.cbPrinters.Name = "cbPrinters";
            this.cbPrinters.Size = new System.Drawing.Size(319, 21);
            this.cbPrinters.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 496);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Printer";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(586, 455);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnShowReport);
            this.tabPage1.Controls.Add(this.btnDesignReport);
            this.tabPage1.Controls.Add(this.lblReportName);
            this.tabPage1.Controls.Add(this.btnSelectReport);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(578, 429);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Reports";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.cbPrintAsBitmap);
            this.groupBox1.Controls.Add(this.tbPrinterFont);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nudFontScale);
            this.groupBox1.Controls.Add(this.tbPageInit);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbPrinterFinish);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbCodePage);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbPrinterInit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbDensity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(36, 133);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 256);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zebra Printer Settings";
            // 
            // cbPrintAsBitmap
            // 
            this.cbPrintAsBitmap.AutoSize = true;
            this.cbPrintAsBitmap.Checked = true;
            this.cbPrintAsBitmap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPrintAsBitmap.Location = new System.Drawing.Point(161, 228);
            this.cbPrintAsBitmap.Name = "cbPrintAsBitmap";
            this.cbPrintAsBitmap.Size = new System.Drawing.Size(97, 17);
            this.cbPrintAsBitmap.TabIndex = 14;
            this.cbPrintAsBitmap.Text = "Print As Bitmap";
            this.cbPrintAsBitmap.UseVisualStyleBackColor = true;
            // 
            // tbPrinterFont
            // 
            this.tbPrinterFont.Location = new System.Drawing.Point(161, 201);
            this.tbPrinterFont.Name = "tbPrinterFont";
            this.tbPrinterFont.Size = new System.Drawing.Size(316, 20);
            this.tbPrinterFont.TabIndex = 13;
            this.tbPrinterFont.Text = "A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Font";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Font Scale";
            // 
            // nudFontScale
            // 
            this.nudFontScale.DecimalPlaces = 2;
            this.nudFontScale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudFontScale.Location = new System.Drawing.Point(161, 175);
            this.nudFontScale.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudFontScale.Name = "nudFontScale";
            this.nudFontScale.Size = new System.Drawing.Size(120, 20);
            this.nudFontScale.TabIndex = 10;
            this.nudFontScale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tbPageInit
            // 
            this.tbPageInit.Location = new System.Drawing.Point(161, 149);
            this.tbPageInit.Name = "tbPageInit";
            this.tbPageInit.Size = new System.Drawing.Size(316, 20);
            this.tbPageInit.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Page Init";
            // 
            // tbPrinterFinish
            // 
            this.tbPrinterFinish.Location = new System.Drawing.Point(161, 123);
            this.tbPrinterFinish.Name = "tbPrinterFinish";
            this.tbPrinterFinish.Size = new System.Drawing.Size(316, 20);
            this.tbPrinterFinish.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Printer Finish";
            // 
            // tbCodePage
            // 
            this.tbCodePage.Location = new System.Drawing.Point(161, 97);
            this.tbCodePage.Name = "tbCodePage";
            this.tbCodePage.Size = new System.Drawing.Size(316, 20);
            this.tbCodePage.TabIndex = 5;
            this.tbCodePage.Text = "^CI28";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Code Page";
            // 
            // tbPrinterInit
            // 
            this.tbPrinterInit.Location = new System.Drawing.Point(161, 71);
            this.tbPrinterInit.Name = "tbPrinterInit";
            this.tbPrinterInit.Size = new System.Drawing.Size(316, 20);
            this.tbPrinterInit.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Printer Init";
            // 
            // cbDensity
            // 
            this.cbDensity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDensity.FormattingEnabled = true;
            this.cbDensity.Items.AddRange(new object[] {
            "6 dpmm(152 dpi)",
            "8 dpmm(203 dpi)",
            "12 dpmm(300 dpi)",
            "24 dpmm(600 dpi)"});
            this.cbDensity.Location = new System.Drawing.Point(161, 44);
            this.cbDensity.Name = "cbDensity";
            this.cbDensity.Size = new System.Drawing.Size(135, 21);
            this.cbDensity.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Density";
            // 
            // btnShowReport
            // 
            this.btnShowReport.Enabled = false;
            this.btnShowReport.Location = new System.Drawing.Point(36, 85);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(123, 23);
            this.btnShowReport.TabIndex = 11;
            this.btnShowReport.Text = "Show Report";
            this.btnShowReport.UseVisualStyleBackColor = true;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click);
            // 
            // btnDesignReport
            // 
            this.btnDesignReport.Enabled = false;
            this.btnDesignReport.Location = new System.Drawing.Point(36, 56);
            this.btnDesignReport.Name = "btnDesignReport";
            this.btnDesignReport.Size = new System.Drawing.Size(123, 23);
            this.btnDesignReport.TabIndex = 10;
            this.btnDesignReport.Text = "Design Report";
            this.btnDesignReport.UseVisualStyleBackColor = true;
            this.btnDesignReport.Click += new System.EventHandler(this.btnDesignReport_Click);
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Location = new System.Drawing.Point(165, 36);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(0, 13);
            this.lblReportName.TabIndex = 9;
            // 
            // btnSelectReport
            // 
            this.btnSelectReport.Location = new System.Drawing.Point(36, 27);
            this.btnSelectReport.Name = "btnSelectReport";
            this.btnSelectReport.Size = new System.Drawing.Size(123, 23);
            this.btnSelectReport.TabIndex = 8;
            this.btnSelectReport.Text = "Select Report";
            this.btnSelectReport.UseVisualStyleBackColor = true;
            this.btnSelectReport.Click += new System.EventHandler(this.btnSelectReport_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnLoad);
            this.tabPage2.Controls.Add(this.textEditor);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(578, 429);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ZPL text";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(429, 381);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(113, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load From File";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // textEditor
            // 
            this.textEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditor.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textEditor.Location = new System.Drawing.Point(3, 3);
            this.textEditor.Multiline = true;
            this.textEditor.Name = "textEditor";
            this.textEditor.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textEditor.Size = new System.Drawing.Size(572, 423);
            this.textEditor.TabIndex = 0;
            // 
            // btnShowZPL
            // 
            this.btnShowZPL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowZPL.Location = new System.Drawing.Point(423, 485);
            this.btnShowZPL.Name = "btnShowZPL";
            this.btnShowZPL.Size = new System.Drawing.Size(82, 38);
            this.btnShowZPL.TabIndex = 13;
            this.btnShowZPL.Text = "Show ZPL";
            this.btnShowZPL.UseVisualStyleBackColor = true;
            this.btnShowZPL.Click += new System.EventHandler(this.btnShowZPL_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 546);
            this.Controls.Add(this.btnShowZPL);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPrinters);
            this.Controls.Add(this.btnPrint);
            this.MinimumSize = new System.Drawing.Size(626, 585);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZPL Printing Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFontScale)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ComboBox cbPrinters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbPrintAsBitmap;
        private System.Windows.Forms.TextBox tbPrinterFont;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudFontScale;
        private System.Windows.Forms.TextBox tbPageInit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPrinterFinish;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCodePage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPrinterInit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbDensity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnShowReport;
        private System.Windows.Forms.Button btnDesignReport;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.Button btnSelectReport;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox textEditor;
        private System.Windows.Forms.Button btnShowZPL;
    }
}

