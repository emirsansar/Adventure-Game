using AdventureGame.Obstacles;

namespace AdventureGame.Locations.Battle
{
    public class Cave : BattleLoc
    {
        public Cave(Player player) : base(player, "Cave", new Zombie(), "Food", 3)
        {
        }
    }
}