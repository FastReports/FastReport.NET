<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.preview1 = New FastReport.Preview.PreviewControl
        Me.lbReports = New System.Windows.Forms.ListBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnExport = New System.Windows.Forms.Button
        Me.btnZoomOut = New System.Windows.Forms.Button
        Me.btnZoomIn = New System.Windows.Forms.Button
        Me.btnFirst = New System.Windows.Forms.Button
        Me.btnPrior = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnLast = New System.Windows.Forms.Button
        Me.tbPageNo = New System.Windows.Forms.TextBox
        Me.exportMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.SuspendLayout()
        '
        'preview1
        '
        Me.preview1.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.preview1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.preview1.Location = New System.Drawing.Point(188, 44)
        Me.preview1.Name = "preview1"
        Me.preview1.Size = New System.Drawing.Size(520, 556)
        Me.preview1.StatusbarVisible = False
        Me.preview1.TabIndex = 0
        Me.preview1.ToolbarVisible = False
        Me.preview1.UIStyle = FastReport.Utils.UIStyle.VisualStudio2005
        '
        'lbReports
        '
        Me.lbReports.FormattingEnabled = True
        Me.lbReports.Location = New System.Drawing.Point(12, 12)
        Me.lbReports.Name = "lbReports"
        Me.lbReports.Size = New System.Drawing.Size(164, 589)
        Me.lbReports.TabIndex = 1
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(188, 12)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(56, 23)
        Me.btnPrint.TabIndex = 2
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(248, 12)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(56, 23)
        Me.btnExport.TabIndex = 2
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnZoomOut
        '
        Me.btnZoomOut.Location = New System.Drawing.Point(356, 12)
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.Size = New System.Drawing.Size(32, 23)
        Me.btnZoomOut.TabIndex = 3
        Me.btnZoomOut.Text = "-"
        Me.btnZoomOut.UseVisualStyleBackColor = True
        '
        'btnZoomIn
        '
        Me.btnZoomIn.Location = New System.Drawing.Point(392, 12)
        Me.btnZoomIn.Name = "btnZoomIn"
        Me.btnZoomIn.Size = New System.Drawing.Size(32, 23)
        Me.btnZoomIn.TabIndex = 3
        Me.btnZoomIn.Text = "+"
        Me.btnZoomIn.UseVisualStyleBackColor = True
        '
        'btnFirst
        '
        Me.btnFirst.Location = New System.Drawing.Point(524, 12)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(32, 23)
        Me.btnFirst.TabIndex = 3
        Me.btnFirst.Text = "<<"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'btnPrior
        '
        Me.btnPrior.Location = New System.Drawing.Point(556, 12)
        Me.btnPrior.Name = "btnPrior"
        Me.btnPrior.Size = New System.Drawing.Size(32, 23)
        Me.btnPrior.TabIndex = 3
        Me.btnPrior.Text = "<"
        Me.btnPrior.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(644, 12)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(32, 23)
        Me.btnNext.TabIndex = 3
        Me.btnNext.Text = ">"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Location = New System.Drawing.Point(676, 12)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(32, 23)
        Me.btnLast.TabIndex = 3
        Me.btnLast.Text = ">>"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'tbPageNo
        '
        Me.tbPageNo.Location = New System.Drawing.Point(596, 12)
        Me.tbPageNo.Name = "tbPageNo"
        Me.tbPageNo.Size = New System.Drawing.Size(40, 21)
        Me.tbPageNo.TabIndex = 4
        '
        'exportMenu
        '
        Me.exportMenu.Name = "exportMenu"
        Me.exportMenu.Size = New System.Drawing.Size(61, 4)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(721, 613)
        Me.Controls.Add(Me.tbPageNo)
        Me.Controls.Add(Me.btnZoomIn)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrior)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.btnZoomOut)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lbReports)
        Me.Controls.Add(Me.preview1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Custom Preview"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents preview1 As FastReport.Preview.PreviewControl
    Friend WithEvents lbReports As System.Windows.Forms.ListBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnZoomOut As System.Windows.Forms.Button
    Friend WithEvents btnZoomIn As System.Windows.Forms.Button
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents btnPrior As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents tbPageNo As System.Windows.Forms.TextBox
    Friend WithEvents exportMenu As System.Windows.Forms.ContextMenuStrip

End Class
