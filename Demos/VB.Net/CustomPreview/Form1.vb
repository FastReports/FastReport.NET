Public Class Form1
    Private FDataSet As DataSet
    Private FReport As Report

    Private Function GetReportsFolder() As String
        Dim thisFolder As String = Config.ApplicationFolder
        Dim i As Integer
        For i = 0 To 6 - 1
            If Directory.Exists((thisFolder & "Demos\Reports")) Then
                Return Path.GetFullPath((thisFolder & "Demos\Reports\"))
            End If
            thisFolder = (thisFolder & "..\")
        Next i
        Throw New Exception("Could not locate the Reports folder.")
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FReport = New Report
        FReport.Preview = preview1
        FDataSet = New DataSet
        FDataSet.ReadXml((GetReportsFolder() & "nwind.xml"))
        lbReports.Items.Add("Simple List.frx")
        lbReports.Items.Add("Groups.frx")
        lbReports.Items.Add("Master-Detail.frx")
        lbReports.Items.Add("Labels.frx")
        lbReports.Items.Add("Subreport.frx")
    End Sub

    Private Sub lbReports_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbReports.SelectedIndexChanged
        Dim reportName As String = (GetReportsFolder() & CStr(lbReports.SelectedItem))
        FReport.Load(reportName)
        FReport.RegisterData(FDataSet, "NorthWind")
        FReport.Prepare()
        FReport.ShowPrepared()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        preview1.Print()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        exportMenu.Items.Clear()
        Dim list As New List(Of ObjectInfo)
        RegisteredObjects.Objects.EnumItems(list)
        Dim saveNative As New ToolStripMenuItem("Save to .fpx file...")
        AddHandler saveNative.Click, New EventHandler(AddressOf item_Click)
        exportMenu.Items.Add(saveNative)
        Dim info As ObjectInfo
        For Each info In list
            If ((Not info.Object Is Nothing) AndAlso info.Object.IsSubclassOf(GetType(ExportBase))) Then
                Dim item As New ToolStripMenuItem((Res.TryGet(info.Text) & "..."))
                item.Tag = info
                AddHandler item.Click, New EventHandler(AddressOf item_Click)
                If (info.ImageIndex <> -1) Then
                    item.Image = Res.GetImage(info.ImageIndex)
                End If
                exportMenu.Items.Add(item)
            End If
        Next
        exportMenu.Show(btnExport, New Point(0, btnExport.Height))
    End Sub

    Private Sub item_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim info As ObjectInfo = TryCast(TryCast(sender, ToolStripMenuItem).Tag, ObjectInfo)
        If (info Is Nothing) Then
            Me.preview1.Save()
        Else
            Dim export As ExportBase = TryCast(Activator.CreateInstance(info.Object), ExportBase)
            export.CurPage = preview1.PageNo
            export.Export(preview1.Report)
        End If
    End Sub

    Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomOut.Click
        preview1.ZoomOut()
    End Sub

    Private Sub btnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomIn.Click
        preview1.ZoomIn()
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        preview1.First()
    End Sub

    Private Sub btnPrior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrior.Click
        preview1.Prior()
    End Sub

    Private Sub tbPageNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tbPageNo.KeyDown
        If (e.KeyData = Keys.Return) Then
            preview1.PageNo = Integer.Parse(tbPageNo.Text)
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        preview1.Next()
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        preview1.Last()
    End Sub

    Private Sub preview1_PageChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles preview1.PageChanged
        tbPageNo.Text = preview1.PageNo.ToString()
    End Sub
End Class
