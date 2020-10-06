using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FastReport;

namespace CustomDesigner
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      // create a new empty report and attach it to the designer
      Report report = new Report();
      designerControl1.Report = report;
      
      // restore the design layout. Without this code, the designer tool windows will be unavailable
      designerControl1.RefreshLayout();
    }

    private void designerControl1_UIStateChanged(object sender, EventArgs e)
    {
      // update Enabled state of our buttons
      btnSave.Enabled = designerControl1.cmdSave.Enabled;
      btnUndo.Enabled = designerControl1.cmdUndo.Enabled;
      btnRedo.Enabled = designerControl1.cmdRedo.Enabled;
    }

    private void btnNew_Click(object sender, EventArgs e)
    {
      designerControl1.cmdNew.Invoke();
    }

    private void btnOpen_Click(object sender, EventArgs e)
    {
      designerControl1.cmdOpen.Invoke();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
      designerControl1.cmdSave.Invoke();
    }

    private void btnUndo_Click(object sender, EventArgs e)
    {
      designerControl1.cmdUndo.Invoke();
    }

    private void btnRedo_Click(object sender, EventArgs e)
    {
      designerControl1.cmdRedo.Invoke();
    }
  }
}