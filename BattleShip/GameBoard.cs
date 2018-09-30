using System;
using System.Collections.Generic;
using System.Text;

namespace BattleShip
{
    public class GameBoard
    {


        public List<Point> points = new List<Point>();

        public List<Point> hits = new List<Point>();

        public List<Ship> ships = new List<Ship>();

        public char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

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


        public bool Hit(int x, int y)
        {
            Point CurrentPoint = points.Find(p => (p.XPos == x) && (p.YPos == y));
            if(CurrentPoint.Occupied)
            {
                Console.WriteLine("Trefil jsi protihráče");
                points[points.IndexOf(CurrentPoint)].PrintChar = 'X';
                return true;
                
            }
            else{
                Console.WriteLine("Netrefil jsi protihráče");
                points[points.IndexOf(CurrentPoint)].PrintChar = 'M';
                return false;
            }


        }



        public char GetShipPCOnPoint(int x, int y)
        {

            char rtnChar = ' ';

            ships.ForEach(ship =>{

                int index = ship.Points.FindIndex(p => (p.XPos == x) && (p.YPos == y));


                if(index != -1)
                {
                    int indexShip = ships.IndexOf(ship);
                    char c = ship.Points[index].PrintChar;

                    if(ship.Rendered)
                    {
                        rtnChar = c;
                    }


                }

            });

            return rtnChar;
        }



        public bool CheckCollision(Ship lod)
        {



            bool toReturn = false;



            lod.Points.ForEach(x => {


                int actualX = x.XPos;
                int actualY = x.YPos;


                ships.ForEach(y => {

                    if(y != lod && y.Rendered == true){
                        int index = y.CollisionPoints.FindIndex(p => (p.XPos == actualX) && (p.YPos == actualY));


                        if (index != -1)
                        {
                            toReturn = true;
                        }

                    }



                });



            });

            return toReturn;

        }


        public void UpdateByShip(Ship lod)
        {



            // Console.WriteLine("Ship name:" + lod.Name);
            // lod.CollisionPoints.ForEach(p => { Console.WriteLine(p.XPos.ToString() + " - " + p.YPos.ToString()); });
            // Console.WriteLine("_-----------");

            if (lod.moved)
            {
                lod.OldPoints.ForEach(x => {


                    int index = points.FindIndex(p => (p.XPos == x.XPos) && (p.YPos == x.YPos));


                    if (index != -1)
                    {
                        points[index].Occupied = false;
                        points[index].PrintChar = GetShipPCOnPoint(x.XPos, x.YPos);
                    }
                });
            }
           


            lod.Points.ForEach(x => {

                int index = points.FindIndex(p => (p.XPos == x.XPos) && (p.YPos == x.YPos));


                if (index != -1)
                {
                    points[index].Occupied = true;
                    points[index].PrintChar = x.PrintChar;
                }
            });



        }


        public void _Render()
        {

           

            for (int y = 0; y <= Size; y++)
            {

                StringBuilder ReturnString = new StringBuilder();
                if (y != 0)
                {
                    Console.Write(ParseStr(alpha[y - 1].ToString()));

                }

                for (int x = 0; x <= Size; x++)
                {
                    if( y == 0)
                    {

                        Console.Write((x == 0) ? ParseStr(" ") : ParseStr(x.ToString()));
                    }
                    else if(x != 0){

                        Point CurrentPoint = points.Find(p => (p.XPos == x) && (p.YPos == y));

                        switch (CurrentPoint.PrintChar)
                        {


                            case 'P':
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                break;
                            case 'T':
                                Console.BackgroundColor = ConsoleColor.White;
                                break;
                            case 'K':
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                break;
                            case 'B':
                                Console.BackgroundColor = ConsoleColor.Red;
                                break;
                            case 'L':
                                Console.BackgroundColor = ConsoleColor.Green;
                                break;
                            case 'Z':
                                Console.BackgroundColor = ConsoleColor.Gray;
                                break;
                            case 'H':
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                break;
                            case 'R':
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                break;
                            case 't':
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                break;
                            case 'c':
                                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 'b':
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 'X':
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 'M':
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                break;
                            case 'h':
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                break;
                            case 'l':
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                break;
                            default:
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                        }


                        Console.Write(ParseStr(CurrentPoint.PrintChar.ToString()));

                        Console.BackgroundColor = ConsoleColor.Black;
                    }


                }

                Console.Write("\n");
                Console.WriteLine(EmptyLine());

            }



           

        }






       

        public string ParseStr(string str)
        {



            return (str.Length == 3) ? str: (str.Length == 2) ?  str + "|" : " " + str + "|";
        }


        public string EmptyLine(){

            StringBuilder RtnString = new StringBuilder();

            for (int i = 0; i <= this.Size; i++)
            {
                RtnString.Append(ParseStr("---"));
            }

            return RtnString.ToString();
        }


    }
}
