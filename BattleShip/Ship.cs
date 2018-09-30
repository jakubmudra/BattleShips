using System;
using System.Collections.Generic;

namespace BattleShip
{
    public class Ship
    {

        public bool IsAlive;

        public int Size;

        public int Destroyed;

        public bool Rendered = false;

        public char PrintChar;

        // Rotation - 0 = 0, 1  = 90deg, 2 = 180 deg, 3 = 270deg

        public int Rotation = 0;

        public int GBSize;

        public int minX, minY, maxX, maxY;

        public string Name;

        public List<Point> Points;

        public List<Point> PointsRotation0;
        public List<Point> PointsRotation1;
        public List<Point> PointsRotation2;
        public List<Point> PointsRotation3;


        public List<Point> CollisionPoints;

        public List<Point> OldPoints;

        public bool moved = false;

        public Ship(int ShipSize, char ShipChar, string ShipName, List<Point> ShipPoints, int size, List<Point> ShipPoints1, List<Point> ShipPoints2, List<Point> ShipPoints3)
        {
            IsAlive = true;
            Size = ShipSize;
            PrintChar = ShipChar;
            Name = ShipName;
            GBSize = size;
            Points = ShipPoints;

            PointsRotation0 = ShipPoints;
            PointsRotation1 = ShipPoints1;
            PointsRotation2 = ShipPoints2;
            PointsRotation3 = ShipPoints3;

            CollisionPoints = new List<Point>(Points);
            ShipCollisionBox();
        }


        public void ShipCollisionBox()
        {

            

            Points.ForEach(point => {






                Point leftBox = new Point(point.XPos - 1, point.YPos, point.Occupied, point.PrintChar);
                Point rightBox = new Point(point.XPos + 1, point.YPos, point.Occupied, point.PrintChar);

                Point topBox = new Point(point.XPos, point.YPos + 1, point.Occupied, point.PrintChar);
                Point botBox = new Point(point.XPos, point.YPos - 1, point.Occupied, point.PrintChar);


                List<Point> line = new List<Point>();

                if(!Points.Contains(rightBox)){
                  
                    CollisionPoints.Add(rightBox);
                }

                if (!Points.Contains(leftBox))
                {
                    CollisionPoints.Add(leftBox);
                }

                if (!Points.Contains(topBox))
                {
                    CollisionPoints.Add(topBox);
                }
                if (!Points.Contains(botBox))
                {
               
                    CollisionPoints.Add(botBox);
                }



            });




          


        }


        public void rotate(int howMuch)

        {

            OldPoints = Points;

            switch (howMuch)
            {
                case 1:
                    Points = PointsRotation1;
                    break;
                case 2:
                    Points = PointsRotation2;
                    break;
                case 3:
                    Points = PointsRotation3;
                    break;
                default:
                    Points = PointsRotation0;
                    break;

            }


            CollisionPoints.Clear();
            CollisionPoints = new List<Point>(Points);

            ShipCollisionBox();

        }


        public int[] GetShipSize()
        {
            int[] ReturnInt = new int[2];


            minX = GBSize;
            minY = GBSize;

            maxX = 0;
            maxY = 0;


            Points.ForEach(x =>{

                if(x.XPos < minX)
                {
                    minX = x.XPos;
                }
                if(x.YPos < minY)
                {
                    minY = x.YPos;
                }

                if (x.XPos > maxX)
                {
                    maxX = x.XPos;
                }
                if (x.YPos > maxY)
                {
                    maxY = x.YPos;
                }


            });

            Console.WriteLine(minX);
            Console.WriteLine(minY);

            Console.WriteLine(maxX);
            Console.WriteLine(maxY);

            int sizeX = maxX - minX + 1;
            int sizeY = maxY - minY + 1;

            return ReturnInt;


        }

        public void MoveShip(int direction)
        {
            List<Point> newPoint = new List<Point>();


            //Dir 0 = right, 1 = down, 2 = left, 3 = up

            OldPoints = Points;

            GetShipSize();

            if((direction == 3 && minY == 1) || (direction == 0 && maxX == GBSize) || (direction == 1 && maxY == GBSize) || (direction == 2 && minX == 1))
            {
                Console.WriteLine("Nelze posunout lodi - jsi na kraji.");
            }else{
                Points.ForEach(point => {

                    int xPos = point.XPos;
                    int yPos = point.YPos;
                    char pC = point.PrintChar;
                    bool occ = point.Occupied;


                    if (direction == 0) { newPoint.Add(new Point(xPos + 1, yPos, occ, pC)); }
                    else if (direction == 1) { newPoint.Add(new Point(xPos, yPos + 1, occ, pC)); }
                    else if (direction == 2) { newPoint.Add(new Point(xPos - 1, yPos, occ, pC)); }
                    else { newPoint.Add(new Point(xPos, yPos - 1, occ, pC)); }

                });

                Points = new List<Point>(newPoint);


                moved = true;


                CollisionPoints.Clear();
                CollisionPoints = new List<Point>(Points);
                PointsRotation0 = new List<Point>(Points);

                ShipCollisionBox();


                newPoint.Clear();
                PointsRotation1.ForEach(point => {

                    int xPos = point.XPos;
                    int yPos = point.YPos;
                    char pC = point.PrintChar;
                    bool occ = point.Occupied;


                    if (direction == 0) { newPoint.Add(new Point(xPos + 1, yPos, occ, pC)); }
                    else if (direction == 1) { newPoint.Add(new Point(xPos, yPos + 1, occ, pC)); }
                    else if (direction == 2) { newPoint.Add(new Point(xPos - 1, yPos, occ, pC)); }
                    else { newPoint.Add(new Point(xPos, yPos - 1, occ, pC)); }

                });
                PointsRotation1 = new List<Point>(newPoint);
                newPoint.Clear();

                PointsRotation2.ForEach(point => {

                    int xPos = point.XPos;
                    int yPos = point.YPos;
                    char pC = point.PrintChar;
                    bool occ = point.Occupied;


                    if (direction == 0) { newPoint.Add(new Point(xPos + 1, yPos, occ, pC)); }
                    else if (direction == 1) { newPoint.Add(new Point(xPos, yPos + 1, occ, pC)); }
                    else if (direction == 2) { newPoint.Add(new Point(xPos - 1, yPos, occ, pC)); }
                    else { newPoint.Add(new Point(xPos, yPos - 1, occ, pC)); }

                });

                PointsRotation2 = new List<Point>(newPoint);
                newPoint.Clear();

                PointsRotation3.ForEach(point => {

                    int xPos = point.XPos;
                    int yPos = point.YPos;
                    char pC = point.PrintChar;
                    bool occ = point.Occupied;


                    if (direction == 0) { newPoint.Add(new Point(xPos + 1, yPos, occ, pC)); }
                    else if (direction == 1) { newPoint.Add(new Point(xPos, yPos + 1, occ, pC)); }
                    else if (direction == 2) { newPoint.Add(new Point(xPos - 1, yPos, occ, pC)); }
                    else { newPoint.Add(new Point(xPos, yPos - 1, occ, pC)); }

                });

                PointsRotation3 = new List<Point>(newPoint);
                newPoint.Clear();

            }



           

        }
    }
}
