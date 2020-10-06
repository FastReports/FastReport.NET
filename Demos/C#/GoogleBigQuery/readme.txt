Google Big Query reporting demo

Prerequisites
1. Visual Studio 2012
2. FastReport .NET http://fast-report.com
3. FastReport.GoogleBigQuery connection
4. Google.Apis.Bigquery.v2 http://www.nuget.org/packages/Google.Apis.Bigquery.v2/ 

How-to set up libraries
1. To install Google.Apis.Bigquery.v2 Client Library, run the following command in the Package Manager Console
(From the Tools menu, select Library Package Manager and then click Package Manager Console):
Install-Package Google.Apis.Bigquery.v2 -Pre 
2. Check references to libraries: FastReport.dll, FastReport.Bars.dll, FastReport.Editor.dll, FastReport.GoogleBigQuery.dll

How-to set up a report
1. Open report in Designer
2. Right-click on "Google Connection" in data tree and click "Edit"
3. Press "Edit connection"
4. Fill "Google Project ID", "Client ID", "Client Secret" from your Google API properties


Please feel free to contact us if you have any questions or comments support@fast-report.com
