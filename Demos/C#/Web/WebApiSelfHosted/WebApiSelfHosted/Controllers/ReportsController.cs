using FastReport;
using FastReport.Export.Html;
using FastReport.Export.Image;
using FastReport.Export.Pdf;
using FastReport.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using WebApiSelfHosted.Models;

namespace WebApiSelfHosted.Controllers
{
    /// <summary>
    /// Report Query class
    /// </summary>
    public class ReportQuery
    {
        // Format of resulting report: png, pdf, html
        public string Format { get; set; }

        // Value of "Parameter" variable in report
        public string Parameter { get; set; }

        // Enable Inline preview in browser (generates "inline" or "attachment")
        public bool Inline { get; set; }
    }

    [RoutePrefix("api/reports")]
    public class ReportsController : ApiController
    {
        // List of reports
        Reports[] reportItems = new Reports[]
        {
            new Reports { Id = 1, ReportName = "Simple List.frx" },
            new Reports { Id = 2, ReportName = "Barcode.frx" }
        };

        // Gets list of reports
        [Route]
        public IEnumerable<Reports> GetAllReports()
        {
            return reportItems;
        }

        // Gets Report by ID with query
        [Route("{id}")]
        public HttpResponseMessage GetReportById(int id, [FromUri] ReportQuery query)
        {
            // Find the report
            Reports reportItem = reportItems.FirstOrDefault((p) => p.Id == id);
            if (reportItem != null)
            {
                string reportPath = "../../App_Data/" + reportItem.ReportName;
                string dataPath = "../../App_Data/nwind-employees.xml";
                MemoryStream stream = new MemoryStream();
                try
                {
                    using (DataSet dataSet = new DataSet())
                    {
                        dataSet.ReadXml(dataPath);
                        Config.WebMode = true;
                        using (Report report = new Report())
                        {
                            report.Load(reportPath);
                            report.RegisterData(dataSet, "NorthWind");
                            if (query.Parameter != null)
                            {
                                report.SetParameterValue("Parameter", query.Parameter);
                            }

                            // Two prepare Phases for eliminate any report dialogs
                            report.PreparePhase1();
                            report.PreparePhase2();

                            if (query.Format == "pdf")
                            {
                                PDFExport pdf = new PDFExport();
                                report.Export(pdf, stream);
                            }
                            else if (query.Format == "html")
                            {
                                using (HTMLExport html = new HTMLExport())
                                {
                                    html.SinglePage = true;
                                    html.Navigator = false;
                                    html.EmbedPictures = true;
                                    report.Export(html, stream);
                                }
                            }
                            else
                            {
                                using (ImageExport img = new ImageExport())
                                {
                                    img.ImageFormat = ImageExportFormat.Png;
                                    img.SeparateFiles = false;
                                    img.ResolutionX = 96;
                                    img.ResolutionY = 96;
                                    report.Export(img, stream);
                                    query.Format = "png";
                                }
                            }
                        }
                    }

                    HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(stream.ToArray())
                    };

                    stream.Dispose();

                    result.Content.Headers.ContentDisposition =
                        new ContentDispositionHeaderValue(query.Inline ? "inline" : "attachment")
                        {
                            FileName = String.Concat(Path.GetFileNameWithoutExtension(reportPath), ".", query.Format)
                        };
                    result.Content.Headers.ContentType =
                        new MediaTypeHeaderValue("application/" + query.Format);
                    return result;
                }
                catch
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}
