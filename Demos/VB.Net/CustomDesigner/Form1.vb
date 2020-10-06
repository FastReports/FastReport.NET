Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' create a new empty report and attach it to the designer
        Dim report As Report = New Report
        DesignerControl1.Report = report

        ' restore the design layout. Without this code, the designer tool windows will be unavailable
        DesignerControl1.RefreshLayout()
    End Sub

    Private Sub DesignerControl1_UIStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesignerControl1.UIStateChanged
        ' update Enabled state of our buttons
        btnSave.Enabled = DesignerControl1.cmdSave.Enabled
        btnUndo.Enabled = DesignerControl1.cmdUndo.Enabled
        btnRedo.Enabled = DesignerControl1.cmdRedo.Enabled
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        DesignerControl1.cmdNew.Invoke()
    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        DesignerControl1.cmdOpen.Invoke()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        DesignerControl1.cmdSave.Invoke()
    End Sub

    Private Sub btnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        DesignerControl1.cmdUndo.Invoke()
    End Sub

    Private Sub btnRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedo.Click
        DesignerControl1.cmdRedo.Invoke()
    End Sub
End Class
