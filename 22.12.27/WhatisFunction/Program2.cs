using System;

namespace WhatisFunction
{
    internal class Program2
    {
        static void Main()
        {
            double result = 0.0;

            Maximum(3, 20, 15);
            SayHello(3);
            
            result = Hypot(5, 5);
            Console.WriteLine(result);
            
            Prime();
            //Prime(2.54321f);

            CallNumber();

            BackString(Console.ReadLine());

        }
        static void Maximum(int x, int y, int z)
        {
            if (x > y && x > z)
            {
                Console.WriteLine("최대값은 {0}", x);
            }
            else if (y > z && y > x)
            {
                Console.WriteLine("최대값은 {0}", y);
            }
            else
            {
                Console.WriteLine("최대값은 {0}", z);
            }
        }

        static void SayHello(int count)
        {
            for(int i = 0; i < count; i++)
            {
                Console.WriteLine("Hello");
            }
        }

        static double Hypot(double x, double y) 
        {
            double total = (x * x) + (y * y);
            return Math.Sqrt(total);
        }

        static void Prime(float Number)
        {
            float total;
            if(2f <= Number && Number <= 100f)
            {
                total = Number % 1;
                if (total > 0)
                {
                    Console.WriteLine("{0}은 소수를 가지고 있습니다. 소수부분 : {1}",Number,total);
                }
            }
            else
            {
                Console.WriteLine("2부터 100사이의 값을 입력주세요");
            }
        }

        static void Prime()
        {
            Console.WriteLine("2 ~ 100 사이의 값 중에서 소수 출력하는 프로그램");

            for(int index = 2; index <= 100;index++)
            {
                if(FindPrime(index))
                {
                    Console.Write("{0} ", index);
                }
            }
            Console.WriteLine();
        }
        static bool FindPrime(int number)
        {
            bool isPrime = true;

            //자신보다 낮은 수로
            for(int index = number - 1; 2 <= index; index--)
            {
                //나눠질 경우(소수가 아님)
                if (number % index == 0)
                {
                    isPrime = false;
                    break;
                }
                else { continue; }
            }
            return isPrime;
        }

        static void CallNumber()
        {
            string callText = string.Empty;
            string ResultText = string.Empty;

            // string 속성 문자열 짜르기 Replace
            //string text = "(821232444)";
            //text = text.Replace("(", "");
            //text = text.Replace(")", "");
            //Console.WriteLine(text);

            while(true)
            {
                callText = Console.ReadLine();
                ResultText = string.Empty;

                if (callText == "quit") break;

                foreach(char one in callText)
                {
                    if(one == '(' || one == ')')
                    {
                        continue;
                    }
                    ResultText += one;
                }
                Console.WriteLine(ResultText);
            }
        }
        
        //hello world
        //dlrow olleh


        static void BackString(string Text)
        {
            string temp = string.Empty;

            for(int i = Text.Length; 0 < i; i--)
            {
                temp += Text[i - 1];
            }
            Console.WriteLine(temp);
        }

    }   //class
}
