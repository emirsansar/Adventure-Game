namespace AdventureGame.Locations
{
    public abstract class Location
    {
        protected Player player;
        protected string name;
        
        public Location(Player player)
        {
            this.Player = player;
        }

        public abstract bool GetLocation(); 
        
        public string Name
        {
            get { return name; }
            set => name = value;
        }
        
        public Player Player
        {
            get { return player; }
            set { player = value; }
        }
    }
}