using System;
using System.Collections.Generic;
using AdventureGame.Manager;
using AdventureGame.Obstacles;

namespace AdventureGame.Locations.Battle
{
    public abstract class BattleLoc : Location
    {
        protected Obstacle obstacle;
        protected string lootName;
        protected int maxObsCount;
        protected CombatManager _combatManager;
        protected List<Obstacle> obstacleList;
        protected int obsCount;

        public BattleLoc(Player player, string name, Obstacle obstacle, string lootName, int maxObsCount) : base(player)
        {
            this.name = name;
            this.obstacle = obstacle;
            this.lootName = lootName;
            this.maxObsCount = maxObsCount;
            this.obsCount = GenerateObsCount(maxObsCount);
            this._combatManager = new CombatManager();
            this.obstacleList = new List<Obstacle>();
        }
        
        public int GenerateObsCount(int number)
        {
            Random rand = new Random();
            return rand.Next(number) + 1;
        }

        public override bool GetLocation()
        {
            Console.WriteLine("You are in " + this.name + "!");
            Console.WriteLine("There are " + obsCount + " " + obstacle.Name + "s ! \n");

            CreateObstacles(name, obsCount);
            
            var selCase = DialogManager.SelectBattleOrEscape();
            if (selCase == "B")
            {
                for (var i=1; i <= obsCount; i++)
                {
                    if (!_combatManager.Combat(player, obstacleList[i-1]))
                    {
                        Console.WriteLine("You died!");
                        return false;
                    }

                    DialogManager.BattleDialog(i, obsCount, this.obstacle);
                }

                Console.WriteLine("\nCongrulations! You defeat all the " + obstacle.Name + " in " + this.name +
                                  " and collected the " + this.lootName +"!");
                
                player.Inventory.GivePlayerLoot(lootName);
            }
            else
            {
                player.EscapeAttemps++;
            }

            return true;
        }

        public void CreateObstacles(string name, int obsCount)
        {
            for (int i = 0; i < obsCount; i++)
            {
                switch (name)
                {
                    case "Cave" :
                        obstacleList.Add(new Zombie());
                        break;
                    case "River" :
                        obstacleList.Add(new Bear());
                        break;
                    case "Forest" :
                        obstacleList.Add(new Vampire());
                        break;
                }
            }
        }
        
    }
}