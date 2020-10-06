using FastReport;
using FastReport.Web;
using System;
using System.IO;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MvcRazor.Controllers
{
    public class HomeController : Controller
    {
        private WebReport webReport = new WebReport();

        public ActionResult Index()
        {
            SetReport();
            webReport.Width = Unit.Percentage(100);
            webReport.Height = Unit.Percentage(100); 
            webReport.ToolbarIconsStyle = ToolbarIconsStyle.Black;
            webReport.SinglePage = true;
            ViewBag.WebReport = webReport;
            return View();
        }

        public ActionResult FitPage()
        {
            SetReport();
            webReport.Width = Unit.Percentage(100);
            webReport.Height = Unit.Percentage(100);
            webReport.ToolbarIconsStyle = ToolbarIconsStyle.Black;
            webReport.ShowToolbar = false;
            webReport.SinglePage = true;
            ViewBag.WebReport = webReport;
            return View();
        }

        public ActionResult Designer()
        {
            webReport = new WebReport();
            webReport.Width = Unit.Percentage(100);
            webReport.Height = Unit.Percentage(100);
            string report_path = GetReportPath();
            System.Data.DataSet dataSet = new System.Data.DataSet();
            dataSet.ReadXml(report_path + "nwind.xml");
            webReport.Report.RegisterData(dataSet, "NorthWind");
            webReport.Report.Load(report_path + "Simple List.frx");            
            webReport.DesignReport = true;
            webReport.DesignScriptCode = false;
            //webReport.Debug = true;
            webReport.DesignerPath = "~/WebReportDesigner/index.html";
            webReport.DesignerSaveCallBack = "~/Home/SaveDesignedReport";
            webReport.ID = "DesignReport";
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
                using (FileStream file = new FileStream(pathToSave, FileMode.Create))
                {
                    reportForSave.CopyTo(file);
                }
            }
            return View();
        }

        private void SetReport()
        {
            string report_path = GetReportPath();
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
        }

        public void GetFile()
        {
            SetReport();
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

        public ActionResult Prepared()
        {
            WebReport webReport = new WebReport();
            webReport.Width = Unit.Percentage(100);
            webReport.Height = Unit.Percentage(100);

            string file = this.Server.MapPath("~/App_Data/Prepared.fpx");
            webReport.Report.LoadPrepared(file);
            webReport.ShowRefreshButton = false;
            webReport.ReportDone = true;

            ViewBag.WebReport = webReport;
            return View();
        }

        public ActionResult Dialogs()
        {
            webReport.Width = 800;
            webReport.Height = 800;
            webReport.ToolbarBackgroundStyle = ToolbarBackgroundStyle.Light;
            webReport.ToolbarIconsStyle = ToolbarIconsStyle.Blue;
            webReport.ReportFile = this.Server.MapPath("~/App_Data/Dialogs.frx");
            ViewBag.WebReport = webReport;
            return View();
        }
    }
}
