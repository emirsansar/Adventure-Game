namespace AdventureGame.Obstacles
{
    public abstract class Obstacle
    {
        private string name;
        private int damage, health, award;

        public Obstacle(string name, int damage, int health, int award)
        {
            this.name = name;
            this.damage = damage;
            this.health = health;
            this.award = award;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value;  }
        }
        
        public int Award
        {
            get { return award; }
            set { award = value; }
        }
    }
}