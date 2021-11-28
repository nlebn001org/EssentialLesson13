using System;
using System.Linq;
using System.Threading;

namespace EssentialLesson13Task1
{
    class Program
    {
        static int x = 0;
        static object locker = new object();
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            FallenRandomChars(0);
            

        }


        public static void FallenChars(int x, int[] arr)
        {
            int y = 1;

            for (int i = 0; i < arr.Length; i++)                //in charge of fall till the end of the array
            {
                Console.Clear();
                for (int j = 0; j <= i; j++)
                {
                    Console.SetCursorPosition(x, j);
                    Console.WriteLine(arr[j]);
                }
                Thread.Sleep(500);
            }

            for (int i = 0; i < 7; i++)                         //in charge of fall till the i
            {
                Console.Clear();
                Console.SetCursorPosition(x, y++);
                for (int j = 0; j < arr.Length; j++)
                {
                    Console.SetCursorPosition(x, j + y);
                    Console.WriteLine(arr[j]);
                }
                Thread.Sleep(500);
            }
        }

        public static void FallenRandomChars(int x)
        {
            int y = 1;

            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()+";

            Random r = new Random();
            int arrayLength = r.Next(5, 10);                    // length of a chain

            for (int i = 0; i < arrayLength; i++)                //in charge of fall till the end of the chain
            {
                Console.Clear();
                for (int j = 0; j <= i; j++)
                {
                    Console.SetCursorPosition(x, j);
                    setColor(i-j);
                    Console.WriteLine(chars[r.Next(chars.Length)]);
                    resetColor();
                }
                Thread.Sleep(500);
            }

            int newArrLenght = r.Next(arrayLength, 10);

            for (int i = 0; i < newArrLenght; i++)                         //in charge of fall till the i element of the chain
            {
                Console.Clear();
                Console.SetCursorPosition(x, y++);
                for (int j = 0; j < arrayLength; j++)
                {
                    Console.SetCursorPosition(x, j + y);
                    setColor(arrayLength-j-1);
                    Console.WriteLine(chars[r.Next(chars.Length)]);
                    resetColor();
                }
                Thread.Sleep(500);
            }
        }

        public static void setColor(int i)
        {

            if (i == 0) Console.ForegroundColor = ConsoleColor.White;
            else if (i == 1) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        public static void resetColor()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
