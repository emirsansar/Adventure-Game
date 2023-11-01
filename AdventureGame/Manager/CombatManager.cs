using System;
using AdventureGame.Obstacles;

namespace AdventureGame.Manager
{
    public class CombatManager
    {
        public bool Combat(Player player, Obstacle obstacle)
        {   
            PlayerStats(player);
            ObstacleStats(obstacle);

            while (player.Healthy > 0 && obstacle.Health > 0)
            {
                string selCase = DialogManager.SelectHitOrEscape();
                if (selCase == "H")
                {
                    PlayerAttack(obstacle, player);
                    Console.WriteLine();
                    if (obstacle.Health > 0)
                    {
                        EnemyAttack(obstacle, player);
                    }
                }
                else
                {
                    player.EscapeAttemps++;
                    break;
                }
            }
            
            if (player.Healthy > 0)
            {
                player.Money +=  obstacle.Award ;
                Console.WriteLine("You have won " + obstacle.Award + " money by defeating " + obstacle.Name + " Your money: " + player.Money);
            }
            else
            {
                return false;
            }

            return true;
        }
        
        private void PlayerAttack(Obstacle obstacle, Player player)
        {
            Console.WriteLine("You hit!");
            obstacle.Health = (obstacle.Health - player.TotalDamage());
            StatsAfterHit(obstacle, player);
        }

        private void EnemyAttack(Obstacle obstacle, Player player)
        {
            Console.WriteLine(obstacle.Name + " hit you!");
            var damageTaken = obstacle.Damage - player.Inventory.ArmorItem.Protection;

            if (damageTaken < 0)
            {
                damageTaken = 0;
            }
            player.Healthy -= damageTaken;
            StatsAfterHit(obstacle, player);
        }
        
        private void PlayerStats(Player player)
        {
            Console.WriteLine("Character's health: " + player.Healthy + ", total damage: " + player.TotalDamage() + " money: " + player.Money);
        }

        private void ObstacleStats(Obstacle obstacle)
        {
            Console.WriteLine(obstacle.Name + "'s health: " + obstacle.Health + ", total damage: " + obstacle.Damage+ " award: " + obstacle.Award);
        }

        private void StatsAfterHit(Obstacle obstacle, Player player)
        {
            if (obstacle.Health < 0)
            {
                obstacle.Health = 0;
            }
            Console.WriteLine("Your health: " + player.Healthy + " -VS-  " + obstacle.Name + "'s health: " + obstacle.Health);
        }
        
    }
}