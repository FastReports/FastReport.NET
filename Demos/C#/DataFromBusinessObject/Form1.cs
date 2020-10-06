using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastReport;

namespace DataFromBusinessObject
{
  public partial class Form1 : Form
  {
    private List<Category> FBusinessObject;
    
    public Form1()
    {
      InitializeComponent();
      CreateBusinessObject();
    }

    private void CreateBusinessObject()
    {
      FBusinessObject = new List<Category>();

      Category category = new Category("Beverages", "Soft drinks, coffees, teas, beers");
      category.Products.Add(new Product("Chai", 18m));
      category.Products.Add(new Product("Chang", 19m));
      category.Products.Add(new Product("Ipoh coffee", 46m));
      FBusinessObject.Add(category);

      category = new Category("Confections", "Desserts, candies, and sweet breads");
      category.Products.Add(new Product("Chocolade", 12.75m));
      category.Products.Add(new Product("Scottish Longbreads", 12.5m));
      category.Products.Add(new Product("Tarte au sucre", 49.3m));
      FBusinessObject.Add(category);

      category = new Category("Seafood", "Seaweed and fish");
      category.Products.Add(new Product("Boston Crab Meat", 18.4m));
      category.Products.Add(new Product("Red caviar", 15m));
      FBusinessObject.Add(category);
    }

    private void btnCreateNew_Click(object sender, EventArgs e)
    {
      // create report instance
      Report report = new Report();

      // register the business object
      report.RegisterData(FBusinessObject, "Categories");

      // design the report
      report.Design();

      // free resources used by report
      report.Dispose();
    }

    private void btnRunExisting_Click(object sender, EventArgs e)
    {
      // create report instance
      Report report = new Report();

      // load the existing report
      report.Load(@"..\..\report.frx");

      // register the business object
      report.RegisterData(FBusinessObject, "Categories");

      // run the report
      report.Show();

      // free resources used by report
      report.Dispose();
    }
  }


  public class Category
  {
    private string FName;
    private string FDescription;
    private List<Product> FProducts;

    public string Name
    {
      get { return FName; }
    }

    public string Description
    {
      get { return FDescription; }
    }

    public List<Product> Products
    {
      get { return FProducts; }
    }

    public Category(string name, string description)
    {
      FName = name;
      FDescription = description;
      FProducts = new List<Product>();
    }
  }

  public class Product
  {
    private string FName;
    private decimal FUnitPrice;

    public string Name
    {
      get { return FName; }
    }

    public decimal UnitPrice
    {
      get { return FUnitPrice; }
    }

    public Product(string name, decimal unitPrice)
    {
      FName = name;
      FUnitPrice = unitPrice;
    }
  }
}