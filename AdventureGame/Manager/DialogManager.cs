using System;
using AdventureGame.Obstacles;

namespace AdventureGame.Manager
{
    public class DialogManager
    {
        public static string SelectBattleOrEscape()
        {
            string selectedCase;
            do
            {
                Console.Write("Press 'B' to battle, 'E' to escape. ");
                selectedCase = (Console.ReadLine()).ToUpper();

                if (selectedCase != "B" && selectedCase != "E")
                {
                    Console.WriteLine("Invalid option! Please, press 'B' to battle, 'E' to escape.");
                }
            } while (selectedCase != "B" && selectedCase != "E");

            return selectedCase;
        }
        
        public static string SelectHitOrEscape()
        {
            string selectedCase;
            do
            {
                Console.Write("Press 'H' to hit, 'E' to escape. ");
                selectedCase = (Console.ReadLine()).ToUpper();

                if (selectedCase != "H" && selectedCase != "E")
                {
                    Console.WriteLine("Invalid option! Please, press 'B' to battle, 'E' to escape.");
                }
            } while (selectedCase != "H" && selectedCase != "E");

            return selectedCase;
        }

        public static void BattleDialog(int i, int obsCount, Obstacle obstacle)
        {
            if (obsCount > 1)
            {
                Console.WriteLine("You defeat the " + i + "/" + obsCount + " " + obstacle.Name +".");
                if (i == obsCount-1)
                {   
                    Console.WriteLine("The last " + obstacle.Name + " is coming towards you! \n");
                }
                else if (i == obsCount-2)
                {
                    Console.WriteLine("New " + obstacle.Name + " is coming towards you! \n");
                }
            }
            else
            {
                Console.WriteLine("You defeat the " + obstacle.Name);
            }
        }

        public static void SelectLocationOptions()
        {
            Console.WriteLine("\n========================\n");
            Console.WriteLine("Please, choose the location you want to go: ");
            Console.WriteLine("1. Safe House ---> A safe place for you.");
            Console.WriteLine("2. Cave ---> Defeat the Zombies and get the loot!");
            Console.WriteLine("3. Forest ---> Defeat the Vampires and get the loot!");
            Console.WriteLine("4. River ---> Defeat the bears and get the loot!");
            Console.WriteLine("5. Tool Shop ---> You can buy a weapon or armor.");
            Console.WriteLine("6. Exit Game.");

            Console.Write("Your choice: ");
        }

        public static void DisplayPlayerLoots(bool water, bool food, bool firewood)
        {
            Console.WriteLine("You need to collect the loots and so far, you have collected these:");
            Console.WriteLine("Has Water: " + water);
            Console.WriteLine("Has Food: " + food);
            Console.WriteLine("Has Firewood: " + firewood);
        }

        public static int SelectNumberInRange(int min, int max)
        {
            int selectedNum;
            
            do
            {
                selectedNum = int.Parse(Console.ReadLine());
        
                if (selectedNum < min || selectedNum > max)
                {
                    Console.WriteLine($"Please, enter a valid option. ({min} - {max})");
                }
        
            } while (selectedNum < min || selectedNum > max);
        
            return selectedNum;
        }
    }
}