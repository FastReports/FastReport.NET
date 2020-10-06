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
        Me.btnSimpleList = New System.Windows.Forms.Button
        Me.btnMasterDetail = New System.Windows.Forms.Button
        Me.btnGroup = New System.Windows.Forms.Button
        Me.btnNestedGroups = New System.Windows.Forms.Button
        Me.btnSubreport = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnSimpleList
        '
        Me.btnSimpleList.Location = New System.Drawing.Point(32, 36)
        Me.btnSimpleList.Name = "btnSimpleList"
        Me.btnSimpleList.Size = New System.Drawing.Size(224, 23)
        Me.btnSimpleList.TabIndex = 0
        Me.btnSimpleList.Text = "Simple List"
        Me.btnSimpleList.UseVisualStyleBackColor = True
        '
        'btnMasterDetail
        '
        Me.btnMasterDetail.Location = New System.Drawing.Point(32, 68)
        Me.btnMasterDetail.Name = "btnMasterDetail"
        Me.btnMasterDetail.Size = New System.Drawing.Size(224, 23)
        Me.btnMasterDetail.TabIndex = 0
        Me.btnMasterDetail.Text = "Master-Detail"
        Me.btnMasterDetail.UseVisualStyleBackColor = True
        '
        'btnGroup
        '
        Me.btnGroup.Location = New System.Drawing.Point(32, 100)
        Me.btnGroup.Name = "btnGroup"
        Me.btnGroup.Size = New System.Drawing.Size(224, 23)
        Me.btnGroup.TabIndex = 0
        Me.btnGroup.Text = "Group"
        Me.btnGroup.UseVisualStyleBackColor = True
        '
        'btnNestedGroups
        '
        Me.btnNestedGroups.Location = New System.Drawing.Point(32, 132)
        Me.btnNestedGroups.Name = "btnNestedGroups"
        Me.btnNestedGroups.Size = New System.Drawing.Size(224, 23)
        Me.btnNestedGroups.TabIndex = 0
        Me.btnNestedGroups.Text = "Nested Groups"
        Me.btnNestedGroups.UseVisualStyleBackColor = True
        '
        'btnSubreport
        '
        Me.btnSubreport.Location = New System.Drawing.Point(32, 164)
        Me.btnSubreport.Name = "btnSubreport"
        Me.btnSubreport.Size = New System.Drawing.Size(224, 23)
        Me.btnSubreport.TabIndex = 0
        Me.btnSubreport.Text = "Subreport"
        Me.btnSubreport.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(292, 221)
        Me.Controls.Add(Me.btnSubreport)
        Me.Controls.Add(Me.btnNestedGroups)
        Me.Controls.Add(Me.btnGroup)
        Me.Controls.Add(Me.btnMasterDetail)
        Me.Controls.Add(Me.btnSimpleList)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report from code"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnSimpleList As System.Windows.Forms.Button
    Friend WithEvents btnMasterDetail As System.Windows.Forms.Button
    Friend WithEvents btnGroup As System.Windows.Forms.Button
    Friend WithEvents btnNestedGroups As System.Windows.Forms.Button
    Friend WithEvents btnSubreport As System.Windows.Forms.Button

End Class
