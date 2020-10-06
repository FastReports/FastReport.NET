using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FastReport;
using FastReport.Utils;
using FastReport.Format;
using FastReport.Data;

namespace ReportFromCode
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
      Config.WelcomeEnabled = false;
    }

    private string GetReportsFolder()
    {
      string thisFolder = Config.ApplicationFolder;

      for (int i = 0; i < 6; i++)
      {
        if (Directory.Exists(thisFolder + @"Demos\Reports"))
        {
          return Path.GetFullPath(thisFolder + @"Demos\Reports\");
        }
        thisFolder += @"..\";
      }

      throw new Exception("Could not locate the Reports folder.");
    }

    private void btnSimpleList_Click(object sender, EventArgs e)
    {
      Report report = new Report();
      
      // load nwind database
      DataSet dataSet = new DataSet();
      dataSet.ReadXml(GetReportsFolder() + "nwind.xml");
      
      // register all data tables and relations
      report.RegisterData(dataSet);
      
      // enable the "Employees" table to use it in the report
      report.GetDataSource("Employees").Enabled = true;
      
      // add report page
      ReportPage page = new ReportPage();
      report.Pages.Add(page);
      // always give names to objects you create. You can use CreateUniqueName method to do this;
      // call it after the object is added to a report.
      page.CreateUniqueName();
      
      // create title band
      page.ReportTitle = new ReportTitleBand();
      // native FastReport unit is screen pixel, use conversion 
      page.ReportTitle.Height = Units.Centimeters * 1;
      page.ReportTitle.CreateUniqueName();
      
      // create title text
      TextObject titleText = new TextObject();
      titleText.Parent = page.ReportTitle;
      titleText.CreateUniqueName();
      titleText.Bounds = new RectangleF(Units.Centimeters * 5, 0, Units.Centimeters * 10, Units.Centimeters * 1);
      titleText.Font = new Font("Arial", 14, FontStyle.Bold);
      titleText.Text = "Employees";
      titleText.HorzAlign = HorzAlign.Center;

      // create data band
      DataBand dataBand = new DataBand();
      page.Bands.Add(dataBand);
      dataBand.CreateUniqueName();
      dataBand.DataSource = report.GetDataSource("Employees");
      dataBand.Height = Units.Centimeters * 0.5f;
      
      // create two text objects with employee's name and birth date
      TextObject empNameText = new TextObject();
      empNameText.Parent = dataBand;
      empNameText.CreateUniqueName();
      empNameText.Bounds = new RectangleF(0, 0, Units.Centimeters * 5, Units.Centimeters * 0.5f);
      empNameText.Text = "[Employees.FirstName] [Employees.LastName]";
      
      TextObject empBirthDateText = new TextObject();
      empBirthDateText.Parent = dataBand;
      empBirthDateText.CreateUniqueName();
      empBirthDateText.Bounds = new RectangleF(Units.Centimeters * 5.5f, 0, Units.Centimeters * 3, Units.Centimeters * 0.5f);
      empBirthDateText.Text = "[Employees.BirthDate]";
      // format value as date
      DateFormat format = new DateFormat();
      format.Format = "MM/dd/yyyy";
      empBirthDateText.Format = format;

      // run report designer
      report.Design();
    }

    private void btnMasterDetail_Click(object sender, EventArgs e)
    {
      Report report = new Report();

      // load nwind database
      DataSet dataSet = new DataSet();
      dataSet.ReadXml(GetReportsFolder() + "nwind.xml");

      // register all data tables and relations
      report.RegisterData(dataSet);

      // enable the "Categories" and "Products" tables to use it in the report
      report.GetDataSource("Categories").Enabled = true;
      report.GetDataSource("Products").Enabled = true;
      // enable relation between two tables
      report.Dictionary.UpdateRelations();

      // add report page
      ReportPage page = new ReportPage();
      report.Pages.Add(page);
      // always give names to objects you create. You can use CreateUniqueName method to do this;
      // call it after the object is added to a report.
      page.CreateUniqueName();

      // create master data band
      DataBand masterDataBand = new DataBand();
      page.Bands.Add(masterDataBand);
      masterDataBand.CreateUniqueName();
      masterDataBand.DataSource = report.GetDataSource("Categories");
      masterDataBand.Height = Units.Centimeters * 0.5f;

      // create category name text
      TextObject categoryText = new TextObject();
      categoryText.Parent = masterDataBand;
      categoryText.CreateUniqueName();
      categoryText.Bounds = new RectangleF(0, 0, Units.Centimeters * 5, Units.Centimeters * 0.5f);
      categoryText.Font = new Font("Arial", 10, FontStyle.Bold);
      categoryText.Text = "[Categories.CategoryName]";

      // create detail data band
      DataBand detailDataBand = new DataBand();
      masterDataBand.Bands.Add(detailDataBand);
      detailDataBand.CreateUniqueName();
      detailDataBand.DataSource = report.GetDataSource("Products");
      detailDataBand.Height = Units.Centimeters * 0.5f;
      // set sort by product name
      detailDataBand.Sort.Add(new Sort("[Products.ProductName]"));

      // create product name text
      TextObject productText = new TextObject();
      productText.Parent = detailDataBand;
      productText.CreateUniqueName();
      productText.Bounds = new RectangleF(Units.Centimeters * 1, 0, Units.Centimeters * 10, Units.Centimeters * 0.5f);
      productText.Text = "[Products.ProductName]";

      // run report designer
      report.Design();
    }

    private void btnGroup_Click(object sender, EventArgs e)
    {
      Report report = new Report();

      // load nwind database
      DataSet dataSet = new DataSet();
      dataSet.ReadXml(GetReportsFolder() + "nwind.xml");

      // register all data tables and relations
      report.RegisterData(dataSet);

      // enable the "Products" table to use it in the report
      report.GetDataSource("Products").Enabled = true;

      // add report page
      ReportPage page = new ReportPage();
      report.Pages.Add(page);
      // always give names to objects you create. You can use CreateUniqueName method to do this;
      // call it after the object is added to a report.
      page.CreateUniqueName();

      // create group header
      GroupHeaderBand groupHeaderBand = new GroupHeaderBand();
      page.Bands.Add(groupHeaderBand);
      groupHeaderBand.Height = Units.Centimeters * 1;
      groupHeaderBand.Condition = "[Products.ProductName].Substring(0,1)";
      groupHeaderBand.SortOrder = FastReport.SortOrder.Ascending;
      
      // create group text
      TextObject groupText = new TextObject();
      groupText.Parent = groupHeaderBand;
      groupText.CreateUniqueName();
      groupText.Bounds = new RectangleF(0, 0, Units.Centimeters * 10, Units.Centimeters * 1);
      groupText.Font = new Font("Arial", 14, FontStyle.Bold);
      groupText.Text = "[[Products.ProductName].Substring(0,1)]";
      groupText.VertAlign = VertAlign.Center;
      groupText.Fill = new LinearGradientFill(Color.OldLace, Color.Moccasin, 90, 0.5f, 1);
      
      // create data band
      DataBand dataBand = new DataBand();
      groupHeaderBand.Data = dataBand;
      dataBand.CreateUniqueName();
      dataBand.DataSource = report.GetDataSource("Products");
      dataBand.Height = Units.Centimeters * 0.5f;

      // create product name text
      TextObject productText = new TextObject();
      productText.Parent = dataBand;
      productText.CreateUniqueName();
      productText.Bounds = new RectangleF(0, 0, Units.Centimeters * 10, Units.Centimeters * 0.5f);
      productText.Text = "[Products.ProductName]";

      // create group footer
      groupHeaderBand.GroupFooter = new GroupFooterBand();
      groupHeaderBand.GroupFooter.CreateUniqueName();
      groupHeaderBand.GroupFooter.Height = Units.Centimeters * 1;
      
      // create total
      Total groupTotal = new Total();
      groupTotal.Name = "TotalRows";
      groupTotal.TotalType = TotalType.Count;
      groupTotal.Evaluator = dataBand;
      groupTotal.PrintOn = groupHeaderBand.GroupFooter;
      report.Dictionary.Totals.Add(groupTotal);
      
      // show total in the group footer
      TextObject totalText = new TextObject();
      totalText.Parent = groupHeaderBand.GroupFooter;
      totalText.CreateUniqueName();
      totalText.Bounds = new RectangleF(0, 0, Units.Centimeters * 10, Units.Centimeters * 0.5f);
      totalText.Text = "Rows: [TotalRows]";
      totalText.HorzAlign = HorzAlign.Right;
      totalText.Border.Lines = BorderLines.Top;

      // run report designer
      report.Design();
    }

    private void btnNestedGroups_Click(object sender, EventArgs e)
    {
      Report report = new Report();

      // load nwind database
      DataSet dataSet = new DataSet();
      dataSet.ReadXml(GetReportsFolder() + "nwind.xml");

      // register all data tables and relations
      report.RegisterData(dataSet);

      // enable the "Products" table to use it in the report
      report.GetDataSource("Products").Enabled = true;

      // add report page
      ReportPage page = new ReportPage();
      report.Pages.Add(page);
      // always give names to objects you create. You can use CreateUniqueName method to do this;
      // call it after the object is added to a report.
      page.CreateUniqueName();

      // create group header
      GroupHeaderBand groupHeaderBand = new GroupHeaderBand();
      page.Bands.Add(groupHeaderBand);
      groupHeaderBand.Height = Units.Centimeters * 1;
      groupHeaderBand.Condition = "[Products.ProductName].Substring(0,1)";

      // create group text
      TextObject groupText = new TextObject();
      groupText.Parent = groupHeaderBand;
      groupText.CreateUniqueName();
      groupText.Bounds = new RectangleF(0, 0, Units.Centimeters * 10, Units.Centimeters * 1);
      groupText.Font = new Font("Arial", 14, FontStyle.Bold);
      groupText.Text = "[[Products.ProductName].Substring(0,1)]";
      groupText.VertAlign = VertAlign.Center;
      groupText.Fill = new LinearGradientFill(Color.OldLace, Color.Moccasin, 90, 0.5f, 1);

      // create nested group header
      GroupHeaderBand nestedGroupBand = new GroupHeaderBand();
      groupHeaderBand.NestedGroup = nestedGroupBand;
      nestedGroupBand.Height = Units.Centimeters * 0.5f;
      nestedGroupBand.Condition = "[Products.ProductName].Substring(0,2)";

      // create nested group text
      TextObject nestedText = new TextObject();
      nestedText.Parent = nestedGroupBand;
      nestedText.CreateUniqueName();
      nestedText.Bounds = new RectangleF(0, 0, Units.Centimeters * 10, Units.Centimeters * 0.5f);
      nestedText.Font = new Font("Arial", 10, FontStyle.Bold);
      nestedText.Text = "[[Products.ProductName].Substring(0,2)]";

      // create data band
      DataBand dataBand = new DataBand();
      // connect it to inner group
      nestedGroupBand.Data = dataBand;
      dataBand.CreateUniqueName();
      dataBand.DataSource = report.GetDataSource("Products");
      dataBand.Height = Units.Centimeters * 0.5f;
      // set sort by product name
      dataBand.Sort.Add(new Sort("[Products.ProductName]"));

      // create product name text
      TextObject productText = new TextObject();
      productText.Parent = dataBand;
      productText.CreateUniqueName();
      productText.Bounds = new RectangleF(Units.Centimeters * 0.5f, 0, Units.Centimeters * 9.5f, Units.Centimeters * 0.5f);
      productText.Text = "[Products.ProductName]";

      // create group footer for outer group
      groupHeaderBand.GroupFooter = new GroupFooterBand();
      groupHeaderBand.GroupFooter.CreateUniqueName();
      groupHeaderBand.GroupFooter.Height = Units.Centimeters * 1;

      // create total
      Total groupTotal = new Total();
      groupTotal.Name = "TotalRows";
      groupTotal.TotalType = TotalType.Count;
      groupTotal.Evaluator = dataBand;
      groupTotal.PrintOn = groupHeaderBand.GroupFooter;
      report.Dictionary.Totals.Add(groupTotal);

      // show total in the group footer
      TextObject totalText = new TextObject();
      totalText.Parent = groupHeaderBand.GroupFooter;
      totalText.CreateUniqueName();
      totalText.Bounds = new RectangleF(0, 0, Units.Centimeters * 10, Units.Centimeters * 0.5f);
      totalText.Text = "Rows: [TotalRows]";
      totalText.HorzAlign = HorzAlign.Right;
      totalText.Border.Lines = BorderLines.Top;

      // run report designer
      report.Design();
    }

    private void btnSubreport_Click(object sender, EventArgs e)
    {
      Report report = new Report();

      // load nwind database
      DataSet dataSet = new DataSet();
      dataSet.ReadXml(GetReportsFolder() + "nwind.xml");

      // register all data tables and relations
      report.RegisterData(dataSet);

      // enable the "Products" and "Suppliers" tables to use it in the report
      report.GetDataSource("Products").Enabled = true;
      report.GetDataSource("Suppliers").Enabled = true;

      // add report page
      ReportPage page = new ReportPage();
      report.Pages.Add(page);
      // always give names to objects you create. You can use CreateUniqueName method to do this;
      // call it after the object is added to a report.
      page.CreateUniqueName();

      // create title band
      page.ReportTitle = new ReportTitleBand();
      // native FastReport unit is screen pixel, use conversion 
      page.ReportTitle.Height = Units.Centimeters * 1;
      page.ReportTitle.CreateUniqueName();

      // create two title text objects
      TextObject titleText1 = new TextObject();
      titleText1.Parent = page.ReportTitle;
      titleText1.CreateUniqueName();
      titleText1.Bounds = new RectangleF(0, 0, Units.Centimeters * 8, Units.Centimeters * 1);
      titleText1.Font = new Font("Arial", 14, FontStyle.Bold);
      titleText1.Text = "Products";
      titleText1.HorzAlign = HorzAlign.Center;

      TextObject titleText2 = new TextObject();
      titleText2.Parent = page.ReportTitle;
      titleText2.CreateUniqueName();
      titleText2.Bounds = new RectangleF(Units.Centimeters * 9, 0, Units.Centimeters * 8, Units.Centimeters * 1);
      titleText2.Font = new Font("Arial", 14, FontStyle.Bold);
      titleText2.Text = "Suppliers";
      titleText2.HorzAlign = HorzAlign.Center;

      // create report title's child band that will contain subreports
      ChildBand childBand = new ChildBand();
      page.ReportTitle.Child = childBand;
      childBand.CreateUniqueName();
      childBand.Height = Units.Centimeters * 0.5f;

      // create the first subreport
      SubreportObject subreport1 = new SubreportObject();
      subreport1.Parent = childBand;
      subreport1.CreateUniqueName();
      subreport1.Bounds = new RectangleF(0, 0, Units.Centimeters * 8, Units.Centimeters * 0.5f);
      
      // create subreport's page
      ReportPage subreportPage1 = new ReportPage();
      report.Pages.Add(subreportPage1);
      // connect subreport to page
      subreport1.ReportPage = subreportPage1;

      // create report on the subreport's page
      DataBand dataBand = new DataBand();
      subreportPage1.Bands.Add(dataBand);
      dataBand.CreateUniqueName();
      dataBand.DataSource = report.GetDataSource("Products");
      dataBand.Height = Units.Centimeters * 0.5f;

      TextObject productText = new TextObject();
      productText.Parent = dataBand;
      productText.CreateUniqueName();
      productText.Bounds = new RectangleF(0, 0, Units.Centimeters * 8, Units.Centimeters * 0.5f);
      productText.Text = "[Products.ProductName]";


      // create the second subreport
      SubreportObject subreport2 = new SubreportObject();
      subreport2.Parent = childBand;
      subreport2.CreateUniqueName();
      subreport2.Bounds = new RectangleF(Units.Centimeters * 9, 0, Units.Centimeters * 8, Units.Centimeters * 0.5f);

      // create subreport's page
      ReportPage subreportPage2 = new ReportPage();
      report.Pages.Add(subreportPage2);
      // connect subreport to page
      subreport2.ReportPage = subreportPage2;

      // create report on the subreport's page
      DataBand dataBand2 = new DataBand();
      subreportPage2.Bands.Add(dataBand2);
      dataBand2.CreateUniqueName();
      dataBand2.DataSource = report.GetDataSource("Suppliers");
      dataBand2.Height = Units.Centimeters * 0.5f;

      // create supplier name text
      TextObject supplierText = new TextObject();
      supplierText.Parent = dataBand2;
      supplierText.CreateUniqueName();
      supplierText.Bounds = new RectangleF(0, 0, Units.Centimeters * 8, Units.Centimeters * 0.5f);
      supplierText.Text = "[Suppliers.CompanyName]";

      // run report designer
      report.Design();
    }
  }
}