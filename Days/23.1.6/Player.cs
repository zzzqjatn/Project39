using ConSoleGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Player : Character
    {
        private Inventory playerInven;
        private Control playerControl;
        public Player(int _nowMapNumber,int _PositionX, int _PositionY)
        {
            this.nowMapNumber = _nowMapNumber;
            this.PositionX = _PositionX;
            this.PositionY = _PositionY;
            playerInven = new Inventory();
            playerControl = new Control();
        }

        int nowMapNumber = 0;
        public int[,] NowMap { get; set; }
        public bool isNowMap { get; set; }

        public bool isPlayerMoved { get; set; }

        public int[] GetMapData() { return new int[] { this.nowMapNumber,this.PositionY, this.PositionX }; }

        public void playerMain()
        {
            if(Console.KeyAvailable)
            {
                move(playerControl.KeyToNum(Console.ReadKey()), NowMap);
                isPlayerMoved = true;
            }
        }
    }
}
