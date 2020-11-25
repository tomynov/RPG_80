using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class Player : Person
    {
        public Role r;

        public List<Item> Inventory;

        public Player(Role role, string name) : base(role, name)
        {
            Inventory = new List<Item>();
            Inventory.Add(new Item(Item.Obj.Heal, "heal", 5, 2));
            Inventory.Add(new Item(Item.Obj.Atk, "Atk", 5, 2));

            switch (role)
            {
                case Role.Warrior:
                    Hp = 50;
                    Atk = 100;
                    Def = 40;
                    break;
                case Role.Mage:
                    Hp = 20;
                    Atk = 200;
                    Def = 60;
                    break;

            }
        }
    }
}
