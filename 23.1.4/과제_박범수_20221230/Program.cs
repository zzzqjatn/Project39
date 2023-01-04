using System;
using System.Text;
using System.IO;

namespace WhatisFunction
{
    public class program
    {
        public static string alltext = string.Empty;

        static void Main(string[] args)
        {
            //PotalGame game = new PotalGame();
            //game.InGame();

            //Console.Title = "안녕하세요";
            //Console.SetBufferSize(200, 200);
            //Console.WriteLine("이 콘솔의 버퍼 길이 {0}, 높이 {1} 값", Console.BufferWidth, Console.BufferHeight);
            //Console.WriteLine("{0}, {1} ", Console.WindowWidth, Console.WindowHeight);
            //Console.WriteLine("asdasd", 100);


            //Console.SetCursorPosition(0, 5);
            //testconsole(Console.ReadLine(), true);

            //Console.SetCursorPosition(0, 5);
            //testconsole("sdas", true);
            //Console.SetWindowPosition(20, 50);

            testing();
        }

        public static void testing()
        {
            Sample.Main222();
        }

        //public static void testconsole( string text, bool endline)
        //{
        //    alltext += text;

        //    if(endline == true)
        //    {
        //        Console.Write(alltext);

        //        for(int i = 0; i < Console.BufferWidth - Console.CursorLeft + 1; i++)
        //        {
        //            Console.Write(" ");
        //        }

        //        //Console.Write("현재콘솔위치 {0} {1}",Console.CursorLeft,Console.BufferWidth - Console.CursorLeft);
        //        alltext += "\n";
        //        alltext = string.Empty;
        //    }
        //}
    }
    class Sample
    {
        public static int saveBufferWidth;
        public static int saveBufferHeight;
        public static int saveWindowHeight;
        public static int saveWindowWidth;
        public static bool saveCursorVisible;
        //
        public static void Main222()
        {
            string m1 = "1) Press the cursor keys to move the console window.\n" +
                        "2) Press any key to begin. When you're finished...\n" +
                        "3) Press the Escape key to quit.";
            string g1 = "+----";
            string g2 = "|    ";
            string grid1;
            string grid2;
            StringBuilder sbG1 = new StringBuilder();
            StringBuilder sbG2 = new StringBuilder();
            ConsoleKeyInfo cki;
            int y;
            //
            try
            {
                saveBufferWidth = Console.BufferWidth;
                saveBufferHeight = Console.BufferHeight;
                saveWindowHeight = Console.WindowHeight;
                saveWindowWidth = Console.WindowWidth;
                saveCursorVisible = Console.CursorVisible;
                //
                Console.Clear();
                Console.WriteLine(m1);
                Console.ReadKey(true);

                // Set the smallest possible window size before setting the buffer size.
                Console.SetWindowSize(1, 1);
                Console.SetBufferSize(80, 80);
                Console.SetWindowSize(40, 20);

                // Create grid lines to fit the buffer. (The buffer width is 80, but
                // this same technique could be used with an arbitrary buffer width.)
                for (y = 0; y < Console.BufferWidth / g1.Length; y++)
                {
                    sbG1.Append(g1);
                    sbG2.Append(g2);
                }
                sbG1.Append(g1, 0, Console.BufferWidth % g1.Length);
                sbG2.Append(g2, 0, Console.BufferWidth % g2.Length);
                grid1 = sbG1.ToString();
                grid2 = sbG2.ToString();

                Console.CursorVisible = false;
                Console.Clear();
                for (y = 0; y < Console.BufferHeight - 1; y++)
                {
                    if (y % 3 == 0)
                        Console.Write(grid1);
                    else
                        Console.Write(grid2);
                }

                Console.SetWindowPosition(0, 0);
                do
                {
                    cki = Console.ReadKey(true);
                    switch (cki.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (Console.WindowLeft > 0)
                                Console.SetWindowPosition(
                                        Console.WindowLeft - 1, Console.WindowTop);
                            break;
                        case ConsoleKey.UpArrow:
                            if (Console.WindowTop > 0)
                                Console.SetWindowPosition(
                                        Console.WindowLeft, Console.WindowTop - 1);
                            break;
                        case ConsoleKey.RightArrow:
                            if (Console.WindowLeft < (Console.BufferWidth - Console.WindowWidth))
                                Console.SetWindowPosition(
                                        Console.WindowLeft + 1, Console.WindowTop);
                            break;
                        case ConsoleKey.DownArrow:
                            if (Console.WindowTop < (Console.BufferHeight - Console.WindowHeight))
                                Console.SetWindowPosition(
                                        Console.WindowLeft, Console.WindowTop + 1);
                            break;
                    }
                }
                while (cki.Key != ConsoleKey.Escape);  // end do-while
            } // end try
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.Clear();
                Console.SetWindowSize(1, 1);
                Console.SetBufferSize(saveBufferWidth, saveBufferHeight);
                Console.SetWindowSize(saveWindowWidth, saveWindowHeight);
                Console.CursorVisible = saveCursorVisible;
            }
        } // end Main
    } // end Sample
}
