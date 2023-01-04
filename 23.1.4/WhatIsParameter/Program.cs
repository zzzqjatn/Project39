using System;

namespace WhatIsParameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Description desc_ = new Description();

            //int number1 = 10;
            //int number2 = 20;

            //desc_.valueTypeParam(number1, number2);
            //desc_.refTypeParam(ref number1, ref number2);

            //Console.WriteLine();
            //Console.WriteLine("Main");
            //Console.WriteLine("first : {0} , second : {1}", number1, number2);

            //int number3;
            //desc_.outTypeParam(out number3);
            //Console.WriteLine(" {0} ", number3);

            int[] numbers = new int[5] { 1, 2, 3, 4, 5 };

            desc_.flexibleTypeParam(1, 2, 3, 10, 40, 100, 111, 123, 130);
            //desc_.ArrayParams(new int[] { 1, 2, 3, 4, 5 });
            desc_.ArrayParams(numbers);
        }
    }
}