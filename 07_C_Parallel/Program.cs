using System;
using System.Text;

namespace _07_C_Parallel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// #1
            // #2

            //int num = 15121;
            //Parallel.Invoke(() => Factorial(num),
            //                () => CountDigits(num),
            //                () => SumDigits(num));

            /// #3

            //Parallel.For(5, 9, MultiplyTable);

            /// 4

            var ListNums = new List<int>();
            Parallel.Invoke(() => ReadNumsFromFile(ref ListNums));
            Parallel.ForEach(ListNums, Factorial);
            var sum = ListNums.AsParallel().Sum();
            var max = ListNums.AsParallel().Max();
            var min = ListNums.AsParallel().Min();
            Console.WriteLine($"Sum : {sum}");
            Console.WriteLine($"Max : {max}");
            Console.WriteLine($"Min : {min}");
        }
        static void ReadNumsFromFile(ref List<int> ListNums)
        {
           
            string text = File.ReadAllText("C:\\Users\\dev\\source\\repos\\My_System_Programing\\07_C_Parallel\\bin\\Debug\\net7.0\\numbers.txt");

            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                {
                    string tmp = text[i].ToString();
                    ListNums.Add(int.Parse(tmp));
                    //Console.WriteLine($"------------{int.Parse(tmp)}");
                }
            }
        }
        static void MultiplyTable(int num)
        {

            /*for(int i = left; i <= right; i++)
            {
                for(int j = 1; j <= 10; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i*j}");
                }
                Console.WriteLine();
            }*/

            
            using (FileStream fs = new FileStream($"Table for {num}.txt", FileMode.OpenOrCreate))
            {
                for (int i = 1; i <= 10; i++)
                {
                    string output = $"{num} * {i} = {num * i}\n";
                    Console.WriteLine(output);
                    byte[] buffer = Encoding.UTF8.GetBytes(output);
                    fs.Write(buffer, 0, buffer.Length);
                }
                fs.Close();
            }
            
            Console.WriteLine();
        }
        static void Factorial(int x)
        {
            int result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Thread.Sleep(3000);
            Console.WriteLine($"Factrial {x} = {result}");
        }
        static int CountDigits(int num)
        {
            Console.WriteLine($"Count digits in {num} : {num.ToString().Length}");
            return num.ToString().Length;
        }
        static int SumDigits(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }
            Console.WriteLine(sum);
            return sum;
        }
    }
}