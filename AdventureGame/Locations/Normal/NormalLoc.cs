namespace AdventureGame.Locations.Normal
{
    public abstract class NormalLoc : Location
    {
        public NormalLoc(Player player, string name) : base(player)
        {
            this.Name = name;
        }
        
        public override bool GetLocation()
        {
            return true;
        }
    }
}