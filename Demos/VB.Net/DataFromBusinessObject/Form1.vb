Public Class Form1
    Private FBusinessObject As List(Of Category)

    Private Sub CreateBusinessObject()
        FBusinessObject = New List(Of Category)

        Dim category As New Category("Beverages", "Soft drinks, coffees, teas, beers")
        category.Products.Add(New Product("Chai", 18))
        category.Products.Add(New Product("Chang", 19))
        category.Products.Add(New Product("Ipoh coffee", 46))
        FBusinessObject.Add(category)

        category = New Category("Confections", "Desserts, candies, and sweet breads")
        category.Products.Add(New Product("Chocolade", 12.75))
        category.Products.Add(New Product("Scottish Longbreads", 12.5))
        category.Products.Add(New Product("Tarte au sucre", 49.3))
        FBusinessObject.Add(category)

        category = New Category("Seafood", "Seaweed and fish")
        category.Products.Add(New Product("Boston Crab Meat", 18.4))
        category.Products.Add(New Product("Red caviar", 15))
        FBusinessObject.Add(category)
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateBusinessObject()
    End Sub

    Private Sub btnCreateNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreateNew.Click
        ' create report instance
        Dim report As New Report
        ' register the business object
        report.RegisterData(Me.FBusinessObject, "Categories")
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
        ' register the business object
        report.RegisterData(Me.FBusinessObject, "Categories")
        ' show the report
        report.Show()
        ' free resources used by report
        report.Dispose()
    End Sub

    Public Class Category
        ' Fields
        Private FDescription As String
        Private FName As String
        Private FProducts As List(Of Product)

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

        ' Methods
        Public Sub New(ByVal name As String, ByVal description As String)
            Me.FName = name
            Me.FDescription = description
            Me.FProducts = New List(Of Product)
        End Sub
    End Class

    Public Class Product
        ' Fields
        Private FName As String
        Private FUnitPrice As Decimal

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

        ' Methods
        Public Sub New(ByVal name As String, ByVal unitPrice As Decimal)
            Me.FName = name
            Me.FUnitPrice = unitPrice
        End Sub
    End Class


End Class
