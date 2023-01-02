using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

namespace poker
{
    public class CardGame
    {
        private struct Card
        {
            //생성자
            public Card(string _mark, int _number)
            {
                mark = _mark;
                number = _number;
            }

            public string mark { get; }
            public int number { get; }
        }

        private TrumpCard trumpcard_;

        private List<Card> computercard = new List<Card>();
        private List<Card> playercard = new List<Card>();
        private int playerMoney;
        private int bettingMoney;

        public CardGame()
        {
            playerMoney = 10_000; //플레이어 소지금(초기10,000원)
            bettingMoney = 0;     //배팅 금액 변수

            trumpcard_= new TrumpCard();
        }

        public void InGame()
        {
            cardDraw(5, 0);
            cardDraw(5, 1);
            drawingCard();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            switch(pokerConditions(0))
            {
                case 6:
                    Console.WriteLine("스트레이트이다");
                    break;
                case 5:
                    Console.WriteLine("플래쉬이다.");
                    break;
                case 4:
                    Console.WriteLine("포카드이다.");
                    break;
                case 3:
                    Console.WriteLine("트리플이다.");
                    break;
                case 2:
                    Console.WriteLine("투페어이다.");
                    break;
                case 1:
                    Console.WriteLine("원페어이다.");
                    break;
                case 0:
                    Console.WriteLine("없음.");
                    break;
            }
            inputBetting();
            cardDraw(2, 0);
            Console.Clear();
            drawingCard();
            playerCardChangeControl(2);
        }

        public int pokerConditions(int choiceOne)
        {
            string condition = string.Empty;

            bool onePair = false;
            bool twoPairs = false;
            bool trips = false;
            bool fourCard = false;
            bool flush = false;
            bool straight = false;

            int incount = 0;

            if (choiceOne == 0)
            {
                //원페어 트리플 포카드
                for (int i = 0; i < computercard.Count; i++)
                {
                    for(int j = 0; j < computercard.Count; j++)
                    {
                        if (i == j) continue;

                        if (computercard[i].number == computercard[j].number)
                        {
                            incount += 1;
                        }
                    }
                    if (incount == 1)
                    {
                        onePair = true;
                    }
                    else if (incount == 2)
                    {
                        trips = true;
                    }
                    else if (incount == 3)
                    {
                        fourCard = true;
                    }
                    incount = 0;
                }

                incount = 0;
                //플래쉬 같은 모양 5개
                for (int i = 0; i < computercard.Count; i++)
                {
                    for (int j = 0; j < computercard.Count; j++)
                    {
                        if (i == j) continue;
                        if (computercard[i].mark == computercard[j].mark)
                        {
                            incount +=1;
                        }
                    }
                    if(incount == 4)
                    {
                        flush = true;
                        break;
                    }
                }

                incount = 0;
                //연속되는 숫자 5개의 경우
                for (int i = 0; i < computercard.Count; i++)
                {
                    for (int j = 0; j < computercard.Count; j++)
                    {
                        if (i == j) continue;
                        if (computercard[i].number + 1 == computercard[j].number)
                        {
                            incount += 1;
                            i += 1;
                        }
                        else
                        {
                            incount = 0;
                        }
                    }
                    if (incount == 4)
                    {
                        straight = true;
                        break;
                    }
                }

                int beforePair = -1;
                incount = 0;
                //투페어
                for (int i = 0; i < computercard.Count; i++)
                {
                    for (int j = 0; j < computercard.Count; j++)
                    {
                        if (i == j || beforePair == computercard[j].number) continue;
                        if (computercard[i].number == computercard[j].number)
                        {
                            incount += 1;
                            beforePair = computercard[i].number;
                        }
                    }
                    if (incount == 2)
                    {
                        twoPairs = true;
                        break;
                    }
                }

                if (straight)
                {
                    return 6;
                }
                else if (flush)
                {
                    return 5;
                }
                else if (fourCard)
                {
                    return 4;
                }
                else if (trips)
                {
                    return 3;
                }
                else if (twoPairs)
                {
                    return 2;
                }
                else if(onePair)
                {
                    return 1;
                }
            }
            else if(choiceOne == 1)
            {
                return 0;
            }
            return 0;
        }

        public String pokerMarkConditions(string before, string now)
        {
            //스페이드 >> 다이아 >> 하트 >> 클로버

            if(now == "♠")
            {
                return now;
            }
            else if(now == "◆")
            {
                if (before != "♠")
                {
                    return now;
                }
                return before;
            }
        }

        public void drawingCard()
        {
            Console.WriteLine("컴퓨터의 카드 {0} 장", computercard.Count);
            //컴퓨터 것
            for(int i = computercard.Count; i > 0; i--)
            {
                Console.Write(" ----- ".PadRight(5, ' '));
            }
            Console.WriteLine();
            
            foreach(Card one in computercard)
            { 
                Console.Write("| {0}  |".PadRight(5, ' '), one.mark);
            }

            Console.WriteLine();
            for (int i = computercard.Count; i > 0; i--)
            {
                Console.Write("|     |".PadRight(5,' '));
            }

            Console.WriteLine();
            foreach (Card one in computercard)
            {
                if (one.number >= 10)
                {
                    switch(one.number)
                    {
                        case 10:
                            Console.Write("|  {0} |".PadRight(5, ' '), one.number);
                            break;
                        case 11:
                            Console.Write("|   J |".PadRight(5, ' '));
                            break;
                        case 12:
                            Console.Write("|   Q |".PadRight(5, ' '));
                            break;
                        case 13:
                            Console.Write("|   K |".PadRight(5, ' '));
                            break;
                    }
                }
                else 
                {
                    Console.Write("|   {0} |".PadRight(8, ' '), one.number);
                }
            }

            Console.WriteLine();
            for (int i = computercard.Count; i > 0; i--)
            {
                Console.Write(" ----- ".PadRight(5, ' '));
            }

            //가독성
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("플레이어의 카드 {0} 장", playercard.Count);
            //플레이어 것
            for (int i = playercard.Count; i > 0; i--)
            {
                Console.Write(" ----- ".PadRight(5, ' '));
            }
            Console.WriteLine();

            foreach (Card one in playercard)
            {
                Console.Write("| {0}  |".PadRight(5, ' '), one.mark);
            }

            Console.WriteLine();
            for (int i = playercard.Count; i > 0; i--)
            {
                Console.Write("|     |".PadRight(5, ' '));
            }

            Console.WriteLine();
            foreach (Card one in playercard)
            {
                if (one.number >= 10)
                {
                    switch (one.number)
                    {
                        case 10:
                            Console.Write("|  {0} |".PadRight(5, ' '), one.number);
                            break;
                        case 11:
                            Console.Write("|   J |".PadRight(5, ' '));
                            break;
                        case 12:
                            Console.Write("|   Q |".PadRight(5, ' '));
                            break;
                        case 13:
                            Console.Write("|   K |".PadRight(5, ' '));
                            break;
                    }
                }
                else
                {
                    Console.Write("|   {0} |".PadRight(8, ' '), one.number);
                }
            }

            Console.WriteLine();
            for (int i = playercard.Count; i > 0; i--)
            {
                Console.Write(" ----- ".PadRight(5, ' '));
            }
        }

        public void inputBetting()
        {
            Console.WriteLine();
            while (true)
            {
                Console.Write("배팅하실 금액을 입력해주세요 : ");

                if (int.TryParse(Console.ReadLine(),out bettingMoney))
                {
                    if(playerMoney < bettingMoney)
                    {
                        Console.WriteLine("[system] 소지금 초과 (현재 소지금보다 이하로 배팅해주세요)");
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("[system] 잘못된 예외 값 (숫자만 입력해주세요)");
                }
            }
        }

        public void cardDraw(int DrawCounter, int choiceOne)
        {
            //witchOne 0은 컴퓨터, 1은 플레이어
            string[] temp = new string[2];
            int parseNumber = 0;
            bool isCardRight = false;

            List<Card> sortCard = new List<Card>();

            //들어온 카드 현재 카드들과 겹치는지
            //컴퓨터 , 내꺼

            //첫번째 값은 중복없으니
            if (computercard.Count == 0 && choiceOne == 0 &&
                playercard.Count == 0 && choiceOne == 0)
            {
                temp = trumpcard_.ReStringRollCard();
                int.TryParse(temp[1], out parseNumber);
                computercard.Add(new Card(temp[0], parseNumber));
                DrawCounter--;
            }
            else if (playercard.Count == 0 && choiceOne == 1 &&
                computercard.Count == 0 && choiceOne == 1)
            {
                temp = trumpcard_.ReStringRollCard();
                int.TryParse(temp[1], out parseNumber);
                playercard.Add(new Card(temp[0], parseNumber));
                DrawCounter--;
            }

            //카드 드로우
            for (int i = 0; i < DrawCounter; i++)
            {
                while (true)
                {
                    isCardRight = false;
                    temp = trumpcard_.ReStringRollCard();
                    int.TryParse(temp[1],out parseNumber);

                    if (choiceOne == 0)
                    {
                        for (int j = 0; j < computercard.Count; j++)
                        {
                            if (computercard[j].mark == temp[0] && computercard[j].number == parseNumber)
                            {
                                isCardRight = false;
                                break;
                            }
                            else { isCardRight = true; }
                        }

                        if (isCardRight)
                        {
                            for (int k = 0; k < playercard.Count; k++)
                            {
                                if (playercard[k].mark == temp[0] && playercard[k].number == parseNumber)
                                {
                                    isCardRight = false;
                                    break;
                                }
                                else { isCardRight = true; }
                            }
                        }
                        
                        if (isCardRight == true)
                        {
                            computercard.Add(new Card(temp[0], parseNumber));
                            break;
                        }
                    }
                    else if (choiceOne == 1)
                    {
                        for (int j = 0; j < computercard.Count; j++)
                        {
                            if (computercard[j].mark == temp[0] && computercard[j].number == parseNumber)
                            {
                                isCardRight = false;
                                break;
                            }
                            else { isCardRight = true; }
                        }

                        if (isCardRight)
                        {
                            for (int k = 0; k < playercard.Count; k++)
                            {
                                if (playercard[k].mark == temp[0] && playercard[k].number == parseNumber)
                                {
                                    isCardRight = false;
                                    break;
                                }
                                else { isCardRight = true; }
                            }
                        }

                        if (isCardRight == true)
                        {
                            playercard.Add(new Card(temp[0], parseNumber));
                            break;
                        }
                    }
                }
            }

            //카드 정렬 (숫자 기준으로)
            if (choiceOne == 0)
            {
                sortCard = computercard;
                computercard = sortCard.OrderBy(x => x.number).ToList();
            }
            else if (choiceOne == 1)
            {
                sortCard = playercard;
                playercard = sortCard.OrderBy(x => x.number).ToList();
            }
        }

        public void playerCardChange(int CardNumber)
        {
            string[] temp = new string[2];
            int parseNumber = 0;
            bool isCardRight = false;

            List<Card> sortCard = new List<Card>();

            playercard.RemoveAt(CardNumber);

            while (true)
            {
                isCardRight = false;
                temp = trumpcard_.ReStringRollCard();
                int.TryParse(temp[1], out parseNumber);

                for (int j = 0; j < computercard.Count; j++)
                {
                    if (computercard[j].mark == temp[0] && computercard[j].number == parseNumber)
                    {
                        isCardRight = false;
                        break;
                    }
                    else { isCardRight = true; }
                }

                if (isCardRight)
                {
                    for (int k = 0; k < playercard.Count; k++)
                    {
                        if (playercard[k].mark == temp[0] && playercard[k].number == parseNumber)
                        {
                            isCardRight = false;
                            break;
                        }
                        else { isCardRight = true; }
                    }
                }

                if (isCardRight == true)
                {
                    playercard.Add(new Card(temp[0], parseNumber));
                    break;
                }
            }

            sortCard = playercard;
            playercard = sortCard.OrderBy(x => x.number).ToList();
        }

        public void playerCardChangeControl(int maxChangeCounter)
        {
            Console.WriteLine();
            Console.WriteLine();

            int choiceNumber = 0;
            int insideCounter = 0;

            bool isdraw = true;
            bool isfinish = false;

            ConsoleKeyInfo keys;

            while (!isfinish)
            {
                if (maxChangeCounter <= insideCounter) break;

                if (isdraw)
                {
                    Console.SetCursorPosition(0, 14);
                    for (int i = 0; i < playercard.Count; i++)
                    {
                        if (i == choiceNumber)
                        {
                            Console.Write("   ▲  ".PadRight(6, ' '));
                        }
                        else
                        {
                            Console.Write("     ".PadRight(7, ' '));
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("왼쪽 A , 오른쪽 D 를 이용하여 이동, Q를 눌러 현재 카드를 바꿉니다. (패스하고 싶다면 P를 눌러주세요)");
                    Console.WriteLine("현재 기회는 {0}", 2 - insideCounter);
                    isdraw = false;
                }

                if (Console.KeyAvailable)
                {
                    keys = Console.ReadKey();
                    if(keys.KeyChar == 'a' || keys.KeyChar == 'A')
                    {
                        if (choiceNumber > 0)
                        {
                            choiceNumber--;
                        }
                        isdraw = true;
                    }
                    else if (keys.KeyChar == 'd' || keys.KeyChar == 'D')
                    {
                        if (choiceNumber < playercard.Count - 1)
                        {
                            choiceNumber++;
                        }
                        isdraw = true;
                    }
                    else if (keys.KeyChar == 'q' || keys.KeyChar == 'Q')
                    {
                        playerCardChange(choiceNumber);
                        insideCounter++;
                        Console.Clear();
                        drawingCard();
                        isdraw = true;
                    }
                    else if (keys.KeyChar == 'p' || keys.KeyChar == 'P')
                    {
                        insideCounter++;
                    }
                }
            }
        }
    }
}
