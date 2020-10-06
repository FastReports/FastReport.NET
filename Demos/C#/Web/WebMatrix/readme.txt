1. Copy FastReport libraries in Bin folder: FastReport.dll, FastReport.Bars.dll, FastReport.Web.dll
2. Add section with handlers in web.config:
<CODE>  <system.webServer>
   <validation validateIntegratedModeConfiguration="false"/>
    <handlers>
     <remove name="FastReportHandler"/>
     <add name="FastReportHandler" path="FastReport.Export.axd" verb="*" type="FastReport.Web.Handlers.WebExport" />
   </handlers>
  </system.webServer>
</CODE>
3. Add lines in _SiteLayout.cshtml:
<QUOTE>        @FastReport.Web.WebReportGlobals.Scripts()
        @FastReport.Web.WebReportGlobals.Styles()                
</QUOTE>
or
<QUOTE>        @FastReport.Web.WebReportGlobals.ScriptsWOjQuery()
        @FastReport.Web.WebReportGlobals.StylesWOjQuery()                
</QUOTE>
4. Copy database nwind.xml and report template "Complex (Master-detail + Group).frx" in App_Data
5. Add code from example:
<CODE>@{
    FastReport.Web.WebReport report = new FastReport.Web.WebReport();
    report.Report.Load(Server.MapPath("~/App_Data/Complex (Master-detail + Group).frx"));
    report.Width = 800;
    report.Height = 900;
    System.Data.DataSet dataSet = new System.Data.DataSet(); 
    dataSet.ReadXml(Server.MapPath("~/App_Data/nwind.xml"));
    report.Report.RegisterData(dataSet, "NorthWind");
}

@report.GetHtml()
</CODE>
