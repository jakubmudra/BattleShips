using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class Ship
    {

        public bool IsAlive;

        public int Size;

        public int Destroyed;

        public char PrintChar;

        public string Name;

        public List<Point> Points;


        public Ship(int ShipSize, char ShipChar, string ShipName, List<Point> ShipPoints)
        {
            IsAlive = true;
            Size = ShipSize;
            PrintChar = ShipChar;
            Name = ShipName;
            Points = ShipPoints;

        }

    }
}
