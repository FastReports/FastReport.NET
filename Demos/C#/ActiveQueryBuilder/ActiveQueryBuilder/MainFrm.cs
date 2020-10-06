using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport.Utils;
using FastReport.Forms;
using FastReport.Design;
using FastReport;


namespace WindowsFormsApp2
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            new ActiveQueryAssemblyInitializer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            DataSet ds = new DataSet();
            ds.ReadXml("..\\..\\..\\..\\..\\..\\Demos\\Reports\\nwind.xml");
            report.RegisterData(ds, "NorthWind");
            report.Load("..\\..\\..\\..\\..\\..\\Demos\\Reports\\Image.frx");
            report.Design();
        }
    }
}
