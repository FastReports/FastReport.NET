<%@ Page Title="FastReport.NET Web service" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
        <h2><a href="ReportService.svc">ReportService.svc</a></h2>
	<hr/>
	<h3>REST USAGE:</h3>
        <p><a href="ReportService.svc/about/">About FastReport.NET (GET)</a> ReportService.svc/about/</p>
        <p><a href="ReportService.svc/reports/">Gets reports list (GET)</a> ReportService.svc/reports/ in JSON</p>
        <p><a href="ReportService.svc/reportsxml/">Gets reports list (GET)</a> ReportService.svc/reportsxml/ in XML</p>
        <p><a href="ReportService.svc/reports/path">Gets reports list by "path" (GET)</a> ReportService.svc/reports/path in JSON</p>
        <p><a href="ReportService.svc/reportsxml/path">Gets reports list by "path" (GET)</a> ReportService.svc/reportsxml/path in XML</p>
        <p><a href="ReportService.svc/gears/">Gets Gears list (GET)</a> ReportService.svc/gears/ in JSON</p>
        <p><a href="ReportService.svc/gearsxml/">Gets Gears list (GET)</a> ReportService.svc/gearsxml/ in XML</p>
        <p><a href="ReportService.svc/getreport/">Gets a report (POST)</a> ReportService.svc/getreport/ with JSON query</p>
        <p><a href="ReportService.svc/getreportxml/">Gets a report (POST)</a> ReportService.svc/getreport/ with XML query</p>
        <p><a href="ReportService.svc/preparereportbyid/ID">Get prepared report by ID (GET)</a> ReportService.svc/preparereportbyid/ID</p>
        <hr/>
        <p><a href="ReportService.svc/gethtml/">Creates html as zip archive from prepared fpx report (POST stream)</a> ReportService.svc/gethtml/</p>
        <p><a href="ReportService.svc/getpdf/">Creates PDF from prepared fpx report (POST stream)</a> ReportService.svc/getpdf/</p>
        <hr/>
        <p><a href="ReportService.svc/put/">Stores report (frx) in service (POST stream). The returned value is UUID for next calls.</a> ReportService.svc/put/</p>
        <p><a href="ReportService.svc/putprepared/">Stores prepared (fpx) report in service (POST stream). The returned value is UUID for next calls.</a> ReportService.svc/putprepared/</p>
        <p><a href="ReportService.svc/checkprepared/UUID">Gets available prepared report by UUID in service(GET)</a> ReportService.svc/checkprepared/UUID</p>
        <p><a href="ReportService.svc/getprepared/UUID">Gets prepared report by UUID from service(GET)</a> ReportService.svc/getprepared/UUID</p>
        <p><a href="ReportService.svc/gethtml/UUID">Gets prepared report as HTML by UUID from service(GET)</a> ReportService.svc/gethtml/UUID</p>
        <p><a href="ReportService.svc/getpdf/UUID">Gets prepared report as PDF by UUID from service(GET)</a> ReportService.svc/getpdf/UUID</p>
        <p><a href="ReportService.svc/getlogo/UUID/WIDTH/HEIGHT">Gets logo of prepared report as PNG by UUID from service(GET)</a> ReportService.svc/getlogo/UUID/WIDTH/HEIGHT</p>
</asp:Content>
