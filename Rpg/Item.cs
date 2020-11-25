using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    class Item
    {
        public enum Obj { Heal, Atk, Def }
        public Obj Effect;

        public int PotionPower;
        public int NumberOfUse;

        public string Description;

        public string Name;

        public Item(Obj effect, string name, int power, int uses)
        {
            Name = name;
            PotionPower = power;
            NumberOfUse = uses;
            Effect = effect;
            Description = "C'est une potion";
        }

        public void Use(Player p)
        {
            switch (Effect)
            {
                case Obj.Heal:
                    p.Hp += PotionPower;
                    break;
                case Obj.Atk:
                    p.Atk += PotionPower;
                    break;
                case Obj.Def:
                    p.Def += PotionPower;
                    break;
                default:
                    break;
            }
            NumberOfUse--;
        }
    }
}
