using System;
using System.Runtime.InteropServices;

/**/
using FastReport;
using FastReport.Data;
using FastReport.Design;
using FastReport.Utils;
using FastReport.Wizards;
/**/

namespace FRCom
{
  [Guid("13101006-BCF7-4af0-9311-802F8DCF67FC")]
  [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]

  public interface _FReport
  {
    [DispId(1)]
    void Test();

    [DispId(2)]
    void ShowReport(string sFullPath);

    [DispId(3)]
    void SetReportPath(string sFullPath);

    [DispId(4)]
    void SetConnectString(string sConnStr);

    [DispId(5)]
    void SetQuery(string sDSName, string sUserQuery);

    [DispId(6)]
    void ShowPreparedReport();
  }

  [Guid("9F83AE6A-3B7E-4468-91FE-0151FF1FC390")]
  [ClassInterface(ClassInterfaceType.None)]
  [ProgId("FRCom.FReport")]

  public class FReport : _FReport
  {
    public FReport() { }

    private string m_sReportPath,
                   m_sConnect,
                   m_sDataSourceName,
                   m_sQuery;

    // Simply Open Report from fxed location
    public void Test()
    {
      Report report1 = new Report();
      report1.Load("E:\\test.frx");
      report1.Show();
    }

    // Assign report location and show report
    public void ShowReport(string sFullPath)
    {
      Report report1 = new Report();
      report1.Load(sFullPath);

      report1.Show();
    }

    // Set report Path
    public void SetReportPath(string sFullPath)
    {
      m_sReportPath = sFullPath;
    }

    // Set report ConnectString
    public void SetConnectString(string sConnStr)
    {
      m_sConnect = sConnStr;
    }

    // Set report Query text for DataSource
    public void SetQuery(string sDSName, string sUserQuery)
    {
      m_sDataSourceName = sDSName;
      m_sQuery          = sUserQuery;
    }

    // Show Prepared report with User Parameters
    public void ShowPreparedReport()
    {
      Report repFRX = new Report();
      repFRX.Load(m_sReportPath);

      // Set Connect string if assigned
      if ( m_sConnect.Length > 0 )
      {
        repFRX.Dictionary.Connections[0].ConnectionString = m_sConnect;        
      }

      // Set Query Text if assigned
      if (m_sDataSourceName.Length > 0 && m_sQuery.Length > 0)
      {
        TableDataSource repTable = repFRX.GetDataSource(m_sDataSourceName) as TableDataSource;

        repTable.SelectCommand = m_sQuery;
      }

      repFRX.Show();
    }
  }
}