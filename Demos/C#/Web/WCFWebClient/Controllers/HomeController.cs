using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FastReport;
using WCFWebClient.ReportService;
using System.IO;
using FastReport.Web;
using System.Configuration;

namespace WCFWebClient.Controllers
{
    public class HomeController : Controller
    {
        private WebReport webReport = new WebReport();

        public ActionResult Index()
        {           
            WebReport webReport = new WebReport();
            webReport.Width = 600;
            webReport.Height = 800;
            webReport.ToolbarIconsStyle = ToolbarIconsStyle.Black;
            webReport.StartReport += new EventHandler(webReport_StartReport);
            ViewBag.WebReport = webReport;
            return View();            
        }

        void webReport_StartReport(object sender, EventArgs e)
        {
            (sender as WebReport).ReportDone = true;            
            FastReportServiceClient reportServiceClient = new FastReportServiceClient();
            reportServiceClient.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["FastReportServiceUserName"];
            reportServiceClient.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["FastReportServicePassword"];
            reportServiceClient.Open();
            ReportItem reportItem = new ReportItem();
            reportItem.Path = @"Demo reports\Simple List.frx";
            GearItem gearItem = new GearItem();
            gearItem.Name = "FPX";
            ReportRequest request = new ReportRequest();
            request.Report = reportItem;
            request.Gear = gearItem;
            (sender as WebReport).Report.LoadPrepared(reportServiceClient.GetReport(request));
            reportServiceClient.Close();            
        }

        public FileResult GetPdfFile()
        {
            FastReportServiceClient reportServiceClient = new FastReportServiceClient();
            reportServiceClient.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["FastReportServiceUserName"];
            reportServiceClient.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["FastReportServicePassword"];
            reportServiceClient.Open();
            ReportItem reportItem = new ReportItem();
            reportItem.Path = @"Demo reports\Simple List.frx";
            GearItem gearItem = new GearItem();
            gearItem.Name = "FPX";
            ReportRequest request = new ReportRequest();
            request.Report = reportItem;
            request.Gear = gearItem;
            Stream stream = reportServiceClient.GetReport(request);
            Stream pdfStream = reportServiceClient.GetPDF(stream);
            reportServiceClient.Close();            
            return File(pdfStream, "application/pdf", "report.pdf");
        }

        public FileResult GetZipFile()
        {
            FastReportServiceClient reportServiceClient = new FastReportServiceClient();
            reportServiceClient.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["FastReportServiceUserName"];
            reportServiceClient.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["FastReportServicePassword"];
            reportServiceClient.Open();
            ReportItem reportItem = new ReportItem();
            reportItem.Path = @"Demo reports\Simple List.frx";
            GearItem gearItem = new GearItem();
            gearItem.Name = "FPX";
            ReportRequest request = new ReportRequest();
            request.Report = reportItem;
            request.Gear = gearItem;
            Stream stream = reportServiceClient.GetReport(request);

            string uuid = reportServiceClient.PutPreparedReport(stream);
            Stream zipStream;
            
            try
            {
                zipStream = reportServiceClient.GetHTMLByUUID(uuid);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            //Stream pdfStream = reportServiceClient.GetHTML(stream);
            reportServiceClient.Close();
            return File(zipStream, "application/zip", "report.zip");
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
