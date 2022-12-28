using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatisClass
{
    internal class CardGame
    {
        private int[] computerCardNumber = new int[2];
        private string[] computerCardMark = new string[2];

        public void gameBegin()
        {
            InGame();
        }

        public void InGame()
        {
            int playerMoney = 10_000;
            int bettingPoint = 0;

            string myCardMark;
            int myCardNumber;

            string[] temp;

            TrumpCard trumpcard_ = new TrumpCard();
            trumpcard_.SetupTrumpCards();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            //게임 로직 반복문
            while (true)
            {
                //컴퓨터 카드 세팅
                for (int index = 0; index < computerCardNumber.Length; index++)
                {
                    temp = trumpcard_.ReNumberRollCard();

                    computerCardMark[index] = temp[0];
                    int.TryParse(temp[1],out computerCardNumber[index]);
                }

                //플레이어 카드 세팅
                temp = trumpcard_.ReNumberRollCard();

                myCardMark = temp[0];
                int.TryParse(temp[1],out myCardNumber);
                //myCard = 5;

                //컴퓨터 카드 순번 바꾸기
                for (int y = 0; y < computerCardNumber.Length; y++)
                {
                    for (int x = y + 1; x < computerCardNumber.Length; x++)
                    {
                        //작은수에서 큰수차례대로 바꿔주기
                        if (computerCardNumber[y] > computerCardNumber[x])
                        {
                            int numbertemp = computerCardNumber[y];
                            computerCardNumber[y] = computerCardNumber[x];
                            computerCardNumber[x] = numbertemp;

                            string marktemp = computerCardMark[y];
                            computerCardMark[y] = computerCardMark[x];
                            computerCardMark[x] = marktemp;
                        }
                    }
                }

                Console.WriteLine("두 숫자 사이 초과, 미만 게임을 시작합니다.");
                Console.WriteLine("현재 소지금 : {0}", playerMoney);
                Console.WriteLine("=============================");
                Console.WriteLine();
                Console.WriteLine("컴퓨터 {0}{1} ~ {2}{3}", computerCardMark[0],computerCardNumber[0], 
                    computerCardMark[computerCardNumber.Length - 1], computerCardNumber[computerCardNumber.Length - 1]);
                Console.WriteLine();

                //배팅 예외처리
                while (true)
                {
                    Console.Write("얼마 거시겠습니까 ? (0원은 패스입니다) ");
                    int.TryParse(Console.ReadLine(), out bettingPoint);

                    if (bettingPoint > playerMoney)
                    {
                        Console.WriteLine("소지금보다 많은 금액을 배팅할 수 없습니다.");
                        Console.WriteLine();
                    }
                    else break;
                }

                //패스
                if (bettingPoint == 0)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("이전 게임은 패스 하셨습니다.");
                }
                else    //패스가 아닐 경우
                {
                    switch (WinExam(myCardNumber))
                    {
                        case true:
                            playerMoney += (bettingPoint * 2);
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("이전 게임은 승리하셨습니다. 컴퓨터 {0}{1} ~ {2}{3} , 내 카드 {4}{5} 배팅금 : {6}",
                                computerCardMark[0], computerCardNumber[0],
                                computerCardMark[computerCardNumber.Length - 1], computerCardNumber[computerCardNumber.Length - 1],
                                myCardMark, myCardNumber, bettingPoint);
                            break;
                        case false:
                            playerMoney -= bettingPoint;
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("이전 게임은 패배하셨습니다. 컴퓨터 {0}{1} ~ {2}{3} , 내 카드 {4}{5} 배팅금 : {6}",
                                computerCardMark[0], computerCardNumber[0],
                                computerCardMark[computerCardNumber.Length - 1], computerCardNumber[computerCardNumber.Length - 1],
                                myCardMark, myCardNumber, bettingPoint);
                            break;
                    }
                }

                /*승리 조건 패배 조건*/
                if(playerMoney >= 100_000)
                {
                    Console.WriteLine("목표금액(100,000원)에 달성하셨습니다. 현재 돈 : {0}", playerMoney);
                    break;
                }
                if (playerMoney <= 0)
                {
                    Console.WriteLine("소지금이 없어 종료합니다. 현재 돈 : {0}", playerMoney);
                    break;
                }
            }
        }

        public bool WinExam(int playerCard)
        {
            if (computerCardNumber[0] < playerCard && playerCard < computerCardNumber[computerCardNumber.Length - 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
