using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public class GameBoard
    {


        public List<Point> points = new List<Point>();

        int Size;


        public GameBoard(int size = 10)
        {

            Size = size;
            Generate();

        }



        private void Generate()
        {

            for (int y = 1; y <= Size;y++)
            {

                for (int x = 1; x <= Size; x++)
                {
                    points.Add(new Point(x,y,false,' '));

                }

            }

        }


        public void _Render()
        {

            StringBuilder ReturnString = new StringBuilder();
            

        }


    }
}
