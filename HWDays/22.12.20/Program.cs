using System;

namespace Switch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* LAB 문제 1
            * 자음과 모음 갯수 세기
            * 사용자로부터 영문자를 받아서 자음과 모음의 개수를 세는 프로그램을 작성
            * - 대, 소문자 모두 카운트
            * EX)
            *      a
            *      b
            *      c
            *      d
            *      e
            *      (종료문 아무거나)
            *      모음: 2
            *      자음: 3
            * AEIOU 모음 나머지 자음  
            */

            int consonant = 0;                                          //자음을 담을 변수 선언
            int vowol = 0;                                              //모음을 담을 변수 선언

            Console.WriteLine("영문단어 자음,모음을 세는 프로그램입니다.");//프로그램 소개글

            while (true)                                                //while 반복문 시작 { true 값의 경우 계속 반복한다 }
            {
                Console.Write("영단어를 입력해주세요 : ");                //입력 정보 도움글
                char Englishchar = default;                             //문자 변수 Englishchar 선언, default 자동(추론) 초기화 
                char.TryParse(Console.ReadLine(), out Englishchar);     //Englishchar 변수에 정보 입력

                if ('Z' == Englishchar)                                 // Englishchar(문자)의 값이 Z(대문자) 과 같다면
                {
                    break;                                              // while 반복문 탈출
                }
                else if ('a' == Englishchar || 'A' == Englishchar)      // Englishchar(문자)의 값이 a 또는 A와 같다면
                {
                    consonant += 1;                                     //자음 갯수 추가
                }
                else if ('e' == Englishchar || 'E' == Englishchar)      // Englishchar(문자)의 값이 e 또는 E와 같다면    
                {
                    consonant += 1;                                     //자음 갯수 추가
                }
                else if ('i' == Englishchar || 'I' == Englishchar)      // Englishchar(문자)의 값이 i 또는 I와 같다면
                {
                    consonant += 1;                                     //자음 갯수 추가
                }
                else if ('o' == Englishchar || 'O' == Englishchar)      // Englishchar(문자)의 값이 o 또는 O와 같다면
                {
                    consonant += 1;                                     //자음 갯수 추가
                }
                else if ('u' == Englishchar || 'U' == Englishchar)      // Englishchar(문자)의 값이 u 또는 U와 같다면
                {
                    consonant += 1;                                     //자음 갯수 추가
                }
                else
                {
                    vowol += 1;                                         //나머진 모음이므로 모듬 갯수 추가
                }
            }
            Console.WriteLine($"자음: {consonant} 개, 모음: {vowol} 개");//최종 결과 출력문

            /* LAB 문제 2
             * 숫자 맞추기 게임
             * 숫자 알아맞히기 게임이다. 프로그램은 1~ 100사이의 정수를 저장하고 있음. 사용자는 질문을 통해서 알아맞춘다.
             * 사용자가 답을 제시하면 프로그램은 제시된 정수가 더 낮은 값인지, 높은 값인지 알려준다.
             * 사용자가 알아맞힐때까지 루프한다. (기본형)
             * 
             * (심화과정)
             *   프로그램을 수정하여 컴퓨터가 생성한 숫자를 사용자가 추측하는 대신에, 사용자가 결정한 번호를 
             *   컴퓨터가 추측하도록 수정한다. 사용자는 컴퓨터가 추측한 숫자가 높거나 낮은 지를 컴퓨터에 알려야 한다.
             *   컴퓨터가 맞출때까지 반복 (어려운거 1)
             *   
             *   사용자가 결정한 값의 범위는 (1 ~ 100) 어떤 숫자를 생각하던 간에 7번 이하의 추측으로 컴퓨터가 맞출 수 있도록
             *   어려운거 1을 수정 하시오 (어려운거 2)
             */

            //(기본형)
            const int SECETNUMBER = 5;                                  //컴퓨터 내부 정답값(5) - 상수 정수형 SECETNUMBER 변수 선언
            int AnswerNumber = 0;                                       //입력 받을 숫자 저장 변수 선언
            Console.WriteLine("\n숫자 맞추기 게임");                     //프로그램 소개글 \n(줄바꿈 이스케이프시퀸스)는 이전 프로그램과 구분을 위해서
            while (true)                                                //while 반복문 시작 true 값이면 계속 반복된다
            {
                Console.Write("1 ~ 100 중 정답 입력 : ");                //입력 정보 도움글
                int.TryParse(Console.ReadLine(), out AnswerNumber);     //AnswerNumber 변수에 정보 입력 (문자열 tryparse로 정수로 변환)

                if (0 >= AnswerNumber || AnswerNumber > 100)            //만약 AnswerNumber 가 0보다 낮거나 AnswerNumber이 100보다 크면(입력값 오류 방지문)
                {
                    Console.WriteLine("1 ~ 100 중에서 입력해 주세요!");  //오류값 입력에 따른 출력문 
                }
                else                                                    //아니면 (정상데이터)
                {
                    if (SECETNUMBER > AnswerNumber)                     //입력값이 내부 정답값보다 작다면
                    {
                        Console.WriteLine("더 높습니다.");               //피드백 출력문
                    }
                    else if (SECETNUMBER < AnswerNumber)                //입력값이 내부 정답값보다 크다면
                    {
                        Console.WriteLine("더 낮습니다.");               //피드백 출력문
                    }
                    else break;                                         //높거나 낮지 않다면 정답이니 반복문 탈출
                }
            }
            Console.WriteLine("정답입니다!");                            //정답 출력문

            //(어려운 것 1)
            Random rand = new Random();                                                     //랜덤 클래스 변수 선언
            int MinNumber = 1, MaxNumber = 100;                                             //탐색 범위를 위한 정수 변수 2개 선언
            int SearchNumber = rand.Next(1, 100 + 1);                                       //검색 값을 위한 정수 변수 (랜덤 값 {1~100 사이 값} 대입)
            int Userchoice = 0;                                                             //유저제어 값 입력 변수 선언
            int anwerReult = 0;                                                             //정답 값 변수 선언

            Console.WriteLine("\n\n숫자 맞춰주는 게임");                                    //프로그램 안내문
            Console.Write("1 ~ 100 중 한가지 숫자를 골라주세요 : ");                        //정답 입력 값 안내문
            int.TryParse(Console.ReadLine(), out anwerReult);                               //정답 값 anwerReult 변수 입력

            while (true)                                                                    //while 반복문
            {
                Console.WriteLine($"{SearchNumber}가 생각하는 숫자가 맞나요 ?");            //랜덤 값을 사용자에게 보여주는 구문
                Console.Write("높으면 1번, 낮으면 2번 눌러주세요 : ");                      //유저 제어 값 사용 안내문
                int.TryParse(Console.ReadLine(), out Userchoice);                           //유저 제어 값 입력

                switch (Userchoice)                                                         //switch문 (유저제어값)
                {
                    case 1:                                                                 //1번 컴퓨터가 보여준 값보다 정답이 높으면
                        MinNumber = SearchNumber + 1;                                       //최저 범위값에 보여준 값 + 1 (자신 제외) 대입
                        break;                                                              //case 1 종료
                    case 2:                                                                 //2번 컴퓨터가 보여준 값보다 정답이 낮으면
                        MaxNumber = SearchNumber - 1;                                       //최대 범위값에 보여준 값 - 1 (자신 제외) 대입
                        break;                                                              //case 2 종료
                }
                SearchNumber = rand.Next(MinNumber, MaxNumber + 1);                         //검색 값 갱신 (최저 범위값 ~ 최대 범위값 사이 랜덤 값)

                if (anwerReult == SearchNumber)                                             //만약 정답 값과 검색값이 같다면
                {
                    Console.WriteLine($"{SearchNumber}정답!");                              //정답 출력문
                    break;                                                                  //while 반복문 탈출
                }
            }

            //(어려운것2)
            int minNumber = 1, maxNumber = 100;                                                 //최저 범위, 최대 범위 값 정수형 변수 선언
            int searchNumber = 50;                                                              //검색 값 초기 값 50으로 선언                   

            Console.WriteLine("숫자 맞춰주는 게임");                                            //프로그램 안내문
            Console.WriteLine("1 ~ 100 중 한가지 숫자를 골라주세요");                           //입력문 안내문
            Console.Write("정답 숫자를 정하세요 : ");                                           //입력값 안내문
            int answer = Convert.ToInt32(Console.ReadLine());                                   //정답 값 입력

            while (true)                                                                        //while 반복문
            {
                Console.WriteLine($"\n현재 범위 최저값 : {minNumber} , 최대값 {maxNumber}");    //현재 최저,최대 범위값 안내
                Console.WriteLine($"{searchNumber}가 생각하는 숫자가 맞나요 ?");                //현재 검색 값 확인문

                if (searchNumber > answer)                                                      //만약 정답값이 검색 값보다 작다면
                {
                    maxNumber = searchNumber - 1;                                               //최대값은 검색값 - 1 (자신 제외) 갱신
                    searchNumber = (maxNumber + minNumber) / 2;                                 //검색 값은 현재 최저값 + 최대값 / 2 (현재 중간값 찾기)
                }
                else if (searchNumber < answer)                                                 //만약 정답값이 검색 값보다 크다면
                {
                    MinNumber = searchNumber + 1;                                               //최저값은 검색값 + 1 (자신 제외) 갱신
                    searchNumber = (maxNumber + minNumber) / 2;                                 //검색 값은 현재 최저값 + 최대값 / 2 (현재 중간값 찾기)
                }
                else                                                                            //나머지일 경우
                {
                    Console.WriteLine("정답!");                                                 //정답 안내문
                    break;                                                                      //while 반복문 탈출
                }
            }

            /*  LAB 문제3
             *  산수 문제 자동 출제
             *  산수 문제를 자동으로 출제하는 프로그램을 작성해보자. 덧셈 문제들을 자동으로 생성하여야 한다.
             *  피연산자는 0 ~ 99 사이의 숫자(난수) 한번이라도 맞으면 종료 틀리면 리트라이(기본형)
             * 
             *  - 뺄셈 곱셈 나눗셈 문제도 출제(추가문제)
             *      -> 나눗셈 예외처리(무한대 값 주의)
             */

            Random randomPoint = new Random();                             //랜덤 클래스 변수 생성         

            int operandA = randomPoint.Next(0, 100);                       //피연산자A 변수 랜덤값 대입 (0 ~ 99)
            int operandB = randomPoint.Next(0, 100);                       //피연산자B 변수 랜덤값 대입 (0 ~ 99)
            int UserResult = 0;                                            //유저 정답 값 입력 변수

            while (true)                                                   //while 반복문 시작
            {
                Console.Write($"{operandA} + {operandB} = ");              //덧셈 안내문
                int.TryParse(Console.ReadLine(), out UserResult);          //유저 정답 값 입력

                if (UserResult == operandA + operandB)                     //정답 값 과 피연산자 A + B 값 비교문 같다면
                {
                    Console.WriteLine("정답입니다.");                      //정답 출력문
                    break;                                                 //while 반복문 탈출
                }
            }

            operandA = randomPoint.Next(0, 100);                            //피연산자A 변수 랜덤값 대입 (0 ~ 99)
            operandB = randomPoint.Next(0, 100);                            //피연산자B 변수 랜덤값 대입 (0 ~ 99)

            while (true)                                                    //while 반복문 시작
            {
                Console.Write($"{operandA} - {operandB} = ");               //뺄셈 안내문
                int.TryParse(Console.ReadLine(), out UserResult);           //유저 정답 값 입력

                if (UserResult == operandA - operandB)                      //정답 값 과 피연산자 A - B 값 비교문 같다면
                {
                    Console.WriteLine("정답입니다.");                       //정답 출력문
                    break;                                                  //while 반복문 탈출
                }
            }

            operandA = randomPoint.Next(0, 100);                            //피연산자A 변수 랜덤값 대입 (0 ~ 99)
            operandB = randomPoint.Next(0, 100);                            //피연산자B 변수 랜덤값 대입 (0 ~ 99)

            while (true)                                                    //while 반복문 시작
            {
                Console.Write($"{operandA} * {operandB} = ");               //곱셈 안내문
                int.TryParse(Console.ReadLine(), out UserResult);           //유저 정답 값 입력

                if (UserResult == operandA * operandB)                      //정답 값 과 피연산자 A x B 값 비교문 같다면
                {
                    Console.WriteLine("정답입니다.");                       //정답 출력문
                    break;                                                  //while 반복문 탈출
                }
            }

            operandA = randomPoint.Next(0, 100);                                            //피연산자A 변수 랜덤값 대입 (0 ~ 99)
            operandB = randomPoint.Next(0, 100);                                            //피연산자B 변수 랜덤값 대입 (0 ~ 99)

            float division = 0.0f, UserdivisionResult = 0.0f;                               //실수형 변수 나눗셈 결과값 선언, 유저 정답 값

            while (true)                                                                    //while 반복문 시작
            {
                Console.Write($"{operandA} / {operandB} = ");                               //나눗셈 안내문
                float.TryParse(Console.ReadLine(), out UserdivisionResult);                 //유저 정답 값 입력

                division = (float)Math.Round((float)operandA / (float)operandB, 3);         //정수형 피연산자 A , B 실수형으로 형변환 후 나누기 그후 소수점 3자리까지 근사값으로 반올림 후 division 변수에 대입

                if (division == UserdivisionResult)                                         //정답 값 과 나눗셈 결과 값 비교문 같다면
                {
                    Console.WriteLine("정답입니다.");                                       //정답 출력문
                    break;                                                                  //while 반복문 탈출
                }
            }
        }
    }
}