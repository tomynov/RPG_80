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
            Inventory = new List<Item>(); //Liste d'item que possède le joueur au début du jeu
            Inventory.Add(new Item(Item.Obj.Heal, "Heal", 35, 2));
            Inventory.Add(new Item(Item.Obj.Atk, "Knife", 25, 4));

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
