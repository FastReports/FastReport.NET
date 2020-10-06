using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastReport;

namespace DataFromArray
{
  public partial class Form1 : Form
  {
    private int[] FArray;
    
    public Form1()
    {
      InitializeComponent();
      CreateArray();
    }

    private void CreateArray()
    {
      FArray = new int[10];
      for (int i = 0; i < 10; i++)
      {
        FArray[i] = i + 1;
      }
    }

    private void btnCreateNew_Click(object sender, EventArgs e)
    {
      // create report instance
      Report report = new Report();

      // register the array
      report.RegisterData(FArray, "Array");

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

      // register the array
      report.RegisterData(FArray, "Array");

      // run the report
      report.Show();

      // free resources used by report
      report.Dispose();
    }
  }
}