using System;

namespace AdventureGame.Locations.Normal
{
    public class SafeHouse : NormalLoc
    {
        public SafeHouse(Player player) : base(player, "Safe House")
        {
        }

        public override bool GetLocation()
        {
            player.Healthy = (player.MaxHp);
            Console.WriteLine("You have been healed. You are in safe now.");

            return true;
        }
    }
}