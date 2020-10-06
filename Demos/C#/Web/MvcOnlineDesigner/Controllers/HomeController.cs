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
using FastReport.Data;

namespace MvcRazor.Controllers
{
    public class HomeController : Controller
    {
        private WebReport webReport = new WebReport();

        public ActionResult Index()
        {
            SetReport();
            webReport.Width = 780;
            webReport.Height = 900;
            webReport.ToolbarIconsStyle = ToolbarIconsStyle.Black;
            // webReport.LocalizationFile = "~/Localization/German.frl";            
            webReport.EmbedPictures = true;
            webReport.XlsxPageBreaks = false;
            webReport.XlsxSeamless = true;
            // fill the parameters on startup
            webReport.Report.SetParameterValue("Test parameter 1", "Value of parameter 1 from application code");
            ViewBag.WebReport = webReport;
            return View();
        }


        public ActionResult Designer()
        {
            webReport = new WebReport();
            webReport.Width = Unit.Percentage(100);
            webReport.Height = Unit.Percentage(100); ;
            string report_path = GetReportPath();
            System.Data.DataSet dataSet = new System.Data.DataSet();
            dataSet.ReadXml(report_path + "nwind.xml");
            webReport.Report.RegisterData(dataSet, "NorthWind");

            webReport.Report.Load(report_path + "Simple List.frx");

            // user friendly aliases of fields in report template
            // next code needs for create new report with predefined aliases and database 

            foreach (DataSourceBase dsItem in webReport.Report.Dictionary.DataSources)
            {
                if (dsItem.Name == "Employees")
                {
                    dsItem.Alias = "CompanyEmployees";
                    dsItem.Columns.FindByName("EmployeeID").Alias = "Employee ID";
                    dsItem.Columns.FindByName("LastName").Alias = "Last Name";
                    dsItem.Columns.FindByName("FirstName").Alias = "First Name";
                    dsItem.Columns.FindByName("Title").Alias = "Title";
                    dsItem.Columns.FindByName("TitleOfCourtesy").Alias = "Title Of Courtesy";
                    dsItem.Columns.FindByName("BirthDate").Alias = "Birth Date";
                    dsItem.Columns.FindByName("HireDate").Alias = "Hire Date";
                    dsItem.Columns.FindByName("Address").Alias = "Address";
                    dsItem.Columns.FindByName("City").Alias = "City";
                    dsItem.Columns.FindByName("Region").Alias = "Region";
                    dsItem.Columns.FindByName("PostalCode").Alias = "Postal Code";
                    dsItem.Columns.FindByName("Country").Alias = "Country";
                    dsItem.Columns.FindByName("HomePhone").Alias = "Home phone";
                    dsItem.Columns.FindByName("Extension").Alias = "Extension";
                    dsItem.Columns.FindByName("Photo").Alias = "Photo";
                    dsItem.Columns.FindByName("Notes").Alias = "Notes";
                    dsItem.Columns.FindByName("ReportsTo").Alias = "Reports To";
                }
            }

            // example of creating a parameter in template with default value
            webReport.Report.SetParameterValue("Parameter 2 from code", "\"Value of second parameter from application\"");

            // set-up the Online-Designer
            webReport.DesignReport = true;
            webReport.DesignScriptCode = false;
            webReport.Debug = true;
            webReport.DesignerPath = "~/WebReportDesigner/index.html";
            //webReport.DesignerLocale = "de";
            //webReport.LocalizationFile = "~/Localization/German.frl";
            webReport.DesignerSaveCallBack = "~/Home/SaveDesignedReport";
            webReport.ID = "DesignReport";
            ViewBag.WebReport = webReport;
            return View();
        }

        [HttpPost]
        // call-back for save the designed report 
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
            report2.Load(report_path + "Chart.frx");
            webReport.AddTab(report2, "Charts");
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
    }
}
