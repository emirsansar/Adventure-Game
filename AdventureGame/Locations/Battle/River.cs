using AdventureGame.Obstacles;

namespace AdventureGame.Locations.Battle
{
    public class River : BattleLoc
    {
        public River(Player player) : base(player, "River", new Bear(), "Water", 2)
        {
        }
    }
}