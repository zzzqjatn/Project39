using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace poker
{
    public class CardGame
    {
        private struct Card //Card 구조체 생성 (마크, 번호)
        {

            public Card(int _mark, int _number) //Card 생성자
            {
                mark = _mark;   //1 : 클로버 , 2 : 하트, 3 : 다이아 , 4 : 스페이드
                number = _number;   //1: A, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11: J, 12: Q, 13: K
            }

            public int mark { get; }    //get을 통한 mark 변수 외부 접근 허용
            public int number { get; }  //get을 통한 number 변수 외부 접근 허용
        }

        private TrumpCard trumpcard_;   //내부에서 쓸 트럼프카드 변수

        private List<Card> computercard = new List<Card>();         //컴퓨터 카드 패
        private List<Card> computerResultcard = new List<Card>();   //pokerConditions()함수에서 모든 경우의 수 중 가장 좋은(승부수) 카드 조합 상태 패 (컴퓨터)
        private List<Card> playercard = new List<Card>();           //플레이어 카드 패
        private List<Card> playerResultcard = new List<Card>();     //pokerConditions()함수에서 모든 경우의 수 중 가장 좋은(승부수) 카드 조합 상태 패 (플레이어)
        private int computerRule = 0;                               //승부수카드의 포커 족보 값 설정 값 변수 (컴퓨터)
        private int playerRule = 0;                                 //승부수카드의 포커 족보 값 설정 값 변수 (플레이어)

        private int playerMoney;    //플레이어 소지금
        private int bettingMoney;   //플레이어 배팅금

        public CardGame()
        {
            playerMoney = 10_000; //플레이어 소지금(초기10,000원)
            bettingMoney = 0;     //배팅 초기값 세팅 0

            trumpcard_= new TrumpCard();    //트럼프카드 변수에 값 세팅 (인스턴스화)
        }

        public void InGame()
        {
            Task loopTask;  //타이머를 위한 Task 변수 (비동기)
            int timer = 0;  //타이머 카운트 변수

            //게임 로직 반복문
            while (true)
            {
                cardDraw(5, 0); //카드 드로우 함수(매개변수 : 드로우 횟수, 누가 할것인가? : 컴퓨터가 [0: 컴퓨터 , 1: 플레이어] )
                cardDraw(5, 1); //카드 드로우 함수(매개변수 : 드로우 횟수, 누가 할것인가? : 플레이어가 [0: 컴퓨터 , 1: 플레이어] )
                Console.SetCursorPosition(0,0); //콘솔의 커서 위치 변경(콘솔에 그려지는 위치 조정)
                Console.WriteLine();
                drawingCard(0); //(매개변수  0 : 컴퓨터 or 1 : 플레이어) 컴퓨터가 가지고 있는 카드 수 만큼 화면에 그려주는 함수
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
                drawingCard(1); //(매개변수  0 : 컴퓨터 or 1 : 플레이어) 플레이어가 가지고 있는 카드 수 만큼 화면에 그려주는 함수

                Console.WriteLine();
                Console.Write("( 미리보는 승부 : ");  //미리 승부 결과값을 위한 안내출력문 
                switch (playerWinning())    //playerWinning()은 위에 리스트들을 통해 플레이어와 컴퓨터의 패를 보고 승리여부를 결정해주는 함수
                {                           //정수반환값으로 2 : 플레이어 승리 , 1 : 컴퓨터 승리, 0 : 서로 비겼을 때 를 반환한다.
                    case 2:
                        Console.WriteLine("플레이어가 이겼습니다. )");
                        break;
                    case 1:
                        Console.WriteLine("컴퓨터가 이겼습니다. )");
                        break;
                    case 0:
                        Console.WriteLine("비겼습니다. )");
                        break;
                }
                Console.WriteLine();                                            //단순 출력문 : 승부 룰에 대해 알려준다.
                Console.WriteLine("이기는 순위 : ");
                Console.WriteLine();
                Console.WriteLine("[ 스페이드 >> 다이아 >> 하트 >> 클로버 ]");
                Console.WriteLine();
                Console.WriteLine("[ A >> K >> Q >> J >> 10 ... ]");
                Console.WriteLine();

                //게임 베팅이 정상적으로 되면
                if (inputBetting())     //inputBetting() 배팅을 입력하고 배팅에 대한 예외처리 하는 함수
                {                       //정상적인 배팅을 하면 true 값을 패스,예외처리 값 이라면 false를 반환한다.
                    cardDraw(2, 0);     //컴퓨터 2장 드로우
                    Console.Clear();    //콘솔화면 클리어
                    drawingCard(0);     //컴퓨터 카드 패 그리기
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    drawingCard(1);     //플레이어 카드 패 그리기
                    playerCardChangeControl(2); //플레이어 카드 패 바꾸기 찬스 (매개변수 : 바꾸기 횟수 [현재 2번])
                    Console.WriteLine("================================================================");    //가독성

                    timer = 2;  //타이머 2초 설정
                    loopTask = Task.Run(async () =>
                    {
                        Console.MoveBufferArea(0, 200, 20, 1, 15, 23);  //콘솔의 일정 위치의 범위를 원하는 좌표에 덮어씌워주는 메서드이다
                                                                        //매개변수(가져올 열 좌표,가져올 행 좌표,가져올 열 길이,가져올 행 길이,붙여줄 열좌표, 붙여줄 행좌표)

                        //현재는 빈 곳을 가져와 내가 그려줄 곳에 미리 덮어씌워 이전에 있던 글씨나
                        //그림들을 지워주는 방식으로 쓰고 있다.
                        Console.SetCursorPosition(15, 23);  //콘솔 그릴 위치 (15열, 23행)
                        Console.WriteLine("계산 결과 중...{0}", timer);
                        await Task.Delay(1000); //1초 뒤에 적용될 코드를 밑에 쓴다.
                        timer--;    //실행은 했지만 1초뒤 적용된다.
                    });

                    while (true)    //타이머 반복문
                    {
                        if (timer > 0 && loopTask.IsCompleted)  //타이머가 0보다 크고, 이전 loopTask가 현재 실행이 끝났다면
                        {
                            loopTask = Task.Run(async () =>         //선언과 동시에 실행
                            {
                                Console.MoveBufferArea(0, 200, 20, 1, 15, 23);  //이전 문자를 위한 덮어주기
                                Console.SetCursorPosition(15, 23);              //쓸 위치 선언
                                Console.WriteLine("계산 결과 중...{0}", timer);
                                await Task.Delay(1000);     //1초 뒤에 적용
                                timer--;    //timer 1빼기
                            });
                        }

                        if (timer <= 0) // 만약 timer 값이 0보다 작거나 같다면
                        {
                            Console.MoveBufferArea(0, 200, 20, 1, 15, 23);  //이전 문자 덮어주기
                            Console.SetCursorPosition(15, 23);              //그 위치에 쓰기설정
                            Console.WriteLine("계산 결과 중...{0}", timer);  //쓰기
                            break;  //반복문 탈출
                        }
                    }
                    Console.WriteLine();

                    Console.SetCursorPosition(0, 23);   //쓰기 위치 설정
                    switch (playerWinning())    //플레이어와 컴퓨터의 패를 보고 승리여부를 결정해주는 함수 ( 2: 플레이어 승, 1: 컴퓨터 승,0: 비김 )
                    {
                        //결과값에 대한 안내출력문
                        case 2:
                            playerMoney += (bettingMoney * 2);
                            Console.WriteLine("배팅금 : {0} 원, 추가금 {1} 원 ({2} X 2) 현재 소지금은 : {3} 원", bettingMoney, bettingMoney * 2, bettingMoney, playerMoney);
                            Console.WriteLine("플레이어가 이겼습니다.");
                            break;
                        case 1:
                            playerMoney -= bettingMoney;
                            Console.WriteLine("배팅금 : {0} 원, 나가는 금액 {1} 원 현재 소지금은 : {2} 원", bettingMoney, bettingMoney, playerMoney);
                            Console.WriteLine("컴퓨터가 이겼습니다.");
                            break;
                        case 0:
                            Console.WriteLine("배팅금 : {0} 원, 현재 소지금은 : {1}", bettingMoney, playerMoney);
                            Console.WriteLine("비겼습니다.");
                            break;
                    }
                    timer = 10; //타이머 10초 설정
                    loopTask = Task.Run(async () => //선언과 실행
                    {
                        Console.MoveBufferArea(0, 200, 50, 1, 0, 26);   // 글 쓸 위치 덮어주기
                        Console.SetCursorPosition(0, 26);               // 그 위치로 쓰기 설정
                        Console.WriteLine(" {0} 초 뒤 초기화면으로 돌아갑니다.", timer);
                        await Task.Delay(1000); //1초(1000 은 1초)뒤 적용
                        timer--;    //timer 1값 빼기
                    });

                    while (true)    //타이머 반복문
                    {
                        if (timer > 0 && loopTask.IsCompleted)  //타이머가 0보다 크고, 이전 loopTask가 현재 실행이 끝났다면
                        {
                            loopTask = Task.Run(async () => //선언과 동시에 실행
                            {
                                Console.MoveBufferArea(0, 200, 50, 1, 0, 26);                   //이전 문자 덮어주기
                                Console.SetCursorPosition(0, 26);                               //그 위치에 쓰기설정
                                Console.WriteLine(" {0} 초 뒤 초기화면으로 돌아갑니다.", timer);  //쓰기
                                await Task.Delay(1000); //1초(1000 은 1초)뒤 적용
                                timer--;    //timer 1값 빼기
                            });
                        }

                        if (timer <= 0) // 만약 timer 값이 0보다 작거나 같다면
                        {
                            Console.MoveBufferArea(0, 200, 50, 1, 0, 26);                    //이전 문자 덮어주기
                            Console.SetCursorPosition(0, 26);                                //그 위치에 쓰기설정
                            Console.WriteLine(" {0} 초 뒤 초기화면으로 돌아갑니다.", timer);   //쓰기
                            break;  //타이머 반복문 나가기
                        }
                    }
                    //게임 종료 조건
                    if (playerMoney >= 100_000) //플레이어 소지금이 100,000원보다 이상이면
                    {
                        Console.WriteLine("목표 금액 : 100,000 달성하셨습니다. 축하드립니다! 현재 소지금 {0} 원", playerMoney);
                        Thread.Sleep(5000); //잠시 기달려주기
                        break;
                    }
                    else if (playerMoney <= 0)  //플레이어 소지금이 없으면
                    {
                        Console.WriteLine("남은 소지금이 없습니다. 안녕히 가십시오. 현재 소지금 {0} 원", playerMoney);
                        Thread.Sleep(5000); //잠시 기달려주기
                        break;
                    }
                }       //게임 베팅이 한 if문 종료 ↑

                Cleanning();    //모든 리스트 플레이어 컴퓨터 관련 값 초기화 함수
            }//게임 로직 반복문
        }

        public int pokerConditions(int choiceOne)
        {
            List<Card> tempCard = new List<Card>();     //원문 리스트
            List<Card> reMatchCard = new List<Card>();  //검사에 필요한 정렬변환한 리스트
            List<Card> Conditions = new List<Card>();   //결과 완료 카드 리스트

            if(choiceOne == 0)
            {
                tempCard = computercard;
                reMatchCard = computercard;
            }
            else if(choiceOne == 1)
            {
                tempCard = playercard;
                reMatchCard = playercard;
            }

            bool onePair = false;
            bool twoPairs = false;
            bool trips = false;
            bool fourCard = false;
            bool flush = false;
            bool straight = false;

            int incount = 0;

            //연속되는 숫자 5개의 경우
            for (int i = 0; i < reMatchCard.Count; i++)
            {
                for (int j = i + 1; j < reMatchCard.Count; j++)
                {
                    if (reMatchCard[i].number + 1 == reMatchCard[j].number)
                    {
                        if(incount == 0) Conditions.Add(reMatchCard[i]);
                        Conditions.Add(reMatchCard[j]);
                        incount++;
                        if(incount == 4 && straight)
                        {
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                        }
                        else if(incount == 4)
                        {
                            straight = true;
                        }
                        if (incount >= 5)
                        {
                            Conditions.RemoveAt(0);
                        }
                        i++;
                    }
                    else if (!straight)
                    {
                        if (Conditions.Count > 0) Conditions.Clear();
                        break;
                    }
                }
                incount = 0;
            }
            if (straight && Conditions.Count > 5)
            {
                for (int i = Conditions.Count - 1; 4 < i; i--)
                {
                    Conditions.RemoveAt(i);
                }
            }

            //결과확인
            if (straight)
            {
                if (choiceOne == 0) computerResultcard = Conditions;
                else if (choiceOne == 1) playerResultcard = Conditions;
                return 6;
            }
            else
            {
                Conditions.Clear();
            }

            reMatchCard = tempCard.OrderBy(x => x.mark).ToList();
            incount = 0;
            //플래쉬 (같은 모양 5개)
            for (int i = 0; i < reMatchCard.Count - 1; i++)
            {
                for (int j = i + 1; j < reMatchCard.Count; j++)
                {
                    if (reMatchCard[i].mark == reMatchCard[j].mark)
                    {
                        if (incount == 0) Conditions.Add(reMatchCard[i]);
                        Conditions.Add(reMatchCard[j]);
                        incount++;
                        if (incount == 4 && flush)
                        {
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                        }
                        else if (incount == 4)
                        {
                            flush = true;
                        }
                        if (incount >= 5)
                        {
                            Conditions.RemoveAt(0);
                        }
                        i++;
                    }
                    else if (!flush)
                    {
                        if (Conditions.Count > 0) Conditions.Clear();
                        break;
                    }
                }
                incount = 0;
            }
            if(flush && Conditions.Count > 5)
            {
                for(int i = Conditions.Count - 1; 4 < i; i--)
                {
                    Conditions.RemoveAt(i);
                }
            }

            if (flush)
            {
                if (choiceOne == 0) computerResultcard = Conditions;
                else if (choiceOne == 1) playerResultcard = Conditions;
                return 5;
            }
            else
            {
                Conditions.Clear();
            }

            reMatchCard = tempCard;
            incount = 0;
            //원페어 트리플 포카드 (같은 숫자 찾기)
            for (int i = 0; i < reMatchCard.Count; i++)
            {
                for (int j = i + 1; j < reMatchCard.Count; j++)
                {
                    if (reMatchCard[i].number == reMatchCard[j].number)
                    {
                        if (incount == 0) Conditions.Add(reMatchCard[i]);
                        Conditions.Add(reMatchCard[j]);
                        incount++;

                        //원페어
                        if (incount == 1 && onePair && !trips && !fourCard)
                        {
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                        }
                        else if (incount == 1 && !trips && !fourCard) onePair = true;

                        //트리플
                        if (incount == 2 && trips && !fourCard)
                        {
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                        }
                        else if (incount == 2 && !fourCard)
                        {
                            trips = true;
                            onePair = false;
                        }

                        //포카드
                        if (incount == 3 && fourCard)
                        {
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                        }
                        else if (incount == 3)
                        {
                            fourCard = true;
                            trips = false;
                        }

                        //포카드 넘을때
                        if (incount > 3 && fourCard)
                        {
                            Conditions.RemoveAt(0);
                        }
                        i++;
                    }
                    else break;
                }
                incount = 0;
            }
            //나머지 적재된 값 정리
            if (fourCard && Conditions.Count > 4)
            {
                for (int i = Conditions.Count - 1; 3 < i; i--)
                {
                    Conditions.RemoveAt(i);
                }
            }
            else if (trips && Conditions.Count > 3)
            {
                for (int i = Conditions.Count - 1; 2 < i; i--)
                {
                    Conditions.RemoveAt(i);
                }
            }

            //결과확인
            if (fourCard)
            {
                if (choiceOne == 0) computerResultcard = Conditions;
                else if (choiceOne == 1) playerResultcard = Conditions;
                return 4;
            }
            else if(trips)
            {
                if (choiceOne == 0) computerResultcard = Conditions;
                else if (choiceOne == 1) playerResultcard = Conditions;
                return 3;
            }
            else
            {
                Conditions.Clear();
            }

            incount = 0;
            //원페어 트리플 포카드 (같은 숫자 찾기)
            for (int i = 0; i < reMatchCard.Count; i++)
            {
                for (int j = i + 1; j < reMatchCard.Count; j++)
                {
                    if (reMatchCard[i].number == reMatchCard[j].number)
                    {
                        Conditions.Add(reMatchCard[i]);
                        Conditions.Add(reMatchCard[j]);
                        onePair = true;
                        incount++;

                        if (incount == 1 && twoPairs)
                        {
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                            incount = 0;
                        }
                        else if (incount == 2)
                        {
                            twoPairs = true;
                            incount = 0;
                        }

                        i = j + 1;
                        j = i;
                    }
                    else break;
                }
            }

            if (twoPairs)
            {
                if (choiceOne == 0) computerResultcard = Conditions;
                else if (choiceOne == 1) playerResultcard = Conditions;
                return 2;
            }
            else if (onePair)
            {
                if (choiceOne == 0) computerResultcard = Conditions;
                else if (choiceOne == 1) playerResultcard = Conditions;
                return 1;
            }
            else
            {
                Conditions.Clear();
            }

            if (choiceOne == 0) computerResultcard = computercard;
            else if (choiceOne == 1) playerResultcard = playercard;
            return 0;
        }   //대략적인 결과를 (노페어,원페어,투페어,트러플 등등) 알려주는 함수 

        public int markToNumber(string input)
        {
            int Result = 0;

            switch (input)
            {
                case "♠":
                    Result = 4;
                    break;
                case "◆":
                    Result = 3;
                    break;
                case "♥":
                    Result = 2;
                    break;
                case "♣":
                    Result = 1;
                    break;
            }
            return Result;
        }   //문자를 번호로 바꿔주는 함수

        public string NumberToString(int input,int choice)
        {
            string Result = string.Empty;

            if (choice == 0)
            {
                switch (input)
                {
                    case 4:
                        Result = "♠";
                        break;
                    case 3:
                        Result = "◆";
                        break;
                    case 2:
                        Result = "♥";
                        break;
                    case 1:
                        Result = "♣";
                        break;
                }
            }
            else if (choice == 1)
            {
                switch (input)
                {
                    case 1:
                        Result = "A";
                        break;
                    case 11:
                        Result = "J";
                        break;
                    case 12:
                        Result = "Q";
                        break;
                    case 13:
                        Result = "K";
                        break;
                    default:
                        Result = input.ToString();
                        break;
                }
            }

            return Result;
        }   //번호를 문자로 바꿔주는 함수

        public void drawingCard(int choiceOne)
        {
            List<Card> tempList = new List<Card>();

            if (choiceOne == 0)
            {
                tempList = computercard;
                Console.WriteLine("컴퓨터의 카드 {0} 장", tempList.Count);
            }
            else if(choiceOne == 1)
            {
                tempList = playercard;
                Console.WriteLine("플레이어의 카드 {0} 장", tempList.Count);
            }

            for(int i = tempList.Count; i > 0; i--)
            {
                Console.Write(" ----- ".PadRight(5, ' '));
            }
            Console.WriteLine();
            
            foreach(Card one in tempList)
            { 
                switch(one.mark)
                {
                    case 4:
                        Console.Write("| ♠  |".PadRight(5, ' '));
                        break;
                    case 3:
                        Console.Write("| ◆  |".PadRight(5, ' '));
                        break;
                    case 2:
                        Console.Write("| ♥  |".PadRight(5, ' '));
                        break;
                    case 1:
                        Console.Write("| ♣  |".PadRight(5, ' '));
                        break;
                }
            }

            Console.WriteLine();
            for (int i = tempList.Count; i > 0; i--)
            {
                Console.Write("|     |".PadRight(5,' '));
            }

            Console.WriteLine();
            foreach (Card one in tempList)
            {
                switch(one.number)
                {
                    case 1:
                        Console.Write("|   A |".PadRight(5, ' '));
                        break;
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
                    default:
                        Console.Write("|   {0} |".PadRight(8, ' '), one.number);
                        break;
                }
            }

            Console.WriteLine();
            for (int i = tempList.Count; i > 0; i--)
            {
                Console.Write(" ----- ".PadRight(5, ' '));
            }
            Console.WriteLine();
            if(tempList.Count > 4)
            {
                int temp = pokerConditions(choiceOne);

                if (choiceOne == 0)
                {
                    computerRule = temp;
                    Console.Write("현재 컴퓨터는 ");
                }
                else if (choiceOne == 1)
                {
                    playerRule = temp;
                    Console.Write("현재 플레이어는 ");
                }

                string forNopair = string.Empty;
                if (tempList[0].number != 1)
                {
                    forNopair += NumberToString(tempList[tempList.Count - 1].mark, 0);
                    forNopair += " ";
                    forNopair += NumberToString(tempList[tempList.Count - 1].number, 1);
                }
                else
                {
                    forNopair += NumberToString(tempList[0].mark, 0);
                    forNopair += " ";
                    forNopair += NumberToString(tempList[0].number, 1);
                }

                switch (temp)
                {
                    case 6:
                        Console.WriteLine("스트레이트 입니다");
                        break;
                    case 5:
                        Console.WriteLine("플래쉬 입니다");
                        break;
                    case 4:
                        Console.WriteLine("포카드 입니다");
                        break;
                    case 3:
                        Console.WriteLine("트리플 입니다");
                        break;
                    case 2:
                        Console.WriteLine("투페어 입니다");
                        break;
                    case 1:
                        Console.WriteLine("원페어 입니다");
                        break;
                    case 0:
                        Console.WriteLine("노페어 {0} 니다", forNopair);
                        break;
                }
            }
        }       //카드를 그려주는 함수

        public bool inputBetting()
        {
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("현재 소지금은 {0} 원",playerMoney);
                Console.Write("배팅하실 금액을 입력해주세요 (0원은 패스입니다.) : ");

                if (int.TryParse(Console.ReadLine(),out bettingMoney))
                {
                    if (bettingMoney == 0)
                    {
                        return false;
                    }
                    else if(playerMoney < bettingMoney)
                    {
                        Console.WriteLine();
                        Console.WriteLine("=======================================================================");
                        Console.WriteLine("[system] 소지금 초과 (현재 소지금보다 이하로 배팅해주세요)");
                        Console.WriteLine("=======================================================================");
                        Console.WriteLine();
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("=======================================================================");
                    Console.WriteLine("[system] 잘못된 예외 값 (숫자만 입력해주세요)");
                    Console.WriteLine("=======================================================================");
                    Console.WriteLine();
                }
            }

            return true;
        }   //배팅에 대한 값처리 성공여부 예외처리 등을 하는 함수

        public void cardDraw(int DrawCounter, int choiceOne)
        {
            //witchOne 0은 컴퓨터, 1은 플레이어
            string[] Cardtemp = new string[2];
            int parseMark = 0;
            int parseNumber = 0;
            bool isCardRight = false;

            List<Card> choicetemp = new List<Card>();

            List<Card> sortCard = new List<Card>();

            //들어온 카드 현재 카드들과 겹치는지
            //컴퓨터 , 내꺼
            if(choiceOne == 0)
            {
                choicetemp = computercard;
            }
            else if(choiceOne == 1)
            {
                choicetemp = playercard;
            }

            //첫번째 값은 중복없으니
            if (choicetemp.Count == 0)
            {
                Cardtemp = trumpcard_.ReStringRollCard();

                parseMark = markToNumber(Cardtemp[0]);
                int.TryParse(Cardtemp[1], out parseNumber);

                choicetemp.Add(new Card(parseMark, parseNumber));
                DrawCounter--;
            }

            //카드 드로우
            for (int i = 0; i < DrawCounter; i++)
            {
                while (true)
                {
                    isCardRight = false;

                    Cardtemp = trumpcard_.ReStringRollCard();
                    parseMark = markToNumber(Cardtemp[0]);
                    int.TryParse(Cardtemp[1], out parseNumber);

                    //컴퓨터 중복확인
                    for (int j = 0; j < computercard.Count; j++)
                    {
                        if (computercard[j].mark == parseMark && computercard[j].number == parseNumber)
                        {
                            isCardRight = false;
                            break;
                        }
                        else { isCardRight = true; }
                    }

                    if (isCardRight)
                    {
                        //플레이어 카드 중복확인
                        for (int k = 0; k < playercard.Count; k++)
                        {
                            if (playercard[k].mark == parseMark && playercard[k].number == parseNumber)
                            {
                                isCardRight = false;
                                break;
                            }
                            else { isCardRight = true; }
                        }
                    }

                    if (isCardRight == true)
                    {
                        choicetemp.Add(new Card(parseMark, parseNumber));
                        break;
                    }
                }
                //카드 정렬 (숫자 기준으로)
                if (choiceOne == 0)
                {
                    sortCard = choicetemp;
                    computercard = sortCard.OrderBy(x => x.mark).OrderBy(x => x.number).ToList();
                }
                else if (choiceOne == 1)
                {
                    sortCard = choicetemp;
                    playercard = sortCard.OrderBy(x => x.mark).OrderBy(x => x.number).ToList();
                }
            }
        }   //카드를 뽑아주는 함수

        public void playerCardChange(int CardNumber)
        {
            string[] Cardtemp = new string[2];
            int parseMark = 0;
            int parseNumber = 0;
            bool isCardRight = false;

            List<Card> sortCard = new List<Card>();

            playercard.RemoveAt(CardNumber);

            while (true)
            {
                isCardRight = false;
                Cardtemp = trumpcard_.ReStringRollCard();
                parseMark = markToNumber(Cardtemp[0]);
                int.TryParse(Cardtemp[1], out parseNumber);

                for (int j = 0; j < computercard.Count; j++)
                {
                    if (computercard[j].mark == parseMark && computercard[j].number == parseNumber)
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
                        if (playercard[k].mark == parseMark && playercard[k].number == parseNumber)
                        {
                            isCardRight = false;
                            break;
                        }
                        else { isCardRight = true; }
                    }
                }

                if (isCardRight == true)
                {
                    playercard.Add(new Card(parseMark, parseNumber));
                    break;
                }
            }

            sortCard = playercard;
            playercard = sortCard.OrderBy(x => x.number).ToList();
        }   //플레이어 카드를 바꿔주는 함수

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
                    Console.SetCursorPosition(0, 18);
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
                    Console.WriteLine();
                    Console.WriteLine("왼쪽 A , 오른쪽 D 를 이용하여 이동, Q를 눌러 현재 카드를 바꿉니다. (패스하고 싶다면 P를 눌러주세요)");
                    Console.WriteLine("현재 기회는 {0} , 현재 배팅 금액 {1} 원", (maxChangeCounter - insideCounter), bettingMoney);
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
                        drawingCard(0);
                        Console.WriteLine();    //가독성
                        Console.WriteLine();    //가독성
                        Console.WriteLine();    //가독성
                        drawingCard(1);
                        isdraw = true;
                    }
                    else if (keys.KeyChar == 'p' || keys.KeyChar == 'P')
                    {
                        insideCounter++;
                        isdraw = true;
                    }
                }
            }
            Console.SetCursorPosition(0, 21);
            Console.WriteLine("현재 기회는 {0} , 현재 배팅 금액 {1} 원", (maxChangeCounter - insideCounter), bettingMoney);
        }   //카드 바꿔주는 UI 그려주는 함수

        public int playerWinning()
        {
            // 2 플레이어 승 1 컴퓨터 승 0 드로우
            int result = 0;
            Card PlayerFirstTemp = playercard[0];
            Card PlayerLastTemp = playercard[playercard.Count - 1];
            Card ComFirstTemp = computercard[0];
            Card ComLastTemp = computercard[computercard.Count - 1];

            Card ResultComFirst = computerResultcard[0];
            Card ResultComLast = computerResultcard[computerResultcard.Count - 1];
            Card ResultPlayerFirst = playerResultcard[0];
            Card ResultPlayerLast = playerResultcard[playerResultcard.Count - 1];

            if (playerRule > computerRule)
            {
                result = 2;
            }
            else if (playerRule < computerRule)
            {
                result = 1;
            }
            //노페어 일때
            else if (playerRule == 0 && computerRule == 0)
            {
                //A가 있을때
                if (PlayerFirstTemp.number == 1 && ComFirstTemp.number == 1)
                {
                    if (PlayerFirstTemp.mark > ComFirstTemp.mark) result = 2;
                    else if (PlayerFirstTemp.mark < ComFirstTemp.mark) result = 1;
                    else result = 0;
                }
                else if (PlayerFirstTemp.number == 1 && ComFirstTemp.number != 1)
                {
                    result = 2;
                }
                else if (PlayerFirstTemp.number != 1 && ComFirstTemp.number == 1)
                {
                    result = 1;
                }
                else
                {
                    //컴퓨터의 마지막 카드 와 플레이어의 마지막 카드 번호가 같을 때
                    if (ComLastTemp.number == PlayerLastTemp.number)
                    {
                        if (ComLastTemp.mark < PlayerLastTemp.mark) result = 2;
                        else if (ComLastTemp.mark > PlayerLastTemp.mark) result = 1;
                        else result = 0;
                    }
                    else if (ComLastTemp.number < PlayerLastTemp.number)
                    {
                        result = 2;
                    }
                    else if (ComLastTemp.number > PlayerLastTemp.number)
                    {
                        result = 1;
                    }
                    else result = 0;
                }
            }
            else if (playerRule == computerRule) //만약 조건이 같을 때 가장 큰값의 마크가 어떤것 인지에 따라
            {
                //A가 있을때
                if (ResultPlayerFirst.number == 1 && ResultComFirst.number == 1)
                {
                    if (ResultPlayerFirst.mark > ResultComFirst.mark) result = 2;
                    else if (ResultPlayerFirst.mark < ResultComFirst.mark) result = 1;
                    else result = 0;
                }
                else if (ResultPlayerFirst.number == 1 && ResultComFirst.number != 1)
                {
                    result = 2;
                }
                else if (ResultPlayerFirst.number != 1 && ResultComFirst.number == 1)
                {
                    result = 1;
                }
                else
                {
                    //컴퓨터의 마지막 카드 와 플레이어의 마지막 카드 번호가 같을 때
                    if (ResultComLast.number == ResultPlayerLast.number)
                    {
                        if (ResultComLast.mark < ResultPlayerLast.mark) result = 2;
                        else if (ResultComLast.mark > ResultPlayerLast.mark) result = 1;
                        else result = 0;
                    }
                    else if (ResultComLast.number < ResultPlayerLast.number)
                    {
                        result = 2;
                    }
                    else if (ResultComLast.number > ResultPlayerLast.number)
                    {
                        result = 1;
                    }
                    else result = 0;
                }
            }
            return result;
        }   //대략적인 결과를 통해 비교 및 동일할 경우 서로 마크 비교(1번) 세밀한 승부 결과 반환

        public void Cleanning()
        {
            if (computercard.Count > 0) computercard.Clear();
            if (computerResultcard.Count > 0) computerResultcard.Clear();
            if (playercard.Count > 0) playercard.Clear();
            if (playerResultcard.Count > 0) playerResultcard.Clear();
            computerRule = 0;
            playerRule = 0;
            Console.Clear();
        }   //플레이어, 컴퓨터에 대한 초기화 함수
    }
}