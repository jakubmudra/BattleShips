using System;
using System.Collections.Generic;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {


            int size = 15;

            GameBoard gb = new GameBoard(size);



            GameBoard hidden = new GameBoard(size);

            KeyHandler kh = new KeyHandler();



            gb.ships.Add(new Ship(1, 'P', "Ponorka", new List<Point>() { new Point(5, 5, true, 'P') }, size, new List<Point>() { new Point(5, 5, true, 'P') }, new List<Point>() { new Point(5, 5, true, 'P') }, new List<Point>() { new Point(5, 5, true, 'P') }));

            gb.ships.Add(new Ship(2, 'T', "Torpedoborec", new List<Point>() { new Point(1, 1, true, 'T'), new Point(2, 1, true, 'T') }, size,
                                                          new List<Point>() { new Point(1, 1, true, 'T'), new Point(1, 2, true, 'T') },
                                                          new List<Point>() { new Point(1, 1, true, 'T'), new Point(2, 1, true, 'T') },
                                                          new List<Point>() { new Point(1, 1, true, 'T'), new Point(1, 2, true, 'T') }));

            bool runGame = true;


            while (runGame)
            {

                //int[] coo = kh.GetCooInput();
                //gb.Hit(coo[0], coo[1]);

               

               



                    for (int i = 0; i < gb.ships.Count; i++)
                    {

                        Ship ship = gb.ships[i];



                        bool run = true;

                        while (run)
                        {
                            Console.Clear();

                            gb.UpdateByShip(ship);

                            gb._Render();

                            Console.WriteLine("Uprav pozici lode  " + ship.Name + "a potvrd ji klavesou enter. Pro rotaci stiskni r");
                            ConsoleKeyInfo keyInfo = Console.ReadKey();
                            if (keyInfo.Key == ConsoleKey.UpArrow)
                            {
                                //UP
                                ship.MoveShip(3);
                            }
                            else if (keyInfo.Key == ConsoleKey.DownArrow)
                            {
                                //DOWN
                                ship.MoveShip(1);
                            }
                            else if (keyInfo.Key == ConsoleKey.LeftArrow)
                            {
                                ship.MoveShip(2);
                            }
                            else if (keyInfo.Key == ConsoleKey.RightArrow)
                            {
                                ship.MoveShip(0);
                            }
                            else if (keyInfo.Key == ConsoleKey.R)
                            {
                                ship.Rotation++;
                                if (ship.Rotation == 4)
                                {
                                    ship.Rotation = 0;
                                }
                                ship.rotate(ship.Rotation);
                            }
                            else if (keyInfo.Key == ConsoleKey.Enter)
                            {
                                if (gb.CheckCollision(ship))
                                {
                                    Console.WriteLine("Nemuzes umistit lod na lod");
                                }
                                else
                                {
                                    run = false;
                                }

                            }

                            ship.Rendered = true;
                            gb.UpdateByShip(ship);

                        }




                    }

                   


                Console.WriteLine("Lode ulozeny. Nyni musis trefit sve lode. Pamatujes si, kde je jaka?");



                bool runHledani = true;

                Point activePoint = new Point(size, 1, false, 'X', true);

                while (runHledani)
                {

                    Console.Clear();

                    hidden._Render();

                    Point oldPoint = activePoint;


                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        //UP

                        if(activePoint.YPos == 1)
                        {
                            Console.WriteLine("Nemuzes jit mimo border");
                        }else{
                            activePoint.YPos--;
                        }
                       
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        //DOWN
                        if (activePoint.YPos == size)
                        {
                            Console.WriteLine("Nemuzes jit mimo border");
                        }
                        else
                        {
                            activePoint.YPos++;
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        if (activePoint.XPos == 1)
                        {
                            Console.WriteLine("Nemuzes jit mimo border");
                        }
                        else
                        {
                            activePoint.XPos--;
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        if (activePoint.XPos == size)
                        {
                            Console.WriteLine("Nemuzes jit mimo border");
                        }
                        else
                        {
                            activePoint.XPos++;
                        }
                    }
                    else if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        //runHledani = false;

                        int indexShip = -1;
                        int realIndex = -1;

                        gb.ships.ForEach( ship => {

                            int i = ship.Points.FindIndex(x => (x.XPos == activePoint.XPos) && (x.YPos == activePoint.YPos));

                            if(i != -1)
                            {
                                indexShip = i;
                                realIndex = gb.ships.IndexOf(ship);
                            }
                         
                        });


                        if(indexShip != -1)
                        {


                            string name = gb.ships[realIndex].Name;
                            Console.WriteLine("Bravo, trefil si  " + name);
                            activePoint.PrintChar = 'h';

                        }
                        else{
                            activePoint.PrintChar = 'M';
                        }

                        hidden.hits.Add(activePoint);
                    }





                    int index = hidden.points.FindIndex(x => (x.XPos == activePoint.XPos) && (x.YPos == activePoint.YPos));
                    int index2 = hidden.points.FindIndex(x => (x.XPos == oldPoint.XPos) && (x.YPos == oldPoint.YPos));
                    int index3 = hidden.hits.IndexOf(oldPoint);


                    if (index != -1)
                    {


                       

                        if(index3 != -1)
                        {
                            hidden.points[index2].PrintChar = oldPoint.PrintChar;
                        }
                        else{
                            hidden.points[index2].PrintChar = ' ';
                        }

                       
                        //hidden.points[index].PrintChar = activePoint.PrintChar;
                    }

                   

                }


            }
           



        }
    }
}
