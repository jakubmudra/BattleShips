using System;
namespace BattleShip
{
    public class KeyHandler
    {



        public int[] GetCooInput()
        {

            Console.WriteLine("Jsi na tahu. Zadej souřadnice ve tvaru pisemno.cislo  (př. A.1)");

            int[] ReturnArray = new int[2];

            bool run = true;

            while(run)
            {

                string userInput = Console.ReadLine();

                if(userInput.Length == 0)
                {
                    Console.WriteLine("Musíš zadat platné souřadnice, zkus to znovu");
                }else{

                    if(userInput.Contains("."))
                    {

                        string[] ArrayInput = userInput.Split(".");

                        char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

                        ReturnArray[1] = Array.IndexOf(alpha, char.Parse(ArrayInput[0])) + 1;

                        ReturnArray[0] = int.Parse(ArrayInput[1]);

                        run = false;
                    }
                    else{
                        Console.WriteLine("Musíš zada souřadnice ve formátu pismeno.cislo (př. A.1), zkus to znovu");

                    }
                }


            }

            return ReturnArray;

        }


    }
}
