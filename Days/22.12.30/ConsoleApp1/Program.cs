using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = 100;
            Console.SetCursorPosition(0, 50);
            Console.WriteLine("sdasd");
            Console.SetCursorPosition(0, 0);
            //Console.MoveBufferArea(0, 50, 0, 0,0,0);
        }
    }
}