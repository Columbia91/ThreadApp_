using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadApp_
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintNumbers();

            //var threads = new Thread[20];
            //for (int i = 0; i < threads.Length; i++)
            //{
            //    threads[i] = new Thread(PrintNumbers);
            //}

            //foreach (var thread in threads)
            //{
            //    thread.Start();
            //}

            var thread = new Thread(Sum);
            thread.IsBackground = false;
            thread.Start(new SumArguments { X = 5, Y = 10 });

            Console.WriteLine("Главный поток закончил работу");

            Console.ReadLine();
        }

        private static void PrintNumbers()
        {
            var currentThread = Thread.CurrentThread;
            Console.WriteLine($"Поток с ID {currentThread.ManagedThreadId} - начал работу");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.Write(i + " ");
            }

            Console.WriteLine($"\nПоток с ID {currentThread.ManagedThreadId} - закончил работу");
        }

        static void Sum(object arguments)
        {
            Console.WriteLine((arguments as SumArguments).X + (arguments as SumArguments).Y);
            Console.WriteLine("Вторичный поток закончил работу");
            Thread.Sleep(5000);
        }
    }
}
