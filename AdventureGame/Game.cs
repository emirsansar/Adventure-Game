using System;
using AdventureGame.Locations;
using AdventureGame.Locations.Battle;
using AdventureGame.Locations.Normal;
using AdventureGame.Manager;

namespace AdventureGame
{
    public class Game
    {
        Player player;
        Location location;

        public void Login()
        {
            Console.WriteLine("Welcome to the Adventure Game!");
            Console.WriteLine("You must collect all the loots from Cave, Forest, and Firewood to win the game!");
            Console.WriteLine("In the game, you can only escape from the battlefield 'three' times! \n");
            Console.Write("Please, enter your name: \n");
            string usernName = Console.ReadLine(); 
            player = new Player(usernName);
            player.SelectCharacter();
            Start();
        }

        private void Start()
        {
            while (true)
            {   
                DialogManager.SelectLocationOptions();
                
                int selLoc;
                while (!int.TryParse(Console.ReadLine(), out selLoc) || selLoc < 1 || selLoc > 6)
                {
                    Console.Write("Please, enter a valid location: \n");
                }

                switch (selLoc)
                {
                    case 1:
                        location = new SafeHouse(player);
                        break;
                    case 2:
                        location = new Cave(player);
                        break;
                    case 3:
                        location = new Forest(player);
                        break;
                    case 4:
                        location = new River(player);
                        break;
                    case 5:
                        location = new ToolStore(player);
                        break;
                    case 6:
                        Console.WriteLine("Exiting game...");
                        return;
                    default:
                        Console.WriteLine("Invalid input. Please choose a valid location.");
                        break;
                }

                if (!location.GetLocation() || CheckEscapes())
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (CheckWin())
                {
                    Console.WriteLine("Congratulations. You won the game by collecting all the loots.");
                    break;
                }
            }
        }
        
        private bool CheckWin()
        {
            Console.WriteLine();
            bool hasWater = player.Inventory.Water;
            bool hasFood = player.Inventory.Food;
            bool hasFirewood = player.Inventory.Firewood;
            
            DialogManager.DisplayPlayerLoots(hasWater,hasFood,hasFirewood);

            return (hasWater && hasFood && hasFirewood);
        }

        public bool CheckEscapes()
        {
            return player.EscapeAttemps >= 3;
        }
    }
}