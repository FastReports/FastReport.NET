using FastReport;
using System.Windows;

namespace ViewerDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void opnRptInCode_Click(object sender, RoutedEventArgs e)
        {
            Report report = new Report();
            report.LoadPrepared("Simple List.fpx");
            Viewer1.Report = report;
        }
    }
}
