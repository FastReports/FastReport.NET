Public Class OpenDialogForm
    Public ReadOnly Property ReportName() As String
        Get
            Return CStr(lbxReports.SelectedItem)
        End Get
    End Property

    Public WriteOnly Property ReportsTable() As DataTable
        Set(ByVal value As DataTable)
            Dim row As DataRow
            For Each row In value.Rows
                lbxReports.Items.Add(row.Item("ReportName"))
            Next
        End Set
    End Property

    Private Sub lbxReports_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbxReports.SelectedIndexChanged
        btnOK.Enabled = Not String.IsNullOrEmpty(Me.ReportName)
    End Sub
End Class
