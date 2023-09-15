using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _01_CH_TaskManager
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

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = Process.GetProcesses();
        }

        [Obsolete]
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(@$"
Process Name          : {((Process)grid.SelectedItem).ProcessName}
Machine Name          : {((Process)grid.SelectedItem).MachineName}
Start Time            : {((Process)grid.SelectedItem).StartTime}
Base Priority         : {((Process)grid.SelectedItem).BasePriority}
Total Processor Time  : {((Process)grid.SelectedItem).TotalProcessorTime}
Paged Memory Size     : {((Process)grid.SelectedItem).PagedMemorySize}
");
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ((Process)grid.SelectedItem).Kill();
        }
    }
}
