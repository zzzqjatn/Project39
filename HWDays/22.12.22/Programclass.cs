using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatisArray2
{
    internal class Programclass
    {
        static void Main(string[] args)
        {
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

            /* 풀이 로직
             * 난수가 들어있는 100개의 배열에서 MaxData 라는 정수형 변수를 이용하여
             * MaxData 값을 난수 값들 과 비교 하며 가장 큰값을 계속 찾아 갱신, 중복값의 경우 새로운 정수형 배열 100개를
             * 통해 순번(index) 부분만 데이터로 넣고 추후에 큰값이 갱신 되었을 경우
             * Array.clear 메서드를 통해 배열 데이터를 초기화하고 새롭게 중복값을 적재합니다.
             */


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
                    Console.Write($"{MaxDataNumber[index]} ");  //가장 큰수 중복 값 번호
                }
            }
            Console.WriteLine($"번째 데이터 : {MaxData} 이 제일 큽니다");  // 가장 큰수 보여주는 출력문

            //-----------------사과 제일 좋아하는 사람 start-------------------//
            //(기본형, 변형1)

            /* 풀이 로직
             * (기본형,변형1)
             * 사람 (people[5]) 5명 분의 배열. maxDataNumber,minDataNumber 변수로 큰값, 작은 값에 대한 중복값 순번 보여주기용 배열 선언
             * 
             * 입력을 통한 tryparse 예외처리를 통해 양의 정수값을 입력받습니다.
             * 가장 큰 값(maxData), 적은 값(minData)을 위한 변수를 통해 계속 값을 갱신하며 가져옵니다.
             */

            int[] people = new int[5];  //각각 먹은 사과의 수를 입력받을 배열

            for (int index = 0; index < people.Length; index++)    //입력을 위한 반복문
            {
                while (true)   //입력 및 잘못 입력된 예외처리 반복문 
                {
                    //tryparse 잘못된 입력(문자 및 특수기호, 0 이하의 숫자 예외처리)이 있으면 false로 반환해준다.
                    if (int.TryParse(Console.ReadLine(), out people[index]))    //정수형이 맞으면
                    {
                        if (people[index] >= 0)  //입력 정수 값 중에서도 양의 정수만
                        {
                            break;  //while문 탈출
                        }
                    }
                    Console.WriteLine("\t\t\t\t\t\t잘못된 입력 값입니다.");  //예외 값 입력 안내문
                }
            }
            //                     배열 전체 값 초기화 (값,배열수) (초기값 -1은 0이하의 수가 없기 때문에)
            int[] maxDataNumber = new int[5];  //최대 중복 값 표현을 위한 순번 배열
            int[] minDataNumber = new int[5];  //최소 중복 값 표현을 위한 순번 배열
            int maxData = 0;        //가장 많이 먹은 사람의 사과 수
            int minData = 0;        //가장 적게 먹은 사람의 사과 수
            bool mindataCheck = false;  //가장 적게 먹은 사람 사과 수(minData)를 초기에 가장 많이 먹은 사람의 사과 수로 대입 후 넘어가기 위한 변수
            for (int index = 0; index < people.Length; index++) //중복값 순번 적재를 위한 반복문
            {
                if (people[index] >= maxData)   //만약 현재 가장 많이 먹은 사과수가 지금 인덱스의 사람이 먹은 수 와 같거나 크다면
                {
                    if (people[index] == maxData) //같다면
                    {
                        maxDataNumber[index] = index + 1;   //순번만 적재
                    }
                    else                                    //만약 크다면
                    {
                        Array.Clear(maxDataNumber);         //배열 초기화 (가장 큰값이 갱신됬기 때문에 이전 중복값은 초기화로 제거한다)
                        maxDataNumber[index] = index + 1;   //순번 적재 
                    }
                    maxData = people[index];                //가장 큰값 갱신

                    if (mindataCheck == false)              //적게먹은 사람이 초기 값이 없다면 minData = 0 이라면
                    {
                        minData = maxData;                  //가장 큰값을 minData 에 대입
                        mindataCheck = true;                //초기 값 설정을 마쳤으니 true로, 앞으로의 for문에선 넘어가기
                    }
                }

                if (people[index] <= minData)               //현재 값이 최저값보다 작거나 같다면
                {
                    if (people[index] == minData)           //갇다면
                    {
                        minDataNumber[index] = index + 1;   //순번만 적재
                    }
                    else                                    //작다면
                    {
                        Array.Clear(minDataNumber);         //배열 초기화(가장 적은 값이 갱신됬기 때문)
                        minDataNumber[index] = index + 1;   //순번 적재
                    }
                    minData = people[index];                //가장 작은값 갱신
                }
            }

            Console.WriteLine();    //가독성을 위한 문장
            for (int index = 0; index < maxDataNumber.Length; index++)  //가장 큰값의 중복된 순번 보여주기 위한 반복문
            {
                if (maxDataNumber[index] != 0)      //배열에 값이 들어있다면 (0은 배열의 초기값이고 순번엔 0의 번째가 없기때문에)
                {
                    Console.Write($"{maxDataNumber[index]} ");  //큰값 순번 출력문
                }
            }
            Console.WriteLine($"번째 사람이 사과를 : {maxData} 개로 제일 많이 먹습니다.");    //가장많이 먹은 갯수 출력문

            for (int index = 0; index < minDataNumber.Length; index++)   //가장 작은 값의 중복된 순번 보여주기 위한 반복문
            {
                if (minDataNumber[index] != 0)      //배열에 값이 들어있다면
                {
                    Console.Write($"{minDataNumber[index]} ");  //작은 값 순번 출력문
                }
            }
            Console.WriteLine($"번째 사람이 사과를 : {minData} 개로 제일 적게 먹습니다.");    //작은 값 순번 출력문
            Console.WriteLine();    //가독성을 위한 출력문

            //----------------------먹은 순서대로 정렬 (변형2) 버블 정렬 start-----------------------//

            /*
             * 풀이 로직
             * Apple_P 사람 배열을 만들고 100 ~ 1000 범위의 난수를 적재
             * 
             * 중복제거 반복문을 통해 앞의 한 배열을 잡고 차례대로 뒷 배열의 수를 비교
             * 같은 방식으로 확인합니다.
             * 
             * 난수로 넣은 값을 초기에 보여주고 버블 정렬을 통해 정렬된 배열을 보여줍니다
             * 
             */


            Random rad = new Random();  //랜덤클래스 생성

            int Sortbubble = 0;         //버블 정렬 시 값변경을 위한 임시 정수 변수

            int[] Apple_P = new int[5]; //사람의 수만큼 배열 선언
            bool Retry = true;          //중복제거에 관한 끝 마침에 대한 변수

            Console.WriteLine("버블 정렬"); //가독성을 위한 출력문
            //중복제거
            while (Retry)   //중복제거 반복문
            {
                for (int index = 0; index < Apple_P.Length; index++) //사람의 수만큼 반복문 
                {
                    Apple_P[index] = rad.Next(100, 1000 + 1);   //난수값 100 ~ 1000 값을 적재
                }

                //중복확인
                for (int index1 = 0; index1 < Apple_P.Length; index1++)  //사람의 수만큼 반복문
                {
                    for (int index2 = index1 + 1; index2 < Apple_P.Length; index2++) //첫 반복문의 바로 뒤부터의 반복문 (앞의 반복문 index1값이 커질수록 index2의 초기값이 줄어 반복문이 줄어든다)
                    {
                        if (Apple_P[index1] == Apple_P[index2]) //첫반복문의 배열 index1 값을 가져와 다음 index2 (계속 갱신) 의 값과 비교하여 같다면 (배열의 앞의 한자리와 뒷자리를 차례대로 비교)
                        {
                            Retry = true;   //중복문 다시시도
                            break;          //중복이니 for문 탈출하여 다시 맨위로
                        }
                        else
                        {
                            Retry = false;  //중복문이 없으니 끝 (모든 수(5개의 난수)가 모두 체크시 false가 되어야 중복제거 반복문을 나올 수 있다.)
                        }
                    }
                }
            }

            for (int index = 0; index < Apple_P.Length; index++)    //초기 적재된 정리되지 않은 배열 출력을 위한 반복문
            {
                Console.Write($"{Apple_P[index]} ");   //배열 출력문
            }
            Console.Write("버블 정렬 전"); //가독성을 위한 출력문
            Console.WriteLine();    //가독성을 위한 출력문
            Console.WriteLine("====================================");   //가독성을 위한 출력문

            //버블 정렬
            for (int index1 = 0; index1 < Apple_P.Length; index1++) //배열 앞의 값을 위한 반복문
            {
                for (int index2 = 0; index2 < Apple_P.Length - (index1 + 1); index2++)  //배열 뒤의 값을 위한 반복문
                {
                    //     앞의값               뒤의값 비교
                    if (Apple_P[index2] > Apple_P[index2 + 1])
                    {
                        //앞의 값 임시저장
                        Sortbubble = Apple_P[index2];
                        //뒤의 값 앞에 반영
                        Apple_P[index2] = Apple_P[index2 + 1];

                        //임시저장한 앞의 값을 뒤에 반영
                        Apple_P[index2 + 1] = Sortbubble;
                    }
                }
            }

            for (int index = 0; index < Apple_P.Length; index++)    //정렬된 배열 출력을 위한 반복문
            {
                Console.Write($"{Apple_P[index]} ");    //배열 출력문
            }
            Console.Write("버블 정렬 후"); //가독성을 위한 출력문
            Console.WriteLine();    //가독성을 위한 출력문
            Console.WriteLine();    //가독성을 위한 출력문

            //----------------------먹은 순서대로 정렬 (어려운거) Merge start-----------------------//
            /*(미완성)
             * 풀이 로직
             * Apple_People 사람 배열을 만들고 100 ~ 1000 범위의 난수를 적재
             * 
             * 중복제거 반복문을 통해 앞의 한 배열을 잡고 차례대로 뒷 배열의 수를 비교
             * 같은 방식으로 확인합니다.
             * 
             * 난수로 넣은 값을 초기에 보여주고 Merge sort 정렬을 통해 정렬된 배열을 보여줍니다
             * 
             */

            Random RAD = new Random();  //랜덤 클래스 생성
            int[] Apple_People = new int[5];    //사람 수에 따른 배열

            bool retry = true;      //완전히 중복체크가 완료 되었는지 비교

            //중복제거
            while (retry)   //중복제거 반복문
            {
                for (int index = 0; index < Apple_People.Length; index++)   //난수 적재용 반복문
                {
                    Apple_People[index] = RAD.Next(100, 1000 + 1);  //난수 (100 ~ 1000) 적재문
                }

                for (int index1 = 0; index1 < Apple_People.Length; index1++)    //첫번째 비교문에 대한 반복문
                {
                    for (int index2 = index1 + 1; index2 < Apple_People.Length; index2++)   //두번째 비교문에 관한 반복문
                    {
                        if (Apple_People[index1] == Apple_People[index2])   //중복값여부체크 첫번째 비교문을 첫번째 제외 나머지와 모두 비교 후 한 단계올라
                                                                            //두번째문을 첫번째,두번째 제외 나머지 와 모두 비교 이하 반복
                        {
                            retry = true;   //중복값이 있음
                            break;  //for문 탈출하여 난수 입력부터 다시하기
                        }
                        else
                        {
                            retry = false;  //중복값이 없음, 이후 모든 값을 돌아도 없을 경우 중복제거 반복문 탈출 
                        }
                    }
                }
            }
            Console.WriteLine("Merge sort 정렬"); //가독성을 위한 출력문
            for (int index = 0; index < Apple_People.Length; index++)   //정렬 되기전 배열 출력문
            {
                Console.Write($"{Apple_People[index]} "); //배열 출력문
            }
            Console.WriteLine("Merge sort 정렬 전"); //가독성을 위한 출력문
            Console.WriteLine("==============================="); //가독성을 위한 출력문
            Console.WriteLine(); //가독성을 위한 출력문

            //Merge sort 문

            /*
             * 현재 절반으로 구분하여 앞의값(왼쪽) 뒤의값(오른쪽)을 비교하여 새로운 배열에 적재하는 부분까진 만들었습니다.
             * 
             * 미완성 부분은 절반을 구분하는 것을 반복해서 계속 구분 후 왼쪽 오른쪽 비교 적재 하는 부분을 만들지 못했습니다.
             */

            int[] Result_ = new int[5]; // 정렬한 값을 새로 받을 값 배열
            int Re = 0;     //적재될 순번 값
            int half = Apple_People.Length / 2;     //중간지점 정수 변수

            for (int index1 = 0; index1 < half; index1++)   //절반 앞의 부분 반복문
            {
                for (int index2 = Apple_People.Length + 1; index2 < Apple_People.Length; index2++)  //절반 뒤의 부분 반복문
                {
                    //왼쪽이 오른쪽 보다 클때 (오른쪽 빼기)
                    if (Apple_People[index1] > Apple_People[index2])
                    {
                        //새로운 배열에 오른쪽 값 넣기
                        Result_[Re] = Apple_People[index2];
                        Re++;   //순번 값 올리기
                        break;
                    }
                    //오른쪽이 왼쪽보다 같거나 클때 (왼쪽 빼기)
                    else if (Apple_People[index1] <= Apple_People[index2])
                    {
                        //새로운 배열에 왼쪽 값 넣기
                        Result_[Re] = Apple_People[index1];
                        Re++;   //순번 값 올리기
                        index1++;   //앞의값(왼쪽) 순번 올리기
                    }
                }
            }
        }
    }
}
