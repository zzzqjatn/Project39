using System;

namespace WhatisProgram
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // 한줄 주석이다
            /*
             * 여러 줄 주석이다
             * 주석은 메모하고 싶을 때 쓰는 기능이다.
             * 영어로 주석은 comment
             */

            /* 프로그래밍이란 무엇인가?
             * 
             * 컴퓨터는 하드웨어(Hardware)와 소프트웨어(software)로 구성된 하드웨어는 pc, 스마트폰과 같은
             * 물리적으로 존재하는 장치를 의미한다 소프트웨어는 이러한 하드웨어에 설치된 운영체제, 앱 등을 의미한다.
             * 
             * 프로그램(program)이란 우리가 하고자 하는 작업을 컴퓨터에게 전달하여 주는 역활을 하는 소프트웨어를 의미한다
             * 프로그램 안에는 "무엇을 어떤식으로 해라" 와 같은 형태의 명령어(Instruction) 들이 들어있다.
             * 
             * 소프트웨어를 만드는 행위를 프로그래밍(programing) 또는 코딩(Coding) 이라고 한다.
             * 
             * 컴퓨터가 알아듣는 언어는 한가지 뿐이다. 0, 1의 형태로 구성되 있으며 기계어(Machine language)라고 부른다.
             * 과거 초기 형태의 컴퓨터는 이러한 기계어를 사용한 프로그래밍을 했었다.
             * 기계어는 인간에게 상당히 불편한(난해한) 언어기 때문에 사람이 이해하기 쉬운 프로그래밍 언어가 만들어지게 된다.
             * 프로그래밍 언어의 예약어 (keyward)와 문법으로 소프트웨어를 만드는 사람을 프로그래머(programmer) 또는
             * 개발자(developer)라고 한다.
             * 
             * 프로그래밍 언어의 문법에 맞게 작성한, 텍스트로 된 명령 집합을 코드(code) 또는 소스(source) 라고 한다.
             * 소스코드를 기계어 번역하는 작업을 컴파일(compile)이라고 한다. 이러한 작업을 하는 소프트웨어를 컴파일러(compiler)라고 한다
             * 
             * 프로그래밍을 하는 과정은 다음과 같다.
             * 1.텍스트 에디터로 소스를 작성하여 파일로 작성한다.   ex) .cs파일
             * 2.소스파일을 컴파일하여 실행 프로그램을 생성한다.    ex) .exe파일
             * 3.프로그램을 실행한다.
             * 이중에 1, 2 단계를 합쳐서 흔히 빌드(build)라고 한다.
             * 
             * 프로그래밍 과정 중 발생한 오류를 버그(Bug)라고 한다.
             * 오류를 탐색하고 수정하는 과정을 디버그(Debug), 디버깅(Debugging) 또는 트러블 슈팅(Trouble shooting) 이라고 한다.
             * 
             * 
             * C#의 경우 
             * C# 언어로 코딩 -> IL(Intermediate Language)코드로 변환 -> 기계어
             * ildasm(il코드를 볼수 있는 것) 도구 명령줄 개발자 명령 프롬프트 ildasm 
             * 
             * C#의 특징
             * C#은 .Net(닷넷)을 위한 많은 언어 중 하나로, 마이크로소프트의 닷넷 플렛폼을 기반으로 한다.
             * 절차적 언어와 객체지향적 언어의 특징, 그리고 함수형 프로그래밍 스타일을 제공하는 다중 패러다임
             * 프로그래밍 언어이다
             * 
             * C#은 C,C++, Java, Javascript와 기초문법이 비슷하다.
             * C#은 자동으로 메모리를 관리한다. (Garbage Collection 기능을 제공)
             * C#은 컴파일 기반 언어이다.
             * C#은 강력한 형식(strongly typed) 언어이다.
             * 강력한 형식{데이터 와 데이터 타입에 따라 서로 맞지 않을 경우 피드백 해준다}
             * C#은 Generic 과 LinQ 등 편리한 기능을 제공한다.
             * 
             * .Net(닷넷)
             * 닷넷 프레임워크와 닷넷 코어를 합쳐서 편하게 닷넷이라고 한다.
             * 닷넷은 소프트웨어 프레임워크로 응용프로그램의 개발속도를 높이는데 도움이되는 API(Application Programming Interface) 및 서비스 모음이다.
             * 
             * 프레임워크 : 응용프로그램의 개발속도를 높이는데 도움이되는 API(Application Programming Interface) 및 서비스 모음이다.
             * 
             * 
             * 함수, 라이브러리, API 란?
             * 함수 : 프로그램에서 사용하기 위한 기능의 단위를 의미한다. 보통 하나의 함수는 하나의 기능을 한다.
             * 라이브러리 : 어떠한 기능을 구현할 때 도움이 되는 기능, 함수의 모음이다.
             * API : 어떠한 기능을 구현할때 도움이 되도록 문서와 함께 제공되는 라이브러리, 함수의 모음이다.
             * 
             * 플렛폼 : 프로그램을 실행하기 위한 배경 환경 또는 운영체제를 의미한다.
             * 
             * 프레임워크 > API > 라이브러리 > 함수
             * 
             * MSDN에서 찾아보기 기능적인 부분은 기억하기 키워드 위주 공부 , 추론하는 식으로 찾기
             */


            /*
             * C#의 기본 코드 구조
             * C# 프로그램은 class와 Main() 메서드가 반드시 있어야 하고, 하나 이상의 문(statement)이 있어야 한다.
             * C#의 기본코드는 위쪽에 네임스페이스 선언부와 Main() 메서드가 오고, 중괄호 시작과 끝을 사용하여
             * 프로그램 범위(scope)를 구분한다
             * 
             * 네임스페이스 : 자주 사용하는 네임스페이스를 위쪽에 미리 선언해 둘 수 있다.
             * Main() 메서드 : 프로그램의 시작 지점이며, 반드시 있어야 한다.
             * 중괄호 () , {} : 프로그램 범위를 구분 짖는다.
             * 세미콜론(;) : 명령어(문, 문장)의 끝을 나타낸다.
             * 
             * Main() 메서드
             * 메서드(Method) : 클래스에서 제공하는 멤버 함수를 의미한다.
             * Main() 앞에 static 키워드가 있어 개체를 생성하지 않고 바로 실행할수 있다.
             * Main() 메서드가 2개이면 "프로그램 진입점이 2개 이상 정의되어 있습니다." 라는 에러 메시지가 출력되어 프로그램이 컴파일되지 않는다.
             * 
             * 대, 소문자 구분하기
             * C#은 대, 소문자를 구분한다. 정확히 입력하지 않으면 에러가 발생한다.
             * 
             * 
             * 문법, 스타일, 패턴
             * 문법(Syntex) : 프로그래밍을 하기 위해 반드시 지켜야 하는 규칙(Rule)이다. 언어별로 다르다.
             * 스타일(style) : 프로그래밍 가이드라인(GuideLine)이다.
             * 패턴(Pattern) : 자주 사용하는 규칙과 스타일 모음이다.
             * 
             * 정규화된 이름
             * 정규화된 이름(Fully qualified names)은 아래와 같이 네임스페이스 이름과 형식 이름까지 전체를 지정하는 방식이다.
             * System.Console.WriteLine("hello, world");
             */

            /*
             출력문 : 명령 프롬프트에 출력하는 구문
             주석문 : 실행에 영향을 주지 않는 코드 설명문
              - 한 줄 주석
              - 여러 줄 주석

            Console.Write(); 글쓰기
            Console.WriteLine(); 글쓰기 줄 바꿈까지

            들여쓰기 : 프로그램 소스 코드의 가독성을 위해서 사용하는 일반적인 들여쓰기 규칙
                        보통 4칸의 공백(space) 또는 Tab 을 사용하지만 혼용하면 안된다.
            공백처리 : C#에서 명령어 사이, 기호와 괄호 사이의 공백, Tab, 줄바꿈은 무시된다.

            이스케이프 시퀸스
            C#은 WriteLine() 메서드에서 사용할 확장 문자를 제공하는데, 이를
            이스케이프 시퀸스(Escapesequence)라고 한다.
            역슬래쉬(\) 기호와 특정문자를 조합하면 특별한 기능을 사용 할 수 있다.
            어떤 이스케이프 시퀸스가 있는지 검색하면 알 수 있다.
             */

            Console.Write("hello, world! \n");
            Console.WriteLine("hello, world");
            Console.WriteLine("hello, world");

            /*
             * 문자열 보간법
             * 문자열 보간법(string interpolation) 또는 문자열 템플릿(string Template)이라고도 한다.
             * 문자열을 묶여서 처리하기 위한 기능이다. 기존에는 string.Format() 메서드를 주로 사용했었는데.
             * C# 6.0버전부터 $"{}" 형태로 간결하게 제공하고 있다.
             * 
             * + 연산자가 무슨 타입인지 확인때문에 더 느리다
             */
              Console.WriteLine("hello, world" + "world!");
             /* 
             * 더 빠르다
             */ Console.WriteLine("{0} , {1}","Hello","world");
              
              string Hello = "hello";
              string World = "world";
              Console.WriteLine("{0} , {1}",Hello,World);
              Console.WriteLine($"{Hello} , {World}");
              
        
              const int THREE_NUMBER = 3;
              const string ODD_WORD = "홀수";
              Console.WriteLine($"{THREE_NUMBER}은(는) {ODD_WORD}입니다.");
              
              string stringFormat = string.Format("{0}은(는) {1}입니다.", THREE_NUMBER,ODD_WORD);
              Console.WriteLine(stringFormat);
              
             // 이렇게 문자열을 + 연산하면 특히 느리다
              string stringPlus = THREE_NUMBER + "은(는) " + ODD_WORD + "입니다.";
              Console.WriteLine(stringPlus);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            string Tt1 = "이름 : 박범수";
            string Tt2 = "과정명 : (게임콘텐츠제작) 모바일 게임 개발자 양성과정 C";
            string Tt3 = "학습과정 : (전공) 게임 프로그래밍 기초 기술";
 
            Console.WriteLine($"{Tt1}");
            Console.WriteLine($"{Tt2}");
            Console.WriteLine($"{Tt3}");

            /*
             * 변수
             * 프로그램에서 값을 다루려면 데이터를 메모리에 잠시 보관해 놓고 사용할수 있는 임시 저장공간이 필요하다.
             * 이때 변수를 사용한다. 변수를 사용하는 순서는 선언(메모리에 공간을 확보)하고 정의(대입,할당)하여
             * 사용하는 것이다. 변수는 데이터 형식, 변수의 이름, 대입한 값으로 이루어져 있다.
             * 
             * 변수 선언: 메모리에 데이터를 저장할 공간을 확보하는 것이다.
             * 변수 정의: 확보한 공간에 값을 정의하는 것이다.
             * 변수 초기화: 변수를 선언한 직후, 초기값으로 정의하는 것이다. 초기화는 변수의 초기값을 명확하게 정의하여
             *              원치 않는 논리적인 오류를 방지하는 역활을 한다.
             * 
             *  //본인의 상식을 겹쳐 개념을 장기기억으로 기억하기
             * 
             * 
             * 
             */

            // Memory Safety

            int number; //선언
            number = 100; //정의

            int number2 = 1; //초기화

            Console.WriteLine("\n{0}", number2);
                                                                            //byte 단위
            Console.WriteLine("int는 얼마 만큼의 메모리를 할당하나요? -> {0}", sizeof(int));

            /* 
             * 이진수
             * bit: 0 또는 1을 표현할 수 있는 최소 단위
             * [0][0]
             * [0][1]
             * [1][0]
             * [1][1]
             * 
             * byte 숫자를 세는 단위. 8bit = 1byte (0000 0000) 요런식
             * 
             * int 가 4바이트인 이유 원래는 2바이트 였음 아키텍쳐라는 것이 있고 이게 x32 기반 운영체제에서 x64로 올라오면서 이렇게 됨
             * 
             * 변수 사용할 때 주의사항(규칙)
             * 변수의 이름을 지을 때는 다음 규칙을 지켜야한다
             * 변수의 첫 글자는 반드시 문자로 지정한다. 숫자는 변수의 첫 글자로 사용 할 수 없다.
             * 길이는 255자 이하로 하고 공백을 포함 할 수 없다.
             * 영문자와 숫자,언더스코어(_) 조합으로 사용하며, 기타 특수 기호는 사용할 수 없다.
             * C#에서 사용하는 키워드는 사용할 수 없다.
             * 변수는 대, 소문자를 구분하고, 일반적으로 소문자로 시작한다.
             * 변수는 타인이 보더라도 이해 할수 있는 이름으로 사용한다.
             * 
             * 데이터 형식
             * 변수에 저장할 수 있는 데이터의 종류를 자료형(Data type)이라고 한다.
             * int, string, bool, double, object 등 C#에서 기본으로 제공하는 데이터 형식을
             * 기본형식(primitive type)이라고 한다
             * 
             * int: 정수형 데이터 타입 (음수, 양수, 0)
             * float: 실수형 데이터 타입(부동소수점 형태 / 3.14)
             * bool : 논리값을 가지는 데이터 타입 (참, 거짓)
             * char : 한 문자를 가지는 데이터 타입('a')
             * string : 문자열 ("hello world")
             * object : C#에서 모든 자료형의 부모형 데이터 타입 (모든 데이터를 저장 가능)
             * 
             * 
             * 
             */

            /*
             * 상수
             * 변수를 선언할 때 앞에 const 키워드를 붙이면 상수(constant)가 된다. 한번 상수로 선언된 변수는
             * 다시 값을 바꿀수 없고, 반드시 선언과 동시에 초기화 해야 한다. 이러한 const 키워드를 붙인 변수를
             * 상수 또는 지역(Local) 상수라고 한다. 상수는 주로 대문자로 표현한다.
             * 
             * 리터럴
             * 변수에 저장하기 위해 직접 대입하는 값 자체를 리터럴(Literal)이라고 한다.
             * 정수형 리터럴: 숫자 그대로 표현한다. ex) 1234
             * 실수형 리터럴: 대문자 F 또는 소문자 f를 접미사로 붙여 표현한다. ex) 3.14F
             * 문자형 리터럴: 작은 따옴표로 묶어서 표현한다.                  ex) 'A'
             * 문자열 리터럴: 큰 따옴표로 묶어서 표현한다.                    ex) "Hello"
             * 
             * 숫자 구분자 사용
             * C# 7.0 버전부터는 언더스코어(_) 문자를 사용하는 숫자 구분자(Digit separator)를 제공한다
             * 숫자 형식을 표현할 때 언더스코어 문자를 무시한다. 이를 이용하면 긴 숫자를 표시할 때 가독성을 높일수 있다.
             * 
             */

            //const int CONST_FIVE = 5;
            ////const float PI = 3.14F;

            //int bigNumber = 110_000 - 1000;
            //Console.WriteLine("Big Number - 1000은 값이 변하지 않을까? {0}",bigNumber);

            //bool boolType;
            //boolType = true;
            //boolType = false;

            ////정수형 변수로 반지름을 선언, 상수로 원주율을 선언한 다음 원의 넓이 출력
            //int Radius = 5;
            //const float PI = 3.14F;
            //float CircleResult = 0f;
            //CircleResult = (Radius * Radius) * PI;

            //Console.WriteLine();
            //Console.WriteLine("원의 넓이 구하기 \n반지름 : {0}\n원주율 : {1}\n원의 넓이는 {2}", Radius, PI, CircleResult);


            /*
             * null키워드
             * C#에서 null 키워드는 '아무것도 없는 값'을 의미한다.
             * 
             * null 가능 형식(nullable)
             * 숫자 형식의 변수를 선언할 때 int?,float? 와 같이 물음표(?) 기호를 붙이면 null 가능형식으로
             * 변경된다. 이러면 null 가능 형식에는 아무런 값도 없음을 의미하는 null을 대입할 수 있다.
             * 
             */

            int? nullNumber = null;
            Console.WriteLine(nullNumber);
            string nullstring = string.Empty;

            /*
             * 자동 타입 추론(Automatic type deduction)
             * 변수에 대입하는 값의 데이터 타입이 명시적이거나 명확할때, 데이터 타입을 명시하지 않고 생략할 수 있다.
             * 자동 타입 추론이란 컴파일러가 대입하는 값 또는 변수의 데이터 타입으로 다른 한 쪽의 데이터 타입을 추론하는 기능을 의미한다.
             * 
             * default 값
             * C# 6.0 버전부터는 자동 타입 추론으로 기본 형식에 default 값을 대입할 수 있다.
             * 기본 형식마다 정해진 default 값이 존재한다.
             * 
             * 
             */
            //데이터 타입으로 리터럴이 무슨 타입인지 하는 방식
            int numberValue = default;
            string stringValue = default;
            char charValue = default;
            float floatValue = default;

            //리터럴 타입으로 데이터 타입이 무슨 타입인지 하는 방식
            var autoVaribleInt = 10;
            var autoVaribleFloat = 3.14f;
            var autoVaribleDouble = 3.14;

            /*
             * 열거형 형식
             * C#에서 열거형(Enumeration) 형식은 기억하기 어려운 상수들을 기억하기 쉬운 이름 하나로 묶어 관리하는 표현 방식이다.
             * 일반적으로 열거형으로 줄여 말한다. 열거형은 enum 키워드를 사용하고 이늄 또는 이넘으로 읽는다.
             * 열거형은 클래스 범위 내에 정의해야 하며, 메서드 범위 안에는 정의할 수 없다.
             * 
             * 
             * 
             */

            Align align = Align.TOP;
            align = Align.LEFT;

            Console.WriteLine(align);

            /*
             * 입출력에 대해서
             * 프로그램을 실행할때마다 서로 다른 값을 입력받으려면 콘솔에서 입력한 값을 변수에 저장할 수 있어야 한다.
             * 키보드로 입력받고 모니터로 출력하는 일반적인 내용을 표준 입출력(Standard input/output)이라고 한다
             * 
             * System.Console.ReadLine(): 콘솔에서 한 줄을 입력받는다.
             * System.Console.Read() :    콘솔에서 한 문자를 정수로 입력받는다.
             * System.Console.ReadKey():  콘솔에서 다음 문자나 사용자가 누른 기능 키를 가져온다.
             * 
             * 
             */

            //Console.Write("이름을 입력하시오 ");
            //string yourname = string.Empty;
            //yourname = Console.ReadLine();

            //Console.WriteLine("안녕하세요 {0}", yourname);

            /*
             *  형식 변환
             *  Console.ReadLine() 메서드를 사용하여 콘솔에서 입력받은 데이터는 문자열이다. 문자열 대신 정수나 실수
             *  데이터를 입력받고 싶다면 입력된 문자열을 원하는 데이터 형식으로 변환할 수 있어야 한다.
             *  
             *  키워드 : 캐스팅 연산자, 암시적(묵시적) 형변환, 명시적 형변환
             *  
             *  3가지의 형변환 하는 법
             *  
             */

            //Console.Write("숫자를 입력하시오 : ");
            //string stringNumber = Console.ReadLine();
            //int intNumber = Convert.ToInt32(stringNumber);
            ////int intNumber2 = (int)stringNumber;
            //int intNumber2 = int.Parse(stringNumber);

            ////추천스타일
            //int intNumber3 = default;
            //int.TryParse(stringNumber, out intNumber3);

            //Console.WriteLine("입력된 숫자 + 10은 {0} 입니다.", intNumber3 + 10);


            //실수형 변수로 반지름을 사용자 입력 받고 실수형 상수로 원주율을 선언한 다음에 구의 겉넓이, 구의 부피 출력하는 프로그램 작성
            /*
             * 출력예시
             * 1.사용자에게 무엇을 입력해야 하는지 알려주는 출력문
             * 2. 구의 겉넓이 : 숫자
             * 3. 구의 부피 : 숫자
             */

            Console.WriteLine();
            Console.WriteLine();



            Console.WriteLine("구의 겉넓이 와 구의 부피 구하기");
            Console.Write("반지름을 입력해 주세요 : ");
            string RadiusInput = Console.ReadLine();

            float ResultRadius = default;
            float.TryParse(RadiusInput, out ResultRadius);
            const float PI = 3.14F;

            float ResultArea = 4 * (PI * (ResultRadius * ResultRadius));
            float ResultVolume =  4f/3f * PI * (ResultRadius * ResultRadius * ResultRadius);
            //실수 데이터 타입에서 정수 계산시 실수로 변경해야 끝까지 나눠져서 정확한 값 나온다

            Console.WriteLine("\n구의 겉넓이 : {0} \n구의 부피 : {1}", ResultArea, ResultVolume);


        }       //main()
        enum Align { TOP, BOTTOM, LEFT, RIGHT, RANDOM, VALUE };
    }      //class program
}       // namespace WhatIsProgramming