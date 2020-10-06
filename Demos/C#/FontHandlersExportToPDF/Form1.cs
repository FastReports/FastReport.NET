using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using FastReport;
using FastReport.Export.Pdf;
using FastReport.Fonts;
using FastReport.Utils;

namespace ExportToPDF
{
    public partial class Form1 : Form
    {
        #region Font list data base
        private DataSet fontList;
        private DataTable fontTable;
        #endregion

        public Form1()
        {
            InitializeComponent();
            CreateFontList();
        }

        private void CreateFontList()
        {
            try
            {
				fontList = new DataSet();
				if (File.Exists ("font.list.xml")) 
				{
					fontList.ReadXml("font.list.xml");
					fontTable = fontList.Tables["FontList"];
					fontTable.PrimaryKey = new DataColumn[] { fontTable.Columns["FontID"] };
				}
				else
				{
					fontTable = new DataTable();
					fontTable.TableName = "FontList";
					fontList.Tables.Add(fontTable);

					fontTable.Columns.Add("FontID", typeof(string));
					fontTable.Columns.Add("FontPath", typeof(string));
					fontTable.PrimaryKey = new DataColumn[] { fontTable.Columns["FontID"] };
				}
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void LoadFontStream(Font font, out System.IO.Stream stream)
        {
            if (font.Bold)
                stream = File.OpenRead(@"C:\Windows\Fonts\arialbd.ttf");
            else
                stream = File.OpenRead(@"C:\Windows\Fonts\arial.ttf");
        }


		private void LoadFontListXml()
		{
			if(!File.Exists("font.list.xml"))
				throw new Exception("File font.list.xml not found.");

			fontList.ReadXml("font.list.xml");
			fontTable.PrimaryKey = new DataColumn[] { fontTable.Columns["FontID"] };
		}

		StringBuilder errors = new StringBuilder ();

		private void GetFontPath(string font_id, out string path)
        {
            if(fontTable.Rows.Count == 0)
            {
				LoadFontListXml ();
            }
            DataRow Drw = fontTable.Rows.Find(font_id);

			if (Drw == null) 
			{
//				throw new Exception("Font '" + font_id + "' not found.");
				errors.AppendLine(font_id);
				Drw = fontTable.Rows [0];
			}

            path = Drw["FontPath"] as string;

        }
        private void SetFontPath(string font_id, string path)
        {
			if(fontTable.Rows.Find(font_id) == null)
            	fontTable.Rows.Add(font_id, path);
        }

        private Report CreateReport()
        {
            const int ROW_HIGHT = 20;
            Report report = new Report();

            ReportPage page = new ReportPage();
            page.Name = "FontList";
            report.Pages.Add(page);
            ReportTitleBand headerBand = new ReportTitleBand();
            headerBand.Name = "Title";
            headerBand.Height = 40;
            page.ReportTitle = headerBand;

            TextObject header = new FastReport.TextObject();
            header.Name = "HeaderMemo";
            header.Width = 300;
            header.Height = 30;
            header.Text = "List of enumerated fonts";
            header.Font = new Font(FontFamily.GenericSansSerif, 18);
            headerBand.Objects.Add(header);

            DataBand dataBand = new DataBand();
            dataBand.Name = "DataBand";
            dataBand.Top = 30;
            dataBand.Height = ROW_HIGHT;
            page.Bands.Add(dataBand);
            TextObject index = new FastReport.TextObject();
            index.Name = "Index";
            index.Text = "[Row#]";
            index.Height = ROW_HIGHT;
            index.Width = 50;
            dataBand.Objects.Add(index);
            TextObject font_id = new FastReport.TextObject();
            font_id.Name = "FontOD";
            font_id.Text = "[FontList1.FontID]";
            font_id.Height = ROW_HIGHT;
            font_id.Width = 300;
            font_id.Left = 50;
            dataBand.Objects.Add(font_id);
            TextObject font_path = new FastReport.TextObject();
            font_path.Name = "FilePath";
            font_path.Text = "[FontList1.FontPath]";
            font_path.Left = 350;
            font_path.Width = 600;
            font_path.Height = ROW_HIGHT;
            dataBand.Objects.Add(font_path);

            report.RegisterData(fontList);
            FastReport.Data.DataSourceBase dsb = report.GetDataSource("FontList1");
            dsb.Enabled = true;
            dataBand.DataSource = dsb;

			report.ReportInfo.Name = "font.list";

			if(WYSIWYG.Checked)
			{
                font_id.AfterData += Font_id_AfterData;
			}
            return report;
        }

        private void Font_id_AfterData(object sender, EventArgs e)
        {
            TextObject font_id = sender as TextObject;
            string font = font_id.Text;
            FontStyle style = FontStyle.Regular;
            if (font.EndsWith("-I"))
            {
                style = FontStyle.Italic;
                font = font.Remove(font.Length - 2);
            }
            if (font.EndsWith("-B"))
            {
                style |= FontStyle.Bold;
                font = font.Remove(font.Length - 2);
            }
            font_id.Font = new Font(font, 10.0f, style);
        }

        private void btnExportWithDialog_Click(object sender, EventArgs e)
        {
            TrueTypeCollection.OnGetFontPath += new GetFontPathHandler(GetFontPath);
            Report report = CreateReport();
            report.Design();
            report.Dispose();
            TrueTypeCollection.OnGetFontPath -= GetFontPath;
			if (errors.Length > 0) 
			{
				System.IO.StreamWriter file = new StreamWriter ("Broken_fonts.txt");
				file.WriteLine (errors.ToString ());
				file.Close ();
			}
        }

        private void btnSilentExport_Click(object sender, EventArgs e)
        {
#if USER_MANAGE_FONTS
            TrueTypeCollection.OnRequestFontData += new RequestFontHandler(LoadFontStream);
#elif true
            TrueTypeCollection.OnGetFontPath += new GetFontPathHandler(GetFontPath);
#endif

            // create report instance
            Report report = new Report();

            // load the existing report
            report.Load(@"../../report.frx");

            // register the dataset
            report.RegisterData(fontList);

            // run the report
            report.Prepare();

            // create export instance
            PDFExport export = new PDFExport();
            export.AllowOpenAfter = true;
            export.EmbeddingFonts = true;
            export.OpenAfterExport = true;

            // export the report
            report.Export(export, "result.pdf");

            TrueTypeCollection.OnGetFontPath -=  GetFontPath;

            // free resources used by report
            report.Dispose();
        }

        private void EnumerateFonts_Click(object sender, EventArgs e)
        {
            TrueTypeCollection.OnSetFontPath += new SetFontPathHandler(SetFontPath);
            Config.FontCollection.EnumerateFonts();
            fontList.WriteXml("font.list.xml");
			TrueTypeCollection.OnSetFontPath -= SetFontPath;
        }
    }
}