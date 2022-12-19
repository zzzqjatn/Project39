using System;

namespace WhatisOperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.Write("숫자를 입력하시오 : ");
            //string stringnum = Console.ReadLine();
            //int intnum = 0;
            //int.TryParse(stringnum, out intnum);
            //Console.WriteLine("입력한 숫자 + 10은(는) {0} 입니다.", intnum + 10);

            //string stringBinary = Convert.ToString(10, 2);
            //Console.WriteLine(stringBinary);
            //int intBinary = Convert.ToInt32("0111", 2);
            //Console.WriteLine(intBinary);

            /*
             * 연산자
             * 데이터로 연산 작업을 수행할 때는 연산자(Operator)를 사용한다. 연산자는 기능에 따라 대입, 산술, 관계, 논리, 증감, 조건, 비트,
             * 시프트 연산자 등으로 나누며, 이용형태에 따라 항1개로 연산을 하는 단항(unary) 연산자와 항 2개로 연산을 하는 이항(Binary) 연산자,
             * 항 3개로 연산을 하는 삼항(Ternary)연산자로 나눈다.                                                       {이진 과 같다}
             * 
             * 단항 연산자
             * 단항 연산자는 연산자와 피연산자 하나로 식을 처리한다.
             * ex) [연산자] [피연산자]
             *  + 연산자 : 특정 정수형 변수 값을 그대로 출력한다.
             *  - 연산자 : 특정 정수형 변수 값을 음수로 변경하여 출력한다. 음수값이 들어 있다면 양수로 변환해서 반환한다.
             *  
             *  이항 연산자
             *  이항 연산자는 연산자와 피연산자 2개로 식을 처리한다.
             *  ex) [피연산자1] [연산자] [피연산자2]
             *  
             *  삼항 연산자
             *  삼항 연산자는 식 1개의 항(Expression)과 그 결과에 따른 피연산자 각 1개씩 총 2개 함으로 식을 처리한다.
             *  ex) (식) ? 피연산자1 : 피연산자2
             *  
             *  식과 문
             *  값 하나 또는 연산을 진행하는 구문의 계산식을 식(Expression) 또는 표현식이라고 한다. 표현식을 사용하여
             *  명령 하나를 진행하는 구문을 문(statement) 또는 문장이라고 한다.
             * 
             */

            //단항 연산자
            const int PLUS_FIVE = +5;   //양수 그대로
            const int MINUS_FIVE = -5;  //음수로 변경됨
            const int MINUS_FIVE2 = -5;
            
            //이항 연산자
            const int PLUS_TEN = 5 + 5; //이항연산자 = , + ?

            //삼항 연산자                1                       2                       3
            string compareTen = (PLUS_FIVE > 10) ? "{0}은(는) 10보다 크다" : "{0}은(는) 10보다 크지 않다";
            Console.WriteLine(compareTen, PLUS_FIVE);

            // 변환 연산자
            // () 기호를 사용하여 특정 값을 원하는 데이터 형식으로 변환할 수 있다.
            const int PI_INT = (int)3.141592;
            const float PI_FLOAT = (float)3.141592;
            //실수와 정수 숫자타입은 서로 호환이 용이하나 다른 타입은 tryparse를 사용하자 메모리 오류?가 뜬다.

            Console.WriteLine("PI_INT : {0}, PI_FLOAT : {1}", PI_INT, PI_FLOAT);

            /*
             * 산술, 관계, 논리, 증감, 조건, 비트, 시프트 연산자
             * 
             * 산술 연산자
             * 더하기(Add), 빼기(Subtract), 곱하기(Multiply), 나누기(Divide), 나머지(Remainder, modules) 등
             * 수학적 연산을 하는 사용한다. 보통 정수 형식과 실수 형식의 산술 연산에 사용한다.
             * ex) +,-, *, /, %
             * 
             * 문자열 연결 연산자
             * 산술 연산자 중 하나인 + 연산자는 피연산자의 데이터 타입에 따라 산술 연산 또는 문자열 연결 연산을
             * 수행한다.
             * 
             * + 연산자: 두항이 숫자일 때는 산술(+) 연산 가능, 문자열일때는 문자열 연결가능
             * 
             */

            string addMessage = "string " + "plus " + "string";
            Console.WriteLine(addMessage);

            /*
             * 연산자 오버로딩
             * 숫자랑 문자랑 어떻게 다 연산이 되냐?
             * but
             * 가독성이 안좋다
             * 객체지향에서 바꿔야 할게 많아서
             * 메서드를 통해 그냥 연산하는게 편리하다. (유지보수에) 메서드.이퀄
             * 
             */

            /*
             * 할당 연산자
             * 할당 연산자(Assignment operator)는 변수에 데이터를 대입하는 데 사용한다. 할당 연산자를 대입 연산자
             * 라고도 한다. C#에서 = 기호는 같다는 의미가 아니라 오른쪽에 있는 값 또는 식의 결과를 왼쪽 변수에 할당하라고
             * 지시하는 것이다.
             * 
             * ex) =,+=,-=,*=,/=,%=
             * 
             * 증감 연산자(Increment / Decrement operator)
             * 변수 값을 1 증가시키거나 1 감소시키는 연산자이다. 증감 연산자가 변수 앞에 위치하느냐, 뒤에 위치하느냐에 따라
             * 연산 처리 우선순위가 결정된다.
             * 
             * ++(증가 연산자): 변수 값에 1을 더한다.
             * --(감소 연산자): 변수 값에 1을 뺀다.
             * 
             * 증감 연산자가 앞에 붙으면 전위 증감 연산자라고 하며, 변수 뒤에 붙으면 후위 증감 연산자라고 한다.
             * 
             * 전위(prefix) 증감 연산자: 정수형 변수 앞에 연산자가 위치하여 변수 값을 미리 증감한 후 나머지 연산을 수행한다.
             * 후휘(postfix) 증감  연산자 : 정수형 변수 뒤에 연산자가 위치하여 연산식(대입)을 먼저 실행한 후 나중에 변수값을 증감한다.
             * 
             */

            ////연산에는 우선순위가 있다
            //int number = 3;
            //++number;   //4
            //Console.WriteLine(number--);    //4 처리하고 뺀다
            //Console.WriteLine(number);      //3 

            int number = 0;
            number = number++;              ///????? 0이 대입이 되지만 결국 number 변수값을 올리니까 결과는 1이다. 아님
            //number++;
            Console.WriteLine(number);

            //????????
            //Memory safety 한 언어 가비지컬렉터가 없앤다?
            //C# 에선 값 타입, 참조 타입 2가지로 존재 , 기본값은 리터럴 즉 값타입으로 연산하는데
            //연산을 할때 메모리에 공간을 만들고 연산 후 리턴, 할당했던 메모리 공간은 소멸을 한다
            //number 대입시 메모리 생성 대입하고 리턴 그리고 소멸 한다, 즉 number은 둘다 다른 곳에서 할당 소멸?  
            // ex = ex++ (대입하지말기);
            // 값타입, 참조타입이 어떤식으로 움직이는 알기(메모리 할당 > 연산 > 리턴 > 소멸 등등)
            // 값타입은 통째로 옮길 메모리 할당하고 그걸 계산하기 때문에 상당히 무거운 연산이다.

            /*
             * 관계형 연산자
             * 관계형 연산자(Relational operator) 또는 비교 연산자(Comparative operator)는 두항이 큰지, 작은지
             * 또는 같은지 등을 비교하는 데 사용한다. 관계형 연산자의 결과 값은 논리 데이터 형식인 참(True), 또는
             * 거짓(False)으로 출력된다.
             * ex) <, <=, >, >=, ==, !=
             * 
             * 논리연산자
             * 논리연산자(Logical operator)는 논리곱(AND), 논리합(OR), 논리부정(NOT)의 조건식에 대한 논리 연산을 
             * 수행한다. 연산의 결과값은 참 또는 거짓의 bool 형식으로 변환되어 Boolean 연산자라고도 한다.
             * ex) &&, ||, !
             * 
             * 비트 연산자
             * 비트 연산자(Bit operator)는 정수형 데이터의 값을 이진수 비트 단위로 연산을 수행할 때 사용한다.
             * ex) &, |, ^, ~
             * 
             * 시프트 연산자
             * 시프트 연산자(shift operator)는 정수 데이터가 담겨 있는 메모리의 비트를 왼쪽 또는 오른쪽으로 지정한
             * 비트만큼 이동시킨다.
             * ex) <<, >>
             * 
             * 조건 연산자
             * 조건 연산자(Conditional operator)는 조건에 따라서 참일때와 거짓일 때 결과를 다르게 반환하며,
             * (조건식) ? (식1 또는 값1) : (식2 또는 값2) 형태의 연산자이다. if~else 문의 축약형이기도 하다.
             */

            //논리
            bool isBigger = false;
            isBigger = (5 == 10) || (5 < 10);
            Console.WriteLine(isBigger);

            isBigger = !isBigger;
            Console.WriteLine(isBigger);

            //비트
            int bitNumber = 10; //bit 1010
            int bitResult = 0;
            bitResult = bitNumber & 6; //bit 1111
            Console.WriteLine(bitResult);

            int bitNumber2 = 10; //bit 1010
            int bitResult2 = 0;
            bitResult2 = bitNumber2 & 0b010; // 0`b010 이걸가지고 확인
            Console.WriteLine("bitNumber2가 0010 상태를 가지고 있나요? -> {0}",bitResult2);

            // & 연산을 통해 어떤 상태를 체크하는데 사용가능하다 비트별로 상태를 적고 나중에 체크한다?
            // 0001 가만히 0010 움직임 0100 공격 1000 방어 이런식?

            //시프트연산자 암호화폐? 에서 많이 쓰인다
            int bitNumber3 = 10; //bit 1010
            int bitResult3 = 0;
            bitResult3 = bitNumber3 << 1; // 1010 > 10100 왼쪽으로 한칸 밀어짐
            Console.WriteLine("bitNumber3? {0}", bitResult3);

            //나열(콤마) 연산자
            //콤마를 구분자로 하여 한 문장에 변수 여러 개를 선언할 때 사용한다.
            int intNumber1, intNumber2, intNumber3;

            /*
             * sizeof 연산자
             * sizeof 연산자는 단항 연산자로 데이터 형식 자체를 크기를 구하는 데 사용한다
             * sizeof([데이터타입]) 형태로 사용하며, 운영체제와 CPU 아키텍쳐의 종류에 따라 결과값이
             * 다르게 나올 수 있다.
             */

            Console.WriteLine("int 메모리 크기는 {0}byte 입니다", sizeof(Int32)); //C#의 int 는 Int32와 같다

            /*
             * 연산자 우선순위
             * 연산자 여러개를 함께 사용할 때는 연산자 우선순위(Precedence)에 따라 계산된다.
             * 연산자 우선순위를 잘 모를 때는 일단 괄호 연산자부터 잘 사용하도록 연습하는게 좋다.
             */

            /*
             * input output
             * 1.사용자에게 주어 동사 목적어를 물어보고 이것들을 합하여 (주어 + 동사 + 목적어)로 출력하는 프로그램을 작성해보자
             * (출력문에 관사가 붙어있음)
             * EX)
             *      주어 : input (i)
             *      동사 : input (have)
             *      목적어 : input (book)
             *      
             *      output -> I have a book
             *      
             *  2.사용자의 나이를 물어보고 10년후에 몇살이 되는 지를 출력하는 프로그램을 작성해보자
             *  EX)
             *       나이 : 20
             *       -> 10년후 에는 30살이 됩니다.
             *       
             *  3.직각 삼각형의 양변(양 변은 빗변이 아님) 길이를 읽어서 빗변의 길이를 계산하는 프로그램을 작성
             *  EX)
             *          첫번째 변: 3
             *          두번째 변: 4
             *          
             *          -> 빗변길이 : ???
             *  
             */
            //string Subject = string.Empty;
            //string Verb = string.Empty;
            //string Object_ = string.Empty;

            //Console.Write("주어 : ");
            //Subject = Console.ReadLine();
            //Console.Write("동사 : ");
            //Verb = Console.ReadLine();
            //Console.Write("목적어 : ");
            //Object_ = Console.ReadLine();
            //Console.WriteLine("{0} {1} a {2} ", Subject, Verb, Object_);
            ////관사?

            //string Age = string.Empty;
            //Console.Write("사용자의 나이를 입력해 주세요 : ");
            //Age = Console.ReadLine();
            //int iAge = 0;
            //int.TryParse(Age, out iAge);
            //Console.WriteLine("나이 : {0} \n10년후에는 {1}이 됩니다", iAge, iAge + 10);

            //Console.WriteLine("직각삼각형의 빗변을 구하는 공식입니다. 양변을 입력해주세요.");
            ////첫번째 변
            //Console.Write("첫번째 변 : ");
            //string InputData = Console.ReadLine();
            //double FirstLine = 0f;
            //double.TryParse(InputData, out FirstLine);
            ////두번째 변
            //Console.Write("두번째 변 : ");
            //InputData = Console.ReadLine();
            //double SecondLine = 0f;
            //double.TryParse(InputData, out SecondLine);
            //// a 2제곱 , b 2제곱
            //FirstLine = Math.Pow(FirstLine, 2);
            //SecondLine = Math.Pow(SecondLine, 2);

            //// a`2 + b`2
            //double Result = FirstLine + SecondLine;
            //Result = Math.Sqrt(Result); //루트
            
            //Console.WriteLine("빗변의 길이 : {0} ", Result);

            /*
             * 4.상자의 길이(Length),너비(width),높이(height)를 입력하라는 메시지를 표시
             * 상자의 부피와 표면적을 계산해서 출력하는프로그램
             * EX)
             *      길이 : 3
             *      너비 : 4
             *      높이 : 5
             *      
             *      -> 상자의 부피 : ???
             *      -> 상자의 표면적 : ???
             * 
             * 5.우리나라에서 많이 사용되는 면적의 단위인 평을 평방미터로 환산하는 프로그램 작성
             * 여기서 1평은 3.3058m^2
             * EX)
             *      평: 25.0
             *      평방미터: ???
             * 6. 시,분,초로 표현된 시간을 초 단위의 시간으로 변환하는 프로그램을 작성
             * EX)
             *      시:1
             *      분:1
             *      초:1
             *      전체 초: ???
             * 
             * 7. 퀴즈, 중간고사, 기말고사의 성적을 사용자로부터 입력받아서 성적 총합을 계산하는 프로그램 작성
             * EX)
             *         퀴즈   #1  성적: 10
             *         퀴즈   #2  성적: 20
             *         퀴즈   #3  성적: 30
             *         중간고사   성적: 80
             *         기말고사   성적: 80
             * ====================================
             *  성적 총합 : ???? (그냥 합)
             * ====================================
             *         
             */
            //패딩 , 패드 left right?

            int Lenght, Width, Height = 0;

            int Volume = 0;
            int superficial = 0;

            Console.WriteLine("\n\n상자의 길이,넓이,높이를 통해 부피와 표면적을 구하는 프로그램입니다.");
            Console.Write("길이 : ");
            int.TryParse(Console.ReadLine(), out Lenght);
            Console.Write("높이 : ");
            int.TryParse(Console.ReadLine(), out Width);
            Console.Write("넓이 : ");
            int.TryParse(Console.ReadLine(), out Height);

            Volume = Lenght * Width * Height;
            superficial = (Lenght * Width * 2) + (Lenght * Height * 2) + (Width * Height * 2);

            Console.WriteLine("상자의 부피 : {0} \n상자의 표면적 : {1}", Volume, superficial);

            ////////
            const float ONE_PYUNG = 3.3058F;
            float userInput = 0.0F;
            Console.WriteLine("\n평수로 평당미터 계산프로그램");
            Console.Write("평 : ");
            // { 사용자의 입력을 받는 입력부 / pbs / 2022.12.19 } < 이런식으로 주석을 달면 협력작업에 편하다.
            float.TryParse(Console.ReadLine(), out userInput);
            Console.WriteLine("평당미터 : {0} m", userInput * ONE_PYUNG);

            ////
            Console.WriteLine("\n시간,분,초의 전체 초를 구하는 프로그램입니다.");
            int Hour, Minute, Second = 0;

            Console.Write("시 : ");
            int.TryParse(Console.ReadLine(), out Hour);
            Console.Write("분 : ");
            int.TryParse(Console.ReadLine(), out Minute);
            Console.Write("초 : ");
            int.TryParse(Console.ReadLine(), out Second);

            Console.WriteLine("전체 초 : {0}",(Hour * 3600 + Minute * 60 + Second));
            ////
            int Input_Data, SumResult = 0;

            Console.WriteLine("\n퀴즈,중간고사,기밀고사 성적을 기입하십시오");
            Console.Write("퀴즈\t#1\t성적 : ");
            int.TryParse(Console.ReadLine(), out Input_Data);
            SumResult = SumResult + Input_Data;

            Console.Write("퀴즈\t#2\t성적 : ");
            int.TryParse(Console.ReadLine(), out Input_Data);
            SumResult = SumResult + Input_Data;

            Console.Write("퀴즈\t#3\t성적 : ");
            int.TryParse(Console.ReadLine(), out Input_Data);
            SumResult = SumResult + Input_Data;

            Console.Write("중간고사\t성적 : ");
            int.TryParse(Console.ReadLine(), out Input_Data);
            SumResult = SumResult + Input_Data;

            Console.Write("기말고사\t성적 : ");
            int.TryParse(Console.ReadLine(), out Input_Data);
            SumResult = SumResult + Input_Data;

            Console.WriteLine("==========================");
            Console.WriteLine("성적 총합 : {0}", SumResult);
            Console.WriteLine("==========================");

        }
    }
}