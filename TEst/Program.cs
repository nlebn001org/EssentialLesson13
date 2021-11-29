using System;
using System.Threading;

namespace TEst
{
    class Program
    {

        static object locker = new object();
        static Random r = new Random();
        static string chars = "$%#@!*?ABCDEFGHIJKLMNOPQRSTUVWXYZ^&123456789";

        static void Main(string[] args)
        {


            Chain(3);
        }

        static public void Chain(int x)
        {
            int len = r.Next(4, 7);
            for (int i = 0; i < 61; i++)
            {
                for (int j = 0; j < len + 1; j++)
                {
                    if (i - j < 0) continue;
                    Console.SetCursorPosition(x, i - j);
                    setColor(j);
                    Console.Write(j == len || Console.GetCursorPosition().Top >= 10 ? " " : chars[r.Next(chars.Length)]);
                    if (Console.GetCursorPosition().Top >= 10 + len)
                    {
                        i = j = 0;
                    }
                    resetColor();
                }
                Thread.Sleep(500);
            }
        }


        static void setColor(int i)
        {
            if (i == 0) Console.ForegroundColor = ConsoleColor.White;
            else if (i == 1) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        static void resetColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
