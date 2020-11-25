using System;
using System.Collections.Generic;
using System.Text;

namespace Rpg
{
    abstract class Person
    {
        public enum Role { Warrior, Mage, Gobelin, Demon, Boss };
        public Role Type;
        public string Name;
        public int Hp;
        public int Atk;
        public int Def;

        public Person(Role role, string name)
        {
            Type = role;
            Name = name;
        }

        public virtual void damage(int amount)
        {
            Hp -= amount;
            if (Hp <= 0)
                Console.WriteLine("Couic");
        }


    }
}
