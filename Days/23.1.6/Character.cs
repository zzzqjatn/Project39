using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Character
    {
        protected int PositionX;
        protected int PositionY;

        protected virtual void move(int dir, int[,] map)
        {
            switch(dir)
            {
                case 1:     //위쪽
                    if (map[PositionY - 1, PositionX] == 0 && (PositionY - 1) <= 0)
                    {
                        PositionY -= 1;
                    }
                    break;
                case 2:     //아래쪽
                    if (map[PositionY + 1, PositionX] == 0 && (PositionY + 1) <= map.GetUpperBound(0))
                    {
                        PositionY += 1;
                    }
                    break;
                case 3:     //왼쪽
                    if (map[PositionY, PositionX - 1] == 0 && (PositionX - 1) <= 0)
                    {
                        PositionX -= 1;
                    }
                    break;
                case 4:     //오른쪽
                    if (map[PositionY, PositionX + 1] == 0 && (PositionX + 1) <= map.GetUpperBound(1))
                    {
                        PositionX += 1;
                    }
                    break;
            }
        }
        
    }
}
