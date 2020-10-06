Public Class Form1
    Private FArray As Integer()

    Private Sub CreateArray()
        Me.FArray = New Integer(9) {}
        Dim i As Integer
        For i = 0 To 9
            Me.FArray(i) = (i + 1)
        Next i
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateArray()
    End Sub

    Private Sub btnCreateNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateNew.Click
        ' create report instance
        Dim report As New Report
        ' register the array
        report.RegisterData(Me.FArray, "Array")
        ' design the report
        report.Design()
        ' free resources used by report
        report.Dispose()
    End Sub

    Private Sub btnRunExisting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunExisting.Click
        ' create report instance
        Dim report As New Report
        ' load the existing report
        report.Load("..\..\report.frx")
        ' register the array
        report.RegisterData(Me.FArray, "Array")
        ' run the report
        report.Show()
        ' free resources used by report
        report.Dispose()
    End Sub
End Class
