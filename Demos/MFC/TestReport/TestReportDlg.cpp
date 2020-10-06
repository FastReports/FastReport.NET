// TestReportDlg.cpp : implementation file
//

#include "stdafx.h"
#include "TestReport.h"
#include "TestReportDlg.h"

#include <stdlib.h>
#include <stdio.h>

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

using namespace FRCom;

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();


// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTestReportDlg dialog

CTestReportDlg::CTestReportDlg(CWnd* pParent /*=NULL*/)
	: CDialog(CTestReportDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CTestReportDlg)
		// NOTE: the ClassWizard will add member initialization here
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);

  m_sConnStrTemplate = "Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=[FILEPATH];Mode=Share Deny None;Extended Properties=;Jet OLEDB:System database=;Jet OLEDB:Registry Path=;Jet OLEDB:Database Password=;Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password=;Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False";
  m_sAccesDBPath     = "..\\Data\\dbTest.mdb";
  m_sReportFilePath  = "..\\Report\\Test.frx";    

  m_sDataSource      = "Customer";
  m_sSQL_Kernel      = "select * from Customer";
}

void CTestReportDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CTestReportDlg)
		// NOTE: the ClassWizard will add DDX and DDV calls here

  DDX_Control(pDX, IDC_PATH_REPORT, m_EditPathReport );
  DDX_Control(pDX, IDC_PATH_DB,     m_EditPathDB     );
  DDX_Control(pDX, IDC_SQL_WHERE,   m_EditSQLWhere   );
  DDX_Control(pDX, IDC_SQL_ORDERBY, m_EditSQLOrderBy );

  DDX_Text   (pDX, IDC_PATH_REPORT, m_sReportFilePath);
  DDX_Text   (pDX, IDC_PATH_DB,     m_sAccesDBPath   );
  DDX_Text   (pDX, IDC_SQL_WHERE,   m_sSQL_Where     );
  DDX_Text   (pDX, IDC_SQL_ORDERBY, m_sSQL_OrderBy   );

	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CTestReportDlg, CDialog)
	//{{AFX_MSG_MAP(CTestReportDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	//}}AFX_MSG_MAP
  ON_BN_CLICKED(ID_SELREPORT, &CTestReportDlg::OnBnClickedSelReport)
  ON_BN_CLICKED(ID_SELDB,     &CTestReportDlg::OnBnClickedSeldb    )
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CTestReportDlg message handlers

BOOL CTestReportDlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
  m_EditPathReport.SetWindowText(m_sReportFilePath);
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CTestReportDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CTestReportDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CTestReportDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CTestReportDlg::OnOK() 
{
  // Get Edit values
  UpdateData(TRUE);

  LPTSTR part;

  CString sFullPathFrx,  // FullPath to frx
          sFullPathMDB,  // FullPath to MDB
          sConnStr,      // Resulting Connect string to DB
          sDataSource,   //
          sQuery,
          sTmp; 
  
  // Calc path to FRX file location
  sFullPathFrx.Preallocate(MAX_PATH);
  ::GetFullPathName(m_sReportFilePath, MAX_PATH, sFullPathFrx.GetBuffer(), &part);

  // Calc path to MDB file
  sFullPathMDB.Preallocate(MAX_PATH);
  ::GetFullPathName(m_sAccesDBPath,    MAX_PATH, sFullPathMDB.GetBuffer(), &part);

  // Compose JET Connect string by MDB FilePath
  sConnStr = m_sConnStrTemplate;   
  sConnStr.Replace("[FILEPATH]", sFullPathMDB);

  // Compose Query text
  sQuery = m_sSQL_Kernel;

  // Assign Where
  if ( m_sSQL_Where.GetLength() > 0 )
    sQuery = sQuery + " where " + m_sSQL_Where;

  // Assign Order By
  if ( m_sSQL_OrderBy.GetLength() > 0 )
    sQuery = sQuery + " order by " + m_sSQL_OrderBy;

  // Report COM object
  FRCom::_FReport *pReport;
	CoInitialize(NULL);
  
	FRCom::_FReportPtr p(__uuidof(FRCom::FReport));
	pReport = p;

  // Test
	//pReport->Test();  

  // Show Report by Path
  //pReport->ShowReport(_bstr_t(sFullPathFrx));

  // Prepare report and show
  pReport->SetReportPath   (_bstr_t(sFullPathFrx));
  pReport->SetConnectString(_bstr_t(sConnStr    ));
  pReport->SetQuery        (_bstr_t(m_sDataSource), _bstr_t(sQuery));

  pReport->ShowPreparedReport();
}

void CTestReportDlg::OnBnClickedSeldb()
{
  CFileDialog dlgFile (TRUE, "*.mdb", NULL, OFN_HIDEREADONLY|OFN_ENABLESIZING|OFN_EXPLORER|OFN_NOVALIDATE, 
    _T("Access DB File (*.mdb)|*.mdb||"), NULL);

  dlgFile.m_ofn.lpstrTitle  = _T("Access DB File");

  if ( dlgFile.DoModal() == IDOK )
  {
    m_sAccesDBPath = dlgFile.GetPathName();

    UpdateData(FALSE);
  }  
}

void CTestReportDlg::OnBnClickedSelReport()
{
  CFileDialog dlgFile (TRUE, "*.frx", NULL, OFN_HIDEREADONLY|OFN_ENABLESIZING|OFN_EXPLORER|OFN_NOVALIDATE, 
    _T("FastReport.NET File (*.frx)|*.frx||"), NULL);

  dlgFile.m_ofn.lpstrTitle  = _T("FastReport.NET File");

  if ( dlgFile.DoModal() == IDOK )
  {
    m_sReportFilePath = dlgFile.GetPathName();

    UpdateData(FALSE);
  }  
}
