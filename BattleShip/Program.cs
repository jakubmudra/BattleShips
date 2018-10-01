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

            gb.ships.Add(new Ship(3, 'K', "Kriznik", new List<Point>() { new Point(1, 2, true, 'K'), new Point(2, 2, true, 'K'), new Point(3, 2, true, 'K') }, size,                                                      new List<Point>() { new Point(2, 1, true, 'K'), new Point(2, 2, true, 'K'), new Point(2, 3, true, 'K') },                                                      new List<Point>() { new Point(1, 2, true, 'K'), new Point(2, 2, true, 'K'), new Point(3, 2, true, 'K') },                                                      new List<Point>() { new Point(2, 1, true, 'K'), new Point(2, 2, true, 'K'), new Point(2, 3, true, 'K') }));               gb.ships.Add(new Ship(4, 'B', "Bitevni lod", new List<Point>() { new Point(1, 2, true, 'B'), new Point(2, 2, true, 'B'), new Point(3, 2, true, 'B'), new Point(4, 2, true, 'B') }, size,                                                          new List<Point>() { new Point(2, 1, true, 'B'), new Point(2, 2, true, 'B'), new Point(2, 3, true, 'B'), new Point(2, 4, true, 'B') },                                                          new List<Point>() { new Point(1, 2, true, 'B'), new Point(2, 2, true, 'B'), new Point(3, 2, true, 'B'), new Point(4, 2, true, 'B') },                                                          new List<Point>() { new Point(2, 1, true, 'B'), new Point(2, 2, true, 'B'), new Point(2, 3, true, 'B'), new Point(2, 4, true, 'B') }));               gb.ships.Add(new Ship(5, 'L', "Letadlova lod", new List<Point>() { new Point(1, 3, true, 'L'), new Point(2, 3, true, 'L'), new Point(3, 3, true, 'L'), new Point(4, 3, true, 'L'), new Point(5, 3, true, 'L') }, size,                                                              new List<Point>() { new Point(3, 1, true, 'L'), new Point(3, 2, true, 'L'), new Point(3, 3, true, 'L'), new Point(3, 4, true, 'L'), new Point(3, 5, true, 'L') },                                                              new List<Point>() { new Point(1, 3, true, 'L'), new Point(2, 3, true, 'L'), new Point(3, 3, true, 'L'), new Point(4, 3, true, 'L'), new Point(5, 3, true, 'L') },                                                              new List<Point>() { new Point(3, 1, true, 'L'), new Point(3, 2, true, 'L'), new Point(3, 3, true, 'L'), new Point(3, 4, true, 'L'), new Point(3, 5, true, 'L') }));                  gb.ships.Add(new Ship(6, 'Z', "Pristavaci zakladna", new List<Point>() { new Point(1, 1, true, 'Z'), new Point(2, 1, true, 'Z'), new Point(3, 1, true, 'Z'),                                                                                      new Point(1, 2, true, 'Z'), new Point(2, 2, true, 'Z'), new Point(3, 2, true, 'Z') }, size,                                                                  new List<Point>() { new Point(1, 1, true, 'Z'), new Point(2, 1, true, 'Z'),                                                                                      new Point(1, 2, true, 'Z'), new Point(2, 2, true, 'Z'),                                                                                      new Point(1, 3, true, 'Z'), new Point(2, 3, true, 'Z')},                                                                   new List<Point>() { new Point(1, 1, true, 'Z'), new Point(2, 1, true, 'Z'), new Point(3, 1, true, 'Z'),                                                                                      new Point(1, 2, true, 'Z'), new Point(2, 2, true, 'Z'), new Point(3, 2, true, 'Z') },                                                                  new List<Point>() { new Point(1, 1, true, 'Z'), new Point(2, 1, true, 'Z'),                                                                                      new Point(1, 2, true, 'Z'), new Point(2, 2, true, 'Z'),                                                                                      new Point(1, 3, true, 'Z'), new Point(2, 3, true, 'Z')}));                 gb.ships.Add(new Ship(6, 'H', "Hydroplan", new List<Point>() {                             new Point(1, 2, true, 'H'),
                                                                           new Point(2, 1, true, 'H'),                              new Point(3, 2, true, 'H') }, size,                                                          new List<Point>() {                             new Point(2, 1, true, 'H'),                                                                            new Point(3,2, true, 'H'),                              new Point(2, 3, true, 'H') },                                                          new List<Point>() {                             new Point(1, 2, true, 'H'),                                                                            new Point(2, 3, true, 'H'),                              new Point(3, 2, true, 'H') },                                                          new List<Point>() {                             new Point(1, 2, true, 'H'),                                                                            new Point(2, 1, true, 'H'),                              new Point(2, 3, true, 'H') }));                   gb.ships.Add(new Ship(6, 'R', "Kriznik II", new List<Point>() {                             new Point(2, 1, true, 'R'),
                                                                            new Point(1, 2, true, 'R'), new Point(2, 2, true, 'R'), new Point(3, 2, true, 'R') }, size,                                    new List<Point>() {                                                    new Point(3, 2, true, 'R'),                                                                             new Point(2, 1, true, 'R'), new Point(2, 2, true, 'R'), new Point(2, 3, true, 'R') },                                     new List<Point>() {                                                    new Point(2, 3, true, 'R'),                                                                             new Point(1, 2, true, 'R'), new Point(2, 2, true, 'R'), new Point(3, 2, true, 'R') },                                    new List<Point>() {                                                    new Point(2, 1, true, 'R'),                                                                             new Point(1, 2, true, 'R'), new Point(2, 2, true, 'R'), new Point(2, 3, true, 'R') }));                   gb.ships.Add(new Ship(6, 't', "Tezky Kriznik", new List<Point>() {                          new Point(2, 1, true, 't'),                                                                             new Point(1, 2, true, 't'), new Point(2, 2, true, 't'), new Point(3, 2, true, 't'),                                                                                                         new Point(2, 3, true, 't') }, size,                                  new List<Point>() {                          new Point(2, 1, true, 't'),                                                                             new Point(1, 2, true, 't'), new Point(2, 2, true, 't'), new Point(3, 2, true, 't'),                                                                                                         new Point(2, 3, true, 't') },                                  new List<Point>() {                          new Point(2, 1, true, 't'),                                                                             new Point(1, 2, true, 't'), new Point(2, 2, true, 't'), new Point(3, 2, true, 't'),                                                                                                         new Point(2, 3, true, 't') },                                  new List<Point>() {                          new Point(2, 1, true, 't'),                                                                             new Point(1, 2, true, 't'), new Point(2, 2, true, 't'), new Point(3, 2, true, 't'),                 new Point(2, 3, true, 't') }));                  gb.ships.Add(new Ship(6, 'C', "Katamaran", new List<Point>() {  new Point(1, 1, true, 'c'),                            new Point(3, 1, true, 'c'),                                                                             new Point(1, 2, true, 'c'), new Point(2, 2, true, 'c'),new Point(3, 2, true, 'c'),                                                                             new Point(1, 3, true, 'c'),                            new Point(3, 3, true, 'c')}, size,                                                        new List<Point>() {  new Point(1, 1, true, 'c'),                            new Point(3, 1, true, 'c'),                                                                             new Point(2, 1, true, 'c'), new Point(2, 2, true, 'c'),new Point(2, 3, true, 'c'),                                                                             new Point(1, 3, true, 'c'),                            new Point(3, 3, true, 'c')},                                                        new List<Point>() {  new Point(1, 1, true, 'c'),                            new Point(3, 1, true, 'c'),                                                                             new Point(1, 2, true, 'c'), new Point(2, 2, true, 'c'),new Point(3, 2, true, 'c'),                                                                             new Point(1, 3, true, 'c'),                            new Point(3, 3, true, 'c')},                                                        new List<Point>() {  new Point(1, 1, true, 'c'),                            new Point(3, 1, true, 'c'),                                                                             new Point(2, 1, true, 'c'), new Point(2, 2, true, 'c'),new Point(2, 3, true, 'c'),                                                                             new Point(1, 3, true, 'c'),                            new Point(3, 3, true, 'c')}));                gb.ships.Add(new Ship(6, 'b', "Lehka bitevni lod", new List<Point>() {   new Point(2, 1, true, 'b'),                                                                                      new Point(2, 2, true, 'b'), new Point(3, 2, true, 'b') }, size,                                                                  new List<Point>() {   new Point(2, 1, true, 'b'),                                                                                      new Point(2, 2, true, 'b'), new Point(3, 1, true, 'b') },                                                                  new List<Point>() {   new Point(2, 1, true, 'b'),                                                                                      new Point(3, 2, true, 'b'), new Point(3, 1, true, 'b') },                                                                  new List<Point>() {   new Point(3, 1, true, 'b'),                                                                                      new Point(2, 2, true, 'b'), new Point(3, 2, true, 'b') }));               gb.ships.Add(new Ship(6, 'l', "Lehka bitevni lod", new List<Point>() {                                                                                     new Point(4, 2, true, 'l'),new Point(5, 2, true, 'l'),                                                                                      new Point(1, 3, true, 'l'),new Point(2, 3, true, 'l'), new Point(3, 3, true, 'l'),new Point(4, 3, true, 'l'), new Point(5, 3, true, 'l') }, size,                                                                   new List<Point>() {                                                                                     new Point(4, 4, true, 'l'),new Point(4, 5, true, 'l'),                                                                                      new Point(3, 1, true, 'l'),new Point(3, 2, true, 'l'), new Point(3, 3, true, 'l'),new Point(3, 4, true, 'l'), new Point(3, 5, true, 'l') },                                                                   new List<Point>() {                                                                                     new Point(1, 4, true, 'l'),new Point(2, 4, true, 'l'),                                                                                      new Point(1, 3, true, 'l'),new Point(2, 3, true, 'l'), new Point(3, 3, true, 'l'),new Point(4, 3, true, 'l'), new Point(5, 3, true, 'l') },                                                                   new List<Point>() {                                                                                     new Point(2, 1, true, 'l'),new Point(2, 2, true, 'l'),                                                                                      new Point(3, 1, true, 'l'),new Point(3, 2, true, 'l'), new Point(3, 3, true, 'l'),new Point(3, 4, true, 'l'), new Point(3, 4, true, 'l') }));



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
