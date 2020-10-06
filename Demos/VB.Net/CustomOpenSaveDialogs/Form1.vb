Public Class Form1
    Private FReportsDs As DataSet

    Private ReadOnly Property ReportsTable() As DataTable
        Get
            Return Me.FReportsDs.Tables.Item(0)
        End Get
    End Property

    Private Sub InitializeDatabase()
        Me.FReportsDs = New DataSet
        Me.FReportsDs.ReadXml((Config.ApplicationFolder & "..\..\database.xml"))
    End Sub

    Private Sub FinalizeDatabase()
        Me.FReportsDs.WriteXml((Config.ApplicationFolder & "..\..\database.xml"), XmlWriteMode.WriteSchema)
    End Sub

    Private Sub WireupDesignerEvents()
        AddHandler Config.DesignerSettings.CustomOpenDialog, New OpenSaveDialogEventHandler(AddressOf Me.DesignerSettings_CustomOpenDialog)
        AddHandler Config.DesignerSettings.CustomOpenReport, New OpenSaveReportEventHandler(AddressOf Me.DesignerSettings_CustomOpenReport)
        AddHandler Config.DesignerSettings.CustomSaveDialog, New OpenSaveDialogEventHandler(AddressOf Me.DesignerSettings_CustomSaveDialog)
        AddHandler Config.DesignerSettings.CustomSaveReport, New OpenSaveReportEventHandler(AddressOf Me.DesignerSettings_CustomSaveReport)
    End Sub

    Private Sub DesignReport()
        Using report As Report = New Report
            AddHandler report.LoadBaseReport, New CustomLoadEventHandler(AddressOf Me.report_LoadBaseReport)
            report.Design()
        End Using
    End Sub

    ' this event is fired when loading a base part of an inherited report.
    Private Sub report_LoadBaseReport(ByVal sender As Object, ByVal e As CustomLoadEventArgs)
        Me.OpenReport(e.Report, e.FileName)
    End Sub

    ' this event is fired when the user press the "Open file" button
    Private Sub DesignerSettings_CustomOpenDialog(ByVal sender As Object, ByVal e As OpenSaveDialogEventArgs)
        Using form As OpenDialogForm = New OpenDialogForm
            ' pass the reports table to display a list of reports
            form.ReportsTable = Me.ReportsTable

            ' show dialog
            e.Cancel = (form.ShowDialog <> Windows.Forms.DialogResult.OK)

            ' return the selected report in e.FileName
            e.FileName = form.ReportName
        End Using
    End Sub

    ' this event is fired when report needs to be loaded
    Private Sub DesignerSettings_CustomOpenReport(ByVal sender As Object, ByVal e As OpenSaveReportEventArgs)
        Me.OpenReport(e.Report, e.FileName)
    End Sub

    ' this event is fired when the user press the "Save file" button to save untitled report,
    ' or "Save file as" button
    Private Sub DesignerSettings_CustomSaveDialog(ByVal sender As Object, ByVal e As OpenSaveDialogEventArgs)
        Using form As SaveDialogForm = New SaveDialogForm
            ' show dialog
            e.Cancel = (form.ShowDialog <> Windows.Forms.DialogResult.OK)

            ' return the report name in e.FileName
            e.FileName = form.ReportName
        End Using
    End Sub

    ' this event is fired when report needs to be saved
    Private Sub DesignerSettings_CustomSaveReport(ByVal sender As Object, ByVal e As OpenSaveReportEventArgs)
        Me.SaveReport(e.Report, e.FileName)
    End Sub

    Private Sub OpenReport(ByVal report As Report, ByVal reportName As String)
        ' find the datarow with specified ReportName
        For Each row As DataRow In Me.ReportsTable.Rows
            If (CStr(row.Item("ReportName")) = reportName) Then
                ' load the report from a stream contained in the "ReportStream" datacolumn
                Dim reportBytes As Byte() = DirectCast(row.Item("ReportStream"), Byte())
                Using stream As IO.MemoryStream = New IO.MemoryStream(reportBytes)
                    report.Load(stream)
                End Using
                Exit For
            End If
        Next
    End Sub

    Private Sub SaveReport(ByVal report As Report, ByVal reportName As String)
        ' find the datarow with specified ReportName
        Dim reportRow As DataRow = Nothing
        Dim row As DataRow
        For Each row In Me.ReportsTable.Rows
            If (CStr(row.Item("ReportName")) = reportName) Then
                reportRow = row
                Exit For
            End If
        Next

        ' no existing row found, append new one
        If (reportRow Is Nothing) Then
            reportRow = Me.ReportsTable.NewRow
            Me.ReportsTable.Rows.Add(reportRow)
        End If

        ' save the report to a stream, then put byte[] array to the datarow
        Using stream As IO.MemoryStream = New IO.MemoryStream
            report.Save(stream)
            reportRow.Item("ReportName") = reportName
            reportRow.Item("ReportStream") = stream.ToArray
        End Using
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        InitializeDatabase()
        WireupDesignerEvents()
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        FinalizeDatabase()
    End Sub

    Private Sub btnRunDesigner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunDesigner.Click
        DesignReport()
    End Sub
End Class
