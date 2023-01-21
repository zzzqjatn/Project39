using System;
using System.Data.SqlTypes;

namespace WhatIsOverride
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Parent parent_ = new Parent();
            //parent_.Say();
            //parent_.Run();
            //parent_.Walk();

            //Child chile_ = new Child();
            //chile_.Say();
            //chile_.Run();
            //chile_.Walk();

            Button button_ = new Button();
            StoreButton storebutton_ = new StoreButton();
            storebutton_.onClickButton();
            QuestButton questbutton_ = new QuestButton();
            questbutton_.onClickButton();

            Slime slime_ = new Slime();
            //slime_.Name = "이거 사실 슬라임 아닌데";
            Console.WriteLine("{0} ", slime_.Name);
        }
    }
}