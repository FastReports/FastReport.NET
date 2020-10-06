Imports FastReport.DevComponents.DotNetBar
Imports FastReport
Imports FastReport.Data
Imports FastReport.Preview
Imports FastReport.Utils
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits Office2007Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private WithEvents btnDesign As Button
    Private WithEvents comboBox1 As ComboBox
    Private components As IContainer = Nothing
    Private label1 As Label
    Private label2 As Label
    Private label4 As Label
    Private lblVersion As Label
    Private WithEvents linkLabel1 As LinkLabel
    Private panel1 As Panel
    Private panel2 As Panel
    Private pictureBox1 As PictureBox
    Private previewControl1 As PreviewControl
    Private tbDescription As TextBox
    Private WithEvents tvReports As TreeView

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnDesign = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.pictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblVersion = New System.Windows.Forms.Label
        Me.linkLabel1 = New System.Windows.Forms.LinkLabel
        Me.tvReports = New System.Windows.Forms.TreeView
        Me.tbDescription = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.panel1 = New System.Windows.Forms.Panel
        Me.panel2 = New System.Windows.Forms.Panel
        Me.comboBox1 = New System.Windows.Forms.ComboBox
        Me.label2 = New System.Windows.Forms.Label
        Me.previewControl1 = New FastReport.Preview.PreviewControl
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel1.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDesign
        '
        Me.btnDesign.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDesign.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnDesign.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnDesign.Location = New System.Drawing.Point(136, 384)
        Me.btnDesign.Name = "btnDesign"
        Me.btnDesign.Size = New System.Drawing.Size(104, 23)
        Me.btnDesign.TabIndex = 0
        Me.btnDesign.Text = "Run the Designer"
        Me.btnDesign.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.BackColor = System.Drawing.Color.Transparent
        Me.label1.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.label1.Location = New System.Drawing.Point(76, 16)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(191, 25)
        Me.label1.TabIndex = 3
        Me.label1.Text = "FastReport.Net"
        '
        'pictureBox1
        '
        Me.pictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.pictureBox1.Image = Global.Main.My.Resources.Resources.fr_blue_48x48
        Me.pictureBox1.Location = New System.Drawing.Point(16, 16)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureBox1.TabIndex = 4
        Me.pictureBox1.TabStop = False
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.BackColor = System.Drawing.Color.Transparent
        Me.lblVersion.Location = New System.Drawing.Point(80, 48)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(98, 13)
        Me.lblVersion.TabIndex = 5
        Me.lblVersion.Text = "Version 0.1 (alpha)"
        '
        'linkLabel1
        '
        Me.linkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.linkLabel1.AutoSize = True
        Me.linkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.linkLabel1.Location = New System.Drawing.Point(788, 16)
        Me.linkLabel1.Name = "linkLabel1"
        Me.linkLabel1.Size = New System.Drawing.Size(143, 13)
        Me.linkLabel1.TabIndex = 7
        Me.linkLabel1.TabStop = True
        Me.linkLabel1.Text = "http://www.fast-report.com"
        '
        'tvReports
        '
        Me.tvReports.BackColor = System.Drawing.Color.White
        Me.tvReports.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tvReports.HideSelection = False
        Me.tvReports.Location = New System.Drawing.Point(8, 8)
        Me.tvReports.Name = "tvReports"
        Me.tvReports.ShowPlusMinus = False
        Me.tvReports.ShowRootLines = False
        Me.tvReports.Size = New System.Drawing.Size(232, 400)
        Me.tvReports.TabIndex = 0
        '
        'tbDescription
        '
        Me.tbDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDescription.BackColor = System.Drawing.Color.White
        Me.tbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbDescription.Location = New System.Drawing.Point(8, 28)
        Me.tbDescription.Multiline = True
        Me.tbDescription.Name = "tbDescription"
        Me.tbDescription.ReadOnly = True
        Me.tbDescription.Size = New System.Drawing.Size(232, 220)
        Me.tbDescription.TabIndex = 3
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.label4.Location = New System.Drawing.Point(8, 8)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(74, 13)
        Me.label4.TabIndex = 9
        Me.label4.Text = "Description:"
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.White
        Me.panel1.Controls.Add(Me.btnDesign)
        Me.panel1.Controls.Add(Me.tvReports)
        Me.panel1.Location = New System.Drawing.Point(16, 80)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(248, 416)
        Me.panel1.TabIndex = 10
        '
        'panel2
        '
        Me.panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.panel2.BackColor = System.Drawing.Color.White
        Me.panel2.Controls.Add(Me.tbDescription)
        Me.panel2.Controls.Add(Me.label4)
        Me.panel2.Location = New System.Drawing.Point(16, 500)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(248, 256)
        Me.panel2.TabIndex = 11
        '
        'comboBox1
        '
        Me.comboBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboBox1.FormattingEnabled = True
        Me.comboBox1.Items.AddRange(New Object() {"Visual Studio", "Office 2003", "Office 2007 (blue)", "Office 2007 (silver)", "Office 2007 (black)", "Vista Glass"})
        Me.comboBox1.Location = New System.Drawing.Point(812, 44)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(117, 21)
        Me.comboBox1.TabIndex = 12
        '
        'label2
        '
        Me.label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label2.AutoSize = True
        Me.label2.BackColor = System.Drawing.Color.Transparent
        Me.label2.Location = New System.Drawing.Point(736, 48)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(69, 13)
        Me.label2.TabIndex = 5
        Me.label2.Text = "Appearance:"
        '
        'previewControl1
        '
        Me.previewControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.previewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.previewControl1.Buttons = CType(((((((((((FastReport.PreviewButtons.Print Or FastReport.PreviewButtons.Open) _
                    Or FastReport.PreviewButtons.Save) _
                    Or FastReport.PreviewButtons.Email) _
                    Or FastReport.PreviewButtons.Find) _
                    Or FastReport.PreviewButtons.Zoom) _
                    Or FastReport.PreviewButtons.Outline) _
                    Or FastReport.PreviewButtons.PageSetup) _
                    Or FastReport.PreviewButtons.Edit) _
                    Or FastReport.PreviewButtons.Watermark) _
                    Or FastReport.PreviewButtons.Navigator), FastReport.PreviewButtons)
        Me.previewControl1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.previewControl1.Location = New System.Drawing.Point(268, 80)
        Me.previewControl1.Name = "previewControl1"
        Me.previewControl1.Size = New System.Drawing.Size(660, 676)
        Me.previewControl1.TabIndex = 8
        '
        'Form1
        '
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(944, 773)
        Me.Controls.Add(Me.comboBox1)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.previewControl1)
        Me.Controls.Add(Me.linkLabel1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.pictureBox1)
        Me.Controls.Add(Me.label1)
        Me.EnableGlass = False
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FastReport.Net Demo"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel1.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class
