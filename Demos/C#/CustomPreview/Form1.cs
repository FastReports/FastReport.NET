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
using FastReport.Export;

namespace CustomPreview
{
  public partial class Form1 : Form
  {
    private Report FReport;
    private DataSet FDataSet;

    public Form1()
    {
      InitializeComponent();
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

    private void Form1_Load(object sender, EventArgs e)
    {
      FReport = new Report();
      FReport.Preview = preview1;
      
      FDataSet = new DataSet();
      FDataSet.ReadXml(GetReportsFolder() + "nwind.xml");
      
      lbReports.Items.Add("Simple List.frx");
      lbReports.Items.Add("Groups.frx");
      lbReports.Items.Add("Master-Detail.frx");
      lbReports.Items.Add("Labels.frx");
      lbReports.Items.Add("Subreport.frx");
    }

    private void lbReports_SelectedIndexChanged(object sender, EventArgs e)
    {
      string reportName = GetReportsFolder() + (string)lbReports.SelectedItem;

      FReport.Load(reportName);
      FReport.RegisterData(FDataSet, "NorthWind");
      FReport.Prepare();
      FReport.ShowPrepared();
    }

    private void btnPrint_Click(object sender, EventArgs e)
    {
      preview1.Print();
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
      // build export menu
      exportMenu.Items.Clear();
      List<ObjectInfo> list = new List<ObjectInfo>();
      RegisteredObjects.Objects.EnumItems(list);

      ToolStripMenuItem saveNative = new ToolStripMenuItem("Save to .fpx file...");
      saveNative.Click += new EventHandler(item_Click);
      exportMenu.Items.Add(saveNative);

      foreach (ObjectInfo info in list)
      {
        if (info.Object != null && info.Object.IsSubclassOf(typeof(ExportBase)))
        {
          ToolStripMenuItem item = new ToolStripMenuItem(Res.TryGet(info.Text) + "...");
          item.Tag = info;
          item.Click += new EventHandler(item_Click);
          if (info.ImageIndex != -1)
            item.Image = Res.GetImage(info.ImageIndex);
          exportMenu.Items.Add(item);
        }
      }
      
      exportMenu.Show(btnExport, new Point(0, btnExport.Height));
    }

    private void item_Click(object sender, EventArgs e)
    {
      ObjectInfo info = (sender as ToolStripMenuItem).Tag as ObjectInfo;
      if (info == null)
      {
        // we clicked "Save to .fpx" item
        preview1.Save();
      }  
      else
      {
        ExportBase export = Activator.CreateInstance(info.Object) as ExportBase;
        export.CurPage = preview1.PageNo;
        export.Export(preview1.Report);
      }
    }

    private void btnZoomOut_Click(object sender, EventArgs e)
    {
      preview1.ZoomOut();
    }

    private void btnZoomIn_Click(object sender, EventArgs e)
    {
      preview1.ZoomIn();
    }

    private void btnFirst_Click(object sender, EventArgs e)
    {
      preview1.First();
    }

    private void btnPrior_Click(object sender, EventArgs e)
    {
      preview1.Prior();
    }

    private void btnNext_Click(object sender, EventArgs e)
    {
      preview1.Next();
    }

    private void btnLast_Click(object sender, EventArgs e)
    {
      preview1.Last();
    }

    private void tbPageNo_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData == Keys.Enter)
      {
        preview1.PageNo = int.Parse(tbPageNo.Text);
      }
    }

    private void preview1_PageChanged(object sender, EventArgs e)
    {
      tbPageNo.Text = preview1.PageNo.ToString();
    }
  }
}