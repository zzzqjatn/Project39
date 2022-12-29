using System;

namespace WhatisClass
{
    internal class CardGame
    {
        private int[] computerCardNumber = new int[2];      //컴퓨터 카드 2장 번호 정수 배열
        private string[] computerCardMark = new string[2];  //컴퓨터 카드 2장 마크 문자열 배열

        public void InGame()
        {
            int playerMoney = 10_000;   //플레이어 소지금(초기10,000원)
            int bettingPoint = 0;       //배팅 금액 변수

            string myCardMark;          //내가 뽑은 카드 마크
            int myCardNumber;           //내가 뽑은 카드 숫자

            string[] temp;              //한장의 카드를 뽑아온 뒤 마크와 번호를 분할하기 위한 임시 변수

            TrumpCard trumpcard_ = new TrumpCard(); //trumpcard 인스턴스화

            Console.WriteLine();    //가독성 출력문
            Console.WriteLine();
            Console.WriteLine();

            //게임 로직 반복문
            while (true)
            {
                //컴퓨터 카드 세팅을 위한 반복문
                for (int index = 0; index < computerCardNumber.Length; index++)
                {
                    temp = trumpcard_.ReStringRollCard();   //임시 변수에 뽑은 한장 값 대입 

                    computerCardMark[index] = temp[0];      //순번에 맞춰 임시변수에서 마크 값 주기 (컴퓨터 카드 마크 배열)
                    int.TryParse(temp[1],out computerCardNumber[index]);    //순번에 맞춰 임시변수에서 번호 문자열을 정수값으로 주기 (컴퓨터 카드 번호 배열)
                }

                //플레이어 카드 세팅
                temp = trumpcard_.ReStringRollCard();   //임시변수에 뽑은 한장 값 대입

                myCardMark = temp[0];   //임시변수 마크값을 플레이어 마크값에 대입
                int.TryParse(temp[1],out myCardNumber); //임시변수 번호값을 플레이어 번호값에 대입

                //컴퓨터 카드 순번 바꾸기
                for (int y = 0; y < computerCardNumber.Length; y++)
                {
                    for (int x = y + 1; x < computerCardNumber.Length; x++)
                    {
                        //작은수에서 큰수차례대로 바꿔주기
                        //(카드 한장을 가지고 그 뒤 카드들 모두와 비교이후
                        //한장뒤로 가서 이전 카드 제외 그뒤 카드 모두 비교한다. 이 과정을 끝까지 반복)
                        if (computerCardNumber[y] > computerCardNumber[x])
                        {
                            //번호 Swap 로직
                            int numbertemp = computerCardNumber[y];
                            computerCardNumber[y] = computerCardNumber[x];
                            computerCardNumber[x] = numbertemp;

                            //마크 Swap 로직
                            string marktemp = computerCardMark[y];
                            computerCardMark[y] = computerCardMark[x];
                            computerCardMark[x] = marktemp;
                        }
                    }
                }

                //게임 안내 출력문
                Console.WriteLine("두 숫자 사이 초과, 미만 게임을 시작합니다.");
                Console.WriteLine("현재 소지금 : {0}", playerMoney);
                Console.WriteLine("=============================");
                Console.WriteLine();
                Console.WriteLine("컴퓨터 {0}{1} ~ {2}{3}", computerCardMark[0],computerCardNumber[0], 
                    computerCardMark[computerCardNumber.Length - 1], computerCardNumber[computerCardNumber.Length - 1]);
                //현재 컴퓨터 카드 중 제일 작은 값은 배열 첫번째[0번] 제일 큰 값은 마지막[Length - 1] 임으로 위 같이 배치해준다. 
                Console.WriteLine();

                //배팅 예외처리
                while (true)
                {
                    Console.Write("얼마 거시겠습니까 ? (0원은 패스입니다) ");
                    int.TryParse(Console.ReadLine(), out bettingPoint);

                    //만약 소지금보다 큰 돈을 결면
                    if (bettingPoint > playerMoney)
                    {
                        Console.WriteLine("소지금보다 많은 금액을 배팅할 수 없습니다.");
                        Console.WriteLine();
                    }
                    else break;
                }

                //패스일 경우
                if (bettingPoint == 0)
                {
                    Console.Clear();    //화면 클리어
                    Console.WriteLine();    //가독성을 위한 출력문
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("이전 게임은 패스 하셨습니다.");  //게임 상단에 이전 선택지를 알려주는 출력문
                }
                else    //패스가 아닐 경우
                {
                    //WinExam(내 카드 번호값)은 이겼는지 여부를 bool 값으로 반환해준다.
                    switch (WinExam(myCardNumber))
                    {
                        //이겼을 경우
                        case true:
                            playerMoney += (bettingPoint * 2);  //플레이어 소지금에 배팅액 2배 더해주기
                            Console.Clear();    //화면 클리어
                            Console.WriteLine();    //가독성을 위한 출력문
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("이전 게임은 승리하셨습니다. 컴퓨터 {0}{1} ~ {2}{3} , 내 카드 {4}{5} 배팅금 : {6}",
                                computerCardMark[0], computerCardNumber[0],
                                computerCardMark[computerCardNumber.Length - 1], computerCardNumber[computerCardNumber.Length - 1],
                                myCardMark, myCardNumber, bettingPoint);
                            //게임 상단에 이전 선택지를 알려주는 출력문 이전 컴퓨터의 카드 값, 내 카드값, 배팅했던 금액
                            break;
                        //졌을 경우
                        case false:
                            playerMoney -= bettingPoint;    //플레이어 소지금에 배팅액 빼주기
                            Console.Clear();    //화면 클리어
                            Console.WriteLine();    //가독성을 위한 출력문
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("이전 게임은 패배하셨습니다. 컴퓨터 {0}{1} ~ {2}{3} , 내 카드 {4}{5} 배팅금 : {6}",
                                computerCardMark[0], computerCardNumber[0],
                                computerCardMark[computerCardNumber.Length - 1], computerCardNumber[computerCardNumber.Length - 1],
                                myCardMark, myCardNumber, bettingPoint);
                            //게임 상단에 이전 선택지를 알려주는 출력문 이전 컴퓨터의 카드 값, 내 카드값, 배팅했던 금액
                            break;
                    }
                }

                /*게임 승리 조건 패배 조건*/
                //게임 승리 100,000을 모았을 경우
                if(playerMoney >= 100_000)
                {
                    Console.WriteLine("목표금액(100,000원)에 달성하셨습니다. 현재 돈 : {0}", playerMoney);
                    break;
                }
                //게임 패배 소지금이 없을 경우
                if (playerMoney <= 0)
                {
                    Console.WriteLine("소지금이 없어 종료합니다. 현재 돈 : {0}", playerMoney);
                    break;
                }
            }
        }

        //내 카드를 통한 이번게임 승리여부를 bool 값으로 내주는 함수
        public bool WinExam(int playerCard)
        {
            //만약 제일 작은 컴퓨터 카드 번호 와 가장 큰 컴퓨터 번호 사이에 내 카드 값이 있다면
            if (computerCardNumber[0] < playerCard && playerCard < computerCardNumber[computerCardNumber.Length - 1])
            {
                //true (이김)
                return true;
            }
            else
            {
                //false (졌음)
                return false;
            }
        }
    }
}
