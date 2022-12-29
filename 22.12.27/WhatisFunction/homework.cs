using System;
using System.Security.Cryptography.X509Certificates;

namespace WhatisFunction
{
    internal class homework
    {
        static void Main(string[] args)
        {
            const int MAP_SIZE_X = 5;   //맵사이즈x값
            const int MAP_SIZE_Y = 5;   //맵사이즈y값
            /*
             * MAP 표시
             * 1 : ㅁ    벽
             * 2 : .    빈 땅
             * 3 : 플레이어
             */
            int[,] map = new int[MAP_SIZE_X, MAP_SIZE_Y]; //전체 맵 크기

            int playerX = 2;    //플레이어 X 좌표
            int playerY = 2;    //플레이어 y 좌표

            bool isDrow = false;    //그리기 여부 값

            map[playerX, playerY] = 2;  //플레이어 세팅

            WALL_SET(ref map);  //벽 세팅 함수(값 참조 이중 배열[,])

            while (true)    //게임 Loop 시작
            {
                if (isDrow == false)    //그리기 값이 false일때 (움직이거나 처음 시작 시)
                {
                    Console.Clear();    //화면 클리어
                    DROW_MAP(map);      //맵 그리기 함수
                    isDrow = true;      //그린 후 true 변경
                }
                else
                {
                    //플레이어 이동함수 (key값 받기 , 플레이어 x 좌표 참조, 플레이어 y좌표 참조, map 이중배열 참조, 그리기 bool 값 참조)
                    MOVE(Console.ReadKey().Key, ref playerX, ref playerY, ref map, ref isDrow);
                }

            }
        }

        //플레이어 이동함수 (key값 받기 , 플레이어 x 좌표 참조, 플레이어 y좌표 참조, map 이중배열 참조, 그리기 bool 값 참조)
        static void MOVE(ConsoleKey INPUTKEY,ref int PLAYERX,ref int PLAYERY,ref int[,] INPUTMAP,ref bool ISDROW)
        {
            //플레이어가 있던 원래 위치 초기화
            INPUTMAP[PLAYERY, PLAYERX] = 0;

            //위
            if (INPUTKEY == ConsoleKey.W)   // W 키를 누르면
            {
                PLAYERY -= 1;   //y값 -1 (빼면 좌표상 위로 올라가기 때문에)

                if(PLAYERY < INPUTMAP.GetLowerBound(0) ||   //만약 공간의 끝이거나 (플레이어 Y좌표 < 이중배열 첫번째의 제일 낮은 인덱스 값)
                    INPUTMAP[PLAYERY, PLAYERX] == 1)    // 혹은 1(벽)값이 있거나
                {
                    PLAYERY += 1;   //위에서 뺐던 값을 다시 더하여 되돌아간다.
                }
            }

            //아래
            if (INPUTKEY == ConsoleKey.S)   // S 키를 누르면
            {
                PLAYERY += 1;   //y값 +1 (더하면 좌표상 아래로 가기 때문에)

                if (PLAYERY > INPUTMAP.GetUpperBound(0) || //만약 공간의 끝이거나 (플레이어 Y좌표 > 이중배열 첫번째의 제일 높은 인덱스 값)
                    INPUTMAP[PLAYERY, PLAYERX] == 1)    // 혹은 1(벽)값이 있거나
                {
                    PLAYERY -= 1;   //위에서 더했던 값을 다시 빼서 되돌아간다.
                }
            }

            //왼
            if (INPUTKEY == ConsoleKey.A)   // A 키를 누르면
            {
                PLAYERX -= 1;   //x값 -1 (빼면 좌표상 왼쪽으로 가기 때문에)

                if (PLAYERX < INPUTMAP.GetLowerBound(1) || //만약 공간의 끝이거나 (플레이어 x좌표 < 이중배열 두번째의 제일 낮은 인덱스 값)
                    INPUTMAP[PLAYERY, PLAYERX] == 1)    // 혹은 1(벽)값이 있거나
                {
                    PLAYERX += 1;   //위에서 뺐던 값을 다시 더하여 되돌아간다.
                }
            }

            //오른
            if (INPUTKEY == ConsoleKey.D)   // D 키를 누르면
            {
                PLAYERX += 1;   //x값 +1 (더하면 좌표상 오른쪽으로 가기 때문에)

                if (PLAYERX > INPUTMAP.GetUpperBound(1) ||  //만약 공간의 끝이거나 (플레이어 x좌표 > 이중배열 첫번째의 제일 높은 인덱스 값)
                    INPUTMAP[PLAYERY, PLAYERX] == 1)    // 혹은 1(벽)값이 있거나
                {
                    PLAYERX -= 1;   //위에서 더했던 값을 다시 빼서 되돌아간다.
                }
            }
            INPUTMAP[PLAYERY, PLAYERX] = 2; //위에서 변경한 플레이어 X,Y 좌표에 값 수정 (2 : 플레이어)
            ISDROW = false; //그리기 bool 값 false (갱신)
        }

        //맵에 겉에만 벽 세팅하는 함수
        static void WALL_SET(ref int[,] MAP_)
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
        }

        //맵 그리는 함수
        static void DROW_MAP(int[,] MAP_)
        {
            for(int y = 0; y <= MAP_.GetUpperBound(0); y++)     //y축 루프문 (첫번째 배열)
            {
                for(int x = 0; x <= MAP_.GetUpperBound(1); x++) //x축 루프문 (두번째 배열)
                {
                    switch(MAP_[y,x])                           //배열 값에 따른 다른 그리기문
                    {
                        case 2:
                            Console.Write("옷".PadRight(3, ' '));        //2값은 플레이어
                            break;
                        case 1:
                            Console.Write("□".PadRight(3, ' '));        //1값은 벽
                            break;
                        case 0:
                            Console.Write(".".PadRight(4, ' '));        //0값은 빈 공간
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            //현재 플레이어의 위치값 확인 출력문
            for (int y = 0; y <= MAP_.GetUpperBound(0); y++) //y축 루프문 (첫번째 배열)
            {
                for (int x = 0; x <= MAP_.GetUpperBound(1); x++) //x축 루프문 (두번째 배열)
                {
                    if (MAP_[y, x] == 2) Console.WriteLine("{0}, {1}", x, y);   //배열에 2(플레이어)값을 찾고 좌표 출력
                }
                Console.WriteLine();
            }
        }
    }
}
