using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatisClass
{
    public class TwoGame
    {
        public static void Main()
        {
            //플레이어와 몬스터의 전투
            Player player_ = new Player();  //플레이어 인스턴스화
            Tiger tiger_ = new Tiger();     //몬스터1(호랑이) 인스턴스화
            Robot robot_ = new Robot();     //몬스터2(로봇) 인스턴스화
            orc orc_ = new orc();           //몬스터3(오크) 인스턴스화
            Battle battle_ = new Battle();  //싸우기 클래스 인스턴스화
            battle_.SetPlayer(player_);     //싸우기 클래스에 Player 값 세팅 함수

            player_.PrintItemBoxAndGold();  //플레이어 소지금, 인벤창 출력 함수
            Console.WriteLine();

            battle_.PlayerAndMonsterFighting(tiger_);  //호랑이와 싸우기
            battle_.PlayerAndMonsterFighting(orc_);    //오크와 싸우기
            battle_.PlayerAndMonsterFighting(robot_);  //로봇와 싸우기

            //컴퓨터와 숫자 초과 미만 게임
            TrumpCard trumpcard_ = new TrumpCard();     //트럼프카드 인스턴스화
            CardGame cardgame_ = new CardGame();        //카드게임 인스턴스화
            cardgame_.InGame();                         //카드게임 시작 함수
        }
    }

    //캐릭터 클래스
    class CharactorInfo
    {
        //캐릭터의 기본적인 값 설정
        protected string name;  //이름
        protected int HP;       //체력
        protected int AttakPoint;   //공격력
        protected int DefencePoint; //방어력
        protected int Gold; //골드
        protected string Item;  //아이템

        //(기본) 캐릭터의 기본 공격
        public void BasicAttack(CharactorInfo enemy)
        {
            if (this.HP > 0)    //현재 클래스의 HP가 0보다 크면 (죽지않았을 때)
            {
                Console.WriteLine("{0}가 {1}에게 {2} 데미지를 줬다.", this.name, this.AttakPoint, enemy.name);
                enemy.HP -= this.AttakPoint;
                BasicEnemyKill(enemy);
            }
        }   //BasicAttack()

        //(기본) 캐릭터가 적을 죽였을 때
        public void BasicEnemyKill(CharactorInfo enemy)
        {
            if (enemy.HP < 0)
            {
                Console.WriteLine("{0}가 죽었다.", enemy.name); //적의 죽음을 알림
            }
            else {/* Do nothing */}
        }   //BasicEnemyDie()

        //(기본) 설정값 Get set // (get)내부에 있는 값을 함수로써 값만 불러오거나 (set)매개변수를 통해 내부값을 변경해준다
        public string Getname() { return this.name; }
        public void Setname(string name_) { this.name = name_; }

        public int GetHP() { return this.HP; }
        public void SetHP(int HP_) { this.HP = HP_; }

        public int GetAttakPoint() { return this.AttakPoint; }
        public void SetAttakPoint(int AttakPoint_) { this.AttakPoint = AttakPoint_; }

        public int GetDefencePoint() { return this.DefencePoint; }
        public void SetDefencePoint(int DefencePoint_) { this.DefencePoint = DefencePoint_; }

        public int GetGold() { return this.Gold; }
        public void SetGold(int Gold_) { this.Gold = Gold_; }

        public string GetItem() { return this.Item; }
        public void SetItem(string Item_) { this.Item = Item_; }
    }

    //자식 : 호랑이 클래스, 부모 : 캐릭터 클래스
    class Tiger : CharactorInfo
    {
        public Tiger()
        {
            this.name = "호랑이";
            this.HP = 200;
            this.AttakPoint = 40;
            this.DefencePoint = 20;
            this.Item = "호랑이 이빨";
            this.Gold = 10;
        }
    }

    //자식 : 로봇 클래스, 부모 : 캐릭터 클래스
    class Robot : CharactorInfo
    {
        public Robot()
        {
            this.name = "로봇";
            this.HP = 800;
            this.AttakPoint = 450;
            this.DefencePoint = 450;
            this.Item = "로봇메모리장치";
            this.Gold = 350;
        }
    }

    //자식 : 오크 클래스, 부모 : 캐릭터 클래스
    class orc : CharactorInfo
    {
        public orc()
        {
            this.name = "오크";
            this.HP = 300;
            this.AttakPoint = 90;
            this.DefencePoint = 20;
            this.Item = "오크가죽";
            this.Gold = 100;
        }
    }

    //자식 : 플레이어 , 부모 : 캐릭터 클래스
    class Player : CharactorInfo
    {
        //(플레이어 클래스만) 플레이어만의 아이템 박스(string 배열)
        private string[] Itembox;

        public Player()
        {
            this.name = "플레이어";
            this.AttakPoint = 100;
            this.DefencePoint = 50;
            this.HP = 600;
            this.Gold = 0;
            this.Item = "플레이어의 검";
            this.Itembox = new string[5];

            //인벤토리 초기화
            for (int i = 0; i < this.Itembox.Length; i++)
            {
                Itembox[i] = " ";
            }
        }
        //(플레이어 클래스만) 플레이어의 공격(캐릭터 클래스의 매개변수)
        public void PlayerAttack(CharactorInfo enemy)
        {
            if (this.HP > 0)    //플레이어의 피가 0보다 크다면 (내가 현재 공격할 수 있는 상태라면)
            {
                //공격 출력문
                Console.WriteLine("{0}가 {1}에게 {2} 데미지를 줬다.", this.name, this.AttakPoint, enemy.Getname());
                enemy.SetHP(enemy.GetHP() - this.AttakPoint);   //적의 HP을 현재 적의 HP - 플레이어 공격력 값으로 해준다. 
                KillMonster(enemy); //플레이어가 적을 죽였을 때 함수
            }
        }   //PlayerAttack()

        //(플레이어 클래스만) 플레이어가 적을 죽였을 때 함수(캐릭터 클래스의 매개변수)
        public void KillMonster(CharactorInfo enemy)
        {
            if (enemy.GetHP() < 0)  //적의 HP가 0보다 낮으면(적이 죽으면)
            {
                //전투결과 출력문
                Console.WriteLine("{0}가 죽었다. {1} 골드와 {2} 아이템을 얻었다.", enemy.Getname(), enemy.GetGold(), enemy.GetItem());
                this.Gold += enemy.GetGold();   //적이 갖고 있는 골드 추가

                //인벤토리 전체돌려주는 반복문
                for (int i = 0; i < this.Itembox.Length; i++)
                {
                    if (Itembox[i] != " " || Itembox[i] == enemy.GetItem()) continue;   //만약 비어있거나 같은(중복) 이름 값이라면 패스
                    else    //아니라면
                    {
                        Itembox[i] = enemy.GetItem();   //적의 아이템을 대입한다.
                        break;
                    }
                }
            }
            else {/* Do nothing */}
        }   //KillMonster()

        //(플레이어 클래스만) 플레이어가 죽었을 때
        public void PlayerDieClean()
        {
            this.Gold = 0;  //골드 초기화
            for (int i = 0; i < this.Itembox.Length; i++)
            {
                Itembox[i] = " ";   //인벤토리 초기화
            }
        }   //PlayerDieClean()

        //(플레이어 클래스만) 현재 플레이어의 소지금 과 인벤토리를 보여주는 함수
        public void PrintItemBoxAndGold()
        {
            Console.WriteLine("인벤토리 총 {0} 개 현재 골드 {1}", this.Itembox.Length, this.Gold);
            for (int i = 0; i < this.Itembox.Length; i++)
            {
                Console.WriteLine("{0}번째 아이템 : {1}", i + 1, Itembox[i]);
            }
        }   //PrintItemBox()
    }
    
    //자식: 싸움 클래스 부모: 플레이어 클래스
    class Battle : Player
    {
        private Player player_;

        //내부 플레이어값을 외부값으로 세팅한다.
        public void SetPlayer(Player PLAYER)
        {
            player_ = PLAYER;
        }
        //내부 플레이어 값을 외부에 보내준다.
        public Player GetPlayer()
        {
            return player_;
        }

        //플레이어와의 전투하기 (매개변수 : 캐릭터 클래스 값)
        public void PlayerAndMonsterFighting(CharactorInfo monster_)
        {
            while (true)    //전투중 (반복문)
            {
                //전투에 관한 출력문 : 플레이어 이름, HP / 몬스터 이름, HP
                Console.WriteLine();
                Console.WriteLine("{0} HP : {1} {2} HP : {3}", player_.Getname(), player_.GetHP(), monster_.Getname(), monster_.GetHP());
                player_.PlayerAttack(monster_); //플레이어가 몬스터 공격
                monster_.BasicAttack(player_);  //몬스터가 플레이어 공격

                if (player_.GetHP() < 0)    //플레이어의 HP가 0보다 낮으면 (전사)
                {
                    player_.PlayerDieClean();   //플레이어 소지금, 인벤토리 청소
                    break;  //반복문 탈출
                }
                else if (monster_.GetHP() < 0) break;   //몬스터의 HP가 0보다 낮으면 (플레이어가 이김) 반복문 탈출
            }
            Console.WriteLine();
            player_.PrintItemBoxAndGold();  //플레이어 소지금, 인벤토리 청소
        }
    }
}
