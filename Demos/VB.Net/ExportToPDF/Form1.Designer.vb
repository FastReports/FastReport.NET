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
        Me.btnExportWithDialog = New System.Windows.Forms.Button
        Me.btnSilentExport = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnExportWithDialog
        '
        Me.btnExportWithDialog.Location = New System.Drawing.Point(56, 128)
        Me.btnExportWithDialog.Name = "btnExportWithDialog"
        Me.btnExportWithDialog.Size = New System.Drawing.Size(180, 23)
        Me.btnExportWithDialog.TabIndex = 0
        Me.btnExportWithDialog.Text = "Export to PDF with dialog"
        Me.btnExportWithDialog.UseVisualStyleBackColor = True
        '
        'btnSilentExport
        '
        Me.btnSilentExport.Location = New System.Drawing.Point(56, 160)
        Me.btnSilentExport.Name = "btnSilentExport"
        Me.btnSilentExport.Size = New System.Drawing.Size(180, 23)
        Me.btnSilentExport.TabIndex = 1
        Me.btnSilentExport.Text = "Silent export"
        Me.btnSilentExport.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 220)
        Me.Controls.Add(Me.btnSilentExport)
        Me.Controls.Add(Me.btnExportWithDialog)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Name = "Form1"
        Me.Text = "Export To PDF"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExportWithDialog As System.Windows.Forms.Button
    Friend WithEvents btnSilentExport As System.Windows.Forms.Button

End Class
