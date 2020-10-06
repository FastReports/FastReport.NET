using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FastReport;
using FastReport.Table;

namespace TableObjectFromCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (Report report = new Report())
            {
                report.Load("report.frx");
                TableObject table = report.FindObject("Table1") as TableObject;
                if (table != null)
                {
                    for(int i = 0; i < 5; i++)
                        for(int j = 0; j < 5; j++)
                            table[j, i].Text = (5 * i + j + 1).ToString();
                    if (report.Prepare())
                        report.ShowPrepared();
                }
                else
                    MessageBox.Show("Table1 not found in a report!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Report report = new Report())
            {
                ReportPage page = new ReportPage();
                page.Name = "Page1";
                report.Pages.Add(page);
                DataBand dataBand = new DataBand();
                dataBand.Name = "DataBand";
                page.Bands.Add(dataBand);
                TableObject table = new TableObject();
                table.Name = "Table1";                
                table.RowCount = 10;
                table.ColumnCount = 10;
                for (int i = 0; i < 10; i++)
                    for (int j = 0; j < 10; j++)
                    {
                        table[j, i].Text = (10 * i + j + 1).ToString();
                        table[j, i].Border.Lines = BorderLines.All;
                    }
                dataBand.Objects.Add(table);
                if (report.Prepare())
                    report.ShowPrepared();
            }

        }
    }
}
