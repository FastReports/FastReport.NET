using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CustomOpenSaveDialogs
{
  public partial class SaveDialogForm : Form
  {
    public string ReportName
    {
      get
      {
        return tbReportName.Text;
      }
    }
    
    public SaveDialogForm()
    {
      InitializeComponent();
    }

    private void tbReportName_TextChanged(object sender, EventArgs e)
    {
      btnOK.Enabled = !String.IsNullOrEmpty(ReportName);
    }
  }
}