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
        private List<Card> computerResultcard = new List<Card>();   //pokerConditions()함수에서 모든 경우의 수 중 가장 좋은 족보 카드 조합 상태 패 (컴퓨터)
        private List<Card> playercard = new List<Card>();           //플레이어 카드 패
        private List<Card> playerResultcard = new List<Card>();     //pokerConditions()함수에서 모든 경우의 수 중 가장 좋은 족보 카드 조합 상태 패 (플레이어)
        private int computerRule = 0;                               //최종적인 포커 족보 값 변수 (컴퓨터)
        private int playerRule = 0;                                 //최종적인 포커 족보 값 변수 (플레이어)

        private int playerMoney;    //플레이어 소지금
        private int bettingMoney;   //플레이어 배팅금

        public CardGame()
        {
            playerMoney = 10_000; //플레이어 소지금(초기10,000원)
            bettingMoney = 0;     //배팅 초기값 세팅 0

            trumpcard_= new TrumpCard();    //트럼프카드 변수에 값 세팅 (인스턴스화)
        }

        public void InGame() //(기본형 : 노페어, 원페어, 투페어, 트리플, 포카드, 플러쉬, 스트레이트 구현)
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

                    TIMER_Message(2, "계산 결과가 완료됩니다.", 15, 23);  //텍스트 타이머 변수 (몇 초, 문자열, 좌표x, 좌표y)

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
                    TIMER_Message(10, "초기화면으로 돌아갑니다.", 3, 26);

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

        public int pokerConditions(int choiceOne) //포커 족보 값을 반환해주는 함수 
        {
            List<Card> tempCard = new List<Card>();     //원본리스트 대입리스트 (한 함수에서 여러가지 경우를 사용하기 위해서 선언)
            List<Card> reMatchCard = new List<Card>();  //실제 조건 검사를 위한 리스트(정렬부분을 다르게 주어 조건을 검사하기 위함) EX) 플래쉬 문자로 정렬 나머진 숫자 정렬
            List<Card> Conditions = new List<Card>();   //결과 완료한 최종 족보 패만 주기 위한 리스트

            if(choiceOne == 0)  // 0: 컴퓨터 라면
            {
                tempCard = computercard;    // 원본 리스트에 컴퓨터 패 대입하기
                reMatchCard = computercard; // 조건검사를 위한 리스트에 컴퓨터 패 대입하기
            }
            else if(choiceOne == 1) // 1: 플레이어 라면
            {
                tempCard = playercard;      // 원본 리스트에 플레이어 패 대입하기
                reMatchCard = playercard;   // 조건검사를 위한 리스트에 플레이어 패 대입하기
            }

            //포커 족보 체크를 위한 bool 값
            bool onePair = false;
            bool twoPairs = false;
            bool trips = false;
            bool fourCard = false;
            bool flush = false;
            bool straight = false;

            int incount = 0;    //조건 검사에 따른 내부 카운터 세기를 위한 변수

            bool backstraight = false;
            //백스트레이트 (A,2,3,4,5)
            for (int i = 0; i < reMatchCard.Count; i++) //검사 리스트 처음부터 끝까지 반복
            {
                if (reMatchCard[i].number == 1) // 1 찾기
                {
                    Conditions.Add(reMatchCard[i]);
                    incount++;

                    for (int j = i + 1; j < reMatchCard.Count; j++)
                    {

                    }

                    i++;
                }
                else if (!straight)
                {
                    if (Conditions.Count > 0) Conditions.Clear();
                    break; 
                }
                for (int j = i + 1; j < reMatchCard.Count; j++)
                {

                }
                incount = 0;
            }
            if (straight && Conditions.Count > 5)   //조건이 맞다면 반복문 내부에 계속 적재되기 때문에 체크
            {
                for (int i = Conditions.Count - 1; 4 < i; i--)  //내부 0 ~ 4까지의 straight 값 빼고 끝부터 내부로 남아있을 때까지
                {
                    Conditions.RemoveAt(i); //제거 하기
                }
            }

            //결과확인
            if (straight)   //맞다면
            {
                if (choiceOne == 0) computerResultcard = Conditions;    //컴퓨터꺼라면 컴퓨터 족보 패에 족보 패값 대입
                else if (choiceOne == 1) playerResultcard = Conditions; //플레이어꺼라면 플레이어 족보 패에 족보 패값 대입
                return 6;   //스트레이트 값 리턴 (좋은 패일수록 높은 정수값을 주어 나중에 비교 시 높은 값 비교를 통해(추후 같은 족보 패라면 세부검사로 마크를 통해) 승리를 준다)
            }
            else
            {
                Conditions.Clear(); //아니라면 현재 검사완료 패 클리어
            }
            //---------------------------------------------------------------------------------------------

            incount = 0;
            //스트레이트 (연속되는 숫자 5개의 경우)
            for (int i = 0; i < reMatchCard.Count; i++) //검사 리스트 처음부터 끝까지 반복
            {
                for (int j = i + 1; j < reMatchCard.Count; j++) //검사하는 순번의 다음순번부터 비교하기 위한 반복문
                {
                    if (reMatchCard[i].number + 1 == reMatchCard[j].number) //현재 카드번호 + 1(연속된 값)이 다음 카드에 있다면 
                    {
                        if(incount == 0) Conditions.Add(reMatchCard[i]);    //만약 incount가 0이라면(첫번째라면) 현재값 적재
                        Conditions.Add(reMatchCard[j]); //비교된 다음순번 값 적재
                        incount++;  //연속된 숫자에 관한 조건이 됬을 때의 내부 카운터 
                        if(incount == 4 && straight)    //straight가 족보 패리스트에 적재되있는데 또 straight가 됬다면 좋은 값으로 갱신
                        {                               //(작은수 -> 큰수 정렬 이후 같은수의 경우 마크 정렬이 되어 있기 때문에 제일 오른쪽이 가장 강한 카드이다)
                            
                            Conditions.RemoveAt(0);     //앞에 있는 5개의 이전 straight 값 제거 (최신 straight 값만 남아있게 하기 위해)
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                        }
                        else if(incount == 4)   //만약 incount가 4번 되었을 때 (연속된 숫자 조건을 4번 만족했을때 == straight이다)
                        {
                            straight = true;    //straight true
                        }
                        if (incount >= 5)       //만약 5번 이상(straight조건이 됬음에도 그 이상) 연속됬을 경우 뒤에 들어온 가장 큰값은 두고 앞에 가장작은 앞값을 제거
                        {
                            Conditions.RemoveAt(0); //앞의 값 제거
                        }
                        i++;    //straight조건은 연속된 값이기 때문에 i값 추가
                    }
                    else if (!straight) //만약 straight false면 연속된 값을 새로 찾아야하기 때문에
                    {
                        if (Conditions.Count > 0) Conditions.Clear();   //만약 값이 들었다면 클리어
                        break;  // j 반복문 나가기
                    }
                }
                incount = 0;    //내부카운터 초기화
            }
            if (straight && Conditions.Count > 5)   //조건이 맞다면 반복문 내부에 계속 적재되기 때문에 체크
            {
                for (int i = Conditions.Count - 1; 4 < i; i--)  //내부 0 ~ 4까지의 straight 값 빼고 끝부터 내부로 남아있을 때까지
                {
                    Conditions.RemoveAt(i); //제거 하기
                }
            }

            //결과확인
            if (straight)   //맞다면
            {
                if (choiceOne == 0) computerResultcard = Conditions;    //컴퓨터꺼라면 컴퓨터 족보 패에 족보 패값 대입
                else if (choiceOne == 1) playerResultcard = Conditions; //플레이어꺼라면 플레이어 족보 패에 족보 패값 대입
                return 6;   //스트레이트 값 리턴 (좋은 패일수록 높은 정수값을 주어 나중에 비교 시 높은 값 비교를 통해(추후 같은 족보 패라면 세부검사로 마크를 통해) 승리를 준다)
            }
            else
            {
                Conditions.Clear(); //아니라면 현재 검사완료 패 클리어
            }

            reMatchCard = tempCard.OrderBy(x => x.mark).ToList();   //카드 문자 순으로 정렬
            incount = 0;    //내부카운터 값 초기화
            //플래쉬 (같은 모양 5개)
            for (int i = 0; i < reMatchCard.Count - 1; i++)
            {
                for (int j = i + 1; j < reMatchCard.Count; j++) //첫번째를 두고 그 다음 순번의 값들을 반복해서 비교하기
                {
                    if (reMatchCard[i].mark == reMatchCard[j].mark) //만약 문양이 같다면
                    {
                        if (incount == 0) Conditions.Add(reMatchCard[i]);   //처음이라면 혹은 내부카운터가 0값이라면 지금 값 적재
                        Conditions.Add(reMatchCard[j]); // 그 다음 값 적재
                        incount++;  //내부카운팅 증가
                        if (incount == 4 && flush)  //만약 문양이 같다가 4번이고 flush가 true라면 (이전에 있었다면)
                        {
                            Conditions.RemoveAt(0); //새로운 값으로 갱신을 위한 앞의 값 제거(오른쪽일수록 큰값이기 때문에)
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                        }
                        else if (incount == 4)  //만약 문양이 같다가 4번이 됬으면
                        {
                            flush = true;   //flush true
                        }
                        if (incount >= 5)   //만약 내부카운터가 계속 올라간다면 (문양이 4번 같은 상태에서 계속 더 나온다면 큰값으로 갱신)
                        {
                            Conditions.RemoveAt(0); //처음 작은 값 지우기
                        }
                        i++;    //조건이 맞기 때문에 빨리 다음 값으로 넘기기
                    }
                    else if (!flush)    //만약 flush가 false라면
                    {
                        //다음 문양으로 flush를 찾아야 하기 때문에 리스트 클리어
                        if (Conditions.Count > 0) Conditions.Clear();
                        break; //반복문 탈출
                    }
                }
                incount = 0;    //내부카운터 초기화
            }
            if(flush && Conditions.Count > 5)   //만약 flush이고 5개 이상 적재되있다면 (더미값이 있다면)
            {
                for(int i = Conditions.Count - 1; 4 < i; i--)   //더미값 지우기
                {
                    Conditions.RemoveAt(i);
                }
            }

            if (flush)  //flush가 됬다면
            {
                if (choiceOne == 0) computerResultcard = Conditions;    //컴퓨터꺼라면 컴퓨터 족보 패에 족보 패값 대입
                else if (choiceOne == 1) playerResultcard = Conditions; //플레이어꺼라면 플레이어 족보 패에 족보 패값 대입
                return 5;   //flush리턴 
            }
            else    //아니라면
            {
                Conditions.Clear(); //클리어
            }

            reMatchCard = tempCard; //다시 원래 정렬대로 되돌리기
            incount = 0;    //내부카운터 초기화

            //원페어 트리플 포카드 (같은 숫자 찾기)
            for (int i = 0; i < reMatchCard.Count; i++)
            {
                for (int j = i + 1; j < reMatchCard.Count; j++) //첫번째를 두고 그 다음 순번의 값들을 반복해서 비교하기
                {
                    if (reMatchCard[i].number == reMatchCard[j].number) //만약 서로 숫자가 같다면
                    {
                        if (incount == 0) Conditions.Add(reMatchCard[i]);   //내부카운팅값이 초기라면 적재
                        Conditions.Add(reMatchCard[j]); //다음순번 값 적재
                        incount++;  //내부카운팅 증가

                        //(가치값에 따라 트리플이 있다면 원페어는 의미 없고, 포카드가 있다면 트리플이 의미 없기 때문에 bool조건으로 걸어준다)
                        //원페어
                        if (incount == 1 && onePair && !trips && !fourCard) //만약 fourCard, trips 이 아니고 onePair가 또 한번 됬다면 갱신
                        {
                            Conditions.RemoveAt(0); //갱신을 위한 앞의 2개 값 제거
                            Conditions.RemoveAt(0);
                        }
                        else if (incount == 1 && !trips && !fourCard) onePair = true;   //fourCard, trips가 fales상태이며 원카드가 되었을 때

                        //트리플
                        if (incount == 2 && trips && !fourCard) //fourCard가 아니고 trips이 되있는 상태에서 또 trips이면
                        {
                            Conditions.RemoveAt(0); //새로운 값 갱신을 위한 앞의 3개 제거
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                        }
                        else if (incount == 2 && !fourCard) //fourCard 가 아닌 상태에서 트리플이 되면
                        {
                            trips = true;   //트리플 true
                            onePair = false;    //원페어 false (더 큰 값이 있어 의미없기 때문에)
                        }

                        //포카드
                        if (incount == 3 && fourCard)   //fourCard가 있는데 fourCard가 또 되면
                        {
                            Conditions.RemoveAt(0); //새로운 값 갱신을 위해 앞의 4개 제거
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                            Conditions.RemoveAt(0);
                        }
                        else if (incount == 3)  //포카드가 되면
                        {
                            fourCard = true;    //포카드 true
                            trips = false;      //트리플 false (큰값이 있어서 의미 없기 때문에)
                        }

                        //포카드 넘을때
                        if (incount > 3 && fourCard)    //포카드가 있는 상태에서 내부카운팅이 넘어가면
                        {
                            Conditions.RemoveAt(0); //앞의 값을 제거해서 큰값으로 계속 갱신하기
                        }
                        i++;   //조건이 확인 했기때문에 다음으로
                    }
                    else break; //아니라면 탈출
                }
                incount = 0;    //내부카운팅 초기화
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

            //결과확인 (원페어는 투페어보다 낮기 때문에 체크만 하고 아래서 확인한다)
            if (fourCard)   //four카드라면
            {
                if (choiceOne == 0) computerResultcard = Conditions;    //컴퓨터꺼라면 컴퓨터 족보 패에 족보 패값 대입
                else if (choiceOne == 1) playerResultcard = Conditions; //플레이어꺼라면 플레이어 족보 패에 족보 패값 대입
                return 4;
            }
            else if(trips)  //trips카드라면
            {
                if (choiceOne == 0) computerResultcard = Conditions;    //컴퓨터꺼라면 컴퓨터 족보 패에 족보 패값 대입
                else if (choiceOne == 1) playerResultcard = Conditions; //플레이어꺼라면 플레이어 족보 패에 족보 패값 대입
                return 3;
            }
            else
            {
                Conditions.Clear(); //아니라면 클리어
            }

            incount = 0;
            //투페어 찾기
            for (int i = 0; i < reMatchCard.Count; i++)
            {
                for (int j = i + 1; j < reMatchCard.Count; j++) //첫번째를 두고 그 다음 순번의 값들을 반복해서 비교하기
                {
                    if (reMatchCard[i].number == reMatchCard[j].number) //만약 서로 숫자가 같다면
                    {
                        Conditions.Add(reMatchCard[i]); //현재 순번값 적재
                        Conditions.Add(reMatchCard[j]); //다음순번값 적재
                        onePair = true; //원페이 true
                        incount++; //내부 카운팅 증가

                        if (incount == 1 && twoPairs)   //만약 twoPairs가 true인 상태에서 원페어가 또 생기면
                        {
                            Conditions.RemoveAt(0); //투페어니 앞의 낮은 원페어 삭제하고 갱신한다
                            Conditions.RemoveAt(0);
                            incount = 0;    //내부카운팅 초기화
                        }
                        else if (incount == 2)  //만약 2번(투페어)라면
                        {
                            twoPairs = true;    //투페어 true
                            incount = 0;        //내부카운팅 초기화
                        }

                        i = j + 1;  //현재 순번을 다음순번의 다음으로
                        j = i;  //j는 현재 i의 값으로(현재 순번을 다음순번의 다음)이지만 루프가 다시 돌면서 i의 다음번이 된다.
                    }
                    else break; //아니라면 탈출
                }
            }

            if (twoPairs)   //투페어라면
            {
                if (choiceOne == 0) computerResultcard = Conditions;    //컴퓨터꺼라면 컴퓨터 족보 패에 족보 패값 대입
                else if (choiceOne == 1) playerResultcard = Conditions; //플레이어꺼라면 플레이어 족보 패에 족보 패값 대입
                return 2;   //투페어값 리턴
            }
            else if (onePair)   //원페어라면
            {
                if (choiceOne == 0) computerResultcard = Conditions;    //컴퓨터꺼라면 컴퓨터 족보 패에 족보 패값 대입
                else if (choiceOne == 1) playerResultcard = Conditions; //플레이어꺼라면 플레이어 족보 패에 족보 패값 대입
                return 1;   //원페어 값 리턴
            }
            else
            {
                Conditions.Clear(); //아니라면 클리어
            }

            //노페어일 경우
            if (choiceOne == 0) computerResultcard = computercard;  //컴퓨터라면 현재 컴퓨터 값을 컴퓨터 족보 패에 대입  
            else if (choiceOne == 1) playerResultcard = playercard; //플레이어라면 현재 플레이어 값을 플레이어 족보 패에 대입  
            return 0;   //노페어 값 리턴
        }

        public int markToNumber(string input)   //마크를 숫자로 바꿔주는 함수
        {
            int Result = 0; //리턴을 위한 임시 값

            switch (input)      //마크를 가져오면
            {
                case "♠":
                    Result = 4; //숫자값으로 바꾼다 (이는 작은값 -> 큰값으로 정렬 및 큰값으로 마크 비교를 위한 변경)
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
            return Result;  // 그 후 반환
        }

        public string NumberToString(int input,int choice)  //숫자를 문자로 변환(매개변수 : 받아올 숫자값 ,[마크인지, 영문 값인지] 구분을 위한 값)
        {
            string Result = string.Empty;   //반환을 위한 임시 string

            if (choice == 0)    //마크 일 경우
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
            else if (choice == 1)   //영문 일 경우
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
                        Result = input.ToString();  //나머지는 숫자 그대로 string으로 반환
                        break;
                }
            }

            return Result;
        }

        public void drawingCard(int choiceOne)  //카드 및 정보 그리기
        {
            List<Card> tempList = new List<Card>(); //한 함수로 여러기능을 위한 리스트 임시 변수

            if (choiceOne == 0) // 컴퓨터라면
            {
                tempList = computercard;    //컴퓨터 패 대입
                Console.WriteLine("컴퓨터의 카드 {0} 장", tempList.Count);
            }
            else if(choiceOne == 1) //플레이어라면
            {
                tempList = playercard;      //플레이어 패 대입
                Console.WriteLine("플레이어의 카드 {0} 장", tempList.Count);
            }

            //카드 그리는 출력문
            for(int i = tempList.Count; i > 0; i--)
            {
                Console.Write(" ----- ".PadRight(5, ' '));
            }
            Console.WriteLine();
            
            foreach(Card one in tempList)   //카드 문자 그리기
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
            foreach (Card one in tempList)  //카드 숫자 그리기
            {
                switch(one.number)
                {
                    case 1:
                        Console.Write("|   A |".PadRight(5, ' '));
                        break;
                    case 10:
                        Console.Write("|  {0} |".PadRight(5, ' '), one.number);     //두자리 수 (여백이 다르기 때문에) 
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
                        Console.Write("|   {0} |".PadRight(8, ' '), one.number);    //한자리 수
                        break;
                }
            }

            Console.WriteLine();
            for (int i = tempList.Count; i > 0; i--)
            {
                Console.Write(" ----- ".PadRight(5, ' '));
            }
            Console.WriteLine();
            if(tempList.Count > 4)  //만약 카드가 5장 이상이라면 (카드게임을 할 수있는 최소 숫자)
            {
                int temp = pokerConditions(choiceOne);  //플레이어 혹은 컴퓨터의 족보 패가 무엇인지 받기

                if (choiceOne == 0)
                {
                    computerRule = temp;    //컴퓨터 포커 족보 값에 대입
                    Console.Write("현재 컴퓨터는 ");
                }
                else if (choiceOne == 1)
                {
                    playerRule = temp;      //플레이어 포커 족보 값에 대입
                    Console.Write("현재 플레이어는 ");
                }

                //만약 NoPair 라면(족보 값 조건이 하나도 없을때)
                string forNopair = string.Empty;    //가장 강한 카드 값을 보여줄 임시변수
                if (tempList[0].number != 1)    //만약 첫번째(작은수 -> 큰수 정렬이기 때문 A가 무조건 첫번째에 있다)에 A가 없다면
                {
                    //카드 끝(제일 강한카드)를 보여주기
                    forNopair += NumberToString(tempList[tempList.Count - 1].mark, 0);
                    forNopair += " ";
                    forNopair += NumberToString(tempList[tempList.Count - 1].number, 1);
                }
                else        //A가 있다면 가장 강한 카드이기 때문에
                {
                    //카드 첫번째 카드 A 보여주기
                    forNopair += NumberToString(tempList[0].mark, 0);
                    forNopair += " ";
                    forNopair += NumberToString(tempList[0].number, 1);
                }

                // 족보 값을 통해 switch문으로 결과를 알려준다.
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
        }

        public bool inputBetting() //배팅에 대한 값처리 성공여부 예외처리 등을 하는 함수
        {
            Console.WriteLine();    //가독성을 위한 출력문
            while (true)    //배팅 반복문
            {
                Console.WriteLine("현재 소지금은 {0} 원",playerMoney);
                Console.Write("배팅하실 금액을 입력해주세요 (0원은 패스입니다.) : ");

                if (int.TryParse(Console.ReadLine(),out bettingMoney))  //int tryparse를 bettingMoney에 대입(정수값이 아니라면 false를 반환한다)
                {
                    if (bettingMoney == 0)  //배팅금이 0이라면
                    {
                        return false;   //배팅자체를 하지 않는다 (패스)
                    }
                    else if(playerMoney < bettingMoney) //배팅금이 소지금보다 크다면
                    {
                        Console.WriteLine();
                        Console.WriteLine("=======================================================================");
                        Console.WriteLine("[system] 소지금 초과 (현재 소지금보다 이하로 배팅해주세요)");
                        Console.WriteLine("=======================================================================");
                        Console.WriteLine();
                    }
                    else    //정상값이라면
                    {
                        break;  //배팅 반복문 탈출
                    }
                }
                else        //잘못된 값 예외처리
                {
                    Console.WriteLine();
                    Console.WriteLine("=======================================================================");
                    Console.WriteLine("[system] 잘못된 예외 값 (숫자만 입력해주세요)");
                    Console.WriteLine("=======================================================================");
                    Console.WriteLine();
                }
            }

            return true;    //반복문을 탈출하였을 경우는 정상 값밖에 없기 때문에
        }

        public void cardDraw(int DrawCounter, int choiceOne)    //카드 가져오기
        {
            //witchOne 0은 컴퓨터, 1은 플레이어
            string[] Cardtemp = new string[2];  //TrmpCard 클래스에서 카드를 가져올때 문자열 배열로 마크와 숫자를 받기 때문에 그것을 받아올 임시변수
            int parseMark = 0;      //문자로 된 마크를 숫자로 바꿔 적재할 변수 (스페이드 4 , 다이아 3 하트 2 클로버 1 로 받는다)
            int parseNumber = 0;    //문자로 된 숫자를 정수 숫자로 받을 변수
            bool isCardRight = false;   //중복이 아닌지 계속 정상적 유지되었는 지 확인 값

            List<Card> choicetemp = new List<Card>();   //값을 대입, 정렬 위한 임시변수

            if(choiceOne == 0) //컴퓨터라면
            {
                choicetemp = computercard;  //컴퓨터 값 대입(처음 카드 드로우는 괜찮지만 이후의 드로우 과정에서 기존값에 더해져야 카드가 추가된 것이기 때문에)
            }
            else if(choiceOne == 1) //플레이어라면
            {
                choicetemp = playercard;    //플레이어 값 대입
            }

            if (choicetemp.Count == 0)  //임시값에 아무것도 없다면(처음이라면 중복값이 없기 때문에)
            {
                Cardtemp = trumpcard_.ReStringRollCard();   //카드 뽑기 그후 임시변수에 대입

                parseMark = markToNumber(Cardtemp[0]);  //마크값 숫자로 받아오기 markToNumber를 통해 받아오는 문자열 배열엔 [0]엔 마크값, [1]엔 숫자값이 들어있다.
                int.TryParse(Cardtemp[1], out parseNumber); //숫자값 받아오기

                choicetemp.Add(new Card(parseMark, parseNumber));   //임시리스트 변수에 대입
                DrawCounter--;  //드로우 카운터 횟수 1 빼기
            }

            //카드 드로우
            for (int i = 0; i < DrawCounter; i++)   //드로우 횟수만큼의 반복문
            {
                while (true)   //중복 체크를 위한 반복문
                {
                    isCardRight = false;    //중복 확인 초기화
                    Cardtemp = trumpcard_.ReStringRollCard();    //카드 뽑기
                    parseMark = markToNumber(Cardtemp[0]);       //마크 값 대입
                    int.TryParse(Cardtemp[1], out parseNumber);  //숫자 값 대입

                    //컴퓨터 중복확인
                    for (int j = 0; j < computercard.Count; j++)
                    {
                        if (computercard[j].mark == parseMark && computercard[j].number == parseNumber) //뽑은 카드와 같은 것이 있다면
                        {
                            isCardRight = false;    //중복
                            break;  // 컴퓨터 중복 체크 반복문 나가기
                        }
                        else { isCardRight = true; }   //끝까지 아니라면 true유지
                    }

                    if (isCardRight)    //컴퓨터 반복문에서 중복이 안나왔다면
                    {
                        //플레이어 카드 중복확인
                        for (int k = 0; k < playercard.Count; k++)
                        {
                            if (playercard[k].mark == parseMark && playercard[k].number == parseNumber) //뽑은 카드와 같은 것이 있다면
                            {
                                isCardRight = false;    //중복
                                break;  // 플레이어 중복 체크 반복문 나가기
                            }
                            else { isCardRight = true; }   //끝까지 아니라면 true유지
                        }
                    }

                    if (isCardRight == true)    //모든 중복체크가 됬다면
                    {
                        choicetemp.Add(new Card(parseMark, parseNumber));   //카드 값 넣기
                        break;  // 탈출 (밖의 드로우 반복문으로 간다)
                    }
                }
            }
            //카드 정렬
            if (choiceOne == 0)
            {
                computercard = choicetemp.OrderBy(x => x.mark).OrderBy(x => x.number).ToList();   //컴퓨터 패에 정렬해서 다시 적재 
                                                                                                  //orderby는 오름차순 정렬이며 마크(마크숫자)로 정렬 후 숫자값으로 한번 더 정렬한다 이로 인해 가장 큰 가치를 가진 카드가 제일 오른쪽으로 간다
            }
            else if (choiceOne == 1)
            {
                playercard = choicetemp.OrderBy(x => x.mark).OrderBy(x => x.number).ToList(); //플레이어 패에 정렬해서 다시 적재 
                                                                                              //orderby는 오름차순 정렬이며 마크(마크숫자)로 정렬 후 숫자값으로 한번 더 정렬한다 이로 인해 가장 큰 가치를 가진 카드가 제일 오른쪽으로 간다
            }
        }   //카드를 뽑아주는 함수

        public void playerCardChange(int CardNumber)    //플레이어 카드를 바꿔주는 함수
        {
            string[] Cardtemp = new string[2];  //새로 들어올 카드 값(trumpCard 클래스에서) 받을 임시 변수 
            int parseMark = 0;      //문자로 된 마크를 숫자로 바꿔 적재할 변수 (스페이드 4 , 다이아 3 하트 2 클로버 1 로 받는다)
            int parseNumber = 0;    //문자로 된 숫자를 정수 숫자로 받을 변수
            bool isCardRight = false;   //중복이 아닌지 계속 정상적 유지되었는 지 확인 값

            List<Card> sortCard = new List<Card>(); //정렬을 위한 리스트 임시변수

            playercard.RemoveAt(CardNumber);    //현재 선택된 카드 삭제 (RemoveAt는 리스트의 순번을 매개변수로 받아 그 인덱스를 삭제한다)

            while (true)    //중복 체크를 위한 반복문
            {
                isCardRight = false;    //중복 확인 초기화
                Cardtemp = trumpcard_.ReStringRollCard();   //카드 뽑기
                parseMark = markToNumber(Cardtemp[0]);      //마크 값 대입
                int.TryParse(Cardtemp[1], out parseNumber); //숫자 값 대입

                for (int j = 0; j < computercard.Count; j++)    //컴퓨터 카드와 중복되는지 확인을 위한 반복문
                {
                    if (computercard[j].mark == parseMark && computercard[j].number == parseNumber) //뽑은 카드와 같은 것이 있다면
                    {
                        isCardRight = false;    //중복
                        break;  // 컴퓨터 중복 체크 반복문 나가기
                    }
                    else { isCardRight = true; }    //끝까지 아니라면 true
                }

                if (isCardRight)    //컴퓨터 반복문에서 중복이 안나왔다면
                {
                    for (int k = 0; k < playercard.Count; k++)  //플레이어 카드와 중복확인
                    {
                        if (playercard[k].mark == parseMark && playercard[k].number == parseNumber) //뽑은 카드와 같은 것이 있다면
                        {
                            isCardRight = false;    //중복
                            break;  //플레이어 중복 체크 반복문 나가기
                        }
                        else { isCardRight = true; }    //끝까지 아니라면 true
                    }
                }

                if (isCardRight == true)    //모든 중복체크가 됬다면
                {
                    playercard.Add(new Card(parseMark, parseNumber));   //카드 값 넣기
                    break;
                }
            }

            sortCard = playercard;  //플레이어 카드 패 임시변수에 받기
            playercard = sortCard.OrderBy(x => x.mark).OrderBy(x => x.number).ToList();  //이를 정렬해서 다시 적재 
            //orderby는 오름차순 정렬이며 마크(마크숫자)로 정렬 후 숫자값으로 한번 더 정렬한다 이로 인해 가장 큰 가치를 가진 카드가 제일 오른쪽으로 간다
        }

        public void playerCardChangeControl(int maxChangeCounter)   //플레이어의 카드패 교환 함수(매개변수 : 바꾸는 횟수)
        {
            Console.WriteLine();    //가독성
            Console.WriteLine();

            int choiceNumber = 0;   //선택된 카드 넘버 임시변수
            int insideCounter = 0;  //카드패를 몇번 바꿨는지 카운팅을 위한 변수

            bool isdraw = true; //새롭게 그리기 갱신 여부 값
            bool isfinish = false;  //카드 패 교환 반복문 여부 값

            ConsoleKeyInfo keys;    //입력키 임시변수

            while (!isfinish)   //카드패 교환 UI 및 실행을 위한 반복문 
            {
                if (maxChangeCounter <= insideCounter) break;   //탈출 조건문 (바꾸는 횟수가 매개변수로 준 횟수랑 이상이라면)

                if (isdraw) //만약 그리기위한 값이 true 라면 갱신하기
                {
                    Console.SetCursorPosition(0, 18);
                    for (int i = 0; i < playercard.Count; i++)
                    {
                        if (i == choiceNumber)  //리스트 순번에 맞게 위치한다.
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

                //키 입력 조건문
                if (Console.KeyAvailable)   //아무 키를 누를 경우 true 를 반환한다.
                {
                    keys = Console.ReadKey();   //위에 키를 누른 값이 키 임시변수에 대입
                    if(keys.KeyChar == 'a' || keys.KeyChar == 'A')  //만약 A 라면 (혹시 모를 소문자도 or을 통해 확인)
                    {
                        if (choiceNumber > 0)   //0보다 크다면 (리스트 순번은 0 보다 낮은 수는 없기 때문에 막기)
                        {
                            choiceNumber--; //좌로 (이전 리스트 순번으로)
                        }
                        isdraw = true;  //그려주기 갱신
                    }
                    else if (keys.KeyChar == 'd' || keys.KeyChar == 'D')    //만약 D라면
                    {
                        if (choiceNumber < playercard.Count - 1)    //최대값보다 작다면(0부터 시작이기 때문에 count보다 1작은 수가 마지막 순번값이다.)
                        {
                            choiceNumber++; //우로 (이후 리스트 순번으로)
                        }
                        isdraw = true;  //그려주기 갱신
                    }
                    else if (keys.KeyChar == 'q' || keys.KeyChar == 'Q')    //만약 Q라면 (바꾸기 선택)
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
                    else if (keys.KeyChar == 'p' || keys.KeyChar == 'P')    //만약 P라면 (바꾸기 패스)
                    {
                        insideCounter++;    //횟수 카운팅 올리기
                        isdraw = true;  //그리기 갱신
                    }
                }
            }
            Console.SetCursorPosition(0, 21);   //그리기 위치 갱신
            Console.WriteLine("현재 기회는 {0} , 현재 배팅 금액 {1} 원", (maxChangeCounter - insideCounter), bettingMoney); //마지막 현재 기회는 0을 찍기 위한 출력문
        }

        public int playerWinning()   //족보 값을 통해 세밀한 승부 결과 반환
        {
            // 2 플레이어 승 1 컴퓨터 승 0 드로우
            int result = 0; //최종결과 반환 임시변수
            Card PlayerFirstTemp = playercard[0];   //플레이어 카드패 첫번째(A값 확인용)
            Card PlayerLastTemp = playercard[playercard.Count - 1];     //플레이어 카드패 마지막(작은수 -> 큰수 정렬이기 때문에)
            Card ComFirstTemp = computercard[0];    //컴퓨터 카드패 첫번째(A값 확인용)
            Card ComLastTemp = computercard[computercard.Count - 1];    //컴퓨터 카드패 마지막(작은수 -> 큰수 정렬이기 때문에)

            Card ResultComFirst = computerResultcard[0];    //컴퓨터 족보 패 리스트 첫번째(A값 확인용)
            Card ResultComLast = computerResultcard[computerResultcard.Count - 1];  //컴퓨터 족보 패 리스트 마지막(작은수 -> 큰수 정렬이기 때문에)
            Card ResultPlayerFirst = playerResultcard[0];    //플레이어 족보 패 리스트 첫번째(A값 확인용)
            Card ResultPlayerLast = playerResultcard[playerResultcard.Count - 1];   //플레이어 족보 패 리스트 마지막(작은수 -> 큰수 정렬이기 때문에)

            //서로 노페어 이거나 같은 조건에 같은 값일 경우에만 마크비교를 하며
            //서로 다를 땐 승부가 나기 때문에 마크비교는 하지 않는다

            if (playerRule > computerRule)  //플레이어 포커 족보 값이 컴퓨터 포커 족보 값보다 높다면
            {
                result = 2; //플레이어 승
            }
            else if (playerRule < computerRule)  //컴퓨터 포커 족보 값이 플레이어 포커 족보 값보다 높다면
            {
                result = 1; //컴퓨터 승
            }
            //서로 노페어 일때
            else if (playerRule == 0 && computerRule == 0)
            {
                //둘다 A가 있을때 (A는 내부값에선 1이다)
                if (PlayerFirstTemp.number == 1 && ComFirstTemp.number == 1)    //서로 첫번째 카드가 A가 있다면 (가장 강한 숫자카드가 같다)
                {
                    if (PlayerFirstTemp.mark > ComFirstTemp.mark) result = 2;   //마크비교 플레이어가 크다면 플레이어 승
                    else if (PlayerFirstTemp.mark < ComFirstTemp.mark) result = 1;  //마크비교 컴퓨터가 크다면 컴퓨터 승
                    else result = 0;    //모두 아니라면 무승부
                }
                else if (PlayerFirstTemp.number == 1 && ComFirstTemp.number != 1)   //플레이어만 A가 있을 때
                {
                    result = 2; //플레이어 승
                }
                else if (PlayerFirstTemp.number != 1 && ComFirstTemp.number == 1)   //컴퓨터만 A가 있을 때
                {
                    result = 1; //컴퓨터 승
                }
                else  //둘다 노페어에 A카드도 없다면 숫자비교문 (내부 값에선 J,K,Q 모두 11,12,13으로 되어있다)
                {
                    //컴퓨터의 마지막 카드 와 플레이어의 마지막 카드 번호가 같을 때
                    if (ComLastTemp.number == PlayerLastTemp.number)
                    {
                        if (ComLastTemp.mark < PlayerLastTemp.mark) result = 2; //마크비교 플레이어가 크면 플레이어 승
                        else if (ComLastTemp.mark > PlayerLastTemp.mark) result = 1; //마크비교 컴퓨터가 크면 컴퓨터 승
                        else result = 0;    //모두 아니라면 무승부
                    }
                    else if (ComLastTemp.number < PlayerLastTemp.number)    //플레이어가 숫자가 크면
                    {
                        result = 2; //플레이어 승
                    }
                    else if (ComLastTemp.number > PlayerLastTemp.number)    //컴퓨터 숫자가 크면
                    {
                        result = 1; //컴퓨터 승
                    }
                    else result = 0;    //모두 아니라면 무승부
                }
            }
            else if (playerRule == computerRule) //만약 포커 족보 값이 서로 같을 때 서로 마크 값 비교
            {
                //A가 있을때
                if (ResultPlayerFirst.number == 1 && ResultComFirst.number == 1)    //둘다 A를 가지고 있을 경우
                {
                    if (ResultPlayerFirst.mark > ResultComFirst.mark) result = 2;
                    else if (ResultPlayerFirst.mark < ResultComFirst.mark) result = 1;
                    else result = 0;
                }
                else if (ResultPlayerFirst.number == 1 && ResultComFirst.number != 1)   //플레이어만 A를 갖고 있다면
                {
                    result = 2; //플레이어 승
                }
                else if (ResultPlayerFirst.number != 1 && ResultComFirst.number == 1)   //컴퓨터만 A를 갖고 있다면
                {
                    result = 1; //컴퓨터 승
                }
                else    //둘 다 A가 없고 숫자비교를 해야하면
                {
                    //컴퓨터의 마지막 카드 와 플레이어의 마지막 카드 번호가 같을 때
                    if (ResultComLast.number == ResultPlayerLast.number)
                    {
                        if (ResultComLast.mark < ResultPlayerLast.mark) result = 2; //마크 비교 플레이어가 크면 플레이어 승
                        else if (ResultComLast.mark > ResultPlayerLast.mark) result = 1; //마크 비교 컴퓨터가 크면 컴퓨터 승
                        else result = 0;    //모두 아니라면 무승부
                    }
                    else if (ResultComLast.number < ResultPlayerLast.number)    //플레이어 숫자가 더 크면
                    {
                        result = 2; //플레이어 승
                    }
                    else if (ResultComLast.number > ResultPlayerLast.number)    //컴퓨터 숫자가 더 크면
                    {
                        result = 1; //컴퓨터 승
                    }
                    else result = 0;    //모두 아니라면 무승부
                }
            }
            return result;  //최종결과 반환
        }

        public void Cleanning()     //플레이어, 컴퓨터에 대한 초기화 함수
        {
            //사용되는 리스트들이 만약 있다면 모두 클리어
            if (computercard.Count > 0) computercard.Clear();
            if (computerResultcard.Count > 0) computerResultcard.Clear();
            if (playercard.Count > 0) playercard.Clear();
            if (playerResultcard.Count > 0) playerResultcard.Clear();
            computerRule = 0;   //컴퓨터 포커 족보 값을 초기화 
            playerRule = 0;     //플레이어 포커 족보 값을 초기화
            Console.Clear();    //콘솔 화면 클리어
        }
        
        public void TIMER_Message(int time, string text,int x,int y)    //초 단위 텍스트 타이머
        {
            while (true)
            {
                if (time <= 0) break;   //타이머가 다되면 탈출
                Console.MoveBufferArea(0, 200, 50, 1, x, y);
                Console.SetCursorPosition(x, y);  //콘솔 그릴 위치 (15열, 23행)
                Console.WriteLine("{0} 초 뒤에 {1}", time, text);
                Thread.Sleep(1000);
                time--;
            }
        }
    }
}