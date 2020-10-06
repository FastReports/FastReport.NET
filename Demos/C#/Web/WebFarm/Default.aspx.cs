using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using FastReport;
using FastReport.Utils;
using FastReport.Web;
using System.Collections.Generic;
using System.IO;
using FastReport.Data;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Version.Text = "ver." + Config.Version;
    }

    protected void WebReport1_StartReport(object sender, EventArgs e)
    {
        WebReport1.Report = new FastReport.Barcodes();
    }
}

