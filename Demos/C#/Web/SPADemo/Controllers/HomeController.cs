using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Text;
using System.IO;
using FastReport;
using FastReport.Web;
using FastReport.Utils;
using FastReport.Export.Pdf;
using System.Web.UI.WebControls;
using FastReport.Export.Html;

namespace MvcRazor.Controllers
{
    public class HomeController : Controller
    {
        private WebReport webReport = new WebReport();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Report()
        {
            SetReport();
            webReport.Width = 780;// Unit.Percentage(100);
            webReport.Height = 800; // Unit.Percentage(100); 
            webReport.ToolbarIconsStyle = ToolbarIconsStyle.Black;
            webReport.LocalizationFile = "~/Localization/German.frl";
            webReport.ToolbarStyle = ToolbarStyle.Large;
            webReport.SinglePage = true;
            ViewBag.WebReport = webReport;
            return View();
        }

        [HttpPost]
        public ActionResult SaveDesignedReport(string reportID, string reportUUID)
        {
            ViewBag.Message = String.Format("Confirmed {0} {1}", reportID, reportUUID);
            if (reportID == "DesignReport")
            {
                // do something with designed report, for example
                Stream reportForSave = Request.InputStream;
                string pathToSave = Server.MapPath("~/App_Data/DesignedReports/test.frx");
                using (FileStream file = new FileStream(pathToSave, FileMode.CreateNew))
                {
                    reportForSave.CopyTo(file);
                }
            }
            return View();
        }

        public ActionResult Designer()
        {
            SetReport();
            webReport.Width = Unit.Percentage(100);
            webReport.Height = Unit.Percentage(100); 
            webReport.ToolbarIconsStyle = ToolbarIconsStyle.Black;
            webReport.LocalizationFile = "~/Localization/German.frl";
            webReport.DesignerLocale = "de";
            webReport.DesignReport = true;
            ViewBag.WebReport = webReport;
            return View();
        }

        private void SetReport()
        {
            string report_path = GetReportPath();

            //webReport.LocalizationFile = "~/Localization/French.frl";

            System.Data.DataSet dataSet = new System.Data.DataSet();
            dataSet.ReadXml(report_path + "nwind.xml");
            webReport.Report.RegisterData(dataSet, "NorthWind");
            webReport.Report.Load(report_path + "Simple List.frx");
            webReport.CurrentTab.Name = "Simple List";
            
            // tab 2
            Report report2 = new Report();
            report2.RegisterData(dataSet, "NorthWind");
            report2.Load(report_path + "Labels.frx");
            webReport.AddTab(report2, "Labels");
            // tab 3
            Report report3 = new Report();
            report3.RegisterData(dataSet, "NorthWind");
            report3.Load(report_path + "Master-Detail.frx");
            webReport.AddTab(report3, "Master-Detail");
            webReport.DesignerPath = "WebReportDesigner/index.html";
            //webReport.DesignReport = true;
        }

        public void GetFile()
        {
            webReport.ExportPdf();
        }

        public void GetPrint()
        {
            SetReport();
            webReport.Prepare();
            webReport.PrintHtml(null);
        }

        private string GetReportPath()
        {
            return this.Server.MapPath("~/App_Data/"); 
        }
    }
}
