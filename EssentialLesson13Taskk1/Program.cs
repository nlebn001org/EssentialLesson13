using System;
using System.Threading;

namespace EssentialLesson13Taskk1
{
    class Program
    {
        static void Main(string[] args)
        {
            RecursiveMethod();
        }

        static void RecursiveMethod()
        {
            Thread r = new Thread(() => Console.WriteLine($"{Thread.CurrentThread.GetHashCode()} Thread "));
            r.Start();
            Thread.Sleep(1000);
            RecursiveMethod();
        }
    }

}