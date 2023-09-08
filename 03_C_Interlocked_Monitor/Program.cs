using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace _03_C_Interlocked_Monitor
{
    public class Stat
    {
        public int Letters { get; set; } = 0;
        public int Digits { get; set; } = 0;
        public int Punctuation { get; set; } = 0;
        //...
    }
    public class Analyse
    {
        public Stat statistic = new Stat();
        public string text { get; set; }
    }
    class Program
    {
        public static Stat Statistic = new Stat();
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("C:\\Users\\dev\\Desktop", "*.txt");
            Analyse analyse = new Analyse();
            Thread thread = null; // ліст потоків
            foreach (var file in files)
            {

                string text = File.ReadAllText(file);
                //ThreadPool.QueueUserWorkItem(TextAnalyse, text);
                thread = new Thread(TextAnalyse); 
                thread.Start(text);

            }//зробити цикл щоб все заджоїнити
            thread.Join();
            // show total statistic
            Console.WriteLine($"Count Digits : {Statistic.Digits}");
            Console.WriteLine($"Count Punctuation : {Statistic.Punctuation}");

        }

        static void TextAnalyse(object text)
        {
            // text analyse how many letters, digits etc.
            string AnalyseText = (string)text;
            string Digits = "1234567890";
            string Punctuation = ".,;:-.!?\"\"''«»(){}[]<>/\\";
            for (int i = 0; i < AnalyseText.Length; i++)
            {
                if (AnalyseText.Contains(Digits))
                {
                    Statistic.Digits++;
                }
                else if (AnalyseText.Contains(Punctuation))
                {
                    Statistic.Punctuation++;
                }
            }
        }
    }
}
