using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    internal class DummeUI
    {
        public static void stringtext(int LeftPad, string inputText, bool isEndLine)
        {
            for (int i = 0; i < LeftPad; i++)
            {
                Console.Write(' ');
            }

            Console.Write(inputText);

            if (isEndLine)
            {
                Console.WriteLine();
            }
        }

        public static void stringtext(int LeftPad, string inputText, int RightPad, bool isEndLine)
        {
            for (int i = 0; i < LeftPad; i++)
            {
                Console.Write(' ');
            }

            Console.Write(inputText);

            for (int i = 0; i < RightPad; i++)
            {
                Console.Write(' ');
            }

            if (isEndLine)
            {
                Console.WriteLine();
            }
        }

        public static void stringtext(bool isEndLine)
        {
            if (isEndLine)
            {
                int maxCount = Console.BufferWidth - Console.CursorLeft;

                for (int i = 0; i < maxCount; i++)
                {
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        public void Dummy()
        {
            //stringtext(11, "-------------------------------------------", 10, true);
            //stringtext(10, "|                                           |", 10, true);
            //stringtext(10, "|                   승리                    |", 10, true);
            //stringtext(10, "|                                           |", 10, true);
            //stringtext(10, "|                                           |", 10, true);
            //stringtext(10, "|                                           |", 10, true);
            //stringtext(10, "|                   보상                    |", 10, true);
            //stringtext(10, "|                                           |", 10, true);
            //stringtext(10, "| Gold : 20 G                               |", true);
            //stringtext(10, "|                                           |", 10, true);
            //stringtext(10, "| 아이템 : 늑대의 송곳니 (Nomal)            |", 10, true);
            //stringtext(10, "|                                           |", 10, true);
            //stringtext(10, "|         5 초 뒤 던전으로 돌아갑니다       |", 10, true);
            //stringtext(10, "|                                           |", 10, true);
            //stringtext(11, "-------------------------------------------", 10, true);
            stringtext(true);

            //stringtext(11, "-------------------------------------------",10, true);
            //stringtext(10, "|                                           |",10, true);
            //stringtext(10, "|             울프가 나타났다               |",10, true);
            //stringtext(10, "|                                           |",10, true);
            //stringtext(10, "| HP : 80     MP : 0   ATK : 60   DEF : 20  |", true);
            //stringtext(10, "|                                           |",10, true);
            //stringtext(11, "-------------------------------------------",10, true);
            //stringtext(true);
            //stringtext(true);
            //stringtext(11, "-------------------------------------------", 10, true);
            //stringtext(10, "|                                           |", 10, true);
            //stringtext(10, "|                  플레이어                 |", 10, true);
            //stringtext(10, "|                                           |", 10, true);
            //stringtext(10, "| HP : 200    MP : 50  ATK : 80   DEF : 40  |", true);
            //stringtext(10, "|                                           |", 10, true);
            //stringtext(11, "-------------------------------------------", 10, true);
            //stringtext(true);
            //stringtext(7, "   공격", false);
            //stringtext(5, "   스킬", false);
            //stringtext(5, "   아이템", false);
            //stringtext(5, "   도망가기", true);
            //stringtext(true);
            //stringtext(11, "▲",0, true);

            //Console.Write("          ■■■■■■■■■■■■ ");
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.Write("@");
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.Write(" ■■■■■■■■■");
            //stringtext(true);

            //stringtext(10, "■                                          ■", 10, true);
            //stringtext(10, "■                                          ■", 10, true);
            //stringtext(10, "■             ⓖ                           ■", 10, true);
            //stringtext(10, "■                                          ■", 10, true);
            //stringtext(10, "■                         ⓦ               ■", 10, true);
            //stringtext(10, "■                                          ■", 10, true);

            //Console.Write("           ");
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.Write("@");
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.Write("        ◎                                ");
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.Write("@");
            //Console.ForegroundColor = ConsoleColor.White;
            //stringtext(true);
            //stringtext(10, "■                                          ■", 10, true);
            //stringtext(10, "■                                          ■", 10, true);
            //stringtext(10, "■                                          ■", 10, true);
            //stringtext(10, "■                                          ■", 10, true);
            //stringtext(10, "■              ⓓ                          ■", 10, true);
            //stringtext(10, "■                                          ■", 10, true);
            //stringtext(10, "■                                          ■", 10, true);

            //Console.Write("          ■■■■■■■■■■■■ ");
            //Console.ForegroundColor = ConsoleColor.Blue;
            //Console.Write("@");
            //Console.ForegroundColor = ConsoleColor.White;
            //Console.Write(" ■■■■■■■■■");




            //stringtext(11, "------------------------------------------------------", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(10, "|   이름 :                                             |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(11, "------------------------------------------------------", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(10, "|   배경 선택                                          |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(10, "|     부유한 기사 ☜      방랑자         거지          |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(11, "------------------------------------------------------", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(10, "|   추가 스텟 포인트 : 14 (랜덤포인트)                 |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(10, "|  힘:10   민첩:10   지능:10   행운:10   카리스마:10   |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(10, "|    ▲                                                |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(11, "------------------------------------------------------", 10, true);


            //stringtext(10, "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒", 10, true);
            //stringtext(10, "▒                                                      ▒", 10, true);
            //stringtext(10, "▒                                                      ▒", 10, true);
            //stringtext(10, "▒                    던전 마스터                       ▒", 10, true);
            //stringtext(10, "▒                                                      ▒", 10, true);
            //stringtext(10, "▒                                                      ▒", 10, true);
            //stringtext(10, "▒                                                      ▒", 10, true);
            //stringtext(10, "▒                                                      ▒", 10, true);
            //stringtext(10, "▒                                                      ▒", 10, true);
            //stringtext(10, "▒                                                      ▒", 10, true);
            //stringtext(10, "▒                                                      ▒", 10, true);
            //stringtext(10, "▒         게임시작  ☜              게임종료           ▒", 10, true);
            //stringtext(10, "▒                                                      ▒", 10, true);
            //stringtext(10, "▒                                                      ▒", 10, true);
            //stringtext(10, "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒", 10, true);

            //stringtext(10, "▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒  인벤토리 ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒", 10, true);
            //stringtext(11, "------------------------------------------------------", 10, true);
            //stringtext(10, "|                     = 상태 =                         |", 10, true);
            //stringtext(10, "|   이름 : Sam                                         |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(10, "|   HP : 200    MP : 50  ATK : 80   DEF : 40           |", true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(10, "|   힘:10   민첩:10   지능:10   행운:10   카리스마:10  |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(11, "------------------------------------------------------", 10, true);
            //stringtext(10, "|                    = 메뉴 =                          |", 10, true);
            //stringtext(10, "|   장비    ☜                                         |", 10, true);
            //stringtext(10, "|   아이템                                             |", 10, true);
            //stringtext(10, "|   나가기                                             |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(11, "------------------------------------------------------", 10, true);
            //stringtext(10, "|  아이템 명          갯수          설명               |", 10, true);
            //stringtext(10, "|  빨간포션            2          체력 10 회복   ◀    |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(11, "------------------------------------------------------", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(10, "|     사용하기  ◀        버리기         나가기        |", 10, true);
            //stringtext(10, "|                                                      |", 10, true);
            //stringtext(11, "------------------------------------------------------", 10, true);
        }

    }
}
