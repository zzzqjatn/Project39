// System 이라는 어셈블리에서 이것 저것 여러 기능을 가져와서 사용합니다.
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;

// 내 프로그램 이름이다 내가 정했다.
namespace WhatisArray
{
    // 클래스 라는 것인데, C#에서는 모든 요소들이 클래스 안에 있어야 함.
    internal class Program
    {
        // 무조건 1개는 있어야 함 -> C# 콘솔(검은 창,터미널,커멘드, 쉘 등등 OS 마다 다르다)을 사용할 때 (유니티에선 없다)
        static void Main(string[] args)
        {
            // 프로그램은 여기서부터 읽기 시작한다.
            //Console.WriteLine("Hello, World!");

            ////3의 배수를 제외한 수
            //int sumofNumber = 0;
            ////int variable_ = 100;

            //for(int variable_ = 1;  100 >= variable_; variable_++)
            //{
            //    //100번도는 루프
            //    bool isRealMultipleofThree = (variable_ % 3 == 0);
            //    Console.WriteLine("{0} is isRealMulipleofThree : {1}",
            //        variable_, isRealMultipleofThree);

            //    //1 ~ 100 숫자 중에서 3의 배수를 제외한 수의 합 구하기
            //    if (isRealMultipleofThree == false)
            //    {
            //        // 3의 배수가 아닌건 다 여기로 오겠네?
            //        // 여기서 값을 계속 더해주면 되겠네?
            //        sumofNumber += variable_;
            //        Console.WriteLine("잘 더해지고 있나? : {0}", sumofNumber);
            //    }
            //    else
            //    {
            //        //여기로 오겠네?
            //        //그러면 여기서 코딩해야지
            //    }
            //    Console.WriteLine();
            //}
            //// 루프가 끝나면 여기로 오니까 다 끝날 때까지는 더해서 마지막 값을 눈으로
            //// 보고 싶으니까
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("======================================");
            //Console.WriteLine(sumofNumber);
            //Console.WriteLine("======================================");

            ////어떤변수 = "강아지"
            ////if (/*여기서 조건문 검사함*/)
            ////{
            ////    // 저 조건문이 참(true)이면 여기로 옴
            ////    // 조건문은 여기서부터 읽기 시작한다.

            ////    Console.WriteLine("아 남자구나 ok");

            ////    // 조건문은 여기서 끝난다.
            ////}
            ////else
            ////{
            ////    // 저 조건문이 거짓(false)이면 여기로 옴.
            ////    // 조건문은 여기서부터 읽기 시작한다.

            ////    Console.WriteLine("아 남자 아닌가 보구나");

            ////    // 조건문은 여기서 끝난다.
            ////}

            //string personalGender = "여자";
            //if (personalGender.Equals("남자"))
            //{
            //    // 저 조건문A이 참(true)이면 여기로 옴
            //    // 조건문A은 여기서부터 읽기 시작한다.

            //    Console.WriteLine("아 남자구나 ok");

            //    // 조건문A은 여기서 끝난다.
            //}
            //else if (personalGender == "여자")
            //{
            //    // 저 조건문B이 참(true)이면 여기로 옴
            //    // 조건문B은 여기서부터 읽기 시작한다.

            //    Console.WriteLine("아 여자구나 ok");

            //    // 조건문B은 여기서 끝난다.
            //}
            //else
            //{
            //    // 저 조건문이 거짓(false)이면 여기로 옴.
            //    // 조건문은 여기서부터 읽기 시작한다.
            //    Console.WriteLine("아 남자도 여자도 아닌가 보구나");
            //    // 조건문은 여기서 끝난다.
            //}



            //// 조건문을 실행했으면 이제 다시 여기서부터 프로그램 시작한다.

            //for(int index = 1; index <= 20; index++)
            //{
            //    Console.WriteLine();
            //}
            //Console.WriteLine("정말로 콘솔이 정리됬었나?");

            //프로그램 사용자로부터 양의 정수를 하나 입력 받아서,
            //그 수 만큼 "Hello world!"를 출력하는 프로그램 작성
            //int someNumber = 100;
            //bool isPositiveInteger = (0 < someNumber);

            /*
             * 프로그램 사용자로부터 계속해서 정수를 입력받는다. 그리고 그 값을 계속해서 더해 나간다. 이러한 작업은
             * 프로그램 사용자가 0을 입력할 때까지 계속되어야 하며,
             * 0이 입력되면 입력된 모든 정수의 합을 출력하고 프로그램 종료.
             */
            //bool isNumberzero = (someNumber == 0);

            //// 프로그램 사용자로부터 입력 받은 숫자에 해당하는 구단을 출력하되,
            //// 역순으로 출력하는 프로그램을 작성.
            //int userInputNumber = 3;
            //for (int index = 9; index >= 1; index--)
            //{
            //    Console.WriteLine("{0} x {1} = {2}",
            //        userInputNumber, index, userInputNumber * index);
            //}       //loop: 9번을 도는 루프

            /*
             * 프로그램 사용자로부터 입력 받은 정수의 평균을 출력하는 프로그램을 작성하되,
             * 다음 두 가지의 조건을 만족할 것.
             * - 먼저 몇개의 정수를 입력할 것인지 프로그램 사용자에게 묻는다.
             * 그리고 그 수 만큼 정수를 입력받는다.
             * - 평균값은 소수점 아히까지 계산해서 출력한다.
             */

            /*
             * LAB1
             * 컴퓨터가 숨기고 있는 비밀코드를 추측하는 게임을 작성
             * 비밀 코드는 a~z 사이의 문자
             * 컴퓨터는 사용자의 추측을 읽고서 앞에 있는지, 뒤에 있는지를 알려준다
             * (즉 , 사용자에게 힌트를 준다)
             */

            ////char ScretCode = 'y';
            ////char userInputAlphabat = 'c';
            ////bool isSmallAlphabat =
            ////    ('a' <= userInputAlphabat && userInputAlphabat <= 'z');

            ////bool isAlphabatFore = (userInputNumber <= ScretCode);
            ////bool isAlphabatBack = (userInputNumber >= ScretCode);

            ////if (isSmallAlphabat) { /*Do nothing*/}
            ////else
            ////{
            ////    Console.WriteLine("{0} {1}",
            ////        "[System] 당신의 입력은 처리 할 수 없습니다.",
            ////        "알파벳 소문자만 입력해주세요.");
            ////}

            ////if (isAlphabatFore)
            ////{
            ////    Console.WriteLine("당신의 알파벳은 시크릿 코드보다 앞에 있다");
            ////}
            ////else { /*Do nothing*/}

            ////if (isAlphabatBack)
            ////{
            ////    Console.WriteLine("당신의 알파벳은 시크릿 코드보다 뒤에 있다");
            ////}
            ////else { /*Do nothing*/}

            ////// 1 ~ 100 숫자 중에서 3의 배수 이면서 4의 배수인 정수의 합 구하기
            ////int sumnumber = 0;
            ////int somenumber = 100;
            ////bool isMultipleofThree = (somenumber % 3 == 0);
            ////bool isMultipleofFour = (somenumber % 4 == 0);

            ////bool isSatisfycondition = isMultipleofThree && isMultipleofFour;

            ////if (isSatisfycondition)
            ////{
            ////    sumnumber += somenumber;
            ////}   // if: 3의 배수 이면서 4의 배수인 값

            ////// *gitignore 유니티도 있다

            ////// 별을 100번 찍는 법
            ////Console.WriteLine("{0} {1} {2} {3} {4}",
            ////    "******************", "******************", "******************", "******************", "******************");
            ////Console.WriteLine("{0} {1} {2} {3} {4}",
            ////    "******************", "******************", "******************", "******************", "******************");

            ////for(int index = 1; index <= 100; index++)
            ////{
            ////    Console.Write("{0} ", "*");
            ////}

            ////Console.WriteLine();
            ////Console.WriteLine();
            ////Console.WriteLine();
            ////Console.WriteLine();
            ////for (int index1 = 1; index1 <= 10; index1++)
            ////{
            ////    for (int index2 = 1; index2 <= 10; index2++)
            ////    {
            ////        Console.Write("{0} ", "*");
            ////    }       //loop: 이건 밖의 루프가 1번 도는 동안 10번을 도는 루프
            ////    Console.WriteLine();
            ////}       // loop : 10번을 도는 루프

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //int hundreadCount = 0;
            //for (int index1 = 1; index1 <= 10; index1++)
            //{
            //    for (int index2 = 1; index2 <= 10; index2++)
            //    {
            //        for (int index3 = 1; index3 <= 10; index3++)
            //        {
            //            hundreadCount++;
            //            if (hundreadCount > 100) { break; }
            //            else { /*Do nothing*/}

            //            //여기가 별을 찍는 지점
            //            Console.Write("{0} ", "*");

            //            //여기서 10번마다 한 줄을 띄어 줄거임
            //            if(hundreadCount % 10 == 0)
            //            {
            //                Console.WriteLine();
            //            }   //if: 별을 10번 찍을 때마다 한 줄 띄어주는 중

            //        }   //loop: 이건 1번 루프가 10번 도는 동안 2번 루프가 10번 돌고
            //            //그 동안 다시 10번을 도는 루프

            //    }       //loop: 이건 밖의 루프가 1번 도는 동안 10번을 도는 루프
            //}       // loop : 10번을 도는 루프

            /*
             * 
             * 유저 입력 받아서 (1~20 줄 이내로 입력 받음) 유저입력은 줄, 단의 개수임
                등차 수열로 한 단이 내려갈 때마다 별1개씩 추가로 증가하는 프로그램 작성
                EX)
                	userinput : 5
                *
                **
                ***
                ****
                *****
                
                어려운거 이번엔 마름모 형식으로입력
                3
                
                	*
                   ***
                    *
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             */

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //int UserInputData = 0;
            //int.TryParse(Console.ReadLine(), out UserInputData);

            //int loopCount = 1;

            //if (0 < UserInputData && UserInputData <= 20)
            //{
            //    for (int index1 = 1; index1 <= UserInputData; index1++)
            //    {
            //        for (int index2 = 1; index2 <= UserInputData; index2++)
            //        {
            //            Console.Write("{0}", "*");
            //            if (index2 >= loopCount) { break; }
            //            else { /*Do nothing*/}
            //        }
            //        Console.WriteLine();
            //        loopCount++;
            //    } // loop : 입력 값만큼 도는 루프
            //}
            //else { /*Do nothing*/}

            ////마름모
            //int.TryParse(Console.ReadLine(), out UserInputData);
            //loopCount = 1;

            //if (0 < UserInputData && UserInputData <= 20)
            //{
            //    //단
            //    for (int index1 = 1; index1 <= (UserInputData * 2); index1++)
            //    {
            //        //짝수 단 예외처리
            //        if (index1 % 2 != 0)
            //        {
            //            //여백
            //            for (int index3 = 1; index3 <= UserInputData; index3++)
            //            {
            //                //절반이 넘었을 때
            //                if (loopCount > UserInputData)
            //                {
            //                    //절반이 넘었으니 loopcount가 입력값보다 많다.
            //                    if (index3 > (loopCount - UserInputData)/ 2) break;
            //                    Console.Write(" ");
            //                }
            //                //절반 이전
            //                else
            //                {
            //                    //입력값 - loopcount(단 루프를 카운터한 수) 
            //                    if (index3 > (UserInputData - loopCount)/ 2) break;
            //                    Console.Write(" ");
            //                }
            //            }

            //            //줄
            //            for (int index2 = 1; index2 <= UserInputData; index2++)
            //            {
            //                //절반 넘었을때
            //                if (loopCount > UserInputData)
            //                {
            //                    if (index2 > UserInputData - (loopCount - UserInputData)) break;
            //                    Console.Write("{0}", "*");
            //                }
            //                //절반 이전
            //                else
            //                {
            //                    if (index2 > loopCount) break;
            //                    Console.Write("{0}", "*");
            //                }
            //            }
            //            Console.WriteLine();
            //        }
            //        loopCount++;
            //    } // loop : 유저 입력 값만큼 도는 루프 (단)
            //}
            //else { /*Do nothing*/}

            ///////
            ///숫자야구
            //컴퓨터가 랜덤한 3자리 수를 같고 있고
            /*
             * 
             * 자리와 숫자가 맞으면 스트라이크
             * 숫자만 맞으면 볼
             * 
             * 맥시멈 9번
             * 
             * 
             * 100의 자리수 100 나누기 10나누기 나머지값
             * 
             * equl
            // */
            //Random rands = new Random();
            //int zoneOne = 0, zoneTwo = 0, zoneThree = 0;
            //int userOne = 0, userTwo = 0, userThree = 0; 

            ////userinput
            //int BallCount = 0, strikeCount = 0;

            //bool isRight = false;   //정답확인용
            //bool isvalueCheck = false;
            //bool issameCheck = false;

            ////숫자 3자리 뽑기
            //bool NumberCheck = false;
            //zoneOne = rands.Next(0, 9 + 1);
            //while (true)
            //{
            //    if (NumberCheck == false)
            //    {
            //        zoneTwo = rands.Next(0, 9 + 1);

            //        if (zoneTwo != zoneOne)
            //        {
            //            NumberCheck = true;
            //        }
            //    }
            //    else
            //    {
            //        zoneThree = rands.Next(0, 9 + 1);

            //        if (zoneThree != zoneOne && zoneThree != zoneTwo)
            //        {
            //            break;
            //        }
            //    }
            //}
            //Console.WriteLine($"숫자는 {zoneOne},{zoneTwo},{zoneThree}");  //숫자확인
            //Console.WriteLine("숫자야구게임입니다. 9번의 기회가 있습니다.");

            //for (int MaxCount = 9; MaxCount >= 1; MaxCount--)
            //{
            //    BallCount = 0;
            //    strikeCount = 0;

            //    Console.WriteLine($"{MaxCount}번째 남았습니다.");

            //    //유효성검사
            //    while (true)
            //    {
            //        Console.Write("숫자 첫번째를 입력해 주십시오 : ");
            //        int.TryParse(Console.ReadLine(), out userOne);

            //        Console.Write("숫자 두번째를 입력해 주십시오 : ");
            //        int.TryParse(Console.ReadLine(), out userTwo);

            //        Console.Write("숫자 세번째를 입력해 주십시오 : ");
            //        int.TryParse(Console.ReadLine(), out userThree);

            //        if (0 > userOne || userOne >= 10)
            //        {
            //            Console.WriteLine("\t\t 첫번째 값이 예상범위 값 밖에 있습니다.");
            //        }

            //        if (0 > userTwo || userTwo >= 10)
            //        {
            //            Console.WriteLine("\t\t 두번째 값이 예상범위 값 밖에 있습니다.");
            //        }

            //        if (0 > userThree || userThree >= 10)
            //        {
            //            Console.WriteLine("\t\t 세번째 값이 예상범위 값 밖에 있습니다.");
            //        }

            //        if ((0 <= userOne && userOne < 10) && (0 <= userTwo && userTwo < 10) && (0 <= userThree && userThree < 10))
            //        {
            //            isvalueCheck = true;
            //        }


            //        if (userThree == userOne)
            //        {
            //            Console.WriteLine("\t\t 첫번째 와 세번째 값이 중복됩니다.");
            //        }

            //        if (userThree == userTwo)
            //        {
            //            Console.WriteLine("\t\t 두번째 와 세번째 값이 중복됩니다.");
            //        }

            //        if (userTwo == userOne)
            //        {
            //            Console.WriteLine("\t\t 첫번째 와 두번째 값이 중복됩니다.");
            //        }

            //        if ((userThree != userOne && userThree != userTwo) && userOne != userTwo)
            //        {
            //            issameCheck = true;
            //        }

            //        if (isvalueCheck && issameCheck) break;

            //    }



            //    //스트라이크 체크
            //    if (userOne == zoneOne)
            //    {
            //        strikeCount++;
            //    }
            //    else if (userTwo == zoneTwo)
            //    {
            //        strikeCount++;
            //    }
            //    else if (userThree == zoneThree)
            //    {
            //        strikeCount++;
            //    }

            //    if (userOne == zoneOne && userTwo == zoneTwo && userThree == zoneThree)
            //    {
            //        isRight = true;
            //        break;
            //    }

            //    //볼값 체크
            //    //유저1값이 컴퓨터1값이 다르고 나머지랑 같을 때
            //    if (userOne != zoneOne && userOne == zoneTwo ||
            //        userOne != zoneOne && userOne == zoneThree)
            //    {
            //        BallCount++;
            //    }

            //    //유저2값이 컴퓨터2값이 다르고 나머지랑 같을 때
            //    if (userTwo != zoneTwo && userTwo == zoneOne ||
            //        userTwo != zoneTwo && userTwo == zoneThree)
            //    {
            //        BallCount++;
            //    }

            //    //유저3값이 컴퓨터3값이 다르고 나머지랑 같을 때
            //    if (userThree != zoneThree && userThree == zoneTwo ||
            //        userThree != zoneThree && userThree == zoneOne)
            //    {
            //        BallCount++;
            //    }
            //    Console.WriteLine($"볼 : {BallCount}, 스트라이크 : {strikeCount}");
            //}
            ////그냥 끝났는지 맞춰서 끝났는지 확인을 위해서
            //if (isRight)
            //{
            //    Console.WriteLine($"정답입니다. 숫자는 {zoneOne},{zoneTwo},{zoneThree}");
            //}
            //else
            //{
            //    Console.WriteLine($"모든 기회를 소진하였습니다 \n오답입니다. 숫자는 {zoneOne},{zoneTwo},{zoneThree}");
            //}

            ///////////----------------------------------------------------------------------------------------//////////

            //string st = Console.ReadLine();

            //char[] ct = new char[3];
            //string[] tempst = st.Split(',');

            //for(int i = 0; i < 3; i++)
            //{
            //    ct[i] = Convert.ToChar(tempst[i]);
            //}

            //Console.WriteLine($"{ct[0]}, {ct[1]}, {ct[2]}");

            //Random rd = new Random();
            //int[] zone = new int[3];

            //zone[0] = rd.Next(0, 9 + 1);
            //while (true)
            //{
            //    zone[1] = rd.Next(0, 9 + 1);
            //    if (zone[0] != zone[1])
            //    {
            //        if (zone[1] != zone[2] && zone[0] != zone[2])
            //        {
            //            break;
            //        }
            //    }
            //}
            //Console.WriteLine($"{zone[0]}, {zone[1]}, {zone[2]}");

            Random rd = new Random();

            int ballnumber1, ballnumber2, ballnumber3;
            int mynumber1, mynumber2, mynumber3;

            int BallCount = 0;
            int StrikeCount = 0;
            int life = 9;


            //랜덤값 받기
            while (true)
            {
                int RandomNum = rd.Next(0, 999);

                ballnumber1 = RandomNum / 100;
                ballnumber2 = (RandomNum - (100 * ballnumber1)) / 10;
                ballnumber3 = RandomNum % 10;

                if (ballnumber1.Equals(ballnumber2) || ballnumber1.Equals(ballnumber3) || ballnumber2.Equals(ballnumber3))
                {
                    Console.WriteLine("중복값 에러 발생");
                    continue;
                }
                else break;
            }
            Console.WriteLine($"{ballnumber1}, {ballnumber2}, {ballnumber3}");


            while (true)
            {
                Console.WriteLine($"현재 기회 : {life}");
                //사용자 입력값 받기 오류처리
                while (true)
                {
                    int InputNum;
                    int.TryParse(Console.ReadLine(), out InputNum);

                    if (10 > (InputNum / 100) && InputNum >= 0)
                    {
                        mynumber1 = InputNum / 100;
                        mynumber2 = (InputNum - (100 * mynumber1)) / 10;
                        mynumber3 = InputNum % 10;

                        if (mynumber1.Equals(mynumber2) || mynumber1.Equals(mynumber2) || mynumber2.Equals(mynumber3))
                        {
                            Console.WriteLine("중복값 에러 발생");
                            continue;
                        }
                        else break;
                    }
                    Console.WriteLine("잘못된 범위 밖 값 입니다");
                }

                if (life <= 1)
                {
                    Console.WriteLine("소진된 기회를 다 사용하셨습니다.");
                    break;
                }
                else if(ballnumber1.Equals(mynumber1) && ballnumber2.Equals(mynumber2) && ballnumber3.Equals(mynumber3))
                {
                    Console.WriteLine("정답입니다.");
                    break;
                }

                BallCount = 0;
                StrikeCount = 0;

                if (ballnumber1.Equals(mynumber1))
                {
                    StrikeCount++;
                }

                if (ballnumber2.Equals(mynumber2))
                {
                    StrikeCount++;
                }

                if (ballnumber3.Equals(mynumber3))
                {
                    StrikeCount++;
                }

                if (ballnumber1 != mynumber1 && ballnumber2.Equals(mynumber1) || 
                    ballnumber1 != mynumber1 && ballnumber3.Equals(mynumber1))
                {
                    BallCount++;
                }

                if (ballnumber2 != mynumber2 && ballnumber1.Equals(mynumber2) ||
                    ballnumber2 != mynumber2 && ballnumber3.Equals(mynumber2))
                {
                    BallCount++;
                }

                if (ballnumber3 != mynumber3 && ballnumber1.Equals(mynumber3) ||
                    ballnumber3 != mynumber3 && ballnumber2.Equals(mynumber3))
                {
                    BallCount++;
                }
                Console.WriteLine($"BALL : {BallCount}, STRIKE : {StrikeCount}");
                life--;
            }
            Console.WriteLine($"{ballnumber1}, {ballnumber2}, {ballnumber3}");


            /*
             * 컬렉션
             * 이름 하나로 데이터 여러 개를 담을 수 있는 자료 구조를 컬렉션(Collection) 또는
             * 컨테이너(Container) 라고 한다. C# 에서 다루는 컬랙션은 배열 (Array), 리스트(List),
             * 사전(Dictinary) 등이 있다.
             * 
             * 배열
             * 배열(Array)은 같은 종류의 데이터를 순차적으로 메모리에 저장되는 자료 구조이다. 각각의 데이터들은
             * 인덱스(번호)를 사용하여 독립적으로 접근된다. 배열을 사용하면 편리하게 데이터를 모아서 관리할 수있다.
             * 
             * 배열의 특징들
             * 1. 배열 하나에는 데이터 형식 한 종류만 보관할 수 있다.
             * 2. 배열은 메모리의 연속된 공간을 미리 할당하고, 이를 대괄호 ([])와 0부터 시작하는 정수형 인덱스를
             *    사용하여 접근할 수 있다.
             * 3. 배열을 선언할 때는 new 키워드로 배열을 생성한 후 사용할 수 있다.
             * 4. 배열에서 값 하나는 요소(Element) 또는 항목(Item)으로 표현한다.
             * 5. 필요한 데이터 개수를 정확히 정한다면 메모리를 적게 사용하여 프로그램 크기가 작아지고 성능이 향상된다.
             * 
             * 배열에는 세가지 종류가 있다.
             * 1차원 배열 : 배열의 첨자를 하나만 사용하는 배열
             * 다차원 배열 : 첨자 2개이상을 사용하는 배열 (2차원,3차원, ..., n차원 배열)
             * 가변(Jagged) 배열 : '배열의 배열'이라고 하며, 이름 하나로 다양한 차원의 배열을 표현할때 사용한다.
             */


            //배열의 선언과 초기화
            //int[] numbers = new int[5] { 1, 2, 3, 4, 5 };

            ////numbers.Length
            //Console.WriteLine(numbers[numbers.Length - 1]);

            //for(int index = 0; index < numbers.Length; index++)
            //{
            //    Console.WriteLine("{0} ",numbers[index]);
            //}

            //foreach(int element in numbers)
            //{
            //    Console.WriteLine("{0} ", element);
            //}

            //int number1 = 1;
            //int number2 = 2;
            //int number3 = 3;
            //int number4 = 4;
            //int number5 = 5;

            //Console.WriteLine(numbers);

            // 프로그램은 여기서 끝난다.




            //----------22.12.22----------
            //모드 연산자

            int number = 1_0821;
            Console.WriteLine("64로 Mod 연산 {0}", number % 64);
        }
    }
}