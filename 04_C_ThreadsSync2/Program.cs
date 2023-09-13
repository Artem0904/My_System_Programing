using System;
using System.Threading;

namespace _04_C_ThreadsSync2
{
    internal class Program
    {
        static int a = 0, b = 0;


        static void Main(string[] args)
        {
            // Завдання 1:
            // Створіть додаток, що використовує механізм семафорів.
            // Створіть в коді програми десять потоків. Кожний з потоків виводить набір
            // випадкових чисел після чого завершує свою роботу. Перед відображенням
            // потрібно показати ідентифікатор потоку. Одночасно можуть виконуватися тільки
            // три потоки, інші потоки знаходяться в черзі. Як тільки якийсь потік завершує
            // своє виконання, новий запускається

            //Semaphore s = new Semaphore(3, 3);

            //for (int i = 0; i < 10; ++i)
            //    ThreadPool.QueueUserWorkItem(RandNum, s);

            //Console.ReadKey();


            // Завдання 2:
            // Створіть додаток, що використовує механізм EventHadnler.
            // Створіть в коді програми кілька потоків. Перший потік генерує і зберігає в 
            // файл кілька пар чисел. Другий потік очікує завершення генерації, після чого підраховує
            // суму кожної пари. Результат записується в файл. Третій потік теж очікує завершення генерації, 
            // після чого підраховує добуток кожної пари.Результат записується в файл.

            ManualResetEvent resetEvent = new ManualResetEvent(false);

            ThreadPool.QueueUserWorkItem(Pair, resetEvent);     
            ThreadPool.QueueUserWorkItem(Sum, resetEvent);
            ThreadPool.QueueUserWorkItem(Multiply, resetEvent);

            Console.ReadKey();

        }
        public static void Pair(object obj)
        {
            Random rnd = new Random();
            a = rnd.Next(0, 100);
            b = rnd.Next(0, 100);
            Console.WriteLine($"\n\n{a} {b}\n");
            ((EventWaitHandle)obj).Set();
        }

        public static void Sum(object obj)
        {
            ((EventWaitHandle)obj).WaitOne();
            Console.WriteLine($"Sum : {a + b}\n");
        }

        public static void Multiply(object obj) 
        {
            ((EventWaitHandle)obj).WaitOne();
            Console.WriteLine($"Multiply : {a * b}\n");
        }


        public static void RandNum(object semaphore)
        {
            Semaphore s = semaphore as Semaphore;

            bool stop = false;
            while (!stop)
            {
                if (s.WaitOne()) // block one state
                {
                    try
                    {
                        Console.WriteLine("Thread {0} start", Thread.CurrentThread.ManagedThreadId);
                        for (int i = 0; i < 5; ++i)
                            Console.WriteLine($"{new Random().Next(0, 100)} ");
                        Thread.Sleep(4000);
                    }
                    finally
                    {
                        stop = true;
                        Console.WriteLine("Thread {0} stop", Thread.CurrentThread.ManagedThreadId);
                        s.Release();
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}