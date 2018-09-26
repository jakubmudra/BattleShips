using System;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            Point point = new Point(1,2,true,'0');

            Console.WriteLine(point.GetCoo()[0]);

        
        }
    }
}
