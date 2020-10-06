using FastReport;
using FastReport.Data;
using FastReport.Design;
using FastReport.Utils;
using FastReport.Wizards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {

        private DataSet dataSet;
        private List<Category> businessObject;
        private string reportsFolder;
        private bool lockSelect = false;
        private TreeNode lastNode;
        

        public static void TestMessage()
        {
            MessageBox.Show("Hello from the main application!");
        }

        private void FindReportsFolder()
        {
            reportsFolder = "";
            string thisFolder = Config.ApplicationFolder;

            for (int i = 0; i < 6; i++)
            {
                string dir = Path.Combine(thisFolder, "Reports\\");
                if (Directory.Exists(dir))
                {
                    string rep_dir = Path.GetFullPath(dir);
                    if (File.Exists(Path.Combine(rep_dir, "reports.xml")))
                    {
                        reportsFolder = rep_dir;
                        break;
                    }
                }
                thisFolder += @"..\";
            }

            if (reportsFolder == "")
            {
                thisFolder = Config.ApplicationFolder;
                for (int i = 0; i < 6; i++)
                {
                    string dir = Path.Combine(thisFolder, "Demos\\Reports\\");
                    if (Directory.Exists(dir))
                    {
                        string rep_dir = Path.GetFullPath(dir);
                        if (File.Exists(Path.Combine(rep_dir, "reports.xml")))
                        {
                            reportsFolder = rep_dir;
                            break;
                        }
                    }
                    thisFolder += @"..\";
                }
            }

            if (reportsFolder == "")
                throw new Exception("Could not locate the Reports folder.");

            // set-up locale folder
            if (!Directory.Exists(Res.LocaleFolder))
                Res.LocaleFolder = Config.ApplicationFolder;
            if (!CheckLocalizationFolder(Res.LocaleFolder))
            {
                string locPath = Path.Combine(Res.LocaleFolder, "Localization");
                if (!CheckLocalizationFolder(locPath))
                {
                    locPath = Res.LocaleFolder;
                    for (int i = 0; i < 6; i++)
                    {
                        locPath = Path.Combine(locPath, "..");
                        string testPath = Path.Combine(locPath, "Localization");
                        if (CheckLocalizationFolder(testPath))
                        {
                            Res.LocaleFolder = testPath;
                            break;
                        }
                    }
                }
                else
                    Res.LocaleFolder = locPath;
            }
        }

        private bool CheckLocalizationFolder(string path)
        {
            if (Directory.Exists(path))
            {
                string[] locfiles = Directory.GetFiles(path, "*.frl");
                return locfiles.Length > 0;
            }
            else
                return false;
        }

        private void CreateDataSources()
        {
            try
            {
                dataSet = new DataSet();
                dataSet.ReadXml(reportsFolder + "nwind.xml");

                businessObject = new List<Category>();

                Category category = new Category("Beverages", "Soft drinks, coffees, teas, beers");
                category.Products.Add(new Product("Chai", 18m));
                category.Products.Add(new Product("Chang", 19m));
                category.Products.Add(new Product("Ipoh coffee", 46m));
                businessObject.Add(category);

                category = new Category("Confections", "Desserts, candies, and sweet breads");
                category.Products.Add(new Product("Chocolade", 12.75m));
                category.Products.Add(new Product("Scottish Longbreads", 12.5m));
                category.Products.Add(new Product("Tarte au sucre", 49.3m));
                businessObject.Add(category);

                category = new Category("Seafood", "Seaweed and fish");
                category.Products.Add(new Product("Boston Crab Meat", 18.4m));
                category.Products.Add(new Product("Red caviar", 15m));
                businessObject.Add(category);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void RegisterData(Report FReport)
        {
            FReport.RegisterData(dataSet, "NorthWind");           
            FReport.RegisterData(businessObject, "Categories BusinessObject");

            foreach (DataSourceBase source in FReport.Dictionary.DataSources)
            {
                source.Enabled = true;
            }
        }

        private void PreviewReport(Report FReport)
        {
            RegisterData(FReport);                        
            FReport.Show();
        }

        private void tvReports_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (!lockSelect)
            {
                try
                {
                    lockSelect = true;
                    if (previewControl1.Report != null)
                    {
                        previewControl1.Clear();
                        previewControl1.Report.Dispose();
                    }
                    try
                    {
                        Report FReport = new Report();

                        FReport.Preview = previewControl1;

                        TreeNode selectedNode = tvReports.SelectedNode;
                        if (selectedNode.Tag == null)
                        {
                            lockSelect = false;
                            tvReports.SelectedNode = e.Node.Nodes[0];
                        }
                        else
                        {
                            lastNode = selectedNode;
                            FReport.Load((string)selectedNode.Tag);
                            PreviewReport(FReport);
                        }
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message);
                    }
                }
                finally
                {
                    lockSelect = false;
                }
            }
            else
            {
                if (lastNode != null)
                {
                    tvReports.SelectedNode = lastNode;
                }
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.fast-report.com");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIStyle style = (UIStyle)comboBox1.SelectedIndex;
            Config.UIStyle = style;
            previewControl1.UIStyle = style;
            Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tvReports.Hide();
            lblVersion.Text = "Version " + Config.Version;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(UIStyleUtils.UIStyleNames);
            comboBox1.SelectedIndex = (int)Config.UIStyle;

            FindReportsFolder();
            CreateDataSources();

            Config.ReportSettings.ShowPerformance = true;
            Config.ReportSettings.StartProgress += new EventHandler(ReportSettings_StartProgress);
            Config.ReportSettings.Progress += new ProgressEventHandler(ReportSettings_Progress);
            Config.ReportSettings.FinishProgress += new EventHandler(ReportSettings_FinishProgress);
            FastReport.Map.MapObject.ShapefileFolder = reportsFolder + @"..\Maps";

            tvReports.ImageList = Res.GetImages();

            try
            {
                XmlDocument reports = new XmlDocument();
                reports.Load(reportsFolder + "reports.xml");

                for (int i = 0; i < reports.Root.Count; i++)
                {
                    XmlItem folderItem = reports.Root[i];
                    if (folderItem.GetProp("WinDemo") == "false")
                        continue;

                    string culture = System.Globalization.CultureInfo.CurrentCulture.Name;
                    string text = folderItem.GetProp("Name-" + culture);
                    if (String.IsNullOrEmpty(text))
                        text = folderItem.GetProp("Name");

                    TreeNode folderNode = tvReports.Nodes.Add(text + "     ");
                    folderNode.ImageIndex = 66;
                    folderNode.SelectedImageIndex = folderNode.ImageIndex;
                    folderNode.NodeFont = new Font(Font, FontStyle.Bold);

                    for (int j = 0; j < folderItem.Count; j++)
                    {
                        XmlItem reportItem = folderItem[j];
                        if (reportItem.GetProp("WinDemo") == "false")
                            continue;


                        string file = reportItem.GetProp("File");
                        string fileName = reportItem.GetProp("Name-" + culture);
                        if (String.IsNullOrEmpty(fileName))
                            fileName = Path.GetFileNameWithoutExtension(file);

                        TreeNode fileNode = folderNode.Nodes.Add(fileName);
                        fileNode.ImageIndex = 134;
                        fileNode.SelectedImageIndex = fileNode.ImageIndex;
                        fileNode.Tag = reportsFolder + file;
                    }
                }

                tvReports.ExpandAll();
                tvReports.Show();

                if (tvReports.Nodes.Count > 0)
                    tvReports.SelectedNode = tvReports.Nodes[0];

                if (tvReports.Nodes.Count > 0 && tvReports.Nodes[0].Nodes.Count > 0)
                    tvReports.SelectedNode = tvReports.Nodes[0].Nodes[0];

                tvReports.Focus();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void ReportSettings_StartProgress(object sender, EventArgs e)
        {
        }

        private void ReportSettings_Progress(object sender, ProgressEventArgs e)
        {
            previewControl1.ShowStatus(e.Message);
        }

        private void ReportSettings_FinishProgress(object sender, EventArgs e)
        {
            previewControl1.ShowStatus(String.Empty);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            previewControl1.Report.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                using (Brush b = new SolidBrush(SystemColors.ControlDark))
                {
                    g.FillRectangle(b, ClientRectangle);
                }
                using (Brush b = new SolidBrush(Color.FromArgb(128, Color.White)))
                {
                    g.FillEllipse(b, new Rectangle(-300, -50, ClientRectangle.Width + 600, 220));
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        public Form1()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            InitializeComponent();

            if (Config.RightToLeft)
            {
                RightToLeft = RightToLeft.Yes;
                tvReports.RightToLeftLayout = true;

                // move components from left to right
                label1.Left = ClientSize.Width - label1.Left - label1.Width;
                lblVersion.Left = ClientSize.Width - lblVersion.Left - lblVersion.Width;
                pictureBox1.Left = ClientSize.Width - pictureBox1.Left - pictureBox1.Width;

                // move components from right to left
                linkLabel1.Left = ClientSize.Width - linkLabel1.Left - linkLabel1.Width;
                comboBox1.Left = ClientSize.Width - comboBox1.Left - comboBox1.Width;
                label2.Left = ClientSize.Width - label2.Left - label2.Width;
            }
        }

        public class Category
        {
            private string name;
            private string description;
            private List<Product> products;

            public string Name
            {
                get { return name; }
            }

            public string Description
            {
                get { return description; }
            }

            public List<Product> Products
            {
                get { return products; }
            }

            public Category(string name, string description)
            {
                this.name = name;
                this.description = description;
                products = new List<Product>();
            }
        }

        public class Product
        {
            private string name;
            private decimal unitPrice;

            public string Name
            {
                get { return name; }
            }

            public decimal UnitPrice
            {
                get { return unitPrice; }
            }

            public Product(string name, decimal unitPrice)
            {
                this.name = name;
                this.unitPrice = unitPrice;
            }
        }
    }
}