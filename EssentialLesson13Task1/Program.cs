using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace EssentialLesson13Task1
{
    class Program
    {
        static object locker = new object();
        static Random r = new Random();
        static string chars = "$%#@!*?ABCDEFGHIJKLMNOPQRSTUVWXYZ^&123456789";
        static int random;

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(r.Next(300, 500));
                random = r.Next(0, 80);
                if (i % 3 == 0)
                    new Thread(() => Chain(random)).Start(); // esli stavim i => pervoe zadanie // esli stavim random => vtoroe zadanie
            }
        }

        static public void Chain(int x)
        {
            int ResetCursor = 20;
            int len = r.Next(4, 7);
            for (int i = 0; i < 61; i++)
            {
                lock (locker)
                {
                    for (int j = 0; j < len + 1; j++)
                    {
                        if (i - j < 0) continue;
                        Console.SetCursorPosition(x, i - j);
                        setColor(j);
                        Console.Write(j == len || Console.GetCursorPosition().Top >= ResetCursor ? " " : chars[r.Next(chars.Length)]);
                        if (Console.GetCursorPosition().Top >= ResetCursor + len)
                            i = j = 0;
                        resetColor();
                    }
                }
                Thread.Sleep(300);
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
