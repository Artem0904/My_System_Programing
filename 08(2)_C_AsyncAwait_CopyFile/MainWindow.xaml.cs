using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

        private string CheckFilesName(string FileName)
        {
            string FolderPath = CopyFromTBox.Text.Remove(CopyFromTBox.Text.LastIndexOf('\\'));
            string[] tmp = Directory.GetFiles(FolderPath);
            for (int i = 0; i < tmp.Length; i++)
            {
                //CopyToTBox.Text += $"({i + 1})";
                FileName += $"({i + 1})";
                if (!File.Exists(CopyToTBox.Text))
                {
                    break;
                }
            }
            return FileName;
        }
        private void Copy_Button(object sender, RoutedEventArgs e)
        {
            string FileNameDest = CopyToTBox.Text;
            if (!File.Exists(CopyFromTBox.Text))
            {
                MessageBox.Show($"File {CopyFromTBox.Text} not exist!");
                return;
            }
            else if (File.Exists(FileNameDest))
            {
                string FolderPath = CopyFromTBox.Text.Remove(CopyFromTBox.Text.LastIndexOf('\\'));
                string[] tmp = Directory.GetFiles(FolderPath);
                FileNameDest.Insert(FileNameDest.LastIndexOf('.'), $"(1)"); 
                for (int i = 0; i < tmp.Length; i++)
                {
                    //if (FileNameDest.Contains('('))
                    //{
                    //    FileNameDest.Remove(FileNameDest.LastIndexOf('('));
                    //    MessageBox.Show(FileNameDest);
                    //}
                    int indexNumber = FileNameDest.LastIndexOf(')') - 1;
                    //FileNameDest.Replace(FileNameDest.LastIndexOf('(')), $"{indexNumber + 1}");
                    FileNameDest.Replace($"({FileNameDest[indexNumber]})", $"({FileNameDest[indexNumber + 1]})");
                    //FileNameDest.Remove(FileNameDest.LastIndexOf('.'));
                    MessageBox.Show(FileNameDest);
                    FileNameDest += $"({i + 1}).txt";
                    MessageBox.Show(FileNameDest);
                    if (!File.Exists(FileNameDest))
                    {
                        break;
                    }
                    MessageBox.Show(FileNameDest);
                }
                //    C:\Users\dev\Desktop\second\secondTEXDT.txt
                //    C:\Users\dev\Desktop\first\test.txt
            }
            File.Copy(CopyFromTBox.Text, FileNameDest);
            //if(int.Parse(CountCopiesTBox.Text) > 1)
            //{
            //    string FolderPath = CopyFromTBox.Text.Remove(CopyFromTBox.Text.LastIndexOf('\\'));
            //    string[] tmp = Directory.GetFiles(FolderPath);
            //    for (int i = 0; i < tmp.Length; i++)
            //    {
            //        CopyToTBox.Text += $"({i + 1})";
            //        if (!File.Exists(CopyToTBox.Text))
            //        {
            //            break;
            //        }
            //    }
            //}

        }
        private void CopyFrom_Button(object sender, RoutedEventArgs e)
        {
            
        }

        private void CopyTo_Button(object sender, RoutedEventArgs e)
        {

        }
    }
}
