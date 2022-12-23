using System;
using System.Runtime.ExceptionServices;

namespace Life_of_adventurer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //변수선언
            Random rand = new Random(); //랜덤요소를 위한 랜덤 클래스 생성
            int situationType = 0;      //랜덤요소값을 위한 정수 변수

            string name = string.Empty; //이름
            int Health = 5; //체력
            int Mental = 5; //정신력

            //힘,민첩,지능,카리스마,건강,지혜 선언 (기본값 5로 설정)
            //int force = 5, agility = 5, intelligence = 5, Charisma = 5, fitness = 5, Wisdom = 5;

            //힘 0 민첩1 지능2 카리스마3 건강4 지혜5 로 된 배열 선언
            int[] stat = new int[6];

            //타이틀 씬
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t==================");  //메인화면 출력문
            Console.WriteLine("\t=                =");  //
            Console.WriteLine("\t=  모험가이야기  =");   //
            Console.WriteLine("\t=                =");  //
            Console.WriteLine("\t==================");  //
            Console.WriteLine();
            Console.WriteLine("\t아무키나 눌러주세요.");  //버튼 키 입력 안내문
            Console.ReadKey();  //버튼 누르기
            Console.Clear();    //출력화면 클리어

            //사용자 설정
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("\t=====================================");  //메인화면 출력문
            Console.Write("\t당신의 이름을 알려주세요.");
            name = Console.ReadLine();
            Console.WriteLine("\t랜덤 능력치를 설정합니다.");
            for (int index = 0; index < stat.Length; index++)
            {
                stat[index] = rand.Next(1, 20 + 1); // 1 ~ 20 스텟 랜덤값
            }
            Console.WriteLine($"\t현재 스텟은 힘 : {stat[0]}, 민첩 : {stat[1]}, 지능 : {stat[2]},카리스마 {stat[3]},건강 {stat[4]},지혜 {stat[5]} 입니다.");
            Console.WriteLine("\t=====================================================");
            Console.WriteLine("\t진행하시려면 아무키나 눌려주세요");  //버튼 키 입력 안내문
            Console.ReadKey();  //버튼 누르기
            Console.Clear();    //출력화면 클리어

            //스토리 씬
            Console.WriteLine("\t=====================================================");
            Console.WriteLine("\t<위대한 모험가를 꿈꾸는 {0}>", name);
            Console.WriteLine();
            Console.WriteLine("\t웅장한 나팔소리와 함께 한 사람이 단상으로");
            Console.WriteLine("\t올라갔다. 그 사람은 왕의 앞에 천천히 무릅을 끓었다");
            Console.WriteLine("\t\"자네의 모험을 온 국민이 기억 할 걸세,모두 보아라!");
            Console.WriteLine("\t이자가 이 나라의 영웅이다!\"");
            Console.WriteLine();
            Console.WriteLine("\t왕의 외침과 함께 관중들의 환호가 터져나왔다.");
            Console.WriteLine("\t당신은 그날부터, 아버지의 밭을 이어받는게 아니라");
            Console.WriteLine("\t명예로운 모험가가 되겠다는 꿈을 꾸었다. 몇 년의");
            Console.WriteLine("\t세월이 흘렀지만 그 기억은 여전히 당신에게 남아,");
            Console.WriteLine("\t모험을 떠나도록 만들었다");
            Console.WriteLine("\t=====================================================");
            Console.WriteLine("\t진행하시려면 아무키나 눌려주세요");  //버튼 키 입력 안내문
            Console.ReadKey();  //버튼 누르기
            Console.Clear();    //출력화면 클리어

            //situationType = rand.Next(1, 2 + 1);    //스토리 선택 랜덤변수

            int eventSuccess = 0;   //페널티 / 보너스 이벤트 성공확률
            int myProbability = 0;  //나의 이벤트 성공확률

            int UserInput = 0;
            bool isStoryEnd = true;

            //선택지 씬 : 랜덤스토리
            while (isStoryEnd)
            {
                Console.WriteLine("\t=====================================================");
                Console.WriteLine($"\t이름 {name}, 체력 {Health}, 정신력 {Mental} ");
                Console.WriteLine($"\t스텟은 힘 : {stat[0]}, 민첩 : {stat[1]}, 지능 : {stat[2]},카리스마 {stat[3]},건강 {stat[4]},지혜 {stat[5]} 입니다.");
                Console.WriteLine();

                situationType = rand.Next(1, 3 + 1);

                myProbability = rand.Next(1, 50 + 1);

                switch (situationType)
                {
                    case 1:
                        //그냥 선택지
                        Console.WriteLine("\t");
                        Console.WriteLine("\t낡은 폐허건물을 지나게 되었다.");
                        Console.WriteLine("\t다른 길로 지나갈 공간이 없으니");
                        Console.WriteLine("\t내부로 지나가게 되었다. 다행히 안은 깔끔했다");
                        Console.WriteLine("\t=====================================================");
                        Console.WriteLine("\t진행하시려면 아무키나 눌려주세요");  //버튼 키 입력 안내문
                        Console.ReadKey();  //버튼 누르기
                        Console.Clear();    //출력화면 클리어
                        isStoryEnd = false;
                        break;
                    case 2:
                        Console.WriteLine("\t");
                        Console.WriteLine("\t패널티 선택지");
                        Console.WriteLine("\t낡은 폐허건물을 지나게 되었다.");
                        Console.WriteLine("\t내부에 가지덩굴이 있다.");
                        Console.WriteLine("\t아마 잘못 지나가면 다칠 수 있을 것 같다");
                        Console.WriteLine("\t=====================================================");
                        Console.WriteLine($"\t 1. 그냥 지나간다 (지혜 : {stat[5]}, 성공확률 : {stat[5] * myProbability / 10} %) 현재 난수 : {myProbability}");
                        Console.WriteLine($"\t 2. 돌아간다");

                        //예외처리
                        while (true)
                        {
                            Console.Write("\t선택 : ");  //버튼 키 입력 안내문
                            int.TryParse(Console.ReadLine(), out UserInput);
                            if (UserInput > 0 && 3 > UserInput) break;

                            Console.WriteLine("\t\t\t\t잘못된 입력값입니다.");
                        }
                        Console.Clear();    //출력화면 클리어
                        //패널티 선택지

                        if(UserInput == 1)
                        {
                                eventSuccess = rand.Next(1, 100 + 1);
                                if ((stat[5] * myProbability / 10) < eventSuccess)
                                {
                                    Console.WriteLine("\t=====================================================");
                                    Console.WriteLine($"\t이름 {name} 현재 스텟은 힘 : {stat[0]}, 민첩 : {stat[1]}, 지능 : {stat[2]},카리스마 {stat[3]},건강 {stat[4]},지혜 {stat[5]} 입니다.");
                                    Console.WriteLine();
                                    Console.WriteLine("\t");
                                    Console.WriteLine("\t이런 마지막 가시 덩굴에 발이 걸렸습니다.");
                                    Console.WriteLine("\t그냥 돌아갈껄 그랬습니다.");
                                    Console.WriteLine("\t패널티 : 체력 - 1 / 현재 체력 {0}, 현재 난수 {1}", --Health, eventSuccess);
                                    Console.WriteLine("\t=====================================================");
                                    Console.WriteLine("\t진행하시려면 아무키나 눌려주세요");  //버튼 키 입력 안내문
                                    Console.ReadKey();  //버튼 누르기
                                    Console.Clear();    //출력화면 클리어
                                }
                                else
                                {
                                    Console.WriteLine("\t=====================================================");
                                    Console.WriteLine($"\t이름 {name} 현재 스텟은 힘 : {stat[0]}, 민첩 : {stat[1]}, 지능 : {stat[2]},카리스마 {stat[3]},건강 {stat[4]},지혜 {stat[5]} 입니다.");
                                    Console.WriteLine();
                                    Console.WriteLine("\t");
                                    Console.WriteLine("\t마지막 덩쿨에 걸릴 껄 운좋게 피했습니다");
                                    Console.WriteLine("\t덕분에 더욱 빠르게 왔습니다");
                                    Console.WriteLine("\t현재 체력 {0} 현재 난수 {1}", Health, eventSuccess);
                                    Console.WriteLine("\t=====================================================");
                                    Console.WriteLine("\t진행하시려면 아무키나 눌려주세요");  //버튼 키 입력 안내문
                                    Console.ReadKey();  //버튼 누르기
                                    Console.Clear();    //출력화면 클리어
                                }
                        }
                        isStoryEnd = false;
                        break;
                    case 3:
                        Console.WriteLine("\t");
                        Console.WriteLine("\t보너스 선택지");
                        Console.WriteLine("\t길거리 한복판에 상자가 떨어져 있다");
                        Console.WriteLine("\t아무래도 수상해보이는 상자다");
                        Console.WriteLine("\t무엇이 있는 지 확인해 볼까?");
                        Console.WriteLine("\t=====================================================");
                        Console.WriteLine($"\t 1. 힘껏 상자를 연다 (힘 : {stat[0]}, 성공확률 : {stat[0] * myProbability / 10} %) , 성공시 : 힘의물약 획득 현재 난수 : {myProbability}");
                        Console.WriteLine($"\t 2. 돌아간다");

                        //예외처리
                        while (true)
                        {
                            Console.Write("\t선택 : ");  //버튼 키 입력 안내문
                            int.TryParse(Console.ReadLine(), out UserInput);
                            if (UserInput > 0 && 3 > UserInput) break;

                            Console.WriteLine("\t\t\t\t잘못된 입력값입니다.");
                        }
                        Console.Clear();    //출력화면 클리어
                        //패널티 선택지

                        if (UserInput == 1)
                        {
                            eventSuccess = rand.Next(1, 100 + 1);
                            if ((stat[5] * myProbability / 10) < eventSuccess)
                            {
                                Console.WriteLine("\t=====================================================");
                                Console.WriteLine($"\t이름 {name} 현재 스텟은 힘 : {stat[0]}, 민첩 : {stat[1]}, 지능 : {stat[2]},카리스마 {stat[3]},건강 {stat[4]},지혜 {stat[5]} 입니다.");
                                Console.WriteLine();
                                Console.WriteLine("\t");
                                Console.WriteLine("\t아쉽게도 열리지 않았다");
                                Console.WriteLine("\t흔들어보면 뭔가 들어있긴 한듯하다");
                                Console.WriteLine("\t=====================================================");
                                Console.WriteLine("\t진행하시려면 아무키나 눌려주세요");  //버튼 키 입력 안내문
                                Console.ReadKey();  //버튼 누르기
                                Console.Clear();    //출력화면 클리어
                            }
                            else
                            {
                                Console.WriteLine("\t=====================================================");
                                Console.WriteLine($"\t이름 {name} 현재 스텟은 힘 : {stat[0]}, 민첩 : {stat[1]}, 지능 : {stat[2]},카리스마 {stat[3]},건강 {stat[4]},지혜 {stat[5]} 입니다.");
                                Console.WriteLine();
                                Console.WriteLine("\t");
                                Console.WriteLine("\t있는 힘껏 열어 상자가 부서졌다");
                                Console.WriteLine("\t하지만 그 중 가장 비싼 포션 힘의 물약이 들어있었다");
                                Console.WriteLine("\t마셔서 힘스텟이 1증가했다");
                                Console.WriteLine("\t현재 기존 힘스텟 {0}, 현재 힘스텟 {1} 현재 난수 {2}", stat[0]++, stat[0], eventSuccess);
                                Console.WriteLine("\t=====================================================");
                                Console.WriteLine("\t진행하시려면 아무키나 눌려주세요");  //버튼 키 입력 안내문
                                Console.ReadKey();  //버튼 누르기
                                Console.Clear();    //출력화면 클리어
                            }
                        }
                        isStoryEnd = false;
                        break;
                }
            }
            //전투씬
            isStoryEnd = true;

            int myAttackPoint = 0;
            int enemyAttackPoint = 0;
            int enemyHealth = 0;
            string matchPointText = "";

            //int TurnPoint

            while (isStoryEnd)
            {
                Console.WriteLine("\t=====================================================");
                Console.WriteLine($"\t이름 {name}, 체력 {Health}, 정신력 {Mental} ");
                Console.WriteLine($"\t스텟은 힘 : {stat[0]}, 민첩 : {stat[1]}, 지능 : {stat[2]},카리스마 {stat[3]},건강 {stat[4]},지혜 {stat[5]} 입니다.");
                Console.WriteLine();

                situationType = rand.Next(1, 3 + 1);
                myAttackPoint = stat[0] + stat[1] + stat[2]; //나의 전투력은 힘 민첩 지능 합산

                switch (situationType)
                {
                    case 1:
                        enemyAttackPoint = 30;
                        enemyHealth = 350;

                        if (myAttackPoint + Health > enemyAttackPoint + enemyHealth + 10) matchPointText = "우세";
                        else if (myAttackPoint + Health < enemyAttackPoint + enemyHealth - 10) matchPointText = "열세";
                        else matchPointText = "비등";

                        //오크
                        Console.WriteLine("\t");
                        Console.WriteLine("\t동굴을 지나던 도중 외다리에서 오크를 만났다");
                        Console.WriteLine("\t나를 보자마자 위협적인 동작으로 걸어오기 시작한다");
                        Console.WriteLine("\t=====================================================");
                        Console.WriteLine($"\t 전투시작 (승리확률 : {matchPointText})");
                        Console.WriteLine("\t진행하시려면 아무키나 눌려주세요");  //버튼 키 입력 안내문
                        Console.ReadKey();  //버튼 누르기
                        Console.Clear();    //출력화면 클리어
                        
                        while(true)
                        {
                            //전투 시작



                        }
                        //if (UserInput == 1)
                        //{
                        //    eventSuccess = rand.Next(1, 100 + 1);
                        //    if ((stat[5] * myProbability / 10) < eventSuccess)
                        //    {
                        //        Console.WriteLine("\t=====================================================");
                        //        Console.WriteLine($"\t이름 {name} 현재 스텟은 힘 : {stat[0]}, 민첩 : {stat[1]}, 지능 : {stat[2]},카리스마 {stat[3]},건강 {stat[4]},지혜 {stat[5]} 입니다.");
                        //        Console.WriteLine();
                        //        Console.WriteLine("\t");
                        //        Console.WriteLine("\t이런 마지막 가시 덩굴에 발이 걸렸습니다.");
                        //        Console.WriteLine("\t그냥 돌아갈껄 그랬습니다.");
                        //        Console.WriteLine("\t패널티 : 체력 - 1 / 현재 체력 {0}, 현재 난수 {1}", --Health, eventSuccess);
                        //        Console.WriteLine("\t=====================================================");
                        //        Console.WriteLine("\t진행하시려면 아무키나 눌려주세요");  //버튼 키 입력 안내문
                        //        Console.ReadKey();  //버튼 누르기
                        //        Console.Clear();    //출력화면 클리어
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("\t=====================================================");
                        //        Console.WriteLine($"\t이름 {name} 현재 스텟은 힘 : {stat[0]}, 민첩 : {stat[1]}, 지능 : {stat[2]},카리스마 {stat[3]},건강 {stat[4]},지혜 {stat[5]} 입니다.");
                        //        Console.WriteLine();
                        //        Console.WriteLine("\t");
                        //        Console.WriteLine("\t마지막 덩쿨에 걸릴 껄 운좋게 피했습니다");
                        //        Console.WriteLine("\t덕분에 더욱 빠르게 왔습니다");
                        //        Console.WriteLine("\t현재 체력 {0} 현재 난수 {1}", Health, eventSuccess);
                        //        Console.WriteLine("\t=====================================================");
                        //        Console.WriteLine("\t진행하시려면 아무키나 눌려주세요");  //버튼 키 입력 안내문
                        //        Console.ReadKey();  //버튼 누르기
                        //        Console.Clear();    //출력화면 클리어
                        //    }
                        //}
                        //isStoryEnd = false;
                        break;
                    case 2:
                        Console.WriteLine("\t");
                        Console.WriteLine("\t패널티 선택지");
                        Console.WriteLine("\t낡은 폐허건물을 지나게 되었다.");
                        Console.WriteLine("\t내부에 가지덩굴이 있다.");
                        Console.WriteLine("\t아마 잘못 지나가면 다칠 수 있을 것 같다");
                        Console.WriteLine("\t=====================================================");
                        Console.WriteLine($"\t 1. 그냥 지나간다 (지혜 : {stat[5]}, 성공확률 : {stat[5] * myProbability / 10} %) 현재 난수 : {myProbability}");
                        Console.WriteLine($"\t 2. 돌아간다");

                        //예외처리
                        while (true)
                        {
                            Console.Write("\t선택 : ");  //버튼 키 입력 안내문
                            int.TryParse(Console.ReadLine(), out UserInput);
                            if (UserInput > 0 && 3 > UserInput) break;

                            Console.WriteLine("\t\t\t\t잘못된 입력값입니다.");
                        }
                        Console.Clear();    //출력화면 클리어
                        //패널티 선택지

                        if (UserInput == 1)
                        {
                            eventSuccess = rand.Next(1, 100 + 1);
                            if ((stat[5] * myProbability / 10) < eventSuccess)
                            {
                                Console.WriteLine("\t=====================================================");
                                Console.WriteLine($"\t이름 {name} 현재 스텟은 힘 : {stat[0]}, 민첩 : {stat[1]}, 지능 : {stat[2]},카리스마 {stat[3]},건강 {stat[4]},지혜 {stat[5]} 입니다.");
                                Console.WriteLine();
                                Console.WriteLine("\t");
                                Console.WriteLine("\t이런 마지막 가시 덩굴에 발이 걸렸습니다.");
                                Console.WriteLine("\t그냥 돌아갈껄 그랬습니다.");
                                Console.WriteLine("\t패널티 : 체력 - 1 / 현재 체력 {0}, 현재 난수 {1}", --Health, eventSuccess);
                                Console.WriteLine("\t=====================================================");
                                Console.WriteLine("\t진행하시려면 아무키나 눌려주세요");  //버튼 키 입력 안내문
                                Console.ReadKey();  //버튼 누르기
                                Console.Clear();    //출력화면 클리어
                            }
                            else
                            {
                                Console.WriteLine("\t=====================================================");
                                Console.WriteLine($"\t이름 {name} 현재 스텟은 힘 : {stat[0]}, 민첩 : {stat[1]}, 지능 : {stat[2]},카리스마 {stat[3]},건강 {stat[4]},지혜 {stat[5]} 입니다.");
                                Console.WriteLine();
                                Console.WriteLine("\t");
                                Console.WriteLine("\t마지막 덩쿨에 걸릴 껄 운좋게 피했습니다");
                                Console.WriteLine("\t덕분에 더욱 빠르게 왔습니다");
                                Console.WriteLine("\t현재 체력 {0} 현재 난수 {1}", Health, eventSuccess);
                                Console.WriteLine("\t=====================================================");
                                Console.WriteLine("\t진행하시려면 아무키나 눌려주세요");  //버튼 키 입력 안내문
                                Console.ReadKey();  //버튼 누르기
                                Console.Clear();    //출력화면 클리어
                            }
                        }
                        //isStoryEnd = false;
                        break;
                    case 3:
                        Console.WriteLine("\t");
                        Console.WriteLine("\t보너스 선택지");
                        Console.WriteLine("\t길거리 한복판에 상자가 떨어져 있다");
                        Console.WriteLine("\t아무래도 수상해보이는 상자다");
                        Console.WriteLine("\t무엇이 있는 지 확인해 볼까?");
                        Console.WriteLine("\t=====================================================");
                        Console.WriteLine($"\t 1. 힘껏 상자를 연다 (힘 : {stat[0]}, 성공확률 : {stat[0] * myProbability / 10} %) , 성공시 : 힘의물약 획득 현재 난수 : {myProbability}");
                        Console.WriteLine($"\t 2. 돌아간다");

                        //예외처리
                        while (true)
                        {
                            Console.Write("\t선택 : ");  //버튼 키 입력 안내문
                            int.TryParse(Console.ReadLine(), out UserInput);
                            if (UserInput > 0 && 3 > UserInput) break;

                            Console.WriteLine("\t\t\t\t잘못된 입력값입니다.");
                        }
                        Console.Clear();    //출력화면 클리어
                        //패널티 선택지

                        if (UserInput == 1)
                        {
                            eventSuccess = rand.Next(1, 100 + 1);
                            if ((stat[5] * myProbability / 10) < eventSuccess)
                            {
                                Console.WriteLine("\t=====================================================");
                                Console.WriteLine($"\t이름 {name} 현재 스텟은 힘 : {stat[0]}, 민첩 : {stat[1]}, 지능 : {stat[2]},카리스마 {stat[3]},건강 {stat[4]},지혜 {stat[5]} 입니다.");
                                Console.WriteLine();
                                Console.WriteLine("\t");
                                Console.WriteLine("\t아쉽게도 열리지 않았다");
                                Console.WriteLine("\t흔들어보면 뭔가 들어있긴 한듯하다");
                                Console.WriteLine("\t=====================================================");
                                Console.WriteLine("\t진행하시려면 아무키나 눌려주세요");  //버튼 키 입력 안내문
                                Console.ReadKey();  //버튼 누르기
                                Console.Clear();    //출력화면 클리어
                            }
                            else
                            {
                                Console.WriteLine("\t=====================================================");
                                Console.WriteLine($"\t이름 {name} 현재 스텟은 힘 : {stat[0]}, 민첩 : {stat[1]}, 지능 : {stat[2]},카리스마 {stat[3]},건강 {stat[4]},지혜 {stat[5]} 입니다.");
                                Console.WriteLine();
                                Console.WriteLine("\t");
                                Console.WriteLine("\t있는 힘껏 열어 상자가 부서졌다");
                                Console.WriteLine("\t하지만 그 중 가장 비싼 포션 힘의 물약이 들어있었다");
                                Console.WriteLine("\t마셔서 힘스텟이 1증가했다");
                                Console.WriteLine("\t현재 기존 힘스텟 {0}, 현재 힘스텟 {1} 현재 난수 {2}", stat[0]++, stat[0], eventSuccess);
                                Console.WriteLine("\t=====================================================");
                                Console.WriteLine("\t진행하시려면 아무키나 눌려주세요");  //버튼 키 입력 안내문
                                Console.ReadKey();  //버튼 누르기
                                Console.Clear();    //출력화면 클리어
                            }
                        }
                        //isStoryEnd = false;
                        break;
                }
            }
        }
    }
}
//배열로 몬스터의 인덱스값 맞춰서 값을 주고 배틀은 하나의 형식으로 공격은 사실상 스킬 공격 A 치기 , 강타, 몸통박치기