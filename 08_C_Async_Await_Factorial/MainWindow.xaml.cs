using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace _08_C_Async_Await_Factorial
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

        private async void AddFactorial_Click(object sender, RoutedEventArgs e)
        {
            int result = await Factorial(int.Parse(NumberTextBox.Text));
            FactorialListBox.Items.Add(result);
        }
        private Task<int> Factorial(int x)
        {
            return Task.Run(() =>   
            {
                int result = 1;

                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                }
                Thread.Sleep(1000);
                return result;
            });
        }
    }
}
