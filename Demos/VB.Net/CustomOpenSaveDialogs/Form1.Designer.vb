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
        Me.btnRunDesigner = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnRunDesigner
        '
        Me.btnRunDesigner.Location = New System.Drawing.Point(80, 212)
        Me.btnRunDesigner.Name = "btnRunDesigner"
        Me.btnRunDesigner.Size = New System.Drawing.Size(132, 23)
        Me.btnRunDesigner.TabIndex = 0
        Me.btnRunDesigner.Text = "Run the Designer"
        Me.btnRunDesigner.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.btnRunDesigner)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Name = "Form1"
        Me.Text = "Custom Open/Save Dialogs"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnRunDesigner As System.Windows.Forms.Button

End Class
