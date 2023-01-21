using System;

namespace WhatisClass
{
    public class Program2
    {
        static void Main()
        {
            //Description des = new Description(123);
            //des.valueTypeAndRefferenceType();
            //des.whatIsField();
            //TrumpCard card = new TrumpCard();
            //card.ReRollcard();

            //Parent parent_ = new Parent();
            //parent_.Print();
            //child child_ = new child();
            //child_.stringValue = "";

            Player player_ = new Player();
            Tiger tiger_ = new Tiger();
            Robot robot_ = new Robot();
            orc orc_ = new orc();
            Battle battle_ = new Battle();
            battle_.SetPlayer(player_);

            player_.PrintItemBoxAndGold();
            Console.WriteLine();

            battle_.PlayerAndMonsterFighting(tiger_);  //호랑이
            battle_.PlayerAndMonsterFighting(orc_);    //오크
            battle_.PlayerAndMonsterFighting(robot_);  //로봇
        }
    }
}
