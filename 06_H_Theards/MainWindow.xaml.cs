using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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

namespace _06_H_Theards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ViewModel viewModel = new();

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new ViewModel();
            this.DataContext = viewModel;
            PrimeNumbersListBox.ItemsSource = PrimaryNums;
        }
        private List<int> FibonacciNums = new List<int>();
        private List<int> PrimaryNums = new List<int>();

        private void Fibonacci(int left)
        {
            int a = 0;
            int b = 1;
            if (left < 0)
            { left = 1000; }
            for (int i = 0; i < left; i++)
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
        private int PrimeNums(int left, int right)
        {
            if (left > right)
            {
                int tmp;
                tmp = left;
                left = right;
                right = tmp;
            }
            int Count = 0;
            for (int i = left; i < right; i++)
            {
                if (IsPrimeNumber(i))
                {
                    PrimaryNums.Add(i);
                    Count++;
                }
            }
            return Count;
        }
        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            PrimeNums(viewModel.leftPrimary, viewModel.rightPrimary);
            Fibonacci(viewModel.rightFibonacci);
        }


        [PropertyChanged.AddINotifyPropertyChangedInterface]
        public class ViewModel
        {
            public int leftPrimary;
            public int rightPrimary;
            public int rightFibonacci;


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
