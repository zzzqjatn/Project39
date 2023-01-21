using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Framework
{
    class Program
    {
        public static void Main()
        {
            Console.Title = "던전 마스터";
            Map InGameMAP = new Map();
            Player InGamePlayer = new Player(1,1,1);

            InGameMAP.playerSetting(InGamePlayer.GetMapData());

            InGamePlayer.isPlayerMoved = false;
            InGamePlayer.isNowMap = true;

            //InGameMAP.DrawMapList2222();


            //while (true)
            //{
            //    if (InGamePlayer.isPlayerMoved)
            //    {
            //        InGameMAP.playerSetting(InGamePlayer.GetMapData());
            //        InGameMAP.DrawMapList();
            //        InGamePlayer.isPlayerMoved = false;
            //    }

            //    if (InGamePlayer.isNowMap)
            //    {
            //        InGamePlayer.NowMap = InGameMAP.GiveMapList();
            //        InGamePlayer.isNowMap = false;
            //    }
            //    InGamePlayer.playerMain();
            //}

        }
    }
}