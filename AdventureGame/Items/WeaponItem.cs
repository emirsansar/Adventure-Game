namespace AdventureGame.Items
{
    public class WeaponItem : Item
    {
        private int damage;
        
        public WeaponItem(string name, int cost, int damage, string weapon) : base(name, cost, "Weapon")
        {
            this.Damage = damage;
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
    }
}