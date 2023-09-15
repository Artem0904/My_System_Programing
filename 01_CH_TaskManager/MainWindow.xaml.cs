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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = Process.GetProcesses();
        }

        private void grid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var res = MessageBox.Show(@$"
Process Name          : {((Process)grid.SelectedItem).ProcessName}
Machine Name          : {((Process)grid.SelectedItem).MachineName}
Start Time            : {((Process)grid.SelectedItem).StartTime}
Base Priority         : {((Process)grid.SelectedItem).BasePriority}
Total Processor Time  : {((Process)grid.SelectedItem).TotalProcessorTime}

Wanna delete it?");
            //if (res == MessageBoxResult.Yes)
            //{
            //    ((Process)grid.SelectedItem).Kill();
            //}
        }
    }
}
