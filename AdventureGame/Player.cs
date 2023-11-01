using System;
using AdventureGame.Manager;

namespace AdventureGame
{
    public class Player
    {
        private string userName, charName;
        private int damage, money, healthy, maxHP, totalDamage;
        private int escapeAttempts;
        private Inventory inventory;

        public Player(string userName)
        {   
            this.userName = userName;
            this.escapeAttempts = 0;
            this.inventory = new Inventory();
        }
        
        public void SelectCharacter()
        {
            switch (CharacterMenu())
            {
                case 1:
                    InitPlayer("Samurai", 5, 21, 15);
                    break;
                case 2:
                    InitPlayer("Archer", 7, 18, 20);
                    break;
                case 3:
                    InitPlayer("Knight", 8, 24, 5);
                    break;
            }
            Console.WriteLine("You have chosen the " + CharName + " class.");
        }

        private int CharacterMenu()
        {
            Console.WriteLine("Please, choose your character: ");
            Console.WriteLine("1- Samurai \t Damage: 5 \t Healthy: 21 \t Money: 15");
            Console.WriteLine("2- Archer \t Damage: 7 \t Healthy: 18 \t Money: 20");
            Console.WriteLine("3- Knight \t Damage: 8 \t Healthy: 24 \t Money: 5");
            Console.Write("Your choice: \n");

            return DialogManager.SelectNumberInRange(1,3);
        }
        
        private void InitPlayer(string charName, int dmg, int healthy, int money)
        {
            this.charName = charName;
            this.damage = dmg;
            this.healthy = healthy;
            this.money = money;
            this.maxHP = healthy;
        }

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public int Healthy
        {
            get { return healthy; }
            set { healthy = value;  }
        }

        public string CharName
        {
            get { return charName; }
            set { charName = value; }
        }

        public int Damage
        {
            get { return damage; }
            set { damage = value; }
        }
        
        public int Money
        {
            get { return money; }
            set { money = value; }
        }

        public int MaxHp
        {
            get { return maxHP; }
            set { maxHP = value; }
        }

        public Inventory Inventory
        {
            get { return inventory; }
            set { inventory = value; }
        }

        public int EscapeAttemps
        {
            get { return escapeAttempts; }
            set { escapeAttempts = value; }
        }

        public int TotalDamage()
        {
            return this.damage + inventory.WeaponItem.Damage;
        }
    }
}