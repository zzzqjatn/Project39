using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace WhatisFunction
{
    internal class homework
    {

        private const int MAP_SIZE_X = 10;   //맵사이즈x값
        private const int MAP_SIZE_Y = 10;   //맵사이즈y값
        private static int mapCoinCounter = 0;    //현재 맵에 있는 코인 카운터
        private static int moveCount = 0;       //움직인 횟수
        static void Main(string[] args)
        {
            /*
             * MAP 표시
             * 0 : ■    벽
             * 1 : .    빈 땅
             * 2 : 플레이어
             * 3 : 코인
             */
            int[,] map = new int[MAP_SIZE_X, MAP_SIZE_Y]; //전체 맵 크기

            int playerX = 5;    //플레이어 X 좌표
            int playerY = 5;    //플레이어 y 좌표
            int PlayerCoin = 0; //플레이어 코인

            bool isDrow = false;    //그리기 여부 값

            map[playerX, playerY] = 2;  //플레이어 위치 세팅

            map = WALL_SET(map);  //벽 세팅 함수(값 참조 이중 배열[,])

            //초기 1회 코인 생성 실행 { 아래의 게임 Loop 내에선 Iscompleted 조건에서 null 오류가 뜨기 때문에 }
            Task loopTask = Task.Run(async () =>
            {
                await Task.Delay(3000); //딜레이를 3초 걸어놓고 아래의 코드가 실행된다
                mapCoinCounter++;       //맵코인 카운터갯수 추가
                map = COIN_SET(map);    //랜덤 코인 생성함수
                isDrow = false;         //그리기 갱신을 위한 false
            });

            while (true)    //게임 Loop
            {
                if (PlayerCoin >= 10) break; //게임종료 조건(코인 10개 이상 먹으면)

                if (mapCoinCounter < 5 && loopTask.IsCompleted)   //loopTask 현재 진행중인 비동기식작업이 모두 완료되고 코인카운터가 5보다 작으면
                {
                    loopTask = Task.Run(async () => //비동기 코인 생성 코드 실행
                    {
                        await Task.Delay(3000);     //딜레이 3초 (아래의 코드는 3초 뒤 시작된다)
                        mapCoinCounter++;       //맵코인 카운터갯수 추가   
                        map = COIN_SET(map);    //랜덤 코인 생성함수
                        isDrow = false;         //그리기 갱신을 위한 false
                    });
                }

                if (isDrow == false)    //그리기 값이 false일때 (움직이거나 처음 시작 시, 비동기 코인랜덤생성시)
                {
                    DROW_MAP(map, PlayerCoin);      //맵 그리기 함수
                    isDrow = true;      //그린 후 true 변경
                }
                else
                {
                    if (Console.KeyAvailable)   //키값이 눌리면(true , 아니면 false)
                    {
                        //[반환 현재 먹은 코인 수] 플레이어 이동함수 (key값 받기 , 플레이어 x 좌표 참조, 플레이어 y좌표 참조, map 이중배열 참조, 그리기 bool 값 참조)
                        PlayerCoin = MOVE(Console.ReadKey().Key, ref playerX, ref playerY, ref map, PlayerCoin);
                        isDrow = false; //그리기 갱신을 위한 false
                    }
                }
            }
            Console.WriteLine("플레이어가 10개 이상의 코인을 먹어 종료되었습니다");  // 게임 종료 출력문
        }
        //--------task 예문---------------//
        //Task.Delay(300).Wait(); //300은 0.3초
        //
        //Task loopTask = default;
        //loopTask = Task.Run(async () =>
        //{
        //    await Task.Delay(300);
        //});
        //loopTask.Wait();

        //[반환 현재 먹은 코인 수] 플레이어 이동함수 (key값 받기 , 플레이어 x 좌표 참조, 플레이어 y좌표 참조, map 이중배열 참조, 그리기 bool 값 참조)
        static int MOVE(ConsoleKey INPUTKEY,ref int PLAYERX,ref int PLAYERY,ref int[,] INPUTMAP,int PlayerCoin_)
        {
            //플레이어가 있던 원래 위치 초기화
            INPUTMAP[PLAYERY, PLAYERX] = 0;

            //코인 랜덤추가
            if (INPUTKEY == ConsoleKey.C)   // C 키를 누르면
            {
                if (mapCoinCounter < 5) //맵에 코인이 5개 이하라면
                {
                    INPUTMAP = COIN_SET(INPUTMAP);  //랜덤코인 생성함수
                    mapCoinCounter++;   //맵에 있는 코인 카운터 추가
                }
            }   //코인 랜덤추가

            //위
            if (INPUTKEY == ConsoleKey.W)   // W 키를 누르면
            {
                PLAYERY -= 1;   // y값 -1 (빼면 좌표상 위로 올라가기 때문에)
                moveCount++;    // 움직임 카운터 증가

                //코인일 경우 먹기
                if (INPUTMAP[PLAYERY, PLAYERX] == 3)    //위치가 코인이면
                {
                    INPUTMAP[PLAYERY, PLAYERX] = 2; //현재 위치를 2 (플레이어)로 변경
                    PlayerCoin_++;  //플레이어 코인값 증가
                    mapCoinCounter--;   //맵코인 카운터 감소
                }

                if (PLAYERY < INPUTMAP.GetLowerBound(0) ||   //만약 공간의 끝이거나 (플레이어 Y좌표 < 이중배열 첫번째의 제일 낮은 인덱스 값)
                    INPUTMAP[PLAYERY, PLAYERX] == 1)    // 혹은 1(벽)값이 있거나
                {
                    PLAYERY += 1;   //위에서 뺐던 값을 다시 더하여 되돌아간다.
                    moveCount--;    //움직인게 아니였던 거니 움직임 카운터 다시 감소
                }
            }   //위

            //아래
            if (INPUTKEY == ConsoleKey.S)   // S 키를 누르면
            {
                PLAYERY += 1;   //y값 +1 (더하면 좌표상 아래로 가기 때문에)
                moveCount++;    // 움직임 카운터 증가

                //코인일 경우 먹기
                if (INPUTMAP[PLAYERY, PLAYERX] == 3)    //위치가 코인이면
                {
                    INPUTMAP[PLAYERY, PLAYERX] = 2; //현재 위치를 2 (플레이어)로 변경
                    PlayerCoin_++;  //플레이어 코인값 증가
                    mapCoinCounter--;   //맵코인 카운터 감소
                }

                if (PLAYERY > INPUTMAP.GetUpperBound(0) || //만약 공간의 끝이거나 (플레이어 Y좌표 > 이중배열 첫번째의 제일 높은 인덱스 값)
                    INPUTMAP[PLAYERY, PLAYERX] == 1)    // 혹은 1(벽)값이 있거나
                {
                    PLAYERY -= 1;   //위에서 더했던 값을 다시 빼서 되돌아간다.
                    moveCount--;    // 움직임 카운터 감소
                }
            }   //아래

            //왼
            if (INPUTKEY == ConsoleKey.A)   // A 키를 누르면
            {
                PLAYERX -= 1;   //x값 -1 (빼면 좌표상 왼쪽으로 가기 때문에)
                moveCount++;    // 움직임 카운터 증가

                //코인일 경우 먹기
                if (INPUTMAP[PLAYERY, PLAYERX] == 3)    //위치가 코인이면
                {
                    INPUTMAP[PLAYERY, PLAYERX] = 2; //현재 위치를 2 (플레이어)로 변경
                    PlayerCoin_++;  //플레이어 코인값 증가
                    mapCoinCounter--;   //맵코인 카운터 감소
                }

                if (PLAYERX < INPUTMAP.GetLowerBound(1) || //만약 공간의 끝이거나 (플레이어 x좌표 < 이중배열 두번째의 제일 낮은 인덱스 값)
                    INPUTMAP[PLAYERY, PLAYERX] == 1)    // 혹은 1(벽)값이 있거나
                {
                    PLAYERX += 1;   //위에서 뺐던 값을 다시 더하여 되돌아간다.
                    moveCount--;    // 움직임 카운터 감소
                }
            }   //왼

            //오른
            if (INPUTKEY == ConsoleKey.D)   // D 키를 누르면
            {
                PLAYERX += 1;   //x값 +1 (더하면 좌표상 오른쪽으로 가기 때문에)
                moveCount++;    // 움직임 카운터 증가

                //코인일 경우 먹기
                if (INPUTMAP[PLAYERY, PLAYERX] == 3)    //위치가 코인이면
                {
                    INPUTMAP[PLAYERY, PLAYERX] = 2; //현재 위치를 2 (플레이어)로 변경
                    PlayerCoin_++;  //플레이어 코인값 증가
                    mapCoinCounter--;   //맵코인 카운터 감소
                }

                if (PLAYERX > INPUTMAP.GetUpperBound(1) ||  //만약 공간의 끝이거나 (플레이어 x좌표 > 이중배열 첫번째의 제일 높은 인덱스 값)
                    INPUTMAP[PLAYERY, PLAYERX] == 1)    // 혹은 1(벽)값이 있거나
                {
                    PLAYERX -= 1;   //위에서 더했던 값을 다시 빼서 되돌아간다.
                    moveCount--;    // 움직임 카운터 감소
                }
            }   //오른

            INPUTMAP[PLAYERY, PLAYERX] = 2; //위에서 변경한 플레이어 X,Y 좌표에 값 수정 (2 : 플레이어)

            return PlayerCoin_; //계산된 플레이어 코인 반환
        }   //MOVE()

        static int[,] WALL_SET(int[,] MAP_)        //맵에 겉에만 벽 세팅하는 함수
        {
            for (int y = 0; y <= MAP_.GetUpperBound(0); y++)    //y축 루프문 (첫번째 배열)
            {
                for (int x = 0; x <= MAP_.GetUpperBound(1); x++)    //x축 루프문 (두번째 배열)
                {
                    if(0 < y && y < MAP_.GetUpperBound(0))  //첫번째(0) 보다 크고 최대 값보다 작은 범위 설정
                    {
                        if (0 < x && x < MAP_.GetUpperBound(1)) //첫번째(0) 보다 크고 최대 값보다 작은 범위 설정
                        {
                            continue; //가운데 비어 있는 공간이니 패스하기
                        }
                    }
                    MAP_[y, x] = 1; //나머지 벽설치
                }
            }
            return MAP_;    //벽 설치된 맵 반환 
        }   //WALL_SET()

        static int[,] COIN_SET( int[,] MAP_)        //맵에 코인 세팅하는 함수
        {
            Random random = new Random();   //랜덤 클래스 생성

            while(true)
            {
                int coinX = random.Next(0, MAP_SIZE_X);     //코인의 랜덤 X값
                int coinY = random.Next(0, MAP_SIZE_Y);     //코인의 랜덤 y값

                if(MAP_[coinY, coinX] == 0) //빈 곳이면
                {
                    MAP_[coinY, coinX] = 3; //코인으로 변경
                    break;
                }
            }
            return MAP_;    //변형된 맵 반환
        }       //COIN_SET()

        //맵 그리는 함수
        static void DROW_MAP(int[,] MAP_,int playerCoin)
        {
            Console.Clear();    //화면 클리어
            Console.WriteLine("현재 플레이어 코인 : {0}", playerCoin);  //현재 플레이어가 먹은 코인

            for(int y = 0; y <= MAP_.GetUpperBound(0); y++)     //y축 루프문 (첫번째 배열)
            {
                for(int x = 0; x <= MAP_.GetUpperBound(1); x++) //x축 루프문 (두번째 배열)
                {
                    switch(MAP_[y,x])                           //배열 값에 따른 다른 그리기문
                    {
                        case 3:
                            Console.Write("$".PadRight(4, ' '));        //3값은 코인
                            break;
                        case 2:
                            Console.Write("옷".PadRight(3, ' '));        //2값은 플레이어
                            break;
                        case 1:
                            Console.Write("■".PadRight(3, ' '));        //1값은 벽
                            break;
                        case 0:
                            Console.Write(".".PadRight(4, ' '));        //0값은 빈 공간
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("움직임 횟수 : {0}",moveCount);
            //현재 플레이어의 위치값 확인 출력문
            for (int y = 0; y <= MAP_.GetUpperBound(0); y++) //y축 루프문 (첫번째 배열)
            {
                for (int x = 0; x <= MAP_.GetUpperBound(1); x++) //x축 루프문 (두번째 배열)
                {
                    if (MAP_[y, x] == 2) Console.WriteLine("{0}, {1}", x, y);   //배열에 2(플레이어)값을 찾고 좌표 출력
                }
            }
            Console.WriteLine();
        }
    }
}
