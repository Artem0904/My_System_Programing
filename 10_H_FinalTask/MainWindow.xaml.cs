using System;
using System.Collections.Generic;
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

namespace _10_H_FinalTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource cancellationTokenSource;
        public MainWindow()
        {
            InitializeComponent();
        }
        private async Task ProgressBarUpAsync(int Max, CancellationToken cancellationToken)
        {
            progressBar.Maximum = Max;
            for (int i = 0; i < Max; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                progressBar.Value++;
                await Task.Delay(100);
            }
        }

        private async Task CheckFilesAsync(string StartPath, string word, CancellationToken cancellationToken)
        {
            int countWords = 0;
            var files = Directory.GetFiles(DirectoryPathTBox.Text,"*", SearchOption.AllDirectories);
            for (int i = 0; i < files.Length; i++)
            {
                if (Path.GetExtension(files[i]) == ".txt")
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    string text = await File.ReadAllTextAsync(files[i]);
                    int index = text.IndexOf(word);

                    FilesLBox.Items.Add(files[i]);
                    for(int j = 0; j < text.Length; j++)
                    {
                        if(index != -1)
                        {
                            countWords++;
                        }
                        else
                        {
                            break;
                        }
                        index = text.IndexOf(word, index + 1);
                    }
                }
            }
            await ProgressBarUpAsync(countWords, cancellationToken);
            MessageBox.Show($@"
Word : {word}
Count word : {countWords.ToString()}
Start path : {StartPath}
");
        }

        private async void Start_Button(object sender, RoutedEventArgs e)
        {
            if (Directory.Exists(DirectoryPathTBox.Text))
            {
                cancellationTokenSource = new CancellationTokenSource();
                CancellationToken cancellationToken = cancellationTokenSource.Token;
                StopButton.IsEnabled = true;

                try
                {
                    await CheckFilesAsync(DirectoryPathTBox.Text, WordTBox.Text, cancellationToken);
                   
                }
                catch (OperationCanceledException)
                {
                    MessageBox.Show("Процес було скасовано.");
                }
                finally
                {
                    StopButton.IsEnabled = false; 
                }
            }
            else
            {
                MessageBox.Show($"Directory '{DirectoryPathTBox.Text}' not exists!");
            }

            //var files = Directory.GetFiles(DirectoryPathTBox.Text);
            ////MessageBox.Show(files[0]);
            //foreach (var file in files)
            //{
            //    FilesLBox.Items.Add(file);
            //}

            //var folders = Directory.GetDirectories(DirectoryPathTBox.Text);
            //foreach (var folder in folders)
            //{
            //    FoldersLBox.Items.Add(folder);
            //}
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            if (cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }
        }
    }
}
