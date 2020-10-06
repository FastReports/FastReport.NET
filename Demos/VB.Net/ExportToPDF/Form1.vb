Public Class Form1
    Private FDataSet As DataSet

    Private Sub CreateDataSet()
        ' create simple dataset with one table
        Me.FDataSet = New DataSet
        Dim table As New DataTable
        table.TableName = "Employees"
        Me.FDataSet.Tables.Add(table)

        table.Columns.Add("ID", GetType(Integer))
        table.Columns.Add("Name", GetType(String))

        table.Rows.Add(1, "Andrew Fuller")
        table.Rows.Add(2, "Nancy Davolio")
        table.Rows.Add(3, "Margaret Peacock")
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateDataSet()
    End Sub

    Private Sub btnExportWithDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportWithDialog.Click
        ' create report instance
        Dim report As New Report
        ' load the existing report
        report.Load("..\..\report.frx")
        ' register the dataset
        report.RegisterData(Me.FDataSet)
        ' run the report
        report.Prepare()
        ' create export instance
        Dim export As New PDFExport
        export.Export(report)
        ' free resources used by report
        report.Dispose()
    End Sub

    Private Sub btnSilentExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSilentExport.Click
        ' create report instance
        Dim report As New Report
        ' load the existing report
        report.Load("..\..\report.frx")
        ' register the dataset
        report.RegisterData(Me.FDataSet)
        ' run the report
        report.Prepare()
        ' create export instance
        Dim export As New PDFExport
        report.Export(export, "result.pdf")
        ' free resources used by report
        report.Dispose()
    End Sub
End Class
