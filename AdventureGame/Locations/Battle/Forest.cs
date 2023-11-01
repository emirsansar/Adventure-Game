using AdventureGame.Obstacles;

namespace AdventureGame.Locations.Battle
{
    public class Forest : BattleLoc
    {
        public Forest(Player player) : base(player, "Forest", new Vampire(), "Firewood", 3)
        {
        }
    }
}