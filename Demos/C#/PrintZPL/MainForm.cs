using FastReport;
using FastReport.Export.Text;
using FastReport.Export.Zpl;
using System;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PrintZPL
{
    public partial class MainForm : Form
    {
        #region Public Constructors

        public MainForm()
        {
            InitializeComponent();
            cbDensity.SelectedIndex = 1;
            foreach (string printer in PrinterSettings.InstalledPrinters)
                cbPrinters.Items.Add(printer);
            if (cbPrinters.Items.Count > 0)
            {
                btnPrint.Enabled = true;
                cbPrinters.SelectedIndex = 0;
            }
        }

        #endregion Public Constructors

        #region Private Fields

        private string configFileName = "config.xml";
        private Config configuration = new Config();
        private bool isPreparedReport = false;
        private bool preview = false;
        private string reportFileName = String.Empty;
        #endregion Private Fields

        #region Private Methods

        private void btnDesignReport_Click(object sender, EventArgs e)
        {
            if (File.Exists(reportFileName) && !isPreparedReport)
            {
                using (Report report = new Report())
                {
                    report.Load(reportFileName);
                    report.Design();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SaveConfig();
            if (tabControl1.SelectedIndex == 0)               
            {
                // first tab
                if (reportFileName == String.Empty)
                    btnSelectReport_Click(sender, e);
                if (reportFileName != String.Empty)
                {
                    using (Report report = new Report())
                    using (ZplExport zplExport = new ZplExport())
                    {
                        if (isPreparedReport)
                            report.LoadPrepared(reportFileName);
                        else
                        {
                            report.Load(reportFileName);
                            report.Prepare();
                        }

                        switch (cbDensity.SelectedIndex)
                        {
                            case 0:
                                zplExport.Density = ZplExport.ZplDensity.d6_dpmm_152_dpi;
                                break;

                            case 1:
                                zplExport.Density = ZplExport.ZplDensity.d8_dpmm_203_dpi;
                                break;

                            case 2:
                                zplExport.Density = ZplExport.ZplDensity.d12_dpmm_300_dpi;
                                break;

                            case 3:
                                zplExport.Density = ZplExport.ZplDensity.d24_dpmm_600_dpi;
                                break;
                        }

                        zplExport.PrinterInit = tbPrinterInit.Text;
                        zplExport.PrinterFinish = tbPrinterFinish.Text;
                        zplExport.CodePage = tbCodePage.Text;
                        zplExport.PageInit = tbPageInit.Text;
                        zplExport.FontScale = (float)nudFontScale.Value;
                        zplExport.PrinterFont = tbPrinterFont.Text;
                        zplExport.PrintAsBitmap = cbPrintAsBitmap.Checked;

                        using (MemoryStream stream = new MemoryStream())
                        {
                            report.Export(zplExport, stream);
                            stream.Position = 0;
                            byte[] buff = new byte[stream.Length];
                            stream.Read(buff, 0, buff.Length);
                            textEditor.Text = Encoding.UTF8.GetString(buff);
                            if (!preview)
                            {
                                stream.Position = 0;
                                TextExportPrint.PrintStream(cbPrinters.Text, "FastReport", 1, stream);
                            }
                        }
                    }
                }
            }
            else
            // second tab with text
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    byte[] utfTextBuff = Encoding.UTF8.GetBytes(textEditor.Text);
                    stream.Write(utfTextBuff, 0, utfTextBuff.Length);
                    stream.Position = 0;
                    TextExportPrint.PrintStream(cbPrinters.Text, "FastReport", 1, stream);
                }
            }
        }

        #endregion Private Methods

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                openDialog.Filter = "ZPL File (*.zpl)|*.zpl|Text File (*.txt)|*.txt;";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(openDialog.FileName))
                    {
                        textEditor.Text = File.ReadAllText(openDialog.FileName);                        
                    }
                }
            }
        }

        private void btnSelectReport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                openDialog.Filter = "Report File (*.frx)|*.frx|Prepared Report File (*.fpx)|*.fpx;";
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    reportFileName = openDialog.FileName;
                    lblReportName.Text = Path.GetFileName(reportFileName);
                    isPreparedReport = Path.GetExtension(reportFileName) == ".fpx";

                    btnDesignReport.Enabled = !isPreparedReport;
                    btnShowReport.Enabled = true;
                }
            }
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            if (File.Exists(reportFileName))
            {
                if (isPreparedReport)
                {
                    using (Report report = new Report())
                    {
                        report.LoadPrepared(reportFileName);
                        report.ShowPrepared();
                    }
                }
                else
                {
                    using (Report report = new Report())
                    {
                        report.Load(reportFileName);
                        report.Show();
                    }
                }
            }
        }

        private void btnShowZPL_Click(object sender, EventArgs e)
        {
            preview = true;
            btnPrint_Click(sender, e);
            preview = false;
            tabControl1.SelectedIndex = 1;
        }

        private void LoadConfig()
        {
            if (File.Exists(configFileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Config));
                using (FileStream file = new FileStream(configFileName, FileMode.Open))
                {
                    configuration = serializer.Deserialize(file) as Config;
                }

                tbPrinterInit.Text = configuration.PrinterInit;
                tbPrinterFinish.Text = configuration.PrinterFinish;
                tbCodePage.Text = configuration.CodePage;
                tbPageInit.Text = configuration.PageInit;
                nudFontScale.Value = (decimal)configuration.FontScale;
                tbPrinterFont.Text = configuration.PrinterFont;
                cbPrintAsBitmap.Checked = configuration.PrintAsBitmap;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfig();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }

        private void SaveConfig()
        {
            configuration.PrinterInit = tbPrinterInit.Text;
            configuration.PrinterFinish = tbPrinterFinish.Text;
            configuration.CodePage = tbCodePage.Text;
            configuration.PageInit = tbPageInit.Text;
            configuration.FontScale = (float)nudFontScale.Value;
            configuration.PrinterFont = tbPrinterFont.Text;
            configuration.PrintAsBitmap = cbPrintAsBitmap.Checked;

            XmlSerializer serializer = new XmlSerializer(typeof(Config));
            using (FileStream file = new FileStream(configFileName, FileMode.Create))
            {
                serializer.Serialize(file, configuration);
            }
        }
    }
}