﻿//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

//namespace TaskManager
//{
//    /// <summary>
//    /// Interaction logic for MainWindow.xaml
//    /// </summary>
//    public partial class MainWindow : Window
//    {
//        Process selectedProcess;
//        public MainWindow()
//        {
//            InitializeComponent();
//        }

//        private void Refresh_Click(object sender, RoutedEventArgs e)
//        {
//            grid.ItemsSource = Process.GetProcesses();
//        }

//        private void EndProcess_Click(object sender, RoutedEventArgs e)
//        {
//            //selectedProcess = Process.GetProcessById(Id);    .......
//            //selectedProcess.Kill();
//        }
//    }
//}
