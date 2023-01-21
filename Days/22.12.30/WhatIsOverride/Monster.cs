using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsOverride
{
    public class Monster
    {
        protected string name;
        public int HP;
        protected int Attak;
        protected int Defence;

        public void Move(string name)
        {
            Console.WriteLine("{0}가 움직인다.", name);
        }
        public void Attacking(string name, int attack)
        {
            Console.WriteLine("{0}가 {1}만큼 공격한다.", name, attack);
        }
        public void Defencing(string name, int defence)
        {
            Console.WriteLine("{0}가 {1}의 방어력으로 막았다.", name, defence);
        }
    }

    class Slime : Monster
    {
        public string Name 
        {
            get { return this.name; }
            private set { this.name = value; }
            //value 키워드 이미 데이터 타입을 알기 때문에 property에서 임시변수를 주는 것이다.
        }

        public Slime()
        {
            this.name = "슬라임";
            this.HP = 100;
            this.Attak = 10;
            this.Defence = 10;
        }

        public void moveAttack()
        {
            this.Move(this.name);
            this.Attacking(this.name, this.Attak);
        }
    }

    class Wolf : Monster
    {
        public Wolf()
        {
            this.name = "늑대";
            this.HP = 300;
            this.Attak = 30;
            this.Defence = 15;
        }
        public void moveAttack()
        {
            this.Move(this.name);
            this.Attacking(this.name, this.Attak);
        }
    }
}
