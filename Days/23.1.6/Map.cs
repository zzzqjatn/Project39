using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Map
    {
        /*
         * 맵 번호 가이드
         * 1: 시작지점
         * 2: 마을
         * 3: 던전
         * 4: 보스방
         */

        /*
         * 전체 맵 (던전맵과 다름)
         * MAP.position 값 가이드
         *  0 : 빈 곳
         *  1 : 벽
         *  2 : 플레이어
         *  3 : 몬스터
         *  4 : 보스
         *  5 : 상점NPC
         *  6 : 주점NPC
         *  7 : 여관NPC
         *  99 : 포탈
         */
        public Map()
        {
            map = new List<MAPInfo>();
            MapsInit();
        }

        public class MAPInfo
        {
            //생성자
            public MAPInfo(string _name, int _typeNum, int[,] _position, int[] _potal, bool _isMapDraw)
            {
                name = _name;
                typeNum = _typeNum;
                position = _position;
                potal = _potal;
                isdrawing = _isMapDraw;
            }

            public string name;    //맵이름
            public int typeNum;    //맵번호
            private int[,] position;    //맵 범위
            private int[] potal;        //맵 포탈위치 0:왼쪽 1:위쪽 2:오른쪽 3:아래쪽 
                                        //배열의 값에 따라 이동 : 맵번호 입력(0은 포탈 없음)
            private bool isdrawing; // 그리기 여부 값

            public bool GetDraw() { return this.isdrawing; }
            public void SetDraw(bool _drawing) { this.isdrawing = _drawing; }
            public int[,] GetMapPosition() { return position; }
            public void SetMapPosition(int[,] _position) { position = _position; }

            public void SetTest(string name_, int typeNum_)
            {
                this.name = name_;
                this.typeNum = typeNum_;
            }
        }

        private List<MAPInfo> map;
        private const int FIRST_MAP_SIZE = 30;
        private const int TOWN_MAP_SIZE = 20;
        private int RandomRoomSize = 0;

        public void MapsInit()
        {
            MapInitAndAdd("시작지점", 1, FIRST_MAP_SIZE, FIRST_MAP_SIZE, new int[] { 0, 3, 2, 0 });
            MapInitAndAdd("마을", 2, TOWN_MAP_SIZE, TOWN_MAP_SIZE, new int[] { 0, 1, 0, 0 });
        }

        //맵 가변배열에 벽과 포탈 적재하는 함수
        private int[,] mapPositionAndPotalSet(int[,] inputMap, int[] inputPotal)
        {
            for (int y = 0; y <= inputMap.GetUpperBound(0); y++)
            {
                for (int x = 0; x <= inputMap.GetUpperBound(1); x++)
                {
                    if (0 < y && y < inputMap.GetUpperBound(0))
                    {
                        if (0 < x && x < inputMap.GetUpperBound(1))
                        {
                            inputMap[y, x] = 0;
                        }
                        else
                        {
                            inputMap[y, x] = 1;
                        }
                    }
                    else
                    {
                        inputMap[y, x] = 1;
                    }
                }
            }

            int middleSizeY = inputMap.GetUpperBound(0) / 2;
            int middleSizeX = inputMap.GetUpperBound(1) / 2;

            for (int i = 0; i < inputPotal.Length; i++)
            {
                if (inputPotal[i] != 0)
                {
                    switch (i)
                    {
                        case 0: //왼쪽
                            inputMap[0 + middleSizeY, 0] = 99;
                            break;
                        case 1: //위쪽
                            inputMap[0, 0 + middleSizeX] = 99;
                            break;
                        case 2: //오른쪽
                            inputMap[0 + middleSizeY, inputMap.GetUpperBound(1)] = 99;
                            break;
                        case 3: //아래쪽
                            inputMap[inputMap.GetUpperBound(0), 0 + middleSizeX] = 99;
                            break;
                    }
                }
            }
            return inputMap;
        }

        //맵 리스트에 적재 함수
        private void MapInitAndAdd(string mapName, int mapNumber, int mapSizeX, int mapSizeY, int[] potals)
        {
            MAPInfo temp;
            int[,] tempMAP = new int[mapSizeY, mapSizeX];

            tempMAP = mapPositionAndPotalSet(tempMAP, potals);

            temp = new MAPInfo(mapName, mapNumber, tempMAP, potals, false);

            map.Add(temp);
        }

        //연구
        public void DungeonMapInit()
        {
            Random random = new Random();
            RandomRoomSize = random.Next(3, 5 + 1);
        }

        //맵그리는 함수
        public void DrawMapList()
        {
            int[,] temp;

            for (int i = 0; i < map.Count; i++)
            {
                if (map[i].GetDraw() == true)
                {
                    temp = map[i].GetMapPosition();
                    Console.SetCursorPosition(0, 0);
                    for (int j = 0; j < temp.GetUpperBound(1); j++)
                    {
                        for (int k = 0; k < temp.GetUpperBound(0); k++)
                        {
                            switch (temp[j, k])
                            {
                                case 0:
                                    Console.Write("   ".PadRight(5, ' '));
                                    break;
                                case 1:
                                    Console.Write("■".PadRight(5, ' '));
                                    break;
                                case 2:
                                    Console.Write("옷".PadRight(2, ' '));
                                    break;
                                case 3:
                                    Console.Write("＠".PadRight(3, ' '));
                                    break;
                            }
                        }
                        Console.WriteLine();
                    }
                }
            }
        }

        public void DrawMapList2222()
        {
            int[,] temp;

            temp = map[0].GetMapPosition();
            Console.SetCursorPosition(0, 0);
            for (int j = 0; j <= temp.GetUpperBound(1); j++)
            {
                for (int k = 0; k <= temp.GetUpperBound(0); k++)
                {
                    switch (temp[j, k])
                    {
                        case 0:
                            Console.Write(" , ".PadRight(2, ' '));
                            break;
                        case 1:
                            Console.Write("■".PadRight(2, ' '));
                            break;
                        case 2:
                            Console.Write("옷".PadRight(2, ' '));
                            break;
                        case 99:
                            Console.Write("＠".PadRight(2, ' '));
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        //맵정보 주기
        public int[,] GiveMapList()
        {
            int[,] temp = default;

            //for (int i = 0; i < map.Count; i++)
            //{
            //    if (map[i].GetDraw() == true)
            //    {
            //        temp = map[i].GetMapPosition();
            //    }
            //}

            temp = map[0].GetMapPosition();
            return temp;
        }

        //플레이어 맵에 세팅
        public void playerSetting(int[] MapData)
        {
            int index = MapData[0] - 1;
            int y = MapData[1];
            int x = MapData[2];

            bool isdrawing_ = true;

            //다른 맵이 켜져 있다면 없애주기
            for(int i = 0; i < map.Count; i++)
            {
                //if(map[i].GetDraw() == true)
                //{
                //    map[i].SetDraw(true);
                //}
                    map[i].SetDraw(true);
            }

            int[,] temp = map[index].GetMapPosition();
            temp[y, x] = 2;
            map[index].SetMapPosition(temp);
            map[index].SetDraw(true);

            Console.WriteLine("Map: isdrawing_ -> {0}", map[index].GetDraw());
            //map[0].SetDraw(true);
            //Console.WriteLine();
        }
    }
}
