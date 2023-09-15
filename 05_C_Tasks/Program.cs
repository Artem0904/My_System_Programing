using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_C_Tasks
{
    internal class Program
    {
        public static bool IsPrimeNumber(int n)
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
        public static int PrintPrimeNums(int left, int right, ref List<int> ListNums)
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
                    Console.WriteLine($"Prime nums : {i}");
                    ListNums.Add(i);
                    Count++;
                }
            }
            Console.WriteLine();
            return Count;
        }
        public static int FindMaxNum(List<int> ListNums)
        {
            int MaxNum = ListNums.Max();
            return MaxNum;
        }
        public static int FindMinNum(List<int> ListNums)
        {
            int MinNum = ListNums.Min();
            return MinNum;
        }
        public static int FindAvgNum(List<int> ListNums)
        {
            int  AvgNum = (int)ListNums.Average();
            return AvgNum;
        }
        public static int FindSum(List<int> ListNums)
        {
            return ListNums.Sum();
        }
        public static void RemoveDublicate(ref List<int> ListNums)
        {
            ListNums = ListNums.Distinct().ToList();
            //ListNums = uniqueNums;
            //ListNums.Distinct();
        }
        public static void SortList(ref List<int> ListNums)
        {
           ListNums = ListNums.OrderByDescending(x => x).ToList();
        }
        public static bool FindNum(List<int> ListNums, int num)
        {
            return ListNums.Contains(num);
        }
        static void Main(string[] args)
        {
            ////// #1
            //while (!Console.KeyAvailable)
            //{
            //    Console.Clear();
            //    Task Time1 = new Task(() => Console.WriteLine($"Time task1 : {DateTime.Now}"));
            //    Time1.Start();

            //    Task Time2 = Task.Factory.StartNew(() => Console.WriteLine($"Time task2 : {DateTime.Now}"));

            //    Task Time3 = Task.Run(() => { Console.WriteLine($"Time task3 : {DateTime.Now}"); });
            //    Thread.Sleep(10);
            //}


            //// #2
            //// #3
            //// #4
            
            Console.Write($"Enter left : ");
            int left = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Enter right : ");
            int right = Convert.ToInt32(Console.ReadLine());
            List<int> ListPrimeNums = new List<int>();

            Task<int> PrimeNums = new Task<int>(() => PrintPrimeNums(left, right, ref ListPrimeNums));
            PrimeNums.Start();
            Task.WaitAll(PrimeNums);

            Console.WriteLine($"Count prime nums : {PrimeNums.Result}");

            Task<int>[] tasks = new Task<int>[4] 
            {
                new Task<int>(() => FindMaxNum(ListPrimeNums)),
                new Task<int>(() => FindMinNum(ListPrimeNums)),
                new Task<int>(() => FindAvgNum(ListPrimeNums)),
                new Task<int>(() => FindSum(ListPrimeNums))
            };
            Task.WaitAny(PrimeNums);

            //for (int i = 0; i < tasks.Length - 1; i++)
            //{
            //    tasks[i].Start();
            //}
            //Task.WaitAll(tasks[0], tasks[1], tasks[2]);
            //tasks[3].Start();
            //Console.WriteLine($"Max : {tasks[0].Result}\nMin : {tasks[1].Result}\nAvg : {tasks[2].Result}\nSum : {tasks[3].Result}");


            //Видалити повторювані значення з масиву.
            //Сортування масиву(стартує після видалення дубльованих значень).
            //Бінарний пошук певного значення(стартує після сортування)

            
            int value = 3;
            Task TRemoveDublicate = new Task(() => RemoveDublicate(ref ListPrimeNums));

            Task TSort = TRemoveDublicate.ContinueWith((t) => SortList(ref ListPrimeNums));

           // Task<bool> TFind = new Task<bool>(() => FindNum(ListPrimeNums, value));

           // Console.WriteLine($"\t\tNumber {value} in List : {TFind.Result}");

            TRemoveDublicate.Start();

            TSort.Wait();
            foreach (var num in ListPrimeNums)
            {
                Console.WriteLine(num);
            }



            Console.ReadKey();
        }
    }
}