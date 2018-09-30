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

        public bool Ghost;


        public Point(int x, int y, bool occup, char pc, bool ghost = false)
        {

            XPos = x;
            YPos = y;
            Ghost = ghost;
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
