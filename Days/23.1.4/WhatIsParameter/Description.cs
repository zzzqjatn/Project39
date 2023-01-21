using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsParameter
{
    internal class Description
    {
        public void ParameterDesc()
        {
            /*
             * 메서드의 매개변수 전달 방식
             * 메서드의 매개변수 전달 방식은 사용하는 방식에 따라 네 가지로 분류한다.
             * 지금까지 기본으로 사용한 매개변수 전달 방식은 값 전달 방식이다.
             * 이에 추가해서 ref 키워드를 사용하는 참조 형 전달 방식과 out 키워드를 사용하는 반환형 전달 방식,
             * 마지막으로 params 키워드를 사용하는 가변형 전달 방식이 있다. 정리하자면 다음과 같다.
             * 
             *  - 값 전달 방식 : 말 그대로 값을 그대로 복사해서 전달하는 방식을 의미한다.
             *                  지금까지 사용해 왔던 매개변수 방식이다.
             *  
             *  - 참조 전달 방식(ref) : 실제 데이터는 매개 변수가 선언된 쪽에서만 저장하고, 호출된 메서드에서는 
             *                         참조만 하는 형태로 변수 이름만 전달하는 형식이다.
             *                         
             *  - 반환형 전달 방식(out) : 메서드를 호출하는 쪽에서 선언만 하고, 초기화 하지 않고 전달하면
             *                           메서드 쪽에서 해당 데이터를 초기화해서 넘겨주는 방식이다.
             *                           
             *  - 가변형 전달 방삭(params) : 1개 이상의 매개변수를 가변적으로 받을 때 매개변수를 선언하면
             *                              params 키워드를 붙인다. 가변적이라는 것은 같은 타입으로 하나 이상을
             *                              받을 수 있도록 배열형으로 받는 다는 의미이다. 가변 길이 매개변수는 반드시
             *                              매개변수를 선언할 때 마지막에 위치해야 한다.
             */
        }   //ParameterDesc()

        public void valueTypeParam(int firstNumber, int secondNumber)   //변수값을 복사해서 사용하는 것이기 때문에 원본값은 그대로
        {
            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;

            Console.WriteLine("first : {0} , second : {1}", firstNumber, secondNumber);
        }

        public void refTypeParam(ref int firstNumber,ref int secondNumber)  //변수의 바로가기 주소를 주어 실제로 그 원본값이 바뀐다
        {
            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;

            Console.WriteLine("first : {0} , second : {1}", firstNumber, secondNumber);
        }

        public void outTypeParam(out int number)  //지역변수로 함수 내부에서 데이터를 처리하고 결과 값을 줄때? (데이터 검사용으로 좋을 것 같다)
        {
            number = 10;
        }

        public void flexibleTypeParam(params int[] numbers) //입력받을 매개변수의 양이 계속 변할 때, 가변할때 응용적으로 쓸수 있는 값처리
        {
            foreach(int number in numbers)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();
        }

        public int[] ArrayParams(int[] numbers)
        {
            foreach (int number in numbers)
            {
                Console.Write("{0} ", number);
            }
            Console.WriteLine();

            return numbers;
        }
    }
}
