namespace AdventureGame.Items
{
    public abstract class Item
    {
        private string name;
        private int cost;
        private string itemType;

        public Item(string name, int cost, string itemType)
        {
            this.Name = name;
            this.Cost = cost;
            this.ItemType = itemType;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        
        public string ItemType
        {
            get { return itemType; }
            set { itemType = value; }
        }
    }
}