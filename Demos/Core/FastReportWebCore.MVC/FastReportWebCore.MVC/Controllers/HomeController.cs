using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastReport.Web;
using FastReportWebCore.MVC.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace FastReportWebCore.MVC.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        IHostingEnvironment _hostingEnvironment;
        string reportsPath = "Reports";

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

            for (int i = 0; i < 6; i++)
            {
                if (Directory.Exists(reportsPath))
                    break;
                reportsPath = Path.Combine("..", reportsPath);
            }
        }

        [HttpGet("{reportIndex:int?}")]
        public IActionResult Index(int? reportIndex = 0)
        {
            var model = new HomeModel()
            {
                WebReport = new WebReport(),
                ReportsList = new[]
                {
                    "Simple List",
                    "Labels",
                    "Master-Detail",
                    "Subreport",
                    "Interactive Report, 2-in-1",
                    "Hyperlinks, Bookmarks",
                    "Outline",
                    "Complex (Hyperlinks, Outline, TOC)",
                    "Drill-Down Groups",
                    "Watermark",
                    "Matrix",
                    "Interactive Forms"
                },
            };

            var reportToLoad = model.ReportsList[0];
            if (reportIndex >= 0 && reportIndex < model.ReportsList.Length)
                reportToLoad = model.ReportsList[reportIndex.Value];

            model.WebReport.Report.Load(Path.Combine(reportsPath, $"{reportToLoad}.frx"));

            var dataSet = new DataSet();
            dataSet.ReadXml(Path.Combine(reportsPath, "nwind.xml"));
            model.WebReport.Report.RegisterData(dataSet, "NorthWind");
            
            model.WebReport.DesignerPath = "/WebReportDesigner/index.html";
            model.WebReport.DesignerSaveCallBack = "/SaveDesignedReport";

            // Uncomment to use Online Designer
            //model.WebReport.Width = "1000";
            //model.WebReport.Height = "1000";
            //model.WebReport.Mode = WebReportMode.Designer;

            return View(model);
        }

        // Call-back for save the designed report 
        [HttpPost("/SaveDesignedReport")]
        public ActionResult SaveDesignedReport(string reportID, string reportName)
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            ViewBag.Message = String.Format("Confirmed {0} {1}", reportID, reportName);

            Stream reportForSave = Request.Body;
            string pathToSave = webRootPath + $"/DesignedReports/{reportName}";
            using (FileStream file = new FileStream(pathToSave, FileMode.Create))
            {
                reportForSave.CopyTo(file);
            }
            return View();
        }
    }
}
