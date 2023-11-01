namespace AdventureGame.Items
{
    public class ArmorItem : Item
    {
        private int protection;
        
        public ArmorItem(string name, int cost, int protection, string armor) : base(name, cost, "Armor")
        {
            this.protection = protection;
        }

        public int Protection
        {
            get { return protection; }
            set { protection = value; }
        }
    }
}