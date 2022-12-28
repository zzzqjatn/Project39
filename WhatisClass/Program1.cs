using System;
using System.Net.Http.Headers;

namespace WhatisClass
{
    internal class Program1
    {
        static void Main()
        {
            /*
             * C#의 모든 코드에 반드시 들어가는 클래스(Class) 알아보자.
             * 
             * 클래스 소개하기
             * 클래스는 지금까지 작성한 모든 예제에서 기본이 되는 C#의 핵심코드이다. 
             * public class [클래스 이름]
             * {
             *      - 무언가 내용
             * }
             * 같은 코드 블록을 사용하여 정의할 수 있다. 클래스를 정의하는 전반적인 내용과 클래스를 내부 또는
             * 외부에 올 수 있는 구성요소는 다음 장에서 살펴볼 것
             * 
             * 클래스의 구성요소는 많지만 그 중에서 속성과 메서드(함수)를 가장 많이 사용한다. 속성은 데이터를 다루고,
             * 메서드는 로직을 다룬다.
             * - 클래스
             *  - 속성: 데이터
             *  - 메서드: 로직
             *  
             * 클래스는 그 의미에 따라, 이미 닷넷 프레임워크에서 만들어 놓은 내장 형식(built-in type)과 사용자가
             * 직접 클래스 구조를 만드는 사용자 정의 형식(User defined type)으로 구분할 수 있다. 예를 들어
             * Console, String, Math 등 클래스는 내장 형식이다. 그리고 class 키워드로 product, Note,
             * User, Group 처럼 새로운 형식(기존에 제공되지 않는)을 정의할 수 있는데, 이를 사용자 데이터 형식
             * 이라고 한다.
             * 
             * 클래스 만들기
             * 클래스를 정의하면 다음과 같다.
             *  - 클래스는 개체를 생성하는 틀(템플릿)이다.
             *  - 클래스는 무엇인가를 만들어 내는 설계도이다.
             * 클래스는 C# 프로그래밍의 기본 단위로 새로운 개체(실체)(instance)를 생성하는 설계도(청사진) 역활을 한다.
             * 예를 들어 자동차라는 개체(object)를 만들려면 자동차 설계도가 필요하다. 이와 마천가지로
             * 프로그래밍에서도 설계도가 필요한데, 이 역활을 하는 것이 클래스(class)이다. 즉, 클래스는
             * 개체를 생성하는 틀(템플릿)이며, 더 간단히 말하자면 "무엇인가를 만들어 내는 설계도"이다.
             * 
             * 클래스 선언하기
             *  - 클래스 이름은 반드시 대문자로 시작한다.
             * 
             * public class [클래스 이름]
             * {
             *      // 클래스 내용을 구현
             *      - 속성 -> 변수
             *      - 메서드 -> 함수
             * }
             */
            //ClassNote classnote_ = new ClassNote();
            //ClassNote.Run();
            //static에서 staic 메서드일땐 직접적으로 바로 호출할 수 있다.

            /*
             * 클래스를 여러개 사용할 때는 public 키워드를 써야 한다. public 키워드가 붙은 클래스는 
             * 클래스 외부에서 해당 클래스를 바로 호출해서 사용할 수 있도록 공개되었다는 의미이다.
             * 반대 의미는 private 키워드를 사용한다.
             * 
             * static과 정적 메서드
             * C#에서는 static을 정적으로 표현한다. 의미가 같은 다른 말로 표현하면 공유(shared)이다.
             * static이 붙는 클래스의 모든 멤버는 해당 클래스 내에서 누구나 공유해서 접근할 수 있다.
             * 메서드에 static이 붙는 메서드를 정적 메서드라고 하는데, 이를 공유 메서드(shared method)라고도
             * 한다.
             * 
             * 정적 메서드와 인스턴스 메서드
             * 닷넷의 많은 API처럼 우리가 새롭게 만드는 클래스는 메서드를 포함한 각 멤버의 static 키워드
             * 유무에 따라 정적 또는 인스턴스 멤버가 될 수 있다.
             * 
             */

            //ClassNote.staticMethod();
            //ClassNote.instance(); //오류남 공유되지않음

            //ClassNote classNote_ = new ClassNote(); // 인스턴스 화 한것이다.
            //메모리에 클래스(ClassNote)라는 객체를 올려놓는 것 == 인스턴스화
            //classNote_.InstanceMethod();    //인스턴스메서드를 사용가능해짐

            /*
             * 클래스 시그니처
             * 클래스는 다음 시그니처를 가진다.
             * 
             * public class Car {}
             * 
             * public 액세스 한정자를 사용하면 기본값인 internal을 갖는데 internal은 해당 프로그램 내에서
             * 언제든지 접근 가능하다. 하지만 학습 단계에서는 클래스에 public만 사용해도 괜찮다. 그리고 class
             * 키워드 다음에 클래스 이름이 오는데, 클래스 이름은 대문자로 시작하는 명사를 사용한다.
             * 클래스 본문 또는 몸통(Class Body)을 표현하는 중괄호 안에는 지금까지 배운 메서드와 앞으로 다룰
             * 필드, 속성, 메서드, 생성자, 소멸자 등이 올 수 있는데, 이 모두를 가리켜 클래스 멤버라고 한다.
             * 
             * (액세스 한정자 : public , internal , private)
             * 
             * 클래스 이름 짖기
             * 클래스 이름은 의미 있는 이름을 사용하면 좋다. 이름은 명사를 사용하며, 첫 글자는 꼭 대문자여야 한다.
             * 또한 클래스 이름을 지을 떄는 축약형이나 특정 접두사, 언더스코어(_) 같은 특수문자는 쓰지 않는다.
             *  - 클래스 이름은 누구나 알기 쉽게
             *  - 간단하고 명확해야 한다
             * 
             * 클래스의 주요 구성 요소
             * 클래스의 시작 과 끝, 즉 클래스 블록 내에는 다음 용어(개념)들이 포함될 수 있다. 일반적으로
             * 클래스 구성 요소를 가리킬 때 클래스 멤버라는 용어와 혼용해서 사용한다.
             * 
             * -필드(Field) : 클래스의 부품 역활을 한다. 클래스 내에 선언된 변수나 데이터를 담는 그릇으로,
             *                개체 상태를 저장한다.
             * -메서드(Method) : 개체 동작이나 기능을 정의한다.
             * -생성자(Constructor) : 개체 필드를 초기화한다. 즉, 개체를 생성할 때 미리 수행해야하는 기능을
             *                        정의한다.
             * -소멸자(Destructor) : 개체를 모두 사용한 후 메모리에서 소멸될 때 실행한다.
             * -속성(Property) : 개체의 색상, 크기, 형태 등을 정의한다.
             * 
             * 액세스 한정자
             * 클래스를 생성할 때 public, private, internal, abstract, sealed 같은 키워드를 붙일 수 있다.
             * 이를 액세스 한정자라고 한다. 액세스 한정자는 클래스에 접근 할 수 있는 범위를 결정하는 데 도움이
             * 된다. 특별히 지정하지 않는 한 기본적으로 public 액세스 한정자를 사용하면 된다.
             */

            //Random random = new Random();
            //int randomNumber = random.Next(1, 100 + 1);

            //Console.WriteLine();
            //Console.WriteLine();
            //LotoNumber lotonum = new LotoNumber();
            //lotonum.Run();
            //Console.WriteLine();
            //Console.WriteLine();

            //LottoCreator mylottoCreator = new LottoCreator();
            //mylottoCreator.PrintLottoNumber();

            //Rockpaperscissors game = new Rockpaperscissors();
            //game.RockpaperscissorsGame();

            //TrumpCard trumpCard = new TrumpCard();
            //trumpCard.SetupTrumpCards();
            //trumpCard.ReRollcard();

            CardGame Game = new CardGame();
            Game.gameBegin();
        }   // Main()
    }   // class program1
    
    public class ClassNote
    {
        public static void Run()
        {
            Console.WriteLine("ClassNote 클래스의 Run 메서드");
        } 
        private static void Run2()
        {
            Console.WriteLine("ClassNote 클래스의 Run 메서드");
        }

        public static void staticMethod()
        {
            Console.WriteLine("ClassNote 클래스의 static 메서드");
        }
        public void InstanceMethod()
        {
            Console.WriteLine("ClassNote 클래스의 instance 메서드");
        }
    }

    public class LotoNumber
    {
        public void Run()
        {
            Random random = new Random();

            int[] numbers = new int[6];
            int number = 0;
            bool isEnd = false;
            bool isLoop = false;

            while (!isEnd)
            {
                //랜덤수 넣기
                for (int i = 0; i < 6; i++)
                {
                    number = random.Next(1, 45 + 1);
                    numbers[i] = number;
                }

                //검수 과정
                isLoop = false;
                for (int i = 0; i < 6; i++) //기존 순서대로
                {
                    if (isLoop == false)
                    {
                        for (int j = i + 1; j < 6; j++) //기존 순서의 한개 뒤의 값과 반복 비교
                        {
                            if (numbers[i] != numbers[j])
                            {
                                isEnd = true;
                            }
                            else
                            {
                                isEnd = false;
                                isLoop = true;
                                break;
                            }
                        }
                    }
                    else break;
                }
            }

            //최종 출력문
            for (int i = 0; i < 6; i++)
            {
                Console.Write("{0} ",numbers[i]);
            }

        }
    }

    //! 로또 번호 생성기
    public class LottoCreator
    {
        int[] lottoNumbers;

        public void PrintLottoNumber()
        {
            // 여기서 로또 번호 출력 할 것임

            // 로또 번호를 생성해서 배열에 초기화
            lottoNumbers = new int[45];
            for(int index = 0; index < 45; index++)
            {
                lottoNumbers[index] = index + 1;
            }   // loop: 로또 번호를 순서대로 초기화하는 루프

            //100번 섞는다
            for (int index = 0; index < 100; index++)
            {
                lottoNumbers = shuffleOnce(lottoNumbers);
            }

            //앞에서 6개만 뽑아내도 중복없이 나올수 있다.
            for(int index = 0; index < 6; index++)
            {
                Console.Write("{0} ", lottoNumbers[index]);
            }
            Console.WriteLine();

        }   //PrintLottoNumber()

        //! 배열을 1번 섞는 함수
        private int[] shuffleOnce(int[] lottoNumbers_)
        {
            Random random = new Random();
            int sourIndex = random.Next(0, lottoNumbers_.Length);
            int destIndex = random.Next(0, lottoNumbers_.Length);

            int tempVarible = lottoNumbers_[sourIndex];
            lottoNumbers_[sourIndex] = lottoNumbers_[destIndex];
            lottoNumbers_[destIndex] = tempVarible;

            return lottoNumbers_;
        }   //shuffleOnce()
    }

    public class Rockpaperscissors
    {
        public void RockpaperscissorsGame()
        {
            //                         가위 바위 보
            int[] Handcase = new int[3] { 1, 2, 3 };
            string[] printhand = new string[4] {" ", "가위", "바위", "보" };
            int ComputerHand = 0;
            int MyHand = 0;
            int Wincase = 0;

            for(int index = 0; index < 20;index++)
            {
                Handcase = SwapHand(Handcase);
            }
            //컴퓨터가 내는값
            ComputerHand = Handcase[0];

            Console.WriteLine("컴퓨터와 가위 바위 보 게임\n1: 가위 2: 바위 3: 보");
            int.TryParse(Console.ReadLine(), out MyHand);

            switch (MyHand)
            {
                //가위
                case 1:
                    if (ComputerHand == 3) Wincase = 3;
                    else if (ComputerHand == 2) Wincase = 1;
                    else if (ComputerHand == 1) Wincase = 2;
                    break;
                //바위
                case 2:
                    if (ComputerHand == 3) Wincase = 1;
                    else if (ComputerHand == 2) Wincase = 2;
                    else if (ComputerHand == 1) Wincase = 3;
                    break;
                //보
                case 3:
                    if (ComputerHand == 3) Wincase = 2;
                    else if (ComputerHand == 2) Wincase = 3;
                    else if (ComputerHand == 1) Wincase = 1;
                    break;
                //예외 값 처리
                default:
                    Console.WriteLine("[System] 잘못된 값 입력입니다.");
                    break;
            }

            switch(Wincase)
            {
                case 1:
                    Console.WriteLine("졌습니다. 컴퓨터 : {0} , 나 : {1}", printhand[ComputerHand], printhand[MyHand]);
                    break;
                case 2:
                    Console.WriteLine("비겼습니다. 컴퓨터 : {0} , 나 : {1}", printhand[ComputerHand], printhand[MyHand]);
                    break;
                case 3:
                    Console.WriteLine("이겼습니다. 컴퓨터 : {0} , 나 : {1}", printhand[ComputerHand], printhand[MyHand]);
                    break;
            }
        }

        private int[] SwapHand(int[] Handcase_)
        {
            Random random = new Random();
            int temp = 0;
            int sour = random.Next(0, 2 + 1);
            int dest = random.Next(0, 2 + 1);

            temp = Handcase_[sour];
            Handcase_[sour] = Handcase_[dest];
            Handcase_[dest] = temp;

            return Handcase_;
        }
    }
}
