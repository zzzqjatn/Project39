using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.연구
{
    public class doubleBuffer
    {
        public static int PaintPoint = 0;
        static bool isdraw = false;
        static bool goingnow = false;
        public static void Ingame()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(120, 30);
            Console.SetBufferSize(200, 180);

            //초기 시작 세팅
            PaintPoint = 2;
            Console.SetWindowPosition(0, 60);

            Task paint = Task.Run(async () =>
            {

                if (PaintPoint == 1)
                {
                    Console.MoveBufferArea(0, 120, 200, 60, 0, 60);  //지워주고 다시이동
                    Console.SetCursorPosition(0, 60);
                    Console.WriteLine("★");
                }
                else if (PaintPoint == 2)
                {
                    Console.MoveBufferArea(0, 120, 200, 60, 0, 0);
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("☆");
                }
                goingnow = true;
                //await Task.Delay(200);
            });
            if (goingnow)
            {
                Thread.Sleep(200);
                switch (PaintPoint)
                {
                    case 1:
                        Console.SetWindowPosition(0, 60);
                        break;
                    case 2:
                        Console.SetWindowPosition(0, 0);
                        break;
                }
                goingnow = false;
            }

            while (true)
            {
                if (paint.IsCompleted && isdraw)
                {
                    paint = Task.Run(async () =>
                    {

                        if (PaintPoint == 1)
                        {
                            Console.MoveBufferArea(0, 120, 200, 60, 0, 60);  //지워주고 다시이동
                            Console.SetCursorPosition(0, 60);
                            Console.WriteLine("★");
                            Console.SetWindowPosition(0, 60);
                        }
                        else if (PaintPoint == 2)
                        {
                            Console.MoveBufferArea(0, 120, 200, 60, 0, 0);
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("☆");
                            Console.SetWindowPosition(0, 0);
                        }
                    });
                    isdraw = false;
                    goingnow = true;
                }

                if (goingnow)
                {
                    Thread.Sleep(200);
                    switch (PaintPoint)
                    {
                        case 1:
                            Console.SetWindowPosition(0, 60);
                            break;
                        case 2:
                            Console.SetWindowPosition(0, 0);
                            break;
                    }
                    goingnow = false;
                }


                if (Console.KeyAvailable)
                {
                    if (PaintPoint == 1)
                    {
                        Console.SetCursorPosition(150, 1);
                    }
                    else if (PaintPoint == 2)
                    {
                        Console.SetCursorPosition(150, 61);
                    }
                    ConsoleKeyInfo temp;
                    temp = Console.ReadKey();

                    if (temp.Key == ConsoleKey.A)
                    {
                        switch (PaintPoint)
                        {
                            case 1:
                                PaintPoint = 2;
                                isdraw = true;
                                break;
                            case 2:
                                PaintPoint = 1;
                                isdraw = true;
                                break;
                        }
                    }
                }
            }
        }

        public static void switching(int num)
        {
            switch (num)
            {
                case 1:
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("☆");
                    break;
                case 2:
                    Console.SetCursorPosition(0, 60);
                    Console.WriteLine("★");
                    break;
            }
        }
    }
}
