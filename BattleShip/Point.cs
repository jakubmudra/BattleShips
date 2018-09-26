using System;
using System.Linq;
using System.Collections.Generic;

namespace BattleShip
{
    public class Point
    {

        public int XPos;
        public int YPos;

        public bool Occupied;

        public char PrintChar;


        public Point(int x,int y, bool occup, char pc)
        {

            XPos = x;
            YPos = y;

            Occupied = occup;
            PrintChar = pc;

        }


        public int[] GetCoo()
        {
            return new int[2] { XPos, YPos };
        }

        public bool IsOccupied()
        {
            return Occupied;
        }

        



    }
}
