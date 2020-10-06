using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastReport.Utils;
using FastReport.Design;
using System.IO;
using FastReport;

namespace CustomOpenSaveDialogs
{
  public partial class Form1 : Form
  {
    private DataSet FReportsDs;

    private DataTable ReportsTable
    {
      get { return FReportsDs.Tables[0]; }
    }
    
    public Form1()
    {
      InitializeComponent();
    }

    private void InitializeDatabase()
    {
      FReportsDs = new DataSet();
      FReportsDs.ReadXml(Config.ApplicationFolder + @"..\..\database.xml");
    }

    private void FinalizeDatabase()
    {
      FReportsDs.WriteXml(Config.ApplicationFolder + @"..\..\database.xml", XmlWriteMode.WriteSchema);
    }

    private void WireupDesignerEvents()
    {
      Config.DesignerSettings.CustomOpenDialog += new OpenSaveDialogEventHandler(DesignerSettings_CustomOpenDialog);
      Config.DesignerSettings.CustomOpenReport += new OpenSaveReportEventHandler(DesignerSettings_CustomOpenReport);
      Config.DesignerSettings.CustomSaveDialog += new OpenSaveDialogEventHandler(DesignerSettings_CustomSaveDialog);
      Config.DesignerSettings.CustomSaveReport += new OpenSaveReportEventHandler(DesignerSettings_CustomSaveReport);
    }

    private void DesignReport()
    {
      using (Report report = new Report())
      {
        report.LoadBaseReport += new CustomLoadEventHandler(report_LoadBaseReport);
        report.Design();
      }
    }

    // this event is fired when loading a base part of an inherited report.
    private void report_LoadBaseReport(object sender, CustomLoadEventArgs e)
    {
      OpenReport(e.Report, e.FileName);
    }

    // this event is fired when the user press the "Open file" button
    private void DesignerSettings_CustomOpenDialog(object sender, OpenSaveDialogEventArgs e)
    {
      using (OpenDialogForm form = new OpenDialogForm())
      {
        // pass the reports table to display a list of reports
        form.ReportsTable = ReportsTable;
        
        // show dialog
        e.Cancel = form.ShowDialog() != DialogResult.OK;
        
        // return the selected report in the e.FileName
        e.FileName = form.ReportName;
      }
    }

    // this event is fired when report needs to be loaded
    private void DesignerSettings_CustomOpenReport(object sender, OpenSaveReportEventArgs e)
    {
      OpenReport(e.Report, e.FileName);
    }

    // this event is fired when the user press the "Save file" button to save untitled report,
    // or "Save file as" button
    private void DesignerSettings_CustomSaveDialog(object sender, OpenSaveDialogEventArgs e)
    {
      using (SaveDialogForm form = new SaveDialogForm())
      {
        // show dialog
        e.Cancel = form.ShowDialog() != DialogResult.OK;

        // return the report name in the e.FileName
        e.FileName = form.ReportName;
      }
    }

    // this event is fired when report needs to be saved
    private void DesignerSettings_CustomSaveReport(object sender, OpenSaveReportEventArgs e)
    {
      SaveReport(e.Report, e.FileName);
    }

    private void OpenReport(Report report, string reportName)
    {
      // find the datarow with specified ReportName
      foreach (DataRow row in ReportsTable.Rows)
      {
        if ((string)row["ReportName"] == reportName)
        {
          // load the report from a stream contained in the "ReportStream" datacolumn
          byte[] reportBytes = (byte[])row["ReportStream"];
          using (MemoryStream stream = new MemoryStream(reportBytes))
          {
            report.Load(stream);
          }
          return;
        }
      }
    }

    private void SaveReport(Report report, string reportName)
    {
      // find the datarow with specified ReportName
      DataRow reportRow = null;

      foreach (DataRow row in ReportsTable.Rows)
      {
        if ((string)row["ReportName"] == reportName)
        {
          reportRow = row;
          break;
        }
      }

      // no existing row found, append new one
      if (reportRow == null)
      {
        reportRow = ReportsTable.NewRow();
        ReportsTable.Rows.Add(reportRow);
      }

      // save the report to a stream, then put byte[] array to the datarow
      using (MemoryStream stream = new MemoryStream())
      {
        report.Save(stream);

        reportRow["ReportName"] = reportName;
        reportRow["ReportStream"] = stream.ToArray();
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      InitializeDatabase();
      WireupDesignerEvents();
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      FinalizeDatabase();
    }

    private void btnDesign_Click(object sender, EventArgs e)
    {
      DesignReport();
    }
  }
}