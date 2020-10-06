// TestReportDlg.h : header file
//

#if !defined(_TestReportDLG_)
#define _TestReportDLG_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifdef _DEBUG
#import "..\Bin\Debug\FRCom.tlb"
#else
#import "..\Bin\Release\FRCom.tlb"
#endif // _DEBUG


/////////////////////////////////////////////////////////////////////////////
// CTestReportDlg dialog

class CTestReportDlg : public CDialog
{
// Construction
public:
	CTestReportDlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CTestReportDlg)
	enum { IDD = IDD_TESTREPORT_DIALOG };
		// NOTE: the ClassWizard will add data members here
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CTestReportDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

  CString m_sConnStrTemplate,
          m_sAccesDBPath,
          m_sReportFilePath,
          m_sDataSource,
          m_sSQL_Kernel,
          m_sSQL_Where,
          m_sSQL_OrderBy;

  CEdit   m_EditPathReport,
          m_EditPathDB,
          m_EditSQLWhere,
          m_EditSQLOrderBy;

	// Generated message map functions
	//{{AFX_MSG(CTestReportDlg)

	virtual BOOL OnInitDialog      ();
	afx_msg void OnSysCommand      (UINT nID, LPARAM lParam);
	afx_msg void OnPaint           ();
	afx_msg HCURSOR OnQueryDragIcon();
	virtual void OnOK              ();

	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()

public:
  afx_msg void OnBnClickedSeldb    ();
  afx_msg void OnBnClickedSelReport();
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(_TestReportDLG_)
