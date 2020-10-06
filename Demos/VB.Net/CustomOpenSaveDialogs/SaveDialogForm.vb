Public Class SaveDialogForm
    ' Properties
    Public ReadOnly Property ReportName() As String
        Get
            Return tbReportName.Text
        End Get
    End Property

    Private Sub tbReportName_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles tbReportName.TextChanged
        btnOK.Enabled = Not String.IsNullOrEmpty(Me.ReportName)
    End Sub
End Class
