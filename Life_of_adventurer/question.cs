using System;

namespace Life_of_adventurer
{
    internal class question
    {
        static void Main(string[] args)
        {

            //문자열 비교문
            string FirstWord = string.Empty;
            string SecondWord = string.Empty;

            bool isCompare = false;

            FirstWord = Console.ReadLine();
            SecondWord = Console.ReadLine();

            if (FirstWord.Length == SecondWord.Length)
            {
                for (int index = 0; index < FirstWord.Length; index++)
                {
                    if (FirstWord[index] == SecondWord[index])
                    {
                        isCompare = true;
                    }
                    else
                    {
                        isCompare = false;
                        break;
                    }
                }
            }
            if(isCompare)
            {
                Console.WriteLine("같습니다");
            }
            else
            {
                Console.WriteLine("다릅니다.");
            }

            //5가지 음료
            Console.WriteLine();
            Console.Write("콜라, 물, 스프라이트, 주스, 커피 (1 ~ 5) 중에서 하나를 선택하세요 : ");
            int selectdrink = 0;

            while(true)
            {
                int.TryParse(Console.ReadLine(), out selectdrink);
                if(selectdrink > 0 && selectdrink < 6)
                {
                    break;
                }
                Console.WriteLine("\t\t\t\t잘못된 오류 값을 입력하였습니다. (1~5까지 정수만)");
            }

            switch(selectdrink)
            {
                case 1:
                    Console.WriteLine("콜라를 선택하셨습니다.");
                    break;
                case 2:
                    Console.WriteLine("물을 선택하셨습니다.");
                    break;
                case 3:
                    Console.WriteLine("스프라이트를 선택하셨습니다.");
                    break;
                case 4:
                    Console.WriteLine("주스를 선택하셨습니다.");
                    break;
                case 5:
                    Console.WriteLine("커피를 선택하셨습니다.");
                    break;
            }

            //배열days
            Console.WriteLine();
            int[] days = new int[12] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            for(int index = 0; index < days.Length; index++)
            {
                Console.WriteLine($"{index + 1}월은 {days[index]}일까지 입니다.");
                Console.WriteLine("=========================");
                Console.WriteLine();
            }

        }
    }
}
