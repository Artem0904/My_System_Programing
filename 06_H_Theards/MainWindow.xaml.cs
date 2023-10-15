using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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

namespace _06_H_Theards
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
        private List<int> FibonacciNums = new List<int>();
        bool firstPrimaryStart = true;
     
        private bool generating;
        private CancellationTokenSource cancelToken;
      
        
        private void Fibonacci(int right)
        {
            int a = 0;
            int b = 1;
            if (right < 0)
            { right = 100; }
            for (int i = 0; i < right; i++)
            {
                int temp = a;
                a = b;
                b = temp + b;
                FibonacciNums.Add(a);
            }
        }
        private bool IsPrimeNumber(int n)
        {
            var result = true;

            if (n > 1)
            {
                for (var i = 2; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        //private async void GeneratePrimary_Click(object sender, RoutedEventArgs e)
        //{
        //    int left = int.Parse(LeftPrimaryTBox.Text);
        //    int right = int.Parse(RightPrimaryTBox.Text);

        //    //List<int> PrimaryNums = await FindPrimesAsync(left, right);
        //    //foreach (int prime in PrimaryNums)
        //    //{
        //        //PrimeListBox.Items.Add(prime);
        //    //}
        //    for(int i = 1; i < right; i++)
        //    {
        //        PrimeListBox.Items.Add(await FindPrimesAsync(left,right));
        //        Thread.Sleep(500);
        //        left++;
        //    }
        //}

        ////private async Task<List<int>> FindPrimesAsync(int left, int right)
        //private async Task<int> FindPrimesAsync(int left, int right)
        //{
        //    //List<int> PrimaryNums = new List<int>();
        //    int PrimeNum = 0;
        //    await Task.Run(() =>
        //    {
        //        for (int num = left; num <= right; num++)
        //        {
        //            if (IsPrimeNumber(num))
        //            {
        //                PrimeNum = num;
        //                break;
        //                //PrimaryNums.Add(num);
        //            }
        //        }
        //    });
        //    //return PrimaryNums;
        //    return PrimeNum;
        //}

        private void GeneratePrimary_Click(object sender, RoutedEventArgs e)
        {
            if (generating)
            {
                // Вимкнути генерацію
                cancelToken.Cancel();
                generating = false;
            }
            else
            {
                // Почати генерацію
                int left = string.IsNullOrWhiteSpace(LeftPrimaryTBox.Text) ? 2 : int.Parse(LeftPrimaryTBox.Text);
                int right = string.IsNullOrWhiteSpace(RightPrimaryTBox.Text) ? int.MaxValue : int.Parse(RightPrimaryTBox.Text);

                PrimeListBox.Items.Clear();
                generating = true;
                cancelToken = new CancellationTokenSource();

                ThreadPool.QueueUserWorkItem(o => GeneratePrimes(left, right, cancelToken.Token));
            }
        }

        private async void GeneratePrimes(int left, int right, CancellationToken token)
        {
            for (int num = left; num <= right; num++)
            {
                if (token.IsCancellationRequested)
                {
                    await Dispatcher.InvokeAsync(() => generating = false);
                    return;
                }

                if (IsPrimeNumber(num))
                {
                    await Dispatcher.InvokeAsync(() => PrimeListBox.Items.Add(num));
                }
            }

            Dispatcher.Invoke(() => generating = false);
        }

        private void GenerateFibonacci_Click(object sender, RoutedEventArgs e)
        {

        }

        //Завдання 1:
        //Створіть віконний додаток, який генерує набір простих чисел в
        //діапазоні, вказаному користувачем. Якщо не вказано нижню
        //межу, потік стартує з 2.Якщо верхню межу не вказано,
        //генерування відбувається до завершення додатка.
        //Використовуйте механізм потоків.Числа мають відображатися у
        //віконному інтерфейсі.


        //Завдання 2:
        //Додайте до першого завдання потік, що генерує набір чисел
        //Фібоначчі.Числа мають відображатися у віконному інтерфейсі.


        //Завдання 3:
        //Додайте до другого завдання кнопки для повної зупинки кожного
        //з потоків.Одна кнопка для одного потоку.Якщо користувач
        //натиснув кнопку зупинки, потік повністю припиняє свою роботу.


        //Завдання 4:
        //Додайте до третього завдання кнопки для призупинення та
        //відновлення кожного з потоків. Наприклад, користувач може
        //призупинити генерацію чисел Фібоначчі натиснувши на кнопку.
        //Продовження генерації можливе після натискання на іншу
        //кнопку.


        //Завдання 5:
        //Додайте до четвертого завдання можливість повного рестарту
        //потоків з новими межами.
    }
}
