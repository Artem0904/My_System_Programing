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

namespace _10_H_FinalTask
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

        private void Check(string StartPath, string word)
        {
            var files = Directory.GetFiles(DirectoryPathTBox.Text);
            //var folders = Directory.GetDirectories(DirectoryPathTBox.Text);
            for (int i = 0; i < files.Length; i++)
            {
                if (Path.GetExtension(files[i]) == ".txt")
                {
                    string text = File.ReadAllText(files[i]);
                    int tmp = text.IndexOf("word");
                    //index of (str, tmp + 1)
                    // передавати індекс після слова і все в циклі
                }
            }
        }

        private async void Start_Button(object sender, RoutedEventArgs e)
        {
            
            Check(DirectoryPathTBox.Text, WordTBox.Text);
            //var files = Directory.GetFiles(DirectoryPathTBox.Text);
            ////MessageBox.Show(files[0]);
            //foreach (var file in files)
            //{
            //    NamesLBox.Items.Add(file);
            //}

            //var folders = Directory.GetDirectories(DirectoryPathTBox.Text);
            //foreach (var folder in folders)
            //{
            //    FoldersLBox.Items.Add(folder);
            //}



        }
    }
}
