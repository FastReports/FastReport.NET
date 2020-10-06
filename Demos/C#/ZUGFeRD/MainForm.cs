using FastReport;
using FastReport.Export.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZUGFeRD
{
    public partial class MainForm : Form
    {
        private string appPath;

        public MainForm()
        {            
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Title = "Select ZUGFeRD XML";
                openDialog.InitialDirectory = appPath;
                openDialog.Filter = "ZUGFeRD invoice XML (*.xml)|*.xml|All files (*.*)|*.*";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    tbZUGFeRDPath.Text = openDialog.FileName;
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            appPath = Path.GetDirectoryName(Application.ExecutablePath);
        }

        private void btnCreatePDF_Click(object sender, EventArgs e)
        {
            string xmlFile = File.Exists(tbZUGFeRDPath.Text) ? tbZUGFeRDPath.Text : Path.Combine(appPath, tbZUGFeRDPath.Text);
            if (File.Exists(xmlFile))
            {
                string reportFile = Path.Combine(appPath, "Invoice.frx");
                if (File.Exists(reportFile))
                {
                    using (SaveFileDialog saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Title = "Select path to save PDF file with embedded ZUGFeRD";
                        saveDialog.Filter = "PDF/A-3b file (*.pdf)|*.pdf|All files (*.*)|*.*";
                        saveDialog.FileName = "Invoice-With-ZUGFeRD.pdf";
                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            using (Report report = new Report())
                            using (PDFExport pdf = new PDFExport())
                            using (FileStream file = new FileStream(xmlFile, FileMode.Open, FileAccess.Read))
                            {
                                report.Load(reportFile);
                                report.Prepare();
                                pdf.PdfCompliance = PDFExport.PdfStandard.PdfA_3b;
                                pdf.OpenAfterExport = true;
                                pdf.AddEmbeddedXML("ZUGFeRD-invoice.xml", "ZUGFeRD invoice", DateTime.Now, file);
                                report.Export(pdf, saveDialog.FileName);
                            }
                        }
                    }
                }
                else
                    MessageBox.Show("Report file does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("XML file does not exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
