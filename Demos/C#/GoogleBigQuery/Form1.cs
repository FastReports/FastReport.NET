using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FastReport;
using FastReport.Data;
using FastReport.Utils;
using System.IO;

namespace GoogleBigQuery
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisteredObjects.AddConnection(typeof(GoogleBigQueryDataConnection));                        
            using (Report report = new Report())
            {
                string reportFileName = "report.frx";
                if (File.Exists(reportFileName))
                    report.Load(reportFileName);
                report.Design();
            }
        }
    }
}
