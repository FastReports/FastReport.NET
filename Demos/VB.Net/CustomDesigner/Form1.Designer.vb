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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.DesignerControl1 = New FastReport.Design.StandardDesigner.DesignerControl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnUndo = New System.Windows.Forms.Button
        Me.btnRedo = New System.Windows.Forms.Button
        CType(Me.DesignerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DesignerControl1
        '
        Me.DesignerControl1.AskSave = True
        Me.DesignerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DesignerControl1.LayoutState = resources.GetString("DesignerControl1.LayoutState")
        Me.DesignerControl1.Location = New System.Drawing.Point(0, 40)
        Me.DesignerControl1.Name = "DesignerControl1"
        Me.DesignerControl1.Size = New System.Drawing.Size(627, 506)
        Me.DesignerControl1.TabIndex = 0
        Me.DesignerControl1.UIStyle = FastReport.Utils.UIStyle.Office2007Black
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnRedo)
        Me.Panel1.Controls.Add(Me.btnUndo)
        Me.Panel1.Controls.Add(Me.btnSave)
        Me.Panel1.Controls.Add(Me.btnOpen)
        Me.Panel1.Controls.Add(Me.btnNew)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(627, 40)
        Me.Panel1.TabIndex = 1
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(16, 8)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "New Report"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(96, 8)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 0
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(176, 8)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnUndo
        '
        Me.btnUndo.Location = New System.Drawing.Point(256, 8)
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(75, 23)
        Me.btnUndo.TabIndex = 0
        Me.btnUndo.Text = "Undo"
        Me.btnUndo.UseVisualStyleBackColor = True
        '
        'btnRedo
        '
        Me.btnRedo.Location = New System.Drawing.Point(336, 8)
        Me.btnRedo.Name = "btnRedo"
        Me.btnRedo.Size = New System.Drawing.Size(75, 23)
        Me.btnRedo.TabIndex = 0
        Me.btnRedo.Text = "Redo"
        Me.btnRedo.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(627, 546)
        Me.Controls.Add(Me.DesignerControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.DesignerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DesignerControl1 As FastReport.Design.StandardDesigner.DesignerControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnRedo As System.Windows.Forms.Button
    Friend WithEvents btnUndo As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button

End Class
