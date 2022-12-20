using System;

namespace Switch
{
    internal class HomeWork
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




        }
    }
}
