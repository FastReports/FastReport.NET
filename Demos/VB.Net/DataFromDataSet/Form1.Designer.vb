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
        Me.btnCreateNew = New System.Windows.Forms.Button
        Me.btnRunExisting = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnCreateNew
        '
        Me.btnCreateNew.Location = New System.Drawing.Point(64, 128)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(164, 23)
        Me.btnCreateNew.TabIndex = 0
        Me.btnCreateNew.Text = "Create new report"
        Me.btnCreateNew.UseVisualStyleBackColor = True
        '
        'btnRunExisting
        '
        Me.btnRunExisting.Location = New System.Drawing.Point(64, 160)
        Me.btnRunExisting.Name = "btnRunExisting"
        Me.btnRunExisting.Size = New System.Drawing.Size(164, 23)
        Me.btnRunExisting.TabIndex = 1
        Me.btnRunExisting.Text = "Run existing report"
        Me.btnRunExisting.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 214)
        Me.Controls.Add(Me.btnRunExisting)
        Me.Controls.Add(Me.btnCreateNew)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Name = "Form1"
        Me.Text = "Data From DataSet"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCreateNew As System.Windows.Forms.Button
    Friend WithEvents btnRunExisting As System.Windows.Forms.Button

End Class
