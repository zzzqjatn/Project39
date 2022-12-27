using System;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace WhatisFunction
{
    internal class sliding_puzzle
    {
        //맵 크기 (x, y) 값에 대한 상수 (맵 크기 변경 가능)
        const int MAP_SIZE_X = 3;
        const int MAP_SIZE_Y = 3;

        static void Main()
        {
            //플레이어 x 값, y 값 세팅 (맵 끝에 세팅)
            int playerX = MAP_SIZE_X - 1,playerY = MAP_SIZE_Y - 1;
            int moveCounter = 0;    //움직임 수에 따른 카운터

            bool drawRecycle = true;    //맵그리기 갱신 bool 값 true(갱신), false(유지)
            bool isGameOver = false;    //게임 종료를 위한 bool 값 false(진행중) true(끝) 

            //맵 값 세팅
            int[,] Map = new int[MAP_SIZE_X, MAP_SIZE_Y];   //가변배열에 맵크기에 따라 배열 세팅

            for(int y = 0; y < MAP_SIZE_Y; y++)     //배열의 y 행 반복문
            {
                for(int x = 0; x < MAP_SIZE_X; x++) //배열의 x 행 반복문
                {
                    // 배열은 0부터 시작이기 때문에 size에서 -1 값을 해주었다
                    if (y == (MAP_SIZE_Y - 1) && x == (MAP_SIZE_X - 1))  //배열의 마지막 순번(초기 플레이어 자리)라면
                    {
                        Map[y, x] = -1;     //플레이어 값 (-1 : 음수는 없기 때문에)
                    }
                    else
                    {
                        Map[y, x] = y * MAP_SIZE_Y + x + 1; //나머지는 순번대로 값 넣기
                    }
                }
            }
            drawMap(Map, moveCounter, ref drawRecycle);     //맵 그리는 함수
            mixMap(3, ref Map, ref playerX, ref playerY, ref drawRecycle);  //자리를 섞어주는 함수

            //게임 진행 loop
            while (!isGameOver)
            {
                drawMap(Map, moveCounter, ref drawRecycle); //맵 그리는 함수
                moveControl(Console.ReadKey(), ref Map, ref playerX, ref playerY, ref drawRecycle, ref moveCounter);    //움직이는 함수
                finish(ref isGameOver, Map);    //게임 종료 확인 함수
            }
            drawMap(Map, moveCounter, ref drawRecycle); //다 종료후 다시 맵그리기
            Console.WriteLine("게임 클리어!");// 게임 종료문
        }

        //자리를 섞어주는 함수(몇번 섞고 싶은 값 복사, 맵 값 참조, 플레이어x 참조, 플레이어y 참조, 맵그리기 bool 값 참조)
        static void mixMap(int mixCounter,ref int[,] map_, ref int playerx, ref int playery, ref bool isdraw)
        {
            Random rand = new Random(); //랜덤 클래스 생성

            int dir;   //섞어질 방향 정하기 값(1~4)
            int bLock_dir = 0;  //이전에 섞인 방향 막는 값(1~4) 초기는 0으로 통과시켜준다.
            int temp;   //스왑을 위한 임시값
            bool isright = false;   //정상적으로 섞인 경우 while문을 나와줄 값

            //mixCounter값만큼 돌려줄 반복문
            for(int i = 0; i < mixCounter; i++)
            {
                isright = false;    //while문 반복값 초기화
                while (!isright)    //제대로 섞일 때까지 반복되는 반복문
                {
                    while (true)
                    {
                        dir = rand.Next(1, 4 + 1); // 1:위 2:아래 3:왼 4:오른 랜덤값 적용

                        if (bLock_dir != dir) break; //만약 막는 값이 지금 방향값과 다르다면 탈출
                    }

                    switch (dir)   //dir_part 방향에 따른 switch문
                    {
                        //위
                        case 1:
                            playery -= 1;   //플레이어 값, 위쪽으로 값 변경

                            if (playery >= 0)   //만약 맵 끝이 아니라면
                            {
                                temp = map_[playery + 1, playerx]; //기존의 플레이어가 위치했던 값을 찾아 임시값에 넣는다.
                                map_[playery + 1, playerx] = map_[playery, playerx]; //기존 플레이어 위치에 현재 옮긴 위치값을 넣는다.
                                map_[playery, playerx] = temp;  //임시값에 저장했던 값을 현재 위치에 옮긴다.
                                isright = true; //정상적인 값 적용확인 반복문 탈출 (제대로 섞일 때까지 반복되는 반복문 탈출)
                                bLock_dir = 2;  //현재 방향의 반대 방향을 막기 (위로 갔다 다시 아래로 가면 그대로 이기 때문에)
                            }
                            else
                            {
                                playery += 1;   //만약 맵 끝이라면 다시 값을 더해 재위치
                            }
                            break;
                        //아래
                        case 2:
                            playery += 1;   //플레이어 값, 아래쪽으로 값 변경

                            if ((MAP_SIZE_Y-1) >= playery)   //만약 맵 끝이 아니라면
                            {
                                temp = map_[playery - 1, playerx]; //기존의 플레이어가 위치했던 값을 찾아 임시값에 넣는다.
                                map_[playery - 1, playerx] = map_[playery, playerx]; //기존 플레이어 위치에 현재 옮긴 위치값을 넣는다.
                                map_[playery, playerx] = temp; //임시값에 저장했던 값을 현재 위치에 옮긴다.
                                isright = true; //정상적인 값 적용확인 반복문 탈출
                                bLock_dir = 1;  //현재 방향의 반대 방향을 막기
                            }
                            else
                            {
                                playery -= 1;  //만약 맵 끝이라면 다시 재위치
                            }
                            break;
                        //왼
                        case 3:
                            playerx -= 1;   //플레이어 값, 왼쪽으로 값 변경

                            if (playerx >= 0)   //만약 맵 끝이 아니라면
                            {
                                temp = map_[playery, playerx + 1]; //기존의 플레이어가 위치했던 값을 찾아 임시값에 넣는다.
                                map_[playery, playerx + 1] = map_[playery, playerx]; //기존 플레이어 위치에 현재 옮긴 위치값을 넣는다.
                                map_[playery, playerx] = temp; //임시값에 저장했던 값을 현재 위치에 옮긴다.
                                isright = true; //정상적인 값 적용확인 반복문 탈출
                                bLock_dir = 4;  //현재 방향의 반대 방향을 막기
                            }
                            else
                            {
                                playerx += 1;  //만약 맵 끝이라면 다시 재위치
                            }
                            break;
                        //오
                        case 4:
                            playerx += 1;   //플레이어 값, 오른쪽으로 값 변경

                            if ((MAP_SIZE_X-1) >= playerx)   //만약 맵 끝이 아니라면
                            {
                                temp = map_[playery, playerx - 1]; //기존의 플레이어가 위치했던 값을 찾아 임시값에 넣는다.
                                map_[playery, playerx - 1] = map_[playery, playerx]; //기존 플레이어 위치에 현재 옮긴 위치값을 넣는다.
                                map_[playery, playerx] = temp; //임시값에 저장했던 값을 현재 위치에 옮긴다.
                                isright = true; //정상적인 값 적용확인 반복문 탈출
                                bLock_dir = 3;  //현재 방향의 반대 방향을 막기
                            }
                            else
                            {
                                playerx -= 1;  //만약 맵 끝이라면 다시 재위치
                            }
                            break;
                    }
                }
            }
            isdraw = true;  //다 끝나면 맵그리기 갱신 값 주기
        }

        //움직이는 함수(입력한 키값 복사, 맵 값 참조, 플레이어x 참조, 플레이어y 참조, 맵그리기 bool 값 참조, 움직인 횟수값 참조)
        static void moveControl(ConsoleKeyInfo KEY_, ref int[,] map_, ref int playerx, ref int playery, ref bool isdraw,ref int movecount_)
        {
            int temp = 0;   //스왑을 위한 임시값

            if(ConsoleKey.W == KEY_.Key)    //키 W 값을 눌렀을때
            {
                playery -= 1;   //플레이어 값, 위쪽으로 값 변경

                if (playery >= 0)  //만약 맵 끝이 아니라면
                {
                    temp = map_[playery + 1, playerx];  //기존의 플레이어가 위치했던 값을 찾아 임시값에 넣는다.
                    map_[playery + 1, playerx] = map_[playery, playerx];  //기존 플레이어 위치에 현재 옮긴 위치값을 넣는다.
                    map_[playery, playerx] = temp;  //임시값에 저장했던 값을 현재 위치에 옮긴다.
                    movecount_++;   //움직임 카운터++;
                }
                else
                {
                    playery += 1;   //만약 맵 끝이라면 다시 재위치
                }
            }

            if (ConsoleKey.S == KEY_.Key)    //키 S 값을 눌렀을때
            {
                playery += 1;   //플레이어 값, 아래쪽으로 값 변경

                if ((MAP_SIZE_Y - 1) >= playery)  //만약 맵 끝이 아니라면
                {
                    temp = map_[playery - 1, playerx];  //기존의 플레이어가 위치했던 값을 찾아 임시값에 넣는다.
                    map_[playery - 1, playerx] = map_[playery, playerx];  //기존 플레이어 위치에 현재 옮긴 위치값을 넣는다.
                    map_[playery, playerx] = temp;  //임시값에 저장했던 값을 현재 위치에 옮긴다.
                    movecount_++;   //움직임 카운터++;
                }
                else
                {
                    playery -= 1;   //만약 맵 끝이라면 다시 재위치
                }
            }

            if (ConsoleKey.A == KEY_.Key)    //키 A 값을 눌렀을때
            {
                playerx -= 1;   //플레이어 값, 왼쪽으로 값 변경

                if (playerx >= 0)  //만약 맵 끝이 아니라면
                {
                    temp = map_[playery, playerx + 1]; //기존의 플레이어가 위치했던 값을 찾아 임시값에 넣는다.
                    map_[playery, playerx + 1] = map_[playery, playerx]; //기존 플레이어 위치에 현재 옮긴 위치값을 넣는다.
                    map_[playery, playerx] = temp; //임시값에 저장했던 값을 현재 위치에 옮긴다.
                    movecount_++; //움직임 카운터++;
                }
                else
                {
                    playerx += 1;   //만약 맵 끝이라면 다시 재위치
                }
            }

            if (ConsoleKey.D == KEY_.Key)   //키 D 값을 눌렀을때
            {
                playerx += 1;  //플레이어 값, 오른쪽으로 값 변경

                if ((MAP_SIZE_X - 1) >= playerx)  //만약 맵 끝이 아니라면
                {
                    temp = map_[playery, playerx - 1]; //기존의 플레이어가 위치했던 값을 찾아 임시값에 넣는다.
                    map_[playery, playerx - 1] = map_[playery, playerx]; //기존 플레이어 위치에 현재 옮긴 위치값을 넣는다.
                    map_[playery, playerx] = temp;  //임시값에 저장했던 값을 현재 위치에 옮긴다.
                    movecount_++;   //움직임 카운터++;
                }
                else
                {
                    playerx -= 1;   //만약 맵 끝이라면 다시 재위치
                }
            }
            isdraw = true; //다 끝나면 맵그리기 갱신 값 주기
        }

        static void drawMap(int[,] MAP_,int moveCounter_,ref bool isdraw)
        {
            if (isdraw) //맵그리기 갱신 값 있다면
            {
                //상단 출력문
                Console.Clear();
                Console.WriteLine("\t=============================================");
                Console.WriteLine("\t                슬라이딩 퍼즐                 ");
                Console.WriteLine("\t=============================================");
                Console.WriteLine();
                Console.WriteLine();

                for (int y = 0; y <= MAP_.GetUpperBound(0); y++)
                {
                    Console.Write("\t\t");
                    for (int x = 0; x <= MAP_.GetUpperBound(1); x++)
                    {
                        switch (MAP_[y, x]) //맵값에 따른 스위치문
                        {
                            case -1:    //-1 값은 플레이어
                                Console.Write("  X  ".PadRight(5, ' '), MAP_[y, x]);
                                break;
                            default:
                                Console.Write("  {0}  ".PadRight(5, ' '), MAP_[y, x]);
                                break;
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
                Console.WriteLine("\t=============================================");
                Console.WriteLine("\t                움직인 횟수 : {0}", moveCounter_);
                Console.WriteLine("\t=============================================");
                isdraw = false;
            }
        }

        static void finish(ref bool isGameOver, int[,] MAP_)
        {
            for(int y = 0; y <= MAP_.GetUpperBound(0); y++)
            {
                for(int x = 0; x <= MAP_.GetUpperBound(1); x++)
                {
                    if (y == MAP_SIZE_Y - 1 && x == MAP_SIZE_X - 1)
                    {
                        if (MAP_[y,x] == -1) isGameOver = true;
                    }
                    else if (MAP_[y, x] != y * MAP_SIZE_Y + x + 1)
                    {
                        isGameOver = false;
                        break;
                    }
                }
            }
        }
    }
}
