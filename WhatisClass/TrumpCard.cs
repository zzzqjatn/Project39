using System;

namespace WhatisClass
{
    public class TrumpCard
    {
        private int[] trumpCardset; //내가 사용할 카드 세트
        private string[] trumpCardMark; //트럼프 카드의 마크

        public void SetupTrumpCards()
        {
            trumpCardset = new int[52];
            for(int i = 0; i < trumpCardset.Length; i++)
            {
                trumpCardset[i] = i + 1;
            }   // loop: 카드를 셋업하는 루프

            //트럼프 카드에 마크를 셋업
            trumpCardMark = new string[4] { "♥", "♠", "◆", "♣" };
        }   //SetupTrumpCards()

        //! 카드를 섞는 함수
        public void ShuffleCards()
        {
            ShuffleCards(200);
        }   //ShuffleCards()

        //! 셔플을 하고서 카드를 한장 뽑아주는 함수
        public void ReRollcard()
        {
            ShuffleCards();
            Rollcard();
        }   //ReRollcard()

        //셔플하고 카드 한장 정수값으로 주는 함수
        public string[] ReNumberRollCard()
        {
            ShuffleCards();
            return Rollcard_();
        }   //ReNumberRollCard()

        //! 한장의 카드를 뽑아서 보여주는 함수
        public void Rollcard()
        {
            int card = trumpCardset[0];
            string cardMark = trumpCardMark[(card - 1) / 13];
            //int cardnumber = (int)Math.Ceiling(card % 13.1);
            string cardnumber = Math.Ceiling(card % 13.1).ToString();
            //13.1 나누기는 0번 예외처리를 위해

            switch(cardnumber)
            {
                case "11":
                    cardnumber = "J";
                    break;
                case "12":
                    cardnumber = "Q";
                    break;
                case "13":
                    cardnumber = "K";
                    break;
                default:
                    /* Do nothing */
                    break;
            }   //switch

            Console.WriteLine("내가 뽑은 카드는 {0}{1} 입니다.", cardMark, cardnumber);
            Console.WriteLine(" -----");
            Console.WriteLine("|{0}{1} |",cardMark,cardnumber);
            Console.WriteLine("|    |");
            Console.WriteLine("| {0}{1}|",cardnumber,cardMark);
            Console.WriteLine(" -----");

        }   //Rollcard()

        public string[] Rollcard_()
        {
            int card = trumpCardset[0];
            string cardMark = trumpCardMark[(card - 1) / 13];
            string cardnumber = Math.Ceiling(card % 13.1).ToString();
            //13.1 나누기는 0번 예외처리를 위해

            string[] temp = { cardMark, cardnumber };

            return temp;
        }   //Rollcard_()
        //! 한장의 카드를 뽑아서 숫자 보내는 주는 함수


        //! 카드를 섞는 함수
        private void ShuffleCards(int howManyLoop)
        {
            for (int i = 0; i < howManyLoop; i++)
            {
                trumpCardset = ShuffleOnce(trumpCardset);
            }
        }   // ShuffleCards()

        private void PrintCardSet()
        {
            foreach(int card in trumpCardset)
            {
                Console.WriteLine("{0} ", card);
            }
        }   // PrintCardSet()


        //! 배열을 1번 섞는 함수
        private int[] ShuffleOnce(int[] intArray)
        {
            Random random = new Random();
            int sourIndex = random.Next(0, intArray.Length);
            int destIndex = random.Next(0, intArray.Length);

            int tempVarible = intArray[sourIndex];
            intArray[sourIndex] = intArray[destIndex];
            intArray[destIndex] = tempVarible;

            return intArray;
        }   // ShuffleOnce()


        public void PrintCheck()
        {
            Console.WriteLine("Main 메서드에서 호출이 가능한지?");
        }   // PrintCheck

    }
}
