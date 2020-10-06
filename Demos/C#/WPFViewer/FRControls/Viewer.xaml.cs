using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FastReport;
using FastReport.Export.XAML;
using System.IO;
using System.Windows.Markup;
using System;
using Microsoft.Win32;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace FRControls
{
    /// <summary>
    /// Interaction logic for Viewer.xaml
    /// </summary>
    public partial class Viewer : UserControl
    {
        private XAMLExport ex = new XAMLExport();
        private bool flag = false;
        private Report report;
        private bool hasMultipleFiles;
        private bool is_scrolled;
        private int currPage;
        private List<ListBoxItem> pages = new List<ListBoxItem>();
        public Report Report
        {
            get { return report; }
            set
            {

                lb.Items.Clear();
                ex = new XAMLExport();
                ex.HasMultipleFiles = HasMultipleFiles;
                ex.IsScrolled = false; //---
                report = value;
                SetContent(report);               
            }
        }
        public bool HasMultipleFiles
        {
            get { return hasMultipleFiles; }
            set
            {
                hasMultipleFiles = value;
                ex.HasMultipleFiles = value;
            }
        }
        public bool IsScrolled
        {
            get { return is_scrolled; }
            set
            {
                is_scrolled = value;
                if(is_scrolled)
                {
                    scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                    scroll.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    ex.IsScrolled = false;
                }
                else
                {
                    scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled;
                    scroll.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
                }
            }
        }
        public Viewer()
        {       
            InitializeComponent();
            HasMultipleFiles = true;
            currPage = 0;
        }

        private void viewer_LayoutUpdated(object sender, EventArgs e)
        {
            if(flag)
            {
                UpdateImages(lb);
                flag = false;
            }
        }

        private void SetContent(Report report)
        {
        /*    if (!HasMultipleFiles)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ex.Export(report, ms);
                    lb.Items.Add(new Frame()
                    {
                        Content = XamlReader.Load(ms),
                        Margin = new Thickness(5, 5, 5, 10)
                    });
                }               
            }
            else*/
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    ex.Export(report, ms);
                    foreach (MemoryStream page in ex.GeneratedStreams)
                    {
                        lb.Items.Add(new Frame()
                        {
                            BorderThickness = new Thickness(1),
                            BorderBrush = Brushes.Yellow,
                            Content = XamlReader.Load(page),
                            Margin = new Thickness(5, 5, 5, 10)
                        });
                    }
                }
            }
            flag = true;
        }

        void UpdateImages(DependencyObject depObj)
        {
            foreach (Image img in FindVisualChildren<Image>(depObj))
            {
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ex.GetImage(img.Name);
                ex.GetImage(img.Name).Position = 0;
                bi.EndInit();
                img.Source = bi;
                img.UpdateLayout();
            }
        }  

        public IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void opnBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenReportFile(this);
        }

        void OpenReportFile(Viewer v)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "Подготовленные отчёты(*.FPX)|*.fpx;";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = false;
            if (myDialog.ShowDialog() == true)
            {
                LoadReport(v, myDialog.FileName);
            }
        }

        void LoadReport(Viewer v, string report_name)
        {
            Report report = new Report();
            report.LoadPrepared(report_name);
            v.Report = report;
        }

        /// <summary>
        /// Scroll to selected page
        /// </summary>
        /// <param name="pageNumber"></param>
        private void ScrollToPage(int pageNumber)
        {
            if (pageNumber < lb.Items.Count && pageNumber >= 0)
                lb.ScrollIntoView(lb.Items[pageNumber]);
        }
        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void opnDesign_Click(object sender, RoutedEventArgs e)
        {
            if(report != null)
            report.Design();
        }
        private void nxtPageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currPage < lb.Items.Count - 1)
                currPage++;
            ScrollToPage(currPage);
        }
        private void prrPageBtn_Click(object sender, RoutedEventArgs e)
        {
            if (currPage > 0)
                currPage--;
            ScrollToPage(currPage);
        }
        private void lstPageBtn_Click(object sender, RoutedEventArgs e)
        {
            currPage = lb.Items.Count - 1;
            ScrollToPage(currPage);
            
        }

        private void frstPageBtn_Click(object sender, RoutedEventArgs e)
        {
            currPage = 0;
            ScrollToPage(currPage);
        }

        private void nbrPageTxt_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
           if(e.Key == Key.Enter)
            {
                if (int.Parse(nbrPageTxt.Text) > 0)
                ScrollToPage(int.Parse(nbrPageTxt.Text) - 1);
            }
        }

        private void nbrPageTxt_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void nbrPageTxt_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }
    }
}
