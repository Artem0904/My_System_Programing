using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.IO;
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

namespace _08_2__C_AsyncAwait_CopyFile
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

        private async Task ProgressBarUpAsync(int Max)
        {
            CopyProgressBar.Maximum = Max;
            for (int i = 0; i < Max; i++)
            {
                CopyProgressBar.Value++;
                await Task.Delay(100);
            }
        }
        private async void Copy_Button(object sender, RoutedEventArgs e)
        {
            CopyProgressBar.Value = 0;
            string FileNameDest = CopyToTBox.Text;
            int coutCopies = int.Parse(CountCopiesTBox.Text);
            for (int i = 0; i < coutCopies; i++)
            {
                if (!File.Exists(CopyFromTBox.Text))
                {
                    MessageBox.Show($"File {CopyFromTBox.Text} not exist!");
                    return;
                }

                string sourceFileName = Path.GetFileName(CopyFromTBox.Text);
                string destinationFileName = Path.Combine(Path.GetDirectoryName(FileNameDest), sourceFileName);

                int counter = 1;

                while (File.Exists(destinationFileName))
                {
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(sourceFileName);
                    string fileExtension = Path.GetExtension(sourceFileName);
                    destinationFileName = Path.Combine(Path.GetDirectoryName(FileNameDest), $"{fileNameWithoutExtension}({counter}){fileExtension}");
                    counter++;
                }

                try
                {
                    File.Copy(CopyFromTBox.Text, destinationFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error copying file : {ex.Message}");
                }
                await ProgressBarUpAsync(coutCopies);
            }

            //    //    C:\Users\dev\Desktop\second\secondTEXDT.txt
            //    //    C:\Users\dev\Desktop\first\test.txt

            //    //    C:\Users\RTX\OneDrive\Desktop\second\secondTEXDT.txt
            //    //    C:\Users\RTX\OneDrive\Desktop\first\test.txt
        }
    }
}
