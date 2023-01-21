using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConSoleGame
{
    public class Control
    {

        public int KeyToNum(ConsoleKeyInfo inputKey)
        {
            switch(inputKey.Key) 
            {
                case ConsoleKey.W:
                    return 1;
                    break;
                case ConsoleKey.S:
                    return 2;
                    break;
                case ConsoleKey.A:
                    return 3;
                    break;
                case ConsoleKey.D:
                    return 4;
                    break;
            }
            return 0;
        }
    }
}
