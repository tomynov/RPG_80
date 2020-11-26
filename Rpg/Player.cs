using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class Player : Person
    {
        public List<Item> Inventory;

        public Player(Role role, string name) : base(role, name)
        {
            Inventory = new List<Item>();
            Inventory.Add(new Item(Item.Obj.Heal, "Heal", 35, 2));
            Inventory.Add(new Item(Item.Obj.Atk, "Knife", 20, 4));

            switch (role)
            {
                case Role.Warrior:
                    Hp = 50;
                    Atk = 100;
                    Def = 50;
                    break;
                case Role.Mage:
                    Hp = 25;
                    Atk = 120;
                    Def = 59;
                    break;

            }
        }
    }
}
