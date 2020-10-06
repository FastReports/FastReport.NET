Public Class Form1
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

    Private Sub btnSimpleList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpleList.Click
        Dim report As New Report
        Dim dataSet As New DataSet

        ' load nwind database
        dataSet.ReadXml((Me.GetReportsFolder & "nwind.xml"))

        ' register all data tables and relations
        report.RegisterData(dataSet)

        ' enable the "Employees" table to use it in the report
        report.GetDataSource("Employees").Enabled = True

        ' add report page
        Dim page As New ReportPage
        report.Pages.Add(page)
        ' always give names to objects you create. You can use CreateUniqueName method to do this;
        ' call it after the object is added to a report.
        page.CreateUniqueName()

        ' create title band
        page.ReportTitle = New ReportTitleBand
        ' native FastReport unit is screen pixel, use conversion 
        page.ReportTitle.Height = (Units.Centimeters * 1.0!)
        page.ReportTitle.CreateUniqueName()

        ' create title text
        Dim titleText As New TextObject
        titleText.Parent = page.ReportTitle
        titleText.CreateUniqueName()
        titleText.Bounds = New RectangleF((Units.Centimeters * 5.0!), 0.0!, (Units.Centimeters * 10.0!), (Units.Centimeters * 1.0!))
        titleText.Font = New Font("Arial", 14.0!, FontStyle.Bold)
        titleText.Text = "Employees"
        titleText.HorzAlign = HorzAlign.Center

        ' create data band
        Dim dataBand As New DataBand
        page.Bands.Add(dataBand)
        dataBand.CreateUniqueName()
        dataBand.DataSource = report.GetDataSource("Employees")
        dataBand.Height = (Units.Centimeters * 0.5!)

        ' create two text objects with employee's name and birth date
        Dim empNameText As New TextObject
        empNameText.Parent = dataBand
        empNameText.CreateUniqueName()
        empNameText.Bounds = New RectangleF(0.0!, 0.0!, (Units.Centimeters * 5.0!), (Units.Centimeters * 0.5!))
        empNameText.Text = "[Employees.FirstName] [Employees.LastName]"

        Dim empBirthDateText As New TextObject
        empBirthDateText.Parent = dataBand
        empBirthDateText.CreateUniqueName()
        empBirthDateText.Bounds = New RectangleF((Units.Centimeters * 5.5!), 0.0!, (Units.Centimeters * 3.0!), (Units.Centimeters * 0.5!))
        empBirthDateText.Text = "[Employees.BirthDate]"
        ' format value as date
        Dim format As New FastReport.Format.DateFormat
        format.Format = "MM/dd/yyyy"
        empBirthDateText.Format = format

        ' run report designer
        report.Design()
    End Sub

    Private Sub btnMasterDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasterDetail.Click
        Dim report As New Report
        Dim dataSet As New DataSet

        ' load nwind database
        dataSet.ReadXml((Me.GetReportsFolder & "nwind.xml"))

        ' register all data tables and relations
        report.RegisterData(dataSet)

        ' enable the "Categories" and "Products" tables to use it in the report
        report.GetDataSource("Categories").Enabled = True
        report.GetDataSource("Products").Enabled = True
        ' enable relation between two tables
        report.Dictionary.UpdateRelations()

        ' add report page
        Dim page As New ReportPage
        report.Pages.Add(page)
        ' always give names to objects you create. You can use CreateUniqueName method to do this;
        ' call it after the object is added to a report.
        page.CreateUniqueName()

        ' create master data band
        Dim masterDataBand As New DataBand
        page.Bands.Add(masterDataBand)
        masterDataBand.CreateUniqueName()
        masterDataBand.DataSource = report.GetDataSource("Categories")
        masterDataBand.Height = (Units.Centimeters * 0.5!)

        ' create category name text
        Dim categoryText As New TextObject
        categoryText.Parent = masterDataBand
        categoryText.CreateUniqueName()
        categoryText.Bounds = New RectangleF(0.0!, 0.0!, (Units.Centimeters * 5.0!), (Units.Centimeters * 0.5!))
        categoryText.Font = New Font("Arial", 10.0!, FontStyle.Bold)
        categoryText.Text = "[Categories.CategoryName]"

        ' create detail data band
        Dim detailDataBand As New DataBand
        masterDataBand.Bands.Add(detailDataBand)
        detailDataBand.CreateUniqueName()
        detailDataBand.DataSource = report.GetDataSource("Products")
        detailDataBand.Height = (Units.Centimeters * 0.5!)
        ' set sort by product name
        detailDataBand.Sort.Add(New Sort("[Products.ProductName]"))

        ' create product name text
        Dim productText As New TextObject
        productText.Parent = detailDataBand
        productText.CreateUniqueName()
        productText.Bounds = New RectangleF((Units.Centimeters * 1.0!), 0.0!, (Units.Centimeters * 10.0!), (Units.Centimeters * 0.5!))
        productText.Text = "[Products.ProductName]"

        ' run report designer
        report.Design()
    End Sub

    Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroup.Click
        Dim report As New Report
        Dim dataSet As New DataSet

        ' load nwind database
        dataSet.ReadXml((Me.GetReportsFolder & "nwind.xml"))

        ' register all data tables and relations
        report.RegisterData(dataSet)

        ' enable the "Products" table to use it in the report
        report.GetDataSource("Products").Enabled = True

        ' add report page
        Dim page As New ReportPage
        report.Pages.Add(page)
        ' always give names to objects you create. You can use CreateUniqueName method to do this;
        ' call it after the object is added to a report.
        page.CreateUniqueName()

        ' create group header
        Dim groupHeaderBand As New GroupHeaderBand
        page.Bands.Add(groupHeaderBand)
        groupHeaderBand.Height = (Units.Centimeters * 1.0!)
        groupHeaderBand.Condition = "[Products.ProductName].Substring(0,1)"
        groupHeaderBand.SortOrder = FastReport.SortOrder.Ascending

        ' create group text
        Dim groupText As New TextObject
        groupText.Parent = groupHeaderBand
        groupText.CreateUniqueName()
        groupText.Bounds = New RectangleF(0.0!, 0.0!, (Units.Centimeters * 10.0!), (Units.Centimeters * 1.0!))
        groupText.Font = New Font("Arial", 14.0!, FontStyle.Bold)
        groupText.Text = "[[Products.ProductName].Substring(0,1)]"
        groupText.VertAlign = VertAlign.Center
        groupText.Fill = New LinearGradientFill(Color.OldLace, Color.Moccasin, 90, 0.5!, 1.0!)

        ' create data band
        Dim dataBand As New DataBand
        groupHeaderBand.Data = dataBand
        dataBand.CreateUniqueName()
        dataBand.DataSource = report.GetDataSource("Products")
        dataBand.Height = (Units.Centimeters * 0.5!)

        ' create product name text
        Dim productText As New TextObject
        productText.Parent = dataBand
        productText.CreateUniqueName()
        productText.Bounds = New RectangleF(0.0!, 0.0!, (Units.Centimeters * 10.0!), (Units.Centimeters * 0.5!))
        productText.Text = "[Products.ProductName]"

        ' create group footer
        groupHeaderBand.GroupFooter = New GroupFooterBand
        groupHeaderBand.GroupFooter.CreateUniqueName()
        groupHeaderBand.GroupFooter.Height = (Units.Centimeters * 1.0!)

        ' create total
        Dim groupTotal As New Total
        groupTotal.Name = "TotalRows"
        groupTotal.TotalType = TotalType.Count
        groupTotal.Evaluator = dataBand
        groupTotal.PrintOn = groupHeaderBand.GroupFooter
        report.Dictionary.Totals.Add(groupTotal)

        ' show total in the group footer
        Dim totalText As New TextObject
        totalText.Parent = groupHeaderBand.GroupFooter
        totalText.CreateUniqueName()
        totalText.Bounds = New RectangleF(0.0!, 0.0!, (Units.Centimeters * 10.0!), (Units.Centimeters * 0.5!))
        totalText.Text = "Rows: [TotalRows]"
        totalText.HorzAlign = HorzAlign.Right
        totalText.Border.Lines = BorderLines.Top

        ' run report designer
        report.Design()
    End Sub

    Private Sub btnNestedGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNestedGroups.Click
        Dim report As New Report
        Dim dataSet As New DataSet

        ' load nwind database
        dataSet.ReadXml((Me.GetReportsFolder & "nwind.xml"))

        ' register all data tables and relations
        report.RegisterData(dataSet)

        ' enable the "Products" table to use it in the report
        report.GetDataSource("Products").Enabled = True

        ' add report page
        Dim page As New ReportPage
        report.Pages.Add(page)
        ' always give names to objects you create. You can use CreateUniqueName method to do this;
        ' call it after the object is added to a report.
        page.CreateUniqueName()

        ' create group header
        Dim groupHeaderBand As New GroupHeaderBand
        page.Bands.Add(groupHeaderBand)
        groupHeaderBand.Height = (Units.Centimeters * 1.0!)
        groupHeaderBand.Condition = "[Products.ProductName].Substring(0,1)"

        ' create group text
        Dim groupText As New TextObject
        groupText.Parent = groupHeaderBand
        groupText.CreateUniqueName()
        groupText.Bounds = New RectangleF(0.0!, 0.0!, (Units.Centimeters * 10.0!), (Units.Centimeters * 1.0!))
        groupText.Font = New Font("Arial", 14.0!, FontStyle.Bold)
        groupText.Text = "[[Products.ProductName].Substring(0,1)]"
        groupText.VertAlign = VertAlign.Center
        groupText.Fill = New LinearGradientFill(Color.OldLace, Color.Moccasin, 90, 0.5!, 1.0!)

        ' create nested group header
        Dim nestedGroupBand As New GroupHeaderBand
        groupHeaderBand.NestedGroup = nestedGroupBand
        nestedGroupBand.Height = (Units.Centimeters * 0.5!)
        nestedGroupBand.Condition = "[Products.ProductName].Substring(0,2)"

        ' create nested group text
        Dim nestedText As New TextObject
        nestedText.Parent = nestedGroupBand
        nestedText.CreateUniqueName()
        nestedText.Bounds = New RectangleF(0.0!, 0.0!, (Units.Centimeters * 10.0!), (Units.Centimeters * 0.5!))
        nestedText.Font = New Font("Arial", 10.0!, FontStyle.Bold)
        nestedText.Text = "[[Products.ProductName].Substring(0,2)]"

        ' create data band
        Dim dataBand As New DataBand
        ' connect it to inner group
        nestedGroupBand.Data = dataBand
        dataBand.CreateUniqueName()
        dataBand.DataSource = report.GetDataSource("Products")
        dataBand.Height = (Units.Centimeters * 0.5!)
        ' set sort by product name
        dataBand.Sort.Add(New Sort("[Products.ProductName]"))

        ' create product name text
        Dim productText As New TextObject
        productText.Parent = dataBand
        productText.CreateUniqueName()
        productText.Bounds = New RectangleF((Units.Centimeters * 0.5!), 0.0!, (Units.Centimeters * 9.5!), (Units.Centimeters * 0.5!))
        productText.Text = "[Products.ProductName]"

        ' create group footer for outer group
        groupHeaderBand.GroupFooter = New GroupFooterBand
        groupHeaderBand.GroupFooter.CreateUniqueName()
        groupHeaderBand.GroupFooter.Height = (Units.Centimeters * 1.0!)

        ' create total
        Dim groupTotal As New Total
        groupTotal.Name = "TotalRows"
        groupTotal.TotalType = TotalType.Count
        groupTotal.Evaluator = dataBand
        groupTotal.PrintOn = groupHeaderBand.GroupFooter
        report.Dictionary.Totals.Add(groupTotal)

        ' show total in the group footer
        Dim totalText As New TextObject
        totalText.Parent = groupHeaderBand.GroupFooter
        totalText.CreateUniqueName()
        totalText.Bounds = New RectangleF(0.0!, 0.0!, (Units.Centimeters * 10.0!), (Units.Centimeters * 0.5!))
        totalText.Text = "Rows: [TotalRows]"
        totalText.HorzAlign = HorzAlign.Right
        totalText.Border.Lines = BorderLines.Top

        ' run report designer
        report.Design()
    End Sub

    Private Sub btnSubreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubreport.Click
        Dim report As New Report
        Dim dataSet As New DataSet

        ' load nwind database
        dataSet.ReadXml((Me.GetReportsFolder & "nwind.xml"))

        ' register all data tables and relations
        report.RegisterData(dataSet)

        ' enable the "Products" and "Suppliers" tables to use it in the report
        report.GetDataSource("Products").Enabled = True
        report.GetDataSource("Suppliers").Enabled = True

        ' add report page
        Dim page As New ReportPage
        report.Pages.Add(page)
        ' always give names to objects you create. You can use CreateUniqueName method to do this;
        ' call it after the object is added to a report.
        page.CreateUniqueName()

        ' create title band
        page.ReportTitle = New ReportTitleBand
        ' native FastReport unit is screen pixel, use conversion 
        page.ReportTitle.Height = (Units.Centimeters * 1.0!)
        page.ReportTitle.CreateUniqueName()

        ' create two title text objects
        Dim titleText1 As New TextObject
        titleText1.Parent = page.ReportTitle
        titleText1.CreateUniqueName()
        titleText1.Bounds = New RectangleF(0.0!, 0.0!, (Units.Centimeters * 8.0!), (Units.Centimeters * 1.0!))
        titleText1.Font = New Font("Arial", 14.0!, FontStyle.Bold)
        titleText1.Text = "Products"
        titleText1.HorzAlign = HorzAlign.Center

        Dim titleText2 As New TextObject
        titleText2.Parent = page.ReportTitle
        titleText2.CreateUniqueName()
        titleText2.Bounds = New RectangleF((Units.Centimeters * 9.0!), 0.0!, (Units.Centimeters * 8.0!), (Units.Centimeters * 1.0!))
        titleText2.Font = New Font("Arial", 14.0!, FontStyle.Bold)
        titleText2.Text = "Suppliers"
        titleText2.HorzAlign = HorzAlign.Center

        ' create report title's child band that will contain subreports
        Dim childBand As New ChildBand
        page.ReportTitle.Child = childBand
        childBand.CreateUniqueName()
        childBand.Height = (Units.Centimeters * 0.5!)

        ' create the first subreport
        Dim subreport1 As New SubreportObject
        subreport1.Parent = childBand
        subreport1.CreateUniqueName()
        subreport1.Bounds = New RectangleF(0.0!, 0.0!, (Units.Centimeters * 8.0!), (Units.Centimeters * 0.5!))

        ' create subreport's page
        Dim subreportPage1 As New ReportPage
        report.Pages.Add(subreportPage1)
        ' connect subreport to page
        subreport1.ReportPage = subreportPage1

        ' create report on the subreport's page
        Dim dataBand As New DataBand
        subreportPage1.Bands.Add(dataBand)
        dataBand.CreateUniqueName()
        dataBand.DataSource = report.GetDataSource("Products")
        dataBand.Height = (Units.Centimeters * 0.5!)

        Dim productText As New TextObject
        productText.Parent = dataBand
        productText.CreateUniqueName()
        productText.Bounds = New RectangleF(0.0!, 0.0!, (Units.Centimeters * 8.0!), (Units.Centimeters * 0.5!))
        productText.Text = "[Products.ProductName]"

        ' create the second subreport
        Dim subreport2 As New SubreportObject
        subreport2.Parent = childBand
        subreport2.CreateUniqueName()
        subreport2.Bounds = New RectangleF((Units.Centimeters * 9.0!), 0.0!, (Units.Centimeters * 8.0!), (Units.Centimeters * 0.5!))

        ' create subreport's page
        Dim subreportPage2 As New ReportPage
        report.Pages.Add(subreportPage2)
        ' connect subreport to page
        subreport2.ReportPage = subreportPage2

        ' create report on the subreport's page
        Dim dataBand2 As New DataBand
        subreportPage2.Bands.Add(dataBand2)
        dataBand2.CreateUniqueName()
        dataBand2.DataSource = report.GetDataSource("Suppliers")
        dataBand2.Height = (Units.Centimeters * 0.5!)

        ' create supplier name text
        Dim supplierText As New TextObject
        supplierText.Parent = dataBand2
        supplierText.CreateUniqueName()
        supplierText.Bounds = New RectangleF(0.0!, 0.0!, (Units.Centimeters * 8.0!), (Units.Centimeters * 0.5!))
        supplierText.Text = "[Suppliers.CompanyName]"

        ' run report designer
        report.Design()
    End Sub
End Class
