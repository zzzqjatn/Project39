using System;
using System.Runtime.InteropServices;

namespace Switch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             * 선택문인 Switch 문은 값에 따라 다양한 제어를 처리 할 수 있다. 조건을 처리할 내용이 많은 경우 유용하다.
             * switch, case, default 키워드를 사용하여 조건을 처리한다.
             */

            //Console.Write("정수 1, 2, 3 중에 하나를 입력하시오 : ");
            //int switchNumber = 0;
            //int.TryParse(Console.ReadLine(), out switchNumber);

            //switch(switchNumber) 
            //{
            //    case 1:
            //        Console.WriteLine("1을(를) 입력했습니다");
            //        break;
            //    case 2:
            //        Console.WriteLine("2을(를) 입력했습니다");
            //        break;
            //    case 3:
            //        Console.WriteLine("3을(를) 입력했습니다");
            //        break;
            //    case 4:
            //    case 5:
            //        Console.WriteLine("4 or 5을(를) 입력했습니다");
            //        break;
            //    case 6:
            //        Console.WriteLine("3점프가 되었습니다.");
            //        goto case 3;        //이런 기능도 있다. 이걸 쓰면 좋은 로직은 아니다.
            //    default:
            //        Console.WriteLine("처리하지않은 예외 입력입니다.");
            //        break;
            //}       //switch

            /*
             *  02.5 중간점검
             *  1. case 절에서 break문을 생략하면 어떻게 되는가?
             *  제어불가능 에러가 뜸, 아래 case 내용이 없다면 아래 case문과 합쳐짐
             */

            //Console.WriteLine("가장 좋아하는 프로그래밍 언어는 ? ");
            //Console.WriteLine("1. C\t");
            //Console.WriteLine("2. C++\t");
            //Console.WriteLine("3. C#\t");
            //Console.WriteLine("4. Java\t");

            //int choice = Convert.ToInt32(Console.ReadLine());

            //switch(choice)
            //{
            //    case 1:
            //        Console.WriteLine("C 선택");
            //        break;
            //    case 2:
            //        Console.WriteLine("C++ 선택");
            //        break;
            //    case 3:
            //        Console.WriteLine("C# 선택");
            //        break;
            //    case 4:
            //        Console.WriteLine("Java 선택");
            //        break;
            //    default:
            //        Console.WriteLine("[system] 처리하지 않은 예외 입력입니다.");
            //        break;
            //}       //switch

            //Console.WriteLine("오늘의 날씨는 어떤가요? (맑음,흐림,비,눈, ...)");
            //string weather = Console.ReadLine();

            //switch(weather)
            //{
            //    case "맑음":
            //        Console.WriteLine("오늘은 날씨가 맑습니다.");
            //        break;
            //    case "흐림":
            //        Console.WriteLine("오늘은 날씨가 흐림니다.");
            //        break;
            //    case "비":
            //        Console.WriteLine("오늘은 비가 옵니다.");
            //        break;
            //    case "눈":
            //        Console.WriteLine("오늘은 눈이 옵니다.");
            //        break;
            //    default:
            //        Console.WriteLine("[system] 예외처리 값입니다.");
            //        break;
            //}     //switch

            // while 문은 조건식이 참일 동안 문장을 반복 실행한다.

            //// while 문은 반복문인데 5번 실행할 예정
            //int loopCounter = 0;

            //while (loopCounter < 5)
            //{
            //    Console.WriteLine("{0}반복문이 5번 실행될까?",loopCounter + 1);
            //    loopCounter++;
            //}

            ////10 ~ 1 카운트 후 발사 출력하는 프로그램 작성
            //loopCounter = 10;
            //while(loopCounter > 0)
            //{
            //    Console.WriteLine("{0} 카운트", loopCounter);
            //    loopCounter -= 1;
            //}
            //Console.WriteLine("발사");

            // 예제 #1 - 구구단 출력하는 프로그램 작성. user input 받아서 해당 단을 출력
            //int GuGuDanInput = 0;
            //Console.WriteLine("구구단에서 출력하고 싶은 단 입력 : ");
            //int.TryParse(Console.ReadLine(), out GuGuDanInput);

            //const int GUGU_LOOP_COUNT = 9;
            //int GuGuLoopIdx = 1;

            //while(GuGuLoopIdx <= GUGU_LOOP_COUNT)
            //{
            //    Console.WriteLine("{0} x {1} = {2}", GuGuDanInput, GuGuLoopIdx, GuGuDanInput * GuGuLoopIdx);
            //    GuGuLoopIdx++;
            //}

            /*
             * 문제1
             * 프로그램 사용자로부터 양의 정수 하나를 입력받아서, 그 수 만큼 "Hello world"를 출력받는 프로그램 작성
             * EX)
             *      userInput -> 3
             *          "hello world"
             *          "hello world"
             *          "hello world"
             *          
             * 문제2
             * 프로그램 사용자로부터 양의 정수를 하나 입력 받은 다음, 그 수 만큼 3의 배수 출력하는 프로그램 작성
             * EX)
             *      userinput -> 3
             *      "3,6,9,12,15"
             *      
             * 문제3
             * 프로그램 사용자로부터 계속해서 정수를 입력받는다 그리고 값을 계속해서 더해 나간다.
             * 이러한 작업은 프로그램 사용자가 0을 입력받을 때까지 계속 되어야 하며, 0이 입력되면 입력된 모든 정수의
             * 합을 출력하고 프로그램 종료
             * EX)
             *      userInput -> 1
             *      userInput -> 10
             *      userInput -> 11
             *      "모든 정수의 합은 11"
             *      
             * 문제4
             * 프로그램 사용자로부터 입력받은 숫자에 해당하는 구구단을 출력하되, 역순으로 출력하는 프로그램을 작성
             * EX)
             *      userinput -> 2
             *      "18, 16, 14, 12, 10, 8, 6, 4, 2"
             *      
             * 문제5
             * 프로그램 사용자로부터 입력 받은 정수의 평균을 출력하는 프로그램을 작성하되, 다음 두가지의 조건을 만족 할것
             *  - 조건 : 먼저 몇 개의 정수를 입력할 것인지 프로그램 사용자에게 묻는다
             *          그리고 그 수 만큼 정수를 입력받는다.
             *          -평균 값은 소수점 이하까지 계산해서 출력한다.
             * EX)  userinput(loopCount) -> 3
             *      userinput - > 10
             *      userinput - > 10
             *      userinput - > 10
             *      "평균 값: 10.0"
             */
            //////1번문제
            //int InputCounter = 0;

            //Console.Write("Hello World!를 반복할 수를 입력해주세요 : ");
            //int.TryParse(Console.ReadLine(), out InputCounter);

            //if(InputCounter <= 0)
            //{
            //    Console.WriteLine("양의 정수를 입력해주세요."); 
            //}
            //else
            //{
            //    while(InputCounter > 0)
            //    {
            //        Console.WriteLine("Hello World!");
            //        InputCounter -= 1;
            //    }
            //}
            //////2번문제
            //int mulNumber = 0;
            //Console.Write("\n원하시는 값의 3의 배수 값을 출력해 드립니다 : ");
            //int.TryParse(Console.ReadLine(), out mulNumber);

            //if(mulNumber <= 0)
            //{
            //    Console.WriteLine("양의 정수를 입력해주세요");
            //}
            //else
            //{
            //    int loopCounter = 0;
            //    while(loopCounter < 5)
            //    {
            //        Console.Write("{0}", mulNumber * (loopCounter + 1));
            //        loopCounter++;
            //        if(5 != loopCounter) Console.Write(",");
            //    }
            //}
            //////3번문제
            //int keepInputData = 0, CheckData = 1, resultSumData = 0;

            //Console.WriteLine("\n\n정수를 계속 합산하는 프로그램입니다.(0을 입력전까지 합산합니다)");
            //while (CheckData != 0)
            //{
            //    Console.Write("정수를 입력해주세요 : ");
            //    int.TryParse(Console.ReadLine(), out keepInputData);

            //    resultSumData += keepInputData;

            //    if (keepInputData == 0) CheckData = 0;
            //}
            //Console.WriteLine("모든 정수의 합 : {0}", resultSumData);
            //////4번문제
            //Console.Write("\n구구단 역순, 숫자를 입력해주세요 : ");
            //int guguDanInput = 0;
            //int gugu_loopCounter = 9;
            //int.TryParse(Console.ReadLine(), out guguDanInput);

            //while(gugu_loopCounter > 0)
            //{
            //    Console.Write("{0}", guguDanInput * gugu_loopCounter);
            //    gugu_loopCounter--;
            //    if (gugu_loopCounter != 0) Console.Write(",");
            //}
            ////// 5번문제
            //int userinputcounter = 0;
            //float userInputData, ResultTemp = 0.0f, counterTemp = 0.0f;

            //Console.Write("\n\n몇 개의 정수를 입력받으시겠습니까? : ");
            //int.TryParse(Console.ReadLine(), out userinputcounter);

            //counterTemp = userinputcounter;

            //while (userinputcounter > 0)
            //{
            //    Console.Write("정수를 입력하시오 : ");
            //    float.TryParse(Console.ReadLine(), out userInputData);
            //    ResultTemp += userInputData;
            //    userinputcounter--;
            //}
            //Console.WriteLine("평균 값 : {0}", ResultTemp / counterTemp);
            //////

            //const float FLOAT_VALUE = 0.1F;
            //float sumofFloatvalue = 0.0f;
            //int loopCount = 10;

            //while(0 < loopCount)
            //{
            //    sumofFloatvalue += FLOAT_VALUE;
            //    loopCount--;
            //}   // loop 10번 돈다
            //Console.WriteLine("{0}",sumofFloatvalue);

            //두 실수를 입력받아서 값이 같은지 다른지 출력하는 프로그램 작성 (Equal 등 메서스 사용 X)

            //float InputAtype = 0.0f, InputBtype = 0.0f;

            //Console.Write("A 실수를 입력하십시오 : ");
            //float.TryParse(Console.ReadLine(), out InputAtype);
            //Console.Write("B 실수를 입력하십시오 : ");
            //float.TryParse(Console.ReadLine(), out InputBtype);

            //if(InputAtype == InputBtype) 
            //{
            //    Console.WriteLine("A와 B같습니다");
            //}
            //else
            //{
            //    Console.WriteLine("A와 B다릅니다");
            //}

            /*
             * for문은 일정한 횟수만큼 반복할 때 유용하다.
             * 초기식을 실행한 후에 조건식이 참인 동안, 문장을 반복한다, 한번 반복이 끝날 때마다 증감식이 실행된다.
             * 
             */
            ////1~10까지 정수의 합
            //int sumNumber = 0;
            ////for 순서도
            ////                   5번          7번
            ////      1번          2번          4번
            //for (int index = 1; index <= 10; index++)
            //{
            //    //      3번, 6번
            //    sumNumber += index;
            //}
            //Console.WriteLine($"1부터 10까지의 정수의 합 = {sumNumber}");
            //Console.WriteLine("1부터 10까지의 정수의 합 = {0}",sumNumber);

            /*
             * 1 ~ 100 숫자 중에서 3의 배수를 제외한 수의 합 구하기
             */
            //Console.WriteLine("1 ~ 100 사이의 3의 배수 제외 수 합산");
            //int Result = 0;
            //for(int index = 1; index <= 100; index++)
            //{
            //    if(index % 3 != 0)
            //    {
            //        Result += index;
            //    }
            //}
            //Console.WriteLine($"합은 : {Result}");

            //////
            //int sumnumber = 0;
            //for(int index =1; index <= 100; index++)
            //{
            //    if (index % 3 == 0) {/* Do nothing */}  //코드 가독성 일부러 명시한 것
            //    else
            //    {
            //        sumnumber += index;
            //    }
            //}   // loop: 100번 도는 루프
            //Console.WriteLine(sumnumber);

            /*
             * braek 문
             * break 문은 반복 루프를 벗어나기 위해서 사용한다. break 문이 실행되면 반복 루프는 즉시 중단되고
             * 반복 루프 다음에 있는 문장이 실행된다.
             * 
             * continue 문
             * continue 문은 현재 수행하고 있는 반복 과정의 나머지를 건너뛰고 다음 반복 과정을 강제적으로
             * 시작하게 된다. 반복 루프에서 continue 문을 만나게 되면 continue 문 다음에 있는 후속 코드들은
             * 실행되지 않고 건너뛰게 된다.
             * 
             */

            ////
            //int sumnumber = 0;
            //for (int index = 1; index <= 100; index++)
            //{
            //    if (index % 3 == 0) { continue; }
            //    else
            //    {
            //        sumnumber += index;
            //    }
            //}   // loop: 100번 도는 루프
            //Console.WriteLine(sumnumber);

            //for (int index =1; index <= 10; index--)
            //{
            //    Console.WriteLine("현재 인덱스 : {0}", index);
            //    if (index == 4) { break; }
            //}   // loop : 10번도는 루프


            /* LAB 문제 1
             * 자음과 모음 갯수 세기
             * 사용자로부터 영문자를 받아서 자음과 모음의 개수를 세는 프로그램을 작성
             * - 대, 소문자 모두 카운트
             * EX)
             *      a
             *      b
             *      c
             *      d
             *      e
             *      (종료문 아무거나 Z)
             *      모음: 2
             *      자음: 3
             *    ///AEIOU 모음 나머지 자음  
             * LAB 문제 2
             * 숫자 맞추기 게임
             * 숫자 알아맞히기 게임이다. 프로그램은 1~ 100사이의 정수를 저장하고 있음. 사용자는 질문을 통해서 알아맞춘다.
             * 사용자가 답을 제시하면 프로그램은 제시된 정수가 더 낮은 값인지, 높은 값인지 알려준다.
             * 사용자가 알아맞힐때까지 루프한다. (기본형)
             * 
             * - 프로그램을 수정하여 컴퓨터가 생성한 숫자를 사용자가 추측하는 대신에, 사용자가 결정한 번호를 
             *   컴퓨터가 추측하도록 수정한다. 사용자는 컴퓨터가 추측한 숫자가 높거나 낮은 지를 컴퓨터에 알려야 한다.
             *   컴퓨터가 맞출때까지 반복 (어려운거 1)
             *   
             *   사용자가 결정한 값의 범위는 (1 ~ 100) 어떤 숫자를 생각하던 간에 7번 이하의 추측으로 컴퓨터가 맞출 수 있도록
             *   어려운거 1을 수정 하시오 (어려운거 2)
             * 
             */

            //int consonant = 0; //자음을 담을 변수 선언
            //int vowol = 0;  //모음을 담을 변수 선언

            //Console.WriteLine("영문단어 자음,모음을 세는 프로그램입니다.");   //프로그램 소개글

            //while (true)
            //{
            //    Console.Write("영단어를 입력해주세요 : ");            //입력 정보 도움글
            //    char Englishchar;                                   //문자열 변수 EnglishWord 선언 
            //    char.TryParse(Console.ReadLine(), out Englishchar); //EnglishWord 변수에 정보 입력

            //    // 문자열 EnglishWord[index](열)의 문자 값이 a 또는 A와 같다면
            //    if('Z' == Englishchar) 
            //    {
            //        break;
            //    }
            //    else if ('a' == Englishchar || 'A' == Englishchar)
            //    {
            //        consonant += 1; //자음 갯수 추가
            //    }
            //    // 문자열 EnglishWord[index](열)의 문자 값이 e 또는 E와 같다면
            //    else if ('e' == Englishchar || 'E' == Englishchar)
            //    {
            //        consonant += 1; //자음 갯수 추가
            //    }
            //    // 문자열 EnglishWord[index](열)의 문자 값이 i 또는 I와 같다면
            //    else if ('i' == Englishchar || 'I' == Englishchar)
            //    {
            //        consonant += 1; //자음 갯수 추가
            //    }
            //    // 문자열 EnglishWord[index](열)의 문자 값이 o 또는 O와 같다면
            //    else if ('o' == Englishchar || 'O' == Englishchar)
            //    {
            //        consonant += 1; //자음 갯수 추가
            //    }
            //    // 문자열 EnglishWord[index](열)의 문자 값이 u 또는 U와 같다면
            //    else if ('u' == Englishchar || 'U' == Englishchar)
            //    {
            //        consonant += 1; //자음 갯수 추가
            //    }
            //    else
            //    {
            //        vowol += 1; //모음 갯수 추가
            //    }
            //}
            //Console.WriteLine($"자음: {consonant} 개, 모음: {vowol} 개"); //최종 결과 출력문

            //------------------------잘못된 해결 string 문자열 방식으로 해결했다---------------------------
            //int consonant = 0; //자음을 담을 변수 선언
            //int vowol = 0;  //모음을 담을 변수 선언
            //Console.WriteLine("영문단어 자음,모음을 세는 프로그램입니다.");   //프로그램 소개글
            //Console.Write("영단어를 입력해주세요 : ");                       //입력 정보 도움글
            //string EnglishWord = string.Empty;                             //문자열 변수 EnglishWord 선언 
            //EnglishWord = Console.ReadLine();                              //EnglishWord 변수에 정보 입력
            ////for반복문      EnglishWord의 문자열 길이 값만큼 반복한다
            //for (int index = 0; index < EnglishWord.Length; index++)       
            //{
            //    /*문자열 EnglishWord의 [index번째](열)값 번째의 문자 값(char) 비교문*/
            //
            //    // 문자열 EnglishWord[index](열)의 문자 값이 a 또는 A와 같다면
            //    if ('a' == EnglishWord[index] || 'A' == EnglishWord[index])
            //    {
            //        consonant += 1; //자음 갯수 추가
            //    }
            //    // 문자열 EnglishWord[index](열)의 문자 값이 e 또는 E와 같다면
            //    else if ('e' == EnglishWord[index] || 'E' == EnglishWord[index])
            //    {
            //        consonant += 1; //자음 갯수 추가
            //    }
            //    // 문자열 EnglishWord[index](열)의 문자 값이 i 또는 I와 같다면
            //    else if ('i' == EnglishWord[index] || 'I' == EnglishWord[index])
            //    {
            //        consonant += 1; //자음 갯수 추가
            //    }
            //    // 문자열 EnglishWord[index](열)의 문자 값이 o 또는 O와 같다면
            //    else if ('o' == EnglishWord[index] || 'O' == EnglishWord[index])
            //    {
            //        consonant += 1; //자음 갯수 추가
            //    }
            //    // 문자열 EnglishWord[index](열)의 문자 값이 u 또는 U와 같다면
            //    else if ('u' == EnglishWord[index] || 'U' == EnglishWord[index])
            //    {
            //        consonant += 1; //자음 갯수 추가
            //    }
            //    else
            //    {
            //        vowol += 1; //모음 갯수 추가
            //    }
            //}
            //Console.WriteLine($"자음: {consonant} 개, 모음: {vowol} 개"); //최종 결과 출력문
            //------------------------잘못된 해결 string 문자열 방식으로 해결했다---------------------------

            //const int SECETNUMBER = 5;
            //int AnswerNumber = 0;
            //Console.WriteLine("\n\n숫자 맞추기 게임");
            //while (true)
            //{
            //    Console.Write("1 ~ 100 중 정답 입력 : ");
            //    int.TryParse(Console.ReadLine(), out AnswerNumber);

            //    if (0 >= AnswerNumber || AnswerNumber > 100)
            //    {
            //        Console.WriteLine("1 ~ 100 중에서 입력해 주세요!");
            //    }
            //    else
            //    {
            //        if (SECETNUMBER > AnswerNumber)
            //        {
            //            Console.WriteLine("더 높습니다.");
            //        }
            //        else if (SECETNUMBER < AnswerNumber)
            //        {
            //            Console.WriteLine("더 낮습니다.");
            //        }
            //        else break;
            //    }
            //}
            //Console.WriteLine("정답입니다!");
            /////
            //Random rand = new Random();
            //int MinNumber = 1, MaxNumber = 100;
            //int SearchNumber = rand.Next(1, 100 + 1);
            //int Userchoice = 0;
            //int anwerReult = 0;
            //bool isClear = true;

            //Console.WriteLine("\n\n숫자 맞춰주는 게임");
            //Console.Write("1 ~ 100 중 한가지 숫자를 골라주세요 : ");
            //int.TryParse(Console.ReadLine(), out anwerReult);

            //while (isClear)
            //{
            //    Console.WriteLine($"{SearchNumber}가 생각하는 숫자가 맞나요 ?");
            //    Console.Write("높으면 1번, 낮으면 2번, 정답이면 3번을 눌러주세요 : ");
            //    int.TryParse(Console.ReadLine(), out Userchoice);

            //    switch (Userchoice)
            //    {
            //        case 1:
            //            MinNumber = SearchNumber + 1;
            //            break;
            //        case 2:
            //            MaxNumber = SearchNumber - 1;
            //            break;
            //    }
            //    SearchNumber = rand.Next(MinNumber, MaxNumber + 1);

            //    if (anwerReult == SearchNumber)
            //    {
            //        Console.WriteLine($"{SearchNumber}정답!");
            //        isClear = false;
            //    }
            //}
            ////

            ////Random rand = new Random();
            //int MinNumber = 1, MaxNumber = 100;
            //int SearchNumber = 50; //= rand.Next(1, 100 + 1);
            //bool isClear = true;

            //Console.WriteLine("숫자 맞춰주는 게임");
            //Console.WriteLine("1 ~ 100 중 한가지 숫자를 골라주세요");
            //Console.Write("정답 숫자를 정하세요 : ");
            //int ans = Convert.ToInt32(Console.ReadLine());

            //while (isClear)
            //{
            //    Console.WriteLine($"\n현재 범위 최저값 : {MinNumber} , 최대값 {MaxNumber}");
            //    Console.WriteLine($"{SearchNumber}가 생각하는 숫자가 맞나요 ?");

            //    if (SearchNumber > ans)
            //    {
            //        MaxNumber = SearchNumber - 1;
            //        SearchNumber = (MaxNumber + MinNumber) / 2;
            //    }
            //    else if (SearchNumber < ans)
            //    {
            //        MinNumber = SearchNumber + 1;
            //        SearchNumber = (MaxNumber + MinNumber) / 2;
            //    }
            //    else
            //    {
            //        Console.WriteLine("정답!");
            //        isClear = false;
            //    }
            //}

            /*
             *  LAB 문제3
             *  산수 문제 자동 출제
             *  산수 문제를 자동으로 출제하는 프로그램을 작성해보자. 덧셈 문제들을 자동으로 생성하여야 한다.
             *  피연산자는 0 ~ 99 사이의 숫자(난수) 한번이라도 맞으면 종료 틀리면 리트라이(기본형)
             *  
             *  - 뺄셈 곱셈 나눗셈 문제도 출제(추가문제)
             *      -> 나눗셈 예외처리(무한대 값 주의)
             */
            Random randomPoint = new Random();

            int operandA = randomPoint.Next(0, 100);
            int operandB = randomPoint.Next(0, 100);
            int UserResult = 0;


            //while(true)
            //{
            //    Console.Write($"{operandA} + {operandB} = ");
            //    int.TryParse(Console.ReadLine(), out UserResult);

            //    if(UserResult == operandA + operandB)
            //    {
            //        Console.WriteLine("정답입니다.");
            //        break;
            //    }
            //}

            ////난수 생성
            //operandA = randomPoint.Next(0, 100);
            //operandB = randomPoint.Next(0, 100);

            //while (true)
            //{
            //    Console.Write($"{operandA} - {operandB} = ");
            //    int.TryParse(Console.ReadLine(), out UserResult);

            //    if (UserResult == operandA - operandB)
            //    {
            //        Console.WriteLine("정답입니다.");
            //        break;
            //    }
            //}

            ////난수 생성
            //operandA = randomPoint.Next(0, 100);
            //operandB = randomPoint.Next(0, 100);

            //while (true)
            //{
            //    Console.Write($"{operandA} * {operandB} = ");
            //    int.TryParse(Console.ReadLine(), out UserResult);

            //    if (UserResult == operandA * operandB)
            //    {
            //        Console.WriteLine("정답입니다.");
            //        break;
            //    }
            //}

            //난수 생성
            //operandA = randomPoint.Next(0, 100);
            //operandB = randomPoint.Next(0, 100);

            //float division = 0.0f, UserdivisionResult = 0.0f;

            //while (true)
            //{
            //    Console.Write($"{operandA} / {operandB} = ");
            //    float.TryParse(Console.ReadLine(), out UserdivisionResult);

            //    division = (float)Math.Round((float)operandA / (float)operandB,3);

            //    if (division == UserdivisionResult)
            //    {
            //        Console.WriteLine("정답입니다.");
            //        break;
            //    }
            //}

            /*
             * 오늘의 과제 LAB 문제 1 ~ LAB 문제 3의 모든라인에서 각 라인이 어떤 역활이 하는지 
             * 주석으로 설명해서 제출할 것 형태는 zip 파일, *gitignore 참고* 용량 잘 보고 올릴것.)
             * 카카오톡 링크 있다 구글 드라이브
             */

            /*
             * foreach 문은 배열(Array)이나 컬랙션(collection) 같은 값을 여러개 담고 있는 데이터 구조에서
             * 각각의 데이터가 들어 있는 만큼 반복하는 반복문이다. 데이터 개수나 반복 조건을 처리할 필요가 없다.
             * 
             */

            //string 에서 글자를 하나씩 출력
            string stringText = "Hello World!";

            int loopcount = 0;
            foreach (char oneCharactor in stringText)
            {
                Console.Write("{0} ", oneCharactor);

                loopcount++;
            }       //loop : stringText의 길이만큼 도는 루프
            Console.WriteLine();
            Console.WriteLine("Loop count: {0}, stringText's length: {1}",
                loopcount, stringText.Length);

            /*  //
             * 1 ~ 100 숫자 중에서 3의 배수이면서 4의 배수인 정수 합 구하기
             *  //
             * 두개의 정수를 입력 받아서 두 수의 차를 출력하는 프로그램 작성
             * - 항상 큰 수 에서 작은 수를 뺀 결과를 출력할 것
             * - 결과는 언제나 0 이상이어야 함
             *  //
             * 구구단을 출력하되 짝수(2단 4단 6단 8단)만 출력되도록 하는 프로그램을 작성
             * -2단은 2x2 까지만, 4단은 4x4 까지만,...,8단은 8x8 까지만 출력한다.
             * -break 와 continue를 사용 할 것
             *  //
             * 다음 식을 만족하는 모든 A와 Z를 구하는 프로그램을 작성
             * -        A Z
             * -    +   Z A
             *      --------
             *          9 9
             *  //
             *  
             *  
             */

            int SumInteger = 0;
            for (int index = 1; index <= 100; index++)
            {
                if (index % 3 == 0 && index % 4 == 0)
                {
                    SumInteger += index;
                }
            }
            Console.WriteLine(SumInteger);
            /////

            int IntegerA = 0;
            int IntegerB = 0;

            int.TryParse(Console.ReadLine(), out IntegerA);
            int.TryParse(Console.ReadLine(), out IntegerB);

            if (IntegerA - IntegerB >= 0 || IntegerB - IntegerA >= 0)
            {
                if (IntegerA >= IntegerB)
                {
                    Console.WriteLine("{0} - {1} = {2}", IntegerA, IntegerB, IntegerA - IntegerB);
                }
                else
                {
                    Console.WriteLine("{0} - {1} = {2}", IntegerB, IntegerA, IntegerB - IntegerA);
                }
            }
            else
            {
                Console.WriteLine("두 수의 차가 0이하 입니다.");
            }
            ////
            int GuguDan_integer = 1;
            while (GuguDan_integer < 10)
            {
                for (int index = 1; index < 10; index++)
                {
                    if (GuguDan_integer % 2 == 0)
                    {
                        if (index > GuguDan_integer)
                        {
                            continue;
                        }
                    }
                    else break;
                    Console.WriteLine("{0} x {1} = {2}", GuguDan_integer, index, GuguDan_integer * index);
                }
                GuguDan_integer++;
                Console.WriteLine();
            }
            ////

            int ResultA = 0;
            int ResultB = 0;
            
            for(int index = 1; index < 9; index++)
            {
                ResultA = 10 * (9 - index) + index;
                ResultB = 10 * index + (9 - index);

                Console.WriteLine("\t{0}\n\t{1}\n\t----\n\t{2}", ResultA, ResultB, ResultA + ResultB);
                Console.WriteLine();
            }




        }       //Main
    }
}