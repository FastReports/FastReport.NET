Imports FastReport.DevComponents.DotNetBar
Imports FastReport
Imports FastReport.Data
Imports FastReport.Preview
Imports FastReport.Utils
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Diagnostics
Imports System.Drawing
Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms

Public Class Form1

    Public Sub New()
      MyBase.SetStyle((ControlStyles.OptimizedDoubleBuffer Or (ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw)), True)
      Me.InitializeComponent
    End Sub

    Private Sub btnDesign_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDesign.Click
        Me.DesignReport()
    End Sub

    Private Sub comboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBox1.SelectedIndexChanged
        Dim style As UIStyle = DirectCast(Me.comboBox1.SelectedIndex, UIStyle)
        MyBase.Office2007ColorTable = UIStyleUtils.GetOffice2007ColorScheme(style)
        Config.UIStyle = style
        Me.previewControl1.UIStyle = style
        Me.Refresh()
    End Sub

    Private Sub DesignReport()
      If Not Me.FReport.IsRunning Then
        Me.FReport.Load(CStr(Me.tvReports.SelectedNode.Tag))
        Me.RegisterData
        Me.FReport.Design
        Me.PreviewReport
      End If
    End Sub

    Private Sub FindReportsFolder()
      Me.FReportsFolder = ""
      Dim thisFolder As String = Config.ApplicationFolder
      Dim i As Integer
      For i = 0 To 7 - 1
        If Directory.Exists((thisFolder & "Demos\Reports")) Then
          Me.FReportsFolder = Path.GetFullPath((thisFolder & "Demos\Reports\"))
          Exit For
        End If
        thisFolder = (thisFolder & "..\")
      Next i
      If (Me.FReportsFolder = "") Then
        Throw New Exception("Could not locate the Reports folder.")
      End If
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
        Me.FReport.Dispose()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Me.FindReportsFolder()
        Me.FReport = New Report
        Me.FReport.Preview = Me.previewControl1
        Config.ReportSettings.ShowPerformance = True
        AddHandler Config.ReportSettings.StartProgress, New EventHandler(AddressOf Me.ReportSettings_StartProgress)
        AddHandler Config.ReportSettings.Progress, New ProgressEventHandler(AddressOf Me.ReportSettings_Progress)
        AddHandler Config.ReportSettings.FinishProgress, New EventHandler(AddressOf Me.ReportSettings_FinishProgress)
        Me.CreateDataSources()
        Me.lblVersion.Text = ("Version " & Config.Version)
        Me.comboBox1.SelectedIndex = 2
        Me.tvReports.ImageList = Res.GetImages
        Dim reports As New XmlDocument
        reports.Load((Me.FReportsFolder & "reports.xml"))
        Dim i As Integer
        For i = 0 To reports.Root.Count - 1
            Dim folderItem As XmlItem = reports.Root.Item(i)
            If (folderItem.GetProp("WinDemo") <> "false") Then
                Dim culture As String = CultureInfo.CurrentCulture.Name
                Dim text As String = folderItem.GetProp(("Name-" & culture))
                If String.IsNullOrEmpty([text]) Then
                    [text] = folderItem.GetProp("Name")
                End If
                Dim folderNode As TreeNode = Me.tvReports.Nodes.Add(([text] & "     "))
                folderNode.ImageIndex = &H42
                folderNode.SelectedImageIndex = folderNode.ImageIndex
                folderNode.NodeFont = New Font(Me.Font, FontStyle.Bold)
                Dim j As Integer
                For j = 0 To folderItem.Count - 1
                    Dim reportItem As XmlItem = folderItem.Item(j)
                    If (reportItem.GetProp("WinDemo") <> "false") Then
                        Dim file As String = reportItem.GetProp("File")
                        Dim fileName As String = reportItem.GetProp(("Name-" & culture))
                        If String.IsNullOrEmpty(fileName) Then
                            fileName = Path.GetFileNameWithoutExtension(file)
                        End If
                        Dim fileNode As TreeNode = folderNode.Nodes.Add(fileName)
                        fileNode.ImageIndex = &H86
                        fileNode.SelectedImageIndex = fileNode.ImageIndex
                        fileNode.Tag = (Me.FReportsFolder & file)
                    End If
                Next j
            End If
        Next i
        If ((Me.tvReports.Nodes.Count > 0) AndAlso (Me.tvReports.Nodes.Item(0).Nodes.Count > 0)) Then
            Me.tvReports.SelectedNode = Me.tvReports.Nodes.Item(0).Nodes.Item(0)
        End If
        Me.tvReports.Focus()
    End Sub

    Private Sub linkLabel1_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked
        Process.Start("http://www.fast-report.com")
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
      Dim color As Color = SystemColors.ControlDark
        Select Case Config.UIStyle
            Case UIStyle.Office2003, UIStyle.Office2007Blue
                color = Drawing.Color.FromArgb(150, 180, &HE0)
                Exit Select
            Case UIStyle.Office2007Silver
                color = Drawing.Color.FromArgb(&H9C, 160, &HA7)
                Exit Select
            Case UIStyle.Office2007Black, UIStyle.VistaGlass
                color = Drawing.Color.FromArgb(&H54, &H54, &H54)
                Exit Select
        End Select
        Using b As Brush = New SolidBrush(color)
            g.FillRectangle(b, MyBase.ClientRectangle)
        End Using
        Using b As Brush = New SolidBrush(Drawing.Color.FromArgb(&H80, Drawing.Color.White))
            g.FillEllipse(b, New Rectangle(-300, -50, (MyBase.ClientRectangle.Width + 600), 220))
        End Using
    End Sub

    Private Sub PreviewReport()
      If Not Me.FReport.IsRunning Then
        Me.RegisterData
        Me.FReport.Show
      End If
    End Sub

    Private Sub CreateDataSources()
        Me.FDataSet = New DataSet
        Me.FDataSet.ReadXml((Me.FReportsFolder & "nwind.xml"))
        Me.FBusinessObject = New List(Of Category)
        Dim category As New Category("Beverages", "Soft drinks, coffees, teas, beers")
        category.Products.Add(New Product("Chai", 18))
        category.Products.Add(New Product("Chang", 19))
        category.Products.Add(New Product("Ipoh coffee", 46))
        Me.FBusinessObject.Add(category)
        category = New Category("Confections", "Desserts, candies, and sweet breads")
        category.Products.Add(New Product("Chocolade", 12.75))
        category.Products.Add(New Product("Scottish Longbreads", 12.5))
        category.Products.Add(New Product("Tarte au sucre", 49.3))
        Me.FBusinessObject.Add(category)
        category = New Category("Seafood", "Seaweed and fish")
        category.Products.Add(New Product("Boston Crab Meat", 18.4))
        category.Products.Add(New Product("Red caviar", 15))
        Me.FBusinessObject.Add(category)
    End Sub

    Private Sub RegisterData()
        Me.FReport.RegisterData(Me.FDataSet, "NorthWind")
        Me.FReport.RegisterData(Me.FBusinessObject, "Categories BusinessObject")
    End Sub

    Private Sub ReportSettings_FinishProgress(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Private Sub ReportSettings_Progress(ByVal sender As Object, ByVal e As ProgressEventArgs)
      Me.previewControl1.ShowStatus(e.Message)
    End Sub

    Private Sub ReportSettings_StartProgress(ByVal sender As Object, ByVal e As EventArgs)
    End Sub

    Public Shared Sub TestMessage()
      MessageBox.Show("Hello from the main application!")
    End Sub

    Private Sub tvReports_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles tvReports.AfterSelect
        If Not Me.FReport.IsRunning Then
            Dim selectedNode As TreeNode = Me.tvReports.SelectedNode
            If (selectedNode.Tag Is Nothing) Then
                Me.tvReports.CollapseAll()
                Me.tvReports.SelectedNode = e.Node.Nodes.Item(0)
            Else
                Me.FReport.Load(CStr(selectedNode.Tag))
                Me.tbDescription.Text = Me.FReport.ReportInfo.Description
                Me.PreviewReport()
            End If
        End If
    End Sub


    ' Fields
    Private FDataSet As DataSet
    Private FBusinessObject As List(Of Category)
    Private FReport As Report
    Private FReportsFolder As String

    Public Class Category
        ' Methods
        Public Sub New(ByVal name As String, ByVal description As String)
            Me.FName = name
            Me.FDescription = description
            Me.FProducts = New List(Of Product)
        End Sub


        ' Properties
        Public ReadOnly Property Description() As String
            Get
                Return Me.FDescription
            End Get
        End Property

        Public ReadOnly Property Name() As String
            Get
                Return Me.FName
            End Get
        End Property

        Public ReadOnly Property Products() As List(Of Product)
            Get
                Return Me.FProducts
            End Get
        End Property


        ' Fields
        Private FDescription As String
        Private FName As String
        Private FProducts As List(Of Product)
    End Class


    Public Class Product
        ' Methods
        Public Sub New(ByVal name As String, ByVal unitPrice As Decimal)
            Me.FName = name
            Me.FUnitPrice = unitPrice
        End Sub


        ' Properties
        Public ReadOnly Property Name() As String
            Get
                Return Me.FName
            End Get
        End Property

        Public ReadOnly Property UnitPrice() As Decimal
            Get
                Return Me.FUnitPrice
            End Get
        End Property


        ' Fields
        Private FName As String
        Private FUnitPrice As Decimal
    End Class

End Class
