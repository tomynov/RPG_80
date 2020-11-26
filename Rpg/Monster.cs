using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class Monster : Person
    {
        public Item Loot;
        public Monster(Role role, string name) :base(role, name)
        {
            switch (role)
            {
                case Role.Gobelin:
                    Hp = 100;
                    Atk = 60;
                    Def = 60;
                    Loot = new Item(Item.Obj.Heal,"Potion",20,2);
                    break;
                case Role.Demon:
                    Hp = 180;
                    Atk = 75;
                    Def = 60;
                    Loot = new Item(Item.Obj.Atk, "Tomahawk ", 30,2);
                    break;
                case Role.Boss:
                    Hp = 200;
                    Atk = 90;
                    Def = 90;
                    Loot = new Item(Item.Obj.Atk, "Sword", 100, 1);
                    break;
            }
        }

        public override void damage(int amount)
        {
            base.damage(amount);
            if (Hp < 0)
                Console.WriteLine(Loot.Name);
        }
    }
}
