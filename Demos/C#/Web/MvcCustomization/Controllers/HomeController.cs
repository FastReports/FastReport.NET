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

namespace MvcCustomization.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            WebReport webReport = new WebReport();

            string report_path = GetReportPath();
            System.Data.DataSet dataSet = new System.Data.DataSet();
            dataSet.ReadXml(report_path + "nwind.xml");
            
            webReport.Report.RegisterData(dataSet, "NorthWind");
            webReport.Report.Load(report_path + "Simple List.frx");

            webReport.Width = Unit.Percentage(100);
            webReport.Height = Unit.Percentage(100);
            webReport.ToolbarIconsStyle = ToolbarIconsStyle.Black;
            // sets custom style of icons
            webReport.ToolbarIconsStyle = ToolbarIconsStyle.Custom;
            // sets custom style of background
            webReport.ToolbarBackgroundStyle = ToolbarBackgroundStyle.Custom;
            // sets path to the customized images
            webReport.ButtonsPath = "Buttons/";
            // load localization, you can find all locale files in the main Localization folder
            webReport.LocalizationFile = "Localization/German.frl";
            //webReport.LocalizationFile = "Localization/Russian.frl";
            webReport.PrintInPdf = false;

            ViewBag.WebReport = webReport;
            return View();
        }


        private string GetReportPath()
        {
            string report_path = Config.ApplicationFolder;
            using (XmlDocument xml = new XmlDocument())
            {
                xml.Load(report_path + "config.xml");
                foreach (XmlItem item in xml.Root.Items)
                    if (item.Name == "Config")
                        foreach (XmlItem configitem in item.Items)
                            if (configitem.Name == "Reports")
                                report_path += configitem.GetProp("Path");
            }
            return report_path;
        }
    }
}
