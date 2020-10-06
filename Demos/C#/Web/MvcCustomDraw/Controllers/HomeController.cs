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
using System.Globalization;

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
            webReport.CustomDraw += WebReport_CustomDraw;
            webReport.SinglePage = true; 
            ViewBag.WebReport = webReport;
            return View();
        }

        private void WebReport_CustomDraw(object sender, FastReport.Export.Html.CustomDrawEventArgs e)
        {
            if (e.ReportObject is TextObject)
            {
                CultureInfo format = CultureInfo.CreateSpecificCulture("en-US");
                TextObject obj = e.ReportObject as TextObject;
                e.Html = String.Format("<div style=\"position:absolute;left:{0}px;top:{1}px;width:{2}px;height:{3}px;font-size:{4}pt;\">{5}</div>",
                    (e.Left * e.Zoom).ToString(format),
                    (e.Top * e.Zoom).ToString(format),
                    (e.Width * e.Zoom).ToString(format),
                    (e.Height * e.Zoom).ToString(format),
                    (obj.Font.Size * e.Zoom).ToString(format),
                    obj.Text);
                e.Done = true;
            }
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
