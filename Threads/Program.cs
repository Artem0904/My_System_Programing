using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; // for working with processes
using System.Reflection;
using System.Drawing;

namespace Processes
{
    class Program
    {
        public static List<int> nums = new List<int>();
        public static int MaxNum = 0;
        public static int MinNum = 0;
        public static int AvgNum = 0;

        public struct Pair
        {
            public int left { get; set; }
            public int right { get; set; }
            public Pair(int left, int right)
            {
                this.left = left;
                this.right = right;
            }
        }
        public static void Numbers(object pair)
        {
            Pair pair1 = (Pair)pair;

            int left = pair1.left;
            int right = pair1.right;
            if (left > pair1.right)
            {
                int tmp;
                tmp = left;
                left = right;
                right = tmp;
            }
            for (int i = left; i < right; i++)
            {
                Console.WriteLine($"Number #{i}");
                Thread.Sleep(10);
            }
        }
        public static void RandomNumbers()
        {
            Random r = new Random();
            int size = 100;
            for (int i = 0; i < size; i++)
            {
                nums.Add(r.Next(0, size));
                Console.WriteLine(nums[i]);
            }
        }
        public static void FindMaxNum()
        { 
            MaxNum = nums.Max();
            Console.WriteLine("===========" + MaxNum);

        }
        public static void FindMinNum()
        {
            MinNum = nums.Min();
            Console.WriteLine("===========" + MinNum);


        }
        public static void FindAvgNum()
        {
            AvgNum = (int)nums.Average();
            Console.WriteLine("===========" + AvgNum);

        }
        static void Main(string[] args)
        {
            ////// #1

            //int left = 0, right = 0;
            //Console.Write("Enter left : ");
            //left = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Enter right : ");
            //right = Convert.ToInt32(Console.ReadLine());
            //Pair pair = new Pair(left, right);

            //Console.Write("How many theards : ");
            //int countTheards = Convert.ToInt32(Console.ReadLine());
            //if (countTheards <= 0)

            //    return;
            //for (int i = 0; i < countTheards; i++)
            //{
            //    Thread tmpT = new Thread(Numbers);
            //    tmpT.Start((object)pair);
            //}

            ////// 4

            Thread TGenerate = new Thread(RandomNumbers);
            TGenerate.Start();
           

            Thread TMax = new Thread(FindMaxNum);
            TMax.Start();
            Thread TMin = new Thread(FindMinNum);
            TMin.Start();
            Thread TAvg = new Thread(FindAvgNum);
            TAvg.Start();

        }
    }
}