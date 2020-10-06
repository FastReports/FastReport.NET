using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastReport.Web;
using FastReportCore.MVC.CentOS.Models;
using Microsoft.AspNetCore.Mvc;

namespace FastReportCore.MVC.CentOS.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("{reportIndex:int?}")]
        public IActionResult Index(int? reportIndex = 0)
        {
            var model = new HomeModel()
            {
                WebReport = new WebReport(),
                ReportsList = new[]
                {
                    "Simple List"
                },
            };

            var reportToLoad = model.ReportsList[0];
            if (reportIndex >= 0 && reportIndex < model.ReportsList.Length)
                reportToLoad = model.ReportsList[reportIndex.Value];
            string reportsDir = System.IO.Path.Combine(
                System.IO.Path.GetDirectoryName(this.GetType().Assembly.Location),
                "Reports");

            model.WebReport.Report.Load(System.IO.Path.Combine(reportsDir, $"{reportToLoad}.frx"));

            var dataSet = new DataSet();
            dataSet.ReadXml(System.IO.Path.Combine(reportsDir, "nwind.xml"));
            model.WebReport.Report.RegisterData(dataSet, "NorthWind");

            return View(model);
        }
    }
}
