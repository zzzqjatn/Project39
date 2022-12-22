using System;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Reflection;

namespace WhatisArray2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //모드 연산자
            //랜덤 클래스에서 쓰는 방식과 같다
            //나머지 값 원리로 난수 범위를 정해주는 것임
            //int number = 1_0821;
            //Console.WriteLine("64로 Mod 연산 {0}", number % 64);

            //배열
            /*
             * 다차원 배열
             * 2차원 배열, 3차원 배열처럼 차원이 2개 이상인 배열을 다차원 배열이라고 한다.
             * C#에서 배열을 선언할 때는 콤마를 기준으로 차원을 구분한다.
             */

            //int[] oneArray = new int[2] { 1, 2 };
            ////이차원 배열
            //int[,] twoArray = new int[3, 2] { { 1, 2 }, { 3, 4 } ,{ 5, 6 } };
            ////삼차원 배열
            //int[,,] threeArray = new int[2, 2, 2] 
            //{ 
            //    { { 1, 2 }, { 3, 4 } },
            //    { { 1, 2 }, { 3, 4 } }
            //};

            //// 3행 3열짜리 배열에서 행과 열이 같으면 1, 다르면 0을 출력
            //twoArray = new int[3, 3];

            //for(int y = 0; y < 3; y++)
            //{
            //    for(int x = 0; x < 3; x++)
            //    {
            //        if (x == y) { twoArray[y, x] = 1; }
            //        else { twoArray[y, x] = 0; }
            //    }
            //}   // loop: 값을 대입하는 루프

            //for (int y = 0; y <= twoArray.GetUpperBound(0); y++)
            //{
            //    for (int x = 0; x <= twoArray.GetUpperBound(1); x++)
            //    {
            //        Console.Write("{0} ", twoArray[y, x]);
            //    }
            //    Console.WriteLine();
            //}   // loop: 값을 출력하는 루프

            /*
             * 가변 배열
             * 차원이 2개 이상인 배열은 다차원 배열이고, 배열 길이가 가변 길이인 배열은 가변 배열이라고 한다.
             */

            //int[][] zagArray = new int[2][];
            //zagArray[0] = new int[2] { 1, 2 };
            //zagArray[1] = new int[3] { 3, 4, 5 };

            //for(int y = 0; y < 2; y++)
            //{
            //    for(int x = 0; x < zagArray[y].Length; x++)
            //    {
            //        Console.Write("{0} ",zagArray[y][x]);
            //    }
            //    Console.WriteLine();
            //}

            //int[] intArray;                 // int 형 데이터 타입의 intArray 라는 배열을 선언
            //intArray = new int[3];          // int 형 데이터 타입의 변수를 3개 메모리에 할당

            //intArray[0] = 1;                // intArray 0번째 인덱스에 1이라는 정수값을 대입
            //intArray[1] = 2;                // intArray 1번째 인덱스에 2이라는 정수값을 대입
            //intArray[2] = 3;                // intArray 2번째 인덱스에 3이라는 정수값을 대입

            ////배열 직접 출력해본다.
            //for (int index=0; index < 3; index++)
            //{
            //    Console.WriteLine("{0} 번째 인덱스의 값 -> {1}", index, intArray[index]);
            //}   //loop : 3번 도는 루프
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();        //라인 클리어

            ////intArray 배열에서 int 형 데이터 타입의 값을 하나씩 뽑아서 index에 저장 할거임.
            //foreach(int index in intArray)
            //{
            //    Console.WriteLine("intArray 배열에서 뽑아온 값 -> {0}", index);
            //}   // loop : intArray 배열의 길이만큼 도는 루프

            /*  배열을 사용하여 국어점수의 총점과 평균 구하기
             *  학생 3명의 점수를 저장하는 배열 선언해서, 각 학생별로 점수를 할당하고 (범위는 1 ~ 100 점)
             *  모든 점수의 총점과 평균을 구해서 출력하는 프로그램
             * 
             *          -> user input (학생의 점수) 받아서 프로그램 작성해 볼 것
             *          - 유저 인풋은 3회 (3명의 학생니까)
             *          - 점수 범위(범위는 1 ~ 100점)
             *          - 이상한 입력 예외처리
             */

            //int[] studentScore = new int[3];
            //int studentScoreResult = 0;
            //int studentScoreAverage = 0;

            //for (int index = 0; index < studentScore.Length; index++)
            //{
            //    //예외처리문
            //    while (true)
            //    {
            //        //점수 입력문
            //        Console.Write($"{index + 1}번째 학생의 국어점수를 입력해주세요 : ");
            //        int.TryParse(Console.ReadLine(), out studentScore[index]);

            //        //범위 안
            //        if (0 < studentScore[index] && studentScore[index] <= 100)
            //        {
            //            studentScoreResult += studentScore[index];
            //            break;
            //        }
            //        else { /* Do nothing */}

            //        Console.WriteLine("\t\t\t\t\t\t잘못된 입력 값입니다.");
            //    }   // loop : 예외처리 무한 루프
            //}   // loop : studentScore 관한 루프 (3번 반복)
            //studentScoreAverage = studentScoreResult / studentScore.Length;

            //Console.WriteLine($"학생들의 총점 : {studentScoreResult}, 학생들의 평균 : {studentScoreAverage}");

            /*
             * LAB 1. 배열에서 최대값 찾기
             * 크기가 100인 배열을 1부터 100 사이의 난수로 채우고 배열 요소중에서 최대 값을 찾아보자
             *  - 보기 좋게 출력
             *  - 가독성이 높아야 함
             *  
             * LAB 2. 사과를 제일 좋아하는 사람 찾기
             * 사람들 5명(사람1, 사람2, 사람3,..... 사람5명)에게 아침에 먹는 사과 개수를 입력하도록 요청하는 프로그램 작성
             * 데이터입력이 마무리 되면 누가 가장 많은 사과를 아침으로 먹었는지 출력한다. (기본형)
             *          - 이상한 입력 예외처리
             *          - 제일 적게 먹은 사람도 찾도록 수정해보기 (변형1)
             *          - 먹은 사과의 갯수 순으로 정렬 정렬 알고리즘은 본인이 사용 한것으로 하되
             *              알고리즘을 잘 모르겠다면 버블 정렬 도전 해볼 것 (변형2)
             *              알고리즘을 잘 알겠다면 Merge Sort 도전 해볼 것 (어려운거)
             *                  -정렬 도전시 유저 입력 X
             *                  -데이터는 난수로 채워넣음(Count는 100 ~ 1000개,value range 는 임의로 )
             *                  -중복 제거
             *                  -시간초는 전혀 상관 없음
             *              
             *   본인의 능력껏 기본형, 변형1, 변형2, 어려운거 난이도 순서로 도전해 볼 것
             */

            //-----------------최대값찾기 start-------------------//

            int[] BigData = new int[100];   //난수를 넣을 배열 선언 및 초기화

            Random rand = new Random();     //랜덤 클래스 생성

            for (int index = 0; index < BigData.Length; index++)    //난수 데이터 값 세팅을 위한 반복문
            {
                BigData[index] = rand.Next(1, 100 + 1); // 난수값 (1 ~ 100 범위) 넣기 

                Console.WriteLine($"{index + 1}번째 데이터 값 : {BigData[index]}"); // 콘솔화면에 어떤 값이 넣어졌는 지 확인을 위한 출력문
                Console.WriteLine("========================");  //가독성을 위한 문장
                Console.WriteLine();    //가독성을 위한 문장
            }

            int[] MaxDataNumber = new int[100]; //가장 큰수와 중복값이 있을 경우를 번호 알기 위한 배열
            int MaxData = 0;    //현재 가장 큰값 변수
            for (int index = 0; index < BigData.Length; index++)    //가장 큰값 찾기 반복문
            {
                if (BigData[index] >= MaxData)     //현재 가장 큰값 변수 보다 난수 넣어진 배열 값이 더 크거나 같을 경우
                {
                    if (BigData[index] == MaxData)  //현재 가장 큰값 변수보다 난수배열값이 같을 경우 
                    {
                        MaxDataNumber[index] = index + 1;   //가장 큰수 중복값 번호 배열에 몇번째인지 값넣기
                    }
                    else                                    //현재 가장 큰값 변수보다 난수배열 값이 클 경우
                    {
                        Array.Clear(MaxDataNumber);         //기존 가장 큰수 중복값 체크 배열 삭제 (기존 큰값보다 더 )
                        MaxDataNumber[index] = index + 1;   //가장 큰수 중복값 번호 배열에 몇번째인지 값넣기
                    }
                    MaxData = BigData[index];               //현재 가장 큰값 변수 갱신
                }
            }
            Console.Write("\t\t\t\t");  //가독성을 위한 문장

            for (int index = 0; index < MaxDataNumber.Length; index++)  //큰수에 관한 출력문
            {
                if (MaxDataNumber[index] != 0)  //가장 큰수 중복 값 배열이 비어있지 않는 경우
                {
                    Console.Write($"{MaxDataNumber[index]} ");  //가장 큰수 중복값
                }
            }
            Console.WriteLine($"번째 데이터 : {MaxData} 이 제일 큽니다");

            //-----------------사과 먹기 start-------------------//
            //(기본형, 변형1)
            int[] people = new int[5];

            for (int index = 0; index < people.Length; index++)
            {
                while (true)
                {
                    int.TryParse(Console.ReadLine(), out people[index]);

                    if (0 < people[index])
                    {
                        break;
                    }
                    Console.WriteLine("\t\t\t\t\t\t잘못된 입력 값입니다.");
                }
            }

            int[] maxDataNumber = new int[5];
            int[] minDataNumber = new int[5];
            int maxData = 0;
            int minData = 0;
            bool mindataCheck = false;
            for (int index = 0; index < people.Length; index++)
            {
                if (people[index] >= maxData)
                {
                    if (people[index] == maxData)
                    {
                        maxDataNumber[index] = index + 1;
                    }
                    else
                    {
                        Array.Clear(maxDataNumber);
                        maxDataNumber[index] = index + 1;
                    }
                    maxData = people[index];

                    if (mindataCheck == false)
                    {
                        minData = maxData;
                        mindataCheck = true;
                    }
                }

                if (people[index] <= minData)
                {
                    if (people[index] == minData)
                    {
                        minDataNumber[index] = index + 1;
                    }
                    else
                    {
                        Array.Clear(minDataNumber);
                        minDataNumber[index] = index + 1;
                    }
                    minData = people[index];
                }
            }

            Console.WriteLine();
            for (int index = 0; index < maxDataNumber.Length; index++)
            {
                if (maxDataNumber[index] != 0)
                {
                    Console.Write($"{maxDataNumber[index]} ");
                }
            }

            Console.WriteLine($"번째 사람이 사과를 : {maxData} 개로 제일 많이 먹습니다.");

            for (int index = 0; index < minDataNumber.Length; index++)
            {
                if (minDataNumber[index] != 0)
                {
                    Console.Write($"{minDataNumber[index]} ");
                }
            }

            Console.WriteLine($"번째 사람이 사과를 : {minData} 개로 제일 적게 먹습니다.");
            Console.WriteLine();

            //----------------------먹은 순서대로 정렬 (변형2) 버블 start-----------------------//

            Random rad = new Random();

            int Sortbubble = 0;

            int[] Apple_P = new int[5];
            bool Retry = true;


            //중복제거
            while (Retry)
            {
                for(int index = 0; index < Apple_P.Length; index++)
                {
                    Apple_P[index] = rad.Next(100, 1000 + 1);
                }

                for(int index1 = 0; index1 < Apple_P.Length; index1++)
                {
                    for(int index2 = index1 + 1; index2 < Apple_P.Length; index2++)
                    {
                        if (Apple_P[index1] == Apple_P[index2])
                        {
                            Retry = true;
                            break;
                        }
                        else
                        {
                            Retry = false;
                        }
                    }
                }
            }

            for (int index = 0; index < Apple_P.Length; index++)
            {
                Console.Write($"{Apple_P[index]} " );
            }
            Console.WriteLine();
            Console.WriteLine("===============================");
            Console.WriteLine();

            for (int index1 = 0; index1 < Apple_P.Length; index1++)
            {
                for (int index2 = 0; index2 < Apple_P.Length - (index1 + 1); index2++)
                {
                    //              앞의값                         뒤의값 비교
                    if (Apple_P[index2] > Apple_P[index2 + 1])
                    {
                        //앞의 값 임시저장
                        Sortbubble = Apple_P[index2];
                        //뒤의 값 앞에 반영
                        Apple_P[index2] = Apple_P[index2 + 1];

                        //뒤의 값을 앞에 반영
                        Apple_P[index2 + 1] = Sortbubble;
                    }
                }
            }

            for (int index = 0; index < Apple_P.Length; index++)
            {
                Console.Write($"{Apple_P[index]} ");
            }
            Console.WriteLine();

            //----------------------먹은 순서대로 정렬 (어려운거) Merge start-----------------------//

            Random rad1 = new Random();
            int[] Apple_People = new int[6];

            bool retry = true;

            //중복제거
            while (retry)
            {
                for (int index = 0; index < Apple_People.Length; index++)
                {
                    Apple_People[index] = rad.Next(100, 1000 + 1);
                }

                for (int index1 = 0; index1 < Apple_People.Length; index1++)
                {
                    for (int index2 = index1 + 1; index2 < Apple_People.Length; index2++)
                    {
                        if (Apple_People[index1] == Apple_People[index2])
                        {
                            retry = true;
                            break;
                        }
                        else
                        {
                            retry = false;
                        }
                    }
                }
            }

            for (int index = 0; index < Apple_People.Length; index++)
            {
                Console.Write($"{Apple_People[index]} ");
            }
            Console.WriteLine();
            Console.WriteLine("===============================");
            Console.WriteLine();

            int[] Result_ = new int[6];

            int loopP = 1;
            int p = 0;
            int q = Apple_People.Length / 2;
            int r = Apple_People.Length;
            int Re = 0;

            while(true)
            {

            }



            while(true)
            {
                if (Apple_People[p] > Apple_People[q + loopP])
                {
                    Result_[Re] = Apple_People[q + loopP];
                    Re++;
                    loopP++;
                }
                else if(Apple_People[p] <= Apple_People[q + loopP])
                {
                    Result_[Re] = Apple_People[p];
                    Re++;
                    p++;
                }
            }

            Re = 0;
            int half = Apple_People.Length / 2;

            for (int index1 = 0; index1 < half; index1++)
            {
                for(int index2 = Apple_People.Length + 1; index2 < Apple_People.Length; index2++)
                {
                    //왼쪽이 오른쪽 보다 클때 (오른쪽 빼기)
                    if (Apple_People[index1] > Apple_People[index2])
                    {
                        //temp배열에 오른쪽 값 넣기
                        Result_[Re] = Apple_People[index2];
                        Re++;
                        break;
                    }
                    //오른쪽이 왼쪽보다 같거나 클때 (왼쪽 빼기)
                    else if (Apple_People[index1] <= Apple_People[index2])
                    {
                        Result_[Re] = Apple_People[index1];
                        Re++;
                        index1++;
                    }
                }
            }



            //while(true)
            //{
            //    for(int index = 0; index < middleNumber; index++)
            //    {
            //        if(Apple_People[index] > Apple_People[middleNumber + index]
            //    }
            //}


            //int SortData = minData;

            //int MaxSort = 0;
            //int minSort = 0;

            //for (int index = 0; index < people.Length; index++)
            //{
            //    if(SortData == people[index])
            //    {
            //        Console.Write($"{SortData}({index + 1}번째) ");
            //    }
            //}

            //int num = 0;
            //for(int i = 0; i < people.Length; i++)
            //{
            //    if (people[i] > SortData)
            //    {
            //        minSort = SortData;
            //        SortData = people[i];

            //        for (int j = 0; j < people.Length; j++)
            //        {
            //            if (minSort < people[j] && SortData > people[j])
            //            {
            //                num = j + 1;
            //                SortData = people[j];
            //            }
            //        }
            //        Console.WriteLine();
            //    }
            //}


            //-----------------사과 먹기 심화과정 (변형2 , 어려운거) start-------------------//

            //int[] people_ = new int[5];

            //for (int index = 0; index < people_.Length; index++)
            //{
            //    while (true)
            //    {
            //        int.TryParse(Console.ReadLine(), out people_[index]);



            //        if (0 < people_[index])
            //        {
            //            break;
            //        }
            //        Console.WriteLine("\t\t\t\t\t\t잘못된 입력 값입니다.");
            //    }
            //}

            //int[] maxDataNumber = new int[5];
            //int[] minDataNumber = new int[5];
            //int maxData = 0;
            //int minData = 0;
            //bool mindataCheck = false;
            //for (int index = 0; index < people.Length; index++)
            //{
            //    if (people[index] >= maxData)
            //    {
            //        if (people[index] == maxData)
            //        {
            //            maxDataNumber[index] = index + 1;
            //        }
            //        else
            //        {
            //            Array.Clear(maxDataNumber);
            //            maxDataNumber[index] = index + 1;
            //        }
            //        maxData = people[index];

            //        if (mindataCheck == false)
            //        {
            //            minData = maxData;
            //            mindataCheck = true;
            //        }
            //    }

            //    if (people[index] <= minData)
            //    {
            //        if (people[index] == minData)
            //        {
            //            minDataNumber[index] = index + 1;
            //        }
            //        else
            //        {
            //            Array.Clear(minDataNumber);
            //            minDataNumber[index] = index + 1;
            //        }
            //        minData = people[index];
            //    }
            //}

            //for (int index = 0; index < maxDataNumber.Length; index++)
            //{
            //    if (maxDataNumber[index] != 0)
            //    {
            //        Console.Write($"{maxDataNumber[index]} ");
            //    }
            //}

            //Console.WriteLine($"번째 사람이 사과를 : {maxData} 개로 제일 많이 먹습니다.");

            //for (int index = 0; index < minDataNumber.Length; index++)
            //{
            //    if (minDataNumber[index] != 0)
            //    {
            //        Console.Write($"{minDataNumber[index]} ");
            //    }
            //}

            //Console.WriteLine($"번째 사람이 사과를 : {minData} 개로 제일 적게 먹습니다.");


        }
    }
}