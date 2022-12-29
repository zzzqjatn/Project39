using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatisOperator
{
    internal class Program2
    {
        static void Main(string[] args)
        {

            //System.Random;           

            /*
             * LAB 1 최대한도의 사탕사기
             * 현재 1000원이 있고 사탕의 가격이 300원 일때, 최대 살수 있는 사탕의 개수와 나머지돈은 얼마인지 출력하는 프로그램
             * EX)
             *      현재 가지고 있는 돈 : 1000 (유저의입력을 받기)
             *      캔디의 가격: 300 (캔디의 가격은 상수)
             *      최대로 살수 있는 캔디의 갯수 = 3
             *      캔디 구입 후 남은 돈 = 100
             *      
             * LAB 2 화씨온도를 섭씨온도로 바꾸기
             * 우리나라는 섭씨온도를 사용하지만 미국에선 화씨온도를 사용한다.
             * 화씨온도를 섭씨온도로 바꾸는 프로그램 작성
             * EX)
             *      화씨온도 60도는 섭씨온도 ????? 입니다.
             *      
             * LAB 3 주사위게임
             *      2개의 주사위를 던져서 합을 표시하는 프로그램을 작성하시오.
             *      주사위를 던지면 랜덤한 수가 나와야 한다.
             *      EX)
             *          첫번째 주사위: {0}
             *          두번째 주사위: {0}
             *          두 주사위 합: {0}
             */


            //int Money = 0;
            //const int CANDYPRICE = 300;

            //Console.WriteLine("\n최대한 캔디 사기!");
            //Console.Write("현재 가지고 있는 돈 : ");
            //int.TryParse(Console.ReadLine(), out Money);
            //Console.WriteLine("캔디의 가격 : {0}", CANDYPRICE);
            //Console.WriteLine("최대한 살수 있는 캔디의 갯수 : {0}", (Money / CANDYPRICE));
            //Console.WriteLine("캔디 구입 후 남은 돈 : {0}", (Money % CANDYPRICE));

            ////      화씨
            //float temperature_F = 0.0f;

            //Console.WriteLine("\n화씨온도 섭씨온도로 바꾸기");
            //Console.Write("화씨온도 입력하시오 : ");
            //float.TryParse(Console.ReadLine(), out temperature_F);
            //Console.WriteLine("화씨온도 {0} 는(은) 섭씨온도 {1} 이다.", temperature_F, (temperature_F - 32) * (5f / 9f));

            ////
            //const string desc = "섭씨온도 {0}도는 화씨온도 {1}도 입니다.";
            //float fTemp = 0.0f;
            //Console.WriteLine("화씨 온도를 입력하시오 : ");
            //float.TryParse(Console.ReadLine(), out fTemp);
            //float cTemp = 5.0f / 9.0f * (fTemp - 32.0f);
            //Console.WriteLine(desc, cTemp, fTemp);
            ////

            //// 주사위
            //Random rand = new Random();
            //int DiceRandom = rand.Next(1, 7);  //랜덤
            //int DiceResult = 0;
            //Console.WriteLine("\n랜덤 주사위게임");

            //Console.WriteLine("첫번째 주사위 : {0}", DiceRandom);
            //DiceResult = DiceResult + DiceRandom;

            //DiceRandom = rand.Next(1, 7);  //랜덤

            //Console.WriteLine("두번째 주사위 : {0}", DiceRandom);
            //DiceResult = DiceResult + DiceRandom;

            //Console.WriteLine("두 주사위의 합 : {0}", DiceResult);

            ////시드값을 고정하면 랜덤 함수 써도 같은 값이 나온다.
            ////C++엔 타임 스템프 시드값을 한번도 같지 않게 넣는 것 (현재 시간은 바뀌기 때문에)
            ////Random dice1 = new Random(100);

            //Random dice1 = new Random();
            //Random dice2 = new Random();
            //int dice1value = dice1.Next(1, 6 + 1); //가독성을 위해 표기
            //int dice2value = dice2.Next(1, 6 + 1);

            //Console.WriteLine("주사위의 값 : {0}, {1}", dice1value, dice2value);
            //Console.WriteLine("주사위 합의 값 : {0}", dice1value + dice2value);

            /*      
             * 제어문 소개
             * 프로그램을 이루는 3가의 중요한 제어 구조에는 순차 구조(순차문), 선택 구조(조건문),
             * 반복 구조(반복문)가 있다.
             * 
             * 순차문
             * 프로그램은 기본적으로 Main() 메서드 시작 시점부터 끝 지점까지 코드가 나열 되면 순서대로 실행 후 종료한다.
             * 
             * 제어문
             * 프로그램 실행 순서를 제어하거나 프로그램 내용을 반복하는 작업 등을 처리할 때 사용하는 구문으로
             * 조건문과 반복문을 구분한다.
             * 
             * 조건문(선택문)
             * 조건의 참 또는 거짓에 따라 서로 다른 명령문을 실행할 수 있는 구조이다. 분기문 또는 비교 판단문이라고 하기도 한다.
             * 
             * 반복문
             * 특정 반복문을 지정된 수만큼 반복해서 실행할 때나 조건식이 참일 동안 반복시킬 때 사용한다.
             *  
             * 
             */

            /*
             * if / else 문
             * 프로그램 흐름을 여러 가지 갈래로 가지치기(Branching)할 수 있는데, 이때 if 문을 사용한다.
             * if 문을 조건을 비교해서 판단하는 구문으로 if, else, else 세가지 키워드가 있다.
             * 
             */

            //02.3 예제 #1
            // 두개의 정수 중에서 더 큰수를 찾는 프로그램

            //int numberX, numberY;
            //Console.Write("x 값을 입력하시오: ");
            //int.TryParse(Console.ReadLine(), out numberX);
            //Console.Write("y 값을 입력하시오: ");
            //int.TryParse(Console.ReadLine(), out numberY);

            //if (numberY < numberX)
            //{
            //    Console.WriteLine("x가 y보다 큽니다.");
            //}
            //else
            //{
            //    Console.WriteLine("y가 x보다 큽니다.");
            //}
            //Console.WriteLine();

            /*
             * 02.4 중간점검1
             * 컵의 사이즈를 받아서 100ml 미만은 small,100ml 이상 200ml 미만은 medium, 200ml 이상은 
             * large라고 출력하는 if-else 문을 작성
             */

            //int CupSize = 0;
            //Console.Write("컵 사이즈가 몇 ml 입니까? ");
            //int.TryParse(Console.ReadLine(), out CupSize);

            //if (CupSize < 0) 
            //{
            //    Console.WriteLine("마이너스입니다");
            //}
            //else if (CupSize >= 200)
            //{
            //    Console.WriteLine("large");
            //}
            //else if (CupSize >= 100)
            //{
            //    Console.WriteLine("medium");
            //}
            //else if(CupSize > 0)
            //{
            //    Console.WriteLine("small");
            //}
            //else //0 밖에
            //{
            //    Console.WriteLine("0 입니다");
            //}

            /*
             * LAB 1 비밀코드 맞추기
             * 컴퓨터가 숨기고 있는 비밀코드를 추측하는 게임을 작성
             * 비밀코드는 a~z 사이의 문자
             * 컴퓨터는 사용자의 추측을 읽고서 앞에 있는지, 뒤에 있는지를 알려준다.(즉,사용자에게 힌트를 준다)
             * EX)
             *      컴퓨터의 비밀코드: h (미리 초기화해서 변수에 가지고 있음.)
             *      
             *      비밀코드를 맞춰보세요: c (->User input)
             *      c뒤에 있음
             *      
             *      --프로그램이 종료됨--
             *      비밀코드를 맞춰보세요: h (->User input)
             *      정답입니다.
             *      
             * LAB 2 
             * 세 개의 정수 중에서 큰 수 찾기
             * 사용자로부터 받은 3개의 정수 중에서 가장 큰 수를 찾는 프로그램 작성
             * EX)
             *      3개의 정수를 입력하시오: 20 10 30 (어려운 버전) string.split (메서드)
             *      
             *      1번 정수를 입력하시오: 10
             *      2번 정수를 입력하시오: 20
             *      3번 정수를 입력하시오: 30        (쉬운버전)
             *      
             *      =============================================
             *      가장 큰 정수는 : 30
             */

            const char SECRET_CODE = 'h';
            
            Console.Write("비밀 코드를 맞춰보세요! : ");
            char UserInput = default;
            char.TryParse(Console.ReadLine(),out UserInput);

            if(SECRET_CODE == UserInput)
            {
                Console.WriteLine("정답입니다.");
            }
            else if(SECRET_CODE > UserInput)
            {
                Console.WriteLine("{0} 뒤에 있음", UserInput);
            }
            else
            {
                Console.WriteLine("{0} 앞에 있음", UserInput);
            }
            Console.WriteLine("\t====프로그램 종료\t====");


            ///////
            int firstNumber, secondNumber, thirdNumber = 0;

            string InputText = Console.ReadLine();

            string[] st = InputText.Split(',');

            int.TryParse(st[0], out firstNumber);
            int.TryParse(st[1], out secondNumber);
            int.TryParse(st[2], out thirdNumber);

            if (firstNumber < secondNumber || firstNumber < thirdNumber)
            {
                if (secondNumber < thirdNumber)
                {
                    Console.WriteLine("가장 큰 정수는 : {0}", thirdNumber);
                }
                else if (secondNumber > thirdNumber)
                {
                    Console.WriteLine("가장 큰 정수는 : {0}", secondNumber);
                }
            }
            else
            {
                Console.WriteLine("가장 큰 정수는 : {0}", firstNumber);
            }

//////////////////////// 1번문제관련
            const char s_Code = 'h';

            bool isSmallAlphabat = false;
            bool isBigAlphabat = false;
            bool isAlphabat = false;

            isSmallAlphabat = ('a' <= s_Code && s_Code <= 'z');
            isBigAlphabat = ('A' <= s_Code && s_Code <= 'Z');

            isAlphabat = isSmallAlphabat || isBigAlphabat;

            if(isAlphabat)
            {
                Console.WriteLine("{0}은 알파벳이 맞습니다.", s_Code);
            }
            else
            {
                Console.WriteLine("{0}은 알파벳이 아닙니다.", s_Code);
            }

        }   //main
    }
}
