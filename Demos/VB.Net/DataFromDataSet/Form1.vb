Public Class Form1
    Private FDataSet As DataSet

    Private Sub CreateDataSet()
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

    Private Sub btnCreateNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateNew.Click
        ' create report instance
        Dim report As New Report
        ' register the dataset
        report.RegisterData(Me.FDataSet)
        ' enable the "Employees" datasource programmatically. 
        ' You can also do this in the "Report|Choose Report Data..." menu.
        report.GetDataSource("Employees").Enabled = True
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
        ' register the dataset
        report.RegisterData(Me.FDataSet)
        ' run the report
        report.Show()
        ' free resources used by report
        report.Dispose()
    End Sub
End Class
