using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using FastReport;
using FastReport.Utils;
using FastReport.Web;
using System.Collections.Generic;
using System.IO;
using FastReport.Data;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static bool FConfigLoaded;
        private static string FReportsPath;
        private static string FDataBasePath;

        private void GetReports(string path)
        {
            string reportslist = path + "reports.xml";
            if (File.Exists(reportslist))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(reportslist);
                foreach (XmlItem folder in xml.Root.Items)
                    if (folder.GetProp("WebDemo") != "false")
                    {
                        MenuItem FolderNode = new MenuItem(folder.GetProp("Name"));
                        FolderNode.Selectable = false;
                        LeftMenu.Items.Add(FolderNode);
                        foreach (XmlItem report in folder.Items)
                            if (report.GetProp("WebDemo") != "false")
                            {
                                MenuItem ReportNode = new MenuItem(Path.GetFileNameWithoutExtension(report.GetProp("File")));
                                ReportNode.Value = path + report.GetProp("File");
                                FolderNode.ChildItems.Add(ReportNode);
                            }
                    }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Version.Text = "ver." + Config.Version;
                if (WebReport1.ReportFile == String.Empty)
                {
                    if (LeftMenu.Items.Count > 0)
                    {
                        MenuItem item = LeftMenu.Items[0].ChildItems[0];
                        item.Selected = true;
                        WebReport1.ReportFile = item.Value;
                        WebReport1.Prepare();
                    }
                }
            }

        }
        protected void TopMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            //MultiViewBody.ActiveViewIndex = Convert.ToInt16(e.Item.Value) - 1;
        }

        protected void LeftMenu_Init(object sender, EventArgs e)
        {
            LeftMenu.Items.Clear();
            GetReports(GetReportsPath());
        }

        protected void LeftMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            WebReport1.ReportFile = e.Item.Value;
            WebReport1.Prepare();
        }

        protected void WebReport1_StartReport(object sender, EventArgs e)
        {
            Report FReport = (sender as WebReport).Report;
            //Label1.Text = FReport.ReportInfo.Description;
            //Label1.Style.Add("padding", "5px");
            RegisterData(FReport);
        }

        private void LoadConfig()
        {
            if (!FConfigLoaded)
            {
                using (XmlDocument xml = new XmlDocument())
                {
                    xml.Load(Config.ApplicationFolder + "config.xml");
                    foreach (XmlItem item in xml.Root.Items)
                        if (item.Name == "Config")
                            foreach (XmlItem configitem in item.Items)
                                if (configitem.Name == "Reports")
                                    FReportsPath = configitem.GetProp("Path");
                                else if (configitem.Name == "Database")
                                    FDataBasePath = configitem.GetProp("Path");
                }
                if (FDataBasePath != String.Empty)
                    FConfigLoaded = true;
            }
        }

        private string GetReportsPath()
        {
            LoadConfig();
            return Config.ApplicationFolder + FReportsPath;
            //return Request.PhysicalApplicationPath + "App_Data\\";
        }

        private string GetDataBasePath()
        {
            LoadConfig();
            return Config.ApplicationFolder + FDataBasePath;
            //return Request.PhysicalApplicationPath + "App_Data\\nwind.xml";
        }

        private void RegisterData(Report FReport)
        {
            DataSet FDataSet = new DataSet();
            FDataSet.ReadXml(GetDataBasePath());

            FReport.RegisterData(FDataSet, "NorthWind");

            List<Category> list = new List<Category>();
            Category category = new Category("Beverages", "Soft drinks, coffees, teas, beers");
            category.Products.Add(new Product("Chai", 18m));
            category.Products.Add(new Product("Chang", 19m));
            category.Products.Add(new Product("Ipoh coffee", 46m));
            list.Add(category);

            category = new Category("Confections", "Desserts, candies, and sweet breads");
            category.Products.Add(new Product("Chocolade", 12.75m));
            category.Products.Add(new Product("Scottish Longbreads", 12.5m));
            category.Products.Add(new Product("Tarte au sucre", 49.3m));
            list.Add(category);

            category = new Category("Seafood", "Seaweed and fish");
            category.Products.Add(new Product("Boston Crab Meat", 18.4m));
            category.Products.Add(new Product("Red caviar", 15m));
            list.Add(category);

            FReport.RegisterData(list, "Categories BusinessObject", BOConverterFlags.AllowFields, 3);
        }
    }

    public class Category
    {
        public string Name;
        public string Description;
        public List<Product> Products;

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
            Products = new List<Product>();
        }
    }

    public class Product
    {
        public string Name;
        public decimal UnitPrice;

        public Product(string name, decimal unitPrice)
        {
            Name = name;
            UnitPrice = unitPrice;
        }
    }
}