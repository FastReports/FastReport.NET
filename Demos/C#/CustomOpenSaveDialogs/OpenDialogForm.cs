using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomOpenSaveDialogs
{
  public partial class OpenDialogForm : Form
  {
    public DataTable ReportsTable
    {
      set
      {
        // fill the listbox with names of reports
        foreach (DataRow row in value.Rows)
        {
          lbxReports.Items.Add(row["ReportName"]);
        }
      }
    }

    public string ReportName
    {
      get
      {
        return (string)lbxReports.SelectedItem;
      }
    }
    
    public OpenDialogForm()
    {
      InitializeComponent();
    }

    private void lbxReports_SelectedIndexChanged(object sender, EventArgs e)
    {
      btnOK.Enabled = !String.IsNullOrEmpty(ReportName);
    }
  }
}