using AdventureGame.Items;

namespace AdventureGame
{
    public class Inventory
    {
        private bool water, food, firewood;
        private WeaponItem weaponItem = new WeaponItem("null", 0, 0, "Weapon");
        private ArmorItem armorItem = new ArmorItem("null",0,0,"Armor");
        
        public bool Water
        {
            get { return water; }
            set { water = value;  }
        }
        public bool Food
        {
            get { return food; }
            set { food = value;  }
        }
        public bool Firewood
        {
            get { return firewood; }
            set { firewood = value;  }
        }

        public WeaponItem WeaponItem
        {
            get { return weaponItem; }
            set { weaponItem = value; }
        }
        
        public ArmorItem ArmorItem
        {
            get { return armorItem; }
            set { armorItem = value; }
        }
        
        public void GivePlayerLoot(string name)
        {
            switch (name)
            {
                case "Food" :
                    Food = true;
                    break;
                case "Firewood" :
                    Firewood = true;
                    break;
                case "Water" :
                    Water = true;
                    break;
            }
        }
    }
}