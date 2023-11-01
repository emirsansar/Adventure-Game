using System;
using AdventureGame.Items;
using AdventureGame.Manager;

namespace AdventureGame.Locations.Normal
{
    public class ToolStore : NormalLoc
    {
        public ToolStore(Player player) : base(player, "Tool Shop")
        {
        }

        public override bool GetLocation()
        {
            Console.WriteLine("You entered the tool shop. You have: " + player.Money + " money.");
            Console.WriteLine("1. Weapons: ");
            Console.WriteLine("2. Armors: ");
            Console.WriteLine("3. Exit. ");
            Console.Write("\nYour choice: ");

            var selection = DialogManager.SelectNumberInRange(1,4);

            switch (selection)
            {
                case 1:
                    BuyWeapon(WeaponMenu());
                    break;
                case 2:
                    BuyArmor(ArmorMenu());
                    break;
                case 3:
                    break;
            }

            return true;
        }
        
        private int WeaponMenu()
        {
            Console.WriteLine("1. Gun ---> \t Damage: 2 / Cost: 25");
            Console.WriteLine("2. Sword ---> \t Damage: 3 / Cost: 35");
            Console.WriteLine("3. Rifle ---> \t Damage: 7 / Cost: 45");
            Console.WriteLine("4. Cancel.");
            Console.Write("\nYour choice: ");
            
            return DialogManager.SelectNumberInRange(1,4);
        }

        private void BuyWeapon(int itemId)
        {
            WeaponItem item = null;
            
            switch (itemId)
            {
                case 1:
                    item = new WeaponItem("Gun", 25, 2, "Weapon");
                    break;
                case 2:
                    item = new WeaponItem("Sword", 35, 3, "Weapon");
                    break;
                case 3:
                    item = new WeaponItem("Rifle", 45, 7, "Weapon");
                    break;
            }

            if (item != null && player.Money >= item.Cost)
            {
                player.Money -= item.Cost;
                Console.WriteLine("You bought the " + player.Inventory.WeaponItem.Name + ". Your new damage: " + player.Damage);
                Console.WriteLine("The money you have: " + player.Money);
            }
            else if (player.Inventory.WeaponItem.Name == item.Name)
            {
                if(item!= null) Console.WriteLine("You have already this weapon!");
            }
            else 
            {
                if (item != null) Console.WriteLine("You don't have enough money to buy " + item.Name);
            }
        }

        
        private int ArmorMenu()
        {
            Console.WriteLine("1. Leather Armor ---> \t Protection: 1 / Cost: 15");
            Console.WriteLine("2. Chain Armor ---> \t Protection: 3 / Cost: 25");
            Console.WriteLine("3. Iron Armor ---> \t Protection: 6 / Cost: 40");
            Console.WriteLine("4. Cancel.");
            Console.Write("Your choice:");

            return DialogManager.SelectNumberInRange(1,4);
        }

        private void BuyArmor(int itemId)
        {
            ArmorItem item = null;
            
            switch (itemId)
            {
                case 1:
                    item = new ArmorItem("Leather Armor",15,1, "Armor");
                    break;
                case 2:
                    item = new ArmorItem("Chain Armor",25, 3,"Armor");
                    break;
                case 3:
                    item = new ArmorItem("Iron Armor",40, 5,"Armor");
                    break;
            }

            if (item != null && player.Money >= item.Cost)
            {
                player.Money -= item.Cost;
                player.Inventory.ArmorItem = item;
                Console.WriteLine("You bought the " + player.Inventory.ArmorItem.Name + ". Your new protection: +" + player.Inventory.ArmorItem.Protection);
                Console.WriteLine("The money you have: " + player.Money);
            }
            else if (player.Inventory.ArmorItem.Name == item.Name)
            {
                if(item!= null) Console.WriteLine("You have already this armor!");
            }
            else
            {
                if (item != null) Console.WriteLine("You don't have enough money to buy " + item.Name);
            }
        }

    }
}