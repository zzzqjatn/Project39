using System;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace WhatisFunction
{

    public class PotalGame
    {
        //순번대로 왼쪽 ,가운데, 오른쪽, 위, 아래
        private static int[] MAP_SIZE_X = new int[5] { 10, 10, 10, 10, 10 };   //맵사이즈x값
        private static int[] MAP_SIZE_Y = new int[5] { 10, 10, 10, 10, 10 };   //맵사이즈y값

        private Map M_Left;
        private Map M_Right;
        private Map M_Middle;
        private Map M_Top;
        private Map M_Bottom;
        private Player player;

        /*
         * MAP 표시
         * 0 : ■    벽
         * 1 : .    빈 땅
         * 2 : 플레이어
         * 3 : 코인
         * 4 : 포탈
         */

        /*
         * 포탈 표시
         * 0 : 없음
         * 1 : 왼쪽
         * 2 : 가운데
         * 3 : 오른쪽
         * 4 : 위
         * 5 : 아래
         */

        struct Map
        {
            public Map(int sizeX, int sizeY, int[] potaldir)
            {
                MAP = new int[sizeX, sizeY];
                PotalDir = potaldir;
            }

            int[,] MAP;
            int[] PotalDir = new int[4];

            int coinCounter = 0;

            public int[,] GetMAP() { return MAP; }
            public void SetMAP(int[,] set) { MAP = set; }

            public int[] GetPotalDir() { return PotalDir; }

            public int GetCoinCounter() { return coinCounter; }
            public void AddCoinCount() { coinCounter++; }
            public void DeclineCoin() { coinCounter--; }
        }

        struct Player
        {
            public Player(int setMap, int positionX, int positionY, int coin)
            {
                NowMap = setMap;
                X = positionX;
                Y = positionY;
                Coin = coin;
                MoveCount = 0;
            }
            int NowMap;
            int X;
            int Y;
            int Coin;
            int MoveCount;

            public int GetX() { return X; }
            public int GetY() { return Y; }
            public int GetNowMap() { return NowMap; }
            public int GetMoveCount() { return MoveCount; }
            public int GetCoin() { return Coin; }

            public void SetNowMap(int number) { NowMap = number; }
            public void SetPosition(int y,int x)
            {
                Y = y;
                X = x;
            }
            public void AddCoin() { Coin++; }
            public void AddMoveCount() { MoveCount++; }
        }

        public PotalGame()
        {
            SettingMap();
        }


        public void InGame()
        {
            bool isDraw = true;

            Task loopTask = Task.Run(async () =>
            {
                await Task.Delay(3000); //딜레이를 3초 걸어놓고 아래의 코드가 실행된다
                M_Middle.AddCoinCount();       //맵코인 카운터갯수 추가
                M_Middle.SetMAP(coinSetting(M_Middle.GetMAP()));    //랜덤 코인 생성함수
                isDraw = false;         //그리기 갱신을 위한 false

                //코인체크 우연히 내가 코인을 그려줄 곳에 있었다면
                int[,] temp = M_Middle.GetMAP();
                if (temp[player.GetY(), player.GetX()] == 3)
                {
                    player.AddCoin();   //코인추가
                    M_Middle.DeclineCoin(); //지워주고
                    temp[player.GetY(), player.GetX()] = 2;
                    M_Middle.SetMAP(temp);
                }
            });

            while (true)
            {
                if (player.GetCoin() >= 10) break;

                if (M_Middle.GetCoinCounter() < 5 && loopTask.IsCompleted)
                {
                    loopTask = Task.Run(async () =>
                    {
                        await Task.Delay(3000); //딜레이를 3초 걸어놓고 아래의 코드가 실행된다
                        M_Middle.AddCoinCount();       //맵코인 카운터갯수 추가
                        M_Middle.SetMAP(coinSetting(M_Middle.GetMAP()));    //랜덤 코인 생성함수
                        isDraw = true;         //그리기 갱신을 위한 false

                        //코인체크
                        int[,] temp = M_Middle.GetMAP();
                        if (temp[player.GetY(), player.GetX()] == 3)
                        {
                            player.AddCoin();
                            M_Middle.DeclineCoin();
                            temp[player.GetY(), player.GetX()] = 2;
                            M_Middle.SetMAP(temp);
                        }
                    });
                }

                if (isDraw)
                {
                    Console.SetCursorPosition(0, 0);
                    switch (player.GetNowMap())
                    {
                        case 1:
                            drawMap(M_Left.GetMAP(), player.GetCoin(),player.GetMoveCount());
                            break;
                        case 2:
                            drawMap(M_Middle.GetMAP(), player.GetCoin(), player.GetMoveCount());
                            break;
                        case 3:
                            drawMap(M_Right.GetMAP(), player.GetCoin(), player.GetMoveCount());
                            break;
                        case 4:
                            drawMap(M_Top.GetMAP(), player.GetCoin(), player.GetMoveCount());
                            break;
                        case 5:
                            drawMap(M_Bottom.GetMAP(), player.GetCoin(), player.GetMoveCount());
                            break;
                    }
                    isDraw = false;
                    //Console.MoveBufferArea(0, 50, 40, 40, 20, 5);
                    //Console.SetCursorPosition(0, 0);
                }

                if (Console.KeyAvailable)
                {
                    move(Console.ReadKey());
                    isDraw = true;
                }
            }
            Console.WriteLine("코인 10개 이상을 먹어 프로그램을 종료합니다.");
        }

        private void potalMove(int potaldir)
        {
            Map temp = default;

            switch (potaldir)
            {
                case 1:
                    temp = M_Left;
                    break;
                case 2:
                    temp = M_Middle;
                    break;
                case 3:
                    temp = M_Right;
                    break;
                case 4:
                    temp = M_Top;
                    break;
                case 5:
                    temp = M_Bottom;
                    break;
            }

            int[] tempDir = temp.GetPotalDir();
            int[,] tempMap = temp.GetMAP();

            int centerY = tempMap.GetUpperBound(0) / 2;
            int centerX = tempMap.GetUpperBound(1) / 2;


            for (int i = 0; i < tempDir.Length; i++)
            {
                if (tempDir[i] == player.GetNowMap())
                {
                    switch (i)
                    {
                        case 0:
                            tempMap[0 + centerY, 1] = 2;  //왼쪽
                            player.SetPosition(0 + centerY, 1);
                            break;
                        case 1:
                            tempMap[1, 0 + centerX] = 2;  //위쪽
                            player.SetPosition(1, 0 + centerX);
                            break;
                        case 2:
                            tempMap[0 + centerY, tempMap.GetUpperBound(1) - 1] = 2;  //오른쪽
                            player.SetPosition(0 + centerY, tempMap.GetUpperBound(1) - 1);
                            break;
                        case 3:
                            tempMap[tempMap.GetUpperBound(0) - 1, 0 + centerX] = 2;  //아래쪽
                            player.SetPosition(tempMap.GetUpperBound(0) - 1, 0 + centerX);
                            break;
                    }
                }
            }

            temp.SetMAP(tempMap);
            player.SetNowMap(potaldir);
        }

        public void move(ConsoleKeyInfo inputKey)
        {
            int[,] tempMap = returnNowMap().GetMAP();
            int[] P_dir = returnNowMap().GetPotalDir();
            int tempX = player.GetX();
            int tempY = player.GetY();

            bool isPotalMove = false;

            tempMap[tempY, tempX] = 0;

            //위
            if (inputKey.Key == ConsoleKey.W)   // W 키를 누르면
            {
                if (tempMap[tempY - 1, tempX] == 4)    //포탈이라면
                {
                    player.AddMoveCount();
                    potalMove(P_dir[1]);    //1는 위방향 포탈
                    isPotalMove = true;
                }
                else if (0 <= (tempY - 1) && tempMap[(tempY-1),tempX] != 1)
                {
                    tempY -= 1;
                    player.AddMoveCount();
                }
            }

            //아래
            if (inputKey.Key == ConsoleKey.S)   // S 키를 누르면
            {
                if (tempMap[tempY + 1, tempX] == 4)    //포탈이라면
                {
                    player.AddMoveCount();
                    potalMove(P_dir[3]);    //3는 아래 방향 포탈
                    isPotalMove = true;
                }
                else if (tempMap.GetUpperBound(0) >= (tempY + 1) && tempMap[(tempY + 1), tempX] != 1)
                {
                    tempY += 1;
                    player.AddMoveCount();
                }
            }

            //왼
            if (inputKey.Key == ConsoleKey.A)   // A 키를 누르면
            {
                if (tempMap[tempY, tempX - 1] == 4)    //포탈이라면
                {
                    player.AddMoveCount();
                    potalMove(P_dir[0]);    //0는 왼쪽 방향 포탈
                    isPotalMove = true;
                }
                else if (0 <= (tempX - 1) && tempMap[tempY, (tempX - 1)] != 1)
                {
                        tempX -= 1;
                        player.AddMoveCount();
                }
            }

            //오른
            if (inputKey.Key == ConsoleKey.D)   // D 키를 누르면
            {
                if (tempMap[tempY, tempX + 1] == 4)    //포탈이라면
                {
                    player.AddMoveCount();
                    potalMove(P_dir[2]);    //0는 왼쪽 방향 포탈
                    isPotalMove = true;
                }
                else if (tempMap.GetUpperBound(1) >= (tempX + 1) && tempMap[tempY, (tempX + 1)] != 1)
                {
                    tempX += 1;
                    player.AddMoveCount();
                }
            }
            //코인체크
            if (tempMap[tempY, tempX] == 3)
            {
                player.AddCoin();
                M_Middle.DeclineCoin();
            }

            //포탈체크
            if (!isPotalMove)
            {
                tempMap[tempY, tempX] = 2;
                player.SetPosition(tempY,tempX);
                resetNowMap(tempMap);
            }
        }

        private Map returnNowMap()
        {
            Map temp = default;

            switch (player.GetNowMap())
            {
                case 1:
                    temp = M_Left;
                    break;
                case 2:
                    temp = M_Middle;
                    break;
                case 3:
                    temp = M_Right;
                    break;
                case 4:
                    temp = M_Top;
                    break;
                case 5:
                    temp = M_Bottom;
                    break;
            }

            return temp;
        }

        public void resetNowMap(int[,] map)
        {
            switch (player.GetNowMap())
            {
                case 1:
                    M_Left.SetMAP(map);
                    break;
                case 2:
                    M_Middle.SetMAP(map);
                    break;
                case 3:
                    M_Right.SetMAP(map);
                    break;
                case 4:
                    M_Top.SetMAP(map);
                    break;
                case 5:
                    M_Bottom.SetMAP(map);
                    break;
            }
        }

        private static Map SettingPotal(Map map)
        {
            int[] tempDir = map.GetPotalDir();
            int[,] tempMap = map.GetMAP();

            int centerY = tempMap.GetUpperBound(0) / 2;
            int centerX = tempMap.GetUpperBound(1) / 2;

            for (int i = 0; i < tempDir.Length; i++)
            {
                if (tempDir[i] == 0) continue;
                else
                {
                    switch(i)
                    {
                        case 0:
                            tempMap[0 + centerY, 0] = 4;  //왼쪽
                            break;
                        case 1:
                            tempMap[0, 0 + centerX] = 4;  //위쪽
                            break;
                        case 2:
                            tempMap[0 + centerY,tempMap.GetUpperBound(1)] = 4;  //오른쪽
                            break;
                        case 3:
                            tempMap[tempMap.GetUpperBound(0), 0 + centerX] = 4;  //아래쪽
                            break;
                    }
                }
            }

            map.SetMAP(tempMap);

            return map;
        }

        private static int[,] coinSetting(int[,] map)        //맵에 코인 세팅하는 함수
        {
            Random random = new Random();   //랜덤 클래스 생성
            int[,] tempMap = map;

            while (true)
            {
                int coinX = random.Next(0, tempMap.GetUpperBound(0) + 1);     //코인의 랜덤 X값
                int coinY = random.Next(0, tempMap.GetUpperBound(1) + 1);     //코인의 랜덤 y값

                if (tempMap[coinX, coinY] == 0) //빈 곳이면
                {
                    tempMap[coinY, coinX] = 3; //코인으로 변경
                    break;
                }
            }
            return tempMap;    //변형된 맵 반환
        }

        public void SettingMap()
        {
            //방향에 0 값이 아니라면 포탈이 있다 (왼 : 1 가운데 : 2 오른 : 3 위 : 4 아래 : 5)
            M_Left = new Map(MAP_SIZE_X[0], MAP_SIZE_Y[0], new int[] { 0, 0, 2, 0 });
            M_Middle = new Map(MAP_SIZE_X[1], MAP_SIZE_Y[1], new int[] { 1, 4, 3, 5 });
            M_Right = new Map(MAP_SIZE_X[2], MAP_SIZE_Y[2], new int[] { 2, 0, 0, 0 });
            M_Top = new Map(MAP_SIZE_X[3], MAP_SIZE_Y[3], new int[] { 0, 0, 0, 2 });
            M_Bottom = new Map(MAP_SIZE_X[4], MAP_SIZE_Y[4], new int[] { 0, 2, 0, 0 });
            
            M_Left.SetMAP(mapInit(M_Left));
            M_Middle.SetMAP(mapInit(M_Middle));
            M_Right.SetMAP(mapInit(M_Right));
            M_Top.SetMAP(mapInit(M_Top));
            M_Bottom.SetMAP(mapInit(M_Bottom));

            player = new Player(1, 2, 2, 0);

            int[,] temp;

            switch(player.GetNowMap())
            {
                case 1:
                    temp = M_Left.GetMAP();
                    temp[player.GetX(), player.GetY()] = 2;
                    M_Left.SetMAP(temp);
                    break;
                case 2:
                    temp = M_Middle.GetMAP();
                    temp[player.GetX(), player.GetY()] = 2;
                    M_Middle.SetMAP(temp);
                    break;
                case 3:
                    temp = M_Right.GetMAP();
                    temp[player.GetX(), player.GetY()] = 2;
                    M_Right.SetMAP(temp);
                    break;
                case 4:
                    temp = M_Top.GetMAP();
                    temp[player.GetX(), player.GetY()] = 2;
                    M_Top.SetMAP(temp);
                    break;
                case 5:
                    temp = M_Bottom.GetMAP();
                    temp[player.GetX(), player.GetY()] = 2;
                    M_Bottom.SetMAP(temp);
                    break;
            }
        }

        static int[,] mapInit(Map map)        
        {
            map = SettingPotal(map);

            int[,] tempMap = map.GetMAP();

            for (int y = 0; y <= tempMap.GetUpperBound(0); y++)    //y축 루프문 (첫번째 배열)
            {
                for (int x = 0; x <= tempMap.GetUpperBound(1); x++)    //x축 루프문 (두번째 배열)
                {
                    if (tempMap[y, x] != 4)
                    {
                        if (0 < y && y < tempMap.GetUpperBound(0))  //첫번째(0) 보다 크고 최대 값보다 작은 범위 설정
                        {
                            if (0 < x && x < tempMap.GetUpperBound(1)) //첫번째(0) 보다 크고 최대 값보다 작은 범위 설정
                            {
                                tempMap[y, x] = 0;
                            }
                            else
                            {
                                tempMap[y, x] = 1;
                            }
                        }
                        else
                        {
                            tempMap[y, x] = 1;
                        }
                    }
                }
            }

            return tempMap;
        }

        static void drawMap(int[,] map, int playerCoin, int playerMovecount)
        {
            Console.WriteLine("현재 플레이어 코인 : {0}", playerCoin);  //현재 플레이어가 먹은 코인

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Black;
            for (int y = 0; y <= map.GetUpperBound(0); y++)     //y축 루프문 (첫번째 배열)
            {
                for (int x = 0; x <= map.GetUpperBound(1); x++) //x축 루프문 (두번째 배열)
                {
                    switch (map[y, x])                           //배열 값에 따른 다른 그리기문
                    {
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("＠".PadRight(2, ' '));        //3값은 포탈
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("₩  ".PadRight(3, ' '));        //3값은 코인
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("옷".PadRight(2, ' '));        //2값은 플레이어
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("■".PadRight(2, ' '));        //1값은 벽
                            Console.ForegroundColor = ConsoleColor.Black;
                            break;
                        case 0:
                            Console.Write(".".PadRight(3, ' '));        //0값은 빈 공간
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.WriteLine("움직인 횟수 : {0}", playerMovecount);
            //현재 플레이어의 위치값 확인 출력문
            for (int y = 0; y <= map.GetUpperBound(0); y++) //y축 루프문 (첫번째 배열)
            {
                for (int x = 0; x <= map.GetUpperBound(1); x++) //x축 루프문 (두번째 배열)
                {
                    if (map[y, x] == 2)
                    {
                        Console.WriteLine("[플레이어] 좌표 X {0}, 좌표 Y {1}", x, y);   //배열에 2(플레이어)값을 찾고 좌표 출력
                        break;
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
